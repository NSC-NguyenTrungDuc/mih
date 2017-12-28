package nta.med.core.domain.mss;

import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the mail_sending database table.
 * 
 */
@Entity
@Table(name = "mail_sending")
@NamedQuery(name = "MailSending.findAll", query = "SELECT m FROM MailSending m")
public class MailSending implements Serializable {
	private static final long serialVersionUID = 1L;
	private Integer mailSendingId;
	private BigDecimal activeFlg;
	private String content;
	private Timestamp created;
	private Integer mailListId;
	private Integer mailTemplateId;
	private Integer patientId;
	private Integer readingFlg;
	private Integer reservationId;
	private String sendingBcc;
	private String sendingCc;
	private BigDecimal sendingStatus;
	private String sendingTo;
	private String subject;
	private Timestamp updated;

	public MailSending() {
	}

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "mail_sending_id", unique = true, nullable = false)
	public Integer getMailSendingId() {
		return this.mailSendingId;
	}

	public void setMailSendingId(Integer mailSendingId) {
		this.mailSendingId = mailSendingId;
	}

	@Column(name = "active_flg")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Lob
	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Column(name = "mail_list_id")
	public Integer getMailListId() {
		return this.mailListId;
	}

	public void setMailListId(Integer mailListId) {
		this.mailListId = mailListId;
	}

	@Column(name = "mail_template_id")
	public Integer getMailTemplateId() {
		return this.mailTemplateId;
	}

	public void setMailTemplateId(Integer mailTemplateId) {
		this.mailTemplateId = mailTemplateId;
	}

	@Column(name = "patient_id")
	public Integer getPatientId() {
		return this.patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	@Column(name = "reading_flg")
	public Integer getReadingFlg() {
		return this.readingFlg;
	}

	public void setReadingFlg(Integer readingFlg) {
		this.readingFlg = readingFlg;
	}

	@Column(name = "reservation_id")
	public Integer getReservationId() {
		return this.reservationId;
	}

	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}

	@Column(name = "sending_bcc")
	public String getSendingBcc() {
		return this.sendingBcc;
	}

	public void setSendingBcc(String sendingBcc) {
		this.sendingBcc = sendingBcc;
	}

	@Column(name = "sending_cc")
	public String getSendingCc() {
		return this.sendingCc;
	}

	public void setSendingCc(String sendingCc) {
		this.sendingCc = sendingCc;
	}

	@Column(name = "sending_status")
	public BigDecimal getSendingStatus() {
		return this.sendingStatus;
	}

	public void setSendingStatus(BigDecimal sendingStatus) {
		this.sendingStatus = sendingStatus;
	}

	@Column(name = "sending_to")
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

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}