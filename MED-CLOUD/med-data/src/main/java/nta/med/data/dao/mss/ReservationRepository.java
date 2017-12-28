package nta.med.data.dao.mss;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.mss.Reservation;
import nta.med.data.model.mss.ReservationOnlineInfo;

@Repository
public interface ReservationRepository extends JpaRepository<Reservation, Long>, ReservationRepositoryCustom {

	public List<Reservation> findByReservationCodeAndHospitalId(String reservationCode, Integer hospitalId);
	public List<ReservationOnlineInfo> findReservationInfoByReCodeHosId(Integer hospitalId, List<String> reservationCodes);
}
