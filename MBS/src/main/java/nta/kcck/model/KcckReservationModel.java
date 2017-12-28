package nta.kcck.model;

public class KcckReservationModel {
	private String hosp_code;
	private String department_code;
	private String doctor_code;
	private String reservation_date;
	private String reservation_time;
	private String patient_code;
	private String patient_name_kanji;
	private String patient_name_kana;
	private String patient_tel;
	private String patient_email;
	private String patient_sex;
	private String patient_birthday;
	private String locale;
	private String doctor_name;
	private String department_name;
	private String reservation_code;
	private String hangmog_code;
	private String hangmog_name;
	private String parent_code;
	private String child_code_list;
	private String doctor_grade;
	private String sys_id;
	private String mis_survey_link;
	private String survey_yn;
	private String quick_mode;
	private String reservation_id;
	
	public String getHosp_code() {
		return hosp_code;
	}
	public void setHosp_code(String hosp_code) {
		this.hosp_code = hosp_code;
	}
	public String getDepartment_code() {
		return department_code;
	}
	public void setDepartment_code(String department_code) {
		this.department_code = department_code;
	}
	public String getDoctor_code() {
		return doctor_code;
	}
	public void setDoctor_code(String doctor_code) {
		this.doctor_code = doctor_code;
	}
	public String getReservation_date() {
		return reservation_date;
	}
	public void setReservation_date(String reservation_date) {
		this.reservation_date = reservation_date;
	}
	public String getReservation_time() {
		return reservation_time;
	}
	public void setReservation_time(String reservation_time) {
		this.reservation_time = reservation_time;
	}
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
	public String getLocale() {
		return locale;
	}
	public void setLocale(String locale) {
		this.locale = locale;
	}
	public String getDoctor_name() {
		return doctor_name;
	}
	public void setDoctor_name(String doctor_name) {
		this.doctor_name = doctor_name;
	}
	public String getDepartment_name() {
		return department_name;
	}
	public void setDepartment_name(String department_name) {
		this.department_name = department_name;
	}
	public String getReservation_code() {
		return reservation_code;
	}
	public void setReservation_code(String reservation_code) {
		this.reservation_code = reservation_code;
	}
	
	public String getHangmog_code() {
		return hangmog_code;
	}
	public void setHangmog_code(String hangmog_code) {
		this.hangmog_code = hangmog_code;
	}
	public String getHangmog_name() {
		return hangmog_name;
	}
	public void setHangmog_name(String hangmog_name) {
		this.hangmog_name = hangmog_name;
	}
	public String getParent_code() {
		return parent_code;
	}
	public void setParent_code(String parent_code) {
		this.parent_code = parent_code;
	}
	public String getChild_code_list() {
		return child_code_list;
	}
	public void setChild_code_list(String child_code_list) {
		this.child_code_list = child_code_list;
	}
	
	public String getDoctor_grade() {
		return doctor_grade;
	}
	public void setDoctor_grade(String doctor_grade) {
		this.doctor_grade = doctor_grade;
	}
	
	public String getSys_id() {
		return sys_id;
	}
	public void setSys_id(String sys_id) {
		this.sys_id = sys_id;
	}	
	public String getMis_survey_link() {
		return mis_survey_link;
	}
	public void setMis_survey_link(String mis_survey_link) {
		this.mis_survey_link = mis_survey_link;
	}
	
	public String getSurvey_yn() {
		return survey_yn;
	}
	public void setSurvey_yn(String survey_yn) {
		this.survey_yn = survey_yn;
	}

	
	public String getQuick_mode() {
		return quick_mode;
	}
	public void setQuick_mode(String quick_mode) {
		this.quick_mode = quick_mode;
	}

	public String getReservation_id() {
		return reservation_id;
	}

	public void setReservation_id(String reservation_id) {
		this.reservation_id = reservation_id;
	}

	public KcckReservationModel(String hosp_code, String department_code, String doctor_code, String reservation_date,
			String reservation_time, String patient_code, String patient_name_kanji, String patient_name_kana,
			String patient_tel, String patient_email, String patient_sex, String patient_birthday, String locale,
			String doctor_name, String department_name, String reservation_code, String hangmog_code,
			String hangmog_name, String parent_code, String child_code_list, String doctor_grade,String sys_id,String mis_survey_link) {
		super();
		this.hosp_code = hosp_code;
		this.department_code = department_code;
		this.doctor_code = doctor_code;
		this.reservation_date = reservation_date;
		this.reservation_time = reservation_time;
		this.patient_code = patient_code;
		this.patient_name_kanji = patient_name_kanji;
		this.patient_name_kana = patient_name_kana;
		this.patient_tel = patient_tel;
		this.patient_email = patient_email;
		this.patient_sex = patient_sex;
		this.patient_birthday = patient_birthday;
		this.locale = locale;
		this.doctor_name = doctor_name;
		this.department_name = department_name;
		this.reservation_code = reservation_code;
		this.hangmog_code = hangmog_code;
		this.hangmog_name = hangmog_name;
		this.parent_code = parent_code;
		this.child_code_list = child_code_list;
		this.doctor_grade = doctor_grade;
		this.sys_id = sys_id;
		this.mis_survey_link = mis_survey_link;
		this.quick_mode = quick_mode;
	}

	public KcckReservationModel() {
	
	}
	@Override
	public String toString() {
		return "KcckReservationModel [hosp_code=" + hosp_code + ", department_code=" + department_code
				+ ", doctor_code=" + doctor_code + ", reservation_date=" + reservation_date + ", reservation_time="
				+ reservation_time + ", patient_code=" + patient_code + ", patient_name_kanji=" + patient_name_kanji
				+ ", patient_name_kana=" + patient_name_kana + ", patient_tel=" + patient_tel + ", patient_email="
				+ patient_email + ", patient_sex=" + patient_sex + ", patient_birthday=" + patient_birthday
				+ ", locale=" + locale + ", doctor_name=" + doctor_name + ", department_name=" + department_name
				+ ", reservation_code=" + reservation_code + ", hangmog_code=" + hangmog_code + ", hangmog_name="
				+ hangmog_name + ", parent_code=" + parent_code + ", child_code_list=" + child_code_list
				+ ", doctor_grade=" + doctor_grade + ", sys_id=" + sys_id + "]";
	}	
	 
}
