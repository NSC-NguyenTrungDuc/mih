package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10CreatePopupMenuRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10CreatePopupMenuHandler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10CreatePopupMenuRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Ocs2016Repository ocs2016Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10CreatePopupMenuRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String str = ocs2016Repository.getOCS6010U10CreatePopupMenuYn(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkocs2003()));
		
		response.setResult(str);
		return response.build();
	}

	
}
