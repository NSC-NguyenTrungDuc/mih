package nta.med.service.ihis.handler.adma;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0103Repository;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class HOTCODEMASTERSaveHandler
		extends ScreenHandler<AdmaServiceProto.HOTCODEMASTERSaveRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(HOTCODEMASTERSaveHandler.class);
	@Resource
	private Bas0103Repository bas0103Repository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			AdmaServiceProto.HOTCODEMASTERSaveRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String errFlg = "0";
		for (AdmaModelProto.ADM2016U00GrdLoadDrgInfo info : request.getHotCodeInfoList()) {

			errFlg = bas0103Repository.callPrAdmHotcodeMasterInsert(getHospitalCode(vertx, sessionId),
					getUserId(vertx, sessionId), info.getA1());
			if (!errFlg.equals("0")) {
				break;
			}
		}
		if (!"0".equalsIgnoreCase(errFlg)) {
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		response.setResult(true);
		return response.build();
	}
}