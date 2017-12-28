package nta.med.data.dao.medi.inp;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.BAS0250Q00layJaewonListInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint1Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint2Info;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.inps.INP1001D00grdINP1001Info;
import nta.med.data.model.ihis.inps.INP1001D01grdINP1001Info;
import nta.med.data.model.ihis.inps.INP1001Q00grdINP1001Info;
import nta.med.data.model.ihis.inps.INP1001R04grdIpToiListInfo;
import nta.med.data.model.ihis.inps.INP1001U01DoubleGrdINP1002Info;
import nta.med.data.model.ihis.inps.INP1001U01DoubleGrdINP1008Info;
import nta.med.data.model.ihis.inps.INP1001U01DoubleLoadDataInfo;
import nta.med.data.model.ihis.inps.INP1001U01EtcIpwongrdHistoryInfo;
import nta.med.data.model.ihis.inps.INP1001U01GrdInp1001Info;
import nta.med.data.model.ihis.inps.INP1001U01GrdOut0103Info;
import nta.med.data.model.ihis.inps.INP1001U01GrdOut0106Info;
import nta.med.data.model.ihis.inps.INP1001U01IpwonSelectFormgrdIpwonHistoryInfo;
import nta.med.data.model.ihis.inps.INP1001U01LayInp1002Info;
import nta.med.data.model.ihis.inps.INP1001U01LoadIpwonTypeListInfo;
import nta.med.data.model.ihis.inps.INP1001U01ReserSelectgrdINP1003Info;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangedrtnresultInfo;
import nta.med.data.model.ihis.inps.INP3003U00grdINP1001Info;
import nta.med.data.model.ihis.inps.INP3003U00grdINP1001PastInfo;
import nta.med.data.model.ihis.inps.INP3003U00layLoadToiwonResDateInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL0AfterTransInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL0BeforeTransInfo;
import nta.med.data.model.ihis.inps.PrIfsMakeIpwonHistoryResultInfo;
import nta.med.data.model.ihis.inps.PrInpMakePkinp1002;
import nta.med.data.model.ihis.nuri.NUR1001R07grdInp1001Info;
import nta.med.data.model.ihis.nuri.NUR1001R09grdINP1001Info;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdINP1001Info;
import nta.med.data.model.ihis.nuri.NUR1010Q00ChangeHosilSelect1Info;
import nta.med.data.model.ihis.nuri.NUR1010Q00MoveHosilSelect1Info;
import nta.med.data.model.ihis.nuri.NUR1010Q00SelectDokboInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00grdGwaCountInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00grdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR1020Q00layIpwonInfoInfo;
import nta.med.data.model.ihis.nuri.NUR1020U00grdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR1035U00grdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR1094U00GrdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdBedSoreInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdGuhoGubunInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdGwaInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdIpToiInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdSusulInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00grdTransInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layGamyumCntInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layPatientInfoInInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layPatientInfoInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layStairCntInfo;
import nta.med.data.model.ihis.nuri.NUR5020U00layTotalCntInfo;
import nta.med.data.model.ihis.nuri.NUR8003R02grdPayloadDataInfo;
import nta.med.data.model.ihis.nuri.NUR8003U03GrdPalistInfo;
import nta.med.data.model.ihis.nuri.NUR8050U00grdNur8050AllInfo;
import nta.med.data.model.ihis.nuri.NUR9001U00grdPalistInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U99grdInp1001Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10LoadIpwonLstInfo;
import nta.med.data.model.ihis.system.PrOcsLoadIpwonInfo;

/**
 * @author dainguyen.
 */
public interface Inp1001RepositoryCustom {
	public Integer getFnInpLoadJaewonIlsu(String hospCode, Double naewonKey, Date orderDate);

	public PrOcsLoadIpwonInfo callPrOcsLoadIpwonInfo(String hospCode, Date naewonDate, Integer fkinp1001,
			String jaewinFlag);

	public String callFnOcsDupInpOrderCheck(String hospCode, String language, String bunho, Integer fkInp1001,
			String orderDate, String hangmogCode, String hopeDate);

	public List<ComboListItemInfo> getPkinp1001JaewonFlag(String hospCode, String bunho, Date ipwonDate);

	public String callFnInpLoadJaewonHoDong(String hospCode, String bunho);

	public String callFnInpLoadLastIpwonDate(String hospCode, String bunho);

