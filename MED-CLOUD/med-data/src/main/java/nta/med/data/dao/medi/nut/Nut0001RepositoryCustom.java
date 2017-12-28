package nta.med.data.dao.medi.nut;

import java.util.List;

import nta.med.data.model.ihis.nuts.Nut0001U00GrdNut0001ItemInfo;
import nta.med.data.model.ihis.ocsa.OCS3003Q11grdOrderDateListInfo;

/**
 * @author dainguyen.
 */
public interface Nut0001RepositoryCustom {
	
	public Double getOCS0103U19GetFkOcsInfo(String hospCode,Double fkOcs );
	
	public List<Nut0001U00GrdNut0001ItemInfo> getNut0001U00GrdNut0001ItemInfo(String hospCode, Double pkocskey);
	public List<OCS3003Q11grdOrderDateListInfo> getOCS3003Q11grdOrderDateListInfo(String hospCode, String bunho, Integer startNum, Integer offset);
}

