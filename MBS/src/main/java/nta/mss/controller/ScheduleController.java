package nta.mss.controller;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.URLEncoder;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Map.Entry;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.validation.Valid;

import nta.kcck.model.KcckDefaultScheduleModel;
import nta.kcck.model.KcckDepartmentModel;
import nta.kcck.model.MessageResponse;
import nta.kcck.service.IKcckDepartmentService;
import nta.kcck.service.impl.KcckDepartmentService;
import nta.mss.entity.*;
import nta.mss.info.*;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.common.MssFileUtils;
import nta.mss.misc.common.SessionValidate;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.DepartmentType;
import nta.mss.misc.enums.JuniorFlag;
import nta.mss.misc.enums.MailCode;
import nta.mss.misc.enums.NotificationType;
import nta.mss.misc.enums.UserRole;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.BookingTimeModel;
import nta.mss.model.DefaultScheduleModel;
import nta.mss.model.DeletingComaModel;
import nta.mss.model.DepartmentModel;
import nta.mss.model.DepartmentScheduleModel;
import nta.mss.model.DoctorModel;
import nta.mss.model.DoctorScheduleModel;
import nta.mss.model.HospitalModel;
import nta.mss.model.MailTemplateModel;
import nta.mss.model.NotificationModel;
import nta.mss.model.ReservationKpiModel;
import nta.mss.model.ReservationModel;
import nta.mss.model.ScheduleMailHistoryModel;
import nta.mss.model.SysUserModel;
import nta.mss.model.UploadedFileModel;
import nta.mss.security.WebSysUserDetails;
import nta.mss.service.IBookingService;
import nta.mss.service.IDepartmentScheduleService;
import nta.mss.service.IDepartmentService;
import nta.mss.service.IDoctorScheduleService;
import nta.mss.service.IDoctorService;
import nta.mss.service.IHospitalService;
import nta.mss.service.IMailService;
import nta.mss.service.IScheduleService;
import nta.mss.validation.MultipartFileValidator;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.io.IOUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.math.NumberUtils;
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
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;
import org.springframework.web.servlet.view.RedirectView;

import au.com.bytecode.opencsv.CSVWriter;

/**
 * The Class ScheduleController.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 */
@NavigationConfig(leftMenuType = NavigationType.BACK_LEFT_MENU)
@Controller
@Scope("prototype")
@RequestMapping(value = "/schedule")
public class ScheduleController extends BaseController {
	private static final Logger LOG = LogManager.getLogger(ScheduleController.class);
	/** The doctor service. */
	private IDoctorService doctorService;

	private IScheduleService scheduleService;

	private IHospitalService hospitalService;

	private IMailService mailService;

	private IBookingService bookingService;

	private IDepartmentService departmentService;

	private IDepartmentScheduleService departmentScheduleService;

	private IDoctorScheduleService doctorScheduleService;

	private MultipartFileValidator fileValidator;
	//TODO
	KcckDepartmentService kcckDepartmentService = new KcckDepartmentService();

