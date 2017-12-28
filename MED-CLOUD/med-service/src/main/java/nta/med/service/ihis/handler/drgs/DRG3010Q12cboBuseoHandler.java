package nta.med.service.ihis.handler.drgs;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010Q12cboBuseoRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class DRG3010Q12cboBuseoHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010Q12cboBuseoRequest, SystemServiceProto.ComboResponse> {

	@Override
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010Q12cboBuseoRequest request) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

}
