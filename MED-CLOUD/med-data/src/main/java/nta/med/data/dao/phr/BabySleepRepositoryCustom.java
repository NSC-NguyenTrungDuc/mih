package nta.med.data.dao.phr;

import java.util.List;

import nta.med.core.domain.phr.PhrBabySleep;
import nta.med.data.model.phr.BabySleepInfo;

public interface BabySleepRepositoryCustom {

	public List<PhrBabySleep> getBabySleepByLastestDay(Long profileId, Integer limit);
	
	public List<BabySleepInfo> getBabySleepInfoByprofileIdAndType(Long profileId, Long durationType);
}
