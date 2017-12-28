package nta.sfd.core.service;

import java.util.List;

import nta.sfd.core.info.MailInfo;

/**
 * The Interface IMailService.
 *
 * @author MinhLS
 * @crtDate 2015/07/02
 */
public interface IMailService {
	
	/**
	 * Send mail.
	 *
	 * @param templateCode the template code
	 * @param locale the locale
	 * @param mailInfo the mail info
	 * @param toList the to list
	 * @param patientId the patient id
	 * @param reservationId the reservation id
	 */
	public void sendMail(String templateCode, String language, MailInfo mailInfo, List<String> toList, String vpnPath);
}
