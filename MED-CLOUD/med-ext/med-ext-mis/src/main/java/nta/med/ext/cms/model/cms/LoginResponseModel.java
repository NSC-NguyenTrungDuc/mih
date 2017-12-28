package nta.med.ext.cms.model.cms;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class LoginResponseModel {
	@JsonProperty("token")
	private String token;

	@JsonProperty("full_name")
	private String fullName;

	@JsonProperty("department_list")
	private List<DepartmentModel> departmentList;

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public String getFullName() {
		return fullName;
	}

	public void setFullName(String fullName) {
		this.fullName = fullName;
	}

	public List<DepartmentModel> getDepartmentList() {
		return departmentList;
	}

	public void setDepartmentList(List<DepartmentModel> departmentList) {
		this.departmentList = departmentList;
	}

}
