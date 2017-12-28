package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl0111RepositoryCustom {
	public List<ComboListItemInfo> getFwkNoteListItem(String hospCode, String jundalGubun, String find);
	
	public String getNoteVsvNote(String hospCode, String jundalGubun, String code);

	public List<ComboListItemInfo> getListCPL3020U02InitializeFwkNote(String hospCode, String jundalGubun, String find1); 
}

