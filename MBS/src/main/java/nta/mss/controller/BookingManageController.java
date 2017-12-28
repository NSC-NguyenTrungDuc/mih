package nta.mss.controller;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.time.Instant;
import java.time.LocalDateTime;
import java.time.OffsetDateTime;
import java.time.ZoneOffset;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import javax.persistence.EntityNotFoundException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;
import javax.validation.Valid;

import nta.kcck.model.*;
import nta.kcck.service.IKcckDepartmentService;
import nta.kcck.service.impl.KcckBookingService;
import nta.kcck.service.impl.KcckDepartmentService;
import nta.kcck.service.impl.KcckDoctorService;
import nta.kcck.service.impl.KcckScheduleService;
import nta.mss.entity.DoctorSchedulePK;
import nta.mss.entity.Patient;
import nta.mss.info.AjaxResponse;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.info.BookingInfo;
import nta.mss.info.BookingVaccineBackendInfo;
import nta.mss.info.HospitalInfo;
import nta.mss.info.MailInfo;
import nta.mss.info.PatientInfo;
import nta.mss.info.ReservationInfo;
import nta.mss.info.ScheduleInfo;
import nta.mss.info.VaccineChildHistoryInfo;
import nta.mss.misc.common.DomainNameUtils;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.common.MssSessionContext;
import nta.mss.misc.common.SessionValidate;
import nta.mss.misc.common.VaccineUtils;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.BookingMode;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.DepartmentType;
import nta.mss.misc.enums.HospitalLocale;
import nta.mss.misc.enums.MailCode;
import nta.mss.misc.enums.NotificationType;
import nta.mss.misc.enums.ReminderTime;
import nta.mss.misc.enums.ReservationStatus;
import nta.mss.misc.enums.ReservationStatusString;
import nta.mss.misc.enums.UserRole;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.BookingTimeModel;
import nta.mss.model.DepartmentModel;
import nta.mss.model.DoctorModel;
import nta.mss.model.DoctorScheduleModel;
import nta.mss.model.HospitalModel;
import nta.mss.model.MailTemplateModel;
import nta.mss.model.NotificationModel;
import nta.mss.model.PatientModel;
import nta.mss.model.ReservationKpiModel;
import nta.mss.model.ReservationModel;
import nta.mss.model.SysUserModel;
import nta.mss.model.UserChildModel;
import nta.mss.model.UserModel;
import nta.mss.model.VaccineChildHistoryModel;
import nta.mss.model.VaccineHospitalModel;
import nta.mss.model.VaccineModel;
import nta.mss.security.WebSysUserDetails;
import nta.mss.security.WebUserDetails;
import nta.mss.service.IBookingService;
import nta.mss.service.IDepartmentScheduleService;
import nta.mss.service.IDepartmentService;
import nta.mss.service.IDoctorScheduleService;
import nta.mss.service.IDoctorService;
import nta.mss.service.IHospitalService;
import nta.mss.service.IMailService;
import nta.mss.service.IScheduleService;
import nta.mss.service.IUserService;
import nta.mss.service.IVaccineHospitalService;
import nta.mss.service.impl.DepartmentScheduleService;
import nta.mss.service.impl.UserChildService;
import nta.mss.service.impl.VaccineChildHistoryService;
import nta.mss.service.impl.VaccineService;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.math.NumberUtils;
import org.apache.commons.lang.time.DateUtils;
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

/**
 * The Class BookingManageController.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 */
@NavigationConfig(leftMenuType = NavigationType.BACK_LEFT_MENU)
@Controller
@Scope("prototype")
@RequestMapping("/booking-manage")
public class BookingManageController extends BaseController {
	private static final Logger LOG = LogManager.getLogger(BookingManageController.class);

	private IDepartmentService departmentService;

	private IHospitalService hospitalService;

	private IDoctorService doctorService;

	private IBookingService bookingService;

	private IDepartmentScheduleService departmentScheduleService;

	private IMailService mailService;

	private IDoctorScheduleService doctorScheduleService;

	private UserChildService userChildService;

	private VaccineChildHistoryService vaccineChildHistoryService;

	private VaccineService vaccineService;

	private IUserService userService;

	private IVaccineHospitalService vaccineHospitalService;

	KcckDepartmentService kcckDepartmentService = new KcckDepartmentService();
	KcckDoctorService kcckDoctorService = new KcckDoctorService();

	KcckBookingService kcckBookingService = new KcckBookingService();
	KcckScheduleService kcckScheduleService = new KcckScheduleService();

	public BookingManageController() {

	}

	/**
	 * Gets the sys user.
	 *
	 * @return the sys user
	 */
	public SysUserModel getSysUser() {
		if(SecurityContextHolder.getContext().getAuthentication()!=null){
	    	Object principal =  (WebSysUserDetails) SecurityContextHolder.getContext().getAuthentication().getPrincipal();
	    	if (principal instanceof WebSysUserDetails) {
				return ((WebSysUserDetails) principal).getSysUser();
			}
	    	}
			return null;
	}

	/**
	 * Instantiates a new booking manage controller.
	 *
	 * @param departmentService
	 *            the department service
	 * @param hospitalService
	 *            the hospital service
	 * @param doctorService
	 *            the doctor service
	 * @param bookingService
	 *            the booking service
	 * @param fileValidator
	 *            the file validator
	 */
	@Autowired
	public BookingManageController(IDepartmentService departmentService, IHospitalService hospitalService,
			IDoctorService doctorService, IBookingService bookingService,
			DepartmentScheduleService departmentScheduleService, IMailService mailService,
			IScheduleService scheduleService, IDoctorScheduleService doctorScheduleService,
			UserChildService userChildService, VaccineChildHistoryService vaccineChildHistoryService,
			VaccineService vaccineService, IUserService userService, IVaccineHospitalService vaccineHospitalService) {
		this.departmentService = departmentService;
		this.hospitalService = hospitalService;
		this.doctorService = doctorService;
		this.bookingService = bookingService;
		this.departmentScheduleService = departmentScheduleService;
		this.mailService = mailService;
		this.doctorScheduleService = doctorScheduleService;
		this.userChildService = userChildService;
		this.vaccineChildHistoryService = vaccineChildHistoryService;
		this.vaccineService = vaccineService;
		this.userService = userService;
		this.vaccineHospitalService = vaccineHospitalService;

	}

