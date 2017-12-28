package nta.med.core.infrastructure.tx;

import com.google.common.collect.ImmutableMap;
import org.springframework.orm.jpa.JpaTransactionManager;
import org.springframework.transaction.TransactionDefinition;

import java.util.Map;
import java.util.stream.Collectors;

/**
 * @author dainguyen.
 */
public class XJpaTransactionManager extends JpaTransactionManager {

    private final ImmutableMap<String, Integer> handlerTimeouts;
    private final int defaultTimeout;

    public XJpaTransactionManager(Map<Class, Integer> timeoutSettings, int defaultTimeout) {
        this.defaultTimeout = defaultTimeout;
        handlerTimeouts = ImmutableMap.copyOf(
                timeoutSettings.entrySet().stream().collect(
                        Collectors.toMap(e -> e.getKey().getName() + ".handle", Map.Entry::getValue)
                )
        );
    }

    @Override
    protected int determineTimeout(TransactionDefinition definition) {
        Integer timeout = handlerTimeouts.get(definition.getName());
        //TODO : remove condition definition.getName().endsWith("Hanlder.handle")) & Handler.handle1 & Handler.handle2 & Handler.handle4 after merger fabric branch
        if(timeout == null && (definition.getName().endsWith("Handler.handle") ||
                definition.getName().endsWith("Handler.handle1") || definition.getName().endsWith("Handler.handle2") ||
                definition.getName().endsWith("Handler.handle3") || definition.getName().endsWith("Hanlder.handle"))){
            timeout = defaultTimeout;
        }
       return timeout != null ? timeout : super.determineTimeout(definition); 
    }
}
