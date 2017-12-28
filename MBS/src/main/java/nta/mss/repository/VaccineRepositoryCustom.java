package nta.mss.repository;

import java.util.Date;
import java.util.List;

import nta.mss.info.BookingVaccineBackendInfo;
import nta.mss.info.ReminderBookingVaccineInfo;
import nta.mss.info.VaccineCdUsingInfo;
import nta.mss.info.VaccineDetailInfo;
import nta.mss.info.VaccineInfo;
import nta.mss.info.VaccineReportInfo;

/**
 * The Interface VaccineRepositoryCustom.
 *
 * @author MinhLS
 * @crtDate 2015/01/28
 */
public interface VaccineRepositoryCustom {
	
	List<VaccineDetailInfo> getAllVaccineList(Integer childId, String hospitalCode);
	List<VaccineDetailInfo> getVaccineHistoryList(Integer childId, Boolean isBookingHistory, String hospitalCode);
	List<VaccineCdUsingInfo> getVaccineCdUsingList(Integer childId, String hospitalCode);
	List<ReminderBookingVaccineInfo> getReminderBookingVaccineInfo();
	List<VaccineReportInfo> getVaccineReport(Date fromDate, Date toDate, String hospitalCode);
	List<BookingVaccineBackendInfo> getInformationVaccine(Integer vaccineId, Integer childId);
	List<VaccineInfo> getVaccineInfoList(Integer vaccineInfo, String hospitalId, String locale);
}
