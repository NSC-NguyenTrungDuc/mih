package nta.med.data.dao.medi.ifs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.Ifs0003U00GrdIFS0003Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0103Info;

/**
 * @author dainguyen.
 */
public interface Ifs0003RepositoryCustom {
	public String getCodeByHospCodeAndMapGubunAndIfCode(String hospCode, String mapGubun, String ifCode);
	
	public String getIfs003U03LayDupCheck(String hospCode, String mapGubun, Date mapGubunYmd, String ocsCode, boolean codeCondition);

	public String callPkgIfsBasFnLoadIfCodeName (String hospCode, String mapGubun, String code);
	
	public List<OCS0103U00GrdOCS0103Info> getOCS0103U00GrdOCS0103Info(String hospCode,String language,String aSlipCode,
			String aHangMogInx,String aSlipGubun,String usedYn,String wonaeYn, Integer pageNumber, Integer offset);
	
	public List<Ifs0003U00GrdIFS0003Info> getIfs0003U00GrdIFS0003ListItem(String hospCode, String mapGubun, String mapGubunYn, String code, String acctType, boolean isIfCode, Integer pageNumber, Integer offset);
	public boolean isExistedIfs0003(String hospCode, String mapGobun, String ocsCode, String ifCode);
	public List<ComboListItemInfo> getIfCodeAndOcsCode(String hospCode);
	public boolean getCommonMapped(String hangmogCode, String hospCode, boolean requiredOcs0103Existed);

}

