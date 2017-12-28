package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0101U00GrdOcs0106ListItemInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdComment3Info;

/**
 * @author dainguyen.
 */
public interface Ocs0106RepositoryCustom {
	
	public List<OCS0101U00GrdOcs0106ListItemInfo> getOCS0101U00GrdOcs0106ListItem(String hospCode, String slipCode);
	
	public String getOCS0101U00Grd0106CheckData(String hospCode, String value);
	
	public List<XRT1002U00GrdComment3Info> getXRT1002U00GrdComment3Info(String hospCode, String bunho, String orderDate);
}

