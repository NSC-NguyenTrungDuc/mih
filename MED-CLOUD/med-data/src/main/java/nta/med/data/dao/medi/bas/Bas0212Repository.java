package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.bas.Bas0212;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Bas0212Repository extends Bas0212RepositoryCustom, CacheRepository<Bas0212> {
	public Integer updateBas0212ByGongbiCodeAndEndDate(String userId, String startDate, String gongbiCode, String language);
	public Integer updateBas0212ByGongbiCodeAndStartDate(String userId, String endDate, String lawNo, String gongbiName, String totalYn,
			String gongbiJiyeok, String gongbiCode, String startDate, String language);
	public Integer updateBas0212ByGongbiCodeAndEndDateCaseDelete(String gongbiCode, String startDate, String language);
	public Integer deleteBas0210(String gongbiCode, Date startDate, String language);
	public List<String> getGongbiCodeByGongbiName(String gongbiName, String language);
}

