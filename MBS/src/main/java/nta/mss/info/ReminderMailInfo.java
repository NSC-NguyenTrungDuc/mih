package nta.mss.info;

import java.io.Serializable;

public class ReminderMailInfo implements Serializable {
	private static final long serialVersionUID = 1L;
	
	private Integer mailListId;
	private String name;
	private String mail;
	private String phone;
	private String mailOld;
	
	public ReminderMailInfo() {
	}

	public ReminderMailInfo(String name, String mail, String mailOld, String phone) {
		this.name = name;
		this.mailOld = mailOld;
		this.mail = mail;
		this.phone = phone;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getMail() {
		return mail;
	}

	public void setMail(String mail) {
		this.mail = mail;
	}

	public String getMailOld() {
		return mailOld;
	}

	public void setMailOld(String mailOld) {
		this.mailOld = mailOld;
	}
	
	public Integer getMailListId() {
		return mailListId;
	}

	public void setMailListId(Integer mailListId) {
		this.mailListId = mailListId;
	}

	/**
	 * Equals.
	 * 
	 * @param other
	 *            the other
	 * @return true, if successful
	 */
	@Override
	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof ReminderMailInfo)) {
			return false;
		}
		ReminderMailInfo castOther = (ReminderMailInfo) other;
		
		return (this.mail.trim().toLowerCase().equals(castOther.mail.trim().toLowerCase()));
	}
	
	@Override
    public int hashCode() {
        return this.mail.hashCode();
    }

	/**
	 * @return the phone
	 */
	public String getPhone() {
		return phone;
	}

	/**
	 * @param phone the phone to set
	 */
	public void setPhone(String phone) {
		this.phone = phone;
	}
}
