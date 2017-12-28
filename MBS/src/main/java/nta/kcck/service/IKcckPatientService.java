package nta.kcck.service;

import java.util.List;

import nta.mss.model.PatientModel;
import nta.mss.model.PatientWaitingModel;

public interface IKcckPatientService {
	public PatientModel getPatientInfo(String hospCode, String patientCode);
	
	List<PatientWaitingModel> findKcckPaitentWaitingByPatientCode(String examinationDate, String examinationSituation
			, String hospCode, String patientCode, String locale);
	
	public PatientWaitingModel updateKcckMtCallingIdByReservationCode(String reservationCode, String mtCallingId);
}
