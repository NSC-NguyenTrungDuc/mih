package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FnDrgGetCycleOrdDateRequest;
import nta.med.service.ihis.proto.SystemServiceProto.FnDrgGetCycleOrdDateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class FnDrgGetCycleOrdDateHandler
	extends ScreenHandler<SystemServiceProto.FnDrgGetCycleOrdDateRequest, SystemServiceProto.FnDrgGetCycleOrdDateResponse> {
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional
	public FnDrgGetCycleOrdDateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			FnDrgGetCycleOrdDateRequest request) throws Exception {
		SystemServiceProto.FnDrgGetCycleOrdDateResponse.Builder response = SystemServiceProto.FnDrgGetCycleOrdDateResponse.newBuilder();
		Date ordDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		Date resultDate = ocs0132Repository.getFnDrgGetCycleOrdDate(getHospitalCode(vertx, sessionId), ordDate, request.getHoDong());
		if(resultDate != null){
			response.setDate(DateUtil.toString(resultDate, DateUtil.PATTERN_YYMMDD));
		}
		return response.build();
	}

}
