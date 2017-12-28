package nta.kcck.service;

import java.util.List;

import nta.mss.model.DoctorModel;
import nta.mss.model.PatientWaitingModel;

public interface IKcckDoctorService {
	List<DoctorModel> getListKcckDoctor(String hospCode,String departmentCode);

	DoctorModel findKcckDoctorById(String hospCode, Integer doctorId,String departmentCode);
	
	DoctorModel findKcckDoctorByCode(String hospCode, String doctorCode,String departmentCode);
	
	List<PatientWaitingModel> findKcckPaitentWaitingByCode(String doctorCode, String examinationDate, String examinationSituation
			, String departmentCode, String hospCode, String locale);
}
