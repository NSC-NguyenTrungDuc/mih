package nta.mss.service.impl;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.time.*;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Comparator;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.Map.Entry;
import java.util.stream.Collectors;

import nta.mss.misc.common.MssContextHolder;
import org.apache.commons.lang.StringUtils;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.kcck.model.KcckBookingSlotModel;
import nta.kcck.model.TimeslotScheduleModel;
import nta.kcck.service.impl.KcckDepartmentService;
import nta.kcck.service.impl.KcckDoctorService;
import nta.mss.entity.Doctor;
import nta.mss.entity.DoctorSchedule;
import nta.mss.entity.DoctorSchedulePK;
import nta.mss.entity.Reservation;
import nta.mss.info.MailSendingInfo;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.model.ReservationKpiModel;
import nta.mss.model.ReservationModel;
import nta.mss.model.ScheduleMailHistoryModel;
import nta.mss.model.ScheduleMailHistoryTempModel;
import nta.mss.repository.DepartmentRepository;
import nta.mss.repository.DoctorRepository;
import nta.mss.repository.DoctorScheduleRepository;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.MailSendingRepositoryCustom;
import nta.mss.repository.ReservationRepository;
import nta.mss.service.IScheduleService;

/**
 * The Class ScheduleService.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
@Service
@Transactional
public class ScheduleService implements IScheduleService {
	private Mapper mapper;
	private HospitalRepository hospitalRepository;
	private ReservationRepository reservationRepository;
	private DepartmentRepository departmentRepository;
	private DoctorScheduleRepository doctorScheduleRepository;
	private DoctorRepository doctorRepository;
	private MailSendingRepositoryCustom mailSendingRepositoryCustom;
	private KcckDoctorService kcckDoctorService = new KcckDoctorService();
	private KcckDepartmentService kcckDepartmentService = new KcckDepartmentService();

	public ScheduleService() {
	}

	@Autowired
	public ScheduleService(Mapper mapper, HospitalRepository hospitalRepository,
			DepartmentRepository departmentRepository, ReservationRepository reservationRepository,
			DoctorScheduleRepository doctorScheduleRepository, DoctorRepository doctorRepository ,MailSendingRepositoryCustom mailSendingRepositoryCustom ) {
		this.mapper = mapper;
		this.hospitalRepository = hospitalRepository;
		this.reservationRepository = reservationRepository;
		this.departmentRepository = departmentRepository;
		this.doctorScheduleRepository = doctorScheduleRepository;
		this.doctorRepository = doctorRepository;
		this.mailSendingRepositoryCustom = mailSendingRepositoryCustom;
	}

	/**
	 * Gets the total reservation and kpi.
	 *
	 * @param deptId
	 *            the dept id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the total reservation and kpi
	 */
	public Map<String, ReservationKpiModel> getTotalReservationAndKpi(Integer deptId, String startDate,
			String endDate) {
		Map<String, ReservationKpiModel> result = new HashMap<String, ReservationKpiModel>();
		List<Doctor> lstDoctor = this.doctorRepository.findByDeptId(deptId);

		Map<String, Long> reservations;
		Map<String, Long> doctorKpi;

		if (!lstDoctor.isEmpty()) {
			for (Doctor doctor : lstDoctor) {
				reservations = this.getDoctorReservationByTimeSlot(doctor.getDoctorId(), startDate, endDate);
				doctorKpi = this.getDoctorKpiByTimeSlot(doctor.getDoctorId(), startDate, endDate);
				String entryKey;
				Long entryValue;
				for (Entry<String, Long> entry : doctorKpi.entrySet()) {
					entryKey = entry.getKey();
					entryValue = entry.getValue();
					result.put(entryKey + "_" + doctor.getDoctorId(),
							new ReservationKpiModel(
									reservations.get(entryKey) == null ? Long.valueOf(0) : reservations.get(entryKey),
									entryValue));
				}
			}
		}

		return result;
	}

	/**
	 * Check doctor schedule.
	 *
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the map
	 */
	@Override
	public Map<String, Boolean> checkDoctorSchedule(Integer doctorId, String startDate, String endDate) {
		Map<String, Boolean> result = new LinkedHashMap<String, Boolean>();
		Map<String, Long> reservations = this.getDoctorReservationByTimeSlot(doctorId, startDate, endDate);
		Map<String, Long> doctorKpi = this.getDoctorKpiByTimeSlot(doctorId, startDate, endDate);
		String entryKey;
		Long entryValue;
		for (Entry<String, Long> entry : doctorKpi.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			if (reservations.get(entryKey) == null && entryValue == 0) {
				result.put(entryKey, false);
			} else if (reservations.get(entryKey) != null && reservations.get(entryKey) >= entryValue) {
				result.put(entryKey, false);
			} else {
				result.put(entryKey, true);
			}
		}
		return result;
	}

	/**
	 * Check doctor schedule.
	 *
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the map
	 */
	//TODO
	@Override
	public TimeslotScheduleModel getDoctorTimeslotSchedule(Integer deptId, Integer doctorId, String startDate,
			String endDate) {

		// return this.doctorScheduleRepository.getTimeslotListByDeptId(deptId);
		Map<String, List<KcckBookingSlotModel>> result = new LinkedHashMap<String, List<KcckBookingSlotModel>>();
		Map<String, Long> reservations = this.getDoctorReservationByTimeSlot(doctorId, startDate, endDate);
		Map<String, Long> doctorKpi = this.getDoctorKpiByTimeSlot(doctorId, startDate, endDate);
		String entryKey;
		Long entryValue;
		for (Entry<String, Long> entry : doctorKpi.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			if (reservations.get(entryKey) != null && reservations.get(entryKey) >= entryValue) {
			} else {
				ArrayList<KcckBookingSlotModel> bookingFrames = new ArrayList<KcckBookingSlotModel>();
				bookingFrames.add(new KcckBookingSlotModel(null, entryKey.substring(9, 13), null,null));
				result.put(entryKey, bookingFrames);
			}
		}
		String avgTime = "30";
		ArrayList<String> timeFrames = new ArrayList<String>(this.doctorScheduleRepository.getTimeslotListByDeptId(deptId));
		if(timeFrames.size() > 2){
			LocalTime lt1 = LocalTime.parse(timeFrames.get(0), DateTimeFormatter.ofPattern("HHmm"));
			LocalTime lt2 = LocalTime.parse(timeFrames.get(1), DateTimeFormatter.ofPattern("HHmm"));
			avgTime = String.valueOf(lt1.until(lt2, ChronoUnit.MINUTES));
		}

		return new TimeslotScheduleModel(
				new ArrayList<String>(this.doctorScheduleRepository.getTimeslotListByDeptId(deptId)),
				result,
				avgTime
		);
	}

	/**
	 * Gets the doctor reservation by time slot.
	 *
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the doctor reservation by time slot
	 */
	private Map<String, Long> getDoctorReservationByTimeSlot(Integer doctorId, String startDate, String endDate) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> reservations = this.reservationRepository.getDoctorReservationsBetweenDate(doctorId, startDate,
				endDate);
		if (reservations != null) {
			if (!reservations.isEmpty()) {
				for (Object[] objects : reservations) {
					result.put(MssDateTimeUtil.concatenateDateTime(objects[1].toString(), objects[2].toString()),
							(Long) objects[3]);
				}
			}
		}
		return result;
	}

	/**
	 * Gets the doctor kpi by time slot.
	 *
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the doctor kpi by time slot
	 */
	private Map<String, Long> getDoctorKpiByTimeSlot(Integer doctorId, String startDate, String endDate) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> doctorKpi = this.doctorScheduleRepository.calculateDoctorKpi(doctorId, startDate, endDate);
		if (doctorKpi != null) {
			if (!doctorKpi.isEmpty()) {
				for (Object[] objects : doctorKpi) {
					result.put(MssDateTimeUtil.concatenateDateTime(objects[1].toString(), objects[2].toString()),
							(Long) objects[3]);
				}
			}
		}
		return result;
	}

	/**
	 * Update kpi for doctors by time slot.
	 * 
	 * @param hospitalId
	 *            the hospital id
	 * @param deptId
	 *            the dept id
	 * @param doctorId
	 *            the doctor id
	 * @param date
	 *            the date
	 * @param time
	 *            the time
	 * @param kpiPlus
	 *            the kpi plus
	 * @return true, if successful
	 */
	public boolean updateKpiForDoctorsByTimeSlot(Integer hospitalId, Integer deptId, Integer doctorId, String date,
			String time, Integer kpiPlus, String endTime) {
		boolean success = true;
		try {
			DoctorSchedule dosc = null;
			List<DoctorSchedule> ds = this.doctorScheduleRepository.findDoctorByDoctorIdAndTimeSlot(doctorId, date,
					time);
			if (!ds.isEmpty()) {
				dosc = ds.get(0);
			}
			if (dosc != null) {
				dosc.setKpi(dosc.getKpi() + kpiPlus);
			}
			if (dosc == null) {
				dosc = new DoctorSchedule();
				dosc.setKpi(kpiPlus);
				dosc.setId(new DoctorSchedulePK(doctorId, date, time));
				dosc.setHospital(hospitalRepository.findOne(hospitalId));
				dosc.setEndTime(endTime);
				dosc.setDepartment(departmentRepository.findOne(deptId));
			}
			this.doctorScheduleRepository.save(dosc);
		} catch (Exception e) {
			success = false;
		}
		return success;
	}

	/**
	 * Gets the reservation by doctor and timeslot.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param checkDate
	 *            the check date
	 * @param startTime
	 *            the start time
	 * @return the reservation by doctor and timeslot
	 */
	public List<ReservationModel> getReservationByDoctorAndTimeslot(Integer doctorId, String checkDate,
			String startTime) {
		List<Reservation> reservations = this.reservationRepository.findByDoctorIdAndTimeSlot(doctorId, checkDate,
				startTime);
		List<ReservationModel> result = new ArrayList<ReservationModel>();
		if (reservations != null) {
			for (Reservation reservation : reservations) {
				result.add(reservation.toModel(mapper));
			}
		}
		return result;
	}

	/**
	 * Gets the reservation in doctor and timeslot list.
	 *
	 * @param doctorSchedulePKList
	 *            the doctor schedule pk list
	 * @return the reservation in doctor and timeslot list
	 */
	public Map<DoctorSchedulePK, List<ReservationModel>> getReservationInDoctorAndTimeslotList(
			List<DoctorSchedulePK> doctorSchedulePKList) {
		Map<DoctorSchedulePK, List<ReservationModel>> result = new LinkedHashMap<DoctorSchedulePK, List<ReservationModel>>();
		// get reservations from DB
		List<Reservation> reservations = this.reservationRepository.findInDoctorIdAndTimeSlotList(doctorSchedulePKList);
		if (reservations != null) {
			DoctorSchedulePK reservationKeys;
			List<ReservationModel> reservationModelList;
			for (DoctorSchedulePK doctorSchedulePK : doctorSchedulePKList) {
				reservationModelList = new ArrayList<ReservationModel>();
				for (Reservation reservation : reservations) {
					reservationKeys = new DoctorSchedulePK(reservation.getDoctor().getDoctorId(),
							reservation.getReservationDate(), reservation.getReservationTime());
					if (doctorSchedulePK.equals(reservationKeys)) {
						reservationModelList.add(reservation.toModel(mapper));
					}
				}
				result.put(doctorSchedulePK, reservationModelList);
			}
		}
		return result;
	}

	/**
	 * Gets the info search schedule mail history.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param reservationDate
	 *            the reservation date
	 * @return the info search schedule mail history
	 */

	public List<ScheduleMailHistoryModel> getInfoSearchScheduleMailHistory(Integer hospitalId, Integer deptId,
			String fromDate, String toDate){
		List<ScheduleMailHistoryModel> lstModel = new ArrayList<>();
		List<ScheduleMailHistoryTempModel> lstTempModel = new ArrayList<ScheduleMailHistoryTempModel>();;
		ScheduleMailHistoryModel model;
		ScheduleMailHistoryTempModel modelTemp  ;
		
		Date modifyFromDate = null;
		if (!StringUtils.isBlank(fromDate)) {
			modifyFromDate = MssDateTimeUtil.dateFromString(fromDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		}
		Date modifyToDate = null;
		if (!StringUtils.isBlank(toDate)) {
			modifyToDate = MssDateTimeUtil.dateFromString(toDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		}
		List<MailSendingInfo> lstInfos = this.mailSendingRepositoryCustom.searchKcckInfoScheduleMailHistory(hospitalId, deptId, modifyFromDate, modifyToDate);
		for (MailSendingInfo objects : lstInfos) {
			modelTemp = new ScheduleMailHistoryTempModel();
			modelTemp.setDoctorId( objects.getDoctorId());
			modelTemp.setDoctorName( objects.getDoctorName());
			modelTemp.setCheckDate(MssDateTimeUtil.convertStringDate(objects.getReservationDate(),
					DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
			modelTemp.setTimeSlot(MssDateTimeUtil.convertStringDate((String) objects.getReservationTime(),
					DateTimeFormat.TIME_FORMAT_HH_MM, DateTimeFormat.TIME_FORMAT_HH_MM_DEFAULT));
			modelTemp.setPatientName( objects.getPatientName());
			modelTemp.setEmail(objects.getEmail());
			modelTemp.setPhoneNumber(objects.getPhoneNumber());
			modelTemp.setReadingFlg(objects.getReadingFlg());
			modelTemp.setSendingStatus(Integer.valueOf( objects.getSendingStatus().toString()));
			modelTemp.setSubject(objects.getSubject());
			lstTempModel.add(modelTemp);
		}
	
		Map<Integer, ScheduleMailHistoryModel> doctorList = new HashMap<>();
		for (ScheduleMailHistoryTempModel s : lstTempModel) {
			ScheduleMailHistoryModel doctor = doctorList.get(s.getDoctorId());
			if(doctor == null){
				doctor = new ScheduleMailHistoryModel(
						null,
						s.getDepartmentId(),
						null,
						null,
						s.getDoctorId(),
						s.getDoctorName(),
						new ArrayList<ScheduleMailHistoryTempModel>()
						);
				doctorList.put(s.getDoctorId(), doctor);
			}			
			doctor.getTempModel().add(s);
		}
		
		return new ArrayList<ScheduleMailHistoryModel>(doctorList.values());
				
		
	}

	/**
	 * get Rerservation by doctorId
	 * 
	 * @param doctorId
	 * @return
	 */
	public List<ReservationModel> getReservationByDoctor(Integer doctorId) {
		List<Reservation> reservations = this.reservationRepository.findByDoctorId(doctorId);
		List<ReservationModel> result = new ArrayList<ReservationModel>();
		if (reservations != null) {
			for (Reservation reservation : reservations) {
				result.add(reservation.toModel(mapper));
			}
		}
		return result;
	}

	/**
	 * delete doctor by deactive record
	 * 
	 * @param doctorId
	 * @return
	 */
	public boolean deleteDoctor(Integer doctorId) {
		if (doctorId == null) {
			return false;
		}
		Doctor doctor = this.doctorRepository.findOne(doctorId);
		if (doctor != null) {
			doctor.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			this.doctorRepository.save(doctor);
			return true;
		}
		return false;
	}

	/**
	 * Check existing reservation of doctor.
	 *
	 * @param doctorId
	 *            the doctor id
	 * @return true, if successful
	 */
	@Override
	public boolean existReservationOfDoctor(Integer doctorId) {
		String currentDate = MssDateTimeUtil.dateToString(new Date(),
				DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM);
		List<Reservation> reservations = this.reservationRepository.findFutureReservationByDoctorId(doctorId,
				currentDate);
		if (reservations.size() != 0) {
			return true;
		}
		return false;
	}
	
	@Override
	public List<KcckBookingSlotModel> getDoctorScheduleFasterBySchedule(TimeslotScheduleModel model ) {
		String currentDate = getStrCurrentDate();
		List<KcckBookingSlotModel> kcckBookingCurrentDate = model.getSchedule().entrySet().stream().filter(p -> p.getKey().split("_")[0].equals(currentDate))
				.flatMap(p -> p.getValue().stream()).collect(Collectors.toList());
		return  (List<KcckBookingSlotModel>) model.getSchedule().entrySet().stream()
																.filter(p -> p.getKey().split("_")[0].equals(currentDate)) //-->  Map<String, List<KcckBookingSlotModel>> with current date																
																.flatMap(p -> p.getValue().stream()) 
																.collect(Collectors.toSet()) // --> List<KcckBookingSlotModel>
																																
																.stream().collect(Collectors.groupingBy(KcckBookingSlotModel::getDoctor_code)).entrySet() // --->partitioningBy to Map<String,List<KcckBookingSlotModel>> with key Doctor_code , value List<KcckBookingSlotModel>  
																			
																.stream().collect(Collectors.toMap(e -> e.getKey() , e ->getkcckBookingSlotModelNearest(e.getValue()))).entrySet().stream()  // ---> convert to Map<String,KcckBookingSlotModel>  with key Doctor_code
																.filter(x -> x.getValue().getDoctor_code() != "").map(x -> x.getValue()).collect(Collectors.toList()); // ---> convert to List<KcckBookingSlotModel> has doctor_code exists		
	

	}
	
	@Override
	public TimeslotScheduleModel getScheduleCanBookingAsCurrentTime(TimeslotScheduleModel model ){
		// String currTime = new SimpleDateFormat("HHmm").format(new Date());

//		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
//		OffsetTime checkTime = selectedDateTime.atOffset(zoneOffset);
//		OffsetDateTime now = Instant.now().atOffset(zoneOffset);
		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);

		 String currentDate = getStrCurrentDate();
		 Map<String, List<KcckBookingSlotModel>> scheduleNew = new HashMap<>();
		 Map<String, List<KcckBookingSlotModel>> schedule = model.getSchedule();
		 if(!schedule.isEmpty())
		 {
			 scheduleNew = schedule.entrySet()
			            .stream()
			            .filter(p ->{
							LocalDateTime selectedDateTime = LocalDateTime.parse(MssDateTimeUtil.dateToString(new Date(), DateTimeFormat.DATE_FORMAT_YYYYMMDD) + p.getKey().split("_")[1],
									DateTimeFormatter.ofPattern("yyyyMMddHHmm"));

							OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);

							return (!p.getKey().split("_")[0].equals(currentDate) ||
								(p.getKey().split("_")[0].equals(currentDate) &&
										checkTime.compareTo(now)>= 0 ) );
						})
			            .collect(Collectors.toMap(p -> p.getKey(), p -> p.getValue()));
			 	 model.setSchedule(scheduleNew);
		 }
		 return model;
	}
	
	public KcckBookingSlotModel getkcckBookingSlotModelNearest(List<KcckBookingSlotModel> kcckBookingSlotModels)
	{
		ZoneOffset zoneOffset = ZoneOffset.ofHours(MssContextHolder.getHospital().getTimeZone());
		OffsetDateTime now = Instant.now().atOffset(zoneOffset);

	    Optional<KcckBookingSlotModel> optionKcckBookingModel = kcckBookingSlotModels.stream()
				.filter(p ->{
					LocalDateTime selectedDateTime = LocalDateTime.parse(MssDateTimeUtil.dateToString(new Date(), DateTimeFormat.DATE_FORMAT_YYYYMMDD) + p.getStart_time(),
							DateTimeFormatter.ofPattern("yyyyMMddHHmm"));
					OffsetDateTime checkTime = selectedDateTime.atOffset(zoneOffset);
					return
							checkTime.compareTo(now)>= 0 ;})
				.collect(Collectors.minBy(new Comparator<KcckBookingSlotModel>() {
					@Override
					public int compare(KcckBookingSlotModel o1, KcckBookingSlotModel o2) {
						// TODO Auto-generated method stub
						return Integer.valueOf(o1.getStart_time()) - Integer.valueOf(o2.getStart_time());
					}
				}));
	
		return optionKcckBookingModel.isPresent() ? optionKcckBookingModel.get() : new KcckBookingSlotModel("", "", "", ""); 
	}
	
	private String getStrCurrentDate() {
		DateFormat df = new SimpleDateFormat("yyyyMMdd");
		Date today = Calendar.getInstance().getTime();
		return df.format(today);
	}
}
