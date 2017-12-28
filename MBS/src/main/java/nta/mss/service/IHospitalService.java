package nta.mss.service;

import java.util.List;

import nta.mss.info.HospitalDto;
import nta.mss.model.HospitalModel;

/**
 * The Interface IHospitalService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public interface IHospitalService {
	
	/**
	 * Find hospital by id.
	 * 
	 * @param hospitalId
	 *            the hospital id
	 * @return the hospital model
	 */
	HospitalModel findHospitalById(Integer hospitalId);
	
	/**
	 * Find all hospital.
	 * 
	 * @return the list
	 */
	List<HospitalModel> findAllHospital();
	
	/**
	 * Find all hospital
	 * 
	 * @return
	 */
	HospitalModel findHospitalModelByHospitalId(Integer hospitalId);
	
	/**
	 * Delete hospital
	 * 
	 * @param hospitalModel
	 * @throws Exception
	 */
	void deleteHospital(HospitalModel hospitalModel) throws Exception;

	/**
	 * findHospitalByHospitalCode
	 * @param hospitalCode
	 * @return HospitalModel
	 */
	public HospitalModel findHospitalByHospitalCode(String hospitalCode);

	/**
	 * findHospital
	 * @param id
	 * @return
	 */
	public HospitalModel findHospital(Integer hospitalId);
	
	/**
	 * findHospital by HospCode And Locate
	 * @param id
	 * @return
	 */
	public HospitalModel findHospitalByHospCodeAndLocate(String hospCode, String locale);

	/**
	 * updateHospital
	 * @param hospitalModel
	 * @return
	 */
	public Integer updateHospital(HospitalModel hospitalModel);
	
	/**
	 * getHospitalModelByHospitalCode
	 * @param hospitalCode
	 * @return
	 */
	public HospitalDto getHospitalModelByHospitalCode(String hospitalCode);
}
