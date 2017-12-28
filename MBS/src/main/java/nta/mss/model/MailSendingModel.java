package nta.mss.model;

import nta.mss.entity.MailSending;

/**
 * The model class for mail_sending.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class MailSendingModel extends BaseModel<MailSending> {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 1L;

	private String content;
	private Integer mailListId;
	private Integer mailTemplateId;
	private Integer patientId;
	private Integer reservationId;
	private String sendingBcc;
	private String sendingCc;
	private Integer sendingStatus;
	private Integer readingFlg;
	private String sendingTo;
	private String subject;

	/**
	 * Instantiates a new mail sending model.
	 */
	public MailSendingModel() {
		super(MailSending.class);
	}
	
	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public Integer getMailListId() {
		return mailListId;
	}

	public void setMailListId(Integer mailListId) {
		this.mailListId = mailListId;
	}

	public Integer getMailTemplateId() {
		return mailTemplateId;
	}

	public void setMailTemplateId(Integer mailTemplateId) {
		this.mailTemplateId = mailTemplateId;
	}

	public Integer getPatientId() {
		return patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	public Integer getReservationId() {
		return reservationId;
	}

	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}

	public String getSendingBcc() {
		return sendingBcc;
	}

	public void setSendingBcc(String sendingBcc) {
		this.sendingBcc = sendingBcc;
	}

	public String getSendingCc() {
		return sendingCc;
	}

	public void setSendingCc(String sendingCc) {
		this.sendingCc = sendingCc;
	}

	public Integer getSendingStatus() {
		return sendingStatus;
	}

	public void setSendingStatus(Integer sendingStatus) {
		this.sendingStatus = sendingStatus;
	}

	public String getSendingTo() {
		return sendingTo;
	}

	public void setSendingTo(String sendingTo) {
		this.sendingTo = sendingTo;
	}

	public String getSubject() {
		return subject;
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
}