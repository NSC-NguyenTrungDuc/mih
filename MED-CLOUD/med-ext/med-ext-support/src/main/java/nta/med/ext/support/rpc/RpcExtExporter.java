package nta.med.ext.support.rpc;

import com.google.protobuf.InvalidProtocolBufferException;
import nta.med.common.glossary.Lifecyclet;
import nta.med.common.remoting.ServiceOverloadException;
import nta.med.common.remoting.ServiceTransportException;
import nta.med.common.remoting.rpc.context.RpcSession;
import nta.med.common.remoting.rpc.exporter.RpcExportable;
import nta.med.common.remoting.rpc.exporter.impl.RpcOioExporter;
import nta.med.common.remoting.rpc.protobuf.Rpc.RpcMessage;
import nta.med.common.remoting.rpc.transport.RpcTransport;
import nta.med.common.util.*;
import nta.med.common.util.concurrent.executor.XExecutors;
import nta.med.common.util.concurrent.future.impl.XFutureEx;
import nta.med.ext.support.glossary.Capability;
import nta.med.ext.support.glossary.EventMetaStore;
import nta.med.ext.support.service.system.SystemRpcService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.File;
import java.io.RandomAccessFile;
import java.net.SocketAddress;
import java.nio.MappedByteBuffer;
import java.nio.channels.FileChannel;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicReference;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

/**
 * 
 */
public final class RpcExtExporter extends RpcOioExporter<RpcExtContext, RpcExtSession> implements RpcExtContext, RpcExtContext.Tracer {

	//
	private static final Logger LOGGER = LoggerFactory.getLogger(RpcExtExporter.class);
	
	//
	private final AtomicReference<RpcExtSessionImpl> session = new AtomicReference<RpcExtSessionImpl>();
	private final ExecutorService executor;
	private List<Listener<?>> subscribers = new ArrayList<>();
	private RpcExtTransport transport;
	private final int authRetryIntervalInSeconds;
	private final String hospCode;
	private final String username;
	private final String password;
	private final String eventStoreFile;
	private MappedByteBuffer buffer;
	private SystemRpcService systemRpcService;
	private List<Capability> capabilities = new ArrayList<>();

	public RpcExtExporter(int authRetryIntervalInSeconds, String hospCode, String username, String password, String eventStoreFile) {
		super("rpc.ext.exporter");
		this.authRetryIntervalInSeconds = authRetryIntervalInSeconds;
		this.hospCode = hospCode;
		this.username = username;
		this.password = password;
		this.eventStoreFile = eventStoreFile;
		this.executor = XExecutors.create(this.name + ".executor", 1);
	}
	
	@Override
	protected void doStart() throws Exception {
		// 1
		super.doStart();

		// 2
		for(List<RpcExportable<RpcExtContext, RpcExtSession>> list : this.services.values()) {
			Lifecyclet.startQuietly(list);
		}

		//3
		boolean exists = Files.exists(eventStoreFile);
		buffer = new RandomAccessFile(new File(eventStoreFile), "rw").getChannel().map(FileChannel.MapMode.READ_WRITE, 0, 1024);
		if(!exists) {
			final EventMetaStore[] constants = sun.misc.SharedSecrets.getJavaLangAccess().getEnumConstantsShared(EventMetaStore.class);
			for (EventMetaStore item : constants) buffer.putLong(item.getPosition(), -1);
		}

		//4
		for (Listener<?> lis : subscribers) { lis.setTracer(this); startQuietly(lis); }

		//5
		transport = Objects.cast(this.transportFactory.create(System.currentTimeMillis()));
		transport.start(); transport.setListener(this);
	}

	@Override
	protected long doStop(long timeout, TimeUnit unit) throws Exception {
		//5
		if(transport != null) Lifecyclet.startQuietly(transport);

		//4
		stopQuietly(subscribers);

		//3
		Buffers.dispose(this.buffer); this.buffer = null;

		// 2
		for(List<RpcExportable<RpcExtContext, RpcExtSession>> list : this.services.values()) {
			timeout = Lifecyclet.stopQuietly(list, timeout, unit);
		}

		// 1
		return super.doStop(timeout, unit);
	}
	
	/**
	 * 
	 */
	@Override
	public RpcExtContext getContext() {
		return this;
	}
	
	@Override
	public RpcExtSession getSession() {
		return this.session.get();
	}

	@Override
	protected void export(RpcExportable<RpcExtContext, RpcExtSession> service) {
		super.export(service); service.setContext(this);
	}

	@Override
	public boolean authenticate() {
		if(systemRpcService != null){
			boolean result = systemRpcService.authenticate(this.hospCode, this.username, this.password, this.capabilities);
			this.session.get().login(result ? this.username : null);
			return this.session.get().isAuthenticated();
		}
		return false;
	}

