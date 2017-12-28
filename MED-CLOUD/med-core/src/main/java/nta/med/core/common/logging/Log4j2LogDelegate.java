package nta.med.core.common.logging;

import nta.med.common.util.Strings;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.vertx.java.core.logging.impl.LogDelegate;

public class Log4j2LogDelegate implements LogDelegate {

    private final Logger logger;

    Log4j2LogDelegate(final String name) {
        logger = LoggerFactory.getLogger(name);
    }

    public boolean isInfoEnabled() {
        return logger.isInfoEnabled();
    }

    public boolean isDebugEnabled() {
        return logger.isDebugEnabled();
    }

    public boolean isTraceEnabled() {
        return logger.isTraceEnabled();
    }

    public void fatal(final Object message) {
        logger.error(Strings.toString(message));
    }

    public void fatal(final Object message, final Throwable t) {
        logger.error(Strings.toString(message), t);
    }

    public void error(final Object message) {
        logger.error(Strings.toString(message));
    }

    public void error(final Object message, final Throwable t) {
        logger.error(Strings.toString(message), t);
    }

    public void warn(final Object message) {
        logger.warn(Strings.toString(message));
    }

    public void warn(final Object message, final Throwable t) {
        logger.warn(Strings.toString(message), t);
    }

    public void info(final Object message) {
        logger.info(Strings.toString(message));
    }

    public void info(final Object message, final Throwable t) {
        logger.info(Strings.toString(message), t);
    }

    public void debug(final Object message) {
        logger.debug(Strings.toString(message));
    }

    public void debug(final Object message, final Throwable t) {
        logger.debug(Strings.toString(message), t);
    }

    public void trace(final Object message) {
        logger.trace(Strings.toString(message));
    }

    public void trace(final Object message, final Throwable t) {
        logger.trace(Strings.toString(message), t);
    }
}
