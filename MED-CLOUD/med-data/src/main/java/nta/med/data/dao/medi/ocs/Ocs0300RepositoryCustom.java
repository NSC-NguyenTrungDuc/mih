package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0103U14LaySlipCodeTreeInfo;
import nta.med.data.model.ihis.ocsa.OCS0301Q09GrdOCS0301Info;
import nta.med.data.model.ihis.ocsa.OCS0301U00MembGrdInfo;
import nta.med.data.model.ihis.ocso.OUTSANGU00GrdOCS0301Info;
//import nta.med.data.model.ihis.system.OFMakeTreeViewInfo;
import nta.med.data.model.ihis.system.OFMakeTreeViewInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0300RepositoryCustom {
	public List<OCS0103U14LaySlipCodeTreeInfo> getOCS0103U14LaySlipCodeTreeInfo(String hospCode, String language, String user);
	public List<OCS0301Q09GrdOCS0301Info> getOCS0301Q09GrdOCS0301(String hospCode,String language,String memb,String yaksokCode,String inputTab);
	public String getOCS0301Q09RbtMembCheckedChangedTableOCS0300And0301(String hospCode,String id,Double m0300,String m0301);
	public List<OFMakeTreeViewInfo> getOFMakeTreeView(String hospCode,String memb,String inputTab);
	
	
	public List<OCS0301U00MembGrdInfo> getOcs0300OCS0301U00MembGrdListItem(String hospCode, String memb, String inputTab);
	public List<OUTSANGU00GrdOCS0301Info> getOUTSANGU00GrdOCS0301Info(String hospCode, String language, String userId, String sangCode, String yaksokCode, String inputTab);
	
}

