package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.cpls.CPL3020U00DsvNoteListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02DsvNoteListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl2090RepositoryCustom {
	
	public List <CPL3020U00DsvNoteListItemInfo> getCPL3020U00DsvNoteListItem(String hospCode, String specimentSer, String jundalPart);

	public List<CPL3020U02DsvNoteListItemInfo> getCPL3020U02DsvNoteListItemInfo(String hospCode, String specimenSer, String jundalGubun);
	
	public String getCPL3020U00ExecuteGetYValue(String hospCode, String jundalGubun, String specimenSer); 
	
}

