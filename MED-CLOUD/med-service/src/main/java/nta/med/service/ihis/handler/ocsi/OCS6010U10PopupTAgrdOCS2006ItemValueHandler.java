package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0132;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006ItemValueRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006ItemValueResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupTAgrdOCS2006ItemValueHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006ItemValueRequest, OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006ItemValueResponse> {

	@Resource
	private Ocs0132Repository ocs0132Repository;

	@Override
	public OCS6010U10PopupTAgrdOCS2006ItemValueResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS6010U10PopupTAgrdOCS2006ItemValueRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006ItemValueResponse.Builder response = OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006ItemValueResponse.newBuilder();

		List<Ocs0132> lstOcs0132 = ocs0132Repository.findByHospCodeCodeTypeCode(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), "ORD_DANUI", request.getOrdDanui());

		if (!CollectionUtils.isEmpty(lstOcs0132)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
					.setDataValue(lstOcs0132.get(0).getCodeName());
			response.setObjItem(info);
		}

		return response.build();
	}

}
