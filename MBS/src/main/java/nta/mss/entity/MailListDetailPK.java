package nta.mss.entity;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Embeddable;

/**
 * The persistent class for the mail_list_detail database table.
 * 
 * @author linhnt
 */
@Embeddable
public class MailListDetailPK implements Serializable {
	private static final long serialVersionUID = 1L;

	@Column(name = "mail_list_id")
	private Integer mailListId;
	
	@Column(name = "email", length = 128)
	private String email;

	public MailListDetailPK() {
		
	}
	
	public MailListDetailPK(Integer mailListId, String email) {
		this.mailListId = mailListId;
		this.email = email;
	}
	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public Integer getMailListId() {
		return this.mailListId;
	}

	public void setMailListId(Integer mailListId) {
		this.mailListId = mailListId;
	}
	
	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof MailListDetailPK)) {
			return false;
		}
		MailListDetailPK castOther = (MailListDetailPK)other;
		return 
			(this.mailListId.equals(castOther.mailListId))
			&& this.email.equals(castOther.email);
	}
	
	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.mailListId;
		hash = hash * prime + this.email.hashCode();
		
		return hash;
	}
}