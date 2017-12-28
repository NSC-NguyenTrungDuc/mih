package nta.sfd.core.service.impl;

import java.io.File;
import java.io.IOException;
import java.io.StringWriter;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.regex.Pattern;

import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;
import org.apache.velocity.context.Context;
import org.dozer.Mapper;
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
import org.springframework.util.StringUtils;

import nta.sfd.core.entity.MailTemplate;
import nta.sfd.core.info.MailInfo;
import nta.sfd.core.jpa.DataSources;
import nta.sfd.core.misc.common.MedConfiguration;
import nta.sfd.core.repository.main.MailTemplateRepository;
import nta.sfd.core.service.IMailService;

/**
 * The Class MailService.
 *
 * @author MinhLS
 * @crtDate 2015/07/02
 */
@Service
@EnableAsync
@Transactional(value = DataSources.MAIN)
public class MailService implements IMailService{
	
	/** The Constant LOG. */
	private static final Logger LOG = LogManager.getLogger(MailService.class);
	
	/** The Constant EMAIL_PATTERN. */
	private static final Pattern EMAIL_PATTERN = Pattern.compile("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$");
	
	/** The mapper. */
	private Mapper mapper;
	
	/** The mail sender. */
	private final JavaMailSender mailSender;
	
	/** The template message. */
	private final SimpleMailMessage templateMessage;
	
	/** The mail template repository. */
	private MailTemplateRepository mailTemplateRepository;

	
	/**
	 * Instantiates a new mail service.
	 *
	 * @param mapper            the mapper
	 * @param mailSender            the mail sender
	 * @param templateMessage            the template message
	 */
	@Autowired
	public MailService(Mapper mapper, JavaMailSender mailSender, SimpleMailMessage templateMessage, MailTemplateRepository mailTemplateRepository) {
		this.mapper = mapper;
		this.mailSender = mailSender;
		this.templateMessage = templateMessage;
		this.mailTemplateRepository = mailTemplateRepository;
	}
	
	/**
	 * Instantiates a new mail service.
	 */
	public MailService(){
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
	public MailService(JavaMailSender mailSender, SimpleMailMessage templateMessage) {
		this.mailSender = mailSender;
		this.templateMessage = templateMessage;
	}
	
	@Override
	@Async
	public void sendMail(String templateCode, String language, MailInfo mailInfo, List<String> toList, String vpnPath) {
		try {
			// set company name
			mailInfo.setCompanyName(MedConfiguration.getInstance().getCompanyName());
			
			MailTemplate mailTemplate = mailTemplateRepository.findByMailTemplate(templateCode, language);
		
			Map<String, Object> templateVariables = new HashMap<String, Object>();
	        templateVariables.put("mailInfo", mailInfo);
	        
			String body = getEmailBody(mailTemplate.getContent(), templateVariables);
			String subject = getEmailBody(mailTemplate.getSubject(), templateVariables);
			
			send(subject, toList, body, true, templateVariables, vpnPath);
//			sendWithActachFile(subject, toList, body, true, templateVariables);
			
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
	 * @param toList
	 *            the to list
	 * @param body
	 *            the body
	 * @param html
	 *            the html
	 * @param hTemplateVariables
	 *            the h template variables
	 */
    private void send(final String subject, final List<String> toList, final String body, final boolean html, final Map<String, Object> hTemplateVariables, final String vpnPath) {
        MimeMessagePreparator preparator = new MimeMessagePreparator() {
            public void prepare(MimeMessage mimeMessage) throws Exception {
                MimeMessageHelper message = new MimeMessageHelper(mimeMessage, true, "UTF-8");
                String[] toArray = toList.toArray(new String[toList.size()]);
                LOG.debug("Send email to: " + Arrays.toString(toArray));
                message.setTo(toArray);
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
//        LOG.info(String.format("Sent e-mail to '%s'.", toList.toString()));
    }
    
//  send email with attachFile  
//    private void sendWithActachFile(final String subject, final List<String> toList, final String body, final boolean html, final Map<String, Object> hTemplateVariables) {
//        MimeMessagePreparator preparator = new MimeMessagePreparator() {
//            public void prepare(MimeMessage mimeMessage) throws Exception {
//                MimeMessageHelper message = new MimeMessageHelper(mimeMessage, true, "UTF-8");
//                String[] toArray = toList.toArray(new String[toList.size()]);
//                LOG.debug("Send email to: " + toArray[0].toString());
//                message.setTo(toArray);
//                message.setFrom(templateMessage.getFrom());
//                message.setSubject(subject);
//                if(templateMessage.getBcc() != null){
//                    message.setBcc(templateMessage.getBcc());
//                }
////              attach file
//                File folder = new File(MedConfiguration.getInstance().getVpnCertFolder() + File.separator + "K01");
//                File[] listOfCert = folder.listFiles();
//                for(int i = 0; i < listOfCert.length; i++){
//                	if(listOfCert[i].isFile()){
//                		FileSystemResource file =  new FileSystemResource(folder + File.separator + listOfCert[i].getName());
//                		message.addAttachment(file.getFilename(), file);
//                	}
//                }
//                
//                message.setText(body, html);
//            }
//        };
//        mailSender.send(preparator);
//        LOG.info("Send email is success");
////        LOG.info(String.format("Sent e-mail to '%s'.", toList.toString()));
//    }
    
}
