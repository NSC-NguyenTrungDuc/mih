package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0301Q09GrdOCS0303Info;
import nta.med.data.model.ihis.ocsa.OCS0301U00LayoutInfo;
import nta.med.data.model.ihis.ocsa.OCS0307U00GrdListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0303RepositoryCustom {
	public List<OCS0301U00LayoutInfo> getOCS0301U00LayoutInfo(String hospitalCode, String language, String memb, Double fkocs0300Seq, String yaksokCode);
	public List<OCS0301Q09GrdOCS0303Info> getOCS0301Q09GrdOCS0303(String hospCode, String language, String genericYn,
			String memb, Double fkocs0300Seq, String yaksokCode, String protocolId);
	public List<OCS0307U00GrdListItemInfo> getComboList0307Info(String hospCode, String userId, String pkocs0300Seq, String yaksokCode);
}

