package nta.med.data.dao.mss;

import java.util.List;

import nta.med.data.model.mss.ReservationOnlineInfo;

public interface ReservationRepositoryCustom {
	public List<ReservationOnlineInfo> findReservationInfoByReCodeHosId(Integer hospId, List<String> reservationCodes);
}
