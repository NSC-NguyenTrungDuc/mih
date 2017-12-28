package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;

public interface Acc001RepositoryCustom {
	
	public List<ComboListItemInfo> getIfs0001U00AccountingSystemInfo(String find1, String language);

}