	public List<INP1001Q00grdINP1001Info> getINP1001Q00grdINP1001Info(String hospCode, String bunho, Date fromDate,
			Date toDate, String language, Integer startNum, Integer offset);

	public List<INP1001D01grdINP1001Info> getINP1001D01grdINP1001Info(String hospCode, String language, Date queryDate,
			String hoDong, String suname);

	public List<INP1001R04grdIpToiListInfo> getINP1001R04grdIpToiListInfo(String hospCode, String language,
			String hoDong, Date fromDate, Date toDate, Integer startNum, Integer offset);

	public List<INP3003U00layLoadToiwonResDateInfo> getINP3003U00layLoadToiwonResDateInfo(String hospCode,
			Double pkinp1001);

	public String getINP1001simsaMagam(String hospCode, String pkInp1001);

	public List<INP1001U01GrdInp1001Info> getINP1001U01GrdInp1001Info(String hospCode, String language,
			Double pkinp1001, Integer startNum, Integer offset);

	public List<INP3003U00grdINP1001Info> getINP3003U00grdINP1001Info(String hospCode, String language,
			Double pkinp1001, Integer startNum, Integer offset);

	public List<INP3003U00grdINP1001PastInfo> getINP3003U00grdINP1001PastInfo(String hospCode, String language,
			String bunho, Integer startNum, Integer offset);

	public List<INP1001U01EtcIpwongrdHistoryInfo> getINP1001U01EtcIpwongrdHistoryInfo(String hospCode, String bunho,
			Integer startNum, Integer offset);

	public String getINP3003U00ToiwonCancelGrdMasterItem(String hospCode, Double pkinp1001);

	public List<INP1001U01GrdOut0103Info> getINP1001U01GrdOut0103Info(String hospCode, String language, String bunho,
			Integer startNum, Integer offset);

	public List<INP1001U01GrdOut0106Info> getINP1001U01GrdOut0106Info(String hospCode, String language, String bunho,
			String ipwonDate, Integer startNum, Integer offset);

	public List<INP1001U01LayInp1002Info> getINP1001U01LayInp1002Info(String hospCode, Double fkInp1001);

	public List<INP1001U01LoadIpwonTypeListInfo> getINP1001U01LoadIpwonTypeListInfo(String hospCode, String language,
			String bunho);

	public String checkExistsInpOrder(String hospCode, String bunho, double pkInp1001);

	public String getAgeByBirth(String birth);

	public List<ComboListItemInfo> getComboChangeGubunInp1001U01(String hospCode, String language, String bunho,
			String gubun, Date naewonDate);

	public List<ComboListItemInfo> getInfoToCheckPatientInHospital(String hospCode, String bunho, Date ipwonDate);

	public Integer checkJubsuCnt(String hospCode, String bunho, Date naewonDate);

	public String callFnInpJaewonHistoryCheck(String bunho, Date queryDate);

	public PrInpMakePkinp1002 callPrInpMakePkinp1002(String fkinp1001, String gubun, String hospCode);

	public PrIfsMakeIpwonHistoryResultInfo callPrIfsMakeIpwonHistory(String hospCode, String procGubun, String bunho,
			Date dataDate, String hoDong, String hoCode, String bedNo, String ipwonGwa, String doctor, Double fkinp1001,
			String userId, String dataGubun, String toiwonGubun);

	public String callPrInpToiwonCancel(String hospCode, Integer pkinp1001, String userId);

	public CommonProcResultInfo callPrInpProcessToiwon(String hospCode, String userId, Double pkinp1001,
			String simsaMagamDate, String simsaMagamTime, String simsaMagamYn, String toiwonDate, String toiwonTime,
			String gaToiwonDate);

	public List<Double> getListPkinp1001(String hospCode, Double pkinp1001);

	public List<INP1001U01IpwonSelectFormgrdIpwonHistoryInfo> getINP1001U01IpwonSelectFormgrdIpwonHistoryInfo(
			String hospCode, String language, String bunho, Integer startNum, Integer offset);

	public String getCallFnInpJaewonCheck(String hospCode, String bunho);

	public List<INP1003U00grdInpReserGridColumnChangedrtnresultInfo> getINP1003U00grdInpReserGridColumnChangedrtnresultInfo(
			String hospCode, String bunho);

	public List<INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo> getINP1003U00grdInpReserGridColumnChangedrtndoctornameInfo(
			String hospCode, String jisiDoctor, String reserDate);

