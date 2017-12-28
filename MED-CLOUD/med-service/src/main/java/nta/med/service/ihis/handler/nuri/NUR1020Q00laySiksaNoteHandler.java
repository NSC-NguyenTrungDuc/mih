package nta.med.service.ihis.handler.nuri;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00laySiksaNoteRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00laySiksaNoteResponse;

@Service
@Scope("prototype")
public class NUR1020Q00laySiksaNoteHandler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00laySiksaNoteRequest, NuriServiceProto.NUR1020Q00laySiksaNoteResponse> {

	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00laySiksaNoteResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00laySiksaNoteRequest request) throws Exception {
		NuriServiceProto.NUR1020Q00laySiksaNoteResponse.Builder response = NuriServiceProto.NUR1020Q00laySiksaNoteResponse
				.newBuilder();

		return response.build();
	}

}
