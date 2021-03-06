package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99DeptCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003U99DeptCodeHandler extends ScreenHandler<OcsiServiceProto.OCS2003U99DeptCodeRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99DeptCodeRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = adm3200Repository.getOCS2003U99DeptCodeRequest(getHospitalCode(vertx, sessionId), request.getRecieverId());
		if (!StringUtils.isEmpty(result))
			response.setResult(result);
		return response.build();
	}

}
