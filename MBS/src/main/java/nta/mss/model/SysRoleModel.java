package nta.mss.model;

import nta.mss.entity.SysRole;

/**
 * SysRoleModel.java
 *
 * @author DinhNX
 * @CrtDate Aug 12, 2014
 *
 */
public class SysRoleModel extends BaseModel<SysRole> {
	private static final long serialVersionUID = 3173808247698344147L;
	private Integer roleId;
	private String roleName;
	private Integer userFlg;
	private Integer reservationFlg;
	private Integer scheduleFlg;
	private Integer mailSendingFlg;

	public SysRoleModel() {
		super(SysRole.class);
	}
	
	public Integer getRoleId() {
		return roleId;
	}
	
	public void setRoleId(Integer roleId) {
		this.roleId = roleId;
	}
	
	public String getRoleName() {
		return roleName;
	}
	
	public void setRoleName(String roleName) {
		this.roleName = roleName;
	}
	
	public Integer getUserFlg() {
		return userFlg;
	}
	
	public void setUserFlg(Integer userFlg) {
		this.userFlg = userFlg;
	}
	
	public Integer getReservationFlg() {
		return reservationFlg;
	}
	
	public void setReservationFlg(Integer reservationFlg) {
		this.reservationFlg = reservationFlg;
	}
	public Integer getScheduleFlg() {
		return scheduleFlg;
	}
	
	public void setScheduleFlg(Integer scheduleFlg) {
		this.scheduleFlg = scheduleFlg;
	}
	
	public Integer getMailSendingFlg() {
		return mailSendingFlg;
	}
	
	public void setMailSendingFlg(Integer mailSendingFlg) {
		this.mailSendingFlg = mailSendingFlg;
	}
}
