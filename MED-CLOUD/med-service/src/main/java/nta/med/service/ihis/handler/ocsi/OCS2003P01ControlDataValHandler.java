package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01ControlDataValRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003P01ControlDataValHandler
		extends ScreenHandler<OcsiServiceProto.OCS2003P01ControlDataValRequest, SystemServiceProto.StringResponse> {
	@Resource
	private Bas0260Repository bas0260Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01ControlDataValRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = bas0260Repository.callFnDrgConvBuseoCode(getHospitalCode(vertx, sessionId), request.getGwa());
		
		response.setResult(result == null ? "" : result);
		
		return response.build();
	}

}
