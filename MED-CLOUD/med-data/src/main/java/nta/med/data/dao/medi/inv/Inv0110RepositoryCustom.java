package nta.med.data.dao.medi.inv;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drug.DRGOCSCHKGrdOcsChkFullInfo;
import nta.med.data.model.ihis.drug.DRGOCSCHKGrdOcsChkInfo;
import nta.med.data.model.ihis.invs.*;
import nta.med.data.model.ihis.ocsa.OCS0103U00LayCommonJaeryoCodeInfo;

import java.util.Date;
import java.util.List;

/**
 * @author dainguyen.
 */
public interface Inv0110RepositoryCustom {
	public String getInjsINJ1001U01ChkbState(String hospCode, Date reserDate, String actingFlag, String bunho, String doctor);
	
	public List<DRGOCSCHKGrdOcsChkInfo> getDRGOCSCHKGrdOcsChkInfo(String hospCode, String jaeryoCode, String jaeryoName, String preSmallCode, 
			String smallCode, String drgPackYn, String phamarcyYn, String powderYn, String hubalYn, String mayakYn, String beforeUseYn, Integer pageNumber, String language);
	
	public String getLoadColumnCodeNameJaeryoCodeCase(String code, String hospCode);
	public List<OCS0103U00LayCommonJaeryoCodeInfo> getOCS0103U00LayCommonJaeryoCodeInfo(String hospCode, String jaeryoCode);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String find);
	public List<INV6000U00LaySummaryMasterInfo> getINV6000U00LaySummaryMasterInfo(String hospCode, String language, String magamMonth);
	
	public List<INV6002U00GrdINV6002BeforeInfo> getINV6002U00GrdINV6002BeforeInfo(String hospCode, String month, String jaeryoGubun, String language, Integer startNum, Integer endNum);
	public List<INV6002U00GrdINV6002AfterInfo> getINV6002U00GrdINV6002AfterInfo(String hospCode, String month, String jaeryoGubun, String language, Integer startNum, Integer endNum);
	public List<LoadINV0110Q00Info> getINV0110Q00Info(String hospCode, String searchWord, String language, Integer startNum, Integer offset);
	public List<CheckRemainingInventoryInfo> checkRemainingInventory(String hospCode, List<String> hangmogCode);
	
	public String checkInvenByHangmogCode(String hospCode, String jaeryoCode);
	public String findJaeryoCode(String hospCode, String hangmogCode);
	
	public List<INV6000U00ExportCSVInfo> getINV6000U00ExportCSVInfo(String hospCode, String language, Date fromDate, Date toDate);
	
	public List<INV6002U00GrdINV6002Info> getINV6002U00GrdINV6002Info(String hospCode, String language, String gubun, String jaeryoGubun, String month, Integer startNum, Integer endNum, String jaeryoCode);
	
	public boolean isExistedINV0110(String hospCode, String jaeryoCode);
	
	public List<DRGOCSCHKGrdOcsChkFullInfo> getDRGOCSCHKGrdOcsChkFullInfo(String hospCode, String language, String jaeryoCode, String jaeryoName, String preSmallCode, String smallCode,
																			String drgPackYn, String phamarcyYn, String powderYn, String hubalYn,
																			String mayakYn, String stockYn, String beforeUseYn, String wonnaeDrgYn,
																			 String jaeryoGubun, Integer pageNumber, Integer offset);
}

