package nta.mss.service.impl;

import java.io.UnsupportedEncodingException;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Async;
import org.springframework.scheduling.annotation.EnableAsync;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.mss.entity.MailTemplate;
import nta.mss.info.MailInfo;
import nta.mss.info.SmsInfo;
import nta.mss.misc.common.ClickatellHttp;
import nta.mss.misc.common.LanguageUtils;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssNumberUtils;
import nta.mss.misc.common.UnicodeUtils;
import nta.mss.misc.enums.HospitalLocale;
import nta.mss.misc.enums.SendType;
import nta.mss.repository.MailTemplateRepository;
import nta.mss.service.IHospitalService;
import nta.mss.service.ISmsService;

@Service
@EnableAsync
@Transactional
public class SmsService implements ISmsService {
	private static final Logger LOG = LogManager.getLogger(SmsService.class);
	private MailTemplateRepository mailTemplateRepository;
	private Mapper mapper;
	MailService mailService = new MailService();

	@Autowired
	public SmsService(Mapper mapper, MailTemplateRepository mailTemplateRepository) {
		this.mapper = mapper;
		this.mailTemplateRepository = mailTemplateRepository;
	}

	public SmsService() {
		super();
	}

	public SmsService(MailTemplateRepository mailTemplateRepository, Mapper mapper, MailService mailService) {
		super();
		this.mailTemplateRepository = mailTemplateRepository;
		this.mapper = mapper;
		this.mailService = mailService;
	}

	@Override
	@Async
	public void sendSms(String templateCode, String locale, SmsInfo smsInfo, Integer hospitalId,
			String recieverNumber) {

		LOG.info("[Start] Send SMS");
		LOG.debug("Send SMS. templateCode = " + templateCode + " ,locale = " + locale);
		MailTemplate mailTemplate = new MailTemplate();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(templateCode, locale,
				hospitalId, SendType.SMS.toInt());
		if (!CollectionUtils.isEmpty(mailTemplateList)) {
			mailTemplate = mailTemplateList.get(0);
		}
		if (smsInfo != null) {
			String body = "";
			try {
				Map<String, Object> templateVariables = new HashMap<String, Object>();
				templateVariables.put("smsInfo", smsInfo);
				body = mailService.getEmailBody(mailTemplate.getContent(), templateVariables);
				LOG.debug("Before :Send SMS. body: " + body + " ,smsInfo: " + smsInfo.toString());
				sendInfoSms(body, recieverNumber, null, locale);
			} catch (Exception e) {
				LOG.info("Send sms not success!");
			}
			LOG.info("[End] Send SMS");
		}

	}

	public void sendInfoSms(String sms, String recieverNumber, String sender, String locale) throws UnsupportedEncodingException {

		ClickatellHttp click = null;
		String userName = null;
		String apiId = null;
		String password = null;
		String recieverNo;
		String message;
		try {
			userName = MssConfiguration.getInstance().getSmsApiUserName();
			apiId = MssConfiguration.getInstance().getSmsApiId();
			password = MssConfiguration.getInstance().getSmsApiPassword();
		} catch (Exception e2) {
			LOG.error("error MssconfigPath" + e2);
		}
		click = new ClickatellHttp(userName, apiId, password);
		if (locale.equalsIgnoreCase("vi")) {
			sms = LanguageUtils.unAccent(sms);
		}else if(locale.equalsIgnoreCase("ja")) {
			sms= UnicodeUtils.toUnicode(sms);
		}
		recieverNo = MssNumberUtils.checkLocaleNumber(recieverNumber);
		if (recieverNo == null) {
			recieverNo = MssNumberUtils.StandardNumber(recieverNumber, locale);
		}
		// send SMS
		try {
			ClickatellHttp.Message response ;
			if (locale.equalsIgnoreCase("ja")){
				response = click.sendUnicodeMessage(recieverNo, sms, "1");	
			}else{
			    response = click.sendMessage(recieverNo, sms);
			}
			LOG.debug("Send SMS to:" + recieverNo + " Content: " + sms);
			LOG.debug("ClickATell status:" + response.toString() + " Content:" + response.content);
		} catch (Exception e) {
			LOG.error("Cannot connect to ClickATell-API");
		}

	}

}
