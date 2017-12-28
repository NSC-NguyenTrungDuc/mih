package nta.med.websocket;

import com.google.protobuf.InvalidProtocolBufferException;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.remoting.rpc.protobuf.Rpc.RpcMessage.Result;
import nta.med.common.util.Strings;
import nta.med.common.util.compressor.Compressor;
import nta.med.common.util.compressor.snappy.SnappyCompressor;
import nta.med.common.util.type.Pair;
import nta.med.core.glossary.AdministrationNotice;
import nta.med.core.glossary.MonitorKey;
import nta.med.core.glossary.SessionAttribute;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Handler;
import org.vertx.java.core.buffer.Buffer;
import org.vertx.java.core.eventbus.EventBus;
import org.vertx.java.core.eventbus.Message;
import org.vertx.java.core.http.HttpServer;
import org.vertx.java.core.impl.VertxInternal;
import org.vertx.java.core.net.impl.ServerID;
import org.vertx.java.core.spi.cluster.AsyncMultiMap;
import org.vertx.java.core.spi.cluster.ClusterManager;
import org.vertx.java.platform.Verticle;

import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.concurrent.*;
import java.util.concurrent.atomic.AtomicReference;
import java.util.function.Consumer;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

/**
 * @author dainguyen
 */
public class MedicalVerticle extends Verticle {

    private static final Log logger = LogFactory.getLog(MedicalVerticle.class);
    private static final int BUFF_SIZE = 8 * 1024 * 1024;
    private static final String LOGIN_ON_BEHALF_OF_REQUEST = Rpc.AdmLoginOnBehalfOfRequest.class.getSimpleName();
    private static final String MEDAPP_LOGIN_REQUEST = "AdmLoginFormCheckLoginUserRequest";
    private static final String MEDAPP_LOGIN_RESPONSE = "AdmLoginFormCheckLoginUserResponse";
    private static final String MEDAPP_LOAD_HOSP_CODE_REQUEST = "FormSelectHospCodeRequest";
    private static ConcurrentMap<String, String> vpnConnection = new ConcurrentHashMap<>();
    private final Compressor compressor = new SnappyCompressor();
    private volatile AtomicReference<Boolean> maintainance = new AtomicReference<>(false);

    private Map clusterMap(String mapName) {
        ClusterManager clusterManager = ((VertxInternal) vertx).clusterManager();
        Map map = clusterManager.getSyncMap(mapName);
        return map;
    }

    @Override
    public void start() {
        final Pattern chatUrlPattern = Pattern.compile("/websocket");
        final EventBus eventBus = vertx.eventBus();

        String hostname = WebsocketStartup.getConfigProperty("vertx.hostname", "127.0.0.1");
        Integer port = Integer.parseInt(WebsocketStartup.getConfigProperty("vertx.port", "8090"));
        String vpnHost = WebsocketStartup.getConfigProperty("vpn.host", "127.0.0.1");
        Integer vpnPort = Integer.parseInt(WebsocketStartup.getConfigProperty("vpn.port", "8091"));
        boolean useSsl = Boolean.parseBoolean(WebsocketStartup.getConfigProperty("vertx.ssl", "false"));
        boolean forceVpn = Boolean.parseBoolean(WebsocketStartup.getConfigProperty("vpn.force", "false"));
        String password = WebsocketStartup.getConfigProperty("ssl.password", "qWe!23qwer!@#$");
        String vpnUrl = WebsocketStartup.getConfigProperty("vpn.prefix", "10.0.0.1");
        HttpServer server = vertx.createHttpServer()
                .setMaxWebSocketFrameSize(BUFF_SIZE);
        HttpServer serverVPN = vertx.createHttpServer()
                .setMaxWebSocketFrameSize(BUFF_SIZE);

        if (useSsl) {
            server.setSSL(useSsl)
                    .setKeyStorePath(System.getProperty("configPath") + "/websocket.jks")
                    .setKeyStorePassword(password);
        }
        ScheduledExecutorService service = Executors.newSingleThreadScheduledExecutor();
        Runnable actionSchedule = () -> MonitorLog.writeMonitorLog(MonitorKey.CONNECTION, vertx.sharedData().getSet("connections").size() + "");
        service.scheduleWithFixedDelay(actionSchedule, new Long(1), Long.parseLong(WebsocketStartup.getConfigProperty("scheduleLog.delay", "10")), TimeUnit.MINUTES);
        initWebSocket(chatUrlPattern, eventBus, hostname, port, server, vpnUrl, forceVpn);
        initWebSocket(chatUrlPattern, eventBus, vpnHost, vpnPort, serverVPN, vpnUrl, forceVpn);
        service.scheduleAtFixedRate(() -> {
            ClusterManager clusterMgr = ((VertxInternal) vertx).clusterManager();
            final String nodeID = clusterMgr.getNodeID();
            AsyncMultiMap<String, ServerID> subs = clusterMgr.getAsyncMultiMap("subs");
            subs.get(AdministrationNotice.MAINTAINANCE_WHOLE_SYSTEM_NOTICE.getAddress(), event -> {
                final List<Boolean> exits = new ArrayList<>();
                event.result().forEach(serverID -> {
                    if(serverID.equals(nodeID)) exits.add(true);
                });
                if(exits.size() == 0) {
                    registerMaintainanceHandler(eventBus);
                }
            });
        }, 10, 60, TimeUnit.SECONDS);
    }

