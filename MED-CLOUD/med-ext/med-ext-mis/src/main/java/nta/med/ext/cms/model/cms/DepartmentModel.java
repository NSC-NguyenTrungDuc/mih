package nta.med.ext.cms.model.cms;

import com.fasterxml.jackson.annotation.JsonProperty;

public class DepartmentModel {

	@JsonProperty("department_code")
	private String departmentCode;

	@JsonProperty("department_name")
	private String departmentName;
	
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
	
}
