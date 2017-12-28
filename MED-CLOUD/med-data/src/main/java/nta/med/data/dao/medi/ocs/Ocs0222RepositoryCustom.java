package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0221Q01GrdOCS0222Info;
import nta.med.data.model.ihis.ocsa.OcsaOCS0221U00GrdOCS0222ListInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0222RepositoryCustom {
	public List<OcsaOCS0221U00GrdOCS0222ListInfo> getOcsaOCS0221U00GrdOCS0222List(String hospCode, String memb, String seq);
	public List<OCS0221Q01GrdOCS0222Info> getOCS0221Q01GrdOCS0222Info (String hospCode, String memb, String seq);
}

