package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0110;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0110Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNur0110ColChangedRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0110U00GrdNur0110ColChangedHandler extends
		ScreenHandler<NuriServiceProto.NUR0110U00GrdNur0110ColChangedRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur0110Repository nur0110Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00GrdNur0110ColChangedRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		List<Nur0110> items = nur0110Repository.findByHospCodeNurGrCode(getHospitalCode(vertx, sessionId),
				request.getNurGrCode());

		response.setResult(CollectionUtils.isEmpty(items) ? "" : "Y");
		return response.build();
	}

}
