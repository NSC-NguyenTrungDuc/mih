package nta.med.service.caching;

import com.google.common.base.Supplier;
import nta.med.common.glossary.Lifecyclet;
import nta.med.core.caching.cache.HashCache;
import nta.med.core.caching.glossary.StorageStrategy;
import nta.med.core.caching.model.medi.drgs.InformationSchemaColumn;
import nta.med.core.caching.cache.impl.HashCacheImpl;
import nta.med.core.config.Configuration;
import nta.med.data.dao.medi.ifs.Ifs7101Repository;
import org.apache.commons.collections.CollectionUtils;
import org.springframework.beans.factory.annotation.Autowired;

import javax.annotation.Resource;
import java.io.Serializable;
import java.util.*;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;
import java.util.concurrent.TimeUnit;

/**
 * @author dainguyen.
 */
public class CacheService extends Lifecyclet {
	
	@Autowired
    private Configuration configuration;
	
	@Resource
	private Ifs7101Repository ifs7101Repository;

    private static final ConcurrentMap<String, Object> CACHE = new ConcurrentHashMap<>();
    
    private static Object lock = new Object();
    
    @SuppressWarnings("unchecked")
	public synchronized static <T> T putIfAbsent(String key, Supplier<T> supplier){
    	if(!CACHE.containsKey(key)){  
    		if(supplier.get() != null)
    		CACHE.putIfAbsent(key, supplier.get());
    		return (T)CACHE.get(key);
    	}
    	return (T)CACHE.get(key);
    }
	
    private OnceInitializedCache<SchemaHashCache, InformationSchemaColumn> schemaCache;

    public OnceInitializedCache<SchemaHashCache, InformationSchemaColumn> getSchemaCache() {
        return schemaCache;
    }

    @Override
    protected void doStart() throws Exception {
        this.schemaCache = new OnceInitializedCache<>(() -> {
            Map<String, Map<String, InformationSchemaColumn>> result = new HashMap<>();
            List<InformationSchemaColumn> rawData = ifs7101Repository.getInformationSchemaColumn(configuration.getSchema());
            if (!CollectionUtils.isEmpty(rawData)) {
                for (InformationSchemaColumn item : rawData) {
                    String key = String.format("%s:%s", item.getTableSchema(), item.getTableName());
                    if (!result.containsKey(key)) {
                        result.put(key, new HashMap<>());
                    }
                    result.get(key).put(item.getColumnName(), item);
                }
            }

            return result;
        }, () -> new SchemaHashCache());
    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        return timeout;
    }

    public CacheService() {
    }

    public class SchemaHashCache extends HashCacheImpl<InformationSchemaColumn>{

        public SchemaHashCache() {
            super(InformationSchemaColumn.class);
        }

        @Override
        protected StorageStrategy getStorageStrategy() {
            return StorageStrategy.JACKSON2;
        }
    }

    public class OnceInitializedCache<T extends HashCache<String, HV>, HV extends Serializable>{
    	public boolean initialized = false;
    	public Supplier<Map<String, Map<String, HV>>> supplier;
    	public Supplier<HashCache<String, HV>> cacheSupplier;
    	public HashCache<String, HV> cache;

        public OnceInitializedCache(Supplier<Map<String, Map<String, HV>>> supplier, Supplier<HashCache<String, HV>> cacheSupplier) {
            this.supplier = supplier;
            this.cacheSupplier = cacheSupplier;
        }

        public boolean contains(String key, String field){
            ensureInitialized();
            return cache.contains(key, field);
        }

        public long size(String key){
            ensureInitialized();
            return cache.size(key);
        }

        public Map<String, HV> findAll(String key) {
        	ensureInitialized();
            return cache.findAll(key);
        }

        public List<HV> findByField(String key, Collection<String> fields) {
            ensureInitialized();
            return cache.findByField(key, fields);
        }

        public HV findByField(String key, String field) {
            ensureInitialized();
            return cache.findByField(key, field);
        }

        public Set<String> fields(String key) {
            ensureInitialized();
            return cache.fields(key);
        }

        public List<HV> values(String key) {
            ensureInitialized();
            return cache.values(key);
        }

        private synchronized void ensureInitialized() {
            if(!initialized){
                Map<String, Map<String, HV>> data = supplier.get();
                if(cache == null) cache = cacheSupplier.get();
                for(Map.Entry<String, Map<String, HV>> entry : data.entrySet()){
                    cache.putAll(entry.getKey(), entry.getValue());
                }
                initialized = true;
            }
        }
    }
}
