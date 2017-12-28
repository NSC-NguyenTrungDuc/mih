package nta.med.data.dao.medi.drg;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01BongtuInfo;
import nta.med.data.model.ihis.drug.DRG0120U00Grd0120Item2Info;
import nta.med.data.model.ihis.drug.DRG0120U00Grd0120Item3Info;
import nta.med.data.model.ihis.drug.DRG0120U00GrdDrg0120Item1Info;
import nta.med.data.model.ihis.drug.DRG0120U00GrdDrg0120ItemInfo;
import nta.med.data.model.ihis.emr.OCS2015U00DosageInfo;
import nta.med.data.model.ihis.ocsa.OCS0208Q00LayBanghyangInfo;
import nta.med.data.model.ihis.ocsa.OCS0208Q01GrdDrg0120Info;
import nta.med.data.model.ihis.system.CFFormUnevenPrescribeLayDRG0120Info;
import nta.med.data.model.ihis.system.OBGetBogyongByDvItemInfo;

/**
 * @author dainguyen.
 */
public interface Drg0120RepositoryCustom {
	
	public DrgsDRG5100P01BongtuInfo getDrgsDRG5100P01BongtuInfo(String hospCode, String language, String jubsuDate, 
			String actDate, String bogyongCode, String fkocs1003);
	
	public List<String> getBogyongNameOcsaOCS0208U00CommonData(String hospCode, String bogyongCode);
	
	public List<DRG0120U00GrdDrg0120ItemInfo> getDRG0120U00GrdDrg0120ItemInfo(String hospCode, String bunryu1, String language);
	
	public List<DRG0120U00Grd0120Item2Info> getDRG0120U00Grd0120Item2Info(String hospCode, String language);
	
	public List<DRG0120U00Grd0120Item3Info> getDRG0120U00Grd0120Item3Info(String hospCode, String language);
	public List<OBGetBogyongByDvItemInfo> getOBGetBogyongByDvItemInfo(String hospCode,String bogyongCode, String language);
	
	public String getLoadColumnCodeNameBogyongCodeCase(String code, String hospCode, String language);
	
	public List<ComboListItemInfo> getOcsLibBogyongInfo3(String bogyongCode, String hospCode, String bogyongGubun, String language);
	public List<OCS0208Q00LayBanghyangInfo> getOCS0208Q00LayBanghyangInfo(String hospCode,String bogyongCode, String language);
	public List<ComboListItemInfo> getOCS0208Q01GrdChiryoGubun(String hospCode,String language, String bogyongGubun,String jaeryoCode,String useYn);
	public List<OCS0208Q01GrdDrg0120Info> getOCS0208Q01GrdDrg0120Info(String hospCode, String language, String chiryoGubun,String banghyang,
			String fJaeryoCode,String useYn,String oJaeryoCode,String bogyongGubun);
	
	public List<DRG0120U00GrdDrg0120Item1Info> getDRG0120U00GrdDrg0120Item1ListItem(String hospCode, String bunryu, String language);
	public String getBogyongName(String hospCode, String bogyongCode, boolean isEqual6, String language);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, boolean isEqual6, String language);
	public List<CFFormUnevenPrescribeLayDRG0120Info> getCFFormUnevenPrescribeLayDRG0120(String hospCode, String bogyongCode, String language);
	
	public List<OCS2015U00DosageInfo> getOcs2015U00DosageInfo(String hospCode, String patientCode, String language);
	public String callFnDrgLoadBogyongName(String hospCode, String bogyongCode);
	public String callFnDrgLoadBogyongJusaName(String hospCode, String language, String orderGubun, String code);
	public List<ComboListItemInfo> getOCS2005U00fwkCombo(String hospCode, String find1);
	public List<ComboListItemInfo> getNUR0110U00SetFindWorkerCombo(String hospCode, String language, String find1, boolean bunryu1Eq6);
}

