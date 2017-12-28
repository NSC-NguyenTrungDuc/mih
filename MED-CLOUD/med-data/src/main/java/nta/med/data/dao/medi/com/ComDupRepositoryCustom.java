package nta.med.data.dao.medi.com;

import java.util.List;

/**
 * @author dainguyen.
 */
public interface ComDupRepositoryCustom {
	public List<Double> getNextGroupSer(String hospCode, String keyObj, String bunho, String pkKey, String inputTab) ;
	public String callPrOcsSetGroupSer(String hospCode,String pkKey,String bunho,String inputTab,String keyVal,String keyObj);
}

