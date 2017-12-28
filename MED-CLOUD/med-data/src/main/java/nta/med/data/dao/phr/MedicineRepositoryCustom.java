package nta.med.data.dao.phr;

import java.util.List;

import nta.med.core.domain.phr.PhrMedicine;

public interface MedicineRepositoryCustom {

	public List<PhrMedicine> getMedicineByLastestDay(Long profileId, Integer limit);
	
}
