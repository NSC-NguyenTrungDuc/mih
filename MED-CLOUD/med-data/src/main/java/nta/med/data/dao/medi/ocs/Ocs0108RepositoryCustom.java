package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drug.DRGOCSCHKgrdOCS0108Info;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0108Info;
import nta.med.data.model.ihis.ocsa.OCS0108U00grdOCS0108ItemInfo;
import nta.med.data.model.ihis.ocso.OCSACTGetFindWorkerInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0108RepositoryCustom {
	public List<OCS0108U00grdOCS0108ItemInfo> getOCS0108U00grdOCS0108ItemInfo(String hospCode, Date hangmogStartDate, String hangmogCode);
	public String getGetDefaultOrdDanui1Request(String hospCode, String hangmogCode);
	public List<ComboListItemInfo> getGetDefaultOrdDanuiInfo(String hospCode, String language, String hangmogCode);
	
	public String getLoadColumnCodeNameOrdDanuiCase(String hangmogCode, String ordDanui, String hospCode);
	
	public String getLoadColumnCodeNameOrdDanuiNameCase(String hangmogCode, String ordDanui, String hospCode, String language);
	
	public String callFnOcsExistsOrdDanui(String hospCode, String hangmogCode, String ordDanui);
	public List<OCSACTGetFindWorkerInfo> getOCSACTGetFindWorkerInfoCaseOrdDanui(String hospCode, String language, String hangmogCode);
	public List<OCSACTGetFindWorkerInfo> getOCSACTGetFindWorkerInfoCaseOrdDanuiName(String hospCode, String language, String hangmogCode);
	public List<OCS0103U00GrdOCS0108Info> getOCS0103U00GrdOCS0108Info(String hospCode, String aHangmogCode, Date aHangmogStartDate, String language);
	public List<DRGOCSCHKgrdOCS0108Info> getDRGOCSCHKgrdOCS0108Info(String hospCode, String language, String aHangmogCode, Date aHangmogStartDate);
	public List<ComboListItemInfo> getComboNUR0110U00SetFindWorker(String hospCode, String language, String hangmogCode);
	public List<String> getNUR0110U00GrdNUR0115ColChangeCaseOrdDanui(String hospCode, String language, String ordDanui, String hangmogCode);
}

