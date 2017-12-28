package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupMPDGetCheckModifyPlandateRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupMPDGetCheckModifyPlandateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupMPDGetCheckModifyPlandateHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupMPDGetCheckModifyPlandateRequest, OcsiServiceProto.OCS6010U10PopupMPDGetCheckModifyPlandateResponse> {

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS6010U10PopupMPDGetCheckModifyPlandateResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS6010U10PopupMPDGetCheckModifyPlandateRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupMPDGetCheckModifyPlandateResponse.Builder response = OcsiServiceProto.OCS6010U10PopupMPDGetCheckModifyPlandateResponse.newBuilder();
		String str = ocs6010Repository.getOCS6010U10PopupMPDGetCheckModifyPlandate(getHospitalCode(vertx, sessionId),
				CommonUtils.parseDouble(request.getFkocs6010()), request.getModifyDate());
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(str);
		response.setRetvalItem(info);
		
		return response.build();
	}

	
}
