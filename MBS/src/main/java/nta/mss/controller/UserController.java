package nta.mss.controller;

import java.math.BigInteger;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.validation.Valid;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.math.NumberUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.security.access.annotation.Secured;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.web.authentication.logout.CookieClearingLogoutHandler;
import org.springframework.security.web.authentication.logout.SecurityContextLogoutHandler;
import org.springframework.security.web.authentication.rememberme.AbstractRememberMeServices;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import com.restfb.DefaultFacebookClient;
import com.restfb.FacebookClient;
import com.restfb.Parameter;
import com.restfb.types.User;

import nta.kcck.service.impl.KcckDepartmentService;
import nta.mss.info.AjaxResponse;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.info.HospitalDto;
import nta.mss.info.MailInfo;
import nta.mss.info.PasswordInfo;
import nta.mss.info.ProfileManagementInfo;
import nta.mss.info.ReservationInfo;
import nta.mss.info.VaccineCdUsingInfo;
import nta.mss.info.VaccineDetailInfo;
import nta.mss.info.VaccineWarningInfo;
import nta.mss.misc.common.DomainNameUtils;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.common.TokenUtils;
import nta.mss.misc.common.VaccineUtils;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.DepartmentType;
import nta.mss.misc.enums.GenderChild;
import nta.mss.misc.enums.HospitalLocale;
import nta.mss.misc.enums.MailCode;
import nta.mss.misc.enums.NotificationType;
import nta.mss.misc.enums.UserRole;
import nta.mss.misc.enums.VaccineWarningType;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.ChangePassModel;
import nta.mss.model.DepartmentModel;
import nta.mss.model.MailModel;
import nta.mss.model.NotificationModel;
import nta.mss.model.UpdateInformationModel;
import nta.mss.model.UserChildModel;
import nta.mss.model.UserModel;
import nta.mss.model.VaccineChildHistoryModel;
import nta.mss.model.VaccineModel;
import nta.mss.security.WebUserDetails;
import nta.mss.service.IDepartmentService;
import nta.mss.service.IHospitalService;
import nta.mss.service.IMailService;
import nta.mss.service.IUserChildService;
import nta.mss.service.IUserService;
import nta.mss.service.IVaccineChildHistoryService;
import nta.mss.service.IVaccineHospitalService;
import nta.mss.service.IVaccineService;
import nta.phr.service.impl.PhrApiService;

/**
 * The Class UserController.
 *
 * @author MinhLS
 * @CrtDate Jan 15, 2015
 */
@Controller
@Scope("prototype")
@RequestMapping("booking")
@NavigationConfig(leftMenuType = NavigationType.FRONT_LEFT_MENU)
public class UserController extends BaseController {

	/** The user service. */
	private IUserService userService;

	/** The mail service. */
	private IMailService mailService;

	/** The department service. */
	private IDepartmentService departmentService;

	/** The vaccine service. */
	private IVaccineService vaccineService;

	/** The user child service. */
	private IUserChildService userChildService;

	/** The vaccine child history service. */
	private IVaccineChildHistoryService vaccineChildHistoryService;

	/** The web user details. */
	private WebUserDetails webUserDetails;

	private IVaccineHospitalService vaccineHospitalService;

	private IHospitalService hospitalService;

	KcckDepartmentService kcckDepartmentService = new KcckDepartmentService();

	@Resource
	private PhrApiService phrApiService;

	/** The Constant LOG. */
	private static final Logger LOG = LogManager.getLogger(UserController.class);

	/**
	 * Instantiates a new user controller.
	 *
	 * @param userService
	 *            the user service
	 * @param mailService
	 *            the mail service
	 * @param vaccineService
	 *            the vaccine service
	 * @param userChildService
	 *            the user child service
	 * @param vaccineChildHistoryService
	 *            the vaccine child history service
	 * @param departmentService
	 *            the department service
	 */
	@Autowired
	public UserController(IUserService userService, IMailService mailService, IVaccineService vaccineService,
						  IUserChildService userChildService, IVaccineChildHistoryService vaccineChildHistoryService,
						  IDepartmentService departmentService, IVaccineHospitalService vaccineHospitalService,
						  IHospitalService hospitalService) {
		this.userService = userService;
		this.mailService = mailService;
		this.departmentService = departmentService;
		this.vaccineService = vaccineService;
		this.userChildService = userChildService;
		this.vaccineChildHistoryService = vaccineChildHistoryService;
		this.vaccineHospitalService = vaccineHospitalService;
		this.hospitalService = hospitalService;
	}

	/**
	 * Instantiates a new user controller.
	 */
	public UserController() {
	}

	/**
	 * Gets the user.
	 *
	 * @return the user
	 */
	public UserModel getUser() {
		if (SecurityContextHolder.getContext().getAuthentication() != null) {
			Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();
			if (principal instanceof WebUserDetails) {
				return ((WebUserDetails) principal).getUser();
			}
		}
		return null;
	}

	@RequestMapping(value = "/access-denied", method = RequestMethod.GET)
	public ModelAndView accessDenied() {
		return new ModelAndView("front.access.denied");
	}

	@RequestMapping(value = "/page-not-found", method = RequestMethod.GET)
	public ModelAndView pageNotFound() {
		return new ModelAndView("front.page.not.found");
	}

	/**
	 * User login.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 */
	@RequestMapping(value = "/login", method = RequestMethod.GET)
	public ModelAndView userLogin(@RequestParam(value = "deptId", required = false) String deptId, ModelMap model)
			throws Exception {
		LOG.info("[START] front end login");
		if (deptId != null && StringUtils.isNotBlank(deptId) && NumberUtils.isDigits(deptId)) {
			MssContextHolder.setDeptId(Integer.valueOf(deptId));
			LOG.debug("DEPTID: " + deptId);
		}
		model.addAttribute("isLoginFaceBook", "false");
		model.addAttribute("hospitalId", MssContextHolder.getHospitalId());

		LOG.info("[END] front end login");
		return new ModelAndView("front.login");
	}

	@RequestMapping(value = "/login-facebook", method = RequestMethod.GET)
	public ModelAndView userLoginFacebook(HttpServletRequest request, ModelMap model) throws Exception {
		LOG.info("[START] front end login");

		String appId = MssConfiguration.getInstance().getFaceBookAppId();
		String appSecret = MssConfiguration.getInstance().getFaceBookSecret();
		String code = request.getParameter("code");
		FacebookClient.AccessToken accessToken = new DefaultFacebookClient().obtainUserAccessToken(appId, appSecret,
				MssConfiguration.getInstance().getFaceBookLoginUrlRedirect(), code);

		FacebookClient facebookClient = new DefaultFacebookClient(accessToken.getAccessToken());
		// User fbUser = facebookClient.fetchObject("me",
		// com.restfb.types.User.class, Parameter.with("fields", "id,
		// first_name, last_name, email, gender, birthday"));
		User user = facebookClient.fetchObject("me", User.class);
		com.restfb.types.User fbUser = facebookClient.fetchObject(user.getId(), com.restfb.types.User.class,
				Parameter.with("fields", "id, first_name, last_name, email, gender, birthday"));
		UserModel userModel = userService.getUserByLoginId(fbUser.getId(), MssContextHolder.getHospitalId());
		MssContextHolder.setFacebookId(fbUser.getId());
		model.addAttribute("accessToken", accessToken.getAccessToken());
		model.addAttribute("hospitalId", MssContextHolder.getHospitalId());
		model.addAttribute("isLoginFaceBook", "true");
		if (userModel == null) {
			model.addAttribute("user", fbUser.getEmail());
		} else {
			model.addAttribute("user", userModel.getEmail());
		}

		model.addAttribute("password", MssConfiguration.getInstance().getDefaultPassword());
		LOG.info("[END] front end login");
		return new ModelAndView("front.login");
	}

