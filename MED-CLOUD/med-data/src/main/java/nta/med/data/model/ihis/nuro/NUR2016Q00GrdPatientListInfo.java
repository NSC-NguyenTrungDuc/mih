package nta.med.data.model.ihis.nuro;

import java.util.Date;

/**
 * @author DEV-TiepNM
 */
public class NUR2016Q00GrdPatientListInfo {
	private String bunho;
	private String patientName;
	private String address;
	private Date birth;
	private String suname;
	private String surname2;
	private String sex;
	private String tel;
	private String linkEmr;

	public NUR2016Q00GrdPatientListInfo(String bunho, String patientName, String address, Date birth, String suname,
			String surname2, String sex, String tel, String linkEmr) {
		this.bunho = bunho;
		this.patientName = patientName;
		this.address = address;
		this.birth = birth;
		this.suname = suname;
		this.surname2 = surname2;
		this.sex = sex;
		this.tel = tel;
		this.linkEmr = linkEmr;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public Date getBirth() {
		return birth;
	}

	public void setBirth(Date birth) {
		this.birth = birth;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getSurname2() {
		return surname2;
	}

	public void setSurname2(String surname2) {
		this.surname2 = surname2;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getTel() {
		return tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	public String getLinkEmr() {
		return linkEmr;
	}

	public void setLinkEmr(String linkEmr) {
		this.linkEmr = linkEmr;
	}

}
