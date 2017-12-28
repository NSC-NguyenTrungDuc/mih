package nta.med.ext.phr.restful.controller;

import java.util.Collection;
import java.util.List;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.HeaderParam;
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
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import com.google.common.util.concurrent.FutureCallback;
import com.google.common.util.concurrent.Futures;
import com.google.common.util.concurrent.ListenableFuture;

import nta.med.ext.phr.glossary.HealthType;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.DurationTypeStandardHealthModel;
import nta.med.ext.phr.model.HealthInfoBaseOnTypeModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.StandardHealthModel;
import nta.med.ext.phr.service.ProfileService;
import nta.med.ext.phr.service.StandardHealthBfpService;
import nta.med.ext.phr.service.StandardHealthBmiService;
import nta.med.ext.phr.service.StandardHealthHeightService;
import nta.med.ext.phr.service.StandardHealthService;
import nta.med.ext.phr.service.StandardHealthWeightService;

/**
 * @author DEV-TiepNM
 */
@Path("/profiles")
@Component
public class StandardHealthResource extends BaseResource {

	@Resource
	private StandardHealthService standardHealthService;
	
	@Resource
	private StandardHealthHeightService standardHealthHeightService;
	
	@Resource
	private StandardHealthWeightService standardHealthWeightService;
	
	@Resource
	private StandardHealthBfpService standardHealthBfpService;
	
	@Resource
	private StandardHealthBmiService standardHealthBmiService;
	
	@Resource
	private ProfileService profileService;
	
	public StandardHealthResource(){
		//this.standardHealthService = SpringBeanFactory.beanFactory.getBean(StandardHealthService.class);
	}
	
	@GET
	@Path("/{profileId}/standard_health")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListStandardHealth(@PathParam("profileId") Long profileId, 
									  @NotNull @QueryParam("limit_page_number") Integer pageNumber,
									  @NotNull @QueryParam("limit_page_size") Integer pageSize, 
									  @HeaderParam("token") String token, 
									  @Suspended final AsyncResponse response) {
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<Collection<StandardHealthModel>> future = asyncExecute(() -> standardHealthService.getListStandardHealthByProfileId(profileId, pageRequest));
		callBackAndResponse(future, response);
	}
	
	@GET
	@Path("/{profileId}/standard_health/health_type/{healthTypeId}/health/{standardHealthId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getStandardHealthDetail(@PathParam("profileId") Long profileId,
										@PathParam("healthTypeId") String healthTypeId, 
										@PathParam("standardHealthId") Long healthId, 
										@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<StandardHealthModel> future = asyncExecute(() -> standardHealthService.getStandardHealthDetail(profileId, healthTypeId, healthId));
		callBackAndResponse(future, response);
	}
	
