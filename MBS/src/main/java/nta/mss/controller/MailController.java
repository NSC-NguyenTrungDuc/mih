package nta.mss.controller;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.regex.Pattern;

import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.validation.Valid;

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
import org.springframework.web.servlet.view.RedirectView;

import nta.kcck.service.impl.KcckDepartmentService;
import nta.kcck.service.impl.KcckDoctorService;
import nta.mss.info.AjaxResponse;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.info.MailInfo;
import nta.mss.info.ReminderMailInfo;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssFileUtils;
import nta.mss.misc.common.SessionValidate;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.SendType;
import nta.mss.misc.enums.NotificationType;
import nta.mss.misc.enums.UserRole;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.DepartmentModel;
import nta.mss.model.DoctorModel;
import nta.mss.model.HospitalModel;
import nta.mss.model.MailListDetailModel;
import nta.mss.model.MailListModel;
import nta.mss.model.MailTemplateModel;
import nta.mss.model.NotificationModel;
import nta.mss.model.SysUserModel;
import nta.mss.model.UploadedFileModel;
import nta.mss.security.WebSysUserDetails;
import nta.mss.service.IDepartmentService;
import nta.mss.service.IDoctorService;
import nta.mss.service.IHospitalService;
import nta.mss.service.IMailService;
import nta.mss.validation.MultipartFileValidator;
import nta.mss.validation.RegularExpressionValidateString;

/**
 * The Class MailController.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 */
@NavigationConfig(leftMenuType = NavigationType.BACK_LEFT_MENU)
@Controller
@Scope("prototype")
@RequestMapping(value = "/mail")
public class MailController extends BaseController {
	private static final Pattern EMAIL_PATTERN = Pattern
			.compile("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$");

	private static final Logger LOG = LogManager.getLogger(MailController.class);
	/** The Mail Service. */
	private IMailService mailService;

	private MultipartFileValidator fileValidator;

	private IHospitalService hospitalService;

	private IDepartmentService departmentService;

	private IDoctorService doctorService;

	private KcckDepartmentService kcckDepartmentService = new KcckDepartmentService();
	private KcckDoctorService kcckDoctorService = new KcckDoctorService();

	public MailController() {
		super();
	}

	@Autowired
	public MailController(IMailService mailService, MultipartFileValidator fileValidator,
			IHospitalService hospitalService, IDepartmentService departmentService, IDoctorService doctorService) {
		this.mailService = mailService;
		this.fileValidator = fileValidator;
		this.hospitalService = hospitalService;
		this.departmentService = departmentService;
		this.doctorService = doctorService;
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
	 * @author linh.nguyen.trong
	 * @since 07/08/2014
	 * 
	 * @param mailListModel
	 *            the mail list model
	 * @param modelMap
	 *            the model map
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "/mail-reminder-mail-list-check", method = { RequestMethod.GET })
	public ModelAndView reminderMailingList(@ModelAttribute("mailList") MailListModel mailListModel,
			ModelMap modelMap) {
		LOG.info("[Start] Reminder mail list ");
		Map<Integer, String> mapMailList = createMailListNames();

		ModelAndView modelAndView = new ModelAndView("back.mail.reminder.mailing.list.check");
		modelAndView.addObject("mailListNames", mapMailList);
		LOG.info("[End] Reminder mail list ");
		return modelAndView;
	}

