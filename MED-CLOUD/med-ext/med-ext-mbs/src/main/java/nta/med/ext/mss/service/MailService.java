package nta.med.ext.mss.service;

import java.util.List;

import nta.med.ext.mss.model.MailInfoModel;

public interface MailService {

	/**
	 * Send mail.
	 * 
	 * @param templateCode
	 *            the template code
	 * @param locale
	 *            the locale
	 * @param mailInfo
	 *            the mail info
	 * @param toList
	 *            the to list
	 * @param patientId
	 *            the patient id
	 * @param reservationId
	 *            the reservation id
	 */
	public void sendMail(String templateCode, String locale, MailInfoModel mailInfo, List<String> toList, Integer patientId,
			Integer reservationId, Integer hospitalId, String bccEmail, String domainName);
}
