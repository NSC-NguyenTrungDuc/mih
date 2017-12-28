package nta.med.service.ihis.handler.nuro;

import java.io.IOException;
import java.io.StringWriter;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;
import org.apache.velocity.context.Context;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.IhisMailTemplate;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.IhisMailTemplateRepository;
import nta.med.data.model.ihis.adma.MailInfo;
import nta.med.service.ihis.handler.system.MailServiceImpl;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.BIL0102U00GetMailTemplateRequest;
import nta.med.service.ihis.proto.NuroServiceProto.BIL0102U00GetMailTemplateResponse;

@Service
@Scope("prototype")
public class BIL0102U00GetMailTemplateHandler extends ScreenHandler<NuroServiceProto.BIL0102U00GetMailTemplateRequest, NuroServiceProto.BIL0102U00GetMailTemplateResponse>{	
	private static final Log LOGGER = LogFactory.getLog(BIL0102U00GetMailTemplateHandler.class);

	@Resource
	private IhisMailTemplateRepository ihisMailTemplateRepository;
	
	@Override
	@Transactional(readOnly = true)
	public BIL0102U00GetMailTemplateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BIL0102U00GetMailTemplateRequest request) throws Exception {
		NuroServiceProto.BIL0102U00GetMailTemplateResponse.Builder response = NuroServiceProto.BIL0102U00GetMailTemplateResponse.newBuilder();
		String locale = getLanguage(vertx, sessionId);
		String hospCode = getHospitalCode(vertx, sessionId);
		Map<String, Object> templateVariables = new HashMap<String, Object>();
		List<IhisMailTemplate> listMialTemplate = ihisMailTemplateRepository.findByMailTemplate("SEND_PAYMENT", locale);
		if (!CollectionUtils.isEmpty(listMialTemplate)) {
			IhisMailTemplate mailTemplate = listMialTemplate.get(0);
			response.setMailTemplateId(mailTemplate.getMailTemplateId().toString());
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
			templateVariables.put("mailInfo", mailInfo);
			String subject = getEmailBody(mailTemplate.getSubject(), templateVariables);
			String content = getEmailBody(mailTemplate.getContent(), templateVariables);
			response.setSubject(subject);
			response.setContent(content);
		}
		return response.build();
	}
	
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
	            	LOGGER.error(e.getMessage(), e);
	            }
	        }
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
	 
	 private String getJubsuTime(String jubsuTime) {
		 String jubsuTime1 = jubsuTime.substring(0, 2);
		 String jubsuTime2 = jubsuTime.substring(2, jubsuTime.length());
		 return jubsuTime1 + ":" + jubsuTime2;
	 }
}
