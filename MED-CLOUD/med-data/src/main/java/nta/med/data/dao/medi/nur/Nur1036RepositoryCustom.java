package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1035U00grdNUR1036Info;

/**
 * @author dainguyen.
 */
public interface Nur1036RepositoryCustom {

	public List<NUR1035U00grdNUR1036Info> getNUR1035U00grdNUR1036Info(String hospCode, Double fknur1035, Integer startNum, Integer offset);

	public String getNUR1035U00cmdText(String hospCode, Double pknur1035);
}

