package nta.med.data.dao.emr;

import nta.med.data.model.ihis.common.ComboListItemInfo;

public interface SysPropertyRepositoryCustom {
	public ComboListItemInfo getPropertyValueInfo(String locale);
}
