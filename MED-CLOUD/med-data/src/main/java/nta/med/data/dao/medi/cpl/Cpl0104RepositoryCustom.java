package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.cpls.CplCPL0104U00GrdDetailCPL0104ListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl0104RepositoryCustom {
	public List<CplCPL0104U00GrdDetailCPL0104ListItemInfo> getCplCPL0104U00GrdDetailCPL0104(String hospCode, String hangmogCode,String specimenCode
			, String emergency, Integer startNum, Integer endNum);
}

