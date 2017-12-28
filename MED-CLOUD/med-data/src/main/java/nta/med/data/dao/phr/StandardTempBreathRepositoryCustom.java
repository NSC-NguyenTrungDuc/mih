package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardTempBreathInfo;

public interface StandardTempBreathRepositoryCustom {

	public List<StandardTempBreathInfo> getStandardTempBreathInfoByprofileIdAndDurationType(Long profileId, Long durationType);
	
}
