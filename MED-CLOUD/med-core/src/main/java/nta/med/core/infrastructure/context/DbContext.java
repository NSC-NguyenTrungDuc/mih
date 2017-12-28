package nta.med.core.infrastructure.context;

import java.util.function.Supplier;

/**
 * @author dainguyen.
 */
public class DbContext {
    /**
     * The constant contextHolder.
     */
    private static final InheritableThreadLocal<String> contextHolder = new InheritableThreadLocal<String>();

    public static final InheritableThreadLocal<Supplier<String>> SHARD_CONTEXT = new InheritableThreadLocal<>();

    /**
     * Sets data source.
     *
     * @param dataSource the data source
     */
    public static void setShardingKey(final String dataSource) {
        contextHolder.set(dataSource);
    }

    /**
     * Get data source.
     *
     * @return the string
     */
    public static String getShardingKey(){
        return contextHolder.get();
    }

    /**
     * Clear void.
     */
    public static void clear(){
        contextHolder.remove();
    }
}
