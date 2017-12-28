package nta.med.data.dao.medi.res;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuro.*;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00CreateTimeComboInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2;

/**
 * @author dainguyen.
 */
public interface Res0102RepositoryCustom {
	/**
	 * @param hospCode
	 * @param doctor
	 * @return
	 */
	public List<NuroRES0102U00GrdRES0102Info> getNuroRES0102U00GrdRES0102Info(String hospCode, String doctor);
	
	/**
	 * @param hospCode
	 * @param doctor
	 * @param startDate
	 * @return
	 */
	public String getNuroRES0102U00CheckDoctor1(String hospCode, String doctor, String startDate);
	
	public List<String> getDoctorExamStatus(String hospitalCode, String sessionHospCode, String type,
			Date examPreDate, String examPreTime, String doctorCode, boolean isOtherClinic);

	public List<NuroRES1001U00ReservationScheduleConditionListItemInfo> getNuroReservationScheduleConditionList(
			String hospitalCode, String examPreDate, String doctorCode);
	public List<NuroRES1001U00AverageTimeListItemInfo> getAverageTimeList (String hospitalCode, String examPreDate, String doctorCode);
	
	public boolean updateNuroRES0102U00UpdateRES0102Info(String hospCode, NuroRES0102U00UpdateRES0102Info nuroRES0102U00UpdateRES0102Info);
	public List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2> getOcsaOCS0503U00GetFindWorkerListInfoProcess3(String hospCode,String naweonDate,String refCode);
	public List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2> getOcsaOCS0503U00GetFindWorkerListInfoProcess4(String hospCode,String naweonDate,String refCode);
	public List<RES1001U00FrmModifyReserGrdRES1001Info> getRES1001U00FrmModifyReserGrdRES1001Info(String intWeek, String hospCode, String doctor, String date);
	public List<OcsaOCS0503U00CreateTimeComboInfo> createTimeComboOCS0503U00(String hospCode,String doctor,  String intweek, Date date);

	public String getNuroRES0102U00CheckDoctor1(String hospCode, String doctor, String startDate, String gwa, String jinryoBreakYn);
	public List<KCCKGetDoctorWorkingTimeInfo> getKCCKGetScheduleDoctorInfo(String hospitalCode, Date examPreDate, String doctorCode);
	public List<KCCKGetLimitScheduleDoctorInfo> getKCCKGetLimitScheduleDoctorInfo(String hospitalCode, Date examPreDate, String doctorCode);
	public List<KCCKScheduleDoctorStartEndDateHistory> getKCCKScheduleDoctorStartEndTime(String hospCode, String doctor, Date startDate, Date endDate);

	List<DoctorScheduleInfo> findScheduleByCondition(String hospCode, String departmentCode, String startDate, String endDate);

	List<BookedDetailInfo> findBookDetails(String hospCode, String departmentCode, String startDate, String endDate);

	public boolean isDifferentTimeFrameByCondition(String hospCode, String departmentCode, String startDate, String endDate);

	public String getDepartmentTimeFrameByCondition(String hospCode, String departmentCode, String language);
}
