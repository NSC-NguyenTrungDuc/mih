package nta.med.data.dao.medi.sch;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.sch.Sch0201;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.NuroCheckBookingInfo;
import nta.med.data.model.ihis.nuro.NuroInspectionOrderInfo;
import nta.med.data.model.ihis.schs.SCH0201Q05LayReserListInfo;
import nta.med.data.model.ihis.schs.SCH0201Q12GrdListItemInfo;
import nta.med.data.model.ihis.schs.SCH0201U10GrdOrderItemInfo;
import nta.med.data.model.ihis.schs.SCH0201U10LayReserInfo;
import nta.med.data.model.ihis.schs.SCH0201U99BookingInfo;
import nta.med.data.model.ihis.schs.SCH0201U99ClinicInfo;
import nta.med.data.model.ihis.schs.SCH0201U99ClinicLinkInfo;
import nta.med.data.model.ihis.schs.SCH0201U99PatientInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q01ReserListItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q02ReserList02ItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q02ReserList03ItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04GetMonthReserListInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04PrartListItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04ReserTimeListInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99DateScheduleItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99GrdOrderListInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99GrdTimeListInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99LayoutTimeListInfo;

/**
 * The Interface Sch0201RepositoryCustom.
 *
 * @author dainguyen.
 */
public interface Sch0201RepositoryCustom {
	
	/**
	 * Gets the patient check booking info.
	 *
	 * @param hospitalCode the hospital code
	 * @param patientCode the patient code
	 * @param reserDate the reser date
	 * @return the patient check booking info
	 */
	public List<NuroCheckBookingInfo> getNuroCheckBookingInfo(String hospitalCode, String patientCode, String reserDate);
	
	/**
	 * Gets the patient inspection order info.
	 *
	 * @param hospitalCode the hospital code
	 * @param language the language
	 * @param patientCode the patient code
	 * @param reserDate the reser date
	 * @return the patient inspection order info
	 */
	public List<NuroInspectionOrderInfo> getNuroInspectionOrderInfo(String hospitalCode, String language, String patientCode, String reserDate);
	
	public List<ComboListItemInfo> getSchsSCH0201Q01SCH0109ComboList(String hospCode, String language);
	
	public List<ComboListItemInfo> getSchsSCH0201Q01SCH0001ComboList(String hospCode, String jundalTable, String language);
	
	public String getSchsSCH0201Q01ExitsJundalTable(String hospCode, String hangmogCode,String jundalTable);
	
	public List<SchsSCH0201Q01ReserListItemInfo> getSchsSCH0201Q01ReserListItemInfo(String hospCode, String fromDate, 
			String toDate, String jundalTable, String jundalPart, boolean chkchecked);
	
	public List<SchsSCH0201Q02ReserList02ItemInfo> getSchsSCH0201Q02ReserList02ItemInfo (String hospCode, String fromDate,
			String toDate, String gwa);
	
	public List<SchsSCH0201Q02ReserList03ItemInfo> getSchsSCH0201Q02ReserList03ItemInfo(String hospCode, String fromDate, String toDate, String gwa);
	
	public List<SchsSCH0201Q04PrartListItemInfo> getSchsSCH0201Q04PrartListItemInfo(String hospCode, String jundalTable);
	
	public List<SchsSCH0201Q04GetMonthReserListInfo> getSchsSCH0201Q04GetMonthReserListInfo(String hospCode, String judalTable, String judalPart, String month);
	
	public List<SchsSCH0201Q04ReserTimeListInfo> getSchsSCH0201Q04ReserTimeListInfo(String hospCode, String ipAddress);
	
	public void callSchsSCH0201Q04PrSchTimeList(String hospCode, String ipAddress, String jundalTable, String jundalPart, String gumsaja, String reserDate);
	public void callSchsSCH0201Q04PrSchTimeListOther(String hospCode, String sessionHospCode, String ipAddress, String jundalTable, String jundalPart, String gumsaja, String reserDate);
	
