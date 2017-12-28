package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm0700Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99SeqRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003U99SeqHandler extends ScreenHandler<OcsiServiceProto.OCS2003U99SeqRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Adm0700Repository adm0700Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99SeqRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = adm0700Repository.getOCS2003U99SeqRequest(getHospitalCode(vertx, sessionId), request.getSenderId());
		if (!StringUtils.isEmpty(result)) 
			response.setResult(result);
		return response.build();
	}

}