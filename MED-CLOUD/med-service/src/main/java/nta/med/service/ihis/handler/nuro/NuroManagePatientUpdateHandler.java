package nta.med.service.ihis.handler.nuro;


import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0101Repository;
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
@Transactional
public class NuroManagePatientUpdateHandler extends ScreenHandler<NuroServiceProto.NuroManagePatientUpdateRequest, NuroServiceProto.NuroManagePatientUpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroManagePatientUpdateHandler.class);
	
	@Resource
	private Out0101Repository out0101Repository;

	@Override
	public NuroServiceProto.NuroManagePatientUpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroManagePatientUpdateRequest request) throws Exception {
		NuroServiceProto.NuroManagePatientUpdateResponse.Builder response = NuroServiceProto.NuroManagePatientUpdateResponse.newBuilder();
		NuroModelProto.NuroManagePatientUpdateData data = request.getPatientData();
		Integer updateData = out0101Repository.updateNuroPatientInfo(getHospitalCode(vertx, sessionId), data.getPatientCode(), data.getZipCode1(), data.getZipCode2(), data.getAddress1(), data.getAddress2(),
        		data.getTel(), data.getTel1(), data.getTelHp(), data.getTelGubun(), data.getTelGubun2(), data.getTelGubun3(), data.getEMail(), data.getPaceMakerYn(), data.getSelfPaceMaker());
		response.setResultUpdate(updateData != null && updateData > 0);
		return response.build();
	}
}
