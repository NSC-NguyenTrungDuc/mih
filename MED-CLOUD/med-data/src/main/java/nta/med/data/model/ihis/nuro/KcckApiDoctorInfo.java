package nta.med.data.model.ihis.nuro;

import java.math.BigInteger;

public class KcckApiDoctorInfo {
	
	private String doctor;
	private String doctorGrade;
	private String doctorName;
	private BigInteger departmentId;
	private BigInteger doctorId;
	
	public KcckApiDoctorInfo(String doctor, String doctorGrade, String doctorName, BigInteger departmentId, BigInteger doctorId) {
		super();
		this.doctor = doctor;
		this.doctorGrade = doctorGrade;
		this.doctorName = doctorName;
		this.departmentId = departmentId;
		this.doctorId = doctorId;
	}
	
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctorGrade() {
		return doctorGrade;
	}
	public void setDoctorGrade(String doctorGrade) {
		this.doctorGrade = doctorGrade;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public BigInteger getDepartmentId() {
		return departmentId;
	}

	public void setDepartmentId(BigInteger departmentId) {
		this.departmentId = departmentId;
	}

	public BigInteger getDoctorId() {
		return doctorId;
	}

	public void setDoctorId(BigInteger doctorId) {
		this.doctorId = doctorId;
	}
}
