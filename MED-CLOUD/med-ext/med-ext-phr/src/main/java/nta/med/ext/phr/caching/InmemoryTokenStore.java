package nta.med.ext.phr.caching;

import java.util.concurrent.TimeUnit;

import com.google.common.cache.Cache;
import com.google.common.cache.CacheBuilder;

import nta.med.ext.phr.model.UserInfo;

/**
 * @author DEV-TiepNM
 */
public class InmemoryTokenStore implements TokenManager<UserInfo> {
    private Cache<String, UserInfo> guavaToken;
    private int expire;
    private int maximumSize;
    public void setExpire(int expire) {
        this.expire = expire;
    }

    public void setMaximumSize(int maximumSize) {
        this.maximumSize = maximumSize;
    }

    public void intConfig() {
        guavaToken = CacheBuilder.newBuilder()
                .maximumSize(maximumSize)
                .expireAfterAccess(expire, TimeUnit.SECONDS)
                .build();
    }

    @Override
    public void put(String key, UserInfo userInfo) {
        guavaToken.put(key, userInfo);
    }

    @Override
    public UserInfo get(String key) {
        return guavaToken.getIfPresent(key);
    }

    @Override
    public void invalidate(String key) {
        guavaToken.invalidate(key);
    }
}
