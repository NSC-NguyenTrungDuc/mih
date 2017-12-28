package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3400Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FormUserInfoUnRegisterSystemUserRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class FormUserInfoUnRegisterSystemUserHandler
	extends ScreenHandler <SystemServiceProto.FormUserInfoUnRegisterSystemUserRequest,  SystemServiceProto.UpdateResponse> {
	@Resource
	private Adm3400Repository adm3400Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			FormUserInfoUnRegisterSystemUserRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
    	if(adm3400Repository.deleteFormUserInfoUnRegisterSystemUser(getHospitalCode(vertx, sessionId), request.getUserId(), request.getSystemId(), request.getIpAddr()) > 0){
    		response.setResult(true);
    	}else{
    		response.setResult(false);
    	}
    	return response.build();
	}
}
