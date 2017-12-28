package nta.mss.model;

import java.util.Date;
import java.util.List;

import nta.mss.entity.MailList;
import nta.mss.info.ReminderMailInfo;
import org.hibernate.validator.constraints.NotBlank;

/**
 * @author linh.nguyen.trong
 * @crtDate 07/08/2014
 * 
 */
public class MailListModel extends BaseModel<MailList> {

	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 1L;

	public MailListModel() {
		super(MailList.class);
	}
	
	private Integer mailListId;
	private Integer activeFlg;
	private Date created;
	@NotBlank
	private String mailListName;
	private Date updated;
	//add for be045
	private String fromDate;
	private String toDate;
	private String patientName;
	private String email;
	private String phoneNumber;
	private Integer readingFlg;
	private List<MailListDetailModel> mailListDetailModels;
	private List<ReminderMailInfo> reminderMails; 
	
	public List<ReminderMailInfo> getReminderMails() {
		return reminderMails;
	}
	public void setReminderMails(List<ReminderMailInfo> reminderMails) {
		this.reminderMails = reminderMails;
	}
	public Integer getMailListId() {
		return mailListId;
	}
	public void setMailListId(Integer mailListId) {
		this.mailListId = mailListId;
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
	public String getMailListName() {
		return mailListName;
	}
	public void setMailListName(String mailListName) {
		this.mailListName = mailListName;
	}
	public Date getUpdated() {
		return updated;
	}
	public void setUpdated(Date updated) {
		this.updated = updated;
	}
	public String getFromDate() {
		return fromDate;
	}
	public void setFromDate(String fromDate) {
		this.fromDate = fromDate;
	}
	public String getToDate() {
		return toDate;
	}
	public void setToDate(String toDate) {
		this.toDate = toDate;
	}
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	public String getPhoneNumber() {
		return phoneNumber;
	}
	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}
	public Integer getReadingFlg() {
		return readingFlg;
	}
	public void setReadingFlg(Integer readingFlg) {
		this.readingFlg = readingFlg;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public List<MailListDetailModel> getMailListDetailModels() {
		return mailListDetailModels;
	}
	public void setMailListDetailModels(List<MailListDetailModel> mailListDetailModels) {
		this.mailListDetailModels = mailListDetailModels;
	}
	@Override
	public String toString() {
		return "MailListModel [mailListId=" + mailListId + ", activeFlg="
				+ activeFlg + ", created=" + created + ", mailListName="
				+ mailListName + ", updated=" + updated + ", fromDate="
				+ fromDate + ", toDate=" + toDate + ", patientName="
				+ patientName + ", email=" + email + ", phoneNumber="
				+ phoneNumber + ", readingFlg=" + readingFlg + "]";
	}
}
