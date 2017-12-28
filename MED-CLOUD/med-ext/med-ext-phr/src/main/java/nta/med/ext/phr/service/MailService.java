package nta.med.ext.phr.service;

import java.util.List;

import nta.med.ext.phr.model.MailModel;

/**
 * @author DEV-TiepNM
 */
public interface MailService {
    public void send(final String subject, final List<String> toList, final String body, final boolean html);
    
    public void sendMultipart(final String subject, final List<String> toList, final String body, final boolean html, final String imgPath, final String imgIdentifier);
    
    public String prepareEmailBody(String mailTemplate, String registerName, String confirmLink, String email, String password);
    
    public MailModel getMailTemplate(String type, String locale);
}
