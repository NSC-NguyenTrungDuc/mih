package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR5020U00grdNURCntInfo;

/**
 * @author dainguyen.
 */
public interface Nur5027RepositoryCustom {

	public List<NUR5020U00grdNURCntInfo> getNUR5020U00grdNURCntInfo(String date, String hoDong, String hospCode, Integer startNum, Integer offset);
}

