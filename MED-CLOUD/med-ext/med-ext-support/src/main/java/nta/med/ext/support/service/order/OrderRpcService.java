package nta.med.ext.support.service.order;

import nta.med.ext.support.proto.OrderServiceProto;

public interface OrderRpcService {

	OrderServiceProto.UpdatePaidOrderResponse updatePaidOrder(OrderServiceProto.UpdatePaidOrderRequest request);
	
	interface Service {
		OrderServiceProto.OrderTranferResponse orderTranfer(OrderServiceProto.OrderTranferRequest request) throws Exception;
    }
}
