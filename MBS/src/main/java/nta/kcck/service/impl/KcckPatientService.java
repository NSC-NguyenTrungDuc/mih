package nta.kcck.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.kcck.model.KcckPatientModel;
import nta.kcck.model.MessageResponse;
import nta.kcck.service.IKcckApiService;
import nta.kcck.service.IKcckPatientService;
import nta.mss.model.PatientModel;
import nta.mss.model.PatientWaitingModel;

public class KcckPatientService implements IKcckPatientService {
	KcckApiService kcckApiService = new KcckApiService();
	
	@Resource
	private IKcckApiService kcckPatientService;
	
	@Override
	public PatientModel getPatientInfo(String hospCode, String patientCode) {
		PatientModel patient = new PatientModel();
		KcckPatientModel kcckPatientModel = kcckApiService.getKcckPatientInfo(hospCode, patientCode);
		if (kcckPatientModel != null && kcckPatientModel.getPatient_code() != null) {
			patient.setName(kcckPatientModel.getPatient_name_kanji());
			patient.setNameFurigana(kcckPatientModel.getPatient_name_kana());
			patient.setCardNumber(kcckPatientModel.getPatient_code());
			patient.setEmail(kcckPatientModel.getPatient_email());
			patient.setPhoneNumber(kcckPatientModel.getPatient_tel());
			patient.setDob(kcckPatientModel.getPatient_birthday());
			patient.setGender(kcckPatientModel.getPatient_sex());
			return patient;
		}
		return patient;
	}

	@Override
	public List<PatientWaitingModel> findKcckPaitentWaitingByPatientCode(String examinationDate,
			String examinationSituation, String hospCode, String patientCode, String locale) {
		// ----
		PatientWaitingModel patientWaitingModel;
		List<PatientWaitingModel> doctorList = new ArrayList<PatientWaitingModel>();
		MessageResponse<List<PatientWaitingModel>> response = (MessageResponse<List<PatientWaitingModel>>) kcckApiService.listKcckPatientWaitingByPaientCode(examinationDate, 
				hospCode, patientCode, locale);
		
		if(response == null || response.getData() == null) {
			return doctorList;
		}
		
		for (PatientWaitingModel model : response.getData()) {	
			patientWaitingModel = new PatientWaitingModel();
			patientWaitingModel.setReservation_code(model.getReservation_code());
			patientWaitingModel.setExamination_date(model.getExamination_date());
			patientWaitingModel.setExamination_time(model.getExamination_time());
			patientWaitingModel.setDepartment_code(model.getDepartment_code());
			patientWaitingModel.setDepartment_name(model.getDepartment_name());
			
			patientWaitingModel.setPatient_name(model.getPatient_name());
			patientWaitingModel.setPatient_code(model.getPatient_code());
			patientWaitingModel.setPatient_name_kana(model.getPatient_name_kana());
			patientWaitingModel.setDoctor_code(model.getDoctor_code());
			patientWaitingModel.setDoctor_name(model.getDoctor_name());
			patientWaitingModel.setSys_id(model.getSys_id());
			patientWaitingModel.setRecept_time(model.getRecept_time());
			patientWaitingModel.setNawon_yn(model.getNawon_yn());

			doctorList.add(patientWaitingModel);
		}

		return doctorList;
	}

	@Override
	public PatientWaitingModel updateKcckMtCallingIdByReservationCode(String reservationCode, String mtCallingId) {
		PatientWaitingModel patientWaitingModel = kcckApiService.updateKcckMtCallingIdByReservationCode(reservationCode, mtCallingId);
		return patientWaitingModel;
	}

}
