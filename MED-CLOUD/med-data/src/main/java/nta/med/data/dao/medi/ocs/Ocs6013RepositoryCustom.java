package nta.med.data.dao.medi.ocs;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Ocs6013RepositoryCustom {
	public String callFnOcsLoadOrderPrtPgmId(String hospCode, String tableId, String key);
	public String getOCS6010U10GetCheckDupDirRequest(String hospCode, String fkocs6010, String inputGubun, String orderDate, String directGubun, String directCode); 
	public Double getNextGroupSerOcs6013(String hospCode, Date orderDate, String inputGubun, Double fkocs6010);
}

