package nta.med.kcck.api.rpc;

import com.google.protobuf.InvalidProtocolBufferException;
import nta.med.common.glossary.Lifecyclet;
import nta.med.common.remoting.ServiceOverloadException;
import nta.med.common.remoting.ServiceTransportException;
import nta.med.common.remoting.rpc.exporter.RpcExportable;
import nta.med.common.remoting.rpc.exporter.impl.RpcNioExporter;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.remoting.rpc.transport.RpcTransport;
import nta.med.common.util.Exceptions;
import nta.med.common.util.Networks;
import nta.med.common.util.concurrent.future.impl.XFutureEx;
import nta.med.core.infrastructure.socket.hazelcast.HazelcastManager;
import nta.med.core.infrastructure.socket.vertx.VertxContext;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import org.apache.commons.lang3.builder.ToStringBuilder;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import javax.annotation.Resource;
import java.net.SocketAddress;
import java.util.*;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;
import java.util.concurrent.TimeUnit;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

/**
 * @author dainguyen.
 */
public class RpcApiExporter extends RpcNioExporter<RpcApiContext, RpcApiSession> implements RpcApiContext {

    private static final Logger LOGGER = LoggerFactory.getLogger(RpcApiExporter.class);
    protected final ConcurrentMap<Long, RpcApiSession> sessions = new ConcurrentHashMap<>();

    @Resource
    protected HazelcastManager hazelcastManager;

    public RpcApiExporter() {
        super("rpc.api.exporter");
    }

    @Override
    protected void doStart() throws Exception {
        // 1
        super.doStart();

        // 2
        for (List<RpcExportable<RpcApiContext, RpcApiSession>> list : this.services.values()) {
            Lifecyclet.startQuietly(list);
        }
    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        // 2
        for (List<RpcExportable<RpcApiContext, RpcApiSession>> list : this.services.values()) {
            timeout = Lifecyclet.stopQuietly(list, timeout, unit);
        }

        // 1
        return super.doStop(timeout, unit);
    }

    @Override
    public RpcApiSession getSession(long id) {
        return this.sessions.get(id);
    }

    @Override
    public Iterator<RpcApiSession> sessions() {
        return this.sessions.values().iterator();
    }

    @Override
    public Collection<RpcApiSession> getSessions() {
        return this.sessions.values();
    }

    @Override
    public RpcApiContext getContext() {
        return this;
    }

    @Override
    protected void export(RpcExportable<RpcApiContext, RpcApiSession> service) {
        super.export(service);
        service.setContext(this);
    }

    @Override
    public void onConnected(RpcTransport<Rpc.RpcMessage> transport) {
        this.sessions.put(transport.getId(), new RpcApiSessionImpl(transport));
        LOGGER.info(" > {},{},", transport.getId(), transport.getRemoteAddress());
    }

    @Override
    public void onMessage(RpcTransport<Rpc.RpcMessage> transport, Rpc.RpcMessage message) {
        // Response
        if (message.hasSourceId()) {
            final long id = message.getSourceId();
            final XFutureEx<Rpc.RpcMessage> f = this.futures.remove(id);
            if (f != null) f.setResult(message);
            return;
        }

        // Request
        final RpcApiSession session = this.sessions.get(transport.getId());
        if (session == null) {
            final String source = transport.toString();
            LOGGER.warn("rejected request[SESSION]: {}, source: {}", format(message), source);
        } else {
            Rpc.RpcMessage response = invoke(session, message);
            if (response != null) session.send(response);
        }
    }

