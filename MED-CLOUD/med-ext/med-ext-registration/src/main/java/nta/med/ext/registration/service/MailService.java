package nta.med.ext.registration.service;

import nta.med.data.model.ihis.adma.MailInfo;

public interface MailService {
	public void sendMail(String templateCode, String language, MailInfo mailInfo, String[] email, String vpnPath);
}
