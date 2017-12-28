package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.system.MenuViewFormItemInfo;

/**
 * @author dainguyen.
 */
public interface Adm4500RepositoryCustom {
	public void callProcAdmGenMyMenu(String hospCode, String language, String userId, String role);
	
	public List<MenuViewFormItemInfo> getMenuViewFormItemInfo(String hospCode, String userId);
}

