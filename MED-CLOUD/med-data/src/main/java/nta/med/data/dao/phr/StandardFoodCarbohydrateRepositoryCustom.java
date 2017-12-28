package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardFoodCarbohydrateInfo;

public interface StandardFoodCarbohydrateRepositoryCustom {

	List<StandardFoodCarbohydrateInfo> getPhrStandardFoodCarbohydrateByprofileIdAndType(Long profileId, Long durationType);
}
