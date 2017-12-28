package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl0111RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl0111RepositoryImpl implements Cpl0111RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getFwkNoteListItem(String hospCode,
			String jundalGubun, String find) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE, 																");
		sql.append("	       A.NOTE                                                               ");
		sql.append("	  FROM CPL0111 A                                                            ");
		sql.append("	 WHERE HOSP_CODE    = :hospCode                                             ");
		sql.append("	   AND JUNDAL_GUBUN = :jundalGubun                                          ");
		sql.append("	   AND (A.CODE LIKE IF(:find IS NULL,'%',CONCAT('%',:find,'%'))             ");
		sql.append("	    OR  A.NOTE LIKE IF(:find IS NULL,'%',CONCAT('%',:find,'%')))            ");
		sql.append("	 ORDER BY 1 ASC                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalGubun", jundalGubun);
		query.setParameter("find",find);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public String getNoteVsvNote(String hospCode, String jundalGubun,
			String code) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT NOTE  								");
		sql.append("	FROM CPL0111                                ");
		sql.append("	WHERE HOSP_CODE    = :hospCode              ");
		sql.append("	AND JUNDAL_GUBUN = :jundalGubun             ");
		sql.append("	AND CODE         = :code                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalGubun", jundalGubun);
		query.setParameter("code",code);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getListCPL3020U02InitializeFwkNote(String hospCode, String jundalGubun, String find1){
		StringBuilder sql = new StringBuilder();
		 sql.append("SELECT A.CODE,                          ");
		 sql.append("       A.NOTE                           ");
		 sql.append(" FROM CPL0111 A                         ");
		 sql.append("WHERE HOSP_CODE    = :f_hosp_code       ");
		 sql.append("  AND JUNDAL_GUBUN = :f_jundal_gubun    ");
		 sql.append("  AND (A.CODE  LIKE :f_find1            ");
		 sql.append("   OR  A.NOTE  LIKE :f_find1)           ");
		 sql.append("ORDER BY 1 ASC                          ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_gubun", jundalGubun);
		query.setParameter("f_find1", "%" + find1 + "%");
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
}

