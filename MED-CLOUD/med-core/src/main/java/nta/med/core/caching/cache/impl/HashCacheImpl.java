package nta.med.core.caching.cache.impl;

import nta.med.core.caching.cache.HashCache;
import nta.med.core.caching.glossary.StorageStrategy;
import nta.med.core.infrastructure.SpringBeanFactory;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.data.redis.core.HashOperations;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.data.redis.serializer.Jackson2JsonRedisSerializer;
import org.springframework.data.redis.serializer.JacksonJsonRedisSerializer;
import org.springframework.data.redis.serializer.JdkSerializationRedisSerializer;
import org.springframework.data.redis.serializer.RedisSerializer;

import java.io.Serializable;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 * @author dainguyen.
 */
public abstract class HashCacheImpl<HV extends Serializable> implements HashCache<String, HV> {
    private static Log LOGGER = LogFactory.getLog(HashCacheImpl.class);

    private final StorageStrategy storageStrategy;

    private final Class<HV> type;

    protected final RedisTemplate<String, HV> redisTemplate;

    protected abstract StorageStrategy getStorageStrategy();

    public HashCacheImpl(Class<HV> type) {
        this.type = type;
        this.redisTemplate = (RedisTemplate<String, HV>) SpringBeanFactory.beanFactory.getBean("redisTemplate");
        this.storageStrategy = getStorageStrategy() == null ? StorageStrategy.JACKSON2 : getStorageStrategy();
        RedisSerializer<?> defaultSerializer;
        switch (this.storageStrategy){
            case JACKSON:
                defaultSerializer = new JacksonJsonRedisSerializer<HV>(this.type);
                break;
            case JACKSON2:
                defaultSerializer = new Jackson2JsonRedisSerializer<HV>(this.type);
                break;
            default:
                defaultSerializer = new JdkSerializationRedisSerializer();
                break;
        }
        this.redisTemplate.setValueSerializer(defaultSerializer);
    }

    @Override
    public void put(String key, String field, HV value) {
        LOGGER.debug(String.format("Putting %s to key %s with information: %s", field, key, value));
        redisTemplate.opsForHash().put(key, field, value);
        LOGGER.debug(String.format("Finished putting %s to key %s with information: %s", field, key, value));
    }

    @Override
    public void putAll(String key, Map<String, HV> map) {
        LOGGER.debug(String.format("Putting %s elements to key %s", map.size(), key));
        HashOperations<String, String, HV> operations = redisTemplate.opsForHash();
        operations.putAll(key, map);
        LOGGER.debug(String.format("Finished putting %s elements to key %s", map.size(), key));
    }

    @Override
    public boolean putIfAbsent(String key, String field, HV value) {
        return redisTemplate.opsForHash().putIfAbsent(key, field, value);
    }

    @Override
    public long size(String key) {
        return redisTemplate.opsForHash().size(key);
    }

    @Override
    public void delete(String key, String... fields) {
        redisTemplate.opsForHash().delete(key, fields);
    }

    @Override
    public boolean contains(String key, String field) {
        return redisTemplate.opsForHash().hasKey(key, field);
    }

    @Override
    public Map<String, HV> findAll(String key) {
        HashOperations<String, String, HV> operations = redisTemplate.opsForHash();
        return operations.entries(key);
    }

    @Override
    public List<HV> findByField(String key, Collection<String> fields) {
        HashOperations<String, String, HV> operations = redisTemplate.opsForHash();
        return operations.multiGet(key, fields);
    }

    @Override
    public HV findByField(String key, String field) {
        HashOperations<String, String, HV> operations = redisTemplate.opsForHash();
        return operations.get(key, field);
    }

    @Override
    public Set<String> fields(String key) {
        HashOperations<String, String, HV> operations = redisTemplate.opsForHash();
        return operations.keys(key);
    }

    @Override
    public List<HV> values(String key) {
        HashOperations<String, String, HV> operations = redisTemplate.opsForHash();
        return operations.values(key);
    }
}
