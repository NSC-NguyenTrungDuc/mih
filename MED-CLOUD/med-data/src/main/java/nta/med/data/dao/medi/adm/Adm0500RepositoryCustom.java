package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.system.MdiFormMainMenuItemInfo;

/**
 * @author dainguyen.
 */
public interface Adm0500RepositoryCustom {
	
	public List<MdiFormMainMenuItemInfo> getMdiFormMainMenuItemInfo(String sysId, String hospCode);
}

