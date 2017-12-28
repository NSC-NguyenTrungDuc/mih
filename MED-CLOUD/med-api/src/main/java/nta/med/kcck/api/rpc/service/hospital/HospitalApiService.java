package nta.med.kcck.api.rpc.service.hospital;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;

/**
 * @author dainguyen.
 */
public interface HospitalApiService {

    HospitalServiceProto.GetDepartmentResponse getDepartment(RpcApiSession session, HospitalServiceProto.GetDepartmentRequest request);

    HospitalServiceProto.GetDoctorByDepartmentResponse getDoctors(RpcApiSession session, HospitalServiceProto.GetDoctorByDepartmentRequest request);

    HospitalServiceProto.SearchDoctorResponse searchDoctors(RpcApiSession session, HospitalServiceProto.SearchDoctorRequest request);

    HospitalServiceProto.SearchHospitalResponse searchHospitals(RpcApiSession session, HospitalServiceProto.SearchHospitalRequest request);
    
    HospitalServiceProto.SubscribeHospitalEventResponse subscribeHospital(RpcApiSession session, HospitalServiceProto.SubscribeHospitalEventRequest request);
    
    HospitalServiceProto.SearchBookingScheduleResponse searchDoctorSchedule(RpcApiSession session, HospitalServiceProto.SearchBookingScheduleRequest request);
    
    HospitalServiceProto.SearchHospitalInfoByHospCodeResponse searchHospitalByHospCode(RpcApiSession session, HospitalServiceProto.SearchHospitalInfoByHospCodeRequest request);

    HospitalServiceProto.VefiryAccountResponse vefiryAccount(RpcApiSession session, HospitalServiceProto.VefiryAccountRequest request) throws Exception;
    
    HospitalServiceProto.UpdateDefaultScheduleResponse updateDefaultSchedule(RpcApiSession session, HospitalServiceProto.UpdateDefaultScheduleRequest request);

    HospitalServiceProto.GetDoctorInfoResponse getDoctorFromSession(RpcApiSession session, HospitalServiceProto.GetDoctorInfoRequest request);
}
