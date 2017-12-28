package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;


/**
 * @author dainguyen.
 */
public interface Cpl0155RepositoryCustom {
	public String getCPL3020U00FwkResultGetY(String hospCOde, String resultForm);
	
	public List<ComboListItemInfo> getCPL3020U00FwkResultInputSQL(String hospCode, String find, String resultForm);

	public List<ComboListItemInfo> getCPL3020U02FwkResult(String hospCode, String find1, String resultCodeGubun);	
}

