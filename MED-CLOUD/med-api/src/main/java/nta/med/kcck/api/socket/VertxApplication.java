package nta.med.kcck.api.socket;

import nta.med.common.glossary.Lifecyclet;
import nta.med.kcck.api.socket.vertx.NuroVerticle;
import nta.med.kcck.api.socket.vertx.OcsoVerticle;
import nta.med.kcck.api.socket.vertx.SystemVerticle;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.vertx.java.core.AsyncResult;
import org.vertx.java.core.Handler;
import org.vertx.java.core.json.JsonObject;
import org.vertx.java.platform.PlatformLocator;
import org.vertx.java.platform.PlatformManager;
import org.vertx.java.platform.Verticle;

import java.net.URL;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

/**
 * @author dainguyen.
 */
public class VertxApplication extends Lifecyclet {

    private static final Log LOGGER = LogFactory.getLog(VertxApplication.class);

    private final Integer vertxClusterPort;
    private final String vertxClusterHost;
    private final boolean vertxWorker;
    private final Integer vertxInstances;
    private final boolean exitOnFailDeployment;
    private PlatformManager pm;

    public VertxApplication(Integer vertxClusterPort, String vertxClusterHost, boolean vertxWorker, Integer vertxInstances, boolean exitOnFailDeployment) {
        this.vertxClusterPort = vertxClusterPort;
        this.vertxClusterHost = vertxClusterHost;
        this.vertxWorker = vertxWorker;
        this.vertxInstances = vertxInstances;
        this.exitOnFailDeployment = exitOnFailDeployment;
    }

    @Override
    protected void doStart() throws Exception {
        pm = PlatformLocator.factory.createPlatformManager(vertxClusterPort, vertxClusterHost);
        JsonObject config = new JsonObject();
        URL[] classpath = {};
        List<Class<? extends Verticle>> allVerticle = Arrays.asList(OcsoVerticle.class, NuroVerticle.class, SystemVerticle.class);
        for (final Class<? extends Verticle> verticle : allVerticle) {
            Handler<AsyncResult<String>> doneHandler = event -> {
                if (event.succeeded()) {
                    LOGGER.info("Completed deployment of " + verticle.getSimpleName());
                } else {
                    LOGGER.info(String.format("Deployment of %s was failed. Result = %s", verticle.getSimpleName(), event.result()));
                    if(exitOnFailDeployment) {
                        LOGGER.warn(String.format("Due to fail deployment of %s so system will exit now. Kindly restart the service again or set exitOnFailDeployment = false", verticle.getSimpleName()));
                        System.exit(1);
                    }
                }
            };
            if (vertxWorker) {
                pm.deployWorkerVerticle(false, verticle.getName(), config, classpath, vertxInstances, null, doneHandler);
            } else {
                pm.deployVerticle(verticle.getName(), config, classpath, vertxInstances, null, doneHandler);
            }
        }
    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        try{
            CountDownLatch latch = new CountDownLatch(1);
            pm.undeployAll(event -> {
                System.out.println("UN-DEPLOY SUCCEEDED: " + event.succeeded());
                latch.countDown();
            });
            latch.await();
        } finally {
            pm.stop();
        }
        return timeout;
    }
}
