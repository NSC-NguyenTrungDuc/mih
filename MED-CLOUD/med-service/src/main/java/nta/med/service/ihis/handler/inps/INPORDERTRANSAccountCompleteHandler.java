package nta.med.service.ihis.handler.inps;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSAccountCompleteRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSAccountCompleteResponse;

@Service
@Scope("prototype")
public class INPORDERTRANSAccountCompleteHandler extends
		ScreenHandler<InpsServiceProto.INPORDERTRANSAccountCompleteRequest, InpsServiceProto.INPORDERTRANSAccountCompleteResponse> {

	@Override
	public INPORDERTRANSAccountCompleteResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSAccountCompleteRequest request) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

}
