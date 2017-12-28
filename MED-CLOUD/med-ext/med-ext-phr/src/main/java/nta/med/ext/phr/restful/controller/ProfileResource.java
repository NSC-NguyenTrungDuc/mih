package nta.med.ext.phr.restful.controller;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Calendar;
import java.util.Collection;

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
import javax.ws.rs.core.Response;

import org.glassfish.jersey.media.multipart.FormDataContentDisposition;
import org.glassfish.jersey.media.multipart.FormDataParam;
import org.glassfish.jersey.server.ManagedAsync;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import com.google.common.util.concurrent.FutureCallback;
import com.google.common.util.concurrent.Futures;
import com.google.common.util.concurrent.ListenableFuture;

import nta.med.ext.phr.configuration.PhrConfiguration;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.AccountInfo;
import nta.med.ext.phr.model.AccountPicture;
import nta.med.ext.phr.model.BabyTimeLine;
import nta.med.ext.phr.model.KcckAccountModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.PatientClinicModel;
import nta.med.ext.phr.model.PatientModel;
import nta.med.ext.phr.model.PhrContext;
import nta.med.ext.phr.model.ProfileBaby;
import nta.med.ext.phr.model.ProfileModel;
import nta.med.ext.phr.model.ProfileScreen;
import nta.med.ext.phr.model.ProfileStandard;
import nta.med.ext.phr.model.StandardHomePage;
import nta.med.ext.phr.model.UserChildInfo;
import nta.med.ext.phr.service.AccountClinicService;
import nta.med.ext.phr.service.ProfileService;

@Path("/profiles")
@Component
public class ProfileResource extends BaseResource{

	@Resource
	private ProfileService profileService;

	@Resource
	private AccountClinicService accountClinicService;

	@Resource
	private PhrConfiguration configuration;
	public ProfileResource(){
//		this.profileService = SpringBeanFactory.beanFactory.getBean(ProfileService.class);
//		this.accountClinicService = SpringBeanFactory.beanFactory.getBean(AccountClinicService.class);
	}
	@Path("/{profileId}/upload")
	@POST
	@Consumes(MediaType.MULTIPART_FORM_DATA)
	@Produces(MediaType.APPLICATION_JSON)
	public Response uploadFile(@PathParam("profileId") Long profileId,
			@FormDataParam("file") InputStream uploadedInputStream,
			@FormDataParam("file") FormDataContentDisposition fileDetail) {

		String folderUpload = configuration.getFolderUpload();
		MessageResponse messageResponse = new MessageResponse.MessageResponseBuilder<String>(Message.MESSAGE_SUCCESS.getValue(),
				Message.SUCCESS.getValue()).build();

		Long userId = PhrContext.current().getUserId();

		String uploadedFileLocation = folderUpload + File.separator+ userId +File.separator +profileId + File.separator ;
		File file = new File(uploadedFileLocation);
		if(!file.exists()) file.mkdirs();

		String fileName = getFileName(fileDetail.getFileName());
		// save it
		writeToFile(uploadedInputStream, uploadedFileLocation + fileName);
		messageResponse.setContent(configuration.getUrlDownload()+ userId +"/"+profileId + "/" + fileName);
		return Response.status(200).entity(messageResponse).build();

	}
	private String getFileName(String fileName) {
		String fileNameStore = "-" + String.valueOf(Calendar.getInstance().getTimeInMillis());
		String[] fileNames = fileName.split("\\.");
		if (fileNames.length > 1) {

			fileName = fileNames[0] + fileNameStore + "." + fileNames[1];
		} else {
			fileName += fileNameStore;
		}
		return fileName;
	}
	private void writeToFile(InputStream uploadedInputStream,
							 String uploadedFileLocation) {

		try {
			OutputStream out;
			int read = 0;
			byte[] bytes = new byte[1024];

			out = new FileOutputStream(new File(uploadedFileLocation));
			while ((read = uploadedInputStream.read(bytes)) != -1) {
				out.write(bytes, 0, read);
			}
			out.flush();
			out.close();
		} catch (IOException e) {

			e.printStackTrace();
		}

	}
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	//@ManagedAsync
	public void getListProfiles(@HeaderParam("token") String token, @QueryParam("baby_flg") BigDecimal babyFlg,
			@Suspended final AsyncResponse response) {
		Long userId = PhrContext.current().getUserId();
		ListenableFuture<Collection<ProfileScreen>> accountFuture = asyncExecute(() -> profileService.getProfileByToken(babyFlg, userId));
		callBackAndResponse(accountFuture, response);

	}


