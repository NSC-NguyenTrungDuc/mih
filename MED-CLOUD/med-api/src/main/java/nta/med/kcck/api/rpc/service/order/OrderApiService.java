package nta.med.kcck.api.rpc.service.order;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.OrderServiceProto;

public interface OrderApiService {

	OrderServiceProto.UpdatePaidOrderResponse updatePaidOrder(RpcApiSession session, OrderServiceProto.UpdatePaidOrderRequest request);
	
	OrderServiceProto.OrderTranferResponse orderTranfer(OrderServiceProto.OrderTranferRequest request) throws Exception;
}
