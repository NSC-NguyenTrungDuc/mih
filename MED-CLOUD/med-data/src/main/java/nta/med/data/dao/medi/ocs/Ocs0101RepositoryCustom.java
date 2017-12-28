package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0101U00GrdOcs0101ListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U15LaySlipCodeTreeInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U17LayHangwiGubunInfo;
import nta.med.data.model.ihis.ocsa.OCS0108U00laySlipItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0113U00LaySlipListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0203U00LaySlipInfo;
import nta.med.data.model.ihis.ocsi.OCS2004U00layTabItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0101RepositoryCustom {
	
	public List<OCS0108U00laySlipItemInfo> getOCS0108U00laySlipItemInfo(String hospCode, String language);
	
	public List<OCS0101U00GrdOcs0101ListItemInfo> getOCS0101U00ListItem(String language);
	
	public String getOCS0101U00Grd0101CheckData(String value, String language);
	
	public List<OCS0113U00LaySlipListItemInfo> getOCS0113U00LaySlipItem(String hospCode, String language);
	
	public List<OCS0103U17LayHangwiGubunInfo> getOCS0103U17LayHangwiGubunListItem(String hospCode, String userId,
			String slip_gubun, String inputTab, String language);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfoOCS0101(String language);
	
	public List<OCS0103U15LaySlipCodeTreeInfo> getOCS0103U15LaySlipCodeTreeInfo(String hospCode, String language);
	
	public List<OCS0203U00LaySlipInfo> getOCS0203U00LaySlipInfo(String hospCode, String language);
	
	public String getOCS2003U99GetSyokudomeCnt(String hospCode, String fkinp1001, String kijunDate);
	
	public List<OCS2004U00layTabItemInfo> getOCS2004U00layTabItem();
}

