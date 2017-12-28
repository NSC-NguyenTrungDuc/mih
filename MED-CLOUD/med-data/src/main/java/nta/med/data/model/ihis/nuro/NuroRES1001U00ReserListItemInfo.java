package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroRES1001U00ReserListItemInfo {
	private Timestamp comingDate;
	private String examPreTime;
	private String departmentName;
	private String doctorName;
	
	public NuroRES1001U00ReserListItemInfo(Timestamp comingDate,
			String examPreTime, String departmentName, String doctorName) {
		this.comingDate = comingDate;
		this.examPreTime = examPreTime;
		this.departmentName = departmentName;
		this.doctorName = doctorName;
	}

	public Timestamp getComingDate() {
		return comingDate;
	}

	public void setComingDate(Timestamp comingDate) {
		this.comingDate = comingDate;
	}

	public String getExamPreTime() {
		return examPreTime;
	}

	public void setExamPreTime(String examPreTime) {
		this.examPreTime = examPreTime;
	}

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
}
