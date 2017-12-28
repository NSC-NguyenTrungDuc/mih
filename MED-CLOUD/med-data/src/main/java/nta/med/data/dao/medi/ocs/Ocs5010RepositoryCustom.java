package nta.med.data.dao.medi.ocs;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Ocs5010RepositoryCustom {
	public void callPrOcsUpdateResult(String hospCode, String inOutGubun, Double fkOcs, String resultBuseo, Date resultDate);
}

