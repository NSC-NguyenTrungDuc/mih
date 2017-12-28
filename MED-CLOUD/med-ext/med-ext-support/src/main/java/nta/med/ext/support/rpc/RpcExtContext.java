package nta.med.ext.support.rpc;

import nta.med.common.glossary.Lifecycle;
import nta.med.common.remoting.rpc.context.RpcContext;
import nta.med.ext.support.glossary.EventMetaStore;

/**
 * 
 */
public interface RpcExtContext extends RpcContext {
	
	RpcExtSession getSession();

	boolean authenticate();

	interface Listener<T> extends Lifecycle {
		boolean subscribe();
		void onEvent(T event) throws InterruptedException;
		void setTracer(Tracer tracer);
	}

	interface Tracer {
		long lastEvent(EventMetaStore meta);
		void traceEvent(EventMetaStore meta, long eventID);
	}
}
