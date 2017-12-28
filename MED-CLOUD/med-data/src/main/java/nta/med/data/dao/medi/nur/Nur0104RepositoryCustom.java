package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Nur0104RepositoryCustom {
	public String getLoadColumnCodeNameInfoCaseHoTeam(String hospCode,String arg1,String arg2);
	public List<ComboListItemInfo> getComboListHoTeam(String hospCode, String argu1);
	public String getNUR1001U00BasicQuery2(String hospCode, Double fkinp1001);
}

