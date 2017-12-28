package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardTempHeartrateInfo;

public interface StandardTempHeartrateRepositoryCustom {

	public List<StandardTempHeartrateInfo> getStandardTempHeartrateInfoByprofileIdAndDurationType(Long profileId, Long durationType);
	
}
