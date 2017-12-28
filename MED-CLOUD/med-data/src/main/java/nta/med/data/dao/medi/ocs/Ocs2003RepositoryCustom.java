package nta.med.data.dao.medi.ocs;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INP2001U02grdOcs2003Info;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdOCS2003Info;
import nta.med.data.model.ihis.inps.OCS2003Q02BatchDeleteProcessInfo;
import nta.med.data.model.ihis.inps.OCS2003R00layOCS2003Info;
import nta.med.data.model.ihis.inps.OCS2003R00layPatientInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdEditIGubunInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U12IsUpdateCheckSelectInfo;
import nta.med.data.model.ihis.ocsi.DtMarumeKeyInfo;
import nta.med.data.model.ihis.ocsi.OCS2003P01GrdPatientListInfo;
import nta.med.data.model.ihis.ocsi.OCS2003P01LayQueryLayoutInfo;
import nta.med.data.model.ihis.ocsi.OCS2003Q02grdNotActingInfo;
import nta.med.data.model.ihis.ocsi.OCS2003Q11dataLayoutMIOInfo;
import nta.med.data.model.ihis.ocsi.OCS2003Q11layQueryInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getJusaCurInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getPRNCURInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getPRNInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdDrugOrderInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdOcs2017Info;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdOrderInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdOrderdateInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10OrderInfoCaseOcsInfo;
import nta.med.data.model.ihis.ocso.PrOcsIudBomOrderActInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdInpInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00LayPrintDateInfo;

/**
 * @author dainguyen.
 */
public interface Ocs2003RepositoryCustom {
	public String callPrOcsApplyNdayOrderOCS0103U13(String hospCode,String bunho,Date orderDate);
	public String callFnOcsInsteadModifiedCheck(String hospCode,Double pkocsKey,String inputGubun,String ioGubun);
	public List<OCS0103U12IsUpdateCheckSelectInfo> getOCS0103U12IsUpdateCheckSelect(String hospCode, Double pkocs2003 );
	
	public String getOCS0103U12ProtectGroupControl(String hospCode, String bunho, Date orderDate, Double groupSer);
	public String getOCS0103U12GridColumnProtectModify(String hospCode,String bunho,Date orderDate,String hangmogCode);
	
	public List<String> getOCS0103U12SetSameOrderDateGroupSerListItem(String hospCode, Date orderDate, String inputTab, String bunho, String inputDoctor);
	public String callPrOcsDeleteNdayOrder(String hospCode,Double pkOcs2003);
	public Double getMaxSeqOCS0103U13SaveLayout(String hospCode,String bunho,Double inoutKey,String orderDate);
	public List<String> getIfNullIfDataSendYnOCS2003(String hospCode,Double pkOcs2003);
	public PrOcsIudBomOrderActInfo callPrOcsIudBomInpOrderAct(String hospCode,String language,String iudGubun,String inputId,String inputPart,
			Date orderDate,Double bomSourceKey,Double pkOcs2003,String hangmogCode,Double suryang,Date actingDate,
			String actingTime,String orderGubun,Double nalsu,String ordDanui);
	public List<XRT1002U00LayPrintDateInfo> getXRT1002U00LayPrintDateInfo(String hospCode,Date orderDate,
			String inOutGubun,Double fkOut1001,String printOnly,String jundalPart,Double pkocs,Double fkinp1001);
	
	public List<ComboListItemInfo> getNut0001U00InitializeScreenOcs0203DoctorGwaInfo(String hospCode, Double pkocskey);
	
	public Double getNUT0001U00GetNaewonKey(String hospCode, String ioKubun, Double pkocs);
	public List<PHY2001U04GrdInpInfo> getPHY2001U04GrdInpInfo(String hospCode, Date orderDate);
	public BigInteger getNewOrderFormINP(String hospCode, Date orderDate, String timeHour, String timeMin, String timeSec);
	
	public BigInteger getPhy8002U01GetLayJissekiDataOcs2003Count(String hospCode, Double fkOcs);
	public List<ORDERTRANSGrdEditIGubunInfo> getORDERTRANSGrdEditInfoCaseElse(String hospCode, String language, Double pk1001, String sendYn, 
			String bunho, Date orderDate, String gwa, String doctor);
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase0ElseEqualN(String hospCode, String language, String ioGubun, String sendYn, String bunho);
	
