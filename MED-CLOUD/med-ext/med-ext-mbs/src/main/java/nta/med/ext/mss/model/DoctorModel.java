package nta.med.ext.mss.model;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author dainguyen.
 */
public class DoctorModel {
	
	@JsonProperty("doctor_code")
    private String doctorCode;
    
    @JsonProperty("doctor_name")
    private String doctorName;
    
    @JsonProperty("doctor_grade")
    private String doctorGrade;
    
    @JsonProperty("department_id")
    private String departmentId;
    
    @JsonProperty("doctor_id")
    private String doctorId;

	@JsonProperty("hosp_code")
	private String hospCode;

	@JsonProperty("department_code")
	private String departmentCode;
    
    public DoctorModel() {
		super();
	}

	public DoctorModel(String doctorCode, String doctorName, String doctorGrade, String departmentId, String doctorId) {
		super();
		this.doctorCode = doctorCode;
		this.doctorName = doctorName;
		this.doctorGrade = doctorGrade;
		this.departmentId = departmentId;
		this.doctorId = doctorId;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getDoctorGrade() {
		return doctorGrade;
	}

	public void setDoctorGrade(String doctorGrade) {
		this.doctorGrade = doctorGrade;
	}

	public String getDepartmentId() {
		return departmentId;
	}

	public void setDepartmentId(String departmentId) {
		this.departmentId = departmentId;
	}

	public String getDoctorId() {
		return doctorId;
	}

	public void setDoctorId(String doctorId) {
		this.doctorId = doctorId;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}
}
