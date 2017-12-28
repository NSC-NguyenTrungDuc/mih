package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01GrdOutsangColumnChangedRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003P01GrdOutsangColumnChangedHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01GrdOutsangColumnChangedRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01GrdOutsangColumnChangedRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = bas0260Repository.getBasLoadGwaName(request.getParam1(), request.getParam2(), getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if (!StringUtils.isEmpty(result))
			response.setResult(result);
		return response.build();
	}

}
