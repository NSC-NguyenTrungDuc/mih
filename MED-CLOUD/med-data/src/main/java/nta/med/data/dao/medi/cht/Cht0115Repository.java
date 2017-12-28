package nta.med.data.dao.medi.cht;

import java.util.Date;

import nta.med.core.domain.cht.Cht0115;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Cht0115Repository extends Cht0115RepositoryCustom, CacheRepository<Cht0115> {
	public Integer updateCht0115Q01TransactionModified(
			String updId,
			String susikName,
			String susikNameGana,
			Date susikCrDate,
			Date susikUpdDate,
			Date susikDisableDate,
			String susikGwanriNo,
			String susikGubun,
			String susikChangeCode,
			String susikDetailGubun,
			Date endDate,
			Double sort,
			String hospCode,
			String susikCode,
			Date startDate);
	
	public Integer deleteCht0115Q01TransactionDeleted(
			String hospCode,
			String susikCode,
			Date startDate);
}

