package nta.med.core.common.interceptor;

import org.aopalliance.intercept.MethodInvocation;
import org.apache.commons.logging.Log;
import org.springframework.aop.interceptor.CustomizableTraceInterceptor;

/**
 * @author dainguyen.
 */
public class MonitorInterceptor extends CustomizableTraceInterceptor {

    private final boolean ignoreExceptions;

    public MonitorInterceptor(boolean ignoreExceptions) {
        this.ignoreExceptions = ignoreExceptions;
    }

    @Override
    protected boolean isInterceptorEnabled(MethodInvocation invocation, Log logger) {
        return true;
    }

    @Override
    protected void writeToLog(Log logger, String message, Throwable ex) {
        if(ex != null) {
            if(!ignoreExceptions) logger.info(message, ex);
        } else {
            logger.info(message);
        }
    }
}
