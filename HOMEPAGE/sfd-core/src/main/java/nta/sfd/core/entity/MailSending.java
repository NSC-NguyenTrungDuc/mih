package nta.sfd.core.entity;

import java.math.BigDecimal;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.Table;

import nta.sfd.core.model.MailSendingModel;


// TODO: Auto-generated Javadoc
/**
 * The persistent class for the MAIL_SENDING database table.
 *
 * @author MinhLS
 * @crtDate 2015/07/03
 */
@Entity
@Table(name="MAIL_SENDING")
public class MailSending extends BaseEntity<MailSendingModel> {
	
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
	 * Instantiates a new mail sending.
	 */
	public MailSending() {
		super(MailSendingModel.class);
	}


	/**
	 * Gets the mail sending id.
	 *
	 * @return the mail sending id
	 */
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="MAIL_SENDING_ID", unique = true, nullable = false)
	public Integer getMailSendingId() {
		return this.mailSendingId;
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
	@Lob
	public String getContent() {
		return this.content;
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
	@Column(name="HOSPITAL_REGISTER_ID")
	public Integer getHospitalRegisterId() {
		return this.hospitalRegisterId;
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
	@Column(name="MAIL_TEMPLATE_ID")
	public Integer getMailTemplateId() {
		return this.mailTemplateId;
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
	@Column(name="SENDING_BCC")
	public String getSendingBcc() {
		return this.sendingBcc;
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
	@Column(name="SENDING_CC")
	public String getSendingCc() {
		return this.sendingCc;
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
	@Column(name="SENDING_STATUS")
	public BigDecimal getSendingStatus() {
		return this.sendingStatus;
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
	@Column(name="SENDING_TO")
	public String getSendingTo() {
		return this.sendingTo;
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
		return this.subject;
	}

	/**
	 * Sets the subject.
	 *
	 * @param subject the new subject
	 */
	public void setSubject(String subject) {
		this.subject = subject;
	}

	/* (non-Javadoc)
	 * @see java.lang.Object#toString()
	 */
	@Override
	public String toString() {
		return "MailSending [mailSendingId=" + mailSendingId + ", content="
				+ content + ", hospitalRegisterId=" + hospitalRegisterId
				+ ", mailTemplateId=" + mailTemplateId + ", sendingBcc="
				+ sendingBcc + ", sendingCc=" + sendingCc + ", sendingStatus="
				+ sendingStatus + ", sendingTo=" + sendingTo + ", subject="
				+ subject + "]";
	}

}