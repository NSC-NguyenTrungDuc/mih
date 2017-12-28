package nta.mss.controller;

import java.util.List;

import nta.mss.entity.SysRole;
import nta.mss.info.AjaxResponse;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.UserRole;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.SysUserModel;
import nta.mss.model.UserChildModel;
import nta.mss.model.UserModel;
import nta.mss.security.WebSysUserDetails;
import nta.mss.security.WebUserDetails;
import nta.mss.service.ISysUserService;
import nta.mss.service.IUserChildService;
import nta.mss.service.IUserService;
import nta.mss.service.impl.SysUserService;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.security.access.annotation.Secured;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

/**
 * The Class AccountController.
 *
 * @author MinhLS
 * @crtDate 2015/01/21
 */

@Controller
@Scope("prototype")
@RequestMapping("account")
@NavigationConfig(leftMenuType = NavigationType.BACK_LEFT_MENU)
public class AccountController extends BaseController {
	
	private static final Logger LOG = LogManager.getLogger(AccountController.class);
	
	private ISysUserService sysUserService;
	
	private IUserService userService;
	
	private IUserChildService userChildService; 
	
	@Autowired
	public AccountController(SysUserService sysUserService, IUserService userService, IUserChildService userChildService){
		this.sysUserService = sysUserService;
		this.userService = userService;
		this.userChildService = userChildService;
	}
	
	public AccountController(){
		
	}

	/**
	 * Gets the sys user.
	 *
	 * @return the sys user
	 */
	public SysUserModel getSysUser() {
		if(SecurityContextHolder.getContext().getAuthentication()!=null){
	    	Object principal =  (WebSysUserDetails) SecurityContextHolder.getContext().getAuthentication().getPrincipal();
	    	if (principal instanceof WebSysUserDetails) {
				return ((WebSysUserDetails) principal).getSysUser();
			}
	    	}
			return null;
    }
	
	@NavigationConfig(group = {NavigationGroup.USER_MANAGEMENT})
	@RequestMapping(value = "/id-management", method = RequestMethod.GET)
	public ModelAndView viewIdManagemnent(ModelMap model) {
		if(MssContextHolder.isKcck()) {
			return new ModelAndView("front.page.not.found");
		}
		List<SysUserModel> lstUserModel = this.sysUserService.getAllSysUser(MssContextHolder.getHospitalId());
		model.addAttribute("users", lstUserModel);
		List<SysRole> lstRoles = this.sysUserService.getAllUserRoles();
		model.addAttribute("roles", lstRoles);
		return new ModelAndView("back.id.management","userRole", new SysUserModel());
	}
	
	@RequestMapping(value = "/ajax-update-role-for-user", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxUpdateRoleUser(@RequestBody SysUserModel sysUserModel) {
		LOG.info("[Start] ajaxUpdateRoleUser");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		sysUserModel.setHospitalId(MssContextHolder.getHospitalId());
		if(this.sysUserService.updateRoleForUser(sysUserModel)) {
			builder.status(HttpStatus.OK).message(this.getText("be092.msg.update.role.success"));
		}else {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be092.msg.update.role.fail"));
		}
		LOG.info("[End] ajaxUpdateRoleUser");
		return builder.build();
	}
	
	@RequestMapping(value = "/ajax-update-password-for-user", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxUpdatePasswordUser(@RequestBody SysUserModel sysUserModel) {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		sysUserModel.setHospitalId(MssContextHolder.getHospitalId());
		if(StringUtils.isEmpty(sysUserModel.getLoginPass().trim())) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be092.msg.update.input.required"));
		}else if(sysUserModel.getLoginPass().trim().length() < 6) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be092.msg.length.pass.not.enough"));
		}else if(this.sysUserService.updatePasswordForUser(sysUserModel)) {
			builder.status(HttpStatus.OK).message(this.getText("be092.msg.update.pass.success"));
		}else {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be092.msg.update.pass.fail"));
		}
		return builder.build();
	}
	
