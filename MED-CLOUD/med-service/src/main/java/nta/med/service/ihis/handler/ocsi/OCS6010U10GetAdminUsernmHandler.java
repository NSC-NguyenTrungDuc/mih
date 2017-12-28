package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10GetAdminUsernmRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10GetAdminUsernmResponse;

@Service
@Scope("prototype")
public class OCS6010U10GetAdminUsernmHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10GetAdminUsernmRequest, OcsiServiceProto.OCS6010U10GetAdminUsernmResponse> {
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS6010U10GetAdminUsernmResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10GetAdminUsernmRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10GetAdminUsernmResponse.Builder response = OcsiServiceProto.OCS6010U10GetAdminUsernmResponse.newBuilder();
		List<ComboListItemInfo> list = adm3200Repository.callFnPpeLoadConfirmEnable(getHospitalCode(vertx, sessionId), request.getUserId());
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				OcsiModelProto.OCS6010U10GetAdminUsernmInfo.Builder info = OcsiModelProto.OCS6010U10GetAdminUsernmInfo.newBuilder();
				info.setUserNm(item.getCode());
				info.setConfirmGrant(item.getCodeName());
				response.addResList(info);
			}
		}
		
		return response.build();
	}

}
