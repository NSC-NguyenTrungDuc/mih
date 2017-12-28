package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0115Info;
import nta.med.data.model.ihis.system.PrOcsLoadJundalInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0115RepositoryCustom {
	public PrOcsLoadJundalInfo callPrOcsLoadJundalInfo(String hospCode, String hangmogCode, String inputPart, String inputGwa, Date appDate, 
			String jundalPartOut, String jundalPartInp, String jundalTableOut, String jundalTableInp, String movePart,String ioFlag, String msg);
	
	public List<ComboListItemInfo> getFindWorkerJundalHangmog(String hospCode, String language, String argu1, String argu2, String caseCondition);
	
	public String getLoadColumnCodeNameJundalPartOutHangmogCase(String argu1, String argu2, String argu3, String hospCode, String language);
	
	public String getLoadColumnCodeNameJundalPartInpHangmogCase(String argu1, String argu2, String argu3, String hospCode, String language);
	public List<OCS0103U00GrdOCS0115Info> getOCS0103U00GrdOCS0115Info(String hospCode,String language,String hangmocCode,String hangmogStartDate);
	
	public String getPhy8002U01BtnPrintGetGwaNameSinryouka(String hospCode, String gwa);
}

