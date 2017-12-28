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
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00ConfirmTransHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00ConfirmTransRequest, SystemServiceProto.UpdateResponse> {   
	
	@Resource                                   
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00ConfirmTransRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		inp2004Repository.updateInp2004NUR1010Q00ConfirmTrans(getHospitalCode(vertx, sessionId), request.getUserId(),
				CommonUtils.parseDouble(request.getTransCnt()), request.getBedNo(),
				CommonUtils.parseDouble(request.getFkinp1001()), CommonUtils.parseDouble(request.getITransCnt()));
		
		response.setResult(true);
		return response.build();
	}
}
