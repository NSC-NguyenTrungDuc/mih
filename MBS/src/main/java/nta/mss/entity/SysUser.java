package nta.mss.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import nta.mss.model.SysUserModel;

/**
 * The persistent class for the doctor database table.
 * 
 */
@Entity
@Table(name = "sys_user")
public class SysUser extends BaseEntity<SysUserModel> {
	private static final long serialVersionUID = 8523365716603491099L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "sys_user_id", unique = true, nullable = false)
	private Integer sysUserId;

	@Column(name = "login_id", length = 128)
	private String loginId;

	@Column(name = "login_name", length = 128)
	private String loginName;

	@Column(name = "login_pass", length = 255)
	private String loginPass;

	@Column(name = "email", length = 128)
	private String email;
	
	@ManyToOne
	@JoinColumn(name = "role_id", nullable = false)
	private SysRole role;

	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id")
	private Hospital hospital;
	
	/**
	 * Instantiates a new doctor.
	 */
	public SysUser() {
		super(SysUserModel.class);
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

	public SysRole getRole() {
		return role;
	}

	public void setRole(SysRole role) {
		this.role = role;
	}

	public Hospital getHospital() {
		return hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}
}