
package nta.med.ext.cms.restful.controller;

import java.util.List;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.springframework.stereotype.Component;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.common.annotation.TokenIgnore;
import nta.med.core.domain.cms.CmsSurveyPatient;
import nta.med.core.utils.EncryptionUtils;
import nta.med.ext.cms.config.Configuration;
import nta.med.ext.cms.glossary.Message;
import nta.med.ext.cms.model.MessageResponse;
import nta.med.ext.cms.model.cms.CmsContext;
import nta.med.ext.cms.model.cms.DashboardModel;
import nta.med.ext.cms.model.cms.HospitalInfoModel;
import nta.med.ext.cms.model.cms.PatientSurveyInform;
import nta.med.ext.cms.model.cms.PatientSurveyModel;
import nta.med.ext.cms.model.cms.PhrAccountModel;
import nta.med.ext.cms.service.HospitalService;
import nta.med.ext.cms.service.SurveyService;

@Path("/cms/hospital")
@Component
public class HospitalRestController {

	@Resource
	private Configuration configuration;

	@Resource
	private HospitalService hospitalService;

	@Resource
	private SurveyService surveyService;

	public HospitalRestController() {
//		configuration = SpringBeanFactory.beanFactory.getBean(Configuration.class);
//		hospitalService = SpringBeanFactory.beanFactory.getBean(HospitalService.class);
//		surveyService = SpringBeanFactory.beanFactory.getBean(SurveyService.class);

	}

	@GET
	@Path("/health-check")
	@TokenIgnore
	public Response test(){
		return Response.ok().entity("success").build();
	}

