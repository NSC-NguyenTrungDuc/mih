package nta.med.core.infrastructure;

import nta.med.core.domain.fabric.FabricSharding;
import nta.med.core.infrastructure.context.DbContext;
import org.apache.commons.dbcp.BasicDataSource;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.jdbc.datasource.lookup.AbstractRoutingDataSource;

import javax.sql.DataSource;
import java.util.*;
import java.util.concurrent.*;
import java.util.function.Function;
import java.util.function.Supplier;

/**
 * @author dainguyen.
 */
public class RoutingDataSource extends AbstractRoutingDataSource {

    private DataSource defaultFabricDataSource;
    private BasicDataSource templateFabricDataSource;

    private Map<Object, Object> targetDataSources;

    private static final ConcurrentMap<Object, Integer> shardMapping = new ConcurrentHashMap<>();
    private static final ScheduledExecutorService service = Executors.newSingleThreadScheduledExecutor();
    private static final List<Integer> shards = new ArrayList<>();
    private static final Log LOGGER = LogFactory.getLog(RoutingDataSource.class);
    private static Function<String, Integer> hospSysGetter;
    private static List<FabricSharding> fabricShards = new ArrayList();
    private static boolean initialized = false;

    public RoutingDataSource() {

    }

    public static void initRoutingMeta(Function<String, Integer> hospSysGetter1, Supplier<Map<String, Integer>> shardingProvider, List<Integer> lowerBoundShards, List<FabricSharding> fabricSharding, Long refreshTime, TimeUnit unit) {
        service.scheduleAtFixedRate(() -> {
            Map<String, Integer> routingMap = shardingProvider.get();
            for (Map.Entry<String, Integer> entry : routingMap.entrySet()) {
                shardMapping.putIfAbsent(entry.getKey(), entry.getValue());
            }
        }, 0, refreshTime, unit);
        Collections.sort(lowerBoundShards);
        shards.addAll(lowerBoundShards);
        hospSysGetter = hospSysGetter1;
        fabricShards = fabricSharding;
        initialized = true;
    }

    public static Collection<String> getRepresentativeShards() {
        Map<Integer, String> r = new HashMap<>();

        for(Map.Entry<Object, Integer> entry : shardMapping.entrySet()) {
            Integer lowerBound = getLowerBoundShard(entry.getValue());
            r.put(lowerBound, entry.getKey().toString());
        }

        return r.values();
    }

    private static Integer getLowerBoundShard(Integer key) {
        for (int i = shards.size() - 1; i >= 0; i--) {
            if (key >= shards.get(i)) return shards.get(i);
        }
        return key;
    }

    @Override
    protected Object determineCurrentLookupKey() {
        return DbContext.getShardingKey();
    }

    private static Integer getShardingKey(Object lookupKey) {    	
        if (shardMapping.get(lookupKey) == null) {
            LOGGER.warn("shardMapping.get(lookupKey) is null");
            Integer hospSysId = hospSysGetter.apply(lookupKey.toString());
            LOGGER.warn("shardMapping.get(lookupKey) hospSysId " + hospSysId);
            if (hospSysId != null) {
                shardMapping.putIfAbsent(lookupKey, hospSysId);
            }
        }

        return getLowerBoundShard(shardMapping.get(lookupKey));
    }

    @Override
    protected DataSource determineTargetDataSource() {
        Object lookupKey = determineCurrentLookupKey();
        LOGGER.info("lookupKey: " + lookupKey);
        if (lookupKey == null) return defaultFabricDataSource;

        Integer shardingKey = getShardingKey(lookupKey);
        LOGGER.info("shardingKey:" + shardingKey);
        BasicDataSource dataSource = (BasicDataSource) this.targetDataSources.get(shardingKey);
        if (dataSource == null) {
            BasicDataSource ds = new BasicDataSource();
            ds.setDriverClassName(templateFabricDataSource.getDriverClassName());
            ds.setUrl(templateFabricDataSource.getUrl() + "&fabricShardKey=" + shardingKey);
            ds.setUsername(templateFabricDataSource.getUsername());
            ds.setPassword(templateFabricDataSource.getPassword());
            ds.setMaxActive(templateFabricDataSource.getMaxActive());
            ds.setMaxIdle(templateFabricDataSource.getMaxIdle());
            ds.setTestOnBorrow(templateFabricDataSource.getTestOnBorrow());
            ds.setTestOnReturn(templateFabricDataSource.getTestOnReturn());
            ds.setValidationQuery(templateFabricDataSource.getValidationQuery());
            ds.setMinEvictableIdleTimeMillis(templateFabricDataSource.getMinEvictableIdleTimeMillis());
            ds.setTimeBetweenEvictionRunsMillis(templateFabricDataSource.getTimeBetweenEvictionRunsMillis());
            ds.setRemoveAbandoned(templateFabricDataSource.getRemoveAbandoned());
            targetDataSources.put(shardingKey, ds);
            return ds;
        }
        return dataSource;
    }

    public void setDefaultFabricDataSource(DataSource defaultFabricDataSource) {
        this.defaultFabricDataSource = defaultFabricDataSource;
    }

    @Override
    public void setTargetDataSources(Map<Object, Object> targetDataSources) {
        super.setTargetDataSources(targetDataSources);
        this.targetDataSources = targetDataSources;
    }

    public void setTemplateFabricDataSource(BasicDataSource templateFabricDataSource) {
        this.templateFabricDataSource = templateFabricDataSource;
    }

    public static String getFabricGroup(String hospCode) {
    	if(!initialized) return null;
        Integer shardingKey = getShardingKey(hospCode);
        if(shardingKey != null) {
            for (FabricSharding fs : fabricShards) {
                if(fs.getHospMin() == shardingKey) return fs.getHospGroupCD();
            }
        }
        return null;
    }
}
