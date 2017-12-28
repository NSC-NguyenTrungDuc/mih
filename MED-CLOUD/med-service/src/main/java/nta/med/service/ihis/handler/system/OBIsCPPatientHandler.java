package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBIsCPPatientRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBIsCPPatientResponse;

@Service                                                                                                          
@Scope("prototype")
public class OBIsCPPatientHandler extends ScreenHandler<SystemServiceProto.OBIsCPPatientRequest, SystemServiceProto.OBIsCPPatientResponse>{

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OBIsCPPatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OBIsCPPatientRequest request) throws Exception {
		
		SystemServiceProto.OBIsCPPatientResponse.Builder response = SystemServiceProto.OBIsCPPatientResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		
		String rs = ocs6010Repository.getOBIsCPPatientYn(hospCode, fkinp1001);
		response.setDecodeOut(rs);
		return response.build();
	}

	
}
