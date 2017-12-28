package nta.kcck.service;

import nta.kcck.model.KcckSysUserModel;
import nta.mss.model.SysUserModel;

public interface IKcckSysUserService {
	public SysUserModel getUserFromKcck(KcckSysUserModel sysUserModel);
}
