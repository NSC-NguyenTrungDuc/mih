package nta.med.core.infrastructure.socket.handler;

import com.google.common.collect.MapMaker;
import com.google.protobuf.InvalidProtocolBufferException;
import com.google.protobuf.Message;
import nta.med.common.remoting.ServiceUnavailableException;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.util.Lists;
import nta.med.common.util.Objects;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.common.util.concurrent.future.impl.XFutureEx;
import nta.med.common.util.type.Tuple;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.SessionAttribute;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.hazelcast.HazelcastManager;
import nta.med.core.infrastructure.socket.store.EventStore;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Handler;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.buffer.Buffer;
import org.vertx.java.core.impl.VertxInternal;
import org.vertx.java.core.spi.cluster.ClusterManager;

import javax.annotation.Resource;
import java.nio.charset.Charset;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.concurrent.ConcurrentMap;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

/**
 * @author dainguyen
 */
public abstract class ScreenHandler<REQ extends Message, RES extends Message> {

    private static final Log LOGGER = LogFactory.getLog(ScreenHandler.class);
    private static ThreadLocal<Tuple<String, SessionUserInfo>> session = new InheritableThreadLocal<>();
    private ConcurrentMap<Long, XFutureEx<? extends Message>> pendingRequests;

    @Resource
    private EventStore eventStore;

    @Resource
    private HazelcastManager hazelcastManager;

    private Map clusterMap(Vertx vertx, String mapName){
        ClusterManager clusterManager = ((VertxInternal)vertx).clusterManager();
        Map map = clusterManager.getSyncMap(mapName);
        return map;
    }

    public void setSessionInfo(Vertx vertx, String sessionId, SessionUserInfo sessionUserInfo)
    {
        clusterMap(vertx, sessionId).put(SessionAttribute.SESSION_USER_INFO.toString(), sessionUserInfo);
        session.set(new Tuple<>(sessionId, getSessionInfo(vertx, sessionId)));
    }

    public SessionUserInfo getSessionInfo(Vertx vertx, String sessionId) {
        SessionUserInfo sessionInfo = (SessionUserInfo) clusterMap(vertx, sessionId).get(SessionAttribute.SESSION_USER_INFO.toString());
        if (null == sessionInfo) {
            LOGGER.info("ScreenHandler session Id get cluster not found : " + sessionId);
            LOGGER.debug("ScreenHandler session Id get cluster not found : " + sessionId);
            return new SessionUserInfo("", Language.JAPANESE.toString(), "", UserRole.ANONYMOUS.getValue(), null);
        }
        LOGGER.info("ScreenHandler session Id found : "+ sessionId);
        LOGGER.debug("ScreenHandler session Id found : "+ sessionId);
        return sessionInfo;
    }

    public String getHospitalCode(Vertx vertx, String sessionId) {
        ensureSessionAvailable(vertx, sessionId);
        return session.get().getV2().getHospitalCode();

    }

    public void cleanIfNotMatch(String sessionId){
        if(session.get() != null && !sessionId.equals(session.get().getV1())){
            session.remove();
        }
    }

    private void ensureSessionAvailable(Vertx vertx, String sessionId) {
        if(session.get() == null){
            session.set(new Tuple<>(sessionId, getSessionInfo(vertx, sessionId)));
        }
    }

    public String getLanguage(Vertx vertx, String sessionId) {
        ensureSessionAvailable(vertx, sessionId);
        return session.get().getV2().getLanguage();
    }

    public String getUserId(Vertx vertx, String sessionId) {
        ensureSessionAvailable(vertx, sessionId);
        return session.get().getV2().getUserId();
    }

    public String getUserRole(Vertx vertx, String sessionId) {
        ensureSessionAvailable(vertx, sessionId);
        return session.get().getV2().getRole();
    }

