package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAgrdOCS2016Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupILgrdOCS2016Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdOCS2016Info;

/**
 * @author dainguyen.
 */
public interface Ocs2016RepositoryCustom {
	
	public String getOCS6010U10CreatePopupMenuYn(String hospCode, Double fkocs2003);
	
	public List<OCS6010U10PopupTAgrdOCS2016Info> getOCS6010U10PopupTAgrdOCS2016Info(String hospCode, String fkocs2015, Integer startNum, Integer offset);
	
	public Double getMaxSeqOCS6010U10(String hospCode, String fkocs2015);

	public String getOCS6010U10frmARActingSeqOCS2016(String hospCode, Double fkocs2015);
	
	public List<OCS6010U10PopupILgrdOCS2016Info> getOCS6010U10PopupILgrdOCS2016Info(String hospCode, String bunho, String limit7);
	
	public List<OCS6010U10PopupIAgrdOCS2016Info> getOCS6010U10PopupIAgrdOCS2016(String hospCode, String fkocs2015, String offset, String pageNumber);
	
	public String getOrdDanui(String hospCode, String hangmogCode, Date orderDate);
	
	public String getOrdDanuiName(String hospCode, String ordDanui);
}

