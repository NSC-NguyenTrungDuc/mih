package nta.med.ext.phr.service.impl;

import java.io.File;
import java.io.StringWriter;
import java.util.List;

import javax.annotation.Resource;
import javax.mail.internet.MimeMessage;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;
import org.apache.velocity.context.Context;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.io.FileSystemResource;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.MimeMessageHelper;
import org.springframework.mail.javamail.MimeMessagePreparator;
import org.springframework.scheduling.annotation.EnableAsync;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrMail;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.MailRepository;
import nta.med.ext.phr.model.MailModel;
import nta.med.ext.phr.service.MailService;

/**
 * @author DEV-TiepNM
 */
@Service
@Transactional
//@Transactional(value = DataSources.PHR)
@EnableAsync
public class MailServiceImpl implements MailService {
	
	private static final Log LOGGER = LogFactory.getLog(MailServiceImpl.class); 
	
    @Autowired
    private JavaMailSender mailSender;

    @Autowired
    private SimpleMailMessage templateMessage;
    
	@Resource
	private MailRepository mailRepository;
	
    public void send(final String subject, final List<String> toList, final String body, final boolean html) {
        MimeMessagePreparator preparator = new MimeMessagePreparator() {
            public void prepare(MimeMessage mimeMessage) throws Exception {
                MimeMessageHelper message = new MimeMessageHelper(mimeMessage, "UTF-8");
                String[] toArray = toList.toArray(new String[toList.size()]);
                message.setTo(toArray);
                message.setFrom(templateMessage.getFrom());
                message.setSubject(subject);

                message.setText(body, html);
            }
        };
        mailSender.send(preparator);

    }
    
    public void sendMultipart(final String subject, 
    						  final List<String> toList, 
    						  final String body, 
    						  final boolean html, 
    						  final String imgPath,
    						  final String imgIdentifier){
    	
    	MimeMessagePreparator preparator = new MimeMessagePreparator() {
            public void prepare(MimeMessage mimeMessage) throws Exception {
            	MimeMessageHelper message = new MimeMessageHelper(mimeMessage, true, "UTF-8");
                String[] toArray = toList.toArray(new String[toList.size()]);
                message.setTo(toArray);
                message.setFrom(templateMessage.getFrom());
                message.setSubject(subject);

                message.setText(body, html);
                
            	//String path = new File(imgPath).getAbsolutePath();
                FileSystemResource res = new FileSystemResource(new File(imgPath));
                message.addInline(imgIdentifier, res);            }
        };
        mailSender.send(preparator);
    }
    
    public String prepareEmailBody(String mailTemplate, String registerName, String confirmLink, String email, String password){
    	StringWriter writer = new StringWriter();
    	
    	try {
    		Context context = new VelocityContext();
    		context.put("registerName", registerName);
    		context.put("confirmLink", confirmLink);
    		context.put("email", email);
    		context.put("password", password);
    		
    		boolean result = Velocity.evaluate(context, writer, "", mailTemplate);
            return result ? writer.toString() : "";
		} finally {
			try {
				writer.close();
			} catch (Exception e) {
				LOGGER.error(e.getMessage(), e);
			}
		}
    }
    
    public MailModel getMailTemplate(String type, String locale){
    	MailModel mailModel = new MailModel();
    	List<PhrMail> listPhrMail = mailRepository.findByTypeAndLocale(type, locale);
    	if(!CollectionUtils.isEmpty(listPhrMail)){
    		BeanUtils.copyProperties(listPhrMail.get(0), mailModel, Language.JAPANESE.toString());
    	}
    	
    	return mailModel;
    }
}
