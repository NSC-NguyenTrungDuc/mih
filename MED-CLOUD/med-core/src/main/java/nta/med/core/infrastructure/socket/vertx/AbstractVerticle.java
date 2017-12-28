package nta.med.core.infrastructure.socket.vertx;

import com.google.protobuf.ByteString;
import com.google.protobuf.Descriptors;
import com.google.protobuf.InvalidProtocolBufferException;
import nta.med.common.remoting.RemotingGenerator;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.message.RpcMessageFormatter;
import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.util.Strings;
import nta.med.common.util.compressor.Compressor;
import nta.med.common.util.compressor.snappy.SnappyCompressor;
import nta.med.common.util.type.Tuple;
import nta.med.core.config.VertxConfig;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.RoutingDataSource;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.context.DbContext;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.infrastructure.socket.listener.AbstractListener;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.orm.jpa.JpaSystemException;
import org.vertx.java.core.Handler;
import org.vertx.java.core.buffer.Buffer;
import org.vertx.java.core.eventbus.EventBus;
import org.vertx.java.core.eventbus.Message;
import org.vertx.java.core.eventbus.impl.BaseMessage;
import org.vertx.java.core.eventbus.impl.DefaultEventBus;
import org.vertx.java.core.net.impl.ServerID;
import org.vertx.java.platform.Verticle;

import java.lang.reflect.Field;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.List;
import java.util.concurrent.*;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.concurrent.atomic.AtomicReference;

/**
 * @author dainguyen.
 */
public abstract class AbstractVerticle extends Verticle {

    private enum Status {STARTING, STARTED, STOPPING, STOPPED;}

    private final AtomicReference<Status> status = new AtomicReference<Status>(Status.STOPPED);
    private CountDownLatch started = new CountDownLatch(1);
    private final AtomicInteger references = new AtomicInteger(0);
    private VertxConfig configuration = null;
    protected ExecutorService vertxExecutor;
    protected XHandler xhandler = null;
    private XSubscriber xsubscriber = null;
    private LinkedBlockingQueue xQueue = null;
    private Compressor compressor = new SnappyCompressor();
    protected final ConcurrentHashMap<String, ScreenHandler> handlers = new ConcurrentHashMap<>(128);
    protected final ConcurrentHashMap<String, AbstractListener> listeners = new ConcurrentHashMap<>(128);

    private static final Log LOGGER = LogFactory.getLog(AbstractVerticle.class);

    protected final String service;

    protected final RpcMessageParser parser;

    protected abstract void doStart() throws Exception;

    protected abstract void doStop() throws Exception;

    protected boolean isCompatible(String version) {
        return true;
    }

    protected List<String> subscribeTopics() {
        return Arrays.asList();
    }

    protected boolean isProcessable() {
        return true;
    }

    public AbstractVerticle(Class<?> clazz, Descriptors.FileDescriptor descriptor) {
        this.service = descriptor.getOptions().getExtension(Rpc.service);
        this.parser = new RpcMessageParser(clazz);
    }

    protected void registerHandler(String handlerName, ScreenHandler handler) {
        handlers.putIfAbsent(handlerName, handler);
    }

    protected void unRegisterHandler(String handlerName) {
        handlers.remove(handlerName);
    }

    protected void subscribeHandler(String eventName, AbstractListener listener) {
        listeners.putIfAbsent(eventName, listener);
    }

    protected void unSubscribeHandler(String eventName) {
        listeners.remove(eventName);
    }

    void unregisterHandler() {
        CountDownLatch latch = new CountDownLatch(1);
        if (xhandler != null) {
            vertx.eventBus().unregisterHandler(service, xhandler, event -> {
                System.out.println(String.format("lifecyclet: %s was successfully unregistered.", service));
                latch.countDown();
            });
        }
        try {
            latch.await(30, TimeUnit.SECONDS);
        } catch (InterruptedException e) {
            LOGGER.warn(e.getMessage(), e);
        }
    }

