package nta.mss.scheduler;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Map.Entry;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.MessageSource;
import org.springframework.scheduling.annotation.EnableScheduling;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import nta.mss.info.MailInfo;
import nta.mss.info.ReminderBookingVaccineInfo;
import nta.mss.info.SmsInfo;
import nta.mss.info.VaccineWarningInfo;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.common.VaccineUtils;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.HospitalLocale;
import nta.mss.misc.enums.MailCode;
import nta.mss.misc.enums.VaccineWarningType;
import nta.mss.model.HospitalModel;
import nta.mss.model.UserModel;
import nta.mss.security.WebUserDetails;
import nta.mss.service.impl.HospitalService;
import nta.mss.service.impl.MailService;
import nta.mss.service.impl.SmsService;
import nta.mss.service.impl.UserService;
import nta.mss.service.impl.VaccineService;

@Component
@EnableScheduling
public class ReminderBookingVaccineScheduler {
	private static final Logger LOG = LogManager.getLogger(ReminderBookingVaccineScheduler.class);

	private MailService mailService;
	private SmsService smsService;
	private VaccineService vaccineService;
	private MessageSource messageSource;
	private UserService userService;
	private HospitalService hospitalService;

	@Autowired
	public ReminderBookingVaccineScheduler(MailService mailService, SmsService smsService,
			VaccineService vaccineService, MessageSource messageSource, UserService userService,
			HospitalService hospitalService) {
		this.mailService = mailService;
		this.smsService = smsService;
		this.vaccineService = vaccineService;
		this.messageSource = messageSource;
		this.userService = userService;
		this.hospitalService = hospitalService;
	}

	@Scheduled(cron = "${schedule.cron.reminder.vaccine}")
	public void run() {
		LOG.info("[START] RUN SERVICE: Send vaccine reminder email");
		try {
			Map<Integer, Map<Integer, List<ReminderBookingVaccineInfo>>> reminderEmailMapByUser = new LinkedHashMap<Integer, Map<Integer, List<ReminderBookingVaccineInfo>>>();
			Map<Integer, List<ReminderBookingVaccineInfo>> reminderEmailMapByChild;
			List<ReminderBookingVaccineInfo> reminderListByChild;
			List<ReminderBookingVaccineInfo> reminderBookingVaccineList = this.vaccineService
					.getReminderBookingVaccineInfo();
			for (ReminderBookingVaccineInfo reminderBookingVaccineInfo : reminderBookingVaccineList) {
				VaccineWarningInfo vaccineWarningInfo = new VaccineWarningInfo();
				vaccineWarningInfo = VaccineUtils.getVaccineWarningInfo(
						MssDateTimeUtil.dateFromString(reminderBookingVaccineInfo.getDob(),
								DateTimeFormat.DATE_FORMAT_YYYYMMDD),
						reminderBookingVaccineInfo.getLimitAgeToMonth(), reminderBookingVaccineInfo.getSupportFeeAge());
				Integer userId = reminderBookingVaccineInfo.getUserId();
				Integer childId = reminderBookingVaccineInfo.getChildId();
				if (vaccineWarningInfo != null) {
					String vaccineName = reminderBookingVaccineInfo.getVaccineName();
					BigInteger injectedNo = reminderBookingVaccineInfo.getInjectedNo();
					Integer warningDays = reminderBookingVaccineInfo.getWarningDays();
					Integer remainingDays = vaccineWarningInfo.getRemainingDays();
					if (remainingDays <= warningDays && remainingDays >= 0) {
						// check remaining days first
						List<Integer> reminderDaysList = MssConfiguration.getInstance()
								.getScheduleVaccineReminderDays();
						Locale locale = org.springframework.util.StringUtils
								.parseLocaleString(MssConfiguration.getInstance().getScheduleLanguage());
						List<Object> args = new ArrayList<Object>(
								Arrays.asList(vaccineName, remainingDays, injectedNo));
						for (Integer day : reminderDaysList) {
							if (remainingDays.equals(day)) {
								if (vaccineWarningInfo.getWarningType()
										.equals(VaccineWarningType.SUPPORT_FEE.toInt())) {
									reminderBookingVaccineInfo.setWarningMsg(this.messageSource.getMessage(
											"general.vaccine.reminder.email.support.fee", args.toArray(), locale));
								} else {
									reminderBookingVaccineInfo.setWarningMsg(this.messageSource.getMessage(
											"general.vaccine.reminder.email.limit.age", args.toArray(), locale));
								}
								reminderBookingVaccineInfo.setBirthDay(
										MssDateTimeUtil.convertStringDateByLocale(reminderBookingVaccineInfo.getDob(),
												DateTimeFormat.DATE_FORMAT_YYYYMMDD, locale));

								// group by user
								if (reminderEmailMapByUser.containsKey(userId)) {
									// group by child
									if (reminderEmailMapByUser.get(userId).containsKey(childId)) {
										reminderEmailMapByUser.get(userId).get(childId).add(reminderBookingVaccineInfo);
									} else {
										reminderListByChild = new ArrayList<ReminderBookingVaccineInfo>();
										reminderListByChild.add(reminderBookingVaccineInfo);
										reminderEmailMapByUser.get(userId).put(childId, reminderListByChild);
									}
								} else {
									// group by child
									reminderEmailMapByChild = new LinkedHashMap<Integer, List<ReminderBookingVaccineInfo>>();
									reminderListByChild = new ArrayList<ReminderBookingVaccineInfo>();
									reminderListByChild.add(reminderBookingVaccineInfo);
									reminderEmailMapByChild.put(childId, reminderListByChild);
									reminderEmailMapByUser.put(userId, reminderEmailMapByChild);
								}
								break;
							}
						}
					}
				}
			}
			this.sendReminderBookingEmail(reminderEmailMapByUser);
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
		}
		LOG.info("[END] RUN SERVICE: Send vaccine reminder email");
	}

