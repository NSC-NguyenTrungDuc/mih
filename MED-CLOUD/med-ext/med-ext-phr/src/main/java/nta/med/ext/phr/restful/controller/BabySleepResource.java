package nta.med.ext.phr.restful.controller;

import com.google.common.util.concurrent.FutureCallback;
import com.google.common.util.concurrent.Futures;
import com.google.common.util.concurrent.ListenableFuture;

import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.BabySleepModel;
import nta.med.ext.phr.model.DurationTypeStandardFoodModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.DurationTypeBabySleepModel;
import nta.med.ext.phr.service.BabySleepService;
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
public class BabySleepResource extends BaseResource {

	@Resource
	private BabySleepService babySleepService;
	
	public BabySleepResource(){
		//this.babySleepService = SpringBeanFactory.beanFactory.getBean(BabySleepService.class);
	}
	
	@GET
	@Path("/{profileId}/baby_sleep")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListBabySleep(@PathParam("profileId") Long profileId, @NotNull @QueryParam("limit_page_number") Integer pageNumber,@NotNull @QueryParam("limit_page_size") Integer pageSize, @HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<Collection<BabySleepModel>> future = asyncExecute(() -> babySleepService.getListBabySleepByProfileId(profileId, pageRequest));
		callBackAndResponse(future, response);
	}
	
	@GET
	@Path("/{profileId}/baby_sleep/{BabySleepId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getBabySleepDetail(@PathParam("profileId") Long profileId, @PathParam("BabySleepId") Long babySleepId, @HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<BabySleepModel> future = asyncExecute(() -> babySleepService.getBabySleepDetail(profileId, babySleepId));
		callBackAndResponse(future, response);
	}
	
	@POST
	@Path("/{profileId}/baby_sleep")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addBabySleep(@Valid @NotNull BabySleepModel BabySleepModel, @PathParam("profileId") Long profileId, @HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<BabySleepModel> addFuture = asyncExecute(() -> babySleepService.addBabySleep(profileId, BabySleepModel));
		callBackAndResponse(addFuture, response);
	}
	
	@PUT
	@Path("/{profileId}/baby_sleep/{BabySleepId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void editBabySleep(@Valid @NotNull BabySleepModel BabySleepModel, 
			@PathParam("profileId") Long profileId,  @PathParam("BabySleepId") Long babySleepId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<BabySleepModel> future = asyncExecute(() -> babySleepService.updateBabySleep(profileId, babySleepId, BabySleepModel));
		callBackAndResponse(future, response);
	}
	
	@DELETE
	@Path("/{profileId}/baby_sleep/{BabySleepId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteBabySleep(
			@PathParam("profileId") Long profileId,  @PathParam("BabySleepId") Long babySleepId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<Boolean> future = asyncExecute(() -> babySleepService.deleteBabySleep(profileId, babySleepId));
		callBackAndResponse(future, response);
	}
	
	//BS10
	@GET
	@Path("/{profileId}/baby_sleep/duration_type/{durationType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getBabySleepByDurationType(@Valid @NotNull(message = "profile.id.required") @PathParam("profileId") Long profileId,
										@NotNull @PathParam("durationType") Long durationType,
										@HeaderParam("token") String token, 
										@Suspended final AsyncResponse response) {
		ListenableFuture<DurationTypeBabySleepModel> future = asyncExecute(() -> babySleepService.getBabySleepByDurationType(profileId, durationType));
		Futures.addCallback(future, new FutureCallback<DurationTypeBabySleepModel>() {
			public void onSuccess(DurationTypeBabySleepModel result) {
				MessageResponse<?> rs;
				if(!StringUtils.isEmpty(result.getMessage())){
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeBabySleepModel>(result.getMessage(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<DurationTypeBabySleepModel>(Message.MESSAGE_SUCCESS.getValue(),
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
