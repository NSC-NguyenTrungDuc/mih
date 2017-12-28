package nta.med.data.dao.medi.out;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.out.Out0101;
import nta.med.data.model.ihis.bass.INP1003ChkBunhoListItemInfo;
import nta.med.data.model.ihis.bass.Inp1003U00GrdInpReserListItem;
import nta.med.data.model.ihis.clis.CLIS2015U03PatientListInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00SelectOUT0101ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00GrdPaListItemInfo;
import nta.med.data.model.ihis.cpls.MultiResultViewLayPaInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LoadMakayJungboInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetPatientInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001FormJusaBedLayPatientItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01TempListItemInfo;
import nta.med.data.model.ihis.inps.INP1003U00SaveLayoutChkBunhoInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangeddtBunhoInfo;
import nta.med.data.model.ihis.inps.INP1003U01layBunhoValidationInfo;
import nta.med.data.model.ihis.inps.INPBATCHTRANSlayOut0101Info;
import nta.med.data.model.ihis.nuri.NUR1001U00LayINP1001Info;
import nta.med.data.model.ihis.nuri.NUR2004U00layCurrentBedInfo;
import nta.med.data.model.ihis.nuro.NUR2016Q00GrdPatientListInfo;
import nta.med.data.model.ihis.nuro.NuroManagePatient;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridBoheomInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridCommentInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridGongbiListInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridPatientInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02HospitalItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02LayDupPatientInfo;
import nta.med.data.model.ihis.nuro.NuroSearchPatientInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSLayOut0101Info;
import nta.med.data.model.ihis.nuro.OUT0101Q01GrdPatientListInfo;
import nta.med.data.model.ihis.nuro.OUT0101U02PatientExportInfo;
import nta.med.data.model.ihis.nuro.OUT1001P03BunhoListItemInfo;
import nta.med.data.model.ihis.nuro.OUT1001P03GrdAfterJubsuInfo;
import nta.med.data.model.ihis.nuro.OUT1001P03GrdBeforeJubsuInfo;
import nta.med.data.model.ihis.nuro.OUT1001R01LayOut0101Info;
import nta.med.data.model.ihis.nuro.PatientDetailInfo;
import nta.med.data.model.ihis.nuro.RES1001R00PatientNameInfo;
import nta.med.data.model.ihis.ocsa.OCS0503Q00LoadConsultInfo;
import nta.med.data.model.ihis.ocsa.OCSAPPROVEGrdPatientListInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02grdPatientListInfo;
import nta.med.data.model.ihis.ocso.OCS1003R00LayOUT1001Info;
import nta.med.data.model.ihis.ocso.OCS1003R02DTListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003R02LayR03ListInfo;
import nta.med.data.model.ihis.ocso.OCSACT2GetPatientListOCSInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdOrderInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdPaListInfo;
import nta.med.data.model.ihis.schs.SCH0201U99BookingDetailInfo;
import nta.med.data.model.ihis.schs.Schs0201U99InsertResultInfo;
import nta.med.data.model.ihis.system.FindPatientInfo;
import nta.med.data.model.ihis.system.LoadPatientBaseInfo;
import nta.med.data.model.ihis.system.PatientAccountInfo;
import nta.med.data.model.ihis.system.PatientByCodeInfo;
import nta.med.data.model.ihis.system.PrOcsLoadNaewonInfo;
import nta.med.data.model.ihis.system.XPaInfoBoxInfo;
/**
 * @author dainguyen.
 */
public interface Out0101RepositoryCustom {
	
	public List<NuroSearchPatientInfo> getNuroSearchPatientInfo(String hospCode, String patientCode);
	
	public List<NuroManagePatient> getNuroManagePatientInfo(String hospCode,String language, String patientCode);
	
	public List<PatientByCodeInfo> getGetPatientByCode(String hospCode, String patientCode, String language);
	
	public Integer updateNuroPatientInfo(String hospCode, String patientCode, String zipCode1, String zipCode2, String address1, String address2,
			String tel, String tel1, String telHp, String telGubun, String telGubun2, String telGubun3, String email, String paceMakerYn, String selfPaceMaker)  throws Exception;
	
	public List<FindPatientInfo> getFindPatientInfo(String hospCode, String language, String patientName2, String sex, String birth, String tel, String type, Integer startNum, Integer offset);
	
	public List<XPaInfoBoxInfo> getXPaInfoBoxInfo(String hospCode, String patientCode, String language);
	
	public List<NuroOUT0101U02GridCommentInfo> getOUT0101U02GridCommentInfo (String hospCode, String patientCode);
	
	public List<NuroOUT0101U02GridBoheomInfo> getNuroOUT0101U02GridBoheomInfo (String language, String hospCode, String patientCode);
	
	public List<NuroOUT0101U02GridGongbiListInfo> getNuroOUT0101U02GridGongbiListInfo(String hospCode, String patientCode, String language);
	
