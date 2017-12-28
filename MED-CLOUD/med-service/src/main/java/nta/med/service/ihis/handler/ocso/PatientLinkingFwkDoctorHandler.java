package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.ocsa.PatientLinkingFwkDoctorInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.PatientLinkingFwkDoctorRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.PatientLinkingFwkDoctorResponse;

@Service
@Scope("prototype")
public class PatientLinkingFwkDoctorHandler extends
		ScreenHandler<OcsoServiceProto.PatientLinkingFwkDoctorRequest, OcsoServiceProto.PatientLinkingFwkDoctorResponse> {

	@Resource
	private Bas0270Repository bas0270Repository;

	@Override
	@Transactional(readOnly = true)
	public PatientLinkingFwkDoctorResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			PatientLinkingFwkDoctorRequest request) throws Exception {
		
		OcsoServiceProto.PatientLinkingFwkDoctorResponse.Builder response = OcsoServiceProto.PatientLinkingFwkDoctorResponse.newBuilder();
		List<PatientLinkingFwkDoctorInfo> listDoctor = bas0270Repository.getPatientLinkingFwkDoctorInfo(request.getHospCode(), request.getGwa()); 
		for (PatientLinkingFwkDoctorInfo item : listDoctor) {
			OcsoModelProto.PatientLinkingFwkDoctorInfo.Builder info = OcsoModelProto.PatientLinkingFwkDoctorInfo.newBuilder();
			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			response.addDoctorList(info);
		}
		
		return response.build();
	}

}
