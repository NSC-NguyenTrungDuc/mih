package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
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
public class OcsoOCS1003P01CheckIsSameNameYnHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01CheckIsSameNameYnRequest, OcsoServiceProto.OcsoOCS1003P01CheckIsSameNameYnResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01CheckIsSameNameYnHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01CheckIsSameNameYnResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01CheckIsSameNameYnRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01CheckIsSameNameYnResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01CheckIsSameNameYnResponse.newBuilder();
		String result = out1001Repository.checkOcsoOCS1003P01CheckIsSameNameYn(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getNaewonDate(),
				request.getGwa(), request.getNaewonYn(), request.getReserYn(), request.getDoctorModeYn(), request.getDoctor(), request.getBunho());
		if(!StringUtils.isEmpty(result)){
			response.setValueCheck(result);
		}
		return response.build();
	}
}
