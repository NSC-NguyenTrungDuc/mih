package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01IsSameNameCHKRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003P01IsSameNameCHKHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01IsSameNameCHKRequest, SystemServiceProto.StringResponse>{
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01IsSameNameCHKRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = inp1001Repository.callFnAdmIsSameNameYnInpT(request.getBunho(), getHospitalCode(vertx, sessionId));
		response.setResult(result == null ? "" : result);
			
		return response.build();
	}
}
