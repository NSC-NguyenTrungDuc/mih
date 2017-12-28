package nta.med.data.dao.medi.clis;

import java.util.List;

import nta.med.data.model.ihis.clis.Clis2015U09ItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

public interface ClisSmoRepositoryCustom {
	public List<Clis2015U09ItemInfo> getClis2015U09ItemInfo(String hospCode, String codeType, String language);
	
	public String getClis2015U09CheckSmoCodeInfo(String hospCode, String smoCode);
	
	public List<ComboListItemInfo> getADM104UClisComboInfo(String hospCode);
}
