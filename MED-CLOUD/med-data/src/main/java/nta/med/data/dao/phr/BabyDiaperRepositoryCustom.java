package nta.med.data.dao.phr;

import java.util.List;

import nta.med.core.domain.phr.PhrBabyDiaper;

public interface BabyDiaperRepositoryCustom {

	public List<PhrBabyDiaper> getBabyDiaperByLastestDay(Long profileId, Integer limit);
}
