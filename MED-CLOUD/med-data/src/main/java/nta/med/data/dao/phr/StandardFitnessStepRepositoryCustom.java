package nta.med.data.dao.phr;

import java.util.List;

import nta.med.data.model.phr.StandardFitnessStepInfo;

public interface StandardFitnessStepRepositoryCustom {

	public List<StandardFitnessStepInfo> getStandardFitnessStepInfoByprofileIdAndDurationType(Long profileId, Long durationType);
	
}
