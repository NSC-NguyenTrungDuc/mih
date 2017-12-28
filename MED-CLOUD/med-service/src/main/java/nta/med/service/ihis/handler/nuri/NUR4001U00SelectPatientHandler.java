package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class NUR4001U00SelectPatientHandler
		extends ScreenHandler<NuriServiceProto.NUR4001U00SelectPatientRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR4001U00SelectPatientRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		Double pkinp1001 = inp1001Repository.getPkinp1001ByHospCodeBunho(getHospitalCode(vertx, sessionId),
				request.getBunho());

		response.setResult(pkinp1001 == null ? "" : String.valueOf(pkinp1001));
		return response.build();
	}
}
