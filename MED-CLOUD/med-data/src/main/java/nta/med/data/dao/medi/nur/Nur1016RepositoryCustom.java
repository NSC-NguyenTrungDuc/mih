package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1016Info;
import nta.med.data.model.ihis.nuri.NUR1016U00GrdNUR1016ListItemInfo;
import nta.med.data.model.ihis.nuri.NuriManageAllergyListItemInfo;

/**
 * @author dainguyen.
 */
public interface Nur1016RepositoryCustom {
	/**
	 * @param hospCode
	 * @param bunho
	 * @return
	 */
	public List<NuriManageAllergyListItemInfo> getNuriManageAllergyListItemInfo(String hospCode, String bunho);
	
	/**
	 * @param hospCode
	 * @param bunho
	 * @param tableId
	 * @param userId
	 * @return
	 */
	public String callNuriNUR1016U00NurAlegyMapping(String hospCode, String bunho, String tableId, String userId);
	
	
	public List<NUR1016U00GrdNUR1016ListItemInfo>  NUR1016U00GrdNUR1016ListItem(String hospCode, String bunho);
	
	public String getOpenAllergyInfo(String hospCode, String bunho, Date appDate);

	public List<NUR1001U00GrdNUR1016Info> getNUR1001U00GrdNUR1016Info(String hospCode, String bunho, String language,
			String sysDate, Integer startNum, Integer offset);
	
}

