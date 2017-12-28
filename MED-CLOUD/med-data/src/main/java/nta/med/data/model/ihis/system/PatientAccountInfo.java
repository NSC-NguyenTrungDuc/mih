package nta.med.data.model.ihis.system;

public class PatientAccountInfo {

	private String hospCode;
	private String hospName;
	private String patientCode;

	public PatientAccountInfo(String hospCode, String hospName, String patientCode) {
		super();
		this.hospCode = hospCode;
		this.hospName = hospName;
		this.patientCode = patientCode;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getHospName() {
		return hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

}