    private void registerMaintainanceHandler(EventBus eventBus) {
        eventBus.registerHandler(AdministrationNotice.MAINTAINANCE_WHOLE_SYSTEM_NOTICE.getAddress(), (Handler<Message<Integer>>) event -> {
            logger.info("Receive maintainance notice: " + event.body());
            boolean result = maintainance.getAndSet(event.body() != null && event.body() != 0);
            if(!result) logger.warn("FAIL TO UPDATE MAINTAINANCE MODE TO " + event.body());
        }, event -> {
            if (event.succeeded()) {
                logger.info("Completed registerHandler of " + AdministrationNotice.MAINTAINANCE_WHOLE_SYSTEM_NOTICE.getAddress());
            } else {
                logger.info(String.format("RegisterHandler of %s was failed. Result = %s", AdministrationNotice.MAINTAINANCE_WHOLE_SYSTEM_NOTICE.getAddress(), event.result()));
            }
        });
    }

    private void initWebSocket(final Pattern chatUrlPattern, final EventBus eventBus, String hostname, Integer port, HttpServer server, String vpnUrl, boolean forceVpn) {
        server.websocketHandler(ws -> {
            final Matcher m = chatUrlPattern.matcher(ws.path());
            if (!m.matches()) {
                ws.reject();
                return;
            }
            final String connectionId = ws.binaryHandlerID();
            final Pair<String> id = new Pair<>(connectionId, null);
            logger.info("registering new connection with id: " + connectionId + ", length=" + connectionId.length());
            vertx.sharedData().getSet("connections").add(connectionId);

            ws.closeHandler(event -> {
                logger.info("un-registering connection with id: " + connectionId + ", length=" + connectionId.length());
                vertx.sharedData().getSet("connections").remove(connectionId);
                //Remove session
                clusterMap(connectionId).clear();
                vpnConnection.remove(connectionId);
            });

            ws.dataHandler(data -> {
                try {
                    byte[] dataBytes = data.getBytes();
                    Rpc.RpcMessage message = Rpc.RpcMessage.parseFrom(dataBytes);
                    if(maintainance.get()) {
                        String sessionId = id.getV2() == null ? id.getV1() : id.getV2();
                        SessionUserInfo sessionInfo = (SessionUserInfo) clusterMap(sessionId).get(SessionAttribute.SESSION_USER_INFO.toString());
                        if(sessionInfo == null || !"NTA".equalsIgnoreCase(sessionInfo.getHospitalCode())) {
                            if(!"FormSelectHospCodeRequest".equals(message.getPayloadClass()) && !"AdmLoginFormCheckLoginUserRequest".equals(message.getPayloadClass()) && !"AdmLoginOnBehalfOfRequest".equals(message.getPayloadClass())) {
                                //System is in maintainance mode --> reject all requests
                                Rpc.RpcMessage response = RpcMessageBuilder.reply(message).setResult(Result.MAINTAINANCE).build();
                                eventBus.send(connectionId, new Buffer(response.toByteArray()));
                                logger.info("[REJECT][MAINTAINANCE] - " + format(message));
                                return;
                            }
                        }
                    }
                    boolean isLoginRequest = MEDAPP_LOGIN_REQUEST.equals(message.getPayloadClass());
                    boolean isLoadHospCodeRequest = MEDAPP_LOAD_HOSP_CODE_REQUEST.equals(message.getPayloadClass());
                    boolean isOnBehalfOfLoginRequest = LOGIN_ON_BEHALF_OF_REQUEST.equals(message.getPayloadClass());
                    logger.info("[LOGIN CONNECTION]:" + connectionId);
                    if (forceVpn && !isLoadHospCodeRequest && !isLoginRequest  && !isOnBehalfOfLoginRequest &&
                            (!vpnConnection.containsKey(connectionId) || (vpnConnection.get(connectionId).equals("Y") &&
                            !ws.remoteAddress().getHostString().startsWith(vpnUrl)))) {
                        logger.info("[REJECT SERVICE]");
                        Rpc.RpcMessage response = RpcMessageBuilder.reply(message).setResult(Result.REQUIRE_VPN).build();
                        eventBus.send(connectionId, new Buffer(response.toByteArray()));
                        return;
                    }
                    receiveAndReplyData(message, data, id, (Buffer buffer) -> {
                        eventBus.send(message.getService(), buffer, (Handler<Message<byte[]>>) event -> {

                            if (isLoginRequest) {
                                try {
                                    Rpc.RpcMessage messageRes = Rpc.RpcMessage.parseFrom(event.body());
                                    if (messageRes.getResult() == Result.SUCCESS && messageRes.hasPayloadClass() && messageRes.getPayloadClass().equals(MEDAPP_LOGIN_RESPONSE) && messageRes.hasPayloadData()) {
                                        byte[] payload = messageRes.hasCompress() && messageRes.getCompress() ? compressor.uncompress(messageRes.getPayloadData().toByteArray()) : messageRes.getPayloadData().toByteArray();
                                        SystemServiceProto.AdmLoginFormCheckLoginUserResponse rp = SystemServiceProto.AdmLoginFormCheckLoginUserResponse
                                                .parseFrom(payload);
                                        logger.info("[LOGIN CONNECTION VPNYN]:" + connectionId);
                                        String vpnYN = Strings.isEmpty(rp.getVpnYn()) ? "N" :rp.getVpnYn();
                                        vpnConnection.put(connectionId, vpnYN);
                                        List<SystemModelProto.AdmLoginFormCheckLoginUserInfo> userList = rp.getUserInfoItemList();
                                        if (!CollectionUtils.isEmpty(userList)) {
                                            logger.info("[LOGIN REQUEST]:"
                                                    + "  [IP CLIENT] = " + ws.remoteAddress().getHostString()
                                                    + ", [HOSP_CODE] = " + userList.get(0).getHospCode()
                                                    + ", [USER] = " + userList.get(0).getUserNm()
                                                    + ", [RESULT] = SUCCESS");
                                        } else {
                                            logger.info("[LOGIN REQUEST]:"
                                                    + "	 [IP CLIENT] = " + ws.remoteAddress().getHostString()
                                                    + ", [RESULT] = FAIL");
                                        }
                                    } else {
                                        logger.info("[LOGIN REQUEST]:"
                                                + "	 [IP CLIENT] = " + ws.remoteAddress().getHostString()
                                                + ", [RESULT] = FAIL");
                                    }

                                } catch (Exception e) {
                                    logger.error(e.getMessage(), e);
                                }

                                if (forceVpn && (!vpnConnection.containsKey(connectionId) || (vpnConnection.get(connectionId).equals("Y") &&
                                        !ws.remoteAddress().getHostString().startsWith(vpnUrl)))) {
                                    logger.info("[REJECT SERVICE]");
                                    Rpc.RpcMessage response = RpcMessageBuilder.reply(message).setResult(Result.REQUIRE_VPN).build();
                                    eventBus.send(connectionId, new Buffer(response.toByteArray()));
                                    return;
                                }
                            }

                            eventBus.send(connectionId, new Buffer(event.body()));
                            logger.info("[END] MESSAGE SERVICE: " + message.getClientId() + " : " + message.getPayloadClass());
                        });
                    });
                } catch (InvalidProtocolBufferException e) {
                    logger.error(e.getMessage(), e);
                    ws.reject();
                }
            });
        }).listen(port, hostname);
    }

