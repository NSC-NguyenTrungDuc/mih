package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBChkSimsaMagamINP1001Request;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBOutputResponse;

@Service
@Scope("prototype")
public class NURILIBChkSimsaMagamINP1001Handler extends
		ScreenHandler<NuriServiceProto.NURILIBChkSimsaMagamINP1001Request, NuriServiceProto.NURILIBOutputResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NURILIBOutputResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NURILIBChkSimsaMagamINP1001Request request) throws Exception {
		NuriServiceProto.NURILIBOutputResponse.Builder response = NuriServiceProto.NURILIBOutputResponse.newBuilder();
		String result = inp1001Repository.getINP1001simsaMagam(getHospitalCode(vertx, sessionId),
				request.getPkinp1001());
		
		response.setOutput(result);
		return response.build();
	}

}
