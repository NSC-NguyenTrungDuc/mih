package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetCodeListInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0312RepositoryCustom {
	public List<OCS0311U00grdSetCodeListInfo> getOCS0311U00grdSetCodeListInfo(String hospCode,String setPart,String hangmogCode);
}

