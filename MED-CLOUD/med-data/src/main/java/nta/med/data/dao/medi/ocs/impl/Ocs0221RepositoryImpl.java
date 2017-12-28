package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0221RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OcsaOCS0304U00GrdOCS0304ListInfo;
import nta.med.data.model.ihis.system.ReservedCommentDloOCS0221Info;

/**
 * @author dainguyen.
 */
public class Ocs0221RepositoryImpl implements Ocs0221RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	public String getOcsaOCS0221U00CommonSeq(String seqName){
		StringBuilder sql = new StringBuilder("SELECT SWF_NextVal(:f_seq_name)");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_seq_name", seqName);
		
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<ReservedCommentDloOCS0221Info> getReservedCommentDloOCS0221Info(
			String hospCode, String language, String memb, String categoryGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT :f_memb   MEMB          ,                                            ");
		sql.append("         A.SORT_KEY   SEQ           ,                                           ");   
		sql.append("         A.CODE       CATEGORY_GUBUN,                                           ");   
		sql.append("         A.CODE_NAME  CATEGORY_NAME ,                                           ");   
		sql.append("         0            COMMENT_LIMIT                                             ");   
		sql.append("    FROM OCS0132 A                                                              ");   
		sql.append("   WHERE A.HOSP_CODE   = :f_hosp_code                                           ");
		sql.append("     AND A.LANGUAGE    = :f_language                                            ");
		sql.append("     AND A.CODE_TYPE   = 'CATEGORY_GUBUN'                                       ");   
		sql.append("     AND A.CODE        LIKE :category_gubun                                     ");
		sql.append("     AND A.CODE        <> '99'                                                  ");   
		sql.append("     AND NOT EXISTS    ( SELECT 'X'                                             ");   
		sql.append("                          FROM OCS0221 B                                        ");   
		sql.append("                         WHERE B.HOSP_CODE         = A.HOSP_CODE                ");   
		sql.append("                           AND B.MEMB              = :f_memb                    ");
		sql.append("                           AND B.CATEGORY_GUBUN    = A.CODE )                   ");   
		sql.append("  UNION ALL                                                                     ");   
		sql.append("  SELECT A.MEMB            ,                                                    ");   
		sql.append("         A.SEQ             ,                                                    ");   
		sql.append("         A.CATEGORY_GUBUN  ,                                                    ");   
		sql.append("         A.CATEGORY_NAME   ,                                                    ");   
		sql.append("         A.COMMENT_LIMIT                                                        ");   
		sql.append("    FROM OCS0221 A                                                              ");   
		sql.append("   WHERE A.HOSP_CODE       = :f_hosp_code                                       ");
		sql.append("     AND A.MEMB            =  :f_memb                                           ");
		sql.append("     AND (A.CATEGORY_GUBUN LIKE :category_gubun  OR A.CATEGORY_GUBUN = '99')    ");
		sql.append("   ORDER BY 2  																	");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_memb", memb);
		query.setParameter("category_gubun", categoryGubun);
		List<ReservedCommentDloOCS0221Info> listResult = new JpaResultMapper().list(query, ReservedCommentDloOCS0221Info.class);
		return listResult;
	}
	
}

