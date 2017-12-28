package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocso.Ocs1023U00GrdOcs1023Info;
import nta.med.data.model.ihis.system.OBCheckRegularDrugInfo;

/**
 * @author dainguyen.
 */
public interface Ocs1023RepositoryCustom {
	public List<OBCheckRegularDrugInfo> getOBCheckRegularDrugInfo(String hospCode,String bunho,String gwa,String hangmog);
	
	public List<Ocs1023U00GrdOcs1023Info> getOcs1023U00GrdOcs1023Info(String hospCode, String language, String bunho,
			String genericYn, String gwa, String inputTab);
	
	public String callPrOcsMakeRegularOrder(String hospCode, String gubun, Double pkKey, String userId);
}

