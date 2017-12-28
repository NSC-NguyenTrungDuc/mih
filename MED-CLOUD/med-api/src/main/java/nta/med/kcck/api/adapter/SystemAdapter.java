package nta.med.kcck.api.adapter;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;

/**
 * @author dainguyen.
 */
public interface SystemAdapter {

    SystemServiceProto.LoginResponse authenticate(RpcApiSession session, SystemServiceProto.LoginRequest request);

    SystemServiceProto.GetIntegratedSystemResponse getIntegratedEnvironments(RpcApiSession session, SystemServiceProto.GetIntegratedSystemRequest request);
    
    PatientServiceProto.VerifyPatientAccountResponse verifyPatientAccount(RpcApiSession session, PatientServiceProto.VerifyPatientAccountRequest request);
    
    HospitalServiceProto.SearchHospitalResponse searchHospitals(RpcApiSession session, HospitalServiceProto.SearchHospitalRequest request);
    
    HospitalServiceProto.SearchHospitalInfoByHospCodeResponse searchHospitalByHospCode(RpcApiSession session, HospitalServiceProto.SearchHospitalInfoByHospCodeRequest request);

    PatientServiceProto.GetPatientResponse getPatient(RpcApiSession session, PatientServiceProto.GetPatientRequest request);

    PatientServiceProto.GetWaitingPatientResponse getWaitingPatient(RpcApiSession session, PatientServiceProto.GetWaitingPatientRequest request);
    
    HospitalServiceProto.VefiryAccountResponse vefiryAccount(RpcApiSession session, HospitalServiceProto.VefiryAccountRequest request);
}
