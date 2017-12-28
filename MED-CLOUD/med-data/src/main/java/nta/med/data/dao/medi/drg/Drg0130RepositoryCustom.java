package nta.med.data.dao.medi.drg;

import java.util.List;

import nta.med.data.model.ihis.drgs.DrgsDRG0130U00GrdDrg0130ListItemInfo;
import nta.med.data.model.ihis.drug.DrugComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Drg0130RepositoryCustom {
	
	public List<DrgsDRG0130U00GrdDrg0130ListItemInfo> getDrgsDRG0130U00GrdDrg0130ListItemInfo(String hospCode, String language, String cautionCode);
	
	public String getDrgsDRG0130U00CautionCode(String hospCode, String language, String cautionCode);
	
	public List<DrugComboListItemInfo> getDRGOCSCHKGetCautionList(String hospCode, String language);
}

