package nta.med.ext.phr.restful.controller;

import com.google.common.util.concurrent.ListenableFuture;
import nta.med.ext.phr.model.StandardDiseasModel;
import nta.med.ext.phr.service.StandardDiseasService;
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
public class StandardDiseasResource extends BaseResource{

	@Resource
	private StandardDiseasService standardDiseasService;
	
	public StandardDiseasResource(){
		//this.standardDiseasService = SpringBeanFactory.beanFactory.getBean(StandardDiseasService.class);
	}
	
	@GET
	@Path("/{profileId}/standard_disease")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListStandardDiseas(@NotNull @PathParam("profileId") Long profileId,
									  @NotNull @QueryParam("limit_page_number") Integer pageNumber,
									  @NotNull @QueryParam("limit_page_size") Integer pageSize,
			  						  @Suspended final AsyncResponse response){
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<List<StandardDiseasModel>> standardDiseasFuture = asyncExecute(() -> standardDiseasService.getLimitStandardDiseas(profileId, pageRequest));
		callBackAndResponse(standardDiseasFuture, response);
	}
	
	@GET
	@Path("/{profileId}/standard_disease/{standardDiseasId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getDetailStandardDiseas(@PathParam("profileId") Long profileId, 
										@PathParam("standardDiseasId") Long standardDiseasId,
										@Suspended final AsyncResponse response){
		
		ListenableFuture<StandardDiseasModel> standardDiseaFuture = asyncExecute(() -> standardDiseasService.getDetailStandardDiseas(profileId, standardDiseasId));
		callBackAndResponse(standardDiseaFuture, response);
	}
	
	@POST
	@Path("/{profileId}/standard_disease")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardDiseas(@Valid @NotNull StandardDiseasModel standardDiseasModel, 
				 				  @PathParam("profileId") Long profileId,
				 				  @Suspended final AsyncResponse response){
		
		// TODO Process Upload/Download picture
		
		standardDiseasModel.setProfileId(profileId);
		ListenableFuture<StandardDiseasModel> addFuture = asyncExecute(() -> standardDiseasService.addStandardDiseas(standardDiseasModel));
		callBackAndResponse(addFuture, response);
	}
	
	@PUT
	@Path("/{profileId}/standard_disease/{standardDiseasId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updateStandardDiseas(@Valid @NotNull StandardDiseasModel standardDiseasModel, 
								     @PathParam("profileId") Long profileId,
								     @PathParam("standardDiseasId") Long standardDiseasId,
								     @Suspended final AsyncResponse response){
		
		// TODO Process Upload/Download picture
		
		standardDiseasModel.setProfileId(profileId);
		standardDiseasModel.setId(standardDiseasId);
		
		ListenableFuture<StandardDiseasModel> updateFuture = asyncExecute(() -> standardDiseasService.updateStandardDiseas(standardDiseasModel));
		callBackAndResponse(updateFuture, response);
	}
	
	@DELETE
	@Path("/{profileId}/standard_disease/{standardDiseasId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteStandardDiseas(@PathParam("profileId") Long profileId,
		     						 @PathParam("standardDiseasId") Long standardDiseasId,
		     						 @Suspended final AsyncResponse response){
		
		ListenableFuture<Boolean> deleteFuture = asyncExecute(() -> standardDiseasService.deleteStandardDiseas(standardDiseasId));
		callBackAndResponse(deleteFuture, response);
	}
}
