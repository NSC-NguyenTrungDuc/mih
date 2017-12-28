package nta.med.ext.support.service.order.impl;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import nta.med.common.remoting.ServiceExecutionException;
import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.ext.support.proto.OrderServiceProto;
import nta.med.ext.support.rpc.RpcExtSession;
import nta.med.ext.support.service.AbstractRpcExtService;
import nta.med.ext.support.service.order.OrderRpcService;

public class OrderRpcServiceImpl extends AbstractRpcExtService implements OrderRpcService {
	
	private static final Logger LOGGER = LoggerFactory.getLogger(OrderRpcServiceImpl.class);
	
	private OrderRpcService.Service service;

	public OrderRpcServiceImpl() {
		super("api.order", OrderServiceProto.class, OrderServiceProto.getDescriptor());
	}

	@Override
	public boolean isCompatible(String arg0) {
		return true;
	}

	@Override
	public OrderServiceProto.UpdatePaidOrderResponse updatePaidOrder(OrderServiceProto.UpdatePaidOrderRequest request) {
		return invoke(request, 10000L, true);
	}

	@RpcService(name = "OrderTranferRequest")
    public OrderServiceProto.OrderTranferResponse orderTranfer(RpcExtSession session, OrderServiceProto.OrderTranferRequest request) {
        if(service != null) try {
            return service.orderTranfer(request);
        } catch (Exception e) {
            LOGGER.warn("fail to invoke createPatient, request = " + format(request));
        }
        
        throw new ServiceExecutionException();
    }
	
	public OrderRpcService.Service getService() {
		return service;
	}

	public void setService(OrderRpcService.Service service) {
		this.service = service;
	}

}
