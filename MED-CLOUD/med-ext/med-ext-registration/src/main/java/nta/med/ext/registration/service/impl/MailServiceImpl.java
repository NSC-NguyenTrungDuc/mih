package nta.med.ext.registration.service.impl;



import nta.med.core.domain.hp.HpMailTemplate;
import nta.med.data.dao.regis.MailTemplateRepository;
import nta.med.data.model.ihis.adma.MailInfo;
import nta.med.ext.registration.service.MailService;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;
import org.apache.velocity.context.Context;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.io.FileSystemResource;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.MimeMessageHelper;
import org.springframework.mail.javamail.MimeMessagePreparator;
import org.springframework.scheduling.annotation.Async;
import org.springframework.scheduling.annotation.EnableAsync;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.mail.internet.MimeMessage;
import java.io.File;
import java.io.IOException;
import java.io.StringWriter;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Service
@EnableAsync
@Transactional()
public class MailServiceImpl implements MailService {
	private static final Logger LOG = LogManager.getLogger(MailServiceImpl.class);
	/** The mail sender. */
	private final JavaMailSender mailSender;
	
	/** The template message. */
	private final SimpleMailMessage templateMessage;
	
	/** The mail template repository. */
	private MailTemplateRepository mailTemplateRepository;
	
	@Autowired
	public MailServiceImpl(JavaMailSender mailSender, SimpleMailMessage templateMessage, MailTemplateRepository mailTemplateRepository) {
		this.mailSender = mailSender;
		this.templateMessage = templateMessage;
		this.mailTemplateRepository = mailTemplateRepository;
	}
	
	/**
	 * Instantiates a new mail service.
	 */
	public MailServiceImpl(){
		mailSender = null;
		templateMessage = null;
	}
	
	/**
	 * Constructor.
	 * 
	 * @param mailSender
	 *            the mail sender
	 * @param templateMessage
	 *            the template message
	 */
	public MailServiceImpl(JavaMailSender mailSender, SimpleMailMessage templateMessage) {
		this.mailSender = mailSender;
		this.templateMessage = templateMessage;
	}
	
	@Override
	@Async
	public void sendMail(String templateCode, String language, MailInfo mailInfo, String[] email, String vpnPath) {
		try {
			Map<String, Object> templateVariables = new HashMap<String, Object>();
			HpMailTemplate mailTemplate = new HpMailTemplate();
	        templateVariables.put("mailInfo", mailInfo);
	        List<HpMailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(templateCode, language );
			if(!CollectionUtils.isEmpty(mailTemplateList)){
				mailTemplate = mailTemplateList.get(0);
			}
			String body = getEmailBody(mailTemplate.getContent(), templateVariables);
			String subject = getEmailBody(mailTemplate.getSubject(), templateVariables);
			
			send(subject, email, body, true, templateVariables, vpnPath);
			
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
		}
	}
	
    /**
	 * Gets the email body.
	 * 
	 * @param templateContent
	 *            the template content
	 * @param hTemplateVariables
	 *            the h template variables
	 * @return the email body
	 */
    private String getEmailBody(String templateContent, final Map<String, Object> hTemplateVariables) {
    	StringWriter writer = new StringWriter();
        try{
            Context context = new VelocityContext();
            for(Map.Entry<String, Object> entry : hTemplateVariables.entrySet()){
                context.put(entry.getKey(), entry.getValue());
            }
            boolean result = Velocity.evaluate(context, writer, "", templateContent);
            return result ? writer.toString() : "";
            
        } finally {
            try {
                writer.close();
            } catch (IOException e) {
                LOG.error(e.getMessage(), e);
            }
        }
    }
    
    /**
	 * Send.
	 * 
	 * @param subject
	 *            the subject
	 *            the to list
	 * @param body
	 *            the body
	 * @param html
	 *            the html
	 * @param hTemplateVariables
	 *            the h template variables
	 */
    private void send(final String subject, final String[] email, final String body, final boolean html, final Map<String, Object> hTemplateVariables, final String vpnPath) {
        MimeMessagePreparator preparator = new MimeMessagePreparator() {
            public void prepare(MimeMessage mimeMessage) throws Exception {
                MimeMessageHelper message = new MimeMessageHelper(mimeMessage, true, "UTF-8");
                LOG.debug("Send email to: " + Arrays.toString(email));
                message.setTo(email);
                message.setFrom(templateMessage.getFrom());
                message.setSubject(subject);
                if(templateMessage.getBcc() != null){
                    message.setBcc(templateMessage.getBcc());
                }
//              attach file
                try {
					if(!StringUtils.isEmpty(vpnPath)){
						 File folder = new File(vpnPath);
					     File[] listOfCert = folder.listFiles();
					     for(int i = 0; i < listOfCert.length; i++){
					     	if(listOfCert[i].isFile()){
					     		FileSystemResource file =  new FileSystemResource(folder + File.separator + listOfCert[i].getName());
					     		message.addAttachment(file.getFilename(), file);
					     	}
					     }
					}
				} catch (Exception e) {
					LOG.error("attach file to email Exception " + e.getMessage(), e);
				}
               
                message.setText(body, html);
            }
        };
        mailSender.send(preparator);
        LOG.info("Send email is success");
    }

}
