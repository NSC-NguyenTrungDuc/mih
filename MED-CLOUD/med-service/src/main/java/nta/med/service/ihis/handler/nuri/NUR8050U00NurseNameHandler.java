package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm3200;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8050U00NurseNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR8050U00NurseNameHandler
		extends ScreenHandler<NuriServiceProto.NUR8050U00NurseNameRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8050U00NurseNameRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		List<Adm3200> items = adm3200Repository.findByHospCodeUserIdSysDate(getHospitalCode(vertx, sessionId),
				request.getCode());

		response.setResult(CollectionUtils.isEmpty(items) ? "" : items.get(0).getUserNm());
		return response.build();
	}

}
