package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0128RepositoryCustom {
	public String getOCS0103U00GrdOCS0115ColChangedJundalPartOut(String hospCode, String language, String gwa, boolean isInpJundalPart, String iOGubun);
	public String getOCS0103U00GetJundalTable(String hospCode, String jundalPart, String startDate, String ioGubun);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String language, String ioGubun);
}

