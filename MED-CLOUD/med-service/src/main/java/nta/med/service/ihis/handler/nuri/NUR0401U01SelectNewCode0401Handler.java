package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0401Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01SelectNewCode0401Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0401U01SelectNewCode0401Handler
		extends ScreenHandler<NuriServiceProto.NUR0401U01SelectNewCode0401Request, SystemServiceProto.StringResponse> {

	@Resource
	private Nur0401Repository nur0401Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01SelectNewCode0401Request request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		String rs = nur0401Repository.getNUR0401U01SelectNewCode0401(getHospitalCode(vertx, sessionId),
				request.getMaxVal(), request.getNurPlanBunryu());
		response.setResult(rs);

		return response.build();
	}

}
