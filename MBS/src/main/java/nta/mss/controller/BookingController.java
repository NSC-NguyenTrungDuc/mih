package nta.mss.controller;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.time.Instant;
import java.time.LocalDateTime;
import java.time.OffsetDateTime;
import java.time.ZoneId;
import java.time.ZoneOffset;
import java.time.ZonedDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Collections;
import java.util.Comparator;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Optional;
import java.util.ResourceBundle;
import java.util.TreeMap;
import java.util.stream.Collectors;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;
import javax.validation.Valid;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.math.NumberUtils;
import org.apache.commons.lang.time.DateUtils;
import org.apache.commons.lang3.RandomStringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.security.access.annotation.Secured;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import nta.kcck.model.KcckBookingSlotModel;
import nta.kcck.model.KcckGmoShopInfoModel;
import nta.kcck.model.KcckReservationModel;
import nta.kcck.model.KcckVaccineScheduleModel;
import nta.kcck.model.MessageResponse;
import nta.kcck.model.TimeslotScheduleModel;
import nta.kcck.service.IKcckApiService;
import nta.kcck.service.IKcckBookingService;
import nta.kcck.service.impl.KcckApiService;
import nta.kcck.service.impl.KcckBookingService;
import nta.kcck.service.impl.KcckDepartmentService;
import nta.kcck.service.impl.KcckDoctorService;
import nta.kcck.service.impl.KcckPatientService;
import nta.kcck.service.impl.KcckScheduleService;
import nta.mss.entity.DataTableJsonObject;
import nta.mss.entity.Transaction;
import nta.mss.entity.UserChild;
import nta.mss.info.AjaxResponse;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.info.BookingInfo;
import nta.mss.info.CalendarInfo;
import nta.mss.info.HospitalDto;
import nta.mss.info.HospitalInfo;
import nta.mss.info.MailInfo;
import nta.mss.info.TransactionInfo;
import nta.mss.info.VaccineChildHistoryInfo;
import nta.mss.info.VaccineInfo;
import nta.mss.misc.common.DomainNameUtils;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.common.GmoPaymentHttp;
import nta.mss.misc.common.LanguageUtils;
import nta.mss.misc.common.MSSSession;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.common.MssNumberUtils;
import nta.mss.misc.common.SessionValidate;
import nta.mss.misc.common.TokenManager;
import nta.mss.misc.common.TokenUtils;
import nta.mss.misc.common.VaccineUtils;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.BookingMode;
import nta.mss.misc.enums.CalendarStatus;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.DepartmentType;
import nta.mss.misc.enums.GenderChild;
import nta.mss.misc.enums.HospitalLocale;
import nta.mss.misc.enums.MailCode;
import nta.mss.misc.enums.NotificationType;
import nta.mss.misc.enums.PaymentStatus;
import nta.mss.misc.enums.ReadingFlg;
import nta.mss.misc.enums.ReminderTime;
import nta.mss.misc.enums.ReservationStatus;
import nta.mss.misc.enums.SessionMode;
import nta.mss.misc.enums.TokenValidationResult;
import nta.mss.misc.enums.UserRole;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.BookingTimeModel;
import nta.mss.model.DepartmentModel;
import nta.mss.model.DoctorModel;
import nta.mss.model.HospitalModel;
import nta.mss.model.MailModel;
import nta.mss.model.MailTemplateModel;
import nta.mss.model.NotificationModel;
import nta.mss.model.PatientModel;
import nta.mss.model.PaymentInfoModel;
import nta.mss.model.ReservationModel;
import nta.mss.model.SessionModel;
import nta.mss.model.TransactionModel;
import nta.mss.model.UserChildModel;
import nta.mss.model.UserModel;
import nta.mss.model.VaccineChildHistoryModel;
import nta.mss.model.VaccineHospitalModel;
import nta.mss.model.VaccineModel;
import nta.mss.repository.TransactionRepositoryCustom;
import nta.mss.security.WebUserDetails;
import nta.mss.service.IBookingService;
import nta.mss.service.IDepartmentService;
import nta.mss.service.IDoctorScheduleService;
import nta.mss.service.IDoctorService;
import nta.mss.service.IGmoTransactionService;
import nta.mss.service.IHospitalService;
import nta.mss.service.IMailService;
import nta.mss.service.IPatientService;
import nta.mss.service.IReservationService;
import nta.mss.service.IScheduleService;
import nta.mss.service.ITransactionService;
import nta.mss.service.IUserChildService;
import nta.mss.service.IUserService;
import nta.mss.service.IVaccineChildHistoryService;
import nta.mss.service.IVaccineHospitalService;
import nta.mss.service.IVaccineService;
import nta.phr.model.PhrAccountClinicModel;
import nta.phr.service.IPhrApiService;

/**
 * The Class BookingController.
 * 
 * @author DinhNX
 * @CrtDate Jul 11, 2014
 */
/**
 * @author Nextop
 *
 */
@Controller
@Scope("prototype")
@RequestMapping("booking")
@NavigationConfig(leftMenuType = NavigationType.FRONT_LEFT_MENU)
public class BookingController extends BaseController {

	/** The Constant LOG. */
	private static final Logger LOG = LogManager.getLogger(BookingController.class);

	/** The Constant DEFAULT_RESERVATIONS_DISPLAY. */
	public static final Integer DEFAULT_RESERVATIONS_DISPLAY = 10;
	public static final String KCCK_AUTHORIZATION_INFO = "kcck_authorization_info";

	private IBookingService bookingService;
	private IMailService mailService;
	private IDepartmentService departmentService;
	private IHospitalService hospitalService;
	private IDoctorService doctorService;
	private IScheduleService scheduleService;
	private IDoctorScheduleService doctorScheduleService;
	private IUserChildService userChildService;
	private IVaccineService vaccineService;
	private IVaccineChildHistoryService vaccineChildHistoryService;
	private IVaccineHospitalService vaccineHospitalService;
	private IUserService userService;
	private IPhrApiService phrApiService;
	private TokenManager<MSSSession> cache;
	private IKcckBookingService kcckBookingService1;
	private IReservationService reservationService;
	private IKcckApiService kcckApiServiceBooking;
	private IPatientService patientService;
	private IGmoTransactionService gmoTransactionService;
	private ITransactionService transactionService;
	private TransactionRepositoryCustom transactionRepositoryCustom;
	
	// TODO
	KcckDepartmentService kcckDepartmentService = new KcckDepartmentService();
	KcckBookingService kcckBookingService = new KcckBookingService();
	KcckScheduleService kcckScheduleService = new KcckScheduleService();
	KcckDoctorService kcckDoctorService = new KcckDoctorService();
	KcckApiService kcckApiService = new KcckApiService();
	KcckPatientService kcckPatientService = new KcckPatientService();

	public BookingController() {
	}

	/**
	 * Instantiates a new booking controller.
	 * 
	 * @param bookingService
	 *            the booking service
	 * @param mailService
	 *            the mail service
	 * @param departmentService
	 *            the department service
	 * @param hospitalService
	 *            the hospital service
	 * @param doctorService
	 *            the doctor service
	 */
	@Autowired
	public BookingController(IBookingService bookingService, IMailService mailService,
			IDepartmentService departmentService, IHospitalService hospitalService, IDoctorService doctorService,
			IScheduleService scheduleService, IDoctorScheduleService doctorScheduleService,
			IUserChildService userChildService, IVaccineService vaccineService,	IReservationService reservationService,
			IVaccineChildHistoryService vaccineChildHistoryService, IVaccineHospitalService vaccineHospitalService,
			IUserService userService, IPhrApiService phrApiService,IKcckBookingService kcckBookingService1,IKcckApiService kcckApiServiceBooking, 
			IPatientService patientService, IGmoTransactionService gmoTransactionService, ITransactionService transactionService, 
			TransactionRepositoryCustom transactionRepositoryCustom, TokenManager<MSSSession> cache) {
		this.bookingService = bookingService;
		this.mailService = mailService;
		this.departmentService = departmentService;
		this.hospitalService = hospitalService;
		this.doctorService = doctorService;
		this.scheduleService = scheduleService;
		this.doctorScheduleService = doctorScheduleService;
		this.userChildService = userChildService;
		this.vaccineService = vaccineService;
		this.vaccineChildHistoryService = vaccineChildHistoryService;
		this.vaccineHospitalService = vaccineHospitalService;
		this.userService = userService;
		this.phrApiService = phrApiService;
		this.cache = cache;
		this.kcckBookingService1 = kcckBookingService1;
		this.reservationService = reservationService;
		this.patientService = patientService;
		this.kcckApiServiceBooking = kcckApiServiceBooking;
		this.gmoTransactionService = gmoTransactionService;
		this.transactionService = transactionService;
		this.transactionRepositoryCustom = transactionRepositoryCustom;
	}

	public UserModel getUser() {
		if (SecurityContextHolder.getContext().getAuthentication() != null) {
			Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();
			if (principal instanceof WebUserDetails) {
				return ((WebUserDetails) principal).getUser();
			}
		}
		return null;
	}

	/**
	 * Index.
	 * 
	 * @return the model and view
	 * @throws Exception
	 */
	/**
	 * @param tokenHospCode
	 * @param model
	 * @return
	 * @throws Exception
	 */
	@RequestMapping("/index")
	@NavigationConfig(group = { NavigationGroup.TOP_SERVICE })
	public ModelAndView getVaccineInfo(HttpServletRequest request,
			@RequestParam(value = "tokenHospCode", required = false) String tokenHospCode, ModelMap model)
			throws Exception {
		MssContextHolder.setReserveMode(null);
		String urlRequest = request.getRequestURI();
		model.addAttribute("urlRequestIndexBooking", urlRequest);
		UserModel u = getUser();
		byte useMt = 1;
		String hospCode = MssContextHolder.getHospCode();
		String locale = MssContextHolder.getLocale().toString();
		HospitalModel hospital = this.hospitalService.findHospitalByHospCodeAndLocate(hospCode, locale);
		if (hospital != null && hospital.getIsUseMt() != null && hospital.getIsUseMt() == 1) {
			model.addAttribute("isMovieTalk", true);
			MssContextHolder.setIsUseMt(useMt);
		} else {
			MssContextHolder.setIsUseMt((byte) 0);
		}
		if (u != null) {
			// Get hospital code from login user
			List<UserChildModel> userChildList = userChildService.findUserChildByActiveFlg(u.getUserId(),
					ActiveFlag.ACTIVE.toInt());
			if (userChildList != null && userChildList.size() != 0) {
				DepartmentModel newbornDepartmentModel = this.departmentService
						.findDeptByType(MssContextHolder.getHospCode(), DepartmentType.NEWBORNS.toInt());
				DepartmentModel vaccineDepartmentModel = this.departmentService
						.findDeptByType(MssContextHolder.getHospCode(), DepartmentType.VACCINE.toInt());
				if (newbornDepartmentModel != null) {
					model.addAttribute("newbornDeptId", newbornDepartmentModel.getDeptId());
				}
				if (vaccineDepartmentModel != null) {
					model.addAttribute("vaccineDeptId", vaccineDepartmentModel.getDeptId());
				}
			} else {
				List<VaccineInfo> vaccineInfoList = this.vaccineService.getVaccineInfoList(
						MssContextHolder.getHospitalId().toString(), MssContextHolder.getUserLanguage());
				model.addAttribute("vaccineInfoList", vaccineInfoList);
			}
			model.addAttribute("userChildList", userChildList);
			model.addAttribute("userLogin", true);
		} else {
			model.addAttribute("userLogin", false);
		}
		// model.addAttribute("hospitalId", hospital.getHospitalId());
		model.addAttribute("hospitalName", MssContextHolder.getHospital().getHospitalName());
		// redirect to the previous page
		Integer deptId = MssContextHolder.getDeptId();
		if (deptId != null) {
			MssContextHolder.setDeptId(null);
			model.addAttribute("deptId", deptId);
		}

		LOG.info("Booking index: load page success!!!");
		try {

		} catch (Exception e) {
			e.printStackTrace();
			LOG.error("Booking load page error!!!" + e.getMessage());
		}
		return new ModelAndView("front.booking.index");
	}

	/**
	 * Index.
	 *
	 * @param vaccineId
	 *            the vaccine id
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@RequestMapping("/vaccine")
	@NavigationConfig(group = { NavigationGroup.TOP_SERVICE })
	public ModelAndView index(@RequestParam(value = "id", required = true) String vaccineIdStr, ModelMap model)
			throws Exception {
		UserModel u = getUser();
		if (u != null) {
			// Get hospital code from login user
			Integer hospitalId = this.getUser().getHospitalId();
			if (StringUtils.isNotBlank(vaccineIdStr) && NumberUtils.isDigits(vaccineIdStr)) {
				VaccineInfo vaccineInfo = this.vaccineService.getVaccineInfoById(Integer.valueOf(vaccineIdStr),
						hospitalId.toString());
				model.addAttribute("vaccineInfo", vaccineInfo);
				return new ModelAndView("front.booking.vaccine.info");
			}
		}
		return new ModelAndView("front.booking.index");
	}

	/**
	 * Create a new booking health check.
	 *
	 * @param model
	 *            the model map
	 * @return the model and view
	 */
	@RequestMapping(value = { "/booking-new", "/online-booking-new" })
	@NavigationConfig(group = { NavigationGroup.BOOKING_NEW, NavigationGroup.ONLINE_BOOKING_NEW,
			NavigationGroup.BOOKING_NEW_PARENT,
			NavigationGroup.CHOOSE_DEPARTMENT }, stepType = NavigationType.BOOKING_STEPS)
	public ModelAndView bookingNew(ModelMap model, HttpServletRequest request) {
		// call datbase
		LOG.info("[Start] Booking new");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		UserModel userModel = this.getUser();
		String urIRequest = request.getRequestURI();
		if (urIRequest.contains("/booking/booking-new")){
			MssContextHolder.setReserveMode(BookingMode.NEW_BOOKING.toInt());
		}
		else if (urIRequest.contains("/booking/online-booking-new")) {
			if (userModel != null) {
				MssContextHolder.setReserveMode(BookingMode.NEW_BOOKING_ONLINE.toInt());
			} else {
				return new ModelAndView(new RedirectView("login"));
			}
		}
		MssContextHolder.setBookingInfo(new BookingInfo());
		// MssContextHolder.

		return chooseDepartment(model);
	}

	/**
	 * Create a new booking health check.
	 *
	 * @param model
	 *            the model map
	 * @return the model and view
	 */
	@RequestMapping("/booking-new-re-examination")
	@NavigationConfig(group = { NavigationGroup.BOOKING_NEW,
			NavigationGroup.CHOOSE_DEPARTMENT }, stepType = NavigationType.BOOKING_STEPS)
	public ModelAndView bookingNewReExamination(@RequestParam(value = "token", required = false) String mailSendingId,
			ModelMap model) {
		LOG.info("[Start] Booking new re examination");
		try {
			if (!StringUtils.isBlank(mailSendingId)) {
				String[] mailIdList = TokenUtils.decodeMailIdToken(mailSendingId);
				for (String mailId : mailIdList) {
					if (NumberUtils.isDigits(mailId)) {
						this.mailService.updateReadingFlg(Integer.valueOf(mailId), ReadingFlg.READ.toInt());
					}
				}
			}
		} catch (Exception e) {
			LOG.error(e.getMessage());
		}
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		MssContextHolder.setReserveMode(BookingMode.NEW_BOOKING.toInt());
		MssContextHolder.setBookingInfo(new BookingInfo());
		return chooseDepartment(model);
	}

