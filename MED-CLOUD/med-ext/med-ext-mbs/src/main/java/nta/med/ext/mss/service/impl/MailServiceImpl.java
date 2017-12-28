package nta.med.ext.mss.service.impl;

import java.io.IOException;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.mail.internet.MimeMessage;

import org.apache.commons.beanutils.BeanUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;
import org.apache.velocity.context.Context;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.MimeMessageHelper;
import org.springframework.mail.javamail.MimeMessagePreparator;
import org.springframework.scheduling.annotation.Async;
import org.springframework.scheduling.annotation.EnableAsync;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.mss.MailSending;
import nta.med.core.domain.mss.MailTemplate;
import nta.med.core.glossary.ActiveFlag;
import nta.med.core.glossary.MailSendingStatus;
import nta.med.core.glossary.ReadingFlg;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.mss.MailSendingRepository;
import nta.med.data.dao.mss.MailTemplateRepository;
import nta.med.ext.mss.model.MailInfoModel;
import nta.med.ext.mss.service.MailService;

/**
 * The Class MailService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Service
@EnableAsync
@Transactional
public class MailServiceImpl implements MailService{
	private static final Logger LOG = LogManager.getLogger(MailServiceImpl.class);
	private final JavaMailSender mailSender;
	private final SimpleMailMessage templateMessage;
	private MailTemplateRepository mailTemplateRepository;
	private MailSendingRepository mailSendingRepository;

	
	/**
	 * Instantiates a new mail service.
	 * 
	 * @param mapper
	 *            the mapper
	 * @param mailSender
	 *            the mail sender
	 * @param templateMessage
	 *            the template message
	 * @param mailTemplateRepository
	 *            the mail template repository
	 * @param mailSendingRepository
	 *            the mail sending repository
	 */
	@Autowired
	public MailServiceImpl(
			JavaMailSender mailSender, 
			SimpleMailMessage templateMessage,
			MailTemplateRepository mailTemplateRepository, 
			MailSendingRepository mailSendingRepository) {
		this.mailSender = mailSender;
		this.templateMessage = templateMessage;
		this.mailTemplateRepository = mailTemplateRepository;
		this.mailSendingRepository = mailSendingRepository;
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
	public void sendMail(String templateCode, String locale, MailInfoModel mailInfo, List<String> toList, Integer patientId, Integer reservationId, Integer hospitalId, String bccEmail, String domainName) {
		LOG.info("[Start] Send email");
		LOG.debug("Send email. templateCode = " + templateCode + " ,locale = " + locale);
		MailTemplate mailTemplate = new MailTemplate();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(templateCode, locale, hospitalId.toString());
		if(!CollectionUtils.isEmpty(mailTemplateList)){
			mailTemplate = mailTemplateList.get(0);
		}
		//save mail sending
		List<MailSending> mailSendingList = new ArrayList<>();
		MailSending mailSending = new MailSending();
		mailSending.setMailTemplateId(mailTemplate.getMailTemplateId());
		mailSending.setPatientId(patientId);
		mailSending.setReservationId(reservationId);
		mailSending.setReadingFlg(ReadingFlg.UNREAD.toInt());
		mailSending.setSendingBcc( StringUtils.join(templateMessage.getBcc(),";"));
		mailSending.setSendingCc( StringUtils.join(templateMessage.getCc(),";"));
		try {
			Map<String, Object> templateVariables = new HashMap<String, Object>();
			// set server address
			mailInfo.setServerAddress(domainName);
	        templateVariables.put("mailInfo", mailInfo);
	        
			String body =  getEmailBody(mailTemplate.getContent(), templateVariables);
			mailSending.setContent(body);
			String subject = getEmailBody(mailTemplate.getSubject(), templateVariables);
			mailSending.setSubject(subject);
			send(subject, toList, body, true, templateVariables, bccEmail);
			mailSending.setSendingStatus(CommonUtils.parseBigDecimal(MailSendingStatus.SUCCESS.getValue()));
		} catch (Exception e) {
			LOG.error("ERROR: " + e.getMessage(), e);
			mailSending.setSendingStatus(CommonUtils.parseBigDecimal(MailSendingStatus.FAIL.getValue()));
		}
		if(toList != null && !toList.isEmpty()) {
			for(int i = 0; i < toList.size(); i ++) {
				MailSending item;
				try {
					item = (MailSending) BeanUtils.cloneBean(mailSending);
					item.setSendingTo(toList.get(i));
					item.setActiveFlg(CommonUtils.parseBigDecimal(ActiveFlag.INACTIVE.getValue()));
					mailSendingList.add(item);
				} catch (Exception e) {
					LOG.error("CLONE MAIL SENDING " + e.getMessage(), e);
				}
			}
		}
		if(!mailSendingList.isEmpty()) {
			LOG.info("[Start] Save mail sending to table mail_sending");
			mailSendingRepository.save(mailSendingList);
			LOG.info("[End] Save mail sending to table mail_sending");
		}
		LOG.info("[End] Send email");
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
    private void send(final String subject, final List<String> toList, final String body, final boolean html, final Map<String, Object> hTemplateVariables, final String bccEmail) {
        MimeMessagePreparator preparator = new MimeMessagePreparator() {
            public void prepare(MimeMessage mimeMessage) throws Exception {
                MimeMessageHelper message = new MimeMessageHelper(mimeMessage, "UTF-8");
                String[] toArray = toList.toArray(new String[toList.size()]);
                LOG.debug("Send email to: " + toArray[0].toString());
                message.setTo(toArray);
                message.setFrom(templateMessage.getFrom());
                message.setSubject(subject);
                if(bccEmail != null && !StringUtils.isEmpty(bccEmail)){
                    message.setBcc(bccEmail);
                } else {
                	message.setBcc(templateMessage.getBcc());
                }
                message.setText(body, html);
            }
        };
        mailSender.send(preparator);
        LOG.info("Send email is success");
//        LOG.info(String.format("Sent e-mail to '%s'.", toList.toString()));
    }
}
