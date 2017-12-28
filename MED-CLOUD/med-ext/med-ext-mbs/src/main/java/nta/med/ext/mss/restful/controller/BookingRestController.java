package nta.med.ext.mss.restful.controller;

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

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.ext.mss.glossary.Message;
import nta.med.ext.mss.model.BookingModel;
import nta.med.ext.mss.model.BookinglabSchedule;
import nta.med.ext.mss.model.CancelBookingModel;
import nta.med.ext.mss.model.ChangeBookingModel;
import nta.med.ext.mss.model.MessageResponse;
import nta.med.ext.mss.model.PendingStatusModel;
import nta.med.ext.mss.model.VaccineBookingModel;
import nta.med.ext.mss.service.BookingService;

/**
 * 
 * @author DEV-HuanLT
 *
 */
@Path("/mss/booking")
@Component
public class BookingRestController {

	private static final Log LOGGER = LogFactory.getLog(BookingRestController.class);

	@Resource
    private BookingService bookingService;

    public BookingRestController() {
    }

    public BookingRestController(BookingService bookingService) {
        this.bookingService = bookingService;
    }

    @POST
    @Produces(MediaType.APPLICATION_JSON)
    public Response bookingExamination(@Valid @NotNull BookingModel model) {
    	LOGGER.info("BookingRestController: bookingExamination: INPUT_DATA!!!" + model.toString());
    	model.setDoctorCode(model.getDoctorCode() != null ? model.getDepartmentCode().concat(model.getDoctorCode()) : model.getDoctorCode());
    	if(!Message.SUCCESS.getValue().equals(validBooking(model))){
    		MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(
     				Message.MESSAGE_FAIL.getValue(),
     	            Message.FAIL.getValue()).setContent(validBooking(model)).build();
    		LOGGER.warn("BookingRestController: bookingExamination: FAIL!!!" + model.toString());
     		return Response.ok().entity(messageResponse).build();
    	}
    	
    	BookingModel bookingModel = bookingService.bookingExamination(model);
    	if(!bookingModel.isResult()){
    		MessageResponse<BookingModel> messageResponse = new MessageResponse.MessageResponseBuilder<String>(
     				Message.MESSAGE_FAIL.getValue(),
     	            Message.FAIL.getValue()).setContent(null).build();
    		LOGGER.warn("BookingRestController: bookingExamination: FAIL!!!" + bookingModel.toString());
     		return Response.ok().entity(messageResponse).build();
    	}
    	MessageResponse<BookingModel> messageResponse = new MessageResponse.MessageResponseBuilder<BookingModel>(
 				Message.MESSAGE_SUCCESS.getValue(),
 	            Message.SUCCESS.getValue()).setContent(bookingModel).build();
 		
    	LOGGER.info("BookingRestController: bookingExamination: SUCCESS!!!" + bookingModel.toString());
 		return Response.ok().entity(messageResponse).build();
    }
    
    
    @POST
    @Path("/change_booking")
    @Produces(MediaType.APPLICATION_JSON)
    public Response changeBookingExamination(@Valid @NotNull ChangeBookingModel model) {
    	LOGGER.info("BookingRestController: changeBookingExamination: INPUT_DATA!!!" + model.toString());
    	model.setDoctorCode(model.getDoctorCode() != null ? model.getDepartmentCode().concat(model.getDoctorCode()) : model.getDoctorCode());
    	ChangeBookingModel bookingModel = new ChangeBookingModel();
    	bookingModel = bookingService.changeBookingExamination(model);
    	if(!bookingModel.isResult()){
    		MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(
     				Message.MESSAGE_FAIL.getValue(),
     	            Message.FAIL.getValue()).setContent(bookingModel.getError()).build();
    		LOGGER.warn("BookingRestController: changeBookingExamination: FAIL!!!" + bookingModel.toString());
     		return Response.ok().entity(messageResponse).build();
    	}
    	
    	MessageResponse<ChangeBookingModel> messageResponse = new MessageResponse.MessageResponseBuilder<ChangeBookingModel>(
 				Message.MESSAGE_SUCCESS.getValue(),
 	            Message.SUCCESS.getValue()).setContent(bookingModel).build();
    	LOGGER.info("BookingRestController: changeBookingExamination: SUCCESS!!!" + bookingModel.toString());
 		return Response.ok().entity(messageResponse).build();
    }
    
