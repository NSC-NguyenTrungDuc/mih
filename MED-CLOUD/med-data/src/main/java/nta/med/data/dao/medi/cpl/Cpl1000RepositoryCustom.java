package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.cpls.CPL3010U00DsvUrineListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl1000RepositoryCustom {
	
	public List<CPL3010U00DsvUrineListItemInfo> getCPL3010U00DsvUrineListItemInfo(String hospCode, String specimenSer, String gubun, Double fkocs, String inOutGubun);
}

