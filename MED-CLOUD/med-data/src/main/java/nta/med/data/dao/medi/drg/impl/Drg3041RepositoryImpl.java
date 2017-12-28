package nta.med.data.dao.medi.drg.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.lang3.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.drg.Drg3041RepositoryCustom;
import nta.med.data.model.ihis.drgs.DRG3041P01grdChulgoJUSAOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3041P01grdChulgoListInfo;
import nta.med.data.model.ihis.drgs.DRG3041P05grdIpgoJUSAOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3041P05grdMixListInfo;
import nta.med.data.model.ihis.drgs.DRG3041P06grdActListInfo;
import nta.med.data.model.ihis.drgs.PrDrgMakeBarCodeResultInfo;

/**
 * @author dainguyen.
 */
public class Drg3041RepositoryImpl implements Drg3041RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DRG3041P01grdChulgoListInfo> getDRG3041P01grdChulgoListInfo(String hospCode, String bunho,
			String hoDong, String chulgoDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT															            ");
		sql.append("	     B.BUNHO															            ");
		sql.append("	    ,A.JUBSU_DATE                                                 JUBSU_DATE        ");
		sql.append("	    ,CAST(A.DRG_BUNHO AS CHAR)                                    DRG_BUNHO         ");
		sql.append("	    ,A.SERIAL_V                                                   SERIAL_V          ");
		sql.append("	    ,A.CHULGO_DATE                                                CHULGO_DATE       ");
		sql.append("	    ,A.CHULGO_TIME                                                CHULGO_TIME       ");
		sql.append("	    ,A.CHULGO_ID                                                  CHULGO_ID         ");
		sql.append("	    ,A.IPGO_DATE                                                  IPGO_DATE         ");
		sql.append("	    ,A.IPGO_TIME                                                  IPGO_TIME         ");
		sql.append("	    ,A.IPGO_ID                                                    IPGO_ID           ");
		sql.append("	    ,A.ACTING_DATE                                                ACTING_DATE       ");
		sql.append("	    ,A.ACTING_TIME                                                ACTING_TIME       ");
		sql.append("	    ,A.ACTING_ID                                                  ACTING_ID         ");
		sql.append("	    ,A.HO_DONG                                                    HO_DONG           ");
		sql.append("	    ,A.HO_CODE                                                    HO_CODE           ");
		sql.append("	    ,IFNULL(FN_ADM_LOAD_USER_NAME(A.CHULGO_ID, :f_hosp_code), '') CHULGO_ID_NAME    ");
		sql.append("	    ,IFNULL(FN_ADM_LOAD_USER_NAME(A.IPGO_ID, :f_hosp_code), '')   IPGO_ID_NAME      ");
		sql.append("	    ,IFNULL(FN_ADM_LOAD_USER_NAME(A.ACTING_ID, :f_hosp_code), '') ACTING_ID_NAME    ");
		sql.append("	    ,C.SUNAME                                                     SUNAME		    ");
		sql.append("	    ,A.CHULGO_ALL_YN                                              CHULGO_ALL_YN	    ");
		sql.append("	    ,B.MAGAM_GUBUN                                                MAGAM_GUBUN	    ");
		sql.append("	    ,A.SEQ                                                        SEQ			    ");
		sql.append("	    ,CONCAT(DATE_FORMAT(A.CHULGO_DATE, '%Y%m%d'), A.CHULGO_TIME)				    ");
		sql.append("	FROM OUT0101 C								                                        ");
		sql.append("	JOIN DRG3010 B ON C.BUNHO         = B.BUNHO	                                        ");
		sql.append("	              AND C.HOSP_CODE     = B.HOSP_CODE                                     ");
		sql.append("	JOIN DRG3041 A ON B.JUBSU_DATE    = A.JUBSU_DATE                                    ");
		sql.append("	              AND B.DRG_BUNHO     = A.DRG_BUNHO	                                    ");
		sql.append("	              AND B.HOSP_CODE     = A.HOSP_CODE	                                    ");
		sql.append("	WHERE A.HOSP_CODE     = :f_hosp_code			                                    ");
		sql.append("	  AND A.CHULGO_DATE   = STR_TO_DATE(:f_chulgo_date, '%Y/%m/%d') 			        ");
		sql.append("	  AND A.BUNHO         LIKE IF(:f_bunho IS NULL OR :f_bunho = '','%',:f_bunho)       ");
		sql.append("	  AND A.HO_DONG       LIKE CONCAT(:f_ho_dong, '%')	                                ");
		sql.append("	ORDER BY DRG_BUNHO, SERIAL_V, SEQ					                                ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_chulgo_date", chulgoDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ho_dong", hoDong);
		
		List<DRG3041P01grdChulgoListInfo> listData = new JpaResultMapper().list(query, DRG3041P01grdChulgoListInfo.class);
		return listData;
	}

	@Override
	public List<DRG3041P01grdChulgoJUSAOrderInfo> getDRG3041P01grdChulgoJUSAOrderInfo(String hospCode, String language,
			String serialV, String jusuDate, String drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.ORDER_DATE AS CHAR)            ORDER_DATE	                                                                                            ");
		sql.append("	      ,IFNULL(A.MIX_GROUP, '')             MIX_GROUP	                                                                                            ");
		sql.append("	      ,A.JAERYO_CODE           JAERYO_CODE                                                                                              ");
		sql.append("	      ,B.JAERYO_NAME           JAERYO_NAME                                                                                              ");
		sql.append("	      ,CAST(A.ORD_SURYANG AS CHAR)           ORD_SURYANG                                                                                              ");
		sql.append("	      ,A.DV_TIME               DV_TIME	                                                                                                ");
		sql.append("	      ,CAST(A.DV AS CHAR)                    DV		                                                                                                ");
		sql.append("	      ,CAST(A.NALSU AS CHAR)                 NALSU	                                                                                                ");
		sql.append("	      ,A.ORDER_DANUI           ORDER_DANUI                                                                                              ");
		sql.append("	      ,IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language) , '')                                        ");
		sql.append("	                               DANUI_NAME                                                                                               ");
		sql.append("	      ,A.BOGYONG_CODE          BOGYONG_CODE                                                                                             ");
		sql.append("	      ,CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))     ");
		sql.append("	                               BOGYONG_NAME                                                                                             ");
		sql.append("	      ,A.POWDER_YN             POWDER_YN                                                                                                ");
		sql.append("	      ,IFNULL(CONCAT(A.REMARK, ' ', FN_DRG_LOAD_DRG0120_PATTERN('I', A.FKOCS2003, :f_hosp_code)), '')                                               ");
		sql.append("	                               REMARK                                                                                                   ");
		sql.append("	      ,IFNULL(A.DV_1, '')                  DV_1                                                                                                     ");
		sql.append("	      ,IFNULL(A.DV_2, '')                  DV_2                                                                                                     ");
		sql.append("	      ,IFNULL(A.DV_3, '')                  DV_3                                                                                                     ");
		sql.append("	      ,IFNULL(A.DV_4, '')                  DV_4                                                                                                     ");
		sql.append("	      ,IFNULL(A.DV_5, '')                  DV_5                                                                                                     ");
		sql.append("	      ,A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN                                                                                          ");
		sql.append("	      ,A.PHARMACY              PHARMACY		                                                                                            ");
		sql.append("	      ,A.DRG_PACK_YN           DRG_PACK_YN	                                                                                            ");
		sql.append("	      ,IFNULL(FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language), '')                                          ");
		sql.append("	                               JUSA_NAME 	                                                                                            ");
		sql.append("	      ,D.SUNAME                SUNAME		                                                                                            ");
		sql.append("	      ,CAST(A.DRG_BUNHO AS CHAR)             DRG_BUNHO	                                                                                            ");
		sql.append("	      ,CAST(A.JUBSU_DATE AS CHAR)            JUBSU_DATE	                                                                                            ");
		sql.append("	      ,A.BUNHO                 BUNHO	                                                                                                ");
		sql.append("	      ,A.HO_DONG               HO_DONG	                                                                                                ");
		sql.append("	     , A.DC_YN                 DC_YN                                                                                                    ");
		sql.append("	     , CAST(A.FKOCS2003 AS CHAR)             FKOCS2003                                                                                                ");
		sql.append("	     , CAST(A.FKINP1001 AS CHAR)             FKINP1001                                                                                                ");
		sql.append("	     , CAST(A.GROUP_SER AS CHAR)             GROUP_SER                                                                                                ");
		sql.append("	     , CONCAT(LPAD(A.DRG_BUNHO, 4, '0'), DATE_FORMAT(A.ORDER_DATE,'%Y%m%d')                                                             ");
		sql.append("	       , LPAD(A.GROUP_SER, 4, '0'), IFNULL(A.MIX_GROUP, ' '), CAST(A.FKOCS2003 AS CHAR))                                                ");
		sql.append("	                               ORDER_BY_KEY						                                                                        ");
		sql.append("	FROM DRG3010 A													                                                                        ");
		sql.append("	JOIN INV0110 B ON B.HOSP_CODE            = A.HOSP_CODE	                                                                                ");
		sql.append("	              AND B.JAERYO_CODE          = A.JAERYO_CODE                                                                                ");
		sql.append("	LEFT JOIN DRG0120 C ON C.HOSP_CODE       = A.HOSP_CODE	                                                                                ");
		sql.append("	                   AND C.BOGYONG_CODE    = A.BOGYONG_CODE	                                                                            ");
		sql.append("	JOIN OUT0101 D ON D.HOSP_CODE            = A.HOSP_CODE		                                                                            ");
		sql.append("	              AND D.BUNHO                = A.BUNHO			                                                                            ");
		sql.append("	JOIN DRG3011 E ON E.HOSP_CODE            = A.HOSP_CODE		                                                                            ");
		sql.append("	              AND E.BUNHO                = A.BUNHO			                                                                            ");
		sql.append("	              AND E.FKOCS2003            = A.FKOCS2003 		                                                                            ");
		sql.append("	              AND E.GROUP_SER            = :f_serial_v		                                                                            ");
		sql.append("	WHERE A.HOSP_CODE            = :f_hosp_code                                                                                             ");
		sql.append("	  AND A.JUBSU_DATE           = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                                                                                            ");
		sql.append("	  AND A.DRG_BUNHO            = :f_drg_bunho					                                                                            ");
		sql.append("	  AND A.BUNRYU1              = '4'							                                                                            ");
		sql.append("	ORDER BY ORDER_BY_KEY										                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", jusuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_language", language);
		query.setParameter("f_serial_v", serialV);
		
		List<DRG3041P01grdChulgoJUSAOrderInfo> listData = new JpaResultMapper().list(query, DRG3041P01grdChulgoJUSAOrderInfo.class);
		return listData;
	}

	@Override
	public PrDrgMakeBarCodeResultInfo callPrDrgMakeBarCode(String hospCode, String barCodeNo, String iudGubun, String userId, Date iDate,
			String userGubun, String bunho) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_MAKE_BARCODE");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BARCODE_NO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_BUNHO", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_HO_DONG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUNAME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUNAME2", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUBSU_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_IPGO_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DRG_BUNHO", Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUSA_YN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_RETURN", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BARCODE_NO", barCodeNo);
		query.setParameter("I_IUD_GUBUN", iudGubun);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_DATE", iDate);
		query.setParameter("I_USER_GUBUN", userGubun);
		query.setParameter("I_BUNHO", bunho);
		
		String ioBunho = (String)query.getOutputParameterValue("IO_BUNHO");
		String ioHoDong = (String)query.getOutputParameterValue("IO_HO_DONG");
		String ioSuname = (String)query.getOutputParameterValue("IO_SUNAME");
		String ioSuname2 = (String)query.getOutputParameterValue("IO_SUNAME2");
		Date ioJusuDate = (Date)query.getOutputParameterValue("IO_JUBSU_DATE");
		Date ioIpgoDate = (Date)query.getOutputParameterValue("IO_IPGO_DATE");
		Integer ioDrgBunho = (Integer)query.getOutputParameterValue("IO_DRG_BUNHO");
		String ioJusaYn = (String)query.getOutputParameterValue("IO_JUSA_YN");
		String ioReturn = (String)query.getOutputParameterValue("IO_RETURN");
		
		PrDrgMakeBarCodeResultInfo pInfo = new PrDrgMakeBarCodeResultInfo();
		pInfo.setIoBunho(ioBunho);
		pInfo.setIoHoDong(ioHoDong);
		pInfo.setIoSuname(ioSuname);
		pInfo.setIoSuname2(ioSuname2);
		pInfo.setIoJusuDate(ioJusuDate);
		pInfo.setIoIpgoDate(ioIpgoDate);
		pInfo.setIoDrgBunho(ioDrgBunho);
		pInfo.setIoJusaYn(ioJusaYn);
		pInfo.setIoReturn(ioReturn);
		
		return pInfo;
	}

	@Override
	public List<DRG3041P05grdMixListInfo> getDRG3041P05grdMixListInfo(String hospCode, String bunryu1, String hoDong,
			String ipGoDate, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT                                                                      ");
		sql.append("	       B.BUNHO                            BUNHO                                      ");
		sql.append("	     , A.JUBSU_DATE                       JUBSU_DATE                                 ");
		sql.append("	     , A.DRG_BUNHO                        DRG_BUNHO                                  ");
		sql.append("	     , A.SERIAL_V                         SERIAL_V                                   ");
		sql.append("	     , A.CHULGO_DATE                      CHULGO_DATE                                ");
		sql.append("	     , A.CHULGO_TIME                      CHULGO_TIME                                ");
		sql.append("	     , A.CHULGO_ID                        CHULGO_ID                                  ");
		sql.append("	     , A.IPGO_DATE                        IPGO_DATE                                  ");
		sql.append("	     , A.IPGO_TIME                        IPGO_TIME                                  ");
		sql.append("	     , A.IPGO_ID                          IPGO_ID                                    ");
		sql.append("	     , A.ACTING_DATE                      ACTING_DATE                                ");
		sql.append("	     , A.ACTING_TIME                      ACTING_TIME                                ");
		sql.append("	     , A.ACTING_ID                        ACTING_ID                                  ");
		sql.append("	     , D.HO_DONG1                         HO_DONG                                    ");
		sql.append("	     , D.HO_CODE1                         HO_CODE                                    ");
		sql.append("	     , FN_ADM_LOAD_USER_NAME(A.CHULGO_ID,:f_hosp_code)                               ");
		sql.append("	                                          CHULGO_ID_NAME                             ");
		sql.append("	     , FN_ADM_LOAD_USER_NAME(A.IPGO_ID,:f_hosp_code)                                 ");
		sql.append("	                                          IPGO_ID_NAME                               ");
		sql.append("	     , FN_ADM_LOAD_USER_NAME(A.ACTING_ID,:f_hosp_code)                               ");
		sql.append("	                                          ACTING_ID_NAME                             ");
		sql.append("	     , C.SUNAME                           SUNAME                                     ");
		sql.append("	     , A.MIX_DATE                         MIX_DATE                                   ");
		sql.append("	     , A.MIX_TIME                         MIX_TIME                                   ");
		sql.append("	     , FN_ADM_LOAD_USER_NAME(A.MIX_ID,:f_hosp_code)                                  ");
		sql.append("	                                          MIX_ID_NAME                                ");
		sql.append("	     , A.CHULGO_ALL_YN                    CHULGO_ALL_YN                              ");
		sql.append("	     , B.MAGAM_GUBUN                      MAGAM_GUBUN                                ");
		sql.append("	     , B.ORDER_DATE                       ORDER_DATE                                 ");
		sql.append("	     , A.SEQ                              SEQ                                        ");
		sql.append("	     , IF(A.MIX_DATE IS NULL, 'N', 'Y')   ACT_YN                                     ");
		sql.append("	     , IFNULL(                                                                       ");
		sql.append("	            (SELECT 'Y'                                                              ");
		sql.append("	             FROM DUAL                                                               ");
		sql.append("	             WHERE EXISTS (  SELECT 'Y'                                              ");
		sql.append("	                              FROM DRG3010 Y                                         ");
		sql.append("	                                 , DRG3011 X                                         ");
		sql.append("	                             WHERE X.HOSP_CODE   = A.HOSP_CODE                       ");
		sql.append("	                               AND X.JUBSU_DATE  = A.JUBSU_DATE                      ");
		sql.append("	                               AND X.DRG_BUNHO   = A.DRG_BUNHO                       ");
		sql.append("	                               AND X.GROUP_SER   = A.SERIAL_V                        ");
		sql.append("	                               AND Y.HOSP_CODE   = X.HOSP_CODE                       ");
		sql.append("	                               AND Y.FKOCS2003   = X.FKOCS2003                       ");
		sql.append("	                               AND Y.MIX_GROUP   IS NOT NULL                         ");
		sql.append("	               )                                                                     ");
		sql.append("	             ), 'N'                                                                  ");
		sql.append("	           )                              MIX_YN                                     ");
		sql.append("	     , IFNULL(                                                                       ");
		sql.append("	            (SELECT 'Y'                                                              ");
		sql.append("	               FROM DUAL                                                             ");
		sql.append("	              WHERE EXISTS (SELECT 'Y'                                               ");
		sql.append("	                              FROM DRG3010 Y                                         ");
		sql.append("	                                 , DRG3011 X                                         ");
		sql.append("	                             WHERE X.HOSP_CODE   = A.HOSP_CODE                       ");
		sql.append("	                               AND X.JUBSU_DATE  = A.JUBSU_DATE                      ");
		sql.append("	                               AND X.DRG_BUNHO   = A.DRG_BUNHO                       ");
		sql.append("	                               AND X.GROUP_SER   = A.SERIAL_V                        ");
		sql.append("	                               AND Y.HOSP_CODE   = X.HOSP_CODE                       ");
		sql.append("	                               AND Y.FKOCS2003   = X.FKOCS2003                       ");
		sql.append("	                               AND Y.BANNAB_YN   = 'Y'                               ");
		sql.append("	               )                                                                     ");
		sql.append("	             ), 'N'                                                                  ");
		sql.append("	           )                              BANNAB_YN                                  ");
		sql.append("	     , B.BUNRYU1                          BUNRYU1                                    ");
		sql.append("	  FROM DRG3041 A                                                                     ");
		sql.append("	  JOIN DRG3010 B ON B.HOSP_CODE   = A.HOSP_CODE                                      ");
		sql.append("	                AND B.JUBSU_DATE  = A.JUBSU_DATE                                     ");
		sql.append("	                AND B.DRG_BUNHO   = A.DRG_BUNHO                                      ");
		sql.append("	                AND B.BUNRYU1     LIKE CONCAT(:f_bunryu1,'%')                        ");
		sql.append("	  JOIN OUT0101 C ON C.HOSP_CODE   = A.HOSP_CODE                                      ");
		sql.append("	                AND C.BUNHO       = B.BUNHO                                          ");
		sql.append("	  JOIN INP1001 D ON D.HOSP_CODE   = B.HOSP_CODE                                      ");
		sql.append("	                AND D.PKINP1001   = B.FKINP1001                                      ");
		sql.append("	                AND D.HO_DONG1    LIKE :f_ho_dong                                    ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                                                  ");
		sql.append("	   AND A.IPGO_DATE   = STR_TO_DATE(:f_ipgo_date, '%Y/%m/%d')                                                  ");
		sql.append("	   AND A.BUNHO       LIKE IF(:f_bunho IS NULL OR :f_bunho = '','%',:f_bunho)         ");
		sql.append("	 ORDER BY DRG_BUNHO                                                                  ");
		sql.append("	        , SERIAL_V                                                                   ");
		sql.append("	        , SEQ                                                                        ");
		sql.append("	        , IPGO_DATE                                                                  ");
		sql.append("	        , IPGO_TIME                                                                  ");
		sql.append("	        , CHULGO_DATE                                                                ");
		sql.append("	        , CHULGO_TIME                                                                ");
		sql.append("	        , JUBSU_DATE                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunryu1", bunryu1);
		query.setParameter("f_ipgo_date", ipGoDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ho_dong", hoDong);
		
		List<DRG3041P05grdMixListInfo> listData = new JpaResultMapper().list(query, DRG3041P05grdMixListInfo.class);
		return listData;
	}

	@Override
	public List<DRG3041P05grdIpgoJUSAOrderInfo> getDRG3041P05grdIpgoJUSAOrderInfo(String hospCode, String language,
			String serialV, String jusuDate, Double drgBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.ORDER_DATE AS CHAR)            ORDER_DATE                                                                               ");
		sql.append("	     , IFNULL(A.MIX_GROUP, '')             MIX_GROUP                                                                                  ");
		sql.append("	     , A.JAERYO_CODE           JAERYO_CODE                                                                                            ");
		sql.append("	     , B.JAERYO_NAME           JAERYO_NAME                                                                                            ");
		sql.append("	     , CAST(A.ORD_SURYANG AS CHAR)           ORD_SURYANG                                                                              ");
		sql.append("	     , A.DV_TIME               DV_TIME                                                                                                ");
		sql.append("	     , '1'                     DV                                                                                                     ");
		sql.append("	     , CAST(A.NALSU AS CHAR)                 NALSU                                                                                    ");
		sql.append("	     , A.ORDER_DANUI           ORDER_DANUI                                                                                            ");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)                                                   ");
		sql.append("								   DANUI_NAME                                                                                             ");
		sql.append("	     , A.BOGYONG_CODE          BOGYONG_CODE                                                                                           ");
		sql.append("	     , CONCAT(A.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(A.JUSA_SPD_GUBUN,'0'), :f_hosp_code, :f_language))   ");
		sql.append("							       BOGYONG_NAME                                                                                           ");
		sql.append("	     , A.POWDER_YN             POWDER_YN                                                                                              ");
		sql.append("	     , IFNULL(CONCAT(A.REMARK, ' ', FN_DRG_LOAD_DRG0120_PATTERN('I', A.FKOCS2003, :f_hosp_code)), '')                                 ");
		sql.append("								   REMARK                                                                                                 ");
		sql.append("	     , IFNULL(A.DV_1, '')                  DV_1                                                                                       ");
		sql.append("	     , IFNULL(A.DV_2, '')                  DV_2                                                                                       ");
		sql.append("	     , IFNULL(A.DV_3, '')                  DV_3                                                                                       ");
		sql.append("	     , IFNULL(A.DV_4, '')                  DV_4                                                                                       ");
		sql.append("	     , IFNULL(A.DV_5, '')                  DV_5                                                                                       ");
		sql.append("	     , A.HUBAL_CHANGE_YN       HUBAL_CHANGE_YN                                                                                        ");
		sql.append("	     , A.PHARMACY              PHARMACY                                                                                               ");
		sql.append("	     , A.DRG_PACK_YN           DRG_PACK_YN                                                                                            ");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(A.JUSA,'0'), :f_hosp_code, :f_language)                                                    ");
		sql.append("								   JUSA_NAME                                                                                              ");
		sql.append("	     , D.SUNAME                SUNAME                                                                                                 ");
		sql.append("	     , CAST(A.DRG_BUNHO AS CHAR)             DRG_BUNHO                                                                                ");
		sql.append("	     , CAST(A.JUBSU_DATE AS CHAR)            JUBSU_DATE                                                                               ");
		sql.append("	     , A.BUNHO                 BUNHO                                                                                                  ");
		sql.append("	     , A.HO_DONG               HO_DONG                                                                                                ");
		sql.append("	     , A.DC_YN                 DC_YN                                                                                                  ");
		sql.append("	     , CAST(A.FKOCS2003 AS CHAR)             FKOCS2003                                                                                ");
		sql.append("	     , CAST(A.FKINP1001 AS CHAR)             FKINP1001                                                                                ");
		sql.append("	     , CAST(A.GROUP_SER AS CHAR)             GROUP_SER                                                                                ");
		sql.append("	     , A.HO_CODE               HO_CODE                                                                                                ");
		sql.append("	     , A.DOCTOR                DOCTOR                                                                                                 ");
		sql.append("	     , A.RESIDENT              RESIDENT                                                                                               ");
		sql.append("	     , A.GWA                   GWA                                                                                                    ");
		sql.append("	     , A.JAERYO_GUBUN          JAERYO_GUBUN                                                                                           ");
		sql.append("	     , A.DIVIDE                DIVIDE                                                                                                 ");
		sql.append("	     , CAST(A.ORDER_SURYANG AS CHAR)         ORDER_SURYANG                                                                            ");
		sql.append("	     , CAST(A.SUBUL_SURYANG AS CHAR)         SUBUL_SURYANG                                                                            ");
		sql.append("	     , A.SUBUL_DANUI           SUBUL_DANUI                                                                                            ");
		sql.append("	     , IFNULL(A.GROUP_YN, '')              GROUP_YN                                                                                   ");
		sql.append("	     , A.BUNRYU1               BUNRYU1                                                                                                ");
		sql.append("	     , IFNULL(A.BUNRYU2, '')               BUNRYU2                                                                                    ");
		sql.append("	     , IFNULL(A.BUNRYU3, '')               BUNRYU3                                                                                    ");
		sql.append("	     , IFNULL(A.BUNRYU4, '')               BUNRYU4                                                                                    ");
		sql.append("	     , IFNULL(A.CAUTION_CODE, '')          CAUTION_CODE                                                                               ");
		sql.append("	     , IFNULL(A.MIX_YN, '')                MIX_YN                                                                                     ");
		sql.append("	     , A.ATC_YN                ATC_YN                                                                                                 ");
		sql.append("	     , IFNULL(A.CHULGO_BUSEO, '')          CHULGO_BUSEO                                                                               ");
		sql.append("	     , IFNULL(A.CHULGO_DATE, '')           CHULGO_DATE                                                                                ");
		sql.append("	     , IFNULL(A.CHULGO_QTY, '')            CHULGO_QTY                                                                                 ");
		sql.append("	     , IFNULL(A.CHULGO_YN, '')             CHULGO_YN                                                                                  ");
		sql.append("	     , CAST(A.CHANGE_QTY AS CHAR)            CHANGE_QTY                                                                               ");
		sql.append("	     , A.TOIWON_DRG_YN         TOIWON_DRG_YN                                                                                          ");
		sql.append("	     , A.EMERGENCY             EMERGENCY                                                                                              ");
		sql.append("	     , IFNULL(A.DRG_PRN_YN, '')            DRG_PRN_YN                                                                                 ");
		sql.append("	     , IFNULL(A.DRG_PRN_TIME, '')          DRG_PRN_TIME                                                                               ");
		sql.append("	     , A.APPEND_YN             APPEND_YN                                                                                              ");
		sql.append("	     , A.ANTI_CANCER_YN        ANTI_CANCER_YN                                                                                         ");
		sql.append("	     , IFNULL(A.TPN_YN, '')                TPN_YN                                                                                     ");
		sql.append("	     , IFNULL(A.SELF_GUBUN, '')            SELF_GUBUN                                                                                 ");
		sql.append("	     , IFNULL(A.MAGAM_GUBUN, '')           MAGAM_GUBUN                                                                                ");
		sql.append("	     , IFNULL(A.MAGAM_SER, '')             MAGAM_SER                                                                                  ");
		sql.append("	     , IFNULL(A.DC_CONFIRM, '')            DC_CONFIRM                                                                                 ");
		sql.append("	     , A.BANNAB_YN             BANNAB_YN                                                                                              ");
		sql.append("	     , A.JUNDAL_PART           JUNDAL_PART                                                                                            ");
		sql.append("	     , IFNULL(A.SOURCE_FKOCS2003, '')      SOURCE_FKOCS2003                                                                           ");
		sql.append("	     , IFNULL(A.RE_USE_YN, '')             RE_USE_YN                                                                                  ");
		sql.append("	     , IFNULL(A.END_TYPE, '')              END_TYPE                                                                                   ");
		sql.append("	     , A.INPUT_GUBUN           INPUT_GUBUN                                                                                            ");
		sql.append("	     , A.ANTI_SOYU_YN          ANTI_SOYU_YN                                                                                           ");
		sql.append("	     , A.WONYOI_ORDER_YN       WONYOI_ORDER_YN                                                                                        ");
		sql.append("	     , IFNULL(A.WONNAE_SAYU_CODE, '')      WONNAE_SAYU_CODE                                                                           ");
		sql.append("	     , IFNULL(A.WONYOI_ACT_YN, '')         WONYOI_ACT_YN                                                                              ");
		sql.append("	     , IFNULL(A.INV_CONFIRM, '')           INV_CONFIRM                                                                                ");
		sql.append("	     , IFNULL(A.HO_DONG1, '')              HO_DONG1                                                                                   ");
		sql.append("	     , IFNULL(A.SUAK_JUBSU_DATE, '')       SUAK_JUBSU_DATE                                                                            ");
		sql.append("	     , IFNULL(A.SUAK_SER, '')              SUAK_SER                                                                                   ");
		sql.append("	     , IFNULL(A.BUNRYU6, '')               BUNRYU6                                                                                    ");
		sql.append("	     , IFNULL(A.TPN_JOJE_GUBUN, '')        TPN_JOJE_GUBUN                                                                             ");
		sql.append("	     , CAST(A.JUBSU_ILSI AS CHAR)            JUBSU_ILSI                                                                               ");
		sql.append("	     , IFNULL(A.DRG_PRN_DATE, '')          DRG_PRN_DATE                                                                               ");
		sql.append("	     , IFNULL(A.ER_MAGAM_DATE, '')         ER_MAGAM_DATE                                                                              ");
		sql.append("	     , IFNULL(A.ER_MAGAM_GUBUN, '')        ER_MAGAM_GUBUN                                                                             ");
		sql.append("	     , IFNULL(A.ER_MAGAM_SER, '')          ER_MAGAM_SER                                                                               ");
		sql.append("	     , A.JUNDAL_PART_RUN       JUNDAL_PART_RUN                                                                                        ");
		sql.append("	     , IFNULL(A.IU_JUSA_DATE, '')          IU_JUSA_DATE                                                                               ");
		sql.append("	     , IFNULL(A.MAYAK_PRINT_YN, '')        MAYAK_PRINT_YN                                                                             ");
		sql.append("	     , IFNULL(A.FKDRG3011, '')             FKDRG3011                                                                                  ");
		sql.append("	     , IFNULL(A.OUT_BF_DC, '')             OUT_BF_DC                                                                                  ");
		sql.append("	     , CAST(A.HOPE_DATE AS CHAR)             HOPE_DATE                                                                                ");
		sql.append("	     , IFNULL(A.JUSA_SPD_GUBUN, '')        JUSA_SPD_GUBUN                                                                             ");
		sql.append("	     , IFNULL(A.JUSA, '')                  JUSA                                                                                       ");
		sql.append("	     , CONCAT(LPAD(A.DRG_BUNHO, 4, '0'), DATE_FORMAT(A.ORDER_DATE,'%Y%m%d')                                                           ");
		sql.append("	       ,LPAD(A.GROUP_SER, 4, '0'), IFNULL(A.MIX_GROUP, ' '), CAST(A.FKOCS2003 AS CHAR))                                               ");
		sql.append("								   ORDER_BY_KEY                                                                                           ");
		sql.append("	  FROM DRG3010 A                                                                                                                      ");
		sql.append("	  JOIN INV0110 B ON B.HOSP_CODE            = A.HOSP_CODE                                                                              ");
		sql.append("					AND B.JAERYO_CODE          = A.JAERYO_CODE                                                                            ");
		sql.append("	  LEFT JOIN DRG0120 C ON C.HOSP_CODE       = A.HOSP_CODE                                                                              ");
		sql.append("						 AND C.BOGYONG_CODE    = A.BOGYONG_CODE                                                                           ");
		sql.append("	  JOIN OUT0101 D ON D.HOSP_CODE            = A.HOSP_CODE                                                                              ");
		sql.append("					AND D.BUNHO                = A.BUNHO                                                                                  ");
		sql.append("	  JOIN DRG3011 E ON E.HOSP_CODE            = A.HOSP_CODE                                                                              ");
		sql.append("				    AND E.BUNHO                = A.BUNHO                                                                                  ");
		sql.append("				    AND E.FKOCS2003            = A.FKOCS2003                                                                              ");
		sql.append("				    AND E.GROUP_SER            = :f_serial_v                                                                              ");
		sql.append("	 WHERE A.HOSP_CODE            = :f_hosp_code                                                                                          ");
		sql.append("	   AND A.JUBSU_DATE           = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                                                                ");
		sql.append("	   AND A.DRG_BUNHO            = :f_drg_bunho                                                                                          ");
		sql.append("	   AND A.BUNRYU1              = ('4')                                                                                                 ");
		sql.append("	 ORDER BY ORDER_BY_KEY                                                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_serial_v", serialV);
		query.setParameter("f_jubsu_date", jusuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		List<DRG3041P05grdIpgoJUSAOrderInfo> listData = new JpaResultMapper().list(query, DRG3041P05grdIpgoJUSAOrderInfo.class);
		return listData;
	}

	@Override
	public List<DRG3041P06grdActListInfo> getDRG3041P06grdActListInfo(String hospCode, String ipgoDate, String bunho,
			String bunryu1, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																									                ");
		sql.append("	  	DISTINCT B.BUNHO                            											BUNHO, 						");
		sql.append("	    CAST(A.JUBSU_DATE AS CHAR)                                                              JUBSU_DATE,					");
		sql.append("	    CAST(A.DRG_BUNHO AS CHAR)                                                               DRG_BUNHO,					");
		sql.append("	    A.SERIAL_V                                                                              SERIAL_V,					");
		sql.append("	    CAST(A.CHULGO_DATE AS CHAR)                                                             CHULGO_DATE,				");
		sql.append("	    A.CHULGO_TIME                                                                           CHULGO_TIME,				");
		sql.append("	    A.CHULGO_ID                                                                             CHULGO_ID,					");
		sql.append("	    CAST(A.IPGO_DATE AS CHAR)                                                               IPGO_DATE,					");
		sql.append("	    A.IPGO_TIME                                                                             IPGO_TIME,					");
		sql.append("	    A.IPGO_ID                                                                               IPGO_ID,					");
		sql.append("	    CAST(A.ACTING_DATE AS CHAR)                                                             ACTING_DATE,				");
		sql.append("	    A.ACTING_TIME                                                                           ACTING_TIME,				");
		sql.append("	    A.ACTING_ID                                                                             ACTING_ID,					");
		sql.append("	    D.HO_DONG1                                                                              HO_DONG,					");
		sql.append("	    D.HO_CODE1                         														HO_CODE,					");
		sql.append("	    FN_ADM_LOAD_USER_NAME(A.CHULGO_ID, :f_hosp_code)                                        CHULGO_ID_NAME,				");
		sql.append("	    FN_ADM_LOAD_USER_NAME(A.IPGO_ID, :f_hosp_code)                                          IPGO_ID_NAME,				");
		sql.append("	    FN_ADM_LOAD_USER_NAME(A.ACTING_ID, :f_hosp_code)                                        ACTING_ID_NAME,				");
		sql.append("	    C.SUNAME                                                                                SUNAME,						");
		sql.append("	    CAST(A.MIX_DATE AS CHAR)                                                                MIX_DATE,					");
		sql.append("	    A.MIX_TIME                                                                              MIX_TIME,					");
		sql.append("	    FN_ADM_LOAD_USER_NAME(A.MIX_ID, :f_hosp_code)    										MIX_ID_NAME,				");
		sql.append("	    A.CHULGO_ALL_YN                                                                         CHULGO_ALL_YN,				");
		sql.append("	    B.MAGAM_GUBUN                                                                           MAGAM_GUBUN,				");
		sql.append("	    CAST(B.ORDER_DATE AS CHAR)                                                              ORDER_DATE,					");
		sql.append("	    CAST(A.SEQ AS CHAR)                                                                     SEQ,						");
		sql.append("	    CASE A.ACTING_DATE WHEN NULL THEN 'N' ELSE 'Y' END ACT_YN,															");
		sql.append("	    IFNULL(																									            ");
		sql.append("	            	( 																									    ");
		sql.append("	            		SELECT 'Y' 																							");
		sql.append("	               		FROM DUAL																							");
		sql.append("	              		WHERE EXISTS (	SELECT 'Y'																			");
		sql.append("	                              		FROM DRG3010 Y JOIN DRG3011 X														");
		sql.append("	                               						ON Y.HOSP_CODE 	= X.HOSP_CODE										");
		sql.append("	                               						AND Y.FKOCS2003 = X.FKOCS2003										");
		sql.append("	                             		WHERE X.HOSP_CODE   		= A.HOSP_CODE											");
		sql.append("	                               				AND X.JUBSU_DATE    = A.JUBSU_DATE											");
		sql.append("	                               				AND X.DRG_BUNHO     = A.DRG_BUNHO											");
		sql.append("	                               				AND X.GROUP_SER     = A.SERIAL_V											");
		sql.append("	                               				AND Y.BANNAB_YN     = 'Y'													");
		sql.append("	               					)																						");
		sql.append("	             	), 'N'																									");
		sql.append("	           )                              													BANNAB_YN,					");
		sql.append("	  	B.BUNRYU1                          														BUNRYU1						");
		sql.append("	FROM																									                ");
		sql.append("	  	DRG3041 A 	JOIN 	DRG3010 B																						");
		sql.append("	  				ON 		A.HOSP_CODE = B.HOSP_CODE																		");
		sql.append("	   				AND 	A.JUBSU_DATE = B.JUBSU_DATE																		");
		sql.append("	   				AND 	A.DRG_BUNHO = B.DRG_BUNHO																		");
		sql.append("	   				JOIN 	OUT0101 C																						");
		sql.append("				   	ON 		A.HOSP_CODE = C.HOSP_CODE																		");
		sql.append("				   	AND 	B.BUNHO       = C.BUNHO																			");
		sql.append("				 	JOIN 	INP1001 D																						");
		sql.append("				   	ON 		B.HOSP_CODE = D.HOSP_CODE																		");
		sql.append("				   	AND 	B.FKINP1001 = D.PKINP1001																		");
		sql.append("	WHERE																									                ");
		sql.append("	 	A.HOSP_CODE   		= :f_hosp_code																					");
		sql.append("	   	AND A.IPGO_DATE   	= :f_ipgo_date																					");
		sql.append("	   	AND A.BUNHO       	LIKE :f_bunho 																					");
		sql.append("	   	AND B.BUNRYU1     	LIKE :f_bunryu1																					");
		sql.append("	   	AND D.HO_DONG1    	LIKE :f_ho_dong																					");
		sql.append("	ORDER BY																									            ");
		sql.append("	  	DRG_BUNHO,																									        ");
		sql.append("	    SERIAL_V,																									        ");
		sql.append("	    SEQ,																									            ");
		sql.append("	    IPGO_DATE,																									        ");
		sql.append("	    IPGO_TIME,																									        ");
		sql.append("	    CHULGO_DATE,																									    ");
		sql.append("	    CHULGO_TIME,																									    ");
		sql.append("	    JUBSU_DATE																									        ");
		
		if((StringUtils.isEmpty(bunho))|| bunho == "")
			bunho = "%";
		if((StringUtils.isEmpty(bunryu1))|| bunryu1 == "")
			bunryu1 = "%";
		else
			bunryu1 = bunryu1 + "%";
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ipgo_date", ipgoDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_bunryu1", bunryu1);
		query.setParameter("f_ho_dong", hoDong);
		
		List<DRG3041P06grdActListInfo> listInfo = new JpaResultMapper().list(query, DRG3041P06grdActListInfo.class);
		return listInfo;
	}
	
	@Override
	public Integer drg3010P99DeleteDrg3041(String hospCode, String jubsuDate, Double drgBunho){
		StringBuilder sql = new StringBuilder();		
		sql.append("     DELETE FROM DRG3041                                                        ");
		sql.append("      WHERE HOSP_CODE  = :f_hosp_code                                           ");
		sql.append("        AND JUBSU_DATE = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')                 ");
		sql.append("        AND DRG_BUNHO  = :f_drg_bunho                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		
		return query.executeUpdate();
	}
	
}

