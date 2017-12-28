package nta.med.core.common.interceptor;

import nta.med.core.common.annotation.Route;
import nta.med.core.config.Configuration;
import nta.med.core.infrastructure.context.DbContext;
import org.aopalliance.intercept.MethodInterceptor;
import org.aopalliance.intercept.MethodInvocation;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class RouterInterceptor implements MethodInterceptor {

    private static final Log LOGGER = LogFactory.getLog(RouterInterceptor.class);
    private final Configuration configuration;

    public RouterInterceptor(Configuration configuration) {
        this.configuration = configuration;
    }

    @Override
    public Object invoke(MethodInvocation methodInvocation) throws Throwable {
        Route route = methodInvocation.getMethod().getDeclaredAnnotation(Route.class);
        if(route == null){
            route = methodInvocation.getClass().getDeclaredAnnotation(Route.class);
        }
        if(route == null && configuration.isShardable() && DbContext.SHARD_CONTEXT.get() != null)
        {
            DbContext.setShardingKey(DbContext.SHARD_CONTEXT.get().get());
        }
        else if((route != null && route.global()) || !configuration.isShardable()){
            DbContext.clear();
        } else if(DbContext.SHARD_CONTEXT.get() == null){
            LOGGER.warn("No sharding context found.");
            DbContext.clear();
        } else {

            DbContext.setShardingKey(DbContext.SHARD_CONTEXT.get().get());
        }
        if(configuration.isVerbose()){
            LOGGER.debug(String.format("Method %s is being routed to Sharding key: %s", methodInvocation.getMethod().getName(), DbContext.getShardingKey()));
        }
        return methodInvocation.proceed();
    }
}
