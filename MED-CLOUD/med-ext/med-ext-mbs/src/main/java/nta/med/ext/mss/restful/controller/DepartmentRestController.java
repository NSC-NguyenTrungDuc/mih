package nta.med.ext.mss.restful.controller;

import nta.med.ext.mss.glossary.Message;
import nta.med.ext.mss.model.DepartmentModel;
import nta.med.ext.mss.model.MessageResponse;
import nta.med.ext.mss.model.SearchPatientModel;
import nta.med.ext.mss.model.UpdateDefaultScheduleModel;
import nta.med.ext.mss.service.DepartmentService;
import org.springframework.stereotype.Component;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.util.List;

/**
 * 
 * @author DEV-HuanLT
 *
 */
@Path("/mss/departments")
@Component
public class DepartmentRestController {

    @Resource
    private DepartmentService departmentService;

    public DepartmentRestController() {
    	//departmentService = SpringBeanFactory.beanFactory.getBean(DepartmentService.class);
    }

    public DepartmentRestController(DepartmentService departmentService) {
        this.departmentService = departmentService;
    }

    
    
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Response list(@Valid @NotNull(message = "hospital.code.required") @QueryParam("hospCode") String hospCode, 
    																		@QueryParam("locale") String locale) {
    	List<DepartmentModel> departments = departmentService.getDepartmentByHospitalCode(hospCode, locale);
        // set result
 		MessageResponse<List<DepartmentModel>> messageResponse = new MessageResponse.MessageResponseBuilder<List<DepartmentModel>>(
 				Message.MESSAGE_SUCCESS.getValue(),
 	            Message.SUCCESS.getValue()).setContent(departments).build();
 		
 		return Response.ok().entity(messageResponse).build();
    }
    
    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/update_default_schedule")
    public Response updateDefaultSchedule(@Valid @NotNull UpdateDefaultScheduleModel model) {
    	String result = departmentService.updateDefaultSchedule(model);
 		MessageResponse<UpdateDefaultScheduleModel> messageResponse = new MessageResponse.MessageResponseBuilder<UpdateDefaultScheduleModel>(
 				Message.MESSAGE_SUCCESS.getValue(),
 	            Message.SUCCESS.getValue()).build();
 		
 		return Response.ok().entity(messageResponse).build();
    }
}
