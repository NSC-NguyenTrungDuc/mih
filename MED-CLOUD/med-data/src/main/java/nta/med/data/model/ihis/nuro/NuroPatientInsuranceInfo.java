package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class NuroPatientInsuranceInfo {
    private String status;
    private String insurCode;
    private String insurName;
    private Date lastCheckDate;
    private Date startDate;
    private String patientCode;
    private String budamjaPatientCode;
    private String insurJiyeok;
	   
	public NuroPatientInsuranceInfo(String status, String insurCode,
			String insurName, Date lastCheckDate, Date startDate,
			String patientCode, String budamjaPatientCode, String insurJiyeok) {
		super();
		this.status = status;
		this.insurCode = insurCode;
		this.insurName = insurName;
		this.lastCheckDate = lastCheckDate;
		this.startDate = startDate;
		this.patientCode = patientCode;
		this.budamjaPatientCode = budamjaPatientCode;
		this.insurJiyeok = insurJiyeok;
	}
	
	public Date getLastCheckDate() {
		return lastCheckDate;
	}

	public void setLastCheckDate(Date lastCheckDate) {
		this.lastCheckDate = lastCheckDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
	public String getInsurCode() {
		return insurCode;
	}
	public void setInsurCode(String insurCode) {
		this.insurCode = insurCode;
	}
	public String getInsurName() {
		return insurName;
	}
	public void setInsurName(String insurName) {
		this.insurName = insurName;
	}
	
	public Date getStartDate() {
		return startDate;
	}

	public String getPatientCode() {
		return patientCode;
	}
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public String getBudamjaPatientCode() {
		return budamjaPatientCode;
	}
	public void setBudamjaPatientCode(String budamjaPatientCode) {
		this.budamjaPatientCode = budamjaPatientCode;
	}
	public String getInsurJiyeok() {
		return insurJiyeok;
	}
	public void setInsurJiyeok(String insurJiyeok) {
		this.insurJiyeok = insurJiyeok;
	}
    
}
