package nta.med.data.dao.medi.ocs;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.ocs.Ocs1003;
import nta.med.data.model.ihis.bill.BIL2016U01LoadPatientInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL2010R02grdOrderListInfo;
import nta.med.data.model.ihis.cpls.CPL2010R02grdcpllistInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetOrderReportInfo;
import nta.med.data.model.ihis.emr.OCS2015U03OrderGubunInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01GrdOCS1003ItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01LabelNewListItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01ScheduleItemInfo;
import nta.med.data.model.ihis.nuro.NUR2016U02TranferSgCodeInfo;
import nta.med.data.model.ihis.nuro.ORCATransferOrdersClaimInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdEditInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListNonSendYnInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSMisaGetHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U12GrdSangyongOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdOrderListInfo;
import nta.med.data.model.ihis.ocsa.OCSAPPROVEGrdOrderInfo;
import nta.med.data.model.ihis.ocso.GwaListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003Q02LayQueryLayoutInfo;
import nta.med.data.model.ihis.ocso.OCS1003R00LayOCS1003Info;
import nta.med.data.model.ihis.ocso.OCSACT2GetGrdPaListInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdJearyoInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayoutQueryInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05OrderListItemInfo;
import nta.med.data.model.ihis.ocso.PatientMedicineInfo;
import nta.med.data.model.ihis.ocso.PrOcsIudBomOrderActInfo;
import nta.med.data.model.ihis.nuro.MedicalInfo;
import nta.med.data.model.ihis.nuro.MedicalInfoExt;
import nta.med.data.model.ihis.orca.ORCATransferOrdersClaimOrdersFeeInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdOutInfo;

/**
 * The Interface Ocs1003RepositoryCustom.
 *
 * @author dainguyen.
 */
public interface Ocs1003RepositoryCustom {
	
	/**
	 * Gets the injs in j1001 u01 schedule item info.
	 *
	 * @param hospitalCode the hospital code
	 * @param language the language
	 * @param bunho the bunho
	 * @param orderDate the order date
	 * @param postOrderYn the post order yn
	 * @param preOrderYn the pre order yn
	 * @param reserDate the reser date
	 * @param actingFlg the acting flg
	 * @return the injs in j1001 u01 schedule item info
	 */
	public List<InjsINJ1001U01ScheduleItemInfo> getInjsINJ1001U01ScheduleItemInfo(String hospitalCode, String language,
			String bunho, Date orderDate, String postOrderYn, String preOrderYn, Date reserDate, String actingFlg);
	
	/**
	 * Gets the ocso oc s1003 p01 layout query info.
	 *
	 * @param language the language
	 * @param hospCode the hosp code
	 * @param bunho the bunho
	 * @param fkout1001 the fkout1001
	 * @param queryGubun the query gubun
	 * @param inputGubun the input gubun
	 * @return the ocso oc s1003 p01 layout query info
	 */
	public List<OcsoOCS1003P01LayoutQueryInfo> getOcsoOCS1003P01LayoutQueryInfo(String language, String hospCode, String bunho, Double fkout1001,
			String queryGubun, String inputGubun);
	
	/**
	 * Call ocso oc s1003 p01 out order end temp.
	 *
	 * @param hospCode the hosp code
	 * @param fkout1001 the fkout1001
	 * @param orderDate the order date
	 * @return the string
	 */
	public String callOcsoOCS1003P01OutOrderEndTemp(String hospCode, Double fkout1001, Date orderDate);
	
	/**
	 * Call ocso oc s1003 p01 update dc yn.
	 *
	 * @param hospCode the hosp code
	 * @param ioGubun the io gubun
	 * @param sourcePkOcs the source pk ocs
	 * @return the string
	 */
	public String callPrOcsUpdateDcYn(String hospCode, String ioGubun, Double sourcePkOcs);
	
	/**
	 * Gets the ocso oc s1003 p01 get ocs key seq.
	 *
	 * @return the ocso oc s1003 p01 get ocs key seq
	 */
	public String getOcsoOCS1003P01GetOcsKeySeq();
	
	/**
	 * Gets the injs in j1001 u01 label new list item info.
	 *
	 * @param hospitalCode the hospital code
	 * @param language the language
	 * @param gwa the gwa
	 * @param doctor the doctor
	 * @param bunho the bunho
	 * @param jubsuDate the jubsu date
	 * @param groupSer the group ser
	 * @param mixGroup the mix group
	 * @param fkinj1001 the fkinj1001
	 * @return the injs in j1001 u01 label new list item info
	 */
	public List<InjsINJ1001U01LabelNewListItemInfo> getInjsINJ1001U01LabelNewListItemInfo(String hospitalCode, String language, String gwa, String doctor,
			String bunho, Date jubsuDate, String groupSer, String mixGroup, String fkinj1001);
	
