package nta.med.ext.cms.caching;

import java.util.Set;
import java.util.concurrent.ConcurrentMap;
import java.util.concurrent.TimeUnit;

import com.google.common.cache.Cache;
import com.google.common.cache.CacheBuilder;

import nta.med.ext.cms.model.cms.CmsSession;

/**
 * @author DEV-TiepNM
 */
public class InmemoryTokenStore implements TokenManager<CmsSession> {
	private Cache<String, CmsSession> guavaToken;
	private int expire;
	private int maximumSize;

	public void setExpire(int expire) {
		this.expire = expire;
	}

	public void setMaximumSize(int maximumSize) {
		this.maximumSize = maximumSize;
	}

	public void intConfig() {
		guavaToken = CacheBuilder.newBuilder().maximumSize(maximumSize).expireAfterAccess(expire, TimeUnit.SECONDS)
				.build();
	}

	@Override
	public void put(String key, CmsSession cmsSession) {
		guavaToken.put(key, cmsSession);
	}

	@Override
	public CmsSession get(String key) {
		return guavaToken.getIfPresent(key);
	}

	@Override
	public void invalidate(String key) {
		guavaToken.invalidate(key);
	}
	
	@Override
	public String getTokenByHospCodeUserId(String hospCode, String userId){
		ConcurrentMap<String, CmsSession> mapToken = guavaToken.asMap();
		Set<String> tokens = mapToken.keySet();
		for (String token : tokens) {
			CmsSession ss = mapToken.get(token);
			if(ss != null && hospCode.equals(ss.getHospCode()) && userId.equals(ss.getUserName())) return token;
		}
		
		return "";
	}
	
}
