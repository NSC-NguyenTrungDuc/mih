package nta.med.data.dao.medi.cht;

import java.util.Date;

import nta.med.core.domain.cht.Cht0118;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Cht0118Repository extends Cht0118RepositoryCustom, CacheRepository<Cht0118> {
	public Integer updateCHT0117TransactionalCht0118(
			Date endDateResult,
			String buwi,
			String subBuwi,
			Date endDate,
			String hospCode,
			String language);
	
	public Integer updateCHT0117TransactionalCht0118Modified(
			String updId,
			String subBuwiName,
			Double sortKey,
			String remark,
			Double nosaiJyRate,
			String buwi,
			String subBuwi,
			Date startDate,
			String hospCode,
			String language);
	
	public Integer deleteCHT0117TransactionalCht0118Deleted(
			String buwi,
			String subBuwi,
			Date startDate,
			String hospCode,
			String language);
}

