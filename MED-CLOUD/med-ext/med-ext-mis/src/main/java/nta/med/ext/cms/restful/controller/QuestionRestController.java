package nta.med.ext.cms.restful.controller;

import nta.med.ext.cms.glossary.Message;
import nta.med.ext.cms.model.MessageResponse;
import nta.med.ext.cms.model.cms.*;
import nta.med.ext.cms.service.SurveyService;
import org.apache.commons.collections.CollectionUtils;
import org.springframework.stereotype.Component;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.util.List;

@Path("/cms")
@Component
public class QuestionRestController {

	@Resource
	private SurveyService surveyService;

	public QuestionRestController() {
		//surveyService = SpringBeanFactory.beanFactory.getBean(SurveyService.class);
	}

	
	// get list of question
	@POST
	@Path("/questions")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getListQuestion(@Valid @NotNull(message = "page_size is required") @QueryParam("page_size") Integer pageSize,
									@Valid @NotNull(message = "page_index is required") @QueryParam("page_index") Integer pageIndex,
									@QueryParam("column") String column,
									@QueryParam("dir") String dir,
									@Valid @NotNull QuestionModel model){
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		List<QuestionModel> listQuestionModel = surveyService.getListCmsQuestion(hospCode, model, pageIndex*pageSize - pageSize, pageSize, column, dir , true);
		List<QuestionModel> total = surveyService.getListCmsQuestion(hospCode, model, 0, 0, column, dir, false );
		
		QuestionInform record = new QuestionInform();
		record.setQuestionlist(listQuestionModel);
		record.setRecordsFiltered(total.size());
		record.setRecordsTotal(total.size());
		
		
		MessageResponse<QuestionInform> messageResponse = new MessageResponse.MessageResponseBuilder<QuestionInform>(Message.MESSAGE_SUCCESS.getValue(),
	                Message.SUCCESS.getValue()).setContent(record).build();
		 
	    return Response.ok().entity(messageResponse).build();
	}
	
	
	// get a question by id
	@GET
	@Path("/question/{question_id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getQuestionById(@PathParam("question_id") Long questionId){
		
		QuestionDetailModel questionDetailModel = surveyService.getCmsQuestionById(questionId, CmsContext.current().getCmsSession().getHospCode());
		MessageResponse<QuestionDetailModel> messageResponse = new MessageResponse.MessageResponseBuilder<QuestionDetailModel>(Message.MESSAGE_SUCCESS.getValue(),
	                Message.SUCCESS.getValue()).setContent(questionDetailModel).build();
		 
	    return Response.ok().entity(messageResponse).build();
	}
	
	// insert new question
	@POST
	@Path("/question")
	@Produces(MediaType.APPLICATION_JSON)
	public Response insertQuestionDetail(@Valid @NotNull QuestionDetailModel model){
		
		String hospCode = CmsContext.current().getCmsSession().getHospCode();
		if(!hospCode.equals(model.getHospCode())){
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.HOSP_CODE_INVALID.getValue(),
					Message.FAIL.getValue()).build();
			return Response.ok().entity(messageResponse).build();
		}
		if(CollectionUtils.isEmpty(model.getAnswerList()))
		{
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.QUESTION_HAS_AT_LEAST_ANSWER.getValue(),
					Message.FAIL.getValue()).build();
			return Response.ok().entity(messageResponse).build();
		}
		boolean isSuccess = surveyService.insertQuestionDetail(model);
		String responseStatus = Message.FAIL.getValue();
		String responseMessage = Message.MESSAGE_FAIL.getValue();
		
		if(isSuccess){
			responseStatus = Message.SUCCESS.getValue();
			responseMessage = Message.MESSAGE_SUCCESS.getValue();
		}
		
		MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(responseMessage, responseStatus).build();
		return Response.ok().entity(messageResponse).build();
	}

	
	
	// delete list of question by id
	@POST
	@Path("/question/delete")
	@Produces(MediaType.APPLICATION_JSON)
	public Response deleteQuestions(@Valid @NotNull List<CommonDelModel> delModel){
		boolean isSuccess = surveyService.deleteQuestionList(delModel, CmsContext.current().getCmsSession().getHospCode());
		String responseStatus = Message.FAIL.getValue();
		String responseMessage = Message.MESSAGE_FAIL.getValue();
		
		if(isSuccess){
			responseStatus = Message.SUCCESS.getValue();
			responseMessage = Message.MESSAGE_SUCCESS.getValue();
		}
		
		MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(responseMessage, responseStatus).build();
		return Response.ok().entity(messageResponse).build();
	}
	
	// update question
		@PUT
		@Path("/question")
		@Produces(MediaType.APPLICATION_JSON)
		public Response updateQuestionDetail(@Valid @NotNull QuestionDetailModel model){
			
			String hospCode = CmsContext.current().getCmsSession().getHospCode();
			if(!hospCode.equals(model.getHospCode())){
				MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.HOSP_CODE_INVALID.getValue(),
						Message.FAIL.getValue()).build();
				return Response.ok().entity(messageResponse).build();
			}
			if(CollectionUtils.isEmpty(model.getAnswerList()))
			{
				MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.QUESTION_HAS_AT_LEAST_ANSWER.getValue(),
						Message.FAIL.getValue()).build();
				return Response.ok().entity(messageResponse).build();
			}
			boolean isSuccess = surveyService.updateQuestionDetail(model);
			String responseStatus = Message.FAIL.getValue();
			String responseMessage = Message.MESSAGE_FAIL.getValue();
			
			if(isSuccess){
				responseStatus = Message.SUCCESS.getValue();
				responseMessage = Message.MESSAGE_SUCCESS.getValue();
			}
			
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(responseMessage, responseStatus).build();
			return Response.ok().entity(messageResponse).build();
		}
	
	
}
