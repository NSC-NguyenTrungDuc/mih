package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.BAS0110BAS0110Q00GrdInfo;
import nta.med.data.model.ihis.bass.BAS0110U00GrdJohapListItemInfo;
import nta.med.data.model.ihis.bass.BAS0111U00GrdMasterItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetJohapInfo;



/**
 * @author dainguyen.
 */
public interface Bas0110RepositoryCustom {
	
	public List<BAS0110U00GrdJohapListItemInfo> getBAS0110U00GrdJohapListItem(String johapGubun, String johap, String startDate, String language);
	
	public String getBas0110U00LayDupChk(String gubun, Date startDate, String johap, String language);
	public List<BAS0110BAS0110Q00GrdInfo> getBAS0110BAS0110Q00GrdInfo(String hospCode, String language, String johapGubun,
			String searchGubun, String searchWord);
	public List<BAS0111U00GrdMasterItemInfo> getBAS0111U00GrdMasterItemInfo(String johapGubun, String johap, String naewonDate, String language);
	public List<String> getJohapNameByJohapAndStartDate(String johap, String startDate, String language);
	
	public List<NuroOUT0101U02GetJohapInfo> getNuroOUT0101U02GetJohapInfo(String johap, Date date, String language);
}
	

