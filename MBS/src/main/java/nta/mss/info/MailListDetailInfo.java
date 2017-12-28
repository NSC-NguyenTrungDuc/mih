package nta.mss.info;

/**
 * The Class MailListDetailInfo.
 */
public class MailListDetailInfo {
	private String name;
	private String phone;
	private String mail;
	
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

	@Override
	public String toString() {
		return "MailListDetailInfo [name=" + name + ", phone=" + phone
				+ ", mail=" + mail + "]";
	}
}
