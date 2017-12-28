package nta.mss.service;

import java.util.List;

import nta.kcck.model.KcckSysUserModel;
import nta.mss.entity.SysRole;
import nta.mss.model.SysUserModel;

/**
 * The Interface IDoctorService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public interface ISysUserService {
	/**
	 * Gets the doctor by doctor id.
	 * 
	 * @param doctId
	 *            the doct id
	 * @return the doctor by doctor id
	 */
	SysUserModel getSysUser(Integer sysUserId);
	SysUserModel getSysUserByLoginId(String loginId, Integer hospitalId);
	SysUserModel getSysUserByEmail(String email, Integer hospitalId);
	List<SysUserModel> getAllSysUser(Integer hospitalId);
	List<SysRole> getAllUserRoles();
	boolean updateRoleForUser(SysUserModel sysUserModel);
	boolean updatePasswordForUser(SysUserModel sysUserModel);
	boolean deleteUser(SysUserModel sysUserModel);
	boolean addNewUser(SysUserModel sysUserModel) throws Exception;
	public SysUserModel getUserFromKcck(KcckSysUserModel sysUserModel);
}
