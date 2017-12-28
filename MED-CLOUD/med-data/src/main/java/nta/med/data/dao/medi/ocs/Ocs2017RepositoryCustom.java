package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuri.NUR2017U01grdNUR2017Info;
import nta.med.data.model.ihis.nuri.NUR2017U01grdPalistInfo;
import nta.med.data.model.ihis.ocsi.NUR2017Q00grdNUR2017Info;

/**
 * @author dainguyen.
 */
public interface Ocs2017RepositoryCustom {
	public List<NUR2017Q00grdNUR2017Info> getNUR2017Q00grdNUR2017Info(String hospCode, String language, String bunho, String orderDate, String pkocs2003);
	public Integer updateOcs2017InOCS6010U10PopupDAbtnList(String hospCode, double fkocs2003, Date actResDate, String userId, String actUser, Date actingDate);

	public List<NUR2017U01grdNUR2017Info> getNUR2017U01grdNUR2017Info(String hospCode, String language,
			String orderGubun, String actResDate, String bunho, String bannabDel);
	
	public List<NUR2017U01grdPalistInfo> getNUR2017U01grdPalistInfo(String hospCode, String hoDong, String orderGubun,
			String actResDate, String fa, String fb, String fc, String fd, Integer startNum, Integer offset);
	
	public Integer updateOcs2017InNUR2017U01(String hospCode, String userId, String actingYn, String actingDate,
			String actingTime, String actUser, String passYn, Double fkocs2003, String actResDate, String hangmogCode, Double seq);
	
	public String callPrOcsiProcessBannab(String hospCode, String workGubun, Double pkocskey, Double seq, String userId);
}

