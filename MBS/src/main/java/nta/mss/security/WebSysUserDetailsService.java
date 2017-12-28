package nta.mss.security;

import nta.kcck.model.KcckSysUserModel;
import nta.kcck.service.IKcckSysUserService;
import nta.mss.custom.authentication.UsernamePasswordAuthenticationFilter;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.model.SysUserModel;
import nta.mss.service.ISysUserService;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataAccessException;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.util.StringUtils;


/**
 * The Class WebSysUserDetailsService.
 * 
 * @author DinhNX
 * @CrtDate Aug 08, 2014
 */
public class WebSysUserDetailsService implements UserDetailsService, InitializingBean {
	private static Logger LOG = LogManager.getLogger(WebSysUserDetailsService.class);
	@Autowired
	private ISysUserService sysUserService;
	
	
	
	public String ROLE_USER = "ROLE_USER";
	
	/**
	 * Load user by loginId or email
	 * 
	 * @param loginId the loginId or email
	 * @return the user details
	 */
	public synchronized UserDetails loadUserByUsername(String loginId) throws UsernameNotFoundException, DataAccessException {
		String hospitalId = UsernamePasswordAuthenticationFilter.localMssContext.get().getHospitalId();
		String password = EncryptionUtils.cryptWithMD5(UsernamePasswordAuthenticationFilter.localMssContext.get().getPassword());
		if(StringUtils.isEmpty(hospitalId)){
			LOG.debug("Can't get user with hospital id is empty, loginId: " + loginId);
			throw new UsernameNotFoundException("Can't get user with hospital id is empty, loginId: " + loginId);
		}
		if(StringUtils.isEmpty(password)){
			LOG.debug("User doesn't input password: " + loginId);
			throw new UsernameNotFoundException("Can't get user with password is empty, loginId: " + loginId);
		}
		SysUserModel sysUser = null;
		LOG.debug("is kcck: " + String.valueOf(MssContextHolder.isKcck()));
		if(MssContextHolder.isKcck()){
			KcckSysUserModel sysUserModel = new KcckSysUserModel();
			sysUserModel.setUser_id(loginId);
			sysUserModel.setHosp_code(MssContextHolder.getHospCode());
			sysUserModel.setPassword(password);
			sysUser = sysUserService.getUserFromKcck(sysUserModel);
			sysUser.setHospitalCode(MssContextHolder.getHospCode());
		} else {
			Integer hospId = Integer.parseInt(hospitalId);
			sysUser = sysUserService.getSysUserByLoginId(loginId, hospId);
			if (sysUser == null) {
				sysUser = sysUserService.getSysUserByEmail(loginId, hospId);
			}
		}
		if (sysUser == null || (sysUser.getCode() != null && sysUser.getCode().equals("30"))) {
			LOG.debug("Can't get user with user name = " + loginId);
			throw new UsernameNotFoundException("Can't get user with user name = " + loginId);
		}
		return new WebSysUserDetails(sysUser);
	}

	@Override
	public void afterPropertiesSet() throws Exception {
		// TODO Auto-generated method stub
		
	}
	
}
