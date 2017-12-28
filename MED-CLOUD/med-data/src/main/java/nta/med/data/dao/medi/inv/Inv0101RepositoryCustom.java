package nta.med.data.dao.medi.inv;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.Drg0102U01GrdMasterItemInfo;
import nta.med.data.model.ihis.invs.INV0101U01GridMasterInfo;

/**
 * @author dainguyen.
 */
public interface Inv0101RepositoryCustom {
	
	public List<ComboListItemInfo> getDRG0102U00GrdMasterInfo(String codeType, String codeTypeName, String language);
	public List<ComboListItemInfo> getINV0101U00GrdMasterInfo(String codeType, String language);
	public List<Drg0102U01GrdMasterItemInfo> getDrg0102U01GrdMasterListItem(String codeType, String codeTypeName, String language);
	
	public List<INV0101U01GridMasterInfo> getGridMasterInfo(String codeType, String language);
	
	public boolean isExistedINV0101(String codeType, String language);
	
	
	
}

