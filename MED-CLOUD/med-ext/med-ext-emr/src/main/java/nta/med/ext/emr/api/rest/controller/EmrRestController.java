package nta.med.ext.emr.api.rest.controller;

import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.ext.emr.glossary.Message;
import nta.med.ext.emr.model.EmrRecordModel;
import nta.med.ext.emr.model.MessageResponse;
import nta.med.ext.emr.service.EmrService;
import nta.med.ext.emr.service.SystemService;

/**
 * @author dainguyen.
 */
@Path("/emr")
public class EmrRestController {

    private SystemService systemService;
    private EmrService emrService;
    
    public EmrRestController() {
        systemService = SpringBeanFactory.beanFactory.getBean(SystemService.class);
        emrService = SpringBeanFactory.beanFactory.getBean(EmrService.class);
    }

    @GET
    @Path("/test")
    @Produces(MediaType.APPLICATION_JSON)
    public Response hello() {

        boolean authenticate = systemService.authenticate("SAM001", "b59c67bf196a4758191e42f76670ceba", "NTA");
        return Response.ok().entity("Hello, World!" + authenticate).build();
    }

    @GET
    @Path("/get")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getEmr(	@Valid @NotNull(message = "patient_code is required") @QueryParam("patient_code") String patientCode,
    						@Valid @NotNull(message = "hosp_code is required") @QueryParam("hosp_code") String hospCode,
    						@Valid @NotNull(message = "format is required") @QueryParam("format") String format){
    	EmrRecordModel emrRecord = emrService.findEmrRecordByPatientCodeAndHospCode(patientCode, hospCode);
    	MessageResponse<EmrRecordModel> messageResponse = new MessageResponse.MessageResponseBuilder<EmrRecordModel>(Message.MESSAGE_SUCCESS.getValue(),
                Message.SUCCESS.getValue()).setContent(emrRecord).build();
    	
    	return Response.ok().entity(messageResponse).build();
    }
    
}
