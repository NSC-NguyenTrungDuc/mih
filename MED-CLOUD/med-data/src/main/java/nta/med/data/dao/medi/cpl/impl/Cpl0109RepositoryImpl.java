package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl0109RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0101U00InitListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0108U00InitGrdDetailListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00GrdResultListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00MlayConstantCPL2010ListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl0109RepositoryImpl implements Cpl0109RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<CPL0108U00InitGrdDetailListItemInfo> getListCPL0108U00GrdDetail(String hospCode, String codeType,String language, Integer startNum, Integer endNum)
	{
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT 									");
		sql.append("	        CODE_TYPE     ,                 ");
		sql.append("	        CODE          ,                 ");
		sql.append("	        CODE_NAME     ,                 ");
		sql.append("	        CODE_NAME_RE  ,                 ");
		sql.append("	        SYSTEM_GUBUN  ,                 ");
		sql.append("	        CODE_VALUE                      ");
		sql.append("	FROM CPL0109                            ");
		sql.append("	WHERE   HOSP_CODE  = :hospCode       	");
		sql.append("	  AND   CODE_TYPE = :codeType        	");
		sql.append("      AND   LANGUAGE = :language            ");
		sql.append("	ORDER BY LPAD(CODE,9,'0')               ");

		if(startNum != null && endNum != null){
			sql.append("  LIMIT :startNum, :endNum 	            ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		if(startNum != null && endNum != null){
			query.setParameter("startNum", startNum);
			query.setParameter("endNum", endNum);
		}
		List<CPL0108U00InitGrdDetailListItemInfo> listResult = new JpaResultMapper().list(query, CPL0108U00InitGrdDetailListItemInfo.class);
		return listResult;
	}
	
	@Override
	public String getCheckItemGrdDetail(String hospCode, String code,
			String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'X'							");
		sql.append("	FROM CPL0109                        ");
		sql.append("	WHERE HOSP_CODE = :hospCode      ");
		sql.append("	AND CODE  = :code                 ");
		sql.append("	AND CODE_TYPE = :codeType        ");
		sql.append("	AND LANGUAGE = :language        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	@Override
	public List<String> getCheckCodeType(String hospCode, String codeType) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'X' 								");
		sql.append("	FROM CPL0109                            ");
		sql.append("	WHERE CODE_TYPE = :codeType          ");
		sql.append("	AND HOSP_CODE = :hospCode            ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		
		List<String> listResult = query.getResultList();
		return listResult;
	}
	
	
	@Override
	public List<CPL0101U00InitListItemInfo> getInitListItem(String hospCode, String language, String hangmog, String ioGubun, Integer startNum, Integer endNum) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.JUKYONG_DATE,                                                                                                                                     						");
		sql.append("	           A.HANGMOG_CODE,                                                                                                                                                      ");
		sql.append("	           A.SPECIMEN_CODE,                                                                                                                                                     ");
		sql.append("	           K.CODE_NAME           SPECIMEN_NAME,                                                                                                                                 ");
		sql.append("	           A.EMERGENCY,                                                                                                                                                         ");
		sql.append("	           A.DEFAULT_YN,                                                                                                                                                        ");
		sql.append("	           A.JUNDAL_GUBUN,                                                                                                                                                      ");
		sql.append("	           F.CODE_NAME           JUNDAL_NAME,                                                                                                                                   ");
		sql.append("	           A.DANUI,                                                                                                                                                             ");
		sql.append("	           B.CODE_NAME           DANUI_NAME,                                                                                                                                    ");
		sql.append("	           A.TUBE_CODE,                                                                                                                                                         ");
		sql.append("	           C.CODE_NAME           TUBE_NAME,                                                                                                                                     ");
		sql.append("	           A.UITAK_CODE,                                                                                                                                                        ");
		sql.append("	           D.CODE_NAME           UITAK_NAME,                                                                                                                                    ");
		sql.append("	           A.SUTAK_CODE,                                                                                                                                                        ");
		sql.append("	           G.CODE_NAME           SUTAK_NAME,                                                                                                                                    ");
		sql.append("	           A.SLIP_CODE,                                                                                                                                                         ");
		sql.append("	           H.SLIP_NAME           SLIP_NAME,                                                                                                                                     ");
		sql.append("	           A.JANGBI_CODE,                                                                                                                                                       ");
		sql.append("	           E.CODE_NAME           JANGBI_NAME,                                                                                                                                   ");
		sql.append("	           A.JANGBI_OUT_CODE,                                                                                                                                                   ");
		sql.append("	           A.JANGBI_CODE2,                                                                                                                                                      ");
		sql.append("	           I.CODE_NAME           JANGBI_NAME2,                                                                                                                                  ");
		sql.append("	           A.JANGBI_OUT_CODE2,                                                                                                                                                  ");
		sql.append("	           A.JANGBI_CODE3,                                                                                                                                                      ");
		sql.append("	           J.CODE_NAME           JANGBI_NAME3,                                                                                                                                  ");
		sql.append("	           A.JANGBI_OUT_CODE3,                                                                                                                                                  ");
		sql.append("	           A.GROUP_GUBUN,                                                                                                                                                       ");
		sql.append("	           A.GUMSA_NAME_RE,                                                                                                                                                     ");
		sql.append("	           A.BARCODE,                                                                                                                                                           ");
		sql.append("	           A.GUMSA_NAME,                                                                                                                                                        ");
		sql.append("	           A.DEFAULT_RESULT,                                                                                                                                                    ");
		sql.append("	           A.MEDICAL_JUNDAL,                                                                                                                                                    ");
		sql.append("	           A.COMMENT_JU_CODE,                                                                                                                                                   ");
		sql.append("	           A.SERIAL,                                                                                                                                                            ");
		sql.append("	           IFNULL(A.CHUBANG_YN,'N'),                                                                                                                                            ");
		sql.append("	           IFNULL(A.RESULT_YN,'N'),                                                                                                                                             ");
		sql.append("	           A.RESULT_FORM,                                                                                                                                                       ");
		sql.append("	           A.TONG_GUBUN,                                                                                                                                                        ");
		sql.append("	           A.SPECIMEN_AMT,                                                                                                                                                      ");
		sql.append("	           A.OLD_SLIP_CODE,                                                                                                                                                     ");
		sql.append("	           A.DETAIL_INFO,                                                                                                                                                       ");
		sql.append("	           A.DISPLAY_YN,                                                                                                                                                        ");
		sql.append("	           A.JUNDAL_GUBUN_NAME,                                                                                                                                                 ");
		sql.append("	           A.SPCIAL_NAME,                                                                                                                                                       ");
		sql.append("	           A.TONG_SERIAL,                                                                                                                                                       ");
		sql.append("	           A.POINT,                                                                                                                                                             ");
		sql.append("	           A.POINT2,                                                                                                                                                            ");
		sql.append("	           A.POINT3,                                                                                                                                                            ");
		sql.append("	           A.OUT_TUBE,                                                                                                                                                          ");
		sql.append("	           A.OUT_TUBE2,                                                                                                                                                         ");
		sql.append("	           A.HANGMOG_MARK_NAME,                                                                                                                                                 ");
		sql.append("	           A.MIDDLE_RESULT,                                                                                                                                                     ");
		sql.append("	           A.USER_GUBUN                                                                                                                                                         ");
		sql.append("	                                                                                                                                                                                ");
		sql.append("	FROM ((((((((( CPL0109 B RIGHT OUTER JOIN CPL0101 A ON B.HOSP_CODE = A.HOSP_CODE AND B.CODE_TYPE = '03'  AND B.CODE  = A.DANUI AND  B.LANGUAGE = :language )                     ");
		sql.append("	           LEFT OUTER JOIN CPL0109 C ON C.HOSP_CODE = A.HOSP_CODE AND C.CODE_TYPE  = '02' AND C.CODE  = A.TUBE_CODE AND C.LANGUAGE = :language )                                 ");
		sql.append("	           LEFT OUTER JOIN CPL0109 D ON D.HOSP_CODE = A.HOSP_CODE AND D.CODE_TYPE = '06' AND D.CODE = A.UITAK_CODE AND D.LANGUAGE = :language )                                  ");
		sql.append("	           LEFT OUTER JOIN CPL0109 G ON G.HOSP_CODE  = A.HOSP_CODE AND G.CODE_TYPE    = '06' AND G.CODE         = A.SUTAK_CODE  AND G.LANGUAGE = :language )                     ");
		sql.append("	           LEFT OUTER JOIN CPL0109 E ON E.HOSP_CODE  = A.HOSP_CODE AND E.CODE_TYPE    = '07' AND E.CODE         = A.JANGBI_CODE AND E.LANGUAGE = :language )                     ");
		sql.append("	           LEFT OUTER JOIN CPL0109 F ON F.HOSP_CODE  = A.HOSP_CODE AND F.CODE_TYPE    = '01' AND F.CODE         = A.JUNDAL_GUBUN AND F.LANGUAGE = :language )                    ");
		sql.append("	           LEFT OUTER JOIN CPL0001 H ON H.HOSP_CODE  = A.HOSP_CODE  AND H.SLIP_CODE    = A.SLIP_CODE)                                                                           ");
		sql.append("	           LEFT OUTER JOIN CPL0109 I ON I.HOSP_CODE  = A.HOSP_CODE AND I.CODE_TYPE    = '07' AND I.CODE         = A.JANGBI_CODE2  AND I.LANGUAGE = :language)                   ");
		sql.append("	           LEFT OUTER JOIN CPL0109 J ON J.HOSP_CODE  = A.HOSP_CODE AND J.CODE_TYPE    = '07' AND J.CODE         = A.JANGBI_CODE3 AND J.LANGUAGE = :language)                    ");
		sql.append("	           LEFT OUTER JOIN CPL0109 K ON K.HOSP_CODE  = A.HOSP_CODE AND K.CODE_TYPE    = '04' AND K.CODE         = A.SPECIMEN_CODE AND K.LANGUAGE = :language                    ");
		sql.append("	                                                                                                                                                                                ");
		sql.append("	     WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                                        ");
		sql.append("	       AND A.SYSTEM_GUBUN    IN ('CPL', 'APL')                                                                                                                                  ");
		sql.append("	       AND (A.HANGMOG_CODE    LIKE IF(:f_txtHangmog = NULL, '%',CONCAT('%',:f_txtHangmog ,'%'))                                                                                 ");
		sql.append("	        OR A.GUMSA_NAME      LIKE IF(:f_txtHangmog = NULL, '%',CONCAT('%',:f_txtHangmog ,'%'))                                                                                  ");
		sql.append("	        OR A.GUMSA_NAME_RE   LIKE IF(:f_txtHangmog = NULL, '%',CONCAT('%',:f_txtHangmog ,'%')))                                                                                 ");
		sql.append("	         AND A.UITAK_CODE      LIKE :f_io_gubun                                                                                                                                 ");
		sql.append("	     ORDER BY CONCAT(SUBSTRING('000000000',1,10 - length(hangmog_code)) , hangmog_code ,                                                                                        ");
		sql.append("	       SUBSTRING('00',1,2 - length(specimen_code)) , specimen_code , emergency)                                                                                                 ");
		if(startNum != null && endNum != null){
			sql.append("  LIMIT :startNum, :endNum 	                                                                                                                                                        ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_txtHangmog", hangmog);
		query.setParameter("f_io_gubun", ioGubun);
		if(startNum != null && endNum != null){
			query.setParameter("startNum", startNum);
			query.setParameter("endNum", endNum);	
		}
		
		List<CPL0101U00InitListItemInfo> listResult = new JpaResultMapper().list(query, CPL0101U00InitListItemInfo.class);
		return listResult;
	}
	@Override
	public List<ComboListItemInfo> getListCboBarCodeItem(String hospCode,
			String codeType, String langague, String orderByNull) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CODE, CODE_NAME			");
		sql.append("	FROM CPL0109                    ");
		sql.append("	WHERE HOSP_CODE = :hospCode     ");
		sql.append("	AND CODE_TYPE = :codeType       ");
		sql.append("	AND LANGUAGE = :langague        ");
		sql.append("	ORDER BY CODE " + orderByNull);
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("langague", langague);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	@Override
	public List<ComboListItemInfo> getListCboResulFormItem(String hospCode,
			String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT ' ', FN_ADM_MSG(221,:language) UNION ALL   ");
		sql.append("	SELECT CODE , CODE_NAME   FROM CPL0109       ");
		sql.append("	WHERE HOSP_CODE = :hospCode                  ");
		sql.append("	AND CODE_TYPE = :codeType                    ");
		sql.append("	AND LANGUAGE  = :language                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	@Override
	public List<ComboListItemInfo> getListCboSpcialNameItem(
			String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT CODE, CODE_NAME    						");	
		sql.append("	FROM CPL0109  WHERE HOSP_CODE = :hospCode       ");
		sql.append("	AND CODE_TYPE = :codeType                       ");
		sql.append("	AND LANGUAGE = :language                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	@Override
	public List<ComboListItemInfo> getListInoutGubunItem(String hospCode,
			String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
	    sql.append("	SELECT '%' CODE, FN_ADM_MSG(221,:language) CODE_NAME 	");
		sql.append("	UNION                                               ");
		sql.append("	SELECT CODE, CODE_NAME                              ");
		sql.append("	FROM CPL0109                                        ");
		sql.append("	WHERE HOSP_CODE = :hospCode                         ");
		sql.append("	AND CODE_TYPE = :codeType  					        ");
		sql.append("	AND LANGUAGE = :language                            ");
		sql.append("	ORDER BY CODE                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	@Override
	public String getCPL0101U00FbxJundalGubunName(String hospCode, String codeType,
			String systemGubun, String code, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT CODE_NAME FROM CPL0109 WHERE HOSP_CODE = :hospCode  AND CODE_TYPE = :codeType AND SYSTEM_GUBUN = :systemGubun AND CODE = :code  AND LANGUAGE = :language");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("systemGubun", systemGubun);
		query.setParameter("code", code);
		query.setParameter("language", language);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	@Override
	public String getCPL0101U00getACtlName(String hospCode, String codeType, String code, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT CODE_NAME FROM CPL0109 WHERE HOSP_CODE = :hospCode AND CODE_TYPE = :codeType AND CODE = :code AND LANGUAGE = :language ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		query.setParameter("language", language);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	@Override
	public List<ComboListItemInfo> getCPL0101U00FbxJundalGubunComboListItem(
			String hospCode, String codeType, String systemGubun, String find1, String find2,
			String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE																         ");
		sql.append("	    , CODE_NAME                                                                  ");
		sql.append("	 FROM CPL0109                                                                    ");
		sql.append("	WHERE HOSP_CODE = :hospCode                                                      ");
		sql.append("	  AND CODE_TYPE  = :codeType                                                     ");
		sql.append("	  AND SYSTEM_GUBUN = :systemGubun                                                ");
		sql.append("	  AND LANGUAGE = :language                                                       ");
		sql.append("	  AND ((CODE      LIKE IF(:find1 = '' , '%',CONCAT('%',:find1,'%'))            ");
		sql.append("	   OR  (CODE_NAME LIKE IF(:find2 = '', '%',CONCAT('%',:find2,'%')))))         ");
		sql.append("	ORDER BY CODE                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("find1", find1);
		query.setParameter("find2", find2);
		query.setParameter("systemGubun", systemGubun);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<ComboListItemInfo> getCPL0101U00getACtrComboListItem(
			String hospCode, String codeType, String find1, String find2,
			String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE																         ");
		sql.append("	    , CODE_NAME                                                                  ");
		sql.append("	 FROM CPL0109                                                                    ");
		sql.append("	WHERE HOSP_CODE = :hospCode                                                      ");
		sql.append("	  AND CODE_TYPE  = :codeType                                                     ");
		sql.append("	  AND LANGUAGE = :language                                                       ");
		sql.append("	  AND ((CODE      LIKE IF(:find1 IS NULL , '%',CONCAT('%',:find1,'%')))           ");
		sql.append("	   OR  (CODE_NAME LIKE IF(:find2 IS NULL , '%',CONCAT('%',:find2,'%'))))          ");
		sql.append("	ORDER BY CODE                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("find1", find1);
		query.setParameter("find2", find2);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override

	public List<ComboListItemInfo> getCpl0109ComboListItemInfo(String hospCode, String language, String codeType, boolean isAll){
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append("SELECT '%' CODE                                  ");
			sql.append("     , FN_ADM_MSG(221,:f_language) CODE_NAME     ");
			sql.append("UNION                                            ");
		}
		sql.append("SELECT A.CODE                                    ");
		sql.append("     , A.CODE_NAME                               ");
		sql.append("  FROM CPL0109 A                                 ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                ");
		sql.append("   AND A.CODE_TYPE = :f_code_type                ");
		sql.append("   AND A.LANGUAGE = :f_language                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getFwkJundalGubunListItem(
			String hospCode, String codeType, String find, String language) {                                           
		StringBuilder sql = new StringBuilder();                                                       
		                                                                                         
		sql.append("	SELECT CODE																	   " );
		sql.append("	     , CODE_NAME                                                               " );
		sql.append("	 FROM CPL0109                                                                  " );
		sql.append("	WHERE HOSP_CODE  = :hospCode                                                   " );
		sql.append("	  AND CODE_TYPE  = :codeType                                                   " );
		sql.append("	  AND ((CODE      LIKE IF(:find IS NULL,'%',CONCAT('%',UPPER(:find),'%')))     " );
		sql.append("	   OR  (CODE_NAME LIKE  IF(:find IS NULL,'%',CONCAT('%',:find,'%'))))   " );
		sql.append("   AND LANGUAGE = :language                                                        ");
		sql.append("	ORDER BY CODE                                                                  " );
		                                                                                               
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("find",find);
		query.setParameter("language",language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<CPL3020U00GrdResultListItemInfo> getGrdResultListItem(
			String hospCode, String language, String labNo, String specimenSer,
			String jundalGubun, String codeType) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT C.PKCPL3020                          PKCPL3020,                                                                                                            ");
		sql.append("	      CONCAT(IF(C.HANGMOG_CODE = C.SOURCE_GUMSA, '', '   ') , D.GUMSA_NAME)                         GUMSA_NAME,                                                   ");
		sql.append("	      C.STANDARD_YN                        STANDARD_YN,                                                                                                           ");
		sql.append("	      C.CPL_RESULT                         CPL_RESULT,                                                                                                            ");
		sql.append("	      C.CONFIRM_YN                         CONFIRM_YN,                                                                                                            ");
		sql.append("	      C.BEFORE_RESULT                      BEFORE_RESULT,                                                                                                         ");
		sql.append("	      C.PANIC_YN                           PANIC_YN,                                                                                                              ");
		sql.append("	      C.DELTA_YN                           DELTA_YN,                                                                                                              ");
		sql.append("	      E.CODE_NAME                          DANUI_NAME,                                                                                                            ");
		sql.append("	      IF(C.TO_STANDARD IS NULL,C.FROM_STANDARD,CONCAT(C.FROM_STANDARD , ' ~ ' , C.TO_STANDARD))    STANDARD,                                                      ");
		sql.append("	      C.COMMENTS                           COMMENTS,                                                                                                              ");
		sql.append("	      IF(A.IN_OUT_GUBUN = 'I',A.FKOCS2003,A.FKOCS1003)    FKOCS,                                                                                                  ");
		sql.append("	      C.FKCPL2010                          FKCPL2010,                                                                                                             ");
		sql.append("	      C.LAB_NO                             LAB_NO,                                                                                                                ");
		sql.append("	      C.HANGMOG_CODE                       HANGMOG_CODE,                                                                                                          ");
		sql.append("	      C.SPECIMEN_CODE                      SPECIMEN_CODE,                                                                                                         ");
		sql.append("	      C.EMERGENCY                          EMERGENCY,                                                                                                             ");
		sql.append("	      C.GUMSAJA                            GUMSAJA,                                                                                                               ");
		sql.append("	      A.BUNHO                              BUNHO,                                                                                                                 ");
		sql.append("	      C.RESULT_DATE                        RESULT_DATE,                                                                                                           ");
		sql.append("	      :specimenSer                      SPECIMEN_SER,                                                                                                             ");
		sql.append("	      C.RESULT_FORM                        RESULT_FORM,                                                                                                           ");
		sql.append("	      C.SOURCE_GUMSA                       SOURCE_GUMSA,                                                                                                          ");
		sql.append("	      D.GROUP_GUBUN                        GROUP_GUBUN,                                                                                                           ");
		sql.append("	      C.SOURCE_GUMSA                       GROUP_HANGMOG,                                                                                                         ");
		sql.append("	      IFNULL(C.DISPLAY_YN,'Y')                DISPLAY_YN,                                                                                                         ");
		sql.append("	      CONCAT(LPAD(C.FKCPL2010,10,'0'),LPAD(C.PKCPL3020,10,'0'))  KET                                                                                              ");
		sql.append("	 FROM CPL0109 E RIGHT JOIN CPL0101 D ON  E.HOSP_CODE = D.HOSP_CODE  AND E.CODE = D.DANUI    AND E.LANGUAGE = :language  AND E.CODE_TYPE = :codeType,              ");
		sql.append("	      CPL3020 C,                                                                                                                                                  ");
		sql.append("	      CPL2010 A                                                                                                                                                   ");
		sql.append("	WHERE A.HOSP_CODE        = :hospCode                                                                                                                              ");
		sql.append("	  AND C.HOSP_CODE        = A.HOSP_CODE                                                                                                                            ");
		sql.append("	  AND D.HOSP_CODE        = A.HOSP_CODE                                                                                                                            ");
		sql.append("	  AND C.LAB_NO           = :labNo                                                                                                                                 ");
		sql.append("	  AND A.SPECIMEN_SER     = :specimenSer                                                                                                                           ");
		sql.append("	  AND A.JUNDAL_GUBUN     = :jundalGubun                                                                                                                           ");
		sql.append("	  AND A.PKCPL2010        = C.FKCPL2010                                                                                                                            ");
		sql.append("	  AND C.HANGMOG_CODE     = D.HANGMOG_CODE                                                                                                                         ");
		sql.append("	  AND C.SPECIMEN_CODE    = D.SPECIMEN_CODE                                                                                                                        ");
		sql.append("	  AND C.EMERGENCY        = D.EMERGENCY	  																														  ");
		sql.append("	ORDER BY C.PKCPL3020                                                                               																  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("labNo",labNo);
		query.setParameter("specimenSer",specimenSer);
		query.setParameter("jundalGubun",jundalGubun);
		query.setParameter("codeType",codeType);
		
		List<CPL3020U00GrdResultListItemInfo> listResult = new JpaResultMapper().list(query, CPL3020U00GrdResultListItemInfo.class);
		return listResult;
	}
	@Override
	public String getCodeNameVsvJundalGubun(String hospCode, String codeType,
			String code,String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE_NAME						");
		sql.append("	FROM CPL0109                            ");
		sql.append("	WHERE HOSP_CODE = :hospCode             ");
		sql.append("	AND CODE_TYPE = :codeType               ");
		sql.append("	AND CODE      = :code                   ");
		sql.append("	AND LANGUAGE = :language               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		query.setParameter("language", language);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	@Override
	public List<ComboListItemInfo> getCPL3020U00FwkResultInputSQL(
			String hospCode, String find, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE																		");
		sql.append("	    , CODE_NAME                                                                 ");
		sql.append("	FROM CPL0109                                                                    ");
		sql.append("	WHERE HOSP_CODE = :hospCode                                                     ");
		sql.append("	  AND ((CODE        LIKE IF(:find IS NULL, '%', CONCAT('%',:find,'%')))         ");
		sql.append("	   OR  (CODE_NAME   LIKE IF(:find IS NULL, '%', CONCAT('%',:find,'%'))))        ");
		sql.append("	  AND CODE_TYPE     = :codeType                                                 ");
		sql.append("	  AND LANGUAGE     = :language                                                 ");
		sql.append("	ORDER BY CODE							                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("find",find);
		query.setParameter("codeType", codeType);
		query.setParameter("language",language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<CplsCPL2010U00MlayConstantCPL2010ListItemInfo> getCPL2010U00MlayConstantInfo(String hospCode, String language, String codeType) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME, CODE_VALUE          ");
		sql.append(" FROM CPL0109 WHERE HOSP_CODE = :f_hosp_code ");
		sql.append("  AND CODE_TYPE = :f_code_type               ");
		sql.append("  AND LANGUAGE     = :language           	 ");
		sql.append("  ORDER BY CODE 					     	 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type",codeType);
		query.setParameter("language",language);
		
		List<CplsCPL2010U00MlayConstantCPL2010ListItemInfo> listResult = new JpaResultMapper().list(query, CplsCPL2010U00MlayConstantCPL2010ListItemInfo.class);
		return listResult;

	}

	@Override
	public List<ComboListItemInfo> getCPL0001U00GrdComboInfo(String hospCode,
			String codeType, String systemGubun, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE, CODE_NAME_RE  		");
		sql.append("	FROM CPL0109                    ");             
		sql.append("	WHERE HOSP_CODE = :hospCode     "); 
		sql.append("	AND CODE_TYPE = :codeType       ");     
		sql.append("	AND SYSTEM_GUBUN  = :sys        "); 
		sql.append("  AND LANGUAGE     = :language     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType",codeType);
		query.setParameter("sys",systemGubun);
		query.setParameter("language",language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> getCPL0001U00CboJundalInfo(String hospCode,
			String codeType, String systemGubun, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT '%'                          ");
		sql.append("	     , FN_ADM_MSG(221, :language)   ");
		sql.append("	UNION ALL                           ");
		sql.append("	SELECT SUBSTR(CODE,2) CODE          ");
		sql.append("	     , CODE_NAME_RE                 ");
		sql.append("	  FROM CPL0109                      ");
		sql.append("	 WHERE HOSP_CODE = :hospCode        ");
		sql.append("	   AND CODE_TYPE = :codeType        ");
		sql.append("	   AND SYSTEM_GUBUN = :sys          ");
		sql.append("  AND LANGUAGE     = :language     		");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType",codeType);
		query.setParameter("sys",systemGubun);
		query.setParameter("language",language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> getCPLMASTERUPLOADERCboMstType(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.CODE  , B.CODE_NAME       ");
		sql.append("   FROM CPL0109 B                   ");
		sql.append("      , CPL0108 A                   ");
		sql.append("  WHERE  A.CODE_TYPE = '06'         ");
		sql.append("    AND B.HOSP_CODE = :f_hosp_code  ");
		sql.append("    AND B.LANGUAGE  = :f_language   ");
		sql.append("    AND B.CODE_TYPE = A.CODE_TYPE   ");
		sql.append("  ORDER BY B.CODE 					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language",language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public String getCPL2010U02SaveLayoutRequest(String hospCode, String codeType, String code) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT 'Y'										");
		sql.append("  FROM DUAL    									");
		sql.append(" WHERE EXISTS (SELECT NULL 						");
		sql.append("                 FROM CPL0109  					");
		sql.append("                WHERE HOSP_CODE = :f_hosp_code 	");
		sql.append("                  AND CODE_TYPE = :f_code_type	");
		sql.append("                  AND CODE      = :f_code)		"); 	
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		query.setParameter("f_code_type", codeType);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	
}


