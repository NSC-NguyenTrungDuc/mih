package nta.med.data.dao.medi.drg;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Drg5001RepositoryCustom {
	
	public Date callFnDrgGetCycleOrdDate(String hospCode, Date ordDate, String hoDong);
	
	public Date callFnDrgGetCycleMagamDate(String hospCode, Date ordDate, String hoDong);
	
	public String callPrDrgInpMagam(String updId, String hospCode, String hoDong, Date magamDate, String magamGubun);
}

