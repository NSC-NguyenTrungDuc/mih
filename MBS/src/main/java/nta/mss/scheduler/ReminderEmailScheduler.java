package nta.mss.scheduler;

import java.util.ArrayList;
import java.util.List;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.MessageSource;
import org.springframework.scheduling.annotation.EnableScheduling;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.mss.info.MailInfo;
import nta.mss.info.ReminderReservationCheduleInfo;
import nta.mss.info.SmsInfo;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.HospitalLocale;
import nta.mss.misc.enums.MailCode;
import nta.mss.model.HospitalModel;
import nta.mss.model.UserModel;
import nta.mss.service.IHospitalService;
import nta.mss.service.impl.MailService;
import nta.mss.service.impl.ReservationService;
import nta.mss.service.impl.SmsService;
import nta.mss.service.impl.UserService;

/**
 * 
 * @author DEV-HuanLT
 *
 */
@Component
@EnableScheduling
public class ReminderEmailScheduler {
	private static final Logger LOGGER = LogManager.getLogger(ReminderEmailScheduler.class);

	private MessageSource messageSource;

	private MailService mailService;

	private SmsService smsService;

	private ReservationService reservationService;
	
	private UserService userService;

	@Autowired
	public ReminderEmailScheduler(MessageSource messageSource, MailService mailService, SmsService smsService,
			ReservationService reservationService, UserService userService) {
		this.messageSource = messageSource;
		this.mailService = mailService;
		this.smsService = smsService;
		this.reservationService = reservationService;
		this.userService = userService;
	}

	@Autowired
	private IHospitalService hospitalService;

	//@Scheduled(fixedDelayString = "${schedule.delay.reminder.booking}")
	@Scheduled(cron = "${schedule.cron.reminder.booking}")
	public void run() {
		LOGGER.info("[START] RUN SERVICE: Send booking reminder email");
		try {
			String schedulerTiming = MssConfiguration.getInstance().getScheduleReservationReminderDays();
			String serverTimeZone = MssConfiguration.getInstance().getServerTimeZone();
			List<ReminderReservationCheduleInfo> listReminder = this.reservationService
					.getListReminderReservationCchedule(schedulerTiming, serverTimeZone);
			sendReminderBooking(listReminder);
		} catch (Exception e) {
			LOGGER.error(e.getMessage(), e);
		}
		LOGGER.info("[END] RUN SERVICE: Send booking reminder email");
	}

	private void sendReminderBooking(List<ReminderReservationCheduleInfo> listReminder) throws Exception {
		if (!CollectionUtils.isEmpty(listReminder)) {
			for (ReminderReservationCheduleInfo reservation : listReminder) {
				String locale = reservation.getLocale();
				// set mail information
				MailInfo mailInfo = new MailInfo();
				mailInfo.setHospitalName(reservation.getHospitalName());
				mailInfo.setUserName(reservation.getPatientName());
				mailInfo.setPatientName(reservation.getPatientName());
				if(MssConfiguration.getInstance().getApiKcckVaccineCode().equals(reservation.getDepartCode())){
					UserModel userMode = this.userService.getActiveUserByEmail(reservation.getEmail(), reservation.getHospitalId());
					mailInfo.setUserName(userMode.getName());
					mailInfo.setPatientName(userMode.getName());
				}
				mailInfo.setReminderTime(reservation.getReminderTime().toString());
				mailInfo.setReservationCode(reservation.getReservationCode());
				mailInfo.setDepartmentName(reservation.getDeptName());
				mailInfo.setPatientCode(reservation.getCardNumber());
				String reservationDateTime = reservation.getReservationDate() + reservation.getReservationTime();

				mailInfo.setReservationDatetime(MssDateTimeUtil.convertStringDate(reservationDateTime,
						DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM,
						DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM_EXTEND));

				// set top page link
				String serverAddress = MssConfiguration.getInstance().getServerAddress();
				if (HospitalLocale.JA_LOCALE.equals(locale)) {
					serverAddress = MssConfiguration.getInstance().getServerAddressJp();
				}
				mailInfo.setLinkTopPage(serverAddress + messageSource.getMessage("be030.link.search.reservation", null,
						org.springframework.util.StringUtils.parseLocaleString(locale)));

				List<String> toList = new ArrayList<String>();
				if (!StringUtils.isEmpty(reservation.getEmail())) {
					toList.add(reservation.getEmail());
					LOGGER.info("send to email: " + reservation.getEmail());
					mailService.sendUserMail(MailCode.REMINDER_RESERVATION_SCHEDULE.toString(), locale, mailInfo,
							toList, reservation.getHospitalId(), reservation.getHospitalEmail(), serverAddress);

				}
				// send SMS
				HospitalModel hospital = this.hospitalService
						.findHospitalModelByHospitalId(reservation.getHospitalId());

				if (!StringUtils.isEmpty(reservation.getPhoneNumber()) && hospital.isUseSms()) {
					String recieverNumber = reservation.getPhoneNumber();
					LOGGER.info("send SMS to : " + recieverNumber);
					SmsInfo smsInfo = new SmsInfo();
					smsInfo.setPatientCode(reservation.getCardNumber());
					smsInfo.setPatientName(reservation.getPatientName());
					if(MssConfiguration.getInstance().getApiKcckVaccineCode().equals(reservation.getDepartCode())){
						UserModel userMode = this.userService.getActiveUserByEmail(reservation.getEmail(), reservation.getHospitalId());
						smsInfo.setUserName(userMode.getName());
						smsInfo.setPatientName(userMode.getName());
					}
					smsInfo.setHospitalName(reservation.getHospitalName());
					smsInfo.setUserName(reservation.getPatientName());
					smsInfo.setReminderTime(reservation.getReminderTime().toString());
					smsInfo.setReservationCode(reservation.getReservationCode());
					smsInfo.setDepartmentName(reservation.getDeptName());

					smsInfo.setReservationDatetime(MssDateTimeUtil.convertStringDate(reservationDateTime,
							DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM,
							DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM_EXTEND));
					
					smsService.sendSms(MailCode.REMINDER_RESERVATION_SCHEDULE.toString(), locale, smsInfo,
							reservation.getHospitalId(), recieverNumber);

				}

			}
		} else {
			LOGGER.info("Empty reminder list");
		}
	}

}
