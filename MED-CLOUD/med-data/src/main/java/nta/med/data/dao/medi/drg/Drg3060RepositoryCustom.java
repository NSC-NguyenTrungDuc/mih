package nta.med.data.dao.medi.drg;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Drg3060RepositoryCustom {
	
	public String callPrDrgLoadPrintGubun(String hospCode, String jubsuDate, String drgBunho, String printGubun);
	
	public String callPrDrgMakeDrg3060(String hospCode, String userId, Double fkocs2003, String boryuYn);
	
	public String callPrDrgLoadPrintGubun(String hospCode, Date jusuDate, Double drgBunho, String printGubun);
}

