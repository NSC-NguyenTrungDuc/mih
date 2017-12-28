package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NuriMeasurePhysicalConditionListItemInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdPatientListRowFocusChangedInfo;
import nta.med.data.model.phr.SyncBloodPressureInfo;
import nta.med.data.model.phr.SyncHeartRateInfo;
import nta.med.data.model.phr.SyncHeightInfo;
import nta.med.data.model.phr.SyncRespirationRateInfo;
import nta.med.data.model.phr.SyncTemperatureInfo;
import nta.med.data.model.phr.SyncWeightInfo;

/**
 * @author dainguyen.
 */
public interface Nur7001RepositoryCustom {
	public List<NuriMeasurePhysicalConditionListItemInfo> getNuriMeasurePhysicalConditionListItemInfo(String hospCode, String bunho);
	
	public List<PHY2001U04GrdPatientListRowFocusChangedInfo> getGrdPatientListRowFocusChangedInfo(String hospCode, String bunho, Date measureDate);
	
	public List<SyncHeightInfo> getPatientHeightByPatient(String hospCode, String patientCode);
	
	public List<SyncWeightInfo> getPatientWeightByPatient(String hospCode, String patientCode);
	
	public List<SyncTemperatureInfo> getPatientTemperatureByPatient(String hospCode, String patientCode);
	
	public List<SyncHeartRateInfo> getPatientHeartRateByPatient(String hospCode, String patientCode);
	
	public List<SyncRespirationRateInfo> getPatientRespirationRateByPatient(String hospCode, String patientCode);
	
	public List<SyncBloodPressureInfo> getPatientBloodPressureByPatient(String hospCode, String patientCode);

	public String getNUR6011U01GetNurseInfoWeight(String hospCode, String bunho, String jukyongDate);
}

