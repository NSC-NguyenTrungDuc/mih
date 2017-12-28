package nta.med.app.startup;

import nta.med.app.vertx.emr.EmrVerticle;
import nta.med.app.vertx.ihis.*;
import nta.med.app.vertx.orca.OrcaVerticle;
import nta.med.core.config.Configuration;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.fabric.FabricGroup;
import nta.med.core.domain.fabric.FabricSharding;
import nta.med.core.glossary.MonitorKey;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.RoutingDataSource;
import nta.med.core.infrastructure.context.DbContext;
import nta.med.core.infrastructure.socket.hazelcast.HazelcastManager;
import nta.med.core.infrastructure.socket.vertx.VertxContext;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.fabric.FabricGroupRepository;
import nta.med.data.dao.medi.fabric.FabricShardingRepository;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.vertx.java.core.AsyncResult;
import org.vertx.java.core.Handler;
import org.vertx.java.core.json.JsonObject;
import org.vertx.java.platform.PlatformLocator;
import org.vertx.java.platform.PlatformManager;
import org.vertx.java.platform.Verticle;

import java.net.URL;
import java.util.*;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;

/**
 * @author dainguyen
 */
public class ApplicationStartup {

    private static final Log LOGGER = LogFactory.getLog(ApplicationStartup.class);

    public static void main(String[] args) throws InterruptedException {
        ClassPathXmlApplicationContext springContext = new ClassPathXmlApplicationContext(new String[]{"META-INF/spring/spring-master-app.xml"});
        springContext.registerShutdownHook();
        Configuration configuration = springContext.getBean(Configuration.class);
        Bas0001Repository bas0001Repository = springContext.getBean(Bas0001Repository.class);
        FabricShardingRepository fabricShardingRepository = springContext.getBean(FabricShardingRepository.class);
        FabricGroupRepository fabricGroupRepository = springContext.getBean(FabricGroupRepository.class);
        List<Integer> lowerBound = new ArrayList<>();

        List<FabricSharding> fabricSharding = fabricShardingRepository.findAll();
        for (FabricSharding sharding : fabricSharding) {
            lowerBound.add(sharding.getHospMin());
        }

        List<FabricGroup> fabricGroups = fabricGroupRepository.findAll();
        for(FabricGroup fg : fabricGroups) VertxContext.current().maintainance(fg.getHospGroupCd(), fg.getMaintenanceMode() == null ? false : fg.getMaintenanceMode().intValue() != 0);

        RoutingDataSource.initRoutingMeta(s -> {

            String currentLookupKey = DbContext.getShardingKey();
            DbContext.clear();
            List<Bas0001> hospitals = bas0001Repository.findByHospCode(s);
            if (!StringUtils.isEmpty(currentLookupKey)) DbContext.setShardingKey(currentLookupKey);

            return (hospitals == null || hospitals.size() == 0) ? null : hospitals.get(0).getHospSysId();


        }, () -> {

            Map<String, Integer> result = new HashMap<String, Integer>();
            for (Bas0001 item : bas0001Repository.findAll()) {
                result.put(item.getHospCode(), item.getHospSysId());
            }
            return result;
        }, lowerBound, fabricSharding, 15L, TimeUnit.MINUTES);
        PlatformManager pm = PlatformLocator.factory.createPlatformManager(configuration.getVertxClusterPort(), configuration.getVertxClusterHost());

        JsonObject config = new JsonObject();
        URL[] classpath = {};
        List<Class<? extends Verticle>> allVerticle = Arrays.asList(NuroVerticle.class, SystemVerticle.class, InjsVerticle.class, NuriVerticle.class, OcsoVerticle.class,
                SchsVerticle.class, OcsaVerticle.class, DrgsVerticle.class, DrugVerticle.class, CplsVerticle.class, XrtsVerticle.class, BassVerticle.class, ChtsVerticle.class, EmrVerticle.class,
                PfesVerticle.class, AdmaVerticle.class, NutsVerticle.class, PhysVerticle.class, EndoVerticle.class, ClisVerticle.class, OrcaVerticle.class, BillVerticle.class, InvsVerticle.class, 
                InpsVerticle.class, OcsiVerticle.class);
        for (final Class<? extends Verticle> verticle : allVerticle) {
            Handler<AsyncResult<String>> doneHandler = event -> {
                if (event.succeeded()) {
                    LOGGER.info("Completed deployment of " + verticle.getSimpleName());
                } else {
                    LOGGER.info(String.format("Deployment of %s was failed. Result = %s", verticle.getSimpleName(), event.result()));
                    if(configuration.isExitOnFailDeployment()) {
                        LOGGER.warn(String.format("Due to fail deployment of %s so system will exit now. Kindly restart the service again or set exitOnFailDeployment = false", verticle.getSimpleName()));
                        System.exit(1);
                    }
                }
            };
            if (configuration.isVertxWorker()) {
                pm.deployWorkerVerticle(false, verticle.getName(), config, classpath, configuration.getVertxInstances(), null, doneHandler);
            } else {
                pm.deployVerticle(verticle.getName(), config, classpath, configuration.getVertxInstances(), null, doneHandler);
            }
        }

        springContext.getBean(HazelcastManager.class).start();
        //springContext.getBean(OUT0101U02SaveGridHandler.class).start();

        ScheduledExecutorService service = Executors.newSingleThreadScheduledExecutor();
        Runnable actionSchedule = () -> {
            MonitorLog.writeMonitorLog(MonitorKey.COMPRESS_TOTAL_MESSAGE, MonitorLog.TOTAL_MESSAGE.toString());
            MonitorLog.writeMonitorLog(MonitorKey.COMPRESS_TOTAL_MESSAGE_COMPRESSED, MonitorLog.TOTAL_MESSAGE_COMPRESSED.toString());
            MonitorLog.writeMonitorLog(MonitorKey.COMPRESS_TOTAL_BYTES_BEFORE_COMPRESS, MonitorLog.TOTAL_BYTES_BEFORE_COMPRESS.toString());
            MonitorLog.writeMonitorLog(MonitorKey.COMPRESS_TOTAL_BYTES_REDUCE_AFTER_COMPRESSED, MonitorLog.TOTAL_BYTES_REDUCE_AFTER_COMPRESSED.toString());
        };

        service.scheduleWithFixedDelay(actionSchedule, new Long(1), 15, TimeUnit.MINUTES);

        Runtime.getRuntime().addShutdownHook(new Thread(() -> {
            System.out.println("STOPPING .......");
            try {
                CountDownLatch latch = new CountDownLatch(1);
                VertxContext.current().unregisterQuietly();
                pm.undeployAll(event -> {
                    System.out.println("UN-DEPLOY SUCCEEDED: " + event.succeeded());
                    latch.countDown();
                });
                latch.await();
            } catch (InterruptedException e) {
                System.out.println(e.getMessage());
                System.out.println(e.getStackTrace());
            } finally {
                pm.stop();
                springContext.close();
            }
        }));
        System.out.println("SYSTEM is ready now.");
    }
}