    @Override
    public void onException(RpcTransport<Rpc.RpcMessage> transport, Throwable cause) {
        final RpcApiSession session = this.sessions.get(transport.getId());
        try {
            if (Exceptions.isCausedBy(cause, ServiceTransportException.class)) {
                LOGGER.warn("onException[BREAK], transport: " + transport + ", cause: " + cause.getMessage());
            } else if (Exceptions.isCausedBy(cause, InvalidProtocolBufferException.class)) {
                LOGGER.warn("onException[ATTACK], transport: " + transport + ", cause: " + cause.getMessage());
            } else if (Exceptions.isCausedBy(cause, ServiceOverloadException.class)) {
                LOGGER.warn("onException[OVERLOAD], transport: " + transport + ", cause: " + cause.getMessage());
            } else {
                final Throwable root = Exceptions.getRootCause(cause);
                LOGGER.error("onException[INTERNAL_ERROR], transport: " + transport, root != null ? root : cause);
            }
        } finally {
            if (session != null) try {
                session.invalidate();
            } catch (Throwable ignore) { /* NOP */ } // Disconnect
        }
    }

    @Override
    public void onDisconnected(RpcTransport<Rpc.RpcMessage> transport, Throwable cause) {
        final SocketAddress address = transport.getRemoteAddress();
        RpcApiSession session = this.sessions.remove(transport.getId());
        final String loginId = (session == null) ? "" : session.getLoginId();
        if (session != null) try {
            session.logout(true);
        } catch (Throwable ignore) {
        }
        LOGGER.info(" < {},{},{}", new Object[]{transport.getId(), address, loginId});
    }

    protected class RpcApiSessionImpl extends RpcSessionImpl implements RpcApiSession {
        //
        private volatile String loginId;
        private volatile String hospCode;
        private volatile String language;
        private volatile String userGroup;
        private volatile Integer clisSmoId;
        private volatile Set<String> hospitals = new HashSet<>();
        private volatile Set<String> patients = new HashSet<>();
        private volatile Set<String> books = new HashSet<>();
        private volatile Set<SystemServiceProto.LoginRequest.Capability> capabilities = new HashSet<>();

        @Override
        public String getLoginId() {
            return this.loginId;
        }

        @Override
        public String getHospCode() {
            return this.hospCode;
        }

        @Override
        public String getLanguage() {
            return this.language;
        }

        @Override
        public String getUserGroup() {
            return this.userGroup;
        }

        @Override
        public Integer getClisSmoId() {
            return this.clisSmoId;
        }

        @Override
        public boolean isAuthenticated() {
            return this.loginId != null;
        }

        public RpcApiSessionImpl(RpcTransport<Rpc.RpcMessage> transport) {
            super(transport);
        }

        @Override
        public void subscribePatient(String hospCode) {
            this.patients.add(hospCode);
        }

        @Override
        public void subscribeHospital(String hospCode) {
            this.hospitals.add(hospCode);
        }

        @Override
        public void subscribeBooking(String hospCode) {
            this.books.add(hospCode);
        }

        @Override
        public boolean isVerbose() {
            return true;
        }

        @Override
        public void unsubscribePatient(String hospCode) {
            if (hospCode == null) patients.clear();
            else patients.remove(hospCode);
        }

        @Override
        public void unsubscribeHospital(String hospCode) {
            if (hospCode == null) hospitals.clear();
            else hospitals.remove(hospCode);
        }

        @Override
        public void unsubscribeBooking(String hospCode) {
            if (hospCode == null) books.clear();
            else books.remove(hospCode);
        }

        @Override
        public boolean hasSubscribedPatient(String hospCode) {
            return hospCode == null ? !patients.isEmpty() : patients.contains(hospCode) || patients.contains("NTA");
        }

        @Override
        public boolean hasSubscribedHospital(String hospCode) {
            return hospCode == null ? !hospitals.isEmpty() : hospitals.contains(hospCode) || hospitals.contains("NTA");
        }

        @Override
        public boolean hasSubscribedBooking(String hospCode) {
            return hospCode == null ? !books.isEmpty() : books.contains(hospCode) || books.contains("NTA");
        }

        @Override
        public boolean hasCapability(SystemServiceProto.LoginRequest.Capability capability) {
        	boolean r = this.capabilities.contains(capability);
            LOGGER.info("Capability " + capability + ": " + r);
            return r;
        }

