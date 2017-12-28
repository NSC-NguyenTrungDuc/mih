package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.util.CollectionUtils;

import nta.med.data.dao.medi.nur.Nur5200RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Nur5200RepositoryImpl implements Nur5200RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public void callPrNurNur5200SubDelete(String hospCode, String hoDong, String nurWrdt) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_NUR_NUR5200_SUB_DELETE");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HO_DONG", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NUR_WRDT", String.class, ParameterMode.IN);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_HO_DONG", hoDong);
		query.setParameter("I_NUR_WRDT", nurWrdt);

		query.execute();
	}

	@Override
	public String getNUR5020U00layConfirmYn(String hospCode, Date fDate, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.CONFIRM_YN                                   ");
		sql.append("	  FROM NUR5200 A                                      ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                     ");
		sql.append("	   AND A.NUR_WRDT  = :f_date                          ");
		sql.append("	   AND A.HO_DONG   = :f_ho_dong                       ");
		sql.append("	   AND A.SEQ       = (SELECT MAX(Z.SEQ)               ");
		sql.append("	                      FROM NUR5200 Z                  ");
		sql.append("	                     WHERE Z.HOSP_CODE = A.HOSP_CODE  ");
		sql.append("	                       AND Z.NUR_WRDT  = A.NUR_WRDT   ");
		sql.append("	                       AND Z.HO_DONG   = A.HO_DONG  ) ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", fDate);
		query.setParameter("f_ho_dong", hoDong);

		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}
}