	/**
	 * Gets the injs in j1001 u01 cpl order status.
	 *
	 * @param hospCode the hosp code
	 * @param ioGubun the io gubun
	 * @param bunho the bunho
	 * @param date the date
	 * @param jundalPart the jundal part
	 * @return the injs in j1001 u01 cpl order status
	 */
	public String getInjsINJ1001U01CplOrderStatus(String hospCode, String ioGubun, String bunho, Date date, String jundalPart);
	
	public List<OcsoOCS1003Q05OrderListItemInfo> getOcsoOCS1003Q05OrderList(String hospCode, String language, String genericYn, String pkOrder, String inputTab,
			String inputGubun, String telYn, String bunho, String jubsuNo, String kijun, Date naewonDate, String gwa, String doctor);
	
	public List<String> callPrOcsUpdateHopeDate(String hospCode, String inOutGubun, Double fkocs, String hopeDate, String io_Msg, String io_Flg);
	
	public List<String> validatePrintAdmMediRequest(String hospCode, String jubsuDate, String drgBunho, String bunho,String handlerName);
	public String getOrderCancelGetYN(Double pkocs1003);
	public List<InjsINJ1001U01GrdOCS1003ItemInfo> getINJ1001U01GrdOCS1003ItemInfo(String hospCode,String language,
			String bunho,Date startDate,Date endDate);
	
	public Integer updatePrOcsUpdateHopeDateCaseOut(String hospCode, Date hopeDate, List<Double> pkocs1003);
	public String callFnOcsInsteadModifiedCheck(String hospCode,Integer pkocskey,String inputGubun,String ioGubun);
	public List<OCS0103U13GrdOrderListInfo> getOCS0103U13GrdOrderListInfo(String hospCode,String language,String orderMode,
			String memb,String yaksolCode,String inputTab,Double fkInOutKey, String request);
	public List<OCS0103U12GrdSangyongOrderInfo> getOCS0103U12GrdSangyongOrder(String user, String hospCode, String ioGubun, 
			String orderGubun, Date orderDate, String searchWord, String wonnaeDrgYn, String protocolId, String language);
	
	public String callFnOcsCheckOrderInputYn(String hospCode, String language, String iudGubun, String ioGubun, Double pkOcsKey);
	
	public String callFnRehIsResultToConsult(String hospCode, String pkOcsKey, String ioGubun);
	
	public Integer getOrderCount(String hospCode, String ioGunbun, String bunho, Date orderDate);
	
	public String getDupCheckInputOutOrder(String hospCode, String language, String bunho,
			Date naewonDate, String hangmogCode, Date hopeDate);
	public List<OCS1003Q02LayQueryLayoutInfo> getOCS1003Q02LayQueryLayoutInfo(String hospCode,String language,
			String bunho,Double fkout1001,String queryGubun,String inputGubun);
	public List<OCS1003R00LayOCS1003Info> getOCS1003R00LayOCS1003Info(String hospCode,String language,String bunho,String naewonDate,
			String gwa,String doctor,String naewonType,String inputGubun);
	
	public void callPrOcsUpdateActing(String hospCode, String inOutGubun, Double fkocs, String actBuseo, Date jubsuDate, String jubsuTime,
			Date actingDate, String actingTime, String actDoctor);

	
	public List<OCSACTGrdJearyoInfo> getOCSACTGrdJearyoInfo (String bunho, String orderDate, String ioGubun, String jundalPart, Double fkocs,
			String hospCode, String language);

	
	public List<String> getIfNullIfDataSendYnOCS1003(String hospCode,Double pkOcs1003);
	public Double callPrOcsoRealOrderFromDummy(String hospCode,String ioGubun,Double srcFkocs,String userId,
			String inputGubun,String hangmogCode);
	public PrOcsIudBomOrderActInfo callPrOcsIudBomOutOrderAct(String hospCode, String language, String iudGubun, String inputId, String inputPart,
			Double bomSourceKey, Double pkOcs1003, String hangmogCode, Double suryang, Date actingDate,
			String actingTime, String orderGubun, Double nalsu, String ordDanui);

	
	public List<OCSAPPROVEGrdOrderInfo> getOCSAPPROVEGrdOrderListItem(String hospCode, String language, Double pkOrder, String inputTab,
			String insteadYN, String approveYn, String prepostGubun, String bunho, String jubsuNo, String doctor, Date naewonDate, boolean ocs1003Q09, String genericYn, String inputGubun, String telYn);
	
	public List<OCSAPPROVEGrdOrderInfo> getOCSAPPROVEGrdOrderListItemUnion(String hospCode, String language, Double pkOrder, String inputTab,
			String insteadYN, String approveYn, String prepostGubun, String bunho, String jubsuNo, String doctor, Date naewonDate, boolean ocs1003Q09
			, String inputGubun, String telYn, String kijun, String gwa);
	public void callPrOcsUpdateXrtJubsu(String hospCode,String inOutGubun,Double fkOcs,String userId,Date jubsuDate,String jubsuTime,String actDoctor);
	public void callPrOcsUpdateXrtAacting(String hospCode,String inOutGubun,Double fkOcs,String userId,String actBuseo,
			Date actingDate,String actingTime,String resultDate,String xrtDrYn);
	
