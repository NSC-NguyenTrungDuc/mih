package nta.mss.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import nta.mss.model.SysRoleModel;

/**
 * The persistent class for the sys_role database table.
 * 
 */
@Entity
@Table(name = "sys_role")
public class SysRole extends BaseEntity<SysRoleModel> {
	private static final long serialVersionUID = 6900968709483784991L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "role_id", unique = true, nullable = false)
	private Integer roleId;

	@Column(name = "role_name", nullable = false, length = 128)
	private String roleName;

	@Column(name = "user_flg", nullable = false)
	private Integer userFlg;

	@Column(name = "reservation_flg", nullable = false)
	private Integer reservationFlg;

	@Column(name = "schedule_flg", nullable = false)
	private Integer scheduleFlg;

	@Column(name = "mail_sending_flg", nullable = false)
	private Integer mailSendingFlg;
	
	public SysRole() {
		super(SysRoleModel.class);
	}

	public Integer getRoleId() {
		return this.roleId;
	}

	public void setRoleId(Integer roleId) {
		this.roleId = roleId;
	}

	public Integer getMailSendingFlg() {
		return this.mailSendingFlg;
	}

	public void setMailSendingFlg(Integer mailSendingFlg) {
		this.mailSendingFlg = mailSendingFlg;
	}

	public Integer getReservationFlg() {
		return this.reservationFlg;
	}

	public void setReservationFlg(Integer reservationFlg) {
		this.reservationFlg = reservationFlg;
	}

	public String getRoleName() {
		return this.roleName;
	}

	public void setRoleName(String roleName) {
		this.roleName = roleName;
	}

	public Integer getScheduleFlg() {
		return this.scheduleFlg;
	}

	public void setScheduleFlg(Integer scheduleFlg) {
		this.scheduleFlg = scheduleFlg;
	}

	public Integer getUserFlg() {
		return this.userFlg;
	}

	public void setUserFlg(Integer userFlg) {
		this.userFlg = userFlg;
	}

}