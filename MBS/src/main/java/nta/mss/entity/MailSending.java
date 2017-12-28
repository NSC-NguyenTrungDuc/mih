package nta.mss.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.Lob;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import nta.mss.model.MailSendingModel;

/**
 * The persistent class for the mail_sending database table.
 * 
 */
@Entity
@Table(name = "mail_sending")
public class MailSending extends BaseEntity<MailSendingModel> {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "mail_sending_id", unique = true, nullable = false)
	private Integer mailSendingId;

	@Lob
	@Column(name = "content")
	private String content;

	@Column(name = "mail_template_id")
	private Integer mailTemplateId;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "patient_id")
	private Patient patient;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "reservation_id")
	private Reservation reservation;

	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "mail_list_id")
	private MailList mailList;
	
//	@ManyToMany(mappedBy = "mailSendings",fetch = FetchType.LAZY)
//	private List<MailListDetail> mailListDetails;
	
	@Column(name = "sending_bcc", length = 256)
	private String sendingBcc;

	@Column(name = "sending_cc", length = 256)
	private String sendingCc;

	@Column(name = "sending_status", nullable = false, precision = 10)
	private Integer sendingStatus;
	
	@Column(name = "reading_flg")
	private Integer readingFlg;

	@Column(name = "sending_to", length = 256)
	private String sendingTo;

	@Column(name = "subject", length = 256)
	private String subject;

	/**
	 * Instantiates a new mail sending.
	 */
	public MailSending() {
		super(MailSendingModel.class);
	}

	public Integer getMailSendingId() {
		return this.mailSendingId;
	}

	public void setMailSendingId(Integer mailSendingId) {
		this.mailSendingId = mailSendingId;
	}

	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public Integer getMailTemplateId() {
		return this.mailTemplateId;
	}

	public void setMailTemplateId(Integer mailTemplateId) {
		this.mailTemplateId = mailTemplateId;
	}

	public Patient getPatient() {
		return patient;
	}

	public void setPatient(Patient patient) {
		this.patient = patient;
	}

	public Reservation getReservation() {
		return reservation;
	}

	public void setReservation(Reservation reservation) {
		this.reservation = reservation;
	}

	public String getSendingBcc() {
		return this.sendingBcc;
	}

	public void setSendingBcc(String sendingBcc) {
		this.sendingBcc = sendingBcc;
	}

	public String getSendingCc() {
		return this.sendingCc;
	}

	public void setSendingCc(String sendingCc) {
		this.sendingCc = sendingCc;
	}

	public Integer getSendingStatus() {
		return this.sendingStatus;
	}

	public void setSendingStatus(Integer sendingStatus) {
		this.sendingStatus = sendingStatus;
	}

	public String getSendingTo() {
		return this.sendingTo;
	}

	public void setSendingTo(String sendingTo) {
		this.sendingTo = sendingTo;
	}

	public String getSubject() {
		return this.subject;
	}

	public void setSubject(String subject) {
		this.subject = subject;
	}

	public Integer getReadingFlg() {
		return readingFlg;
	}

	public void setReadingFlg(Integer readingFlg) {
		this.readingFlg = readingFlg;
	}

	public MailList getMailList() {
		return mailList;
	}

	public void setMailList(MailList mailList) {
		this.mailList = mailList;
	}
	
}