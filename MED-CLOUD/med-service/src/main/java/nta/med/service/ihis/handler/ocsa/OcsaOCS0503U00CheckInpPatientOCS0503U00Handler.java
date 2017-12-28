package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00CheckInpPatientRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00CheckInpPatientResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;


@Transactional
@Service
@Scope("prototype")
public class OcsaOCS0503U00CheckInpPatientOCS0503U00Handler
	extends ScreenHandler<OcsaServiceProto.OCS0503U00CheckInpPatientRequest, OcsaServiceProto.OCS0503U00CheckInpPatientResponse> {
	@Resource
    private Ocs0503Repository ocs0503Repository;
	@Override
	@Transactional(readOnly = true)
	public OCS0503U00CheckInpPatientResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0503U00CheckInpPatientRequest request) throws Exception {
		OcsaServiceProto.OCS0503U00CheckInpPatientResponse.Builder response=OcsaServiceProto.OCS0503U00CheckInpPatientResponse.newBuilder();
		Double result = ocs0503Repository.getOCS0503U00CheckInpPatient(getHospitalCode(vertx, sessionId), request.getBunho());
		if (result != null) {
			response.setPkinp1001(String.format("%.0f", result));
		}
		return response.build();
	}
}
