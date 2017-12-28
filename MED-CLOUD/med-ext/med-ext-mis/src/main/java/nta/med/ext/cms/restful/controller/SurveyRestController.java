package nta.med.ext.cms.restful.controller;

import jdk.nashorn.internal.ir.annotations.Ignore;
import nta.med.core.common.annotation.TokenIgnore;
import nta.med.core.domain.cms.CmsSurveyPatient;
import nta.med.ext.cms.glossary.Message;
import nta.med.ext.cms.model.MessageResponse;
import nta.med.ext.cms.model.cms.*;
import nta.med.ext.cms.service.HospitalService;
import nta.med.ext.cms.service.SurveyService;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.stereotype.Component;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.util.List;

/**
 * @author dainguyen.
 */
@Path("/survey")
@Component
public class SurveyRestController {

	private static final Log LOGGER = LogFactory.getLog(SurveyRestController.class);
	private final String SINGLE_CHOICE = "0";
	private final String MUTIL_CHOICE = "1";
	@Resource
	private SurveyService surveyService;
	@Resource
	private HospitalService hospitalService;

	public SurveyRestController() {
		//surveyService = SpringBeanFactory.beanFactory.getBean(SurveyService.class);
	}

	public SurveyRestController(SurveyService surveyService) {
		this.surveyService = surveyService;
	}

	// CMS 07
	@GET
	@Path("/view_patient_survey/{patient_survey_id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getSurveyByPatientSurveyId(@PathParam("patient_survey_id") Long patientSurveyId) throws Exception {
		LOGGER.info("BEGIN view_patient_survey:" + new Date());
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		PatientSurveyStore patientSurveyStore = surveyService.getPatientSurveyByIdOrPatientCode(patientSurveyId, hospCode, null);

		List<HospitalInfoModel> listCmsHospitalInfoModel = hospitalService.getListHospitalModel(hospCode);
		HospitalInfoModel hospitalModel = new HospitalInfoModel();
		if (listCmsHospitalInfoModel != null && !listCmsHospitalInfoModel.isEmpty()) {
			hospitalModel = listCmsHospitalInfoModel.get(0);
		}

		patientSurveyStore.setHospitalInfoModel(hospitalModel);

		MessageResponse<PatientSurveyStore> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyStore>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(patientSurveyStore).build();
		if (!patientSurveyStore.isResult()) {
			messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyStore>(
					patientSurveyStore.getError(), Message.FAIL.getValue()).setContent(patientSurveyStore).build();
		}
		LOGGER.info("END view_patient_survey:" + new Date());
		return Response.ok().entity(messageResponse).build();
	}
	
	// CMS 07 TOKEN
	@GET
	@Path("/view_patient_survey_token/{patient_survey_id}/{token}")
	@TokenIgnore
	@Produces(MediaType.APPLICATION_JSON)
	public Response getSurveyByPatientSurveyIdToken(@PathParam("patient_survey_id") Long patientSurveyId, @PathParam("token") String token) throws Exception {
		LOGGER.info("BEGIN view_patient_survey:" + new Date());
		//String hospCode = CmsContext.current().getCmsSession().getHospCode();
		CmsSurveyPatient surveypatient = surveyService.getSurveyPatientByToken(token);
		String hospCode = surveypatient.getHospCode();
		PatientSurveyStore patientSurveyStore = surveyService.getPatientSurveyByIdOrPatientCode(patientSurveyId, hospCode, null);

		List<HospitalInfoModel> listCmsHospitalInfoModel = hospitalService.getListHospitalModel(hospCode);
		HospitalInfoModel hospitalModel = new HospitalInfoModel();
		if (listCmsHospitalInfoModel != null && !listCmsHospitalInfoModel.isEmpty()) {
			hospitalModel = listCmsHospitalInfoModel.get(0);
		}

		patientSurveyStore.setHospitalInfoModel(hospitalModel);

		MessageResponse<PatientSurveyStore> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyStore>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(patientSurveyStore).build();
		if (!patientSurveyStore.isResult()) {
			messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyStore>(
					patientSurveyStore.getError(), Message.FAIL.getValue()).setContent(patientSurveyStore).build();
		}
		LOGGER.info("END view_patient_survey:" + new Date());
		return Response.ok().entity(messageResponse).build();
	}
		
