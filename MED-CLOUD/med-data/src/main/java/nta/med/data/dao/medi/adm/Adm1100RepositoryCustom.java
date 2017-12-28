package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.ADM201UGrdDicMasterListItemInfo;

/**
 * @author dainguyen.
 */
public interface Adm1100RepositoryCustom {
	public List<ADM201UGrdDicMasterListItemInfo> getADM201UGrdDicMasterListItemInfo(String colId, String colNm, Integer pageNumber, Integer offset);
}

