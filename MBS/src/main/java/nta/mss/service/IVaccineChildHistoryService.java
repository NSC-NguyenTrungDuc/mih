package nta.mss.service;

import java.util.List;

import nta.mss.info.ReservationInfo;
import nta.mss.info.VaccineChildHistoryInfo;
import nta.mss.model.ReservationModel;
import nta.mss.model.VaccineChildHistoryModel;

// TODO: Auto-generated Javadoc
/**
 * The Interface IVaccineChildHistoryService.
 */
public interface IVaccineChildHistoryService {

	/**
	 * Find child history by child id.
	 *
	 * @param childId the child id
	 * @param vaccineGroupId the vaccine group id
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<VaccineChildHistoryModel> findChildHistoryByChildId(Integer childId, Integer vaccineGroupId) throws Exception;
	
	/**
	 * Save.
	 *
	 * @param childHistoryModel the child history model
	 * @throws Exception the exception
	 */
	public void save(VaccineChildHistoryModel childHistoryModel) throws Exception;
	
	/**
	 * Find by reservation id.
	 *
	 * @param reservationId the reservation id
	 * @return the vaccine child history model
	 * @throws Exception the exception
	 */
	public VaccineChildHistoryModel findByReservationId(Integer reservationId) throws Exception;
	
	/**
	 * Find by vaccine id child id reservation id.
	 *
	 * @param reservationId the reservation id
	 * @param vaccineId the vaccine id
	 * @param childId the child id
	 * @return the vaccine child history model
	 * @throws Exception the exception
	 */
	public VaccineChildHistoryModel findByVaccineIdChildIdReservationId (Integer reservationId, Integer vaccineId, Integer childId) throws Exception;
	
	/**
	 * Findaccine child history info by child id.
	 *
	 * @param childId the child id
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<VaccineChildHistoryInfo> findVaccineChildHistoryInfoByChildId(Integer childId) throws Exception;
	
	/**
	 * Gets the list vaccine child history by id.
	 *
	 * @param vaccineChildId the vaccine child id
	 * @return the list vaccine child history by id
	 * @throws Exception the exception
	 */
	public VaccineChildHistoryInfo getListVaccineChildHistoryById(Integer vaccineChildId) throws Exception;
	
	/**
	 * Find by id.
	 *
	 * @param vaccinceChildId the vaccince child id
	 * @return the vaccine child history model
	 * @throws Exception the exception
	 */
	public VaccineChildHistoryModel findById(Integer vaccinceChildId) throws Exception;
	
	/**
	 * Find by vaccine id.
	 *
	 * @param vaccineId the vaccine id
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<VaccineChildHistoryModel> findByChildId(Integer userChild) throws Exception;
	
	/**
	 * Find reservation by id.
	 *
	 * @param reservationId the reservation id
	 * @return the reservation model
	 */
	public ReservationModel findReservationById(Integer reservationId);
	
	/**
	 * Find by vaccine id injected time.
	 *
	 * @param vaccineId the vaccine id
	 * @param childId the child id
	 * @param injectedNo the injected no
	 * @return the reservation model
	 * @throws Exception the exception
	 */
	public VaccineChildHistoryModel findByVaccineIdInjectedNo(Integer vaccineId, Integer childId, Integer injectedNo) throws Exception;

	/**
	 * Find by user id child id.
	 *
	 * @param userId the user id
	 * @param childId the child id
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<VaccineChildHistoryModel> findByUserIdChildId(Integer userId, Integer childId)  throws Exception;
	
	/**
	 * Gets the max injected no.
	 *
	 * @param vaccineId the vaccine id
	 * @param childId the child id
	 * @return the max injected no
	 * @throws Exception the exception
	 */
	public Integer getMaxInjectedNo(Integer vaccineId, Integer childId) throws Exception;
	
	/**
	 * Find by vaccine id.
	 *
	 * @param vaccineId the vaccine id
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<VaccineChildHistoryModel> findByVaccineId(Integer vaccineId) throws Exception;
	
	/**
	 * Find reservation info by child id.
	 *
	 * @param childId the child id
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<ReservationInfo> findReservationInfoByChildId(Integer childId) throws Exception;
}
