package nta.mss.model;

import java.util.List;
import java.util.Map;

import nta.mss.entity.Reservation;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.ReservationStatus;

import org.apache.commons.lang.StringUtils;

/**
 * The Class ReservationModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class ReservationModel extends BaseModel<Reservation> {
	private static final long serialVersionUID = 1L;
	private Integer reservationId;
	private String patientName;
	private String nameFurigana;
	private String phoneNumber;
	private String cardNumber;
	private String reservationCode;
	private Integer hospitalId;
	private String hospitalName;
	private Integer deptId;
	private Integer transactionId;
	private String deptName;
	private Integer doctorId;
	private String doctorName;
	private String reservationDate;
	private String reservationTime;
	private Integer reminderTime;
	private String email;
	private Integer reservationStatus;
	private Integer patientId;
	private String sessionId;
	private String regUser;
	private Integer activeFlg;
	private String referLink;
	//add for KCCK
	private String hospCode;
	private String locate;
	private String patientSex;
	private String patientBirtday;
	private String departmentCode;
	private String departCode;
	private Integer deptType;

	
	
	
	public Integer getDeptType() {
		return deptType;
	}

	public void setDeptType(Integer deptType) {
		this.deptType = deptType;
	}

	private String formattedReservationDate;
	private String formattedReservationTime;
	//add for search booking screen
	private String reservationFromDate;
	private String reservationToDate;
	private boolean cancelled;
	private String vaccineChildId;
	
	private List<ReservationModel> reservationModels;
	
	private Map<Integer, String> mapReminderTime;
	
	/**
	 * Instantiates a new reservation model.
	 */
	public ReservationModel() {
		super(Reservation.class);
	}
	
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	public String getNameFurigana() {
		return nameFurigana;
	}
	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}
	public String getPhoneNumber() {
		return phoneNumber;
	}
	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}
	public String getCardNumber() {
		return cardNumber;
	}
	public void setCardNumber(String cardNumber) {
		this.cardNumber = cardNumber;
	}
	public String getReservationCode() {
		return reservationCode;
	}
	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}
	public Integer getHospitalId() {
		return hospitalId;
	}
	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
	public String getHospitalName() {
		return hospitalName;
	}
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}
	public Integer getDeptId() {
		return deptId;
	}
	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}
	public String getDeptName() {
		return deptName;
	}
	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}
	public Integer getDoctorId() {
		return doctorId;
	}
	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getReservationDate() {
		return reservationDate;
	}
	public void setReservationDate(String reservationDate) {
		this.reservationDate = reservationDate;
	}
	public String getReservationTime() {
		return reservationTime;
	}
	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}

	public Integer getReminderTime() {
		return reminderTime;
	}

	public void setReminderTime(Integer reminderTime) {
		this.reminderTime = reminderTime;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public Integer getReservationStatus() {
		return reservationStatus;
	}

	public void setReservationStatus(Integer reservationStatus) {
		this.reservationStatus = reservationStatus;
	}

	public Integer getReservationId() {
		return reservationId;
	}

	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}

	public Integer getPatientId() {
		return patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	public String getSessionId() {
		return sessionId;
	}

	public void setSessionId(String sessionId) {
		this.sessionId = sessionId;
	}

	public String getRegUser() {
		return regUser;
	}

	public void setRegUser(String regUser) {
		this.regUser = regUser;
	}

	public Integer getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getReservationFromDate() {
		return reservationFromDate;
	}

	public void setReservationFromDate(String reservationFromDate) {
		this.reservationFromDate = reservationFromDate;
	}

	public String getReservationToDate() {
		return reservationToDate;
	}

	public void setReservationToDate(String reservationToDate) {
		this.reservationToDate = reservationToDate;
	}
	
	

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getLocate() {
		return locate;
	}

	public void setLocate(String locate) {
		this.locate = locate;
	}

	public String getPatientSex() {
		return patientSex;
	}

	public void setPatientSex(String patientSex) {
		this.patientSex = patientSex;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	/**
	 * Gets the formatted reservation date.
	 * 
	 * @return the formatted reservation date
	 */
	public String getFormattedReservationDate() {
		if (StringUtils.isBlank(formattedReservationDate)) {
			formattedReservationDate = MssDateTimeUtil.convertStringDateByLocale(reservationDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD, MssContextHolder.getLocale());
		}
		return formattedReservationDate;
	}

	public void setFormattedReservationDate(String formattedReservationDate) {
		this.formattedReservationDate = formattedReservationDate;
	}

	/**
	 * Gets the formatted reservation time.
	 * 
	 * @return the formatted reservation time
	 */
	public String getFormattedReservationTime() {
		if (StringUtils.isBlank(formattedReservationTime)) {
			formattedReservationTime = MssDateTimeUtil.convertStringTimeByLocale(reservationTime, DateTimeFormat.TIME_FORMAT_HH_MM, MssContextHolder.getLocale());
		}
		return formattedReservationTime;
	}

	public void setFormattedReservationTime(String formattedReservationTime) {
		this.formattedReservationTime = formattedReservationTime;
	}

	public boolean getCancelled() {
		this.cancelled = ReservationStatus.CANCELLED.toInt().equals(this.reservationStatus);
		return this.cancelled;
	}

	public void setCancelled(boolean cancelled) {
		this.cancelled = cancelled;
	}

	/**
	 * Gets the map reminder time.
	 *
	 * @return the map reminder time
	 */
	public Map<Integer, String> getMapReminderTime() {
		return mapReminderTime;
	}

	/**
	 * Sets the map reminder time.
	 *
	 * @param mapReminderTime the map reminder time
	 */
	public void setMapReminderTime(Map<Integer, String> mapReminderTime) {
		this.mapReminderTime = mapReminderTime;
	}

	/**
	 * @return the reservationModels
	 */
	public List<ReservationModel> getReservationModels() {
		return reservationModels;
	}

	/**
	 * @param reservationModels the reservationModels to set
	 */
	public void setReservationModels(List<ReservationModel> reservationModels) {
		this.reservationModels = reservationModels;
	}
	
	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	private String doctorCode;

	@Override
	public String toString() {
		return "ReservationModel [reservationId=" + reservationId
				+ ", patientName=" + patientName + ", reservationCode="
				+ reservationCode + ", hospitalId=" + hospitalId + ", deptId="
				+ deptId + ", doctorId=" + doctorId + ", reservationDate="
				+ reservationDate + ", reservationTime=" + reservationTime
				+ ", reminderTime=" + reminderTime + ", email=" + email
				+ ", patientId=" + patientId + ", sessionId=" + sessionId + "]";
	}

	public String getVaccineChildId() {
		return vaccineChildId;
	}

	public void setVaccineChildId(String vaccineChildId) {
		this.vaccineChildId = vaccineChildId;
	}

	public String getPatientBirtday() {
		return patientBirtday;
	}

	public void setPatientBirtday(String patientBirtday) {
		this.patientBirtday = patientBirtday;
	}

	public String getDepartCode() {
		return departCode;
	}

	public void setDepartCode(String departCode) {
		this.departCode = departCode;
	}
	public String getReferLink() {
		return referLink;
	}

	public void setReferLink(String referLink) {
		this.referLink = referLink;
	}

	public Integer getTransactionId() {
		return transactionId;
	}

	public void setTransactionId(Integer transactionId) {
		this.transactionId = transactionId;
	}
	
}