	/**
	 * Forget password.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@RequestMapping(value = "/forget-password", method = RequestMethod.GET)
	public ModelAndView forgetPassword(ModelMap model) {
		LOG.info("[START] forget password");
		MailModel mail = new MailModel();
		model.addAttribute("mail", mail);
		LOG.info("[END] forget password");
		return new ModelAndView("front.forget.password");
	}

	/**
	 * Forget password confirm.
	 *
	 * @param mail
	 *            the mail
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@RequestMapping(value = "/forget-password", method = RequestMethod.POST)
	public ModelAndView forgetPasswordConfirm(@Valid @ModelAttribute("mail") MailModel mail, BindingResult result,
											  ModelMap model) throws Exception {
		LOG.info("[START] forget password confirmation");
		String email = mail.getEmail();
		UserModel userModel = null;
		ModelAndView mav = new ModelAndView("front.forget.password");
		if (result.getFieldError("email") == null) {
			LOG.debug("Email: " + email);
			// check email exists
			userModel = this.userService.getActiveUserByEmail(email, MssContextHolder.getHospitalId());
			if (userModel == null) {
				result.rejectValue("email", "re00101.msg.email.invalid");
				LOG.info("Email is invalid");
			}
		}
		if (result.hasErrors()) {
			LOG.info("Validate failed");
			return mav;
		}
		LOG.info("Validate successfully");

		// Update Token
		userModel.setTokenId(TokenUtils.generateToken());
		this.userService.saveUser(userModel);

		LOG.info("Reset password successfully");
		MailInfo mailInfo = new MailInfo();
		mailInfo.setUserName(userModel.getName());
		mailInfo.setHospitalName(userModel.getHospitalName());
		mailInfo.setSessionId(userModel.getTokenId());
		List<Object> args = new ArrayList<Object>();
		args.add(MssContextHolder.getTokenHospCode());
		mailInfo.setLinkResetPassword(MssContextHolder.getDomainName()
				+ this.getText("be030.link.for.reset.password", args) + mailInfo.getSessionId().toString());
		List<String> toList = new ArrayList<>();
		toList.add(userModel.getEmail());
		mailService.sendUserMail(MailCode.FORGET_PASSWORD.toString(), this.getLanguage(), mailInfo, toList,
				MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
				MssContextHolder.getDomainName());
		model.addAttribute("message", this.getText("re00101.msg.send.email.success"));
		LOG.info("[END] forget password confirmation");
		return mav;
	}

	/**
	 * Change password.
	 *
	 * @param token
	 *            the token
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@RequestMapping(value = "/change-password", method = RequestMethod.GET)
	public ModelAndView changePassword(@RequestParam("token") String token,
									   @RequestParam(value = "tokenHospCode", required = false) String tokenHospCode, ModelMap model)
			throws Exception {
		LOG.info("[Start] change password");

		if (!StringUtils.isEmpty(tokenHospCode)) {
			if (StringUtils.isEmpty(MssContextHolder.getTokenHospCode())
					|| (!StringUtils.isEmpty(MssContextHolder.getTokenHospCode())
					&& !tokenHospCode.equals(MssContextHolder.getTokenHospCode()))) {
				String hospCode = EncryptionUtils.decrypt(tokenHospCode, MssConfiguration.getInstance().getSecretKey(),
						EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
				if (StringUtils.isEmpty(hospCode)) {
					return new ModelAndView("front.page.not.found");
				}
				HospitalDto hospital = this.hospitalService.getHospitalModelByHospitalCode(hospCode);
				if (hospital == null) {
					return new ModelAndView("front.access.denied");
				}
				MssContextHolder.setHospitalId(hospital.getHospitalId());
				MssContextHolder.setHospitalName(hospital.getHospitalName());
				MssContextHolder.setHospitalIconPath(hospital.getHospitalIconPath());
				MssContextHolder.setTokenHospCode(tokenHospCode);
				MssContextHolder.setHospCode(hospCode);
				MssContextHolder.setUserLanguage(hospital.getLocale());
				MssContextHolder.setHospitalLocale(hospital.getLocale());
				MssContextHolder.setHospitalEmail(hospital.getEmail());
				MssContextHolder.setHospitalParentId(hospital.getHospitalParentId());

				MssContextHolder.setDomainName(DomainNameUtils.getDomainName(hospital.getLocale()));
			}
		} else {
			if (StringUtils.isEmpty(MssContextHolder.getHospCode())) {
				return new ModelAndView("front.access.denied");
			}
		}

		PasswordInfo passwordInfo = new PasswordInfo();
		String tokenValidate = TokenUtils.validateTokenAndCheckExpiredTime(token);
		if (tokenValidate != null) {
			UserModel userModel = this.userService.findByToken(token);
			if (userModel == null) {
				LOG.warn("[WARN] changePassword. UserModel is null");
				return new ModelAndView(new RedirectView("expire"));
			}
			userModel.setTokenId(null);
			this.userService.saveUser(userModel);
			passwordInfo.setEmail(userModel.getEmail());
			userModel.setTokenId(null);
			this.userService.saveUser(userModel);

			LOG.info("[End] change password");
		} else {
			return new ModelAndView(new RedirectView("expire"));
		}

		return new ModelAndView("front.change.password", "passwordInfo", passwordInfo);
	}

	/**
	 * Confirm change password.
	 *
	 * @param passwordInfo
	 *            the password info
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@RequestMapping(value = "/change-password", method = RequestMethod.POST)
	public ModelAndView confirmChangePassword(@ModelAttribute("passwordInfo") @Valid PasswordInfo passwordInfo,
											  BindingResult result, ModelMap model) throws Exception {
		if (result.hasErrors()) {
			return new ModelAndView("front.change.password", "passwordInfo", passwordInfo);
		}
		String password = passwordInfo.getPassword();
		String passwordConfirm = passwordInfo.getPasswordConfirm();
		// check password confirm matching
		if (!password.equalsIgnoreCase(passwordConfirm)) {
			result.rejectValue("passwordConfirm", "re002.msg.password.not.match");
			return new ModelAndView("front.change.password", "passwordInfo", passwordInfo);
		}
		UserModel userModel = new UserModel();
		userModel.setPassword(passwordInfo.getPassword());
		userModel.setEmail(passwordInfo.getEmail());
		userModel.setHospitalId(MssContextHolder.getHospitalId());
		try {
			ChangePassModel modelChagePass = new ChangePassModel(userModel.getEmail(), userModel.getPassword());
			boolean resultChangePass = phrApiService.changePassword(modelChagePass);
			if (resultChangePass) {
				this.addNotification(new NotificationModel(NotificationType.SUCCESS,
						this.getText("general.msg.reset.password.success")));
				return new ModelAndView(new RedirectView("index"));
			}

		} catch (Exception e) {
			e.printStackTrace();
		}
		this.addNotification(
				new NotificationModel(NotificationType.ERROR, this.getText("general.msg.reset.password.failed")));
		LOG.info("[END] confirm change password. ");
		return new ModelAndView(new RedirectView("login"));
	}

	/**
	 * Register.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@RequestMapping(value = "/register", method = RequestMethod.GET)
	public ModelAndView register(ModelMap model) {
		LOG.info("[START] register");
		UserModel user = new UserModel();
		user.setIsFaceBook(false);
		model.addAttribute("user", user);
		LOG.info("[END] register");
		return new ModelAndView("front.register");
	}

	@RequestMapping(value = "/register-fb", method = RequestMethod.GET)
	public ModelAndView registerFb(ModelMap model, HttpServletRequest request) throws Exception {
		String error_code = request.getParameter("error_code");
		String access_deny = request.getParameter("error");
		if (error_code != null && access_deny != null) {
			UserModel user = new UserModel();
			user.setIsFaceBook(false);
			model.addAttribute("user", user);
			return new ModelAndView("front.register");
		} else {
			String appId = MssConfiguration.getInstance().getFaceBookAppId();
			String appSecret = MssConfiguration.getInstance().getFaceBookSecret();
			String code = request.getParameter("code");
			FacebookClient.AccessToken accessToken = new DefaultFacebookClient().obtainUserAccessToken(appId, appSecret,
					MssConfiguration.getInstance().getFaceBookRegisterUrlRedirect(), code);

			FacebookClient facebookClient = new DefaultFacebookClient(accessToken.getAccessToken());
			// User fbUser = facebookClient.fetchObject("me",
			// com.restfb.types.User.class, Parameter.with("fields", "id,
			// first_name, last_name, email, gender, birthday"));
			User user = facebookClient.fetchObject("me", User.class);
			com.restfb.types.User fbUser = facebookClient.fetchObject(user.getId(), com.restfb.types.User.class,
					Parameter.with("fields", "id, first_name, last_name, email, gender, birthday"));

			LOG.info("[START] register fb");
			UserModel userModel = new UserModel();

			if (fbUser.getEmail() != null) {
				userModel.setEmail(fbUser.getEmail());
				userModel.setName(fbUser.getFirstName() + " " + fbUser.getLastName());

				if (fbUser.getGender() != null
						&& fbUser.getGender().toLowerCase().equals(GenderChild.MALE.name().toLowerCase())) {
					userModel.setSex("1");
				} else {
					userModel.setSex("0");
				}
				userModel.setLoginId(fbUser.getId());
				userModel.setToken(accessToken.getAccessToken());
				userModel.setDob(fbUser.getBirthday());
				userModel.setEmail(fbUser.getEmail());

				userModel.setIsFaceBook(true);

			}
			model.addAttribute("user", userModel);
			LOG.info("[END] register");
			return new ModelAndView("front.register");
		}
	}

	/**
	 * Register confirm.
	 *
	 * @param user
	 *            the user
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@RequestMapping(value = "/register", method = RequestMethod.POST)
	public ModelAndView registerConfirm(@Valid @ModelAttribute("user") UserModel user, BindingResult result,
										ModelMap model) throws Exception {
		LOG.info("[START] register confirmation");
		String fullName = user.getName();
		String fullNameKana = user.getNameFurigana();
		if (HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
			if (result.getFieldError(fullName) == null && result.getFieldError(fullNameKana) == null) {
				LOG.debug("Full Name: " + fullName + " Full Name Kana: " + fullNameKana);
				// check space ã‚­ãƒŽã‚·ã‚¿ ã‚´ã‚¦ ã�¡ ã�¡
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("name", "general.label.name.required.space");
				}
				if (!StringUtils.isEmpty(fullNameKana)
						&& !fullNameKana.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("nameFurigana", "general.label.name.required.space");
				}
			}
		} else {
			if (result.getFieldError(fullName) == null) {
				LOG.debug("Full Name: " + fullName);
				// check space
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("name", "general.label.name.required.space");
				}
				// if(!StringUtils.isEmpty(fullName) &&
				// !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
				// result.rejectValue("name",
				// "general.label.name.required.space");
				// }
			}
		}

		String hospitalCode = MssContextHolder.getHospCode();
		String hospitalName = MssContextHolder.getHospitalName();
		user.setHospitalName(hospitalName);
		user.setHospitalCode(hospitalCode);
		String password = user.getPassword();
		String passwordConfirm = user.getPasswordConfirm();
		String email = user.getEmail();
		String dob = user.getDob();
		if (dob == null || dob.isEmpty()) {
			LOG.debug("Birth day empty ");
		} else {
			if (!dob.matches("((?:19|20)\\d\\d)/(0?[1-9]|1[012])/([12][0-9]|3[01]|0?[1-9])")) {
				result.rejectValue("dob", "re002.msg.dob.invalid");
			}
		}
		// String loginId = user.getLoginId();
		user.setHospitalId(MssContextHolder.getHospitalId());
		if (user.getIsFaceBook().equals("false")) {
			if ((password == null) || (passwordConfirm == null)) {
				result.rejectValue("passwordConfirm", "re002.msg.password.is.blank");
				result.rejectValue("password", "re002.msg.password.is.blank");
			}
		}
		if (user.getIsFaceBook().equals("false") && result.getFieldError("password") == null
				&& result.getFieldError("passwordConfirm") == null) {
			// check password confirm matching
			if (!password.equalsIgnoreCase(passwordConfirm)) {
				result.rejectValue("passwordConfirm", "re002.msg.password.not.match");
			}
		}
		if (result.getFieldError("email") == null) {
			LOG.debug("Email: " + email);
			// check email exists
			if(user.getIsFaceBook().equals(false) || StringUtils.isEmpty(user.getLoginId()))
			{
				if (this.userService.getUserByEmail(email, MssContextHolder.getHospitalId()) != null) {
					result.rejectValue("email", "re002.msg.email.invalid");
					LOG.info("Email is not available");
				}
			}

		}
		if (!StringUtils.isEmpty(user.getLoginId()) && user.getIsFaceBook().equals(true)) {
			UserModel userModel = userService.getUserByLoginId(user.getLoginId(), MssContextHolder.getHospitalId());
			if (userModel != null) {
				result.rejectValue("email", "re002.msg.email.invalid");
				LOG.info("FacebookId exist");
			}
		}

//		/*
//		 * if (result.getFieldError("loginId") == null) { LOG.debug("LoginId: "
//		 * + loginId); // check loginId exists if
//		 * (this.userService.getUserByLoginId(loginId,
//		 * MssContextHolder.getHospitalId()) != null) {
//		 * result.rejectValue("loginId", "re002.msg.loginId.invalid"); LOG.info(
//		 * "LoginId is not available"); } }
//		 */

