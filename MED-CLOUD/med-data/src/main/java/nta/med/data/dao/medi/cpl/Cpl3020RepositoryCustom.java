package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect2ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00LaySubHangmogListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00GrdGumListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U01GrdHangmogInfo;
import nta.med.data.model.ihis.cpls.CPL3010U01GrdResultInfo;
import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl3020RepositoryCustom {
	
	public List<CPL3010U00GrdGumListItemInfo> getCPL3010U00GrdGumListItemInfo(String hospCode, String language, String specimenSer);
	public  List<CPL3010U01GrdHangmogInfo> getCPL3010U01GrdHangmogListItemInfo(String hospCode,String language,String requestKey);
	public  List<CPL3010U01GrdResultInfo> getCPL3010U01GrdResultListItemInfo(String hospCode,String language,String requestKey);
	public	List<CPL0000Q00LaySubHangmogListItemInfo> getCPL0000Q00LaySubHangmogListItemInfo(String hospCode, String bunho, String hangmogCode);
	
	public List<CPL0000Q00GetSigeyulDataSelect2ListItemInfo> getCPL0000Q00GetSigeyulDataSelect2(String hospCode, String bunho, String hangmogCode,
			String jubsuDate, String jubsuTime);
	
	public String callPrCplResultMatchProc(String proc_gubun,String hospCode, String specimenSer, String hangmogCode, String resultVal, String jangbiCode, String resultDate, String sampleId, String resultCode,String ioFlag);
	public Integer updateCPL3010U01(String hospCode,String language,String cplResult,String standartYn,
			String comment1,String comment2,String userId,String requestKey,String bmlCode);
	
	public void callPrCplAutoConfirmUpdate(String hospCode, String specimenSer, String gumsaja, String confirmYn);
	public List<TripleListItemInfo> getNUR6011U01GetGumsa(String hospCode, String language, String date, String bunho);
	
}

