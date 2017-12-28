package nta.med.data.dao.medi.bas;

import java.util.Date;

import nta.med.core.domain.bas.Bas0110;
import nta.med.data.dao.medi.CacheRepository;

import org.springframework.data.repository.query.Param;

/**
 * @author dainguyen.
 */
public interface Bas0110Repository extends Bas0110RepositoryCustom , CacheRepository<Bas0110>{
	
	public Integer updateBas0110U00TransactionModified(
			String updId,
			String johapName,
			String zipCode1,
			String zipCode2,
			String address,
			String tel,
			String giho,
			String remark,
			String checkDigitYn,
			String johap,
			Date startDate,
			String johapGubun,
			String language);
	
	public Integer deleteBas0110U00TransactionDeleted(
			String johap,
			Date startDate,
			String johapGubun,
			String language);
}

