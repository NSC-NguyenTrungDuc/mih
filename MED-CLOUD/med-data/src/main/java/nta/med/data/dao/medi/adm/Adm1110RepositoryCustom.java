package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.ADM201UGrdDicDetailOderListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Adm1110RepositoryCustom {
	public List<ADM201UGrdDicDetailOderListItemInfo> getADM201UGrdDicDetailOderListItemInfo (String colId, Integer startNum, Integer endNum, String language); 

	public List<ComboListItemInfo> getComboUserGubun(boolean isAll, String language, String colId);
}

