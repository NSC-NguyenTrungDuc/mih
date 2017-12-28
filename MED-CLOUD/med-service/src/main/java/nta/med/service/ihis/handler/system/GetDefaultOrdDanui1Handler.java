package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetDefaultOrdDanui1Request;
import nta.med.service.ihis.proto.SystemServiceProto.GetDefaultOrdDanui1Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetDefaultOrdDanui1Handler 
	extends ScreenHandler<SystemServiceProto.GetDefaultOrdDanui1Request, SystemServiceProto.GetDefaultOrdDanui1Response> {                     
	@Resource                                                                                                       
	private Ocs0108Repository ocs0108Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public GetDefaultOrdDanui1Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetDefaultOrdDanui1Request request)
			throws Exception {                                                               
  	   	SystemServiceProto.GetDefaultOrdDanui1Response.Builder response = SystemServiceProto.GetDefaultOrdDanui1Response.newBuilder();                      
		String ordDanui= ocs0108Repository.getGetDefaultOrdDanui1Request(getHospitalCode(vertx, sessionId),request.getHangmogCode());
		if(!StringUtils.isEmpty(ordDanui)){
			response.setOrdDanui(ordDanui);
		}
		return response.build();
	}
}