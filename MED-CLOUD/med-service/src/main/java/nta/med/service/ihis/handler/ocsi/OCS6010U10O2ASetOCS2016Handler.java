package nta.med.service.ihis.handler.ocsi;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10O2ASetOCS2016Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10O2ASetOCS2016Response;

@Service
@Scope("prototype")
public class OCS6010U10O2ASetOCS2016Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10O2ASetOCS2016Request, OcsiServiceProto.OCS6010U10O2ASetOCS2016Response> {

	@Override
	public OCS6010U10O2ASetOCS2016Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10O2ASetOCS2016Request request) throws Exception {
		
		OcsiServiceProto.OCS6010U10O2ASetOCS2016Response.Builder response = OcsiServiceProto.OCS6010U10O2ASetOCS2016Response.newBuilder();
		
		return response.build();
	}

	
}
