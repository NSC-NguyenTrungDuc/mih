package nta.med.data.dao.medi.cpl;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00LaySigeyulTempListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0106U00FwkGumsaListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0106U00GrdGroupListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U01GrdPaInfo;
import nta.med.data.model.ihis.cpls.CPL3010U01LayPrint2Info;
import nta.med.data.model.ihis.cpls.CPL3010U01LaySpecimenInfo;
import nta.med.data.model.ihis.cpls.CPL3010U01PrePrintInfo;
import nta.med.data.model.ihis.cpls.CplCPL0104U00GrdMasterCPL0104ListItemInfo;
import nta.med.data.model.ihis.cpls.MultiResultViewGrdSigeyulInfo;

/**
 * @author dainguyen.
 */
public interface Cpl0101RepositoryCustom {
	List<CplCPL0104U00GrdMasterCPL0104ListItemInfo> getCPL0104U00GrdMaster(String hospCode,String hangmogCode,String specimenCode,String emergency,String gumsaName,
			Integer startNum, Integer endNum);
	
	List<CPL0106U00FwkGumsaListItemInfo> getCPL0106U00FwkGumsaListItemInfo(String hospCode, String language, String find1, boolean isLike);
	
	List<CPL0106U00GrdGroupListItemInfo> getCPL0106U00GrdGroupListItemInfo(String hospCode, String language, String hangmogCode,
			String gumsaName);

	String getCPL3010U00InitializeYValue(String hospCode, String specimenSer);
	
	List<CPL0000Q00LaySigeyulTempListItemInfo> getCPL0000Q00LaySigeyulTempListItemInfo(String hospCode, String groupHangmog,
			String specimenCode, String hangmogCode, String language);
	
	public String getCPL0101U00FbxHangmogCodeName(String hospCode, String code);
	
	public List<ComboListItemInfo> getCPL0101U00FbxHangmogCodeComboListItem(String hospCode, String find1, String find2);
	
	public String getCPL0101U00CheckHangmogCopy(String hospCode, String hangmogCode, String specimenCode, String emergency);
	
	public String callPrCplCopyCpl0101(String hospCode, String hangmogCode, String specimenCode, String emergency, String newSpecimenCode, String newEmergency,String o_err);
	
	public  List<CPL3010U01LaySpecimenInfo> getCPL3010U01LaySpecimenInfoListItemInfo(String hospCode,String language,String specimenSer);
	public List<CPL3010U01LayPrint2Info> getCplsCPL3010U01LayPrint2ListItemInfo(String hospCode,String language,String fromPartJubsuDate,String fromSeq,String toPartJubsuDate,String toSed);
	public List<CPL3010U01LayPrint2Info> getCplsCPL3010U01LayPrint2ListItemInfo2(String hospCode,String language,String fromSpecimenSer,String toSpecimenSer);
	public List<CPL3010U01PrePrintInfo> getCPL3010U01BtnPrePrintClickCPL3010ListItemInfo(String hospCode, String language, List<String> iraiStr, String uitakCode);
	public List<CPL3010U01GrdPaInfo> getCplsCPL3010U01GrdPaCPL3010ListItemInfo(String centerCode, String uitakCode, String hospCode,String  fromPartJubsuDate,String toPartJubsuDate,String fromSeq,String toSeq,
			String fromSpecimenSer,String toSpecimenSer,boolean isTrue);

	public String callPrCplNumStandardCheck(String result, String fromStandard, String toStandard, String ioStandard);
	
	public String callPrCplPanicChk(String hospCode, String bunho, Date orderDate,String gumsaCode, String specimenCode, String emergency, String result, String ioPanicYn );
	
	public String callFnCplLoadDupGrdHangmog(String hospCode, String language, String newHangmogCode, String newSpecimenCode, String oldHangmogCode, String oldSpecimenCode);
	
	public List<MultiResultViewGrdSigeyulInfo> getMultiResultViewGrdSigeyul2(String hospCode, String bunho, String groupHangmog);
	
	public List<MultiResultViewGrdSigeyulInfo> getMultiResultViewGrdSigeyul1(String hospCode, String bunho, String groupHangmog);

	public String callPrCpl0101U00UpdateMasterData(String hospCode);

	boolean isExistedCpl0101(String hospCode, String hangmogCode, String specimenCode, String emergency);
	public List<ComboListItemInfo> getCPL0000Q01fwkHangmogCode(String hospCode, String find1, String find2);
	
	public String callFnCplLoadDupHangmog(String hospCode, String language, String ioGubun, String bunho, String hangmogCode, String specimenCode, Date checkDate);
}

