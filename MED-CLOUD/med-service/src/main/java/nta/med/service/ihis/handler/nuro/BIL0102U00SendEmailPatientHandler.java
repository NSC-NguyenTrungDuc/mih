package nta.med.service.ihis.handler.nuro;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.config.Configuration;
import nta.med.core.config.MailInfoConfig;
import nta.med.core.config.SshConfig;
import nta.med.core.domain.adm.IhisMailTemplate;
import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.adm.IhisMailTemplateRepository;
import nta.med.data.dao.medi.adm.LoginExtRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.adma.MailInfo;
import nta.med.service.ihis.handler.system.MailService;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.BIL0102U00SendEmailPatientRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class BIL0102U00SendEmailPatientHandler extends ScreenHandler<NuroServiceProto.BIL0102U00SendEmailPatientRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(BIL0102U00SendEmailPatientHandler.class);
	
	@Resource
    private Adm3200Repository adm3200Repository;
	
	@Resource
	private IhisMailTemplateRepository ihisMailTemplateRepository;
    
    @Resource
    private LoginExtRepository loginExtRepository;
    
    @Resource
    private Bas0001Repository bas0001Repository;
    @Resource
	private SshConfig sshConfig;
    @Resource
    private Configuration configuration;
    @Resource
    private MailService mailService;
    @Resource
    private MailInfoConfig mailInfoConfig;
	
	@Override
	@Transactional(readOnly = true)
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BIL0102U00SendEmailPatientRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		sendEmailInform(hospCode, language, request);
		response.setResult(true);
		response.setMsg("BIL0102_0002");
		return response.build();
	}
	
	private void sendEmailInform(String hospCode, String language, BIL0102U00SendEmailPatientRequest request) {	 
		MailInfo mailInfo = new MailInfo();
		mailInfo.setHospitalCode(hospCode);
		mailInfo.setMailPatient(request.getMailPatient());
		mailInfo.setHospitalName(request.getYoyangName());
		mailInfo.setPatientName(request.getPatientName());
		mailInfo.setNaewonDate(request.getNaewonDate());
		if (!StringUtils.isEmpty(request.getJubsuTime())) {
			mailInfo.setJubsuTime(getJubsuTime(request.getJubsuTime()));
		}
		mailInfo.setTotal(request.getTotal());
		mailInfo.setTotalDiscount(request.getTotalDiscount());
		mailInfo.setTotalPaid(request.getTotalPaid());
		mailInfo.setTotalPaying(request.getTotalPaying());
		if (!StringUtils.isEmpty(request.getNaewonDate())) {
			mailInfo.setExpectDate(getExpectDate(request.getNaewonDate()));
		}
		mailInfo.setAddressHosp(request.getAddressHosp());
		mailInfo.setTelHosp(request.getTelHosp());
		mailInfo.setEmailHosp(request.getEmailHosp());
		
		mailService.sendMail("SEND_PAYMENT", hospCode, language, mailInfo, request.getMailPatient(), "");		
	}
	
	private String getExpectDate(String date) {
		Date expireDate = DateUtil.toDate(date, DateUtil.PATTERN_YYYY_MM_DD);
		SimpleDateFormat sdf = new SimpleDateFormat(DateUtil.PATTERN_YYYY_MM_DD);
		Calendar c = Calendar.getInstance();
		c.setTime(expireDate); 
		c.add(Calendar.DATE, 7); // Adding 7 days
		String output = sdf.format(c.getTime());
		System.out.println(output);
		return output;
	}
	
	private String getMailTemplateCode(String templateCode, String locale) {
		List<IhisMailTemplate> listMialTemplate = ihisMailTemplateRepository.findByMailTemplate("SEND_PAYMENT", locale);
		if (!CollectionUtils.isEmpty(listMialTemplate)) {
			return listMialTemplate.get(0).getTemplateCode();
		} 
		return "";
	}
	
	private String getJubsuTime(String jubsuTime) {
		 String jubsuTime1 = jubsuTime.substring(0, 2);
		 String jubsuTime2 = jubsuTime.substring(2, jubsuTime.length());
		 return jubsuTime1 + ":" + jubsuTime2;
	 }
}
