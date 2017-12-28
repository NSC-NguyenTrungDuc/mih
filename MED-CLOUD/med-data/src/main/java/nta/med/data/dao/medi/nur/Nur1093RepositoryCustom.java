package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1094U00GrdMasterInfo;

public interface Nur1093RepositoryCustom {

	public List<NUR1094U00GrdMasterInfo> getNUR1094U00GrdMasterInfo(String hospCode, Double pkinp1001);
}
