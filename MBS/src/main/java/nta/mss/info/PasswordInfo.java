package nta.mss.info;

import javax.validation.constraints.Size;

import org.hibernate.validator.constraints.NotBlank;

public class PasswordInfo {
	@NotBlank
	private String email;
	@NotBlank
	@Size(min = 6)
	private String password;
	@NotBlank
	@Size(min = 6)
	private String passwordConfirm;
	
	public PasswordInfo() {
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getPasswordConfirm() {
		return passwordConfirm;
	}

	public void setPasswordConfirm(String passwordConfirm) {
		this.passwordConfirm = passwordConfirm;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}
	
}