	// BEGIN MIH
	public List<INP2001U02grdOcs2003Info> getListINP2001U02grdOcs2003Info(String hospCode, String language, String bunho, Double fkinp1001);
	public List<OCS2003R00layPatientInfo> getOCS2003R00layPatientInfo(String hospCode, String language, String gwa, String doctor, String inputGubun, String bunho, Double fkinp1001, String orderDate);
	public List<OCS2003R00layOCS2003Info> getOCS2003R00layOCS2003Info(String hospCode, String language, String bunho, Double fkinp1001, String orderDate, String inputGubun, String gwa, String doctor);
	
	public List<ComboListItemInfo> getOCS2003P01XOCS0132EditGridCell(String hospCode);
	public List<ComboListItemInfo> getOCS2003P01XBAS0260EditGridCell(String hospCode,String language);
	public List<ComboListItemInfo> getOCS2003P01XBAS0102EditGridCell(String hospCode);
	
	public String getOCS2003Q02GetCodeNameGwaInfo(String hospCode, String language, String code, String ipwonYn, String buseoGubun);
	
	public List<OCS2003Q11dataLayoutMIOInfo> getOCS2003Q11dataLayoutMIOInfo(String hospCode, String language, String hoDong,
			String session, String hoTeam, Date orderDate);
	public List<OCS2003Q11layQueryInfo> getOCS2003Q11layQueryInfo(String hospCode, String language, String queryDate,
			String hoDong, String hoTeam, String a, String b, String c, String d);
	
	public List<OCS2003Q02grdNotActingInfo> getOCS2003Q02grdNotActingInfo(String hospCode, String language, String bunho, String hoDong, String gwa, String doctor, String timeGubun, String orderDate, String inputGubun, String orderGubun);
	
	public String checkOcsIsYetBannabOrder(String hospCode, String bunho, String kijunDate);
	
	public OCS2003Q02BatchDeleteProcessInfo callPrOcsiBatchDeleteOrder(String hospCode, Double pkInp1001, Date deleteDate);
	
	public String callPrOcsiProcessBannabNew(String hospCode, String workGubun, String bunho, double fkinp1001,
			double pkocs2003, Date stopDate, Date stopDate2, String inputDoctor, String userId, String gubun,
			double bannabDv, String bogyongCodeReturn, double toiwonDrgDv, String toiwonDrgBogyongCode);

	public List<Double> getOCS2003P01SetSameOrderDateGroupSer(String hospCode, String orderDate, String inputTab, String bunho, String inputDoctor);
	public List<OCS2003P01GrdPatientListInfo> getOCS2003P01GrdPatientListInfo(String hospCode, String language, Date orderDate, String inputGubun, String approveDoctor, String bunho, String doctorYn, String doctor, String hodong);
	
	public List<OCS2003P01LayQueryLayoutInfo> getOCS2003P01LayQueryLayout(String hospCode, String language,
			String bunho, String fkinp1001, String orderDate, String queryGubun, String inputDoctor,
			String inputGubun);	
	public String getOCS2003U03getResDateinfo(String hospCode, String bunho, String pkocs2003, String kijunDate);
	public String callPrOcsUpdateDrgSunabDate(String hospCode, String fkocs2003, String userId);
	public String callPrOcsiProcessBannabNew(String hospCode, String workGubun, String bunho, String fkinp1001, String pkocs2003, String stopDate, String stopDate2, String inputDoctor, String userId, String gubun, String bannabDv, String bogyongCodeReturn, String toiwonDrgDv, String toiwonDrgBogyongCode);
	public List<OCS2003U03grdOrderInfo> getOCS2003U03grdOrderInfo(String hospCode, String kijunDate, String bunho, String fkinp1001, String orderDate, String inputDoctor, Integer startNum, Integer offset);
	public List<OCS2003U03grdOcs2017Info> getOCS2003U03grdOcs2017Info(String hospCode, String language, String pkocs2003, Integer startNum, Integer offset);
	
	public List<OCS2003U03grdOrderdateInfo> getOCS2003U03grdOrderdateInfo(String hospCode, String fkinp1001, String bunho,
			String orderDate, String inputGubun, String gaiyouYn, Integer startNum, Integer offset);
	
	public List<OCS2003U03grdDrugOrderInfo> getOCS2003U03grdDrugOrderInfo(String hospCode, String language, String bunho,
			Double fkinp1001, String gwa, String doctor, String inputTab, String queryDate, String queryGubun,
			String gaiyouYn, String kijunDate, Integer startNum, Integer offset);
	
