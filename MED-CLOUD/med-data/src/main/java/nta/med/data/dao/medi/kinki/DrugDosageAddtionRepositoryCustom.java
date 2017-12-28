package nta.med.data.dao.medi.kinki;

import java.util.List;

import nta.med.data.model.ihis.system.DrugDosageAddtionInfo;

public interface DrugDosageAddtionRepositoryCustom {
	public List<DrugDosageAddtionInfo> getDrugDosageAddtionInfo(Integer pageNumber, Integer offset);

}
