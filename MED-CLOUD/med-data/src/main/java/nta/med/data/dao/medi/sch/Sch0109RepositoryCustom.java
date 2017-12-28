package nta.med.data.dao.medi.sch;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.schs.ComboGumsaListItemInfo;
import nta.med.data.model.ihis.schs.ComboGumsaPartListItemInfo;

/**
 * The Interface Sch0109RepositoryCustom.
 *
 * @author dainguyen.
 */

public interface Sch0109RepositoryCustom {
	
	/**
	 * Gets the patient inspection order code name info.
	 *
	 * @param hospitalCode the hospital code
	 * @param codeType the code type
	 * @param code2 the code2
	 * @return the patient inspection order code name info
	 */
	public List<String> getNuroInspectionOrderCodeNameInfo(String hospitalCode, String codeType, String code2);
	
	/**
	 * Gets the patient inspection order text.
	 *
	 * @param hospitalCode the hospital code
	 * @param codeType the code type
	 * @return the patient inspection order text
	 */
	public List<String> getNuroInspectionOrderText(String hospitalCode, String codeType, String language);
	
	
	/**
	 * Gets the patient inspection order max code name.
	 *
	 * @param hospitalCode the hospital code
	 * @param codeType the code type
	 * @param reserPart the reser part
	 * @return the patient inspection order max code name
	 */
	public List<String> getNuroInspectionOrderMaxCodeName(String hospitalCode, String codeType, List<String> reserPart);
	
	public List<ComboGumsaListItemInfo> getComboGumsaListItemInfo(String hospCode);
	
	public List<ComboGumsaPartListItemInfo> getComboGumsaPartListItemInfo(String hospCode, String jundalTable);
	public List<ComboListItemInfo> getSCH3001U00GetCboGumsa(String hospCode, String language, String codeType);
	public List<ComboListItemInfo> getSCH0201Q12CboAppointmentList(String hospCode, String language);
	
	public List<ComboListItemInfo> getComboGumsaListItemInfo(String hospCode, String language);
}

