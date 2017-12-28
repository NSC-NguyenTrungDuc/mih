package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00checkInputControlRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00checkInputControlResponse;

@Service
@Scope("prototype")
public class OCS2005U00checkInputControlHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00checkInputControlRequest, OcsiServiceProto.OCS2005U00checkInputControlResponse>{
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00checkInputControlResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00checkInputControlRequest request) throws Exception {
		OcsiServiceProto.OCS2005U00checkInputControlResponse.Builder response = OcsiServiceProto.OCS2005U00checkInputControlResponse.newBuilder();
		String result = ocs0103Repository.getOCS2005U00checkInputControl(getHospitalCode(vertx, sessionId), request.getHangmogCode());
		if (!StringUtils.isEmpty(result))
			response.setInputControl(result);
		return response.build();
	}

}
