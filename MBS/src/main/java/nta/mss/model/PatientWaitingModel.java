package nta.mss.model;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.apache.commons.lang.StringUtils;

/**
 * The model class for doctor.
 * 
 * @author HoanPC
 * @CrtDate Sep 6, 2016
 */
public class PatientWaitingModel {
	
	private String reservation_id;
	private String reservation_code;
	private String examination_date;
	private String examination_time;
	private String department_code;
	private String department_name;
	private String patient_name;
	private String patient_code;
	private String patient_name_kana;
	private String doctor_code;
	private String doctor_name;
	private String sys_id;
	private String recept_time;
	private String nawon_yn;
	
	private String examinationTimeFrm;
	private String examinationTimeAmPm;
	private String mt_calling_id;


	private String hospital_id;
	
	public PatientWaitingModel() {
		super();
	}
	
	public PatientWaitingModel(String reservation_code, String examination_date, String examination_time,
			String department_code, String department_name, String patient_name, String patient_code,
			String patient_name_kana, String doctor_code, String doctor_name, String sys_id, String recept_time, String nawon_yn,String reservation_id) {
		super();
		this.reservation_code = reservation_code;
		this.examination_date = examination_date;
		this.examination_time = examination_time;
		this.department_code = department_code;
		this.department_name = department_name;
		this.patient_name = patient_name;
		this.patient_code = patient_code;
		this.patient_name_kana = patient_name_kana;
		this.doctor_code = doctor_code;
		this.doctor_name = doctor_name;
		this.sys_id = sys_id;
		this.recept_time = recept_time;
		this.nawon_yn = nawon_yn;
		this.reservation_id= reservation_id;
	}

	public String getReservation_code() {
		return reservation_code;
	}

	public void setReservation_code(String reservation_code) {
		this.reservation_code = reservation_code;
	}

	public String getExamination_date() {
		return examination_date;
	}

	public void setExamination_date(String examination_date) {
		this.examination_date = examination_date;
	}

	public String getExamination_time() {
		return examination_time;
	}

	public void setExamination_time(String examination_time) {
		this.examination_time = examination_time;
	}

	public String getDepartment_code() {
		return department_code;
	}

	public void setDepartment_code(String department_code) {
		this.department_code = department_code;
	}

	public String getDepartment_name() {
		return department_name;
	}

	public void setDepartment_name(String department_name) {
		this.department_name = department_name;
	}

	public String getPatient_name() {
		return patient_name;
	}

	public void setPatient_name(String patient_name) {
		this.patient_name = patient_name;
	}

	public String getPatient_code() {
		return patient_code;
	}

	public void setPatient_code(String patient_code) {
		this.patient_code = patient_code;
	}

	public String getPatient_name_kana() {
		return patient_name_kana;
	}

	public void setPatient_name_kana(String patient_name_kana) {
		this.patient_name_kana = patient_name_kana;
	}

	public String getDoctor_code() {
		return doctor_code;
	}

	public void setDoctor_code(String doctor_code) {
		this.doctor_code = doctor_code;
	}

	public String getDoctor_name() {
		return doctor_name;
	}

	public void setDoctor_name(String doctor_name) {
		this.doctor_name = doctor_name;
	}

	public String getSys_id() {
		return sys_id;
	}

	public void setSys_id(String sys_id) {
		this.sys_id = sys_id;
	}

	public String getRecept_time() {
		if(StringUtils.isNotBlank(recept_time) && recept_time.length() == 4) {
			return recept_time.substring(0, 2) + ":" + recept_time.substring(2, 4);
		}
		return recept_time;
	}

	public void setRecept_time(String recept_time) {
		this.recept_time = recept_time;
	}
	
	public String getNawon_yn() {
		return nawon_yn;
	}

	public void setNawon_yn(String nawon_yn) {
		this.nawon_yn = nawon_yn;
	}
	
	public String getExaminationTimeFrm() {
		if(StringUtils.isNotBlank(examination_time) && examination_time.length() == 4) {
			return examination_time.substring(0, 2) + ":" + examination_time.substring(2, 4);
		}
		return "";
	}

	public void setExaminationTimeFrm(String examinationTimeFrm) {
		this.examinationTimeFrm = examinationTimeFrm;
	}

	public String getExaminationTimeAmPm() {
		if(StringUtils.isNotBlank(examination_time) && examination_time.length() == 4) {
			//SimpleDateFormat displayFormat = new SimpleDateFormat("HH:mm a");
			SimpleDateFormat displayFormat2 = new SimpleDateFormat("a");
		    SimpleDateFormat parseFormat = new SimpleDateFormat("hhmm");
		    Date date = null;
			try {
				date = parseFormat.parse(examination_time);
				//System.out.println(parseFormat.format(date) + " = " + displayFormat.format(date) + "=" + displayFormat2.format(date));
				return displayFormat2.format(date);
			} catch (ParseException e) {
				e.printStackTrace();
			}
		}
		
		return "";
	}

	public void setExaminationTimeAmPm(String examinationTimeAmPm) {
		this.examinationTimeAmPm = examinationTimeAmPm;
	}
	
	public String getMt_calling_id() {
		return mt_calling_id;
	}

	public void setMt_calling_id(String mt_calling_id) {
		this.mt_calling_id = mt_calling_id;
	}

	public String getHospital_id() {
		return hospital_id;
	}

	public void setHospital_id(String hospital_id) {
		this.hospital_id = hospital_id;
	}

	@Override
	public String toString() {
		return "PatientWaitingModel [reservation_code=" + reservation_code + ", examination_date=" + examination_date
				+ ", examination_time=" + examination_time + ", department_code=" + department_code
				+ ", department_name=" + department_name + ", patient_name=" + patient_name
				+ ", patient_code=" + patient_code + ", patient_name_kana=" + patient_name_kana
				+ ", doctor_code=" + doctor_code + ", doctor_name=" + doctor_name
				+ ", sys_id=" + sys_id + ", recept_time=" + recept_time + ", nawon_yn=" + nawon_yn + ", mt_calling_id=" + mt_calling_id + "]";
	}

	public String getReservation_id() {
		return reservation_id;
	}

	public void setReservation_id(String reservation_id) {
		this.reservation_id = reservation_id;
	}
	
}
