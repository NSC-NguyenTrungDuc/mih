package nta.med.ext.mss.model;

import javax.validation.constraints.Digits;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * 
 * @author DEV-HoanPC
 *
 */
public class PatientInfoModel {
	
	@JsonProperty("patient_id")
	private Integer patientId;   
	
	@JsonProperty("hosp_id")
	private Integer hospitalId;
	
	@JsonProperty("hosp_code")
	private String hospitalCode;
	
	@JsonProperty("patient_code") // string
	private String cardNumber;

	@JsonProperty("patient_name") // "石川"
	private String name;
	
	@JsonProperty("patient_name_furigana") // string
	private String nameFurigana;

	@JsonProperty("patient_age") // number
	@Digits(integer = 6, fraction = 2)
	private Integer patientAge;

	@JsonProperty("patient_gender") // string (F or M)
	private String sex;
	
	@JsonProperty("patient_phone")
	private String phoneNumber;

	public String getCardNumber() {
		return cardNumber;
	}

	public void setCardNumber(String cardNumber) {
		this.cardNumber = cardNumber;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getNameFurigana() {
		return nameFurigana;
	}

	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}

	public Integer getPatientAge() {
		return patientAge;
	}

	public void setPatientAge(Integer patientAge) {
		this.patientAge = patientAge;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public Integer getPatientId() {
		return patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	public String getHospitalCode() {
		return hospitalCode;
	}

	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}
	
}
