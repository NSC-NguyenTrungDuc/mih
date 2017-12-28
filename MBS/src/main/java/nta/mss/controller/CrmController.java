package nta.mss.controller;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.regex.Pattern;

import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.math.NumberUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.util.CollectionUtils;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import nta.kcck.model.KcckCrmModel;
import nta.kcck.service.impl.KcckCrmService;
import nta.kcck.service.impl.KcckDepartmentService;
import nta.kcck.service.impl.KcckDoctorService;
import nta.mss.info.AjaxResponse;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.info.MailInfo;
import nta.mss.misc.common.CrmUtils;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.HospitalLocale;
import nta.mss.misc.enums.NotificationType;
import nta.mss.misc.enums.PatientContact;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.CrmMailListDetailModel;
import nta.mss.model.CrmModel;
import nta.mss.model.CrmPatientModel;
import nta.mss.model.HospitalModel;
import nta.mss.model.MailTemplateModel;
import nta.mss.model.NotificationModel;
import nta.mss.model.SysUserModel;
import nta.mss.security.WebSysUserDetails;
import nta.mss.service.IDepartmentService;
import nta.mss.service.IDoctorService;
import nta.mss.service.IHospitalService;
import nta.mss.service.IMailService;
import nta.mss.validation.MultipartFileValidator;


@NavigationConfig(leftMenuType = NavigationType.BACK_LEFT_MENU)
@Controller
@Scope("prototype")
@RequestMapping(value = "/crm")
public class CrmController extends BaseController {
	
	private static final Pattern EMAIL_PATTERN = Pattern
			.compile("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$");

	private static final Logger LOG = LogManager.getLogger(CrmController.class);
	/** The Mail Service. */
	private IMailService mailService;

	private MultipartFileValidator fileValidator;

	private IHospitalService hospitalService;

	private IDepartmentService departmentService;

	private IDoctorService doctorService;

	private KcckDepartmentService kcckDepartmentService = new KcckDepartmentService();
	private KcckDoctorService kcckDoctorService = new KcckDoctorService();
	private KcckCrmService kcckCrmService = new KcckCrmService();

	public CrmController() {
		super();
	}

