package nta.med.service.ihis.handler.drgs;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P06grdActJUSAOrderRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P06grdActJUSAOrderResponse;

@Service
@Scope("prototype")
public class DRG3041P06grdActJUSAOrderHandler extends
		ScreenHandler<DrgsServiceProto.DRG3041P06grdActJUSAOrderRequest, DrgsServiceProto.DRG3041P06grdActJUSAOrderResponse> {

	@Override
	@Transactional(readOnly = true)
	public DRG3041P06grdActJUSAOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P06grdActJUSAOrderRequest request) throws Exception {
		
		DrgsServiceProto.DRG3041P06grdActJUSAOrderResponse.Builder response = DrgsServiceProto.DRG3041P06grdActJUSAOrderResponse.newBuilder();
		
		return response.build();
	}

}
