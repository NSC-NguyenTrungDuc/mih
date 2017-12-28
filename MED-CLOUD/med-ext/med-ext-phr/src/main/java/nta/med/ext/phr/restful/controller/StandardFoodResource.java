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

import nta.med.ext.phr.glossary.FoodType;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.DurationTypeStandardFoodModel;
import nta.med.ext.phr.model.FoodInfoBaseOnTypeModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.StandardFoodModel;
import nta.med.ext.phr.service.ProfileService;
import nta.med.ext.phr.service.StandardFoodMenuService;

/**
 * @author DEV-TiepNM
 */
@Path("/profiles")
@Component
public class StandardFoodResource extends BaseResource{

	@Resource
	private StandardFoodMenuService standardFoodMenuService;
	
	@Resource
	private ProfileService profileService;
	
	public StandardFoodResource(){
		
	}
	
	//SF01
	@GET
	@Path("/{profileId}/standard_food/food_type/{foodType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListStandardFoodByType( @HeaderParam("token") String token, 
			@PathParam("profileId") Long profileId, 
			@NotNull @PathParam("foodType") String foodType,
			@NotNull @QueryParam("page_number") Integer pageNumber, 
			@NotNull @QueryParam("page_size") Integer pageSize,
			@Suspended final AsyncResponse response){
	
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<FoodInfoBaseOnTypeModel> future = asyncExecute(() -> standardFoodMenuService.getStandardFoodByType(profileId, foodType, pageRequest));
		Futures.addCallback(future, new FutureCallback<FoodInfoBaseOnTypeModel>() {
			public void onSuccess(FoodInfoBaseOnTypeModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<FoodInfoBaseOnTypeModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<FoodInfoBaseOnTypeModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//SF02
	@GET
	@Path("/{profileId}/standard_food/food_type/{foodType}/food/{foodId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getDetailStandardFoodByType( @HeaderParam("token") String token, 
			@PathParam("profileId") Long profileId,
			@NotNull @PathParam("foodType") String foodType,
			@PathParam("foodId") Long foodId,
			@Suspended final AsyncResponse response){
		ListenableFuture<StandardFoodModel> future = asyncExecute(() -> standardFoodMenuService.getDetailStandardFoodMenuByType(profileId, foodType, foodId));
		Futures.addCallback(future, new FutureCallback<StandardFoodModel>() {
			public void onSuccess(StandardFoodModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardFoodModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardFoodModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//SF03
	@POST
	@Path("/{profileId}/standard_food/food_type/{foodType}/food/")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardFood( @HeaderParam("token") String token, 
			@PathParam("profileId") Long profileId, 
			@PathParam("foodType") String foodType, 
			@Valid @NotNull StandardFoodModel standardFoodModel,
			@Suspended final AsyncResponse response){
		ListenableFuture<StandardFoodModel> future = asyncExecute(() -> standardFoodMenuService.updateStandardFoodByFoodType(standardFoodModel, foodType, profileId));
		Futures.addCallback(future, new FutureCallback<StandardFoodModel>() {
			public void onSuccess(StandardFoodModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardFoodModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardFoodModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//SF04
	@PUT
	@Path("/{profileId}/standard_food/food_type/{foodType}/food/{foodId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updateStandardFood( @HeaderParam("token") String token, 
			@PathParam("profileId") Long profileId, 
			@PathParam("foodType") String foodType,
			@Valid @NotNull StandardFoodModel standardFoodModel,
			@PathParam("foodId") Long foodId, @Suspended final AsyncResponse response){
		
		standardFoodModel.setId(foodId);
		ListenableFuture<StandardFoodModel> future = asyncExecute(() -> standardFoodMenuService.updateStandardFoodByFoodType(standardFoodModel, foodType, profileId));
		Futures.addCallback(future, new FutureCallback<StandardFoodModel>() {
			public void onSuccess(StandardFoodModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardFoodModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardFoodModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//SF05
	@DELETE
	@Path("/{profileId}/standard_food/food_type/{foodType}/food/{foodId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteStandardFoodMenu( @HeaderParam("token") String token, 
			@PathParam("profileId") Long profileId, 
			@PathParam("foodType") String foodType,
			@PathParam("foodId") Long foodId,
			@Suspended final AsyncResponse response){
		ListenableFuture<StandardFoodModel> future = asyncExecute(() -> standardFoodMenuService.deleteStandardFoodByFoodType(profileId, foodType, foodId));
		Futures.addCallback(future, new FutureCallback<StandardFoodModel>() {
			public void onSuccess(StandardFoodModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<StandardFoodModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<StandardFoodModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//SF10
	@GET
	@Path("/{profileId}/standard_food/food_type/{foodType}/duration_type/{durationType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getStandardFoodInfoByDurationType(@Valid @NotNull(message = "profile.id.required") @PathParam("profileId") Long profileId,
										@PathParam("foodType") String foodType,  
										@NotNull @PathParam("durationType") Long durationType,
										@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<DurationTypeStandardFoodModel> future = asyncExecute(() -> standardFoodMenuService.getStandardFoodInfoByDurationType(profileId, foodType, durationType));
		Futures.addCallback(future, new FutureCallback<DurationTypeStandardFoodModel>() {
			public void onSuccess(DurationTypeStandardFoodModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeStandardFoodModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeStandardFoodModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//SF11 
	@POST
	@Path("/{profileId}/standard_food_list/food_type/{foodType}/food")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardFoodList( @HeaderParam("token") String token,
								 @PathParam("profileId") Long profileId,
								 @NotNull @QueryParam("udid") String udid,
								 @PathParam("foodType") String foodType,
								 @Valid @NotNull List<StandardFoodModel> standardFoodModels,
								 @Suspended final AsyncResponse response){
		String message = validatePushData(standardFoodModels, foodType, profileId, udid);
		if(StringUtils.isEmpty(message)){
			ListenableFuture<List<StandardFoodModel>> future = asyncExecute(() -> standardFoodMenuService.addStandardFoodListByFoodType(standardFoodModels, foodType, profileId));
			Futures.addCallback(future, new FutureCallback<Collection<StandardFoodModel>>() {
				@Override
				public void onSuccess(Collection<StandardFoodModel> result) {
					MessageResponse<?> rs;
					if(!CollectionUtils.isEmpty(result)){
						rs = new MessageResponse.MessageResponseBuilder<Collection<StandardFoodModel>>(Message.MESSAGE_SUCCESS.getValue(),
								Message.SUCCESS.getValue()).setContent(result).build();
						response.resume(rs);
					}
				}
				
				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		} else {
			MessageResponse<?> rs = new MessageResponse.MessageResponseBuilder<Collection<StandardFoodModel>>(message,
					Message.FAIL.getValue()).build();
			response.resume(rs);
		}
	}
	
	private String validatePushData(List<StandardFoodModel> standardFoodModels, String foodType, Long profileId, String udid){
		if(!profileService.isValidUidStandard(profileId, udid)){
			return Message.UDID_INVALID.getValue();
		}
		if(!FoodType.FOOD_CALORIES.getValue().equals(foodType)
				&& !FoodType.FOOD_CARBOHYDRATE.getValue().equals(foodType)
				&& !FoodType.FOOD_TOTAL_FAT.getValue().equals(foodType)){
			return Message.FOOD_TYPE_NOT_EXIST.getValue();
		}
		if(CollectionUtils.isEmpty(standardFoodModels)){
			return Message.FOOD_LIST_IS_EMPTY.getValue();
		}
		for (StandardFoodModel standardFoodModel : standardFoodModels) {
			if (standardFoodModel.getEatingTime() == null) {
				return Message.DATETIME_RECORD_REQUIRED.getValue();
			}
			if(FoodType.FOOD_CALORIES.getValue().equals(foodType)){
				if(standardFoodModel.getKcal() == null){
					return Message.FOOD_KCAL_REQUIRED.getValue();
				}
			}
			if(FoodType.FOOD_CARBOHYDRATE.getValue().equals(foodType)){
				if(standardFoodModel.getCarbohydrate() == null){
					return Message.FOOD_CARBOHYDRATE_REQUIRED.getValue();
				}
			}
			if(FoodType.FOOD_TOTAL_FAT.getValue().equals(foodType)){
				if(standardFoodModel.getTotalFat() == null){
					return Message.FOOD_TOTAL_FAT_REQUIRED.getValue();
				}
			}
		}
		return "";
	}
}
