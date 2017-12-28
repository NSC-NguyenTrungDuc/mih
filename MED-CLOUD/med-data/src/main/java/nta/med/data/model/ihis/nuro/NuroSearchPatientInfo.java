package nta.med.data.model.ihis.nuro;

public class NuroSearchPatientInfo {
	private String patientCode;
	private String patientName1;
	private String patientName2;
	private String birth;

	public NuroSearchPatientInfo(String patientCode, String patientName1,
			String patientName2, String birth) {
		super();
		this.patientCode = patientCode;
		this.patientName1 = patientName1;
		this.patientName2 = patientName2;
		this.birth = birth;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getPatientName1() {
		return patientName1;
	}

	public void setPatientName1(String patientName1) {
		this.patientName1 = patientName1;
	}

	public String getPatientName2() {
		return patientName2;
	}

	public void setPatientName2(String patientName2) {
		this.patientName2 = patientName2;
	}

	public String getBirth() {
		return birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
	}

}
