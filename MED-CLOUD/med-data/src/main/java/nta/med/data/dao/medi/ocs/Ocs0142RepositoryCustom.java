package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.OcsLoadInputTabListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U11LaySlipCodeTreeInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U17GrdJaeryoOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U19TvwJaeryoGubunInfo;
import nta.med.data.model.ihis.system.LoadOftenUsedTabResponseInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0142RepositoryCustom {
	
	public List<OcsLoadInputTabListItemInfo> getOcslibTabListItem(String hospCode, String inputTab);
	public List<LoadOftenUsedTabResponseInfo> getLoadOftenUsedTabInfoElse(String hospCode,String language,String memb);
	public List<LoadOftenUsedTabResponseInfo> getLoadOftenUsedTabInfo(String hospCode,String language,String memb,String inputTab);
	
	public List<ComboListItemInfo> getOCS0103U17MakeJaeryoGubunTabListItem(String hospCode, String inputTab, String codeType);
	
	public List<OCS0103U17GrdJaeryoOrderInfo> getOCS0103U17LoadJaeryoOrderListItem(String hospCode, String mode, String orderGubun,
			String searchWord, String orderDate, String wonnaeDrgYn, String inputTab, boolean gubun, String protocolId, Integer pageNumber, Integer offset, String slipCode, String language);
	
	public List<OCS0103U11LaySlipCodeTreeInfo> getOCS0103U11LaySlipCodeTreeListItem(String hospCode, String language);
	
	public List<ComboListItemInfo> getOCS0103U19InitializeScreenComboListItem(String hospCode, String inputTab, String mainYn, String inputControl, String language);
	
	public List<OCS0103U19TvwJaeryoGubunInfo> getOCS0103U19InitializeScreenTvwJaeryoGubunItem(String hospCode, String inputTab, String language);
	
}

