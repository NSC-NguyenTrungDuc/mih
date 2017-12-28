package nta.mss.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.security.web.authentication.logout.CookieClearingLogoutHandler;
import org.springframework.security.web.authentication.logout.SecurityContextLogoutHandler;
import org.springframework.security.web.authentication.rememberme.AbstractRememberMeServices;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import nta.mss.info.HospitalDto;
import nta.mss.misc.common.DomainNameUtils;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.service.IHospitalService;

/**
 * The Class SysUserController.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 */
@Controller
@Scope("prototype")
@RequestMapping("back")
public class SysUserController extends BaseController {
	
	private IHospitalService hospitalService;
	
	public SysUserController(){
		
	}
	
	@Autowired
	public SysUserController(IHospitalService hospitalService) {
		this.hospitalService = hospitalService;
	}
	
	@RequestMapping(value = "/login", method = RequestMethod.GET)
	public ModelAndView login(HttpServletRequest request, @RequestParam(value = "tokenHospCode", required=false) String tokenHospCode, ModelMap model) throws Exception {
		
		if(!StringUtils.isEmpty(tokenHospCode)){
			if(StringUtils.isEmpty(MssContextHolder.getTokenHospCode()) ||
					(!StringUtils.isEmpty(MssContextHolder.getTokenHospCode()) && !tokenHospCode.equals(MssContextHolder.getTokenHospCode()))){
				String hospCode = EncryptionUtils.decrypt(tokenHospCode, MssConfiguration.getInstance().getSecretKey(), 
						EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
				if(StringUtils.isEmpty(hospCode)){
					return new ModelAndView("back.page.not.found");
				}
				HospitalDto hospital = this.hospitalService.getHospitalModelByHospitalCode(hospCode);
				
				
				if(hospital == null){
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
			if(StringUtils.isEmpty(MssContextHolder.getHospCode())){
				return new ModelAndView("front.access.denied");
			}
		}	
	
		
		
		model.addAttribute("hospitalId", MssContextHolder.getHospitalId());
		return new ModelAndView("back.login");
	}
    
	@RequestMapping(value = "/access-denied", method = RequestMethod.GET)
	public ModelAndView accessDenied() {
		return new ModelAndView("back.access.denied");
	}
	
	@RequestMapping(value = "/page-not-found", method = RequestMethod.GET)
	public ModelAndView pageNotFound() {
		return new ModelAndView("back.page.not.found");
	}
	
	@RequestMapping(value = "/logout", method = RequestMethod.GET)
	public ModelAndView logout(ModelMap model, HttpServletRequest request, HttpServletResponse response) throws Exception {
		String token = MssContextHolder.getTokenHospCode();
		
		CookieClearingLogoutHandler cookieClearingLogoutHandler = new CookieClearingLogoutHandler(AbstractRememberMeServices.SPRING_SECURITY_REMEMBER_ME_COOKIE_KEY);
	    SecurityContextLogoutHandler securityContextLogoutHandler = new SecurityContextLogoutHandler();
	    cookieClearingLogoutHandler.logout(request, response, null);
	    securityContextLogoutHandler.logout(request, response, null);
	    
		return new ModelAndView(new RedirectView("login?tokenHospCode=" + token));
	}
}