	@POST
	@Path("/{profileId}/standard_health/health_type/{healthTypeId}/health")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardHealth(@Valid @NotNull StandardHealthModel standardHealthModel, 
			@NotNull @PathParam("profileId") Long profileId, 
			@PathParam("healthTypeId") String healthType, 
			@HeaderParam("token") String token, 
			@Suspended final AsyncResponse response){
		
		ListenableFuture<StandardHealthModel> future = asyncExecute(() -> standardHealthService.updateStandardHealthByType(standardHealthModel, healthType, profileId));
		Futures.addCallback(future, new FutureCallback<StandardHealthModel>() {
			public void onSuccess(StandardHealthModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardHealthModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardHealthModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	@PUT
	@Path("/{profileId}/standard_health/health_type/{healthTypeId}/health/{standardHealthId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void editStandardHealth(@Valid @NotNull StandardHealthModel standardHealthModel, 
			@PathParam("profileId") Long profileId,  
			@PathParam("standardHealthId") Long healthId,
			@PathParam("healthTypeId") String healthType,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		
		standardHealthModel.setId(healthId);
		ListenableFuture<StandardHealthModel> future = asyncExecute(() -> standardHealthService.updateStandardHealthByType(standardHealthModel, healthType, profileId));
		Futures.addCallback(future, new FutureCallback<StandardHealthModel>() {
			public void onSuccess(StandardHealthModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardHealthModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardHealthModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	@DELETE
	@Path("/{profileId}/standard_health/health_type/{healthTypeId}/{standardHealthId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteStandardHealth(
			@PathParam("profileId") Long profileId,  @PathParam("standardHealthId") Long healthId,
			@PathParam("healthTypeId") String healthTypeId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<Boolean> future = asyncExecute(() -> standardHealthService.deleteStandardHealth(profileId, healthTypeId, healthId));
		callBackAndResponse(future, response);
	}
	
	
	//SH01
	@GET
	@Path("/{profileId}/standard_health/health_type/{healthTypeId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getHealthInfoBaseOnType(@Valid @NotNull(message = "profileId.required") @PathParam("profileId") Long profileId, 
			@Valid @NotNull(message = "healthTypeId.required") @PathParam("healthTypeId") String healthTypeId,
			@Valid @NotNull(message = "page.number.required") @QueryParam("page_number") Integer pageNumber,
			@Valid @NotNull(message = "page.size.required") @QueryParam("page_size") Integer pageSize,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<HealthInfoBaseOnTypeModel> future = asyncExecute(() -> standardHealthService.getHealthInfoBaseOnTypeModel(profileId, healthTypeId, pageRequest));
		callBackAndResponse(future, response);
	}
	
	//SH10
	@GET
	@Path("/{profileId}/standard_health/health_type/{healthTypeId}/duration_type/{durationType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getStandardHealthInfo(@PathParam("profileId") Long profileId,
										@PathParam("healthTypeId") String healthTypeId,  
										@NotNull @PathParam("durationType") Long durationType,
										@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<DurationTypeStandardHealthModel> future = asyncExecute(() -> standardHealthService.getStandardHealthInfo(profileId, healthTypeId, durationType));
		callBackAndResponse(future, response);
	}
	
	//SH11
	@POST
	@Path("/{profileId}/standard_health_list/health")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardHealthList(@Valid @NotNull List<StandardHealthModel> standardHealthModels, 
			@NotNull @PathParam("profileId") Long profileId, 
			@NotNull @QueryParam("udid") String udid,
			@HeaderParam("token") String token, 
			@Suspended final AsyncResponse response){
		String message = validatePushData(standardHealthModels, profileId, udid);
		if(StringUtils.isEmpty(message)){
			ListenableFuture<Collection<StandardHealthModel>> future = asyncExecute(() -> standardHealthService.addStandardHealthListByType(standardHealthModels, profileId));
			Futures.addCallback(future, new FutureCallback<Collection<StandardHealthModel>>() {
				@Override
				public void onSuccess(Collection<StandardHealthModel> result) {
					MessageResponse<?> rs;
					if(!CollectionUtils.isEmpty(result)){
						rs = new MessageResponse.MessageResponseBuilder<Collection<StandardHealthModel>>(Message.MESSAGE_SUCCESS.getValue(),
								Message.SUCCESS.getValue()).setContent(result).build();
						response.resume(rs);
					}
				}
				
				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		} else {
			MessageResponse<?> rs = new MessageResponse.MessageResponseBuilder<Collection<StandardHealthModel>>(message,
					Message.FAIL.getValue()).build();
			response.resume(rs);
		}
	}
	
	private String validatePushData(List<StandardHealthModel> standardHealthModels, Long profileId, String udid){
		if(!profileService.isValidUidStandard(profileId, udid)){
			return Message.UDID_INVALID.getValue();
		}
//		if(!HealthType.HEIGHT.getValue().equals(healthType)
//				&& !HealthType.WEIGHT.getValue().equals(healthType)
//				&& !HealthType.BMI.getValue().equals(healthType)
//				&& !HealthType.BFP.getValue().equals(healthType)){
//			return Message.HEALTH_TYPE_NOT_EXIST.getValue();
//		}
		if(CollectionUtils.isEmpty(standardHealthModels)){
			return Message.HEALTH_LIST_IS_EMPTY.getValue();
		}
		for (StandardHealthModel standardHealthModel : standardHealthModels) {
			if (standardHealthModel.getDatetimeRecord() == null) {
				return Message.DATETIME_RECORD_REQUIRED.getValue();
			}
			if(HealthType.HEIGHT.getValue().equals(standardHealthModel.getHealthType())){
				if(standardHealthModel.getHeight() == null){
					return Message.HEALTH_HEIGHT_REQUIRED.getValue();
				}
			}
			if(HealthType.WEIGHT.getValue().equals(standardHealthModel.getHealthType())){
				if(standardHealthModel.getWeight() == null){
					return Message.HEALTH_WEIGHT_REQUIRED.getValue();
				}
			}
			if(HealthType.BMI.getValue().equals(standardHealthModel.getHealthType())){
				if(standardHealthModel.getBmi() == null){
					return Message.HEALTH_BMI_REQUIRED.getValue();
				}
			}
			if(HealthType.BFP.getValue().equals(standardHealthModel.getHealthType())){
				if(standardHealthModel.getPercFat() == null){
					return Message.HEALTH_PERC_FAT_REQUIRED.getValue();
				}
			}
		}
		return "";
	}
}