    public static void receiveAndReplyData(Rpc.RpcMessage message, Buffer data, Pair<String> id, Consumer<Buffer> consumer) {
        try {
            String sessionId = id.getV2() == null ? id.getV1() : id.getV2();
            logger.info("V1 : " + id.getV1() + " : V2 " + id.getV2());
            byte[] idByte = sessionId.getBytes(Charset.forName("UTF-8"));
            data.appendBytes(idByte).appendByte((byte) sessionId.length());

            logger.info("[START] MESSAGE SERVICE: " + message.getClientId() + " : " + message.getPayloadClass() + ", service:" + message.getService() + ", version:" + message.getVersion());
            if (LOGIN_ON_BEHALF_OF_REQUEST.equals(message.getPayloadClass())) {
                Rpc.AdmLoginOnBehalfOfRequest request = Rpc.AdmLoginOnBehalfOfRequest.parseFrom(message.getPayloadData());
                if (request.hasSessionId()) {
                    id.setV2(request.getSessionId());
                    vpnConnection.putIfAbsent(id.getV1(), vpnConnection.getOrDefault(request.getSessionId(), "N"));
                }
            } else {
                consumer.accept(data);
            }
        } catch (InvalidProtocolBufferException e) {
            logger.error(e.getMessage(), e);
        }
    }
}
