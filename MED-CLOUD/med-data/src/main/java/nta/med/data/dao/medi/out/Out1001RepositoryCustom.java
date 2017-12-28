package nta.med.data.dao.medi.out;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.adma.ADM9999U00GetInformInfo;
import nta.med.data.model.ihis.bass.CreatePatientSurveyInfo;
import nta.med.data.model.ihis.bill.LoadGridBIL2016U02Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LoadChebangPrintInfo;
import nta.med.data.model.ihis.emr.OCS2015U04LoadExaminationInfo;
import nta.med.data.model.ihis.nuro.BookingLabInfo;
import nta.med.data.model.ihis.nuro.KCCKCountTotalOfBookingInfo;
import nta.med.data.model.ihis.nuro.MedicalInfo;
import nta.med.data.model.ihis.nuro.NUR2015U01GrdOrderInfo;
import nta.med.data.model.ihis.nuro.NUR2016U02ActingDateAndSendYnInfo;
import nta.med.data.model.ihis.nuro.NuroChkGetBunhoBySujinInfo;
import nta.med.data.model.ihis.nuro.NuroNUR1001R00GetTempListItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LayoutBarCodeInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LoadCheckChojaeJpnInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LoadOUT0105Info;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01GridInfo;
import nta.med.data.model.ihis.nuro.NuroOutOrderStatus;
import nta.med.data.model.ihis.nuro.NuroPatientCommentInfo;
import nta.med.data.model.ihis.nuro.NuroPatientDetailInfo;
import nta.med.data.model.ihis.nuro.NuroPatientInfo;
import nta.med.data.model.ihis.nuro.NuroPatientInsuranceInfo;
import nta.med.data.model.ihis.nuro.NuroPatientReceptionHistoryInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00DoctorReserListItemInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReserListItemInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReseredDataListItemInfo;
import nta.med.data.model.ihis.nuro.OCS1003P01GrdPatientListItemInfo;
import nta.med.data.model.ihis.nuro.OUT1001P01GrdOUT1001ListItemInfo;
import nta.med.data.model.ihis.nuro.RES1001R00BookingInfo;
import nta.med.data.model.ihis.nuro.RES1001U01BookingClinicReferInfo;
import nta.med.data.model.ihis.ocsa.OCS0503Q00FilteringTheInformationInfo;
import nta.med.data.model.ihis.ocsa.OCS1003Q09GridOUT1001Info;
import nta.med.data.model.ihis.ocsa.OCS3003Q10GrdOrderDateListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003Q02GridOUT1001Info;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridPatientListInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayPatInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05ScheduleItemInfo;
import nta.med.data.model.ihis.phys.PHY2001U04BtnDeleteGetDataTableInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdExcelInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdOut1001Info;
import nta.med.data.model.ihis.phys.PHY2001U04GrdPaCntInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdPatientListInfo;
import nta.med.data.model.ihis.phys.PHY2001U04PrOutMakeAutoJubsuInfo;
import nta.med.data.model.ihis.phys.PHY2001U04RefreshCounterInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99ReserListInfo;
import nta.med.data.model.ihis.system.LoadPatientNaewonListInfo;
import nta.med.data.model.mss.BookingExamInfo;
import nta.med.data.model.phr.SyncDrugInfo;
/**
 * The Interface Out1001RepositoryCustom.
 *
 * @author dainguyen.
 */
public interface Out1001RepositoryCustom {
	
	/**
	 * Gets the patient patient list info.
	 *
	 * @param language the language
	 * @param hospitalCode the hospital code
	 * @param comingDate the coming date
	 * @param departmentCode the department code
	 * @param doctorCode the doctor code
	 * @param patientCode the patient code
	 * @param receptionType the reception type
	 * @param examStatus the exam status
	 * @param comingStatus the coming status
	 * @param currentSystemId the current system id
	 * @return the patient patient list info
	 */
	public List<NuroPatientInfo> getNuroPatientListInfo(String language, String hospitalCode, String comingDate, String departmentCode, String doctorCode, 
			String patientCode, String receptionType, String examStatus, String comingStatus, String currentSystemId, boolean ignoreLanguage);
	
