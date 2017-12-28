package nta.med.kcck.api.socket.vertx;

import com.google.protobuf.Descriptors;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.socket.vertx.VertxContext;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.vertx.java.core.impl.VertxInternal;
import org.vertx.java.core.net.impl.ServerID;
import org.vertx.java.core.spi.cluster.AsyncMultiMap;
import org.vertx.java.core.spi.cluster.ClusterManager;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;

/**
 * @author dainguyen.
 */
public abstract class ApiVerticle extends AbstractVerticle {

    private final ScheduledExecutorService service = Executors.newSingleThreadScheduledExecutor();

    private static final Log LOGGER = LogFactory.getLog(SystemVerticle.class);

    public ApiVerticle(Class<?> clazz, Descriptors.FileDescriptor descriptor) {
        super(clazz, descriptor);
    }

    abstract boolean isNodeBasedHandle();

    @Override
    public boolean isMaintenance(String request, String hospCode, String shardingGroup) {
        return VertxContext.current().isMaintainance("ALL") || super.isMaintenance(request, hospCode, shardingGroup);
    }

    @Override
    protected void registerHandler(String handlerName, ScreenHandler handler) {
        super.registerHandler(handlerName, handler);
        if(isNodeBasedHandle()) {
            final String address = String.format("%s-%s", handlerName, ((VertxInternal)vertx).clusterManager().getNodeID());
            registerHandler(address);
            service.scheduleAtFixedRate(() -> {
                ClusterManager clusterMgr = ((VertxInternal) vertx).clusterManager();
                AsyncMultiMap<String, ServerID> subs = clusterMgr.getAsyncMultiMap("subs");
                subs.get(address, event -> {
                    if(event.failed() || event.result().isEmpty()) {
                        registerHandler(address);
                    }
                });
            }, 10, 60, TimeUnit.SECONDS);
        }
    }

    private void registerHandler(String address) {
        if(xhandler == null) xhandler = new XHandler(vertxExecutor, vertx.eventBus());
        vertx.eventBus().registerHandler(address, xhandler, event -> {
            if (event.succeeded()) {
                LOGGER.info(String.format("lifecyclet: %s was successfully registered.", address));
            } else {
                LOGGER.error(String.format("lifecyclet: registering %s was failed.", address), event.cause());
            }
        });
    }
}
