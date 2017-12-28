package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ifs.Ifs7303Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10PrJihInjIfsProcRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class DRG3010P10PrJihInjIfsProcHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010P10PrJihInjIfsProcRequest, SystemServiceProto.StringResponse> {

	private static final Log LOGGER = LogFactory.getLog(DRG3010P10PrJihInjIfsProcHandler.class);
	
	@Resource
	private Ifs7303Repository ifs7303Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10PrJihInjIfsProcRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String err = ifs7303Repository.callPrJihInjIfsProc(getHospitalCode(vertx, sessionId), request.getIoGubun(),
				CommonUtils.parseDouble(request.getFkdrg()), getUserId(vertx, sessionId));
		
		LOGGER.info(String.format("Execute PR_JIH_INJ_IFS_PROC: ERROR = %s, HOSP_CODE = %s", err == null ? "NULL" : err, getHospitalCode(vertx, sessionId)));
		
		response.setResult(err == null ? "" : err);
		return response.build();
	}

	
}
