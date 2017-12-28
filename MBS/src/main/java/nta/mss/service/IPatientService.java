package nta.mss.service;

import java.util.List;

import nta.mss.entity.Patient;
import nta.mss.model.PatientModel;

/**
 * The Interface IBookingService.
 * 
 * @author HoanPC
 * @CrtDate Sep 13, 2016
 */
public interface IPatientService {
	
	public List<PatientModel> getListByPatientId(Integer patientId);

	public Patient savePatient(PatientModel patientModel, Integer hospitalId);

	public String getStrPatientCodeFromAccountClinic(String token, Integer userId);

}
