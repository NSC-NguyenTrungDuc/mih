package nta.med.data.dao.phr;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.phr.PhrStandardFoodMenu;

public interface StandardFoodMenuRepositoryCustom {

	public List<PhrStandardFoodMenu> getListStandardFoodByProfileId(Long profileId, Integer limit);
	
	public BigDecimal getTotalKcalByProfileId(Long profileId, Date fromDate, Date toDate);
}
