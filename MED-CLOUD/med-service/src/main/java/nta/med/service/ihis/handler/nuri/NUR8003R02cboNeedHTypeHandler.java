package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003R02cboNeedHTypeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR8003R02cboNeedHTypeHandler
		extends ScreenHandler<NuriServiceProto.NUR8003R02cboNeedHTypeRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003R02cboNeedHTypeRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();

		List<Nur0102> listNur0102 = nur0102Repository.findByCodeTypeLanguage(getHospitalCode(vertx, sessionId),
				"NEED_H_TYPE", getLanguage(vertx, sessionId));
		for (Nur0102 item : listNur0102) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addComboItem(info);
		}

		return response.build();
	}

}