	/**
	 * Booking new breadcrumb.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@RequestMapping("/booking-new-breadcrumb")
	@NavigationConfig(group = { NavigationGroup.BOOKING_NEW,
			NavigationGroup.CHOOSE_DEPARTMENT }, stepType = NavigationType.BOOKING_STEPS)
	public ModelAndView bookingNewBreadcrumb(ModelMap model) {
		LOG.info("[Start] Booking new");
		if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())) {
			return new ModelAndView(new RedirectView("re-examination"));
		}
		int sessionMode = MssContextHolder.getReservationMode();
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(sessionMode)) {
			MssContextHolder.setReserveMode(BookingMode.NEW_BOOKING_ONLINE.toInt());
		} else {
			MssContextHolder.setReserveMode(BookingMode.NEW_BOOKING.toInt());
		}
		MssContextHolder.setBookingInfo(new BookingInfo());
		return chooseDepartment(model);
	}

	/**
	 * Choose department.
	 * 
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	private ModelAndView chooseDepartment(ModelMap model) {
		List<HospitalInfo> hospitalInfoList = new ArrayList<HospitalInfo>();
		HospitalInfo hospitalInfo;
		HospitalModel hospital = this.hospitalService.findHospitalModelByHospitalId(MssContextHolder.getHospitalId());
		if (hospital == null) {
			return new ModelAndView("front.access.denied");
		}
		// DepartmentModel depatmentModel;
		List<DepartmentModel> internalDepts;
		List<DepartmentModel> departmentList;
		List<DepartmentModel> surgeryDepts;
		List<DepartmentModel> vaccineDepts;
		List<DepartmentModel> newBorns;
		if (hospital != null) {
			internalDepts = new ArrayList<DepartmentModel>();
			surgeryDepts = new ArrayList<DepartmentModel>();
			vaccineDepts = new ArrayList<DepartmentModel>();
			newBorns = new ArrayList<DepartmentModel>();
			departmentList = new ArrayList<DepartmentModel>();

			// check HospitalParentId : KCCK -MSS
			if (MssContextHolder.isKcck()) {
				if (MssContextHolder.getKcckDepartmentList() == null) {
					departmentList = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
							MssContextHolder.getLocale().toString());
					MssContextHolder.setKcckDepartmentList(departmentList);
				} else {
					departmentList = MssContextHolder.getKcckDepartmentList();
				}
				if (MssContextHolder.isUseVaccine()) {
					List<DepartmentModel> departmentList2 = new ArrayList<DepartmentModel>();
					departmentList2.addAll(departmentList);
					for (DepartmentModel departmentModel : departmentList) {
						if (departmentModel.getDeptType() == DepartmentType.NEWBORNS.toInt()) {
							vaccineDepts.add(departmentModel);
							departmentList2.remove(departmentModel);
						}
						if (departmentModel.getDeptType() == DepartmentType.VACCINE.toInt()) {
							departmentModel.setDeptName(this.getText("general.label.vaccine"));
							vaccineDepts.add(departmentModel);
							departmentList2.remove(departmentModel);
						}
					}
					double size = departmentList2.size();
					int index = (int) Math.ceil(size / 2);
					internalDepts = departmentList2.subList(0, index);
					if (size > 1) {
						surgeryDepts = departmentList2.subList(index, (int) size);
					}
				} else {
					double size = departmentList.size();
					int index = (int) Math.ceil(size / 3);
					internalDepts = departmentList.subList(0, index);
					if (size > 1) {
						surgeryDepts = departmentList.subList(index, index * 2);
						vaccineDepts = departmentList.subList(index * 2, (int) size);
					}
				}

				model.addAttribute("isKcck", true);
			} else {
				departmentList = hospital.getDepartments();
				if (hospital.getIsHideDeptType() != null && hospital.getIsHideDeptType() == 1) {
					double size = departmentList.size();
					int index = (int) Math.ceil(size / 3);
					internalDepts = departmentList.subList(0, index);
					if (size > 1) {
						surgeryDepts = departmentList.subList(index, index * 2);
						vaccineDepts = departmentList.subList(index * 2, (int) size);
					}
					model.addAttribute("isKcck", true);
				} else {
					for (DepartmentModel department : departmentList) {
						if (ActiveFlag.ACTIVE.toInt().equals(department.getActiveFlg())) {
							if (DepartmentType.INTERNAL.toInt().equals(department.getDeptType())) {
								internalDepts.add(department);
							} else if (DepartmentType.SURGERY.toInt().equals(department.getDeptType())) {
								surgeryDepts.add(department);
							} else if (DepartmentType.VACCINE.toInt().equals(department.getDeptType())) {
								vaccineDepts.add(department);
							} else if (DepartmentType.NEWBORNS.toInt().equals(department.getDeptType())) {
								newBorns.add(department);
							}
						}
					}
					model.addAttribute("isKcck", false);
				}
			}

			Collections.sort(internalDepts);
			Collections.sort(surgeryDepts);
			Collections.sort(vaccineDepts);
			Collections.sort(newBorns);
			// add hospital and its separated list of department to the new list
			hospitalInfo = new HospitalInfo();
			hospitalInfo.setHospital(hospital);
			hospitalInfo.setInternalDepts(internalDepts);
			hospitalInfo.setSurgeryDepts(surgeryDepts);
			hospitalInfo.setVaccineDepts(vaccineDepts);
			hospitalInfo.setNewBorns(newBorns);
			hospitalInfoList.add(hospitalInfo);
		}
		model.addAttribute("hospitalInfoList", hospitalInfoList);

		if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
			model.addAttribute("isReExamMode", true);
			BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
			if (bookingInfo != null) {
				List<ReservationModel> reservation = this.bookingService.getListLatestReservationByPatientId(
						bookingInfo.getPatientId(), MssContextHolder.getHospitalId(), DEFAULT_RESERVATIONS_DISPLAY);
				if (MssContextHolder.isKcck() && !CollectionUtils.isEmpty(reservation)) {
					for (ReservationModel info : reservation) {
						DepartmentModel item = kcckDepartmentService.findKcckDepartmentById(info.getHospCode(),
								info.getLocate(), info.getDeptId());
						info.setDeptType(item.getDeptType());
						if (info.getDeptName().equals("Khoa nhi")) {
							info.setDeptType(DepartmentType.NEWBORNS.toInt());
						}
					}
				}
				bookingInfo.setListLastestReservation(reservation);
				model.addAttribute("latestReservations", reservation);
				model.addAttribute("patientCode", bookingInfo.getCardNumber());
			}

		}

		LOG.info("[End] Booking new");
		return new ModelAndView("front.booking.new", model);
	}

	/**
	 * Booking time.
	 * 
	 * @param deptIdStr
	 *            the dept id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@RequestMapping(value = { "/booking-time" })
	@NavigationConfig(group = { NavigationGroup.CHOOSE_TIME }, stepType = NavigationType.BOOKING_STEPS)
	public ModelAndView bookingTime(@RequestParam(value = "deptId", required = false) String deptIdStr,
			@RequestParam(value = "deptType", required = false) Integer deptType,
			@RequestParam(value = "date", required = false) String dateStr,
			@RequestParam(value = "hospitalCode", required = false) String hospitalCode,
			@RequestParam(value = "deptCode", required = false) String deptCode,
			@RequestParam(value = "childId", required = false) String childId, ModelMap model, HttpSession session)
			throws Exception {
		LOG.info("[Start] Booking time");
		// check booking mode for displaying		
//		String currHH = new SimpleDateFormat("HH").format(new Date());
//		String currMM = new SimpleDateFormat("mm").format(new Date());
//		String currDD = new SimpleDateFormat("YYYYMMdd").format(new Date());

		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);


		String currHH = String.valueOf(now.getHour());
		String currMM = String.valueOf(now.getMinute());
		String currDD = new SimpleDateFormat("YYYYMMdd").format(new Date());

		session.setAttribute("currHH", currHH);
		session.setAttribute("currMM", currMM);
		session.setAttribute("currDD", currDD);
		LOG.debug("Booking time. deptId=" + deptIdStr + "; dateStr=" + dateStr + "; hospitalCode=" + hospitalCode
				+ "; deptCode=" + deptCode);
		Integer autoRecept = 0;
		if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode()))
		{
			String patientCode = "";
			if(BookingMode.NEW_BOOKING_ONLINE.toInt().equals(MssContextHolder.getReservationMode()))
			{			
			patientCode = this.userService.getUser(this.getUser().getUserId()).getPatientCode();	
			}
			else
			{
				    patientCode = MssContextHolder.getPatientCode();
			}
			String checkAutoRecept = kcckApiServiceBooking.getAutoReceiptByPatientCodeAndHospCode(patientCode, MssContextHolder.getHospCode());
			autoRecept = checkAutoRecept.equals("Y") ? 1 : 0;
			MssContextHolder.setAutoRecept(autoRecept);
		}
		else if(BookingMode.NEW_BOOKING.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode()))
		{
			MssContextHolder.setAutoRecept(0);
		}
		Integer deptId = null;
		Integer nearestDoctorId = null;
		Integer bookingMode = MssContextHolder.getReservationMode();
		List<DoctorModel> doctorModels = new ArrayList<>();
		if (this.getUser() == null && BookingMode.NEW_BOOKING_ONLINE.toInt().equals(bookingMode)) {
			return new ModelAndView(new RedirectView("login"));
		}
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (hospitalCode == null || StringUtils.isBlank(hospitalCode) || deptCode == null
				|| StringUtils.isBlank(deptCode)) {
			if (StringUtils.isBlank(deptIdStr) && bookingInfo != null && bookingInfo.getDeptId() != null) {
				deptIdStr = bookingInfo.getDeptId().toString();
			}
			if (StringUtils.isBlank(deptIdStr) || !StringUtils.isNumeric(deptIdStr)) {
				LOG.warn("[WARN] Booking time. deptIdStr is null");
				if (BookingMode.NEW_BOOKING.toInt().equals(bookingMode)
						|| BookingMode.RE_EXAMINATION.equals(bookingMode))
					return new ModelAndView(new RedirectView("booking-new"));
				if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(bookingMode)
						|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(bookingMode))
					return new ModelAndView(new RedirectView("online-booking-new"));
			}
			deptId = Integer.valueOf(deptIdStr);
		} else { // the request come from landingpage
			DepartmentModel departmentModel = departmentService.findDepartmentByCode(hospitalCode, deptCode);
			if (departmentModel != null) {
				// display the first date when the request comes from landing
				// page
				if (dateStr != null && !StringUtils.isBlank(dateStr)) {
					model.addAttribute("curDate", MssDateTimeUtil.convertStringDate(dateStr,
							DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
				}
				// clear the booking info session
				bookingInfo = null;
			} else {
				LOG.warn("[WARN] Booking time. departmentModel is null");
				if (BookingMode.NEW_BOOKING.toInt().equals(bookingMode)
						|| BookingMode.RE_EXAMINATION.toInt().equals(bookingMode))
					return new ModelAndView(new RedirectView("booking-new"));
				if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(bookingMode)
						|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(bookingMode))
					return new ModelAndView(new RedirectView("online-booking-new"));
			}
		}
		if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
			LOG.info("[INFO] Booking time for RE_EXAMINATION");
			model.addAttribute("reexaminationMode", true);
			HospitalModel hospital = this.hospitalService
					.findHospitalModelByHospitalId(MssContextHolder.getHospitalId());
			List<DoctorModel> doctorList;

			if (hospital == null) {
				return new ModelAndView("front.access.denied");
			}
			if (bookingInfo.getListLastestReservation() != null) {
				if (!bookingInfo.getListLastestReservation().isEmpty()) {
					nearestDoctorId = bookingInfo.getListLastestReservation().get(0).getDoctorId();
				}
			}
			if (MssContextHolder.isKcck()) {
				/* CKKC */
				DepartmentModel departmentModel = kcckDepartmentService.findKcckDepartmentById(
						MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(), deptId);
				doctorList = this.kcckDoctorService.getListKcckDoctor(MssContextHolder.getHospCode(),
						departmentModel.getDeptCode());
			} else {
				/* No CKKC */
				doctorList = this.doctorService.findDoctorsByDepartment(deptId);
			}
			MssContextHolder.setDoctorList(doctorModels);
			model.addAttribute("doctorList", doctorList);
			model.addAttribute("nearestDoctorId", nearestDoctorId);
		}

		DepartmentModel dept = new DepartmentModel();
		if (MssContextHolder.isKcck()) {
			// dept =
			// kcckDepartmentService.findKcckDepartmentById(MssContextHolder.getHospCode(),
			// MssContextHolder.getLocale().toString(), deptId);
			dept = kcckDepartmentService.findKcckDepartmentByIdAndType(MssContextHolder.getHospCode(),
					MssContextHolder.getLocale().toString(), deptId, deptType);

		} else {
			dept = this.departmentService.findDepartmentById(deptId);
		}
		if (dept == null) {
			LOG.warn("[WARN] Booking time. dept is null");
			if (BookingMode.NEW_BOOKING.toInt().equals(bookingMode)
					|| BookingMode.RE_EXAMINATION.toInt().equals(bookingMode))
				return new ModelAndView(new RedirectView("booking-new"));
			if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(bookingMode)
					|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(bookingMode))
				return new ModelAndView(new RedirectView("online-booking-new"));
		}
		if (bookingInfo == null) {
			bookingInfo = new BookingInfo();
			MssContextHolder.setBookingInfo(bookingInfo);
		}

		// Check if booking vaccine
		if (DepartmentType.VACCINE.toInt().equals(dept.getDeptType())) {
			if (this.getUser() != null) {
				List<UserChildModel> lstUserChildModel = this.userChildService
						.findUserChildByActiveFlg(this.getUser().getUserId(), ActiveFlag.ACTIVE.toInt());
				if (!CollectionUtils.isNotEmpty(lstUserChildModel)) {
					this.addNotification(new NotificationModel(NotificationType.ERROR,
							this.getText("fe001.msg.list.userChild.is.null")));
					return new ModelAndView(new RedirectView("booking-new"));
				}
			}
		}
		bookingInfo.setDeptId(dept.getDeptId());
		bookingInfo.setDeptName(dept.getDeptName());
		bookingInfo.setDeptType(dept.getDeptType());
		doctorModels = this.kcckDoctorService.getListKcckDoctor(MssContextHolder.getHospCode(),
				dept.getDeptCode());
		MssContextHolder.setDoctorList(doctorModels);
		if (!StringUtils.isBlank(childId) && StringUtils.isNumeric(childId)) {
			bookingInfo.setChildId(Integer.valueOf(childId));
		}
		model.addAttribute("departmentName", dept.getDeptName());
		LOG.info("[End] Booking time");
		if (DepartmentType.VACCINE.toInt().equals(dept.getDeptType())) {
			return new ModelAndView(new RedirectView("booking-vaccine-recommendation?deptId=" + deptIdStr));
		} else {
			return new ModelAndView("front.booking.time");
		}
	}

	/**
	 * Ajax get booking time data.
	 * 
	 * @param bookingTime
	 *            the booking time
	 * @return the map
	 * @throws Exception
	 */
	@RequestMapping(value = "/ajax-booking-time", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxGetBookingSchedule(@RequestBody BookingTimeModel bookingTime , ModelMap model) throws Exception {
		LOG.info("[Start] ajax booking time");
		Integer deptId = MssContextHolder.getBookingInfo().getDeptId();
		Integer deptType = MssContextHolder.getBookingInfo().getDeptType();
		Integer doctorId = bookingTime.getDoctorId();
		LOG.debug("Ajax booking time. deptId = " + deptId);
		TimeslotScheduleModel schedule = new TimeslotScheduleModel();
		TimeslotScheduleModel scheduleForPopup = new TimeslotScheduleModel();
		// Re examination
		if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
			LOG.info("[INFO] ajax booking time for RE_EXAMINATION.");
			if (MssContextHolder.isKcck()) {
				if (doctorId != null) {
					DepartmentModel departmentModel = kcckDepartmentService.findKcckDepartmentById(
							MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(), deptId);
					DoctorModel doctorModel = kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(),
							bookingTime.getDoctorId(), departmentModel.getDeptCode());
					scheduleForPopup = kcckScheduleService.checkKcckDepartmentSchedule(MssContextHolder.getHospCode(),
							MssConfiguration.getInstance().getApiKcckDepartmentScheduleTime(),
							bookingTime.getStartDate(), bookingTime.getEndDate(), departmentModel.getDeptCode(),
							null, null);
					Map<String, List<KcckBookingSlotModel>> scheduleTempMap = scheduleForPopup.getSchedule().entrySet().stream()
							.collect(Collectors.toMap(t -> t.getKey(), t -> t.getValue().stream().filter(p -> p.getDoctor_code().equals(doctorModel.getDoctorCode())).collect(Collectors.toList())));
					Map<String,List<KcckBookingSlotModel>> scheduleMap = scheduleTempMap.entrySet().stream().filter(p -> !CollectionUtils.isEmpty(p.getValue())).collect(Collectors.toMap(p -> p.getKey(), p -> p.getValue()));
					schedule.setAvgTime(scheduleForPopup.getAvgTime());
					schedule.setTimeslots(scheduleForPopup.getTimeslots());
					schedule.setSchedule(scheduleMap);
							
				}

			} else {
				if (doctorId != null) {
					schedule = this.scheduleService.getDoctorTimeslotSchedule(deptId, bookingTime.getDoctorId(),
							bookingTime.getStartDate(), bookingTime.getEndDate());
				}
			}
		} else {// New booking
			if (MssContextHolder.isKcck()) {
				DepartmentModel departmentModel = kcckDepartmentService.findKcckDepartmentByIdAndType(
						MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(), deptId, deptType);
				String doctorGrade = "";
				if (departmentModel.getDeptType() == DepartmentType.VACCINE.toInt()) {
					doctorGrade = MssConfiguration.getInstance().getApiKcckDoctorGrade();
				}
				schedule = kcckScheduleService.checkKcckDepartmentSchedule(MssContextHolder.getHospCode(),
						MssConfiguration.getInstance().getApiKcckDepartmentScheduleTime(), bookingTime.getStartDate(),
						bookingTime.getEndDate(), departmentModel.getDeptCode(), null, doctorGrade);
				scheduleForPopup = schedule;
			} else {
				schedule = this.departmentService.getDepartmentTimeslotSchedule(deptId, bookingTime.getStartDate(),
						bookingTime.getEndDate());
			}

		}
		List<KcckBookingSlotModel> kcckBookingSlots = new ArrayList<>();
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (!(scheduleForPopup == null || scheduleForPopup.getTimeslots().isEmpty())) {
			String currentDate = getStrCurrentDate();
			String startDate = bookingTime.getStartDate();
			if (currentDate.equals(startDate)) {
				kcckBookingSlots = scheduleService.getDoctorScheduleFasterBySchedule(scheduleForPopup);
				MssContextHolder.setKcckBookingSlots(kcckBookingSlots);
			}
		}
		if (schedule == null || schedule.getTimeslots().isEmpty()) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).data(schedule);
		} else {
			builder.status(HttpStatus.OK).data(scheduleService.getScheduleCanBookingAsCurrentTime(schedule));
		}
		
		LOG.info("[End] ajax booking time");
		return builder.build();
	}
	/**
	 * Booking time.
	 *
	 * @param doctorIdstr
	 *            the doctor idstr
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@RequestMapping("/booking-time-re-examination")
	@NavigationConfig(group = { NavigationGroup.CHOOSE_TIME }, stepType = NavigationType.BOOKING_STEPS)
	public ModelAndView bookingTimeReExamination(@RequestParam(value = "token", required = false) String doctorIdstr,
			@RequestParam(value = "mailSendingId") String mailSendingId, ModelMap model) {
		LOG.info("[Start] Booking time re examination");
		LOG.debug("Booking time re examination. doctorIdstr=" + doctorIdstr + "; mailSendingId=" + mailSendingId);
		try {
			if (!StringUtils.isBlank(mailSendingId)) {
				String[] mailIdList = TokenUtils.decodeMailIdToken(mailSendingId);
				for (String mailId : mailIdList) {
					if (NumberUtils.isDigits(mailId)) {
						this.mailService.updateReadingFlg(Integer.valueOf(mailId), ReadingFlg.READ.toInt());
					}
				}
			}
		} catch (Exception e) {
			LOG.error(e.getMessage());
		}
		if (StringUtils.isBlank(doctorIdstr) || !NumberUtils.isDigits(doctorIdstr)) {
			LOG.warn("[WARN] Booking time re examination. doctorIdstr is null");
			return new ModelAndView(new RedirectView("booking-new"));
		}
		Integer doctorId = Integer.valueOf(doctorIdstr);
		DoctorModel doctorModel = this.doctorService.getDoctorByDoctorId(doctorId);
		if (doctorModel == null) {
			LOG.warn("[WARN] Booking time re examination. doctorModel is null");
			return new ModelAndView(new RedirectView("booking-new"));
		}
		DepartmentModel departmentModel;
		if ((MssContextHolder.isKcck())) {
			// TODO
			departmentModel = kcckDepartmentService.findKcckDepartmentById(MssContextHolder.getHospCode(),
					MssContextHolder.getLocale().toString(), doctorModel.getDeptId());
		} else {
			departmentModel = this.departmentService.findDepartmentById(doctorModel.getDeptId());
		}

		if (departmentModel == null) {
			LOG.warn("[WARN] Booking time re examination. departmentModel is null");
			return new ModelAndView(new RedirectView("booking-new"));
		}
		BookingInfo bookingInfo = new BookingInfo();
		bookingInfo.setDoctorId(doctorModel.getDoctorId());
		bookingInfo.setDoctorName(doctorModel.getName());
		bookingInfo.setDeptId(departmentModel.getDeptId());
		bookingInfo.setDeptName(departmentModel.getDeptName());
		MssContextHolder.setBookingInfo(bookingInfo);
		MssContextHolder.setReserveMode(BookingMode.NEW_BOOKING.toInt());

		model.addAttribute("doctorName", doctorModel.getName());
		model.addAttribute("departmentName", departmentModel.getDeptName());
		LOG.info("[End] Booking time re examination");

		return new ModelAndView("front.booking.time.re.examination");
	}

	/**
	 * Ajax get booking time data re examination.
	 *
	 * @param bookingTime
	 *            the booking time
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-booking-time-re-examination", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxGetBookingTimeDataReExamination(@RequestBody BookingTimeModel bookingTime) {
		LOG.info("[Start] Ajax get booking time data re examination.");
		Integer doctorId = MssContextHolder.getBookingInfo().getDoctorId();
		LOG.debug("Ajax get booking time data re examination doctorId=" + doctorId);
		Map<String, Boolean> departmentSchedule = this.scheduleService.checkDoctorSchedule(doctorId,
				bookingTime.getStartDate(), bookingTime.getEndDate());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.status(HttpStatus.OK).data(departmentSchedule);
		LOG.info("[End] Ajax get booking time data re examination.");
		return builder.build();
	}

	/**
	 * Ajax select timeslot.
	 * 
	 * @param bookingTime
	 *            the booking time
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-select-timeslot", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxSelectTimeslot(@RequestBody BookingTimeModel bookingTime) throws Exception {
		LOG.info("[Start] Ajax select timeslot.");
		String clickAutoRecept = bookingTime.getTemplateName();
		String isAutoRecept = MssContextHolder.getAutoRecept().toString();
		if(clickAutoRecept != null && clickAutoRecept.equals("recept") && isAutoRecept.equals("1") )
		{
			MssContextHolder.setAutoRecept(1);
		}
		else{
			MssContextHolder.setAutoRecept(0);
		}
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		bookingInfo.setDoctorCode(bookingTime.getDoctorCode());
		Integer deptId = bookingInfo.getDeptId();
		String selectedDate = bookingTime.getSelectedDate();
		String selectedTime = bookingTime.getSelectedTime();
		LocalDateTime selectedDateTime = LocalDateTime.parse(selectedDate + selectedTime,
				DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
		LOG.debug("Ajax select timeslot. deptId=" + deptId + " ;selectedDate=" + selectedDate + " ;selectedTime="
				+ selectedTime + " ;selectedDateTime=" + selectedDateTime);
		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);
		DoctorModel doctor;
		String validateBookingVaccine = "";
		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();

		if (checkTime.isAfter(now)) {
			// If booking vaccine
			if (bookingInfo.getDeptType() != null && bookingInfo.getDeptType().equals(DepartmentType.VACCINE.toInt())) {
				// convert from localdatetime to date
				ZonedDateTime zdt = selectedDateTime.atZone(ZoneId.systemDefault());
				Date datetime = Date.from(zdt.toInstant());

				validateBookingVaccine = validateBookingVaccine(bookingInfo.getVaccineId(), bookingInfo.getChildId(),
						datetime);
				if (!StringUtils.isEmpty(validateBookingVaccine)) {
					responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR)
							.message(this.getText(validateBookingVaccine));
					return responseBuilder.build();
				}
			}

			if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
					|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
				if ((MssContextHolder.isKcck())) {
					DepartmentModel departmentModel = this.kcckDepartmentService.findKcckDepartmentById(
							MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(), deptId);
					doctor = this.kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(),
							bookingTime.getDoctorId(), departmentModel.getDeptCode());
				} else {
					doctor = this.doctorService.getDoctorByDoctorId(bookingTime.getDoctorId());
				}

			} else {
				if (MssContextHolder.isKcck()) {
					DepartmentModel departmentModel = this.kcckDepartmentService.findKcckDepartmentById(
							MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(), deptId);
					doctor = this.kcckDoctorService.findKcckDoctorByCode(MssContextHolder.getHospCode(),
							bookingTime.getDoctorCode(), departmentModel.getDeptCode());
				} else {
					doctor = this.doctorService.findAvailableDoctor(deptId, selectedDate, selectedTime);
				}
			}
			if (doctor == null) {
				LOG.warn("[WARN] Ajax select timeslot. doctor is null");
				responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR)
						.message(this.getText("general.msg.internal_error"));
				return responseBuilder.build();
			}
		} else {
			responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR)
					.message(this.getText("general.msg.cannot_select_past_time"));
			return responseBuilder.build();
		}

		setDoctorToContextHolder(selectedDate, selectedTime, doctor);

		// Check booking or booking vaccine
		if (bookingInfo.getDeptType() != null && bookingInfo.getDeptType().equals(DepartmentType.VACCINE.toInt())
				&& StringUtils.isEmpty(validateBookingVaccine)) {
			responseBuilder.status(HttpStatus.OK).data("booking-vaccine-info");
		} else {
			responseBuilder.status(HttpStatus.OK).data("booking-info");
		}

		LOG.info("[End] Ajax select timeslot.");
		return responseBuilder.build();
	}

	/**
	 * Validate booking vaccine.
	 *
	 * @param vaccineId
	 *            the vaccine id
	 * @param childId
	 *            the child id
	 * @param selectedDateTime
	 *            the selected date time
	 * @return the string
	 * @throws Exception
	 *             the exception
	 */
	private String validateBookingVaccine(Integer vaccineId, Integer childId, Date selectedDateTime) throws Exception {
		VaccineModel vaccineModel = this.vaccineService.findById(vaccineId);
		UserChildModel childModel = this.userChildService.findById(childId);
		if (vaccineModel.getLimitAgeToMonth() != null) {
			Integer limitAgeFromMonth = vaccineModel.getLimitAgeFromMonth();
			Integer limitAgeToMonth = vaccineModel.getLimitAgeToMonth();

			String strDateOfBirth = childModel.getDob();
			if (StringUtils.isBlank(strDateOfBirth)) {
				return "fe00302.msg.err.child.dateOfBirth";
			}
			Date dateOfBirth = MssDateTimeUtil.dateFromString(strDateOfBirth, DateTimeFormat.DATE_FORMAT_YYYYMMDD);
			Integer monthsAge = VaccineUtils.getMonthsAge(dateOfBirth);
			if (monthsAge > limitAgeToMonth) {
				return "fe00302.msg.err.age.not.allow";
			} else if (monthsAge < limitAgeFromMonth) {
				return "fe00302.msg.err.age.not.allow";
			}
		}
		if (vaccineModel.getToDate() != null) {
			Date toDate = new Date(vaccineModel.getToDate().getTime());
			if (selectedDateTime.after(toDate)) {
				return "fe00302.msg.err.dateChoose.not.allow";
			}
		}

		Date truncatedSelectedDateTime = DateUtils.truncate(selectedDateTime, Calendar.DATE);
		// List<VaccineChildHistoryModel> lstVaccineChildHistoryModel =
		// this.vaccineChildHistoryService
		// .findChildHistoryByChildId(childId,
		// vaccineModel.getVaccineGroupId());
		List<VaccineChildHistoryInfo> lstVaccineChildHistoryInfo = this.vaccineChildHistoryService
				.findVaccineChildHistoryInfoByChildId(childId);
		if (CollectionUtils.isNotEmpty(lstVaccineChildHistoryInfo)) {
			for (VaccineChildHistoryInfo VaccineChildHistoryInfo : lstVaccineChildHistoryInfo) {
				Date injectedDate = DateUtils.truncate(new Date(VaccineChildHistoryInfo.getInjectedDate().getTime()),
						Calendar.DATE);

				if (truncatedSelectedDateTime.equals(injectedDate)
						&& !vaccineModel.getVaccineGroupId().equals(VaccineChildHistoryInfo.getVaccineGroupId())) {
					return "fe00302.msg.err.duplicate.group";
				}
			}
		}

		return "";
	}

	/**
	 * Sets the doctor to context holder.
	 *
	 * @param selectedDate
	 *            the selected date
	 * @param selectedTime
	 *            the selected time
	 * @param doctor
	 *            the doctor
	 */
	private void setDoctorToContextHolder(String selectedDate, String selectedTime, DoctorModel doctor) {
		MssContextHolder.getBookingInfo().setDoctorId(doctor.getDoctorId());
		MssContextHolder.getBookingInfo().setDoctorName(doctor.getName());
		MssContextHolder.getBookingInfo().setReservationDate(selectedDate);
		MssContextHolder.getBookingInfo().setReservationTime(selectedTime);
		// reset formatted date time
		MssContextHolder.getBookingInfo().setFormattedReservationDate(StringUtils.EMPTY);
		MssContextHolder.getBookingInfo().setFormattedReservationTime(StringUtils.EMPTY);
	}

	/**
	 * Ajax select timeslot re examination.
	 *
	 * @param bookingTime
	 *            the booking time
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-select-timeslot-re-examination", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxSelectTimeslotReExamination(@RequestBody BookingTimeModel bookingTime) {
		LOG.info("[Start] Ajax select timeslot re examination.");
		Integer doctorId = MssContextHolder.getBookingInfo().getDoctorId();
		String selectedDate = bookingTime.getSelectedDate();
		String selectedTime = bookingTime.getSelectedTime();
		LocalDateTime selectedDateTime = LocalDateTime.parse(selectedDate + selectedTime,
				DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
		LOG.debug("Ajax select timeslot. deptId=" + doctorId + " ;selectedDate=" + selectedDate + " ;selectedTime="
				+ selectedTime + " ;selectedDateTime=" + selectedDateTime);
		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);
		DoctorModel doctor = null;
		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();
		if (checkTime.isAfter(now)) {
			doctor = this.doctorService.getDoctorByDoctorId(doctorId);
			if (doctor == null) {
				LOG.warn("[WARN] Ajax select timeslot re examination. doctor is null");
				responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR)
						.message(this.getText("general.msg.internal_error"));
			}
		} else {
			responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR)
					.message(this.getText("general.msg.cannot_select_past_time"));
		}
		if (doctor != null) {
			setDoctorToContextHolder(selectedDate, selectedTime, doctor);
			responseBuilder.status(HttpStatus.OK).data("booking-info");
		}
		LOG.info("[End] Ajax select timeslot re examination.");
		return responseBuilder.build();
	}

	/**
	 * Authorized email.
	 * 
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.EDIT_BOOKING })
	@RequestMapping(value = "/authorized-email", method = RequestMethod.GET)
	public ModelAndView authorizedEmail(ModelMap model) {
		// TODO
		// MssContextHolder.setReserveMode(3);
		LOG.info("[Start] Authorized email.");
		LOG.info("[End] Authorized email.");
		return new ModelAndView("front.authorizedEmail", "mail", new MailModel());
	}

	/**
	 * Confirm authorized email.
	 * 
	 * @param mailModel
	 *            the mail model
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.EDIT_BOOKING })
	@RequestMapping(value = "/confirm-authorized-email", method = RequestMethod.POST)
	public ModelAndView confirmAuthorizedEmail(@ModelAttribute("mail") @Valid MailModel mailModel, BindingResult result,
			ModelMap model) {
		LOG.info("[Start] Confirm authorized email.");
		// TODO
		LOG.debug("Confirm authorized email. Email inputed : " + mailModel.getEmail());
		if (result.hasErrors()) {
			LOG.debug("Confirm authorized email. Email inputed is empty or incorrect");
			return new ModelAndView("front.authorizedEmail", "mail", mailModel);
		}
		List<ReservationModel> resList = this.bookingService.getReservationListByEmail(mailModel.getEmail(),
				MssContextHolder.getHospitalId());
		if (resList == null || resList.isEmpty()) {
			model.addAttribute("notReservation", true);
			return new ModelAndView("front.acceptEmail");
		}
		UserModel userMode = this.userService.getActiveUserByEmail(mailModel.getEmail(),
				MssContextHolder.getHospitalId());
		try {
			MailInfo mailInfo = new MailInfo();
			mailInfo.setHospitalName(MssContextHolder.getHospitalName());
			List<MailInfo> mailInfoList = new ArrayList<MailInfo>();
			for (ReservationModel res : resList) {
				String sessionId = null;
				sessionId = TokenUtils.generateToken();
				this.bookingService.saveSession(sessionId);
				this.bookingService.saveTokenIntoReservation(res.getReservationId(), sessionId);
				MailInfo mailInfoChild = new MailInfo();
				mailInfoChild.setPatientName(res.getPatientName());
				if (MssConfiguration.getInstance().getApiKcckVaccineCode().equals(res.getDepartmentCode())) {
					mailInfoChild.setPatientName(userMode.getName());
				}
				mailInfoChild.setHospitalName(MssContextHolder.getHospitalName());
				mailInfoChild.setReservationCode(res.getReservationCode());
				mailInfoChild.setDepartmentName(res.getDeptName());
				mailInfoChild.setReservationDatetime(
						res.getFormattedReservationDate() + " " + res.getFormattedReservationTime());
				mailInfoChild.setReminderTime(res.getReminderTime().toString());
				mailInfoChild.setSessionId(sessionId);
				mailInfoChild.setPatientId(res.getPatientId());
				mailInfoChild.setReservationId(res.getReservationId());
				// mailInfoChild.setHospitalName(res.getHospitalName());
				List<Object> args = new ArrayList<Object>();
				args.add(MssContextHolder.getUserLanguage());
				args.add(MssContextHolder.getTokenHospCode());
				mailInfoChild.setLinkBookingChangeInfo(MssContextHolder.getDomainName()
						+ this.getText("be030.link.booking.change.info", args) + mailInfoChild.getSessionId());
				mailInfoList.add(mailInfoChild);
			}
			mailInfo.setMailInfoList(mailInfoList);
			List<String> toList = new ArrayList<>();
			toList.add(mailModel.getEmail());
			mailService.sendMail(MailCode.BOOKING_CHANGE.toString(), this.getLanguage(), mailInfo, toList,
					MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
					MssContextHolder.getDomainName());
		} catch (Exception e) {
			LOG.error(e.getMessage());
		}
		LOG.info("[End] Confirm authorized email.");
		return new ModelAndView("front.acceptEmail");
	}

	@NavigationConfig(group = { NavigationGroup.EDIT_BOOKING })
	@RequestMapping(value = "/confirm-authorized-email", method = RequestMethod.GET)
	public ModelAndView viewAuthorizedEmail() {
		LOG.info("[Start] View authorized email.");
		LOG.info("[End] View authorized email.");
		return new ModelAndView("front.acceptEmail");
	}

	/**
	 * Pending status.
	 * 
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.PENDING_STATUS })
	@RequestMapping(value = "/pending-status", method = RequestMethod.GET)
	public ModelAndView pendingStatus(ModelMap model) {
		LOG.info("[Start] Pending status function");
		List<HospitalInfo> hospitalInfoList = new ArrayList<HospitalInfo>();
		HospitalInfo hospitalInfo;
		HospitalModel hospital = this.hospitalService.findHospitalModelByHospitalId(MssContextHolder.getHospitalId());
		if (hospital == null) {
			return new ModelAndView("front.access.denied");
		}
		// DepartmentModel depatmentModel;
		List<DepartmentModel> internalDepts;
		List<DepartmentModel> surgeryDepts;
		List<DepartmentModel> vaccineDepts;
		List<DepartmentModel> newBorns;
		List<DepartmentModel> departmentList;
		if (hospital != null) {
			internalDepts = new ArrayList<DepartmentModel>();
			surgeryDepts = new ArrayList<DepartmentModel>();
			vaccineDepts = new ArrayList<DepartmentModel>();
			newBorns = new ArrayList<DepartmentModel>();
			departmentList = new ArrayList<DepartmentModel>();

			// check HospitalParentId : KCCK -MSS
			if ((MssContextHolder.isKcck())) {
				if (MssContextHolder.getKcckDepartmentList() == null) {
					departmentList = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
							MssContextHolder.getLocale().toString());
					MssContextHolder.setKcckDepartmentList(departmentList);
				} else {
					departmentList = MssContextHolder.getKcckDepartmentList();
				}
				if (MssContextHolder.isUseVaccine()) {
					List<DepartmentModel> departmentList2 = new ArrayList<DepartmentModel>();
					departmentList2.addAll(departmentList);
					for (DepartmentModel departmentModel : departmentList) {
						if (departmentModel.getDeptType() == DepartmentType.NEWBORNS.toInt()) {
							vaccineDepts.add(departmentModel);
							departmentList2.remove(departmentModel);
						}
						if (departmentModel.getDeptType() == DepartmentType.VACCINE.toInt()) {
							departmentModel.setDeptName(this.getText("general.label.vaccine"));
							vaccineDepts.add(departmentModel);
							departmentList2.remove(departmentModel);
						}
					}
					double size = departmentList2.size();
					int index = (int) Math.ceil(size / 2);
					internalDepts = departmentList2.subList(0, index);
					if (size > 1) {
						surgeryDepts = departmentList2.subList(index, (int) size);
					}
				} else {
					double size = departmentList.size();
					int index = (int) Math.ceil(size / 3);
					internalDepts = departmentList.subList(0, index);
					if (size > 1) {
						surgeryDepts = departmentList.subList(index, index * 2);
						vaccineDepts = departmentList.subList(index * 2, (int) size);
					}
				}
				model.addAttribute("isKcck", true);
			} else {
				departmentList = hospital.getDepartments();
				if (hospital.getIsHideDeptType() != null && hospital.getIsHideDeptType() == 1) {
					double size = departmentList.size();
					int index = (int) Math.ceil(size / 3);
					internalDepts = departmentList.subList(0, index);
					if (size > 1) {
						surgeryDepts = departmentList.subList(index, index * 2);
						vaccineDepts = departmentList.subList(index * 2, (int) size);
					}
					model.addAttribute("isKcck", true);
				} else {
					for (DepartmentModel department : departmentList) {
						if (ActiveFlag.ACTIVE.toInt().equals(department.getActiveFlg())) {
							if (DepartmentType.INTERNAL.toInt().equals(department.getDeptType())) {
								internalDepts.add(department);
							} else if (DepartmentType.SURGERY.toInt().equals(department.getDeptType())) {
								surgeryDepts.add(department);
							} else if (DepartmentType.VACCINE.toInt().equals(department.getDeptType())) {
								vaccineDepts.add(department);
							} else if (DepartmentType.NEWBORNS.toInt().equals(department.getDeptType())) {
								newBorns.add(department);
							}
						}
					}
					model.addAttribute("isKcck", false);
				}
			}

			Collections.sort(internalDepts);
			Collections.sort(surgeryDepts);
			Collections.sort(vaccineDepts);
			Collections.sort(newBorns);
			// add hospital and its separated list of department to the new list
			hospitalInfo = new HospitalInfo();
			hospitalInfo.setHospital(hospital);
			hospitalInfo.setInternalDepts(internalDepts);
			hospitalInfo.setSurgeryDepts(surgeryDepts);
			hospitalInfo.setVaccineDepts(vaccineDepts);
			hospitalInfo.setNewBorns(newBorns);
			hospitalInfoList.add(hospitalInfo);
		}
		model.addAttribute("hospitalInfoList", hospitalInfoList);

		LOG.info("[End] Pending status function");

		return new ModelAndView("front.pendingStatus");
	}

	/**
	 * Pending status detail.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@RequestMapping(value = "/pending-status-detail", method = RequestMethod.GET)
	public ModelAndView pendingStatusDetail(@RequestParam("deptId") String deptId, ModelMap model) {

		LOG.info("[Start] Pending status detail function");
		LOG.debug("Pending status detail function. RequestParam: deptId=" + deptId);
		Integer departmentId = Integer.valueOf(deptId);
		DepartmentModel deptModel;
		if ((MssContextHolder.isKcck())) {
			deptModel = this.kcckDepartmentService.findKcckDepartmentById(MssContextHolder.getHospCode(),
					MssContextHolder.getLocale().toString(), departmentId);
		} else {
			deptModel = this.departmentService.findDepartmentById(departmentId);
		}
		model.addAttribute("department", deptModel);

		// HospitalModel hospital =
		// this.hospitalService.findHospitalById(deptModel.getHospitalId());
		model.addAttribute("hospitalName", MssContextHolder.getHospitalName());

		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);
		String currentTime = now.format(DateTimeFormatter.ofPattern("HH:mm"));

		model.addAttribute("currentTime", currentTime);
		String reservationDate = now.format(DateTimeFormatter.ofPattern("yyyyMMdd"));
		// String reservationDate = MssDateTimeUtil.dateToString(currentDate,
		// DateTimeFormat.DATE_FORMAT_YYYYMMDD);
		LOG.debug("[Debug] Pending status detail. reservationDate =  " + reservationDate);
		String reservationTime = null;
		if (reservationDate != null) {
			if ((MssContextHolder.isKcck())) {
				reservationTime = this.kcckBookingService
						.getPendingStatus(MssContextHolder.getHospCode(), deptModel.getDeptCode())
						.getMax_reservation_time();
			} else {
				reservationTime = this.bookingService.findTimeCurrentPendingStatus(reservationDate, departmentId);
			}
		}
		String timePending = null;
		LOG.debug("[Debug] Pending status detail. Max reservationTime =  " + reservationTime);
		if (reservationTime != null) {
			timePending = MssDateTimeUtil.convertStringDate(reservationTime, DateTimeFormat.TIME_FORMAT_HH_MM,
					DateTimeFormat.TIME_FORMAT_HH_MM_DEFAULT);
			long diffirentTime = MssDateTimeUtil.compareTime(currentTime, timePending);
			String lateTimeStr = this.bookingService.getLateTimePending(diffirentTime,
					MssContextHolder.getLocale().toString());

			model.addAttribute("timePending", timePending);
			model.addAttribute("lateStr", lateTimeStr);
		}
		LOG.info("[End] Pending status detail function");
		return new ModelAndView("front.pendingStatusDetail");
	}

	/**
	 * Start reexamination.
	 * 
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.RE_BOOKING_PARENT, NavigationGroup.REEXAMINE,
			NavigationGroup.ONLINE_REEXAMINE, NavigationGroup.CHOOSE_DEPARTMENT })
	@RequestMapping(value = { "/re-examination", "/online-re-examination" }, method = RequestMethod.GET)
	public ModelAndView startReexamination(HttpServletRequest request) {
		LOG.info("[Start] Start re examination.");
		String cardNumber = "";
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		UserModel userModel = this.getUser();
		String urIRequest = request.getRequestURI();
		if (urIRequest.contains("/booking/re-examination")){
			MssContextHolder.setReserveMode(BookingMode.RE_EXAMINATION.toInt());
		}
		else if (urIRequest.contains("/booking/online-re-examination")) {
			if (userModel != null) {
				MssContextHolder.setReserveMode(BookingMode.RE_EXAMINATION_ONLINE.toInt());
			} else {
				return new ModelAndView(new RedirectView("login"));
			}
		}
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (bookingInfo == null) {
			bookingInfo = new BookingInfo();
		} else {
			cardNumber = bookingInfo.getCardNumber();
			PatientModel patient;
			// KccK - Mss
			if (cardNumber != null) {
				if ((MssContextHolder.isKcck())) {
					String kcckPatientCode = MssNumberUtils.kcckPatientCode(cardNumber);
					LOG.debug("Kcck PatientCode=" + kcckPatientCode);
					patient = this.bookingService.findKcckPatientByCardNumber(kcckPatientCode,
							MssContextHolder.getHospitalId());
					if (patient != null) {
						patient.setDob(MssDateTimeUtil.dateToString(patient.getBirthDay(),
								DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
					} else {
						patient = this.kcckPatientService.getPatientInfo(MssContextHolder.getHospCode(),
								kcckPatientCode);
					}
				} else {
					patient = this.bookingService.findOnePatientByCardNumber(cardNumber,
							MssContextHolder.getHospitalId());
				}
				if (patient != null && patient.getCardNumber() != null) {
					bookingInfo.setCardNumber(patient.getCardNumber());
					bookingInfo.setPatientId(patient.getPatientId());
					bookingInfo.setPatientName(patient.getName());
					bookingInfo.setPatientFurigana(patient.getNameFurigana());
					bookingInfo.setPhoneNumber(patient.getPhoneNumber());
					bookingInfo.setEmail(patient.getEmail());
					bookingInfo.setPatientDob(patient.getDob());
					bookingInfo.setPatientGender(patient.getGender());
					return chooseDepartment(new ModelMap());
				}
			}
		}
		MssContextHolder.setBookingInfo(bookingInfo);
		ModelAndView modelAndView = new ModelAndView("front.booking.reexamination");
		modelAndView.addObject("cardNumber", cardNumber);
		LOG.info("[End] Start re examination.");
		return modelAndView;
	}

	/**
	 * Confirm reexamination.
	 * 
	 * @param cardNumber
	 *            the card number
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.CHOOSE_DEPARTMENT }, stepType = NavigationType.BOOKING_STEPS)
	@RequestMapping(value = "/re-examination-confirm", method = RequestMethod.POST, params = { "cardNumber" })
	@SessionValidate
	public ModelAndView confirmReexamination(@RequestParam("cardNumber") String cardNumber, ModelMap model) {
		LOG.info("[Start] Confirm re examination.");
		LOG.debug("Confirm re examination. cardNumber=" + cardNumber);
		ModelAndView modelAndView = new ModelAndView("front.booking.reexamination");
		modelAndView.addObject("cardNumber", cardNumber);
		if (StringUtils.isNotBlank(cardNumber)) {
			BookingInfo bookingInfo = MssContextHolder.getBookingInfo();

			PatientModel patient;
			// KccK - Mss
			if (MssContextHolder.isKcck()) {
				String kcckPatientCode = MssNumberUtils.kcckPatientCode(cardNumber);
				LOG.debug("Kcck PatientCode=" + kcckPatientCode);
				patient = this.bookingService.findKcckPatientByCardNumber(kcckPatientCode,
						MssContextHolder.getHospitalId());
				if (patient != null) {
					patient.setDob(MssDateTimeUtil.dateToString(patient.getBirthDay(),
							DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
				} else {
					patient = this.kcckPatientService.getPatientInfo(MssContextHolder.getHospCode(), kcckPatientCode);
					//patientService.savePatient(patient, MssContextHolder.getHospitalId());

				}
			} else {
				patient = this.bookingService.findOnePatientByCardNumber(cardNumber, MssContextHolder.getHospitalId());
			}
			if (patient != null && patient.getCardNumber() != null) {
				bookingInfo.setCardNumber(patient.getCardNumber());
				bookingInfo.setPatientId(patient.getPatientId());
				bookingInfo.setPatientName(patient.getName());
				bookingInfo.setPatientFurigana(patient.getNameFurigana());
				bookingInfo.setPhoneNumber(patient.getPhoneNumber());
				bookingInfo.setEmail(patient.getEmail());
				bookingInfo.setPatientDob(patient.getDob());
				bookingInfo.setPatientGender(patient.getGender());
				MssContextHolder.setPatientCode(patient.getCardNumber());
				return chooseDepartment(new ModelMap());
			} else {
				modelAndView.addObject("error", getText("fe010.label.card.number.error"));
				modelAndView.addObject("notExist", getText("fe010.label.card.number.not.exist"));
			}
		} else {
			LOG.warn("[WARN] Confirm re examination. cardNumber is null");
			modelAndView.addObject("error", getText("fe010.label.card.number.empty"));
		}
		LOG.info("[End] Confirm re examination.");
		return modelAndView;
	}

	/**
	 * Input booking info.
	 * 
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.INPUT_INFO }, stepType = NavigationType.BOOKING_STEPS)
	@RequestMapping(value = "/booking-info", method = RequestMethod.GET)
	@SessionValidate
	public ModelAndView inputBookingInfo(ModelMap model) throws Exception {
		LOG.info("[Start] Input booking info.");
		String urlUpload = "";
		if (getUser() != null) {
			String token = getUser().getToken();
			Long profileId = getUser().getMasterProfileId();
			String phrURI = phrApiService.getFullUrl("");
			urlUpload = phrURI + "api/profiles/" + profileId + "/upload?token=" + token;
		}
		PatientModel patient = new PatientModel();
		Integer bookingMode = MssContextHolder.getReservationMode();
		if (this.getUser() == null && BookingMode.NEW_BOOKING_ONLINE.toInt().equals(bookingMode)) {
			return new ModelAndView(new RedirectView("login"));
		}
		if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode()))
			patient.setNewBooking(false);
		else {
			patient.setNewBooking(true);
		}
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		// If booking newborns
		if (this.getUser() != null && DepartmentType.NEWBORNS.toInt().equals(bookingInfo.getDeptType())) {
			List<UserChildModel> lstChild = new ArrayList<UserChildModel>();
			if (bookingInfo.getChildId() == null) {
				lstChild = userChildService.findUserChildByActiveFlg(this.getUser().getUserId(),
						ActiveFlag.ACTIVE.toInt());
				model.addAttribute("lstChild", createMapChild(lstChild));
			} else {
				UserChildModel childModel = this.userChildService.findById(bookingInfo.getChildId());
				lstChild.add(childModel);
				Map<Integer, String> mapChild = new HashMap<Integer, String>();
				mapChild.put(childModel.getChildId(), childModel.getChildName());
				model.addAttribute("lstChild", mapChild);
			}

			model.addAttribute("isBookingNewBorns", true);
		}

		// set patient information from session
		if (bookingInfo != null) {
			patient.setName(bookingInfo.getPatientName());
			patient.setNameFurigana(bookingInfo.getPatientFurigana());
			patient.setEmail(bookingInfo.getEmail());
			patient.setDob(bookingInfo.getPatientDob());
			patient.setGender(bookingInfo.getPatientGender());
			patient.setPhoneNumber(bookingInfo.getPhoneNumber());
			patient.setCardNumber(bookingInfo.getCardNumber());
			patient.setReminderTime(bookingInfo.getReminderTime());
			model.addAttribute("deptName", bookingInfo.getDeptName());
			model.addAttribute("deptId", bookingInfo.getDeptId());
			if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
				model.addAttribute("bookingTime",
						bookingInfo.getFormattedReservationTime() + " " + bookingInfo.getFormattedReservationDate());
			} else {
				model.addAttribute("bookingTime",
						bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
			}

		}
		// set patient information from login user
		if (this.getUser() != null && bookingInfo != null) {
			UserModel user = userService.getUser(this.getUser().getUserId());
			bookingInfo.setUserId(this.getUser().getUserId());
			patient.setEmail(user.getEmail());
			patient.setPhoneNumber(user.getPhoneNumber());
			if (user.getSex() != null) {
				if (user.getSex().equals("M") || user.getSex().equals("1")) {
					patient.setGender("M");
					patient.setGenderText(this.getText("general.label.male"));
				} else {
					patient.setGender("F");
					patient.setGenderText(this.getText("general.label.female"));
				}
			}
			if (bookingInfo.getCardNumber() == null) {
				patient.setName(user.getName());
				patient.setNameFurigana(user.getNameFurigana());

				if (StringUtils.isNotBlank(user.getDob())) {
					try {
						SimpleDateFormat sdfSource = new SimpleDateFormat("yyyyMMdd");
						Date date = sdfSource.parse(user.getDob());

						SimpleDateFormat sdfDestination = new SimpleDateFormat("yyyy/MM/dd");
						String newDate = sdfDestination.format(date);
						patient.setDob(newDate);
					} catch (Exception ex) {
						ex.printStackTrace();
					}
				}

			}
		}
		patient.setMapReminderTime(getReminderTimeMap());
		if ((MssContextHolder.isKcck())) {
			model.addAttribute("isKcck", true);
		} else {
			model.addAttribute("isKcck", false);
		}
		if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(bookingMode)
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(bookingMode)) {
			model.addAttribute("needUpdateInsurance", true);
		}
		boolean hideSomeFields = false;
		if (BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(bookingMode)) {
			hideSomeFields = true;
			model.addAttribute("hideSomeFields", hideSomeFields);
		}
		model.addAttribute("reservationMode", MssContextHolder.getReservationMode());
		model.addAttribute("patient", patient);
		model.addAttribute("urlUpload", urlUpload);

		LOG.info("[End] Input booking info.");
		return new ModelAndView("front.booking.info");
	}
	
	@NavigationConfig(group = { NavigationGroup.INPUT_INFO }, stepType = NavigationType.BOOKING_STEPS)
	@RequestMapping(value = "/send-payment-info", method = RequestMethod.GET)
	@SessionValidate
	public ModelAndView sendPaymentInfo(ModelMap model, HttpServletRequest request, HttpSession session) throws Exception {
		LOG.info("[Start] Send payment info.");
		
		String baseURL = MssConfiguration.getInstance().getServerAddressJp();
		if (!StringUtils.isEmpty(MssContextHolder.getUserLanguage())) {
			if (MssContextHolder.getUserLanguage().equals("ja")) {
				baseURL = MssConfiguration.getInstance().getServerAddressJp();
			} else {
				baseURL = MssConfiguration.getInstance().getServerAddress();
			}
		}
		String ret_url = baseURL + "/booking/result-payment?" + request.getQueryString();
		String cancel_url = baseURL + "/booking/result-payment?" + request.getQueryString();
		
		KcckGmoShopInfoModel authorizationInfo = null;
		if(session.getAttribute(KCCK_AUTHORIZATION_INFO) != null) {
			authorizationInfo = (KcckGmoShopInfoModel)session.getAttribute(KCCK_AUTHORIZATION_INFO);
			
			authorizationInfo.setRet_url(ret_url);
			authorizationInfo.setCancel_url(cancel_url);
			
			DateFormat df = new SimpleDateFormat("yyyyMMddHHmmss");
			Date today = Calendar.getInstance().getTime();        
			String dateTimeString = df.format(today);
			
			authorizationInfo.setDate_time(dateTimeString);
			authorizationInfo.setOrder_id(dateTimeString);
			
			String shopPassString = EncryptionUtils.cryptWithMD5(authorizationInfo.getShop_id() + "|" + authorizationInfo.getOrder_id() + "|" 
					+ authorizationInfo.getAuth_amt() + "|" + authorizationInfo.getTax() + "|" + authorizationInfo.getShop_password() + "|" + authorizationInfo.getDate_time());
			
			authorizationInfo.setShop_pass_string(shopPassString);
			authorizationInfo.setGmoPayUrlResquestion(MssConfiguration.getInstance().getGmoPayUrlResquestion().replaceAll("shop_id_replace", authorizationInfo.getShop_id()));
			//authorizationInfo.setGmoPayUrlCancelation(MssConfiguration.getInstance().getGmoPayUrlCancelation());
			authorizationInfo.setJob_cd("AUTH");
			
			LOG.info("[End] Send payment info.");
			model.addAttribute("authorizationInfo", authorizationInfo);
		}
	    
		return new ModelAndView("front.booking.info.pay");
	}

	private Map<Integer, String> createMapChild(List<UserChildModel> lstChild) {
		Map<Integer, String> mapChild = new LinkedHashMap<Integer, String>();
		mapChild.put(null, getText("fe00302.select.child"));
		if (CollectionUtils.isNotEmpty(lstChild)) {
			for (UserChildModel childModel : lstChild) {
				mapChild.put(childModel.getChildId(), childModel.getChildName());
			}
		}
		return mapChild;
	}

	/**
	 * Confirm booking info.
	 *
	 * @param patient
	 *            the patient
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.INPUT_INFO }, stepType = NavigationType.BOOKING_STEPS)
	@RequestMapping(value = "/booking-info", method = RequestMethod.POST)
	@SessionValidate
	public ModelAndView postBookingInfo(@Valid @ModelAttribute("patient") PatientModel patient, BindingResult result,
			ModelMap model, HttpSession session) throws Exception {
		LOG.info("[Start] booking info.");
		String urlUpload = "";
		if (getUser() != null) {
			String token = getUser().getToken();
			Long profileId = getUser().getMasterProfileId();
			String phrURI = phrApiService.getFullUrl("");
			urlUpload = phrURI + "api/profiles/" + profileId + "/upload?token=" + token;
		}
		String pattern = "yyyy/MM/dd";
		String fullName = patient.getName();
		String fullNameKana = patient.getNameFurigana();
		if (HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
			if (result.getFieldError(fullName) == null && result.getFieldError(fullNameKana) == null) {
				LOG.debug("Full Name: " + fullName + " Full Name Kana: " + fullNameKana);
				// check space ã‚­ãƒŽã‚·ã‚¿ ã‚´ã‚¦ ã¡ ã¡
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("name", "general.label.name.required.space");
				}
				if (!StringUtils.isEmpty(fullNameKana)
						&& !fullNameKana.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("nameFurigana", "general.label.name.required.space");
				}
			}
		} else {
			if (result.getFieldError(fullName) == null) {
				LOG.debug("Full Name: " + fullName);
				// check space
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("name", "general.label.name.required.space");
				}
			}
		}
		// check validate Date
		if (patient.getDob() != null && patient.getDob().length() > 0) {
			Date date = null;
			try {
				DateFormat formater = new SimpleDateFormat(pattern);
				formater.setLenient(false);
				date = formater.parse(patient.getDob());
			} catch (Exception ex) {
				result.rejectValue("dob", "re002.msg.dob.invalid");
			}
		}

		patient.setMapReminderTime(getReminderTimeMap());
		if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode()))
			patient.setNewBooking(false);
		else
			patient.setNewBooking(true);
		model.addAttribute("patient", patient);
		Map<Integer, String> mapChild = new HashMap<Integer, String>();
		// View choose child if booking borns
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (bookingInfo == null) {
			LOG.warn("[WARN] postBookingInfo bookingInfo is null");
			return new ModelAndView(new RedirectView("booking-new"));
		}
		if (this.getUser() != null && DepartmentType.NEWBORNS.toInt().equals(bookingInfo.getDeptType())) {
			List<UserChildModel> lstChild = userChildService.findUserChildByActiveFlg(this.getUser().getUserId(),
					ActiveFlag.ACTIVE.toInt());
			mapChild = createMapChild(lstChild);
			model.addAttribute("lstChild", mapChild);
			model.addAttribute("isBookingNewBorns", true);
		}

		if ((MssContextHolder.isKcck())) {
			model.addAttribute("isKcck", true);
		} else {
			model.addAttribute("isKcck", false);
		}

		model.addAttribute("bookingTime",
				bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());

		// Chooise child if booking new born
		if (DepartmentType.NEWBORNS.toInt().equals(bookingInfo.getDeptType())) {
			if (patient.getChildId() == null) {
				result.rejectValue("childId", "fe00302.msg.err.select.child");
			}
			bookingInfo.setChildName(mapChild.get(patient.getChildId()));
		}
		Integer bookingMode = MssContextHolder.getReservationMode();
		if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(bookingMode)
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(bookingMode)) {
			model.addAttribute("needUpdateInsurance", true);
		}
		// validate input data
		if (result.hasErrors()) {
			// return new ModelAndView(new RedirectView("booking-info"));
			model.addAttribute("reservationMode", MssContextHolder.getReservationMode());
			model.addAttribute("patient", patient);
			model.addAttribute("urlUpload", urlUpload);
			return new ModelAndView("front.booking.info");
		}
		LOG.debug("[Debug] " + patient.toString());
		bookingInfo.setPatientName(patient.getName());
		bookingInfo.setPatientFurigana(patient.getNameFurigana());
		bookingInfo.setEmail(patient.getEmail());
		bookingInfo.setPhoneNumber(patient.getPhoneNumber());
		bookingInfo.setEmail(patient.getEmail());
		bookingInfo.setPatientGender(patient.getGender());
		bookingInfo.setPatientDob(patient.getDob());
		bookingInfo.setPatientBitrhday(
				MssDateTimeUtil.dateFromString(patient.getDob(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		bookingInfo.setCardNumber(patient.getCardNumber());
		bookingInfo.setReminderTime(patient.getReminderTime());
		bookingInfo.setChildId(patient.getChildId());
		bookingInfo.setPatientIconPath(patient.getPatientIconPath());
		LOG.info("[End] booking info.");
		
		return new ModelAndView(new RedirectView("booking-info-confirm"));
	}
	
	@RequestMapping("/result-payment")
	public ModelAndView resultProcessPayment(ModelMap model, HttpServletRequest request) throws Exception {
		LOG.info("[Start] View result process payment.");
		PaymentInfoModel paymentInfo = MssContextHolder.getPaymentInfo();
		
		HttpSession session = request.getSession(true);
		KcckGmoShopInfoModel authorizationInfo = null;
		if(session.getAttribute(KCCK_AUTHORIZATION_INFO) != null) {
			authorizationInfo = (KcckGmoShopInfoModel)session.getAttribute(KCCK_AUTHORIZATION_INFO);
		}
		
		List<String> paramsReturn = Arrays.asList("JobCd", "OrderID", "Forwarded", "Method", "PayTimes", "Approve", "TranID",
				"TranDate", "CheckString","ErrCode","ErrInfo", "AccessID", "AccessPass", "JobCd");
		Map<String, Object> resultPayment = new HashMap<>();
		for (String param : paramsReturn) {
			resultPayment.put(param, request.getParameter(param));
		}
		
		String errCode          = Optional.ofNullable(resultPayment.get("ErrCode")).map(Object::toString).orElse("null");
		String errInfo          = Optional.ofNullable(resultPayment.get("ErrInfo")).map(Object::toString).orElse("null");
		String orderID          = Optional.ofNullable(resultPayment.get("OrderID")).map(Object::toString).orElse("null");
		String forwarded        = Optional.ofNullable(resultPayment.get("Forwarded")).map(Object::toString).orElse("null");
		String method           = Optional.ofNullable(resultPayment.get("Method")).map(Object::toString).orElse("null");
		String payTimes         = Optional.ofNullable(resultPayment.get("PayTimes")).map(Object::toString).orElse("null");
		String approve          = Optional.ofNullable(resultPayment.get("Approve")).map(Object::toString).orElse("null");
		String tranID           = Optional.ofNullable(resultPayment.get("TranID")).map(Object::toString).orElse("null");
		String tranDate         = Optional.ofNullable(resultPayment.get("TranDate")).map(Object::toString).orElse("null");
		String checkString      = Optional.ofNullable(resultPayment.get("CheckString")).map(Object::toString).orElse("null");
		String accessID         = Optional.ofNullable(resultPayment.get("AccessID")).map(Object::toString).orElse("null");
		String accessPass       = Optional.ofNullable(resultPayment.get("AccessPass")).map(Object::toString).orElse("null");
		
		if(authorizationInfo == null || !authorizationInfo.getOrder_id().equalsIgnoreCase(orderID)) {
			return new ModelAndView("front.access.denied");
		}
		
		String returnPass = EncryptionUtils.cryptWithMD5(orderID + forwarded + method + payTimes + approve + tranID + tranDate + authorizationInfo.getShop_password());
		
		TransactionModel transactionModel = new TransactionModel();
		transactionModel.setRequestId(orderID);
		transactionModel.setRefId(tranID);
		transactionModel.setExecutedDatetime(new Date());
		transactionModel.setAmount(authorizationInfo.getAuth_amt());
		transactionModel.setCurrency(authorizationInfo.getCurrency());
		transactionModel.setErrorCode(errCode);
		transactionModel.setPaymentGw("GMO");
		transactionModel.setAccessId(accessID);
		transactionModel.setAccessPass(accessPass);
		transactionModel.setHospitalId(MssContextHolder.getHospitalId());
		transactionModel.setSysId("MBS");
		transactionModel.setUpdId("MBS");
		
		boolean isSuccess = false;
		if (returnPass.equals(checkString) && StringUtils.isEmpty(errCode) && StringUtils.isEmpty(errInfo)) {
			isSuccess = true;
			
			model.addAttribute("transactionIdReturn", tranID);
			model.addAttribute("paymentDate", MssDateTimeUtil.formatDateString(tranDate));
			
			// Save transaction info
			transactionModel.setStatus(PaymentStatus.AUTHORIZATION.toInt());
			Transaction transaction = transactionService.saveTransaction(transactionModel);
			
			return createReservationAndSendMailBookingComplete(request, transaction);
		} else {		
			isSuccess = false;

			if(!nta.med.common.util.Strings.isEmpty(tranID)) {
				transactionModel.setStatus(PaymentStatus.AUTHORIZATION.toInt());
				transactionService.saveTransaction(transactionModel);
			} else {
				LOG.warn("Transaction id is empty order Id: "+ orderID+ " errCode="+errCode+"" +
						" errInfo="+errInfo+" method="+method+" payTimes="+payTimes+" approve="+ approve+" tranID="+
						tranID+" tranDate"+tranDate+" checkString="+ checkString+" returnPass="+returnPass+" forwarded="+ forwarded);
			}
			String messageErr = "";
			try {
				ResourceBundle rb = ResourceBundle.getBundle("gmo_messages_ja",this.getLocale());
				messageErr = rb.getString(errInfo + "_JA");
			} catch(Exception e) {
				messageErr = this.getText("fe903.error.title");
			}
			model.addAttribute("errorCode", messageErr);
			
			if("3".equalsIgnoreCase(authorizationInfo.getBookingMode())) {
				return new ModelAndView(new RedirectView("online-booking-new?" + request.getQueryString()));
			} else if("4".equalsIgnoreCase(authorizationInfo.getBookingMode())) {
				return new ModelAndView(new RedirectView("re-examination-confirm?" + request.getQueryString()));
			}
		}
		model.addAttribute("isSuccess", isSuccess);
		model.addAttribute("paymentInfo", paymentInfo);
		
		return new ModelAndView(new RedirectView("booking-accept?" + request.getQueryString()));
	}
	
	public ModelAndView createReservationAndSendMailBookingComplete(HttpServletRequest request, Transaction transaction) throws Exception {
		LOG.info("[Start] booking accept");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		// Check doctor is full
		if (!MssContextHolder.isKcck()) {
			if (this.doctorScheduleService.isDoctorScheduleFull(bookingInfo.getDoctorId(),
					bookingInfo.getReservationDate(), bookingInfo.getReservationTime())) {
				this.addNotification(
						new NotificationModel(NotificationType.ERROR, this.getText("fe005.msg.full.time.slot")));
				return new ModelAndView(new RedirectView("booking-info-confirm"));
			}
		}

		Long patientId = 0L;
		if (this.getUser() != null && this.getUser().getMasterProfileId() != null) {
			patientId = this.getUser().getMasterProfileId();
		}

		// save reservation - reservationStatus = 0
		if (!StringUtils.isEmpty(bookingInfo.getPatientDob()) && bookingInfo.getPatientBitrhday() == null) {
			bookingInfo.setPatientBitrhday(MssDateTimeUtil.dateFromString(bookingInfo.getPatientDob(), DateTimeFormat.DATE_FORMAT_YYYY_MM_DD));
		}
		ReservationModel reservationModel = bookingService.savePatientInfo(bookingInfo,
				MssContextHolder.getReservationMode(), MssContextHolder.getHospitalId(), false, patientId, transaction);

		bookingInfo.setReservationCode(reservationModel.getReservationCode());
		// Get patientCode in case of rebooking
		String patientCodeRebooking = MssContextHolder.getBookingInfo().getCardNumber();
		if (patientCodeRebooking == null) {
			patientCodeRebooking = "";
		}
		// send mail when accept temporary
		MailInfo mailInfo = createEmailInfo(bookingInfo, reservationModel.getHospitalName());
		List<Object> args = new ArrayList<Object>();
		args.add(MssContextHolder.getTokenHospCode());
		if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
			args.add("MBSO");
		} else if (BookingMode.NEW_BOOKING.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())) {
			args.add("MBS");
		}
		args.add(MssContextHolder.getReservationMode());
		args.add(MssContextHolder.getUserToken());
		args.add(MssContextHolder.getMasterProfile());
		args.add(patientCodeRebooking);
		args.add(MssContextHolder.getAutoRecept().toString());
		mailInfo.setLinkBookingComplete(MssContextHolder.getDomainName()
				+ this.getText("be030.link.for.booking.complete", args) + mailInfo.getSessionId().toString());
		List<String> toList = new ArrayList<>();
		toList.add(bookingInfo.getEmail());
		mailService.sendMail(MailCode.BOOKING_NEW_ACCEPTED.toString(), this.getLanguage(), mailInfo, toList,
				reservationModel.getPatientId(), reservationModel.getReservationId(), MssContextHolder.getHospitalId(),
				MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());

		// Set model
		ModelAndView modelAndView = new ModelAndView("front.booking.accept");
		if (MssContextHolder.isKcck()) {
			// modelAndView.addObject("reservationCode",
			// bookingInfo.getReservationCode());
			modelAndView.addObject("isKcck", true);
		} else {
			modelAndView.addObject("isKcck", false);
		}
		modelAndView.addObject("deptName", bookingInfo.getDeptName());
		if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
			modelAndView.addObject("bookingTime",
					bookingInfo.getFormattedReservationTime() + " " + bookingInfo.getFormattedReservationDate());
		} else {
			modelAndView.addObject("bookingTime",
					bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
		}

		ReminderTime time = ReminderTime.newInstance(bookingInfo.getReminderTime());
		modelAndView.addObject("reminderTime", time.toText());
		LOG.info("[End] booking accept");
		
		//return modelAndView;
		return new ModelAndView(new RedirectView("booking-accept?" + request.getQueryString()));
	}

	/**
	 * Confirm booking info.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 */
	@NavigationConfig(group = { NavigationGroup.CONFIRM }, stepType = NavigationType.BOOKING_STEPS)
	@RequestMapping(value = "/booking-info-confirm", method = RequestMethod.GET)
	@SessionValidate
	public ModelAndView confirmBookingInfo(ModelMap model, HttpServletRequest request) throws Exception {
		LOG.info("[Start] Confirm booking info.");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		PatientModel patient = new PatientModel();
		Integer bookingMode = MssContextHolder.getReservationMode();
		if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode()))
			patient.setNewBooking(false);
		else
			patient.setNewBooking(true);

		patient.setName(bookingInfo.getPatientName());
		patient.setNameFurigana(bookingInfo.getPatientFurigana());
		patient.setEmail(bookingInfo.getEmail());
		patient.setPhoneNumber(bookingInfo.getPhoneNumber());
		patient.setCardNumber(bookingInfo.getCardNumber());
		patient.setReminderTime(bookingInfo.getReminderTime());
		patient.setChildId(bookingInfo.getChildId());
		Map<Integer, String> mapReminderTime = new HashMap<>();
		ReminderTime time = ReminderTime.newInstance(bookingInfo.getReminderTime());
		mapReminderTime.put(time.toKey(), time.toText());
		patient.setMapReminderTime(mapReminderTime);
		if ("M".equals(bookingInfo.getPatientGender())) {
			patient.setGenderText(this.getText("general.label.male"));
		} else {
			patient.setGenderText(this.getText("general.label.female"));
		}
		patient.setDob(bookingInfo.getPatientDob());

		if (DepartmentType.NEWBORNS.toInt().equals(bookingInfo.getDeptType())) {
			UserChildModel childModel = userChildService.findById(bookingInfo.getChildId());
			if ("1".equals(childModel.getSex())) {
				patient.setGenderText(this.getText("general.label.male"));
			} else {
				patient.setGenderText(this.getText("general.label.female"));
			}
			Date birthOfDate = MssDateTimeUtil.dateFromString(childModel.getDob(), DateTimeFormat.DATE_FORMAT_YYYYMMDD);
			patient.setDob(MssDateTimeUtil.dateToString(birthOfDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		}
		if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(bookingMode)
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(bookingMode)) {
			model.addAttribute("imageInsurance", true);
			model.addAttribute("linkInsurance", bookingInfo.getPatientIconPath());
		}
		model.addAttribute("reservationMode", MssContextHolder.getReservationMode());
		model.addAttribute("patient", patient);
		model.addAttribute("deptName", bookingInfo.getDeptName());
		model.addAttribute("bookingDate", bookingInfo.getFormattedReservationDate());
		model.addAttribute("bookingTime", bookingInfo.getFormattedReservationTime());
		// If booking child newborns
		if (DepartmentType.NEWBORNS.toInt().equals(bookingInfo.getDeptType())) {
			model.addAttribute("isBookingNewBorns", true);
			model.addAttribute("childName", bookingInfo.getChildName());
		}
		boolean hideSomeFields = false;
		if (BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(bookingMode)) {
			hideSomeFields = true;
			model.addAttribute("hideSomeFields", hideSomeFields);
		}
		// check Kcck - Mss
		if ((MssContextHolder.isKcck())) {
			model.addAttribute("isKcck", true);
		}
		LOG.info("[End] Confirm booking info.");
		
		KcckGmoShopInfoModel authorizationInfo = null;
		boolean isAuthorization = false;
		if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(bookingMode) || BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(bookingMode)) {
			// Booking Movie Talk --> AUTHORIZATION
			authorizationInfo = kcckApiServiceBooking.getGmoShopInfo(MssContextHolder.getHospCode());
			
			if(authorizationInfo != null && StringUtils.isNotEmpty(authorizationInfo.getShop_id()) && StringUtils.isNotEmpty(authorizationInfo.getShop_password()) 
					&& "Y".equalsIgnoreCase(authorizationInfo.getUse_auth()) && authorizationInfo.getAuth_amt() > 0) {
				isAuthorization = true;
				authorizationInfo.setPatientname(bookingInfo.getPatientName());
				authorizationInfo.setBookingMode(bookingMode.toString());
			}
		}
		
		if(authorizationInfo == null) {
			authorizationInfo = new KcckGmoShopInfoModel("", "", "N", 0, "", "", "");
		}
		
		authorizationInfo.setAuthorization(isAuthorization);
		authorizationInfo.setLocale(MssContextHolder.getHospitalLocale());
		//model.addAttribute("authorizationInfo", authorizationInfo);
		
		// GMO
		if(isAuthorization) {
			LOG.info("[Start] Send payment info.");
			
			String baseURL = MssConfiguration.getInstance().getServerAddressJp();
			if (!StringUtils.isEmpty(MssContextHolder.getUserLanguage())) {
				if (MssContextHolder.getUserLanguage().equals("ja")) {
					baseURL = MssConfiguration.getInstance().getServerAddressJp();
					authorizationInfo.setCurrencyDisplay("JPY");//円
				} else {
					baseURL = MssConfiguration.getInstance().getServerAddress();
					authorizationInfo.setCurrencyDisplay("USD");//$
				}
			}
			String ret_url = baseURL + "/booking/result-payment?" + request.getQueryString();
			String cancel_url = baseURL + "/booking/result-payment?" + request.getQueryString();
			
			//KcckGmoShopInfoModel authorizationInfo = null;
			authorizationInfo.setRet_url(ret_url);
			authorizationInfo.setCancel_url(cancel_url);
			
			Date today = Calendar.getInstance().getTime();        
			authorizationInfo.setDate_time(MssDateTimeUtil.dateToString(today, DateTimeFormat.DATE_TIME_FORMAT_YYYYMMDDHHMMSS));
			authorizationInfo.setOrder_id("SAUTH" + MssContextHolder.getHospCode() + MssDateTimeUtil.dateToString(today, DateTimeFormat.DATE_FORMAT_YYYYMMDD) + RandomStringUtils.randomNumeric(8));
			
			String shopPassString = EncryptionUtils.cryptWithMD5(authorizationInfo.getShop_id() + "|" + authorizationInfo.getOrder_id() + "|" 
					+ authorizationInfo.getAuth_amt() + "|" + authorizationInfo.getTax() + "|" + authorizationInfo.getShop_password() + "|" + authorizationInfo.getDate_time());
			
			authorizationInfo.setShop_pass_string(shopPassString);
			authorizationInfo.setGmoPayUrlResquestion(MssConfiguration.getInstance().getGmoPayUrlResquestion().replaceAll("shop_id_replace", authorizationInfo.getShop_id()));
			authorizationInfo.setJob_cd("SAUTH");
			
			HttpSession session = request.getSession(true);
			session.setAttribute(KCCK_AUTHORIZATION_INFO, authorizationInfo);
			
			LOG.info("[End] Send payment info.");
		}
		
		model.addAttribute("authorizationInfo", authorizationInfo);
		
		return new ModelAndView("front.booking.info.confirm");
	}

	/**
	 * Submit booking info.
	 * 
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@NavigationConfig(group = { NavigationGroup.TEMP_SCHEDULE }, stepType = NavigationType.BOOKING_STEPS)
	@RequestMapping(value = "/booking-accept", method = RequestMethod.POST)
	@SessionValidate
	public ModelAndView submitBookingInfo() throws Exception {
		LOG.info("[Start] booking accept");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		// Check doctor is full
		if (!MssContextHolder.isKcck()) {
			if (this.doctorScheduleService.isDoctorScheduleFull(bookingInfo.getDoctorId(),
					bookingInfo.getReservationDate(), bookingInfo.getReservationTime())) {
				this.addNotification(
						new NotificationModel(NotificationType.ERROR, this.getText("fe005.msg.full.time.slot")));
				return new ModelAndView(new RedirectView("booking-info-confirm"));
			}
		}

		Long patientId = 0L;
		if (this.getUser() != null && this.getUser().getMasterProfileId() != null) {
			patientId = this.getUser().getMasterProfileId();
		}

		// save reservation - reservationStatus = 0
		if (!StringUtils.isEmpty(bookingInfo.getPatientDob()) && bookingInfo.getPatientBitrhday() == null) {
			bookingInfo.setPatientBitrhday(
					MssDateTimeUtil.dateFromString(bookingInfo.getPatientDob(), DateTimeFormat.DATE_FORMAT_YYYY_MM_DD));
		}
		ReservationModel reservationModel = bookingService.savePatientInfo(bookingInfo,
				MssContextHolder.getReservationMode(), MssContextHolder.getHospitalId(), false, patientId, null);
		// TODO

		bookingInfo.setReservationCode(reservationModel.getReservationCode());
		// Get patientCode in case of rebooking
		String patientCodeRebooking = MssContextHolder.getBookingInfo().getCardNumber();
		if (patientCodeRebooking == null) {
			patientCodeRebooking = "";
		}
		// send mail when accept temporary
		MailInfo mailInfo = createEmailInfo(bookingInfo, reservationModel.getHospitalName());
		List<Object> args = new ArrayList<Object>();
		args.add(MssContextHolder.getTokenHospCode());
		if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
			args.add("MBSO");
		} else if (BookingMode.NEW_BOOKING.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())) {
			args.add("MBS");
		}
		args.add(MssContextHolder.getReservationMode());
		args.add(MssContextHolder.getUserToken());
		args.add(MssContextHolder.getMasterProfile());
		args.add(patientCodeRebooking);
		args.add(MssContextHolder.getAutoRecept().toString());
		mailInfo.setLinkBookingComplete(MssContextHolder.getDomainName()
				+ this.getText("be030.link.for.booking.complete", args) + mailInfo.getSessionId().toString());
		List<String> toList = new ArrayList<>();
		toList.add(bookingInfo.getEmail());
		mailService.sendMail(MailCode.BOOKING_NEW_ACCEPTED.toString(), this.getLanguage(), mailInfo, toList,
				reservationModel.getPatientId(), reservationModel.getReservationId(), MssContextHolder.getHospitalId(),
				MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());

		// Set model
		ModelAndView modelAndView = new ModelAndView("front.booking.accept");
		if (MssContextHolder.isKcck()) {
			// modelAndView.addObject("reservationCode",
			// bookingInfo.getReservationCode());
			modelAndView.addObject("isKcck", true);
		} else {
			modelAndView.addObject("isKcck", false);
		}
		modelAndView.addObject("deptName", bookingInfo.getDeptName());
		if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
			modelAndView.addObject("bookingTime",
					bookingInfo.getFormattedReservationTime() + " " + bookingInfo.getFormattedReservationDate());
		} else {
			modelAndView.addObject("bookingTime",
					bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
		}

		ReminderTime time = ReminderTime.newInstance(bookingInfo.getReminderTime());
		modelAndView.addObject("reminderTime", time.toText());
		LOG.info("[End] booking accept");
		return modelAndView;
	}

	/**
	 * View booking info.
	 *
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@NavigationConfig(group = { NavigationGroup.TEMP_SCHEDULE }, stepType = NavigationType.BOOKING_STEPS)
	@RequestMapping(value = "/booking-accept", method = RequestMethod.GET)
	@SessionValidate
	public ModelAndView viewBookingInfo() throws Exception {
		LOG.info("[Start] booking accept");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();

		// Set model
		ModelAndView modelAndView = new ModelAndView("front.booking.accept");
		modelAndView.addObject("reservationCode", bookingInfo.getReservationCode());
		modelAndView.addObject("deptName", bookingInfo.getDeptName());
		modelAndView.addObject("bookingTime",
				bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
		ReminderTime time = ReminderTime.newInstance(bookingInfo.getReminderTime());
		modelAndView.addObject("reminderTime", time.toText());

		LOG.info("[End] booking accept");
		return modelAndView;
	}

	/**
	 * Creates the email info.
	 *
	 * @param bookingInfo
	 *            the booking info
	 * @param hospitalName
	 *            the hospital name
	 * @return the mail info
	 */
	private MailInfo createEmailInfo(BookingInfo bookingInfo, String hospitalName) {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setPatientName(bookingInfo.getPatientName());
		mailInfo.setHospitalName(hospitalName);

		// mailInfo.setReservationCode(bookingInfo.getReservationCode());

		mailInfo.setReservationCode("");
		if (bookingInfo.getCardNumber() != null) {
			mailInfo.setPatientCode(bookingInfo.getCardNumber());
		} else {
			mailInfo.setPatientCode("");
		}
		mailInfo.setDepartmentName(bookingInfo.getDeptName());
		if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
			mailInfo.setReservationDatetime(
					bookingInfo.getFormattedReservationTime() + " " + bookingInfo.getFormattedReservationDate());
		} else {
			mailInfo.setReservationDatetime(
					bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
		}

		mailInfo.setReminderTime(bookingInfo.getReminderTime().toString());
		mailInfo.setSessionId(bookingInfo.getTokenId());

		// Set infomation when booking vaccine
		if (!StringUtils.isBlank(bookingInfo.getChildName())) {
			mailInfo.setChildName(bookingInfo.getChildName());
		}
		if (!StringUtils.isBlank(bookingInfo.getDob())) {
			mailInfo.setDob(bookingInfo.getDob());
		}
		if (!StringUtils.isBlank(bookingInfo.getSex())) {
			if (bookingInfo.getSex().equals(GenderChild.FEMALE.toString())) {
				mailInfo.setSex(this.getText("general.label.sex.female"));
			} else if (bookingInfo.getSex().equals(GenderChild.MALE.toString())) {
				mailInfo.setSex(this.getText("general.label.sex.male"));
			}
		}
		if (!StringUtils.isBlank(bookingInfo.getVaccineName())) {
			mailInfo.setVaccineName(bookingInfo.getVaccineName());
		}
		if (!StringUtils.isBlank(bookingInfo.getTimesUsing())) {
			mailInfo.setTimesUsing(bookingInfo.getTimesUsing());
		}

		return mailInfo;
	}

	/**
	 * Complete booking.
	 * 
	 * @param tokenId
	 *            the token id
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@NavigationConfig(group = { NavigationGroup.FINISH_SCHEDULE }, stepType = NavigationType.BOOKING_STEPS)
	@RequestMapping(value = "/booking-complete", method = RequestMethod.GET)
	public ModelAndView completeBooking(@RequestParam(value = "token") String tokenId,
			@RequestParam(value = "sysId") String sysId, @RequestParam(value = "user_token") String user_token,
			@RequestParam(value = "master_profile") String master_profile,
			@RequestParam(value = "booking_mode") String bookingMode,
			@RequestParam(value = "patient_code_re") String patientCodeRebooking,
			@RequestParam(value = "quick_mode") String quickMode,
			@RequestParam(value = "tokenHospCode", required = false) String tokenHospCode) throws Exception {
		LOG.info("[Start] Booking complete");
		ModelAndView modelAndView = new ModelAndView("front.booking.complete");
		TokenValidationResult tokenResult = TokenUtils.validateToken(tokenId);



		if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
			SessionModel session = this.bookingService.getSessionById(tokenId);
			tokenResult = TokenUtils.validateToken(session);
		}
		if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
			// TODO
			ReservationModel reservationModel;

			if ((MssContextHolder.isKcck())) {
				reservationModel = bookingService.findKcckReservationBySessionId(tokenId);
			} else {
				reservationModel = bookingService.findReservationBySessionId(tokenId);
			}
			// check reservation session
			if (reservationModel == null) {
				LOG.warn("[WARN] Booking complete. reservationModel is null");
				return new ModelAndView(new RedirectView("expire"));
			}
			// update reading flag of mail
			MailTemplateModel mailModel = this.bookingService.getMailTemplateByCode("BOOKING_NEW_ACCEPTED",
					this.getLanguage(), MssContextHolder.getHospitalId());
			if (mailModel != null) {
				this.bookingService.updateReadingFlag(tokenId, mailModel.getMailTemplateId());
			}

			if (MssContextHolder.getHospitalParentId() != 1) {
				modelAndView.addObject("hospitalName", reservationModel.getHospitalName());
				// check the status of reservation that is deleted of not
				if (ReservationStatus.CANCELLED.toInt().equals(reservationModel.getReservationStatus())) {
					modelAndView.addObject("isDeletedBooking", true);
					return modelAndView;
				}
				// check the status of reservation that is already completed or
				// not
				if (ReservationStatus.BOOKING_COMPLETED.toInt().equals(reservationModel.getReservationStatus())) {
					modelAndView.addObject("isAlreadyCompleted", true);
					return modelAndView;
				}
				// check the doctor schedule before change reservation status

				if (this.doctorScheduleService.isDoctorScheduleFull(reservationModel.getDoctorId(),
						reservationModel.getReservationDate(), reservationModel.getReservationTime())) {
					modelAndView.addObject("isDoctorScheduleFull", true);
					return modelAndView;
				}

				// send mail
				MailInfo mailInfo = createMailInfoCompleteBooking(reservationModel, null);
				List<String> toList = new ArrayList<>();
				toList.add(reservationModel.getEmail());
				mailService.sendMail(MailCode.BOOKING_NEW_COMPLETED.toString(), this.getLanguage(), mailInfo, toList,
						reservationModel.getPatientId(), reservationModel.getReservationId(),
						MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
						MssContextHolder.getDomainName());
			}
			boolean isKcck = false;
			// check KCCK -MSS
			if ((MssContextHolder.isKcck())) {
				isKcck = true;
				KcckReservationModel kcckModel = new KcckReservationModel();

				DepartmentModel departmentModel = kcckDepartmentService.

						findKcckDepartmentById(MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(),
								reservationModel.getDeptId());
				DoctorModel doctorModel = kcckDoctorService.findKcckDoctorByCode(MssContextHolder.getHospCode(),
						reservationModel.getDoctorCode(), departmentModel.getDeptCode());
				String reservationDate = MssDateTimeUtil.convertBetweenDateFormat(reservationModel.getReservationDate(),
						DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);

				// rebooking
				if (doctorModel != null) {
					kcckModel.setDoctor_code(doctorModel.getDoctorCode());
				}
				if (!StringUtils.isEmpty(patientCodeRebooking)) {
					kcckModel.setPatient_code(patientCodeRebooking);
				} else {
					kcckModel.setPatient_code(reservationModel.getCardNumber());
				}
				// newbooking
				kcckModel.setPatient_name_kanji(reservationModel.getPatientName());
				if (HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
					kcckModel.setPatient_name_kana(LanguageUtils.convertKana(reservationModel.getNameFurigana()));
				} else {
					kcckModel.setPatient_name_kana(reservationModel.getPatientName());
				}
				kcckModel.setPatient_tel(reservationModel.getPhoneNumber());
				kcckModel.setPatient_email(reservationModel.getEmail());
				kcckModel.setPatient_sex(reservationModel.getPatientSex());
				kcckModel.setPatient_birthday(reservationModel.getPatientBirtday());
				//
				kcckModel.setHosp_code(MssContextHolder.getHospCode());
				kcckModel.setDepartment_code(departmentModel.getDeptCode());

				kcckModel.setReservation_date(reservationDate);
				kcckModel.setReservation_time(reservationModel.getReservationTime());
				kcckModel.setLocale(MssContextHolder.getLocale().toString());
				kcckModel.setSys_id(sysId);
				// Vaccine
				String childCodeList = this.bookingService.getChildCodeList(reservationModel.getCardNumber());
				kcckModel.setChild_code_list(childCodeList);
				// send reservation to KCCK
				LOG.info("BEFORE: saveReservation: reservation Info :" + kcckModel.toString());
				if (bookingMode.toString().equals("3")) {
					kcckModel.setSurvey_yn("Y");
				} else {
					kcckModel.setSurvey_yn("N");
				}
				modelAndView.addObject("sysId", sysId);
				modelAndView.addObject("master_profile", master_profile);
				modelAndView.addObject("patient_code_re", patientCodeRebooking);
				modelAndView.addObject("user_token", user_token);
				modelAndView.addObject("bookingMode", bookingMode);
				modelAndView.addObject("token", tokenId);
				modelAndView.addObject("quick_mode", quickMode);
				//Check isAuto Reception
				kcckModel.setQuick_mode(quickMode);
				kcckModel.setReservation_id(reservationModel.getReservationId().toString());
				if(cache.get(tokenId) == null)
				{
					cache.put(tokenId, new MSSSession());
					kcckBookingService1.saveReservationAsyn(kcckModel);
				}

				MssContextHolder.setReservationModel(reservationModel);
			}
			else {
				// update Reservation Status
				reservationModel.setReservationStatus(ReservationStatus.BOOKING_COMPLETED.toInt());
				// update reservation -- reservationStatus =1
				bookingService.updateReservation(reservationModel);
				modelAndView.addObject("reservationCode", reservationModel.getReservationCode());
				modelAndView.addObject("patientCode", reservationModel.getCardNumber());				
				modelAndView.addObject("hospitalName", reservationModel.getHospitalName());
				modelAndView.addObject("deptName", reservationModel.getDeptName());
				if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
					modelAndView.addObject("bookingTime", reservationModel.getFormattedReservationTime() + " "
							+ reservationModel.getFormattedReservationDate());
				} else {
					modelAndView.addObject("bookingTime", reservationModel.getFormattedReservationDate() + " "
							+ reservationModel.getFormattedReservationTime());
				}
				ReminderTime time = ReminderTime.newInstance(reservationModel.getReminderTime());
				modelAndView.addObject("reminderTime", time.toText());
				modelAndView.addObject("token", tokenId);
				LOG.info("[End] Booking complete");
			}
			modelAndView.addObject("isKcck", isKcck);
			return modelAndView;
		}
		else {
			return new ModelAndView(new RedirectView("expire"));
		}		
	}
	
	@RequestMapping(value = "/ajax-booking-after-asyn", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse bookingCompleteAfterAsyn(@RequestBody Map<String,String> response) throws Exception
	{
		LOG.info("[Start] Ajax select booking complete after asyn");
		String sysId = response.get("sysId");
		String master_profile = response.get("master_profile");
		String patientCodeRebooking = response.get("patient_code_re");
		String userToken = response.get("user_token");
		String bookingMode = response.get("bookingMode");
		String tokenId = response.get("token");
		Map<String,String> dataSend = new HashMap<>();
		boolean surveyLink = (bookingMode.equals("3"))?true:false;
		ReservationModel reservationModel = MssContextHolder.getReservationModel();
		if (!StringUtils.isEmpty(patientCodeRebooking)) {
			reservationModel.setCardNumber(patientCodeRebooking);
		}
		KcckReservationModel kcckReservationModel = reservationService.getReservation(reservationModel.getReservationId(),surveyLink);
		if(kcckReservationModel !=null && kcckReservationModel.getReservation_code() != null)
		{
			dataSend.put("isNotSuccess", "false");
			LOG.info("reservation KCCK Info :" + kcckReservationModel.toString());
				
			bookingService.updatePatient(reservationModel.getPatientId(), kcckReservationModel.getParent_code(), null);
			dataSend.put("reservationCode", kcckReservationModel.getReservation_code());
		    reservationModel.setReservationCode(kcckReservationModel.getReservation_code());
			reservationModel.setDeptName(kcckReservationModel.getDepartment_name());
			reservationModel.setDoctorName(kcckReservationModel.getDoctor_name());
			reservationModel.setDoctorCode(kcckReservationModel.getDoctor_code());
			reservationModel.setDepartmentCode(kcckReservationModel.getDepartment_code());
			DoctorModel doctor = kcckDoctorService.findKcckDoctorByCode(MssContextHolder.getHospCode(), kcckReservationModel.getDoctor_code(), kcckReservationModel.getDepartment_code());
			if(doctor != null)
			{
				reservationModel.setDoctorId(doctor.getDoctorId());
			}
			//update Reservation status
			reservationModel.setReservationStatus(ReservationStatus.BOOKING_COMPLETED.toInt());
			reservationModel.setReferLink(MssContextHolder.getBookingInfo().getPatientIconPath());
			
			reservationModel.setHospitalName(MssContextHolder.getHospitalName());
			if (StringUtils.equals("MBSO", sysId)) {
				PhrAccountClinicModel phrAccountModel = new PhrAccountClinicModel();
				phrAccountModel.setHosp_code(MssContextHolder.getHospCode());
				if (master_profile != "" && master_profile != null)
					phrAccountModel.setMaster_profile_id(Long.valueOf(master_profile));
				phrAccountModel.setHosp_name(MssContextHolder.getHospitalName());
				phrAccountModel.setBaby_udid(sysId);
				if (StringUtils.isEmpty(patientCodeRebooking)) {
					phrAccountModel.setPatient_code(kcckReservationModel.getPatient_code());
				} else {
					phrAccountModel.setPatient_code(patientCodeRebooking);
				}
				phrApiService.bookingInsertDataAccountclinic(phrAccountModel, userToken);
			}
			// send mail
			MailInfo mailInfo = createMailInfoCompleteBooking(reservationModel, kcckReservationModel);
			List<String> toList = new ArrayList<>();
			toList.add(reservationModel.getEmail());
			String QuicklinkMovieTalk = MssContextHolder.getDomainName() + this.getText("be030.link.movietalk") + "&tokenHospCode=" +MssContextHolder.getTokenHospCode();
			String linkSurvey = kcckReservationModel.getMis_survey_link();
			if (bookingMode.toString().equals("3") || bookingMode.toString().equals("4")) {
				dataSend.put("isBookingOnline", "true");
				if (StringUtils.isEmpty(linkSurvey)) {
					mailInfo.setQuicklinkMovieTalk(QuicklinkMovieTalk);
					mailService.sendMail(MailCode.BOOKING_NEW_ONLINE_COMPLETED_1.toString(), this.getLanguage(),
							mailInfo, toList, reservationModel.getPatientId(),
							reservationModel.getReservationId(), MssContextHolder.getHospitalId(),
							MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());
				} else {
					mailInfo.setQuicklinkMovieTalk(QuicklinkMovieTalk);
					mailInfo.setLinksurvey(linkSurvey);
					dataSend.put("linkSurvey", linkSurvey);
					mailService.sendMail(MailCode.BOOKING_NEW_ONLINE_COMPLETED.toString(), this.getLanguage(),
							mailInfo, toList, reservationModel.getPatientId(),
							reservationModel.getReservationId(), MssContextHolder.getHospitalId(),
							MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());
				}
	
			} else {
	
				mailService.sendMail(MailCode.BOOKING_NEW_COMPLETED.toString(), this.getLanguage(), mailInfo,
						toList, reservationModel.getPatientId(), reservationModel.getReservationId(),
						MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
						MssContextHolder.getDomainName());
			}
			dataSend.put("reservationCode",  kcckReservationModel.getReservation_code());
			if (!StringUtils.isEmpty(patientCodeRebooking)) {
				dataSend.put("patientCode", patientCodeRebooking);
			} else {
				dataSend.put("patientCode", kcckReservationModel.getPatient_code());
			}
		}
		else
		{
			dataSend.put("isNotSuccess", "true");
		}
		dataSend.put("hospitalName", reservationModel.getHospitalName());
		dataSend.put("deptName", StringUtils.isNotEmpty(kcckReservationModel.getDepartment_name())?kcckReservationModel.getDepartment_name():"");
		if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
			dataSend.put("bookingTime", reservationModel.getFormattedReservationTime() + " "
					+ reservationModel.getFormattedReservationDate());
		} else {
			dataSend.put("bookingTime", reservationModel.getFormattedReservationDate() + " "
					+ reservationModel.getFormattedReservationTime());
		}
		ReminderTime time = ReminderTime.newInstance(reservationModel.getReminderTime());
		dataSend.put("reminderTime", time.toKey().toString());
		dataSend.put("token", tokenId);
		LOG.info("[End] Booking complete");

		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();
		responseBuilder.data(dataSend);
		responseBuilder.status(HttpStatus.OK);
		return responseBuilder.build();
	}
	
	@RequestMapping(value = "/cancel-authorization-transaction", method = {RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse cancelAuthorizationTransaction(@RequestBody Map<String,String> response) throws Exception {
		LOG.info("[Start] Cancel Authorization Transaction");
		String bookingMode = response.get("bookingMode");
		String tokenId = response.get("token");
		
		Map<String,String> dataSend = new HashMap<>();
		ReservationModel reservationModel = MssContextHolder.getReservationModel();
		
		/*
		 * Condition to process void for the authorization transaction:
		 * 1) Booking movie-talk
		 * 2) Booking fail
		 * 
		 * */
		dataSend.put("isSuccess", "false");
		if (bookingMode.toString().equals("3") || bookingMode.toString().equals("4")) {
			KcckGmoShopInfoModel authorizationInfo = null;
			
			// Booking Movie Talk --> VOID
			authorizationInfo = kcckApiServiceBooking.getGmoShopInfo(MssContextHolder.getHospCode());
			
			if(authorizationInfo != null && StringUtils.isNotEmpty(authorizationInfo.getShop_id()) && StringUtils.isNotEmpty(authorizationInfo.getShop_password()) && "Y".equalsIgnoreCase(authorizationInfo.getUse_auth()) && authorizationInfo.getAuth_amt() > 0) {
				String JobCd   = "VOID";
				List<TransactionInfo> transactionInfos = transactionRepositoryCustom.getTransactionInfo(reservationModel.getSessionId());
				
				if(transactionInfos != null && transactionInfos.size() > 0 && transactionInfos.get(0).getStatus().intValue() == PaymentStatus.AUTHORIZATION.toInt()) {
					boolean loopCondition = true;
					int loopCounter = 1;
					boolean voidStatusSuccess = false;
					while (loopCondition && loopCounter <= 3) {
						GmoPaymentHttp.Message message = gmoTransactionService.cancelAuth(MssConfiguration.getInstance().getGmoPayVersion(), authorizationInfo.getShop_id(), authorizationInfo.getShop_password(), transactionInfos.get(0).getAccessId(), transactionInfos.get(0).getAccessPass(), JobCd);
						LOG.info("[GMO] cancel authorization: " + message.content);
						if(message != null && "success".equalsIgnoreCase(message.status) && message.content.indexOf("ErrCode") < 0) {
							loopCondition = true;
							voidStatusSuccess = true;
							break;
						}
						
						loopCounter = loopCounter + 1;
					}
					
					// Update transaction status = 2(Cancelationed)
					if(voidStatusSuccess) {
						transactionService.updateTransaction(transactionInfos.get(0).getId(), new BigDecimal(PaymentStatus.FAILED.toInt()));
						
						dataSend.put("isSuccess", "true");
						dataSend.put("orderId", transactionInfos.get(0).getOrderId());
						dataSend.put("executeDateTime", MssDateTimeUtil.dateToString(transactionInfos.get(0).getExecuteDateTime(), DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM_EXTEND));
					}
				}
			}
		}
		
		dataSend.put("token", tokenId);
		LOG.info("[End] Booking complete");

		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();
		responseBuilder.data(dataSend);
		responseBuilder.status(HttpStatus.OK);
		return responseBuilder.build();
	}
	
	/**
	 * View booking change info.
	 * 
	 * @param model
	 *            the model
	 * @param tokenId
	 *            the token id
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@NavigationConfig(group = { NavigationGroup.EDIT_BOOKING })
	@RequestMapping(value = "/booking-change-info", method = RequestMethod.GET)
	public ModelAndView viewBookingChangeInfo(ModelMap model,
			@RequestParam(value = "resId", required = false) String resId,
			@RequestParam(value = "token", required = false) String tokenId,
			@RequestParam(value = "tokenHospCode", required = false) String tokenHospCode) throws Exception {
		LOG.info("[Start] booking change info. ");
		if (!StringUtils.isEmpty(tokenHospCode)) {
			if (StringUtils.isEmpty(MssContextHolder.getTokenHospCode())
					|| (!StringUtils.isEmpty(MssContextHolder.getTokenHospCode())
							&& !tokenHospCode.equals(MssContextHolder.getTokenHospCode()))) {
				String hospCode = EncryptionUtils.decrypt(tokenHospCode, MssConfiguration.getInstance().getSecretKey(),
						EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
				if (StringUtils.isEmpty(hospCode)) {
					return new ModelAndView("front.page.not.found");
				}
				HospitalDto hospital = this.hospitalService.getHospitalModelByHospitalCode(hospCode);
				if (hospital == null) {
					return new ModelAndView("front.access.denied");
				}
				MssContextHolder.setHospitalId(hospital.getHospitalId());
				MssContextHolder.setHospitalName(hospital.getHospitalName());
				MssContextHolder.setHospitalIconPath(hospital.getHospitalIconPath());
				MssContextHolder.setTokenHospCode(tokenHospCode);
				MssContextHolder.setHospCode(hospCode);
				MssContextHolder.setUserLanguage(hospital.getLocale());
				MssContextHolder.setHospitalLocale(hospital.getLocale());
				MssContextHolder.setHospitalEmail(hospital.getEmail());
				MssContextHolder.setHospitalParentId(hospital.getHospitalParentId());

				MssContextHolder.setDomainName(DomainNameUtils.getDomainName(hospital.getLocale()));
			}
		} else {
			if (StringUtils.isEmpty(MssContextHolder.getHospCode())) {
				return new ModelAndView("front.access.denied");
			}
		}
		ModelAndView modelAndView = new ModelAndView("front.booking.change.info");
		ReservationModel reservation = null;
		if (tokenId != null && !StringUtils.isBlank(tokenId)) {
			TokenValidationResult tokenResult = TokenUtils.validateToken(tokenId);
			if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
				SessionModel session = this.bookingService.getSessionById(tokenId);
				tokenResult = TokenUtils.validateToken(session);
			}
			if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
				if ((MssContextHolder.isKcck())) {
					reservation = bookingService.findKcckReservationBySessionId(tokenId);
				} else {
					reservation = bookingService.findReservationBySessionId(tokenId);
				}
			}
		} else if (!StringUtils.isBlank(resId) && NumberUtils.isDigits(resId)) {
			reservation = bookingService.findReservationById(Integer.valueOf(resId));
		}

		// check reservation session
		if (reservation == null) {
			LOG.warn("[WARN] booking change info. reservationModel is null");
			return new ModelAndView(new RedirectView("expire"));
		} else {
			// Check if reservationStatus = 5 no for BOOKING_COMPLETED
			Integer reservationStatus = ReservationStatus.CANCELLED.toInt();
			if (reservationStatus.equals(reservation.getReservationStatus())) {
				model.addAttribute("isNotAvailable", true);
				return modelAndView;
			}
			// Check time booking
			String reservationDate = reservation.getReservationDate();
			String reservationTime = reservation.getReservationTime();
			LocalDateTime selectedDateTime = LocalDateTime.parse(reservationDate + reservationTime,
					DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
			ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
			OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
			OffsetDateTime now = Instant.now().atOffset(zoneOffset);
			if (checkTime.isBefore(now)) {
				model.addAttribute("isNotAvailable", true);
				return modelAndView;
			}

			// update reading flag of mail if not booking vaccine
			MailTemplateModel mailModel = this.bookingService.getMailTemplateByCode(MailCode.BOOKING_CHANGE.toString(),
					this.getLanguage(), MssContextHolder.getHospitalId());
			if (mailModel != null && StringUtils.isBlank(resId)) {
				this.bookingService.updateReadingFlag(tokenId, mailModel.getMailTemplateId());
			}
			Map<Integer, String> mapReminderTime = new HashMap<>();
			ReminderTime time = ReminderTime.newInstance(reservation.getReminderTime());
			mapReminderTime.put(time.toKey(), time.toText());
			reservation.setMapReminderTime(mapReminderTime);

			PatientModel patient = this.bookingService.findPatientById(reservation.getPatientId());
			if (patient.getGender() != null) {
				if (patient.getGender().equals("M"))
					patient.setGenderText(this.getText("general.label.male"));
				else
					patient.setGenderText(this.getText("general.label.female"));
			}
			patient.setDob(
					MssDateTimeUtil.dateToString(patient.getBirthDay(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
			model.addAttribute("reservation", reservation);
			model.addAttribute("patient", patient);

			BookingInfo bookingInfo = new BookingInfo();
			DepartmentModel departmentModel;
			// check Kcck - Mss
			if ((MssContextHolder.isKcck())) {
				departmentModel = this.kcckDepartmentService.findKcckDepartmentById(MssContextHolder.getHospCode(),
						MssContextHolder.getLocale().toString(), reservation.getDeptId());
			} else {
				departmentModel = this.departmentService.findDepartmentById(reservation.getDeptId());
			}
			// If booking vaccine
			if (DepartmentType.VACCINE.toInt().equals(departmentModel.getDeptType())) {
				VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService
						.findByReservationId(reservation.getReservationId());
				if (vaccineChildHistoryModel != null) {
					VaccineModel vaccineModel = this.vaccineService.findById(vaccineChildHistoryModel.getVaccineId());
					UserChildModel userChildModel = this.userChildService
							.findById(vaccineChildHistoryModel.getChildId());
					// set data booking vaccine to session
					createBookingInfoVaccine(bookingInfo, departmentModel, vaccineChildHistoryModel, vaccineModel,
							userChildModel);

					model.addAttribute("vaccineModel", vaccineModel);
					model.addAttribute("userChildModel", userChildModel);
					model.addAttribute("injectedNo", vaccineChildHistoryModel.getInjectedNo());
					model.addAttribute("bookingVaccine", true);
				}
			}

			// set data to session
			if (MssContextHolder.getHospitalParentId() != 1) {
				MssContextHolder.setHospitalId(reservation.getHospitalId());
				MssContextHolder.setHospitalName(reservation.getHospitalName());
			}
			// BookingInfo bookingInfo = createBookingInfo(reservation);
			createBookingInfo(bookingInfo, reservation);
			MssContextHolder.setBookingInfo(bookingInfo);
			LOG.info("[End] booking change info. ");
			return modelAndView;
		}
	}

	private void createBookingInfoVaccine(BookingInfo bookingInfo, DepartmentModel departmentModel,
			VaccineChildHistoryModel vaccineChildHistoryModel, VaccineModel vaccineModel,
			UserChildModel userChildModel) {
		bookingInfo.setVaccineId(vaccineModel.getVaccineId());
		bookingInfo.setVaccineName(vaccineModel.getVaccineName());
		bookingInfo.setChildId(userChildModel.getChildId());
		bookingInfo.setChildName(userChildModel.getChildName());
		bookingInfo.setDob(userChildModel.getDob());
		bookingInfo.setDeptType(departmentModel.getDeptType());
		bookingInfo.setSex(userChildModel.getSex());
		bookingInfo.setTimesUsing(String.valueOf(vaccineChildHistoryModel.getInjectedNo()));
		bookingInfo.setDeptType(DepartmentType.VACCINE.toInt());
	}

	private void createBookingInfo(BookingInfo bookingInfo, ReservationModel reservation) {
		// BookingInfo bookingInfo = new BookingInfo();
		bookingInfo.setReservationId(reservation.getReservationId());
		bookingInfo.setPatientId(reservation.getPatientId());
		bookingInfo.setPatientName(reservation.getPatientName());
		bookingInfo.setPatientFurigana(reservation.getNameFurigana());
		bookingInfo.setPhoneNumber(reservation.getPhoneNumber());
		bookingInfo.setEmail(reservation.getEmail());
		bookingInfo.setCardNumber(reservation.getCardNumber());
		bookingInfo.setReservationCode(reservation.getReservationCode());
		bookingInfo.setDeptId(reservation.getDeptId());
		bookingInfo.setDeptName(reservation.getDeptName());
		bookingInfo.setDoctorId(reservation.getDoctorId());
		bookingInfo.setDoctorName(reservation.getDoctorName());
		bookingInfo.setReservationDate(reservation.getReservationDate());
		bookingInfo.setReservationTime(reservation.getReservationTime());
		bookingInfo.setReminderTime(reservation.getReminderTime());

		// return bookingInfo;
	}

	/**
	 * View booking change.
	 * 
	 * @param reservation
	 *            the reservation
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.EDIT_BOOKING,
			NavigationGroup.CHANGE_CHOOSE_TIME }, stepType = NavigationType.CHANGE_STEPS)
	@RequestMapping(value = "/booking-change", method = RequestMethod.GET)
	@SessionValidate
	public ModelAndView viewBookingChange(ModelMap model) {
		LOG.info("[Start] Booking change");
		ReservationModel reservation = new ReservationModel();
		reservation.setHospitalName(MssContextHolder.getHospitalName());
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		reservation.setDeptName(bookingInfo.getDeptName());
		reservation.setDoctorName(bookingInfo.getDoctorName());
		reservation.setReservationDate(bookingInfo.getFormattedReservationDate());
		reservation.setReservationTime(bookingInfo.getFormattedReservationTime());
		model.addAttribute("reservation", reservation);
		LOG.info("[End] Booking change");
		return new ModelAndView("front.booking.change");
	}

	/**
	 * Ajax get booking change.
	 * 
	 * @param bookingTime
	 *            the booking time
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-get-booking-change", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxGetBookingChange(@RequestBody BookingTimeModel bookingTime) throws Exception {
		LOG.info("[Start] ajax get booking change ");
		Integer doctorId = MssContextHolder.getBookingInfo().getDoctorId();
		LOG.debug("ajax get booking change. doctorId=" + doctorId);
		String startDate = bookingTime.getStartDate();
		String endDate = bookingTime.getEndDate();
		TimeslotScheduleModel schedule;
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (MssContextHolder.isKcck()) {
			// KCCK - MBS
			DepartmentModel departmentModel = kcckDepartmentService.findKcckDepartmentById(
					MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(),
					MssContextHolder.getBookingInfo().getDeptId());
			DoctorModel doctor = kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(), doctorId,
					departmentModel.getDeptCode());
			schedule = this.kcckScheduleService.checkKcckDepartmentSchedule(MssContextHolder.getHospCode(),
					MssConfiguration.getInstance().getApiKcckDepartmentScheduleTime(), startDate, endDate,
					departmentModel.getDeptCode(), doctor.getDoctorCode(), null);
		} else {

			schedule = this.scheduleService.getDoctorTimeslotSchedule(MssContextHolder.getBookingInfo().getDeptId(),
					doctorId, bookingTime.getStartDate(), bookingTime.getEndDate());
		}
		if (schedule == null || schedule.getTimeslots().isEmpty()) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).data(schedule);
		} else {
			builder.status(HttpStatus.OK).data(schedule);
		}
		LOG.info("[End] ajax get booking change ");
		return builder.build();
	}

	/**
	 * Ajax submit booking time.
	 * 
	 * @param bookingTime
	 *            the booking time
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-submit-booking-change", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxSubmitBookingTime(@RequestBody BookingTimeModel bookingTime) throws Exception {
		LOG.info("[Start] ajax submit booking change");
		String selectedDate = bookingTime.getSelectedDate();
		String selectedTime = bookingTime.getSelectedTime();
		LocalDateTime selectedDateTime = LocalDateTime.parse(selectedDate + selectedTime,
				DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
		LOG.debug("Ajax submit booking change. selectedDate=" + selectedDate + " ;selectedTime=" + selectedTime
				+ " ;selectedDateTime=" + selectedDateTime);

		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);
		DoctorModel doctor;
		String validateBookingVaccine = "";
		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();

		if (checkTime.isAfter(now)) {

			MssContextHolder.getBookingInfo().setReservationDate(selectedDate);
			MssContextHolder.getBookingInfo().setReservationTime(selectedTime);

			// Check if booking vaccine
			BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
			// DepartmentModel departmentModel =
			// this.departmentService.findDepartmentById(bookingInfo.getDeptId());
			if (DepartmentType.VACCINE.toInt().equals(bookingInfo.getDeptType())) {
				VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService
						.findByReservationId(bookingInfo.getReservationId());
				if (vaccineChildHistoryModel == null) {
					return responseBuilder.build();
				}
				ZonedDateTime zdt = selectedDateTime.atZone(ZoneId.systemDefault());
				Date datetime = Date.from(zdt.toInstant());
				String resultValidate = validateBookingVaccine(vaccineChildHistoryModel.getVaccineId(),
						vaccineChildHistoryModel.getChildId(), datetime);
				if (!StringUtils.isEmpty(resultValidate)) {
					responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText(resultValidate));
					return responseBuilder.build();
				}
			}
		} else {
			responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR)
					.message(this.getText("general.msg.cannot_select_past_time"));
			return responseBuilder.build();
		}

		responseBuilder.status(HttpStatus.OK).data("booking-change-confirm");
		// }
		LOG.info("[End] ajax submit booking change");
		return responseBuilder.build();
	}

	/**
	 * Cancel booking change.
	 * 
	 * @return the model and view
	 */
	@RequestMapping(value = "/booking-cancel", method = RequestMethod.POST)
	@SessionValidate
	public ModelAndView cancelBookingChange() throws Exception {
		LOG.info("[Start] booking cancel");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		ReservationModel reservation;
		KcckReservationModel kcckModel = new KcckReservationModel();
		if ((MssContextHolder.isKcck())) {
			reservation = bookingService.findKcckReservationById(bookingInfo.getReservationId());
			kcckModel.setReservation_code(reservation.getReservationCode());
			kcckModel.setPatient_code(reservation.getCardNumber());
			kcckModel.setHosp_code(MssContextHolder.getHospCode());
			kcckModel.setLocale(MssContextHolder.getLocale().toString());
			KcckReservationModel kcckReservationModel = kcckBookingService.cancelReservation(kcckModel);
			LOG.debug("[FE] Booking cancel. " + kcckReservationModel.toString());
		} else {
			reservation = bookingService.findReservationById(bookingInfo.getReservationId());
		}

		LOG.debug("Booking cancel. " + reservation.toString());
		reservation.setReservationStatus(ReservationStatus.CANCELLED.toInt());
		// update Reservation Status
		bookingService.updateReservation(reservation);
		this.addNotification(new NotificationModel(NotificationType.SUCCESS, this.getText("fe001.msg.cancel.success")));
		// send Mail
		MailInfo mailInfo = new MailInfo();
		mailInfo.setPatientName(reservation.getPatientName());
		mailInfo.setPatientCode(reservation.getReservationCode());
		mailInfo.setHospitalName(MssContextHolder.getHospitalName());
		mailInfo.setReservationCode(reservation.getReservationCode());
		mailInfo.setDepartmentName(reservation.getDeptName());
		mailInfo.setDoctorName(reservation.getDoctorName());
		if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
			mailInfo.setReservationDatetime(
					bookingInfo.getFormattedReservationTime() + " " + bookingInfo.getFormattedReservationDate());
		} else {
			mailInfo.setReservationDatetime(
					bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
		}
		if (reservation.getEmail() != null && !"".equals(reservation.getEmail())) {
			List<String> toList = new ArrayList<>();
			toList.add(reservation.getEmail());
			mailService.sendMail(MailCode.CANCEL_RESERVATION.toString(), this.getLanguage(), mailInfo, toList,
					reservation.getPatientId(), reservation.getReservationId(), MssContextHolder.getHospitalId(),
					MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());
		}
		// Cancelled if booing vaccine
		VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService
				.findByReservationId(bookingInfo.getReservationId());
		if (vaccineChildHistoryModel != null) {
			vaccineChildHistoryModel.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			this.vaccineChildHistoryService.save(vaccineChildHistoryModel);
			return new ModelAndView(new RedirectView("index"));
		}
		LOG.info("[End] booking cancel");
		return new ModelAndView(new RedirectView("booking-new"));
	}

	/**
	 * Confirm booking change.
	 * 
	 * @param reservation
	 *            the reservation
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.EDIT_BOOKING,
			NavigationGroup.CHANGE_CONFIRM }, stepType = NavigationType.CHANGE_STEPS)
	@RequestMapping(value = "/booking-change-confirm", method = RequestMethod.GET)
	@SessionValidate
	public ModelAndView confirmBookingChange(ReservationModel reservation, ModelMap model) {
		LOG.info("[Start] booking change confirm");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		createReservation(reservation, bookingInfo);
		PatientModel patient = this.bookingService.findPatientById(bookingInfo.getPatientId());
		if (patient.getGender() != null) {
			if (patient.getGender().equals("M") || patient.getGender().equals("1"))
				patient.setGenderText(this.getText("general.label.male"));
			else
				patient.setGenderText(this.getText("general.label.female"));
		}
		patient.setDob(MssDateTimeUtil.dateToString(patient.getBirthDay(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		Map<Integer, String> mapReminderTime = new HashMap<>();
		ReminderTime time = ReminderTime.newInstance(bookingInfo.getReminderTime());
		mapReminderTime.put(time.toKey(), time.toText());
		reservation.setMapReminderTime(mapReminderTime);
		LOG.debug("Booking change confirm. " + reservation.toString());

		// If booking vaccine
		if (bookingInfo.getDeptType() != null && DepartmentType.VACCINE.toInt().equals(bookingInfo.getDeptType())) {
			model.addAttribute("childName", bookingInfo.getChildName());
			model.addAttribute("dob", bookingInfo.getDob());
			model.addAttribute("sex", bookingInfo.getSex());
			model.addAttribute("vaccineName", bookingInfo.getVaccineName());
			model.addAttribute("injectedNo", bookingInfo.getTimesUsing());
			model.addAttribute("bookingVaccine", true);
		}
		model.addAttribute("reservation", reservation);
		model.addAttribute("patient", patient);
		LOG.info("[End] booking change confirm");
		return new ModelAndView("front.booking.change.confirm");
	}

	private void createReservation(ReservationModel reservation, BookingInfo bookingInfo) {
		reservation.setPatientName(bookingInfo.getPatientName());
		reservation.setNameFurigana(bookingInfo.getPatientFurigana());
		reservation.setPhoneNumber(bookingInfo.getPhoneNumber());
		reservation.setEmail(bookingInfo.getEmail());
		reservation.setCardNumber(bookingInfo.getCardNumber());
		reservation.setDeptName(bookingInfo.getDeptName());
		reservation.setDoctorName(bookingInfo.getDoctorName());
		reservation.setReservationDate(bookingInfo.getReservationDate());
		reservation.setReservationTime(bookingInfo.getReservationTime());
		reservation.setReminderTime(bookingInfo.getReminderTime());
	}

	/**
	 * Accept booking change.
	 * 
	 * @param reservation
	 *            the reservation
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@NavigationConfig(group = { NavigationGroup.EDIT_BOOKING,
			NavigationGroup.CHANGE_ACCEPT }, stepType = NavigationType.CHANGE_STEPS)
	@RequestMapping(value = "/booking-change-accept", method = RequestMethod.GET)
	@SessionValidate
	public ModelAndView acceptBookingChange(ReservationModel reservation, ModelMap model) throws Exception {
		LOG.info("[Start] booking change accept");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if ((MssContextHolder.isKcck())) {
			reservation = bookingService.findKcckReservationById(bookingInfo.getReservationId());
		} else {
			reservation = bookingService.findReservationById(bookingInfo.getReservationId());
		}
		reservation.setReservationDate(bookingInfo.getReservationDate());
		reservation.setReservationTime(bookingInfo.getReservationTime());
		MssContextHolder.getBookingInfo().setFormattedReservationTime(StringUtils.EMPTY);
		reservation.setReservationStatus(ReservationStatus.BOOKING_ACCEPTED.toInt());

		// update booking time
		LOG.debug("Booking change accept. updateReservation: " + reservation.toString());
		bookingService.updateReservation(reservation);
		// set session
		String sessionId = TokenUtils.generateToken();
		bookingService.saveSession(sessionId);
		bookingService.saveTokenIntoReservation(reservation.getReservationId(), sessionId);

		// send mail when accept temporary
		MailInfo mailInfo = new MailInfo();
		mailInfo.setPatientName(bookingInfo.getPatientName());
		mailInfo.setDepartmentName(bookingInfo.getDeptName());
		if (MssConfiguration.getInstance().getApiKcckVaccineCode().equals(reservation.getDepartmentCode())) {
			UserModel userMode = this.userService.getActiveUserByEmail(reservation.getEmail(),
					MssContextHolder.getHospitalId());
			mailInfo.setPatientName(userMode.getName());
		}
		if (bookingInfo.getCardNumber() != null) {
			mailInfo.setPatientCode(bookingInfo.getCardNumber());
		} else {
			mailInfo.setPatientCode("");
		}
		mailInfo.setHospitalName(MssContextHolder.getHospitalName());
		mailInfo.setReservationCode(bookingInfo.getReservationCode());
		if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
			mailInfo.setReservationDatetime(
					bookingInfo.getFormattedReservationTime() + " " + bookingInfo.getFormattedReservationDate());
		} else {
			mailInfo.setReservationDatetime(
					bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
		}
		mailInfo.setSessionId(sessionId);
		List<Object> args = new ArrayList<Object>();
		args.add(MssContextHolder.getTokenHospCode());

		mailInfo.setLinkBookingChangeComplete(MssContextHolder.getDomainName()
				+ this.getText("be030.link.booking.change.complete", args) + mailInfo.getSessionId());
		mailInfo.setLinkAuthorizedEmail(
				MssContextHolder.getDomainName() + this.getText("be030.link.search.reservation"));
		List<String> toList = new ArrayList<>();
		toList.add(reservation.getEmail());
		mailService.sendMail(MailCode.BOOKING_CHANGE_ACCEPTED.toString(), this.getLanguage(), mailInfo, toList,
				reservation.getPatientId(), reservation.getReservationId(), MssContextHolder.getHospitalId(),
				MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());

		model.addAttribute("reservation", reservation);
		ReminderTime time = ReminderTime.newInstance(reservation.getReminderTime());
		model.addAttribute("reminderTime", time.toText());

		LOG.info("[End] booking change accept");
		return new ModelAndView("front.booking.change.accept");
	}

	/**
	 * Complete booking change.
	 * 
	 * @param model
	 *            the model
	 * @param tokenId
	 *            the token id
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@NavigationConfig(group = { NavigationGroup.EDIT_BOOKING,
			NavigationGroup.CHANGE_COMPLETE }, stepType = NavigationType.CHANGE_STEPS)
	@RequestMapping(value = "/booking-change-complete", method = RequestMethod.GET)
	public ModelAndView completeBookingChange(
			@RequestParam(value = "tokenHospCode", required = false) String tokenHospCode, ModelMap model,
			@RequestParam(value = "token") String tokenId) throws Exception {
		LOG.info("[Start] booking change complete");
		if (!StringUtils.isEmpty(tokenHospCode)) {
			if (StringUtils.isEmpty(MssContextHolder.getTokenHospCode())
					|| (!StringUtils.isEmpty(MssContextHolder.getTokenHospCode())
							&& !tokenHospCode.equals(MssContextHolder.getTokenHospCode()))) {
				String hospCode = EncryptionUtils.decrypt(tokenHospCode, MssConfiguration.getInstance().getSecretKey(),
						EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
				if (StringUtils.isEmpty(hospCode)) {
					return new ModelAndView("front.page.not.found");
				}
				HospitalDto hospital = this.hospitalService.getHospitalModelByHospitalCode(hospCode);
				if (hospital == null) {
					return new ModelAndView("front.access.denied");
				}
				MssContextHolder.setHospitalId(hospital.getHospitalId());
				MssContextHolder.setHospitalName(hospital.getHospitalName());
				MssContextHolder.setHospitalIconPath(hospital.getHospitalIconPath());
				MssContextHolder.setTokenHospCode(tokenHospCode);
				MssContextHolder.setHospCode(hospCode);
				MssContextHolder.setUserLanguage(hospital.getLocale());
				MssContextHolder.setHospitalLocale(hospital.getLocale());
				MssContextHolder.setHospitalEmail(hospital.getEmail());
				MssContextHolder.setHospitalParentId(hospital.getHospitalParentId());

				MssContextHolder.setDomainName(DomainNameUtils.getDomainName(hospital.getLocale()));
			}
		} else {
			if (StringUtils.isEmpty(MssContextHolder.getHospCode())) {
				return new ModelAndView("front.access.denied");
			}
		}

		ModelAndView modelAndView = new ModelAndView("front.booking.change.complete");
		TokenValidationResult tokenResult = TokenUtils.validateToken(tokenId);

		if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {

			SessionModel session = this.bookingService.getSessionById(tokenId);
			tokenResult = TokenUtils.validateToken(session);
		}

		if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
			ReservationModel reservation;
			if ((MssContextHolder.isKcck())) {
				reservation = bookingService.findKcckReservationBySessionId(tokenId);
			} else {
				reservation = bookingService.findReservationBySessionId(tokenId);
			}

			// check reservation session
			if (reservation == null) {
				return new ModelAndView(new RedirectView("expire"));
			}
			// if (MssContextHolder.getHospitalParentId() != 1) {}

			// update reading flag of mail
			MailTemplateModel mailModel = this.bookingService.getMailTemplateByCode("BOOKING_CHANGE_ACCEPTED",
					this.getLanguage(), MssContextHolder.getHospitalId());
			if (mailModel != null) {
				this.bookingService.updateReadingFlag(tokenId, mailModel.getMailTemplateId());
			}

			// update vaccine_child_history if booking
			BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
			if (bookingInfo != null && bookingInfo.getDeptType() != null
					&& DepartmentType.VACCINE.toInt().equals(bookingInfo.getDeptType())) {
				VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService
						.findByVaccineIdChildIdReservationId(reservation.getReservationId(), bookingInfo.getVaccineId(),
								bookingInfo.getChildId());
				if (vaccineChildHistoryModel != null) {
					Timestamp injectedDate = MssDateTimeUtil.convertStringToTimestamp(
							reservation.getReservationDate() + reservation.getReservationTime(),
							DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM);
					vaccineChildHistoryModel.setInjectedDate(injectedDate);
					this.vaccineChildHistoryService.save(vaccineChildHistoryModel);
				}

			}
			if ((MssContextHolder.isKcck())) {
				KcckReservationModel kcckModel = new KcckReservationModel();
				DepartmentModel departmentModel = kcckDepartmentService.findKcckDepartmentById(
						MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(),
						reservation.getDeptId());
				DoctorModel doctorModel = kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(),
						reservation.getDoctorId(), departmentModel.getDeptCode());
				String reservationDate = MssDateTimeUtil.convertBetweenDateFormat(reservation.getReservationDate(),
						DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
				if (doctorModel != null) {
					kcckModel.setDoctor_code(doctorModel.getDoctorCode());
				}
				kcckModel.setDoctor_code(doctorModel.getDoctorCode());
				kcckModel.setReservation_code(reservation.getReservationCode());
				kcckModel.setPatient_code(reservation.getCardNumber());
				kcckModel.setHosp_code(MssContextHolder.getHospCode());
				kcckModel.setDepartment_code(departmentModel.getDeptCode());
				kcckModel.setReservation_date(reservationDate);
				kcckModel.setReservation_time(reservation.getReservationTime());
				kcckModel.setLocale(MssContextHolder.getLocale().toString());
				LOG.debug("[FE]Send Change Reservation to KCCK " + kcckModel.toString());
				KcckReservationModel kcckReservationModel = kcckBookingService.changeReservation(kcckModel);
				LOG.debug("[FE]Reservation Info from KCCK " + kcckReservationModel.toString());
				if (kcckReservationModel != null && kcckReservationModel.getReservation_code() != null) {
					if (ReservationStatus.BOOKING_COMPLETED.toInt().equals(reservation.getReservationStatus())) {
						modelAndView.addObject("isAlreadyCompleted", true);
						return modelAndView;
					}
					// Update Reservation
					reservation.setReservationStatus(ReservationStatus.BOOKING_COMPLETED.toInt());
					LOG.debug("Booking change complete. updateReservation: " + reservation.toString());
					reservation.setDepartmentCode(departmentModel.getDeptCode());
					bookingService.updateReservation(reservation);
					// sendmail
					MailInfo mailInfo = new MailInfo();
					mailInfo.setPatientName(reservation.getPatientName());
					if (MssConfiguration.getInstance().getApiKcckVaccineCode()
							.equals(reservation.getDepartmentCode())) {
						UserModel userMode = this.userService.getActiveUserByEmail(reservation.getEmail(),
								MssContextHolder.getHospitalId());
						mailInfo.setPatientName(userMode.getName());
					}
					mailInfo.setHospitalName(MssContextHolder.getHospitalName());
					mailInfo.setReservationCode(reservation.getReservationCode());
					mailInfo.setPatientCode(kcckReservationModel.getPatient_code());
					mailInfo.setDepartmentName(reservation.getDeptName());
					mailInfo.setDoctorName(reservation.getDoctorName());
					if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
						mailInfo.setReservationDatetime(reservation.getFormattedReservationTime() + " "
								+ reservation.getFormattedReservationDate());
					} else {
						mailInfo.setReservationDatetime(reservation.getFormattedReservationDate() + " "
								+ reservation.getFormattedReservationTime());
					}
					mailInfo.setReminderTime(getText(ReminderTime.newInstance(reservation.getReminderTime()).toText()));
					List<String> toList = new ArrayList<>();
					toList.add(reservation.getEmail());
					mailInfo.setLinkAuthorizedEmail(
							MssContextHolder.getDomainName() + this.getText("be030.link.search.reservation"));
					mailService.sendMail(MailCode.BOOKING_CHANGE_COMPLETED.toString(), this.getLanguage(), mailInfo,
							toList, reservation.getPatientId(), reservation.getReservationId(),
							MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
							MssContextHolder.getDomainName());
				} else {
					modelAndView.addObject("isNotSuccess", true);
					return modelAndView;
				}
			} else {

				// check the status of reservation that is already completed or
				// not
				if (ReservationStatus.BOOKING_COMPLETED.toInt().equals(reservation.getReservationStatus())) {
					modelAndView.addObject("isAlreadyCompleted", true);
					return modelAndView;
				}
				// check the doctor schedule before change reservation status
				if (this.doctorScheduleService.isDoctorScheduleFull(reservation.getDoctorId(),
						reservation.getReservationDate(), reservation.getReservationTime())) {
					modelAndView.addObject("isDoctorScheduleFull", true);
					return modelAndView;
				}
				// Send mail
				PatientModel patient = bookingService.findPatientById(reservation.getPatientId());
				MailInfo mailInfo = new MailInfo();
				if (patient.getCardNumber() == null) {
					mailInfo.setPatientCode("");
				} else {
					mailInfo.setPatientCode(patient.getCardNumber());
				}
				mailInfo.setPatientName(reservation.getPatientName());
				if (MssConfiguration.getInstance().getApiKcckVaccineCode().equals(reservation.getDepartmentCode())) {
					UserModel userMode = this.userService.getActiveUserByEmail(reservation.getEmail(),
							MssContextHolder.getHospitalId());
					mailInfo.setPatientName(userMode.getName());
				}
				mailInfo.setHospitalName(reservation.getHospitalName());
				mailInfo.setReservationCode(reservation.getReservationCode());
				mailInfo.setDepartmentName(reservation.getDeptName());
				mailInfo.setDoctorName(reservation.getDoctorName());
				if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
					mailInfo.setReservationDatetime(reservation.getFormattedReservationTime() + " "
							+ reservation.getFormattedReservationDate());
				} else {
					mailInfo.setReservationDatetime(reservation.getFormattedReservationDate() + " "
							+ reservation.getFormattedReservationTime());
				}

				mailInfo.setReminderTime(getText(ReminderTime.newInstance(reservation.getReminderTime()).toText()));
				List<String> toList = new ArrayList<>();
				toList.add(reservation.getEmail());
				mailInfo.setLinkAuthorizedEmail(
						MssContextHolder.getDomainName() + this.getText("be030.link.search.reservation"));
				mailService.sendMail(MailCode.BOOKING_CHANGE_COMPLETED.toString(), this.getLanguage(), mailInfo, toList,
						reservation.getPatientId(), reservation.getReservationId(), MssContextHolder.getHospitalId(),
						MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());

				// update Reservation Status
				reservation.setReservationStatus(ReservationStatus.BOOKING_COMPLETED.toInt());
				LOG.debug("Booking change complete. updateReservation: " + reservation.toString());
				bookingService.updateReservation(reservation);

			}
			model.addAttribute("reservation", reservation);
			ReminderTime time = ReminderTime.newInstance(reservation.getReminderTime());
			model.addAttribute("reminderTime", time.toText());
			LOG.info("[End] booking change complete");
			return modelAndView;
		} else {
			return new ModelAndView(new RedirectView("expire"));
		}
	}

	/**
	 * Booking expire.
	 * 
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@RequestMapping(value = "/expire", method = RequestMethod.GET)
	public ModelAndView bookingExpire(ModelMap model) {
		HospitalModel hospital = this.hospitalService.findHospitalById(MssContextHolder.getHospitalId());
		model.addAttribute("hospitalName", hospital.getHospitalName());
		MssContextHolder.currentSessionContext().removeBookingInfo();
		return new ModelAndView("front.booking.expire");
	}

	/**
	 * Gets the reminder time map.
	 * 
	 * @return the reminder time map
	 */
	private Map<Integer, String> getReminderTimeMap() {
		Map<Integer, String> map = new HashMap<>();
		for (ReminderTime item : ReminderTime.values()) {
			map.put(item.toKey(), getText(item.toText()));
		}
		return getRemiderTimeMapSort(map);
	}

	private Map<Integer, String> getRemiderTimeMapSort(Map<Integer, String> unsortMap) {
		Map<Integer, String> treeMap = new TreeMap<Integer, String>(new Comparator<Integer>() {

			@Override
			public int compare(Integer o1, Integer o2) {
				return o1.compareTo(o2);
			}

		});
		treeMap.putAll(unsortMap);
		return treeMap;

	}

	/**
	 * Ajax get timeslot list.
	 *
	 * @return the list
	 * @throws Exception
	 */
	@RequestMapping(value = "/ajax-get-timeslot-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetTimeslotList(@RequestBody BookingTimeModel bookingTime) throws Exception {
		LOG.info("[Start] ajax get timeslot list");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		Integer deptId = bookingInfo.getDeptId();
		Integer doctorId = bookingInfo.getDoctorId();
		LOG.debug("Ajax get timeslot list. deptId=" + deptId);
		List<String> timeslotList;
		String startDate = bookingTime.getStartDate();
		String endDate = bookingTime.getEndDate();
		if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			DepartmentModel departmentModel = kcckDepartmentService.findKcckDepartmentById(
					MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(), deptId);
			if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
					|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
				DoctorModel doctor = kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(),
						bookingTime.getDoctorId(), departmentModel.getDeptCode());
				if (doctor != null) {
					timeslotList = this.kcckScheduleService.listKcckDoctorTime(MssContextHolder.getHospCode(),
							departmentModel.getDeptCode(), doctor.getDoctorCode(), startDate, endDate);
				} else {
					timeslotList = new ArrayList<String>();
				}
			} else if (BookingMode.NEW_BOOKING.toInt().equals(MssContextHolder.getReservationMode())
					|| BookingMode.NEW_BOOKING_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
				timeslotList = this.kcckScheduleService.listKcckDepartmentTime(MssContextHolder.getHospCode(),
						MssConfiguration.getInstance().getApiKcckDepartmentScheduleTime(), startDate, endDate,
						departmentModel.getDeptCode(), null);
			} else {
				DoctorModel doctor = kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(), doctorId,
						departmentModel.getDeptCode());
				timeslotList = this.kcckScheduleService.listKcckDoctorTime(MssContextHolder.getHospCode(),
						departmentModel.getDeptCode(), doctor.getDoctorCode(), startDate, endDate);
			}
		} else {
			timeslotList = this.doctorScheduleService.getTimeslotListByDepartment(deptId);
		}
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(timeslotList);
		LOG.info("[End] ajax get timeslot list");
		return builder.build();
	}

	/**
	 * View calendar.
	 *
	 * @param deptId
	 *            the dept id
	 * @return the model and view
	 * @throws Exception
	 */
	@RequestMapping(value = "/calendar", method = RequestMethod.GET)
	public ModelAndView viewCalendar(@RequestParam(value = "hospitalCode", required = false) String hospitalCode,
			@RequestParam(value = "deptCode", required = false) String deptCode, HttpSession session) throws Exception {
		LOG.info("[Start] View calendar.");
		LOG.debug("View calendar. hospitalCode=" + hospitalCode + " ;deptCode=" + deptCode);
		ModelAndView modelAndView = new ModelAndView("front.calendar");
		if (hospitalCode != null && !StringUtils.isBlank(hospitalCode) && deptCode != null
				&& !StringUtils.isBlank(deptCode)) {
			DepartmentModel departmentModel = departmentService.findDepartmentByCode(hospitalCode, deptCode);
			if (departmentModel != null) {
				session.setAttribute("deptId", departmentModel.getDeptId());
				session.setAttribute("hospitalCode", hospitalCode);
				session.setAttribute("deptCode", deptCode);
			}
		}
		MssContextHolder.setReserveMode(BookingMode.NEW_BOOKING.toInt());
		modelAndView.addObject("serverAddress", MssContextHolder.getDomainName());
		LOG.info("[End] View calendar.");
		return modelAndView;
	}

	/**
	 * Ajax init month data calendar.
	 *
	 * @param calendarInfo
	 *            the calendar info
	 * @param session
	 *            the session
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-init-month-data-calendar", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxInitMonthDataCalendar(@RequestBody CalendarInfo calendarInfo, HttpSession session) {
		LOG.info("[Start] Ajax init month data calendar.");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Integer deptId = Integer.valueOf(session.getAttribute("deptId").toString());
		String startDate = MssDateTimeUtil.getDateFromMonthAndYear(calendarInfo.getMonth(), calendarInfo.getYear(),
				true);
		String endDate = MssDateTimeUtil.getDateFromMonthAndYear(calendarInfo.getMonth(), calendarInfo.getYear(),
				false);
		Map<String, Integer> resultMap = this.departmentService.checkDepartmentScheduleInDay(deptId, startDate,
				endDate);
		List<String> dateInMonth = MssDateTimeUtil.getDateBetween(startDate, endDate);
		List<CalendarInfo> calendarInfoList = new ArrayList<CalendarInfo>();
		CalendarInfo calendar;
		for (String date : dateInMonth) {
			calendar = new CalendarInfo();
			calendar.setCheckedDate(date);
			if (resultMap.containsKey(date)) {
				calendar.setStatus(resultMap.get(date));
			} else {
				calendar.setStatus(CalendarStatus.FULL.toInt());
			}
			// set title
			if (CalendarStatus.FULL.toInt().equals(calendar.getStatus())) {
				calendar.setTitle(this.getText("calendar.title.full"));
			} else if (CalendarStatus.HALF_FULL.toInt().equals(calendar.getStatus())) {
				calendar.setTitle(this.getText("calendar.title.half_full"));
			} else {
				calendar.setTitle(this.getText("calendar.title.none"));
			}
			calendarInfoList.add(calendar);
		}
		builder.status(HttpStatus.OK).data(calendarInfoList);
		LOG.info("[End] Ajax init month data calendar.");
		return builder.build();
	}

	/**
	 * View calendar week.
	 *
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@RequestMapping(value = "/calendar-week", method = RequestMethod.GET)
	public ModelAndView viewCalendarWeek(@RequestParam(value = "isWeekMode", required = false) String isWeekModeStr,
			ModelMap model, HttpSession session) throws Exception {
		LOG.info("[Start] View calendar week.");
		ModelAndView modelAndView = new ModelAndView("front.calendar.week");
		Boolean isWeekMode = true;
		if (isWeekModeStr != null && !StringUtils.isBlank(isWeekModeStr)) {
			isWeekMode = Boolean.valueOf(isWeekModeStr);
		}
		model.addAttribute("isWeekMode", isWeekMode);
		model.addAttribute("serverAddress", MssContextHolder.getDomainName());
		LOG.info("[End] View calendar week.");
		return modelAndView;
	}

	/**
	 * Ajax init week data calendar.
	 *
	 * @param calendarInfo
	 *            the calendar info
	 * @param session
	 *            the session
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-init-week-data-calendar", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxInitWeekDataCalendar(@RequestBody CalendarInfo calendar, HttpSession session) {
		LOG.info("[Start] Ajax init week data calendar.");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Integer deptId = Integer.valueOf(session.getAttribute("deptId").toString());
		LOG.debug("Ajax init week data calendar. deptId=" + deptId);
		String currentDate = calendar.getStartDateTime();
		String startDate;
		String endDate;
		if (calendar.getIsWeekMode()) {
			startDate = MssDateTimeUtil.getFirstDayOfWeek(true, currentDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD);
			endDate = MssDateTimeUtil.getFirstDayOfWeek(false, currentDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD);
		} else {
			startDate = currentDate;
			endDate = currentDate;
		}
		List<String> dateList = MssDateTimeUtil.getDateBetween(startDate, endDate);
		Map<String, List<CalendarInfo>> dsMap = this.departmentService.checkDepartmentScheduleInTimeslot(deptId,
				startDate, endDate);
		List<CalendarInfo> result = new ArrayList<CalendarInfo>();
		CalendarInfo calendarInfo;
		for (String date : dateList) {
			calendarInfo = new CalendarInfo();
			// set common data
			calendarInfo.setCheckedDate(date);
			calendarInfo.setFormattedCheckedDate(MssDateTimeUtil.convertStringDate(date,
					DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND, DateTimeFormat.DATE_TIME_FORMAT_MMDD));
			calendarInfo.setStartDateTime(MssDateTimeUtil.convertStringDateByLocale(startDate,
					DateTimeFormat.DATE_FORMAT_YYYYMMDD, this.getLocale()));
			calendarInfo.setEndDateTime(MssDateTimeUtil.convertStringDateByLocale(endDate,
					DateTimeFormat.DATE_FORMAT_YYYYMMDD, this.getLocale()));
			if (dsMap.containsKey(date)) {
				calendarInfo.setCalendarInfoList(dsMap.get(date));
				// number of record in each row is 6
				Integer remainder = calendarInfo.getCalendarInfoList().size() % 6;
				if (remainder != 0) {
					for (int i = 0; i < 6 - remainder; i++) {
						calendarInfo.getCalendarInfoList().add(createEmptyCalendarInfo(date));
					}
				}

			} else {
				calendarInfo.setCalendarInfoList(createEmptyCalendarInfoList(date));
			}
			result.add(calendarInfo);
		}
		builder.status(HttpStatus.OK).data(result);
		LOG.info("[End] Ajax init week data calendar.");
		return builder.build();
	}

	/**
	 * Ajax get timeslot list.
	 *
	 * @return the list
	 */
	@RequestMapping(value = "/ajax-get-vaccine-timeslot-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetVaccineTimeslotList(@RequestBody BookingTimeModel bookingTime) {
		LOG.info("[Start] ajax get timeslot list");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		Integer deptId = bookingInfo.getDeptId();
		Integer doctorId = bookingInfo.getDoctorId();
		LOG.debug("Ajax get timeslot list. deptId=" + deptId);
		List<String> timeslotList;
		MessageResponse<KcckVaccineScheduleModel> dataVaccineScheduleReponsive;
		String startDate = bookingTime.getStartDate();
		String endDate = bookingTime.getEndDate();
		/*
		 * timeslotList =
		 * kcckApiService.listKcckVaccineTime("K01","0030","20160919","20160928"
		 * ,"A100","121");
		 */
		dataVaccineScheduleReponsive = kcckApiService.getKcckVaccineSchedule("K01", "0030", "20160919", "20160928",
				"A100", "121");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(dataVaccineScheduleReponsive.getData());
		builder.message(dataVaccineScheduleReponsive.getMessage());
		LOG.info("[End] ajax get timeslot list");
		return builder.build();
	}

	/**
	 * Creates the empty calendar info list.
	 *
	 * @param checkDate
	 *            the check date
	 * @return the list
	 */
	private List<CalendarInfo> createEmptyCalendarInfoList(String checkDate) {
		List<CalendarInfo> emptyCalendarInfoList = new ArrayList<CalendarInfo>();
		CalendarInfo emptyCalendarInfo = createEmptyCalendarInfo(checkDate);
		for (int i = 0; i < 6; i++) {
			emptyCalendarInfoList.add(emptyCalendarInfo);
		}
		return emptyCalendarInfoList;
	}

	/**
	 * Creates the empty calendar info.
	 *
	 * @param checkDate
	 *            the check date
	 * @return the calendar info
	 */
	private CalendarInfo createEmptyCalendarInfo(String checkDate) {
		CalendarInfo emptyCalendarInfo = new CalendarInfo();
		emptyCalendarInfo.setCheckedDate(checkDate);
		emptyCalendarInfo.setStatus(Integer.valueOf(-1));
		return emptyCalendarInfo;
	}

	/**
	 * Ajax get full timeslot list.
	 *
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-get-full-timeslot-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetFullTimeslotList(HttpSession session) {
		Integer deptId = Integer.valueOf(session.getAttribute("deptId").toString());
		List<String> timeslotList = this.doctorScheduleService.getFullTimeslotListByDepartment(deptId);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(timeslotList);
		return builder.build();
	}

	/**
	 * Ajax select timeslot calendar.
	 *
	 * @param bookingTime
	 *            the booking time
	 * @param session
	 *            the session
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-select-timeslot-calendar", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSelectTimeslotCalendar(@RequestBody BookingTimeModel bookingTime, HttpSession session) {
		LOG.info("[Start] Ajax select timeslot calendar.");
		Integer deptId = Integer.valueOf(session.getAttribute("deptId").toString());
		LOG.debug("Ajax select timeslot calendar. deptId=" + deptId);
		String selectedDate = bookingTime.getSelectedDate();
		String selectedTime = bookingTime.getSelectedTime();
		LocalDateTime selectedDateTime = LocalDateTime.parse(selectedDate + selectedTime,
				DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);
		DoctorModel doctor = null;
		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();

		if (checkTime.isAfter(now)) {
			doctor = this.doctorService.findAvailableDoctor(deptId, selectedDate, selectedTime);
			if (doctor == null) {
				LOG.warn("[WARN] Ajax select timeslot calendar. doctor is null");
				responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR)
						.message(this.getText("general.msg.internal_error"));
			}
		} else {
			responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR)
					.message(this.getText("general.msg.cannot_select_past_time"));
		}

		if (doctor != null) {
			MssContextHolder.setBookingInfo(new BookingInfo());
			MssContextHolder.getBookingInfo().setDoctorId(doctor.getDoctorId());
			MssContextHolder.getBookingInfo().setDoctorName(doctor.getName());
			MssContextHolder.getBookingInfo().setReservationDate(selectedDate);
			MssContextHolder.getBookingInfo().setReservationTime(selectedTime);
			MssContextHolder.getBookingInfo().setDeptId(doctor.getDeptId());
			MssContextHolder.getBookingInfo()
					.setDeptName(this.departmentService.findDepartmentById(deptId).getDeptName());
			// reset formatted date time
			MssContextHolder.getBookingInfo().setFormattedReservationDate(StringUtils.EMPTY);
			MssContextHolder.getBookingInfo().setFormattedReservationTime(StringUtils.EMPTY);
			responseBuilder.status(HttpStatus.OK);
		}
		LOG.info("[End] Ajax select timeslot calendar.");
		return responseBuilder.build();
	}

	/**
	 * View thank you page.
	 *
	 * @param token
	 *            the token
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@NavigationConfig(group = { NavigationGroup.BOOKING_NEW })
	@RequestMapping(value = "/thank-you", method = RequestMethod.GET)
	public ModelAndView viewThankYouPage(@RequestParam(value = "token") String token) throws Exception {
		LOG.info("[Start] thank you");
		ModelAndView modelAndView = new ModelAndView("front.thank.you");
		if (token != null && StringUtils.isNotBlank(token)) {
			String[] mailIdList = TokenUtils.decodeMailIdToken(token);
			for (String mailId : mailIdList) {
				if (NumberUtils.isDigits(mailId)) {
					mailService.updateReadingFlg(Integer.valueOf(mailId), ReadingFlg.READ.toInt());
				}
			}
		}
		LOG.info("[End] thank you");
		return modelAndView;

	}

	/**
	 * Booking vaccine.
	 *
	 * @param modelMap
	 *            the model map
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping("/booking-vaccine-recommendation")
	@NavigationConfig(group = { NavigationGroup.BOOKING_NEW,
			NavigationGroup.VACCINE_RECOMMENDATION }, stepType = NavigationType.BOOKING_VACCINEE_STEPS)
	public ModelAndView bookingVaccine(@RequestParam(value = "deptId", required = false) String deptIdStr,
			@RequestParam(value = "childId", required = false) Integer childId, ModelMap modelMap) throws Exception {
		List<UserChildModel> lstChild = new ArrayList<UserChildModel>();
		if (childId != null) {
			UserChildModel userChildModel = this.userChildService.findById(childId);
			lstChild.add(userChildModel);
		} else {
			lstChild = userChildService.findUserChildByActiveFlg(this.getUser().getUserId(), ActiveFlag.ACTIVE.toInt());
		}
		modelMap.addAttribute("lstChild", lstChild);
		modelMap.addAttribute("deptId", deptIdStr);

		return new ModelAndView("front.booking.vaccine.recommendation");
	}

	/**
	 * Booking vaccine select time.
	 *
	 * @param deptId
	 *            the dept id
	 * @param vaccineId
	 *            the vaccine id
	 * @param childId
	 *            the child id
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/booking-vaccine-select-time", method = RequestMethod.GET)
	@NavigationConfig(group = { NavigationGroup.BOOKING_NEW,
			NavigationGroup.CHOOSE_TIME }, stepType = NavigationType.BOOKING_VACCINEE_STEPS)
	public ModelAndView bookingVaccineSelectTime(@RequestParam(value = "deptId", required = false) Integer deptId,
			@RequestParam(value = "vaccineId", required = false) String strVaccineId,
			@RequestParam(value = "date", required = false) String dateStr,
			@RequestParam(value = "childId", required = false) String strChildId,
			@RequestParam(value = "timesUsing", required = false) String timesUsing, ModelMap model) throws Exception {
		Integer childId = null;
		Integer vaccineId = null;
		String injectedNo = null;
		DepartmentModel dept = new DepartmentModel();
		if (MssContextHolder.isKcck()) {
			dept = this.kcckDepartmentService.findKcckDepartmentById(MssContextHolder.getHospCode(),
					MssContextHolder.getLocale().toString(), deptId);
			if (dept == null) {
				dept = this.kcckDepartmentService.findKcckDepartmentByType(MssContextHolder.getHospCode(),
						MssContextHolder.getLocale().toString(), DepartmentType.VACCINE.toInt());
			}
		} else {
			dept = this.departmentService.findDeptByType(MssContextHolder.getHospCode(),
					DepartmentType.VACCINE.toInt());
		}
		// for other fast booking flow
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (bookingInfo == null) {
			bookingInfo = new BookingInfo();
		}
		if (StringUtils.isBlank(strVaccineId) && StringUtils.isBlank(strChildId) && StringUtils.isBlank(timesUsing)) {
			childId = bookingInfo.getChildId();
			vaccineId = bookingInfo.getVaccineId();
			injectedNo = bookingInfo.getTimesUsing();
		}
		if (NumberUtils.isDigits(strVaccineId) && NumberUtils.isDigits(strChildId)
				&& !StringUtils.isBlank(timesUsing)) {
			childId = Integer.valueOf(strChildId);
			vaccineId = Integer.valueOf(strVaccineId);
			injectedNo = timesUsing.substring(0, 1);
		}
		if (vaccineId == null || childId == null || injectedNo == null) {
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("fe00302.msg.no.select.vaccine")));
			return new ModelAndView(new RedirectView("booking-vaccine-recommendation?deptId=" + dept.getDeptId()));
		}
		// display first date in booking vaccine schedule
		if (dateStr != null && !StringUtils.isBlank(dateStr)) {
			model.addAttribute("curDate", MssDateTimeUtil.convertStringDate(dateStr,
					DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
			model.addAttribute("isVaccine", true);
		}
		model.addAttribute("isKcck", false);
		if (MssContextHolder.isKcck())
			model.addAttribute("isKcck", true);
		if (this.getUser() != null) {
			UserModel userModel = userService.getUser(this.getUser().getUserId());
			bookingInfo.setPatientName(userModel.getName());
			bookingInfo.setPatientFurigana(userModel.getNameFurigana());
			bookingInfo.setEmail(userModel.getEmail());
			bookingInfo.setPhoneNumber(userModel.getPhoneNumber());
			bookingInfo.setUserSex(userModel.getSex());
			bookingInfo.setUserDob(userModel.getDob());
			bookingInfo.setDeptName(dept.getDeptName());
		}
		bookingInfo.setDeptId(dept.getDeptId());
		bookingInfo.setVaccineId(vaccineId);
		bookingInfo.setChildId(childId);
		bookingInfo.setTimesUsing(injectedNo);
		bookingInfo.setDeptType(DepartmentType.VACCINE.toInt());
		MssContextHolder.setBookingInfo(bookingInfo);
		// DepartmentModel dept =
		// this.departmentService.findDepartmentById(bookingInfo.getDeptId());
		model.addAttribute("departmentName", dept.getDeptName());
		return new ModelAndView("front.booking.time");
	}

	/**
	 * Booking vaccine contact information.
	 *
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/booking-vaccine-info", method = RequestMethod.GET)
	@NavigationConfig(group = { NavigationGroup.BOOKING_NEW,
			NavigationGroup.INPUT_INFO }, stepType = NavigationType.BOOKING_VACCINEE_STEPS)
	public ModelAndView bookingVaccineContactInformation(ModelMap model) throws Exception {
		PatientModel patient = new PatientModel();
		if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode()))
			patient.setNewBooking(false);
		else
			patient.setNewBooking(true);

		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (bookingInfo != null) {
			createPatient(bookingInfo, patient);
			model.addAttribute("deptName", bookingInfo.getDeptName());
			model.addAttribute("deptId", bookingInfo.getDeptId());
			model.addAttribute("bookingTime",
					bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
			model.addAttribute("vaccineId", bookingInfo.getVaccineId());
			model.addAttribute("childId", bookingInfo.getChildId());
			model.addAttribute("timesUsing", bookingInfo.getTimesUsing());

		}
		patient.setMapReminderTime(getReminderTimeMap());
		model.addAttribute("reservationMode", MssContextHolder.getReservationMode());
		model.addAttribute("patient", patient);
		model.addAttribute("bookingVaccine", true);
		UserChildModel childModel = this.userChildService.findById(bookingInfo.getChildId());
		if (childModel != null) {
			model.addAttribute("childName", childModel.getChildName());
			bookingInfo.setChildName(childModel.getChildName());
		}

		return new ModelAndView("front.booking.info");
	}

	/**
	 * Post booking vaccine info.
	 *
	 * @param patient
	 *            the patient
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@NavigationConfig(group = { NavigationGroup.BOOKING_NEW,
			NavigationGroup.INPUT_INFO }, stepType = NavigationType.BOOKING_VACCINEE_STEPS)
	@RequestMapping(value = "/booking-vaccine-info", method = RequestMethod.POST)
	@SessionValidate
	public ModelAndView postBookingVaccineInfo(@Valid @ModelAttribute("patient") PatientModel patient,
			BindingResult result, ModelMap model) {
		String fullName = patient.getName();
		String fullNameKana = patient.getNameFurigana();
		if (HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
			if (result.getFieldError(fullName) == null && result.getFieldError(fullNameKana) == null) {
				LOG.debug("Full Name: " + fullName + " Full Name Kana: " + fullNameKana);
				// check space ã‚­ãƒŽã‚·ã‚¿ ã‚´ã‚¦ ã¡ ã¡
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("name", "general.label.name.required.space");
				}
				if (!StringUtils.isEmpty(fullNameKana)
						&& !fullNameKana.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("nameFurigana", "general.label.name.required.space");
				}
			}
		} else {
			if (result.getFieldError(fullName) == null) {
				LOG.debug("Full Name: " + fullName);
				// check space
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("name", "general.label.name.required.space");
				}
			}
		}
		patient.setMapReminderTime(getReminderTimeMap());
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (result.hasErrors()) {
			if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
					|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode()))
				patient.setNewBooking(false);
			else
				patient.setNewBooking(true);
			model.addAttribute("patient", patient);
			model.addAttribute("bookingTime",
					bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
			model.addAttribute("childName", bookingInfo.getChildName());
			model.addAttribute("vaccineId", bookingInfo.getVaccineId());
			model.addAttribute("childId", bookingInfo.getChildId());
			model.addAttribute("timesUsing", bookingInfo.getTimesUsing());
			model.addAttribute("bookingVaccine", true);
			return new ModelAndView("front.booking.info");
		}
		bookingInfo.setPatientName(patient.getName());
		bookingInfo.setPatientFurigana(patient.getNameFurigana());
		bookingInfo.setEmail(patient.getEmail());
		bookingInfo.setPhoneNumber(patient.getPhoneNumber());
		bookingInfo.setEmail(patient.getEmail());
		bookingInfo.setCardNumber(patient.getCardNumber());
		bookingInfo.setReminderTime(patient.getReminderTime());
		bookingInfo.setUserDob(patient.getDob());
		bookingInfo.setUserSex(patient.getGender());
		bookingInfo.setPatientGender(patient.getGender());
		bookingInfo.setPatientBitrhday(
				MssDateTimeUtil.dateFromString(patient.getDob(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));

		return new ModelAndView(new RedirectView("booking-vaccine-info-confirm"));
	}

	/**
	 * Confirm booking vaccine info.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@NavigationConfig(group = { NavigationGroup.CONFIRM }, stepType = NavigationType.BOOKING_VACCINEE_STEPS)
	@RequestMapping(value = "/booking-vaccine-info-confirm", method = RequestMethod.GET)
	@SessionValidate
	public ModelAndView confirmBookingVaccineInfo(ModelMap model) throws Exception {
		LOG.info("[Start] Confirm booking info.");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		PatientModel patient = new PatientModel();
		if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())
				|| BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode()))
			patient.setNewBooking(false);
		else
			patient.setNewBooking(true);
		createPatient(bookingInfo, patient);

		Map<Integer, String> mapReminderTime = new HashMap<>();
		ReminderTime time = ReminderTime.newInstance(bookingInfo.getReminderTime());
		mapReminderTime.put(time.toKey(), time.toText());
		patient.setMapReminderTime(mapReminderTime);

		UserChildModel childModel = this.userChildService.findById(bookingInfo.getChildId());
		VaccineModel vaccineModel = this.vaccineService.findById(bookingInfo.getVaccineId());

		bookingInfo.setChildName(childModel.getChildName());
		bookingInfo.setDob(childModel.getDob());
		bookingInfo.setSex(childModel.getSex());
		bookingInfo.setVaccineName(vaccineModel.getVaccineName());

		model.addAttribute("reservationMode", MssContextHolder.getReservationMode());
		model.addAttribute("patient", patient);
		model.addAttribute("deptName", bookingInfo.getDeptName());
		model.addAttribute("bookingDate", bookingInfo.getFormattedReservationDate());
		model.addAttribute("bookingTime", bookingInfo.getFormattedReservationTime());
		model.addAttribute("timeUsing", bookingInfo.getTimesUsing());
		model.addAttribute("childModel", childModel);
		model.addAttribute("vaccineModel", vaccineModel);
		model.addAttribute("bookingVaccine", true);
		LOG.info("[End] Confirm booking info.");
		return new ModelAndView("front.booking.info.confirm_vaccine");
	}

	private void createPatient(BookingInfo bookingInfo, PatientModel patient) {
		patient.setName(bookingInfo.getPatientName());
		patient.setNameFurigana(bookingInfo.getPatientFurigana());
		patient.setEmail(bookingInfo.getEmail());
		if (bookingInfo.getUserSex() != null) {
			if (bookingInfo.getUserSex().equals("M") || bookingInfo.getUserSex().equals("1")) {
				patient.setGender("M");
				patient.setGenderText(this.getText("general.label.male"));
			} else {
				patient.setGender("F");
				patient.setGenderText(this.getText("general.label.female"));
			}
		}
		patient.setDob(bookingInfo.getUserDob());
		patient.setPhoneNumber(bookingInfo.getPhoneNumber());
		patient.setCardNumber(bookingInfo.getCardNumber());
		patient.setReminderTime(bookingInfo.getReminderTime());
		patient.setChildId(bookingInfo.getChildId());
	}

	/**
	 * Submit booking vaccine info.
	 *
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@NavigationConfig(group = { NavigationGroup.TEMP_SCHEDULE }, stepType = NavigationType.BOOKING_VACCINEE_STEPS)
	@RequestMapping(value = "/booking-vaccine-accept", method = RequestMethod.POST)
	@SessionValidate
	public ModelAndView submitBookingVaccineInfo() throws Exception {
		LOG.info("[Start] booking accept");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();

		// Check doctor is full
		// if (bookingInfo.getDeptId() !=
		// MssConfiguration.getInstance().getApiKcckVaccineId()) {
		// if
		// (this.doctorScheduleService.isDoctorScheduleFull(bookingInfo.getDoctorId(),
		// bookingInfo.getReservationDate(), bookingInfo.getReservationTime()))
		// {
		// this.addNotification(
		// new NotificationModel(NotificationType.ERROR,
		// this.getText("fe005.msg.full.time.slot")));
		// return new ModelAndView(new
		// RedirectView("booking-vaccine-info-confirm"));
		// }
		// }
		ReservationModel reservationModel = bookingService.savePatientInfo(bookingInfo,
				MssContextHolder.getReservationMode(), MssContextHolder.getHospitalId(), false,
				this.getUser().getMasterProfileId(), null);
		bookingInfo.setReservationCode(reservationModel.getReservationCode());

		// If Booking vaccine
		VaccineChildHistoryModel vaccineChildHistoryModel = new VaccineChildHistoryModel();
		vaccineChildHistoryModel.setReservationId(reservationModel.getReservationId());
		vaccineChildHistoryModel.setChildId(bookingInfo.getChildId());
		vaccineChildHistoryModel.setVaccineId(bookingInfo.getVaccineId());
		vaccineChildHistoryModel.setHospitalName(reservationModel.getHospitalName());
		vaccineChildHistoryModel.setLoginHospitalId(this.getUser().getHospitalId());
		Timestamp injectedDate = MssDateTimeUtil.convertStringToTimestamp(
				bookingInfo.getReservationDate() + bookingInfo.getReservationTime(),
				DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM);
		if (injectedDate == null) {
			return new ModelAndView(new RedirectView("booking-vaccine-info-confirm"));
		} else {
			vaccineChildHistoryModel.setInjectedDate(injectedDate);
		}
		vaccineChildHistoryModel.setInjectedNo(Integer.valueOf(bookingInfo.getTimesUsing()));
		// Get Vaccine_hospital
		Integer vaccineHospitalId = this.vaccineHospitalService
				.findByHospitalIdVaccineId(this.getUser().getHospitalId(), bookingInfo.getVaccineId())
				.getVaccineHospitalId();
		vaccineChildHistoryModel.setVaccineHospitalId(vaccineHospitalId);
		this.vaccineChildHistoryService.save(vaccineChildHistoryModel);

		// send mail when accept temporary
		MailInfo mailInfo = createEmailInfo(bookingInfo, reservationModel.getHospitalName());

		List<Object> args = new ArrayList<Object>();
		args.add(MssContextHolder.getUserLanguage());
		args.add(MssContextHolder.getTokenHospCode());
		mailInfo.setLinkBookingVaccineComplete(MssContextHolder.getDomainName()
				+ this.getText("be030.link.for.booking.vaccine.complete", args) + mailInfo.getSessionId().toString());
		mailInfo.setBookingVaccine(true);
		List<String> toList = new ArrayList<>();
		toList.add(bookingInfo.getEmail());
		mailService.sendMail(MailCode.BOOKING_VACCINE_NEW_ACCEPTED.toString(), this.getLanguage(), mailInfo, toList,
				reservationModel.getPatientId(), reservationModel.getReservationId(), MssContextHolder.getHospitalId(),
				MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());

		// Set model
		ModelAndView modelAndView = new ModelAndView("front.booking.accept");
		// modelAndView.addObject("reservationCode",
		// bookingInfo.getReservationCode());
		modelAndView.addObject("deptName", bookingInfo.getDeptName());
		modelAndView.addObject("bookingTime",
				bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
		ReminderTime time = ReminderTime.newInstance(bookingInfo.getReminderTime());
		modelAndView.addObject("reminderTime", time.toText());

		LOG.info("[End] booking accept");
		return modelAndView;
	}

	/**
	 * View booking vaccine info.
	 *
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@NavigationConfig(group = { NavigationGroup.TEMP_SCHEDULE }, stepType = NavigationType.BOOKING_VACCINEE_STEPS)
	@RequestMapping(value = "/booking-vaccine-accept", method = RequestMethod.GET)
	@SessionValidate
	public ModelAndView viewBookingVaccineInfo() throws Exception {
		LOG.info("[Start] booking accept");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();

		// Set model
		ModelAndView modelAndView = new ModelAndView("front.booking.accept");
		modelAndView.addObject("reservationCode", bookingInfo.getReservationCode());
		modelAndView.addObject("deptName", bookingInfo.getDeptName());
		modelAndView.addObject("bookingTime",
				bookingInfo.getFormattedReservationDate() + " " + bookingInfo.getFormattedReservationTime());
		ReminderTime time = ReminderTime.newInstance(bookingInfo.getReminderTime());
		modelAndView.addObject("reminderTime", time.toText());

		LOG.info("[End] booking accept");
		return modelAndView;
	}

	/**
	 * Complete booking vaccine.
	 *
	 * @param tokenId
	 *            the token id
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	// @Secured({UserRole.ROLE_FRONT_END_NAME})
	@NavigationConfig(group = { NavigationGroup.FINISH_SCHEDULE }, stepType = NavigationType.BOOKING_VACCINEE_STEPS)
	@RequestMapping(value = "/booking-vaccine-complete", method = RequestMethod.GET)
	public ModelAndView completeBookingVaccine(@RequestParam(value = "token") String tokenId,
			@RequestParam(value = "tokenHospCode", required = false) String tokenHospCode) throws Exception {
		LOG.info("[Start] Booking complete");
		ModelAndView modelAndView = new ModelAndView("front.booking.vaccine.complete");
		modelAndView.addObject("successBookingVaccine", true);
		TokenValidationResult tokenResult = TokenUtils.validateToken(tokenId);

		if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
			SessionModel session = this.bookingService.getSessionById(tokenId);
			tokenResult = TokenUtils.validateToken(session);
		}
		if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
			ReservationModel reservationModel;
			if (MssContextHolder.isKcck()) {
				reservationModel = bookingService.findKcckReservationBySessionId(tokenId);
			} else {
				reservationModel = bookingService.findReservationBySessionId(tokenId);
			}
			// check reservation session
			if (reservationModel == null) {
				LOG.warn("[WARN] Booking complete. reservationModel is null");
				return new ModelAndView(new RedirectView("expire"));
			}
			modelAndView.addObject("hospitalName", reservationModel.getHospitalName());
			// check the status of reservation that is deleted of not
			if (ReservationStatus.CANCELLED.toInt().equals(reservationModel.getReservationStatus())) {
				modelAndView.addObject("isDeletedBooking", true);
				return modelAndView;
			}
			// check the status of reservation that is already completed or not
			if (ReservationStatus.BOOKING_COMPLETED.toInt().equals(reservationModel.getReservationStatus())) {
				modelAndView.addObject("isAlreadyCompleted", true);
				return modelAndView;
			}
			// update reading flag of mail
			MailTemplateModel mailModel = this.bookingService.getMailTemplateByCode("BOOKING_NEW_ACCEPTED",
					this.getLanguage(), MssContextHolder.getHospitalId());
			if (mailModel != null) {
				this.bookingService.updateReadingFlag(tokenId, mailModel.getMailTemplateId());
			}
			// Get VaccineChildHistory
			VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService
					.findByReservationId(reservationModel.getReservationId());
			VaccineModel vaccineModel = null;
			VaccineHospitalModel vaccineHospitalModel = null;
			UserChildModel userChildModel = null;
			if (vaccineChildHistoryModel != null) {
				Integer vaccineId = vaccineChildHistoryModel.getVaccineId();
				vaccineHospitalModel = this.vaccineHospitalService
						.findByHospitalIdVaccineId(MssContextHolder.getHospitalId(), vaccineId);
				vaccineModel = this.vaccineService.findById(vaccineId);
				modelAndView.addObject("vaccineModel", vaccineModel);
				Integer childId = vaccineChildHistoryModel.getChildId();
				userChildModel = this.userChildService.findById(childId);
				modelAndView.addObject("userChildModel", userChildModel);
				modelAndView.addObject("injectedNo", vaccineChildHistoryModel.getInjectedNo());
				modelAndView.addObject("bookingVaccine", true);
			} else {
				return modelAndView.addObject("successBookingVaccine", false);
			}
			// KCCK-MSS
			if (MssContextHolder.isKcck()) {

				KcckReservationModel kcckModel = new KcckReservationModel();
				DepartmentModel departmentModel = kcckDepartmentService.

						findKcckDepartmentById(MssContextHolder.getHospCode(), MssContextHolder.getLocale().toString(),
								reservationModel.getDeptId());
				String reservationDate = MssDateTimeUtil.convertBetweenDateFormat(reservationModel.getReservationDate(),
						DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
				kcckModel.setDoctor_grade(MssConfiguration.getInstance().getApiKcckDoctorGrade());
				kcckModel.setHangmog_code(vaccineHospitalModel.getKcckVaccineCode());
				kcckModel.setHangmog_name(vaccineModel.getVaccineName());
				kcckModel.setDoctor_code(reservationModel.getDoctorCode());
				kcckModel.setPatient_name_kanji(reservationModel.getPatientName());
				if (HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
					kcckModel.setPatient_name_kana(LanguageUtils.convertKana(reservationModel.getNameFurigana()));
				} else {
					kcckModel.setPatient_name_kana(reservationModel.getPatientName());
				}
				kcckModel.setPatient_code(userChildModel.getPatientCode());
				kcckModel.setPatient_tel(reservationModel.getPhoneNumber());
				kcckModel.setPatient_email(reservationModel.getEmail());
				kcckModel.setPatient_sex(reservationModel.getPatientSex());
				kcckModel.setPatient_birthday(reservationModel.getPatientBirtday());
				//
				kcckModel.setHosp_code(MssContextHolder.getHospCode());
				kcckModel.setDepartment_code(departmentModel.getDeptCode());

				kcckModel.setReservation_date(reservationDate);
				kcckModel.setReservation_time(reservationModel.getReservationTime());
				kcckModel.setLocale(MssContextHolder.getLocale().toString());
				// TODO
				PatientModel p = this.bookingService.getParentByChildId(vaccineChildHistoryModel.getChildId());
				if (p != null && p.getCardNumber() != null) {
					kcckModel.setParent_code(p.getCardNumber());
				}

				// send reservation to KCCK
				LOG.info("BEFORE: saveReservation: reservation Info :" + kcckModel.toString());
				KcckReservationModel kcckReservationModel = kcckBookingService.saveReservation(kcckModel);
				if (kcckReservationModel != null && kcckReservationModel.getReservation_code() != null) {
					LOG.info("reservation KCCK Info :" + kcckReservationModel.toString());
					// update patientCode
					PatientModel patient = bookingService.updatePatient(reservationModel.getPatientId(),
							kcckReservationModel.getPatient_code(), kcckReservationModel.getParent_code());
					modelAndView.addObject("reservationCode", kcckReservationModel.getReservation_code());
					modelAndView.addObject("patientCode", kcckReservationModel.getPatient_code());

					// update Reservation info
					reservationModel.setReservationCode(kcckReservationModel.getReservation_code());
					reservationModel.setDeptName(kcckReservationModel.getDepartment_name());
					reservationModel.setDoctorName(kcckReservationModel.getDoctor_name());
					reservationModel.setDoctorCode(kcckReservationModel.getDoctor_code());
					reservationModel.setDepartmentCode(kcckReservationModel.getDepartment_code());
					LOG.debug("HospCode :" + MssContextHolder.getHospCode());
					LOG.debug("Kcck DoctorCode :" + kcckReservationModel.getDoctor_code());
					LOG.debug("Kcck DepartmentCode :" + kcckReservationModel.getDepartment_code());
					DoctorModel doctor = kcckDoctorService.findKcckDoctorByCode(MssContextHolder.getHospCode(),
							kcckReservationModel.getDoctor_code(), kcckReservationModel.getDepartment_code());
					if (doctor != null) {
						LOG.debug("Kcck DoctorID :" + doctor.getDoctorId());
						reservationModel.setDoctorId(doctor.getDoctorId());
					}

					// update Reservation Status

					reservationModel.setReservationStatus(ReservationStatus.BOOKING_COMPLETED.toInt());
					bookingService.updateReservation(reservationModel);
					// send mail
					MailInfo mailInfo = createMailInfoCompleteBooking(reservationModel, kcckReservationModel);
					List<String> toList = new ArrayList<>();
					toList.add(reservationModel.getEmail());
					mailService.sendMail(MailCode.BOOKING_NEW_COMPLETED.toString(), this.getLanguage(), mailInfo,
							toList, reservationModel.getPatientId(), reservationModel.getReservationId(),
							MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
							MssContextHolder.getDomainName());
				} else
					modelAndView.addObject("successBookingVaccine", false);

			} else {
				// check the doctor schedule before change reservation status
				if (this.doctorScheduleService.isDoctorScheduleFull(reservationModel.getDoctorId(),
						reservationModel.getReservationDate(), reservationModel.getReservationTime())) {
					modelAndView.addObject("isDoctorScheduleFull", true);
					return modelAndView;
				}
				// send mail
				MailInfo mailInfo = createMailInfoCompleteBooking(reservationModel, null);
				List<String> toList = new ArrayList<>();
				toList.add(reservationModel.getEmail());
				mailService.sendMail(MailCode.BOOKING_NEW_COMPLETED.toString(), this.getLanguage(), mailInfo, toList,
						reservationModel.getPatientId(), reservationModel.getReservationId(),
						MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
						MssContextHolder.getDomainName());

				// update Reservation Status
				reservationModel.setReservationStatus(ReservationStatus.BOOKING_COMPLETED.toInt());
				bookingService.updateReservation(reservationModel);
			}
			modelAndView.addObject("reservationCode", reservationModel.getReservationCode());
			modelAndView.addObject("hospitalName", reservationModel.getHospitalName());
			modelAndView.addObject("deptName", reservationModel.getDeptName());
			modelAndView.addObject("bookingTime", reservationModel.getFormattedReservationDate() + " "
					+ reservationModel.getFormattedReservationTime());
			ReminderTime time = ReminderTime.newInstance(reservationModel.getReminderTime());

			modelAndView.addObject("reminderTime", time.toText());
			modelAndView.addObject("token", tokenId);
			LOG.info("[End] Booking complete");
			return modelAndView;
		} else {
			// this.addNotification(new
			// NotificationModel(NotificationType.ERROR, "Invalid or expired
			// token."));
			return new ModelAndView(new RedirectView("expire"));
		}

	}

	private MailInfo createMailInfoCompleteBooking(ReservationModel reservationModel,
			KcckReservationModel kcckReservationCode) throws Exception {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setPatientName(reservationModel.getPatientName());
		if (MssContextHolder.isKcck()) {
			mailInfo.setReservationCode(kcckReservationCode.getReservation_code());
			mailInfo.setPatientCode(kcckReservationCode.getPatient_code());
		} else {
			mailInfo.setReservationCode(reservationModel.getReservationCode());
			// mailInfo.setPatientCode(reservationModel.getCardNumber()==null?
			// "" : reservationModel.getCardNumber());
			if (reservationModel.getCardNumber() != null) {
				mailInfo.setPatientCode(reservationModel.getCardNumber());
			} else {
				mailInfo.setPatientCode("");
			}
		}
		mailInfo.setDepartmentName(reservationModel.getDeptName());
		mailInfo.setDoctorName(reservationModel.getDoctorName());
		mailInfo.setHospitalName(MssContextHolder.getHospitalName());
		if (MssContextHolder.getLocale().equals(new Locale("vi"))) {
			mailInfo.setReservationDatetime(reservationModel.getFormattedReservationTime() + " "
					+ reservationModel.getFormattedReservationDate());
		} else {
			mailInfo.setReservationDatetime(reservationModel.getFormattedReservationDate() + " "
					+ reservationModel.getFormattedReservationTime());
		}
		mailInfo.setReminderTime(getText(ReminderTime.newInstance(reservationModel.getReminderTime()).toText()));
		mailInfo.setLinkAuthorizedEmail(
				MssContextHolder.getDomainName() + this.getText("be030.link.search.reservation"));
		UserChild child = userChildService.getUserChildByPatientId(reservationModel.getPatientId());
		if (child != null && child.getUser() != null) {
			mailInfo.setPatientName(child.getUser().getName());
			mailInfo.setChildName(child.getChildName());
		}
		return mailInfo;
	}

	/**
	 * Method getListMovieTalkHistory
	 * 
	 * @param iDisplayStart
	 * @param iDisplayLength
	 * @return
	 */
	@RequestMapping(value = "/get-nearest_doctor_schedule", method = RequestMethod.GET, produces = {
			"application/json; charset=UTF-8" })
	public @ResponseBody String getNearestDoctorSchedule(ModelMap model) {
		LOG.info("[Start] View get data history insurance.");

		List<KcckBookingSlotModel> listDoctorScheduleTemp = MssContextHolder.getKcckBookingSlots();
		List<DoctorModel> doctorModels = MssContextHolder.getDoctorList();
		List<KcckBookingSlotModel> listDoctorSchedule = new ArrayList<>();
		try{
		Map<String,List<DoctorModel>> mapDoctorModels = doctorModels.stream().collect(Collectors.groupingBy(DoctorModel::getDoctorCode));
			if(!mapDoctorModels.isEmpty())
			{
				listDoctorSchedule = listDoctorScheduleTemp.stream().map(p -> new KcckBookingSlotModel(p.getDoctor_code() + "_" + mapDoctorModels.get(p.getDoctor_code()).get(0).getName() + "_" + mapDoctorModels.get(p.getDoctor_code()).get(0).getDoctorId(), p.getStart_time(), p.getEnd_time(), p.getWaiting_patient())).collect(Collectors.toList());
			    Collections.sort(listDoctorSchedule, (p1,p2) -> Long.valueOf(p1.getStart_time()).compareTo(Long.valueOf(p2.getStart_time())));
			}
		}catch(Exception e)
		{
			LOG.info("Error Booking Faster " + e.toString());
		}
		DataTableJsonObject<KcckBookingSlotModel> doctorScheduleJsonObject = new DataTableJsonObject<>();
		doctorScheduleJsonObject.setiTotalDisplayRecords(listDoctorSchedule.size());
		doctorScheduleJsonObject.setiTotalRecords(listDoctorSchedule.size());
		doctorScheduleJsonObject.setAaData(listDoctorSchedule);
		GsonBuilder builder = new GsonBuilder();
		builder.serializeNulls();
		Gson gson = builder.create();
		String jsonOBJ = gson.toJson(doctorScheduleJsonObject);
		return jsonOBJ;
	}
	
	private String getStrCurrentDate() {
		DateFormat df = new SimpleDateFormat("yyyyMMdd");
		Date today = Calendar.getInstance().getTime();
		return df.format(today);
	}

}