	@RequestMapping(value = "/ajax-delete-user", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxDeleteUser(@RequestBody SysUserModel sysUserModel) {
		LOG.info("[Start] ajaxDeleteUser");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		sysUserModel.setHospitalId(MssContextHolder.getHospitalId());
		if(this.sysUserService.deleteUser(sysUserModel)) {
			builder.status(HttpStatus.OK).message(this.getText("be092.msg.delete.success"));
		}else {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be092.msg.delete.fail"));
		}
		LOG.info("[End] ajaxDeleteUser");
		return builder.build();
	}
	
	@RequestMapping(value = "/ajax-add-new-user", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxAddNewUser(@RequestBody SysUserModel sysUserModel) throws Exception{
		LOG.info("[Start] ajaxAddNewUser");
		LOG.debug("[User access] UserId = " + getSysUser().getLoginId());
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if(sysUserModel.getLoginId().isEmpty() || sysUserModel.getLoginPass().isEmpty()) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be092.msg.add.required"));
			return builder.build();
		}
		if(sysUserModel.getLoginPass().length() < 6) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be092.msg.length.pass.not.enough"));
			return builder.build();
		}
		sysUserModel.setHospitalId(MssContextHolder.getHospitalId());
		if(!this.sysUserService.addNewUser(sysUserModel)) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be092.msg.add.loginId.existed"));
		}else {
			builder.status(HttpStatus.OK).message(this.getText("be092.msg.add.success"));
		}
		LOG.info("[End] ajaxAddNewUser");
		return builder.build();
	}
	
	/**
	 * Account manage.
	 *
	 * @param model the model
	 * @return the model and view
	 * @throws Exception the exception
	 */
	@Secured({UserRole.ROLE_BACK_END_NAME})
	@NavigationConfig(group = {NavigationGroup.ACCOUNT_MANAGEMENT})
	@RequestMapping(value = "/account-manage", method = {RequestMethod.GET})
	public ModelAndView accountManage(ModelMap model) throws Exception {
		return new ModelAndView("back.account.manage", "user", new UserModel()); 
	}

	/**
	 * Ajax search user model.
	 *
	 * @param userModel the user model
	 * @return the ajax response
	 * @throws Exception the exception
	 */
	@Secured({UserRole.ROLE_BACK_END_NAME})
	@NavigationConfig(group = {NavigationGroup.ACCOUNT_MANAGEMENT})
	@RequestMapping(value = "/ajax-search-user", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxSearchUserModel(@RequestBody UserModel userModel) throws Exception {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		userModel.setHospitalId(MssContextHolder.getHospitalId());
		List<UserModel> lstUserModel = this.userService.findByCondition(userModel);
		
		builder.status(HttpStatus.OK).data(lstUserModel);
		return builder.build();
	}
	
	/**
	 * Ajax delete account.
	 *
	 * @param user the user
	 * @return the ajax response
	 */
	@Secured({UserRole.ROLE_BACK_END_NAME})
	@NavigationConfig(group = {NavigationGroup.ACCOUNT_MANAGEMENT})
	@RequestMapping(value = "/ajax-delete-account", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxDeleteAccount(@RequestBody UserModel user) throws Exception {
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		if (user.getUserId() == null) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("general.msg.delete.not.success"));
			return builder.build();
		}
		
		// if accout exist child. can not delete
		List<UserChildModel> lstUserChildModel = this.userChildService.findUserChildByActiveFlg(user.getUserId(), ActiveFlag.ACTIVE.toInt());
		if (CollectionUtils.isNotEmpty(lstUserChildModel)) {
			builder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(getText("be104.error.delete.account"));
			return builder.build();
		}
		
		UserModel userModel = this.userService.getUser(user.getUserId());
		this.userService.deleteUser(userModel);
		
		builder.status(HttpStatus.OK).message(getText("general.msg.delete.success"));
		return builder.build();
	}
	
	public UserModel getUser() {
		if (SecurityContextHolder.getContext().getAuthentication() != null) {
			Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();
			if (principal instanceof WebUserDetails) {
				return ((WebUserDetails) principal).getUser();
			}
		}
		return null;
	}
	
}
