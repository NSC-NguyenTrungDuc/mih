package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.HIGetGenericNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto.HIGetGenericNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class HIGetGenericNameHandler
	extends ScreenHandler<SystemServiceProto.HIGetGenericNameRequest, SystemServiceProto.HIGetGenericNameResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public HIGetGenericNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, HIGetGenericNameRequest request)
			throws Exception {                                                                  
  	   	SystemServiceProto.HIGetGenericNameResponse.Builder response = SystemServiceProto.HIGetGenericNameResponse.newBuilder();                      
		String generic = ocs0103Repository.getHIGetGenericName(getHospitalCode(vertx, sessionId),request.getHangmogCode());
		if(!StringUtils.isEmpty(generic)){
			response.setResult(generic);
		}
		return response.build();
	}
}