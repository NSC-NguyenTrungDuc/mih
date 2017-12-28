package nta.med.ext.phr.restful.controller;

import java.net.URI;
import java.util.Arrays;
import java.util.Collection;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.*;
import javax.ws.rs.container.AsyncResponse;
import javax.ws.rs.container.ContainerRequestContext;
import javax.ws.rs.container.Suspended;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import nta.med.ext.phr.glossary.AccountStatus;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.glassfish.jersey.server.ManagedAsync;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import com.google.common.util.concurrent.FutureCallback;
import com.google.common.util.concurrent.Futures;
import com.google.common.util.concurrent.ListenableFuture;
import com.restfb.DefaultFacebookClient;
import com.restfb.FacebookClient;
import com.restfb.types.User;

import nta.med.core.common.annotation.TokenIgnore;
import nta.med.ext.phr.caching.TokenManager;
import nta.med.ext.phr.configuration.PhrConfiguration;
import nta.med.ext.phr.glossary.AccountType;
import nta.med.ext.phr.glossary.Constant;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.AccountClinicKcckModel;
import nta.med.ext.phr.model.MailModel;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.PhrAccountModel;
import nta.med.ext.phr.model.PhrContext;
import nta.med.ext.phr.model.SocialAccountModel;
import nta.med.ext.phr.model.UserInfo;
import nta.med.ext.phr.service.MailService;
import nta.med.ext.phr.service.PhrAccountService;
import nta.med.ext.phr.service.impl.PhrAccountServiceImpl;

/**
 * @author DEV-TiepNM
 */
@Path("/accounts")
@Component
public class AccountResource extends BaseResource {

	private static final Logger LOGGER = LogManager.getLogger(PhrAccountServiceImpl.class);

	@Resource
	private PhrAccountService phrAccountService;

	@Resource
	private MailService mailService;

	@Resource
	private PhrConfiguration configuration;

	@Resource
	private TokenManager<UserInfo> cache;

	public AccountResource() {

	}

	@GET
	@Path("/health-check")
	@TokenIgnore
	public Response healthCheck() {
		return Response.ok().entity("success").build();
	}

