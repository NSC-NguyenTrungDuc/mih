package nta.med.data.dao.medi.bas;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.BAS0270FwdDoctorInfo;
import nta.med.data.model.ihis.bass.Inp1003U00FwkDoctorListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetDoctorInfo;
import nta.med.data.model.ihis.inps.INP1003U00fwkDoctorInfo;
import nta.med.data.model.ihis.inps.INP1003U01fbxInp1003Info;
import nta.med.data.model.ihis.nuro.DoctorInfo;
import nta.med.data.model.ihis.nuro.KcckApiDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01DoctorNameInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01FwkDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GetDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00DoctorReservationStatusListItemInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0503Q00DoctorListInfo;
import nta.med.data.model.ihis.ocsa.OCSAOCS0270Q00GridBAS0270RowInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1;
import nta.med.data.model.ihis.ocsa.PatientLinkingFwkDoctorInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99LayoutCommonListInfo;

/**
 * @author dainguyen.
 */
public interface Bas0270RepositoryCustom {
	/**
	 * @param hospitalCode
	 * @param doctorCode
	 * @param date
	 * @return
	 */
	public List<String> getNuroNUR2001U04DoctorName(String hospitalCode, String doctorCode, String date);
	
	/**
	 * @param hospCode
	 * @param patientCode
	 * @param find1
	 * @return
	 */
	public List<NuroOUT1101Q01FwkDoctorInfo> getNuroOUT1101Q01FwkDoctorInfo(String hospCode, String patientCode, String find1);
	/**
	 * @param hospCode
	 * @param gwa
	 * @param doctor
	 * @return
	 */
	public List<NuroOUT1101Q01DoctorNameInfo> getNuroOUT1101Q01DoctorNameInfo(String hospCode, String gwa, String doctor);
	
	/**
	 * @param hospCode
	 * @param departmentCode
	 * @param appDate
	 * @return
	 */
	public List<ComboListItemInfo> getNuroRES0102U00CboDoctorItemInfo(String hospCode, String departmentCode, String appDate);
	
	/**
	 * @param hospCode
	 * @param doctor
	 * @param startDate
	 * @return
	 */
	public List<NuroRES0102U00GetDoctorInfo> getNuroRES0102U00GetDoctorInBetweenDate(String hospCode, String doctor, String startDate);
	
	public List<NuroRES1001U00DoctorReservationStatusListItemInfo> getDoctorReservationStatusList(String hospitalCode, String deptCode, String doctorCode, boolean isOtherClinic);
	
	public List<NuroOUT1001U01GetDoctorInfo> getNuroOUT1001U01GetDoctorInfo(String language, String hospCode, String naewonDate, String gwa, String find1);
	
	public List<OCSAOCS0270Q00GridBAS0270RowInfo> getOCSAOCS0270Q00GridBAS0270RowInfo(String language, String hospCode, String allGubun, String gwa,
			String doctorGrade, String fQuery, String osimGubun, String date, boolean reserOutFlg);
	
	public List<ComboListItemInfo> getNuroNUR1001R00GetGwaDoctorList(String hospCode, String gwa, String month);
	
	public String getOcsaOCS0503Q00DoctorNameList(String hospCode, String gwa, String code);
	
	public List<OCS0503Q00DoctorListInfo> getOcsaOCS0503Q00DoctorList(String hospCode, String language, String gwa);
	
	public List<SchsSCH0201U99LayoutCommonListInfo> getSchsSCH0201U99LayoutCommonListInfo(String hospCode, String doctor, String gwa);
	public String getDoctorNameOCS0503U00(String hospCode, String code);
	public List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1> getOcsaOCS0503U00GetFindWorkerListInfoProcess2(String hospCode,String refCode);
	public List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1> getOcsaOCS0503U00GetFindWorkerListInfoProcess5(String hospCode,String refCode);
	public String getOUTSANGU00DoctorName(String hospCode, String gwa, String find, Date doctorYmd);
	
	public String getDoctorNameBAS0270(String hospCode, String gwa, String doctor, String date);
	
	public List<BAS0270FwdDoctorInfo> getBAS0270FwdDoctorInfo(String hospCode, String find1);
	
	public List<ComboListItemInfo> getOcsOrderBizLoadComboDataSourceListItem(String hospCode, String doctor, String date);
	public String getMainGwaDoctorCodeInfo(String hospCode,String memb);
	public String getLoadColumnCodeNameInfoCaseGwaDoctor(String hospCode,String arg1,String arg2,String arg3);
	public List<ComboListItemInfo> getDoctorComboListItemInfo(String hospCode, String doctorGwa);
	public List<Inp1003U00FwkDoctorListItemInfo> getInp1003U00FwkDoctorListItemInfo(Date doctorYmd, String hospCode, String language, String gwa, String find1);
	public List<ComboListItemInfo> getPHY2001U04CboDoctor(String hospCode, String gwa);
	
	public List<ComboListItemInfo> getOCS0203U00LoadAllMemb(String hospCode, String gwa);
	public OCS2015U00GetDoctorInfo getOCS2015U00GetDoctorInfo(String hospCode, String language, String doctor);
	
	public List<PatientLinkingFwkDoctorInfo> getPatientLinkingFwkDoctorInfo(String hospCode, String refCode);
	
	public List<KcckApiDoctorInfo> getKcckApiGetDoctors(String hospCode, String department);
	
	public List<DoctorInfo> searchDoctors(String hospCode, String department, String startDate, String endDate);

	public List<KcckApiDoctorInfo> getKcckApiSearchDoctors(String hospCode, String department, String startDate, String endDate, String locale, String reservationDate, String reservationTime, Integer pageSize, Integer pageIndex);
	
	public String getDoctorNameBAS0271(String hospCode, String doctor, String date);
	
	public BigInteger getKcckApiTotalRecordSearchDoctors(String hospCode, String department, String startDate,
			String endDate, String locale, String reservationDate, String reservationTime);
	
	public List<PatientLinkingFwkDoctorInfo> getOcs2015U00DoctorNameInfo(String hospCode);
	
	public List<INP1003U01fbxInp1003Info> getINP1003U01fbxInp1003Info(String hospCode, String find, String buseoYmd, String gwa, String doctorYmd, String nameControl);
	
	public String getExsitReserDateINP1003U01SaveLayout(String hospCode, String gwa, Date reserDate, String doctor);
	
	public String getDoctorByDoctorGwaAndCommonDoctorYn(String hospCode, String doctorGwa, String commonYn);
	
	public List<INP1003U00fwkDoctorInfo> getINP1003U00fwkDoctorInfo(String hospCode, String gwa, String find, String doctorYmd, String language);
	
	public List<ComboListItemInfo> findDoctorByHospCodeSysDateDoctorGwa(String hospCode, String language, String doctorGwa, boolean isAll);
	
	public String getOCS2003P01IsCommonDocConsultInfo(String hospCode, String doctor, String date);
	
	public List<ComboListItemInfo> findByHospCodeDoctorGwaFDate(String hospCode,String doctorGwa, String ipwonDate);
	
	public List<ComboListItemInfo> getNUR2004U00fbxToDoctor(String hospCode, String date, String gwa, String find1);
	
	public List<DataStringListItemInfo> getNUR2004U00layValidCheckDoctor(String hospCode, String gwa, String code, String date);
}

