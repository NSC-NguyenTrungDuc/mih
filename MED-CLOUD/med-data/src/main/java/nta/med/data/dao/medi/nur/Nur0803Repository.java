package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.nur.Nur0803;
import nta.med.data.dao.medi.CacheRepository;

public interface Nur0803Repository extends Nur0803RepositoryCustom, CacheRepository<Nur0803> {

	public List<Nur0803> findByNeedGubun(String hospCode, String needGubun);
	
	public List<Nur0803> findByHospCodeNeedGubunNeedAsmtCodeFDate(String hospCode, String needGubun, String asmtCode, Date fDate);

}
