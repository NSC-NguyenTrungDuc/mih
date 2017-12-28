package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR5020U00grdWoiInfo;

/**
 * @author dainguyen.
 */
public interface Nur5023RepositoryCustom {

	public List<NUR5020U00grdWoiInfo> getNUR5020U00grdWoiInfoMode2(String hospCode, String language, String date, String hoDong, Integer startNum, Integer offset);
}

