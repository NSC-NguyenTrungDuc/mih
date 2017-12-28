package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0111Info;

/**
 * @author dainguyen.
 */
public interface Nur0111RepositoryCustom {

	public List<ComboListItemInfo> getOCS2005U02AutoMaSetCombo(String hospCode, String sikGubun);

	public String getSansoOrderCode(String hospCode, String directCode);

	public List<NUR0110U00GrdNUR0111Info> getNUR0110U00GrdNUR0111Info(String hospCode, String nurGrCode, Integer startNum, Integer offset);
}
