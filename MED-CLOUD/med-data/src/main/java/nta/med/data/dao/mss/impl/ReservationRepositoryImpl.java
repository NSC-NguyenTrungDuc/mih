package nta.med.data.dao.mss.impl;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.stereotype.Service;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.mss.ReservationRepositoryCustom;
import nta.med.data.model.mss.ReservationOnlineInfo;

public class ReservationRepositoryImpl implements ReservationRepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<ReservationOnlineInfo> findReservationInfoByReCodeHosId(Integer hospitalId, List<String> reservationCodes) {
		if (hospitalId == 0 || reservationCodes == null) {
			return null;
		}

		try {
			StringBuilder listReservationCode = new StringBuilder();
			if (reservationCodes != null && reservationCodes.size() > 0) {
				int index = 0;
				for (String parame : reservationCodes) {
					index += 1;
					if (index == reservationCodes.size())
						listReservationCode.append("'" + parame + "'");
					else
						listReservationCode.append("'" + parame + "', ");
				}
			}

			Map<String, Object> params = new HashMap<String, Object>();
			StringBuilder sql = new StringBuilder();
			sql.append(" SELECT                                                                     ");
			sql.append(" 	reservation_id,                                                         ");
			sql.append(" 	reservation_code,                                                       ");
			sql.append(" 	mt_calling_id,                                                          ");
			sql.append(" 	patient_id,                                     	                    ");
			sql.append(" 	hospital_id,                                                            ");
			sql.append(" 	dept_id,                                                                ");
			sql.append(" 	doctor_id                                                               ");
			sql.append(" FROM                                                					    ");
			sql.append(" 	reservation                                      					    ");
			sql.append(" WHERE active_flg = 1                               						");
			sql.append(" 	AND hospital_id = :hospitalId                             				");
			sql.append(" 	AND reservation_code  IN (" + listReservationCode + ")                  ");

			params.put("hospitalId", hospitalId);

			Query query = entityManager.createNativeQuery(sql.toString());
			for (Map.Entry<String, Object> entry : params.entrySet()) {
				query.setParameter(entry.getKey(), entry.getValue());
			}
			List<ReservationOnlineInfo> list = new JpaResultMapper().list(query, ReservationOnlineInfo.class);
			return list;
		} catch (Exception e) {
			e.printStackTrace();
		}

		return null;
	}

}
