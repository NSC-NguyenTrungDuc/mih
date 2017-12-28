package nta.med.data.dao.medi.ocs;


import java.util.List;

import nta.med.data.model.ihis.adma.Ocs0131U01Grd0131ListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0131U00GrdOCS0131Info;
import nta.med.data.model.ihis.system.LoadOcs0131Info;

/**
 * @author dainguyen.
 */
public interface Ocs0131RepositoryCustom {
	public String getLoadColumnCodeNameInfoCaseCodeType(String arg1, String language);
	
	public List<ComboListItemInfo> getOCS0131U00FwkCode(String find1, String language);
	
	public List<OCS0131U00GrdOCS0131Info> getOCS0131U00GrdOCS0131Info(String codeType, String language);
	
	public List<LoadOcs0131Info> getLoadOcs0131Info(String codeType, String language);
	
	public List<Ocs0131U01Grd0131ListItemInfo> getOcs0131U01Grd0131ListItemInfo(String codeType, String language);
}

