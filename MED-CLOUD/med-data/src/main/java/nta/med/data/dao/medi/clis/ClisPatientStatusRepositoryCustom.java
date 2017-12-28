package nta.med.data.dao.medi.clis;

import java.util.List;

import nta.med.data.model.ihis.clis.CLIS2015U04GetPatientStatusListItemInfo;

public interface ClisPatientStatusRepositoryCustom {

	public List<CLIS2015U04GetPatientStatusListItemInfo> getCLIS2015U04GetPatientStatusListItemInfo(
			String protocolPatientId, String hospCode);

	
}
