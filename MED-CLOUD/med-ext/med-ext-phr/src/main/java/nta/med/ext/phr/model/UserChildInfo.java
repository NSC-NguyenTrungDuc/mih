package nta.med.ext.phr.model;

import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;
/**
 * @author DEV-HoanPC
 */
public class UserChildInfo {
	
	@JsonProperty("id")
	private BigInteger id;
	
	@JsonProperty("account_id")
	private Integer accountId;

	@JsonProperty("fullname")
	private String fullname;

	@JsonProperty("fullname_kana")
	private String fullnameKana;
	
	@JsonProperty("birth_day")
	private String birthday;
	
	@JsonProperty("sex")
	private String sex;
	
	@JsonProperty("locale")
	private String locale;
	
	@JsonProperty("phone")
	private String phone;

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public Integer getAccountId() {
		return accountId;
	}

	public void setAccountId(Integer accountId) {
		this.accountId = accountId;
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

	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}
	
}
