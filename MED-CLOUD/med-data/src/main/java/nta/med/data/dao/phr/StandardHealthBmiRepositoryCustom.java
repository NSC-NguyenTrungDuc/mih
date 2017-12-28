package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.HealthBmiInfo;

public interface StandardHealthBmiRepositoryCustom {
	List<HealthBmiInfo> getPhrStandardHealthBmiByprofileIdAndType(Long profileId, Long durationType);
}
