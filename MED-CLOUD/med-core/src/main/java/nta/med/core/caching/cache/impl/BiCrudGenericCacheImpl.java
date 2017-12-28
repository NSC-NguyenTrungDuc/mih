package nta.med.core.caching.cache.impl;

import com.google.common.base.Function;
import com.google.common.cache.Cache;
import com.google.common.cache.CacheBuilder;
import nta.med.core.caching.cache.BiGenericCache;
import nta.med.core.caching.exception.NotFoundException;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.io.Serializable;
import java.util.Collection;
import java.util.List;
import java.util.concurrent.TimeUnit;
import java.util.function.BiFunction;

/**
 * The type default crud generic cache impl.
 *
 * @param <EK> the type of entity key
 * @param <HV> the type entity
 * @author dainguyen
 */
public abstract class BiCrudGenericCacheImpl<EK, HV extends Serializable> extends GenericCacheBase<EK, HV> implements BiGenericCache<EK, HV> {

    private final Cache<String, Function<String, String>> cachedFunctions = CacheBuilder.newBuilder().expireAfterAccess(10, TimeUnit.MINUTES).build();

    /**
     * Instantiates a new No lock crud generic cache impl.
     *
     * @param type the type
     */
    protected BiCrudGenericCacheImpl(Class<HV> type) {
        super(type);
    }

    @Override
    public boolean add(String keySpace, HV added) {
        return super.add(added, functionInstance(keySpace));
    }

    @Override
    public List<HV> findRange(String keySpace, EK from, EK to) {
        return super.findRange(from, to, functionInstance(keySpace));
    }

    @Override
    public long totalRecords(final String keySpace) {
        return super.totalRecords(functionInstance(keySpace));
    }

    @Override
    public Long add(String keySpace, List<HV> addedSet) {
        return super.add(addedSet, functionInstance(keySpace));
    }

    @Override
    public boolean deleteById(String keySpace, EK id) throws NotFoundException {
        return super.deleteById(id, functionInstance(keySpace));
    }

    @Override
    public boolean delete(String keySpace, HV deleted) throws NotFoundException {
        return super.delete(deleted, functionInstance(keySpace));
    }

    @Override
    public List<HV> findAll(final String keySpace) {
        return super.findAll(functionInstance(keySpace));
    }

    @Override
    public Page<HV> findAll(String keySpace, Pageable pageable) {
        return super.findAll(pageable, functionInstance(keySpace));
    }

    @Override
    public Page<HV> findRange(String keySpace, EK from, EK to, Pageable pageable) {
        return super.findRange(from, to, pageable, functionInstance(keySpace));
    }

    @Override
    public HV findById(String keySpace, EK id) throws NotFoundException {
        return super.findById(id, functionInstance(keySpace));
    }

    @Override
    public boolean update(String keySpace, HV updated, boolean retryIfFail) throws NotFoundException {
        return super.update(updated, retryIfFail, functionInstance(keySpace));
    }

    @Override
    public boolean saveOrUpdate(String keySpace, HV entity) throws NotFoundException {
        return super.saveOrUpdate(entity, functionInstance(keySpace));
    }
    
    @Override
    public boolean update(String keySpace, Collection<EK> keys, boolean retryIfFail, BiFunction<EK, HV, HV> updateCallback) {
        return super.update(keys, retryIfFail, updateCallback, functionInstance(keySpace));
    }

    private Function<String, String> functionInstance(final String keySpace){
        if(!cachedFunctions.asMap().containsKey(keySpace)){
            cachedFunctions.put(keySpace, new Function<String, String>() {
                @Override
                public String apply(String redisEntityKey) {
                    return redisEntityKey + ":" + keySpace;
                }
            });
        }
        return cachedFunctions.getIfPresent(keySpace);
    }
}
