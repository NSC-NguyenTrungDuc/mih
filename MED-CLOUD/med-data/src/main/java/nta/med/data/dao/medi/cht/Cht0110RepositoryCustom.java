package nta.med.data.dao.medi.cht;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.chts.CHT0110Q01GrdCHT0110MListInfo;
import nta.med.data.model.ihis.chts.CHT0110U00grdCHT0110ItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00SangCodeListInfo;

/**
 * @author dainguyen.
 */
public interface Cht0110RepositoryCustom {
	
	public String getSangName(String hospCode, String code);
	
	public String getGwaName(String hospCode, String languge, String code);
	
	public String getDoctorName(String hospCode, String code);

	public List<OcsaOCS0204U00SangCodeListInfo> getOcsaOCS0204U00SangCodeListOcsaOCS0204U00FindWorkerList(String hospCode);
	public List<CHT0110U00grdCHT0110ItemInfo> getCHT0110U00grdCHT0110ItemInfo(String hospCode,String sangInx,Integer startNum, Integer offset);
    public String getCHT0110U00TChk (String hospCode, String sangCode);
    
    public List<ComboListItemInfo> getOcsoLoadCht0110(String sangCode, String gijunDate);
    
    public String getLoadColumnCodeNameSangCodeCase(String sangCode, String orderDate, String hospCode);
    public List<CHT0110Q01GrdCHT0110MListInfo>  getCHT0110Q01GrdCHT0110MListInfo(String hospCode, String ioGubun,
    		String userId,String sangInx,Date date);
    
    public String callPrAdmUpdateMasterSang(String hospCode, String userId);
    public String callPrCht0110U00UpdateMasterData(String hospCode);
}

