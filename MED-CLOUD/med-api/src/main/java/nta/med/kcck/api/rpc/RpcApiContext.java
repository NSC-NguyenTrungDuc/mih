package nta.med.kcck.api.rpc;

import nta.med.common.remoting.rpc.context.RpcContext;

import java.util.Collection;

/**
 * @author dainguyen.
 */
public interface RpcApiContext extends RpcContext {
    RpcApiSession getSession(long id);

    //Iterator<RpcApiSession> sessions();

    Collection<RpcApiSession> getSessions();
}