	@POST
	@Path("/register")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	@TokenIgnore
	public void addAccount(@Valid @NotNull PhrAccountModel phrAccountModel, @Suspended final AsyncResponse response,
			@NotNull @QueryParam("udid") String udid) {

		String message = valid(phrAccountModel);
		if (!StringUtils.isEmpty(message)) {
			response.resume(new MessageResponse.MessageResponseBuilder<String>(message, Message.FAIL.getValue())
					.setContent(null).build());
		} else {
			ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
					() -> phrAccountService.addAccount(phrAccountModel, udid, false));
			Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
				public void onSuccess(PhrAccountModel model) {
					MessageResponse<?> rs;
					if (model.equals(phrAccountModel)) {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.MESSAGE_DUPLICATE_EMAIL.getValue(), Message.FAIL.getValue()).build();
						response.resume(rs);
					} else {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue())
										.setContent(phrAccountModel).build();
						response.resume(rs);

						String confirmLink = configuration.getBaseUri() + Constant.PHR_PATH_VERIFY + model.getId() + "/"
								+ model.getToken();
						String registerName = phrAccountModel.getProfile().getFullName();

						MailModel mailModel = mailService.getMailTemplate(Constant.MAIL_TYPE_CONFIRM_REGISTER,
								Constant.JA_LOCALE);
						String bodyTemplate = mailModel.getBodyTemplate();
						String bodyMail = mailService.prepareEmailBody(bodyTemplate, registerName, confirmLink, null,
								null);
						String subject = mailModel.getSubject();
						String imgPath = configuration.getPhrImages() + Constant.ICON_USER_IMG;
						String imgIdentifier = Constant.ICON_USER_IMG;
						mailService.sendMultipart(subject, Arrays.asList(model.getEmail()), bodyMail, true, imgPath,
								imgIdentifier);
					}

				}

				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		}
	}

	
	@POST
	@Path("/add_account_clinic")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	public void addAccountClinicFromMbs(@Valid @NotNull PhrAccountModel phrAccountModel, @HeaderParam("token") String token,
			@Suspended final AsyncResponse response) {
		String message = "";
		if(phrAccountModel.getMasterProfileId()==null)
			message =  Message.MESSAGE_PROFILE_NOT_FOUND.getValue();
		if(phrAccountModel.getHospcode()==null)
			message = Message.MESSAGE_HOSP_NOT_FOUND.getValue();
		if(phrAccountModel.getPatientcode() == null)
			message = Message.MESSAGE_PATIENT_NOT_FOUND.getValue();
		if (!StringUtils.isEmpty(message)) {
			response.resume(new MessageResponse.MessageResponseBuilder<String>(message, Message.FAIL.getValue())
					.setContent(null).build());
		} else {
			ListenableFuture<Integer> accountFuture = asyncExecute(
					() -> phrAccountService.addAccountClinic(phrAccountModel));
			Futures.addCallback(accountFuture, new FutureCallback<Integer>() {
				public void onSuccess(Integer result) {
					MessageResponse<?> rs;
					if (result.equals(-1)) {
						rs = new MessageResponse.MessageResponseBuilder<>(
								Message.MESSAGE_PROFILE_HOSP_PATIENT.getValue(), Message.FAIL.getValue()).build();
						response.resume(rs);
					} else {
						rs = new MessageResponse.MessageResponseBuilder<>(
								Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).build();
						response.resume(rs);
					}
				}

				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		}
	}
	
	@POST
	@Path("/registermbs")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	@TokenIgnore
	public void addAccountFromMbs(@Valid @NotNull PhrAccountModel phrAccountModel,
			@Suspended final AsyncResponse response, @QueryParam("udid") String udid) {

		String message = valid(phrAccountModel);
		if (!StringUtils.isEmpty(message)) {
			response.resume(new MessageResponse.MessageResponseBuilder<String>(message, Message.FAIL.getValue())
					.setContent(null).build());
		} else {
			ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
					() -> phrAccountService.addAccount(phrAccountModel, udid, false));
			Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
				public void onSuccess(PhrAccountModel model) {
					MessageResponse<?> rs;
					if (model.equals(phrAccountModel)) {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.MESSAGE_DUPLICATE_EMAIL.getValue(), Message.FAIL.getValue()).build();
						response.resume(rs);
					} else {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue())
										.setContent(phrAccountModel).build();
						response.resume(rs);
					}
				}

				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		}
	}

	private String valid(PhrAccountModel phrAccountModel) {
		if (phrAccountModel.getProfile().getGender() == null) {
			return Message.GENDER_REQUIRED.getValue();
		}
		if (StringUtils.isEmpty(phrAccountModel.getProfile().getBirthday())) {
			return Message.BIRTHDAY_REQUIRED.getValue();
		}
		return null;
	}

	@Path("/verify/{id}/{token}")
	@GET
	public Response verifyAccount(@PathParam("id") Long id, @PathParam("token") String token) throws Exception {

		Long userId = PhrContext.current().getUserId();
		Long profileId = PhrContext.current().getDefaultProfileId();
		PhrAccountModel originalAccount = phrAccountService.findById(id);
		if (originalAccount.getStatus().intValue() == AccountStatus.ACTIVE.getValue().intValue()
				&& originalAccount.getType() == AccountType.NEW_REGISTER.getValue()) {
			URI targetURIForRedirection = new URI(configuration.getConfirmAccountHasActivedUrl());
			return Response.temporaryRedirect(targetURIForRedirection).build();
		}
		// PhrAccountModel accountModel =
		// phrAccountService.verifyAccount(userId, profileId);
		PhrAccountModel accountModel = phrAccountService.verifyAccount(userId, profileId);
		if (accountModel != null) {
			boolean registerNewAccount = false;
			if (originalAccount.getType() == AccountType.NEW_REGISTER.getValue()) {
				registerNewAccount = true;
			} else if (originalAccount.getType() == AccountType.RESET_PASSWORD.getValue()) {

				registerNewAccount = false;
			}
			URI targetURIForRedirection;
			if (registerNewAccount) {
				targetURIForRedirection = new URI(configuration.getConfirmAccountUrl());

			} else {
				targetURIForRedirection = new URI(configuration.getConfirmPasswordUrl());
			}

			MailModel mailModel = mailService.getMailTemplate(Constant.MAIL_TYPE_SEND_PASSWORD, Constant.JA_LOCALE);
			String bodyTemplate = mailModel.getBodyTemplate();
			String bodyMail = mailService.prepareEmailBody(bodyTemplate, accountModel.getProfile().getFullName(), null,
					accountModel.getEmail(), accountModel.getNewPassword());
			String subject = mailModel.getSubject();
			String imgPath = configuration.getPhrImages() + Constant.ICON_LOCK_OPEN_IMG;
			String imgIdentifier = Constant.ICON_LOCK_OPEN_IMG;

			mailService.sendMultipart(subject, Arrays.asList(accountModel.getEmail()), bodyMail, true, imgPath,
					imgIdentifier);
			// cache.invalidate(token);
			return Response.temporaryRedirect(targetURIForRedirection).build();
		} else {
			URI targetURIForRedirection = new URI(configuration.getErrorConfirmUrl());
			return Response.temporaryRedirect(targetURIForRedirection).build();
		}

	}

	@Path("/verifyFromMbs/{email}")
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@TokenIgnore
	public void verifyAccountFromMbs(@PathParam("email") String email,@Suspended final AsyncResponse response) throws Exception {

		PhrAccountModel originalAccount = phrAccountService.findByEmail(email);
		MessageResponse<?> rs;
		if (originalAccount != null) {
			
			if (originalAccount.getStatus().intValue() == AccountStatus.ACTIVE.getValue().intValue()) {
				rs = new MessageResponse.MessageResponseBuilder<>(Message.MESSAGE_ACCOUNT_ALREADY_ACTIVE.getValue(), Message.FAIL.getValue()).build();
				response.resume(rs);
			}
			if (phrAccountService.verifyAccount(originalAccount.getId())) {
				rs = new MessageResponse.MessageResponseBuilder<>(
						Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue())
								.setMessage("Success").build();
				response.resume(rs);
			} else {
				rs = new MessageResponse.MessageResponseBuilder<>(Message.MESSAGE_FAIL.getValue(), Message.FAIL.getValue()).build();
				response.resume(rs);
			}
		}
		else
		{
			rs = new MessageResponse.MessageResponseBuilder(Message.MESSAGE_FAIL.getValue(), Message.FAIL.getValue()).build();
			response.resume(rs);
		}
		// PhrAccountModel accountModel =
		// phrAccountService.verifyAccount(userId, profileId);
		

	}
	@GET
	@Path("/generate-token")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	@TokenIgnore
	public void generateToken(@QueryParam("patient_code") String patientCode, @QueryParam("hosp_code") String hospCode, @Suspended final AsyncResponse response) {
		ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(() -> phrAccountService.generateToken(patientCode, hospCode));
		callBackAndResponse(accountFuture, response);
	}

	@POST
	@Path("/login")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	@TokenIgnore
	public void login(@Valid @NotNull PhrAccountModel accountModel, @Suspended final AsyncResponse response) {
		ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(() -> phrAccountService.login(accountModel));
		Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
			public void onSuccess(PhrAccountModel accountModel) {

				MessageResponse<?> rs;
				if (accountModel.isResultIsVerify()) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_LOGIN_IS_NOT_VERIFY_YET.getValue(), Message.FAIL.getValue()).build();
				} else if (accountModel.isResultIsChangePass()) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_LOGIN_IS_FIRST.getValue(), Message.FAIL.getValue()).setContent(accountModel)
									.build();
				} else if (accountModel.getId() == null) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_LOGIN_IS_FAIL.getValue(), Message.FAIL.getValue()).build();
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(accountModel).build();
				}
				response.resume(rs);
			}

			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}

	@Path("/logout")
	@PUT
	@Produces(MediaType.APPLICATION_JSON)
	// @ManagedAsync
	public void logout(@HeaderParam("token") String token, @Suspended final AsyncResponse response) {

		Long userId = PhrContext.current().getUserId();

		ListenableFuture<Boolean> logoutFuture = asyncExecute(() -> phrAccountService.processLogout(token, userId));
		Futures.addCallback(logoutFuture, new FutureCallback<Boolean>() {

			@Override
			public void onSuccess(Boolean result) {
				response.resume(new MessageResponse.MessageResponseBuilder<String>(
						Message.MESSAGE_LOGOUT_SUCCESS.getValue(), Message.SUCCESS.getValue()).build());
			}

			@Override
			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});

	}

	@Path("/reset_password")
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@TokenIgnore
	public void processResetPassword(PhrAccountModel account, @Suspended final AsyncResponse response) {
		ListenableFuture<PhrAccountModel> resetPasswordFuture = asyncExecute(
				() -> phrAccountService.processForgotPassword(account.getEmail()));
		Futures.addCallback(resetPasswordFuture, new FutureCallback<PhrAccountModel>() {
			@Override
			public void onSuccess(PhrAccountModel accountModel) {
				MessageResponse<?> rs;

				if (accountModel != null) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_RESET_PASSWORD_SUCCESS.getValue(), Message.SUCCESS.getValue()).build();
					response.resume(rs);

					MailModel mailModel = mailService.getMailTemplate(Constant.MAIL_TYPE_RESET_PASSWORD,
							Constant.JA_LOCALE);
					String bodyTemplate = mailModel.getBodyTemplate();
					String confirmLink = configuration.getBaseUri() + Constant.PHR_PATH_VERIFY + accountModel.getId()
							+ "/" + accountModel.getToken();
					String bodyMail = mailService.prepareEmailBody(bodyTemplate,
							accountModel.getProfile().getFullName(), confirmLink, accountModel.getEmail(), null);
					String subject = mailModel.getSubject();
					String imgPath = configuration.getPhrImages() + Constant.ICON_LOCK_IMG;
					String imgIdentifier = Constant.ICON_LOCK_IMG;

					mailService.sendMultipart(subject, Arrays.asList(account.getEmail()), bodyMail, true, imgPath,
							imgIdentifier);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_RESET_PASSWORD_EMAIL_UNREGISTERED.getValue(), Message.FAIL.getValue())
									.build();
					response.resume(rs);
				}
			}

			@Override
			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}

	@PUT
	@Path("/update_information")
	@Produces(MediaType.APPLICATION_JSON)
	public void updateInformation( @Valid @NotNull PhrAccountModel accountModel,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response) {

		Long userId = PhrContext.current().getUserId();

		ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
				() -> phrAccountService.updateInformation(token, accountModel, userId));
		Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
			public void onSuccess(PhrAccountModel accountModel) {

				MessageResponse<?> rs;
				if (accountModel.getId() == null) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_CHANGE_PASSWORD_FAIL.getValue(), Message.FAIL.getValue()).build();
					response.resume(rs);
				} else if (accountModel.isResultTokenIsRequired()) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_CHANGE_PASSWORD_TOKEN_NULL.getValue(), Message.FAIL.getValue()).build();
					response.resume(rs);
				} else if (accountModel.isResultTokenInvalid()) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_CHANGE_PASSWORD_TOKEN_INVALID.getValue(), Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(accountModel).build();
					response.resume(rs);
				}
			}

			@Override
			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}
	@PUT
	@Path("/forgot_passwordmbs")
	@Produces(MediaType.APPLICATION_JSON)
	@TokenIgnore
	@ManagedAsync
	public void forgotPasswordMbs( @Valid @NotNull PhrAccountModel accountModel, @Suspended final AsyncResponse response) {
		ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
				() -> phrAccountService.forgotPasswordMbs(accountModel));
		Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
			public void onSuccess(PhrAccountModel accountModel) {

				MessageResponse<?> rs;
				if (accountModel.getId() == null) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_CHANGE_PASSWORD_FAIL.getValue(), Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(accountModel).build();
					response.resume(rs);
				}
			}

			@Override
			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}

	
	@PUT
	@Path("/change_password")
	@Produces(MediaType.APPLICATION_JSON)
	// @ManagedAsync
	public void changePassword(@Context ContainerRequestContext crc, @Valid @NotNull PhrAccountModel accountModel,
							   @HeaderParam("token") String token, @Suspended final AsyncResponse response) {

		Long userId = PhrContext.current().getUserId();

		ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
				() -> phrAccountService.changePassword(token, accountModel, userId));
		Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
			public void onSuccess(PhrAccountModel accountModel) {

				MessageResponse<?> rs;
				if (accountModel.getId() == null) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_CHANGE_PASSWORD_FAIL.getValue(), Message.FAIL.getValue()).build();
					response.resume(rs);
				} else if (accountModel.isResultTokenIsRequired()) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_CHANGE_PASSWORD_TOKEN_NULL.getValue(), Message.FAIL.getValue()).build();
					response.resume(rs);
				} else if (accountModel.isResultTokenInvalid()) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_CHANGE_PASSWORD_TOKEN_INVALID.getValue(), Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(accountModel).build();
					response.resume(rs);
				}
			}

			@Override
			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}

	
	@PUT
	@Path("/standard_change_background")
	@Produces(MediaType.APPLICATION_JSON)
	// @ManagedAsync
	public void changeStandardBackground(@Valid @NotNull PhrAccountModel accountModel,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		Long userId = PhrContext.current().getUserId();

		ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
				() -> phrAccountService.changeStandardBackground(accountModel, userId));
		Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
			public void onSuccess(PhrAccountModel accountModel) {

				MessageResponse<?> rs;
				if (accountModel.getId() == null && accountModel.getStandardBackgroundUrl() == null) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_INVALID_INPUT_PARAM.getValue(), Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(accountModel).build();
					response.resume(rs);
				}
			}

			@Override
			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}

	@PUT
	@Path("/baby_change_background")
	@Produces(MediaType.APPLICATION_JSON)
	// @ManagedAsync
	public void changeBabyBackground(@Valid @NotNull PhrAccountModel accountModel, @HeaderParam("token") String token,
			@Suspended final AsyncResponse response) {
		Long userId = PhrContext.current().getUserId();
		ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
				() -> phrAccountService.changeBabyBackground(accountModel, userId));
		Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
			public void onSuccess(PhrAccountModel accountModel) {

				MessageResponse<?> rs;
				if (accountModel.getId() == null && accountModel.getBabyBackgroundUrl() == null) {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_INVALID_INPUT_PARAM.getValue(), Message.FAIL.getValue()).build();
					response.resume(rs);
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(Message.MESSAGE_SUCCESS.getValue(),
							Message.SUCCESS.getValue()).setContent(accountModel).build();
					response.resume(rs);
				}
			}

			@Override
			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}
		});
	}

	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public void getUserInfo(@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(() -> phrAccountService.getAccount(token));
		callBackAndResponse(accountFuture, response);
	}

	@POST
	@Path("/kcck")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	@TokenIgnore
	public void verifyAccountKcck(@Valid @NotNull PhrAccountModel accountModel,
			@Suspended final AsyncResponse response) {
		ListenableFuture<Collection<AccountClinicKcckModel>> future = asyncExecute(
				() -> phrAccountService.verifyAccountFromKcck(accountModel));
		Futures.addCallback(future, new FutureCallback<Collection<AccountClinicKcckModel>>() {
			@Override
			public void onFailure(Throwable thrown) {
				fail(response, thrown);
			}

			@Override
			public void onSuccess(Collection<AccountClinicKcckModel> result) {
				MessageResponse<?> rs;
				if (result != null) {
					rs = new MessageResponse.MessageResponseBuilder<Collection<AccountClinicKcckModel>>(
							Message.MESSAGE_VERIFY_KCCK_SUCCESS.getValue(), Message.SUCCESS.getValue())
									.setContent(result).build();
				} else {
					rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
							Message.MESSAGE_VERIFY_KCCK_FAIL.getValue(), Message.FAIL.getValue()).build();
				}
				response.resume(rs);
			}
		});
	}

	@POST
	@Path("/register_facebook")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	@TokenIgnore
	public void registerUseFacebook(@Valid @NotNull SocialAccountModel socialAccountModel,
			@Suspended final AsyncResponse response, @NotNull @QueryParam("udid") String udid) {
		LOGGER.info("BEGIN registerUseFacebook: " + socialAccountModel.toString());
		String message = validRegisterUseFacebook(socialAccountModel) == null
				? validFacebookAccessToken(socialAccountModel) : validRegisterUseFacebook(socialAccountModel);
		if (!StringUtils.isEmpty(message)) {
			response.resume(new MessageResponse.MessageResponseBuilder<String>(message, Message.FAIL.getValue())
					.setContent(null).build());
		} else {
			ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
					() -> phrAccountService.registerUseFacebook(socialAccountModel, udid));
			Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
				public void onSuccess(PhrAccountModel result) {
					MessageResponse<?> rs;
					if (result != null && result.getId() == null) {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.FACEBOOK_ID_IN_USED.getValue(), Message.FAIL.getValue()).setContent(result)
										.build();
						response.resume(rs);
					}
					if (result != null && result.getId() != null) {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(result)
										.build();
					} else {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.FACEBOOK_REGISTER_FAIL.getValue(), Message.FAIL.getValue()).build();
					}
					response.resume(rs);
				}

				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		}
	}

	private String validRegisterUseFacebook(SocialAccountModel socialAccountModel) {
		if (socialAccountModel.getFacebookId() == null) {
			return Message.FACEBOOK_REGISTER_ID_REQUIRED.getValue();
		}
		if (StringUtils.isEmpty(socialAccountModel.getEmail())) {
			return Message.FACEBOOK_EMAIL_REQUIRED.getValue();
		}
		if (StringUtils.isEmpty(socialAccountModel.getBirthday())) {
			return Message.FACEBOOK_BIRTH_REQUIRED.getValue();
		}
		return null;
	}

	@POST
	@Path("/login_facebook")
	@Produces(MediaType.APPLICATION_JSON)
	@ManagedAsync
	@TokenIgnore
	public void loginUseFacebook(@Valid @NotNull SocialAccountModel socialAccountModel,
			@Suspended final AsyncResponse response) {
		LOGGER.info("BEGIN loginUseFacebook: " + socialAccountModel.toString());
		String message = validFacebookAccessToken(socialAccountModel);
		if (!StringUtils.isEmpty(message)) {
			response.resume(new MessageResponse.MessageResponseBuilder<String>(message, Message.FAIL.getValue())
					.setContent(null).build());
		} else {
			ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
					() -> phrAccountService.loginUseFacebook(socialAccountModel));
			Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
				public void onSuccess(PhrAccountModel accountModel) {

					MessageResponse<?> rs;
					if (accountModel != null && accountModel.getId() == null) {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.FACEBOOK_LOGIN_FAIL.getValue(), Message.FAIL.getValue()).build();
					} else {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(accountModel)
										.build();
					}
					response.resume(rs);
				}

				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		}
	}

	@SuppressWarnings("deprecation")
	private String validFacebookAccessToken(SocialAccountModel socialAccountModel) {
		try {
			// get face_book info
			FacebookClient facebookClient = new DefaultFacebookClient(socialAccountModel.getAccessToken());
			User user = facebookClient.fetchObject("me", User.class);
			if (socialAccountModel.getFacebookId() != null
					&& !user.getId().equals(socialAccountModel.getFacebookId().toString())) {
				LOGGER.warn("WARN: facebook_id input invalid!!!");
				LOGGER.warn("API: facebook_id:" + user.getId());
				LOGGER.warn("INPUT: facebook_id:" + socialAccountModel.getFacebookId());
				return Message.FACEBOOK_ID_INVALID.getValue();
			}
		} catch (Exception e) {
			LOGGER.warn("ERROR: facebook access token invalid!!!", e.getMessage());
			LOGGER.warn("INPUT: facebook_id:" + socialAccountModel.getFacebookId());
			return Message.FACEBOOK_ACCESS_TOKEN_INVALID.getValue();
		}

		return null;
	}

	@PUT
	@Path("/{accountId}/change_status_agreement")
	@Produces(MediaType.APPLICATION_JSON)
	// @ManagedAsync
	public void changeStatusAgreement(@NotNull @PathParam("accountId") Long accountId,
			@HeaderParam("token") String token, @Suspended final AsyncResponse response) {
		Long userId = PhrContext.current().getUserId();
		if (!userId.equals(accountId)) {
			MessageResponse<?> rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
					Message.ACCOUNT_ID_INVALID.getValue(), Message.FAIL.getValue()).build();
			response.resume(rs);
		} else {
			ListenableFuture<PhrAccountModel> accountFuture = asyncExecute(
					() -> phrAccountService.changeStatusAgreement(accountId));
			Futures.addCallback(accountFuture, new FutureCallback<PhrAccountModel>() {
				public void onSuccess(PhrAccountModel accountModel) {

					MessageResponse<?> rs;
					if (accountModel.getId() != null) {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.MESSAGE_SUCCESS.getValue(), Message.SUCCESS.getValue()).setContent(accountModel)
										.build();
						response.resume(rs);
					} else {
						rs = new MessageResponse.MessageResponseBuilder<PhrAccountModel>(
								Message.ACCOUNT_WITH_TYPE_AGREEMENT_UPDATED.getValue(), Message.FAIL.getValue())
										.build();
						response.resume(rs);
					}
				}

				@Override
				public void onFailure(Throwable thrown) {
					fail(response, thrown);
				}
			});
		}
	}
	
	@GET
	@Path("/update_patient_code")
    @Produces(MediaType.APPLICATION_JSON)
	@TokenIgnore
    public Response list(@Valid @NotNull(message = "patient.code.required") @QueryParam("patientCode") String patientCode,
    		@Valid @NotNull(message = "profile.id.required") @QueryParam("profileId") String profileId,
    		@Valid @NotNull(message = "hospital.code.required") @QueryParam("hospCode") String hospCode) {
		
		Integer resultUpdate = 0;
		try {
			Long profileIdLong = Long.parseLong(profileId);
			resultUpdate = phrAccountService.updatePatientCodeByProfileIdHopsCode(profileIdLong, hospCode, patientCode);
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		// set result
		if(resultUpdate > 0) {
			MessageResponse<Integer> messageResponse = new MessageResponse.MessageResponseBuilder<Integer>(
	 				Message.MESSAGE_SUCCESS.getValue(),
	 	            Message.SUCCESS.getValue()).setContent(resultUpdate).build();
			return Response.ok().entity(messageResponse).build();
		} else {
			MessageResponse<Integer> messageResponse = new MessageResponse.MessageResponseBuilder<Integer>(
	 				Message.MESSAGE_FAIL.getValue(),
	 	            Message.FAIL.getValue()).setContent(resultUpdate).build();
			return Response.ok().entity(messageResponse).build();
		}
 		
    }
	
}
