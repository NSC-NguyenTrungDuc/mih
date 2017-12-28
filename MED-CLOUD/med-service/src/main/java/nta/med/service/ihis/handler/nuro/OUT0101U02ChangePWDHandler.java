package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import org.apache.commons.lang.RandomStringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.OUT0101U02ChangePWDRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

/**
 * @author DEV-NgocNV
 *
 */

@Transactional
@Service
@Scope("prototype")
public class OUT0101U02ChangePWDHandler
		extends ScreenHandler<NuroServiceProto.OUT0101U02ChangePWDRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OUT0101U02ChangePWDHandler.class);

	@Resource
	private Out0101Repository out0101Repository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OUT0101U02ChangePWDRequest request) throws Exception {
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean result = updateOUT0101U02ChangePWD(request, hospCode, request.getBunho(), request.getPwd());
		response.setResult(result);
		return response.build();
	}

	private boolean updateOUT0101U02ChangePWD(OUT0101U02ChangePWDRequest request, String hospCode, String bunho, String pwd) {
		String newPWD = RandomStringUtils.randomAlphabetic(8).toUpperCase();
		newPWD = StringUtils.isEmpty(pwd) ? newPWD : pwd.toUpperCase();

		return out0101Repository.updatePWD(hospCode, request.getBunho(), newPWD) > 0;
	}
}
