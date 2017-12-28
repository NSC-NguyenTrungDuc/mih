package nta.sfd.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;

//@Controller
//@RequestMapping("/")
public class HomeController {
	@RequestMapping(value = {""}, method = {RequestMethod.GET})
	public ModelAndView viewIndex(ModelAndView mav) {
		mav.setViewName("index");
	    return mav;
	}

	@RequestMapping(value = {"/about-us"}, method = {RequestMethod.GET})
	public ModelAndView viewAboutUs(ModelAndView mav) {
		mav.setViewName("about-us");
	    return mav;
	}
	@RequestMapping(value = {"/confirm-phr-account"}, method = {RequestMethod.GET})
	public ModelAndView confirmPhrAccount(ModelAndView mav) {
		mav.setViewName("confirm-phr-account");
		return mav;
	}
	@RequestMapping(value = {"/confirm-phr-password"}, method = {RequestMethod.GET})
	public ModelAndView confirmPhrPassword(ModelAndView mav) {
		mav.setViewName("confirm-phr-password");
		return mav;
	}
	@RequestMapping(value = {"/error-phr"}, method = {RequestMethod.GET})
	public ModelAndView confirmErrorPhr(ModelAndView mav) {
		mav.setViewName("error-phr");
		return mav;
	}
	@RequestMapping(value = {"/privacy-policy"}, method = {RequestMethod.GET})
	public ModelAndView viewPrivacyPolicy(ModelAndView mav) {
		mav.setViewName("privacy-policy");
	    return mav;
	}

	@RequestMapping(value = {"/guidelines"}, method = {RequestMethod.GET})
	public ModelAndView viewGuidelines(ModelAndView mav) {
		mav.setViewName("guidelines");
	    return mav;
	}

	@RequestMapping(value = {"/term-of-service"}, method = {RequestMethod.GET})
	public ModelAndView viewTermOfService(ModelAndView mav) {
		mav.setViewName("term-of-service");
	    return mav;
	}

	@RequestMapping(value = "/page-not-found", method = RequestMethod.GET)
	public ModelAndView pageNotFound() {
		return new ModelAndView("page-not-found");
	}
}
