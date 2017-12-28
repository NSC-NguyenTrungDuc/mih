package nta.mss.service;

import java.util.List;

import nta.mss.model.VaccineHospitalModel;


/**
 * @author linhnt
 * 
 * The Interface IVaccineHospitalService.
 */
public interface IVaccineHospitalService {
	
	/**
	 * Find all.
	 *
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<VaccineHospitalModel> getVaccineHospital(Integer hospitalId) throws Exception;
	
	/**
	 * Find by id.
	 *
	 * @param VaccineHospitalId the vaccine hospital id
	 * @return the vaccine hospital model
	 * @throws Exception the exception
	 */
	public VaccineHospitalModel findById(Integer VaccineHospitalId) throws Exception;

	/**
	 * Save vaccine hospital.
	 *
	 * @throws Exception the exception
	 */
	public void saveVaccineHospital(VaccineHospitalModel vaccineHospitalModel) throws Exception;
	
	/**
	 * Delete vaccine hospital.
	 *
	 * @param vaccineHospitalModel the vaccine hospital model
	 * @throws Exception the exception
	 */
	public void deleteVaccineHospital(VaccineHospitalModel vaccineHospitalModel) throws Exception;
	
	public VaccineHospitalModel findByHospitalIdVaccineId(Integer hospitalId, Integer vaccineId) throws Exception;
}
