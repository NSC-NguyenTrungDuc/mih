package nta.kcck.model;

public class KcckPatientModel {
	public String patient_code;
	public String patient_name_kanji;
	public String patient_name_kana;
	public String patient_tel;
	public String patient_email;
	public String patient_sex;
	public String patient_birthday;
	public String getPatient_code() {
		return patient_code;
	}
	public void setPatient_code(String patient_code) {
		this.patient_code = patient_code;
	}
	public String getPatient_name_kanji() {
		return patient_name_kanji;
	}
	public void setPatient_name_kanji(String patient_name_kanji) {
		this.patient_name_kanji = patient_name_kanji;
	}
	public String getPatient_name_kana() {
		return patient_name_kana;
	}
	public void setPatient_name_kana(String patient_name_kana) {
		this.patient_name_kana = patient_name_kana;
	}
	public String getPatient_tel() {
		return patient_tel;
	}
	public void setPatient_tel(String patient_tel) {
		this.patient_tel = patient_tel;
	}
	public String getPatient_email() {
		return patient_email;
	}
	public void setPatient_email(String patient_email) {
		this.patient_email = patient_email;
	}
	public String getPatient_sex() {
		return patient_sex;
	}
	public void setPatient_sex(String patient_sex) {
		this.patient_sex = patient_sex;
	}
	public String getPatient_birthday() {
		return patient_birthday;
	}
	public void setPatient_birthday(String patient_birthday) {
		this.patient_birthday = patient_birthday;
	}
	@Override
	public String toString() {
		return "KcckPatientModel [patient_code=" + patient_code + ", patient_name_kanji=" + patient_name_kanji
				+ ", patient_name_kana=" + patient_name_kana + ", patient_tel=" + patient_tel + ", patient_email="
				+ patient_email + ", patient_sex=" + patient_sex + ", patient_birthday=" + patient_birthday + "]";
	}
	
	 
}
