package nta.sfd.core.model;

import java.math.BigDecimal;

import nta.sfd.core.entity.MailSending;


/**
 * The persistent class for the MAIL_SENDING database table.
 *
 * @author MinhLS
 * @crtDate 2015/07/03
 */
public class MailSendingModel extends BaseModel<MailSending> {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 1L;
	
	/** The mail sending id. */
	private Integer mailSendingId;
	
	/** The content. */
	private String content;
	
	/** The hospital register id. */
	private Integer hospitalRegisterId;
	
	/** The mail template id. */
	private Integer mailTemplateId;
	
	/** The sending bcc. */
	private String sendingBcc;
	
	/** The sending cc. */
	private String sendingCc;
	
	/** The sending status. */
	private BigDecimal sendingStatus;
	
	/** The sending to. */
	private String sendingTo;
	
	/** The subject. */
	private String subject;

	/**
	 * Instantiates a new mail sending model.
	 */
	public MailSendingModel() {
		super(MailSending.class);
	}

	/**
	 * Gets the mail sending id.
	 *
	 * @return the mail sending id
	 */
	public Integer getMailSendingId() {
		return mailSendingId;
	}

	/**
	 * Sets the mail sending id.
	 *
	 * @param mailSendingId the new mail sending id
	 */
	public void setMailSendingId(Integer mailSendingId) {
		this.mailSendingId = mailSendingId;
	}

	/**
	 * Gets the content.
	 *
	 * @return the content
	 */
	public String getContent() {
		return content;
	}

	/**
	 * Sets the content.
	 *
	 * @param content the new content
	 */
	public void setContent(String content) {
		this.content = content;
	}

	/**
	 * Gets the hospital register id.
	 *
	 * @return the hospital register id
	 */
	public Integer getHospitalRegisterId() {
		return hospitalRegisterId;
	}

	/**
	 * Sets the hospital register id.
	 *
	 * @param hospitalRegisterId the new hospital register id
	 */
	public void setHospitalRegisterId(Integer hospitalRegisterId) {
		this.hospitalRegisterId = hospitalRegisterId;
	}

	/**
	 * Gets the mail template id.
	 *
	 * @return the mail template id
	 */
	public Integer getMailTemplateId() {
		return mailTemplateId;
	}

	/**
	 * Sets the mail template id.
	 *
	 * @param mailTemplateId the new mail template id
	 */
	public void setMailTemplateId(Integer mailTemplateId) {
		this.mailTemplateId = mailTemplateId;
	}

	/**
	 * Gets the sending bcc.
	 *
	 * @return the sending bcc
	 */
	public String getSendingBcc() {
		return sendingBcc;
	}

	/**
	 * Sets the sending bcc.
	 *
	 * @param sendingBcc the new sending bcc
	 */
	public void setSendingBcc(String sendingBcc) {
		this.sendingBcc = sendingBcc;
	}

	/**
	 * Gets the sending cc.
	 *
	 * @return the sending cc
	 */
	public String getSendingCc() {
		return sendingCc;
	}

	/**
	 * Sets the sending cc.
	 *
	 * @param sendingCc the new sending cc
	 */
	public void setSendingCc(String sendingCc) {
		this.sendingCc = sendingCc;
	}

	/**
	 * Gets the sending status.
	 *
	 * @return the sending status
	 */
	public BigDecimal getSendingStatus() {
		return sendingStatus;
	}

	/**
	 * Sets the sending status.
	 *
	 * @param sendingStatus the new sending status
	 */
	public void setSendingStatus(BigDecimal sendingStatus) {
		this.sendingStatus = sendingStatus;
	}

	/**
	 * Gets the sending to.
	 *
	 * @return the sending to
	 */
	public String getSendingTo() {
		return sendingTo;
	}

	/**
	 * Sets the sending to.
	 *
	 * @param sendingTo the new sending to
	 */
	public void setSendingTo(String sendingTo) {
		this.sendingTo = sendingTo;
	}

	/**
	 * Gets the subject.
	 *
	 * @return the subject
	 */
	public String getSubject() {
		return subject;
	}

	/**
	 * Sets the subject.
	 *
	 * @param subject the new subject
	 */
	public void setSubject(String subject) {
		this.subject = subject;
	}
}