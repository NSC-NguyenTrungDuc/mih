package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetHangmogGridFindListInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTACreateCombo2Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupTACreateCombo2Handler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupTACreateCombo2Request, SystemServiceProto.ComboResponse> {
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupTACreateCombo2Request request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<OCS0311U00grdSetHangmogGridFindListInfo> list = ocs0103Repository.getOCS0311U00grdSetHangmogGridFindListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getHangmogCode());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS0311U00grdSetHangmogGridFindListInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(StringUtils.isEmpty(item.getOrdDanui()) ? "" : item.getOrdDanui());
				info.setCodeName(StringUtils.isEmpty(item.getCodeName()) ? "" : item.getCodeName());
				response.addComboItem(info);
			}
		}
		return response.build();
	}

	
}
