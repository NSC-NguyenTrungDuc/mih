package nta.mss.misc.common;

/**
 * @author DEV-TiepNM
 */
public interface TokenManager<T> {

    public void put(String key, T value);

    public T get(String key);

    public void invalidate(String key);

    public String getTokenByHospCodeUserId(String hospCode, String userId);
}
