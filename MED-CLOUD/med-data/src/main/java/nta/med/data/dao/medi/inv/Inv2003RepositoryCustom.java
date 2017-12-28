package nta.med.data.dao.medi.inv;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.invs.INV2003U00ExportCSVInfo;
import nta.med.data.model.ihis.invs.INV2003U00GrdINV2003Info;

public interface Inv2003RepositoryCustom {
	
	public List<INV2003U00GrdINV2003Info> getGridINV2003Info(String hospCode, Date fromDate, Date toDate, String chulgoType);
	public List<INV2003U00ExportCSVInfo> getINV2003U00ExportCSVInfo(String hospCode, Date fromDate, Date toDate, String language);

}