    @Override
    public void start() {
        // Precondition checking
        this.references.getAndIncrement();
        if (!this.status.compareAndSet(Status.STOPPED, Status.STARTING)) {
            try {
                this.started.await();
                return;
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }
        }

        configuration = SpringBeanFactory.beanFactory.getBean(VertxConfig.class);
        //
        RuntimeException ex = null;
        try {
            xQueue = new LinkedBlockingQueue();
            vertxExecutor = new XThreadPoolExecutor(configuration.getVertxThreads(), configuration.getVertxThreads(),
                    0L, TimeUnit.MILLISECONDS,
                    xQueue);
            doStart();
            if (isProcessable()) {
                xhandler = new XHandler(vertxExecutor, vertx.eventBus());
                vertx.eventBus().registerHandler(service, xhandler, event -> {
                    if (event.succeeded()) {
                        VertxContext.current().add(this);
                        LOGGER.info(String.format("lifecyclet: %s was successfully registered.", service));
                    } else {
                        LOGGER.error(String.format("lifecyclet: registering %s was failed.", service), event.cause());
                    }
                });
            }

            xsubscriber = new XSubscriber(vertxExecutor);
            for (final String topic : subscribeTopics()) {
                vertx.eventBus().registerHandler(topic, xsubscriber, event -> {
                    if (event.succeeded()) {
                        VertxContext.current().add(this);
                        LOGGER.info(String.format("lifecyclet: topic %s was successfully registered.", topic));
                    } else {
                        LOGGER.error(String.format("lifecyclet: registering topic %s was failed.", topic), event.cause());
                    }
                });
            }
        } catch (RuntimeException e) {
            ex = e;
            throw ex;
        } catch (Throwable e) {
            ex = new RuntimeException(e);
            throw ex;
        } finally {
            this.status.set(Status.STARTED);
            if (ex != null) this.started.countDown();
        }
    }

    @Override
    public void stop() {
        // Precondition checking
        if (this.references.decrementAndGet() != 0) return;
        if (!this.status.compareAndSet(Status.STARTED, Status.STOPPING)) return;

        //
        try {
            doStop();
            List<Runnable> jobs = vertxExecutor.shutdownNow();
            if (configuration.isVerbose() && xQueue.size() > 0) {
                System.out.println(String.format("%s - QUEUE SIZE: %s, THREAD: %s", service, xQueue.size(), configuration.getVertxThreads()));
            }
            if (jobs.size() > 0) {
                System.out.println(String.format("There are %s pending jobs. The program will try to pass these jobs to other nodes.", jobs.size()));
                jobs.stream().filter(r -> r instanceof XFutureTask).forEach(r -> {
                    XRunnable xr = ((XFutureTask) r).getXrnb();
                    if (xr != null) {
                        System.out.println(String.format("START: Request[id=%s, clientId=%s, replyAddress=%s].", xr.getOriginalMessage().getId(), xr.getOriginalMessage().getClientId(), xr.getReplyAddress()));
                        Rpc.RpcMessage.Builder builder = RpcMessageBuilder.toBuilder(xr.getOriginalMessage());
                        if (!builder.hasReplyAddress()) builder.setReplyAddress(xr.getReplyAddress());
                        if (!builder.hasReplyHost() || !builder.hasReplyPort()) {
                            ServerID serverID = xr.getReplyServerID();
                            if (configuration.isVerbose()) System.out.println("DESTINATION HOST: " + serverID);
                            if (serverID != null) {
                                builder.setReplyHost(serverID.host);
                                builder.setReplyPort(serverID.port);
                            }
                        }

                        Buffer data = new Buffer(builder.build().toByteArray());
                        byte[] idByte = xr.getSessionId().getBytes(Charset.forName("UTF-8"));
                        data.appendBytes(idByte).appendByte((byte) xr.getSessionId().length());
                        vertx.eventBus().send(service, data);
                        System.out.println(String.format("END: Request[id=%s, clientId=%s] has been passed to other nodes successfully.", builder.getId(), builder.getClientId()));
                    }
                });
            }
            for (final String topic : subscribeTopics()) {
                vertx.eventBus().unregisterHandler(topic, xsubscriber, event -> {
                    if (event.succeeded()) {
                        LOGGER.info(String.format("lifecyclet: topic %s was successfully unregistered.", topic));
                    } else {
                        LOGGER.error(String.format("lifecyclet: unregistering topic %s was failed.", topic), event.cause());
                    }
                });
            }
            vertxExecutor.awaitTermination(5, TimeUnit.MINUTES);
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
            throw new RuntimeException(e);
        } catch (RuntimeException e) {
            throw e;
        } catch (Throwable e) {
            throw new RuntimeException(e);
        } finally {
            this.status.set(Status.STOPPED);
            VertxContext.current().remove(this);
        }
    }

