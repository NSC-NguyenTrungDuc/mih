package nta.mss.info;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

/**
 * The Class PatientModel.
 * 
 * @author HoanPC
 * @CrtDate Sep 6, 2016
 */
public class PatientProfileInfo {
	private Integer patientId;
	private String name;
	private String nameFurigana;
	private String phoneNumber;
	private String gender;
	private Date birthDate;
	private String dob;
	private int age;
	private String cardNumber;
	
	public PatientProfileInfo() {
		super();
	}

	public PatientProfileInfo(Integer patientId, String name, String nameFurigana, String phoneNumber, String gender,
			Date birthDate, String dob, int age, String cardNumber) {
		super();
		this.patientId = patientId;
		this.name = name;
		this.nameFurigana = nameFurigana;
		this.phoneNumber = phoneNumber;
		this.gender = gender;
		this.birthDate = birthDate;
		this.dob = dob;
		this.age = age;
		this.cardNumber = cardNumber;
	}
	
	public Integer getPatientId() {
		return patientId;
	}
	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
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
	public String getPhoneNumber() {
		return phoneNumber;
	}
	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}
	public String getGender() {
		return gender;
	}
	public void setGender(String gender) {
		this.gender = gender;
	}
	public Date getBirthDate() {
		return birthDate;
	}
	public void setBirthDate(Date birthDate) {
		this.birthDate = birthDate;
	}

	@SuppressWarnings("deprecation")
	public int getAge() {
		if(getBirthDate() != null) {
			return (Calendar.getInstance().get(Calendar.YEAR) - (1900+this.getBirthDate().getYear()));
		}
		return 0;
	}
	
	public void setAge(int age) {
		this.age = age;
	}
	public String getCardNumber() {
		return cardNumber;
	}
	public void setCardNumber(String cardNumber) {
		this.cardNumber = cardNumber;
	}

	public String getDob() {
		if(getBirthDate() != null) {
			DateFormat df = new SimpleDateFormat("yyyy/MM/dd");
			return df.format(getBirthDate());
		}
		return null;
	}

	public void setDob(String dob) {
		this.dob = dob;
	}
	
}
