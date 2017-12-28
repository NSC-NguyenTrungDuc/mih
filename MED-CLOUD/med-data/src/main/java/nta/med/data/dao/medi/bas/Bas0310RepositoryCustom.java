package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.adma.BAS0310U00GrdListInfo;
import nta.med.data.model.ihis.bass.BAS0311Q01GrdBAS0311Info;
import nta.med.data.model.ihis.bass.BAS0311U00GridListItemInfo;
import nta.med.data.model.ihis.bass.ComBizGetFindWorkerInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00LayCommonInfo;

/**
 * @author dainguyen.
 */
public interface Bas0310RepositoryCustom {
	public String getLoadColumnCodeNameSgCodeCase(String sgCode, String orderDate, String hospCode);
	
	public List<BAS0310U00GrdListInfo> getBAS0310U00GrdList(String hospCode, String language, String sgCode, String bunCode, Integer startNum, Integer endNum);
	
	public List<ComboListItemInfo> getSgCodeNameListItemInfo (String hospCode, String find1);
	
	public String getOCSACTCommand(String hospCode,String hangmogCode);
	public List<OCS0103U00LayCommonInfo> getOCS0103U00LayCommonInfo(String hospCode, Date sysDate, String sgCode,String startDate);
	
	public List<BAS0311Q01GrdBAS0311Info> getBAS0311Q01GrdBAS0311Info(String hospCode, String searchWord, String nuGroup, Integer startNum, Integer endNum);
	
	public List<ComBizGetFindWorkerInfo> getComBizGetFindWorkerInfoCaseSgCode(String hospCode, String sgYmd, String find);
	public List<BAS0311U00GridListItemInfo> getBAS0311U00GridListItemInfo(String hospCode, String language, String sgCode);
	
	public String callPrAdmUpdateMasterCom(String hospCode, String userId, String procGubun);
}