    class XRunnable implements Runnable {

        private final Runnable action;
        private final String sessionId;
        private final String replyAddress;
        private final Rpc.RpcMessage originalMessage;
        private final Message<Buffer> event;

        public XRunnable(Runnable action, String sessionId, String replyAddress, Rpc.RpcMessage originalMessage, Message<Buffer> event) {
            this.action = action;
            this.sessionId = sessionId;
            this.replyAddress = replyAddress;
            this.originalMessage = originalMessage;
            this.event = event;
        }

        @Override
        public void run() {
            action.run();
        }

        public String getSessionId() {
            return sessionId;
        }

        public String getReplyAddress() {
            return replyAddress;
        }

        public Rpc.RpcMessage getOriginalMessage() {
            return originalMessage;
        }

        public ServerID getReplyServerID() {
            try {
                Field field = BaseMessage.class.getDeclaredField("sender");
                field.setAccessible(true);
                return field == null ? null : (ServerID) field.get(event);
            } catch (Exception e) {
                return null;
            }
        }
    }

    class XFutureTask<T> extends FutureTask<T> {

        private XRunnable xrnb;

        public XFutureTask(Runnable runnable, T result) {
            super(runnable, result);
            if (runnable instanceof XRunnable) {
                xrnb = (XRunnable) runnable;
            }
        }

        public XRunnable getXrnb() {
            return xrnb;
        }
    }

    class XThreadPoolExecutor extends ThreadPoolExecutor {

        public XThreadPoolExecutor(int corePoolSize, int maximumPoolSize, long keepAliveTime, TimeUnit unit, BlockingQueue<Runnable> workQueue) {
            super(corePoolSize, maximumPoolSize, keepAliveTime, unit, workQueue);
        }

        @Override
        protected <T> RunnableFuture<T> newTaskFor(Runnable runnable, T value) {
            return new XFutureTask<T>(runnable, value);
        }
    }

    class XByteArrayMessage extends BaseMessage<byte[]> {

        XByteArrayMessage(DefaultEventBus bus, ServerID sender, String replyAddress) {
            super(true, "", new byte[1]);
            super.bus = bus;
            super.sender = sender;
            super.replyAddress = replyAddress;
        }

        protected XByteArrayMessage(boolean send, String address, byte[] body) {
            super(send, address, body);
        }

        @Override
        protected void readBody(int pos, Buffer readBuff) {
            boolean isNull = readBuff.getByte(pos) == (byte) 0;
            if (!isNull) {
                pos++;
                int buffLength = readBuff.getInt(pos);
                pos += 4;
                body = readBuff.getBytes(pos, pos + buffLength);
            }
        }

        @Override
        protected void writeBody(Buffer buff) {
            if (body == null) {
                buff.appendByte((byte) 0);
            } else {
                buff.appendByte((byte) 1);
                buff.appendInt(body.length);
                buff.appendBytes(body);
            }
        }

        @Override
        protected int getBodyLength() {
            return body == null ? 1 : 1 + 4 + body.length;
        }

        @Override
        protected Message<byte[]> copy() {
            byte[] bod;
            if (body != null) {
                bod = new byte[body.length];
                System.arraycopy(body, 0, bod, 0, bod.length);
            } else {
                bod = null;
            }
            XByteArrayMessage copied = new XByteArrayMessage(send, address, bod);
            copied.replyAddress = this.replyAddress;
            copied.bus = this.bus;
            copied.sender = this.sender;
            return copied;
        }

        @Override
        protected byte type() {
            return (byte) 3;
        }
    }

