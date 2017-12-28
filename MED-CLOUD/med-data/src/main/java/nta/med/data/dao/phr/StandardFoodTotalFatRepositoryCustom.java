package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardFoodTotalFatInfo;

public interface StandardFoodTotalFatRepositoryCustom {

	List<StandardFoodTotalFatInfo> getPhrStandardFoodTotalFatByprofileIdAndType(Long profileId, Long durationType);
}
