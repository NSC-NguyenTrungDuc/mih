package nta.mss.repository;

import java.util.List;

import nta.mss.info.VaccineChildHistoryInfo;


/**
 * The Interface VaccineChildHistoryCustom.
 */
public interface VaccineChildHistoryRepositoryCustom {
	
	/**
	 * Gets the list vaccine child history.
	 *
	 * @param childId the child id
	 * @return the list vaccine child history
	 */
	public List<VaccineChildHistoryInfo> getListVaccineChildHistory(Integer childId) throws Exception;
	
	public VaccineChildHistoryInfo getListVaccineChildHistoryById(Integer vaccineChildId) throws Exception;
	
	public Integer getMaxInjectedNo(Integer vaccineId, Integer childId) throws Exception;
}
