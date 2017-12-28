package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layNUR1122Info;
import nta.med.data.model.ihis.nuri.NUR1020U00grdNUR1122Info;

/**
 * @author dainguyen.
 */
public interface Nur1122RepositoryCustom {

	public List<NUR1020U00grdNUR1122Info> getNUR1020U00grdNUR1122Info(String hospCode, String bunho, Double fkinp1001,
			String ymd, String prevqryFlag);
	
	public String getNUR1020U00MaxYmd(String hospCode, String bunho, String ymd);
	
	public List<NUR1020Q00layNUR1122Info> getNUR1020Q00layNUR1122Info(String hospCode, String bunho, Double fkinp1001,
			String ymd);
	
	public List<ComboListItemInfo> getNUR1020Q00layNUR1122List(String hospCode, String bunho, Double fkinp1001, String ymd);
}