	@Path("/{profileId}")
	@PUT
	@Produces(MediaType.APPLICATION_JSON)
	//@ManagedAsync
	public void changePictureProfile(@PathParam("profileId") Long profileId, @HeaderParam("token") String token, @Valid @NotNull ProfileModel profileModel, @Suspended final AsyncResponse response)  {

		Long userId = PhrContext.current().getUserId();

		ListenableFuture<AccountPicture> verifyFuture = asyncExecute(() -> profileService.updatePictureProfileUrl(profileId, profileModel.getPictureProfileUrl(), userId));
		callBackAndResponse(verifyFuture, response);
	}
	@GET
	@Path("/baby_profile/{profileId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getDetailBabyProfile(@Valid @NotNull @PathParam("profileId") Long profileId, @HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<ProfileBaby> verifyFuture = asyncExecute(() -> profileService.getBabyProfileByProfileId(profileId));
		callBackAndResponse(verifyFuture, response);
	}

	@POST
	@Path("/baby_profile")
	@Produces(MediaType.APPLICATION_JSON)
	//@ManagedAsync
	public void addBabyProfile(@Valid @NotNull ProfileBaby profileModel, @HeaderParam("token") String token,  @NotNull @QueryParam("udid") String udid,
							   @Suspended final AsyncResponse response) {

		String message = validBabyProfile(profileModel, false);
		if(!StringUtils.isEmpty(message)){
			response.resume(new MessageResponse.MessageResponseBuilder<String>(message,
					Message.FAIL.getValue()).setContent(null).build());
		} else {
			Long userId = PhrContext.current().getUserId();
			ListenableFuture<ProfileBaby> verifyFuture = asyncExecute(() -> profileService.addBabyProfile(profileModel, userId, udid));
			callBackAndResponse(verifyFuture, response);
		}
	}

	@PUT
	@Path("/baby_profile/{profileId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void editBabyProfile(@Valid @NotNull @PathParam("profileId") Long profileId,
			@Valid @NotNull ProfileBaby profileBaby,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		String message = validBabyProfile(profileBaby, true);
		if(!StringUtils.isEmpty(message)){
			response.resume(new MessageResponse.MessageResponseBuilder<String>(message,
					Message.FAIL.getValue()).setContent(null).build());
		} else {
			ListenableFuture<ProfileBaby> verifyFuture = asyncExecute(() -> profileService.editBabyProfile(profileId, profileBaby));
			callBackAndResponse(verifyFuture, response);
		}
	}

	@DELETE
	@Path("/baby_profile/{profileId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteBabyProfile(@Valid @NotNull @PathParam("profileId") Long profileId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response) {

		ListenableFuture<Boolean> verifyFuture = asyncExecute(() -> profileService.updateActiveProfile(profileId));
		callBackAndResponse(verifyFuture, response);
	}

	@Path("/standard_profile/{profileId}")
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public void getDetailStandardProfile(@PathParam("profileId") Long profileId,
										 @HeaderParam("token") String token,
										 @Suspended final AsyncResponse response){

		ListenableFuture<ProfileStandard> future = asyncExecute(() -> profileService.getStandardProfileById(profileId));
		callBackAndResponse(future, response);
	}
	
	@Path("/standard_profile_mbs/{profileId}")
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public void getDetailStandardProfileMbs(@PathParam("profileId") Long profileId,
										 @HeaderParam("token") String token,
										 @Suspended final AsyncResponse response){

		ListenableFuture<ProfileStandard> future = asyncExecute(() -> profileService.getStandardProfileByIdMbs(profileId));
		callBackAndResponse(future, response);
	}

	@Path("/standard_profile")
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	public void addStandardProfile(@Valid @NotNull ProfileStandard profileStandard,
								   @HeaderParam("token") String token,
								   @Suspended final AsyncResponse response){


		Long userId = PhrContext.current().getUserId();

		String message = valid(profileStandard);
		if(!StringUtils.isEmpty(message)){
			response.resume(new MessageResponse.MessageResponseBuilder<String>(message,
					Message.FAIL.getValue()).setContent(null).build());
		} else {
			ListenableFuture<ProfileStandard> addFuture = asyncExecute(() -> profileService.addStandardProfile(profileStandard, userId));
			callBackAndResponse(addFuture, response);
		}
	}

	private String valid(ProfileStandard profileStandard) {
		if (StringUtils.isEmpty(profileStandard.getGender())) {
			return Message.GENDER_REQUIRED.getValue();
		}
		if (StringUtils.isEmpty(profileStandard.getBirthday())) {
			return Message.BIRTHDAY_REQUIRED.getValue();
		}
		return null;
	}

	@PUT
	@Path("/standard_profile/{profileId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void updateStandardProfile(@Valid @NotNull ProfileStandard profileStandard,
									  @PathParam("profileId") Long profileId,
									  @HeaderParam("token") String token,
									  @Suspended final AsyncResponse response){



		profileStandard.setId(profileId);
		ListenableFuture<ProfileStandard> updateFuture = asyncExecute(() -> profileService.updateStandardProfile(profileStandard));
		callBackAndResponse(updateFuture, response);
	}

