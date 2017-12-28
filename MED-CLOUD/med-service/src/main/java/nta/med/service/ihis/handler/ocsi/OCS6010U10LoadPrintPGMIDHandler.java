package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs6013Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10LoadPrintPGMIDRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10LoadPrintPGMIDHandler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10LoadPrintPGMIDRequest, SystemServiceProto.StringResponse> {
	@Resource
	private Ocs6013Repository ocs6013Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10LoadPrintPGMIDRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = ocs6013Repository.callFnOcsLoadOrderPrtPgmId(getHospitalCode(vertx, sessionId), request.getTableId(), request.getPkOrder());
		if (!StringUtils.isEmpty(result))
			response.setResult(result);
		return response.build();
	}

}
