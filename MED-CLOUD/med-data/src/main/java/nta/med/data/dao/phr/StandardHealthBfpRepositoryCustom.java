package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.HealthBfpInfo;

public interface StandardHealthBfpRepositoryCustom {
	List<HealthBfpInfo> getPhrStandardHealthBfpByprofileIdAndType(Long profileId, Long durationType);
}
