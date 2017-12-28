package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.bas.Bas0250;
import nta.med.data.model.ihis.bass.BAS0250U00GrdHoCodeListInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR2004U00layValidCheckHocodeInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0250RepositoryCustom {

	public List<ComboListItemInfo> getHocodeHodongItemInfo(String hospCode, Date hoCodeYmd, String hoDong, String hoCode);
	
	public String getBAS0250U00FbxHoGradeValidating(String hospCode, String hoGrade, String hoGradeYmd);
	
	public List<BAS0250U00GrdHoCodeListInfo> getBAS0250U00GrdHoCodeListInfoList(String hospCode, String language, String jukyongDate, String hoDong, Integer startNum, Integer offset);
	
	public Integer updateTableBas0250(String hospCode,String updId,String startDate,String hoCode,String hoDong);
	
	public Integer updateTableBas0250CaseDelete(String hospCode, String updId, String startDate, String hoCode, String hoDong);
	
	public List<String> getINP2004Q00grdHoCodeListInfo(String hospCode, String hoDong, String jukyongDate);
	
	public List<Bas0250> findByHoCodeHoDongFDate(String hospCode, String hoCode, String hoDong, String ipwonDate);
	
	public String checkHospitalBedIsPossible(String hospCode, String hoCode, String bedNo, String hoDong, String ipwonDate);
	
	public List<ComboListItemInfo> getINP1003U00grdInpReserGridColumnChangeddtHoSil(String hospCode, String hoCodeYmd, String hoDong, String hoCode);
	
	public List<ComboListItemInfo> getNUR2004U00layHoSex(String hospCode, String hoCode, String hoDong, Date date);
	
	public List<ComboListItemInfo> getNUR2004U00cboToKaikei(String hospCode, String kaikeiHodong);
	
	public List<ComboListItemInfo> getComboListItemInfo(String hospCode, String date, String hoDong);
	
	public List<NUR2004U00layValidCheckHocodeInfo> getNUR2004U00layValidCheckHocode(String hospCode, String hoDong, String code, String date);
	public List<DataStringListItemInfo> getNUR2004U00getHograde(String hospCode, String toHoDong1, String toHoCode1, String junpyoDate);
	public String getHoTotalBedByHospCodeHoCode(String hospCode, String hoCode);
}

