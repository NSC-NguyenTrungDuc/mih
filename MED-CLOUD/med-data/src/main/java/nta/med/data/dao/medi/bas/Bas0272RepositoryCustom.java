package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import org.springframework.data.repository.query.Param;

import nta.med.data.model.ihis.bass.BAS0270GrdBAS0272Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0272RepositoryCustom {
	public List<BAS0270GrdBAS0272Info > getBAS0270GrdBAS0272Info (String hospCode, String language, Date doctorYmd, String doctor);
	public List<ComboListItemInfo> getOFMakeGwaCombo(String hospCode,String language,String sabun);
	public List<ComboListItemInfo> getComboDoctorGwa(String hospCode,String language,String memb);
	
	public Integer deleteBas0272Bas(String hospCode, String sabun, String doctorGwa, String startDate); 
}

