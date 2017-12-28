package nta.med.kcck.api.rpc.service.system.impl;

import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

import nta.med.common.remoting.ServiceRestrictedException;
import nta.med.common.remoting.ServiceUnavailableException;
import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.kcck.api.adapter.EmrAdapter;
import nta.med.kcck.api.adapter.SystemAdapter;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;
import nta.med.kcck.api.rpc.proto.SystemServiceProto.GetMisTokenRequest;
import nta.med.kcck.api.rpc.proto.SystemServiceProto.GetMisTokenResponse;
import nta.med.kcck.api.rpc.service.AbstractRpcApiService;
import nta.med.kcck.api.rpc.service.system.SystemApiService;

/**
 * @author dainguyen.
 */
public class SystemApiServiceImpl extends AbstractRpcApiService implements SystemApiService {

	private static final Log LOGGER = LogFactory.getLog(SystemApiServiceImpl.class);
	
    @Resource
    SystemAdapter systemAdapter;
    
    @Resource
    EmrAdapter emrAdapter;
    
    public SystemApiServiceImpl() {
        super(SystemServiceProto.class, SystemServiceProto.getDescriptor());
    }

    @Override
    public boolean isCompatible(String s) {
        return true;
    }

    @RpcService(name = "LoginRequest", authenticate = false)
    public SystemServiceProto.LoginResponse authenticate(RpcApiSession session, SystemServiceProto.LoginRequest request) {
        SystemServiceProto.LoginResponse r =  systemAdapter.authenticate(session, request);
        return r;
    }

    @RpcService(name = "GetIntegratedSystemRequest", authenticate = true)
    public SystemServiceProto.GetIntegratedSystemResponse getEnvironments(RpcApiSession session, SystemServiceProto.GetIntegratedSystemRequest request) {
        if(!session.isAuthorized(request.getHospCode())) throw new ServiceRestrictedException();
        SystemServiceProto.GetIntegratedSystemResponse rp = systemAdapter.getIntegratedEnvironments(session, request);
        return rp;
    }
    
    @RpcService(name = "GetEmrDataRequest", authenticate = true)
    public SystemServiceProto.GetEmrDataResponse getEmrData(RpcApiSession session, SystemServiceProto.GetEmrDataRequest request) {
    	return emrAdapter.getEmrData(session, request);
    }

	@Override
	public GetMisTokenResponse getMisToken(GetMisTokenRequest request) throws Exception {
		LOGGER.info("Session Details: " + context.getSessions());
		for (RpcApiSession session : context.getSessions()) {
            if(session.isAuthorized(request.getHospCode()) && session.hasCapability(SystemServiceProto.LoginRequest.Capability.GET_MIS_TOKEN)) {
                FutureEx<Rpc.RpcMessage> res = session.invoke(RpcMessageBuilder.build(request, null));
                Rpc.RpcMessage r = res.get(30, TimeUnit.SECONDS);
                if(r != null) return parser.parse(r);
            }
        }
		
        throw new ServiceUnavailableException();
	}
}
