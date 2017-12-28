package nta.med.data.dao.medi.sch;

import java.util.List;

import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3101Info;

/**
 * @author dainguyen.
 */
public interface Sch3101RepositoryCustom {
	public List<SCH3001U00GrdSCH3101Info> getSCH3001U00GrdSCH3101Info(String hospCode, String jundalTable, String jundalPart, String gumsaja,
			String reserDate);
}

