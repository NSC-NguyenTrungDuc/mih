package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.data.model.ihis.emr.OCS2015U00LoadPatientMedicalRecordInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U00LoadPatientMedicalRecordHandler extends ScreenHandler<EmrServiceProto.OCS2015U00LoadPatientMedicalRecordRequest, EmrServiceProto.OCS2015U00LoadPatientMedicalRecordResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U00LoadPatientMedicalRecordHandler.class);                                    
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;



	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U00LoadPatientMedicalRecordResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U00LoadPatientMedicalRecordRequest request) throws Exception {
		EmrServiceProto.OCS2015U00LoadPatientMedicalRecordResponse.Builder response = EmrServiceProto.OCS2015U00LoadPatientMedicalRecordResponse.newBuilder();
		OCS2015U00LoadPatientMedicalRecordInfo item = emrRecordRepository.getOCS2015U00LoadPatientMedicalRecordInfo(request.getBunho(), getHospitalCode(vertx, sessionId));
		EmrModelProto.OCS2015U00LoadPatientMedicalRecordInfo.Builder info = EmrModelProto.OCS2015U00LoadPatientMedicalRecordInfo.newBuilder();
		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		response.addPatientMedicalInfo(info);
		return response.build();
	}
}