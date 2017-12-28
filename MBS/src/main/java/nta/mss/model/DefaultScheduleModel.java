package nta.mss.model;

import java.io.Serializable;

public class DefaultScheduleModel implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = -4540131431325503098L;
	
	private Integer deptId;
	private String deptCode;
	private Integer defaultTimeSlot;
	
	public Integer getDeptId() {
		return deptId;
	}
	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}
	public String getDeptCode() {
		return deptCode;
	}
	public void setDeptCode(String deptCode) {
		this.deptCode = deptCode;
	}
	public Integer getDefaultTimeSlot() {
		return defaultTimeSlot;
	}
	public void setDefaultTimeSlot(Integer defaultTimeSlot) {
		this.defaultTimeSlot = defaultTimeSlot;
	}
	@Override
	public String toString() {
		return "DefaultScheduleModel [deptId=" + deptId + ", deptCode=" + deptCode + ", defaultTimeSlot="
				+ defaultTimeSlot + "]";
	}
	
	
}
