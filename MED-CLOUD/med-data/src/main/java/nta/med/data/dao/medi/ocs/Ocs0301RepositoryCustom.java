package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0301U00MembGrdInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0301RepositoryCustom {
	
	public List<OCS0301U00MembGrdInfo> getOcs0301OCS0301U00MembGrdListItem(String hospCode, String memb, Double fkocs0300);
}

