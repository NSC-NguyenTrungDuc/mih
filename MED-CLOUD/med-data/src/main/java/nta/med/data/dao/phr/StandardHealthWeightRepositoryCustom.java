package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.HealthWeightInfo;

public interface StandardHealthWeightRepositoryCustom {
	List<HealthWeightInfo> getPhrStandardHealthWeightByprofileIdAndType(Long profileId, Long durationType);
}
