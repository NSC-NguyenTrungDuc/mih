package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.Adm102UGrdListItemInfo;
import nta.med.data.model.ihis.adma.Adm106UMakeQueryListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.system.FormScreenInfo;

/**
 * @author dainguyen.
 */
public interface Adm0300RepositoryCustom {
	public List<FormScreenInfo> getFormScreenInfo(String language, String screenId);
	
	public List<Adm102UGrdListItemInfo> getAdm102UGrdListItem(String language, String sysId);
	
	public List<ComboListItemInfo> getAdm106UFwkPgmIdListItem(String pgmId, String language);
	
	public List<Adm106UMakeQueryListItemInfo> getAdm106UMakeQueryListItem(String hospCode, String sysId, String upperMenu, String language, String role);
	
	public String getAdm106UGrdMenuListItem(String pgmId, String language);
	
	public List<Adm108UGrdListItemInfo> getAdm108UGrdListItemIn(String sysId, String language, String hospCode);
	
	public List<Adm108UFwkPgmIdListItemInfo> getAdm108UFwkPgmIdListItem(String language, String hospCode);
	
	public List<ComboListItemInfo> getOcsPemRU00FwkPgmIdListItem(String sysId, String language);
	
	public boolean isExistedADM0300(String pgmId, String language);
	
}

