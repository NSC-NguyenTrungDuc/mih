package nta.med.data.dao.medi.out.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out0112RepositoryCustom;
import nta.med.data.model.ihis.nuro.OUT0106U00PatientCommentItemInfo;
import nta.med.data.model.ihis.nuro.OUT0106U00PatientItemInfo;

/**
 * @author dainguyen.
 */
public class Out0112RepositoryImpl implements Out0112RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	
	@Override
	public List<OUT0106U00PatientItemInfo> getOUT0106U00PatientItemInfo(String hospCode, String find1, String naewonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.PATIENT_INFO                                                                                                                             ");
		sql.append("        , A.PATIENT_INFO_NAME                                                                                                                     ");
		sql.append("        , CONCAT(A.PATIENT_INFO , DATE_FORMAT(A.START_DATE, '%Y/%m/%d'))    CONT_KEY                                                              ");
		sql.append(" FROM OUT0112 A                                                                                                                                   ");
		sql.append("WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                  ");
		sql.append("  AND A.PATIENT_INFO LIKE :f_find1                                                                                                                ");
		sql.append("  AND IFNULL(STR_TO_DATE(:f_naewon_date,'%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')) ");
		sql.append("ORDER BY CONT_KEY                                                                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", find1+"%");
		query.setParameter("f_naewon_date", naewonDate);

		List<OUT0106U00PatientItemInfo> list = new JpaResultMapper().list(query, OUT0106U00PatientItemInfo.class);
		return list;
	}
}

