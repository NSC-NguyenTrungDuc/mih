package nta.mss.model;

import java.util.List;

import nta.mss.entity.SysUser;

/**
 * The model class for sys user.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class SysUserModel extends BaseModel<SysUser> {

	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = -5037078490064972441L;

	private Integer sysUserId;
	private String loginId;
	private String loginName;
	private String loginPass;
	private String email;
	private SysRoleModel role;

	private List<String> roleIdList;
	private List<String> newPass;
	private Integer roleId;
	private Integer hospitalId;
	private String hospitalCode;
	private String code;
	/**
	 * Instantiates a new doctor model.
	 */
	public SysUserModel() {
		super(SysUser.class);
	}

	public Integer getSysUserId() {
		return sysUserId;
	}

	public void setSysUserId(Integer sysUserId) {
		this.sysUserId = sysUserId;
	}

	public String getLoginId() {
		return loginId;
	}

	public void setLoginId(String loginId) {
		this.loginId = loginId;
	}

	public String getLoginName() {
		return loginName;
	}

	public void setLoginName(String loginName) {
		this.loginName = loginName;
	}

	public String getLoginPass() {
		return loginPass;
	}

	public void setLoginPass(String loginPass) {
		this.loginPass = loginPass;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public SysRoleModel getRole() {
		return role;
	}

	public void setRole(SysRoleModel role) {
		this.role = role;
	}

	public List<String> getRoleIdList() {
		return roleIdList;
	}

	public void setRoleIdList(List<String> roleIdList) {
		this.roleIdList = roleIdList;
	}

	public List<String> getNewPass() {
		return newPass;
	}

	public void setNewPass(List<String> newPass) {
		this.newPass = newPass;
	}

	public Integer getRoleId() {
		return roleId;
	}

	public void setRoleId(Integer roleId) {
		this.roleId = roleId;
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	public String getHospitalCode() {
		return hospitalCode;
	}

	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}
	
}
