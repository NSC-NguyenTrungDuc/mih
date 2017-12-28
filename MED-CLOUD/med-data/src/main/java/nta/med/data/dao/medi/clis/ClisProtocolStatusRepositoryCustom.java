package nta.med.data.dao.medi.clis;

import java.util.List;

import nta.med.data.model.ihis.clis.CLIS2015U02GrdStatusInfo;

public interface ClisProtocolStatusRepositoryCustom {
	public List<CLIS2015U02GrdStatusInfo> getCLIS2015U02GrdStatusInfo(Integer clisProtocolId, String hospCode, String language);
}