    class XSubscriber implements Handler<Message<Buffer>> {

        private final ExecutorService executor;

        public XSubscriber(ExecutorService executor) {
            this.executor = executor;
        }

        @Override
        public void handle(Message<Buffer> event) {
            try {
                Rpc.RpcMessage message = Rpc.RpcMessage.parseFrom(event.body().getBytes());
                executor.submit(() -> onMessage(message));
            } catch (InvalidProtocolBufferException e) {
                LOGGER.warn(e.getMessage(), e);
            }
        }

        void onMessage(Rpc.RpcMessage message) {
            AbstractListener listener = listeners.get(message.getPayloadClass());
            if (listener == null) {
                LOGGER.warn(String.format("failed to invoke listener[SERVICE_UNAVAILABLE], request: %s, session: %s", RpcMessageFormatter.format(message)));
                return;
            }
            // Parse & process
            try {
                com.google.protobuf.Message request = parser.parse(message);
                listener.onEvent(request);
            } catch (Exception e) {
                LOGGER.warn(String.format("failed to invoke listener[INVALID_PAYLOAD], request: %s, session: %s", RpcMessageFormatter.format(message)));
                return;
            }
        }
    }


    protected class XHandler implements Handler<Message<Buffer>> {

        private final ExecutorService executor;
        private final EventBus eventBus;

        public XHandler(ExecutorService executor, EventBus eventBus) {
            this.executor = executor;
            this.eventBus = eventBus;
        }

        @Override
        public void handle(Message<Buffer> event) {
            final Rpc.RpcMessage.Builder builder = Rpc.RpcMessage.newBuilder();
            try {
                Buffer data = event.body();
                byte idLength = data.getByte(data.length() - 1);
                final String sessionId = data.getString(data.length() - idLength - 1, data.length() - 1, "UTF-8");
                Rpc.RpcMessage message = Rpc.RpcMessage.parseFrom(data.getBytes(0, data.length() - idLength - 1));
                String replyAddress = message.hasReplyAddress() ? message.getReplyAddress() : event.replyAddress();
                executor.submit(new XRunnable(() -> doHandle(event, builder, sessionId, message), sessionId, replyAddress, message, event));
            } catch (InvalidProtocolBufferException e) {
                LOGGER.warn(e.getMessage(), e);
            }
        }

