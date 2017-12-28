package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.bass.HoGradeInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0251RepositoryCustom {
	
	public List<HoGradeInfo> getHoGradeInfo(String hospCode, String find1, String startDate);
	
	public List<ComboListItemInfo> getNUR2004U00cboFromToHoGrade(String hospCode);
	
	public List<ComboListItemInfo> getNUR2004U00fbxToGwa(String hospCode, String date, String find1);
	
}
