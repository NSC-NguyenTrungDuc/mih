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
 * The persistent class for the mail_template database table.
 * 
 */
@Entity
@Table(name = "mail_template")
@NamedQuery(name = "MailTemplate.findAll", query = "SELECT m FROM MailTemplate m")
public class MailTemplate implements Serializable {
	private static final long serialVersionUID = 1L;
	private Integer mailTemplateId;
	private BigDecimal activeFlg;
	private String content;
	private Timestamp created;
	private String hospitalId;
	private String locale;
	private String subject;
	private String templateCode;
	private BigDecimal templateType;
	private Timestamp updated;

	public MailTemplate() {
	}

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "mail_template_id", unique = true, nullable = false)
	public Integer getMailTemplateId() {
		return this.mailTemplateId;
	}

	public void setMailTemplateId(Integer mailTemplateId) {
		this.mailTemplateId = mailTemplateId;
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

	@Column(name = "hospital_id")
	public String getHospitalId() {
		return this.hospitalId;
	}

	public void setHospitalId(String hospitalId) {
		this.hospitalId = hospitalId;
	}

	public String getLocale() {
		return this.locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getSubject() {
		return this.subject;
	}

	public void setSubject(String subject) {
		this.subject = subject;
	}

	@Column(name = "template_code")
	public String getTemplateCode() {
		return this.templateCode;
	}

	public void setTemplateCode(String templateCode) {
		this.templateCode = templateCode;
	}

	@Column(name = "template_type")
	public BigDecimal getTemplateType() {
		return this.templateType;
	}

	public void setTemplateType(BigDecimal templateType) {
		this.templateType = templateType;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}