package nta.med.ext.mss.service.impl;

import java.math.BigInteger;
import java.util.*;

import javax.annotation.Resource;

import nta.med.core.domain.mss.Hospital;
import nta.med.core.domain.mss.User;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.EncryptionUtils;
import nta.med.data.dao.mss.HospitalRepository;
import nta.med.data.dao.mss.UserRepository;
import nta.med.ext.mss.common.MbsConfiguration;
import nta.med.ext.mss.glossary.UserStatus;
import nta.med.ext.mss.model.*;
import nta.med.ext.support.glossary.EventMetaStore;
import nta.med.ext.support.service.AbstractRpcExtListener;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.mss.Patient;
import nta.med.core.domain.mss.Reservation;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.mss.PatientRepository;
import nta.med.data.dao.mss.ReservationRepository;
import nta.med.data.model.mss.PatientInfo;
import nta.med.data.model.mss.ReservationOnlineInfo;
import nta.med.ext.mss.service.PatientService;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.patient.PatientRpcService;

/**
 * @author DEV-TiepNM
 */
@Service
@Transactional
public class PatientServiceImpl implements PatientService {

	@Resource
	private PatientRpcService patientRpcService;
	@Resource
	private ReservationRepository reservationRepository;
	@Resource
	private PatientRepository patientRepository;
	@Resource
	private HospitalRepository hospitalRepository;
	
	private static final Log LOGGER = LogFactory.getLog(PatientServiceImpl.class);

	@Override
	public PatientBasicInfoModel getPatient(String hospCode, String patientCode) {

		PatientServiceProto.GetPatientRequest patientRequest = PatientServiceProto.GetPatientRequest.newBuilder()
				.setPatientCode(patientCode).setHospCode(hospCode).build();

		PatientServiceProto.GetPatientResponse patientResponse = patientRpcService.getPatient(patientRequest);
		PatientBasicInfoModel patientBasicInfoModel = new PatientBasicInfoModel();
		if (patientResponse != null && !Strings.isEmpty(patientResponse.getPatientCode())) {
			BeanUtils.copyProperties(patientResponse, patientBasicInfoModel, Language.JAPANESE.toString());
		}

		return patientBasicInfoModel;
	}

	@Override
	public List<ReservationModel> getWaitingPatient(String examinationDate, String examinationSituation,
			String departmentCode, String doctorCode, String hospCode, String locale, List<String> patientCodes) {

//		if (Strings.isEmpty(patientCode)) {
//			patientCode = "";
//		}
		if (Strings.isEmpty(departmentCode)) {
			departmentCode = "";
		}
		if (Strings.isEmpty(doctorCode)) {
			doctorCode = "";
		}
		if (Strings.isEmpty(examinationSituation)) {
			examinationSituation = "";
		}
		PatientServiceProto.GetWaitingPatientRequest getWaitingPatientRequest = PatientServiceProto.GetWaitingPatientRequest
				.newBuilder().setHospCode(hospCode).setDepartmentCode(departmentCode)
				.setExaminationDate(examinationDate).setExaminationSituation(examinationSituation)
				.setDoctorCode(doctorCode).setLocale(locale).addAllPatientCode(patientCodes).build();

		PatientServiceProto.GetWaitingPatientResponse patientResponse = patientRpcService
				.getWaitingPatient(getWaitingPatientRequest);

		List<ReservationModel> reservationModels = new ArrayList<>();

		for (PatientModelProto.WaitingPatientInfo waitingPatientInfo : patientResponse.getWaitingPatientsList()) {
			ReservationModel reservationModel = new ReservationModel();
			BeanUtils.copyProperties(waitingPatientInfo, reservationModel, Language.JAPANESE.toString());
			reservationModels.add(reservationModel);
		}
		return reservationModels;

	}

	@Override
	public ReservationModel saveCallingId(String reservationCode, String callingId, String hospitalId) {
		ReservationModel reservationModel = new ReservationModel();
		List<Reservation> reservations = reservationRepository.findByReservationCodeAndHospitalId(reservationCode, Integer.valueOf(hospitalId));
		if (!CollectionUtils.isEmpty(reservations)) {
			Reservation reservation = reservations.get(0);
			callingId = Strings.isEmpty(callingId) ? null : callingId;
			reservation.setMtCallingId(callingId);
			reservationRepository.save(reservation);

			BeanUtils.copyProperties(reservation, reservationModel, Language.JAPANESE.toString());
		}
		return reservationModel;

	}
	
