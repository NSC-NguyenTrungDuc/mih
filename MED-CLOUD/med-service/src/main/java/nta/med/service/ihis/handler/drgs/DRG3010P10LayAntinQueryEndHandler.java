package nta.med.service.ihis.handler.drgs;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10LayAntinQueryEndRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10LayAntinQueryEndResponse;

@Service
@Scope("prototype")
public class DRG3010P10LayAntinQueryEndHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10LayAntinQueryEndRequest, DrgsServiceProto.DRG3010P10LayAntinQueryEndResponse> {

	@Override
	@Transactional(readOnly = true)
	public DRG3010P10LayAntinQueryEndResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10LayAntinQueryEndRequest request) throws Exception {
		DrgsServiceProto.DRG3010P10LayAntinQueryEndResponse.Builder response = DrgsServiceProto.DRG3010P10LayAntinQueryEndResponse.newBuilder();
		
		
		return response.build();
	}

	
}
