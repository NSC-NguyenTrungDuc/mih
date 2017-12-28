package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR5020U00grdWatchListInfo;

/**
 * @author dainguyen.
 */
public interface Nur5024RepositoryCustom {

	public List<NUR5020U00grdWatchListInfo> getNUR5020U00grdWatchListInfo(String hospCode, String language, String date, String hoDong, Integer startNum, Integer offset);
}

