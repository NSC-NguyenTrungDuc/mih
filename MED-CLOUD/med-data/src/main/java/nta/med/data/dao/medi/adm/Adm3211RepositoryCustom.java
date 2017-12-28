package nta.med.data.dao.medi.adm;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Adm3211RepositoryCustom {
	
	public String getLoadColumnCodeNameUserId(String hospCode, String userId);
	public List<ComboListItemInfo> getOCS0150Q00FindboxMemb(String hospCode,String language,String find);
	public String getNUR6011U01LoadUserNm(String hospCode, String code);
	public String callFnAdmLoadUserNm(String hospCode, String code, Date fdate);
}

