package nta.med.ext.mss.service.impl;

import nta.med.common.util.DateTimes;
import nta.med.common.util.Strings;
import nta.med.common.util.type.Pair;
import nta.med.common.util.type.Triple;
import nta.med.core.domain.mss.Hospital;
import nta.med.core.domain.mss.Patient;
import nta.med.core.domain.mss.Reservation;
import nta.med.core.glossary.ActiveFlag;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.MailCode;
import nta.med.core.glossary.ReservationStatus;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.mss.HospitalRepository;
import nta.med.data.dao.mss.PatientRepository;
import nta.med.data.dao.mss.ReservationRepository;
import nta.med.data.dao.mss.SessionRepository;
import nta.med.data.model.ihis.nuro.*;
import nta.med.ext.mss.common.MbsConfiguration;
import nta.med.ext.mss.glossary.DateTimeFormat;
import nta.med.ext.mss.glossary.Message;
import nta.med.ext.mss.glossary.ScheduleCache;
import nta.med.ext.mss.model.*;
import nta.med.ext.mss.service.BookingService;
import nta.med.ext.mss.service.MailService;
import nta.med.ext.support.glossary.EventMetaStore;
import nta.med.ext.support.proto.BookingModelProto;
import nta.med.ext.support.proto.BookingServiceProto;
import nta.med.ext.support.proto.HospitalModelProto;
import nta.med.ext.support.proto.HospitalServiceProto;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.AbstractRpcExtListener;
import nta.med.ext.support.service.booking.BookingRpcService;
import nta.med.ext.support.service.hospital.HospitalRpcService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.cache.CacheManager;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.annotation.Resource;
import java.util.*;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;
import java.util.stream.Collectors;

import static nta.med.core.utils.BookingUtils.createBookingDate;
import static nta.med.core.utils.BookingUtils.createTimeFrames;
import static nta.med.ext.mss.glossary.ScheduleCache.doctorSchedules;

/**
 * @author dainguyen.
 */
@Service("bookingService")
public class BookingServiceImpl implements BookingService {

	@Resource
	private HospitalRpcService hospitalRpcService;
	
	@Resource
	private BookingRpcService bookingRpcService;

    @Resource
    private CacheManager cacheManager;
    
	private static final Logger LOGGER = LoggerFactory.getLogger(BookingServiceImpl.class);

    @Override
    public List<DoctorModel> findDoctorByDepartment(String hospCode, String departmentCode) {
    	HospitalServiceProto.GetDoctorByDepartmentRequest.Builder doctorRequest = HospitalServiceProto.GetDoctorByDepartmentRequest.newBuilder();
    	doctorRequest.setHospCode(hospCode);
    	doctorRequest.setDepartmentCode(departmentCode);
		HospitalServiceProto.GetDoctorByDepartmentResponse doctorResponse = hospitalRpcService.getDoctors(doctorRequest.build());

		List<DoctorModel> doctorModels = new ArrayList<>();
		if(doctorResponse != null){
			for(HospitalModelProto.Doctor doctor : doctorResponse.getDoctorsList())
			{
				DoctorModel doctorModel = new DoctorModel();
				BeanUtils.copyProperties(doctor, doctorModel, Language.JAPANESE.toString());
				doctorModels.add(doctorModel);
			}
		}	
		return doctorModels;
    }
	
	private Map<String, List<BookingSchedule>> getDepartmentSchedule(String hospitalCode, String departmentCode,
																		   String startDate, String endDate, String doctorCode, KCCKGetDoctorWorkingTimeInfo doctorWorkingTime) {
		final String key1 = String.format("%s-%s", hospitalCode, departmentCode);
		final String key2 = String.format("%s-%s", startDate, endDate);
		LOGGER.info("BookingSchedule getDepartmentSchedule: "+ key1);
		LOGGER.info("BookingSchedule getDepartmentSchedule: "+ key2);
		LOGGER.info("BookingSchedule getDepartmentSchedule contain key 1: " + doctorSchedules.containsKey(key1));
		if(!doctorSchedules.containsKey(key1)) doctorSchedules.putIfAbsent(key1, new Triple<>(false, "60" , new ConcurrentHashMap<>()));
		if(!doctorSchedules.get(key1).getV3().containsKey(key2))
		{
			LOGGER.info("BookingSchedule call med app ");
			HospitalServiceProto.SearchBookingScheduleRequest request = HospitalServiceProto.SearchBookingScheduleRequest.newBuilder()
					.setHospCode(hospitalCode).setDepartment(departmentCode).setStartDate(startDate).setEndDate(endDate).build();
			HospitalServiceProto.SearchBookingScheduleResponse response = hospitalRpcService.getScheduleDoctor(request);
			List<HospitalModelProto.BookingSchedule> schedule = new ArrayList<>();
			if(response != null){
				doctorWorkingTime.setDoctorIsDifferentAvgTime(response.getIsDifferentTimeFrame());
				doctorWorkingTime.setAvgTime(response.getAvgTime());
				schedule = response.getSchedulesList();
				doctorSchedules.get(key1).setV1(response.getIsDifferentTimeFrame());
				doctorSchedules.get(key1).setV2(response.getAvgTime());
				doctorSchedules.get(key1).getV3().putIfAbsent(key2, schedule.stream().map(s -> {
					BookingSchedule r = new BookingSchedule();
					BeanUtils.copyProperties(s, r, Language.JAPANESE.toString());
					List<BookingScheduleDetail> scheduleDetails = s.getPeriodList().stream().map(sd -> {
						BookingScheduleDetail d = new BookingScheduleDetail();
						BeanUtils.copyProperties(sd, d, Language.JAPANESE.toString());
						return d;
					}).collect(Collectors.toList());
					r.setPeriod(scheduleDetails);
					return r;
				}).collect(Collectors.groupingBy(s -> s.getDoctorCode())));
			}
		}
		LOGGER.info("INFO [doctorSchedules] key1: " + key1);
		LOGGER.info("INFO [doctorSchedules] key2: " + key2);
		return doctorSchedules.get(key1).getV3().get(key2);
	}

