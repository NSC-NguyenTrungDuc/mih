package nta.mss.model;

import org.hibernate.validator.constraints.NotBlank;

import nta.mss.entity.MailListDetail;
import nta.mss.validation.Email;

public class CrmMailListDetailModel extends BaseModel<MailListDetail> {
	
	private static final long serialVersionUID = 1L;

	public CrmMailListDetailModel() {
		super(MailListDetail.class);
	}
	
	@NotBlank
	@Email
	private String patientEmail;
	@NotBlank
	private String patientName;
	private String hospCode;
	private String diseaseName;
	private String statusOfDisease;
	private String lastestGoHospital;
	private Integer patientAge;
	private String patientSex;
	private Boolean isSentEmail;

	public String getPatientEmail() {
		return patientEmail;
	}
	public void setPatientEmail(String patientEmail) {
		this.patientEmail = patientEmail;
	}
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getDiseaseName() {
		return diseaseName;
	}
	public void setDiseaseName(String diseaseName) {
		this.diseaseName = diseaseName;
	}
	public String getStatusOfDisease() {
		return statusOfDisease;
	}
	public void setStatusOfDisease(String statusOfDisease) {
		this.statusOfDisease = statusOfDisease;
	}
	public String getLastestGoHospital() {
		return lastestGoHospital;
	}
	public void setLastestGoHospital(String lastestGoHospital) {
		this.lastestGoHospital = lastestGoHospital;
	}
	
	public Integer getPatientAge() {
		return patientAge;
	}
	public void setPatientAge(Integer patientAge) {
		this.patientAge = patientAge;
	}
	public String getPatientSex() {
		return patientSex;
	}
	public void setPatientSex(String patientSex) {
		this.patientSex = patientSex;
	}
	public Boolean getIsSentEmail() {
		return isSentEmail;
	}
	public void setIsSentEmail(Boolean isSentEmail) {
		this.isSentEmail = isSentEmail;
	}
}
