package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99layCheckDupRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99layCheckDupResponse;

@Service
@Scope("prototype")
public class OCS2003U99layCheckDupHandler extends ScreenHandler<OcsiServiceProto.OCS2003U99layCheckDupRequest, OcsiServiceProto.OCS2003U99layCheckDupResponse>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U99layCheckDupResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99layCheckDupRequest request) throws Exception {
		OcsiServiceProto.OCS2003U99layCheckDupResponse.Builder response = OcsiServiceProto.OCS2003U99layCheckDupResponse.newBuilder();
		String result = inp1001Repository.getOCS2003U99layCheckDupRequest(getHospitalCode(vertx, sessionId), request.getBunho());
		if (!StringUtils.isEmpty(result)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.addListCheck(info);
		}
		return response.build();
	}

}
