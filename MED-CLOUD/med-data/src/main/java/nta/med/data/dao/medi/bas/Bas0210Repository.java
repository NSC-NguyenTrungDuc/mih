package nta.med.data.dao.medi.bas;

import java.util.Date;

import nta.med.core.domain.bas.Bas0210;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Bas0210Repository extends Bas0210RepositoryCustom , CacheRepository<Bas0210>{
	public String getBAS0210U00DupCheck(String gubun, Date startDate, String language);
	
	public Integer deleteBAS0210U00Execute(String gubun, Date startDate, String language);
	
	public Integer updateBAS0210U00ExecuteCaseInsert(String userId, Date startDate, String gubun, String language);
	
	public Integer updateBAS0210Execute(String userId,
			 Date endDate, String gubunName, String johapGubun,
			 String gongbiYn, String gubun, Date startDate, String language);
}

