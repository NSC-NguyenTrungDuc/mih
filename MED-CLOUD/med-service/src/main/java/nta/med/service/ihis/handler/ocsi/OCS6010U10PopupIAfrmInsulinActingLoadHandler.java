package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.CommonModelProto.ComboListItemInfo;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAfrmInsulinActingLoadRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAfrmInsulinActingLoadResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupIAfrmInsulinActingLoadHandler extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupIAfrmInsulinActingLoadRequest, OcsiServiceProto.OCS6010U10PopupIAfrmInsulinActingLoadResponse> {
	
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional
	public OCS6010U10PopupIAfrmInsulinActingLoadResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupIAfrmInsulinActingLoadRequest request) throws Exception {
		
		OcsiServiceProto.OCS6010U10PopupIAfrmInsulinActingLoadResponse.Builder response = OcsiServiceProto.OCS6010U10PopupIAfrmInsulinActingLoadResponse.newBuilder();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		
		String code = ocs0132Repository.getCodeNameByCodeAndCodeType(hospCode, language, "AUTO_JISI_PROCESS", "INSULIN_YN").get(0);
		String codeName = ocs0132Repository.getCodeNameByCodeAndCodeType(hospCode, language, "AUTO_JISI_PROCESS", "BS_CHECK_YN").get(0);
		
		ComboListItemInfo.Builder info = ComboListItemInfo.newBuilder()
				.setCode(code)
				.setCodeName(codeName);
		
		response.setFrmItem(info);
		return response.build();
	}

}
