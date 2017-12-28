package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Nur0301RepositoryCustom {
	public List<ComboListItemInfo> getNuroRES0102U00CboGwaRoom(String hospCode, String departmentCode, String date);
}

