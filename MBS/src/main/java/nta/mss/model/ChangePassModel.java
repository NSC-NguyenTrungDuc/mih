package nta.mss.model;

import java.io.Serializable;

import org.hibernate.validator.constraints.NotBlank;

import nta.mss.validation.Email;

public class ChangePassModel implements Serializable{
	
	@NotBlank
	@Email
	private String email;

	@NotBlank
	private String password;

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public ChangePassModel(String email, String password) {
		super();
		this.email = email;
		this.password = password;
	}
	
}
