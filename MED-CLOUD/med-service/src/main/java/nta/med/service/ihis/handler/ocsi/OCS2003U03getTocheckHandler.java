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
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getTocheckRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003U03getTocheckHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03getTocheckRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03getTocheckRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = drg3010Repository.getOCS2003U03getTocheckInfo(getHospitalCode(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho());
		if (!StringUtils.isEmpty(result))
			response.setResult(result);
		return response.build();
	}

}