	public List<ComboListItemInfo>  getNut0001U00InitializeScreenOcs1003DoctorGwaInfo(String hospCode, Double pkocs1003);
	
	
	public ComboListItemInfo callPrRehAddRehasinryouryou(String hospCode, String language, Date iOrderDate, String iBunho, 
			Double iFkout1001, String iDoctor, String iSinryouryouGubun, String iInputId, String iInputTab, String iIudGubun);
	public List<PHY2001U04GrdOutInfo> getPHY2001U04GrdOutInfo(String hospCode, Date orderDate);
	
	public BigInteger getNewOrderFormOUT(String hospCode, Date orderDate, String timeHour, String timeMin, String timeSec);
	
	public BigInteger getPhy8002U01GetLayJissekiDataOcs1003Count(String hospCode, Double fkOcs);
	public List<OCS2015U03OrderGubunInfo> getOCS2015U03OrderGubunInfo(String hospCode, String patientCode, Double reservationCode);
	public List<ORDERTRANSGrdEditInfo> getORDERTRANSGrdEditInfo(String hospCode, String language, String sendYn, Double pk1001, 
			Date actingDate, String bunho, String gwa, String doctor);
	
	public List<ORDERTRANSGrdListNonSendYnInfo> getORDERTRANSGrdListNonSendYnInfo(String hospCode, String language, Date actingDate, String bunho);
	public String callPrOutCheckOrderEnd(String hospCode, String langage, Date actingDate, String doctor, String bunho);
	public List<ORCATransferOrdersClaimInfo> getORCATransferOrdersClaimInfo(String hospCode, String bunho, Double pkout1001);
	public List<ORCATransferOrdersClaimOrdersFeeInfo> getORCATransferOrdersClaimOrdersFeeInfo(String hospCode, String language, String bunho, Double pkout1001, List<String> listHangmocCode);

	public String callFnOcsIsNextKensaReser(String hospCode, String buho, Date newDate);
	public List<OCS2015U00GetOrderReportInfo> getOCS2015U00GetOrderReportInfo(String hospCode, String language, String bunho, Double pkout1001);
	public List<String> checkOrderStatus(String hospCode, String bunho, Double pkout1001);
	
	public List<ORDERTRANSMisaGetHangmogInfo> getORDERTRANSMisaGetHangmogInfo(String hospCode, String bunho, String pkout1001);

	public List<Ocs1003> getByHospCodeAndFks0201(String hospCode, Double fksch0201) ;
	
	public List<PatientMedicineInfo> getPatientMedicine(String patientCode, String hospCode, String language);
	
	public List<NUR2016U02TranferSgCodeInfo> getNUR2016U02TranferInfo(String hospCode, String bunho);
	public List<NUR2016U02TranferSgCodeInfo> getNUR2016U02TranferInfoExt(String hospCode, String bunho);
	
	public List<OCSACT2GetGrdPaListInfo> getOCSACT2GetGrdPaListInfo(String hospCode, String language, String jundalTable, String gwa, Date orderDateFrom, Date orderDateTo, String bunho, String actingFlag, boolean isCPL);
	public void callProLogicInsertOcs1003(String hospCode, Double pkocs1003);
	public boolean isExistJundalTableIsCPL(String hospCode, String gwa, Date orderDateFrom, Date orderDateTo, String bunho, String actingFlag);

	public boolean isCompleteOrder(String hospCode,double pkOCS1003);
	
	public List<BIL2016U01LoadPatientInfo> getBIL2016U01LoadPatientInfo(String hospCode, String language, Date fromDate, Date toDate, String bunho, String suname, String billNumber);
	
	public String getRemarkOcs1003(String hospCode, Double pkocs1003, Double pkout1001, String language);
	
	public List<MedicalInfoExt> getMedicalInfo(String hospCode, String bunho, Double pkout1001, List<String> listHangmocCode, boolean isTransfered);
	
	public boolean isExistedOCS1003(String hospCode, Double pkocs1003);
	
	List<GwaListItemInfo> getMedicineInfo(String hospCode, String bunho, Date orderDate);
	
	public Integer getOrderCount(Double pkout1001);
	
	public List<OCS2015U00GetOrderReportInfo> getOCS2015U00OrderReportInfo(String hospCode, String language, String bunho);
	public List<CPL2010R02grdcpllistInfo> getCPL2010R02grdcpllistInfo(String hospCode, String language, String inOutGubun, String bunho, String orderDate, String gwa, String doctor, String specimenCode, String reOutput, String fkinp1001);
	public List<CPL2010R02grdOrderListInfo> getCPL2010R02grdOrderListInfo(String hospCode, String language, String bunho, String orderDate, String reOutput);
	public Integer callFnOcsGetBeforeApporder(String hospCode, String ioGubun, String insteadYn, String approveYn, String doctorId, String key);
} 

