package nta.med.service.ihis.handler.drgs;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P06getUserIDRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class DRG3041P06getUserIDHandler
		extends ScreenHandler<DrgsServiceProto.DRG3041P06getUserIDRequest, SystemServiceProto.StringResponse> {

	@Override
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P06getUserIDRequest request) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

}
