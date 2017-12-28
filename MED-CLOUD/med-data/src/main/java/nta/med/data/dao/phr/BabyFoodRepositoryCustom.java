package nta.med.data.dao.phr;

import java.util.List;

import nta.med.core.domain.phr.PhrBabyFood;
import nta.med.data.model.phr.BabyFoodInfo;

public interface BabyFoodRepositoryCustom {

	public List<PhrBabyFood> getBabyFoodByLastestDay(Long profileId, Integer limit);
	
	public List<BabyFoodInfo> getBabyFoodByDurationType(Long profileId, Long durationType);
}