    public Integer getClisSmoId(Vertx vertx, String sessionId) {
        ensureSessionAvailable(vertx, sessionId);
        return session.get().getV2().getClisSmoId();
    }
    public Integer getTimeZone(Vertx vertx, String sessionId)
    {
        ensureSessionAvailable(vertx, sessionId);
        return session.get().getV2().getTimeZone();
    }
    /**
     * Check whether current request is authorized or not
     * @return True if current request is authorized.
     */
    public boolean isAuthorized(Vertx vertx, String sessionId){
        return !UserRole.ANONYMOUS.getValue().equals(getUserRole(vertx, sessionId));
    }
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, REQ request) throws Exception {
        //override in concrete class
    }

    public RES postHandle(Vertx vertx, String clientId, String sessionId, long contextId, REQ request, RES response) throws Exception {
        //override in concrete class
        return response;
    }

    @Transactional
    public RES doInTransaction(Vertx vertx, String clientId, String sessionId, long contextId, REQ request) throws Exception{
        preHandle(vertx, clientId, sessionId, contextId, request);
        RES response = handle(vertx, clientId, sessionId, contextId, request);
        response = postHandle(vertx, clientId, sessionId, contextId, request, response);
        return response;
    }

    public Tuple<Boolean, Collection<String>> isShardable(REQ request, Vertx vertx, String clientId, String sessionId) {
        return new Tuple<>(false, Lists.emptyList());
    }

    public RES mergeShards(List<RES> responses) {
        return responses == null || responses.isEmpty() ? null : responses.get(0);
    }

    public boolean isValid(REQ request, Vertx vertx, String clientId, String sessionId){
        return true;
    }

    public abstract RES handle(Vertx vertx, String clientId, String sessionId, long contextId, REQ request) throws Exception;

    public ThreadLocal<Tuple<String, SessionUserInfo>> getSession() {
        return session;
    }

    public void setSession(ThreadLocal<Tuple<String, SessionUserInfo>> session) {
        this.session = session;
    }

    protected Message publish(Vertx vertx, Message message) {
        Message r;
        try { r = eventStore.persist(message, (counter, latest) -> hazelcastManager.getCounter(counter, latest).incrementAndGet()); }
        catch (Exception e) { LOGGER.warn("fail to persist event: " + format(message) + ", error: " + e.getMessage(), e); r = message; }
        final Rpc.RpcMessage req = RpcMessageBuilder.build(r, Rpc.RpcMessage.Result.SUCCESS);
        vertx.eventBus().publish(r.getClass().getSimpleName(), new Buffer(req.toByteArray()));
        return r;
    }

    protected <T extends Message> FutureEx<T> send(Vertx vertx, final RpcMessageParser parser, Message message, String hospCode) {
        final Rpc.RpcMessage req = RpcMessageBuilder.build(message, Rpc.RpcMessage.Result.SUCCESS);
        final XFutureEx<T> r = new XFutureEx<T>().setCookie(req);
        if(pendingRequests == null) pendingRequests = new MapMaker().weakValues().concurrencyLevel(32).initialCapacity(128).makeMap();
        pendingRequests.put(req.getId(), r);
        String endpoint = hazelcastManager.getEndpoint(message.getClass().getSimpleName(), hospCode);
        if(endpoint == null) throw new ServiceUnavailableException();
        String sessionId = UUID.randomUUID().toString();
        byte[] idByte = sessionId.getBytes(Charset.forName("UTF-8"));
        Buffer data = new Buffer(req.toByteArray());
        data.appendBytes(idByte).appendByte((byte) sessionId.length());
        vertx.eventBus().send(endpoint, data, (Handler<org.vertx.java.core.eventbus.Message<byte[]>>) event -> {
            Rpc.RpcMessage msg = null;
            try {
                msg = Rpc.RpcMessage.parseFrom(event.body());
                final long id = msg.getSourceId();
                final XFutureEx<T> f = Objects.cast(pendingRequests.get(id));
                if(f != null) f.setResult(parser.parse(msg));
            } catch (InvalidProtocolBufferException e) {
                LOGGER.error(e.getMessage(), e);
            }
        });
        return r;
    }
}