	@Override
	public Iterator<? extends RpcSession> sessions() {
		return Iterators.iterator(this.session.get());
	}

	@Override
	public void onConnected(RpcTransport<RpcMessage> transport) {
		this.session.getAndSet(new RpcExtSessionImpl(transport));
		executor.submit(() -> {
			while (!authenticate()){
				try {
					TimeUnit.SECONDS.sleep(authRetryIntervalInSeconds);
				} catch (InterruptedException e) {
					LOGGER.warn("failed to authenticate, exception: " + e);
				}
				LOGGER.warn("failed to authenticate");
			}
			LOGGER.info("the connection was successfully authenticated.");
			List<Listener<?>> subs = new ArrayList<>(subscribers);
			int counter = 0;
			while (subs.size() > 0) {
				try {
					Listener<?> sb = subs.get(++counter % subs.size());
					if(sb.subscribe()) subs.remove(sb);
					else {
						LOGGER.warn("Wait 10 seconds due to subscribe fail: " + sb.toString());
						TimeUnit.SECONDS.sleep(10);
					}
				} catch (Exception e) { LOGGER.warn("failed to subscribe, exception = " + e.getMessage(), e); }
			}
		});
		LOGGER.info(" > {},{},", transport.getId(), transport.getRemoteAddress());
	}

	@Override
	public void onMessage(RpcTransport<RpcMessage> transport, RpcMessage message) {
		// Response
		if(message.hasSourceId()) {
			final long id = message.getSourceId();
			final XFutureEx<RpcMessage> f = this.futures.remove(id);
			if(f != null) f.setResult(message);
			return;
		}

		// Request
		final RpcExtSession session = this.session.get();
		if(session == null) {
			final String source = transport.toString();
			LOGGER.warn("rejected request[SESSION]: {}, source: {}", format(message), source);
		} else {
			RpcMessage response = invoke(session, message); if(response != null) session.send(response);
		}
	}

	@Override
	public void onException(RpcTransport<RpcMessage> transport, Throwable cause) {
		final RpcExtSessionImpl session = this.session.getAndSet(null);
		try {
			if(Exceptions.isCausedBy(cause, ServiceTransportException.class)) {
				LOGGER.warn("onException[BREAK], transport: " + transport + ", cause: " + cause.getMessage());
			} else if(Exceptions.isCausedBy(cause, InvalidProtocolBufferException.class)) {
				LOGGER.warn("onException[ATTACK], transport: " + transport + ", cause: " + cause.getMessage());
			} else if(Exceptions.isCausedBy(cause, ServiceOverloadException.class)) {
				LOGGER.warn("onException[OVERLOAD], transport: " + transport + ", cause: " + cause.getMessage());
			} else {
				final Throwable root = Exceptions.getRootCause(cause);
				LOGGER.error("onException[INTERNAL_ERROR], transport: " + transport, root != null ? root : cause);
			}
		} finally {
			if (session != null) try { session.invalidate(); } catch(Throwable ignore) { /* NOP */ } // Disconnect
		}
	}

	@Override
	public void onDisconnected(RpcTransport<RpcMessage> transport, Throwable cause) {
		final SocketAddress address = transport.getRemoteAddress();
		final RpcExtSessionImpl session = this.session.getAndSet(null);
		final String loginId = (session == null) ? "" : session.getLoginId();
		if(session != null) try { session.logout(true); } catch(Throwable ignore) {}
		LOGGER.info(" < {},{},{}", new Object[]{transport.getId(), address, loginId});
	}

	public void setSubscribers(List<Listener<?>> subscribers) {
		this.subscribers = subscribers;
	}

	@Override
	public long lastEvent(EventMetaStore meta) {
		return buffer.getLong(meta.getPosition());
	}

	@Override
	public void traceEvent(EventMetaStore meta, long eventID) {
		buffer.putLong(meta.getPosition(), eventID);
	}

	public void setSystemRpcService(SystemRpcService systemRpcService) {
		this.systemRpcService = systemRpcService;
	}

	public void setCapabilities(List<Capability> capabilities) {
		this.capabilities = capabilities;
	}

	/**
	 * 
	 */
	private class RpcExtSessionImpl extends RpcSessionImpl implements RpcExtSession {
		//
		private String loginId;

		public RpcExtSessionImpl(RpcTransport<RpcMessage> transport) { super(transport); }

		@Override public boolean isAuthenticated() { return this.loginId != null; }

		@Override
		public String getLoginId() {
			return loginId;
		}

		@Override
		public void logout(boolean force) {
			String lid = loginId; loginId = null; LOGGER.info("{}- {},{},{}", new Object[]{force ? "!" : " ", getId(), Networks.format(getRemoteAddress()), lid});
		}

		@Override
		public void login(String loginId) {
			this.loginId = loginId;
		}
	}

}
