package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1093;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1093Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GetLevelRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR1094U00GetLevelHandler
		extends ScreenHandler<NuriServiceProto.NUR1094U00GetLevelRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur1093Repository nur1093Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1094U00GetLevelRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		List<Nur1093> items = nur1093Repository.findByHospCodeFDateFSum(getHospitalCode(vertx, sessionId),
				DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD), CommonUtils.parseDouble(request.getSum()));

		response.setResult(CollectionUtils.isEmpty(items) ? "" : items.get(0).getCode());
		return response.build();
	}

}
