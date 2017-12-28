package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg9043Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIfJusaConfRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupIfJusaConfHandler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupIfJusaConfRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Drg9043Repository drg9043Repository;
	
	@Override
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupIfJusaConfRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String strCheck = drg9043Repository.getOCS6010U10PopupIfJusaConf(getHospitalCode(vertx, sessionId));
		
		response.setResult(strCheck);
		return response.build();
	}

	
}
