package nta.mss.service.impl;

import java.io.IOException;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.regex.Pattern;

import javax.mail.internet.MimeMessage;

import org.apache.commons.beanutils.BeanUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;
import org.apache.velocity.context.Context;
import org.dozer.Mapper;
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

import nta.mss.converter.CsvConverter;
import nta.mss.entity.MailList;
import nta.mss.entity.MailListDetail;
import nta.mss.entity.MailListDetailPK;
import nta.mss.entity.MailSending;
import nta.mss.entity.MailTemplate;
import nta.mss.entity.Patient;
import nta.mss.entity.Reservation;
import nta.mss.info.MailInfo;
import nta.mss.info.MailListDetailInfo;
import nta.mss.info.ReminderMailInfo;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.common.MssFileUtils;
import nta.mss.misc.common.TokenUtils;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.CsvErrorCode;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.MailSendingStatus;
import nta.mss.misc.enums.ReadingFlg;
import nta.mss.misc.enums.SendType;
import nta.mss.model.MailListDetailModel;
import nta.mss.model.MailListModel;
import nta.mss.model.MailTemplateModel;
import nta.mss.repository.MailListDetailRepository;
import nta.mss.repository.MailListRepository;
import nta.mss.repository.MailSendingRepository;
import nta.mss.repository.MailSendingRepositoryCustom;
import nta.mss.repository.MailTemplateRepository;
import nta.mss.repository.PatientRepository;
import nta.mss.service.IMailService;
import nta.mss.validation.RegularExpressionValidateString;