	@Override
	public List<KCCKGetDoctorWorkingTimeInfo> getDoctorScheduleInfo(String hospitalCode, String departmentCode,
																		   String startDate, String endDate, String doctorCode, String avgTime, String doctorGrade) {
		//doctorSchedules.clear(); //TODO
		KCCKGetDoctorWorkingTimeInfo doctorWorkingTimeInfo = new KCCKGetDoctorWorkingTimeInfo();

		Map<String, List<BookingSchedule>> departSchedules = getDepartmentSchedule(hospitalCode, departmentCode, startDate, endDate, doctorCode, doctorWorkingTimeInfo);
		final String key1 = String.format("%s-%s", hospitalCode, departmentCode);
		doctorWorkingTimeInfo.setDoctorIsDifferentAvgTime(doctorSchedules.get(key1).getV1());
		doctorWorkingTimeInfo.setAvgTime(doctorSchedules.get(key1).getV2());


		List<KCCKGetDoctorWorkingTimeInfo> r = new ArrayList<>();
		if(departSchedules == null || departSchedules.size() == 0) return r;
		if(!Strings.isEmpty(doctorCode)) {
			//search by doctor
			List<BookingSchedule> schedules = departSchedules.get(doctorCode);
			
			return convert(schedules, startDate, endDate, doctorWorkingTimeInfo);
		} else {
			List<BookingSchedule> schedules = new ArrayList<>();
			for (Map.Entry<String, List<BookingSchedule>> entry : departSchedules.entrySet())
			{
				schedules.addAll(entry.getValue());
			}
			if(!StringUtils.isEmpty(doctorGrade)){
				schedules = schedules.stream().filter(i -> i.getDoctorGrade().equals(doctorGrade)).collect(Collectors.toList());
			} else {
				schedules = schedules.stream().filter(i -> !i.getDoctorGrade().equals("6")).collect(Collectors.toList());
			}
			return convert(schedules, startDate, endDate, doctorWorkingTimeInfo);
		}
	}

	private List<KCCKGetDoctorWorkingTimeInfo> convert(List<BookingSchedule> schedules, String startDate, String endDate, KCCKGetDoctorWorkingTimeInfo doctorWorkingTime) {
		Integer timeFrame = CommonUtils.parseInteger(doctorWorkingTime.getAvgTime());
		boolean differentTimeFrame = doctorWorkingTime.isDoctorIsDifferentAvgTime();
		List<KCCKGetDoctorWorkingTimeInfo> r = new ArrayList<>();
		if(schedules == null || schedules.size() == 0) return r;
		if(timeFrame == null) {
			BookingSchedule item = schedules.get(0);
			timeFrame = (int)(DateTimes.toDate("yyyyMMdd HHmm", "20150101 " + item.getResPmEndHhmm()).getTime() - DateTimes.toDate("yyyyMMdd HHmm", "20150101 " + item.getResAmStartHhmm()).getTime())/(1000 * 60);
		}

		String startAm = schedules.stream().map(s -> s.getResAmStartHhmm()).min(String::compareTo).get();
		String endAm = schedules.stream().map(s -> s.getResAmEndHhmm()).max(String::compareTo).get();
		String startPm = schedules.stream().map(s -> s.getResPmStartHhmm()).min(String::compareTo).get();
		String endPm = schedules.stream().map(s -> s.getResPmEndHhmm()).max(String::compareTo).get();
		
		KCCKGetDoctorWorkingTimeInfo result = new KCCKGetDoctorWorkingTimeInfo(startAm, endAm, startPm, endPm, Strings.toString(timeFrame));
		List<Pair<String>> frames = createTimeFrames(startAm, endAm, timeFrame);
		frames.addAll(createTimeFrames(startPm, endPm, timeFrame));
		
		List<KCCKGetEnableScheduleDoctorInfo> enableSlots = new ArrayList<>();
		// all
		Map<String, List<BookingSchedule>> bookedDetails = schedules.stream().collect(Collectors.groupingBy(s -> s.getBookingDate()));
		for (String bookingDate : createBookingDate(startDate, endDate)) {
			List<BookingSchedule> bookedByDate = bookedDetails.get(bookingDate);
			if(bookedByDate != null && bookedByDate.size() > 0) {
				for(Pair<String> frame : frames) {
					KCCKGetEnableScheduleDoctorInfo enableSlot = new KCCKGetEnableScheduleDoctorInfo(bookingDate, frame.getV1());
					List<KCCKGetEnableBookDoctorInfo> enableBookingSlots = new ArrayList<>();
					for (BookingSchedule bookingSchedule : bookedByDate) {
						List<BookingScheduleDetail> periods = bookingSchedule.getPeriod();
						for (BookingScheduleDetail bookingScheduleDetail : periods) {
							if((bookingScheduleDetail.getStartTime().compareTo(frame.getV1()) >= 0 && bookingScheduleDetail.getStartTime().compareTo(frame.getV2()) < 0)
									|| (bookingScheduleDetail.getEndTime().compareTo(frame.getV1()) > 0 && bookingScheduleDetail.getEndTime().compareTo(frame.getV2()) <= 0)){
								if(bookingScheduleDetail.isAvailable(frame, bookingSchedule.getTotalSlots(), bookingSchedule.getOtherSlots())){
									KCCKGetEnableBookDoctorInfo bookingSlot = new KCCKGetEnableBookDoctorInfo();
									bookingSlot.setDoctorCode(bookingSchedule.getDoctorCode());
									bookingSlot.setStartTime(bookingScheduleDetail.getStartTime());
									bookingSlot.setEndTime(bookingScheduleDetail.getEndTime());
									enableBookingSlots.add(bookingSlot);
								}
							}
						}
					}
					if(!CollectionUtils.isEmpty(enableBookingSlots)){
						enableSlot.setEnableBookingSlot(enableBookingSlots);
						enableSlots.add(enableSlot);
					}
				}
			}
		}
		result.setEnableSlot(enableSlots);
		return Arrays.asList(result);
	}