	/**
	 * Select department.
	 * 
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping("/select-department")
	public ModelAndView selectDepartment(ModelMap model) {
		LOG.info("[Start] Select department");
		MssContextHolder.setBookingInfo(new BookingInfo());
		MssContextHolder.setScheduleInfo(new ScheduleInfo());
		List<HospitalInfo> hospitalInfoList = new ArrayList<HospitalInfo>();
		HospitalInfo hospitalInfo;
		HospitalModel hospital = this.hospitalService.findHospitalModelByHospitalId(MssContextHolder.getHospitalId());
		List<DepartmentModel> internalDepts;
		List<DepartmentModel> surgeryDepts;
		List<DepartmentModel> vaccineDepts;
		List<DepartmentModel> newBorns;
		DepartmentModel depatmentModel;
		List<DepartmentModel> departmentList;
		if (hospital != null) {
			internalDepts = new ArrayList<DepartmentModel>();
			surgeryDepts = new ArrayList<DepartmentModel>();
			vaccineDepts = new ArrayList<DepartmentModel>();
			newBorns = new ArrayList<DepartmentModel>();
			departmentList = new ArrayList<DepartmentModel>();

			// check HospitalParentId : KCCK -MSS
			if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
				if (MssContextHolder.getKcckDepartmentList() == null) {
					departmentList = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
							MssContextHolder.getLocale().toString());
					MssContextHolder.setKcckDepartmentList(departmentList);
				} else {
					departmentList = MssContextHolder.getKcckDepartmentList();
				}
				double size = departmentList.size();
				int index = (int) Math.ceil(size / 3);
				internalDepts = departmentList.subList(0, index);
				if (size > 1) {
					surgeryDepts = departmentList.subList(index, index * 2);
					vaccineDepts = departmentList.subList(index * 2, (int) size);
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
		LOG.info("[End] Select department");
		return new ModelAndView("back.booking.department.select");
	}

	/**
	 * Ajax load department schedule.
	 * 
	 * @param bookingTime
	 *            the booking time
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-dept-schedule", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxLoadDepartmentSchedule(@RequestBody BookingTimeModel bookingTime) {
		LOG.info("[Start] Ajax load department schedule.");
		Integer deptId = MssContextHolder.getBookingInfo().getDeptId();
		LOG.debug("Ajax load department schedule. deptId=" + deptId);
		Map<String, ReservationKpiModel> departmentSchedule = this.departmentService.getDepartmentSchedule(deptId,
				bookingTime.getStartDate(), bookingTime.getEndDate());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(departmentSchedule);
		LOG.info("[End] Ajax load department schedule.");
		return builder.build();
	}

	/**
	 * Select date time.
	 * 
	 * @param deptId
	 *            the doct id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping("/select-time")
	public ModelAndView selectDateTime(@RequestParam(value = "deptId", required = false) String deptIdStr,
			ModelMap model) {
		LOG.info("[Start] Select date time.");
		if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			return new ModelAndView("front.access.denied");
		}
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (StringUtils.isBlank(deptIdStr) && bookingInfo != null) {
			deptIdStr = bookingInfo.getDeptId().toString();
		}
		if (StringUtils.isBlank(deptIdStr) || !NumberUtils.isDigits(deptIdStr)) {
			LOG.warn("[WARN] Select date time. deptId is null");
			return new ModelAndView(new RedirectView("select-department"));
		}

		Integer deptId = Integer.valueOf(deptIdStr);
		LOG.debug("Select date time. deptId=" + deptId);
		List<DoctorModel> doctorList = this.doctorService.findDoctorsByDepartment(deptId);
		DepartmentModel dept = this.departmentService.findDepartmentById(deptId);
		if (dept == null) {
			LOG.warn("[WARN] Select date time. DepartmentModel is null");
			return new ModelAndView(new RedirectView("select-department"));
		}

		if (bookingInfo == null) {
			bookingInfo = new BookingInfo();
			MssContextHolder.setBookingInfo(bookingInfo);
		}
		bookingInfo.setDeptId(dept.getDeptId());
		bookingInfo.setDeptName(dept.getDeptName());
		model.addAttribute("doctorList", doctorList);
		model.addAttribute("hospitalName", dept.getHospitalName());
		model.addAttribute("departmentName", dept.getDeptName());
		LOG.info("[End] Select date time.");
		return new ModelAndView("back.booking.time.select");
	}

	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@RequestMapping(value = "/ajax-validate-selected-time", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxValidateSelectedTime(@RequestBody ReservationModel reservationModel) {
		LOG.info("[Start] ajax validate selected time");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		String date = reservationModel.getReservationDate();
		String time = reservationModel.getReservationTime();
		LocalDateTime selectedDateTime = LocalDateTime.parse(date + time,
				DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);
		if (checkTime.isAfter(now)) {
			builder.status(HttpStatus.OK);
		} else {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
			.message(this.getText("general.msg.cannot_booking_past_time"));
		}
		LOG.info("[End] ajax validate selected time");
		return builder.build();
	}

	/**
	 * Ajax load doctor schedule.
	 * 
	 * @param bookingTime
	 *            the booking time
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-doctor-schedule", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxLoadDoctorSchedule(@RequestBody BookingTimeModel bookingTime) {
		LOG.info("[Start] Ajax load doctor schedule. ");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Map<String, ReservationKpiModel> doctorSchedule;
		if (bookingTime.getDoctorId() == null) {
			BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
			doctorSchedule = this.departmentService.getDepartmentSchedule(bookingInfo.getDeptId(),
					bookingTime.getStartDate(), bookingTime.getEndDate());
		} else {
			doctorSchedule = this.doctorService.getDoctorSchedule(bookingTime.getDoctorId(), bookingTime.getStartDate(),
					bookingTime.getEndDate());
		}
		builder.status(HttpStatus.OK).data(doctorSchedule);
		LOG.info("[End] Ajax load doctor schedule. ");
		return builder.build();
	}

	// TODO

	/**
	 * Ajax get timeslot list.
	 *
	 * @return the list
	 * @throws Exception
	 */
	@RequestMapping(value = "/ajax-get-kcck-timeslot-list", method = {
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
		DepartmentModel departmentModel = kcckDepartmentService.findKcckDepartmentById(MssContextHolder.getHospCode(),
				MssContextHolder.getLocale().toString(), deptId);
		DoctorModel doctor = kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(), doctorId,
				departmentModel.getDeptCode());
		timeslotList = this.kcckScheduleService.listKcckDoctorTime(MssContextHolder.getHospCode(),
				departmentModel.getDeptCode(), doctor.getDoctorCode(), startDate, endDate);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(timeslotList);
		LOG.info("[End] ajax get timeslot list");
		return builder.build();
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
		TimeslotScheduleModel doctorSchedule;
		DepartmentModel departmentModel = kcckDepartmentService.findKcckDepartmentById(MssContextHolder.getHospCode(),
				MssContextHolder.getLocale().toString(), MssContextHolder.getBookingInfo().getDeptId());
		if (departmentModel != null) {
			DoctorModel doctor = kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(), doctorId,
					departmentModel.getDeptCode());
			if (doctor != null) {
				doctorSchedule = this.kcckScheduleService.checkKcckDepartmentSchedule(MssContextHolder.getHospCode(),
						MssConfiguration.getInstance().getApiKcckDepartmentScheduleTime(),
						startDate, endDate,
						departmentModel.getDeptCode(), doctor.getDoctorCode(), null);
			} else {
				doctorSchedule = new TimeslotScheduleModel(null, null, null);
			}
		} else {
			doctorSchedule = new TimeslotScheduleModel(null, null, null);
		}
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (doctorSchedule == null || doctorSchedule.getTimeslots().isEmpty()) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).data(doctorSchedule);
		} else {
			builder.status(HttpStatus.OK).data(doctorSchedule);
		}
		LOG.info("[End] ajax get booking change ");
		return builder.build();
	}

	/**
	 * Ajax load doctor reservation.
	 * 
	 * @param bookingTime
	 *            the booking time
	 * @return the list
	 */
	@RequestMapping(value = "/ajax-doctor-reservations", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxLoadDoctorReservation(@RequestBody BookingTimeModel bookingTime) {
		LOG.info("[Start] Ajax load doctor reservation. ");
		Map<String, Object> result = new HashMap<String, Object>();
		String selectedDate = MssDateTimeUtil.convertStringDateByLocale(bookingTime.getSelectedDate(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD, this.getLocale());
		String selectedTime = MssDateTimeUtil.convertStringTimeByLocale(bookingTime.getSelectedTime(),
				DateTimeFormat.TIME_FORMAT_HH_MM, this.getLocale());
		LOG.debug("Ajax load doctor reservation. selectedDate=" + selectedDate + " ;selectedTime=" + selectedTime);
		List<ReservationModel> reservations;
		List<ReservationModel> lstReservations = new ArrayList<ReservationModel>();
		ReservationModel reservationModel = null;
		if (bookingTime.getDoctorId() == null) {
			BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
			List<DoctorModel> doctorList = this.doctorService.findDoctorsByDepartment(bookingInfo.getDeptId());
			for (DoctorModel d : doctorList) {
				reservations = this.bookingService.getReservationsByDoctorAndTimeSlot(d.getDoctorId(),
						bookingTime.getSelectedDate(), bookingTime.getSelectedTime());
				if (reservations != null && !reservations.isEmpty()) {
					reservationModel = new ReservationModel();
					createReservationModel(bookingTime, selectedDate, selectedTime, reservations, reservationModel, d);
					lstReservations.add(reservationModel);
				}
			}

		} else {
			reservations = this.bookingService.getReservationsByDoctorAndTimeSlot(bookingTime.getDoctorId(),
					bookingTime.getSelectedDate(), bookingTime.getSelectedTime());
			reservationModel = new ReservationModel();
			reservationModel.setReservationModels(reservations);
			reservationModel.setDoctorId(bookingTime.getDoctorId());
			reservationModel.setReservationDate(bookingTime.getSelectedDate());
			reservationModel.setReservationTime(bookingTime.getSelectedTime());
			reservationModel.setFormattedReservationDate(selectedDate);
			reservationModel.setFormattedReservationTime(selectedTime);
			lstReservations.add(reservationModel);
		}
		result.put("lstReservations", lstReservations);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(result);
		LOG.info("[End] Ajax load doctor reservation. ");
		return builder.build();
	}

	private void createReservationModel(BookingTimeModel bookingTime, String selectedDate, String selectedTime,
			List<ReservationModel> reservations, ReservationModel reservationModel, DoctorModel d) {
		reservationModel.setReservationModels(reservations);
		reservationModel.setDoctorId(d.getDoctorId());
		reservationModel.setDoctorName(d.getName());
		reservationModel.setReservationDate(bookingTime.getSelectedDate());
		reservationModel.setReservationTime(bookingTime.getSelectedTime());
		reservationModel.setFormattedReservationDate(selectedDate);
		reservationModel.setFormattedReservationTime(selectedTime);
	}

	/**
	 * Booking new reservation.
	 * 
	 * @param date
	 *            the date
	 * @param time
	 *            the time
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/booking-new")
	public ModelAndView bookingNew(@RequestParam(value = "date", required = false) String date,
			@RequestParam(value = "time", required = false) String time,
			@RequestParam(value = "doctorId", required = false) String doctorId,
			@RequestParam(value = "isBookingVaccine", required = false) String isBookingVaccine, ModelMap model,
			HttpSession session) throws Exception {
		LOG.info("[Start] Booking new.");
		PatientInfo patient = new PatientInfo();
		MssContextHolder.setReserveMode(BookingMode.NEW_BOOKING.toInt());
		patient.setNewBooking(true);

		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (bookingInfo != null) {
			bookingInfo.setReservationDate(date);
			bookingInfo.setReservationTime(time);
			if (StringUtils.isBlank(date)) {
				date = bookingInfo.getReservationDate();
			}
			if (StringUtils.isBlank(time)) {
				time = bookingInfo.getReservationTime();
			}
			// if is booking vaccine
			if (!StringUtils.isBlank(isBookingVaccine)) {
				if (bookingInfo.getUserId() == null || bookingInfo.getVaccineId() == null
						|| bookingInfo.getChildId() == null || StringUtils.isBlank(bookingInfo.getTimesUsing())) {
					LOG.warn("[WARN] Booking vaccine new. not enough infoamtion");
					return new ModelAndView(new RedirectView("select-time"));
				}
				createInfoUser(patient, bookingInfo);
				model.addAttribute("vaccine", this.vaccineService.findById(bookingInfo.getVaccineId()));
				model.addAttribute("child", this.userChildService.findById(bookingInfo.getChildId()));
				model.addAttribute("isBookingVaccine", true);
			}
		} else {
			bookingInfo = new BookingInfo();
		}
		if (StringUtils.isBlank(date) || StringUtils.isBlank(time)) {
			LOG.warn("[WARN] Booking new. date or time is null");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("general.msg.select_booking_time")));
			return new ModelAndView(new RedirectView("select-time"));
		}
		Date selectedDateTime = MssDateTimeUtil.dateFromString(date + time,
				DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM);
		Date now = new Date();
		// if (selectedDateTime.before(now)) {
		// this.addNotification(new NotificationModel(NotificationType.ERROR,
		// this.getText("general.msg.cannot_select_past_time")));
		// return new ModelAndView(new RedirectView("select-time"));
		// }
		bookingInfo.setReservationDate(date);
		bookingInfo.setReservationTime(time);
		bookingInfo.setDoctorId(Integer.valueOf(doctorId));
		MssContextHolder.setBookingInfo(bookingInfo);

		patient.setMapReminderTime(getReminderTimeMap());
		model.addAttribute("patient", patient);
		model.addAttribute("deptName", bookingInfo.getDeptName());
		Locale currentLocale = this.getLocale();
		String formattedDate = MssDateTimeUtil.convertStringDateByLocale(date, DateTimeFormat.DATE_FORMAT_YYYYMMDD,
				currentLocale);
		String formattedTime = MssDateTimeUtil.convertStringTimeByLocale(time, DateTimeFormat.TIME_FORMAT_HH_MM,
				currentLocale);
		model.addAttribute("bookingDate", formattedDate);
		model.addAttribute("bookingTime", formattedTime);
		LOG.info("[End] Booking new.");
		return new ModelAndView("back.booking.new");
	}

	private void createInfoUser(PatientInfo patient, BookingInfo bookingInfo) {
		UserModel userModel = this.userService.getUser(bookingInfo.getUserId());
		patient.setUserId(userModel.getUserId());
		patient.setName(userModel.getName());
		patient.setNameFurigana(userModel.getNameFurigana());
		patient.setEmail(userModel.getEmail());
		patient.setPhoneNumber(userModel.getPhoneNumber());
		patient.setTimeUsing(bookingInfo.getTimesUsing());

		patient.setVaccineId(bookingInfo.getVaccineId());
		patient.setChildId(bookingInfo.getChildId());
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
	 * Save new reservation and display reservation info.
	 * 
	 * @param patient
	 *            the patient
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/booking-new", method = RequestMethod.POST, params = { "validate" })
	public ModelAndView bookingNewValidate(@Valid @ModelAttribute("patient") PatientInfo patient, BindingResult result,
			ModelMap model) throws Exception {
		LOG.info("[Start] booking New Validate");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (patient.getUserId() != null && patient.getVaccineId() != null && patient.getChildId() != null) {
			model.addAttribute("vaccine", this.vaccineService.findById(bookingInfo.getVaccineId()));
			model.addAttribute("child", this.userChildService.findById(bookingInfo.getChildId()));
			model.addAttribute("isBookingVaccine", true);
		}
		Locale currentLocale = this.getLocale();
		patient.setMapReminderTime(getReminderTimeMap());
		model.addAttribute("deptName", bookingInfo.getDeptName());
		model.addAttribute("bookingDate", MssDateTimeUtil.convertStringDateByLocale(bookingInfo.getReservationDate(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD, currentLocale));
		model.addAttribute("bookingTime", MssDateTimeUtil.convertStringTimeByLocale(bookingInfo.getReservationTime(),
				DateTimeFormat.TIME_FORMAT_HH_MM, currentLocale));
		LOG.info("[End] booking New Validate");
		if (result.hasErrors()) {

			return new ModelAndView("back.booking.new");
		} else {
			model.addAttribute("validation", true);
			return new ModelAndView("back.booking.new");
		}

	}

	/**
	 * Booking new confirm.
	 *
	 * @param patient
	 *            the patient
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/booking-new", method = RequestMethod.POST)
	public ModelAndView bookingNewConfirm(@Valid @ModelAttribute("patient") PatientInfo patient, BindingResult result,
			ModelMap model) {
		LOG.info("[Start] Booking New Confirm");
		LOG.debug("[UserId] " + getSysUser().getLoginId());
		patient.setMapReminderTime(getReminderTimeMap());
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		bookingInfo.setPatientName(patient.getName());
		bookingInfo.setPatientFurigana(patient.getNameFurigana());
		bookingInfo.setEmail(patient.getEmail());
		bookingInfo.setPhoneNumber(patient.getPhoneNumber());
		if (!StringUtils.isBlank(patient.getEmail())) {
			bookingInfo.setEmail(patient.getEmail());
		}
		bookingInfo.setPatientGender(patient.getGender());
		bookingInfo.setPatientBitrhday(MssDateTimeUtil.dateFromString(patient.getDob(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		bookingInfo.setCardNumber(patient.getCardNumber());
		bookingInfo.setReminderTime(patient.getReminderTime());

		boolean isBookingVaccine = false;

		ReservationModel reservationModel = null;
		try {
			reservationModel = this.bookingService.savePatientInfo(bookingInfo, MssContextHolder.getReservationMode(),MssContextHolder.getHospitalId(),
					true, this.getUser().getMasterProfileId(), null);
			// If Booking vaccine
			if (patient.getUserId() != null && patient.getVaccineId() != null && patient.getChildId() != null
					&& patient.getTimeUsing() != null) {
				VaccineChildHistoryModel vaccineChildHistoryModel = new VaccineChildHistoryModel();
				vaccineChildHistoryModel.setReservationId(reservationModel.getReservationId());
				vaccineChildHistoryModel.setChildId(patient.getChildId());
				vaccineChildHistoryModel.setVaccineId(patient.getVaccineId());
				vaccineChildHistoryModel.setHospitalName(reservationModel.getHospitalName());
				vaccineChildHistoryModel.setLoginHospitalId(getSysUser().getHospitalId());
				Timestamp injectedDate = MssDateTimeUtil.convertStringToTimestamp(
						bookingInfo.getReservationDate() + bookingInfo.getReservationTime(),
						DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM);
				if (injectedDate == null) {
					this.addNotification(
							new NotificationModel(NotificationType.ERROR, this.getText("general.msg.booking.failed")));
					return new ModelAndView(new RedirectView("booking-vaccine"));
				} else {
					vaccineChildHistoryModel.setInjectedDate(injectedDate);
				}
				vaccineChildHistoryModel.setInjectedNo(Integer.valueOf(patient.getTimeUsing()));
				// Get Vaccine_hospital
				VaccineHospitalModel vaccineHospitalModel = this.vaccineHospitalService
						.findByHospitalIdVaccineId(getSysUser().getHospitalId(), patient.getVaccineId());
				vaccineChildHistoryModel.setVaccineHospitalId(vaccineHospitalModel.getVaccineHospitalId());
				this.vaccineChildHistoryService.save(vaccineChildHistoryModel);
				isBookingVaccine = true;
			}
			if (reservationModel != null) {
				LOG.debug("Booking New Confirm with " + reservationModel.toString());
				Integer doctorId = reservationModel.getDoctorId();
				String checkDate = reservationModel.getReservationDate();
				String startTime = reservationModel.getReservationTime();
				Integer deptId = reservationModel.getDeptId();
				Integer hospitalId = reservationModel.getHospitalId();
				// check doctor schedule for this reservation
				DoctorScheduleModel dsm = this.doctorScheduleService
						.getByDoctorSchedulePK(new DoctorSchedulePK(doctorId, checkDate, startTime));
				// doctor schedule is not initialized
				if (dsm == null) {
					// create a default doctor schedule with kpi 0
					dsm = createDefaultDoctorSchedule(doctorId, checkDate, startTime, deptId, hospitalId);
					// get end time by start time and department
					dsm.setEndTime(
							this.departmentScheduleService.getEndTimeByStartTimeAndDepartment(startTime, deptId));
					this.doctorScheduleService.addDoctorSchedule(dsm);
				} else {// doctor schedule is initialized
						// if doctor schedule is inactive, activate and change
						// kpi to 0
					if (dsm.getActiveFlg().equals(ActiveFlag.INACTIVE.toInt())) {
						dsm.setActiveFlg(ActiveFlag.ACTIVE.toInt());
						dsm.setKpi(Integer.valueOf(0));
						this.doctorScheduleService.updateDoctorSchedule(dsm);
					}
				}
				// send email to patient after finish booking
				MailInfo mailInfo = createMailInfoFinishBooking(reservationModel);
				List<String> toList = new ArrayList<>();
				if (!StringUtils.isBlank(reservationModel.getEmail())) {
					toList.add(reservationModel.getEmail());
					mailService.sendMail(MailCode.BOOKING_NEW_COMPLETED.toString(), this.getLanguage(), mailInfo,
							toList, reservationModel.getPatientId(), reservationModel.getReservationId(),
							MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
							MssContextHolder.getDomainName());
				}
				bookingInfo.setReservationCode(reservationModel.getReservationCode());
			} else {
				LOG.warn("[WARN] Booking New Confirm. reservationModel is null");
				this.addNotification(
						new NotificationModel(NotificationType.ERROR, this.getText("general.msg.booking.failed")));
				return new ModelAndView("select-department");
			}
		} catch (Exception e) {
			LOG.error("Error while save reservation. Exception: " + e.getMessage());
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("general.msg.booking.failed")));
			return new ModelAndView(new RedirectView("select-department"));
		}
		model.addAttribute("mapReminderTime", this.getReminderTimeMap());
		model.addAttribute("reservation", reservationModel);
		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("general.msg.booking_new.success")));
		LOG.info("[End] Booking New Confirm");
		if (isBookingVaccine == true) {
			return new ModelAndView(new RedirectView("booking-vaccine"));
		}
		return new ModelAndView(new RedirectView("select-time"));
	}

	private MailInfo createMailInfoFinishBooking(ReservationModel reservationModel) throws Exception {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setPatientName(reservationModel.getPatientName());
		mailInfo.setHospitalName(reservationModel.getHospitalName());
		mailInfo.setReservationCode(reservationModel.getReservationCode());
		mailInfo.setDepartmentName(reservationModel.getDeptName());
		mailInfo.setReservationDatetime(
				reservationModel.getFormattedReservationDate() + " " + reservationModel.getFormattedReservationTime());
		mailInfo.setReminderTime(getText(ReminderTime.newInstance(reservationModel.getReminderTime()).toText()));
		mailInfo.setLinkAuthorizedEmail(
				MssContextHolder.getDomainName() + this.getText("be030.link.search.reservation"));
		return mailInfo;
	}

	private DoctorScheduleModel createDefaultDoctorSchedule(Integer doctorId, String checkDate, String startTime,
			Integer deptId, Integer hospitalId) {
		DoctorScheduleModel dsm;
		dsm = new DoctorScheduleModel();
		dsm.setDoctorId(doctorId);
		dsm.setCheckDate(checkDate);
		dsm.setStartTime(startTime);
		dsm.setDeptId(deptId);
		dsm.setHospitalId(hospitalId);
		dsm.setKpi(Integer.valueOf(0));
		return dsm;
	}

	/**
	 * Get reservation info and display with given reservation id.
	 *
	 * @param reservationId
	 *            the reservation id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/booking-info", method = RequestMethod.GET)
	public ModelAndView bookingInfo(@RequestParam("id") String reservationId, ModelMap model) throws Exception {
		LOG.info("[Start] booking info");
		return createBookingInfo(reservationId, null, model);
	}

	/**
	 * Booking info for search booking.
	 *
	 * @param reservationId
	 *            the reservation id
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.SEARCH_RESERVATION })
	@RequestMapping(value = "/booking-info-for-search", method = RequestMethod.GET)
	public ModelAndView bookingInfoForSearchBooking(@RequestParam("id") String reservationId,
			@RequestParam(value = "vaccineChildId", required = false) String vaccineChildId, ModelMap model,
			HttpSession session) throws Exception {
		LOG.info("[Start] booking info");
		session.setAttribute("bookingForSearch", true);
		model.addAttribute("bookingForSearch", true);
		return createBookingInfo(reservationId, vaccineChildId, model);
	}

	/**
	 * Creates the booking info.
	 *
	 * @param reservationId
	 *            the reservation id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	private ModelAndView createBookingInfo(String reservationId, String vaccineChildId, ModelMap model)
			throws Exception {
		LOG.debug("Booking info. reservationId = " + reservationId);
		ReservationModel reservation;
		PatientModel patient;
		if (StringUtils.isBlank(reservationId) || !NumberUtils.isDigits(reservationId)) {
			LOG.warn("[WARN] The reservation is blank or not an integer.");
			return new ModelAndView(new RedirectView("select-department"));
		}
		if (MssContextHolder.isKcck()) {
			reservation = this.bookingService.findKcckReservationById(Integer.valueOf(reservationId));
			
			model.addAttribute("isKcck", true);
		} else {
			reservation = this.bookingService.findReservationById(Integer.valueOf(reservationId));
		}
		if (reservation == null) {
			LOG.warn("[WARN] The reservation not found.");
			return new ModelAndView(new RedirectView("search-booking"));
		}else{
			//Check time booking
//			String reservationDate = reservation.getReservationDate();
//			String reservationTime = reservation.getReservationTime();
//			LocalDateTime selectedDateTime = LocalDateTime.parse(reservationDate + reservationTime,
//					DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
//			ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
//			OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
//			OffsetDateTime now = Instant.now().atOffset(zoneOffset);
//			if (checkTime.isBefore(now))  {
//				model.addAttribute("isNotAvailable", true);
//			}
			
			patient = this.bookingService.findPatientById(reservation.getPatientId());
			if(patient.getGender()!=null){
			if (patient.getGender().equals("M")) patient.setGenderText(this.getText("general.label.male"));
			else patient.setGenderText(this.getText("general.label.female"));
			}
			patient.setDob(MssDateTimeUtil.dateToString(patient.getBirthDay(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
			}
		
		// If change booking for vaccine
		if (!StringUtils.isBlank(vaccineChildId) && NumberUtils.isNumber(vaccineChildId)) {
			VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService
					.findById(Integer.valueOf(vaccineChildId));
			VaccineModel vaccineModel = this.vaccineService.findById(vaccineChildHistoryModel.getVaccineId());
			UserChildModel userChildModel = this.userChildService.findById(vaccineChildHistoryModel.getChildId());
			BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
			if (bookingInfo == null) {
				bookingInfo = new BookingInfo();
				MssContextHolder.setBookingInfo(bookingInfo);
			}
			bookingInfo.setVaccineChildHistoryId(Integer.valueOf(vaccineChildId));
			bookingInfo.setVaccineId(vaccineModel.getVaccineId());
			bookingInfo.setVaccineName(vaccineModel.getVaccineName());
			bookingInfo.setTimesUsing(String.valueOf(vaccineChildHistoryModel.getInjectedNo()));
			bookingInfo.setChildId(userChildModel.getChildId());
			bookingInfo.setChildName(userChildModel.getChildName());
			bookingInfo.setDob(userChildModel.getDob());
			bookingInfo.setSex(userChildModel.getSex());

			model.addAttribute("isChangeBookingVaccine", true);
			model.addAttribute("bookingInfo", bookingInfo);
		}
		
		
		model.addAttribute("mapReminderTime", this.getReminderTimeMap());
		model.addAttribute("reservation", reservation);
		model.addAttribute("patient", patient);
		LOG.info("[End] booking info");
		return new ModelAndView("back.booking.info");
	}

	/**
	 * Cancel a booking with given reservation id.
	 *
	 * @param reservationId
	 *            the reservation id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/cancel-booking", method = RequestMethod.POST)
	public ModelAndView cancelBooking(@RequestParam("id") String reservationId,
			@RequestParam(value = "vaccineChildId", required = false) String vaccineChildId,
			@RequestParam(value = "patientCode", required = false) String patientCode, ModelMap model,
			HttpServletRequest request, HttpSession session) throws Exception {
		LOG.info("[Start] cancel booking");
		LOG.debug("[UserId] User cancel booking: " + getSysUser().getLoginId());
		if (StringUtils.isBlank(reservationId) || !NumberUtils.isDigits(reservationId)) {
			LOG.warn("[WARN] Cancel booking. The reservation id is blank or not an integer.");
			return new ModelAndView(new RedirectView("select-department"));
		}
		try {
			ReservationModel reservationModel;
			if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
				reservationModel = this.bookingService.findKcckReservationById(Integer.valueOf(reservationId));
			} else {
				reservationModel = this.bookingService.findReservationById(Integer.valueOf(reservationId));
			}
			if (reservationModel == null) {
				LOG.warn("[WARN] Cannot get reservation by reservation Id: " + reservationId);
				return new ModelAndView(new RedirectView("select-department"));
			} else if (reservationModel.getReservationDate() == null || reservationModel.getReservationTime() == null) {
				LOG.warn("[WARN] Reservation date or reservation time is null. Reservation Id: " + reservationId);
				return new ModelAndView(new RedirectView("select-department"));
			} else {
				String departmentCode = reservationModel.getDepartmentCode();
				String date = reservationModel.getReservationDate();
				String time = reservationModel.getReservationTime();
				LocalDateTime selectedDateTime = LocalDateTime.parse(date + time,
						DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
				ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
				OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
				OffsetDateTime now = Instant.now().atOffset(zoneOffset);
				if (checkTime.isAfter(now))  {
					// TODO
					if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
						KcckReservationModel kcckCancelModel = new KcckReservationModel();
						kcckCancelModel.setReservation_code(reservationModel.getReservationCode());
						kcckCancelModel.setPatient_code(reservationModel.getCardNumber());
						kcckCancelModel.setHosp_code(MssContextHolder.getHospCode());
						kcckCancelModel.setLocale(MssContextHolder.getLocale().toString());
						KcckReservationModel kcckCancelReservationModel = kcckBookingService
								.cancelReservation(kcckCancelModel);
						if (kcckCancelReservationModel.getReservation_code() == null) {
							this.addNotification(new NotificationModel(NotificationType.ERROR,
									this.getText("general.msg.cancel.fail")));
							return new ModelAndView(
									new RedirectView("booking-info-for-search?id=" + reservationModel.getDeptId()));
						}
					}
					reservationModel = this.bookingService.cancelReservation(Integer.valueOf(reservationId));
					LOG.debug("[BE] Booking cancel. " + reservationModel.toString());
					// If cancle booking vaccine
					if (!StringUtils.isBlank(vaccineChildId) && NumberUtils.isNumber(vaccineChildId)) {
						VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService
								.findById(Integer.valueOf(vaccineChildId));
						vaccineChildHistoryModel.setActiveFlg(ActiveFlag.INACTIVE.toInt());
						this.vaccineChildHistoryService.save(vaccineChildHistoryModel);
					}
					LOG.debug("Cancel booking with reservation: " + reservationModel.toString());
					// send email to patient after finish canceling
					MailInfo mailInfo = new MailInfo();
					mailInfo.setPatientName(reservationModel.getPatientName());					
					mailInfo.setHospitalName(reservationModel.getHospitalName());
					mailInfo.setReservationCode(reservationModel.getReservationCode());
					mailInfo.setDepartmentName(reservationModel.getDeptName());
					mailInfo.setDoctorName(reservationModel.getDoctorName());
					mailInfo.setPatientCode(patientCode);
					mailInfo.setReservationDatetime(reservationModel.getFormattedReservationDate() + " "
							+ reservationModel.getFormattedReservationTime());
					if (reservationModel.getEmail() != null && !"".equals(reservationModel.getEmail())) {
						List<String> toList = new ArrayList<>();
						toList.add(reservationModel.getEmail());
						if(!StringUtils.isEmpty(departmentCode) && MssConfiguration.getInstance().getApiKcckVaccineCode().equals(departmentCode)){
							UserModel userMode = this.userService.getActiveUserByEmail(reservationModel.getEmail(), MssContextHolder.getHospitalId());
							mailInfo.setPatientName(userMode.getName());
						}
						mailService.sendMail(MailCode.CANCEL_RESERVATION.toString(), this.getLanguage(), mailInfo,
								toList, reservationModel.getPatientId(), reservationModel.getReservationId(),
								MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
								MssContextHolder.getDomainName());
					}
					this.addNotification(new NotificationModel(NotificationType.SUCCESS,
							this.getText("general.msg.cancel.success")));
					if (session.getAttribute("bookingForSearch") != null) {
						session.removeAttribute("bookingForSearch");
						return new ModelAndView(new RedirectView("search-booking"));
					}
					LOG.info("[End] cancel booking");
					return new ModelAndView(new RedirectView("select-time?deptId=" + reservationModel.getDeptId()));
				} else {
					this.addNotification(new NotificationModel(NotificationType.ERROR,
							this.getText("general.msg.cannot_delete_past_time")));
					return new ModelAndView(new RedirectView(request.getHeader("Referer")));
				}
			}
		} catch (EntityNotFoundException ex) {
			LOG.error("Cancel booking. The reservation not found.");
			return new ModelAndView(new RedirectView("select-department"));
		}
		// return new ModelAndView(new RedirectView("select-department"));
	}

	/**
	 * Change booking time.
	 *
	 * @param reservationId
	 *            the reservation id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/change-booking-time", method = RequestMethod.GET)
	public ModelAndView changeBookingTime(@RequestParam("id") String reservationId, ModelMap model) {
		LOG.info("[Start] change booking time.");
		LOG.debug("Change booking time. reservationId=" + reservationId);
		return createChangeBookingTime(reservationId, null, model);
	}

	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.SEARCH_RESERVATION })
	@RequestMapping(value = "/change-booking-time-for-search", method = RequestMethod.GET)
	public ModelAndView changeBookingTimeForSearch(@RequestParam("id") String reservationId,
			@RequestParam(value = "vaccineChildId", required = false) String vaccineChildId, ModelMap model) {
		LOG.info("[Start] change booking time.");
		LOG.debug("Change booking time. reservationId=" + reservationId);
		model.addAttribute("bookingForSearch", true);
		return createChangeBookingTime(reservationId, vaccineChildId, model);
	}

	/**
	 * Creates the change booking time.
	 *
	 * @param reservationId
	 *            the reservation id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	private ModelAndView createChangeBookingTime(String reservationId, String vaccineChildId, ModelMap model) {
		if (StringUtils.isBlank(reservationId) || !NumberUtils.isDigits(reservationId)) {
			LOG.warn("[WARN] change booking time. The reservation id is blank or not an integer.");
			return new ModelAndView("redirect:select-department");
		}
		ReservationModel reservation;
		PatientModel patient;
		if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			reservation = this.bookingService.findKcckReservationById(Integer.valueOf(reservationId));
			model.addAttribute("isKcck", true);
		} else {
			reservation = this.bookingService.findReservationById(Integer.valueOf(reservationId));
		}
		if (reservation == null) {
			LOG.warn("[WARN] change booking time. The reservation not found.");
			return new ModelAndView("redirect:select-department");
		}else{
			patient = this.bookingService.findPatientById(reservation.getPatientId());
			if (patient.getGender() != null) {
				if (patient.getGender().equals("M"))
					patient.setGenderText(this.getText("general.label.male"));
				else
					patient.setGenderText(this.getText("general.label.female"));
			}
			patient.setDob(MssDateTimeUtil.dateToString(patient.getBirthDay(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		}
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (bookingInfo == null) {
			bookingInfo = new BookingInfo();
			MssContextHolder.setBookingInfo(bookingInfo);
		}
		createBooingInfoForChange(reservation, bookingInfo);
		// If change booking for vaccine
		if (!StringUtils.isBlank(vaccineChildId) && NumberUtils.isNumber(vaccineChildId)) {
			model.addAttribute("isChangeBookingVaccine", true);
			model.addAttribute("bookingInfo", bookingInfo);
		}
		model.addAttribute("mapReminderTime", this.getReminderTimeMap());
		model.addAttribute("reservation", reservation);
		model.addAttribute("patient", patient);
		LOG.info("[End] change booking time.");
		return new ModelAndView("back.booking.change.time");
	}

	/**
	 * Creates the booing info for change.
	 *
	 * @param reservation
	 *            the reservation
	 * @param bookingInfo
	 *            the booking info
	 */
	private void createBooingInfoForChange(ReservationModel reservation, BookingInfo bookingInfo) {
		bookingInfo.setDoctorId(reservation.getDoctorId());
		bookingInfo.setDoctorName(reservation.getDeptName());
		bookingInfo.setCardNumber(reservation.getCardNumber());
		bookingInfo.setDeptId(reservation.getDeptId());
		bookingInfo.setDeptName(reservation.getDeptName());
		bookingInfo.setEmail(reservation.getEmail());
		bookingInfo.setPatientId(reservation.getPatientId());
		bookingInfo.setPatientName(reservation.getPatientName());
		bookingInfo.setPatientFurigana(reservation.getNameFurigana());
		bookingInfo.setPhoneNumber(reservation.getPhoneNumber());
		bookingInfo.setReminderTime(reservation.getReminderTime());
		bookingInfo.setReservationCode(reservation.getReservationCode());
		bookingInfo.setReservationDate(reservation.getReservationDate());
		bookingInfo.setReservationTime(reservation.getReservationTime());
		bookingInfo.setReservationId(reservation.getReservationId());
	}

	/**
	 * Change booking time confirm.
	 *
	 * @param reservationId
	 *            the reservation id
	 * @param date
	 *            the date
	 * @param time
	 *            the time
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/change-booking-time-confirm", method = RequestMethod.GET)
	public ModelAndView changeBookingTimeConfirm(@RequestParam("date") String date, @RequestParam("time") String time,
			ModelMap model, HttpSession session) throws Exception {
		LOG.info("[Start] change booking time confirm.");
		LOG.debug("Change booking time confirm. date=" + date + " ;time=" + time);
		return createChangeBookingTimeConfirm(date, time, null, model, session);
	}

	/**
	 * Change booking time for search confirm.
	 *
	 * @param date
	 *            the date
	 * @param time
	 *            the time
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.SEARCH_RESERVATION })
	@RequestMapping(value = "/change-booking-time-for-search-confirm", method = RequestMethod.GET)
	public ModelAndView changeBookingTimeForSearchConfirm(@RequestParam("date") String date,
			@RequestParam("time") String time,
			@RequestParam(value = "vaccineChildId", required = false) String vaccineChildId, ModelMap model,
			HttpSession session) throws Exception {
		LOG.info("[Start] change booking time confirm.");
		LOG.debug("Change booking time confirm. date=" + date + " ;time=" + time);
		session.setAttribute("bookingForSearch", true);
		return createChangeBookingTimeConfirm(date, time, vaccineChildId, model, session);
	}

	/**
	 * Creates the change booking time confirm.
	 *
	 * @param date
	 *            the date
	 * @param time
	 *            the time
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	private ModelAndView createChangeBookingTimeConfirm(String date, String time, String vaccineChildId, ModelMap model,
			HttpSession session) throws Exception {
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		if (bookingInfo == null) {
			LOG.info("Session time out.");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("general.msg.session_timeout")));
			return new ModelAndView(new RedirectView("select-department"));
		}
		Date selectedDateTime = MssDateTimeUtil.dateFromString(date + time,
				DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM);
		Date now = new Date();
		// if (selectedDateTime.before(now)) {
		// LOG.info("Cannot select the time in the past.");
		// this.addNotification(new NotificationModel(NotificationType.ERROR,
		// this.getText("general.msg.cannot_select_past_time")));
		// return new ModelAndView(new
		// RedirectView("change-booking-time-for-search?id=" +
		// bookingInfo.getReservationId()));
		// }
		// Validate if change booking vaccine
		if (!StringUtils.isBlank(vaccineChildId) && NumberUtils.isNumber(vaccineChildId)) {
			String resultValidate = validateBookingVaccine(bookingInfo.getVaccineId(), bookingInfo.getChildId(),
					selectedDateTime);
			if (!StringUtils.isBlank(resultValidate)) {
				LOG.info("Cannot select the time in the past.");
				this.addNotification(new NotificationModel(NotificationType.ERROR, this.getText(resultValidate)));
				return new ModelAndView(
						new RedirectView("change-booking-time-for-search?id=" + bookingInfo.getReservationId()
								+ "&vaccineChildId=" + bookingInfo.getVaccineChildHistoryId()));
			}
			model.addAttribute("isChangeBookingVaccine", true);
			model.addAttribute("bookingInfo", bookingInfo);
		}

		bookingInfo.setReservationDate(date);
		bookingInfo.setReservationTime(time);
		ReservationModel reservation = createReservationForChange(bookingInfo);
		PatientModel patient = this.bookingService.findPatientById(bookingInfo.getPatientId());
		if(patient.getGender()!=null){
			if (patient.getGender().equals("M")) patient.setGenderText(this.getText("general.label.male"));
			else patient.setGenderText(this.getText("general.label.female"));
		}
			patient.setDob(MssDateTimeUtil.dateToString(patient.getBirthDay(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		
		model.addAttribute("reservation", reservation);
		model.addAttribute("patient", patient);
		model.addAttribute("mapReminderTime", this.getReminderTimeMap());
		// save to session
		session.setAttribute("reservation", reservation);
		LOG.info("[End] change booking time confirm.");
		return new ModelAndView("back.booking.change.time.confirm");
	}

	/**
	 * Creates the reservation for change.
	 *
	 * @param bookingInfo
	 *            the booking info
	 * @return the reservation model
	 */
	private ReservationModel createReservationForChange(BookingInfo bookingInfo) {
		ReservationModel reservation = new ReservationModel();
		reservation.setPatientName(bookingInfo.getPatientName());
		reservation.setNameFurigana(bookingInfo.getPatientFurigana());
		reservation.setPhoneNumber(bookingInfo.getPhoneNumber());
		reservation.setEmail(bookingInfo.getEmail());
		reservation.setCardNumber(bookingInfo.getCardNumber());
		reservation.setDeptName(bookingInfo.getDeptName());
		reservation.setDoctorName(bookingInfo.getDoctorName());
		reservation.setReservationDate(bookingInfo.getReservationDate());
		reservation.setReservationTime(bookingInfo.getReservationTime());
		reservation.setReservationId(bookingInfo.getReservationId());
		reservation.setReminderTime(bookingInfo.getReminderTime());
		return reservation;
	}

	/**
	 * Save booking change.
	 * 
	 * @param timeModel
	 *            the time model
	 * @return the map
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@RequestMapping(value = "/save-change-booking-time", method = RequestMethod.POST)
	public ModelAndView saveChangeBookingTime(
			@RequestParam(value = "vaccineChildId", required = false) String vaccineChildId, HttpSession session)
					throws Exception {
		LOG.info("[Start] Save booking change.");
		ModelAndView mav = new ModelAndView();
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();
		ReservationModel sessionReservation = (ReservationModel) session.getAttribute("reservation");
		// clear session
		session.removeAttribute("reservation");
		if (bookingInfo == null) {
			BookingInfo sessionBookingInfo = new BookingInfo();
			sessionBookingInfo.setDeptId(sessionReservation.getDeptId());
			MssContextHolder.setBookingInfo(sessionBookingInfo);
		}
		if (bookingInfo == null || sessionReservation == null
				|| !bookingInfo.getReservationId().toString().equals(sessionReservation.getReservationId().toString())
				|| !bookingInfo.getReservationDate().equals(sessionReservation.getReservationDate())
				|| !bookingInfo.getReservationTime().equals(sessionReservation.getReservationTime())) {
			LOG.info("Session time out.");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("general.msg.change_booking.failed")));
			// initialize dept id for booking info in session

			mav.setView(new RedirectView("select-time"));
		} else {
			ReservationModel reservation;
			if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
				reservation = this.bookingService.findKcckReservationById(bookingInfo.getReservationId());
			} else {
				reservation = this.bookingService.findReservationById(bookingInfo.getReservationId());
			}
			if (reservation == null) {
				LOG.warn("[WARN] Save booking change. Cannot found reservation with id ="
						+ bookingInfo.getReservationId());
				this.addNotification(new NotificationModel(NotificationType.ERROR,
						this.getText("general.msg.change_booking.failed")));
				mav.setView(new RedirectView("select-time"));
			} else {
				reservation.setReservationDate(bookingInfo.getReservationDate());
				reservation.setReservationTime(bookingInfo.getReservationTime());

				if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
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
					LOG.debug("[BE]Send Change Reservation to KCCK " + kcckModel.toString());
					KcckReservationModel kcckReservationModel = kcckBookingService.changeReservation(kcckModel);
					LOG.debug("[BE]Reservation Info from KCCK " + kcckReservationModel.toString());
					reservation.setReservationStatus(ReservationStatus.BOOKING_COMPLETED.toInt());
				}

				this.bookingService.updateReservation(reservation);
				// if change booking vaccine. Update Vaccine_Child_History
				if (!StringUtils.isBlank(vaccineChildId) && NumberUtils.isNumber(vaccineChildId)) {
					VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService
							.findById(Integer.valueOf(vaccineChildId));
					if (vaccineChildHistoryModel != null) {
						Timestamp injectedDate = MssDateTimeUtil.convertStringToTimestamp(
								reservation.getReservationDate() + reservation.getReservationTime(),
								DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM);
						vaccineChildHistoryModel.setInjectedDate(injectedDate);
						this.vaccineChildHistoryService.save(vaccineChildHistoryModel);
					}
				}
				LOG.debug("Save booking change with " + reservation.toString());
				// send email to patient after finish changing booking
				MailInfo mailInfo = createMailInfoForChange(reservation);
				List<String> toList = new ArrayList<>();
				if (!StringUtils.isBlank(reservation.getEmail())) {
					toList.add(reservation.getEmail());
					mailService.sendMail(MailCode.BOOKING_CHANGE_COMPLETED.toString(), this.getLanguage(), mailInfo,
							toList, reservation.getPatientId(), reservation.getReservationId(),
							MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
							MssContextHolder.getDomainName());
				}
				if (session.getAttribute("bookingForSearch") != null
						&& (boolean) session.getAttribute("bookingForSearch")) {
					LOG.info("Redirect to search-booking screen");
					session.removeAttribute("bookingForSearch");
					this.addNotification(new NotificationModel(NotificationType.SUCCESS,
							this.getText("general.msg.change_booking.success")));
					mav.setView(new RedirectView("search-booking"));
				} else {
					LOG.info("Redirect to select-time screen");
					this.addNotification(new NotificationModel(NotificationType.SUCCESS,
							this.getText("general.msg.change_booking.success")));
					mav.setView(new RedirectView("select-time"));
				}
			}
		}
		LOG.info("[End] Save booking change.");
		return mav;
	}

	private MailInfo createMailInfoForChange(ReservationModel reservation) throws Exception {
		MailInfo mailInfo = new MailInfo();
		if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			mailInfo.setPatientCode(reservation.getCardNumber());
		} else {
			PatientModel patient = bookingService.findPatientById(reservation.getPatientId());
			if (patient.getCardNumber() == null) {
				mailInfo.setPatientCode("");
			} else {
				mailInfo.setPatientCode(patient.getCardNumber());
			}
		}
		mailInfo.setPatientName(reservation.getPatientName());
		mailInfo.setHospitalName(MssContextHolder.getHospitalName());
		mailInfo.setReservationCode(reservation.getReservationCode());
		mailInfo.setDepartmentName(reservation.getDeptName());
		mailInfo.setDoctorName(reservation.getDoctorName());
		mailInfo.setReservationDatetime(
				reservation.getFormattedReservationDate() + " " + reservation.getFormattedReservationTime());
		mailInfo.setReminderTime(getText(ReminderTime.newInstance(reservation.getReminderTime()).toText()));
		mailInfo.setLinkAuthorizedEmail(
				MssContextHolder.getDomainName() + this.getText("be030.link.search.reservation"));
		return mailInfo;
	}

	/**
	 * Booking change doctor.
	 *
	 * @param reservationId
	 *            the reservation id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/booking-change-doctor", method = RequestMethod.GET)
	public ModelAndView bookingChangeDoctor(@RequestParam("id") String reservationId, ModelMap model,
			HttpSession session) {
		LOG.info("[Start] booking change doctor");
		if (StringUtils.isBlank(reservationId) || !NumberUtils.isDigits(reservationId)) {
			LOG.warn("[WARN] Booking change doctor. The reservation id is blank or not an integer.");
			return new ModelAndView(new RedirectView("booking-info?id=" + reservationId));
		}
		ReservationModel reservation;
		DoctorModel doctorModel;
		List<DoctorModel> listDoctor;
		if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			/* KCCK */
			reservation = this.bookingService.findKcckReservationById(Integer.valueOf(reservationId));
			// Check kcck doctor in department
			doctorModel = this.kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(),
					reservation.getDoctorId(), reservation.getDepartmentCode());
			listDoctor = this.kcckDoctorService.getListKcckDoctor(MssContextHolder.getHospCode(),
					reservation.getDepartmentCode());
		} else {
			reservation = this.bookingService.findReservationById(Integer.valueOf(reservationId));
			// Check doctor in department
			doctorModel = this.doctorService.getDoctorByDoctorId(reservation.getDoctorId());
			listDoctor = this.doctorService.findDoctorsByDepartment(reservation.getDeptId());
		}
		if (reservation == null) {
			LOG.warn("[WARN] Booking change doctor. The reservation not found.");
			return new ModelAndView(new RedirectView("booking-info?id=" + reservationId));
		}

		if (listDoctor != null && !listDoctor.isEmpty()) {
			for (DoctorModel dm : listDoctor) {
				if (doctorModel.getDoctorId().equals(dm.getDoctorId())) {
					listDoctor.remove(dm);
					break;
				}
			}
		}
		if (listDoctor == null || listDoctor.isEmpty()) {
			LOG.warn("[warn] booking change doctor. List doctor is null");
			this.addNotification(new NotificationModel(NotificationType.ERROR, this.getText("be005.msg.no.doctor")));
			return new ModelAndView(new RedirectView("booking-info?id=" + reservationId));
		}

		// Check time
		Date selectedDateTime = MssDateTimeUtil.dateFromString(
				reservation.getReservationDate() + reservation.getReservationTime(),
				DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM);
		LOG.debug("Booking change doctor. selectedDateTime=" + selectedDateTime);
		Date now = new Date();
		if (!selectedDateTime.after(now)) {
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be005.msg.timeslot.is.pass")));
			return new ModelAndView(new RedirectView("booking-info?id=" + reservationId));
		}
		// get mailTemplateModel List
		// List<MailTemplateModel> mailTemplateList =
		// this.mailService.findAllTemplateCustomize(MssContextHolder.getHospitalId());
		List<MailTemplateModel> mailTemplateList = this.mailService
				.findByHospIdAndLocale(MssContextHolder.getHospitalId(), MssContextHolder.getLocale().toString());
		model.addAttribute("listDoctor", listDoctor);
		model.addAttribute("mailTemplateList", mailTemplateList);
		model.addAttribute("reservation", reservation);
		session.setAttribute("reservation", reservation);
		LOG.info("[End] booking change doctor");
		return new ModelAndView("back.booking.change.doctor");
	}

	/**
	 * Booking change doctor confirm.
	 *
	 * @param doctorId
	 *            the doctor id
	 * @param templateCode
	 *            the template code
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/booking-change-doctor-confirm", method = RequestMethod.GET)
	public ModelAndView bookingChangeDoctorConfirm(@RequestParam("doctorId") String doctorId,
			@RequestParam("templateCode") String templateCode, ModelMap model, HttpSession session) {
		LOG.info("[Start] Booking change doctor confirm.");
		if (StringUtils.isBlank(doctorId) || !NumberUtils.isDigits(doctorId) || StringUtils.isBlank(templateCode)) {
			LOG.warn("doctorId and templateCode is null");
			return new ModelAndView(new RedirectView("back.booking.change.doctor"));
		}
		DoctorModel doctorModel;
		ReservationModel reservation = (ReservationModel) session.getAttribute("reservation");
		if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			doctorModel = this.kcckDoctorService.findKcckDoctorById(MssContextHolder.getHospCode(),
					Integer.valueOf(doctorId), reservation.getDepartmentCode());
		} else {
			doctorModel = this.doctorService.getDoctorByDoctorId(Integer.valueOf(doctorId));
		}
		MailTemplateModel mailTemplateModel = this.mailService.getMailTemplate(templateCode, getLocale().getLanguage(),
				MssContextHolder.getHospitalId());

		BookingTimeModel bookingTimeModel = new BookingTimeModel();
		bookingTimeModel.setReservationId(String.valueOf(reservation.getReservationId()));
		bookingTimeModel.setDoctorId(doctorModel.getDoctorId());
		bookingTimeModel.setDoctorName(doctorModel.getName());
		bookingTimeModel.setTemplateCode(templateCode);
		bookingTimeModel.setTemplateName(mailTemplateModel.getSubject());

		model.addAttribute("reservation", reservation);

		LOG.info("[End] Booking change doctor confirm.");
		return new ModelAndView("back.booking.change.doctor.confirm", "bookingTimeModel", bookingTimeModel);
	}

	/**
	 * Save booking change doctor.
	 *
	 * @param bookingTimeModel
	 *            the booking time model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/booking-change-doctor-save", method = RequestMethod.POST)
	public ModelAndView saveBookingChangeDoctor(@ModelAttribute("bookingTimeModel") BookingTimeModel bookingTimeModel,
			HttpSession session) throws Exception {
		LOG.info("[Start] save change doctor ");
		LOG.debug("[UserID] " + getSysUser().getLoginId());
		ModelAndView mav = new ModelAndView("back.booking.change.doctor.confirm", "bookingTimeModel", bookingTimeModel);
		if (bookingTimeModel == null || StringUtils.isBlank(bookingTimeModel.getReservationId())
				|| bookingTimeModel.getDoctorId() == null || StringUtils.isBlank(bookingTimeModel.getTemplateCode())) {
			LOG.debug("Error: Save change doctor. Session time out.");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be005.msg.change_doctor.failed")));
			return mav;
		}
		ReservationModel reservation;
		if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			reservation = this.bookingService
					.findKcckReservationById(Integer.valueOf(bookingTimeModel.getReservationId()));
		}
		reservation = this.bookingService.findReservationById(Integer.valueOf(bookingTimeModel.getReservationId()));
		if (reservation == null) {
			LOG.debug("Error: save change doctor. The reservation not found.");
			return mav;
		}

		DoctorModel doctorModelNew = this.doctorService.getDoctorByDoctorId(bookingTimeModel.getDoctorId());
		if (doctorModelNew == null) {
			LOG.debug("Error: change doctor. The doctor not found.");
			return mav;
		}

		// get doctor schedules that have reservations
		DoctorSchedulePK doctorSchedulePK = new DoctorSchedulePK(bookingTimeModel.getDoctorId(),
				reservation.getReservationDate(), reservation.getReservationTime());
		DoctorScheduleModel doctorScheduleModel = this.doctorScheduleService.getByDoctorSchedulePK(doctorSchedulePK);
		if (doctorScheduleModel == null) {
			doctorSchedulePK = new DoctorSchedulePK(reservation.getDoctorId(), reservation.getReservationDate(),
					reservation.getReservationTime());
			DoctorScheduleModel doctorScheduleModelOld = this.doctorScheduleService
					.getByDoctorSchedulePK(doctorSchedulePK);
			if (doctorScheduleModelOld == null) {
				LOG.debug("Error: save change doctor. The doctorScheduleModelOld not found.");
				return mav;
			}
			// Create DoctorSchedule new
			doctorScheduleModel = createDoctorScheduleModel(doctorModelNew, doctorScheduleModelOld);
			this.doctorScheduleService.addDoctorSchedule(doctorScheduleModel);
			LOG.debug("Change doctor. Insert " + doctorScheduleModel.toString());

			this.bookingService.updateDoctorForReservation(bookingTimeModel.getDoctorId(),
					reservation.getReservationId());
			LOG.debug("Update doctor_id for " + reservation.toString());
		} else {
			// Update doctorId for reservation
			this.bookingService.updateDoctorForReservation(bookingTimeModel.getDoctorId(),
					reservation.getReservationId());
			LOG.debug("Update doctor_id for " + reservation.toString());
		}

		if (reservation.getEmail() != null) {
			MailInfo mailInfo = createMailInfo(reservation, doctorModelNew.getName());
			List<String> toList = new ArrayList<>();
			toList.add(reservation.getEmail());
			this.mailService.sendMail(bookingTimeModel.getTemplateCode(), MssContextHolder.getUserLanguage(), mailInfo,
					toList, reservation.getPatientId(), reservation.getReservationId(),
					MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
					MssContextHolder.getDomainName());
			LOG.debug("Save change doctor. Send email when change_doctor success. Email=" + reservation.getEmail());
		}

		LOG.info("[End] save change doctor ");
		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("be005.msg.change_doctor.success")));
		session.removeAttribute("reservation");
		return new ModelAndView(new RedirectView("select-time?deptId=" + reservation.getDeptId()));
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Ajax save booking change doctor.
	 *
	 * @param timeModel
	 *            the time model
	 * @param session
	 *            the session
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@RequestMapping(value = "/ajax-save-booking-change-doctor", method = RequestMethod.POST, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSaveBookingChangeDoctor(@RequestBody BookingTimeModel timeModel, HttpSession session) {
		LOG.info("[Start] save change doctor ");
		LOG.debug("[UserID] " + getSysUser().getLoginId());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		try {
			if (timeModel == null || StringUtils.isBlank(timeModel.getReservationId())
					|| timeModel.getDoctorId() == null || StringUtils.isBlank(timeModel.getTemplateCode())) {
				LOG.warn("[WARN] ajax save change doctor. Session time out.");
				builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
						.message(this.getText("be005.msg.change_doctor.failed"));
				return builder.build();
			}
			ReservationModel reservation = this.bookingService
					.findReservationById(Integer.valueOf(timeModel.getReservationId()));
			if (reservation == null) {
				LOG.warn("[WARN] ajax save change doctor. The reservation not found.");
				builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
						.message(this.getText("be005.msg.change_doctor.failed"));
				return builder.build();
			}
			DoctorModel doctorModelNew = this.doctorService.getDoctorByDoctorId(timeModel.getDoctorId());
			if (doctorModelNew == null) {
				LOG.warn("[WARN] ajax save change doctor. The doctor not found.");
				builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
						.message(this.getText("be005.msg.change_doctor.failed"));
				return builder.build();
			}
			// get doctor schedules that have reservations
			DoctorSchedulePK doctorSchedulePK = new DoctorSchedulePK(timeModel.getDoctorId(),
					timeModel.getSelectedDate(), timeModel.getSelectedTime());
			DoctorScheduleModel doctorScheduleModel = this.doctorScheduleService
					.getByDoctorSchedulePK(doctorSchedulePK);
			if (doctorScheduleModel == null) {
				doctorSchedulePK = new DoctorSchedulePK(reservation.getDoctorId(), reservation.getReservationDate(),
						reservation.getReservationTime());
				DoctorScheduleModel doctorScheduleModelOld = this.doctorScheduleService
						.getByDoctorSchedulePK(doctorSchedulePK);
				if (doctorScheduleModelOld == null) {
					LOG.warn("[WARN] ajax save change doctor. The doctorScheduleModelOld not found.");
					builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
							.message(this.getText("be005.msg.change_doctor.failed"));
					return builder.build();
				}
				// Create DoctorSchedule new
				doctorScheduleModel = createDoctorScheduleModel(doctorModelNew, doctorScheduleModelOld);
				this.doctorScheduleService.addDoctorSchedule(doctorScheduleModel);
				LOG.debug("Change doctor. Insert " + doctorScheduleModel.toString());

				this.bookingService.updateDoctorForReservation(timeModel.getDoctorId(), reservation.getReservationId());
				LOG.debug("Update doctor_id for " + reservation.toString());
			} else {
				// Update doctorId for reservation
				this.bookingService.updateDoctorForReservation(timeModel.getDoctorId(), reservation.getReservationId());
				LOG.debug("Update doctor_id for " + reservation.toString());
			}

			if (reservation.getEmail() != null) {
				MailInfo mailInfo = createMailInfo(reservation, doctorModelNew.getName());
				List<String> toList = new ArrayList<>();
				toList.add(reservation.getEmail());
				this.mailService.sendMail(timeModel.getTemplateCode(), MssContextHolder.getUserLanguage(), mailInfo,
						toList, reservation.getPatientId(), reservation.getReservationId(),
						MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
						MssContextHolder.getDomainName());
				LOG.debug("Save change doctor. Send email when change_doctor success. Email=" + reservation.getEmail());
			}

			LOG.info("[End] save change doctor ");
			builder.status(HttpStatus.OK).message(this.getText("be005.msg.change_doctor.success"));
			builder.data("select-time?deptId=" + reservation.getDeptId());
			return builder.build();
		} catch (Exception e) {
			LOG.error("Save change doctor. Error: " + e.getMessage());
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be005.msg.change_doctor.failed"));
			return builder.build();
		}
	}

	/**
	 * Creates the mail info.
	 *
	 * @param reservation
	 *            the reservation
	 * @param doctorModel
	 *            the doctor model
	 * @return the mail info
	 * @throws Exception
	 *             the exception
	 */
	private MailInfo createMailInfo(ReservationModel reservation, String nameDoctorChange) throws Exception {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setPatientName(reservation.getPatientName());
		mailInfo.setHospitalName(reservation.getHospitalName());
		mailInfo.setReservationCode(reservation.getReservationCode());
		mailInfo.setDepartmentName(reservation.getDeptName());
		mailInfo.setDoctorName(reservation.getDoctorName());
		mailInfo.setReservationDatetime(
				reservation.getFormattedReservationDate() + " " + reservation.getFormattedReservationTime());
		mailInfo.setNewDoctorName(nameDoctorChange);
		mailInfo.setLinkAuthorizedEmail(
				MssContextHolder.getDomainName() + this.getText("be030.link.search.reservation"));
		mailInfo.setLinkThankYou(MssContextHolder.getDomainName() + this.getText("be030.link.thank.you"));
		return mailInfo;
	}

	/**
	 * Creates the doctor schedule model.
	 *
	 * @param doctorModel
	 *            the doctor model
	 * @param doctorScheduleModelOld
	 *            the doctor schedule model old
	 * @return the doctor schedule model
	 */
	private DoctorScheduleModel createDoctorScheduleModel(DoctorModel doctorModel,
			DoctorScheduleModel doctorScheduleModelOld) {
		DoctorScheduleModel doctorScheduleModel = new DoctorScheduleModel();
		doctorScheduleModel.setHospitalId(doctorScheduleModelOld.getHospitalId());
		doctorScheduleModel.setDeptId(doctorScheduleModelOld.getDeptId());
		doctorScheduleModel.setDoctorId(doctorModel.getDoctorId());
		doctorScheduleModel.setCheckDate(doctorScheduleModelOld.getCheckDate());
		doctorScheduleModel.setStartTime(doctorScheduleModelOld.getStartTime());
		doctorScheduleModel.setEndTime(doctorScheduleModelOld.getEndTime());
		doctorScheduleModel.setKpi(doctorModel.getKpiAvg());
		return doctorScheduleModel;
	}

	private Map<Integer, String> getReminderTimeMap() {
		Map<Integer, String> map = new HashMap<>();
		for (ReminderTime item : ReminderTime.values()) {
			map.put(item.toKey(), this.getText(item.toText()));
		}
		return map;
	}

	/**
	 * search reservation by condition
	 * 
	 * @param model
	 * @return bbe06 screen
	 */
	@NavigationConfig(group = { NavigationGroup.SEARCH_RESERVATION })
	@RequestMapping("/search-booking")
	public ModelAndView searchBooking(@RequestParam(value = "date", required = false) String dateStr,
			@RequestParam(value = "deptId", required = false) String deptIdStr, ModelMap model) {
		LOG.info("[Start] search booking");
		Map<Integer, String> departments = new LinkedHashMap<>();
		// Map<Integer, String> hospitals = new LinkedHashMap<>();
		Map<Integer, String> lstStatus = new HashMap<Integer, String>();
		for (ReservationStatus r : ReservationStatus.values()) {
			if (!MssContextHolder.isKcck()) {
				if (r.toInt().equals(0)) {
					lstStatus.put(r.toInt(), this.getText(ReservationStatusString.BOOKING_NEW.toString()));
				}
			}
			if (r.toInt().equals(1)) {
				lstStatus.put(r.toInt(), this.getText(ReservationStatusString.BOOKING_COMPLETED.toString()));
			}
			if (r.toInt().equals(2)) {
				lstStatus.put(r.toInt(), this.getText(ReservationStatusString.HEALTH_CHECKING.toString()));
			}
			if (r.toInt().equals(3)) {
				lstStatus.put(r.toInt(), this.getText(ReservationStatusString.FINISH_HEALTH_CHECK.toString()));
			}
			if (r.toInt().equals(4)) {
				lstStatus.put(r.toInt(), this.getText(ReservationStatusString.PATIENT_PENDING.toString()));
			}
			if (r.toInt().equals(5)) {
				lstStatus.put(r.toInt(), this.getText(ReservationStatusString.CANCELLED.toString()));
			}
		}
		/*
		 * HospitalModel hospitalModel =
		 * hospitalService.findHospital(MssContextHolder.getHospitalId()); if
		 * (hospitalModel != null) {
		 * hospitals.put(hospitalModel.getHospitalId(),
		 * hospitalModel.getHospitalName()); }
		 */
		// get all department
		List<DepartmentModel> lstDepartmentModel;
		model.addAttribute("isKcck", false);
		if (MssContextHolder.isKcck()) {
			model.addAttribute("isKcck", true);
			lstDepartmentModel = kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
					MssContextHolder.getLocale().toString());
		} else {
			lstDepartmentModel = departmentService.getAllDepartmentInHospital(MssContextHolder.getHospitalId());
		}
		for (DepartmentModel departmentModel : lstDepartmentModel) {
			departments.put(departmentModel.getDeptId(), departmentModel.getDeptName());
		}
		// model.addAttribute("hospitalList", hospitals);
		model.addAttribute("departmentList", departments);
		model.addAttribute("lstStatus", lstStatus);
		// check date param from other screen
		if (dateStr != null && !StringUtils.isBlank(dateStr)) {
			model.addAttribute("searchDate", MssDateTimeUtil.convertStringDate(dateStr,
					DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		}
		if (!StringUtils.isBlank(deptIdStr) && NumberUtils.isDigits(deptIdStr)) {
			model.addAttribute("vaccineDeptId", Integer.valueOf(deptIdStr));
		}
		LOG.info("[End] search booking");
		return new ModelAndView("back.booking.search", "searchBooking", new ReservationModel());
	}

	/**
	 * Ajax get department list.
	 *
	 * @param hospitalModel
	 *            the hospital model
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-get-department-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetDepartmentList(@RequestBody HospitalModel hospitalModel) {
		LOG.info("[Start] Ajax get department list.");
		Map<Integer, String> departments = new LinkedHashMap<>();
		if (hospitalModel.getHospitalId() != null && hospitalModel.getHospitalId() == 1) {
			List<DepartmentModel> lstDepartmentModel = departmentService
					.getAllDepartmentInHospital(hospitalModel.getHospitalId());
			for (DepartmentModel departmentModel : lstDepartmentModel) {
				departments.put(departmentModel.getDeptId(), departmentModel.getDeptName());
			}
		} else {
			// get all department
			List<DepartmentModel> lstDepartmentModel = departmentService.getAllActiveDepartment();
			for (DepartmentModel departmentModel : lstDepartmentModel) {
				departments.put(departmentModel.getDeptId(), departmentModel.getDeptName());
			}
		}
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(departments);
		LOG.info("[End] Ajax get department list.");
		return builder.build();
	}

	/**
	 * ajax get resull when search reservation
	 * 
	 * @param reservationModel
	 * @return
	 */
	@RequestMapping(value = "/ajax-search-reservation", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSearchReservation(@RequestBody ReservationModel reservationModel) throws Exception {
		LOG.info("[Start] ajax Search Reservation");
		List<ReservationInfo> reservationList = new ArrayList<ReservationInfo>();
		// List<ReservationModel> reservationList =
		// this.bookingService.searchReservation(reservationModel);
		reservationModel.setHospitalId(MssContextHolder.getHospitalId());
		List<ReservationInfo> lstReservationInfo = this.bookingService.searchReservationInfo(reservationModel);
		// TODO: turning
		for (ReservationInfo reservationInfo : lstReservationInfo) {
			// Booking newborns
//			if (reservationInfo.getBookingNewbornsChildId() != null) {
//				UserChildModel userChildModel = this.userChildService
//						.findById(reservationInfo.getBookingNewbornsChildId());
//				String infoBooking = userChildModel.getChildName() + "(" + userChildModel.getDob().toString() + ")";
//				reservationInfo.setInfoBooking(infoBooking);
//			}
			if (reservationInfo.getBookingNewbornsChildId() != null) {
				VaccineChildHistoryInfo vaccineChildHistoryInfo = this.vaccineChildHistoryService
						.getListVaccineChildHistoryById(reservationInfo.getBookingNewbornsChildId());
				String infoBooking = vaccineChildHistoryInfo.getChildName() + "_"
						+ vaccineChildHistoryInfo.getVaccineName() + "_" + vaccineChildHistoryInfo.getInjectedNo();
				reservationInfo.setInfoBooking(infoBooking);
			}
			// Booking vaccine
			if (reservationInfo.getChildId() != null) {
				VaccineChildHistoryInfo vaccineChildHistoryInfo = this.vaccineChildHistoryService
						.getListVaccineChildHistoryById(reservationInfo.getVaccineChildId());
				String infoBooking = vaccineChildHistoryInfo.getChildName() + "_"
						+ vaccineChildHistoryInfo.getVaccineName() + "_" + vaccineChildHistoryInfo.getInjectedNo();
				reservationInfo.setInfoBooking(infoBooking);
			}
//			if (reservationInfo.getReservationStatus() != null) {
//				if(reservationInfo.getReservationStatus().compareTo(new BigDecimal(ReservationStatus.CANCELLED.toInt())) == 0) {
//					reservationInfo.setInfoBooking("");
//				}
//			}

 			if (MssContextHolder.isKcck()) {
				if (Integer.valueOf(reservationInfo.getReservationStatus().toString()) != 0) {
					reservationList.add(reservationInfo);
				}
			}else{
				reservationList.add(reservationInfo);
			}
 			System.out.println("infoBooking: " + reservationInfo.getInfoBooking());
		}
		
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(reservationList);
		LOG.info("[End] ajax Search Reservation");
		return builder.build();
	}

	/**
	 * ajax cancel the reservation
	 * 
	 * @param reservationModel
	 * @return
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@RequestMapping(value = "/ajax-cancel-reservation", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxCancelReservation(@RequestBody ReservationModel reservationModel) throws Exception {
		LOG.info("[Start] cancel the reservation.");
		LOG.debug("[UserId] " + getSysUser().getLoginId());
		LOG.debug("Cancel the reservation." + reservationModel.toString());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		String date = reservationModel.getReservationDate();
		String time = reservationModel.getReservationTime();
		Integer reservationId = reservationModel.getReservationId();
		String vaccineChildId = reservationModel.getVaccineChildId();
		LocalDateTime selectedDateTime = LocalDateTime.parse(date + time,
				DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);
		if (checkTime.isAfter(now)) {
			// Cancel
			if (MssContextHolder.isKcck()) {
				ReservationModel kcckReservationModel = bookingService.findKcckReservationById(reservationId);
				KcckReservationModel kcckCancelModel = new KcckReservationModel();
				kcckCancelModel.setReservation_code(kcckReservationModel.getReservationCode());
				kcckCancelModel.setPatient_code(kcckReservationModel.getCardNumber());
				kcckCancelModel.setHosp_code(MssContextHolder.getHospCode());
				kcckCancelModel.setLocale(MssContextHolder.getLocale().toString());
				KcckReservationModel kcckCancelReservationModel = kcckBookingService.cancelReservation(kcckCancelModel);
				if (kcckCancelReservationModel.getReservation_code() == null) {
					builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be006.msg.cancel.fail"));
					return builder.build();
				}
			}
			reservationModel = this.bookingService.cancelReservation(reservationId);
			String hospitalName = reservationModel.getHospitalName();
			String derpartmentCode = "";
			if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			    reservationModel = this.bookingService.findKcckReservationById(Integer.valueOf(reservationId));
			    derpartmentCode = reservationModel.getDepartmentCode();
			} else {
				 reservationModel = this.bookingService.findReservationById(Integer.valueOf(reservationId));
				 derpartmentCode = reservationModel.getDepartCode();
			}
			// If cancle booking vaccine
			if (!StringUtils.isBlank(vaccineChildId) && NumberUtils.isNumber(vaccineChildId)) {
				VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService
						.findById(Integer.valueOf(vaccineChildId));
				vaccineChildHistoryModel.setActiveFlg(ActiveFlag.INACTIVE.toInt());
				this.vaccineChildHistoryService.save(vaccineChildHistoryModel);
			}
			LOG.debug("Cancel the reservation. " + reservationModel.toString());
			// send email to patient after finish canceling
			MailInfo mailInfo = new MailInfo();
			mailInfo.setPatientName(reservationModel.getPatientName());
			mailInfo.setHospitalName(hospitalName);
			mailInfo.setReservationCode(reservationModel.getReservationCode());
			mailInfo.setDepartmentName(reservationModel.getDeptName());
			mailInfo.setDoctorName(reservationModel.getDoctorName());
			mailInfo.setPatientCode(this.bookingService.findPatientById(reservationModel.getPatientId()).getCardNumber());
			mailInfo.setReservationDatetime(reservationModel.getFormattedReservationDate() + " "
					+ reservationModel.getFormattedReservationTime());
			if (reservationModel.getEmail() != null && !"".equals(reservationModel.getEmail())) {
				List<String> toList = new ArrayList<>();
				toList.add(reservationModel.getEmail());
				if(!StringUtils.isEmpty(derpartmentCode) && MssConfiguration.getInstance().getApiKcckVaccineCode().equals(derpartmentCode)){
			       UserModel userMode = this.userService.getActiveUserByEmail(reservationModel.getEmail(), MssContextHolder.getHospitalId());
			       mailInfo.setPatientName(userMode.getName());
			    }
				mailService.sendMail(MailCode.CANCEL_RESERVATION.toString(), this.getLanguage(), mailInfo, toList,
						reservationModel.getPatientId(), reservationModel.getReservationId(),
						MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
						MssContextHolder.getDomainName());
			}
			builder.status(HttpStatus.OK).message(this.getText("be006.msg.cancel.success"));
		
		
		} else {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
			.message(this.getText("general.msg.cannot_delete_past_time"));
		}
		LOG.info("[End] cancel the reservation");
		return builder.build();
	}

	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@RequestMapping(value = "/ajax-update-reservation-status", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxUpdateReservationStatus(@RequestBody ReservationModel reservationModel) {
		LOG.info("[Start] Update Reservation Status.");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (this.bookingService.updateReservationStatus(reservationModel)) {
			if (ReservationStatus.CANCELLED.toInt().equals(reservationModel.getReservationStatus())) {
				// send email if reservation is cancelled
				reservationModel = this.bookingService.findReservationById(reservationModel.getReservationId());
				// send email to patient after finish canceling
				MailInfo mailInfo = new MailInfo();
				mailInfo.setPatientName(reservationModel.getPatientName());
				mailInfo.setHospitalName(reservationModel.getHospitalName());
				mailInfo.setReservationCode(reservationModel.getReservationCode());
				mailInfo.setDepartmentName(reservationModel.getDeptName());
				mailInfo.setDoctorName(reservationModel.getDoctorName());
				mailInfo.setReservationDatetime(reservationModel.getFormattedReservationDate() + " "
						+ reservationModel.getFormattedReservationTime());
				mailInfo.setPatientCode(reservationModel.getReservationCode());
				List<String> toList = new ArrayList<>();
				toList.add(reservationModel.getEmail());
				mailService.sendMail(MailCode.CANCEL_RESERVATION.toString(), this.getLanguage(), mailInfo, toList,
						reservationModel.getPatientId(), reservationModel.getReservationId(),
						MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
						MssContextHolder.getDomainName());
			}
			builder.status(HttpStatus.OK).message(this.getText("be006.msg.update.status.success"));
			LOG.debug("Update Reservation Status success. " + reservationModel.toString());
		} else {
			LOG.warn("[WARN] Update Reservation Status fail");
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be006.msg.update.status.fail"));
		}
		LOG.info("[End] Update Reservation Status.");
		return builder.build();
	}

	/**
	 * Ajax get timeslot list.
	 *
	 * @return the list
	 */
	@RequestMapping(value = "/ajax-get-timeslot-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetTimeslotList() {
		LOG.info("[Start] Ajax get timeslot list.");
		Integer deptId = MssContextHolder.getBookingInfo().getDeptId();
		List<String> timeslotList = this.doctorScheduleService.getTimeslotListByDepartment(deptId);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(timeslotList);
		LOG.info("[End] Ajax get timeslot list.");
		return builder.build();
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
	 * Booking vaccine.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/booking-vaccine", method = { RequestMethod.GET })
	public ModelAndView bookingVaccine(ModelMap model) throws Exception {
		List<VaccineModel> lstVaccineModel = this.vaccineService
				.findVaccineByHospitalCode(getSysUser().getHospitalCode());

		model.addAttribute("vaccineModels", lstVaccineModel);
		return new ModelAndView("back.booking.vaccine", "user", new UserModel());
	}

	/**
	 * Ajax search user model.
	 *
	 * @param userModel
	 *            the user model
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/ajax-search-user", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSearchUserModel(@RequestBody UserModel userModel) throws Exception {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		List<UserModel> lstUserModel = this.userService.findByCondition(userModel);

		builder.status(HttpStatus.OK).data(lstUserModel);
		return builder.build();
	}

	/**
	 * Ajax search user child.
	 *
	 * @param userChildModel
	 *            the user child model
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@RequestMapping(value = "/ajax-search-user-child", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSearchUserChild(@RequestBody UserChildModel userChildModel) throws Exception {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Integer userId = userChildModel.getUserId();
		if (userId == null) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("be301.msg.not.data"));
			return builder.build();
		}

		List<UserChildModel> lstUserChildModel = this.userChildService.findUserChildByActiveFlg(userId,
				ActiveFlag.ACTIVE.toInt());
		builder.status(HttpStatus.OK).data(lstUserChildModel);
		return builder.build();
	}

	/**
	 * Ajax info vaccine.
	 *
	 * @param vaccineChildHistoryModel
	 *            the vaccine child history model
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping(value = "/ajax-init-info-vaccine", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxInfoVaccine(@RequestBody VaccineChildHistoryModel vaccineChildHistoryModel)
			throws Exception {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Integer vaccineId = vaccineChildHistoryModel.getVaccineId();
		Integer childId = vaccineChildHistoryModel.getChildId();
		if (childId == null) {
			// builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("be301.msg.not.choose.children"));
			return builder.build();
		}
		if (vaccineId == null) {
			// builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("be301.msg.not.select.vaccine"));
			return builder.build();
		}
		List<BookingVaccineBackendInfo> lstInfomationVaccine = this.vaccineService.getInformationVaccine(vaccineId,
				childId);
		if (CollectionUtils.isNotEmpty(lstInfomationVaccine)) {
			BookingVaccineBackendInfo bookingVaccineBackendInfo = lstInfomationVaccine.get(0);
			Timestamp timestampFromDate = bookingVaccineBackendInfo.getFromDate();

			Locale locale = Locale.JAPANESE;
			if (HospitalLocale.VI_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
				locale = new Locale("vi");
			} else if (!HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
				locale = Locale.ENGLISH;
			}

			String fromDateFormat = "";
			String strFromDate = "";
			if (timestampFromDate == null || timestampFromDate.before(new Date())) {
				fromDateFormat = MssDateTimeUtil.convertDateToStringByLocale(new Date(),
						DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND, locale);
				strFromDate = MssDateTimeUtil.dateToString(new Date(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
			} else {
				fromDateFormat = MssDateTimeUtil.convertDateToStringByLocale(timestampFromDate,
						DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND, locale);
				strFromDate = MssDateTimeUtil.dateToString(timestampFromDate,
						DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
			}
			bookingVaccineBackendInfo.setFromDateFormat(fromDateFormat);
			bookingVaccineBackendInfo.setStrFromDate(strFromDate);

			String fromYear = VaccineUtils.getMonthAndYearText(bookingVaccineBackendInfo.getLimitAgeFromMonth(),
					locale);
			bookingVaccineBackendInfo.setFromYear(fromYear);
			String toYear = VaccineUtils.getMonthAndYearText(bookingVaccineBackendInfo.getLimitAgeToMonth(), locale);
			bookingVaccineBackendInfo.setToYear(toYear);

			Integer injectdNoCurrent = bookingVaccineBackendInfo.getInjectdNoCurrent().intValue();
			Integer totalInject = bookingVaccineBackendInfo.getTotalInject();
			if (injectdNoCurrent == totalInject) {
				builder.status(HttpStatus.METHOD_NOT_ALLOWED).data(bookingVaccineBackendInfo)
						.message(getText("be301.msg.can.not.booking.vaccine"));
				return builder.build();
			}
			builder.status(HttpStatus.OK).data(bookingVaccineBackendInfo);
		}
		return builder.build();
	}

	/**
	 * Select date time booking vaccine.
	 *
	 * @param userIdStr
	 *            the user id str
	 * @param vaccineIdStr
	 *            the vaccine id str
	 * @param chidlIdStr
	 *            the chidl id str
	 * @param dateBooking
	 *            the date booking
	 * @param timeUsing
	 *            the time using
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_RESERVATION_NAME })
	@NavigationConfig(group = { NavigationGroup.MANAGE_RESERVATION })
	@RequestMapping("/select-time-booking-vaccine")
	public ModelAndView selectDateTimeBookingVaccine(@RequestParam(value = "userId", required = false) String userIdStr,
			@RequestParam(value = "vaccineId", required = false) String vaccineIdStr,
			@RequestParam(value = "childId", required = false) String chidlIdStr,
			@RequestParam(value = "dateBooking", required = false) String dateBooking,
			@RequestParam(value = "timeUsing", required = false) String timeUsing, ModelMap model) throws Exception {
		LOG.info("[Start] Select date time.");
		BookingInfo bookingInfo = MssContextHolder.getBookingInfo();

		if (StringUtils.isBlank(userIdStr) || !NumberUtils.isNumber(userIdStr)) {
			LOG.warn("[WARN] Select user. userId is null");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be003.msg.not.select.user")));
			return new ModelAndView(new RedirectView("booking-vaccine"));
		}
		if (StringUtils.isBlank(vaccineIdStr) || !NumberUtils.isNumber(vaccineIdStr)) {
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be003.msg.not.select.vaccine")));
			return new ModelAndView(new RedirectView("booking-vaccine"));
		}
		if (StringUtils.isBlank(chidlIdStr) || !NumberUtils.isNumber(chidlIdStr)) {
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be003.msg.not.select.child")));
			return new ModelAndView(new RedirectView("booking-vaccine"));
		}
		if (StringUtils.isBlank(dateBooking)) {
			this.addNotification(new NotificationModel(NotificationType.ERROR,
					this.getText("be003.msg.not.found.date.using.booking")));
			return new ModelAndView(new RedirectView("booking-vaccine"));
		}
		if (StringUtils.isBlank(timeUsing) || !NumberUtils.isNumber(timeUsing)) {
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be003.msg.not.found.injectNo")));
			return new ModelAndView(new RedirectView("booking-vaccine"));
		}
		DepartmentModel departmentModel = this.departmentService.findDeptByType(MssContextHolder.getHospCode(),
				DepartmentType.VACCINE.toInt());
		Integer deptId = departmentModel.getDeptId();
		if (deptId == null) {
			LOG.warn("[WARN] Select date time. deptId is null");
			return new ModelAndView(new RedirectView("booking-vaccine"));
		}
		// display first date in booking vaccine schedule
		if (dateBooking != null && !StringUtils.isBlank(dateBooking)) {
			model.addAttribute("curDate", MssDateTimeUtil.convertStringDate(dateBooking,
					DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		}
		List<DoctorModel> doctorList = this.doctorService.findDoctorsByDepartment(deptId);
		DepartmentModel dept = this.departmentService.findDepartmentById(deptId);
		if (dept == null) {
			LOG.warn("[WARN] Select date time. DepartmentModel is null");
			return new ModelAndView(new RedirectView("booking-vaccine"));
		}

		if (bookingInfo == null) {
			bookingInfo = new BookingInfo();
			MssContextHolder.setBookingInfo(bookingInfo);
		}
		bookingInfo.setDeptId(dept.getDeptId());
		bookingInfo.setDeptName(dept.getDeptName());
		bookingInfo.setVaccineId(Integer.valueOf(vaccineIdStr));
		bookingInfo.setChildId(Integer.valueOf(chidlIdStr));
		bookingInfo.setUserId(Integer.valueOf(userIdStr));
		bookingInfo.setTimesUsing(timeUsing);

		model.addAttribute("doctorList", doctorList);
		model.addAttribute("hospitalName", dept.getHospitalName());
		model.addAttribute("departmentName", dept.getDeptName());
		model.addAttribute("isBookingVaccine", true);
		LOG.info("[End] Select date time.");
		return new ModelAndView("back.booking.time.select");
	}
}
