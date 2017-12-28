package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.cht.Cht0118Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00BuwiNameRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00BuwiNameResponse;

@Service
@Scope("prototype")
public class OCS2005U00BuwiNameHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00BuwiNameRequest, OcsiServiceProto.OCS2005U00BuwiNameResponse>{
	@Resource
	private Cht0118Repository cht0118Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00BuwiNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00BuwiNameRequest request) throws Exception {
		OcsiServiceProto.OCS2005U00BuwiNameResponse.Builder response = OcsiServiceProto.OCS2005U00BuwiNameResponse.newBuilder();
		String result = cht0118Repository.getOCS2005U00BuwiName(getHospitalCode(vertx, sessionId), request.getBuwiCode());
		if (!StringUtils.isEmpty(result))
			response.setBuwiName(result);
		return response.build();
	}

}
