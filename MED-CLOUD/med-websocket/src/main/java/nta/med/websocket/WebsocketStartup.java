package nta.med.websocket;

import nta.med.core.infrastructure.socket.hazelcast.HazelcastManager;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.vertx.java.core.AsyncResult;
import org.vertx.java.core.Handler;
import org.vertx.java.core.json.JsonObject;
import org.vertx.java.platform.PlatformLocator;
import org.vertx.java.platform.PlatformManager;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.util.Properties;

/**
 * @author dainguyen
 */
public class WebsocketStartup {

    private static final Log LOGGER = LogFactory.getLog(WebsocketStartup.class);

    private static Properties properties = new Properties();

    static {
        InputStream is = null;
        try {
            String configPath = System.getProperty("configPath");
            File file = new File( (configPath == null ? "" : configPath + "/") + "configs.properties" );
            is = new FileInputStream( file );
            properties.load(is);
        } catch (Exception ignore) {
            LOGGER.error(ignore.getMessage(), ignore);
        } finally {
            if (is != null) {
                try {
                    is.close();
                } catch (IOException e) {
                    LOGGER.error(e.getMessage(), e);
                }
            }
        }
    }

    public static String getConfigProperty(String name, String defaultValue){
        return properties.getProperty(name, defaultValue);
    }

    public static void main(String[] args) {

        String clusterHost = getConfigProperty("vertx.clusterHost", "127.0.0.1");
        Integer clusterPort = Integer.parseInt(getConfigProperty("vertx.clusterPort", "8090"));
        Integer instances = Integer.parseInt(getConfigProperty("vertx.instances", "1"));

        PlatformManager pm = PlatformLocator.factory.createPlatformManager(clusterPort, clusterHost);
        JsonObject config = new JsonObject();
        URL[] classpath = {};
        pm.deployVerticle("nta.med.websocket.MedicalVerticle", config, classpath, instances, null, new Handler<AsyncResult<String>>() {
            @Override
            public void handle(AsyncResult<String> stringAsyncResult) {
                if (stringAsyncResult.succeeded()) {
                    LOGGER.info("Completed deployment of MedicalVerticle");
                    HazelcastManager hm = new HazelcastManager();
                    hm.start();
                } else {
                    LOGGER.info(String.format("Failed deployment of MedicalVerticle with result ", stringAsyncResult.result()));
                }
            }
        });
    }
}
