package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.adm.Adm3400;
import nta.med.data.dao.medi.adm.Adm3400Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ChangeSystemUserRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class ChangeSystemUserHandler extends ScreenHandler<SystemServiceProto.ChangeSystemUserRequest, SystemServiceProto.UpdateResponse> {                   
	private static final Log LOGGER = LogFactory.getLog(ChangeSystemUserHandler.class);                                    
	@Resource                                                                                                       
	private Adm3400Repository adm3400Repository;                                                                    

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, ChangeSystemUserRequest request)
			throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
		Integer result = adm3400Repository.updateChangeSystemUser(new Date(), request.getAfUserId(), getHospitalCode(vertx, sessionId),
				request.getBfUserId(), request.getSystemId(), request.getIpAddr());
		if(result == 0){
			Adm3400 adm3400 = new Adm3400();
			adm3400.setSysId(request.getSystemId());
			adm3400.setUserId(request.getAfUserId());
			adm3400.setIpAddr(request.getIpAddr());
			adm3400.setEntrTime(new Date());
			adm3400.setHospCode(getHospitalCode(vertx, sessionId));
			adm3400Repository.save(adm3400);
		}
		response.setResult(true);
		return response.build();
	}                                                                                                                 
}