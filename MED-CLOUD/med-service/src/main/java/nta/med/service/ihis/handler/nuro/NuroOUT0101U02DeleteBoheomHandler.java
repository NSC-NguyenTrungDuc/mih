package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuroOUT0101U02DeleteBoheomHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02DeleteBoheomRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02DeleteBoheomHandler.class);
	@Resource
	private Out0102Repository out0102Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT0101U02DeleteBoheomRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOldStartDate()) && DateUtil.toDate(request.getOldStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02DeleteBoheomRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Date oldStartDate = DateUtil.toDate(request.getOldStartDate(), DateUtil.PATTERN_YYMMDD);
		boolean result = deleteNuroOUT0101U02DeleteBoheom(request, oldStartDate, getHospitalCode(vertx, sessionId));
	    response.setResult(result);
		return response.build();
	}
	
	private boolean deleteNuroOUT0101U02DeleteBoheom(NuroServiceProto.NuroOUT0101U02DeleteBoheomRequest request, Date oldStartDate, String hospCode) throws Exception{
		try {
			if( out0102Repository.deleteNuroOUT0101U02DeleteBoheom(hospCode, request.getPatientCode(), request.getOldType(), oldStartDate) > 0)
				return true;
			
		}catch (Exception e) {
			LOGGER.error(e.getMessage(), e);
	    	return false;
	    }
		return false;
	}
}
