package nta.sfd.controller;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.ServletRequest;
import javax.validation.Valid;

import net.tanesha.recaptcha.ReCaptcha;
import net.tanesha.recaptcha.ReCaptchaResponse;
import nta.sfd.core.info.MailInfo;
import nta.sfd.core.misc.common.IMedConstants;
import nta.sfd.core.misc.common.MedConfiguration;
import nta.sfd.core.service.IMailService;
import nta.sfd.info.ContactUsInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;

// TODO: Auto-generated Javadoc
/**
 * The Class ITOrganizationController.
 *
 * @author MinhLS
 * @crtDate 2015/07/02
 */
@Controller
@RequestMapping("/it-organization")
public class ITOrganizationController extends BaseController {
	
	/** The mail service. */
	private IMailService mailService;
	
    /** The re captcha service. */
    private ReCaptcha reCaptchaService = null;
	/**
	 * Instantiates a new IT organization controller.
	 */
	public ITOrganizationController(){
		super();
	}
	
	/**
	 * Instantiates a new IT organization controller.
	 *
	 * @param mailService the mail service
	 * @param sysPropertyRepository the sys property repository
	 * @param reCaptchaService the re captcha service
	 */
	@Autowired
	public ITOrganizationController(IMailService mailService, ReCaptcha reCaptchaService){
		this.mailService = mailService;
		this.reCaptchaService = reCaptchaService;
	}
	
	/**
	 * View related medical agent.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/related-medical-agent"}, method = {RequestMethod.GET})
	public ModelAndView viewRelatedMedicalAgent(ModelAndView mav) {
		mav.setViewName("it-organization/related-medical-agent");    
	    return mav;
	}
	
	/**
	 * View trial service.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/trial-service"}, method = {RequestMethod.GET})
	public ModelAndView viewTrialService(ModelAndView mav) {
		mav.setViewName("it-organization/trial-service");    
		return mav;
	}
	
	/**
	 * View radiation system.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/radiation-system"}, method = {RequestMethod.GET})
	public ModelAndView viewRadiationSystem(ModelAndView mav) {
		mav.setViewName("it-organization/radiation-system");    
		return mav;
	}
	
	/**
	 * View dispensed service.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/dispensed-service"}, method = {RequestMethod.GET})
	public ModelAndView viewDispensedService(ModelAndView mav) {
		mav.setViewName("it-organization/dispensed-service");    
		return mav;
	}
	
	/**
	 * View contact us.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
//	@RequestMapping(value = {"/contact-us"}, method = {RequestMethod.GET})
//	public ModelAndView viewContactUs(ModelAndView mav) {
//		mav.setViewName("it-organization/contact-us");
//		mav.addObject("contactUsInfo", new ContactUsInfo());
//		return mav;
//	}
	@RequestMapping(value = {"/contact-us-inner"}, method = {RequestMethod.GET})
	public ModelAndView viewContactUsInner(ModelAndView mav) {
		mav.setViewName("it-organization/contact-us-inner");
		mav.addObject("contactUsInfo", new ContactUsInfo());
		return mav;
	}

	@RequestMapping(value = {"/contact-us-inner"}, method = {RequestMethod.POST})
	public ModelAndView submitContactInfoInner(ServletRequest request, ModelAndView mav, @Valid @ModelAttribute("contactUsInfo") ContactUsInfo info, BindingResult bindingResult) throws Exception {
		mav = new ModelAndView("it-organization/contact-us-inner");

		mav.addObject("contactUsInfo", info);
		if (bindingResult.hasErrors()) {
			return mav;
		}

		String challenge = request.getParameter("recaptcha_challenge_field");
		String response = request.getParameter("recaptcha_response_field");
		String remoteAddr = request.getRemoteAddr();
		ReCaptchaResponse reCaptchaResponse = reCaptchaService.checkAnswer(remoteAddr, challenge, response);
		if (!reCaptchaResponse.isValid()) {
			mav.addObject("captchaError", this.getText("captcha.error"));
			return mav;
		}

		sendEmailContact(info, this.getLanguage());
		sendEmailToContact(info, this.getLanguage());

		mav.setViewName("it-organization/contact-us-inner/success");
		return mav;
	}
	/**
	 * Submit contact us.
	 *
	 * @param request the request
	 * @param mav the mav
	 * @param info the info
	 * @param bindingResult the binding result
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/contact-us"}, method = {RequestMethod.POST})
	public ModelAndView submitContactInfo(ServletRequest request, ModelAndView mav, @Valid @ModelAttribute("contactUsInfo") ContactUsInfo info, BindingResult bindingResult) throws Exception {
		mav = new ModelAndView("it-organization/contact-us");
        
        mav.addObject("contactUsInfo", info);
        if (bindingResult.hasErrors()) {
			return mav;
		}
		
        String challenge = request.getParameter("recaptcha_challenge_field");
        String response = request.getParameter("recaptcha_response_field");
        String remoteAddr = request.getRemoteAddr();
        ReCaptchaResponse reCaptchaResponse = reCaptchaService.checkAnswer(remoteAddr, challenge, response);
		if (!reCaptchaResponse.isValid()) {
            mav.addObject("captchaError", this.getText("captcha.error"));
            return mav;
        }
		
		sendEmailContact(info, this.getLanguage());
		sendEmailToContact(info, this.getLanguage());
		
		mav.setViewName("it-organization/contact-us/success");
		return mav;
	}
	
	/**
	 * Send email contact.
	 *
	 * @param info the info
	 * @param language the language
	 * @param company the company
	 */
	private void sendEmailContact(ContactUsInfo info, String language) throws Exception {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setHospitalName(info.getCompanyName());
		mailInfo.setCustomerName(info.getPicName());
		mailInfo.setEmail(info.getMailAddress());
		mailInfo.setContent(info.getContent());
		String templateCode = IMedConstants.MAIL_CODE.CONTACT;
		
		List<String> toList = new ArrayList<String>();
		String mailAdmin = MedConfiguration.getInstance().getMailAdmin();
		toList.add(mailAdmin);
		mailService.sendMail(templateCode, language, mailInfo, toList, "");
	}
	
	/**
	 * Send email to contact.
	 *
	 * @param info the info
	 * @param language the language
	 * @param company the company
	 */
	private void sendEmailToContact(ContactUsInfo info, String language) {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setCustomerName(info.getPicName());
		mailInfo.setContent(info.getContent());
		String templateCode = IMedConstants.MAIL_CODE.REPLY_CONTACT;
		List<String> toList = new ArrayList<String>();
		toList.add(info.getMailAddress());
		mailService.sendMail(templateCode, language, mailInfo, toList, "");
	}
}
