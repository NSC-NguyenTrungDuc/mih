package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.core.domain.bas.Bas0102;
import nta.med.data.model.ihis.adma.BAS0101U04GrdDetailInfo;
import nta.med.data.model.ihis.bass.BAS0001U00grdDetailItemInfo;
import nta.med.data.model.ihis.bass.BAS0101U00GrdDetailListItemInfo;
import nta.med.data.model.ihis.bass.BAS0101U00grdDetailItemInfo;
import nta.med.data.model.ihis.bass.LoadDepartmentTypeInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdCSC0108Info;
import nta.med.data.model.ihis.inps.INP1003U01cboEmergencyInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02LayProtectGubunListInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetGroupKeyInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01PrintNameInfo;
import nta.med.data.model.ihis.ocso.GwaListItemInfo;
import nta.med.data.model.ihis.phys.PHY2001U04CboJubsuGubunInfo;
import nta.med.data.model.ihis.system.GetORCAEnvInfo;
import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0102RepositoryCustom {
	
	public List<ComboListItemInfo> getNuroReceptionTypeList(String language, String hospitalCode, String codeType, boolean isAll);
	
	public String getJapanDateInfo(String hospCode, String language, String naewonDate);
	
	public List<NuroOUT1101Q01PrintNameInfo> getNuroOUT1101Q01PrintNameInfo(String hospCode, String language);
	
	public List<ComboListItemInfo> getOcsaComboListItemInfo(String hospCode, String language);
	
	public List<ComboListItemInfo> getOcsoOUTSANGU00FindWorker(String hospCode, String language,String sangEndSayU );
	
	public List<GwaListItemInfo> getGwaListItemInfo(String hospCode,String outJubsuyn);
	
	public List<ComboListItemInfo> getComboListItemInfoByCodeType(String hospCode, String language,String codeType);
	
	public List<TripleListItemInfo> getByCodeTypeList(String language,
			String hospitalCode, List<String> codeType, boolean isAll);
	
	public List<BAS0101U00grdDetailItemInfo> listBAS0101U00GrdDetail(String hosoCode,String codeType, String language);
	
	public List<ComboListItemInfo> getCht0115Q01xEditGridCell10ListItem(String hospCode, String codeType, String language);
	
	public List<ComboListItemInfo> getCht0115Q01cboDetailGubunListItem(String hospCode, String codeType, String language,String code99AndOrderBy);

	public List<BAS0101U00GrdDetailListItemInfo> getBAS0101U00GrdDetailListItem(String hospCode, String codeType, String language);
	
	public String getBas0101U00TransactionDeleteChk(String hospCode, String codeType,String language);
	
	public List<ComboListItemInfo> getBAS0001U00CboHospJinGubun(String hospCode,String language);
	public List<ComboListItemInfo> getBAS0001U00FbxDodobuHyeunFindClick(String hospCode,String language,String codeType,String find);
	public List<ComboListItemInfo> getBAS0001U00FbxDodobuHyeunDataValidating(String hospCode,String language,String codeType,String code);
	public List<BAS0001U00grdDetailItemInfo> getBAS0001U00grdDetailItemInfo(String hospCode,String language,String codeType);
	public List<ComboListItemInfo> getBAS0210U00grdBAS0210GridColumnChanged(String hospCode,String language,String code);
	public List<ComboListItemInfo> getBAS0210U00fwkCommon(String hospCode,String language,String find);
	public List<ComboListItemInfo> getOUT0101Q01CboSex(String hospCode,String language);
	public List<ComboListItemInfo> getComboJubsuGubun(String hospCode,String language, boolean orderBySortKey);
	
	public String getOcsoOCS1003P01GetGroupKey(String hospCode, String language, String pkout1001, String codeType);
	public String callFnBasLoadCodeName(String codeType, String code, String hospCode, String language);
	public List<ComboListItemInfo> getCHT0115Q00LayoutCommon(String hospCode,String language);
	public List<ComboListItemInfo> getCodeNameListItem (String hospCode, String codeType, String order, String language);
	public List<ComboListItemInfo> getAdmMsgListItem(String hospCode, String language, String codeType);
	
	public List<ComboListItemInfo> getEditGridOcs0131ListItem(String hospCode, String codeType, String language);
	public List<ComboListItemInfo> getAdmMesgListItemInfo (String language, String hospCode, String codeType);
	public List<ComboListItemInfo> getCodeCodeNameListItemInfo(String hospCode, String language, String codeType);
	public List<ComboListItemInfo> getCodeCodeNameWhereFind1Item (String hospCode, String codeType, String find1, boolean isTwo, String language);
	public List<ComboListItemInfo> getCodeNameSortKeyListItem (String hospCode, String language, String codeType, String fCode);

	public List<BAS0101U04GrdDetailInfo> getBAS0101U04GrdDetailInfo(String hospCode, String codeType, String language);
	public List<BAS0101U04GrdDetailInfo> getBAS0101U04GrdDetailInfoIgnoreLanguage(String hospCode, String codeType);
	public List<PHY2001U04CboJubsuGubunInfo> getPHY2001U04CboJubsuGubunInfo(String hospCode, String language);
	public List<NuroOUT0101U02LayProtectGubunListInfo> getNuroOUT0101U02LayProtectGubunListInfo(String hospCode, String language, String codeType, String find1);

	public List<NuroOUT1001U01GetGroupKeyInfo> getNuroOUT1001U01GetGroupKeyInfo(String hospCode, String language, String codeType, String code);
	
	public List<ComboListItemInfo> getCLIS2015U02CboStatus(String hospCode, String language, String codeType, boolean isAll);
	public String getCodeByCodeTypeAndCodeName(String hospCode, String codeType, String language, String codeName);

	public String getCodeUsingORCA(String hospCode, String language);

	public List<GetORCAEnvInfo> getORCAEnvInfo(String hospCode, String language);
	
	public List<ComboListItemInfo> getINV0101ComboListItemInfo(String hospCode);
	
	public List<LoadDepartmentTypeInfo> getDepartmentTypeInfo(String hospCode, String codeType, String language);
	
	public List<INP1003U01cboEmergencyInfo> getINP1003U01cboEmergencyInfo(String hospCode);
	public List<INP1003U00grdCSC0108Info> getINP1003U00grdCSC0108(String hospCode, String categoryGubun);

	public List<ComboListItemInfo> getByCodeTypeContainNull(String hospCode, String codeType, String language);

	public List<ComboListItemInfo> getNUR1001R09cboWingGubun(String hospCode, String language, String codeType);

}

