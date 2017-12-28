package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01IsCommonDocConsultRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003P01IsCommonDocConsultHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01IsCommonDocConsultRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01IsCommonDocConsultRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = bas0270Repository.getOCS2003P01IsCommonDocConsultInfo(getHospitalCode(vertx, sessionId), request.getDoctor(), request.getDate());
		if (!StringUtils.isEmpty(result))
			response.setResult(result);
		return response.build();
	}

}
