package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99layChkCommonRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99layChkCommonResponse;

@Service
@Scope("prototype")
public class OCS2003U99layChkCommonHandler extends ScreenHandler<OcsiServiceProto.OCS2003U99layChkCommonRequest, OcsiServiceProto.OCS2003U99layChkCommonResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U99layChkCommonResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99layChkCommonRequest request) throws Exception {
		OcsiServiceProto.OCS2003U99layChkCommonResponse.Builder response = OcsiServiceProto.OCS2003U99layChkCommonResponse.newBuilder();
		String result = ocs2003Repository.getOCS2003U99layChkCommonRequest(getHospitalCode(vertx, sessionId), request.getBunho(), request.getPkinp1001(), "D6");
		if (!StringUtils.isEmpty(result)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.addListCHK(info);
		}
		return response.build();
	}

}