        private void doHandle(Message<Buffer> event, Rpc.RpcMessage.Builder builder, String sessionId, Rpc.RpcMessage message) {
            final long mark = System.nanoTime();
            com.google.protobuf.Message request = null;
            try {
                builder.setService(service).setVersion(message.getVersion());
                builder.setId(RemotingGenerator.getDefault().next()).setSourceId(message.getId()).setResult(Rpc.RpcMessage.Result.SUCCESS);

                if (!isCompatible(message.getVersion())) {
                    LOGGER.warn(String.format("failed to invoke service[SERVICE_UNAVAILABLE], request: %s, session: %s", RpcMessageFormatter.format(message), sessionId));
                    builder.setResult(Rpc.RpcMessage.Result.INVALID_VERSION);
                    return;
                }
                ScreenHandler handler = handlers.get(message.getPayloadClass());
                if (handler == null) {
                    LOGGER.warn(String.format("failed to invoke service[SERVICE_UNAVAILABLE], request: %s, session: %s", RpcMessageFormatter.format(message), sessionId));
                    builder.setResult(Rpc.RpcMessage.Result.SERVICE_UNAVAILABLE);
                    return;
                }

                handler.cleanIfNotMatch(sessionId);
                final String hospCode = handler.getHospitalCode(vertx, sessionId);
                String shardingGroup = RoutingDataSource.getFabricGroup(hospCode);
                //if(configuration.isVerbose())
                    //LOGGER.info(String.format("HOSP_CODE: %s, SHARD: %s, request: %s, modifiableRequest: %s, isMaintain: %s", hospCode == null ? "" : hospCode, shardingGroup == null ? "" : shardingGroup, message.getPayloadClass(), configuration.isModifiableRequest(message.getPayloadClass()), VertxContext.current().isMaintainance(shardingGroup)));
                //VertxContext.current().isMaintainance("ALL") --> This is apply for KCCK-API only
                if(isMaintenance(message.getPayloadClass(), hospCode, shardingGroup)) {
                    LOGGER.warn(String.format("failed to invoke service[MAINTAINANCE], request: %s, session: %s", RpcMessageFormatter.format(message), sessionId));
                    builder.setResult(Rpc.RpcMessage.Result.MAINTAINANCE);
                    return;
                }
                // Authenticate
                if (configuration.isLoginRequired() && !handler.isAuthorized(vertx, sessionId)) {
                    LOGGER.warn(String.format("failed to invoke service[NOT_AUTHENTICATED], request: %s, session: %s", RpcMessageFormatter.format(message), sessionId));
                    builder.setResult(Rpc.RpcMessage.Result.NOT_AUTHENTICATED);
                    return;
                }

                // Parse
                try {
                    request = parser.parse(message);
                } catch (Exception e) {
                    LOGGER.warn(String.format("failed to invoke service[INVALID_PAYLOAD], request: %s, session: %s", RpcMessageFormatter.format(message), sessionId));
                    builder.setResult(Rpc.RpcMessage.Result.INVALID_PAYLOAD);
                    return;
                }

                //validate
                if (!handler.isValid(request, vertx, message.getClientId(), sessionId)) {
                    LOGGER.warn(String.format("failed to invoke service[SERVICE_REJECTED], request: %s, session: %s", RpcMessageFormatter.format(message), sessionId));
                    builder.setResult(Rpc.RpcMessage.Result.SERVICE_REJECTED);
                    return;
                }


                DbContext.SHARD_CONTEXT.set(() -> {
//                    if(handler instanceof OUT0101U02SaveGridHandler || handler instanceof UpdateJubsuDataHandler){
//                        return hospCodes[(int)(round.incrementAndGet() % hospCodes.length)];
//                    }

                    return handler.getHospitalCode(vertx, sessionId);
                    //return hospCode;
                });
                //Handle
                com.google.protobuf.Message response;
                if (!configuration.isShardable()) {
                    response = handler.doInTransaction(vertx, message.getClientId(), sessionId, message.getContextId(), parser.parse(message));
                } else {
                    handler.preHandle(vertx, message.getClientId(), sessionId, message.getContextId(), parser.parse(message));
                    Tuple<Boolean, Collection<String>> shardable = handler.isShardable(parser.parse(message), vertx, message.getClientId(), sessionId);
                    if(shardable == null || !shardable.getV1()) {
                        response = handler.handle(vertx, message.getClientId(), sessionId, message.getContextId(), parser.parse(message));
                    } else {
                        List<com.google.protobuf.Message> responses = new ArrayList<>();
                        for (String hc : shardable.getV2()) {
                            //language isn't require for this case due to it is used only for routing between shards
                            handler.setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(hc, "JA", "", 1, ""));
                            responses.add(handler.handle(vertx, message.getClientId(), sessionId, message.getContextId(), parser.parse(message)));
                        }
                        response = handler.mergeShards(responses);
                    }
                    response = handler.postHandle(vertx, message.getClientId(), sessionId, message.getContextId(), parser.parse(message), response);
                }
                builder.setResult(Rpc.RpcMessage.Result.SUCCESS);
                if (response != null) {
                    MonitorLog.TOTAL_MESSAGE.addAndGet(1);
                    if (configuration.isCompressible()) {
                        byte[] payload = response.toByteArray();
                        Long lengthPayLoad = Long.valueOf(payload.length);
                        MonitorLog.TOTAL_BYTES_BEFORE_COMPRESS.addAndGet(lengthPayLoad);
                        if (payload.length > configuration.getCompressThreshold()) {
                            try {
                                payload = compressor.compress(payload);
                                builder.setCompress(true);
                                MonitorLog.TOTAL_MESSAGE_COMPRESSED.addAndGet(1);
                                MonitorLog.TOTAL_BYTES_REDUCE_AFTER_COMPRESSED.addAndGet(lengthPayLoad - payload.length);
                            } catch (Exception e) {
                                LOGGER.warn("failed to compress payload");
                            }

                        }

                        builder.setPayloadData(ByteString.copyFrom(payload));
                    } else {
                        builder.setPayloadData(response.toByteString());
                        MonitorLog.TOTAL_BYTES_BEFORE_COMPRESS.addAndGet(response.toByteArray().length);
                    }
                    builder.setPayloadClass(response.getDescriptorForType().getName());
                }

                final long time = System.nanoTime() - mark;
                if (configuration.isVerbose()) {
                    LOGGER.info(String.format("invoked handler, request: %s, response: %s, session: %s, elapsed time: %s ms", request == null ? null : RpcMessageFormatter.format(request), response == null ? null : RpcMessageFormatter.format(response), sessionId, TimeUnit.MILLISECONDS.convert(time, TimeUnit.NANOSECONDS)));
                } else {
                    LOGGER.info(String.format("invoked handler, request: %s, session: %s, elapsed time: %s ms", message.getPayloadClass(), sessionId, TimeUnit.MILLISECONDS.convert(time, TimeUnit.NANOSECONDS)));
                }
            } catch (nta.med.core.common.exception.ExecutionException e) {
                final long time = System.nanoTime() - mark; //RpcMessage.Result is still SUCCESS because the message is actively returned by developer
                if (e.getCookie() != null) {
                    builder.setPayloadData(e.getCookie().toByteString());
                    builder.setPayloadClass(e.getCookie().getDescriptorForType().getName());
                }
                LOGGER.warn("failed to invoke service, request: " + (request == null ? null : RpcMessageFormatter.format(request)) + ", session: " + sessionId + ", elapsed time: " + TimeUnit.MILLISECONDS.convert(time, TimeUnit.NANOSECONDS) + " ms, cookie: " + RpcMessageFormatter.format(e.getCookie()), e);
            } catch (JpaSystemException e) {
                final long time = System.nanoTime() - mark;
                builder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);
                LOGGER.warn("timeout to invoke service[TIMEOUT_ERROR or INTERNAL_ERROR], request: " + (request == null ? null : RpcMessageFormatter.format(request)) + ", session: " + sessionId + ", elapsed time: " + TimeUnit.MILLISECONDS.convert(time, TimeUnit.NANOSECONDS) + " ms", e);
            } catch (RuntimeException e) {
                final long time = System.nanoTime() - mark;
                builder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);
                LOGGER.warn("failed to invoke service, request: " + (request == null ? null : RpcMessageFormatter.format(request)) + ", session: " + sessionId + ", elapsed time: " + TimeUnit.MILLISECONDS.convert(time, TimeUnit.NANOSECONDS) + " ms", e);
            } catch (Exception e) {
                final long time = System.nanoTime() - mark;
                builder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);
                LOGGER.error("failed to invoke service[INTERNAL_ERROR], request: " + (request == null ? null : RpcMessageFormatter.format(request)) + ", session: " + sessionId + ", elapsed time: " + TimeUnit.MILLISECONDS.convert(time, TimeUnit.NANOSECONDS) + " ms", e);
            } finally {
                DbContext.SHARD_CONTEXT.remove();
                if (message.hasReplyAddress() && message.hasReplyHost() && message.hasReplyPort()) {
                    System.out.println("ReplyAddress: " + message.getReplyAddress() + ", ReplyHost: " + message.getReplyHost() + ", ReplyPort: " + message.getReplyPort());
                    XByteArrayMessage xMsg = new XByteArrayMessage((DefaultEventBus) eventBus, new ServerID(message.getReplyPort(), message.getReplyHost()), message.getReplyAddress());
                    xMsg.reply(builder.build().toByteArray());
                } else {
                    event.reply(builder.build().toByteArray());
                }
            }
        }
    }

    public boolean isMaintenance(String request, String hospCode, String shardingGroup) {
        return (!Strings.isEmpty(hospCode) && !Strings.isEmpty(shardingGroup) && VertxContext.current().isMaintainance(shardingGroup) && configuration.isModifiableRequest(request));
    }
}
