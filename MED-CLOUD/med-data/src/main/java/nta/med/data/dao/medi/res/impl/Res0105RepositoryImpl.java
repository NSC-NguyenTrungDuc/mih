package nta.med.data.dao.medi.res.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.res.Res0105RepositoryCustom;
import nta.med.data.model.ihis.nuro.NuroRES1001U00DoctorReservationDateListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Res0105RepositoryImpl implements Res0105RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Res0105RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NuroRES1001U00DoctorReservationDateListItemInfo> getNuroRES1001U00DoctorReservationDateList (String hospitalCode, String doctorCode, String startDate, String endDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR,                                                                                                                                                   ");
		sql.append("        A.YYMM,                                                                                                                                                    ");
		sql.append("        A.RES_DATE,                                                                                                                                                ");
		sql.append("        IF(SIGN(A.RES_DATE - (STR_TO_DATE(DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), '%Y/%m/%d')-1)) = -1,  '0',                                                          ");
		sql.append("        (CASE WHEN FN_OUT_CHECK_RES_DOC_SCHEDULE(:hospitalCode, A.RES_DATE, NULL, A.DOCTOR) <> '0'                                                                 ");
		sql.append("                           THEN '0'                                                                                                                                ");
		sql.append("                  ELSE A.RES_FLAG END ))    RES_FLAG,                                                                                                              ");
		sql.append(" CONCAT(IFNULL(CASE A.IN_OUT_FLG WHEN 1 THEN A.RES_INWON END,'0') + IFNULL(CASE A.IN_OUT_FLG WHEN 0 THEN A.RES_INWON END,'0'), '/', IFNULL(B.DOC_RES_LIMIT, '0')), ");
		sql.append(" CONCAT(IFNULL(CASE A.IN_OUT_FLG WHEN 0 THEN A.RES_INWON END,'0'), '/', IFNULL(B.OUT_HOSP_RES_LIMIT, '0'))                                                         ");
		sql.append("FROM VW_OUT_RES0105 A LEFT JOIN RES0102 B ON  B.HOSP_CODE =  A.HOSP_CODE  AND  B.DOCTOR = A.DOCTOR                                                                 ");
		sql.append("WHERE A.HOSP_CODE = :hospitalCode                                                                                                                                  ");
		if (!StringUtils.isEmpty(doctorCode)) {
			sql.append("        AND A.DOCTOR    = :doctorCode                                                                                                                          ");
		}
		if (!StringUtils.isEmpty(startDate)) {
			sql.append("        AND A.RES_DATE >= STR_TO_DATE(:startDate, '%Y/%m/%d')                                                                                                  ");
		}
		if (!StringUtils.isEmpty(endDate)) {
			sql.append("        AND A.RES_DATE <= STR_TO_DATE(:endDate, '%Y/%m/%d')                                                                                                    ");
		}
		sql.append("ORDER BY A.RES_DATE;                                                                                                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		if (!StringUtils.isEmpty(startDate)) {
			query.setParameter("startDate", startDate);
		}
		if (!StringUtils.isEmpty(endDate)) {
			query.setParameter("endDate", endDate);
		}

		List<NuroRES1001U00DoctorReservationDateListItemInfo> list = new JpaResultMapper().list(query, NuroRES1001U00DoctorReservationDateListItemInfo.class);

		return list;
	}
}

