package nta.med.data.dao.emr;

import java.util.List;

import nta.med.data.model.ihis.emr.OCS2015U06EmrTemplateTypeInfo;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTemplateTypeInfo;

public interface EmrTemplateTypeRepositoryCustom {
	public List<OCS2015U31EmrTemplateTypeInfo> getTemplateTyeListItemInfo (String language);
	public List<OCS2015U06EmrTemplateTypeInfo> getOCS2015U06EmrTemplateTypeInfo(String language);
}
