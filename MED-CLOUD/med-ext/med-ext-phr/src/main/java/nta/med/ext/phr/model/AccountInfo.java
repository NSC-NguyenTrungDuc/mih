package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;
/**
 * @author DEV-HoanPC
 */
public class AccountInfo {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("email")
	private String email;

	@JsonProperty("name")
	private String fullname;
	
	@JsonProperty("name_kana")
	private String fullnameKana;
	
	@JsonProperty("sex")
	private String sex;
	
	@JsonProperty("birthday")
	private String birthday;
	
	@JsonProperty("phone")
	private String phone;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getFullname() {
		return fullname;
	}

	public void setFullname(String fullname) {
		this.fullname = fullname;
	}

	public String getFullnameKana() {
		return fullnameKana;
	}

	public void setFullnameKana(String fullnameKana) {
		this.fullnameKana = fullnameKana;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}
	
}