	@DELETE
	@Path("/standard_profile/{profileId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void deleteStandardProfile(@PathParam("profileId") Long profileId,
									  @HeaderParam("token") String token,
									  @Suspended final AsyncResponse response){

		ListenableFuture<Boolean> deleteFuture = asyncExecute(() -> profileService.deleteStandardProfile(profileId));
		callBackAndResponse(deleteFuture, response);
	}

	@GET
	@Path("/baby_profile/{profileId}/homepage")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getListBabyProfilesTimeline(@PathParam("profileId") Long profileId, @QueryParam("limit") Integer limit, @HeaderParam("token") String token, @Suspended final AsyncResponse response){
		ListenableFuture<BabyTimeLine> babyProfileTimelineFuture = asyncExecute(() -> profileService.getTimelineBabyProfileByLastestDay(profileId, limit));
		callBackAndResponse(babyProfileTimelineFuture, response);
	}

	@GET
	@Path("/standard_profile/{profileId}/homepage")
	@Produces(MediaType.APPLICATION_JSON)
	//@ManagedAsync
	public void getStandardHomepage(@Valid @NotNull @PathParam("profileId") Long profileId,
									@HeaderParam("token") String token,
									@Suspended final AsyncResponse response){
		Long userId = PhrContext.current().getUserId();
		ListenableFuture<StandardHomePage> profileFuture = asyncExecute(() -> profileService.getStandardHomepageByProfileId(profileId, userId));
		callBackAndResponse(profileFuture, response);
	}

	@PUT
	@Path("/set_active_profile/{activeProfileId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void activeProfile(@QueryParam("type") Integer type, @Valid @NotNull @PathParam("activeProfileId") Long requestActiveProfileId,
			@HeaderParam("token") String token,  @NotNull @QueryParam("udid") String udid, @Suspended final AsyncResponse response) {
		ListenableFuture<Boolean> profileFuture = asyncExecute(() -> profileService.activeProfile(requestActiveProfileId, udid, type));
		callBackAndResponse(profileFuture, response);
	}

	@PUT
	@Path("/{profileId}/clinic_account/set_active_profile/{activeClinicAccountId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void activeAccount(@Valid @NotNull @PathParam("profileId") Long currentProfileId,
							  @Valid @NotNull @PathParam("activeClinicAccountId") Long requestActiveClinicAccountId,
							  @Suspended final AsyncResponse response) {

		ListenableFuture<Boolean> profileFuture = asyncExecute(() -> profileService.activeAccountClinic(currentProfileId, requestActiveClinicAccountId));
		callBackAndResponse(profileFuture, response);
	}