	public List<NuroOUT0101U02GridPatientInfo> getNuroOUT0101U02GridPatientInfo(String hospCode, String patientCode, String language);
	
	public List<NuroOUT0101U02LayDupPatientInfo> getNuroOUT0101U02LayDupPatientInfo(String hospCode,String language, String suname2, String birth,String sex,String codeType);
	
	public String getNuroOUT0101U02GetBirthDay(String sysDate, String birth);
	
	public String getNuroOUT0101U02CheckExistsX(String hospCode, String bunho);
	
	public List<InjsINJ1001U01TempListItemInfo> getInjsINJ1001U01TempListItemInfo (String hospitalCode, String language,
			String bunho,	String doctor, Date reserDate, Date jubsuDate);
	
	public List<OCS0503Q00LoadConsultInfo> getOCS0503Q00GrdConsultList(String hospCode, String language, String doctor,
			String fromDate, String toDate, String answerYn, String ioGubun, String gwaConsultYn, String naewonYn);
	
	public List<OCS0503Q00LoadConsultInfo> getOcsaOCS0503Q00GrdRequestList(String hospCode, String language, String doctor,
			String fromDate, String toDate, String answerYn, String ioGubun, String gwaConsultYn, String naewonYn);
	
	public DrgsDRG5100P01LoadMakayJungboInfo getDrgsDRG5100P01LoadMakayJungboInfo(String hospCode, String language,
			String ioGubun, Date jubsuDate, Double drgBunho);
	
	public String getNuroOUT0101U02CheckExistsY(String hospCode, String bunho);
	public List<CPL3020U00GrdPaListItemInfo> getGrdPaListItem(String hospCode, String jundalGubun, String gubun, String fromDate, String toDate);
	public List<CPL0000Q00SelectOUT0101ListItemInfo> getCPL0000Q00SelectOUT0101ListItemInfo(String hospCode, String bunho);
	public List<InjsINJ1001FormJusaBedLayPatientItemInfo> getInjsINJ1001FormJusaBedLayPatientItemInfo(String hospCode, String language);
	public List<OUT0101Q01GrdPatientListInfo> getOUT0101Q01GrdPatientListInfo(String hospCode,String language,String suname2,String sex,
			Date birth,String tel,  Integer startNum, Integer offset);
	
	public String OCSLibOrderBizGetIsToiwonGojiYNandEndOrder(String hospCode, Double pkinp1001);
	public LoadPatientBaseInfo callPrOcsLoadBunhoInfo(String hospCode, Date naewonDate, String bunho);
	public PrOcsLoadNaewonInfo callPrOcsLoadNaewonInfo(String hospCode, Double pkKey);
	
	public List<OCSAPPROVEGrdPatientListInfo> getOCSAPPROVEGrdPatientListItem(String hospCode, String language,
			String inputGubun, String ioGubun, String doctor, String insteadYn, String approveYn, String inputTab);
	
	public String getIsJaewonPatientInfo(String bunho, String hospCode);
	public List<Inp1003U00GrdInpReserListItem> getInp1003U00GrdInpReserListItem(String hospCode, String language, Date reserDate, String hoDong);
	public List<ComboListItemInfo> getSurnameTelListItemInfo (String hospCode, String bunho);
	public List<INP1003ChkBunhoListItemInfo> getINP1003ChkBunhoListItemInfo(String hospCode, String language, String bunho);
	public List<OCS1003R00LayOUT1001Info> getOCS1003R00LayOUT1001Info(String hospCode,String language,String inputGubun,
			Date naewonDate,String bunho,String gwa,String doctor,String naewonType,String jubsuNo);
	
	public List<OCSACTGrdPaListInfo> getOCSACTGrdPaListInfo(String hospCode,String language,String bunho,
			Date fromDate,Date toDate,String actGubun,String code,List<String> jundalPartParam,String iOGubun );
	public List<OCSACTGrdOrderInfo> getOCSACTGrdOrderInfo (String hospCode, String language, String bunho, String dataValue, 
			List<String> jundalPartParam, String ioGubun, Date fromDate, Date toDate, String gwa, 
			String doctor, boolean rbxNonAct, boolean rbxAct);
	
	public List<MultiResultViewLayPaInfo> getMultiResultViewLayPaInfo(String hospCode, String bunho, String language);
	public ComboListItemInfo getPatientCodeName (String bunho);
	public List<ORDERTRANSLayOut0101Info> getORDERTRANSLayOut0101Info(String hospCode, String language, String bunho);
	public List<OCS1003R02DTListItemInfo> getOCS1003R02DTListItemInfo(String hospCode, String language, String gwa, 
			String naewonDate, String bunho, String doctor, String naewonType, String jubsuNo);
	
	public List<OUT1001R01LayOut0101Info> getOUT1001R01LayOut0101Info(String hospCode, String bunho, String language);
	public List<OUT1001P03BunhoListItemInfo> getOUT1001P03BunhoListItemInfo(String hospCode, String language);
	
