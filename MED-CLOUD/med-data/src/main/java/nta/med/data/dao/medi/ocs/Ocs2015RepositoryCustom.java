package nta.med.data.dao.medi.ocs;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdSiksaInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL1Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdSiksaInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdOCS2015Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10OrderInfoCase2Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10OrderInfoCaseDfltInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAgrdOCS2015Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAProcDAOTInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdOCS2015Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmDirectActinggrdOCS2015Info;
import nta.med.data.model.ihis.ocsi.RecoveryMaxMinInfo;

/**
 * @author dainguyen.
 */
public interface Ocs2015RepositoryCustom {
	public List<ORDERTRANSGrdSiksaInfo> getORDERTRANSGrdSiksaInfo(String hospCode, String sendYn, String bunho, Double pk1001, String actingDate);
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase1(String hospCode, String language, String ioGubun, String sendYn, String bunho, String actingDate);
	public List<INPORDERTRANSGrdSiksaInfo> getINPORDERTRANSGrdSiksaInfo(String hospCode, String bunho, String sendYn, Date firstDate, Date lastDate,Integer startNum, Integer offset);
	public List<OCS6010U10OrderInfoCaseDfltInfo> getOCS6010U10OrderInfoCaseDfltInfo(String hospCode, String bunho, String fkinp1001, String inputGubun, String pkSeq, String actDate);
	public List<OCS6010U10OrderInfoCaseDfltInfo> getOCS6010U10OrderInfoCase3Info(String hospCode, String bunho, String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate);
	public List<OCS6010U10OrderInfoCase2Info> getOCS6010U10OrderInfoCase2Info(String hospCode, String language, String bunho, String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate);
	public Double getNextSeqOcs2015(String hospCode, String bunho, Double fkinp1001, Date orderDate, String inputGubun, Double pkSeq);
	public List<OCS2005U00grdOCS2015Info> getOCS2005U00grdOCS2015Info(String hospCode, String pkSeq, String inputGubun, String fkinp1001, String bunho, Integer startNum, Integer offset);
	public BigInteger countOcs2015InOCS6010U10(String hospCode, String bunho, Double fkinp1001, Date sourceOrderDate, String inputGubun, Double pk);
	public List<ComboListItemInfo> OCS2005U02getMinMaxDate(String hospCode, Double fkocs2005, String fromDate, String toDate);
	public List<OCS6010U10PopupTAgrdOCS2015Info> getOCS6010U10PopupTAgrdOCS2015Info(String hospCode, String bunho, String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate, Integer startNum, Integer offset);
	public List<RecoveryMaxMinInfo> getRecoveryMaxMinInfo(String hospCode, Double pkocs2005, Date drtFromDate, Date drtToDate);
	
	public Double getOCS6010U10frmARActingSeqOCS2015(String hospCode, String bunho, String fkinp1001, String orderDate, String inputGubun, String pkSeq);
	public List<OCS6010U10frmDirectActinggrdOCS2015Info> getOCS6010U10frmDirectActinggrdOCS2015Info(String hospCode, String bunho, String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate, Integer startNum, Integer offset);
	public Double getNextSeqOcs2015Ext(String hospCode, String bunho, Double fkinp1001, Date orderDate, String inputGubun, Double pkSeq);
	public OCS6010U10PopupTAProcDAOTInfo callPrOcsDirectActOrderTreat(String hospCode, String language, String bunho, String fkinp1001, String orderDate, String inputGubun, String pkocs2015, String actingDate, String userId);
	public CommonProcResultInfo callPrOcsiIsJisiDateime(String hospCode, String iud, String gubun, String bunho, Double fkinp1001, Date fromDate, String fromTime, Date toDate, String toTime, String userId);
	
	public List<ComboListItemInfo> getOCS6010U10PopupIAbtnList(String hospCode, String bunho, String orderDate);
	public CommonProcResultInfo callPrOcsiMarumeIud(String hospCode, String iudGubun, double key);
	
	public List<OCS6010U10PopupIAgrdOCS2015Info> getOCS6010U10PopupIAgrdOCS2015(String hospCode, String bunho, String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate, String offset, String pageNumber);
	public Double getNextSeqOcs2015InFrmDrugAting(String hospCode, String bunho, Double fkinp1001, Date orderDate, String inputGubun, Double pkSeq, Date actDate);
	public String getXOCS6010U10PopupO2ASavePerformer(String hospCode, String bunho, double fkinp1001, String inputGubun, double pkseq, Date actDate);
	public List<INPORDERTRANSSelectListSQL1Info> getINPORDERTRANSSelectListSQL1Info(String hospCode, String language, String bunho, String yyyyMm, Date yyyyMMddFirst, Date yyyyMMddLast);

}