	public CommonProcResultInfo callPrInpUpdateIpwonDate(String hospCode, String userId, Double pkinp1001,
			Date fromIpwonDate, Date toIpwonDate, String fromIpwonTime, String toIpwonTime, String fromIpwonGasan,
			String toIpwonGasan);

	List<INP1001U01DoubleLoadDataInfo> getINP1001U01DoubleLoadDataInfo(String hospCode, String bunho, String ipwonType);

	public CommonProcResultInfo callPrInpCheckIpwonTrans(String hospCode, String bunho, Date ipWonDate);

	public CommonProcResultInfo callPrInpIpwonCancel(String hospCode, String userId, Double pkinp1001, Date junpyoDate);

	public CommonProcResultInfo callPrInpUpdateOut0103(String hospCode, String user, Date naewondate, String bunho,
			String gwa, String gubun, String doctor, String inOut, String jubsuGwa, Integer tuyakIlsu, String specialYn,
			Date toiwonDate);

	public boolean callPrOcsInitCreateSiksa(String hospCode, Double pkInp1001, String bunho, Date ipwonDate,
			String iudGubun, String language);

	public CommonProcResultInfo callPrInpMakePkinp1002(Integer fkInp1001, String gubun, String hospCode);

	public CommonProcResultInfo callPrOcsUpdateInpOrderRes(String hospCode, String inputId, String bunho,
			Integer fkinp1001);

	public List<INP1001Q00grdINP1001Info> getINP1001U00Pkinp1001JaewonFlagInfo(String hospCode, String bunho,
			String ipwonDate);

	public List<INP1001U01ReserSelectgrdINP1003Info> getINP1001U01ReserSelectgrdINP1003Info(String hospCode,
			String language, String bunho, Integer offset);

	public List<INP1001U01DoubleGrdINP1008Info> getINP1001U01DoubleGrdINP1008Info(String hospCode, Double pkinp1002,
			String language, String bunho, String dataGubun, Date gubunIpwonDate, Date ipwonDate, Integer page_number,
			String offset);

	public List<INP1001U01DoubleGrdINP1002Info> getINP1001U01DoubleGrdINP1002Info(String hospCode, Double pkinp1002,
			String language, String bunho, String exitType, Date ipwonDate);

	public String inpIsValidGisanDate(String hospCode, Date gisanIpwonDate, Date ipwonDate, String bunho);

	public String inp1001U01checkIsExist(String hospCode, String hoDong, String hoCode, String bedNo);

	public Double getListPkinp1001(String hospCode, String bunho);

	public Integer updateInp1001U01DoubleSaveLayout(String hospCode, String userId, String ipwonTime, String ipwonGwa,
			String gwa, String doctor, String resident, String hoCode1, String hoDong1, String hoGrade1, String hoCode2,
			String hoDong2, String ipwonRtn2, String chojea, String babyStatus, String inpTransYn, Double fkout1001,
			String jaewonFlag, String toiwonGojiYn, String toiwonResDate, String gaToiwonDate, String toiwonDate,
			String toiwonTime, String result, String sigiMagamYn, String cancelDate, String cancelUser, String cancelYn,
			Double fkinp1003, String team, String ipwonDate, String bedNo, String gisanJaewonIlsu, String jisiDoctor,
			Double pkinp1001);

	public String callFnAdmIsSameNameYnInpT(String bunho, String hospCode);

	public String callPrOcsSetCycleOrderGroup(String hospCode, String bunho, String color);

	public List<OCS6010U10LoadIpwonLstInfo> getOCS6010U10LoadIpwonLstInfo(String hospCode, String language,
			String bunho);

	public List<OCS2003U99grdInp1001Info> getOCS2003U99grdInp1001Info(String hospCode, String fkinp1001);

	public String getOCS2003U99layCheckDupRequest(String hospCode, String bunho);

	public String getIudGubun(String hospCode, String fkinp1001);

	public String getOCS2003U99DoctorRequest(String hospCode, String pkinp1001);

	public List<BAS0250Q00layJaewonListInfo> getBAS0250Q00layJaewonListInfoList(String hospCode, String hoDong,
			String language);

	public List<DataStringListItemInfo> getPkInp1001Ocs2005U02(String hospCode, String bunho, String jaewonYn);

	public List<DataStringListItemInfo> getInpwonDateOcs2005U02(String hospCode, String bunho, String jaewonYn);

