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

import nta.med.ext.phr.glossary.GrowthType;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.BabyGrowthHeightWeightModel;
import nta.med.ext.phr.model.DurationTypeBabyGrowthModel;
import nta.med.ext.phr.model.GrowthInfoBaseOnTypeModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.service.BabyGrowthService;
import nta.med.ext.phr.service.ProfileService;

/**
 * @author OaiDV
 */
@Path("/profiles")
@Component
public class BabyGrowthResource extends BaseResource{

	@Resource
	private BabyGrowthService babyGrowthService;
	
	@Resource
	private ProfileService profileService;

	public BabyGrowthResource(){
		
	}
	
	//BG01
	@GET
	@Path("/{profileId}/baby_growth/growth_type/{growthType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListBabyGrowthByType(@Valid @NotNull(message = "profileId.required") @PathParam("profileId") Long profileId, 
											@Valid @NotNull(message = "growth.type.required") @PathParam("growthType") String growthType,
											@Valid @NotNull(message = "page.number.required") @QueryParam("page_number") Integer pageNumber,
											@Valid @NotNull(message = "page.size.required") @QueryParam("page_size") Integer pageSize,
											@HeaderParam("token") String token,
										   @Suspended final AsyncResponse response) {
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<GrowthInfoBaseOnTypeModel> future = asyncExecute(() -> babyGrowthService.getListBabyGrowthByType(profileId, growthType, pageRequest));
		Futures.addCallback(future, new FutureCallback<GrowthInfoBaseOnTypeModel>() {
			public void onSuccess(GrowthInfoBaseOnTypeModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<GrowthInfoBaseOnTypeModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<GrowthInfoBaseOnTypeModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//BG02
	@GET
	@Path("/{profileId}/baby_growth/growth_type/{growthType}/growth/{growthId}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getDetailsBabyGrowthByType(@NotNull @PathParam("profileId") Long profileId,
									   @NotNull @PathParam("growthType") String growthType,
									   @NotNull @PathParam("growthId") Long growthId,
									   @HeaderParam("token") String token,
									   @Suspended final AsyncResponse response) {
		
		ListenableFuture<BabyGrowthHeightWeightModel> future = asyncExecute(() -> babyGrowthService.getDetailsBabyGrowthByType(profileId, growthType, growthId));
		Futures.addCallback(future, new FutureCallback<BabyGrowthHeightWeightModel>() {
			public void onSuccess(BabyGrowthHeightWeightModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<BabyGrowthHeightWeightModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<BabyGrowthHeightWeightModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	
	}
	
	
	//BG03
	@Path("/{profileId}/baby_growth/growth_type/{growthType}")
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addBabyGrowthByType(@Valid @NotNull BabyGrowthHeightWeightModel babyGrowthHeightWeightModel, 
									   @NotNull @PathParam("profileId") Long profileId,
									   @NotNull @PathParam("growthType") String growthType,
									   @HeaderParam("token") String token,
									   @Suspended final AsyncResponse response) {
		

		ListenableFuture<BabyGrowthHeightWeightModel> future = asyncExecute(() -> babyGrowthService.updateBabyGrowthByType(babyGrowthHeightWeightModel, growthType, profileId));
		Futures.addCallback(future, new FutureCallback<BabyGrowthHeightWeightModel>() {
			public void onSuccess(BabyGrowthHeightWeightModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<BabyGrowthHeightWeightModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<BabyGrowthHeightWeightModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	
	}
	
	//BG04
	@PUT
	@Path("/{profileId}/baby_growth/growth_type/{growthType}/growth/{growthId}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updateBabyGrowthByType(@Valid @NotNull BabyGrowthHeightWeightModel babyGrowthHeightWeightModel, 
									   @NotNull @PathParam("profileId") Long profileId,
									   @NotNull @PathParam("growthType") String growthType,
									   @NotNull @PathParam("growthId") Long growthId,
									   @HeaderParam("token") String token,
									   @Suspended final AsyncResponse response) {
		
		babyGrowthHeightWeightModel.setId(growthId);
		ListenableFuture<BabyGrowthHeightWeightModel> future = asyncExecute(() -> babyGrowthService.updateBabyGrowthByType(babyGrowthHeightWeightModel, growthType, profileId));
		Futures.addCallback(future, new FutureCallback<BabyGrowthHeightWeightModel>() {
			public void onSuccess(BabyGrowthHeightWeightModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<BabyGrowthHeightWeightModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<BabyGrowthHeightWeightModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	
	}
	
	//BG05
	@DELETE
	@Path("/{profileId}/baby_growth/growth_type/{growthType}/growth/{growthId}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteBabyGrowthByType(@NotNull @PathParam("profileId") Long profileId,
									   @NotNull @PathParam("growthType") String growthType,
									   @NotNull @PathParam("growthId") Long growthId,
									   @HeaderParam("token") String token,
									   @Suspended final AsyncResponse response) {
		
		ListenableFuture<BabyGrowthHeightWeightModel> future = asyncExecute(() -> babyGrowthService.deleteBabyGrowthByType(profileId, growthType, growthId));
		Futures.addCallback(future, new FutureCallback<BabyGrowthHeightWeightModel>() {
			public void onSuccess(BabyGrowthHeightWeightModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<BabyGrowthHeightWeightModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<BabyGrowthHeightWeightModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	
	}
	
	//BG10
	@GET
	@Path("/{profileId}/baby_growth/growth_type/{growthType}/duration_type/{durationType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getBabyGrowthInfoByDurationType(@Valid @NotNull(message = "profile.id.required") @PathParam("profileId") Long profileId, 
										@Valid @NotNull(message = "growth.type.required") @PathParam("growthType") String growthType,
										@Valid @NotNull(message = "duration.type.required") @PathParam("durationType") Long durationType,
										@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<DurationTypeBabyGrowthModel> future = asyncExecute(() -> babyGrowthService.getBabyGrowthInfoByDurationType(profileId, growthType, durationType));
		Futures.addCallback(future, new FutureCallback<DurationTypeBabyGrowthModel>() {
			public void onSuccess(DurationTypeBabyGrowthModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeBabyGrowthModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeBabyGrowthModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	
	//BG11
	@Path("/{profileId}/baby_growth_list/growth_type/{growthType}")
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addBabyGrowthListByType(@Valid @NotNull List<BabyGrowthHeightWeightModel> babyGrowthHeightWeightModels, 
									   @NotNull @PathParam("profileId") Long profileId,
									   @NotNull @QueryParam("udid") String udid, 
									   @NotNull @PathParam("growthType") String growthType,
									   @HeaderParam("token") String token,
									   @Suspended final AsyncResponse response) {
		
		String message = validatePushData(babyGrowthHeightWeightModels, growthType, profileId, udid);
		if(StringUtils.isEmpty(message)){
			ListenableFuture<Collection<BabyGrowthHeightWeightModel>> future = asyncExecute(() -> babyGrowthService.addBabyGrowthListByType(babyGrowthHeightWeightModels, growthType, profileId));
			Futures.addCallback(future, new FutureCallback<Collection<BabyGrowthHeightWeightModel>>() {
				@Override
				public void onSuccess(Collection<BabyGrowthHeightWeightModel> result) {
					MessageResponse<?> rs;
					if(!CollectionUtils.isEmpty(result)){
						rs = new MessageResponse.MessageResponseBuilder<Collection<BabyGrowthHeightWeightModel>>(Message.MESSAGE_SUCCESS.getValue(),
								Message.SUCCESS.getValue()).setContent(result).build();
						response.resume(rs);
					}
				}
				
				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		} else {
			MessageResponse<?> rs = new MessageResponse.MessageResponseBuilder<Collection<BabyGrowthHeightWeightModel>>(message,
					Message.FAIL.getValue()).build();
			response.resume(rs);
		}
	}
	
	private String validatePushData(List<BabyGrowthHeightWeightModel> babyGrowthHeightWeightModels, String growthType, Long profileId, String udid){
		if(!profileService.isValidUidStandard(profileId, udid)){
			return Message.UDID_INVALID.getValue();
		}
		if(!GrowthType.GROWTH_HEIGHT.getValue().equals(growthType)
				&& !GrowthType.GROWTH_WEIGHT.getValue().equals(growthType)){
			return Message.GROWTH_TYPE_NOT_EXIST.getValue();
		}
		if(CollectionUtils.isEmpty(babyGrowthHeightWeightModels)){
			return Message.GROWTH_LIST_IS_EMPTY.getValue();
		}
		for (BabyGrowthHeightWeightModel babyGrowthHeightWeightModel : babyGrowthHeightWeightModels) {
			if (babyGrowthHeightWeightModel.getTimeMeasure() == null) {
				return Message.DATETIME_RECORD_REQUIRED.getValue();
			}
			if(GrowthType.GROWTH_HEIGHT.getValue().equals(growthType)){
				if(StringUtils.isEmpty(babyGrowthHeightWeightModel.getHeight())){
					return Message.GROWTH_HEIGHT_REQUIRED.getValue();
				}
			}
			if(GrowthType.GROWTH_WEIGHT.getValue().equals(growthType)){
				if(StringUtils.isEmpty(babyGrowthHeightWeightModel.getWeight())){
					return Message.GROWTH_WEIGHT_REQUIRED.getValue();
				}
			}
		}
		return "";
	}
}
