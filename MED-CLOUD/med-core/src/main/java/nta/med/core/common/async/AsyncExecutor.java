package nta.med.core.common.async;

import nta.med.common.glossary.Lifecycle;
import nta.med.common.glossary.Nullable;

import java.util.concurrent.Callable;
import java.util.concurrent.Future;

/**
 * @author dainguyen.
 */
public interface AsyncExecutor extends Lifecycle {

    Future<?> execute(@Nullable Integer shard, Runnable task);

    <T> Future<T> execute(@Nullable Integer shard, Callable<T> task);

    Future<?> execute(String service, @Nullable Integer shard, Runnable task);

    <T> Future<T> execute(String service, @Nullable Integer shard, Callable<T> task);
}