/**
 * The Class MailService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Service
@EnableAsync
@Transactional
public class MailService implements IMailService {
	private static final Logger LOG = LogManager.getLogger(MailService.class);
	private static final Pattern EMAIL_PATTERN = Pattern
			.compile("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$");
	private Mapper mapper;
	// private final VelocityEngine velocityEngine;
	private final JavaMailSender mailSender;
	private final SimpleMailMessage templateMessage;
	private MailTemplateRepository mailTemplateRepository;
	private MailSendingRepository mailSendingRepository;
	private MailSendingRepositoryCustom mailSendingRepositoryCustom;
	private MailListRepository mailListRepository;
	private MailListDetailRepository mailListDetailRepository;
	private PatientRepository patientRepository;

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
	public MailService(Mapper mapper, JavaMailSender mailSender, SimpleMailMessage templateMessage,
			MailTemplateRepository mailTemplateRepository, MailSendingRepository mailSendingRepository,
			MailListRepository mailListRepository, MailListDetailRepository mailListDetailRepository,
			MailSendingRepositoryCustom mailSendingRepositoryCustom, PatientRepository patientRepository) {
		this.mapper = mapper;
		this.mailSender = mailSender;
		this.templateMessage = templateMessage;
		this.mailTemplateRepository = mailTemplateRepository;
		this.mailSendingRepository = mailSendingRepository;
		this.mailListRepository = mailListRepository;
		this.mailListDetailRepository = mailListDetailRepository;
		this.mailSendingRepositoryCustom = mailSendingRepositoryCustom;
		this.patientRepository = patientRepository;
	}

	/**
	 * Instantiates a new mail service.
	 */
	public MailService() {
		// velocityEngine = null;
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
	public MailService(JavaMailSender mailSender, SimpleMailMessage templateMessage) {
		// this.velocityEngine = velocityEngine;
		this.mailSender = mailSender;
		this.templateMessage = templateMessage;
	}

	/**
	 * Gets the all mail templates.
	 *
	 * @return the all mail templates
	 */
	@Override
	public List<MailTemplateModel> getAllMailTemplates() {
		List<MailTemplateModel> mailTemplateModelList = new ArrayList<MailTemplateModel>();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findAll();
		for (MailTemplate mailTemplate : mailTemplateList) {
			mailTemplateModelList.add(mailTemplate.toModel(mapper));
		}
		return mailTemplateModelList;
	}

	/**
	 * Gets the all active mail templates.
	 *
	 * @return the all active mail templates
	 */
	@Override
	public List<MailTemplateModel> getAllActiveMailTemplates() {
		List<MailTemplateModel> mailTemplateModelList = new ArrayList<MailTemplateModel>();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findAllActive(SendType.MAIL.toInt());
		for (MailTemplate mailTemplate : mailTemplateList) {
			mailTemplateModelList.add(mailTemplate.toModel(mapper));
		}
		return mailTemplateModelList;
	}

	/**
	 * Gets the mail template.
	 * 
	 * @param templateCode
	 *            the template code
	 * @param locale
	 *            the locale
	 * @return the mail template
	 */
	@Override
	public MailTemplateModel getMailTemplate(String templateCode, String locale, Integer hospitalId) {

		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(templateCode, locale,
				hospitalId, SendType.MAIL.toInt());
		if (!CollectionUtils.isEmpty(mailTemplateList)) {
			MailTemplate mailTemplate = mailTemplateList.get(0);
			return mailTemplate.toModel(mapper);
		} else {
			return null;
		}
	}

	/**
	 * Gets the mail template by id and locale.
	 *
	 * @param mailTemplateId
	 *            the mail template id
	 * @param locale
	 *            the locale
	 * @return the mail template by id and locale
	 */
	@Override
	public MailTemplateModel getMailTemplateByIdAndLocale(Integer mailTemplateId, String locale, Integer hospitalId) {
		MailTemplate mailTemplate = new MailTemplate();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplateId(mailTemplateId, locale, hospitalId, SendType.MAIL.toInt());
		if (!CollectionUtils.isEmpty(mailTemplateList)) {
			mailTemplate = mailTemplateList.get(0);
		}
		return mailTemplate.toModel(mapper);
	}

	/**
	 * Gets the mail template by id.
	 *
	 * @param mailTemplateId
	 *            the mail template id
	 * @return the mail template by id
	 */
	@Override
	public MailTemplateModel getMailTemplateById(Integer mailTemplateId) {
		MailTemplate mailTemplate = mailTemplateRepository.findOne(mailTemplateId);
		return mailTemplate.toModel(mapper);
	}

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
	@Override
	@Async
	public void sendMail(String templateCode, String locale, MailInfo mailInfo, List<String> toList, Integer patientId,
			Integer reservationId, Integer hospitalId, String bccEmail, String domainName) {
		LOG.info("[Start] Send email");
		LOG.debug("Send email. templateCode = " + templateCode + " ,locale = " + locale);
		MailTemplate mailTemplate = new MailTemplate();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(templateCode, locale,
				hospitalId,SendType.MAIL.toInt());
		if (!CollectionUtils.isEmpty(mailTemplateList)) {
			mailTemplate = mailTemplateList.get(0);
		}
		// save mail sending
		List<MailSending> mailSendingList = new ArrayList<>();
		MailSending mailSending = new MailSending();
		mailSending.setMailTemplateId(mailTemplate.getMailTemplateId());
		Patient patient = new Patient();
		if (patientId != null) {
			patient.setPatientId(patientId);
			mailSending.setPatient(patient);
		}
		Reservation reservation = new Reservation();
		if (reservationId != null) {
			reservation.setReservationId(reservationId);
			mailSending.setReservation(reservation);
		}
		mailSending.setReadingFlg(ReadingFlg.UNREAD.toInt());
		mailSending.setSendingBcc(StringUtils.join(templateMessage.getBcc(), ";"));
		mailSending.setSendingCc(StringUtils.join(templateMessage.getCc(), ";"));
		int count = 0;
		int maxTries = 3;
		while (true) {
			try {
				Map<String, Object> templateVariables = new HashMap<String, Object>();
				// set server address
				mailInfo.setServerAddress(domainName);
				templateVariables.put("mailInfo", mailInfo);

				String body = getEmailBody(mailTemplate.getContent(), templateVariables);
				mailSending.setContent(body);
				String subject = getEmailBody(mailTemplate.getSubject(), templateVariables);
				mailSending.setSubject(subject);
				send(subject, toList, body, true, templateVariables, bccEmail);
				mailSending.setSendingStatus(MailSendingStatus.SUCCESS.toInt());
				break;
			} catch (Exception e) {
				try {
					Thread.sleep(3 * 60 * 1000);
				} catch (InterruptedException e1) {
					e1.printStackTrace();
				}
				if (++count == maxTries) {
					LOG.error("ERROR: " + e.getMessage(), e);
					mailSending.setSendingStatus(MailSendingStatus.FAIL.toInt());
					break;
				}
			}
		}
		if (toList != null && !toList.isEmpty()) {
			for (int i = 0; i < toList.size(); i++) {
				MailSending item;
				try {
					item = (MailSending) BeanUtils.cloneBean(mailSending);
					item.setSendingTo(toList.get(i));
					mailSendingList.add(item);
				} catch (Exception e) {
					LOG.error("CLONE MAIL SENDING " + e.getMessage(), e);
				}
			}
		}
		if (!mailSendingList.isEmpty()) {
			LOG.info("[Start] Save mail sending to table mail_sending");
			mailSendingRepository.save(mailSendingList);
			LOG.info("[End] Save mail sending to table mail_sending");
		}
		LOG.info("[End] Send email");
	}

	@Override
	@Async
	public void sendMail(String templateCode, String locale, MailInfo mailInfo, List<String> toList, Integer hospitalId,
			String bccEmail, String domainName) {
		LOG.info("[Start] Send email");
		LOG.debug("Send email. templateCode = " + templateCode + " ,locale = " + locale);
		List<MailSending> mailSendingList = new ArrayList<>();
		MailTemplate mailTemplate = new MailTemplate();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(templateCode, locale,
				hospitalId,SendType.MAIL.toInt());
		if (!CollectionUtils.isEmpty(mailTemplateList)) {
			mailTemplate = mailTemplateList.get(0);
		}
		if (mailInfo != null && mailInfo.getMailInfoList() != null && !mailInfo.getMailInfoList().isEmpty()) {
			String body = "";
			String subject = "";
			int count = 0;
			int maxTries = 3;
			while (true) {
				try {
					Map<String, Object> templateVariables = new HashMap<String, Object>();
					// set server address
					mailInfo.setServerAddress(domainName);
					templateVariables.put("mailInfo", mailInfo);

					body = getEmailBody(mailTemplate.getContent(), templateVariables);
					subject = getEmailBody(mailTemplate.getSubject(), templateVariables);
					send(subject, toList, body, true, templateVariables, bccEmail);
					break;
				} catch (Exception e) {

					try {
						Thread.sleep(3 * 60 * 1000);
					} catch (InterruptedException e1) {
						e1.printStackTrace();
					}
					if (++count == maxTries) {
						LOG.error("ERROR: " + e.getMessage(), e);
						break;
					}
				}
			}
			// save mail sending
			MailSending mailSending;
			Patient patient;
			Reservation reservation;
			for (MailInfo mail : mailInfo.getMailInfoList()) {
				mailSending = new MailSending();
				mailSending.setMailTemplateId(mailTemplate.getMailTemplateId());

				Integer patientId = mail.getPatientId();
				patient = new Patient();
				if (patientId != null) {
					patient.setPatientId(patientId);
					mailSending.setPatient(patient);
				}
				Integer reservationId = mail.getReservationId();
				reservation = new Reservation();
				if (reservationId != null) {
					reservation.setReservationId(reservationId);
					mailSending.setReservation(reservation);
				}
				mailSending.setReadingFlg(ReadingFlg.UNREAD.toInt());
				mailSending.setSubject(subject);
				mailSending.setSendingBcc(StringUtils.join(templateMessage.getBcc(), ";"));
				mailSending.setSendingCc(StringUtils.join(templateMessage.getCc(), ";"));
				mailSending.setContent(body);
				mailSending.setSendingStatus(MailSendingStatus.SUCCESS.toInt());
				if (toList != null && !toList.isEmpty()) {
					for (int i = 0; i < toList.size(); i++) {
						MailSending item;
						try {
							item = (MailSending) BeanUtils.cloneBean(mailSending);
							item.setSendingTo(toList.get(i));
							mailSendingList.add(item);
						} catch (Exception e) {
							LOG.error("CLONE MAIL SENDING " + e.getMessage(), e);
						}
					}
				}
			}
		}

		if (!mailSendingList.isEmpty()) {
			LOG.info("Save mail sending to table mail_sending");
			mailSendingRepository.save(mailSendingList);
		}
		LOG.info("[End] Send email");
	}

	@Async
	public void sendUserMail(String templateCode, String locale, MailInfo mailInfo, List<String> toList,
			Integer hospitalId, String bccEmail, String domainName) {
		LOG.info("[Start] Send user email");
		LOG.debug("Send email. templateCode = " + templateCode + " ,locale = " + locale);
		MailTemplate mailTemplate = new MailTemplate();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(templateCode, locale,
				hospitalId,SendType.MAIL.toInt());
		if (!CollectionUtils.isEmpty(mailTemplateList)) {
			mailTemplate = mailTemplateList.get(0);
		}
		if (mailInfo != null) {
			String body = "";
			String subject = "";
			int count = 0;
			int maxTries = 3;
			while (true) {
				try {
					Map<String, Object> templateVariables = new HashMap<String, Object>();
					// set server address
					templateVariables.put("mailInfo", mailInfo);

					body = getEmailBody(mailTemplate.getContent(), templateVariables);
					subject = getEmailBody(mailTemplate.getSubject(), templateVariables);
					send(subject, toList, body, true, templateVariables, bccEmail);
					break;
				} catch (Exception e) {

					try {
						Thread.sleep(3 * 60 * 1000);
					} catch (InterruptedException e1) {
						e1.printStackTrace();
					}
					if (++count == maxTries) {
						LOG.error("ERROR: " + e.getMessage(), e);
						break;
					}
				}

			}
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
	public String getEmailBody(String templateContent, final Map<String, Object> hTemplateVariables) {
		StringWriter writer = new StringWriter();
		try {
			Context context = new VelocityContext();
			for (Map.Entry<String, Object> entry : hTemplateVariables.entrySet()) {
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
	private void send(final String subject, final List<String> toList, final String body, final boolean html,
			final Map<String, Object> hTemplateVariables, final String bccEmail) {
		MimeMessagePreparator preparator = new MimeMessagePreparator() {
			public void prepare(MimeMessage mimeMessage) throws Exception {
				MimeMessageHelper message = new MimeMessageHelper(mimeMessage, "UTF-8");
				String[] toArray = toList.toArray(new String[toList.size()]);
				LOG.debug("Send email to: " + toArray[0].toString());
				message.setTo(toArray);
				message.setFrom(templateMessage.getFrom());
				message.setSubject(subject);
				if (bccEmail != null && !StringUtils.isEmpty(bccEmail)) {
					message.setBcc(bccEmail);
				} else {
					message.setBcc(templateMessage.getBcc());
				}
				message.setText(body, html);
			}
		};
		mailSender.send(preparator);
		LOG.info("Send email is success");
		// LOG.info(String.format("Sent e-mail to '%s'.", toList.toString()));
	}

	/**
	 * Gets the mail template repository.
	 * 
	 * @return the mail template repository
	 */
	public MailTemplateRepository getMailTemplateRepository() {
		return mailTemplateRepository;
	}

	/**
	 * Sets the mail template repository.
	 * 
	 * @param mailTemplateRepository
	 *            the new mail template repository
	 */
	public void setMailTemplateRepository(MailTemplateRepository mailTemplateRepository) {
		this.mailTemplateRepository = mailTemplateRepository;
	}

	/**
	 * Gets the mail sending repository.
	 * 
	 * @return the mail sending repository
	 */
	public MailSendingRepository getMailSendingRepository() {
		return mailSendingRepository;
	}

	/**
	 * Sets the mail sending repository.
	 * 
	 * @param mailSendingRepository
	 *            the new mail sending repository
	 */
	public void setMailSendingRepository(MailSendingRepository mailSendingRepository) {
		this.mailSendingRepository = mailSendingRepository;
	}

	/**
	 * Find MailListModel by active flg
	 * 
	 * @param activeFlg
	 * @return List
	 */
	public List<MailListModel> getMailListByActiveFlg(Integer activeFlg, Integer hospitalId) {
		List<MailList> mailLists = this.mailListRepository.findMailListActiveByHospitalId(activeFlg, hospitalId);
		List<MailListModel> result = new ArrayList<MailListModel>();
		if (mailLists != null) {
			for (MailList mailList : mailLists) {
				result.add(mailList.toModel(mapper));
			}
		}

		return result;
	}

	/**
	 * @author linh.nguyen.trong
	 * @since 08/08/2014
	 * 
	 *        Save mail list
	 * 
	 * @param mail
	 *            List name
	 * @return
	 * @throws Exception
	 */
	@Transactional
	public MailListModel saveMailList(String mailListName, List<ReminderMailInfo> reminderMailInfos, Integer hospitalId)
			throws Exception {
		MailList mailList = new MailList();
		Integer mailListId = reminderMailInfos.get(0).getMailListId();
		if (mailListId != null) {
			mailList = this.mailListRepository.findOne(mailListId);
		}
		mailList.setMailListName(mailListName);
		mailList.setHospitalId(hospitalId);
		mailList = this.mailListRepository.save(mailList);
		for (ReminderMailInfo rmInfo : reminderMailInfos) {
			saveMailListDetailNew(mailList.getMailListId(), rmInfo.getMail().trim(), rmInfo.getName().trim(),
					rmInfo.getPhone(),hospitalId);
		}
		MailListModel mailListModel = mailList.toModel(mapper);
		mailListModel.setReminderMails(reminderMailInfos);
		return mailListModel;
	}

	/**
	 * @author linh.nguyen.trong
	 * @since 20140811
	 * 
	 *        Save mail list detail
	 * 
	 * @param mailListId
	 * @param email
	 * @param name
	 * @return
	 * @throws Exception
	 */
	public MailListDetail saveMailListDetail(Integer mailListId, String email, String name, String phone)
			throws Exception {
		MailListDetail mailListDetail = new MailListDetail();
		mailListDetail.setId(new MailListDetailPK(mailListId, email));
		mailListDetail.setName(name);
		if (!StringUtils.isBlank(phone)) {
			mailListDetail.setPhone(phone.trim());
		}
		LOG.info("[Save mail list detail] " + mailListDetail.toString());
		return this.mailListDetailRepository.save(mailListDetail);
	}
	
	public MailListDetail saveMailListDetailNew(Integer mailListId, String email, String name, String phone,Integer hospitalId)
			throws Exception {
		MailListDetail mailListDetail = new MailListDetail();
		mailListDetail.setId(new MailListDetailPK(mailListId, email));
		mailListDetail.setName(name);
		mailListDetail.setHospitalId(hospitalId);
		if (!StringUtils.isBlank(phone)) {
			mailListDetail.setPhone(phone.trim());
		}
		LOG.info("[Save mail list detail] " + mailListDetail.toString());
		return this.mailListDetailRepository.save(mailListDetail);
	}
	
	/**
	 * @author linhnt
	 * @since 20140813
	 * 
	 * @param mailListId
	 * @param activeFlg
	 * @return
	 * @throws Exception
	 */
	public List<MailListDetailModel> getMailListDetail(Integer mailListId, Integer activeFlg) throws Exception {
		List<MailListDetail> mailListDetails = this.mailListDetailRepository.getMailListDetail(mailListId, activeFlg);
		List<MailListDetailModel> mailListDetailModels = new ArrayList<MailListDetailModel>();
		for (MailListDetail mailListDetail : mailListDetails) {
			mailListDetailModels.add(mailListDetail.toModel(mapper));
		}
		return mailListDetailModels;
	}

	/**
	 * find mail list by id
	 * 
	 * @param mailListId
	 * @return
	 * @throws Exception
	 */
	public MailListModel findByMailListId(Integer mailListId) throws Exception {
		MailList mailList = this.mailListRepository.findOne(mailListId);
		return mailList.toModel(mapper);
	}

	/**
	 * get all mail list
	 * 
	 * @return map
	 */
	public Map<Integer, String> getAllMailList() {
		Map<Integer, String> result = new HashMap<>();
		List<MailList> mailList = this.mailListRepository.findMailListByActiveFlg(ActiveFlag.ACTIVE.toInt());
		for (MailList mailItem : mailList) {
			result.put(mailItem.getMailListId(), mailItem.getMailListName());
		}
		return result;
	}

	/**
	 * search mail list
	 * 
	 * @return list
	 */
	public List<MailListModel> searchMailListHistory(MailListModel mailingListModel) {
		List<MailListModel> result = new ArrayList<>();
		Date fromDate = MssDateTimeUtil.dateFromString(mailingListModel.getFromDate(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		Date toDate = MssDateTimeUtil.dateFromString(mailingListModel.getToDate(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);

		List<Object[]> lstInfos = this.mailSendingRepositoryCustom
				.searchMailListHistory(mailingListModel.getMailListId(), fromDate, toDate, MssContextHolder.getHospitalId().toString());
		MailListModel modelTemp;
		for (Object[] objects : lstInfos) {
			modelTemp = new MailListModel();
			modelTemp.setPatientName((String) objects[0]);
			modelTemp.setEmail((String) objects[1]);
			modelTemp.setReadingFlg((Integer) objects[2]);
			if (objects[3] != null) {
				modelTemp.setPhoneNumber((String) objects[3]);
			} else {
				try {
					String email = (String) objects[1];

					List<Patient> lstPatient = this.patientRepository
							.findPatientByEmail("%" + email.trim().toLowerCase() + "%");
					if (!lstPatient.isEmpty()) {
						modelTemp.setPhoneNumber(lstPatient.get(0).getPhoneNumber());
					}
				} catch (Exception e) {
					LOG.error("ERROR", e.getMessage());
				}
			}

			result.add(modelTemp);
		}
		return result;
	}

	/**
	 * Delete mail template.
	 *
	 * @param mailTemplateModel
	 *            the mail template model
	 * @return true, if successful
	 */
	public boolean deleteMailTemplate(MailTemplateModel mailTemplateModel) {
		boolean result = false;
		MailTemplate mailTemplate = this.mailTemplateRepository.findOne(mailTemplateModel.getMailTemplateId());
		if (mailTemplate != null) {
			mailTemplate.setActiveFlg(0);
			LOG.info("[Delete mail template] " + mailTemplate.toString());
			mailTemplateRepository.save(mailTemplate);
			result = true;
		}
		return result;
	}

	/**
	 * Update mail template.
	 *
	 * @param mailTemplateModel
	 *            the mail template model
	 * @return true, if successful
	 */
	public boolean updateMailTemplate(MailTemplateModel mailTemplateModel) {
		boolean result = false;
		if (mailTemplateModel != null) {
			MailTemplate mailTemplate = mailTemplateModel.toEntity(mapper);
			LOG.info("[Update mail template] " + mailTemplate.toString());
			mailTemplateRepository.save(mailTemplate);
			result = true;
		}
		return result;
	}

	// /**
	// * Delete mail list.
	// *
	// * @param mailListModel the mail list model
	// * @throws Exception the exception
	// */
	// public void updateMailList(MailListModel mailListModel) throws Exception
	// {
	// MailList mailList = mailListModel.toEntity(mapper);
	// mailListRepository.save(mailList);
	// }

	/**
	 * Update mail list detail.
	 *
	 * @param mailListDetailModel
	 *            the mail list detail model
	 * @throws Exception
	 *             the exception
	 */
	public void updateMailListDetail(MailListDetailModel mailListDetailModel) throws Exception {
		MailListDetail mailListDetail = mailListDetailModel.toEntity(mapper);
		LOG.info("[Update mail list detail]" + mailListDetail.toString());
		mailListDetailRepository.save(mailListDetail);
	}

	/**
	 * Find by mail list id and email.
	 *
	 * @param mailListId
	 *            the mail list id
	 * @param email
	 *            the email
	 * @return the mail list detail model
	 * @throws Exception
	 *             the exception
	 */
	public MailListDetailModel findByMailListIdAndEmail(Integer mailListId, String email) throws Exception {
		MailListDetail mailListDetail = mailListDetailRepository.findByMailListIdAndEmail(mailListId, email);
		if (mailListDetail != null) {
			return mailListDetail.toModel(mapper);
		}
		return null;
	}

	/**
	 * Delete mail list.
	 *
	 * @param mailListModel
	 *            the mail list model
	 * @param lstMailListDetail
	 *            the lst mail list detail
	 * @throws Exception
	 *             the exception
	 */
	@Transactional
	public void deleteMailList(MailListModel mailListModel, List<MailListDetailModel> lstMailListDetail)
			throws Exception {
		mailListModel.setActiveFlg(ActiveFlag.INACTIVE.toInt());
		MailList mailList = mailListModel.toEntity(mapper);
		mailListRepository.save(mailList);
		if (lstMailListDetail != null && !lstMailListDetail.isEmpty()) {
			for (MailListDetailModel mailListDetailModel : lstMailListDetail) {
				mailListDetailModel.setActiveFlg(ActiveFlag.INACTIVE.toInt());
				MailListDetail mailListDetail = mailListDetailModel.toEntity(mapper);
				mailListDetailRepository.save(mailListDetail);
			}
		}
	}

	/**
	 * Delete mail list detail.
	 *
	 * @param mailListDetailModel
	 *            the mail list detail model
	 * @throws Exception
	 *             the exception
	 */
	public void deleteMailListDetail(MailListDetailModel mailListDetailModel) throws Exception {
		MailListDetail mailListDetail = mailListDetailModel.toEntity(mapper);
		mailListDetailRepository.delete(mailListDetail);
	}

	/**
	 * Adds the new mail detail.
	 *
	 * @param mailListId
	 *            the mail list id
	 * @param reminderMailInfos
	 *            the reminder mail infos
	 * @throws Exception
	 *             the exception
	 */
	@Transactional
	public void addNewMailDetail(Integer mailListId, List<ReminderMailInfo> reminderMailInfos) throws Exception {
		for (ReminderMailInfo rmInfo : reminderMailInfos) {
			saveMailListDetail(mailListId, rmInfo.getMail().trim(), rmInfo.getName().trim(), rmInfo.getPhone());
		}
	}

	/**
	 * Update mail list.
	 *
	 * @param mailListName
	 *            the mail list name
	 * @param lstReminderMailInfo
	 *            the lst reminder mail info
	 * @throws Exception
	 *             the exception
	 */
	@Transactional
	public void updateMailList(Integer mailListId, String mailListName, ReminderMailInfo reminderMailInfo)
			throws Exception {
		MailList mailList = this.mailListRepository.findOne(mailListId);
		mailList.setMailListName(mailListName);
		// update mail list
		this.mailListRepository.save(mailList);
		updateMailListDetail(reminderMailInfo.getMail(), reminderMailInfo.getName(), mailListId,
				reminderMailInfo.getMailOld());
	}

	/**
	 * Save mail list.
	 *
	 * @param mailListName
	 *            the mail list name
	 * @param reminderMailInfo
	 *            the reminder mail info
	 * @throws Exception
	 *             the exception
	 */
	@Transactional
	public void saveMailList(String mailListName, ReminderMailInfo reminderMailInfo) throws Exception {
		MailList mailList = new MailList();
		mailList.setMailListName(mailListName);
		mailList = this.mailListRepository.save(mailList);
		saveMailListDetail(mailList.getMailListId(), reminderMailInfo.getMail().trim(),
				reminderMailInfo.getName().trim(), reminderMailInfo.getPhone());
	}

	/**
	 * Update mail list detail.
	 *
	 * @param email
	 *            the email
	 * @param name
	 *            the name
	 * @param mailListId
	 *            the mail list id
	 * @param emailOld
	 *            the email old
	 * @throws Exception
	 *             the exception
	 */
	public void updateMailListDetail(String email, String name, Integer mailListId, String emailOld) throws Exception {
		LOG.info("[Start] Update mail list detail.");
		LOG.info("[End] Update mail list detail.");
		this.mailListDetailRepository.updateByMailListIdAndEmail(email, name, mailListId, emailOld);
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Process mail csv.
	 *
	 * @param name
	 *            the name
	 * @throws Exception
	 *             the exception
	 */
	public void processMailCsv(String name) throws Exception {
		LOG.info("[start] processMailCsv " + name);
		List<MailListDetail> lstMailListDetail = new ArrayList<>();
		String filePath = MssConfiguration.getInstance().getDirFileUpload() + "/" + name;
		CsvConverter csvConverter = new CsvConverter();
		List<Entry<MailListDetailInfo, CsvErrorCode>> listCsvData = csvConverter.parseCsvMailListDetail(filePath);
		if (listCsvData != null && listCsvData.size() > 0) {
			// Save mail list
			String mailListName = name.split("\\.")[0];
			MailList mailList = new MailList();
			mailList.setMailListName(mailListName);
			mailList.setHospitalId(MssContextHolder.getHospitalId());
			mailList = this.mailListRepository.save(mailList);

			for (int rowNo = 1; rowNo <= listCsvData.size(); rowNo++) {
				Entry<MailListDetailInfo, CsvErrorCode> mapMailListInfo = listCsvData.get(rowNo - 1);
				if (listCsvData.size() > 0) {
					if (mapMailListInfo.getValue() != null) {
						writeErrorLog(rowNo, mapMailListInfo.getValue().name());
						continue;
					}

					MailListDetailInfo mailListDetailInfo = mapMailListInfo.getKey();
					if (mailListDetailInfo == null) {
						LOG.debug("mailListDetailInfo is null");
						continue;
					}

					CsvErrorCode errorCode = validateCsvData(mailListDetailInfo, rowNo);
					if (!CsvErrorCode.VALID.toInt().equals(errorCode.toInt())) {
						writeErrorLog(rowNo, errorCode.name());
					} else {
						// Save mail list detail
						MailListDetail mailListDetail = this.mailListDetailRepository
								.findByMailListIdAndEmail(mailList.getMailListId(), mailListDetailInfo.getMail());
						if (mailListDetail == null) {
							mailListDetail = new MailListDetail();
							mailListDetail.setName(mailListDetailInfo.getName());
							if (!StringUtils.isBlank(mailListDetailInfo.getPhone())) {
								mailListDetail.setPhone(mailListDetailInfo.getPhone());
							}
							mailListDetail.setId(
									new MailListDetailPK(mailList.getMailListId(), mailListDetailInfo.getMail()));
							lstMailListDetail.add(mailListDetail);
						} else {
							mailListDetail.setName(mailListDetailInfo.getName());
							if (!StringUtils.isBlank(mailListDetailInfo.getPhone())) {
								mailListDetail.setPhone(mailListDetailInfo.getPhone());
							}
							lstMailListDetail.add(mailListDetail);
						}
					}

				}
			}

			if (lstMailListDetail.size() > 0) {
				this.mailListDetailRepository.save(lstMailListDetail);
			}
		}

		MssFileUtils.remove(filePath);
		LOG.info("[end] processMailCsv " + name);
	}

	private CsvErrorCode validateCsvData(MailListDetailInfo mailListDetailInfo, Integer rowNo) {
		String name = mailListDetailInfo.getName();
		String phone = mailListDetailInfo.getPhone();
		String email = mailListDetailInfo.getMail();
		if (StringUtils.isBlank(email)) {
			LOG.warn("[Import mail list] ErrorCode = REQUIRED_DATA. " + mailListDetailInfo.toString());
			return CsvErrorCode.REQUIRED_DATA;
		}
		if (email.length() > 128 || name.length() > 64 || phone.length() > 45) {
			LOG.warn("[Import mail list] ErrorCode = WRONG_SIZE. " + mailListDetailInfo.toString());
			return CsvErrorCode.WRONG_SIZE;
		}
		RegularExpressionValidateString validate = new RegularExpressionValidateString();
		if (validate.regularExpressionValidate(email.trim(), EMAIL_PATTERN) == false) {
			return CsvErrorCode.INVALID;
		}

		return CsvErrorCode.VALID;
	}

	private void writeErrorLog(Integer rowNo, String errorCode) {
		LOG.warn("Error occurred while verifying the row:" + rowNo + "+ error code = " + errorCode);
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Find by name.
	 *
	 * @param name
	 *            the name
	 * @return the list
	 * @throws Exception
	 *             the exception
	 */
	public List<MailListModel> findByName(String mailListName) throws Exception {
		List<MailList> lstMailList = this.mailListRepository.findMailListByName(mailListName.trim().toLowerCase());
		if (lstMailList == null || lstMailList.isEmpty()) {
			return null;
		}
		List<MailListModel> lstMailListModel = new ArrayList<MailListModel>();
		for (MailList mailList : lstMailList) {
			lstMailListModel.add(mailList.toModel(mapper));
		}
		return lstMailListModel;
	}

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
	 * @param mailListId
	 *            the mail list id
	 * @param patientId
	 *            the patient id
	 * @param reservationId
	 *            the reservation id
	 * @throws Exception
	 *             the exception
	 */
	@Override
	public void sendMail(String templateCode, String locale, MailInfo mailInfo, List<String> toList, Integer mailListId,
			Integer patientId, Integer reservationId, Integer hospitalId, String bccEmail, String domainName)
					throws Exception {
		LOG.info("[Start] Send email");
		LOG.debug("Send email. templateCode = " + templateCode + " ,locale = " + locale);
		MailTemplate mailTemplate = new MailTemplate();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(templateCode, locale,
				hospitalId, SendType.MAIL.toInt());
		if (!CollectionUtils.isEmpty(mailTemplateList)) {
			mailTemplate = mailTemplateList.get(0);
		}
		// save mail sending
		List<MailSending> mailSendingList = new ArrayList<>();
		MailSending mailSending = new MailSending();
		mailSending.setMailTemplateId(mailTemplate.getMailTemplateId());
		MailList mailList = this.mailListRepository.findOne(mailListId);
		if (mailList != null) {
			mailSending.setMailList(mailList);
		}
		Patient patient = new Patient();
		if (patientId != null) {
			patient.setPatientId(patientId);
			mailSending.setPatient(patient);
		}
		Reservation reservation = new Reservation();
		if (reservationId != null) {
			reservation.setReservationId(reservationId);
			mailSending.setReservation(reservation);
		}
		mailSending.setReadingFlg(ReadingFlg.UNREAD.toInt());
		mailSending.setSendingBcc(StringUtils.join(templateMessage.getBcc(), ";"));
		mailSending.setSendingCc(StringUtils.join(templateMessage.getCc(), ";"));
		Map<String, Object> templateVariables = new HashMap<String, Object>();
		// set server address
		mailInfo.setServerAddress(domainName);
		templateVariables.put("mailInfo", mailInfo);

		String body = getEmailBody(mailTemplate.getContent(), templateVariables);
		mailSending.setContent(body);
		String subject = getEmailBody(mailTemplate.getSubject(), templateVariables);
		mailSending.setSubject(subject);
		mailSending.setSendingStatus(MailSendingStatus.SUCCESS.toInt());
		if (toList != null && !toList.isEmpty()) {
			for (int i = 0; i < toList.size(); i++) {
				MailSending item;
				try {
					item = (MailSending) BeanUtils.cloneBean(mailSending);
					item.setSendingTo(toList.get(i));
					mailSendingList.add(item);
				} catch (Exception e) {
					LOG.error("CLONE MAIL SENDING " + e.getMessage(), e);
				}
			}
		}
		if (!mailSendingList.isEmpty()) {
			mailSendingList = mailSendingRepository.save(mailSendingList);
		}
		List<String> mailIdList = new ArrayList<String>();
		for (MailSending ms : mailSendingList) {
			mailIdList.add(ms.getMailSendingId().toString());
		}
		// generate token for mail Id list
		String token = TokenUtils.generateMailIdToken(mailIdList);
		mailInfo.setMailId(token);
		mailInfo.setLinkThankYou(mailInfo.getLinkThankYou() + mailInfo.getMailId());
		if (StringUtils.isBlank(mailInfo.getDoctorId())) {
			mailInfo.setLinkReminderEmail(mailInfo.getLinkReminderEmail() + mailInfo.getMailId());
		} else {
			mailInfo.setLinkReminderEmail(mailInfo.getLinkReminderEmail() + "&mailSendingId=" + mailInfo.getMailId());
		}
		// set token to mail content
		templateVariables.put("mailInfo", mailInfo);
		body = getEmailBody(mailTemplate.getContent(), templateVariables);
		int count = 0;
		int maxTries = 3;
		while (true) {
			try {
				send(subject, toList, body, true, templateVariables, bccEmail);
				break;
			} catch (Exception e) {

				try {
					Thread.sleep(3 * 60 * 1000);
				} catch (InterruptedException e1) {
					e1.printStackTrace();
				}
				if (++count == maxTries) {
					LOG.error("ERROR: " + e.getMessage(), e);
					for (MailSending ms : mailSendingList) {
						ms.setSendingStatus(MailSendingStatus.FAIL.toInt());
					}
					LOG.info("[Start] Save mail sending to table mail_sending");
					mailSendingRepository.save(mailSendingList);
					LOG.info("[End] Save mail sending to table mail_sending");
					break;
				}
			}
		}

		LOG.info("[End] Send email");
	}

	@Override
	public boolean updateReadingFlg(Integer mailSendingId, Integer readingFlg) {
		LOG.info("[Start] update Reading Flg");
		LOG.debug("update Reading Flg. mailSendingId = " + mailSendingId);
		boolean result = false;
		if (this.mailSendingRepository.updateReadingFlg(mailSendingId, readingFlg) != 0) {
			result = true;
		}
		LOG.info("[Start] update Reading Flg");
		return result;
	}

	/**
	 * Find all template customize.
	 *
	 * @return the list
	 */
	@Override
	public List<MailTemplateModel> findAllTemplateCustomize(Integer hospitalId, String locale) {
		List<MailTemplate> mailListDetails = this.mailTemplateRepository.findAllTemplateCustomize(hospitalId, locale, SendType.MAIL.toInt());
		if (mailListDetails == null || mailListDetails.isEmpty()) {
			return null;
		}
		List<MailTemplateModel> lstMailTemplateModel = new ArrayList<MailTemplateModel>();
		for (MailTemplate mailTemplate : mailListDetails) {
			lstMailTemplateModel.add(mailTemplate.toModel(mapper));
		}
		return lstMailTemplateModel;
	}

	@Override
	public List<MailTemplateModel> findByHospIdAndLocale(Integer hospitalId, String locale) {
		List<MailTemplate> mailListDetails = this.mailTemplateRepository.findByHospIdAndLocale(hospitalId, locale, SendType.MAIL.toInt());
		if (mailListDetails == null || mailListDetails.isEmpty()) {
			return null;
		}
		List<MailTemplateModel> lstMailTemplateModel = new ArrayList<MailTemplateModel>();
		for (MailTemplate mailTemplate : mailListDetails) {
			lstMailTemplateModel.add(mailTemplate.toModel(mapper));
		}
		return lstMailTemplateModel;
	}
	//mail
	@Override
	public List<MailTemplateModel> getAllActiveMailTemplatesByHospitalId(Integer hospitalId, String locale) {
		List<MailTemplateModel> mailTemplateModelList = new ArrayList<MailTemplateModel>();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findAllActiveByHospitalId(hospitalId, locale, SendType.MAIL.toInt());
		for (MailTemplate mailTemplate : mailTemplateList) {
			mailTemplateModelList.add(mailTemplate.toModel(mapper));
		}
		return mailTemplateModelList;
	}
	//sms
	@Override
	public List<MailTemplateModel> getAllActiveSmsTemplatesByHospitalId(Integer hospitalId, String locale) {
		List<MailTemplateModel> mailTemplateModelList = new ArrayList<MailTemplateModel>();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findAllActiveByHospitalId(hospitalId, locale, SendType.SMS.toInt());
		for (MailTemplate mailTemplate : mailTemplateList) {
			mailTemplateModelList.add(mailTemplate.toModel(mapper));
		}
		return mailTemplateModelList;
	}
	//Send SMS
	
	
	
	
	
	
//	@Override
//	@Async
//	public void sendSms(String templateCode, String locale, MailInfo mailInfo, Integer hospitalId,
//			String recieverNumber) {
//		
//		LOG.info("[Start] Send SMS");
//		LOG.debug("Send SMS. templateCode = " + templateCode + " ,locale = " + locale);
//		MailTemplate mailTemplate = new MailTemplate();
//		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(templateCode, locale,
//				hospitalId);
//		if (!CollectionUtils.isEmpty(mailTemplateList)) {
//			mailTemplate = mailTemplateList.get(0);
//		}
//		if (mailInfo != null) {
//			String body = "";
//			try {
//				Map<String, Object> templateVariables = new HashMap<String, Object>();
//				// set server address
//				templateVariables.put("mailInfo", mailInfo);
//				body = getEmailBody(mailTemplate.getContent(), templateVariables);
//				//sendInfoSms(body, recieverNumber, null, locale);
//			} catch (Exception e) {
//				
//			}
//		
//		
//		LOG.info("[End] Send email");
//		}
//		
//	}
//
//	public void sendInfoSms(String message,String recieverNumber,String sender,String locale){
//		Properties props = new Properties();
//			props.setProperty("smsj.clickatell.username", "cuongtavan");
//			props.setProperty("smsj.clickatell.password", "DcXMLZdRefTVHO");
//			props.setProperty("smsj.clickatell.apiid", "3602691");
//		
//		
//		// Load the clickatell transport
//		SmsTransport transport = null;
//		try {
//			transport = SmsTransportManager.getTransport("org.marre.sms.transport.clickatell.ClickatellTransport",
//					props);
//			LOG.info("Load the clickatell transport");
//		} catch (SmsException e) {
//			e.printStackTrace();
//		}
//
//		// Connect to clickatell
//		try {
//			transport.connect();
//			LOG.info("Transport.Connect to ClickATell");
//		} catch (SmsException e) {
//			e.printStackTrace();
//		} catch (IOException e) {
//			e.printStackTrace();
//		}
//
//		// Create the sms message
//		SmsTextMessage textMessage = new SmsTextMessage("Send SMS");
//		//Fix fomat phone number by locale
//		String reciever = MssPhoneNumberUtils.StandardNumber(recieverNumber, locale);
//		// Send the sms to "461234" from "461235"
//		try {
//			transport.send(textMessage, new SmsAddress(reciever), new SmsAddress("84962171226"));
//			LOG.debug("Send SMS: to" + recieverNumber + "Content:" + textMessage);
//			System.out.println("Send SMS: to" + recieverNumber + "Content:" + textMessage.toString());
//		} catch (SmsException e) {
//			LOG.error("Phonenumber is not correct");
//		} catch (IOException e) {
//			e.printStackTrace();
//		}
//
//		// Disconnect from clickatell
//		
//			try {
//				transport.disconnect();
//			} catch (SmsException | IOException e) {
//				e.printStackTrace();
//			}
//			System.out.println(" transport.disconnect();");
//			LOG.info("Transport.Disconnect");
//		
//		
//		
//	}
	
	
	@Override
	public List<MailTemplateModel> getTemplateByTemplateType(Integer templateType, Integer hospitalId, String locale) {
		List<MailTemplate> mailListDetails = this.mailTemplateRepository.findByHospIdAndTemplateTypeAndLocale(templateType, hospitalId, locale, SendType.MAIL.toInt());
		if (mailListDetails == null || mailListDetails.isEmpty()) {
			return null;
		}
		List<MailTemplateModel> lstMailTemplateModel = new ArrayList<MailTemplateModel>();
		for (MailTemplate mailTemplate : mailListDetails) {
			lstMailTemplateModel.add(mailTemplate.toModel(mapper));
		}
		return lstMailTemplateModel;
	}
	
	
	@Override
	public List<MailTemplateModel> getCrmTemplate(Integer hospitalId, String locale) {
		List<MailTemplate> mailListDetails = this.mailTemplateRepository.getCrmTemplateByLocale(hospitalId, locale, SendType.MAIL.toInt());
		if (mailListDetails == null || mailListDetails.isEmpty()) {
			return null;
		}
		List<MailTemplateModel> lstMailTemplateModel = new ArrayList<MailTemplateModel>();
		for (MailTemplate mailTemplate : mailListDetails) {
			lstMailTemplateModel.add(mailTemplate.toModel(mapper));
		}
		return lstMailTemplateModel;
	}
}
