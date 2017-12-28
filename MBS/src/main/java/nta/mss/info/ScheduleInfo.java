package nta.mss.info;

import java.io.Serializable;

/**
 * The Class ScheduleInfo.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class ScheduleInfo implements Serializable {

	private static final long serialVersionUID = 1L;
	private Integer deptId;
	private String deptName;

	public Integer getDeptId() {
		return deptId;
	}

	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}

	public String getDeptName() {
		return deptName;
	}

	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}
}
