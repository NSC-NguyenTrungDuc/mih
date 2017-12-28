package nta.med.data.dao.medi.ifs.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.glossary.AccountingConfig;
import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ifs.Ifs0003RepositoryCustom;
import nta.med.data.model.ihis.bass.Ifs0003U00GrdIFS0003Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0103Info;

/**
 * @author dainguyen.
 */
public class Ifs0003RepositoryImpl implements Ifs0003RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public String getCodeByHospCodeAndMapGubunAndIfCode(String hospCode, String mapGubun, String ifCode) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT OCS_CODE								");
		sql.append("	FROM IFS0003 A                              ");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code        	");
		sql.append("	AND A.MAP_GUBUN     = :f_map_gubun          ");
		sql.append("	AND UPPER(A.IF_CODE)   	= :f_if_code		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_map_gubun", mapGubun);
		query.setParameter("f_if_code", ifCode.toUpperCase());

		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return "";
	}
	
	@Override
	public String getIfs003U03LayDupCheck(String hospCode, String mapGubun,
			Date mapGubunYmd, String ocsCode, boolean codeCondition) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT 'Y'  								");	
		sql.append("	FROM IFS0003 A                              ");
		sql.append("	WHERE A.HOSP_CODE     = :f_hosp_code        ");
		sql.append("	AND A.MAP_GUBUN     = :f_map_gubun          ");
		sql.append("	AND A.MAP_GUBUN_YMD = :f_map_gubun_ymd      ");
		if(codeCondition){
			sql.append("	AND A.OCS_CODE       = :f_ocs_code      ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_map_gubun", mapGubun);
		query.setParameter("f_map_gubun_ymd", mapGubunYmd);
		if(codeCondition){
			query.setParameter("f_ocs_code", ocsCode);
		}
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	
	public String callPkgIfsBasFnLoadIfCodeName (String hospCode, String mapGubun, String code){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT                             ");
		sql.append("	PKG_IFS_BAS_FN_LOAD_IF_CODE_NAME(  ");
		sql.append("	:f_hosp_code,                      ");
		sql.append("	:f_map_gubun,                      ");
		sql.append("	:f_code) IF_CODE_NAME              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_map_gubun", mapGubun);
		query.setParameter("f_code", code);

		@SuppressWarnings("unchecked")
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<OCS0103U00GrdOCS0103Info> getOCS0103U00GrdOCS0103Info(
			String hospCode, String language, String aSlipCode,
			String aHangMogInx, String aSlipGubun, String usedYn, String wonaeYn, Integer startNumber, Integer offset) {
		
		/*StringBuilder sql = new StringBuilder();
		sql.append(" ( SELECT    A.SYS_DATE                                                                                                                         ");
		sql.append("         , A.SYS_ID                                                                                                                             ");
		sql.append("         , A.UPD_DATE                                                                                                                           ");
		sql.append("         , A.HANGMOG_CODE                                                                                                                       ");
		sql.append("         , A.HANGMOG_NAME                                                                                                                       ");
		sql.append("         , A.SLIP_CODE                                                                                                                          ");
		sql.append("         , A.GROUP_YN                                                                                                                           ");
		sql.append("         , A.POSITION                                                                                                                           ");
		sql.append("         , A.SEQ                                                                                                                                ");
		sql.append("         , A.ORDER_GUBUN                                                                                                                        ");
		sql.append("         , A.INPUT_CONTROL                                                                                                                      ");
		sql.append("         , A.JUNDAL_TABLE_OUT                                                                                                                   ");
		sql.append("         , A.JUNDAL_TABLE_INP                                                                                                                   ");
		sql.append("         , A.JUNDAL_PART_OUT                                                                                                                    ");
		sql.append("         , A.JUNDAL_PART_INP                                                                                                                    ");
		sql.append("         , A.MOVE_PART                                                                                                                          ");
		sql.append("         , A.DV_TIME                                                                                                                            ");
		sql.append("         , A.ORD_DANUI                                                                                                                          ");
		sql.append("         , A.DEFAULT_BOGYONG_CODE                                                                                                               ");
		sql.append("         , A.SUGA_YN                                                                                                                            ");
		sql.append("         , A.SG_CODE                                                                                                                            ");
		sql.append("         , A.JAERYO_YN                                                                                                                          ");
		sql.append("         , A.JAERYO_CODE                                                                                                                        ");
		sql.append("         , A.HANGMOG_NAME_INX                                                                                                                   ");
		sql.append("         , A.DISPLAY_YN                                                                                                                         ");
		sql.append("         , A.START_DATE                                                                                                                         ");
		sql.append("         , A.END_DATE                                                                                                                           ");
		sql.append("         , A.SPECIMEN_YN                                                                                                                        ");
		sql.append("         , A.SPECIMEN_DEFAULT                                                                                                                   ");
		sql.append("         , A.DEFAULT_PORTABLE_YN        DEFAULT_PORTABLE_YN1                                                                                    ");
		sql.append("         , A.SPECIFIC_COMMENT                                                                                                                   ");
		sql.append("         , A.RESER_YN_OUT                                                                                                                       ");
		sql.append("         , A.RESER_YN_INP                                                                                                                       ");
		sql.append("         , A.EMERGENCY                                                                                                                          ");
		sql.append("         , A.LIMIT_SURYANG                                                                                                                      ");
		sql.append("         , A.BOM_YN                                                                                                                             ");
		sql.append("         , A.RETURN_YN                                                                                                                          ");
		sql.append("         , A.SUBUL_CONVERT_GUBUN                                                                                                                ");
		sql.append("         , A.WONYOI_ORDER_YN                                                                                                                    ");
		sql.append("         , A.DEFAULT_WONNAE_SAYU                                                                                                                ");
		sql.append("         , A.ANTI_CANCER_YN                                                                                                                     ");
		sql.append("         , A.CHISIK_YN                                                                                                                          ");
		sql.append("         , A.NDAY_YN                                                                                                                            ");
		sql.append("         , A.MUHYO_YN                                                                                                                           ");
		sql.append("         , A.INV_JUNDAL_YN                                                                                                                      ");
		sql.append("         , A.POWDER_YN                                                                                                                          ");
		sql.append("         , A.REMARK                                                                                                                             ");
		sql.append("         , A.DEFAULT_DV                                                                                                                         ");
		sql.append("         , A.DEFAULT_SURYANG                                                                                                                    ");
		sql.append("         , A.NURSE_INPUT_YN                                                                                                                     ");
		sql.append("         , A.SUPPLY_INPUT_YN                                                                                                                    ");
		sql.append("         , A.LIMIT_NALSU                                                                                                                        ");
		sql.append("         , A.DEFAULT_WONYOI_YN                                                                                                                  ");
		sql.append("         , A.PORTABLE_CHECK                                                                                                                     ");
		sql.append("         , A.PAT_STATUS_GR                                                                                                                      ");
		sql.append("         , A.UPD_ID                                                                                                                             ");
		sql.append("         , A.HOSP_CODE                                                                                                                          ");
		sql.append("         , A.DEFAULT_JUSA                                                                                                                       ");
		sql.append("         , B.SLIP_NAME                                                                                                                          ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_OUT, SYSDATE(), :f_hosp_code,:f_langauge)   JUNDAL_PART_OUT_NAME                                  ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_INP, SYSDATE(), :f_hosp_code,:f_langauge)   JUNDAL_PART_INP_NAME                                  ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.MOVE_PART, SYSDATE(), :f_hosp_code,:f_langauge)         MOVE_PART_NAME                                        ");
		sql.append("         , E.JAERYO_NAME                                                                                                                        ");
		sql.append("         , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', E.SUBUL_DANUI, :f_hosp_code,:f_langauge) SUBUL_DANUI_NAME                                       ");
		sql.append("         , DATE_FORMAT(E.BULYONG_DATE, '%Y/%m/%d')  JEARYO_BULYONG_DATE                                                                         ");
		sql.append("         , CASE WHEN A.ORDER_GUBUN IN ('C', 'D') THEN FN_DRG_LOAD_BOGYONG_NAME (A.DEFAULT_BOGYONG_CODE, :f_hosp_code )                          ");
		sql.append("         WHEN A.ORDER_GUBUN IN ('B')      THEN FN_OCS_LOAD_CODE_NAME ('JUSA', A.DEFAULT_BOGYONG_CODE, :f_hosp_code,:f_langauge)                 ");
		sql.append("         ELSE NULL                                                                                                                              ");
		sql.append("         END DEFAULT_BOGYONG_NAME                                                                                                               ");
		sql.append("         , A.IF_INPUT_CONTROL                                                                                                                   ");
		sql.append("         , D.HUBAL_DRG_YN                                                                                                                       ");
		sql.append("         , D.SG_NAME                                                                                                                            ");
		sql.append("         , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', D.DANUI, :f_hosp_code,:f_langauge)      SG_DANUI_NAME                                           ");
		sql.append("         , DATE_FORMAT(D.BULYONG_YMD, '%Y/%m/%d')                                                                                               ");
		sql.append("         , A.RESULT_GUBUN                                                                                                                       ");
		sql.append("         , A.WONNAE_DRG_YN                                                                                                                      ");
		sql.append("         , '' COMMON_ORDER                                                                                                                   ");
		sql.append("         , A.YAK_KIJUN_CODE                                                                                                                     ");
		sql.append("         , A.YJ_CODE                                                                                                                            ");
		sql.append("         , G.IF_CODE                                                                                                                            ");
		sql.append("         , A.TRIAL_FLG                                                                                                                          ");
		sql.append("         , H.PROTOCOL_CODE                                                                                                                      ");
		sql.append("         , A.DEFAULT_PORTABLE_YN    DEFAULT_PORTABLE_YN2                                                                                        ");
		sql.append(" FROM    ( SELECT * FROM OCS0103 O  WHERE O.HOSP_CODE        = :f_hosp_code                                                                     ");
		sql.append("              AND O.SLIP_CODE        LIKE :f_aSlipCode AND O.HANGMOG_NAME_INX LIKE :f_aHangmogINX                        						");
		sql.append("     AND NOT EXISTS (SELECT 'Y' FROM OCS0103S S  WHERE S.HANGMOG_CODE = O.HANGMOG_CODE AND S.GROUP_CODE = (SELECT GROUP_CODE FROM BAS0001       ");
		sql.append("                      WHERE HOSP_CODE = :f_hosp_code AND START_DATE = (SELECT MAX(START_DATE) FROM BAS0001  WHERE HOSP_CODE = :f_hosp_code)))	");
		sql.append("				  ORDER BY O.HANGMOG_CODE  ) A                        																	        ");
		sql.append("              LEFT JOIN  CLIS_PROTOCOL H ON A.HOSP_CODE = H.HOSP_CODE AND A.CLIS_PROTOCOL_ID = H.CLIS_PROTOCOL_ID                               ");
		sql.append("              INNER JOIN  OCS0102 B ON B.HOSP_CODE = A.HOSP_CODE AND B.SLIP_CODE = A.SLIP_CODE                                                  ");
		sql.append("              INNER JOIN OCS0101 C ON  C.SLIP_GUBUN = B.SLIP_GUBUN AND C.SLIP_GUBUN  LIKE :f_aSlipGubun                                         ");
		sql.append("              LEFT JOIN ( SELECT  X.SG_CODE                                                                                                     ");
		sql.append("                 , X.SG_UNION                                                                                                                   ");
		sql.append("                 , X.SG_NAME                                                                                                                    ");
		sql.append("                 , X.BULYONG_YMD                                                                                                                ");
		sql.append("                 , X.DANUI                                                                                                                      ");
		sql.append("                 , X.HUBAL_DRG_YN                                                                                                               ");
		sql.append("                 , X.HOSP_CODE                                                                                                                  ");
		sql.append("           FROM BAS0310 X                                                                                                                       ");
		sql.append("          WHERE X.HOSP_CODE = :f_hosp_code                                                                                                      ");
		sql.append("            AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                               ");
		sql.append("                               FROM BAS0310 Z                                                                                                   ");
		sql.append("                              WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                                   ");
		sql.append("                                AND Z.SG_CODE = X.SG_CODE                                                                                       ");
		sql.append("                                AND Z.SG_YMD <= SYSDATE() )                                                                                     ");
		sql.append("          ) D ON D.HOSP_CODE = A.HOSP_CODE AND D.SG_CODE = A.SG_CODE                                                                            ");
		sql.append("          LEFT JOIN INV0110 E ON E.HOSP_CODE = A.HOSP_CODE AND E.JAERYO_CODE = A.JAERYO_CODE                                                    ");
		sql.append("          LEFT JOIN CNV0006 F ON F.SG_CODE = D.SG_CODE                                                                                          ");
		sql.append("          LEFT JOIN ( SELECT A.IF_CODE                                                                                                          ");
		sql.append("                  , A.OCS_CODE                                                                                                                  ");
		sql.append("                  , A.HOSP_CODE                                                                                                                 ");
		sql.append("               FROM IFS0003 A                                                                                                                   ");
		sql.append("              WHERE A.HOSP_CODE      = :f_hosp_code                                                                                             ");
		sql.append("                AND A.MAP_GUBUN      IN ( 'IF_SKR_HANGMOG_JAE', 'IF_SKR_HANGMOG', 'IF_SKR_HANGMOG_DRG')                                         ");
		sql.append("                AND A.MAP_GUBUN_YMD  = ( SELECT MAX(Z.MAP_GUBUN_YMD)                                                                            ");
		sql.append("                                           FROM IFS0003 Z                                                                                       ");
		sql.append("                                          WHERE Z.HOSP_CODE    = A.HOSP_CODE                                                                    ");
		sql.append("                                            AND Z.MAP_GUBUN    = A.MAP_GUBUN                                                                    ");
		sql.append("                                            AND Z.OCS_CODE     = A.OCS_CODE                                                                     ");
		sql.append("                                            AND (   Z.MAP_GUBUN_YMD  < STR_TO_DATE('9998/12/31', '%Y/%m/%d')                                    ");
		sql.append("                                                 OR Z.MAP_GUBUN_YMD  = STR_TO_DATE(SYSDATE(), '%Y/%m/%d')                                       ");
		sql.append("                                                )                                                                                               ");
		sql.append("                                            AND Z.IF_CODE      = A.IF_CODE                                                                      ");
		sql.append("                                       )                                                                                                        ");
		sql.append("           ) G ON G.HOSP_CODE = A.HOSP_CODE AND G.OCS_CODE = A.HANGMOG_CODE                                                                     ");
		sql.append(" WHERE                                                                                                                                          ");
		sql.append("    (                                                                                                                                           ");
		sql.append("           ( :f_used_yn = '%' )                                                                                                                 ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_used_yn = '1'                                                                                                                   ");
		sql.append("           AND F.SG_CODE IS NOT NULL )                                                                                                          ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_used_yn = '2'                                                                                                                   ");
		sql.append("           AND F.SG_CODE IS NULL )                                                                                                              ");
		sql.append("           )                                                                                                                                    ");
		sql.append("           AND (                                                                                                                                ");
		sql.append("           ( :f_wonnae_yn = '%' )                                                                                                               ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_wonnae_yn = '1'                                                                                                                 ");
		sql.append("           AND IFNULL(A.WONNAE_DRG_YN, 'N') = 'Y' )                                                                                             ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_wonnae_yn = '2'                                                                                                                 ");
		sql.append("           AND IFNULL(A.WONNAE_DRG_YN, 'N') != 'Y' )                                                                                            ");
		//sql.append("       )           limit 200        )                                                                                                         ");
		sql.append("       )                   )                                                                                                                    ");
		
		sql.append("       UNION                                                                                                                                    ");
		
		sql.append(" ( SELECT    A.SYS_DATE                                                                                                                         ");
		sql.append("         , A.SYS_ID                                                                                                                             ");
		sql.append("         , A.UPD_DATE                                                                                                                           ");
		sql.append("         , A.HANGMOG_CODE                                                                                                                       ");
		sql.append("         , A.HANGMOG_NAME                                                                                                                       ");
		sql.append("         , A.SLIP_CODE                                                                                                                          ");
		sql.append("         , A.GROUP_YN                                                                                                                           ");
		sql.append("         , A.POSITION                                                                                                                           ");
		sql.append("         , A.SEQ                                                                                                                                ");
		sql.append("         , A.ORDER_GUBUN                                                                                                                        ");
		sql.append("         , A.INPUT_CONTROL                                                                                                                      ");
		sql.append("         , A.JUNDAL_TABLE_OUT                                                                                                                   ");
		sql.append("         , A.JUNDAL_TABLE_INP                                                                                                                   ");
		sql.append("         , A.JUNDAL_PART_OUT                                                                                                                    ");
		sql.append("         , A.JUNDAL_PART_INP                                                                                                                    ");
		sql.append("         , A.MOVE_PART                                                                                                                          ");
		sql.append("         , A.DV_TIME                                                                                                                            ");
		sql.append("         , A.ORD_DANUI                                                                                                                          ");
		sql.append("         , A.DEFAULT_BOGYONG_CODE                                                                                                               ");
		sql.append("         , A.SUGA_YN                                                                                                                            ");
		sql.append("         , A.SG_CODE                                                                                                                            ");
		sql.append("         , A.JAERYO_YN                                                                                                                          ");
		sql.append("         , A.JAERYO_CODE                                                                                                                        ");
		sql.append("         , A.HANGMOG_NAME_INX                                                                                                                   ");
		sql.append("         , A.DISPLAY_YN                                                                                                                         ");
		sql.append("         , A.START_DATE                                                                                                                         ");
		sql.append("         , A.END_DATE                                                                                                                           ");
		sql.append("         , A.SPECIMEN_YN                                                                                                                        ");
		sql.append("         , A.SPECIMEN_DEFAULT                                                                                                                   ");
		sql.append("         , A.DEFAULT_PORTABLE_YN        DEFAULT_PORTABLE_YN1                                                                                    ");
		sql.append("         , A.SPECIFIC_COMMENT                                                                                                                   ");
		sql.append("         , A.RESER_YN_OUT                                                                                                                       ");
		sql.append("         , A.RESER_YN_INP                                                                                                                       ");
		sql.append("         , A.EMERGENCY                                                                                                                          ");
		sql.append("         , A.LIMIT_SURYANG                                                                                                                      ");
		sql.append("         , A.BOM_YN                                                                                                                             ");
		sql.append("         , A.RETURN_YN                                                                                                                          ");
		sql.append("         , A.SUBUL_CONVERT_GUBUN                                                                                                                ");
		sql.append("         , A.WONYOI_ORDER_YN                                                                                                                    ");
		sql.append("         , A.DEFAULT_WONNAE_SAYU                                                                                                                ");
		sql.append("         , A.ANTI_CANCER_YN                                                                                                                     ");
		sql.append("         , A.CHISIK_YN                                                                                                                          ");
		sql.append("         , A.NDAY_YN                                                                                                                            ");
		sql.append("         , A.MUHYO_YN                                                                                                                           ");
		sql.append("         , A.INV_JUNDAL_YN                                                                                                                      ");
		sql.append("         , A.POWDER_YN                                                                                                                          ");
		sql.append("         , A.REMARK                                                                                                                             ");
		sql.append("         , A.DEFAULT_DV                                                                                                                         ");
		sql.append("         , A.DEFAULT_SURYANG                                                                                                                    ");
		sql.append("         , A.NURSE_INPUT_YN                                                                                                                     ");
		sql.append("         , A.SUPPLY_INPUT_YN                                                                                                                    ");
		sql.append("         , A.LIMIT_NALSU                                                                                                                        ");
		sql.append("         , A.DEFAULT_WONYOI_YN                                                                                                                  ");
		sql.append("         , A.PORTABLE_CHECK                                                                                                                     ");
		sql.append("         , A.PAT_STATUS_GR                                                                                                                      ");
		sql.append("         , A.UPD_ID                                                                                                                             ");
		sql.append("         , ''  HOSP_CODE                                                                                                                        ");
		sql.append("         , A.DEFAULT_JUSA                                                                                                                       ");
		sql.append("         , B.SLIP_NAME                                                                                                                          ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_OUT, SYSDATE(), :f_hosp_code,:f_langauge)   JUNDAL_PART_OUT_NAME                                  ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_INP, SYSDATE(), :f_hosp_code,:f_langauge)   JUNDAL_PART_INP_NAME                                  ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.MOVE_PART, SYSDATE(), :f_hosp_code,:f_langauge)         MOVE_PART_NAME                                        ");
		sql.append("         , E.JAERYO_NAME                                                                                                                        ");
		sql.append("         , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', E.SUBUL_DANUI, :f_hosp_code,:f_langauge) SUBUL_DANUI_NAME                                       ");
		sql.append("         , DATE_FORMAT(E.BULYONG_DATE, '%Y/%m/%d')  JEARYO_BULYONG_DATE                                                                         ");
		sql.append("         , CASE WHEN A.ORDER_GUBUN IN ('C', 'D') THEN FN_DRG_LOAD_BOGYONG_NAME (A.DEFAULT_BOGYONG_CODE, :f_hosp_code )                          ");
		sql.append("         WHEN A.ORDER_GUBUN IN ('B')      THEN FN_OCS_LOAD_CODE_NAME ('JUSA', A.DEFAULT_BOGYONG_CODE, :f_hosp_code,:f_langauge)                 ");
		sql.append("         ELSE NULL                                                                                                                              ");
		sql.append("         END DEFAULT_BOGYONG_NAME                                                                                                               ");
		sql.append("         , A.IF_INPUT_CONTROL                                                                                                                   ");
		sql.append("         , D.HUBAL_DRG_YN                                                                                                                       ");
		sql.append("         , D.SG_NAME                                                                                                                            ");
		sql.append("         , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', D.DANUI, :f_hosp_code,:f_langauge)      SG_DANUI_NAME                                           ");
		sql.append("         , DATE_FORMAT(D.BULYONG_YMD, '%Y/%m/%d')                                                                                               ");
		sql.append("         , A.RESULT_GUBUN                                                                                                                       ");
		sql.append("         , A.WONNAE_DRG_YN                                                                                                                      ");
		sql.append("         , A.COMMON_YN  COMMON_ORDER                                                                                                         ");
		sql.append("         , A.YAK_KIJUN_CODE                                                                                                                     ");
		sql.append("         , A.YJ_CODE                                                                                                                            ");
		sql.append("         , G.IF_CODE                                                                                                                            ");
		sql.append("         , A.TRIAL_FLG                                                                                                                          ");
		sql.append("         , H.PROTOCOL_CODE                                                                                                                      ");
		sql.append("         , A.DEFAULT_PORTABLE_YN    DEFAULT_PORTABLE_YN2                                                                                        ");
		sql.append(" FROM    ( SELECT * FROM OCS0103S  WHERE COMMON_YN = 'Y' AND GROUP_CODE  =  (SELECT GROUP_CODE FROM BAS0001 									");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code AND START_DATE = (SELECT MAX(START_DATE)    FROM BAS0001  WHERE HOSP_CODE = :f_hosp_code)) 					");
		sql.append("              AND SLIP_CODE        LIKE :f_aSlipCode AND HANGMOG_NAME_INX LIKE :f_aHangmogINX ORDER BY HANGMOG_CODE  ) A                        ");
		sql.append("              LEFT JOIN  CLIS_PROTOCOL H ON H.HOSP_CODE = :f_hosp_code AND A.CLIS_PROTOCOL_ID = H.CLIS_PROTOCOL_ID                              ");
		sql.append("              INNER JOIN  OCS0102 B ON B.HOSP_CODE = :f_hosp_code AND B.SLIP_CODE = A.SLIP_CODE                                                 ");
		sql.append("              INNER JOIN OCS0101 C ON  C.SLIP_GUBUN = B.SLIP_GUBUN AND C.SLIP_GUBUN  LIKE :f_aSlipGubun                                         ");
		sql.append("              LEFT JOIN ( SELECT  X.SG_CODE                                                                                                     ");
		sql.append("                 , X.SG_UNION                                                                                                                   ");
		sql.append("                 , X.SG_NAME                                                                                                                    ");
		sql.append("                 , X.BULYONG_YMD                                                                                                                ");
		sql.append("                 , X.DANUI                                                                                                                      ");
		sql.append("                 , X.HUBAL_DRG_YN                                                                                                               ");
		sql.append("                 , X.HOSP_CODE                                                                                                                  ");
		sql.append("           FROM BAS0310 X                                                                                                                       ");
		sql.append("          WHERE X.HOSP_CODE = :f_hosp_code                                                                                                      ");
		sql.append("            AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                               ");
		sql.append("                               FROM BAS0310 Z                                                                                                   ");
		sql.append("                              WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                                   ");
		sql.append("                                AND Z.SG_CODE = X.SG_CODE                                                                                       ");
		sql.append("                                AND Z.SG_YMD <= SYSDATE() )                                                                                     ");
		sql.append("          ) D ON D.HOSP_CODE = :f_hosp_code AND D.SG_CODE = A.SG_CODE                                                                           ");
		sql.append("          LEFT JOIN INV0110 E ON E.HOSP_CODE = :f_hosp_code AND E.JAERYO_CODE = A.JAERYO_CODE                                                   ");
		sql.append("          LEFT JOIN CNV0006 F ON F.SG_CODE = D.SG_CODE                                                                                          ");
		sql.append("          LEFT JOIN ( SELECT A.IF_CODE                                                                                                          ");
		sql.append("                  , A.OCS_CODE                                                                                                                  ");
		sql.append("                  , A.HOSP_CODE                                                                                                                 ");
		sql.append("               FROM IFS0003 A                                                                                                                   ");
		sql.append("              WHERE A.HOSP_CODE      = :f_hosp_code                                                                                             ");
		sql.append("                AND A.MAP_GUBUN      IN ( 'IF_SKR_HANGMOG_JAE', 'IF_SKR_HANGMOG', 'IF_SKR_HANGMOG_DRG')                                         ");
		sql.append("                AND A.MAP_GUBUN_YMD  = ( SELECT MAX(Z.MAP_GUBUN_YMD)                                                                            ");
		sql.append("                                           FROM IFS0003 Z                                                                                       ");
		sql.append("                                          WHERE Z.HOSP_CODE    = A.HOSP_CODE                                                                    ");
		sql.append("                                            AND Z.MAP_GUBUN    = A.MAP_GUBUN                                                                    ");
		sql.append("                                            AND Z.OCS_CODE     = A.OCS_CODE                                                                     ");
		sql.append("                                            AND (   Z.MAP_GUBUN_YMD  < STR_TO_DATE('9998/12/31', '%Y/%m/%d')                                    ");
		sql.append("                                                 OR Z.MAP_GUBUN_YMD  = STR_TO_DATE(SYSDATE(), '%Y/%m/%d')                                       ");
		sql.append("                                                )                                                                                               ");
		sql.append("                                            AND Z.IF_CODE      = A.IF_CODE                                                                      ");
		sql.append("                                       )                                                                                                        ");
		sql.append("           ) G ON G.HOSP_CODE = :f_hosp_code AND G.OCS_CODE = A.HANGMOG_CODE                                                                    ");
		sql.append(" WHERE                                                                                                                                          ");
		sql.append("    (                                                                                                                                           ");
		sql.append("           ( :f_used_yn = '%' )                                                                                                                 ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_used_yn = '1'                                                                                                                   ");
		sql.append("           AND F.SG_CODE IS NOT NULL )                                                                                                          ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_used_yn = '2'                                                                                                                   ");
		sql.append("           AND F.SG_CODE IS NULL )                                                                                                              ");
		sql.append("           )                                                                                                                                    ");
		sql.append("           AND (                                                                                                                                ");
		sql.append("           ( :f_wonnae_yn = '%' )                                                                                                               ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_wonnae_yn = '1'                                                                                                                 ");
		sql.append("           AND IFNULL(A.WONNAE_DRG_YN, 'N') = 'Y' )                                                                                             ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_wonnae_yn = '2'                                                                                                                 ");
		sql.append("           AND IFNULL(A.WONNAE_DRG_YN, 'N') != 'Y' )                                                                                            ");
		sql.append("       )                )                                                                                                              			");
		//sql.append("       )           limit 200     )                                                                                                            ");
		
		sql.append("  limit :startNum, :offset                                                                 														 ");*/
		
//		StringBuilder sql = new StringBuilder();
//		sql.append(" SELECT    A.SYS_DATE                                                                                                                         	");
//		sql.append("         , A.SYS_ID                                                                                                                             ");
//		sql.append("         , A.UPD_DATE                                                                                                                           ");
//		sql.append("         , A.HANGMOG_CODE                                                                                                                       ");
//		sql.append("         , A.HANGMOG_NAME                                                                                                                       ");
//		sql.append("         , A.SLIP_CODE                                                                                                                          ");
//		sql.append("         , A.GROUP_YN                                                                                                                           ");
//		sql.append("         , A.POSITION                                                                                                                           ");
//		sql.append("         , A.SEQ                                                                                                                                ");
//		sql.append("         , A.ORDER_GUBUN                                                                                                                        ");
//		sql.append("         , A.INPUT_CONTROL                                                                                                                      ");
//		sql.append("         , A.JUNDAL_TABLE_OUT                                                                                                                   ");
//		sql.append("         , A.JUNDAL_TABLE_INP                                                                                                                   ");
//		sql.append("         , A.JUNDAL_PART_OUT                                                                                                                    ");
//		sql.append("         , A.JUNDAL_PART_INP                                                                                                                    ");
//		sql.append("         , A.MOVE_PART                                                                                                                          ");
//		sql.append("         , A.DV_TIME                                                                                                                            ");
//		sql.append("         , A.ORD_DANUI                                                                                                                          ");
//		sql.append("         , A.DEFAULT_BOGYONG_CODE                                                                                                               ");
//		sql.append("         , A.SUGA_YN                                                                                                                            ");
//		sql.append("         , A.SG_CODE                                                                                                                            ");
//		sql.append("         , A.JAERYO_YN                                                                                                                          ");
//		sql.append("         , A.JAERYO_CODE                                                                                                                        ");
//		sql.append("         , A.HANGMOG_NAME_INX                                                                                                                   ");
//		sql.append("         , A.DISPLAY_YN                                                                                                                         ");
//		sql.append("         , A.START_DATE                                                                                                                         ");
//		sql.append("         , A.END_DATE                                                                                                                           ");
//		sql.append("         , A.SPECIMEN_YN                                                                                                                        ");
//		sql.append("         , A.SPECIMEN_DEFAULT                                                                                                                   ");
//		sql.append("         , A.DEFAULT_PORTABLE_YN        DEFAULT_PORTABLE_YN1                                                                                    ");
//		sql.append("         , A.SPECIFIC_COMMENT                                                                                                                   ");
//		sql.append("         , A.RESER_YN_OUT                                                                                                                       ");
//		sql.append("         , A.RESER_YN_INP                                                                                                                       ");
//		sql.append("         , A.EMERGENCY                                                                                                                          ");
//		sql.append("         , A.LIMIT_SURYANG                                                                                                                      ");
//		sql.append("         , A.BOM_YN                                                                                                                             ");
//		sql.append("         , A.RETURN_YN                                                                                                                          ");
//		sql.append("         , A.SUBUL_CONVERT_GUBUN                                                                                                                ");
//		sql.append("         , A.WONYOI_ORDER_YN                                                                                                                    ");
//		sql.append("         , A.DEFAULT_WONNAE_SAYU                                                                                                                ");
//		sql.append("         , A.ANTI_CANCER_YN                                                                                                                     ");
//		sql.append("         , A.CHISIK_YN                                                                                                                          ");
//		sql.append("         , A.NDAY_YN                                                                                                                            ");
//		sql.append("         , A.MUHYO_YN                                                                                                                           ");
//		sql.append("         , A.INV_JUNDAL_YN                                                                                                                      ");
//		sql.append("         , A.POWDER_YN                                                                                                                          ");
//		sql.append("         , A.REMARK                                                                                                                             ");
//		sql.append("         , A.DEFAULT_DV                                                                                                                         ");
//		sql.append("         , A.DEFAULT_SURYANG                                                                                                                    ");
//		sql.append("         , A.NURSE_INPUT_YN                                                                                                                     ");
//		sql.append("         , A.SUPPLY_INPUT_YN                                                                                                                    ");
//		sql.append("         , A.LIMIT_NALSU                                                                                                                        ");
//		sql.append("         , A.DEFAULT_WONYOI_YN                                                                                                                  ");
//		sql.append("         , A.PORTABLE_CHECK                                                                                                                     ");
//		sql.append("         , A.PAT_STATUS_GR                                                                                                                      ");
//		sql.append("         , A.UPD_ID                                                                                                                             ");
//		sql.append("         , A.HOSP_CODE                                                                                                                          ");
//		sql.append("         , A.DEFAULT_JUSA                                                                                                                       ");
//		sql.append("         , B.SLIP_NAME                                                                                                                          ");
//		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_OUT, SYSDATE(), :f_hosp_code,:f_langauge)   JUNDAL_PART_OUT_NAME                                  ");
//		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_INP, SYSDATE(), :f_hosp_code,:f_langauge)   JUNDAL_PART_INP_NAME                                  ");
//		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.MOVE_PART, SYSDATE(), :f_hosp_code,:f_langauge)         MOVE_PART_NAME                                        ");
//		sql.append("         , E.JAERYO_NAME                                                                                                                        ");
//		sql.append("         , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', E.SUBUL_DANUI, :f_hosp_code,:f_langauge) SUBUL_DANUI_NAME                                       ");
//		sql.append("         , DATE_FORMAT(E.BULYONG_DATE, '%Y/%m/%d')  JEARYO_BULYONG_DATE                                                                         ");
//		sql.append("         , CASE WHEN A.ORDER_GUBUN IN ('C', 'D') THEN FN_DRG_LOAD_BOGYONG_NAME (A.DEFAULT_BOGYONG_CODE, :f_hosp_code )                          ");
//		sql.append("         WHEN A.ORDER_GUBUN IN ('B')      THEN FN_OCS_LOAD_CODE_NAME ('JUSA', A.DEFAULT_BOGYONG_CODE, :f_hosp_code,:f_langauge)                 ");
//		sql.append("         ELSE NULL                                                                                                                              ");
//		sql.append("         END DEFAULT_BOGYONG_NAME                                                                                                               ");
//		sql.append("         , A.IF_INPUT_CONTROL                                                                                                                   ");
//		sql.append("         , D.HUBAL_DRG_YN                                                                                                                       ");
//		sql.append("         , D.SG_NAME                                                                                                                            ");
//		sql.append("         , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', D.DANUI, :f_hosp_code,:f_langauge)      SG_DANUI_NAME                                           ");
//		sql.append("         , DATE_FORMAT(D.BULYONG_YMD, '%Y/%m/%d')                                                                                               ");
//		sql.append("         , A.RESULT_GUBUN                                                                                                                       ");
//		sql.append("         , A.WONNAE_DRG_YN                                                                                                                      ");
//		sql.append("         , COMMON_ORDER				                                                                                                            ");
//		sql.append("         , A.YAK_KIJUN_CODE                                                                                                                     ");
//		sql.append("         , A.YJ_CODE                                                                                                                            ");
//		sql.append("         , ''                                                                                                                                   ");
////		sql.append("         , G.IF_CODE                                                                                                                            ");
//		sql.append("         , A.TRIAL_FLG                                                                                                                          ");
//		sql.append("         , H.PROTOCOL_CODE                                                                                                                      ");
//		sql.append("         , A.DEFAULT_PORTABLE_YN    DEFAULT_PORTABLE_YN2                                                                                        ");
//		
////		sql.append(" FROM    ( SELECT * FROM OCS0103 O  WHERE O.HOSP_CODE        = :f_hosp_code                                                                     ");
////		sql.append("              AND O.SLIP_CODE        LIKE :f_aSlipCode AND O.HANGMOG_NAME_INX LIKE :f_aHangmogINX                        						");
////		sql.append("     AND NOT EXISTS (SELECT 'Y' FROM OCS0103S S  WHERE S.HANGMOG_CODE = O.HANGMOG_CODE AND S.GROUP_CODE = (SELECT GROUP_CODE FROM BAS0001       ");
////		sql.append("                      WHERE HOSP_CODE = :f_hosp_code AND START_DATE = (SELECT MAX(START_DATE) FROM BAS0001  WHERE HOSP_CODE = :f_hosp_code)))	");
////		sql.append("				  ORDER BY O.HANGMOG_CODE  ) A                        																	        ");
//				
//		sql.append(" FROM    (						   ");
//		sql.append("  SELECT  O.HOSP_CODE			   ");
//		sql.append("        , O.CLIS_PROTOCOL_ID	   ");
//		sql.append("        , O.SYS_DATE			   ");
//		sql.append("        , O.SYS_ID			       ");
//		sql.append("        , O.UPD_DATE			   ");
//		sql.append("        , O.HANGMOG_CODE		   ");
//		sql.append("        , O.HANGMOG_NAME		   ");
//		sql.append("		, O.SLIP_CODE              ");
//		sql.append("		, O.GROUP_YN               ");
//		sql.append("		, O.POSITION               ");
//		sql.append("		, O.SEQ                    ");
//		sql.append("		, O.ORDER_GUBUN            ");
//		sql.append("		, O.INPUT_CONTROL          ");
//		sql.append("		, O.JUNDAL_TABLE_OUT       ");
//		sql.append("		, O.JUNDAL_TABLE_INP       ");
//		sql.append("		, O.JUNDAL_PART_OUT        ");
//		sql.append("		, O.JUNDAL_PART_INP        ");
//		sql.append("		, O.MOVE_PART              ");
//		sql.append("		, O.DV_TIME                ");
//		sql.append("		, O.ORD_DANUI              ");
//		sql.append("		, O.DEFAULT_BOGYONG_CODE   ");
//		sql.append("		, O.SUGA_YN                ");
//		sql.append("		, O.SG_CODE                ");
//		sql.append("		, O.JAERYO_YN              ");
//		sql.append("		, O.JAERYO_CODE            ");
//		sql.append("		, O.HANGMOG_NAME_INX       ");
//		sql.append("		, O.DISPLAY_YN             ");
//		sql.append("		, O.START_DATE             ");
//		sql.append("		, O.END_DATE               ");
//		sql.append("		, O.SPECIMEN_YN            ");
//		sql.append("		, O.SPECIMEN_DEFAULT       ");
//		sql.append("		, O.DEFAULT_PORTABLE_YN    ");
//		sql.append("		, O.SPECIFIC_COMMENT       ");
//		sql.append("		, O.RESER_YN_OUT           ");
//		sql.append("		, O.RESER_YN_INP           ");
//		sql.append("		, O.EMERGENCY              ");
//		sql.append("		, O.LIMIT_SURYANG          ");
//		sql.append("		, O.BOM_YN                 ");
//		sql.append("		, O.RETURN_YN              ");
//		sql.append("		, O.SUBUL_CONVERT_GUBUN    ");
//		sql.append("		, O.WONYOI_ORDER_YN        ");
//		sql.append("		, O.DEFAULT_WONNAE_SAYU    ");
//		sql.append("		, O.ANTI_CANCER_YN         ");
//		sql.append("		, O.CHISIK_YN              ");
//		sql.append("		, O.NDAY_YN                ");
//		sql.append("		, O.MUHYO_YN               ");
//		sql.append("		, O.INV_JUNDAL_YN          ");
//		sql.append("		, O.POWDER_YN              ");
//		sql.append("		, O.REMARK                 ");
//		sql.append("		, O.DEFAULT_DV             ");
//		sql.append("		, O.DEFAULT_SURYANG        ");
//		sql.append("		, O.NURSE_INPUT_YN         ");
//		sql.append("		, O.SUPPLY_INPUT_YN        ");
//		sql.append("		, O.LIMIT_NALSU            ");
//		sql.append("		, O.DEFAULT_WONYOI_YN      ");
//		sql.append("		, O.PORTABLE_CHECK         ");
//		sql.append("		, O.PAT_STATUS_GR          ");
//		sql.append("		, O.UPD_ID                 ");
//		sql.append("		, O.DEFAULT_JUSA           ");
//		sql.append("		, O.IF_INPUT_CONTROL       ");
//		sql.append("		, O.RESULT_GUBUN           ");
//		sql.append("		, O.WONNAE_DRG_YN          ");
//		sql.append("		, 'N' AS COMMON_ORDER      ");
//		sql.append("		, O.YAK_KIJUN_CODE         ");
//		sql.append("		, O.YJ_CODE                ");
//		sql.append("		, O.TRIAL_FLG              ");
//		sql.append(" FROM OCS0103 O  																	");
//		sql.append(" LEFT JOIN OCS0103S S ON S.HANGMOG_CODE = O.HANGMOG_CODE							");
//		sql.append("                     AND S.GROUP_CODE = :f_group_code								");
//		sql.append(" WHERE O.HOSP_CODE = :f_hosp_code                                                	");
//		sql.append("   AND O.SLIP_CODE LIKE :f_aSlipCode 												");
//		sql.append("   AND O.HANGMOG_NAME_INX LIKE :f_aHangmogINX										");
//		sql.append("   AND S.ID IS NULL																	");
//		
//		sql.append(" UNION																				");
//		sql.append(" SELECT  :f_hosp_code																");
//		sql.append("		, S.CLIS_PROTOCOL_ID		");
//		sql.append("		, S.SYS_DATE				");
//		sql.append("		, S.SYS_ID    				");
//		sql.append("		, S.UPD_DATE  				");
//		sql.append("		, S.HANGMOG_CODE            ");
//		sql.append("		, S.HANGMOG_NAME            ");
//		sql.append("		, S.SLIP_CODE 				");
//		sql.append("		, S.GROUP_YN  				");
//		sql.append("		, S.POSITION  				");
//		sql.append("		, S.SEQ       				");
//		sql.append("		, S.ORDER_GUBUN             ");
//		sql.append("		, S.INPUT_CONTROL           ");
//		sql.append("		, S.JUNDAL_TABLE_OUT        ");
//		sql.append("		, S.JUNDAL_TABLE_INP        ");
//		sql.append("		, S.JUNDAL_PART_OUT         ");
//		sql.append("		, S.JUNDAL_PART_INP         ");
//		sql.append("		, S.MOVE_PART 				");
//		sql.append("		, S.DV_TIME   				");
//		sql.append("		, S.ORD_DANUI 				");
//		sql.append("		, S.DEFAULT_BOGYONG_CODE    ");
//		sql.append("		, S.SUGA_YN   				");
//		sql.append("		, S.SG_CODE   				");
//		sql.append("		, S.JAERYO_YN 				");
//		sql.append("		, S.JAERYO_CODE             ");
//		sql.append("		, S.HANGMOG_NAME_INX        ");
//		sql.append("		, S.DISPLAY_YN				");
//		sql.append("		, S.START_DATE				");
//		sql.append("		, S.END_DATE  				");
//		sql.append("		, S.SPECIMEN_YN             ");
//		sql.append("		, S.SPECIMEN_DEFAULT        ");
//		sql.append("		, S.DEFAULT_PORTABLE_YN		");
//		sql.append("		, S.SPECIFIC_COMMENT        ");
//		sql.append("		, S.RESER_YN_OUT            ");
//		sql.append("		, S.RESER_YN_INP            ");
//		sql.append("		, S.EMERGENCY 				");
//		sql.append("		, S.LIMIT_SURYANG           ");
//		sql.append("		, S.BOM_YN    				");
//		sql.append("		, S.RETURN_YN 				");
//		sql.append("		, S.SUBUL_CONVERT_GUBUN     ");
//		sql.append("		, S.WONYOI_ORDER_YN         ");
//		sql.append("		, S.DEFAULT_WONNAE_SAYU     ");
//		sql.append("		, S.ANTI_CANCER_YN          ");
//		sql.append("		, S.CHISIK_YN 				");
//		sql.append("		, S.NDAY_YN   				");
//		sql.append("		, S.MUHYO_YN  				");
//		sql.append("		, S.INV_JUNDAL_YN           ");
//		sql.append("		, S.POWDER_YN 				");
//		sql.append("		, S.REMARK    				");
//		sql.append("		, S.DEFAULT_DV				");
//		sql.append("		, S.DEFAULT_SURYANG         ");
//		sql.append("		, S.NURSE_INPUT_YN          ");
//		sql.append("		, S.SUPPLY_INPUT_YN         ");
//		sql.append("		, S.LIMIT_NALSU             ");
//		sql.append("		, S.DEFAULT_WONYOI_YN       ");
//		sql.append("		, S.PORTABLE_CHECK          ");
//		sql.append("		, S.PAT_STATUS_GR           ");
//		sql.append("		, S.UPD_ID     				");
//		sql.append("		, S.DEFAULT_JUSA            ");
//		sql.append("		, S.IF_INPUT_CONTROL 		");
//		sql.append("		, S.RESULT_GUBUN            ");
//		sql.append("		, S.WONNAE_DRG_YN           ");
//		sql.append("		, S.COMMON_YN AS COMMON_ORDER			");
//		sql.append("		, S.YAK_KIJUN_CODE           			");
//		sql.append("		, S.YJ_CODE   							");
//		sql.append("		, S.TRIAL_FLG 							");
//		sql.append(" FROM OCS0103S S								");
//		sql.append(" WHERE S.COMMON_YN = 'Y'						");
//		sql.append("   AND S.GROUP_CODE = :f_group_code				");
//		sql.append("   AND S.SLIP_CODE LIKE :f_aSlipCode 			");
//		sql.append("   AND S.HANGMOG_NAME_INX LIKE :f_aHangmogINX	");
//		sql.append(" ORDER BY HANGMOG_CODE							");
//		sql.append(" ) A											");
//		
//		sql.append("              LEFT JOIN  CLIS_PROTOCOL H ON A.HOSP_CODE = H.HOSP_CODE AND A.CLIS_PROTOCOL_ID = H.CLIS_PROTOCOL_ID                               ");
//		sql.append("              INNER JOIN  OCS0102 B ON B.HOSP_CODE = A.HOSP_CODE AND B.SLIP_CODE = A.SLIP_CODE                                                  ");
//		sql.append("              INNER JOIN OCS0101 C ON  C.SLIP_GUBUN = B.SLIP_GUBUN AND C.SLIP_GUBUN  LIKE :f_aSlipGubun                                         ");
//		sql.append("              LEFT JOIN ( SELECT  X.SG_CODE                                                                                                     ");
//		sql.append("                 , X.SG_UNION                                                                                                                   ");
//		sql.append("                 , X.SG_NAME                                                                                                                    ");
//		sql.append("                 , X.BULYONG_YMD                                                                                                                ");
//		sql.append("                 , X.DANUI                                                                                                                      ");
//		sql.append("                 , X.HUBAL_DRG_YN                                                                                                               ");
//		sql.append("                 , X.HOSP_CODE                                                                                                                  ");
//		sql.append("           FROM BAS0310 X                                                                                                                       ");
//		sql.append("          WHERE X.HOSP_CODE = :f_hosp_code                                                                                                      ");
//		sql.append("            AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                               ");
//		sql.append("                               FROM BAS0310 Z                                                                                                   ");
//		sql.append("                              WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                                   ");
//		sql.append("                                AND Z.SG_CODE = X.SG_CODE                                                                                       ");
//		sql.append("                                AND Z.SG_YMD <= SYSDATE() )                                                                                     ");
//		sql.append("          ) D ON D.HOSP_CODE = A.HOSP_CODE AND D.SG_CODE = A.SG_CODE                                                                            ");
//		sql.append("          LEFT JOIN INV0110 E ON E.HOSP_CODE = A.HOSP_CODE AND E.JAERYO_CODE = A.JAERYO_CODE                                                    ");
//		sql.append("          LEFT JOIN CNV0006 F ON F.SG_CODE = D.SG_CODE                                                                                          ");
////		sql.append("          LEFT JOIN ( SELECT A.IF_CODE                                                                                                          ");
////		sql.append("                  , A.OCS_CODE                                                                                                                  ");
////		sql.append("                  , A.HOSP_CODE                                                                                                                 ");
////		sql.append("               FROM IFS0003 A                                                                                                                   ");
////		sql.append("              WHERE A.HOSP_CODE      = :f_hosp_code                                                                                             ");
////		sql.append("                AND A.MAP_GUBUN      IN ( 'IF_SKR_HANGMOG_JAE', 'IF_SKR_HANGMOG', 'IF_SKR_HANGMOG_DRG')                                         ");
////		sql.append("                AND A.MAP_GUBUN_YMD  = ( SELECT MAX(Z.MAP_GUBUN_YMD)                                                                            ");
////		sql.append("                                           FROM IFS0003 Z                                                                                       ");
////		sql.append("                                          WHERE Z.HOSP_CODE    = A.HOSP_CODE                                                                    ");
////		sql.append("                                            AND Z.MAP_GUBUN    = A.MAP_GUBUN                                                                    ");
////		sql.append("                                            AND Z.OCS_CODE     = A.OCS_CODE                                                                     ");
////		sql.append("                                            AND (   Z.MAP_GUBUN_YMD  < STR_TO_DATE('9998/12/31', '%Y/%m/%d')                                    ");
////		sql.append("                                                 OR Z.MAP_GUBUN_YMD  = STR_TO_DATE(SYSDATE(), '%Y/%m/%d')                                       ");
////		sql.append("                                                )                                                                                               ");
////		sql.append("                                            AND Z.IF_CODE      = A.IF_CODE                                                                      ");
////		sql.append("                                       )                                                                                                        ");
////		sql.append("           ) G ON G.HOSP_CODE = A.HOSP_CODE AND G.OCS_CODE = A.HANGMOG_CODE                                                                     ");
//		sql.append(" WHERE                                                                                                                                          ");
//		sql.append("    (                                                                                                                                           ");
//		sql.append("           ( :f_used_yn = '%' )                                                                                                                 ");
//		sql.append("           OR                                                                                                                                   ");
//		sql.append("           ( :f_used_yn = '1'                                                                                                                   ");
//		sql.append("           AND F.SG_CODE IS NOT NULL )                                                                                                          ");
//		sql.append("           OR                                                                                                                                   ");
//		sql.append("           ( :f_used_yn = '2'                                                                                                                   ");
//		sql.append("           AND F.SG_CODE IS NULL )                                                                                                              ");
//		sql.append("           )                                                                                                                                    ");
//		sql.append("           AND (                                                                                                                                ");
//		sql.append("           ( :f_wonnae_yn = '%' )                                                                                                               ");
//		sql.append("           OR                                                                                                                                   ");
//		sql.append("           ( :f_wonnae_yn = '1'                                                                                                                 ");
//		sql.append("           AND IFNULL(A.WONNAE_DRG_YN, 'N') = 'Y' )                                                                                             ");
//		sql.append("           OR                                                                                                                                   ");
//		sql.append("           ( :f_wonnae_yn = '2'                                                                                                                 ");
//		sql.append("           AND IFNULL(A.WONNAE_DRG_YN, 'N') != 'Y' )                                                                                            ");
//		sql.append("       )																																		");
		
	
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT    A.SYS_DATE                                                                                                                           ");
		sql.append("         , A.SYS_ID                                                                                                                             ");
		sql.append("         , A.UPD_DATE                                                                                                                           ");
		sql.append("         , A.HANGMOG_CODE                                                                                                                       ");
		sql.append("         , A.HANGMOG_NAME                                                                                                                       ");
		sql.append("         , A.SLIP_CODE                                                                                                                          ");
		sql.append("         , A.GROUP_YN                                                                                                                           ");
		sql.append("         , A.POSITION                                                                                                                           ");
		sql.append("         , A.SEQ                                                                                                                                ");
		sql.append("         , A.ORDER_GUBUN                                                                                                                        ");
		sql.append("         , A.INPUT_CONTROL                                                                                                                      ");
		sql.append("         , A.JUNDAL_TABLE_OUT                                                                                                                   ");
		sql.append("         , A.JUNDAL_TABLE_INP                                                                                                                   ");
		sql.append("         , A.JUNDAL_PART_OUT                                                                                                                    ");
		sql.append("         , A.JUNDAL_PART_INP                                                                                                                    ");
		sql.append("         , A.MOVE_PART                                                                                                                          ");
		sql.append("         , A.DV_TIME                                                                                                                            ");
		sql.append("         , A.ORD_DANUI                                                                                                                          ");
		sql.append("         , A.DEFAULT_BOGYONG_CODE                                                                                                               ");
		sql.append("         , A.SUGA_YN                                                                                                                            ");
		sql.append("         , A.SG_CODE                                                                                                                            ");
		sql.append("         , A.JAERYO_YN                                                                                                                          ");
		sql.append("         , A.JAERYO_CODE                                                                                                                        ");
		sql.append("         , A.HANGMOG_NAME_INX                                                                                                                   ");
		sql.append("         , A.DISPLAY_YN                                                                                                                         ");
		sql.append("         , A.START_DATE                                                                                                                         ");
		sql.append("         , A.END_DATE                                                                                                                           ");
		sql.append("         , A.SPECIMEN_YN                                                                                                                        ");
		sql.append("         , A.SPECIMEN_DEFAULT                                                                                                                   ");
		sql.append("         , A.DEFAULT_PORTABLE_YN        DEFAULT_PORTABLE_YN1                                                                                    ");
		sql.append("         , A.SPECIFIC_COMMENT                                                                                                                   ");
		sql.append("         , A.RESER_YN_OUT                                                                                                                       ");
		sql.append("         , A.RESER_YN_INP                                                                                                                       ");
		sql.append("         , A.EMERGENCY                                                                                                                          ");
		sql.append("         , A.LIMIT_SURYANG                                                                                                                      ");
		sql.append("         , A.BOM_YN                                                                                                                             ");
		sql.append("         , A.RETURN_YN                                                                                                                          ");
		sql.append("         , A.SUBUL_CONVERT_GUBUN                                                                                                                ");
		sql.append("         , A.WONYOI_ORDER_YN                                                                                                                    ");
		sql.append("         , A.DEFAULT_WONNAE_SAYU                                                                                                                ");
		sql.append("         , A.ANTI_CANCER_YN                                                                                                                     ");
		sql.append("         , A.CHISIK_YN                                                                                                                          ");
		sql.append("         , A.NDAY_YN                                                                                                                            ");
		sql.append("         , A.MUHYO_YN                                                                                                                           ");
		sql.append("         , A.INV_JUNDAL_YN                                                                                                                      ");
		sql.append("         , A.POWDER_YN                                                                                                                          ");
		sql.append("         , A.REMARK                                                                                                                             ");
		sql.append("         , A.DEFAULT_DV                                                                                                                         ");
		sql.append("         , A.DEFAULT_SURYANG                                                                                                                    ");
		sql.append("         , A.NURSE_INPUT_YN                                                                                                                     ");
		sql.append("         , A.SUPPLY_INPUT_YN                                                                                                                    ");
		sql.append("         , A.LIMIT_NALSU                                                                                                                        ");
		sql.append("         , A.DEFAULT_WONYOI_YN                                                                                                                  ");
		sql.append("         , A.PORTABLE_CHECK                                                                                                                     ");
		sql.append("         , A.PAT_STATUS_GR                                                                                                                      ");
		sql.append("         , A.UPD_ID                                                                                                                             ");
		sql.append("         , A.HOSP_CODE                                                                                                                          ");
		sql.append("         , A.DEFAULT_JUSA                                                                                                                       ");
		sql.append("         , B.SLIP_NAME                                                                                                                          ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_OUT, SYSDATE(), :f_hosp_code,:f_langauge)   JUNDAL_PART_OUT_NAME                                  ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_INP, SYSDATE(), :f_hosp_code,:f_langauge)   JUNDAL_PART_INP_NAME                                  ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME(A.MOVE_PART, SYSDATE(), :f_hosp_code,:f_langauge)         MOVE_PART_NAME                                        ");
		sql.append("         , E.JAERYO_NAME                                                                                                                        ");
		sql.append("         , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', E.SUBUL_DANUI, :f_hosp_code,:f_langauge) SUBUL_DANUI_NAME                                       ");
		sql.append("         , DATE_FORMAT(E.BULYONG_DATE, '%Y/%m/%d')  JEARYO_BULYONG_DATE                                                                         ");
		sql.append("         , CASE WHEN A.ORDER_GUBUN IN ('C', 'D') THEN FN_DRG_LOAD_BOGYONG_NAME (A.DEFAULT_BOGYONG_CODE, :f_hosp_code )                          ");
		sql.append("         WHEN A.ORDER_GUBUN IN ('B')      THEN FN_OCS_LOAD_CODE_NAME ('JUSA', A.DEFAULT_BOGYONG_CODE, :f_hosp_code,:f_langauge)                 ");
		sql.append("         ELSE NULL                                                                                                                              ");
		sql.append("         END DEFAULT_BOGYONG_NAME                                                                                                               ");
		sql.append("         , A.IF_INPUT_CONTROL                                                                                                                   ");
		sql.append("         , D.HUBAL_DRG_YN                                                                                                                       ");
		sql.append("         , D.SG_NAME                                                                                                                            ");
		sql.append("         , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', D.DANUI, :f_hosp_code,:f_langauge)      SG_DANUI_NAME                                           ");
		sql.append("         , DATE_FORMAT(D.BULYONG_YMD, '%Y/%m/%d')                                                                                               ");
		sql.append("         , A.RESULT_GUBUN                                                                                                                       ");
		sql.append("         , A.WONNAE_DRG_YN                                                                                                                      ");
		sql.append("         , IFNULL(A.COMMON_YN, 'N')   COMMON_ORDER                                                                                                                   ");
		sql.append("         , A.YAK_KIJUN_CODE                                                                                                                     ");
		sql.append("         , A.YJ_CODE                                                                                                                            ");
		sql.append("         , G.IF_CODE                                                                                                                            ");
		sql.append("         , A.TRIAL_FLG                                                                                                                          ");
		sql.append("         , H.PROTOCOL_CODE                                                                                                                      ");
		sql.append("         , A.DEFAULT_PORTABLE_YN    DEFAULT_PORTABLE_YN2                                                                                        ");
		sql.append(" FROM    ( select * from OCS0103  where HOSP_CODE        = :f_hosp_code                                                                         ");
		sql.append(" AND SYSDATE() BETWEEN START_DATE AND IFNULL(END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))                                                   ");
		sql.append("              AND SLIP_CODE        LIKE :f_aSlipCode AND HANGMOG_NAME_INX LIKE :f_aHangmogINX ORDER BY HANGMOG_CODE  ) A                        ");
		sql.append("              LEFT JOIN  CLIS_PROTOCOL H ON A.HOSP_CODE = H.HOSP_CODE AND A.CLIS_PROTOCOL_ID = H.CLIS_PROTOCOL_ID                               ");
		sql.append("              INNER JOIN  OCS0102 B ON B.HOSP_CODE = A.HOSP_CODE AND B.SLIP_CODE = A.SLIP_CODE                                                  ");
		sql.append("              INNER JOIN OCS0101 C ON  C.SLIP_GUBUN = B.SLIP_GUBUN AND C.SLIP_GUBUN  LIKE :f_aSlipGubun AND C.LANGUAGE = B.LANGUAGE AND C.LANGUAGE = :f_langauge            ");
		sql.append("              LEFT JOIN ( SELECT  X.SG_CODE                                                                                                     ");
		sql.append("                 , X.SG_UNION                                                                                                                   ");
		sql.append("                 , X.SG_NAME                                                                                                                    ");
		sql.append("                 , X.BULYONG_YMD                                                                                                                ");
		sql.append("                 , X.DANUI                                                                                                                      ");
		sql.append("                 , X.HUBAL_DRG_YN                                                                                                               ");
		sql.append("                 , X.HOSP_CODE                                                                                                                  ");
		sql.append("           FROM BAS0310 X                                                                                                                       ");
		sql.append("          WHERE X.HOSP_CODE = :f_hosp_code                                                                                                      ");
		sql.append("            AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                               ");
		sql.append("                               FROM BAS0310 Z                                                                                                   ");
		sql.append("                              WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                                   ");
		sql.append("                                AND Z.SG_CODE = X.SG_CODE                                                                                       ");
		sql.append("                                AND Z.SG_YMD <= SYSDATE() )                                                                                     ");
		sql.append("          ) D ON D.HOSP_CODE = A.HOSP_CODE AND D.SG_CODE = A.SG_CODE                                                                            ");
		sql.append("          LEFT JOIN INV0110 E ON E.HOSP_CODE = A.HOSP_CODE AND E.JAERYO_CODE = A.JAERYO_CODE                                                    ");
		sql.append("          LEFT JOIN CNV0006 F ON F.SG_CODE = D.SG_CODE                                                                                          ");
		sql.append("          LEFT JOIN ( SELECT A.IF_CODE                                                                                                          ");
		sql.append("                  , A.OCS_CODE                                                                                                                  ");
		sql.append("                  , A.HOSP_CODE                                                                                                                 ");
		sql.append("               FROM IFS0003 A                                                                                                                   ");
		sql.append("              WHERE A.HOSP_CODE      = :f_hosp_code                                                                                             ");
		sql.append("                AND A.MAP_GUBUN      IN ( 'IF_SKR_HANGMOG_JAE', 'IF_SKR_HANGMOG', 'IF_SKR_HANGMOG_DRG')                                         ");
		sql.append("                AND A.MAP_GUBUN_YMD  = ( SELECT MAX(Z.MAP_GUBUN_YMD)                                                                            ");
		sql.append("                                           FROM IFS0003 Z                                                                                       ");
		sql.append("                                          WHERE Z.HOSP_CODE    = A.HOSP_CODE                                                                    ");
		sql.append("                                            AND Z.MAP_GUBUN    = A.MAP_GUBUN                                                                    ");
		sql.append("                                            AND Z.OCS_CODE     = A.OCS_CODE                                                                     ");
		sql.append("                                            AND (   Z.MAP_GUBUN_YMD  < STR_TO_DATE('9998/12/31', '%Y/%m/%d')                                    ");
		sql.append("                                                 OR Z.MAP_GUBUN_YMD  = STR_TO_DATE(SYSDATE(), '%Y/%m/%d')                                       ");
		sql.append("                                                )                                                                                               ");
		sql.append("                                            AND Z.IF_CODE      = A.IF_CODE                                                                      ");
		sql.append("                                       )                                                                                                        ");
		sql.append("           ) G ON G.HOSP_CODE = A.HOSP_CODE AND G.OCS_CODE = A.HANGMOG_CODE                                                                     ");
		sql.append(" WHERE                                                                                                                                          ");
		sql.append("    (                                                                                                                                           ");
		sql.append("           ( :f_used_yn = '%' )                                                                                                                 ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_used_yn = '1'                                                                                                                   ");
		sql.append("           AND F.SG_CODE IS NOT NULL )                                                                                                          ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_used_yn = '2'                                                                                                                   ");
		sql.append("           AND F.SG_CODE IS NULL )                                                                                                              ");
		sql.append("           )                                                                                                                                    ");
		sql.append("           AND (                                                                                                                                ");
		sql.append("           ( :f_wonnae_yn = '%' )                                                                                                               ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_wonnae_yn = '1'                                                                                                                 ");
		sql.append("           AND IFNULL(A.WONNAE_DRG_YN, 'N') = 'Y' )                                                                                             ");
		sql.append("           OR                                                                                                                                   ");
		sql.append("           ( :f_wonnae_yn = '2'                                                                                                                 ");
		sql.append("           AND IFNULL(A.WONNAE_DRG_YN, 'N') != 'Y' )                                                                                            ");
		sql.append("       )                                                                                                                                        ");
		
		sql.append("  limit :startNum, :offset                                                                 														");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);  
		query.setParameter("f_langauge", language);
		query.setParameter("f_aSlipCode", aSlipCode);
		query.setParameter("f_aHangmogINX", aHangMogInx);
		query.setParameter("f_aSlipGubun", aSlipGubun);
		query.setParameter("f_used_yn", usedYn);
		query.setParameter("f_wonnae_yn", wonaeYn);
	//	query.setParameter("f_group_code", groupCode);
		query.setParameter("startNum", startNumber);
		query.setParameter("offset", offset);
		
		List<OCS0103U00GrdOCS0103Info> list = new JpaResultMapper().list(query, OCS0103U00GrdOCS0103Info.class);
		return list;
	}

	@Override
	public List<Ifs0003U00GrdIFS0003Info> getIfs0003U00GrdIFS0003ListItem(
			String hospCode, String mapGubun, String mapGubunYn, String code,String acctType, boolean isIfCode, Integer pageNumber, Integer offset) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT   A.MAP_GUBUN																								");
		sql.append("	       , A.MAP_GUBUN_YMD                                                                                            ");
		sql.append("	       , A.OCS_CODE                                                                                                 ");
		sql.append("	       , A.HOSP_CODE    AS OCS_CODE_NAME                     									                    ");
		sql.append("	       , A.OCS_DEFAULT_YN                                                                                           ");
		sql.append("	       , A.IF_CODE                                                                                                  ");
		sql.append("	       , PKG_IFS_BAS_FN_LOAD_IF_CODE_NAME(A.HOSP_CODE, A.MAP_GUBUN, A.IF_CODE)      AS IF_CODE_NAME                 ");
		sql.append("	       , A.IF_DEFAULT_YN                                                                                            ");
		sql.append("	       , A.REMARK                                                                                                   ");
		sql.append("	  FROM IFS0003 A                                                                                                    ");
		sql.append("	 WHERE A.HOSP_CODE        = :f_hosp_code                                                                            ");
		sql.append("	   AND A.MAP_GUBUN        = :f_map_gubun                                                                            ");
		sql.append("	   AND A.MAP_GUBUN_YMD  = ( SELECT MAX(Z.MAP_GUBUN_YMD)                                                             ");
		sql.append("	                              FROM IFS0003 Z                                                                        ");
		sql.append("	                             WHERE Z.HOSP_CODE                = A.HOSP_CODE                                         ");
		sql.append("	                               AND Z.MAP_GUBUN          = A.MAP_GUBUN                                               ");
		sql.append("	                               AND Z.OCS_CODE                = A.OCS_CODE                                           ");
		sql.append("	                               AND (Z.MAP_GUBUN_YMD        < STR_TO_DATE(:f_map_gubun_ymd, '%Y/%m/%d')              ");
		sql.append("	                                OR Z.MAP_GUBUN_YMD        = STR_TO_DATE(:f_map_gubun_ymd, '%Y/%m/%d') )             ");
		if(isIfCode){
			sql.append("	                               AND Z.IF_CODE            = A.IF_CODE                                             ");
		}
		sql.append("	                          )                                                                                         ");
		sql.append("	  AND A.ACCT_TYPE = :acctType                                                                                       ");
		if(isIfCode){
			sql.append("	   AND (A.IF_CODE LIKE :f_code OR A.OCS_CODE LIKE :f_code)                                                      ");
		}
		sql.append("	 ORDER BY A.HOSP_CODE, A.MAP_GUBUN, A.OCS_CODE                                                                      ");
		if(pageNumber != null && offset != null){
			sql.append(" LIMIT :f_page_number,:f_offset 																				 		");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);  
		query.setParameter("f_map_gubun", mapGubun);
		if(isIfCode){
			query.setParameter("f_code", code);
		}
		query.setParameter("f_map_gubun_ymd", mapGubunYn);
		query.setParameter("acctType", acctType);
		if(pageNumber != null && offset != null){
			query.setParameter("f_page_number",pageNumber);
			query.setParameter("f_offset", offset);
		}
	
		List<Ifs0003U00GrdIFS0003Info> list = new JpaResultMapper().list(query, Ifs0003U00GrdIFS0003Info.class);
		return list;
		
	}
	
	@Override
	public boolean isExistedIfs0003(String hospCode, String mapGobun, String ocsCode, String ifCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'  									");
		sql.append("	FROM IFS0003 A                         	 	    ");
		sql.append("	WHERE A.HOSP_CODE     = :f_hosp_code   		    ");
		sql.append("	AND A.MAP_GUBUN     = :f_map_gubun              ");
		sql.append("	AND A.OCS_CODE = :f_ocs_code        		    ");
		sql.append("	AND A.IF_CODE = :f_if_code        		        ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_map_gubun", mapGobun);
		query.setParameter("f_ocs_code", ocsCode);
		query.setParameter("f_if_code", ifCode);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}
	@Override
	public List<ComboListItemInfo> getIfCodeAndOcsCode(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.OCS_CODE                                                                                              ");         
		sql.append("                   , A.IF_CODE                                                                                  ");                               
		sql.append("                FROM IFS0003 A                                                                                  ");                               
		sql.append("               WHERE A.HOSP_CODE      = :f_hosp_code                                                            ");                               
		sql.append("                 AND A.MAP_GUBUN      IN ( 'IF_SKR_HANGMOG_JAE', 'IF_SKR_HANGMOG', 'IF_SKR_HANGMOG_DRG')        ");                               
		sql.append("                 AND A.MAP_GUBUN_YMD  = ( SELECT MAX(Z.MAP_GUBUN_YMD)                                           ");                               
		sql.append("                                            FROM IFS0003 Z                                                      ");                               
		sql.append("                                           WHERE Z.HOSP_CODE    = A.HOSP_CODE                                   ");                               
		sql.append("                                             AND Z.MAP_GUBUN    = A.MAP_GUBUN                                   ");                               
		sql.append("                                             AND Z.OCS_CODE     = A.OCS_CODE                                    ");                               
		sql.append("                                             AND (   Z.MAP_GUBUN_YMD  < STR_TO_DATE('9998/12/31', '%Y/%m/%d')   ");                               
		sql.append("                                                  OR Z.MAP_GUBUN_YMD  = STR_TO_DATE(SYSDATE(), '%Y/%m/%d')      ");                               
		sql.append("                                                 )                                                              ");                               
		sql.append("                                             AND Z.IF_CODE      = A.IF_CODE                                     ");                               
		sql.append("                                        ) 																		");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	
	@Override
	public boolean getCommonMapped(String hangmogCode, String hospCode, boolean requiredOcs0103Existed) {
		StringBuilder sqlQuery = new StringBuilder();
		sqlQuery.append(" SELECT 'Y'																															");
		sqlQuery.append(" FROM   BAS0001 a                                                                                                                     ");
		sqlQuery.append(" WHERE  a.HOSP_CODE = :f_hosp_code AND NOT EXISTS                                                                                     ");
		sqlQuery.append("          (                            SELECT 'Y'                                                                                     ");
		sqlQuery.append("                                       FROM   BAS0102 a                                                                               ");
		sqlQuery.append("                                       WHERE  a.CODE_TYPE = 'ACCT_TYPE' AND a.HOSP_CODE = :f_hosp_code)                               ");
		sqlQuery.append(" UNION                                                                                                                                ");
		sqlQuery.append(" SELECT 'Y'                                                                                                                           ");
		sqlQuery.append(" FROM   BAS0102 a                                                                                                                     ");
		sqlQuery.append(" WHERE  a.CODE_TYPE = 'ACCT_TYPE' AND a.CODE = :misa AND a.HOSP_CODE = :f_hosp_code                                                   ");
		sqlQuery.append(" UNION                                                                                                                                ");
		sqlQuery.append(" SELECT 'Y'                                                                                                                           ");
		sqlQuery.append(" FROM   IFS0003                                                                                                                       ");
		sqlQuery.append(" WHERE  HOSP_CODE = :f_hosp_code AND MAP_GUBUN = 'IF_ORCA_HANGMOG' AND MAP_GUBUN_YMD <= CURRENT_DATE AND OCS_CODE = :f_hangmog_code   ");
		if(requiredOcs0103Existed) {
			sqlQuery.append("        AND EXISTS                                                                                                                    ");
			sqlQuery.append("          ( SELECT 'Y'                                                                                                                ");
			sqlQuery.append("            FROM   OCS0103                                                                                                            ");
			sqlQuery.append("            WHERE  HOSP_CODE = :f_hosp_code AND HANGMOG_CODE = :f_hangmog_code AND START_DATE <= CURRENT_DATE AND (END_DATE IS NULL OR CURRENT_DATE <= END_DATE)) ");
		}
		sqlQuery.append("        AND EXISTS   (				                                                 SELECT 'Y'                                        ");
		sqlQuery.append("                                                                                    FROM   BAS0102 a                                  ");
		sqlQuery.append("                                                                                    WHERE  a.CODE_TYPE = 'ACCT_TYPE' AND a.CODE = :orca ");
		sqlQuery.append("        AND a.HOSP_CODE = :f_hosp_code)																								");
		
		Query query = entityManager.createNativeQuery(sqlQuery.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("orca", AccountingConfig.ACCCT_TYPE_ORCA.getValue());
		query.setParameter("misa", AccountingConfig.ACCT_TYPE_MISA.getValue());
		List<String> result = query.getResultList();
		return result.size() > 0;
	}
		
}

