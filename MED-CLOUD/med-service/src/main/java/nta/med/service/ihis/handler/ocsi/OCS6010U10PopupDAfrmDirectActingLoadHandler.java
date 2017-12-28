package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupDAfrmDirectActingLoadRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupDAfrmDirectActingLoadResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupDAfrmDirectActingLoadHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupDAfrmDirectActingLoadRequest, OcsiServiceProto.OCS6010U10PopupDAfrmDirectActingLoadResponse> {

	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	public OCS6010U10PopupDAfrmDirectActingLoadResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS6010U10PopupDAfrmDirectActingLoadRequest request) throws Exception {
		
		OcsiServiceProto.OCS6010U10PopupDAfrmDirectActingLoadResponse.Builder response = OcsiServiceProto.OCS6010U10PopupDAfrmDirectActingLoadResponse.newBuilder();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		
		List<String> listString = ocs0132Repository.getCodeNameByCodeAndCodeType(hospCode, language, "AUTO_JISI_PROCESS", "AUTO_YN");

		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		response.setObjItem(info.setDataValue(listString.get(0)));
		return response.build();
	}

}