	@GET
	@Path("/view_patient_survey")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getSurveyByPatientCode(@NotNull @QueryParam("patientCode") String patientCode) throws Exception {
		LOGGER.info("BEGIN view_patient_survey:" + new Date());
		String hospCode = CmsContext.current().getCmsSession().getHospCode();

		PatientSurveyStore patientSurveyStore = surveyService.getPatientSurveyByIdOrPatientCode(null, hospCode, patientCode);

		List<HospitalInfoModel> listCmsHospitalInfoModel = hospitalService.getListHospitalModel(hospCode);
		HospitalInfoModel hospitalModel = new HospitalInfoModel();
		if (listCmsHospitalInfoModel != null && !listCmsHospitalInfoModel.isEmpty()) {
			hospitalModel = listCmsHospitalInfoModel.get(0);
		}

		patientSurveyStore.setHospitalInfoModel(hospitalModel);

		MessageResponse<PatientSurveyStore> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyStore>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(patientSurveyStore).build();
		if (!patientSurveyStore.isResult()) {
			messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyStore>(
					patientSurveyStore.getError(), Message.FAIL.getValue()).setContent(patientSurveyStore).build();
		}
		LOGGER.info("END view_patient_survey:" + new Date());
		return Response.ok().entity(messageResponse).build();
	}
	// Get list patient - survey ( CMS 10 )
	@POST
	@Path("/patient_survey/search")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getListSurveyPatient(
			@Valid @NotNull(message = "page_size is required") @QueryParam("page_size") Integer pageSize,
			@Valid @NotNull(message = "page_index is required") @QueryParam("page_index") Integer pageIndex,
			@QueryParam("column") String column, @QueryParam("dir") String dir,
			@Valid @NotNull PatientSurveyModel model) {
		
//		if(model == null || model.getSearchType() == null){
//			MessageResponse<PatientSurveyInform> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyInform>(
//					Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(null).build();
//			return Response.ok().entity(messageResponse).build();
//		}
		
		String hospCode = CmsContext.current().getCmsSession().getHospCode();		
		List<PatientSurveyModel> listListSurvey = surveyService.getListSurveyPatient(hospCode, model, pageIndex * pageSize - pageSize, pageSize, column, dir, true);
		List<PatientSurveyModel> total = surveyService.getListSurveyPatient(hospCode, model, 0, 0, column, dir, false);

		PatientSurveyInform record = new PatientSurveyInform();
		record.setPatientSurveyList(listListSurvey);
		record.setRecordsFiltered(total.size());
		record.setRecordsTotal(total.size());

		MessageResponse<PatientSurveyInform> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyInform>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(record).build();

		return Response.ok().entity(messageResponse).build();

	}

	// CMS 13 -- Show dashboard of survey following each department
	@GET
	@Path("/home")
	@Produces(MediaType.APPLICATION_JSON)
	public Response listSurvey() {

		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		List<SurveyPatientStatusModel> listSurveyStatus = surveyService.getListSurveyStatus(hospCode);
		MessageResponse messageResponse = new MessageResponse.MessageResponseBuilder(Message.MESSAGE_SUCCESS.getValue(),
				Message.SUCCESS.getValue()).setContent(listSurveyStatus).build();
		return Response.ok().entity(messageResponse).build();

	}

	// cms 14 -- Get list survey by departmentID
	@GET
	@Path("/search")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getListSurveyPatient(
			@Valid @NotNull(message = "department_code is required") @QueryParam("department_code") String departmentCode,
			@Valid @NotNull(message = "page_size is required") @QueryParam("page_size") Integer pageSize,
			@Valid @NotNull(message = "page_index is required") @QueryParam("page_index") Integer pageIndex) {

		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		List<SurveyStatusModel> listSurveyStatusModel = surveyService.getListSurveybyDepartmentCode(hospCode,
				departmentCode, pageIndex * pageSize - pageSize, pageSize);
		int total = surveyService.getTotalSurveybyDepartmentCode(hospCode, departmentCode);

		SurveyStatusInform record = new SurveyStatusInform();
		record.setSurveyStatusList(listSurveyStatusModel);
		record.setRecordsFiltered(total);
		record.setRecordsTotal(total);

		MessageResponse<SurveyStatusInform> messageResponse = new MessageResponse.MessageResponseBuilder<SurveyStatusInform>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(record).build();

		return Response.ok().entity(messageResponse).build();
	}

	// cms 15 - get a survey to edit
	@GET
	@Path("/{id_survey}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getSurveyById(@PathParam("id_survey") Long surveyId) {

		SurveyInfoModel surveyInfoModel = surveyService.getSurveyById(surveyId, CmsContext.current().getCmsSession().getHospCode());
		MessageResponse<SurveyInfoModel> messageResponse = new MessageResponse.MessageResponseBuilder<SurveyInfoModel>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(surveyInfoModel).build();

		return Response.ok().entity(messageResponse).build();
	}

