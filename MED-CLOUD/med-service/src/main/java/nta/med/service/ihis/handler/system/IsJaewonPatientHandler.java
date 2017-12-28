package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.IsJaewonPatientRequest;
import nta.med.service.ihis.proto.SystemServiceProto.IsJaewonPatientResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class IsJaewonPatientHandler
		extends ScreenHandler<SystemServiceProto.IsJaewonPatientRequest, SystemServiceProto.IsJaewonPatientResponse> {
	
	@Resource
	private Out0101Repository out0101Repository;

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public IsJaewonPatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			IsJaewonPatientRequest request) throws Exception {
		SystemServiceProto.IsJaewonPatientResponse.Builder response = SystemServiceProto.IsJaewonPatientResponse.newBuilder();
		String result = "";
		if(StringUtils.isEmpty(request.getAllowInpReser())){
			result = out0101Repository.getIsJaewonPatientInfo(request.getBunho(), getHospitalCode(vertx, sessionId));
		} else {
			result = inp1001Repository.getIsJaewonPatientInfo(request.getBunho(), getHospitalCode(vertx, sessionId));
		}
		
		response.setYValue(result == null ? "" : result);
		return response.build();
	}
}