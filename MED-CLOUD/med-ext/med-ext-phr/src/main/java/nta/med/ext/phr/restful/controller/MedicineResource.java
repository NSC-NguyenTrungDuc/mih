package nta.med.ext.phr.restful.controller;

import java.util.List;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.container.AsyncResponse;
import javax.ws.rs.container.Suspended;
import javax.ws.rs.core.MediaType;

import org.glassfish.jersey.server.ManagedAsync;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import com.google.common.util.concurrent.FutureCallback;
import com.google.common.util.concurrent.Futures;
import com.google.common.util.concurrent.ListenableFuture;

import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.MedicineModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.PrescriptionDetailModel;
import nta.med.ext.phr.model.PrescriptionModel;
import nta.med.ext.phr.service.MedicineService;
import nta.med.ext.phr.service.PhrPrescriptionService;

@Path("/profiles")
@Component
public class MedicineResource extends BaseResource{

	@Resource
	private MedicineService medicineService;
	@Resource
	private PhrPrescriptionService phrPrescriptionService;
	
	public MedicineResource(){
		//this.medicineService = SpringBeanFactory.beanFactory.getBean(MedicineService.class);
	}
	
	@GET
	@Path("/{profileId}/medicine_note")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListPrescription(@Valid @NotNull(message = "profileId.required") @PathParam("profileId") Long profileId, 
								@Valid @NotNull(message = "page.number.required") @QueryParam("page_number") Integer pageNumber,
								@Valid @NotNull(message = "page.size.required") @QueryParam("page_size") Integer pageSize,
								@Suspended final AsyncResponse response){
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<List<PrescriptionModel>> medicinesFuture = asyncExecute(() -> phrPrescriptionService.getPrescription(profileId, pageRequest));
		callBackAndResponse(medicinesFuture, response);
	}
	
	@GET
	@Path("/{profileId}/medicine_note/{prescriptionId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getPrescriptionDetail(@Valid @NotNull(message = "profileId.required") @PathParam("profileId") Long profileId,
								@PathParam("prescriptionId") Long prescriptionId,
								@Valid @NotNull(message = "page.number.required") @QueryParam("page_number") Integer pageNumber,
								@Valid @NotNull(message = "page.size.required") @QueryParam("page_size") Integer pageSize,
								@Suspended final AsyncResponse response){
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<PrescriptionDetailModel> medicinesFuture = asyncExecute(() -> phrPrescriptionService.getPrescriptionDetail(prescriptionId, pageRequest));
		callBackAndResponse(medicinesFuture, response);
	}	
	
	@GET
	@Path("/{profileId}/medicine_note/{presciptionId}/medicine/{medicineId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getDetailMedicine(@PathParam("profileId") Long profileId, 
								  @PathParam("presciptionId") Long presciptionId,
								  @PathParam("medicineId") Long medicineId,
								  @Suspended final AsyncResponse response) {
		
		ListenableFuture<MedicineModel> medicineFuture = asyncExecute(() -> medicineService.getDetailMedicine(profileId, medicineId));
		callBackAndResponse(medicineFuture, response);
	}
	
	//MN03
	@POST
	@Path("/{profileId}/medicine_note/{presciptionId}/medicine")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addMedicine(@Valid @NotNull MedicineModel medicineModel, 
							@PathParam("profileId") Long profileId,
							@PathParam("presciptionId") Long presciptionId,
							@Suspended final AsyncResponse response) {
		
		medicineModel.setProfileId(profileId);
		medicineModel.setPrescriptionId(presciptionId);
		ListenableFuture<MedicineModel> future = asyncExecute(() -> medicineService.addMedicine(medicineModel));
		Futures.addCallback(future, new FutureCallback<MedicineModel>() {
			public void onSuccess(MedicineModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//MN04
	@PUT
	@Path("/{profileId}/medicine_note/{presciptionId}/medicine/{medicineId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updateMedicine(@Valid @NotNull MedicineModel medicineModel, 
								@PathParam("profileId") Long profileId,
								@PathParam("presciptionId") Long presciptionId,
							   @PathParam("medicineId") Long medicineId,
							   @Suspended final AsyncResponse response) {
		
		medicineModel.setProfileId(profileId);
		medicineModel.setId(medicineId);
		medicineModel.setPrescriptionId(presciptionId);
		ListenableFuture<MedicineModel> future = asyncExecute(() -> medicineService.updateMedicine(medicineModel));
		Futures.addCallback(future, new FutureCallback<MedicineModel>() {
			public void onSuccess(MedicineModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//MN05
	@DELETE
	@Path("/{profileId}/medicine_note/{presciptionId}/medicine/{medicineId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteMedicine(@PathParam("profileId") Long profileId,
							   @PathParam("presciptionId") Long presciptionId,
							   @PathParam("medicineId") Long medicineId,
							   @Suspended final AsyncResponse response) {
		
		ListenableFuture<MedicineModel> future = asyncExecute(() -> medicineService.deleteMedicine(medicineId, profileId, presciptionId));
		Futures.addCallback(future, new FutureCallback<MedicineModel>() {
			public void onSuccess(MedicineModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//MN12
	@POST
	@Path("/{profileId}/medicine_note")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updatePrescription(@Valid @NotNull MedicineModel medicineModel, 
							@PathParam("profileId") Long profileId,
							@Suspended final AsyncResponse response) {
		
		medicineModel.setProfileId(profileId);
		ListenableFuture<MedicineModel> future = asyncExecute(() -> medicineService.updatePrescription(medicineModel));
		Futures.addCallback(future, new FutureCallback<MedicineModel>() {
			public void onSuccess(MedicineModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//MN13
	@DELETE
	@Path("/{profileId}/medicine_note/{presciptionId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deletePrescription(@PathParam("profileId") Long profileId,
							   @PathParam("presciptionId") Long presciptionId,
							   @Suspended final AsyncResponse response) {
		
		ListenableFuture<MedicineModel> future = asyncExecute(() -> medicineService.deletePrescription(profileId, presciptionId));
		Futures.addCallback(future, new FutureCallback<MedicineModel>() {
			public void onSuccess(MedicineModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<MedicineModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
}
