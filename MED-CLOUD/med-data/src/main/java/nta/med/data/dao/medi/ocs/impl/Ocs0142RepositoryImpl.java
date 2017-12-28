package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0142RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.OcsLoadInputTabListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U11LaySlipCodeTreeInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U17GrdJaeryoOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U19TvwJaeryoGubunInfo;
import nta.med.data.model.ihis.system.LoadOftenUsedTabResponseInfo;

import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Ocs0142RepositoryImpl implements Ocs0142RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OcsLoadInputTabListItemInfo> getOcslibTabListItem(
			String hospCode, String inputTab) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.INPUT_TAB   input_tab  ,               			");        
		sql.append("	        A.ORDER_GUBUN order_gubun,                          ");
		sql.append("	        A.MAIN_YN     main_yn    ,                          ");
		sql.append("	        A.DEFAULT_YN  default_yn                            ");
		sql.append("	   FROM OCS0142 A                                           ");
		sql.append("	  WHERE A.HOSP_CODE = :hospCode                             ");
		sql.append("	    AND A.INPUT_TAB  LIKE TRIM(CONCAT(:inputTab,'%'))       ");
		sql.append("	 ORDER BY A.INPUT_TAB, A.ORDER_GUBUN                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("inputTab", inputTab);
		
		List<OcsLoadInputTabListItemInfo> listResult = new JpaResultMapper().list(query, OcsLoadInputTabListItemInfo.class);
		return listResult;
	}

	@Override
	public List<LoadOftenUsedTabResponseInfo> getLoadOftenUsedTabInfoElse(String hospCode,String language, String memb) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT DISTINCT                                                           ");
		sql.append("         C.XRAY_GUBUN          ORDER_GUBUN                                  ");
		sql.append("       , D.CODE_NAME           ORDER_GUBUN_NAME                             ");
		if(!StringUtils.isEmpty(memb)){
			sql.append("       , :f_aMemb        MEMB                                           ");	
		}else{
			sql.append("       , ' '        MEMB                                               ");	
		}
		sql.append("       , 'Y'                   XRAY_YN                                      ");
		sql.append("       , D.SEQ                 SORT_SEQ                                     ");
		sql.append("    FROM OCS0142 A  , OCS0103 B , XRT0001 C  , XRT0102 D                    ");          
		sql.append("   WHERE A.INPUT_TAB = '07' AND A.HOSP_CODE = :f_hosp_code                  ");
		sql.append("     AND A.ORDER_GUBUN = B.ORDER_GUBUN  AND A.MAIN_YN = 'Y'                 ");       
		sql.append("     AND A.HOSP_CODE = B.HOSP_CODE AND D.LANGUAGE = :f_language             ");
		sql.append("     AND B.HANGMOG_CODE = C.XRAY_CODE  AND C.HOSP_CODE = B.HOSP_CODE        ");      
		sql.append("     AND D.HOSP_CODE = C.HOSP_CODE AND C.XRAY_GUBUN   = D.CODE              ");  
		sql.append("     AND D.CODE_TYPE    = 'X1'                                              ");
		sql.append("   UNION                                                                    ");
		sql.append("  SELECT B.CODE                ORDER_GUBUN                                  ");
		sql.append("       , B.CODE_NAME           ORDER_GUBUN_NAME                             ");
		if(!StringUtils.isEmpty(memb)){
			sql.append("       , :f_aMemb        MEMB                                           ");	
		}else{
			sql.append("       , ' '        MEMB                                               ");	
		}
		sql.append("       , A.MAIN_YN             XRAY_YN                                      ");
		sql.append("       , 9                     SORT_SEQ                                     ");
		sql.append("    FROM OCS0142 A    , OCS0132 B                                           ");
		sql.append("   WHERE A.INPUT_TAB = '07'  AND A.HOSP_CODE = :f_hosp_code                 ");
		sql.append("     AND B.LANGUAGE =:f_language AND A.ORDER_GUBUN = B.CODE                 ");
		sql.append("     AND A.MAIN_YN != 'Y'     AND B.HOSP_CODE = A.HOSP_CODE                 ");
		sql.append("     AND B.CODE_TYPE = 'ORDER_GUBUN_BAS'        ORDER BY 4 DESC, 5, 1 		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		if(!StringUtils.isEmpty(memb)){
			query.setParameter("f_aMemb", memb);
		}
		
		List<LoadOftenUsedTabResponseInfo> listResult = new JpaResultMapper().list(query, LoadOftenUsedTabResponseInfo.class);
		return listResult;
	}

	@Override
	public List<LoadOftenUsedTabResponseInfo> getLoadOftenUsedTabInfo(String hospCode, String language, String memb, String inputTab) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT DISTINCT B.CODE      ORDER_GUBUN      ,B.CODE_NAME          ORDER_GUBUN_NAME ,                            ");
		if(!StringUtils.isEmpty(memb)){
			sql.append("  :f_aMemb      MEMB             ,                                                                              ");
		}else{
			sql.append("  ''      MEMB             ,                                                                                    ");
		}
		sql.append(" 	CONCAT(case A.MAIN_YN when 'Y' then '0' else '9' end,TRIM(LPAD(FORMAT(B.SORT_KEY,0), 3, '0')) )  ORDER_BY, CAST(null as DECIMAL) seq ");
		sql.append("    FROM OCS0132 B  , OCS0142 A                                                                                     ");
		sql.append("    WHERE A.INPUT_TAB LIKE IFNULL(:f_aInputTab, '%')                                                                ");
		sql.append("   AND A.HOSP_CODE   =  :f_hosp_code AND B.LANGUAGE  =:f_language                                                   ");
		sql.append("  AND A.ORDER_GUBUN = B.CODE AND B.CODE_TYPE   = 'ORDER_GUBUN_BAS'                                                  ");
		sql.append("   AND B.HOSP_CODE   = A.HOSP_CODE   ORDER BY ORDER_BY  															");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		if(!StringUtils.isEmpty(memb)){
			query.setParameter("f_aMemb", memb);
		}
		query.setParameter("f_aInputTab", inputTab);
		List<LoadOftenUsedTabResponseInfo> listResult = new JpaResultMapper().list(query, LoadOftenUsedTabResponseInfo.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U17MakeJaeryoGubunTabListItem(
			String hospCode, String inputTab, String codeType) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.ORDER_GUBUN ORDER_GUBUN 			");
		sql.append("	     , B.CODE_NAME   ORDER_GUBUN_NAME       ");
		sql.append("	  FROM OCS0142 A                            ");
		sql.append("	     , OCS0132 B                            ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode              ");
		sql.append("	   AND A.INPUT_TAB = :inputTab              ");
		sql.append("	   AND A.MAIN_YN   = 'N'                    ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE            ");
		sql.append("	   AND B.CODE      = A.ORDER_GUBUN          ");
		sql.append("	   AND B.CODE_TYPE = :codeType     			");
		sql.append("	 ORDER BY B.SORT_KEY                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("inputTab", inputTab);
		query.setParameter("codeType", codeType);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U17GrdJaeryoOrderInfo> getOCS0103U17LoadJaeryoOrderListItem(
			String hospCode, String mode, String orderGubun, String searchWord,
			String orderDate, String wonnaeDrgYn, String inputTab, boolean gubun, String protocolId, Integer pageNumber, Integer offset, String slipCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SLIP_CODE       SLIP_CODE																		");
		sql.append("	     , B.SLIP_NAME       SLIP_NAME                                                                      ");
		sql.append("	     , A.HANGMOG_CODE    HANGMOG_CODE                                                                   ");
		sql.append("	     , A.HANGMOG_NAME    HANGMOG_NAME                                                                   ");
		sql.append("	     , A.HOSP_CODE       HOSP_CODE                                                                      ");
		sql.append("	     , IFNULL(A.WONNAE_DRG_YN, 'N')   WONNAE_DRG_YN                                                     ");
		sql.append("	     , A.TRIAL_FLG       TRIAL_FLG                                                                      ");
		sql.append("	  FROM OCS0142 C                                                                                        ");
		sql.append("	     , OCS0102 B                                                                                        ");
		sql.append("	     , OCS0103 A                                                                                        ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                                                                          ");
		if(!StringUtils.isEmpty(slipCode)){
			sql.append("	 AND A.SLIP_CODE = :slipCode            															");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                    ");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))            ");
		}else{
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                              ");
		}
		sql.append("	   AND (( :f_mode = '1' AND A.HANGMOG_NAME_INX LIKE :f_search_word 										");
		if(gubun){
			sql.append("		AND A.ORDER_GUBUN = :f_order_gubun                                            				    ");
		}
		sql.append("	        ) OR ( :f_mode = '2'AND A.HANGMOG_NAME_INX LIKE :f_search_word ))                               ");
		sql.append("	   AND STR_TO_DATE(:f_order_date, '%Y/%m/%d') BETWEEN A.START_DATE                                      ");
		sql.append("	                                       AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%y%m%d'))        ");
		sql.append("	   AND (( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                            ");
		sql.append("	           AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                     ");
		sql.append("	          OR                                                                                            ");
		sql.append("	      ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn ) ");
		sql.append("	       )																								");
		if(gubun){
			sql.append("	   AND (( C.MAIN_YN != 'Y' )                                                                        ");
			sql.append("	         OR( C.MAIN_YN = 'Y' AND A.IF_INPUT_CONTROL != 'P'))                                        ");
		}
		sql.append("	   AND C.HOSP_CODE   = A.HOSP_CODE                                                                      ");
		sql.append("	   AND C.ORDER_GUBUN = A.ORDER_GUBUN                                                                    ");
		sql.append("	   AND C.INPUT_TAB   = :f_input_tab                                                                     ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                                                        ");
		sql.append("	   AND B.SLIP_CODE = A.SLIP_CODE                                                                        ");
		sql.append("	   AND B.LANGUAGE = :f_language                                                                        ");
		sql.append("	 ORDER BY A.SLIP_CODE, A.HANGMOG_NAME                                                                   ");
		sql.append(" LIMIT :f_page_number,:f_offset                                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		if(!StringUtils.isEmpty(slipCode)){
			query.setParameter("slipCode", slipCode);
		}
		query.setParameter("f_mode", mode);
		if(gubun){
			query.setParameter("f_order_gubun", orderGubun);
		}
		if(!StringUtils.isEmpty(protocolId)){
			query.setParameter("f_protocol_id", CommonUtils.parseInteger(protocolId));
		}
		query.setParameter("f_search_word", searchWord);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_wonnae_drg_yn", wonnaeDrgYn);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("f_offset", offset);
		query.setParameter("f_page_number", (pageNumber-1)*offset);	
		query.setParameter("f_language", language);
		
		List<OCS0103U17GrdJaeryoOrderInfo> listResult = new JpaResultMapper().list(query, OCS0103U17GrdJaeryoOrderInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U11LaySlipCodeTreeInfo> getOCS0103U11LaySlipCodeTreeListItem(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT														");
		sql.append("	       D.SLIP_GUBUN                                                 ");
		sql.append("	     , D.SLIP_GUBUN_NAME                                            ");
		sql.append("	     , C.SLIP_CODE                                                  ");
		sql.append("	     , C.SLIP_NAME                                                  ");
		sql.append("	     , CONCAT(D.SLIP_GUBUN , C.SLIP_CODE)    ORDERBYKEY             ");
		sql.append("	  FROM OCS0142 A                                                    ");
		sql.append("	     , OCS0103 B                                                    ");
		sql.append("	     , OCS0102 C                                                    ");
		sql.append("	     , OCS0101 D                                                    ");
		sql.append("	 WHERE A.HOSP_CODE   = :hospCode                                    ");
		sql.append("	   AND A.INPUT_TAB   = '10'                                         ");
		sql.append("	   AND A.MAIN_YN     = 'Y'                                          ");
		sql.append("	   AND B.HOSP_CODE   = A.HOSP_CODE                                  ");
		sql.append("	   AND B.ORDER_GUBUN = A.ORDER_GUBUN                                ");
		sql.append("	   AND C.HOSP_CODE   = B.HOSP_CODE                                  ");
		sql.append("	   AND C.SLIP_CODE   = B.SLIP_CODE                                  ");
		sql.append("	   AND C.LANGUAGE    = D.LANGUAGE                                   ");
		sql.append("	   AND D.SLIP_GUBUN  = C.SLIP_GUBUN AND D.LANGUAGE = :language      ");
		sql.append("	 ORDER BY 1 , ORDERBYKEY                                            ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);

		List<OCS0103U11LaySlipCodeTreeInfo> list = new JpaResultMapper().list(query, OCS0103U11LaySlipCodeTreeInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U19InitializeScreenComboListItem(
			String hospCode, String inputTab, String mainYn, String inputControl, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT B.SLIP_CODE						");
		sql.append("	   , C.SLIP_NAME                                ");
		sql.append("	FROM OCS0142 A                                  ");
		sql.append("	   , OCS0103 B                                  ");
		sql.append("	   , OCS0102 C                                  ");
		sql.append("	WHERE A.HOSP_CODE = :hospCode                   ");
		sql.append("	 AND A.INPUT_TAB = :f_input_tab                 ");
		sql.append("	 AND A.MAIN_YN = :mainYn                        ");
		sql.append("	 AND B.HOSP_CODE = A.HOSP_CODE                  ");
		sql.append("	 AND B.ORDER_GUBUN = A.ORDER_GUBUN              ");
		sql.append("	 AND B.IF_INPUT_CONTROL != :inputControl        ");
		sql.append("	 AND C.HOSP_CODE = B.HOSP_CODE                  ");
		sql.append("	 AND C.SLIP_CODE = B.SLIP_CODE                  ");
		sql.append("	 AND C.LANGUAGE = :f_language                   ");
		sql.append("	ORDER BY 1                                      ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("mainYn", mainYn);
		query.setParameter("inputControl", inputControl);
		query.setParameter("f_language", language);
		
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS0103U19TvwJaeryoGubunInfo> getOCS0103U19InitializeScreenTvwJaeryoGubunItem(String hospCode, 
			String inputTab, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT A.ORDER_GUBUN ORDER_GUBUN 		");
		sql.append("	     , B.CODE_NAME   ORDER_GUBUN_NAME           ");
		sql.append("	     , B.SORT_KEY    SORT_KEY                   ");
		sql.append("	  FROM OCS0142 A                                ");
		sql.append("	     , OCS0132 B                                ");
		sql.append("	 WHERE A.HOSP_CODE   = :hospCode                ");
		sql.append("	   AND A.INPUT_TAB   = :inputTab                ");
		sql.append("	   AND A.MAIN_YN     = 'N'                      ");
		sql.append("	   AND B.HOSP_CODE  = A.HOSP_CODE               ");
		sql.append("	   AND B.CODE        = A.ORDER_GUBUN            ");
		sql.append("	   AND B.CODE_TYPE   = 'ORDER_GUBUN_BAS'        ");
		sql.append("	   AND B.LANGUAGE = :language                   ");
		sql.append("	 UNION ALL                                      ");
		sql.append("	SELECT DISTINCT A.ORDER_GUBUN ORDER_GUBUN       ");
		sql.append("	     , C.CODE_NAME   ORDER_GUBUN_NAME           ");
		sql.append("	     , 0             SORT_KEY                   ");
		sql.append("	  FROM OCS0142 A                                ");
		sql.append("	     , OCS0103 B                                ");
		sql.append("	     , OCS0132 C                                ");
		sql.append("	 WHERE A.HOSP_CODE   = :hospCode                ");
		sql.append("	   AND A.INPUT_TAB   = :inputTab                ");
		sql.append("	   AND A.MAIN_YN     = 'Y'                      ");
		sql.append("	   AND B.HOSP_CODE   = A.HOSP_CODE              ");
		sql.append("	   AND B.ORDER_GUBUN = A.ORDER_GUBUN            ");
		sql.append("	   AND B.IF_INPUT_CONTROL != 'P'                ");
		sql.append("	   AND C.HOSP_CODE   = B.HOSP_CODE              ");
		sql.append("	   AND C.CODE        = B.ORDER_GUBUN            ");
		sql.append("	   AND C.CODE_TYPE   = 'ORDER_GUBUN_BAS'        ");
		sql.append("	   AND C.LANGUAGE = :language                   ");
		sql.append("	 ORDER BY SORT_KEY                              ");
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("inputTab", inputTab);
		query.setParameter("language", language);
		
		List<OCS0103U19TvwJaeryoGubunInfo> list = new JpaResultMapper().list(query, OCS0103U19TvwJaeryoGubunInfo.class);
		return list;
	}
	
}

