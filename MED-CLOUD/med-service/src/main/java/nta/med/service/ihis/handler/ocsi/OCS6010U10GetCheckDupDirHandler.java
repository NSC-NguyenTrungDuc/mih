package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs6013Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10GetCheckDupDirRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10GetCheckDupDirHandler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10GetCheckDupDirRequest, SystemServiceProto.StringResponse> {
	@Resource
	private Ocs6013Repository ocs6013Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10GetCheckDupDirRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = ocs6013Repository.getOCS6010U10GetCheckDupDirRequest(getHospitalCode(vertx, sessionId), request.getFkocs6010(), request.getAInputGubun(), request.getAOrderDate(), request.getDirectGubun(), request.getDirectCode());
		if (!StringUtils.isEmpty(result))
			response.setResult(result);
		return response.build();
	}

}
