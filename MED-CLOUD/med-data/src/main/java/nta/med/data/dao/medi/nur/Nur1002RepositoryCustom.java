package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1002Info;

/**
 * @author dainguyen.
 */
public interface Nur1002RepositoryCustom {

	public List<NUR1001U00GrdNUR1002Info> getNUR1001U00GrdNUR1002Info(String hospCode, String bunho, Double fkinp1001, Integer startNum, Integer offset);
}

