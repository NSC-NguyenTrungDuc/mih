package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0113Info;
import nta.med.data.model.ihis.ocsa.OCS0113U00GrdOCS0113ListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0113RepositoryCustom {
	public List<OCS0113U00GrdOCS0113ListItemInfo> getOCS0113U00GrdOCS0113ListItem(String hospCode, String hangmongCode);
	public List<OCS0103U00GrdOCS0113Info> getOCS0103U00GrdOCS0113Info(String hospCode,String aHangmogCode,String aHangmogStartDate);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String hangmogCode);
}

