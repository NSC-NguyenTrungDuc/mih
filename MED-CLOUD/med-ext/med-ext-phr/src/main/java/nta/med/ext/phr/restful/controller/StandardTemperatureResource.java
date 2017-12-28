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

import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.glossary.TemperatureType;
import nta.med.ext.phr.model.DurationTypeStandardTempModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.StandardTemperatureModel;
import nta.med.ext.phr.model.TemperatureInfoBaseOnTypeModel;
import nta.med.ext.phr.service.ProfileService;
import nta.med.ext.phr.service.StandardTemperatureService;


/**
 * @author DEV-TiepNM
 */
@Path("/profiles")
@Component
public class StandardTemperatureResource extends BaseResource {

	@Resource
	private StandardTemperatureService standardTemperatureService;
	
	@Resource
	private ProfileService profileService;
	
	public StandardTemperatureResource(){
		
	}
	
	/**
	 * ST01
	 * Get data base on item type
	 * @param profileId
	 * @param pageNumber
	 * @param pageSize
	 * @param response
	 */
	@Path("/{profileId}/standard_temperature/temperature_type/{temperatureType}")
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListStandardTemperature(@Valid @NotNull(message = "profileId.required") @PathParam("profileId") Long profileId, 
											@Valid @NotNull(message = "temperature.type.required") @PathParam("temperatureType") String temperatureType,
											@Valid @NotNull(message = "page.number.required") @QueryParam("page_number") Integer pageNumber,
											@Valid @NotNull(message = "page.size.required") @QueryParam("page_size") Integer pageSize,
											@HeaderParam("token") String token,
										   @Suspended final AsyncResponse response) {
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<TemperatureInfoBaseOnTypeModel> future = asyncExecute(() -> standardTemperatureService.getTemperatureLimitBaseOnTypeModel(profileId, temperatureType, pageRequest));
		Futures.addCallback(future, new FutureCallback<TemperatureInfoBaseOnTypeModel>() {
			public void onSuccess(TemperatureInfoBaseOnTypeModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<TemperatureInfoBaseOnTypeModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<TemperatureInfoBaseOnTypeModel>(Message.MESSAGE_SUCCESS.getValue(),
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
	 * ST02
	 * Get detail a temperature/ physiological record
	 * @param profileId
	 * @param temperatureId
	 * @param response
	 */
	@Path("/{profileId}/standard_temperature/temperature_type/{temperatureType}/temperature/{temperatureId}")
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getDetailStandardTemperature(@Valid @NotNull(message = "profile.id.required") @PathParam("profileId") Long profileId, 
											@Valid @NotNull(message = "temperature.type.required") @PathParam("temperatureType") String temperatureType,
											@Valid @NotNull(message = "temperature.id.required")@PathParam("temperatureId") Long temperatureId, 
											@HeaderParam("token") String token,
											@Suspended final AsyncResponse response) {
		
		ListenableFuture<StandardTemperatureModel> future = asyncExecute(() -> standardTemperatureService.getTemperatureDetailByTypeModel(profileId, temperatureType, temperatureId));
		Futures.addCallback(future, new FutureCallback<StandardTemperatureModel>() {
			public void onSuccess(StandardTemperatureModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardTemperatureModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardTemperatureModel>(Message.MESSAGE_SUCCESS.getValue(),
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
	 * ST03
	 * Add new Temperature/ Physiological record 
	 * @param temperature
	 * @param profileId
	 * @param response
	 */
	@Path("/{profileId}/standard_temperature/temperature_type/{temperatureType}")
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardTemperature(@Valid @NotNull StandardTemperatureModel standardTemperatureModel, 
									   @NotNull @PathParam("profileId") Long profileId,
									   @NotNull @PathParam("temperatureType") String temperatureType,
									   @HeaderParam("token") String token,
									   @Suspended final AsyncResponse response) {
		ListenableFuture<StandardTemperatureModel> future = asyncExecute(() -> standardTemperatureService.updateStandardTempByType(standardTemperatureModel, temperatureType, profileId));
		Futures.addCallback(future, new FutureCallback<StandardTemperatureModel>() {
			public void onSuccess(StandardTemperatureModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardTemperatureModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardTemperatureModel>(Message.MESSAGE_SUCCESS.getValue(),
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
	 * * ST04
	 * Edit a temperature/ physiologycal record
	 * @param standardTemperatureModel
	 * @param profileId
	 * @param temperatureId
	 * @param temperatureType
	 * @param token
	 * @param response
	 */
	@Path("{profileId}/standard_temperature/temperature_type/{temperatureType}/temperature/{temperatureId}")
	@PUT
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updateStandardTemperature(@Valid @NotNull StandardTemperatureModel standardTemperatureModel,
										  @PathParam("profileId") Long profileId,
										  @NotNull @PathParam("temperatureId") Long temperatureId,
										  @NotNull @PathParam("temperatureType") String temperatureType,
										  @HeaderParam("token") String token,
										  @Suspended final AsyncResponse response) {
		standardTemperatureModel.setId(temperatureId);
		ListenableFuture<StandardTemperatureModel> future = asyncExecute(() -> standardTemperatureService.updateStandardTempByType(standardTemperatureModel, temperatureType, profileId));
		Futures.addCallback(future, new FutureCallback<StandardTemperatureModel>() {
			public void onSuccess(StandardTemperatureModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardTemperatureModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardTemperatureModel>(Message.MESSAGE_SUCCESS.getValue(),
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
	 * * ST05
	 * Delete a temperature/ physiologycal record
	 * @param profileId
	 * @param temperatureId
	 * @param temperatureType
	 * @param token
	 * @param response
	 */
	@Path("{profileId}/standard_temperature/temperature_type/{temperatureType}/temperature/{temperatureId}")
	@DELETE
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteStandardTemperature( @PathParam("profileId") Long profileId,
										  @NotNull @PathParam("temperatureId") Long temperatureId,
										  @NotNull @PathParam("temperatureType") String temperatureType,
										  @HeaderParam("token") String token,
										  @Suspended final AsyncResponse response) {
		
		ListenableFuture<StandardTemperatureModel> future = asyncExecute(() -> standardTemperatureService.deleteStandardTempByTemperatureType(profileId, temperatureType, temperatureId));
		Futures.addCallback(future, new FutureCallback<StandardTemperatureModel>() {
			public void onSuccess(StandardTemperatureModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardTemperatureModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardTemperatureModel>(Message.MESSAGE_SUCCESS.getValue(),
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
	 * ST10
	 * Get temperature, heart rate, respiration rate, blood pressure data
	 * @param profileId
	 * @param temperatureTypeId
	 * @param durationType
	 * @param token
	 * @param response
	 */
	@GET
	@Path("/{profileId}/standard_temperature/temperature_type/{temperatureType}/duration_type/{durationType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getStandardTempInfoByDurationType(@Valid @NotNull(message = "profile.id.required") @PathParam("profileId") Long profileId, 
										@Valid @NotNull(message = "temperature.type.required") @PathParam("temperatureType") String temperatureType,
										@Valid @NotNull(message = "duration.type.required") @PathParam("durationType") Long durationType,
										@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<DurationTypeStandardTempModel> future = asyncExecute(() -> standardTemperatureService.getStandardTempInfoByDurationType(profileId, temperatureType, durationType));
		Futures.addCallback(future, new FutureCallback<DurationTypeStandardTempModel>() {
			public void onSuccess(DurationTypeStandardTempModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeStandardTempModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeStandardTempModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//ST11
	@Path("/{profileId}/standard_temp_list/temperature_type/{temperatureType}")
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardTemperatureList(@Valid @NotNull List<StandardTemperatureModel> standardTemperatureModels, 
									   @NotNull @PathParam("profileId") Long profileId,
									   @NotNull @QueryParam("udid") String udid,
									   @NotNull @PathParam("temperatureType") String temperatureType,
									   @HeaderParam("token") String token,
									   @Suspended final AsyncResponse response) {
		String message = validatePushData(standardTemperatureModels, temperatureType, profileId, udid);
		if(StringUtils.isEmpty(message)){
			ListenableFuture<Collection<StandardTemperatureModel>> future = asyncExecute(() -> standardTemperatureService.addStandardTemperatureListByType(standardTemperatureModels, temperatureType, profileId));
			Futures.addCallback(future, new FutureCallback<Collection<StandardTemperatureModel>>() {
				@Override
				public void onSuccess(Collection<StandardTemperatureModel> result) {
					MessageResponse<?> rs;
					if(!CollectionUtils.isEmpty(result)){
						rs = new MessageResponse.MessageResponseBuilder<Collection<StandardTemperatureModel>>(Message.MESSAGE_SUCCESS.getValue(),
								Message.SUCCESS.getValue()).setContent(result).build();
						response.resume(rs);
					}
				}
				
				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		} else {
			MessageResponse<?> rs = new MessageResponse.MessageResponseBuilder<Collection<StandardTemperatureModel>>(message,
					Message.FAIL.getValue()).build();
			response.resume(rs);
		}
	}
	
	private String validatePushData(List<StandardTemperatureModel> standardTemperatureModels, String temperatureType, Long profileId, String udid){
		if(!profileService.isValidUidStandard(profileId, udid)){
			return Message.UDID_INVALID.getValue();
		}
		if(!TemperatureType.TEMP_TEMPERATURE.getValue().equals(temperatureType)
				&& !TemperatureType.TEMP_HEARTRATE.getValue().equals(temperatureType)
				&& !TemperatureType.TEMP_BREATH.getValue().equals(temperatureType)
				&& !TemperatureType.TEMP_BP.getValue().equals(temperatureType)){
			return Message.TEMP_TYPE_NOT_EXIST.getValue();
		}
		if(CollectionUtils.isEmpty(standardTemperatureModels)){
			return Message.TEMP_LIST_IS_EMPTY.getValue();
		}
		for (StandardTemperatureModel standardTemperatureModel : standardTemperatureModels) {
			if (standardTemperatureModel.getDateMeasure() == null) {
				return Message.DATETIME_RECORD_REQUIRED.getValue();
			}
			if(TemperatureType.TEMP_TEMPERATURE.getValue().equals(temperatureType)){
				if(standardTemperatureModel.getTemperature() == null){
					return Message.TEMP_TEMPERATURE_REQUIRED.getValue();
				}
			}
			if(TemperatureType.TEMP_HEARTRATE.getValue().equals(temperatureType)){
				if(standardTemperatureModel.getHeartrate() == null){
					return Message.TEMP_HEARTRATE_REQUIRED.getValue();
				}
			}
			if(TemperatureType.TEMP_BREATH.getValue().equals(temperatureType)){
				if(standardTemperatureModel.getBreath() == null){
					return Message.TEMP_BREATH_REQUIRED.getValue();
				}
			} 
			if(TemperatureType.TEMP_BP.getValue().equals(temperatureType)){
				if(standardTemperatureModel.getBpFrom() == null || standardTemperatureModel.getBpTo() == null){
					return Message.TEMP_BP_REQUIRED.getValue();
				}
			}
		}
		return "";
	}
}