	public String OCS2005U02GetToiwonDate(String hospCode, Double pkinp1001);

	public String getIsJaewonPatientInfo(String bunho, String hospCode);

	public List<INPORDERTRANSSelectListSQL0BeforeTransInfo> getINPORDERTRANSSelectListSQL0BeforeTransInfo(
			String hospCode, String language, String bunho, Date orderFromDate, Date orderToDate);

	public List<INPORDERTRANSSelectListSQL0AfterTransInfo> getINPORDERTRANSSelectListSQL0AfterTransInfo(String hospCode,
			String language, String bunho, Date orderFromDate, Date orderToDate);

	public String getHoDongByHospCodeAndBunho(String hospCode, String bunho);

	public String getToiwonGojiYnFromOcs2003Inp1001(String hospCode, Double fkocs2003);

	public String callPrDrgInpDrgBunhoCancel(String hospCode, Date jubsuDate, Double drgBunho, String userId);

	public List<DRG3010P10DsvOrderPrint1Info> getDRG3010P10DsvOrderPrint1Info(String hospCode, String language,
			Date jubsuDate, Double drgBunho);

	public List<DRG3010P10DsvOrderPrint2Info> getDRG3010P10DsvOrderPrint2Info(String hospCode, String language,
			String serialText, String jubsudate, Double drgBunho);

	public List<INP1001D00grdINP1001Info> getINP1001D00grdINP1001Info(String hospCode, String language, String hoDong1,
			String sendYn, String queryDate);

	public String getNUR2004U01GetSubConfirmData1(String hospCode, Double fkinp1001);

	public String getNUR2004U01GetSubConfirmData3(String hospCode, String toHoDong1, String toHoCode1, String toBedNo,
			String bunho, String changeGubun);

	public List<ComboListItemInfo> getNUR6011U01IsJaewon(String hospCode, String bunho);

	public String getNUR6011U01GetNurseInfoIpwonDate(String hospCode, Double fkinp1001);

	public String getNUR6011U01fwkAssessorHoDong1(String hospCode, String bunho);

	public List<NUR1020U00grdPalistInfo> getNUR1020U00grdPalistInfo(String hospCode, String hoDong, String fDate,
			String fa, String fb, String fc, String fd);

	public String getNUR1020U00Pkinp1001(String hospCode, String bunho);

	public String getVwOcsInp1001BedNo2ByHospCodePkinp1001(String hospCode, Double pkinp1001);

	public String getNUR2004U00CheckPreInsert4(String hospCode, String hoDong1, String hoCode1, String bedNo,
			String bunho);

	public String callFnInpLoadSimaYn(String hospCode, Double pkinp1001);

	public List<NUR1010Q00grdGwaCountInfo> getNUR1010Q00grdGwaCountInfo(String hospCode, String hoDong);

	public List<NUR1010Q00SelectDokboInfo> getNUR1010Q00SelectDokboInfo(String hospCode, String hoDong);

	public String checkNUR1010Q00ChangeMoveHosilCheck2(String hospCode, String bedNo, String fromHoCode,
			String fromHoDong, Double fkinp1001);

	public String checkNUR1010Q00MoveHosilCheck3(String hospCode, String toBedNo, String toHoCode, String toHoDong);

	public List<NUR1010Q00MoveHosilSelect1Info> getNUR1010Q00MoveHosilSelect1Info(String hospCode, Double fkinp1001);

	public List<NUR1010Q00ChangeHosilSelect1Info> getNUR1010Q00ChangeHosilSelect1Info(String hospCode,
			Double fkinp1001);

	public List<NUR1001R09grdINP1001Info> getNUR1001R09grdINP1001Info(String hospCode, String language, String hoDong,
			String gwa, Integer startNum, Integer offset);

	public List<NUR1001R07grdInp1001Info> getNUR1001R07grdInp1001Info(String hospCode, String language, String bunho,
			Integer startNum, Integer offset);

	public List<NUR1035U00grdPalistInfo> getNUR1035U00grdPalistInfo(String hospCode, String hoDong, String date,
			String a, String b, String c, String d, Integer startNum, Integer offset);

	public Double getPkinp1001ByHospCodeBunho(String hospCode, String bunho);

	public Double getPkinp1001ByHospCodeBunhoJaewonFlagCancelYn(String hospCode, String bunho);

