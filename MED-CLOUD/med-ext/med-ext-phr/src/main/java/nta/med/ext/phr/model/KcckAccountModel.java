package nta.med.ext.phr.model;

import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonProperty;

public class KcckAccountModel {

	@JsonProperty("username")
	@NotNull(message = "username.required")
	private String username;

	@JsonProperty("password")
	@NotNull(message = "password.required")
	private String password;

	@JsonProperty("hosp_code")
	@NotNull(message = "hosp_code.required")
	private String hospCode;

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

}
