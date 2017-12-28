package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1035U00grdNUR1035Info;

/**
 * @author dainguyen.
 */
public interface Nur1035RepositoryCustom {

	public List<NUR1035U00grdNUR1035Info> getNUR1035U00grdNUR1035Info(String hospCode, Double fkinp1001, Integer startNum, Integer offset);
}

