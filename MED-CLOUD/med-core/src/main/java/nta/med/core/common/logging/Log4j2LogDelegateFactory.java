package nta.med.core.common.logging;

import org.vertx.java.core.logging.impl.LogDelegate;
import org.vertx.java.core.logging.impl.LogDelegateFactory;

public class Log4j2LogDelegateFactory implements LogDelegateFactory {

    public LogDelegate createDelegate(String name) {
        return new Log4j2LogDelegate(name);
    }

}
