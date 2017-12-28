package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01OrderValidationRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003P01OrderValidationHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01OrderValidationRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01OrderValidationRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = cpl0101Repository.callFnCplLoadDupGrdHangmog(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getParam1(), request.getParam2(), request.getParam3(), request.getParam4());
		if (!StringUtils.isEmpty(result))
			response.setResult(result);
		return response.build();
	}

}
