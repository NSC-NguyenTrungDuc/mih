package nta.med.ext.registration.restful.controller;

import java.math.BigDecimal;
import java.net.URI;

import javax.annotation.Resource;
import javax.validation.constraints.NotNull;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.MultivaluedMap;
import javax.ws.rs.core.Response;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.stereotype.Component;

import nta.med.common.util.Strings;
import nta.med.core.common.annotation.TokenIgnore;
import nta.med.core.glossary.Language;
import nta.med.data.model.ihis.adma.MailInfo;
import nta.med.ext.registration.glosarry.ClinicScale;
import nta.med.ext.registration.glosarry.ClinicType;
import nta.med.ext.registration.glosarry.GmtAndVpn;
import nta.med.ext.registration.glosarry.IMedConstants;
import nta.med.ext.registration.glosarry.IMedConstants.LOCALE;
import nta.med.ext.registration.glosarry.MedConfiguration;
import nta.med.ext.registration.glosarry.Message;
import nta.med.ext.registration.glosarry.TokenUtils;
import nta.med.ext.registration.glosarry.TokenValidationResult;
import nta.med.ext.registration.glosarry.VerifyRecaptcha;
import nta.med.ext.registration.model.HospitalRegisterModel;
import nta.med.ext.registration.restful.model.MessageResponse;
import nta.med.ext.registration.service.MailService;
import nta.med.ext.registration.service.hospitalRegisterService;

/**
 * @author DEV-TiepNM
 */
@Path("/clinic")
@Component
public class RegisRestController {


    @Resource
    private hospitalRegisterService hospitalRegisterService;

    @Resource
    private MailService mailService;


