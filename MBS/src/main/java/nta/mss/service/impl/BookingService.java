package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;
import java.util.List;
import java.util.Map;

import javax.persistence.EntityNotFoundException;

import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.kcck.info.KcckReservationInfo;
import nta.med.common.util.Strings;
import nta.mss.entity.Department;
import nta.mss.entity.Doctor;
import nta.mss.entity.Hospital;
import nta.mss.entity.MailSending;
import nta.mss.entity.MailTemplate;
import nta.mss.entity.Patient;
import nta.mss.entity.Reservation;
import nta.mss.entity.Session;
import nta.mss.entity.Transaction;
import nta.mss.entity.User;
import nta.mss.entity.UserChild;
import nta.mss.info.BookingInfo;
import nta.mss.info.ReservationInfo;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.common.MssHelper;
import nta.mss.misc.common.TokenUtils;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.DepartmentType;
import nta.mss.misc.enums.ReadingFlg;
import nta.mss.misc.enums.ReservationStatus;
import nta.mss.misc.enums.SendType;
import nta.mss.model.MailTemplateModel;
import nta.mss.model.PatientModel;
import nta.mss.model.ReservationModel;
import nta.mss.model.SessionModel;
import nta.mss.repository.DepartmentRepository;
import nta.mss.repository.DoctorRepository;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.MailSendingRepository;
import nta.mss.repository.MailTemplateRepository;
import nta.mss.repository.PatientRepository;
import nta.mss.repository.ReservationRepository;
import nta.mss.repository.SessionRepository;
import nta.mss.repository.UserChildRepository;
import nta.mss.repository.UserRepository;
import nta.mss.service.IBookingService;

