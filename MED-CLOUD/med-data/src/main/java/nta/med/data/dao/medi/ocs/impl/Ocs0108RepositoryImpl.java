package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0108RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drug.DRGOCSCHKgrdOCS0108Info;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0108Info;
import nta.med.data.model.ihis.ocsa.OCS0108U00grdOCS0108ItemInfo;
import nta.med.data.model.ihis.ocso.OCSACTGetFindWorkerInfo;

/**
 * @author dainguyen.
 */
public class Ocs0108RepositoryImpl implements Ocs0108RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS0108U00grdOCS0108ItemInfo> getOCS0108U00grdOCS0108ItemInfo(
			String hospCode, Date hangmogStartDate, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HANGMOG_CODE ,                                                                                                                           " );
		sql.append("        A.SEQ          ,                                                                                                                           " );
		sql.append("        A.ORD_DANUI    ,                                                                                                                           " );
		sql.append("        IFNULL(A.CHANGE_QTY1, 0),                                                                                                                  " );
		sql.append("        IFNULL(A.CHANGE_QTY2, 0),                                                                                                                  " );
		sql.append("       case IFNULL(E.DANUI, '000') when A.ORD_DANUI then IFNULL(E.DANUI, '000') else  '000'  end SUNAB_DANUI,                                      " );
		sql.append("       case IFNULL(F.SUBUL_DANUI, '000') when A.ORD_DANUI then IFNULL(F.SUBUL_DANUI, '000') else '000' end SUBUL_DANUI,                            " );
		sql.append("        A.HANGMOG_START_DATE                                                                                                                       " );
		sql.append("   FROM OCS0108 A,                                                                                                                                 " );
		sql.append("        (( SELECT X.SG_CODE                                                                                                                        " );
		sql.append("               , X.DANUI                                                                                                                           " );
		sql.append("            FROM BAS0310 X                                                                                                                         " );
		sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                                                        " );
		sql.append("             AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                                 " );
		sql.append("                                FROM BAS0310 Z                                                                                                     " );
		sql.append("                               WHERE X.HOSP_CODE = Z.HOSP_CODE                                                                                     " );
		sql.append("                                 AND Z.SG_CODE = X.SG_CODE                                                                                         " );
		sql.append("                                 AND Z.SG_YMD <= SYSDATE())                                                                                        " );
		sql.append("        ) E RIGHT JOIN  OCS0103 D ON E.SG_CODE = D.SG_CODE) LEFT JOIN  INV0110 F ON F.JAERYO_CODE= D.JAERYO_CODE AND F.HOSP_CODE= D.HOSP_CODE      " );
		sql.append("  WHERE A.HANGMOG_START_DATE = :f_hangmog_start_date                                                                                               " );
		sql.append("    AND A.HANGMOG_CODE   = :f_hangmog_code                                                                                                         " );
		sql.append("    AND A.HOSP_CODE      = :f_hosp_code                                                                                                            " );
		sql.append("    AND A.HANGMOG_CODE   = D.HANGMOG_CODE                                                                                                          " );
		sql.append("    AND A.HOSP_CODE      = D.HOSP_CODE                                                                                                             " );
		sql.append("  ORDER BY A.SEQ																																	");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_start_date", hangmogStartDate);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<OCS0108U00grdOCS0108ItemInfo> listResult = new JpaResultMapper().list(query, OCS0108U00grdOCS0108ItemInfo.class);
		return listResult;
	}

	@Override
	public String getGetDefaultOrdDanui1Request(String hospCode,String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.ORD_DANUI                        ");
		sql.append("  FROM OCS0108 A                           ");
		sql.append("      ,OCS0103 B                           ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code       ");
		sql.append("    AND A.HANGMOG_CODE = :f_hangmog_code   ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE           ");
		sql.append("   AND B.HANGMOG_CODE = A.HANGMOG_CODE     ");
		sql.append("   AND B.START_DATE = A.HANGMOG_START_DATE ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);                           
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getGetDefaultOrdDanuiInfo(String hospCode, String language, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code,:f_language)       ");
		sql.append(" FROM OCS0108 A ,OCS0103 B                                                                          ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                                ");
		sql.append(" AND A.HANGMOG_CODE = :f_hangmog_code                                                               ");
		sql.append(" AND B.HOSP_CODE = A.HOSP_CODE                                                                      ");
		sql.append(" AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                ");
		sql.append(" AND B.START_DATE = A.HANGMOG_START_DATE															");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hangmog_code", hangmogCode); 
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public String getLoadColumnCodeNameOrdDanuiCase(String hangmogCode,
			String ordDanui, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.ORD_DANUI 								");
		sql.append("	FROM OCS0108 A                                 " );
		sql.append("	   , OCS0103 B                                 " );
		sql.append("	WHERE A.HANGMOG_CODE = :hangmogCode            " );
		sql.append("	 AND A.ORD_DANUI    =  :ordDanui	           " );
		sql.append("	 AND A.HOSP_CODE    =  :hospCode               " );
		sql.append("	 AND B.HOSP_CODE    = A.HOSP_CODE              " );
		sql.append("	 AND B.HANGMOG_CODE = A.HANGMOG_CODE           " );
		sql.append("	 AND B.START_DATE   = A.HANGMOG_START_DATE     " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("ordDanui", ordDanui);
		query.setParameter("hospCode", hospCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getLoadColumnCodeNameOrdDanuiNameCase(String hangmogCode,
			String ordDanui, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.ORD_DANUI 																");
		sql.append("	 FROM OCS0108 A                                                                 ");
		sql.append("	    , OCS0103 B                                                                 ");
		sql.append("	WHERE A.HANGMOG_CODE = :hangmogCode                                             ");
		sql.append("	  AND TRIM(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:hospCode, :language)) = TRIM(:ordDanui)   ");
		sql.append("	  AND A.HOSP_CODE    = :hospCode                                                ");
		sql.append("	  AND B.HOSP_CODE    = A.HOSP_CODE                                              ");
		sql.append("	  AND B.HANGMOG_CODE = A.HANGMOG_CODE                                           ");
		sql.append("	  AND B.START_DATE   = A.HANGMOG_START_DATE                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("ordDanui", ordDanui);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String callFnOcsExistsOrdDanui(String hospCode, String hangmogCode,
			String ordDanui) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT FN_OCS_EXISTS_ORD_DANUI(:hospCode, :hangmogCode, :ordDanui)");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("ordDanui", ordDanui);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<OCSACTGetFindWorkerInfo> getOCSACTGetFindWorkerInfoCaseOrdDanui(String hospCode, String language, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code,:f_language), A.SEQ    ");
		sql.append("   FROM OCS0108 A                                                                                       ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                      ");
		sql.append("   AND A.HANGMOG_CODE = :f_hangmog_code                                                                 ");
		sql.append("  ORDER BY 3, 1, 2																						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<OCSACTGetFindWorkerInfo> listResult = new JpaResultMapper().list(query, OCSACTGetFindWorkerInfo.class);
		return listResult;
	}

	@Override
	public List<OCSACTGetFindWorkerInfo> getOCSACTGetFindWorkerInfoCaseOrdDanuiName(String hospCode, String language, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI,:f_hosp_code,:f_language) , B.SEQ    ");
		sql.append("  FROM OCS0108 B     , OCS0103 A                                                                         ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                        ");
		sql.append("   AND A.HANGMOG_CODE = :f_hangmog_code                                                                  ");
		sql.append("   AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                                                     ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                                                         ");
		sql.append("   AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                   ");
		sql.append("   AND B.HANGMOG_START_DATE = A.START_DATE                                                               ");
		sql.append("   ORDER BY 3, 1, 2 																					 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<OCSACTGetFindWorkerInfo> listResult = new JpaResultMapper().list(query, OCSACTGetFindWorkerInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U00GrdOCS0108Info> getOCS0103U00GrdOCS0108Info(String hospCode, String aHangmogCode, Date aHangmogStartDate, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.HANGMOG_CODE                                                                                                                                         ");
		sql.append("       , A.ORD_DANUI                                                                                                                                            ");
		sql.append("       , A.SEQ                                                                                                                                                  ");
		sql.append("       , A.CHANGE_QTY1                 SUNAB_GIJUN                                                                                                              ");
		sql.append("       , A.CHANGE_QTY2                 SUBUL_GIJUN                                                                                                              ");
		sql.append("       , A.HOSP_CODE                                                                                                                                            ");
		sql.append("       , A.HANGMOG_START_DATE                                                                                                                                   ");
		//tuning performance
		sql.append("       ,B.CODE_NAME      CODE_NAME1                                                                                                                             ");
		sql.append("       ,B.CODE_NAME      CODE_NAME2                                                                                                                             ");
		sql.append("    FROM OCS0132 B RIGHT JOIN   OCS0108 A   ON   B.HOSP_CODE = A.HOSP_CODE                                                                                      ");
		sql.append("     AND B.CODE = A.ORD_DANUI AND B.CODE_TYPE = 'ORD_DANUI'                                                                                                     ");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                          ");
		sql.append("     AND A.HANGMOG_CODE = :f_aHangmogCode                                                                                                                       ");
		sql.append("     AND A.HANGMOG_START_DATE = :f_aHangmogStartdate                                                                                                            ");
		sql.append("     AND B.LANGUAGE = :language						                                                                                                            ");
		sql.append("   ORDER BY A.HANGMOG_CODE, A.SEQ																																");
		   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aHangmogCode", aHangmogCode);
		query.setParameter("f_aHangmogStartdate", aHangmogStartDate);
		query.setParameter("language", language);
		List<OCS0103U00GrdOCS0108Info> listResult = new JpaResultMapper().list(query, OCS0103U00GrdOCS0108Info.class);
		return listResult;
	}
	
	@Override
	public List<DRGOCSCHKgrdOCS0108Info> getDRGOCSCHKgrdOCS0108Info(String hospCode, String language, String aHangmogCode, Date aHangmogStartDate){		
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.HANGMOG_CODE                                                                                     						");
		sql.append("         , A.ORD_DANUI                                                                                                     			");
		sql.append("         , A.SEQ                                                                                                           			");
		sql.append("         , A.CHANGE_QTY1                 SUNAB_GIJUN                                                                       			");
		sql.append("         , A.CHANGE_QTY2                 SUBUL_GIJUN                                                                       			");
		sql.append("         , A.HOSP_CODE                                                                                                    			");
		sql.append("         , A.HANGMOG_START_DATE                                                                                            			");                                                                                                                                                          
		sql.append("       ,B.CODE_NAME      CHANGE_DANUI1                                                                                              ");
		sql.append("       ,B.CODE_NAME      CHANGE_DANUI2                                                                                              ");
		sql.append("      FROM  OCS0132 B right JOIN  OCS0108 A  ON B.HOSP_CODE = A.HOSP_CODE                                                           ");
		sql.append("        and B.CODE    = A.ORD_DANUI and B.CODE_TYPE = 'ORD_DANUI'                                                                   ");
		sql.append("     WHERE A.HOSP_CODE    = :f_hosp_code                                                             								");
		sql.append("       AND A.HANGMOG_CODE = :f_aHangmogCode                                                             							");
		sql.append("       AND A.HANGMOG_START_DATE = :f_aHangmogStartdate                                                     							");
		sql.append("       AND B.LANGUAGE = :f_language						                                                                            ");
		sql.append("       ORDER BY A.HANGMOG_CODE, A.SEQ ;                                                             								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_aHangmogCode", aHangmogCode);
		query.setParameter("f_aHangmogStartdate", aHangmogStartDate);
		List<DRGOCSCHKgrdOCS0108Info> listResult = new JpaResultMapper().list(query, DRGOCSCHKgrdOCS0108Info.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> getComboNUR0110U00SetFindWorker(String hospCode, String language,
			String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :f_language) ORD_DANUI_NAME ");
		sql.append("	  FROM OCS0108 A                                                                                              ");
		sql.append("	     , OCS0103 B                                                                                              ");
		sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code                                                                          ");
		sql.append("	   AND A.HANGMOG_CODE = :f_hangmog_code                                                                       ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                           ");
		sql.append("	   AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                        ");
		sql.append("	   AND B.START_DATE   = A.HANGMOG_START_DATE                                                                  ");
		sql.append("	 ORDER BY 1, 2                                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<String> getNUR0110U00GrdNUR0115ColChangeCaseOrdDanui(String hospCode, String language, String ordDanui,
			String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT FN_OCS_LOAD_CODE_NAME('ORD_DANUI', ORD_DANUI, :f_hosp_code, :f_language) ORD_DANUI_NAME ");
		sql.append("	  FROM OCS0108                                                                                          ");
		sql.append("	 WHERE HOSP_CODE    = :f_hosp_code                                                                      ");
		sql.append("	   AND ORD_DANUI    = :f_ord_danui                                                                      ");
		sql.append("	   AND HANGMOG_CODE = :f_hangmog_code                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ord_danui", ordDanui);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		return query.getResultList();
	}
}

