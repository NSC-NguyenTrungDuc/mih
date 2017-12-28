package nta.med.ext.support.service.system.impl;

import nta.med.common.remoting.ServiceExecutionException;
import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.ext.support.glossary.Capability;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.proto.SystemServiceProto;
import nta.med.ext.support.rpc.RpcExtSession;
import nta.med.ext.support.service.AbstractRpcExtService;
import nta.med.ext.support.service.patient.PatientRpcService;
import nta.med.ext.support.service.patient.PatientRpcService.Service;
import nta.med.ext.support.service.system.SystemRpcService;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import java.util.Collections;
import java.util.List;

/**
 * @author dainguyen.
 */
public class SystemRpcServiceImpl extends AbstractRpcExtService implements SystemRpcService {

    private static final Logger LOGGER = LoggerFactory.getLogger(SystemRpcServiceImpl.class);

    private SystemRpcService.Service service;
    
    public SystemRpcServiceImpl() {
        super("api.system", SystemServiceProto.class, SystemServiceProto.getDescriptor());
    }

    @Override
    public boolean isCompatible(String version) {
        return true;
    }

    @Override
    public boolean authenticate(String hospCode, String login, String password) {
        return authenticate(hospCode, login, password, Collections.emptyList());
    }

    @Override
    public boolean authenticate(String hospCode, String login, String password, List<Capability> capabilities) {
        try {
            final SystemServiceProto.LoginRequest.Builder builder = SystemServiceProto.LoginRequest.newBuilder()
                    .setLoginId(login)
                    .setPassword(password).setHospCode(hospCode);
            if(capabilities != null) for (Capability cp : capabilities) builder.addCapability(cp.toProto());
            SystemServiceProto.LoginRequest request = builder.build();
            LOGGER.info("authenticate Request: " + request);
            final SystemServiceProto.LoginResponse response = invoke(request, 10000L, false);
            LOGGER.info("authenticate Response: " + response);
            return response != null && SystemServiceProto.LoginResponse.Result.SUCCESS.equals(response.getResult());
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return false;
        }
    }

    @Override
    public SystemServiceProto.GetIntegratedSystemResponse getEnvironments(SystemServiceProto.GetIntegratedSystemRequest request) {
        return invoke(request, 10000L, true);
    }
    
    @Override
	public SystemServiceProto.GetEmrDataResponse getEmrData(SystemServiceProto.GetEmrDataRequest request) {
		 return invoke(request, 10000L, true);
	}
    
    @RpcService(name = "GetMisTokenRequest")
    public SystemServiceProto.GetMisTokenResponse getMisToken(RpcExtSession session, SystemServiceProto.GetMisTokenRequest request) {
        if(service != null) try {
            return service.getMisToken(request);
        } catch (Exception e) {
            LOGGER.warn("fail to invoke getMisToken, request = " + format(request));
        }
        throw new ServiceExecutionException();
    }
    
    public void setService(Service service) {
        this.service = service;
    }

}
