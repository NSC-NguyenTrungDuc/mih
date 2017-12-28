package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardTempTemperatureInfo;

public interface StandardTempTemperatureRepositoryCustom {

	public List<StandardTempTemperatureInfo> getStandardTempTemperatureInfoByprofileIdAndDurationType(Long profileId, Long durationType);
	
}
