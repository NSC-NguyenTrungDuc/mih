package nta.med.data.dao.medi.opr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.opr.Opr1001RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1020Q00laySusulInfoInfo;

/**
 * @author dainguyen.
 */
public class Opr1001RepositoryImpl implements Opr1001RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR1020Q00laySusulInfoInfo> getNUR1020Q00laySusulInfoInfo(String hospCode, String language,
			String bunho, Double fkinp1001, String fromOpDate, String toOpDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT IFNULL(DATE_FORMAT(A.OP_DATE, '%Y/%m/%d'), '') 	OP_DATE                                                             ");
		sql.append("	     , ''                 										OP_NAME                                                             ");
		sql.append("	  FROM (SELECT OP_RESER_DATE OP_DATE                                                                                                ");
		sql.append("	              ,CONCAT(IF(PRE_OP_NAME1 IS NULL, '', CONCAT(FN_ADM_MSG(3257, :f_language), ': ', PRE_OP_NAME1, CHAR(10), CHAR(13))),  ");
		sql.append("	               IF(POST_OP_NAME1 IS NULL, '', CONCAT(FN_ADM_MSG(3258, :f_language), ': ', POST_OP_NAME1))) OP_NAME                   ");
		sql.append("	          FROM OPR1001                                                                                                              ");
		sql.append("	         WHERE HOSP_CODE = :f_hosp_code                                                                                             ");
		sql.append("	           AND BUNHO 	 = :f_bunho                                                                                                 ");
		sql.append("	           AND FKINP1001 = :f_fkinp1001                                                                                             ");
		sql.append("	           AND OP_RESER_DATE  BETWEEN STR_TO_DATE(:f_from_op_date, '%Y/%m/%d')                                                      ");
		sql.append("	                              AND STR_TO_DATE(:f_to_op_date, '%Y/%m/%d')                                                            ");
		sql.append("	           AND IF(OP_CANCEL_YN IS NULL OR OP_CANCEL_YN = '', 'N', OP_CANCEL_YN) = 'N'                                               ");
		sql.append("	         UNION                                                                                                                      ");
		sql.append("	        SELECT DISTINCT ORDER_DATE OP_DATE                                                                                          ");
		sql.append("	             , '' OP_NAME                                                                                                           ");
		sql.append("	          FROM OCS2003                                                                                                              ");
		sql.append("	         WHERE HOSP_CODE = :f_hosp_code                                                                                             ");
		sql.append("	           AND BUNHO 	 = :f_bunho                                                                                                 ");
		sql.append("	           AND FKINP1001 = :f_fkinp1001                                                                                             ");
		sql.append("	           AND ORDER_DATE BETWEEN STR_TO_DATE(:f_from_op_date, '%Y/%m/%d')                                                          ");
		sql.append("	                          AND STR_TO_DATE(:f_to_op_date, '%Y/%m/%d')                                                                ");
		sql.append("	           AND INPUT_GUBUN = 'D8') A                                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_from_op_date", fromOpDate);
		query.setParameter("f_to_op_date", toOpDate);
		
		List<NUR1020Q00laySusulInfoInfo> list = new JpaResultMapper().list(query, NUR1020Q00laySusulInfoInfo.class);
		return list;
	}
}
