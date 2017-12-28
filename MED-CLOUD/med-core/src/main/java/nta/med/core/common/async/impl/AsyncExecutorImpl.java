package nta.med.core.common.async.impl;

import nta.med.common.glossary.Lifecyclet;
import nta.med.common.glossary.Nullable;
import nta.med.common.util.concurrent.executor.XExecutorService;
import nta.med.common.util.concurrent.executor.XExecutors;
import nta.med.core.common.async.AsyncExecutor;

import java.util.concurrent.Callable;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;

import static nta.med.common.util.Concurrents.terminateQuietly;

/**
 * @author dainguyen.
 */
public class AsyncExecutorImpl extends Lifecyclet implements AsyncExecutor {
    //
    private int shards = 2;
    private final String name;
    private XExecutorService executors[];

    /**
     *
     */
    public AsyncExecutorImpl(String name) {
        this.name = name;
    }

    @Override
    protected void doStart() throws Exception {
        this.executors = XExecutors.creates(name, shards, 1);
    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        return terminateQuietly(this.executors, timeout, unit);
    }

    /**
     *
     */
    public void setShards(int shards) {
        this.shards = shards;
    }

    @Override
    public Future<?> execute(@Nullable Integer shard, Runnable task) {
        return submit(shard, task);
    }

    @Override
    public <T> Future<T> execute(@Nullable Integer shard, Callable<T> task) {
        return submit(shard, task);
    }

    /**
     *
     */
    @Override
    public Future<?> execute(String service, @Nullable Integer shard, Runnable task) {
        return submit(shard, task);
    }

    @Override
    public <T> Future<T> execute(String service, @Nullable Integer shard, Callable<T> task) {
        return submit(shard, task);
    }

    private <T> Future<T> submit(@Nullable Integer shard, Callable<T> task) {
        if(this.executors.length == 1) {
            return this.executors[0].submit(task);
        } else if(shard == null) {
            return this.executors[this.executors.length - 1].submit(task);
        } else {
            return this.executors[shard % (this.executors.length - 1)].submit(task);
        }
    }

    private Future<?> submit(@Nullable Integer shard, Runnable task) {
        if(this.executors.length == 1) {
            return this.executors[0].submit(task);
        } else if(shard == null) {
            return this.executors[this.executors.length - 1].submit(task);
        } else {
            return this.executors[shard % (this.executors.length - 1)].submit(task);
        }
    }
}
