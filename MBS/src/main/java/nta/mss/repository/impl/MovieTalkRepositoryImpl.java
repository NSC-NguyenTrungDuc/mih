package nta.mss.repository.impl;

import java.math.BigInteger;
import java.util.Arrays;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.collections.CollectionUtils;

import nta.mss.entity.MovieTalkHistory;
import nta.mss.jpa.mapper.JpaResultMapper;
import nta.mss.repository.MovieTalkRepositoryCustom;

/**
 * 
 * @author TungLT 
 * @category MovieTalkRepositoryImpl
 */
public class MovieTalkRepositoryImpl implements MovieTalkRepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	/**
	 * Find listMovieTalkHistory by hospId and cardNumber
	 * 
	 * @author TungLT
	 * @param hospId
	 * @param cardNumber
	 * @param startIndex
	 * @param pageSize
	 * @return the list
	 */
	@Override
	public List<MovieTalkHistory> getListMovieTalkHistory(Integer hospId, String cardNumber, Integer startIndex,
			Integer pageSize, String columnSort, String typeOrder) {
		List<String> strCardNumber = this.getPatientCodes(cardNumber);
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '1' AS rowNum , 																					");
		sql.append(" m.mt_history_id AS mtHistoryId , 																			");
		sql.append(" r.dept_name AS department, 																				");
		sql.append(" CONCAT( DATE_FORMAT(m.reservation_date, '%d/%m/%Y') ,'  ' , m.reservation_time) AS examinationDateTime , 	");
		sql.append(" m.duration AS duration, 																					");
		sql.append(" m.mt_history_url AS mtHistoryUrl 																			");
		sql.append(" FROM mt_history m, patient p, reservation r 																");
		sql.append(" WHERE 1 = 1 																								");
		sql.append(" AND m.active_flag = 1 																						");
		sql.append(" AND m.hospital_id = p.hospital_id 																			");
		sql.append(" AND p.hospital_id = r.hospital_id 																			");
		sql.append(" AND m.patient_id = p.patient_id 																			");
		sql.append(" AND p.patient_id = r.patient_id 																			");
		sql.append(" AND m.reservation_id = r.reservation_id 																	");
		sql.append(" AND m.hospital_id = :hospId 																				");
		sql.append(" AND p.card_Number IN(:strCardNumber) 																		");
		switch (columnSort) {
		case "1": {
			if (typeOrder.equalsIgnoreCase("asc"))
				sql.append(" ORDER BY r.dept_name ");
			else if (typeOrder.equalsIgnoreCase("desc"))
				sql.append(" ORDER BY r.dept_name desc ");
			break;
		}
		case "2": {
			if (typeOrder.equalsIgnoreCase("asc"))
				sql.append(" ORDER BY m.reservation_date asc , m.reservation_time asc ");
			else if (typeOrder.equalsIgnoreCase("desc"))
				sql.append(" ORDER BY m.reservation_date desc , m.reservation_time desc ");
			break;
		}
		case "3": {
			if (typeOrder.equalsIgnoreCase("asc"))
				sql.append(" ORDER BY m.duration ");
			else if (typeOrder.equalsIgnoreCase("desc"))
				sql.append(" ORDER BY m.duration desc");
			break;
		}
		default: {
			sql.append(" ORDER BY m.mt_history_id desc ");
			break;
		}
		}
		sql.append(" LIMIT :startIndex, :pageSize");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospId", hospId);
		query.setParameter("strCardNumber", strCardNumber);
		query.setParameter("startIndex", startIndex);
		query.setParameter("pageSize", pageSize);
		List<MovieTalkHistory> list = new JpaResultMapper().list(query, MovieTalkHistory.class);
		return list;
	}

	@Override
	public Integer getTotalRecordMovieTalkHistoryByHospIdAndPatientId(Integer hospId, String cardNumber) {
		// TODO Auto-generated method stub
		List<String> strCardNumber = this.getPatientCodes(cardNumber);
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT COUNT(m.mt_history_id) 					");
		sql.append(" FROM mt_history m, reservation r, patient p 	");
		sql.append(" WHERE 1 = 1 									");
		sql.append(" AND m.active_flag = 1 							");
		sql.append(" AND m.hospital_id = p.hospital_id 				");
		sql.append(" AND p.hospital_id = r.hospital_id 				");
		sql.append(" AND m.patient_id = p.patient_id 				");
		sql.append(" AND p.patient_id = r.patient_id 				");
		sql.append(" AND m.reservation_id = r.reservation_id 		");
		sql.append(" AND r.hospital_id = :hospId 					");
		sql.append(" AND p.card_Number IN(:strCardNumber) 			");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospId", hospId);
		query.setParameter("strCardNumber", strCardNumber);
		List<BigInteger> lstMovieTalk = query.getResultList();
		if (CollectionUtils.isNotEmpty(lstMovieTalk)) {
			return lstMovieTalk.get(0).intValue();
		}
		return 0;
	}

	@Override
	public Integer deleteRecordMovieTalkHistoryById(Integer mtHistoryId) {
		// TODO Auto-generated method stub
		StringBuilder sql = new StringBuilder();
		sql.append(" UPDATE mt_history ");
		sql.append(" SET active_flag = 0 ");
		sql.append(" WHERE mt_history_id = :mtHistoryId ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("mtHistoryId", mtHistoryId);
		return query.executeUpdate();
	}
	//Add Str cardNumber into List<String>
	private List<String> getPatientCodes(String cardNumber)
	{
		String[] strArrayCardNumber = cardNumber.split(",");
		List<String> strCardNumber = Arrays.asList(strArrayCardNumber);
		return strCardNumber;
	}

}
