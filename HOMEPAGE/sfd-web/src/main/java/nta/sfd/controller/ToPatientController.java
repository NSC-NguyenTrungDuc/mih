package nta.sfd.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;

//@Controller
//@RequestMapping("/to-patient")
public class ToPatientController {
	@RequestMapping(value = {"/about-electronic-medical-record"}, method = {RequestMethod.GET})
	public ModelAndView viewAboutMedicalRecord(ModelAndView mav) {
		mav.setViewName("to-patient/about-electronic-medical-record");    
	    return mav;
	}
	
	@RequestMapping(value = {"/patient-register"}, method = {RequestMethod.GET})
	public ModelAndView viewPatientRegister(ModelAndView mav) {
		mav.setViewName("to-patient/patient-register");    
		return mav;
	}
}
