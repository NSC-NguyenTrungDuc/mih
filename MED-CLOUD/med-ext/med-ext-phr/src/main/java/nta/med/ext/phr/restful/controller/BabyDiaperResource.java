package nta.med.ext.phr.restful.controller;

import com.google.common.util.concurrent.ListenableFuture;
import nta.med.ext.phr.model.BabyDiaperModel;
import nta.med.ext.phr.service.BabyDiaperService;
import org.glassfish.jersey.server.ManagedAsync;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Component;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.*;
import javax.ws.rs.container.AsyncResponse;
import javax.ws.rs.container.Suspended;
import javax.ws.rs.core.MediaType;
import java.util.List;

@Path("/profiles")
@Component
public class BabyDiaperResource extends BaseResource{

	@Resource
	private BabyDiaperService babyDiaperService;
	
	public BabyDiaperResource(){
		//this.babyDiaperService = SpringBeanFactory.beanFactory.getBean(BabyDiaperService.class);
	}
	
	@GET
	@Path("/{profileId}/baby_diaper")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListBabyDiaper(@PathParam("profileId") Long profileId,
								  @NotNull @QueryParam("limit_page_number") Integer pageNumber,
								  @NotNull @QueryParam("limit_page_size") Integer pageSize,
			  					  @Suspended final AsyncResponse response){
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<List<BabyDiaperModel>> babyDiapersFuture = asyncExecute(() -> babyDiaperService.getLimitBabyDiaper(profileId, pageRequest));
		callBackAndResponse(babyDiapersFuture, response);
	}
	
	@GET
	@Path("/{profileId}/baby_diaper/{babyDiaperId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getDetailBabyDiaper(@PathParam("profileId") Long profileId, 
									@PathParam("babyDiaperId") Long babyDiaperId,
									@Suspended final AsyncResponse response){
		
		ListenableFuture<BabyDiaperModel> babyDiaperFuture = asyncExecute(() -> babyDiaperService.getDetailBabyDiaper(profileId, babyDiaperId));
		callBackAndResponse(babyDiaperFuture, response);
	}
	
	@POST
	@Path("/{profileId}/baby_diaper")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addBabyDiaper(@Valid @NotNull BabyDiaperModel babyDiaperModel, 
			  				  @PathParam("profileId") Long profileId,
			  				  @Suspended final AsyncResponse response){
		
		babyDiaperModel.setProfileId(profileId);
		ListenableFuture<BabyDiaperModel> addDiaperFuture = asyncExecute(() -> babyDiaperService.addBabyDiaper(babyDiaperModel));
		callBackAndResponse(addDiaperFuture, response);
	}
	
	@PUT
	@Path("/{profileId}/baby_diaper/{babyDiaperId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updateBabyDiaper(@Valid @NotNull BabyDiaperModel babyDiaperModel, 
				 				 @PathParam("profileId") Long profileId,
				 				 @PathParam("babyDiaperId") Long babyDiaperId,
				 				 @Suspended final AsyncResponse response){
		
		babyDiaperModel.setProfileId(profileId);
		babyDiaperModel.setId(babyDiaperId);
		
		ListenableFuture<BabyDiaperModel> updateDiaperFuture = asyncExecute(() -> babyDiaperService.updateBabyDiaper(babyDiaperModel));
		callBackAndResponse(updateDiaperFuture, response);
	}
	
	@DELETE
	@Path("/{profileId}/baby_diaper/{babyDiaperId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteBabyDiaper(@PathParam("profileId") Long profileId, 
				 				 @PathParam("babyDiaperId") Long babyDiaperId,
				 				 @Suspended final AsyncResponse response){
		
		ListenableFuture<Boolean> deleteDiaperFuture = asyncExecute(() -> babyDiaperService.deleteBabyDiaper(babyDiaperId));
		callBackAndResponse(deleteDiaperFuture, response);
	}
	
}
