package nta.med.data.dao.medi.bas.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0111RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0111U00GrdBas0111ItemInfo;

/**
 * @author dainguyen.
 */
public class Bas0111RepositoryImpl implements Bas0111RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<BAS0111U00GrdBas0111ItemInfo> getBAS0111U00GrdBas0111ItemInfo(String hospCode, String johapGubun, String johap, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JOHAP_GUBUN                                   ");
		sql.append("      , A.JOHAP                                         ");
		sql.append("      , A.GAEIN                                         ");
		sql.append("      , A.USE_YN                                        ");
		sql.append("      , A.ZIP_CODE1                                     ");
		sql.append("      , A.ZIP_CODE2                                     ");
		sql.append("      , A.ADDRESS                                       ");
		sql.append("      , A.ADDRESS1                                      ");
		sql.append("      , IFNULL(A.GAEIN_NAME, B.JOHAP_NAME)              ");
		sql.append("      ,CONCAT(A.JOHAP, A.GAEIN)  CONT_KEY               ");
		sql.append("   FROM BAS0110 B                                       ");
		sql.append("      , BAS0111 A                                       ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                    ");
		sql.append("    AND A.JOHAP_GUBUN = :f_johap_gubun                  ");
		sql.append("    AND A.JOHAP       = :f_johap                        ");
		sql.append("    AND A.JOHAP_GUBUN = B.JOHAP_GUBUN                   ");
		sql.append(" AND A.JOHAP       = B.JOHAP AND B.LANGUAGE = :language ");
		sql.append("    AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE   ");
		sql.append("  ORDER BY A.JOHAP										");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_johap_gubun", johapGubun);
		query.setParameter("f_johap", johap);
		query.setParameter("language", language);

		List<BAS0111U00GrdBas0111ItemInfo> list = new JpaResultMapper().list(query, BAS0111U00GrdBas0111ItemInfo.class);
		return list;
	}
	
	@Override
	public List<String> getNuroNuroOUT0101U02GetGaein(String hospCode, String johap,
			String gaein) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.GAEIN						");
		sql.append("  FROM BAS0111 A                    ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode   ");
		sql.append("   AND A.JOHAP     = :johap       ");
		sql.append("    AND A.GAEIN  LIKE :gaein       ");
		sql.append("   ORDER BY A.GAEIN                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("johap", johap);
		query.setParameter("gaein", gaein);
		
		return query.getResultList();
	}
}

