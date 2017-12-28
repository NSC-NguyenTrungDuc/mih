package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.HealthHeightInfo;

public interface StandardHealthHeightRepositoryCustom {
	
	List<HealthHeightInfo> getPhrStandardHealthHeightByprofileIdAndType(Long profileId, Long durationType);

}
