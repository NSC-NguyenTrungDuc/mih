package nta.med.data.dao.medi.kinki;

import java.util.List;

import nta.med.data.model.ihis.system.DrugDosageMasterInfo;

public interface DrugDosageRepositoryCustom {
	public List<DrugDosageMasterInfo> getDrugDosageMasterInfo();
}
