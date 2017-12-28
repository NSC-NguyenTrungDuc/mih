package nta.med.ext.support.service.system;

import java.util.List;

import nta.med.ext.support.glossary.Capability;
import nta.med.ext.support.proto.SystemServiceProto;

/**
 * @author dainguyen.
 */
public interface SystemRpcService {

    boolean authenticate(String hospCode, String login, String password);

    boolean authenticate(String hospCode, String login, String password, List<Capability> capabilities);

    SystemServiceProto.GetIntegratedSystemResponse getEnvironments(SystemServiceProto.GetIntegratedSystemRequest request);

    SystemServiceProto.GetEmrDataResponse getEmrData(SystemServiceProto.GetEmrDataRequest request);
    
    interface Service {
        SystemServiceProto.GetMisTokenResponse getMisToken(SystemServiceProto.GetMisTokenRequest request) throws Exception;
    }
    
}
