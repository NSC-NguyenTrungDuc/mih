package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.system.MdiFormMenuItemInfo;

/**
 * @author dainguyen.
 */
public interface Adm4300RepositoryCustom {
	
	public List<MdiFormMenuItemInfo> getMdiFormSystemMenu(String hospCode, String language, String userId, String sysId);

	public Integer deleteByHospCodeAndLanguageAndUserIdAndSysId(String hospCode, String language, String userId, String sysId);
}

