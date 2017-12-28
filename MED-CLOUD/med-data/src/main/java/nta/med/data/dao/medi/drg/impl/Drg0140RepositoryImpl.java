package nta.med.data.dao.medi.drg.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.drg.Drg0140RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0103U12LayDrugTreeInfo;

/**
 * @author dainguyen.
 */
public class Drg0140RepositoryImpl implements Drg0140RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS0103U12LayDrugTreeInfo> getOCS0103U12LayDrugTreeListItem(
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT 										");
		sql.append("	       A.CODE             CODE                          ");
		sql.append("	     , A.CODE_NAME        CODE_NAME                     ");
		sql.append("	     , B.CODE1            CODE1                         ");
		sql.append("	     , B.CODE_NAME1       CODE_NAME1                    ");
		sql.append("	  FROM DRG0140 A                                        ");
		sql.append("	     , DRG0141 B                                        ");
		sql.append("	     , INV0110 C                                        ");
		sql.append("	     , OCS0103 D                                        ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode             				");
		sql.append("       AND A.LANGUAGE    = :f_language                      ");
		sql.append("       AND A.LANGUAGE    = B.LANGUAGE                       ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                        ");
		sql.append("	   AND B.CODE = A.CODE                                  ");
		sql.append("	   AND C.SMALL_CODE = B.CODE1                           ");
		sql.append("	   AND C.HOSP_CODE = B.HOSP_CODE                        ");
		sql.append("	   AND D.HOSP_CODE = C.HOSP_CODE                        ");
		sql.append("	   AND D.HANGMOG_CODE = C.JAERYO_CODE                   ");
		sql.append("	   AND D.ORDER_GUBUN IN ( 'B' )                         ");
		sql.append("	                                                        ");
		sql.append("	UNION ALL                                               ");
		sql.append("	SELECT 'AAAA'                                           ");
		sql.append("	      ,'セット'                                           ");
		sql.append("	      ,B.YAKSOK_CODE                                    ");
		sql.append("	      ,B.YAKSOK_NAME                                    ");
		sql.append("	  FROM OCS0300 A                                        ");
		sql.append("	      ,OCS0301 B                                        ");
		sql.append("	 WHERE A.HOSP_CODE     = :hospCode         			    ");
		sql.append("	   AND A.MEMB          = 'ADMIN'                        ");
		sql.append("	   AND A.INPUT_TAB     = '03'                           ");
		sql.append("	   AND B.HOSP_CODE     = A.HOSP_CODE                    ");
		sql.append("	   AND B.FKOCS0300_SEQ = A.PK_SEQ                       ");
		sql.append("	   AND B.MEMB          = A.MEMB                         ");
		sql.append("	                                                        ");
		sql.append("	UNION ALL                                               ");
		sql.append("	SELECT '999'              CODE                          ");
		sql.append("	     , 'その他'           CODE_NAME                       ");
		sql.append("	     , '999'              CODE1                         ");
		sql.append("	     , 'その他'           CODE_NAME1                      ");
		sql.append("	ORDER BY 3                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_language", language);
		
		List<OCS0103U12LayDrugTreeInfo> listResult = new JpaResultMapper().list(query, OCS0103U12LayDrugTreeInfo.class);
		return listResult;
	}
}