		if (result.hasErrors()) {
			LOG.info("Validate failed");
			return new ModelAndView("front.register");
		}
		LOG.info("Validate successfully");
		LOG.debug("User: " + user.toString());

		boolean registerSuccess = false;

		if (user.getIsFaceBook().equals(true)) {
			registerSuccess = phrApiService.registerAccountFacebook(user);
		} else {
			registerSuccess = phrApiService.registerAccount(user);
		}

		if (registerSuccess) {
			// registerSuccess = this.userService.addNewUser(user,
			// user.getIsFaceBook());

			String token = TokenUtils.generateRegisterToken(user.getEmail());
			// Send email to customer
			MailInfo mailInfo = new MailInfo();
			mailInfo.setPatientName(user.getName());
			mailInfo.setLoginId(user.getLoginId());
			mailInfo.setLoginEmail(user.getEmail());
			List<Object> args = new ArrayList<Object>();
			args.add(MssContextHolder.getTokenHospCode());
			mailInfo.setLinkVerifyAccount(
					MssContextHolder.getDomainName() + this.getText("be030.link.verify.account", args) + token);
			List<String> toList = new ArrayList<>();
			toList.add(user.getEmail());
			mailService.sendUserMail(MailCode.VERIFY_ACCOUNT.toString(), this.getLanguage(), mailInfo, toList,
					MssContextHolder.getHospitalId(), MssContextHolder.getHospitalEmail(),
					MssContextHolder.getDomainName());
			if(user.getIsFaceBook().equals(true))
			{
				model.addAttribute("register_account_facebook", "true");
			}
			else
			{
				NotificationModel notify = new NotificationModel(NotificationType.WARN, this.getText("general.msg.register.success"));
				notify.setTimeAppear("20000");
				this.addNotification(notify);
			}

		}
		// Add new user to database with status is register accepted

		if (!registerSuccess) {
			// Registration failed
			this.addNotification(
					new NotificationModel(NotificationType.ERROR, this.getText("general.msg.register.failed")));
		}

