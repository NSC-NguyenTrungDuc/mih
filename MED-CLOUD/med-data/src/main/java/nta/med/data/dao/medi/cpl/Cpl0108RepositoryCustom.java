package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.cpls.CPL0108U00InitGrdMasterListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0108U01GrdMasterItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl0108RepositoryCustom {
	
	public List<CPL0108U00InitGrdMasterListItemInfo> getListCPL0108U00GrdMaster(String hospCode, String language, String codeTypeName);
	
	public String getCheckItemGrdMaster(String hospCode, String language, String codeType);
	public List<CPL0108U01GrdMasterItemInfo> getCPL0108U01grdMasterItemInfo(String hospCode, String language, String codeType, String codeTypeName);
}