	public List<ComboListItemInfo> getSCH0201Q12FwkDoctorList(String hospCode, String gwa, String find1);
	
	public List<SCH0201Q12GrdListItemInfo> getSCH0201Q12GrdListItemInfo(String hospCode,
			String bunho, String statFlg,String naewonDate, String gwa, String doctor, String reserGubun, String language);
	
	public List<String> getSCH0201Q12DistinctDoctorNameListInfo(String hospCode, String gwa, String doctor);
	
	public String callPrSchSch0210Iud(String hospCode, String iudGubun, String fksch0201, Date reserDate, String reserTime, String inputId,String ioErr);
	public String callPrSchSch0210IudOther(String hospCode, String sessionHospCode, String iudGubun, String fksch0201, Date reserDate, String reserTime, String inputId,String ioErr);
	
	public List<SchsSCH0201U99GrdOrderListInfo> getSchsSCH0201U99GrdOrderListInfo(String hospCode,String language, String flag, String bunho, String fkocs,
			String reserStatus, String reserGubun, String reserPart, String wonyoi_order_yn );
	
	
	public List<SchsSCH0201U99GrdTimeListInfo> getSchsSCH0201U99GrdTimeListInfo(String hospCode, String ipAddress);
	
	public List<SchsSCH0201U99LayoutTimeListInfo> getSchsSCH0201U99LayoutTimeListInfo(String hospCode, String ipAddress); 
	
	public String callPrSchSch0201EtcInsert(String hospCode, String  iBunho,String iJundalTable,
			String iJundalPar, String iHangmogCode, String iUserId);
	
	public List<SchsSCH0201U99DateScheduleItemInfo> getSchsSCH0201U99DateScheduleListInfo(String hospCode, String jundalTable, String jundalPart, String hangmogCode,String startDate);
	
	public String getSCH0201U99ReserTimeChk(String hospCode, String bunho, String reserDate, String reserTime,Double pksch0201);

	public List<SCH0201Q05LayReserListInfo> getSCH0201Q05LayReserListInfo(String hospCode, String language, String bunho);
	
	public List<SCH0201U10GrdOrderItemInfo> getSCH0201U10GrdOrderItemInfo(String hospCode, String language, String bunho, String reserDate);
	
	public List<SCH0201U10LayReserInfo> getSCH0201U10LayReserInfo(String hospCode, String language, String bunho, String reserDate);
	
	public List<SCH0201U99ClinicLinkInfo> getLinkedClinic(String hospCodeLink, String language);
	
	public List<SCH0201U99PatientInfo> getSCH0201U99PatientInfo(String hospCode, String hospCodeLink, String bunhoLink);
	
	public List<SCH0201U99ClinicInfo> getSCH0201U99ClinicInfo(String hospCode, String language, String bunhoLink, String hospCodeLink, String reserDate, String reserTime);
	
	public List<SCH0201U99BookingInfo> getSCH0201U99BookingInfo(String hospCode, String language, String bunhoLink, String hospCodeLink, String hangmogCode, String reserDate);

	public String getBarcodeLinkedPatient(String bunhoLink);

	public boolean isOrderEffected(String hospCode, String hangmogCode, String reserDate);

	public String getSchTotalInWon(String hospCode, String jundalTable, String jundalPart, String reserDate);
	public String getSchTotalInWonByTime(String hospCode, String jundalTable, String jundalPart, String reserDate, String reserTime);

	public String getSchTotalOutWon(String hospCode, String jundalTable, String jundalPart, String reserDate);
	public String getSchTotalOutWonByTime(String hospCode, String jundalTable, String jundalPart, String reserDate,String reserTime);

	public Double getPkSCH0101ByFkOcs(String fkOCS, String hangmogCode);

	public Sch0201 getPkSCH0101ByFkOcs(Double fkOCS, String hangmogCode, String hospCode);

	List<Sch0201> findByFkOscAndHangCodeAndHospCode(Double fkOCS, String hangmogCode, String hospCode);

	public String isExistBookingDate(String reserDate, Double fkOCS, String hangmogCode, String hospCode);
}

