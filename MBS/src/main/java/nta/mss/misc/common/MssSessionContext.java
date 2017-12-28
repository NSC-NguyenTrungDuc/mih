package nta.mss.misc.common;

import java.io.Serializable;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import nta.kcck.model.KcckBookingSlotModel;
import nta.kcck.model.KcckOrderMedicineModel;
import nta.kcck.model.KcckPaymentInfoModel;
import nta.mss.info.BookingInfo;
import nta.mss.info.HospitalDto;
import nta.mss.info.ScheduleInfo;
import nta.mss.info.VaccineReportInfo;
import nta.mss.model.*;

// TODO: Auto-generated Javadoc
/**
 * The Class MssSessionContext.
 *
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MssSessionContext implements Serializable {

	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 3570571102529580094L;

	/** The user language. */
	private String userLanguage;

	/** The locale. */
	private Locale locale;

	/** The session mode. */
	private Integer sessionMode;

	/** The reservation mode. */
	private Integer reservationMode;

	/** The hospital id. */
	private Integer hospitalId;

	/** The hospital name. */
	private String hospitalName;

	/** The booking info. */
	private BookingInfo bookingInfo;

	/** The schedule info. */
	private ScheduleInfo scheduleInfo;

	/** The user. */
	private UserModel user;

	/** The dept id. */
	private Integer deptId;

	private String deptCode;

	/** The vaccine report. */
	private Map<String, List<VaccineReportInfo>> vaccineReport;

	/** The vaccine list. */
	private List<VaccineModel> vaccineList;


	private Integer hospitalParentId;

	private Integer isUseSms;

	private String hospitalIconPath;

	private String tokenHospCode;

	private String hospCode;

	private String hospitalLocale;

	private String hospitalEmail;

	private String domainName;

	private String patientName;

	private String doctorName;

	private byte timeZone;

	private byte isUseVaccine;
	//Allow hospital using movie talk
	private byte isUseMt;

	private String mode;

	/** KCCK Model */
	private List<DepartmentModel> departmentList;
	private List<DoctorModel> doctorList;
	private List<KcckBookingSlotModel> kcckBookingSlots;
	private ReservationModel reservationModel;
	private Integer autoRecept;

	private HospitalDto hospital;
	private String doctorCode;
	private String patientCode;
	private String userToken;
	private Long masterProfileId;
	private String phrDeviceToken;
	private String facebookId;


	/**Tracking script */
	private List<HospitalTrackingModel> trackingList;


	public List<HospitalTrackingModel> getTrackingList() {
		return trackingList;
	}

	public void setTrackingList(List<HospitalTrackingModel> trackingList) {
		this.trackingList = trackingList;
	}

	/**Payment feature */
	private PaymentInfoModel paymentInfo;
	private List<OrderMedicineModel> orderMedicines;
	/**Set user ID when login backend*/
	private String userBack;

	/**
	 * Gets the user language.
	 *
	 * @return the user language
	 */
	public String getUserLanguage() {
		return userLanguage;
	}

	/**
	 * Sets the user language.
	 *
	 * @param userLanguage
	 *            the new user language
	 */
	public void setUserLanguage(String userLanguage) {
		this.userLanguage = userLanguage;
	}

	/**
	 * Gets the locale.
	 *
	 * @return the locale
	 */
	public Locale getLocale() {
		return locale;
	}

	/**
	 * Sets the locale.
	 *
	 * @param locale
	 *            the new locale
	 */
	public void setLocale(Locale locale) {
		this.locale = locale;
	}

	/**
	 * Gets the session mode.
	 *
	 * @return the session mode
	 */
	public Integer getSessionMode() {
		return sessionMode;
	}

	/**
	 * Sets the session mode.
	 *
	 * @param sessionMode
	 *            the new session mode
	 */
	public void setSessionMode(Integer sessionMode) {
		this.sessionMode = sessionMode;
	}

	/**
	 * Removes the session mode.
	 */
	public void removeSessionMode() {
		this.sessionMode = null;
	}

	/**
	 * Gets the reservation mode.
	 *
	 * @return the reservation mode
	 */
	public Integer getReservationMode() {
		return reservationMode;
	}

	/**
	 * Sets the reservation mode.
	 *
	 * @param reservationMode
	 *            the new reservation mode
	 */
	public void setReservationMode(Integer reservationMode) {
		this.reservationMode = reservationMode;
	}

	/**
	 * Removes the reservation mode.
	 */
	public void removeReservationMode() {
		this.reservationMode = null;
	}

	/**
	 * Gets the hospital id.
	 *
	 * @return the hospital id
	 */
	public Integer getHospitalId() {
		return hospitalId;
	}

	/**
	 * Sets the hospital id.
	 *
	 * @param hospitalId
	 *            the new hospital id
	 */
	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	/**
	 * Removes the hospital id.
	 */
	public void removeHospitalId() {
		this.hospitalId = null;
	}

	/**
	 * Gets the hospital name.
	 *
	 * @return the hospital name
	 */
	public String getHospitalName() {
		return hospitalName;
	}

	/**
	 * Sets the hospital name.
	 *
	 * @param hospitalName
	 *            the new hospital name
	 */
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}

	/**
	 * Removes the hospital name.
	 */
	public void removeHospitalName() {
		this.hospitalName = null;
	}

	/**
	 * Gets the booking info.
	 *
	 * @return the booking info
	 */
	public BookingInfo getBookingInfo() {
		return bookingInfo;
	}

	/**
	 * Sets the booking info.
	 *
	 * @param bookingInfo
	 *            the new booking info
	 */
	public void setBookingInfo(BookingInfo bookingInfo) {
		this.bookingInfo = bookingInfo;
	}

	/**
	 * Gets the schedule info.
	 *
	 * @return the schedule info
	 */
	public ScheduleInfo getScheduleInfo() {
		return scheduleInfo;
	}

	/**
	 * Sets the schedule info.
	 *
	 * @param scheduleInfo the new schedule info
	 */
	public void setScheduleInfo(ScheduleInfo scheduleInfo) {
		this.scheduleInfo = scheduleInfo;
	}

	/**
	 * Removes the booking info.
	 */
	public void removeBookingInfo() {
		this.bookingInfo = null;
	}

	/**
	 * Gets the user.
	 *
	 * @return the user
	 */
	public UserModel getUser() {
		return user;
	}

	/**
	 * Sets the user.
	 *
	 * @param user the new user
	 */
	public void setUser(UserModel user) {
		this.user = user;
	}

	/**
	 * Gets the dept id.
	 *
	 * @return the dept id
	 */
	public Integer getDeptId() {
		return deptId;
	}

	/**
	 * Sets the dept id.
	 *
	 * @param deptId the new dept id
	 */
	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}
	public void setDeptCode(String deptCode) {
		this.deptCode = deptCode;
	}
	public String getDeptCode() {
		return deptCode;
	}

	/**
	 * Gets the vaccine report.
	 *
	 * @return the vaccine report
	 */
	public Map<String, List<VaccineReportInfo>> getVaccineReport() {
		return vaccineReport;
	}

	/**
	 * Sets the vaccine report.
	 *
	 * @param vaccineReport the vaccine report
	 */
	public void setVaccineReport(Map<String, List<VaccineReportInfo>> vaccineReport) {
		this.vaccineReport = vaccineReport;
	}

	/**
	 * Gets the vaccine list.
	 *
	 * @return the vaccine list
	 */
	public List<VaccineModel> getVaccineList() {
		return vaccineList;
	}

	/**
	 * Sets the vaccine list.
	 *
	 * @param vaccineList the new vaccine list
	 */
	public void setVaccineList(List<VaccineModel> vaccineList) {
		this.vaccineList = vaccineList;
	}

	public Integer getHospitalParentId() {
		return hospitalParentId;
	}

	public void setHospitalParentId(Integer hospitalParentId) {
		this.hospitalParentId = hospitalParentId;
	}


	public Integer getIsUseSms() {
		return isUseSms;
	}

	public void setIsUseSms(Integer isUseSms) {
		this.isUseSms = isUseSms;
	}

	public String getHospitalIconPath() {
		return hospitalIconPath;
	}

	public void setHospitalIconPath(String hospitalIconPath) {
		this.hospitalIconPath = hospitalIconPath;
	}

	public String getTokenHospCode() {
		return tokenHospCode;
	}

	public void setTokenHospCode(String tokenHospCode) {
		this.tokenHospCode = tokenHospCode;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getHospitalLocale() {
		return hospitalLocale;
	}

	public void setHospitalLocale(String hospitalLocale) {
		this.hospitalLocale = hospitalLocale;
	}

	public String getHospitalEmail() {
		return hospitalEmail;
	}

	public void setHospitalEmail(String hospitalEmail) {
		this.hospitalEmail = hospitalEmail;
	}

	public String getDomainName() {
		return domainName;
	}

	public void setDomainName(String domainName) {
		this.domainName = domainName;
	}

	public List<DepartmentModel> getDepartmentList() {
		return departmentList;
	}

	public void setDepartmentList(List<DepartmentModel> departmentList) {
		this.departmentList = departmentList;
	}

	public List<DoctorModel> getDoctorList() {
		return doctorList;
	}
	public void setDoctorList(List<DoctorModel> doctorList) {
		this.doctorList = doctorList;
	}
	public byte getTimeZone() {
		return timeZone;
	}
	public void setTimeZone(byte timeZone) {
		this.timeZone = timeZone;

	}

	public HospitalDto getHospital() {
		return hospital;
	}

	public void setHospital(HospitalDto hospital) {
		this.hospital = hospital;
	}

	public byte getIsUseVaccine() {
		return isUseVaccine;
	}

	public void setIsUseVaccine(byte isUseVaccine) {
		this.isUseVaccine = isUseVaccine;
	}


	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public String getPatientCode() {
		return patientCode;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public byte getIsUseMt() {
		return isUseMt;
	}

	public void setIsUseMt(byte isUseMt) {
		this.isUseMt = isUseMt;
	}

	public void setUserToken(String userToken) {
		this.userToken = userToken;

	}

	public String getUserToken() {
		return userToken;
	}

	public void setMasterProfile(Long masterProfileId) {
		this.masterProfileId = masterProfileId;

	}

	public Long getMasterProfile() {

		return masterProfileId;
	}

	public String getMode() {
		return mode;
	}

	public void setMode(String mode) {
		this.mode = mode;
	}

	public List<KcckBookingSlotModel> getKcckBookingSlots() {
		return kcckBookingSlots;
	}

	public void setKcckBookingSlots(List<KcckBookingSlotModel> kcckBookingSlots) {
		this.kcckBookingSlots = kcckBookingSlots;
	}

	public ReservationModel getReservationModel() {
		return reservationModel;
	}

	public void setReservationModel(ReservationModel reservationModel) {
		this.reservationModel = reservationModel;
	}

	public Integer getAutoRecept() {
		return autoRecept;
	}

	public void setAutoRecept(Integer autoRecept) {
		this.autoRecept = autoRecept;
	}

	public String getPhrDeviceToken() {
		return phrDeviceToken;
	}

	public void setPhrDeviceToken(String phrDeviceToken) {
		this.phrDeviceToken = phrDeviceToken;
	}

	public PaymentInfoModel getPaymentInfo() {
		return paymentInfo;
	}

	public void setPaymentInfo(PaymentInfoModel paymentInfo) {
		this.paymentInfo = paymentInfo;
	}

	public List<OrderMedicineModel> getOrderMedicines() {
		return orderMedicines;
	}

	public void setOrderMedicines(List<OrderMedicineModel> orderMedicines) {
		this.orderMedicines = orderMedicines;
	}

	public String getUserBack() {
		return userBack;
	}

	public void setUserBack(String userBack) {
		this.userBack = userBack;
	}

	public String getFacebookId() {
		return facebookId;
	}

	public void setFacebookId(String facebookId) {
		this.facebookId = facebookId;
	}
}
