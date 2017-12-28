package nta.sfd.controller;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.ServletRequest;
import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import net.tanesha.recaptcha.ReCaptcha;
import net.tanesha.recaptcha.ReCaptchaResponse;
import nta.sfd.core.info.MailInfo;
import nta.sfd.core.misc.common.IMedConstants;
import nta.sfd.core.misc.common.IMedConstants.LOCALE;
import nta.sfd.core.misc.common.MedConfiguration;
import nta.sfd.core.misc.common.TokenUtils;
import nta.sfd.core.misc.enums.GmtAndVpn;
import nta.sfd.core.misc.enums.TokenValidationResult;
import nta.sfd.core.model.HospitalRegisterModel;
import nta.sfd.core.service.IHospitalRegisterService;
import nta.sfd.core.service.IMailService;

/**
 * The Class ServiceController.
 *
 * @author MinhLS
 * @crtDate 2015/07/03
 */
@Controller
@RequestMapping("/service")
public class ServiceController extends BaseController {
	
	private IHospitalRegisterService hospitalRegisterService;
	
	private IMailService mailService;
    /** The re captcha service. */
    private ReCaptcha reCaptchaService = null;
	
	/**
	 * Instantiates a new service controller.
	 */
	public ServiceController(){
		super();
	}
	
	/**
	 * Instantiates a new service controller.
	 *
	 * @param reCaptchaService the re captcha service
	 */
	@Autowired
	public ServiceController(IHospitalRegisterService hospitalRegisterService, IMailService mailService, ReCaptcha reCaptchaService){
		this.hospitalRegisterService = hospitalRegisterService;
		this.mailService = mailService;
		this.reCaptchaService = reCaptchaService;
	}
	