	@POST
	@Path("/{profileId}/clinic_account")
	@Produces(MediaType.APPLICATION_JSON)
	public void addClinicAccount(@Valid @NotNull @PathParam("profileId") Long profileId,
								 @Valid @NotNull KcckAccountModel model,
								 @Suspended final AsyncResponse response){

		ListenableFuture<PatientClinicModel> profileFuture = asyncExecute(() -> profileService.addAccountClinic(profileId, model));
		//callBackAndResponse(profileFuture, response);

		Futures.addCallback(profileFuture, new FutureCallback<PatientClinicModel>() {
			@Override
			public void onSuccess(PatientClinicModel result) {
				MessageResponse<?> rs;
				if (result == null) {
					rs = new MessageResponse.MessageResponseBuilder<PatientModel>(Message.MESSAGE_VERIFY_PATIENT_KCCK_FAIL.getValue(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else if (result.getHospCode() == null) {
					rs = new MessageResponse.MessageResponseBuilder<PatientModel>(Message.FAIL.getValue(),
							Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PatientClinicModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(result).build();
					response.resume(rs);
				}
			}

			@Override
			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}

		});
	}

	@DELETE
	@Path("/{profileId}/clinic_account/{clinicAccountiId}")
	@Produces(MediaType.APPLICATION_JSON)
	public void deleteClinicAccount(@Valid @NotNull @PathParam("profileId") Long profileId,
									@Valid @NotNull @PathParam("clinicAccountiId") Long clinicAccountiId,
									@Suspended final AsyncResponse response){

		ListenableFuture<Boolean> profileFuture = asyncExecute(() -> accountClinicService.deleteAccountClinic(clinicAccountiId, profileId));
		callBackAndResponse(profileFuture, response);
	}

	private String validBabyProfile(ProfileBaby profileModel, boolean isUpdate){
		if(StringUtils.isEmpty(profileModel.getFullName())){
			return Message.BABY_PROFILE_FULL_NAME_REQUIRED.getValue();
		}
		if(StringUtils.isEmpty(profileModel.getFullNameKana())){
			return Message.BABY_PROFILE_FULL_NAME_KANA_REQUIRED.getValue();
		}
		if(StringUtils.isEmpty(profileModel.getBirthday())){
			return Message.BABY_PROFILE_BIRTHDAY_REQUIRED.getValue();
		}
		if(StringUtils.isEmpty(profileModel.getRelationship())){
			return Message.BABY_PROFILE_RELATIONSHIP_REQUIRED.getValue();
		}
		if(StringUtils.isEmpty(profileModel.getGender())){
			return Message.BABY_PROFILE_GENDER_REQUIRED.getValue();
		}
		if(profileModel.getBabyGrowthHeightModel() == null){
			return Message.BABY_PROFILE_GROWTH_HEIGHT_MODEL_REQUIRED.getValue();
		}
		if(profileModel.getBabyGrowthWeightModel() == null){
			return Message.BABY_PROFILE_GROWTH_WEIGHT_MODEL_REQUIRED.getValue();
		}
		if(isUpdate && profileModel.getBabyGrowthHeightModel().getId() == null){
			return Message.BABY_PROFILE_GROWTH_HEIGHT_ID_REQUIRED.getValue();
		}
		if(isUpdate && profileModel.getBabyGrowthWeightModel().getId() == null){
			return Message.BABY_PROFILE_GROWTH_WEIGHT_ID_REQUIRED.getValue();
		}
		if(StringUtils.isEmpty(profileModel.getBabyGrowthHeightModel().getHeight())){
			return Message.BABY_PROFILE_GROWTH_HEIGHT_REQUIRED.getValue();
		}
		if(StringUtils.isEmpty(profileModel.getBabyGrowthWeightModel().getWeight())){
			return Message.BABY_PROFILE_GROWTH_WEIGHT_REQUIRED.getValue();
		}
		return "";
	}
//	@PUT
//	@Path("/{profileId}/set_active_sync_udid")
//	@Produces(MediaType.APPLICATION_JSON)
//	public void setActiveSyncUdId(@Valid @NotNull @PathParam("profileId") Long profileId,
//								  @HeaderParam("token") String token,@QueryParam("udid") String udid,
//								 @Suspended final AsyncResponse response){
//		Long accountId = PhrContext.current().getUserId();
//		ListenableFuture<Boolean> profileFuture = asyncExecute(() -> profileService.activeSyncFlg(accountId, profileId, udid));
//
//		Futures.addCallback(profileFuture, new FutureCallback<Boolean>() {
//			@Override
//			public void onSuccess(Boolean result) {
//				MessageResponse<?> rs;
//				if(result)
//				{
//					rs = new MessageResponse.MessageResponseBuilder<Boolean>(Message.MESSAGE_SUCCESS.getValue(),
//							Message.SUCCESS.getValue()).setContent(true).build();
//					response.resume(rs);
//				}
//				else
//				{
//					rs = new MessageResponse.MessageResponseBuilder<PatientModel>(Message.FAIL.getValue(),
//							Message.FAIL.getValue()).build();
//					response.resume(rs);
//				}
//			}
//
//			@Override
//			public void onFailure(Throwable thrown) {
//				fail(response, thrown);
//			}
//		});
//	}

    @GET
    @Path("/{profileId}/validate_udid")
    @Produces(MediaType.APPLICATION_JSON)
    public void validateUdid(@Valid @NotNull @PathParam("profileId") Long profileId,
                                 @HeaderParam("token") String token, @NotNull @QueryParam("udid") String udid,
                                 @Suspended final AsyncResponse response) {


        MessageResponse<Integer> messageResponse = new MessageResponse.MessageResponseBuilder<Integer>(
                Message.MESSAGE_SUCCESS.getValue(),
                Message.SUCCESS.getValue()).build();
        if (profileService.isValidUidStandard(profileId, udid)) {
            messageResponse.setContent(1);
        } else {
            messageResponse.setContent(0);
        }


        response.resume(messageResponse);

    }
    
    @POST
    @Path("account/{accountId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getAccountInfo(@PathParam("accountId") Long accountId, @HeaderParam("token") String token, @Suspended final AsyncResponse response)  {
		ListenableFuture<AccountInfo> verifyFuture = asyncExecute(() -> profileService.getAccountInfo(accountId));
		callBackAndResponse(verifyFuture, response);
	}
    
    @POST
    @Path("userchild/{accountId}")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void getUserChildInfo(@PathParam("accountId") BigInteger childId, @HeaderParam("token") String token, @Suspended final AsyncResponse response)  {
		ListenableFuture<UserChildInfo> verifyFuture = asyncExecute(() -> profileService.getUserChildByChildId(childId));
		callBackAndResponse(verifyFuture, response);
	}
    
}
