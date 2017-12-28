package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.HIOcsBogyongRequest;
import nta.med.service.ihis.proto.SystemServiceProto.HIOcsBogyongResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class HIOcsBogyongHandler
	extends ScreenHandler<SystemServiceProto.HIOcsBogyongRequest, SystemServiceProto.HIOcsBogyongResponse> {                     
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public HIOcsBogyongResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, HIOcsBogyongRequest request)
			throws Exception {                                                                  
  	   	SystemServiceProto.HIOcsBogyongResponse.Builder response = SystemServiceProto.HIOcsBogyongResponse.newBuilder();                      
		String result = drg0120Repository.getHIOcsBogyong(getHospitalCode(vertx, sessionId), request.getBogyongCode(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}
}
