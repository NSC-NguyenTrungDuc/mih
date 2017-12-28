package nta.med.core.caching.cache.impl;

import com.google.common.base.Function;
import nta.med.core.caching.cache.GenericCache;
import nta.med.core.caching.exception.NotFoundException;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.io.Serializable;
import java.util.Collection;
import java.util.List;
import java.util.function.BiFunction;

/**
 * The type default crud generic cache impl.
 * @param <EK>      the type of entity key
 * @param <HV>      the type entity
 * @author dainguyen
 */
public abstract class CrudGenericCacheImpl<EK, HV extends Serializable> extends GenericCacheBase<EK, HV> implements GenericCache<EK,HV> {

    private final Function<String, String> redisEntityKeyFunction;

    /**
     * Instantiates a new No lock crud generic cache impl.
     * @param type the type
     */
    protected CrudGenericCacheImpl(Class<HV> type) {
        super(type);
        redisEntityKeyFunction = new Function<String, String>() {
            @Override
            public String apply(String entityKey) {
                return entityKey;
            }
        };
    }

    @Override
    public boolean add(HV added){
        return super.add(added, redisEntityKeyFunction);
    }

    @Override
    public boolean deleteById(EK id) {
        return super.deleteById(id, redisEntityKeyFunction);
    }

    @Override
    public List<HV> findAll(){
        return super.findAll(redisEntityKeyFunction);
    }

    @Override
    public List<HV> findRange(EK from, EK to){
        return super.findRange(from, to, redisEntityKeyFunction);
    }

    @Override
    public HV findById(EK id) {
        return super.findById(id, redisEntityKeyFunction);
    }

    @Override
    public long totalRecords(){
        return super.totalRecords(redisEntityKeyFunction);
    }

    @Override
    public Long add(final List<HV> addedSet){
        return super.add(addedSet, redisEntityKeyFunction);
    }

    @Override
    public boolean delete(HV deleted) throws NotFoundException {
        return super.delete(deleted, redisEntityKeyFunction);
    }

    @Override
    public Page<HV> findAll(Pageable pageable){
        return super.findAll(pageable, redisEntityKeyFunction);
    }

    @Override
    public Page<HV> findRange(EK from, EK to, Pageable pageable){
        return super.findRange(from, to, pageable, redisEntityKeyFunction);
    }

    @Override
    public boolean update(final HV updated, final boolean retryIfFail) {
        return super.update(updated, retryIfFail, redisEntityKeyFunction);
    }
    
    @Override
    public boolean saveOrUpdate(HV entity) throws NotFoundException {
        return super.saveOrUpdate(entity, redisEntityKeyFunction);
    }

    @Override
    public boolean update(final Collection<EK> keys, final boolean retryIfFail, BiFunction<EK, HV, HV> updateCallback) {
        return super.update(keys, retryIfFail, updateCallback, redisEntityKeyFunction);
    }
}