	/**
	 * @author linh.nguyen.trong
	 * @since 07/08/2014
	 * 
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "/mail-add-new-mail-list", method = { RequestMethod.GET })
	public ModelAndView addNewMailList() {
		LOG.info("[Start] Add new mail list");
		ModelAndView mav = new ModelAndView("back.add.new.mailing.list");
		LOG.info("[End] Add new mail list");
		return mav;
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Get list reminder info
	 * 
	 * @param lstReminderInfo
	 * @param session
	 * @return
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@RequestMapping(value = "/ajax-mail-get-list-reminder-info", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetListReminderInfo(@RequestBody List<ReminderMailInfo> lstReminderInfo,
			HttpSession session) {
		LOG.info("[Start] Get list reminder info");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		RegularExpressionValidateString validate = new RegularExpressionValidateString();
		for (ReminderMailInfo reminderMailInfo : lstReminderInfo) {
			if (validate.regularExpressionValidate(reminderMailInfo.getMail().trim(), EMAIL_PATTERN) == false) {
				List<ReminderMailInfo> lstReminderInfoError = new ArrayList<ReminderMailInfo>();
				lstReminderInfoError.add(reminderMailInfo);
				builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be041.msg.error.email"));
				builder.data(lstReminderInfoError);
				return builder.build();
			}
		}
		// Validate duplicate email
		Set<ReminderMailInfo> reminderMailInfoSet = new HashSet<ReminderMailInfo>();
		Set<ReminderMailInfo> reminderMailInfoErrorSet = new HashSet<ReminderMailInfo>();
		for (ReminderMailInfo reminderMailInfo : lstReminderInfo) {
			if (!reminderMailInfoSet.add(reminderMailInfo)) {
				reminderMailInfoErrorSet.add(reminderMailInfo);
			}
		}
		// add negative condition
		if (!reminderMailInfoErrorSet.isEmpty()) {
			List<ReminderMailInfo> lstReminderInfoDuplicate = new ArrayList<ReminderMailInfo>(reminderMailInfoErrorSet);
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
					.message(this.getText("be041.msg.update.mail.list.duplicate"));
			builder.data(lstReminderInfoDuplicate);
			return builder.build();
		}
		session.setAttribute("lstReminderInfo", lstReminderInfo);
		builder.status(HttpStatus.OK).data("mail-pre-save-mail-list");
		LOG.info("[End] Get list reminder info");
		return builder.build();
	}

	/**
	 * Pre save mail list.
	 *
	 * @author linh.nguyen.trong
	 * @param mailList
	 *            the mail list
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "mail-pre-save-mail-list", method = { RequestMethod.GET })
	@SuppressWarnings("unchecked")
	public ModelAndView preSaveMailList(@ModelAttribute("mailListModel") MailListModel mailList, HttpSession session) {
		LOG.info("[Start] Pre save mail list.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		ModelAndView mav = new ModelAndView("back.save.mail.list", "mailListModel", mailList);
		List<ReminderMailInfo> lstReminderInfo = (List<ReminderMailInfo>) session.getAttribute("lstReminderInfo");
		if (lstReminderInfo == null || lstReminderInfo.isEmpty()) {
			LOG.warn("[WARN] Pre save mail list. lstReminderInfo is null or empty.");
			return mav;
		}
		mailList.setReminderMails(lstReminderInfo);
		LOG.info("[End] Pre save mail list.");
		return mav;
	}

	/**
	 * Save mail list.
	 *
	 * @author linh.nguyen.trong
	 * @param mailListModel
	 *            the mail list model
	 * @param bindingResult
	 *            the binding result
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "mail-save-mail-list-confirm", method = { RequestMethod.POST })
	@SuppressWarnings("unchecked")
	public ModelAndView saveMailList(@ModelAttribute("mailListModel") @Valid MailListModel mailListModel,
			BindingResult bindingResult, HttpSession session) {
		LOG.info("[Start] Save MailList");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		List<ReminderMailInfo> lstReminderInfo = (List<ReminderMailInfo>) session.getAttribute("lstReminderInfo");
		mailListModel.setReminderMails(lstReminderInfo);
		ModelAndView modelAndView = new ModelAndView("back.save.mail.list", "mailListModel", mailListModel);
		if (bindingResult.hasErrors()) {
			LOG.warn("[WARN]Add mail list has errors.");
			return modelAndView;
		}
		try {
			String mailListName = mailListModel.getMailListName();
			this.mailService.saveMailList(mailListName, lstReminderInfo, MssContextHolder.getHospitalId());
			session.removeAttribute("lstReminderInfo");
		} catch (Exception ex) {
			LOG.error(" ERROR:" + ex.getMessage(), ex);
		}

		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("be042.msg.add.mailList.success")));
		LOG.info("[End] Save MailList");
		return new ModelAndView(new RedirectView("mail-reminder-mail-list-check"));
	}

	/**
	 * Send email.
	 *
	 * @author linh.nguyen.trong
	 * @param mailListModel
	 *            the mail list model
	 * @param model
	 *            the model
	 * @return the model and view
	 * @since 20140813
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "mail-send-email", method = { RequestMethod.GET })
	public ModelAndView sendEmail(@ModelAttribute("mailList") MailListModel mailListModel, ModelMap model) {
		LOG.info("[Start] Send email.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		Integer mailListId = mailListModel.getMailListId();
		LOG.debug("Send email with mailListId = " + mailListId);
		if (mailListId == null || mailListId == -1) {
			LOG.warn("[WARN] Send email. mailListId is null ");
			Map<Integer, String> mapMailList = createMailListNames();
			ModelAndView mav = new ModelAndView("back.mail.reminder.mailing.list.check", "mailList",
					new MailListModel());
			mav.addObject("mailListNames", mapMailList);
			mav.addObject("message", this.getText("be040.msg.select.mailList.error"));
			return mav;
		}
		try {
			// Get mailListModel by id
			mailListModel = this.mailService.findByMailListId(mailListId);
			// Get list mailListDetail
			List<MailListDetailModel> mailListDetailModels = this.mailService.getMailListDetail(mailListId,
					ActiveFlag.ACTIVE.toInt());
			// Get mailTemplateModel List
			List<MailTemplateModel> mailTemplateList = mailService
					.findAllTemplateCustomize(MssContextHolder.getHospitalId(), MssContextHolder.getUserLanguage());

			// Map<Integer, String> hospitals = new LinkedHashMap<>();
			// List<HospitalModel> lstHospitalModel =
			// hospitalService.findAllHospital();
			List<DepartmentModel> lstDepartmentModel;
			if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
				if (MssContextHolder.getKcckDepartmentList() == null) {
					lstDepartmentModel = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
							MssContextHolder.getLocale().toString());
					MssContextHolder.setKcckDepartmentList(lstDepartmentModel);
				} else {
					lstDepartmentModel = MssContextHolder.getKcckDepartmentList();
				}
			} else {
				lstDepartmentModel = departmentService.getAllDepartmentInHospital(MssContextHolder.getHospitalId());
			}
			model.addAttribute("departmentList", lstDepartmentModel);
			model.addAttribute("mailListDetails", mailListDetailModels);
			model.addAttribute("mailList", mailListModel);
			model.addAttribute("mailTemplate", mailTemplateList);
		} catch (Exception ex) {
			LOG.error(ex.getMessage(), ex);
		}
		LOG.info("[END] Send email.");
		return new ModelAndView("back.mail.list.send");
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
		if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			if (MssContextHolder.getKcckDepartmentList() == null) {
				lstDepartmentModel = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
						MssContextHolder.getLocale().toString());
				MssContextHolder.setKcckDepartmentList(lstDepartmentModel);
			} else {
				lstDepartmentModel = MssContextHolder.getKcckDepartmentList();
			}
		} else {
			lstDepartmentModel = departmentService.getAllDepartmentInHospital(MssContextHolder.getHospitalId());
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
	 * Ajax get doctor in department.
	 *
	 * @param departmentModel
	 *            the department model
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-get-doctor-in-department", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetDoctorInDepartment(@RequestBody DepartmentModel departmentModel) {
		LOG.info("[Start] Ajax get doctor in department.");
		Map<Integer, String> doctors = new LinkedHashMap<>();
		List<DoctorModel> lstDoctorModel;
		if (departmentModel.getDeptId() != null) {
			if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
				DepartmentModel model = kcckDepartmentService.findKcckDepartmentById(MssContextHolder.getHospCode(),
						MssContextHolder.getLocale().toString(), departmentModel.getDeptId());
				lstDoctorModel = this.kcckDoctorService.getListKcckDoctor(MssContextHolder.getHospCode(),
						model.getDeptCode());
			} else {
				lstDoctorModel = this.doctorService.findDoctorsByDepartment(departmentModel.getDeptId());
			}
			for (DoctorModel doctorModel : lstDoctorModel) {
				doctors.put(doctorModel.getDoctorId(), doctorModel.getName());
			}
		}
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(doctors);
		LOG.info("[End] Ajax get doctor in department.");
		return builder.build();
	}


	/**
	 * @author linh.nguyen.trong
	 * @see 20140814
	 * 
	 *      Ajax send mail list comfirm
	 * 
	 * @param lstMailListDetailModel
	 * @param session
	 * @return
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@RequestMapping(value = "ajax-mail-send-mail-list-confirm", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSendMailListConfirm(@RequestBody List<MailListDetailModel> lstMailListDetailModel,
			HttpSession session) {
		LOG.info("[Start] Ajax send mail list comfirm");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (lstMailListDetailModel == null || lstMailListDetailModel.isEmpty()) {
			LOG.warn("[WARN] Ajax send mail list comfirm. lstMailListDetailModel is null or empty");
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("be043.msg.mail.confirm.fail"));
		} else {
			builder.status(HttpStatus.OK);
			session.setAttribute("lstMailListDetailModel", lstMailListDetailModel);
			builder.data("mail-send-mail-list-confirm");
		}
		LOG.info("[End] Ajax send mail list comfirm");
		return builder.build();
	}

	/**
	 * @author linh.nguyen.trong
	 *
	 *         View mail list sending confirmation
	 * 
	 * @param templateId
	 * @param model
	 * @param session
	 * @return
	 */
	@SuppressWarnings("unchecked")
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "mail-send-mail-list-confirm", method = { RequestMethod.GET })
	public ModelAndView viewMailListSendingConfirmation(@RequestParam(value = "templateId") String templateId,
			@RequestParam(value = "doctorId") String doctorId, ModelMap model, HttpSession session) {
		LOG.info("[Start] View mail list sending confirmation");
		LOG.debug("View mail list sending confirmation. templateId = " + templateId + " ,doctorId = " + doctorId);
		if (templateId == null || StringUtils.isBlank(templateId) || !NumberUtils.isDigits(templateId)) {
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be043.msg.enter.mail.temp")));
			LOG.warn("[WARN] View mail list sending confirmation. templateId is null or not an integer");
			return new ModelAndView("back.send.mail.list.confirm");
		} else {
			List<MailListDetailModel> lstMailListDetailModel = (List<MailListDetailModel>) session
					.getAttribute("lstMailListDetailModel");

			// get MailTemplate by code and set it to session
			MailTemplateModel mailTemplate = mailService.getMailTemplateById(Integer.valueOf(templateId));

			session.setAttribute("mailTemplateCode", mailTemplate.getTemplateCode());
			session.setAttribute("subject", mailTemplate.getSubject());
			session.setAttribute("doctorId", doctorId);
			model.addAttribute("mailTemplate", mailTemplate);
			model.addAttribute("mailListDetails", lstMailListDetailModel);
			LOG.info("[Start] View mail list sending confirmation");
			return new ModelAndView("back.send.mail.list.confirm");
		}

	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Submit send mail list.
	 *
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@SuppressWarnings("unchecked")
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "mail-send-mail-list-submit", method = { RequestMethod.POST })
	public ModelAndView submitSendMailList(HttpSession session) {
		LOG.info("[Start] Submit send mail list.");
		List<MailListDetailModel> lstMailListDetailModel = (List<MailListDetailModel>) session
				.getAttribute("lstMailListDetailModel");
		String mailTemplateCode = session.getAttribute("mailTemplateCode").toString();
		String doctorId = StringUtils.EMPTY;
		if (session.getAttribute("doctorId") != null) {
			doctorId = (String) session.getAttribute("doctorId");
		}
		try {
			HospitalModel hospital = this.hospitalService.findHospital(MssContextHolder.getHospitalId());
			for (MailListDetailModel mailListDetailModel : lstMailListDetailModel) {
				MailInfo mailInfo = new MailInfo();
				mailInfo.setPatientName(mailListDetailModel.getName());
				mailInfo.setUserName(mailListDetailModel.getName());
				mailInfo.setHospitalPhone(hospital.getPhoneNumber());
				mailInfo.setHospitalName(hospital.getHospitalName());
				mailInfo.setLinkThankYou(MssContextHolder.getDomainName() + this.getText("be030.link.thank.you"));
				mailInfo.setDoctorId(doctorId);
				if (StringUtils.isBlank(doctorId)) {
					mailInfo.setLinkReminderEmail(
							MssContextHolder.getDomainName() + this.getText("be030.link.for.booking.new"));
				} else {
					mailInfo.setLinkReminderEmail(
							MssContextHolder.getDomainName() + this.getText("be030.link.for.reminder") + doctorId);
				}
				sendMailToPatient(mailListDetailModel, mailTemplateCode, mailInfo, hospital.getHospitalId());
			}
		} catch (Exception e) {
			LOG.error("ERROR: " + e.getMessage());
		}
		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("be043.msg.send.email.success")));
		LOG.info("[End] Submit send mail list.");
		return new ModelAndView(new RedirectView("mail-reminder-mail-list-check"));
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Ajax delete mail list.
	 *
	 * @param mailListModel
	 *            the mail list model
	 * @return the ajax response
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@RequestMapping(value = "mail-ajax-delete-mail-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxDeleteMailList(@RequestBody MailListModel mailListModel) {
		LOG.info("[Start] Ajax delete mail list.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Integer mailListId = mailListModel.getMailListId();
		LOG.debug("Ajax delete mail list. mailListId = " + mailListId);
		if (mailListId == null || mailListId == -1) {
			LOG.warn("[WARN] Ajax delete mail list. mailListId is null");
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be040.msg.select.mailList.error"));
			return builder.build();
		}
		try {
			mailListModel = this.mailService.findByMailListId(mailListId);
			List<MailListDetailModel> lstMailListDetailModel = this.mailService.getMailListDetail(mailListId,
					ActiveFlag.ACTIVE.toInt());
			this.mailService.deleteMailList(mailListModel, lstMailListDetailModel);
		} catch (Exception ex) {
			LOG.error("ERROR: " + ex.getMessage(), ex);
		}
		builder.status(HttpStatus.OK).message(this.getText("be040.msg.delete.mailList.succ"));
		builder.data("mail-reminder-mail-list-check");
		LOG.info("[Start] Ajax delete mail list.");
		return builder.build();
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Update mail list.
	 *
	 * @param modelMap
	 *            the model map
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "mail-update-mail-list", method = { RequestMethod.GET })
	public ModelAndView updateMailList(@RequestParam("mailListId") String strMailListId, HttpSession session,
			ModelMap model) {
		LOG.info("[Start] Update mail list.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		LOG.debug("Ajax delete mail list. mailListId = " + strMailListId);
		MailListModel mailListModel = new MailListModel();
		if (strMailListId == null || StringUtils.isBlank(strMailListId) || !NumberUtils.isDigits(strMailListId)) {
			LOG.warn("[WARN] Update mail list.");
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be040.msg.select.mailList.error")));
			return new ModelAndView(new RedirectView("mail-reminder-mail-list-check"));
		}
		Integer mailListId = Integer.valueOf(strMailListId);
		try {
			mailListModel = this.mailService.findByMailListId(mailListId);
			List<MailListDetailModel> mailListDetailModels = this.mailService.getMailListDetail(mailListId,
					ActiveFlag.ACTIVE.toInt());
			mailListModel.setMailListDetailModels(mailListDetailModels);
			session.setAttribute("mailListId", mailListId);
		} catch (Exception ex) {
			LOG.error("ERROR: " + ex.getMessage(), ex);
		}

		ModelAndView modelAndView = new ModelAndView("back.add.new.mailing.list", "mailList", mailListModel);
		model.addAttribute("mailListModel", mailListModel);
		LOG.info("[End] Update mail list.");
		return modelAndView;
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Delete mail list detail.
	 *
	 * @param mailListDetailModel
	 *            the mail list detail model
	 * @return the ajax response
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@RequestMapping(value = "mail-ajax-delete-mail-detail", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxDeleteMailListDetail(@RequestBody MailListDetailModel mailListDetailModel) {
		LOG.info("[Start] Delete mail list detail.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Integer mailListId = mailListDetailModel.getMailListId();
		String email = mailListDetailModel.getEmail();
		if (mailListId == null || StringUtils.isBlank(email)) {
			LOG.warn("[WARN] mailListId is null or email is null");
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
					.message(this.getText("be046.msg.delete.mail.detail.error"));
		}
		try {
			mailListDetailModel = this.mailService.findByMailListIdAndEmail(mailListId, email);
			mailListDetailModel.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			this.mailService.updateMailListDetail(mailListDetailModel);

			builder.status(HttpStatus.OK).message(this.getText("be046.msg.delete.mail.detail.succ"));
		} catch (Exception e) {
			LOG.error("ERROR: " + e.getMessage(), e);
		}
		LOG.info("[Start] Delete mail list detail.");
		return builder.build();
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Ajax update mail list.
	 *
	 * @param lstReminderMailInfo
	 *            the lst reminder mail info
	 * @return the ajax response
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "ajax-mail-update-mail-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxUpdateMailList(@RequestBody List<ReminderMailInfo> lstReminderMailInfo,
			HttpSession session) {
		LOG.info("[Start] Ajax update mail list.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (lstReminderMailInfo == null || lstReminderMailInfo.isEmpty()) {
			LOG.warn("[WARN] Ajax update mail list. lstReminderMailInfo is null or is empty");
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
					.message(this.getText("be041.msg.update.mail.list.null.error"));
			return builder.build();
		}
		// Validate format email
		RegularExpressionValidateString validate = new RegularExpressionValidateString();
		for (ReminderMailInfo reminderMailInfo : lstReminderMailInfo) {
			if (validate.regularExpressionValidate(reminderMailInfo.getMail().trim(), EMAIL_PATTERN) == false) {
				List<ReminderMailInfo> lstReminderInfoError = new ArrayList<ReminderMailInfo>();
				lstReminderInfoError.add(reminderMailInfo);
				builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be041.msg.error.email"));
				builder.data(lstReminderInfoError);
				return builder.build();
			}
		}
		// Validate duplicate email
		Set<ReminderMailInfo> reminderMailInfoSet = new HashSet<ReminderMailInfo>();
		Set<ReminderMailInfo> reminderMailInfoErrorSet = new HashSet<ReminderMailInfo>();
		for (ReminderMailInfo reminderMailInfo : lstReminderMailInfo) {
			if (!reminderMailInfoSet.add(reminderMailInfo)) {
				reminderMailInfoErrorSet.add(reminderMailInfo);
			}
		}
		// add negative condition
		if (!reminderMailInfoErrorSet.isEmpty()) {
			List<ReminderMailInfo> lstReminderInfoDuplicate = new ArrayList<ReminderMailInfo>(reminderMailInfoErrorSet);
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR)
					.message(this.getText("be041.msg.update.mail.list.duplicate"));
			builder.data(lstReminderInfoDuplicate);
			return builder.build();
		}
		session.setAttribute("lstReminderInfo", lstReminderMailInfo);
		builder.status(HttpStatus.OK).data("mail-confirm-update-mail-list");
		LOG.info("[End] Ajax update mail list.");
		return builder.build();
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Confirm update mail list.
	 *
	 * @param mailList
	 *            the mail list
	 * @param session
	 *            the session
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "mail-confirm-update-mail-list", method = { RequestMethod.GET })
	@SuppressWarnings("unchecked")
	public ModelAndView confirmUpdateMailList(@ModelAttribute("mailListModel") MailListModel mailList,
			HttpSession session) {
		LOG.info("[Start] Confirm update mail list.");
		List<ReminderMailInfo> lstReminderInfo = (List<ReminderMailInfo>) session.getAttribute("lstReminderInfo");
		try {
			mailList = this.mailService.findByMailListId(lstReminderInfo.get(0).getMailListId());
			mailList.setReminderMails(lstReminderInfo);
		} catch (Exception e) {
			LOG.error("ERROR: " + e.getMessage(), e);
		}
		LOG.info("[End] Confirm update mail list.");
		return new ModelAndView("back.save.mail.list", "mailListModel", mailList);
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Import csv.
	 *
	 * @param uploadedFile
	 *            the uploaded file
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_MAIL_SENDING_NAME })
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "mail-import-csv", method = { RequestMethod.POST })
	public ModelAndView importCsv(@ModelAttribute("uploadedFile") UploadedFileModel uploadedFile, BindingResult result,
			ModelMap model, HttpSession session) {
		LOG.info("[Start] Import csv for mail list");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		// TODO: validate
		MultipartFile file = uploadedFile.getFile();
		fileValidator.validate(file, result);
		if (result.hasErrors()) {
			Map<Integer, String> mailListNames = createMailListNames();
			ModelAndView mav = new ModelAndView("back.mail.reminder.mailing.list.check", "mailList",
					new MailListModel());
			mav.addObject("mailListNames", mailListNames);
			return mav;
		}
		try {
			String name = file.getOriginalFilename();
			if (!uploadFile(file, name)) {
				LOG.warn("[WARN] Import csv for mail list is fail");
				result.reject("be040.msg.upload.fail");
			} else {
				this.mailService.processMailCsv(name);
			}

		} catch (Exception e) {
			LOG.error("ERROR: " + e.getMessage());
		}
		this.addNotification(new NotificationModel(NotificationType.SUCCESS, this.getText("be040.msg.upload.success")));
		LOG.info("[End] Import csv for mail list");
		return new ModelAndView(new RedirectView("mail-reminder-mail-list-check"));
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Export csv.
	 *
	 * @param strMailListId
	 *            the str mail list id
	 * @param session
	 *            the session
	 * @param model
	 *            the model
	 */
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAILING_LIST })
	@RequestMapping(value = "mail-export-csv-mailList", method = { RequestMethod.GET })
	public void exportCsv(@RequestParam("mailListId") String strMailListId, HttpServletResponse response,
			HttpSession session, ModelMap model) {
		LOG.info("[Start] Export csv for mail list");
		if (StringUtils.isBlank(strMailListId) || !NumberUtils.isDigits(strMailListId)) {
			return;
		}
		InputStream inputStream = null;
		Integer mailListId = Integer.valueOf(strMailListId);
		LOG.debug("Export csv for mail list. mailListId = " + mailListId);
		try {
			MailListModel mailListModel = this.mailService.findByMailListId(mailListId);
			List<MailListDetailModel> lstMailListDetailModel = this.mailService.getMailListDetail(mailListId,
					ActiveFlag.ACTIVE.toInt());

			String destDir = MssConfiguration.getInstance().getDirFileUpload();
			File file = generateFileMailList(lstMailListDetailModel, destDir, mailListModel.getMailListName() + ".csv");
			if (file == null) {
				LOG.debug("Export csv for mail list. File is null");
				return;
			}
			String fileName = URLEncoder.encode(file.getName(), "UTF-8").replace("+", "%20");
			// Download
			inputStream = new FileInputStream(file);
			response.setContentType("application/force-download; charset=UTF-8");
			response.setCharacterEncoding("UTF-8");
			response.setHeader("Content-Disposition", "attachment; filename*=UTF-8''" + fileName);
			IOUtils.copy(inputStream, response.getOutputStream());
			response.flushBuffer();
		} catch (Exception e) {
			LOG.error("ERROR: " + e.getMessage());
		} finally {
			if (inputStream != null) {
				try {
					inputStream.close();
				} catch (IOException e) {
					LOG.error("[ERROR] Cannot close the input stream", e.getMessage());
				}
			}
		}
		LOG.info("[End] Export csv for mail list");
	}

	/**
	 * View mail template list.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.TEMPLATE ,NavigationGroup.MAIL_TEMPLATE })
	@RequestMapping(value = "/mail-template-list", method = RequestMethod.GET)
	public ModelAndView viewMailTemplateList(ModelMap model) {
		LOG.info("[Start] View mail template list.");
		List<MailTemplateModel> mailTemplateList = this.mailService.getAllActiveMailTemplatesByHospitalId(
				MssContextHolder.getHospitalId(), MssContextHolder.getUserLanguage());
		model.addAttribute("mailTemplateList", mailTemplateList);
		LOG.info("[End] View mail template list.");
		return new ModelAndView("back.mail.template.list");
	}
	/**
	 * View sms template list.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.TEMPLATE ,NavigationGroup.SMS_TEMPLATE })
	@RequestMapping(value = "/sms-template-list", method = RequestMethod.GET)
	public ModelAndView viewSmsTemplateList(ModelMap model) {
		LOG.info("[Start] View sms template list.");
		List<MailTemplateModel> mailTemplateList = this.mailService.getAllActiveSmsTemplatesByHospitalId(
				MssContextHolder.getHospitalId(), MssContextHolder.getUserLanguage());
		model.addAttribute("mailTemplateList", mailTemplateList);
		LOG.info("[End] View sms template list.");
		return new ModelAndView("back.sms.template.list");
	}

	/**
	 * Ajax delete mail template.
	 *
	 * @param mailTemplateModel
	 *            the mail template model
	 * @return the map
	 */
	@RequestMapping(value = "/ajax-delete-mail-template", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxDeleteMailTemplate(@RequestBody MailTemplateModel mailTemplateModel) {
		LOG.info("[Start] Ajax delete mail template.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (this.mailService.deleteMailTemplate(mailTemplateModel)) {
			builder.status(HttpStatus.OK).message(this.getText("be030.msg.delete.success"));
		} else {
			LOG.warn("[WARN] Ajax delete template is fail.");
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be030.msg.delete.fail"));
		}
		LOG.info("[End] Ajax delete template.");
		return builder.build();
	}
//TODO
	/**
	 * View mail template detail.
	 *
	 * @param mailTemplateId
	 *            the mail template id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.TEMPLATE ,NavigationGroup.MAIL_TEMPLATE })
	@RequestMapping(value = "/mail-template-detail")
	public ModelAndView viewMailTemplateDetail(
			@RequestParam(value = "mailTemplateId", required = false) String mailTemplateId, ModelMap model) {
		LOG.info("[Start] View mail template detail.");
		MailTemplateModel mailTemplateModel = new MailTemplateModel();
		if (mailTemplateId != null && !StringUtils.isBlank(mailTemplateId) && NumberUtils.isDigits(mailTemplateId)) {
			mailTemplateModel = this.mailService.getMailTemplateById(Integer.valueOf(mailTemplateId));
			model.addAttribute("isUpdate", true);
		}
		model.addAttribute("mailTemplate", mailTemplateModel);
		
		LOG.info("[End] View mail template detail.");
		return new ModelAndView("back.mail.template.detail");

	}
	/**
	 * View mail template detail.
	 *
	 * @param mailTemplateId
	 *            the mail template id
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.TEMPLATE ,NavigationGroup.SMS_TEMPLATE })
	@RequestMapping(value = "/sms-template-detail")
	public ModelAndView viewSmsTemplateDetail(
			@RequestParam(value = "mailTemplateId", required = false) String mailTemplateId, ModelMap model) {
		LOG.info("[Start] View sms template detail.");
		MailTemplateModel mailTemplateModel = new MailTemplateModel();
		if (mailTemplateId != null && !StringUtils.isBlank(mailTemplateId) && NumberUtils.isDigits(mailTemplateId)) {
			mailTemplateModel = this.mailService.getMailTemplateById(Integer.valueOf(mailTemplateId));
			model.addAttribute("isUpdate", true);
		}
		model.addAttribute("mailTemplate", mailTemplateModel);
		LOG.info("[End] View sms template detail.");
		return new ModelAndView("back.sms.template.detail");

	}

	/**
	 * Save mail template.
	 *
	 * @param mailTemplateModel
	 *            the mail template model
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.TEMPLATE, NavigationGroup.MAIL_TEMPLATE })
	@RequestMapping(value = "/mail-template-detail", method = RequestMethod.POST, params = { "validate" })
	public ModelAndView saveMailTemplate(@Valid @ModelAttribute("mailTemplate") MailTemplateModel mailTemplateModel,
			BindingResult result, ModelMap model) {
		LOG.info("[Start] Save mail template.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		ModelAndView modelAndView = new ModelAndView("back.mail.template.detail");

		if (this.mailService.getMailTemplate(mailTemplateModel.getTemplateCode(),
				MssContextHolder.getLocale().toString(), MssContextHolder.getHospitalId()) != null
				&& mailTemplateModel.getMailTemplateId() == null) {
			result.rejectValue("templateCode", "be031.validate.templace.code");
			LOG.info(" Mail Template Code is duplicate");
		}
		if (result.hasErrors()) {
			LOG.warn("[WARN] Save mail template is error");
			LOG.info("[Start] Save mail template.");
			return modelAndView;
		} else {
			model.addAttribute("validation", true);
			LOG.info("[Start] Save mail template.");
			return modelAndView;
		}
	}
	//TODO
	/**
	 * Save SMS template.
	 *
	 * @param mailTemplateModel
	 *            the mail template model
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.TEMPLATE, NavigationGroup.SMS_TEMPLATE })
	@RequestMapping(value = "/sms-template-detail", method = RequestMethod.POST, params = { "validate" })
	public ModelAndView saveSmsTemplate(@Valid @ModelAttribute("mailTemplate") MailTemplateModel mailTemplateModel,
			BindingResult result, ModelMap model) {
		LOG.info("[Start] Save sms template.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		ModelAndView modelAndView = new ModelAndView("back.sms.template.detail");

		if (this.mailService.getMailTemplate(mailTemplateModel.getTemplateCode(),
				MssContextHolder.getLocale().toString(), MssContextHolder.getHospitalId()) != null
				&& mailTemplateModel.getMailTemplateId() == null) {
			result.rejectValue("templateCode", "be031.validate.templace.code");
			LOG.info("SMS Template Code is duplicate");
		}
		if (result.hasErrors()) {
			LOG.warn("[WARN] Save sms template is error");
			LOG.info("[Start] Save sms template.");
			return modelAndView;
		} else {
			model.addAttribute("validation", true);
			LOG.info("[Start] Save sms template.");
			return modelAndView;
		}
	}

	/**
	 * Save mail template confirm.
	 *
	 * @param mailTemplateModel
	 *            the mail template model
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.TEMPLATE ,NavigationGroup.MAIL_TEMPLATE })
	@RequestMapping(value = "/mail-template-detail", method = RequestMethod.POST)
	public ModelAndView saveMailTemplateConfirm(
			@Valid @ModelAttribute("mailTemplate") MailTemplateModel mailTemplateModel, BindingResult result,
			ModelMap model) {
		LOG.info("[Start] Save mail template confirm.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		mailTemplateModel.setHospitalId(MssContextHolder.getHospitalId());
		mailTemplateModel.setLocale(MssContextHolder.getHospitalLocale());
		mailTemplateModel.setSendType(1);

		if (this.mailService.updateMailTemplate(mailTemplateModel)) {
			this.addNotification(
					new NotificationModel(NotificationType.SUCCESS, this.getText("be030.msg.update.success")));
		} else {
			this.addNotification(new NotificationModel(NotificationType.ERROR, this.getText("be030.msg.update.fail")));
		}
		LOG.info("[End] Save mail template confirm.");
		return new ModelAndView(new RedirectView("mail-template-list"));
	}
	/**
	 * Save SMS template confirm.
	 *
	 * @param mailTemplateModel
	 *            the mail template model
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.TEMPLATE ,NavigationGroup.SMS_TEMPLATE })
	@RequestMapping(value = "/sms-template-detail", method = RequestMethod.POST)
	public ModelAndView saveSmsTemplateConfirm(
			@Valid @ModelAttribute("mailTemplate") MailTemplateModel mailTemplateModel, BindingResult result,
			ModelMap model) {
		LOG.info("[Start] Save sms template confirm.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		mailTemplateModel.setHospitalId(MssContextHolder.getHospitalId());
		mailTemplateModel.setLocale(MssContextHolder.getHospitalLocale());
		mailTemplateModel.setSendType(2);

		if (this.mailService.updateMailTemplate(mailTemplateModel)) {
			this.addNotification(
					new NotificationModel(NotificationType.SUCCESS, this.getText("be030.msg.update.success")));
		} else {
			this.addNotification(new NotificationModel(NotificationType.ERROR, this.getText("be030.msg.update.fail")));
		}
		LOG.info("[End] Save sms template confirm.");
		return new ModelAndView(new RedirectView("sms-template-list"));
	}

	/**
	 * Send mail to patient.
	 *
	 * @param mailListDetail
	 *            the mail list detail
	 * @param templateCode
	 *            the template code
	 * @param mailInfo
	 *            the mail info
	 */
	private void sendMailToPatient(MailListDetailModel mailListDetail, String templateCode, MailInfo mailInfo,
			Integer hospitalId) throws Exception {
		List<String> toList = new ArrayList<>();
		toList.add(mailListDetail.getEmail());
		mailService.sendMail(templateCode, MssContextHolder.getUserLanguage(), mailInfo, toList,
				mailListDetail.getMailListId(), mailListDetail.getPatientId(), null, hospitalId,
				MssContextHolder.getHospitalEmail(), MssContextHolder.getDomainName());
	}

	/**
	 * Submit schedule delete coma.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@NavigationConfig(group = { NavigationGroup.REMINDER_MAIL, NavigationGroup.MAIL_HISTORY })
	@RequestMapping(value = "/mail-list-history", method = RequestMethod.GET)
	public ModelAndView submitScheduleDeleteComa(ModelMap model) {
		LOG.info("[Start] Submit schedule delete coma.");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		Map<Integer, String> mailList = new LinkedHashMap<>();
		mailList.put(-1, this.getText("general.select.all"));
		List<MailListModel> lstMailListModel = this.mailService.getMailListByActiveFlg(ActiveFlag.ACTIVE.toInt(),
				MssContextHolder.getHospitalId());
		for (MailListModel mailItem : lstMailListModel) {
			mailList.put(mailItem.getMailListId(), mailItem.getMailListName());
		}
		model.addAttribute("mailList", mailList);
		LOG.info("[End] Submit schedule delete coma.");
		return new ModelAndView("back.mail.list.history", "mailHistory", new MailListModel());
	}

	/**
	 * Ajax search mail list history.
	 *
	 * @param mailListModel
	 *            the mail list model
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-search-mail-list-history", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSearchMailListHistory(@RequestBody MailListModel mailListModel) {
		LOG.info("[Start] Ajax search mail list history.");
		List<MailListModel> mailList = this.mailService.searchMailListHistory(mailListModel);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(mailList);
		LOG.info("[End] Ajax search mail list history.");
		return builder.build();
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
			LOG.error("You failed to upload " + name + " => " + e.getMessage(), e);
			return false;
		}
	}

	/**
	 * Generate file mail list.
	 *
	 * @param lstMailListDetailModel
	 *            the lst mail list detail model
	 * @param destDir
	 *            the dest dir
	 * @param fileName
	 *            the file name
	 */
	private File generateFileMailList(List<MailListDetailModel> lstMailListDetailModel, String destDir,
			String fileName) {
		StringBuilder data = new StringBuilder("List mail_list detail");
		if (lstMailListDetailModel != null && lstMailListDetailModel.size() > 0) {

			for (MailListDetailModel mailListDetailModel : lstMailListDetailModel) {
				data.append("\n");
				data.append(mailListDetailModel.getName()).append(",");
				if (StringUtils.isBlank(mailListDetailModel.getPhone())) {
					data.append("").append(",");
				} else {
					data.append(mailListDetailModel.getPhone()).append(",");
				}
				data.append(mailListDetailModel.getEmail());
			}
		}

		return MssFileUtils.saveFile(destDir, fileName, data.toString());
	}

	/**
	 * Creates the mail list names.
	 *
	 * @return the map
	 */
	private Map<Integer, String> createMailListNames() {
		List<MailListModel> lstMailModel = this.mailService.getMailListByActiveFlg(ActiveFlag.ACTIVE.toInt(),
				MssContextHolder.getHospitalId());
		Map<Integer, String> mapMailList = new LinkedHashMap<Integer, String>();
		mapMailList.put(-1, this.getText("be040.label.select.mail.list"));
		for (MailListModel mailList : lstMailModel) {
			mapMailList.put(mailList.getMailListId(), mailList.getMailListName());
		}
		return mapMailList;
	}

}
