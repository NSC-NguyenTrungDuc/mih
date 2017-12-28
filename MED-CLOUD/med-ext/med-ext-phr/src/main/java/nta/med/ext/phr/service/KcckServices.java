package nta.med.ext.phr.service;

import java.util.List;

import nta.med.ext.phr.model.HospitalModel;
import nta.med.ext.phr.model.KcckAccountModel;
import nta.med.ext.phr.model.PatientDiseaseWrapper;
import nta.med.ext.phr.model.PatientMedicineWrapper;
import nta.med.ext.phr.model.PatientModel;

public interface KcckServices {

	public PatientDiseaseWrapper getPatientDisease(String patientCode, String hospCode);

	public List<HospitalModel> getHospitalList(String hospName, String address, String tel, String countryCode);

	public PatientMedicineWrapper getPatientMedicine(String patientCode, String hospCode);

	public PatientModel verifyKcckAccount(KcckAccountModel account);
}
