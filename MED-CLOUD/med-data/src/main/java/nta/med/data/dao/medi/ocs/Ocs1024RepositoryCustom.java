package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS1024U00grdOCS1024Info;

/**
 * @author dainguyen.
 */
public interface Ocs1024RepositoryCustom {
	
	public String callFnOcsIsBroughtDrgYn(String hospCode, String bunho, Integer pkinp1001, String inputTab);
	
	public String callFnOcsInsertBgtdrgYn(String hospCode, String bunho, Double pkocs1024, String suryang, String dv, String dvTime, String nalsu);
	public List<ComboListItemInfo> getOCS1024U00btnListGrdOCS1024(String hospCode, String hangmogCode, Double fkInp1001);
	public List<OCS1024U00grdOCS1024Info> getOCS1024U00grdOCS1024(String hospCode, String language, String genericYn, String bunho, String inputTab, Double fkinp1001,Integer startNum, Integer offset);
	public List<OCS1024U00grdOCS1024Info> getOCS1024U00grdOCS1024Jusa(String hospCode, String language, String genericYn, String bunho, String inputTab, Double fkinp1001,Integer startNum, Integer offset);
	public Double getMaxSeqByBunhoAnhGwa(String hospCode, String bunho, String gwa);
}

