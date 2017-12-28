package nta.med.kcck.api.adapter;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;
import nta.med.kcck.api.rpc.proto.SystemServiceProto.GetEmrDataRequest;

/**
 * @author dainguyen.
 */
public interface EmrAdapter {

    SystemServiceProto.GetEmrDataResponse getEmrData(RpcApiSession session, GetEmrDataRequest request);
}
