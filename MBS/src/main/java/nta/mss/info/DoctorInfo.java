package nta.mss.info;

/**
 * The Class DoctorInfo.
 * 
 * @author Dev-DuyenNT
 * @CrtDate Jul 29, 2014
 */
public class DoctorInfo {
	private String hospitalCode;
	private String hospitalName;
	private String departmentCode;
	private String departmentName;
	private String departmentType;
	private String departmentOrder;
	private String doctorName;
	private String doctorOrder;
	private String juniorFlg;
	private String kpi;
	
//	private Integer hospitalId;
//	private Integer deptId;
	
	public DoctorInfo() {
	}
	
	public String getHospitalCode() {
		return hospitalCode;
	}
	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}
	public String getHospitalName() {
		return hospitalName;
	}
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}
	public String getDepartmentCode() {
		return departmentCode;
	}
	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}
	public String getDepartmentName() {
		return departmentName;
	}
	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}
	public String getDepartmentType() {
		return departmentType;
	}
	public void setDepartmentType(String departmentType) {
		this.departmentType = departmentType;
	}
	public String getDepartmentOrder() {
		return departmentOrder;
	}
	public void setDepartmentOrder(String departmentOrder) {
		this.departmentOrder = departmentOrder;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getJuniorFlg() {
		return juniorFlg;
	}
	public void setJuniorFlg(String juniorFlg) {
		this.juniorFlg = juniorFlg;
	}
	public String getKpi() {
		return kpi;
	}
	public void setKpi(String kpi) {
		this.kpi = kpi;
	}
	/**
	 * @return the doctorOrder
	 */
	public String getDoctorOrder() {
		return doctorOrder;
	}
	/**
	 * @param doctorOrder the doctorOrder to set
	 */
	public void setDoctorOrder(String doctorOrder) {
		this.doctorOrder = doctorOrder;
	}

	@Override
	public String toString() {
		return "DoctorInfo [hospitalCode=" + hospitalCode + ", hospitalName="
				+ hospitalName + ", departmentCode=" + departmentCode
				+ ", departmentName=" + departmentName + ", departmentType="
				+ departmentType + ", departmentOrder=" + departmentOrder
				+ ", doctorName=" + doctorName + ", doctorOrder=" + doctorOrder
				+ ", juniorFlg=" + juniorFlg + ", kpi=" + kpi + "]";
	}
}
