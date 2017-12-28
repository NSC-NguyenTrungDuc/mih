package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.cpls.CPL3010U01GrdPaInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01GrdPaRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01GrdPaResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3010U01GrdPaHandler extends ScreenHandler <CplsServiceProto.CPL3010U01GrdPaRequest, CplsServiceProto.CPL3010U01GrdPaResponse> {                     
	@Resource                                                                                                       
	private Cpl0101Repository cpl0101Repository;                                                                    
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public CPL3010U01GrdPaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3010U01GrdPaRequest request)
			throws Exception  {                                                                   
  	   	 CplsServiceProto.CPL3010U01GrdPaResponse.Builder response = CplsServiceProto.CPL3010U01GrdPaResponse.newBuilder();                         	 
  	   	 List<CPL3010U01GrdPaInfo> listGrdPa = cpl0101Repository.getCplsCPL3010U01GrdPaCPL3010ListItemInfo(
				 request.getCenterCode(), request.getUitakCode(), 
				 getHospitalCode(vertx, sessionId),request.getFromPartJubsuDate(),
				 request.getToPartJubsuDate(),request.getFromSeq() ,request.getToSeq(),
				 request.getFromSpecimenSer(),request.getToSpecimenSer(),request.getCbxJubsuDate());
		 if(!CollectionUtils.isEmpty(listGrdPa)){
			 for(CPL3010U01GrdPaInfo item:listGrdPa){
				 CplsModelProto.CPL3010U01GrdPaInfo.Builder info= CplsModelProto.CPL3010U01GrdPaInfo.newBuilder();
				  BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				  response.addGrdPaLst(info);
			 }
		 }
		 return response.build();
	}

}