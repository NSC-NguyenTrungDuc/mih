package nta.med.core.caching.cache;

import java.io.Serializable;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 * The interface Hash cache.
 * @param <HF>   the type parameter
 * @param <HV>   the type parameter
 * @author dainguyen.
 */
public interface HashCache<HF extends Serializable, HV extends Serializable> {

    /**
     * Put an element to hash.
     *
     * @param key the key
     * @param field the field
     * @param value the value
     */
    void put(String key, HF field, HV value);

    /**
     * Put all to the hash.
     *
     * @param key the key
     * @param map the map
     */
    void putAll(String key, Map<HF, HV> map);

    /**
     * Put if absent.
     *
     * @param key the key
     * @param field the field
     * @param value the value
     * @return the boolean
     */
    boolean putIfAbsent(String key, HF field, HV value);

    /**
     * Size long.
     *
     * @param key the key
     * @return the long
     */
    long size(String key);

    /**
     * Delete void.
     *
     * @param key the key
     * @param fields the fields
     */
    void delete(String key, HF... fields);

    /**
     * Contains boolean.
     *
     * @param key the key
     * @param field the field
     * @return the boolean
     */
    boolean contains(String key, HF field);

    /**
     * Find all.
     *
     * @param key the key
     * @return the map
     */
    Map<HF, HV> findAll(String key);

    /**
     * Find by field.
     *
     * @param key the key
     * @param fields the fields
     * @return the list
     */
    List<HV> findByField(String key, Collection<HF> fields);

    /**
     * Find by field.
     *
     * @param key the key
     * @param field the field
     * @return the hV
     */
    HV findByField(String key, HF field);

    /**
     * Fields set.
     *
     * @param key the key
     * @return the set
     */
    Set<HF> fields(String key);

    /**
     * Values list.
     *
     * @param key the key
     * @return the list
     */
    List<HV> values(String key);
}
