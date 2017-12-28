package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.bas.Bas0250;
import nta.med.data.dao.medi.CacheRepository;
import nta.med.data.model.ihis.bass.BAS0250Q00grdHOBEDInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00SelectHosexInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00layBedListInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00layHosilListInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0250Repository extends Bas0250RepositoryCustom, CacheRepository<Bas0250>{
	
	public List<Bas0250> findByHoCodeHoDongStartDate(String hospCode, String hoCode, String hoDong, String startDate);
	
	public Integer deleteByHospCodeHoCodeHoDongStartDate(String hospCode, String hoCode, String hoDong, String startDate);
	
	public List<Bas0250> findByHospCodeHoDong(String hospCode, String hoDong);
	
	public String inp1001U00CheckExist(String hospCode, String hoDong, String hoCode, Date silIpwonDate);
	
	public String inp1001U01CheckBedIsPossible(String hospCode, String hoCode, String bedNo, String hoDong, Date silIpwonDate);
	
	public List<BAS0250Q00grdHOBEDInfo> getBAS0250Q00grdHOBEDInfoList(String hospCode, String hoDong, Date hoCodeYmd, String gumjinHodongYn);
	
	public List<DataStringListItemInfo> getBAS0250Q00layMaxBedNoInfoList(String hospCode, String hoDong,Date hoCodeYmd);
	
	public void callPrBas2050Refresh(String hospCode, String hoDong);

	public List<ComboListItemInfo> getNUR2004U00fbxToHoCode(String hospCode, String date, String hoDong);

	public List<NUR1010Q00layHosilListInfo> getNUR1010Q00layHosilListInfo(String hospCode, String hoDong);

	public List<NUR1010Q00layBedListInfo> getNUR1010Q00layBedListInfo(String hospCode, String hoDong);

	public List<ComboListItemInfo> getNUR1010Q00SelectMancnt(String hospCode, String hoDong);

	public List<NUR1010Q00SelectHosexInfo> getNUR1010Q00SelectHosexInfo(String hospCode, String hoDong);

	public List<String> getNUR1010Q00ChangeMoveHosilSelect2(String hospCode, String junpyoDate, String toHoCode, String toHoDong);

	public String checkNUR1010Q00isExistBas2050(String hospCode, String toHoCode, String toHoDong);
}

