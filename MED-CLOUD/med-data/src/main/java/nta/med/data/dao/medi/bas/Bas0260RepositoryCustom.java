package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.BAS0260DepartmentInfo;
import nta.med.data.model.ihis.bass.BAS0260GrdBuseoListItemInfo;
import nta.med.data.model.ihis.bass.Inp1003U00FwkGwaListItemInfo;
import nta.med.data.model.ihis.bass.LoadGrdBAS0260U01Info;
import nta.med.data.model.ihis.bass.WaitingPatientInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00GetSpecimenInfoListItemInfo;
import nta.med.data.model.ihis.inps.INP1003U00fwkGwaInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangeddtGwaInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetDepartmentInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003R02LayR03ListItemInfo;
import nta.med.data.model.ihis.ocso.OUTSANGU00findBoxToDoctorInfo;
import nta.med.data.model.ihis.ocso.OUTSANGU00findBoxToGwaInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayJinryoGwaInfo;
import nta.med.data.model.ihis.system.BuseoInfo;
import nta.med.data.model.ihis.system.FormGwaItemInfo;
import nta.med.data.model.ihis.system.HIOcsCheckJundalPartLoadJaeryoJundalInfo;
import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * The Interface Bas0260RepositoryCustom.
 *
 * @author dainguyen.
 */
public interface Bas0260RepositoryCustom {
	
	/**
	 * Generate patient deparment list.
	 *
	 * @param language the language
	 * @param hospCode the hosp code
	 * @return the list
	 */
	public List<ComboListItemInfo> generateNuroDeparmentList(String language, String hospCode);
	
	/**
	 * Gets the combo department item info.
	 *
	 * @param language the language
	 * @param hospCode the hosp code
	 * @param comingDate the coming date
	 * @return the combo department item info
	 */
	public List<ComboListItemInfo> getComboDepartmentItemInfo(String language, String hospCode, Date comingDate, boolean isAll);
	
	/**
	 * @param language
	 * @param hospCode
	 * @param appDate
	 * @return
	 */
	public List<ComboListItemInfo> getNuroRES0102U00CboGwa(String language, String hospCode, String appDate);
	
	public List<NuroOUT1001U01GetDepartmentInfo> getNuroOUT1001U01GetDepartmentInfo(String language, String hospCode, String buseoYmd, String buseoGubun, String find1);
	
	/**
	 * @param hospCode
	 * @param language
	 * @return
	 */
	public List<OcsoOCS1003P01LayJinryoGwaInfo> getOcsoOCS1003P01LayJinryoGwaInfo(String hospCode, String language);
	
	public String getBasLoadGwaName(String gwa, String buseoYmd, String hospCode, String language);
	
	public List<BuseoInfo> getBuseoInfo(String hospCode,String language, String buseoGubun);
	
	public String getOcsaOCS0503Q00DepartmentNameList(String hospCode, String language, String gwa);
	
	public List<ComboListItemInfo> getOcsaOCS0503Q00DepartmentList(String hospCode, String language);
	
	public List<ComboListItemInfo> getComboListItemOcsaOCS0204U00CommonData(String hospCode, String language, String sabun);
	
	public List<ComboListItemInfo> getOcsaOCS0150U00DepartmentList(String hospCode, String language, String fMemb);
	
	public String getSchsSCH0201U99GetGwaName(String hospCode, String gwa, Date today);
	
	public String getSCH0201U99GetJundalPartName(String hospCode, String ioGubun, String jundalPart, Date today);
	public List<ComboListItemInfo> getOCS0301U00CboDoctorGwa(String hospCode, String language, String userId);
	public List<TripleListItemInfo> getOCS0301U00CboGwa(String hospCode, String language, String find, String queryMode);
	
	public List<OUTSANGU00findBoxToGwaInfo> getOUTSANGU00findBoxToGwaInfo(
			String hospCode, Date startDate, String find, String language);
	
	public List<OUTSANGU00findBoxToDoctorInfo> getOUTSANGU00findBoxToDoctorInfo(String hospCode, String gwa, String find, Date doctorYmd);
	
	public String getOUTSANGU00GwaName(String hospCode, Date startDate, String find, String language);
	
