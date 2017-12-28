package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBIsMeterialOrderRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBIsMeterialOrderResponse;

@Service
@Scope("prototype")
public class OBIsMeterialOrderHandler extends
		ScreenHandler<SystemServiceProto.OBIsMeterialOrderRequest, SystemServiceProto.OBIsMeterialOrderResponse> {

	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OBIsMeterialOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OBIsMeterialOrderRequest request) throws Exception {
		SystemServiceProto.OBIsMeterialOrderResponse.Builder response = SystemServiceProto.OBIsMeterialOrderResponse.newBuilder();
		String rs = ocs0103Repository.loadJaeryoYn(getHospitalCode(vertx, sessionId), request.getHangmogCode());
		
		response.setFnOut(rs);
		return response.build();
	}
	
}
