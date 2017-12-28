package nta.med.service.ihis.handler.nuri;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class NUR4001U00LayComboHandler extends ScreenHandler<NuriServiceProto.NUR4001U00LayComboRequest, SystemServiceProto.ComboResponse> {   
	
	//@Resource                                   

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR4001U00LayComboRequest request) throws Exception {
				
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		
		// TO DO
		
		return response.build();
	}
}