	public ScheduleController() {

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
	 * Instantiates a new schedule controller.
	 * 
	 * @param doctorService
	 *            the doctor service
	 * @param scheduleService
	 *            the schedule service
	 * @param hospitalService
	 *            the hospital service
	 * @param departmentService
	 *            the department service
	 */
	@Autowired
	public ScheduleController(IDoctorService doctorService, IScheduleService scheduleService,
			IHospitalService hospitalService, IMailService mailService, IBookingService bookingService,
			IDepartmentService departmentService, IDepartmentScheduleService departmentScheduleService,
			IDoctorScheduleService doctorScheduleService, MultipartFileValidator fileValidator) {
		this.doctorService = doctorService;
		this.scheduleService = scheduleService;
		this.hospitalService = hospitalService;
		this.mailService = mailService;
		this.bookingService = bookingService;
		this.departmentService = departmentService;
		this.departmentScheduleService = departmentScheduleService;
		this.doctorScheduleService = doctorScheduleService;
		this.fileValidator = fileValidator;
	
	}

	/**
	 * View schedule remove coma.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/schedule-delete-coma-info", method = RequestMethod.GET)
	public ModelAndView viewScheduleDeleteComa(@RequestParam(value = "deptId", required = true) String deptIdStr,
			ModelMap model) {
		LOG.info("[Start] View schedule remove coma.");
		LOG.debug("[UserID] User = " + getSysUser().getLoginId());
		LOG.debug("View schedule remove coma. deptIdStr = " + deptIdStr);
		if (StringUtils.isBlank(deptIdStr) || !NumberUtils.isDigits(deptIdStr)) {
			LOG.warn("[WARN] View schedule remove coma. deptId is null or not an integer");
			return new ModelAndView(new RedirectView("schedule-coma-select-department"));
		}
		Integer deptId = Integer.valueOf(deptIdStr);
		DepartmentModel dept = departmentService.findDepartmentById(deptId);
		String deptName = dept.getDeptName();
		String hospitalName = dept.getHospitalName();
		MssContextHolder.getScheduleInfo().setDeptId(deptId);
		MssContextHolder.getScheduleInfo().setDeptName(deptName);

		model.addAttribute("hospitalName", hospitalName);
		model.addAttribute("deptName", deptName);
		LOG.info("[End] View schedule remove coma.");
		return new ModelAndView("back.schedule.delete.coma");
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
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug("Ajax get timeslot list. deptId = " + deptId);
		List<String> timeslotList = this.departmentScheduleService.getTimeslotListByDepartment(deptId);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(timeslotList);
		LOG.info("[End] Ajax get timeslot list.");
		return builder.build();
	}

	/**
	 * Ajax get full timeslot list.
	 *
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-get-full-timeslot-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetFullTimeslotList() {
		LOG.info("[Start] Ajax get full timeslot list.");
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug("Ajax get full timeslot list. deptId = " + deptId);
		List<String> timeslotList = this.departmentScheduleService.getFullTimeslotListByDepartment(deptId);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(timeslotList);
		LOG.info("[End] Ajax get full timeslot list.");
		return builder.build();
	}

	/**
	 * Ajax get doctor list.
	 *
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-get-doctor-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetDoctorList() {
		LOG.info("[Start] Ajax get doctor list.");
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug("Ajax get doctor list. deptId = " + deptId);
		Map<Integer, String> doctorList = this.doctorService.getDoctorsByDepartment(deptId);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(doctorList);
		LOG.info("[End] Ajax get doctor list.");
		return builder.build();
	}

	/**
	 * Ajax get total reservation kpi doctors.
	 *
	 * @param bookingTime
	 *            the booking time
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-get-total-reservation-kpi-doctors", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetTotalReservationKpiDoctors(@RequestBody BookingTimeModel bookingTime) {
		LOG.info("[Start] Ajax get total reservation kpi doctors.");
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug("Ajax get total reservation kpi doctors. deptId = " + deptId);
		Map<String, ReservationKpiModel> result = this.scheduleService.getTotalReservationAndKpi(deptId,
				bookingTime.getStartDate(), bookingTime.getEndDate());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(result);
		LOG.info("[End] Ajax get total reservation kpi doctors.");
		return builder.build();
	}

	/**
	 * Ajax schedule get reservations.
	 *
	 * @param doctorScheduleModel
	 *            the doctor schedule model
	 * @return the list
	 */
	@RequestMapping(value = "/ajax-schedule-get-reservations", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxScheduleGetReservations(@RequestBody DoctorSchedulePK doctorSchedulePK) {
		LOG.info("[Start] Ajax schedule get reservations.");
		Integer doctorId = doctorSchedulePK.getDoctorId();
		String checkDate = doctorSchedulePK.getCheckDate();
		String startTime = doctorSchedulePK.getStartTime();
		LOG.debug(" doctorSchedulePK [doctorId = " + doctorId + " ,checkDate=" + checkDate + ",startTime=" + startTime
				+ "]");
		List<ReservationModel> result = this.scheduleService.getReservationByDoctorAndTimeslot(doctorId, checkDate,
				startTime);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(result);
		LOG.info("[End] Ajax schedule get reservations.");
		return builder.build();
	}

	@RequestMapping(value = "/ajax-schedule-get-reservations-multi-records", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxScheduleGetReservationsMultiRecords(
			@RequestBody List<DoctorSchedulePK> doctorSchedulePKList) {
		LOG.info("[Start] Schedule Get Reservations Multi Records");
		Map<DoctorSchedulePK, List<ReservationModel>> doctorSchedule = new LinkedHashMap<DoctorSchedulePK, List<ReservationModel>>();
		if (doctorSchedulePKList != null && doctorSchedulePKList.size() != 0) {
			doctorSchedule = this.scheduleService.getReservationInDoctorAndTimeslotList(doctorSchedulePKList);
		}
		Map<String, List<ReservationModel>> result = new LinkedHashMap<String, List<ReservationModel>>();
		StringBuilder key;
		DoctorSchedulePK entryKey;
		List<ReservationModel> entryValue;
		for (Entry<DoctorSchedulePK, List<ReservationModel>> entry : doctorSchedule.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			key = new StringBuilder();
			key.append(entryKey.getCheckDate());
			key.append("_");
			key.append(entryKey.getStartTime());
			key.append("_");
			key.append(entryKey.getDoctorId());
			result.put(key.toString(), entryValue);
		}
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(result);
		LOG.info("[End] Schedule Get Reservations Multi Records");
		return builder.build();
	}

	/**
	 * Ajax schedule get doctor schedule pk list.
	 *
	 * @param combinedIdList
	 *            the combined id list
	 * @param session
	 *            the session
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-schedule-get-doctorSchedulePK-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxScheduleGetDoctorSchedulePKList(@RequestBody List<String> combinedIdList,
			HttpSession session) {
		// get list doctor schedule
		LOG.info("[Start] Ajax schedule get doctor schedule pk list.");
		String[] ids;
		List<DoctorSchedulePK> doctorSchedulePKList = new ArrayList<DoctorSchedulePK>();
		String checkDate;
		String startTime;
		Integer doctorId;
		for (String combinedId : combinedIdList) {
			ids = combinedId.split("_");
			checkDate = ids[0];
			startTime = ids[1];
			doctorId = Integer.valueOf(ids[2]);
			doctorSchedulePKList.add(new DoctorSchedulePK(doctorId, checkDate, startTime));
		}
		if (doctorSchedulePKList == null || doctorSchedulePKList.size() != 0) {
			// get doctor schedules that have reservations
			Map<DoctorSchedulePK, List<ReservationModel>> doctorSchedule = this.scheduleService
					.getReservationInDoctorAndTimeslotList(doctorSchedulePKList);
			// add doctorSchedule Map to session
			session.setAttribute("doctorScheduleMap", doctorSchedule);
		} else {
			LOG.debug("doctorSchedulePKList is null or size = 0");
		}
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data("schedule-delete-coma-sending-setting");
		LOG.info("[End] Ajax schedule get doctor schedule pk list.");
		return builder.build();
	}

	/**
	 * View deleted patient list.
	 *
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@SuppressWarnings("unchecked")
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/schedule-delete-coma-sending-setting", method = RequestMethod.GET)
	public ModelAndView viewDeletedPatientList(ModelMap model, HttpSession session) {
		LOG.info("[Start] View deleted patient list.");
		LOG.debug("[UserID] User = " + getSysUser().getLoginId());
		String deptName = MssContextHolder.getScheduleInfo().getDeptName();
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug("View deleted patient list. deptId = " + deptId);
		DepartmentModel dept = departmentService.findDepartmentById(deptId);
		String hospitalName = dept.getHospitalName();
		Map<DoctorSchedulePK, List<ReservationModel>> doctorSchedule = (Map<DoctorSchedulePK, List<ReservationModel>>) session
				.getAttribute("doctorScheduleMap");

		// get doctor list in department
		List<DoctorModel> doctorList = this.doctorService.findDoctorsByDepartment(deptId);

		// get mailTemplateModel List
		List<MailTemplateModel> mailTemplateList = mailService
				.findAllTemplateCustomize(MssContextHolder.getHospitalId(), MssContextHolder.getUserLanguage());

		model.addAttribute("mailTemplateList", mailTemplateList);
		model.addAttribute("doctorSchedule", doctorSchedule);
		model.addAttribute("hospitalName", hospitalName);
		model.addAttribute("deptName", deptName);
		model.addAttribute("doctorList", doctorList);
		LOG.info("[End] View deleted patient list.");
		return new ModelAndView("back.schedule.delete.coma.sending.setting");
	}

	/**
	 * Ajax delete coma get doctor for select box.
	 *
	 * @param deletingComaModelList
	 *            the deleting coma model list
	 * @param session
	 *            the session
	 * @return the list
	 */
	@SuppressWarnings("unchecked")
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@RequestMapping(value = "/ajax-delete-coma-get-doctor-for-select-box", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxDeleteComaGetDoctorForSelectBox(@RequestBody BookingTimeModel bookingTime,
			HttpSession session) {
		LOG.info("[Start] delete coma get doctor for select box.");
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug("delete coma get doctor for select box. deptId = " + deptId);
		Map<DoctorSchedulePK, List<ReservationModel>> doctorSchedule = (Map<DoctorSchedulePK, List<ReservationModel>>) session
				.getAttribute("doctorScheduleMap");
		List<DoctorScheduleModel> doctorScheduleList = this.doctorScheduleService.getDoctorScheduleByDeptIdAndTimeslot(
				deptId, bookingTime.getStartDate(), bookingTime.getSelectedTime());
		List<DoctorScheduleModel> found = new ArrayList<DoctorScheduleModel>();
		for (DoctorScheduleModel ds : doctorScheduleList) {
			if (doctorSchedule
					.containsKey(new DoctorSchedulePK(ds.getDoctorId(), ds.getCheckDate(), ds.getStartTime()))) {
				found.add(ds);
			}
		}
		doctorScheduleList.removeAll(found);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(doctorScheduleList);
		LOG.info("[End] delete coma get doctor for select box.");
		return builder.build();
	}

	/**
	 * Ajax schedule send email.
	 *
	 * @param reservationIds
	 *            the reservation ids
	 * @param session
	 *            the session
	 * @return the map
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@RequestMapping(value = "/ajax-schedule-send-email", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxScheduleSendEmail(@RequestBody List<DeletingComaModel> deletingComaModelList,
			HttpSession session) {
		LOG.info("[Start]  Ajax schedule send email.");
		Map<Integer, DeletingComaModel> deletingComaMap = new HashMap<Integer, DeletingComaModel>();
		for (DeletingComaModel deletingcoma : deletingComaModelList) {
			deletingComaMap.put(deletingcoma.getReservationId(), deletingcoma);
		}
		// set deleting coma map to session
		session.setAttribute("deletingComaMap", deletingComaMap);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data("schedule-delete-coma-confirmation");
		LOG.info("[End]  Ajax schedule send email.");
		return builder.build();
	}

	/**
	 * View email sending confirmation.
	 *
	 * @param templateId
	 *            the template id
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@SuppressWarnings("unchecked")
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/schedule-delete-coma-confirmation", method = RequestMethod.GET)
	public ModelAndView viewEmailSendingConfirmation(@RequestParam(value = "templateId") String templateId,
			ModelMap model, HttpSession session) {
		LOG.info("[Start] View email sending confirmation.");
		LOG.debug("View email sending confirmation. templateId = " + templateId);
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug("View email sending confirmation. deptId = " + deptId);
		String deptName = MssContextHolder.getScheduleInfo().getDeptName();
		DepartmentModel dept = departmentService.findDepartmentById(deptId);
		String hospitalName = dept.getHospitalName();
		Map<DoctorSchedulePK, List<ReservationModel>> doctorSchedule = (Map<DoctorSchedulePK, List<ReservationModel>>) session
				.getAttribute("doctorScheduleMap");
		Map<Integer, DeletingComaModel> deletingComaMap = (Map<Integer, DeletingComaModel>) session
				.getAttribute("deletingComaMap");

		// get MailTemplate by code and set it to session
		MailTemplateModel mailTemplate = mailService.getMailTemplateByIdAndLocale(Integer.valueOf(templateId),
				MssContextHolder.getUserLanguage(), MssContextHolder.getHospitalId());
		session.setAttribute("mailTemplateCode", mailTemplate.getTemplateCode());

		model.addAttribute("doctorSchedule", doctorSchedule);
		model.addAttribute("deletingComa", deletingComaMap);
		model.addAttribute("mailTemplate", mailTemplate);
		model.addAttribute("hospitalName", hospitalName);
		model.addAttribute("deptName", deptName);
		model.addAttribute("deptId", deptId);
		LOG.info("[End] View email sending confirmation.");
		return new ModelAndView("back.schedule.delete.coma.confirmation");
	}

	/**
	 * Submit schedule delete coma.
	 *
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@SuppressWarnings("unchecked")
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/schedule-delete-coma-submit", method = RequestMethod.GET)
	public ModelAndView submitScheduleDeleteComa(ModelMap model, HttpSession session) {
		LOG.info("[Start] Submit schedule delete coma.");
		LOG.debug("[UserID] userId = " + getSysUser().getLoginId());
		RedirectView redirectView = new RedirectView(
				"schedule-delete-coma-info?deptId=" + MssContextHolder.getScheduleInfo().getDeptId());
		ModelAndView modelAndView = new ModelAndView(redirectView);
		// get deleting coma map and mail template code in session
		Map<DoctorSchedulePK, List<ReservationModel>> doctorSchedule = (Map<DoctorSchedulePK, List<ReservationModel>>) session
				.getAttribute("doctorScheduleMap");
		Map<Integer, DeletingComaModel> deletingComaMap = (Map<Integer, DeletingComaModel>) session
				.getAttribute("deletingComaMap");
		String mailTemplateCode = session.getAttribute("mailTemplateCode").toString();

		// cancel doctor schedule

		if (doctorSchedule != null
				&& !this.doctorScheduleService.cancelDoctorScheduleByIdInList(doctorSchedule.keySet())) {
			this.addNotification(new NotificationModel(NotificationType.ERROR,
					this.getText("be022.msg.cancel_doctor_schedule.fail")));
			return modelAndView;
		}

		// get canceling reservation list and changing reservation list
		List<Integer> cancelingReservationIds = new ArrayList<Integer>();
		Map<Integer, Integer> changingReservationMap = new HashMap<Integer, Integer>();
		Integer doctorId;
		Integer originalDoctorId;
		Integer entryKey;
		DeletingComaModel entryValue;
		for (Entry<Integer, DeletingComaModel> entry : deletingComaMap.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			doctorId = entryValue.getDoctorId();
			originalDoctorId = entryValue.getOriginalDoctorId();
			if (doctorId.equals(originalDoctorId)) {
				cancelingReservationIds.add(entryKey);
			} else {
				changingReservationMap.put(entryKey, doctorId);
			}
		}
		// cancel reservation and send email
		if (cancelingReservationIds.size() > 0) {
			if (!cancelReservation(cancelingReservationIds, deletingComaMap)) {
				this.addNotification(new NotificationModel(NotificationType.ERROR,
						this.getText("be022.msg.cancel_reservation.fail")));
				return modelAndView;
			}
		}
		// change doctor and send email
		if (changingReservationMap.size() > 0) {
			if (!changeDoctorReservation(changingReservationMap, deletingComaMap, mailTemplateCode)) {
				this.addNotification(
						new NotificationModel(NotificationType.ERROR, this.getText("be022.msg.change_doctor.fail")));
				return modelAndView;
			}
		}

		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("be022.msg.delete_coma.success")));
		LOG.info("[End] Submit schedule delete coma.");
		return new ModelAndView(redirectView);
	}

	/**
	 * Cancel reservation.
	 *
	 * @param cancelingReservationIds
	 *            the canceling reservation ids
	 * @param deletingComaMap
	 *            the deleting coma map
	 * @param mailTemplateCode
	 *            the mail template code
	 * @return true, if successful
	 */
	private boolean cancelReservation(List<Integer> cancelingReservationIds,
			Map<Integer, DeletingComaModel> deletingComaMap) {
		boolean result = false;
		MailInfo mailInfo;
		// cancel reservation
		if (this.bookingService.cancelReservationInIdList(cancelingReservationIds)) {
			LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
			// send email
			List<ReservationModel> cancelingReservationList = this.bookingService
					.findReservationInIdList(cancelingReservationIds);
			for (ReservationModel rs : cancelingReservationList) {
				LOG.debug("Cancel Reservation. " + rs.toString());
				if (deletingComaMap.get(rs.getReservationId()).getIsSentEmail()) {
					mailInfo = new MailInfo();
					mailInfo.setPatientName(rs.getPatientName());
					mailInfo.setHospitalName(rs.getHospitalName());
					mailInfo.setReservationCode(rs.getReservationCode());
					mailInfo.setDepartmentName(rs.getDeptName());
					mailInfo.setDoctorName(rs.getDoctorName());
					mailInfo.setPatientCode(rs.getReservationCode());
					mailInfo.setReservationDatetime(
							rs.getFormattedReservationDate() + " " + rs.getFormattedReservationTime());
					sendMailToPatient(rs, MailCode.CANCEL_RESERVATION.toString(), mailInfo);
				}
			}
			result = true;
		}
		return result;
	}

	/**
	 * Change doctor reservation.
	 *
	 * @param changingReservationMap
	 *            the changing reservation map
	 * @param deletingComaMap
	 *            the deleting coma map
	 * @return true, if successful
	 */
	private boolean changeDoctorReservation(Map<Integer, Integer> changingReservationMap,
			Map<Integer, DeletingComaModel> deletingComaMap, String tempCode) {
		boolean result = false;
		MailInfo mailInfo;
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		// update doctor
		if (this.bookingService.updateDoctorReservationById(changingReservationMap)) {
			DeletingComaModel deletingComa;
			List<ReservationModel> changingReservationList = this.bookingService
					.findReservationInIdList(changingReservationMap.keySet());
			for (ReservationModel rs : changingReservationList) {
				LOG.debug(" Change doctor " + rs.toString());
				deletingComa = deletingComaMap.get(rs.getReservationId());
				if (deletingComa.getIsSentEmail()) {
					mailInfo = new MailInfo();
					mailInfo.setPatientName(rs.getPatientName());
					mailInfo.setHospitalName(rs.getHospitalName());
					mailInfo.setReservationCode(rs.getReservationCode());
					mailInfo.setDepartmentName(rs.getDeptName());
					mailInfo.setDoctorName(deletingComa.getOriginalDoctorName());
					mailInfo.setReservationDatetime(
							rs.getFormattedReservationDate() + " " + rs.getFormattedReservationTime());
					mailInfo.setNewDoctorName(rs.getDoctorName());
					sendMailToPatient(rs, tempCode, mailInfo);
				}
			}
			result = true;
		}
		return result;
	}

	/**
	 * Send mail to patient.
	 *
	 * @param reservation
	 *            the reservation
	 * @param templateCode
	 *            the template code
	 */
	private void sendMailToPatient(ReservationModel reservation, String templateCode, MailInfo mailInfo) {
		List<String> toList = new ArrayList<>();
		toList.add(reservation.getEmail());
		mailService.sendMail(templateCode, MssContextHolder.getUserLanguage(), mailInfo, toList,
				reservation.getPatientId(), reservation.getReservationId(), MssContextHolder.getHospitalId(),
				MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());
	}

	/**
	 * view schedule to add kpi in backend.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/schedule-adding-coma", method = RequestMethod.GET)
	public ModelAndView viewAddingComa(@RequestParam("deptId") String deptIdStr, ModelMap model) {
		LOG.info("[Start] schedule to add kpi in backend.");
		LOG.debug("[UserId] User = " + getSysUser().getLoginId());
		Integer deptId = Integer.valueOf(deptIdStr);
		LOG.debug("schedule to add kpi in backend. deptId = " + deptId);
		DepartmentModel dept = departmentService.findDepartmentById(deptId);
		String hospitalName = dept.getHospitalName();
		String deptName = dept.getDeptName();
		MssContextHolder.getScheduleInfo().setDeptId(deptId);
		MssContextHolder.getScheduleInfo().setDeptName(deptName);

		model.addAttribute("hospitalName", hospitalName);
		model.addAttribute("deptName", deptName);
		LOG.info("[End] schedule to add kpi in backend.");
		return new ModelAndView("back.schedule.adding.coma");
	}

	/**
	 * view screen select department to add coma.
	 * 
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/schedule-coma-select-department", method = RequestMethod.GET)
	public ModelAndView selectDepartmentToChangeSchedule(ModelMap model) {
		LOG.info("[Start] Adding coma - select department");
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
				if(MssContextHolder.getKcckDepartmentList()==null){
					departmentList = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),MssContextHolder.getLocale().toString());
					MssContextHolder.setKcckDepartmentList(departmentList);
				}else{
					departmentList= MssContextHolder.getKcckDepartmentList();
				}
				double size = departmentList.size();
				int index = (int) Math.ceil(size / 3);
				internalDepts = departmentList.subList(0, index);
				surgeryDepts = departmentList.subList(index, index * 2);
				vaccineDepts = departmentList.subList(index * 2, (int) size);
				model.addAttribute("isKcck", true);
			} else {
				departmentList = hospital.getDepartments();
				if (hospital.getIsHideDeptType() != null && hospital.getIsHideDeptType() != 1) {
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
				}else {
						double size = departmentList.size();
						if( size >= 3){
							int index = (int) Math.ceil(size / 3);
							internalDepts = departmentList.subList(0, index);
							surgeryDepts = departmentList.subList(index, index * 2);
							vaccineDepts = departmentList.subList(index * 2, (int) size);
						}
						else if(size == 2){
							internalDepts = departmentList.subList(0, 1);
							surgeryDepts = departmentList.subList(1, 2);
						}
						else if(size == 1){
							internalDepts = departmentList.subList(0, 1);
						}
						model.addAttribute("isKcck", true);
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

		LOG.info("[End] Adding coma - select department");

		return new ModelAndView("back.schedule.select.department");
	}

	/**
	 * add kpi for doctor in one time slot.
	 * 
	 * @param value
	 *            the value
	 * @return the map
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@RequestMapping(value = "/ajax-editable-add-coma", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxUpdateKpiForDoctorSchedule(@RequestBody DoctorScheduleModel doctorSchedule) {
		LOG.info("[Start] add kpi for doctor in one time slot.");
		LOG.debug("[UserId] User = " + getSysUser().getLoginId());
		DoctorModel doctorModel = this.doctorService.getDoctorByDoctorId(doctorSchedule.getDoctorId());
		LOG.debug(" add kpi for doctor. " + doctorModel.toString());
		Integer deptId = doctorModel.getDeptId();
		DepartmentModel departmentModel = this.departmentService.findDepartmentById(deptId);
		Integer hospitalId = departmentModel.getHospitalId();
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		try {
			String date = doctorSchedule.getCheckDate();
			String time = doctorSchedule.getStartTime();
			Integer docId = doctorSchedule.getDoctorId();
			String endTime = doctorSchedule.getEndTime();
			Integer val = doctorSchedule.getKpi();

			if (this.scheduleService.updateKpiForDoctorsByTimeSlot(hospitalId, deptId, docId, date, time, val,
					endTime)) {
				builder.status(HttpStatus.OK).message(getText("be021.msg.update.success"));
			} else {
				LOG.warn("[WARN] add kpi for doctor in one time slot is fail");
				builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("be021.msg.update.fail"));
			}
		} catch (Exception ex) {
			LOG.error("ERROR: " + ex.getMessage());
		}
		LOG.info("[End] add kpi for doctor in one time slot.");
		return builder.build();
	}

	/**
	 * View mail history.
	 * 
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.SCHEDULE_MAIL_HISTORY })
	@RequestMapping(value = "/schedule-mail-history", method = RequestMethod.GET)
	public ModelAndView viewMailHistory(ModelMap model, HttpSession session) {
		LOG.info("[Start] View mail history.");
		Map<Integer, String> departments = new LinkedHashMap<>();
		List<DepartmentModel> lstDepartmentModel;
		if(MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1){
			if (MssContextHolder.getKcckDepartmentList() == null) {
				lstDepartmentModel = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
						MssContextHolder.getLocale().toString());
				MssContextHolder.setKcckDepartmentList(lstDepartmentModel);
			} else {
				lstDepartmentModel = MssContextHolder.getKcckDepartmentList();
			}
		}else{
				 lstDepartmentModel = departmentService
				.getAllDepartmentInHospital(MssContextHolder.getHospitalId());
		}
		for (DepartmentModel departmentModel : lstDepartmentModel) {
			departments.put(departmentModel.getDeptId(), departmentModel.getDeptName());
		}
		model.addAttribute("departmentList", departments);
		LOG.info("[End] View mail history.");
		return new ModelAndView("back.schedule.mail.history", "scheduleMailHistory", new ScheduleMailHistoryModel());
	}
	
	/**
	 * View default schedule of department.
	 * 
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.DEFAULT_SCHEDULE_DEPARTMENT })
	@RequestMapping(value = "/default-schedule-department", method = RequestMethod.GET)
	public ModelAndView getDefaultSchedule(ModelMap model, HttpSession session) {
		LOG.info("[Start] View default schedule.");
		List<DepartmentModel> lstDepartmentModel;
		if(MssContextHolder.isKcck()){
			if (CollectionUtils.isEmpty(MssContextHolder.getKcckDepartmentList())) {
				lstDepartmentModel = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
						MssContextHolder.getLocale().toString());
				MssContextHolder.setKcckDepartmentList(lstDepartmentModel);
			} else {
				lstDepartmentModel = MssContextHolder.getKcckDepartmentList();
			}
		} else {
				 lstDepartmentModel = departmentService
				.getAllDepartmentInHospital(MssContextHolder.getHospitalId());
		}
		List<Integer> timeSlot = new ArrayList<>();
		timeSlot.add(1);
		timeSlot.add(2);
		timeSlot.add(3);
		timeSlot.add(4);
		timeSlot.add(5);
		timeSlot.add(6);
		timeSlot.add(7);
		timeSlot.add(8);
		timeSlot.add(9);
		timeSlot.add(10);
		timeSlot.add(15);
		timeSlot.add(20);
		timeSlot.add(25);
		timeSlot.add(30);
		timeSlot.add(40);
		timeSlot.add(50);
		timeSlot.add(60);
		if(!CollectionUtils.isEmpty(lstDepartmentModel)) {
			for (DepartmentModel departmentModel : lstDepartmentModel) {
				departmentModel.setTimeSlot(timeSlot);
			}
		}
		model.addAttribute("departmentList", lstDepartmentModel);
		LOG.info("[End] View mail history.");
		return new ModelAndView("back.default.schedule", "defaultSchedule", new DepartmentModel());
	}
	
	/**
	 * Ajax update default schedule.
	 *
	 * @param defaultScheduleList
	 *            the defaultScheduleList
	 * @param session
	 *            the session
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-update-default-schedule-department", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxUpdateDefaultSchedule(@RequestBody List<DefaultScheduleModel> defaultScheduleList,
			HttpSession session) {
		LOG.info("[Start]  Ajax update default schedule.");
		KcckDefaultScheduleModel kcckDefaultSchedule = new KcckDefaultScheduleModel();
		kcckDefaultSchedule.setHosp_code(MssContextHolder.getHospCode());
		kcckDefaultSchedule.setLanguage(getLanguage());
		List<KcckDepartmentModel> departmentList = new ArrayList<KcckDepartmentModel>();
		for (DefaultScheduleModel info : defaultScheduleList) {
			KcckDepartmentModel item = new KcckDepartmentModel();
			item.setDepartment_id(String.valueOf(info.getDeptId()));
			item.setDepartment_code(info.getDeptCode());
			item.setAvg_time(String.valueOf(info.getDefaultTimeSlot()));
			departmentList.add(item);
		}
		kcckDefaultSchedule.setDepartment_list(departmentList);
		String result = kcckDepartmentService.updateKcckDefaultSchedule(kcckDefaultSchedule);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(result).status(HttpStatus.OK).message(this.getText("general.msg.update.success"));
		//clear cache
		MssContextHolder.getKcckDepartmentList().clear();
		LOG.info("[End]  Ajax update default schedule.");
		return builder.build();
	}
	
	/**
	 * Ajax reset default schedule.
	 */
	@RequestMapping(value = "/ajax-reset-default-schedule-department", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxResetDefaultSchedule() {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.status(HttpStatus.OK).message(this.getText("be092.msg.update.pass.success"));
		return builder.build();		
	}

	/**
	 * Ajax search mail list history.
	 *
	 * @param scheduleMailHistory
	 *            the schedule mail history
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-search-schedule-mail-history", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxMailHistorySearched(@RequestBody ScheduleMailHistoryModel scheduleMailHistory) {
		LOG.info("[Start] Ajax search mail list history.");
		List<ScheduleMailHistoryModel> scheduleHistorys = scheduleService.getInfoSearchScheduleMailHistory(
				MssContextHolder.getHospitalId(), scheduleMailHistory.getDepartment(),
				scheduleMailHistory.getFromDate(), scheduleMailHistory.getToDate());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if(scheduleHistorys.isEmpty()){
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR);
		}else{
			builder.status(HttpStatus.OK).data(scheduleHistorys);
		}
		LOG.info("[End] Ajax search mail list history.");
		return builder.build();
	}

	/**
	 * Ajax get depatment in hospital.
	 * 
	 * @param hospitalModel
	 *            the hospital model
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-get-department-in-hospital", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxGetDepatmentInHospital(@RequestBody HospitalModel hospitalModel) {
		LOG.info("[Start] Ajax get depatment in hospital.");
		Map<Integer, String> departments = new LinkedHashMap<>();
		List<DepartmentModel> lstDepartmentModel;
		if(MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1){
			if (MssContextHolder.getKcckDepartmentList() == null) {
				lstDepartmentModel = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
						MssContextHolder.getLocale().toString());
				MssContextHolder.setKcckDepartmentList(lstDepartmentModel);
			} else {
				lstDepartmentModel = MssContextHolder.getKcckDepartmentList();
			}
		}else{
				 lstDepartmentModel = departmentService
				.getAllDepartmentInHospital(MssContextHolder.getHospitalId());
		}
		for (DepartmentModel departmentModel : lstDepartmentModel) {
			departments.put(departmentModel.getDeptId(), departmentModel.getDeptName());
		}
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(departments);
		LOG.info("[End] Ajax get depatment in hospital.");
		return builder.build();
	}

	/**
	 * Adds the doctor csv.
	 *
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT})
	@RequestMapping("/add-doctor-csv")
	public ModelAndView addDoctorCsv() {
		return new ModelAndView("back.upload.doctor");
	}

	/**
	 * Upload file handler.
	 *
	 * @param uploadedFile
	 *            the uploaded file
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.INPUT_DEPARTMENT_DOCTOR })
	@RequestMapping(value = "/upload-doctor-csv", method = RequestMethod.POST)
	public ModelAndView uploadFileHandler(@ModelAttribute("uploadedFile") UploadedFileModel uploadedFile,
			BindingResult result, ModelMap model) {
		LOG.info("[Start] Adds the doctor by csv.");
		LOG.debug("[UserId] User = " + getSysUser().getLoginId());
		ModelAndView mav = new ModelAndView("back.upload.doctor");
		MultipartFile file = uploadedFile.getFile();
		fileValidator.validate(file, result);
		if (result.hasErrors()) {
			return mav;
		}
		String name = file.getOriginalFilename();
		if (!uploadFile(file, name)) {
			result.reject("be013.label.upload.fail");
		} else {
			// valid data hospital code
			boolean isValidData = doctorService.processValidDataCsv(name);
			if (!isValidData) {
				LOG.warn("[WARN] Don't allow to import multi hospital");
				model.addAttribute("errorMsg", getText("be013.label.data.invalid.hospcode.error"));
				return mav;
			}
			List<DoctorModel> doctorList = doctorService.processDoctorCsv(name);
			if (doctorList == null || doctorList.isEmpty()) {
				LOG.warn("[WARN] doctorList is null");
				model.addAttribute("errorMsg", getText("be013.label.upload.error"));
				return mav;
			}
			// generate department schedule
			if (!this.departmentScheduleService.generateDepartmentSchedule(doctorList)) {
				LOG.warn("[WARN] Generate department schedule failed");
			}
			model.addAttribute("successMsg", getText("be013.label.upload.success"));
		}
		LOG.info("[End] Adds the doctor by csv.");
		return mav;
	}

	/**
	 * import csv department schedule
	 * 
	 * @return import department-schedule
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_REGISTER_CHANGE })
	@RequestMapping("/import-department-schedule-csv")
	public ModelAndView importDepartmentSchedule() {
		LOG.info("[Start] import csv department schedule");
		LOG.info("[End] import csv department schedule");
		return new ModelAndView("back.import.department.schedule", "uploadFile", new UploadedFileModel());
	}

	/**
	 * Export doctor.
	 *
	 * @param response
	 *            the response
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_REGISTER_CHANGE })
	@RequestMapping(value = "export-doctor-csv", method = RequestMethod.GET)
	public void exportDoctor(HttpServletResponse response) {
		LOG.info("[Start] Export doctor.");
		InputStream inputStream = null;
		try {
			List<DoctorInfo> lstDoctorInfo = this.doctorService.findAllDoctorInfo(MssContextHolder.getHospitalId());
			String destDir = MssConfiguration.getInstance().getDirFileUpload();
			String fileName = URLEncoder.encode(this.getText("be010.export.csv.doctor") + ".csv", "UTF-8").replace("+",
					"%20");
			File file = generateFileDoctorList(lstDoctorInfo, destDir, fileName);
			if (file == null) {
				return;
			}
			// Download
			inputStream = new FileInputStream(file);
			response.setContentType("application/force-download; charset=UTF-8");
			response.setCharacterEncoding("UTF-8");
			response.setHeader("Content-Disposition", "attachment; filename*=UTF-8''" + fileName);
			IOUtils.copy(inputStream, response.getOutputStream());
			response.flushBuffer();
		} catch (Exception e) {
			LOG.error("Exception: " + e.getMessage());
		} finally {
			if (inputStream != null) {
				try {
					inputStream.close();
				} catch (IOException e) {
					LOG.error(" Cannot close the input stream: " + e.getMessage());
				}
			}
		}
		LOG.info("[Start] Export doctor.");
	}

	/**
	 * 
	 * upload and import department schedule
	 * 
	 * @param uploadedFile
	 * @param result
	 * @param model
	 * @return
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_REGISTER_CHANGE })
	@RequestMapping(value = "/execute-import-department-schedule", method = RequestMethod.POST)
	public ModelAndView executeImportDepartmentSchedule(@ModelAttribute("uploadedFile") UploadedFileModel uploadedFile,
			BindingResult result, ModelMap model) {
		LOG.info("[Start] upload and import department schedule");
		LOG.debug("[UserId] User = " + getSysUser().getLoginId());
		MultipartFile file = uploadedFile.getFile();
		fileValidator.validate(file, result);
		if (result.hasErrors()) {
			LOG.warn("[WARN] file error");
			model.addAttribute("msgError", getText("be015.label.upload.error"));
			return new ModelAndView("back.import.department.schedule", "uploadFile", uploadedFile);
		}
		if (StringUtils.isBlank(uploadedFile.getApplyDate())) {
			model.addAttribute("msgError", getText("be015.label.upload.error"));
			return new ModelAndView("back.import.department.schedule", "uploadFile", uploadedFile);
		}
		Date applyDate = MssDateTimeUtil.dateFromString(uploadedFile.getApplyDate(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		// get current date without time
		Date now = new Date();
		Calendar cal = Calendar.getInstance();
		cal.setTime(now);

		// Set time fields to zero
		cal.set(Calendar.HOUR_OF_DAY, 0);
		cal.set(Calendar.MINUTE, 0);
		cal.set(Calendar.SECOND, 0);
		cal.set(Calendar.MILLISECOND, 0);

		// Put it back in the Date object
		now = cal.getTime();

		// compare apply date with current date
		if (applyDate.before(now)) {
			model.addAttribute("msgError", getText("be015.label.applydate.error"));
			return new ModelAndView("back.import.department.schedule", "uploadFile", uploadedFile);
		}
		String name = file.getOriginalFilename();
		if (!uploadFile(file, name)) {
			LOG.warn("[WARN] upload file error");
			result.reject("be015.label.upload.fail");
		} else {
			if (!departmentScheduleService.validHospCode(name)) {
				model.addAttribute("msgError", getText("be015.label.data.invalid.hospcode.error"));
				return new ModelAndView("back.import.department.schedule", "uploadFile", uploadedFile);
			}
			boolean importSuccess = departmentScheduleService.importDepartmentScheduleFromCSV(name, uploadedFile);
			if (importSuccess) {
				LOG.info("[Success] upload and import department schedule is success");
				model.addAttribute("msgSuccess", getText("be015.label.upload.success"));
			} else {
				LOG.warn("[WARN] import error");
				model.addAttribute("msgError", getText("be015.label.upload.error"));
			}
		}
		LOG.info("[End] upload and import department schedule");
		return new ModelAndView("back.import.department.schedule", "uploadFile", new UploadedFileModel());
	}

	/**
	 * Upload file.
	 *
	 * @param file
	 *            the file
	 * @param name
	 *            the name
	 * @return true, if successful
	 */
	private boolean uploadFile(MultipartFile file, String name) {
		LOG.info("[Start] uploadFile");
		try {
			byte[] bytes = file.getBytes();

			// Creating the directory to store file
			String rootPath = MssConfiguration.getInstance().getDirFileUpload();
			File dir = new File(rootPath);
			if (!dir.exists()) {
				if (!dir.mkdirs()) {
					LOG.error("Upload file: cannot create directory at: " + rootPath);
					return false;
				}
			}

			// Create the file on server
			File serverFile = new File(dir.getAbsolutePath() + File.separator + name);
			BufferedOutputStream stream = new BufferedOutputStream(new FileOutputStream(serverFile));
			stream.write(bytes);
			stream.close();
			LOG.info("Server File Location=" + serverFile.getAbsolutePath());
			LOG.info("You successfully uploaded file=" + name);
			return true;
		} catch (Exception e) {
			LOG.error(" You failed to upload " + name + " => " + e.getMessage(), e);
			return false;
		} finally {
			LOG.info("[End] uploadFile");
		}
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         View department and doctor list
	 * 
	 * @param model
	 *            the model
	 * @return ModelAndView
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.INPUT_DEPARTMENT_DOCTOR })
	@RequestMapping(value = "/view-dept-and-doctor", method = RequestMethod.GET)
	public ModelAndView viewDeparmentAndDoctor(ModelMap model) {
		LOG.info("[Start] View department and doctor list");
		List<HospitalModel> listHospitalModel = new ArrayList<>();
		HospitalModel hospitalModel = this.hospitalService
				.findHospitalModelByHospitalId(MssContextHolder.getHospitalId());
		if (hospitalModel != null) {
			listHospitalModel.add(hospitalModel);
		}
		model.addAttribute("listHospitalModel", listHospitalModel);
		LOG.info("[Start] View department and doctor list");
		return new ModelAndView("back.schedule.view.dept.and.doctor");
	}

	/**
	 * Delete hospital.
	 *
	 * @author linh.nguyen.trong
	 * @param hospitalId
	 *            the hospital id
	 * @param redirectAttributes
	 *            the redirect attributes
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@RequestMapping(value = "/delete-hospital")
	public ModelAndView deleteHospital(@RequestParam(value = "hospitalId", required = false) String hospitalId,
			final RedirectAttributes redirectAttributes) {
		LOG.info("[Start] Delete hospital");
		LOG.debug("[UserId] user = " + getSysUser().getLoginId());
		LOG.debug("[Delete hospital] hospitalId = " + hospitalId);
		ModelAndView modelAndView = new ModelAndView(new RedirectView("view-dept-and-doctor"));

		if (StringUtils.isBlank(hospitalId) || !NumberUtils.isDigits(hospitalId)) {
			LOG.warn("[WARN] hospitalId is null or not an integer");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be010.msg.error.delete.hospital")));
			return modelAndView;
		}

		Integer intHospitalId = Integer.valueOf(hospitalId);
		List<DepartmentModel> lstDepartmentModel = this.departmentService.getAllDepartmentInHospital(intHospitalId);
		if (lstDepartmentModel != null && !lstDepartmentModel.isEmpty()) {
			LOG.warn("[WARN] lstDepartmentModel is null or empty");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be010.msg.inform.delete.dept")));
			return modelAndView;
		}

		HospitalModel hospitalModel = this.hospitalService.findHospitalById(intHospitalId);
		try {
			this.hospitalService.deleteHospital(hospitalModel);
		} catch (Exception ex) {
			LOG.error(" Exception: " + ex.getMessage(), ex);
		}

		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("be010.msg.delete.hospital.succ")));
		LOG.info("[End] Delete hospital");
		return modelAndView;
	}

	/**
	 * Delete department
	 * 
	 * @param deptId
	 *            the department id
	 * @param model
	 *            the ModelMap
	 * @param redirectAttributes
	 * @return the ModelAndView
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@RequestMapping(value = "/delete-department")
	public ModelAndView deleteDepartment(@RequestParam(value = "deptId", required = false) String deptId,
			final RedirectAttributes redirectAttributes) {
		LOG.info("[Start] Delete department");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		ModelAndView modelAndView = new ModelAndView(new RedirectView("view-dept-and-doctor"));
		LOG.debug("[Delete department] deptId = " + deptId);
		if (StringUtils.isBlank(deptId) || !NumberUtils.isDigits(deptId)) {
			LOG.warn("[WARN] deptId is null or not an integer");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be010.msg.error.delete.dept")));
			return modelAndView;
		}

		Integer intDeptId = Integer.valueOf(deptId);
		List<DoctorModel> lstDoctorModel = this.doctorService.findDoctorsByDepartment(intDeptId);
		if (lstDoctorModel != null && !lstDoctorModel.isEmpty()) {
			LOG.warn("[WARN] lstDoctorModel is null or empty");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be010.msg.inform.delete.doctor")));
			return modelAndView;
		}

		DepartmentModel departmentModel = this.departmentService.findDepartmentById(intDeptId);
		try {
			// change department's active_flg to 0
			this.departmentService.deleteDepartment(departmentModel);
			// change department schedules's active_flg to 0
			if (!this.departmentScheduleService.deleteDepartmentScheduleByDeptId(intDeptId)) {
				LOG.warn("[WARN] delete Department Schedule By DeptId = " + intDeptId + " is fail");
				this.addNotification(
						new NotificationModel(NotificationType.ERROR, this.getText("be010.msg.error.delete.dept")));
				return modelAndView;
			}
		} catch (Exception ex) {
			LOG.error(" Exception: " + ex.getMessage(), ex);
		}
		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("be010.msg.delete.dept.succ")));
		LOG.info("[End] Delete department");
		return modelAndView;
	}

	/**
	 * @author linh.nguyen.trong
	 * @since 31/07/2014
	 * 
	 *        update junior flg doctor
	 * 
	 * @param doctorId
	 * @param redirectAttributes
	 * @return the ModelAndView
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@RequestMapping(value = "/update-junior-flg-doctor")
	public ModelAndView updateJuniorFlgDoctor(@RequestParam(value = "doctorId", required = false) String doctorId,
			@RequestParam(value = "juniorFlg", required = false) String juniorFlg,
			final RedirectAttributes redirectAttributes) {
		LOG.info("[Start] Update juniorFlg for doctor");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		LOG.debug("[Update juniorFlg] doctorId = " + doctorId + " ,juniorFlg = " + juniorFlg);
		ModelAndView modelAndView = new ModelAndView(new RedirectView("view-dept-and-doctor"));

		if (StringUtils.isBlank(doctorId) || !NumberUtils.isDigits(doctorId) || StringUtils.isBlank(juniorFlg)) {
			LOG.warn("[WARN] doctorId is null or not an integer");
			this.addNotification(new NotificationModel(NotificationType.ERROR,
					this.getText("be010.msg.error.update.junior.doctor")));
			return modelAndView;
		}

		Integer intDoctorId = Integer.valueOf(doctorId);
		DoctorModel doctorModel = this.doctorService.getDoctorByDoctorId(intDoctorId);
		if ("true".equals(juniorFlg)) {
			doctorModel.setJuniorFlg(JuniorFlag.JUNIOR.toInt());
		} else {
			doctorModel.setJuniorFlg(JuniorFlag.SENIOR.toInt());
		}
		try {
			this.doctorService.updateJuniorFlgForDoctor(doctorModel);
		} catch (Exception ex) {
			LOG.error(" Exception: " + ex.getMessage(), ex);
		}

		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("be010.msg.update.junior.doctor.succ")));
		LOG.info("[End] Update juniorFlg for doctor");
		return modelAndView;
	}

	/**
	 * @author linh.nguyen.trong
	 * @since 23/07/2014
	 * 
	 *        Add department
	 * 
	 * @param model
	 *            the model
	 * 
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.INPUT_DEPARTMENT_DOCTOR })
	@RequestMapping(value = "/add-department")
	public ModelAndView addDepartment(@RequestParam(value = "hospitalId", required = false) String hospitalId,
			ModelMap model, HttpSession session) {
		LOG.info("[Start] Add Department");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		LOG.debug("[Add Department] hospitalId = " + hospitalId);
		// clear session validation
		ModelAndView modelAndView = new ModelAndView("back.add.department", "department", new DepartmentModel());
		if (StringUtils.isBlank(hospitalId) || !NumberUtils.isDigits(hospitalId)) {
			LOG.warn("[WARN] hospitalId is null or not an integer");
			return modelAndView;
		}
		HospitalModel hospital = this.hospitalService.findHospitalById(Integer.valueOf(hospitalId));
		model.addAttribute("hospitalName", hospital.getHospitalName());
		session.setAttribute("hospitalId", hospital.getHospitalId());
		session.setAttribute("hospitalName", hospital.getHospitalName());

		Map<Integer, String> deptTypes = referenceData();

		modelAndView.addObject("deptTypes", deptTypes);
		LOG.info("[End] Add Department");
		return modelAndView;
	}

	/**
	 * Accept add department.
	 *
	 * @param departmentModel
	 *            the department model
	 * @param bindingResult
	 *            the binding result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.INPUT_DEPARTMENT_DOCTOR })
	@RequestMapping(value = "/add-department", method = RequestMethod.POST, params = { "validate" })
	public ModelAndView acceptAddDepartment(@ModelAttribute("department") @Valid DepartmentModel departmentModel,
			BindingResult bindingResult, ModelMap model) {
		LOG.info("[Start] Accept add Department");
		LOG.debug("[Add Department] Department name : " + departmentModel.getDeptName());
		LOG.debug("[Add Department] Display order : " + departmentModel.getDisplayOrder());
		LOG.debug("[Add Department] UserId = " + getSysUser().getLoginId());
		ModelAndView modelAndView = new ModelAndView("back.add.department", "department", departmentModel);

		Map<Integer, String> deptTypes = referenceData();

		if (bindingResult.hasErrors()) {
			LOG.warn("Add Department has errors.");
			modelAndView.addObject("deptTypes", deptTypes);
			return modelAndView;
		} else {
			modelAndView.addObject("validation", true);
			modelAndView.addObject("deptTypes", deptTypes);
			return modelAndView;
		}
	}

	/**
	 * Accept add department confirm.
	 *
	 * @param departmentModel
	 *            the department model
	 * @param bindingResult
	 *            the binding result
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.INPUT_DEPARTMENT_DOCTOR })
	@RequestMapping(value = "/add-department", method = RequestMethod.POST)
	public ModelAndView acceptAddDepartmentConfirm(@ModelAttribute("department") @Valid DepartmentModel departmentModel,
			BindingResult bindingResult, ModelMap model, HttpSession session) {
		LOG.info("[End] Accept add department confirm. ");
		LOG.info("[Add department] UserId = " + getSysUser().getLoginId());
		LOG.debug("[Add department] " + departmentModel.toString());
		ModelAndView modelAndView = new ModelAndView(new RedirectView("view-dept-and-doctor"));
		Integer hospitalId = (Integer) session.getAttribute("hospitalId");
		try {
			// clear session validation
			session.removeAttribute("validation");
			String deptName = departmentModel.getDeptName();
			String deptCode = departmentModel.getDeptCode();
			Integer displayOrder = departmentModel.getDisplayOrder();
			Integer deptType = departmentModel.getDeptType();
			this.departmentService.saveDepartment(hospitalId, deptCode, deptName, displayOrder, deptType);
		} catch (Exception ex) {
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be011.msg.add.dept.error")));
			LOG.error(" Exception: " + ex.getMessage(), ex);
		}

		LOG.info("[End] Accept add Department");
		this.addNotification(new NotificationModel(NotificationType.SUCCESS, this.getText("be011.msg.add.dept.succ")));
		return modelAndView;
	}

	/**
	 * @author linh.nguyen.trong
	 * @since 25/07/2014
	 * 
	 * @return map
	 */
	private Map<Integer, String> referenceData() {
		Map<Integer, String> deptTypes = new LinkedHashMap<Integer, String>();
		deptTypes.put(null, getText("be011.label.select.deptType"));
		deptTypes.put(DepartmentType.INTERNAL.toInt(), getText("general.label.internal_department"));
		deptTypes.put(DepartmentType.SURGERY.toInt(), getText("general.label.surgery_department"));
		deptTypes.put(DepartmentType.VACCINE.toInt(), getText("general.label.other"));
		return deptTypes;
	}

	/**
	 * @author Linh.nguyen.trong
	 * @since 25/07/2014
	 * 
	 *        addDoctor
	 * 
	 * @param model
	 *            the model map
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.INPUT_DEPARTMENT_DOCTOR })
	@RequestMapping(value = "/add-doctor")
	public ModelAndView addDoctor(@RequestParam(value = "hospitalId", required = false) String hospitalId,
			@RequestParam(value = "deptId", required = false) String deptId, ModelMap model, HttpSession session) {
		LOG.info("[Start] Add doctor");
		LOG.debug("[Add doctor]. UserId = " + getSysUser().getLoginId());
		LOG.debug("[Add doctor] hospitalId = " + hospitalId + ",deptId=" + deptId);
		ModelAndView modelAndView = new ModelAndView("back.schedule.adding.doctor", "doctor", new DoctorModel());
		;
		if (StringUtils.isBlank(hospitalId) || !NumberUtils.isDigits(hospitalId) || StringUtils.isBlank(deptId)
				|| !NumberUtils.isDigits(deptId)) {
			LOG.warn("[Add doctor] hospitalId is null or not an integer");
			return modelAndView;
		}

		HospitalModel hospital = this.hospitalService.findHospitalById(Integer.valueOf(hospitalId));
		List<DoctorModel> doctorList = this.doctorService.findDoctorsByDepartment(Integer.valueOf(deptId));
		model.addAttribute("hospitalName", hospital.getHospitalName());
		model.addAttribute("doctorList", doctorList);
		session.setAttribute("hospitalName", hospital.getHospitalName());
		session.setAttribute("deptId", deptId);

		LOG.info("[End] Add Doctor");
		return modelAndView;
	}

	/**
	 * Accept add department.
	 * 
	 * @param doctorModel
	 *            the doctor model
	 * @param bindingResult
	 *            the binding result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.INPUT_DEPARTMENT_DOCTOR })
	@RequestMapping(value = "/add-doctor", method = RequestMethod.POST, params = { "validate" })
	public ModelAndView acceptAddDoctor(@ModelAttribute("doctor") @Valid DoctorModel doctorModel,
			BindingResult bindingResult, ModelMap model, HttpSession session) {
		LOG.info("[Start] accept add doctor");
		LOG.debug("[Add doctor]. UserId = " + getSysUser().getLoginId());
		ModelAndView modelAndView = new ModelAndView("back.schedule.adding.doctor", "doctor", doctorModel);
		List<DoctorModel> doctorList = this.doctorService
				.findDoctorsByDepartment(Integer.valueOf(session.getAttribute("deptId").toString()));
		model.addAttribute("doctorList", doctorList);
		if (bindingResult.hasErrors()) {
			LOG.info("[Add doctor] has errors.");
			return modelAndView;
		} else {
			model.addAttribute("validation", true);
			return modelAndView;
		}
	}

	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.INPUT_DEPARTMENT_DOCTOR })
	@RequestMapping(value = "/add-doctor", method = RequestMethod.POST)
	public ModelAndView acceptAddDoctorConfirm(@ModelAttribute("doctor") @Valid DoctorModel doctorModel,
			BindingResult bindingResult, ModelMap model, HttpSession session) {
		LOG.info("[Start] accept add doctor");
		LOG.debug("[Add doctor]. UserId = " + getSysUser().getLoginId());
		ModelAndView modelAndView = new ModelAndView(new RedirectView("view-dept-and-doctor"));
		try {
			String name = doctorModel.getName();
			Integer orderPriority = doctorModel.getOrderPriority();
			Integer deptId = Integer.valueOf(session.getAttribute("deptId").toString());
			Integer copyDoctorId = doctorModel.getCopyDoctorId();
			DoctorModel result = this.doctorService.addDoctor(deptId, name, orderPriority);
			Integer doctorId = result.getDoctorId();
			// generate department schedule
			if (!this.departmentScheduleService.generateDepartmentSchedule(doctorId, deptId, result.getKpiAvg())) {
				LOG.info("[Add doctor] Generate department schedule failed");
			}
			// copy doctor schedule
			if (!Integer.valueOf(-1).equals(copyDoctorId)) {
				if (!this.doctorService.copyDoctorSchedule(copyDoctorId, doctorId)) {
					LOG.info("[Add doctor] Copy schedule failed");
				}
			}
		} catch (Exception ex) {
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be012.msg.add.doctor.error")));
			LOG.error("[Add doctor] Exception: " + ex.getMessage(), ex);
			return modelAndView;
		}

		LOG.info("[End] accept add doctor");
		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("be012.msg.add.doctor.succ")));
		return modelAndView;
	}

	/**
	 * View schedule register default coma.
	 *
	 * @param deptId
	 *            the dept id
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/schedule-register-default-coma", method = RequestMethod.GET)
	public ModelAndView viewScheduleRegisterDefaultComa(
			@RequestParam(value = "deptId", required = true) String deptIdStr, ModelMap model, HttpSession session) {
		LOG.info("[Start] View schedule register default coma.");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		LOG.debug(" View schedule register default coma. deptId = " + deptIdStr);
		session.removeAttribute("defaultComaMap");
		Locale locale = MssContextHolder.getLocale();
		if (StringUtils.isBlank(deptIdStr) || !NumberUtils.isDigits(deptIdStr)) {
			LOG.warn("[WARN] deptIdStr is null or not an integer");
			return new ModelAndView("redirect:schedule-coma-select-department");
		}
		Integer deptId = Integer.valueOf(deptIdStr);
		DepartmentModel dept = departmentService.findDepartmentById(deptId);
		String deptName = dept.getDeptName();
		String hospitalName = dept.getHospitalName();
		MssContextHolder.setScheduleInfo(new ScheduleInfo());
		MssContextHolder.getScheduleInfo().setDeptId(deptId);
		MssContextHolder.getScheduleInfo().setDeptName(deptName);

		// get next 3 months
		Date nowDate = new Date();
		Date firstNextDate = MssDateTimeUtil.getFirstDateOfNextMonth(nowDate);
		Date secondNextDate = MssDateTimeUtil.getFirstDateOfNextMonth(firstNextDate);
		Date thirdNextDate = MssDateTimeUtil.getFirstDateOfNextMonth(secondNextDate);
		List<Date> nextDateList = Arrays.asList(firstNextDate, secondNextDate, thirdNextDate);
		String firstNextMonth = MssDateTimeUtil.getMonthName(firstNextDate, locale);
		String secondNextMonth = MssDateTimeUtil.getMonthName(secondNextDate, locale);
		String thirdNextMonth = MssDateTimeUtil.getMonthName(thirdNextDate, locale);
		session.setAttribute("nextDateList", nextDateList);

		model.addAttribute("hospitalName", hospitalName);
		model.addAttribute("deptName", deptName);
		model.addAttribute("firstNextMonth", firstNextMonth);
		model.addAttribute("secondNextMonth", secondNextMonth);
		model.addAttribute("thirdNextMonth", thirdNextMonth);
		LOG.info("[End] View schedule register default coma.");
		return new ModelAndView("back.schedule.register.default.coma");
	}

	/**
	 * Ajax get default department kpi.
	 *
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-get-default-department-kpi", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetDefaultDepartmentKpi() {
		LOG.info("[Start] Ajax get default department kpi.");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug(" Ajax get default department kpi. deptId is null or not an integer");
		Map<String, DepartmentScheduleModel> result = this.departmentScheduleService
				.getLatestDefaultDepartmentKpi(deptId);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(result);
		LOG.info("[End] Ajax get default department kpi.");
		return builder.build();
	}

	/**
	 * Ajax submit default coma.
	 *
	 * @param value
	 *            the value
	 * @param session
	 *            the session
	 * @return the map
	 */
	@SuppressWarnings("unchecked")
	@RequestMapping(value = "/ajax-submit-default-coma", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxSubmitDefaultComa(@RequestBody DepartmentScheduleModel departmentSchedule,
			HttpSession session) {
		LOG.info("[Start] Ajax submit default coma.");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		DepartmentSchedule saveDepartmentSchedule = new DepartmentSchedule();
        saveDepartmentSchedule.setDepartmentScheduleId(departmentSchedule.getDepartmentScheduleId());
		saveDepartmentSchedule.setKpi(departmentSchedule.getKpi());
		Map<Integer, Integer> defaultComaMap = (Map<Integer, Integer>) session.getAttribute("defaultComaMap");
		if (defaultComaMap == null) {
			defaultComaMap = new HashMap<Integer, Integer>();
		}
		DepartmentSchedule departmentScheduleReturn = this.departmentScheduleService.saveDepartmentSchedule(saveDepartmentSchedule);
		defaultComaMap.put(departmentSchedule.getDepartmentScheduleId(), departmentSchedule.getKpi());
		session.setAttribute("defaultComaMap", defaultComaMap);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.status(HttpStatus.OK);
		LOG.info("[End] Ajax submit default coma.");
		return builder.build();
	}

	/**
	 * Ajax save default coma.
	 *
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@SuppressWarnings("unchecked")
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/ajax-save-default-coma", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSaveDefaultComa(HttpSession session) {
		LOG.info("[Start] Ajax save default coma.");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		Map<Integer, Integer> defaultComaMap = (Map<Integer, Integer>) session.getAttribute("defaultComaMap");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (departmentScheduleService.updateDefaultComa(defaultComaMap)) {
			builder.status(HttpStatus.OK).message(getText("be016.msg.update.success"));
		} else {
			LOG.warn("[WARN] Ajax save default coma is fail");
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("be016.msg.update.fail"));
		}
		session.removeAttribute("defaultComaMap");
		LOG.info("[End] Ajax save default coma.");
		return builder.build();
	}

	/**
	 * View schedule register monthly coma.
	 *
	 * @param next
	 *            the next
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@SuppressWarnings("unchecked")
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/schedule-register-monthly-coma", method = RequestMethod.GET)
	public ModelAndView viewScheduleRegisterMonthlyComa(@RequestParam(value = "next", required = true) String next,
			ModelMap model, HttpSession session) {
		LOG.info("[Start] View schedule register monthly coma.");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug(" View schedule register monthly coma. deptId = " + deptId);
		String deptName = MssContextHolder.getScheduleInfo().getDeptName();
		DepartmentModel dept = departmentService.findDepartmentById(deptId);
		String hospitalName = dept.getHospitalName();
		Locale locale = MssContextHolder.getLocale();
		if (!StringUtils.isBlank(next) && NumberUtils.isDigits(next)) {
			int index = Integer.parseInt(next) - 1;
			if (index >= 0 && index < 3) {
				List<Date> nextDateList = (List<Date>) session.getAttribute("nextDateList");
				Date nextDate = nextDateList.get(index);
				String nextMonth = MssDateTimeUtil.getMonthName(nextDate, locale);

				session.setAttribute("nextDate", nextDate);
				model.addAttribute("hospitalName", hospitalName);
				model.addAttribute("deptName", deptName);
				model.addAttribute("nextMonth", nextMonth);
				return new ModelAndView("back.schedule.register.monthly.coma");
			}
		}
		LOG.info("[End] View schedule register monthly coma.");
		return new ModelAndView(
				"redirect:schedule-register-default-coma?deptId=" + MssContextHolder.getScheduleInfo().getDeptId());
	}

	/**
	 * Ajax get days of month list.
	 *
	 * @param session
	 *            the session
	 * @return the string
	 */
	@RequestMapping(value = "/ajax-get-days-of-month-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetDaysOfMonthList(HttpSession session) {
		LOG.info("[Start] jax get days of month list.");
		Date nextDate = (Date) session.getAttribute("nextDate");
		Calendar c = Calendar.getInstance();
		c.setTime(nextDate);
		Integer month = c.get(Calendar.MONTH);
		Integer year = c.get(Calendar.YEAR);
		String dateStr = month + "_" + year;
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(dateStr);
		LOG.info("[End] jax get days of month list.");
		return builder.build();
	}

	/**
	 * Ajax get monthly department kpi. load a part of monthly data and show on
	 * the screen
	 * 
	 * @param bookingTime
	 *            the booking time
	 * @param session
	 *            the session
	 * @return the map
	 * @throws ParseException
	 *             the parse exception
	 */
	@RequestMapping(value = "/ajax-get-monthly-department-kpi", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetMonthlyDepartmentKpi(@RequestBody BookingTimeModel bookingTime) throws ParseException {
		LOG.info("[Start] Ajax get monthly department kpi.");
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		Map<DoctorScheduleModel, Integer> doctorScheduleMap = this.doctorScheduleService.getMonthlyDepartmentKpi(deptId,
				bookingTime.getStartDate(), bookingTime.getEndDate());
		Map<String, String> result = new HashMap<String, String>();
		String checkDate;
		String startTime;
		Integer doctorId;
		Integer kpi;
		String endTime;
		DoctorScheduleModel entryKey;
		Integer entryValue;
		for (Entry<DoctorScheduleModel, Integer> entry : doctorScheduleMap.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			checkDate = entryKey.getCheckDate();
			startTime = entryKey.getStartTime();
			doctorId = entryKey.getDoctorId();
			kpi = entryValue;
			endTime = entryKey.getEndTime();
			result.put(checkDate + "_" + startTime + "_" + doctorId, kpi + "_" + endTime);
		}
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(result);
		LOG.info("[End] Ajax get monthly department kpi.");
		return builder.build();
	}

	/**
	 * Ajax set monthly coma to session. set whole data of a month and set it to
	 * session
	 *
	 * @param bookingTime
	 *            the booking time
	 * @param session
	 *            the session
	 * @return the ajax response
	 * @throws ParseException
	 *             the parse exception
	 */
	@RequestMapping(value = "/ajax-set-monthly-coma-to-session", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSetMonthlyComaToSession(@RequestBody BookingTimeModel bookingTime, HttpSession session)
			throws ParseException {
		LOG.info("[Start] Ajax set monthly coma to session.");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		LOG.debug("Ajax set monthly coma to session. deptId = " + deptId);
		Map<DoctorScheduleModel, Integer> doctorScheduleMap = this.doctorScheduleService.getMonthlyDepartmentKpi(deptId,
				bookingTime.getStartDate(), bookingTime.getEndDate());
		Map<DoctorSchedulePK, DoctorScheduleModel> monthlyComaMap = new HashMap<DoctorSchedulePK, DoctorScheduleModel>();
		DoctorSchedulePK dspk;
		DoctorScheduleModel dsm;
		DoctorScheduleModel entryKey;
		Integer entryValue;
		for (Entry<DoctorScheduleModel, Integer> entry : doctorScheduleMap.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			dspk = new DoctorSchedulePK();
			dspk.setCheckDate(entryKey.getCheckDate());
			dspk.setStartTime(entryKey.getStartTime());
			dspk.setDoctorId(entryKey.getDoctorId());
			dsm = new DoctorScheduleModel();
			dsm.setEndTime(entryKey.getEndTime());
			dsm.setKpi(entryValue);
			monthlyComaMap.put(dspk, dsm);
		}
		// set to session
		session.setAttribute("monthlyComaMap", monthlyComaMap);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.status(HttpStatus.OK);
		LOG.info("[End] Ajax set monthly coma to session.");
		return builder.build();
	}

	/**
	 * Ajax submit monthly coma.
	 *
	 * @param value
	 *            the value
	 * @param session
	 *            the session
	 * @return the map
	 */
	@SuppressWarnings("unchecked")
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@RequestMapping(value = "/ajax-submit-monthly-coma", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse ajaxSubmitMonthlyComa(@RequestBody DoctorScheduleModel doctorSchedule, HttpSession session) {
		LOG.info("[Start] Ajax submit monthly coma.");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		Map<DoctorSchedulePK, DoctorScheduleModel> monthlyComaMap = (Map<DoctorSchedulePK, DoctorScheduleModel>) session
				.getAttribute("monthlyComaMap");
		DoctorSchedulePK dspk = new DoctorSchedulePK();
		dspk.setCheckDate(doctorSchedule.getCheckDate());
		dspk.setStartTime(doctorSchedule.getStartTime());
		dspk.setDoctorId(doctorSchedule.getDoctorId());
		DoctorScheduleModel dsm = new DoctorScheduleModel();
		if (monthlyComaMap == null) {
			monthlyComaMap = new HashMap<DoctorSchedulePK, DoctorScheduleModel>();
		}
		dsm.setEndTime(doctorSchedule.getEndTime());
		dsm.setKpi(doctorSchedule.getKpi());
		monthlyComaMap.put(dspk, dsm);

		session.setAttribute("monthlyComaMap", monthlyComaMap);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.status(HttpStatus.OK);
		LOG.info("[End] Ajax submit monthly coma.");
		return builder.build();
	}

	/**
	 * Ajax save monthly coma.
	 *
	 * @param session
	 *            the session
	 * @return the map
	 */
	@SuppressWarnings("unchecked")
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.COMA_SETTINGS })
	@RequestMapping(value = "/ajax-save-monthly-coma", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSaveMonthlyComa(HttpSession session) {
		LOG.info("[Start] Ajax save monthly coma.");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		Integer deptId = MssContextHolder.getScheduleInfo().getDeptId();
		DepartmentModel departmentModel = this.departmentService.findDepartmentById(deptId);
		Integer hospitalId = departmentModel.getHospitalId();
		Map<DoctorSchedulePK, DoctorScheduleModel> monthlyComaMap = (Map<DoctorSchedulePK, DoctorScheduleModel>) session
				.getAttribute("monthlyComaMap");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (doctorScheduleService.updateMonthlyComa(monthlyComaMap, hospitalId, deptId)) {
			builder.status(HttpStatus.OK).message(getText("be016-1.msg.update.success"));
		} else {
			LOG.warn("[WARN] Ajax save monthly coma is fail");
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("be016-1.msg.update.fail"));
		}
		LOG.info("[End] Ajax save monthly coma.");
		return builder.build();
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         View department and doctor list
	 * 
	 * @param model
	 *            the model
	 * @return ModelAndView
	 */
	@NavigationConfig(group = { NavigationGroup.SCHEDULE_MANAGEMENT, NavigationGroup.INPUT_DEPARTMENT_DOCTOR })
	@RequestMapping(value = "/delete-doctor", method = RequestMethod.GET)
	public ModelAndView deleteDoctor(@RequestParam("doctorId") String doctorId, ModelMap model) {
		LOG.info("[Start] View department and doctor list");
		LOG.debug("[UserId] UserId = " + getSysUser().getLoginId());
		if (StringUtils.isBlank(doctorId) || !NumberUtils.isDigits(doctorId)) {
			LOG.warn("The reservation is blank or not an integer.");
			return new ModelAndView("redirect:view-dept-and-doctor");
		}
		DoctorModel doctorModel = this.doctorService.getDoctorByDoctorId(Integer.valueOf(doctorId));
		DepartmentModel departmentModel = this.departmentService.findDepartmentById(doctorModel.getDeptId());
		List<ReservationModel> lstReservation = this.scheduleService.getReservationByDoctor(doctorModel.getDoctorId());
		model.addAttribute("hospitalName", departmentModel.getHospitalName());
		model.addAttribute("departmentName", departmentModel.getDeptName());
		model.addAttribute("doctorName", doctorModel.getName());
		model.addAttribute("lstReservation", lstReservation);
		model.addAttribute("doctorId", doctorId);
		LOG.info("[End] View department and doctor list");
		return new ModelAndView("back.delete.doctor");
	}

	/**
	 * Ajax delete doctor.
	 *
	 * @param doctorModel
	 *            the doctor model
	 * @return true, if successful
	 */
	@Secured({ UserRole.ROLE_SCHEDULE_NAME })
	@RequestMapping(value = "/accept-delete-doctor")
	@SessionValidate
	public ModelAndView deleteDoctor(@RequestParam(value = "doctorId", required = false) String doctorId,
			final RedirectAttributes redirectAttributes) {
		LOG.info("[Start] jax delete doctor.");
		LOG.info("[Ajax delete doctor] UserId = " + getSysUser().getLoginId());
		LOG.debug("[Ajax delete doctor] doctorId = " + doctorId);
		ModelAndView modelAndView = new ModelAndView(new RedirectView("view-dept-and-doctor"));
		if (StringUtils.isBlank(doctorId) || !NumberUtils.isDigits(doctorId)) {
			LOG.warn("[Ajax delete doctor] jax delete doctor. doctorId is null or not an integer");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be014.msg.delete.doctor.fail")));
			return modelAndView;
		}

		Integer intDoctorId = Integer.valueOf(doctorId);
		if (this.scheduleService.existReservationOfDoctor(intDoctorId)) {
			LOG.warn("[Ajax delete doctor] Exist Reservation Of Doctor");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be010.msg.error.exist_reservation")));
		} else {
			this.scheduleService.deleteDoctor(intDoctorId);
			this.addNotification(
					new NotificationModel(NotificationType.SUCCESS, this.getText("be014.msg.delete.doctor.success")));
		}
		LOG.info("[End] jax delete doctor.");
		return modelAndView;
	}

	/**
	 * export reservation pending of doctor
	 * 
	 * @param doctorId
	 * @param request
	 * @param response
	 * @throws IOException
	 */
	@RequestMapping(value = "/export-reservation-of-doctor", method = { RequestMethod.GET })
	public void exportCsvReservationOfDoctor(@RequestParam("doctorId") String doctorId, HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		LOG.info("[Start] export reservation pending of doctor");
		if (StringUtils.isBlank(doctorId) || !NumberUtils.isDigits(doctorId)) {
			LOG.debug("The doctorId is blank or not an integer.");
			return;
		}
		List<ReservationModel> lstReservation = this.scheduleService.getReservationByDoctor(Integer.valueOf(doctorId));
		DoctorModel doctorModel = this.doctorService.getDoctorByDoctorId(Integer.valueOf(doctorId));
		String fileName = this.getText("be014.file.name.export.reservation.of.doctor") + "_" + doctorModel.getName()
				+ "_" + MssDateTimeUtil.getCurrentTime(DateTimeFormat.DATE_TIME_FORMAT_YYYYMMDD_HHMMSS) + ".csv";
		fileName = URLEncoder.encode(fileName, "UTF8").replace("+", "%20");
		// Download
		response.setContentType("application/force-download; charset=UTF-8");
		response.setCharacterEncoding("UTF-8");
		response.setHeader("Content-Disposition", "attachment; filename*=UTF-8''" + fileName);

		OutputStream resOs = response.getOutputStream();
		OutputStream buffOs = new BufferedOutputStream(resOs);
		OutputStreamWriter outputwriter = new OutputStreamWriter(buffOs);

		CSVWriter writer = new CSVWriter(outputwriter, ',');
		List<String[]> lstToExport = new ArrayList<>();
		List<String> temp;
		for (ReservationModel reservation : lstReservation) {
			temp = new ArrayList<>();
			temp.add(reservation.getReservationDate());
			temp.add(reservation.getReservationTime());
			temp.add(reservation.getPatientName());
			temp.add(reservation.getEmail());
			temp.add(reservation.getPhoneNumber());
			lstToExport.add((String[]) temp.toArray(new String[temp.size()]));
		}
		writer.writeAll(lstToExport);
		writer.close();
		outputwriter.close();
		LOG.info("[End] export reservation pending of doctor");
	};

	/**
	 * Generate file doctor list.
	 *
	 * @param listHospitalModel
	 *            the list hospital model
	 * @param destDir
	 *            the dest dir
	 * @param fileName
	 *            the file name
	 */
	private File generateFileDoctorList(List<DoctorInfo> lstDoctorInfo, String destDir, String fileName) {
		StringBuilder data = new StringBuilder("");
		if (lstDoctorInfo != null && !lstDoctorInfo.isEmpty()) {
			for (DoctorInfo doctorInfo : lstDoctorInfo) {
				data.append(doctorInfo.getHospitalCode()).append(",");
				if (doctorInfo.getHospitalName() == null) {
					data.append(StringUtils.EMPTY).append(",");
				} else {
					data.append(doctorInfo.getHospitalName()).append(",");
				}
				if (doctorInfo.getDepartmentCode() == null) {
					data.append(StringUtils.EMPTY).append(",");
				} else {
					data.append(doctorInfo.getDepartmentCode()).append(",");
				}
				if (doctorInfo.getDepartmentName() == null) {
					data.append(StringUtils.EMPTY).append(",");
				} else {
					data.append(doctorInfo.getDepartmentName()).append(",");
				}
				if (doctorInfo.getDepartmentType() == null) {
					data.append(StringUtils.EMPTY).append(",");
				} else {
					data.append(doctorInfo.getDepartmentType()).append(",");
				}
				if (doctorInfo.getDepartmentOrder() == null) {
					data.append(StringUtils.EMPTY).append(",");
				} else {
					data.append(doctorInfo.getDepartmentOrder()).append(",");
				}
				data.append(doctorInfo.getDoctorName()).append(",");
				if (doctorInfo.getDoctorOrder() == null) {
					data.append(StringUtils.EMPTY).append(",");
				} else {
					data.append(doctorInfo.getDoctorOrder()).append(",");
				}
				if (doctorInfo.getJuniorFlg() == null) {
					data.append(StringUtils.EMPTY).append(",");
				} else {
					data.append(doctorInfo.getJuniorFlg()).append(",");
				}
				if (doctorInfo.getKpi() == null) {
					data.append(StringUtils.EMPTY).append(",");
				} else {
					data.append(doctorInfo.getKpi()).append(",");
				}
				data.append("\n");
			}
		}

		return MssFileUtils.saveFile(destDir, fileName, data.toString());
	}
}
