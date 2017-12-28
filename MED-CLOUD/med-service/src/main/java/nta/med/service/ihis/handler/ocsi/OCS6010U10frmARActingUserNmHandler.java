package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActingUserNmRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10frmARActingUserNmHandler extends ScreenHandler<OcsiServiceProto.OCS6010U10frmARActingUserNmRequest, SystemServiceProto.StringResponse> {
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10frmARActingUserNmRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = request.getUserId();
		
		String strData = adm3200Repository.getOCS6010U10frmARActingUserNm(hospCode, userId);
		strData = StringUtils.isEmpty(strData) ? "" : strData;

		if (!StringUtils.isEmpty(strData)) {
			response.setResult(strData);
		}
			
		return response.build();
	}

}
