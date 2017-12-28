package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.core.domain.bas.Bas0251;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */

public interface Bas0251Repository extends Bas0251RepositoryCustom, CacheRepository<Bas0251>{

	public List<Bas0251> findByHospCode(String hospCode);
}