	@Override
    public SearchDoctorModel searchDoctors(SearchDoctorModel searchDoctorModel) {
    	HospitalServiceProto.SearchDoctorRequest.Builder doctorRequest = HospitalServiceProto.SearchDoctorRequest.newBuilder();
    	doctorRequest.setHospCode(searchDoctorModel.getHospCode() == null ? "" : searchDoctorModel.getHospCode());
    	doctorRequest.setDepartmentCode(searchDoctorModel.getDepartmentCode() == null ? "" : searchDoctorModel.getDepartmentCode());
    	doctorRequest.setStartDate(searchDoctorModel.getStartDate() == null ? "" : searchDoctorModel.getStartDate());
    	doctorRequest.setEndDate(searchDoctorModel.getEndDate() == null ? "" : searchDoctorModel.getEndDate());
    	doctorRequest.setLocale(searchDoctorModel.getLocale() == null ? "" : searchDoctorModel.getLocale());
    	doctorRequest.setReservationDate(searchDoctorModel.getReservationDate() == null ? "" : searchDoctorModel.getReservationDate());
    	doctorRequest.setReservationTime(searchDoctorModel.getReservationTime() == null ? "" : searchDoctorModel.getReservationTime());
    	doctorRequest.setPageSize(searchDoctorModel.getPageSize() == null ? "" : searchDoctorModel.getPageSize());
    	doctorRequest.setPageIndex(searchDoctorModel.getPageIndex() == null ? "" : searchDoctorModel.getPageIndex());
    	
		HospitalServiceProto.SearchDoctorResponse doctorResponse = hospitalRpcService.searchDoctors(doctorRequest.build());

		List<DoctorModel> doctorModels = new ArrayList<>();
		if(doctorResponse != null){
			for(HospitalModelProto.Doctor doctor : doctorResponse.getDoctorsList())
			{
				DoctorModel doctorModel = new DoctorModel();
				BeanUtils.copyProperties(doctor, doctorModel, Language.JAPANESE.toString());
				doctorModels.add(doctorModel);
			}
			searchDoctorModel.setTotalRecords(doctorResponse.getTotalRecords());
			searchDoctorModel.setDoctorModels(doctorModels);
		}	
		return searchDoctorModel;
    }
    
