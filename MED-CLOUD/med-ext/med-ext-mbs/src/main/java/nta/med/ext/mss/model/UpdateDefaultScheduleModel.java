package nta.med.ext.mss.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class UpdateDefaultScheduleModel {
	@JsonProperty("hosp_code") //string
	private String hospCode;
	
	@JsonProperty("language") //string
	private String language;
	
	@JsonProperty("department_list")
	private List<DepartmentModel> deptList;

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

	public List<DepartmentModel> getDeptList() {
		return deptList;
	}

	public void setDeptList(List<DepartmentModel> deptList) {
		this.deptList = deptList;
	}

	@Override
	public String toString() {
		return "UpdateDefaultScheduleModel [hospCode=" + hospCode + ", language=" + language + ", deptList=" + deptList
				+ "]";
	}	
}

