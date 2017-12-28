package nta.med.ext.phr.restful.controller;

import java.util.Collection;
import java.util.List;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.HeaderParam;
import javax.ws.rs.POST;
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
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import com.google.common.util.concurrent.FutureCallback;
import com.google.common.util.concurrent.Futures;
import com.google.common.util.concurrent.ListenableFuture;

import nta.med.ext.phr.glossary.FitnessType;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.DurationTypeStandardFitnessModel;
import nta.med.ext.phr.model.FitnessInfoBaseOnTypeModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.StandardFitnessModel;
import nta.med.ext.phr.service.ProfileService;
import nta.med.ext.phr.service.StandardTemperatureService;


@Path("/profiles")
@Component
public class StandardFitnessResource extends BaseResource {

	@Resource
	private StandardTemperatureService standardTemperatureService;
	
	@Resource
	private ProfileService profileService;
	
	public StandardFitnessResource(){
		
	}
	
	/**
	 * SFN01
	 */
	@Path("/{profileId}/standard_fitness/fitness_type/{fitnessType}")
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getFitnessInfoBaseOnTypeModel(@Valid @NotNull(message = "profileId.required") @PathParam("profileId") Long profileId, 
											@Valid @NotNull(message = "fitness.type.required") @PathParam("fitnessType") String fitnessType,
											@Valid @NotNull(message = "page.number.required") @QueryParam("page_number") Integer pageNumber,
											@Valid @NotNull(message = "page.size.required") @QueryParam("page_size") Integer pageSize,
											@HeaderParam("token") String token,
										   @Suspended final AsyncResponse response) {
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<FitnessInfoBaseOnTypeModel> future = asyncExecute(() -> standardTemperatureService.getStandardFitnessInfoBaseOnTypeModel(profileId, fitnessType, pageRequest));
		Futures.addCallback(future, new FutureCallback<FitnessInfoBaseOnTypeModel>() {
			public void onSuccess(FitnessInfoBaseOnTypeModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<FitnessInfoBaseOnTypeModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<FitnessInfoBaseOnTypeModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	
	/**
	 * SFN02
	 */
	@Path("/{profileId}/standard_fitness/fitness_type/{fitnessType}/fitness/{fitnessId}")
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getStandardFitnessDetailsByTypeModel(@Valid @NotNull(message = "profile.id.required") @PathParam("profileId") Long profileId, 
											@Valid @NotNull(message = "fitness.type.required") @PathParam("fitnessType") String fitnessType,
											@Valid @NotNull(message = "fitness.id.required")@PathParam("fitnessId") Long fitnessId, 
											@HeaderParam("token") String token,
											@Suspended final AsyncResponse response) {
		
		ListenableFuture<StandardFitnessModel> future = asyncExecute(() -> standardTemperatureService.getStandardFitnessDetailsByTypeModel(profileId, fitnessType, fitnessId));
		Futures.addCallback(future, new FutureCallback<StandardFitnessModel>() {
			public void onSuccess(StandardFitnessModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardFitnessModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardFitnessModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	/**
	 * SFN03
	 */
	@Path("/{profileId}/standard_fitness/fitness_type/{fitnessType}/fitness")
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updateFitnessByType(@Valid @NotNull StandardFitnessModel standardFitnessModel, 
									   @NotNull @PathParam("profileId") Long profileId,
									   @NotNull @PathParam("fitnessType") String fitnessType,
									   @HeaderParam("token") String token,
									   @Suspended final AsyncResponse response) {
		

		ListenableFuture<StandardFitnessModel> future = asyncExecute(() -> standardTemperatureService.updateStandardFitnessByType(standardFitnessModel, fitnessType, profileId));
		Futures.addCallback(future, new FutureCallback<StandardFitnessModel>() {
			public void onSuccess(StandardFitnessModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardFitnessModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardFitnessModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	
	}

	/**
	 * * SFN05
	 */
	@Path("/{profileId}/standard_fitness/fitness_type/{fitnessType}/fitness/{fitnessId}")
	@DELETE
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteFitnessByType( @PathParam("profileId") Long profileId,
			  							  @NotNull @PathParam("fitnessId") Long fitnessId,
										  @NotNull @PathParam("fitnessType") String fitnessType,
										  @HeaderParam("token") String token,
										  @Suspended final AsyncResponse response) {
		
		ListenableFuture<StandardFitnessModel> future = asyncExecute(() -> standardTemperatureService.deleteStandardFitnessByType(fitnessId, fitnessType, profileId));
		Futures.addCallback(future, new FutureCallback<StandardFitnessModel>() {
			public void onSuccess(StandardFitnessModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardFitnessModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardFitnessModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	/**
	 * SFN10
	 */
	@GET
	@Path("/{profileId}/standard_fitness/fitness_type/{fitnessType}/duration_type/{durationType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getStandardFitnessInfoByDurationType(@Valid @NotNull(message = "profile.id.required") @PathParam("profileId") Long profileId, 
										@Valid @NotNull(message = "fitness.type.required") @PathParam("fitnessType") String fitnessType,
										@Valid @NotNull(message = "duration.type.required") @PathParam("durationType") Long durationType,
										@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<DurationTypeStandardFitnessModel> future = asyncExecute(() -> standardTemperatureService.getStandardFitnessInfoByDurationType(profileId, fitnessType, durationType));
		Futures.addCallback(future, new FutureCallback<DurationTypeStandardFitnessModel>() {
			public void onSuccess(DurationTypeStandardFitnessModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeStandardFitnessModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeStandardFitnessModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	@Path("/{profileId}/standard_fitness_list/fitness_type/{fitnessType}/fitness")
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addFitnessListByType(@Valid @NotNull List<StandardFitnessModel> standardFitnessModels, 
									   @NotNull @PathParam("profileId") Long profileId,
									   @NotNull @QueryParam("udid") String udid, 
									   @NotNull @PathParam("fitnessType") String fitnessType,
									   @HeaderParam("token") String token,
									   @Suspended final AsyncResponse response) {
		String message = validatePushData(standardFitnessModels, fitnessType, profileId, udid);
		if(StringUtils.isEmpty(message)){
			ListenableFuture<Collection<StandardFitnessModel>> future = asyncExecute(() -> standardTemperatureService.addFitnessListByType(standardFitnessModels, fitnessType, profileId));
			Futures.addCallback(future, new FutureCallback<Collection<StandardFitnessModel>>() {
				@Override
				public void onSuccess(Collection<StandardFitnessModel> result) {
					MessageResponse<?> rs;
					if(!CollectionUtils.isEmpty(result)){
						rs = new MessageResponse.MessageResponseBuilder<Collection<StandardFitnessModel>>(Message.MESSAGE_SUCCESS.getValue(),
								Message.SUCCESS.getValue()).setContent(result).build();
						response.resume(rs);
					}
				}
				
				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		} else {
			MessageResponse<?> rs = new MessageResponse.MessageResponseBuilder<Collection<StandardFitnessModel>>(message,
					Message.FAIL.getValue()).build();
			response.resume(rs);
		}
	}
	
	private String validatePushData(List<StandardFitnessModel> standardFitnessModels, String fitnessType, Long profileId, String udid){
		if(!profileService.isValidUidStandard(profileId, udid)){
			return Message.UDID_INVALID.getValue();
		}
		if(!FitnessType.FITNESS_STEPS.getValue().equals(fitnessType)
				&& !FitnessType.FITNESS_DISTANCE.getValue().equals(fitnessType)){
			return Message.FITNESS_TYPE_NOT_EXIST.getValue();
		}
		if(CollectionUtils.isEmpty(standardFitnessModels)){
			return Message.FITNESS_LIST_IS_EMPTY.getValue();
		}
		for (StandardFitnessModel standardFitnessModel : standardFitnessModels) {
			if (standardFitnessModel.getDatetimeRecord() == null) {
				return Message.DATETIME_RECORD_REQUIRED.getValue();
			}
			if(FitnessType.FITNESS_STEPS.getValue().equals(fitnessType)){
				if(StringUtils.isEmpty(standardFitnessModel.getStepsCount())){
					return Message.FITNESS_STEPS_REQUIRED.getValue();
				}
			}
			if(FitnessType.FITNESS_DISTANCE.getValue().equals(fitnessType)){
				if(StringUtils.isEmpty(standardFitnessModel.getWalkRunDistance())){
					return Message.FITNESS_DISTANCE_REQUIRED.getValue();
				}
			}
		}
		return "";
	}
}
