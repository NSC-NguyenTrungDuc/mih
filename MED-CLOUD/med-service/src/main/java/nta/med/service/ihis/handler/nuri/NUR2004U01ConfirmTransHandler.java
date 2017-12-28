package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01ConfirmTransRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR2004U01ConfirmTransHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U01ConfirmTransRequest, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01ConfirmTransRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		if(inp2004Repository.updateNur2004U01ConfirmTrans(hospCode, userId, CommonUtils.parseDouble(request.getTransCnt()), request.getBedNo(),
				CommonUtils.parseDouble(request.getFkinp1001()), CommonUtils.parseDouble(request.getITransCnt())) < 0){
			response.setResult(false);
		}		
		response.setResult(true);
		
		return response.build();
		
	}

}
