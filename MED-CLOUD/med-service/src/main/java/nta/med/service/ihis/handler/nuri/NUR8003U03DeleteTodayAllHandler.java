package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur8003Repository;
import nta.med.data.dao.medi.nur.Nur8033Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03DeleteTodayAllRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR8003U03DeleteTodayAllHandler
		extends ScreenHandler<NuriServiceProto.NUR8003U03DeleteTodayAllRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur8003Repository nur8003Repository;

	@Resource
	private Nur8033Repository nur8033Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03DeleteTodayAllRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();

		nur8003Repository.deleteByHospCodeBunhoWriteDate(getHospitalCode(vertx, sessionId), request.getBunho(),
				DateUtil.toDate(request.getWriteDate(), DateUtil.PATTERN_YYMMDD));
		
		nur8033Repository.deleteByHospCodeBunhoWriteDate(getHospitalCode(vertx, sessionId), request.getBunho(),
				DateUtil.toDate(request.getWriteDate(), DateUtil.PATTERN_YYMMDD));

		response.setResult(true);
		return response.build();
	}

}
