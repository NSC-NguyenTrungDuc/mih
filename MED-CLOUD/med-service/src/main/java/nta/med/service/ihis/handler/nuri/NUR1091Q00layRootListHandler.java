package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1091;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1091Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091Q00layRootListRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR1091Q00layRootListHandler
		extends ScreenHandler<NuriServiceProto.NUR1091Q00layRootListRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Nur1091Repository nur1091Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1091Q00layRootListRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();

		List<Nur1091> items = nur1091Repository.findByHospCodeFDate(getHospitalCode(vertx, sessionId),
				DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));

		for (Nur1091 item : items) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCodeType())
					.setCodeName(item.getCodeTypeName() == null ? "" : item.getCodeTypeName());
			response.addComboItem(info);
		}

		return response.build();
	}

}
