package nta.med.service.ihis.handler.ocsi;

import java.sql.SQLException;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10DayApplyOCS6013Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10DayApplyOCS6013Handler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10DayApplyOCS6013Request, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(OCS6010U10DayApplyOCS6013Handler.class);
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10DayApplyOCS6013Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		response.setResult(false);
		response.setMsg("");
		
		try {
			Integer updRow = ocs2003Repository.updateOcs2003InOCS6010U10(hospCode
					, request.getBunho()
					, request.getUserId()
					, CommonUtils.parseDouble(request.getFkinp1001())
					, DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD)
					, DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD)
					, CommonUtils.parseDouble(request.getPkocs6013()));
			
			response.setResult(updRow > 0);
			LOGGER.info(String.format("Update OCS2003: hosp_code = %s, row_updated = %s", hospCode, String.valueOf(updRow)));
		} catch (Exception e) {
			LOGGER.info(String.format("Update OCS2003 fail: hosp_code = %s", hospCode), e);
			if(e.getCause().getCause() instanceof SQLException){
				SQLException sqle = ((SQLException)e.getCause().getCause());
				response.setMsg(sqle.getMessage() != null ? sqle.getMessage() : "");
			}
			
			throw new ExecutionException(response.build());
		}
		
		return response.build();
	}
}
