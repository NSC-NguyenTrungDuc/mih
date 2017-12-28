package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg9005Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010Q12queryHistoryRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class DRG3010Q12queryHistoryHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010Q12queryHistoryRequest, SystemServiceProto.UpdateResponse> {
	@Resource Drg9005Repository drg9005Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010Q12queryHistoryRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		boolean result = drg9005Repository.callProcDrg9005SeriesNew(userId, hospCode, request.getOrderFrom(), request.getBunho(), request.getInOutGubun());
		response.setResult(result);
		
		return response.build();
	}

}