	// get hospital information
	@GET
	@Path("/{code}")
	@Produces({MediaType.APPLICATION_JSON})
	@TokenIgnore
	public Response getHospitalInfo(
			@Valid @NotNull(message = "hospcode.invaild") @PathParam("code") String hospCodeKey) {

		String hospCode = EncryptionUtils.decrypt(hospCodeKey, configuration.getSecretKey(),
				EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
		if(StringUtils.isEmpty(hospCode)){
			// set result
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(
					Message.HOSP_CODE_INVALID.getValue(), Message.FAIL.getValue()).build();

			return Response.ok().entity(messageResponse).build();
		}

		List<HospitalInfoModel> listCmsHospitalInfoModel = hospitalService.getListHospitalModel(hospCode);
		HospitalInfoModel hospitalModel = new HospitalInfoModel();
		if (listCmsHospitalInfoModel != null && !listCmsHospitalInfoModel.isEmpty()) {
			hospitalModel = listCmsHospitalInfoModel.get(0);
		}

		// set result
		MessageResponse<HospitalInfoModel> messageResponse = new MessageResponse.MessageResponseBuilder<HospitalInfoModel>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(hospitalModel).build();

		return Response.ok().entity(messageResponse).build();

	}

	// CMS 11 -- Show dashboard of survey follow day|week|month|all
	@GET
	@Path("/dashboard")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getDashboard(@Valid @NotNull(message = "type is required") @QueryParam("type") Integer type,
			@Valid @NotNull(message = "page_size is required") @QueryParam("page_size") Integer pageSize,
			@Valid @NotNull(message = "page_index is required") @QueryParam("page_index") Integer pageIndex) {

		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		DashboardModel cmsDashBoardModel = hospitalService.findAnsweredAndWaitingByHospCode(hospCode, type, pageIndex, pageSize, true);
		DashboardModel cmsTotalDashBoardModel = hospitalService.findAnsweredAndWaitingByHospCode(hospCode, type,0, 0, false);
		
		cmsDashBoardModel.setTotalHospAnswered(cmsTotalDashBoardModel.getTotalHospAnswered());
		cmsDashBoardModel.setTotalHospWaiting(cmsTotalDashBoardModel.getTotalHospWaiting());
		cmsDashBoardModel.setRecordsFiltered(cmsTotalDashBoardModel.getDepartmentList().size());
		cmsDashBoardModel.setRecordsTotal(cmsTotalDashBoardModel.getDepartmentList().size());

		MessageResponse<DashboardModel> messageResponse = new MessageResponse.MessageResponseBuilder<DashboardModel>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(cmsDashBoardModel).build();

		return Response.ok().entity(messageResponse).build();
	}

	// CMS 12 -- Search survey of patient
	@POST
	@Path("/dashboard/search")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getListSurveyPatient(
			@Valid @NotNull(message = "page_size is required") @QueryParam("page_size") Integer pageSize,
			@Valid @NotNull(message = "page_index is required") @QueryParam("page_index") Integer pageIndex,
			@QueryParam("column") String column,
			@QueryParam("dir") String dir,
			@Valid @NotNull PatientSurveyModel model) {

		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		List<PatientSurveyModel> listQuestionModel = hospitalService.getListSurveyPatient(hospCode, model,
				pageIndex * pageSize - pageSize, pageSize, column, dir, true);
		List<PatientSurveyModel> total = hospitalService.getListSurveyPatient(hospCode, model,
				0, 0, column, dir, false);
		
		PatientSurveyInform record = new PatientSurveyInform();
    	record.setPatientSurveyList(listQuestionModel);
    	record.setRecordsFiltered(total.size());
    	record.setRecordsTotal(total.size());
		
		MessageResponse<PatientSurveyInform> messageResponse = new MessageResponse.MessageResponseBuilder<PatientSurveyInform>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(record).build();

		return Response.ok().entity(messageResponse).build();
	}

	// cms 19 -- Export PhrAccount
	@GET
	@Path("/export_phr/{id_survey_patient}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getPhrAccount(
			@Valid @NotNull(message = "id_survey_patient is required") @PathParam("id_survey_patient") Long surveyPatientId) {

		PhrAccountModel phrAccountModel = hospitalService.getPhrAccountModel(surveyPatientId, CmsContext.current().getCmsSession().getHospCode());
		MessageResponse<PhrAccountModel> messageResponse = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(phrAccountModel).build();

		return Response.ok().entity(messageResponse).build();

	}
	
	// cms 19 -- Export PhrAccount Token
	@GET
	@Path("/export_phr_token/{id_survey_patient}/{token}")
	@TokenIgnore
	@Produces(MediaType.APPLICATION_JSON)
	public Response getPhrAccountByToken(
			@Valid @NotNull(message = "id_survey_patient is required") @PathParam("id_survey_patient") Long surveyPatientId,
			@Valid @NotNull(message = "id_token is required") @PathParam("token") String token) {

		CmsSurveyPatient surveypatient = surveyService.getSurveyPatientByToken(token);
		String hospCode = surveypatient.getHospCode();
		PhrAccountModel phrAccountModel = hospitalService.getPhrAccountModel(surveyPatientId, hospCode);
		MessageResponse<PhrAccountModel> messageResponse = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
				Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(phrAccountModel).build();

		return Response.ok().entity(messageResponse).build();

	}

	// CMS 21 get hospital information by hosp code not enscrypt
	@GET
	@Path("/search")
	@Produces({MediaType.APPLICATION_JSON})
	@TokenIgnore
	public Response getHospitalInfoByHospCode(@Valid @NotNull(message = "hospcode.invaild") @QueryParam("hosp_code") String hospCode) {
		
		List<HospitalInfoModel> listCmsHospitalInfoModel = hospitalService.getListHospitalModel(hospCode);
		HospitalInfoModel hospitalModel = new HospitalInfoModel();
		MessageResponse<HospitalInfoModel> messageResponse ;
		if (!CollectionUtils.isEmpty(listCmsHospitalInfoModel)) {
			hospitalModel = listCmsHospitalInfoModel.get(0);
			String hospCodeEnscypt = EncryptionUtils.encrypt(hospitalModel.getHospCode(), configuration.getSecretKey(),
					EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
			hospitalModel.setDescryptHospCode(hospCodeEnscypt);
			messageResponse = new MessageResponse.MessageResponseBuilder<HospitalInfoModel>(
						Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(hospitalModel).build();
		}else{
			hospitalModel = hospitalService.searchHospitalByHospCode(hospCode);
			if(!StringUtils.isEmpty(hospitalModel.getHospCode())){
				String hospCodeEnscypt = EncryptionUtils.encrypt(hospitalModel.getHospCode(), configuration.getSecretKey(),
						EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
				hospitalModel.setDescryptHospCode(hospCodeEnscypt);
				messageResponse = new MessageResponse.MessageResponseBuilder<HospitalInfoModel>(
						Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(hospitalModel).build();
			}else{
				 messageResponse = new MessageResponse.MessageResponseBuilder<HospitalInfoModel>(
						Message.MESSAGE_FAIL.getValue(), Message.FAIL.getValue()).setContent(hospitalModel).build();
			}
		}
		return Response.ok().entity(messageResponse).build();
	}
	
	@GET
	@Path("/search_token")
	@Produces({MediaType.APPLICATION_JSON})
	@TokenIgnore
	public Response getHospitalInfoByToken(@Valid @NotNull(message = "token.invaild") @QueryParam("token") String token) {
		MessageResponse<HospitalInfoModel> messageResponse ;
		HospitalInfoModel hospitalModel = new HospitalInfoModel();
		
		CmsSurveyPatient cmsSurveyPatient = surveyService.getSurveyPatientByToken(token);
		String hospCode = null;
		if(cmsSurveyPatient != null) {
			hospCode = cmsSurveyPatient.getHospCode();
		} else {
			messageResponse = new MessageResponse.MessageResponseBuilder<HospitalInfoModel>(
					Message.MESSAGE_FAIL.getValue(), Message.FAIL.getValue()).setContent(hospitalModel).build();
			return Response.ok().entity(messageResponse).build();
		}
		
		List<HospitalInfoModel> listCmsHospitalInfoModel = hospitalService.getListHospitalModel(hospCode);
		
		if (!CollectionUtils.isEmpty(listCmsHospitalInfoModel)) {
			hospitalModel = listCmsHospitalInfoModel.get(0);
			String hospCodeEnscypt = EncryptionUtils.encrypt(hospitalModel.getHospCode(), configuration.getSecretKey(),
					EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
			hospitalModel.setDescryptHospCode(hospCodeEnscypt);
			messageResponse = new MessageResponse.MessageResponseBuilder<HospitalInfoModel>(
						Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(hospitalModel).build();
		}else{
			hospitalModel = hospitalService.searchHospitalByHospCode(hospCode);
			if(!StringUtils.isEmpty(hospitalModel.getHospCode())){
				String hospCodeEnscypt = EncryptionUtils.encrypt(hospitalModel.getHospCode(), configuration.getSecretKey(),
						EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
				hospitalModel.setDescryptHospCode(hospCodeEnscypt);
				messageResponse = new MessageResponse.MessageResponseBuilder<HospitalInfoModel>(
						Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(hospitalModel).build();
			}else{
				 messageResponse = new MessageResponse.MessageResponseBuilder<HospitalInfoModel>(
						Message.MESSAGE_FAIL.getValue(), Message.FAIL.getValue()).setContent(hospitalModel).build();
			}
		}
		return Response.ok().entity(messageResponse).build();
	}
}
