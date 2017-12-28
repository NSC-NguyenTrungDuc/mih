package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.phy.Phy8002Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01ApplyCopyRehaRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003P01ApplyCopyRehaHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01ApplyCopyRehaRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Phy8002Repository phy8002Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01ApplyCopyRehaRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		Double result = phy8002Repository.getOCS0103U11GetFkOcs(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkocskey()));
		if (request != null)
			response.setResult(CommonUtils.parseString(result));
		return response.build();
	}

}
