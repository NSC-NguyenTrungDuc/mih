package nta.mss.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.PrePersist;
import javax.persistence.Table;

import nta.mss.misc.enums.MailTemplateType;
import nta.mss.model.MailTemplateModel;

/**
 * The persistent class for the mail_template database table.
 * 
 */
@Entity
@Table(name = "mail_template")
public class MailTemplate extends BaseEntity<MailTemplateModel> {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "mail_template_id", unique = true, nullable = false)
	private Integer mailTemplateId;

	@Lob
	@Column(name = "content")
	private String content;

	private String locale;

	@Column(name = "subject", nullable = false, length = 256)
	private String subject;

	@Column(name = "template_code", nullable = false, length = 32)
	private String templateCode;
	
	@Column(name = "template_type", nullable = false)
	private Integer templateType;
	
	@Column(name = "send_type", nullable = false)
	private Integer sendType;
	
	@Column(name = "hospital_id")
	private Integer hospitalId;
	
	@Column(name = "is_new")
	private Integer isNew;
	/**
	 * Instantiates a new mail template.
	 */
	public MailTemplate() {
		super(MailTemplateModel.class);
	}

	public Integer getMailTemplateId() {
		return this.mailTemplateId;
	}

	public void setMailTemplateId(Integer mailTemplateId) {
		this.mailTemplateId = mailTemplateId;
	}

	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
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

	public String getTemplateCode() {
		return this.templateCode;
	}

	public void setTemplateCode(String templateCode) {
		this.templateCode = templateCode;
	}

	public Integer getTemplateType() {
		return templateType;
	}

	public void setTemplateType(Integer templateType) {
		this.templateType = templateType;
	}
	
	
	
	public Integer getSendType() {
		return sendType;
	}

	public void setSendType(Integer sendType) {
		this.sendType = sendType;
	}

	@PrePersist
	void prePersist() {
		if(templateType == null) {
			templateType = MailTemplateType.CUSTOMIZE_MAIL.toInt();
		}
		if(isNew == null){
			isNew = MailTemplateType.CUSTOMIZE_MAIL.toInt();
		}
	}
	

	@Override
	public String toString() {
		return "MailTemplate [mailTemplateId=" + mailTemplateId + ", content=" + content + ", locale=" + locale
				+ ", subject=" + subject + ", templateCode=" + templateCode + ", templateType=" + templateType
				+ ", sendType=" + sendType + ", hospitalId=" + hospitalId + ", isNew=" + isNew + "]";
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	public Integer getIsNew() {
		return isNew;
	}

	public void setIsNew(Integer isNew) {
		this.isNew = isNew;
	}
	
}