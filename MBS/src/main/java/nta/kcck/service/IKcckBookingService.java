package nta.kcck.service;

import nta.kcck.model.KcckPendingModel;
import nta.kcck.model.KcckReservationModel;
import nta.kcck.model.KcckVaccineReservationModel;

public interface IKcckBookingService {
	public KcckReservationModel saveReservation(KcckReservationModel model);
	public KcckReservationModel changeReservation(KcckReservationModel model);
	public KcckReservationModel cancelReservation(KcckReservationModel model);
	public KcckPendingModel getPendingStatus(String hospCode, String departmentCode);
	public void saveReservationAsyn(KcckReservationModel model);
}
