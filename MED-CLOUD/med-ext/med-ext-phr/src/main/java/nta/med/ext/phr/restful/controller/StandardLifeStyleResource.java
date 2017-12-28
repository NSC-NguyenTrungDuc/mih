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

import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.StandardLifeStyleModel;
import nta.med.ext.phr.service.ProfileService;
import nta.med.ext.phr.service.StandardLifeStyleService;

@Path("/profiles")
@Component
public class StandardLifeStyleResource extends BaseResource{

	@Resource
	private StandardLifeStyleService standardLifeStyleService;
	
	@Resource
	private ProfileService profileService;
	
	public StandardLifeStyleResource(){
		//this.standardLifeStyleService = SpringBeanFactory.beanFactory.getBean(StandardLifeStyleService.class);
	}
	
	@GET
	@Path("/{profileId}/standard_life_style")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListStandardLifeStyle(@PathParam("profileId") Long profileId, 
										 @NotNull @QueryParam("limit_page_number") Integer pageNumber,
										 @NotNull @QueryParam("limit_page_size") Integer pageSize, 
										 @Suspended final AsyncResponse response){
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<List<StandardLifeStyleModel>> lifeStylesFuture = asyncExecute(() -> standardLifeStyleService.getLimitStandardLifeStyle(profileId, pageRequest));
		callBackAndResponse(lifeStylesFuture, response);
	}	
	
	@GET
	@Path("/{profileId}/standard_life_style/{standardLifeStyleId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getDetailStandardLifeStyle(@PathParam("profileId") Long profileId, 
			  							   @PathParam("standardLifeStyleId") Long standardLifeStyleId,
			  							   @Suspended final AsyncResponse response){
		
		ListenableFuture<StandardLifeStyleModel> lifeStyleFuture = asyncExecute(() -> standardLifeStyleService.getDetailStandardLifeStyle(profileId, standardLifeStyleId));
		callBackAndResponse(lifeStyleFuture, response);
	}
	
	@POST
	@Path("/{profileId}/standard_life_style")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardLifeStyle(@Valid @NotNull StandardLifeStyleModel standardLifeStyleModel, 
									 @PathParam("profileId") Long profileId,
									 @Suspended final AsyncResponse response){
		
		standardLifeStyleModel.setProfileId(profileId);
		ListenableFuture<StandardLifeStyleModel> addFuture = asyncExecute(() -> standardLifeStyleService.addStandardLifeStyle(standardLifeStyleModel));
		callBackAndResponse(addFuture, response);
	}
	
	@PUT
	@Path("/{profileId}/standard_life_style/{standardLifeStyleId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updateStandardLifeStyle(@Valid @NotNull StandardLifeStyleModel standardLifeStyleModel, 
			   							@PathParam("profileId") Long profileId,
			   							@PathParam("standardLifeStyleId") Long standardLifeStyleId,
			   							@Suspended final AsyncResponse response){
		
		standardLifeStyleModel.setProfileId(profileId);
		standardLifeStyleModel.setId(standardLifeStyleId);
		
		ListenableFuture<StandardLifeStyleModel> updateFuture = asyncExecute(() -> standardLifeStyleService.updateStandardLifeStyle(standardLifeStyleModel));
		callBackAndResponse(updateFuture, response);
	}
	
	@DELETE
	@Path("/{profileId}/standard_life_style/{standardLifeStyleId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteStandardLifeStyle(@PathParam("profileId") Long profileId, 
			   							@PathParam("standardLifeStyleId") Long standardLifeStyleId,
			   							@Suspended final AsyncResponse response){
		
		ListenableFuture<Boolean> deleteFuture = asyncExecute(() -> standardLifeStyleService.deleteStandardLifeStyle(standardLifeStyleId));
		callBackAndResponse(deleteFuture, response);
	}
	
	@GET
	@Path("/{profileId}/standard_life_style/duration_type/{durationType}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getStandardLifeStyleByDurationType(@PathParam("profileId") Long profileId, 
											@NotNull @PathParam("durationType") Long durationType,
											@HeaderParam("token") String token, 
			  							   @Suspended final AsyncResponse response){
		ListenableFuture<List<StandardLifeStyleModel>> lifeStyleFuture = asyncExecute(() -> standardLifeStyleService.getStandardLifeStyleByDurationType(profileId, durationType));
		callBackAndResponse(lifeStyleFuture, response);
	}
	
	@POST
	@Path("/{profileId}/standard_life_style_list")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardLifeStyleList(@Valid @NotNull List<StandardLifeStyleModel> standardLifeStyleModels, 
									 @PathParam("profileId") Long profileId,
									 @NotNull @QueryParam("udid") String udid, 
									 @Suspended final AsyncResponse response){
		String message = validatePushData(standardLifeStyleModels, profileId, udid);
		if(StringUtils.isEmpty(message)){
			ListenableFuture<Collection<StandardLifeStyleModel>> future = asyncExecute(() -> standardLifeStyleService.addStandardLifeStyleList(standardLifeStyleModels, profileId));
			Futures.addCallback(future, new FutureCallback<Collection<StandardLifeStyleModel>>() {
				@Override
				public void onSuccess(Collection<StandardLifeStyleModel> result) {
					MessageResponse<?> rs;
					if(!CollectionUtils.isEmpty(result)){
						rs = new MessageResponse.MessageResponseBuilder<Collection<StandardLifeStyleModel>>(Message.MESSAGE_SUCCESS.getValue(),
								Message.SUCCESS.getValue()).setContent(result).build();
						response.resume(rs);
					}
				}
				
				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		} else {
			MessageResponse<?> rs = new MessageResponse.MessageResponseBuilder<Collection<StandardLifeStyleModel>>(message,
					Message.FAIL.getValue()).build();
			response.resume(rs);
		}
	}
	
	private String validatePushData(List<StandardLifeStyleModel> standardLifeStyleModels, Long profileId, String udid){
		if(!profileService.isValidUidStandard(profileId, udid)){
			return Message.UDID_INVALID.getValue();
		}
		if(CollectionUtils.isEmpty(standardLifeStyleModels)){
			return Message.LIFE_STYLE_LIST_EMPTY.getValue();
		}
		for (StandardLifeStyleModel standardLifeStyleModel : standardLifeStyleModels) {
			if (standardLifeStyleModel.getTimeStartSleep() == null) {
				return Message.LIFE_STYLE_TIME_START_SLEEP_REQUIRED.getValue();
			}
			if (standardLifeStyleModel.getTimeWakeUp() == null) {
				return Message.LIFE_STYLE_TIME_WAKE_UP_REQUIRED.getValue();
			}
			if (standardLifeStyleModel.getTotalHourSleep() == null) {
				return Message.LIFE_STYLE_TOTAL_HOUR_SLEEP_REQUIRED.getValue();
			}
		}
		return "";
	}
}
