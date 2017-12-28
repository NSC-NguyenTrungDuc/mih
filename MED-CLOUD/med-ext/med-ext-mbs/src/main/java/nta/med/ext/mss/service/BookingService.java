package nta.med.ext.mss.service;

import java.util.List;

import nta.med.data.model.ihis.nuro.KCCKGetDoctorWorkingTimeInfo;
import nta.med.ext.mss.model.AccountModel;
import nta.med.ext.mss.model.BookingModel;
import nta.med.ext.mss.model.CancelBookingModel;
import nta.med.ext.mss.model.ChangeBookingModel;
import nta.med.ext.mss.model.DoctorModel;
import nta.med.ext.mss.model.SearchDoctorModel;

/**
 * @author dainguyen.
 */
public interface BookingService {

    List<DoctorModel> findDoctorByDepartment(String hospCode, String departmentCode);
    List<KCCKGetDoctorWorkingTimeInfo> getDoctorScheduleInfo(String hospitalCode, String departmentCode, String examPreDate, String endDate, String doctorCode, String avgTime, String doctorGrade);
    SearchDoctorModel searchDoctors(SearchDoctorModel searchDoctorModel);
	BookingModel bookingExamination(BookingModel bookingModel);
	CancelBookingModel cancelBookingExamination(CancelBookingModel cancelModel);
	ChangeBookingModel changeBookingExamination(ChangeBookingModel changeBooking);
	AccountModel verifyAccount(AccountModel model);
	DoctorModel getDoctorFromSession(String sessionId);
}
