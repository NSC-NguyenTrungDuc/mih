package nta.mss.security;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.UserRole;
import nta.mss.model.SysRoleModel;
import nta.mss.model.SysUserModel;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

public class WebSysUserDetails implements UserDetails {
	private static final long serialVersionUID = 4086373038080828255L;
	private SysUserModel sysUser;
	private List<UserRole> roles = new ArrayList<UserRole>();
	
	public WebSysUserDetails(SysUserModel sysUser){
		this.sysUser = sysUser;
		SysRoleModel roleModel = sysUser.getRole();
		if (ActiveFlag.ACTIVE.toInt().equals(roleModel.getUserFlg())) {
			roles.add(UserRole.ROLE_USER);
		}
		if (ActiveFlag.ACTIVE.toInt().equals(roleModel.getReservationFlg())) {
			roles.add(UserRole.ROLE_RESERVATION);
		}
		if (ActiveFlag.ACTIVE.toInt().equals(roleModel.getScheduleFlg())) {
			roles.add(UserRole.ROLE_SCHEDULE);
		}
		if (ActiveFlag.ACTIVE.toInt().equals(roleModel.getMailSendingFlg())) {
			roles.add(UserRole.ROLE_MAIL_SENDING);
		}
		roles.add(UserRole.ROLE_BACK_END);
	}

	@Override
	public Collection<? extends GrantedAuthority> getAuthorities() {
		ArrayList<GrantedAuthority> authorities = new ArrayList<GrantedAuthority>();
		for (UserRole role : roles) {
			authorities.add(new SimpleGrantedAuthority(role.name()));
		}
		return authorities;
	}

	@Override
	public String getPassword() {
		return this.sysUser.getLoginPass();
	}

	@Override
	public String getUsername() {
		return this.sysUser.getLoginId();
	}

	@Override
	public boolean isAccountNonExpired() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean isAccountNonLocked() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean isCredentialsNonExpired() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean isEnabled() {
		// TODO Auto-generated method stub
		return true;
	}

	public SysUserModel getSysUser() {
		return sysUser;
	}

	public void setSysUser(SysUserModel sysUser) {
		this.sysUser = sysUser;
	}
}
