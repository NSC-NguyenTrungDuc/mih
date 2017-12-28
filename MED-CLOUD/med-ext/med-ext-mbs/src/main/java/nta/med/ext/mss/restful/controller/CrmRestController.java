package nta.med.ext.mss.restful.controller;

import nta.med.ext.mss.glossary.Message;
import nta.med.ext.mss.model.MessageResponse;
import nta.med.ext.mss.model.SearchPatientModel;
import nta.med.ext.mss.service.CrmService;
import org.springframework.stereotype.Component;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

@Path("/mss/crm")
@Component
public class CrmRestController {

	@Resource
	private CrmService crmService;

	public CrmRestController() {
		//crmService = SpringBeanFactory.beanFactory.getBean(CrmService.class);
	}

	public CrmRestController(CrmService crmService) {
		this.crmService = crmService;
	}
	
    @POST
    @Path("/search")
    @Produces(MediaType.APPLICATION_JSON)
    public Response crmSearch(@Valid @NotNull SearchPatientModel model) {
    	SearchPatientModel searchPatientModel = crmService.getPatientDetailResultInfo(model);
 		MessageResponse<SearchPatientModel> messageResponse = new MessageResponse.MessageResponseBuilder<SearchPatientModel>(
 				Message.MESSAGE_SUCCESS.getValue(),
 	            Message.SUCCESS.getValue()).setContent(searchPatientModel).build();
 		
 		return Response.ok().entity(messageResponse).build();
    }
}
