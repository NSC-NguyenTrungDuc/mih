package nta.med.data.dao.medi.cpl;

import java.util.List;

import org.springframework.data.repository.query.Param;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0101U00InitListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0108U00InitGrdDetailListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00GrdResultListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00MlayConstantCPL2010ListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl0109RepositoryCustom {

	public List<CPL0108U00InitGrdDetailListItemInfo> getListCPL0108U00GrdDetail(String hospCode, String codeType,String language, Integer startNum, Integer endNum);

	public String getCheckItemGrdDetail(String hospCode, String code, String codeType, String language);
	
	public List<String> getCheckCodeType(String hospCode, String codeType); 
	
	public List<ComboListItemInfo> getCpl0109ComboListItemInfo(String hospCode, String language, String codeType, boolean isAll);
	
	public List<CPL0101U00InitListItemInfo> getInitListItem(String hospCode, String language, String hangmog, String ioGubun, Integer startNum, Integer endNum);
	
	public List<ComboListItemInfo> getListCboBarCodeItem(String hospCode, String codeType, String langague, String orderByNull);
	
	public List<ComboListItemInfo> getListCboResulFormItem(String hospCode, String codeType, String langague);
	
	public List<ComboListItemInfo> getListCboSpcialNameItem(String hospCode, String codeType, String langague);
	
	public List<ComboListItemInfo> getListInoutGubunItem(String hospCode, String codeType, String langague);
	
	public String getCPL0101U00FbxJundalGubunName(String hospCode, String codeType, String systemGubun, String code, String language);
	
	public String getCPL0101U00getACtlName(String hospCode, String codeType, String code, String language);
	
	public List<ComboListItemInfo> getCPL0101U00FbxJundalGubunComboListItem(String hospCode, String codeType, String systemGubun, String find1, String find2, String language);
	
	public List<ComboListItemInfo> getCPL0101U00getACtrComboListItem(String hospCode, String codeType, String find1, String find2, String language);
	
	public List<ComboListItemInfo> getFwkJundalGubunListItem(String hospCode, String codeType, String find, String language);
	
	public List<CPL3020U00GrdResultListItemInfo> getGrdResultListItem(String hospCode, String language, String labNo, String specimenSer, String jundalGubun, String codeType);
	
	public String getCodeNameVsvJundalGubun(String hospCode, String codeType, String code, String language);
	
	public List<ComboListItemInfo> getCPL3020U00FwkResultInputSQL(String hospCode, String find, String codeType, String language);
	
	public List<CplsCPL2010U00MlayConstantCPL2010ListItemInfo> getCPL2010U00MlayConstantInfo(String hospCode, String language, String codeType);
	
	public List<ComboListItemInfo> getCPL0001U00GrdComboInfo(String hospCode, String codeType, String systemGubun, String language);
	
	public List<ComboListItemInfo> getCPL0001U00CboJundalInfo(String hospCode, String codeType, String systemGubun, String language);
	
	public List<ComboListItemInfo> getCPLMASTERUPLOADERCboMstType(String hospCode, String language);
	
	public String getCPL2010U02SaveLayoutRequest(String hospCode, String codeType, String code);
}

