package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur4005RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR4005U01GrdNUR4005Info;

/**
 * @author dainguyen.
 */
public class Nur4005RepositoryImpl implements Nur4005RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callFnNurPlanEndDate(String hospCode, Double fknur4001, Date fdate) {
		String sql = "SELECT IFNULL(DATE_FORMAT(FN_NUR_PLAN_END_DATE(:f_hosp_code, :f_fknur4001, :f_date), '%Y/%m/%d'), '') FROM DUAL ";
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fknur4001", fknur4001);
		query.setParameter("f_date", fdate);
		
		List<String> rs = query.getResultList();
		return CollectionUtils.isEmpty(rs) ? "" : rs.get(0);
	}

	@Override
	public List<NUR4005U01GrdNUR4005Info> getNUR4005U01GrdNUR4005Info(String hospCode, Double fknur4001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.FKNUR4001 AS CHAR)                                                                             ");
		sql.append("	     , IFNULL(A.GUBUN, '')                                                                                   ");
		sql.append("	     , A.RESER_DATE                                                                                          ");
		sql.append("	     , IFNULL(A.VALU_CONTENTS, '')                                                                           ");
		sql.append("	     , A.VALU_DATE                                                                                           ");
		sql.append("	     , IFNULL(A.VALUER, '')                                                                                  ");
		sql.append("	     , IFNULL(FN_ADM_LOAD_USER_NM(:f_hosp_code, A.VALUER, IFNULL(VALU_DATE, CURRENT_DATE())), '') VALUER_NAME");
		sql.append("	 FROM NUR4005 A                                                                                              ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                                             ");
		sql.append("	  AND A.FKNUR4001 = :f_fknur4001                                                                             ");
		sql.append("	  ORDER BY A.RESER_DATE                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fknur4001", fknur4001);
		
		List<NUR4005U01GrdNUR4005Info> lstResult = new JpaResultMapper().list(query, NUR4005U01GrdNUR4005Info.class);
		return lstResult;	
	}
	
}

