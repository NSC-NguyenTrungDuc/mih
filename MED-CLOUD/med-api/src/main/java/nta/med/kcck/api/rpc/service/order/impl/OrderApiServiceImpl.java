package nta.med.kcck.api.rpc.service.order.impl;

import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.common.remoting.ServiceUnavailableException;
import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.kcck.api.adapter.OcsoAdapter;
import nta.med.kcck.api.rpc.RpcApiContext;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.OrderServiceProto;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;
import nta.med.kcck.api.rpc.service.AbstractRpcApiService;
import nta.med.kcck.api.rpc.service.order.OrderApiService;

public class OrderApiServiceImpl extends AbstractRpcApiService implements OrderApiService {
	
	private static final Log LOGGER = LogFactory.getLog(OrderApiServiceImpl.class);

	private final RpcMessageParser parser;

	@Resource
	private RpcApiContext context;

	@Resource
	private OcsoAdapter ocsoAdapter;

	public OrderApiServiceImpl() {
		super(OrderServiceProto.class, OrderServiceProto.getDescriptor());
		parser = new RpcMessageParser(OrderServiceProto.class);
	}

	@Override
	public boolean isCompatible(String s) {
		return true;
	}

	@RpcService(name = "UpdatePaidOrderRequest", authenticate = true)
	public OrderServiceProto.UpdatePaidOrderResponse updatePaidOrder(RpcApiSession session, OrderServiceProto.UpdatePaidOrderRequest request) {
		return ocsoAdapter.updatePaidOrder(session, request);
	}

	@Override
	public OrderServiceProto.OrderTranferResponse orderTranfer(OrderServiceProto.OrderTranferRequest request) throws Exception{
		for (RpcApiSession session : context.getSessions()) {
            if(session.isAuthorized(request.getHospCode()) && session.hasCapability(SystemServiceProto.LoginRequest.Capability.ORDER_TRANSFER)) {
                FutureEx<Rpc.RpcMessage> res = session.invoke(RpcMessageBuilder.build(request, null));
                Rpc.RpcMessage r = res.get(30, TimeUnit.SECONDS);
                if(r != null) return parser.parse(r);
            }
        }
		
        throw new ServiceUnavailableException();
	}
	
}