	/**
	 * View function intro.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/function-intro"}, method = {RequestMethod.GET})
	public ModelAndView viewFunctionIntro(ModelAndView mav) {
		mav.setViewName("service/function-intro");    
	    return mav;
	}
	
	/**
	 * View method procedure intro.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/method-procedure-intro"}, method = {RequestMethod.GET})
	public ModelAndView viewMethodProcedureIntro(ModelAndView mav) {
		mav.setViewName("service/method-procedure-intro");    
		return mav;
	}
	
	/**
	 * View manual guide.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	///@RequestMapping(value = {"/manual-guide"}, method = {RequestMethod.GET})
	public ModelAndView viewManualGuide(ModelAndView mav) {
		ModelAndView modelAndView = new ModelAndView("service/manual-guide");        
	    return modelAndView;
	}
	
	/**
	 * View about peripheral equipment.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/about-connected-peripheral-equipment"}, method = {RequestMethod.GET})
	public ModelAndView viewAboutPeripheralEquipment(ModelAndView mav) {
		ModelAndView modelAndView = new ModelAndView("service/about-connected-peripheral-equipment");        
		return modelAndView;
	}
	
	/**
	 * View registration for test.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/registration-for-test"}, method = {RequestMethod.GET})
	public ModelAndView viewRegistrationForTest(ModelAndView mav) {
		mav = new ModelAndView("service/registration-for-test");     
		mav.addObject("hospital", new HospitalRegisterModel());
		return mav;
	}

	@RequestMapping(value = {"/registration-for-test-inner"}, method = {RequestMethod.GET})
	public ModelAndView viewRegistrationForTestInner(ModelAndView mav) {
		mav = new ModelAndView("service/registration-for-test-inner");
		mav.addObject("hospital", new HospitalRegisterModel());
		return mav;
	}
	@RequestMapping(value = {"/registration-for-test-inner"}, method = {RequestMethod.POST})
	public ModelAndView submitRegistrationForTestInner(ServletRequest request, ModelAndView mav, @Valid @ModelAttribute("hospital") HospitalRegisterModel hospital, BindingResult bindingResult) throws Exception {
		mav = new ModelAndView("service/registration-for-test-inner");

		mav.addObject("hospital", hospital);
		// check unique email
		String email = hospital.getRegisterEmail();
		BigDecimal demoFlg = hospital.getDemoFlg();
		if (!bindingResult.hasFieldErrors("registerEmail") && !hospitalRegisterService.isUniqueEmail(email, demoFlg)) {
			bindingResult.rejectValue("registerEmail", "Email.hospital.registerEmail.exist");
		}

		// validate error
		if (bindingResult.hasErrors()) {
			return mav;
		}

		// validate captcha
		String challenge = request.getParameter("recaptcha_challenge_field");
		String response = request.getParameter("recaptcha_response_field");
		String remoteAddr = request.getRemoteAddr();
		ReCaptchaResponse reCaptchaResponse = reCaptchaService.checkAnswer(remoteAddr, challenge, response);
		if (!reCaptchaResponse.isValid()) {
			mav.addObject("captchaError", this.getText("captcha.error"));
			return mav;
		}

		// create sesstion id
		String sessionId = TokenUtils.generateToken();
//		String locale = REGISTRATION_TYPE.REAL.equalsIgnoreCase(accountType) ? HOSP_GROUP.JP : HOSP_GROUP.DEMO;
		hospital.setSessionId(sessionId);
		hospital.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.REQUEST);
		hospital.setDemoFlg(demoFlg);
		hospital.setLocale(LOCALE.JP);
		hospital.setLanguage(hospital.getLanguage());
		hospital.setTimeZone(GmtAndVpn.newInstance(LOCALE.JP).toGMT());
		hospital.setVpnYn(GmtAndVpn.newInstance(LOCALE.JP).getVpn());
//		if(BigDecimal.ZERO.compareTo(demoFlg) == 0){
//			hospital.setVpnYn("Y");
//		}else{
//			hospital.setVpnYn("N");
//		}

		// save data
		hospitalRegisterService.updateHospitalRegister(hospital);

		// send email confirm, update BD 1.5.4
		if(BigDecimal.ZERO.compareTo(demoFlg) == 0){
			sendEmailRegistration(hospital, IMedConstants.MAIL_CODE.CONFIRM_REAL);
		}else{
			sendEmailRegistration(hospital, IMedConstants.MAIL_CODE.CONFIRM_DEMO);
//			send email to marketing team
			String linkConfirm = MedConfiguration.getInstance().getServerAddress() + this.getText("link.registration.confirm") + hospital.getSessionId();
			sendEmailToMarketing(hospital, hospital.getLanguage(), IMedConstants.MAIL_CODE.CONFIRM_DEMO_MARKETING_TEAM, linkConfirm, "");
		}
		mav.setViewName("service/registration-for-test-inner/success");
		return mav;
	}

	/**
	 * Submit registration for test.
	 *
	 * @param request the request
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/registration-for-test"}, method = {RequestMethod.POST})
	public ModelAndView submitRegistrationForTest(ServletRequest request, ModelAndView mav, @Valid @ModelAttribute("hospital") HospitalRegisterModel hospital, BindingResult bindingResult) throws Exception {
		mav = new ModelAndView("service/registration-for-test");
		
		mav.addObject("hospital", hospital);
		// check unique email
		String email = hospital.getRegisterEmail();
    	if (!bindingResult.hasFieldErrors("registerEmail") && !hospitalRegisterService.isUniqueEmail(email, hospital.getDemoFlg())) {
    		bindingResult.rejectValue("registerEmail", "Email.hospital.registerEmail.exist");
    	}
    	
    	// validate error
        if (bindingResult.hasErrors()) {
			return mav;
		}
		
        // validate captcha
		String challenge = request.getParameter("recaptcha_challenge_field");
        String response = request.getParameter("recaptcha_response_field");
        String remoteAddr = request.getRemoteAddr();
        ReCaptchaResponse reCaptchaResponse = reCaptchaService.checkAnswer(remoteAddr, challenge, response);
        if (!reCaptchaResponse.isValid()) {
            mav.addObject("captchaError", this.getText("captcha.error"));
            return mav;
        }
        
        // create sesstion id
        String sessionId = TokenUtils.generateToken();
        hospital.setSessionId(sessionId);
        hospital.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.REQUEST);
        hospital.setLocale("JA");
        
        // save data
        hospitalRegisterService.updateHospitalRegister(hospital);
        
        // send email confirm
        sendEmailRegistration(hospital, "JA");
        mav.setViewName("service/registration-for-test/success");
        return mav;
	}
	
	/**
	 * View manual for test.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
	//@RequestMapping(value = {"/manual-for-test"}, method = {RequestMethod.GET})
	public ModelAndView viewManualForTest(ModelAndView mav) {
		ModelAndView modelAndView = new ModelAndView("service/manual-for-test");        
		return modelAndView;
	}
	
	/**
	 * View manual for test2.
	 *
	 * @param mav the mav
	 * @return the model and view
	 */
//	@RequestMapping(value = {"/manual-for-test2"}, method = {RequestMethod.GET})
	public ModelAndView viewManualForTest2(ModelAndView mav) {
		ModelAndView modelAndView = new ModelAndView("service/manual-for-test2");        
		return modelAndView;
	}
	
