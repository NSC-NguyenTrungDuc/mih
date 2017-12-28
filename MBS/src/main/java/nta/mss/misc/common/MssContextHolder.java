package nta.mss.misc.common;

import java.util.List;
import java.util.Locale;

import nta.mss.model.*;
import org.apache.commons.lang.StringUtils;
import org.springframework.web.context.request.RequestAttributes;
import org.springframework.web.context.request.RequestContextHolder;

import nta.kcck.model.KcckBookingSlotModel;
import nta.kcck.model.KcckOrderMedicineModel;
import nta.kcck.model.KcckPaymentInfoModel;
import nta.mss.info.BookingInfo;
import nta.mss.info.HospitalDto;
import nta.mss.info.ScheduleInfo;

/**
 * The class to access the data in session.
 *
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MssContextHolder {

	/** The Constant DEFAULT_USER_LANGUAGE. */
	public static final String DEFAULT_USER_LANGUAGE = "en";

	/** The Constant MSS_SESSION_CONTEXT. */
	public static final String MSS_SESSION_CONTEXT = "MSS_CONTEXT";

	/**
	 * Current session context.
	 *
	 * @return the mss session context
	 */
	public static MssSessionContext currentSessionContext() {
		MssSessionContext sessionContext = (MssSessionContext) RequestContextHolder.currentRequestAttributes()
				.getAttribute(MSS_SESSION_CONTEXT, RequestAttributes.SCOPE_SESSION);

		if (sessionContext == null) {
			sessionContext = new MssSessionContext();
			RequestContextHolder.currentRequestAttributes().setAttribute(MSS_SESSION_CONTEXT, sessionContext,
					RequestAttributes.SCOPE_SESSION);
		}
		return sessionContext;
	}

	/**
	 * Sets the session mode.
	 *
	 * @param sessionMode
	 *            the new session mode
	 */
	public static void setSessionMode(Integer sessionMode) {
		currentSessionContext().setSessionMode(sessionMode);
	}

	/**
	 * Gets the session mode.
	 *
	 * @return the session mode
	 */
	public static Integer getSessionMode() {
		return currentSessionContext().getSessionMode();
	}

	/**
	 * Sets the reserve mode.
	 *
	 * @param reserveMode
	 *            the new reserve mode
	 */
	public static void setReserveMode(Integer reserveMode) {
		currentSessionContext().setReservationMode(reserveMode);
	}

	/**
	 * Gets the reservation mode.
	 *
	 * @return the reservation mode
	 */
	public static Integer getReservationMode() {
		return currentSessionContext().getReservationMode();
	}

	/**
	 * Sets the hospital id.
	 *
	 * @param hospitalId
	 *            the new hospital id
	 */
	public static void setHospitalId(Integer hospitalId) {
		currentSessionContext().setHospitalId(hospitalId);
	}

	/**
	 * Gets the hospital id.
	 *
	 * @return the hospital id
	 */
	public static Integer getHospitalId() {
		return currentSessionContext().getHospitalId();
	}

	/**
	 * Sets the hospital name.
	 *
	 * @param hospitalName
	 *            the new hospital name
	 */
	public static void setHospitalName(String hospitalName) {
		currentSessionContext().setHospitalName(hospitalName);
	}

	/**
	 * Gets the hospital name.
	 *
	 * @return the hospital name
	 */
	public static String getHospitalName() {
		return currentSessionContext().getHospitalName();
	}

	/**
	 * Sets the booking info.
	 *
	 * @param bookingInfo
	 *            the new booking info
	 */
	public static void setBookingInfo(BookingInfo bookingInfo) {
		currentSessionContext().setBookingInfo(bookingInfo);
	}

	/**
	 * Gets the booking info.
	 *
	 * @return the booking info
	 */
	public static BookingInfo getBookingInfo() {
		return currentSessionContext().getBookingInfo();
	}

	/**
	 * Sets the booking info.
	 *
	 * @param scheduleInfo
	 *            the new schedule info
	 */
	public static void setScheduleInfo(ScheduleInfo scheduleInfo) {
		currentSessionContext().setScheduleInfo(scheduleInfo);
	}

	/**
	 * Gets the schedule Info
	 *
	 * @return the scheduleInfo
	 */
	public static ScheduleInfo getScheduleInfo() {
		return currentSessionContext().getScheduleInfo();
	}

	/**
	 * Sets the user language.
	 *
	 * @param userLanguage
	 *            the new user language
	 */
	public static void setUserLanguage(String userLanguage) {
		MssSessionContext mssContext = currentSessionContext();
		mssContext.setUserLanguage(userLanguage);
		mssContext.setLocale(org.springframework.util.StringUtils.parseLocaleString(userLanguage));
	}

	/**
	 * Gets the user language.
	 *
	 * @return the user language
	 */
	public static String getUserLanguage() {
		MssSessionContext mssContext = currentSessionContext();
		String lang = mssContext.getUserLanguage();
		if (StringUtils.isBlank(lang)) {
			return DEFAULT_USER_LANGUAGE;
		} else {
			return lang;
		}
	}

	/**
	 * Gets the locale.
	 *
	 * @return the locale
	 */
	public static Locale getLocale() {
		MssSessionContext mssContext = currentSessionContext();
		String lang = mssContext.getUserLanguage();
		if (StringUtils.isBlank(lang)) {
			return org.springframework.util.StringUtils.parseLocaleString(DEFAULT_USER_LANGUAGE);
		} else {
			return org.springframework.util.StringUtils.parseLocaleString(lang);
		}
	}

	public static void setDeptId(Integer deptId) {
		currentSessionContext().setDeptId(deptId);
	}

	public static String getDepCode() {
		return currentSessionContext().getDeptCode();
	}

	public static void setDepCode(String deptCode) {
		currentSessionContext().setDeptCode(deptCode);
	}

	public static Integer getDeptId() {
		return currentSessionContext().getDeptId();
	}

	public static Integer getHospitalParentId() {
		return currentSessionContext().getHospitalParentId();
	}


	public static boolean isKcck() {
		Integer p = currentSessionContext().getHospitalParentId();
		return p != null && p == 1;
	}

	public static void setHospitalParentId(Integer hospitalParentId) {
		currentSessionContext().setHospitalParentId(hospitalParentId);
	}

	public static Byte getIsUseVaccine() {
		return currentSessionContext().getIsUseVaccine();
	}

	public static boolean isUseVaccine() {
		Integer v = Integer.valueOf(currentSessionContext().getIsUseVaccine());
		return v != null && v == 1;
	}

	public static void setIsUseVaccine(Byte isUseVaccine) {
		currentSessionContext().setIsUseVaccine(isUseVaccine);
	}

	public static Integer getIsUseSms() {
		return currentSessionContext().getIsUseSms();
	}

	public static byte getIsUseMt() {
		return currentSessionContext().getIsUseMt();
	}

	public static boolean isUseSms() {
		Integer s = currentSessionContext().getIsUseSms();
		return s != null && s == 1;
	}

	public static void setIsUseSms(Integer isUseSms) {
		currentSessionContext().setIsUseSms(isUseSms);
	}
	public static void setIsUseMt(byte isUseMt) {
		currentSessionContext().setIsUseMt(isUseMt);
	}

	public static String getHospitalIconPath() {
		return currentSessionContext().getHospitalIconPath();
	}

	public static void setHospitalIconPath(String hospitalIconPath) {
		currentSessionContext().setHospitalIconPath(hospitalIconPath);
	}

	public static String getTokenHospCode() {
		return currentSessionContext().getTokenHospCode();
	}

	public static void setTokenHospCode(String tokenHospCode) {
		currentSessionContext().setTokenHospCode(tokenHospCode);
	}

	public static String getHospCode() {
		return currentSessionContext().getHospCode();
	}

	public static void setHospCode(String hospCode) {
		currentSessionContext().setHospCode(hospCode);
	}

	public static String getHospitalLocale() {
		return currentSessionContext().getHospitalLocale();
	}

	public static void setHospitalLocale(String hospitalLocale) {
		currentSessionContext().setHospitalLocale(hospitalLocale);
	}

	public static String getHospitalEmail() {
		return currentSessionContext().getHospitalEmail();
	}

	public static void setHospitalEmail(String hospitalEmail) {
		currentSessionContext().setHospitalEmail(hospitalEmail);
	}

	public static String getDomainName() {
		return currentSessionContext().getDomainName();
	}

	public static void setDomainName(String domainName) {
		currentSessionContext().setDomainName(domainName);
	}

	public static List<DepartmentModel> getKcckDepartmentList() {
		return currentSessionContext().getDepartmentList();
	}

	public static void setKcckDepartmentList(List<DepartmentModel> departmentList) {
		currentSessionContext().setDepartmentList(departmentList);
	}
	public static List<DoctorModel> getDoctorList() {
		return currentSessionContext().getDoctorList();
	}

	public static void setDoctorList(List<DoctorModel> doctorList) {
		currentSessionContext().setDoctorList(doctorList);
	}

	public static List<KcckBookingSlotModel> getKcckBookingSlots()
	{
		return currentSessionContext().getKcckBookingSlots();
	}
	public static void setKcckBookingSlots(List<KcckBookingSlotModel> kcckBookingSlots) {
		currentSessionContext().setKcckBookingSlots(kcckBookingSlots);
	}
	public static ReservationModel getReservationModel()
	{
		return currentSessionContext().getReservationModel();
	}
	public static void setReservationModel(ReservationModel reservationModel) {
		currentSessionContext().setReservationModel(reservationModel);
	}
	public static Integer getAutoRecept()
	{
		return currentSessionContext().getAutoRecept() == null ? 0 : currentSessionContext().getAutoRecept();
	}
	public static void setAutoRecept(Integer autoRecept) {
		currentSessionContext().setAutoRecept(autoRecept);
	}

	public static void setTimeZone(byte timeZone) {
		currentSessionContext().setTimeZone(timeZone);
	}

	public static byte getTimeZone() {
		return currentSessionContext().getTimeZone();
	}
	public static void setHospital(HospitalDto hospital) {
		currentSessionContext().setHospital(hospital);
	}

	public static HospitalDto getHospital() {
		return currentSessionContext().getHospital();
	}

	public static void setDoctorCode(String doctorCode) {
		currentSessionContext().setDoctorCode(doctorCode);
	}
	public static String getDoctorCode() {
		return currentSessionContext().getDoctorCode();
	}


	public static void setPatientCode(String patientCode) {
		currentSessionContext().setPatientCode(patientCode);
	}

	public static String getPatientCode() {
		return currentSessionContext().getPatientCode();
	}
	public static void setPatientName(String patientName) {
		currentSessionContext().setPatientName(patientName);
	}

	public static String getPatientName() {
		return currentSessionContext().getPatientName();
	}
	public static void setDoctorName(String doctorName) {
		currentSessionContext().setDoctorName(doctorName);
	}

	public static String getMode() {
		return currentSessionContext().getMode();
	}
	public static void setMode(String mode) {
		currentSessionContext().setMode(mode);
	}

	public static String getDoctorName() {
		return currentSessionContext().getDoctorName();
	}
	public static void setUserToken(String token) {
		currentSessionContext().setUserToken(token);
	}

	public static String getUserToken() {
		return currentSessionContext().getUserToken();
	}
	public static void setPhrDeviceToken(String phrDeviceToken) {
		currentSessionContext().setPhrDeviceToken(phrDeviceToken);
	}

	public static String getPhrDeviceToken() {
		return currentSessionContext().getPhrDeviceToken();
	}
	public static void setPaymentInfo(PaymentInfoModel paymentInfo) {
		currentSessionContext().setPaymentInfo(paymentInfo);
	}

	public static PaymentInfoModel getPaymentInfo() {
		return currentSessionContext().getPaymentInfo();
	}

	public static void setOrderMedicines(List<OrderMedicineModel> orderMedicines) {
		currentSessionContext().setOrderMedicines(orderMedicines);
	}

	public static List<OrderMedicineModel> getOrderMedicines() {
		return currentSessionContext().getOrderMedicines();
	}

	public static void setMasterProfile(Long masterProfileId) {
		currentSessionContext().setMasterProfile(masterProfileId);
	}

	public static Long getMasterProfile() {
		return currentSessionContext().getMasterProfile();
	}
	public static void setUserBack(String userBack) {
		currentSessionContext().setUserBack(userBack);
	}

	public static String getUserBack() {
		return currentSessionContext().getUserBack();
	}

	public static void setTrackingScript(List<HospitalTrackingModel> trackingList) {
		currentSessionContext().setTrackingList(trackingList);
	}

	public static List<HospitalTrackingModel> getTrackingScript() {
		return currentSessionContext().getTrackingList();
	}

	public static void setFacebookId(String facebookId) {
		currentSessionContext().setFacebookId(facebookId);
	}

	public static String getFacebookId() {
		return currentSessionContext().getFacebookId();
	}
}
