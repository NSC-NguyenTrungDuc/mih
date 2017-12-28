package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.xrts.XRT1002U00GrdPaStatusInfo;

/**
 * @author dainguyen.
 */
public interface Ocs1801RepositoryCustom {
	public List<XRT1002U00GrdPaStatusInfo> getXRT1002U00GrdPaStatusInfo(String hospCode, String language, String bunho, String hangmogCode);
	public List<XRT1002U00GrdPaStatusInfo> getXRT1002U00PrintOrderByJudalPart(String hospCode, String language, String bunho, String hangmogCode);
}

