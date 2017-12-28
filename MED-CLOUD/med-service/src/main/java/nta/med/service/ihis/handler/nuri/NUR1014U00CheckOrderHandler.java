package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1014U00CheckOrderHandler extends ScreenHandler<NuriServiceProto.NUR1014U00CheckOrderRequest, SystemServiceProto.StringResponse> {   
	
	@Resource
	private Ocs2003Repository ocs2003Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1014U00CheckOrderRequest request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		response.setResult(ocs2003Repository.getNUR1014U00CheckOrder(hospCode, CommonUtils.parseDouble(request.getFkinp1001()),
				request.getBunho(), request.getOutDate(), request.getInDate()));
		
		return response.build();
	}
}