        @Override
        public String toString() {
            return new ToStringBuilder(this)
                    .append("loginId", loginId)
                    .append("hospCode", hospCode)
                    .append("language", language)
                    .append("userGroup", userGroup)
                    .append("clisSmoId", clisSmoId)
                    .append("hospitals", hospitals)
                    .append("patients", patients)
                    .append("books", books)
                    .toString();
        }

        @Override
        public void logout(final boolean force) {
            this.unsubscribeHospital(null);
            this.unsubscribePatient(null);
            String lid = loginId;
            loginId = null;
            for (SystemServiceProto.LoginRequest.Capability cp : this.capabilities) {
                switch (cp) {
                    case CREATE_PATIENT:
                        hazelcastManager.delEndpoint(NuroServiceProto.CreatePatientRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                        break;
                    case BOOK_EXAM:
                        hazelcastManager.delEndpoint(NuroServiceProto.SaveExaminationRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                        break;
                    case APPOINT_EXAM:
                    	hazelcastManager.delEndpoint(NuroServiceProto.BookingExaminationRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                        break;
                    case GET_MIS_TOKEN:
                    	hazelcastManager.delEndpoint(nta.med.service.ihis.proto.SystemServiceProto.GetMisTokenRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                    	break;
                    case ORDER_TRANSFER:
                    	hazelcastManager.delEndpoint(nta.med.service.ihis.proto.NuroServiceProto.OrderTranferRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                    	break;
                    case GET_MIS_SURVEY_LINK:
                    	hazelcastManager.delEndpoint(nta.med.service.ihis.proto.NuroServiceProto.GetMisSurveyLinkRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                    	break;	
                }
            }
            LOGGER.info("{}- {},{},{}", new Object[]{force ? "!" : " ", getId(), Networks.format(getRemoteAddress()), lid});
        }

        @Override
        public void login(final String loginId, final String hospCode, String language, String userGroup, Integer clisSmoId, List<SystemServiceProto.LoginRequest.Capability> capabilities) {
            this.loginId = loginId; this.hospCode = hospCode; this.language = language;
            this.userGroup = userGroup; this.clisSmoId = clisSmoId;
            this.capabilities.addAll(capabilities);
            for (SystemServiceProto.LoginRequest.Capability cp : this.capabilities) {
                switch (cp) {
                    case CREATE_PATIENT:
                        hazelcastManager.addEndpoint(NuroServiceProto.CreatePatientRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                        break;
                    case BOOK_EXAM:
                        hazelcastManager.addEndpoint(NuroServiceProto.SaveExaminationRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                        break;
                    case APPOINT_EXAM:
                    	hazelcastManager.addEndpoint(NuroServiceProto.BookingExaminationRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                        break;
                    case GET_MIS_TOKEN:
                    	hazelcastManager.addEndpoint(nta.med.service.ihis.proto.SystemServiceProto.GetMisTokenRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                    	break;
                    case ORDER_TRANSFER:
                        hazelcastManager.addEndpoint(NuroServiceProto.OrderTranferRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                        break;
                    case GET_MIS_SURVEY_LINK:
                        hazelcastManager.addEndpoint(NuroServiceProto.GetMisSurveyLinkRequest.class.getSimpleName(), hospCode, VertxContext.current().clusterManager().getNodeID());
                        break;    
                }
            }
            LOGGER.info(" + {},{},{}", new Object[]{getId(), Networks.format(getRemoteAddress()), loginId});
        }

        @Override
        public boolean isAuthorized(String hospCode) {
            LOGGER.info(String.format("isAuthorized(%s). session hospCode is %s", hospCode == null ? "null" : hospCode, this.hospCode == null ? "null" : this.hospCode));
            if(this.hospCode == null || hospCode == null) {
                LOGGER.warn("calling method isAuthorized with hospCode is null: SESSION" + toString());
                return false;
            }
            return this.hospCode.equals("NTA") || this.hospCode.equals(hospCode);
        }
    }
}
