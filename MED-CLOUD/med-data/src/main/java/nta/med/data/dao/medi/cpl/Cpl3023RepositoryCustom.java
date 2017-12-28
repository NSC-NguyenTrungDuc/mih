package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.cpls.CPL0000Q00ResultListQuerySelect1ListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl3023RepositoryCustom {
	
	public List<CPL0000Q00ResultListQuerySelect1ListItemInfo> getCPL0000Q00ResultListQuerySelect1Request(String hospCode, String specimenSer,
			String srlCode, String jundalGubun);
}

