package nta.mss.misc.common;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.math.NumberUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

/**
 * The Class MssConfiguration.
 *
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MssConfiguration {
	private static final Logger LOG = LogManager.getLogger(MssConfiguration.class);

	/** The Constant CONFIG_PATH. */
	private static final String CONFIG_PATH = "configPath";

	/** The Constant CONFIG_FILE. */
	private static final String CONFIG_FILE = "configs.properties";

	/** The Constant SECRET_KEY. */
	private static final String SECRET_KEY = "token.secret.key";

	/** The Constant MSS_SECRET_SPEC. */
	private static final String MSS_SECRET_SPEC = "token.mss.secret.spec";

	/** The Constant MSS_BOOKING_NUMBER_SIZE. */
	private static final String MSS_BOOKING_NUMBER_SIZE = "mss.booking.number.size";

	/** The Constant PREFIX_RESERVATION_CODE. */
	private static final String PREFIX_RESERVATION_CODE = "prefix.reservation.code";

	/** The Constant PREFIX_CARD_NUMBER. */
	private static final String PREFIX_CARD_NUMBER = "prefix.card.number";
	private static final String DIR_FILE_UPLOAD = "dir.file.upload";
	private static final String SERVER_ADDRESS = "server.address";
	private static final String SERVER_ADDRESS_JP = "server.address.jp";
	private static final String VACCINE_MONTHS_VIEW = "vaccine.months.view";
	private static final String SCHEDULE_LANGUAGE = "schedule.language";
	private static final String SCHEDULE_VACCINE_REMINDER_DAYS = "schedule.cron.reminder.vaccine.days";
	private static final String SCHEDULE_RESERVATION_REMINDER_DAYS = "schedule.delay.reminder.booking";
	private static final String SERVER_TIME_ZONE = "server.time.zone";
	private static final String MAX_SIZE_IMG_FILE = "max.size.img.file";
	private static final String DIR_IMAGE_FILE_UPLOAD = "dir.image.file.upload";
	private static final String HOSPITAL_LOGO_URL = "hospital.logo.url";
	private static final String PORTAL_URL = "portal.url";
	private static final String PEERJS_URL = "peerjs.url";
	private static final String LSTPEERID_URL ="listpeerjs.url";
	private static final String CERT_PATH ="cert.phr.path";
	/** The Constant SERVER API KCCK. */
	private static final String CONFIG_FILE_API = "api.kcck.properties";
	private static final String API__KCCK_SEVER_URL = "api.kcck.server";
	private static final String API__KCCK_SEVER_PORT = "api.kcck.port";
	private static final String API__KCCK_VACCINE_BOOKING = "api.kcck.vaccine.booking";
	private static final String API__KCCK_BOOKINGLAB_SCHEDULE = "api.kcck.bookinglab.schedule";
	private static final String API__KCCK_VACCINE_CODE = "api.kcck.vaccine.code";
	private static final String API__KCCK_DOCTOR_GRADE = "api.kcck.doctor.grade";
	private static final String API__KCCK_NEW_BOOKING = "api.kcck.new.booking";
	private static final String API__KCCK_NEW_BOOKING_ASYN = "api.kcck.new.booking.asyn";
	private static final String API__KCCK_CHANGE_BOOKING = "api.kcck.change.booking";
	private static final String API__KCCK_CANCEL_BOOKING = "api.kcck.cancel.booking";
	private static final String API__KCCK_PENDING_STATUS = "api.kcck.pending.status";
	private static final String API__KCCK_DEPARTMENT_LIST = "api.kcck.department.list";
	private static final String API__KCCK_DOCTOR_SCHEDULE = "api.kcck.doctor.schedule";
	private static final String API__KCCK_DEPARTMENT_SCHEDULE = "api.kcck.department.schedule";
	private static final String API__KCCK_DOCTOR_LIST = "api.kcck.doctor.list";
	private static final String API__KCCK_DEPARTMENT_SCHEDULE_TIME = "api.kcck.department.schedule.time";
	private static final String API__KCCK_PATIENT_INFO = "api.kcck.patient.info";
	private static final String API__KCCK_CRM_SEARCH = "api.kcck.crm.search";
	private static final String API__KCCK_SYS_USER = "api.kcck.sys.user";
	private static final String API__KCCK_UPDATE_DEFAULT_SCHEDULE = "api.kcck.update.default.schedule";
	private static final String API__KCCK_PATIENT_WAITING_LIST = "api.kcck.patient.wating.list";
	private static final String API__KCCK_PATIENT_CALLING_ID = "api.kcck.patient.calling.id";
	private static final String API__KCCK_DOCTOR_INFORMATION_FROM_SESSION = "api.kcck.doctor.session-information";
	private static final String API_KCCK_AUTO_RECEIPT = "api.kcck.auto.receipt";
	private static final String API_KCCK_SEARCH_PAYMENT_HISTORY = "api.kcck.patient.search_payment_history";
	private static final String API_KCCK_PAYMENT_INFO = "api.kcck.payment.info";
	private static final String API_KCCK_UPDATE_PAYMENT = "api.kcck.patient.update_payment";

	private static final String CONFIG_FILE_API_MIS = "api.mis.properties";

	private static final String API_MIS_SURVEY_LINK = "api.mis.survey_link";
	private static final String API_MIS_SURVER_URL = "api.mis.server";
	private static final String API_MIS_SURVEY_PORT = "api.mis.port";

	/** The Constant SERVER PHR API */
	private static final String CONFIG_FILE_API_PHR = "api.phr.properties";
	private static final String API_PHR_SEVER_URL = "api.phr.server";
	private static final String API_PHR_SEVER_PORT = "api.phr.port";
	private static final String API_PHR_LOGIN = "api.phr.login";
	private static final String API_PHR_LOGIN_FACEBOOK = "api.phr.login_facebook";
	private static final String API_PHR_REGISTER = "api.phr.register";
	private static final String API_PHR_CHANGE_PASS = "api.phr.change_password";
	private static final String API_PHR_UPDATE_INFORMATION = "api.phr.update_information";
	private static final String API_PHR_REGISTER_FB = "api.phr.register_fb";
	private static final String API_PHR_ADD_ACCOUNT_CLINIC = "api.phr.add.account_clinic";
	private static final String API_PHR_FIND_PATIENT_BY_PROFILE_ID = "api.phr.find.patient_by_profile_id";

	private static final String API_PHR_VERIFY = "api.phr.verify";
	private static final String API_PHR_GET_ACCOUNT_INFO = "api.phr.get.account_info";
	private static final String API_PHR_FIND_USER_CHILD_BY_ACCOUNT_ID = "api.phr.find.user_childs_by_account_id";
	private static final String API_PHR_FIND_USER_CHILD_BY_ID = "api.phr.find.user_child_by_id";
	private static final String API_PHR_GENERATE_TOKEN = "api.phr.generate-token";
	private static final String API_PHR_GET_TOKEN_DEVICE_ID = "api.phr.get_token_device_id";

	/** SMS - Click A Tell API */
	private static final String API_CLICKATELL_USERNAME = "clickatell.api.username";
	private static final String API_CLICKATELL_PASSWORD = "clickatell.api.password";
	private static final String API_CLICKATELL_ID = "clickatell.api.id";

	private static final String FACE_BOOK_APP_ID = "facebook.app_id";
	private static final String FACE_BOOK_APP_SECRET = "facebook.app_secret";
	private static final String FACE_BOOK_REGISTER_REDIRECT ="facebook.register_redirect";
	private static final String FACE_BOOK_LOGIN_REDIRECT = "facebook.login_redirect";
	private static final String DEFAULT_PASSWORD = "123456";
	
	/** GMO PG */
	private static final String GMO_URL_REQUESTION = "gmo.pay.url.resquestion";
	private static final String GMO_URL_CANCELATION = "gmo.pay.url.cancelation";
	private static final String GMO_URL_VERSION = "gmo.pay.version";
	private static final String API_KCCK_GMO_PAYMENT_INFO = "api.kcck.patient.authorization_amount";

	private static MssConfiguration instance;
	private static boolean isInitialized = false;
	private String secretKey;
	private String secretSpec;
	private Integer bookingNumberSize;
	private String prefixReservationCode;
	private String prefixCardNumber;
	private String dirFileUpload;
	private String serverAddress;
	private String serverAddressJp;
	private Integer vaccineMonthsView;
	private String scheduleLanguage;
	private List<Integer> scheduleVaccineReminderDays;
	private String scheduleReservationReminderDays;
	private String serverTimeZone;
	private Long maxSizeImgFile;
	private String dirImageFileUpload;
	private String locale;
	private String hospitalLogo;
	private String portalUrl;
	private String smsApiUserName;
	private String smsApiPassword;
	private String smsApiId;
	private String peerjsUrl;
	private String lstpeeridUrl;
	private String certPhrFullPath;
	
	private String apiKcckSeverUrl;
	private String apiKcckSeverPort;
	private String apiKcckVaccineBooking;
	private String apiKcckBookinglabSchedule;
	private String apiKcckVaccineCode;
	private String apiKcckDoctorGrade;
	private String apiKcckNewBooking;
	private String apiKcckNewBookingAsyn;
	private String apiKcckChangeBooking;
	private String apiKcckCancelBooking;
	private String apiKcckPendingStatus;
	private String apiKcckDepartmentList;
	private String apiKcckDoctorSchedule;
	private String apiKcckDepartmentSchedule;
	private String apiKcckDepartmentScheduleTime;
	private String apiKcckDoctorList;
	private String apiKcckPatientInfo;
	private String apiKcckCrmSearch;
	private String apiKcckSysUser;
	private String apiKcckUpdateDefaultSchedule;
	private String apiKcckPatientWaitingList;
	private String apiKcckPatientCallingId;
	private String apiKcckDoctorInformationFromSession;
	private String apiKcckAutoRecept;
	private String apiKcckSearchPaymentHistory;
	private String apiKcckPaymentInfo;
	private String apiKcckUpdatePayment;

	private String apiMisSeverUrl;
	private String apiMisSeverPort;
	private String apiGetLinkSurvey;

	private String apiPhrSeverUrl;
	private String apiPhrSeverPort;
	private String apiPhrLogin;
	private String apiPhrLoginFacebook;
	private String apiPhrRegister;
	private String apiPhrChangePass;
	private String apiPhrUpdateInformation;
	private String apiPhrRegisterFB;
	private String apiPhrAddAccountClinic;
	private String apiPhrFindPatientByProfileId;
	private String apiPhrVerify;
	private String apiPhrGetAccountInfo;
	private String apiPhrFindUserChildsByAccountId;
	private String apiPhrFindUserChildById;
	private String apiPhrGenerateToken;
	private String apiPhrGetTokenDevice;



	private String faceBookAppId;
	private String faceBookSecret;
	private String faceBookRegisterUrlRedirect;
	private String faceBookLoginUrlRedirect;
	private String defaultPassword="123456";
	
	// GMO PG
	private String gmoPayUrlResquestion;
	private String gmoPayUrlCancelation;
	private String gmoPayVersion;
	private String apiKcckGmoPaymentInfo;


	/**
	 * Instantiates a new mss configuration.
	 */
	private MssConfiguration() {

	}

	/**
	 * Gets the single instance of MssConfiguration.
	 *
	 * @return single instance of MssConfiguration
	 * @throws Exception
	 *             the exception
	 */
	public static MssConfiguration getInstance() throws Exception {
		if (instance == null) {
			instance = new MssConfiguration();
		}
		if (!isInitialized) {
			instance.init();
		}
		return instance;
	}

	/**
	 * Inits the configuration and get all the values from config files.
	 *
	 * @throws Exception
	 *             the exception
	 */
	private void init() throws Exception {
		String configPath = System.getProperty(CONFIG_PATH);
		if (StringUtils.isBlank(configPath)) {
			LOG.error("Config path not found.");
			throw new Exception("Config path not found.");
		}
		Properties props = new Properties();
		FileInputStream fis = null;
		try {
			fis = new FileInputStream(configPath + System.getProperty("file.separator") + CONFIG_FILE);
			props.load(fis);
			// get the properties from properties file
			secretKey = props.getProperty(SECRET_KEY);
			secretSpec = props.getProperty(MSS_SECRET_SPEC);
			bookingNumberSize = Integer.parseInt(props.getProperty(MSS_BOOKING_NUMBER_SIZE));
			prefixReservationCode = props.getProperty(PREFIX_RESERVATION_CODE);
			prefixCardNumber = props.getProperty(PREFIX_CARD_NUMBER);
			dirFileUpload = props.getProperty(DIR_FILE_UPLOAD);
			serverAddress = props.getProperty(SERVER_ADDRESS);
			serverAddressJp = props.getProperty(SERVER_ADDRESS_JP);
			vaccineMonthsView = Integer.parseInt(props.getProperty(VACCINE_MONTHS_VIEW));
			scheduleLanguage = props.getProperty(SCHEDULE_LANGUAGE);
			scheduleVaccineReminderDays = this.getReminderDaysList(props.getProperty(SCHEDULE_VACCINE_REMINDER_DAYS));
			scheduleReservationReminderDays = props.getProperty(SCHEDULE_RESERVATION_REMINDER_DAYS);
			serverTimeZone = props.getProperty(SERVER_TIME_ZONE);
			maxSizeImgFile = Long.parseLong(props.getProperty(MAX_SIZE_IMG_FILE));
			dirImageFileUpload = props.getProperty(DIR_IMAGE_FILE_UPLOAD);
			hospitalLogo = props.getProperty(HOSPITAL_LOGO_URL);
			portalUrl = props.getProperty(PORTAL_URL);
			smsApiUserName = props.getProperty(API_CLICKATELL_USERNAME);
			smsApiPassword = props.getProperty(API_CLICKATELL_PASSWORD);
			smsApiId = props.getProperty(API_CLICKATELL_ID);
			peerjsUrl = props.getProperty(PEERJS_URL);
			lstpeeridUrl = props.getProperty(LSTPEERID_URL);
			certPhrFullPath = props.getProperty(CERT_PATH);




		} catch (IOException e) {
			LOG.error("Cannot get config file");
		} finally {
			if (fis != null) {
				try {
					fis.close();
				} catch (IOException e) {
					LOG.error("Cannot close the file input stream", e.getMessage());
				}
			}
		}
		/*Config KCCK*/
		FileInputStream fisApi = null;
		try {
			fisApi = new FileInputStream(configPath + System.getProperty("file.separator") + CONFIG_FILE_API);
			props.load(fisApi);
			apiKcckSeverUrl = props.getProperty(API__KCCK_SEVER_URL);
			apiKcckSeverPort = props.getProperty(API__KCCK_SEVER_PORT);
			apiKcckVaccineBooking = props.getProperty(API__KCCK_VACCINE_BOOKING);
			apiKcckBookinglabSchedule = props.getProperty(API__KCCK_BOOKINGLAB_SCHEDULE);
			apiKcckVaccineCode =  props.getProperty(API__KCCK_VACCINE_CODE);
			apiKcckDoctorGrade =  props.getProperty(API__KCCK_DOCTOR_GRADE);
			apiKcckNewBooking = props.getProperty(API__KCCK_NEW_BOOKING);
			apiKcckNewBookingAsyn = props.getProperty(API__KCCK_NEW_BOOKING_ASYN);
			apiKcckChangeBooking = props.getProperty(API__KCCK_CHANGE_BOOKING);
			apiKcckCancelBooking = props.getProperty(API__KCCK_CANCEL_BOOKING);
			apiKcckPendingStatus = props.getProperty(API__KCCK_PENDING_STATUS);
			apiKcckDepartmentList = props.getProperty(API__KCCK_DEPARTMENT_LIST);
			apiKcckDoctorList = props.getProperty(API__KCCK_DOCTOR_LIST);
			apiKcckDoctorSchedule = props.getProperty(API__KCCK_DOCTOR_SCHEDULE);
			apiKcckDepartmentSchedule = props.getProperty(API__KCCK_DEPARTMENT_SCHEDULE);
			apiKcckDepartmentScheduleTime = props.getProperty(API__KCCK_DEPARTMENT_SCHEDULE_TIME);
			apiKcckPatientInfo = props.getProperty(API__KCCK_PATIENT_INFO);
			apiKcckCrmSearch = props.getProperty(API__KCCK_CRM_SEARCH);
			apiKcckSysUser = props.getProperty(API__KCCK_SYS_USER);
			apiKcckUpdateDefaultSchedule = props.getProperty(API__KCCK_UPDATE_DEFAULT_SCHEDULE);
			apiKcckPatientWaitingList = props.getProperty(API__KCCK_PATIENT_WAITING_LIST);
			apiKcckPatientCallingId = props.getProperty(API__KCCK_PATIENT_CALLING_ID);
			apiKcckDoctorInformationFromSession =  props.getProperty(API__KCCK_DOCTOR_INFORMATION_FROM_SESSION);
			apiKcckAutoRecept = props.getProperty(API_KCCK_AUTO_RECEIPT);
			apiKcckPaymentInfo = props.getProperty(API_KCCK_PAYMENT_INFO);
			apiKcckSearchPaymentHistory = props.getProperty(API_KCCK_SEARCH_PAYMENT_HISTORY);
			apiKcckUpdatePayment = props.getProperty(API_KCCK_UPDATE_PAYMENT);
			apiKcckGmoPaymentInfo = props.getProperty(API_KCCK_GMO_PAYMENT_INFO);
		} catch (IOException e) {
			LOG.error("Cannot get config file");
		} finally {
			if (fisApi != null) {
				try {
					fisApi.close();
				} catch (IOException e) {
					LOG.error("Cannot close the file input stream", e.getMessage());
				}
			}
		}

		/*Config PHR*/
		FileInputStream fisPhrApi = null;
		try {
			fisPhrApi = new FileInputStream(configPath + System.getProperty("file.separator") + CONFIG_FILE_API_PHR);
			props.load(fisPhrApi);
			apiPhrSeverUrl = props.getProperty(API_PHR_SEVER_URL);
			apiPhrSeverPort = props.getProperty(API_PHR_SEVER_PORT);
			apiPhrLogin = props.getProperty(API_PHR_LOGIN);
			apiPhrLoginFacebook = props.getProperty(API_PHR_LOGIN_FACEBOOK);
			apiPhrRegister= props.getProperty(API_PHR_REGISTER);
			apiPhrChangePass= props.getProperty(API_PHR_CHANGE_PASS);
			apiPhrUpdateInformation = props.getProperty(API_PHR_UPDATE_INFORMATION);
			apiPhrRegisterFB =  props.getProperty(API_PHR_REGISTER_FB);
			apiPhrAddAccountClinic = props.getProperty(API_PHR_ADD_ACCOUNT_CLINIC);
			apiPhrFindPatientByProfileId = props.getProperty(API_PHR_FIND_PATIENT_BY_PROFILE_ID);
			apiPhrVerify= props.getProperty(API_PHR_VERIFY);
			apiPhrGetAccountInfo = props.getProperty(API_PHR_GET_ACCOUNT_INFO);
			apiPhrFindUserChildsByAccountId = props.getProperty(API_PHR_FIND_USER_CHILD_BY_ACCOUNT_ID);
			apiPhrFindUserChildById = props.getProperty(API_PHR_FIND_USER_CHILD_BY_ID);
			apiPhrGenerateToken =  props.getProperty(API_PHR_GENERATE_TOKEN);
			apiPhrGetTokenDevice = props.getProperty(API_PHR_GET_TOKEN_DEVICE_ID);


			faceBookAppId =  props.getProperty(FACE_BOOK_APP_ID);
			faceBookSecret =  props.getProperty(FACE_BOOK_APP_SECRET);
			faceBookRegisterUrlRedirect =  props.getProperty(FACE_BOOK_REGISTER_REDIRECT);
			faceBookLoginUrlRedirect =  props.getProperty(FACE_BOOK_LOGIN_REDIRECT);


		} catch (IOException e) {
			LOG.error("Cannot get config file");
		} finally {
			if (fisApi != null) {
				try {
					fisApi.close();
				} catch (IOException e) {
					LOG.error("Cannot close the file input stream", e.getMessage());
				}
			}
		}
		/*Config Mis*/
		FileInputStream fisMisApi = null;
		try {
			fisMisApi = new FileInputStream(configPath + System.getProperty("file.separator") + CONFIG_FILE_API_MIS);
			props.load(fisMisApi);
			apiGetLinkSurvey =  props.getProperty(API_MIS_SURVEY_LINK);
			apiMisSeverUrl =  props.getProperty(API_MIS_SURVER_URL);
			apiMisSeverPort =  props.getProperty(API_MIS_SURVEY_PORT);
		} catch (IOException e) {
			LOG.error("Cannot get config file");
		} finally {
			if (fisMisApi != null) {
				try {
					fisApi.close();
				} catch (IOException e) {
					LOG.error("Cannot close the file input stream", e.getMessage());
				}
			}
		}
		
		/* Config GMO */
		FileInputStream fisGMOApi = null;
		try {
			fisGMOApi = new FileInputStream(configPath + System.getProperty("file.separator") + CONFIG_FILE);
			props.load(fisGMOApi);
			gmoPayUrlResquestion =  props.getProperty(GMO_URL_REQUESTION);
			gmoPayUrlCancelation =  props.getProperty(GMO_URL_CANCELATION);
			gmoPayVersion        = props.getProperty(GMO_URL_VERSION);
		} catch (IOException e) {
			LOG.error("Cannot get config file");
		} finally {
			if (fisMisApi != null) {
				try {
					fisApi.close();
				} catch (IOException e) {
					LOG.error("Cannot close the file input stream", e.getMessage());
				}
			}
		}
		
	}

	public String getLstpeeridUrl() {
		return lstpeeridUrl;
	}

	public void setLstpeeridUrl(String lstpeeridUrl) {
		this.lstpeeridUrl = lstpeeridUrl;
	}

	public String getCertPhrFullPath() {
		return certPhrFullPath;
	}

	public void setCertPhrFullPath(String certPhrFullPath) {
		this.certPhrFullPath = certPhrFullPath;
	}

	public String getApiPhrVerify() {
		return apiPhrVerify;
	}

	public void setApiPhrVerify(String apiPhrVerify) {
		this.apiPhrVerify = apiPhrVerify;
	}

	public String getApiPhrRegister() {
		return apiPhrRegister;
	}

	public void setApiPhrRegister(String apiPhrRegister) {
		this.apiPhrRegister = apiPhrRegister;
	}

	public String getApiPhrRegisterFB() {
		return apiPhrRegisterFB;
	}

	public void setApiPhrRegisterFB(String apiPhrRegisterFB) {
		this.apiPhrRegisterFB = apiPhrRegisterFB;
	}


	public String getApiPhrAddAccountClinic() {
		return apiPhrAddAccountClinic;
	}

	public void setApiPhrAddAccountClinic(String apiPhrAddAccountClinic) {
		this.apiPhrAddAccountClinic = apiPhrAddAccountClinic;
	}

	public String getApiPhrFindPatientByProfileId() {
		return apiPhrFindPatientByProfileId;
	}

	public void setApiPhrFindPatientByProfileId(String apiPhrFindPatientByProfileId) {
		this.apiPhrFindPatientByProfileId = apiPhrFindPatientByProfileId;
	}

	private List<Integer> getReminderDaysList (String reminderDays){
		String[] daysArray = reminderDays.split(",");
		List<Integer> daysList = new ArrayList<Integer>();
		for (String days : daysArray) {
			if (NumberUtils.isDigits(days)) {
				daysList.add(Integer.valueOf(days));
			}
		}
		return daysList;
	}

	/**
	 * Gets the secret key.
	 *
	 * @return the secret key
	 */
	public String getSecretKey() {
		return secretKey;
	}

	/**
	 * Gets the secret spec.
	 *
	 * @return the secret spec
	 */
	public String getSecretSpec() {
		return secretSpec;
	}

	/**
	 * Gets the prefix card number.
	 *
	 * @return the prefix card number
	 */
	public String getPrefixCardNumber() {
		return prefixCardNumber;
	}

	/**
	 * Gets the prefix reservation code.
	 *
	 * @return the prefix reservation code
	 */
	public String getPrefixReservationCode() {
		return prefixReservationCode;
	}

	/**
	 * Gets the booking number size.
	 *
	 * @return the booking number size
	 */
	public Integer getBookingNumberSize() {
		return bookingNumberSize;
	}

	public String getDirFileUpload() {
		return dirFileUpload;
	}

	/**
	 * Gets the server address.
	 *
	 * @return the server address
	 */
	public String getServerAddress() {
		return serverAddress;
	}

	public void setServerAddress(String serverAddress) {
		this.serverAddress = serverAddress;
	}

	/**
	 * Gets the server address.
	 *
	 * @return the server address
	 */
	public String getServerAddressJp() {
		return serverAddressJp;
	}

	public void setServerAddressJp(String serverAddressJp) {
		this.serverAddress = serverAddressJp;
	}

	/**
	 * Gets the vaccine months view.
	 *
	 * @return the vaccine months view
	 */
	public Integer getVaccineMonthsView() {
		return vaccineMonthsView;
	}

	public void setVaccineMonthsView(Integer vaccineMonthsView) {
		this.vaccineMonthsView = vaccineMonthsView;
	}

	public String getScheduleLanguage() {
		return scheduleLanguage;
	}

	public List<Integer> getScheduleVaccineReminderDays() {
		return scheduleVaccineReminderDays;
	}

	public String getScheduleReservationReminderDays() {
		return scheduleReservationReminderDays;
	}

	public Long getMaxSizeImgFile() {
		return maxSizeImgFile;
	}

	public String getDirImageFileUpload() {
		return dirImageFileUpload;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getHospitalLogo() {
		return hospitalLogo;
	}

	public String getPortalUrl() {
		return portalUrl;
	}

	public String getApiKcckSeverUrl() {
		return apiKcckSeverUrl;
	}

	public String getApiKcckSeverPort() {return apiKcckSeverPort;}

	public String getApiKcckVaccineBooking() {return apiKcckVaccineBooking;}

	public String getApiKcckBookinglabSchedule() {return apiKcckBookinglabSchedule;}

	public String getApiKcckVaccineCode() {return apiKcckVaccineCode;}

	public String getApiKcckDoctorGrade() {return apiKcckDoctorGrade;}

	public String getApiKcckNewBooking() {
		return apiKcckNewBooking;
	}

	public void setApiKcckNewBooking(String apiKcckNewBooking) {
		this.apiKcckNewBooking = apiKcckNewBooking;
	}
	public String getApiKcckNewBookingAsyn() {
		return apiKcckNewBookingAsyn;
	}

	public void setApiKcckNewBookingAsyn(String apiKcckNewBookingAsyn) {
		this.apiKcckNewBookingAsyn = apiKcckNewBookingAsyn;
	}
	public String getApiKcckChangeBooking() {
		return apiKcckChangeBooking;
	}

	public void setApiKcckChangeBooking(String apiKcckChangeBooking) {
		this.apiKcckChangeBooking = apiKcckChangeBooking;
	}

	public String getApiKcckCancelBooking() {
		return apiKcckCancelBooking;
	}

	public void setApiKcckCancelBooking(String apiKcckCancelBooking) {
		this.apiKcckCancelBooking = apiKcckCancelBooking;
	}

	public String getApiKcckPendingStatus() {
		return apiKcckPendingStatus;
	}

	public void setApiKcckPendingStatus(String apiKcckPendingStatus) {
		this.apiKcckPendingStatus = apiKcckPendingStatus;
	}

	public String getApiKcckDepartmentList() {
		return apiKcckDepartmentList;
	}

	public void setApiKcckDepartmentList(String apiKcckDepartmentList) {
		this.apiKcckDepartmentList = apiKcckDepartmentList;
	}

	public String getApiKcckDoctorSchedule() {
		return apiKcckDoctorSchedule;
	}

	public void setApiKcckDoctorSchedule(String apiKcckDoctorSchedule) {
		this.apiKcckDoctorSchedule = apiKcckDoctorSchedule;
	}

	public String getApiKcckDepartmentSchedule() {
		return apiKcckDepartmentSchedule;
	}

	public void setApiKcckDepartmentSchedule(String apiKcckDepartmentSchedule) {
		this.apiKcckDepartmentSchedule = apiKcckDepartmentSchedule;
	}

	public String getApiKcckDoctorList() {
		return apiKcckDoctorList;
	}

	public void setApiKcckDoctorList(String apiKcckDoctorList) {
		this.apiKcckDoctorList = apiKcckDoctorList;
	}

	public String getApiKcckDepartmentScheduleTime() {
		return apiKcckDepartmentScheduleTime;
	}

	public void setApiKcckDepartmentScheduleTime(String apiKcckDepartmentScheduleTime) {
		this.apiKcckDepartmentScheduleTime = apiKcckDepartmentScheduleTime;
	}

	public String getSmsApiUserName() {
		return smsApiUserName;
	}

	public String getSmsApiPassword() {
		return smsApiPassword;
	}

	public String getSmsApiId() {
		return smsApiId;
	}

	public String getApiKcckPatientInfo() {
		return apiKcckPatientInfo;
	}

	public String getApiKcckCrmSearch() {
		return apiKcckCrmSearch;
	}

	public String getServerTimeZone() {
		return serverTimeZone;
	}

	public String getApiKcckSysUser() {
		return apiKcckSysUser;
	}

	public String getApiKcckUpdateDefaultSchedule() {
		return apiKcckUpdateDefaultSchedule;
	}

	public String getApiKcckPatientWaitingList() {
		return apiKcckPatientWaitingList;
	}

	public String getApiKcckPatientCallingId() {
		return apiKcckPatientCallingId;
	}
	public String getApiKcckAutoRecept() {
		return apiKcckAutoRecept;
	}

	public void setApiKcckAutoRecept(String apiKcckAutoRecept) {
		this.apiKcckAutoRecept = apiKcckAutoRecept;
	}

	public String getApiKcckPaymentInfo() {
		return apiKcckPaymentInfo;
	}

	public void setApiKcckPaymentInfo(String apiKcckPaymentInfo) {
		this.apiKcckPaymentInfo = apiKcckPaymentInfo;
	}

	public String getApiPhrSeverUrl() {
		return apiPhrSeverUrl;
	}
	
	public void setApiPhrSeverUrl(String apiPhrSeverUrl) {
		this.apiPhrSeverUrl = apiPhrSeverUrl;
	}

	public String getApiPhrSeverPort() {
		return apiPhrSeverPort;
	}

	public void setApiPhrSeverPort(String apiPhrSeverPort) {
		this.apiPhrSeverPort = apiPhrSeverPort;
	}

	public String getApiPhrLogin() {
		return apiPhrLogin;
	}

	public void setApiPhrLogin(String apiPhrLogin) {
		this.apiPhrLogin = apiPhrLogin;
	}

	public String getApiPhrGetAccountInfo() {
		return apiPhrGetAccountInfo;
	}

	public void setApiPhrGetAccountInfo(String apiPhrGetAccountInfo) {
		this.apiPhrGetAccountInfo = apiPhrGetAccountInfo;
	}

	public String getApiPhrFindUserChildsByAccountId() {
		return apiPhrFindUserChildsByAccountId;
	}

	public void setApiPhrFindUserChildsByAccountId(String apiPhrFindUserChildsByAccountId) {
		this.apiPhrFindUserChildsByAccountId = apiPhrFindUserChildsByAccountId;
	}

	public String getApiPhrFindUserChildById() {
		return apiPhrFindUserChildById;
	}

	public void setApiPhrFindUserChildById(String apiPhrFindUserChildById) {
		this.apiPhrFindUserChildById = apiPhrFindUserChildById;
	}

	public String getApiPhrGenerateToken() {
		return apiPhrGenerateToken;
	}

	public void setApiPhrGenerateToken(String apiPhrGenerateToken) {
		this.apiPhrGenerateToken = apiPhrGenerateToken;
	}
	
	public String getApiPhrGetTokenDevice() {
		return apiPhrGetTokenDevice;
	}

	public void setApiPhrGetTokenDevice(String apiPhrGetTokenDevice) {
		this.apiPhrGetTokenDevice = apiPhrGetTokenDevice;
	}



	public String getApiKcckDoctorInformationFromSession() {
		return apiKcckDoctorInformationFromSession;
	}

	public void setApiKcckDoctorInformationFromSession(String apiKcckDoctorInformationFromSession) {
		this.apiKcckDoctorInformationFromSession = apiKcckDoctorInformationFromSession;
	}

	public String getFaceBookAppId() {
		return faceBookAppId;
	}

	public void setFaceBookAppId(String faceBookAppId) {
		this.faceBookAppId = faceBookAppId;
	}

	public String getFaceBookSecret() {
		return faceBookSecret;
	}

	public void setFaceBookSecret(String faceBookSecret) {
		this.faceBookSecret = faceBookSecret;
	}

	public String getFaceBookRegisterUrlRedirect() {
		return faceBookRegisterUrlRedirect;
	}

	public void setFaceBookRegisterUrlRedirect(String faceBookRegisterUrlRedirect) {
		this.faceBookRegisterUrlRedirect = faceBookRegisterUrlRedirect;
	}

	public String getFaceBookLoginUrlRedirect() {
		return faceBookLoginUrlRedirect;
	}

	public void setFaceBookLoginUrlRedirect(String faceBookLoginUrlRedirect) {
		this.faceBookLoginUrlRedirect = faceBookLoginUrlRedirect;
	}

	public String getApiPhrLoginFacebook() {
		return apiPhrLoginFacebook;
	}

	public void setApiPhrLoginFacebook(String apiPhrLoginFacebook) {
		this.apiPhrLoginFacebook = apiPhrLoginFacebook;
	}

	public String getDefaultPassword() {
		return defaultPassword;
	}

	public void setDefaultPassword(String defaultPassword) {
		this.defaultPassword = defaultPassword;
	}

	public String getApiPhrChangePass() {
		return apiPhrChangePass;
	}

	public String getApiPhrUpdateInformation() {
		return apiPhrUpdateInformation;
	}

	public void setApiPhrUpdateInformation(String apiPhrUpdateInformation) {
		this.apiPhrUpdateInformation = apiPhrUpdateInformation;
	}

	public void setApiPhrChangePass(String apiPhrChangePass) {
		this.apiPhrChangePass = apiPhrChangePass;
	}

	public String getPeerjsUrl() {
		return peerjsUrl;
	}

	public void setPeerjsUrl(String peerjsUrl) {
		this.peerjsUrl = peerjsUrl;
	}

	public String getApiGetLinkSurvey() {
		return apiGetLinkSurvey;
	}

	public void setApiGetLinkSurvey(String apiGetLinkSurvey) {
		this.apiGetLinkSurvey = apiGetLinkSurvey;
	}

	public static Logger getLOG() {
		return LOG;
	}

	public String getApiMisSeverPort() {
		return apiMisSeverPort;
	}

	public void setApiMisSeverPort(String apiMisSeverPort) {
		this.apiMisSeverPort = apiMisSeverPort;
	}

	public String getApiMisSeverUrl() {
		return apiMisSeverUrl;
	}

	public void setApiMisSeverUrl(String apiMisSeverUrl) {
		this.apiMisSeverUrl = apiMisSeverUrl;
	}

	public String getApiKcckSearchPaymentHistory() {
		return apiKcckSearchPaymentHistory;
	}

	public void setApiKcckSearchPaymentHistory(String apiKcckSearchPaymentHistory) {
		this.apiKcckSearchPaymentHistory = apiKcckSearchPaymentHistory;
	}

	public String getApiKcckUpdatePayment() {
		return apiKcckUpdatePayment;
	}

	public void setApiKcckUpdatePayment(String apiKcckUpdatePayment) {
		this.apiKcckUpdatePayment = apiKcckUpdatePayment;
	}

	public String getGmoPayUrlResquestion() {
		return gmoPayUrlResquestion;
	}

	public void setGmoPayUrlResquestion(String gmoPayUrlResquestion) {
		this.gmoPayUrlResquestion = gmoPayUrlResquestion;
	}

	public String getGmoPayUrlCancelation() {
		return gmoPayUrlCancelation;
	}

	public void setGmoPayUrlCancelation(String gmoPayUrlCancelation) {
		this.gmoPayUrlCancelation = gmoPayUrlCancelation;
	}

	public String getApiKcckGmoPaymentInfo() {
		return apiKcckGmoPaymentInfo;
	}

	public void setApiKcckGmoPaymentInfo(String apiKcckGmoPaymentInfo) {
		this.apiKcckGmoPaymentInfo = apiKcckGmoPaymentInfo;
	}

	public String getGmoPayVersion() {
		return gmoPayVersion;
	}

	public void setGmoPayVersion(String gmoPayVersion) {
		this.gmoPayVersion = gmoPayVersion;
	}
	
}
