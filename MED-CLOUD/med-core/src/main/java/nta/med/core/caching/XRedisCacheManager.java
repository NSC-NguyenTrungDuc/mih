package nta.med.core.caching;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.cache.Cache;
import org.springframework.data.redis.RedisConnectionFailureException;
import org.springframework.data.redis.cache.RedisCacheManager;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.util.Assert;
import redis.clients.jedis.exceptions.JedisConnectionException;

import java.util.Collection;

/**
 * @author dainguyen.
 */
public class XRedisCacheManager extends RedisCacheManager {

    private static final Log LOGGER = LogFactory.getLog(XRedisCacheManager.class);

    public XRedisCacheManager(RedisTemplate template) {
        super(template);
    }

    public XRedisCacheManager(RedisTemplate template, Collection<String> cacheNames) {
        super(template, cacheNames);
    }

    @Override
    public Cache getCache(String name) {
        return new RedisCacheWrapper(super.getCache(name));
    }

    protected static class RedisCacheWrapper implements Cache {

        private final Cache delegate;

        public RedisCacheWrapper(Cache redisCache) {
            Assert.notNull(redisCache, "'delegate' must not be null");
            this.delegate = redisCache;
        }

        @Override
        public String getName() {
            try {
                return delegate.getName();
            } catch (Exception e) {
                return handleErrors(e);
            }
        }

        @Override
        public Object getNativeCache() {
            try {
                return delegate.getNativeCache();
            } catch (Exception e) {
                return handleErrors(e);
            }
        }

        @Override
        public Cache.ValueWrapper get(Object key) {
            try {
                return delegate.get(key);
            } catch (Exception e) {
                return handleErrors(e);
            }
        }

        @Override
        public <T> T get(Object o, Class<T> aClass) {
            try {
                return delegate.get(o, aClass);
            } catch (Exception e) {
                return handleErrors(e);
            }
        }

        @Override
        public void put(Object key, Object value) {
            try {
                delegate.put(key, value);
            } catch (Exception e) {
                handleErrors(e);
            }
        }

        @Override
        public ValueWrapper putIfAbsent(Object key, Object value) {
            try {
                return delegate.putIfAbsent(key, value);
            } catch (Exception e) {
                return handleErrors(e);
            }
        }

        @Override
        public void evict(Object o) {
            try {
                delegate.evict(o);
            } catch (Exception e) {
                handleErrors(e);
            }
        }

        @Override
        public void clear() {
            try {
                delegate.clear();
            } catch (Exception e) {
                handleErrors(e);
            }
        }

        protected <T> T handleErrors(Exception e) {
            if (e instanceof RedisConnectionFailureException) {
                LOGGER.warn("RedisConnectionFailureException: " + e.getMessage());
                return null;
            } else if (e instanceof JedisConnectionException) {
                LOGGER.warn("JedisConnectionException: " + e.getMessage());
                return null;
            }
            throw new RuntimeException(e);
        }
    }
}
