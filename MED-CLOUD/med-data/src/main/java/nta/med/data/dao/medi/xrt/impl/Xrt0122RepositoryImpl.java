package nta.med.data.dao.medi.xrt.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.xrt.Xrt0122RepositoryCustom;
import nta.med.data.model.ihis.system.LoadSearchOrderInfo;
import nta.med.data.model.ihis.xrts.XRT0122Q00GrdDCodeListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0122U00GrdDcodeInfo;
import nta.med.data.model.ihis.xrts.XRT0123U00GrdDCodeItemInfo;

/**
 * @author dainguyen.
 */
public class Xrt0122RepositoryImpl implements Xrt0122RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getXRT0001U00FbxDataValidatingSelectXRT0122(String hopsCode,String language, String code, String kaikeiYn) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT buwi_name FROM XRT0122 WHERE HOSP_CODE = :hospCode  							     	");
		sql.append("     Language =:f_language AND buwi_code = :f_code AND IFNULL(kaikei_yn, 'N') = :f_kaikei_yn 	");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hopsCode", hopsCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code", code);
		query.setParameter("f_kaikei_yn", kaikeiYn);
		List<String> getFbx00122= query.getResultList();
		if(!getFbx00122.isEmpty()){
			return getFbx00122.get(0);
		}
		return null;
	}
	
	@Override
	public List<XRT0123U00GrdDCodeItemInfo> getXRT0123U00GrdDCodeItemInfo(String hopsCode,String language,String xrayGubun, String buwiCode) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT IFNULL(A.XRAY_GUBUN,B.BUWI_BUNRYU) XRAY_GUBUN                                                    					");
		sql.append("     , IFNULL(A.BUWI_CODE,B.BUWI_CODE) BUWI_CODE                                                        					");
		sql.append("     , B.BUWI_NAME BUWI_NAME                                                                            					");
		sql.append("     , A.VALTAGE                                                                                        					");
		sql.append("     , A.CUR_ELECTRIC                                                                                   					");
		sql.append("     , A.TIME                                                                                           					");
		sql.append("     , A.DISTANCE                                                                                       					");
		sql.append("     , A.GRID                                                                                           					");
		sql.append("     , A.NOTE                                                                                           					");
		sql.append("     , FN_XRT_LOAD_CODE_NAME('X1',IFNULL(A.XRAY_GUBUN,B.BUWI_BUNRYU), :hopsCode) XRAY_GUBUN_NAME        					");
		sql.append("     , FROM_AGE                                                                                         					");
		sql.append("     , TO_AGE                                                                                           					");
		sql.append("     , MAS_VAL                                                                                          					");
		sql.append("     , CONCAT(IFNULL(A.XRAY_GUBUN,B.BUWI_BUNRYU), IFNULL(A.BUWI_CODE,B.BUWI_CODE)) CONT_KEY  								");
		sql.append("  FROM XRT0122 B                                                                                        					");
		sql.append(" LEFT JOIN XRT0123 A ON B.BUWI_CODE = A.BUWI_CODE AND B.HOSP_CODE = A.HOSP_CODE  AND B.LANGUAGE  = :language	            ");
		sql.append(" WHERE A.HOSP_CODE  = :hopsCode	                            	                                        					");
		sql.append("   AND B.BUWI_BUNRYU   LIKE :xray_gubun                                                                  					");
		sql.append("   AND B.BUWI_CODE     LIKE :buwi_code                                                                   					");
		sql.append(" ORDER BY CONT_KEY                                                                                      					");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hopsCode", hopsCode);
		query.setParameter("language", language);
		query.setParameter("xray_gubun", xrayGubun+"%");
		query.setParameter("buwi_code", buwiCode+"%");
		List<XRT0123U00GrdDCodeItemInfo> listResult = new JpaResultMapper().list(query, XRT0123U00GrdDCodeItemInfo.class);
		return listResult;
	}

	@Override
	public List<XRT0122U00GrdDcodeInfo> getXRT0122U00grdDCodeInitInfo(
			String hospCode, String buwiBunryu, String buwiCode,
			String buwiName, String flag,String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT BUWI_BUNRYU																									");
		sql.append("	     , BUWI_CODE                                                                                                    ");
		sql.append("	     , BUWI_NAME                                                                                                    ");
		sql.append("	     , IFNULL(SORT_SEQ,0)                                                                                           ");
		sql.append("	     , RPAD(BUWI_CODE,10,'0') KE                                                                                    ");
		sql.append("	  FROM XRT0122 A                                                                                                    ");
		sql.append("	 WHERE 	HOSP_CODE = :hospCode 					                                                                    ");
		sql.append("	   AND    BUWI_BUNRYU = :buwiBunryu                                                                                 ");
		sql.append("	   AND BUWI_CODE   LIKE IF(:flag = '1','%',IF(:buwiCode = '','%',CONCAT('%',:buwiCode,'%')))           		    	");
		sql.append("	   AND BUWI_NAME   LIKE IF(:flag = '1','%',IF(:buwiName = '','%',CONCAT('%',:buwiName,'%')))                     	");
		sql.append("	   AND LANGUAGE = :language                                                                                         ");
		sql.append("	 ORDER BY KE                                                                                                        ");

		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("buwiBunryu", buwiBunryu);
		query.setParameter("flag", flag);
		query.setParameter("buwiCode", buwiCode);
		query.setParameter("buwiName", buwiName);
		query.setParameter("language", language);
		
		List<XRT0122U00GrdDcodeInfo> listResult = new JpaResultMapper().list(query, XRT0122U00GrdDcodeInfo.class);
		return listResult;
	}

	@Override
	public String getXRT0122U00layDupD(String hospCode, String language, String buwiBunryu, String buwiCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'									");
		sql.append("	FROM XRT0122                                ");
		sql.append("	WHERE HOSP_CODE = :hospCode 		        ");
		sql.append("	AND        LANGUAGE = :language             ");
		sql.append("	AND BUWI_BUNRYU = :buwiBunryu               ");
		sql.append("	AND BUWI_CODE   = :buwiCode                 ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("buwiBunryu", buwiBunryu);
		query.setParameter("buwiCode", buwiCode);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
		
	}

	@Override
	public List<String> getXrt0121Loop(String hospCode, String buwiBunryu, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'X' 								");	
		sql.append("	FROM XRT0122                            ");
		sql.append("	WHERE HOSP_CODE = :hospCode             ");
		sql.append("	 AND    BUWI_BUNRYU = :buwiBunryu       ");
		sql.append("	 AND LANGUAGE = :language          		");

		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("buwiBunryu", buwiBunryu);
		query.setParameter("language", language);

		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public List<LoadSearchOrderInfo> getOcsLibOrderBizLoadSearchOrderListItemInfo(
			String searchWord, String hospCode, String gijunDate,
			String wonnaeDrgYn, String inputTab, String language, Integer startNum, Integer endNum, String protocolId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SLIP_CODE    																												                                ");		
		sql.append("	    , B.SLIP_NAME    	                                                                                                                                            ");
		sql.append("	    , A.HANGMOG_CODE                                                                                                                                                ");
		sql.append("	    , A.HANGMOG_NAME                                                                                                                                                ");
		sql.append("	    , IFNULL(A.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN                                                                                                                    ");
		sql.append("		, A.YAK_KIJUN_CODE																												                                ");
		sql.append("		, A.TRIAL_FLG																													                                ");
		sql.append("	 FROM (XRT0122 E RIGHT JOIN XRT0001 D  ON E.HOSP_CODE = D.HOSP_CODE AND E.BUWI_CODE = D.XRAY_BUWI AND E.LANGUAGE = :language)                                       ");
		sql.append("	       RIGHT JOIN OCS0103 A  ON D.HOSP_CODE = A.HOSP_CODE    AND D.XRAY_CODE = A.HANGMOG_CODE                                                                       ");
		sql.append("	    , OCS0142 C                                                                                                                                                     ");
		sql.append("	    , OCS0102 B                                                                                                                                                     ");
		sql.append("	WHERE A.HANGMOG_NAME_INX LIKE :searchWord 					                                                                                                        ");	
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    													");
		}else{
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                     													    ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                                                                ");
		sql.append("	  AND A.HOSP_CODE = :hospCode                                                                                                                                       ");
		sql.append("	  AND IFNULL(STR_TO_DATE( :gijunDate, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE                                                                   ");
		sql.append("	  AND (( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                                                         ");
		sql.append("	          AND                                                                                                                                                       ");
		sql.append("	          IFNULL(A.WONNAE_DRG_YN,'N') LIKE :wonnaeDrgYn )                                                                                                           ");
		sql.append("	          OR                                                                                                                                                        ");
		sql.append("	       ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ))  AND       IFNULL(A.WONNAE_DRG_YN,'N') LIKE :wonnaeDrgYn )                                                         ");
		sql.append("	  AND A.HOSP_CODE = B.HOSP_CODE                                                                                                                                     ");
		sql.append("	  AND A.SLIP_CODE = B.SLIP_CODE                                                                                                                                     ");
		sql.append("	  AND C.HOSP_CODE = A.HOSP_CODE                                                                                                                                     ");
		sql.append("	  AND C.ORDER_GUBUN = A.ORDER_GUBUN                                                                                                                                 ");
		sql.append("	  AND C.INPUT_TAB LIKE :inputTab                                                                                                                                    ");
		sql.append("	  AND B.LANGUAGE = :language                                                                                                                                    ");
//		sql.append("	  ORDER BY A.SLIP_CODE, IFNULL(E.SORT_SEQ, 0), A.HANGMOG_NAME                                                                                                       ");
		
		if(endNum != 0){
			sql.append("	  LIMIT :startNum, :endNum                                                                      							                                    ");
		}
		
		 
		Query query= entityManager.createNativeQuery(sql.toString());
	    query.setParameter("language", language);
	    query.setParameter("searchWord", searchWord);
	    query.setParameter("hospCode", hospCode);
	    query.setParameter("gijunDate", gijunDate);
	    query.setParameter("wonnaeDrgYn", wonnaeDrgYn);
	    query.setParameter("inputTab", inputTab);
	    if(!StringUtils.isEmpty(protocolId)){
	    	query.setParameter("f_protocol_id", protocolId);	
	    }
		if(endNum != 0){
			query.setParameter("startNum", startNum);
	    	query.setParameter("endNum", endNum);
		}
        	    
	    List<LoadSearchOrderInfo> list = new JpaResultMapper().list(query, LoadSearchOrderInfo.class);
	    return list;
	}
	
	@Override
	public List<XRT0122Q00GrdDCodeListItemInfo> getXRT0122Q00GrdDCodeListItemInfo(String hospCode, String language,
			String buwiBunryu, String flag, String buwiCode, String buwiName){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT BUWI_BUNRYU																	");
		sql.append("	, BUWI_CODE 	                                                                    ");
		sql.append("	, BUWI_NAME 	                                                                    ");
		sql.append("	, IFNULL(SORT_SEQ,0)	                                                            ");
		sql.append("	, RPAD(BUWI_CODE,10,'0') KEY1	                                                    ");
		sql.append("	FROM XRT0122	                                                                    ");
		sql.append("	WHERE 		HOSP_CODE = :hospCode AND LANGUAGE = :f_language                       	");
		sql.append("	AND BUWI_BUNRYU = :f_buwi_bunryu	                                                ");
//		sql.append("	AND BUWI_CODE   LIKE CASE :f_flag WHEN '1' THEN '%' ELSE CONCAT('%',:f_buwi_code  ,'%') END	");
//		sql.append("	AND BUWI_NAME   LIKE CASE :f_flag WHEN '1' THEN '%' ELSE CONCAT('%',:f_buwi_name  ,'%') END	");
		sql.append("	AND BUWI_CODE   LIKE CASE :f_flag WHEN '1' THEN '%' ELSE :f_buwi_code END	");
		sql.append("	AND BUWI_NAME   LIKE CASE :f_flag WHEN '1' THEN '%' ELSE :f_buwi_name END	");
		sql.append("	ORDER BY SORT_SEQ	");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
	    query.setParameter("f_language", language);
	    query.setParameter("f_buwi_bunryu", buwiBunryu);
	    query.setParameter("f_flag", flag);
	    query.setParameter("f_buwi_code","%"+ buwiCode+"%");
	    query.setParameter("f_buwi_name","%"+ buwiName+"%");
	    
	    List<XRT0122Q00GrdDCodeListItemInfo> list = new JpaResultMapper().list(query, XRT0122Q00GrdDCodeListItemInfo.class);
	    return list;
	}

	@Override
	public List<LoadSearchOrderInfo> getLoadSearchCommonOrder(String searchWord, String hospCode, String gijunDate,
			String wonnaeDrgYn, String inputTab, String language, Integer startNum, Integer endNum, String protocolId,
			String jundalTableOut) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SLIP_CODE    																												                                ");		
		sql.append("	    , B.SLIP_NAME    	                                                                                                                                            ");
		sql.append("	    , A.HANGMOG_CODE                                                                                                                                                ");
		sql.append("	    , A.HANGMOG_NAME                                                                                                                                                ");
		sql.append("	    , IFNULL(A.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN                                                                                                                    ");
		sql.append("		, A.YAK_KIJUN_CODE																												                                ");
		sql.append("		, A.TRIAL_FLG																													                                ");
		sql.append("	 FROM (XRT0122 E RIGHT JOIN XRT0001 D  ON E.HOSP_CODE = D.HOSP_CODE AND E.BUWI_CODE = D.XRAY_BUWI AND E.LANGUAGE = :language AND D.HOSP_CODE = :hospCode )          ");
		sql.append("      RIGHT JOIN ( SELECT O.SLIP_CODE, O.HANGMOG_CODE, O.HANGMOG_NAME, O.WONNAE_DRG_YN, O.YAK_KIJUN_CODE,                                                               ");
		sql.append("                     O.HANGMOG_NAME_INX, O.TRIAL_FLG, O.START_DATE, O.END_DATE, O.ORDER_GUBUN                                                                           ");
		sql.append("                     FROM OCS0103 O WHERE O.COMMON_YN = 'Y'                                                                                                            ");
		sql.append("                     AND O.JUNDAL_TABLE_OUT = :jundal_table_out                                                                                                         ");         
		sql.append("                     AND O.HOSP_CODE = :hospCode ) A                                                                                                                    ");
		sql.append("         ON   D.XRAY_CODE = A.HANGMOG_CODE  AND D.HOSP_CODE = :hospCode                                                                                                 ");
		sql.append("	    , OCS0142 C                                                                                                                                                     ");
		sql.append("	    , OCS0102 B                                                                                                                                                     ");
		sql.append("	WHERE A.HANGMOG_NAME_INX LIKE :searchWord 					                                                                                                        ");	
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    													");
		}else{
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                     													    ");
		}
		sql.append("	  AND B.HOSP_CODE = :hospCode                                                                                                                                       ");
		sql.append("	  AND IFNULL(STR_TO_DATE( :gijunDate, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE                                                                   ");
		sql.append("	  AND (( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                                                         ");
		sql.append("	          AND                                                                                                                                                       ");
		sql.append("	          IFNULL(A.WONNAE_DRG_YN,'N') LIKE :wonnaeDrgYn )                                                                                                           ");
		sql.append("	          OR                                                                                                                                                        ");
		sql.append("	       ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ))  AND       IFNULL(A.WONNAE_DRG_YN,'N') LIKE :wonnaeDrgYn )                                                         ");
//		sql.append("	  AND D.HOSP_CODE = B.HOSP_CODE                                                                                                                                     ");
		sql.append("	  AND A.SLIP_CODE = B.SLIP_CODE                                                                                                                                     ");
		sql.append("	  AND C.HOSP_CODE = B.HOSP_CODE                                                                                                                                     ");
		sql.append("	  AND C.ORDER_GUBUN = A.ORDER_GUBUN                                                                                                                                 ");
		sql.append("	  AND C.INPUT_TAB LIKE :inputTab                                                                                                                                    ");
		sql.append("	  AND B.LANGUAGE = :language                                                                                                                                    ");
//		sql.append("	  ORDER BY A.SLIP_CODE, IFNULL(E.SORT_SEQ, 0), A.HANGMOG_NAME                                                                                                       ");
		
		if(endNum != 0){
			sql.append("	  LIMIT :startNum, :endNum                                                                      							                                    ");
		}
		
		 
		Query query= entityManager.createNativeQuery(sql.toString());
	    query.setParameter("language", language);
	    query.setParameter("searchWord", searchWord);
	    query.setParameter("hospCode", hospCode);
	    query.setParameter("gijunDate", gijunDate);
	    query.setParameter("wonnaeDrgYn", wonnaeDrgYn);
	    query.setParameter("inputTab", inputTab);
	    query.setParameter("jundal_table_out", jundalTableOut);
	    if(!StringUtils.isEmpty(protocolId)){
	    	query.setParameter("f_protocol_id", protocolId);	
	    }
		if(endNum != 0){
			query.setParameter("startNum", startNum);
	    	query.setParameter("endNum", endNum);
		}
        	    
	    List<LoadSearchOrderInfo> list = new JpaResultMapper().list(query, LoadSearchOrderInfo.class);
	    return list;
	}

	
}

