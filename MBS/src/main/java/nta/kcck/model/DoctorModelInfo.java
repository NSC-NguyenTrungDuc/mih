package nta.kcck.model;

/**
 * Created by admin on 4/7/2016.
 */
public class DoctorModelInfo {
    private String doctor_code;
    private String doctor_name;
    private String doctor_grade;
    private String department_id;
    private String doctor_id;
	private String hosp_code;
	private String department_code;
	public String getDoctor_code() {
		return doctor_code;
	}
	public void setDoctor_code(String doctor_code) {
		this.doctor_code = doctor_code;
	}
	public String getDoctor_name() {
		return doctor_name;
	}
	public void setDoctor_name(String doctor_name) {
		this.doctor_name = doctor_name;
	}
	public String getDoctor_grade() {
		return doctor_grade;
	}
	public void setDoctor_grade(String doctor_grade) {
		this.doctor_grade = doctor_grade;
	}
	public String getDepartment_id() {
		return department_id;
	}
	public void setDepartment_id(String department_id) {
		this.department_id = department_id;
	}
	public String getDoctor_id() {
		return doctor_id;
	}
	public void setDoctor_id(String doctor_id) {
		this.doctor_id = doctor_id;
	}

	public String getHosp_code() {
		return hosp_code;
	}

	public void setHosp_code(String hosp_code) {
		this.hosp_code = hosp_code;
	}

	public String getDepartment_code() {
		return department_code;
	}

	public void setDepartment_code(String department_code) {
		this.department_code = department_code;
	}
}
