package nta.med.data.dao.phr;

import java.util.List;

import nta.med.core.domain.phr.PhrBabyMilk;

public interface BabyMilkRepositoryCustom {
	
	public List<PhrBabyMilk> getBabyMilkByLastestDay(Long profileId, Integer limit);
}
