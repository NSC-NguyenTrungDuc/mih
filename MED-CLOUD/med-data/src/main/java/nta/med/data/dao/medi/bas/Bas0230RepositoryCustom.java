package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.adma.BAS0230U00GrdBAS0230Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0230RepositoryCustom {
	
	public List<BAS0230U00GrdBAS0230Info> getBAS0230U00GrdBAS0230(String hospCode, String language, String startYmd);
	
	public List<ComboListItemInfo> getBunCodeBunNameListItemInfo(String hospCode, String language, String find1, String bunYmd, boolean bun, boolean isAll);
	
	public String getBunNameItemInfo (String hospCode, String language, String bunCode, String bunYmd, boolean bun);
	
	public List<ComboListItemInfo> getComboNuGroup(String hospCode, String language, boolean isAll);
	public String getBAS0203U00LayBunCode(String hospCode, String language, String code);
} 

