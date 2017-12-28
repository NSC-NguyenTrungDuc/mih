package nta.med.data.dao.medi.ifs;

import java.util.List;

import nta.med.data.model.ihis.adma.IFS0001U00GrdDetailInfo;
import nta.med.data.model.ihis.bass.ComBizGetFindWorkerInfo;
import nta.med.data.model.ihis.bass.ComBizLoadIFS0002Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ifs0002RepositoryCustom {
	public List<IFS0001U00GrdDetailInfo> getIFS0001U00GrdDetailInfo(String hospCode, String codeType, Integer pageNumber, Integer offset);
	
	
	public List<ComboListItemInfo> getIfs003U03FwkCommonListItem(String hospCode, String codeType, String find, boolean orderByHospCode, Integer startNum, Integer endNum);
	
	public String getIfs003U03FbxSearchGubun(String hospCode, String codeType, String code);
	
	public String callPkgIfsBasFnLoadIfCodeName(String hospCode, String mapGubun, String code);
	
	public List<ComBizLoadIFS0002Info> getComBizLoadIFS0002ListItem(String hospCode, String codeType, String code);
	
	public List<ComBizGetFindWorkerInfo> getComBizGetFindWorkerInfoCaseCodeType(String hospCode, String find);
	
	public List<ComBizGetFindWorkerInfo> getComBizGetFindWorkerInfoCaseCodeOLD(String hospCode, String codeType, String find);
}

