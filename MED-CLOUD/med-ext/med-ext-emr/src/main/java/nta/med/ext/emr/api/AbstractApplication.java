package nta.med.ext.emr.api;

import com.google.common.cache.Cache;
import com.google.common.cache.CacheBuilder;
import nta.med.common.glossary.Lifecyclet;

import java.util.concurrent.TimeUnit;

/**
 * @author dainguyen.
 */
public abstract class AbstractApplication<SES, TOK> extends Lifecyclet {

    private final Cache<TOK, SES> CACHE = CacheBuilder.newBuilder()
            .expireAfterAccess(2, TimeUnit.MINUTES)
            .maximumSize(10000).build();

    protected abstract SES verifyAuthorization(TOK token);

    protected boolean isValid(SES session, TOK token) {
        if (session == null || token == null) return false;
        return session.equals(token);
    }

    protected boolean isAuthorized(TOK token) {
        SES session = CACHE.getIfPresent(token);
        if (session == null) {
            session = verifyAuthorization(token);
            if(session != null) CACHE.put(token, session);
        }
        return session != null && isValid(session, token);
    }

}