    @Override
    public BookingModel bookingExamination(BookingModel bookingModel) {
    	LOGGER.info("INFO!!! BEGIN BookingServiceImpl!!! bookingExamination" + bookingModel.toString());
    	BookingServiceProto.BookingExaminationRequest.Builder bookingRequest = BookingServiceProto.BookingExaminationRequest.newBuilder();
    	bookingRequest.setHospCode(bookingModel.getHospCode() == null ? "" : bookingModel.getHospCode());
    	bookingRequest.setDepartmentCode(bookingModel.getDepartmentCode() == null ? "" : bookingModel.getDepartmentCode());
    	bookingRequest.setReservationDate(bookingModel.getReservationDate() == null ? "" : bookingModel.getReservationDate());
    	bookingRequest.setReservationTime(bookingModel.getReservationTime() == null ? "" : bookingModel.getReservationTime());
    	bookingRequest.setLocale(bookingModel.getLocale() == null ? "" : bookingModel.getLocale());
    	String doctorCode = "";
    	if(StringUtils.isEmpty(bookingModel.getDoctorCode())){
    		doctorCode = getDoctorCode(bookingModel.getHospCode(), bookingModel.getDepartmentCode(), bookingModel.getReservationDate().replaceAll("/", ""), bookingModel.getReservationDate().replaceAll("/", ""), null, bookingModel.getReservationTime(), bookingModel.getDoctorGrade());
    		if(org.springframework.util.StringUtils.isEmpty(doctorCode)){
        		bookingModel.setError("booking.not.found.doctor.enable.slot");
        		LOGGER.info("INFO!!! bookingExamination: reservationCode=" + bookingModel.getReservationCode() + ", errorCode=" + bookingModel.getError());
    			return bookingModel;
        	}
    	} else {
    		doctorCode = bookingModel.getDoctorCode();
    	}
    	LOGGER.info("INFO!!! bookingExamination: reservationCode=" + bookingModel.getReservationCode() + ", patientCode=" + bookingModel.getPatientCode() + ", doctorCode=" + doctorCode);
    	bookingRequest.setDoctorCode(doctorCode);
    	bookingRequest.setPatientCode(bookingModel.getPatientCode() == null ? "" : bookingModel.getPatientCode());
    	bookingRequest.setPatientNameKanji(bookingModel.getPatientNameKanji() == null ? "" : bookingModel.getPatientNameKanji());
    	bookingRequest.setPatientNameKana(bookingModel.getPatientNameKana() == null ? "" : bookingModel.getPatientNameKana());
    	bookingRequest.setPatientTel(bookingModel.getPatientTel() == null ? "" : bookingModel.getPatientTel());
    	bookingRequest.setPatientEmail(bookingModel.getPatientEmail() == null ? "" : bookingModel.getPatientEmail());
    	bookingRequest.setPatientSex(StringUtils.isEmpty(bookingModel.getPatientSex())? "M" : bookingModel.getPatientSex());
    	bookingRequest.setPatientBirthday(StringUtils.isEmpty(bookingModel.getPatientBirthday()) ? "1900/01/01" : bookingModel.getPatientBirthday());
    	bookingRequest.setPatientType("4"); //  - ＭＳＳから登録
//    	bookingRequest.setType("G1");
    	bookingRequest.setType("Z0");
    	bookingRequest.setUserId(Strings.isEmpty(bookingModel.getSysId()) ? "MSS" :  bookingModel.getSysId());
    	bookingRequest.setParentCode(bookingModel.getParentCode() == null ? "" : bookingModel.getParentCode());
    	bookingRequest.setChildCodeList(bookingModel.getChildCodeList() == null ? "" : bookingModel.getChildCodeList());
    	bookingRequest.setHangmogCode(bookingModel.getHangmogCode() == null ? "" : bookingModel.getHangmogCode());
    	bookingRequest.setHangmogName(bookingModel.getHangmogName() == null ? "" : bookingModel.getHangmogName());
    	bookingRequest.setSurveyYn(bookingModel.getSurveyYn() == null ? "N" : bookingModel.getSurveyYn());
    	
    	BookingServiceProto.BookingExaminationResponse bookingResponse = bookingRpcService.bookExamination(bookingRequest.build());
    	if(bookingResponse != null){
			if(!bookingResponse.getResult()){
				bookingModel.setError(bookingResponse.getErrCode());
				return bookingModel;
			}
			bookingModel.setPatientCode(StringUtils.isEmpty(bookingResponse.getNewPatientCode()) ? bookingModel.getPatientCode() : bookingResponse.getNewPatientCode());
			bookingModel.setDoctorCode(StringUtils.isEmpty(bookingResponse.getDoctorCode()) ? bookingModel.getDoctorCode() : bookingResponse.getDoctorCode().replaceFirst(bookingModel.getDepartmentCode(), ""));
			bookingModel.setDoctorName(bookingResponse.getDoctorName());
			bookingModel.setDepartmentName(bookingResponse.getDepartmentName());
			bookingModel.setReservationCode(bookingResponse.getReservationCode());
			bookingModel.setPatientBirthday(bookingRequest.getPatientBirthday());
			bookingModel.setMisSurveyLink(bookingResponse.getMisSurveyLink());
			bookingModel.setResult(true);
		}
    	LOGGER.info("END BookingServiceImpl!!! bookingExamination !!! SUCCESS");
		return bookingModel;
    }

	@Override
	public CancelBookingModel cancelBookingExamination(CancelBookingModel cancelModel) {
		LOGGER.info("BEGIN BookingServiceImpl!!! cancelBookingExamination !!!");
		BookingServiceProto.CancelBookingExaminationRequest.Builder bookingRequest = BookingServiceProto.CancelBookingExaminationRequest.newBuilder();
		if(!StringUtils.isEmpty(cancelModel.getReservationCode()) && !org.apache.commons.lang3.StringUtils.isNumeric(cancelModel.getReservationCode())){
			cancelModel.setError("reservation.code.invalid");
			cancelModel.setResult(false);
			LOGGER.info("FAILURE!!! cancelBookingExamination: reservationCode=" + cancelModel.getReservationCode() + ", patientCode=" + cancelModel.getPatientCode() + ", error=" + cancelModel.getError());
			return cancelModel;
		}
    	bookingRequest.setHospCode(cancelModel.getHospCode());
    	bookingRequest.setPatientCode(cancelModel.getPatientCode());
    	bookingRequest.setReservationCode(cancelModel.getReservationCode());
    	bookingRequest.setLocale(cancelModel.getLocale() == null ? "" : cancelModel.getLocale());

    	BookingServiceProto.CancelBookingExaminationResponse bookingResponse = bookingRpcService.cancelBookingExamination(bookingRequest.build());
    	if(bookingResponse != null){
			cancelModel.setResult(bookingResponse.getResult());
			LOGGER.info("END BookingServiceImpl!!! cancelBookingExamination !!! bookingResponse!!! result=" + cancelModel.isResult());
			return cancelModel;
		}
    	LOGGER.info("END BookingServiceImpl!!! cancelBookingExamination !!! result=" + cancelModel.isResult());
		return cancelModel;
	}

