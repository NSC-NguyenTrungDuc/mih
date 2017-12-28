package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0212RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0203U00LayOCS0212Info;
import nta.med.data.model.ihis.system.LoadOftenUsedResponseInfo;

/**
 * @author dainguyen.
 */
public class Ocs0212RepositoryImpl implements Ocs0212RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Double getMaxSeqOfenUsedHangmogInfo(String hospCode, String membGubun, String memb, String hangmogCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(MAX(A.SEQ), 1)             ");
		sql.append("  FROM OCS0212 A,                        ");
		sql.append("       OCS0103 B,                        ");
		sql.append("       OCS0103 C                         ");
		sql.append(" WHERE A.MEMB_GUBUN   = :f_memb_gubun    ");
		sql.append("   AND A.MEMB         = :f_memb          ");
		sql.append("   AND A.HOSP_CODE    = :f_hosp_code     ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE      ");
		sql.append("   AND B.HANGMOG_CODE = A.HANGMOG_CODE   ");
		sql.append("   AND B.HANGMOG_CODE = :f_hangmog_code  ");
		sql.append("   AND C.HOSP_CODE    = B.HOSP_CODE      ");
		sql.append("   AND C.ORDER_GUBUN  = B.ORDER_GUBUN    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_memb_gubun", membGubun);
		query.setParameter("f_memb", memb);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		List<Double> list = query.getResultList();
		if(list != null && list.size() > 0){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<LoadOftenUsedResponseInfo> getLoadOftenUsedResponseListItem(
			String hospCode, String language, String membGubun, String memb,
			String orderGubun, String wonnaeDrgYn, String searchWord) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.MEMB        ,            																							");                          
		sql.append("	       B.SLIP_CODE   ,                                                                                                              ");
		sql.append("	       C.SLIP_NAME   ,                                                                                                              ");
		sql.append("	       A.HANGMOG_CODE,                                                                                                              ");
		sql.append("	       B.HANGMOG_NAME,                                                                                                              ");
		sql.append("	       A.SEQ         ,                                                                                                              ");
		sql.append("	       A.HOSP_CODE   ,                                                                                                              ");
		sql.append("	       A.MEMB_GUBUN  ,                                                                                                              ");
		sql.append("	       IFNULL(B.WONNAE_DRG_YN, 'N')     WONNAE_DRG_YN,                                                                              ");
		sql.append("	       CONCAT(B.SLIP_CODE , TRIM(LPAD(B.SEQ, 5,'0')) , B.HANGMOG_NAME)    ORDERBYKEY                                                ");
		sql.append("	  FROM OCS0212 A,  OCS0103 B,  OCS0102 C                                                                                            ");
		sql.append("	 WHERE A.MEMB_GUBUN   = :membGubun                                                                                                  ");
		sql.append("	   AND A.MEMB         = :memb                                                                                                       ");
		sql.append("	   AND A.HOSP_CODE    = :hospCode                                                                                                   ");
		sql.append("	   AND A.OFTEN_USE    = 'Y'                                                                                                         ");
		sql.append("	   AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                              ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                 ");
		sql.append("	   AND B.START_DATE  <= SYSDATE()                                                                                                   ");
		sql.append("	   AND B.END_DATE    >= SYSDATE()                                                                                                   ");
		sql.append("	   AND B.ORDER_GUBUN != 'E'                                                                                                         ");
		sql.append("	   AND B.ORDER_GUBUN  = :orderGubun                                                                                                 ");
		sql.append("	   AND (                                                                                                                            ");
		sql.append("	         ( B.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                       ");
		sql.append("	           AND                                                                                                                      ");
		sql.append("	           IFNULL(B.WONNAE_DRG_YN,'N') LIKE :wonnaeDrgYn)                                                                           ");
		sql.append("	          OR                                                                                                               			");
		sql.append("	          ( B.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :wonnaeDrgYn )                			    ");
		sql.append("	       )                                                                                                                            ");
		sql.append("	   AND B.HANGMOG_NAME_INX LIKE IFNULL(:searchWord,'%')                                                                              ");
		sql.append("	   AND C.SLIP_CODE    = B.SLIP_CODE                                                                                                 ");
		sql.append("	   AND C.HOSP_CODE    = A.HOSP_CODE                                                                                                 ");
		sql.append("	   AND C.LANGUAGE     = :language                                                                                                   ");
		sql.append("	 UNION ALL                                                                                                                          ");
		sql.append("	SELECT A.MEMB        ,                                                                                                              ");
		sql.append("	       B.SLIP_CODE   ,                                                                                                              ");
		sql.append("	       C.SLIP_NAME   ,                                                                                                              ");
		sql.append("	       A.HANGMOG_CODE,                                                                                                              ");
		sql.append("	       B.HANGMOG_NAME,                                                                                                              ");
		sql.append("	       A.SEQ         ,                                                                                                              ");
		sql.append("	       A.HOSP_CODE   ,                                                                                                              ");
		sql.append("	       A.MEMB_GUBUN  ,                                                                                                              ");
		sql.append("	       IFNULL(B.WONNAE_DRG_YN, 'N')     WONNAE_DRG_YN,                                                                              ");
		sql.append("	       CONCAT(B.SLIP_CODE , TRIM(LPAD(IFNULL(E.SORT_SEQ, 0),6,'0')) , B.HANGMOG_NAME)    ORDERBYKEY                                 ");
		sql.append("	  FROM                                                                                                                              ");
		sql.append("	     XRT0001 D                                                                                                                      ");
		sql.append("	     LEFT JOIN  XRT0122 E ON E.HOSP_CODE = D.HOSP_CODE AND E.BUWI_CODE = D.XRAY_BUWI AND E.LANGUAGE = :language                     ");
		sql.append("	     RIGHT JOIN OCS0103 B ON D.HOSP_CODE = B.HOSP_CODE AND D.XRAY_CODE = B.HANGMOG_CODE                                             ");
		sql.append("	     , OCS0212 A,  OCS0102 C                                                                                                        ");
		sql.append("	 WHERE A.MEMB_GUBUN   = :membGubun                                                                                                  ");
		sql.append("	   AND A.MEMB         = :memb                                                                                                       ");
		sql.append("	   AND A.HOSP_CODE    = :hospCode                                                                                                   ");
		sql.append("	   AND A.OFTEN_USE    = 'Y'                                                                                                         ");
		sql.append("	   AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                              ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                 ");
		sql.append("	   AND B.START_DATE  <= SYSDATE()                                                                                                   ");
		sql.append("	   AND B.END_DATE    >= SYSDATE()                                                                                                   ");
		sql.append("	   AND B.ORDER_GUBUN  = 'E'                                                                                                         ");
		sql.append("	   AND B.ORDER_GUBUN  = :orderGubun                                                                                                 ");
		sql.append("	   AND B.HANGMOG_NAME_INX LIKE IFNULL(:searchWord,'%')                                                                              ");
		sql.append("	   AND C.SLIP_CODE    = B.SLIP_CODE                                                                                                 ");
		sql.append("	   AND C.HOSP_CODE    = A.HOSP_CODE                                                                                                 ");
		sql.append("	   AND C.LANGUAGE    = :language                                                                                                 	");
		sql.append("	 ORDER BY ORDERBYKEY                                                                                                                ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("membGubun", membGubun);
		query.setParameter("memb", memb);
		query.setParameter("hospCode", hospCode);
		query.setParameter("orderGubun", orderGubun);
		query.setParameter("wonnaeDrgYn", wonnaeDrgYn);
		query.setParameter("searchWord", searchWord);
		query.setParameter("language", language);
		
		List<LoadOftenUsedResponseInfo> list = new JpaResultMapper().list(query, LoadOftenUsedResponseInfo.class);
		return list;
	}
	
	@Override
	public List<OCS0203U00LayOCS0212Info> getOCS0203U00LayOCS0212Info(String hospCode, String memb, String slipCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.HANGMOG_CODE                      ");
		sql.append("      ,A.OFTEN_USE                         ");
		sql.append("      ,A.MEMB                              ");
		sql.append("      ,A.MEMB_GUBUN                        ");
		sql.append("      ,A.HOSP_CODE                         ");
		sql.append("  FROM OCS0212 A                           ");
		sql.append("      ,OCS0103 B                           ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code       ");
		sql.append("   AND A.MEMB         = :f_memb            ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE        ");
		sql.append("   AND B.SLIP_CODE    = :f_slip_code       ");
		sql.append("   AND B.HANGMOG_CODE = A.HANGMOG_CODE     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_slip_code", slipCode);
		query.setParameter("f_memb", memb);
		query.setParameter("f_hosp_code", hospCode);
		
		List<OCS0203U00LayOCS0212Info> list = new JpaResultMapper().list(query, OCS0203U00LayOCS0212Info.class);
		return list;
	}
}