	public List<OUT1001P03GrdBeforeJubsuInfo> getOUT1001P03GrdBeforeJubsuInfo(String hospCode, String language, String ioGubun, String bunho);
	public List<OUT1001P03GrdAfterJubsuInfo> getOUT1001P03GrdAfterJubsuInfo(String hospCode, String language, String ioGubun, String bunho);
	public List<OCS1003R02LayR03ListInfo> getOCS1003R02LayR03ListInfo(String hospCode, String langauge, String gwa, String naewonDate, String bunho);
	public List<CLIS2015U03PatientListInfo> getCLIS2015U03PatientListInfo(Integer protocolId);
	public List<CLIS2015U03PatientListInfo> getCLIS2015U03SearchPatient(String hospCode, String sex, Integer fromAge, Integer toAge, 
			Date naewonDateFrom, Date naewonDateTo, String makerYn, String join, String filterStringOutsang, 
			String filterStringOcs1003, String filterStringView, String filterStringEmr, 
			String filterCommandOutsang, String filterCommandOcs1003, String filterCommandView);
	public String getLatestBunho();
	public OCS2015U00GetPatientInfo getOCS2015U00GetPatientInfo(String hospCode, String bunho);
	public List<RES1001R00PatientNameInfo> getRES1001R00PatientName(String hospCode, String bunho);
	public List<NUR2016Q00GrdPatientListInfo> getNUR2016Q00GrdPatientListInfo(String hospCode, String sunName, String sunName2, String address, Date birth,
																			  Integer startNum, Integer offset, String sesionHospCode, String bunho);
	
	public List<NuroOUT0101U02HospitalItemInfo> getNuroOUT0101U02HospitalListInfo(String hospitalCode, String language, String bunho);
	public List<SCH0201U99BookingDetailInfo> getSCH0201U99BookingDetailInfo(String hospCode, String language, String reservation, String jundalTable, String jundalPart, Date reserDate, List<String> bunho, List<String> hospCodeLink);

	public List<Schs0201U99InsertResultInfo> getSchs0201U99InsertResultInfo(String hospCode, String pkOut);
	
	public PatientAccountInfo verifyPatientAccount(String username, String password, String hospCode);
	
	public List<PatientDetailInfo> getPatientDetailResultInfo(String hospCode, String diseaseName, String fromLastestGoHospital, String toLastestGoHospital, Integer fromPatientAge, Integer toPatientAge, String patientSex, String statusOfDisease, String patientContact, 
			Integer pageSize, Integer pageIndex, String column , String dir);
	
	public BigInteger getTotalRecord(String hospCode, String diseaseName, String fromLastestGoHospital, String toLastestGoHospital, Integer fromPatientAge, Integer toPatientAge, String patientSex, String statusOfDisease, String patientContact);
	public List<OCSACT2GetPatientListOCSInfo> getOCSACT2GetPatientListOCSInfo(String hospCode,
			String language, String bunho, Date fromDate, Date toDate,
			String actGubun, String code,List<String> jundalPartParam, String iOGubun);
	public List<OUT0101U02PatientExportInfo> getOUT0101U02PatientExportInfo(String hospCode, Date fromDate, Date toDate);
	
	public String callProcMergePatient(String hospCode, String sysId, String ignoreDuplicateYn);
	
	public void saveBatchPatients(List<Out0101> patientList, boolean ignoreDuplicate);
	
	public List<INPBATCHTRANSlayOut0101Info> getINPBATCHTRANSlayOut0101Info(String hospCode, String language, String bunho);
	
	public List<INP1003U01layBunhoValidationInfo> getINP1003U01layBunhoValidationInfo(String hospCode, String bunho);

	public String getTelINP1003U01SaveLayout(String hospCode, String bunho);
	
	public List<INP1003U00grdInpReserGridColumnChangeddtBunhoInfo> getINP1003U00grdInpReserGridColumnChangeddtBunho(String hospCode, String bunho);

	public List<INP1003U00SaveLayoutChkBunhoInfo> getOut0101U00ByBunho(String hospCode, String language, String bunho);

	public List<OCS2005U02grdPatientListInfo> getOCS2005U02grdPatientListInfo(String hospCode, String orderDate, String language, String inputGubun,
			String bunho, String hoDong, String hoCode, String jaewonYn, Integer startNum, Integer offset);

	public String OCS2005U02IsSameNameCHK(String hospCode, String bunho);
	
	public String loadOutSuname(String bunho, String hospCode);
	
	public List<NUR2004U00layCurrentBedInfo> getNUR2004U00layCurrentBedInfo(String hospCode, String bunho, String language);

	public List<NUR1001U00LayINP1001Info> getNUR1001U00LayINP1001Info(String hospCode, String bunho, String language, Double fkinp1001);
	
}

