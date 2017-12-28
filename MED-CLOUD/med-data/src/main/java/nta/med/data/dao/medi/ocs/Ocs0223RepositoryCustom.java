package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0223U00GrdOCS0223Info;

/**
 * @author dainguyen.
 */
public interface Ocs0223RepositoryCustom {
	public List<OCS0223U00GrdOCS0223Info> getOCS0223U00GrdOCS0223Info(String hospitalCode, String language,
			String jundalPart);
}

