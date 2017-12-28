package nta.mss.service;

import java.util.Collection;
import java.util.List;
import java.util.Map;

import javax.persistence.EntityNotFoundException;

import nta.mss.entity.Session;
import nta.mss.entity.Transaction;
import nta.mss.info.BookingInfo;
import nta.mss.info.ReservationInfo;
import nta.mss.model.MailTemplateModel;
import nta.mss.model.PatientModel;
import nta.mss.model.ReservationModel;
import nta.mss.model.SessionModel;

/**
 * The Interface IBookingService.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public interface IBookingService {
	
	/**
	 * Find reservation by session id.
	 * 
	 * @param sessionId
	 *            the session id
	 * @return the reservation model
	 */
	ReservationModel findReservationBySessionId(String sessionId);
	
	/**
	 * Find Kcck reservation by session id.
	 * 
	 * @param sessionId
	 *            the session id
	 * @return the reservation model
	 */
	ReservationModel findKcckReservationBySessionId(String sessionId);
	/**
	 * Find reservation by id.
	 * 
	 * @param reservationId
	 *            the reservation id
	 * @return the reservation model
	 */
	ReservationModel findReservationById(Integer reservationId);
	
	/**
	 * Find reservation in id list.
	 *
	 * @param reservationIdList the reservation id list
	 * @return the list
	 */
	List<ReservationModel> findReservationInIdList(Collection<Integer> reservationIds);
	
	/**
	 * Cancel reservation.
	 *
	 * @param reservationId the reservation id
	 * @throws EntityNotFoundException the entity not found exception
	 */
	ReservationModel cancelReservation(Integer reservationId) throws EntityNotFoundException;
	
	/**
	 * Save patient info.
	 *
	 * @param bookingInfo            the booking info
	 * @param reservationMode            the reservation mode
	 * @param hospitalId            the hospital id
	 * @param isBackendBooking the is backend booking
	 * @return the reservation model
	 * @throws Exception             the exception
	 */
	ReservationModel savePatientInfo(BookingInfo bookingInfo, Integer reservationMode,Integer hospitalId, boolean isBackendBooking, Long profileId, Transaction transaction) throws Exception;
	
	/**
	 * Find one patient by card number.
	 * 
	 * @param cardNumber
	 *            the card number
	 * @return the patient model
	 */
	PatientModel findOnePatientByCardNumber(String cardNumber, Integer hospitalId);
	
	/**
	 * Find time current pending status.
	 * 
	 * @param reservationtime
	 *            the reservationtime
	 * @param deptId
	 *            the dept id
	 * @return the string
	 */
	String findTimeCurrentPendingStatus(String reservationtime, Integer deptId);
	
	/**
	 * Gets the late time pending.
	 * 
	 * @param diffirentTime
	 *            the diffirent time
	 * @return the late time pending
	 */
	String getLateTimePending(long diffirentTime, String locale);
	
	/**
	 * Save session.
	 * 
	 * @param sessionId
	 *            the session id
	 * @return the session
	 */
	Session saveSession(String sessionId);
	
	/**
	 * Gets the session by id.
	 *
	 * @param sessionId the session id
	 * @return the session by id
	 */
	SessionModel getSessionById(String sessionId);
	
	/**
	 * Gets the latest reservation by email.
	 * 
	 * @param email
	 *            the email
	 * @return the latest reservation by email
	 */
	List<ReservationModel> getReservationListByEmail(String email, Integer hospitalId) ;
	
	/**
	 * Save token into reservation.
	 * 
	 * @param email
	 *            the email
	 * @param sessionId
	 *            the session id
	 * @return true, if successful
	 */
	boolean saveTokenIntoReservation(Integer reservationId, String sessionId) ;
	
	/**
	 * Update reservation.
	 * 
	 * @param reservationModel
	 *            the reservation model
	 */
	void updateReservation(ReservationModel reservationModel);
	
	/**
	 * Gets the latest reservation by patient id.
	 * 
	 * @param patientId
	 *            the patient id
	 * @param limit
	 *            the limit
	 * @return the latest reservation by patient id
	 */
	List<ReservationModel> getLatestReservationByPatientId(Integer patientId, Integer limit);
	
	/**
	 * Gets the reservations by doctor and time slot.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param startTime
	 *            the start time
	 * @return the reservations by doctor and time slot
	 */
	List<ReservationModel> getReservationsByDoctorAndTimeSlot(Integer doctorId, String startDate, String startTime);
	
	/**
	 * search reservation by condition
	 * @param reservationModel
	 * @return the reservations suitable
	 */
	List<ReservationModel> searchReservation(ReservationModel reservationModel);
	
	/**
	 * update reservation status
	 * @param reservationModel
	 * @return
	 */
	boolean updateReservationStatus(ReservationModel reservationModel);
	/**
	 * 
	 * @param token
	 * @param mailTemplateId
	 * @return
	 */
	boolean updateReadingFlag(String token, Integer mailTemplateId);
	
	/**
	 * 
	 * @param mailTemplateCode
	 * @param locale
	 * @return
	 */
	MailTemplateModel getMailTemplateByCode(String mailTemplateCode, String locale, Integer hospitalId);
	
	/**
	 * Cancel reservation in id list.
	 *
	 * @param reservationIdList the reservation id list
	 * @return true, if successful
	 */
	boolean cancelReservationInIdList(Collection<Integer> reservationIdList);
	
	/**
	 * Update doctor reservation by id.
	 *
	 * @param reservationMap the reservation map
	 * @return true, if successful
	 */
	boolean updateDoctorReservationById(Map<Integer, Integer> reservationMap);
	
	/**
	 * Update doctor for reservation.
	 *
	 * @param doctorId the doctor id
	 * @param reservationId the reservation id
	 * @throws Exception the exception
	 */
	public void updateDoctorForReservation(Integer doctorId, Integer reservationId) throws Exception;
	
	/**
	 * Search reservation info.
	 *
	 * @param reservationModel the reservation model
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<ReservationInfo> searchReservationInfo(ReservationModel reservationModel) throws Exception;
	
	public PatientModel updatePatient(int id, String patientCode, String kcckParentCode);
	
	/**
	 * Get a patient by cardnumber - use for KCCK - MSS
	 */	
	PatientModel findKcckPatientByCardNumber(String cardNumber, Integer hospitalId);
	
	public List<ReservationModel> getListLatestReservationByPatientId(Integer patientId,Integer hospitalId, Integer limit);
	
	public ReservationModel findKcckReservationById(Integer reservationId);
	
	PatientModel findPatientById(Integer id);
	
	public PatientModel getParentByChildId(Integer childId);
	
	public String getChildCodeList(String kcckParentCode);
}
