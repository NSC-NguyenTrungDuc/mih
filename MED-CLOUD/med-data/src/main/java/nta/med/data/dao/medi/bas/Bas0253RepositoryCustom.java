package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.BAS0250Q00layBedStatusInfo;
import nta.med.data.model.ihis.bass.BAS0250U00GrdBAS0253Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0253RepositoryCustom {
	
	public List<BAS0250U00GrdBAS0253Info> getBAS0250U00GrdBAS0253InfoList(String hospCode, String hoDong, String hoCode, Integer startNum, Integer offset);
	
	public Integer updateTableBas0253(String hospCode, String updId, String fromBedDate, String hoCode, String hoDong, String bedNo);
	
	public Integer updateTableBas0253CaseDelete(String hospCode, String updId, String fromBedDate, String hoCode, String hoDong, String bedNo);
	
	public String checkExistByHospCodeHoDongHoCodeBedNoIpwonDate(String hospCode, String hoDong, String hoCode, String bedNo, String ipwonDate);
	
	public String inp1001U01CheckIsExist(String hospCode, String hoDong, String hoCode, String bedNo, Date silIpwonDate);
	
	public List<BAS0250Q00layBedStatusInfo> getBAS0250Q00layBedStatusInfoList(String hospCode, Date hoCodeYmd, String hoDong);
	
	public List<String> getBedNoNUR2004U01(String hospCode, String hoDong, String hoCode);
	
	public String getNUR2004U01GetSubConfirmData2(String hospCode, String hoDong, String hoCode, String bedNo);
	
	public List<ComboListItemInfo> getNUR2004U00layHocodeBednoRequest(String hospCode, String hoDong, String hoCode);
}

