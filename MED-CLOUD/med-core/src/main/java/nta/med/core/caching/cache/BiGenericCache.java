package nta.med.core.caching.cache;

import nta.med.core.caching.exception.NotFoundException;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.io.Serializable;
import java.util.Collection;
import java.util.List;
import java.util.function.BiFunction;

/**
 * The interface Generic cache.
 * @param <EK>    the type parameter
 * @param <HV>    the type parameter
 * @author dainguyen
 */
public interface BiGenericCache<EK, HV extends Serializable> {
    /**
     * The constant RETRY_ATTEMPTS.
     */
    public static final int RETRY_ATTEMPTS = 15;
    /**
     * The constant DELAY.
     */
    public static final int DELAY = 1;

    /**
     * Add boolean.
     *
     * @param keySpace the key space
     * @param added the added
     * @return the boolean
     */
    boolean add(String keySpace, HV added);

    /**
     * Find range.
     *
     * @param keySpace the key space
     * @param from the from
     * @param to the to
     * @return the list
     */
    List<HV> findRange(String keySpace, EK from, EK to);

    /**
     * Total records.
     *
     * @param keySpace the key space
     * @return the long
     */
    long totalRecords(String keySpace);

    /**
     * Add long.
     *
     * @param keySpace the key space
     * @param addedSet the added set
     * @return the long
     */
    Long add(String keySpace, List<HV> addedSet);

    /**
     * Delete by id.
     *
     * @param keySpace the key space
     * @param id the id
     * @return the hV
     * @throws NotFoundException the not found exception
     */
    boolean deleteById(String keySpace, EK id) throws NotFoundException;

    /**
     * Delete hV.
     *
     * @param keySpace the key space
     * @param deleted the deleted
     * @return the hV
     * @throws NotFoundException the not found exception
     */
    boolean delete(String keySpace, HV deleted) throws NotFoundException;

    /**
     * Find all.
     *
     * @param keySpace the key space
     * @return the list
     */
    List<HV> findAll(String keySpace);

    /**
     * Find all.
     *
     * @param keySpace the key space
     * @param pageable the pageable
     * @return the page
     */
    Page<HV> findAll(String keySpace, Pageable pageable);

    /**
     * Find range.
     *
     * @param keySpace the key space
     * @param from the from
     * @param to the to
     * @param pageable the pageable
     * @return the page
     */
    Page<HV> findRange(String keySpace, EK from, EK to, Pageable pageable);

    /**
     * Find by id.
     *
     * @param keySpace the key space
     * @param id the id
     * @return the hV
     * @throws NotFoundException the not found exception
     */
    HV findById(String keySpace, EK id) throws NotFoundException;

    /**
     * Update boolean.
     *
     * @param keySpace the key space
     * @param updated the updated
     * @param retryIfFail the retry if fail
     * @return the boolean
     * @throws NotFoundException the not found exception
     */
    boolean update(String keySpace, HV updated, boolean retryIfFail) throws NotFoundException;

    /**
     * Save or update.
     *
     * @param keySpace the key space
     * @param entity the entity
     * @return the boolean
     * @throws NotFoundException the not found exception
     */
    boolean saveOrUpdate(String keySpace, HV entity) throws NotFoundException;
    
    /**
     * Update a collections with transaction.
     *
     * @param keySpace the key space
     * @param keys the keys
     * @param retryIfFail the retry if fail
     * @param updateCallback the update callback
     * @return the boolean
     */
    boolean update(String keySpace, final Collection<EK> keys, final boolean retryIfFail, BiFunction<EK, HV, HV> updateCallback);
}
