package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR5020U00grdGuhoGubunInfo;

/**
 * @author dainguyen.
 */
public interface Nur5021RepositoryCustom {

	public List<NUR5020U00grdGuhoGubunInfo> getNUR5020U00grdGuhoGubunInfoMode2(String hospCode, String hoDong, String date, Integer startNum, Integer offset);
}

