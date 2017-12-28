package nta.med.data.dao.phr;

import java.util.List;

import nta.med.core.domain.phr.PhrBabyGrowthWeight;
import nta.med.data.model.phr.BabyGrowthWeightInfo;

public interface BabyGrowthWeightRepositoryCustom {

	public List<BabyGrowthWeightInfo> getBabyGrowthWeightInfoByprofileIdAndDurationType(Long profileId, Long durationType);
	
	public List<PhrBabyGrowthWeight> getBabyGrowthWeightByLastestDay(Long profileId, Integer limit);
	
}
