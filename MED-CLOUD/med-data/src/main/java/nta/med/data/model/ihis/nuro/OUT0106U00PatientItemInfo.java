package nta.med.data.model.ihis.nuro;

public class OUT0106U00PatientItemInfo {
	private String patientInfo;
    private String patientInfoName;
    private String contKey;
	public OUT0106U00PatientItemInfo(String patientInfo,
			String patientInfoName, String contKey) {
		super();
		this.patientInfo = patientInfo;
		this.patientInfoName = patientInfoName;
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
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
}
