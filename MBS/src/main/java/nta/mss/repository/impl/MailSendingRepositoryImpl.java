package nta.mss.repository.impl;

import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.kcck.info.KcckReservationInfo;
import nta.mss.info.MailSendingInfo;
import nta.mss.jpa.mapper.JpaResultMapper;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.repository.MailSendingRepositoryCustom;

/**
 * CustomReservationRepository.java
 *
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 *
 */
public class MailSendingRepositoryImpl implements MailSendingRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	
	@SuppressWarnings("unchecked")
	public List<Object[]> searchMailListHistory(Integer mailListId, Date fromDate, Date toDate, String hospitalId) {
		Map<String, Object> params = new HashMap<String, Object>();
		StringBuilder sql = new StringBuilder("  select ml.name, ml.email, ms.reading_flg, ml.phone FROM mail_list_detail ml inner join mail_sending ms on ml.mail_list_id = ms.mail_list_id and ml.email = ms.sending_to where ms.active_flg = 1 and ml.hospital_id = :f_hospitalId ");
		if(mailListId != null && mailListId != -1) {
			sql.append(" and ml.mail_list_id = :mailListId ");
			params.put("mailListId", mailListId);
		}
		if(fromDate != null) {
			sql.append(" and ms.created >= :fromDate ");
			params.put("fromDate", fromDate);
		}
		
		if(toDate != null) {
			sql.append(" and ms.created <= :toDate ");
			Calendar calendar = Calendar.getInstance();
			calendar.setTime(toDate);
			calendar.add(Calendar.DAY_OF_YEAR, 1);
			calendar.add(Calendar.SECOND, -1);
			params.put("toDate", calendar.getTime());
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hospitalId", hospitalId);
		for (Map.Entry<String, Object> entry : params.entrySet()) {
			query.setParameter(entry.getKey(), entry.getValue());
		}
		return query.getResultList();
	}


	 @SuppressWarnings("unchecked") 
		@Override
		public List<MailSendingInfo> searchKcckInfoScheduleMailHistory(Integer hospId,Integer deptId, Date fromDate, Date toDate) {
			StringBuilder sql = new StringBuilder();
			sql.append(" SELECT r.doctor_id AS doctorId,															");
			sql.append("        r.doctor_name AS doctorName,														");
			sql.append("        r.reservation_date AS reservationDate,												");
			sql.append("        r.reservation_time AS reservationTime,												");
			sql.append("        r.patient_name AS patientName,														");
			sql.append("        r.email AS email,																	");
			sql.append("        r.phone_number AS phoneNumber,														");
			sql.append("        ms.reading_flg AS readingFlg,														");
			sql.append("        ms.sending_status AS sendingStatus,													");
			sql.append("        ms.subject AS subject																");
			sql.append("		FROM mail_sending ms 																");
			sql.append("		INNER JOIN reservation r ON ms.patient_id = r.patient_id 							");
			sql.append(" 		 WHERE r.hospital_id = :hospId														");
			if (deptId != -1) {
				sql.append(" AND r.dept_id = :deptId");
			
			}
			if (fromDate != null) {
				sql.append(" AND ms.created >= :fromDate");
			}
			if (toDate != null) {
				sql.append(" AND ms.created <= :toDate");
			}
			sql.append(" 	AND r.active_flg = 1											");
			sql.append("	ORDER BY r.doctor_name , r.reservation_time						");
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("hospId", hospId);
			if (deptId != -1) {
				query.setParameter("deptId", deptId);
			}
			query.setParameter("fromDate", fromDate);
			query.setParameter("toDate",  MssDateTimeUtil.getTimeEndDate(toDate));
			List<MailSendingInfo> list = new JpaResultMapper().list(query, MailSendingInfo.class);	
			return list;
		}

}
