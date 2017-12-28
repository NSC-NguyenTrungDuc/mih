package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.data.model.ihis.system.LoadSearchOrderInfo;
import nta.med.data.model.ihis.xrts.XRT0122Q00GrdDCodeListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0122U00GrdDcodeInfo;
import nta.med.data.model.ihis.xrts.XRT0123U00GrdDCodeItemInfo;

/**
 * @author dainguyen.
 */
public interface Xrt0122RepositoryCustom {
	public String getXRT0001U00FbxDataValidatingSelectXRT0122(String hopsCode,String language,String code,String kaikeiYn);
	public List<XRT0123U00GrdDCodeItemInfo> getXRT0123U00GrdDCodeItemInfo(String hopsCode,String language,String xrayGubun, String buwiCode);
	
	public List<XRT0122U00GrdDcodeInfo> getXRT0122U00grdDCodeInitInfo(String hospCode, String buwiBunryu, String buwiCode, String buwiName, String flag,String language );
	
	public String getXRT0122U00layDupD(String hospCode, String language, String buwiBunryu, String buwiCode);
	
	public List<String> getXrt0121Loop(String hospCode, String buwiBunryu, String language);
	
	public List<LoadSearchOrderInfo> getOcsLibOrderBizLoadSearchOrderListItemInfo(String searchWord, String hospCode, String gijiunDate, String wonnaeDrgYn, String inputTab, String language
			, Integer startNum, Integer endNum, String protocolId);
	
	public List<XRT0122Q00GrdDCodeListItemInfo> getXRT0122Q00GrdDCodeListItemInfo(String hospCode, String language, String buwiBunryu, String flag, String buwiCode, String buwiName);
	
	public List<LoadSearchOrderInfo> getLoadSearchCommonOrder(String searchWord, String hospCode, String gijunDate, String wonnaeDrgYn, String inputTab, String language
			, Integer startNum, Integer endNum, String protocolId, String jundalTableOut);
}

