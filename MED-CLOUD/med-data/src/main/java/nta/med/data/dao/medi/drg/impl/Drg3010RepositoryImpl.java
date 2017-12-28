package nta.med.data.dao.medi.drg.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3010RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaLabel1Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaLabel2Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint1Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint2Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint3Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint4Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint3Info;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdDcOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdDrgBunhoInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdJusaDcOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamJusaOrdInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamOrdInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamPaQueryInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMiMaJuOrdInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMiMaOrdInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdPaDcInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdPaInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10LayOrderJungboInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaCurInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaKInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaLabelInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaSerialInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99OrdPrnCurInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99OrdPrnRemarkInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99OrdPrnSerialInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99PaPrnInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99SerRemarkInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99getBodyIndexBarcodeInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99getBodyIndexInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdDcOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdJusaDcOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdListInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdMagamOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdMiMagamJusaOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdPaDcListInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdPaInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdPrnJusaInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99layOrderBarcodeInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99layOrderJungboInfo;
import nta.med.data.model.ihis.drgs.DRG3010Q12grdPalistInfo;
import nta.med.data.model.ihis.drgs.DRG3041P05LabelInfo;
import nta.med.data.model.ihis.drgs.DRG3041P05SerialInfo;
import nta.med.data.model.ihis.drgs.DRG3041P06LabelInfo;
import nta.med.data.model.ihis.drgs.DRG3041P06SerialInfo;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdJUSAOrderListInfo;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdOrderInfo;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdOrderListInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01CurDrgOrderInfo;
import nta.med.data.model.ihis.drgs.PrJihDrgIfsProcInfo;
import nta.med.data.model.ihis.drgs.PrJihDrgIfsProcPatientInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getJusaInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getSysInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03orderJungboInfo;

/**
 * @author dainguyen.
 */
public class Drg3010RepositoryImpl implements Drg3010RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Drg3010RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DrgsDRG5100P01CurDrgOrderInfo> getDrgsDRG5100P01CurDrgOrderInfo(String hospCode, String language, 
			Double masterPk, String ioGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT                                                                                                                                                                                                   ");
		sql.append("          A.HOSP_CODE                                                              AS HOSP_CODE                                                                                                          ");
		sql.append("        , A.BUNHO                                                                  AS BUNHO                                                                                                              ");
		sql.append("        , AK.SUNAME                                                                AS NAME                                                                                                               ");
		sql.append("        , AK.SUNAME2                                                               AS NAME_KANA                                                                                                          ");
		sql.append("        , IF(AK.SEX = 'F', '2', '1')                                               AS SEX                                                                                                                ");
		sql.append("        , AK.BIRTH                                                                 AS BIRTHDAY                                                                                                           ");
		sql.append("        , '1'                                                                      AS IO_GUBUN                                                                                                           ");
		sql.append("        , CASE A.MAGAM_GUBUN WHEN '11' THEN '1'                                                                                                                                                          ");
		sql.append("                                WHEN '21' THEN '2'                                                                                                                                                       ");
		sql.append("                                WHEN '31' THEN '3'                                                                                                                                                       ");
		sql.append("          END                                               AS DRG_ORD_GUBUN                                                                                                                             ");
		sql.append("        , CASE A.MAGAM_GUBUN WHEN '11' THEN '1'                                                                                                                                                          ");
		sql.append("                                WHEN '21' THEN '1'                                                                                                                                                       ");
		sql.append("                                WHEN '31' THEN '3'                                                                                                                                                       ");
		sql.append("             END                                               AS IP_TOIWON_GUBUN                                                                                                                        ");
		sql.append("        , A0.DATA_DUBUN                                                            AS DATA_GUBUN                                                                                                         ");
		sql.append("        , A.HO_DONG                                                                AS HO_DONG                                                                                                            ");
		sql.append("        , FN_BAS_LOAD_HO_DONG_NAME(A.HO_DONG, A.ORDER_DATE, :f_hosp_code, :f_language)                         AS HO_DONG_NAME                                                                           ");
		sql.append("        , A.HO_CODE                                                                AS HO_CODE                                                                                                            ");
		sql.append("        , CONCAT(IFNULL(A.HO_CODE,''),'室')                                        AS HO_CODE_NAME                                                                                                       ");
		sql.append("        , A.GWA                                                                    AS GWA                                                                                                                ");
		sql.append("        , AG.GWA_NAME                                                              AS GWA_NAME                                                                                                           ");
		sql.append("        , AD.ORG_DOCTOR                                                            AS DOCTOR                                                                                                             ");
		sql.append("        , AD.DOCTOR_NAME                                                           AS DOCTOR_NAME                                                                                                        ");
		sql.append("        , A.JUBSU_DATE                                                             AS JUBSU_DATE                                                                                                         ");
		sql.append("        , A.JUBSU_DATE                                                             AS JOJE_DATE                                                                                                          ");
		sql.append("        , IFNULL(AO.HOPE_DATE, A.JUBSU_DATE)                                       AS BOGYONG_START_DATE                                                                                                 ");
		sql.append("        , A.DRG_BUNHO                                                              AS DRG_BUNHO                                                                                                          ");
		sql.append("        , RC.RP_CNT                                                                AS RP_CNT                                                                                                             ");
		sql.append("        , CA.ORDER_REMARK                                                          AS ORD_CMT                                                                                                            ");
		sql.append("        , CEIL(LENGTH(IFNULL(CA.ORDER_REMARK,''))/50)                              AS ORD_CMT_CNT                                                                                                        ");
		sql.append("        , SUBSTR(A.GROUP_SER, 2)                                                   AS DRG_RP_NO                                                                                                          ");
		sql.append("        , CASE                                                                                                                                                                                           ");
		sql.append("            WHEN (B.DONBOG_YN = 'Y')    THEN '3'                                                                                                                                                         ");
		sql.append("            WHEN (B.BUNRYU1 = '1')      THEN '1'                                                                                                                                                         ");
		sql.append("            WHEN (B.BUNRYU1 = '6')      THEN '5'                                                                                                                                                         ");
		sql.append("            WHEN (B.BUNRYU1 = '4')      THEN '4'                                                                                                                                                         ");
		sql.append("                                        ELSE '9'                                                                                                                                                         ");
		sql.append("          END                                                                      AS BOGYONG_GUBUN                                                                                                      ");
		sql.append("        , A.BOGYONG_CODE                                                           AS BOGYONG_CODE                                                                                                       ");
		sql.append("        , '4'                                                                      AS BOGYONG_SIGI_GUBUN                                                                                                 ");
		sql.append("        , ''                                                                       AS BOGYONG_SIGI                                                                                                       ");
		sql.append("        , B.BOGYONG_NAME                                                           AS BOGYONG_NAME                                                                                                       ");
		sql.append("        , LPAD(CASE                                                                                                                                                                                      ");
		sql.append("               WHEN (B.DONBOG_YN = 'Y')    THEN 1                                                                                                                                                        ");
		sql.append("                                           ELSE A.DV                                                                                                                                                     ");
		sql.append("                END                                                                                                                                                                                      ");
		sql.append("          ,2, '0')                                                                 AS DV                                                                                                                 ");
		sql.append("        , CASE                                                                                                                                                                                           ");
		sql.append("            WHEN (B.DONBOG_YN = 'Y')    THEN '1'                                                                                                                                                         ");
		sql.append("                                     ELSE '0'                                                                                                                                                            ");
		sql.append("           END                                                                     AS DAY_DV_GUBUN                                                                                                       ");
		sql.append("        , CASE                                                                                                                                                                                           ");
		sql.append("            WHEN (B.DONBOG_YN = 'Y')    THEN IFNULL(B.BOGYONG_GUBUN, '')                                                                                                                                 ");
		sql.append("                                        ELSE A.NALSU                                                                                                                                                     ");
		sql.append("          END                                                                      AS DAY_DV_CNT                                                                                                         ");
		sql.append("        , LPAD(DC.DRG_CNT,2, '0')                                                  AS DRG_CNT                                                                                                            ");
		sql.append("        , 1                                                                        AS DRG_SEQ                                                                                                            ");
		sql.append("        , A.JAERYO_CODE                                                            AS DRG_CODE                                                                                                           ");
		sql.append("        , C.JAERYO_NAME                                                            AS DRG_NAME                                                                                                           ");
		sql.append("        , ''                                                                       AS DRG_NAME_KANA                                                                                                      ");
		sql.append("        , CASE                                                                                                                                                                                           ");
		sql.append("            WHEN (B.BUNRYU1 = '6')      THEN '5'                                                                                                                                                         ");
		sql.append("            WHEN (B.BUNRYU1 = '4')      THEN '4'                                                                                                                                                         ");
		sql.append("            WHEN (B.BUNRYU1 = '1')      THEN '1'                                                                                                                                                         ");
		sql.append("                                        ELSE '1'                                                                                                                                                         ");
		sql.append("          END                                                                      AS DRG_GUBUN                                                                                                          ");
		sql.append("        , ''                                                                       AS DRG_TYPE                                                                                                           ");
		sql.append("        , A.ORDER_DANUI                                                            AS DANUI                                                                                                              ");
		sql.append("        , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI,:f_hosp_code,:f_language)                        AS DANUI_NAME                                                                                ");
		sql.append("        , A.DV_TIME                                                                AS DV_TIME                                                                                                            ");
		sql.append("        , CASE                                                                                                                                                                                           ");
		sql.append("            WHEN (A.DV_TIME = '*' )     THEN (A.ORDER_SURYANG)                                                                                                                                           ");
		sql.append("                                        ELSE (A.ORD_SURYANG)                                                                                                                                             ");
		sql.append("          END                                                                      AS SURYANG                                                                                                            ");
		sql.append("        , IF(SIGN(IFNULL(A.DV_1, 0)) =  0, '0', '1')                                AS UNBALANCE_YN                                                                                                      ");
		sql.append("        , B.PATTERN                                                                AS PATTERN                                                                                                            ");
		sql.append("        , A.DV_1                                                                   AS DV_1                                                                                                               ");
		sql.append("        , A.DV_2                                                                   AS DV_2                                                                                                               ");
		sql.append("        , A.DV_3                                                                   AS DV_3                                                                                                               ");
		sql.append("        , A.DV_4                                                                   AS DV_4                                                                                                               ");
		sql.append("        , A.DV_5                                                                   AS DV_5                                                                                                               ");
		sql.append("        , A.DV_6                                                                   AS DV_6                                                                                                               ");
		sql.append("        , A.DV_7                                                                   AS DV_7                                                                                                               ");
		sql.append("        , A.DV_8                                                                   AS DV_8                                                                                                               ");
		sql.append("        , IF(A.POWDER_YN = 'Y', '1', '0')                                          AS POWDER_YN                                                                                                          ");
		sql.append("        , IF(A.DRG_PACK_YN = 'Y', '1', '0')                                        AS DRG_PACK_YN                                                                                                        ");
		sql.append("        , A.FKOCS2003                                                              AS FKOCS                                                                                                              ");
		sql.append("        , CD.ORDER_REMARK                                                          AS DRG_CMT                                                                                                            ");
		sql.append("        , CEIL(LENGTH(IFNULL(CD.ORDER_REMARK,''))/50)                              AS DRG_CMT_CNT                                                                                                        ");
		sql.append("        , A0.PKDRG4010                                                             AS FKDRG                                                                                                              ");
		sql.append("     FROM                                                                                                                                                                                                ");
		sql.append("          (SELECT COUNT(DISTINCT Z.GROUP_SER)   AS RP_CNT                                                                                                                                                ");
		sql.append("             FROM DRG4010 X                                                                                                                                                                              ");
		sql.append("                , DRG3010 Z                                                                                                                                                                              ");
		sql.append("            WHERE X.HOSP_CODE                   = :f_hosp_code                                                                                                                                           ");
		sql.append("              AND X.PKDRG4010                   = :f_master_pk                                                                                                                                           ");
		sql.append("              AND X.IN_OUT_GUBUN                = :f_io_gubun                                                                                                                                            ");
		sql.append("              AND Z.HOSP_CODE                   = X.HOSP_CODE                                                                                                                                            ");
		sql.append("              AND Z.FKDRG4010                   = X.PKDRG4010                                                                                                                                            ");
		sql.append("          ) RC                                                                                                                                                                                           ");
		sql.append("        , DRG3010 A JOIN DRG4010 A0 ON A.HOSP_CODE = A0.HOSP_CODE AND A.FKDRG4010 = A0.PKDRG4010                                                                                                         ");
		sql.append("                    JOIN OUT0101 AK ON AK.HOSP_CODE = A.HOSP_CODE AND AK.BUNHO = A.BUNHO                                                                                                                 ");
		sql.append("                    LEFT OUTER JOIN BAS0270 AD ON AD.HOSP_CODE = A.HOSP_CODE AND AD.DOCTOR = A.DOCTOR                                                                                                    ");
		sql.append("                    LEFT OUTER JOIN BAS0260 AG ON AG.HOSP_CODE = A.HOSP_CODE AND AG.GWA = A.GWA AND AG.LANGUAGE = :f_language                                                                            ");
		sql.append("                    LEFT OUTER JOIN OCS2003 AO ON AO.HOSP_CODE = A.HOSP_CODE AND AO.PKOCS2003 = A.FKOCS2003                                                                                              ");
		sql.append("                    LEFT OUTER JOIN DRG0120 B ON :f_hosp_code = A.HOSP_CODE AND B.BOGYONG_CODE = A.BOGYONG_CODE AND B.LANGUAGE = :f_language  AND B.HOSP_CODE = :f_hosp_code                             ");
		sql.append("                    LEFT OUTER JOIN INV0110 C ON C.HOSP_CODE = A.HOSP_CODE AND C.JAERYO_CODE = A.JAERYO_CODE                                                                                             ");
		sql.append("                    LEFT OUTER JOIN (SELECT Z.GROUP_SER                   AS GROUP_SER                                                                                                                   ");
		sql.append("                                          , COUNT(*)                      AS DRG_CNT                                                                                                                     ");
		sql.append("                                       FROM DRG4010 X                                                                                                                                                    ");
		sql.append("                                          , DRG3010 Z                                                                                                                                                    ");
		sql.append("                                      WHERE X.HOSP_CODE                   = :f_hosp_code                                                                                                                 ");
		sql.append("                                        AND X.PKDRG4010                   = :f_master_pk                                                                                                                 ");
		sql.append("                                        AND X.IN_OUT_GUBUN                = :f_io_gubun                                                                                                                  ");
		sql.append("                                        AND Z.HOSP_CODE                   = X.HOSP_CODE                                                                                                                  ");
		sql.append("                                        AND Z.FKDRG4010                   = X.PKDRG4010                                                                                                                  ");
		sql.append("                                   GROUP BY Z.GROUP_SER) DC ON DC.GROUP_SER = A.GROUP_SER                                                                                                                ");
		sql.append("                    LEFT OUTER JOIN DRG9040 CA ON CA.HOSP_CODE = A.HOSP_CODE AND CA.IN_OUT_GUBUN = :f_io_gubun AND CA.JUBSU_DATE = A.JUBSU_DATE AND CA.DRG_BUNHO = A.DRG_BUNHO                           ");
		sql.append("                    LEFT OUTER JOIN DRG9042 CD ON CD.HOSP_CODE = A.HOSP_CODE AND CD.IN_OUT_GUBUN = :f_io_gubun AND CD.FKOCS = A.FKOCS2003                                                                ");
		sql.append("    WHERE A0.HOSP_CODE                 = :f_hosp_code                                                                                                                                                    ");
		sql.append("      AND A0.PKDRG4010                 = :f_master_pk                                                                                                                                                    ");
		sql.append("      AND A0.IN_OUT_GUBUN              = :f_io_gubun                                                                                                                                                     ");
		sql.append("      AND IFNULL(A.DC_YN, 'N')             = 'N'                                                                                                                                                         ");
		sql.append("      AND IFNULL(A.BANNAB_YN, 'N')         = 'N'                                                                                                                                                         ");
		sql.append("    ORDER BY A.HOSP_CODE, A.DRG_BUNHO, A.GROUP_SER, A.FKOCS2003                                                                                                                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_master_pk", masterPk);
		query.setParameter("f_io_gubun", ioGubun);
		
		List<DrgsDRG5100P01CurDrgOrderInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01CurDrgOrderInfo.class);
		return list;
	}
	
	@Override
	public List<PrJihDrgIfsProcInfo> getPrJihDrgIfsProcInInfo(String hospitalCode, Double fkdrg){

		StringBuilder sql = new StringBuilder();
		sql.append("SELECT   PKG_IFS_BAS_FN_LOAD_IF_CONSTANT(:hospitalCode, 'IF_JIH_CONSTANT', 'REC_GUBUN_PAT_01PT')       REC_GUBUN_PAT      ");
		sql.append("         , DATE_FORMAT(A.DRG_PRN_DATE, '%Y%m%d')                                                           JOJE_DATE          ");
		sql.append("         , A.DRG_BUNHO                                                                                 DRG_BUNHO          ");
		sql.append("         , PKG_IFS_BAS_FN_LOAD_MAPPED_CODE(:hospitalCode, 'IF_JIH_GWA', A.JUBSU_DATE, A.GWA, 'IF')     GWA                ");
		sql.append("         , A.BUNHO                                                                                     BUNHO              ");
		sql.append("         , B.SUNAME                                                                                    PAT_NAME           ");
		sql.append("         , DATE_FORMAT(B.BIRTH, '%Y%m%d')                                                              BIRTHDAY           ");
		sql.append("         , PKG_IFS_BAS_FN_LOAD_MAPPED_CODE(:hospitalCode, 'IF_JIH_SEX', A.JUBSU_DATE, B.SEX, 'IF')     SEX                ");
		sql.append("         , PKG_IFS_BAS_FN_LOAD_IF_CONSTANT(:hospitalCode, 'IF_JIH_CONSTANT', 'CANCER_FLAG_N')          CANCER_FLAG        ");
		sql.append("         , PKG_IFS_BAS_FN_LOAD_IF_CONSTANT(:hospitalCode, 'IF_JIH_CONSTANT', 'REC_GUBUN_MEMO')         REC_GUBUN_MEMO     ");
		sql.append("         , C.DRG_REMARK                                                                                PAT_MEMO           ");
		sql.append("         , PKG_IFS_BAS_FN_LOAD_IF_CONSTANT(:hospitalCode, 'IF_JIH_CONSTANT', 'REC_GUBUN_DRGUSER')      REC_GUBUN_DRGUSER  ");
		sql.append("         , FN_ADM_LOAD_USER_NAME(A.MAGAM_USER, :hospitalCode)                                            DRGUSER_NAME       ");
		sql.append("         , PKG_IFS_BAS_FN_LOAD_IF_CONSTANT(:hospitalCode, 'IF_JIH_CONSTANT', 'REC_GUBUN_DOCTOR')       REC_GUBUN_DOCTOR   ");
		sql.append("         , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.JUBSU_DATE, :hospitalCode)                              DOCTOR_NAME        ");
		sql.append("      FROM DRG3010 A                                                                                                      ");
		sql.append("          LEFT JOIN DRG9041 C ON C.HOSP_CODE = A.HOSP_CODE AND C.BUNHO = A.BUNHO                                          ");
		sql.append("           INNER JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                        ");
		sql.append("     WHERE A.HOSP_CODE     = :hospitalCode                                                                                ");
		sql.append("       AND A.FKJIHKEY      = :fkdrg                                                                                       ");
		sql.append("       AND A.FKOCS1003     = (SELECT MAX(D.FKOCS2003)                                                                     ");
		sql.append("                                FROM DRG3010 D                                                                            ");
		sql.append("                               WHERE D.HOSP_CODE  = :hospitalCode                                                         ");
		sql.append("                                 AND D.FKJIHKEY   = :fkdrg);                                                              ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("fkdrg", fkdrg);
		List<PrJihDrgIfsProcInfo> list = new JpaResultMapper().list(query, PrJihDrgIfsProcInfo.class);
		return list;


	}

	@Override
	public List<PrJihDrgIfsProcPatientInfo> getPrJihDrgIfsProcPatientInInfo(String hospitalCode, String bunho, Double fkdrg) {

		StringBuilder sql = new StringBuilder();
		sql.append("SELECT PKG_IFS_BAS_FN_LOAD_IF_CONSTANT(:hospitalCode, 'IF_JIH_CONSTANT', 'REC_GUBUN_DRG')                  REC_GUBUN_DRG                          ");
		sql.append("       , O.YJ_CODE                                                                                             DRG_CODE                           ");
		sql.append("       , IF(SUBSTR(B.ORDER_GUBUN, 2)='D', '0', B.SURYANG )                                                     SURYANG                            ");
		sql.append("       , PKG_IFS_BAS_FN_LOAD_MAPPED_CODE(:hospitalCode, 'IF_JIH_DRG_TYPE', A.JUBSU_DATE, B.ORD_DANUI, 'IF')    DRG_TYPE                           ");
		sql.append("       , PKG_IFS_BAS_FN_LOAD_MAPPED_CODE(:hospitalCode, 'IF_JIH_BOGYONG_CODE', A.JUBSU_DATE, B.BOGYONG_CODE, 'IF')  BOGYONG_CODE                  ");
		sql.append("       , IF(SUBSTR(B.ORDER_GUBUN, 2) = 'D', '0', IF(IFNULL(FN_DRG_LOAD_DONBOK_YN(B.BOGYONG_CODE, :hospitalCode), 'N')='Y', B.DV, B.NALSU )) NALSU ");
		sql.append("    FROM OCS2003 B                                                                                                                                ");
		sql.append("       , DRG2010 A                                                                                                                                ");
		sql.append("       , DRG3010 O                                                                                                                                ");
		sql.append("   WHERE A.HOSP_CODE   = :hospitalCode                                                                                                            ");
		sql.append("     AND A.BUNHO       = :bunho                                                                                                                   ");
		sql.append("     AND A.FKJIHKEY    = :fkdrg                                                                                                                   ");
		sql.append("     AND B.HOSP_CODE   = A.HOSP_CODE                                                                                                              ");
		sql.append("     AND B.PKOCS2003   = A.FKOCS2003                                                                                                              ");
		sql.append("     AND O.HOSP_CODE    = A.HOSP_CODE                                                                                                             ");
		sql.append("     AND O.HANGMOG_CODE = A.JAERYO_CODE                                                                                                           ");
		sql.append("     AND A.JUBSU_DATE   BETWEEN O.START_DATE AND O.END_DATE;                                                                                      ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("bunho", bunho);
		query.setParameter("fkdrg", fkdrg);
		List<PrJihDrgIfsProcPatientInfo> list = new JpaResultMapper().list(query, PrJihDrgIfsProcPatientInfo.class);
		return list;

	}
	
	@Override
	public List<DRG9040U01GrdJUSAOrderListInfo> getDRG9040U01GrdJUSAOrderListInfo(String hospCode, String language, String jubsuDate, String drgBunho, String magambunryu){
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.ORDER_DATE            ORDER_DATE                                                                                                               ");
		sql.append("      ,A.GROUP_SER             GROUP_SER                                                                                                                ");
		sql.append("      ,A.JAERYO_CODE           JAERYO_CODE                                                                                                              ");
		sql.append("      ,B.JAERYO_NAME           JAERYO_NAME                                                                                                              ");
		sql.append("      ,A.ORD_SURYANG           ORD_SURYANG                                                                                                              ");
		sql.append("      ,A.DV_TIME               DV_TIME                                                                                                                  ");
		sql.append("      ,A.DV                    DV                                                                                                                       ");
		sql.append("      ,A.NALSU                 NALSU                                                                                                                    ");
		sql.append("      ,A.ORDER_DANUI           ORDER_DANUI                                                                                                              ");
		sql.append("      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI,:f_hosp_code, :f_language) DANUI_NAME                                                           ");
		sql.append("      ,A.BOGYONG_CODE          BOGYONG_CODE                                                                                                             ");
		sql.append("      ,C.BOGYONG_NAME          BOGYONG_NAME                                                                                                             ");
		sql.append("      ,A.POWDER_YN             POWDER_YN                                                                                                                ");
		sql.append("      ,A.REMARK                REMARK                                                                                                                   ");
		sql.append("      ,A.DV_1                  DV_1                                                                                                                     ");
		sql.append("      ,A.DV_2                  DV_2                                                                                                                     ");
		sql.append("      ,A.DV_3                  DV_3                                                                                                                     ");
		sql.append("      ,A.DV_4                  DV_4                                                                                                                     ");
		sql.append("      ,A.DV_5                  DV_5                                                                                                                     ");
		sql.append("      ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN                                                                                                          ");
		sql.append("      ,A.PHARMACY              PHARMACY                                                                                                                 ");
		sql.append("      ,A.DRG_PACK_YN           DRG_PACK_YN                                                                                                              ");
		sql.append("      ,F.CODE_NAME             JUSA                                                                                                                     ");
		sql.append("      ,D.SUNAME                SUNAME                                                                                                                   ");
		sql.append("      ,E.ORDER_REMARK          ORDER_REMARK                                                                                                             ");
		sql.append("      ,E.DRG_REMARK            DRG_REMARK                                                                                                               ");
		sql.append("      ,A.DRG_BUNHO             DRG_BUNHO                                                                                                                ");
		sql.append("      ,A.JUBSU_DATE            JUBSU_DATE                                                                                                               ");
		sql.append("      ,A.BUNHO                 BUNHO                                                                                                                    ");
		sql.append("      ,A.FKOCS2003             FKOCS2003                                                                                                                ");
		sql.append("  FROM DRG3010 A LEFT JOIN DRG0120 C ON C.BOGYONG_CODE = A.BOGYONG_CODE AND :f_hosp_code = A.HOSP_CODE AND C.LANGUAGE = :f_language AND C.HOSP_CODE = :f_hosp_code   ");
		sql.append("                 LEFT JOIN DRG9042 E ON E.IN_OUT_GUBUN = 'I' AND E.FKOCS = A.FKOCS2003 AND E.HOSP_CODE = A.HOSP_CODE                                    ");
		sql.append("                 LEFT JOIN OCS0132 F ON F.CODE_TYPE = 'JUSA' AND F.CODE = A.JUSA                                                                        ");
		sql.append("                 JOIN OUT0101 D ON D.BUNHO = A.BUNHO AND D.HOSP_CODE = A.HOSP_CODE                                                                      ");
		sql.append("                 JOIN INV0110 B ON B.JAERYO_CODE = A.JAERYO_CODE AND B.HOSP_CODE = A.HOSP_CODE                                                          ");
		sql.append(" WHERE A.JUBSU_DATE           = STR_TO_DATE(:f_jubsu_date,'%Y/%m/%d')                                                                                   ");
		sql.append("   AND A.DRG_BUNHO            = :f_drg_bunho                                                                                                            ");
		sql.append("   AND A.HOSP_CODE            = :f_hosp_code                                                                                                            ");
		sql.append("   AND A.BUNRYU1              IN ('1','6')                                                                                                              ");
		sql.append("   AND IFNULL(A.DC_YN,'N')       = 'N'                                                                                                                  ");
		sql.append("   AND IFNULL(A.BANNAB_YN,'N')   = 'N'                                                                                                                  ");
		sql.append("   AND :f_magam_bunryu        = '1'                                                                                                                     ");
		sql.append("UNION ALL                                                                                                                                               ");
		sql.append("SELECT A.ORDER_DATE            ORDER_DATE                                                                                                               ");
		sql.append("      ,A.GROUP_SER             GROUP_SER                                                                                                                ");
		sql.append("      ,A.JAERYO_CODE           JAERYO_CODE                                                                                                              ");
		sql.append("      ,B.JAERYO_NAME           JAERYO_NAME                                                                                                              ");
		sql.append("      ,A.ORD_SURYANG           ORD_SURYANG                                                                                                              ");
		sql.append("      ,A.DV_TIME               DV_TIME                                                                                                                  ");
		sql.append("      ,A.DV                    DV                                                                                                                       ");
		sql.append("      ,A.NALSU                 NALSU                                                                                                                    ");
		sql.append("      ,A.ORDER_DANUI           ORDER_DANUI                                                                                                              ");
		sql.append("      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI,:f_hosp_code, :f_language) DANUI_NAME                                                           ");
		sql.append("      ,A.BOGYONG_CODE          BOGYONG_CODE                                                                                                             ");
		sql.append("      ,CONCAT(A.BOGYONG_CODE , ' ' , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'),:f_hosp_code, :f_language))     BOGYONG_NAME   ");
		sql.append("      ,A.POWDER_YN             POWDER_YN                                                                                                                ");
		sql.append("      ,A.REMARK                REMARK                                                                                                                   ");
		sql.append("      ,A.DV_1                  DV_1                                                                                                                     ");
		sql.append("      ,A.DV_2                  DV_2                                                                                                                     ");
		sql.append("      ,A.DV_3                  DV_3                                                                                                                     ");
		sql.append("      ,A.DV_4                  DV_4                                                                                                                     ");
		sql.append("      ,A.DV_5                  DV_5                                                                                                                     ");
		sql.append("      ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN                                                                                                          ");
		sql.append("      ,A.PHARMACY              PHARMACY                                                                                                                 ");
		sql.append("      ,A.DRG_PACK_YN           DRG_PACK_YN                                                                                                              ");
		sql.append("      ,F.CODE_NAME             JUSA                                                                                                                     ");
		sql.append("      ,D.SUNAME                SUNAME                                                                                                                   ");
		sql.append("      ,E.ORDER_REMARK          ORDER_REMARK                                                                                                             ");
		sql.append("      ,E.DRG_REMARK            DRG_REMARK                                                                                                               ");
		sql.append("      ,A.DRG_BUNHO             DRG_BUNHO                                                                                                                ");
		sql.append("      ,A.JUBSU_DATE            JUBSU_DATE                                                                                                               ");
		sql.append("      ,A.BUNHO                 BUNHO                                                                                                                    ");
		sql.append("     , A.FKOCS2003             FKOCS2003                                                                                                                ");
		sql.append("  FROM DRG3010 A LEFT JOIN DRG0120 C ON C.BOGYONG_CODE = A.BOGYONG_CODE AND :f_hosp_code = A.HOSP_CODE AND C.LANGUAGE = :f_language  AND C.HOSP_CODE = :f_hosp_code                    ");
		sql.append("                 LEFT JOIN DRG9042 E ON E.IN_OUT_GUBUN = 'I' AND E.FKOCS = A.FKOCS2003 AND E.HOSP_CODE = A.HOSP_CODE                                    ");
		sql.append("                 LEFT JOIN OCS0132 F ON F.CODE_TYPE = 'JUSA' AND F.CODE = A.JUSA                                                                        ");
		sql.append("                 JOIN OUT0101 D ON D.BUNHO = A.BUNHO AND D.HOSP_CODE = A.HOSP_CODE                                                                      ");
		sql.append("                 JOIN INV0110 B ON B.JAERYO_CODE = A.JAERYO_CODE AND B.HOSP_CODE = A.HOSP_CODE                                                          ");
		sql.append(" WHERE A.JUBSU_DATE           = STR_TO_DATE(:f_jubsu_date,'%Y/%m/%d')                                                                                   ");
		sql.append("   AND A.DRG_BUNHO            = :f_drg_bunho                                                                                                            ");
		sql.append("   AND A.HOSP_CODE            = :f_hosp_code                                                                                                            ");
		sql.append("   AND A.BUNRYU1              IN ('4')                                                                                                                  ");
		sql.append("   AND IFNULL(A.DC_YN,'N')       = 'N'                                                                                                                  ");
		sql.append("   AND IFNULL(A.BANNAB_YN,'N')   = 'N'                                                                                                                  ");
		sql.append("   AND :f_magam_bunryu        = '2'                                                                                                                     ");
		sql.append(" ORDER BY 3, 11, 1 DESC                                                                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_magam_bunryu", magambunryu);
		List<DRG9040U01GrdJUSAOrderListInfo> list = new JpaResultMapper().list(query, DRG9040U01GrdJUSAOrderListInfo.class);
		return list;
	}
	
	@Override
	public List<DRG9040U01GrdOrderInfo> getDRG9040U01GrdOrderInfo(String hospCode, String bunho, String fromDate, String toDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.JUBSU_DATE               JUBSU_DATE                                                                                                                ");
		sql.append("      ,A.DRG_BUNHO                DRG_BUNHO                                                                                                                 ");
		sql.append("      ,MAX(A.BUNHO)               BUNHO                                                                                                                     ");
		sql.append("      ,MAX(A.ORDER_DATE)          ORDER_DATE                                                                                                                ");
		sql.append("      ,MAX(A.RESIDENT)            DOCTOR                                                                                                                    ");
		sql.append("      ,MAX(C.DOCTOR_NAME)         DOCTOR_NAME                                                                                                               ");
		sql.append("      ,MAX(A.GWA)                 GWA                                                                                                                       ");
		sql.append("      ,MAX(B.BUSEO_NAME)          BUSEO_NAME                                                                                                                ");
		sql.append("      ,MAX(D.ORDER_REMARK)        ORDER_REMARK                                                                                                              ");
		sql.append("      ,MAX(D.DRG_REMARK)          DRG_REMARK                                                                                                                ");
		sql.append("      ,MAX(A.MAGAM_GUBUN)         MAGAM_GUBUN                                                                                                               ");
		sql.append("      ,MAX(A.BUNRYU1)             BUNRYU1                                                                                                                   ");
		sql.append("  FROM DRG3010 A LEFT JOIN VW_GWA_NAME B ON B.BUSEO_CODE = A.GWA AND B.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("                  LEFT JOIN BAS0270 C ON C.DOCTOR = A.RESIDENT AND C.HOSP_CODE = A.HOSP_CODE                                                                ");
		sql.append("                  LEFT JOIN DRG9040 D ON D.IN_OUT_GUBUN = 'I' AND D.JUBSU_DATE = A.JUBSU_DATE AND D.DRG_BUNHO = A.DRG_BUNHO AND D.HOSP_CODE = A.HOSP_CODE   ");
		sql.append(" WHERE A.JUBSU_DATE BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')                                                     ");
		sql.append("   AND A.BUNHO                    = :f_bunho                                                                                                                ");
		sql.append("   AND A.HOSP_CODE                = :f_hosp_code                                                                                                            ");
		sql.append("   AND A.CHULGO_DATE              IS NOT NULL                                                                                                               ");
		sql.append("   AND IFNULL(A.DC_YN,'N')           <> 'Y'                                                                                                                 ");
		sql.append("   AND A.SOURCE_FKOCS2003         IS NULL                                                                                                                   ");
		sql.append(" GROUP BY A.BUNHO,  A.DRG_BUNHO, A.JUBSU_DATE                                                                                                               ");
		sql.append(" ORDER BY 1 DESC, 1                                                                                                                                         ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		List<DRG9040U01GrdOrderInfo> list = new JpaResultMapper().list(query, DRG9040U01GrdOrderInfo.class);
		return list;
	}
	
	@Override
	public List<DRG9040U01GrdOrderListInfo> getDRG9040U01GrdOrderListInfo(String hospCode, String language, String jubsuDate, String drgBunho, String magambunryu){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.ORDER_DATE            ORDER_DATE                                                                                                            ");
		sql.append("      ,A.GROUP_SER             GROUP_SER                                                                                                             ");
		sql.append("      ,A.JAERYO_CODE           JAERYO_CODE                                                                                                           ");
		sql.append("      ,B.JAERYO_NAME           JAERYO_NAME                                                                                                           ");
		sql.append("      ,A.ORD_SURYANG           ORD_SURYANG                                                                                                           ");
		sql.append("      ,A.DV_TIME               DV_TIME                                                                                                               ");
		sql.append("      ,A.DV                    DV                                                                                                                    ");
		sql.append("      ,A.NALSU                 NALSU                                                                                                                 ");
		sql.append("      ,A.ORDER_DANUI           ORDER_DANUI                                                                                                           ");
		sql.append("      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI,:f_hosp_code,:f_language) DANUI_NAME                                                         ");
		sql.append("      ,A.BOGYONG_CODE          BOGYONG_CODE                                                                                                          ");
		sql.append("      ,C.BOGYONG_NAME          BOGYONG_NAME                                                                                                          ");
		sql.append("      ,A.POWDER_YN             POWDER_YN                                                                                                             ");
		sql.append("      ,A.REMARK                REMARK                                                                                                                ");
		sql.append("      ,A.DV_1                  DV_1                                                                                                                  ");
		sql.append("      ,A.DV_2                  DV_2                                                                                                                  ");
		sql.append("      ,A.DV_3                  DV_3                                                                                                                  ");
		sql.append("      ,A.DV_4                  DV_4                                                                                                                  ");
		sql.append("      ,A.DV_5                  DV_5                                                                                                                  ");
		sql.append("      ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN                                                                                                       ");
		sql.append("      ,A.PHARMACY              PHARMACY                                                                                                              ");
		sql.append("      ,A.DRG_PACK_YN           DRG_PACK_YN                                                                                                           ");
		sql.append("      ,A.JUSA                  JUSA                                                                                                                  ");
		sql.append("      ,D.SUNAME                SUNAME                                                                                                                ");
		sql.append("      ,E.ORDER_REMARK          ORDER_REMARK                                                                                                          ");
		sql.append("      ,E.DRG_REMARK            DRG_REMARK                                                                                                            ");
		sql.append("      ,A.DRG_BUNHO             DRG_BUNHO                                                                                                             ");
		sql.append("      ,A.JUBSU_DATE            JUBSU_DATE                                                                                                            ");
		sql.append("      ,A.BUNHO                 BUNHO                                                                                                                 ");
		sql.append("      ,A.FKOCS2003             FKOCS2003                                                                                                             ");
		sql.append("  FROM DRG3010 A JOIN INV0110 B ON B.JAERYO_CODE = A.JAERYO_CODE AND B.HOSP_CODE = A.HOSP_CODE                                                       ");
		sql.append("                 LEFT JOIN DRG0120 C ON C.BOGYONG_CODE = A.BOGYONG_CODE AND :f_hosp_code = A.HOSP_CODE   AND C.LANGUAGE = :f_language   AND C.HOSP_CODE = :f_hosp_code              ");
		sql.append("                 JOIN OUT0101 D ON D.BUNHO = A.BUNHO AND D.HOSP_CODE = A.HOSP_CODE                                                                   ");
		sql.append("                 LEFT JOIN DRG9042 E ON E.IN_OUT_GUBUN = 'I' AND E.FKOCS = A.FKOCS2003 AND E.HOSP_CODE = A.HOSP_CODE                                 ");
		sql.append(" WHERE A.HOSP_CODE            = :f_hosp_code                                                                                                         ");
		sql.append("   AND A.JUBSU_DATE           = STR_TO_DATE(:f_jubsu_date,'%Y/%m/%d')                                                                                ");
		sql.append("   AND A.DRG_BUNHO            = :f_drg_bunho                                                                                                         ");
		sql.append("   AND A.BUNRYU1              IN ('1','6')                                                                                                           ");
		sql.append("   AND IFNULL(A.DC_YN,'N')       = 'N'                                                                                                               ");
		sql.append("   AND IFNULL(A.BANNAB_YN,'N')   = 'N'                                                                                                               ");
		sql.append("   AND :f_magam_bunryu        = '1'                                                                                                                  ");
		sql.append("UNION ALL                                                                                                                                            ");
		sql.append("SELECT A.ORDER_DATE            ORDER_DATE                                                                                                            ");
		sql.append("      ,A.GROUP_SER             GROUP_SER                                                                                                             ");
		sql.append("      ,A.JAERYO_CODE           JAERYO_CODE                                                                                                           ");
		sql.append("      ,B.JAERYO_NAME           JAERYO_NAME                                                                                                           ");
		sql.append("      ,A.ORD_SURYANG           ORD_SURYANG                                                                                                           ");
		sql.append("      ,A.DV_TIME               DV_TIME                                                                                                               ");
		sql.append("      ,A.DV                    DV                                                                                                                    ");
		sql.append("      ,A.NALSU                 NALSU                                                                                                                 ");
		sql.append("      ,A.ORDER_DANUI           ORDER_DANUI                                                                                                           ");
		sql.append("      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI,:f_hosp_code,:f_language) DANUI_NAME                                                         ");
		sql.append("      ,A.BOGYONG_CODE          BOGYONG_CODE                                                                                                          ");
		sql.append("      ,CONCAT(A.BOGYONG_CODE , ' ' , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'),:f_hosp_code,:f_language))     BOGYONG_NAME ");
		sql.append("      ,A.POWDER_YN             POWDER_YN                                                                                                             ");
		sql.append("      ,A.REMARK                REMARK                                                                                                                ");
		sql.append("      ,A.DV_1                  DV_1                                                                                                                  ");
		sql.append("      ,A.DV_2                  DV_2                                                                                                                  ");
		sql.append("      ,A.DV_3                  DV_3                                                                                                                  ");
		sql.append("      ,A.DV_4                  DV_4                                                                                                                  ");
		sql.append("      ,A.DV_5                  DV_5                                                                                                                  ");
		sql.append("      ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN                                                                                                       ");
		sql.append("      ,A.PHARMACY              PHARMACY                                                                                                              ");
		sql.append("      ,A.DRG_PACK_YN           DRG_PACK_YN                                                                                                           ");
		sql.append("      ,A.JUSA                  JUSA                                                                                                                  ");
		sql.append("      ,D.SUNAME                SUNAME                                                                                                                ");
		sql.append("      ,E.ORDER_REMARK          ORDER_REMARK                                                                                                          ");
		sql.append("      ,E.DRG_REMARK            DRG_REMARK                                                                                                            ");
		sql.append("      ,A.DRG_BUNHO             DRG_BUNHO                                                                                                             ");
		sql.append("      ,A.JUBSU_DATE            JUBSU_DATE                                                                                                            ");
		sql.append("      ,A.BUNHO                 BUNHO                                                                                                                 ");
		sql.append("     , A.FKOCS2003             FKOCS2003                                                                                                             ");
		sql.append("  FROM DRG3010 A JOIN INV0110 B ON B.JAERYO_CODE = A.JAERYO_CODE AND B.HOSP_CODE = A.HOSP_CODE                                                       ");
		sql.append("                 LEFT JOIN DRG0120 C ON C.BOGYONG_CODE = A.BOGYONG_CODE AND :f_hosp_code = A.HOSP_CODE AND C.LANGUAGE = :f_language   AND C.HOSP_CODE = :f_hosp_code                ");
		sql.append("                 JOIN OUT0101 D ON D.BUNHO = A.BUNHO AND D.HOSP_CODE = A.HOSP_CODE                                                                   ");
		sql.append("                 LEFT JOIN DRG9042 E ON E.IN_OUT_GUBUN = 'I' AND E.FKOCS = A.FKOCS2003 AND E.HOSP_CODE = A.HOSP_CODE                                 ");
		sql.append(" WHERE A.HOSP_CODE            = :f_hosp_code                                                                                                         ");
		sql.append("   AND A.JUBSU_DATE           = STR_TO_DATE(:f_jubsu_date,'%Y/%m/%d')                                                                                ");
		sql.append("   AND A.DRG_BUNHO            = :f_drg_bunho                                                                                                         ");
		sql.append("   AND A.BUNRYU1              IN ('4')                                                                                                               ");
		sql.append("   AND IFNULL(A.DC_YN,'N')       = 'N'                                                                                                               ");
		sql.append("   AND IFNULL(A.BANNAB_YN,'N')   = 'N'                                                                                                               ");
		sql.append("   AND :f_magam_bunryu        = '2'                                                                                                                  ");
		sql.append(" ORDER BY 3, 11, 1 DESC                                                                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_magam_bunryu", magambunryu);
		List<DRG9040U01GrdOrderListInfo> list = new JpaResultMapper().list(query, DRG9040U01GrdOrderListInfo.class);
		return list;
	}

	@Override
	public List<OCS2003U03getJusaInfo> getOCS2003U03getJusaInfo(String hospCode, String language, String serialText, String JubsuDate, String drgBunho, boolean isGetRemark) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.JAERYO_CODE                                        JAERYO_CODE																				");
		sql.append("	  ,A.NALSU                                              NALSU																					");
		sql.append("	  ,A.DIVIDE                                             DIVIDE																					");
		sql.append("	  ,A.ORDER_SURYANG                                      ORDER_SURYANG																			");
		sql.append("	  ,A.SUBUL_SURYANG                                      SUBUL_SURYANG																			");
		sql.append("	  ,A.ORD_SURYANG                                        ORD_SURYANG																				");
		sql.append("	  ,A.ORDER_DANUI                                        ORDER_DANUI																				");
		sql.append("	  ,A.SUBUL_DANUI                                        SUBUL_DANUI																				");
		sql.append("	  ,A.BUNRYU1                                            BUNRYU1																					");
		sql.append("	  ,A.BUNRYU2                                            BUNRYU2																					");
		sql.append("	  ,A.BUNRYU3                                            BUNRYU3																					");
		sql.append("	  ,A.BUNRYU4                                            BUNRYU4																					");
		sql.append("	  ,TRIM(C.ORDER_REMARK)                                 REMARK																					");
		sql.append("	  ,A.DV_TIME                                            DV_TIME																					");
		sql.append("	  ,A.DV                                                 DV																						");
		sql.append("	  ,A.BUNRYU6                                            BUNRYU6																					");
		sql.append("	  ,A.MIX_GROUP                                          MIX_GROUP																				");
		sql.append("	  ,A.DV_1                                               DV_1																					");
		sql.append("	  ,A.DV_2                                               DV_2																					");
		sql.append("	  ,A.DV_3                                               DV_3																					");
		sql.append("	  ,A.DV_4                                               DV_4																					");
		sql.append("	  ,A.DV_5                                               DV_5																					");
		sql.append("	  ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN																			");
		sql.append("	  ,A.PHARMACY                                           PHARMACY																				");
		sql.append("	  ,A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN																			");
		sql.append("	  ,A.DRG_PACK_YN                                        DRG_PACK_YN																				");
		sql.append("	  ,A.JUSA                                               JUSA																					");
		sql.append("	  ,B.HANGMOG_NAME                                       JAERYO_NAME																				");
		sql.append("	  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)    DANUI_NAME													");
		sql.append("	  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language)    SUBUL_DANUI_NAME												");
		sql.append("	  ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)        JUSA_NAME													");
		sql.append("	  ,CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))    BOGYONG_NAME ");
		sql.append("	  ,FN_DRG_LOAD_NALSU_CNT(:f_hosp_code, A.BUNHO, A.ORDER_DATE, 'I', A.JAERYO_CODE)                               JUSA_NALSU						");
		sql.append("	  ,'A'                                                                                            DATA_GUBUN									");
		sql.append("	  ,IFNULL(D.ACT_JAERYO_NAME,B.HANGMOG_NAME)                HODONG_ORD_NAME																		");
		sql.append("	  ,CONCAT(TRIM(E.SERIAL_V), TRIM(A.GROUP_SER), IFNULL(A.MIX_GROUP, ' '),																		");
		sql.append("	   TRIM(IF(C.BOM_OCCUR_YN = 'Y', C.SEQ + 100, C.SEQ)),																							");
		sql.append("	   TRIM(C.PKOCS2003))            DATA_KEY																										");
		sql.append("	  ,(SELECT MAX(IFNULL(X.BANNAB_YN,'N'))																											");
		sql.append("			  FROM DRG3010 X																														");
		sql.append("				 , DRG2035 Y																														");
		sql.append("			 WHERE Y.HOSP_CODE  = :f_hosp_code																										");
		sql.append("			   AND Y.JUBSU_DATE = E.JUBSU_DATE																										");
		sql.append("			   AND Y.DRG_BUNHO  = E.DRG_BUNHO												l														");
		sql.append("			   AND Y.SERIAL_V   = E.SERIAL_V																										");
		sql.append("			   AND Y.FKOCS2003  = X.FKOCS2003																										");
		sql.append("			   AND X.HOSP_CODE  = Y.HOSP_CODE)              MAX_BANNAB_YN																			");
		sql.append("	  ,A.BANNAB_YN                                          BANNAB_YN																				");
		sql.append("	  ,A.FKOCS2003                                          FKOCS2003																				");
		sql.append("  FROM DRG3010 A 																																	");
		sql.append("  JOIN DRG2035 E ON  E.HOSP_CODE          = A.HOSP_CODE																								");
		sql.append("				 AND E.JUBSU_DATE         = A.JUBSU_DATE																							");
		sql.append("				 AND E.DRG_BUNHO          = A.DRG_BUNHO																								");
		sql.append("				 AND E.FKOCS2003          = A.FKOCS2003																								");
		sql.append("				 AND E.SERIAL_V           = :f_serial_text																							");
		sql.append("	LEFT JOIN INV0110 D 																															");
		sql.append("                 ON  D.HOSP_CODE          = A.HOSP_CODE																								");
		sql.append("				 AND D.JAERYO_CODE     	  = A.JAERYO_CODE																							");
		sql.append("			 JOIN OCS2003 C 																														");
		sql.append("                 ON     C.HOSP_CODE       = A.HOSP_CODE																								");
		sql.append("				 AND C.PKOCS2003          = A.FKOCS2003 																							");
		sql.append("			 JOIN OCS0103 B 																														");
		sql.append("                 ON  B.HOSP_CODE          = C.HOSP_CODE																								");
		sql.append("				 AND B.HANGMOG_CODE       = C.HANGMOG_CODE	  																						");
		sql.append(" WHERE A.JUBSU_DATE         = :f_jubsu_date																											");
		sql.append("   AND A.HOSP_CODE          = :f_hosp_code																											");
		sql.append("   AND A.DRG_BUNHO          = :f_drg_bunho																											");
		sql.append("   AND A.BUNRYU1            IN ('4')																												");
		if (isGetRemark) 
			sql.append("   AND C.ORDER_REMARK IS NOT NULL																												");
		sql.append(" ORDER BY CONCAT(TRIM(E.SERIAL_V), TRIM(A.GROUP_SER),IFNULL(A.MIX_GROUP, ' '),																		");
		sql.append("	   TRIM(IF(C.BOM_OCCUR_YN = 'Y', C.SEQ + 100, C.SEQ)),																							");
		sql.append("	   TRIM(C.PKOCS2003))																															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_serial_text", serialText);
		query.setParameter("f_jubsu_date", DateUtil.toDate(JubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_drg_bunho", CommonUtils.parseDouble(drgBunho));
		List<OCS2003U03getJusaInfo> list = new JpaResultMapper().list(query, OCS2003U03getJusaInfo.class);
		return list;
	}

	@Override
	public List<OCS2003U03getJusaInfo> getOCS2003U03getJusaInfoExt(String hospCode, String language, String serialV,
			String fkocs2003) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.JAERYO_CODE                                        JAERYO_CODE																									");
		sql.append("	  ,A.NALSU                                              NALSU																										");
		sql.append("	  ,A.DIVIDE                                             DIVIDE																										");
		sql.append("	  ,A.ORDER_SURYANG                                      ORDER_SURYANG																								");
		sql.append("	  ,A.SUBUL_SURYANG                                      SUBUL_SURYANG																								");
		sql.append("	  ,CASE WHEN A.NALSU < 0 THEN CONCAT('-', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)	");
		sql.append("							  ELSE CONCAT('', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)	");
		sql.append("							  END                                                                 ORD_SURYANG															");
		sql.append("	  ,A.ORDER_DANUI                                        ORDER_DANUI																									");
		sql.append("	  ,A.SUBUL_DANUI                                        SUBUL_DANUI																									");
		sql.append("	  ,A.BUNRYU1                                            BUNRYU1																										");
		sql.append("	  ,A.BUNRYU2                                            BUNRYU2																										");
		sql.append("	  ,A.BUNRYU3                                            BUNRYU3																										");
		sql.append("	  ,A.BUNRYU4                                            BUNRYU4																										");
		sql.append("	  ,TRIM(C.ORDER_REMARK)                                 REMARK																										");
		sql.append("	  ,A.DV_TIME                                            DV_TIME																										");
		sql.append("	  ,A.DV                                                 DV																											");
		sql.append("	  ,A.BUNRYU6                                            BUNRYU6																										");
		sql.append("	  ,A.MIX_GROUP                                          MIX_GROUP																									");
		sql.append("	  ,A.DV_1                                               DV_1																										");
		sql.append("	  ,A.DV_2                                               DV_2																										");
		sql.append("	  ,A.DV_3                                               DV_3																										");
		sql.append("	  ,A.DV_4                                               DV_4																										");
		sql.append("	  ,A.DV_5                                               DV_5																										");
		sql.append("	  ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN																								");
		sql.append("	  ,A.PHARMACY                                           PHARMACY																									");
		sql.append("	  ,A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN																								");
		sql.append("	  ,A.DRG_PACK_YN                                        DRG_PACK_YN																									");
		sql.append("	  ,A.JUSA                                               JUSA																										");
		sql.append("	  ,B.HANGMOG_NAME                                       JAERYO_NAME																									");
		sql.append("	  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)    DANUI_NAME																		");
		sql.append("	  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language)    SUBUL_DANUI_NAME																	");
		sql.append("	  ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)        JUSA_NAME																		");
		sql.append("	  ,CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))     BOGYONG_NAME					");
		sql.append("	  ,FN_DRG_LOAD_NALSU_CNT(A.BUNHO, A.ORDER_DATE, 'I', A.JAERYO_CODE)                               JUSA_NALSU														");
		sql.append("	  ,'A'                                                                                            DATA_GUBUN														");
		sql.append("	  ,IFNULL(D.ACT_JAERYO_NAME,B.HANGMOG_NAME)                HODONG_ORD_NAME																							");
		sql.append("	  ,CONCAT(TRIM(:f_serial_v), TRIM(A.GROUP_SER), IFNULL(A.MIX_GROUP, ' '),																							");
		sql.append("	   TRIM(IF(C.BOM_OCCUR_YN = 'Y', C.SEQ + 100, C.SEQ)),																												");
		sql.append("	   TRIM(C.PKOCS2003))            DATA_KEY																															");
		sql.append("	  ,IFNULL(A.BANNAB_YN,'N')                                 MAX_BANNAB_YN																							");
		sql.append("	  ,A.BANNAB_YN                                          BANNAB_YN																									");
		sql.append("	  ,A.FKOCS2003                                          FKOCS2003																									");
		sql.append("  FROM DRG3010 A																																						");
		sql.append("	  LEFT JOIN INV0110 D ON  D.HOSP_CODE          = A.HOSP_CODE																										");
		sql.append("						            AND D.JAERYO_CODE        = A.JAERYO_CODE																							");
		sql.append("	       JOIN OCS2003 C ON  C.HOSP_CODE          = A.HOSP_CODE																										");
		sql.append("						            AND C.PKOCS2003          = A.FKOCS2003																								");
		sql.append("	       JOIN OCS0103 B ON  B.HOSP_CODE          = C.HOSP_CODE																										");
		sql.append("                        AND B.HANGMOG_CODE       = C.HANGMOG_CODE	  																									");
		sql.append(" WHERE A.SOURCE_FKOCS2003   = :f_fkocs2003																																");
		sql.append("   AND A.HOSP_CODE          = :f_hosp_code  																															");
		sql.append(" ORDER BY A.FKOCS2003																																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_serial_v", serialV);
		query.setParameter("f_fkocs2003", CommonUtils.parseDouble(fkocs2003));
		List<OCS2003U03getJusaInfo> list = new JpaResultMapper().list(query, OCS2003U03getJusaInfo.class);
		return list;
	}

	@Override
	public List<OCS2003U03orderJungboInfo> getOCS2003U03orderJungboInfo(String hospCode, String language,
			String jubsuDate, String drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT                 SEQ_1																												            ");
		sql.append("			         , SEQ_2																												            ");
		sql.append("		   			 , TEXT_1																												            ");
		sql.append("					 , '' TEXT_2 																											            ");
		sql.append("					 , '' TEXT_3 																											            ");
		sql.append("					 , REMARK																												    		");
		sql.append("					 , BAR_DRG_BUNHO																												    ");
		sql.append("					 , BUNHO																												    		");
		sql.append("FROM (																																		            ");
		sql.append("SELECT '1'                SEQ_1																												            ");
		sql.append("	  ,D.SERIAL_V         SEQ_2																												            ");
		sql.append("	  ,C.JAERYO_NAME      TEXT_1																											            ");
		//sql.append("	  ,''                 TEXT_2																											            ");
		//sql.append("	  ,''                 TEXT_3																											            ");
		sql.append("	  ,IFNULL(REPLACE(REPLACE(B.ORDER_REMARK,CONCAT(CHAR(13),CHAR(10)),' '),CHAR(10),' '), '')     REMARK									            ");
		sql.append("	  ,CONCAT('*', DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), TRIM(A.DRG_BUNHO), '*')  BAR_DRG_BUNHO												            ");
		sql.append("	  ,A.BUNHO            BUNHO																												            ");
		sql.append("  FROM DRG3010 A																															            ");
		sql.append("    LEFT JOIN DRG2035 D 																													            ");
		sql.append("             ON  D.FKOCS2003    = A.FKOCS2003																								            ");
		sql.append("             AND D.HOSP_CODE    = A.HOSP_CODE																								            ");
		sql.append("	       JOIN INV0110 C																													            ");
		sql.append("             ON  C.JAERYO_CODE  = A.JAERYO_CODE																								            ");
		sql.append("             AND C.HOSP_CODE    = A.HOSP_CODE																								            ");
		sql.append("	       JOIN DRG9042 B																													            ");
		sql.append("             ON  B.FKOCS        = A.FKOCS2003																								            ");
		sql.append("             AND B.ORDER_REMARK IS NOT NULL																									            ");
		sql.append("             AND B.HOSP_CODE   = A.HOSP_CODE																								            ");
		sql.append(" WHERE A.JUBSU_DATE  = :f_jubsu_date																										            ");
		sql.append("   AND A.HOSP_CODE   = :f_hosp_code																											            ");
		sql.append("   AND A.DRG_BUNHO   = :f_drg_bunho																											            ");
		sql.append("UNION ALL																																	            ");
		sql.append("SELECT DISTINCT '1'       SEQ_1																												            ");
		sql.append("	  ,''                 SEQ_2																												            ");
		sql.append("	  ,C.JAERYO_NAME      TEXT_1																											            ");
		//sql.append("	  ,''                 TEXT_2																											            ");
		//sql.append("	  ,''                 TEXT_3																											            ");
		sql.append("	  ,IFNULL(CONCAT('[', FN_ADM_MSG('4111',:language), ']', REPLACE(REPLACE(C.DRG_COMMENT,CONCAT(CHAR(13),CHAR(10)),' '),CHAR(10),' ')), '')   REMARK	");
		sql.append("	  ,CONCAT('*', DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), TRIM(A.DRG_BUNHO), '*')  BAR_DRG_BUNHO												            ");
		sql.append("	  ,A.BUNHO            BUNHO																												            ");
		sql.append("  FROM DRG3010 A																															            ");
		sql.append("    LEFT JOIN DRG2035 D 																													            ");
		sql.append("             ON  D.FKOCS2003        = A.FKOCS2003																							            ");
		sql.append("             AND D.HOSP_CODE        = A.HOSP_CODE																							            ");
		sql.append("	       JOIN INV0110 C																													            ");
		sql.append("             ON C.JAERYO_CODE       = A.JAERYO_CODE																							            ");
		sql.append("             AND C.HOSP_CODE        = A.HOSP_CODE																							            ");
		sql.append("             AND IFNULL(C.CHKD,'N') = 'Y'																									            ");
		sql.append(" WHERE A.JUBSU_DATE  = :f_jubsu_date																										            ");
		sql.append("   AND A.HOSP_CODE   = :f_hosp_code																											            ");
		sql.append("   AND A.DRG_BUNHO   = :f_drg_bunho																											            ");
		sql.append("UNION ALL																																	            ");
		sql.append("SELECT DISTINCT																																            ");
		sql.append("	   '2'                SEQ_1																												            ");
		sql.append("	  ,''                 SEQ_2																												            ");
		sql.append("	  ,'##'               TEXT_1																											            ");
		//sql.append("	  ,''                 TEXT_2																											            ");
		//sql.append("	  ,''                 TEXT_3																											            ");
		sql.append("	  ,IFNULL(REPLACE(REPLACE(B.ORDER_REMARK,CONCAT(CHAR(13),CHAR(10)),' '),CHAR(10),' '), '')    REMARK									            ");
		sql.append("	  ,CONCAT('*', DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), TRIM(A.DRG_BUNHO), '*')  BAR_DRG_BUNHO												            ");
		sql.append("	  ,A.BUNHO            BUNHO																												            ");
		sql.append("  FROM DRG9040 B																															            ");
		sql.append("	  JOIN DRG3010 A																														            ");
		sql.append("        ON B.HOSP_CODE     = A.HOSP_CODE																									            ");
		sql.append("       AND B.JUBSU_DATE    = A.JUBSU_DATE																									            ");
		sql.append("       AND B.DRG_BUNHO     = A.DRG_BUNHO																									            ");
		sql.append("       AND B.ORDER_REMARK IS NOT NULL																										            ");
		sql.append(" WHERE A.JUBSU_DATE    = :f_jubsu_date																										            ");
		sql.append("   AND A.HOSP_CODE     = :f_hosp_code																										            ");
		sql.append("   AND A.DRG_BUNHO     = :f_drg_bunho																										            ");
		sql.append("UNION ALL																																	            ");
		sql.append("SELECT DISTINCT																																            ");
		sql.append("	   '3'                SEQ_1																												            ");
		sql.append("	  ,''                 SEQ_2																												            ");
		sql.append("	  ,'$$'               TEXT_1																											            ");
		//sql.append("	  ,''                 TEXT_2																											            ");
		//sql.append("	  ,''                 TEXT_3																											            ");
		sql.append("	  ,IFNULL(REPLACE(REPLACE(B.ORDER_REMARK,CONCAT(CHAR(13),CHAR(10)),' '),CHAR(10),' '), '')     REMARK									            ");
		sql.append("	  ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), TRIM(A.DRG_BUNHO),'*')  BAR_DRG_BUNHO													            ");
		sql.append("	  ,A.BUNHO            BUNHO																												            ");
		sql.append("  FROM DRG3010 A																															            ");
		sql.append("    LEFT JOIN DRG9041 B																														            ");
		sql.append("        ON B.HOSP_CODE    = A.HOSP_CODE																										            ");
		sql.append("       AND B.BUNHO        = A.BUNHO																											            ");
		sql.append("       AND B.ORDER_REMARK IS NOT NULL																										            ");
		sql.append(" WHERE A.JUBSU_DATE    = :f_jubsu_date																										            ");
		sql.append("   AND A.HOSP_CODE     = :f_hosp_code																										            ");
		sql.append("   AND A.DRG_BUNHO     = :f_drg_bunho																										            ");
		sql.append(" ) AA																																		            ");
		sql.append(" ORDER BY SEQ_1, SEQ_2																														            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_jubsu_date", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_drg_bunho", drgBunho);
		List<OCS2003U03orderJungboInfo> list = new JpaResultMapper().list(query, OCS2003U03orderJungboInfo.class);
		return list;
	}

	@Override
	public String getOCS2003U03getTocheckInfo(String hospCode, String jubsuDate, String drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), TRIM(A.DRG_BUNHO), '*') 	");
		sql.append("     FROM DRG3010 A 																	");
		sql.append("    WHERE A.HOSP_CODE   = :f_hosp_code 													");
		sql.append("      AND A.JUBSU_DATE  = :f_jubsu_date 												");
		sql.append("      AND A.DRG_BUNHO   = :f_drg_bunho 													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_drg_bunho", drgBunho);
				
		List<String> listDoctorName = query.getResultList();
		if(!CollectionUtils.isEmpty(listDoctorName)){
			return listDoctorName.get(0);
		}
		return null;
	}

	@Override
	public List<OCS2003U03getSysInfo> getOCS2003U03getSysInfo(String hospCode, String bunho, String comments) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(FN_NUR_LOAD_WEIGHT_HEIGHT('H', :o_bunho, :f_hosp_code), 0) HEIGHT				");
		sql.append("        	  ,'Cm'                                             CM    						");
		sql.append("        	  ,IFNULL(FN_NUR_LOAD_WEIGHT_HEIGHT('W', :o_bunho, :f_hosp_code), 0) WEIGHT		");
		sql.append("        	  ,'Kg'                                             KG							");
		sql.append("        	  ,FN_CPL_HANGMOG_RESULT(:o_bunho, '00077', :f_hosp_code)         CPL_RESULT	");
		sql.append("        	  ,IFNULL(FN_ADM_CONVERT_KATAKANA_FULL(:o_comments, :f_hosp_code), '')        COMMENTS		");
		sql.append("        	  ,FLOOR(LENGTH(IFNULL(:o_comments,' ')) / 80)         CNT						");
		sql.append("          FROM DUAL																			");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("o_bunho", bunho);
		query.setParameter("o_comments", comments);
		List<OCS2003U03getSysInfo> list = new JpaResultMapper().list(query, OCS2003U03getSysInfo.class);
		return list;
	}

	@Override
	public ComboListItemInfo callPrDrgInpMagamProc(String hospCode, String procGubun, String jubsuDate, String orderDate,
			String hopeDate, String magamGubun, String magamSer, String bunho, String doctor, String magamUser) {
		String oDrgBunho = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_INP_MAGAM_PROC");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PROC_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOPE_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MAGAM_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MAGAM_SER", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MAGAM_USER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_DRG_BUNHO", Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PROC_GUBUN", procGubun);
		query.setParameter("I_JUBSU_DATE", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_ORDER_DATE", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_HOPE_DATE", DateUtil.toDate(hopeDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_MAGAM_GUBUN", magamGubun);
		query.setParameter("I_MAGAM_SER", CommonUtils.parseInteger(magamSer));
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_DOCTOR", doctor);
		query.setParameter("I_MAGAM_USER", magamUser);
		query.setParameter("IO_ERR", oDrgBunho);
		
		query.execute();
		oDrgBunho = CommonUtils.parseString(((Integer) query.getOutputParameterValue("O_DRG_BUNHO")));
		String ioErr = (String) query.getOutputParameterValue("IO_ERR");
		return new ComboListItemInfo(oDrgBunho, ioErr);
	}

	@Override
	public String callFnDrgToiwonOrderChk(String hospCode, String toiwonDate, String bunho, String fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT FN_DRG_TOIWON_ORDER_CHK(:f_hosp_code, DATE(SYSDATE()), :f_bunho, :f_fkinp1001)			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<DRG3010Q12grdPalistInfo> getDRG3010Q12grdPalistInfo(String hospCode, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT                                                                                                        ");
		sql.append("	       E.HO_DONG1                                                                                                      ");
		sql.append("	     , E.HO_CODE1                                                                                                      ");
		sql.append("	     , E.BED_NO                                                                                                        ");
		sql.append("	     , E.BUNHO                                                                                                         ");
		sql.append("	     , E.SUNAME                                                                                                        ");
		sql.append("	     , E.PKINP1001                                                                                                     ");
		sql.append("	     , CONCAT(FN_BAS_LOAD_AGE(STR_TO_DATE('2013/09/20', '%Y/%m/%d'),E.BIRTH,''), '/', E.SEX)              AGE_SEX      ");
		sql.append("	     , E.IPWON_DATE                                                                                       IPWON_DATE   ");
		sql.append("	     , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(E.DOCTOR, STR_TO_DATE('2013/09/20', '%Y/%m/%d'), :f_hosp_code), '') DOCTOR_NAME  ");
		sql.append("	     , IFNULL(D.HO_SORT, '')                                                                                           ");
		sql.append("	  FROM BAS0250        D                                                                                                ");
		sql.append("	     , VW_OCS_INP1001 E                                                                                                ");
		sql.append("	     , (select @kcck_hosp_code \\:= :f_hosp_code) TMP	                                                               ");
		sql.append("	 WHERE E.HOSP_CODE       = :f_hosp_code                                                                                ");
		sql.append("	   AND E.HO_DONG1        LIKE :f_ho_dong                                                                               ");
		sql.append("	   AND D.HOSP_CODE       = E.HOSP_CODE                                                                                 ");
		sql.append("	   AND D.HO_DONG         = E.HO_DONG1                                                                                  ");
		sql.append("	   AND D.HO_CODE         = E.HO_CODE1                                                                                  ");
		sql.append("	   AND CURRENT_DATE()    BETWEEN D.START_DATE AND D.END_DATE                                                           ");
		sql.append("	 ORDER BY E.HO_DONG1, D.HO_SORT, E.BED_NO                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<DRG3010Q12grdPalistInfo> list = new JpaResultMapper().list(query, DRG3010Q12grdPalistInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getHoDongGwaName(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '%'                           ");
		sql.append("	     , FN_ADM_MSG(221, :f_language)  ");
		sql.append("	FROM DUAL                            ");
		sql.append("	UNION ALL                            ");
		sql.append("	                                     ");
		sql.append("	SELECT DISTINCT                      ");
		sql.append("	       A.HO_DONG                     ");
		sql.append("	     , B.GWA_NAME                    ");
		sql.append("	  FROM DRG3010 A, BAS0260 B          ");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code   ");
		sql.append("	   AND B.LANGUAGE   = :f_language    ");
		sql.append("	   AND B.HOSP_CODE  = A.HOSP_CODE    ");
		sql.append("	   AND A.HO_DONG    = B.GWA          ");
		sql.append("	 ORDER BY 1                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3010P99grdDcOrderInfo> getDRG3010P99grdDcOrderInfo(String hospCode, String language, String jubsuDate, Double drgBunho, String bunho, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')         ORDER_DATE																				");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																										");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																										");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																										");
		sql.append("           ,CASE WHEN A.NALSU < 0 THEN CONCAT('-',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                ELSE CONCAT('',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                END           ORD_SURYANG																							");
		sql.append("           ,A.DV_TIME                            DV_TIME																							");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																								");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																								");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																										");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME													");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																						");
		sql.append("           ,IFNULL(C.BOGYONG_NAME, '')          BOGYONG_NAME																						");
		sql.append("           ,A.POWDER_YN                         POWDER_YN																							");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																								");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																								");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																								");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																								");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																								");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																								");
		sql.append("           ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN																									");
		sql.append("           ,A.PHARMACY              PHARMACY																										");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																										");
		sql.append("           ,IFNULL(A.JUSA, '')                  JUSA																								");
		sql.append("           ,D.SUNAME                SUNAME																											");
		sql.append("           ,CAST(A.DRG_BUNHO AS CHAR)             DRG_BUNHO																							");
		sql.append("           ,DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')             JUBSU_DATE																			");
		sql.append("           ,A.BUNHO                 BUNHO																											");
		sql.append("           ,A.BANNAB_YN             BANNAB_YN																										");
		sql.append("           ,CASE (A.SOURCE_FKOCS2003) WHEN '' THEN A.FKOCS2003 																						");
		sql.append("                                       ELSE IFNULL(A.SOURCE_FKOCS2003,A.FKOCS2003)  END SOURCE_FKOCS2003											");
		sql.append("           ,A.FKOCS2003             FKOCS2003																										");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE																				");
		sql.append("           ,A.DC_YN                 DC_YN																											");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																										");
		sql.append("           ,IFNULL(F.MIX_GROUP, '')             MIX_GROUP																							");
		sql.append("           ,IFNULL(F.BROUGHT_DRG_YN, '')        BROUGHT_DRG_YN																						");
		sql.append("           ,A.EMERGENCY																																");
		sql.append("       FROM DRG3010 A																																");
		sql.append("       LEFT JOIN INV0110 B																															");
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																									");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       LEFT JOIN DRG0120 C																															");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																									");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OUT0101 D																																");
		sql.append("         ON D.BUNHO                = A.BUNHO																										");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OCS2003 F																																");
		sql.append("         ON F.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("        AND F.PKOCS2003            = A.FKOCS2003																									");
		sql.append("      WHERE A.HOSP_CODE            = :f_hosp_code																									");
		sql.append("        AND A.JUBSU_DATE           = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																			");
		sql.append("        AND A.DRG_BUNHO            = :f_drg_bunho																									");
		sql.append("        AND A.BUNHO                = :f_bunho																										");
		sql.append("     UNION ALL																																		");
		sql.append("     SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')            ORDER_DATE																				");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																										");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																										");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																										");
		sql.append("           ,CASE WHEN A.NALSU < 0 THEN CONCAT('-',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                ELSE CONCAT('',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                     THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                END           ORD_SURYANG																							");
		sql.append("           ,A.DV_TIME               DV_TIME																											");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																								");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																								");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																										");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME													");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																						");
		sql.append("           ,IFNULL(C.BOGYONG_NAME, '')          BOGYONG_NAME																						");
		sql.append("           ,A.POWDER_YN             POWDER_YN																										");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																								");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																								");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																								");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																								");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																								");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																								");
		sql.append("           ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN																									");
		sql.append("           ,A.PHARMACY              PHARMACY																										");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																										");
		sql.append("           ,IFNULL(A.JUSA, '')                  JUSA																								");
		sql.append("           ,D.SUNAME                SUNAME																											");
		sql.append("           ,CAST(A.DRG_BUNHO AS CHAR)             DRG_BUNHO																							");
		sql.append("           ,DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')             JUBSU_DATE																			");
		sql.append("           ,A.BUNHO                 BUNHO																											");
		sql.append("           ,A.BANNAB_YN             BANNAB_YN																										");
		sql.append("           ,CASE (A.SOURCE_FKOCS2003) WHEN '' THEN A.FKOCS2003 																						");
		sql.append("                                       ELSE IFNULL(A.SOURCE_FKOCS2003,A.FKOCS2003)  END SOURCE_FKOCS2003											");
		sql.append("           ,A.FKOCS2003             FKOCS2003																										");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE																				");
		sql.append("           ,A.DC_YN                 DC_YN																											");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																										");
		sql.append("           ,IFNULL(F.MIX_GROUP, '')             MIX_GROUP																							");
		sql.append("           ,IFNULL(F.BROUGHT_DRG_YN, '')        BROUGHT_DRG_YN																						");
		sql.append("           ,A.EMERGENCY																																");
		sql.append("       FROM 																																		");
		sql.append("            (SELECT *																																");
		sql.append("               FROM DRG3010 Y																														");
		sql.append("              WHERE Y.HOSP_CODE = :f_hosp_code																										");
		sql.append("                AND Y.SOURCE_FKOCS2003 IN (SELECT X.FKOCS2003																						");
		sql.append("                                             FROM DRG3010 X																							");
		sql.append("                                            WHERE X.HOSP_CODE = :f_hosp_code																		");
		sql.append("                                             AND X.JUBSU_DATE = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')												");
		sql.append("                                             AND X.DRG_BUNHO  = :f_drg_bunho																		");
		sql.append("                                             AND X.BUNHO      = :f_bunho																			");
		sql.append("                                            )																										");
		sql.append("            ) A																																		");
		sql.append("       LEFT JOIN INV0110 B																															");
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																									");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       LEFT JOIN DRG0120 C																															");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																									");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OUT0101 D																																");
		sql.append("         ON D.BUNHO                = A.BUNHO																										");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OCS2003 F																																");
		sql.append("         ON F.PKOCS2003            = A.FKOCS2003																									");
		sql.append("        AND F.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("            																																		");
		sql.append("      WHERE 1 = 1																																	");
		sql.append("      ORDER BY ORDER_DATE DESC, DC_YN DESC, GROUP_SER, SOURCE_FKOCS2003, FKOCS2003, JAERYO_NAME														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																													");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_bunho", bunho);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdDcOrderInfo> list = new JpaResultMapper().list(query, DRG3010P99grdDcOrderInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3010P99grdJusaDcOrderInfo> getDRG3010P99grdJusaDcOrderInfo(String hospCode, String language, String jubsuDate, Double drgBunho, String bunho, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')         ORDER_DATE																				");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																										");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																										");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																										");
		sql.append("           ,CASE WHEN A.NALSU < 0 THEN CONCAT('-',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                ELSE CONCAT('',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                END           ORD_SURYANG																							");
		sql.append("           ,A.DV_TIME                            DV_TIME																							");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																								");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																								");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																										");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME													");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																						");
		sql.append("           ,CONCAT(A.BOGYONG_CODE, ' ', 																											");
		sql.append("               FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',CASE(A.JUSA_SPD_GUBUN) WHEN '' THEN '0' ELSE IFNULL(A.JUSA_SPD_GUBUN,'0') END					");
		sql.append("               , A.HOSP_CODE, :f_language))            BOGYONG_NAME																					");
		sql.append("           ,A.POWDER_YN                         POWDER_YN																							");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																								");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																								");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																								");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																								");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																								");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																								");
		sql.append("           ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN																									");
		sql.append("           ,A.PHARMACY              PHARMACY																										");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																										");
		sql.append("           ,IFNULL(FN_OCS_LOAD_CODE_NAME('JUSA', CASE(A.JUSA) WHEN '' THEN '0' ELSE																	");
		sql.append("                                     IFNULL(A.JUSA, '0') END, A.HOSP_CODE, :f_language),'')     JUSA_NAME											");
		sql.append("           ,D.SUNAME                SUNAME																											");
		sql.append("           ,CAST(A.DRG_BUNHO AS CHAR)             DRG_BUNHO																							");
		sql.append("           ,DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')             JUBSU_DATE																			");
		sql.append("           ,A.BUNHO                 BUNHO																											");
		sql.append("           ,A.BANNAB_YN             BANNAB_YN																										");
		sql.append("           ,CASE (A.SOURCE_FKOCS2003) WHEN '' THEN A.FKOCS2003 																						");
		sql.append("                                       ELSE IFNULL(A.SOURCE_FKOCS2003,A.FKOCS2003)  END SOURCE_FKOCS2003											");
		sql.append("           ,A.FKOCS2003             FKOCS2003																										");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE																				");
		sql.append("           ,A.DC_YN                 DC_YN																											");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																										");
		sql.append("           ,IFNULL(F.MIX_GROUP, '')             MIX_GROUP																							");
		sql.append("           ,IFNULL(F.BROUGHT_DRG_YN, '')        BROUGHT_DRG_YN																						");
		sql.append("           ,A.EMERGENCY																																");
		sql.append("       FROM DRG3010 A																																");
		sql.append("       LEFT JOIN INV0110 B																															");
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																									");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       LEFT JOIN DRG0120 C																															");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																									");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OUT0101 D																																");
		sql.append("         ON D.BUNHO                = A.BUNHO																										");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OCS2003 F																																");
		sql.append("         ON F.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("        AND F.PKOCS2003            = A.FKOCS2003																									");
		sql.append("      WHERE A.HOSP_CODE            = :f_hosp_code																									");
		sql.append("        AND A.JUBSU_DATE           = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																			");
		sql.append("        AND A.DRG_BUNHO            = :f_drg_bunho																									");
		sql.append("        AND A.BUNHO                = :f_bunho																										");
		sql.append("     UNION ALL																																		");
		sql.append("     SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')            ORDER_DATE																				");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																										");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																										");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																										");
		sql.append("           ,CASE WHEN A.NALSU < 0 THEN CONCAT('-',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                ELSE CONCAT('',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                     THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                END           ORD_SURYANG																							");
		sql.append("           ,A.DV_TIME               DV_TIME																											");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																								");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																								");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																										");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME													");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																						");
		sql.append("           ,CONCAT(A.BOGYONG_CODE, ' ', 																											");
		sql.append("               FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',CASE(A.JUSA_SPD_GUBUN) WHEN '' THEN '0' ELSE IFNULL(A.JUSA_SPD_GUBUN,'0') END					");
		sql.append("               , A.HOSP_CODE, :f_language))            BOGYONG_NAME																					");
		sql.append("           ,A.POWDER_YN             POWDER_YN																										");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																								");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																								");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																								");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																								");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																								");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																								");
		sql.append("           ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN																									");
		sql.append("           ,A.PHARMACY              PHARMACY																										");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																										");
		sql.append("           ,IFNULL(FN_OCS_LOAD_CODE_NAME('JUSA', CASE(A.JUSA) WHEN '' THEN '0' ELSE																	");
		sql.append("                                     IFNULL(A.JUSA, '0') END, A.HOSP_CODE, :f_language),'')     JUSA_NAME											");
		sql.append("           ,D.SUNAME                SUNAME																											");
		sql.append("           ,CAST(A.DRG_BUNHO AS CHAR)             DRG_BUNHO																							");
		sql.append("           ,DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')             JUBSU_DATE																			");
		sql.append("           ,A.BUNHO                 BUNHO																											");
		sql.append("           ,A.BANNAB_YN             BANNAB_YN																										");
		sql.append("           ,CASE (A.SOURCE_FKOCS2003) WHEN '' THEN A.FKOCS2003 																						");
		sql.append("                                       ELSE IFNULL(A.SOURCE_FKOCS2003,A.FKOCS2003)  END SOURCE_FKOCS2003											");
		sql.append("           ,A.FKOCS2003             FKOCS2003																										");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE																				");
		sql.append("           ,A.DC_YN                 DC_YN																											");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																										");
		sql.append("           ,IFNULL(F.MIX_GROUP, '')             MIX_GROUP																							");
		sql.append("           ,IFNULL(F.BROUGHT_DRG_YN, '')        BROUGHT_DRG_YN																						");
		sql.append("           ,A.EMERGENCY																																");
		sql.append("       FROM 																																		");
		sql.append("            (SELECT *																																");
		sql.append("               FROM DRG3010 Y																														");
		sql.append("              WHERE Y.HOSP_CODE = :f_hosp_code																										");
		sql.append("                AND Y.SOURCE_FKOCS2003 IN (SELECT X.FKOCS2003																						");
		sql.append("                                             FROM DRG3010 X																							");
		sql.append("                                            WHERE X.HOSP_CODE = :f_hosp_code																		");
		sql.append("                                             AND X.JUBSU_DATE = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')												");
		sql.append("                                             AND X.DRG_BUNHO  = :f_drg_bunho																		");
		sql.append("                                             AND X.BUNHO      = :f_bunho																			");
		sql.append("                                            )																										");
		sql.append("            ) A																																		");
		sql.append("       LEFT JOIN INV0110 B																															");
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																									");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       LEFT JOIN DRG0120 C																															");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																									");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OUT0101 D																																");
		sql.append("         ON D.BUNHO                = A.BUNHO																										");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OCS2003 F																																");
		sql.append("         ON F.PKOCS2003            = A.FKOCS2003																									");
		sql.append("        AND F.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("            																																		");
		sql.append("      WHERE 1 = 1																																	");
		sql.append("      ORDER BY ORDER_DATE DESC, DC_YN DESC, GROUP_SER, SOURCE_FKOCS2003, FKOCS2003, JAERYO_NAME														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																													");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_bunho", bunho);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdJusaDcOrderInfo> list = new JpaResultMapper().list(query, DRG3010P99grdJusaDcOrderInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3010P99grdListInfo> getDRG3010P99grdListInfo(String hospCode, String language, String hoDong, String bunho, String fromDate, String toDate,
					String magamGubun, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																														");
		sql.append("            DATE_FORMAT(A.DRG_PRN_DATE, '%Y/%m/%d')                                JUBSU_DATE												");
		sql.append("          , A.DRG_PRN_TIME                                       DRG_PRN_TIME																");
		sql.append("          , CAST(A.DRG_BUNHO AS CHAR)                            DRG_BUNHO																	");
		sql.append("          , A.BUNHO                                              BUNHO																		");
		sql.append("          , B.SUNAME                                             SUNAME																		");
		sql.append("          , FN_BAS_LOAD_CODE_NAME('SEX', B.SEX, A.HOSP_CODE, :f_language)                  SEX												");
		sql.append("          , CAST(FN_BAS_LOAD_AGE(A.HOPE_DATE, B.BIRTH,'') AS CHAR)       AGE																");
		sql.append("          , A.RESIDENT                                           RESIDENT																	");
		sql.append("          , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, A.HOSP_CODE),'')    DOCTOR_NAME										");
		sql.append("          , B.HO_DONG1                                            HO_DONG																	");
		sql.append("          , FN_BAS_LOAD_GWA_NAME(B.HO_DONG1, A.ORDER_DATE, A.HOSP_CODE, :f_language)        HO_DONG_NAME									");
		sql.append("          , B.HO_CODE1                                            HO_CODE																	");
		sql.append("          , B.PKINP1001                                          PKINP1001																	");
		sql.append("          , CASE(B.TOIWON_RES_DATE) WHEN '' THEN 'N' WHEN NULL THEN 'N' ELSE 'Y' END       TOIWON_YN										");
		sql.append("          , ''                                                   GWA																		");
		sql.append("          , DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                        ORDER_DATE											");
		sql.append("          , DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')                                          HOPE_DATE											");
		sql.append("          , CASE																															");
		sql.append("                 WHEN A.EMERGENCY = 'Y'																										");
		sql.append("                  AND C.ORDER_GUBUN LIKE '1%' 																								");
		sql.append("                  AND A.BUNRYU1 IN ('1', '6') THEN 'P1'  /*指薬*/																			");
		sql.append("                 WHEN A.EMERGENCY = 'Y'																										");
		sql.append("                  AND C.ORDER_GUBUN LIKE '1%'																								");
		sql.append("                  AND A.BUNRYU1 IN ('4') THEN 'P2'       /*指注*/																			");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  = 'N'									");
		sql.append("                  AND A.BUNRYU1 IN ('1', '6') THEN '21' /*臨薬*/																				");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  = 'N'									");
		sql.append("                  AND A.BUNRYU1 = '4' THEN '22'         /*臨注*/																				");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  <> 'N'									");
		sql.append("                  AND A.BUNRYU1 IN ('1', '6') THEN '31' /*退薬*/																				");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  <> 'N'									");
		sql.append("                  AND A.BUNRYU1 = '4' THEN '32'         /*退注*/																				");
		sql.append("                 ELSE ''																													");
		sql.append("            END                                                  MAGAM_GUBUN																");
		sql.append("          , CASE(A.BUNRYU1) WHEN '4' THEN 'Y' ELSE 'N' END               JUSA_YN															");
		sql.append("          , IFNULL(CASE(A.BUNRYU1) WHEN '4' 																								");
		sql.append("                 THEN DATE_FORMAT(FN_DRG_GET_MIX_DATE(A.HOSP_CODE, A.JUBSU_DATE, A.DRG_BUNHO), '%Y/%m/%d') ELSE '' END,'')  CHULGO_DATE		");
		sql.append("      FROM DRG3010 A																														");
		sql.append("      JOIN VW_OCS_INP1001_02 B																												");
		sql.append("        ON B.HOSP_CODE                  = A.HOSP_CODE																						");
		sql.append("       AND B.PKINP1001                  = A.FKINP1001																						");
		sql.append("       AND B.HO_DONG1                   LIKE CONCAT(:f_ho_dong,'%')																			");
		sql.append("      JOIN OCS2003 C																														");
		sql.append("        ON C.HOSP_CODE                  = A.HOSP_CODE																						");
		sql.append("       AND C.PKOCS2003                  = A.FKOCS2003																						");
		sql.append("      ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP																						");
		sql.append("     WHERE A.HOSP_CODE                  = :f_hosp_code																						");
		sql.append("       AND A.BUNHO                      LIKE CONCAT(:f_bunho,'%')																			");
		sql.append("       AND A.DRG_PRN_DATE               BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m/%d')														");
		sql.append("                                        AND STR_TO_DATE(:f_to_date, '%Y/%m/%d')																");
		sql.append("       AND ((:f_magam_gubun = '%'  AND (CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y' 							");
		sql.append("                                  OR CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'))					");
		sql.append("        OR  (:f_magam_gubun = '21' AND C.ORDER_GUBUN NOT LIKE '1%'																			");
		sql.append("                                  AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'							");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'					");
		sql.append("                                  AND A.BUNRYU1 IN ('1', '6') /*臨薬*/)																		");
		sql.append("        OR  (:f_magam_gubun = '22' AND C.ORDER_GUBUN NOT LIKE '1%' 																			");
		sql.append("                                  AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'							");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'					");
		sql.append("                                  AND A.BUNRYU1 = '4'         /*臨注*/)																		");
		sql.append("        OR  (:f_magam_gubun = '31' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N'							");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'					");
		sql.append("                                  AND A.BUNRYU1 IN ('1', '6') /*退薬*/)																		");
		sql.append("        OR  (:f_magam_gubun = '32' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N'							");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'					");
		sql.append("                                  AND A.BUNRYU1 = '4'         /*退注*/)																		");
		sql.append("        OR  (:f_magam_gubun = 'P1' AND  C.ORDER_GUBUN LIKE '1%' AND A.BUNRYU1 IN ('1', '6') /*指薬*/)										");
		sql.append("        OR  (:f_magam_gubun = 'P2' AND  C.ORDER_GUBUN LIKE '1%' AND A.BUNRYU1 = '4'         /*指注*/)										");
		sql.append("        )																																	");
		sql.append("        AND CASE(DRG_PRN_YN) WHEN '' THEN 'N' ELSE IFNULL(DRG_PRN_YN, 'N') END        = 'Y'													");
		sql.append("        AND CASE(A.DC_YN)  WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END              = 'N'												");
		sql.append("        AND CASE(A.BANNAB_YN)  WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN, 'N') END      = 'N'												");
		sql.append("        AND CASE(A.RE_USE_YN)  WHEN '' THEN 'N' ELSE IFNULL(A.RE_USE_YN, 'N') END      = 'N'												");
		sql.append("        AND CASE(A.WONYOI_ORDER_YN)  WHEN '' THEN 'N' ELSE IFNULL(A.WONYOI_ORDER_YN, 'N') END = 'N'											");
		sql.append("        AND CASE(A.NALSU)  WHEN '' THEN 'N' ELSE IFNULL(A.NALSU, 'N') END              > 0													");
		sql.append("     ORDER BY MAGAM_GUBUN, A.DRG_PRN_DATE DESC, A.DRG_PRN_TIME DESC, HO_DONG, HO_CODE														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																											");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_magam_gubun", magamGubun);
		query.setParameter("f_ho_dong", hoDong);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdListInfo> list = new JpaResultMapper().list(query, DRG3010P99grdListInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3010P99grdJusaDcOrderInfo> getDRG3010P99grdMagamJusaOrderInfo(String hospCode, String language, String jubsuDate, Double drgBunho, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')         ORDER_DATE																				");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																										");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																										");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																										");
		sql.append("           ,CASE WHEN A.NALSU < 0 THEN CONCAT('-',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                ELSE CONCAT('',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                END           ORD_SURYANG																							");
		sql.append("           ,A.DV_TIME                            DV_TIME																							");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																								");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																								");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																										");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME													");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																						");
		sql.append("           ,CONCAT(A.BOGYONG_CODE, ' ', 																											");
		sql.append("               FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',CASE(A.JUSA_SPD_GUBUN) WHEN '' THEN '0' ELSE IFNULL(A.JUSA_SPD_GUBUN,'0') END					");
		sql.append("               , A.HOSP_CODE, :f_language))            BOGYONG_NAME																					");
		sql.append("           ,A.POWDER_YN                         POWDER_YN																							");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																								");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																								");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																								");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																								");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																								");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																								");
		sql.append("           ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN																									");
		sql.append("           ,A.PHARMACY              PHARMACY																										");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																										");
		sql.append("           ,IFNULL(FN_OCS_LOAD_CODE_NAME('JUSA', CASE(A.JUSA) WHEN '' THEN '0' ELSE																	");
		sql.append("                                     IFNULL(A.JUSA, '0') END, A.HOSP_CODE, :f_language),'')     JUSA_NAME											");
		sql.append("           ,D.SUNAME                SUNAME																											");
		sql.append("           ,CAST(A.DRG_BUNHO AS CHAR)             DRG_BUNHO																							");
		sql.append("           ,DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')             JUBSU_DATE																			");
		sql.append("           ,A.BUNHO                 BUNHO																											");
		sql.append("           ,A.BANNAB_YN             BANNAB_YN																										");
		sql.append("           ,CASE (A.SOURCE_FKOCS2003) WHEN '' THEN A.FKOCS2003 																						");
		sql.append("                                       ELSE IFNULL(A.SOURCE_FKOCS2003,A.FKOCS2003)  END SOURCE_FKOCS2003											");
		sql.append("           ,A.FKOCS2003             FKOCS2003																										");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE																				");
		sql.append("           ,A.DC_YN                 DC_YN																											");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																										");
		sql.append("           ,IFNULL(F.MIX_GROUP, '')             MIX_GROUP																							");
		sql.append("           ,IFNULL(F.BROUGHT_DRG_YN, '')        BROUGHT_DRG_YN																						");
		sql.append("           ,A.EMERGENCY																																");
		sql.append("       FROM DRG3010 A																																");
		sql.append("       LEFT JOIN INV0110 B																															");
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																									");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       LEFT JOIN DRG0120 C																															");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																									");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OUT0101 D																																");
		sql.append("         ON D.BUNHO                = A.BUNHO																										");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OCS2003 F																																");
		sql.append("         ON F.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("        AND F.PKOCS2003            = A.FKOCS2003																									");
		sql.append("      WHERE A.HOSP_CODE            = :f_hosp_code																									");
		sql.append("        AND A.DRG_PRN_DATE         = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																			");
		sql.append("        AND A.DRG_BUNHO            = :f_drg_bunho																									");
		sql.append("        AND A.BUNRYU1              IN ('4')																											");		
		sql.append("      ORDER BY ORDER_DATE DESC, DC_YN DESC, GROUP_SER, SOURCE_FKOCS2003, FKOCS2003, JAERYO_NAME														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																													");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdJusaDcOrderInfo> list = new JpaResultMapper().list(query, DRG3010P99grdJusaDcOrderInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3010P99grdMagamOrderInfo> getDRG3010P99grdMagamOrderInfo(String hospCode, String language, String jubsuDate, Double drgBunho, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')         ORDER_DATE																				");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																										");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																										");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																										");
		sql.append("           ,CASE WHEN A.NALSU < 0 THEN CONCAT('-',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                ELSE CONCAT('',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 																");
		sql.append("                                                       THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                                END           ORD_SURYANG																							");
		sql.append("           ,A.DV_TIME                            DV_TIME																							");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																								");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																								");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																										");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME													");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																						");
		sql.append("           ,IFNULL(C.BOGYONG_NAME, '')          BOGYONG_NAME																						");
		sql.append("           ,A.POWDER_YN                         POWDER_YN																							");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																								");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																								");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																								");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																								");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																								");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																								");
		sql.append("           ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN																									");
		sql.append("           ,A.PHARMACY              PHARMACY																										");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																										");
		sql.append("           ,IFNULL(A.JUSA, '')                  JUSA																								");
		sql.append("           ,D.SUNAME                SUNAME																											");
		sql.append("           ,CAST(A.DRG_BUNHO AS CHAR)             DRG_BUNHO																							");
		sql.append("           ,DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')             JUBSU_DATE																			");
		sql.append("           ,A.BUNHO                 BUNHO																											");
		sql.append("           ,A.BANNAB_YN             BANNAB_YN																										");
		sql.append("           ,CASE (A.SOURCE_FKOCS2003) WHEN '' THEN A.FKOCS2003 																						");
		sql.append("                                       ELSE IFNULL(A.SOURCE_FKOCS2003,A.FKOCS2003)  END SOURCE_FKOCS2003											");
		sql.append("           ,A.FKOCS2003             FKOCS2003																										");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE																				");
		sql.append("           ,A.DC_YN                 DC_YN																											");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																										");
		sql.append("           ,IFNULL(F.MIX_GROUP, '')             MIX_GROUP																							");
		sql.append("		   ,IFNULL(A.RE_USE_YN, '')				RE_USE_YN																							");
		sql.append("           ,IFNULL(F.BROUGHT_DRG_YN, '')        BROUGHT_DRG_YN																						");
		sql.append("           ,A.EMERGENCY																																");
		sql.append("       FROM DRG3010 A																																");
		sql.append("       LEFT JOIN INV0110 B																															");
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																									");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       LEFT JOIN DRG0120 C																															");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																									");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OUT0101 D																																");
		sql.append("         ON D.BUNHO                = A.BUNHO																										");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("       JOIN OCS2003 F																																");
		sql.append("         ON F.HOSP_CODE            = A.HOSP_CODE																									");
		sql.append("        AND F.PKOCS2003            = A.FKOCS2003																									");
		sql.append("      WHERE A.HOSP_CODE            = :f_hosp_code																									");
		sql.append("        AND A.JUBSU_DATE           = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																			");
		sql.append("        AND A.DRG_BUNHO            = :f_drg_bunho																									");
		sql.append("        AND A.BUNRYU1              IN ('1','6')																										");
		sql.append("      ORDER BY ORDER_DATE DESC, DC_YN DESC, GROUP_SER, SOURCE_FKOCS2003, FKOCS2003, JAERYO_NAME														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																													");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdMagamOrderInfo> list = new JpaResultMapper().list(query, DRG3010P99grdMagamOrderInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3010P99grdMiMagamJusaOrderInfo> getDRG3010P99grdMiMagamJusaOrderInfo(String hospCode, String language, String orderDate, String hopeDate, String bunho,
							String hoDong, String resident, String magamGubun, Integer startNum, Integer offset, boolean isJusa){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')            ORDER_DATE																");
		sql.append("           ,IFNULL(A.MIX_GROUP, '')             MIX_GROUP																			");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																						");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																						");
		sql.append("           ,CAST(A.ORD_SURYANG AS CHAR)           ORD_SURYANG																		");
		sql.append("           ,A.DV_TIME               DV_TIME																							");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																				");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																				");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																						");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME									");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																		");
		if(isJusa){
			sql.append("       ,IFNULL(CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',												");
			sql.append("                   CASE(A.JUSA_SPD_GUBUN) WHEN '' THEN '0' ELSE 																");
			sql.append("                   IFNULL(A.JUSA_SPD_GUBUN,'0') END, A.HOSP_CODE, :f_language)),'')     BOGYONG_NAME							");
		}else{
			sql.append("       ,IFNULL(C.BOGYONG_NAME, '')          BOGYONG_NAME 																		");
		}
		sql.append("           ,A.POWDER_YN             POWDER_YN																						");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																				");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																				");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																				");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																				");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																				");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																				");
		sql.append("           ,FN_DRG_JUNINP_YN(A.HOSP_CODE, A.FKOCS2003, 'N')      HUBAL_CHANGE_YN													");
		sql.append("           ,A.PHARMACY              PHARMACY																						");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																						");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('JUSA', CASE(A.JUSA) WHEN '' THEN '0'																");
		sql.append("                             ELSE IFNULL(A.JUSA,'0') END, A.HOSP_CODE, :f_language)     JUSA_NAME									");
		sql.append("           ,D.SUNAME                                          SUNAME																");
		sql.append("           ,IFNULL(CAST(A.DRG_BUNHO AS CHAR), '')             DRG_BUNHO																");
		sql.append("           ,A.FKOCS2003             FKOCS2003																						");
		sql.append("           ,A.APPEND_YN             APPEND_YN																						");
		sql.append("           ,IFNULL(A.RE_USE_YN,'')             RE_USE_YN																			");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE																");
		sql.append("           ,A.HOPE_TIME             HOPE_TIME																						");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																						");
		sql.append("           ,A.DC_YN                 DC_YN																							");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																						");
		sql.append("           ,IFNULL(G.IF_INPUT_CONTROL, '')      IF_INPUT_CONTROL																	");
		sql.append("           ,IFNULL(F.BROUGHT_DRG_YN, '')        BROUGHT_DRG_YN																		");
		sql.append("           ,A.EMERGENCY             EMERGENCY																						");
		sql.append("       FROM DRG3010 A																												");
		if(isJusa){
			sql.append("   LEFT JOIN INV0110 B																											");
		}else{
			sql.append("   JOIN INV0110 B																												");
		}
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																					");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																					");
		sql.append("       LEFT JOIN DRG0120 C																											");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																					");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																					");
		sql.append("       JOIN OUT0101 D																												");
		sql.append("         ON D.BUNHO                = A.BUNHO																						");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																					");
		sql.append("       JOIN INP1001 E																												");
		sql.append("         ON E.HOSP_CODE            = A.HOSP_CODE																					");
		sql.append("        AND E.PKINP1001            = A.FKINP1001																					");
		sql.append("        AND E.HO_DONG1             LIKE :f_ho_dong																						");
		sql.append("       JOIN OCS2003 F																												");
		sql.append("         ON F.HOSP_CODE            = A.HOSP_CODE																					");
		sql.append("        AND F.PKOCS2003            = A.FKOCS2003																					");
		sql.append("        AND F.ORDER_GUBUN          NOT LIKE '1%'  /*指示事項除外*/																	");
		sql.append("       JOIN OCS0103 G																												");
		sql.append("         ON G.HOSP_CODE            = A.HOSP_CODE																					");
		sql.append("        AND G.HANGMOG_CODE         = F.HANGMOG_CODE																					");
		sql.append("      WHERE A.HOSP_CODE            = :f_hosp_code																					");
		sql.append("        AND A.ORDER_DATE           = STR_TO_DATE(:f_order_date, '%Y/%m/%d')															");
		sql.append("        AND A.HOPE_DATE            = STR_TO_DATE(:f_hope_date, '%Y/%m/%d')															");
		sql.append("        AND A.BUNHO                = :f_bunho																						");
		sql.append("        AND A.RESIDENT             = :f_doctor																						");
		if(isJusa){
			sql.append("    AND A.BUNRYU1              IN ('4')																							");
		}else{
			sql.append("    AND A.BUNRYU1              IN ('1','6')																						");
		}
		sql.append("        AND ((:f_magam_gubun = '%'  AND (CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'					");
		sql.append("                                  OR CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'))			");
		sql.append("         OR  (:f_magam_gubun = '21' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'					");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'			");
		sql.append("                                  AND A.BUNRYU1 IN ('1', '6') /*臨薬*/)																");
		sql.append("         OR  (:f_magam_gubun = '22' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'					");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'			");
		sql.append("                                  AND A.BUNRYU1 = '4'         /*臨注*/)																");
		sql.append("         OR  (:f_magam_gubun = '31' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N'					");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'			");
		sql.append("                                  AND A.BUNRYU1 IN ('1', '6') /*退薬*/)																");
		sql.append("         OR  (:f_magam_gubun = '32' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N'					");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'			");
		sql.append("                                  AND A.BUNRYU1 = '4'         /*退注*/)																");
		sql.append("         )																															");
		sql.append("        AND (A.DRG_BUNHO            IS NULL OR A.DRG_BUNHO = '')																	");
		sql.append("        AND A.NALSU                > 0																								");
		sql.append("        AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END      = 'N'													");
		sql.append("        AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN, 'N') END  = 'N'												");
		sql.append("        AND CASE(A.RE_USE_YN) WHEN '' THEN 'N' ELSE IFNULL(A.RE_USE_YN, 'N') END  = 'N'												");
		if(isJusa){
			sql.append("    AND A.ORDER_DATE BETWEEN G.START_DATE AND IFNULL(G.END_DATE, STR_TO_DATE('99991231','%Y%m%d'))								");
		}else{
			sql.append("    AND A.HOPE_DATE BETWEEN G.START_DATE AND IFNULL(G.END_DATE, STR_TO_DATE('99991231','%Y%m%d'))								");
		}
		sql.append("      ORDER BY ORDER_DATE, GROUP_SER, MIX_GROUP, SUNAME																				");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																									");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hope_date", hopeDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_doctor", resident);
		query.setParameter("f_magam_gubun", magamGubun);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdMiMagamJusaOrderInfo> list = new JpaResultMapper().list(query, DRG3010P99grdMiMagamJusaOrderInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3010P99grdPaDcListInfo> getDRG3010P99grdPaDcListInfo(String hospCode, String language, String hoDong, String bunho, String fromDate,
						String toDate, String magamGubun, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																												");
		sql.append("            DATE_FORMAT(A.DRG_PRN_DATE, '%Y/%m/%d')              JUBSU_DATE															");
		sql.append("          , CAST(A.DRG_BUNHO AS CHAR)                            DRG_BUNHO															");
		sql.append("          , A.BUNHO                                              BUNHO																");
		sql.append("          , B.SUNAME                                             SUNAME																");
		sql.append("          , FN_BAS_LOAD_CODE_NAME('SEX', B.SEX, A.HOSP_CODE, :f_language)                  SEX										");
		sql.append("          , CAST(FN_BAS_LOAD_AGE(A.HOPE_DATE, B.BIRTH,'') AS CHAR)            AGE													");
		sql.append("          , A.RESIDENT                                           RESIDENT															");
		sql.append("          , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, A.HOSP_CODE),'')    DOCTOR_NAME								");
		sql.append("          , B.HO_DONG1                                            HO_DONG															");
		sql.append("          , FN_BAS_LOAD_GWA_NAME(B.HO_DONG1, A.ORDER_DATE, A.HOSP_CODE, :f_language)        HO_DONG_NAME							");
		sql.append("          , B.HO_CODE1                                            HO_CODE															");
		sql.append("          , CASE(IFNULL(B.TOIWON_RES_DATE, 'N')) WHEN '' THEN 'N' WHEN 'N' THEN 'N' ELSE 'Y' END       TOIWON_YN					");
		sql.append("          , A.GWA                                                GWA																");
		sql.append("          , DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                         ORDER_DATE								");
		sql.append("          , DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')                                          HOPE_DATE									");
		sql.append("          , CASE 																													");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  = 'N'							");
		sql.append("                                            AND A.BUNRYU1 IN ('1', '6') THEN '21' /*臨薬*/											");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  = 'N'							");
		sql.append("                                            AND A.BUNRYU1 = '4' THEN '22'         /*臨注*/											");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  <> 'N'							");
		sql.append("                                            AND A.BUNRYU1 IN ('1', '6') THEN '31' /*退薬*/											");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN)  WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  <> 'N'							");
		sql.append("                                            AND A.BUNRYU1 = '4' THEN '32'         /*退注*/											");
		sql.append("            END                                                           MAGAM_GUBUN												");
		sql.append("          , CASE(A.BUNRYU1) WHEN '4' THEN 'Y' ELSE 'N' END                JUSA_YN													");
		sql.append("      FROM DRG3010 A																												");
		sql.append("      JOIN VW_OCS_INP1001_02 B																										");
		sql.append("        ON B.HOSP_CODE                  = A.HOSP_CODE																				");
		sql.append("       AND B.PKINP1001                  = A.FKINP1001																				");
		sql.append("       AND B.HO_DONG1                    LIKE CONCAT(:f_ho_dong,'%')																");
		sql.append("      JOIN OCS2003 C																												");
		sql.append("        ON C.HOSP_CODE                  = A.HOSP_CODE																				");
		sql.append("       AND C.PKOCS2003                  = A.FKOCS2003																				");
		sql.append("       ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP																				");
		sql.append("     WHERE A.HOSP_CODE                  = :f_hosp_code																				");
		sql.append("       AND A.BUNHO                      LIKE CONCAT(:f_bunho, '%')																	");
		sql.append("       AND A.DRG_PRN_DATE               BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m/%d') 												");
		sql.append("                                        AND STR_TO_DATE(:f_to_date, '%Y/%m/%d')														");
		sql.append("       AND ((:f_magam_gubun = '%'  AND (CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'					");
		sql.append("                                  OR CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'))			");
		sql.append("         OR  (:f_magam_gubun = '21' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'					");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'			");
		sql.append("                                  AND A.BUNRYU1 IN ('1', '6') /*臨薬*/)																");
		sql.append("         OR  (:f_magam_gubun = '22' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'					");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'			");
		sql.append("                                  AND A.BUNRYU1 = '4'         /*臨注*/)																");
		sql.append("         OR  (:f_magam_gubun = '31' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N'					");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'			");
		sql.append("                                  AND A.BUNRYU1 IN ('1', '6') /*退薬*/)																");
		sql.append("         OR  (:f_magam_gubun = '32' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N'					");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'			");
		sql.append("                                  AND A.BUNRYU1 = '4'         /*退注*/)																");
		sql.append("         )																															");
		sql.append("        AND CASE(A.DRG_PRN_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DRG_PRN_YN, 'N') END      = 'Y'										");
		sql.append("        AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END                = 'Y'										");
		sql.append("        AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN, 'N') END        = 'Y'										");
		sql.append("        AND CASE(A.RE_USE_YN) WHEN '' THEN 'N' ELSE IFNULL(A.RE_USE_YN, 'N') END        = 'N'										");
		sql.append("        AND (A.SOURCE_FKOCS2003           IS NULL OR A.SOURCE_FKOCS2003 = '')														");
		sql.append("        AND CASE(A.WONYOI_ORDER_YN) WHEN '' THEN 'N' ELSE IFNULL(A.WONYOI_ORDER_YN, 'N') END = 'N'									");
		sql.append("        AND CASE(A.NALSU) WHEN '' THEN 0 ELSE IFNULL(A.NALSU, 0) END           > 0													");
		sql.append("     ORDER BY MAGAM_GUBUN, A.DRG_PRN_DATE DESC, HO_DONG, HO_CODE																	");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																									");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_magam_gubun", magamGubun);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdPaDcListInfo> list = new JpaResultMapper().list(query, DRG3010P99grdPaDcListInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3010P99PaPrnInfo> getDRG3010P99PaPrnInfo(String hospCode, String language, String hoDong, String fromDate, String toDate, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																									");
		sql.append("            A.BUNHO                                              BUNHO													");
		sql.append("          , B.SUNAME                                             SUNAME													");
		sql.append("          , FN_BAS_LOAD_CODE_NAME('SEX', B.SEX, A.HOSP_CODE, :f_language)                  SEX							");
		sql.append("          , CAST(FN_BAS_LOAD_AGE(A.HOPE_DATE, B.BIRTH,'') AS CHAR)             AGE										");
		sql.append("          , A.RESIDENT                                           RESIDENT												");
		sql.append("          , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, A.HOSP_CODE), '')    DOCTOR_NAME					");
		sql.append("          , ''                                                   MAGAM_YN												");
		sql.append("          , B.HO_DONG1                                            HO_DONG												");
		sql.append("          , FN_BAS_LOAD_GWA_NAME(B.HO_DONG1, A.ORDER_DATE, A.HOSP_CODE, :f_language)        HO_DONG_NAME				");
		sql.append("          , B.HO_CODE1                                            HO_CODE												");
		sql.append("          , ''                                                   JUNINP_YN												");
		sql.append("          , DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')                        HOPE_DATE										");
		sql.append("          , A.HOPE_TIME                                          HOPE_TIME												");
		sql.append("          , B.PKINP1001                                          PKINP1001												");
		sql.append("          , CASE(IFNULL(B.TOIWON_RES_DATE, 'N')) WHEN '' THEN 'N' WHEN 'N' THEN 'N' ELSE 'Y' END TOIWON_YN				");
		sql.append("          , A.GWA                                                GWA													");
		sql.append("          , DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                ORDER_DATE												");
		sql.append("          , A.EMERGENCY                                          EMERGENCY												");
		sql.append("          , CASE(A.BUNRYU1) WHEN '4' THEN 'P2' ELSE 'P1' END     MAGAM_GUBUN											");
		sql.append("          , CASE(A.BUNRYU1) WHEN '4' THEN 'Y' ELSE 'N' END       JUSA_YN												");
		sql.append("      FROM DRG3010 A																									");
		sql.append("      JOIN VW_OCS_INP1001_02 B																							");
		sql.append("        ON B.HOSP_CODE                  = A.HOSP_CODE																	");
		sql.append("       AND B.PKINP1001                  = A.FKINP1001																	");
		sql.append("       AND B.HO_DONG1                   LIKE CONCAT(:f_ho_dong, '%')													");
		sql.append("      JOIN OCS2003 C																									");
		sql.append("        ON C.HOSP_CODE                  = A.HOSP_CODE																	");
		sql.append("       AND C.PKOCS2003                  = A.FKOCS2003																	");
		sql.append("       AND C.ORDER_GUBUN                LIKE '1%' /*指示事項*/															");
		sql.append("       ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP																	");
		sql.append("     WHERE A.HOSP_CODE                  = :f_hosp_code																	");
		sql.append("       AND A.HOPE_DATE                  BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m/%d') 									");
		sql.append("                                        AND STR_TO_DATE(:f_to_date, '%Y/%m/%d')											");
		sql.append("        AND CASE(A.DRG_PRN_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DRG_PRN_YN, 'N') END        = 'N'							");
		sql.append("        AND CASE(A.CHULGO_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CHULGO_YN, 'N') END          = 'N'							");
		sql.append("        AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END           = 'N'								");
		sql.append("        AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN, 'N') END        = 'N'							");
		sql.append("        AND CASE(A.RE_USE_YN) WHEN '' THEN 'N' ELSE IFNULL(A.RE_USE_YN, 'N') END        = 'N'							");
		sql.append("        AND A.SOURCE_FKOCS2003           IS NULL OR A.SOURCE_FKOCS2003 = ''												");
		sql.append("        AND CASE(A.WONYOI_ORDER_YN) WHEN '' THEN 'N' ELSE IFNULL(A.WONYOI_ORDER_YN, 'N') END  = 'N'						");
		sql.append("        AND CASE(A.NALSU) WHEN '' THEN 0 ELSE IFNULL(A.NALSU, 0) END          > 0										");
		sql.append("     ORDER BY MAGAM_GUBUN, HOPE_DATE DESC, HOPE_TIME, HO_DONG, HO_CODE													");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																									");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99PaPrnInfo> list = new JpaResultMapper().list(query, DRG3010P99PaPrnInfo.class);
		return list;
	}

	@Override
	public List<DRG3010P99grdPaInfo> getDRG3010P99grdPaInfo(String hospCode, String language, String bunho, String fromDate, String toDate, String magamGubun,
						String hoDong, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																											");
		sql.append("            A.BUNHO                                              BUNHO															");
		sql.append("          , B.SUNAME                                             SUNAME															");
		sql.append("          , FN_BAS_LOAD_CODE_NAME('SEX', B.SEX, A.HOSP_CODE, :f_language)                  SEX									");
		sql.append("          , IFNULL(FN_BAS_LOAD_AGE(A.HOPE_DATE, B.BIRTH,''), '')             AGE												");
		sql.append("          , A.RESIDENT                                           RESIDENT														");
		sql.append("          , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, A.HOSP_CODE), '')    DOCTOR_NAME							");
		sql.append("          , ''                                                   MAGAM_YN														");
		sql.append("          , B.HO_DONG1                                           HO_DONG														");
		sql.append("          , FN_BAS_LOAD_GWA_NAME(B.HO_DONG1, A.ORDER_DATE, A.HOSP_CODE, :f_language)       HO_DONG_NAME							");
		sql.append("          , B.HO_CODE1                                           HO_CODE														");
		sql.append("          , ''                                                   JUNINP_YN														");
		sql.append("          , DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')                 HOPE_DATE														");
		sql.append("          , ''                                                   HOPE_TIME														");
		sql.append("          , B.PKINP1001                                          PKINP1001														");
		sql.append("          , CASE(IFNULL(B.TOIWON_RES_DATE, 'N')) WHEN '' THEN 'N' WHEN 'N' THEN 'N' ELSE 'Y' END  TOIWON_YN						");
		sql.append("          , ''                                                   GWA															");
		sql.append("          , DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                        ORDER_DATE								");
		sql.append("          , ''                                                   EMERGENCY														");
		sql.append("          , CASE																												");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  = 'N'						");
		sql.append("                                            AND A.BUNRYU1 IN ('1', '6') THEN '21' /*臨薬*/										");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  = 'N'						");
		sql.append("                                            AND A.BUNRYU1 = '4' THEN '22'         /*臨注*/										");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  <> 'N'						");
		sql.append("                                            AND A.BUNRYU1 IN ('1', '6') THEN '31' /*退薬*/										");
		sql.append("                 WHEN CASE(A.TOIWON_DRG_YN)  WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END  <> 'N'						");
		sql.append("                                            AND A.BUNRYU1 = '4' THEN '32'         /*退注*/										");
		sql.append("             END                                                 MAGAM_GUBUN													");
		sql.append("          , CASE(A.BUNRYU1) WHEN '4' THEN 'Y' ELSE 'N' END       JUSA_YN														");
		sql.append("          , C.ACT_BUSEO                                          ACT_BUSEO														");
		sql.append("      FROM DRG3010 A																											");
		sql.append("      JOIN VW_OCS_INP1001_02 B																									");
		sql.append("        ON B.HOSP_CODE                  = A.HOSP_CODE																			");
		sql.append("       AND B.PKINP1001                  = A.FKINP1001																			");
		sql.append("       AND B.HO_DONG1                    LIKE CONCAT(:f_ho_dong,'%')															");
		sql.append("      JOIN OCS2003 C																											");
		sql.append("        ON C.HOSP_CODE                  = A.HOSP_CODE																			");
		sql.append("       AND C.PKOCS2003                  = A.FKOCS2003																			");
		sql.append("       AND C.ORDER_GUBUN                NOT LIKE '1%'  /*指示事項除外*/															");
		sql.append("       ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP																			");
		sql.append("     WHERE A.HOSP_CODE                  = :f_hosp_code																			");
		sql.append("       AND A.BUNHO                      LIKE CONCAT(:f_bunho, '%')																");
		sql.append("       AND A.HOPE_DATE                  BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m/%d') 											");
		sql.append("                                        AND STR_TO_DATE(:f_to_date, '%Y/%m/%d') 												");
		sql.append("       AND ((:f_magam_gubun = '%'  AND (CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'				");
		sql.append("                                  OR CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'))		");
		sql.append("         OR  (:f_magam_gubun = '21' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'				");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'		");
		sql.append("                                  AND A.BUNRYU1 IN ('1', '6') /*臨薬*/)															");
		sql.append("         OR  (:f_magam_gubun = '22' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'				");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'		");
		sql.append("                                  AND A.BUNRYU1 = '4'         /*臨注*/)															");
		sql.append("         OR  (:f_magam_gubun = '31' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N'				");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'		");
		sql.append("                                  AND A.BUNRYU1 IN ('1', '6') /*退薬*/)															");
		sql.append("         OR  (:f_magam_gubun = '32' AND CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N'				");
		sql.append("                                  AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'		");
		sql.append("                                  AND A.BUNRYU1 = '4'         /*退注*/)															");
		sql.append("         )																														");
		sql.append("       AND CASE(A.DRG_PRN_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DRG_PRN_YN, 'N') END         = 'N'									");
		sql.append("       AND CASE(A.CHULGO_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CHULGO_YN, 'N') END          = 'N'									");
		sql.append("       AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END            = 'N'										");
		sql.append("       AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN, 'N') END        = 'N'									");
		sql.append("       AND CASE(A.RE_USE_YN) WHEN '' THEN 'N' ELSE IFNULL(A.RE_USE_YN, 'N') END        = 'N'									");
		sql.append("       AND A.DRG_BUNHO                  IS NULL																					");
		sql.append("       AND CASE(A.WONYOI_ORDER_YN) WHEN '' THEN 'N' ELSE IFNULL(A.WONYOI_ORDER_YN, 'N') END  = 'N'								");
		sql.append("       AND CASE(A.NALSU) WHEN '' THEN 0 ELSE IFNULL(A.NALSU, 0) END             > 0												");
		sql.append("     ORDER BY MAGAM_GUBUN, HOPE_DATE, HOPE_TIME, HO_DONG, HO_CODE																");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																									");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_magam_gubun", magamGubun);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdPaInfo> list = new JpaResultMapper().list(query, DRG3010P99grdPaInfo.class);
		return list;
		
	}
	
	@Override
	public List<DRG3010P99grdPrnJusaInfo> getDRG3010P99grdPrnJusaInfo(String hospCode, String language, String hoDong, String orderDate, String hopeDate, String hopeTime,
						String bunho, String resident, String emergency, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')            ORDER_DATE														");
		sql.append("           ,IFNULL(A.MIX_GROUP, '')             MIX_GROUP																	");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																				");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																				");
		sql.append("           ,CAST(A.ORD_SURYANG AS CHAR)           ORD_SURYANG																");
		sql.append("           ,A.DV_TIME               DV_TIME																					");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																		");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																		");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																				");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME							");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																");
		sql.append("           ,IFNULL(CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',										");
		sql.append("                   CASE(A.JUSA_SPD_GUBUN) WHEN '' THEN '0' ELSE 															");
		sql.append("                   IFNULL(A.JUSA_SPD_GUBUN,'0') END, A.HOSP_CODE, :f_language)),'')     BOGYONG_NAME						");
		sql.append("           ,A.POWDER_YN             POWDER_YN																				");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																		");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																		");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																		");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																		");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																		");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																		");
		sql.append("           ,FN_DRG_JUNINP_YN(A.HOSP_CODE, A.FKOCS2003, 'N')      HUBAL_CHANGE_YN											");
		sql.append("           ,A.PHARMACY              PHARMACY																				");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																				");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('JUSA', CASE(A.JUSA) WHEN '' THEN '0' 													");
		sql.append("                             ELSE IFNULL(A.JUSA,'0') END, A.HOSP_CODE, :f_language)     JUSA_NAME							");
		sql.append("           ,D.SUNAME                                          SUNAME														");
		sql.append("           ,IFNULL(CAST(A.DRG_BUNHO AS CHAR), '')             DRG_BUNHO														");
		sql.append("           ,A.FKOCS2003             FKOCS2003																				");
		sql.append("           ,A.APPEND_YN             APPEND_YN																				");
		sql.append("           ,IFNULL(A.RE_USE_YN,'')             RE_USE_YN																	");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE														");
		sql.append("           ,A.HOPE_TIME             HOPE_TIME																				");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																				");
		sql.append("           ,A.DC_YN                 DC_YN																					");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																				");
		sql.append("           ,IFNULL(G.IF_INPUT_CONTROL, '')      IF_INPUT_CONTROL															");
		sql.append("       FROM DRG3010 A																										");
		sql.append("       LEFT JOIN INV0110 B																									");
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																			");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("       LEFT JOIN DRG0120 C																									");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																			");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("       JOIN OUT0101 D																										");
		sql.append("         ON D.BUNHO                = A.BUNHO																				");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("       JOIN INP1001 E																										");
		sql.append("         ON E.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("        AND E.PKINP1001            = A.FKINP1001																			");
		sql.append("        AND E.HO_DONG1             = :f_ho_dong																				");
		sql.append("       JOIN OCS2003 F																										");
		sql.append("         ON F.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("        AND F.PKOCS2003            = A.FKOCS2003																			");
		sql.append("       JOIN OCS0103 G																										");
		sql.append("         ON G.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("        AND G.HANGMOG_CODE         = F.HANGMOG_CODE																			");
		sql.append("      WHERE A.HOSP_CODE            = :f_hosp_code																			");
		sql.append("        AND A.ORDER_DATE           = STR_TO_DATE(:f_order_date, '%Y/%m/%d')													");
		sql.append("        AND A.HOPE_DATE            = STR_TO_DATE(:f_hope_date, '%Y/%m/%d')													");
		sql.append("        AND A.HOPE_TIME            = :f_hope_time																			");
		sql.append("        AND A.BUNHO                = :f_bunho																				");
		sql.append("        AND A.RESIDENT             = :f_doctor																				");
		sql.append("        AND A.BUNRYU1              IN ('4')																					");
		sql.append("        AND ((CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N' AND A.EMERGENCY = 'Y')				");
		sql.append("              OR(CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'))								");
		sql.append("        AND CASE(A.EMERGENCY) WHEN '' THEN 'N' ELSE IFNULL(A.EMERGENCY, 'N') END     = :f_emergency							");
		sql.append("        AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'								");
		sql.append("        AND (A.DRG_BUNHO           IS NULL OR A.DRG_BUNHO = '')																");
		sql.append("        AND A.SOURCE_FKOCS2003     IS NULL																					");
		sql.append("        AND A.NALSU                > 0																						");
		sql.append("        AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END      = 'N'											");
		sql.append("        AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN, 'N') END  = 'N'										");
		sql.append("        AND CASE(A.RE_USE_YN) WHEN '' THEN 'N' ELSE IFNULL(A.RE_USE_YN, 'N') END  = 'N'										");
		sql.append("        AND A.ORDER_DATE BETWEEN G.START_DATE AND IFNULL(G.END_DATE, STR_TO_DATE('99991231','%Y%m%d'))						");
		sql.append("      ORDER BY ORDER_DATE, GROUP_SER, MIX_GROUP, SUNAME																		");

		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																							");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hope_date", hopeDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hope_time", hopeTime);
		query.setParameter("f_doctor", resident);
		query.setParameter("f_emergency", emergency);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdPrnJusaInfo> list = new JpaResultMapper().list(query, DRG3010P99grdPrnJusaInfo.class);
		return list;		
	}
	
	@Override
	public List<DRG3010P99grdPrnJusaInfo> getDRG3010P99grdPrnInfo(String hospCode, String language, String hoDong, String orderDate, String hopeDate, String hopeTime,
			String bunho, String resident, String emergency, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')            ORDER_DATE														");
		sql.append("           ,IFNULL(A.MIX_GROUP, '')             MIX_GROUP																	");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																				");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																				");
		sql.append("           ,CAST(A.ORD_SURYANG AS CHAR)           ORD_SURYANG																");
		sql.append("           ,A.DV_TIME               DV_TIME																					");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																		");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																		");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																				");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME							");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																");
		sql.append("           ,IFNULL(C.BOGYONG_NAME, '')     BOGYONG_NAME																		");
		sql.append("           ,A.POWDER_YN             POWDER_YN																				");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																		");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																		");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																		");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																		");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																		");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																		");
		sql.append("           ,FN_DRG_JUNINP_YN(A.HOSP_CODE, A.FKOCS2003, 'N')      HUBAL_CHANGE_YN											");
		sql.append("           ,A.PHARMACY              PHARMACY																				");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																				");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('JUSA', CASE(A.JUSA) WHEN '' THEN '0' 													");
		sql.append("                             ELSE IFNULL(A.JUSA,'0') END, A.HOSP_CODE, :f_language)     JUSA_NAME							");
		sql.append("           ,D.SUNAME                                          SUNAME														");
		sql.append("           ,IFNULL(CAST(A.DRG_BUNHO AS CHAR), '')             DRG_BUNHO														");
		sql.append("           ,A.FKOCS2003             FKOCS2003																				");
		sql.append("           ,A.APPEND_YN             APPEND_YN																				");
		sql.append("           ,IFNULL(A.RE_USE_YN,'')             RE_USE_YN																	");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE														");
		sql.append("           ,A.HOPE_TIME             HOPE_TIME																				");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																				");
		sql.append("           ,A.DC_YN                 DC_YN																					");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																				");
		sql.append("           ,IFNULL(G.IF_INPUT_CONTROL, '')      IF_INPUT_CONTROL															");
		sql.append("       FROM DRG3010 A																										");
		sql.append("       JOIN INV0110 B																										");
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																			");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("       LEFT JOIN DRG0120 C																									");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																			");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("       JOIN OUT0101 D																										");
		sql.append("         ON D.BUNHO                = A.BUNHO																				");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("       JOIN INP1001 E																										");
		sql.append("         ON E.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("        AND E.PKINP1001            = A.FKINP1001																			");
		sql.append("       JOIN OCS2003 F																										");
		sql.append("         ON F.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("        AND F.PKOCS2003            = A.FKOCS2003																			");
		sql.append("       JOIN OCS0103 G																										");
		sql.append("         ON G.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("        AND G.HANGMOG_CODE         = F.HANGMOG_CODE																			");
		sql.append("      WHERE A.HOSP_CODE            = :f_hosp_code																			");
		sql.append("        AND A.ORDER_DATE           = STR_TO_DATE(:f_order_date, '%Y/%m/%d')													");
		sql.append("        AND A.HOPE_DATE            = STR_TO_DATE(:f_hope_date, '%Y/%m/%d')													");
		sql.append("        AND A.HOPE_TIME            = :f_hope_time																			");
		sql.append("        AND A.BUNHO                = :f_bunho																				");
		sql.append("        AND A.RESIDENT             = :f_doctor																				");
		sql.append("        AND A.BUNRYU1              IN ('1','6')																				");
		sql.append("        AND ((CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'N' AND A.EMERGENCY = 'Y')				");
		sql.append("              OR(CASE(A.APPEND_YN) WHEN '' THEN 'N' ELSE IFNULL(A.APPEND_YN, 'N') END = 'Y'))								");
		sql.append("        AND CASE(A.EMERGENCY) WHEN '' THEN 'N' ELSE IFNULL(A.EMERGENCY, 'N') END     = :f_emergency							");
		sql.append("        AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END = 'N'								");
		sql.append("        AND (A.DRG_BUNHO           IS NULL OR A.DRG_BUNHO = '')																");
		sql.append("        AND A.SOURCE_FKOCS2003     IS NULL																					");
		sql.append("        AND A.NALSU                > 0																						");
		sql.append("        AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END      = 'N'											");
		sql.append("        AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN, 'N') END  = 'N'										");
		sql.append("        AND CASE(A.RE_USE_YN) WHEN '' THEN 'N' ELSE IFNULL(A.RE_USE_YN, 'N') END  = 'N'										");
		sql.append("        AND A.ORDER_DATE BETWEEN G.START_DATE AND IFNULL(G.END_DATE, STR_TO_DATE('99991231','%Y%m%d'))						");
		sql.append("     UNION ALL																												");
		sql.append("        SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')            ORDER_DATE													");
		sql.append("           ,IFNULL(A.MIX_GROUP, '')             MIX_GROUP																	");
		sql.append("           ,A.JAERYO_CODE           JAERYO_CODE																				");
		sql.append("           ,B.JAERYO_NAME           JAERYO_NAME																				");
		sql.append("           ,CAST(A.ORD_SURYANG AS CHAR)           ORD_SURYANG																");
		sql.append("           ,A.DV_TIME               DV_TIME																					");
		sql.append("           ,CAST(A.DV AS CHAR)                    DV																		");
		sql.append("           ,CAST(A.NALSU AS CHAR)                NALSU																		");
		sql.append("           ,A.ORDER_DANUI           ORDER_DANUI																				");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language) DANUI_NAME							");
		sql.append("           ,IFNULL(A.BOGYONG_CODE, '')          BOGYONG_CODE																");
		sql.append("           ,IFNULL(C.BOGYONG_NAME, '')     BOGYONG_NAME																		");
		sql.append("           ,A.POWDER_YN             POWDER_YN																				");
		sql.append("           ,IFNULL(A.REMARK, '')                REMARK																		");
		sql.append("           ,IFNULL(A.DV_1, '')                  DV_1																		");
		sql.append("           ,IFNULL(A.DV_2, '')                  DV_2																		");
		sql.append("           ,IFNULL(A.DV_3, '')                  DV_3																		");
		sql.append("           ,IFNULL(A.DV_4, '')                  DV_4																		");
		sql.append("           ,IFNULL(A.DV_5, '')                  DV_5																		");
		sql.append("           ,FN_DRG_JUNINP_YN(A.HOSP_CODE, A.FKOCS2003, 'N')      HUBAL_CHANGE_YN											");
		sql.append("           ,A.PHARMACY              PHARMACY																				");
		sql.append("           ,A.DRG_PACK_YN           DRG_PACK_YN																				");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('JUSA', CASE(A.JUSA) WHEN '' THEN '0'														");
		sql.append("                             ELSE IFNULL(A.JUSA,'0') END, A.HOSP_CODE, :f_language)     JUSA_NAME							");
		sql.append("           ,D.SUNAME                                          SUNAME														");
		sql.append("           ,IFNULL(CAST(A.DRG_BUNHO AS CHAR), '')             DRG_BUNHO														");
		sql.append("           ,A.FKOCS2003             FKOCS2003																				");
		sql.append("           ,A.APPEND_YN             APPEND_YN																				");
		sql.append("           ,IFNULL(A.RE_USE_YN,'')             RE_USE_YN																	");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')             HOPE_DATE														");
		sql.append("           ,A.HOPE_TIME             HOPE_TIME																				");
		sql.append("           ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER																				");
		sql.append("           ,A.DC_YN                 DC_YN																					");
		sql.append("           ,F.ORDER_GUBUN           ORDER_GUBUN																				");
		sql.append("           ,IFNULL(G.IF_INPUT_CONTROL, '')      IF_INPUT_CONTROL															");
		sql.append("       FROM DRG3010 A																										");
		sql.append("       JOIN INV0110 B																										");
		sql.append("         ON B.JAERYO_CODE          = A.JAERYO_CODE																			");
		sql.append("        AND B.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("       LEFT JOIN DRG0120 C																									");
		sql.append("         ON C.BOGYONG_CODE         = A.BOGYONG_CODE																			");
		sql.append("        AND C.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("       JOIN OUT0101 D																										");
		sql.append("         ON D.BUNHO                = A.BUNHO																				");
		sql.append("        AND D.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("       JOIN INP1001 E																										");
		sql.append("         ON E.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("        AND E.PKINP1001            = A.FKINP1001																			");
		sql.append("        AND E.HO_DONG1             = :f_ho_dong																				");
		sql.append("       JOIN OCS2003 F																										");
		sql.append("         ON F.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("        AND F.PKOCS2003            = A.FKOCS2003																			");
		sql.append("       JOIN OCS0103 G																										");
		sql.append("         ON G.HOSP_CODE            = A.HOSP_CODE																			");
		sql.append("        AND G.HANGMOG_CODE         = F.HANGMOG_CODE																			");
		sql.append("      WHERE A.HOSP_CODE            = :f_hosp_code																			");
		sql.append("        AND A.ORDER_DATE           = STR_TO_DATE(:f_order_date, '%Y/%m/%d')													");
		sql.append("        AND A.HOPE_DATE            = STR_TO_DATE(:f_hope_date, '%Y/%m/%d')													");
		sql.append("        AND A.HOPE_TIME            = :f_hope_time																			");
		sql.append("        AND A.BUNHO                = :f_bunho																				");
		sql.append("        AND A.RESIDENT             = :f_doctor																				");
		sql.append("        AND A.BUNRYU1              IN ('1','6')																				");
		sql.append("        AND CASE(A.EMERGENCY) WHEN '' THEN 'N' ELSE IFNULL(A.EMERGENCY, 'N') END     = :f_emergency							");
		sql.append("        AND CASE(A.TOIWON_DRG_YN) WHEN '' THEN 'N' ELSE IFNULL(A.TOIWON_DRG_YN, 'N') END <> 'N'								");
		sql.append("        AND (A.DRG_BUNHO           IS NULL OR A.DRG_BUNHO = '')																");
		sql.append("        AND A.SOURCE_FKOCS2003     IS NULL																					");
		sql.append("        AND A.NALSU                > 0																						");
		sql.append("        AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END      = 'N'											");
		sql.append("        AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN, 'N') END  = 'N'										");
		sql.append("        AND CASE(A.RE_USE_YN) WHEN '' THEN 'N' ELSE IFNULL(A.RE_USE_YN, 'N') END  = 'N'										");
		sql.append("        AND A.ORDER_DATE BETWEEN G.START_DATE AND IFNULL(G.END_DATE, STR_TO_DATE('99991231','%Y%m%d'))						");
		sql.append("      ORDER BY ORDER_DATE, GROUP_SER, MIX_GROUP, SUNAME, JAERYO_CODE														");

		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																							");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hope_date", hopeDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hope_time", hopeTime);
		query.setParameter("f_doctor", resident);
		query.setParameter("f_emergency", emergency);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		List<DRG3010P99grdPrnJusaInfo> list = new JpaResultMapper().list(query, DRG3010P99grdPrnJusaInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3041P06LabelInfo> getDRG3041P06LabelDataInfo(String hospCode, String language, String jubsuDate, String drgBunho, String rp) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																								");
		sql.append("		A.BUNHO                                                                                                                                     BUNHO,				");
		sql.append("	    CAST(A.DRG_BUNHO AS CHAR)                         	                                                                                        DRG_BUNHO,			");
		sql.append("	    FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, :f_hosp_code, :f_language)    ORDER_DATE_TEXT,																	");
		sql.append("	    DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')                                                                                                       JUBSU_DATE,			");
		sql.append("	    DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                                                                                       ORDER_DATE,			");
		sql.append("	    CONCAT('Rp.', E.SERIAL_V, 'Rp.', E.SERIAL_V, (CASE A.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END)) 											SERIAL_V,			");
		sql.append("	    E.SERIAL_V                                                                                                                                  SERIAL_TEXT,		");
		sql.append("	    D.SUNAME                                                                                                                                    SUNAME,				");
		sql.append("	    D.SUNAME2                                                                                                                                   SUNAME2,			");
		sql.append("	    FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, :f_hosp_code)          																			SEX_AGE,			");
		sql.append("	    IFNULL(SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TRUNCDATE(CURRENT_TIMESTAMP, 'DD'), 'C'),1,20), '')             HO_CODE,			");
		sql.append("	    IFNULL(SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TRUNCDATE(CURRENT_TIMESTAMP, 'DD'), 'D'),1,20), '')             HO_DONG,			");
		sql.append("	    IFNULL(MAX(CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))), '') BOGYONG_NAME,	");
		sql.append("	    CAST(MAX(A.DV) AS CHAR)                                           																			CNT					");
		sql.append("	FROM																																								");
		sql.append("		DRG3010 A 	JOIN 		DRG2035 E																																");
		sql.append("	    			ON 			A.JUBSU_DATE	= E.JUBSU_DATE																											");
		sql.append("	                AND 		A.DRG_BUNHO     = E.DRG_BUNHO																											");
		sql.append("	                AND 		A.FKOCS2003     = E.FKOCS2003																											");
		sql.append("	                JOIN 		OUT0101 D																																");
		sql.append("	                ON 			A.BUNHO 		= D.BUNHO																												");
		sql.append("	    			LEFT JOIN 	DRG0120 C																																");
		sql.append("	                ON 			A.BOGYONG_CODE 	= C.BOGYONG_CODE																										");
		sql.append("	                JOIN 		INV0110 B																																");
		sql.append("	                ON 			A.JAERYO_CODE 	= B.JAERYO_CODE																											");
		sql.append("	WHERE																																								");
		sql.append("		A.HOSP_CODE          			= :f_hosp_code																													");
		sql.append("	    AND A.JUBSU_DATE         		= :f_jubsu_date																													");
		sql.append("	    AND A.DRG_BUNHO          		= :f_drg_bunho																													");
		sql.append("	    AND A.BUNRYU1            		= '4'																															");
		sql.append("	    AND IFNULL(A.DC_YN,'N')     	= 'N'																															");
		sql.append("	    AND IFNULL(A.BANNAB_YN,'N') 	= 'N'																															");
		sql.append("	    AND E.SERIAL_V           		= :f_rp																															");
		sql.append("	GROUP BY																																							");
		sql.append("		A.BUNHO,																																						");
		sql.append("	    DRG_BUNHO,																																						");
		sql.append("	    ORDER_DATE_TEXT,																																				");
		sql.append("	    A.JUBSU_DATE,																																					");
		sql.append("	    A.ORDER_DATE,																																					");
		sql.append("	    CONCAT('Rp.', E.SERIAL_V, CASE A.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END),																					");
		sql.append("	    E.SERIAL_V,																																						");
		sql.append("	    D.SUNAME,																																						");
		sql.append("	    D.SUNAME2,																																						");
		sql.append("	    FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, :f_hosp_code),																										");
		sql.append("	    SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TRUNCDATE(CURRENT_TIMESTAMP, 'DD'), 'C'),1,20),											");
		sql.append("	    SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TRUNCDATE(CURRENT_TIMESTAMP, 'DD'), 'D'),1,20)												");
		sql.append("	ORDER BY																																							");
		sql.append("		LPAD(E.SERIAL_V,4, '0')																																			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_rp", rp);
		
		List<DRG3041P06LabelInfo> listInfo = new JpaResultMapper().list(query, DRG3041P06LabelInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3041P06SerialInfo> getDRG3041P06SerialInfo(String hospCode, String language, String k, String cnt, String jubsuDate, String drgBunho, String serialText) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																															");
		sql.append("		A.JAERYO_CODE                                                                                       JAERYO_CODE,			");
		sql.append("	    CAST(A.NALSU AS CHAR)                                                                               NALSU,					");
		sql.append("	    A.DIVIDE                                                                                            DIVIDE,					");
		sql.append("	    CAST(A.ORDER_SURYANG AS CHAR)                                                                       ORDER_SURYANG,			");
		sql.append("	    CAST(A.SUBUL_SURYANG AS CHAR)                                                                       SUBUL_SURYANG,			");
		sql.append("	    CAST(A.ORD_SURYANG AS CHAR)                                                                         ORD_SURYANG,			");
		sql.append("	    A.ORDER_DANUI                                                                                       ORDER_DANUI,			");
		sql.append("	    A.SUBUL_DANUI                                                                                       SUBUL_DANUI,			");
		sql.append("	    A.BUNRYU1                                                                                           BUNRYU1,				");
		sql.append("	    IFNULL(A.BUNRYU2, '')                                                                               BUNRYU2,				");
		sql.append("	    IFNULL(A.BUNRYU3, '')                                                                               BUNRYU3,				");
		sql.append("	    IFNULL(A.BUNRYU4, '')                                                                               BUNRYU4,				");
		sql.append("	    IFNULL(A.REMARK, '')                                                                                REMARK,					");
		sql.append("	    A.DV_TIME                                                                                           DV_TIME,				");
		sql.append("	    CAST(A.DV AS CHAR)                                                                                  DV,						");
		sql.append("	    IFNULL(A.BUNRYU6, '')                                                                               BUNRYU6,				");
		sql.append("	    IFNULL(A.MIX_GROUP, '')                                                                             MIX_GROUP,				");
		sql.append("	    IFNULL(A.DV_1, '')                                                                                  DV_1,					");
		sql.append("	    IFNULL(A.DV_2, '')                                                                                  DV_2,					");
		sql.append("	    IFNULL(A.DV_3, '')                                                                                  DV_3,					");
		sql.append("	    IFNULL(A.DV_4, '')                                                                                  DV_4,					");
		sql.append("	    IFNULL(A.DV_5, '')                                                                                  DV_5,					");
		sql.append("	    A.HUBAL_CHANGE_YN                                                                                   HUBAL_CHANGE_YN,		");
		sql.append("	    A.PHARMACY                                                                                          PHARMACY,				");
		sql.append("	    IFNULL(A.JUSA_SPD_GUBUN, '')                                                                        JUSA_SPD_GUBUN,			");
		sql.append("	    A.DRG_PACK_YN                                                                                       DRG_PACK_YN,			");
		sql.append("	    IFNULL(A.JUSA, '')                                                                                  JUSA,					");
		sql.append("	    B.HANGMOG_NAME                                                                                      JAERYO_NAME,			");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)    	                DANUI_NAME,				");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language)    	                SUBUL_DANUI_NAME,		");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('JUSA', IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)                        JUSA_NAME,				");
		sql.append("	    CONCAT(:k, '/', :f_cnt)                																RP2,					");
		sql.append("	    CONCAT('*', DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), CAST(A.DRG_BUNHO AS CHAR), E.SERIAL_V, :k, '*') 	BARCODE_NO,				");
		sql.append("	    'A'                                                  												DATA_GUBUN				");
		sql.append("	FROM																															");
		sql.append("		DRG3010 A 	JOIN 	DRG2035 E																								");
		sql.append("					ON 	    A.HOSP_CODE 	= E.HOSP_CODE																			");
		sql.append("		        	AND     A.JUBSU_DATE 	= E.JUBSU_DATE																			");
		sql.append("		        	AND     A.DRG_BUNHO 	= E.DRG_BUNHO																			");
		sql.append("		        	AND     A.FKOCS2003 	= E.FKOCS2003																			");
		sql.append("					JOIN 	OCS2003 C																								");
		sql.append("					ON 		A.HOSP_CODE  	= C.HOSP_CODE																			");
		sql.append("	        		AND 	A.FKOCS2003 	= C.PKOCS2003																			");
		sql.append("					JOIN 	OCS0103 B																								");
		sql.append("					ON 		B.HOSP_CODE 	= C.HOSP_CODE 																			");
		sql.append("	        		AND B.HANGMOG_CODE 		= C.HANGMOG_CODE																		");
		sql.append("	WHERE																															");
		sql.append("		A.HOSP_CODE          			= :f_hosp_code																				");
		sql.append("	    AND A.JUBSU_DATE         		= :f_jubsu_date																				");
		sql.append("	    AND A.DRG_BUNHO          		= :f_drg_bunho																				");
		sql.append("	    AND A.DIVIDE            		>= :k																						");
		sql.append("	    AND A.BUNRYU1            		IN ('4')																					");
		sql.append("	    AND IFNULL(A.DC_YN,'N')     	= 'N'																						");
		sql.append("	    AND IFNULL(A.BANNAB_YN,'N') 	= 'N'																						");
		sql.append("	    AND E.SERIAL_V           		= :f_serial_text																			");
		sql.append("	    AND C.ORDER_DATE         		BETWEEN   B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31')									");
		sql.append("	ORDER BY																														");
		sql.append("	    CONCAT(	LTRIM(LPAD(E.SERIAL_V, 4, '0')), LTRIM(LPAD(A.GROUP_SER, 4, '0')), IFNULL(A.MIX_GROUP, ' '),						");
		sql.append("	        	LTRIM(LPAD(CASE C.BOM_OCCUR_YN WHEN 'Y' THEN (C.SEQ + 100) ELSE C.SEQ END, 4, '0')),								");
		sql.append("	        	LTRIM(LPAD(C.PKOCS2003, 10, '0')))																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("k", k);
		query.setParameter("f_cnt", cnt);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_serial_text", serialText);
		
		List<DRG3041P06SerialInfo> listInfo = new JpaResultMapper().list(query, DRG3041P06SerialInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10GrdDcOrderInfo> getDRG3010P10GrdDcOrderInfo(String hospCode, String language, Date jusuDate,
			Double drgBunho, String bunho, String magamBunryu) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.ORDER_DATE            ORDER_DATE                                                                                ");
		sql.append("	      ,A.MIX_GROUP             MIX_GROUP                                                                                 ");
		sql.append("	      ,A.JAERYO_CODE           JAERYO_CODE                                                                               ");
		sql.append("	      ,B.JAERYO_NAME           JAERYO_NAME                                                                               ");
		sql.append("	      ,A.ORD_SURYANG           ORD_SURYANG                                                                               ");
		sql.append("	      ,A.DV_TIME               DV_TIME                                                                                   ");
		sql.append("	      ,A.DV                    DV                                                                                        ");
		sql.append("	      ,A.NALSU                 NALSU                                                                                     ");
		sql.append("	      ,A.ORDER_DANUI           ORDER_DANUI                                                                               ");
		sql.append("	      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)                                      ");
		sql.append("								   		DANUI_NAME                                                                           ");
		sql.append("	      ,IFNULL(A.BOGYONG_CODE, '')	BOGYONG_CODE                                                                         ");
		sql.append("	      ,IFNULL(C.BOGYONG_NAME, '')	BOGYONG_NAME                                                                         ");
		sql.append("	      ,A.POWDER_YN             POWDER_YN                                                                                 ");
		sql.append("	      ,IFNULL(A.REMARK, '')    REMARK                                                                                    ");
		sql.append("	      ,A.DV_1                  DV_1                                                                                      ");
		sql.append("	      ,A.DV_2                  DV_2                                                                                      ");
		sql.append("	      ,A.DV_3                  DV_3                                                                                      ");
		sql.append("	      ,A.DV_4                  DV_4                                                                                      ");
		sql.append("	      ,A.DV_5                  DV_5                                                                                      ");
		sql.append("	      ,FN_DRG_JUNINP_YN(:f_hosp_code, A.FKOCS2003, null)                                                                 ");
		sql.append("								   HUBAL_CHANGE_YN                                                                           ");
		sql.append("	      ,A.PHARMACY              PHARMACY                                                                                  ");
		sql.append("	      ,A.DRG_PACK_YN           DRG_PACK_YN                                                                               ");
		sql.append("	      ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)                                       ");
		sql.append("								   JUSA_NAME                                                                                 ");
		sql.append("	      ,D.SUNAME                SUNAME                                                                                    ");
		sql.append("	      ,A.DRG_BUNHO             DRG_BUNHO                                                                                 ");
		sql.append("	      ,A.FKOCS2003             FKOCS2003                                                                                 ");
		sql.append("	      ,A.APPEND_YN             APPEND_YN                                                                                 ");
		sql.append("	      ,IFNULL(A.RE_USE_YN,'')  RE_USE_YN                                                                                 ");
		sql.append("	      ,A.HOPE_DATE             HOPE_DATE                                                                                 ");
		sql.append("	      ,A.HOPE_TIME             HOPE_TIME                                                                                 ");
		sql.append("	      ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER                                                                                 ");
		sql.append("	      ,A.DC_YN                 DC_YN                                                                                     ");
		sql.append("	      ,F.ORDER_GUBUN           ORDER_GUBUN                                                                               ");
		sql.append("	      ,IFNULL(G.IF_INPUT_CONTROL,'') 	   IF_INPUT_CONTROL                                                              ");
		sql.append("	      ,A.BANNAB_YN             BANNAB_YN                                                                                 ");
		sql.append("	  FROM DRG3010 A                                                                                                         ");
		sql.append("	  JOIN INP1001 E ON E.HOSP_CODE		= A.HOSP_CODE                                                                        ");
		sql.append("					AND E.PKINP1001 	= A.FKINP1001                                                                        ");
		sql.append("	  LEFT JOIN INV0110 B ON B.HOSP_CODE   	= A.HOSP_CODE                                                                    ");
		sql.append("						 AND B.JAERYO_CODE  = A.JAERYO_CODE                                                                  ");
		sql.append("	  LEFT JOIN DRG0120 C ON C.HOSP_CODE    = A.HOSP_CODE                                                                    ");
		sql.append("						 AND C.BOGYONG_CODE = A.BOGYONG_CODE                                                                 ");
		sql.append("	  JOIN OUT0101 D ON D.HOSP_CODE         = A.HOSP_CODE                                                                    ");
		sql.append("					AND D.BUNHO             = A.BUNHO                                                                        ");
		sql.append("	  JOIN OCS2003 F ON F.HOSP_CODE         = A.HOSP_CODE                                                                    ");
		sql.append("					AND F.PKOCS2003         = A.FKOCS2003                                                                    ");
		sql.append("	  JOIN OCS0103 G ON F.HOSP_CODE         = G.HOSP_CODE                                                                    ");
		sql.append("				    AND F.HANGMOG_CODE      = G.HANGMOG_CODE                                                                 ");
		sql.append("				    AND A.ORDER_DATE BETWEEN G.START_DATE AND IFNULL(G.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))      ");
		sql.append("	 WHERE A.HOSP_CODE            = :f_hosp_code                                                                             ");
		sql.append("	   AND A.JUBSU_DATE           = :f_jubsu_date                                                                            ");
		sql.append("	   AND A.DRG_BUNHO            = :f_drg_bunho                                                                             ");
		sql.append("	   AND A.BUNHO                = :f_bunho                                                                                 ");
		sql.append("	   AND :f_magam_bunryu        = '1'                                                                                      ");
		sql.append("	                                                                                                                         ");
		sql.append("	UNION ALL                                                                                                                ");
		sql.append("	                                                                                                                         ");
		sql.append("	SELECT A.ORDER_DATE            ORDER_DATE                                                                                ");
		sql.append("	      ,A.MIX_GROUP             MIX_GROUP                                                                                 ");
		sql.append("	      ,A.JAERYO_CODE           JAERYO_CODE                                                                               ");
		sql.append("	      ,B.JAERYO_NAME           JAERYO_NAME                                                                               ");
		sql.append("	      ,A.ORD_SURYANG           ORD_SURYANG                                                                               ");
		sql.append("	      ,A.DV_TIME               DV_TIME                                                                                   ");
		sql.append("	      ,A.DV                    DV                                                                                        ");
		sql.append("	      ,A.NALSU                 NALSU                                                                                     ");
		sql.append("	      ,A.ORDER_DANUI           ORDER_DANUI                                                                               ");
		sql.append("	      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)                                      ");
		sql.append("										DANUI_NAME                                                                           ");
		sql.append("	      ,IFNULL(A.BOGYONG_CODE,'')	BOGYONG_CODE                                                                         ");
		sql.append("	      ,IFNULL(C.BOGYONG_NAME, '')	BOGYONG_NAME                                                                         ");
		sql.append("	      ,A.POWDER_YN             POWDER_YN                                                                                 ");
		sql.append("	      ,IFNULL(A.REMARK, '')    REMARK                                                                                    ");
		sql.append("	      ,A.DV_1                  DV_1                                                                                      ");
		sql.append("	      ,A.DV_2                  DV_2                                                                                      ");
		sql.append("	      ,A.DV_3                  DV_3                                                                                      ");
		sql.append("	      ,A.DV_4                  DV_4                                                                                      ");
		sql.append("	      ,A.DV_5                  DV_5                                                                                      ");
		sql.append("	      ,FN_DRG_JUNINP_YN(:f_hosp_code, A.FKOCS2003, null)                                                                 ");
		sql.append("								   HUBAL_CHANGE_YN                                                                           ");
		sql.append("	      ,A.PHARMACY              PHARMACY                                                                                  ");
		sql.append("	      ,A.DRG_PACK_YN           DRG_PACK_YN                                                                               ");
		sql.append("	      ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)                                       ");
		sql.append("								   JUSA_NAME                                                                                 ");
		sql.append("	      ,D.SUNAME                SUNAME                                                                                    ");
		sql.append("	      ,A.DRG_BUNHO             DRG_BUNHO                                                                                 ");
		sql.append("	      ,A.FKOCS2003             FKOCS2003                                                                                 ");
		sql.append("	      ,A.APPEND_YN             APPEND_YN                                                                                 ");
		sql.append("	      ,IFNULL(A.RE_USE_YN, '') RE_USE_YN                                                                                 ");
		sql.append("	      ,A.HOPE_DATE             HOPE_DATE                                                                                 ");
		sql.append("	      ,A.HOPE_TIME             HOPE_TIME                                                                                 ");
		sql.append("	      ,SUBSTR(A.GROUP_SER,2,2) GROUP_SER                                                                                 ");
		sql.append("	      ,A.DC_YN                 DC_YN                                                                                     ");
		sql.append("	      ,F.ORDER_GUBUN           ORDER_GUBUN                                                                               ");
		sql.append("	      ,IFNULL(G.IF_INPUT_CONTROL,'') 	   IF_INPUT_CONTROL                                                              ");
		sql.append("	      ,A.BANNAB_YN             BANNAB_YN                                                                                 ");
		sql.append("	  FROM  (SELECT *                                                                                                        ");
		sql.append("	          FROM DRG3010 Y                                                                                                 ");
		sql.append("	         WHERE Y.HOSP_CODE = :f_hosp_code                                                                                ");
		sql.append("	           AND Y.SOURCE_FKOCS2003 IN (SELECT X.FKOCS2003                                                                 ");
		sql.append("	                                        FROM DRG3010 X                                                                   ");
		sql.append("	                                       WHERE X.HOSP_CODE  = :f_hosp_code                                                 ");
		sql.append("	                                         AND X.JUBSU_DATE = :f_jubsu_date                                                ");
		sql.append("	                                         AND X.DRG_BUNHO  = :f_drg_bunho                                                 ");
		sql.append("	                                         AND X.BUNHO      = :f_bunho)                                                    ");
		sql.append("	        )       A                                                                                                        ");
		sql.append("	  JOIN INP1001 E ON E.HOSP_CODE		= A.HOSP_CODE                                                                        ");
		sql.append("					AND E.PKINP1001     = A.FKINP1001                                                                        ");
		sql.append("	  LEFT JOIN INV0110 B ON B.HOSP_CODE    = A.HOSP_CODE                                                                    ");
		sql.append("						 AND B.JAERYO_CODE  = A.JAERYO_CODE		                                                             ");
		sql.append("	  LEFT JOIN DRG0120 C ON C.HOSP_CODE    = A.HOSP_CODE                                                                    ");
		sql.append("						 AND C.BOGYONG_CODE = A.BOGYONG_CODE                                                                 ");
		sql.append("	  JOIN OUT0101 D ON D.HOSP_CODE         = A.HOSP_CODE                                                                    ");
		sql.append("					AND D.BUNHO             = A.BUNHO                                                                        ");
		sql.append("	  JOIN OCS2003 F ON F.HOSP_CODE         = A.HOSP_CODE                                                                    ");
		sql.append("					AND F.PKOCS2003         = A.FKOCS2003                                                                    ");
		sql.append("	  JOIN OCS0103 G ON F.HOSP_CODE         = G.HOSP_CODE                                                                    ");
		sql.append("				    AND F.HANGMOG_CODE      = G.HANGMOG_CODE                                                                 ");
		sql.append("				    AND A.ORDER_DATE BETWEEN G.START_DATE AND IFNULL(G.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))      ");
		sql.append("	 WHERE :f_magam_bunryu        = '1'                                                                                      ");
		sql.append("	 ORDER BY ORDER_DATE, HOPE_DATE DESC, MIX_GROUP, JUSA_NAME, JAERYO_CODE                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jusuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_magam_bunryu", magamBunryu);
		
		List<DRG3010P10GrdDcOrderInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdDcOrderInfo.class);
		return listInfo;
	}
	
	@Override
	public List<DRG3041P05LabelInfo> getDRG3041P05LabelInfo(String hospCode, String language, String jubsuDate, String drgBunho, String rp) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																								");
		sql.append("		A.BUNHO                                                                                                                                     BUNHO,				");
		sql.append("	    CAST(A.DRG_BUNHO AS CHAR)                         	                                                                                        DRG_BUNHO,			");
		sql.append("	    FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, :f_hosp_code, :f_language)    ORDER_DATE_TEXT,																	");
		sql.append("	    DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')                                                                                                       JUBSU_DATE,			");
		sql.append("	    DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                                                                                       ORDER_DATE,			");
		sql.append("	    CONCAT('Rp.', E.SERIAL_V, 'Rp.', E.SERIAL_V, (CASE A.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END)) 											SERIAL_V,			");
		sql.append("	    E.SERIAL_V                                                                                                                                  SERIAL_TEXT,		");
		sql.append("	    D.SUNAME                                                                                                                                    SUNAME,				");
		sql.append("	    D.SUNAME2                                                                                                                                   SUNAME2,			");
		sql.append("	    FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, :f_hosp_code)          																			SEX_AGE,			");
		sql.append("	    IFNULL(SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TRUNCDATE(CURRENT_TIMESTAMP, 'DD'), 'C'),1,20), '')             HO_CODE,			");
		sql.append("	    IFNULL(SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TRUNCDATE(CURRENT_TIMESTAMP, 'DD'), 'D'),1,20), '')             HO_DONG,			");
		sql.append("	    IFNULL(MAX(CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))), '') BOGYONG_NAME,	");
		sql.append("	    CAST(MAX(A.DV) AS CHAR)                                           																			CNT					");
		sql.append("	FROM																																								");
		sql.append("		DRG3010 A 	JOIN 		DRG2035 E																																");
		sql.append("	    			ON 			A.JUBSU_DATE	= E.JUBSU_DATE																											");
		sql.append("	                AND 		A.DRG_BUNHO     = E.DRG_BUNHO																											");
		sql.append("	                AND 		A.FKOCS2003     = E.FKOCS2003																											");
		sql.append("	                JOIN 		OUT0101 D																																");
		sql.append("	                ON 			A.BUNHO 		= D.BUNHO																												");
		sql.append("	    			LEFT JOIN 	DRG0120 C																																");
		sql.append("	                ON 			A.BOGYONG_CODE 	= C.BOGYONG_CODE																										");
		sql.append("	                JOIN 		INV0110 B																																");
		sql.append("	                ON 			A.JAERYO_CODE 	= B.JAERYO_CODE																											");
		sql.append("	WHERE																																								");
		sql.append("		A.HOSP_CODE          			= :f_hosp_code																													");
		sql.append("	    AND A.JUBSU_DATE         		= :f_jubsu_date																													");
		sql.append("	    AND A.DRG_BUNHO          		= :f_drg_bunho																													");
		sql.append("	    AND A.BUNRYU1            		= '4'																															");
		sql.append("	    AND IFNULL(A.DC_YN,'N')     	= 'N'																															");
		sql.append("	    AND IFNULL(A.BANNAB_YN,'N') 	= 'N'																															");
		sql.append("	    AND E.SERIAL_V           		= :f_rp																															");
		sql.append("	GROUP BY																																							");
		sql.append("		A.BUNHO,																																						");
		sql.append("	    DRG_BUNHO,																																						");
		sql.append("	    ORDER_DATE_TEXT,																																				");
		sql.append("	    A.JUBSU_DATE,																																					");
		sql.append("	    A.ORDER_DATE,																																					");
		sql.append("	    CONCAT('Rp.', E.SERIAL_V, CASE A.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END),																					");
		sql.append("	    E.SERIAL_V,																																						");
		sql.append("	    D.SUNAME,																																						");
		sql.append("	    D.SUNAME2,																																						");
		sql.append("	    FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, :f_hosp_code),																										");
		sql.append("	    SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TRUNCDATE(CURRENT_TIMESTAMP, 'DD'), 'C'),1,20),											");
		sql.append("	    SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TRUNCDATE(CURRENT_TIMESTAMP, 'DD'), 'D'),1,20)												");
		sql.append("	ORDER BY																																							");
		sql.append("		LPAD(E.SERIAL_V,4, '0')																																			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_rp", rp);
		
		List<DRG3041P05LabelInfo> listInfo = new JpaResultMapper().list(query, DRG3041P05LabelInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3041P05SerialInfo> getDRG3041P05SerialInfo(String hospCode, String language, String k, String cnt, String jubsuDate, String drgBunho, String serialText) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																															");
		sql.append("		A.JAERYO_CODE                                                                                       JAERYO_CODE,			");
		sql.append("	    CAST(A.NALSU AS CHAR)                                                                               NALSU,					");
		sql.append("	    A.DIVIDE                                                                                            DIVIDE,					");
		sql.append("	    CAST(A.ORDER_SURYANG AS CHAR)                                                                       ORDER_SURYANG,			");
		sql.append("	    CAST(A.SUBUL_SURYANG AS CHAR)                                                                       SUBUL_SURYANG,			");
		sql.append("	    CAST(A.ORD_SURYANG AS CHAR)                                                                         ORD_SURYANG,			");
		sql.append("	    A.ORDER_DANUI                                                                                       ORDER_DANUI,			");
		sql.append("	    A.SUBUL_DANUI                                                                                       SUBUL_DANUI,			");
		sql.append("	    A.BUNRYU1                                                                                           BUNRYU1,				");
		sql.append("	    IFNULL(A.BUNRYU2, '')                                                                               BUNRYU2,				");
		sql.append("	    IFNULL(A.BUNRYU3, '')                                                                               BUNRYU3,				");
		sql.append("	    IFNULL(A.BUNRYU4, '')                                                                               BUNRYU4,				");
		sql.append("	    IFNULL(A.REMARK, '')                                                                                REMARK,					");
		sql.append("	    A.DV_TIME                                                                                           DV_TIME,				");
		sql.append("	    CAST(A.DV AS CHAR)                                                                                  DV,						");
		sql.append("	    IFNULL(A.BUNRYU6, '')                                                                               BUNRYU6,				");
		sql.append("	    IFNULL(A.MIX_GROUP, '')                                                                             MIX_GROUP,				");
		sql.append("	    IFNULL(A.DV_1, '')                                                                                  DV_1,					");
		sql.append("	    IFNULL(A.DV_2, '')                                                                                  DV_2,					");
		sql.append("	    IFNULL(A.DV_3, '')                                                                                  DV_3,					");
		sql.append("	    IFNULL(A.DV_4, '')                                                                                  DV_4,					");
		sql.append("	    IFNULL(A.DV_5, '')                                                                                  DV_5,					");
		sql.append("	    A.HUBAL_CHANGE_YN                                                                                   HUBAL_CHANGE_YN,		");
		sql.append("	    A.PHARMACY                                                                                          PHARMACY,				");
		sql.append("	    IFNULL(A.JUSA_SPD_GUBUN, '')                                                                        JUSA_SPD_GUBUN,			");
		sql.append("	    A.DRG_PACK_YN                                                                                       DRG_PACK_YN,			");
		sql.append("	    IFNULL(A.JUSA, '')                                                                                  JUSA,					");
		sql.append("	    B.HANGMOG_NAME                                                                                      JAERYO_NAME,			");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)    	                DANUI_NAME,				");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language)    	                SUBUL_DANUI_NAME,		");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('JUSA', IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)                        JUSA_NAME,				");
		sql.append("	    CONCAT(:k, '/', :f_cnt)                																RP2,					");
		sql.append("	    CONCAT('*', DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), CAST(A.DRG_BUNHO AS CHAR), E.SERIAL_V, :k, '*') 	BARCODE_NO,				");
		sql.append("	    'A'                                                  												DATA_GUBUN				");
		sql.append("	FROM																															");
		sql.append("		DRG3010 A 	JOIN 	DRG2035 E																								");
		sql.append("					ON 	    A.HOSP_CODE 	= E.HOSP_CODE																			");
		sql.append("		        	AND     A.JUBSU_DATE 	= E.JUBSU_DATE																			");
		sql.append("		        	AND     A.DRG_BUNHO 	= E.DRG_BUNHO																			");
		sql.append("		        	AND     A.FKOCS2003 	= E.FKOCS2003																			");
		sql.append("					JOIN 	OCS2003 C																								");
		sql.append("					ON 		A.HOSP_CODE  	= C.HOSP_CODE																			");
		sql.append("	        		AND 	A.FKOCS2003 	= C.PKOCS2003																			");
		sql.append("					JOIN 	OCS0103 B																								");
		sql.append("					ON 		B.HOSP_CODE 	= C.HOSP_CODE 																			");
		sql.append("	        		AND B.HANGMOG_CODE 		= C.HANGMOG_CODE																		");
		sql.append("	WHERE																															");
		sql.append("		A.HOSP_CODE          			= :f_hosp_code																				");
		sql.append("	    AND A.JUBSU_DATE         		= :f_jubsu_date																				");
		sql.append("	    AND A.DRG_BUNHO          		= :f_drg_bunho																				");
		sql.append("	    AND A.DIVIDE            		>= :k																						");
		sql.append("	    AND A.BUNRYU1            		IN ('4')																					");
		sql.append("	    AND IFNULL(A.DC_YN,'N')     	= 'N'																						");
		sql.append("	    AND IFNULL(A.BANNAB_YN,'N') 	= 'N'																						");
		sql.append("	    AND E.SERIAL_V           		= :f_serial_text																			");
		sql.append("	    AND C.ORDER_DATE         		BETWEEN   B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31')									");
		sql.append("	ORDER BY																														");
		sql.append("	    CONCAT(	LTRIM(LPAD(E.SERIAL_V, 4, '0')), LTRIM(LPAD(A.GROUP_SER, 4, '0')), IFNULL(A.MIX_GROUP, ' '),						");
		sql.append("	        	LTRIM(LPAD(CASE C.BOM_OCCUR_YN WHEN 'Y' THEN (C.SEQ + 100) ELSE C.SEQ END, 4, '0')),								");
		sql.append("	        	LTRIM(LPAD(C.PKOCS2003, 10, '0')))																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("k", k);
		query.setParameter("f_cnt", cnt);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_serial_text", serialText);
		
		List<DRG3041P05SerialInfo> listInfo = new JpaResultMapper().list(query, DRG3041P05SerialInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10GrdDrgBunhoInfo> getDRG3010P10GrdDrgBunhoInfo(String hospCode, String language, String magamDate, String magamSer,
			String magamGubun, String hoDong, String magamBunryu) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																												");
		sql.append("		DISTINCT CAST(A.ORDER_DATE AS CHAR)   											ORDER_DATE,						");
		sql.append("	    CAST(A.JUBSU_DATE AS CHAR)                                                      JUBSU_DATE,						");
		sql.append("	    CAST(A.DRG_BUNHO AS CHAR)                                                       DRG_BUNHO,						");
		sql.append("	    A.BUNHO                                                                         BUNHO,							");
		sql.append("	    D.HO_DONG1,																										");
		sql.append("	    FN_BAS_LOAD_GWA_NAME(D.HO_DONG1, A.JUBSU_DATE, :f_hosp_code, :f_language)      	HO_DONG_NAME,					");
		sql.append("	    D.HO_CODE1                                          							HO_CODE,  						");
		sql.append("	    B.SUNAME                                                                        SUNAME,							");
		sql.append("	    CAST(A.FKINP1001 AS CHAR)                                                       FKINP1001,						");
		sql.append("	    CAST(IFNULL(A.HOPE_DATE, A.ORDER_DATE) AS CHAR)                        			HOPE_DATE,						");
		sql.append("	    NULL                                                                            CHULGO_DATE,					");
		sql.append("	    '1'                                                                             MAGAM_BUNRYU					");
		sql.append("	FROM																												");
		sql.append("		DRG3010 A 	JOIN 	OUT0101 B																					");
		sql.append("	    			ON 		A.HOSP_CODE 			= B.HOSP_CODE														");
		sql.append("	   				AND 	A.BUNHO 				= B.BUNHO															");
		sql.append("	      			JOIN 	INP1001 D																					");
		sql.append("	                ON 		A.HOSP_CODE 			= D.HOSP_CODE														");
		sql.append("	   				AND 	A.FKINP1001            	= D.PKINP1001														");
		sql.append("	                JOIN 	DRG3020 Z																					");
		sql.append("	                ON 		A.HOSP_CODE            	= Z.HOSP_CODE														");
		sql.append("	                AND 	A.JUBSU_DATE           	= Z.MAGAM_DATE														");
		sql.append("	                AND 	A.MAGAM_GUBUN          	= Z.MAGAM_GUBUN														");
		sql.append("	                AND 	IFNULL(A.MAGAM_SER,0)   = Z.MAGAM_SER														");
		sql.append("	WHERE																												");
		sql.append("		Z.HOSP_CODE            		= :f_hosp_code																		");
		sql.append("	  	AND Z.MAGAM_DATE            = :f_magam_date																		");
		sql.append("	  	AND Z.MAGAM_SER             = :f_magam_ser																		");
		sql.append("	  	AND Z.MAGAM_GUBUN           = :f_magam_gubun																	");
		sql.append("	   	AND A.BUNRYU1               IN ('1','6')																		");
		sql.append("	   	AND D.HO_DONG1              LIKE IFNULL(:f_ho_dong,'%')															");
		sql.append("	   	AND :f_magam_bunryu         = '1'																				");
		sql.append("	UNION																												");
		sql.append("	SELECT																												");
		sql.append("		DISTINCT A.ORDER_DATE   											ORDER_DATE,									");
		sql.append("	    A.JUBSU_DATE                                                        JUBSU_DATE,									");
		sql.append("	    A.DRG_BUNHO                                                         DRG_BUNHO,									");
		sql.append("	    A.BUNHO                                                             BUNHO,										");
		sql.append("	    D.HO_DONG1,																										");
		sql.append("	    FN_BAS_LOAD_GWA_NAME(D.HO_DONG1, A.JUBSU_DATE, :f_hosp_code, :f_language)        				HO_DONG_NAME,	");
		sql.append("	    D.HO_CODE1                                          				HO_CODE,  									");
		sql.append("	    B.SUNAME                                                            SUNAME,										");
		sql.append("	    A.FKINP1001                                                         FKINP1001,									");
		sql.append("	    IFNULL(A.HOPE_DATE, A.ORDER_DATE)                        			HOPE_DATE,									");
		sql.append("	    FN_DRG_GET_MIX_DATE(A.HOSP_CODE , A.JUBSU_DATE, A.DRG_BUNHO)  		MIX_DATE,									");
		sql.append("	    '2'                     MAGAM_BUNRYU																			");
		sql.append("	FROM																												");
		sql.append("	    DRG3010 A 	JOIN 	OUT0101 B																					");
		sql.append("	    			ON 		A.HOSP_CODE 			= B.HOSP_CODE														");
		sql.append("	   				AND 	A.BUNHO 				= B.BUNHO															");
		sql.append("	         		JOIN 	INP1001 D																					");
		sql.append("	         		ON 		A.HOSP_CODE 			= D.HOSP_CODE														");
		sql.append("	   				AND 	A.FKINP1001            	= D.PKINP1001														");
		sql.append("	         		JOIN 	DRG3020 Z																					");
		sql.append("	         		ON 		A.HOSP_CODE            	= Z.HOSP_CODE														");
		sql.append("	                AND 	A.JUBSU_DATE           	= Z.MAGAM_DATE														");
		sql.append("	                AND 	A.MAGAM_GUBUN          	= Z.MAGAM_GUBUN														");
		sql.append("	                AND 	IFNULL(A.MAGAM_SER,0)   = Z.MAGAM_SER														");
		sql.append("	WHERE																												");
		sql.append("		Z.HOSP_CODE          	= :f_hosp_code																			");
		sql.append("	    AND Z.MAGAM_DATE        = :f_magam_date																			");
		sql.append("	    AND Z.MAGAM_SER         = :f_magam_ser																			");
		sql.append("	    AND Z.MAGAM_GUBUN       = :f_magam_gubun																		");
		sql.append("	    AND A.BUNRYU1           = '4'																					");
		sql.append("	    AND D.HO_DONG1          LIKE IFNULL(:f_ho_dong,'%')																");
		sql.append("	    AND :f_magam_bunryu     = '2'																					");
		sql.append("	ORDER BY 3																											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_magam_date", magamDate);
		query.setParameter("f_magam_ser", magamSer);
		query.setParameter("f_magam_gubun", magamGubun);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_magam_bunryu", magamBunryu);
		
		List<DRG3010P10GrdDrgBunhoInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdDrgBunhoInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10GrdJusaDcOrderInfo> getDRG3010P10GrdJusaDcOrderInfo(String hospCode, String language,
			String jubsuDate, String drgBunho, String bunho, String magamBunryu) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																	");
		sql.append("	  	CAST(A.ORDER_DATE AS CHAR)                                                                              ORDER_DATE,					");
		sql.append("	    IFNULL(A.MIX_GROUP, '')                                                                                 MIX_GROUP,					");
		sql.append("	    A.JAERYO_CODE                                                                                           JAERYO_CODE,				");
		sql.append("	    B.JAERYO_NAME                                                                                           JAERYO_NAME,				");
		sql.append("	    CAST(A.ORD_SURYANG AS CHAR)                                                                             ORD_SURYANG,				");
		sql.append("	    A.DV_TIME                                                                                               DV_TIME,					");
		sql.append("	    CAST(A.DV AS CHAR)                                                                                      DV,							");
		sql.append("	    CAST(A.NALSU AS CHAR)                                                                                   NALSU,						");
		sql.append("	    A.ORDER_DANUI                                                                                           ORDER_DANUI,				");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) 							DANUI_NAME,					");
		sql.append("	    IFNULL(A.BOGYONG_CODE, '')          																	BOGYONG_CODE,				");
		sql.append("	    IFNULL(CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language)), '')     	BOGYONG_NAME,	");
		sql.append("	    A.POWDER_YN                                                                                             POWDER_YN,					");
		sql.append("	    IFNULL(A.REMARK, '')                                                                                    REMARK,						");
		sql.append("	    IFNULL(A.DV_1, '')                                                                                      DV_1,						");
		sql.append("	    IFNULL(A.DV_2, '')                                                                                      DV_2,						");
		sql.append("	    IFNULL(A.DV_3, '')                                                                                      DV_3,						");
		sql.append("	    IFNULL(A.DV_4, '')                                                                                      DV_4,						");
		sql.append("	    IFNULL(A.DV_5, '')                                                                                      DV_5,						");
		sql.append("	    FN_DRG_JUNINP_YN(:f_hosp_code, A.FKOCS2003, null)      													HUBAL_CHANGE_YN,			");
		sql.append("	    A.PHARMACY                                                                                              PHARMACY,					");
		sql.append("	    A.DRG_PACK_YN                                                                                           DRG_PACK_YN,				");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)     						JUSA_NAME,					");
		sql.append("	    D.SUNAME                                                                                                SUNAME,						");
		sql.append("	    CAST(A.DRG_BUNHO AS CHAR)                                                                               DRG_BUNHO,					");
		sql.append("	    CAST(A.FKOCS2003 AS CHAR)                                                                               FKOCS2003,					");
		sql.append("	    A.APPEND_YN                                                                                             APPEND_YN,					");
		sql.append("	    IFNULL(A.RE_USE_YN, '')                                                                                 RE_USE_YN,					");
		sql.append("	    CAST(A.HOPE_DATE AS CHAR)                                                                               HOPE_DATE,					");
		sql.append("	    A.HOPE_TIME                                                                                             HOPE_TIME,					");
		sql.append("	    SUBSTRING(A.GROUP_SER,2,2) 																				GROUP_SER,					");
		sql.append("	    A.DC_YN                                                                                                 DC_YN,						");
		sql.append("	    F.ORDER_GUBUN                                                                                           ORDER_GUBUN,				");
		sql.append("	    G.IF_INPUT_CONTROL                                                                                      IF_INPUT_CONTROL,			");
		sql.append("	    A.BANNAB_YN                                                                                             BANNAB_YN,					");
		sql.append("	    CASE G.IF_INPUT_CONTROL																												");
		sql.append("	        WHEN 'P' THEN '1'																												");
		sql.append("	        WHEN 'B' THEN '2'																												");
		sql.append("	        WHEN 'C' THEN '3'																												");
		sql.append("	        ELSE G.IF_INPUT_CONTROL																											");
		sql.append("	    END																																	");
		sql.append("	FROM																																	");
		sql.append("	  	DRG3010 A 	JOIN 		INP1001 E																									");
		sql.append("	                ON 			A.HOSP_CODE 		= E.HOSP_CODE																			");
		sql.append("	                AND 		A.FKINP1001 		= E.PKINP1001																			");
		sql.append("	                JOIN 		OUT0101 D																									");
		sql.append("	                ON 			A.HOSP_CODE 		= D.HOSP_CODE																			");
		sql.append("	                AND 		A.BUNHO 			= D.BUNHO																				");
		sql.append("	                JOIN 		OCS2003 F																									");
		sql.append("	                ON 			A.HOSP_CODE 		= F.HOSP_CODE																			");
		sql.append("	                AND 		A.FKOCS2003 		= F.PKOCS2003																			");
		sql.append("	                JOIN 		OCS0103 G																									");
		sql.append("	                ON 			F.HOSP_CODE 		= G.HOSP_CODE																			");
		sql.append("	                AND 		F.HANGMOG_CODE      = G.HANGMOG_CODE																		");
		sql.append("	                LEFT JOIN 	INV0110 B																									");
		sql.append("	                ON 			A.HOSP_CODE 		= B.HOSP_CODE																			");
		sql.append("	                AND 		A.JAERYO_CODE 		= B.JAERYO_CODE																			");
		sql.append("	                LEFT JOIN  	DRG0120 C																									");
		sql.append("	                ON 			A.HOSP_CODE 		= C.HOSP_CODE																			");
		sql.append("	                AND 		A.BOGYONG_CODE 		= C.BOGYONG_CODE																		");
		sql.append("	WHERE																																	");
		sql.append("	  A.HOSP_CODE            	= :f_hosp_code																								");
		sql.append("	   AND A.JUBSU_DATE         = :f_jubsu_date																								");
		sql.append("	   AND A.DRG_BUNHO          = :f_drg_bunho																								");
		sql.append("	   AND A.BUNHO              = :f_bunho																									");
		sql.append("	   AND :f_magam_bunryu      = '2'																										");
		sql.append("	UNION ALL																																");
		sql.append("	SELECT																																	");
		sql.append("	    A.ORDER_DATE                                                                                                ORDER_DATE,				");
		sql.append("	    A.MIX_GROUP                                                                                                 MIX_GROUP,				");
		sql.append("	    A.JAERYO_CODE                                                                                               JAERYO_CODE,			");
		sql.append("	    B.JAERYO_NAME                                                                                               JAERYO_NAME,			");
		sql.append("	    A.ORD_SURYANG                                                                                               ORD_SURYANG,			");
		sql.append("	    A.DV_TIME                                                                                                   DV_TIME,				");
		sql.append("	    A.DV                                                                                                        DV,						");
		sql.append("	    A.NALSU                                                                                                     NALSU,					");
		sql.append("	    A.ORDER_DANUI                                                                                               ORDER_DANUI,			");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) 								DANUI_NAME,				");
		sql.append("	    A.BOGYONG_CODE          																					BOGYONG_CODE,			");
		sql.append("	    CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))     		BOGYONG_NAME,			");
		sql.append("	    A.POWDER_YN                                                                                                 POWDER_YN,				");
		sql.append("	    A.REMARK                                                                                                    REMARK,					");
		sql.append("	    A.DV_1                                                                                                      DV_1,					");
		sql.append("	    A.DV_2                                                                                                      DV_2,					");
		sql.append("	    A.DV_3                                                                                                      DV_3,					");
		sql.append("	    A.DV_4                                                                                                      DV_4,					");
		sql.append("	    A.DV_5                                                                                                      DV_5,					");
		sql.append("	    FN_DRG_JUNINP_YN(:f_hosp_code, A.FKOCS2003, null)      														HUBAL_CHANGE_YN,		");
		sql.append("	    A.PHARMACY                                                                                                	PHARMACY,				");
		sql.append("	    A.DRG_PACK_YN                                                                                             	DRG_PACK_YN,			");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)     							JUSA_NAME,				");
		sql.append("	    D.SUNAME                                          															SUNAME,					");
		sql.append("	    A.DRG_BUNHO                                                                                                 DRG_BUNHO,				");
		sql.append("	    A.FKOCS2003                                                                                                 FKOCS2003,				");
		sql.append("	    A.APPEND_YN                                                                                                 APPEND_YN,				");
		sql.append("	    A.RE_USE_YN                                                                                                 RE_USE_YN,				");
		sql.append("	    A.HOPE_DATE                                                                                                 HOPE_DATE,				");
		sql.append("	    A.HOPE_TIME                                                                                                 HOPE_TIME,				");
		sql.append("	    SUBSTR(A.GROUP_SER,2,2)                                                                                     GROUP_SER,				");
		sql.append("	    A.DC_YN                                                                                                     DC_YN,					");
		sql.append("	    F.ORDER_GUBUN                                                                                               ORDER_GUBUN,			");
		sql.append("	    G.IF_INPUT_CONTROL                                                                                          IF_INPUT_CONTROL,		");
		sql.append("	    A.BANNAB_YN                                                                                                 BANNAB_YN,				");
		sql.append("	    CASE G.IF_INPUT_CONTROL																												");
		sql.append("	        WHEN 'P' THEN '1'																												");
		sql.append("	        WHEN 'B' THEN '2'																												");
		sql.append("	        WHEN 'C' THEN '3'																												");
		sql.append("	        ELSE G.IF_INPUT_CONTROL																											");
		sql.append("	    END																																	");
		sql.append("	FROM																																	");
		sql.append("		(SELECT *																															");
		sql.append("	     FROM DRG3010 Y																														");
		sql.append("	     WHERE Y.HOSP_CODE = :f_hosp_code																									");
		sql.append("	           AND Y.SOURCE_FKOCS2003 IN (SELECT X.FKOCS2003																				");
		sql.append("	                                      FROM DRG3010 X																					");
		sql.append("	                                      WHERE X.HOSP_CODE  	= :f_hosp_code																");
		sql.append("	                                          AND X.JUBSU_DATE 	= :f_jubsu_date																");
		sql.append("	                                          AND X.DRG_BUNHO  	= :f_drg_bunho																");
		sql.append("	                                          AND X.BUNHO      	= :f_bunho)																	");
		sql.append("	       ) A																																");
		sql.append("	     JOIN 		INP1001 E																												");
		sql.append("	     ON 		A.HOSP_CODE = E.HOSP_CODE																								");
		sql.append("	     AND 		A.FKINP1001 = E.PKINP1001																								");
		sql.append("	     JOIN 		OUT0101 D																												");
		sql.append("	     ON 		A.HOSP_CODE = D.HOSP_CODE																								");
		sql.append("	     AND 		A.BUNHO = D.BUNHO																										");
		sql.append("	     JOIN 		OCS2003 F																												");
		sql.append("	     ON 		A.HOSP_CODE = F.HOSP_CODE																								");
		sql.append("	     AND 		A.FKOCS2003 = F.PKOCS2003																								");
		sql.append("	     JOIN 		OCS0103 G																												");
		sql.append("	     ON 		F.HOSP_CODE = G.HOSP_CODE																								");
		sql.append("	     AND 		F.HANGMOG_CODE         = G.HANGMOG_CODE																					");
		sql.append("	     LEFT JOIN 	INV0110 B																												");
		sql.append("	     ON 		A.HOSP_CODE = B.HOSP_CODE																								");
		sql.append("	     AND 		A.JAERYO_CODE = B.JAERYO_CODE																							");
		sql.append("	     LEFT JOIN 	DRG0120 C																												");
		sql.append("	     ON 		A.HOSP_CODE = C.HOSP_CODE																								");
		sql.append("	     AND 		A.BOGYONG_CODE = C.BOGYONG_CODE																							");
		sql.append("	 WHERE 																																	");
		sql.append("	     :f_magam_bunryu        = '2'																										");
		sql.append("	     AND A.ORDER_DATE BETWEEN G.START_DATE AND IFNULL(G.END_DATE, '9998/12/31')															");
		sql.append("	ORDER BY																																");
		sql.append("	  	1, 32 DESC ,2, 25																													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_magam_bunryu", magamBunryu);
		
		List<DRG3010P10GrdJusaDcOrderInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdJusaDcOrderInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10GrdMagamJusaOrdInfo> getDRG3010P10GrdMagamJusaOrdInfo(String hospCode, String language, String jubsuDate, String drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																											");
		sql.append("	    CAST(A.ORDER_DATE AS CHAR)                                                             	ORDER_DATE,																			");
		sql.append("	    IFNULL(A.MIX_GROUP, '')                                                                	MIX_GROUP,																			");
		sql.append("	    A.JAERYO_CODE                                                                           JAERYO_CODE,																		");
		sql.append("	    B.JAERYO_NAME                                     										JAERYO_NAME,																		");
		sql.append("	    CASE WHEN A.NALSU < 0 THEN CONCAT('-', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("	                           ELSE CONCAT('', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("	                           END           													ORD_SURYANG,																		");
		sql.append("	    A.DV_TIME                                                                               DV_TIME,																			");
		sql.append("	    CAST(A.DV AS CHAR)                                                                      DV,																					");
		sql.append("	    CAST(A.NALSU AS CHAR)                                                                   NALSU,																				");
		sql.append("	    A.ORDER_DANUI                                                                           ORDER_DANUI,																		");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) 			DANUI_NAME,																			");
		sql.append("	    A.BOGYONG_CODE                                                                          BOGYONG_CODE,																		");
		sql.append("	    IFNULL(C.BOGYONG_NAME, '')                                                              BOGYONG_NAME,																		");
		sql.append("	    A.POWDER_YN                                                                             POWDER_YN,																			");
		sql.append("	    IFNULL(CONCAT(A.REMARK, ' ', FN_DRG_LOAD_DRG0120_PATTERN('I', A.FKOCS2003, :f_hosp_code)), '')    	REMARK,														            ");
		sql.append("	    IFNULL(A.DV_1, '')                                                                      DV_1,																	            ");
		sql.append("	    IFNULL(A.DV_2, '')                                                                      DV_2,																	            ");
		sql.append("	    IFNULL(A.DV_3, '')                                                                      DV_3,																	            ");
		sql.append("	    IFNULL(A.DV_4, '')                                                                      DV_4,																	            ");
		sql.append("	    IFNULL(A.DV_5, '')                                                                      DV_5,																	            ");
		sql.append("	    A.HUBAL_CHANGE_YN                                                                       HUBAL_CHANGE_YN,																	");
		sql.append("	    A.PHARMACY                                                                              PHARMACY,																			");
		sql.append("	    A.DRG_PACK_YN                                                                           DRG_PACK_YN,																		");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)     		JUSA_NAME,																			");
		sql.append("	    D.SUNAME                                                                                SUNAME,																				");
		sql.append("	    CAST(A.DRG_BUNHO AS CHAR)                                                               DRG_BUNHO,																			");
		sql.append("	    CAST(A.JUBSU_DATE AS CHAR)                                                              JUBSU_DATE,																			");
		sql.append("	    A.BUNHO                                                                                 BUNHO,																				");
		sql.append("	    A.HO_DONG                                                                               HO_DONG  ,																			");
		sql.append("	    CAST(A.HOPE_DATE AS CHAR)                                                               HOPE_DATE,																			");
		sql.append("	    SUBSTR(A.GROUP_SER,2,2)                                                                 GROUP_SER,																			");
		sql.append("	    A.DC_YN                                                                                 DC_YN,																				");
		sql.append("	    F.ORDER_GUBUN                                                                           ORDER_GUBUN,																		");
		sql.append("	    CONCAT(LTRIM(LPAD(A.DRG_BUNHO, 4, '0')), DATE_FORMAT(A.ORDER_DATE,'%Y%m%d'))  			QUERY_SEQ,																			");
		sql.append("	    A.BANNAB_YN             																BANNAB_YN,																			");
		sql.append("	    CAST(IFNULL(A.SOURCE_FKOCS2003, A.FKOCS2003) AS CHAR)      								SOURCE_FKOCS2003,																	");
		sql.append("	    CAST(A.FKOCS2003 AS CHAR)             													FKOCS2003																			");
		sql.append("	FROM																																											");
		sql.append("	    DRG3010 A 	JOIN 		OUT0101 D																																			");
		sql.append("	                ON 			A.HOSP_CODE 	= D.HOSP_CODE																														");
		sql.append("	                AND 		A.BUNHO 		= D.BUNHO																															");
		sql.append("	                JOIN 		OCS2003 F																																			");
		sql.append("	                ON 			A.HOSP_CODE 	= F.HOSP_CODE																														");
		sql.append("	                AND 		A.FKOCS2003 	= F.PKOCS2003																														");
		sql.append("	      			LEFT JOIN 	INV0110 B																																			");
		sql.append("	         		ON 			A.HOSP_CODE 	= B.HOSP_CODE																														");
		sql.append("	         		AND 		A.JAERYO_CODE 	= B.JAERYO_CODE																														");
		sql.append("	      			LEFT JOIN 	DRG0120 C																																			");
		sql.append("	      			ON 			A.HOSP_CODE 	= C.HOSP_CODE																														");
		sql.append("	         		AND 		A.BOGYONG_CODE 	= C.BOGYONG_CODE																													");
		sql.append("	 WHERE																																											");
		sql.append("	     A.HOSP_CODE            	= :f_hosp_code																																	");
		sql.append("	     AND A.JUBSU_DATE         	= :f_jubsu_date																																	");
		sql.append("	     AND A.DRG_BUNHO          	= :f_drg_bunho																																	");
		sql.append("	     AND A.BUNRYU1            	IN ('1','6')																																	");
		sql.append("	UNION ALL																																										");
		sql.append("	SELECT																																											");
		sql.append("	   A.ORDER_DATE                                                                                             ORDER_DATE,															");
		sql.append("	   A.MIX_GROUP                                                                                              MIX_GROUP,															");
		sql.append("	   A.JAERYO_CODE                                                                                            JAERYO_CODE,														");
		sql.append("	   B.JAERYO_NAME                                                                                            JAERYO_NAME,														");
		sql.append("	   CASE WHEN A.NALSU < 0 THEN CONCAT('-', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("	                           ELSE CONCAT('', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("	                           END           																	ORD_SURYANG,														");
		sql.append("	   A.DV_TIME                                                                                                DV_TIME,															");
		sql.append("	   A.DV                                                                                                     DV,																	");
		sql.append("	   A.NALSU                                                                                                  NALSU,																");
		sql.append("	   A.ORDER_DANUI                                                                                            ORDER_DANUI,														");
		sql.append("	   FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) 							DANUI_NAME,															");
		sql.append("	   A.BOGYONG_CODE          																					BOGYONG_CODE,														");
		sql.append("	   CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))     	BOGYONG_NAME,							");
		sql.append("	   A.POWDER_YN             																					POWDER_YN,															");
		sql.append("	   CONCAT(A.REMARK, ' ', FN_DRG_LOAD_DRG0120_PATTERN('I', A.FKOCS2003, :f_hosp_code))						REMARK,																");
		sql.append("	   A.DV_1                                                                                                   DV_1,																");
		sql.append("	   A.DV_2                                                                                                   DV_2,																");
		sql.append("	   A.DV_3                                                                                                   DV_3,																");
		sql.append("	   A.DV_4                                                                                                   DV_4,																");
		sql.append("	   A.DV_5                                                                                                   DV_5,																");
		sql.append("	   A.HUBAL_CHANGE_YN                                                                                        HUBAL_CHANGE_YN,													");
		sql.append("	   A.PHARMACY                                                                                               PHARMACY,															");
		sql.append("	   A.DRG_PACK_YN                                                                                            DRG_PACK_YN,														");
		sql.append("	   FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)     							JUSA_NAME,															");
		sql.append("	   D.SUNAME                                                                                                 SUNAME,																");
		sql.append("	   A.DRG_BUNHO                                                                                              DRG_BUNHO,															");
		sql.append("	   A.JUBSU_DATE                                                                                             JUBSU_DATE,															");
		sql.append("	   A.BUNHO                                                                                                  BUNHO,																");
		sql.append("	   A.HO_DONG                                                                                                HO_DONG  ,															");
		sql.append("	   A.HOPE_DATE                                                                                              HOPE_DATE,															");
		sql.append("	   SUBSTR(A.GROUP_SER,2,2)                                                                                  GROUP_SER,															");
		sql.append("	   A.DC_YN                                                                                                  DC_YN,																");
		sql.append("	   F.ORDER_GUBUN                                                                                            ORDER_GUBUN,														");
		sql.append("	   CONCAT(LTRIM(LPAD(A.DRG_BUNHO, 4, '0')), DATE_FORMAT(A.ORDER_DATE, '%Y%m%d'))   							QUERY_SEQ,															");
		sql.append("	   A.BANNAB_YN             																					BANNAB_YN,															");
		sql.append("	   IFNULL(A.SOURCE_FKOCS2003, A.FKOCS2003)       															SOURCE_FKOCS2003,													");
		sql.append("	   A.FKOCS2003             																					FKOCS2003															");
		sql.append("	FROM																																											");
		sql.append("		DRG3010 A 	JOIN 		OUT0101 D																																			");
		sql.append("	                ON 			D.HOSP_CODE      	= A.HOSP_CODE 																													");
		sql.append("	                AND 		D.BUNHO             = A.BUNHO																														");
		sql.append("	                JOIN 		OCS2003 F																																			");
		sql.append("	                ON 			F.HOSP_CODE         = A.HOSP_CODE 																													");
		sql.append("	                AND 		F.PKOCS2003         = A.FKOCS2003																													");
		sql.append("	                LEFT JOIN 	INV0110 B																																			");
		sql.append("	                ON 			A.HOSP_CODE 		= B.HOSP_CODE																													");
		sql.append("	                AND 		A.JAERYO_CODE 		= B.JAERYO_CODE																													");
		sql.append("	                LEFT JOIN 	DRG0120 C																																			");
		sql.append("	                ON 			A.HOSP_CODE 		= C.HOSP_CODE																													");
		sql.append("	                AND 		A.BOGYONG_CODE 		= C.BOGYONG_CODE																												");
		sql.append("	      																																											");
		sql.append("	WHERE																																											");
		sql.append("	   A.HOSP_CODE            	= :f_hosp_code																																		");
		sql.append("	   AND A.JUBSU_DATE         = :f_jubsu_date																																		");
		sql.append("	   AND A.DRG_BUNHO          = :f_drg_bunho																																		");
		sql.append("	   AND A.BUNRYU1            = ('4')																																				");
		sql.append("	 ORDER BY																																										");
		sql.append("	   ORDER_DATE, DC_YN DESC, GROUP_SER, MIX_GROUP, DRG_BUNHO, SOURCE_FKOCS2003, FKOCS2003, QUERY_SEQ																				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
        
		List<DRG3010P10GrdMagamJusaOrdInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdMagamJusaOrdInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10GrdMagamOrdInfo> getDRG3010P10GrdMagamOrdInfo(String hospCode, String language, String jubsuDate, String drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																											");
		sql.append("		CAST(A.ORDER_DATE AS CHAR)                                                          ORDER_DATE,																				");
		sql.append("	    SUBSTRING(F.GROUP_SER,2,2)                                                          GROUP_SER,																				");
		sql.append("	    A.JAERYO_CODE                                                                       JAERYO_CODE,																			");
		sql.append("	    B.JAERYO_NAME                                                                       JAERYO_NAME,																			");
		sql.append("	    CASE WHEN A.NALSU < 0 THEN CONCAT('-', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("	                           ELSE CONCAT('', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("	                           END        	ORD_SURYANG,																															");
		sql.append("	    A.DV_TIME                                                                           DV_TIME,																				");
		sql.append("	    CAST(A.DV AS CHAR)                                                                  DV,																						");
		sql.append("	    CAST(A.NALSU AS CHAR)                                                               NALSU,																					");
		sql.append("	    A.ORDER_DANUI                                                                       ORDER_DANUI,																			");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) 		DANUI_NAME,																				");
		sql.append("	    A.BOGYONG_CODE                                                                      BOGYONG_CODE,																			");
		sql.append("	    IFNULL(C.BOGYONG_NAME, '')                                                          BOGYONG_NAME,																			");
		sql.append("	    A.POWDER_YN                                                                         POWDER_YN,																				");
		sql.append("	    IFNULL(CONCAT(A.REMARK, ' ', FN_DRG_LOAD_DRG0120_PATTERN('I', A.FKOCS2003, A.HOSP_CODE)), '')    REMARK,																	");
		sql.append("	    IFNULL(A.DV_1, '')                                                                  DV_1,																					");
		sql.append("	    IFNULL(A.DV_2, '')                                                                  DV_2,																					");
		sql.append("	    IFNULL(A.DV_3, '')                                                                  DV_3,																					");
		sql.append("	    IFNULL(A.DV_4, '')                                                                  DV_4,																					");
		sql.append("	    IFNULL(A.DV_5, '')                                                                  DV_5,																					");
		sql.append("	    A.HUBAL_CHANGE_YN                                                                   HUBAL_CHANGE_YN,																		");
		sql.append("	    A.PHARMACY                                                                          PHARMACY,																				");
		sql.append("	    A.DRG_PACK_YN                                                                       DRG_PACK_YN,																			");
		sql.append("	    IFNULL(A.JUSA, '')                                                                  JUSA,																					");
		sql.append("	    D.SUNAME                                                                            SUNAME,																					");
		sql.append("	    CAST(A.DRG_BUNHO AS CHAR)                                                           DRG_BUNHO,																				");
		sql.append("	    CAST(A.JUBSU_DATE AS CHAR)                                                          JUBSU_DATE,																				");
		sql.append("	    A.BUNHO                                                                             BUNHO,																					");
		sql.append("	    A.HO_DONG                                                                           HO_DONG,         																		");
		sql.append("	    A.BANNAB_YN                                                                         BANNAB_YN,																				");
		sql.append("	    CAST(IFNULL(A.SOURCE_FKOCS2003,A.FKOCS2003) AS CHAR) 								SOURCE_FKOCS2003,																		");
		sql.append("	    CAST(A.FKOCS2003 AS CHAR)                                                           FKOCS2003,																				");
		sql.append("	    CAST(A.HOPE_DATE AS CHAR)                                                           HOPE_DATE,																				");
		sql.append("	    A.DC_YN                                                                             DC_YN,																					");
		sql.append("	    F.ORDER_GUBUN                                                                       ORDER_GUBUN,																			");
		sql.append("	    IFNULL(F.MIX_GROUP, '')                                                             MIX_GROUP,																				");
		sql.append("	    IFNULL(F.BROUGHT_DRG_YN, '')                                                        BROUGHT_DRG_YN																			");
		sql.append("	FROM																																											");
		sql.append("		DRG3010 A 	JOIN 		OUT0101 D																																			");
		sql.append("					ON 			D.HOSP_CODE            = A.HOSP_CODE 																												");
		sql.append("	   				AND 		D.BUNHO                = A.BUNHO																													");
		sql.append("					JOIN 		OCS2003 F																																			");
		sql.append("	   				ON 			F.HOSP_CODE            = A.HOSP_CODE 																												");
		sql.append("	   				AND 		F.PKOCS2003            = A.FKOCS2003																												");
		sql.append("					LEFT JOIN 	INV0110 B																																			");
		sql.append("	   				ON 			B.HOSP_CODE            = A.HOSP_CODE 																												");
		sql.append("	   				AND 		B.JAERYO_CODE          = A.JAERYO_CODE																												");
		sql.append("					LEFT JOIN 	DRG0120 C																																			");
		sql.append("	   				ON 			C.HOSP_CODE            = A.HOSP_CODE 																												");
		sql.append("	   				AND 		C.BOGYONG_CODE        = A.BOGYONG_CODE																												");
		sql.append("	WHERE																																											");
		sql.append("		A.HOSP_CODE				= :f_hosp_code																																		");
		sql.append("	   	AND A.JUBSU_DATE        = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																											");
		sql.append("	   	AND A.DRG_BUNHO         = :f_drg_bunho																																		");
		sql.append("	   	AND A.BUNRYU1           IN ('1','6')																																		");
		sql.append("	UNION ALL																																										");
		sql.append("	SELECT																																											");
		sql.append("		A.ORDER_DATE                                                                                                                        ORDER_DATE,								");
		sql.append("	    SUBSTRING(F.GROUP_SER,2,2)                                                                                                          GROUP_SER,								");
		sql.append("	    A.JAERYO_CODE                                                                                                                       JAERYO_CODE,							");
		sql.append("	    B.JAERYO_NAME                                                                                                                       JAERYO_NAME,							");
		sql.append("	    CASE WHEN A.NALSU < 0 THEN CONCAT('-', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("	                           ELSE CONCAT('', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("	                           END           																								ORD_SURYANG,							");
		sql.append("	    A.DV_TIME                                                                                                                           DV_TIME,								");
		sql.append("	    A.DV                                                                                                                                DV,										");
		sql.append("	    A.NALSU                                                                                                                             NALSU,									");
		sql.append("	    A.ORDER_DANUI                                                                                                                       ORDER_DANUI,							");
		sql.append("	    FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) 														DANUI_NAME,								");
		sql.append("	    A.BOGYONG_CODE          																											BOGYONG_CODE,							");
		sql.append("	    CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))     	BOGYONG_NAME,							");
		sql.append("	    A.POWDER_YN             																											POWDER_YN,								");
		sql.append("	    CONCAT(A.REMARK, ' ', FN_DRG_LOAD_DRG0120_PATTERN('I', A.FKOCS2003, A.HOSP_CODE))    												REMARK,									");
		sql.append("	    A.DV_1                                                                                                                              DV_1,									");
		sql.append("	    A.DV_2                                                                                                                              DV_2,									");
		sql.append("	    A.DV_3                                                                                                                              DV_3,									");
		sql.append("	    A.DV_4                                                                                                                              DV_4,									");
		sql.append("	    A.DV_5                                                                                                                              DV_5,									");
		sql.append("	    A.HUBAL_CHANGE_YN                                                                                                                   HUBAL_CHANGE_YN,						");
		sql.append("	    A.PHARMACY                                                                                                                          PHARMACY,								");
		sql.append("	    A.DRG_PACK_YN                                                                                                                       DRG_PACK_YN,							");
		sql.append("	    A.JUSA                                                                                                                              JUSA,									");
		sql.append("	    D.SUNAME                                                                                                                            SUNAME,									");
		sql.append("	    A.DRG_BUNHO                                                                                                                         DRG_BUNHO,								");
		sql.append("	    A.JUBSU_DATE                                                                                                                        JUBSU_DATE,								");
		sql.append("	    A.BUNHO                                                                                                                             BUNHO,									");
		sql.append("	    A.HO_DONG                                                                                                                           HO_DONG,								");
		sql.append("	    A.BANNAB_YN                                                                                                                         BANNAB_YN,								");
		sql.append("	    IFNULL(A.SOURCE_FKOCS2003,A.FKOCS2003) 																								SOURCE_FKOCS2003,						");
		sql.append("	    A.FKOCS2003                                                                                                                         FKOCS2003,								");
		sql.append("	    A.HOPE_DATE                                                                                                                         HOPE_DATE,								");
		sql.append("	    A.DC_YN                                                                                                                             DC_YN,									");
		sql.append("	    F.ORDER_GUBUN                                                                                                                       ORDER_GUBUN,							");
		sql.append("	    F.MIX_GROUP                                                                                                                         MIX_GROUP,								");
		sql.append("	    F.BROUGHT_DRG_YN                                                                                                                    BROUGHT_DRG_YN							");
		sql.append("	FROM																																											");
		sql.append("	  	DRG3010 A 	JOIN 		OUT0101 D																																			");
		sql.append("	    			ON 			D.HOSP_CODE            = A.HOSP_CODE 																												");
		sql.append("	    			AND 		D.BUNHO                = A.BUNHO																													");
		sql.append("	    			AND 		D.HOSP_CODE            = A.HOSP_CODE 																												");
		sql.append("				 	JOIN 		OCS2003 F																																			");
		sql.append("	   				ON 			F.PKOCS2003            = A.FKOCS2003																												");
		sql.append("				 	LEFT JOIN 	INV0110 B																																			");
		sql.append("	   				ON 			B.HOSP_CODE            = A.HOSP_CODE 																												");
		sql.append("	   				AND 		B.JAERYO_CODE          = A.JAERYO_CODE																												");
		sql.append("				 	LEFT JOIN 	DRG0120 C																																			");
		sql.append("	   				ON 			C.HOSP_CODE            = A.HOSP_CODE 																												");
		sql.append("	   				AND 		C.BOGYONG_CODE         = A.BOGYONG_CODE																												");
		sql.append("	WHERE																																											");
		sql.append("	    A.HOSP_CODE            		= :f_hosp_code																																	");
		sql.append("	   	AND A.JUBSU_DATE           	= STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																										");
		sql.append("	   	AND A.DRG_BUNHO            	= :f_drg_bunho																																	");
		sql.append("	   	AND A.BUNRYU1              	= ('4')																																			");
		sql.append("	ORDER BY																																										");
		sql.append("		ORDER_DATE, DC_YN DESC, GROUP_SER, DRG_BUNHO, SOURCE_FKOCS2003, FKOCS2003																									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
        
		List<DRG3010P10GrdMagamOrdInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdMagamOrdInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10GrdMagamPaQueryInfo> getDRG3010P10GrdMagamPaQueryInfo(String hospCode,
			String fromDate, String toDate, String hoDong, String bunho, String magamGubun, String pageNumber, String offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT  A.MAGAM_DATE,																								 ");
		sql.append("      	    A.MAGAM_SER,																								 ");
		sql.append("      	    A.MAGAM_TIME,																								 ");
		sql.append("      	    A.MAGAM_GUBUN,																								 ");
		sql.append("      	    IFNULL(A.MAGAM_CANCEL, '')                                     MAGAM_CANCEL,								 ");
		sql.append("      	    A.ACT_FLAG,																									 ");
		sql.append("      	    CASE A.MAGAM_CANCEL WHEN 'Y' THEN '' ELSE MIN(B.DRG_BUNHO) END MIN_DRG_BUNHO,								 ");
		sql.append("      	    CASE A.MAGAM_CANCEL WHEN 'Y' THEN '' ELSE MAX(B.DRG_BUNHO) END MAX_DRG_BUNHO,								 ");
		sql.append("      	    '1'                                                            MAGAM_BUNRYU									 ");
		sql.append("    FROM DRG3020 A 	                                                                                                     ");
		sql.append("    LEFT JOIN 	DRG3010 B ON  B.HOSP_CODE     = A.HOSP_CODE														         ");
		sql.append("      	                 AND  B.JUBSU_DATE    = A.MAGAM_DATE														     ");
		sql.append("      	                 AND  B.MAGAM_GUBUN   = A.MAGAM_GUBUN														     ");
		sql.append("      	                 AND  B.MAGAM_SER     = A.MAGAM_SER														         ");
		sql.append("      	                 AND  B.BUNRYU1       != '4'																     ");
		sql.append("    JOIN INP1001 C ON C.HOSP_CODE = B.HOSP_CODE                                                                          ");
		sql.append("                  AND C.PKINP1001 = B.FKINP1001														                     ");
		sql.append("  	WHERE A.HOSP_CODE     = :f_hosp_code														                         ");
		sql.append("      AND A.MAGAM_DATE    BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m/%d') AND STR_TO_DATE(:f_to_date, '%Y/%m/%d')          ");
		sql.append("      AND IF(B.APPEND_YN IS NULL OR B.APPEND_YN = '', 'N', B.APPEND_YN)        	    = 'N'								 ");
		sql.append("      AND IF(B.TOIWON_DRG_YN IS NULL OR B.TOIWON_DRG_YN = '', 'N', B.TOIWON_DRG_YN) = 'N'								 ");
		sql.append("      AND IF(B.DC_YN IS NULL OR B.DC_YN = '', 'N', B.DC_YN)          	              = 'N'								 ");
		sql.append("      AND IF(B.BANNAB_YN IS NULL OR B.BANNAB_YN = '', 'N', B.BANNAB_YN)      	      = 'N'								 ");
		sql.append("      AND C.HO_DONG1         					                                              LIKE :f_ho_dong            ");
		sql.append("      AND B.BUNHO           					                                              LIKE :f_bunho              ");
		sql.append("      AND '1' 								                                                      LIKE :f_magam_gubun	 ");
		sql.append("  	GROUP BY																										     ");
		sql.append("  	    A.MAGAM_DATE,																								     ");
		sql.append("  	    A.MAGAM_SER,																								     ");
		sql.append("  	    A.MAGAM_TIME,																								     ");
		sql.append("  	    A.MAGAM_GUBUN,																								     ");
		sql.append("  	    A.MAGAM_CANCEL,																								     ");
		sql.append("  	    A.ACT_FLAG																									     ");
		sql.append("  	UNION ALL																										     ");
		sql.append("  	SELECT																											     ");
		sql.append("  	    A.MAGAM_DATE,																								     ");
		sql.append("  	    A.MAGAM_SER,																								     ");
		sql.append("  	    A.MAGAM_TIME,																								     ");
		sql.append("  	    A.MAGAM_GUBUN,																								     ");
		sql.append("  	    IFNULL(A.MAGAM_CANCEL, '')                                          MAGAM_CANCEL,								 ");
		sql.append("  	    A.ACT_FLAG,																									     ");
		sql.append("  	    CASE A.MAGAM_CANCEL WHEN 'Y' THEN '' ELSE MIN(B.DRG_BUNHO) END 			MIN_DRG_BUNHO,						     ");
		sql.append("  	    CASE A.MAGAM_CANCEL WHEN 'Y' THEN '' ELSE MAX(B.DRG_BUNHO) END 			MAX_DRG_BUNHO,						     ");
		sql.append("  	    '2'                                            							        MAGAM_BUNRYU					 ");
		sql.append("  	FROM DRG3020 A 	                                                                                                     ");
		sql.append("    LEFT JOIN 	DRG3010 B ON B.HOSP_CODE     = A.HOSP_CODE														         ");
		sql.append("      	                 AND B.JUBSU_DATE    = A.MAGAM_DATE														         ");
		sql.append("      	                 AND B.MAGAM_GUBUN   = A.MAGAM_GUBUN														     ");
		sql.append("      	                 AND B.MAGAM_SER     = A.MAGAM_SER														         ");
		sql.append("      		               AND B.BUNRYU1       = '4'																     ");
		sql.append("  	JOIN INP1001 C ON C.HOSP_CODE = B.HOSP_CODE														                     ");
		sql.append("  		            AND C.PKINP1001 = B.FKINP1001														                 ");
		sql.append("  	WHERE A.HOSP_CODE   = :f_hosp_code														                             ");
		sql.append("      AND A.MAGAM_DATE  BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m/%d') AND STR_TO_DATE(:f_to_date, '%Y/%m/%d')            ");
		sql.append("      AND IF(B.APPEND_YN IS NULL OR B.APPEND_YN = '', 'N', B.APPEND_YN)        	    = 'N'								 ");
		sql.append("      AND IF(B.TOIWON_DRG_YN IS NULL OR B.TOIWON_DRG_YN = '', 'N', B.TOIWON_DRG_YN) = 'N'								 ");
		sql.append("      AND C.HO_DONG1         					LIKE :f_ho_dong                                                          ");
		sql.append("      AND B.BUNHO           					LIKE :f_bunho                                                            ");
		sql.append("      AND '2' 								        LIKE :f_magam_gubun													 ");
		sql.append("  	GROUP BY																										     ");
		sql.append("  	    A.MAGAM_DATE,																								     ");
		sql.append("  	    A.MAGAM_SER,																								     ");
		sql.append("  	    A.MAGAM_TIME,																								     ");
		sql.append("  	    A.MAGAM_GUBUN,																								     ");
		sql.append("  	    A.MAGAM_CANCEL,																								     ");
		sql.append("  	    A.ACT_FLAG																									     ");
		sql.append("  	ORDER BY																										     ");
		sql.append("  		MAGAM_BUNRYU, MAGAM_DATE DESC, MAGAM_TIME DESC																     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_ho_dong", StringUtils.isEmpty(hoDong) ? "%" : hoDong);
		query.setParameter("f_bunho", StringUtils.isEmpty(bunho) ? "%" : bunho);
		query.setParameter("f_magam_gubun", magamGubun);
        
		List<DRG3010P10GrdMagamPaQueryInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdMagamPaQueryInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10GrdMiMaJuOrdInfo> getDRG3010P10GrdMiMaJuOrdInfo(String hospCode, String language, String orderDate, String bunho,
			String hopeDate, String hoDong, String doctor, String magamGubun, String magamBunryu, String pageNumber, String offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																									                                                    ");
		sql.append("	  A.ORDER_DATE            ORDER_DATE,																	                                                    ");
		sql.append("	  IFNULL(A.MIX_GROUP, '')             MIX_GROUP,														                                                    ");
		sql.append("	  A.JAERYO_CODE           JAERYO_CODE,																	                                                    ");
		sql.append("	  B.JAERYO_NAME                                     JAERYO_NAME,										                                                    ");
		sql.append("	  A.ORD_SURYANG           ORD_SURYANG,																	                                                    ");
		sql.append("	  A.DV_TIME               DV_TIME,																		                                                    ");
		sql.append("	  A.DV                    DV,																			                                                    ");
		sql.append("	  A.NALSU                 NALSU,																		                                                    ");
		sql.append("	  A.ORDER_DANUI           ORDER_DANUI,																	                                                    ");
		sql.append("	  FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) DANUI_NAME,				                                                    ");
		sql.append("	  A.BOGYONG_CODE          BOGYONG_CODE,																	                                                    ");
		sql.append("	  IFNULL(C.BOGYONG_NAME, '')                                    BOGYONG_NAME,							                                                    ");
		sql.append("	  A.POWDER_YN             POWDER_YN,																	                                                    ");
		sql.append("	  IFNULL(A.REMARK, '')                REMARK,															                                                    ");
		sql.append("	  IFNULL(A.DV_1, '')                  DV_1,																                                                    ");
		sql.append("	  IFNULL(A.DV_2, '')                  DV_2,																                                                    ");
		sql.append("	  IFNULL(A.DV_3, '')                  DV_3,																                                                    ");
		sql.append("	  IFNULL(A.DV_4, '')                  DV_4,																                                                    ");
		sql.append("	  IFNULL(A.DV_5, '')                  DV_5,																                                                    ");
		sql.append("	  FN_DRG_JUNINP_YN(:f_hosp_code, A.FKOCS2003, NULL)  HUBAL_CHANGE_YN,									                                                    ");
		sql.append("	  A.PHARMACY              PHARMACY,																		                                                    ");
		sql.append("	  A.DRG_PACK_YN           DRG_PACK_YN,																	                                                    ");
		sql.append("	  FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)     JUSA_NAME,			                                                    ");
		sql.append("	  D.SUNAME                                          SUNAME,																									");
		sql.append("	  IFNULL(A.DRG_BUNHO, '')             DRG_BUNHO,																											");
		sql.append("	  A.FKOCS2003             FKOCS2003,																														");
		sql.append("	  A.APPEND_YN             APPEND_YN,																														");
		sql.append("	  IFNULL(A.RE_USE_YN, '')             RE_USE_YN,																											");
		sql.append("	  A.HOPE_DATE             HOPE_DATE,																														");
		sql.append("	  A.HOPE_TIME             HOPE_TIME,																														");
		sql.append("	  SUBSTR(A.GROUP_SER,2,2) GROUP_SER,																														");
		sql.append("	  A.DC_YN                 DC_YN,																															");
		sql.append("	  F.ORDER_GUBUN           ORDER_GUBUN,																														");
		sql.append("	  G.IF_INPUT_CONTROL      IF_INPUT_CONTROL,																													");
		sql.append("	  CASE G.IF_INPUT_CONTROL WHEN 'P' THEN '1'																													");
		sql.append("	        WHEN 'B' THEN '2'																																	");
		sql.append("	        WHEN 'C' THEN '3'																																	");
		sql.append("	        ELSE G.IF_INPUT_CONTROL																																");
		sql.append("	      END																																					");
		sql.append("	  FROM																																						");
		sql.append("	    DRG3010 A JOIN INP1001 E																																");
		sql.append("	    ON E.HOSP_CODE            = A.HOSP_CODE																													");
		sql.append("	   AND E.PKINP1001            = A.FKINP1001																													");
		sql.append("	   JOIN OUT0101 D																																			");
		sql.append("	   ON D.HOSP_CODE            = A.HOSP_CODE																													");
		sql.append("	   AND D.BUNHO                = A.BUNHO																														");
		sql.append("	   JOIN OCS2003 F																																			");
		sql.append("	   ON F.HOSP_CODE            = A.HOSP_CODE																													");
		sql.append("	   AND F.PKOCS2003            = A.FKOCS2003																													");
		sql.append("	   JOIN OCS0103 G																																			");
		sql.append("	   ON G.HOSP_CODE            = F.HOSP_CODE																													");
		sql.append("	   AND F.HANGMOG_CODE         = G.HANGMOG_CODE																												");
		sql.append("	       LEFT JOIN INV0110 B																																	");
		sql.append("	       ON B.HOSP_CODE         = A.HOSP_CODE																													");
		sql.append("	   AND B.JAERYO_CODE       = A.JAERYO_CODE																													");
		sql.append("	       LEFT JOIN DRG0120 C																																	");
		sql.append("	   ON C.HOSP_CODE         = A.HOSP_CODE																														");
		sql.append("	   AND C.BOGYONG_CODE      = A.BOGYONG_CODE																													");
		sql.append("	 WHERE																																						");
		sql.append("	  A.HOSP_CODE            = :f_hosp_code																														");
		sql.append("	   AND A.ORDER_DATE           = STR_TO_DATE(:f_order_date,'%Y/%m/%d')																						");
		sql.append("	   AND A.BUNHO                = :f_bunho																													");
		sql.append("	   AND A.HOPE_DATE            = STR_TO_DATE(:f_hope_date,'%Y/%m/%d')																						");
		sql.append("	   AND E.HO_DONG1             = :f_ho_dong																													");
		sql.append("	   AND A.RESIDENT             = :f_doctor																													");
		sql.append("	   AND IFNULL(A.APPEND_YN,'N')   LIKE :f_magam_gubun																										");
		sql.append("	   AND A.BUNRYU1              IN ('1','6')																													");
		sql.append("	   AND IFNULL(A.EMERGENCY,'N')     = 'N'																													");
		sql.append("	   AND IFNULL(A.TOIWON_DRG_YN,'N') = 'N'																													");
		sql.append("	   AND A.DRG_BUNHO            IS NULL																														");
		sql.append("	   AND A.NALSU                > 0																															");
		sql.append("	   AND IFNULL(A.DC_YN,'N')       = 'N'																														");
		sql.append("	   AND IFNULL(A.BANNAB_YN,'N')   = 'N'																														");
		sql.append("	   AND IFNULL(A.RE_USE_YN, 'N')  = 'N'																														");
		sql.append("	   																																							");
		sql.append("	   AND :f_magam_bunryu        = '1'																															");
		sql.append("	   AND A.ORDER_DATE BETWEEN G.START_DATE AND IFNULL(G.END_DATE, '9998/12/31')																				");
		sql.append("	UNION ALL																																					");
		sql.append("	SELECT																																						");
		sql.append("	  A.ORDER_DATE            ORDER_DATE,																														");
		sql.append("	  A.MIX_GROUP             MIX_GROUP,																														");
		sql.append("	  A.JAERYO_CODE           JAERYO_CODE,																														");
		sql.append("	  B.JAERYO_NAME                                     JAERYO_NAME,																							");
		sql.append("	  A.ORD_SURYANG           ORD_SURYANG,																														");
		sql.append("	  A.DV_TIME               DV_TIME,																															");
		sql.append("	  A.DV                    DV,																																");
		sql.append("	  A.NALSU                 NALSU,																															");
		sql.append("	  A.ORDER_DANUI           ORDER_DANUI,																														");
		sql.append("	  FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) DANUI_NAME,																	");
		sql.append("	  A.BOGYONG_CODE          BOGYONG_CODE,																														");
		sql.append("	  CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))     BOGYONG_NAME,			");
		sql.append("	  A.POWDER_YN             POWDER_YN,																														");
		sql.append("	  A.REMARK                REMARK,																															");
		sql.append("	  A.DV_1                  DV_1,																																");
		sql.append("	  A.DV_2                  DV_2,																																");
		sql.append("	  A.DV_3                  DV_3,																																");
		sql.append("	  A.DV_4                  DV_4,																																");
		sql.append("	  A.DV_5                  DV_5,																																");
		sql.append("	  FN_DRG_JUNINP_YN(A.HOSP_CODE,A.FKOCS2003, 'N')      HUBAL_CHANGE_YN,																						");
		sql.append("	  A.PHARMACY              PHARMACY,																															");
		sql.append("	  A.DRG_PACK_YN           DRG_PACK_YN,																														");
		sql.append("	  FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)     JUSA_NAME,																");
		sql.append("	  D.SUNAME                                          SUNAME,																									");
		sql.append("	  A.DRG_BUNHO             DRG_BUNHO,																														");
		sql.append("	  A.FKOCS2003             FKOCS2003,																														");
		sql.append("	  A.APPEND_YN             APPEND_YN,																														");
		sql.append("	  A.RE_USE_YN             RE_USE_YN,																														");
		sql.append("	  A.HOPE_DATE             HOPE_DATE,																														");
		sql.append("	  A.HOPE_TIME             HOPE_TIME,																														");
		sql.append("	  SUBSTR(A.GROUP_SER,2,2) GROUP_SER,																														");
		sql.append("	  A.DC_YN                 DC_YN,																															");
		sql.append("	  F.ORDER_GUBUN           ORDER_GUBUN,																														");
		sql.append("	  G.IF_INPUT_CONTROL      IF_INPUT_CONTROL,																													");
		sql.append("	  CASE G.IF_INPUT_CONTROL																																	");
		sql.append("	        WHEN 'P' THEN '1'																																	");
		sql.append("	        WHEN 'B' THEN '2'																																	");
		sql.append("	        WHEN 'C' THEN '3'																																	");
		sql.append("	        ELSE G.IF_INPUT_CONTROL																																");
		sql.append("	      END																																					");
		sql.append("	  FROM																																						");
		sql.append("	  	DRG3010 A JOIN INP1001 E																																");
		sql.append("	   		ON E.HOSP_CODE            	= A.HOSP_CODE																											");
		sql.append("	        AND E.PKINP1001            	= A.FKINP1001																											");
		sql.append("	        JOIN OUT0101 D																																		");
		sql.append("	        ON D.HOSP_CODE            	= A.HOSP_CODE																											");
		sql.append("	        AND D.BUNHO                	= A.BUNHO																												");
		sql.append("	        JOIN OCS2003 F																																		");
		sql.append("	        ON F.HOSP_CODE            	= A.HOSP_CODE																											");
		sql.append("	        AND F.PKOCS2003            	= A.FKOCS2003																											");
		sql.append("	        JOIN OCS0103 G																																		");
		sql.append("	   		ON G.HOSP_CODE            	= F.HOSP_CODE																											");
		sql.append("	   		AND F.HANGMOG_CODE         	= G.HANGMOG_CODE																										");
		sql.append("	       	LEFT JOIN INV0110 B																																	");
		sql.append("	   		ON B.HOSP_CODE         		= A.HOSP_CODE																											");
		sql.append("	   		AND B.JAERYO_CODE       	= A.JAERYO_CODE																											");
		sql.append("	       	LEFT JOIN DRG0120 C																																	");
		sql.append("	   		ON C.HOSP_CODE         		= A.HOSP_CODE																											");
		sql.append("	   		AND C.BOGYONG_CODE      	= A.BOGYONG_CODE																										");
		sql.append("	 WHERE A.HOSP_CODE                      = :f_hosp_code																										");
		sql.append("	   AND A.ORDER_DATE                     = STR_TO_DATE(:f_order_date,'%Y/%m/%d')																				");
		sql.append("	   AND A.BUNHO                          = :f_bunho																											");
		sql.append("	   AND A.HOPE_DATE                      = STR_TO_DATE(:f_hope_date,'%Y/%m/%d')																				");
		sql.append("	   AND E.HO_DONG1                       = :f_ho_dong																										");
		sql.append("	   AND A.RESIDENT                       = :f_doctor																											");
		sql.append("	   AND IFNULL(A.APPEND_YN,'N')   		LIKE :f_magam_gubun																									");
		sql.append("	   AND A.BUNRYU1              			IN ('4')																											");
		sql.append("	   AND IFNULL(A.EMERGENCY,'N')     		= 'N'																												");
		sql.append("	   AND IFNULL(A.TOIWON_DRG_YN,'N') 		= 'N'																												");
		sql.append("	   AND A.DRG_BUNHO            			IS NULL																												");
		sql.append("	   AND A.NALSU                			> 0																													");
		sql.append("	   AND IFNULL(A.DC_YN,'N')              = 'N'																												");
		sql.append("	   AND IFNULL(A.BANNAB_YN,'N')          = 'N'																												");
		sql.append("	   AND IFNULL(A.RE_USE_YN, 'N')         = 'N'																												");
		sql.append("	   AND :f_magam_bunryu        			= '2'																												");
		sql.append("	   AND A.ORDER_DATE 					BETWEEN G.START_DATE AND IFNULL(G.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))									");
		sql.append("	 ORDER BY																																					");
		sql.append("	  ORDER_DATE, GROUP_SER, MIX_GROUP, DRG_BUNHO																												");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hope_date", hopeDate);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_magam_gubun", magamGubun);
		query.setParameter("f_magam_bunryu", magamBunryu);
		
		List<DRG3010P10GrdMiMaJuOrdInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdMiMaJuOrdInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10GrdMiMaOrdInfo> getDRG3010P10GrdMiMaOrdInfo(String hospCode, String language,
			String orderDate, String bunho, String hopeDate, String hoDong, String doctor, String magamGubun, String magamBunryu) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																									");
		sql.append("	  A.ORDER_DATE                                                                                                                          ORDER_DATE,						");
		sql.append("	  IFNULL(A.MIX_GROUP, '')                                                                                                               MIX_GROUP,						");
		sql.append("	  A.JAERYO_CODE                                                                                                                         JAERYO_CODE,					");
		sql.append("	  B.JAERYO_NAME                                                                                                                         JAERYO_NAME,					");
		sql.append("	  A.ORD_SURYANG                                                                                                                         ORD_SURYANG,					");
		sql.append("	  A.DV_TIME                                                                                                                             DV_TIME,						");
		sql.append("	  A.DV                                                                                                                                  DV,								");
		sql.append("	  A.NALSU                                                                                                                               NALSU,							");
		sql.append("	  A.ORDER_DANUI                                                                                                                         ORDER_DANUI,					");
		sql.append("	  FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) 															DANUI_NAME,						");
		sql.append("	  A.BOGYONG_CODE                                                                                                                        BOGYONG_CODE,					");
		sql.append("	  IFNULL(C.BOGYONG_NAME, '')                                                                                                            BOGYONG_NAME,					");
		sql.append("	  A.POWDER_YN                                                                                                                           POWDER_YN,						");
		sql.append("	  IFNULL(A.REMARK, '')                                                                                                                  REMARK,							");
		sql.append("	  IFNULL(A.DV_1, '')                                                                                                                    DV_1,							");
		sql.append("	  IFNULL(A.DV_2, '')                                                                                                                    DV_2,							");
		sql.append("	  IFNULL(A.DV_3, '')                                                                                                                    DV_3,							");
		sql.append("	  IFNULL(A.DV_4, '')                                                                                                                    DV_4,							");
		sql.append("	  IFNULL(A.DV_5, '')                                                                                                                    DV_5,							");
		sql.append("	  FN_DRG_JUNINP_YN(:f_hosp_code, A.FKOCS2003, NULL)  																					HUBAL_CHANGE_YN,				");
		sql.append("	  A.PHARMACY                                                                                                                            PHARMACY,						");
		sql.append("	  A.DRG_PACK_YN                                                                                                                         DRG_PACK_YN,					");
		sql.append("	  FN_OCS_LOAD_CODE_NAME('JUSA', IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)     														JUSA_NAME,						");
		sql.append("	  D.SUNAME                                                                                                                              SUNAME,							");
		sql.append("	  IFNULL(A.DRG_BUNHO, '')                                                                                                               DRG_BUNHO,						");
		sql.append("	  A.FKOCS2003                                                                                                                           FKOCS2003,						");
		sql.append("	  A.APPEND_YN                                                                                                                           APPEND_YN,						");
		sql.append("	  IFNULL(A.RE_USE_YN, '')                                                                                                               RE_USE_YN,						");
		sql.append("	  A.HOPE_DATE                                                                                                                           HOPE_DATE,						");
		sql.append("	  A.HOPE_TIME                                                                                                                           HOPE_TIME,						");
		sql.append("	  SUBSTRING(A.GROUP_SER,2,2) 																											GROUP_SER,						");
		sql.append("	  A.DC_YN                                                                                                                               DC_YN,							");
		sql.append("	  F.ORDER_GUBUN                                                                                                                         ORDER_GUBUN,					");
		sql.append("	  G.IF_INPUT_CONTROL                                                                                                                    IF_INPUT_CONTROL,				");
		sql.append("	  IFNULL(F.BROUGHT_DRG_YN, '')        																									BROUGHT_DRG_YN					");
		sql.append("	FROM																																									");
		sql.append("		DRG3010 A JOIN OUT0101 D																																			");
		sql.append("			ON D.HOSP_CODE            	= A.HOSP_CODE																														");
		sql.append("	   		AND D.BUNHO                	= A.BUNHO																															");
		sql.append("		 	JOIN INP1001 E																																					");
		sql.append("		 	ON E.HOSP_CODE            	= A.HOSP_CODE																														");
		sql.append("	   		AND E.PKINP1001            	= A.FKINP1001																														");
		sql.append("		 	JOIN OCS2003 F																																					");
		sql.append("		 	ON F.HOSP_CODE            	= A.HOSP_CODE																														");
		sql.append("	   		AND F.PKOCS2003            	= A.FKOCS2003																														");
		sql.append("		 	JOIN OCS0103 G																																					");
		sql.append("		 	ON F.HOSP_CODE            	= G.HOSP_CODE																														");
		sql.append("	   		AND F.HANGMOG_CODE         	= G.HANGMOG_CODE																													");
		sql.append("		 	LEFT JOIN INV0110 B																																				");
		sql.append("		 	ON B.HOSP_CODE         		= A.HOSP_CODE																														");
		sql.append("	   		AND B.JAERYO_CODE       	= A.JAERYO_CODE																														");
		sql.append("		 	LEFT JOIN DRG0120 C																																				");
		sql.append("		 	ON C.HOSP_CODE         		= A.HOSP_CODE																														");
		sql.append("	   		AND C.BOGYONG_CODE      	= A.BOGYONG_CODE																													");
		sql.append("	 WHERE A.HOSP_CODE                      = :f_hosp_code																													");
		sql.append("	   AND A.ORDER_DATE                     = :f_order_date																													");
		sql.append("	   AND A.BUNHO                          = :f_bunho																														");
		sql.append("	   AND A.HOPE_DATE                      = :f_hope_date																													");
		sql.append("	   AND E.HO_DONG1                       = :f_ho_dong																													");
		sql.append("	   AND A.RESIDENT                       = :f_doctor																														");
		sql.append("	   AND IFNULL(A.APPEND_YN,'N')   		LIKE :f_magam_gubun																												");
		sql.append("	   AND A.BUNRYU1              			IN ('1','6')																													");
		sql.append("	   AND IFNULL(A.EMERGENCY,'N')     		= 'N'																															");
		sql.append("	   AND IFNULL(A.TOIWON_DRG_YN,'N') 		= 'N'																															");
		sql.append("	   AND A.DRG_BUNHO            			IS NULL																															");
		sql.append("	   AND A.NALSU                			> 0																																");
		sql.append("	   AND IFNULL(A.DC_YN,'N')              = 'N'																															");
		sql.append("	   AND IFNULL(A.BANNAB_YN,'N')          = 'N'																															");
		sql.append("	   AND IFNULL(A.RE_USE_YN, 'N')         = 'N'																															");
		sql.append("	   AND :f_magam_bunryu        			= '1'																															");
		sql.append("	   AND A.ORDER_DATE 					BETWEEN G.START_DATE AND IFNULL(G.END_DATE, '9998/12/31')																		");
		sql.append("	 UNION ALL																																								");
		sql.append("	SELECT																																									");
		sql.append("	  A.ORDER_DATE                                                                                                                          ORDER_DATE,						");
		sql.append("	  A.MIX_GROUP                                                                                                                           MIX_GROUP,						");
		sql.append("	  A.JAERYO_CODE                                                                                                                         JAERYO_CODE,					");
		sql.append("	  B.JAERYO_NAME                                                                                                                         JAERYO_NAME,					");
		sql.append("	  A.ORD_SURYANG                                                                                                                         ORD_SURYANG,					");
		sql.append("	  A.DV_TIME                                                                                                                             DV_TIME,						");
		sql.append("	  A.DV                                                                                                                                  DV,								");
		sql.append("	  A.NALSU                                                                                                                               NALSU,							");
		sql.append("	  A.ORDER_DANUI                                                                                                                         ORDER_DANUI,					");
		sql.append("	  FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) 															DANUI_NAME,						");
		sql.append("	  A.BOGYONG_CODE          																												BOGYONG_CODE,					");
		sql.append("	  CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))     	BOGYONG_NAME,					");
		sql.append("	  A.POWDER_YN                                                                                                                           POWDER_YN,						");
		sql.append("	  A.REMARK                                                                                                                              REMARK,							");
		sql.append("	  A.DV_1                                                                                                                                DV_1,							");
		sql.append("	  A.DV_2                                                                                                                                DV_2,							");
		sql.append("	  A.DV_3                                                                                                                                DV_3,							");
		sql.append("	  A.DV_4                                                                                                                                DV_4,							");
		sql.append("	  A.DV_5                                                                                                                                DV_5,							");
		sql.append("	  FN_DRG_JUNINP_YN(:f_hosp_code, A.FKOCS2003, NULL)      																				HUBAL_CHANGE_YN,				");
		sql.append("	  A.PHARMACY                                                                                                                            PHARMACY,						");
		sql.append("	  A.DRG_PACK_YN                                                                                                                         DRG_PACK_YN,					");
		sql.append("	  FN_OCS_LOAD_CODE_NAME('JUSA', IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)     														JUSA_NAME,						");
		sql.append("	  D.SUNAME                                                                                                                              SUNAME,							");
		sql.append("	  A.DRG_BUNHO                                                                                                                           DRG_BUNHO,						");
		sql.append("	  A.FKOCS2003                                                                                                                           FKOCS2003,						");
		sql.append("	  A.APPEND_YN                                                                                                                           APPEND_YN,						");
		sql.append("	  A.RE_USE_YN                                                                                                                           RE_USE_YN,						");
		sql.append("	  A.HOPE_DATE                                                                                                                           HOPE_DATE,						");
		sql.append("	  A.HOPE_TIME                                                                                                                           HOPE_TIME,						");
		sql.append("	  SUBSTRING(A.GROUP_SER,2,2) 																											GROUP_SER,						");
		sql.append("	  A.DC_YN                                                                                                                               DC_YN,							");
		sql.append("	  F.ORDER_GUBUN                                                                                                                         ORDER_GUBUN,					");
		sql.append("	  G.IF_INPUT_CONTROL                                                                                                                    IF_INPUT_CONTROL,				");
		sql.append("	  F.BROUGHT_DRG_YN                                                                                                                      BROUGHT_DRG_YN					");
		sql.append("	FROM																																									");
		sql.append("		DRG3010 A JOIN OUT0101 D																																			");
		sql.append("			ON D.HOSP_CODE            	= A.HOSP_CODE																														");
		sql.append("	   		AND D.BUNHO                	= A.BUNHO																															");
		sql.append("			JOIN INP1001 E																																					");
		sql.append("			ON E.HOSP_CODE            	= A.HOSP_CODE																														");
		sql.append("	   		AND E.PKINP1001            	= A.FKINP1001																														");
		sql.append("			JOIN OCS2003 F																																					");
		sql.append("	   		ON F.HOSP_CODE            	= A.HOSP_CODE																														");
		sql.append("	   		AND F.PKOCS2003            	= A.FKOCS2003																														");
		sql.append("			JOIN OCS0103 G																																					");
		sql.append("			ON F.HOSP_CODE            	= G.HOSP_CODE																														");
		sql.append("	   		AND F.HANGMOG_CODE 			= G.HANGMOG_CODE																													");
		sql.append("			LEFT JOIN INV0110 B																																				");
		sql.append("	   		ON B.HOSP_CODE            	= A.HOSP_CODE																														");
		sql.append("	   		AND B.JAERYO_CODE          	= A.JAERYO_CODE																														");
		sql.append("			LEFT JOIN DRG0120 C																																				");
		sql.append("	   		ON C.HOSP_CODE            	= A.HOSP_CODE																														");
		sql.append("	   		AND C.BOGYONG_CODE         	= A.BOGYONG_CODE																													");
		sql.append("	 WHERE A.HOSP_CODE                  = :f_hosp_code																														");
		sql.append("	   AND A.ORDER_DATE                 = :f_order_date																														");
		sql.append("	   AND A.BUNHO                      = :f_bunho																															");
		sql.append("	   AND A.HOPE_DATE                  = :f_hope_date																														");
		sql.append("	   AND A.BUNHO                      = :f_bunho																															");
		sql.append("	   AND E.HO_DONG1                   = :f_ho_dong																														");
		sql.append("	   AND A.RESIDENT                   = :f_doctor																															");
		sql.append("	   AND IFNULL(A.APPEND_YN,'N')   	LIKE :f_magam_gubun																													");
		sql.append("	   AND A.BUNRYU1              		IN ('4')																															");
		sql.append("	   AND IFNULL(A.EMERGENCY,'N')     	= 'N'																																");
		sql.append("	   AND IFNULL(A.TOIWON_DRG_YN,'N') 	= 'N'																																");
		sql.append("	   AND A.DRG_BUNHO            		IS NULL																																");
		sql.append("	   AND A.NALSU                		> 0																																	");
		sql.append("	   AND IFNULL(A.DC_YN,'N')          = 'N'																																");
		sql.append("	   AND IFNULL(A.BANNAB_YN,'N')      = 'N'																																");
		sql.append("	   AND IFNULL(A.RE_USE_YN, 'N')     = 'N'																																");
		sql.append("	   AND :f_magam_bunryu        		= '2'																																");
		sql.append("	   AND A.ORDER_DATE 				BETWEEN G.START_DATE AND IFNULL(G.END_DATE, '9998/12/31')																			");
		sql.append("	ORDER BY																																								");
		sql.append("		ORDER_DATE, GROUP_SER, MIX_GROUP, DRG_BUNHO, JAERYO_CODE																											");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hope_date", hopeDate);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_magam_gubun", magamGubun);
		query.setParameter("f_magam_bunryu", magamBunryu);

		List<DRG3010P10GrdMiMaOrdInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdMiMaOrdInfo.class);
		return listInfo;
	}
	
	
	@Override
	public List<DRG3010P99OrdPrnCurInfo> getDRG3010P99OrdPrnCurInfo(String hospCode, String language, String jubsuDate, Double drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																													");
		sql.append("              A.BUNHO                                             BUNHO																	");
		sql.append("             ,LTRIM(CAST(A.DRG_BUNHO AS CHAR))                         DRG_BUNHO														");
		sql.append("             ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, A.HOSP_CODE, :f_language)    ORDER_DATE_TEXT								");
		sql.append("             ,DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')                                        JUBSU_DATE									");
		sql.append("             ,DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                        ORDER_DATE									");
		sql.append("             ,CONCAT('Rp.',E.SERIAL_V, CASE(IFNULL(A.MIX_GROUP,'')) WHEN '' THEN '' ELSE ' M' END) SERIAL_V								");
		sql.append("             ,E.SERIAL_V                                          SERIAL_TEXT															");
		sql.append("             ,FN_BAS_LOAD_GWA_NAME(F.GWA, A.JUBSU_DATE, A.HOSP_CODE, :f_language)           GWA_NAME									");
		sql.append("             ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, A.HOSP_CODE),'')   DOCTOR_NAME									");
		sql.append("             ,D.SUNAME                                            SUNAME																");
		sql.append("             ,D.SUNAME2                                           SUNAME2																");
		sql.append("             ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH, A.HOSP_CODE, :f_language)          BIRTH										");
		sql.append("             ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, A.HOSP_CODE)          SEX_AGE													");
		sql.append("             ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'')      HO_CODE			");
		sql.append("             ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'')      HO_DONG			");
		sql.append("             ,CASE(A.TOIWON_DRG_YN) WHEN '1' THEN 'OT' ELSE A.MAGAM_GUBUN END                   MAGAM_GUBUN								");
		sql.append("             ,CONCAT(DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), CAST(A.DRG_BUNHO AS CHAR), CAST(E.SERIAL_V AS CHAR))   RP_BARCODE				");
		sql.append("         FROM DRG3010 A																													");
		sql.append("         JOIN INV0110 B																													");
		sql.append("           ON B.HOSP_CODE          = A.HOSP_CODE																						");
		sql.append("          AND B.JAERYO_CODE        = A.JAERYO_CODE																						");
		sql.append("         LEFT JOIN DRG0120 C																											");
		sql.append("           ON C.HOSP_CODE          = A.HOSP_CODE																						");
		sql.append("          AND C.BOGYONG_CODE       = A.BOGYONG_CODE																						");
		sql.append("         JOIN OUT0101 D																													");
		sql.append("           ON D.HOSP_CODE          = A.HOSP_CODE																						");
		sql.append("          AND D.BUNHO              = A.BUNHO																							");
		sql.append("         JOIN DRG2035 E																													");
		sql.append("           ON E.HOSP_CODE          = A.HOSP_CODE																						");
		sql.append("          AND E.JUBSU_DATE         = A.JUBSU_DATE																						");
		sql.append("          AND E.DRG_BUNHO          = A.DRG_BUNHO																						");
		sql.append("          AND E.FKOCS2003          = A.FKOCS2003																						");
		sql.append("         JOIN INP1001 F																													");
		sql.append("           ON F.HOSP_CODE          = A.HOSP_CODE																						");
		sql.append("          AND F.PKINP1001          = A.FKINP1001																						");
		sql.append("        WHERE A.HOSP_CODE          = :f_hosp_code																						");
		sql.append("          AND A.JUBSU_DATE         = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																");
		sql.append("          AND A.DRG_BUNHO          = :f_drg_bunho																						");
		sql.append("          AND A.BUNRYU1            <> '4'																								");
		sql.append("        ORDER BY E.SERIAL_V																												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_jubsu_date", jubsuDate);
		
		List<DRG3010P99OrdPrnCurInfo> list = new JpaResultMapper().list(query, DRG3010P99OrdPrnCurInfo.class);
		return list;
	}
	
	@Override
	public List<DRG3010P99OrdPrnSerialInfo> getDRG3010P99SerialvInfo(String hospCode, String language, Double sourceFkocs2003, String serialV){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																																");
		sql.append("              A.BUNHO                                                                                 BUNHO											");
		sql.append("             ,CAST(A.DRG_BUNHO AS CHAR)                                                               DRG_BUNHO										");
		sql.append("             ,CAST(A.GROUP_SER AS CHAR)                                                               GROUP_SER										");
		sql.append("             ,DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d')                                                    JUBSU_DATE									");
		sql.append("             ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                                    RDER_DATE										");
		sql.append("             ,A.JAERYO_CODE                                                                           JAERYO_CODE									");
		sql.append("             ,CAST(A.NALSU * CASE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)) WHEN 'Y' THEN A.DIVIDE ELSE 1 END AS CHAR)  NALSU				");
		sql.append("             ,A.DIVIDE                                                                                DIVIDE										");
		sql.append("             ,CASE WHEN A.NALSU < 0 THEN CONCAT('-',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 															");
		sql.append("                             THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)									");
		sql.append("                   ELSE CONCAT('',CASE WHEN ROUND(A.ORD_SURYANG,2) < 1																				");
		sql.append("                             THEN CONCAT('0',ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('',ROUND(A.ORD_SURYANG,2)) END)									");
		sql.append("                    END                                                               ORD_SURYANG													");
		sql.append("             ,CAST(CASE(A.BUNRYU1) WHEN '4' THEN A.ORD_SURYANG ELSE A.ORDER_SURYANG END AS CHAR)      ORDER_SURYANG									");
		sql.append("             ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, A.HOSP_CODE, :f_language)               ORDER_DANUI									");
		sql.append("             ,A.SUBUL_DANUI                                                                           SUBUL_DANUI									");
		sql.append("             ,A.BOGYONG_CODE                                                                          BOGYONG_CODE									");
		sql.append("             ,CONCAT(TRIM(B.BOGYONG_NAME), FN_DRG_LOAD_RP_TEXT('I', A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v, A.HOSP_CODE),							");
		sql.append("               CASE(IFNULL(A.DV_1,0) + IFNULL(A.DV_2,0) + IFNULL(A.DV_3,0) + IFNULL(A.DV_4,0) + IFNULL(A.DV_5,0)) 									");
		sql.append("               WHEN 0 THEN '' ELSE CONCAT('(', LTRIM(CAST(IFNULL(A.DV_1,0) AS CHAR)), '-', LTRIM(CAST(IFNULL(A.DV_2,0) AS CHAR)), '-',				");
		sql.append("                   LTRIM(CAST(IFNULL(A.DV_3,0) AS CHAR)), '-', LTRIM(CAST(IFNULL(A.DV_4,0) AS CHAR)), '-',											");
		sql.append("                   LTRIM(CAST(IFNULL(A.DV_5,0) AS CHAR)), ')' ) END )                                 BOGYONG_NAME									");
		sql.append("             ,SUBSTR(FN_DRG_LOAD_CAUTION_NM(A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v, 'O', '1', A.HOSP_CODE, :f_language ),1,80)   CAUTION_NAME		");
		sql.append("             ,IFNULL(A.MIX_YN, '')                                                                    MIX_YN										");
		sql.append("             ,IFNULL(A.ATC_YN, '')                                                                    ATC_YN										");
		sql.append("             ,CAST(D.DV AS CHAR)                                                                      DV											");
		sql.append("             ,A.DV_TIME                                                                               DV_TIME										");
		sql.append("             ,IFNULL(D.DC_YN,'')                                                                      DC_YN											");
		sql.append("             ,IFNULL(D.BANNAB_YN,'')                                                                  BANNAB_YN										");
		sql.append("             ,D.SOURCE_FKOCS2003                                                                      SOURCE_FKOCS2003								");
		sql.append("             ,A.FKOCS2003                                                                             FKOCS2003										");
		sql.append("             ,DATE_FORMAT(CURRENT_DATE(),'%Y/%m/%d')                                                  SUNAB_DATE									");
		sql.append("             ,B.PATTERN                                                                               PATTERN										");
		sql.append("             ,F.HANGMOG_NAME                                                                          JAERYO_NAME									");
		sql.append("             ,'0'                                                                                     SUNAB_NALSU									");
		sql.append("             ,CASE(D.WONYOI_ORDER_YN) WHEN '' THEN 'N' ELSE IFNULL(D.WONYOI_ORDER_YN,'N')  END        WONYOI_YN										");
		sql.append("             ,IFNULL(CONCAT(F.HANGMOG_NAME, ' : ', TRIM(D.ORDER_REMARK)), '')                         ORDER_REMARK									");
		sql.append("             ,DATE_FORMAT(CURRENT_DATE(),'%Y/%m/%d')                                                  ACT_DATE										");
		sql.append("             ,CASE(C.MIX_YN_INP) WHEN '' THEN 'N' ELSE IFNULL(C.MIX_YN_INP, 'N') END                  UI_JUSA_YN									");
		sql.append("             ,CAST(A.SUBUL_SURYANG AS CHAR)                                                           SUBUL_SURYANG									");
		sql.append("             ,CONCAT('Rp.',LTRIM(LPAD(:f_serial_v, 2, '0')), CASE IFNULL(A.MIX_GROUP, '') WHEN '' THEN '' ELSE ' M' END)     SERIAL_V				");
		sql.append("             ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.JUBSU_DATE, A.HOSP_CODE, :f_language)                     GWA_NAME										");
		sql.append("             ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.JUBSU_DATE, A.HOSP_CODE),'')                 DOCTOR_NAME									");
		sql.append("             ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA, A.HOSP_CODE)                OTHER_GWA										");
		sql.append("             ,IFNULL(FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE, A.HOSP_CODE, :f_language),'')     HOPE_DATE										");
		sql.append("             ,A.POWDER_YN                                                                             POWDER_YN										");
		sql.append("             ,IFNULL(:f_serial_v, 1)                                                                   LINE											");
		sql.append("             ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language)             ORD_DANUI2									");
		sql.append("             ,SUBSTR(TRIM(A.BUNRYU1),1,1)                                                             BUNRYU1										");
		sql.append("             ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'') HO_DONG							");
		sql.append("             ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'') HO_CODE							");
		sql.append("             ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)                                      DONBOK										");
		sql.append("             ,''                                                                                      TUSUK											");
		sql.append("             ,CASE(A.TOIWON_DRG_YN) WHEN '1' THEN 'OT' ELSE A.MAGAM_GUBUN END                         MAGAM_GUBUN									");
		sql.append("             ,IFNULL(C.TEXT_COLOR, '')                                                                TEXT_COLOR									");
		sql.append("             ,IFNULL(C.CHANGGO1, '')                                                                  CHANGGO										");
		sql.append("             ,CONCAT('( ', DATE_FORMAT(CASE IFNULL(D.HOPE_DATE, '') 																				");
		sql.append("                    WHEN '' THEN D.ORDER_DATE ELSE D.HOPE_DATE END,'%m/%d'))                          FROM_ORDER_DATE								");
		sql.append("             ,CONCAT(DATE_FORMAT(DATE_ADD(CASE IFNULL(D.HOPE_DATE, '') 																				");
		sql.append("                    WHEN '' THEN D.ORDER_DATE ELSE D.HOPE_DATE END, INTERVAL A.NALSU - 1 DAY), '%m/%d'), ' )')   TO_ORDER_DATE						");
		sql.append("             ,'A'                                                                                     DATA_GUBUN									");
		sql.append("             ,CASE(IFNULL(C.ACT_JAERYO_NAME, '')) WHEN '' THEN F.HANGMOG_NAME ELSE C.ACT_JAERYO_NAME END           HODONG_ORD_NAME					");
		sql.append("             ,CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN, 'N') END                    MAX_BANNAB_YN									");
		sql.append("         FROM DRG3010 A																																");
		sql.append("      LEFT JOIN DRG0120 B																															");
		sql.append("           ON B.HOSP_CODE        = A.HOSP_CODE																										");
		sql.append("          AND B.BOGYONG_CODE     = A.BOGYONG_CODE																									");
		sql.append("         JOIN INV0110 C																																");
		sql.append("           ON C.HOSP_CODE        = A.HOSP_CODE																										");
		sql.append("          AND C.JAERYO_CODE      = A.JAERYO_CODE																									");
		sql.append("         JOIN OCS2003 D																																");
		sql.append("           ON D.HOSP_CODE        = A.HOSP_CODE																										");
		sql.append("          AND D.PKOCS2003        = A.FKOCS2003																										");
		sql.append("         JOIN OCS0103 F																																");
		sql.append("           ON F.HOSP_CODE        = D.HOSP_CODE																										");
		sql.append("          AND F.HANGMOG_CODE     = D.HANGMOG_CODE																									");
		sql.append("        WHERE A.HOSP_CODE        = :f_hosp_code																										");
		sql.append("          AND A.SOURCE_FKOCS2003 = :f_fkocs2003																										");
		sql.append("        ORDER BY A.FKOCS2003																														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_fkocs2003", sourceFkocs2003);
		query.setParameter("f_serial_v", serialV);
		
		List<DRG3010P99OrdPrnSerialInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99OrdPrnSerialInfo.class);
		return listInfo;
	}
	
	@Override
	public List<DRG3010P99OrdPrnRemarkInfo> getDRG3010P99OrdPrnRemarkInfo(String hospCode, String language, String jubsuDate, Double drgBunho, String serialText){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																																");
		sql.append("              A.BUNHO                                                                                 BUNHO											");
		sql.append("             ,CAST(A.DRG_BUNHO AS CHAR)                                                               DRG_BUNHO										");
		sql.append("             ,CAST(A.GROUP_SER AS CHAR)                                                               GROUP_SER										");
		sql.append("             ,DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d')                                                    JUBSU_DATE									");
		sql.append("             ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                                    ORDER_DATE									");
		sql.append("             ,A.JAERYO_CODE                                                                           JAERYO_CODE									");
		sql.append("             ,CAST(A.NALSU * CASE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)) WHEN 'Y' THEN A.DIVIDE ELSE 1 END AS CHAR)  NALSU				");
		sql.append("             ,A.DIVIDE                                                                                DIVIDE										");
		sql.append("             ,CAST(A.ORDER_SURYANG AS CHAR)                                                           ORD_SURYANG									");
		sql.append("             ,CAST(CASE(A.BUNRYU1) WHEN '4' THEN A.ORD_SURYANG ELSE A.ORDER_SURYANG END AS CHAR)      ORDER_SURYANG									");
		sql.append("             ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, A.HOSP_CODE, :f_language)               ORDER_DANUI									");
		sql.append("             ,A.SUBUL_DANUI                                                                           SUBUL_DANUI									");
		sql.append("             ,A.BOGYONG_CODE                                                                          BOGYONG_CODE									");
		sql.append("             ,CONCAT(TRIM(B.BOGYONG_NAME), FN_DRG_LOAD_RP_TEXT('I', E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, A.HOSP_CODE),							");
		sql.append("                         CASE(IFNULL(G.DV_1,0) + IFNULL(G.DV_2,0) + IFNULL(G.DV_3,0) + IFNULL(G.DV_4,0) + IFNULL(G.DV_5,0)) 						");
		sql.append("                       WHEN 0 THEN '' ELSE CONCAT('(', LTRIM(CAST(IFNULL(G.DV_1,0) AS CHAR)), '-', LTRIM(CAST(IFNULL(G.DV_2,0) AS CHAR)), '-',		");
		sql.append("                   LTRIM(CAST(IFNULL(G.DV_3,0) AS CHAR)), '-',LTRIM(CAST(IFNULL(G.DV_4,0) AS CHAR)), '-',											");
		sql.append("                   LTRIM(CAST(IFNULL(G.DV_5,0) AS CHAR)), ')' ) END)    BOGYONG_NAME																");
		sql.append("             ,SUBSTR(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O', '1', A.HOSP_CODE, :f_language ),1,80)   CAUTION_NAME		");
		sql.append("             ,IFNULL(A.MIX_YN, '')                                                                    MIX_YN										");
		sql.append("             ,IFNULL(A.ATC_YN, '')                                                                    ATC_YN										");
		sql.append("             ,CAST(D.DV AS CHAR)                                                                      DV											");
		sql.append("             ,A.DV_TIME                                                                               DV_TIME										");
		sql.append("             ,IFNULL(D.DC_YN,'')                                                                      DC_YN											");
		sql.append("             ,IFNULL(D.BANNAB_YN,'')                                                                  BANNAB_YN										");
		sql.append("             ,D.SOURCE_FKOCS2003                                                                      SOURCE_FKOCS2003								");
		sql.append("             ,A.FKOCS2003                                                                             FKOCS2003										");
		sql.append("             ,DATE_FORMAT(CURRENT_DATE(),'%Y/%m/%d')                                                  SUNAB_DATE									");
		sql.append("             ,B.PATTERN                                                                               PATTERN										");
		sql.append("             ,F.HANGMOG_NAME                                                                          JAERYO_NAME									");
		sql.append("             ,'0'                                                                                     SUNAB_NALSU									");
		sql.append("             ,CASE(D.WONYOI_ORDER_YN) WHEN '' THEN 'N' ELSE IFNULL(D.WONYOI_ORDER_YN,'N')  END        WONYOI_YN										");
		sql.append("             ,IFNULL(CONCAT(F.HANGMOG_NAME, ' : ', TRIM(D.ORDER_REMARK)), '')                         ORDER_REMARK									");
		sql.append("             ,DATE_FORMAT(CURRENT_DATE(),'%Y/%m/%d')                                                  ACT_DATE										");
		sql.append("             ,CASE(C.MIX_YN_INP) WHEN '' THEN 'N' ELSE IFNULL(C.MIX_YN_INP, 'N') END                  UI_JUSA_YN									");
		sql.append("             ,CAST(A.SUBUL_SURYANG AS CHAR)                                                           SUBUL_SURYANG									");
		sql.append("             ,CONCAT('Rp.',LTRIM(LPAD(E.SERIAL_V, 2, '0')), CASE IFNULL(G.MIX_GROUP, '') WHEN '' THEN '' ELSE ' M' END)     SERIAL_V				");
		sql.append("             ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.JUBSU_DATE, A.HOSP_CODE, :f_language)                     GWA_NAME										");
		sql.append("             ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, A.HOSP_CODE),'')                 DOCTOR_NAME									");
		sql.append("             ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA, A.HOSP_CODE)                OTHER_GWA										");
		sql.append("             ,IFNULL(FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE, A.HOSP_CODE, :f_language),'')     HOPE_DATE										");
		sql.append("             ,G.POWDER_YN                                                                             POWDER_YN										");
		sql.append("             ,IFNULL(E.SERIAL_V, 1)                                                                   LINE											");
		sql.append("             ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language)             ORD_DANUI2									");
		sql.append("             ,SUBSTR(TRIM(A.BUNRYU1),1,1)                                                             BUNRYU1										");
		sql.append("             ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'') HO_DONG							");
		sql.append("             ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'') HO_CODE							");
		sql.append("             ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)                                      DONBOK										");
		sql.append("             ,''                                                                                      TUSUK											");
		sql.append("             ,CASE(G.TOIWON_DRG_YN) WHEN '1' THEN 'OT' ELSE G.MAGAM_GUBUN END                         MAGAM_GUBUN									");
		sql.append("             ,IFNULL(C.TEXT_COLOR, '')                                                                TEXT_COLOR									");
		sql.append("             ,IFNULL(C.CHANGGO1, '')                                                                  CHANGGO										");
		sql.append("             ,CONCAT('( ', DATE_FORMAT(CASE IFNULL(D.HOPE_DATE, '')																					");
		sql.append("                    WHEN '' THEN D.ORDER_DATE ELSE D.HOPE_DATE END,'%m/%d'))                          FROM_ORDER_DATE								");
		sql.append("             ,CONCAT(DATE_FORMAT(DATE_ADD(CASE IFNULL(D.HOPE_DATE, '') 																				");
		sql.append("                    WHEN '' THEN D.ORDER_DATE ELSE D.HOPE_DATE END, INTERVAL A.NALSU - 1 DAY), '%m/%d'), ' )')   TO_ORDER_DATE						");
		sql.append("             ,'B'                                                                                     DATA_GUBUN									");
		sql.append("             ,CASE(IFNULL(C.ACT_JAERYO_NAME, '')) WHEN '' THEN F.HANGMOG_NAME ELSE C.ACT_JAERYO_NAME END           HODONG_ORD_NAME					");
		sql.append("             ,(SELECT MAX(CASE(X.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(X.BANNAB_YN, 'N') END)														");
		sql.append("                 FROM DRG3010 X																														");
		sql.append("                 JOIN DRG3011 W																														");
		sql.append("                   ON W.HOSP_CODE        = X.HOSP_CODE																								");
		sql.append("                  AND W.JUBSU_DATE       = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																	");
		sql.append("                  AND W.DRG_BUNHO        = :f_drg_bunho																								");
		sql.append("                 JOIN DRG2035 Z																														");
		sql.append("                   ON Z.HOSP_CODE        = W.HOSP_CODE																								");
		sql.append("                  AND Z.JUBSU_DATE       = W.JUBSU_DATE																								");
		sql.append("                  AND Z.DRG_BUNHO        = W.DRG_BUNHO																								");
		sql.append("                  AND Z.FKOCS2003        = W.FKOCS2003																								");
		sql.append("                  AND Z.SERIAL_V         = :f_serial_text																							");
		sql.append("                 JOIN DRG2035 Y																														");
		sql.append("                   ON Y.HOSP_CODE        = X.HOSP_CODE																								");
		sql.append("                 AND Y.JUBSU_DATE        = Z.JUBSU_DATE																								");
		sql.append("                 AND Y.DRG_BUNHO         = Z.DRG_BUNHO																								");
		sql.append("                  AND Y.FKOCS2003        = X.FKOCS2003																								");
		sql.append("                 AND Y.SERIAL_V          = Z.SERIAL_V																								");
		sql.append("                WHERE X.HOSP_CODE        = :f_hosp_code																								");
		sql.append("                  )                                                     MAX_BANNAB_YN																");
		sql.append("         FROM DRG3011 A																																");
		sql.append("      LEFT JOIN DRG0120 B																															");
		sql.append("           ON B.HOSP_CODE        = A.HOSP_CODE																										");
		sql.append("          AND B.BOGYONG_CODE     = A.BOGYONG_CODE																									");
		sql.append("         JOIN INV0110 C																																");
		sql.append("           ON C.HOSP_CODE        = A.HOSP_CODE																										");
		sql.append("          AND C.JAERYO_CODE      = A.JAERYO_CODE																									");
		sql.append("         JOIN OCS2003 D																																");
		sql.append("           ON D.HOSP_CODE        = A.HOSP_CODE																										");
		sql.append("          AND D.PKOCS2003        = A.FKOCS2003																										");
		sql.append("          AND (TRIM(D.ORDER_REMARK) IS NOT NULL AND TRIM(D.ORDER_REMARK) <> '')																		");
		sql.append("         JOIN DRG2035 E																																");
		sql.append("           ON E.HOSP_CODE        = A.HOSP_CODE																										");
		sql.append("          AND E.JUBSU_DATE       = A.JUBSU_DATE																										");
		sql.append("          AND E.DRG_BUNHO        = A.DRG_BUNHO																										");
		sql.append("          AND E.FKOCS2003        = A.FKOCS2003																										");
		sql.append("          AND E.SERIAL_V         = :f_serial_text																									");
		sql.append("         JOIN OCS0103 F																																");
		sql.append("           ON F.HOSP_CODE        = D.HOSP_CODE																										");
		sql.append("          AND F.HANGMOG_CODE     = D.HANGMOG_CODE																									");
		sql.append("         JOIN DRG3010 G																																");
		sql.append("           ON G.HOSP_CODE        = A.HOSP_CODE																										");
		sql.append("          AND G.FKOCS2003        = A.FKOCS2003																										");
		sql.append("        WHERE A.HOSP_CODE        = :f_hosp_code																										");
		sql.append("         AND A.JUBSU_DATE       = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																			");
		sql.append("         AND A.DRG_BUNHO        = :f_drg_bunho																										");
		sql.append("        ORDER BY A.DRG_BUNHO,																														");
		sql.append("          CONCAT('Rp.',LTRIM(LPAD(E.SERIAL_V, 2, '0')), CASE IFNULL(G.MIX_GROUP, '') WHEN '' THEN '' ELSE ' M' END),								");
		sql.append("          A.FKOCS2003																																");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_serial_text", serialText);
		
		List<DRG3010P99OrdPrnRemarkInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99OrdPrnRemarkInfo.class);
		return listInfo;
	}
	
	@Override
	public List<DRG3010P99layOrderJungboInfo> getDRG3010P99layOrderJungboInfo(String hospCode, String language, Double drgBunho, String jubsuDate){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT '1'                SEQ_1																												");
		sql.append("           ,D.SERIAL_V         SEQ_2																												");
		sql.append("           ,IFNULL(C.JAERYO_NAME,'')      TEXT_1																									");
		sql.append("           ,''                 TEXT_2																												");
		sql.append("           ,''                 TEXT_3																												");
		sql.append("           ,IFNULL(REPLACE(REPLACE(B.ORDER_REMARK,CONCAT(CHAR(13 USING ASCII), CHAR(10 USING ASCII)),' '), CHAR(10 USING ASCII),' '),'')   REMARK	");
		sql.append("           ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), LTRIM(LPAD(A.DRG_BUNHO,4,'0')),'*')  BAR_DRG_BUNHO										");
		sql.append("           ,A.BUNHO            BUNHO																												");
		sql.append("       FROM DRG3010 A																																");
		sql.append("       JOIN DRG9042 B																																");
		sql.append("         ON B.FKOCS          = A.FKOCS2003																											");
		sql.append("        AND B.HOSP_CODE      = A.HOSP_CODE																											");
		sql.append("        AND (B.ORDER_REMARK  IS NOT NULL AND B.ORDER_REMARK <> '')																					");
		sql.append("       LEFT JOIN INV0110 C																															");
		sql.append("         ON C.JAERYO_CODE    = A.JAERYO_CODE																										");
		sql.append("        AND C.HOSP_CODE      = A.HOSP_CODE																											");
		sql.append("       LEFT JOIN DRG2035 D																															");
		sql.append("         ON D.FKOCS2003      = A.FKOCS2003																											");
		sql.append("        AND D.HOSP_CODE      = A.HOSP_CODE																											");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code																											");
		sql.append("        AND A.JUBSU_DATE     = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																				");
		sql.append("        AND A.DRG_BUNHO      = :f_drg_bunho																											");
		sql.append("     UNION ALL																																		");
		sql.append("     SELECT DISTINCT '1'       SEQ_1																												");
		sql.append("           ,''                 SEQ_2																												");
		sql.append("           ,IFNULL(C.JAERYO_NAME,'')      TEXT_1																									");
		sql.append("           ,''                 TEXT_2																												");
		sql.append("           ,''                 TEXT_3																												");
		sql.append("           ,IFNULL(CONCAT('[', FN_ADM_MSG(4111, :f_language), ']', 																					");
		sql.append("               REPLACE(REPLACE(C.DRG_COMMENT, CONCAT(CHAR(13 USING ASCII),CHAR(10 USING ASCII)),' '),CHAR(10 USING ASCII),' ')),'')      REMARK		");
		sql.append("           ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'),  LTRIM(LPAD(A.DRG_BUNHO,4,'0')),'*')  BAR_DRG_BUNHO										");
		sql.append("           ,A.BUNHO            BUNHO																												");
		sql.append("       FROM DRG3010 A																																");
		sql.append("       LEFT JOIN INV0110 C																															");
		sql.append("         ON C.JAERYO_CODE    = A.JAERYO_CODE																										");
		sql.append("        AND C.HOSP_CODE      = A.HOSP_CODE																											");
		sql.append("        AND CASE(C.CHKD) WHEN '' THEN 'N' ELSE IFNULL(C.CHKD,'N') END = 'Y'																			");
		sql.append("       LEFT JOIN DRG2035 D																															");
		sql.append("         ON D.FKOCS2003      = A.FKOCS2003																											");
		sql.append("        AND D.HOSP_CODE      = A.HOSP_CODE																											");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code																											");
		sql.append("        AND A.JUBSU_DATE     = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																				");
		sql.append("        AND A.DRG_BUNHO      = :f_drg_bunho																											");
		sql.append("     UNION ALL																																		");
		sql.append("     SELECT DISTINCT																																");
		sql.append("            '2'                SEQ_1																												");
		sql.append("           ,''                 SEQ_2																												");
		sql.append("           ,'##'               TEXT_1																												");
		sql.append("           ,''                 TEXT_2																												");
		sql.append("           ,''                 TEXT_3																												");
		sql.append("           ,IFNULL(REPLACE(REPLACE(B.ORDER_REMARK,CONCAT(CHAR(13 USING ASCII),CHAR(10 USING ASCII)),' '),CHAR(10 USING ASCII),' '),'')    REMARK	");
		sql.append("           ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'),  LTRIM(LPAD(A.DRG_BUNHO,4,'0')),'*')  BAR_DRG_BUNHO										");
		sql.append("           ,A.BUNHO            BUNHO																												");
		sql.append("       FROM DRG3010 A																																");
		sql.append("       JOIN DRG9040 B																																");
		sql.append("         ON B.JUBSU_DATE  = A.JUBSU_DATE																											");
		sql.append("        AND B.DRG_BUNHO   = A.DRG_BUNHO																												");
		sql.append("        AND B.HOSP_CODE   = A.HOSP_CODE																												");
		sql.append("        AND (B.ORDER_REMARK IS NOT NULL AND B.ORDER_REMARK <> '')																					");
		sql.append("      WHERE A.HOSP_CODE   = :f_hosp_code																											");
		sql.append("        AND A.JUBSU_DATE  = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																					");
		sql.append("        AND A.DRG_BUNHO   = :f_drg_bunho																											");
		sql.append("     UNION ALL																																		");
		sql.append("     SELECT DISTINCT																																");
		sql.append("            '3'                SEQ_1																												");
		sql.append("           ,''                 SEQ_2																												");
		sql.append("           ,'$$'               TEXT_1																												");
		sql.append("           ,''                 TEXT_2																												");
		sql.append("           ,''                 TEXT_3																												");
		sql.append("           ,REPLACE(REPLACE(B.ORDER_REMARK,CONCAT(CHAR(13 USING ASCII),CHAR(10 USING ASCII)),' '),CHAR(10 USING ASCII),' ')     REMARK				");
		sql.append("           ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'),  LTRIM(LPAD(A.DRG_BUNHO,4,'0')),'*')  BAR_DRG_BUNHO										");
		sql.append("           ,A.BUNHO            BUNHO																												");
		sql.append("       FROM DRG3010 A																																");
		sql.append("       LEFT JOIN DRG9041 B																															");
		sql.append("         ON B.BUNHO          = A.BUNHO																												");
		sql.append("        AND B.HOSP_CODE      = A.HOSP_CODE																											");
		sql.append("        AND (B.ORDER_REMARK IS NOT NULL AND B.ORDER_REMARK <> '')																					");
		sql.append("      WHERE A.JUBSU_DATE     = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																				");
		sql.append("        AND A.DRG_BUNHO      = :f_drg_bunho																											");
		sql.append("        AND A.HOSP_CODE      = :f_hosp_code																											");
		sql.append("        AND B.ORDER_REMARK IS NOT NULL																												");
		sql.append("      ORDER BY SEQ_1, SEQ_2																															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DRG3010P99layOrderJungboInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99layOrderJungboInfo.class);
		return listInfo;
	}
	
	@Override
	public String DRG3010P99getBarDrgBunho(String hospCode, String jubsuDate, Double drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'),  LTRIM(LPAD(A.DRG_BUNHO,4,'0')),'*')							");
		sql.append("       FROM DRG3010 A																												");
		sql.append("      WHERE A.JUBSU_DATE  = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																	");
		sql.append("        AND A.DRG_BUNHO   = :f_drg_bunho																							");
		sql.append("        AND A.HOSP_CODE   = :f_hosp_code																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list)){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public List<DRG3010P99getBodyIndexInfo> getDRG3010P99getBodyIndexInfo(String hospCode, String bunho, String comment){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT CAST(IFNULL(FN_NUR_LOAD_WEIGHT_HEIGHT('H', :f_bunho, :f_hosp_code), 0) AS CHAR) HEIGHT									");
		sql.append("           ,'Cm'                                                                            CM										");
		sql.append("           ,CAST(IFNULL(FN_NUR_LOAD_WEIGHT_HEIGHT('W', :f_bunho, :f_hosp_code), 0) AS CHAR) WEIGHT									");
		sql.append("           ,'Kg'                                                                            KG										");
		sql.append("           ,IFNULL(FN_CPL_HANGMOG_RESULT(:f_bunho, '00077', :f_hosp_code), '')              CPL_RESULT								");
		sql.append("           ,FN_ADM_CONVERT_KATAKANA_FULL(:f_comments, :f_hosp_code)                         COMMENTS								");
		sql.append("           ,CAST(TRUNCATE(LENGTH(IFNULL(:f_comments,' ')) / 80, 0) AS CHAR)                 CNT										");
		sql.append("       FROM DUAL																													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_comments", comment);
		
		List<DRG3010P99getBodyIndexInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99getBodyIndexInfo.class);
		return listInfo;
	}
	
	@Override
	public List<DRG3010P99layOrderBarcodeInfo> getDRG3010P99layOrderBarcodeInfo(String hospCode, Double drgBunho, String jubsuDate){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																												");
		sql.append("          CONCAT('*', DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'),CAST(A.DRG_BUNHO AS CHAR), '*')                            BAR_DRG_BUNHO	");
		sql.append("         ,CONCAT('*', DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'),CAST(A.DRG_BUNHO AS CHAR),CAST(A.GROUP_SER AS CHAR),'*')   BAR_RP_BUNHO	");
		sql.append("         ,CONCAT('Rp. ', CAST(A.GROUP_SER AS CHAR))                                                                 SER				");
		sql.append("         ,A.BUNHO                                                                                         			BUNHO			");
		sql.append("     FROM DRG3011 A																													");
		sql.append("     WHERE A.HOSP_CODE      = :f_hosp_code																							");
		sql.append("       AND A.JUBSU_DATE     = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																");
		sql.append("       AND A.DRG_BUNHO      = :f_drg_bunho																							");
		sql.append("     ORDER BY 1, 2																													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DRG3010P99layOrderBarcodeInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99layOrderBarcodeInfo.class);
		return listInfo;

	}
	
	@Override
	public List<DRG3010P99getBodyIndexBarcodeInfo> getDRG3010P99getBodyIndexBarcodeInfo(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT CAST(IFNULL(FN_NUR_LOAD_WEIGHT_HEIGHT('H', :f_bunho, :f_hosp_code), 0) AS CHAR) HEIGHT									");
		sql.append("           ,'Cm'                                                                            CM										");
		sql.append("           ,CAST(IFNULL(FN_NUR_LOAD_WEIGHT_HEIGHT('W', :f_bunho, :f_hosp_code), 0) AS CHAR) WEIGHT									");
		sql.append("           ,'Kg'                                                                            KG										");
		sql.append("           ,IFNULL(FN_CPL_HANGMOG_RESULT(:f_bunho, '00077', :f_hosp_code), '')              CPL_RESULT								");
		sql.append("       FROM DUAL																													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<DRG3010P99getBodyIndexBarcodeInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99getBodyIndexBarcodeInfo.class);
		return listInfo;
	}
	
	@Override
	public List<DRG3010P99JusaCurInfo> getDRG3010P99JusaCurInfo(String hospCode, String language, String jubsuDate, Double drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																													");
		sql.append("            A.BUNHO                                             BUNHO																	");
		sql.append("           ,LTRIM(CAST(A.DRG_BUNHO AS CHAR))                         DRG_BUNHO															");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, A.HOSP_CODE, :f_language)    ORDER_DATE_TEXT								");
		sql.append("           ,DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d')                  JUBSU_DATE															");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE ,'%Y/%m/%d')                  HOPE_DATE																");
		sql.append("           ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                  ORDER_DATE															");
		sql.append("           ,CONCAT('Rp.',E.SERIAL_V,CASE(IFNULL(A.MIX_GROUP, '')) WHEN '' THEN '' ELSE ' M' END) SERIAL_V								");
		sql.append("           ,E.SERIAL_V                                          SERIAL_TEXT																");
		sql.append("           ,FN_BAS_LOAD_GWA_NAME(F.GWA, A.JUBSU_DATE, A.HOSP_CODE, :f_language)           GWA_NAME										");
		sql.append("           ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, A.HOSP_CODE),'')   DOCTOR_NAME										");
		sql.append("           ,D.SUNAME                                            SUNAME																	");
		sql.append("           ,D.SUNAME2                                           SUNAME2																	");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH, A.HOSP_CODE, :f_language)          BIRTH											");
		sql.append("           ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, A.HOSP_CODE)          SEX_AGE													");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'')      HO_CODE				");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'')      HO_DONG				");
		sql.append("           ,A.MAGAM_GUBUN                                       MAGAM_GUBUN																");
		sql.append("           ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), CAST(A.DRG_BUNHO AS CHAR), CAST(E.SERIAL_V AS CHAR),'*')      RP_BARCODE		");
		sql.append("           ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), CAST(A.DRG_BUNHO AS CHAR),'*')                             BARCODE			");
		sql.append("           ,CONCAT(LTRIM(LPAD(E.SERIAL_V, 4,'0')), LTRIM(LPAD(A.GROUP_SER, 4, '0')),													");
		sql.append("                       CASE(A.MIX_GROUP) WHEN '' THEN ' ' ELSE IFNULL(A.MIX_GROUP, ' ') END) KE											");
		sql.append("       FROM DRG3010 A																													");
		sql.append("       LEFT JOIN INV0110 B																												");
		sql.append("         ON B.JAERYO_CODE        = A.JAERYO_CODE																						");
		sql.append("        AND B.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("       LEFT JOIN DRG0120 C																												");
		sql.append("         ON C.BOGYONG_CODE       = A.BOGYONG_CODE																						");
		sql.append("        AND C.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("       JOIN OUT0101 D																													");
		sql.append("         ON D.BUNHO              = A.BUNHO																								");
		sql.append("        AND D.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("       JOIN DRG2035 E																													");
		sql.append("         ON E.JUBSU_DATE         = A.JUBSU_DATE																							");
		sql.append("        AND E.DRG_BUNHO          = A.DRG_BUNHO																							");
		sql.append("        AND E.FKOCS2003          = A.FKOCS2003																							");
		sql.append("        AND E.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("       JOIN INP1001 F																													");
		sql.append("         ON F.HOSP_CODE          = A.HOSP_CODE																							");
		sql.append("        AND F.PKINP1001          = A.FKINP1001																							");
		sql.append("      WHERE A.HOSP_CODE          = :f_hosp_code																							");
		sql.append("        AND A.JUBSU_DATE         = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																");
		sql.append("        AND A.DRG_BUNHO          = :f_drg_bunho																							");
		sql.append("        AND A.BUNRYU1            IN ('4')																								");
		sql.append("        ORDER BY CONCAT(LTRIM(LPAD(E.SERIAL_V, 4,'0')), LTRIM(LPAD(A.GROUP_SER, 4, '0'))												");
		sql.append("			,CASE(A.MIX_GROUP) WHEN '' THEN ' ' ELSE IFNULL(A.MIX_GROUP, ' ') END)														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DRG3010P99JusaCurInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99JusaCurInfo.class);
		return listInfo;
	}
	
	@Override
	public List<DataStringListItemInfo> getDRG3010P99getFkocs2003Info(String hospCode, Double drgBunho, String jubsuDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT CAST(FKOCS2003 AS CHAR)    ");
		sql.append("    FROM DRG3010                      ");
		sql.append("    WHERE DRG_BUNHO  = :f_drg_bunho   ");
		sql.append("    AND JUBSU_DATE = :f_jubsu_date    ");
		sql.append("    AND HOSP_CODE = :f_hosp_code      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DataStringListItemInfo> listInfo = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10DsvJusaOrderPrint1Info> getDRG3010P10DsvJusaOrderPrint1Info(String hospCode, String language,
			String jubsuDate, String drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT																														");
		sql.append("	       A.BUNHO BUNHO,																												");
		sql.append("	       LTRIM(A.DRG_BUNHO) DRG_BUNHO,																								");
		sql.append("	       FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, :f_hosp_code, :f_language) ORDER_DATE_TEXT,									");
		sql.append("	       DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d') JUBSU_DATE,                                                                            ");
		sql.append("	       DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d') HOPE_DATE,	                                                                            ");
		sql.append("	       DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d') ORDER_DATE,                                                                            ");
		sql.append("	       CONCAT('Rp.', E.SERIAL_V, CASE A.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END) SERIAL_V,										");
		sql.append("	       E.SERIAL_V SERIAL_TEXT,																										");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language) GWA_NAME,												");
		sql.append("	       FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, :f_hosp_code) DOCTOR_NAME,													");
		sql.append("	       D.SUNAME SUNAME,																												");
		sql.append("	       D.SUNAME2 SUNAME2,																											");
		sql.append("	       FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH, :f_hosp_code, :f_language) BIRTH,													");
		sql.append("	       FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, :f_hosp_code) SEX_AGE,															");
		sql.append("	       SUBSTR(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TruncDate(CURRENT_TIMESTAMP, 'DD'), 'C'), 1, 20) HO_CODE,	");
		sql.append("	       SUBSTR(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TruncDate(CURRENT_TIMESTAMP, 'DD'), 'D'), 1, 20) HO_DONG,	");
		sql.append("	       A.MAGAM_GUBUN MAGAM_GUBUN,																									");
		sql.append("	       CONCAT('*', DATE_FORMAT(A.JUBSU_DATE, '%Y%m%d'), A.DRG_BUNHO, E.SERIAL_V, '*') RP_BARCODE,									");
		sql.append("	       CONCAT('*', DATE_FORMAT(A.JUBSU_DATE, '%Y%m%d'), A.DRG_BUNHO, '*') BARCODE,													");
		sql.append("	       CONCAT(LPAD(E.SERIAL_V, 4, '0000'), LPAD(A.GROUP_SER, 4, '0000'), IFNULL(A.MIX_GROUP, ' ')) KEY_ORDER						");
		sql.append("	  FROM DRG3010 A																													");
		sql.append("	       LEFT OUTER JOIN INV0110 B																									");
		sql.append("	          ON B.HOSP_CODE = A.HOSP_CODE AND B.JAERYO_CODE = A.JAERYO_CODE															");
		sql.append("	       LEFT OUTER JOIN DRG0120 C																									");
		sql.append("	          ON C.HOSP_CODE = A.HOSP_CODE AND C.BOGYONG_CODE = A.BOGYONG_CODE,															");
		sql.append("	       DRG2035 E,						                                                                                            ");
		sql.append("	       OUT0101 D						                                                                                            ");
		sql.append("	 WHERE     A.HOSP_CODE = :f_hosp_code	                                                                                            ");
		sql.append("	       AND A.BUNRYU1 IN ('4')			                                                                                            ");
		sql.append("	       AND D.HOSP_CODE = A.HOSP_CODE	                                                                                            ");
		sql.append("	       AND D.BUNHO = A.BUNHO			                                                                                            ");
		sql.append("	       AND E.HOSP_CODE = A.HOSP_CODE	                                                                                            ");
		sql.append("	       AND E.JUBSU_DATE = A.JUBSU_DATE	                                                                                            ");
		sql.append("	       AND E.DRG_BUNHO = A.DRG_BUNHO	                                                                                            ");
		sql.append("	       AND E.FKOCS2003 = A.FKOCS2003	                                                                                            ");
		sql.append("	       AND A.JUBSU_DATE = :f_jubsu_date	                                                                                            ");
		sql.append("	       AND A.DRG_BUNHO = :f_drg_bunho	                                                                                            ");
		sql.append("	ORDER BY CONCAT(LPAD(E.SERIAL_V, 4, '0000'), LPAD(A.GROUP_SER, 4, '0000'), IFNULL(A.MIX_GROUP, ' '))								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_drg_bunho", CommonUtils.parseDouble(drgBunho));
        
		List<DRG3010P10DsvJusaOrderPrint1Info> listInfo = new JpaResultMapper().list(query, DRG3010P10DsvJusaOrderPrint1Info.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10DsvJusaOrderPrint2Info> getDRG3010P10DsvJusaOrderPrint2Info(String hospCode, String language,
			String jubsuDate, String drgBunho, String serialText) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.JAERYO_CODE JAERYO_CODE,																							");
		sql.append("	       A.NALSU NALSU,					                                                                                    ");
		sql.append("	       A.DIVIDE DIVIDE,					                                                                                    ");
		sql.append("	       A.ORDER_SURYANG ORDER_SURYANG,	                                                                                    ");
		sql.append("	       A.SUBUL_SURYANG SUBUL_SURYANG,	                                                                                    ");
		sql.append("	       A.ORD_SURYANG ORD_SURYANG,		                                                                                    ");
		sql.append("	       A.ORDER_DANUI ORDER_DANUI,		                                                                                    ");
		sql.append("	       A.SUBUL_DANUI SUBUL_DANUI,		                                                                                    ");
		sql.append("	       A.BUNRYU1 BUNRYU1,				                                                                                    ");
		sql.append("	       A.BUNRYU2 BUNRYU2,				                                                                                    ");
		sql.append("	       A.BUNRYU3 BUNRYU3,				                                                                                    ");
		sql.append("	       A.BUNRYU4 BUNRYU4,				                                                                                    ");
		sql.append("	       TRIM(C.ORDER_REMARK) REMARK,		                                                                                    ");
		sql.append("	       A.DV_TIME DV_TIME,				                                                                                    ");
		sql.append("	       A.DV DV,							                                                                                    ");
		sql.append("	       A.BUNRYU6 BUNRYU6,				                                                                                    ");
		sql.append("	       A.MIX_GROUP MIX_GROUP,			                                                                                    ");
		sql.append("	       A.DV_1 DV_1,						                                                                                    ");
		sql.append("	       A.DV_2 DV_2,						                                                                                    ");
		sql.append("	       A.DV_3 DV_3,						                                                                                    ");
		sql.append("	       A.DV_4 DV_4,						                                                                                    ");
		sql.append("	       A.DV_5 DV_5,						                                                                                    ");
		sql.append("	       A.HUBAL_CHANGE_YN HUBAL_CHANGE_YN,	                                                                                ");
		sql.append("	       A.PHARMACY PHARMACY,					                                                                                ");
		sql.append("	       A.JUSA_SPD_GUBUN JUSA_SPD_GUBUN,		                                                                                ");
		sql.append("	       A.DRG_PACK_YN DRG_PACK_YN,			                                                                                ");
		sql.append("	       A.JUSA JUSA,							                                                                                ");
		sql.append("	       B.HANGMOG_NAME JAERYO_NAME,			                                                                                ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) DANUI_NAME,								");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language) SUBUL_DANUI_NAME,						");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('JUSA', IFNULL(A.JUSA, '0'), :f_hosp_code, :f_language) JUSA_NAME,								");
		sql.append("	       CONCAT(A.BOGYONG_CODE,																								");
		sql.append("	          ' ',																												");
		sql.append("	          FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN, '0'), :f_hosp_code, :f_language)) BOGYONG_NAME,	");
		sql.append("	       FN_DRG_LOAD_JUSA_NALSU_CNT(:f_hosp_code, A.BUNHO,			                                                        ");
		sql.append("	                                  A.ORDER_DATE,						                                                        ");
		sql.append("	                                  A.JAERYO_CODE,					                                                        ");
		sql.append("	                                  A.GROUP_SER,						                                                        ");
		sql.append("	                                  A.HOPE_DATE,						                                                        ");
		sql.append("	                                  'C') JUSA_NALSU,					                                                        ");
		sql.append("	       'A' DATA_GUBUN,												                                                        ");
		sql.append("	       IFNULL(D.ACT_JAERYO_NAME, B.HANGMOG_NAME) HODONG_ORD_NAME,	                                                        ");
		sql.append("	       CONCAT(														                                                        ");
		sql.append("	          LPAD(E.SERIAL_V, 4, '0000'),								                                                        ");
		sql.append("	          LPAD(A.GROUP_SER, 4, '0000'),								                                                        ");
		sql.append("	          IFNULL(A.MIX_GROUP, ' '),									                                                        ");
		sql.append("	          LPAD(CASE C.BOM_OCCUR_YN WHEN 'Y' THEN C.SEQ + 100 ELSE C.SEQ END, 4, '0000'),									");
		sql.append("	          LPAD(C.PKOCS2003, 10, '0000000000')) KEY_ORDER,	                                                                ");
		sql.append("	       (SELECT MAX(IFNULL(X.BANNAB_YN, 'N'))				                                                                ");
		sql.append("	          FROM DRG3010 X, DRG2035 Y							                                                                ");
		sql.append("	         WHERE     Y.HOSP_CODE = :f_hosp_code				                                                                ");
		sql.append("	               AND Y.JUBSU_DATE = E.JUBSU_DATE				                                                                ");
		sql.append("	               AND Y.DRG_BUNHO = E.DRG_BUNHO				                                                                ");
		sql.append("	               AND Y.SERIAL_V = E.SERIAL_V					                                                                ");
		sql.append("	               AND X.HOSP_CODE = Y.HOSP_CODE				                                                                ");
		sql.append("	               AND Y.FKOCS2003 = X.FKOCS2003)				                                                                ");
		sql.append("	          MAX_BANNAB_YN,									                                                                ");
		sql.append("	       A.BANNAB_YN BANNAB_YN,								                                                                ");
		sql.append("	       A.FKOCS2003 FKOCS2003								                                                                ");
		sql.append("	  FROM DRG3010 A											                                                                ");
		sql.append("	       LEFT OUTER JOIN INV0110 D							                                                                ");
		sql.append("	          ON A.HOSP_CODE = D.HOSP_CODE AND A.JAERYO_CODE = D.JAERYO_CODE,													");
		sql.append("	       DRG2035 E,							                                                                                ");
		sql.append("	       OCS2003 C,							                                                                                ");
		sql.append("	       OCS0103 B							                                                                                ");
		sql.append("	 WHERE     A.HOSP_CODE = :f_hosp_code		                                                                                ");
		sql.append("	       AND A.BUNRYU1 IN ('4')				                                                                                ");
		sql.append("	       AND B.HOSP_CODE = C.HOSP_CODE		                                                                                ");
		sql.append("	       AND B.HANGMOG_CODE = C.HANGMOG_CODE	                                                                                ");
		sql.append("	       AND E.HOSP_CODE = A.HOSP_CODE		                                                                                ");
		sql.append("	       AND E.JUBSU_DATE = A.JUBSU_DATE		                                                                                ");
		sql.append("	       AND E.DRG_BUNHO = A.DRG_BUNHO		                                                                                ");
		sql.append("	       AND E.FKOCS2003 = A.FKOCS2003		                                                                                ");
		sql.append("	       AND C.HOSP_CODE = A.HOSP_CODE		                                                                                ");
		sql.append("	       AND C.PKOCS2003 = A.FKOCS2003		                                                                                ");
		sql.append("	       AND A.JUBSU_DATE = :f_jubsu_date		                                                                                ");
		sql.append("	       AND A.DRG_BUNHO = :f_drg_bunho		                                                                                ");
		sql.append("	       AND E.SERIAL_V = :f_serial_text		                                                                                ");
		sql.append("	       AND C.ORDER_DATE BETWEEN B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31')											");
		sql.append("	ORDER BY CONCAT(LPAD(E.SERIAL_V, 4, '0000'),	                                                                            ");
		sql.append("	            LPAD(A.GROUP_SER, 4, '0000'),		                                                                            ");
		sql.append("	            IFNULL(A.MIX_GROUP, ' '),			                                                                            ");
		sql.append("	            LPAD(CASE C.BOM_OCCUR_YN			                                                                            ");
		sql.append("	                     WHEN 'Y' THEN C.SEQ + 100	                                                                            ");
		sql.append("	                     ELSE C.SEQ					                                                                            ");
		sql.append("	                  END, 4, 						                                                                            ");
		sql.append("	                  '0000'),						                                                                            ");
		sql.append("	            LPAD(C.PKOCS2003, 10, '0000000000'))	                                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_drg_bunho", CommonUtils.parseDouble(drgBunho));
		query.setParameter("f_serial_text", serialText);
        
		List<DRG3010P10DsvJusaOrderPrint2Info> listInfo = new JpaResultMapper().list(query, DRG3010P10DsvJusaOrderPrint2Info.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10DsvJusaOrderPrint3Info> getDRG3010P10DsvJusaOrderPrint3Info(String hospCode, String language,
			String serialV, String fkocs2003) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.JAERYO_CODE JAERYO_CODE,																		");
		sql.append("	       A.NALSU NALSU,					                                                                ");
		sql.append("	       A.DIVIDE DIVIDE,					                                                                ");
		sql.append("	       A.ORDER_SURYANG ORDER_SURYANG,	                                                                ");
		sql.append("	       A.SUBUL_SURYANG SUBUL_SURYANG,	                                                                ");
		sql.append("	       CASE								                                                                ");
		sql.append("	          WHEN A.NALSU < 0				                                                                ");
		sql.append("	          THEN							                                                                ");
		sql.append("	             CONCAT(					                                                                ");
		sql.append("	                '-',					                                                                ");
		sql.append("	                CASE					                                                                ");
		sql.append("	                   WHEN ROUND(A.ORD_SURYANG, 2) < 1														");
		sql.append("	                   THEN																					");
		sql.append("	                      CONCAT('0', ROUND(A.ORD_SURYANG, 2))												");
		sql.append("	                   ELSE																					");
		sql.append("	                      CONCAT('', ROUND(A.ORD_SURYANG, 2))												");
		sql.append("	                END)																					");
		sql.append("	          ELSE																							");
		sql.append("	             CONCAT(																					");
		sql.append("	                '',																						");
		sql.append("	                CASE																					");
		sql.append("	                   WHEN ROUND(A.ORD_SURYANG, 2) < 1														");
		sql.append("	                   THEN																					");
		sql.append("	                      CONCAT('0', ROUND(A.ORD_SURYANG, 2))												");
		sql.append("	                   ELSE																					");
		sql.append("	                      CONCAT('', ROUND(A.ORD_SURYANG, 2))												");
		sql.append("	                END)																					");
		sql.append("	       END ORD_SURYANG,																					");
		sql.append("	       A.ORDER_DANUI ORDER_DANUI,																		");
		sql.append("	       A.SUBUL_DANUI SUBUL_DANUI,																		");
		sql.append("	       A.BUNRYU1 BUNRYU1,                                                                               ");
		sql.append("	       A.BUNRYU2 BUNRYU2,                                                                               ");
		sql.append("	       A.BUNRYU3 BUNRYU3,                                                                               ");
		sql.append("	       A.BUNRYU4 BUNRYU4,                                                                               ");
		sql.append("	       TRIM(C.ORDER_REMARK) REMARK,			                                                            ");
		sql.append("	       A.DV_TIME DV_TIME,					                                                            ");
		sql.append("	       A.DV DV,								                                                            ");
		sql.append("	       A.BUNRYU6 BUNRYU6,					                                                            ");
		sql.append("	       A.MIX_GROUP MIX_GROUP,				                                                            ");
		sql.append("	       A.DV_1 DV_1,							                                                            ");
		sql.append("	       A.DV_2 DV_2,							                                                            ");
		sql.append("	       A.DV_3 DV_3,							                                                            ");
		sql.append("	       A.DV_4 DV_4,							                                                            ");
		sql.append("	       A.DV_5 DV_5,							                                                            ");
		sql.append("	       A.HUBAL_CHANGE_YN HUBAL_CHANGE_YN,	                                                            ");
		sql.append("	       A.PHARMACY PHARMACY,					                                                            ");
		sql.append("	       A.JUSA_SPD_GUBUN JUSA_SPD_GUBUN,		                                                            ");
		sql.append("	       A.DRG_PACK_YN DRG_PACK_YN,			                                                            ");
		sql.append("	       A.JUSA JUSA,							                                                            ");
		sql.append("	       B.HANGMOG_NAME JAERYO_NAME,			                                                            ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) DANUI_NAME,			");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language) SUBUL_DANUI_NAME,	");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('JUSA', IFNULL(A.JUSA, '0'), :f_hosp_code, :f_language) JUSA_NAME,			");
		sql.append("	       CONCAT(																							");
		sql.append("	          A.BOGYONG_CODE,																				");
		sql.append("	          ' ',																							");
		sql.append("	          FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',														");
		sql.append("	                                IFNULL(A.JUSA_SPD_GUBUN, '0'), :f_hosp_code, :f_language)) BOGYONG_NAME,");
		sql.append("	       FN_DRG_LOAD_JUSA_NALSU_CNT(:f_hosp_code, A.BUNHO,												");
		sql.append("	                                  A.ORDER_DATE,															");
		sql.append("	                                  A.JAERYO_CODE,					                                    ");
		sql.append("	                                  A.GROUP_SER,						                                    ");
		sql.append("	                                  A.HOPE_DATE,						                                    ");
		sql.append("	                                  'C') JUSA_NALSU,					                                    ");
		sql.append("	       'A' DATA_GUBUN,												                                    ");
		sql.append("	       IFNULL(D.ACT_JAERYO_NAME, B.HANGMOG_NAME) HODONG_ORD_NAME,	                                    ");
		sql.append("	       CONCAT(														                                    ");
		sql.append("	          LPAD(:f_serial_v, 4, '0000'),								                                    ");
		sql.append("	          LPAD(A.GROUP_SER, 4, '0000'),								                                    ");
		sql.append("	          IFNULL(A.MIX_GROUP, ' '),									                                    ");
		sql.append("	          LPAD(														                                    ");
		sql.append("	                CASE C.BOM_OCCUR_YN WHEN 'Y' THEN C.SEQ + 100 ELSE C.SEQ END, 4,						");
		sql.append("	                '0000'),																				");
		sql.append("	          LPAD(C.PKOCS2003, 10, '0000000000')) KEY_ORDER,												");
		sql.append("	       'Y' MAX_BANNAB_YN,																				");
		sql.append("	       A.BANNAB_YN BANNAB_YN,																			");
		sql.append("	       A.FKOCS2003 FKOCS2003																			");
		sql.append("	  FROM DRG3010 A																						");
		sql.append("	       LEFT OUTER JOIN INV0110 D																		");
		sql.append("	          ON A.HOSP_CODE = D.HOSP_CODE AND A.JAERYO_CODE = D.JAERYO_CODE,								");
		sql.append("	       OCS2003 C,																						");
		sql.append("	       OCS0103 B																						");
		sql.append("	 WHERE     A.HOSP_CODE = :f_hosp_code			                                                        ");
		sql.append("	       AND B.HOSP_CODE = C.HOSP_CODE			                                                        ");
		sql.append("	       AND B.HANGMOG_CODE = C.HANGMOG_CODE		                                                        ");
		sql.append("	       AND C.HOSP_CODE = A.HOSP_CODE			                                                        ");
		sql.append("	       AND C.PKOCS2003 = A.FKOCS2003			                                                        ");
		sql.append("	       AND C.ORDER_DATE BETWEEN B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31')						");
		sql.append("	       AND A.SOURCE_FKOCS2003 = :f_fkocs2003															");
		sql.append("	ORDER BY A.FKOCS2003																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_serial_v", serialV);
		query.setParameter("f_fkocs2003", CommonUtils.parseDouble(fkocs2003));
        
		List<DRG3010P10DsvJusaOrderPrint3Info> listInfo = new JpaResultMapper().list(query, DRG3010P10DsvJusaOrderPrint3Info.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10DsvJusaOrderPrint4Info> getDRG3010P10DsvJusaOrderPrint4Info(String hospCode, String jubsuDate,
			String drgBunho, String serialText) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.JAERYO_CODE JAERYO_CODE,													");
		sql.append("	       A.NALSU NALSU,					                                            ");
		sql.append("	       A.DIVIDE DIVIDE,					                                            ");
		sql.append("	       A.ORDER_SURYANG ORDER_SURYANG,	                                            ");
		sql.append("	       A.SUBUL_SURYANG SUBUL_SURYANG,	                                            ");
		sql.append("	       A.ORD_SURYANG ORD_SURYANG,		                                            ");
		sql.append("	       A.ORDER_DANUI ORDER_DANUI,		                                            ");
		sql.append("	       A.SUBUL_DANUI SUBUL_DANUI,		                                            ");
		sql.append("	       A.BUNRYU1 BUNRYU1,				                                            ");
		sql.append("	       A.BUNRYU2 BUNRYU2,				                                            ");
		sql.append("	       IFNULL(A.BUNRYU3, '') BUNRYU3,				                                ");
		sql.append("	       IFNULL(A.BUNRYU4, '') BUNRYU4,				                                ");
		sql.append("	       TRIM(C.ORDER_REMARK) REMARK,		                                            ");
		sql.append("	       A.DV_TIME DV_TIME,				                                            ");
		sql.append("	       A.DV DV,							                                            ");
		sql.append("	       IFNULL(A.BUNRYU6, '') BUNRYU6,				                                ");
		sql.append("	       A.MIX_GROUP MIX_GROUP,			                                            ");
		sql.append("	       A.DV_1 DV_1,						                                            ");
		sql.append("	       A.DV_2 DV_2,						                                            ");
		sql.append("	       A.DV_3 DV_3,						                                            ");
		sql.append("	       A.DV_4 DV_4,						                                            ");
		sql.append("	       A.DV_5 DV_5,						                                            ");
		sql.append("	       A.HUBAL_CHANGE_YN HUBAL_CHANGE_YN,                                           ");
		sql.append("	       A.PHARMACY PHARMACY,				                                            ");
		sql.append("	       A.JUSA_SPD_GUBUN JUSA_SPD_GUBUN,	                                            ");
		sql.append("	       A.DRG_PACK_YN DRG_PACK_YN,		                                            ");
		sql.append("	       A.JUSA JUSA,						                                            ");
		sql.append("	       B.HANGMOG_NAME JAERYO_NAME,		                                            ");
		sql.append("	       'B' DATA_GUBUN,					                                            ");
		sql.append("	       IFNULL(D.ACT_JAERYO_NAME, B.HANGMOG_NAME) HODONG_ORD_NAME,					");
		sql.append("	       CONCAT(																		");
		sql.append("	          LPAD(E.SERIAL_V, 4, '0000'),												");
		sql.append("	          LPAD(A.GROUP_SER, 4, '0000'),												");
		sql.append("	          IFNULL(A.MIX_GROUP, ' '),													");
		sql.append("	          LPAD(																		");
		sql.append("	                CASE C.BOM_OCCUR_YN WHEN 'Y' THEN C.SEQ + 100 ELSE C.SEQ END, 4,	");
		sql.append("	                '0000'),															");
		sql.append("	          LPAD(C.PKOCS2003, 10, '0000000000')) KEY_ORDER,							");
		sql.append("	       (SELECT MAX(IFNULL(X.BANNAB_YN, 'N'))	                                    ");
		sql.append("	          FROM DRG3010 X, DRG2035 Y				                                    ");
		sql.append("	         WHERE     Y.HOSP_CODE = :f_hosp_code	                                    ");
		sql.append("	               AND Y.JUBSU_DATE = E.JUBSU_DATE	                                    ");
		sql.append("	               AND Y.DRG_BUNHO = E.DRG_BUNHO	                                    ");
		sql.append("	               AND Y.SERIAL_V = E.SERIAL_V		                                    ");
		sql.append("	               AND X.HOSP_CODE = Y.HOSP_CODE	                                    ");
		sql.append("	               AND Y.FKOCS2003 = X.FKOCS2003) MAX_BANNAB_YN,						");
		sql.append("	       A.BANNAB_YN BANNAB_YN,														");
		sql.append("	       A.FKOCS2003 FKOCS2003														");
		sql.append("	  FROM DRG3010 A																	");
		sql.append("	       LEFT OUTER JOIN INV0110 D													");
		sql.append("	          ON A.HOSP_CODE = D.HOSP_CODE AND A.JAERYO_CODE = D.JAERYO_CODE,			");
		sql.append("	       DRG2035 E,																	");
		sql.append("	       OCS2003 C,																	");
		sql.append("	       OCS0103 B																	");
		sql.append("	 WHERE     A.HOSP_CODE = :f_hosp_code												");
		sql.append("	       AND A.BUNRYU1 IN ('4')														");
		sql.append("	       AND TRIM(C.ORDER_REMARK) IS NOT NULL											");
		sql.append("	       AND B.HOSP_CODE = C.HOSP_CODE												");
		sql.append("	       AND B.HANGMOG_CODE = C.HANGMOG_CODE											");
		sql.append("	       AND C.ORDER_DATE BETWEEN B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31')	");
		sql.append("	       AND E.HOSP_CODE = A.HOSP_CODE	                                            ");
		sql.append("	       AND E.JUBSU_DATE = A.JUBSU_DATE	                                            ");
		sql.append("	       AND E.DRG_BUNHO = A.DRG_BUNHO	                                            ");
		sql.append("	       AND C.HOSP_CODE = A.HOSP_CODE	                                            ");
		sql.append("	       AND C.PKOCS2003 = A.FKOCS2003	                                            ");
		sql.append("	       AND E.FKOCS2003 = A.FKOCS2003	                                            ");
		sql.append("	       AND A.JUBSU_DATE = :f_jubsu_date	                                            ");
		sql.append("	       AND A.DRG_BUNHO = :f_drg_bunho	                                            ");
		sql.append("	       AND E.SERIAL_V = :f_serial_text	                                            ");
		sql.append("	ORDER BY CONCAT(						                                            ");
		sql.append("	            LPAD(E.SERIAL_V, 4, '0000'),                                            ");
		sql.append("	            LPAD(A.GROUP_SER, 4, '0000'),		                                    ");
		sql.append("	            IFNULL(A.MIX_GROUP, ' '),			                                    ");
		sql.append("	            LPAD(								                                    ");
		sql.append("	                  CASE C.BOM_OCCUR_YN			                                    ");
		sql.append("	                     WHEN 'Y' THEN C.SEQ + 100	                                    ");
		sql.append("	                     ELSE C.SEQ					                                    ");
		sql.append("	                  END, 4, 						                                    ");
		sql.append("	                  '0000'),						                                    ");
		sql.append("	            LPAD(C.PKOCS2003, 10, '0000000000'))                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_drg_bunho", CommonUtils.parseDouble(drgBunho));
		query.setParameter("f_serial_text", serialText);
        
		List<DRG3010P10DsvJusaOrderPrint4Info> listInfo = new JpaResultMapper().list(query, DRG3010P10DsvJusaOrderPrint4Info.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10DsvJusaLabel1Info> getDRG3010P10DsvJusaLabel1Info(String hospCode, String language,
			String jubsuDate, String drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BUNHO BUNHO,																				");
		sql.append("	       LTRIM(A.DRG_BUNHO) DRG_BUNHO,																");
		sql.append("	       FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, :f_hosp_code, :f_language) ORDER_DATE_TEXT,	");
		sql.append("	       DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d') JUBSU_DATE,											");
		sql.append("	       DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d') HOPE_DATE,												");
		sql.append("	       DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d') ORDER_DATE,											");
		sql.append("	       CONCAT('Rp.', E.SERIAL_V, CASE A.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END) SERIAL_V,		");
		sql.append("	       E.SERIAL_V SERIAL_TEXT,																		");
		sql.append("	       D.SUNAME SUNAME,																				");
		sql.append("	       D.SUNAME2 SUNAME2,																			");
		sql.append("	       FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, :f_hosp_code) SEX_AGE,							");
		sql.append("	       SUBSTR(																						");
		sql.append("	          FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001,									");
		sql.append("	                         SWF_TruncDate(CURRENT_TIMESTAMP, 'DD'),									");
		sql.append("	                         'C'),																		");
		sql.append("	          1,																						");
		sql.append("	          20)																						");
		sql.append("	          HO_CODE,																					");
		sql.append("	       SUBSTR(																						");
		sql.append("	          FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001,									");
		sql.append("	                         SWF_TruncDate(CURRENT_TIMESTAMP, 'DD'),									");
		sql.append("	                         'D'),																		");
		sql.append("	          1,										                                                ");
		sql.append("	          20)										                                                ");
		sql.append("	          HO_DONG,									                                                ");
		sql.append("	       MAX(											                                                ");
		sql.append("	          CONCAT(									                                                ");
		sql.append("	             A.BOGYONG_CODE,						                                                ");
		sql.append("	             ' ',									                                                ");
		sql.append("	             FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',                                                ");
		sql.append("	                                   IFNULL(A.JUSA_SPD_GUBUN, '0'), :f_hosp_code, :f_language)))		");
		sql.append("	          BOGYONG_NAME,																				");
		sql.append("	       MAX(A.DV) CNT																				");
		sql.append("	  FROM DRG3010 A																					");
		sql.append("	       LEFT OUTER JOIN INV0110 B																	");
		sql.append("	          ON B.HOSP_CODE = A.HOSP_CODE AND B.JAERYO_CODE = A.JAERYO_CODE							");
		sql.append("	       LEFT OUTER JOIN DRG0120 C																	");
		sql.append("	          ON C.HOSP_CODE = A.HOSP_CODE AND C.BOGYONG_CODE = A.BOGYONG_CODE,							");
		sql.append("	       DRG2035 E,							                                                        ");
		sql.append("	       OUT0101 D							                                                        ");
		sql.append("	 WHERE     A.HOSP_CODE = :f_hosp_code		                                                        ");
		sql.append("	       AND A.BUNRYU1 = '4'					                                                        ");
		sql.append("	       AND IFNULL(A.DC_YN, 'N') = 'N'		                                                        ");
		sql.append("	       AND IFNULL(A.BANNAB_YN, 'N') = 'N'	                                                        ");
		sql.append("	       AND D.HOSP_CODE = A.HOSP_CODE		                                                        ");
		sql.append("	       AND D.BUNHO = A.BUNHO				                                                        ");
		sql.append("	       AND E.HOSP_CODE = A.HOSP_CODE		                                                        ");
		sql.append("	       AND E.JUBSU_DATE = A.JUBSU_DATE		                                                        ");
		sql.append("	       AND E.DRG_BUNHO = A.DRG_BUNHO		                                                        ");
		sql.append("	       AND E.FKOCS2003 = A.FKOCS2003		                                                        ");
		sql.append("	       AND A.JUBSU_DATE = :f_jubsu_date		                                                        ");
		sql.append("	       AND A.DRG_BUNHO = :f_drg_bunho		                                                        ");
		sql.append("	GROUP BY A.BUNHO,							                                                        ");
		sql.append("	         LTRIM(A.DRG_BUNHO),				                                                        ");
		sql.append("	         FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, :f_hosp_code, :f_language),				");
		sql.append("	         A.JUBSU_DATE,		                                                                        ");
		sql.append("	         A.HOPE_DATE,		                                                                        ");
		sql.append("	         A.ORDER_DATE,		                                                                        ");
		sql.append("	         CONCAT('Rp.',		                                                                        ");
		sql.append("	                E.SERIAL_V,	                                                                        ");
		sql.append("	                CASE A.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END),	                                ");
		sql.append("	         E.SERIAL_V,												                                ");
		sql.append("	         D.SUNAME,													                                ");
		sql.append("	         D.SUNAME2,													                                ");
		sql.append("	         FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, :f_hosp_code),	                                ");
		sql.append("	         SUBSTR(													                                ");
		sql.append("	            FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001,	                                ");
		sql.append("	                           SWF_TruncDate(CURRENT_TIMESTAMP, 'DD'),	                                ");
		sql.append("	                           'C'),									                                ");
		sql.append("	            1,														                                ");
		sql.append("	            20),													                                ");
		sql.append("	         SUBSTR(													                                ");
		sql.append("	            FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001,	                                ");
		sql.append("	                           SWF_TruncDate(CURRENT_TIMESTAMP, 'DD'),	                                ");
		sql.append("	                           'D'),									                                ");
		sql.append("	            1,														                                ");
		sql.append("	            20)														                                ");
		sql.append("	ORDER BY LPAD(E.SERIAL_V, 4, '0000')								                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_drg_bunho", CommonUtils.parseDouble(drgBunho));
        
		List<DRG3010P10DsvJusaLabel1Info> listInfo = new JpaResultMapper().list(query, DRG3010P10DsvJusaLabel1Info.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10DsvJusaLabel2Info> getDRG3010P10DsvJusaLabel2Info(String hospCode, String language, String k,
			String cnt, String jubsuDate, String drgBunho, String serialText, boolean is2) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.JAERYO_CODE JAERYO_CODE,																		");
		sql.append("	       A.NALSU NALSU,					                                                                ");
		sql.append("	       A.DIVIDE DIVIDE,					                                                                ");
		sql.append("	       A.ORDER_SURYANG ORDER_SURYANG,	                                                                ");
		sql.append("	       A.SUBUL_SURYANG SUBUL_SURYANG,	                                                                ");
		sql.append("	       A.ORD_SURYANG ORD_SURYANG,		                                                                ");
		sql.append("	       A.ORDER_DANUI ORDER_DANUI,		                                                                ");
		sql.append("	       A.SUBUL_DANUI SUBUL_DANUI,		                                                                ");
		sql.append("	       A.BUNRYU1 BUNRYU1,				                                                                ");
		sql.append("	       A.BUNRYU2 BUNRYU2,				                                                                ");
		sql.append("	       IFNULL(A.BUNRYU3, '') BUNRYU3,				                                                    ");
		sql.append("	       IFNULL(A.BUNRYU4, '') BUNRYU4,				                                                    ");
		sql.append("	       A.REMARK REMARK,					                                                                ");
		sql.append("	       A.DV_TIME DV_TIME,				                                                                ");
		sql.append("	       A.DV DV,							                                                                ");
		sql.append("	       IFNULL(A.BUNRYU6, '') BUNRYU6,				                                                    ");
		sql.append("	       A.MIX_GROUP MIX_GROUP,			                                                                ");
		sql.append("	       A.DV_1 DV_1,                                                                                     ");
		sql.append("	       A.DV_2 DV_2,                                                                                     ");
		sql.append("	       A.DV_3 DV_3,                                                                                     ");
		sql.append("	       A.DV_4 DV_4,                                                                                     ");
		sql.append("	       A.DV_5 DV_5,                                                                                     ");
		sql.append("	       A.HUBAL_CHANGE_YN HUBAL_CHANGE_YN,																");
		sql.append("	       A.PHARMACY PHARMACY,																				");
		sql.append("	       A.JUSA_SPD_GUBUN JUSA_SPD_GUBUN,																	");
		sql.append("	       A.DRG_PACK_YN DRG_PACK_YN,																		");
		sql.append("	       A.JUSA JUSA,																						");
		sql.append("	       B.HANGMOG_NAME JAERYO_NAME,																		");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) DANUI_NAME,			");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language) SUBUL_DANUI_NAME,	");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('JUSA', IFNULL(A.JUSA, '0'), :f_hosp_code, :f_language) JUSA_NAME,			");
		sql.append("	       CONCAT(:k, '/', :f_cnt) RP2,																		");
		sql.append("	       CONCAT('*',																						");
		sql.append("	              DATE_FORMAT(A.JUBSU_DATE, '%Y%m%d'),														");
		sql.append("	              A.DRG_BUNHO,																				");
		sql.append("	              E.SERIAL_V,																				");
		sql.append("	              :k,							                                                            ");
		sql.append("	              '*')							                                                            ");
		sql.append("	          BARCODE_NO,						                                                            ");
		if (is2)
			sql.append("	       'A' DATA_GUBUN						                                                            ");
		else 
			sql.append("	       'B' DATA_GUBUN						                                                            ");
		sql.append("	  FROM DRG2035 E,                                                                                       ");
		sql.append("	       OCS2003 C,                                                                                       ");
		sql.append("	       OCS0103 B,                                                                                       ");
		sql.append("	       DRG3010 A							                                                            ");
		sql.append("	 WHERE     A.HOSP_CODE = :f_hosp_code		                                                            ");
		sql.append("	       AND A.BUNRYU1 IN ('4')				                                                            ");
		sql.append("	       AND IFNULL(A.DC_YN, 'N') = 'N'		                                                            ");
		sql.append("	       AND IFNULL(A.BANNAB_YN, 'N') = 'N'	                                                            ");
		sql.append("	       AND B.HOSP_CODE = C.HOSP_CODE		                                                            ");
		sql.append("	       AND B.HANGMOG_CODE = C.HANGMOG_CODE	                                                            ");
		sql.append("	       AND C.HOSP_CODE = A.HOSP_CODE		                                                            ");
		sql.append("	       AND C.PKOCS2003 = A.FKOCS2003		                                                            ");
		sql.append("	       AND E.HOSP_CODE = A.HOSP_CODE		                                                            ");
		sql.append("	       AND E.JUBSU_DATE = A.JUBSU_DATE		                                                            ");
		sql.append("	       AND E.DRG_BUNHO = A.DRG_BUNHO		                                                            ");
		sql.append("	       AND E.FKOCS2003 = A.FKOCS2003		                                                            ");
		sql.append("	       AND C.ORDER_DATE BETWEEN B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31')						");
		sql.append("	       AND A.JUBSU_DATE = :f_jubsu_date																	");
		sql.append("	       AND A.DRG_BUNHO = :f_drg_bunho																	");
		sql.append("	       AND E.SERIAL_V = :f_serial_text																	");
		sql.append("	       AND A.DIVIDE >= :k																				");
		sql.append("	ORDER BY CONCAT(																						");
		sql.append("	            LPAD(E.SERIAL_V, 4, '0000'),		                                                        ");
		sql.append("	            LPAD(A.GROUP_SER, 4, '0000'),		                                                        ");
		sql.append("	            IFNULL(A.MIX_GROUP, ' '),			                                                        ");
		sql.append("	            LPAD(								                                                        ");
		sql.append("	                  CASE C.BOM_OCCUR_YN			                                                        ");
		sql.append("	                     WHEN 'Y' THEN C.SEQ + 100	                                                        ");
		sql.append("	                     ELSE C.SEQ					                                                        ");
		sql.append("	                  END, 4,						                                                        ");
		sql.append("	                  '0000'),						                                                        ");
		sql.append("	            LPAD(C.PKOCS2003, 10, '0000000000'))                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("k", k);
		query.setParameter("f_cnt", cnt);
		query.setParameter("f_jubsu_date", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_drg_bunho", CommonUtils.parseDouble(drgBunho));
		query.setParameter("f_serial_text", serialText);
        
		List<DRG3010P10DsvJusaLabel2Info> listInfo = new JpaResultMapper().list(query, DRG3010P10DsvJusaLabel2Info.class);
		return listInfo;
	}
	
	@Override
	public List<DRG3010P99JusaSerialInfo> getDRG3010P99JusaSerialInfo(String hospCode, String language, String jubsuDate, String serialText, Double drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT A.JAERYO_CODE                                        JAERYO_CODE                                                             ");
		sql.append("           ,CAST(A.NALSU AS CHAR)                                NALSU                                                                   ");
		sql.append("           ,A.DIVIDE                                             DIVIDE                                                                  ");
		sql.append("           ,CAST(A.ORDER_SURYANG AS CHAR)                        ORDER_SURYANG                                                           ");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                        SUBUL_SURYANG                                                           ");
		sql.append("           ,CAST(A.ORD_SURYANG AS CHAR)                          ORD_SURYANG                                                             ");
		sql.append("           ,A.ORDER_DANUI                                        ORDER_DANUI                                                             ");
		sql.append("           ,A.SUBUL_DANUI                                        SUBUL_DANUI                                                             ");
		sql.append("           ,IFNULL(A.BUNRYU1, '')                                BUNRYU1                                                                 ");
		sql.append("           ,IFNULL(A.BUNRYU2, '')                                BUNRYU2                                                                 ");
		sql.append("           ,IFNULL(A.BUNRYU3, '')                                BUNRYU3                                                                 ");
		sql.append("           ,IFNULL(A.BUNRYU4, '')                                BUNRYU4                                                                 ");
		sql.append("           ,IFNULL(TRIM(C.ORDER_REMARK), '')                     REMARK                                                                  ");
		sql.append("           ,CAST(A.DV_TIME AS CHAR)                              DV_TIME                                                                 ");
		sql.append("           ,CAST(A.DV AS CHAR)                                   DV                                                                      ");
		sql.append("           ,IFNULL(A.BUNRYU6, '')                                BUNRYU6                                                                 ");
		sql.append("           ,IFNULL(A.MIX_GROUP, '')                              MIX_GROUP                                                               ");
		sql.append("           ,IFNULL(A.DV_1, '')                                   DV_1                                                                    ");
		sql.append("           ,IFNULL(A.DV_2, '')                                   DV_2                                                                    ");
		sql.append("           ,IFNULL(A.DV_3, '')                                   DV_3                                                                    ");
		sql.append("           ,IFNULL(A.DV_4, '')                                   DV_4                                                                    ");
		sql.append("           ,IFNULL(A.DV_5, '')                                   DV_5                                                                    ");
		sql.append("           ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN                                                         ");
		sql.append("           ,A.PHARMACY                                           PHARMACY                                                                ");
		sql.append("           ,IFNULL(A.JUSA_SPD_GUBUN, '')                         JUSA_SPD_GUBUN                                                          ");
		sql.append("           ,A.DRG_PACK_YN                                        DRG_PACK_YN                                                             ");
		sql.append("           ,IFNULL(A.JUSA, '')                                   JUSA                                                                    ");
		sql.append("           ,B.HANGMOG_NAME                                       JAERYO_NAME                                                             ");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language)    DANUI_NAME                                    ");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, A.HOSP_CODE, :f_language)    SUBUL_DANUI_NAME                              ");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0') , A.HOSP_CODE, :f_language)        JUSA_NAME                                 ");
		sql.append("           ,IFNULL(CONCAT(A.BOGYONG_CODE, ' ',FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', CASE(A.JUSA_SPD_GUBUN)                             ");
		sql.append("                 WHEN '' THEN '0' ELSE IFNULL(A.JUSA_SPD_GUBUN,'0') END, A.HOSP_CODE, :f_language)),'')     BOGYONG_NAME                 ");
		sql.append("           ,FN_DRG_LOAD_JUSA_NALSU_CNT(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, A.JAERYO_CODE, A.GROUP_SER, A.HOPE_DATE, 'C')  JUSA_NALSU     ");
		sql.append("           ,'A'                                                                                            DATA_GUBUN                    ");
		sql.append("           ,CASE(D.ACT_JAERYO_NAME) WHEN '' THEN B.HANGMOG_NAME ELSE IFNULL(D.ACT_JAERYO_NAME, B.HANGMOG_NAME) END  HODONG_ORD_NAME      ");
		sql.append("           ,CONCAT(LTRIM(LPAD(E.SERIAL_V, 4,'0')), LTRIM(LPAD(A.GROUP_SER, 4,'0')), CASE(A.MIX_GROUP)                                    ");
		sql.append("                     WHEN '' THEN ' ' ELSE IFNULL(A.MIX_GROUP, ' ') END,                                                                 ");
		sql.append("            LTRIM(LPAD(CASE(C.BOM_OCCUR_YN) WHEN 'Y' THEN C.SEQ + 100 ELSE C.SEQ END, 4, '0')),                                          ");
		sql.append("            LTRIM(LPAD(C.PKOCS2003, 10, '0')))            KE                                                                             ");
		sql.append("           ,(SELECT MAX(CASE(X.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(X.BANNAB_YN, 'N') END)                                            ");
		sql.append("               FROM DRG3010 X                                                                                                            ");
		sql.append("               JOIN DRG2035 Z                                                                                                            ");
		sql.append("                 ON Z.HOSP_CODE        = X.HOSP_CODE                                                                                     ");
		sql.append("                AND Z.JUBSU_DATE       = X.JUBSU_DATE                                                                                    ");
		sql.append("                AND Z.DRG_BUNHO        = X.DRG_BUNHO                                                                                     ");
		sql.append("                AND Z.FKOCS2003        = X.FKOCS2003                                                                                     ");
		sql.append("                AND Z.SERIAL_V         = :f_serial_text                                                                                  ");
		sql.append("              WHERE X.HOSP_CODE        = :f_hosp_code                                                                                    ");
		sql.append("                AND X.JUBSU_DATE       = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                                                          ");
		sql.append("                  )                                              MAX_BANNAB_YN                                                           ");
		sql.append("           ,A.BANNAB_YN                                          BANNAB_YN                                                               ");
		sql.append("           ,A.FKOCS2003                                          FKOCS2003                                                               ");
		sql.append("       FROM DRG3010 A                                                                                                                    ");
		sql.append("       JOIN OCS2003 C                                                                                                                    ");
		sql.append("         ON C.PKOCS2003          = A.FKOCS2003                                                                                           ");
		sql.append("        AND C.HOSP_CODE          = A.HOSP_CODE                                                                                           ");
		sql.append("       JOIN OCS0103 B                                                                                                                    ");
		sql.append("         ON B.HANGMOG_CODE       = C.HANGMOG_CODE                                                                                        ");
		sql.append("        AND B.HOSP_CODE          = C.HOSP_CODE                                                                                           ");
		sql.append("       LEFT JOIN INV0110 D                                                                                                               ");
		sql.append("         ON D.JAERYO_CODE        = A.JAERYO_CODE                                                                                         ");
		sql.append("        AND D.HOSP_CODE          = A.HOSP_CODE                                                                                           ");
		sql.append("       JOIN DRG2035 E                                                                                                                    ");
		sql.append("         ON E.JUBSU_DATE         = A.JUBSU_DATE                                                                                          ");
		sql.append("        AND E.DRG_BUNHO          = A.DRG_BUNHO                                                                                           ");
		sql.append("        AND E.HOSP_CODE          = A.HOSP_CODE                                                                                           ");
		sql.append("        AND E.FKOCS2003          = A.FKOCS2003                                                                                           ");
		sql.append("        AND E.SERIAL_V           = :f_serial_text                                                                                        ");
		sql.append("      WHERE A.HOSP_CODE          = :f_hosp_code                                                                                          ");
		sql.append("       AND A.JUBSU_DATE         = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                                                                 ");
		sql.append("       AND A.DRG_BUNHO          = :f_drg_bunho                                                                                           ");
		sql.append("        AND A.BUNRYU1            IN ('4')                                                                                                ");
		sql.append("        AND C.ORDER_DATE         BETWEEN   B.START_DATE AND CASE (B.END_DATE) WHEN '' THEN STR_TO_DATE('9998/12/31','%Y/%m/%d')          ");
		sql.append("                                         ELSE IFNULL(B.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')) END                               ");
		sql.append("      ORDER BY CONCAT(LTRIM(LPAD(E.SERIAL_V, 4,'0')), LTRIM(LPAD(A.GROUP_SER, 4,'0')),                                                   ");
		sql.append("            CASE(A.MIX_GROUP) WHEN '' THEN ' ' ELSE IFNULL(A.MIX_GROUP, ' ') END,                                                        ");
		sql.append("            LTRIM(LPAD(CASE(C.BOM_OCCUR_YN) WHEN 'Y' THEN C.SEQ + 100 ELSE C.SEQ END, 4, '0')),                                          ");
		sql.append("            LTRIM(LPAD(C.PKOCS2003, 10, '0')))                                                                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_serial_text", serialText);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_jubsu_date", jubsuDate);
		
		List<DRG3010P99JusaSerialInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99JusaSerialInfo.class);
		return listInfo;
	}
	
	@Override
	public List<DRG3010P99JusaSerialInfo> getDRG3010P99JusaserialvInfo(String hospCode, String language, String serialV, Double fkocs2003){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT A.JAERYO_CODE                                        JAERYO_CODE                                                               ");
		sql.append("           ,CAST(A.NALSU AS CHAR)                                NALSU                                                                     ");
		sql.append("           ,A.DIVIDE                                             DIVIDE                                                                    ");
		sql.append("           ,CAST(A.ORDER_SURYANG AS CHAR)                        ORDER_SURYANG                                                             ");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                        SUBUL_SURYANG                                                             ");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                        ORD_SURYANG                                                               ");
		sql.append("           ,A.ORDER_DANUI                                        ORDER_DANUI                                                               ");
		sql.append("           ,A.SUBUL_DANUI                                        SUBUL_DANUI                                                               ");
		sql.append("           ,IFNULL(A.BUNRYU1, '')                                BUNRYU1                                                                   ");
		sql.append("           ,IFNULL(A.BUNRYU2, '')                                BUNRYU2                                                                   ");
		sql.append("           ,IFNULL(A.BUNRYU3, '')                                BUNRYU3                                                                   ");
		sql.append("           ,IFNULL(A.BUNRYU4, '')                                BUNRYU4                                                                   ");
		sql.append("           ,IFNULL(TRIM(C.ORDER_REMARK), '')                     REMARK                                                                    ");
		sql.append("           ,A.DV_TIME                                            DV_TIME                                                                   ");
		sql.append("           ,A.DV                                                 DV                                                                        ");
		sql.append("           ,IFNULL(A.BUNRYU6, '')                                BUNRYU6                                                                   ");
		sql.append("           ,IFNULL(A.MIX_GROUP, '')                              MIX_GROUP                                                                 ");
		sql.append("           ,IFNULL(A.DV_1, '')                                   DV_1                                                                      ");
		sql.append("           ,IFNULL(A.DV_2, '')                                   DV_2                                                                      ");
		sql.append("           ,IFNULL(A.DV_3, '')                                   DV_3                                                                      ");
		sql.append("           ,IFNULL(A.DV_4, '')                                   DV_4                                                                      ");
		sql.append("           ,IFNULL(A.DV_5, '')                                   DV_5                                                                      ");
		sql.append("           ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN                                                           ");
		sql.append("           ,A.PHARMACY                                           PHARMACY                                                                  ");
		sql.append("           ,IFNULL(A.JUSA_SPD_GUBUN, '')                         JUSA_SPD_GUBUN                                                            ");
		sql.append("           ,A.DRG_PACK_YN                                        DRG_PACK_YN                                                               ");
		sql.append("           ,IFNULL(A.JUSA, '')                                   JUSA                                                                      ");
		sql.append("           ,B.HANGMOG_NAME                                       JAERYO_NAME                                                               ");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language)    DANUI_NAME                                      ");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, A.HOSP_CODE, :f_language)    SUBUL_DANUI_NAME                                ");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0') , A.HOSP_CODE, :f_language)        JUSA_NAME                                   ");
		sql.append("           ,IFNULL(CONCAT(A.BOGYONG_CODE, ' ',FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', CASE(A.JUSA_SPD_GUBUN)                               ");
		sql.append("                 WHEN '' THEN '0' ELSE IFNULL(A.JUSA_SPD_GUBUN,'0') END, A.HOSP_CODE, :f_language)),'')     BOGYONG_NAME                   ");
		sql.append("           ,FN_DRG_LOAD_JUSA_NALSU_CNT(A.HOSP_CODE, A.BUNHO, A.ORDER_DATE, A.JAERYO_CODE, A.GROUP_SER, A.HOPE_DATE, 'C')  JUSA_NALSU       ");
		sql.append("           ,'A'                                                                                            DATA_GUBUN                      ");
		sql.append("           ,CASE(D.ACT_JAERYO_NAME) WHEN '' THEN B.HANGMOG_NAME ELSE IFNULL(D.ACT_JAERYO_NAME, B.HANGMOG_NAME) END  HODONG_ORD_NAME        ");
		sql.append("           ,CONCAT(LTRIM(LPAD(:f_serial_v, 4,'0')), LTRIM(LPAD(A.GROUP_SER, 4,'0')), CASE(A.MIX_GROUP)                                     ");
		sql.append("                     WHEN '' THEN ' ' ELSE IFNULL(A.MIX_GROUP, ' ') END,                                                                   ");
		sql.append("            LTRIM(LPAD(CASE(C.BOM_OCCUR_YN) WHEN 'Y' THEN C.SEQ + 100 ELSE C.SEQ END, 4, '0')),                                            ");
		sql.append("            LTRIM(LPAD(C.PKOCS2003, 10, '0')))            KE                                                                               ");
		sql.append("           ,'Y'                                                 MAX_BANNAB_YN                                                              ");
		sql.append("           ,A.BANNAB_YN                                          BANNAB_YN                                                                 ");
		sql.append("           ,A.FKOCS2003                                          FKOCS2003                                                                 ");
		sql.append("       FROM DRG3010 A                                                                                                                      ");
		sql.append("       JOIN OCS2003 C                                                                                                                      ");
		sql.append("         ON C.HOSP_CODE          = A.HOSP_CODE                                                                                             ");
		sql.append("        AND C.PKOCS2003          = A.FKOCS2003                                                                                             ");
		sql.append("       JOIN OCS0103 B                                                                                                                      ");
		sql.append("         ON B.HOSP_CODE          = A.HOSP_CODE                                                                                             ");
		sql.append("        AND B.HANGMOG_CODE       = C.HANGMOG_CODE                                                                                          ");
		sql.append("       LEFT JOIN INV0110 D                                                                                                                 ");
		sql.append("         ON D.HOSP_CODE          = A.HOSP_CODE                                                                                             ");
		sql.append("        AND D.JAERYO_CODE        = A.JAERYO_CODE                                                                                           ");
		sql.append("      WHERE A.HOSP_CODE          = :f_hosp_code                                                                                            ");
		sql.append("        AND A.SOURCE_FKOCS2003   = :f_fkocs2003                                                                                            ");
		sql.append("        AND A.BUNRYU1            IN ('4')                                                                                                  ");
		sql.append("        AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN,'N') END = 'Y'                                                      ");
		sql.append("        AND C.ORDER_DATE       BETWEEN   B.START_DATE AND CASE (B.END_DATE) WHEN '' THEN STR_TO_DATE('9998/12/31','%Y/%m/%d')              ");
		sql.append("                                                           ELSE IFNULL(B.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')) END               ");
		sql.append("      ORDER BY A.FKOCS2003                                                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_serial_v", serialV);
		query.setParameter("f_fkocs2003", fkocs2003);
		
		List<DRG3010P99JusaSerialInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99JusaSerialInfo.class);
		return listInfo;
	}
	
	@Override
	public List<DRG3010P99SerRemarkInfo> getDRG3010P99SerRemarkInfo(String hospCode, String jubsuDate, Double drgBunho, String serialText){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT A.JAERYO_CODE                                        JAERYO_CODE                                                             ");
		sql.append("           ,CAST(A.NALSU AS CHAR)                                NALSU                                                                   ");
		sql.append("           ,A.DIVIDE                                             DIVIDE                                                                  ");
		sql.append("           ,CAST(A.ORDER_SURYANG AS CHAR)                        ORDER_SURYANG                                                           ");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                        SUBUL_SURYANG                                                           ");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                        ORD_SURYANG                                                             ");
		sql.append("           ,A.ORDER_DANUI                                        ORDER_DANUI                                                             ");
		sql.append("           ,A.SUBUL_DANUI                                        SUBUL_DANUI                                                             ");
		sql.append("           ,IFNULL(A.BUNRYU1, '')                                BUNRYU1                                                                 ");
		sql.append("           ,IFNULL(A.BUNRYU2, '')                                BUNRYU2                                                                 ");
		sql.append("           ,IFNULL(A.BUNRYU3, '')                                BUNRYU3                                                                 ");
		sql.append("           ,IFNULL(A.BUNRYU4, '')                                BUNRYU4                                                                 ");
		sql.append("           ,IFNULL(TRIM(C.ORDER_REMARK), '')                     REMARK                                                                  ");
		sql.append("           ,A.DV_TIME                                            DV_TIME                                                                 ");
		sql.append("           ,CAST(A.DV AS CHAR)                                   DV                                                                      ");
		sql.append("           ,IFNULL(A.BUNRYU6, '')                                BUNRYU6                                                                 ");
		sql.append("           ,IFNULL(A.MIX_GROUP, '')                              MIX_GROUP                                                               ");
		sql.append("           ,IFNULL(A.DV_1, '')                                   DV_1                                                                    ");
		sql.append("           ,IFNULL(A.DV_2, '')                                   DV_2                                                                    ");
		sql.append("           ,IFNULL(A.DV_3, '')                                   DV_3                                                                    ");
		sql.append("           ,IFNULL(A.DV_4, '')                                   DV_4                                                                    ");
		sql.append("           ,IFNULL(A.DV_5, '')                                   DV_5                                                                    ");
		sql.append("           ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN                                                         ");
		sql.append("           ,A.PHARMACY                                           PHARMACY                                                                ");
		sql.append("           ,IFNULL(A.JUSA_SPD_GUBUN, '')                         JUSA_SPD_GUBUN                                                          ");
		sql.append("           ,A.DRG_PACK_YN                                        DRG_PACK_YN                                                             ");
		sql.append("           ,IFNULL(A.JUSA, '')                                   JUSA                                                                    ");
		sql.append("           ,B.HANGMOG_NAME                                       JAERYO_NAME                                                             ");
		sql.append("           ,'B'                                                  DATA_GUBUN                                                              ");
		sql.append("           ,CASE(D.ACT_JAERYO_NAME) WHEN '' THEN B.HANGMOG_NAME ELSE IFNULL(D.ACT_JAERYO_NAME, B.HANGMOG_NAME) END  HODONG_ORD_NAME      ");
		sql.append("           ,CONCAT(LTRIM(LPAD(E.SERIAL_V, 4,'0')), LTRIM(LPAD(A.GROUP_SER, 4,'0')), CASE(A.MIX_GROUP)                                    ");
		sql.append("                     WHEN '' THEN ' ' ELSE IFNULL(A.MIX_GROUP, ' ') END,                                                                 ");
		sql.append("            LTRIM(LPAD(CASE(C.BOM_OCCUR_YN) WHEN 'Y' THEN C.SEQ + 100 ELSE C.SEQ END, 4, '0')),                                          ");
		sql.append("            LTRIM(LPAD(C.PKOCS2003, 10, '0')))            KE                                                                             ");
		sql.append("       FROM DRG3010 A                                                                                                                    ");
		sql.append("       JOIN OCS2003 C                                                                                                                    ");
		sql.append("         ON C.HOSP_CODE          = A.HOSP_CODE                                                                                           ");
		sql.append("        AND C.PKOCS2003          = A.FKOCS2003                                                                                           ");
		sql.append("       JOIN OCS0103 B                                                                                                                    ");
		sql.append("         ON B.HOSP_CODE          = A.HOSP_CODE                                                                                           ");
		sql.append("        AND B.HANGMOG_CODE       = C.HANGMOG_CODE                                                                                        ");
		sql.append("       LEFT JOIN INV0110 D                                                                                                               ");
		sql.append("         ON D.HOSP_CODE          = A.HOSP_CODE                                                                                           ");
		sql.append("        AND D.JAERYO_CODE        = A.JAERYO_CODE                                                                                         ");
		sql.append("       JOIN DRG2035 E                                                                                                                    ");
		sql.append("         ON E.JUBSU_DATE         = A.JUBSU_DATE                                                                                          ");
		sql.append("        AND E.DRG_BUNHO          = A.DRG_BUNHO                                                                                           ");
		sql.append("        AND E.HOSP_CODE          = A.HOSP_CODE                                                                                           ");
		sql.append("        AND E.FKOCS2003          = A.FKOCS2003                                                                                           ");
		sql.append("        AND E.SERIAL_V           = :f_serial_text                                                                                        ");
		sql.append("      WHERE A.HOSP_CODE          = :f_hosp_code                                                                                          ");
		sql.append("        AND A.JUBSU_DATE         = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                                                                ");
		sql.append("        AND A.DRG_BUNHO          = :f_drg_bunho                                                                                          ");
		sql.append("        AND A.BUNRYU1            IN ('4')                                                                                                ");
		sql.append("        AND TRIM(C.ORDER_REMARK) IS NOT NULL AND TRIM(C.ORDER_REMARK) <> ''                                                              ");
		sql.append("        AND C.ORDER_DATE       BETWEEN   B.START_DATE AND CASE (B.END_DATE) WHEN '' THEN STR_TO_DATE('9998/12/31','%Y/%m/%d')            ");
		sql.append("                                                           ELSE IFNULL(B.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')) END             ");
		sql.append("      ORDER BY CONCAT(LTRIM(LPAD(E.SERIAL_V, 4,'0')), LTRIM(LPAD(A.GROUP_SER, 4,'0')), CASE(A.MIX_GROUP)                                 ");
		sql.append("                     WHEN '' THEN ' ' ELSE IFNULL(A.MIX_GROUP, ' ') END,                                                                 ");
		sql.append("            LTRIM(LPAD(CASE(C.BOM_OCCUR_YN) WHEN 'Y' THEN C.SEQ + 100 ELSE C.SEQ END, 4, '0')),                                          ");
		sql.append("            LTRIM(LPAD(C.PKOCS2003, 10, '0')))                                                                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_serial_text", serialText);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DRG3010P99SerRemarkInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99SerRemarkInfo.class);
		return listInfo;
	}
	
	@Override
	public List<DRG3010P99JusaLabelInfo> getDRG3010P99JusaLabelInfo(String hospCode, String language, String jubsuDate, Double drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT A.BUNHO                                             BUNHO                                                            ");
		sql.append("           ,LTRIM(CAST(A.DRG_BUNHO AS CHAR))                         DRG_BUNHO                                                   ");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, A.HOSP_CODE, :f_language )    ORDER_DATE_TEXT                        ");
		sql.append("           ,DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d')                  JUBSU_DATE                                                     ");
		sql.append("           ,DATE_FORMAT(A.HOPE_DATE,'%Y/%m/%d')                   HOPE_DATE                                                      ");
		sql.append("           ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                  ORDER_DATE                                                     ");
		sql.append("           ,CONCAT('Rp.',E.SERIAL_V, CASE IFNULL(A.MIX_GROUP, '') WHEN '' THEN '' ELSE ' M' END)  SERIAL_V                       ");
		sql.append("           ,E.SERIAL_V                                          SERIAL_TEXT                                                      ");
		sql.append("           ,D.SUNAME                                            SUNAME                                                           ");
		sql.append("           ,D.SUNAME2                                           SUNAME2                                                          ");
		sql.append("           ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, A.HOSP_CODE)          SEX_AGE                                             ");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'') HO_DONG           ");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'') HO_CODE           ");
		sql.append("           ,IFNULL(CONCAT(A.BOGYONG_CODE, ' ',FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', CASE(A.JUSA_SPD_GUBUN)                     ");
		sql.append("                   WHEN '' THEN '0' ELSE IFNULL(A.JUSA_SPD_GUBUN,'0') END, A.HOSP_CODE, :f_language)),'')     BOGYONG_NAME       ");
		sql.append("           ,CAST(MAX(A.DV) AS CHAR)                                           CNT                                                ");
		sql.append("       FROM DRG3010 A                                                                                                            ");
		sql.append("       LEFT JOIN INV0110 B                                                                                                       ");
		sql.append("         ON B.JAERYO_CODE        = A.JAERYO_CODE                                                                                 ");
		sql.append("        AND B.HOSP_CODE          = A.HOSP_CODE                                                                                   ");
		sql.append("       LEFT JOIN DRG0120 C                                                                                                       ");
		sql.append("         ON C.BOGYONG_CODE       = A.BOGYONG_CODE                                                                                ");
		sql.append("        AND C.HOSP_CODE          = A.HOSP_CODE                                                                                   ");
		sql.append("       JOIN OUT0101 D                                                                                                            ");
		sql.append("         ON D.BUNHO              = A.BUNHO                                                                                       ");
		sql.append("        AND D.HOSP_CODE          = A.HOSP_CODE                                                                                   ");
		sql.append("       JOIN DRG2035 E                                                                                                            ");
		sql.append("         ON E.JUBSU_DATE         = A.JUBSU_DATE                                                                                  ");
		sql.append("        AND E.DRG_BUNHO          = A.DRG_BUNHO                                                                                   ");
		sql.append("        AND E.FKOCS2003          = A.FKOCS2003                                                                                   ");
		sql.append("        AND E.HOSP_CODE          = A.HOSP_CODE                                                                                   ");
		sql.append("      WHERE A.HOSP_CODE          = :f_hosp_code                                                                                  ");
		sql.append("        AND A.JUBSU_DATE         = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                                                        ");
		sql.append("        AND A.DRG_BUNHO          = :f_drg_bunho                                                                                  ");
		sql.append("        AND A.BUNRYU1            = '4'                                                                                           ");
		sql.append("        AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL (A.DC_YN,'N') END     = 'N'                                               ");
		sql.append("        AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN,'N') END  = 'N'                                               ");
		sql.append("      GROUP BY A.BUNHO                                                                                                           ");
		sql.append("           ,LTRIM(CAST(A.DRG_BUNHO AS CHAR))                                                                                     ");
		sql.append("           ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, A.HOSP_CODE, :f_language )                                           ");
		sql.append("           ,A.JUBSU_DATE                                                                                                         ");
		sql.append("           ,A.HOPE_DATE                                                                                                          ");
		sql.append("           ,A.ORDER_DATE                                                                                                         ");
		sql.append("           ,CONCAT('Rp.',E.SERIAL_V, CASE IFNULL(A.MIX_GROUP, '') WHEN '' THEN '' ELSE ' M' END)                                 ");
		sql.append("           ,E.SERIAL_V                                                                                                           ");
		sql.append("           ,D.SUNAME                                                                                                             ");
		sql.append("           ,D.SUNAME2                                                                                                            ");
		sql.append("           ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE, A.HOSP_CODE)                                                              ");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'')                   ");
		sql.append("           ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'')                   ");
		sql.append("      ORDER BY LTRIM(LPAD(E.SERIAL_V,4, '0'))                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DRG3010P99JusaLabelInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99JusaLabelInfo.class);
		return listInfo;		
	}
	
	@Override
	public List<DRG3010P99JusaKInfo> getDRG3010P99JusaKInfo(String hospCode, String language, String k, String cnt, String serialText, String jubsuDate, Double drgBunho, String dataGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT A.JAERYO_CODE                                        JAERYO_CODE                                                         ");
		sql.append("           ,CAST(A.NALSU AS CHAR)                                NALSU                                                               ");
		sql.append("           ,A.DIVIDE                                             DIVIDE                                                              ");
		sql.append("           ,CAST(A.ORDER_SURYANG AS CHAR)                        ORDER_SURYANG                                                       ");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                        SUBUL_SURYANG                                                       ");
		sql.append("           ,CAST(A.SUBUL_SURYANG AS CHAR)                        ORD_SURYANG                                                         ");
		sql.append("           ,A.ORDER_DANUI                                        ORDER_DANUI                                                         ");
		sql.append("           ,A.SUBUL_DANUI                                        SUBUL_DANUI                                                         ");
		sql.append("           ,IFNULL(A.BUNRYU1, '')                                BUNRYU1                                                             ");
		sql.append("           ,IFNULL(A.BUNRYU2, '')                                BUNRYU2                                                             ");
		sql.append("           ,IFNULL(A.BUNRYU3, '')                                BUNRYU3                                                             ");
		sql.append("           ,IFNULL(A.BUNRYU4, '')                                BUNRYU4                                                             ");
		sql.append("           ,IFNULL(TRIM(C.ORDER_REMARK), '')                     REMARK                                                              ");
		sql.append("           ,A.DV_TIME                                            DV_TIME                                                             ");
		sql.append("           ,A.DV                                                 DV                                                                  ");
		sql.append("           ,IFNULL(A.BUNRYU6, '')                                BUNRYU6                                                             ");
		sql.append("           ,IFNULL(A.MIX_GROUP, '')                              MIX_GROUP                                                           ");
		sql.append("           ,IFNULL(A.DV_1, '')                                   DV_1                                                                ");
		sql.append("           ,IFNULL(A.DV_2, '')                                   DV_2                                                                ");
		sql.append("           ,IFNULL(A.DV_3, '')                                   DV_3                                                                ");
		sql.append("           ,IFNULL(A.DV_4, '')                                   DV_4                                                                ");
		sql.append("           ,IFNULL(A.DV_5, '')                                   DV_5                                                                ");
		sql.append("           ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN                                                     ");
		sql.append("           ,A.PHARMACY                                           PHARMACY                                                            ");
		sql.append("           ,IFNULL(A.JUSA_SPD_GUBUN, '')                         JUSA_SPD_GUBUN                                                      ");
		sql.append("           ,A.DRG_PACK_YN                                        DRG_PACK_YN                                                         ");
		sql.append("           ,IFNULL(A.JUSA, '')                                   JUSA                                                                ");
		sql.append("           ,B.HANGMOG_NAME                                       JAERYO_NAME                                                         ");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language)    DANUI_NAME                                ");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, A.HOSP_CODE, :f_language)    SUBUL_DANUI_NAME                          ");
		sql.append("           ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0') , A.HOSP_CODE, :f_language)        JUSA_NAME                             ");
		sql.append("          , CONCAT(:f_k, '/', :f_cnt)                            RP2                                                                 ");
		sql.append("          , CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'),CAST(A.DRG_BUNHO AS CHAR),CAST(E.SERIAL_V AS CHAR),:f_k,'*') BARCODE_NO    ");
		sql.append("          , :f_data_gubun                                        DATA_GUBUN                                                          ");
		sql.append("     FROM DRG3010 A                                                                                                                  ");
		sql.append("     JOIN OCS2003 C                                                                                                                  ");
		sql.append("       ON C.PKOCS2003          = A.FKOCS2003                                                                                         ");
		sql.append("      AND C.HOSP_CODE          = A.HOSP_CODE                                                                                         ");
		sql.append("     JOIN OCS0103 B                                                                                                                  ");
		sql.append("       ON B.HANGMOG_CODE       = C.HANGMOG_CODE                                                                                      ");
		sql.append("      AND B.HOSP_CODE          = C.HOSP_CODE                                                                                         ");
		sql.append("     JOIN DRG2035 E                                                                                                                  ");
		sql.append("       ON E.JUBSU_DATE         = A.JUBSU_DATE                                                                                        ");
		sql.append("      AND E.DRG_BUNHO          = A.DRG_BUNHO                                                                                         ");
		sql.append("      AND E.FKOCS2003          = A.FKOCS2003                                                                                         ");
		sql.append("      AND E.HOSP_CODE          = A.HOSP_CODE                                                                                         ");
		sql.append("      AND E.SERIAL_V           = :f_serial_text                                                                                      ");
		sql.append("     WHERE A.HOSP_CODE         = :f_hosp_code                                                                                        ");
		sql.append("       AND A.JUBSU_DATE        = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                                                              ");
		sql.append("       AND A.DRG_BUNHO         = :f_drg_bunho                                                                                        ");
		sql.append("       AND A.DIVIDE            >= :f_k                                                                                               ");
		sql.append("       AND A.BUNRYU1           IN ('4')                                                                                              ");
		sql.append("       AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL (A.DC_YN,'N') END        = 'N'                                                 ");
		sql.append("       AND CASE(A.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(A.BANNAB_YN,'N') END = 'N'                                                 ");
		sql.append("       AND C.ORDER_DATE       BETWEEN   B.START_DATE AND CASE (B.END_DATE) WHEN '' THEN STR_TO_DATE('9998/12/31','%Y/%m/%d')         ");
		sql.append("                                                           ELSE IFNULL(B.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')) END         ");
		sql.append("     ORDER BY CONCAT(LTRIM(LPAD(E.SERIAL_V, 4,'0')), LTRIM(LPAD(A.GROUP_SER, 4,'0')), CASE(A.MIX_GROUP)                              ");
		sql.append("                     WHEN '' THEN ' ' ELSE IFNULL(A.MIX_GROUP, ' ') END,                                                             ");
		sql.append("            LTRIM(LPAD(CASE(C.BOM_OCCUR_YN) WHEN 'Y' THEN C.SEQ + 100 ELSE C.SEQ END, 4, '0')),                                      ");
		sql.append("            LTRIM(LPAD(C.PKOCS2003, 10, '0')))                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_k", k);
		query.setParameter("f_serial_text", serialText);
		query.setParameter("f_cnt", cnt);
		query.setParameter("f_data_gubun", dataGubun);		
		
		List<DRG3010P99JusaKInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99JusaKInfo.class);
		return listInfo;		
	}
	
	@Override
	public String getDRG3010P99CheckDetailMaxActing(String hospCode, Double fkocs2003){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT IFNULL(FN_OCS_CHECK_DETAIL_MAX_ACTING(A.HOSP_CODE,A.FKOCS2003,                          ");
		sql.append("       CASE(A.HOPE_DATE) WHEN '' THEN A.ORDER_DATE ELSE IFNULL(A.HOPE_DATE, ORDER_DATE) END),'0')     ");
		sql.append("                            FROM DRG3010 A                                                          ");
		sql.append("                           WHERE A.HOSP_CODE = :f_hosp_code                                         ");
		sql.append("                             AND A.FKOCS2003 = :f_fkocs2003                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2003", fkocs2003);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list)){
			return list.get(0);
		}
		return "";
	}
	
	
	@Override
	public String getDRG3010P99FnDrgChulgoDate(String hospCode, String bunho, String orderDate, String ioGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT FN_DRG_CHULGO_DATE(:f_hosp_code, :f_io, :f_bunho, STR_TO_DATE(:f_order_date, '%Y/%m/%d'))	");
		sql.append("     FROM DUAL                                                                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_io", ioGubun);
		query.setParameter("f_order_date", orderDate);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list)){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public String getDRG3010P99MaxSeq(String hospCode, Double drgBunho, String jubsuDate, String ioGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT IFNULL(MAX(A.SEQ) + 1, '')                                   ");
		sql.append("       FROM DRG_ATC A                                                    ");
		sql.append("      WHERE A.JUBSU_DATE   = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')      ");
		sql.append("        AND A.DRG_BUNHO    = :f_drg_bunho                                ");
		sql.append("        AND A.IN_OUT_GUBUN = :f_in_out_gubun                             ");
		sql.append("        AND A.HOSP_CODE    = :f_hosp_code                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_in_out_gubun", ioGubun);
		query.setParameter("f_jubsu_date", jubsuDate);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list)){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public Integer DRG3010P99UpdateDrg3010Fkjihkey(String hospCode, Double fkjihkey, String jubsuDate, Double drgBunho, String bunho, String mode){
		StringBuilder sql = new StringBuilder();
		if(mode.equals("1")){
			sql.append("     UPDATE DRG3010 A                                    							");
			sql.append("        SET A.FKJIHKEY     = :f_pkdrg    	             							");
			sql.append("      WHERE A.HOSP_CODE    = :f_hosp_code                							");
			sql.append("        AND A.JUBSU_DATE   = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')               	");
			sql.append("        AND A.DRG_BUNHO    = :f_drg_bunho                							");
			sql.append("        AND A.BUNHO        = :f_bunho                    							");
			sql.append("        AND A.BUNRYU1      IN('1', '6')                  							");
		}else{
			sql.append("     UPDATE DRG3010 A                                    							");
			sql.append("        SET A.FKJIHKEY     = :f_pkdrg	                 							");
			sql.append("      WHERE A.HOSP_CODE    = :f_hosp_code                							");
			sql.append("        AND A.JUBSU_DATE   = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')               	");
			sql.append("        AND A.DRG_BUNHO    = :f_drg_bunho                							");
			sql.append("        AND A.BUNHO        = :f_bunho                    							");
			sql.append("        AND A.BUNRYU1      = '4'                         							");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_pkdrg", fkjihkey);
		query.setParameter("f_bunho", bunho);
		
		return query.executeUpdate();
	}
	
	@Override
	public Integer DRG3010P99UpdateDrg3010PowderYn(String hospCode, Double fkocs2003, String powderYn){
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE DRG3010 A                                    ");
		sql.append("        SET A.POWDER_YN   = :f_powder_yn                 ");
		sql.append("      WHERE A.HOSP_CODE   = :f_hosp_code                 ");
		sql.append("        AND A.FKOCS2003   = :f_fkocs2003                 ");		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_powder_yn", powderYn);
		query.setParameter("f_fkocs2003", fkocs2003);
		
		return query.executeUpdate();
	}
	
	@Override
	public Integer DRG3010P99UpdateDrg3010DrgPackYn(String hospCode, Double fkocs2003, String drgPackYn){
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE DRG3010 A                                    ");
		sql.append("        SET A.DRG_PACK_YN = :f_drg_pack_yn               ");
		sql.append("      WHERE A.HOSP_CODE   = :f_hosp_code                 ");
		sql.append("        AND A.FKOCS2003   = :f_fkocs2003                 ");		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_drg_pack_yn", drgPackYn);
		query.setParameter("f_fkocs2003", fkocs2003);
		
		return query.executeUpdate();
	}
	
	@Override
	public Integer DRG3010P99UpdateDrg3010fkDrg4010(String hospCode, Double pkdrg4010, String jubsuDate, Double drgBunho, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE DRG3010 A                                    							");
		sql.append("        SET A.FKDRG4010    = :f_pkdrg4010                							");
		sql.append("      WHERE A.HOSP_CODE    = :f_hosp_code                							");
		sql.append("        AND A.JUBSU_DATE   = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')               	");
		sql.append("        AND A.DRG_BUNHO    = :f_drg_bunho                							");
		sql.append("        AND A.BUNHO        = :f_bunho                    							");		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkdrg4010", pkdrg4010);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_bunho", bunho);
		
		return query.executeUpdate();
	}
	
	@Override
	public Integer DRG3010P99UpdateDrg3010ReUseYn(String hospCode, Double fkocs2003, String reUseYn){
		StringBuilder sql = new StringBuilder();
		sql.append("     UPDATE DRG3010                                      ");
		sql.append("        SET RE_USE_YN = :f_re_use_yn                     ");
		sql.append("      WHERE FKOCS2003 = :f_fkocs2003                     ");
		sql.append("        AND HOSP_CODE = :f_hosp_code                     ");	
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_re_use_yn", reUseYn);
		query.setParameter("f_fkocs2003", fkocs2003);
		
		return query.executeUpdate();
	}
	
	@Override
	public String getDRG3010P99getYOrderGubun(String hospCode, Double drgBunho, String jubsuDate, String bunho, String orderGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT 'Y'                                                                            ");
		sql.append("       FROM (                                                                                       ");
		sql.append("             SELECT SUBSTR(A.ORDER_GUBUN,2,1) ORDER_GUBUN                                           ");
		sql.append("               FROM OCS2003 A                                                                       ");
		sql.append("              WHERE A.HOSP_CODE = :f_hosp_code                                                      ");
		sql.append("                AND A.PKOCS2003 IN (SELECT B.FKOCS2003                                              ");
		sql.append("                                      FROM DRG3010 B                                                ");
		sql.append("                                     WHERE B.HOSP_CODE  = A.HOSP_CODE                               ");
		sql.append("                                       AND B.JUBSU_DATE = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')    ");
		sql.append("                                       AND B.DRG_BUNHO  = :f_drg_bunho                              ");
		sql.append("                                       AND B.BUNHO      = :f_bunho)                                 ");
		sql.append("            ) C                                                                                     ");
		if(orderGubun.equals("cd")){
			sql.append("      WHERE C.ORDER_GUBUN IN ('C', 'D')                                                         ");
		}else{
			sql.append("      WHERE C.ORDER_GUBUN IN ('B')                                                              ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_jubsu_date", jubsuDate);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list)){
			return list.get(0);
		}
		return "";
	}


	@Override
	public List<DRG3010P10GrdPaDcInfo> getDRG3010P10GrdPaDcInfo(String hospCode, String language,
			String bunho, String hoDong, String fromDate, String toDate, String magamGubun, String magamBunryu) {
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT																												");
		sql.append("        DISTINCT A.BUNHO                                                                    BUNHO,						");
		sql.append("        B.SUNAME                                                                            SUNAME,						");
		sql.append("        FN_BAS_LOAD_CODE_NAME('SEX', B.SEX, :f_hosp_code, :f_language)                    	SEX,						");
		sql.append("        FN_BAS_LOAD_AGE(A.HOPE_DATE, B.BIRTH, '')                                           AGE,						");
		sql.append("        A.RESIDENT                                                                          RESIDENT,					");
		sql.append("        IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, :f_hosp_code), '')     	DOCTOR_NAME,				");
		sql.append("        C.HO_DONG1                                             								HO_DONG,					");
		sql.append("        FN_BAS_LOAD_GWA_NAME(C.HO_DONG1, A.ORDER_DATE, :f_hosp_code, :f_language)         	HO_DONG_NAME,				");
		sql.append("        IFNULL(A.APPEND_YN,'N')                                                             APPEND_YN,					");
		sql.append("        ''                                                                                  JUNINP_YN ,					");
		sql.append("        IFNULL(A.HOPE_DATE, A.ORDER_DATE)                                                   HOPE_DATE,					");
		sql.append("        C.PKINP1001                                                                         PKINP1001,					");
		sql.append("        CASE C.TOIWON_RES_DATE WHEN NULL THEN 'N' ELSE 'Y' END                				TOIWON_YN,					");
		sql.append("        '1'                                                                                 MAGAM_BUNRYU,				");
		sql.append("        A.ORDER_DATE                                                                        ORDER_DATE ,				");
		sql.append("        C.HO_CODE1                                                                          HO_CODE,					");
		sql.append("        A.JUBSU_DATE                                                                        JUBSU_DATE,					");
		sql.append("        A.DRG_BUNHO                                                                         DRG_BUNHO					");
		sql.append("     FROM																												");
		sql.append("       DRG3010 A JOIN OUT0101 B																							");
		sql.append("     		ON B.BUNHO                	= A.BUNHO																		");
		sql.append("     		JOIN INP1001 C																								");
		sql.append("     		ON A.HOSP_CODE            	= C.HOSP_CODE																	");
		sql.append("        	AND C.PKINP1001            	= A.FKINP1001																	");
		sql.append("        	AND B.HOSP_CODE            	= C.HOSP_CODE																	");
		sql.append("     WHERE C.HOSP_CODE 					= :f_hosp_code																	");
		sql.append("        AND A.JUBSU_DATE  				BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')											");
		sql.append("        AND A.BUNHO                		LIKE :f_bunho																	");
		sql.append("        AND C.HO_DONG1             		LIKE :f_ho_dong																	");
		sql.append("        AND IFNULL(A.APPEND_YN,'N')   	LIKE :f_magam_gubun																");
		sql.append("        AND A.BUNRYU1              		IN ('1','6')																	");
		sql.append("        AND IFNULL(A.RE_USE_YN,'N')     = 'N'																			");
		sql.append("        AND IFNULL(EMERGENCY,'N')       = 'N'																			");
		sql.append("        AND IFNULL(TOIWON_DRG_YN,'N')   = 'N'																			");
		sql.append("        AND IFNULL(A.DC_YN,'N')         = 'Y'																			");
		sql.append("        AND IFNULL(A.BANNAB_YN,'N')     = 'Y'																			");
		sql.append("        AND IFNULL(C.CANCEL_YN,'N')     = 'N'																			");
		sql.append("        AND '1' 						LIKE :f_magam_bunryu       														");
		sql.append("      UNION ALL																											");
		sql.append("     SELECT																												");
		sql.append("        DISTINCT A.BUNHO                                                                    BUNHO,						");
		sql.append("        B.SUNAME                                                                            SUNAME,						");
		sql.append("        FN_BAS_LOAD_CODE_NAME('SEX', B.SEX, :f_hosp_code, :f_language)                    	SEX,						");
		sql.append("        FN_BAS_LOAD_AGE(A.HOPE_DATE, B.BIRTH, '')                                           AGE,						");
		sql.append("        A.RESIDENT                                                                          RESIDENT,					");
		sql.append("        FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, :f_hosp_code)     				DOCTOR_NAME,				");
		sql.append("        C.HO_DONG1                                             								HO_DONG,					");
		sql.append("        FN_BAS_LOAD_GWA_NAME(C.HO_DONG1, A.ORDER_DATE, :f_hosp_code, :f_language)         	HO_DONG_NAME,				");
		sql.append("        IFNULL(A.APPEND_YN,'N')                                                             APPEND_YN,					");
		sql.append("        FN_DRG_JUNINP_YN(A.HOSP_CODE,A.FKOCS2003,'N')      				                    JUNINP_YN ,					");
		sql.append("        IFNULL(A.HOPE_DATE, A.ORDER_DATE)                                                   HOPE_DATE,					");
		sql.append("        C.PKINP1001                                                                         PKINP1001,					");
		sql.append("        CASE C.TOIWON_RES_DATE WHEN NULL THEN 'N' ELSE 'Y' END                				TOIWON_YN,					");
		sql.append("        '2'                                                                                 MAGAM_BUNRYU,				");
		sql.append("        A.ORDER_DATE                                                                        ORDER_DATE ,				");
		sql.append("        C.HO_CODE1                                                                          HO_CODE,					");
		sql.append("        A.JUBSU_DATE                                                                        JUBSU_DATE,					");
		sql.append("        A.DRG_BUNHO                                                                         DRG_BUNHO					");
		sql.append("     FROM																												");
		sql.append("        DRG3010 A JOIN OUT0101 B																						");
		sql.append("     	 	ON B.BUNHO                	= A.BUNHO																		");
		sql.append("     		JOIN INP1001 C																								");
		sql.append("        	ON A.HOSP_CODE            	= C.HOSP_CODE																	");
		sql.append("        	AND C.PKINP1001            	= A.FKINP1001																	");
		sql.append("        	AND B.HOSP_CODE            	= C.HOSP_CODE																	");
		sql.append("      WHERE C.HOSP_CODE 					= :f_hosp_code																");
		sql.append("        AND A.JUBSU_DATE  					BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')											");
		sql.append("        AND A.BUNHO                			LIKE :f_bunho																");
		sql.append("        AND C.HO_DONG1             			LIKE :f_ho_dong																");
		sql.append("        AND IFNULL(A.APPEND_YN,'N')   		LIKE :f_magam_gubun															");
		sql.append("        AND A.BUNRYU1              			IN ('4')																	");
		sql.append("        AND IFNULL(A.RE_USE_YN,'N')         = 'N'																		");
		sql.append("        AND IFNULL(EMERGENCY,'N')           = 'N'																		");
		sql.append("        AND IFNULL(TOIWON_DRG_YN,'N')       = 'N'																		");
		sql.append("        AND IFNULL(A.DC_YN,'N')             = 'Y'																		");
		sql.append("        AND IFNULL(A.BANNAB_YN,'N')         = 'Y'																		");
		sql.append("        AND IFNULL(C.CANCEL_YN,'N')         = 'N'																		");
		sql.append("        AND '2' 							LIKE :f_magam_bunryu       													");
		sql.append("      ORDER BY																											");
		sql.append("      	JUBSU_DATE, PKINP1001, TOIWON_YN DESC, BUNHO, HO_DONG_NAME														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_bunho", bunho + "%");
		query.setParameter("f_ho_dong", hoDong + "%");
		query.setParameter("f_magam_gubun", magamGubun);
		query.setParameter("f_magam_bunryu", magamBunryu);
		
		List<DRG3010P10GrdPaDcInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdPaDcInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10GrdPaInfo> getDRG3010P10GrdPaInfo(String hospCode, String language,
			String fromDate, String toDate, String bunho, String hoDong, String magamGubun, String magamBunryu) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT DISTINCT                                                                                                                                ");
		sql.append("      A.BUNHO                                                                                  BUNHO, 						                      ");
		sql.append("      B.SUNAME                                                                                 SUNAME, 					                      	  ");
		sql.append("      FN_BAS_LOAD_CODE_NAME('SEX', B.SEX, :f_hosp_code, :f_language)                           SEX, 						                      ");
		sql.append("      CAST(FN_BAS_LOAD_AGE(A.HOPE_DATE, B.BIRTH, '') AS CHAR)                                  AGE, 						                      ");
		sql.append("      A.RESIDENT                                                                               RESIDENT, 					                      ");
		sql.append("      IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, :f_hosp_code), '')              DOCTOR_NAME, 				                      ");
		sql.append("      C.HO_DONG1                                                                               HO_DONG, 					                      ");
		sql.append("      FN_BAS_LOAD_GWA_NAME(C.HO_DONG1, A.ORDER_DATE, :f_hosp_code, :f_language)        		    HO_DONG_NAME, 				                      ");
		sql.append("      IFNULL(A.APPEND_YN,'N')                                                                  APPEND_YN, 					                      ");
		sql.append("      ''                                                                                       JUNINP_YN , 				                          ");
		sql.append("      DATE_FORMAT(IFNULL(A.HOPE_DATE, A.ORDER_DATE), '%Y/%m/%d')                                HOPE_DATE, 					                      ");
		sql.append("      C.PKINP1001                                                                              PKINP1001, 					                      ");
		sql.append("      CASE C.TOIWON_RES_DATE WHEN NULL THEN 'N' ELSE 'Y' END                                   TOIWON_YN, 					                      ");
		sql.append("      '1'                                                                                      MAGAM_BUNRYU, 				                      ");
		sql.append("      DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                                    ORDER_DATE , 				                      ");
		sql.append("      C.HO_CODE1                                                                               HO_CODE, 					                      ");
		sql.append("      D.ACT_BUSEO                                                                              ACT_BUSEO 					                      ");
		sql.append("   FROM DRG3010 A                                                                                                                                 ");
		sql.append("   JOIN OUT0101 B ON B.BUNHO = A.BUNHO                                                                                                            ");
		sql.append("                 AND B.HOSP_CODE = A.HOSP_CODE                                                                                                    ");
		sql.append("   JOIN INP1001 C ON A.HOSP_CODE = C.HOSP_CODE 																		                              ");
		sql.append("              		AND C.PKINP1001 = A.FKINP1001 																		                          ");
		sql.append("              		AND B.HOSP_CODE = C.HOSP_CODE 																		                          ");
		sql.append("   JOIN OCS2003 D ON D.HOSP_CODE = A.HOSP_CODE 																		                              ");
		sql.append("      		        AND D.PKOCS2003 = A.FKOCS2003 																		                          ");
		sql.append("   WHERE C.HOSP_CODE                               = :f_hosp_code 														                          ");
		sql.append("    AND IFNULL(A.HOPE_DATE, A.ORDER_DATE)          BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m/%d') AND STR_TO_DATE(:f_to_date, '%Y/%m/%d')          ");
		sql.append("    AND A.BUNHO                		                LIKE CONCAT(:f_bunho, '%') 											                          ");
		sql.append("    AND C.HO_DONG1             		                LIKE CONCAT(:f_ho_dong, '%') 										                          ");
		sql.append("    AND IF(A.APPEND_YN IS NULL OR A.APPEND_YN = '', 'N', A.APPEND_YN)   	          LIKE :f_magam_gubun 										  ");
		sql.append("    AND A.BUNRYU1              		                                                IN ('1','6') 												  ");
		sql.append("    AND IF(A.RE_USE_YN IS NULL OR A.RE_USE_YN = '', 'N', A.RE_USE_YN)   	          = 'N' 												      ");
		sql.append("    AND IF(A.EMERGENCY IS NULL OR A.EMERGENCY = '', 'N', A.EMERGENCY)     	        = 'N' 													      ");
		sql.append("    AND IF(A.TOIWON_DRG_YN IS NULL OR A.TOIWON_DRG_YN = '', 'N', A.TOIWON_DRG_YN) 	= 'N' 													      ");
		sql.append("    AND A.DRG_BUNHO            		                                                IS NULL 													  ");
		sql.append("    AND A.NALSU                		                                                > 0 														  ");
		sql.append("    AND IF(A.DC_YN IS NULL OR A.DC_YN = '', 'N', A.DC_YN)      	                  = 'N' 														  ");
		sql.append("    AND IF(A.BANNAB_YN IS NULL OR A.BANNAB_YN = '', 'N', A.BANNAB_YN)   	          = 'N' 													  ");
		sql.append("    AND IF(A.BANNAB_YN IS NULL OR A.BANNAB_YN = '', 'N', A.BANNAB_YN)   	          != 'Y' 													  ");
		sql.append("    AND IF(C.CANCEL_YN IS NULL OR C.CANCEL_YN = '', 'N', C.CANCEL_YN)   	          = 'N' 													  ");
		sql.append("    AND C.JAEWON_FLAG          		                                                = 'Y' 														  ");
		sql.append("    AND '1' LIKE                                                                   :f_magam_bunryu 												  ");
		sql.append("   UNION ALL 																												                      ");
		sql.append("   SELECT DISTINCT                                                                                                                                ");
		sql.append("      A.BUNHO                                               						          BUNHO, 							                  ");
		sql.append("      B.SUNAME                                              								      SUNAME, 						                  ");
		sql.append("      FN_BAS_LOAD_CODE_NAME('SEX', B.SEX, :f_hosp_code, :f_language)             SEX, 							                                  ");
		sql.append("      CAST(FN_BAS_LOAD_AGE(A.HOPE_DATE, B.BIRTH, '') AS CHAR)  								      AGE, 							                  ");
		sql.append("      A.RESIDENT                                            								      RESIDENT, 						              ");
		sql.append("      FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE, :f_hosp_code)     	      DOCTOR_NAME, 					                                  ");
		sql.append("      C.HO_DONG1                                            								      HO_DONG, 						                  ");
		sql.append("      FN_BAS_LOAD_GWA_NAME(C.HO_DONG1, A.ORDER_DATE, :f_hosp_code, :f_language)  HO_DONG_NAME, 					                                  ");
		sql.append("      IFNULL(A.APPEND_YN,'N')                                  							    APPEND_YN, 						                      ");
		sql.append("      FN_DRG_JUNINP_YN(:f_hosp_code, A.FKOCS2003, NULL)                         	JUNINP_YN , 					                              ");
		sql.append("      DATE_FORMAT(IFNULL(A.HOPE_DATE, A.ORDER_DATE),'%Y/%m/%d')                        		  HOPE_DATE, 						                      ");
		sql.append("      C.PKINP1001                                           								      PKINP1001, 						              ");
		sql.append("      CASE C.TOIWON_RES_DATE WHEN NULL THEN 'N' ELSE 'Y' END                			TOIWON_YN, 						                          ");
		sql.append("      '2'                                                                        MAGAM_BUNRYU, 					                                  ");
		sql.append("      DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                          ORDER_DATE , 					                                  ");
		sql.append("      C.HO_CODE1                                                                 HO_CODE, 						                                  ");
		sql.append("      D.ACT_BUSEO                                                                ACT_BUSEO 						                                  ");
		sql.append("   FROM DRG3010 A                                                                                                                                 ");
		sql.append("   JOIN OUT0101 B ON B.BUNHO = A.BUNHO 																		                                      ");
		sql.append("                 AND B.HOSP_CODE = A.HOSP_CODE                                                                                                    ");
		sql.append("   JOIN INP1001 C ON A.HOSP_CODE = C.HOSP_CODE 																	                                  ");
		sql.append("                 AND C.PKINP1001 = A.FKINP1001 																	                                  ");
		sql.append("   JOIN OCS2003 D ON D.HOSP_CODE = A.HOSP_CODE 																	                                  ");
		sql.append("      			      AND D.PKOCS2003 = A.FKOCS2003 																	                          ");
		sql.append("   WHERE C.HOSP_CODE = :f_hosp_code 																							                  ");
		sql.append("    AND IFNULL(A.HOPE_DATE, A.ORDER_DATE)  BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m/%d') AND STR_TO_DATE(:f_to_date, '%Y/%m/%d')                  ");
		sql.append("    AND A.BUNHO                						LIKE CONCAT(:f_bunho, '%') 											                          ");
		sql.append("    AND C.HO_DONG1             						LIKE CONCAT(:f_ho_dong, '%') 										                          ");
		sql.append("    AND IF(A.APPEND_YN IS NULL OR A.APPEND_YN = '','N', A.APPEND_YN)               LIKE :f_magam_gubun 											  ");
		sql.append("    AND A.BUNRYU1              						                                        IN ('4') 											  ");
		sql.append("    AND IF(A.RE_USE_YN IS NULL OR A.RE_USE_YN = '', 'N', A.RE_USE_YN)              = 'N' 													      ");
		sql.append("    AND IF(A.EMERGENCY IS NULL OR A.EMERGENCY = '', 'N', A.EMERGENCY)              = 'N' 													      ");
		sql.append("    AND IF(A.TOIWON_DRG_YN IS NULL OR A.TOIWON_DRG_YN = '', 'N', A.TOIWON_DRG_YN)  = 'N' 													      ");
		sql.append("    AND A.DRG_BUNHO            						                                        IS NULL 											  ");
		sql.append("    AND A.NALSU                						                                        > 0 												  ");
		sql.append("    AND IF(A.DC_YN IS NULL OR A.DC_YN = '', 'N', A.DC_YN)       					          = 'N' 										      ");
		sql.append("    AND IF(A.BANNAB_YN IS NULL OR A.BANNAB_YN = '', 'N', A.BANNAB_YN)   					  = 'N' 										      ");
		sql.append("    AND IF(A.BANNAB_YN IS NULL OR A.BANNAB_YN = '', 'N', A.BANNAB_YN)   					  != 'Y' 										      ");
		sql.append("    AND IF(C.CANCEL_YN IS NULL OR C.CANCEL_YN = '', 'N', C.CANCEL_YN)   					  = 'N' 										      ");
		sql.append("    AND C.JAEWON_FLAG          						                                        = 'Y' 												  ");
		sql.append("    AND '2' 											                                                  LIKE :f_magam_bunryu                    ");
		sql.append("    ORDER BY MAGAM_BUNRYU, HOPE_DATE DESC, BUNHO, HO_DONG                                                                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_bunho", bunho + "%");
		query.setParameter("f_ho_dong", hoDong + "%");
		query.setParameter("f_magam_gubun", magamGubun);
		query.setParameter("f_magam_bunryu", magamBunryu);
		
		List<DRG3010P10GrdPaInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10GrdPaInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10LayOrderJungboInfo> getDRG3010P10LayOrderJungboInfo(String hospCode, String jubsuDate, String drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT 																																				");
		sql.append("      '1'                                                                                           SEQ_1, 												");
		sql.append("      D.SERIAL_V                                                                                    SEQ_2, 												");
		sql.append("      C.JAERYO_NAME                                                                                 TEXT_1, 											");
		sql.append("      REPLACE(REPLACE(B.ORDER_REMARK, CONCAT(CHAR(13),CHAR(10)), ' '), CHAR(10), ' ')     			REMARK, 											");
		sql.append("      CONCAT('*', DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), LTRIM(LPAD(A.DRG_BUNHO, 4, '0')), '*')  		bar_drg_bunho, 										");
		sql.append("      A.BUNHO            																			BUNHO 												");
		sql.append("    FROM 																																				");
		sql.append("    	DRG3010 A JOIN DRG9042 B 																														");
		sql.append("    		ON B.HOSP_CODE      	= A.HOSP_CODE 																										");
		sql.append("       		AND B.FKOCS          	= A.FKOCS2003 																										");
		sql.append("    	 	LEFT JOIN INV0110 C 																														");
		sql.append("    	 	ON C.HOSP_CODE   		= A.HOSP_CODE 																										");
		sql.append("       		AND C.JAERYO_CODE 		= A.JAERYO_CODE 																									");
		sql.append("    	 	LEFT JOIN DRG2035 D 																														");
		sql.append("    	 	ON D.HOSP_CODE   		= A.HOSP_CODE 																										");
		sql.append("       		AND D.FKOCS2003   		= A.FKOCS2003 																										");
		sql.append("    WHERE 																																				");
		sql.append("       A.HOSP_CODE      	= :f_hosp_code 																												");
		sql.append("       AND A.JUBSU_DATE     = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d') 																					");
		sql.append("       AND A.DRG_BUNHO      = :f_drg_bunho 																												");
		sql.append("       AND B.ORDER_REMARK 	IS NOT NULL	  																												");
		sql.append("    UNION ALL 																																			");
		sql.append("    SELECT 																																				");
		sql.append("      DISTINCT '1'                                                                                                              SEQ_1, 					");
		sql.append("      ''                                                                                                                        SEQ_2, 					");
		sql.append("      C.JAERYO_NAME                                                                                                             TEXT_1, 				");
		sql.append("      CONCAT('[', FN_ADM_MSG(4111), ']', REPLACE(REPLACE(C.DRG_COMMENT, CONCAT(CHAR(13), CHAR(10)), ' '), CHAR(10), ' '))      	REMARK, 				");
		sql.append("      CONCAT('*', DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), LTRIM(LPAD(A.DRG_BUNHO, 4, '0')), '*')  									bar_drg_bunho, 			");
		sql.append("      A.BUNHO            																										BUNHO 					");
		sql.append("    FROM 																																				");
		sql.append("    	DRG3010 A LEFT JOIN INV0110 C 																													");
		sql.append("    		ON C.HOSP_CODE   		= A.HOSP_CODE 																										");
		sql.append("       		AND C.JAERYO_CODE 		= A.JAERYO_CODE 																									");
		sql.append("      		LEFT JOIN DRG2035 D 																														");
		sql.append("    		ON D.HOSP_CODE   		= A.HOSP_CODE 																										");
		sql.append("       		AND D.FKOCS2003   		= A.FKOCS2003 																										");
		sql.append("    WHERE 																																				");
		sql.append("      A.HOSP_CODE      			= :f_hosp_code 																											");
		sql.append("       AND A.JUBSU_DATE     	= STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d') 																				");
		sql.append("       AND A.DRG_BUNHO      	= :f_drg_bunho 																											");
		sql.append("       AND IFNULL(C.CHKD,'N')  	= 'Y' 																													");
		sql.append("    UNION ALL 																																			");
		sql.append("    SELECT 																																				");
		sql.append("      DISTINCT '2'                                                                                  SEQ_1, 												");
		sql.append("      ''                                                                                            SEQ_2, 												");
		sql.append("      '##'                                                                                          TEXT_1, 											");
		sql.append("      REPLACE(REPLACE(B.ORDER_REMARK, CONCAT(CHAR(13), CHAR(10)), ' '), CHAR(10), ' ')    			REMARK, 											");
		sql.append("      CONCAT('*', DATE_FORMAT(A.JUBSU_DATE, '%Y%m%d'), LTRIM(LPAD(A.DRG_BUNHO, 4, '0')), '*') 		bar_drg_bunho, 										");
		sql.append("      A.BUNHO            																			BUNHO 												");
		sql.append("    FROM 																																				");
		sql.append("    	DRG3010 A JOIN DRG9040 B 																														");
		sql.append("    		ON B.HOSP_CODE    	= A.HOSP_CODE 																											");
		sql.append("       		AND B.JUBSU_DATE    = A.JUBSU_DATE 																											");
		sql.append("       		AND B.DRG_BUNHO     = A.DRG_BUNHO 																											");
		sql.append("    WHERE 																																				");
		sql.append("       A.HOSP_CODE     		= FN_ADM_LOAD_HOSP_CODE() 																									");
		sql.append("       AND A.JUBSU_DATE    	= STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d') 																					");
		sql.append("       AND A.DRG_BUNHO     	= :f_drg_bunho 																												");
		sql.append("       AND B.ORDER_REMARK 	IS NOT NULL 																												");
		sql.append("    UNION ALL 																																			");
		sql.append("    SELECT 																																				");
		sql.append("      DISTINCT '3'                                                                              SEQ_1, 													");
		sql.append("      ''                                                                                        SEQ_2, 													");
		sql.append("      '$$'                                                                                      TEXT_1, 												");
		sql.append("      REPLACE(REPLACE(B.ORDER_REMARK, CONCAT(CHAR(13), CHAR(10)), ' '), CHAR(10), ' ')     		REMARK, 												");
		sql.append("      CONCAT('*', DATE_FORMAT(A.JUBSU_DATE, '%Y%m%d'), LTRIM(LPAD(A.DRG_BUNHO, 4, '0')), '*')  	bar_drg_bunho, 											");
		sql.append("      A.BUNHO            																		BUNHO 													");
		sql.append("    FROM 																																				");
		sql.append("    	DRG3010 A LEFT JOIN DRG9041 B 																													");
		sql.append("    		ON B.HOSP_CODE   	= A.HOSP_CODE 																											");
		sql.append("       		AND B.BUNHO       	= A.BUNHO 																												");
		sql.append("    WHERE 																																				");
		sql.append("      A.HOSP_CODE      		= :f_hosp_code 																												");
		sql.append("       AND A.JUBSU_DATE    	= STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d') 																					");
		sql.append("       AND A.DRG_BUNHO     	= :f_drg_bunho 																												");
		sql.append("       AND B.ORDER_REMARK 	IS NOT NULL 																												");
		sql.append("    ORDER BY 																																			");
		sql.append("    	SEQ_1, SEQ_2 																																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DRG3010P10LayOrderJungboInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10LayOrderJungboInfo.class);
		return listInfo;
	}
	
	@Override
	public ComboListItemInfo callPrMakeBongtuInp(String hospCode, String jubsuDate, String bunho, String hopeDate,
			String hopeTime, String gwa, String doctor, String jusaYn, String chulgoBuseo, String userId) {
		String oDrgBunho = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_MAKE_BONGTU_INP_ER");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOPE_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOPE_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUSA_YN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CHULGO_BUSEO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_DRG_BUNHO", Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_JUBSU_DATE", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_HOPE_DATE", DateUtil.toDate(hopeDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_HOPE_TIME", hopeTime);
		query.setParameter("I_GWA", gwa);
		query.setParameter("I_DOCTOR", doctor);
		query.setParameter("I_JUSA_YN", jusaYn);
		query.setParameter("I_CHULGO_BUSEO", chulgoBuseo);
		query.setParameter("I_USER_ID", userId);
		
		query.execute();
		oDrgBunho = CommonUtils.parseString((Integer) query.getOutputParameterValue("IO_DRG_BUNHO"));
		String ioErr = (String) query.getOutputParameterValue("IO_ERR");
		return new ComboListItemInfo(oDrgBunho, ioErr);
	}
	
	@Override
	public String callPrDrgLoadPrintGubun(String hospCode, String drgBunho, String jubsuDate, String printGubun){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_LOAD_PRINT_GUBUN");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DRG_BUNHO", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PRINT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_PRINT_GUBUN", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_JUBSU_DATE", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_DRG_BUNHO", CommonUtils.parseDouble(drgBunho));
		query.setParameter("I_PRINT_GUBUN", printGubun);
		query.execute();
		
		String result = (String) query.getOutputParameterValue("O_PRINT_GUBUN");
		return result;
	}

	@Override
	public List<DRG3010P10DsvOrderPrint3Info> getDRG3010P10DsvOrderPrint3Info(String hospCode, String language, String serialV, String fkocs2003) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT							 																																				");
		sql.append("        DISTINCT A.BUNHO                                                                                                            BUNHO,							 				");
		sql.append("        A.DRG_BUNHO                                                                                                                 DRG_BUNHO,							 			");
		sql.append("        A.GROUP_SER                                                                                                                 GROUP_SER,							 			");
		sql.append("        DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d')                                                                                        JUBSU_DATE,							 			");
		sql.append("        DATE_FORMAT(A.HOPE_DATE,'%Y/%m/%d')                                                                                         HOPE_DATE,							 			");
		sql.append("        DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                                                                        ORDER_DATE,							 			");
		sql.append("        A.JAERYO_CODE                                                                                                               JAERYO_CODE,							 		");
		sql.append("        A.NALSU * CASE FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code) WHEN 'Y' THEN A.DIVIDE ELSE 1 END              			NALSU,							 				");
		sql.append("        A.DIVIDE                                                                                									DIVIDE,							 				");
		sql.append("        CASE WHEN A.NALSU < 0 THEN CONCAT('-', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)			");
		sql.append("                           ELSE CONCAT('', CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN CONCAT('0', ROUND(A.ORD_SURYANG,2)) ELSE CONCAT('', ROUND(A.ORD_SURYANG,2)) END)				");
		sql.append("                           END                                                                                                      ORD_SURYANG,							 		");
		sql.append("        CASE A.BUNRYU1 WHEN '4' THEN A.ORD_SURYANG ELSE A.ORDER_SURYANG END                                                         ORDER_SURYANG,							 		");
		sql.append("        FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, :f_hosp_code, :f_language)                                                  ORDER_DANUI,							 		");
		sql.append("        A.SUBUL_DANUI                                                                                                               SUBUL_DANUI,							 		");
		sql.append("        IFNULL(A.BOGYONG_CODE, '')                                                                                                  BOGYONG_CODE,							 		");
		sql.append("        IFNULL(																																				 						");
		sql.append("        	CONCAT(																																				 					");
		sql.append("        		TRIM(B.BOGYONG_NAME), FN_DRG_LOAD_RP_TEXT('I', A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v),																				");
		sql.append("            	CASE IFNULL(A.DV_1,0) + IFNULL(A.DV_2,0) + IFNULL(A.DV_3,0) + IFNULL(A.DV_4,0) + IFNULL(A.DV_5,0)																	");
		sql.append("        			WHEN 0 																																				 			");
		sql.append("        			THEN ''																																				 			");
		sql.append("        			ELSE CONCAT('(', LTRIM(CAST(IFNULL(A.DV_1,0) AS CHAR)), '-', LTRIM(CAST(IFNULL(A.DV_2,0) AS CHAR)), '-',														");
		sql.append("                				LTRIM(CAST(IFNULL(A.DV_3,0) AS CHAR)), '-', LTRIM(CAST(IFNULL(A.DV_4,0) AS CHAR)), '-',																");
		sql.append("                            	LTRIM(CAST(IFNULL(A.DV_5,0) AS CHAR)), ')'																											");
		sql.append("        			 	)																																				 			");
		sql.append("        			END																																			 					");
		sql.append("        	), ''																																									");
		sql.append("        )   																														BOGYONG_NAME,									");
		sql.append("		SUBSTRING(FN_DRG_LOAD_CAUTION_NM(A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v, 'O', '1', :f_hosp_code, :f_language) , 1, 80)      CAUTION_NAME,									");
		sql.append("        IFNULL(A.MIX_YN, '')                                                                                                        MIX_YN,							 				");
		sql.append("        IFNULL(A.ATC_YN, '')                                                                                                        ATC_YN,							 				");
		sql.append("        D.DV                                                                                                                        DV,							 					");
		sql.append("        A.DV_TIME                                                                                                                   DV_TIME,							 			");
		sql.append("        D.DC_YN                                                                                                                     DC_YN,							 				");
		sql.append("        IFNULL(D.BANNAB_YN, '')                                                                                                     BANNAB_YN,							 			");
		sql.append("        IFNULL(D.SOURCE_FKOCS2003, '')                                                                                              SOURCE_FKOCS2003,							 	");
		sql.append("        A.FKOCS2003                                                                                                                 FKOCS2003,							 			");
		sql.append("        IFNULL(DATE_FORMAT(SWF_TruncDate(CURRENT_TIMESTAMP,'DD'),'%Y/%m/%d'), '')                                                   SUNAB_DATE,							 			");
		sql.append("        IFNULL(B.PATTERN, '')                                                                                                       PATTERN,							 			");
		sql.append("        F.HANGMOG_NAME                                                                                                              JAERYO_NAME,							 		");
		sql.append("        '0'                                                                                                                         SUNAB_NALSU,							 		");
		sql.append("        IFNULL(D.WONYOI_ORDER_YN,'N')                                                                                               WONYOI_YN,							 			");
		sql.append("        IFNULL(CONCAT(F.HANGMOG_NAME, ' : ',  TRIM(D.ORDER_REMARK)), '')                                                            ORDER_REMARK,							 		");
		sql.append("        DATE_FORMAT(SWF_TruncDate(CURRENT_TIMESTAMP,'DD'),'%Y/%m/%d')                                                               ACT_DATE,							 			");
		sql.append("        IFNULL(C.MIX_YN_INP,'N')                                                                                                    UI_JUSA_YN,							 			");
		sql.append("        A.SUBUL_SURYANG                                                                         									SUBUL_SURYANG,							 		");
		sql.append("        CONCAT('Rp.', LTRIM(LPAD(:f_serial_v, 2, '0')), CASE A.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END)    						SERIAL_V,							 			");
		sql.append("        FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language)                                               			GWA_NAME,							 			");
		sql.append("        FN_OCS_LOAD_ORDER_DOCTOR_NAME(:f_hosp_code, A.FKOCS2003)                                              						DOCTOR_NAME,							 		");
		sql.append("        FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA, :f_hosp_code)                             						OTHER_GWA,							 			");
		sql.append("        IFNULL(FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE, :f_hosp_code, :f_language), '')                                       HOPE_DATE_2,							 		");
		sql.append("        A.POWDER_YN                                        																			POWDER_YN,							 			");
		sql.append("        IFNULL(:f_serial_v,'1')                                                                   									LINE,							 				");
		sql.append("        FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)                                       			ORD_DANUI2,							 			");
		sql.append("        SUBSTRING(TRIM(A.BUNRYU1), 1, 1)                                                            								BUNRYU1,							 			");
		sql.append("        IFNULL(SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TruncDate(CURRENT_TIMESTAMP,'DD'), 'D'), 1, 20), '')  		HO_DONG,							");
		sql.append("        IFNULL(SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TruncDate(CURRENT_TIMESTAMP,'DD'), 'C'),1,20), '')          HO_CODE,							");
		sql.append("        FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code)                                                                         DONBOK,							 				");
		sql.append("        ''                                                                                     	                                    TUSUK,							 				");
		sql.append("        CASE A.TOIWON_DRG_YN WHEN '1' THEN 'OT' ELSE A.MAGAM_GUBUN END                                                              MAGAM_GUBUN,							 		");
		sql.append("        IFNULL(C.TEXT_COLOR, '')                                                                                                    TEXT_COLOR,							 			");
		sql.append("        IFNULL(C.CHANGGO1, '')                                                                                                      CHANGGO,							 			");
		sql.append("        CONCAT('( ', DATE_FORMAT(A.HOPE_DATE,'%m/%d'))                                                                              FROM_ORDER_DATE,							 	");
		sql.append("        CONCAT(DATE_FORMAT(DATE_ADD(A.HOPE_DATE, INTERVAL A.NALSU - 1 DAY), '%m/%d'), ' )')                                         TO_ORDER_DATE,							 		");
		sql.append("        'A'                                                                                                                         DATA_GUBUN,							 			");
		sql.append("        IFNULL(C.ACT_JAERYO_NAME, F.HANGMOG_NAME)                                                                                   HODONG_ORD_NAME,							 	");
		sql.append("        IFNULL(A.BANNAB_YN, 'N')                                                                                                    MAX_BANNAB_YN							 		");
		sql.append("	FROM							 																																				");
		sql.append("        DRG3010 A JOIN OCS2003 D							 																														");
		sql.append("        	ON D.HOSP_CODE        		= A.HOSP_CODE							 																									");
		sql.append("       		AND D.PKOCS2003        		= A.FKOCS2003							 																									");
		sql.append("            JOIN OCS0103 F							 																																");
		sql.append("       		ON F.HOSP_CODE        		= D.HOSP_CODE							 																									");
		sql.append("       		AND F.HANGMOG_CODE     		= D.HANGMOG_CODE							 																								");
		sql.append("       		LEFT JOIN DRG0120 B							 																															");
		sql.append("       		ON B.HOSP_CODE     			= A.HOSP_CODE							 																									");
		sql.append("       		AND B.BOGYONG_CODE  		= A.BOGYONG_CODE							 																								");
		sql.append("            LEFT JOIN INV0110 C							 																															");
		sql.append("       		ON C.HOSP_CODE     			= A.HOSP_CODE							 																									");
		sql.append("       		AND C.JAERYO_CODE   		= A.JAERYO_CODE							 																									");
		sql.append("	WHERE							 																																				");
		sql.append("    	A.HOSP_CODE        			= :f_hosp_code							 																										");
		sql.append("       	AND A.SOURCE_FKOCS2003 		= :f_fkocs2003							 																										");
		sql.append("       	AND D.ORDER_DATE       		BETWEEN   F.START_DATE AND IFNULL(F.END_DATE, '9998/12/31')							 															");
		sql.append("    ORDER BY							 																																			");
		sql.append("    	A.FKOCS2003							 																																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_serial_v", serialV);
		query.setParameter("f_fkocs2003", fkocs2003);
		
		List<DRG3010P10DsvOrderPrint3Info> listInfo = new JpaResultMapper().list(query, DRG3010P10DsvOrderPrint3Info.class);
		return listInfo;
	}


}
