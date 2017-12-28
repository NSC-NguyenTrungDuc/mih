package nta.med.ext.support.service;

import com.google.protobuf.Descriptors.FileDescriptor;
import com.google.protobuf.Message;
import nta.med.common.remoting.RemotingException;
import nta.med.common.remoting.SessionUnavailableException;
import nta.med.common.remoting.rpc.exporter.service.AbstractRpcService;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.ext.support.rpc.RpcExtContext;
import nta.med.ext.support.rpc.RpcExtSession;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;
import java.util.concurrent.TimeUnit;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

/**
 * 
 */
public abstract class AbstractRpcExtService extends AbstractRpcService<RpcExtContext, RpcExtSession> {

	private static final Logger LOGGER = LoggerFactory.getLogger(AbstractRpcExtService.class);
	/**
	 * 
	 */
	public AbstractRpcExtService(String prefix, Class<?> clazz, FileDescriptor descriptor) {
		super(prefix, clazz, descriptor);
	}

	public AbstractRpcExtService(String prefix, List<Class<?>> clazz, FileDescriptor descriptor) {
		super(prefix, clazz, descriptor);
	}

	@Override
	protected void doStart() throws Exception {
		super.doStart();
	}

	@Override
	protected long doStop(long timeout, TimeUnit unit) throws Exception {
		return super.doStop(timeout, unit);
	}
	
	protected final <T extends Message> T invoke(final Message request, long timeout) {
		return invoke(request, timeout, true);
	}

	protected final <T extends Message> T invoke(final Message request, long timeout, boolean requireAuthenticated) {
		return invoke(request, timeout, requireAuthenticated, true);
	}
	
	protected final <T extends Message> T invoke(final Message request, long timeout, boolean requireAuthenticated, boolean isNeedResponseResult) {
		//
		final RpcExtSession session = this.context.getSession();
		if(session == null) {
			throw new SessionUnavailableException("failed to invoke, request: " + format(request));
		}

		if(requireAuthenticated && !session.isAuthenticated()){
			boolean result = exporter.getContext().authenticate();
			if(!result){
				throw new RemotingException("failed to authenticate");
			}
		}

		//
		if(timeout <= 0) timeout = this.getTimeout();
		final FutureEx<Rpc.RpcMessage> future = session.invoke(RpcMessageBuilder.build(request, null));
		
		if(isNeedResponseResult){
			final Rpc.RpcMessage response;
			try {
				response = future.get(timeout, TimeUnit.MILLISECONDS);
				if(!response.hasResult() || response.getResult() == Rpc.RpcMessage.Result.SUCCESS) {
					return this.parser.parse(response);
				} else {
					throw new RemotingException("failed to invoke, request: " + format(request) + ", result: " + response.getResult().name());
				}
			} catch (Exception e) {
				throw new RemotingException("failed to invoke, request: " + format(request), e);
			}
		} else{
			return null;
		}
		
	}

}
