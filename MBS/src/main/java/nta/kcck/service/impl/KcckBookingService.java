package nta.kcck.service.impl;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.collections.functors.ExceptionPredicate;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.scheduling.annotation.Async;
import org.springframework.scheduling.annotation.EnableAsync;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.kcck.model.KcckPendingModel;
import nta.kcck.model.KcckReservationModel;
import nta.kcck.service.IKcckBookingService;
import nta.mss.controller.BookingController;

@EnableAsync
@Service
@Transactional
public class KcckBookingService implements IKcckBookingService {
	private static final Logger LOG = LogManager.getLogger(BookingController.class);
	KcckApiService kcckApiService = new KcckApiService();

	@Override
	public KcckPendingModel getPendingStatus(String hospCode, String departmentCode) {
		KcckPendingModel kcckPendingModel = kcckApiService.getKcckPendingStatus(hospCode, departmentCode).getData();
		return kcckPendingModel;

	}

	@Override
	public KcckReservationModel saveReservation(KcckReservationModel model) {
		return kcckApiService.saveReservation(model);
	}

	@Override
	@Async
	public void saveReservationAsyn(KcckReservationModel model) {
/*		int count = 0;
		while (count < 3){
			try {*/
				KcckReservationModel kcckModels = kcckApiService.saveReservation(model);
			/*	if (kcckModels != null && kcckModels.getReservation_code() != null)
					break;
				else {
					Thread.sleep(20 * 1000);
				}
				count++;
			} catch (Exception e) {
				LOG.error("Error booking from KCCK " + e);
			}
		}*/
	}
	
	

	@Override
	public KcckReservationModel changeReservation(KcckReservationModel model) {
		return kcckApiService.changeReservation(model);
	}

	@Override
	public KcckReservationModel cancelReservation(KcckReservationModel model) {
		return kcckApiService.cancelReservation(model);
	}

}