	public List<DataStringListItemInfo> getOCS2003U03getPkocskey(Double pkocskey, String workGubun, String hospCode);
	public String getCountOCS2003U03(String hospCode, Double pkocs2003, String actResDate);
	
	public String getOCS2003U03ActResDate(String hospCode, Double pkocs2003, String bunho, String kijunDate, String stopDate,
			String stopEndDate, String controlId);
	public String getOCS2003U03StopStartDate(String hospCode, Double pkocs2003);
	public String getOCS2003U03StopEndDate(String hospCode, Double pkocs2003, String stopStartDate);
	public String getOCS2003U03DV(String hospCode, Double pkocs2003);
	public String getOCS2003U03BogyongCode(String hospCode, String bogyongCode, String dvOriginal, String dvChanged, String gubun);
	public List<OCS2003U03getPRNCURInfo> getOCS2003U03getPRNCURInfo(String hospCode, String language, String jubsuDate, String drgBunho);
	public List<OCS2003U03getPRNInfo> getOCS2003U03getPRNInfoSerial(String hospCode, String language, String jubsuDate, String drgBunho, String serialText);
	public List<OCS2003U03getPRNInfo> getOCS2003U03getPRNInfoSerial2003(String hospCode, String language, Double fkocs2003, String serialText);
	public List<OCS2003U03getPRNInfo> getOCS2003U03getPRNInfoElse(String hospCode, String language, String jubsuDate, String drgBunho, String serialText);
	public List<OCS2003U03getJusaCurInfo> getOCS2003U03getJusaCurInfo(String hospCode, String language, String jubsuDate, String drgBunho);
	public List<OCS6010U10OrderInfoCaseOcsInfo> getOCS6010U10OrderInfoCaseOcsInfo(String hospCode, String pkocs2003);
	public String getOCS2003U99layChkCommonRequest(String hospCode, String bunho, String pkinp1001, String inputGubun);
	public Boolean callPrDrgAutoOcsBannab(String hospCode, String language, String actingDate, String userId, String fkinp1001);
	public String callPrOcsTransInputGubunD6(String hospCode, String bunho, String fkinp1001, String toiwonGoji, String userId);
	public String callPrOcsDeleteInpOrderToiwon(String hospCode, String inputId, String bunho, String fkinp1001, String toiwonDate, String sigiMagamDate, String kiGubun);
	
	public int updateOcs2003InOCS6010U10(String hospCode, String bunho, String userId, Double fkInp1001, Date fromDate, Date toDate, Double pkocs6013);
	public int updateOcs2003InOCS6010U10SaveLayoutCase01(String hospCode, double pkocs2003, String userId, String nurseActUser, Date nurseActDate);
	public int updateOcs2003InOCS6010U10SaveLayoutCase02(String hospCode, double pkocs2003, String userId);
	public int updateOcs2003InOCS6010U10SaveLayoutCase03(String hospCode, double pkocs2003, String userId, String pickupUser);
	public int updateOcs2003InOCS6010U10SaveLayoutCase04(String hospCode, double pkocs2003, String userId);
	public String getNUR2017Q00grdNUR2017QueryEndInfo(String hospCode, String pkocs2003);
	public Integer deleteOCS2003ByHospCodePkocs2015(String hospCode, double pkocs2015);
	public Integer updateOcs2003InOCS6010U10PopupDAbtnList(String hospCode, double pkocs2003, Date actingDate, String ocsFlag, String actBuseo);
	public List<DtMarumeKeyInfo> getDtMarumeKeyInfo(String hospCode, String bunho, double fkinp1001, String inputGubun, Date orderDate, String hangmogCode);
	
	public Integer deleteOCS6010U10PopupIASaveLayout(String hospCode, String pkocs2016);

	public Integer deleteOCS6010U10PopupIASaveLayoutWhenError(String hospCode, String bunho, String pkocs2016);
	
	public List<INPORDERTRANSGrdOCS2003Info> getINPORDERTRANSGrdOCS2003Info(String hospCode, String language, String sendYn, Double pkinp3010, Date actingDate, String bunho);
	public String getDRG3010P99ToiwonGojiYn(String hospCode, Double fkocs2003);
	public String getNUR1014U00CheckOrder(String hospCode, Double fkinp1001, String bunho, String outDate, String inDate);
	
}

