package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;

public interface Nur0801RepositoryCustom {

	public List<ComboListItemInfo> getNUR0802U00xEditGridCel3(String hospCode, String language);

	public List<ComboListItemInfo> getNUR8003R02cboHoDong(String hospCode, String needHType);

	public List<ComboListItemInfo> getNUR8003U03CboHoDong(String hospCode, String language);
}
