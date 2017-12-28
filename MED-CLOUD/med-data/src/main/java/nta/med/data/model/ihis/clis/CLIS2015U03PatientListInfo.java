package nta.med.data.model.ihis.clis;

import java.util.Date;

public class CLIS2015U03PatientListInfo {
	private String bunho;
	private String surname;
	private String surname2;
	private String fullName;
	private String sex;
	private Integer birth;
	private String clisProtocolId;

	public CLIS2015U03PatientListInfo(String bunho, String surname,
			String surname2, String fullName, String sex, Integer birth,
			String clisProtocolId) {
		super();
		this.bunho = bunho;
		this.surname = surname;
		this.surname2 = surname2;
		this.fullName = fullName;
		this.sex = sex;
		this.birth = birth;
		this.clisProtocolId = clisProtocolId;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getSurname() {
		return surname;
	}

	public void setSurname(String surname) {
		this.surname = surname;
	}

	public String getSurname2() {
		return surname2;
	}

	public void setSurname2(String surname2) {
		this.surname2 = surname2;
	}

	public String getFullName() {
		return fullName;
	}

	public void setFullName(String fullName) {
		this.fullName = fullName;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public Integer getBirth() {
		return birth;
	}

	public void setBirth(Integer birth) {
		this.birth = birth;
	}

	public String getClisProtocolId() {
		return clisProtocolId;
	}

	public void setClisProtocolId(String clisProtocolId) {
		this.clisProtocolId = clisProtocolId;
	}

}
