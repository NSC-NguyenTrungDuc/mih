package nta.med.ext.phr.restful.controller;

import com.google.common.util.concurrent.FutureCallback;
import com.google.common.util.concurrent.Futures;
import com.google.common.util.concurrent.ListenableFuture;

import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.BabyFoodModel;
import nta.med.ext.phr.model.DurationTypeBabyFoodModel;
import nta.med.ext.phr.model.DurationTypeBabySleepModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.service.BabyFoodService;
import org.glassfish.jersey.server.ManagedAsync;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.*;
import javax.ws.rs.container.AsyncResponse;
import javax.ws.rs.container.Suspended;
import javax.ws.rs.core.MediaType;
import java.util.Collection;

/**
 * @author DEV-TiepNM
 */
@Path("/profiles")
@Component
public class BabyFoodResource extends BaseResource {

	@Resource
	private BabyFoodService babyFoodService;
	
	public BabyFoodResource(){
		//this.babyFoodService = SpringBeanFactory.beanFactory.getBean(BabyFoodService.class);
	}
	
	@GET
	@Path("/{profileId}/baby_food")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListBabyFood(@PathParam("profileId") Long profileId, @NotNull @QueryParam("limit_page_number") Integer pageNumber,@NotNull @QueryParam("limit_page_size") Integer pageSize, @HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<Collection<BabyFoodModel>> future = asyncExecute(() -> babyFoodService.getListBabyFoodByProfileId(profileId, pageRequest));
		callBackAndResponse(future, response);
	}
	
	@GET
	@Path("/{profileId}/baby_food/{BabyFoodId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getBabyFoodDetail(@PathParam("profileId") Long profileId, @PathParam("BabyFoodId") Long babyFoodId, @HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<BabyFoodModel> future = asyncExecute(() -> babyFoodService.getBabyFoodDetail(profileId, babyFoodId));
		callBackAndResponse(future, response);
	}
	
	@POST
	@Path("/{profileId}/baby_food")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addBabyFood(@Valid @NotNull BabyFoodModel BabyFoodModel, @PathParam("profileId") Long profileId, @HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<BabyFoodModel> addFuture = asyncExecute(() -> babyFoodService.addBabyFood(profileId, BabyFoodModel));
		callBackAndResponse(addFuture, response);
	}
	
	@PUT
	@Path("/{profileId}/baby_food/{BabyFoodId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void editBabyFood(@Valid @NotNull BabyFoodModel BabyFoodModel, 
			@PathParam("profileId") Long profileId,  @PathParam("BabyFoodId") Long babyFoodId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<BabyFoodModel> future = asyncExecute(() -> babyFoodService.updateBabyFood(profileId, babyFoodId, BabyFoodModel));
		callBackAndResponse(future, response);
	}
	
	@DELETE
	@Path("/{profileId}/baby_food/{BabyFoodId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteBabyFood(
			@PathParam("profileId") Long profileId,  @PathParam("BabyFoodId") Long babyFoodId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<Boolean> future = asyncExecute(() -> babyFoodService.deleteBabyFood(profileId, babyFoodId));
		callBackAndResponse(future, response);
	}
	
	//BF10
	@GET
	@Path("/{profileId}/baby_food/duration_type/{durationType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getBabySleepByDurationType(@Valid @NotNull(message = "profile.id.required") @PathParam("profileId") Long profileId,
										@NotNull @PathParam("durationType") Long durationType,
										@HeaderParam("token") String token, 
										@Suspended final AsyncResponse response) {
		ListenableFuture<DurationTypeBabyFoodModel> future = asyncExecute(() -> babyFoodService.getBabyFoodByDurationType(profileId, durationType));
		Futures.addCallback(future, new FutureCallback<DurationTypeBabyFoodModel>() {
			public void onSuccess(DurationTypeBabyFoodModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeBabyFoodModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeBabyFoodModel>(Message.MESSAGE_SUCCESS.getValue(),
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