    @POST
    @Path("/cancel_booking")
    @Produces(MediaType.APPLICATION_JSON)
    public Response cancelBookingExamination(@Valid @NotNull CancelBookingModel model) {
    	LOGGER.info("BookingRestController: cancelBookingExamination: INPUT_DATA!!!" + model.toString());
    	MessageResponse<CancelBookingModel> messageResponse = null;
    	model = bookingService.cancelBookingExamination(model);
        if(model.isResult()){
     		messageResponse = new MessageResponse.MessageResponseBuilder<CancelBookingModel>(
     				Message.MESSAGE_SUCCESS.getValue(),
     	            Message.SUCCESS.getValue()).setContent(model).build();
     		LOGGER.info("BookingRestController: cancelBookingExamination: SUCCESS!!!" + model.toString());
        } else {
        	messageResponse = new MessageResponse.MessageResponseBuilder<CancelBookingModel>(
        			model.getError(),
     	            Message.FAIL.getValue()).setContent(model).build();
        	LOGGER.info("BookingRestController: cancelBookingExamination: FAIL!!!" + model.toString());
        }
        
 		return Response.ok().entity(messageResponse).build();
    }
    
    @POST
    @Path("/vaccine_booking")
    @Produces(MediaType.APPLICATION_JSON)
    public Response bookingVaccine(@Valid @NotNull VaccineBookingModel model) {
    	VaccineBookingModel vacine = new VaccineBookingModel();
    	BeanUtils.copyProperties(model, vacine, "JA");
    	vacine.setDoctorName("Demo Doctor");
    	vacine.setDepartmentName("Dept Name");
    	
 		MessageResponse<VaccineBookingModel> messageResponse = new MessageResponse.MessageResponseBuilder<VaccineBookingModel>(
 				Message.MESSAGE_SUCCESS.getValue(),
 	            Message.SUCCESS.getValue()).setContent(vacine).build();
 		
 		return Response.ok().entity(messageResponse).build();
    }

	@GET
	@Path("/test")
	public Response test(){
		return Response.ok().entity("success").build();
	}
    
    @GET
    @Path("/bookinglab_schedule")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getBookinglabSchedule(@Valid @NotNull(message = "hospital.code.required") @QueryParam("hosp_code") String hospCode,
    									  @Valid @NotNull(message = "jundal.table.required") @QueryParam("jundal_table") String jundalTable,
    									  @Valid @NotNull(message = "jundal.part.required") @QueryParam("jundal_part") String jundalPart,
    									  @Valid @NotNull(message = "avg.time.required") @QueryParam("avg_time") String avgTime,
    									  @Valid @NotNull(message = "start.date.required") @QueryParam("start_date") String startDate,
    									  @Valid @NotNull(message = "end.date.required") @QueryParam("end_date") String endDate,
    									  @QueryParam("locale") String locale){
    	
    	BookinglabSchedule bs = new BookinglabSchedule();
    	bs.setStartTimeHhmm("0800");
    	bs.setEndTimeHhmm("1200");
    	bs.setAvgTime(15);
    	bs.fData();
    	
 		MessageResponse<BookinglabSchedule> messageResponse = new MessageResponse.MessageResponseBuilder<BookinglabSchedule>(
 				Message.MESSAGE_SUCCESS.getValue(),
 	            Message.SUCCESS.getValue()).setContent(bs).build();
 		
 		return Response.ok().entity(messageResponse).build();
    }
    
    private String validBooking(BookingModel model){
    	if (!StringUtils.isEmpty(model.getReservationDate()) && DateUtil.toDate(model.getReservationDate(), DateUtil.PATTERN_YYMMDD) == null) {
    		return Message.RESERVATION_DATE_INVALID.getValue();
		}
		if (!StringUtils.isEmpty(model.getPatientBirthday()) && DateUtil.toDate(model.getPatientBirthday(), DateUtil.PATTERN_YYMMDD) == null) {
			return Message.BIRTH_DATE_INVALID.getValue();
		}
		if(StringUtils.isEmpty(model.getPatientCode())){
			if(StringUtils.isEmpty(model.getPatientNameKanji())){
				return Message.SURNAME1_REQUIRED.getValue();
			}
			if(StringUtils.isEmpty(model.getPatientNameKana())){
				return Message.SURNAME2_REQUIRED.getValue();
			}
		}
		return Message.SUCCESS.getValue();
    }
    
    @GET
    @Path("/pending_status")
    @Produces(MediaType.APPLICATION_JSON)
    public Response pendingStatus(@Valid @NotNull(message = "hospital.code.required") @QueryParam("hosp_code") String hospCode,
    									  @Valid @NotNull(message = "department.code.required") @QueryParam("department_code") String departmentCode,
    									  @QueryParam("time") String time,
    									  @QueryParam("locale") String locale){
    	PendingStatusModel pendingModel = new PendingStatusModel();
    	pendingModel.setCurrentTime("0800");
    	pendingModel.setMaxReservationTime("0800");
    	MessageResponse<PendingStatusModel> messageResponse = new MessageResponse.MessageResponseBuilder<PendingStatusModel>(
 				Message.MESSAGE_SUCCESS.getValue(),
 	            Message.SUCCESS.getValue()).setContent(pendingModel).build();
 		
 		return Response.ok().entity(messageResponse).build();
    }
    
}