	@Override
	public ReservationModel updateCallingId(String reservationCode, String callingId, String hospitalCode) {
		ReservationModel reservationModel = new ReservationModel();
		
		List<Hospital> hospitals = hospitalRepository.findByHospitalCode(hospitalCode);
		Integer hospitalId = null;
		if(!CollectionUtils.isEmpty(hospitals) && hospitals.get(0) != null) {
			hospitalId = hospitals.get(0).getHospitalId();
			
			List<Reservation> reservations = reservationRepository.findByReservationCodeAndHospitalId(reservationCode, hospitalId);
			if (!CollectionUtils.isEmpty(reservations)) {
				Reservation reservation = reservations.get(0);
				callingId = Strings.isEmpty(callingId) ? null : callingId;
				reservation.setMtCallingId(callingId);
				reservationRepository.save(reservation);

				BeanUtils.copyProperties(reservation, reservationModel, Language.JAPANESE.toString());
			}
			return reservationModel;
		}
		return reservationModel;

	}

	@Override
	public PatientInfoModel getPatientInfo(String hospitalId, String patientCode) {
		PatientInfoModel patientModel = new PatientInfoModel();
		List<Patient> patients = null;
		try {
			patients = patientRepository.findKcckPatientByPatientCodeHospCode(Integer.parseInt(hospitalId),
					patientCode);
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}

		if (!CollectionUtils.isEmpty(patients)) {
			Patient patient = patients.get(0);
			BeanUtils.copyProperties(patient, patientModel, Language.JAPANESE.toString());
			if (patient.getBirth() != null) {
				patientModel.setPatientAge(getAge(patient.getBirth()));
			}
		}
		return patientModel;
	}

	@Override
	public List<ReservationOnlineInfo> findReservationInfoByReCodeHosId(String hospId, List<String> reservationCodes) {
		return reservationRepository.findReservationInfoByReCodeHosId(Integer.parseInt(hospId), reservationCodes);
	}

	@Override
	public List<PatientInfoModel> findPatientInfoByProfileId(String profileId) {
		BigInteger profileIdBD = new BigInteger(profileId);
		List<PatientInfo> ls = this.patientRepository.findPatientInfoByProfileId(profileIdBD);

		List<PatientInfoModel> reservationModels = new ArrayList<>();
		for (PatientInfo patientInfo : ls) {
			PatientInfoModel reservationModel = new PatientInfoModel();
			BeanUtils.copyProperties(patientInfo, reservationModel, Language.JAPANESE.toString());
			reservationModels.add(reservationModel);
		}

		return reservationModels;
	}

	public int getAge(Date dateOfBirth) {
		try {
			Calendar today = Calendar.getInstance();
			Calendar birthDate = Calendar.getInstance();

			int age = 0;

			birthDate.setTime(dateOfBirth);
			if (birthDate.after(today)) {
				throw new IllegalArgumentException("Can't be born in the future");
			}

			age = today.get(Calendar.YEAR) - birthDate.get(Calendar.YEAR);

			// If birth date is greater than todays date (after 2 days
			// adjustment of leap year) then decrement age one year
			if ((birthDate.get(Calendar.DAY_OF_YEAR) - today.get(Calendar.DAY_OF_YEAR) > 3)
					|| (birthDate.get(Calendar.MONTH) > today.get(Calendar.MONTH))) {
				age--;

				// If birth date and todays date are of same month and birth day
				// of month is greater than todays day of month then decrement
				// age
			} else if ((birthDate.get(Calendar.MONTH) == today.get(Calendar.MONTH))
					&& (birthDate.get(Calendar.DAY_OF_MONTH) > today.get(Calendar.DAY_OF_MONTH))) {
				age--;
			}

			return age;
		} catch (Exception e) {
			e.printStackTrace();
		}
		return 0;
	}

	public static class ListenerImpl extends AbstractRpcExtListener<PatientServiceProto.UserEvent> {

		@Resource
		private PatientRpcService patientRpcService;
		@Resource
		private UserRepository userRepository;
		@Resource
		private HospitalRepository hospitalRepository;

		protected ListenerImpl() {
			super(PatientServiceProto.UserEvent.class);
		}

		@Override
		public EventMetaStore meta() {
			return EventMetaStore.PATIENT;
		}

