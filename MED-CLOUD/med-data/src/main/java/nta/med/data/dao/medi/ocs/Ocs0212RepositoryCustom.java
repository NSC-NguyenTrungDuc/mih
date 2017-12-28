package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0203U00LayOCS0212Info;
import nta.med.data.model.ihis.system.LoadOftenUsedResponseInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0212RepositoryCustom {
	
	public Double getMaxSeqOfenUsedHangmogInfo(String hospCode, String membGubun, String memb, String hangmogCode);
	
	public List<LoadOftenUsedResponseInfo> getLoadOftenUsedResponseListItem(String hospCode, String language, String membGubun, String memb, 
			String orderGubun, String wonnaeDrgYn, String searchWord);
	
	public List<OCS0203U00LayOCS0212Info> getOCS0203U00LayOCS0212Info(String hospCode, String memb, String slipCode);
}

