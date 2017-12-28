package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class OUT0106U00PatientCommentItemInfo {
	private String patientInfo;
    private String patientInfoName;
    private Date startDate;
    private Date endDate;
    private String comments;
    private String bunho;
    private String contKey;
	public OUT0106U00PatientCommentItemInfo(String patientInfo,
			String patientInfoName, Date startDate, Date endDate,
			String comments, String bunho, String contKey) {
		super();
		this.patientInfo = patientInfo;
		this.patientInfoName = patientInfoName;
		this.startDate = startDate;
		this.endDate = endDate;
		this.comments = comments;
		this.bunho = bunho;
		this.contKey = contKey;
	}
	public String getPatientInfo() {
		return patientInfo;
	}
	public void setPatientInfo(String patientInfo) {
		this.patientInfo = patientInfo;
	}
	public String getPatientInfoName() {
		return patientInfoName;
	}
	public void setPatientInfoName(String patientInfoName) {
		this.patientInfoName = patientInfoName;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
	public String getComments() {
		return comments;
	}
	public void setComments(String comments) {
		this.comments = comments;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
}
