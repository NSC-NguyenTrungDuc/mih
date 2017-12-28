package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur4005;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur4005Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class NUR4001U00IsExistNUR4005Handler
		extends ScreenHandler<NuriServiceProto.NUR4001U00IsExistNUR4005Request, SystemServiceProto.StringResponse> {

	@Resource
	private Nur4005Repository nur4005Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR4001U00IsExistNUR4005Request request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		List<Nur4005> items = nur4005Repository.findByHospCodeFknur4001(getHospitalCode(vertx, sessionId),
				CommonUtils.parseDouble(request.getFknur4001()));

		response.setResult(CollectionUtils.isEmpty(items) ? "" : "Y");
		return response.build();
	}
}