	/**
	 * Gets the patient out order status info.
	 *
	 * @param hospCode the hosp code
	 * @param bunho the bunho
	 * @param naewonDate the naewon date
	 * @param gwa the gwa
	 * @param language the language
	 * @return the patient out order status info
	 */
	public List<NuroOutOrderStatus> getNuroOutOrderStatusInfo(String hospCode, String bunho, String naewonDate, String gwa, String language);
	
	/**
	 * Gets the patient patient detail list item info.
	 *
	 * @param language the language
	 * @param hospitalCode the hospital code
	 * @param patientCode the patient code
	 * @param comingDate the coming date
	 * @return the patient patient detail list item info
	 */
	public List<NuroPatientDetailInfo> getNuroPatientDetailListItemInfo (String language, String hospitalCode,String patientCode, String comingDate);
	
	/**
	 * Gets the patient patient insurance list item info.
	 *
	 * @param language the language
	 * @param hospitalCode the hospital code
	 * @param patientCode the patient code
	 * @param comingDate the coming date
	 * @return the patient patient insurance list item info
	 */
	public List<NuroPatientInsuranceInfo> getNuroPatientInsuranceListItemInfo  (String language, String hospitalCode,String patientCode, String comingDate);
	
	/**
	 * Gets the patient patient comment list item info.
	 *
	 * @param language the language
	 * @param hospitalCode the hospital code
	 * @param patientCode the patient code
	 * @return the patient patient comment list item info
	 */
	public List<NuroPatientCommentInfo> getNuroPatientCommentListItemInfo  (String language, String hospitalCode, String patientCode);
	
	/**
	 * Gets the nuronur2001u04 coming status.
	 *
	 * @param hospitalCode the hospital code
	 * @param patientCode the patient code
	 * @param comingDate the coming date
	 * @param departmentCode the department code
	 * @param doctorCode the doctor code
	 * @param comingType the coming type
	 * @param oldReceptionNo the old reception no
	 * @param examStatus the exam status
	 * @return the nuronur2001u04 coming status
	 */
	public List<String> getNuroNUR2001U04ComingStatus(String hospitalCode, String patientCode, String comingDate, String departmentCode, 
			String doctorCode, String comingType, Integer oldReceptionNo, String examStatus);
	
	/**
	 * Gets the nuronur2001u04 existing key status.
	 *
	 * @param hospitalCode the hospital code
	 * @param pkout1001 the pkout1001
	 * @return the nuronur2001u04 existing key status
	 */
	public List<String> getNuroNUR2001U04ExistingKeyStatus(String hospitalCode, String pkout1001 );
	
	public List<String> getNuroNUR2001U04ForeignKey(String hospitalCode, String comingDate, String patientCode, 
			String departmentCode, String doctorCode, String comingType, String receptionNo);
	
	public Integer updateComingStatus(String hospitalCode, String comingStatus, String pkout1001);
	
	public Integer updatePatientInfo(String hospitalCode, String updId, String comingStatus, 
			String arriveTime, String receptionType, String pkout1001);
	
	public boolean deletePatientInfo(String hospitalCode, String pkout1001);
	
	public List<NuroOUT1101Q01GridInfo> getNuroOUT1101Q01GridInfo(String hospCode, String gwa, String doctor, String language, String naewonDate);
	
	public List<NuroPatientReceptionHistoryInfo> getNuroPatientReceptionHistoryInfo  (String language, String hospitalCode, String patientCode);
	
	public List<NuroPatientReceptionHistoryInfo> getNuroPatientReceptionHistoryInfo2  (String language, String hospitalCode, String patientCode);
	
	public List<String> getInspectionOrderReserMoveName(String hospitalCode, String language, String patientCode, String reserDate, String departmentCode, String reserYn, String rowNum);
	
