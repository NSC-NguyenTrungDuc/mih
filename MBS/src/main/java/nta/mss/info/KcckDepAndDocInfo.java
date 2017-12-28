package nta.mss.info;

public class KcckDepAndDocInfo {
	/** The dept id. */
	private Integer deptId;           
	
	/** The doctor id. */
	private Integer doctorId;

	public Integer getDeptId() {
		return deptId;
	}

	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}

	public Integer getDoctorId() {
		return doctorId;
	}

	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}

	public KcckDepAndDocInfo(Integer deptId, Integer doctorId) {
		super();
		this.deptId = deptId;
		this.doctorId = doctorId;
	}         
	
	
}
