package nta.med.data.dao.medi.bas.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.data.dao.medi.bas.Bas0380RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Bas0380RepositoryImpl implements Bas0380RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	public String checkHangSangInfo(String hospCode, String hangmogCode, String sangCode, Date checkDate, String inOutGubun,
			String gwa, Date birthDate){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OCS_SANG_HANGMOG_CHECK(:f_hosp_code, :f_hangmog_code,      ");
		sql.append(" :f_sang_code, :f_check_date, :f_in_out_gubun, :f_gwa, :f_birth_date) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_sang_code", sangCode);
		query.setParameter("f_check_date", checkDate);
		query.setParameter("f_in_out_gubun", inOutGubun);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_birth_date", birthDate);
		List<String> list  = query.getResultList();
		if(list != null && list.size() > 0){
			return list.get(0);
		}
		return null;
	}
}