	public List<CPL3020U00GetSpecimenInfoListItemInfo> getCPL3020U00GetSpecimenInfo(String gwa, String orderDate, String hoDong, String hospCode, String language);
	public List<ComboListItemInfo> getSchsSCH0201Q02JundalComboList(String hospCode,String language, boolean isAndDate , boolean isAll, boolean isOutMoveYn);
	
	public List<ComboListItemInfo> getSCH0201Q12CboDepartmentList(String hospCode, String language);
	
	public List<BAS0260GrdBuseoListItemInfo> getBas0260U00grdBuseoInitListItem(String hospCode, String startDate, String language);
	
	public String getBas0260U00LayDupCheck(String hospCode, String code, String startDate, String language);
	
	public String getBas0260U00TransactionUpdatecheck(String hospCode, String buseoCode, String startDate, String language);
	
	public String getOCS1003P01ChangeUserInfo(String hospCode, String gwa, String language);

	public List<ComboListItemInfo> getComboUserInfoCheckUserSubDoctor(String hospCode, String language, String gwa);
	
	public List<FormGwaItemInfo> getFormGwaItemInfo(String hospCode, String language, String userId, boolean isLimit);
	public String loadGwaNameFromVwBasGwa(String hospCode,String language,String arg1,String arg2,String buseoGubun);
	public String loadColumnCodeNameInfoCaseOcsGwa(String arg1);
	public String loadColumnCodeNameInfoCaseOcsInputPart(String arg1);
	
	public String getOCS0103U12GwaName(String hospCode, String language, String gwa, String date);
	
	public List<HIOcsCheckJundalPartLoadJaeryoJundalInfo> getHIOcsCheckJundalPartLoadJaeryoJundalListItem(String hospCode, String language, 
			String ioGubun,String hangmogCode,String jundalTable, String jundalPart,Date orderDate,String inputPart);
	
	
	public String getLoadColunmCodeNameMovePartCase(String hospCode,String language, String argu1, String argu2);
	
	public String getLoadColumnGwaAll(String hospCode, String orderDate, String gwa);
	
	public List<ComboListItemInfo> getOUTSANGU00createGwaDataListItem(String hospCode, String outJubsu, String language);
	public List<ComboListItemInfo> getComboListFromVwBasGwa(String hospCode,String language,String arg1);
	public List<ComboListItemInfo> getGwaBuseoNameComboListItemInfo(String hospCode);
	public List<Inp1003U00FwkGwaListItemInfo> getInp1003U00FwkGwaListItemInfo(String hospCode, String buseoYmd, String find1);
	public List<ComboListItemInfo> getAdmMsgListItem (String language, String hospCode, Date reserDate);
	public List<ComboListItemInfo> getGwaNameListItem (String hospCode, Date reserDate);
	public String getGwaNameItemInfo(String hospCode, String gwa, Date reserDate);
	public String getDoctorNameItemInfo(String jisiDoctor, Date reserDate, String hospCode);
	
	public List<ComboListItemInfo> getADM104UBuseoCode(String hospCode, String language, String buseoCode, String gwaName);
	
	public List<ComboListItemInfo> getComboHoDongSystemCombobox(String hospCode, String language, String buseoGubun);
	public String getOCS0103U00GrdOCS0115ColChangedJundalPart(String hospCode,String language,String gwa);
	public List<ComboListItemInfo> getPHY2001U04ComboListItemInfo(String hospCode, String languae);
	public List<ComboListItemInfo> getOUTSANGQ00LayoutGwaCombo(String hospCode, String language);
	public List<String> getPHY8002U00SinryoukaInfo(String hospCode, String language, String gwa);
	
	public List<ComboListItemInfo> getOCS0203U00LoadGwaInfo(String hospCode, String language);
	public List<OCS1003R02LayR03ListItemInfo> getOCS1003R03LayOutListItemInfo(String hospCode, String language,
			String gwa, String gwaNameOut, String bunhoOut, String sunamOut, String balheangDateOut, 
			String birthOut, String naewonDateOut, String bunho1Out, String naewonDate, String bunho,
			String naewonType, String doctor, String orderGubun);
	
