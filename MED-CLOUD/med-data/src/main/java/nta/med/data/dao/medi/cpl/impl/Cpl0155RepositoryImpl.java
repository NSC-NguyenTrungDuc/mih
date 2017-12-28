package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl0155RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl0155RepositoryImpl implements Cpl0155RepositoryCustom {
    @PersistenceContext
    private EntityManager entityManager;
    
	@Override
	public String getCPL3020U00FwkResultGetY(String hospCode, String resultForm) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'                 						");           
		sql.append("	FROM CPL0155                                    ");
		sql.append("	WHERE HOSP_CODE = :hospCode                  ");
		sql.append("	AND RESULT_CODE_GUBUN = :resultForm          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("resultForm", resultForm);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getCPL3020U00FwkResultInputSQL(
			String hospCode, String find, String resultForm) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE																		");
		sql.append("	    , CODE_NAME                                                                 ");
		sql.append("	FROM CPL0155                                                                    ");
		sql.append("	WHERE HOSP_CODE = :hospCode                                                     ");
		sql.append("	  AND ((CODE        LIKE IF(:find IS NULL, '%', CONCAT('%',:find,'%')))         ");
		sql.append("	  OR  (CODE_NAME   LIKE IF(:find IS NULL, '%', CONCAT('%',:find,'%'))))         ");
		sql.append("	  AND RESULT_CODE_GUBUN    = :resultForm                                        ");
		sql.append("	ORDER BY CODE;                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("find", find);
		query.setParameter("resultForm", resultForm);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<ComboListItemInfo> getCPL3020U02FwkResult(String hospCode, String find1, String resultCodeGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CODE                                       ");
		sql.append("     , CODE_NAME                                  ");
		sql.append("  FROM CPL0155                                    ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code                   ");
		sql.append("   AND ((CODE        LIKE :f_find1)     ");
		sql.append("    OR  (CODE_NAME   LIKE :f_find1))    ");
		sql.append("   AND RESULT_CODE_GUBUN    = :f_result_form      ");
		sql.append(" ORDER BY CODE                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", "%"+find1+"%");
		query.setParameter("f_result_form", resultCodeGubun);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
}

