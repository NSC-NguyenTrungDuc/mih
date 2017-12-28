package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR5020U00grdCommentInfo;

/**
 * @author dainguyen.
 */
public interface Nur5025RepositoryCustom {

	public List<NUR5020U00grdCommentInfo> getNUR5020U00grdCommentInfo(String hospCode, String date, String hoDong, Integer startNum, Integer offset);
}

