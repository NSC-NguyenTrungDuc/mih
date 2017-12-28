package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10GetCheckModifyPlanRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10GetCheckModifyPlanHandler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10GetCheckModifyPlanRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Ocs6010Repository ocs6010Repository;

	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10GetCheckModifyPlanRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String modifyDate = request.getModifyDate();
		String fkocs6010 = request.getFkocs6010();

		String strData = ocs6010Repository.getOCS6010U10GetCheckModifyPlan(hospCode, modifyDate, fkocs6010);

		strData = StringUtils.isEmpty(strData) ? "" : strData;
		response.setResult(strData);

		return response.build();
	}

}
