package nta.mss.model;

import java.util.Date;

import org.hibernate.validator.constraints.NotBlank;

import nta.mss.entity.MailListDetail;
import nta.mss.validation.Email;

/**
 * @author linhnt
 * @since 20140811
 *
 */
public class MailListDetailModel extends BaseModel<MailListDetail> {
	
	private static final long serialVersionUID = 1L;

	public MailListDetailModel() {
		super(MailListDetail.class);
	}
	
	private Integer mailListId;
	@NotBlank
	@Email
	private String email;
	@NotBlank
	private String name;
	private String phone;
	private Integer patientId;
	private Boolean isSentEmail;
	private Integer activeFlg;
	private Date created;
	private Date updated;

	public Integer getMailListId() {
		return mailListId;
	}
	public void setMailListId(Integer mailListId) {
		this.mailListId = mailListId;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public Integer getPatientId() {
		return patientId;
	}
	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}
	public Boolean getIsSentEmail() {
		return isSentEmail;
	}
	public void setIsSentEmail(Boolean isSentEmail) {
		this.isSentEmail = isSentEmail;
	}
	public Integer getActiveFlg() {
		return activeFlg;
	}
	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}
	public Date getCreated() {
		return created;
	}
	public void setCreated(Date created) {
		this.created = created;
	}
	public Date getUpdated() {
		return updated;
	}
	public void setUpdated(Date updated) {
		this.updated = updated;
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
		return "MailListDetailModel [mailListId=" + mailListId + ", email="
				+ email + ", name=" + name + ", phone=" + phone
				+ ", patientId=" + patientId + ", isSentEmail=" + isSentEmail
				+ ", activeFlg=" + activeFlg + ", created=" + created
				+ ", updated=" + updated + "]";
	}
}