	private void sendReminderBookingEmail(
			Map<Integer, Map<Integer, List<ReminderBookingVaccineInfo>>> reminderEmailMapByUser) throws Exception {
		if (reminderEmailMapByUser.size() != 0) {
			Map<Integer, List<ReminderBookingVaccineInfo>> reminderEmailMapByChild;
			ReminderBookingVaccineInfo reminderInfo;

			for (Entry<Integer, Map<Integer, List<ReminderBookingVaccineInfo>>> userEntry : reminderEmailMapByUser
					.entrySet()) {
				reminderEmailMapByChild = userEntry.getValue();
				// get the first element in list to get the user information
				reminderInfo = reminderEmailMapByChild.entrySet().iterator().next().getValue().get(0);

				String locale = reminderInfo.getLocale();
				LOG.debug("UserId: " + reminderInfo.getUserId());
				UserModel userModel = userService.getUser(reminderInfo.getUserId());
				HospitalModel hospitalModel = hospitalService.findHospital(userModel.getHospitalId());
				String hospCodeKey = EncryptionUtils.encrypt(hospitalModel.getHospitalCode(),
						MssConfiguration.getInstance().getSecretKey(), EncryptionUtils.ENCRYPT_ALGORITHM_AES,
						EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);

				LOG.debug("Email: " + reminderInfo.getEmail());
				LOG.debug("Hospital locale: " + reminderInfo.getLocale());

				// set mail information
				MailInfo mailInfo = new MailInfo();
				// set user name
				mailInfo.setUserName(reminderInfo.getUserName());
				// set children
				mailInfo.setChildren(reminderEmailMapByChild);
				// set top page link

				String serverAddress = MssConfiguration.getInstance().getServerAddress();
				if (HospitalLocale.JA_LOCALE.equals(locale)) {
					serverAddress = MssConfiguration.getInstance().getServerAddressJp();
				}
				mailInfo.setLinkTopPage(serverAddress + messageSource.getMessage("be030.link.top.page",
						new Object[] { hospCodeKey }, org.springframework.util.StringUtils.parseLocaleString(locale)));

				List<String> toList = new ArrayList<String>();
				// send Mail
				if (!StringUtils.isEmpty(reminderInfo.getEmail())) {
					toList.add(reminderInfo.getEmail());
					mailService.sendUserMail(MailCode.REMINDER_BOOKING_VACCINE.toString(), locale, mailInfo, toList,
							userModel.getHospitalId(), hospitalModel.getEmail(), serverAddress);
				}
				// Send Sms
				if (!StringUtils.isEmpty(reminderInfo.getPhoneNumber()) && hospitalModel.isUseSms()) {
					SmsInfo smsInfo = new SmsInfo();
					smsInfo.setUserName(reminderInfo.getUserName());
					// set children
					smsInfo.setChildren(reminderEmailMapByChild);
					smsService.sendSms(MailCode.REMINDER_BOOKING_VACCINE.toString(), locale, smsInfo,
							reminderInfo.getHospitalId(), reminderInfo.getPhoneNumber());
				}
			}
		} else {
			LOG.info("Empty vaccine reminder list");
		}
	}
	
	public UserModel getUser() {
		if (SecurityContextHolder.getContext().getAuthentication() != null) {
			Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();
			if (principal instanceof WebUserDetails) {
				return ((WebUserDetails) principal).getUser();
			}
		}
		return null;
	}
	
}
