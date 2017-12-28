package nta.med.data.dao.medi.cht;

import java.util.Date;

import nta.med.core.domain.cht.Cht0117;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Cht0117Repository extends Cht0117RepositoryCustom, CacheRepository<Cht0117> {
	public Integer updateCHT0117Transactional(
			Date endDateResult,
			String buwi,
			Date endDate,
			String hospCode,
			String language);
	
	public Integer updateCHT0117TransactionalModified(
			String updId,
			String buwiName,
			Double sortKey,
			String remark,
			String buwi,
			Date startDate,
			String hospCode,
			String language);
	
	public Integer deleteCHT0117TransactionalDeleted(
			String buwi,
			Date startDate,
			String hospCode,
			String language);
}

