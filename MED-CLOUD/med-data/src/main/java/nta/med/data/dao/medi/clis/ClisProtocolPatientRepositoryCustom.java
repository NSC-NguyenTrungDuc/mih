package nta.med.data.dao.medi.clis;


import java.util.List;

import nta.med.data.model.ihis.clis.CLIS2015U04GetPatientListItemInfo;
import nta.med.data.model.ihis.emr.EMRGetLatestWarningStatusInfo;


public interface ClisProtocolPatientRepositoryCustom {

	public String getXRT0201U00ToolTipInfo(String hospCode, String bunho);
	public String getYByBunho(String hospCode, String bunho);
	public List<CLIS2015U04GetPatientListItemInfo> getCLIS2015U04GetPatientListItemInfo(String clisProtocolId);
	public List<String> getYByBunhoAndClisProtocolId(String hospCode, String bunho, Integer clisProtocolId);
	public EMRGetLatestWarningStatusInfo getLatestWarningStatusInfo(String hospCode, String bunho);
}
