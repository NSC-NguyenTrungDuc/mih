package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0304RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0304Q00layOCS0304Info;
import nta.med.data.model.ihis.ocsa.OcsaOCS0304U00GrdOCS0304ListInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0304U00GrdOCS0305ListInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0304U00GrdOCS0306ListInfo;
/**
 * @author dainguyen.
 */
public class Ocs0304RepositoryImpl implements Ocs0304RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OcsaOCS0304U00GrdOCS0304ListInfo> getOcsaOCS0304U00GrdOCS0304ListInfo(
			String hospCode, String membGubun, String doctor,
			String yaksokDirectCode) {
		StringBuilder sql = new StringBuilder();
		
		 sql.append("	SELECT A.MEMB               ,																");
		 sql.append("	      A.MEMB_GUBUN         ,                                                                ");
		 sql.append("	      A.YAKSOK_DIRECT_CODE ,                                                                ");
		 sql.append("	      A.YAKSOK_DIRECT_NAME ,                                                                ");
		 sql.append("	      A.SEQ                ,                                                                ");
		 sql.append("	      A.MENT                                                                                ");
		 sql.append("	 FROM OCS0304 A                                                                             ");
		 sql.append("	WHERE A.HOSP_CODE        = :hospCode                                                     ");
		 sql.append("	  AND A.MEMB_GUBUN       = :membGubun                                                     ");
		 sql.append("	  AND A.MEMB             LIKE CONCAT('%',SUBSTRING(:doctor, 3))                           ");
		 sql.append("	  AND (A.YAKSOK_DIRECT_CODE LIKE CONCAT('%' , :yaksokDirectCode , '%')                  ");
		 sql.append("	       OR A.YAKSOK_DIRECT_NAME LIKE CONCAT('%' , :yaksokDirectCode , '%' ))             ");
		 sql.append("	ORDER BY A.SEQ                                                                             ");
		
		 Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("hospCode", hospCode);
		 query.setParameter("membGubun", membGubun);
		 query.setParameter("doctor", doctor);
		 query.setParameter("yaksokDirectCode", yaksokDirectCode);
		
		List<OcsaOCS0304U00GrdOCS0304ListInfo> listResult = new JpaResultMapper().list(query, OcsaOCS0304U00GrdOCS0304ListInfo.class);
		return listResult;
	}

	@Override
	public List<OcsaOCS0304U00GrdOCS0305ListInfo> getOcsaOCS0304U00GrdOCS0305ListInfo(
			String hospCode, String membGubun, String doctor,
			String yaksokDirectCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.MEMB              ,																	");
		sql.append("	       A.YAKSOK_DIRECT_CODE,                                                                   " );
		sql.append("	       A.PK_SEQ            ,                                                                   " );
		sql.append("	       A.DIRECT_GUBUN      ,                                                                   " );
		sql.append("	       B.NUR_GR_NAME       ,                                                                   " );
		sql.append("	       A.DIRECT_CODE       ,                                                                   " );
		sql.append("	       C.NUR_MD_NAME       ,                                                                   " );
		sql.append("	       A.DIRECT_CONT1      ,                                                                   " );
		sql.append("	       A.DIRECT_CONT2      ,                                                                   " );
		sql.append("	       A.DIRECT_TEXT       ,                                                                   " );
		sql.append("	       C.DIRECT_CONT_YN                                                                        " );
		sql.append("	  FROM OCS0305 A,                                                                              " );
		sql.append("	       NUR0110 B,                                                                              " );
		sql.append("	       NUR0111 C                                                                               " );
		sql.append("	 WHERE A.HOSP_CODE          = :hospCode                                                        " );
		sql.append("	   AND A.MEMB_GUBUN         = :membGubun                                                       " );
		sql.append("	   AND A.YAKSOK_DIRECT_CODE = :yaksokDirectCode                                     		   " );
		sql.append("	   AND A.MEMB               LIKE CONCAT('%', SUBSTRING(:doctor , 3)) 			               " );
		sql.append("	   AND B.HOSP_CODE          = A.HOSP_CODE                                                      " );
		sql.append("	   AND B.NUR_GR_CODE        = A.DIRECT_GUBUN                                                   " );
		sql.append("	   AND C.HOSP_CODE          = A.HOSP_CODE                                                      " );
		sql.append("	   AND C.NUR_GR_CODE        = A.DIRECT_GUBUN                                                   " );
		sql.append("	   AND C.NUR_MD_CODE        = A.DIRECT_CODE                                                    " );
		sql.append("	 ORDER BY A.PK_SEQ;                                                                            " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("membGubun", membGubun);
		query.setParameter("doctor", doctor);
		query.setParameter("yaksokDirectCode", yaksokDirectCode);
		
		List<OcsaOCS0304U00GrdOCS0305ListInfo> listResult = new JpaResultMapper().list(query,OcsaOCS0304U00GrdOCS0305ListInfo.class);
		return listResult;
	}

	@Override
	public List<OcsaOCS0304U00GrdOCS0306ListInfo> getOcsaOCS0304U00GrdOCS0306ListInfo(
			String hospCode, String membGubun, String doctor,
			String yaksokDirectCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.MEMB               ,											");
		sql.append("	       A.YAKSOK_DIRECT_CODE ,                                          " );
		sql.append("	       A.DIRECT_GUBUN       ,                                          " );
		sql.append("	       A.DIRECT_CODE        ,                                          " );
		sql.append("	       A.DIRECT_DETAIL      ,                                          " );
		sql.append("	       A.PK_SEQ             ,                                          " );
		sql.append("	       A.SEQ                ,                                          " );
		sql.append("	       A.HANGMOG_CODE       ,                                          " );
		sql.append("	       A.SURYANG            ,                                          " );
		sql.append("	       A.NALSU              ,                                          " );
		sql.append("	       A.ORD_DANUI          ,                                          " );
		sql.append("	       A.BOGYONG_CODE       ,                                          " );
		sql.append("	       A.JUSA_CODE          ,                                          " );
		sql.append("	       A.JUSA_SPD_GUBUN     ,                                          " );
		sql.append("	       A.DV                 ,                                          " );
		sql.append("	       A.DV_TIME            ,                                          " );
		sql.append("	       A.INSULIN_FROM       ,                                          " );
		sql.append("	       A.INSULIN_TO         ,                                          " );
		sql.append("	       A.TIME_GUBUN         ,                                          " );
		sql.append("	       A.BOM_SOURCE_KEY     ,                                          " );
		sql.append("	       A.BOM_YN                                                        " );
		sql.append("	  FROM OCS0306 A                                                       " );
		sql.append("	 WHERE A.HOSP_CODE          = :hospCode                                " );
		sql.append("	   AND A.MEMB_GUBUN         = :membGubun                               " );
		sql.append("	   AND A.YAKSOK_DIRECT_CODE = :yaksokDirectCode                        " );
		sql.append("	   AND A.MEMB               = :doctor                                  " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("membGubun", membGubun);
		query.setParameter("doctor", doctor);
		query.setParameter("yaksokDirectCode", yaksokDirectCode);
		
		List<OcsaOCS0304U00GrdOCS0306ListInfo> listResult = new JpaResultMapper().list(query,OcsaOCS0304U00GrdOCS0306ListInfo.class);
		return listResult;
	}

	@Override
	public String getOCS0304U00GetYaksokDirectName(String hospCode,
			String membGubun, String code, String doctor) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.YAKSOK_DIRECT_NAME						");						
		sql.append("	  FROM OCS0304 A                                ");
		sql.append("	 WHERE A.HOSP_CODE          = :hospCode      ");
		sql.append("	   AND A.MEMB_GUBUN         =  :membGubun    ");
		sql.append("	   AND A.YAKSOK_DIRECT_CODE = :code           ");
		sql.append("	   AND A.MEMB               = :doctor        ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("membGubun", membGubun);
		query.setParameter("doctor", doctor);
		query.setParameter("code", code);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OcsaOCS0304U00GrdOCS0305ListInfo> getOcsaOCS0304U00GrdOCS0305ListInfoext(String hospCode, String memb) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.MEMB              ,																   ");
		sql.append("	       A.YAKSOK_DIRECT_CODE,                                                                   " );
		sql.append("	       A.PK_SEQ            ,                                                                   " );
		sql.append("	       A.DIRECT_GUBUN      ,                                                                   " );
		sql.append("	       B.NUR_GR_NAME 	   ,                                                                   " );
		sql.append("	       A.DIRECT_CODE       ,                                                                   " );
		sql.append("	       C.NUR_MD_NAME  	   ,                                                                   " );
		sql.append("	       A.DIRECT_CONT1      ,                                                                   " );
		sql.append("	       A.DIRECT_CONT2      ,                                                                   " );
		sql.append("	       A.DIRECT_TEXT       ,                                                                   " );
		sql.append("	       C.DIRECT_CONT_YN                                                                        " );
		sql.append("	  FROM OCS0305 A,                                                                              " );
		sql.append("	       NUR0110 B,                                                                              " );
		sql.append("	       NUR0111 C                                                                               " );
		sql.append("	 WHERE A.HOSP_CODE          = :hospCode                                                        " );
		sql.append("	   AND (   A.MEMB            LIKE   CONCAT('%', SUBSTRING(:memb , 3))		               	   " );
		sql.append("	           							OR A.MEMB = 'ADMIN')		               				   " );
		sql.append("	   AND B.HOSP_CODE          = A.HOSP_CODE                                                      " );
		sql.append("	   AND B.NUR_GR_CODE        = A.DIRECT_GUBUN                                                   " );
		sql.append("	   AND C.HOSP_CODE          = A.HOSP_CODE                                                      " );
		sql.append("	   AND C.NUR_GR_CODE        = A.DIRECT_GUBUN                                                   " );
		sql.append("	   AND C.NUR_MD_CODE        = A.DIRECT_CODE                                                    " );
		sql.append("	 ORDER BY A.PK_SEQ;                                                                            " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("memb", memb);
		
		List<OcsaOCS0304U00GrdOCS0305ListInfo> listResult = new JpaResultMapper().list(query,OcsaOCS0304U00GrdOCS0305ListInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0304Q00layOCS0304Info> getOCS0304Q00layOCS0304Info(String hospCode, String memb) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	 SELECT A.MEMB          				   					");
		sql.append("	      ,A.YAKSOK_DIRECT_CODE                  				" );
		sql.append("	      ,A.YAKSOK_DIRECT_NAME                  				" );
		sql.append("	      ,A.SEQ                                 				" );
		sql.append("	      ,A.MENT                  								" );
		sql.append("	  FROM OCS0304 A                  							" );
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                      		" );
		sql.append("	   AND A.MEMB    LIKE  CONCAT('%', SUBSTRING(:memb , 3))    " );
		sql.append("	 UNION                  									" );
		sql.append("	SELECT A.MEMB                            					" );
		sql.append("	      ,A.YAKSOK_DIRECT_CODE                  				" );
		sql.append("	      ,A.YAKSOK_DIRECT_NAME                  				" );
		sql.append("	      ,A.SEQ                                 				" );
		sql.append("	      ,A.MENT                  								" );
		sql.append("	  FROM OCS0304 A                  							" );
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                  	   		" );
		sql.append("	   AND A.MEMB      = 'ADMIN'  				   				" );
		sql.append("	 ORDER BY 4                  								" );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("memb", memb);
		
		List<OCS0304Q00layOCS0304Info> listResult = new JpaResultMapper().list(query,OCS0304Q00layOCS0304Info.class);
		return listResult;
	}
}

