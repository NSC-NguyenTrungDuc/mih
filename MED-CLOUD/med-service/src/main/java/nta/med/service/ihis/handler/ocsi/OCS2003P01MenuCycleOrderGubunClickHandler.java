package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01MenuCycleOrderGubunClickRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS2003P01MenuCycleOrderGubunClickHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01MenuCycleOrderGubunClickRequest, SystemServiceProto.UpdateResponse>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01MenuCycleOrderGubunClickRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(false);
		String resutl = inp1001Repository.callPrOcsSetCycleOrderGroup(getHospitalCode(vertx, sessionId), request.getBunho(), request.getColor());
		if (!StringUtils.isEmpty(resutl)) {
			response.setMsg(resutl);
			response.setResult(true);
		}
		return response.build();
	}

}