	public String getNuroRES0102U00ChkHyujin(String hospCode, String doctor, String startDate, String endDate);
	
	public List<String> getNuroRES1001U00TypeRequest(String hospitalCode, String sessionHospCode, String patientCode, String departmentCode, boolean isOtherClinic);
	
	public List<String> getDoctorName(String hospitalCode, String sessionHospCode, String patientCode, String departmentCode, String examPreDate, String examPreTime, boolean isOtherClinic);
	
	public String callNuroProcOcsoDoctorChange2(String hospitalCode, String pkout1001, String doctorCode, String clinicCode);
	
	public List<Double> getNuroRES1001U00ReceptionNumber(String hospitalCode, String sessionHospCode, String patientCode, String examPreDate, boolean isOtherClinic);
	
	public String getNuroOUT1001U01LayLastCheckDate(String hospCode, String gubun, String bunho, String date);
	
	public List<NuroOUT1001U01LayoutBarCodeInfo> getNuroOUT1001U01LayoutBarCodeInfo(String hospCode, String language, String bunho); 
	
	public List<NuroOUT1001U01LoadOUT0105Info> getNuroOUT1001U01LoadOUT0105Info(String hospCode, String gongbiCode, String fkout1001);
	
	public String getNuroOUT1001U01GetDbMaxJubsuNo(String hospCode, String bunho, String naewonDate);
	
	public String getNuroOUT1001U01CheckDoctor (String type,String date, String time, String doctor, String hospCode);
	
	public String getNuroOUT1001U01CheckNaewonYn(String bunho, String naewonDate, String gwa, String doctor, String naewonType, String oldJubsuno, String hospCode);
	
	public String getNuroOUT1001U01CheckY(String hospCode, Double pkout1001);


	public String getNuroOUT1001U01GetOut1001Seq(String seqName);
	
	public String getNuroOUT1001U01GetGubunName(String gubun, String naewonDate, String bunho, String hospCode);
	
	public List<NuroRES1001U00ReserListItemInfo> getNuroRES1001U00ReserListItemInfo(String hospitalCode, String sessionHospCode, String language, String patientCode, boolean isOtherClinic);
	
	public List<NuroRES1001U00ReseredDataListItemInfo> getNuroRES1001U00ReseredDataListItemInfo (String hospitalCode, String sessionHospCode, String departmentCode, String doctorCode,
			String examPreDate, String fromTime, String toTime, String reserToTime, boolean isOtherClinic);
	
	public List<NuroRES1001U00DoctorReserListItemInfo> getNuroRES1001U00DoctorReserListItemInfo(String hospitalCode, String sessionHospCode, String language, String patientCode, boolean isOtherClinic, boolean isAllClinic);
	
	public List<OcsoOCS1003P01GridPatientListInfo> getOcsoOCS1003P01GridPatientListInfo(String hospCode, String language, String naewonDate, String naewonYn, String reserYn, 
			String doctorModeYn, String doctor, String bunho);
	
	/**
	 * @param hospCode
	 * @param pkout1001
	 * @return
	 */
	public String getOcsoOCS1003P01CheckY(String hospCode, Double pkout1001);
	public NuroOUT1001U01LoadCheckChojaeJpnInfo getNuroOUT1001U01LoadCheckChojaeJpnInfo(String hospCode, String date, String bunho, String gubun, String gwa, 
			double jubsuNo, String oChojae,String oChtChojae,String oGajubsu_GUBUN,String oErr);
	
	public String checkOcsoOCS1003P01CheckIsSameNameYn(String hospCode, String language, String naewonDate, String gwa, String naewonYn, String reserYn, String doctorModeYn, String doctor, String bunho);
	
	public List<OcsoOCS1003Q05ScheduleItemInfo> getOcsoOCS1003Q05Schedule(String hospCode, String language, String inputGubun, String telYn, String inpuTab,
			String ioGubun, String selectedInputTab, String bunho, String kijun, String naewonDate, String gwa);
	
