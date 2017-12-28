package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01GetGroupKeyHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GetGroupKeyRequest, OcsoServiceProto.OcsoOCS1003P01GetGroupKeyResponse> {
	private static final Log LOG = LogFactory.getLog(OcsoOCS1003P01GetGroupKeyHandler.class);
	
	@Resource
	private Bas0102Repository bas0102Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01GetGroupKeyResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GetGroupKeyRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GetGroupKeyResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GetGroupKeyResponse.newBuilder();
		String result = bas0102Repository.getOcsoOCS1003P01GetGroupKey(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getPkout1001(), request.getCodeType());
    	if (!StringUtils.isEmpty(result)) {
			response.setGroupKey(result);
    	}
		return response.build();
	}

}
