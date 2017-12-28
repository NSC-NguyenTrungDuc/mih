package nta.med.data.dao.medi.sch;

import java.util.List;

import nta.med.data.model.ihis.schs.SCH3001U00GrdJukyongDateInfo;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3000Info;

/**
 * @author dainguyen.
 */
public interface Sch3000RepositoryCustom {
	
	public List<SCH3001U00GrdJukyongDateInfo> getSCH3001U00GrdJukyongDateInfo(String hospCode, String jundalTable, String jundalPart, String gumsaja);
	
	public List<SCH3001U00GrdSCH3000Info> getSCH3001U00GrdSCH3000Info(String hospCode, String jundalTable, String jundalPart, String gumsaja,
			String jukyongDate, String yoilGubun);
}

