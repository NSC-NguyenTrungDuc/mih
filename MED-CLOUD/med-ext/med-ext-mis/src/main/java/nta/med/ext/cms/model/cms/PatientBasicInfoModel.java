package nta.med.ext.cms.model.cms;

/**
 * @author DEV-TiepNM
 */
public class PatientBasicInfoModel {

	private String patientCode;
	private String patientNameKanji;
	private String patientNameKana;
	private String patientTel;
	private String patientEmail;
	private String patientSex;
	private String patientBirthday;
	private String patientPwd;

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getPatientNameKanji() {
		return patientNameKanji;
	}

	public void setPatientNameKanji(String patientNameKanji) {
		this.patientNameKanji = patientNameKanji;
	}

	public String getPatientNameKana() {
		return patientNameKana;
	}

	public void setPatientNameKana(String patientNameKana) {
		this.patientNameKana = patientNameKana;
	}

	public String getPatientTel() {
		return patientTel;
	}

	public void setPatientTel(String patientTel) {
		this.patientTel = patientTel;
	}

	public String getPatientEmail() {
		return patientEmail;
	}

	public void setPatientEmail(String patientEmail) {
		this.patientEmail = patientEmail;
	}

	public String getPatientSex() {
		return patientSex;
	}

	public void setPatientSex(String patientSex) {
		this.patientSex = patientSex;
	}

	public String getPatientBirthday() {
		return patientBirthday;
	}

	public void setPatientBirthday(String patientBirthday) {
		this.patientBirthday = patientBirthday;
	}

	public String getPatientPwd() {
		return patientPwd;
	}

	public void setPatientPwd(String patientPwd) {
		this.patientPwd = patientPwd;
	}

	@Override
	public String toString() {
		return "PatientBasicInfoModel [patientCode=" + patientCode + ", patientNameKanji=" + patientNameKanji
				+ ", patientNameKana=" + patientNameKana + ", patientTel=" + patientTel + ", patientEmail="
				+ patientEmail + ", patientSex=" + patientSex + ", patientBirthday=" + patientBirthday + ", patientPwd="
				+ patientPwd + "]";
	}
}
