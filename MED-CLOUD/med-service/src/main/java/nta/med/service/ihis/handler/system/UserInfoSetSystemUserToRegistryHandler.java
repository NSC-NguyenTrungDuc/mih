package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm3400;
import nta.med.data.dao.medi.adm.Adm3400Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import nta.med.service.ihis.proto.SystemServiceProto.UserInfoSetSystemUserToRegistryRequest;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class UserInfoSetSystemUserToRegistryHandler extends ScreenHandler<SystemServiceProto.UserInfoSetSystemUserToRegistryRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Adm3400Repository adm3400Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			UserInfoSetSystemUserToRegistryRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	if(adm3400Repository.updateUserInfoSetSystemUserToRegistry(new Date(), hospCode, request.getUserId(), request.getSystemId(), request.getIpAddr()) <= 0){
    		Adm3400 adm3400 = new Adm3400();
    		adm3400.setSysId(request.getSystemId());
    		adm3400.setUserId(request.getUserId());
    		adm3400.setIpAddr(request.getIpAddr());
    		adm3400.setEntrTime(new Date());
    		adm3400.setHospCode(hospCode);
    		
    		adm3400Repository.save(adm3400);
    	}
    	response.setResult(true);
    	return response.build();
	}
}
