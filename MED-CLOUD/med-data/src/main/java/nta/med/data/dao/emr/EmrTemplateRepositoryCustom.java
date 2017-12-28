package nta.med.data.dao.emr;

import java.util.List;

import nta.med.data.model.ihis.emr.DepartAndDoctorInfo;
import nta.med.data.model.ihis.emr.OCS2015U06EmrTemplateInfo;
import nta.med.data.model.ihis.emr.OCS2015U09GetTemplateComboBoxInfo;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTemplateInfo;
import nta.med.data.model.ihis.emr.OCS2015U31GetEmrTemplateInfo;

public interface EmrTemplateRepositoryCustom {
	public List<OCS2015U31EmrTemplateInfo> getTemplateListItemInfo (String hospCode, String userId, String userGroup, String language);
	public List<OCS2015U06EmrTemplateInfo> getOCS2015U06EmrTemplateInfo(String templateCode, String gwa);
	public List<OCS2015U09GetTemplateComboBoxInfo> getOCS2015U09GetTemplateComboBoxInfo (String hospCode, String userId, String language);	
	public List<OCS2015U31GetEmrTemplateInfo> getOCS2015U31GetEmrTemplateListInfo(String hospCode, String userId,
			String templateCode, String permissionType, String level, List<String> deptCodeList, String doctorCode, boolean isCommonTab, String language);
	
	public List<DepartAndDoctorInfo> getDepartAndDoctorInfo(String hospCode, String language, String buseoGubun);
	
	public String findLastestTemplateCode(String hospCode, String templateCode, String doctorCode, String permissionType);
}
