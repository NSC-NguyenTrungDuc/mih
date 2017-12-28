package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0303RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0301Q09GrdOCS0303Info;
import nta.med.data.model.ihis.ocsa.OCS0301U00LayoutInfo;
import nta.med.data.model.ihis.ocsa.OCS0307U00GrdListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Ocs0303RepositoryImpl implements Ocs0303RepositoryCustom {
private static final Log LOG = LogFactory.getLog(Ocs0303RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS0301U00LayoutInfo> getOCS0301U00LayoutInfo(String hospitalCode, String language, String memb, Double fkocs0300Seq, String yaksokCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.FKOCS0300_SEQ                                   IN_OUT_KEY                                                                                          ");
		sql.append("    , A.PKOCS0303                                        PKOCSKEY                                                                                            ");
		sql.append("    , ''                                                 BUNHO                                                                                               ");
		sql.append("    , ''                                                 ORDER_DATE                                                                                          ");
		sql.append("    , ''                                                 GWA                                                                                                 ");
		sql.append("    , ''                                                 DOCTOR                                                                                              ");
		sql.append("    , ''                                                 RESIDENT                                                                                            ");
		sql.append("    , ''                                                 NAEWON_TYPE                                                                                         ");
		sql.append("    , ''                                                 JUBSU_NO                                                                                            ");
		sql.append("    , ''                                                 INPUT_ID                                                                                            ");
		sql.append("    , ''                                                 INPUT_PART                                                                                          ");
		sql.append("    , ''                                                 INPUT_GWA                                                                                           ");
		sql.append("    , ''                                                 INPUT_DOCTOR                                                                                        ");
		sql.append("    , 'D0'                                                 INPUT_GUBUN                                                                                       ");
		sql.append("    , FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN', 'D0', :hospitalCode, :language) INPUT_GUBUN_NAME                                                                  ");
		sql.append("    , A.GROUP_SER                                          GROUP_SER                                                                                         ");
		sql.append("    , A.INPUT_TAB                                          INPUT_TAB                                                                                         ");
		sql.append("    , FN_OCS_LOAD_CODE_NAME('INPUT_TAB', A.INPUT_TAB, :hospitalCode, :language) INPUT_TAB_NAME                                                               ");
		sql.append("    , A.ORDER_GUBUN                                        ORDER_GUBUN                                                                                       ");
		sql.append("    , FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN', A.ORDER_GUBUN, :hospitalCode, :language) ORDER_GUBUN_NAME                                                         ");
		sql.append("    , B.GROUP_YN                                           GROUP_YN                                                                                          ");
		sql.append("    , A.SEQ                                                SEQ                                                                                               ");
		sql.append("    , B.SLIP_CODE                                          SLIP_CODE                                                                                         ");
		sql.append("    , A.HANGMOG_CODE                                       HANGMOG_CODE                                                                                      ");
		sql.append("    , IF(A.GENERAL_DISP_YN= 'Y', I.GENERIC_NAME, B.HANGMOG_NAME)       HANGMOG_NAME                                                                          ");
		sql.append("    , A.SPECIMEN_CODE                                      SPECIMEN_CODE                                                                                     ");
		sql.append("    , C.SPECIMEN_NAME                                      SPECIMEN_NAME                                                                                     ");
		sql.append("    , A.SURYANG                                            SURYANG                                                                                           ");
		sql.append("    , A.SURYANG                                            SUNAB_SURYANG                                                                                     ");
		sql.append("    , A.SURYANG                                            SUBUL_SURYANG                                                                                     ");
		sql.append("    , A.ORD_DANUI                                          ORD_DANUI                                                                                         ");
		sql.append("    , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :hospitalCode, :language) ORD_DANUI_NAME                                                               ");
		sql.append("    , A.DV_TIME                                            DV_TIME                                                                                           ");
		sql.append("    , A.DV                                                 DV                                                                                                ");
		sql.append("    , A.DV_1                                               DV_1                                                                                              ");
		sql.append("    , A.DV_2                                               DV_2                                                                                              ");
		sql.append("    , A.DV_3                                               DV_3                                                                                              ");
		sql.append("    , A.DV_4                                               DV_4                                                                                              ");
		sql.append("    , A.NALSU                                              NALSU                                                                                             ");
		sql.append("    , ''                                                SUNAB_NALSU                                                                                          ");
		sql.append("    , A.JUSA                                               JUSA                                                                                              ");
		sql.append("    , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA, :hospitalCode, :language) JUSA_NAME                                                                              ");
		sql.append("    , A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN                                                                                    ");
		sql.append("    , A.BOGYONG_CODE                                       BOGYONG_CODE                                                                                      ");
		sql.append("    ,IF(B.INPUT_CONTROL = 'A',FN_CHT_LOAD_CHT0117_NAME(A.BOGYONG_CODE, :hospitalCode, :language),FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE, :hospitalCode)) BOGYONG_NAM   ");
		sql.append("    , A.EMERGENCY                                          EMERGENCY                                                                                         ");
		sql.append("    , ''                                                 JAERYO_JUNDAL_YN                                                                                    ");
		sql.append("    , ''                                                 JUNDAL_TABLE                                                                                        ");
		sql.append("    , ''                                                 JUNDAL_PART                                                                                         ");
		sql.append("    , ''                                                 MOVE_PART                                                                                           ");
		sql.append("    , ''                                                 PORTABLE_YN                                                                                         ");
		sql.append("    , ''                                                 POWDER_YN                                                                                           ");
		sql.append("    , A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN                                                                                   ");
		sql.append("    , A.PHARMACY                                           PHARMACY                                                                                          ");
		sql.append("    , A.DRG_PACK_YN                                        DRG_PACK_YN                                                                                       ");
		sql.append("    , A.MUHYO                                              MUHYO                                                                                             ");
		sql.append("    , ''                                                 PRN_YN                                                                                              ");
		sql.append("    , ''                                                 TOIWON_DRG_YN                                                                                       ");
		sql.append("    , ''                                                 PRN_NURSE                                                                                           ");
		sql.append("    , ''                                                 APPEND_YN                                                                                           ");
		sql.append("    , A.ORDER_REMARK                                       ORDER_REMARK                                                                                      ");
		sql.append("    , A.NURSE_REMARK                                       NURSE_REMARK                                                                                      ");
		sql.append("    , ''                                                 COMMENTS                                                                                            ");
		sql.append("    , A.MIX_GROUP                                          MIX_GROUP                                                                                         ");
		sql.append("    , A.AMT                                                AMT                                                                                               ");
		sql.append("    , A.PAY                                                PAY                                                                                               ");
		sql.append("    , A.WONYOI_ORDER_YN                                    WONYOI_ORDER_YN                                                                                   ");
		sql.append("    , A.DANGIL_GUMSA_ORDER_YN                              DANGIL_GUMSA_ORDER_YN                                                                             ");
		sql.append("    , A.DANGIL_GUMSA_RESULT_YN                             DANGIL_GUMSA_RESULT_YN                                                                            ");
		sql.append("    , ''                                                 BOM_OCCUR_YN                                                                                        ");
		sql.append("    , A.BOM_SOURCE_KEY                                     BOM_SOURCE_KEY                                                                                    ");
		sql.append("    , ''                                                 DISPLAY_YN                                                                                          ");
		sql.append("    , 'N'                                                  SUNAB_YN                                                                                          ");
		sql.append("    , ''                                                 SUNAB_DATE                                                                                          ");
		sql.append("    , ''                                                 SUNAB_TIME                                                                                          ");
		sql.append("    , ''                                                 HOPE_DATE                                                                                           ");
		sql.append("    , ''                                                 HOPE_TIME                                                                                           ");
		sql.append("    , ''                                                 NURSE_CONFIRM_USER                                                                                  ");
		sql.append("    , ''                                                 NURSE_CONFIRM_DATE                                                                                  ");
		sql.append("    , ''                                                 NURSE_CONFIRM_TIME                                                                                  ");
		sql.append("    , ''                                                 NURSE_PICKUP_USER                                                                                   ");
		sql.append("    , ''                                                 NURSE_PICKUP_DATE                                                                                   ");
		sql.append("    , ''                                                 NURSE_PICKUP_TIME                                                                                   ");
		sql.append("    , ''                                                 NURSE_HOLD_USER                                                                                     ");
		sql.append("    , ''                                                 NURSE_HOLD_DATE                                                                                     ");
		sql.append("    , ''                                                 NURSE_HOLD_TIME                                                                                     ");
		sql.append("    , ''                                                 RESER_DATE                                                                                          ");
		sql.append("    , ''                                                 RESER_TIME                                                                                          ");
		sql.append("    , ''                                                 JUBSU_DATE                                                                                          ");
		sql.append("    , ''                                                 JUBSU_TIME                                                                                          ");
		sql.append("    , ''                                                 ACTING_DATE                                                                                         ");
		sql.append("    , ''                                                 ACTING_TIME                                                                                         ");
		sql.append("    , ''                                                 ACTING_DAY                                                                                          ");
		sql.append("    , ''                                                 RESULT_DATE                                                                                         ");
		sql.append("    , ''                                                 DC_GUBUN                                                                                            ");
		sql.append("    , 'N'                                                  DC_YN                                                                                             ");
		sql.append("    , 'N'                                                  BANNAB_YN                                                                                         ");
		sql.append("    , ''                                                 BANNAB_CONFIRM                                                                                      ");
		sql.append("    , ''                                                 SOURCE_ORD_KEY                                                                                      ");
		sql.append("    , '0'                                                  OCS_FLAG                                                                                          ");
		sql.append("    , B.SG_CODE                                            SG_CODE                                                                                           ");
		sql.append("    , SYSDATE()                                            SG_YMD                                                                                            ");
		sql.append("    , ''                                                 IO_GUBUN                                                                                            ");
		sql.append("    , ''                                                 AFTER_ACT_YN                                                                                        ");
		sql.append("    , ''                                                 BICHI_YN                                                                                            ");
		sql.append("    , ''                                                 DRG_BUNHO                                                                                           ");
		sql.append("    , ''                                                 SUB_SUSUL                                                                                           ");
		sql.append("    , ''                                                 PRINT_YN                                                                                            ");
		sql.append("    , ''                                                 CHISIK                                                                                              ");
		sql.append("    , 'N'                                                  TEL_YN                                                                                            ");
		sql.append("    , B.ORDER_GUBUN                                        ORDER_GUBUN_BAS                                                                                   ");
		sql.append("    , B.INPUT_CONTROL                                      INPUT_CONTROL                                                                                     ");
		sql.append("    , B.SUGA_YN                                            SUGA_YN                                                                                           ");
		sql.append("    , B.JAERYO_YN                                          JAERYO_YN                                                                                         ");
		sql.append("    , IF(B.WONYOI_ORDER_YN = 'Z', 'Y', 'N')             WONYOI_CHECK                                                                                         ");
		sql.append("    , IF(B.EMERGENCY = 'Z', 'Y', 'N')                   EMERGENCY_CHECK                                                                                      ");
		sql.append("    , B.SPECIMEN_YN                                        SPECIMEN_CHECK                                                                                    ");
		sql.append("    , 'N'                                                  PORTABLE_YN_2                                                                                     ");
		sql.append("    , IF(B.END_DATE IS NULL OR B.END_DATE = STR_TO_DATE('99981231','%Y%m%d'),'N','Y') BULYONG_CHECK                                                          ");
		sql.append("    , 'N'                                                  SUNAB_CHECK                                                                                       ");
		sql.append("    , 'N'                                                  DC_CHECK                                                                                          ");
		sql.append("    , ''                                                 DC_GUBUN_CHECK                                                                                      ");
		sql.append("    , 'N'                                                  CONFIRM_CHECK                                                                                     ");
		sql.append("    , 'N'                                                  RESER_YN_CHECK                                                                                    ");
		sql.append("    , 'N'                                                  CHISIK_YN                                                                                         ");
		sql.append("    , 'N'                                                  NDAY_YN                                                                                           ");
		sql.append("    , 'N'                                                  DEFAULT_JAERYO_JUNDAL_YN                                                                          ");
		sql.append("    ,IF(A.ORDER_GUBUN NOT IN ('A', 'B', 'C', 'D') OR A.WONYOI_ORDER_YN = 'Z' OR A.WONYOI_ORDER_YN = 'Y', 'N', 'Y') DEFAULT_WONYOI_YN                         ");
		sql.append("    , D.SPECIFIC_COMMENT                                   SPECIFIC_COMMENT                                                                                  ");
		sql.append("    , D.SPECIFIC_COMMENT_NAME                              SPECIFIC_COMMENT_NAME                                                                             ");
		sql.append("    , D.SPECIFIC_COMMENT_SYS_ID                            SPECIFIC_COMMENT_SYS_ID                                                                           ");
		sql.append("    , D.SPECIFIC_COMMENT_PGM_ID                            SPECIFIC_COMMENT_PGM_ID                                                                           ");
		sql.append("    , D.SPECIFIC_COMMENT_NOT_NULL                          SPECIFIC_COMMENT_NOT_NULL                                                                         ");
		sql.append("    , D.SPECIFIC_COMMENT_TABLE_ID                          SPECIFIC_COMMENT_TABLE_ID                                                                         ");
		sql.append("    , D.SPECIFIC_COMMENT_COL_ID                            SPECIFIC_COMMENT_COL_ID                                                                           ");
		sql.append("    , FN_DRG_LOAD_DONBOK_YN (A.BOGYONG_CODE, :hospitalCode)             DONBOG_YN                                                                            ");
		sql.append("    , FN_OCS_LOAD_CODE_NAME ('ORDER_GUBUN_BAS', SUBSTR(A.ORDER_GUBUN, 2, 1), :hospitalCode, :language) ORDER_GUBUN_BAS_NAME                                  ");
		sql.append("    , ''                                                 ACT_DOCTOR                                                                                          ");
		sql.append("    , ''                                                 ACT_BUSEO                                                                                           ");
		sql.append("    , ''                                                 ACT_GWA                                                                                             ");
		sql.append("    , ''                                                 HOME_CARE_YN                                                                                        ");
		sql.append("    , ''                                                 REGULAR_YN                                                                                          ");
		sql.append("    , ''                                                 SORT_FKOCSKEY                                                                                       ");
		sql.append("    , IF(IF(A.BOM_SOURCE_KEY IS NULL, FN_OCS_LOAD_CHILD_GUBUN(:hospitalCode,'S',A.PKOCS0303),'3') != '3', 'N','Y') CHILD_YN                                  ");
		sql.append("    , B.IF_INPUT_CONTROL                                   IF_INPUT_CONTROL                                                                                  ");
		sql.append("    , F.SLIP_NAME                                          SLIP_NAME                                                                                         ");
		sql.append("    , A.PKOCS0303                                          ORG_KEY                                                                                           ");
		sql.append("    , A.BOM_SOURCE_KEY                                     PARENT_KEY                                                                                        ");
		sql.append("    , E.BUN_CODE                                           BUN_CODE                                                                                          ");
		sql.append("    , A.MEMB                                               MEMB                                                                                              ");
		sql.append("    , A.YAKSOK_CODE                                        YAKSOK_CODE                                                                                       ");
		sql.append("    , B.WONNAE_DRG_YN                                      WONNAE_DRG_YN                                                                                     ");
		sql.append("    , ''						                           HUBAL_CHANGE_CHECK                                                                                ");
		sql.append("    , ''                                                   DRG_PACK_CHECK                                                                                    ");
		sql.append("    , ''                                                   PHARMACY_CHECK                                                                                    ");
		sql.append("    , ''                                                   POWDER_CHECK                                                                                      ");
		sql.append("    , IFNULL(A.JUNDAL_TABLE_OUT, B.JUNDAL_TABLE_OUT)       JUNDAL_TABLE_OUT                                                                                  ");
		sql.append("    , IFNULL(A.JUNDAL_PART_OUT, B.JUNDAL_PART_OUT)         JUNDAL_PART_OUT                                                                                   ");
		sql.append("    , IFNULL(A.JUNDAL_TABLE_INP, B.JUNDAL_TABLE_INP)       JUNDAL_TABLE_INP                                                                                  ");
		sql.append("    , IFNULL(A.JUNDAL_PART_INP, B.JUNDAL_PART_INP)         JUNDAL_PART_INP                                                                                   ");
		sql.append("    , IFNULL(A.MOVE_PART_OUT, B.MOVE_PART)                 MOVE_PART_OUT                                                                                     ");
		sql.append("    , IFNULL(A.MOVE_PART_INP, B.MOVE_PART)                 MOVE_PART_INP                                                                                     ");
		sql.append("    ,DV_5                                                                                                                                                    ");
		sql.append("    ,DV_6                                                                                                                                                    ");
		sql.append("    ,DV_7                                                                                                                                                    ");
		sql.append("    ,DV_8                                                                                                                                                    ");
		sql.append("    ,IFNULL(A.GENERAL_DISP_YN, 'N')                                                                                                                          ");
		sql.append("    , CONCAT(LPAD(A.GROUP_SER, 11,'0'), LPAD(A.SEQ, 5, '0'),IF(A.BOM_SOURCE_KEY IS NULL, A.PKOCS0303, A.BOM_SOURCE_KEY)                                      ");
		sql.append("   , IF(A.BOM_SOURCE_KEY IS NULL,'1', '9'), A.PKOCS0303)  ORDER_BY_KEY                                                                                       ");
		sql.append(" FROM OCS0303 A INNER JOIN OCS0103 B ON B.HOSP_CODE = A.HOSP_CODE AND B.HANGMOG_CODE  = A.HANGMOG_CODE AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE     ");
		sql.append(" LEFT JOIN OCS0116 C ON C.HOSP_CODE = A.HOSP_CODE AND C.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                      ");
		sql.append(" LEFT JOIN OCS0170 D ON D.HOSP_CODE = B.HOSP_CODE AND D.SPECIFIC_COMMENT = B.SPECIFIC_COMMENT                                                                ");
		sql.append(" LEFT JOIN ( SELECT A.SG_CODE                                                                                                                                ");
		sql.append("             , A.SG_NAME                                                                                                                                     ");
		sql.append("             , A.BUN_CODE                                                                                                                                    ");
		sql.append("             , A.HOSP_CODE                                                                                                                                   ");
		sql.append("          FROM BAS0310 A                                                                                                                                     ");
		sql.append("         WHERE A.HOSP_CODE = :hospitalCode                                                                                                                   ");
		sql.append("           AND A.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                                             ");
		sql.append("                              FROM BAS0310 Z                                                                                                                 ");
		sql.append("                             WHERE Z.HOSP_CODE = A.HOSP_CODE                                                                                                 ");
		sql.append("                               AND Z.SG_CODE = A.SG_CODE                                                                                                     ");
		sql.append("                               AND Z.SG_YMD <= SYSDATE() )                                                                                                   ");
		sql.append("      ) E ON E.HOSP_CODE = B.HOSP_CODE AND E.SG_CODE = B.SG_CODE                                                                                             ");
		sql.append(" INNER JOIN OCS0102 F ON F.HOSP_CODE = B.HOSP_CODE  AND F.SLIP_CODE = B.SLIP_CODE AND F.LANGUAGE = :language                                                                          ");
		sql.append(" LEFT JOIN OCS0109 I ON I.HOSP_CODE = B.HOSP_CODE AND I.GENERIC_CODE = SUBSTR(B.YAK_KIJUN_CODE, 1, 9)                                                        ");
		sql.append("WHERE A.HOSP_CODE     = :hospitalCode                                                                                                                        ");
//		if(!StringUtils.isEmpty(memb)) {
			sql.append("   AND A.MEMB          = :memb                                                                                                                           ");
//		}
//		if(!StringUtils.isEmpty(fkocs0300Seq)) {
			sql.append("   AND A.FKOCS0300_SEQ = :fkocs0300_seq                                                                                                                  ");
//		}
//		if(!StringUtils.isEmpty(yaksokCode)) {
			sql.append("   AND A.YAKSOK_CODE   = :yaksok_code                                                                                                                    ");
//		}
		sql.append("ORDER BY ORDER_BY_KEY                                                                                                                                        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
//		if(!StringUtils.isEmpty(memb)) {
			query.setParameter("memb", memb);
//		}
//		if(!StringUtils.isEmpty(fkocs0300Seq)) {
			query.setParameter("fkocs0300_seq", fkocs0300Seq);
//		}
//		if(!StringUtils.isEmpty(yaksokCode)) {
			query.setParameter("yaksok_code", yaksokCode);
//		}
		
		List<OCS0301U00LayoutInfo> list = new JpaResultMapper().list(query, OCS0301U00LayoutInfo.class);
		
		return list;
	}

	@Override
	public List<OCS0301Q09GrdOCS0303Info> getOCS0301Q09GrdOCS0303(
			String hospCode, String language, String genericYn, String memb,
			Double fkocs0300Seq, String yaksokCode, String protocolId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.MEMB                                                    MEMB              ,                                                   ");
		sql.append("        A.YAKSOK_CODE                                             YAKSOK_CODE       ,                                                   ");
		sql.append("        CONCAT(IFNULL(A.MEMB,''),IFNULL(A.YAKSOK_CODE,''))        PK_YAKSOK         ,                                                   ");
		sql.append("        A.PKOCS0303                                               PKOCS0303         ,                                                   ");
		sql.append("        A.GROUP_SER                                               GROUP_SER         ,                                                   ");
		sql.append("        A.MIX_GROUP                                               MIX_GROUP         ,                                                   ");
		sql.append("        A.SEQ                                                     SEQ               ,                                                   ");
		sql.append("        A.ORDER_GUBUN                                             ORDER_GUBUN       ,                                                   ");
		sql.append("        IFNULL(C.CODE_NAME, 'Etc')                                ORDER_GUBUN_NAME  ,                                                   ");
		sql.append("        A.INPUT_TAB                                               INPUT_TAB         ,                                                   ");
		sql.append("        A.HANGMOG_CODE                                            HANGMOG_CODE      ,                                                   ");
		sql.append("        case :f_generic_yn when 'N' then B.HANGMOG_NAME                                                                                 ");
		sql.append("           else (case A.GENERAL_DISP_YN when 'Y' then I.GENERIC_NAME else  B.HANGMOG_NAME end) end  HANGMOG_NAME,                       ");
		sql.append("        A.SPECIMEN_CODE                                           SPECIMEN_CODE     ,                                                   ");
		sql.append("        FN_OCS_LOAD_SPECIMEN_NAME(:f_hosp_code,A.SPECIMEN_CODE)                SPECIMEN_NAME     ,                                      ");
		sql.append("        A.SURYANG                                                 SURYANG           ,                                                   ");
		sql.append("        A.ORD_DANUI                                               ORD_DANUI         ,                                                   ");
		sql.append("        FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code,:f_language)     ORD_DANUI_NAME    ,                                ");
		sql.append("        A.DV_TIME                                                 DV_TIME           ,                                                   ");
		sql.append("        IFNULL(A.DV, 0)                                           DV                ,                                                   ");
		sql.append("        A.DV_1                                                    DV_1              ,                                                   ");
		sql.append("        A.DV_2                                                    DV_2              ,                                                   ");
		sql.append("        A.DV_3                                                    DV_3              ,                                                   ");
		sql.append("        A.DV_4                                                    DV_4              ,                                                   ");
		sql.append("        A.NALSU                                                   NALSU             ,                                                   ");
		sql.append("        A.JUSA                                                    JUSA              ,                                                   ");
		sql.append("        FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA,:f_hosp_code,:f_language)                     JUSA_NAME         ,                          ");
		sql.append("        A.BOGYONG_CODE                                            BOGYONG_CODE      ,                                                   ");
		sql.append("        FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN,:f_hosp_code,:f_language)                               ");
		sql.append("                                                                  BOGYONG_NAME      ,                                                   ");
		sql.append("        A.JUSA_SPD_GUBUN                                          JUSA_SPD_GUBUN    ,                                                   ");
		sql.append("        A.HUBAL_CHANGE_YN                                         HUBAL_CHANGE_YN   ,                                                   ");
		sql.append("        A.PHARMACY                                                PHARMACY          ,                                                   ");
		sql.append("        A.DRG_PACK_YN                                             DRG_PACK_YN       ,                                                   ");
		sql.append("        A.EMERGENCY                                               EMERGENCY         ,                                                   ");
		sql.append("        A.PAY                                                     PAY               ,                                                   ");
		sql.append("        A.PORTABLE_YN                                             PORTABLE_YN       ,                                                   ");
		sql.append("        A.POWDER_YN                                               POWDER_YN         ,                                                   ");
		sql.append("        A.MUHYO                                                   MUHYO             ,                                                   ");
		sql.append("        A.PRN_YN                                                  PRN_YN            ,                                                   ");
		sql.append("        A.ORDER_REMARK                                            ORDER_REMARK      ,                                                   ");
		sql.append("        A.NURSE_REMARK                                            NURSE_REMARK      ,                                                   ");
		sql.append("        FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, '',SYSDATE(),:f_hosp_code)  BULYONG_CHECK,                 			    ");
		// [MED-hieutt]20150715 tuning Beta 1.0.5.1
//		sql.append("        ( CASE WHEN FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE(),:f_hosp_code) <> 'Y'                                             ");
//		sql.append("               THEN 'N'                                                                                                                 ");
//		sql.append("               WHEN FN_OCS_BULYONG_CHECK_OUT   (B.HANGMOG_CODE, SYSDATE(),:f_hosp_code) = 'Y'                                           ");
//		sql.append("                AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, '',SYSDATE(),:f_hosp_code) <> A.HANGMOG_CODE                  ");
//		sql.append("               THEN 'Z'                                                                                                                 ");
//		sql.append("               ELSE 'Y' END )                                     BULYONG_CHECK     ,                                                   ");	
		sql.append("        B.SLIP_CODE                                               SLIP_CODE         ,                                                   ");
		sql.append("        B.GROUP_YN                                                GROUP_YN          ,                                                   ");
		sql.append("        B.ORDER_GUBUN                                             ORDER_GUBUN_BAS   ,                                                   ");
		sql.append("        B.INPUT_CONTROL                                           INPUT_CONTROL     ,                                                   ");
		sql.append("        B.SG_CODE                                                 SG_CODE           ,                                                   ");
		sql.append("        IFNULL(B.SUGA_YN,'N')                                        SUGA_YN           ,                                                ");
		sql.append("        case IFNULL(B.EMERGENCY,'Z') when 'Y' then 'N' when 'N' then 'N' else 'Y' end    EMERGENCY_CHECK   ,                            ");
		sql.append("        B.LIMIT_SURYANG                                           LIMIT_SURYANG     ,                                                   ");
		sql.append("        IFNULL(B.SPECIMEN_YN,'N')                                    SPECIMEN_YN       ,                                                ");
		sql.append("        IFNULL(B.JAERYO_YN,'N')                                      JAERYO_YN         ,                                                ");
		sql.append("        case B.ORD_DANUI when NULL then 'N' else 'Y' end         ORD_DANUI_CHECK   ,                                                    ");
		sql.append("        A.WONYOI_ORDER_YN                                         WONYOI_ORDER_YN   ,                                                   ");
		sql.append("        A.DANGIL_GUMSA_ORDER_YN                                   DANGIL_GUMSA_ORDER_YN ,                                               ");
		sql.append("        A.DANGIL_GUMSA_RESULT_YN                                  DANGIL_GUMSA_RESULT_YN,                                               ");
		sql.append("        case B.ORDER_GUBUN when 'A' then (case B.WONYOI_ORDER_YN when 'Y' then 'N' when 'N' then 'N' else 'Y' end)                      ");
		sql.append("                           when 'B' then (case B.WONYOI_ORDER_YN when 'Y' then 'N' when 'N' then 'N' else 'Y' end)                      ");
		sql.append("                           when 'C' then (case B.WONYOI_ORDER_YN when 'Y' then 'N' when 'N' then 'N' else 'Y' end)                      ");
		sql.append("                           when 'D' then (case B.WONYOI_ORDER_YN when 'Y' then 'N' when 'N' then 'N' else 'Y' end)                      ");
		sql.append("                           else 'N' end                                WONYOI_ORDER_CR_YN,                                              ");
		sql.append("        IFNULL(B.NDAY_YN,'N')                                        NDAY_YN           ,                                                ");
		sql.append("        IFNULL(A.MUHYO, IFNULL(B.MUHYO_YN,'N'))                         MUHYO_YN          ,                                             ");
		sql.append("        FN_OCS_LOAD_CODE_NAME('PAY',  A.PAY,:f_hosp_code,:f_language)                      PAY_NAME          ,                          ");
		sql.append("        D.BUN_CODE                                                BUN_CODE          ,                                                   ");
		sql.append("        A.YAKSOK_CODE                                             DATA_CONTROL      ,                                                   ");
		sql.append("        case B.ORDER_GUBUN when 'C' then FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE,:f_hosp_code) else 'N' end                                ");
		sql.append("                                                                  DONBOK_YN           ,                                                 ");
		sql.append("        FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8) DV_NAME             ,                 ");
		sql.append("        FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE,:f_hosp_code)                       DRG_INFO            ,                                    ");
		sql.append("        ' '                                                       DRG_BUNRYU          ,                                                 ");
		sql.append("        case A.BOM_SOURCE_KEY when NULL then FN_OCS_SETORDER_CHILD_GUBUN(:f_hosp_code,A.PKOCS0303) else '3' end     CHILD_GUBUN,        ");
		sql.append("         A.BOM_SOURCE_KEY                                         BOM_SOURCE_KEY,                                                       ");
		sql.append("        'Y'                                                       HAENGWEE_YN,                                                          ");
		sql.append("         A.PKOCS0303                                              ORG_KEY,                                                              ");
		sql.append("         A.BOM_SOURCE_KEY                                         PARENT_KEY,                                                           ");
		sql.append("         A.FKOCS0300_SEQ                                          FKOCS0300_SEQ,                                                        ");
		sql.append("         CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN 'Y' ELSE 'N' END      CHILD_YN ,                                                   ");
		sql.append("         IFNULL(A.JUNDAL_TABLE_OUT, B.JUNDAL_TABLE_OUT)              JUNDAL_TABLE_OUT ,                                                 ");
		sql.append("         IFNULL(A.JUNDAL_PART_OUT, B.JUNDAL_PART_OUT)                JUNDAL_PART_OUT  ,                                                 ");
		sql.append("         IFNULL(A.JUNDAL_TABLE_INP, B.JUNDAL_TABLE_INP)              JUNDAL_TABLE_INP ,                                                 ");
		sql.append("         IFNULL(A.JUNDAL_PART_INP, B.JUNDAL_PART_INP)                JUNDAL_PART_INP  ,                                                 ");
		sql.append("         IFNULL(A.MOVE_PART_OUT, B.MOVE_PART)                    MOVE_PART_OUT    ,                                                     ");
		sql.append("         IFNULL(A.MOVE_PART_INP, B.MOVE_PART)                    MOVE_PART_INP    ,                                                     ");
		sql.append("                                                                                                                                        ");
		sql.append("         FN_BAS_LOAD_GWA_NAME (B.JUNDAL_PART_OUT, SYSDATE(),:f_hosp_code,:f_language) JUNDAL_PART_OUT_NAME ,                            ");
		sql.append("         FN_BAS_LOAD_GWA_NAME (B.JUNDAL_PART_INP, SYSDATE(),:f_hosp_code,:f_language) JUNDAL_PART_INP_NAME ,                            ");
		sql.append("         IFNULL(B.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN,                                                                                    ");
		sql.append("         A.DV_5,                                                                                                                        ");
		sql.append("         A.DV_6,                                                                                                                        ");
		sql.append("         A.DV_7,                                                                                                                        ");
		sql.append("         A.DV_8,                                                                                                                        ");
		sql.append("         IFNULL(A.GENERAL_DISP_YN, 'N'),                                                                                                ");
		sql.append("         I.GENERIC_NAME,                                                                                                                ");
		sql.append("         'N',                                                                                                                           ");
		sql.append("		 B.TRIAL_FLG 							TRIAL_FLG,																				");
		sql.append("        IFNULL(DATE_FORMAT(Z.BULYONG_YMD, '%Y/%m/%d'), '9998/12/31')	,																");
		sql.append("        B.YJ_CODE																	                                                    ");
		sql.append(" FROM 																																    ");
		sql.append("        (( SELECT A.SG_CODE                                                                                                             ");
		sql.append("               , A.SG_NAME                                                                                                              ");
		sql.append("               , A.BUN_CODE                                                                                                             ");
		sql.append("               , A.SG_UNION                                                                                                             ");
		sql.append("               , A.HOSP_CODE                                                                                                            ");
		sql.append("            FROM (SELECT * FROM BAS0310 WHERE HOSP_CODE = :f_hosp_code ) A                                                              ");
		sql.append("           WHERE A.SG_YMD = ( SELECT MAX(X.SG_YMD)                                                                                      ");
		sql.append("                                FROM BAS0310 X                                                                                          ");
		sql.append("                               WHERE X.SG_CODE = A.SG_CODE                                                                              ");
		sql.append("                                 AND X.SG_YMD <= SYSDATE() AND HOSP_CODE = :f_hosp_code )                                               ");
		sql.append("        ) D RIGHT JOIN OCS0103 B ON D.SG_CODE = B.SG_CODE AND D.HOSP_CODE = B.HOSP_CODE)                                                ");
		//sql.append("        LEFT JOIN VW_OCS_GENERIC I ON I.HOSP_CODE = B.HOSP_CODE AND I.HANGMOG_CODE = B.HANGMOG_CODE                                     ");

		sql.append(" LEFT JOIN ( select distinct A.HOSP_CODE AS HOSP_CODE ,A.HANGMOG_CODE AS HANGMOG_CODE, C.GENERIC_NAME AS GENERIC_NAME                   ");
		sql.append("               FROM OCS0109 C INNER JOIN OCS0110 B ON C.HOSP_CODE = B.HOSP_CODE AND C.GENERIC_CODE_ORG = B.GENERIC_CODE_ORG             ");
		sql.append("                              INNER JOIN OCS0103 A ON B.HOSP_CODE = A.HOSP_CODE AND B.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE                 ");
		sql.append("         AND A.START_DATE <= SYSDATE() AND A.END_DATE >= SYSDATE()                                                                      ");
		sql.append(" AND A.START_DATE = (SELECT MAX(S.START_DATE) FROM OCS0103 S where S.HOSP_CODE = A.HOSP_CODE AND S.HANGMOG_CODE = A.HANGMOG_CODE)       ");
		sql.append("                              WHERE  B.HOSP_CODE = :f_hosp_code                                                                          ");
		sql.append("            union all                                                                                                                   ");
		sql.append("            select distinct A.HOSP_CODE AS HOSP_CODE ,A.HANGMOG_CODE AS HANGMOG_CODE, C.GENERIC_NAME AS GENERIC_NAME                    ");
		sql.append("            FROM OCS0109 C INNER JOIN OCS0103 A ON C.HOSP_CODE = A.HOSP_CODE AND C.GENERIC_CODE = A.YAK_KIJUN_CODE_SHORT                ");
		sql.append("         AND A.START_DATE <= SYSDATE() AND A.END_DATE >= SYSDATE()                                                                      ");
		sql.append(" AND A.START_DATE = (SELECT MAX(S.START_DATE) FROM OCS0103 S where S.HOSP_CODE = A.HOSP_CODE AND S.HANGMOG_CODE = A.HANGMOG_CODE)       ");
		sql.append("            WHERE C.HOSP_CODE = :f_hosp_code AND                                                                                        ");
		sql.append("                 (not (exists(SELECT NULL FROM OCS0110 Z                                                                                ");
		sql.append("                                WHERE Z.HOSP_CODE = A.HOSP_CODE AND                                                                     ");
		sql.append("                                Z.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE)))) I                                                               ");
		sql.append("                           ON I.HOSP_CODE = B.HOSP_CODE AND I.HANGMOG_CODE = B.HANGMOG_CODE										    	");

		//[START] get data to process FN_OCS_BULYONG_CHECK_OUT in java --> turning performance                                                              
		sql.append(" 	   LEFT JOIN(SELECT X.SG_CODE                                                                                                       ");
		sql.append("               , X.HOSP_CODE                                                                                                            ");
		sql.append("               , X.BULYONG_YMD                                                                                                          ");
		sql.append(" 	   FROM (SELECT * FROM BAS0310 WHERE HOSP_CODE = :f_hosp_code ) X                                                                   ");
		sql.append(" 	   WHERE X.SG_YMD =(SELECT MAX(Y.SG_YMD)                                                                                            ");
		sql.append(" 	   	FROM BAS0310 Y                                                                                                                  ");
		sql.append(" 	   	WHERE Y.SG_CODE = X.SG_CODE                                                                                                     ");
		sql.append(" 	   	AND Y.SG_YMD <= SYSDATE() AND HOSP_CODE = :f_hosp_code)) Z ON Z.HOSP_CODE = B.HOSP_CODE AND Z.SG_CODE = B.SG_CODE               ");
		sql.append(" 	   	AND B.START_DATE =                                                                                                              ");
		sql.append(" 	   	(SELECT MAX(Z.START_DATE)  FROM OCS0103 Z WHERE Z.HANGMOG_CODE = B.HANGMOG_CODE AND Z.START_DATE <= SYSDATE() ),       	        ");
		sql.append(" 	   	OCS0132 C,                                                                                                                      ");
		sql.append(" 	   	OCS0303 A                                                                                                                       ");
		//[END] get data to process FN_OCS_BULYONG_CHECK_OUT in java                 
		sql.append("  WHERE A.MEMB          = :f_memb                                                                                                       ");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND  (B.TRIAL_FLG = 'N'  OR ( B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))                                     ");
		}else{
			sql.append("    AND B.TRIAL_FLG = 'N'                                                                                                           ");
		}
		sql.append("    AND A.FKOCS0300_SEQ = :f_fkocs0300_seq                                                                                              ");
		sql.append("    AND A.YAKSOK_CODE   = :f_yaksok_code                                                                                                ");
		sql.append("    AND A.HOSP_CODE     = :f_hosp_code                                                                                                  ");
		sql.append("    AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                                                                                   ");
		sql.append("    AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE                                                                                   ");
		sql.append("    AND C.CODE          = A.ORDER_GUBUN                                                                                                 ");
		sql.append("    AND C.CODE_TYPE     = 'ORDER_GUBUN'                                                                                                 ");
		sql.append("    AND C.HOSP_CODE     = A.HOSP_CODE                                                                                                   ");
		sql.append("    AND C.LANGUAGE      =:f_language                                                                                                    ");
		sql.append("  ORDER BY A.GROUP_SER, IFNULL(C.SORT_KEY, 99), A.SEQ																			        ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_generic_yn", genericYn);
		query.setParameter("f_memb", memb);
		query.setParameter("f_fkocs0300_seq", fkocs0300Seq);
		query.setParameter("f_yaksok_code", yaksokCode);
		if(!StringUtils.isEmpty(protocolId)){
			query.setParameter("f_protocol_id", CommonUtils.parseInteger(protocolId));
		}
		List<OCS0301Q09GrdOCS0303Info> list = new JpaResultMapper().list(query, OCS0301Q09GrdOCS0303Info.class);
		return list;
	}

	@Override
	public List<OCS0307U00GrdListItemInfo> getComboList0307Info(String hospCode, String userId, String pkocs0300Seq,
			String yaksokCode) {
		StringBuffer sql = new StringBuffer(); 
		sql.append("SELECT A.SANG_CODE,									 			");
		sql.append("       B.SANG_NAME,												");
		sql.append("       A.ID	 													");
		sql.append(" FROM OCS0307 A INNER JOIN CHT0110 B 							");       
		sql.append("            ON  A.HOSP_CODE = B.HOSP_CODE						");
		sql.append("            AND A.SANG_CODE = B.SANG_CODE						");
		sql.append("            AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE	");       
		sql.append("            AND B.START_DATE = (								");       
		sql.append("              SELECT MAX(B1.START_DATE)							");       
		sql.append("              FROM CHT0110 B1									");       
		sql.append("              WHERE B1.HOSP_CODE = :f_hosp_code					");
		sql.append("                AND B1.SANG_CODE = B.SANG_CODE)					");       
		sql.append("    WHERE A.HOSP_CODE       = :f_hosp_code						");       
		sql.append("      AND A.MEMB            = :f_sys_id							");
		sql.append("      AND A.FKOCS0300_SEQ   = :f_fkocs0300_seq					"); 
		sql.append("      AND A.YAKSOK_CODE     = :f_yaksok_code					");
		sql.append("      AND A.ACTIVE_FLG      = 1									");
		sql.append("      ORDER BY A.ID												");
		                                                                                                          
		Query query = entityManager.createNativeQuery(sql.toString());                                            
		query.setParameter("f_hosp_code", hospCode);                                                              
		query.setParameter("f_sys_id", userId);                                                                       
		query.setParameter("f_fkocs0300_seq", CommonUtils.parseDouble(pkocs0300Seq));
		query.setParameter("f_yaksok_code", yaksokCode);
		List<OCS0307U00GrdListItemInfo> listResult = new JpaResultMapper().list(query, OCS0307U00GrdListItemInfo.class);
		return listResult;         
	}
}

