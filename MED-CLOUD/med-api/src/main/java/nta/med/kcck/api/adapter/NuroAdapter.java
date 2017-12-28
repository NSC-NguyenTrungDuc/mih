package nta.med.kcck.api.adapter;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.BookingServiceProto;
import nta.med.kcck.api.rpc.proto.BookingServiceProto.CancelBookingExaminationRequest;
import nta.med.kcck.api.rpc.proto.BookingServiceProto.CancelBookingExaminationResponse;
import nta.med.kcck.api.rpc.proto.BookingServiceProto.ChangeBookingExaminationRequest;
import nta.med.kcck.api.rpc.proto.BookingServiceProto.ChangeBookingExaminationResponse;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;

/**
 * @author dainguyen.
 */
public interface NuroAdapter {
//	List<KCCKGetDoctorWorkingTimeInfo> getKCCKGetScheduleDoctorInfo(String hospitalCode, String departmentCode, String examPreDate, String endDate, String doctorCode, String avgTime);

	HospitalServiceProto.GetDoctorByDepartmentResponse getDoctorByDepartment(RpcApiSession session, HospitalServiceProto.GetDoctorByDepartmentRequest request);

	HospitalServiceProto.SearchDoctorResponse searchDoctors(RpcApiSession session, HospitalServiceProto.SearchDoctorRequest request);

	BookingServiceProto.BookingExaminationResponse bookingExamination(RpcApiSession session, BookingServiceProto.BookingExaminationRequest request);

	BookingServiceProto.BookingExaminationResponse booking(RpcApiSession session, BookingServiceProto.BookingExaminationRequest request);

	PatientServiceProto.SearchPatientResponse searchPatient(RpcApiSession session, PatientServiceProto.SearchPatientRequest request);
	
	PatientServiceProto.SyncPatientResponse syncPatient(RpcApiSession session, PatientServiceProto.SyncPatientRequest request);
	
	PatientServiceProto.SyncExaminationResponse syncExamination(RpcApiSession session, PatientServiceProto.SyncExaminationRequest request);
	
	PatientServiceProto.SyncReservationResponse syncReservation(RpcApiSession session, PatientServiceProto.SyncReservationRequest request);

	ChangeBookingExaminationResponse changeBookingExamination(RpcApiSession session, ChangeBookingExaminationRequest request);

	CancelBookingExaminationResponse cancelBookingExamination(RpcApiSession session, CancelBookingExaminationRequest request);

	HospitalServiceProto.SearchBookingScheduleResponse searchDoctorSchedule(RpcApiSession session, HospitalServiceProto.SearchBookingScheduleRequest request);
}
