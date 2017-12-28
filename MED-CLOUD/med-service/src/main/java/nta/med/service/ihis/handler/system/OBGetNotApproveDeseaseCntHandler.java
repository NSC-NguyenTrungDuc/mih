package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.App1001Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBGetNotApproveDeseaseCntRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBGetNotApproveDeseaseCntResponse;

@Service
@Scope("prototype")
public class OBGetNotApproveDeseaseCntHandler extends
		ScreenHandler<SystemServiceProto.OBGetNotApproveDeseaseCntRequest, SystemServiceProto.OBGetNotApproveDeseaseCntResponse> {

	@Resource
	private App1001Repository app1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OBGetNotApproveDeseaseCntResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OBGetNotApproveDeseaseCntRequest request) throws Exception {
		
		SystemServiceProto.OBGetNotApproveDeseaseCntResponse.Builder response = SystemServiceProto.OBGetNotApproveDeseaseCntResponse.newBuilder();
		String rsCnt = app1001Repository.getOBGetNotApproveDeseaseCnt(getHospitalCode(vertx, sessionId),
				request.getFIoGubun(), request.getFInsteadYn(), request.getFApproveYn(), request.getFDoctorId(),
				request.getFBunho());
		
		response.setFnOut(rsCnt);
		return response.build();
	}

	
}
