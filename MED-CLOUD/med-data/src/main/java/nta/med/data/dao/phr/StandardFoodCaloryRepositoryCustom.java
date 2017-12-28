package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardFoodCaloriesInfo;

public interface StandardFoodCaloryRepositoryCustom {

	List<StandardFoodCaloriesInfo> getPhrStandardFoodCaloryByprofileIdAndType(Long profileId, Long durationType);
}
