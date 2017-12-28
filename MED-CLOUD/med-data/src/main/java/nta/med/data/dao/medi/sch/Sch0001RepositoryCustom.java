package nta.med.data.dao.medi.sch;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH0001Info;

/**
 * @author dainguyen.
 */
public interface Sch0001RepositoryCustom {
	public List<SCH3001U00GrdSCH0001Info> getSCH3001U00GrdSCH0001Info(String hospCode, String jundalTable);
	public List<ComboListItemInfo> getSchsSCH0201U99ComboGumsaPart (String hospCode, String language, String cboGumsaValue);
}