		LOG.info("[END] register confirmation");
		return new ModelAndView(new RedirectView("index?tokenHospCode=" + MssContextHolder.getTokenHospCode()));
	}

	/**
	 * Verify account.
	 *
	 * @param model
	 *            the model
	 * @param tokenId
	 *            the token id
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@RequestMapping(value = "/verify-account", method = RequestMethod.GET)
	public ModelAndView verifyAccount(@RequestParam(value = "tokenHospCode", required = false) String tokenHospCode,
									  ModelMap model, @RequestParam(value = "token") String tokenId) throws Exception {
		LOG.info("[Start] Verify account");
		if (!StringUtils.isEmpty(tokenHospCode)) {
			if (StringUtils.isEmpty(MssContextHolder.getTokenHospCode())
					|| (!StringUtils.isEmpty(MssContextHolder.getTokenHospCode())
					&& !tokenHospCode.equals(MssContextHolder.getTokenHospCode()))) {
				String hospCode = EncryptionUtils.decrypt(tokenHospCode, MssConfiguration.getInstance().getSecretKey(),
						EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
				if (StringUtils.isEmpty(hospCode)) {
					return new ModelAndView("front.page.not.found");
				}
				HospitalDto hospital = this.hospitalService.getHospitalModelByHospitalCode(hospCode);
				if (hospital == null) {
					return new ModelAndView("front.access.denied");
				}
				MssContextHolder.setHospitalId(hospital.getHospitalId());
				MssContextHolder.setHospitalName(hospital.getHospitalName());
				MssContextHolder.setHospitalIconPath(hospital.getHospitalIconPath());
				MssContextHolder.setTokenHospCode(tokenHospCode);
				MssContextHolder.setHospCode(hospCode);
				MssContextHolder.setUserLanguage(hospital.getLocale());
				MssContextHolder.setHospitalLocale(hospital.getLocale());
				MssContextHolder.setHospitalEmail(hospital.getEmail());
				MssContextHolder.setHospitalParentId(hospital.getHospitalParentId());

				MssContextHolder.setDomainName(DomainNameUtils.getDomainName(hospital.getLocale()));
			}
		} else {
			if (StringUtils.isEmpty(MssContextHolder.getHospCode())) {
				return new ModelAndView("front.access.denied");
			}
		}

		ModelAndView modelAndView = new ModelAndView(new RedirectView("login"));
		String email = TokenUtils.validateTokenAndCheckExpiredTime(tokenId);
		LOG.debug("Email: " + email);
		if (email != null) {
			// update user status to register completed
			boolean verifyAccountSuccess = false;
			if (userService.registerUser(email, MssContextHolder.getHospitalId())) {
				PhrApiService phrApiService = new PhrApiService();
				if (phrApiService.verifyAccount(email)) {
					verifyAccountSuccess = true;
				}
			}
			if (verifyAccountSuccess) {
				model.addAttribute("verify_account", "true");
				this.addNotification(
						new NotificationModel(NotificationType.SUCCESS, this.getText("general.msg.verify.success")));
				LOG.info("Verify successfully");
			} else {
				this.addNotification(
						new NotificationModel(NotificationType.ERROR, this.getText("general.msg.verify.failed")));
				LOG.info("Verify failed");
			}
			return modelAndView;
		} else {
			LOG.info("Token is invalid or link is expired");
			return new ModelAndView(new RedirectView("expire"));
		}
	}

	/**
	 * Profile management.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/profile-management", method = RequestMethod.GET)
	public ModelAndView profileManagement(ModelMap model) throws Exception {
		LOG.info("[START] profile-management");

		UserModel userModel = this.userService.getUser(this.getUser().getUserId());

		ProfileManagementInfo user = new ProfileManagementInfo();
		user.setUserChilds(userModel.getUserChilds());
		user.setName(userModel.getName());
		user.setNameFurigana(userModel.getNameFurigana());
		user.setSex(userModel.getSex());
		user.setPhoneNumber(userModel.getPhoneNumber());
		user.setUserId(userModel.getUserId());
		user.setPatientCode(userModel.getPatientCode());
		user.setLoginId(userModel.getLoginId());
		user.setMasterProfileId(getUser().getMasterProfileId());

		/*
		 * user.setUserChilds(null);
		 * user.setName(phrAccountInfoModelRes.getName());
		 * user.setNameFurigana(phrAccountInfoModelRes.getName_kana());
		 * user.setSex(phrAccountInfoModelRes.getSex());
		 * user.setPhoneNumber(null);
		 * user.setUserId(Integer.valueOf(phrAccountInfoModelRes.getId().
		 * intValue())); user.setPatientCode(null);
		 */

		// Get list user child
		List<UserChildModel> lstUserChildModel = this.userChildService
				.findUserChildByActiveFlg(this.getUser().getUserId(), ActiveFlag.ACTIVE.toInt());
		user.setUserChilds(lstUserChildModel);
		DepartmentModel departmentModel = null;
		List<DepartmentModel> lstDepartmentModel = null;
		// Get DeptId
		if (MssContextHolder.isKcck()) {
			if (CollectionUtils.isEmpty(MssContextHolder.getKcckDepartmentList())) {
				lstDepartmentModel = this.kcckDepartmentService.getListDepartment(MssContextHolder.getHospCode(),
						MssContextHolder.getLocale().toString());
				MssContextHolder.setKcckDepartmentList(lstDepartmentModel);
			} else {
				lstDepartmentModel = MssContextHolder.getKcckDepartmentList();
			}
		} else {
			departmentModel = this.departmentService.findDeptByType(MssContextHolder.getHospCode(),
					DepartmentType.NEWBORNS.toInt());
		}

		if (!CollectionUtils.isEmpty(lstDepartmentModel)) {
			for (DepartmentModel info : lstDepartmentModel) {
				if (info.getDeptCode().equals("15")) {
					departmentModel = info;
					break;
				}
			}
		}
		if (departmentModel != null) {
			model.addAttribute("deptId", departmentModel.getDeptId());
			model.addAttribute("deptType", departmentModel.getDeptType());
		} else {
			model.addAttribute("deptId", null);
		}
		if (user.getLoginId() != null) {
			model.addAttribute("isFacebookId", true);
		}
		LOG.info("[END] profile-management");
		return new ModelAndView("front.profile.management", "user", user);
	}

	/**
	 * Submit profile management.
	 *
	 * @param user
	 *            the user
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @param session
	 *            the session
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/profile-management", method = RequestMethod.POST)
	public ModelAndView submitProfileManagement(@Valid @ModelAttribute("user") ProfileManagementInfo user,
												BindingResult result, ModelMap model, HttpSession session) throws Exception {
		UserModel userModel = this.userService.getUser(user.getUserId());
		user.setUserChilds(this.userChildService.findUserChildByActiveFlg(user.getUserId(), ActiveFlag.ACTIVE.toInt()));
		String fullName = user.getName();
		String fullNameKana = user.getNameFurigana();
		if (HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
			if (result.getFieldError(fullName) == null && result.getFieldError(fullNameKana) == null) {
				LOG.debug("Full Name: " + fullName + " Full Name Kana: " + fullNameKana);
				// check space ã‚­ãƒŽã‚·ã‚¿ ã‚´ã‚¦ ã�¡ ã�¡
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("name", "general.label.name.required.space");
				}
				if (!StringUtils.isEmpty(fullNameKana)
						&& !fullNameKana.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("nameFurigana", "general.label.name.required.space");
				}
			}
		} else {
			if (result.getFieldError(fullName) == null) {
				LOG.debug("Full Name: " + fullName);
				// check space
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("name", "general.label.name.required.space");
				}
			}
		}
		ModelAndView modelAndView = new ModelAndView("front.profile.management", "user", user);
		if (result.hasErrors()) {
			return modelAndView;
		}
		if (userModel.getLoginId() == null) { // Update logic if user has
			// facebookId , can't update
			// change password
			// Check password
			if (!StringUtils.isBlank(user.getChangePass())) {
				String password = user.getPassword();
				String passwordConfirm = user.getPasswordConfirm();
				if (StringUtils.isBlank(password)) {
					result.rejectValue("password", "NotBlank.user.password");
				}
				if (StringUtils.isBlank(passwordConfirm)) {
					result.rejectValue("passwordConfirm", "NotBlank.user.passwordConfirm");
				}
				if (result.hasErrors()) {
					model.addAttribute("isChangePass", user.getChangePass());
					return modelAndView;
				}
				if (!StringUtils.isBlank(password)) {
					if (!password.equalsIgnoreCase(passwordConfirm)) {
						result.rejectValue("passwordConfirm", "re002.msg.password.not.match");
						model.addAttribute("isChangePass", user.getChangePass());
						return modelAndView;
					}
					userModel.setPassword(EncryptionUtils.cryptWithMD5(password));
				}

			}
		}

		userModel.setName(user.getName());
		userModel.setNameFurigana(user.getNameFurigana());
		userModel.setSex(user.getSex());
		userModel.setPhoneNumber(user.getPhoneNumber());
		userModel.setMasterProfileId(getUser().getMasterProfileId());

		try {
			String passwordOld = getUser().getPasswordConfirm();
			String hosp_code = "";
			if (MssContextHolder.getHospCode() != null) {
				hosp_code = MssContextHolder.getHospCode();
			}
			UpdateInformationModel userChangePassModel = new UpdateInformationModel(userModel.getEmail(), passwordOld,
					userModel.getPassword(), userModel.getName(), userModel.getNameFurigana(), userModel.getSex(),
					userModel.getPhoneNumber(), userModel.getMasterProfileId(), hosp_code);
			boolean resultChangePass = phrApiService.updateInformation(userChangePassModel, getUser().getToken());
			if (resultChangePass) {
				this.addNotification(
						new NotificationModel(NotificationType.SUCCESS, this.getText("re002.msg.change.success")));
				return new ModelAndView(new RedirectView("profile-management"));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}

		this.addNotification(new NotificationModel(NotificationType.ERROR, this.getText("re002.msg.change.fail")));
		return new ModelAndView(new RedirectView("profile-management"));
	}

	/**
	 * View vaccine history.
	 *
	 * @param model
	 *            the model
	 * @param childId
	 *            the child id
	 * @return the model and view
	 * @throws NumberFormatException
	 *             the number format exception
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/vaccine-history", method = RequestMethod.GET)
	public ModelAndView viewVaccineHistory(ModelMap model, @RequestParam(value = "childId") String childId)
			throws NumberFormatException, Exception {
		if (childId != null && !StringUtils.isBlank(childId) && NumberUtils.isDigits(childId)) {
			UserChildModel userChild = this.userChildService.findById(Integer.valueOf(childId));
			DepartmentModel newbornDepartmentModel = this.departmentService
					.findDeptByType(MssContextHolder.getHospCode(), DepartmentType.NEWBORNS.toInt());
			DepartmentModel vaccineDepartmentModel = this.departmentService
					.findDeptByType(MssContextHolder.getHospCode(), DepartmentType.VACCINE.toInt());
			if (userChild.getSex().equals("1"))
				userChild.setGenderText(this.getText("general.label.male"));
			else
				userChild.setGenderText(this.getText("general.label.female"));
			model.addAttribute("userChild", userChild);
			if (newbornDepartmentModel != null) {
				model.addAttribute("newbornDeptId", newbornDepartmentModel.getDeptId());
			}
			if (vaccineDepartmentModel != null) {
				model.addAttribute("vaccineDeptId", vaccineDepartmentModel.getDeptId());
			}
			return new ModelAndView("front.vaccine.history");
		} else {
			// TODO: return to error page
			return new ModelAndView("front.booking.index");
		}
	}

	/**
	 * Ajax init full vaccine schedule list.
	 *
	 * @param userChild
	 *            the user child
	 * @param session
	 *            the session
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/ajax-init-full-vaccine-schedule-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxInitFullVaccineScheduleList(@RequestBody UserChildModel userChild, HttpSession session)
			throws Exception {
		LOG.info("[Start] Ajax init full vaccine schedule list");
		// Type = 2 Get full vaccine list
		AjaxResponseBuilder builder = this.getVaccineScheduleList(userChild, 2);
		LOG.info("[End] Ajax init full vaccine schedule list");
		return builder.build();
	}

	/**
	 * Ajax init recommended vaccine schedule list.
	 *
	 * @param userChild
	 *            the user child
	 * @param session
	 *            the session
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/ajax-init-recommended-booking-vaccine-schedule-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxInitRecommendedVaccineScheduleList(@RequestBody UserChildModel userChild,
															   HttpSession session) throws Exception {
		LOG.info("[Start] Ajax init recommended and booking vaccine schedule list");
		// Type = 1 Get recommended and booking vaccine list
		AjaxResponseBuilder builder = this.getVaccineScheduleList(userChild, 1);
		LOG.info("[End] Ajax init recommended and booking vaccine schedule list");
		return builder.build();
	}

	/**
	 * Ajax init booking vaccine schedule list.
	 *
	 * @param userChild
	 *            the user child
	 * @param session
	 *            the session
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/ajax-init-recommended-vaccine-schedule-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxInitBookingVaccineScheduleList(@RequestBody UserChildModel userChild, HttpSession session)
			throws Exception {
		LOG.info("[Start] Ajax init recommended vaccine schedule list");
		// Type = 0 Get recommended vaccine list only
		AjaxResponseBuilder builder = this.getVaccineScheduleList(userChild, 0);
		LOG.info("[End] Ajax init recommended vaccine schedule list");
		return builder.build();
	}

	/**
	 * Gets the vaccine schedule list.
	 *
	 * @param userChild
	 *            the user child
	 * @param type
	 *            the type
	 * @return the vaccine schedule list
	 * @throws Exception
	 *             the exception
	 */
	private AjaxResponseBuilder getVaccineScheduleList(UserChildModel userChild, Integer type) throws Exception {
		// Get hospital code from login user
		String hospitalCode = this.getUser().getHospitalCode();

		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Integer childId = userChild.getChildId();
		if (childId == null) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("fe00302.msg.err.select.child"));
			return builder;
		}

		UserChildModel child = this.userChildService.findById(childId);
		Date childBirthDay = child.getBirthDay();
		LOG.debug("Child:" + child);
		List<VaccineDetailInfo> result = new ArrayList<VaccineDetailInfo>();

		List<VaccineDetailInfo> bookingList = this.vaccineService.getVaccineBookingHistoryList(childId, hospitalCode);
		for (VaccineDetailInfo vaccineInfo : bookingList) {
			vaccineInfo.setFormattedSupportFeeDate(childBirthDay);
		}
		List<VaccineDetailInfo> userHistoryList = this.vaccineService.getVaccineUserHistoryList(childId, hospitalCode);
		for (VaccineDetailInfo vaccineInfo : userHistoryList) {
			vaccineInfo.setFormattedSupportFeeDate(childBirthDay);
		}
		List<VaccineDetailInfo> recommendedList = this.getRecommendedVaccineList(child, bookingList, userHistoryList,
				hospitalCode);
		// Type == 0 Get recommended vaccine list
		result.addAll(recommendedList);
		// Type == 1 Get recommended and booking vaccine list
		if (type.equals(1)) {
			result.addAll(bookingList);
		}
		// Type == 2 Get full vaccine list
		else if (type.equals(2)) {
			result.addAll(bookingList);
			result.addAll(userHistoryList);
		}

		builder.status(HttpStatus.OK).data(result);
		return builder;
	}

	/**
	 * Ajax get child info.
	 *
	 * @param userChild
	 *            the user child
	 * @param session
	 *            the session
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/ajax-get-child-info", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxGetChildInfo(@RequestBody UserChildModel userChild, HttpSession session) throws Exception {
		LOG.info("[Start] Ajax get child info");
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Integer childId = userChild.getChildId();
		if (childId == null) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("fe00302.msg.err.select.child"));
			return builder.build();
		}

		UserChildModel child = this.userChildService.findById(childId);
		LOG.debug("Child:" + child);
		if (child.getSex().equals("1"))
			child.setGenderText(this.getText("general.label.male"));
		else
			child.setGenderText(this.getText("general.label.female"));
		builder.status(HttpStatus.OK).data(child);
		LOG.info("[End] Ajax get child info");
		return builder.build();
	}

	/**
	 * Gets the recommended vaccine list.
	 *
	 * @param child
	 *            the child
	 * @return the recommended vaccine list
	 * @throws Exception
	 *             the exception
	 */
	private List<VaccineDetailInfo> getRecommendedVaccineList(UserChildModel child,
															  List<VaccineDetailInfo> bookingHistoryList, List<VaccineDetailInfo> userHistoryList, String hospitalCode)
			throws Exception {
		Integer childId = child.getChildId();
		Date childBirthDay = child.getBirthDay();
		Map<String, VaccineCdUsingInfo> vaccineCdUsingMap = this.vaccineService.getVaccineCdUsingMap(childId,
				hospitalCode);
		List<VaccineDetailInfo> fullVaccineList = this.vaccineService.getAllVaccineList(childId, hospitalCode);

		// Merge to get full history vaccine with format vaccine_id + _ +
		// inject_no
		List<String> fullHistoryList = this.vaccineService.getAllHistoryVaccineList(bookingHistoryList,
				userHistoryList);
		Integer limitAgeFromMonth;
		Integer limitAgeToMonth;
		Integer vaccineId = null;
		Date temp = null;
		VaccineCdUsingInfo vaccineCdUsingInfo;
		Iterator<VaccineDetailInfo> i = fullVaccineList.iterator();
		boolean isFirst = false;
		while (i.hasNext()) {
			VaccineDetailInfo vaccineInfo = i.next();
			String vaccineCd = vaccineInfo.getVaccineCd();

			if (vaccineId == null || !vaccineId.equals(vaccineInfo.getVaccineId())) {
				vaccineId = vaccineInfo.getVaccineId();
				isFirst = true;
			} else if (vaccineId.equals(vaccineInfo.getVaccineId())) {
				isFirst = false;
			}
			limitAgeFromMonth = vaccineInfo.getLimitAgeFromMonth();
			limitAgeToMonth = vaccineInfo.getLimitAgeToMonth();
			// check age limit of using vaccine by birthday to current time
			if (limitAgeToMonth != null
					&& VaccineUtils.compareLimitAgeByMonth(childBirthDay, limitAgeToMonth, null) < 0) {
				i.remove();
				continue;
			} else if (VaccineUtils.compareLimitAgeByMonth(childBirthDay, limitAgeFromMonth, null) >= 0) {
				vaccineInfo.setDateCanBooking(MssDateTimeUtil.addMonthToDate(childBirthDay, limitAgeFromMonth));
			} else {
				vaccineInfo.setDateCanBooking(Calendar.getInstance().getTime());
			}

			// calculate the next date of next injection with same vaccine_cd
			// (vaccine_cd is continuous in array)
			if (vaccineCdUsingMap.containsKey(vaccineCd)) {
				vaccineCdUsingInfo = vaccineCdUsingMap.get(vaccineCd);
				if (BigInteger.valueOf(vaccineInfo.getInjectedNo()).compareTo(vaccineCdUsingInfo.getInjectedNo()) < 1) {
					i.remove();
					continue;
				} else if (BigInteger.valueOf(vaccineInfo.getInjectedNo())
						.equals(vaccineCdUsingInfo.getInjectedNo().add(BigInteger.ONE))) {
					temp = new Date(vaccineCdUsingInfo.getInjectedDate().getTime());
				}
			}

			if (isFirst) {
				temp = vaccineInfo.getDateCanBooking();
			}
			// get date for next injection time
			else {
				temp = MssDateTimeUtil.addDayToDate(temp, vaccineInfo.getDayMin());
			}
			vaccineInfo.setDateCanBooking(temp);

			// check age limit of using vaccine by birthday to date can booking
			if (vaccineInfo.getLimitAgeToMonth() != null && VaccineUtils.compareLimitAgeByMonth(childBirthDay,
					limitAgeToMonth, vaccineInfo.getDateCanBooking()) < 0) {
				i.remove();
				continue;
			}

			// check receiving booking date of hospital to date can booking
			if (vaccineInfo.getToDate() != null
					&& MssDateTimeUtil.compareDate(vaccineInfo.getDateCanBooking(), vaccineInfo.getToDateType()) > 0) {
				i.remove();
				continue;
			} else if (vaccineInfo.getFromDate() != null && MssDateTimeUtil.compareDate(vaccineInfo.getDateCanBooking(),
					vaccineInfo.getFromDateType()) < 0) {
				vaccineInfo.setDateCanBooking(vaccineInfo.getFromDateType());
			}

			// display the XX months of data from now on - loading from config
			// file
			if (VaccineUtils.compareLimitAgeByMonth(Calendar.getInstance().getTime(),
					MssConfiguration.getInstance().getVaccineMonthsView(), vaccineInfo.getDateCanBooking()) < 0) {
				i.remove();
				continue;
			}

			// remove records that contain in history list
			if (fullHistoryList.contains(vaccineInfo.getVaccineId() + "_" + vaccineInfo.getInjectedNo())) {
				i.remove();
				continue;
			}

			// set support fee date
			vaccineInfo.setFormattedSupportFeeDate(childBirthDay);
			// calculate the remaining date
			VaccineWarningInfo vaccineWarningInfo = new VaccineWarningInfo();
			vaccineWarningInfo = VaccineUtils.getVaccineWarningInfo(childBirthDay, vaccineInfo.getLimitAgeToMonth(),
					vaccineInfo.getSupportFeeAge());
			if (vaccineWarningInfo != null) {
				Integer warningDays = vaccineInfo.getWarningDays();
				Integer remainingDays = vaccineWarningInfo.getRemainingDays();
				if (warningDays != 0 && remainingDays <= warningDays && remainingDays > 0) {
					List<Object> args = new ArrayList<Object>();
					args.add(remainingDays);
					if (vaccineWarningInfo.getWarningType().equals(VaccineWarningType.SUPPORT_FEE.toInt())) {
						vaccineInfo.setWarningDaysText(this.getText("general.vaccine.support.fee.warning", args));
					} else {
						vaccineInfo.setWarningDaysText(this.getText("general.vaccine.limit.age.warning", args));
					}
				}
			}
		}
		Collections.sort(fullVaccineList);
		return fullVaccineList;
	}

	/**
	 * Ajax cancel reservation.
	 *
	 * @param vaccineChildHistoryModel
	 *            the vaccine child history model
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/ajax-vaccine-update-hospital", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxCancelReservation(@RequestBody VaccineChildHistoryModel vaccineChildHistoryModel)
			throws Exception {
		// Get hospital id from login user
		Integer hospitalId = this.getUser().getHospitalId();
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		vaccineChildHistoryModel.setInjectedDate(MssDateTimeUtil.convertStringToTimestamp(
				vaccineChildHistoryModel.getInjectedDateStr(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		vaccineChildHistoryModel.setLoginHospitalId(hospitalId);
		// Get Vaccine_hospital
		Integer vaccineHospitalId = this.vaccineHospitalService
				.findByHospitalIdVaccineId(hospitalId, vaccineChildHistoryModel.getVaccineId()).getVaccineHospitalId();
		vaccineChildHistoryModel.setVaccineHospitalId(vaccineHospitalId);

		this.vaccineChildHistoryService.save(vaccineChildHistoryModel);
		builder.status(HttpStatus.OK).message(this.getText("general.vaccine.choose.hospital.success"));
		return builder.build();
	}

	/**
	 * Adds the child.
	 *
	 * @param model
	 *            the model
	 * @return the model and view
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/add-child", method = RequestMethod.GET)
	public ModelAndView addChild(ModelMap model) {

		UserChildModel userChildModel = new UserChildModel();
		return new ModelAndView("front.booking.add.child", "userChildModel", userChildModel);
	}

	/**
	 * Submit add child.
	 *
	 * @param userChildModel
	 *            the user child model
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/add-child", method = RequestMethod.POST)
	public ModelAndView submitAddChild(@Valid @ModelAttribute("userChildModel") UserChildModel userChildModel,
									   BindingResult result, ModelMap model) throws Exception {
		String fullName = userChildModel.getChildName();
		String fullNameKana = userChildModel.getChildNameFurigana();
		if (HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
			if (result.getFieldError(fullName) == null && result.getFieldError(fullNameKana) == null) {
				LOG.debug("Full Name: " + fullName + " Full Name Kana: " + fullNameKana);
				// check space ã‚­ãƒŽã‚·ã‚¿ ã‚´ã‚¦ ã�¡ ã�¡
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("childName", "general.label.name.required.space");
				}
				if (!StringUtils.isEmpty(fullNameKana)
						&& !fullNameKana.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("childNameFurigana", "general.label.name.required.space");
				}
			}
		} else {
			if (result.getFieldError(fullName) == null) {
				LOG.debug("Full Name: " + fullName);
				// check space
				if (!StringUtils.isEmpty(fullName) && !fullName.replaceAll("\u3000", " ").trim().contains(" ")) {
					result.rejectValue("childName", "general.label.name.required.space");
				}
			}
		}
		ModelAndView modelAndView = new ModelAndView("front.booking.add.child", "userChildModel", userChildModel);
		if (result.hasErrors()) {
			return modelAndView;
		}
		if (userChildModel.getChildId() == null) {
			Integer userId = this.getUser().getUserId();
			userChildModel.setUserId(userId);
			this.userChildService.save(userChildModel);
		} else {
			this.userChildService.save(userChildModel);
		}

		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("re008.msg.add.child.success")));
		return new ModelAndView(new RedirectView("profile-management"));
	}

	/**
	 * Delete child.
	 *
	 * @param userChildModel
	 *            the user child model
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/ajax-delete-child", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse deleteChild(@RequestBody UserChildModel userChildModel) throws Exception {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (userChildModel.getChildId() == null) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("re008.delete.child.error"));
			return builder.build();
		}

		// Check if child has booking. Not delete
		List<VaccineChildHistoryModel> lstChildHistoryModel = this.vaccineChildHistoryService
				.findByUserIdChildId(this.getUser().getUserId(), userChildModel.getChildId());
		if (CollectionUtils.isNotEmpty(lstChildHistoryModel)) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("re008.msg.cannot.delete.child"));
			return builder.build();
		}

		// Check if Exist booking newborn
		List<ReservationInfo> lstreReservationInfo = this.vaccineChildHistoryService
				.findReservationInfoByChildId(userChildModel.getChildId());
		if (CollectionUtils.isNotEmpty(lstreReservationInfo)) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("re008.msg.cannot.delete.child"));
			return builder.build();
		}

		userChildModel = this.userChildService.findById(userChildModel.getChildId());
		userChildModel.setActiveFlg(ActiveFlag.INACTIVE.toInt());
		this.userChildService.save(userChildModel);
		builder.status(HttpStatus.OK).message(this.getText("re008.delete.child.success"));
		return builder.build();
	}

	/**
	 * Edits the info user child.
	 *
	 * @param childId
	 *            the child id
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/change-user-child", method = RequestMethod.GET)
	public ModelAndView editInfoUserChild(@RequestParam("childId") String childId, ModelMap model) throws Exception {
		if (StringUtils.isBlank(childId) || !StringUtils.isNumeric(childId)) {
			return new ModelAndView(new RedirectView("profile-management"));
		}

		UserChildModel userChildModel = this.userChildService.findById(Integer.valueOf(childId));
		String dob = MssDateTimeUtil.convertBetweenDateFormat(userChildModel.getDob(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		model.addAttribute("isChange", true);
		model.addAttribute("dobCurrent", dob);
		return new ModelAndView("front.booking.add.child", "userChildModel", userChildModel);
	}

	/**
	 * Submit edit user child.
	 *
	 * @param userChildModel
	 *            the user child model
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/change-user-child", method = RequestMethod.POST)
	public ModelAndView submitEditUserChild(@Valid @ModelAttribute("userChildModel") UserChildModel userChildModel,
											BindingResult result, ModelMap model) throws Exception {
		ModelAndView modelAndView = new ModelAndView("front.booking.add.child", "userChildModel", userChildModel);
		if (result.hasErrors()) {
			return modelAndView;
		}

		this.userChildService.save(userChildModel);
		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("re008.msg.add.child.success")));
		return new ModelAndView(new RedirectView("profile-management"));
	}

	/**
	 * Adds the history vaccine.
	 *
	 * @param childId
	 *            the child id
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/add-history-vaccine", method = RequestMethod.GET)
	public ModelAndView addHistoryVaccine(@RequestParam(value = "childId") String childId, ModelMap model)
			throws Exception {
		if (StringUtils.isBlank(childId) || !NumberUtils.isNumber(childId)) {
			// TODO: return to error page
			return new ModelAndView("front.booking.index");
		}
		model.addAttribute("vaccines", createMapVaccineIdWithName());
		VaccineChildHistoryModel vaccineChildHistoryModel = new VaccineChildHistoryModel();
		vaccineChildHistoryModel.setChildId(Integer.valueOf(childId));

		ModelAndView mav = new ModelAndView("front.booking.add.history.vaccine", "vaccineChildHistory",
				vaccineChildHistoryModel);
		return mav;
	}

	/**
	 * Ajax init combo injected no.
	 *
	 * @param vaccineChildHistoryModel
	 *            the vaccine child history model
	 * @return the ajax response
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "ajax-get-injectedNo", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxInitComboInjectedNo(@RequestBody VaccineChildHistoryModel vaccineChildHistoryModel)
			throws Exception {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (vaccineChildHistoryModel.getChildId() == null || vaccineChildHistoryModel.getVaccineId() == null
				|| vaccineChildHistoryModel.getVaccineId().equals(-1)) {
			return builder.build();
		}
		VaccineModel vaccineModel = this.vaccineService.findById(vaccineChildHistoryModel.getVaccineId());
		Map<Integer, String> mapInjectedNo = new LinkedHashMap<>();
		if (vaccineModel != null) {
			for (int i = 1; i <= vaccineModel.getTotalInject(); i++) {
				mapInjectedNo.put(i, String.valueOf(i));
			}
		}

		builder.data(mapInjectedNo);
		return builder.build();
	}

	/**
	 * Submit add history vaccine.
	 *
	 * @param vaccineChildHistory
	 *            the vaccine child history
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/add-history-vaccine", method = RequestMethod.POST)
	public ModelAndView submitAddHistoryVaccine(
			@Valid @ModelAttribute("vaccineChildHistory") VaccineChildHistoryModel vaccineChildHistory,
			BindingResult result, ModelMap model) throws Exception {
		ModelAndView mav = new ModelAndView("front.booking.add.history.vaccine", "vaccineChildHistory",
				vaccineChildHistory);
		model.addAttribute("vaccines", createMapVaccineIdWithName());

		if (vaccineChildHistory.getVaccineId().equals(-1)) {
			result.rejectValue("vaccineId", "NotNull.vaccineChildHistory.vaccineId");
		}
		if (vaccineChildHistory.getInjectedNo() == null || vaccineChildHistory.getInjectedNo().equals(-1)) {
			result.rejectValue("injectedNo", "NotNull.vaccineChildHistory.injectedNo");
		}
		if (result.hasErrors()) {
			return mav;
		}
		// Check duplicate
		VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService.findByVaccineIdInjectedNo(
				vaccineChildHistory.getVaccineId(), vaccineChildHistory.getChildId(),
				vaccineChildHistory.getInjectedNo());
		if (vaccineChildHistoryModel != null) {
			model.addAttribute("isDuplicate", true);
			// this.addNotification(new
			// NotificationModel(NotificationType.ERROR,
			// this.getText("re011.msg.is.duplicate")));
			return mav;
		}
		Timestamp injectedDate = MssDateTimeUtil.convertStringToTimestamp(vaccineChildHistory.getInjectedDateStr(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		vaccineChildHistory.setInjectedDate(injectedDate);

		// Get hospital code from login user
		Integer hospitalId = this.getUser().getHospitalId();
		vaccineChildHistory.setLoginHospitalId(hospitalId);
		// Get vaccine hospital Id
		Integer vaccineHospitalId = this.vaccineHospitalService
				.findByHospitalIdVaccineId(hospitalId, vaccineChildHistory.getVaccineId()).getVaccineHospitalId();
		vaccineChildHistory.setVaccineHospitalId(vaccineHospitalId);

		this.vaccineChildHistoryService.save(vaccineChildHistory);
		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("general.msg.add.new.success")));
		return new ModelAndView(new RedirectView("add-history-vaccine?childId=" + vaccineChildHistory.getChildId()));
	}

	/**
	 * Delete vaccine child history.
	 *
	 * @param vaccineChildHistory
	 *            the vaccine child history
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/ajax-delete-vaccine-child-history", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse deleteVaccineChildHistory(@RequestBody VaccineChildHistoryModel vaccineChildHistory)
			throws Exception {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		Integer vaccineChildId = vaccineChildHistory.getVaccineChildId();
		if (vaccineChildId == null) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("general.msg.delete.not.success"));
			return builder.build();
		}
		VaccineChildHistoryModel vaccineChildHistoryModel = this.vaccineChildHistoryService.findById(vaccineChildId);
		vaccineChildHistoryModel.setActiveFlg(ActiveFlag.INACTIVE.toInt());
		this.vaccineChildHistoryService.save(vaccineChildHistoryModel);

		builder.status(HttpStatus.OK).message(this.getText("general.msg.delete.success"));
		return builder.build();
	}

	/**
	 * Change vaccine child history.
	 *
	 * @param vaccineChildId
	 *            the vaccine child id
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/change-history-vaccine", method = RequestMethod.GET)
	public ModelAndView changeVaccineChildHistory(@RequestParam("vaccineChildId") String vaccineChildId, ModelMap model)
			throws Exception {
		if (StringUtils.isBlank(vaccineChildId) || !NumberUtils.isNumber(vaccineChildId)) {
			// TODO: return to error page
			return new ModelAndView("front.booking.index");
		}
		VaccineChildHistoryModel vaccineChildHistory = createVaccineHistoryInfo(Integer.valueOf(vaccineChildId));
		model.addAttribute("vaccineChildHistory", vaccineChildHistory);
		model.addAttribute("vaccineName", createMapVaccineIdWithName().get(vaccineChildHistory.getVaccineId()));
		model.addAttribute("timesUsing", vaccineChildHistory.getInjectedNo());

		return new ModelAndView("front.booking.edit.history.vaccine", "vaccineChildHistory", vaccineChildHistory);
	}

	/**
	 * Creates the vaccine history info.
	 *
	 * @param vaccineChildId
	 *            the vaccine child id
	 * @return the vaccine child history model
	 * @throws Exception
	 *             the exception
	 */
	private VaccineChildHistoryModel createVaccineHistoryInfo(Integer vaccineChildId) throws Exception {
		VaccineChildHistoryModel childHistoryModel = this.vaccineChildHistoryService.findById(vaccineChildId);
		String injectedDateStr = MssDateTimeUtil.convertTimestampToString(childHistoryModel.getInjectedDate(),
				DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM_EXTEND);
		childHistoryModel.setInjectedDateStr(injectedDateStr);
		// Calcalate dayAge
		Date birthDate = MssDateTimeUtil.dateFromString(childHistoryModel.getDob(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD);
		Date injectDate = new Date(childHistoryModel.getInjectedDate().getTime());
		String dayAge = VaccineUtils.getDayAge(birthDate, injectDate, Locale.JAPANESE);
		childHistoryModel.setDayAge(dayAge);

		return childHistoryModel;
	}

	/**
	 * Submit change vaccine child history.
	 *
	 * @param vaccineChildHistory
	 *            the vaccine child history
	 * @param result
	 *            the result
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception
	 *             the exception
	 */
	@Secured({ UserRole.ROLE_FRONT_END_NAME })
	@RequestMapping(value = "/submit-change-history-vaccine", method = RequestMethod.POST)
	public ModelAndView submitChangeVaccineChildHistory(
			@Valid @ModelAttribute("vaccineChildHistory") VaccineChildHistoryModel vaccineChildHistory,
			BindingResult result, ModelMap model) throws Exception {
		VaccineChildHistoryModel childHistoryModel = createVaccineHistoryInfo(
				Integer.valueOf(vaccineChildHistory.getVaccineChildId()));
		// Get hospital code from login user
		Integer hospitalId = this.getUser().getHospitalId();
		vaccineChildHistory.setLoginHospitalId(hospitalId);
		// Get Vaccine_hospital
		Integer vaccineHospitalId = this.vaccineHospitalService
				.findByHospitalIdVaccineId(hospitalId, vaccineChildHistory.getVaccineId()).getVaccineHospitalId();
		vaccineChildHistory.setVaccineHospitalId(vaccineHospitalId);

		model.addAttribute("vaccineName", createMapVaccineIdWithName().get(childHistoryModel.getVaccineId()));
		model.addAttribute("timesUsing", childHistoryModel.getInjectedNo());

		ModelAndView mav = new ModelAndView("front.booking.edit.history.vaccine", "vaccineChildHistory",
				vaccineChildHistory);
		if (vaccineChildHistory.getVaccineId().equals(-1)) {
			result.rejectValue("vaccineId", "NotNull.vaccineChildHistory.vaccineId");
		}
		if (vaccineChildHistory.getInjectedNo() == null || vaccineChildHistory.getInjectedNo().equals(-1)) {
			result.rejectValue("injectedNo", "NotNull.vaccineChildHistory.injectedNo");
		}
		if (result.hasErrors()) {
			return mav;
		}
		// Check duplicate
		// VaccineChildHistoryModel vaccineChildHistoryModel =
		// this.vaccineChildHistoryService.findByVaccineIdInjectedNo(vaccineChildHistory.getVaccineId(),
		// vaccineChildHistory.getChildId(),
		// vaccineChildHistory.getInjectedNo());
		// if (vaccineChildHistoryModel != null) {
		//// model.addAttribute("isDuplicate", true);
		// this.addNotification(new NotificationModel(NotificationType.ERROR,
		// this.getText("re011.msg.is.duplicate")));
		// return new ModelAndView(new
		// RedirectView("change-history-vaccine?vaccineChildId=" +
		// vaccineChildHistory.getVaccineChildId()));
		// }

		Timestamp injectedDate = MssDateTimeUtil.convertStringToTimestamp(vaccineChildHistory.getInjectedDateStr(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		vaccineChildHistory.setInjectedDate(injectedDate);
		this.vaccineChildHistoryService.save(vaccineChildHistory);
		this.addNotification(
				new NotificationModel(NotificationType.SUCCESS, this.getText("general.msg.update.success")));
		return new ModelAndView(new RedirectView("add-history-vaccine?childId=" + vaccineChildHistory.getChildId()));
	}

	/**
	 * Creates the map vaccine id with name.
	 *
	 * @return the map
	 * @throws Exception
	 *             the exception
	 */
	private Map<Integer, String> createMapVaccineIdWithName() throws Exception {
		Map<Integer, String> map = new LinkedHashMap<Integer, String>();
		map.put(-1, this.getText("re011.label.select"));
		// List<VaccineModel> lstVaccineModel =
		// this.vaccineService.findVaccineByActiveFlg(ActiveFlag.ACTIVE.toInt());
		List<VaccineModel> lstVaccineModel = this.vaccineService
				.findVaccineByHospitalCode(this.getUser().getHospitalCode());
		if (CollectionUtils.isNotEmpty(lstVaccineModel)) {
			for (VaccineModel vaccineModel : lstVaccineModel) {
				map.put(vaccineModel.getVaccineId(), vaccineModel.getVaccineName());
			}
		}
		return map;
	}

	/**
	 * Ajax init vaccine child history.
	 *
	 * @param vaccineChildHistoryModel
	 *            the vaccine child history model
	 * @param session
	 *            the session
	 * @return the ajax response
	 * @throws Exception
	 *             the exception
	 */
	@RequestMapping(value = "/ajax-init-vaccine-child-history-list", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse ajaxInitVaccineChildHistory(@RequestBody VaccineChildHistoryModel vaccineChildHistoryModel,
													HttpSession session) throws Exception {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (vaccineChildHistoryModel.getChildId() == null) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("re011.msg.err.select.vaccine"));
			return builder.build();
		}
		List<VaccineChildHistoryModel> lstVaccineChildHistoryModel = this.vaccineChildHistoryService
				.findByChildId(vaccineChildHistoryModel.getChildId());
		for (int i = 0; i < lstVaccineChildHistoryModel.size(); i++) {
			VaccineChildHistoryModel childHistoryModel = lstVaccineChildHistoryModel.get(i);
			String injectedDateStr;
			if (childHistoryModel.getReservationId() == null) {
				injectedDateStr = MssDateTimeUtil.convertTimestampToString(childHistoryModel.getInjectedDate(),
						DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
			} else {
				injectedDateStr = MssDateTimeUtil.convertTimestampToString(childHistoryModel.getInjectedDate(),
						DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM_EXTEND);
			}
			childHistoryModel.setInjectedDateStr(injectedDateStr);
			// Calcalate dayAge
			Date birthDate = MssDateTimeUtil.dateFromString(childHistoryModel.getDob(),
					DateTimeFormat.DATE_FORMAT_YYYYMMDD);
			Date injectedDate = new Date(childHistoryModel.getInjectedDate().getTime());
			String dayAge = VaccineUtils.getDayAge(birthDate, injectedDate, MssContextHolder.getLocale());
			childHistoryModel.setDayAge(dayAge);
		}
		builder.status(HttpStatus.OK).data(lstVaccineChildHistoryModel);
		return builder.build();
	}

	@RequestMapping(value = "/logout", method = RequestMethod.GET)
	public ModelAndView logout(ModelMap model, HttpServletRequest request, HttpServletResponse response)
			throws Exception {
		String token = MssContextHolder.getTokenHospCode();

		CookieClearingLogoutHandler cookieClearingLogoutHandler = new CookieClearingLogoutHandler(
				AbstractRememberMeServices.SPRING_SECURITY_REMEMBER_ME_COOKIE_KEY);
		SecurityContextLogoutHandler securityContextLogoutHandler = new SecurityContextLogoutHandler();
		cookieClearingLogoutHandler.logout(request, response, null);
		securityContextLogoutHandler.logout(request, response, null);

		return new ModelAndView(new RedirectView("index?tokenHospCode=" + token));
	}
}