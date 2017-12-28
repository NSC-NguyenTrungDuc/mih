package nta.med.service.emr.handler;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.LoadPatientInfectionRequest;
import nta.med.service.emr.proto.EmrServiceProto.LoadPatientInfectionResponse;

@Service
@Scope("prototype")
public class LoadPatientInfectionHandler extends ScreenHandler<EmrServiceProto.LoadPatientInfectionRequest, EmrServiceProto.LoadPatientInfectionResponse>{
	@Resource
	private Nur1017Repository nur1017Repository;

	@Override
	@Transactional(readOnly = true)
	public LoadPatientInfectionResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadPatientInfectionRequest request) throws Exception {
		EmrServiceProto.LoadPatientInfectionResponse.Builder response = EmrServiceProto.LoadPatientInfectionResponse.newBuilder();
		String hospCode = request.getHospCode();
		if (StringUtils.isEmpty(hospCode)) 
			hospCode = getHospitalCode(vertx, sessionId);
		response.setInfectionCount(nur1017Repository.getNUR1017PatientInfection(hospCode, request.getBunho()));
		return response.build();
	}
}
