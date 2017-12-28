package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroRES0102U00GridDoctorInfo {
	private String doctor;
	private Timestamp startDate;
	private Timestamp endDate; 
	private String sayu;
	public NuroRES0102U00GridDoctorInfo(String doctor, Timestamp startDate,
			Timestamp endDate, String sayu) {
		super();
		this.doctor = doctor;
		this.startDate = startDate;
		this.endDate = endDate;
		this.sayu = sayu;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public Timestamp getStartDate() {
		return startDate;
	}
	public void setStartDate(Timestamp startDate) {
		this.startDate = startDate;
	}
	public Timestamp getEndDate() {
		return endDate;
	}
	public void setEndDate(Timestamp endDate) {
		this.endDate = endDate;
	}
	public String getSayu() {
		return sayu;
	}
	public void setSayu(String sayu) {
		this.sayu = sayu;
	}
}