	@Override
	public ChangeBookingModel changeBookingExamination(ChangeBookingModel changeBooking) {
		LOGGER.info("BEGIN BookingServiceImpl!!! changeBookingExamination !!!");
		BookingServiceProto.ChangeBookingExaminationRequest.Builder bookingRequest = BookingServiceProto.ChangeBookingExaminationRequest.newBuilder();
		if(!StringUtils.isEmpty(changeBooking.getReservationCode()) && !org.apache.commons.lang3.StringUtils.isNumeric(changeBooking.getReservationCode())){
			changeBooking.setError("reservation.code.invalid");
			changeBooking.setResult(false);
			LOGGER.info("FAILURE!!! changeBookingExamination: reservationCode=" + changeBooking.getReservationCode() + ", patientCode=" + changeBooking.getPatientCode());
			return changeBooking;
		}
		bookingRequest.setHospCode(changeBooking.getHospCode());
		bookingRequest.setPatientCode(changeBooking.getPatientCode());
		bookingRequest.setReservationCode(changeBooking.getReservationCode());
		bookingRequest.setReservationDate(changeBooking.getReservationDate());
		bookingRequest.setReservationTime(changeBooking.getReservationTime());
		bookingRequest.setDoctorCode(changeBooking.getDoctorCode());
		bookingRequest.setDepartmentCode(changeBooking.getDepartmentCode());
    	bookingRequest.setLocale(changeBooking.getLocale() == null ? "" : changeBooking.getLocale());

    	BookingServiceProto.ChangeBookingExaminationResponse bookingResponse = bookingRpcService.changeBookingExamination(bookingRequest.build());
    	if(bookingResponse != null){
    		if(!bookingResponse.getResult()){
    			changeBooking.setError(bookingResponse.getErrCode());
    			changeBooking.setResult(false);
    			LOGGER.info("END BookingServiceImpl!!! changeBookingExamination FAILURE!!! result=" + changeBooking.isResult() + ", error=" + changeBooking.getError());
				return changeBooking;
			}
    		changeBooking.setDoctorCode(StringUtils.isEmpty(bookingResponse.getDoctorCode()) ? changeBooking.getDoctorCode() : bookingResponse.getDoctorCode().replaceFirst(changeBooking.getDepartmentCode(), ""));
    		changeBooking.setDoctorName(bookingResponse.getDoctorName());
    		changeBooking.setDepartmentName(bookingResponse.getDepartmentName());
    		changeBooking.setResult(true);
		}
    	LOGGER.info("END BookingServiceImpl!!! changeBookingExamination !!! result=" + changeBooking.isResult());
		return changeBooking;
	}
	
	@Override
	public AccountModel verifyAccount(AccountModel model) {
		AccountModel accountModel = new AccountModel();
		
		HospitalServiceProto.VefiryAccountRequest.Builder verifyAccountRequest = HospitalServiceProto.VefiryAccountRequest.newBuilder();
		verifyAccountRequest.setHospCode(model.getHospCode());
		verifyAccountRequest.setLoginId(model.getUserId());
		verifyAccountRequest.setPassword(model.getPassword());
		verifyAccountRequest.setAccountType(HospitalServiceProto.VefiryAccountRequest.AccountType.MBS);
		HospitalServiceProto.VefiryAccountResponse verifyAccountResponse = hospitalRpcService.vefiryAccount(verifyAccountRequest.build());

		if(verifyAccountResponse != null && verifyAccountResponse.getResult()){
			HospitalModelProto.AccountInfo accountInfo = verifyAccountResponse.getAccountInfo();
			BeanUtils.copyProperties(accountInfo, accountModel, Language.JAPANESE.toString());
			return accountModel;
		}	
		accountModel.setMessage(Message.VERIFY_ACCOUNT_FAIL_MSG.getValue());
		return accountModel;
	}
	public DoctorModel getDoctorFromSession(String sessionId)
	{
		HospitalServiceProto.GetDoctorInfoRequest.Builder doctorInfoRequest = HospitalServiceProto.GetDoctorInfoRequest.newBuilder();
		doctorInfoRequest.setSessionId(sessionId);

		HospitalServiceProto.GetDoctorInfoResponse doctorInfoResponse = hospitalRpcService.getDoctorFromSession(doctorInfoRequest.build());
		DoctorModel doctorModel = new DoctorModel();
		if(doctorInfoResponse != null && doctorInfoResponse.getDoctor() != null)
		{
			BeanUtils.copyProperties(doctorInfoResponse.getDoctor(), doctorModel, Language.JAPANESE.toString());
		}
		return doctorModel;
	}
	private String getDoctorCode(String hospitalCode, String departmentCode, String startDate, String endDate, String avgTime, String reservationTime, String doctorGrade){
		KCCKGetDoctorWorkingTimeInfo doctorWorkingTimeInfo = new KCCKGetDoctorWorkingTimeInfo();
		Map<String, List<BookingSchedule>> departSchedules = getDepartmentSchedule(hospitalCode, departmentCode, startDate, endDate, null, doctorWorkingTimeInfo); 
		//filter by doctor grade
		for(Map.Entry<String, List<BookingSchedule>> entry : departSchedules.entrySet()) {
			if(!StringUtils.isEmpty(doctorGrade)){
				if(entry.getValue().stream().anyMatch(s -> s.getDoctorGrade().equals(doctorGrade))) return entry.getKey();
			} else {
				if(entry.getValue().stream().anyMatch(s -> !s.getDoctorGrade().equals("6"))) return entry.getKey();
			}			
		}
		return "";
	}

