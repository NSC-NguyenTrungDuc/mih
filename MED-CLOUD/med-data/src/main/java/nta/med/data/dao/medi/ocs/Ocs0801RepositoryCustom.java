package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.endo.END1001U02DsvLDOCS0801Info;
import nta.med.data.model.ihis.ocsa.OCS0801U00GrdOCS0801ListItemInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00DsvLDOCS0801Info;

/**
 * @author dainguyen.
 */
public interface Ocs0801RepositoryCustom {
	public List<ComboListItemInfo> getOCS0803U00GetFindWorker(String language);
	
	public List<OCS0801U00GrdOCS0801ListItemInfo> getOCS0801U00GrdOCS0801ListItem(String language);
	
	public String getOCS0801getCodeNameOcs0801(String code,String language);
	
	public String getOCS0801TransactionDupCheck(String patStatus, String language);
	
	public List<XRT1002U00DsvLDOCS0801Info> getXRT1002U00DsvLDOCS0801Info(String hospCode, String language, String hangmogCode);
	public List<END1001U02DsvLDOCS0801Info> getEND1001U02DsvLDOCS0801Info(String hospCode, String language, String hangmogCode);
}

