package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg5001Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10PrDrgInpMagamRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class DRG3010P10PrDrgInpMagamHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010P10PrDrgInpMagamRequest, SystemServiceProto.StringResponse> {

	private static final Log LOGGER = LogFactory.getLog(DRG3010P10PrDrgInpMagamHandler.class);
	
	@Resource
	private Drg5001Repository drg5001Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10PrDrgInpMagamRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String flag = drg5001Repository.callPrDrgInpMagam(request.getUpdId()
				, hospCode
				, request.getHoDong()
				, DateUtil.toDate(request.getMagamDate(), DateUtil.PATTERN_YYMMDD)
				, request.getMagamGubun());
		
		LOGGER.info(String.format("Execute procedure PR_DRG_INP_MAGAM: O_FLAG = %s, HOSP_CODE = %s", flag == null ? "NULL" : flag, hospCode));
		
		response.setResult(flag == null ? "" : flag);
		return response.build();
	}

	
}
