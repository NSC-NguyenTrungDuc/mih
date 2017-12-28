package nta.med.core.caching.cache.impl;

import com.google.common.base.Function;
import nta.med.core.caching.exception.NotFoundException;
import nta.med.core.caching.glossary.LockingStrategy;
import nta.med.core.caching.glossary.StorageStrategy;
import nta.med.core.infrastructure.SpringBeanFactory;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.dao.DataAccessException;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageImpl;
import org.springframework.data.domain.Pageable;
import org.springframework.data.redis.core.*;
import org.springframework.data.redis.serializer.Jackson2JsonRedisSerializer;
import org.springframework.data.redis.serializer.JacksonJsonRedisSerializer;
import org.springframework.data.redis.serializer.JdkSerializationRedisSerializer;
import org.springframework.data.redis.serializer.RedisSerializer;

import java.io.Serializable;
import java.util.*;
import java.util.function.BiFunction;

/**
 * The type default crud generic cache impl.
 * @param <EK>      the type of entity key
 * @param <HV>      the type entity
 * @author dainguyen
 */
public abstract class GenericCacheBase<EK, HV extends Serializable> {
    /**
     * The constant RETRY_ATTEMPTS.
     */
    public static final int RETRY_ATTEMPTS = 15;
    /**
     * The constant DELAY.
     */
    public static final int DELAY = 1;

    private static Log LOGGER = LogFactory.getLog(GenericCacheBase.class);

    private final LockingStrategy lockingStrategy;

    private final StorageStrategy storageStrategy;

    private final Class<HV> type;

    /**
     * Redis entity key.
     *
     * @return the string
     */
    protected abstract String redisEntityKey();

    /**
     * The Redis template.
     */
    protected final RedisTemplate<String, HV> redisTemplate;

    /**
     * Build redis key.
     *
     * @param entityKey the entity key
     * @return the double
     */
    protected abstract Double buildRedisKey(EK entityKey);

    /**
     * Gets id.
     *
     * @param value the value
     * @return the id
     */
    protected abstract EK getId(HV value);

    /**
     * Gets locking strategy.
     *
     * @return the locking strategy
     */
    protected abstract LockingStrategy getLockingStrategy();

    /**
     * Gets storage strategy.
     *
     * @return the storage strategy
     */
    protected abstract StorageStrategy getStorageStrategy();

    /**
     * Redis entity lock prefix.
     *
     * @return the string
     */
    protected String redisEntityLockPrefix(){
        return type.getSimpleName().toUpperCase() + ":LOCK";
    }

    /**
     * Build lock key.
     *
     * @param id the id
     * @return the string
     */
    protected String buildLockKey(EK id) {
        return String.format("%s:%s", redisEntityLockPrefix(), id);
    }

