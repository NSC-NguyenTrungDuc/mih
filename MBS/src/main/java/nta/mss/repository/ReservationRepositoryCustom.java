package nta.mss.repository;

import java.util.Date;
import java.util.List;
import java.util.Map;

import nta.kcck.info.KcckReservationInfo;
import nta.mss.entity.InsuranceHistory;
import nta.mss.entity.Reservation;
import nta.mss.info.ReminderReservationCheduleInfo;
import nta.mss.info.ReservationInfo;
import nta.mss.info.ReservationOnlineInfo;
import nta.mss.model.ReservationModel;

/**
 *
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 *
 */
public interface ReservationRepositoryCustom {
	List<Reservation> searchByCondition(ReservationModel reservationModel);

	boolean updateDoctorReservationById(Map<Integer, Integer> reservationMap);
	
	public List<Object[]> searchInfoScheduleMailHistory(Integer deptId, Date fromDate, Date toDate);
	
	public void updateDoctorForReservation(Integer doctorId, Integer reservationId);
	
	public List<ReservationInfo> searchReservationInfoByCondition(ReservationModel reservationModel);
	
	public List<ReservationInfo> searchReservationInfoByChildId(Integer childId);

	public List<ReminderReservationCheduleInfo> getReminderReservationCcheduleInfo(String schedulerTiming, String serverTimeZone);
	
	public KcckReservationInfo  findKcckReservationBySessionId(String sessionId);
	
	public KcckReservationInfo  findKcckReservationById(Integer reservationId);
	
	public List<KcckReservationInfo> findKcckReservationByPatientId(Integer patientId, Integer hospitalId, Integer limit);
	
	public List<InsuranceHistory> findReservationByHospIdAndPatientId(Integer hospId,String cardNumber,Integer startIndex, Integer pageSize,String columnSort, String typeOrder);
	
	public Integer  getTotalRecordReservationByHospIdAndPatientId(Integer hospId,String cardNumber);
	
	public List<ReservationOnlineInfo> findReservationInfoByReCodeHosId(Integer hospId, List<String> reservationCodes);
	
	public String getMtCallingIdByReservationId(Integer reservationId);

	
	
}
