package nta.med.data.dao.medi.res;

import java.util.List;

import nta.med.data.model.ihis.nuro.NuroRES1001U00ReservationScheduleListItemInfo;

/**
 * @author dainguyen.
 */
public interface Res0106RepositoryCustom {

	/**
	 * @param hospCode
	 * @return
	 */
	public List<String> getCboAvgTime();
	
	public List<NuroRES1001U00ReservationScheduleListItemInfo> getReservationScheduleList(String hospitalCode, String examPreDate, String departmentCode, String doctorCode,
			String fromTime, String toTime, String avgTime);
}

