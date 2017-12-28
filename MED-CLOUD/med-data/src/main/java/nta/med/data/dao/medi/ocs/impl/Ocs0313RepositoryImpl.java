package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0313RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0311Q00LayDownListInfo;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetHangmogListInfo;
import nta.med.data.model.ihis.ocso.OCSACTDefaultJearyoInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdJaeryoGridColumnChangedInfo;

/**
 * @author dainguyen.
 */
public class Ocs0313RepositoryImpl implements Ocs0313RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS0311U00grdSetHangmogListInfo> getOCS0311U00grdSetHangmogListInfo(String hospCode, String setPart, String hangmogCode, String setCode, String language) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.SET_PART, A.HANGMOG_CODE , A.SET_CODE , A.SET_HANGMOG_CODE, B.HANGMOG_NAME                                       " );
		sql.append(" , A.SURYANG , A.DANUI , C.CODE_NAME         DANUI_NAME                                                                    " );
		sql.append(" , FN_OCS_BULYONG_CHECK(:f_hosp_code, A.SET_HANGMOG_CODE,SYSDATE())  BULYONG_YN                                                          " );
		sql.append(" FROM OCS0132 C RIGHT JOIN OCS0313 A ON  C.HOSP_CODE = A.HOSP_CODE AND C.CODE = A.DANUI AND C.CODE_TYPE = 'ORD_DANUI'      " );
		sql.append(" AND C.LANGUAGE = :f_language                                                                                              " );
		sql.append("  , OCS0103 B                                                                                                              " );
		sql.append("  WHERE A.HOSP_CODE         = :f_hosp_code                                                                                 " );
		sql.append(" AND A.SET_PART          = :f_set_part                                                                                     " );
		sql.append(" AND A.HANGMOG_CODE      = :f_hangmog_code                                                                                 " );
		sql.append(" AND A.SET_CODE          = :f_set_code                                                                                     " );
		sql.append(" AND B.HOSP_CODE         = A.HOSP_CODE                                                                                     " );
		sql.append(" AND B.HANGMOG_CODE      = A.SET_HANGMOG_CODE                                                                              " );
		sql.append(" AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE                                                                         " );
		sql.append(" ORDER BY A.SET_HANGMOG_CODE																								");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_set_part", setPart);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_set_code", setCode);
		query.setParameter("f_language", language);
		List<OCS0311U00grdSetHangmogListInfo> listGrdSetHangmog= new JpaResultMapper().list(query, OCS0311U00grdSetHangmogListInfo.class);
		return listGrdSetHangmog;
	}

	@Override
	public List<OCSACTDefaultJearyoInfo> getOCSACTDefaultJearyoInfo(String hospCode, String language, String hangmogCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT SET_HANGMOG_CODE, SURYANG, DANUI                                                        ");
		sql.append("      , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',DANUI,:f_hosp_code,:f_langauge)         DANUI_NAME    ");
		sql.append("   FROM OCS0313                                                                                 ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code AND HANGMOG_CODE  = :f_hangmog_code AND DEFAULT_CHECK = 'Y'    ");
		sql.append("  ORDER BY 1																					");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_langauge", language);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<OCSACTDefaultJearyoInfo> listGrdSetHangmog= new JpaResultMapper().list(query, OCSACTDefaultJearyoInfo.class);
		return listGrdSetHangmog;
	}

	@Override
	public List<OCSACTGrdJaeryoGridColumnChangedInfo> getOCSACTGrdJaeryoGridColumnChangedInfo(String hospCode, String language, String hangmogCode,
			String setHangmogCode, boolean xrts) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT B.HANGMOG_NAME                                                                                                          ");
		sql.append("        , CAST( A.SURYANG AS CHAR)                                                                                                             ");
		sql.append("        , IFNULL(A.DANUI,B.ORD_DANUI) DANUI                                                                                     ");
		sql.append("        , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',IFNULL(A.DANUI,B.ORD_DANUI),:f_hosp_code,:f_language)         DANUI_NAME            ");
		if(xrts){
		sql.append("        ,' '                                                                                                                    ");
		}else{
			sql.append("        , D.BUN_CODE                                                                                                            ");
		}
		sql.append("        , B.INPUT_CONTROL                                                                                                      ");
		sql.append("     FROM OCS0313 A                                                                                                               ");
		if(xrts){
			sql.append("  , OCS0103 B																													");
		}else{
			sql.append("        , ( SELECT X.SG_CODE                                                                                                    ");
			sql.append("                 , X.SG_NAME                                                                                                    ");
			sql.append("                 , X.SG_YMD                                                                                                     ");
			sql.append("                 , X.BULYONG_YMD                                                                                                ");
			sql.append("                 , X.BUN_CODE                                                                                                   ");
			sql.append("              FROM BAS0310 X                                                                                                    ");
			sql.append("             WHERE X.HOSP_CODE = :f_hosp_code                                                                                   ");
			sql.append("               AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                            ");
			sql.append("                                 FROM BAS0310 Z                                                                                 ");
			sql.append("                                WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                 ");
			sql.append("                                  AND Z.SG_CODE   = X.SG_CODE                                                                   ");
			sql.append("                                  AND Z.SG_YMD   <= SYSDATE() )                                                                 ");
			sql.append("          ) D RIGHT JOIN OCS0103 B ON D.SG_CODE  = B.SG_CODE                                                                    ");
		}
		sql.append("    WHERE A.HOSP_CODE        = :f_hosp_code                                                                                     ");
		sql.append("      AND A.HANGMOG_CODE     = :f_hangmog_code                                                                                  ");
		sql.append("      AND A.SET_HANGMOG_CODE = :f_set_hangmog_code                                                                              ");
		sql.append("      AND B.HOSP_CODE        = A.HOSP_CODE                                                                                      ");
		sql.append("      AND B.HANGMOG_CODE     = A.SET_HANGMOG_CODE                                                                               ");
		sql.append("      AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE 																		");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hangmog_code", hangmogCode); 
		query.setParameter("f_set_hangmog_code", setHangmogCode); 
		List<OCSACTGrdJaeryoGridColumnChangedInfo> listGrd= new JpaResultMapper().list(query, OCSACTGrdJaeryoGridColumnChangedInfo.class);
		return listGrd;   
	}

	@Override
	public List<OCSACTGrdJaeryoGridColumnChangedInfo> getOCSACTGrdJaeryoGridColumnChangedInfoCaseElse(String hospCode, String language,
			String hangmogCode,boolean xrts) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT HANGMOG_NAME                                                                                ");
		sql.append("       , '1'          SURYANG                                                                       ");
		sql.append("       , ORD_DANUI    DANUI                                                                         ");
		sql.append("       , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',ORD_DANUI,:f_hosp_code,:f_language)   DANUI_NAME         ");
		if(xrts){
			sql.append("       , ' '                                                                                 ");
		}else{
			sql.append("       , D.BUN_CODE                                                                                 ");
		}
		sql.append("       , A.INPUT_CONTROL                                                                            ");
		sql.append("    FROM                                                                                            ");
		if(xrts){
			sql.append("       OCS0103 A                                                                                ");
		}else{
			sql.append("        ( SELECT X.SG_CODE                                                                          ");
			sql.append("                , X.SG_NAME                                                                         ");
			sql.append("                , X.SG_YMD                                                                          ");
			sql.append("                , X.BULYONG_YMD                                                                     ");
			sql.append("                , X.BUN_CODE                                                                        ");
			sql.append("             FROM BAS0310 X                                                                         ");
			sql.append("            WHERE X.HOSP_CODE = :f_hosp_code                                                        ");
			sql.append("              AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                 ");
			sql.append("                                 FROM BAS0310 Z                                                     ");
			sql.append("                                WHERE Z.HOSP_CODE = X.HOSP_CODE                                     ");
			sql.append("                                  AND Z.SG_CODE   = X.SG_CODE                                       ");
			sql.append("                                  AND Z.SG_YMD   <= SYSDATE() )                                     ");
			sql.append("         ) D RIGHT JOIN OCS0103 A ON D.SG_CODE = A.SG_CODE                                          ");
		}
		sql.append("   WHERE A.HOSP_CODE        = :f_hosp_code                                                          ");
		sql.append("     AND A.HANGMOG_CODE     = :f_hangmog_code                                                       ");
		sql.append("     AND IFNULL(A.IF_INPUT_CONTROL, 'C') <> 'P'                                                     ");
		sql.append("     AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE 												");

		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hangmog_code", hangmogCode); 
		List<OCSACTGrdJaeryoGridColumnChangedInfo> listGrd= new JpaResultMapper().list(query, OCSACTGrdJaeryoGridColumnChangedInfo.class);
		return listGrd;   
	}

	@Override
	public List<OCS0311Q00LayDownListInfo> getOCS0311Q00LayDownListInfo(
			String hospCode, String setPart, String hangmogCode, String setCode, String language) {
		StringBuilder sql= new StringBuilder();
		sql.append("	SELECT A.SET_PART                                                                                                                                   	");
		sql.append("	     , A.HANGMOG_CODE                                                                                                                                   ");
		sql.append("	     , A.SET_CODE                                                                                                                                       ");
		sql.append("	     , A.SET_HANGMOG_CODE                                                                                                                               ");
		sql.append("	     , B.HANGMOG_NAME                                                                                                                                   ");
		sql.append("	     , A.SURYANG                                                                                                                                        ");
		sql.append("	     , A.DANUI                                                                                                                                          ");
		sql.append("	     , C.CODE_NAME         DANUI_NAME                                                                                                                   ");
		sql.append("	     , FN_OCS_BULYONG_CHECK(:f_hosp_code,A.SET_HANGMOG_CODE,SYSDATE())  BULYONG_YN                                                                      ");
		sql.append("	     , D.SLIP_NAME                                                                                                                                      ");
		sql.append("	     , B.INPUT_CONTROL                                                                                                                                  ");
		sql.append("	     , E.BUN_CODE                                                                                                                                       ");
		sql.append("	  FROM                                                                                                                                                  ");
		sql.append("	     OCS0132 C RIGHT JOIN OCS0313 A ON C.HOSP_CODE = A.HOSP_CODE AND C.CODE = A.DANUI  AND C.CODE_TYPE = 'ORD_DANUI'  AND C.LANGUAGE = :language        ");
		sql.append("	      , (OCS0102 D RIGHT JOIN OCS0103 B ON D.HOSP_CODE = B.HOSP_CODE AND D.SLIP_CODE  = B.SLIP_CODE AND D.LANGUAGE = :language )                                                   ");
		sql.append("	 		LEFT JOIN 	 ( SELECT X.SG_CODE                                                                                                                 ");
		sql.append("	               , X.SG_NAME                                                                                                                              ");
		sql.append("	               , X.SG_YMD                                                                                                                               ");
		sql.append("	               , X.BULYONG_YMD                                                                                                                          ");
		sql.append("	               , X.BUN_CODE                                                                                                                             ");
		sql.append("	               , X.HOSP_CODE                                                                                                                            ");
		sql.append("	            FROM BAS0310 X                                                                                                                              ");
		sql.append("	           WHERE X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                                      ");
		sql.append("	                                FROM BAS0310 Z                                                                                                          ");
		sql.append("	                               WHERE Z.SG_CODE = X.SG_CODE                                                                                              ");
		sql.append("	                                 AND Z.SG_YMD <=  SYSDATE()                                                                                             ");
		sql.append("	                                 AND Z.HOSP_CODE =  :f_hosp_code )                                                                                      ");
		sql.append("	                 AND X.HOSP_CODE= :f_hosp_code                                                                                                          ");
		sql.append("	        ) E ON E.SG_CODE  = B.SG_CODE AND E.HOSP_CODE =  :f_hosp_code                                                                                   ");                                       
		sql.append("	 WHERE A.HOSP_CODE         = :f_hosp_code                                                                                                               ");
		sql.append("	   AND B.HOSP_CODE         = A.HOSP_CODE                                                                                                                ");
		sql.append("	   AND A.SET_PART          = :f_set_part                                                                                                                ");
		sql.append("	   AND A.HANGMOG_CODE      = :f_hangmog_code                                                                                                            ");
		sql.append("	   AND A.SET_CODE          = :f_set_code                                                                                                                ");
		sql.append("	   AND B.HANGMOG_CODE      = A.SET_HANGMOG_CODE                                                                                                         "); 
		sql.append("	 ORDER BY A.SET_HANGMOG_CODE	                                                                                                                        ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_set_part", setPart);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_set_code", setCode);
		List<OCS0311Q00LayDownListInfo> listGrd= new JpaResultMapper().list(query, OCS0311Q00LayDownListInfo.class);
		return listGrd;   
	}
}