	// cms 16 - update survey
	@PUT
	@Path("/{id_survey}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response updateSurveyInfoModel(@Valid @NotNull SurveyInfoModel model,
			@PathParam("id_survey") Long surveyId) {
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		if(!hospCode.equals(model.getHospCode())){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.HOSP_CODE_INVALID.getValue(),
					Message.FAIL.getValue()).build();
			return Response.ok().entity(messageResponse).build();
		}
		String message = validateCreateSurvey(model);
		if(!StringUtils.isEmpty(message)){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(message,
					Message.FAIL.getValue()).build();
			return Response.ok().entity(messageResponse).build();
		}
		model.setHospCode(hospCode);
		boolean isSuccess = surveyService.updateSurveyInfoModel(model, surveyId);
		String responseStatus = Message.FAIL.getValue();
		String responseMessage = Message.MESSAGE_FAIL.getValue();

		if (isSuccess) {
			responseStatus = Message.SUCCESS.getValue();
			responseMessage = Message.MESSAGE_SUCCESS.getValue();
		}

		MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(responseMessage,
				responseStatus).build();
		return Response.ok().entity(messageResponse).build();
	}

	// cms 17 -- Delete a survey
	@DELETE
	@Path("/{id_survey}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response deleteSurvey(@PathParam("id_survey") BigInteger surveyId) {
		
		if(surveyService.isExistedSurveyRelatedOrSurveyActive(surveyId, CmsContext.current().getCmsSession().getHospCode())){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.SURVEY_USED.getValue(),
					 Message.FAIL.getValue()).build();
			return Response.ok().entity(messageResponse).build();
		}
		
		boolean isSuccess = surveyService.deleteSurvey(surveyId, CmsContext.current().getCmsSession().getHospCode());
		String responseStatus = Message.FAIL.getValue();
		String responseMessage = Message.MESSAGE_FAIL.getValue();

		if (isSuccess) {
			responseStatus = Message.SUCCESS.getValue();
			responseMessage = Message.MESSAGE_SUCCESS.getValue();
		}

		MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(responseMessage,
				responseStatus).build();
		return Response.ok().entity(messageResponse).build();
	}

	// cms 18 -- Create a survey
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	public Response createSurvey(@Valid @NotNull SurveyInfoModel model) {
		
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		if(!hospCode.equals(model.getHospCode())){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.HOSP_CODE_INVALID.getValue(),
					Message.FAIL.getValue()).build();
			return Response.ok().entity(messageResponse).build();
		}
		String message = validateCreateSurvey(model);
		if(!StringUtils.isEmpty(message)){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(message,
					Message.FAIL.getValue()).build();
			return Response.ok().entity(messageResponse).build();
		}
		model.setHospCode(hospCode);
		boolean isSuccess = surveyService.createSurveyInfoModel(model);
		String responseStatus = Message.FAIL.getValue();
		String responseMessage = Message.MESSAGE_FAIL.getValue();

		if (isSuccess) {
			responseStatus = Message.SUCCESS.getValue();
			responseMessage = Message.MESSAGE_SUCCESS.getValue();
		}

		MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(responseMessage,
				responseStatus).build();
		return Response.ok().entity(messageResponse).build();
	}

	// CMS 08
	@GET
	@Path("/do_patient_survey/{patient_survey_id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getSurveyToDoByPatientSurveyId(@PathParam("patient_survey_id") Long patientSurveyId)
			throws Exception {
		LOGGER.info("BEGIN do_patient_survey:" + new Date());
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		PatientSurveyModel patientSurvey = surveyService.getPatientSurveyToDoById(patientSurveyId, hospCode);
		MessageResponse<PatientSurveyModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyModel>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(patientSurvey).build();
		if (!patientSurvey.isResult()) {
			messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyModel>(patientSurvey.getError(),
					Message.FAIL.getValue()).setContent(patientSurvey).build();
		}
		LOGGER.info("END do_patient_survey:" + new Date());
		return Response.ok().entity(messageResponse).build();
	}

	// CMS 09
	@POST
	@Path("/patient_survey")
	@Produces(MediaType.APPLICATION_JSON)
	public Response saveSurveyAnswer(@Valid @NotNull PatientSurveyInfoModel model) throws Exception {
		LOGGER.info("BEGIN saveSurveyAnswer:" + new Date());
		
		String message = validateSaveSurveyAnswer(model.getPatientSurvey());
		if(!StringUtils.isEmpty(message)){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(message,
					Message.FAIL.getValue()).build();
			return Response.ok().entity(messageResponse).build();
		}
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		if(!hospCode.equals(model.getHospCode())){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.HOSP_CODE_INVALID.getValue(),
					Message.FAIL.getValue()).build();
			LOGGER.info("END saveSurveyAnswer:" + new Date());
			return Response.ok().entity(messageResponse).build();
		}
		if(!isQuestionValid(model))
		{
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.QUESTION_INVALID.getValue(),
					Message.FAIL.getValue()).build();
			LOGGER.info("END saveSurveyAnswer:" + new Date());
			return Response.ok().entity(messageResponse).build();
		}

		PatientSurveyInfoModel patientSurveyInfoModel = surveyService.saveSurveyAnswer(model);
		if(!StringUtils.isEmpty(patientSurveyInfoModel.getError())){
			MessageResponse<PatientSurveyInfoModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyInfoModel>(
					 patientSurveyInfoModel.getError(), Message.FAIL.getValue()).setContent(patientSurveyInfoModel)
							.build();
			LOGGER.info("END saveSurveyAnswer:" + new Date());
			return Response.ok().entity(messageResponse).build();
		} else {
			MessageResponse<PatientSurveyInfoModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyInfoModel>(
					Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(patientSurveyInfoModel)
							.build();
			LOGGER.info("END saveSurveyAnswer:" + new Date());
			return Response.ok().entity(messageResponse).build();
		}
	}
	
	// CMS 09 TOKEN
	@POST
	@Path("/patient_survey_token")
	@TokenIgnore
	@Produces(MediaType.APPLICATION_JSON)
	public Response saveSurveyAnswerToken(@Valid @NotNull PatientSurveyInfoModel model) throws Exception {
		LOGGER.info("BEGIN saveSurveyAnswer:" + new Date());
		
		String message = validateSaveSurveyAnswer(model.getPatientSurvey());
		if(!StringUtils.isEmpty(message)){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(message,
					Message.FAIL.getValue()).build();
			return Response.ok().entity(messageResponse).build();
		}
		//String hospCode = CmsContext.current().getCmsSession().getHospCode();
		CmsSurveyPatient surveypatient = surveyService.getSurveyPatientByToken(model.getToken());
		String hospCode = surveypatient.getHospCode();
		if(!hospCode.equals(model.getHospCode())){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.HOSP_CODE_INVALID.getValue(),
					Message.FAIL.getValue()).build();
			LOGGER.info("END saveSurveyAnswer:" + new Date());
			return Response.ok().entity(messageResponse).build();
		}
		if(!isQuestionValid(model))
		{
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.QUESTION_INVALID.getValue(),
					Message.FAIL.getValue()).build();
			LOGGER.info("END saveSurveyAnswer:" + new Date());
			return Response.ok().entity(messageResponse).build();
		}

		PatientSurveyInfoModel patientSurveyInfoModel = surveyService.saveSurveyAnswer(model);
		if(!StringUtils.isEmpty(patientSurveyInfoModel.getError())){
			MessageResponse<PatientSurveyInfoModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyInfoModel>(
					 patientSurveyInfoModel.getError(), Message.FAIL.getValue()).setContent(patientSurveyInfoModel)
							.build();
			LOGGER.info("END saveSurveyAnswer:" + new Date());
			return Response.ok().entity(messageResponse).build();
		} else {
			MessageResponse<PatientSurveyInfoModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyInfoModel>(
					Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(patientSurveyInfoModel)
							.build();
			LOGGER.info("END saveSurveyAnswer:" + new Date());
			return Response.ok().entity(messageResponse).build();
		}
	}

	private boolean isQuestionValid(@Valid @NotNull PatientSurveyInfoModel model) {
		boolean isValid = true;
		if (model.getPatientSurvey() != null&&model.getPatientSurvey().getGroup()!=null) {
			for (QuestionGroupStore questionGroupStore : model.getPatientSurvey().getGroup()) {
				if (questionGroupStore.getQuestion() != null) {
					for (QuestionStore questionStore : questionGroupStore.getQuestion()) {
						if (SINGLE_CHOICE.equals(questionStore.getQuestionType())
								&& questionStore.getRequiredFlg() == 1) {
							BigDecimal totalAnswer = getTotalAnswer(questionStore);
							if (totalAnswer.intValue() != 1) {
								isValid = false;
							}

						} else if (MUTIL_CHOICE.equals(questionStore.getQuestionType())
								&& questionStore.getRequiredFlg() == 1) {
							BigDecimal totalAnswer = getTotalAnswer(questionStore);
							if (totalAnswer.intValue() == 0) {
								isValid = false;
							}
						}
						if (!isValid)
							break;
					}
				}

				if (!isValid)
					break;
			}
		}

		return isValid;

	}

	/*private BigDecimal getTotalAnswer(QuestionStore questionStore) {
		BigDecimal totalAnswer = questionStore.getAllowOtherFlg() ==  null ? BigDecimal.ZERO : questionStore.getAllowOtherFlg();
		for(AnswerStore answerStore :  questionStore.getAnswer())
        {
            BigDecimal activeFlg = answerStore.getActiveFlg() == null ? BigDecimal.ZERO : answerStore.getActiveFlg();
            totalAnswer = totalAnswer.add(activeFlg);

        }
		return totalAnswer;
	}*/
	
	private BigDecimal getTotalAnswer(QuestionStore questionStore) {
		BigDecimal totalAnswer = new BigDecimal(0);
		
		// Case 1: The question allow patient choose other answer
		// and patient choosed other answer
		BigDecimal allowOtherAnswer = questionStore.getAllowOtherFlg() ==  null ? BigDecimal.ZERO : questionStore.getAllowOtherFlg();
		if(allowOtherAnswer.compareTo(new BigDecimal(1)) == 0 && org.apache.commons.lang.StringUtils.isNotBlank(questionStore.getHasOtherText())) {
			totalAnswer = totalAnswer.add((new BigDecimal(1)));
			return totalAnswer;
		}
		
		// Case 2: The patient choose one or more normal answer
		for(AnswerStore answerStore :  questionStore.getAnswer()) {
            BigDecimal activeFlg = answerStore.getActiveFlg() == null ? BigDecimal.ZERO : answerStore.getActiveFlg();
            totalAnswer = totalAnswer.add(activeFlg);
        }
		return totalAnswer;
	}

	// CMS 20
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/set_active/{id_survey}")
	public Response setActiveSurvey(
			@Valid @NotNull(message = "id_survey is required") @PathParam("id_survey") Long idSurvey) {
		boolean isSuccess = surveyService.setActiveSurvey(idSurvey, CmsContext.current().getCmsSession().getHospCode());
		String responseStatus = Message.FAIL.getValue();
		String responseMessage = Message.MESSAGE_FAIL.getValue();
		if (isSuccess) {
			responseStatus = Message.SUCCESS.getValue();
			responseMessage = Message.MESSAGE_SUCCESS.getValue();
		}
		MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(responseMessage,
				responseStatus).build();
		return Response.ok().entity(messageResponse).build();
	}
	
	private String validateCreateSurvey(SurveyInfoModel model){
		if(CollectionUtils.isEmpty(model.getListquestionGroup())){
			return Message.CREATE_SURVEY_QUESTION_GROUP_REQUIRED.getValue();
		}
		for (SurveyQuestionGroupModel surveyQuestionGroup : model.getListquestionGroup()) {
			if(CollectionUtils.isEmpty(surveyQuestionGroup.getListQuestion())){
				return Message.CREATE_SURVEY_QUESTION_REQUIRED.getValue();
			}
		}
		return "";
	}
	
	private String validateSaveSurveyAnswer(PatientSurveyStore store){
		if(CollectionUtils.isEmpty(store.getGroup())){
			return Message.SURVEY_ANSWER_QUESTION_GROUP_REQUIRED.getValue();
		}
		for (QuestionGroupStore questionGroupStore : store.getGroup()) {
			if(CollectionUtils.isEmpty(questionGroupStore.getQuestion())){
				return Message.SURVEY_ANSWER_QUESTION_IN_GROUP_REQUIRED.getValue();
			}
			for (QuestionStore questionStore : questionGroupStore.getQuestion()) {
				if(CollectionUtils.isEmpty(questionStore.getAnswer())){
					return Message.SURVEY_ANSWER_ANSWER_IN_QUESTION_REQUIRED.getValue();
				}
			}
		}
		return "";
	}
	
	// CMS 08 ADD TOKEN
	@GET
	@Path("/do_patient_survey_by_token/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@TokenIgnore
	public Response getSurveyToDoByToken(@PathParam("token") String token) throws Exception {
		LOGGER.info("BEGIN do_patient_survey:" + new Date());
		PatientSurveyModel patientSurvey = surveyService.getPatientSurveyToDoByToken(token);
		MessageResponse<PatientSurveyModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyModel>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(patientSurvey).build();
		if (!patientSurvey.isResult()) {
			messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyModel>(patientSurvey.getError(),
					Message.FAIL.getValue()).setContent(patientSurvey).build();
		}
		LOGGER.info("END do_patient_survey:" + new Date());
		return Response.ok().entity(messageResponse).build();
	}
		
}
