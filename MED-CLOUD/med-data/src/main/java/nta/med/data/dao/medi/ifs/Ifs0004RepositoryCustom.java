package nta.med.data.dao.medi.ifs;

import java.util.List;

import nta.med.data.model.ihis.bass.IFS0004U01grdMasterListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ifs0004RepositoryCustom {
	
	public List<IFS0004U01grdMasterListItemInfo> getIfs0004U01grdMasterListItem(String hospCode, String nuGubun, String nuYmd);
}

