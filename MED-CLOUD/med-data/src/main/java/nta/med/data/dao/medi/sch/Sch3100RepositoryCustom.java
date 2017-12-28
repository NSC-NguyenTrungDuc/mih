package nta.med.data.dao.medi.sch;

import java.util.List;

import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3100Info;

/**
 * @author dainguyen.
 */
public interface Sch3100RepositoryCustom {
	
	public List<SCH3001U00GrdSCH3100Info> getSCH3001U00GrdSCH3100Info(String hospCode, String jundalTable, String jundalPart, String gumsaja);
}

