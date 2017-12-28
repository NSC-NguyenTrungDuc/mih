package nta.med.service.ihis.handler.inps;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSExecuteProcRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSExecuteProcResponse;

@Service
@Scope("prototype")
public class INPORDERTRANSExecuteProcHandler extends
		ScreenHandler<InpsServiceProto.INPORDERTRANSExecuteProcRequest, InpsServiceProto.INPORDERTRANSExecuteProcResponse> {

	@Override
	public INPORDERTRANSExecuteProcResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSExecuteProcRequest request) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

	
}
