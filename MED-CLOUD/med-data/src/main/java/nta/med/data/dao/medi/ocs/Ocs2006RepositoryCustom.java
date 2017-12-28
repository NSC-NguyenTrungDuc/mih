package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsi.OCS6010U10PopupDAgrdOCS2006Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdOCS2006Info;

/**
 * @author dainguyen.
 */
public interface Ocs2006RepositoryCustom {

	public Double getNextSeqByHospCodePkOcs2005(String hospCode, Double fkocs2005);
	
	public List<OCS6010U10PopupTAgrdOCS2006Info> getOCS6010U10PopupTAgrdOCS2006Info(String hospCode, String orderDate, String fkocs2005, String pkSeq);
	
	public String getOCS6010U10frmARActingSuryang(String hospCode, String fkocs2005);

	public List<OCS6010U10PopupDAgrdOCS2006Info> getOCS6010U10PopupDAgrdOCS2006(String hospCode, String fkocs2005, String orderDate, String pkSeq);
}
