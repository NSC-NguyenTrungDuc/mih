package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg3020Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03proBongtuRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003U03proBongtuHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03proBongtuRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Drg3020Repository drg3020Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03proBongtuRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = drg3020Repository.callPrDrgLoadBongtuSer(getHospitalCode(vertx, sessionId), request.getJubsuDate(), request.getMagamGubun(), request.getBunho(), request.getMagamDept(), request.getUpdId());
		if (!StringUtils.isEmpty(result))
			response.setResult(result);
		return response.build();
	}

}
