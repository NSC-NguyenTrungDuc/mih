package nta.med.data.dao.medi.cpl;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.cpls.CPL3020U02RESULTMAPGrdIDListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02RESULTMAPGrdResultListItemInfo;
import nta.med.data.model.ihis.cpls.Cpl3020U02ResultMapGrdIdInfo;
import nta.med.data.model.ihis.cpls.Cpl3020U02ResultMapGrdRsltInfo;

/**
 * @author dainguyen.
 */
public interface Cpl0891RepositoryCustom {
	
	public List<CPL3020U02RESULTMAPGrdIDListItemInfo> getCPL3020U02RESULTMAPGrdIDListItemInfo(String hospCode, String jangbiCode, String specimenSer,
			String fromDate, String toDate, String allYn);
	
	public List<CPL3020U02RESULTMAPGrdResultListItemInfo> getCPL3020U02RESULTMAPGrdResultListItemInfo(String hospCode, String jangbiCode,
			String resultDate, String sampleId);
	
	public List<Cpl3020U02ResultMapGrdIdInfo> getCpl3020U02ResultMapGrdIdInfo(String hospCode, String jangbiCode, String specimentSer, Date fromDate, Date toDate, String allYn);
	
	public List<Cpl3020U02ResultMapGrdRsltInfo> getCpl3020U02ResultMapGrdRsltInfo(String hospCode, String jangbiCode, Date resultDate, String sampleId);
	
	
	
}

