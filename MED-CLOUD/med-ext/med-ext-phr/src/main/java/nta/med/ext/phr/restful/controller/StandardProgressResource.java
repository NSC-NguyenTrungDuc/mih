package nta.med.ext.phr.restful.controller;

import com.google.common.util.concurrent.ListenableFuture;
import nta.med.ext.phr.model.StandardProgressDetailModel;
import nta.med.ext.phr.model.StandardProgressModel;
import nta.med.ext.phr.service.StandardProgressService;
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
public class StandardProgressResource extends BaseResource {

	@Resource
	private StandardProgressService standardProgressService;
	
	public StandardProgressResource(){
		//this.standardProgressService = SpringBeanFactory.beanFactory.getBean(StandardProgressService.class);
	}
	
	@GET
	@Path("/{profileId}/standard_progress_course")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListStandardProgress(@PathParam("profileId") Long profileId, @NotNull @QueryParam("limit_page_number") Integer pageNumber, @NotNull @QueryParam("limit_page_size") Integer pageSize, @HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		
		PageRequest pageRequest = new PageRequest(pageNumber - 1, pageSize);
		ListenableFuture<Collection<StandardProgressModel>> future = asyncExecute(() -> standardProgressService.getListStandardProgressByProfileId(profileId, pageRequest));
		callBackAndResponse(future, response);
	}
	
	@GET
	@Path("/{profileId}/standard_progress_course_detail")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getStandardProgressDetail(@PathParam("profileId") Long profileId, @HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<StandardProgressDetailModel> future = asyncExecute(() -> standardProgressService.getStandardProgressDetail(profileId));
		callBackAndResponse(future, response);
	}
	
	@POST
	@Path("/{profileId}/standard_progress_course")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addStandardProgress(@Valid @NotNull StandardProgressModel StandardProgressModel, @PathParam("profileId") Long profileId, @HeaderParam("token") String token, @Suspended final AsyncResponse response){
		//TODO upload file
		ListenableFuture<StandardProgressModel> addFuture = asyncExecute(() -> standardProgressService.addStandardProgress(profileId, StandardProgressModel));
		callBackAndResponse(addFuture, response);
	}
	
	@PUT
	@Path("/{profileId}/standard_progress_course/{StandardProgressId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void editStandardProgress(@Valid @NotNull StandardProgressModel StandardProgressModel, 
			@PathParam("profileId") Long profileId,  @PathParam("StandardProgressId") Long progressId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		//TODO upload file
		ListenableFuture<StandardProgressModel> future = asyncExecute(() -> standardProgressService.updateStandardProgress(profileId, progressId, StandardProgressModel));
		callBackAndResponse(future, response);
	}
	
	@DELETE
	@Path("/{profileId}/standard_progress_course/{StandardProgressId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteStandardProgress(
			@PathParam("profileId") Long profileId,  @PathParam("StandardProgressId") Long progressId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<Boolean> future = asyncExecute(() -> standardProgressService.deleteStandardProgress(profileId, progressId));
		callBackAndResponse(future, response);
	}
}
