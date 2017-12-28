package nta.med.service.ihis.handler.system;

import nta.med.data.model.ihis.adma.MailInfo;

public interface MailService {
	public void sendMail(String templateCode, String hospCode, String language, MailInfo mailInfo, String email, String vpnPath);
}