	public List<NUR1020Q00grdPalistInfo> getNUR1020Q00grdPalistInfo(String hospCode, String hoDong, String fDate,
			String fa, String fb, String fc, String fd, Integer startNum, Integer offset);

	public List<NUR1020Q00layIpwonInfoInfo> getNUR1020Q00layIpwonInfoInfo(String hospCode, String bunho);

	public List<ComboListItemInfo> getNUR1001U00LayFkinp1001Info(String hospCode, String bunho);

	public List<NUR1001U00GrdINP1001Info> getNUR1001U00GrdINP1001Info(String hospCode, String bunho, Integer startNum,
			Integer offset);

	public String getNUR9001U00fkInp1001(String hospCode, String bunho, String toDate);

	public List<NUR9001U00grdPalistInfo> getNUR9001U00grdPalistInfo(String hospCode, String hoDong, String date,
			String a, String b, String c, String d, Integer startNum, Integer offset);

	public List<NUR8003R02grdPayloadDataInfo> getNUR8003R02grdPayloadDataInfo(String hospCode, String language,
			String needHType, String fromDate, String toDate, String hoDong, String bunho);

	public List<NUR1094U00GrdPalistInfo> getNUR1094U00GrdPalistInfo(String hospCode, String hoDong, String fDate,
			String fa, String fb, String fc, String fd);

	public List<NUR8003U03GrdPalistInfo> getNUR8003U03GrdPalistInfo(String hospCode, String hoDong, String fDate,
			String fa, String fb, String fc, String fd);

	public String callFnInpLoadKaikeiHodongHis(String hospCode, Double pkinp1001, Date jukyongDate);

	public List<NUR8050U00grdNur8050AllInfo> getNUR8050U00grdNur8050AllInfo(String hospCode, Date fdate);

	public List<NUR5020U00grdGuhoGubunInfo> getNUR5020U00grdGuhoGubunInfoMode1(String hospCode, String hoDong,
			String date, Integer startNum, Integer offset);

	public List<NUR5020U00layTotalCntInfo> getNUR5020U00layTotalCntInfo(String hospCode, String hoDong, String fdate);

	public List<NUR5020U00layStairCntInfo> getNUR5020U00layStairCntInfo(String hospCode, String hoDong, Date fdate);

	public List<NUR5020U00grdIpToiInfo> getNUR5020U00grdIpToiInfoCase1(String hospCode, String language, Date fDate,
			String hoDong);

	public List<NUR5020U00grdIpToiInfo> getNUR5020U00grdIpToiInfoCase2(String hospCode, String language, Date fDate,
			String hoDong);

	public List<NUR5020U00layPatientInfoInInfo> getNUR5020U00layPatientInfoInInfo(String hospCode, String bunho,
			Date nurWrdt);

	public List<NUR5020U00layPatientInfoInInfo> getNUR5020U00layPatientInfoInInfoCase2(String hospCode, String bunho,
			Date nurWrdt);

	public List<NUR5020U00layPatientInfoInfo> getNUR5020U00layPatientInfoInfo(String hospCode, String bunho,
			Date nurWrdt);

	public List<NUR5020U00layGamyumCntInfo> getNUR5020U00layGamyumCntInfo(String hospCode, String hoDong, Date fDate);

	public List<NUR5020U00grdBedSoreInfo> getNUR5020U00grdBedSoreInfoCase1(String hospCode);

	public List<NUR5020U00grdBedSoreInfo> getNUR5020U00grdBedSoreInfoCase2(String hospCode, String hoDong, Date fDate);

	public List<NUR5020U00grdGwaInfo> getNUR5020U00grdGwaInfoCase1(String hospCode, String hoDong);
	
	public List<NUR5020U00grdGwaInfo> getNUR5020U00grdGwaInfoCase2(String hospCode, String hoDong, Date fDate);
	
	public List<NUR5020U00grdSusulInfo> getNUR5020U00grdSusulInfoCase1(String hospCode, String language, String hoDong, Date fDate);
	
	public List<NUR5020U00grdSusulInfo> getNUR5020U00grdSusulInfoCase2(String hospCode, String language, String hoDong, Date fDate);
	
	public List<NUR5020U00grdTransInfo> getNUR5020U00grdTransInfoCase1(String hospCode, String language, String hoDong, Date fDate);
	
	public List<NUR5020U00grdTransInfo> getNUR5020U00grdTransInfoCase2(String hospCode, String language, String hoDong, Date fDate);
}
