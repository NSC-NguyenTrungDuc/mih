package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00CancelUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR2004U00CancelUpdateHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U00CancelUpdateRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00CancelUpdateRequest request) throws Exception {

		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		String fkinp1001 = request.getFkinp1001();
		String transCnt = request.getTransCnt();
		String userId = request.getUserId();
		String cancelSayu = request.getCancelSayu();
		
		if (inp2004Repository.updateNUR2004U00CancelUpdate(userId, cancelSayu, hospCode, bunho, fkinp1001, transCnt) <= 0) {
			return response.setResult(false).build();
		}

		response.setResult(true);
		return response.build();
	}
}
