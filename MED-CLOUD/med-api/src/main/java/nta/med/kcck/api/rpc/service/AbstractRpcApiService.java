package nta.med.kcck.api.rpc.service;

import com.google.protobuf.Descriptors;
import com.google.protobuf.Message;
import nta.med.common.glossary.Lifecyclet;
import nta.med.common.glossary.Nullable;
import nta.med.common.remoting.RemotingTranslator;
import nta.med.common.remoting.ServiceRestrictedException;
import nta.med.common.remoting.ServiceSchemaException;
import nta.med.common.remoting.ServiceTimeoutException;
import nta.med.common.remoting.rpc.exporter.RpcInvocation;
import nta.med.common.remoting.rpc.exporter.service.AbstractRpcService;
import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.util.Exceptions;
import nta.med.common.util.Strings;
import nta.med.common.util.logging.slf4j.Markers;
import nta.med.kcck.api.rpc.RpcApiContext;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.core.common.async.AsyncExecutor;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.Marker;

import java.util.List;
import java.util.concurrent.Callable;
import java.util.concurrent.TimeUnit;

import static java.util.concurrent.TimeUnit.NANOSECONDS;
import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;
import static nta.med.common.util.DateTimes.toMillis;

/**
 * @author dainguyen.
 */
public abstract class AbstractRpcApiService extends AbstractRpcService<RpcApiContext, RpcApiSession> {

    private static final Logger LOGGER = LoggerFactory.getLogger(AbstractRpcApiService.class);

    //
    protected AsyncExecutor executor;

    public AbstractRpcApiService(Class<?> clazz, Descriptors.FileDescriptor descriptor) {
        super("api", clazz, descriptor);
    }

    public AbstractRpcApiService(List<Class<?>> clazz, Descriptors.FileDescriptor descriptor) {
        super("api", clazz, descriptor);
    }

    @Override
    protected void doStart() throws Exception {
        super.doStart();
        Lifecyclet.startQuietly(this.executor);
    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        timeout = Lifecyclet.stopQuietly(this.executor, timeout, unit);
        return super.doStop(timeout, unit);
    }

    /**
     *
     */
    @Override
    public String toString() {
        return Strings.build(this)
                .append("service", service).toString();
    }

    /**
     *
     */
    @Override
    public boolean isCompatible(String version) {
        return true;
    }

    public void setExecutor(AsyncExecutor executor) {
        this.executor = executor;
    }

    protected final void async(@Nullable Integer shard, @Nullable Long timeout, String name, Runnable task) {
        final long mark1 = System.nanoTime();
        this.executor.execute(this.service, shard, () -> {
            long mark2 = System.nanoTime(), delay = mark2 - mark1;
            try {
                if(timeout == null || NANOSECONDS.toMillis(delay) <= timeout) {
                    task.run();
                } else {
                    LOGGER.warn("failed to execute[TIMEOUT], name: " + name + ", shard: " + shard);
                }
            } catch(Throwable tx) {
                LOGGER.error("failed to execute[INTERNAL_ERROR], name: " + name + ", shard: " + shard, tx);
            }
        });
    }

    /**
     *
     */
    protected void reply(@Nullable Integer shard, @Nullable Long timeout, final RpcApiSession session, final Message request, final Callable<Message> task) {
        final long mark = System.nanoTime();
        final RpcInvocation invocation = RpcInvocation.current();
        final Rpc.RpcMessage message = invocation.getMessage(); final RpcService service = invocation.getService();
        final boolean v1 = service.audit() && session.isVerbose(), v2 = service.audit() && exporter.isVerbose();
        this.executor.execute(this.service, shard, () -> {
            long et = 0L; Message response = null;
            final Rpc.RpcMessage.Builder builder = RpcMessageBuilder.reply(message);
            try {
                //
                if(timeout != null && (System.nanoTime() - mark) > TimeUnit.MILLISECONDS.toNanos(timeout)) {
                    throw new ServiceTimeoutException();
                }

                //
                response = task.call(); builder.setResult(Rpc.RpcMessage.Result.SUCCESS);
                et = System.nanoTime() - mark;
                builder.setPayloadData(response.toByteString()); builder.setPayloadClass(response.getDescriptorForType().getName());
                if(v1) ACCESS.info("* {},{},{},{},{}", session.getId(), getPrincipal(session), millis(et), format(request), format(response));
                else if(v2) ACCESS.info("* {},{},{},{}", session.getId(), getPrincipal(session), millis(et), format(request) /* Request Only */);
            } catch(Throwable tx) {
                //
                final Rpc.RpcMessage.Result result = RemotingTranslator.translate(tx); builder.setResult(result);
                if(v1 || v2) ACCESS.info("! {},{},{},{},{}", new Object[]{session.getId(), getPrincipal(session), millis(et), format(request), result});

                //
                Marker m = Markers.fc("INVOKE", "REPLY", session.getId());
                et = System.nanoTime() - mark;
                if (Exceptions.isCausedBy(tx, ServiceSchemaException.class)) {
                    LOGGER.warn(m, "failed to invoke service[REJECT], request: {}, session: {}, elapsed time: {} ms", format(request), session.getId(), toMillis(et));
                } else if (Exceptions.isCausedBy(tx, ServiceTimeoutException.class)) {
                    LOGGER.warn(m, "failed to invoke service[TIMEOUT], request: {}, session: {}, elapsed time: {} ms", format(request), session.getId(), toMillis(et));
                } else if (Exceptions.isCausedBy(tx, ServiceRestrictedException.class)) {
                    LOGGER.info(m, "failed to invoke service[RESTRICT], request: {}, session: {}, elapsed time: {} ms", format(request), session.getId(), toMillis(et));
                } else {
                    LOGGER.error(m, "failed to invoke service[INTERNAL_ERROR], request: " + format(request) + ", session: " + session + ", elapsed time: " + toMillis(et) + " ms", tx);
                }
            } finally {
                try { session.send(builder.build()); } catch(Throwable tx) {
                    LOGGER.warn("failed to send[INTERNAL_ERROR], request: " + format(request) + ", response: " + format(response) + ", session: " + session + ", elapsed time: " + toMillis(et) + " ms", tx);
                }
            }
        });
    }
}
