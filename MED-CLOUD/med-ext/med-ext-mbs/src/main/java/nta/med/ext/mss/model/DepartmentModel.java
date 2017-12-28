package nta.med.ext.mss.model;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class DepartmentModel {
    
	@JsonProperty("department_code")
	private String departmentCode;
	
	@JsonProperty("department_name")
    private String departmentName;
	
	@JsonProperty("department_id")
	private String departmentId;
    
	@JsonProperty("avg_time")
	private String avgTime;
	
    public DepartmentModel() {
		super();
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

	public String getDepartmentId() {
		return departmentId;
	}

	public void setDepartmentId(String departmentId) {
		this.departmentId = departmentId;
	}

	public String getAvgTime() {
		return avgTime;
	}

	public void setAvgTime(String avgTime) {
		this.avgTime = avgTime;
	}
	
	
}