	public List<NuroNUR1001R00GetTempListItemInfo> getNuroNUR1001R00GetTempListItem(String hospCode, String doctorName, String month, String gwa, String doctor);
	
	public List<OCS0503Q00FilteringTheInformationInfo> getOcsaOCS0503Q00GrdRequestOUT1001List(String hospCode, String language, String bunho, String naewonDate);
	public DrgsDRG5100P01LoadChebangPrintInfo getDrgsDRG5100P01LoadChebangPrintInfo(String hospCode, Double fkOut1001);
	public List<SchsSCH0201U99ReserListInfo> getSchsSCH0201U99ReserListInfo(String hospCode, String bunho);
	
	public String callPrResDoctorScheduleNew(String hospCode, String sessionHospCode, String doctor, String yyMm, String isOtherClinic, String oErr);
	
	public List<OUT1001P01GrdOUT1001ListItemInfo> getOUT1001P01GrdOUT1001(String hospCode, String bunho, Date naewonDate, Double pkout1001, String language);
	
	public String getLastGubun(String hospCode, String bunho, String gwa, String naewonDate);
	
	public String getRecentlyDoctor(String hospCode, String bunho, String gwa, String naewonDate);
	
	public NuroChkGetBunhoBySujinInfo getNuroChkGetBunhoBySujinInfo(String hospCode, String naewonDate, String sujinNo);
	
	public List<String> getNuroLoadTableReserYN(String hospCode, String bunho, String gwa,String naewonDate, String doctor);
	
	public List<OCS1003P01GrdPatientListItemInfo> getOCS1003P01GrdPatientListItem(String hospCode, Date naewonDate, String naewonYn, String reserYn, String doctorModeYn, String doctor, String bunho, String language);
	
	public String callFnOcsGetNotapproveOrdercnt(String hospCode, String ioGubun, String insteadYn, String approveYn, String doctorId, String key);
	
	public String getOcsLibNaewonYNInfo1(String hospCode, String bunho, Date naewonDate, Double pkout1001);
	
	public String getOcsLibNaewonYNInfo2(String hospCode ,Double pkout1001);
	
	public List<LoadPatientNaewonListInfo> getLoadPatientNaewonListItem(String hospcode, String language, String approveDoctor, String doctorModeYn,
	String ioGubun, String pkKeyOut, String bunho, String naewonDate, String gwa, String doctor, String jaewonFlag, String pkKeyInp, String isEnableIpwonReser);
	
	public Integer getOutTaGwaJinryoCnt(String hospCode, String bunho, String gwa, Date naewonDate);
	
	public List<OcsoOCS1003P01LayPatInfo> getOcsoOCS1003P01LayPatInfo(String hospCode, String language, String doctor, String bunho, String naewonDate, String loginDoctorYn);
	
	public List<OCS1003Q02GridOUT1001Info> getOCS1003Q02GridOUT1001(String hospCode, String language, Date naewonDate,
			String bunho, String gwa, String doctor, String naewonYn);
	
	public List<OCS1003Q09GridOUT1001Info> getOCS1003Q09GridOUT1001ListItem(String hospCode, String language, String kijun, String inputGubun, String telYN,
			String inputTab, String ioGubun, String selectedInputTab, String bunho, Date naewonDate, String gwa);
	
	public List<String> getReserMoveName(String hospCode, String language, String bunho, Date reserDate, String gwa);
	
