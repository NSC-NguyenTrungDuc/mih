package nta.med.core.infrastructure.socket.vertx;

import nta.med.common.util.concurrent.PaddedAtomicLong;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.eventbus.EventBus;
import org.vertx.java.core.impl.VertxInternal;
import org.vertx.java.core.spi.cluster.ClusterManager;
import org.vertx.java.platform.Verticle;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;

/**
 * @author dainguyen.
 */
public final class VertxContext {

    public static final VertxContext current() {
        return INSTANCE;
    }

    private volatile ConcurrentMap<String, Boolean> maintainanceSetting = new ConcurrentHashMap<>();

    private static final VertxContext INSTANCE = new VertxContext();
    private final PaddedAtomicLong sequence = new PaddedAtomicLong(1);

    private List<AbstractVerticle> verticles = new ArrayList<>();

    public boolean add(AbstractVerticle verticle) {
        return verticles.add(verticle);
    }

    public ClusterManager clusterManager() {
        return ((VertxInternal)vertx()).clusterManager();
    }

    public boolean remove(AbstractVerticle verticle) {
        return verticles.remove(verticle);
    }

    public void unregisterQuietly() {
        verticles.forEach(AbstractVerticle::unregisterHandler);
    }

    public EventBus eventBus() {
        if (verticles.size() == 0) throw new RuntimeException("failed to invoke eventBus");
        Verticle vertx;
        while (verticles.size() > 0) {
            vertx = verticles.get((int) (sequence.getAndIncrement() % verticles.size()));
            if (vertx != null && vertx.getVertx() != null && vertx.getVertx().eventBus() != null)
                return vertx.getVertx().eventBus();
            verticles.remove(vertx);
        }
        throw new RuntimeException("failed to invoke eventBus");
    }

    public Vertx vertx() {
        Verticle vertx;
        while (verticles.size() > 0) {
            vertx = verticles.get((int) (sequence.getAndIncrement() % verticles.size()));
            if (vertx != null && vertx.getVertx() != null && vertx.getVertx().eventBus() != null)
                return vertx.getVertx();
            verticles.remove(vertx);
        }
        throw new RuntimeException("failed to invoke eventBus");
    }

    public void maintainance(String group, boolean maintain) {
        maintainanceSetting.put(group, maintain);
    }

    public boolean isMaintainance(String group) {
        return maintainanceSetting.containsKey(group) ? maintainanceSetting.get(group) : false;
    }

}
