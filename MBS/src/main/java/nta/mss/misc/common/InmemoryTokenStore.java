package nta.mss.misc.common;

import com.google.common.cache.Cache;
import com.google.common.cache.CacheBuilder;

import java.util.Set;
import java.util.concurrent.ConcurrentMap;
import java.util.concurrent.TimeUnit;

/**
 * @author DEV-TiepNM
 */
public class InmemoryTokenStore implements TokenManager<MSSSession> {
	private Cache<String, MSSSession> guavaToken;
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
	public void put(String key, MSSSession cmsSession) {
		guavaToken.put(key, cmsSession);
	}

	@Override
	public MSSSession get(String key) {
		return guavaToken.getIfPresent(key);
	}

	@Override
	public void invalidate(String key) {
		guavaToken.invalidate(key);
	}
	
	@Override
	public String getTokenByHospCodeUserId(String hospCode, String userId){
		ConcurrentMap<String, MSSSession> mapToken = guavaToken.asMap();
		Set<String> tokens = mapToken.keySet();
		for (String token : tokens) {
			MSSSession ss = mapToken.get(token);
			if(ss != null && hospCode.equals(ss.getHospCode()) && userId.equals(ss.getUserName())) return token;
		}
		
		return "";
	}
	
}
