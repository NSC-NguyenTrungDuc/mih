package nta.med.kcck.api.adapter;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public interface BassAdapter {

    public HospitalServiceProto.GetDepartmentResponse getDepartmentByHospitalCode(RpcApiSession session, HospitalServiceProto.GetDepartmentRequest request);
    
    public HospitalServiceProto.UpdateDefaultScheduleResponse updateDefaultSchedule(RpcApiSession session, HospitalServiceProto.UpdateDefaultScheduleRequest request);
}
