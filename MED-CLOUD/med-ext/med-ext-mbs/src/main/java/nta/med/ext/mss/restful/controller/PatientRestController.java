package nta.med.ext.mss.restful.controller;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.apache.logging.log4j.util.Strings;
import org.springframework.stereotype.Component;

import nta.med.data.model.mss.ReservationOnlineInfo;
import nta.med.ext.mss.glossary.Message;
import nta.med.ext.mss.model.MessageResponse;
import nta.med.ext.mss.model.PatientBasicInfoModel;
import nta.med.ext.mss.model.PatientInfoModel;
import nta.med.ext.mss.model.ReservationCodeModel;
import nta.med.ext.mss.model.ReservationModel;
import nta.med.ext.mss.service.PatientService;

/**
 * @author dainguyen.
 */
@Path("/mss/patient")
@Component
public class PatientRestController {

    @Resource
    private PatientService patientService;

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Response getPatient(@Valid @NotNull(message = "hospital.code.required") @QueryParam("hosp_code") String hospCode,
                               @Valid @NotNull(message = "hospital.patient_code.required") @QueryParam("patient_code") String  patientCode) {

        PatientBasicInfoModel patientBasicInfoModel = patientService.getPatient(hospCode, patientCode);
        // set result
        if(Strings.isEmpty(patientBasicInfoModel.getPatientCode()))
        {
           patientBasicInfoModel = null;
        }
        MessageResponse<PatientBasicInfoModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientBasicInfoModel>(
                Message.MESSAGE_SUCCESS.getValue(),
                Message.SUCCESS.getValue()).setContent(patientBasicInfoModel).build();

        return Response.ok().entity(messageResponse).build();
    }


    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/waiting-list")
    public Response getWaitingPatient(@QueryParam("doctor_code") String doctorCode, @QueryParam("examination_date")
    String examinationDate, @QueryParam("examination_situation") String examinationSituation, @QueryParam("patient_code") String patientCode,
                                     @QueryParam("hosp_code") String hosp_code, @QueryParam("department_code") String departmentCode,  @QueryParam("locale") String locale
                                     ) {
        List<ReservationModel> reservationModels;
        if(Strings.isEmpty(patientCode))
        {
            reservationModels = patientService.getWaitingPatient(examinationDate, examinationSituation, departmentCode, doctorCode, hosp_code, locale, new ArrayList<String>());
        }
        else
        {
            List<String> patientCodes = new ArrayList<>();
            String[] patients = patientCode.split(",");
            for(String patientItem : patients)
            {
                patientCodes.add(patientItem);
            }
            reservationModels = patientService.getWaitingPatient(examinationDate, examinationSituation, departmentCode, doctorCode, hosp_code, locale, patientCodes);
        }


        MessageResponse<List<ReservationModel>> messageResponse = new MessageResponse.MessageResponseBuilder<List<ReservationModel>>(
                Message.MESSAGE_SUCCESS.getValue(),
                Message.SUCCESS.getValue()).setContent(reservationModels).build();

        return Response.ok().entity(messageResponse).build();


    }
    @PUT
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/calling-id")
    public Response getWaitingPatient(@Valid @NotNull(message = "param.body.required") ReservationModel model)
    {
        ReservationModel reservationModel = patientService.saveCallingId(model.getReservationCode(), model.getMtCallingId(), model.getHospitalId());

        MessageResponse<ReservationModel> messageResponse = new MessageResponse.MessageResponseBuilder<ReservationModel>(
                Message.MESSAGE_SUCCESS.getValue(),
                Message.SUCCESS.getValue()).setContent(reservationModel).build();

        return Response.ok().entity(messageResponse).build();
    }
    
    @PUT
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/update-calling-id")
    public Response updateMtCallingId(@Valid @NotNull(message = "param.body.required") ReservationModel model)
    {
        ReservationModel reservationModel = patientService.updateCallingId(model.getReservationCode(), model.getMtCallingId(), model.getHospitalCode());
        if(reservationModel != null && model.getReservationCode().equalsIgnoreCase(reservationModel.getReservationCode())) {
        	MessageResponse<ReservationModel> messageResponse = new MessageResponse.MessageResponseBuilder<ReservationModel>(
                    Message.MESSAGE_SUCCESS.getValue(),
                    Message.SUCCESS.getValue()).setContent(reservationModel).build();

            return Response.ok().entity(messageResponse).build();
        } else {
        	MessageResponse<ReservationModel> messageResponse = new MessageResponse.MessageResponseBuilder<ReservationModel>(
                    Message.MESSAGE_FAIL.getValue(),
                    Message.FAIL.getValue()).setContent(reservationModel).build();

            return Response.ok().entity(messageResponse).build();
        }
        
    }
    
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/get-patient-info")
    public Response getPatientInfo(@Valid @NotNull(message = "hospital.code.required") @QueryParam("hosp_id") String hospId,
                               @Valid @NotNull(message = "hospital.patient_code.required") @QueryParam("patient_code") String  patientCode) {

    	PatientInfoModel patientModel = patientService.getPatientInfo(hospId, patientCode);
        // set result
        if(Strings.isEmpty(patientModel.getCardNumber())) {
        	patientModel = null;
        }
        MessageResponse<PatientInfoModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientInfoModel>(
                Message.MESSAGE_SUCCESS.getValue(),
                Message.SUCCESS.getValue()).setContent(patientModel).build();

        return Response.ok().entity(messageResponse).build();
    }
    
    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/list-reservation-by-code")
    public Response  getListReservationByCode(ReservationCodeModel reservationCodeModel) {
        List<ReservationOnlineInfo> reservationModels = patientService.findReservationInfoByReCodeHosId(reservationCodeModel.getHospitalId(), reservationCodeModel.getReservationCodes());
        MessageResponse<List<ReservationOnlineInfo>> messageResponse = new MessageResponse.MessageResponseBuilder<List<ReservationOnlineInfo>>(
                Message.MESSAGE_SUCCESS.getValue(),
                Message.SUCCESS.getValue()).setContent(reservationModels).build();

        return Response.ok().entity(messageResponse).build();


    }
    
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/get-patient-info-by-profile-id")
    public Response getPatientInfoByProfileId(@Valid @NotNull(message = "hospital.code.required") @QueryParam("profile_id") String profileId) {

    	List<PatientInfoModel> patientModels = patientService.findPatientInfoByProfileId(profileId);
    	PatientInfoModel patientInfoModel = null;
    	if(patientModels != null && patientModels.size() > 0) {
    		patientInfoModel = patientModels.get(0);
    	}
    	MessageResponse<PatientInfoModel> messageResponse = new MessageResponse.MessageResponseBuilder<PatientInfoModel>(
                Message.MESSAGE_SUCCESS.getValue(),
                Message.SUCCESS.getValue()).setContent(patientInfoModel).build();

        return Response.ok().entity(messageResponse).build();
    }
}
