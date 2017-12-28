package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.*;
import nta.med.data.model.ihis.system.OCS0103U12GrdGeneralInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0102RepositoryCustom {
	public List<OCS0101U00GrdOcs0102ListItemInfo> getOCS0101U00GrdOcso0102InitListItem(String hospCode, String slipGubun, String language);
	
	public String getOCS0101U00Grd0102CheckData(String hospCode, String value, String language);
	
	public List<OCS0103U12GrdGeneralInfo> getOCS0103U12GrdGeneralListItem(String hospCode, String filter, String yakKijunCode, String orderDate, String hangmogCode, Integer startNum, Integer offset, String language);
	public List<OCS0103U16SlipCodeTreeInfo> getOCS0103U16SlipCodeTree(String hospCode, String language);
	
	public String getLoadColumnCodeNameSlipCodeCase(String slipCode, String hospCode, String language);
	public List<OCS0103U11LaySlipCodeTreeListItemInfo> getOCS0103U11LaySlipCodeTreeList(String hospCode, String language);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String slipGubun, boolean isSlipGubun, String language);

} 