		@Override
		public void handleEvent(PatientServiceProto.UserEvent event) throws Exception {
			if (event.getAction().equals(PatientServiceProto.UserEvent.Action.REGISTER)) {

                List<User> userList = new ArrayList<>();
                if(!Strings.isEmpty(event.getHospitalCode()))
                {

                    List<Hospital> hospitals = hospitalRepository.findByHospitalCode(event.getHospitalCode());
                    if(!CollectionUtils.isEmpty(hospitals))
                    {
                        userList = userRepository.findByEmail(event.getEmail(), hospitals.get(0).getHospitalId());
                    }

                }
                else
                {
					try {
						userList = this.userRepository.findByEmail(event.getEmail(), CommonUtils.parseInteger(MbsConfiguration.getInstance().getDefaultHospitalId()));
					} catch (Exception e) {
						LOGGER.error("PatientServiceImpl get by email error", e);
					}
				}

                if(userList.isEmpty()) {
                    User user = new User();
                    BeanUtils.copyProperties(event, user, Language.JAPANESE.toString());
                    user.setUserStatus(UserStatus.REGISTER_ACCEPTED.toInt());
                    if(!Strings.isEmpty(event.getPassword()))
                    {
                        user.setPassword(event.getPassword());
                    }
                    else
                    {
                        //With register by Facebook
						try {
							user.setPassword(EncryptionUtils.cryptWithMD5(MbsConfiguration.getInstance().getDefaultPassWord()));
						} catch (Exception e) {
							LOGGER.error("PatientServiceImpl get Default password error", e);
						}
						user.setUserStatus(UserStatus.REGISTER_COMPLETED.toInt());
                    }
                    if(!Strings.isEmpty(event.getHospitalCode()))
                    {
                        List<Hospital> hospitals = hospitalRepository.findByHospitalCode(event.getHospitalCode());
                        if(!CollectionUtils.isEmpty(hospitals))
                        {
							try {
								user.setHospitalId(hospitals.get(0).getHospitalId());
							} catch (Exception e) {
								LOGGER.error("PatientServiceImpl get Default hospital id error", e);
							}
						}

                    }
                    else
                    {
						try {
							user.setHospitalId(CommonUtils.parseInteger(MbsConfiguration.getInstance().getDefaultHospitalId()));
						} catch (Exception e) {
							LOGGER.error("PatientServiceImpl get Default hospital id error", e);
						}
					}



                    if(StringUtils.isNotBlank(user.getDob())) {
                        String formatedDate = user.getDob().replaceAll("/", "");
                        user.setDob(formatedDate);
                    }
					if(!Strings.isEmpty(event.getFacebookId()))
					{
						user.setLoginId(event.getFacebookId());
					}


                    this.userRepository.save(user);

                }

			} else if (event.getAction().equals(PatientServiceProto.UserEvent.Action.UPDATE_INFOMATION)) {
				List<User> listUser = new ArrayList<>();
				if (!Strings.isEmpty(event.getHospitalCode())) {
					List<Hospital> hospitals = hospitalRepository.findByHospitalCode(event.getHospitalCode());
					if (!CollectionUtils.isEmpty(hospitals)) {
						if(event.getFacebookId().equals(""))
						{
							listUser = this.userRepository.findByEmailAndFacebookIdEmptyAndHospId(event.getEmail(), hospitals.get(0).getHospitalId());
						}
						else
						{
							 listUser = this.userRepository.findByEmailAndFacebookIdAndHospId(event.getEmail(),event.getFacebookId(), hospitals.get(0).getHospitalId());
									
						}                
					}

				} else {
					Integer hospitalId;
					try {
						hospitalId = CommonUtils.parseInteger(MbsConfiguration.getInstance().getDefaultHospitalId());
						if(event.getFacebookId().equals(""))
						{
							listUser = this.userRepository.findByEmailAndFacebookIdEmptyAndHospId(event.getEmail(), hospitalId);
						}
						else
						{
							 listUser = this.userRepository.findByEmailAndFacebookIdAndHospId(event.getEmail(),event.getFacebookId(),hospitalId);
									
						}       
					} catch (Exception e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
				}
				if (listUser.size() > 0) {
					User user = listUser.get(0);
					user.setName(event.getName());
					user.setEmail(event.getEmail());
					user.setPassword(event.getPassword());
					user.setNameFurigana(event.getNameFurigana());
					user.setSex(event.getSex());
					user.setPhoneNumber(event.getPhoneNumber());
					this.userRepository.save(user);
				}

			} else if (event.getAction().equals(PatientServiceProto.UserEvent.Action.FOGOT_PASS) ||
					event.getAction().equals(PatientServiceProto.UserEvent.Action.CHANGE_PASS)) {
				List<User> listUser = this.userRepository.findByEmail(event.getEmail());
				for(User user : listUser)
				{
					if(user.getLoginId() == null)
					{
						user.setEmail(event.getEmail());
						user.setUserStatus(UserStatus.REGISTER_COMPLETED.toInt());
						user.setPassword(EncryptionUtils.cryptWithMD5(event.getPassword()));
						this.userRepository.save(user);
					}
				}		
			}
			

		}

		@Override
		public Collection<PatientServiceProto.UserEvent> invokeSubscribe(long eventId) throws Exception {
			PatientServiceProto.SubscribeUserEventRequest request = PatientServiceProto.SubscribeUserEventRequest
					.newBuilder().setEventId(-1L).build();
			PatientServiceProto.SubscribeUserEventResponse response = patientRpcService.subscribeUser(request);
			if (response != null
					&& PatientServiceProto.SubscribeUserEventResponse.Result.SUCCESS.equals(response.getResult())) {
				if (isVerbose())
					LOGGER.info("{} was successfully subscribed");
				return response.getEventsList();
			}

			return java.util.Collections.emptyList();
		}
	}

}
