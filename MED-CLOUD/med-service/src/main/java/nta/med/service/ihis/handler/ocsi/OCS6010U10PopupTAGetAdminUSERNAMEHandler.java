package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAGetAdminUSERNAMERequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAGetAdminUSERNAMEResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupTAGetAdminUSERNAMEHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupTAGetAdminUSERNAMERequest, OcsiServiceProto.OCS6010U10PopupTAGetAdminUSERNAMEResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS6010U10PopupTAGetAdminUSERNAMEResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS6010U10PopupTAGetAdminUSERNAMERequest request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupTAGetAdminUSERNAMEResponse.Builder response = OcsiServiceProto.OCS6010U10PopupTAGetAdminUSERNAMEResponse.newBuilder();
		String userNm = adm3200Repository.getUserNmByUserId(getHospitalCode(vertx, sessionId), request.getUserId());
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(userNm);
		response.setUserName(info);
		return response.build();
	}

	
}
