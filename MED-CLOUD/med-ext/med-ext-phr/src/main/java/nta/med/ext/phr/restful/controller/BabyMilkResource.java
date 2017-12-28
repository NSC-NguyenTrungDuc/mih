package nta.med.ext.phr.restful.controller;

import com.google.common.util.concurrent.ListenableFuture;
import nta.med.ext.phr.model.BabyMilkModel;
import nta.med.ext.phr.service.BabyMilkService;
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
import java.util.Collection;

/**
 * @author DEV-TiepNM
 */
@Path("/profiles")
@Component
public class BabyMilkResource extends BaseResource {

	@Resource
	private BabyMilkService babyMilkService;
	
	public BabyMilkResource(){
		//this.babyMilkService = SpringBeanFactory.beanFactory.getBean(BabyMilkService.class);
	}
	
	@GET
	@Path("/{profileId}/baby_milk")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListBabyMilk(@PathParam("profileId") Long profileId, @NotNull @QueryParam("limit_page_number") Integer pageNumber,@NotNull @QueryParam("limit_page_size") Integer pageSize, @HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<Collection<BabyMilkModel>> future = asyncExecute(() -> babyMilkService.getListBabyMilkByProfileId(profileId, pageRequest));
		callBackAndResponse(future, response);
	}
	
	@GET
	@Path("/{profileId}/baby_milk/{BabyMilkId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getBabyMilkDetail(@PathParam("profileId") Long profileId, @PathParam("BabyMilkId") Long babyMilkId, @HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<BabyMilkModel> future = asyncExecute(() -> babyMilkService.getBabyMilkDetail(profileId, babyMilkId));
		callBackAndResponse(future, response);
	}
	
	@POST
	@Path("/{profileId}/baby_milk")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addBabyMilk(@Valid @NotNull BabyMilkModel BabyMilkModel, @PathParam("profileId") Long profileId, @HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<BabyMilkModel> addFuture = asyncExecute(() -> babyMilkService.addBabyMilk(profileId, BabyMilkModel));
		callBackAndResponse(addFuture, response);
	}
	
	@PUT
	@Path("/{profileId}/baby_milk/{BabyMilkId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void editBabyMilk(@Valid @NotNull BabyMilkModel BabyMilkModel, 
			@PathParam("profileId") Long profileId,  @PathParam("BabyMilkId") Long babyMilkId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<BabyMilkModel> future = asyncExecute(() -> babyMilkService.updateBabyMilk(profileId, babyMilkId, BabyMilkModel));
		callBackAndResponse(future, response);
	}
	
	@DELETE
	@Path("/{profileId}/baby_milk/{BabyMilkId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteBabyMilk(
			@PathParam("profileId") Long profileId,  @PathParam("BabyMilkId") Long babyMilkId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<Boolean> future = asyncExecute(() -> babyMilkService.deleteBabyMilk(profileId, babyMilkId));
		callBackAndResponse(future, response);
	}
}
