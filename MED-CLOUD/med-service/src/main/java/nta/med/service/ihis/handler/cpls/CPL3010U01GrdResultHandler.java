package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.model.ihis.cpls.CPL3010U01GrdResultInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01GrdResultRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01GrdResultResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3010U01GrdResultHandler extends ScreenHandler <CplsServiceProto.CPL3010U01GrdResultRequest, CplsServiceProto.CPL3010U01GrdResultResponse> {                     
	@Resource                                                                                                       
	private Cpl3020Repository cpl3020Repository;                                                                    
	                                                                                                                
	@Override            
	@Transactional(readOnly = true)
	public CPL3010U01GrdResultResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3010U01GrdResultRequest request)
			throws Exception  {                                                                   
  	   	CplsServiceProto.CPL3010U01GrdResultResponse.Builder response = CplsServiceProto.CPL3010U01GrdResultResponse.newBuilder();                      
		//get list GrdResult 
		 List<CPL3010U01GrdResultInfo> listGrdResult=cpl3020Repository.getCPL3010U01GrdResultListItemInfo(getHospitalCode(vertx, sessionId),
				 getLanguage(vertx, sessionId),request.getRequestKey());
		 if(!CollectionUtils.isEmpty(listGrdResult)){
			 for(CPL3010U01GrdResultInfo item : listGrdResult){
				 CplsModelProto.CPL3010U01GrdResultInfo.Builder info= CplsModelProto.CPL3010U01GrdResultInfo.newBuilder();
				 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				 response.addGrdResultLst(info);
			 }
		 }
		 return response.build();
	}
}