	@RequestMapping(value = "/registration-confirm", method = RequestMethod.GET)
	public ModelAndView confirmRegistration(@RequestParam(value = "token") String tokenId) throws Exception {
		ModelAndView mav = new ModelAndView(new RedirectView("registration-complete"));
		TokenValidationResult tokenResult= TokenUtils.validateToken(tokenId);
		
		if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
			HospitalRegisterModel hospital = hospitalRegisterService.findBySessionId(tokenId);
			// check hospital
			if (hospital == null) {
				return new ModelAndView(new RedirectView("expired"));
			}
			else {
				// update BD 1.5.4
				if(BigDecimal.ZERO.compareTo(hospital.getDemoFlg()) == 0){
					if(hospital.getStatus().compareTo(IMedConstants.HOSPITAL_REGISTER_STATUS.REQUEST) == 0){
						// create new session id
				        String sessionId = TokenUtils.generateToken();
				        hospital.setSessionId(sessionId);
				        hospital.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.WAITING_MARKETING_CONFIRM);
				        //send email to marketing confirm
				        String approveLink = MedConfiguration.getInstance().getServerAddress() + this.getText("link.registration.approve") + sessionId;
				        String rejectLink = MedConfiguration.getInstance().getServerAddress() + this.getText("link.registration.reject") + sessionId;
						sendEmailToMarketing(hospital, hospital.getLanguage(), IMedConstants.MAIL_CODE.CONFIRM_REAL_MARKETING_TEAM, approveLink, rejectLink);
						mav = new ModelAndView(new RedirectView("confirm-real-clinic"));
					}
				}else{
			        hospital.setSessionId("");
			        hospital.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.CONFIRMED);
				}
		        // save data
		        hospitalRegisterService.updateHospitalRegister(hospital);
		        return mav;
			}
		} else {
			return new ModelAndView(new RedirectView("expired"));
		}
	}
	
	@RequestMapping(value = "/registration-approve", method = RequestMethod.GET)
	public ModelAndView approveRegistration(@RequestParam(value = "token") String tokenId) throws Exception {
		ModelAndView mav = new ModelAndView(new RedirectView("approve"));
		TokenValidationResult tokenResult= TokenUtils.validateToken(tokenId);
		
		if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
			HospitalRegisterModel hospital = hospitalRegisterService.findBySessionId(tokenId);
			// check hospital
			if (hospital == null) {
				return new ModelAndView(new RedirectView("expired"));
			}else{
			    hospital.setSessionId("");
			    hospital.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.CONFIRMED);
		        // save data
		        hospitalRegisterService.updateHospitalRegister(hospital);
		        return mav;
			}
		} else {
			return new ModelAndView(new RedirectView("expired"));
		}
	}
	
	@RequestMapping(value = "/registration-reject", method = RequestMethod.GET)
	public ModelAndView rejectRegistration(@RequestParam(value = "token") String tokenId) throws Exception {
		ModelAndView mav = new ModelAndView(new RedirectView("reject"));
		TokenValidationResult tokenResult= TokenUtils.validateToken(tokenId);
		
		if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
			HospitalRegisterModel hospital = hospitalRegisterService.findBySessionId(tokenId);
			// check hospital
			if (hospital == null) {
				return new ModelAndView(new RedirectView("expired"));
			}else{
			    hospital.setSessionId("");
			    hospital.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.CANCEL);
			    sendEmailRegistration(hospital, IMedConstants.MAIL_CODE.REJECT_MARKETING_TEAM);
		        // save data
		        hospitalRegisterService.updateHospitalRegister(hospital);
		        return mav;
			}
		} else {
			return new ModelAndView(new RedirectView("expired"));
		}
	}
	 //demo register
	 @RequestMapping("/registration-complete")
	 public RedirectView localCompleteRedirect() throws Exception {
		 RedirectView redirectView = new RedirectView();
		 redirectView.setUrl(MedConfiguration.getInstance().getWpRegCompletedLink());
		 return redirectView;
	 }
	 
	 @RequestMapping("/expired")
	 public RedirectView localExpireRedirect() throws Exception {
		 RedirectView redirectView = new RedirectView();
		 redirectView.setUrl(MedConfiguration.getInstance().getWpExpireLink());
		 return redirectView;
	 }
	 
	 @RequestMapping("/reject")
	 public RedirectView rejectRedirect() throws Exception {
		 RedirectView redirectView = new RedirectView();
		 redirectView.setUrl(MedConfiguration.getInstance().getRejectRegisterLink());
		 return redirectView;
	 }
	 
	 @RequestMapping("/approve")
	 public RedirectView approveRedirect() throws Exception {
		 RedirectView redirectView = new RedirectView();
		 redirectView.setUrl(MedConfiguration.getInstance().getApproveRegisterLink());
		 return redirectView;
	 }
	 
	 @RequestMapping("/confirm-real-clinic")
	 public RedirectView watingMarketingConfirmRedirect() throws Exception {
		 RedirectView redirectView = new RedirectView();
		 redirectView.setUrl(MedConfiguration.getInstance().getConfirmRealClinicLink());
		 return redirectView;
	 }
	
	
