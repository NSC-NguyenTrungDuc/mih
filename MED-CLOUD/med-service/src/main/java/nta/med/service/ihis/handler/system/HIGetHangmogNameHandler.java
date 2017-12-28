package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.HIGetHangmogNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto.HIGetHangmogNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class HIGetHangmogNameHandler
	extends ScreenHandler<SystemServiceProto.HIGetHangmogNameRequest, SystemServiceProto.HIGetHangmogNameResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public HIGetHangmogNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, HIGetHangmogNameRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.HIGetHangmogNameResponse.Builder response = SystemServiceProto.HIGetHangmogNameResponse.newBuilder();                      
		String result = ocs0103Repository.getHIGetHangmogName(getHospitalCode(vertx, sessionId),request.getHangmogCode());
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}
}