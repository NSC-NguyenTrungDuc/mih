package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.ADM2016U00GrdLoadDrgInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00FwkCommonInfo;

/**
 * @author dainguyen.
 */
public interface Adm9983RepositoryCustom {
	public List<OCS0103U00FwkCommonInfo> getOCS0103U00OCS0103U00FwkCommonInfo(String a9, String a7);
	public List<ADM2016U00GrdLoadDrgInfo> getADM2016U00GrdLoadDrgInfo(String hospCode,String a13, String a20, String a9,Integer startNum, Integer offset);
	public List<ComboListItemInfo> getCombo(String hospCode);
}

