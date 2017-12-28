package nta.med.ext.cms.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class KcckUserModel {

	@JsonProperty("hosp_code")
	private String hospCode;

	@JsonProperty("username")
	private String userName;

	@JsonProperty("password")
	private String password;

	public KcckUserModel() {
		super();
	}

	public KcckUserModel(String hospCode, String userName, String password) {
		super();
		this.hospCode = hospCode;
		this.userName = userName;
		this.password = password;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getUserName() {
		return userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

}
