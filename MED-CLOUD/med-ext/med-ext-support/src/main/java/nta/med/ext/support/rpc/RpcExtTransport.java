package nta.med.ext.support.rpc;

import nta.med.common.remoting.rpc.message.RpcMessageMarshaller;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.remoting.rpc.transport.RpcTransport;
import nta.med.common.remoting.rpc.transport.oio.RpcOioTransport;
import nta.med.common.remoting.rpc.transport.oio.RpcOioTransportFactory;
import nta.med.common.util.concurrent.executor.XExecutors;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.TimeUnit;

/**
 * @author dainguyen.
 */
public class RpcExtTransport extends RpcOioTransport<Rpc.RpcMessage> {

    protected final ExecutorService exec;

    public RpcExtTransport(String name) {
        super(name);
        this.exec = XExecutors.create(this.name + ".exec", 2);
    }

    @Override
    protected void doStart() throws Exception {
        super.doStart();
    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        return super.doStop(timeout, unit);
    }

    @Override
    public String toString() {
        return new StringBuilder()
            .append("RpcExtTransport[")
            .append("id=").append(this.id)
            .append(",la=").append(getLocalAddress())
            .append(",ra=").append(getRemoteAddress()).append("]").toString();
    }

    @Override
    protected void notifyOnMessage(Rpc.RpcMessage message) {
        exec.execute(() -> super.notifyOnMessage(message));
    }

    public static class FactoryImpl extends RpcOioTransportFactory<Rpc.RpcMessage> {
        @Override
        public RpcTransport<Rpc.RpcMessage> create(Object id) {
            String name = "rpc.transport-" + id;
            final RpcExtTransport r = new RpcExtTransport(name);
            r.setSocketFactory(socketFactory);
            if(this.connectTimeout > 0L) r.setConnectTimeout(this.connectTimeout);
            if(this.reconnectInterval > 0L) r.setReconnectInterval(this.reconnectInterval);
            r.setMarshaller(this.marshaller != null ? marshaller : new RpcMessageMarshaller());
            r.setVerbose(verbose); r.setPort(this.port); r.setHost(this.host);
            return r;
        }
    }
}