/**
 * The Class BookingService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Service
@Transactional
public class BookingService implements IBookingService {
	private Mapper mapper;
	private PatientRepository patientRepository;
	private ReservationRepository reservationRepository;
	private SessionRepository sessionRepository;
	private MailSendingRepository mailSendingRepository;
	private MailTemplateRepository mailTemplateRepository;
	private DepartmentRepository departmentRepository;
	private UserChildRepository userChildRepository;
	private UserRepository userRepository;
	private HospitalRepository hospitalRepository;
	private DoctorRepository doctorRepository;

	public BookingService() {
	}

	/**
	 * Instantiates a new booking service.
	 * 
	 * @param mapper
	 *            the mapper
	 * @param patientRepository
	 *            the patient repository
	 * @param reservationRepository
	 *            the reservation repository
	 * @param sessionRepository
	 *            the session repository
	 */
	@Autowired
	public BookingService(Mapper mapper, PatientRepository patientRepository,
			ReservationRepository reservationRepository, SessionRepository sessionRepository,
			MailSendingRepository mailSendingRepository, MailTemplateRepository mailTemplateRepository,
			DepartmentRepository departmentRepository, UserChildRepository userChildRepository,
			UserRepository userRepository, HospitalRepository hospitalRepository, DoctorRepository doctorRepository) {
		this.mapper = mapper;
		this.patientRepository = patientRepository;
		this.reservationRepository = reservationRepository;
		this.sessionRepository = sessionRepository;
		this.mailSendingRepository = mailSendingRepository;
		this.mailTemplateRepository = mailTemplateRepository;
		this.departmentRepository = departmentRepository;
		this.userChildRepository = userChildRepository;
		this.userRepository = userRepository;
		this.hospitalRepository = hospitalRepository;
		this.doctorRepository = doctorRepository;
	}

	/**
	 * Find reservation by id.
	 * 
	 * @param reservationId
	 *            the reservation id
	 * @return the reservation model
	 */
	public ReservationModel findReservationById(Integer reservationId) {
		Reservation reservation = this.reservationRepository.findOne(reservationId);
		return reservation == null ? null : reservation.toModel(mapper);
	}

	/**
	 * Find Kcckreservation by id.
	 * 
	 * @param reservationId
	 *            the reservation id
	 * @return the reservation model
	 */
	public ReservationModel findKcckReservationById(Integer reservationId) {

		KcckReservationInfo kcckReservationInfo = this.reservationRepository.findKcckReservationById(reservationId);
		if (kcckReservationInfo != null) {
			ReservationModel reservationModel = new ReservationModel();
			reservationModel.setReservationId(kcckReservationInfo.getReservationId());
			reservationModel.setHospitalId(kcckReservationInfo.getHospitalId());
			reservationModel.setDeptId(kcckReservationInfo.getDeptId());
			reservationModel.setDoctorId(kcckReservationInfo.getDoctorId());
			reservationModel.setPatientId(kcckReservationInfo.getPatientId());
			reservationModel.setPatientName(kcckReservationInfo.getPatientName());
			reservationModel.setNameFurigana(kcckReservationInfo.getNameFurigana());
			reservationModel.setPhoneNumber(kcckReservationInfo.getPhoneNumber());
			reservationModel.setEmail(kcckReservationInfo.getEmail());
			reservationModel.setReservationDate(kcckReservationInfo.getReservationDate());
			reservationModel.setReservationTime(kcckReservationInfo.getReservationTime());
			reservationModel.setSessionId(kcckReservationInfo.getSessionId());
			reservationModel.setReservationCode(kcckReservationInfo.getReservationCode());
			reservationModel.setReminderTime(kcckReservationInfo.getReminderTime());
			reservationModel.setDoctorName(kcckReservationInfo.getDoctorName());
			reservationModel.setDoctorCode(kcckReservationInfo.getDoctorCode());
			reservationModel.setDeptName(kcckReservationInfo.getDeptName());
			reservationModel.setCardNumber(kcckReservationInfo.getPatientCode());
			reservationModel.setDepartmentCode(kcckReservationInfo.getDeptCode());
			reservationModel.setPatientSex(kcckReservationInfo.getPatientGender());
			if (kcckReservationInfo.getPatientBirthDay() != null) {
				reservationModel.setPatientBirtday(
						MssDateTimeUtil.convertDateToStringByLocale(kcckReservationInfo.getPatientBirthDay(),
								DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND, MssContextHolder.getLocale()));
			}
			return reservationModel;
		}
		return null;
	}

	/**
	 * Cancel reservation.
	 *
	 * @param reservationId
	 *            the reservation id
	 * @throws EntityNotFoundException
	 *             the entity not found exception
	 */
	public ReservationModel cancelReservation(Integer reservationId) throws EntityNotFoundException {
		ReservationModel reservationModel = null;
		Reservation reservation = this.reservationRepository.findOne(reservationId);
		if (reservation == null) {
			throw new EntityNotFoundException();
		} else {
			reservation.setReservationStatus(ReservationStatus.CANCELLED.toInt());
			if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
				reservationModel = this.reservationRepository.save(reservation).toModel(mapper,
						"exclude-departmentAnddoctor");
				reservationModel.setHospitalName(reservation.getHospital().getHospitalName());
			} else {
				reservationModel = this.reservationRepository.save(reservation).toModel(mapper);
			}

		}
		return reservationModel;
	}

	/**
	 * Find reservation in id list.
	 *
	 * @param reservationIdList
	 *            the reservation id list
	 * @return the list
	 */
	public List<ReservationModel> findReservationInIdList(Collection<Integer> reservationIds) {
		List<ReservationModel> result = new ArrayList<ReservationModel>();
		List<Reservation> reservations = this.reservationRepository.findInIdList(reservationIds);
		if (reservations != null) {
			for (Reservation reservation : reservations) {
				if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
					result.add(reservation.toModel(mapper, "exclude-departmentAnddoctor"));
				} else {
					result.add(reservation.toModel(mapper));
				}
			}
		}
		return result;
	}

	/**
	 * Find reservation by session id.
	 * 
	 * @param sessionId
	 *            the session id
	 * @return the reservation model
	 */
	public ReservationModel findReservationBySessionId(String sessionId) {
		Reservation reservation = this.reservationRepository.findBySessionId(sessionId);
		if (MssContextHolder.getHospitalParentId() != null && MssContextHolder.getHospitalParentId() == 1) {
			return reservation == null ? null : reservation.toModel(mapper, "exclude-departmentAnddoctor");
		} else {
			return reservation == null ? null : reservation.toModel(mapper);
		}
	}

	/**
	 * Find Kcck reservation by session id.
	 * 
	 * @param sessionId
	 *            the session id
	 * @return the reservation model
	 */
	public ReservationModel findKcckReservationBySessionId(String sessionId) {
		KcckReservationInfo kcckReservationInfo = this.reservationRepository.findKcckReservationBySessionId(sessionId);
		if (kcckReservationInfo != null) {
			ReservationModel reservationModel = new ReservationModel();
			reservationModel.setReservationId(kcckReservationInfo.getReservationId());
			reservationModel.setHospitalId(kcckReservationInfo.getHospitalId());
			reservationModel.setDeptId(kcckReservationInfo.getDeptId());
			reservationModel.setDoctorId(kcckReservationInfo.getDoctorId());
			reservationModel.setPatientId(kcckReservationInfo.getPatientId());
			reservationModel.setPatientName(kcckReservationInfo.getPatientName());
			reservationModel.setNameFurigana(kcckReservationInfo.getNameFurigana());
			reservationModel.setPhoneNumber(kcckReservationInfo.getPhoneNumber());
			reservationModel.setEmail(kcckReservationInfo.getEmail());
			reservationModel.setReservationDate(kcckReservationInfo.getReservationDate());
			reservationModel.setReservationTime(kcckReservationInfo.getReservationTime());
			reservationModel.setSessionId(kcckReservationInfo.getSessionId());
			reservationModel.setReservationCode(kcckReservationInfo.getReservationCode());
			reservationModel.setReminderTime(kcckReservationInfo.getReminderTime());
			reservationModel.setDoctorName(kcckReservationInfo.getDoctorName());
			reservationModel.setDoctorCode(kcckReservationInfo.getDoctorCode());
			reservationModel.setDeptName(kcckReservationInfo.getDeptName());
			reservationModel.setCardNumber(kcckReservationInfo.getPatientCode());
			reservationModel.setPatientSex(kcckReservationInfo.getPatientGender());
			reservationModel.setPatientBirtday(MssDateTimeUtil.dateToString(kcckReservationInfo.getPatientBirthDay(),
					DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
			return reservationModel;
		}
		return null;

	}

	/**
	 * Find time current pending status.
	 * 
	 * @param reservationDate
	 *            the reservation date
	 * @param deptId
	 *            the dept id
	 * @return the string
	 */
	public String findTimeCurrentPendingStatus(String reservationDate, Integer deptId) {
		String timeCrrStatus = this.reservationRepository.findTimeCurrentPendingStatus(reservationDate, deptId);
		return timeCrrStatus;
	}

	/**
	 * Find one patient by card number.
	 * 
	 * @param cardNumber
	 *            the card number
	 * @return the patient model
	 */
	@Override
	public PatientModel findOnePatientByCardNumber(String cardNumber, Integer hospitalId) {
		Patient patient = getPatientByCardNumber(cardNumber, hospitalId);
		return patient == null ? null : patient.toModel(mapper);
	}

	/**
	 * Gets the patient by card number.
	 * 
	 * @param cardNumber
	 *            the card number
	 * @return the patient by card number
	 */
	private Patient getPatientByCardNumber(String cardNumber, Integer hospitalId) {
		List<Patient> patientList = this.patientRepository.findPatientByCardNumber(cardNumber, hospitalId);
		if (patientList == null || patientList.isEmpty()) {
			return null;
		}
		return patientList.get(0);
	}

	/**
	 * Save patient info.
	 *
	 * @param bookingInfo
	 *            the booking info
	 * @param reservationMode
	 *            the reservation mode
	 * @param hospitalId
	 *            the hospital id
	 * @param isBackendBooking
	 *            the is backend booking
	 * @return the reservation model
	 * @throws Exception
	 *             the exception
	 */
	@Override
	@Transactional
	public ReservationModel savePatientInfo(BookingInfo bookingInfo, Integer reservationMode, Integer hospitalId,
			boolean isBackendBooking, Long profileId, Transaction transaction) throws Exception {
		System.out.print(bookingInfo);
		Patient patient;
		if (MssContextHolder.isKcck()) {
			// bookingInfo.setCardNumber(MssNumberUtils.kcckPatientCode(bookingInfo.getCardNumber()));
			patient = getKcckPatientByCardNumber(bookingInfo.getCardNumber(), hospitalId);
		} else {
			patient = getPatientByCardNumber(bookingInfo.getCardNumber(), hospitalId);
		}
		if (patient == null) {
			patient = savePatient(bookingInfo, hospitalId, profileId);
		} else {
			if (bookingInfo.getUserId() != null) {
				User user = this.userRepository.findOne(bookingInfo.getUserId());
				Patient userPatient = user.getPatient();
				if (userPatient == null) {
					user.setPatient(patient);
					userRepository.save(user);
					
				}
				if (profileId > 0 && patient.getProfileId() == null) {
					patient.setProfileId(profileId);
					patientRepository.save(patient);
				}

			}
		}
		// generate TOKEN
		String sessionId = TokenUtils.generateToken();
		Session session = saveSession(sessionId);
		bookingInfo.setTokenId(session.getSessionId());
		Reservation reservation = saveReservation(bookingInfo, patient, session, isBackendBooking, transaction);

		reservation.setReservationCode(MssHelper.generateBookingNumber(
				MssConfiguration.getInstance().getPrefixReservationCode(), reservation.getReservationId().toString()));
		return reservation.toModel(mapper);
	}

	/**
	 * Save patient.
	 * 
	 * @param bookingInfo
	 *            the booking info
	 * @return the patient
	 */
	private Patient savePatient(BookingInfo bookingInfo, Integer hospitalId, Long profileId) {
		Patient patient = new Patient();
		patient.setName(bookingInfo.getPatientName());
		patient.setNameFurigana(bookingInfo.getPatientFurigana());
		patient.setEmail(bookingInfo.getEmail());
		patient.setGender(bookingInfo.getPatientGender());
		patient.setBirthDay(bookingInfo.getPatientBitrhday());
		patient.setPhoneNumber(bookingInfo.getPhoneNumber());
		patient.setCardNumber(bookingInfo.getCardNumber());
		Hospital hospital = this.hospitalRepository.findOne(hospitalId);
		if (hospital != null) {
			patient.setHospital(hospital);
		}
		patient.setActiveFlg(ActiveFlag.ACTIVE.toInt());
		patient.setCreated(new Date());
		patient.setUpdated(new Date());
		// Save childId if booking newborns
		if (DepartmentType.NEWBORNS.toInt().equals(bookingInfo.getDeptType())
				|| DepartmentType.VACCINE.toInt().equals(bookingInfo.getDeptType())) {
			UserChild userChild = this.userChildRepository.findOne(bookingInfo.getChildId());
			if (userChild != null) {
				patient.setUserChild(userChild);
				Patient childPatient = userChild.getPatient();
				if (childPatient != null) {// if child already has patient
					// we update birth day and gender for child (in case child
					// update)
					return childPatient;
				}
				patient.setBirthDay(
						MssDateTimeUtil.dateFromString(userChild.getDob(), DateTimeFormat.DATE_FORMAT_YYYYMMDD));
				patient.setGender("1".equals(userChild.getSex()) ? "M" : "F");
				patient.setName(userChild.getChildName());
				patient.setNameFurigana(userChild.getChildNameFurigana());
				patient = patientRepository.save(patient);
				userChild.setPatient(patient);
				userChild = userChildRepository.save(userChild);
				return patient;
			}
		}
		if (bookingInfo.getUserId() != null) {
			User user = this.userRepository.findOne(bookingInfo.getUserId());
			Patient userPatient = user.getPatient();
			if (userPatient != null) {

				// if rebooking with patient code != patient_code
				if(!Strings.isEmpty(patient.getCardNumber()) && !userPatient.getCardNumber().equals(patient.getCardNumber()))
				{
					patientRepository.save(patient);
					return patient;
				}

				return userPatient;
			}
			user.setPatient(patient);
			userRepository.save(user);
		}

		if (profileId > 0) {
			patient.setProfileId(profileId);
		}

		return patientRepository.save(patient);
	}

	//
	@Override
	@Transactional
	public PatientModel updatePatient(int id, String patientCode, String kcckParentCode) {
		Patient patient = patientRepository.findOne(id);
		if (patient != null) {
			if(StringUtils.isEmpty(patient.getCardNumber()))
			{
				patient.setCardNumber(patientCode);
			}
			patient.setKcckParentCode(kcckParentCode);
		}
		return patient.toModel(mapper);

	}

	/**
	 * Save reservation.
	 * 
	 * @param bookingInfo
	 *            the booking info
	 * @param patient
	 *            the patient
	 * @param session
	 *            the session
	 * @param hospitalId
	 *            the hospital id
	 * @return the reservation
	 */
	private Reservation saveReservation(BookingInfo bookingInfo, Patient patient, Session session,
			boolean isBackendBooking, Transaction transaction) {
		/* Doctor doctor = new Doctor(); */
		Doctor doctor;
		Department department;
		if (MssContextHolder.isKcck()) {
			doctor = new Doctor();
			if (bookingInfo.getDoctorId() != null) {
				doctor.setDoctorId(bookingInfo.getDoctorId());
				doctor.setName(bookingInfo.getDoctorName());
			} else {
				doctor.setDoctorId(999999999);
			}
			department = new Department();
			department.setDeptId(bookingInfo.getDeptId());
		} else {
			doctor = this.doctorRepository.findOne(bookingInfo.getDoctorId());
			doctor.setDoctorId(bookingInfo.getDoctorId());
			department = this.departmentRepository.findOne(bookingInfo.getDeptId());
		}
		Hospital hospital = hospitalRepository.findHospital(MssContextHolder.getHospitalId(), 1);
		Reservation reservation = createReservation(bookingInfo, patient, session, isBackendBooking, doctor, department,
				hospital, transaction);
		return reservation;
	}
	
	private Reservation createReservation(BookingInfo bookingInfo, Patient patient, Session session,
			boolean isBackendBooking, Doctor doctor, Department department, Hospital hospital) {
		Reservation reservation = new Reservation();
		if (session != null) {
			reservation.setSession(session);
		}
		if (bookingInfo.getPatientIconPath() != null) {
			reservation.setReferLink(bookingInfo.getPatientIconPath());
		}
		reservation.setPatient(patient);
		reservation.setDoctor(doctor);
		reservation.setDoctorCode(bookingInfo.getDoctorCode());
		reservation.setDepartment(department);
		reservation.setHospital(hospital);
		reservation.setDeptName(bookingInfo.getDeptName());
		reservation.setDoctorName(doctor.getName());
		reservation.setPatientName(bookingInfo.getPatientName());
		reservation.setReservationDate(bookingInfo.getReservationDate());
		reservation.setReservationTime(bookingInfo.getReservationTime());
		if (isBackendBooking) {
			reservation.setReservationStatus(ReservationStatus.BOOKING_COMPLETED.toInt());
		} else {
			reservation.setReservationStatus(ReservationStatus.BOOKING_ACCEPTED.toInt());
		}
		reservation.setReminderTime(bookingInfo.getReminderTime());
		reservation.setNameFurigana(bookingInfo.getPatientFurigana());
		reservation.setPhoneNumber(bookingInfo.getPhoneNumber());
		if (!StringUtils.isEmpty(bookingInfo.getEmail())) {
			reservation.setEmail(bookingInfo.getEmail());
		}
		reservation.setRegUser("patient"); // TODO: hashcode for FE
		if (DepartmentType.NEWBORNS.toInt().equals(bookingInfo.getDeptType())
				|| DepartmentType.VACCINE.toInt().equals(bookingInfo.getDeptType())) {
			reservation.setPatientName(patient.getName());
			reservation.setNameFurigana(patient.getNameFurigana());
		}
		reservation = reservationRepository.save(reservation);
		return reservation;
	}

	private Reservation createReservation(BookingInfo bookingInfo, Patient patient, Session session,
			boolean isBackendBooking, Doctor doctor, Department department, Hospital hospital, Transaction transaction) {
		Reservation reservation = new Reservation();
		if (session != null) {
			reservation.setSession(session);
		}
		if (bookingInfo.getPatientIconPath() != null) {
			reservation.setReferLink(bookingInfo.getPatientIconPath());
		}
		reservation.setPatient(patient);
		reservation.setDoctor(doctor);
		reservation.setDoctorCode(bookingInfo.getDoctorCode());
		reservation.setDepartment(department);
		if(transaction != null) {
			reservation.setTransaction(transaction);
		}
		reservation.setHospital(hospital);
		reservation.setDeptName(bookingInfo.getDeptName());
		reservation.setDoctorName(doctor.getName());
		reservation.setPatientName(bookingInfo.getPatientName());
		reservation.setReservationDate(bookingInfo.getReservationDate());
		reservation.setReservationTime(bookingInfo.getReservationTime());
		if (isBackendBooking) {
			reservation.setReservationStatus(ReservationStatus.BOOKING_COMPLETED.toInt());
		} else {
			reservation.setReservationStatus(ReservationStatus.BOOKING_ACCEPTED.toInt());
		}
		reservation.setReminderTime(bookingInfo.getReminderTime());
		reservation.setNameFurigana(bookingInfo.getPatientFurigana());
		reservation.setPhoneNumber(bookingInfo.getPhoneNumber());
		if (!StringUtils.isEmpty(bookingInfo.getEmail())) {
			reservation.setEmail(bookingInfo.getEmail());
		}
		reservation.setRegUser("patient"); // TODO: hashcode for FE
		if (DepartmentType.NEWBORNS.toInt().equals(bookingInfo.getDeptType())
				|| DepartmentType.VACCINE.toInt().equals(bookingInfo.getDeptType())) {
			reservation.setPatientName(patient.getName());
			reservation.setNameFurigana(patient.getNameFurigana());
		}
		reservation = reservationRepository.save(reservation);
		return reservation;
	}

	/**
	 * Update reservation.
	 * 
	 * @param reservationModel
	 *            the reservation model
	 */
	@Override
	public void updateReservation(ReservationModel reservationModel) {
		Reservation reservation = reservationModel.toEntity(mapper);
		reservation.setDeptName(reservationModel.getDeptName());
		reservation.setDoctorName(reservationModel.getDoctorName());
		reservation.setDepartCode(reservationModel.getDepartmentCode());
		reservationRepository.save(reservation);
	}

	/**
	 * Save session.
	 * 
	 * @param sessionId
	 *            the session id
	 * @return the session
	 */
	public Session saveSession(String sessionId) {
		Session session = new Session();
		session.setSessionId(sessionId);
		session.setExpired(new Date(new Date().getTime() + (1000 * 60 * 60)));
		// session.setAccessIp(accessIp);
		session.setActiveFlg(ActiveFlag.ACTIVE.toInt());
		session.setCreated(new Date());
		session.setUpdated(new Date());
		session = sessionRepository.save(session);
		return session;
	}

	/**
	 * Gets the session by id.
	 *
	 * @param sessionId
	 *            the session id
	 * @return the session by id
	 */
	public SessionModel getSessionById(String sessionId) {
		Session session = this.sessionRepository.findOne(sessionId);
		return session == null ? null : session.toModel(mapper);
	}

	/**
	 * Gets the late time pending.
	 * 
	 * @param diffirentTime
	 *            the diffirent time
	 * @return the late time pending
	 */
	public String getLateTimePending(long diffirentTime, String locale) {
		String lateTime = "";
		Long hours, minutes;
		hours = diffirentTime / (1000 * 3600);
		minutes = (diffirentTime / (60 * 1000)) % 60;
		if (diffirentTime <= 0) {
			lateTime = "0";
		} else if (hours >= 1) {
			if (locale.equalsIgnoreCase("ja")) {
				lateTime = (hours >= 10 ? hours.toString() : "0" + hours.toString()) + "\u6642\u9593"
						+ minutes.toString();
			} else {
				lateTime = (hours >= 10 ? hours.toString() : "0" + hours.toString()) + ":"
						+ (minutes >= 10 ? minutes.toString() : "0" + minutes.toString());
			}
		} else {
			lateTime = minutes >= 10 ? minutes.toString() : "0" + minutes.toString();
		}
		return lateTime;
	}

	/**
	 * Gets the latest reservation by email.
	 * 
	 * @param email
	 *            the email
	 * @return the latest reservation by email
	 */
	public List<ReservationModel> getReservationListByEmail(String email, Integer hospitalId) {
		List<ReservationModel> result = new ArrayList<ReservationModel>();
		List<Reservation> resList = new ArrayList<>();
		if (MssContextHolder.isKcck()) {
			resList = reservationRepository.findKcckCompletedReservationListByEmail(email, hospitalId);
		} else {
			resList = reservationRepository.findCompletedReservationListByEmail(email, hospitalId);
		}
		if (resList != null && resList.size() > 0) {
			for (Reservation res : resList) {
				ReservationModel resModel = new ReservationModel();
				resModel = res.toModel(mapper, "exclude-departmentAnddoctor");
				resModel.setDepartmentCode(res.getDepartCode());
				result.add(resModel);
			}
		}
		return result;
	}

	/**
	 * Save token into reservation.
	 * 
	 * @param email
	 *            the email
	 * @param sessionId
	 *            the session id
	 * @return true, if successful
	 */
	public boolean saveTokenIntoReservation(Integer reservationId, String sessionId) {
		boolean success = false;

		Reservation result = null;
		Reservation res = reservationRepository.findOne(reservationId);
		if (res != null) {
			result = res;
			Session ss = new Session();
			ss.setSessionId(sessionId);
			result.setSession(ss);
		}
		if (result != null) {
			reservationRepository.save(result);
			success = true;
		}

		return success;
	}

	/**
	 * Gets the latest reservation by patient id.
	 * 
	 * @param patientId
	 *            the patient id
	 * @param limit
	 *            the limit
	 * @return the latest reservation by patient id
	 */
	public List<ReservationModel> getLatestReservationByPatientId(Integer patientId, Integer limit) {
		List<ReservationModel> result = new ArrayList<ReservationModel>();
		List<Reservation> reservations = reservationRepository.findByPatientId(patientId, limit);
		if (reservations != null) {
			for (Reservation reservation : reservations) {
				result.add(reservation.toModel(mapper));
			}
		}
		return result;
	}

	public List<ReservationModel> getListLatestReservationByPatientId(Integer patientId, Integer hospitalId,
			Integer limit) {
		List<ReservationModel> result = new ArrayList<ReservationModel>();
		List<KcckReservationInfo> reservations = reservationRepository.findKcckReservationByPatientId(patientId,
				hospitalId, limit);
		if (reservations != null) {
			for (KcckReservationInfo reservation : reservations) {
				ReservationModel model = new ReservationModel();
				model.setReservationId(reservation.getReservationId());
				model.setHospitalId(reservation.getHospitalId());
				model.setDeptId(reservation.getDeptId());
				model.setDoctorId(reservation.getDoctorId());
				model.setPatientId(reservation.getPatientId());
				model.setPatientName(reservation.getPatientName());
				model.setNameFurigana(reservation.getNameFurigana());
				model.setPhoneNumber(reservation.getPhoneNumber());
				model.setEmail(reservation.getEmail());
				model.setReservationDate(reservation.getReservationDate());
				model.setReservationTime(reservation.getReservationTime());
				model.setSessionId(reservation.getSessionId());
				model.setReservationCode(reservation.getReservationCode());
				model.setReminderTime(reservation.getReminderTime());
				model.setDoctorName(reservation.getDoctorName());
				model.setDoctorCode(reservation.getDoctorCode());
				model.setDeptName(reservation.getDeptName());
				result.add(model);
			}
		}
		return result;
	}

	/**
	 * Gets the reservations by doctor and time slot.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param startTime
	 *            the start time
	 * @return the reservations by doctor and time slot
	 */
	public List<ReservationModel> getReservationsByDoctorAndTimeSlot(Integer doctorId, String startDate,
			String startTime) {
		List<ReservationModel> result = new ArrayList<ReservationModel>();
		List<Reservation> reservationsList = this.reservationRepository.findByDoctorIdAndTimeSlot(doctorId, startDate,
				startTime);
		if (reservationsList != null) {
			for (Reservation reservation : reservationsList) {
				result.add(reservation.toModel(this.mapper));
			}
		}
		return result;
	}

	/**
	 * search Reservation
	 * 
	 * @param reservationModel
	 * @return List reservationModel
	 */
	public List<ReservationModel> searchReservation(ReservationModel reservationModel) {
		List<ReservationModel> result = new ArrayList<ReservationModel>();
		Date modifyFromDate = MssDateTimeUtil.dateFromString(reservationModel.getReservationFromDate(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		reservationModel.setReservationFromDate(
				MssDateTimeUtil.dateToString(modifyFromDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD));
		Date modifyToDate = MssDateTimeUtil.dateFromString(reservationModel.getReservationToDate(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		reservationModel
				.setReservationToDate(MssDateTimeUtil.dateToString(modifyToDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD));

		List<Reservation> reservationsList = this.reservationRepository.searchByCondition(reservationModel);
		if (reservationsList != null) {
			for (Reservation reservation : reservationsList) {
				result.add(reservation.toModel(this.mapper));
			}
		}

		return result;
	}

	/**
	 * update reservation status
	 * 
	 * @param reservationModel
	 * @return
	 */
	public boolean updateReservationStatus(ReservationModel reservationModel) {
		boolean result = false;
		Reservation reservation = this.reservationRepository.findOne(reservationModel.getReservationId());
		if (reservation != null) {
			reservation.setReservationStatus(reservationModel.getReservationStatus());
			reservationRepository.save(reservation);
			result = true;
		}
		return result;
	}

	/**
	 * update reading flag when click into link of email
	 * 
	 * @return {Boolean}
	 * @param token,
	 *            mailTemplateId
	 */
	public boolean updateReadingFlag(String token, Integer mailTemplateId) {
		boolean success = false;
		Reservation reservation = this.reservationRepository.findBySessionId(token);
		List<MailSending> mailSendings = this.mailSendingRepository
				.findBySessionAndMailTemplateId(reservation.getReservationId(), mailTemplateId);
		if (mailSendings.isEmpty()) {
			return false;
		}
		MailSending msd = mailSendings.get(0);
		msd.setReadingFlg(ReadingFlg.READ.toInt());
		try {
			this.mailSendingRepository.save(msd);
			success = true;
		} catch (Exception e) {
			success = false;
		}
		return success;
	}

	/**
	 * 
	 * @param mailTemplateCode
	 * @param locale
	 * @return
	 */
	public MailTemplateModel getMailTemplateByCode(String mailTemplateCode, String locale, Integer hospitalId) {
		// MailTemplate mailTemplate =
		// this.mailTemplateRepository.findByMailTemplate(mailTemplateCode,
		// locale, hospitalId);
		MailTemplate mailTemplate = new MailTemplate();
		List<MailTemplate> mailTemplateList = mailTemplateRepository.findByMailTemplate(mailTemplateCode, locale,
				hospitalId, SendType.MAIL.toInt());
		if (!CollectionUtils.isEmpty(mailTemplateList)) {
			mailTemplate = mailTemplateList.get(0);
		}
		return mailTemplate.toModel(mapper);
	}

	/**
	 * Cancel reservation in id list.
	 *
	 * @param reservationIdList
	 *            the reservation id list
	 * @return true, if successful
	 */
	public boolean cancelReservationInIdList(Collection<Integer> reservationIds) {
		boolean result = false;
		if (reservationIds.size() > 0) {
			if (this.reservationRepository.cancelReservationInIdList(reservationIds) == reservationIds.size())
				result = true;
		}
		return result;
	}

	/**
	 * Update doctor reservation by id.
	 *
	 * @param reservationMap
	 *            the reservation map
	 * @return true, if successful
	 */
	public boolean updateDoctorReservationById(Map<Integer, Integer> reservationMap) {
		boolean result = false;
		if (reservationMap.size() > 0) {
			result = this.reservationRepository.updateDoctorReservationById(reservationMap);
		}
		return result;
	}

	/**
	 * Update doctor for reservation.
	 *
	 * @param doctorId
	 *            the doctor id
	 * @param reservationId
	 *            the reservation id
	 * @throws Exception
	 *             the exception
	 */
	@Override
	public void updateDoctorForReservation(Integer doctorId, Integer reservationId) throws Exception {
		this.reservationRepository.updateDoctorForReservation(doctorId, reservationId);
	}

	public List<ReservationInfo> searchReservationInfo(ReservationModel reservationModel) throws Exception {
		List<ReservationInfo> result = new ArrayList<ReservationInfo>();
		Date modifyFromDate = MssDateTimeUtil.dateFromString(reservationModel.getReservationFromDate(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		reservationModel.setReservationFromDate(
				MssDateTimeUtil.dateToString(modifyFromDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD));
		Date modifyToDate = MssDateTimeUtil.dateFromString(reservationModel.getReservationToDate(),
				DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		reservationModel
				.setReservationToDate(MssDateTimeUtil.dateToString(modifyToDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD));

		result = this.reservationRepository.searchReservationInfoByCondition(reservationModel);
		return result;
	}

	@Override
	public PatientModel findKcckPatientByCardNumber(String cardNumber, Integer hospitalId) {

		Patient patient = getKcckPatientByCardNumber(cardNumber, hospitalId);
		return patient == null ? null : patient.toModel(mapper);
	}

	/**
	 * Gets the patient by card number.
	 * 
	 * @param cardNumber
	 *            the card number
	 * @return the patient by card number
	 */
	private Patient getKcckPatientByCardNumber(String cardNumber, Integer hospitalId) {
		List<Patient> patientList = this.patientRepository.findKcckPatientByCardNumber(cardNumber, hospitalId);
		if (patientList == null || patientList.isEmpty()) {
			return null;
		}
		return patientList.get(0);
	}

	@Override
	public PatientModel findPatientById(Integer id) {
		Patient patient = getPatientById(id);
		return patient == null ? null : patient.toModel(mapper);
	}

	private Patient getPatientById(Integer id) {
		List<Patient> patientList = this.patientRepository.findPatientById(id);
		if (patientList == null || patientList.isEmpty()) {
			return null;
		}
		return patientList.get(0);
	}

	@Override
	public PatientModel getParentByChildId(Integer childId) {
		UserChild userChild = this.userChildRepository.findOne(childId);
		Patient patient = userChild.getUser().getPatient();
		if (patient != null) {
			return patient.toModel(mapper);
		}
		return null;

	}

	@Override
	public String getChildCodeList(String kcckParentCode) {
		String childCodeList = "";
		List<Patient> patientList = this.patientRepository.getListPatientByKcckParentCode(kcckParentCode);
		if (patientList != null || !patientList.isEmpty()) {
			for (Patient p : patientList) {
				if (!StringUtils.isEmpty(childCodeList) && patientList.size() > 1) {
					childCodeList += ";";
				}
				childCodeList += p.getCardNumber();

			}
		}
		return childCodeList;
	}

}
