package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.cpls.CPL3020U02GrdPaListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02GrdResultListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl3010RepositoryCustom {
	public List<CPL3020U02GrdPaListItemInfo> getCPL3020U02GrdPaListItemInfo(String hospCode, String fromDate, String toDate, String jangbiCode);
	
	public List<CPL3020U02GrdResultListItemInfo> getCPL3020U02GrdResultListItemInfo(String hospCode, String specimenSer, String labNo, String jundalGubun);
	
}

