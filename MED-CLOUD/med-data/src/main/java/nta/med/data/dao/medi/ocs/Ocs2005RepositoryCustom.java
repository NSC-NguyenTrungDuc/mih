package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2004U00DupCheckInfo;
import nta.med.data.model.ihis.ocsi.OCS2004U00layAllOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS2004U00layOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS2004U00layOCS2006Info;
import nta.med.data.model.ihis.ocsi.OCS2005U02SetTabInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02calSiksaDayClickInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02grdOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS2005U02layVWOCSOCS2005NUTInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAlayOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAlayOCS2006Info;

/**
 * @author dainguyen.
 */
public interface Ocs2005RepositoryCustom {
	public String callPrOcsCreateStopSiksa(String stopFromDate, String stopFromBld, String stopToDate, String stopToBld, String bunho, String hospCode, String fkinp1001, String updId, String commentGubun, String iudGubun, String ipwonDate);
	
	public List<OCS2005U02grdOCS2005Info> getOCS2005U02grdOCS2005Info(String hospCode, String jaewonYn, String bunho,
			Double fkinp1001, String blbGubun, Integer startNum, Integer offset);

	public List<OCS2005U02layVWOCSOCS2005NUTInfo> getOCS2005U02layVWOCSOCS2005NUTInfo(String hospCode, String bunho,
			Double fkinp1001, Integer startNum, Integer offset);

	public List<ComboListItemInfo> getOCS2005U02createHoDong(String hospCode, String language);

	public List<ComboListItemInfo> getOCS2005U02createHoCode(String hospCode, String language, String hoDong,
			String orderDate);
	public Double getOCS2005U00getPKSeq(String hospCode, String bunho, String fkinp1001, String orderDate);
	
	public String callFnOcsiGEetJisiOrderGubun(String hospCode, String nurGrCode, String nurMdCode);
	
	public List<OCS2004U00DupCheckInfo> getOCS2004U00DupCheck(String hospCode, String bunho, String fkinp1001, String inputGubun, String directGubun, String directCode, String fromDate, String toDate);
	
	public String getOCS2004U00setFromDate(String hospCode, String pkocs2005, String fkinp1001, String kijunDate, String directGubun, String directCode, String kijunTime);
	
	public String getOCS2004U00getPKSeq(String hospCode, String bunho, String fkinp1001, String orderDate, String tabinputGubun);
	
	public String getOCS2004U00setFromDate2(String hospCode, String fkinp1001, String kijunDate, String directGubun, String directCode, String kijunTime);
	
	public List<OCS2004U00layAllOCS2005Info> getOCS2004U00layAllOCS2005(String hospCode, String language, String bunho, String fkinp1001, String orderDate);
	
	public List<OCS2004U00layOCS2006Info> getOCS2004U00layOCS2006(String hospCode, String bunho, String fkinp1001, String orderDate, String pkSeq);
	
	public String executeFnOcsOcs2005DeleteYn(String hospCode, Date drtDate, String bldGubun);
	
	public Integer updateOcs2005InOCS6010U10SaveLayoutCase01(String hospCode, Double pkocs2005, String userId, String pickupUser);
	
	public Integer updateOcs2005InOCS6010U10SaveLayoutCase02(String hospCode, Double pkocs2005, String userId);
	
	public List<OCS2004U00layOCS2005Info> getOCS2004U00layOCS2005(String hospCode, String language, String bunho, String fkinp1001, String orderDate);
	

	public List<OCS2005U02SetTabInfo> getOCS2005U02SetTabInfo(String hospCode, String bunho, String jaewonYn, String bldGubun,	Double fkinp1001);

	public String getOCS2005U02IsNutCheckFromToDate(String hospCode, Date date, String bunho, String bldGubun, String pkocs2005, String fkinp1001);

	public List<ComboListItemInfo> OCS2005U02btnLoadOldComment(String hospCode, String bldGubun, Double fkinp1001);
	
	public String OCS2005U02ProcCreateSikjin(String fromDate, String fromBld, String bunho, String hospCode, Double fkinp1001,
			String updId, String commentGubun, Integer sikjinGubun, String iudGubun, String nomimono, String ipwonDate,
			String sikgubun1th, String sikjong1th, String jusik1th, String busik1th, String sikgubun2th,
			String sikjong2th, String jusik2th, String busik2th, String sikgubun3th, String sikjong3th, String jusik3th,
			String busik3th, String sikgubun4th, String sikjong4th, String jusik4th, String busik4th,
			String sikgubun5th, String sikjong5th, String jusik5th, String busik5th);

	public List<OCS2005U02calSiksaDayClickInfo> getOCS2005U02calSiksaDayClickInfo(String hospCode, String nutDate, Double fkinp1001);

	public String OCS2005U02ProcDailyNut(String updId, String hospCode, String bunho, String fkinp1001, String chargeDate,	String workGubun);
	
	public Double getNextSeqOcs2005Today(String hospCode, String bunho, Double fkinp1001);
	
	public List<OCS6010U10PopupIAlayOCS2006Info> getOCS6010U10PopupIAlayOCS2006(String hospCode, String pkocs2005);
	
	public List<OCS6010U10PopupIAlayOCS2005Info> getOCS6010U10PopupIAlayOCS2005(String hospCode, String pkocs2005);

	public List<ComboListItemInfo> getOCS2005U02createHoDongNut(String hospCode, String language);
}