    /**
     * Instantiates a new No lock crud generic cache impl.
     * @param type the type
     */
    protected GenericCacheBase(Class<HV> type) {
        this.type = type;
        this.redisTemplate = (RedisTemplate<String, HV>)SpringBeanFactory.beanFactory.getBean("redisTemplate");
        this.lockingStrategy = getLockingStrategy() == null ? LockingStrategy.NONE : getLockingStrategy();
        this.storageStrategy = getStorageStrategy() == null ? StorageStrategy.JDK : getStorageStrategy();
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
    
    protected boolean add(HV added, Function<String, String> redisEntityKeyFunction){
        LOGGER.debug(String.format("Adding %s with information: %s", redisEntityKeyFunction.apply(redisEntityKey()), added));

        Double key = buildRedisKey(getId(added));
        boolean result = true;
        if(LockingStrategy.ROW_LEVEL.equals(lockingStrategy)){
            RedisTemplate<String, Long> redisLockTemplate = (RedisTemplate<String, Long>)redisTemplate;
            result = redisLockTemplate.opsForValue().setIfAbsent(buildLockKey(getId(added)), System.nanoTime());
        }
        result = result ? redisTemplate.opsForZSet().add(redisEntityKeyFunction.apply(redisEntityKey()), added, key) : result;

        LOGGER.debug(String.format("%s to adding %s with information: %s", result ? "Success" : "Fail", redisEntityKeyFunction.apply(redisEntityKey()), added));
        return result;
    }
    
    protected boolean deleteById(EK id, Function<String, String> redisEntityKeyFunction) {
        Double key = buildRedisKey(id);
        LOGGER.debug(String.format("Finding %s by id: %s", redisEntityKeyFunction.apply(redisEntityKey()), id));

        if(LockingStrategy.ROW_LEVEL.equals(lockingStrategy)){
            redisTemplate.delete(buildLockKey(id));
        }

        Long result = redisTemplate.opsForZSet().removeRangeByScore(redisEntityKeyFunction.apply(redisEntityKey()), key, key);

        return result > 0;
    }

    protected List<HV> findAll(Function<String, String> redisEntityKeyFunction){
        LOGGER.debug("Finding all " + redisEntityKeyFunction.apply(redisEntityKey()));
        Set<HV> result = redisTemplate.opsForZSet().range(redisEntityKeyFunction.apply(redisEntityKey()), 0, totalRecords(redisEntityKeyFunction));
        LOGGER.debug(String.format("Returning %d %s", result.size(), redisEntityKeyFunction.apply(redisEntityKey())));
        return new ArrayList<HV>(result);
    }

    protected List<HV> findRange(EK from, EK to, Function<String, String> redisEntityKeyFunction){
        LOGGER.debug(String.format("Finding range %s from %s to %s", redisEntityKeyFunction.apply(redisEntityKey()), from, to));
        Set<HV> result = redisTemplate.opsForZSet().rangeByScore(redisEntityKeyFunction.apply(redisEntityKey()), buildRedisKey(from), buildRedisKey(to));
        LOGGER.debug(String.format("Returning %d %s", result.size(), redisEntityKeyFunction.apply(redisEntityKey())));
        return new ArrayList<HV>(result);
    }

    protected HV findById(EK id, Function<String, String> redisEntityKeyFunction) {
        Double key = buildRedisKey(id);
        LOGGER.debug(String.format("Finding %s by id: %s", redisEntityKeyFunction.apply(redisEntityKey()), id));
        return fetch(redisTemplate.opsForZSet(), key, redisEntityKeyFunction);
    }

    protected long totalRecords(Function<String, String> redisEntityKeyFunction){
        return redisTemplate.opsForZSet().size(redisEntityKeyFunction.apply(redisEntityKey()));
    }

    protected Long add(final List<HV> addedSet, Function<String, String> redisEntityKeyFunction){
        LOGGER.debug(String.format("Adding %d %s to Cache", addedSet.size(), redisEntityKeyFunction.apply(redisEntityKey())));
        Set<ZSetOperations.TypedTuple<HV>> tuples = new HashSet<ZSetOperations.TypedTuple<HV>>();
        Map<String, Long> lockMap = new HashMap<String, Long>();
        boolean insertLock = true;
        for(HV added : addedSet){
            tuples.add(new DefaultTypedTuple<HV>(added, Double.valueOf(buildRedisKey(getId(added)))));
            if(LockingStrategy.ROW_LEVEL.equals(lockingStrategy)){
                lockMap.put(buildLockKey(getId(added)), System.nanoTime());
            }
        }
        RedisTemplate<String, Long> redisLockTemplate = (RedisTemplate<String, Long>)redisTemplate;
        if(LockingStrategy.ROW_LEVEL.equals(lockingStrategy)){
            insertLock = redisLockTemplate.opsForValue().multiSetIfAbsent(lockMap);
        }
        Long result = insertLock ? redisTemplate.opsForZSet().add(redisEntityKeyFunction.apply(redisEntityKey()), tuples) : 0;
        LOGGER.debug(String.format("Added %d %s to Cache", result, redisEntityKeyFunction.apply(redisEntityKey())));
        return result;
    }

    protected boolean delete(HV deleted, Function<String, String> redisEntityKeyFunction) throws NotFoundException {
        return deleteById(getId(deleted), redisEntityKeyFunction);
    }

    protected Page<HV> findAll(Pageable pageable, Function<String, String> redisEntityKeyFunction){
        LOGGER.debug(String.format("Finding all %s with pageable %s", redisEntityKeyFunction.apply(redisEntityKey()), pageable));
        long totalRecords = totalRecords(redisEntityKeyFunction);
        Set<HV> entities = redisTemplate.opsForZSet().rangeByScore(redisEntityKeyFunction.apply(redisEntityKey()), 0l, totalRecords, pageable.getOffset(), pageable.getPageSize());
        LOGGER.debug(String.format("Returning %d %s with total records %s", entities.size(), redisEntityKeyFunction.apply(redisEntityKey()), totalRecords));
        return new PageImpl<HV>(new ArrayList<HV>(entities), pageable, totalRecords);
    }

    protected Page<HV> findRange(EK from, EK to, Pageable pageable, Function<String, String> redisEntityKeyFunction){
        LOGGER.debug(String.format("Finding range %s from %s to %s", redisEntityKeyFunction.apply(redisEntityKey()), from, to));
        Double fromKey = buildRedisKey(from);
        Double toKey = buildRedisKey(to);
        long totalRecords = redisTemplate.opsForZSet().count(redisEntityKeyFunction.apply(redisEntityKey()), fromKey, toKey);
        Set<HV> entities = redisTemplate.opsForZSet().rangeByScore(redisEntityKeyFunction.apply(redisEntityKey()), fromKey, toKey, pageable.getOffset(), pageable.getPageSize());
        LOGGER.debug(String.format("Returning %d %s with total records %s", entities.size(), redisEntityKeyFunction.apply(redisEntityKey()), totalRecords));
        return new PageImpl<HV>(new ArrayList<HV>(entities), pageable, totalRecords);
    }

    protected boolean update(final HV updated, final boolean retryIfFail, Function<String, String> redisEntityKeyFunction) {
        LOGGER.debug(String.format("Updating %s with information: %s", redisEntityKeyFunction.apply(redisEntityKey()), updated));

        boolean retVal = update(Arrays.asList(getId(updated)), retryIfFail, new BiFunction<ZSetOperations<String, HV>, Double, HV>() {
            @Override
            public HV apply(ZSetOperations<String, HV> stringHVZSetOperations, Double aDouble) {
                return updated;
            }
        }, new BiFunction<EK, HV, HV>() {
            @Override
            public HV apply(EK ek, HV hv) {
                return hv;
            }
        }, redisEntityKeyFunction);
        LOGGER.debug(String.format("Updated %s with information: %s", redisEntityKeyFunction.apply(redisEntityKey()), getId(updated)));
        return retVal;
    }

    protected boolean update(final Collection<EK> keys, final boolean retryIfFail, BiFunction<EK, HV, HV> updateCallback, final Function<String, String> redisEntityKeyFunction) {
        return update(keys, retryIfFail, new BiFunction<ZSetOperations<String, HV>, Double, HV>() {
            @Override
            public HV apply(ZSetOperations<String, HV> zSetOperations, Double aDouble) {
                return fetch(zSetOperations, aDouble, redisEntityKeyFunction);
            }
        }, updateCallback, redisEntityKeyFunction);
    }
    
    protected boolean saveOrUpdate(HV entity, Function<String, String> redisEntityKeyFunction){
        Double key = buildRedisKey(getId(entity));
        Set<HV> result = redisTemplate.opsForZSet().rangeByScore(redisEntityKeyFunction.apply(redisEntityKey()), key, key);
        if(result == null || result.size() == 0){
            return add(entity, redisEntityKeyFunction);
        } else {
            return update(entity, true, redisEntityKeyFunction);
        }
    }

    private boolean update(final Collection<EK> keys, final boolean retryIfFail, final BiFunction<ZSetOperations<String, HV>, Double, HV> fetchCallback, final BiFunction<EK, HV, HV> updateCallback, final Function<String, String> redisEntityKeyFunction) {
        boolean retVal = true;
        if(updateCallback == null || fetchCallback == null){
            throw new UnsupportedOperationException("callback is required for this operation");
        } else {
            if(LockingStrategy.NONE.equals(lockingStrategy)){
                ZSetOperations<String, HV> zSetOperations =  redisTemplate.opsForZSet();
                for(EK key : keys){
                    Double entityKey = buildRedisKey(key);
                    HV entity = fetchCallback.apply(zSetOperations, entityKey);
                    entity = updateCallback.apply(key, entity);
                    zSetOperations.removeRangeByScore(redisEntityKeyFunction.apply(redisEntityKey()), entityKey, entityKey);
                    zSetOperations.add(redisEntityKeyFunction.apply(redisEntityKey()), entity, entityKey);
                }
            } else {
                final List<Object> finalResult = redisTemplate.execute(new SessionCallback<List<Object>>() {
                    public List<Object> execute(RedisOperations operations) throws DataAccessException {
                        List<Object> results = null;
                        int i = 0;
                        try {
                            while (results == null && i < (retryIfFail ? RETRY_ATTEMPTS : 1)) {
                                try {
                                    if (i > 0) {
                                        Thread.sleep(DELAY << i);
                                    }
                                } catch (InterruptedException e) {
                                    new RuntimeException(e);
                                }
                                ZSetOperations zSetOperations = operations.opsForZSet();
                                Map<EK, String> rowLockKeyMap = new HashMap<EK, String>();
                                Map<Map.Entry<EK, Double>, HV> fetchEntities = redisWatch(operations, zSetOperations, rowLockKeyMap, keys, fetchCallback, redisEntityKeyFunction);

                                operations.multi();
                                redisMulti(operations.opsForValue(), zSetOperations, rowLockKeyMap, fetchEntities, updateCallback, redisEntityKeyFunction);
                                // This will contain the results of all ops in the transaction
                                results = operations.exec();
                                i++;
                            }
                        } finally {
                            operations.unwatch();
                        }
                        return results;
                    }
                });
                retVal = finalResult != null;
            }
            return retVal;
        }
    }

    private Map<Map.Entry<EK, Double>, HV> redisWatch(RedisOperations operations, ZSetOperations<String, HV> zSetOperations, Map<EK, String> rowLockKeyMap, Collection<EK> keys, BiFunction<ZSetOperations<String, HV>, Double, HV> fetchCallback, Function<String, String> redisEntityKeyFunction) {
        for (EK key : keys) {
            rowLockKeyMap.put(key, buildLockKey(key));
        }
        if (LockingStrategy.TABLE_LEVEL.equals(lockingStrategy)) {
            operations.watch(redisEntityKeyFunction.apply(redisEntityKey()));
        } else {
            operations.watch(rowLockKeyMap.values());
        }
        Map<Map.Entry<EK, Double>, HV> fetchEntities = new HashMap<Map.Entry<EK, Double>, HV>(keys.size());
        for(EK key : keys){
            Double entityKey = buildRedisKey(key);
            fetchEntities.put(new AbstractMap.SimpleEntry<EK, Double>(key, entityKey), fetchCallback.apply(zSetOperations, entityKey));
        }
        return fetchEntities;
    }

    private void redisMulti(ValueOperations operations, ZSetOperations zSetOperations, Map<EK, String> rowLockKeyMap, Map<Map.Entry<EK, Double>, HV> fetchEntities, BiFunction<EK, HV, HV> updateCallback, Function<String, String> redisEntityKeyFunction) {
        for(Map.Entry<Map.Entry<EK, Double>, HV> entry : fetchEntities.entrySet()){
            if (LockingStrategy.ROW_LEVEL.equals(lockingStrategy)) {
                operations.set(rowLockKeyMap.get(entry.getKey().getKey()), System.nanoTime());
            }
            Double entityKey = entry.getKey().getValue();
            EK id = entry.getKey().getKey();
            HV updated = updateCallback.apply(id, entry.getValue());
            zSetOperations.removeRangeByScore(redisEntityKeyFunction.apply(redisEntityKey()), entityKey, entityKey);
            zSetOperations.add(redisEntityKeyFunction.apply(redisEntityKey()), updated, entityKey);
        }
    }

    private HV fetch(ZSetOperations<String, HV> zSetOperations, Double key, Function<String, String> redisEntityKeyFunction) {
        Set<HV> result = zSetOperations.rangeByScore(redisEntityKeyFunction.apply(redisEntityKey()), key, key);
        Iterator<HV> iterator = result.iterator();
        if(iterator.hasNext()){
            return iterator.next();
        }
        return null;
    }
}
