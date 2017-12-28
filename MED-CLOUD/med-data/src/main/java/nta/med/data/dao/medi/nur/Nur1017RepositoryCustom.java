package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1017Info;
import nta.med.data.model.ihis.nuri.NUR1017U00GrdNUR1017ListItemInfo;
import nta.med.data.model.ihis.nuri.NuriNUR1017U00ManageInfectionInfo;

/**
 * @author dainguyen.
 */
public interface Nur1017RepositoryCustom {
	
	public List<NuriNUR1017U00ManageInfectionInfo> getNuriNUR1017U00ManageInfectionInfo(String hospCode, String bunho);
	
	public String getNuriNUR1017U00GetY(String hospCode, String infeCode, String bunho, String startDate);
	
	public String getNuriNUR1017U00GetCodeName(String hospCode, String codeType, String infeCode, String language);
	
	public String callNuriPrNurInfeMapping(String hospCode, String bunho, String InfeCode, String tableId, String userId,String language, String oFlag);
	
	public List<NUR1017U00GrdNUR1017ListItemInfo> getNUR1017U00GrdNUR1017ListItem(String hospCode, String bunho);
	
	public String getNUR1017U00LayValidationDupchk(String hospCode, String infeCode, String bunho, String startDate);
	
	public String getNUR1017PatientInfection(String hospCode, String bunho);

	public List<NUR1001U00GrdNUR1017Info> getNUR1001U00GrdNUR1017Info(String hospCode, String language, String bunho, Integer startNum, Integer offset);
}

