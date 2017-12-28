package nta.med.data.dao.medi.res;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuro.NuroRES0102U00GetDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0103Info;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0103ResInfo;
import nta.med.data.model.ihis.nuro.NuroRES0102U00UpdateRES0103Info;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReservationScheduleConditionListItemInfo;

/**
 * @author dainguyen.
 */
public interface Res0103RepositoryCustom {
	
	/**
	 * @param hospCode
	 * @param doctor
	 * @param date
	 * @return
	 */
	public List<NuroRES0102U00GrdRES0103Info> getNuroRES0102U00GrdRES0103Info(String hospCode, String doctor, String date);
	
	public List<NuroRES0102U00GrdRES0103ResInfo> getNuroRES0102U00GrdRES0103ResInfo(String hospCode, String doctor, String date);
	
	
	
	/**
	 * @param hospCode
	 * @param doctor
	 * @param date
	 * @param byResPm
	 * @return
	 */
	public List<NuroRES0102U00GetDoctorInfo> getNuroRES0102U00GetDoctorByJinryoDate(String hospCode, String doctor, String date, boolean byResPm);
	
	/**
	 * @param hospCode
	 * @param doctor
	 * @param date
	 * @return
	 */
	public String getNuroRES0102U00CheckDoctor2(String hospCode, String doctor, String date);
	
	
//	/**
//	 * @param hospCode
//	 * @param nuroRES0102U00UpdateRES0103Info
//	 * @return
//	 */
//	public boolean insertNuroRES0102U00InsertRES0103Request1(String hospCode, NuroRES0102U00UpdateRES0103Info nuroRES0102U00UpdateRES0103Info) throws Exception;
	
	/**
	 * @param hospCode
	 * @param nuroRES0102U00UpdateRES0103Info
	 * @return
	 * @throws Exception
	 */
	public boolean updateNuroRES0102U00UpdateRES0103Request1(String hospCode, NuroRES0102U00UpdateRES0103Info nuroRES0102U00UpdateRES0103Info) throws Exception;
	
	public List<NuroRES1001U00ReservationScheduleConditionListItemInfo> getReservationScheduleConditionListItemInfo (String hospitalCode, String doctorCode, String examPreDate);
	
	public String getNuroRES1001U00CheckingReservation(String hospitalCode, String sessionClinic, String doctorCode, String examPreDate, String examPreTime, String inputType, boolean isOtherClinic);
	public String getTChkRES1001U00FrmModifyReserGrdRES1001SavePerformer(String hospCode,String doctor,Date jinryoPreDate,String jinryoPreTime,String inputGubun);
}

