package nta.mss.security;

import javax.servlet.http.HttpServletRequest;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataAccessException;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.util.StringUtils;
import org.springframework.web.context.request.RequestContextHolder;
import org.springframework.web.context.request.ServletRequestAttributes;

import nta.mss.custom.authentication.UsernamePasswordAuthenticationFilter;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.model.UserModel;
import nta.mss.service.IUserService;
import nta.phr.model.PhrLoginModel;
import nta.phr.model.SocialAccountModel;
import nta.phr.service.impl.PhrApiService;

/**
 * The Class WebUserDetailsService.
 *
 * @author MinhLS
 * @crtDate 2015/01/20
 */
public class WebUserDetailsService implements UserDetailsService, InitializingBean {
	private static Logger LOG = LogManager.getLogger(WebUserDetailsService.class);

	@Autowired
	private IUserService userService;
	PhrApiService phrApiService = new PhrApiService();

	public synchronized UserDetails loadUserByUsername(String loginId) throws UsernameNotFoundException, DataAccessException {

		String hospitalId = UsernamePasswordAuthenticationFilter.localMssContext.get().getHospitalId();
		if(StringUtils.isEmpty(hospitalId)){
			LOG.debug("Can't get user with hospital id is empty, loginId: " + loginId);
			throw new UsernameNotFoundException("Can't get user with hospital id is empty, loginId: " + loginId);
		}
		Integer hospId = Integer.parseInt(hospitalId);
//		UserModel user = userService.getActiveUserByLoginId(loginId, hospId);
		HttpServletRequest request = ((ServletRequestAttributes) RequestContextHolder.getRequestAttributes()).getRequest();
		UserModel user = null;
		boolean loginSuccess = false;
		if(request.getParameter("isLoginFaceBook") != null &&
				request.getParameter("isLoginFaceBook").equals("true"))
		{

			SocialAccountModel socialAccountModel = new SocialAccountModel();
			socialAccountModel.setAccess_token(request.getParameter("accessToken"));

			SocialAccountModel model = phrApiService.loginFaceBook(socialAccountModel);
			if(model != null && model.getEmail() != null)
			{
				user = userService.getActiveUserByLoginId(MssContextHolder.getFacebookId(), hospId);
				if(user !=null)
				{
					user.setPasswordConfirm(request.getParameter("j_password"));
					user.setToken(model.getToken());
					MssContextHolder.setUserToken(model.getToken());
					MssContextHolder.setMasterProfile(model.getMaster_profile_id());
					user.setMasterProfileId(model.getMaster_profile_id());
					loginSuccess = true;
				}
			}

		} else {
			PhrLoginModel phrLoginModel = new PhrLoginModel();
			phrLoginModel.setEmail(loginId);
			// Get password from httpServletRequest
			phrLoginModel.setPassword(request.getParameter("j_password"));
			PhrLoginModel phrLoginModelRes = phrApiService.login(phrLoginModel);
			if(phrLoginModelRes != null && loginId.equalsIgnoreCase(phrLoginModelRes.getEmail())) {
				user = userService.getActiveUserByEmailAndLoginId(loginId, hospId);
				if(user != null) {
					user.setToken(phrLoginModelRes.getToken());
					MssContextHolder.setUserToken(phrLoginModelRes.getToken());
					MssContextHolder.setMasterProfile(phrLoginModelRes.getMaster_profile_id());
					user.setMasterProfileId(phrLoginModelRes.getMaster_profile_id());
					user.setPasswordConfirm(request.getParameter("j_password"));
					loginSuccess = true;
				}
			}
		}





		if (!loginSuccess) {
			LOG.debug("Can't get user with loginId: " + loginId);
			throw new UsernameNotFoundException("Can't get user with loginId: " + loginId);
		}
		
		/*UserModel user = new UserModel();
		user.setUserId(new Integer(phrLoginModelRes.getId().toString()));
		user.setEmail(loginId);
		user.setPassword(phrLoginModelRes.getPassword());
		user.setToken(phrLoginModelRes.getToken());
		user.setMasterProfileId(phrLoginModelRes.getMaster_profile_id());*/

		return new WebUserDetails(user);
	}

	@Override
	public void afterPropertiesSet() throws Exception {
		// TODO Auto-generated method stub
	}

}
