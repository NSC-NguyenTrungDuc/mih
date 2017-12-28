package nta.med.kcck.api.rpc.service.system;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;

/**
 * @author dainguyen.
 */
public interface SystemApiService {
    SystemServiceProto.LoginResponse authenticate(RpcApiSession session, SystemServiceProto.LoginRequest request);

    SystemServiceProto.GetIntegratedSystemResponse getEnvironments(RpcApiSession session, SystemServiceProto.GetIntegratedSystemRequest request);
    
    SystemServiceProto.GetEmrDataResponse getEmrData(RpcApiSession session, SystemServiceProto.GetEmrDataRequest request);
    
    SystemServiceProto.GetMisTokenResponse getMisToken(SystemServiceProto.GetMisTokenRequest request) throws Exception;
}
