package nta.med.ext.phr.restful.controller;

import com.google.common.util.concurrent.FutureCallback;
import com.google.common.util.concurrent.Futures;
import com.google.common.util.concurrent.ListenableFuture;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.*;
import nta.med.ext.phr.service.KcckServices;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.glassfish.jersey.server.ManagedAsync;
import org.springframework.stereotype.Component;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.*;
import javax.ws.rs.container.AsyncResponse;
import javax.ws.rs.container.Suspended;
import javax.ws.rs.core.MediaType;
import java.util.List;

@Path("/kcck")
@Component
public class KcckResource extends BaseResource{

	private static final Log LOGGER = LogFactory.getLog(KcckResource.class);

	@Resource
	private KcckServices kcckServices;
	
	public KcckResource(){
		//this.kcckServices = SpringBeanFactory.beanFactory.getBean(KcckServices.class);
	}
	
	@GET
	@Path("/get_disease")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getDisease(	@Valid @NotNull(message = "patient_code.required") @QueryParam("patient_code") String patientCode,
							@Valid @NotNull(message = "hosp_code.required") @QueryParam("hosp_code") String hospCode,
							@Suspended final AsyncResponse response){
		
		ListenableFuture<PatientDiseaseWrapper> patientDiseaseWrapper = asyncExecute(() -> kcckServices.getPatientDisease(patientCode, hospCode));
		callBackAndResponse(patientDiseaseWrapper, response);
	}

	@GET
	@Path("/get_medicine")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getMedicine(@Valid @NotNull(message = "patient_code.required") @QueryParam("patient_code") String patientCode,
							@Valid @NotNull(message = "hosp_code.required") @QueryParam("hosp_code") String hospCode,
							@Suspended final AsyncResponse response){
		ListenableFuture<PatientMedicineWrapper> patientMedicineWrapper = asyncExecute(() -> kcckServices.getPatientMedicine(patientCode, hospCode));
		callBackAndResponse(patientMedicineWrapper, response);
	}
	
	@GET
	@Path("/get_hospital_name")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	//@TokenIgnore
	public void getHospitalName(@QueryParam("hosp_name") String hospName, 
								@QueryParam("address") String address, 
								@QueryParam("tel") String tel, 
								@QueryParam("country_code") String countryCode,
								@Suspended final AsyncResponse response){
		
		String fHospName = hospName == null ? "" : hospName;
		String fAddress = address == null ? "" : address;
		String fTel = tel == null ? "" : tel;
		String fCountryCode = countryCode == null ? "" : countryCode;
		
		ListenableFuture<List<HospitalModel>> hospListModel = asyncExecute(() -> kcckServices.getHospitalList(fHospName, fAddress, fTel, fCountryCode));
		callBackAndResponse(hospListModel, response);
	}

	@POST
	@Path("/get_verify_kcck")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	//@TokenIgnore
	public void verifyKcckAccount(@Valid @NotNull KcckAccountModel model, @Suspended final AsyncResponse response){
		ListenableFuture<PatientModel> patientFuture = asyncExecute(() -> kcckServices.verifyKcckAccount(model));
		Futures.addCallback(patientFuture, new FutureCallback<PatientModel>() {
			@Override
			public void onSuccess(PatientModel result) {
				MessageResponse<?> rs;
				if(result == null){
					rs = new MessageResponse.MessageResponseBuilder<PatientModel>(Message.MESSAGE_FAIL.getValue(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PatientModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			@Override
			public void onFailure(Throwable thrown) {
				LOGGER.info(thrown);
				fail(response, thrown);
			}
			
		});
	}
}
