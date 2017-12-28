package nta.mss.service;

import nta.mss.info.MailInfo;
import nta.mss.info.SmsInfo;

public interface ISmsService {

	public void sendSms(String templateCode, String locale, SmsInfo smsInfo, Integer hospitalId,
			String recieverNumber);

}
