package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0304Q00grdOCS0306Info;

/**
 * @author dainguyen.
 */
public interface Ocs0306RepositoryCustom {
	List<OCS0304Q00grdOCS0306Info> getOCS0304Q00grdOCS0306Info(String hospCode, String memb);
}

