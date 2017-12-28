package nta.med.ext.support.rpc;

import nta.med.common.remoting.rpc.context.RpcSession;

/**
 * 
 */
public interface RpcExtSession extends RpcSession {

	String getLoginId();

	void logout(boolean force);

	void login(String loginId);
}