	public static class ListenerImpl extends AbstractRpcExtListener<BookingServiceProto.BookingEvent> {

		@Resource
		private BookingRpcService bookingRpcService;
		
		@Resource
		private PatientRepository patientRepository;
		
		@Resource
		private ReservationRepository reservationRepository;
		
		@Resource
		private SessionRepository sessionRepository;
		
		@Resource
		private HospitalRepository hospitalRepository;
		
	    @Resource
	    private MailService mailService;

		protected ListenerImpl() {
			super(BookingServiceProto.BookingEvent.class);
		}

		@Override
		public EventMetaStore meta() {
			return EventMetaStore.BOOKING;
		}

		@Override
		public void handleEvent(BookingServiceProto.BookingEvent event) throws Exception {

			LOGGER.info("Event ID =" + event.getId());
			BookingModelProto.BookingExamInfo bookingExam = event.getBookingExam();
			if(bookingExam != null && bookingExam.getHospCode() != null && bookingExam.getDepartmentCode() != null && "Y".equals(bookingExam.getReserYn()))
			{
				//update data for mss system
				if(!bookingExam.getIsMssRequest()){
					updateDataForMssSystem(bookingExam);
				}

				final String key1 = String.format("%s-%s", bookingExam.getHospCode(), bookingExam.getDepartmentCode());
				ConcurrentMap<String,  Map<String, List<BookingSchedule>>> map = null;
				if(doctorSchedules.get(key1) != null){
					map = doctorSchedules.get(key1).getV3();
				}
				
				List<BookingSchedule> schedules = new ArrayList<>();
				if(map != null)
				{
					for(Map.Entry<String, Map<String, List<BookingSchedule>>> entry : map.entrySet())
					{
						Map<String, List<BookingSchedule>> value = entry.getValue();
						value.forEach((k, v) -> schedules.addAll(v));
					}
//					List<BookingSchedule> bookingSchedules =  schedules.stream().filter(s -> (CommonUtils.parseInteger(s.getResAmStartHhmm())
//							<=  CommonUtils.parseInteger(bookingExam.getReservationTime())  &&(CommonUtils.parseInteger(bookingExam.getReservationTime())
//							<  CommonUtils.parseInteger(s.getResPmEndHhmm()))) &&
//							s.getDoctorCode().equals(bookingExam.getDepartmentCode() + bookingExam.getDoctorCode()) &&
//							s.getBookingDate().equals(bookingExam.getReservationDate())).collect(Collectors.toList());

					Map<String, List<BookingSchedule>> bookedDetails = schedules.stream().collect(Collectors.groupingBy(s -> s.getBookingDate()));
					List<BookingSchedule> bookingScheduleItems = bookedDetails.get(bookingExam.getReservationDate());
					for (BookingSchedule bookingSchedule : bookingScheduleItems) {
						if(bookingSchedule.getDoctorCode().equals(bookingExam.getDoctorCode()))
						{
							List<BookingScheduleDetail> periods = bookingSchedule.getPeriod();
							for (BookingScheduleDetail bookingScheduleDetail : periods) {
								if(CommonUtils.parseInteger(bookingScheduleDetail.getStartTime()) <= CommonUtils.parseInteger(bookingExam.getReservationTime()) &&
										CommonUtils.parseInteger(bookingExam.getReservationTime()) < CommonUtils.parseInteger(bookingScheduleDetail.getEndTime())){
									if (bookingExam.getAction().equals(BookingModelProto.BookingExamInfo.Action.BOOKING)) {
										bookingScheduleDetail.setTotalBookedInOther(String.valueOf(CommonUtils.parseInteger(bookingScheduleDetail.getTotalBookedInOther()) + 1));
									} else if (bookingExam.getAction().equals(BookingModelProto.BookingExamInfo.Action.CHANGE_BOOKING)) {
										ScheduleCache.doctorSchedules.get(key1).getV3().clear();
										break;
									} else if (bookingExam.getAction().equals(BookingModelProto.BookingExamInfo.Action.CANCEL_BOOKING)) {
										bookingScheduleDetail.setTotalBookedInOther(String.valueOf(CommonUtils.parseInteger(bookingScheduleDetail.getTotalBookedInOther()) - 1));
									}
								}

							}
						}
					}
				}

			}

		}

		@Override
		public Collection<BookingServiceProto.BookingEvent> invokeSubscribe(long eventId) throws Exception {
			BookingServiceProto.SubscribeBookingEventRequest request = BookingServiceProto.SubscribeBookingEventRequest
					.newBuilder().setEventId(-1L).build();
			BookingServiceProto.SubscribeBookingEventResponse response = bookingRpcService.subscribeBooking(request);
			if (response != null && PatientServiceProto.SubscribePatientEventResponse.Result.SUCCESS.equals(response.getResult())) {
				if (isVerbose()) LOGGER.info("{} was successfully subscribed", this);
				return response.getEventsList();
			}
			return java.util.Collections.emptyList();
		}
		
