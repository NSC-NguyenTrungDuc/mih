package nta.med.data.dao.emr;

import java.util.List;

import nta.med.data.model.ihis.emr.OCS2015U06EmrTagInfo;
import nta.med.data.model.ihis.emr.OCS2015U07TagChildInfo;
import nta.med.data.model.ihis.emr.OCS2015U09EmrTagGetTemplateTagsInfo;
import nta.med.data.model.ihis.emr.OCS2015U09GetTagsForContextInfo;
import nta.med.data.model.ihis.emr.OCS2015U09TagParentAndChild;
import nta.med.data.model.ihis.emr.OCS2015U30EmrTagGetTagInfo;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTagGetTagInfo;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTagGetTemplateTagsInfo;
import nta.med.data.model.ihis.emr.OCS2015U31GetTemplateTagsInfo;

public interface EmrTagRepositoryCustom {
	public List<OCS2015U30EmrTagGetTagInfo> getOCS2015U30EmrTagGetTagInfo (String tagLevel, String hospCode, String userId, String userGroup);
	public String getUserGroup (String userId);
	public Integer checkExistTagCodeCaseAdded (String tagCode);
	public Integer checkExistTagCodeCaseModified (String tagId, String tagCode);
	public List<OCS2015U31EmrTagGetTagInfo> getOCS2015U31EmrTagGetTagInfo (String hospCode,String tagLevel);
	public List<OCS2015U31EmrTagGetTemplateTagsInfo> getOCS2015U31EmrTagGetTemplateTagsInfo (String hospCode, List<String> tagCode);
	public List<OCS2015U06EmrTagInfo> getOCS2015U06EmrTagInfo(String hospCode);
	public List<OCS2015U09GetTagsForContextInfo> getOCS2015U09GetTagsRootForContextInfo(String hospCode);
	public List<OCS2015U09GetTagsForContextInfo> getOCS2015U09GetTagsNodeForContextInfo(String hospCode, String userId, String tagParent);
	public List<OCS2015U07TagChildInfo> getOCS2015U07TagChildInfo(String tagParent, String hospCode);
	
	public List<OCS2015U31GetTemplateTagsInfo> getOCS2015U31GetTemplateTagsParentListInfo(String hospCode, String templateId);
	
	public List<OCS2015U31GetTemplateTagsInfo> getOCS2015U31GetTemplateTagsChildListInfo(String hospCode, String templateId);
	public List<OCS2015U09TagParentAndChild> getOCS2015U09TagParentAndChild(String hospCode, List<Integer> emrTemplateId);
	public List<OCS2015U31EmrTagGetTemplateTagsInfo> getOCS2015U09EmrTagGetTemplateTagsInfo (String hospCode, String tagParent, String tagChild);
	public List<OCS2015U09EmrTagGetTemplateTagsInfo> getOCS2015U09EmrTagGetTemplateTagsInfo (String hospCode, List<Integer> emrTemplateId);
	public List<OCS2015U09EmrTagGetTemplateTagsInfo> getOCS2015U09EmrTagGetTemplateTagsChildInfo (String hospCode, List<Integer> emrTemplateId);
}
