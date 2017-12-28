package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.model.ihis.cpls.CPL3010U01GrdHangmogInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01GrdHangmogRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01GrdHangmogResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3010U01GrdHangmogHandler extends ScreenHandler <CplsServiceProto.CPL3010U01GrdHangmogRequest, CplsServiceProto.CPL3010U01GrdHangmogResponse> {                     
	@Resource                                                                                                       
	private Cpl3020Repository cpl3020Repository;                                                                    
	                                                                                                                
	@Override                   
	@Transactional(readOnly = true)
	public CPL3010U01GrdHangmogResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U01GrdHangmogRequest request) throws Exception{                                                                   
  	   	CplsServiceProto.CPL3010U01GrdHangmogResponse.Builder response = CplsServiceProto.CPL3010U01GrdHangmogResponse.newBuilder();                      
		//get list Grd Hangmog 
		 List<CPL3010U01GrdHangmogInfo> listGrdHangmog=cpl3020Repository.getCPL3010U01GrdHangmogListItemInfo(getHospitalCode(vertx, sessionId),
				 getLanguage(vertx, sessionId),request.getRequestKey());
		 if(!CollectionUtils.isEmpty(listGrdHangmog)){
			 for(CPL3010U01GrdHangmogInfo item:listGrdHangmog){
				 CplsModelProto.CPL3010U01GrdHangmogInfo.Builder info= CplsModelProto.CPL3010U01GrdHangmogInfo.newBuilder();
				    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addGrdHangmogLst(info);
			 }
		 }
		 return response.build();
	}
}