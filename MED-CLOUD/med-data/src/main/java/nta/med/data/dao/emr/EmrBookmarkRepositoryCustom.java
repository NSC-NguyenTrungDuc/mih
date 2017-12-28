package nta.med.data.dao.emr;

import java.util.List;

import nta.med.data.model.ihis.emr.OCS2015U04EmrRecordLoadBookmarkContentInfo;
import nta.med.data.model.ihis.emr.OCS2015U04LoadBookmarkByPk0ut1001Info;

public interface EmrBookmarkRepositoryCustom {
	public List<OCS2015U04EmrRecordLoadBookmarkContentInfo> getOCS2015U04EmrRecordLoadBookmarkContentInfo (String emrRecordId, String hospCode, String language);
	public List<OCS2015U04LoadBookmarkByPk0ut1001Info> getOCS2015U04LoadBookmarkByPk0ut1001Info (String pkout1001, String sysId, String emrRecordId);
}
