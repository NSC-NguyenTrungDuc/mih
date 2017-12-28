package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.system.SpeciFicCommentInputYnInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0170RepositoryCustom {
	public List<SpeciFicCommentInputYnInfo> getSpeciFicCommentInputYnInfo(String hospCode,String hanmogCode);
	
	public String getLoadColumnCodeNameSpecificCommentCase(String specimen, String hospCode);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode);
}

