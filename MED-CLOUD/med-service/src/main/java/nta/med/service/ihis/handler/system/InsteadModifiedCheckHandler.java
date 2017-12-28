package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.InsteadModifiedCheckRequest;
import nta.med.service.ihis.proto.SystemServiceProto.InsteadModifiedCheckResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class InsteadModifiedCheckHandler
	extends ScreenHandler<SystemServiceProto.InsteadModifiedCheckRequest, SystemServiceProto.InsteadModifiedCheckResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003RepositoryO;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public InsteadModifiedCheckResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InsteadModifiedCheckRequest request) throws Exception {                                                                  
  	   	SystemServiceProto.InsteadModifiedCheckResponse.Builder response = SystemServiceProto.InsteadModifiedCheckResponse.newBuilder();                      
		String getResult =ocs1003RepositoryO.callFnOcsInsteadModifiedCheck(getHospitalCode(vertx, sessionId),CommonUtils.parseInteger(request.getPkkey()),request.getInputGubun(),request.getIoGubun());
		if(!StringUtils.isEmpty(getResult)){
			response.setIsPossibleInsteadOrder(getResult);
		}
		return response.build();
	}
}