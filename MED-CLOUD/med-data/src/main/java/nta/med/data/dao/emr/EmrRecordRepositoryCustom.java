package nta.med.data.dao.emr;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.EMRUserGetLockEditingInfo;
import nta.med.data.model.ihis.emr.EmrRecordGetOldDataInfo;
import nta.med.data.model.ihis.emr.OCS2015U00LoadPatientMedicalRecordInfo;
import nta.med.data.model.ihis.emr.OCS2015U06EmrRecordInfo;
import nta.med.data.model.ihis.emr.OCS2015U06EmrTagInfo;
import nta.med.data.model.ihis.emr.OCS2015U06EmrTemplateInfo;
import nta.med.data.model.ihis.emr.OCS2015U06EmrTemplateTypeInfo;
import nta.med.data.model.ihis.emr.PatientEmailInfo;
import nta.med.data.model.ihis.emr.OCS2015U40EmrHistoryMedicalRecordInfo;

public interface EmrRecordRepositoryCustom {
	public List<OCS2015U06EmrRecordInfo> getOCS2015U06EmrRecordInfo(String bunho, String hospCode);
	
	public PatientEmailInfo getCreatedRecordLog (String emrRecordId) ;
	public OCS2015U00LoadPatientMedicalRecordInfo getOCS2015U00LoadPatientMedicalRecordInfo (String bunho, String hospCode);
	
	
	public ComboListItemInfo getOCS2015U40EmrMedicalRecordContentListItem(String emrReCordId);
	
	public Integer getEmrRecordId(String bunho, String hospCode);
	
	public Integer getEmrRecordMaxVersion(Integer recordId);
	public EmrRecordGetOldDataInfo getEmrRecordGetOldDataInfo (String emrRecordId);
	public boolean checkUserCreateBookmark (String recordId, String userId) ;
	public String getUserEditingRecord (String recordId);
	public EMRUserGetLockEditingInfo getEMRUserGetLockEditingInfo(String recordId) ;
	public boolean getEditingTime (String recordId);
	
	public Integer getOcs2015U00EmrNoInfo(String hospCode, String patientCode);
}
