package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00GetFkinp1001Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR1020U00GetFkinp1001Handler
		extends ScreenHandler<NuriServiceProto.NUR1020U00GetFkinp1001Request, SystemServiceProto.StringResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00GetFkinp1001Request request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String pkinp1001 = inp1001Repository.getNUR1020U00Pkinp1001(getHospitalCode(vertx, sessionId),
				request.getBunho());

		response.setResult(pkinp1001);
		return response.build();
	}

}
