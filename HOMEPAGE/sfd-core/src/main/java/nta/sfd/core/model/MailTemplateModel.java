package nta.sfd.core.model;import nta.sfd.core.entity.MailTemplate;

import org.hibernate.validator.constraints.NotEmpty;


/** * The Class MailTemplateModel. * * @author MinhLS * @crtDate 2015/07/02 */public class MailTemplateModel extends BaseModel<MailTemplate> {
		/** The Constant serialVersionUID. */	private static final long serialVersionUID = 1L;
		/** The mail template id. */	private Integer mailTemplateId;
		/** The content. */	private String content;
		/** The locale. */	private String locale;
		/** The subject. */	@NotEmpty
	private String subject;
		/** The template code. */	@NotEmpty
	private String templateCode;
	
	/**
	 * Instantiates a new mail template model.
	 */
	public MailTemplateModel() {
		super(MailTemplate.class);
	}
	
	/**	 * Gets the mail template id.	 *	 * @return the mail template id	 */	public Integer getMailTemplateId() {
		return mailTemplateId;
	}

	/**	 * Sets the mail template id.	 *	 * @param mailTemplateId the new mail template id	 */	public void setMailTemplateId(Integer mailTemplateId) {
		this.mailTemplateId = mailTemplateId;
	}

	/**	 * Gets the content.	 *	 * @return the content	 */	public String getContent() {
		return content;
	}

	/**	 * Sets the content.	 *	 * @param content the new content	 */	public void setContent(String content) {
		this.content = content;
	}

	/**	 * Gets the locale.	 *	 * @return the locale	 */	public String getLocale() {
		return locale;
	}

	/**	 * Sets the locale.	 *	 * @param locale the new locale	 */	public void setLocale(String locale) {
		this.locale = locale;
	}

	/**	 * Gets the subject.	 *	 * @return the subject	 */	public String getSubject() {
		return subject;
	}

	/**	 * Sets the subject.	 *	 * @param subject the new subject	 */	public void setSubject(String subject) {
		this.subject = subject;
	}

	/**	 * Gets the template code.	 *	 * @return the template code	 */	public String getTemplateCode() {
		return templateCode;
	}

	/**	 * Sets the template code.	 *	 * @param templateCode the new template code	 */	public void setTemplateCode(String templateCode) {
		this.templateCode = templateCode;
	}
}