	@Autowired
	public CrmController(IMailService mailService, MultipartFileValidator fileValidator,
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

	@NavigationConfig(group = { NavigationGroup.CRM_MANAGEMENT })
	@RequestMapping(value = "/search-crm", method = RequestMethod.GET)
	public ModelAndView searchCrm(ModelMap model) {
		LOG.info("[Start] View search crm screen.");
		// get disease status
		Map<String, String> listStatusOfDisease = CrmUtils.getStatusOfDisease(MssContextHolder.getLocale());
		model.addAttribute("listStatusOfDisease", listStatusOfDisease);
		// get email template
		List<MailTemplateModel> mailTemplateList = mailService
				.getCrmTemplate(MssContextHolder.getHospitalId(), MssContextHolder.getUserLanguage());
		model.addAttribute("mailTemplate", mailTemplateList);
		return new ModelAndView("back.search.crm", "crmModel", new CrmModel());
	}

	/**
	 * Ajax search mail list history.
	 *
	 * @param mailListModel
	 *            the mail list model
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-search-crm-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSearchMailListHistory(@RequestBody CrmModel crmModel) {
		LOG.info("[Start] Ajax search crm list.");
		KcckCrmModel kcckCrmModel = new KcckCrmModel();
		kcckCrmModel.setHosp_code(MssContextHolder.getHospCode());
		kcckCrmModel.setDisease_name(crmModel.getDiseaseName());
		kcckCrmModel.setStatus_of_disease(crmModel.getStatusOfDisease());
		kcckCrmModel.setFrom_lastest_go_hospital(crmModel.getFromLastestGoHospital());
		kcckCrmModel.setTo_lastest_go_hospital(crmModel.getToLastestGoHospital());
		kcckCrmModel.setFrom_patient_age(crmModel.getFromPatientAge());
		kcckCrmModel.setTo_patient_age(crmModel.getToPatientAge());
		kcckCrmModel.setPatient_sex(crmModel.getPatientSex());
		if(crmModel.getPatientContact().equals("")) {
			kcckCrmModel.setPatient_contact("");
		}
		if(crmModel.getPatientContact().equals("E")) {
			kcckCrmModel.setPatient_contact(PatientContact.EMAIL.getValue());
		}
		if(crmModel.getPatientContact().equals("P")) {
			kcckCrmModel.setPatient_contact(PatientContact.PHONE.getValue());
		}
		if(crmModel.getPatientContact().equals("PE")) {
			kcckCrmModel.setPatient_contact(PatientContact.ALL.getValue());
		}
		kcckCrmModel.setPage_size(crmModel.getPageSize());
		kcckCrmModel.setPage_index(crmModel.getPageIndex());
		kcckCrmModel.setOrder_field(crmModel.getOrderField());
		kcckCrmModel.setOrder_value(crmModel.getOrderValue());
		
		CrmModel resultCrmModel = kcckCrmService.getListCrm(kcckCrmModel);
		if (resultCrmModel != null) {
			if(!CollectionUtils.isEmpty(resultCrmModel.getListCrmPatientModel()))
			{
				for (CrmPatientModel info : resultCrmModel.getListCrmPatientModel()) {
					if (info.getPatientSex().equalsIgnoreCase("F"))
						info.setPatientSex(this.getText("general.label.female"));
					else if (info.getPatientSex().equalsIgnoreCase("M")) 
						info.setPatientSex(this.getText("general.label.male"));
					else
						info.setPatientSex("");
				}			
			}
		}
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.data(resultCrmModel);
		LOG.info("[End] Ajax search crm list.");
		return builder.build();
	}

	
	@RequestMapping(value = "ajax-crm-send-mail-list-confirm", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxSendMailListConfirm(@RequestBody List<CrmMailListDetailModel> lstCrmMailListDetailModel,
			HttpSession session) {
		LOG.info("[Start] Ajax send mail list comfirm");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (lstCrmMailListDetailModel == null || lstCrmMailListDetailModel.isEmpty()) {
			LOG.warn("[WARN] Ajax send mail list comfirm. lstCrmMailListDetailModel is null or empty");
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("be043.msg.mail.confirm.fail"));
		} else {
			builder.status(HttpStatus.OK);
			session.setAttribute("lstCrmMailListDetailModel", lstCrmMailListDetailModel);
			builder.data("crm-send-mail-list-confirm");
		}
		LOG.info("[End] Ajax send mail list comfirm");
		return builder.build();
	}
	
	@SuppressWarnings("unchecked")
	@NavigationConfig(group = { NavigationGroup.CRM_MANAGEMENT })
	@RequestMapping(value = "crm-send-mail-list-confirm", method = { RequestMethod.GET })
	public ModelAndView viewMailListSendingConfirmation(@RequestParam(value = "templateId") String templateId, ModelMap model, HttpSession session) {
		LOG.info("[Start] View mail list sending confirmation");
		LOG.debug("View mail list sending confirmation. templateId = " + templateId);
		if (templateId == null || StringUtils.isBlank(templateId) || !NumberUtils.isDigits(templateId)) {
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("be043.msg.enter.mail.temp")));
			LOG.warn("[WARN] View mail list sending confirmation. templateId is null or not an integer");
			return new ModelAndView("back.send.mail.list.confirm");
		} else {
			List<CrmMailListDetailModel> lstCrmMailListDetailModel = (List<CrmMailListDetailModel>) session
					.getAttribute("lstCrmMailListDetailModel");

			// get MailTemplate by code and set it to session
			MailTemplateModel mailTemplate = mailService.getMailTemplateById(Integer.valueOf(templateId));

			session.setAttribute("mailTemplateCode", mailTemplate.getTemplateCode());
			session.setAttribute("subject", mailTemplate.getSubject());
			model.addAttribute("mailTemplate", mailTemplate);
			model.addAttribute("mailListDetails", lstCrmMailListDetailModel);
			LOG.info("[Start] View mail list sending confirmation");
			return new ModelAndView("back.crm.send.mail.list.confirm");
		}

	}

	@SuppressWarnings("unchecked")
	@NavigationConfig(group = { NavigationGroup.CRM_MANAGEMENT })
	@RequestMapping(value = "crm-mail-send-mail-list-submit", method = { RequestMethod.POST })
	public ModelAndView submitSendMailList(HttpSession session) {
		LOG.info("[Start] Submit send mail list.");
		List<CrmMailListDetailModel> lstCrmMailListDetailModel = (List<CrmMailListDetailModel>) session
				.getAttribute("lstCrmMailListDetailModel");
		String mailTemplateCode = session.getAttribute("mailTemplateCode").toString();
		try {
			HospitalModel hospital = this.hospitalService.findHospital(MssContextHolder.getHospitalId());
			for (CrmMailListDetailModel crmMailListDetailModel : lstCrmMailListDetailModel) {
				MailInfo mailInfo = new MailInfo();
				mailInfo.setPatientName(crmMailListDetailModel.getPatientName());
				mailInfo.setDieaseName(crmMailListDetailModel.getDiseaseName());
				mailInfo.setPatientAge(crmMailListDetailModel.getPatientAge());
				mailInfo.setPatientSex(crmMailListDetailModel.getPatientSex());
				mailInfo.setLatestGoTime(crmMailListDetailModel.getLastestGoHospital());
				
				mailInfo.setUserName(crmMailListDetailModel.getPatientEmail());
				mailInfo.setHospitalPhone(hospital.getPhoneNumber());
				mailInfo.setHospitalName(hospital.getHospitalName());
				mailInfo.setLinkThankYou(MssContextHolder.getDomainName() + this.getText("be030.link.thank.you"));
				mailInfo.setLinkReminderEmail(MssContextHolder.getDomainName() + this.getText("be030.link.for.booking.new"));
				
				sendMailToPatient(crmMailListDetailModel, mailTemplateCode, mailInfo, hospital.getHospitalId());
			}
		} catch (Exception e) {
			LOG.error("ERROR: " + e.getMessage());
		}
		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("be043.msg.send.email.success")));
		LOG.info("[End] Submit send mail list.");
		return new ModelAndView(new RedirectView("search-crm"));
	}
	
	private void sendMailToPatient(CrmMailListDetailModel mailListDetail, String templateCode, MailInfo mailInfo,
			Integer hospitalId) throws Exception {
		List<String> toList = new ArrayList<>();
		toList.add(mailListDetail.getPatientEmail());
		mailService.sendUserMail(templateCode, this.getLanguage(), mailInfo, toList, MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),MssContextHolder.getDomainName());
	}
}
