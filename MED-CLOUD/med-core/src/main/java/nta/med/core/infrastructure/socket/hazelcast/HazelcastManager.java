package nta.med.core.infrastructure.socket.hazelcast;

import com.hazelcast.client.HazelcastClient;
import com.hazelcast.client.config.ClientConfig;
import com.hazelcast.client.config.XmlClientConfigBuilder;
import com.hazelcast.config.ListenerConfig;
import com.hazelcast.core.*;
import nta.med.common.glossary.Lifecyclet;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.BufferedInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.Iterator;
import java.util.concurrent.TimeUnit;
import java.util.function.Supplier;
import java.util.stream.Collectors;

/**
 * @author dainguyen.
 */
public class HazelcastManager extends Lifecyclet implements MembershipListener {
    private static final Logger log = LoggerFactory.getLogger(HazelcastManager.class);

    private static final String DEFAULT_CONFIG_FILE = "default-client.xml";
    private static final String CONFIG_FILE = "client.xml";
    private static final String NODES = "nodes";
    private static final String EVENTS = "events";

    private HazelcastInstance hazelcast;

    public HazelcastManager() {
    }

    public IAtomicLong getCounter(String counterName, Supplier<Long> latest) {
        if (hazelcast == null) return null;
        IAtomicLong counter = hazelcast.getAtomicLong(counterName);
        if(counter.get() == 0) counter.compareAndSet(0L, latest.get());
        return counter;
    }

    private InputStream getConfigStream() {
        ClassLoader ctxClsLoader = Thread.currentThread().getContextClassLoader();
        InputStream is = null;
        if (ctxClsLoader != null) {
            is = ctxClsLoader.getResourceAsStream(CONFIG_FILE);
        }
        if (is == null) {
            is = getClass().getClassLoader().getResourceAsStream(CONFIG_FILE);
            if (is == null) {
                is = getClass().getClassLoader().getResourceAsStream(DEFAULT_CONFIG_FILE);
            }
        }
        return is;
    }

    /**
     * Get the Hazelcast config
     *
     * @return a config object
     */
    protected ClientConfig getConfig() {
        ClientConfig cfg = null;
        try (InputStream is = getConfigStream();
             InputStream bis = new BufferedInputStream(is)) {
            if (is != null) {
                cfg = new XmlClientConfigBuilder(bis).build();
            }
        } catch (IOException ex) {
            log.error("Failed to read config", ex);
        }
        return cfg;
    }

    public String getEndpoint(String address, String hospCode) {
        ISet<String> endpoints = hazelcast.getSet(EVENTS);
        ISet<String> nodes = hazelcast.getSet(NODES);
        String prefixEndPoint = String.format("%s-%s-", address, hospCode);
        String prefixEndPointNTA = String.format("%s-NTA-", address);
        Iterator<String> iterator = endpoints.iterator();
        String candidate = null;
        while (iterator.hasNext()) {
            String r = iterator.next();
            String nodeID = r.replaceFirst(prefixEndPoint, "");
            String nodeNTAID = r.replaceFirst(prefixEndPointNTA, "");
            if (nodes.contains(nodeID)) return r.replaceFirst(String.format("-%s-", hospCode), "-");
            if (nodes.contains(nodeNTAID)) candidate = r.replaceFirst("-NTA-", "-");
        }
        return candidate;
    }

    public void addEndpoint(String address, String hospCode, String nodeID) {
        //hazelcast.getSet(String.format("%s-%s", address, hospCode)).add(String.format("%s-%s", address, nodeID));

        hazelcast.getSet(EVENTS).add(String.format("%s-%s-%s", address, hospCode, nodeID));
    }

    public void delEndpoint(String address, String hospCode, String nodeID) {
        //hazelcast.getSet(String.format("%s-%s", address, hospCode)).remove(String.format("%s-%s", address, nodeID));

        hazelcast.getSet(EVENTS).remove(String.format("%s-%s", address, hospCode, nodeID));
    }

    @Override
    protected void doStart() throws Exception {
        ClientConfig cfg = getConfig();
        if (cfg == null) {
            log.warn("Cannot find cluster configuration on classpath. Using default hazelcast configuration");
        }
        cfg.addListenerConfig(new ListenerConfig(this));
        hazelcast = HazelcastClient.newHazelcastClient(cfg);
    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        return timeout;
    }

    @Override
    public void memberAdded(MembershipEvent event) {
        System.out.println("added: " + event);
        String nodeID = event.getMember().getUuid();
        if(hazelcast != null) {
            hazelcast.getSet(NODES).add(nodeID);
            if(event.getMembers().size() > hazelcast.getSet(NODES).size()) {
                hazelcast.getSet(NODES).addAll(event.getMembers().stream().map(m -> m.getUuid()).collect(Collectors.toList()));
            }
        }
    }

    @Override
    public void memberRemoved(MembershipEvent event) {
        System.out.println("removed: " + event);
        String nodeID = event.getMember().getUuid();
        if(hazelcast != null) hazelcast.getSet(NODES).remove(nodeID);
    }

    @Override
    public void memberAttributeChanged(MemberAttributeEvent event) {
        System.out.println("changed: " + event);
    }
}
