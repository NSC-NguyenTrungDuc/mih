package nta.med.core.config;

import com.google.common.collect.ImmutableList;

import java.util.List;

/**
 * @author dainguyen.
 */
public class VertxConfig {
    protected final String vertxClusterHost;
    protected final Integer vertxClusterPort;
    protected final Integer vertxInstances;
    protected final int vertxThreads;
    protected final boolean exitOnFailDeployment;
    protected final boolean vertxWorker;
    protected final boolean verbose;
    protected final boolean loginRequired;
    protected final boolean shardable;
    protected final int compressThreshold;
    protected final boolean compressible;
    private ImmutableList<String> modifiableRequests;

    public VertxConfig(boolean shardable, String vertxClusterHost, boolean loginRequired, Integer vertxInstances, boolean vertxWorker, boolean compressible, boolean vertxVerbose, Integer vertxClusterPort, int compressThreshold, int vertxThreads, boolean exitOnFailDeployment) {
        this.shardable = shardable;
        this.vertxClusterHost = vertxClusterHost;
        this.loginRequired = loginRequired;
        this.vertxInstances = vertxInstances;
        this.vertxWorker = vertxWorker;
        this.compressible = compressible;
        this.verbose = vertxVerbose;
        this.vertxClusterPort = vertxClusterPort;
        this.compressThreshold = compressThreshold;
        this.vertxThreads = vertxThreads;
        this.exitOnFailDeployment = exitOnFailDeployment;
    }

    public String getVertxClusterHost() {
        return vertxClusterHost;
    }

    public Integer getVertxClusterPort() {
        return vertxClusterPort;
    }

    public Integer getVertxInstances() {
        return vertxInstances;
    }

    public int getVertxThreads() {
        return vertxThreads;
    }

    public boolean isVertxWorker() {
        return vertxWorker;
    }

    public boolean isVerbose() {
        return verbose;
    }

    public boolean isLoginRequired() {
        return loginRequired;
    }

    public boolean isShardable() {
        return shardable;
    }

    public int getCompressThreshold() {
        return compressThreshold;
    }

    public boolean isCompressible() {
        return compressible;
    }

    public boolean isExitOnFailDeployment() {
        return exitOnFailDeployment;
    }

    public boolean isModifiableRequest(String request) {
        return modifiableRequests.contains(request);
    }

    public void setModifiableRequests(List<String> modifiableRequests) {
        this.modifiableRequests = ImmutableList.copyOf(modifiableRequests);
    }
}