	public String callPrOutChangeGwaDoctor(String hospCode, String bunho, String pkout1001, String toGwa, String toDoctor, String userId);
	public PHY2001U04PrOutMakeAutoJubsuInfo callPrOutMakeAutoJubsuInfo(String hospCode, Double iSourcePkKey, 
			String iGwa, String iDoctor, String iJubsuGubun, String iUserId);
	public List<PHY2001U04BtnDeleteGetDataTableInfo>  getPHY2001U04DeleteClickInfo(String hospCode, String language, String bunho, Double pkOut1001);
	public String callFnPhyDupJubsuGubun(String hospCode, String jubsuGubun, String bunho, String gwa, Date naewonDate);
	public List<PHY2001U04GrdPaCntInfo> getPHY2001U04GrdPaCntInfo(String hospCode, String language, Date naewonDate);
	public List<PHY2001U04RefreshCounterInfo> getPHY2001U04RefreshCounterInfo(String hospCode, String gwa, Date naewonDate);
	public List<PHY2001U04GrdOut1001Info> getPHY2001U04GrdOut1001Info(String hospCode, String language, String gwa, String bunho,Date naewonDate);
	public List<PHY2001U04GrdPatientListInfo> getPHY2001U04GrdPatientListInfo(String hospCode, String language, String naewonDate,
			String gwa, String doctor, String bunho, String jubsuGubun, String jinryoYn, String naewonYn, String userId);
	public List<PHY2001U04GrdExcelInfo> getPHY2001U04GrdExcelInfo(String hospCode, String langauge, String naewonDate, String gwa,
			String doctor, String bunho, String jubsuGubun, String jinryoYn, String naewonYn);
	
	public List<OCS3003Q10GrdOrderDateListItemInfo> getOCS3003Q10GrdOrderDateListItemInfo(String hospCode, String language, String ioGubun, String bunho,
			String orderDate, String orderGubun);
	
	public List<OCS2015U04LoadExaminationInfo> getOCS2015U04LoadExaminationInfo (String hospCode, String patientCode);
	
	public String getFnOutCheckNaewonYn(String hospCode, Double fkout1001);
	
	public String callPrNurChangeBunho(String hospCode, String ioGubun, String fromBunho, Double naewonKey, String toBunho, String userId);
	public List<RES1001R00BookingInfo> getRES1001R00BookingInfo(String hospCode, String language, String bunhoLink, String gwa, String doctor, Date naewonDate, String jubsuTime );
	public List<RES1001U01BookingClinicReferInfo> getRES1001U01BookingClinicReferInfo(String naewonDate, String hospCode, String gwa,String doctor);

	public List<BookingLabInfo> getBookingLabInfo(String doctor, String gwa,String bunho, String hospCode, String nawon, String reserTime);

	public String getGubun(String pkOUT1001, String hospCode);
	public List<KCCKCountTotalOfBookingInfo> getKCCKCountTotalOfBookingInfo(String hospCode, String doctor, Date startDate, Date endDate);
	
	public List<ADM9999U00GetInformInfo> getADM9999U00GetInformInfo(BigInteger id);
	
	public List<CreatePatientSurveyInfo> getPatientSurveyInfo(String hospCode);

	public List<BookingExamInfo> getPatientSurveyInfo(String hospCode, String pkout1001, String language);

	public List<NUR2016U02ActingDateAndSendYnInfo> getNUR2016U02ActingDateAndSendYn(String hospCode, List<String> bunho);

	public List<NUR2015U01GrdOrderInfo> getNUR2015U01GrdOrderInfo(String hospCode, String bunho, String language);
	
	public List<SyncDrugInfo> getDrugInfo(String hospCode, String patientCode, String language);
	
	public List<ComboListItemInfo> getRES1001U00CheckDuplicate(String hospitalCode, String sessionHospCode, String patientCode, String departmentCode, String examPreDate, 
			String examPreTime, String language, boolean isOtherClinic);
	public List<MedicalInfo> getExaminationFee(String hospCode, String bunho, Double pkout1001);
	public List<LoadGridBIL2016U02Info> getInvoiceUnPayForAdmissionFeeDetailList(String hospCode, String language, String bunho, Double pkout1001, String bunhoType);
	
	public List<OCS1003P01GrdPatientListItemInfo> getOCS2015U21GrdPatientListItem(String hospCode, Date naewonDate, String naewonYn, String reserYn, String doctorModeYn, String doctor, String bunho, String language, String gwa);
	
	public String getNURILIBwonyoiYn(String hospCode, String bunho, String naewonDate, String jubsuTime);
}

