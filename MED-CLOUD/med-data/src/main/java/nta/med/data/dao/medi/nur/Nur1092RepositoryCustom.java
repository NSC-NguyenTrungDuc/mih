package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1091Q00layDownListInfo;
import nta.med.data.model.ihis.nuri.NUR1094U00GrdDetailInfo;

public interface Nur1092RepositoryCustom {

	public List<NUR1094U00GrdDetailInfo> getNUR1094U00GrdDetailInfo(String hospCode, Double fknur1094);

	public List<NUR1091Q00layDownListInfo> getNUR1091Q00layDownListInfo(String hospCode, String codeType, Date fDate);
}