//	@RequestMapping(value = "/registration-complete", method = RequestMethod.GET)
//	public ModelAndView completeRegistration(ModelAndView mav) {
//		mav = new ModelAndView("service/registration-complete");
//		mav.addObject("isSuccess", true);
//		return mav;
//	}
//	
//	@RequestMapping(value = "/expired", method = RequestMethod.GET)
//	public ModelAndView expiredRegistration(ModelAndView mav) {
//		ModelAndView modelAndView = new ModelAndView("service/expired");
//		return modelAndView;
//	}
	
	private void sendEmailRegistration(HospitalRegisterModel info, String mailTempCode) throws Exception {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setRegisterName(info.getRegisterName());
		mailInfo.setHospitalName(info.getHospitalName());
		mailInfo.setConfirmLink(MedConfiguration.getInstance().getServerAddress() + this.getText("link.registration.confirm") + info.getSessionId());
		mailInfo.setHospRegLink(MedConfiguration.getInstance().getHospRegistrationLink());
		mailInfo.setEmail(info.getRegisterEmail());
		List<String> toList = new ArrayList<String>();
		toList.add(info.getRegisterEmail());
		mailService.sendMail(mailTempCode, info.getLanguage(), mailInfo, toList, "");
	}
	
	private void sendEmailToMarketing(HospitalRegisterModel info, String language, String mailTempCode, String approveLink, String rejectLink) throws Exception {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setRegisterName(info.getRegisterName());
		mailInfo.setHospitalName(info.getHospitalName());
		mailInfo.setApproveLink(approveLink);
		mailInfo.setRejectLink(rejectLink);
		mailInfo.setEmail(info.getRegisterEmail());
//		List<String> toList = new ArrayList<String>();
//		toList.add(MedConfiguration.getInstance().getMailMarketing());
		List<String> toList = new ArrayList<String>();
		String email = MedConfiguration.getInstance().getMailMarketing();
		String[] emails = email.split(",");
		for(int i = 0; i< emails.length; i++){
			toList.add(emails[i]);
		}
		mailService.sendMail(mailTempCode, language, mailInfo, toList, "");
	}
}
