package nta.med.ext.mss.model;

import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class AccountModel {
	
	@JsonProperty("hosp_code")
	@NotNull
    private String hospCode;
    
    @JsonProperty("user_id")
    @NotNull
    private String userId;
    
    @JsonProperty("password")
    @NotNull
    private String password;
    
    @JsonProperty("user_name")
    private String userName;
   
	@JsonIgnore
	private String message;

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getUserName() {
		return userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}

	@Override
	public String toString() {
		return "AccountModel [hospCode=" + hospCode + ", userId=" + userId + ", password=" + password + ", userName="
				+ userName + ", message=" + message + "]";
	}
}
