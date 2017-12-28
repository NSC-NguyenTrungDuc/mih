package nta.med.data.dao.phr;

import java.util.List;

import nta.med.core.domain.phr.PhrBabyGrowth;

public interface BabyGrowthRepositoryCustom {
	public List<PhrBabyGrowth> getBabyGrowthByLastestDay(Long profileId, Integer limit);
}
