package nta.kcck.model;

import java.util.List;

public class KcckDefaultScheduleModel {
	private String hosp_code;
	private String language;
	private List<KcckDepartmentModel> department_list;
	
	public String getHosp_code() {
		return hosp_code;
	}
	public void setHosp_code(String hosp_code) {
		this.hosp_code = hosp_code;
	}
	public String getLanguage() {
		return language;
	}
	public void setLanguage(String language) {
		this.language = language;
	}
	public List<KcckDepartmentModel> getDepartment_list() {
		return department_list;
	}
	public void setDepartment_list(List<KcckDepartmentModel> department_list) {
		this.department_list = department_list;
	}
	
}