	public List<BAS0260DepartmentInfo> getBas0260ListGetDepartment(String hospCode, String language);
	
	public List<ComboListItemInfo> findDepartmentByHospCode(String hospCode, String language);
	
    public List<ComboListItemInfo> getAssignDeptCombo(String hospCode, String language);
    public List<ComboListItemInfo> getINV4001LoadBuseo(String hospCode, String language);
    
    public List<ComboListItemInfo> getExeDeptComboListItemInfo(String hospCode, String language);
    
    public List<LoadGrdBAS0260U01Info> getBas0260ListGetDepartment(String language, String buseoGubun, String gwaName, String activeFlg);
    
    public boolean isExistedBAS0260(String hospCode, String buseoCode, String startDate, String language);

	public List<WaitingPatientInfo> getWaitingPatients(String doctor, String examinationDate, String hospCode, String deptCode, String language);

	List<WaitingPatientInfo> getWaitingOfPatient( String examinationDate, String hospCode, String locale, List<String> patientCode);
	public List<ComboListItemInfo> getINP1001R04cboHodong(String hospCode, String language);
	
	public List<ComboListItemInfo> getINP1001D01cboHodongInfo(String hospCode);
	
	public List<ComboListItemInfo> getINP1003Q00cboHodong(String hospCode, String reserDate);
	
	public String getNURILIBbuseoInfo(String hospCode, String buseoGubun, String gwa, String naewonDate);
	
	public String getINP1003U01CheckBool(String hospCode, String gwa, String buseoYmd);
	public String getExsitReserDateINP1003U01SaveLayout(String hospCode, String gwa, Date reserDate);	
	public List<INP1003U00fwkGwaInfo> getINP1003U00fwkGwaInfo(String hospCode, String buseoYmd, String find1);
	public List<ComboListItemInfo> getINP1003U00cboHodong(String hospCode, String language, String reserDate);
	public List<ComboListItemInfo> getINP1003U00MakeHodongCombo(String hospCode, String reserDate);
	public List<INP1003U00grdInpReserGridColumnChangeddtGwaInfo> getINP1003U00grdInpReserGridColumnChangeddtGwa(String hospCode, String gwa, String reserDate);

	public String inp1001U01checkExist(String hospCode, String hoDong, Date silIpwonDate);
	public List<ComboListItemInfo> findBasGwaByHospCodeIpwonYnBuseoGubun(String hospCode, String language, String ipwonYn, String buseoGubun, boolean isAll);
	public String callFnDrgConvBuseoCode(String hospCode, String gwa);
	
	public List<ComboListItemInfo> getOCSCHKDISCHARGEgrdStatus1(String hospCode, String fkinp1001, String kijundate, String bunho);
	
	public DataStringListItemInfo getOCSCHKDISCHARGEFkinp1001(String bunho);
	public String callFnOcsCheckNotEndDirect(String hospCode, String bunho, String fkinp1001);
	public String callFnBasLoadBuseoCode(String hospCode, String bunho, String date);
	
	public List<ComboListItemInfo> getBAS0250Q00grdBAS0260Department(String hospCode, String language, Date buseoYmd, String gumjinHodong);

	public List<ComboListItemInfo> getDRG3010P99cbxBuseo(String hospCode, String language, String buseoGubun);
	
	public List<ComboListItemInfo> getComboHoDong(String hospCode, String language, String buseoGubun, String find1);
	
	public String getBuseoNameByCode(String hospCode, String language, String buseoGubun, String code);
	
	public List<ComboListItemInfo> getNUR2004U00fbxToHodong(String hospCode, String date);
	
	public List<DataStringListItemInfo> getNUR2004U00layValidCheckGwa(String hospCode, String code, String date);
	
	public List<DataStringListItemInfo> getNUR2004U00layValidCheckHodong(String hospCode, String code, String date);
	
	public List<ComboListItemInfo> getBuseoCodeBuseoNameInVwGwaName(String hospCode, String language, String buseoGubun);

	public List<ComboListItemInfo> getNUR8003Q00cboBuseo(String hospCode, String language, String buseoGubun);

	public List<ComboListItemInfo> getNUR1001U00FwkFind(String hospCode, String language, String buseoName);
}

