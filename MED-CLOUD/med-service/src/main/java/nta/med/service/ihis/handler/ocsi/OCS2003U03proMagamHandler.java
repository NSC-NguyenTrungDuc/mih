package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03proMagamRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03proMagamResponse;

@Service
@Scope("prototype")
public class OCS2003U03proMagamHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03proMagamRequest, OcsiServiceProto.OCS2003U03proMagamResponse>{
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
	@Transactional
	public OCS2003U03proMagamResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03proMagamRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03proMagamResponse.Builder response = OcsiServiceProto.OCS2003U03proMagamResponse.newBuilder();
		String result = drg3010Repository.callPrDrgInpMagamProc(getHospitalCode(vertx, sessionId), request.getGubun(), request.getJubsuDate(), request.getOrderDate(), request.getHopeDate(), request.getMagamGubun(), 
				request.getMagamSer(), request.getBunho(), request.getDoctor(), request.getMagamUser()).getCode();
		if (!StringUtils.isEmpty(result)) 
			response.setDrgBunho(result);
		return response.build();
	}

}
