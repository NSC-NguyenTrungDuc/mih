package nta.med.data.dao.phr;

import java.util.List;

import nta.med.core.domain.phr.PhrBabyGrowthHeight;
import nta.med.data.model.phr.BabyGrowthHeightInfo;

public interface BabyGrowthHeightRepositoryCustom {

	public List<BabyGrowthHeightInfo> getBabyGrowthHeightInfoByprofileIdAndDurationType(Long profileId, Long durationType);
	
	public List<PhrBabyGrowthHeight> getBabyGrowthHeightByLastestDay(Long profileId, Integer limit);
	
}
