package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.cpls.CPL3010U01LayPrint2Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01LayPrint2Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01LayPrint2Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3010U01LayPrint2Handler extends ScreenHandler<CplsServiceProto.CPL3010U01LayPrint2Request, CplsServiceProto.CPL3010U01LayPrint2Response> {                     
	@Resource                                                                                                       
	private Cpl0101Repository cpl0101Repository;                                                                    
	                                                                                                                
	@Override            
	@Transactional(readOnly = true)
	public CPL3010U01LayPrint2Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3010U01LayPrint2Request request)
			throws Exception {                            
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
  	   	CplsServiceProto.CPL3010U01LayPrint2Response.Builder response = CplsServiceProto.CPL3010U01LayPrint2Response.newBuilder();                      
		List<CPL3010U01LayPrint2Info> listLayPrint2;
		if(request.getCbxJubsuDate()){
		 listLayPrint2 = cpl0101Repository.getCplsCPL3010U01LayPrint2ListItemInfo(hospCode, language,
				 request.getFromPartJubsuDate(),request.getFromSeq() ,request.getToPartJubsuDate(),request.getToSeq());
		 if(listLayPrint2 !=null && !listLayPrint2.isEmpty()){
			 for(CPL3010U01LayPrint2Info item :listLayPrint2){
			    CplsModelProto.CPL3010U01LayPrint2Info.Builder info= CplsModelProto.CPL3010U01LayPrint2Info.newBuilder();
			    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayPrintLst(info);
			 }
		 }
		}else{
		 listLayPrint2=cpl0101Repository.getCplsCPL3010U01LayPrint2ListItemInfo2(hospCode, language,request.getFromSpecimenSer(),request.getToSpecimenSer());
		 if(listLayPrint2 !=null && !listLayPrint2.isEmpty()){
			 for(CPL3010U01LayPrint2Info item :listLayPrint2){
				CplsModelProto.CPL3010U01LayPrint2Info.Builder info= CplsModelProto.CPL3010U01LayPrint2Info.newBuilder();
			    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayPrintLst(info);
			 }
		 }
		}
		return response.build();
	}
}