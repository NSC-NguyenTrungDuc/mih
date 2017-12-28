package nta.med.service.ihis.handler.nuri;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GetLevelNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR1094U00GetLevelNameHandler
		extends ScreenHandler<NuriServiceProto.NUR1094U00GetLevelNameRequest, SystemServiceProto.StringResponse> {

	@Override
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1094U00GetLevelNameRequest request) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

}
