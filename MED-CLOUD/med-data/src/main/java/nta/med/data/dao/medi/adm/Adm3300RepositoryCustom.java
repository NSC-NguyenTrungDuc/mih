package nta.med.data.dao.medi.adm;

import java.util.Date;


/**
 * @author dainguyen.
 */
public interface Adm3300RepositoryCustom {
	public String getNexTrmId(String hospCode);

	public Integer updateAdm3300(String hospCode, String userId, Date upTime, String bPrintName, String ipAddr);
	public String getLayPrintName(String hospCode , String ipAddr);
	public Integer updateCPL2010U00SetPrint(String hospCode,String userId,String bPrintName,String ipAddr);
	public String getTTrmIdCPL2010U00SetPrint(String hospCode); 
	public Integer insertCPL2010U00SetPrint(String hospCode,String tTrimId,String ipAddr,String userId,String bPrintName);
}

