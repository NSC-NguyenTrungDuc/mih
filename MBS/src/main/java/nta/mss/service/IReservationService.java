package nta.mss.service;

import java.util.List;

import nta.kcck.model.KcckReservationModel;
import nta.mss.entity.InsuranceHistory;
import nta.mss.info.ReminderReservationCheduleInfo;
import nta.mss.info.ReservationOnlineInfo;

/**
 * 
 * @author DEV-HuanLT
 * IReservationService
 */
public interface IReservationService {

	public List<ReminderReservationCheduleInfo> getListReminderReservationCchedule(String schedulerTiming, String serverTimeZone);
	public List<InsuranceHistory> getListReservationByHospIdAndCardNumber(Integer hospId, String cardNumber,Integer startIndex, Integer pageSize,String columnSort, String typeOrder);
	public Integer getTotalRecordReservationByHospIdAndPatientId(Integer hospId, String cardNumber) ;
	
	public List<ReservationOnlineInfo> findReservationInfoByReCodeHosId(Integer hospId, List<String> reservationCodes);
	public String getMtCallingIdByReservationId(Integer reservationId);
	public KcckReservationModel getReservation(Integer reservationId, boolean surveyYN);
}
