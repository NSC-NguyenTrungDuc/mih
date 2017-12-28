package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardFitnessDistanceInfo;

public interface StandardFitnessDistanceRepositoryCustom {
	
	public List<StandardFitnessDistanceInfo> getStandardFitnessDistanceInfoByprofileIdAndDurationType(Long profileId, Long durationType);
	
}