		private void updateDataForMssSystem(BookingModelProto.BookingExamInfo bookingExam){
			LOGGER.info("BEGIN sys data from event booking into mss");
			
			String hospitalName = "";
			Integer hospitalId = null;
			String locale = "";
			String hospitalEmail = "";
			List<Hospital> hospitals = hospitalRepository.findByHospitalCode(bookingExam.getHospCode());
			if(!CollectionUtils.isEmpty(hospitals) && hospitals.get(0) != null){
				hospitalId = hospitals.get(0).getHospitalId();
				hospitalName =  hospitals.get(0).getHospitalName();
				locale =  hospitals.get(0).getLocale();
				hospitalEmail = hospitals.get(0).getEmail();
				LOGGER.info("EVENT_BOOKING: hospitalId = " + hospitalId);
				if(hospitals.get(0).getHospitalParentId() != null && hospitals.get(0).getHospitalParentId() == 1){
					String reservationCode = CommonUtils.parseString(CommonUtils.parseDouble(bookingExam.getReservationCode()));
					Reservation reservation = getKcckReservationByReservationCode(reservationCode, hospitalId);
					Patient patient = getKcckPatientByCardNumber(bookingExam.getPatientCode(), hospitalId);
					String emailTemplate = "";
					// save booking into mss
					if(patient == null){
						// insert into patient
						patient = savePatient(bookingExam, hospitalId);
						LOGGER.info("EVENT_BOOKING: Insert patient success: patientid = " + patient.getPatientId());
					}
					if(patient != null && bookingExam.getAction() != null 
							&& bookingExam.getAction().equals(BookingModelProto.BookingExamInfo.Action.BOOKING)){
						// insert into reservation
						reservation = saveReservation(bookingExam, patient.getPatientId(), hospitalId);
						emailTemplate = MailCode.BOOKING_NEW_COMPLETED.toString();
						LOGGER.info("EVENT_BOOKING: Booking success!!!" + ", patientCode=" + patient.getCardNumber());
					}
					if (patient != null && bookingExam.getAction() != null
							&& bookingExam.getAction().equals(BookingModelProto.BookingExamInfo.Action.CHANGE_BOOKING)
							&& reservation != null){
						// update reservation
						reservation.setDoctorId(bookingExam.getDoctorId());
						reservation.setDoctorCode(bookingExam.getDoctorCode());
						reservation.setDoctorName(bookingExam.getDoctorName());
						reservation.setDeptId(bookingExam.getDepartmentId());
						reservation.setDepartCode(bookingExam.getDepartmentCode());
						reservation.setDeptName(bookingExam.getDepartmentName());
						reservation.setReservationDate(bookingExam.getReservationDate());
						reservation.setReservationTime(bookingExam.getReservationTime());
						reservation.setReservationStatus(CommonUtils.parseBigDecimal(ReservationStatus.BOOKING_COMPLETED.getValue()));
						reservation.setActiveFlg(CommonUtils.parseBigDecimal(ActiveFlag.ACTIVE.getValue()));
						reservationRepository.save(reservation);
						emailTemplate = MailCode.BOOKING_CHANGE_COMPLETED.toString();
						LOGGER.info("EVENT_BOOKING: ChangeBooking success!!!" + ", patientCode=" + patient.getCardNumber());
					} 
					if(patient != null && bookingExam.getAction() != null 
							&& bookingExam.getAction().equals(BookingModelProto.BookingExamInfo.Action.CANCEL_BOOKING)
							&& reservation != null){
						// cancel reservation
						reservation.setReservationStatus(CommonUtils.parseBigDecimal(ReservationStatus.CANCELLED.getValue()));
						reservationRepository.save(reservation);
						emailTemplate = MailCode.CANCEL_RESERVATION.toString();
						LOGGER.info("EVENT_BOOKING: CanlcelBooking success!!!" + ", patientCode=" + patient.getCardNumber());
					}

					// send mail
					if(patient != null && !StringUtils.isEmpty(patient.getEmail()) && reservation != null){
						MailInfoModel mailInfo = createMailInfoCompleteBooking(reservation, hospitalName, bookingExam.getPatientCode(), locale);
						List<String> toList = new ArrayList<>();
						toList.add(patient.getEmail());
						if(mailInfo != null){
							mailService.sendMail(emailTemplate, locale, mailInfo,
									toList, reservation.getPatientId(), reservation.getReservationId(),
									hospitalId, hospitalEmail, mailInfo.getServerAddress());
							LOGGER.info("EVENT_BOOKING: SendEmail " + emailTemplate + " success!!!");
						} else {
							LOGGER.warn("EVENT_BOOKING: DO_NOT_SEND_EMAIL!!! toEmail=" + patient.getEmail() + ", emailTemplate=" + emailTemplate + ", patientCode=" + patient.getCardNumber());
						}
					}
				} else {
					LOGGER.warn("BookingEvent!!! Hospital do not used KCCK !!! HOSP_CODE=" + bookingExam.getHospCode());
				}
			} else {
				LOGGER.warn("BookingEvent!!! Hospital not found in mbs db !!! HOSP_CODE=" + bookingExam.getHospCode());
			}
			LOGGER.info("END sys data from event booking into mss");
		}
		
