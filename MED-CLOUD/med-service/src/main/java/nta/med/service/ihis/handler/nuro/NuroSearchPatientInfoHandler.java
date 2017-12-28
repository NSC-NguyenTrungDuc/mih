package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroSearchPatientInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroSearchPatientInfoHandler extends ScreenHandler<NuroServiceProto.NuroSearchPatientInfoRequest, NuroServiceProto.NuroSearchPatientInfoResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroSearchPatientInfoHandler.class);
	@Resource
	private Out0101Repository out0101Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroSearchPatientInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroSearchPatientInfoRequest request) throws Exception {
		NuroServiceProto.NuroSearchPatientInfoResponse.Builder response = NuroServiceProto.NuroSearchPatientInfoResponse.newBuilder();
		List<NuroSearchPatientInfo> listPatientInfo = out0101Repository.getNuroSearchPatientInfo(getHospitalCode(vertx, sessionId), request.getPatientCode());
        if (listPatientInfo != null && !listPatientInfo.isEmpty()) {
            for (NuroSearchPatientInfo obj : listPatientInfo) {
                NuroModelProto.NuroSearchPatientInfo.Builder patientInfoBuiler = NuroModelProto.NuroSearchPatientInfo.newBuilder();
                patientInfoBuiler.setPatientName1(obj.getPatientName1());
                patientInfoBuiler.setPatientName2(obj.getPatientName2());
                patientInfoBuiler.setBirth(obj.getBirth());
                
                response.addPatientInfoItem(patientInfoBuiler);
            }
        }
		return response.build();
	}
}
