package nta.mss.service;

import java.util.List;
import java.util.Map;

import nta.kcck.model.KcckBookingSlotModel;
import nta.kcck.model.TimeslotScheduleModel;
import nta.mss.entity.DoctorSchedulePK;
import nta.mss.model.ReservationKpiModel;
import nta.mss.model.ReservationModel;
import nta.mss.model.ScheduleMailHistoryModel;

/**
 * The Interface IScheduleService.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
/**
 * @author Nextop
 *
 */
/**
 * @author Nextop
 *
 */
/**
 * @author Nextop
 *
 */
/**
 * @author Nextop
 *
 */
public interface IScheduleService {
	
	/**
	 * Gets the total reservation and kpi.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the total reservation and kpi
	 */
	Map<String, ReservationKpiModel> getTotalReservationAndKpi(Integer deptId, String startDate, String endDate);

	/**
	 * Check doctor schedule.
	 *
	 * @param doctorId the doctor id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the map
	 */
	Map<String, Boolean> checkDoctorSchedule(Integer doctorId, String startDate, String endDate);

	/**
	 * Check doctor schedule.
	 *
	 * @param doctorId the doctor id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the map
	 */
	TimeslotScheduleModel getDoctorTimeslotSchedule(Integer deptId, Integer doctorId, String startDate, String endDate);
	
	/**
	 * Update kpi for doctors by time slot.
	 *
	 * @param hospitalId the hospital id
	 * @param deptId the dept id
	 * @param doctorId the doctor id
	 * @param date the date
	 * @param time the time
	 * @param kpiPlus the kpi plus
	 * @param endTime the end time
	 * @return true, if successful
	 */
	boolean updateKpiForDoctorsByTimeSlot(Integer hospitalId, Integer deptId, Integer doctorId, String date, String time, Integer kpiPlus, String endTime);
	
	/**
	 * Gets the reservation by doctor and timeslot.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param checkDate
	 *            the check date
	 * @param startTime
	 *            the start time
	 * @return the reservation by doctor and timeslot
	 */
	List<ReservationModel> getReservationByDoctorAndTimeslot (Integer doctorId, String checkDate, String startTime);
	
	/**
	 * Gets the reservation in doctor and timeslot list.
	 *
	 * @param doctorSchedulePKList the doctor schedule pk list
	 * @return the reservation in doctor and timeslot list
	 */
	Map<DoctorSchedulePK, List<ReservationModel>> getReservationInDoctorAndTimeslotList (List<DoctorSchedulePK> doctorSchedulePKList);
	 
 	/**
	 * Gets the info search schedule mail history.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param reservationDate
	 *            the reservation date
	 * @return the info search schedule mail history
	 */
	List<ScheduleMailHistoryModel> getInfoSearchScheduleMailHistory(Integer hospitalId, Integer deptId, String fromDate, String toDate);
	
	/**
	 * Get reservation by doctor
	 * @param doctorId
	 * @return List reservation model
	 */
	List<ReservationModel> getReservationByDoctor(Integer doctorId);
	
	/**
	 * delete doctor
	 * @param doctorId
	 * @return
	 */
	boolean deleteDoctor(Integer doctorId);
	
	/**
	 * Check existing reservation of doctor.
	 *
	 * @param doctorId the doctor id
	 * @return true, if successful
	 */
	boolean existReservationOfDoctor(Integer doctorId);
	
	List<KcckBookingSlotModel> getDoctorScheduleFasterBySchedule(TimeslotScheduleModel model );
	TimeslotScheduleModel getScheduleCanBookingAsCurrentTime(TimeslotScheduleModel model );
	
	
}
