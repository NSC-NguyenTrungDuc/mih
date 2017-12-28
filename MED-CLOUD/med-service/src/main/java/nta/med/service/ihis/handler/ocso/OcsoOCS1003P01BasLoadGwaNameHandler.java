package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01BasLoadGwaNameHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01BasLoadGwaNameRequest, OcsoServiceProto.OcsoOCS1003P01BasLoadGwaNameResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01BasLoadGwaNameHandler.class);

	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	public boolean isValid(OcsoServiceProto.OcsoOCS1003P01BasLoadGwaNameRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getBuseoYmd()) && DateUtil.toDate(request.getBuseoYmd(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01BasLoadGwaNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01BasLoadGwaNameRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01BasLoadGwaNameResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01BasLoadGwaNameResponse.newBuilder();
		String result = bas0260Repository.getBasLoadGwaName(request.getGwa(), request.getBuseoYmd(), getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setGwaName(result);
		}
		return response.build();
	}
}
