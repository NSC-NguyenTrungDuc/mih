package nta.med.data.dao.medi.ifs;

import java.util.List;

import nta.med.data.model.ihis.bass.IFS0004U01grdDetailtListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ifs0005RepositoryCustom {
	public List<IFS0004U01grdDetailtListItemInfo> getIfs0004U01grdDetailtListItem(String hospCode, String language, String curYmd, 
			String nuGubun, String nuCode, String nuYmd);
}

