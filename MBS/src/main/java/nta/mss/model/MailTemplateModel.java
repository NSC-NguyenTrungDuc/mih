package nta.mss.model;

import nta.mss.entity.MailTemplate;

import org.hibernate.validator.constraints.NotEmpty;

/**
 * The Class MailTemplateModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class MailTemplateModel extends BaseModel<MailTemplate> {
	private static final long serialVersionUID = 1L;
	private Integer mailTemplateId;
	private String content;
	private String locale;
	@NotEmpty
	private String subject;
	@NotEmpty
	private String templateCode;
	private Integer sendType;
	private Integer templateType;
	private Integer hospitalId;
	private Integer isNew;
	
	/**
	 * Instantiates a new mail template model.
	 */
	public MailTemplateModel() {
		super(MailTemplate.class);
	}
	
	public Integer getMailTemplateId() {
		return mailTemplateId;
	}

	public void setMailTemplateId(Integer mailTemplateId) {
		this.mailTemplateId = mailTemplateId;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getSubject() {
		return subject;
	}

	public void setSubject(String subject) {
		this.subject = subject;
	}

	public String getTemplateCode() {
		return templateCode;
	}

	public void setTemplateCode(String templateCode) {
		this.templateCode = templateCode;
	}

	/**
	 * @return the templateType
	 */
	public Integer getTemplateType() {
		return templateType;
	}
	

	public Integer getSendType() {
		return sendType;
	}

	public void setSendType(Integer sendType) {
		this.sendType = sendType;
	}

	/**
	 * @param templateType the templateType to set
	 */
	public void setTemplateType(Integer templateType) {
		this.templateType = templateType;
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
