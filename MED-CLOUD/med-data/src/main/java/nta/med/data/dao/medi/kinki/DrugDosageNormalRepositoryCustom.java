package nta.med.data.dao.medi.kinki;

import java.util.List;

import nta.med.data.model.ihis.system.DrugDosageNormalInfo;

public interface DrugDosageNormalRepositoryCustom {
	public List<DrugDosageNormalInfo> getDrugDosageNormalInfo(Integer pageNumber, Integer offset);
}
