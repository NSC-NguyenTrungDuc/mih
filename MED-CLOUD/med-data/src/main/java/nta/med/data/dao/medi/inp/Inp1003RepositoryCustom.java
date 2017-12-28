package nta.med.data.dao.medi.inp;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.BAS0250Q00layReserBedInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INP1003Q00grdINP1003Info;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangeddtReserInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserInfo;
import nta.med.data.model.ihis.inps.INP1003U01grdINP1003Info;
import nta.med.data.model.ihis.inps.INP1003U01layDeleteInfo;
import nta.med.data.model.ihis.inps.INP1003U01layIpWonInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.system.PrOcsLoadIpwonReserInfo;

/**
 * @author dainguyen.
 */
public interface Inp1003RepositoryCustom {
	public PrOcsLoadIpwonReserInfo getPrOcsLoadIpwonReserInfo(String hospCode, String language, Date reserDate, Double naewonKey);
	
	public String getAbleInsteadOrder(String hospCode, String bunho, Date naewonDate);
	
	public String getYInfo(String hospCode, String bunho);
	
	public String getYInfoWhereReserDate(String hospCode, String bunho, Date reserDate);
	
	public String getYWherePkinp1003 (String hospCode, String bunho, Date reserDate, double pkinp1003);
	
	public List<INP1003Q00grdINP1003Info> getINP1003Q00grdINP1003Info(String hospCode, String language, String reserEndType, String reserDate
			, String hoDong, Integer offset, Integer startNum);
	
	public String checkExistOrderInp1003ByHospCodeBunho(String hospCode, String bunho);
	
	public List<INP1003U01grdINP1003Info> getINP1003U01grdINP1003Info(String hospCode, String bunho, String language, Integer offset, Integer startNum);
	
	public Integer updateINP1003U01CancelReser(String hospCode, Double pkinp1003, String ipwonsiOrderYn);

	public String getExsitINP1003U01SaveLayout(String hospCode, String bunho);

	public void prOcsInitCreateSiksa(String hospCode, Double pkinp1001, String bunho, String inpwonDate, String gubun, String language);

	public String checkExistReser(String hospCode, Double pkinp1003, Date reserDate);

	public Integer Inp1003U01UpdateInp1003(String userId, Double reserFkinp1001, String remark, String sangBigo,
			String emerGugun, String emerDetail, String hospCode, Double pkinp1003);

	public Integer Inp1003U01UpdateReserEndDate(String hospCode, Double pkinp1003);

	public Integer Inp1003UpdateInp1003(String userId, String doctor, String remark, String jisiDoctor, String sangBigo,
			String hoDong, String hoCode, String bedNo, String emerGubun, String emerDetail, String hospCode, Double pkinp1003);

	public ComboListItemInfo prcOcsAlterReserInpwonDate(String hospCode, String bunho, Double fkinp1001, Date reserDateOld,
			Date reserDate, String userId);

	public Integer Inp1003UpdateInp1003(String userId, String doctor, String gwa, Date reserDate, String remark,
			String jisiDoctor, String sangBigo, String hoDong, String hoCode, String bedNo, String emerGubun,
			String emerDetail, String hospCode, Double pkinp1003);

	public List<INP1003U01layDeleteInfo> getINP1003U01layDeleteInfo(String hospCode, Double pkinp1003);

	public List<INP1003U01layIpWonInfo> getINP1003U01layIpWonInfo(String hospCode, Double pkinp1003);

	public List<DataStringListItemInfo> prcINP1003U01Procedure(String hospCode, String bunho, String fkinp1001,
			Date ipwonDate, String gubun, String userId, String ipwonType, String nameControl);
	
	public List<INP1003U00grdInpReserInfo> getINP1003U00grdInpReser(String hospCode, String language, String reserDate, String hoDong);
	
	public List<INP1003U00grdInpReserGridColumnChangeddtReserInfo> getINP1003U00grdInpReserGridColumnChangeddtReserInfo(String hospCode, String bunho);
	
	public String getINP1003U00YByReserDate(String hospCode, String bunho, String reserDate);
	
	public String getINP1003U00YByReserEndType(String hospCode, String bunho, String reserDate, Double pkinp1003);
	
	public String inp1001U01CheckIsExist(String hospCode, String bunho);
	public List<BAS0250Q00layReserBedInfo> getBAS0250Q00layReserBedInfoList(String hospCode, String hoDong);
	public List<DataStringListItemInfo> OCS2005U02getReserFkInp1001(String hospCode, String bunho, String reserEndType);

	public List<DataStringListItemInfo> OCS2005U02getReserDate(String hospCode, String bunho, String reserEndType);

	public ComboListItemInfo prcINP1003U01ProcedureDelete(String hospCode, String bunho, String fkinp1001, Date ipwonDate,
			String gubun, String userId, String ipwonType, String nameControl);

	public List<ComboListItemInfo> getNUR1001U00LayReserInfo(String hospCode, String bunho);
}

