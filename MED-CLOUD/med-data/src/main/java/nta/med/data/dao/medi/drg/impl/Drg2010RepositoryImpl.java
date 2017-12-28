package nta.med.data.dao.medi.drg.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.drg.Drg2010RepositoryCustom;
import nta.med.data.model.ihis.drgs.*;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.persistence.*;
import java.util.Date;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Drg2010RepositoryImpl implements Drg2010RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Drg2010RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DrgsDRG5100P01OrderListItemInfo> getDrgsDRG5100P01OrderListItemInfo(String hospitalCode, String language, String orderDate, String drgBunho,
			String gubun, String wonyoiYn, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                    ");
		sql.append("          A.BUNHO                             BUNHO                                                                                                ");
		sql.append("         ,A.DRG_BUNHO                         DRG_BUNHO                                                                                            ");
		sql.append("         ,A.NAEWON_DATE                       NAEWON_DATE                                                                                          ");
		sql.append("         ,A.GROUP_SER                         GROUP_SER                                                                                            ");
		sql.append("         ,A.JUBSU_DATE                        JUBSU_DATE                                                                                           ");
		sql.append("         ,A.ORDER_DATE                        ORDER_DATE                                                                                           ");
		sql.append("         ,A.JAERYO_CODE                       JAERYO_CODE                                                                                          ");
		sql.append("         ,A.NALSU                             NALSU                                                                                                ");
		sql.append("         ,A.DIVIDE                            DIVIDE                                                                                               ");
		sql.append("         ,A.ORD_SURYANG                       ORD_SURYANG                                                                                          ");
		sql.append("         ,A.ORDER_SURYANG                     ORDER_SURYANG                                                                                        ");
		sql.append("         ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :hospitalCode, :language) ORDER_DANUI                                                  ");
		sql.append("         ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, :hospitalCode, :language) SUBUL_DANUI                                                  ");
		sql.append("         ,A.GROUP_YN                          GROUP_YN                                                                                             ");
		sql.append("         ,A.JAERYO_GUBUN                      JAERYO_GUBUN                                                                                         ");
		sql.append("         ,A.BOGYONG_CODE                      BOGYONG_CODE                                                                                         ");
		sql.append("         ,CONCAT (B.BOGYONG_NAME, IFNULL(FN_DRG_LOAD_DRG0120_PATTERN('O', A.FKOCS1003, :hospitalCode), '') ) BOGYONG_NAME                          ");
		sql.append("         ,FN_DRG_LOAD_DRG0130( A.CAUTION_CODE, :hospitalCode, :language)   CAUTION_NAME                                                            ");
		sql.append("         ,A.CAUTION_CODE                      CAUTION_CODE                                                                                         ");
		sql.append("         ,A.MIX_YN                            MIX_YN                                                                                               ");
		sql.append("         ,E.ATC_YN                            ATC_YN                                                                                               ");
		sql.append("         ,A.DV                                DV                                                                                                   ");
		sql.append("         ,A.DV_TIME                           DV_TIME                                                                                              ");
		sql.append("         ,A.DC_YN                             DC_YN                                                                                                ");
		sql.append("         ,A.BANNAB_YN                         BANNAB_YN                                                                                            ");
		sql.append("         ,A.SOURCE_FKOCS1003                  SOURCE_FKOCS1003                                                                                     ");
		sql.append("         ,A.FKOCS1003                         FKOCS1003                                                                                            ");
		sql.append("         ,A.FKOUT1001                         FKOUT1001                                                                                            ");
		sql.append("         ,A.SUNAB_DATE                        SUNAB_DATE                                                                                           ");
		sql.append("         ,B.PATTERN                           PATTERN                                                                                              ");
		sql.append("         ,Y.HANGMOG_NAME                      JAERYO_NAME                                                                                          ");
		sql.append("         ,(SELECT X.GENERIC_NAME   FROM                                                                                                              ");
		//sql.append("             FROM VW_OCS_GENERIC X                                                                                                                 ");

		sql.append(" ( select distinct A.HOSP_CODE AS HOSP_CODE ,A.HANGMOG_CODE AS HANGMOG_CODE, C.GENERIC_NAME AS GENERIC_NAME                   						");
		sql.append("               FROM OCS0109 C INNER JOIN OCS0110 B ON C.HOSP_CODE = B.HOSP_CODE AND C.GENERIC_CODE_ORG = B.GENERIC_CODE_ORG             			");
		sql.append("                              INNER JOIN OCS0103 A ON B.HOSP_CODE = A.HOSP_CODE AND B.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE                				");
		sql.append("                              WHERE  B.HOSP_CODE = :hospitalCode                                                                            		");
		sql.append("            union all                                                                                                                  				");
		sql.append("            select distinct A.HOSP_CODE AS HOSP_CODE ,A.HANGMOG_CODE AS HANGMOG_CODE, C.GENERIC_NAME AS GENERIC_NAME                   				");
		sql.append("            FROM OCS0109 C INNER JOIN OCS0103 A ON C.HOSP_CODE = A.HOSP_CODE AND C.GENERIC_CODE = A.YAK_KIJUN_CODE_SHORT               				");
		sql.append("            WHERE C.HOSP_CODE = :hospitalCode AND                                                                                           		");
		sql.append("                 (not (exists(SELECT NULL FROM OCS0110 Z                                                                               				");
		sql.append("                                WHERE Z.HOSP_CODE = A.HOSP_CODE AND                                                                    				");
		sql.append("                                Z.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE)))) X                                                              				");

		sql.append("            WHERE HOSP_CODE = A.HOSP_CODE                                                                                                          ");
		sql.append("              AND X.HANGMOG_CODE = (SELECT Z.HANGMOG_CODE                                                                                          ");
		sql.append("                                      FROM OCS0103 Z                                                                                               ");
		sql.append("                                     WHERE Z.HOSP_CODE = A.HOSP_CODE                                                                               ");
		sql.append("                                       AND Z.HANGMOG_CODE = A.JAERYO_CODE                                                                          ");
		sql.append("                                       AND SYSDATE() BETWEEN Z.START_DATE AND Z.END_DATE)) GENERIC_NAME                                            ");                                          
		sql.append("         ,IFNULL(A.SUNAB_NALSU,0)                SUNAB_NALSU                                                                                       ");
		sql.append("         ,IFNULL(A.WONYOI_ORDER_YN,'N')          WONYOI_YN                                                                                         ");
		sql.append("         ,TRIM(D.ORDER_REMARK)                REMARK                                                                                               ");
		sql.append("         ,A.ACT_DATE                          ACT_DATE                                                                                             ");
		sql.append("         ,A.BUNRYU2                           MAYAK                                                                                                ");
		sql.append("         ,A.TPN_JOJE_GUBUN                    TPN_JOJE_GUBUN                                                                                       ");
		sql.append("         ,IFNULL(C.MIX_YN_INP,'N')               UI_JUSA_YN                                                                                        ");
		sql.append("         ,A.SUBUL_SURYANG                     SUBUL_SURYANG                                                                                        ");
		sql.append("         ,E.SERIAL_V                          SERIAL_V                                                                                             ");
		sql.append("         ,A.POWDER_YN                         POWDER_YN                                                                                            ");
		sql.append("         ,IFNULL(A.GYUNBON_YN, 'N')              GYUNBON_YN                                                                                        ");
		sql.append("         ,IFNULL(A.PRINT_YN, 'N')                PRINT_YN                                                                                          ");
		sql.append("         ,IFNULL(A.GYUNBON_YN, 'N')              OLD_GYUNBON_YN                                                                                    ");
		sql.append("         ,G.ORDER_REMARK                      ORDER_REMARK                                                                                         ");
		sql.append("         ,G.DRG_REMARK                        DRG_REMARK                                                                                           ");
		sql.append("         ,A.HUBAL_CHANGE_YN                   HUBAK_CHANGE_YN                                                                                      ");
		sql.append("         ,A.PHARMACY                          PHARMACY                                                                                             ");
		sql.append("         ,A.DRG_PACK_YN                       DRG_PACK_YN                                                                                          ");
		sql.append("         ,D.MIX_GROUP                         MIX_GROUP                                                                                            ");
		sql.append("         ,D.HOPE_DATE                         HOPE_DATE                                                                                            ");
		sql.append("         ,D.ORDER_GUBUN                       ORDER_GUBUN                                                                                          ");
		sql.append("         ,A.BUNRYU1                           BUNRYU1                                                                                              ");
		sql.append("     FROM DRG2010 A                                                                                                                                ");
		sql.append("     LEFT JOIN DRG0120 B ON :hospitalCode = A.HOSP_CODE AND B.BOGYONG_CODE = A.BOGYONG_CODE AND B.LANGUAGE = :language AND B.HOSP_CODE = :hospitalCode   ");
		sql.append("     LEFT JOIN INV0110 C ON C.HOSP_CODE = A.HOSP_CODE AND C.JAERYO_CODE = A.JAERYO_CODE                                                            ");
		sql.append("     INNER JOIN OCS1003 D ON D.HOSP_CODE = A.HOSP_CODE AND D.PKOCS1003 = A.FKOCS1003                                                               ");
		sql.append("     LEFT JOIN DRG2030 E ON E.HOSP_CODE = A.HOSP_CODE AND E.FKOCS1003 = A.FKOCS1003 AND E.JUBSU_DATE = A.ORDER_DATE AND E.DRG_BUNHO = A.DRG_BUNHO  ");
		sql.append("     LEFT JOIN DRG9042 G ON G.IN_OUT_GUBUN = 'O' AND G.HOSP_CODE = A.HOSP_CODE AND G.FKOCS = A.FKOCS1003                                           ");
		sql.append("     LEFT JOIN OCS0103 Y ON Y.HOSP_CODE = A.HOSP_CODE AND Y.HANGMOG_CODE = A.JAERYO_CODE AND A.JUBSU_DATE BETWEEN Y.START_DATE AND Y.END_DATE      ");
		sql.append("   WHERE A.HOSP_CODE  = :hospitalCode                                                                                                              ");
		sql.append("      AND A.ORDER_DATE = STR_TO_DATE(:orderDate, '%Y/%m/%d')                                                                                       ");
		sql.append("      AND A.DRG_BUNHO  = :drgBunho                                                                                                                 ");
		sql.append("      AND ((:gubun = '1' AND IFNULL(A.PRINT_YN,'N') = 'N') OR (:gubun = '2' AND IFNULL(A.PRINT_YN,'N') = 'Y') OR (:gubun = '3'))                   ");
		sql.append("      AND IFNULL(A.WONYOI_ORDER_YN, 'N') = :wonyoiYn                                                                                               ");
		sql.append("      AND A.BUNHO  = :bunho                                                                                                                        ");
		sql.append("      AND A.SOURCE_FKOCS1003 IS NULL                                                                                                               ");
		sql.append("      AND A.JUNDAL_PART     IN ('PA')                                                                                                              ");
		sql.append("    ORDER BY CAST(E.SERIAL_V AS SIGNED), A.FKOCS1003;                                                                                              ");
		                                                                                                                                                   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		query.setParameter("orderDate", orderDate);
		query.setParameter("drgBunho", drgBunho);
		query.setParameter("gubun", gubun);
		query.setParameter("wonyoiYn", wonyoiYn);
		query.setParameter("bunho", bunho);
		
		List<DrgsDRG5100P01OrderListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01OrderListItemInfo.class);
		return list;
	}
	
	@Override
	public List<DrgsDRG5100P01AutoJubsuListItemInfo> getDrgsDRG5100P01AutoJubsuListItemInfo(String hospitalCode, String gwa, 
			Date fromDate, Date toDate, String gubun, String wonyoiYn, String bunho){
		StringBuilder sql = new StringBuilder();
		if(StringUtils.isEmpty(bunho)) {
			sql.append("SELECT  A.BUNHO                                            BUNHO                                                                      ");
			sql.append("         ,A.ORDER_DATE                                       ORDER_DATE                                                               ");
			sql.append("         ,A.DRG_BUNHO                                        DRG_BUNHO                                                                ");
			sql.append("         ,FN_OUT_LOAD_SUNAME(A.BUNHO, :hospitalCode)         SUNAME                                                                   ");
			sql.append("         ,IF(IFNULL(A.BORYU_YN,'N')='N',' ','Y')            BORYU_YN                                                                  ");
			sql.append("         ,MIN(C.ORDER_REMARK)                                ORDER_REMARK                                                             ");
			sql.append("         ,MIN(C.DRG_REMARK)                                  DRG_REMARK                                                               ");
			sql.append("    FROM DRG2010 A                                                                                                                    ");
			sql.append("     LEFT JOIN DRG9041 C ON C.HOSP_CODE = A.HOSP_CODE AND C.BUNHO = A.BUNHO                                                           ");
			sql.append("     ,OCS1003 B                                                                                                                       ");
			sql.append("     ,OUT1001 D                                                                                                                       ");
			sql.append("    WHERE A.HOSP_CODE                 = :hospitalCode                                                                                 ");
			if(fromDate != null && toDate != null) {
				sql.append("      AND A.ORDER_DATE                BETWEEN :fromDate AND :toDate                                                                   ");
			}
			if(!StringUtils.isEmpty(gwa)) {
				sql.append("      AND A.GWA = :gwa                                                                                                                ");
			}
			if(!StringUtils.isEmpty(wonyoiYn)) {
				sql.append("      AND IFNULL(A.WONYOI_ORDER_YN, 'N') = :wonyoiYn                                                                                 ");
			}
			sql.append("      AND ((:gubun = '1' AND IFNULL(A.PRINT_YN,'N') = 'N') OR (:gubun = '2' AND IFNULL(A.PRINT_YN,'N') = 'Y') OR (:gubun = '3'))      ");
			sql.append("      AND IFNULL(A.DC_YN,'N')            <> 'Y'                                                                                       ");
			sql.append("      AND A.SOURCE_FKOCS1003          IS NULL                                                                                         ");
			sql.append("      AND B.HOSP_CODE                 = A.HOSP_CODE                                                                                   ");
			sql.append("      AND A.FKOCS1003                 = B.PKOCS1003                                                                                   ");
			sql.append("      AND SUBSTR(B.ORDER_GUBUN,2,1)   IN ('C','D','B')                                                                                ");
			sql.append("      AND D.HOSP_CODE                 = B.HOSP_CODE                                                                                   ");
			sql.append("      AND B.FKOUT1001                 = D.PKOUT1001                                                                                   ");
			sql.append("      AND D.NAEWON_YN                 = 'E'                                                                                           ");
			sql.append("    GROUP BY A.BUNHO, A.ORDER_DATE, A.DRG_BUNHO, IF(IFNULL(A.BORYU_YN,'N')='N',' ','Y')                                               ");
		} else {
			sql.append("   SELECT A.BUNHO                                            BUNHO                                                                    ");
			sql.append("         ,A.ORDER_DATE                                       ORDER_DATE                                                               ");
			sql.append("         ,A.DRG_BUNHO                                        DRG_BUNHO                                                                ");
			sql.append("         ,FN_OUT_LOAD_SUNAME(A.BUNHO, :hospitalCode)         SUNAME                                                                   ");
			sql.append("         ,IF(IFNULL(A.BORYU_YN,'N')='N',' ','Y')            BORYU_YN                                                                  ");
			sql.append("         ,MIN(C.ORDER_REMARK)                                ORDER_REMARK                                                             ");
			sql.append("         ,MIN(C.DRG_REMARK)                                  DRG_REMARK                                                               ");
			sql.append("     FROM                                                                                                                             ");
			sql.append("          DRG2010 A                                                                                                                   ");
			sql.append("          LEFT JOIN DRG9041 C ON C.HOSP_CODE = A.HOSP_CODE  AND C.BUNHO = A.BUNHO                                                     ");
			sql.append("         , OUT1001 D                                                                                                                  ");
			sql.append("         , OCS1003 B                                                                                                                  ");
			sql.append("    WHERE A.HOSP_CODE                 = :hospitalCode                                                                                 ");
			sql.append("      AND A.BUNHO                     = :bunho                                                                                        ");
			if(!StringUtils.isEmpty(wonyoiYn)) {
				sql.append("      AND IFNULL(A.WONYOI_ORDER_YN, 'N') = :wonyoiYn                                                                                 ");
			}
			if(!StringUtils.isEmpty(gubun)) {
				sql.append("      AND ((:gubun = '1' AND IFNULL(A.PRINT_YN,'N') = 'N') OR (:gubun = '2' AND IFNULL(A.PRINT_YN,'N') = 'Y') OR (:gubun = '3'))      ");
			}
			sql.append("      AND IFNULL(A.DC_YN,'N')            <> 'Y'                                                                                       ");
			sql.append("      AND A.SOURCE_FKOCS1003          IS NULL                                                                                         ");
			sql.append("      AND B.HOSP_CODE                 = A.HOSP_CODE                                                                                   ");
			sql.append("      AND A.FKOCS1003                 = B.PKOCS1003                                                                                   ");
			sql.append("      AND SUBSTR(B.ORDER_GUBUN,2,1)   IN ('C','D','B')                                                                                ");
			sql.append("      AND D.HOSP_CODE                 = B.HOSP_CODE                                                                                   ");
			sql.append("      AND B.FKOUT1001                 = D.PKOUT1001                                                                                   ");
			sql.append("      AND D.NAEWON_YN                 = 'E'                                                                                           ");
			sql.append("    GROUP BY A.BUNHO, A.ORDER_DATE, A.DRG_BUNHO, IF(IFNULL(A.BORYU_YN,'N')='N',' ','Y')                                               ");
			sql.append("    ORDER BY 2 DESC, 3 DESC                                                                                                           ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if(!StringUtils.isEmpty(gwa)) {
			query.setParameter("gwa", gwa);
		}
		if(StringUtils.isEmpty(bunho)) {
			if(fromDate != null && toDate != null) {
				query.setParameter("fromDate", fromDate);
				query.setParameter("toDate", toDate);
			}
		} else {
			query.setParameter("bunho", bunho);
		}
		if(!StringUtils.isEmpty(gubun)) {
			query.setParameter("gubun", gubun);
		}
		if(!StringUtils.isEmpty(wonyoiYn)) {
			query.setParameter("wonyoiYn", wonyoiYn);
		}
		
		List<DrgsDRG5100P01AutoJubsuListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01AutoJubsuListItemInfo.class);
		return list;
	}
	@Override
	public List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> getDrgsDRG5100P01DrgwonneaOWnCurList(String hospCode, String language,
			String jubsuDate, String drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                                        ");
		sql.append("         A.BUNHO                                                                        BUNHO                                                                          ");
		sql.append("        ,LTRIM(A.DRG_BUNHO)                                                    DRG_BUNHO                                                                               ");
		sql.append("        ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.NAEWON_DATE, :f_hosp_code, :f_language )                              NAEWON_DATE                                         ");
		sql.append("        ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                             JUBSU_DATE                                                                   ");
		sql.append("        ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE, :f_hosp_code, :f_language)                                ORDER_DATE                                          ");
		//sql.append("        ,CONCAT('Rp.',E.SERIAL_V,IF(A.MIX_GROUP IS NULL,'',' M'))                             SERIAL_V                                                                 ");
		sql.append("        ,CONCAT('Rp.',E.SERIAL_V,IF(A.MIX_GROUP IS NULL OR A.MIX_GROUP = '','',' M'))                             SERIAL_V                                             ");
		sql.append("        ,E.SERIAL_V                                                                     SERIAL_TEXT                                                                    ");
		sql.append("        ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language)                                      GWA_NAME                                            ");
		sql.append("        ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, :f_hosp_code)                                DOCTOR_NAME                                                      ");
		sql.append("        ,F.SUNAME                                                                       SUNAME                                                                         ");
		sql.append("        ,F.SUNAME2                                                                      SUNAME2                                                                        ");
		sql.append("        ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH, :f_hosp_code, :f_language )                                    BIRTH                                               ");
		sql.append("        ,F.SEX                                                                          SEX_AGE                                                                        ");
		sql.append("        ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.NAEWON_DATE, A.GWA, :f_hosp_code)                   OTHER_GWA                                                        ");
		sql.append("        ,FN_DRG_DO_ORDER(A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, 'O', A.DRG_BUNHO,'11', :f_hosp_code)     DO_ORDER                                                    ");
		sql.append("        ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', DATE_ADD(A.NAEWON_DATE,INTERVAL 3 DAY) , :f_hosp_code, :f_language)                   GIGAM_DATE                            ");
		sql.append("        ,N.ADDRESS                                                                      ADDRESS                                                                        ");
		sql.append("        ,N.TEL                                                                          TEL                                                                            ");				
		sql.append("    FROM DRG2010 A LEFT OUTER JOIN DRG0120 B ON :f_hosp_code = A.HOSP_CODE AND B.BOGYONG_CODE = A.BOGYONG_CODE  AND B.LANGUAGE = :f_language  AND B.HOSP_CODE = :f_hosp_code  ");
		sql.append("                   LEFT OUTER JOIN INV0110 C ON C.HOSP_CODE = A.HOSP_CODE AND C.JAERYO_CODE = A.JAERYO_CODE                                                            ");
		sql.append("                   JOIN OCS1003 D ON D.HOSP_CODE = A.HOSP_CODE AND D.PKOCS1003 = A.FKOCS1003                                                                           ");
		sql.append("                   JOIN DRG2030 E ON E.HOSP_CODE = A.HOSP_CODE AND E.JUBSU_DATE = A.ORDER_DATE AND E.DRG_BUNHO = A.DRG_BUNHO AND E.FKOCS1003 = A.FKOCS1003             ");
		sql.append("                   JOIN OUT0101 F ON F.HOSP_CODE = A.HOSP_CODE AND F.BUNHO = A.BUNHO                                                                                   ");										
		sql.append("        		   JOIN BAS0001 N ON N.HOSP_CODE = A.HOSP_CODE AND N.LANGUAGE = :f_language  																		   ");
		sql.append(" 							AND N.START_DATE = (SELECT MAX(N1.START_DATE) FROM BAS0001 N1 WHERE N1.HOSP_CODE = N.HOSP_CODE AND N1.LANGUAGE = N.LANGUAGE)			   ");	
		sql.append("   WHERE A.HOSP_CODE                = :f_hosp_code                                                                                                                     ");
		sql.append("     AND A.ORDER_DATE               = DATE_FORMAT(:f_jubsu_date, '%Y/%m/%d')                                                                                           ");
		sql.append("     AND A.DRG_BUNHO                = :f_drg_bunho                                                                                                                     ");
		sql.append("     AND A.SOURCE_FKOCS1003         IS NULL                                                                                                                            ");
		sql.append("     AND IFNULL(A.DC_YN,'N')           = 'N'                                                                                                                           ");
		sql.append("     AND IFNULL(A.BANNAB_YN,'N')       = 'N'                                                                                                                           ");
		sql.append("     AND IFNULL(A.WONYOI_ORDER_YN,'N') = 'N'                                                                                                                           ");
		sql.append("     AND A.JUNDAL_PART   = 'PA'                                                                                                                                        ");
		sql.append("   ORDER BY 6                                                                                                                                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01DrgwonneaOWnCurListInfo.class);
		return list;
		
	}
	
	@Override
	public List<DrgsDRG5100P01WnSerialQryListItemInfo> getDrgsDRG5100P01WnSerialQryListItem(String hospCode, String language, String jubsuDate, String drgBunho
			,String oSerialText){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                                                                       ");
		sql.append("           A.GROUP_SER                                                                                      GROUP_SER                                                                                 ");
		sql.append("          ,A.JAERYO_CODE                                                                                    JAERYO_CODE                                                                               ");
		sql.append("          ,IF(A.BUNRYU1 = '6', 0, IF(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code) = 'Y', A.DV,A.NALSU))        NALSU                                                                           ");
		sql.append("          ,A.DIVIDE                                                                                         DIVIDE                                                                                    ");
		sql.append("          ,A.ORD_SURYANG                                                                                    DRG_ORDER_SURYANG                                                                         ");
		sql.append("          ,A.ORDER_SURYANG                                                                                  ORDER_SURYANG                                                                             ");
		sql.append("          ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, :f_hosp_code, :f_language)                                                  DRG_ORDER_DANUI                                                ");
		sql.append("          ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language)                                                SUBUL_DANUI                                                    ");
		sql.append("          ,A.GROUP_YN                                                                                       GROUP_YN                                                                                  ");
		sql.append("          ,A.JAERYO_GUBUN                                                                                   JAERYO_GUBUN                                                                              ");
		sql.append("          ,A.BOGYONG_CODE                                                                                   BOGYONG_CODE                                                                              ");
		sql.append("          ,CONCAT(IFNULL(TRIM(CASE A.BUNRYU1 WHEN '4' THEN IFNULL(FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O',NULL, :f_hosp_code),'')                                               ");
		sql.append("                                      WHEN '6' THEN IFNULL(FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O',NULL, :f_hosp_code),'') END ) ,'')                                          ");
		sql.append("           ,' ', IFNULL(TRIM(B.BOGYONG_NAME),'') , IFNULL(FN_DRG_LOAD_RP_TEXT('O', E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, :f_hosp_code),'')                                                                      ");
		sql.append("           ,' ',IFNULL(FN_DRG_LOAD_DRG0120_PATTERN('O', A.FKOCS1003, :f_hosp_code),''))                                             BOGYONG_NAME                                                      ");
		sql.append("          ,''                                                                                               CAUTION_NAME                                                                              ");
		sql.append("          ,A.CAUTION_CODE                                                                                   CAUTION_CODE                                                                              ");
		sql.append("          ,IF(A.MIX_GROUP IS NULL,'N','Y')                                                                 MIX_YN                                                                                     ");
		sql.append("          ,E.ATC_YN                                                                                         ATC_YN                                                                                    ");
		sql.append("          ,A.DV                                                                                             DV                                                                                        ");
		sql.append("          ,A.DV_TIME                                                                                        DV_TIME                                                                                   ");
		sql.append("          ,A.DC_YN                                                                                          DC_YN                                                                                     ");
		sql.append("          ,A.BANNAB_YN                                                                                      BANNAB_YN                                                                                 ");
		sql.append("          ,A.SOURCE_FKOCS1003                                                                               SOURCE_FKOCS1003                                                                          ");
		sql.append("          ,A.FKOCS1003                                                                                      FKOCS1003                                                                                 ");
		sql.append("          ,DATE_FORMAT(A.SUNAB_DATE,'%Y/%m/%d')                                                               SUNAB_DATE                                                                              ");
		sql.append("          ,B.PATTERN                                                                                        PATTERN                                                                                   ");
		sql.append("          ,C.JAERYO_NAME                                                                                    JAERYO_NAME                                                                               ");
		sql.append("          ,IFNULL(A.SUNAB_NALSU,0)                                                                             SUNAB_NALSU                                                                            ");
		sql.append("          ,IFNULL(A.WONYOI_ORDER_YN,'N')                                                                       WONYOI_YN                                                                              ");
		sql.append("          ,DATE_FORMAT(A.ACT_DATE,'%Y/%m/%d')                                                                 ACT_DATE                                                                                ");
		sql.append("          ,A.BUNRYU2                                                                                        MAYAK                                                                                     ");
		sql.append("          ,A.TPN_JOJE_GUBUN                                                                                 TPN_JOJE_GUBUN                                                                            ");
		sql.append("          ,IFNULL(C.MIX_YN_INP,'N')                                                                            UI_JUSA_YN                                                                             ");
		sql.append("          ,A.SUBUL_SURYANG                                                                                  SUBUL_SURYANG                                                                             ");
		//sql.append("          ,CONCAT('Rp.',E.SERIAL_V,IF(A.MIX_GROUP IS NULL,'',' M') )                                              SERIAL_V                                                                            ");
		sql.append("          ,CONCAT('Rp.',E.SERIAL_V,IF(A.MIX_GROUP IS NULL OR A.MIX_GROUP = '','',' M'))                             SERIAL_V                                                                          ");
		sql.append("          ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language)                             GWA_NAME                                                                                  ");
		sql.append("          ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, :f_hosp_code)                                    DOCTOR_NAME                                                                               ");
		sql.append("          ,F.SUNAME                                                                                         SUNAME                                                                                    ");
		sql.append("          ,F.SUNAME2                                                                                        SUNAME2                                                                                   ");
		sql.append("          ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH, :f_hosp_code, :f_language )                           BIRTH                                                                                     ");
		sql.append("          ,F.SEX                                                                                            SEX_AGE                                                                                   ");
		sql.append("          ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.NAEWON_DATE, A.GWA, :f_hosp_code)                        OTHER_GWA                                                                                ");
		sql.append("          ,FN_DRG_DO_ORDER(A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, 'O', A.DRG_BUNHO,'11', :f_hosp_code)                       DO_ORDER                                                               ");
		sql.append("          ,FN_BAS_TO_JAPAN_DATE_CONVERT('5', D.HOPE_DATE, :f_hosp_code, :f_language)                                                  HOPE_DATE                                                       ");
		sql.append("          ,FN_DRG_POWDER_YN(E.JUBSU_DATE, E.DRG_BUNHO, 'O', :f_hosp_code)                                                 POWDER_YN                                                                   ");
		sql.append("          ,E.SERIAL_V                                                                                       LINE                                                                                      ");
		sql.append("          ,TRIM(C.KYUKYEOK)                                                                                 KYUKYEOK                                                                                  ");
		sql.append("          ,CASE FN_DRG_MAYAK_CHK(A.JUBSU_DATE, A.DRG_BUNHO, 'O', :f_hosp_code) WHEN 'Y'                                                                                                               ");
		sql.append("                  THEN SUBSTR(TRIM(FN_DRG_DOCTOR_LICENSE(A.DOCTOR, DATE_FORMAT(SYSDATE(),'%Y/%m/%d'),'Y',:f_hosp_code,:f_language)),1,20) END                 LICENSE                                 ");
		sql.append("          ,A.MIX_GROUP                                                                                      MIX_GROUP                                                                                 ");
		sql.append("          ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code)                                                            DONBOK                                                                      ");
		sql.append("          ,''                                                                                               TUSUK                                                                                     ");
		sql.append("          ,FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ,'2', :f_hosp_code, :f_language)                          CAUTION_NM                                                     ");
		sql.append("          ,FN_OCS_LOAD_ORDER_SORT('O', D.INPUT_GUBUN, D.ORDER_GUBUN, D.GROUP_SER,                                                                                                                     ");
		sql.append("                                       D.MIX_GROUP,   D.SEQ,         D.PKOCS1003,NULL, :f_hosp_code)                           ORDER_SORT                                                             ");
		sql.append("          ,C.TEXT_COLOR                                                                                     TEXT_COLOR                                                                                ");
		sql.append("          ,C.CHANGGO1                                                                                       CHANGGO                                                                                   ");
		sql.append("          ,A.HUBAL_CHANGE_YN                                                                                HUBAL_CHANGE_YN                                                                           ");
		sql.append("          ,FN_DRG_LOAD_HUBAL_ALL(A.ORDER_DATE, A.DRG_BUNHO, :f_hosp_code)                                                 HUBAL_ALL_YN                                                                ");
		sql.append("      FROM OUT0101 F                                                                                                                                                                                  ");
		sql.append("          ,DRG2030 E                                                                                                                                                                                  ");
		sql.append("          ,OCS1003 D                                                                                                                                                                                  ");
		sql.append("          ,DRG2010 A LEFT OUTER JOIN DRG0120 B ON :f_hosp_code = A.HOSP_CODE AND B.BOGYONG_CODE = A.BOGYONG_CODE  AND B.LANGUAGE = :f_language  AND B.HOSP_CODE = :f_hosp_code                        ");
		sql.append("                     LEFT OUTER JOIN INV0110 C ON C.HOSP_CODE = A.HOSP_CODE AND C.JAERYO_CODE = A.JAERYO_CODE                                                                                         ");
		sql.append("     WHERE A.HOSP_CODE                = :f_hosp_code                                                                                                                                                  ");
		sql.append("       AND A.ORDER_DATE               = DATE_FORMAT(:f_jubsu_date, '%Y/%m/%d')                                                                                                                        ");
		sql.append("       AND A.DRG_BUNHO                = :f_drg_bunho                                                                                                                                                  ");
		sql.append("       AND A.SOURCE_FKOCS1003         IS NULL                                                                                                                                                         ");
		sql.append("       AND IFNULL(A.DC_YN,'N')           = 'N'                                                                                                                                                        ");
		sql.append("       AND IFNULL(A.BANNAB_YN,'N')       = 'N'                                                                                                                                                        ");
		sql.append("       AND A.JUNDAL_PART              = 'PA'                                                                                                                                                          ");
		sql.append("       AND D.HOSP_CODE                = A.HOSP_CODE                                                                                                                                                   ");
		sql.append("       AND D.PKOCS1003                = A.FKOCS1003                                                                                                                                                   ");
		sql.append("       AND E.HOSP_CODE                = A.HOSP_CODE                                                                                                                                                   ");
		sql.append("       AND E.JUBSU_DATE               = A.ORDER_DATE                                                                                                                                                  ");
		sql.append("       AND E.DRG_BUNHO                = A.DRG_BUNHO                                                                                                                                                   ");
		sql.append("       AND F.HOSP_CODE                = A.HOSP_CODE                                                                                                                                                   ");
		sql.append("       AND E.FKOCS1003                = A.FKOCS1003                                                                                                                                                   ");
		sql.append("       AND E.SERIAL_V                 = :o_serial_text                                                                                                                                                ");
		sql.append("       AND F.BUNHO                    = A.BUNHO                                                                                                                                                       ");
		sql.append("     ORDER BY E.SERIAL_V, A.MIX_GROUP, A.FKOCS1003                                                                                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("o_serial_text", oSerialText);
		
		List<DrgsDRG5100P01WnSerialQryListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01WnSerialQryListItemInfo.class);
		return list;
	}
	
	@Override
	public String getDrgsDRG5100P01SetNumberRowInsert(String bogyongName){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT ROUND(length(IFNULL(:bogyongName,' ')) / 60) CNT ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("bogyongName", bogyongName);
		
		List<Object> list = query.getResultList();
		if(list != null){
			return list.get(0).toString();
		}
		return null;
	}
	
	@Override
	public String getDrgsDRG5100P01GetBogyongName(String bogyongName, String b){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT SUBSTR(:bogyongName, (:b * 60) + 1, 60) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("bogyongName", bogyongName);
		query.setParameter("b", b);
		
		List<Object> list = query.getResultList();
		if(list != null){
			return list.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<DrgsDRG5100P01OrderJungboListItemInfo> getDrgsDRG5100P01OrderJungboListItem(String hospCode, String language, String jubsuDate, String drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT '1'                SEQ_1                                                                                                  ");
		sql.append("        ,D.SERIAL_V         SEQ_2                                                                                                  ");
		sql.append("        ,C.JAERYO_NAME      TEXT_1                                                                                                 ");
		sql.append("        ,'TEXT_2'                 TEXT_2                                                                                                 ");
		sql.append("        ,'TEXT_3'                 TEXT_3                                                                                                 ");
		sql.append("        ,B.ORDER_REMARK     REMARK                                                                                                 ");
		sql.append("        ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d') , LPAD(A.DRG_BUNHO,4,'0'),'*')   BAR_DRG_BUNHO                              ");
		sql.append("        ,A.BUNHO            BUNHO                                                                                                  ");
		sql.append("    FROM                                                                                                                           ");
		sql.append("        DRG9042 B                                                                                                                  ");
		sql.append("        ,DRG2010 A LEFT OUTER JOIN INV0110 C ON C.HOSP_CODE = A.HOSP_CODE AND C.JAERYO_CODE = A.JAERYO_CODE                        ");
		sql.append("                   LEFT OUTER JOIN DRG2030 D ON D.HOSP_CODE = A.HOSP_CODE AND D.FKOCS1003 = A.FKOCS1003                            ");
		sql.append("   WHERE A.HOSP_CODE      = :f_hosp_code                                                                                           ");
		sql.append("     AND A.ORDER_DATE     = DATE_FORMAT(:f_jubsu_date, '%Y/%m/%d')                                                                 ");
		sql.append("     AND A.DRG_BUNHO      = :f_drg_bunho                                                                                           ");
		sql.append("     AND B.HOSP_CODE      = A.HOSP_CODE                                                                                            ");
		sql.append("     AND B.FKOCS          = A.FKOCS1003                                                                                            ");
		sql.append("     AND B.ORDER_REMARK   IS NOT NULL                                                                                              ");
		sql.append("  UNION ALL                                                                                                                        ");
		sql.append("  SELECT DISTINCT '1'       SEQ_1                                                                                                  ");
		sql.append("        ,'SEQ_2'                 SEQ_2                                                                                                  ");
		sql.append("        ,C.JAERYO_NAME      TEXT_1                                                                                                 ");
		sql.append("        ,'TEXT_2'                 TEXT_2                                                                                                 ");
		sql.append("        ,'TEXT_3'                 TEXT_3                                                                                                 ");
		sql.append("        ,CONCAT('[' , FN_ADM_MSG(4111,:f_language) , ']' , C.DRG_COMMENT) REMARK                                                   ");
		sql.append("        ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d') , LPAD(A.DRG_BUNHO,4,'0'),'*')   BAR_DRG_BUNHO                              ");
		sql.append("        ,A.BUNHO            BUNHO                                                                                                  ");
		sql.append("    FROM                                                                                                                           ");
		sql.append("        DRG2010 A LEFT OUTER JOIN INV0110 C ON C.HOSP_CODE = A.HOSP_CODE AND C.JAERYO_CODE = A.JAERYO_CODE                         ");
		sql.append("                   LEFT OUTER JOIN DRG2030 D ON D.HOSP_CODE = A.HOSP_CODE AND D.FKOCS1003 = A.FKOCS1003                            ");
		sql.append("   WHERE A.HOSP_CODE      = :f_hosp_code                                                                                           ");
		sql.append("     AND A.ORDER_DATE     = DATE_FORMAT(:f_jubsu_date, '%Y/%m/%d')                                                                 ");
		sql.append("     AND A.DRG_BUNHO      = :f_drg_bunho                                                                                           ");
		sql.append("     AND IFNULL(C.CHKD,'N')  = 'Y'                                                                                                 ");
		sql.append("  UNION ALL                                                                                                                        ");
		sql.append("  SELECT DISTINCT                                                                                                                  ");
		sql.append("         '2'                SEQ_1                                                                                                  ");
		sql.append("        ,'SEQ_2'                 SEQ_2                                                                                                  ");
		sql.append("        ,'##'               TEXT_1                                                                                                 ");
		sql.append("        ,'TEXT_2'                 TEXT_2                                                                                                 ");
		sql.append("        ,'TEXT_3'                 TEXT_3                                                                                                 ");
		sql.append("        ,B.ORDER_REMARK     REMARK                                                                                                 ");
		sql.append("        ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d') , LPAD(A.DRG_BUNHO,4,'0'),'*')   BAR_DRG_BUNHO                              ");
		sql.append("        ,A.BUNHO            BUNHO                                                                                                  ");
		sql.append("    FROM DRG9040 B                                                                                                                 ");
		sql.append("        ,DRG2010 A                                                                                                                 ");
		sql.append("   WHERE A.HOSP_CODE   = :f_hosp_code                                                                                              ");
		sql.append("     AND A.ORDER_DATE  = DATE_FORMAT(:f_jubsu_date, '%Y/%m/%d')                                                                    ");
		sql.append("     AND A.DRG_BUNHO   = :f_drg_bunho                                                                                              ");
		sql.append("     AND B.HOSP_CODE   = A.HOSP_CODE                                                                                               ");
		sql.append("     AND B.ORDER_DATE  = A.ORDER_DATE                                                                                              ");
		sql.append("     AND B.DRG_BUNHO   = A.DRG_BUNHO                                                                                               ");
		sql.append("     AND B.ORDER_REMARK IS NOT NULL                                                                                                ");
		sql.append("  UNION ALL                                                                                                                        ");
		sql.append("  SELECT DISTINCT                                                                                                                  ");
		sql.append("         '3'                SEQ_1                                                                                                  ");
		sql.append("        ,'SEQ_2'                 SEQ_2                                                                                                  ");
		sql.append("        ,IF(B.BUNHO IS NULL,'','$$')  TEXT_1                                                                                       ");
		sql.append("        ,'TEXT_2'                 TEXT_2                                                                                                 ");
		sql.append("        ,'TEXT_3'                 TEXT_3                                                                                                 ");
		sql.append("        ,B.ORDER_REMARK     REMARK                                                                                                 ");
		sql.append("        ,CONCAT('*',DATE_FORMAT(A.JUBSU_DATE,'%Y%m%d'), LPAD(A.DRG_BUNHO,4,'0'),'*')   BAR_DRG_BUNHO                               ");
		sql.append("        ,A.BUNHO            BUNHO                                                                                                  ");
		sql.append("    FROM                                                                                                                           ");
		sql.append("        DRG2010 A LEFT OUTER JOIN DRG9041 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                     ");
		sql.append("   WHERE A.HOSP_CODE     = :f_hosp_code                                                                                            ");
		sql.append("     AND A.ORDER_DATE    = DATE_FORMAT(:f_jubsu_date, '%Y/%m/%d')                                                                  ");
		sql.append("     AND A.DRG_BUNHO     = :f_drg_bunho                                                                                            ");
		sql.append("     AND B.ORDER_REMARK IS NOT NULL                                                                                                ");
		sql.append("   ORDER BY 1, 2                                                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DrgsDRG5100P01OrderJungboListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01OrderJungboListItemInfo.class);
		return list;
	}
	
	@Override
	public String getDrgsDRG5100P01SetBarDrgBunho(String hospCode, String jubsuDate, String drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT CONCAT('*',DATE_FORMAT(A.ORDER_DATE,'%Y%m%d') , LPAD(A.DRG_BUNHO,4,'0'), '*')  ");
		sql.append("  FROM DRG2010 A                                                                               ");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                                                            ");
		sql.append("   AND A.ORDER_DATE  = DATE_FORMAT(:f_jubsu_date, '%Y/%m/%d')                                  ");
		sql.append("   AND A.DRG_BUNHO   = :f_drg_bunho                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<Object> list = query.getResultList();
		if(list != null){
			return list.get(0).toString();
		}
		return null;
	}
	
	@Override
	public DrgsDRG5100P01JungboListInfo getDrgsDRG5100P01JungboListInfo(String hospCode, String bunho, String comments){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(FN_NUR_LOAD_WEIGHT_HEIGHT('H', :f_bunho, :f_hosp_code), 0) HEIGHT     ");
		sql.append("       , 'Cm'                                             CM                         ");
		sql.append("       , IFNULL(FN_NUR_LOAD_WEIGHT_HEIGHT('W', :f_bunho, :f_hosp_code), 0) WEIGHT    ");
		sql.append("       , 'Kg'                                             KG                         ");
		sql.append("       , FN_CPL_HANGMOG_RESULT(:f_bunho, '00077', :f_hosp_code)         CPL_RESULT   ");
		sql.append("       , FN_ADM_CONVERT_KATAKANA_FULL(:f_comments, :f_hosp_code)        COMMENTS     ");
		sql.append("       , ROUND(LENGTH(IFNULL(:f_comments,' ')) / 80)         CNT                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_comments", comments);
		
		DrgsDRG5100P01JungboListInfo result = new JpaResultMapper().uniqueResult(query, DrgsDRG5100P01JungboListInfo.class);
		return result;
	}
	
	@Override
	public String getDrgsDRG5100P01CommentNumber(String iComment, String rowNumber){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CONCAT('    ' , SUBSTR(:o_comments , :b * 80 + 1, 80))  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("o_comments", iComment);
		query.setParameter("b", rowNumber);
		List<Object> list = query.getResultList();
		if(list != null){
			return list.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<DrgsDRG5100P01LabelListItemInfo> getDrgsDRG5100P01LabelListItemInfo(String hospitalCode, String language, String jubsuDate, String drgBunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT X.ORDER_DATE, X.DANUI, X.DANUI1, X.DRG_BUNHO, X.BUNHO, X.DV, X.DRG_GRP,                                                                                            ");
		sql.append("       X.NAME , X.GWA, X.BOGYONG_CODE, X.BOGYONG_NAME, X.NALSU, X.BUNRYU1,                                                                                                ");
		sql.append("       X.CAUTION_NM, X.JAERYO_NAME, X.GYUNBON_YN, SUM(X.SU), X.RP,X.HOPE_DATE, X.DONBOK                                                                                   ");
		sql.append("  FROM (SELECT B.ORDER_DATE   ORDER_DATE                                                                                                                                  ");
		sql.append("             , FN_DRG_LOAD_CODE_MENT     ('ORD_DANUI', IFNULL(FN_DRG_LABEL_DANUI(B.JAERYO_CODE,'1', :hospitalCode), B.ORDER_DANUI), B.JAERYO_CODE, :hospitalCode) DANUI   ");
		sql.append("             , FN_OCS_LOAD_CODE_GROUP_KEY('ORD_DANUI', IFNULL(FN_DRG_LABEL_DANUI(B.JAERYO_CODE,'2', :hospitalCode), B.ORDER_DANUI), :hospitalCode) DANUI1                 ");
		sql.append("             , B.DRG_BUNHO    DRG_BUNHO                                                                                                                                   ");
		sql.append("             , B.BUNHO        BUNHO                                                                                                                                       ");
		sql.append("             , B.DV           DV                                                                                                                                          ");
		sql.append("             , IF(IFNULL(B.MIX_GROUP, 'N') = 'N', IF(MAX(A.DRG_GRP) < '999.95',LTRIM(ROUND(MAX(A.DRG_GRP),1)), '')                                                        ");
		sql.append("                                                , IF(MAX(A.DRG_GRP) < '99999.95',LTRIM(ROUND(MAX(A.DRG_GRP),1)), '')) DRG_GRP                                             ");
		sql.append("             , FN_OUT_LOAD_SUNAME(B.BUNHO, :hospitalCode)                        NAME                                                                                     ");
		sql.append("             , FN_BAS_LOAD_GWA_NAME(B.GWA, B.ORDER_DATE, :hospitalCode, :language)          GWA                                                                           ");
		sql.append("             , A.BOGYONG_CODE                                     BOGYONG_CODE                                                                                            ");
		sql.append("             , FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE, :hospitalCode)           BOGYONG_NAME                                                                             ");
		sql.append("             , MAX(IF(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :hospitalCode)='Y', B.DV,B.NALSU)) NALSU                                                                      ");
		sql.append("             , SUBSTR(TRIM(B.BUNRYU1),1,1)                       BUNRYU1                                                                                                  ");
		sql.append("                                                                                                                                                                          ");
		sql.append("             , CONCAT(SUBSTR(CONCAT(FN_DRG_LOAD_CAUTION_NM(A.JUBSU_DATE, A.DRG_BUNHO, A.SERIAL_V, 'O', 1,:hospitalCode, :language),                                       ");
		sql.append("             TRIM(FN_DRG_LOAD_REMARK( A.JUBSU_DATE, A.DRG_BUNHO, A.SERIAL_V,  'O','N', :hospitalCode))) ,1,200),                                                          ");
		sql.append("               IF(B.BUNRYU1= '4',FN_OCS_LOAD_CODE_NAME('JUSA', B.JUSA_GUBUN, :hospitalCode, :language),'')) CAUTION_NM                                                    ");
		sql.append("             , ' ' JAERYO_NAME                                                                                                                                            ");
		sql.append("             , IFNULL(B.GYUNBON_YN, 'N')   GYUNBON_YN                                                                                                                     ");
		sql.append("             , SUM(1)                                             SU                                                                                                      ");
		sql.append("             , CONCAT('Rp',A.SERIAL_V)                                   RP                                                                                               ");
		sql.append("             , A.HOPE_DATE    HOPE_DATE                                                                                                                                   ");
		sql.append("             , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :hospitalCode) DONBOK                                                                                                ");
		sql.append("          FROM DRG2010 B                                                                                                                                                  ");
		sql.append("             , DRG2030 A                                                                                                                                                  ");
		sql.append("         WHERE B.HOSP_CODE         = :hospitalCode                                                                                                                        ");
		if(!StringUtils.isEmpty(jubsuDate)) {
			sql.append("         AND B.ORDER_DATE        = STR_TO_DATE(:jubsuDate, '%Y/%m/%d')                                                                                                ");
		}
		if(!StringUtils.isEmpty(drgBunho)) {
			sql.append("         AND B.DRG_BUNHO         = :drgBunho                                                                                                                          ");
		}
		sql.append("           AND B.BUNRYU1           IN ('1','3','8','9')                                                                                                                   ");
		sql.append("           AND B.SOURCE_FKOCS1003  IS NULL                                                                                                                                ");
		sql.append("                                                                                                                                                                          ");
		sql.append("           AND IFNULL(B.DC_YN,'N')    = 'N'                                                                                                                               ");
		sql.append("           AND IFNULL(B.BANNAB_YN,'N')       = 'N'                                                                                                                        ");
		sql.append("           AND IFNULL(B.WONYOI_ORDER_YN,'N') <> 'Y'                                                                                                                       ");
		sql.append("           AND IFNULL(B.MIX_GROUP, 'N')      = 'N'                                                                                                                        ");
		sql.append("           AND A.HOSP_CODE           = B.HOSP_CODE                                                                                                                        ");
		sql.append("           AND B.FKOCS1003           = A.FKOCS1003                                                                                                                        ");
		sql.append("           AND B.ORDER_DATE          = A.JUBSU_DATE                                                                                                                       ");
		sql.append("           AND B.DRG_BUNHO           = A.DRG_BUNHO                                                                                                                        ");
		sql.append("         GROUP BY B.ORDER_DATE , DANUI , DANUI1  , B.DRG_BUNHO, B.BUNHO, B.DV, BUNRYU1, NAME, GWA, A.BOGYONG_CODE                                                         ");
		sql.append("                , BOGYONG_NAME, CAUTION_NM, GYUNBON_YN, RP, HOPE_DATE, DONBOK, B.JAERYO_CODE, B.ORDER_DANUI, B.MIX_GROUP												  ");
		sql.append("      UNION                                                                                                                                                               ");
		sql.append("       SELECT B.ORDER_DATE   ORDER_DATE                                                                                                                                   ");
		sql.append("            ,FN_DRG_LOAD_CODE_MENT     ('ORD_DANUI', IFNULL(FN_DRG_LABEL_DANUI(B.JAERYO_CODE,'1', :hospitalCode), B.ORDER_DANUI), B.JAERYO_CODE, :hospitalCode) DANUI     ");
		sql.append("            ,FN_OCS_LOAD_CODE_GROUP_KEY('ORD_DANUI', IFNULL(FN_DRG_LABEL_DANUI(B.JAERYO_CODE,'2', :hospitalCode), B.ORDER_DANUI), :hospitalCode) DANUI1                   ");
		sql.append("            ,B.DRG_BUNHO                                                                                                                                                  ");
		sql.append("            ,B.BUNHO                                                                                                                                                      ");
		sql.append("            ,B.DV                                                                                                                                                         ");
		sql.append("            ,IF(MAX(A.DRG_GRP) <'99999.95', LTRIM(ROUND(MAX(A.DRG_GRP),1)), '')   DRG_GRP                                                                                 ");
		sql.append("            ,FN_OUT_LOAD_SUNAME(B.BUNHO, :hospitalCode)                          NAME                                                                                     ");
		sql.append("            ,FN_BAS_LOAD_GWA_NAME(B.GWA, B.ORDER_DATE, :hospitalCode, :language)            GWA                                                                           ");
		sql.append("            ,IFNULL(A.BOGYONG_CODE, 'XXX')                           BOGYONG_CODE                                                                                         ");
		sql.append("            ,CONCAT(TRIM(FN_DRG_LOAD_REMARK(A.JUBSU_DATE, A.DRG_BUNHO, A.SERIAL_V, 'O', 'N', :hospitalCode)),                                                             ");
		sql.append("            TRIM(IF(B.BUNRYU1 = '6', FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE, :hospitalCode),'')))  BOGYONG_NAME                                                          ");
		sql.append("            ,0                                                    NALSU                                                                                                   ");
		sql.append("            ,SUBSTR(TRIM(B.BUNRYU1),1,1)                         BUNRYU1                                                                                                  ");
		sql.append("            ,CONCAT(TRIM(FN_DRG_LOAD_CAUTION_NM(A.JUBSU_DATE, A.DRG_BUNHO, A.SERIAL_V, 'O',1, :hospitalCode, :language)),                                                 ");
		sql.append("             IF(B.BUNRYU1 = '4',FN_OCS_LOAD_CODE_NAME('JUSA', B.JUSA_GUBUN, :hospitalCode, :language),''))   CAUTION_NM                                                   ");
		sql.append("            ,CONCAT (SUBSTR(TRIM(FN_INV_LOAD_JAERYO_NAME(B.JAERYO_CODE, '1', :hospitalCode)), 36), '  ',                                                                  ");
		sql.append("             CASE WHEN B.ORD_SURYANG >0 AND B.ORD_SURYANG  < 1 THEN  IF(B.ORD_SURYANG < '9.950', LTRIM(ROUND(B.ORD_SURYANG,1)), '')                                       ");
		sql.append("                  ELSE LTRIM(ROUND(B.ORD_SURYANG))  END, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORDER_DANUI, :hospitalCode, :language)) JAERYO_CODE                         ");
		sql.append("            ,IFNULL(B.GYUNBON_YN, 'N')                            GYUNBON_YN                                                                                              ");
		sql.append("            ,0                                                    SU                                                                                                      ");
		sql.append("            ,CONCAT('Rp',A.SERIAL_V)                                     RP                                                                                               ");
		sql.append("            ,A.HOPE_DATE HOPE_DATE                                                                                                                                        ");
		sql.append("            ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :hospitalCode) DONBOK                                                                                                  ");
		sql.append("        FROM DRG2010 B                                                                                                                                                    ");
		sql.append("            ,DRG2030 A                                                                                                                                                    ");
		sql.append("       WHERE B.HOSP_CODE         = :hospitalCode                                                                                                                          ");
		if(!StringUtils.isEmpty(jubsuDate)) {
			sql.append("         AND B.ORDER_DATE        = STR_TO_DATE(:jubsuDate, '%Y/%m/%d')                                                                                                ");
		}
		if(!StringUtils.isEmpty(drgBunho)) {
			sql.append("         AND B.DRG_BUNHO         = :drgBunho                                                                                                                          ");
		}
		sql.append("         AND B.BUNRYU1      IN ('4', '6')                                                                                                                                 ");
		sql.append("         AND IFNULL(B.DC_YN,'N')    = 'N'                                                                                                                                 ");
		sql.append("         AND IFNULL(B.BANNAB_YN,'N')       = 'N'                                                                                                                          ");
		sql.append("         AND IFNULL(B.WONYOI_ORDER_YN,'N') <> 'Y'                                                                                                                         ");
		sql.append("         AND A.HOSP_CODE           = B.HOSP_CODE                                                                                                                          ");
		sql.append("         AND B.FKOCS1003           = A.FKOCS1003                                                                                                                          ");
		sql.append("         AND B.ORDER_DATE          = A.JUBSU_DATE                                                                                                                         ");
		sql.append("         AND B.DRG_BUNHO           = A.DRG_BUNHO                                                                                                                          ");
		sql.append("       GROUP BY B.ORDER_DATE, DANUI,DANUI1,B.DRG_BUNHO,B.BUNHO,B.DV,BUNRYU1, NAME, GWA                                                                                    ");
		sql.append("            ,A.BOGYONG_CODE, BOGYONG_NAME, CAUTION_NM, JAERYO_CODE, GYUNBON_YN,RP,HOPE_DATE,DONBOK, B.ORDER_DANUI, B.ORD_SURYANG										  ");
		sql.append("            )  X                                                                                                                                                          ");
		sql.append("   GROUP BY X.ORDER_DATE, X.DANUI, X.DANUI1, X.DRG_BUNHO   , X.BUNHO       , X.DV   , X.DRG_GRP,                                                                          ");
		sql.append("            X.NAME , X.GWA   , X.BOGYONG_CODE, X.BOGYONG_NAME, X.NALSU, X.BUNRYU1,                                                                                        ");
		sql.append("            X.CAUTION_NM, X.JAERYO_NAME, X.GYUNBON_YN, X.RP,   X.HOPE_DATE, X.DONBOK                                                                                      ");
		sql.append("  ORDER BY 18                                                                                                                                                             ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(jubsuDate)) {
			query.setParameter("jubsuDate", jubsuDate);
		}
		if(!StringUtils.isEmpty(drgBunho)) {
			query.setParameter("drgBunho", drgBunho);
		}
		
		List<DrgsDRG5100P01LabelListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01LabelListItemInfo.class);
		return list;
	}
	
	@Override
	public List<DrgsDRG5100P01NebokLabelListItemInfo> getDrgsDRG5100P01NebokLabelListItemInfo(String hospitalCode, String language,
			String jubsuDate, String drgBunho, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT B.BUNHO                                                BUNHO                                               ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME(B.GWA, B.ORDER_DATE, :hospitalCode, :language)   GWA_NAME                             ");
		sql.append("     , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, B.ORDER_DATE, :hospitalCode)        DOCTOR_NAME                          ");
		sql.append("     , E.SUNAME                                               SUNAME                                              ");
		sql.append("     , E.SUNAME2                                              SUNAME2                                             ");
		sql.append("     , FN_BAS_LOAD_AGE(SYSDATE(), E.BIRTH, '')                AGE                                                 ");
		sql.append("     , E.SEX                                                  SEX                                                 ");
		sql.append("     , E.BIRTH                                                BIRTH                                               ");
		sql.append("     , A.DRG_BUNHO                                            DRG_BUNHO                                           ");
		sql.append("     , A.SERIAL_V                                             RP_BUNHO                                            ");
		sql.append("     , DATE_FORMAT(B.ORDER_DATE,'%Y/%m/%d')                     RESER_DATE                                        ");
		sql.append("     , FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE, :hospitalCode)  JUSA_GUBUN                                        ");
		sql.append("     , ''                                                     JUSA_SPD_GUBUN                                      ");
		sql.append("     , F.SURYANG                                              SURYANG                                             ");
		sql.append("     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', F.ORD_DANUI, :hospitalCode, :language)  ORD_DANUI                       ");
		sql.append("     , F.DV_TIME                                              DV_TIME                                             ");
		sql.append("     , F.DV                                                   DV                                                  ");
		sql.append("     , F.BOGYONG_CODE                                         BOGYONG_CODE                                        ");
		sql.append("     , F.SUBUL_SURYANG                                        SUBUL_SURYANG                                       ");
		sql.append("     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', F.SUBUL_DANUI, :hospitalCode, :language) SUBUL_DANUI                    ");
		sql.append("     , FN_INV_LOAD_JAERYO_NAME(B.JAERYO_CODE, '1', :hospitalCode) JAERYO_NAME                                     ");
		sql.append("     , B.NALSU                                                NALSU_CNT                                           ");
		sql.append("  FROM OCS1003 F,                                                                                                 ");
		sql.append("       OUT0101 E,                                                                                                 ");
		sql.append("       OCS0103 C,                                                                                                 ");
		sql.append("       DRG2010 B,                                                                                                 ");
		sql.append("       DRG2030 A                                                                                                  ");
		sql.append(" WHERE A.HOSP_CODE       = :hospitalCode                                                                          ");
		if(!StringUtils.isEmpty(jubsuDate)) {
			sql.append("      AND A.JUBSU_DATE   = :jubsuDate                                                                             ");
		}
		if(!StringUtils.isEmpty(drgBunho)) {
			sql.append("      AND A.DRG_BUNHO    = :drgBunho                                                                              ");
		}
		if(!StringUtils.isEmpty(bunho)) {
			sql.append("      AND B.BUNHO        = :bunho                                                                                 ");
		}
		sql.append("      AND B.HOSP_CODE    = A.HOSP_CODE                                                                            ");
		sql.append("      AND B.JUBSU_DATE   = A.JUBSU_DATE                                                                           ");
		sql.append("      AND B.DRG_BUNHO    = A.DRG_BUNHO                                                                            ");
		sql.append("      AND B.FKOCS1003    = A.FKOCS1003                                                                            ");
		sql.append("      AND C.HOSP_CODE    = B.HOSP_CODE                                                                            ");
		sql.append("      AND C.HANGMOG_CODE = B.JAERYO_CODE                                                                          ");
		sql.append("      AND E.HOSP_CODE    = B.HOSP_CODE                                                                            ");
		sql.append("      AND E.BUNHO        = B.BUNHO                                                                                ");
		sql.append("      AND F.HOSP_CODE    = B.HOSP_CODE                                                                            ");
		sql.append("      AND F.PKOCS1003    = B.FKOCS1003                                                                            ");
		sql.append("  ORDER BY CONCAT(A.SERIAL_V, IFNULL(F.TEL_YN, 'N'), LTRIM(LPAD(F.GROUP_SER, 4, '0')), IFNULL(F.MIX_GROUP, ' ')   ");
		sql.append("          ,LTRIM(LPAD(IF(F.BOM_OCCUR_YN = 'Y', F.SEQ + 100, F.SEQ) ,4,'0')),LTRIM(LPAD(F.PKOCS1003, 10,'0')) )    ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(jubsuDate)) {
			query.setParameter("jubsuDate", jubsuDate);
		}
		if(!StringUtils.isEmpty(drgBunho)) {
			query.setParameter("drgBunho", drgBunho);
		}
		if(!StringUtils.isEmpty(bunho)) {
			query.setParameter("bunho", bunho);
		}
		
		List<DrgsDRG5100P01NebokLabelListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01NebokLabelListItemInfo.class);
		return list;
	}
	
	@Override
	public List<DrgsDRG5100P01PaidOrderListItemInfo> getDrgsDRG5100P01PaidListItemInfo(String hospitalCode, String gwa, 
			Date fromDate, Date toDate, String gubun, String wonyoiYn, String bunho, boolean isJubsu){
		StringBuilder sql = new StringBuilder();
		if (StringUtils.isEmpty(bunho)) {
			sql.append("SELECT A.BUNHO                                            BUNHO                                                                   ");
			sql.append("      ,A.ORDER_DATE                                       ORDER_DATE                                                              ");
			sql.append("      ,A.DRG_BUNHO                                        DRG_BUNHO                                                               ");
			sql.append("      ,FN_OUT_LOAD_SUNAME(A.BUNHO, :hospitalCode)         SUNAME                                                                  ");
			sql.append("      ,IF(IFNULL(A.BORYU_YN,'N') = 'N',' ','Y')           BORYU_YN                                                                ");
			sql.append("      ,MIN(C.ORDER_REMARK)                                ORDER_REMARK                                                            ");
			sql.append("      ,MIN(C.DRG_REMARK)                                  DRG_REMARK                                                              ");
			sql.append("      ,IFNULL(P.NUMBER_PROTOCOL, 0)                           NUMBER_PROTOCOL                                                     ");
			sql.append("  FROM DRG2010 A                                                                                                                  ");
			sql.append("        LEFT JOIN DRG9041 C ON C.HOSP_CODE = A.HOSP_CODE AND C.BUNHO  = A.BUNHO                                                   ");
			sql.append("        INNER JOIN OCS1003 B ON B.HOSP_CODE  = A.HOSP_CODE  AND A.FKOCS1003 = B.PKOCS1003                                         ");
			sql.append("		LEFT JOIN (select COUNT(cpp.CLIS_PROTOCOL_ID) NUMBER_PROTOCOL, cpp.BUNHO from CLIS_PROTOCOL_PATIENT cpp                   ");
			sql.append("		 INNER JOIN CLIS_PROTOCOL	cp	ON cpp.CLIS_PROTOCOL_ID = cp.CLIS_PROTOCOL_ID                                             ");
			sql.append("		 AND cpp.HOSP_CODE = :hospitalCode										AND				                                  ");
			sql.append("		cpp.ACTIVE_FLG = 1										AND		                                                          ");
			sql.append("		cp.ACTIVE_FLG = 1										AND		                                                          ");
			sql.append("		cp.STATUS_FLG <> 1										AND		                                                          ");
			sql.append("		cp.END_DATE <= SYSDATE() GROUP BY cpp.BUNHO ) P ON A.BUNHO = P.BUNHO	                                                  ");
			sql.append(" WHERE A.HOSP_CODE = :hospitalCode                                                                                                ");
			if(fromDate != null && toDate != null) {
				if (!isJubsu) {
					sql.append("   AND A.ORDER_DATE  BETWEEN :fromDate AND :toDate                                                              		  ");
				} else {
					sql.append("   AND A.JUBSU_DATE  BETWEEN :fromDate AND :toDate                                                              		  ");
				}
			}
			if(!StringUtils.isEmpty(gwa)) {
				sql.append("   AND A.GWA  LIKE IFNULL(:gwa,'%')                                                                                           ");
			}
			if(!StringUtils.isEmpty(wonyoiYn)) {
				sql.append("   AND IFNULL(A.WONYOI_ORDER_YN, 'N') = :wonyoiYn                                                                             ");
			}
			sql.append("   AND ((:gubun = '1' AND IFNULL(A.PRINT_YN,'N') = 'N') OR (:gubun = '2' AND IFNULL(A.PRINT_YN,'N') = 'Y') OR (:gubun = '3'))     ");
			sql.append("   AND IFNULL(A.DC_YN,'N')            <> 'Y'                                                                                      ");
			sql.append("   AND A.SOURCE_FKOCS1003          IS NULL                                                                                        ");
			sql.append("   AND SUBSTR(B.ORDER_GUBUN,2,1) IN('C','D','B','Z')                                        ");
			sql.append("   GROUP BY A.BUNHO, A.ORDER_DATE, A.DRG_BUNHO, IF(IFNULL(A.BORYU_YN,'N')='N',' ','Y')                                            ");
		} else {
			sql.append("SELECT A.BUNHO                                            BUNHO                                                                    ");
			sql.append("      ,A.ORDER_DATE                                       ORDER_DATE                                                               ");
			sql.append("      ,A.DRG_BUNHO                                        DRG_BUNHO                                                                ");
			sql.append("      ,FN_OUT_LOAD_SUNAME(A.BUNHO, :hospitalCode)         SUNAME                                                                   ");
			sql.append("      ,IF(IFNULL(A.BORYU_YN,'N')='N',' ','Y')             BORYU_YN                                                                 ");
			sql.append("      ,MIN(C.ORDER_REMARK)                                ORDER_REMARK                                                             ");
			sql.append("      ,MIN(C.DRG_REMARK)                                  DRG_REMARK                                                               ");
			sql.append("      ,IFNULL(P.NUMBER_PROTOCOL, 0)                       NUMBER_PROTOCOL                                                          ");
			sql.append("  FROM DRG2010 A                                                                                                                   ");
			sql.append("        LEFT JOIN DRG9041 C ON C.HOSP_CODE = A.HOSP_CODE AND C.BUNHO  = A.BUNHO                                                    ");
			sql.append("        INNER JOIN OCS1003 B ON B.HOSP_CODE  = A.HOSP_CODE  AND A.FKOCS1003 = B.PKOCS1003                                          ");
			sql.append("		LEFT JOIN (select COUNT(cpp.CLIS_PROTOCOL_ID) NUMBER_PROTOCOL, cpp.BUNHO from CLIS_PROTOCOL_PATIENT cpp                   ");
			sql.append("		 INNER JOIN CLIS_PROTOCOL	cp	ON cpp.CLIS_PROTOCOL_ID = cp.CLIS_PROTOCOL_ID                                             ");
			sql.append("		 AND cpp.HOSP_CODE = :hospitalCode										AND				                                  ");
			sql.append("		cpp.ACTIVE_FLG = 1										AND		                                                          ");
			sql.append("		cp.ACTIVE_FLG = 1										AND		                                                          ");
			sql.append("		cp.STATUS_FLG <> 1										AND		                                                          ");
			sql.append("		cp.END_DATE <= SYSDATE() GROUP BY cpp.BUNHO ) P ON A.BUNHO = P.BUNHO	                                                  ");
			sql.append(" WHERE A.HOSP_CODE                 = :hospitalCode                                                                                 ");
			sql.append("   AND A.BUNHO                     = :bunho                                                                                        ");
			if(!StringUtils.isEmpty(wonyoiYn)) {
				sql.append("   AND IFNULL(A.WONYOI_ORDER_YN, 'N') = :wonyoiYn	                                                                               ");
			}
			if(!StringUtils.isEmpty(gubun)) {
				sql.append("   AND ((:gubun = '1' AND IFNULL(A.PRINT_YN,'N') = 'N') OR (:gubun = '2' AND IFNULL(A.PRINT_YN,'N') = 'Y') OR (:gubun = '3'))      ");
			}
			sql.append("   AND IFNULL(A.DC_YN,'N')            <> 'Y'                                                                                       ");
			sql.append("   AND A.SOURCE_FKOCS1003          IS NULL                                                                                         ");
			sql.append("   AND SUBSTR(B.ORDER_GUBUN,2,1) IN('C','D','B','Z')                                          										");
			sql.append(" GROUP BY A.BUNHO, A.ORDER_DATE, A.DRG_BUNHO, BORYU_YN                                                                             ");
			sql.append(" ORDER BY 2 DESC, 3 DESC                                                                                                           ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if(StringUtils.isEmpty(bunho)) {
			if(!StringUtils.isEmpty(gwa)) {
				query.setParameter("gwa", gwa);
			}
			if(fromDate != null && toDate != null) {
				query.setParameter("fromDate", fromDate);
				query.setParameter("toDate", toDate);
			}
		} else {
			query.setParameter("bunho", bunho);
		}
		if(!StringUtils.isEmpty(gubun)) {
			query.setParameter("gubun", gubun);
		}
		if(!StringUtils.isEmpty(wonyoiYn)) {
			query.setParameter("wonyoiYn", wonyoiYn);
		}
		List<DrgsDRG5100P01PaidOrderListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01PaidOrderListItemInfo.class);
		return list;
	}
	
	@Override
	public List<DrgsDRG5100P01OrderOrderListItemInfo> getDrgsDRG5100P01OrderOrderListItemInfo(String hospitalCode, String language, 
			String orderDate, String drgBunho, String gubun){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DRG_BUNHO                         DRG_BUNHO                                                                                   ");
		sql.append("      ,MAX(A.BUNHO)                        BUNHO                                                                                       ");
		sql.append("      ,MAX(A.ORDER_DATE)                   ORDER_DATE                                                                                  ");
		sql.append("      ,MAX(A.JUBSU_DATE)                   JUBSU_DATE                                                                                  ");
		sql.append("      ,MAX(A.JUBSU_ILSI)                   DRG_JUBSU_DATE                                                                              ");
		sql.append("      ,MAX(IF(IFNULL(A.PRINT_YN,'N') = 'N',' ', A.JUBSU_TIME))   JUBSU_TIME                                                            ");
		sql.append("      ,MAX(A.DOCTOR)                       DOCTOR                                                                                      ");
		sql.append("      ,MAX(C.DOCTOR_NAME)                  DOCTOR_NAME                                                                                 ");
		sql.append("      ,MAX(A.GWA)                          GWA                                                                                         ");
		sql.append("      ,MAX(B.BUSEO_NAME)                   BUSEO_NAME                                                                                  ");
		sql.append("      ,MAX(A.ACT_ILSI)                     ACT_DATE                                                                                    ");
		sql.append("      ,IFNULL(A.PRINT_YN, 'N')             ACT_YN                                                                                      ");
		sql.append("      ,MAX(A.SUNAB_DATE)                   SUNAB_DATE                                                                                  ");
		sql.append("      ,MAX(A.CHULGO_DATE)                  CHULGO_DATE                                                                                 ");
		sql.append("      ,IFNULL(A.BORYU_YN, 'N')             BORYU_YN                                                                                    ");
		sql.append("      ,MAX(A.CHULGO_BUSEO)                 CHULGO_BUSEO                                                                                ");
		sql.append("      ,MAX(E.ORDER_REMARK)                 ORDER_REMARK                                                                                ");
		sql.append("      ,MAX(E.DRG_REMARK)                   DRG_REMARK                                                                                  ");
		sql.append("      ,IFNULL(A.WONYOI_ORDER_YN, 'N')      WONYOI_ORDER_YN                                                                             ");
		sql.append("      ,MAX(D.FKOUT1001)                    FKOUT1001                                                                                   ");
		sql.append("      ,MAX(A.FKOCS1003)                    FKOCS1003                                                                                   ");
		sql.append("      ,MAX(X.NAEWON_YN)                    NAEWON_YN                                                                                   ");
		sql.append("      ,MAX(D.IF_DATA_SEND_YN)              IF_DATA_SEND_YN                                                                             ");
		sql.append("  FROM (SELECT * FROM DRG2010 A WHERE IFNULL(A.DC_YN,'N') <> 'Y'  AND A.SOURCE_FKOCS1003   IS NULL) A                                  ");
		sql.append("  LEFT JOIN VW_GWA_NAME B ON B.HOSP_CODE = A.HOSP_CODE  AND B.BUSEO_CODE = A.GWA AND B.LANGUAGE = :language AND B.GWA IS NOT NULL                            ");
		sql.append("  LEFT JOIN BAS0270 C ON C.HOSP_CODE = A.HOSP_CODE AND C.DOCTOR = A.DOCTOR                                                             ");
		sql.append("  LEFT JOIN OCS1003 D ON D.HOSP_CODE = A.HOSP_CODE AND D.PKOCS1003 = A.FKOCS1003                                                       ");
		sql.append("  LEFT JOIN OUT1001 X ON X.HOSP_CODE = :hospitalCode AND X.PKOUT1001 = D.FKOUT1001                                           		   ");
		sql.append("  LEFT JOIN DRG9040 E ON E.HOSP_CODE = A.HOSP_CODE AND E.DRG_BUNHO = A.DRG_BUNHO  AND E.JUBSU_DATE = A.JUBSU_DATE                       ");
		sql.append(" WHERE A.HOSP_CODE = :hospitalCode");
		if (!StringUtils.isEmpty(orderDate)) {
			sql.append("   AND A.ORDER_DATE         = STR_TO_DATE(:orderDate, '%Y/%m/%d')                                                                      ");
		}
		if (!StringUtils.isEmpty(drgBunho)) {
			sql.append("   AND A.DRG_BUNHO          = :drgBunho                                                                                                ");
		}
		if(!StringUtils.isEmpty(gubun)) {
			sql.append("   AND ((:gubun = '1' AND IFNULL(A.PRINT_YN,'N') = 'N') OR (:gubun = '2' AND IFNULL(A.PRINT_YN,'N') = 'Y') OR (:gubun = '3'))    	   ");
		}
		sql.append(" GROUP BY A.BUNHO,  A.DRG_BUNHO, IFNULL(A.WONYOI_ORDER_YN, 'N'),IFNULL(A.PRINT_YN, 'N'), IFNULL(A.BORYU_YN, 'N')                       ");
		sql.append(" ORDER BY 1                                                                                                                            ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(gubun)) {
			query.setParameter("gubun", gubun);
		}
		if(!StringUtils.isEmpty(orderDate)) {
			query.setParameter("orderDate", orderDate);
		}
		if(!StringUtils.isEmpty(drgBunho)) {
			query.setParameter("drgBunho", drgBunho);
		}
		
		List<DrgsDRG5100P01OrderOrderListItemInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01OrderOrderListItemInfo.class);
		return list;
	}
	
	@Override
	public List<DrgsDRG5100P01CurDrgOrderInfo> getDrgsDRG5100P01CurDrgOrderInfo(String hospCode, String language, 
			Double masterPk, String ioGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT                                                                                                                                      ");
		sql.append("          A.HOSP_CODE                           AS HOSP_CODE                                                                                ");
		sql.append("        , A.BUNHO                               AS BUNHO                                                                                    ");
		sql.append("        , AK.SUNAME                             AS NAME                                                                                     ");
		sql.append("        , AK.SUNAME2                            AS NAME_KANA                                                                                ");
		sql.append("        , IF(AK.SEX = 'F', '2', '1')            AS SEX                                                                                      ");
		sql.append("        , AK.BIRTH                              AS BIRTHDAY                                                                                 ");
		sql.append("        , '2'                                   AS IO_GUBUN                                                                                 ");
		sql.append("        , '4'                                   AS DRG_ORD_GUBUN                                                                            ");
		sql.append("        , '0'                                   AS IP_TOIWON_GUBUN                                                                          ");
		sql.append("        , A0.DATA_DUBUN                         AS DATA_GUBUN                                                                               ");
		sql.append("        , ''                                    AS HO_DONG                                                                                  ");
		sql.append("        , ''                                    AS HO_DONG_NAME                                                                             ");
		sql.append("        , ''                                    AS HO_CODE                                                                                  ");
		sql.append("        , ''                                    AS HO_CODE_NAME                                                                             ");
		sql.append("        , A.GWA                                 AS GWA                                                                                      ");
		sql.append("        , AG.GWA_NAME                           AS GWA_NAME                                                                                 ");
		sql.append("        , AD.ORG_DOCTOR                         AS DOCTOR                                                                                   ");
		sql.append("        , AD.DOCTOR_NAME                        AS DOCTOR_NAME                                                                              ");
		sql.append("        , A.JUBSU_DATE                          AS JUBSU_DATE                                                                               ");
		sql.append("        , A.JUBSU_DATE                          AS JOJE_DATE                                                                                ");
		sql.append("        , IFNULL(AO.HOPE_DATE, A.JUBSU_DATE)    AS BOGYONG_START_DATE                                                                       ");
		sql.append("        , A.DRG_BUNHO                           AS DRG_BUNHO                                                                                ");
		sql.append("        , RC.RP_CNT                             AS RP_CNT                                                                                   ");
		sql.append("        , CA.ORDER_REMARK                       AS ORD_CMT                                                                                  ");
		sql.append("        , CEIL(LENGTH(IFNULL(CA.ORDER_REMARK,''))/50) AS ORD_CMT_CNT                                                                        ");
		sql.append("        , SUBSTR(A.GROUP_SER, 2)                AS DRG_RP_NO                                                                                ");
		sql.append("        , CASE                                                                                                                              ");
		sql.append("            WHEN (B.DONBOG_YN = 'Y')    THEN '3'                                                                                            ");
		sql.append("            WHEN (B.BUNRYU1 = '1')      THEN '1'                                                                                            ");
		sql.append("            WHEN (B.BUNRYU1 = '6')      THEN '5'                                                                                            ");
		sql.append("            WHEN (B.BUNRYU1 = '4')      THEN '4'                                                                                            ");
		sql.append("                                        ELSE '9'                                                                                            ");
		sql.append("          END                                   AS BOGYONG_GUBUN                                                                            ");
		sql.append("        , A.BOGYONG_CODE                        AS BOGYONG_CODE                                                                             ");
		sql.append("        , '4'                                   AS BOGYONG_SIGI_GUBUN                                                                       ");
		sql.append("        , ''                                    AS BOGYONG_SIGI                                                                             ");
		sql.append("        , B.BOGYONG_NAME                        AS BOGYONG_NAME                                                                             ");
		sql.append("        , LPAD(CASE                                                                                                                         ");
		sql.append("               WHEN (B.DONBOG_YN = 'Y')    THEN 1                                                                                           ");
		sql.append("                                           ELSE A.DV                                                                                        ");
		sql.append("                END                                                                                                                         ");
		sql.append("          ,2, '0')                     AS DV                                                                                                ");
		sql.append("        , CASE                                                                                                                              ");
		sql.append("            WHEN (B.DONBOG_YN = 'Y')    THEN '1'                                                                                            ");
		sql.append("                                        ELSE '0'                                                                                            ");
		sql.append("          END                                   AS DAY_DV_GUBUN                                                                             ");
		sql.append("        , LPAD(CASE                                                                                                                         ");
		sql.append("            WHEN (B.DONBOG_YN = 'Y')    THEN IFNULL(B.BOGYONG_GUBUN, '')                                                                    ");
		sql.append("                                        ELSE A.NALSU                                                                                        ");
		sql.append("            END                                                                                                                             ");
		sql.append("          ,2, '0')                              AS DAY_DV_CNT                                                                               ");
		sql.append("        , LPAD(DC.DRG_CNT,1, '')                AS DRG_CNT                                                                                  ");
		sql.append("        , 1                                     AS DRG_SEQ                                                                                  ");
		sql.append("        , A.JAERYO_CODE                         AS DRG_CODE                                                                                 ");
		sql.append("        , C.JAERYO_NAME                         AS DRG_NAME                                                                                 ");
		sql.append("        , ''                                    AS DRG_NAME_KANA                                                                            ");
		sql.append("        , CASE                                                                                                                              ");
		sql.append("            WHEN (B.BUNRYU1 = '6')      THEN '5'                                                                                            ");
		sql.append("            WHEN (B.BUNRYU1 = '4')      THEN '4'                                                                                            ");
		sql.append("            WHEN (B.BUNRYU1 = '1')      THEN '1'                                                                                            ");
		sql.append("                                        ELSE '1'                                                                                            ");
		sql.append("          END                                   AS DRG_GUBUN                                                                                ");
		sql.append("        , ''                                    AS DRG_TYPE                                                                                 ");
		sql.append("        , A.ORDER_DANUI                         AS DANUI                                                                                    ");
		sql.append("        , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI,:f_hosp_code,:f_language) AS DANUI_NAME                                           ");
		sql.append("        , A.DV_TIME                             AS DV_TIME                                                                                  ");
		sql.append("        , CASE                                                                                                                              ");
		sql.append("            WHEN (A.DV_TIME = '*' )     THEN (A.ORDER_SURYANG)                                                                              ");
		sql.append("                                        ELSE (A.ORD_SURYANG)                                                                                ");
		sql.append("          END                                   AS SURYANG                                                                                  ");
		sql.append("        , IF(SIGN(IFNULL(A.DV_1, 0)) =  0, '0', '1')                                                                                        ");
		sql.append("                                                AS UNBALANCE_YN                                                                             ");
		sql.append("        , B.PATTERN                                                                AS PATTERN                                               ");
		sql.append("        , A.DV_1                                                                   AS DV_1                                                  ");
		sql.append("        , A.DV_2                                                                   AS DV_2                                                  ");
		sql.append("        , A.DV_3                                                                   AS DV_3                                                  ");
		sql.append("        , A.DV_4                                                                   AS DV_4                                                  ");
		sql.append("        , A.DV_5                                                                   AS DV_5                                                  ");
		sql.append("        , A.DV_6                                                                   AS DV_6                                                  ");
		sql.append("        , A.DV_7                                                                   AS DV_7                                                  ");
		sql.append("        , A.DV_8                                                                   AS DV_8                                                  ");
		sql.append("        , IF(A.POWDER_YN = 'Y', '1', '0')    AS POWDER_YN                                                                                   ");
		sql.append("        , IF(A.DRG_PACK_YN = 'Y', '1', '0')  AS DRG_PACK_YN                                                                                 ");
		sql.append("        , A.FKOCS1003                           AS FKOCS                                                                                    ");
		sql.append("        , CD.ORDER_REMARK                       AS DRG_CMT                                                                                  ");
		sql.append("        , CEIL(LENGTH(IFNULL(CD.ORDER_REMARK,''))/50)                                                                                       ");
		sql.append("                                                AS DRG_CMT_CNT                                                                              ");
		sql.append("        , A0.PKDRG4010                          AS FKDRG                                                                                    ");
		sql.append("     FROM                                                                                                                                   ");
		sql.append("         DRG2010 A  LEFT OUTER JOIN BAS0270 AD ON AD.HOSP_CODE = A.HOSP_CODE AND AD.DOCTOR = A.DOCTOR                                       ");
		sql.append("                     LEFT OUTER JOIN BAS0260 AG ON AG.HOSP_CODE = A.HOSP_CODE AND AG.GWA = A.GWA AND AG.LANGUAGE = :f_language              ");
		sql.append("                     LEFT OUTER JOIN OCS1003 AO ON AO.HOSP_CODE = A.HOSP_CODE AND AO.PKOCS1003 = A.FKOCS1003                                ");
		sql.append("                     LEFT OUTER JOIN DRG0120 B ON :f_hosp_code = A.HOSP_CODE AND B.BOGYONG_CODE = A.BOGYONG_CODE  AND B.LANGUAGE = :f_language   AND B.HOSP_CODE = :f_hosp_code                         ");
		sql.append("                     LEFT OUTER JOIN INV0110 C ON C.HOSP_CODE = A.HOSP_CODE AND C.JAERYO_CODE = A.JAERYO_CODE                               ");
		sql.append("                     LEFT OUTER JOIN (SELECT Z.GROUP_SER                   AS GROUP_SER                                                     ");
		sql.append("                , COUNT(*)                      AS DRG_CNT                                                                                  ");
		sql.append("             FROM DRG4010 X                                                                                                                 ");
		sql.append("                , DRG2010 Z                                                                                                                 ");
		sql.append("            WHERE X.HOSP_CODE                   = :f_hosp_code                                                                              ");
		sql.append("              AND X.PKDRG4010                   = :f_master_pk                                                                              ");
		sql.append("              AND X.IN_OUT_GUBUN                = :f_io_gubun                                                                               ");
		sql.append("              AND Z.HOSP_CODE                   = X.HOSP_CODE                                                                               ");
		sql.append("              AND Z.FKDRG4010                   = X.PKDRG4010                                                                               ");
		sql.append("            GROUP BY Z.GROUP_SER) DC ON DC.GROUP_SER = A.GROUP_SER                                                                          ");
		sql.append("                     LEFT OUTER JOIN DRG9040 CA ON CA.HOSP_CODE = A.HOSP_CODE  AND CA.IN_OUT_GUBUN = :f_io_gubun                            ");
		sql.append("                        AND CA.JUBSU_DATE = A.JUBSU_DATE  AND CA.DRG_BUNHO = A.DRG_BUNHO                                                    ");
		sql.append("                     LEFT OUTER JOIN DRG9042 CD ON CD.HOSP_CODE = A.HOSP_CODE AND CD.IN_OUT_GUBUN = :f_io_gubun                             ");
		sql.append("                        AND CD.FKOCS = A.FKOCS1003 ,                                                                                        ");
		sql.append("                        DRG4010 A0                                                                                                          ");
		sql.append("        , (SELECT COUNT(DISTINCT Z.GROUP_SER)   AS RP_CNT                                                                                   ");
		sql.append("             FROM DRG4010 X                                                                                                                 ");
		sql.append("                , DRG2010 Z                                                                                                                 ");
		sql.append("            WHERE X.HOSP_CODE                   = :f_hosp_code                                                                              ");
		sql.append("              AND X.PKDRG4010                   = :f_master_pk                                                                              ");
		sql.append("              AND X.IN_OUT_GUBUN                = :f_io_gubun                                                                               ");
		sql.append("              AND Z.HOSP_CODE                   = X.HOSP_CODE                                                                               ");
		sql.append("              AND Z.FKDRG4010                   = X.PKDRG4010                                                                               ");
		sql.append("          ) RC                                                                                                                              ");
		sql.append("        , OUT0101 AK                                                                                                                        ");
		sql.append("    WHERE A0.HOSP_CODE                 = :f_hosp_code                                                                                       ");
		sql.append("      AND A0.PKDRG4010                 = :f_master_pk                                                                                       ");
		sql.append("      AND A0.IN_OUT_GUBUN              = :f_io_gubun                                                                                        ");
		sql.append("      AND A.HOSP_CODE                   = A0.HOSP_CODE                                                                                      ");
		sql.append("      AND A.FKDRG4010                   = A0.PKDRG4010                                                                                      ");
		sql.append("      AND AK.HOSP_CODE                  = A.HOSP_CODE                                                                                       ");
		sql.append("      AND AK.BUNHO                      = A.BUNHO                                                                                           ");
		sql.append("    ORDER BY A.HOSP_CODE, A.DRG_BUNHO, A.GROUP_SER, A.FKOCS1003                                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_master_pk", masterPk);
		query.setParameter("f_io_gubun", ioGubun);
		
		List<DrgsDRG5100P01CurDrgOrderInfo> list = new JpaResultMapper().list(query, DrgsDRG5100P01CurDrgOrderInfo.class);
		return list;
	}

	@Override
	public List<DRG0201U00GrdPaidInfo> getDrg0201u00GridPaidInfo(String hospitalCode, Date orderDate, String bunho, String gubun){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DRG_BUNHO DRG_BUNHO                                                                                               ");
		sql.append(" ,MAX(A.BUNHO) BUNHO                                                                                                       ");
		sql.append(" ,MAX(A.ORDER_DATE) ORDER_DATE                                                                                             ");
		sql.append(" ,IFNULL(A.CHULGO_YN, 'N') JOJE_YN                                                                                         ");
		sql.append(" ,FN_OUT_LOAD_SUNAME(A.BUNHO, :hospitalCode) SUNAME                                                                        ");
		sql.append(" ,MIN(C.ORDER_REMARK) ORDER_REMARK                                                                                         ");
		sql.append(" ,MIN(C.DRG_REMARK) DRG_REMARK                                                                                             ");
		sql.append(" ,IFNULL(P.NUMBER_PROTOCOL, 0)   NUMBER_PROTOCOL                                                                           ");
		sql.append(" FROM DRG9041 C RIGHT JOIN DRG2010 A ON C.BUNHO = A.BUNHO AND C.HOSP_CODE = A.HOSP_CODE                                    ");
		sql.append("LEFT JOIN (select COUNT(cpp.CLIS_PROTOCOL_ID) NUMBER_PROTOCOL, cpp.BUNHO from CLIS_PROTOCOL_PATIENT cpp                    ");
		sql.append("		 INNER JOIN CLIS_PROTOCOL	cp	ON cpp.CLIS_PROTOCOL_ID = cp.CLIS_PROTOCOL_ID                                      ");
		sql.append("		 AND cpp.HOSP_CODE = :hospitalCode										AND				                           ");
		sql.append("		cpp.ACTIVE_FLG = 1										AND		                                                   ");
		sql.append("		cp.ACTIVE_FLG = 1										AND		                                                   ");
		sql.append("		cp.STATUS_FLG <> 1										AND		                                                   ");
		sql.append("		cp.END_DATE <= SYSDATE() GROUP BY cpp.BUNHO ) P ON A.BUNHO = P.BUNHO	                                           ");
		sql.append(" WHERE A.HOSP_CODE = :hospitalCode                                                       								  ");
		if(!StringUtils.isEmpty(gubun)) {
			sql.append(" AND ((:gubun = '1' AND A.ACT_DATE IS NULL )                                                                           ");
			sql.append(" OR (:gubun = '2' AND A.ACT_DATE IS NOT NULL )                                                                         ");
			sql.append(" OR (:gubun = '3' ))                                                                                                   ");
		}
		sql.append(" AND ((:bunho IS NULL AND A.ORDER_DATE = :orderDate) OR A.BUNHO = :bunho)                                                  ");
		sql.append(" AND A.SOURCE_FKOCS1003 IS NULL                                                                                            ");
		sql.append(" AND IFNULL(A.DC_YN,'N') <> 'Y'                                                                                            ");
		sql.append(" AND A.PRINT_YN = 'Y'                                                                                                      ");
		sql.append(" AND IFNULL(A.WONYOI_ORDER_YN,'N') = 'N'                                                                                   ");
		sql.append(" AND A.JUNDAL_PART = 'PA'                                                                                                  ");
		sql.append(" AND A.FKOCS1003 IN (SELECT X.PKOCS1003                                                                                    ");
		sql.append(" FROM OCS1003 X                                                                                                            ");
		sql.append(" WHERE X.HOSP_CODE = A.HOSP_CODE                                                                                           ");
		sql.append(" AND X.PKOCS1003 = A.FKOCS1003)                                                                                            ");
		sql.append("GROUP BY DRG_BUNHO, JOJE_YN, SUNAME, P.NUMBER_PROTOCOL																	   ");
		sql.append("ORDER BY 3 DESC, 1                                                                                                         ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if(!StringUtils.isEmpty(gubun)) {
			query.setParameter("gubun", gubun);
		}
		query.setParameter("orderDate", orderDate);
		query.setParameter("bunho", bunho);
		
		List<DRG0201U00GrdPaidInfo> list = new JpaResultMapper().list(query, DRG0201U00GrdPaidInfo.class);
		return list;
	}
	
	@Override
	public List<DRG0201U00GrdOrderInfo> getDRG0201U00DetailServerCallInfo(String hospCode, String language, String jubsuDate, String bunho, String drgBunho,String handlerName){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DRG_BUNHO                                 DRG_BUNHO                                                      ");
		sql.append("     , MAX(A.BUNHO)                                BUNHO                                                          ");
		sql.append("     , MAX(A.ORDER_DATE)                           ORDER_DATE                                                     ");
		sql.append("     , MAX(A.JUBSU_DATE)                           JUBSU_DATE                                                     ");
		sql.append("     , MAX(A.JUBSU_ILSI)                           DRG_JUBSU_DATE                                                 ");
		sql.append("     , MAX(A.JUBSU_TIME)                           JUBSU_TIME                                                     ");
		sql.append("     , MAX(A.DOCTOR)                               DOCTOR                                                         ");
		sql.append("     , MAX(C.DOCTOR_NAME)                          DOCTOR_NAME                                                    ");
		sql.append("     , MAX(A.GWA)                                  GWA                                                            ");
		sql.append("     , MAX(B.BUSEO_NAME)                           BUSEO_NAME                                                     ");
		sql.append("     , MAX(A.ACT_DATE)                             ACT_DATE                                                       ");
		sql.append("     , MAX(A.ACT_ILSI)                             ACT_TIME                                                       ");
		sql.append("     , MAX(IF(IFNULL(A.ACT_GWA,'N')='N','N','Y'))  ACT_YN                                                         ");
		sql.append("     , MAX(D.IF_DATA_SEND_DATE)                      SUNAB_DATE                                                   ");
		sql.append("     , MAX(A.CHULGO_DATE)                          CHULGO_DATE                                                    ");
		if(handlerName.equalsIgnoreCase("DRG0201U00GrdOrderTbxBarCodeRequest")){
			sql.append("     , MAX(FN_ADM_LOAD_USER_NM(A.ACT_USER, A.JUBSU_DATE)) ACT_USER_NAME                                           ");
		}else{
			sql.append("     , ''                                               ACT_USER_NAME                                           ");
		}
		sql.append("     , IFNULL(A.WONYOI_ORDER_YN, 'N')                 WONYOI_ORDER_YN                                             ");
		sql.append("     , MAX(A.DIS_GUBUN )                           DIS_GUBUN                                                      ");
		sql.append("     , MAX(E.ORDER_REMARK)                         ORDER_REMARK                                                   ");
		sql.append("     , MAX(E.DRG_REMARK)                           DRG_REMARK                                                     ");
		if(handlerName.equalsIgnoreCase("DRG0201U00GrdOrderTbxBarCodeRequest")){
			sql.append("     , cast(null as DECIMAL)                             FKOUT1001                                             ");
		}else{
			sql.append("     , MAX(D.FKOUT1001)                            FKOUT1001                                                      ");
		}
		sql.append("  ,D.IF_DATA_SEND_YN                                                                                              ");
		sql.append("  FROM (SELECT * FROM DRG2010 A WHERE A.HOSP_CODE  = :hospCode                                                    ");
		sql.append("   AND A.SOURCE_FKOCS1003         IS NULL                                                                         ");
		sql.append("   AND IFNULL(A.DC_YN,'N')           <> 'Y'                                                                       ");
		sql.append("   AND A.JUNDAL_PART              = 'PA'                                                                          ");
		sql.append("   AND IFNULL(A.WONYOI_ORDER_YN,'N') = 'N'                                                                        ");
		sql.append("   AND A.SOURCE_FKOCS1003         IS NULL                                                                         ");
		if(!StringUtils.isEmpty(jubsuDate)) {
			sql.append("   AND DATE_FORMAT(A.ORDER_DATE,'%Y%m%d') = :jubsu_date                                                      ");
		}
		if(handlerName.equalsIgnoreCase("DRG0201U00GrdOrderTbxBarCodeRequest")){
			sql.append("   AND A.DRG_BUNHO                = cast(:drg_bunho as DECIMAL)                                                 ");
			sql.append("   AND  IFNULL(A.WONYOI_ORDER_YN,'N') = 'N'                                                                    ");
		}else{
			if(!StringUtils.isEmpty(bunho)) {
				sql.append("   AND A.BUNHO                    = :bunho                                                                        ");
			}
			if(!StringUtils.isEmpty(drgBunho)) {
				sql.append("   AND ((IFNULL(:drg_bunho, 'N')  != 'N' AND A.DRG_BUNHO = :drg_bunho)                                            ");
				sql.append("     OR (IFNULL(:drg_bunho, 'N')   = 'N' AND A.DRG_BUNHO > 0))                                                    ");
			}
		}
		sql.append("  ) A                                                                                                             ");
		sql.append("  LEFT JOIN BAS0270 C ON C.DOCTOR = A.DOCTOR AND C.HOSP_CODE = A.HOSP_CODE                                        ");
		sql.append("  LEFT JOIN DRG9040  E ON E.JUBSU_DATE = A.JUBSU_DATE AND E.DRG_BUNHO = A.DRG_BUNHO AND E.HOSP_CODE = A.HOSP_CODE ");
		sql.append("  INNER JOIN VW_GWA_NAME B ON B.HOSP_CODE = A.HOSP_CODE AND B.LANGUAGE = :language AND B.BUSEO_CODE = A.GWA       ");
		sql.append("  INNER JOIN OCS1003 D ON A.FKOCS1003 = D.PKOCS1003 AND D.HOSP_CODE = A.HOSP_CODE                                 ");
		sql.append("                                                                                                                  ");
		sql.append(" GROUP BY A.BUNHO, A.DRG_BUNHO, IFNULL(A.WONYOI_ORDER_YN, 'N'), D.IF_DATA_SEND_YN								  ");
		sql.append(" ORDER BY 1;                                                                                                      ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(jubsuDate)) {
			 query.setParameter("jubsu_date", jubsuDate);
		}
		if(!handlerName.equalsIgnoreCase("DRG0201U00GrdOrderTbxBarCodeRequest")){
			if(!StringUtils.isEmpty(bunho)) {
				query.setParameter("bunho", bunho);
			}
		}
		if(!StringUtils.isEmpty(drgBunho)) {
			query.setParameter("drg_bunho", drgBunho);
		}
		
		List<DRG0201U00GrdOrderInfo> list = new JpaResultMapper().list(query, DRG0201U00GrdOrderInfo.class);
		return list;
	}
	
	public List<PrJihDrgIfsProcInfo> getPrJihDrgIfsProcOutInfo(String hospitalCode, Double fkdrg){

		StringBuilder sql = new StringBuilder();
		sql.append("SELECT   PKG_IFS_BAS_FN_LOAD_IF_CONSTANT(:hospitalCode, 'IF_JIH_CONSTANT', 'REC_GUBUN_PAT_01PT')       REC_GUBUN_PAT      ");
		sql.append("         , DATE_FORMAT(A.ACT_DATE, '%Y%m%d')                                                           JOJE_DATE          ");
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
		sql.append("         , FN_ADM_LOAD_USER_NAME(A.ACT_USER, :hospitalCode)                                            DRGUSER_NAME       ");
		sql.append("         , PKG_IFS_BAS_FN_LOAD_IF_CONSTANT(:hospitalCode, 'IF_JIH_CONSTANT', 'REC_GUBUN_DOCTOR')       REC_GUBUN_DOCTOR   ");
		sql.append("         , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.JUBSU_DATE, :hospitalCode)                              DOCTOR_NAME        ");
		sql.append("      FROM DRG2010 A                                                                                                      ");
		sql.append("          LEFT JOIN DRG9041 C ON C.HOSP_CODE = A.HOSP_CODE AND C.BUNHO = A.BUNHO                                          ");
		sql.append("           INNER JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                        ");
		sql.append("     WHERE A.HOSP_CODE     = :hospitalCode                                                                                ");
		sql.append("       AND A.FKJIHKEY      = :fkdrg                                                                                       ");
		sql.append("       AND A.FKOCS1003     = (SELECT MAX(D.FKOCS1003)                                                                     ");
		sql.append("                                FROM DRG2010 D                                                                            ");
		sql.append("                               WHERE D.HOSP_CODE  = :hospitalCode                                                         ");
		sql.append("                                 AND D.FKJIHKEY   = :fkdrg);                                                              ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("fkdrg", fkdrg);
		List<PrJihDrgIfsProcInfo> list = new JpaResultMapper().list(query, PrJihDrgIfsProcInfo.class);
		return list;
	}

	public List<PrJihDrgIfsProcPatientInfo> getPrJihDrgIfsProcPatientOutInfo(String hospitalCode, String bunho, Double fkdrg) {

		StringBuilder sql = new StringBuilder();
		sql.append("SELECT PKG_IFS_BAS_FN_LOAD_IF_CONSTANT(:hospitalCode, 'IF_JIH_CONSTANT', 'REC_GUBUN_DRG')                  REC_GUBUN_DRG                          ");
		sql.append("       , O.YJ_CODE                                                                                             DRG_CODE                           ");
		sql.append("       , IF(SUBSTR(B.ORDER_GUBUN, 2)='D', '0', B.SURYANG )                                                     SURYANG                            ");
		sql.append("       , PKG_IFS_BAS_FN_LOAD_MAPPED_CODE(:hospitalCode, 'IF_JIH_DRG_TYPE', A.JUBSU_DATE, B.ORD_DANUI, 'IF')    DRG_TYPE                           ");
		sql.append("       , PKG_IFS_BAS_FN_LOAD_MAPPED_CODE(:hospitalCode, 'IF_JIH_BOGYONG_CODE', A.JUBSU_DATE, B.BOGYONG_CODE, 'IF')  BOGYONG_CODE                  ");
		sql.append("       , IF(SUBSTR(B.ORDER_GUBUN, 2) = 'D', '0', IF(IFNULL(FN_DRG_LOAD_DONBOK_YN(B.BOGYONG_CODE, :hospitalCode), 'N')='Y', B.DV, B.NALSU )) NALSU ");
		sql.append("    FROM OCS1003 B                                                                                                                                ");
		sql.append("       , DRG2010 A                                                                                                                                ");
		sql.append("       , OCS0103 O                                                                                                                                ");
		sql.append("   WHERE A.HOSP_CODE   = :hospitalCode                                                                                                            ");
		sql.append("     AND A.BUNHO       = :bunho                                                                                                                   ");
		sql.append("     AND A.FKJIHKEY    = :fkdrg                                                                                                                   ");
		sql.append("     AND B.HOSP_CODE   = A.HOSP_CODE                                                                                                              ");
		sql.append("     AND B.PKOCS1003   = A.FKOCS1003                                                                                                              ");
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
	public String callPrDrgUpdateChulgo(String hospCode, Date jubsuDate, Integer drgBunho, Date chulgoDate,
			String actUser, String chulgoBuseo, String wonyoiOrderYn, String actYn) {
		LOG.info("[START] callPrDrgUpdateChulgo");
		String out = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_UPDATE_CHULGO");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DRG_BUNHO", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CHULGO_DATE", Date.class, ParameterMode.INOUT);;
		query.registerStoredProcedureParameter("I_ACT_USER", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_CHULGO_BUSEO", Integer.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_WONYOI_ORDER_YN", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_ACT_YN", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_JUBSU_DATE", jubsuDate);
		query.setParameter("I_DRG_BUNHO", drgBunho);
		query.setParameter("I_CHULGO_DATE", chulgoDate);
		query.setParameter("I_ACT_USER", actUser);
		query.setParameter("I_CHULGO_BUSEO", drgBunho);
		query.setParameter("I_WONYOI_ORDER_YN", wonyoiOrderYn);
		query.setParameter("I_ACT_YN", actYn);
		query.setParameter("O_ERR", out);
		
		query.execute();
		out = (String)query.getOutputParameterValue("O_ERR");
		LOG.info("[END] callPrDrgMakeBongtuOut");
		return out;
	}

	@Override
	public List<DRG0201U00GrdOrderListInfo> getDRG0201U00GrdOrderListInfo(String hospCode, String language, String jubsuDate, String drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                                                                            ");
		sql.append("        A.BUNHO                             BUNHO                                                                                                           ");
		sql.append("       ,A.DRG_BUNHO                         DRG_BUNHO                                                                                                       ");
		sql.append("       ,A.NAEWON_DATE                       NAEWON_DATE                                                                                                     ");
		sql.append("       ,A.GROUP_SER                         GROUP_SER                                                                                                       ");
		sql.append("       ,A.JUBSU_DATE                        JUBSU_DATE                                                                                                      ");
		sql.append("       ,A.ORDER_DATE                        ORDER_DATE                                                                                                      ");
		sql.append("       ,A.JAERYO_CODE                       JAERYO_CODE                                                                                                     ");
		sql.append("       ,A.NALSU                             NALSU                                                                                                           ");
		sql.append("       ,A.DIVIDE                            DIVIDE                                                                                                          ");
		sql.append("       ,A.ORD_SURYANG                       ORD_SURYANG                                                                                                     ");
		sql.append("       ,A.ORDER_SURYANG                     ORDER_SURYANG                                                                                                   ");
		sql.append("       ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI',  A.ORDER_DANUI,:f_hosp_code,:f_language) ORDER_DANUI                                                             ");
		sql.append("       ,FN_OCS_LOAD_CODE_NAME('SUBUL_DANUI',A.SUBUL_DANUI,:f_hosp_code,:f_language)                                                                         ");
		sql.append("       ,A.GROUP_YN                          GROUP_YN                                                                                                        ");
		sql.append("       ,A.JAERYO_GUBUN                      JAERYO_GUBUN                                                                                                    ");
		sql.append("       ,A.BOGYONG_CODE                      BOGYONG_CODE                                                                                                    ");
		sql.append("       ,B.BOGYONG_NAME                      BOGYONG_NAME                                                                                                    ");
		sql.append("       ,FN_DRG_LOAD_DRG0130(C.CAUTION_CODE,:f_hosp_code, :f_language) CAUTION_NAME                                                                          ");
		sql.append("       ,A.CAUTION_CODE                      CAUTION_CODE                                                                                                    ");
		sql.append("       ,A.MIX_YN                            MIX_YN                                                                                                          ");
		sql.append("       ,E.ATC_YN                            ATC_YN                                                                                                          ");
		sql.append("       ,A.REMARK                            REMARK                                                                                                          ");
		sql.append("       ,A.DV                                DV                                                                                                              ");
		sql.append("       ,A.DV_TIME                           DV_TIME                                                                                                         ");
		sql.append("       ,A.DC_YN                             DC_YN                                                                                                           ");
		sql.append("       ,A.BANNAB_YN                         BANNAB_YN                                                                                                       ");
		sql.append("       ,A.SOURCE_FKOCS1003                  SOURCE_FKOCS1003                                                                                                ");
		sql.append("       ,A.FKOCS1003                         FKOCS1003                                                                                                       ");
		sql.append("       ,A.FKOUT1001                         FKOUT1001                                                                                                       ");
		sql.append("       ,A.SUNAB_DATE                        SUNAB_DATE                                                                                                      ");
		sql.append("       ,B.PATTERN                           PATTERN                                                                                                         ");
		sql.append("       ,C.JAERYO_NAME                       JAERYO_NAME                                                                                                     ");
		sql.append("       ,IFNULL(A.SUNAB_NALSU,0)                SUNAB_NALSU                                                                                                  ");
		sql.append("       ,IFNULL(A.WONYOI_ORDER_YN,'N')          WONYOI_YN                                                                                                    ");
		sql.append("       ,D.ORDER_REMARK                      OCS_REMARK                                                                                                      ");
		sql.append("       ,A.ACT_DATE                          ACT_DATE                                                                                                        ");
		sql.append("       ,A.BUNRYU2                           MAYAK                                                                                                           ");
		sql.append("       ,A.TPN_JOJE_GUBUN                    TPN_JOJE_GUBUN                                                                                                  ");
		sql.append("       ,IFNULL(C.MIX_YN_INP,'N')               UI_JUSA_YN                                                                                                   ");
		sql.append("       ,A.SUBUL_SURYANG                     SUBUL_SURYANG                                                                                                   ");
		sql.append("       ,E.SERIAL_V               SERIAL_V                                                                                                                   ");
		sql.append("       ,G.ORDER_REMARK                      ORDER_REMARK                                                                                                    ");
		sql.append("       ,G.DRG_REMARK                        DRG_REMARK                                                                                                      ");
		sql.append("       ,A.HUBAL_CHANGE_YN                   HUBAK_CHANGE_YN                                                                                                 ");
		sql.append("       ,A.PHARMACY                          PHARMACY                                                                                                        ");
		sql.append("       ,A.DRG_PACK_YN                       DRG_PACK_YN                                                                                                     ");
		sql.append("       ,A.POWDER_YN                         POWDER_YN                                                                                                       ");
		sql.append("   FROM                                                                                                                                                     ");
		sql.append("       OCS1003 D                                                                                                                                            ");
		sql.append("       ,INV0110 C                                                                                                                                           ");
		sql.append("       ,(( DRG2010 A LEFT JOIN DRG0120 B ON B.BOGYONG_CODE = A.BOGYONG_CODE AND :f_hosp_code = A.HOSP_CODE AND B.LANGUAGE  = :f_language AND B.HOSP_CODE = :f_hosp_code)                   ");
		sql.append("         LEFT JOIN DRG2030 E ON  E.JUBSU_DATE = A.ORDER_DATE AND E.DRG_BUNHO = A.DRG_BUNHO AND E.FKOCS1003 = A.FKOCS1003 )                                  ");
		sql.append("         LEFT JOIN DRG9042 G ON G.FKOCS = A.FKOCS1003 AND G.HOSP_CODE = A.HOSP_CODE AND E.HOSP_CODE = A.HOSP_CODE                                           ");
		sql.append("           AND G.IN_OUT_GUBUN= 'O'                                                                                                                          ");
		sql.append("  WHERE A.ORDER_DATE      = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                                                                                          ");
		sql.append("    AND A.DRG_BUNHO       = :f_drg_bunho                                                                                                                    ");
		sql.append("    AND A.HOSP_CODE       = :f_hosp_code                                                                                                                    ");
		sql.append("    AND A.SOURCE_FKOCS1003 IS NULL                                                                                                                          ");
		sql.append("    AND A.JUNDAL_PART     IN ('PA' , 'AC' , 'AT' , 'IR')                                                                                                    ");
		sql.append("    AND C.JAERYO_CODE     = A.JAERYO_CODE                                                                                                                   ");
		sql.append("    AND D.PKOCS1003       = A.FKOCS1003                                                                                                                     ");
		sql.append("    AND D.HOSP_CODE       = A.HOSP_CODE                                                                                                                     ");
		sql.append("    AND C.HOSP_CODE       = A.HOSP_CODE                                                                                                                     ");
		//sql.append("    AND B.LANGUAGE        = :f_language                                                                                                                     ");
		sql.append("  ORDER BY E.SERIAL_V, A.FKOCS1003																															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DRG0201U00GrdOrderListInfo> list = new JpaResultMapper().list(query, DRG0201U00GrdOrderListInfo.class);
		return list;
	}
	
	@Override
	public List<DRG9040U01GrdOrderListOutInfo> getDRG9040U01GrdOrderListOutInfo(String hospCode, String language, String orderDate, String drgBunho, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                                    ");
		sql.append("           A.BUNHO                             BUNHO                                                                                                               ");
		sql.append("          ,A.DRG_BUNHO                         DRG_BUNHO                                                                                                           ");
		sql.append("          ,A.NAEWON_DATE                       NAEWON_DATE                                                                                                         ");
		sql.append("          ,A.GROUP_SER                         GROUP_SER                                                                                                           ");
		sql.append("          ,A.JUBSU_DATE                        JUBSU_DATE                                                                                                          ");
		sql.append("          ,A.ORDER_DATE                        ORDER_DATE                                                                                                          ");
		sql.append("          ,A.JAERYO_CODE                       JAERYO_CODE                                                                                                         ");
		sql.append("          ,A.NALSU                             NALSU                                                                                                               ");
		sql.append("          ,A.DIVIDE                            DIVIDE                                                                                                              ");
		sql.append("          ,A.ORD_SURYANG                       ORD_SURYANG                                                                                                         ");
		sql.append("          ,A.ORDER_SURYANG                     ORDER_SURYANG                                                                                                       ");
		sql.append("          ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) ORDER_DANUI                                                                ");
		sql.append("          ,FN_OCS_LOAD_CODE_NAME('SUBUL_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language)                                                                          ");
		sql.append("          ,A.GROUP_YN                          GROUP_YN                                                                                                            ");
		sql.append("          ,A.JAERYO_GUBUN                      JAERYO_GUBUN                                                                                                        ");
		sql.append("          ,A.BOGYONG_CODE                      BOGYONG_CODE                                                                                                        ");
		sql.append("          ,B.BOGYONG_NAME                      BOGYONG_NAME                                                                                                        ");
		sql.append("          ,FN_DRG_LOAD_DRG0130( A.CAUTION_CODE, :f_hosp_code, :f_language)   CAUTION_NAME                                                                          ");
		sql.append("          ,A.CAUTION_CODE                      CAUTION_CODE                                                                                                        ");
		sql.append("          ,A.MIX_YN                            MIX_YN                                                                                                              ");
		sql.append("          ,E.ATC_YN                            ATC_YN                                                                                                              ");
		sql.append("          ,A.DV                                DV                                                                                                                  ");
		sql.append("          ,A.DV_TIME                           DV_TIME                                                                                                             ");
		sql.append("          ,A.DC_YN                             DC_YN                                                                                                               ");
		sql.append("          ,A.BANNAB_YN                         BANNAB_YN                                                                                                           ");
		sql.append("          ,A.SOURCE_FKOCS1003                  SOURCE_FKOCS1003                                                                                                    ");
		sql.append("          ,A.FKOCS1003                         FKOCS1003                                                                                                           ");
		sql.append("          ,A.FKOUT1001                         FKOUT1001                                                                                                           ");
		sql.append("          ,A.SUNAB_DATE                        SUNAB_DATE                                                                                                          ");
		sql.append("          ,B.PATTERN                           PATTERN                                                                                                             ");
		sql.append("          ,C.JAERYO_NAME                       JAERYO_NAME                                                                                                         ");
		sql.append("          ,IFNULL(A.SUNAB_NALSU,0)                SUNAB_NALSU                                                                                                      ");
		sql.append("          ,IFNULL(A.WONYOI_ORDER_YN,'N')          WONYOI_YN                                                                                                        ");
		sql.append("          ,TRIM(D.ORDER_REMARK)                REMARK                                                                                                              ");
		sql.append("          ,A.ACT_DATE                          ACT_DATE                                                                                                            ");
		sql.append("          ,A.BUNRYU2                           MAYAK                                                                                                               ");
		sql.append("          ,A.TPN_JOJE_GUBUN                    TPN_JOJE_GUBUN                                                                                                      ");
		sql.append("          ,IFNULL(C.MIX_YN_INP,'N')               UI_JUSA_YN                                                                                                       ");
		sql.append("          ,A.SUBUL_SURYANG                     SUBUL_SURYANG                                                                                                       ");
		sql.append("          ,E.SERIAL_V                          SERIAL_V                                                                                                            ");
		sql.append("          ,A.POWDER_YN                         POWDER_YN                                                                                                           ");
		sql.append("          ,IFNULL(A.GYUNBON_YN, 'N')              GYUNBON_YN                                                                                                       ");
		sql.append("          ,IFNULL(A.PRINT_YN, 'N')                PRINT_YN                                                                                                         ");
		sql.append("          ,G.ORDER_REMARK                      ORDER_REMARK                                                                                                        ");
		sql.append("          ,G.DRG_REMARK                        DRG_REMARK                                                                                                          ");
		sql.append("          ,A.HUBAL_CHANGE_YN                   HUBAK_CHANGE_YN                                                                                                     ");
		sql.append("          ,A.PHARMACY                          PHARMACY                                                                                                            ");
		sql.append("          ,A.DRG_PACK_YN                       DRG_PACK_YN                                                                                                         ");
		sql.append("      FROM DRG2010 A LEFT JOIN DRG0120 B ON B.BOGYONG_CODE = A.BOGYONG_CODE AND :f_hosp_code = A.HOSP_CODE  AND B.LANGUAGE = :f_language AND B.HOSP_CODE = :f_hosp_code                           ");
		sql.append("                     JOIN INV0110 C ON C.JAERYO_CODE = A.JAERYO_CODE AND C.HOSP_CODE = A.HOSP_CODE                                                                 ");
		sql.append("                     JOIN OCS1003 D ON D.PKOCS1003 = A.FKOCS1003 AND C.HOSP_CODE = A.HOSP_CODE                                                                     ");
		sql.append("                     LEFT JOIN DRG2030 E ON E.FKOCS1003 = A.FKOCS1003 AND E.JUBSU_DATE = A.ORDER_DATE AND E.DRG_BUNHO = A.DRG_BUNHO AND E.HOSP_CODE = A.HOSP_CODE  ");
		sql.append("                     LEFT JOIN DRG9042 G ON G.IN_OUT_GUBUN = 'O' AND G.FKOCS = A.FKOCS1003 AND G.HOSP_CODE = A.HOSP_CODE                                           ");
		sql.append("     WHERE A.HOSP_CODE        = :f_hosp_code                                                                                                                       ");
		sql.append("       AND A.ORDER_DATE       = STR_TO_DATE(:f_order_date,'%Y/%m/%d')                                                                                              ");
		sql.append("       AND A.DRG_BUNHO        = :f_drg_bunho                                                                                                                       ");
		sql.append("       AND A.BUNHO            = :f_bunho                                                                                                                           ");
		sql.append("       AND A.SOURCE_FKOCS1003 IS NULL                                                                                                                              ");
		sql.append("       AND A.JUNDAL_PART     IN ('PA')                                                                                                                             ");
		sql.append("     ORDER BY E.SERIAL_V, A.FKOCS1003                                                                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_bunho", bunho);
		
		List<DRG9040U01GrdOrderListOutInfo> list = new JpaResultMapper().list(query, DRG9040U01GrdOrderListOutInfo.class);
		return list;
	}
	
	public List<DRG9040U01GrdOrderOutInfo> getDRG9040U01GrdOrderOutInfo(String hospCode, String language, String bunho, String fromDate, String toDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DRG_BUNHO                          DRG_BUNHO                                                                                                             ");
		sql.append("          ,A.BUNHO                              BUNHO                                                                                                             ");
		sql.append("          ,MAX(A.ORDER_DATE)                          ORDER_DATE                                                                                                  ");
		sql.append("          ,A.JUBSU_DATE                           JUBSU_DATE                                                                                                      ");
		sql.append("          ,MAX(IF(IFNULL(A.PRINT_YN,'N') = 'N',' ',                                                                                                               ");
		sql.append("               DATE_FORMAT(A.JUBSU_ILSI,'%H%s'))) JUBSU_TIME                                                                                                      ");
		sql.append("          ,MAX(A.DOCTOR)                              DOCTOR                                                                                                      ");
		sql.append("          ,MAX(C.DOCTOR_NAME)                         DOCTOR_NAME                                                                                                 ");
		sql.append("          ,MAX(A.GWA)                                 GWA                                                                                                         ");
		sql.append("          ,MAX(B.BUSEO_NAME)                          BUSEO_NAME                                                                                                  ");
		sql.append("          ,MAX(A.ACT_ILSI)                            ACT_DATE                                                                                                    ");
		sql.append("          ,IFNULL(A.PRINT_YN, 'N')                 ACT_YN                                                                                                         ");
		sql.append("          ,MAX(A.SUNAB_DATE)                          SUNAB_DATE                                                                                                  ");
		sql.append("          ,MAX(A.CHULGO_DATE)                         CHULGO_DATE                                                                                                 ");
		sql.append("          ,IFNULL(A.BORYU_YN, 'N')                 BORYU_YN                                                                                                       ");
		sql.append("          ,MAX(D.ORDER_REMARK)                  ORDER_REMARK                                                                                                      ");
		sql.append("          ,MAX(D.DRG_REMARK)                    DRG_REMARK                                                                                                        ");
		sql.append("          ,IFNULL(A.WONYOI_ORDER_YN, 'N')          WONYOI_ORDER_YN                                                                                                ");
		sql.append("      FROM DRG2010 A LEFT JOIN VW_GWA_NAME B ON B.BUSEO_CODE = A.GWA AND B.HOSP_CODE = A.HOSP_CODE AND B.LANGUAGE = :language                                     ");
		sql.append("                     LEFT JOIN BAS0270 C ON C.DOCTOR = A.DOCTOR AND C.HOSP_CODE = A.HOSP_CODE                                                                     ");
		sql.append("                     LEFT JOIN DRG9040 D ON D.IN_OUT_GUBUN = 'O' AND DATE(D.JUBSU_DATE) = DATE(A.JUBSU_DATE) AND D.DRG_BUNHO = A.DRG_BUNHO AND D.HOSP_CODE = A.HOSP_CODE      ");
		sql.append("     WHERE A.ORDER_DATE BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')                                                       ");
		sql.append("       AND A.BUNHO                    = :f_bunho                                                                                                                  ");
		sql.append("       AND A.HOSP_CODE                = :f_hosp_code                                                                                                              ");
		sql.append("       AND IFNULL(A.DC_YN,'N')           <> 'Y'                                                                                                                   ");
		sql.append("       AND A.SOURCE_FKOCS1003         IS NULL                                                                                                                     ");
		sql.append("     GROUP BY A.BUNHO                                                                                                                                             ");
		sql.append("            , A.DRG_BUNHO                                                                                                                                         ");
		sql.append("            , A.JUBSU_DATE                                                                                                                                        ");
		sql.append("            , IFNULL(A.WONYOI_ORDER_YN, 'N')                                                                                                                      ");
		sql.append("            , IFNULL(A.PRINT_YN, 'N')                                                                                                                             ");
		sql.append("            , IFNULL(A.BORYU_YN, 'N')                                                                                                                             ");
		sql.append("     ORDER BY 4 DESC, 1                                                                                                                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		List<DRG9040U01GrdOrderOutInfo> list = new JpaResultMapper().list(query, DRG9040U01GrdOrderOutInfo.class);
		return list;
	}
	
	@Override
	public List<DataStringListItemInfo> getDRG3010P99layOutOrder(String hospCode, String fromDate, String toDate, String gubun, String wonyoiYn, String gwa, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT 'Y' OUTORDER																							");
		sql.append("       FROM DRG2010 A																								");
		sql.append("       LEFT JOIN DRG9041 C																							");
		sql.append("         ON C.HOSP_CODE      = A.HOSP_CODE																			");
		sql.append("        AND C.BUNHO          = A.BUNHO																				");
		sql.append("       JOIN OCS1003 B																								");
		sql.append("         ON B.HOSP_CODE      = A.HOSP_CODE																			");
		sql.append("        AND B.PKOCS1003      = A.FKOCS1003																			");
		sql.append("        AND SUBSTR(B.ORDER_GUBUN,2,1) IN('C','D')																	");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code																			");
		sql.append("        AND A.ORDER_DATE     BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m/%d')											");
		sql.append("                             AND STR_TO_DATE(:f_to_date, '%Y/%m/%d')												");
		sql.append("        AND A.GWA            LIKE :f_gwa																			");
		sql.append("        AND (:f_bunho         = '' OR :f_bunho IS NULL)																");
		sql.append("        AND CASE(A.WONYOI_ORDER_YN) WHEN '' THEN 'N' ELSE IFNULL(A.WONYOI_ORDER_YN, 'N') END = :f_wonyoi_yn			");
		sql.append("        AND ((:f_gubun = '1' AND CASE(A.PRINT_YN) WHEN '' THEN 'N' ELSE IFNULL(A.PRINT_YN, 'N') END = 'N')			");
		sql.append("          OR (:f_gubun = '2' AND CASE(A.PRINT_YN) WHEN '' THEN 'N' ELSE IFNULL(A.PRINT_YN, 'N') END = 'Y')			");
		sql.append("          OR (:f_gubun = '3'))																						");
		sql.append("        AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END   <> 'Y'									");
		sql.append("        AND A.SOURCE_FKOCS1003          IS NULL																		");
		sql.append("      GROUP BY A.BUNHO, A.ORDER_DATE, A.DRG_BUNHO																	");
		sql.append("           , CASE(IFNULL(A.BORYU_YN,'N')) WHEN 'N' THEN ' ' WHEN '' THEN ' ' ELSE 'Y' END							");
		sql.append("     UNION ALL																										");
		sql.append("     SELECT  'Y' OUTORDER																							");
		sql.append("       FROM DRG2010 A																								");
		sql.append("       JOIN OCS1003 B																								");
		sql.append("         ON B.HOSP_CODE        = A.HOSP_CODE																		");
		sql.append("        AND B.PKOCS1003        = A.FKOCS1003																		");
		sql.append("        AND SUBSTR(B.ORDER_GUBUN,2,1) IN('C','D')																	");
		sql.append("       LEFT JOIN DRG9041 C																							");
		sql.append("         ON C.HOSP_CODE        = A.HOSP_CODE																		");
		sql.append("        AND C.BUNHO            = A.BUNHO																			");
		sql.append("      WHERE A.HOSP_CODE        = :f_hosp_code																		");
		sql.append("        AND A.BUNHO            = :f_bunho																			");
		sql.append("        AND CASE(A.WONYOI_ORDER_YN) WHEN '' THEN 'N' ELSE IFNULL(A.WONYOI_ORDER_YN, 'N') END = :f_wonyoi_yn			");
		sql.append("        AND ((:f_gubun = '1' AND CASE(A.PRINT_YN) WHEN '' THEN 'N' ELSE IFNULL(A.PRINT_YN, 'N') END = 'N') 			");
		sql.append("          OR (:f_gubun = '2' AND CASE(A.PRINT_YN) WHEN '' THEN 'N' ELSE IFNULL(A.PRINT_YN, 'N') END = 'Y') 			");
		sql.append("          OR (:f_gubun = '3'))																						");
		sql.append("        AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN, 'N') END     <> 'Y'									");
		sql.append("        AND A.SOURCE_FKOCS1003          IS NULL																		");
		sql.append("      GROUP BY A.BUNHO, A.ORDER_DATE, A.DRG_BUNHO																	");
		sql.append("       , CASE(IFNULL(A.BORYU_YN,'N')) WHEN 'N' THEN ' ' WHEN '' THEN ' ' ELSE 'Y' END								");

		if(gwa == null) gwa = "";
		if(gwa == "") gwa = "%";
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		
		List<DataStringListItemInfo> list = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return list;
	}
}

