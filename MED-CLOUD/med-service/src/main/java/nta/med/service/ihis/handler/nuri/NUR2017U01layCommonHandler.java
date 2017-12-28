package nta.med.service.ihis.handler.nuri;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017U01layCommonRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR2017U01layCommonHandler
		extends ScreenHandler<NuriServiceProto.NUR2017U01layCommonRequest, SystemServiceProto.ComboResponse> {

	@Override
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2017U01layCommonRequest request) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

}
