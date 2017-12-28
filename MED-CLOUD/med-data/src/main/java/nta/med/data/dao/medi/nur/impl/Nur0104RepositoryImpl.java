package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0104RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public class Nur0104RepositoryImpl implements Nur0104RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public String getLoadColumnCodeNameInfoCaseHoTeam(String hospCode,String arg1, String arg2) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT A.HO_TEAM FROM NUR0104 A                            ");
		sql.append(" WHERE A.JUKYONG_DATE <= SYSDATE() AND A.HO_DONG =  :f_aArgu1        ");
		sql.append(" AND A.HO_TEAM = :f_aArgu2 AND A.HOSP_CODE  = :f_hosp_code 			");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aArgu1", arg1);  
		query.setParameter("f_aArgu2", arg2); 
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;                           
	}
	
	@Override
	public List<ComboListItemInfo> getComboListHoTeam(String hospCode, String argu1){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT A.HO_TEAM, A.HO_TEAM	");
		sql.append("	FROM NUR0104 A 							");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code		");
		sql.append("	  AND A.JUKYONG_DATE <= SYSDATE()		");
		sql.append("	  AND A.HO_DONG = :f_argu1				");
		sql.append("	ORDER BY A.HO_TEAM, A.HO_TEAM			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_argu1", argu1);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}
	
	@Override
	public String getNUR1001U00BasicQuery2(String hospCode, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.HO_TEAM                                                     ");
		sql.append("     FROM NUR0104 A                                                     ");
		sql.append("     JOIN INP1001 B                                                     ");
		sql.append("       ON B.HOSP_CODE = A.HOSP_CODE                                     ");
		sql.append("      AND B.PKINP1001 = :f_fkinp1001                                    ");
		sql.append("      AND B.HO_DONG1  = A.HO_DONG                                       ");
		sql.append("      AND B.HO_CODE1  = A.HO_CODE                                       ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                    ");
		sql.append("      AND A.JUKYONG_DATE = (SELECT MAX(Z.JUKYONG_DATE)                  ");
		sql.append("                              FROM NUR0104 Z                            ");
		sql.append("                             WHERE Z.HOSP_CODE = A.HOSP_CODE            ");
		sql.append("                               AND Z.HO_DONG   = A.HO_DONG              ");
		sql.append("                               AND Z.HO_CODE   = A.HO_CODE  )           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
}

