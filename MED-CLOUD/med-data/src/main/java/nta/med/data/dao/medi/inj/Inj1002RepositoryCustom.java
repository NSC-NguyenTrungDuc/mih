package nta.med.data.dao.medi.inj;

import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.injs.INJ1002R01LayQueryListItemInfo;
import nta.med.data.model.ihis.injs.INJ1002U01GrdOrderListItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01DetailListItemInfo;

/**
 * @author dainguyen.
 */
public interface Inj1002RepositoryCustom {

	public List<InjsINJ1001U01DetailListItemInfo> getInjsINJ1001U01DetailListItemInfo(String hospitalCode, String language, 
			String bunho, String gwa, String doctor, String reserDate, String actingDate,
			String actingFlg);
	
	public List<Timestamp> getInjsINJ1001U01ReserDateList(String hospitalCode, String bunho, String doctor, Date reserDate, String actingFlg);
	
	public List<Double> getFkocs1003(String hospCode, String pkinj1002);
	
	public List<INJ1002R01LayQueryListItemInfo> INJ1002R01LayQuery1(String hospCode, String language, String fromDate, String toDate);
	
	public List<INJ1002R01LayQueryListItemInfo> INJ1002R01LayQuery2(String hospCode, String language, String fromDate, String toDate);
	
	public List<INJ1002U01GrdOrderListItemInfo> getINJ1002U01Initialize(String hospCode, String language, String bunho, String reserDate);
	
	public List<String> getINJ1002U01InitializeReserDate(String hospCode, String bunho);
}

