package nta.mss.model;

import nta.mss.validation.Email;

import org.hibernate.validator.constraints.NotBlank;

/**
 * The Class MailModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class MailModel {
	
	@NotBlank
	@Email
	private String email;

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}
	
}
