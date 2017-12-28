package nta.med.core.infrastructure.socket.adapter;

import com.google.common.collect.MapMaker;
import com.google.protobuf.Descriptors;
import com.google.protobuf.InvalidProtocolBufferException;
import com.google.protobuf.Message;
import nta.med.common.remoting.ServiceTransportException;
import nta.med.common.remoting.ServiceUnavailableException;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.common.util.concurrent.future.impl.XFutureEx;
import nta.med.core.glossary.SessionAttribute;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.VertxSession;
import nta.med.core.infrastructure.socket.vertx.VertxContext;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.vertx.java.core.Handler;
import org.vertx.java.core.buffer.Buffer;
import org.vertx.java.core.eventbus.EventBus;

import java.nio.charset.Charset;
import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;
import java.util.concurrent.TimeUnit;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;


/**
 * @author dainguyen.
 */
public abstract class AbstractAdapter {

    private static final Log LOGGER = LogFactory.getLog(AbstractAdapter.class);
    protected final ConcurrentMap<Long, XFutureEx<Rpc.RpcMessage>> pendingRequests;
    protected long invocationTimeout = TimeUnit.SECONDS.toMillis(10);
    protected final RpcMessageParser parser;
    protected final String service;
    protected final String version;
    private ConcurrentMap<String, String> sessions = new ConcurrentHashMap<>();

    public AbstractAdapter(Class<?> clazz, Descriptors.FileDescriptor descriptor) {
        this(Arrays.asList(clazz), descriptor);
    }

    public AbstractAdapter(List<Class<?>> clazz, Descriptors.FileDescriptor descriptor) {
        this.pendingRequests = new MapMaker().weakValues().concurrencyLevel(32).initialCapacity(1024).makeMap();
        this.service = descriptor.getOptions().getExtension(Rpc.service);
        this.version = descriptor.getOptions().getExtension(Rpc.version);
        this.parser = new RpcMessageParser(clazz);
    }

    protected final <T extends Message> T submit(final VertxSession session, final com.google.protobuf.Message request, long timeout) {
        if(VertxContext.current().isMaintainance("ALL")) {
            throw new ServiceUnavailableException("failed to invoke[MAINTAINANCE], request: " + format(request));
        } else {
            if(timeout <= 0) timeout = this.invocationTimeout;
            String sessionId = session == null ? null : this.sessions.getOrDefault(session.getHospCode(), null);
            if(sessionId == null && session != null) {
                sessionId = UUID.randomUUID().toString();
                Map map = VertxContext.current().clusterManager().getSyncMap(sessionId);
                map.put(SessionAttribute.SESSION_USER_INFO.toString(), SessionUserInfo.setSessionUserInfoByUserGroup(session.getHospCode(), session.getLanguage(), session.getLoginId(), 1, session.getUserGroup()));
                String preSessionId = this.sessions.putIfAbsent(session.getHospCode(), sessionId);
                sessionId = preSessionId != null ? preSessionId : sessionId;
            }
            final FutureEx<Rpc.RpcMessage> future = submit(sessionId == null ? UUID.randomUUID().toString() : sessionId, VertxContext.current().eventBus(), request);
            final Rpc.RpcMessage response;
            try {
                response = future.get(timeout, TimeUnit.MILLISECONDS);
                if(!response.hasResult() || response.getResult() == Rpc.RpcMessage.Result.SUCCESS) {
                    return this.parser.parse(response);
                } else {
                    throw new ServiceTransportException("failed to invoke, request: " + format(request) + ", result: " + response.getResult().name());
                }
            } catch (Exception e) {
                throw new ServiceTransportException("failed to invoke, request: " + format(request), e);
            }
        }
    }

    private FutureEx<Rpc.RpcMessage> submit(String sessionId, final EventBus eventBus, Message request) {
        final Rpc.RpcMessage req = RpcMessageBuilder.build(request, Rpc.RpcMessage.Result.SUCCESS);
        final XFutureEx<Rpc.RpcMessage> r = new XFutureEx<Rpc.RpcMessage>().setCookie(req);
        pendingRequests.put(req.getId(), r);
        byte[] idByte = sessionId.getBytes(Charset.forName("UTF-8"));
        Buffer data = new Buffer(req.toByteArray());
        data.appendBytes(idByte).appendByte((byte) sessionId.length());
        eventBus.send(service, data, (Handler<org.vertx.java.core.eventbus.Message<byte[]>>) event -> {
            Rpc.RpcMessage message = null;
            try {
                message = Rpc.RpcMessage.parseFrom(event.body());
                final long id = message.getSourceId();
                final XFutureEx<Rpc.RpcMessage> f = pendingRequests.get(id);
                if(f != null) f.setResult(message);
            } catch (InvalidProtocolBufferException e) {
                LOGGER.error(e.getMessage(), e);
            }
        });

        return r;
    }
}
