package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.core.domain.nur.Nur0802;
import nta.med.data.dao.medi.CacheRepository;

public interface Nur0802Repository extends Nur0802RepositoryCustom, CacheRepository<Nur0802> {

	public List<Nur0802> findByHospCodeNeedTypeNeedGubunNeedAsmtCode(String hospCode, String needType, String needGubun,
			String needAsmtCode);
}
