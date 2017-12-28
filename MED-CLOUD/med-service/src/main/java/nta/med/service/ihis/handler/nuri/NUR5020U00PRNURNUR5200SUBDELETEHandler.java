package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur5200Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00PRNURNUR5200SUBDELETERequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR5020U00PRNURNUR5200SUBDELETEHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00PRNURNUR5200SUBDELETERequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur5200Repository nur5200Repository;

	@Override
	@Transactional(readOnly = true)
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00PRNURNUR5200SUBDELETERequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();

		nur5200Repository.callPrNurNur5200SubDelete(getHospitalCode(vertx, sessionId), request.getHoDong(),
				request.getNurWrdt());

		response.setResult(true);
		return response.build();
	}

}
