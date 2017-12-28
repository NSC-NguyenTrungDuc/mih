package nta.med.ext.support.service;

import com.google.protobuf.Message;
import nta.med.common.glossary.Lifecyclet;
import nta.med.common.util.concurrent.executor.XExecutors;
import nta.med.ext.support.glossary.EventMetaStore;
import nta.med.ext.support.rpc.RpcExtContext;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.Collection;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.LinkedBlockingQueue;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;
import static nta.med.common.util.Concurrents.terminateQuietly;

/**
 * @author dainguyen.
 */
public abstract class AbstractRpcExtListener<T extends Message> extends Lifecyclet implements RpcExtContext.Listener<T> {

	private static final Logger LOGGER = LoggerFactory.getLogger(AbstractRpcExtListener.class);

    private BlockingQueue<T> messages = new LinkedBlockingQueue<>();

    private final ExecutorService exec;

    private final Lock lock = new ReentrantLock();

    private RpcExtContext.Tracer tracer;

    protected AbstractRpcExtListener(Class<T> clazz){
        exec = XExecutors.create("rpc.listener." + clazz.getSimpleName().toLowerCase(), 1);
    }

    @Override
    public boolean subscribe() {
        long eventId = tracer.lastEvent(meta());
        try {
            lock.lock();
            Collection<T> pendingEvents = invokeSubscribe(eventId);
            if (pendingEvents.size() > 0) {
                messages.addAll(pendingEvents);
            }
            if (isVerbose()) LOGGER.info("{} was successfully subscribed", this);
			return true;
        } catch (Exception e) {
            LOGGER.warn(String.format("failed to subscribe event: %s, id: %s, message: %s", meta(), eventId, e.getMessage()), e);
        } finally {
            lock.unlock();
        }
        return false;
    }

    @Override
    public void onEvent(T event) throws InterruptedException {
        if (isVerbose()) LOGGER.info("onEvent: " + format(event));
        lock.lock();
        try {
			messages.put(event);
		} finally {
			lock.unlock();
		}
    }

    @Override
    protected void doStart() throws Exception {
        exec.execute(() -> {
            if (isVerbose()) LOGGER.info("{} was successfully started", new Object[]{this});
            while (true) {
                try {
                    final T f = messages.poll(1000L, TimeUnit.MILLISECONDS);
                    if (f != null) {
                        try {
							handleEvent(f);
							tracer.traceEvent(meta(), meta().eventID(f));
						} catch (Throwable tx) {
							LOGGER.warn(tx.getMessage(), tx);
						}
                    }
                } catch (InterruptedException e) {
                    Thread.currentThread().interrupt();
					break;
                }
            }
            if (isVerbose()) LOGGER.info("{} was successfully stopped", new Object[]{this});
        });
    }

    @Override
    public void setTracer(RpcExtContext.Tracer tracer) {
        this.tracer = tracer;
    }

    public abstract EventMetaStore meta();

    public abstract void handleEvent(T event) throws Exception;

    public abstract Collection<T> invokeSubscribe(long eventId) throws Exception;

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        timeout = terminateQuietly(exec, timeout, unit);
        return timeout;
    }
}
