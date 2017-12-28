package nta.med.ext.mss.restful.controller;

import java.util.List;

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

import org.apache.commons.lang3.StringUtils;
import org.springframework.stereotype.Component;
import org.springframework.util.CollectionUtils;

import nta.med.data.model.ihis.nuro.KCCKGetDoctorWorkingTimeInfo;
import nta.med.ext.mss.glossary.Message;
import nta.med.ext.mss.model.AccountModel;
import nta.med.ext.mss.model.DoctorModel;
import nta.med.ext.mss.model.MessageResponse;
import nta.med.ext.mss.model.SearchDoctorModel;
import nta.med.ext.mss.service.BookingService;

/**
 * @author dainguyen.
 */
@Path("/mss/doctors")
@Component
public class DoctorRestController {

    @Resource
    private BookingService bookingService;

    public DoctorRestController() {
        //bookingService = SpringBeanFactory.beanFactory.getBean(BookingService.class);
    }

    public DoctorRestController(BookingService bookingService) {
        this.bookingService = bookingService;
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Response getListDoctor(@Valid @NotNull(message = "hospital.code.required") @QueryParam("hospCode") String hospCode, 
    		@Valid @NotNull(message = "department.code.required") @QueryParam("departmentCode") String departmentCode,
    		@QueryParam("locale") String locale) {
        List<DoctorModel> doctors = bookingService.findDoctorByDepartment(hospCode, departmentCode);
        // set result
  		MessageResponse<List<DoctorModel>> messageResponse = new MessageResponse.MessageResponseBuilder<List<DoctorModel>>(
  				Message.MESSAGE_SUCCESS.getValue(),
  	            Message.SUCCESS.getValue()).setContent(doctors).build();
  		return Response.ok().entity(messageResponse).build();
    }
    
    @SuppressWarnings("unchecked")
	@GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/kcck/schedule")
    public Response getDoctorSchedules(@Valid @NotNull(message = "hospital.code.required") @QueryParam("hosp_code") String hospCode, 
    		@Valid @NotNull(message = "department.code.required") @QueryParam("department_code") String departmentCode,
    		@QueryParam("doctor_code") String doctorCode,
    		@QueryParam("doctor_grade") String doctorGrade, 
    		@Valid @NotNull(message = "start.date.required") @QueryParam("start_date") String startDate, 
    		@Valid @NotNull(message = "end.date.required") @QueryParam("end_date") String endDate,
            @QueryParam("agv_time") String agv_time,
            @QueryParam("locale") String locale) {
    	MessageResponse<KCCKGetDoctorWorkingTimeInfo> rs = null ;
//    	List<KCCKGetScheduleDoctorInfo> doctors = bookingService.getKCCKGetScheduleDoctorInfo("K01", "2016/03/10", "01K01OCS");
        if(StringUtils.isEmpty(departmentCode))
        {
            departmentCode = "";
        }
        if(StringUtils.isEmpty(agv_time))
        {
            agv_time = "";
        }
        if(StringUtils.isEmpty(doctorCode))
        {
        	doctorCode = "";
        }
    	List<KCCKGetDoctorWorkingTimeInfo> doctors = bookingService.getDoctorScheduleInfo(hospCode, departmentCode, startDate, endDate, doctorCode, agv_time, doctorGrade);
    	if(!CollectionUtils.isEmpty(doctors)){
    		rs = new MessageResponse.MessageResponseBuilder<KCCKGetDoctorWorkingTimeInfo>(Message.MESSAGE_SUCCESS.getValue(),
					Message.SUCCESS.getValue()).setContent(doctors.get(0)).build();
    	}else{
    		rs = new MessageResponse.MessageResponseBuilder<KCCKGetDoctorWorkingTimeInfo>(Message.MESSAGE_SUCCESS.getValue(),
					Message.SUCCESS.getValue()).build();
    	}
        return Response.ok().entity(rs).build();
    }
    
    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/search")
    public Response getSearchDoctor(@Valid @NotNull(message = "param.body.required") SearchDoctorModel model) {
    	SearchDoctorModel searchDoctorModel = bookingService.searchDoctors(model);
        // set result
  		MessageResponse<SearchDoctorModel> messageResponse = new MessageResponse.MessageResponseBuilder<SearchDoctorModel>(
  				Message.MESSAGE_SUCCESS.getValue(),
  	            Message.SUCCESS.getValue()).setContent(searchDoctorModel).build();
  		return Response.ok().entity(messageResponse).build();
    }

    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/verify_account")
    public Response verifyAccount(@Valid @NotNull(message = "param.body.required") AccountModel model) {
    	AccountModel accountModel = bookingService.verifyAccount(model);
        // set result
    	if(!StringUtils.isEmpty(accountModel.getMessage())){
    		MessageResponse<AccountModel> messageResponse = new MessageResponse.MessageResponseBuilder<AccountModel>(
      				Message.VERIFY_ACCOUNT_FAIL_MSG.getValue(),
      	            Message.VERIFY_ACCOUNT_FAIL_CODE.getValue()).setContent(accountModel).build();
      		return Response.ok().entity(messageResponse).build();
    	}
  		MessageResponse<AccountModel> messageResponse = new MessageResponse.MessageResponseBuilder<AccountModel>(
  				Message.VERIFY_ACCOUNT_SUCCESS_MSG.getValue(),
  	            Message.VERIFY_ACCOUNT_SUCCESS_CODE.getValue()).setContent(accountModel).build();
  		return Response.ok().entity(messageResponse).build();
    }
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/session-information")
    public Response getDoctorInformationFromSession(@Valid @NotNull(message = "param.session_id.required")@QueryParam("session_id") String sessionId) {
        DoctorModel doctorModel = bookingService.getDoctorFromSession(sessionId);
        // set result
        MessageResponse<DoctorModel> messageResponse = new MessageResponse.MessageResponseBuilder<DoctorModel>(
                Message.MESSAGE_SUCCESS.getValue(),
                Message.SUCCESS.getValue()).setContent(doctorModel).build();
        return Response.ok().entity(messageResponse).build();

    }


}
