package nta.med.ext.support.service.hospital;

import nta.med.ext.support.proto.HospitalServiceProto;
import nta.med.ext.support.proto.SystemServiceProto;

/**
 * @author dainguyen.
 */
public interface HospitalRpcService {

    HospitalServiceProto.GetDepartmentResponse getDepartment(HospitalServiceProto.GetDepartmentRequest request);

    HospitalServiceProto.GetDoctorByDepartmentResponse getDoctors(HospitalServiceProto.GetDoctorByDepartmentRequest request);

    HospitalServiceProto.SearchDoctorResponse searchDoctors(HospitalServiceProto.SearchDoctorRequest request);

    HospitalServiceProto.SearchHospitalResponse searchHospitals(HospitalServiceProto.SearchHospitalRequest request);
    
    HospitalServiceProto.SubscribeHospitalEventResponse subscribeHospital(HospitalServiceProto.SubscribeHospitalEventRequest request);

    HospitalServiceProto.SearchBookingScheduleResponse getScheduleDoctor(HospitalServiceProto.SearchBookingScheduleRequest request);
    
    HospitalServiceProto.SearchHospitalInfoByHospCodeResponse searchHospitalInfoByHospCode(HospitalServiceProto.SearchHospitalInfoByHospCodeRequest request);
    
    HospitalServiceProto.VefiryAccountResponse vefiryAccount(HospitalServiceProto.VefiryAccountRequest request);
    
    HospitalServiceProto.UpdateDefaultScheduleResponse updateDefaultSchedule(HospitalServiceProto.UpdateDefaultScheduleRequest request);

    HospitalServiceProto.GetDoctorInfoResponse getDoctorFromSession(HospitalServiceProto.GetDoctorInfoRequest request );
}
