package nta.kcck.service.impl;

import nta.kcck.model.KcckSysUserModel;
import nta.kcck.service.IKcckSysUserService;
import nta.mss.entity.SysRole;
import nta.mss.model.SysRoleModel;
import nta.mss.model.SysUserModel;
import nta.mss.repository.SysRoleRepository;

public class KcckSysUserService implements IKcckSysUserService{
	KcckApiService kcckApiService = new KcckApiService();
	SysRoleRepository sysRoleReposity ;
	@Override
	public SysUserModel getUserFromKcck(KcckSysUserModel sysUserModel) {
		SysUserModel sysUser = new SysUserModel();
		KcckSysUserModel responseSysUser = kcckApiService.getKcckSysUserInfo(sysUserModel);
		if(responseSysUser != null) {
			sysUser.setLoginId(responseSysUser.getUser_id());
			sysUser.setLoginName(responseSysUser.getUser_name());
			sysUser.setCode(responseSysUser.getStatus());
			if(responseSysUser.getStatus().equals("00")) {
				SysRole sysRole = sysRoleReposity.findByRoleId(1).get(0);
				SysRoleModel sysRoleModel = new SysRoleModel();
				sysRoleModel.setRoleId(sysRole.getRoleId());
				sysRoleModel.setRoleName(sysRole.getRoleName());
				sysRoleModel.setUserFlg(sysRole.getUserFlg());
				sysRoleModel.setReservationFlg(sysRole.getReservationFlg());
				sysRoleModel.setScheduleFlg(sysRole.getScheduleFlg());
				sysRoleModel.setMailSendingFlg(sysRole.getMailSendingFlg());
				sysUser.setRole(sysRoleModel);
				sysUser.setLoginPass(sysUserModel.getPassword());
			}
		}
		return sysUser;
	}

}
