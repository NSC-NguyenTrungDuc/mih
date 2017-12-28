package nta.med.service.ihis.handler.drgs;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg5001Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10SetCycleDateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class DRG3010P10SetCycleDateHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010P10SetCycleDateRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Drg5001Repository drg5001Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10SetCycleDateRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String caseVal = request.getCaseVal();
		Date dtResult = null;
		
		if("1".equals(caseVal)){
			dtResult = drg5001Repository.callFnDrgGetCycleOrdDate(hospCode, DateUtil.toDate(request.getMagamDate(), DateUtil.PATTERN_YYMMDD), request.getHoDong());
		}
		else {
			dtResult = drg5001Repository.callFnDrgGetCycleMagamDate(hospCode, DateUtil.toDate(request.getMagamDate(), DateUtil.PATTERN_YYMMDD), request.getHoDong());
		}
		
		response.setResult(dtResult == null ? "" : DateUtil.toString(dtResult, DateUtil.PATTERN_YYMMDD));
		return response.build();
	}

}