		private Patient getKcckPatientByCardNumber(String patientCode, Integer hospitalId) {
			List<Patient> patientList = this.patientRepository.findKcckPatientByPatientCodeHospCode(hospitalId, patientCode);
			if (patientList == null || patientList.isEmpty()) {
				return null;
			}
			return patientList.get(0);
		}
		
		private Patient savePatient(BookingModelProto.BookingExamInfo bookingExam, Integer hospitalId) {
			try {
				Patient patient = new Patient();
				patient.setCardNumber(bookingExam.getPatientCode());
				patient.setName(bookingExam.getPatientName());
				patient.setNameFurigana(bookingExam.getPatientNameFurigana());
				patient.setActiveFlg(CommonUtils.parseBigDecimal(ActiveFlag.ACTIVE.getValue()));
				if(!StringUtils.isEmpty(bookingExam.getEmail())){
					patient.setEmail(bookingExam.getEmail());
				}
				patient.setPhoneNumber(bookingExam.getPhoneNumber());
				patient.setSex(bookingExam.getSex());
				patient.setBirth(DateUtil.toDate(bookingExam.getBirth(), DateUtil.PATTERN_YYYY_MM_DD));
				patient.setHospitalId(hospitalId);
				patient = patientRepository.save(patient);
				return patient;
			} catch (Exception e) {
				LOGGER.error("ERROR sys data from event booking into mss: savePatient ERROR: ", e);
				return null;
			}
		}
		
		private Reservation saveReservation(BookingModelProto.BookingExamInfo bookingExam, Integer patientId, Integer hospitalId) {
			try {
				Reservation reservation = new Reservation();
				reservation.setPatientId(patientId);
				reservation.setDoctorId(bookingExam.getDoctorId());
				reservation.setDoctorCode(bookingExam.getDoctorCode());
				reservation.setDoctorName(bookingExam.getDoctorName());
				reservation.setDeptId(bookingExam.getDepartmentId());
				reservation.setHospitalId(hospitalId);
				reservation.setDepartCode(bookingExam.getDepartmentCode());
				reservation.setDeptName(bookingExam.getDepartmentName());
				reservation.setPatientName(bookingExam.getPatientName());
				reservation.setReservationCode(bookingExam.getReservationCode());
				reservation.setReservationDate(bookingExam.getReservationDate());
				reservation.setReservationTime(bookingExam.getReservationTime());
				reservation.setReservationStatus(CommonUtils.parseBigDecimal(ReservationStatus.BOOKING_COMPLETED.getValue()));
				reservation.setReminderTime(30);
				reservation.setNameFurigana(bookingExam.getPatientNameFurigana());
				reservation.setPhoneNumber(bookingExam.getPhoneNumber());
				reservation.setEmail(bookingExam.getEmail());
				reservation.setRegUser("patient");
				reservation.setSessionId("");
				reservation.setActiveFlg(CommonUtils.parseBigDecimal(ActiveFlag.ACTIVE.getValue()));
				reservation = reservationRepository.save(reservation);
				return reservation;
			} catch (Exception e) {
				LOGGER.error("ERROR sys data from event booking into mss: savePatient ERROR: ", e);
				return null;
			}
		}
		
		private Reservation getKcckReservationByReservationCode (String reservationCode, Integer hospitalId){
			List<Reservation> listReservation = reservationRepository.findByReservationCodeAndHospitalId(reservationCode, hospitalId);
			if(CollectionUtils.isEmpty(listReservation)){
				return null;
			}
			return listReservation.get(0);
		}
		
		private MailInfoModel createMailInfoCompleteBooking(Reservation reservation, String hospitalName, String patientCode, String locale) {
			try {
				MailInfoModel mailInfo = new MailInfoModel();
				mailInfo.setPatientCode(patientCode);
				mailInfo.setPatientName(reservation.getPatientName());
				mailInfo.setDoctorName(reservation.getDoctorName());
				mailInfo.setHospitalName(hospitalName);
				mailInfo.setReservationCode(reservation.getReservationCode());
				mailInfo.setDepartmentName(reservation.getDeptName());
				mailInfo.setReservationDatetime(DateTimeFormat.DATE_FORMAT_YYYYMMDD.convertStringDateByLocale(reservation.getReservationDate(), org.springframework.util.StringUtils.parseLocaleString(locale))
						+ " " + DateTimeFormat.TIME_FORMAT_HH_MM.convertStringTimeByLocale(reservation.getReservationTime(), org.springframework.util.StringUtils.parseLocaleString(locale)));
				mailInfo.setReminderTime(reservation.getReminderTime() == null ? "" : reservation.getReminderTime().toString());
				mailInfo.setServerAddress(MbsConfiguration.getInstance().getServerAddress());
				mailInfo.setLinkAuthorizedEmail(MbsConfiguration.getInstance().getServerAddress() + MbsConfiguration.getInstance().getLinkAuthorizeEmail() + locale);
				return mailInfo;
			} catch (Exception e) {
				LOGGER.error("ERROR Booing_Event: createMailInfoCompleteBooking: ", e);
				return null;
			}
		}
	}
}
