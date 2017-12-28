package nta.med.data.dao.medi.cpl;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0001U00GrdSlipInfo;

/**
 * @author dainguyen.
 */
public interface Cpl0001RepositoryCustom {
	
	public String getCPL0101U00FbxSlipCodeName(String hospCode, String code);
	
	public List<ComboListItemInfo> getCPL0101U00FbxSlipCodeComboListItem(String hospCode, String find1, String find2, String language);
	
	public List<CPL0001U00GrdSlipInfo> getCPL0001U00GrdSlipInfo(String hospCode, String slipCode);
	
	public String callPrCplBmlUploader(String hospCode, String language, String userId, String groupGubun, String parentCode, String hangmogCode, 
			Integer serial, String gumsaNameRe, String gumsaName, String jlac10Code, String tubeName, String keepMeansName, String specimenCode, 
			String specimenName, String danui, String menFromStandard, String menToStandard, String womenFromStandard, String womenToStandard,
			String sgCode1, String sgCode2, String specimenAmt, Date jukyongDate,String detailInfo, String hangmogMarkName, String emergency);
	
}

