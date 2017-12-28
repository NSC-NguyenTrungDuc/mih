package nta.sfd.info;

import javax.validation.constraints.Size;

import nta.sfd.validation.Email;

import org.hibernate.validator.constraints.NotEmpty;

public class ContactUsInfo {
	@NotEmpty
	@Size(max = 256)
	private String companyName;
	
	@NotEmpty
	@Size(max = 256)
	private String picName;
	
	@NotEmpty
	@Email
	@Size(max = 128)
	private String mailAddress;
	
	@NotEmpty
	@Size(max = 1000)
	private String content;

	public String getCompanyName() {
		return companyName;
	}

	public void setCompanyName(String companyName) {
		this.companyName = companyName;
	}

	public String getPicName() {
		return picName;
	}

	public void setPicName(String picName) {
		this.picName = picName;
	}

	public String getMailAddress() {
		return mailAddress;
	}

	public void setMailAddress(String mailAddress) {
		this.mailAddress = mailAddress;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}
}
