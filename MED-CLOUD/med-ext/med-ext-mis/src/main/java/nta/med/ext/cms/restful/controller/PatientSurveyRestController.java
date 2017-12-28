/**
 * 
 */
package nta.med.ext.cms.restful.controller;

import java.math.BigDecimal;
import java.math.BigInteger;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import nta.med.core.domain.cms.CmsSurveyPatient;
import nta.med.core.utils.BeanUtils;
import nta.med.ext.cms.glossary.Message;
import nta.med.ext.cms.model.MessageResponse;
import nta.med.ext.cms.model.cms.CmsContext;
import nta.med.ext.cms.model.cms.PatientBasicInfoModel;
import nta.med.ext.cms.model.cms.PatientSurveyBaseModel;
import nta.med.ext.cms.service.SurveyService;
import nta.med.ext.cms.service.impl.SurveyServiceImpl;

/**
 * @author DEV-ThangNH
 *
 */

@Path("/cms")
@Component
public class PatientSurveyRestController {
	
	private static final Log LOGGER = LogFactory.getLog(PatientSurveyRestController.class);

	@Resource
	private SurveyService surveyService;

	public PatientSurveyRestController() {
	}

	public PatientSurveyRestController(SurveyService surveyService) {
		this.surveyService = surveyService;
	}

	// AC02
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public Response list() {
		Boolean surveyid = surveyService.getSurveyByDepartmentCode();
		MessageResponse<Boolean> messageResponse = new MessageResponse.MessageResponseBuilder<Boolean>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(surveyid).build();

		return Response.ok().entity(messageResponse).build();
	}
	
	@POST
	@Path("/patient_survey")
	@Produces(MediaType.APPLICATION_JSON)
	public Response createPatientSurvey(@Valid @NotNull PatientSurveyBaseModel model) throws Exception {
		
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		String sysId = CmsContext.current().getCmsSession().getUserName();
		int timeZone = CmsContext.current().getCmsSession().getTimeZone();
//		String hospCode = "K01";
//		String sysId = "MIS-TEST";
		
		PatientBasicInfoModel patient = surveyService.getPatientFromKCCK(hospCode, model.getPatientCode());
        LOGGER.info("[createPatientSurvey] PATIENT_INFO: " + patient.toString());
		if(patient == null || StringUtils.isEmpty(patient.getPatientCode())){
			MessageResponse<PatientSurveyBaseModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyBaseModel>(
					Message.PATIENT_NOT_FOUND.getValue(), Message.FAIL.getValue()).setContent(null).build();
			return Response.ok().entity(messageResponse).build();
		}
		
		String patientName = StringUtils.isEmpty(patient.getPatientNameKana()) ? patient.getPatientNameKanji() : patient.getPatientNameKana();
		CmsSurveyPatient csp = surveyService.insertCmsSurveyPatient(timeZone, hospCode, model.getSurveyId(), model.getPatientCode(), patientName, model.getDepartmentCode(), model.getDepartmentName(), sysId, patient.getPatientPwd());
		if(csp == null){
			MessageResponse<PatientSurveyBaseModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyBaseModel>(
					Message.MESSAGE_FAIL.getValue(), Message.FAIL.getValue()).setContent(model).build();
			return Response.ok().entity(messageResponse).build();
		}
		
		BeanUtils.copyProperties(csp, model, "JA");
		LOGGER.info("[createPatientSurvey] PATIENT_SURVEY: " + model.toString());
		MessageResponse<PatientSurveyBaseModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyBaseModel>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(model).build();
		return Response.ok().entity(messageResponse).build();
	}
	
	@PUT
	@Path("/patient_survey/{id_patient_survey}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response updatePatientSurvey(
			@Valid @NotNull @PathParam("id_patient_survey") Long patientSurveyId,
			@Valid @NotNull PatientSurveyBaseModel model) throws Exception {
		
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		//String hospCode = "K01";
		CmsSurveyPatient surveyPatient = surveyService.findById(patientSurveyId, hospCode);
		
		if(surveyPatient == null){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(
					Message.MESSAGE_FAIL.getValue(), Message.FAIL.getValue()).setContent(null).build();
			return Response.ok().entity(messageResponse).build();
		}
		if(BigDecimal.ONE.equals(surveyPatient.getStatusFlg())){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(
					Message.PATIENT_SURVEY_IN_COMPLETE.getValue(), Message.FAIL.getValue()).setContent(null).build();
			return Response.ok().entity(messageResponse).build();
		}
		
		boolean updateResult = surveyService.changeSurvey(model.getSurveyId(), patientSurveyId, hospCode);
		if(updateResult){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(
					Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(null).build();
			return Response.ok().entity(messageResponse).build();
		} else {
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(
					Message.MESSAGE_FAIL.getValue(), Message.FAIL.getValue()).setContent(null).build();
			return Response.ok().entity(messageResponse).build();
		}
	}
	
}
