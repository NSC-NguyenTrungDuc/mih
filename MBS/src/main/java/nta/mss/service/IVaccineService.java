package nta.mss.service;

import java.util.Date;
import java.util.List;
import java.util.Map;

import nta.mss.info.BookingVaccineBackendInfo;
import nta.mss.info.ReminderBookingVaccineInfo;
import nta.mss.info.VaccineCdUsingInfo;
import nta.mss.info.VaccineDetailInfo;
import nta.mss.info.VaccineInfo;
import nta.mss.info.VaccineReportInfo;
import nta.mss.model.VaccineModel;


// TODO: Auto-generated Javadoc
/**
 * The Interface IVaccineService.
 */
public interface IVaccineService {

	/**
	 * Find by id.
	 *
	 * @param vaccineId the vaccine id
	 * @return the vaccine model
	 */
	VaccineModel findById(Integer vaccineId);

	/**
	 * Gets the vaccine recommend list.
	 *
	 * @param childId the child id
	 * @return the vaccine recommend list
	 */
	List<VaccineDetailInfo> getAllVaccineList(Integer childId, String hospitalCode);
	
	/**
	 * Gets the vaccine booking history list.
	 *
	 * @param childId the child id
	 * @return the vaccine booking history list
	 */
	List<VaccineDetailInfo> getVaccineBookingHistoryList(Integer childId, String hospitalCode);
	
	/**
	 * Gets the vaccine user history list.
	 *
	 * @param childId the child id
	 * @return the vaccine user history list
	 */
	List<VaccineDetailInfo> getVaccineUserHistoryList(Integer childId, String hospitalCode);
	
	/**
	 * Gets the all history vaccine list.
	 *
	 * @param bookingHistoryList the booking history list
	 * @param userHistoryList the user history list
	 * @return the all history vaccine list
	 */
	List<String> getAllHistoryVaccineList(List<VaccineDetailInfo> bookingHistoryList, List<VaccineDetailInfo> userHistoryList);
	
	/**
	 * Gets the vaccine cd using map.
	 *
	 * @param childId the child id
	 * @return the vaccine cd using map
	 */
	Map<String, VaccineCdUsingInfo> getVaccineCdUsingMap(Integer childId, String hospitalCode);
	
	/**
	 * Gets the reminder booking vaccine info.
	 *
	 * @return the reminder booking vaccine info
	 */
	List<ReminderBookingVaccineInfo> getReminderBookingVaccineInfo();
	
	/**
	 * Find vaccine by active flg.
	 *
	 * @param activeFlg the active flg
	 * @return the list
	 * @throws Exception the exception
	 */
	List<VaccineModel> findVaccineByActiveFlg(Integer activeFlg) throws Exception;
	
	/**
	 * Gets the vaccine report map.
	 *
	 * @param fromDate the from date
	 * @param toDate the to date
	 * @return the vaccine report map
	 */
	Map<VaccineReportInfo, VaccineReportInfo> getVaccineReportMap (Date fromDate, Date toDate, String hospitalCode);
	
	/**
	 * Find vaccine by vaccine status.
	 *
	 * @param vaccineStatus the vaccine status
	 * @return the list
	 * @throws Exception the exception
	 */
	List<VaccineModel> findVaccineByHospitalCode(String hospitalCode) throws Exception;
	
	/**
	 * Gets the information vaccine.
	 *
	 * @param vaccineId the vaccine id
	 * @param childId the child id
	 * @return the information vaccine
	 * @throws Exception the exception
	 */
	List<BookingVaccineBackendInfo> getInformationVaccine(Integer vaccineId, Integer childId) throws Exception;
	
	/**
	 * Gets the vaccine info list.
	 *
	 * @param hospitalCode the hospital code
	 * @return the vaccine info list
	 */
	List<VaccineInfo> getVaccineInfoList(String hospitalId, String locale);
	
	/**
	 * Gets the vaccine info by id.
	 *
	 * @param vaccineId the vaccine id
	 * @param hospitalCode the hospital code
	 * @return the vaccine info by id
	 */
	VaccineInfo getVaccineInfoById (Integer vaccineId, String hospitalCode);
}
