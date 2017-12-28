package nta.med.data.dao.medi.inj;

import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.injs.INJ0000Q00layActDateInfo;
import nta.med.data.model.ihis.injs.INJ0000Q00layActingInfo;
import nta.med.data.model.ihis.injs.INJ0000Q00layOrderInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01MasterListItemInfo;
import nta.med.data.model.ihis.ocso.OCSACT2GetPatientListINJInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdListInfo;

/**
 * @author dainguyen.
 */
public interface Inj1001RepositoryCustom {
	public List<InjsINJ1001U01MasterListItemInfo> getInjsINJ1001U01MasterListItemInfo(String hospitalCode, String gwa, String reserDate, String actingFlg);
	
	public List<Timestamp> getInjsINJ1001U01OrderDateList(String hospitalCode, String pkinj1002);
	public List<PHY2001U04GrdListInfo> getPHY2001U04GrdListInfo(String hospCode, String language, String bunho, String statFlg,
			Date naewonDate, String gwa, String doctor, String gubun);
	public List<Timestamp> getSCH0201U10GrdReser(String hospCode, String bunho);
	public List<OCSACT2GetPatientListINJInfo> getOCSACT2GetPatientListINJInfo(String hospitalCode, String language, String gwa, String reserDate, String actingFlg);
	public List<INJ0000Q00layActDateInfo> getINJ0000Q00layActDateInfo(String hospCode, String language, String bunho, String messageGubun);
	public List<INJ0000Q00layActingInfo> getINJ0000Q00layActingInfo(String hospCode, String language, String bunho, String messageGubun);
	public List<INJ0000Q00layOrderInfo> getINJ0000Q00layOrderInfo(String hospCode, String language, String bunho, String gubun, String messageGubun);
	public List<INJ0000Q00layActDateInfo> getINJ0000Q00layOrderListInfo(String hospCode, String language, String bunho, String gubun, String messageGubun);
}

