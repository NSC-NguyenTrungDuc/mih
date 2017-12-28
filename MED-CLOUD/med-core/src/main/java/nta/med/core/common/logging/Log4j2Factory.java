package nta.med.core.common.logging;

import com.hazelcast.logging.AbstractLogger;
import com.hazelcast.logging.ILogger;
import com.hazelcast.logging.LogEvent;
import com.hazelcast.logging.LoggerFactorySupport;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.logging.impl.Log4JLogger;
import org.apache.commons.logging.impl.LogFactoryImpl;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.logging.Level;
import java.util.logging.LogRecord;

/**
 * @author DEV-TiepNM
 */
public class Log4j2Factory extends LoggerFactorySupport {

    private static final String FQCN = Log4j2Logger.class.getName();

    @Override
    protected ILogger createLogger(String name) {
        return new Log4j2Logger(LoggerFactory.getLogger(name));
    }

    class Log4j2Logger extends AbstractLogger {
        private final Logger logger;

        public Log4j2Logger(Logger logger) {
            this.logger = logger;
        }

        @Override
        public void log(Level level, String s) {
            if (Level.SEVERE == level) {
                logger.error(s);
                return;
            } else if (Level.WARNING == level) {
                logger.warn(s);
                return;
            } else if (Level.INFO == level) {
                logger.info(s);
                return;
            } else if (Level.CONFIG == level) {
                logger.info(s);
                return;
            } else if (Level.FINE == level) {
                logger.debug(s);
                return;
            } else if (Level.FINER == level) {
                logger.debug(s);
                return;
            } else if (Level.FINEST == level) {
                logger.debug(s);
                return;
            } else {
                logger.info(s);
                return;
            }
        }

        @Override
        public void log(Level level, String s, Throwable throwable) {
            if (Level.SEVERE == level) {
                logger.error(s, throwable);
                return;
            } else if (Level.WARNING == level) {
                logger.warn(s, throwable);
                return;
            } else if (Level.INFO == level) {
                logger.info(s, throwable);
                return;
            } else if (Level.CONFIG == level) {
                logger.info(s, throwable);
                return;
            } else if (Level.FINE == level) {
                logger.debug(s, throwable);
                return;
            } else if (Level.FINER == level) {
                logger.debug(s, throwable);
                return;
            } else if (Level.FINEST == level) {
                logger.debug(s, throwable);
                return;
            } else {
                logger.info(s, throwable);
                return;
            }
        }

        @Override
        public void log(LogEvent logEvent) {
            LogRecord logRecord = logEvent.getLogRecord();
            Level level = logEvent.getLogRecord().getLevel();
            String message = logRecord.getMessage();
            Throwable thrown = logRecord.getThrown();
            log(level, message, thrown);
        }

        @Override
        public Level getLevel() {
            if (logger.isDebugEnabled()) {
                return Level.FINEST;
            } else if (logger.isInfoEnabled()) {
                return Level.INFO;
            } else if (logger.isWarnEnabled()) {
                return Level.WARNING;
            } else {
                return Level.SEVERE;
            }
        }

        @Override
        public boolean isLoggable(Level level) {
            if (Level.OFF == level) {
                return false;
            } else {
                if (Level.SEVERE == level) {
                    return logger.isErrorEnabled();
                } else if (Level.WARNING == level) {
                    return logger.isWarnEnabled();
                } else if (Level.INFO == level) {
                    return logger.isInfoEnabled();
                } else if (Level.CONFIG == level) {
                    return logger.isInfoEnabled();
                } else if (Level.FINE == level) {
                    return logger.isDebugEnabled();
                } else if (Level.FINER == level) {
                    return logger.isDebugEnabled();
                } else if (Level.FINEST == level) {
                    return logger.isDebugEnabled();
                } else {
                    return logger.isInfoEnabled();
                }
            }
        }
    }
}
