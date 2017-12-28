package nta.sfd.core.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.Table;

import nta.sfd.core.model.MailTemplateModel;

/**
 * The Class MailTemplate.
 *
 * @author MinhLS
 * @crtDate 2015/07/02
 */
@Entity
@Table(name="MAIL_TEMPLATE")
public class MailTemplate extends BaseEntity<MailTemplateModel> {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 1L;
	
	/** The mail template id. */
	private Integer mailTemplateId;
	
	/** The content. */
	private String content;
	
	/** The locale. */
	private String locale;
	
	/** The subject. */
	private String subject;
	
	/** The template code. */
	private String templateCode;
	
	private String language;

	/**
	 * Instantiates a new mail template.
	 */
	public MailTemplate() {
		super(MailTemplateModel.class);
	}

	/**
	 * Gets the mail template id.
	 *
	 * @return the mail template id
	 */
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="MAIL_TEMPLATE_ID", unique = true, nullable = false)
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
	 * Gets the locale.
	 *
	 * @return the locale
	 */
	@Column(name = "LOCALE", nullable = false, length = 16)
	public String getLocale() {
		return this.locale;
	}

	/**
	 * Sets the locale.
	 *
	 * @param locale the new locale
	 */
	public void setLocale(String locale) {
		this.locale = locale;
	}

	/**
	 * Gets the subject.
	 *
	 * @return the subject
	 */
	@Column(name = "SUBJECT", nullable = false, length = 256)
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

	/**
	 * Gets the template code.
	 *
	 * @return the template code
	 */
	@Column(name="TEMPLATE_CODE", nullable = false, length = 32)
	public String getTemplateCode() {
		return this.templateCode;
	}

	/**
	 * Sets the template code.
	 *
	 * @param templateCode the new template code
	 */
	public void setTemplateCode(String templateCode) {
		this.templateCode = templateCode;
	}
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

	/* (non-Javadoc)
	 * @see java.lang.Object#toString()
	 */
	@Override
	public String toString() {
		return "MailTemplate [mailTemplateId=" + mailTemplateId + ", content="
				+ content + ", locale=" + locale + ", subject=" + subject
				+ ", templateCode=" + templateCode + "]";
	}
}