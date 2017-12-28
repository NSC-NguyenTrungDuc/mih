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
 * @param <EK>   the type parameter
 * @param <HV>   the type parameter
 * @author dainguyen
 */
public interface GenericCache<EK, HV extends Serializable> {

    /**
     * Add boolean.
     *
     * @param added the added
     * @return the boolean
     */
    boolean add(HV added);

    /**
     * Find range.
     *
     * @param from the from
     * @param to the to
     * @return the list
     */
    List<HV> findRange(EK from, EK to);

    /**
     * Total records.
     *
     * @return the long
     */
    long totalRecords();

    /**
     * Add long.
     *
     * @param addedSet the added set
     * @return the long
     */
    Long add(List<HV> addedSet);

    /**
     * Delete by id.
     *
     * @param id the id
     * @return the hV
     * @throws NotFoundException the not found exception
     */
    boolean deleteById(EK id) throws NotFoundException;

    /**
     * Delete hV.
     *
     * @param deleted the deleted
     * @return the hV
     * @throws NotFoundException the not found exception
     */
    boolean delete(HV deleted) throws NotFoundException;

    /**
     * Find all.
     *
     * @return the list
     */
    List<HV> findAll();

    /**
     * Find all.
     *
     * @param pageable the pageable
     * @return the page
     */
    Page<HV> findAll(Pageable pageable);

    /**
     * Find range.
     *
     * @param from the from
     * @param to the to
     * @param pageable the pageable
     * @return the page
     */
    Page<HV> findRange(EK from, EK to, Pageable pageable);

    /**
     * Find by id.
     *
     * @param id the id
     * @return the hV
     * @throws NotFoundException the not found exception
     */
    HV findById(EK id) throws NotFoundException;

    /**
     * Update boolean.
     *
     * @param updated the updated
     * @param retryIfFail the retry if fail
     * @return the boolean
     * @throws NotFoundException the not found exception
     */
    boolean update(HV updated, boolean retryIfFail) throws NotFoundException;

    /**
     * Save or update.
     *
     * @param entity the updated
     * @return the boolean
     * @throws NotFoundException the not found exception
     */
    boolean saveOrUpdate(HV entity) throws NotFoundException;

    
    /**
     * Update a collections with transaction.
     *
     * @param keys the keys
     * @param retryIfFail the retry if fail
     * @param updateCallback the update callback
     * @return the boolean
     */
    boolean update(final Collection<EK> keys, final boolean retryIfFail, BiFunction<EK, HV, HV> updateCallback);
}
