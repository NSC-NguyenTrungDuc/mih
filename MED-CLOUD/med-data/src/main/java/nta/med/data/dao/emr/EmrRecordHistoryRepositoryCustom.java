package nta.med.data.dao.emr;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.OCS2015U40EmrHistoryMedicalRecordInfo;

public interface EmrRecordHistoryRepositoryCustom {

	public Integer getOcs2015U44LastVerSionInsert(String recordId);
	
	public Integer getOcs2015U44OldestVerSionInsert(String recordId);
	
	public Integer getOcs2015U44TotalVersionCount(String recordId);
	
	public ComboListItemInfo getOCS2015U40EmrMedicalRecordHisotryContentListItem(Integer recordId, Integer version);
	
	public Integer getOcs2015U44OldestVersionCount(String recordId);
	
	public List<OCS2015U40EmrHistoryMedicalRecordInfo> getOCS2015U40EmrHistoryMedicalRecordListItem(Integer emrReCordId);
}
