package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.ADM103UgrdUserGrpInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Adm3100RepositoryCustom {
	public List<ADM103UgrdUserGrpInfo> getADM103UgrdUserGrpInfo(String hospCode, String language);
	public List<ComboListItemInfo> getComboUserGroup(String hospCode, String language, boolean isAll);
}

