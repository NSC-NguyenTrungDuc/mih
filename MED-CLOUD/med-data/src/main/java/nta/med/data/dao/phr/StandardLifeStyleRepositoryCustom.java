package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardLifeStyleInfo;

public interface StandardLifeStyleRepositoryCustom {

	List<StandardLifeStyleInfo> getStandardLifeStyleByDurationType(Long profileId, Long durationType);

}
