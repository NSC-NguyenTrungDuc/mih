package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.ADM101UGrdGroupItemInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00GetGroupListInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.system.MainFormGetMainMenuItemInfo;
import nta.med.data.model.ihis.system.MainMenuInfo;

/**
 * @author dainguyen.
 */
public interface Adm0100RepositoryCustom {

	/**
	 * Generate main menu.
	 *
	 * @param msgUserYn the msg user yn
	 * @param adminUserYn the admin user yn
	 * @return the list
	 */
	public List<MainMenuInfo> generateMainMenu(String msgUserYn, String adminUserYn, String language);
	
	public String getLoadColumnCodeNameJundalTableCase(String agru1);
	public List<ADM101UGrdGroupItemInfo> getADM101UGrdGroupItemInfo(String language, String grdId, String grpNm);
	public List<MainFormGetMainMenuItemInfo> getMainFormGetSuperAdminMenuItem(String language, String userId, String msgSys);
	public List<MainFormGetMainMenuItemInfo> getMainFormGetAdminMenuItem(String hospCode, String language, String userId, String msgSys);
	public List<ADMS2015U00GetGroupListInfo> getADMS2015U00GetGroupListInfo (String language);
}

