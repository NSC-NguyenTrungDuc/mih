package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardTempBpInfo;

public interface StandardTempBpRepositoryCustom {

	public List<StandardTempBpInfo> getStandardTempBpInfoByprofileIdAndDurationType(Long profileId, Long durationType);
	
}
