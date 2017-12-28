package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10LayQueryLayoutInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10LaySiksaJunpyoInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10LoadDetailDataInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupMAgrdOCS2016Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmARActingOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmARActinggrdOCS2015Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmARActinggrdOCS2016Info;
import nta.med.data.model.ihis.system.FnInpLoadJaewonIlsuInfo;

/**
 * @author dainguyen.
 */
public interface Ocs6010RepositoryCustom {
	public List<FnInpLoadJaewonIlsuInfo> getFnInpLoadJaewonIlsuInfo(String hospCode, String bunho, Double naewonKey);

	public String getOBIsCPPatientYn(String hospCode, Double fkinp1001);

	public List<OCS6010U10LayQueryLayoutInfo> getOCS6010U10LayQueryLayoutInfo(String hospCode, String language,
			String bunho, Double fkInp1001, Date orderDate, String queryGubun, String inputDoctor, String inputGubun);

	public List<OCS6010U10LaySiksaJunpyoInfo> getOCS6010U10LaySiksaJunpyoInfo(String hospCode, String language,
			String bunho, Date fromDate, Date orderDate, Double fkinp1001, String inputGubun, Double pkSeq);

	public String getOCS6010U10GetCheckValue(String hospCode, String code);
	
	public String getOCS6010U10GetCheckModifyPlan(String hospCode, String modifyDate, String fkocs6010);
	
	public List<OCS6010U10LoadDetailDataInfo> getOCS6010U10LoadDetailDataInfo(String hospCode, String language,
			String bunho, Double fkinp1001, Date fromDate, Date toDate, String allSiji, String emergencyTreat,
			String insteadOrderDisplayYn, String fB, String fC, String fD, String fH, String fG, String fM, String fF,
			String fO, String fN, String fE, String fL, String fK, String fI, String fZ, String commentYn, String remarkYn);
	
	public CommonProcResultInfo callPrOcsPlanDirectConvert(String hospCode, Double pkOcs6015, Date appDate, String userId);
	
	public CommonProcResultInfo callPrOcsApplyPlanOrderGroup(String hospCode, String bunho, Double fkinp1001, Double fkocs6010, Date planDate, String inputGubun, String orderGubun, String groupSer, String userId);
	public String callPrOcsPrnCancelProc(String hospCode, double pkocs2003);
	public CommonProcResultInfo callPrOcsCreatePlanJaewonil(String hospCode, Double fkocs6010, Date planOrderDate, String userId);
	public List<OCS6010U10frmARActingOCS2005Info> getOCS6010U10frmARActingOCS2005Info(String hospCode, Double fkocs2005, Date orderDate);
	public List<OCS6010U10frmARActinggrdOCS2015Info> getOCS6010U10frmARActinggrdOCS2015Info(String hospCode, String bunho, double fkinp1001, double fkocs2005, String limit7, String kijunDate);
	public List<OCS6010U10frmARActinggrdOCS2016Info> getOCS6010U10frmARActinggrdOCS2016Info(String hospCode, double fkocs2015);
	public List<OCS6010U10PopupMAgrdOCS2016Info> getOCS6010U10PopupMAgrdOCS2016Info(String hospCode, double fkocs2015);
	public String getOCS6010U10PopupMPDGetCheckModifyPlandate(String hospCode, double fkocs6010, String modifyDate);
	public CommonProcResultInfo callPrOcsDirectActOrder(String hospCode, String bunho, Double fkinp1001, Date orderDate, String inputGubun, Double pkocs2015, Date actingDate, String userId);

	public CommonProcResultInfo callPrOcsDirectActAr(String hospCode, String bunho, Double fkinp1001, Date orderDate,
			String inputGubun, Double pkseq, Date actingDate, Double seq, String fromTime, String toTime, String userId, Double pkocs2015);
	
	public CommonProcResultInfo callPrOcsDirectActingO2(String hospCode, String bunho, double fkinp1001, Date orderDate,
			String inputGubun, double pkseq, Date actingDate, double seq, String fromTime, String toTime, String userId, double suryang, double pkocs2015);
	
	public CommonProcResultInfo callPrOcsDirectActMoniter(String hospCode, String bunho, double fkinp1001,
			Date orderDate, String inputGubun, double pkseq, Date actingDate, double seq, String fromTime,String toTime, String userId, double pkocs2015);
}
