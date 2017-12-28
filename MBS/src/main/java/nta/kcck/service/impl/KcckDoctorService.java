package nta.kcck.service.impl;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import nta.kcck.model.DoctorModelInfo;
import nta.kcck.model.MessageResponse;
import nta.kcck.service.IKcckDoctorService;
import nta.mss.model.DoctorModel;
import nta.mss.model.PatientWaitingModel;

public class KcckDoctorService implements IKcckDoctorService {
KcckApiService kcckApiService = new KcckApiService();
	
	@Override
	public DoctorModel findKcckDoctorById(String hospCode,Integer doctorId,String departmentCode) {
		
		Map<Integer,DoctorModel> doctorLists = new HashMap<Integer,DoctorModel>();
		List<DoctorModel> doctorList = getListKcckDoctor(hospCode,departmentCode);
		for(DoctorModel model:doctorList){
			doctorLists.put(model.getDoctorId(), model );
		}
		DoctorModel model = doctorLists.get( doctorId );
		return model;
	
	}
	// doctor API: KCCK-MSS
	@Override
	public List<DoctorModel> getListKcckDoctor(String hospCode,String departmentCode) {
		DoctorModel doctorModel;
		List<DoctorModel> doctorList = new ArrayList<DoctorModel>();
		MessageResponse<List<DoctorModelInfo>> response = (MessageResponse<List<DoctorModelInfo>>) kcckApiService.listKcckDoctor(
				hospCode, departmentCode);	
		if(response == null || response.getData() == null){
			return doctorList;
		}
		for (DoctorModelInfo doctor : response.getData()) {			
			doctorModel = new DoctorModel();
			doctorModel.setDoctorId(Integer.parseInt(doctor.getDoctor_id()));
			doctorModel.setDoctorCode(doctor.getDoctor_code());
			doctorModel.setName(doctor.getDoctor_name());
			doctorModel.setDeptId(Integer.parseInt(doctor.getDepartment_id()));
			doctorModel.setKpiAvg(Integer.parseInt(doctor.getDoctor_grade()));	

			doctorList.add(doctorModel);
		}

		return doctorList;

	}

	@Override
	public DoctorModel findKcckDoctorByCode(String hospCode, String doctorCode, String departmentCode) {
		Map<String,DoctorModel> doctorLists = new HashMap<String,DoctorModel>();
		List<DoctorModel> doctorList = getListKcckDoctor(hospCode,departmentCode);
		for(DoctorModel model:doctorList){
			doctorLists.put(model.getDoctorCode(), model );
		}
		DoctorModel model = doctorLists.get(doctorCode);
		return model;
	}
	@Override
	public List<PatientWaitingModel> findKcckPaitentWaitingByCode(String doctorCode, String examinationDate,
			String examinationSituation, String departmentCode, String hospCode, String locale) {
		
		PatientWaitingModel patientWaitingModel;
		List<PatientWaitingModel> doctorList = new ArrayList<PatientWaitingModel>();
		MessageResponse<List<PatientWaitingModel>> response = (MessageResponse<List<PatientWaitingModel>>) kcckApiService.listKcckPatientWaiting(doctorCode, examinationDate, 
				examinationSituation, departmentCode, hospCode, locale);
		
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

			doctorList.add(patientWaitingModel);
		}

		return doctorList;
	}
}
