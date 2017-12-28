package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1029Info;

/**
 * @author dainguyen.
 */
public interface Nur1029RepositoryCustom {

	public List<NUR1001U00GrdNUR1029Info> getNUR1001U00GrdNUR1029Info(String hospCode, String bunho, Integer startNum, Integer offset);
}

