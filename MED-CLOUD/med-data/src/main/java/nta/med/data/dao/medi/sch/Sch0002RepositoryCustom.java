package nta.med.data.dao.medi.sch;

import java.util.List;

import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH0002Info;


/**
 * @author dainguyen.
 */
public interface Sch0002RepositoryCustom {
	public String getjundalTable(String hospCode, String hangmogCode);
	
	public List<SCH3001U00GrdSCH0002Info> getSCH3001U00GrdSCH0002Info(String hospCode, String jundalTable, String jundalPart);
}

