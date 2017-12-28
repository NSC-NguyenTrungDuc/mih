package nta.mss.repository.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.mss.info.BookingVaccineBackendInfo;
import nta.mss.info.ReminderBookingVaccineInfo;
import nta.mss.info.VaccineCdUsingInfo;
import nta.mss.info.VaccineDetailInfo;
import nta.mss.info.VaccineInfo;
import nta.mss.info.VaccineReportInfo;
import nta.mss.jpa.mapper.JpaResultMapper;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.repository.VaccineRepositoryCustom;

public class VaccineRepositoryImpl implements VaccineRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<VaccineDetailInfo> getAllVaccineList(Integer childId, String hospitalCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.vaccine_id, A.type_support, A.vaccine_type, A.total_inject,	                                  ");
		sql.append(" 	A.vaccine_name, A.color, A.vaccine_group_id, A.limit_age_from_month,                                  ");
		sql.append(" 	A.limit_age_to_month, A.vaccine_status, A.from_date, A.to_date,		                                  ");
		sql.append(" 	A.recommend_age, A.support_fee_age, A.warning_days, A.vaccine_cd,	                                  ");
		sql.append(" 	A.injected_no, A.day_min, A.day_max, A.description,				                                      ");
		sql.append(" 	D.hospital_name, D.injected_date,									                                  ");
		sql.append(" 	D.reservation_id, :childId as child_id,                                                               ");
		// 0 is RECOMMENDED
		sql.append(" 	'0' as status															                              ");
		sql.append(" FROM (																	                                  ");
		sql.append(" 	SELECT                                                                                                ");
		sql.append(" 	    V.vaccine_id AS vaccine_id,                                                                       ");
		sql.append(" 	    IF((GROUP_CONCAT(DISTINCT CONCAT(VSF.from_month, '-', VSF.to_month)                                        ");
		sql.append(" 	            SEPARATOR ',')) IS NOT NULL,                                                              ");
		sql.append(" 	        1,                                                                                            ");
		sql.append(" 	        0) AS type_support,                                                                           ");
		sql.append(" 	    V.vaccine_type AS vaccine_type,                                                                   ");
		sql.append(" 	    V.total_inject AS total_inject,                                                                   ");
		sql.append(" 	    V.vaccine_name AS vaccine_name,                                                                   ");
		sql.append(" 	    VG.color AS color,                                                                                ");
		sql.append(" 	    VG.vaccine_group_id AS vaccine_group_id,                                                          ");
		sql.append(" 	    V.limit_age_from_month AS limit_age_from_month,                                                   ");
		sql.append(" 	    V.limit_age_to_month AS limit_age_to_month,                                                       ");
		sql.append(" 	    VH.vaccine_status AS vaccine_status,        	                                                  ");
		sql.append(" 	    VH.from_date AS from_date,                                                                        ");
		sql.append(" 	    VH.to_date AS to_date,                                                                            ");
		sql.append(" 	    GROUP_CONCAT(DISTINCT CONCAT(VRA.from_month, '-', VRA.to_month)                                            ");
		sql.append(" 	        SEPARATOR ',') AS recommend_age,                                                              ");
		sql.append(" 	    GROUP_CONCAT(DISTINCT CONCAT(VSF.from_month, '-', VSF.to_month)                                            ");
		sql.append(" 	        SEPARATOR ',') AS support_fee_age,                                                            ");
		sql.append(" 	    VH.warning_days AS warning_days,                                                                  ");
		sql.append(" 	    V.vaccine_cd AS vaccine_cd,                                                                       ");
		sql.append(" 	    VID.injected_no AS injected_no,                                                                   ");
		sql.append(" 	    VID.day_min AS day_min,                                                                           ");
		sql.append(" 	    VID.day_max AS day_max,                                                                           ");
		sql.append(" 	    V.description AS description                                                                      ");
		sql.append(" 	FROM                                                                                                  ");
		sql.append(" 	    vaccine V                                                                                         ");
		sql.append(" 	    LEFT JOIN vaccine_group VG ON V.vaccine_group_id = VG.vaccine_group_id                            ");
		sql.append("			AND VG.active_flg = 1																		  ");
		sql.append(" 	    LEFT JOIN vaccine_recommend_age VRA ON V.vaccine_id = VRA.vaccine_id  		                      ");
		sql.append(" 	        AND VRA.active_flg = 1                                                                        ");
		sql.append(" 	    LEFT JOIN vaccine_support_fee VSF ON V.vaccine_id = VSF.vaccine_id                                ");
		sql.append(" 	        AND VSF.active_flg = 1                                                                        ");
		sql.append(" 	    LEFT JOIN vaccine_inject_day VID ON V.vaccine_id = VID.vaccine_id                                 ");
		sql.append("			AND VID.active_flg = 1																		  ");
		sql.append(" 		LEFT JOIN vaccine_hospital VH ON V.vaccine_id = VH.vaccine_id                                     ");
		sql.append(" 			AND VH.hospital_id IN (SELECT hospital_id FROM hospital WHERE hospital_code = :hospitalCode)  ");
		sql.append(" 	WHERE V.active_flg = 1                                                                                ");
		sql.append(" 		AND VH.vaccine_status = 1  		                                                                  ");
		sql.append(" 		AND VH.active_flg = 1	  		                                                                  ");
		sql.append(" 	GROUP BY V.vaccine_id , injected_no,  vaccine_type, total_inject, vaccine_name, color,                ");
		sql.append(" 		vaccine_group_id, limit_age_from_month,limit_age_to_month, vaccine_status, from_date, to_date,    ");
		sql.append("	 	warning_days, vaccine_cd, injected_no, day_min, day_max, description 							  ");
		sql.append(" 	ORDER BY vaccine_group_id , vaccine_id , injected_no                                                  ");
		sql.append(" )as A																	                                  ");
		sql.append(" LEFT JOIN (                                                                                              ");
		sql.append(" 	SELECT B.vaccine_id, B.injected_no, B.reservation_id, B.hospital_name, B.injected_date                ");
		sql.append(" 	FROM vaccine_child_history as B                                                                       ");
		sql.append(" 	LEFT JOIN reservation as C ON (                                                                       ");
		sql.append(" 		B.reservation_id = C.reservation_id                                                               ");
		sql.append(" 	)                                                                                                     ");
		sql.append(" 	WHERE B.active_flg = 1                                                                                ");
		sql.append(" 		AND B.child_id = :childId                                                                         ");
		sql.append(" 		AND IF(B.reservation_id IS NOT NULL, C.reservation_status NOT IN (0, 5) AND C.active_flg = 1, true)        ");
		sql.append(" ) as D ON A.vaccine_id = D.vaccine_id                                                                    ");
		sql.append(" 	AND A.injected_no = D.injected_no                                                                     ");
		sql.append(" ORDER BY A.vaccine_id, A.injected_no									                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("childId", childId);
		query.setParameter("hospitalCode", hospitalCode);
		
		List<VaccineDetailInfo> list = new JpaResultMapper().list(query, VaccineDetailInfo.class);
		return list;
	}
	
	@Override	
	public List<VaccineDetailInfo> getVaccineHistoryList(Integer childId, Boolean isBookingHistory, String hospitalCode){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.vaccine_id, A.type_support, A.vaccine_type, A.total_inject,		                                          ");
		sql.append(" 	A.vaccine_name, A.color, A.vaccine_group_id, A.limit_age_from_month,	                                          ");
		sql.append(" 	A.limit_age_to_month, A.vaccine_status, A.from_date, A.to_date,			                                          ");
		sql.append(" 	A.recommend_age, A.support_fee_age, A.warning_days, A.vaccine_cd,		                                          ");
		sql.append(" 	A.injected_no, A.day_min, A.day_max, A.description,					                                              ");
		sql.append(" 	B.hospital_name, B.injected_date,										                                          ");
		sql.append(" 	C.reservation_id, :childId as child_id,									                                          ");
		if (isBookingHistory) {
		// 1 is BOOKED_INSIDE
		// 2 is BOOKED_OUTSIDE
			sql.append(" 	IF(C.reservation_id IS NULL, '2', '1') as status				                              		          ");
		}
		else {
		// 3 is COMPLETED
			sql.append(" 	'3' as status																								  ");
		}
		sql.append(" FROM (																	                                              ");
		sql.append(" 	SELECT                                                                                                            ");
		sql.append(" 	    V.vaccine_id AS vaccine_id,                                                                                   ");
		sql.append(" 	    IF((GROUP_CONCAT(DISTINCT CONCAT(VSF.from_month, '-', VSF.to_month)                                                    ");
		sql.append(" 	            SEPARATOR ',')) IS NOT NULL,                                                                          ");
		sql.append(" 	        1,                                                                                                        ");
		sql.append(" 	        0) AS type_support,                                                                                       ");
		sql.append(" 	    V.vaccine_type AS vaccine_type,                                                                               ");
		sql.append(" 	    V.total_inject AS total_inject,                                                                               ");
		sql.append(" 	    V.vaccine_name AS vaccine_name,                                                                               ");
		sql.append(" 	    VG.color AS color,                                                                                            ");
		sql.append(" 	    VG.vaccine_group_id AS vaccine_group_id,                                                                      ");
		sql.append(" 	    V.limit_age_from_month AS limit_age_from_month,                                                               ");
		sql.append(" 	    V.limit_age_to_month AS limit_age_to_month,                                                                   ");
		sql.append(" 	    VH.vaccine_status AS vaccine_status,         	                                                              ");
		sql.append(" 	    VH.from_date AS from_date,                                                                                    ");
		sql.append(" 	    VH.to_date AS to_date,                                                                                        ");
		sql.append(" 	    GROUP_CONCAT(DISTINCT CONCAT(VRA.from_month, '-', VRA.to_month)                                                        ");
		sql.append(" 	        SEPARATOR ',') AS recommend_age,                                                                          ");
		sql.append(" 	    GROUP_CONCAT(DISTINCT CONCAT(VSF.from_month, '-', VSF.to_month)                                                        ");
		sql.append(" 	        SEPARATOR ',') AS support_fee_age,                                                                        ");
		sql.append(" 	    VH.warning_days AS warning_days,                                                                              ");
		sql.append(" 	    V.vaccine_cd AS vaccine_cd,                                                                                   ");
		sql.append(" 	    VID.injected_no AS injected_no,                                                                               ");
		sql.append(" 	    VID.day_min AS day_min,                                                                                       ");
		sql.append(" 	    VID.day_max AS day_max,                                                                                       ");
		sql.append(" 	    V.description AS description                                                                                  ");
		sql.append(" 	FROM                                                                                                              ");
		sql.append(" 	    vaccine V                                                                                                     ");
		sql.append(" 	    LEFT JOIN vaccine_group VG ON V.vaccine_group_id = VG.vaccine_group_id		                                  ");
		sql.append("			AND VG.active_flg = 1																					  ");			
		sql.append(" 	    LEFT JOIN vaccine_recommend_age VRA ON V.vaccine_id = VRA.vaccine_id  		                                  ");
		sql.append(" 	        AND VRA.active_flg = 1                                                                                    ");
		sql.append(" 	    LEFT JOIN vaccine_support_fee VSF ON V.vaccine_id = VSF.vaccine_id                                            ");
		sql.append(" 	        AND VSF.active_flg = 1                                                                                    ");
		sql.append(" 	    LEFT JOIN vaccine_inject_day VID ON V.vaccine_id = VID.vaccine_id    		                                  ");
		sql.append("			AND VID.active_flg = 1																					  ");
		sql.append(" 		LEFT JOIN vaccine_hospital VH ON V.vaccine_id = VH.vaccine_id                                    			  ");
		sql.append(" 			AND VH.hospital_id IN (SELECT hospital_id FROM hospital WHERE hospital_code = :hospitalCode) 			  ");
		sql.append(" 	WHERE V.active_flg = 1                                                                                            ");
		sql.append(" 		AND VH.vaccine_status = 1                	                                                                  ");
		sql.append(" 	GROUP BY V.vaccine_id , injected_no,  vaccine_type, total_inject, vaccine_name, color,                			  ");
		sql.append(" 		vaccine_group_id, limit_age_from_month,limit_age_to_month, vaccine_status, from_date, to_date,    			  ");
		sql.append("	 	warning_days, vaccine_cd, injected_no, day_min, day_max, description 							  			  ");
		sql.append(" 	ORDER BY vaccine_group_id , vaccine_id , injected_no                                                              ");
		sql.append(" )as A																	                                              ");
		sql.append(" LEFT JOIN vaccine_child_history as B ON (                                                                            ");
		sql.append(" 	A.vaccine_id = B.vaccine_id                                                                                       ");
		sql.append(" 	AND A.injected_no = B.injected_no                                                                                 ");
		sql.append(" )	                                                                                                                  ");
		sql.append(" LEFT JOIN reservation as C ON B.reservation_id = C.reservation_id			                                          ");
		sql.append(" WHERE B.active_flg = 1                                                                                               ");
		sql.append(" 	AND B.child_id = :childId                                                                                         ");
		if (isBookingHistory) {
			sql.append(" 	AND IF(B.reservation_id IS NULL, B.injected_date >= NOW(), C.reservation_status IN (1,2,4) AND C.active_flg = 1) ");
		}
		else {
			sql.append(" 	AND IF(B.reservation_id IS NULL, B.injected_date < NOW(), C.reservation_status = 3 AND C.active_flg = 1)          ");
		}
		sql.append(" ORDER BY B.injected_date DESC												                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("childId", childId);
		query.setParameter("hospitalCode", hospitalCode);
		
		List<VaccineDetailInfo> list = new JpaResultMapper().list(query, VaccineDetailInfo.class);
		return list;
	}
	
	@Override
	public List<VaccineCdUsingInfo> getVaccineCdUsingList(Integer childId, String hospitalCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.vaccine_cd, count(A.vaccine_cd) as injected_no, MAX(B.injected_date) as injected_date          ");
		sql.append(" FROM (                                                                                                  ");
		sql.append(" 	SELECT                                                                                               ");
		sql.append(" 	    V.vaccine_id AS vaccine_id,                                                                      ");
		sql.append(" 	    VH.vaccine_status AS vaccine_status,                                                             ");
		sql.append(" 	    V.vaccine_cd AS vaccine_cd,                                                                      ");
		sql.append(" 	    VID.injected_no AS injected_no                                                                   ");
		sql.append(" 	FROM                                                                                                 ");
		sql.append(" 	    vaccine V                                                                                        ");
		sql.append(" 	    LEFT JOIN vaccine_inject_day VID ON V.vaccine_id = VID.vaccine_id                                ");
		sql.append(" 			AND VID.active_flg = 1                                                                       ");
		sql.append(" 		LEFT JOIN vaccine_hospital VH ON V.vaccine_id = VH.vaccine_id                                    ");
		sql.append(" 			AND VH.hospital_id IN (SELECT hospital_id FROM hospital WHERE hospital_code = :hospitalCode) ");
		sql.append(" 	WHERE V.active_flg = 1                                                                               ");
		sql.append(" 		AND VH.vaccine_status = 1                                                                        ");
		sql.append(" 	GROUP BY V.vaccine_id , injected_no                                                                  ");
		sql.append(" 	ORDER BY vaccine_id , injected_no                                                                    ");
		sql.append(" )as A																	                                 ");
		sql.append(" LEFT JOIN vaccine_child_history as B ON (                                                               ");
		sql.append(" 	A.vaccine_id = B.vaccine_id                                                                          ");
		sql.append(" 	AND A.injected_no = B.injected_no                                                                    ");
		sql.append(" )	                                                                                                     ");
		sql.append(" LEFT JOIN reservation as C ON B.reservation_id = C.reservation_id			                             ");
		sql.append(" WHERE B.active_flg = 1                                                                                  ");
		sql.append(" 	AND B.child_id = :childId                                                                            ");
		sql.append(" 	AND IF(B.reservation_id IS NOT NULL, C.reservation_status NOT IN (0, 5) AND C.active_flg = 1, true)           ");
		sql.append(" GROUP BY A.vaccine_cd																		             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("childId", childId);
		query.setParameter("hospitalCode", hospitalCode);
		
		List<VaccineCdUsingInfo> list = new JpaResultMapper().list(query, VaccineCdUsingInfo.class);
		return list;
	}
	
	@Override
	public List<ReminderBookingVaccineInfo> getReminderBookingVaccineInfo() {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                                                                               ");
		sql.append(" 	u.user_id AS user_id,                                                                             ");
		sql.append(" 	u.name AS user_name,                             									              ");
		sql.append(" 	u.email AS email,                                                                                 ");
		sql.append(" 	u.phone_number AS phoneNumber,                                                                                 ");
		sql.append(" 	V.child_id AS child_id,                                                                           ");
		sql.append(" 	V.child_name AS child_name,                                                                       ");
		sql.append(" 	V.dob AS dob,                                                                                     ");
		sql.append(" 	V.vaccine_id AS vaccine_id,                                                                       ");
		sql.append(" 	V.vaccine_name AS vaccine_name,                                                                   ");
		sql.append(" 	V.limit_age_to_month AS limit_age_to_month,                                                       ");
		sql.append(" 	V.support_fee_age AS support_fee_age,                                                             ");
		sql.append(" 	MIN(V.injected_no) AS injected_no,                                                                ");
		sql.append(" 	V.warning_days AS warning_days,                                                                   ");
		sql.append(" 	H.hospital_id AS hospital_id,                                                                     ");
		sql.append(" 	H.locale AS locale                                                                                ");
		sql.append(" FROM                                                                                                 ");
		sql.append("     (                                                                                                ");
		sql.append(" 	SELECT                                                                                            ");
		sql.append(" 		user_child.child_id AS child_id,                                                              ");
		sql.append(" 			user_child.child_name AS child_name,   												      ");
		sql.append(" 			vcdetail.vaccine_id AS vaccine_id,                                                        ");
		sql.append(" 			vcdetail.vaccine_name AS vaccine_name,                                                    ");
		sql.append(" 			vcdetail.injected_no AS injected_no,                                                      ");
		sql.append(" 			vcdetail.limit_age_to_month AS limit_age_to_month,                                        ");
		sql.append(" 			vcdetail.support_fee_age AS support_fee_age,                                              ");
		sql.append(" 			user_child.user_id AS user_id,                                                            ");
		sql.append(" 			user_child.dob AS dob,                                                                    ");
		sql.append(" 			vcdetail.warning_days AS warning_days,                                                    ");
		sql.append(" 			vcdetail.hospital_id AS hospital_id                                                       ");
		sql.append(" 	FROM user_child                                                                                   ");
		sql.append(" 	LEFT JOIN user ON user_child.user_id = user.user_id                                               ");
		sql.append(" 	JOIN                                                                                              ");
		sql.append(" 	(                                                                                                 ");
		sql.append(" 		(                                                                                             ");
		sql.append(" 		SELECT                                                                                        ");
		sql.append(" 			V.vaccine_id AS vaccine_id,                                                               ");
		sql.append(" 			V.vaccine_type AS vaccine_type,                                                           ");
		sql.append(" 			V.vaccine_name AS vaccine_name,                                                           ");
		sql.append(" 			V.limit_age_to_month AS limit_age_to_month,                                               ");
		sql.append(" 			B.support_fee_age AS support_fee_age,                                                     ");
		sql.append(" 			VH.warning_days AS warning_days,                                                          ");
		sql.append(" 			VID.injected_no AS injected_no,                                                           ");
		sql.append(" 			VH.hospital_id                                                                            ");
		sql.append(" 		FROM vaccine V                                                                                ");
		sql.append(" 		LEFT JOIN vaccine_group VG ON V.vaccine_group_id = VG.vaccine_group_id                        ");
		sql.append(" 		LEFT JOIN                                                                                     ");
		sql.append(" 			(                                                                                         ");
		sql.append(" 			SELECT vaccine_support_fee.vaccine_id AS vaccine_id,                                      ");
		sql.append(" 				GROUP_CONCAT(DISTINCT CONCAT(vaccine_support_fee.from_month, '-', vaccine_support_fee.to_month)");
		sql.append(" 				SEPARATOR ',') AS support_fee_age                                                     ");
		sql.append(" 			FROM vaccine_support_fee                                                                  ");
		sql.append(" 			WHERE vaccine_support_fee.active_flg = 1                                                  ");
		sql.append(" 			GROUP BY vaccine_support_fee.vaccine_id                                                   ");
		sql.append(" 			) B ON V.vaccine_id = B.vaccine_id                                                        ");
		sql.append(" 		LEFT JOIN vaccine_inject_day VID ON V.vaccine_id = VID.vaccine_id                             ");
		sql.append(" 		LEFT JOIN vaccine_hospital VH ON V.vaccine_id = VH.vaccine_id                                 ");
		sql.append(" 		WHERE V.active_flg = 1                                                                        ");
		sql.append(" 			AND VH.vaccine_status = 1                                                                 ");
		sql.append(" 			AND (VH.warning_days IS NOT NULL AND VH.warning_days > 0)                                 ");
		sql.append(" 			AND B.vaccine_id IS NOT NULL                                                              ");
		sql.append(" 			AND (VG.active_flg = 1 OR ISNULL(VG.active_flg))                                          ");
		sql.append(" 			AND (VID.active_flg = 1 OR ISNULL(VID.active_flg))                                        ");
		sql.append(" 		)                                                                                             ");
		sql.append(" 		UNION ALL                                                                                     ");
		sql.append(" 		(                                                                                             ");
		sql.append(" 		SELECT                                                                                        ");
		sql.append(" 			V.vaccine_id AS vaccine_id,                                                               ");
		sql.append(" 			V.vaccine_type AS vaccine_type,                                                           ");
		sql.append(" 			V.vaccine_name AS vaccine_name,                                                           ");
		sql.append(" 			V.limit_age_to_month AS limit_age_to_month,                                               ");
		sql.append(" 			B.support_fee_age AS support_fee_age,                                                     ");
		sql.append(" 			VH.warning_days AS warning_days,                                                          ");
		sql.append(" 			VID.injected_no AS injected_no,                                                           ");
		sql.append(" 			VH.hospital_id                                                                            ");
		sql.append(" 		FROM vaccine V                                                                                ");
		sql.append(" 		LEFT JOIN vaccine_group VG ON V.vaccine_group_id = VG.vaccine_group_id                        ");
		sql.append(" 		LEFT JOIN                                                                                     ");
		sql.append(" 			(                                                                                         ");
		sql.append(" 			SELECT vaccine_support_fee.vaccine_id AS vaccine_id,                                      ");
		sql.append(" 				GROUP_CONCAT(DISTINCT CONCAT(vaccine_support_fee.from_month, '-', vaccine_support_fee.to_month)");
		sql.append(" 				SEPARATOR ',') AS support_fee_age                                                     ");
		sql.append(" 			FROM vaccine_support_fee                                                                  ");
		sql.append(" 			WHERE vaccine_support_fee.active_flg = 1                                                  ");
		sql.append(" 			GROUP BY vaccine_support_fee.vaccine_id                                                   ");
		sql.append(" 			) B ON V.vaccine_id = B.vaccine_id                                                        ");
		sql.append(" 		LEFT JOIN vaccine_inject_day VID ON V.vaccine_id = VID.vaccine_id                             ");
		sql.append(" 		LEFT JOIN vaccine_hospital VH ON V.vaccine_id = VH.vaccine_id		                          ");
		sql.append(" 		WHERE V.active_flg = 1                                                                        ");
		sql.append(" 			AND VH.vaccine_status = 1                                                                 ");
		sql.append(" 			AND (VH.warning_days IS NOT NULL AND VH.warning_days > 0)                                 ");
		sql.append(" 			AND ISNULL(B.vaccine_id)                                                                  ");
		sql.append(" 			AND (VG.active_flg = 1 OR ISNULL(VG.active_flg))                                          ");
		sql.append(" 			AND (VID.active_flg = 1 OR ISNULL(VID.active_flg))                                        ");
		sql.append(" 		)                                                                                             ");
		sql.append(" 	) vcdetail                                                                                        ");
		sql.append(" 	WHERE user_child.active_flg = 1                                                                   ");
		sql.append(" 		AND user.hospital_id = vcdetail.hospital_id                                                   ");
		sql.append(" 	ORDER BY user_child.child_id , vcdetail.vaccine_id , vcdetail.injected_no                         ");
		sql.append(" 	) V                                                                                               ");
		sql.append("     JOIN hospital H ON V.hospital_id = H.hospital_id                                                 ");
		sql.append("     LEFT JOIN vaccine_child_history VCH ON V.child_id = VCH.child_id                                 ");
		sql.append("         AND V.vaccine_id = VCH.vaccine_id                                                            ");
		sql.append("         AND V.injected_no = VCH.injected_no                                                          ");
		sql.append("     LEFT JOIN user u ON V.user_id = u.user_id                                                        ");
		sql.append(" WHERE (VCH.active_flg = 1 OR ISNULL(VCH.active_flg))                                                 ");
		sql.append("     AND ISNULL(VCH.injected_date)                                                                    ");
		sql.append(" 	AND u.active_flg = 1                                                                              ");
		sql.append(" GROUP BY V.child_id , V.vaccine_id, u.name, u.email, V.child_id, V.child_name, V.dob, V.vaccine_id,  ");
		sql.append(" V.vaccine_name, V.limit_age_to_month, V.support_fee_age, V.warning_days, H.hospital_id, H.locale     ");
		sql.append(" ORDER BY u.user_id , V.child_id , V.vaccine_id                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		
		List<ReminderBookingVaccineInfo> list = new JpaResultMapper().list(query, ReminderBookingVaccineInfo.class);
		return list;
	}
	
	@Override
	public List<VaccineReportInfo> getVaccineReport(Date fromDate, Date toDate, String hospitalCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT C.vaccine_id, DATE_FORMAT(C.injected_date, '%Y/%m/%d') date,                               ");
		sql.append(" 	SUM(CASE WHEN status = 3 THEN 1 ELSE 0 END) as number_of_finished,                             ");
		sql.append(" 	COUNT(C.vaccine_id) as total                                                                   ");
		sql.append(" FROM                                                                                              ");
		sql.append(" (                                                                                                 ");
		sql.append(" 	SELECT vaccine_id, 3 status, injected_date                                                     ");
		sql.append(" 	FROM vaccine_child_history                                                                     ");
		sql.append(" 	WHERE reservation_id IS NULL                                                                   ");
		sql.append(" 	AND login_hospital_id IN (SELECT hospital_id FROM hospital WHERE hospital_code = :hospitalCode)");
		if (fromDate != null) {
			sql.append(" AND injected_date >= :fromDate                                                                ");
		}
		if (toDate != null) {
			sql.append(" AND injected_date <= :toDate                                                                  ");
		}
		sql.append(" 	UNION ALL                                                                                      ");
		sql.append(" 	SELECT A.vaccine_id, B.reservation_status status, A.injected_date                              ");
		sql.append(" 	FROM vaccine_child_history A                                                                   ");
		sql.append(" 	LEFT JOIN reservation B ON A.reservation_id = B.reservation_id                                 ");
		sql.append(" 	WHERE A.active_flg = 1                                                                         ");
		sql.append(" 		AND B.active_flg = 1                                                                       ");
		sql.append(" 		AND A.reservation_id IS NOT NULL                                                           ");
		sql.append(" 	AND login_hospital_id IN (SELECT hospital_id FROM hospital WHERE hospital_code = :hospitalCode)");
		if (fromDate != null) {
			sql.append(" AND A.injected_date >= :fromDate                                                              ");
		}
		if (toDate != null) {
			sql.append(" AND A.injected_date <= :toDate                                                                ");
		}
		sql.append(" ) as C                                                                                            ");
		sql.append(" GROUP BY C.vaccine_id, date			                                                           ");
				
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (fromDate != null) {
			query.setParameter("fromDate", MssDateTimeUtil.getTimeStartDate(fromDate));
		}
		if (toDate != null) {
			query.setParameter("toDate", MssDateTimeUtil.getTimeEndDate(toDate));
		}
		List<VaccineReportInfo> list = new JpaResultMapper().list(query, VaccineReportInfo.class);
		return list;
	}

	@Override
	public List<BookingVaccineBackendInfo> getInformationVaccine(
			Integer vaccineId, Integer childId) {
		StringBuffer sql = new StringBuffer();
//		sql.append(" SELECT                                                                             ");
//		sql.append(" 	V.total_inject,                                                                 ");
//		sql.append(" 	IFNULL(max(VCH.injected_no), 0) injectd_no_current,                             ");
//		sql.append(" 	V.limit_age_from_month,                                                         ");
//		sql.append(" 	V.limit_age_to_month,                                                           ");
//		sql.append(" 	VH.from_date,                                                                   ");
//		sql.append(" 	VH.to_date                                                                      ");
//		sql.append(" FROM                                                                               ");
//		sql.append(" 	vaccine_child_history VCH                                                       ");
//		sql.append(" INNER JOIN vaccine V ON VCH.vaccine_id = V.vaccine_id                              ");
//		sql.append(" LEFT JOIN reservation c ON VCH.reservation_id = c.reservation_id                   ");
//		sql.append(" LEFT JOIN vaccine_hospital VH ON VCH.vaccine_hospital_id = VH.vaccine_hospital_id  ");
//		sql.append(" WHERE                                                                              ");
//		sql.append(" 	VCH.active_flg = 1                                                              ");
//		sql.append(" AND (VCH.reservation_id IS NULL OR c.reservation_status < 5)                       ");
//		sql.append(" AND VCH.child_id = :childId                                                        ");
//		sql.append(" AND V.vaccine_id = :vaccineId                                                      ");
//		sql.append(" GROUP BY V.total_inject, V.limit_age_from_month, V.limit_age_to_month, VH.from_date, VH.to_date ");
		sql.append("SELECT total_inject,");
		sql.append("       MAX(injectd_no_current) AS injectd_no_current,								");
		sql.append("       limit_age_from_month,														");
		sql.append("       limit_age_to_month,															");
		sql.append("       from_date,																	");
		sql.append("       to_date																		");
		sql.append("FROM																				");
		sql.append("  (SELECT V.total_inject,															");
		sql.append(" IFNULL(VCH.injected_no, 0) injectd_no_current,										");
		sql.append(" V.limit_age_from_month,															");
		sql.append(" V.limit_age_to_month,																");
		sql.append(" VH.from_date,																		");
		sql.append(" VH.to_date																			");
		sql.append("   FROM vaccine V																	");
		sql.append("   LEFT JOIN vaccine_child_history VCH ON VCH.vaccine_id = V.vaccine_id				");
		sql.append("   AND VCH.active_flg = 1															");
		sql.append("   LEFT JOIN vaccine_hospital VH ON VCH.vaccine_hospital_id = VH.vaccine_hospital_id");
		sql.append("   AND VCH.child_id = :childId														");
		sql.append("   LEFT JOIN reservation c ON VCH.reservation_id = c.reservation_id					");
		sql.append("   AND (VCH.reservation_id IS NULL													");
		sql.append("        OR c.reservation_status NOT IN (0,5))												");
		sql.append("   WHERE V.vaccine_id = :vaccineId) AS AB											");
		sql.append("GROUP BY AB.total_inject,															");
		sql.append("         AB.limit_age_from_month,													");
		sql.append("         AB.limit_age_to_month,														");
		sql.append("         AB.from_date,																");
		sql.append("         AB.to_date																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("childId", childId);
		query.setParameter("vaccineId", vaccineId);
		
		List<BookingVaccineBackendInfo> list = new JpaResultMapper().list(query, BookingVaccineBackendInfo.class);
		
		return list;
	}
	
	@Override
	public List<VaccineInfo> getVaccineInfoList(Integer vaccineId, String hospitalId, String locale) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                                                                              "); 
		sql.append(" 	V.vaccine_id AS vaccine_id,                                                                      ");
		sql.append(" 	IF((GROUP_CONCAT(DISTINCT CONCAT(VSF.from_month, '-', VSF.to_month)                              ");
		sql.append(" 			SEPARATOR ',')) IS NOT NULL,                                                             ");
		sql.append(" 		1,                                                                                           ");
		sql.append(" 		0) AS type_support,                                                                          ");
		sql.append(" 	V.vaccine_type AS vaccine_type,                                                                  ");
		sql.append(" 	V.total_inject AS total_inject,                                                                  ");
		sql.append(" 	V.vaccine_name AS vaccine_name,                                                                  ");
		sql.append(" 	VG.color AS color,                                                                               ");
		sql.append(" 	VG.vaccine_group_id AS vaccine_group_id,                                                         ");
		sql.append(" 	V.limit_age_from_month AS limit_age_from_month,                                                  ");
		sql.append(" 	V.limit_age_to_month AS limit_age_to_month,                                                      ");
		sql.append(" 	VH.vaccine_status AS vaccine_status,        	                                                 ");
		sql.append(" 	VH.from_date AS from_date,                                                                       ");
		sql.append(" 	VH.to_date AS to_date,                                                                           ");
		sql.append(" 	GROUP_CONCAT(DISTINCT CONCAT(VRA.from_month, '-', VRA.to_month)                                  ");
		sql.append(" 		SEPARATOR ',') AS recommend_age,                                                             ");
		sql.append(" 	GROUP_CONCAT(DISTINCT CONCAT(VSF.from_month, '-', VSF.to_month)                                  ");
		sql.append(" 		SEPARATOR ',') AS support_fee_age,                                                           ");
		sql.append(" 	VH.warning_days AS warning_days,                                                                 ");
		sql.append(" 	V.vaccine_cd AS vaccine_cd,                                                                      ");
		sql.append(" 	VID.injected_no AS injected_no,                                                                  ");
		sql.append(" 	VID.day_min AS day_min,                                                                          ");
		sql.append(" 	VID.day_max AS day_max,                                                                          ");
		sql.append(" 	V.description AS description                                                                     ");
		sql.append(" FROM                                                                                                "); 
		sql.append(" 	vaccine V                                                                                        ");
		sql.append(" 	LEFT JOIN vaccine_group VG ON V.vaccine_group_id = VG.vaccine_group_id                           ");
		sql.append(" 	AND VG.active_flg = 1																		     ");
		sql.append(" 	LEFT JOIN vaccine_recommend_age VRA ON V.vaccine_id = VRA.vaccine_id  		                     ");
		sql.append(" 		AND VRA.active_flg = 1                                                                       ");
		sql.append(" 	LEFT JOIN vaccine_support_fee VSF ON V.vaccine_id = VSF.vaccine_id                               ");
		sql.append(" 		AND VSF.active_flg = 1                                                                       ");
		sql.append(" 	LEFT JOIN vaccine_inject_day VID ON V.vaccine_id = VID.vaccine_id                                ");
		sql.append(" 	AND VID.active_flg = 1																		     ");
		sql.append(" 	LEFT JOIN vaccine_hospital VH ON V.vaccine_id = VH.vaccine_id                                    ");
		sql.append(" 		AND VH.hospital_id = :hospitalId								 							 ");
		sql.append(" WHERE V.active_flg = 1                                                                              "); 
		sql.append(" 	AND VH.vaccine_status = 1  		                                                                 ");
		sql.append(" 	AND VH.active_flg = 1  		                                                            	     ");
		if(locale != null){
			sql.append(" 	AND ((V.vaccine_locale = :locale                                       	                         ");
			sql.append(" 	AND V.hospital_id is null)                                             	                         ");
			sql.append(" 	OR (V.vaccine_locale is null                                           	                         ");
			sql.append(" 	AND V.hospital_id = :hospitalId))                                      	                         ");
		}
		
		if (vaccineId != null) {
			sql.append(" 	AND V.vaccine_id = :vaccineId  		                                                        	 ");
		}
		sql.append(" 	GROUP BY V.vaccine_id , injected_no,  vaccine_type, total_inject, vaccine_name, color,                ");
		sql.append(" 		vaccine_group_id, limit_age_from_month,limit_age_to_month, vaccine_status, from_date, to_date,    ");
		sql.append("	 	warning_days, vaccine_cd, injected_no, day_min, day_max, description 							  ");
		sql.append(" ORDER BY vaccine_group_id , vaccine_id , injected_no                                               	  "); 
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (vaccineId != null) {
			query.setParameter("vaccineId", vaccineId);
		}
		query.setParameter("hospitalId", hospitalId);
		if(locale != null){
			query.setParameter("locale", locale);
		}
		
		List<VaccineInfo> list = new JpaResultMapper().list(query, VaccineInfo.class);
		return list;
	}
}