    @POST
    @Path("/regis")
    @Produces(MediaType.APPLICATION_JSON)
    @Consumes(MediaType.APPLICATION_FORM_URLENCODED)
    @TokenIgnore
    public Response createNewClinic(MultivaluedMap<String,String> multivaluedMap) throws Exception {
        MessageResponse messageResponse = new MessageResponse.MessageResponseBuilder(
                Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(true).build();
        String registerName = CollectionUtils.isEmpty(multivaluedMap.get("registerName")) ? "" : multivaluedMap.get("registerName").get(0);
        String email = CollectionUtils.isEmpty(multivaluedMap.get("registerEmail")) ? "" : multivaluedMap.get("registerEmail").get(0);
        String clinicName =  CollectionUtils.isEmpty(multivaluedMap.get("clinicName")) ? "" : multivaluedMap.get("clinicName").get(0);
        String telephone = CollectionUtils.isEmpty(multivaluedMap.get("telephone")) ? "" : multivaluedMap.get("telephone").get(0);

        String scale = CollectionUtils.isEmpty(multivaluedMap.get("scale")) ? "" : multivaluedMap.get("scale").get(0);
        String type = CollectionUtils.isEmpty(multivaluedMap.get("type")) ? "" : multivaluedMap.get("type").get(0);
        String packageOfClinic = CollectionUtils.isEmpty(multivaluedMap.get("package")) ? "" : multivaluedMap.get("package").get(0);
        String gRecaptchaResponse = multivaluedMap.get("g-recaptcha-response").get(0);
        BigDecimal demoFlg = CollectionUtils.isEmpty(multivaluedMap.get("demoFlg")) ? BigDecimal.ONE :  new BigDecimal(multivaluedMap.get("demoFlg").get(0));
//        String locale = REGISTRATION_TYPE.REAL.equalsIgnoreCase(accountType) ? HOSP_GROUP.VN : HOSP_GROUP.DEMO;
        
        if(Strings.isEmpty(email))
        {
            messageResponse = new MessageResponse.MessageResponseBuilder<String>(
                    Message.EMAIL_INVALID.getValue(), Message.FAIL.getValue()).build();
            return Response.ok().entity(messageResponse).build();
        }
        if(Strings.isEmpty(clinicName))
        {
            messageResponse = new MessageResponse.MessageResponseBuilder<String>(
                    Message.CLINIC_INVALID.getValue(), Message.FAIL.getValue()).build();
            return Response.ok().entity(messageResponse).build();
        }
        if(Strings.isEmpty(telephone))
        {
            messageResponse = new MessageResponse.MessageResponseBuilder<String>(
                    Message.TELEPHONE_INVALID.getValue(), Message.FAIL.getValue()).build();
            return Response.ok().entity(messageResponse).build();
        }

        if(!hospitalRegisterService.isUniqueEmail(email))
        {
            messageResponse = new MessageResponse.MessageResponseBuilder<String>(
                    Message.EMAIL_HAS_EXISTED.getValue(), Message.FAIL.getValue()).build();
            return Response.ok().entity(messageResponse).build();
        }
        boolean verify = VerifyRecaptcha.verify(gRecaptchaResponse);
        if(!verify)
        {
            messageResponse = new MessageResponse.MessageResponseBuilder<String>(
                    Message.RECAPCHA_VERIFY_FAIL.getValue(), Message.FAIL.getValue()).build();
            return Response.ok().entity(messageResponse).build();
        }
        HospitalRegisterModel model = new HospitalRegisterModel();
        model.setPhone(telephone);
        model.setRegisterName(registerName);
        model.setHospitalName(clinicName);
        model.setLanguage(Language.VIETNAMESE.toString().toUpperCase());
        model.setDemoFlg(demoFlg);
        model.setLocale(LOCALE.VN);
        model.setClinicPackage(packageOfClinic);
        model.setClinicType(type);
        model.setScale(scale);
        model.setRegisterEmail(email);
        model.setClinicPackage("0");
        String sessionId = TokenUtils.generateToken();
        model.setSessionId(sessionId);

        model.setStatus(0);


        model.setTimeZone(GmtAndVpn.newInstance("VN").toGMT());
        model.setVpnYn(GmtAndVpn.newInstance("VN").getVpn());


        hospitalRegisterService.createClinic(model);

        // send email confirm, update BD 1.5.4
        if(BigDecimal.ZERO.compareTo(demoFlg) == 0){
     		sendEmailRegistration(model, IMedConstants.MAIL_CODE.CONFIRM_REAL);
     	}else{
        	sendEmailRegistration(model, IMedConstants.MAIL_CODE.CONFIRM_DEMO);
     		// send email to marketing team
     		String linkConfirm = MedConfiguration.getInstance().getServerAddress() + "/clinic/registration-confirm?lang=VI&token=" + model.getSessionId();
     		sendEmailToMarketing(model, model.getLanguage(), IMedConstants.MAIL_CODE.CONFIRM_DEMO_MARKETING_TEAM, linkConfirm, "");
     	}
        return Response.ok().entity(messageResponse).build();
    }
    private void sendEmailRegistration(HospitalRegisterModel info, String emailTempl) throws Exception {
        MailInfo mailInfo = new MailInfo();
        mailInfo.setRegisterName(info.getRegisterName());
        mailInfo.setHospitalName(info.getHospitalName());
        mailInfo.setConfirmLink(MedConfiguration.getInstance().getServerAddress() + "/clinic/registration-confirm?lang=VI&token=" + info.getSessionId());
        mailInfo.setHospRegLink(MedConfiguration.getInstance().getHospRegistrationLink());
		String[] email = {info.getRegisterEmail()};
        mailService.sendMail(emailTempl, info.getLanguage(), mailInfo, email, "");
    }

    @GET
    @Path("/registration-confirm")
    @Produces(MediaType.APPLICATION_JSON)
    public Response confirm(@NotNull @QueryParam(value = "token") String tokenId) throws Exception {
        TokenValidationResult tokenResult= TokenUtils.validateToken(tokenId);
        URI targetURIForRedirection = new URI(MedConfiguration.getInstance().getWpRegCompletedLink());

        if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
            HospitalRegisterModel hospital = hospitalRegisterService.findBySessionId(tokenId);
            // check hospital
            if (hospital == null) {
                targetURIForRedirection = new URI(MedConfiguration.getInstance().getWpExpireLink());
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
				        String approveLink = MedConfiguration.getInstance().getServerAddress() + "/clinic/registration-approve?lang=VI&token=" + sessionId;
				        String rejectLink = MedConfiguration.getInstance().getServerAddress() + "/clinic/registration-reject?lang=VI&token=" + sessionId;
						sendEmailToMarketing(hospital, hospital.getLanguage(), IMedConstants.MAIL_CODE.CONFIRM_REAL_MARKETING_TEAM, approveLink, rejectLink);
						targetURIForRedirection = new URI(MedConfiguration.getInstance().getConfirmRealClinicLink());
					}
				}else{
			        hospital.setSessionId("");
			        hospital.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.CONFIRMED);
				}
                // save data
                hospitalRegisterService.updateHospitalRegister(hospital);
            }
        } else {
            targetURIForRedirection = new URI(MedConfiguration.getInstance().getWpExpireLink());
        }
        return Response.temporaryRedirect(targetURIForRedirection).build();
    }
    
    @GET
    @Path("/registration-reject")
    @Produces(MediaType.APPLICATION_JSON)
    public Response reject(@NotNull @QueryParam(value = "token") String tokenId) throws Exception {
        TokenValidationResult tokenResult= TokenUtils.validateToken(tokenId);
        URI targetURIForRedirection;

        if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
            HospitalRegisterModel hospital = hospitalRegisterService.findBySessionId(tokenId);
            // check hospital
            if (hospital == null) {
                targetURIForRedirection = new URI(MedConfiguration.getInstance().getWpExpireLink());
            }else{
			    hospital.setSessionId("");
			    hospital.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.CANCEL);
			    sendEmailRegistration(hospital, IMedConstants.MAIL_CODE.REJECT_MARKETING_TEAM);
                // save data
                hospitalRegisterService.updateHospitalRegister(hospital);
                targetURIForRedirection = new URI(MedConfiguration.getInstance().getRejectRegisterLink());
            }
        } else {
            targetURIForRedirection = new URI(MedConfiguration.getInstance().getWpExpireLink());
        }
        return Response.temporaryRedirect(targetURIForRedirection).build();
    }
    
    @GET
    @Path("/registration-approve")
    @Produces(MediaType.APPLICATION_JSON)
    public Response approve(@NotNull @QueryParam(value = "token") String tokenId) throws Exception {
        TokenValidationResult tokenResult= TokenUtils.validateToken(tokenId);
        URI targetURIForRedirection;

        if (TokenValidationResult.VALID.toInt().equals(tokenResult.toInt())) {
            HospitalRegisterModel hospital = hospitalRegisterService.findBySessionId(tokenId);
            // check hospital
            if (hospital == null) {
                targetURIForRedirection = new URI(MedConfiguration.getInstance().getWpExpireLink());
            }else{
			    hospital.setSessionId("");
			    hospital.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.CONFIRMED);
                // save data
                hospitalRegisterService.updateHospitalRegister(hospital);
                targetURIForRedirection = new URI(MedConfiguration.getInstance().getApproveRegisterLink());
            }
        } else {
            targetURIForRedirection = new URI(MedConfiguration.getInstance().getWpExpireLink());
        }
        return Response.temporaryRedirect(targetURIForRedirection).build();
    }
    
    private void sendEmailToMarketing(HospitalRegisterModel info, String language, String mailTemp, String approveLink, String rejectLink) throws Exception {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setRegisterName(info.getRegisterName());
		mailInfo.setHospitalName(info.getHospitalName());
		mailInfo.setApproveLink(approveLink);
		mailInfo.setRejectLink(rejectLink);
		mailInfo.setPhone(info.getPhone());
//		mailInfo.setClinicType(info.getClinicType());
//		mailInfo.setScale(info.getScale());
		mailInfo.setClinicType(ClinicType.newInstance(info.getClinicType()).getTypeName());
		mailInfo.setScale(ClinicScale.newInstance(info.getScale()).getScale(info.getClinicType()));
		mailInfo.setEmail(info.getRegisterEmail());
		String email = MedConfiguration.getInstance().getMailMarketing();
		String[] emails = email.split(",");
		mailService.sendMail(mailTemp, language, mailInfo, emails, "");
	}
}
