package nta.med.data.dao.medi.out.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out0113RepositoryCustom;
import nta.med.data.model.ihis.nuro.OUT0106U00PatientCommentItemInfo;

/**
 * @author dainguyen.
 */
public class Out0113RepositoryImpl implements Out0113RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OUT0106U00PatientCommentItemInfo> getOUT0106U00PatientCommentItemInfo(String hospCode, String bunho, String naewonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.PATIENT_INFO                                                                                     ");
		sql.append("     , B.PATIENT_INFO_NAME                                                                                ");
		sql.append("     , A.START_DATE                                                                                       ");
		sql.append("     , A.END_DATE                                                                                         ");
		sql.append("     , A.COMMENTS                                                                                         ");
		sql.append("     , A.BUNHO                                                                                            ");
		sql.append("     , CONCAT(A.BUNHO, A.PATIENT_INFO , DATE_FORMAT(A.START_DATE, '%Y%m%d')) CONT_KEY                     ");
		sql.append("  FROM OUT0112 B                                                                                          ");
		sql.append("     , OUT0113 A                                                                                          ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                                      ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE                                                                       ");
		sql.append("   AND A.BUNHO        = :f_bunho                                                                          ");
		sql.append("   AND A.START_DATE  <= STR_TO_DATE(:f_naewon_date,'%Y/%m/%d')                                            ");
		sql.append("   AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')) > STR_TO_DATE(:f_naewon_date,'%Y/%m/%d')  ");
		sql.append("   AND A.PATIENT_INFO = B.PATIENT_INFO                                                                    ");
		sql.append("   AND SYSDATE() BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))        ");
		sql.append(" ORDER BY CONT_KEY                                                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);

		List<OUT0106U00PatientCommentItemInfo> list = new JpaResultMapper().list(query, OUT0106U00PatientCommentItemInfo.class);
		return list;
	}
}

