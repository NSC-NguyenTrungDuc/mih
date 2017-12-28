package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import nta.kcck.info.KcckReservationInfo;
import nta.kcck.model.KcckReservationModel;
import nta.kcck.service.impl.KcckApiService;
import nta.med.common.util.Collections;
import nta.mss.entity.Reservation;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.DateTimeFormat;
import org.apache.logging.log4j.util.Strings;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.mss.entity.InsuranceHistory;
import nta.mss.info.ReminderReservationCheduleInfo;
import nta.mss.info.ReservationOnlineInfo;
import nta.mss.repository.ReservationRepository;
import nta.mss.service.IReservationService;

/**
 * The Class ReservationService.
 * 
 * @author DEV-HuanLT
 */
@Service
@Transactional
public class ReservationService implements IReservationService {
	
	private ReservationRepository reservationRepository;
	@Autowired
	private KcckApiService kcckApiService;
	
    public ReservationService() {
    }

    @Autowired
	public ReservationService(Mapper mapper,
			ReservationRepository reservationRepository) {
		this.reservationRepository = reservationRepository;
	}
    
    @Override
	public List<ReminderReservationCheduleInfo> getListReminderReservationCchedule(String schedulerTiming, String serverTimeZone) {
		List<ReminderReservationCheduleInfo> result = new ArrayList<>();
		result = this.reservationRepository.getReminderReservationCcheduleInfo(schedulerTiming,serverTimeZone);
		return result;
	}

	@Override
	public List<InsuranceHistory> getListReservationByHospIdAndCardNumber(Integer hospId, String cardNumber,Integer startIndex, Integer pageSize,String columnSort, String typeOrder) {
		// TODO Auto-generated method stub
		List<InsuranceHistory> result = new ArrayList<>();
		result = this.reservationRepository.findReservationByHospIdAndPatientId(hospId, cardNumber,startIndex,pageSize,columnSort, typeOrder);
		return result;
	}

	@Override
	public Integer getTotalRecordReservationByHospIdAndPatientId(Integer hospId, String cardNumber) {
		// TODO Auto-generated method stub
		Integer result = reservationRepository.getTotalRecordReservationByHospIdAndPatientId(hospId, cardNumber);
		return result;
	}

	@Override
	public List<ReservationOnlineInfo> findReservationInfoByReCodeHosId(Integer hospId, List<String> reservationCodes) {
		List<ReservationOnlineInfo> result = new ArrayList<>();
		result = this.reservationRepository.findReservationInfoByReCodeHosId(hospId, reservationCodes);
		return result;
	}
	@Override
	public String getMtCallingIdByReservationId(Integer reservationId) {
		String result =this.reservationRepository.getMtCallingIdByReservationId(reservationId);
		return result;
	}

	@Override
	public KcckReservationModel getReservation(Integer reservationId, boolean surveyYN) {

		KcckReservationInfo kcckReservationInfo = this.reservationRepository.findKcckReservationById(reservationId);
		Reservation reservation = this.reservationRepository.
				findOne(kcckReservationInfo.getReservationId());
		String hospCode = reservation.getHospital().getHospitalCode();
		Integer status = reservation.getReservationStatus();
		String linkSurveyYN = "";
		if(surveyYN)
		{
			if(!Strings.isEmpty(kcckApiService.getLinkSurvey(hospCode, kcckReservationInfo.getDeptCode(),
				kcckReservationInfo.getPatientCode(), kcckReservationInfo.getReservationCode())))
			{

				linkSurveyYN = kcckApiService.getLinkSurvey(hospCode, kcckReservationInfo.getDeptCode(),
						kcckReservationInfo.getPatientCode(), kcckReservationInfo.getReservationCode());
			}


		}


		if(kcckReservationInfo != null && status != null & status == 1)
		{
			KcckReservationModel kcckReservationModel = new KcckReservationModel();
			kcckReservationModel.setHosp_code(hospCode);
			kcckReservationModel.setDepartment_code(kcckReservationInfo.getDeptCode());
			kcckReservationModel.setDoctor_code(kcckReservationInfo.getDoctorCode());
			kcckReservationModel.setPatient_code(kcckReservationInfo.getPatientCode());
			kcckReservationModel.setReservation_date(kcckReservationInfo.getReservationDate());
			kcckReservationModel.setReservation_time(kcckReservationInfo.getReservationTime());
			kcckReservationModel.setPatient_name_kana(kcckReservationInfo.getNameFurigana());
			kcckReservationModel.setPatient_name_kanji(kcckReservationInfo.getNameFurigana());
			kcckReservationModel.setReservation_code(kcckReservationInfo.getReservationCode());
			kcckReservationModel.setPatient_code(kcckReservationInfo.getPatientCode());
			kcckReservationModel.setReservation_id(String.valueOf(kcckReservationInfo.getReservationId()));
			kcckReservationModel.setPatient_email(kcckReservationInfo.getEmail());
			kcckReservationModel.setDepartment_name(kcckReservationInfo.getDeptName());

			if (kcckReservationInfo.getPatientBirthDay() != null) {
				kcckReservationModel.setPatient_birthday(
						MssDateTimeUtil.convertDateToStringByLocale(kcckReservationInfo.getPatientBirthDay(),
								DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND, MssContextHolder.getLocale()));
			}
			if(surveyYN)
			{
				kcckReservationModel.setMis_survey_link(linkSurveyYN);
			}
			return kcckReservationModel;
		}
		return null;

	}
}
