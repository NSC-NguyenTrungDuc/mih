package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.IsResultToConsultRequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.IsResultToConsultRequest;
import nta.med.service.ihis.proto.SystemServiceProto.IsResultToConsultResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IsResultToConsultHandler
	extends ScreenHandler<SystemServiceProto.IsResultToConsultRequest, SystemServiceProto.IsResultToConsultResponse> {                             
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public IsResultToConsultResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, IsResultToConsultRequest request)
			throws Exception {                                                                  
      	   	SystemServiceProto.IsResultToConsultResponse.Builder response = SystemServiceProto.IsResultToConsultResponse.newBuilder();                      
		IsResultToConsultRequestInfo item = request.getInputInfo();
		if(item != null){
			String result = ocs1003Repository.callFnRehIsResultToConsult(getHospitalCode(vertx, sessionId), item.getPkocskey(), item.getIoGubun());
			if(!StringUtils.isEmpty(result)){
				response.setResult(result);
			}
		}
		return response.build();
	}
}