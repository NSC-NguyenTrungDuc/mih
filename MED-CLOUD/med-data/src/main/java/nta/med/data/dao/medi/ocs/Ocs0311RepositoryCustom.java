package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0311Q00LayRootListInfo;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdHangmogCodeListInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0311RepositoryCustom {
	public List<OCS0311U00grdHangmogCodeListInfo> getOCS0311U00grdHangmogCodeListInfo(String hospCode,String language,String setPart);
	public List<OCS0311Q00LayRootListInfo> getOCS0311Q00LayRootListInfo(String hospCode,String language,String setPart,String hangmogCode);
}

