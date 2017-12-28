package nta.med.data.dao.medi.drg;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0103U10DrugTreeInfo;

/**
 * @author dainguyen.
 */
public interface Drg0141RepositoryCustom {
	public List<OCS0103U10DrugTreeInfo> listOCS0103U10DrugTreeInfo(String hospCode, String language);
}

