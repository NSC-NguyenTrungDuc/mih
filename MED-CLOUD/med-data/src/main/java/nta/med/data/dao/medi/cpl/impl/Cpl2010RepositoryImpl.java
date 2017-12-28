package nta.med.data.dao.medi.cpl.impl;

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
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect1ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00LayJungboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00LayOrderListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00LayResultListTempListItemInfo;
import nta.med.data.model.ihis.cpls.CPL2010R00GetBarCodeInfo;
import nta.med.data.model.ihis.cpls.CPL2010R01LaySpecimenListItemInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01CHANGETIMEgrdSpecimenInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01grdPaInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01grdPaListInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01grdSpecimenInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01layBarcodeTempInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01layBarcodeTempInfo2;
import nta.med.data.model.ihis.cpls.CPL2010U02grdSpecimenInfo;
import nta.med.data.model.ihis.cpls.CPL2010U02layBarcodeInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00GrdPartListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00LayBarCodeTemp2ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00LayBarCodeTempListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00LaySpecimenInfoListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U01MaxInfoListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00SelectFromStandardListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00SelectInOutGubunListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02ExecuteSelectInOutGubunListItemInfo;
import nta.med.data.model.ihis.cpls.CPL7001Q01LayDailyReportInfo;
import nta.med.data.model.ihis.cpls.CPL7001Q02LayMonthlyReportInfo;
import nta.med.data.model.ihis.cpls.CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00FwkPaCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdOrderCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdPaCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdTubeCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdTubeCPL2010ListItemInfo2;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00LayChkNameCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00PrCplBunhoLoadMinCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.MultiResultViewSearchDataSigeyulInfo;
import nta.med.data.model.ihis.cpls.PrCplSpecimenInfoResultListItemInfo;
import nta.med.data.model.ihis.drgs.CPL2010U01grdTubeInfo;
import nta.med.data.model.ihis.ocso.OCSACT2GetPatientListCPLInfo;
/**
 * @author dainguyen.
 */
public class Cpl2010RepositoryImpl implements Cpl2010RepositoryCustom {
	
	private static final Log LOG = LogFactory.getLog(Cpl2010RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo> getCPL2010U00ChangeTimeGrdSpecimenListItemInfo(String hospCode, String orderDate, String bunho, String gwa,String gubun, String doctor, String inOutGubun,String language) {
		StringBuilder sql= new StringBuilder();
		gubun =gubun+"%";
		sql.append(" SELECT A.PKCPL2010                                                                                                                                                               "  );
		sql.append(" ,case A.SUNAB_DATE when NULL then 'N' else 'Y' end   SUNAB_YN                                                                                                                    "  );
		sql.append(" , case A.JUBSU_DATE when NULL then 'N' else 'Y' end  JUBSU_FLAG                                                                                                                  "  );
		sql.append(" , F.SLIP_NAME                                                                                                                                                                    "  );
		sql.append(" , A.HANGMOG_CODE                                                                                                                                                                 "  );
		sql.append(" , C.GUMSA_NAME                                                                                                                                                                   "  );
		sql.append(" , A.SPECIMEN_CODE                                                                                                                                                                "  );
		sql.append(" , IFNULL(B.CODE_NAME_RE, B.CODE_NAME)  SPECIMEN_NAME                                                                                                                             "  );
		sql.append(" , A.EMERGENCY                                                                                                                                                                    "  );
		sql.append(" , IFNULL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME                                                                                                                                 "  );
		sql.append(" , A.SPECIMEN_SER                                                                                                                                                                 "  );
		sql.append(" , FN_XRT_LOAD_COMMENT(:f_hosp_code,A.FKOCS1003,A.FKOCS2003)  COMMENT_JU_CODE                                                                                                     "  );
		sql.append(" , A.FKOCS1003                                                                                                                                                                    "  );
		sql.append(" , IFNULL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN                                                                                                                               "  );
		sql.append(" , case A.PART_JUBSU_DATE when NULL then 'N' else 'Y' end PART_JUBSU_FLAG                                                                                                         "  );
		sql.append(" ,case A.GUM_JUBSU_DATE when NULL then 'N' else 'Y' end GUM_JUBSU_FLAG                                                                                                            "  );
		sql.append(" , A.DUMMY                                                                                                                                                                        "  );
		sql.append(" ,case C.GROUP_GUBUN when NULL then 'N' else 'Y' end MODIFY_YN                                                                                                                    "  );
		sql.append(" , case A.HANGMOG_CODE                                                                                                                                                            "  );
		sql.append(" when A.GROUP_HANGMOG then                                                                                                                                                        "  );
		sql.append("   case C.GROUP_GUBUN                                                                                                                                                             "  );
		sql.append("   when '02' then 'N'                                                                                                                                                             "  );
		sql.append("   else 'Y' end                                                                                                                                                                   "  );
		sql.append(" else 'N' end MODIFY_YN_1                                                                                                                                                         "  );
		sql.append(" , A.JUNDAL_GUBUN                                                                                                                                                                 "  );
		sql.append(" , A.JUBSUJA                                                                                                                                                                      "  );
		sql.append(" , A.ORDER_DATE                                                                                                                                                                   "  );
		sql.append(" , A.BUNHO                                                                                                                                                                        "  );
		sql.append(" , A.JUBSU_DATE                                                                                                                                                                   "  );
		sql.append(" , A.JUBSU_TIME                                                                                                                                                                   "  );
		sql.append(" , A.ORDER_TIME                                                                                                                                                                   "  );
		sql.append(" FROM                                                                                                                                                                             "  );
		sql.append("   ((( CPL0109 B RIGHT JOIN CPL2010 A ON B.HOSP_CODE = A.HOSP_CODE AND B.CODE = A.SPECIMEN_CODE AND B.CODE_TYPE  = '04')                                                          "  );
		sql.append(" 	  LEFT JOIN CPL0109 D ON  D.HOSP_CODE = A.HOSP_CODE AND D.CODE = A.TUBE_CODE AND D.CODE_TYPE = '02' )                                                                         "  );
		sql.append(" 	  LEFT JOIN CPL0001 F ON  F.HOSP_CODE = A.HOSP_CODE AND F.SLIP_CODE = A.SLIP_CODE)                                                                                            "  );
		sql.append(" 	  JOIN CPL0101 C ON C.HOSP_CODE = A.HOSP_CODE  AND C.HANGMOG_CODE  = A.HANGMOG_CODE AND C.SPECIMEN_CODE = A.SPECIMEN_CODE AND C.EMERGENCY = A.EMERGENCY                       "  );
		sql.append("                                                                                                                                                                                  "  );
		sql.append(" WHERE A.HOSP_CODE                = :f_hosp_code                                                                                                                               	  "  );
		sql.append(" AND B.LANGUAGE                = :f_language                                                                                                                                      "  );
		sql.append(" AND D.LANGUAGE                = :f_language                                                                                                                                      "  );
		sql.append(" AND A.ORDER_DATE               = STR_TO_DATE(:f_order_date,'%Y/%m/%d')                                                                                                           "  );
		sql.append(" AND A.BUNHO                    = :f_bunho                                                                                                                                        "  );
		sql.append(" AND A.GWA                      = :f_gwa                                                                                                                                          "  );
		sql.append(" AND IFNULL(A.GUBUN,'%')            LIKE :f_gubun                                                                                                      						      "  );
		sql.append(" AND A.DOCTOR                   = :f_doctor                                                                                                                                       "  );
		sql.append(" AND A.IN_OUT_GUBUN             = :f_in_out_gubun                                                                                                                                 "  );
		sql.append(" AND IFNULL(A.DC_YN,'N')           = 'N'                                                                                                                                          "  );
		sql.append(" AND A.JUBSU_DATE              IS NULL                                                                                                                                            "  );
		sql.append(" AND ( (A.AFTER_ACT_YN IS NULL) OR                                                                                                                                                "  );
		sql.append("     (A.AFTER_ACT_YN =  'N' ) )                                                                                                                                                   "  );
		sql.append(" ORDER BY LPAD(A.HANGMOG_CODE,10,'0')   																																	   	  ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_in_out_gubun", inOutGubun);
		query.setParameter("f_language", language);
		List<CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo> listChangeTimeGrd= new JpaResultMapper().list(query, CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo.class);
		return listChangeTimeGrd;
	}

	@Override
	public List<CplsCPL2010U00FwkPaCPL2010ListItemInfo> getCPL2010U00FwkPaListItemInfo(String hospCode,String language, String orderDate, String jubsuYn, String bunho,
			String suname, String gwaName, String orderTime) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                             ");
		sql.append(" A.BUNHO                                                                                     ");
		sql.append(" , B.SUNAME                                                                                  ");
		sql.append(" , A.IN_OUT_GUBUN                                                                            ");
		sql.append(" , FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language)                            ");
		sql.append(" , case FN_SCH_RESER_TIME(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)               ");
		sql.append(" when NULL then A.ORDER_TIME                                                                 ");
		sql.append(" else FN_SCH_RESER_TIME(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) end ORDER_TIME   ");
		sql.append(" , FN_CPL_SPECIMEN_PRN_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)   TODAY_YN                 ");
		sql.append(" , FN_SCH_RESER_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)          RESER_YN                 ");
		sql.append(" FROM OUT0101 B                                                                              ");
		sql.append(" , CPL2010 A                                                                                 ");
		sql.append(" WHERE A.HOSP_CODE        = :f_hosp_code                                                     ");
		sql.append(" AND B.HOSP_CODE        = A.HOSP_CODE                                                        ");
		sql.append(" AND ((A.ORDER_DATE     = STR_TO_DATE(:f_order_date,'%c/%d/%Y') AND A.RESER_DATE IS NULL )   ");
		sql.append(" OR  (A.RESER_DATE     = STR_TO_DATE(:f_order_date,'%c/%d/%Y') ))                            ");
		sql.append(" AND case A.JUBSU_DATE                                                                       ");
		sql.append(" when NULL then 'N'                                                                          ");
		sql.append(" else 'Y' end LIKE :f_jubsu_yn                                                               ");
		sql.append(" AND A.IN_OUT_GUBUN   = 'O'                                                                  ");
		sql.append(" AND B.BUNHO          = A.BUNHO                                                              ");
		sql.append(" AND ((A.BUNHO        LIKE CONCAT('%',IFNULL(:f_bunho,''),'%'))                              ");
		sql.append(" OR  (B.SUNAME       LIKE CONCAT('%',IFNULL(:f_suname,''),'%'))                              ");
		sql.append(" OR  (A.GWA_NAME     LIKE CONCAT('%',IFNULL(:f_gwa_name,''),'%'))                            ");
		sql.append(" OR  (A.ORDER_TIME   LIKE CONCAT('%',IFNULL(:f_order_time,''),'%')))                         ");
		sql.append(" ORDER BY TODAY_YN DESC,ORDER_TIME                                                           ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_jubsu_yn", jubsuYn);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_suname", suname);
		query.setParameter("f_gwa_name", gwaName);
		query.setParameter("f_order_time", orderTime);
		List<CplsCPL2010U00FwkPaCPL2010ListItemInfo> listFwkPa= new JpaResultMapper().list(query, CplsCPL2010U00FwkPaCPL2010ListItemInfo.class);
		return listFwkPa;
	}

	@Override
	public List<CplsCPL2010U00GrdOrderCPL2010ListItemInfo> getCplsCPL2010U00GrdOrderListItemInfo(String hospCode,String language,String bunho,
			String mijubsu,String reserYn,String fromDate,String toDate,String doctor,String emergencyYn) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                                          ");
		sql.append("  A.ORDER_DATE                                                                                                            ");
		sql.append(" , A.ORDER_TIME                                                                                                           ");
		sql.append(" , FN_BAS_LOAD_GWA_NAME((case A.IN_OUT_GUBUN when 'I' then A.HO_DONG else A.GWA end),A.ORDER_DATE,:f_hosp_code,:f_language) GWA_NAME               ");
		sql.append(" , A.IN_OUT_GUBUN                                                                                                         ");
		sql.append(" , FN_OCS_LOAD_ORDER_DOCTOR_NAME(:f_hosp_code,case A.IN_OUT_GUBUN when 'I' then A.FKOCS2003 else A.FKOCS1003 end) DOCTOR_NAME          ");
		sql.append(" , A.JUBSU_DATE                                                                                                           ");
		sql.append(" , A.JUBSU_TIME                                                                                                           ");
		sql.append(" , A.AFTER_ACT_YN                                                                                                         ");
		sql.append(" , A.BUNHO                                                                                                                ");
		sql.append(" , A.GWA                                                                                                                  ");
		sql.append(" , A.GUBUN                                                                                                                ");
		sql.append(" , A.DOCTOR                                                                                                               ");
		sql.append(" , A.RESER_DATE                                                                                                           ");
		sql.append(" , A.JUBSUJA                                                                                                              ");
		sql.append(" , FN_ADM_LOAD_USER_NM(:f_hosp_code,A.JUBSUJA, A.JUBSU_DATE) JUBSUJA_NAME                                                 ");
		sql.append(" , A.GROUP_SER                                                                                                            ");
		sql.append(" ,CONCAT(DATE_FORMAT(A.JUBSU_DATE,'%Y-%m-%d'),DATE_FORMAT(A.ORDER_DATE, '%Y-%m-%d'),RPAD(A.ORDER_TIME, 4, '0')) KEY1      ");
		sql.append(" , B.IF_DATA_SEND_YN                                                                                                      ");
		sql.append(" FROM OCS1003 B                                                                                                           ");
		sql.append(" , CPL2010 A                                                                                                              ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                                                                                        ");
		sql.append(" AND A.BUNHO      = :f_bunho                                                                                              ");
		sql.append(" AND A.IN_OUT_GUBUN = 'O'                                                                                                 ");
		sql.append(" AND IFNULL(A.DC_YN,'N') = 'N'                                                                                            ");
		sql.append(" AND (  (:f_mijubsu = '2' AND A.JUBSU_DATE IS NULL)                                                                       ");
		sql.append("      OR(:f_mijubsu = '3' AND A.JUBSU_DATE IS NOT NULL)                                                                   ");
		sql.append("     )                                                                                                                    ");
		sql.append(" AND ((:f_reser_yn = 'Y' AND A.RESER_DATE BETWEEN :f_from_date AND :f_to_date)                                            ");
		sql.append("   OR (:f_reser_yn = 'N' AND A.RESER_DATE IS NULL AND (A.ORDER_DATE BETWEEN :f_from_date AND :f_to_date)))                ");
		sql.append(" AND A.DOCTOR = :f_doctor                                                                                                 ");
		sql.append(" AND B.HOSP_CODE = A.HOSP_CODE                                                                                            ");
		sql.append(" AND B.PKOCS1003 = A.FKOCS1003                                                                                            ");
		sql.append(" AND (:f_emergency_yn = 'N' AND IFNULL(B.EMERGENCY, 'N') = 'N'                                                            ");
		sql.append("   OR :f_emergency_yn = 'Y' AND IFNULL(B.EMERGENCY, 'N') = 'Y')                                                           ");
		sql.append(" AND EXISTS (SELECT 'X'                                                                                                   ");
		sql.append(" FROM OUT1001 X                                                                                                           ");
		sql.append(" WHERE X.HOSP_CODE   = A.HOSP_CODE                                                                                        ");
		sql.append(" AND X.NAEWON_DATE = IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                   ");
		sql.append(" AND X.BUNHO       = A.BUNHO                                                                                              ");
		sql.append(" AND X.GWA         != '03')                                                                                               ");
		sql.append(" ORDER BY A.JUBSU_DATE DESC, IFNULL(A.RESER_DATE, A.ORDER_DATE) DESC, A.ORDER_DATE DESC, RPAD(A.ORDER_TIME, 4, '0') DESC  limit 10");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_mijubsu", mijubsu);
		query.setParameter("f_reser_yn", reserYn);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_emergency_yn", emergencyYn);
		
		List<CplsCPL2010U00GrdOrderCPL2010ListItemInfo> listGrdOrder= new JpaResultMapper().list(query, CplsCPL2010U00GrdOrderCPL2010ListItemInfo.class);
		return listGrdOrder;
	}

	@Override
	public List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo2> getCplsCPL2010U00GrdTubeListItemInfo(String hospCode,String language, String jubuDate, String jubsuTime, String bunho) {
		StringBuilder sql=new StringBuilder();
		sql.append(" SELECT X.TUBE_CODE,                                             ");
		sql.append(" X.TUBE_NAME,                                                    ");
		sql.append(" SUM(X.TUBE_COUNT)   CNT                                         ");
		sql.append(" FROM (SELECT MIN(A.TUBE_CODE) TUBE_CODE,                        ");
		sql.append(" MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language))  TUBE_NAME,             ");
		sql.append(" FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code) TUBE_COUNT,                   ");
		sql.append(" A.HOSP_CODE                                                     ");
		sql.append(" FROM CPL0101 B,                                                 ");
		sql.append(" CPL2010 A                                                       ");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                            ");
		sql.append(" AND B.HOSP_CODE     = A.HOSP_CODE                               ");
		sql.append(" AND A.JUBSU_DATE    = STR_TO_DATE(:f_jubsu_date,'%Y/%m/%d')     ");
		sql.append(" AND A.JUBSU_TIME    = :f_jubsu_time                             ");
		sql.append(" AND A.BUNHO         = :f_bunho                                  ");
		sql.append(" AND A.JUBSU_DATE    IS NOT NULL                                 ");
		sql.append(" AND B.HANGMOG_CODE  = A.HANGMOG_CODE                            ");
		sql.append(" AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                           ");
		sql.append(" AND B.EMERGENCY     = A.EMERGENCY                               ");
		sql.append(" GROUP BY A.HOSP_CODE,                                           ");
		sql.append(" A.TUBE_CODE,                                                    ");
		sql.append(" A.IN_OUT_GUBUN,                                                 ");
		sql.append(" A.SPECIMEN_SER,                                                 ");
		sql.append(" A.GWA,                                                          ");
		sql.append(" A.BUNHO      ) X                                                ");
		sql.append(" WHERE X.HOSP_CODE = :f_hosp_code                                ");
		sql.append(" GROUP BY X.TUBE_CODE, X.TUBE_NAME                               ");
		sql.append(" ORDER BY 1                                                      ");
		 Query query= entityManager.createNativeQuery(sql.toString());
		 query.setParameter("f_hosp_code", hospCode);
		 query.setParameter("f_language", language);
		 query.setParameter("f_jubsu_date", jubuDate);
		 query.setParameter("f_jubsu_time", jubsuTime);
		 query.setParameter("f_bunho", bunho);
		 List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo2> listGrdTube= new JpaResultMapper().list(query, CplsCPL2010U00GrdTubeCPL2010ListItemInfo2.class);
		return listGrdTube;
	}

	@Override
	public List<CplsCPL2010U00LayChkNameCPL2010ListItemInfo> getCplsCPL2010U00LayChkNameListItemInfo(String hospCode, String bunho, String reserDate) {
		StringBuilder sql=new StringBuilder();
		sql.append(" SELECT A.SUNAME                  ,                                       ");
		sql.append(" A.ORDER_DATE   ORDER_DATE1,                                              ");
		sql.append(" B.ORDER_DATE    ORDER_DATE2,                                             ");
		sql.append(" CONCAT(C.GUMSA_NAME,'-',D.CODE_NAME)                                     ");
		sql.append(" FROM CPL0109 D,                                                          ");
		sql.append(" CPL0101 C,                                                               ");
		sql.append(" CPL2010 B,                                                               ");
		sql.append(" CPL2010 A                                                                ");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                                     ");
		sql.append(" AND B.HOSP_CODE     = A.HOSP_CODE                                        ");
		sql.append(" AND C.HOSP_CODE     = A.HOSP_CODE                                        ");
		sql.append(" AND D.HOSP_CODE     = A.HOSP_CODE                                        ");
		sql.append(" AND A.BUNHO         = :f_bunho                                           ");
		sql.append(" AND A.RESER_DATE    = :f_reser_date                                      ");
		sql.append(" AND A.JUBSU_DATE   IS NULL                                               ");
		sql.append(" AND B.BUNHO         = A.BUNHO                                            ");
		sql.append(" AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                     ");
		sql.append(" AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                    ");
		sql.append(" AND ((   B.RESER_DATE    = A.RESER_DATE                                  ");
		sql.append(" AND B.ORDER_DATE   <> A.ORDER_DATE )                                     ");
		sql.append(" OR B.RESER_DATE = A.ORDER_DATE                                           ");
		sql.append(" OR B.ORDER_DATE = A.RESER_DATE)                                          ");
		sql.append(" AND B.GWA          <> A.GWA                                              ");
		sql.append(" AND B.JUBSU_DATE   IS NULL                                               ");
		sql.append(" AND C.HANGMOG_CODE  = A.HANGMOG_CODE                                     ");
		sql.append(" AND C.EMERGENCY     = A.EMERGENCY                                        ");
		sql.append(" AND C.SPECIMEN_CODE = A.SPECIMEN_CODE                                    ");
		sql.append(" AND D.CODE_TYPE     = '04'                                               ");
		sql.append(" AND D.CODE          = A.SPECIMEN_CODE                                    ");
		sql.append(" GROUP BY A.SUNAME, C.GUMSA_NAME, D.CODE_NAME, A.ORDER_DATE, B.ORDER_DATE ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_date", reserDate);
		List<CplsCPL2010U00LayChkNameCPL2010ListItemInfo> listlayChkname= new JpaResultMapper().list(query, CplsCPL2010U00LayChkNameCPL2010ListItemInfo.class);
		return listlayChkname;
	}

	@Override
	public String getCPL2010U00CheckInjCplOrder(String ioGubun, String bunho,Date orderDate,String hospCode) {
		StringBuilder sql=new StringBuilder();
		sql.append(" SELECT FN_INJ_CPL_CHK_YN(:f_io_gubun, :f_bunho, :f_order_date, 'INJ',:f_hosp_code) ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hosp_code", hospCode);
		List<String> checkInjCp=query.getResultList();
		if(!CollectionUtils.isEmpty(checkInjCp)){
			return checkInjCp.get(0);
		}
		return null;
	}

	@Override
	public List<CplsCPL2010U00GrdPaCPL2010ListItemInfo> getCplsCPL2010U00GrdPaCPL2010ListItemInfo(String hospCode,String language, String fromDate, String toDate,String bunho) {
		StringBuilder sql=new StringBuilder();
		sql.append("  SELECT A.BUNHO                                                                                                                                           " );
		sql.append(" , MAX(B.SUNAME)                                                                                                                                           " );
		sql.append(" , MAX(A.IN_OUT_GUBUN)                                                                                                                                     " );
		sql.append(" , MAX(FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language)) GWA_NAME                                                                                                       " );
		sql.append(" , FN_SCH_RESER_YN1(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)   RESER_YN                                                           " );
		sql.append(" , MAX(A.DOCTOR)                                                                                                                                           " );
		sql.append(" , A.DOCTOR_NAME                                                                                                                                           " );
		sql.append(" , IFNULL(A.RESER_DATE, A.ORDER_DATE)                                   KIJUN_DATE                                                                         " );
		sql.append(" , IFNULL(C.EMERGENCY, 'N')                                             EMERGENCY_YN ,''                                                                   " );
		sql.append(" , IFNULL(P.NUMBER_PROTOCOL, 0)                                                               															   " );
		sql.append(" FROM OCS1003 C                                                                                                                                            " );
		sql.append(" , OUT0101 B                                                                                                                                               " );
		sql.append(" , CPL2010 A                                                                                                                                               " );
		sql.append("LEFT JOIN (select COUNT(cpp.CLIS_PROTOCOL_ID) NUMBER_PROTOCOL, cpp.BUNHO from CLIS_PROTOCOL_PATIENT cpp                                                    ");
		sql.append("		 INNER JOIN CLIS_PROTOCOL	cp	ON cpp.CLIS_PROTOCOL_ID = cp.CLIS_PROTOCOL_ID                                                                      ");
		sql.append("		 AND cpp.HOSP_CODE = :f_hosp_code										AND				                                                           ");
		sql.append("		cpp.ACTIVE_FLG = 1										AND		                                                                                   ");
		sql.append("		cp.ACTIVE_FLG = 1										AND		                                                                                   ");
		sql.append("		cp.STATUS_FLG <> 1										AND		                                                                                   ");
		sql.append("		cp.END_DATE <= SYSDATE() GROUP BY cpp.BUNHO ) P ON A.BUNHO = P.BUNHO	                                                                           ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                       " );
		sql.append(" AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                          " );
		sql.append(" AND ((:f_bunho IS NULL AND IFNULL(A.RESER_DATE, A.ORDER_DATE) between STR_TO_DATE(:f_from_date,'%Y/%m/%d') and STR_TO_DATE(:f_to_date,'%Y/%m/%d'))        " );
		sql.append(" OR  (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))                                                                                                        " );
		sql.append(" AND A.JUBSU_DATE IS NOT NULL                                                                                                                              " );
		sql.append(" AND A.IN_OUT_GUBUN   = 'O'                                                                                                                                " );
		sql.append(" AND B.BUNHO          = A.BUNHO                                                                                                                            " );
		sql.append(" AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                        " );
		sql.append(" AND C.PKOCS1003      = A.FKOCS1003                                                                                                                        " );
		sql.append(" AND EXISTS (SELECT 'X'                                                                                                                                    " );
		sql.append(" FROM OUT1001 X                                                                                                                                            " );
		sql.append(" WHERE X.HOSP_CODE   = A.HOSP_CODE                                                                                                                         " );
		sql.append(" AND X.NAEWON_DATE = IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                                                    " );
		sql.append(" AND X.BUNHO       = A.BUNHO                                                                                                                               " );
		sql.append(" AND X.GWA         != '03')                                                                                                                                " );
		sql.append(" GROUP BY A.BUNHO                                                                                                                                          " );
		sql.append(" , FN_SCH_RESER_YN1(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)                                                                                   " );
		sql.append(" , A.DOCTOR_NAME                                                                                                                                           " );
		sql.append(" , FN_REQUEST_GWA_NAME(:f_hosp_code,:f_language,'O',A.BUNHO, A.GWA, A.ORDER_DATE)                                                                                                   " );
		sql.append(" , IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                                                                      " );
		sql.append(" , IFNULL(C.EMERGENCY, 'N')                                                                                                                                " );
		sql.append(" ORDER BY MAX(A.JUBSU_DATE) DESC, MAX(A.JUBSU_TIME) DESC																									");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		if(StringUtils.isEmpty(bunho)){
			bunho = null;
		}
		query.setParameter("f_bunho", bunho);
		List<CplsCPL2010U00GrdPaCPL2010ListItemInfo> listGrdPa= new JpaResultMapper().list(query, CplsCPL2010U00GrdPaCPL2010ListItemInfo.class);
		return listGrdPa;
	}
	//TODO check and opt getCplsCPL2010U00GrdPaCPL2010ListItemInfo2 AND getCplsCPL2010U00GrdPaCPL2010ListItemInfo
	@Override
	public List<CplsCPL2010U00GrdPaCPL2010ListItemInfo> getCplsCPL2010U00GrdPaCPL2010ListItemInfo2(String hospCode,String language, String fromDate, String toDate, String bunho) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                                                                                                        " );
		sql.append(" , MAX(B.SUNAME)                                                                                                                                       " );
		sql.append(" , MAX(A.IN_OUT_GUBUN)                                                                                                                                 " );
		sql.append(" , MAX(FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language)) GWA_NAME                                                                                                   " );
		sql.append(" , FN_SCH_RESER_YN1(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)   RESER_YN                                                                    " );
		sql.append(" , MAX(A.DOCTOR)                                                                                                                                       " );
		sql.append(" , A.DOCTOR_NAME                                                                                                                                       " );
		sql.append(" , IFNULL(A.RESER_DATE, A.ORDER_DATE)    KIJUN_DATE                                                                                                    " );
		sql.append(" , IFNULL(C.EMERGENCY, 'N')     EMERGENCY_YN                                                                                                           " );
		sql.append(" , MAX(A.ORDER_TIME)    NAEWON_TIME                                                                                                                    " );
		sql.append(" , IFNULL(P.NUMBER_PROTOCOL, 0)                                                                                                                        " );
		sql.append(" FROM OCS1003 C                                                                                                                                        " );
		sql.append(" , OUT0101 B                                                                                                                                           " );
		sql.append(" , CPL2010 A                                                                                                                                           " );
		sql.append("LEFT JOIN (select COUNT(cpp.CLIS_PROTOCOL_ID) NUMBER_PROTOCOL, cpp.BUNHO from CLIS_PROTOCOL_PATIENT cpp                                                ");
		sql.append("		 INNER JOIN CLIS_PROTOCOL	cp	ON cpp.CLIS_PROTOCOL_ID = cp.CLIS_PROTOCOL_ID                                                                  ");
		sql.append("		 AND cpp.HOSP_CODE = :f_hosp_code										AND				                                                       ");
		sql.append("		cpp.ACTIVE_FLG = 1										AND		                                                                               ");
		sql.append("		cp.ACTIVE_FLG = 1										AND		                                                                               ");
		sql.append("		cp.STATUS_FLG <> 1										AND		                                                                               ");
		sql.append("		cp.END_DATE <= SYSDATE() GROUP BY cpp.BUNHO ) P ON A.BUNHO = P.BUNHO	                                                                       ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                   " );
		sql.append(" AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                      " );
		sql.append("AND ((:f_bunho IS NULL AND STR_TO_DATE(IFNULL(DATE_FORMAT(A.RESER_DATE,'%Y/%m/%d'), DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')), '%Y/%m/%d' ) between STR_TO_DATE(:f_from_date,'%Y/%m/%d') and STR_TO_DATE(:f_to_date,'%Y/%m/%d'))      " );
		sql.append(" OR  (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))                                                                                                    " );
		sql.append(" AND A.JUBSU_DATE IS NULL                                                                                                                              " );
		sql.append(" AND A.IN_OUT_GUBUN   = 'O'                                                                                                                            " );
		sql.append(" AND B.BUNHO          = A.BUNHO                                                                                                                        " );
		sql.append(" AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                    " );
		sql.append(" AND C.PKOCS1003      = A.FKOCS1003                                                                                                                    " );
		sql.append(" AND EXISTS (SELECT 'X'                                                                                                                                " );
		sql.append(" FROM OUT1001 X                                                                                                                                        " );
		sql.append(" WHERE X.HOSP_CODE = A.HOSP_CODE                                                                                                                       " );
		sql.append(" AND X.NAEWON_DATE = IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                                                " );
		sql.append(" AND X.BUNHO = A.BUNHO                                                                                                                                 " );
		sql.append(" AND IFNULL(X.NAEWON_YN, 'N') != 'N'                                                                                                                   " );
		sql.append(" AND X.GWA   != '03')                                                                                                                                  " );
		sql.append(" GROUP BY A.BUNHO                                                                                                                                      " );
		sql.append(" , FN_SCH_RESER_YN1(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)                                                                               " );
		sql.append(" , A.DOCTOR_NAME                                                                                                                                       " );
		sql.append(" , FN_REQUEST_GWA_NAME(:f_hosp_code,:f_language,'O',A.BUNHO, A.GWA, A.ORDER_DATE)                                                                                               " );
		sql.append(" , IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                                                                  " );
		sql.append(" , IFNULL(C.EMERGENCY, 'N')                                                                                                                            " );
		sql.append(" ORDER BY IFNULL(A.RESER_DATE, A.ORDER_DATE) , NAEWON_TIME																								");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		if(StringUtils.isEmpty(bunho)){
			bunho = null;
		}
		query.setParameter("f_bunho", bunho);
		List<CplsCPL2010U00GrdPaCPL2010ListItemInfo> listGrdPa= new JpaResultMapper().list(query, CplsCPL2010U00GrdPaCPL2010ListItemInfo.class);
		return listGrdPa;
	}

	@Override
	public List<CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo> getCPL2010U00OrderCancelGrdOrder(String hospCode,String language, String bunho, Date orderDate) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.FKOCS1003                                                 ");
		sql.append(" , A.HANGMOG_CODE                                                   ");
		sql.append(" , C.GUMSA_NAME                                                     ");
		sql.append(" , A.SPECIMEN_CODE                                                  ");
		sql.append(" , FN_CPL_LOAD_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language) SPECIMEN_NAME        ");
		sql.append(" , A.SPECIMEN_SER                                                   ");
		sql.append(" , A.PKCPL2010                                                      ");
		sql.append(" , IFNULL(B.IF_DATA_SEND_YN, 'N')  IF_DATA_SEND_YN                  ");
		sql.append(" FROM CPL2010 A                                                     ");
		sql.append(" , OCS1003 B                                                        ");
		sql.append(" , CPL0101 C                                                        ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                   ");
		sql.append(" AND A.HANGMOG_CODE = C.HANGMOG_CODE                                ");
		sql.append(" AND A.EMERGENCY = C.EMERGENCY                                      ");
		sql.append(" AND A.FKOCS1003 = B.PKOCS1003                                      ");
		sql.append(" AND A.BUNHO = :f_bunho                                             ");
		sql.append(" AND DATE_FORMAT(A.SYS_DATE,'%Y-%m-%d') = :f_order_date             ");
		sql.append(" AND A.JUBSU_DATE IS NOT NULL										");	
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		List<CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo> listOrderCanerGrd= new JpaResultMapper().list(query, CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo.class);
		return listOrderCanerGrd;
	}

	@Override
	public List<CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo> getCPL2010U00PaqryGrdPaListItemInfo(String hospCode,String language, String orderDate, String jubsyYn, String bunho,
			String suname, String gwaName, String orderTime) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                                            				" );
		sql.append(" , B.SUNAME                                                                                				" );
		sql.append(" , A.IN_OUT_GUBUN                                                                          				" );
		sql.append(" , FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language) GWA_NAME                 				 " );
		sql.append(" ,case FN_SCH_RESER_TIME(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)              				" );
		sql.append(" when NULL then A.ORDER_TIME                                                               				" );
		sql.append(" else FN_SCH_RESER_TIME(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) end ORDER_TIME             " );
		sql.append(" , MAX(FN_CPL_SPECIMEN_PRN_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003))   TODAY_YN          " );
		sql.append(" , FN_SCH_RESER_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)          RESER_YN               " );
		sql.append(" , A.DOCTOR_NAME                                                                          		      " );
		sql.append(" FROM OUT0101 B                                                                           		      " );
		sql.append(" , CPL2010 A                                                                              		      " );
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                      		      " );
		sql.append(" AND B.HOSP_CODE    = A.HOSP_CODE                                                         		      " );
		sql.append(" AND ((A.ORDER_DATE     = STR_TO_DATE(:f_order_date,'%Y/%m/%d') AND A.RESER_DATE IS NULL )		      " );
		sql.append(" OR  (A.RESER_DATE     = STR_TO_DATE(:f_order_date,'%Y/%m/%d') ))                         		      " );
		sql.append(" AND case A.JUBSU_DATE                                                                    		      " );
		sql.append(" when NULL then 'N'                                                                       		      " );
		sql.append(" else 'Y' end LIKE :f_jubsu_yn                                                            		      " );
		sql.append(" AND A.IN_OUT_GUBUN   = 'O'                                                               		      " );
		sql.append(" AND B.BUNHO          = A.BUNHO                                                           		      " );
		sql.append(" AND ((A.BUNHO        LIKE CONCAT('%',IFNULL(:f_bunho,''),'%'))                           		      " );
		sql.append(" OR  (B.SUNAME       LIKE CONCAT('%',IFNULL(:f_suname,''),'%'))                           		      " );
		sql.append(" OR  (A.GWA_NAME     LIKE CONCAT('%',IFNULL(:f_gwa_name,''),'%'))                         		      " );
		sql.append(" OR  (A.ORDER_TIME   LIKE  CONCAT('%',IFNULL(:f_order_time,''),'%')))                     		      " );
		sql.append(" GROUP BY A.BUNHO, B.SUNAME, A.IN_OUT_GUBUN,                                              		      " );
		sql.append(" FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language),                                       " );
		sql.append(" case FN_SCH_RESER_TIME(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)                           " );
		sql.append(" when NULL then A.ORDER_TIME                                                               				" );
		sql.append(" else FN_SCH_RESER_TIME(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) end,                       " );
		sql.append(" FN_SCH_RESER_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003),                                  " );
		sql.append(" A.DOCTOR_NAME                                                                          			  " );
		sql.append(" ORDER BY ORDER_TIME DESC																				");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_jubsu_yn", jubsyYn);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_suname", suname);
		query.setParameter("f_gwa_name", gwaName);
		query.setParameter("f_order_time", orderTime);
		List<CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo> listPayGrdPa=new JpaResultMapper().list(query, CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo.class);
		return listPayGrdPa;
	}

	@Override
	public List<CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo> getCPL2010U00PaqryGrdPaListItemInfo2(String hospCode,String language, String orderDate, String jubsyYn, String bunho,
			String suname, String gwaName, String orderTime) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                                                " );
		sql.append(" , B.SUNAME                                                                                    " );
		sql.append(" , A.IN_OUT_GUBUN                                                                              " );
		sql.append(" , FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language) GWA_NAME                                              " );
		sql.append(" , case FN_SCH_RESER_TIME(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)                              " );
		sql.append(" when NULL then A.ORDER_TIME                                                                   " );
		sql.append(" else FN_SCH_RESER_TIME(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) end ORDER_TIME                 " );
		sql.append(" , MAX(FN_CPL_SPECIMEN_PRN_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003))   TODAY_YN              " );
		sql.append(" , FN_SCH_RESER_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)          RESER_YN                   " );
		sql.append(" , A.DOCTOR_NAME                                                                               " );
		sql.append(" FROM OUT0101 B                                                                                " );
		sql.append(" , CPL2010 A                                                                                   " );
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                           " );
		sql.append(" AND B.HOSP_CODE    = A.HOSP_CODE                                                              " );
		sql.append(" AND ((A.ORDER_DATE     = STR_TO_DATE(:f_order_date,'%Y/%m/%d') AND A.RESER_DATE IS NULL )     " );
		sql.append(" OR  (A.RESER_DATE     = STR_TO_DATE(:f_order_date,'%Y/%m/%d') ))                              " );
		sql.append(" AND case A.JUBSU_DATE                                                                         " );
		sql.append(" when NULL then 'N'                                                                            " );
		sql.append(" else 'Y' end LIKE :f_jubsu_yn                                                                 " );
		sql.append(" AND A.IN_OUT_GUBUN   = 'O'                                                                    " );
		sql.append(" AND B.BUNHO          = A.BUNHO                                                                " );
		sql.append(" AND ((A.BUNHO       LIKE  CONCAT('%',IFNULL(:f_bunho,''),'%'))                                " );
		sql.append(" OR  (B.SUNAME       LIKE CONCAT('%',IFNULL(:f_suname,''),'%'))                                " );
		sql.append(" OR  (A.GWA_NAME     LIKE CONCAT('%',IFNULL(:f_gwa_name,''),'%'))                              " );
		sql.append(" OR  (A.ORDER_TIME   LIKE CONCAT('%',IFNULL(:f_order_time,''),'%')))                           " );
		sql.append(" GROUP BY A.BUNHO, B.SUNAME, A.IN_OUT_GUBUN, A.ORDER_TIME,   A.FKOCS1003,A.FKOCS2003,           " );
		sql.append(" FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language),                                                        " );
		sql.append(" case  FN_SCH_RESER_TIME(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)                               " );
		sql.append(" when NULL then A.ORDER_TIME                                                                   " );
		sql.append(" else FN_SCH_RESER_TIME(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) end,                           " );
		sql.append(" FN_SCH_RESER_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003),                                      " );
		sql.append(" A.DOCTOR_NAME                                                                                 " );
		sql.append(" ORDER BY ORDER_TIME																			");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_jubsu_yn", jubsyYn);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_suname", suname);
		query.setParameter("f_gwa_name", gwaName);
		query.setParameter("f_order_time", orderTime);
		List<CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo> listPayGrdPa2=new JpaResultMapper().list(query, CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo.class);
		return listPayGrdPa2;
	}

	@Override
	public List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo> getCPL2010U00GrdTubeQueryStarting(String hospCode,String language, String orderDate, String orderTime, String bunho) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT X.TUBE_CODE,                                              						   " );
		sql.append(" X.TUBE_NAME,                                                     						   " );
		sql.append(" SUM(X.TUBE_COUNT)   CNT                                          						   " );
		sql.append(" FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,     						   " );
		sql.append(" MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language))            TUBE_NAME,     " );
		sql.append(" FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)               TUBE_COUNT,       		" );
		sql.append(" A.HOSP_CODE                                                    						 " );
		sql.append(" FROM CPL0101 B,                                                						 " );
		sql.append(" CPL2010 A                                                      						 " );
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                           						 " );
		sql.append(" AND B.HOSP_CODE     = A.HOSP_CODE                              						 " );
		sql.append(" AND A.ORDER_DATE    = STR_TO_DATE(:f_order_date,'%Y/%m/%d')    						 " );
		sql.append(" AND A.ORDER_TIME    = :f_order_time                            						 " );
		sql.append(" AND A.BUNHO         = :f_bunho                                 						 " );
		sql.append(" AND A.JUBSU_DATE    IS NOT NULL                                						 " );
		sql.append(" AND B.HANGMOG_CODE  = A.HANGMOG_CODE                           						 " );
		sql.append(" AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                          						 " );
		sql.append(" AND B.EMERGENCY     = A.EMERGENCY                              						 " );
		sql.append(" GROUP BY A.HOSP_CODE,                                          						 " );
		sql.append(" A.TUBE_CODE,                                                   						 " );
		sql.append(" A.IN_OUT_GUBUN,                                                						 " );
		sql.append(" A.SPECIMEN_SER,                                                						 " );
		sql.append(" A.GWA,                                                         						 " );
		sql.append(" A.BUNHO      ) X                                               						 " );
		sql.append(" WHERE X.HOSP_CODE = :f_hosp_code                               						 " );
		sql.append(" GROUP BY X.TUBE_CODE, X.TUBE_NAME                              						 " );
		sql.append(" ORDER BY 1																					");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_order_time", orderTime);
		query.setParameter("f_bunho", bunho);
		List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo> listGrdTube= new JpaResultMapper().list(query, CplsCPL2010U00GrdTubeCPL2010ListItemInfo.class);
		return listGrdTube;
	}

	@Override
	public List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo2> getCPL2010U00GrdTubeQueryStarting2(String hospCode,String language, String orderDate, String orderTime, String bunho) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT X.TUBE_CODE,                                               							");
		sql.append("  X.TUBE_NAME,                                                     							");
		sql.append("  SUM(X.TUBE_COUNT)   CNT                                          							");
		sql.append("  FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,     							");
		sql.append("  MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language))            TUBE_NAME,     ");
		sql.append("  1                                                  TUBE_COUNT,                            ");
		sql.append("  A.HOSP_CODE                                                                               ");
		sql.append(" FROM CPL0101 B,                                                                            ");
		sql.append(" CPL2010 A                                                                                  ");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                                                       ");
		sql.append(" AND B.HOSP_CODE     = A.HOSP_CODE                                                          ");
		sql.append(" AND A.ORDER_DATE    = STR_TO_DATE(:f_order_date,'%Y/%m/%d')                                ");
		sql.append(" AND A.ORDER_TIME    = :f_order_time                                                        ");
		sql.append(" AND A.BUNHO         = :f_bunho                                                             ");
		sql.append(" AND A.JUBSU_DATE    IS NULL                                                                ");
		sql.append(" AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                       ");
		sql.append(" AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                      ");
		sql.append(" AND B.EMERGENCY     = A.EMERGENCY                                                          ");
		sql.append(" GROUP BY A.HOSP_CODE,                                                                      ");
		sql.append(" A.TUBE_CODE,                                                                               ");
		sql.append(" A.IN_OUT_GUBUN,                                                                            ");
		sql.append(" A.GWA,                                                                                     ");
		sql.append(" A.BUNHO      ) X                                                                           ");
		sql.append(" WHERE X.HOSP_CODE = :f_hosp_code                                                           ");
		sql.append(" GROUP BY X.TUBE_CODE, X.TUBE_NAME                                                          ");
		sql.append(" ORDER BY 1  														                        ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_order_time", orderTime);
		query.setParameter("f_bunho", bunho);
		List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo2> listGrdTube2= new JpaResultMapper().list(query, CplsCPL2010U00GrdTubeCPL2010ListItemInfo2.class);
		return listGrdTube2;
	}

	@Override
	public List<CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo> getCplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo(String hospCode, String orderDate, String bunho, String gwa,
			String gubun, String doctor, String inOutGubun) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.PKCPL2010                                                                                                                                                               "  );
		sql.append(" ,case A.SUNAB_DATE when NULL then 'N' else 'Y' end   SUNAB_YN                                                                                                                    "  );
		sql.append(" , case A.JUBSU_DATE when NULL then 'N' else 'Y' end  JUBSU_FLAG                                                                                                                  "  );
		sql.append(" , F.SLIP_NAME                                                                                                                                                                    "  );
		sql.append(" , A.HANGMOG_CODE                                                                                                                                                                 "  );
		sql.append(" , C.GUMSA_NAME                                                                                                                                                                   "  );
		sql.append(" , A.SPECIMEN_CODE                                                                                                                                                                "  );
		sql.append(" , IFNULL(B.CODE_NAME_RE, B.CODE_NAME)  SPECIMEN_NAME                                                                                                                             "  );
		sql.append(" , A.EMERGENCY                                                                                                                                                                    "  );
		sql.append(" , IFNULL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME                                                                                                                                 "  );
		sql.append(" , A.SPECIMEN_SER                                                                                                                                                                 "  );
		sql.append(" , FN_XRT_LOAD_COMMENT(A.FKOCS1003,A.FKOCS2003)  COMMENT_JU_CODE                                                                                                                  "  );
		sql.append(" , A.FKOCS1003                                                                                                                                                                    "  );
		sql.append(" , IFNULL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN                                                                                                                               "  );
		sql.append(" , case A.PART_JUBSU_DATE when NULL then 'N' else 'Y' end PART_JUBSU_FLAG                                                                                                         "  );
		sql.append(" ,case A.GUM_JUBSU_DATE when NULL then 'N' else 'Y' end GUM_JUBSU_FLAG                                                                                                            "  );
		sql.append(" , A.DUMMY                                                                                                                                                                        "  );
		sql.append(" ,case C.GROUP_GUBUN when NULL then 'N' else 'Y' end MODIFY_YN                                                                                                                    "  );
		sql.append(" , case A.HANGMOG_CODE                                                                                                                                                            "  );
		sql.append(" when A.GROUP_HANGMOG then                                                                                                                                                        "  );
		sql.append("   case C.GROUP_GUBUN                                                                                                                                                             "  );
		sql.append("   when '02' then 'N'                                                                                                                                                             "  );
		sql.append("   else 'Y' end                                                                                                                                                                   "  );
		sql.append(" else 'N' end MODIFY_YN_1                                                                                                                                                         "  );
		sql.append(" , A.JUNDAL_GUBUN                                                                                                                                                                 "  );
		sql.append(" , A.JUBSUJA                                                                                                                                                                      "  );
		sql.append(" , A.ORDER_DATE                                                                                                                                                                   "  );
		sql.append(" , A.BUNHO                                                                                                                                                                        "  );
		sql.append(" , A.JUBSU_DATE                                                                                                                                                                   "  );
		sql.append(" , A.JUBSU_TIME                                                                                                                                                                   "  );
		sql.append(" , A.ORDER_TIME                                                                                                                                                                   "  );
		sql.append(" FROM                                                                                                                                                                             "  );
		sql.append("   ((( CPL0109 B RIGHT JOIN CPL2010 A ON B.HOSP_CODE = A.HOSP_CODE AND B.CODE = A.SPECIMEN_CODE AND B.CODE_TYPE  = '04')                                                          "  );
		sql.append(" 	  LEFT JOIN CPL0109 D ON  D.HOSP_CODE = A.HOSP_CODE AND D.CODE = A.TUBE_CODE AND D.CODE_TYPE = '02' )                                                                         "  );
		sql.append(" 	  LEFT JOIN CPL0001 F ON  F.SLIP_CODE = A.SLIP_CODE)                                                                                                                          "  );
		sql.append(" 	  JOIN CPL0101 C ON C.HOSP_CODE = A.HOSP_CODE  AND C.HANGMOG_CODE  = A.HANGMOG_CODE AND C.SPECIMEN_CODE = A.SPECIMEN_CODE AND C.EMERGENCY = A.EMERGENCY                       "  );
		sql.append("                                                                                                                                                                                  "  );
		sql.append(" WHERE A.HOSP_CODE                = :f_hosp_code                                                                                                                                  "  );
		sql.append(" AND A.ORDER_DATE               = STR_TO_DATE(:f_order_date,'%Y/%m/%d')                                                                                                           "  );
		sql.append(" AND A.BUNHO                    = :f_bunho                                                                                                                                        "  );
		sql.append(" AND A.GWA                      = :f_gwa                                                                                                                                          "  );
		sql.append(" AND IFNULL(A.GUBUN,'%')           LIKE CONCAT(IFNULL(:f_gubun,''),'%')                                                                                                           "  );
		sql.append(" AND A.DOCTOR                   = :f_doctor                                                                                                                                       "  );
		sql.append(" AND A.IN_OUT_GUBUN             = :f_in_out_gubun                                                                                                                                 "  );
		sql.append(" AND IFNULL(A.DC_YN,'N')           = 'N'                                                                                                                                          "  );
		sql.append(" AND A.JUBSU_DATE              IS NULL                                                                                                                                            "  );
		sql.append(" AND ( (A.AFTER_ACT_YN IS NULL) OR                                                                                                                                                "  );
		sql.append("     (A.AFTER_ACT_YN =  'N' ) )                                                                                                                                                   "  );
		sql.append(" ORDER BY LPAD(A.HANGMOG_CODE,10,'0')																																				");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_in_out_gubun", inOutGubun);
		List<CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo> listChangeTimeGrd=new JpaResultMapper().list(query, CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo.class);
		return listChangeTimeGrd;
	}

	@Override
	public List<CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo> getCPL2010U00GrdSpecimenListItemInfo(String hospCode,String language, Date orderDate, String bunho, String gwa,
			String orderTime, String doctor, Date reserDate,Date jubsuDate, String jubsuTime, String jubsuja,Double groupSer, String serverYn, String emergencyYn) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.PKCPL2010                                                                                                                         ");
		sql.append("  , IF(A.SUNAB_DATE IS NULL ,'N', 'Y')       SUNAB_YN                                                                                       ");
		sql.append("  ,IF(A.JUBSU_DATE IS NULL ,'N', 'Y')   JUBSU_FLAG                                                                                         ");
		sql.append("  , F.SLIP_NAME                                                                                                                             ");
		sql.append("  , A.HANGMOG_CODE                                                                                                                          ");
		sql.append("  , C.GUMSA_NAME                                                                                                                            ");
		sql.append("  , A.SPECIMEN_CODE                                                                                                                         ");
		sql.append("  , B.CODE_NAME                       SPECIMEN_NAME                                                                                         ");
		sql.append("  , A.EMERGENCY                                                                                                                             ");
		sql.append("  , A.TUBE_CODE                                                                                                                             ");
		sql.append("  , IFNULL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME                                                                                          ");
		sql.append("  , A.SPECIMEN_SER                                                                                                                          ");
		sql.append("  , FN_CPL_SUB_COMMENT(:f_hosp_code,A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)  COMMENT_JU_CODE                                          ");
		sql.append("  , A.FKOCS1003                                                                                                                             ");
		sql.append("  , IFNULL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN                                                                                        ");
		sql.append("  , IF(A.PART_JUBSU_DATE IS NULL ,'N', 'Y')    PART_JUBSU_FLAG                                                                              ");
		sql.append("  ,IF(A.GUM_JUBSU_DATE IS NULL ,'N', 'Y')    GUM_JUBSU_FLAG                                                                                 ");
		sql.append("  , A.DUMMY                                                                                                                                 ");
		sql.append("  ,IF(C.GROUP_GUBUN = '03' ,'Y', 'N')    MODIFY_YN                                                                                         ");
		sql.append("  , case A.HANGMOG_CODE                                                                                                                     ");
		sql.append("  WHEN A.GROUP_HANGMOG THEN                                                                                                                 ");
		sql.append("   CASE C.GROUP_GUBUN                                                                                                                       ");
		sql.append("     WHEN '02' THEN 'N'                                                                                                                     ");
		sql.append("     ELSE 'Y' END                                                                                                                           ");
		sql.append("   ELSE  'N' END   MODIFY_YN_1                                                                                                              ");
		sql.append("  , A.JUNDAL_GUBUN                                                                                                                          ");
		sql.append("  , FN_CPL_LOAD_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)    JUNDAL_GUBUN_NAME                                                                         ");
		sql.append("  , A.JUBSUJA                                                                                                                               ");
		sql.append("  , A.ORDER_DATE                                                                                                                            ");
		sql.append("  , A.BUNHO                                                                                                                                 ");
		sql.append("  , A.JUBSU_DATE                                                                                                                            ");
		sql.append("  , A.JUBSU_TIME                                                                                                                            ");
		sql.append("  , A.ORDER_TIME                                                                                                                            ");
		sql.append("  , A.GROUP_HANGMOG                                                                                                                         ");
		sql.append("  , C.SPCIAL_NAME                                                                                                                           ");
		sql.append("  , FN_CPL_SPECIMEN_PRN_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) CAN_YN                                                                   ");
		sql.append("  , C.BARCODE BARCODE                                                                                                                       ");
		sql.append("  , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE,:f_hosp_code,:f_language) BARCODE_NAME                                                                                     ");
		sql.append("  , FN_XRT_LOAD_COMMENT(:f_hosp_code,A.FKOCS1003, A.FKOCS2003) DOC_COMMENT                                                                               ");
		sql.append("  , C.UITAK_CODE                                                                                                                            ");
		sql.append("  , IFNULL(C.MIDDLE_RESULT, 'N')                              MIDDLE_RESULT                                                                 ");
		sql.append("	FROM CPL0101 C LEFT OUTER JOIN CPL0001 F ON F.HOSP_CODE  = C.HOSP_CODE AND F.SLIP_CODE  = C.SLIP_CODE,									");
		sql.append("	CPL2010 A LEFT OUTER JOIN CPL0109 B ON B.HOSP_CODE   = A.HOSP_CODE AND B.CODE  = A.SPECIMEN_CODE AND B.CODE_TYPE   = '04' AND B.LANGUAGE = :f_language		");
		sql.append(" 	LEFT OUTER JOIN CPL0109 D ON D.HOSP_CODE = A.HOSP_CODE AND D.CODE  = A.TUBE_CODE AND D.CODE_TYPE = '02' AND D.LANGUAGE = :f_language ,OCS1003 O						");
		sql.append(" WHERE A.HOSP_CODE                = :f_hosp_code                                                                                            ");
		sql.append("  AND C.HOSP_CODE                = A.HOSP_CODE                                                                                              ");
		sql.append("  AND A.ORDER_DATE               = :f_order_date                                                                                            ");
		sql.append("  AND A.GROUP_SER                = :f_group_ser                                                                                             ");
		sql.append("  AND A.BUNHO                    = :f_bunho                                                                                                 ");
		sql.append("  AND A.GWA                      = :f_gwa                                                                                                   ");
		if(!StringUtils.isEmpty(orderTime)){
			sql.append("  AND IFNULL(A.ORDER_TIME,'0000')   = IFNULL(:f_order_time,'0000')                                                                          ");
		}
		sql.append("  AND A.DOCTOR                   = :f_doctor                                                                                                ");
		sql.append("  AND A.IN_OUT_GUBUN             = 'O'                                                                                                      ");
		sql.append("  AND A.JUBSU_DATE               IS NULL                                                                                                    ");
		sql.append("  AND (  ( :f_reser_yn = 'Y' AND A.RESER_DATE = :f_reser_date )                                                                             ");
		sql.append("      OR ( :f_reser_yn = 'N' AND A.RESER_DATE IS NULL ) )                                                                                   ");
		sql.append("  AND IFNULL(A.DC_YN,'N')           = 'N'                                                                                                   ");
		sql.append("  AND ( (A.AFTER_ACT_YN IS NULL) OR                                                                                                         ");
		sql.append("      (A.AFTER_ACT_YN =  'N' ) )                                                                                                            ");
		sql.append("  AND C.HANGMOG_CODE             = A.HANGMOG_CODE                                                                                           ");
		sql.append("  AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE                                                                                          ");
		sql.append("  AND C.EMERGENCY                = A.EMERGENCY                                                                                              ");
		sql.append("  AND O.HOSP_CODE                = A.HOSP_CODE                                                                                              ");
		sql.append("  AND O.PKOCS1003                = A.FKOCS1003                                                                                              ");
		sql.append("  AND (:f_emergency_yn = 'N' AND IFNULL(O.EMERGENCY, 'N') = 'N'                                                                             ");
		sql.append("   OR :f_emergency_yn = 'Y' AND IFNULL(O.EMERGENCY, 'N') = 'Y')                                                                             ");
		sql.append("  ORDER BY C.UITAK_CODE,                                                                                                                    ");
		sql.append(" LPAD(A.GROUP_HANGMOG,10,'0'),                                                                                                              ");
		sql.append(" case A.GROUP_HANGMOG                                                                                                                       ");
		sql.append(" when A.HANGMOG_CODE then 1                                                                                                                 ");
		sql.append(" else 2 end,                                                                                                                                ");
		sql.append(" LPAD(A.HANGMOG_CODE,10,'0'),                                                                                                               ");
		sql.append(" A.TUBE_CODE,                                                                                                                               ");
		sql.append(" A.ORDER_TIME,                                                                                                                              ");
		sql.append(" A.JUNDAL_GUBUN,                                                                                                                            ");
		sql.append(" A.SPECIMEN_CODE,                                                                                                                           ");
		sql.append(" IFNULL(C.SERIAL,'9999999999')																												");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_group_ser", groupSer);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		if(!StringUtils.isEmpty(orderTime)){
			query.setParameter("f_order_time", orderTime);
		}
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_reser_yn", serverYn);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_emergency_yn", emergencyYn);
		
		List<CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo> listSpecimen=new JpaResultMapper().list(query, CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo.class);
		return listSpecimen;
	}

	@Override
	public List<CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo> getCPL2010U00GrdSpecimenListItemInfo2(String hospCode,String language, Date orderDate, Double groupSer, String bunho,
			String gwa, String orderTime, String doctor, Date jubsuDate,String jubsuTime, String jubsuja, String reserYn, Date reserDate,String emergencyYn) {
		if(StringUtils.isEmpty(orderTime)){
			orderTime = null;
		}
		StringBuilder sql= new StringBuilder();
		sql.append("	 SELECT A.PKCPL2010                                                                                                                   ");   
		sql.append("	  , IF(A.SUNAB_DATE IS NULL , 'N','Y')SUNAB_YN                                                                                         ");                                                                                                                     
		sql.append("	  , IF(A.JUBSU_DATE IS NULL , 'N','Y')      JUBSU_FLAG                                                                                 ");                             
		sql.append("	  , F.SLIP_NAME                                                                                                                        ");
		sql.append("	  , A.HANGMOG_CODE                                                                                                                     ");
		sql.append("	  , C.GUMSA_NAME                                                                                                                       ");
		sql.append("	  , A.SPECIMEN_CODE                                                                                                                    ");
		sql.append("	  , B.CODE_NAME                       SPECIMEN_NAME                                                                                    ");
		sql.append("	  , A.EMERGENCY                                                                                                                        ");
		sql.append("	  , A.TUBE_CODE                                                                                                                        ");
		sql.append("	  , IFNULL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME                                                                                     ");
		sql.append("	  , A.SPECIMEN_SER                                                                                                                     ");
		sql.append("	  , FN_CPL_SUB_COMMENT(:f_hosp_code,A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)                 COMMENT_JU_CODE                      ");
		sql.append("	  , A.FKOCS1003                                                                                                                        ");
		sql.append("	  , IFNULL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN                                                                                   ");
		sql.append("	  , IF(A.PART_JUBSU_DATE IS NULL , 'N','Y')       PART_JUBSU_FLAG                                                                      ");                                                                                                                                  
		sql.append("	  , IF(A.GUM_JUBSU_DATE   IS NULL , 'N','Y')           GUM_JUBSU_FLAG                                                                  ");                                                                                                                               
		sql.append("	  , A.DUMMY                                                                                                                            ");
		sql.append("	  ,IF( C.GROUP_GUBUN  = '03','Y','N')          MODIFY_YN                                                                               ");                                                                                                                                  
		sql.append("	  ,CASE A.HANGMOG_CODE                                                                                                                 ");
		sql.append("	 WHEN  A.GROUP_HANGMOG THEN                                                                                                            ");
		sql.append("	 	CASE C.GROUP_GUBUN                                                                                                                 ");
		sql.append("	 	WHEN '02' THEN 'N'                                                                                                                 ");
		sql.append("	 	ELSE 'Y' END                                                                                                                       ");
		sql.append("	 ELSE 'N' END  MODIFY_YN_1                                                                                                             ");
		sql.append("	  , A.JUNDAL_GUBUN                                                                                                                     ");
		sql.append("	  , FN_CPL_LOAD_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)    JUNDAL_GUBUN_NAME                                           ");
		sql.append("	  , A.JUBSUJA                                                                                                                          ");
		sql.append("	  , A.ORDER_DATE                                                                                                                       ");
		sql.append("	  , A.BUNHO                                                                                                                            ");
		sql.append("	  , A.JUBSU_DATE                                                                                                                       ");
		sql.append("	  , A.JUBSU_TIME                                                                                                                       ");
		sql.append("	  , A.ORDER_TIME                                                                                                                       ");
		sql.append("	  , A.GROUP_HANGMOG                                                                                                                    ");
		sql.append("	  , C.SPCIAL_NAME                                                                                                                      ");
		sql.append("	  , FN_CPL_SPECIMEN_PRN_YN(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) CAN_YN                                                 ");
		sql.append("	  , C.BARCODE BARCODE                                                                                                                  ");
		sql.append("	  , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE,:f_hosp_code,:f_language) BARCODE_NAME                                                       ");
		sql.append("	  , FN_XRT_LOAD_COMMENT(:f_hosp_code,A.FKOCS1003, A.FKOCS2003) DOC_COMMENT                                                             ");
		sql.append("	  , C.UITAK_CODE                                                                                                                       ");
		sql.append("	  , IFNULL(C.MIDDLE_RESULT, 'N')                              MIDDLE_RESULT                                                            ");
		sql.append(" FROM CPL0101 C LEFT OUTER JOIN CPL0001 F ON F.HOSP_CODE  = C.HOSP_CODE AND F.SLIP_CODE  = C.SLIP_CODE,                                    ");
		sql.append(" CPL2010 A LEFT OUTER JOIN CPL0109 B ON B.HOSP_CODE  = A.HOSP_CODE AND B.CODE = A.SPECIMEN_CODE AND B.CODE_TYPE = '04' AND B.LANGUAGE = :f_language                   ");
		sql.append(" LEFT OUTER JOIN CPL0109 D ON D.HOSP_CODE  = A.HOSP_CODE AND D.CODE   = A.TUBE_CODE AND D.CODE_TYPE = '02' AND D.LANGUAGE = :f_language,                    ");
		sql.append(" OCS1003 O                                                                                                                                 ");
		sql.append("	 WHERE A.HOSP_CODE                = :f_hosp_code                                                                                       ");
		sql.append("	  AND C.HOSP_CODE                = A.HOSP_CODE                                                                                         ");
		sql.append("	  AND A.ORDER_DATE               = :f_order_date                                                                                       ");
		sql.append("	  AND A.GROUP_SER                = :f_group_ser                                                                                        ");
		sql.append("	  AND A.BUNHO                    = :f_bunho                                                                                            ");
		sql.append("	  AND A.GWA                      = :f_gwa                                                                                              ");
		sql.append("	  AND IFNULL(A.ORDER_TIME,'0000')   = IFNULL(:f_order_time,'0000')                                                                     ");
		sql.append("	  AND A.DOCTOR                   = :f_doctor                                                                                           ");
		sql.append("	  AND A.IN_OUT_GUBUN             = 'O'                                                                                                 ");
		sql.append("	  AND A.JUBSU_DATE               = :f_jubsu_date                                                                                       ");
		sql.append("	  AND A.JUBSU_TIME               = :f_jubsu_time                                                                                       ");
		sql.append("	  AND A.JUBSUJA                  = :f_jubsuja                                                                                          ");
		sql.append("	  AND (  ( :f_reser_yn = 'Y' AND A.RESER_DATE = :f_reser_date )                                                                        ");
		sql.append("	      OR ( :f_reser_yn = 'N' AND A.RESER_DATE IS NULL ) )                                                                              ");
		sql.append("	  AND IFNULL(A.DC_YN,'N')           = 'N'                                                                                              ");
		sql.append("	  AND ( (A.AFTER_ACT_YN IS NULL) OR                                                                                                    ");
		sql.append("	      (A.AFTER_ACT_YN =  'N' ) )                                                                                                       ");
		sql.append("	  AND C.HANGMOG_CODE             = A.HANGMOG_CODE                                                                                      ");
		sql.append("	  AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE                                                                                     ");
		sql.append("	  AND C.EMERGENCY                = A.EMERGENCY                                                                                         ");
		sql.append("	  AND O.HOSP_CODE                = A.HOSP_CODE                                                                                         ");
		sql.append("	  AND O.PKOCS1003                = A.FKOCS1003                                                                                         ");
		sql.append("	  AND (:f_emergency_yn = 'N' AND IFNULL(O.EMERGENCY, 'N') = 'N'                                                                        ");
		sql.append("	    OR :f_emergency_yn = 'Y' AND IFNULL(O.EMERGENCY, 'N') = 'Y')                                                                       ");
		sql.append("	 ORDER BY C.UITAK_CODE,                                                                                                                ");
		sql.append("	 LPAD(A.GROUP_HANGMOG,10,'0'),                                                                                                         ");
		sql.append("	 case A.GROUP_HANGMOG                                                                                                                  ");
		sql.append("	 when A.HANGMOG_CODE then 1                                                                                                            ");
		sql.append("	 else 2 end,                                                                                                                           ");
		sql.append("	 LPAD(A.HANGMOG_CODE,10,'0'),                                                                                                          ");
		sql.append("	 A.TUBE_CODE,                                                                                                                          ");
		sql.append("	 A.ORDER_TIME,                                                                                                                         ");
		sql.append("	 A.JUNDAL_GUBUN,                                                                                                                       ");
		sql.append("	 A.SPECIMEN_CODE,                                                                                                                      ");
		sql.append("	 IFNULL(C.SERIAL,'9999999999')																											");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_group_ser", groupSer);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_order_time", orderTime);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_jubsu_time", jubsuTime);
		query.setParameter("f_jubsuja", jubsuja);
		query.setParameter("f_reser_yn", reserYn);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_emergency_yn", emergencyYn);
		List<CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo> listSpecimen2=new JpaResultMapper().list(query, CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo.class);
		return listSpecimen2;
	}
	@Override
	public List<CPL7001Q01LayDailyReportInfo> getCPL7001Q01LayDailyReportInfo(String hospCode, String language, String kensadate,
			String ioGubun, String uitakCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT                                                                                                                                    ");
		sql.append("      :f_kensa_date GUMSA_DATE                                                                                                            ");
		sql.append("     , A.BUNHO BUNHO                                                                                                                      ");
		sql.append("     , A.SUNAME SUNAME                                                                                                                    ");
		sql.append("     , IF(A.IN_OUT_GUBUN = 'O', FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code, :f_language),                                      ");
		sql.append("          CONCAT(IFNULL(FN_BAS_LOAD_GWA_NAME(A.HO_DONG, A.ORDER_DATE,:f_hosp_code, :f_language),''), '-' , IFNULL(A.HO_CODE,''))) GWA     ");
		sql.append("     , A.DOCTOR_NAME DOCTOR_NAME                                                                                                          ");
		sql.append("     , A.HANGMOG_CODE HANGMOG_CODE                                                                                                        ");
		sql.append("     , C.HANGMOG_NAME HANGMOG_NAME                                                                                                        ");
		sql.append("     , A.SPECIMEN_SER                                                                                                                     ");
		sql.append("     , (SELECT X.CODE_NAME                                                                                                                ");
		sql.append("          FROM CPL0109 X                                                                                                                  ");
		sql.append("         WHERE X.HOSP_CODE = A.HOSP_CODE                                                                                                  ");
		sql.append("           AND X.CODE_TYPE = '04' AND X.LANGUAGE = :f_language                                                                                                        ");
		sql.append("           AND X.CODE      = A.SPECIMEN_CODE)  SPECIMEN_NAME                                                                              ");
		sql.append("  FROM OCS0103 C                                                                                                                          ");
		sql.append("     , CPL0101 B                                                                                                                          ");
		sql.append("     , CPL2010 A                                                                                                                          ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                                                         ");
		sql.append("   AND IFNULL(A.RESER_DATE, A.ORDER_DATE) = STR_TO_DATE(:f_kensa_date,'%Y/%m/%d')                                                         ");
		sql.append("   AND A.IN_OUT_GUBUN  LIKE :f_io_gubun                                                                                                   ");
		sql.append("   AND A.UITAK_CODE    LIKE :f_uitak_code                                                                                                 ");
		sql.append("   AND A.PART_JUBSU_DATE IS NOT NULL                                                                                                      ");
		sql.append("   AND A.DC_YN         = 'N'                                                                                                              ");
		sql.append("   AND B.HOSP_CODE     = A.HOSP_CODE                                                                                                      ");
		sql.append("   AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                   ");
		sql.append("   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                  ");
		sql.append("   AND B.EMERGENCY     = A.EMERGENCY                                                                                                      ");
		sql.append("   AND C.HOSP_CODE     = A.HOSP_CODE                                                                                                      ");
		sql.append("   AND C.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                   ");
		sql.append("   AND A.ORDER_DATE    BETWEEN C.START_DATE AND C.END_DATE                                                                                ");
		sql.append(" ORDER BY A.BUNHO                                                                                                                         ");
		sql.append("        , GWA                                                                                                                             ");
		sql.append("        , DOCTOR_NAME                                                                                                                     ");
		sql.append("        , SPECIMEN_NAME                                                                                                                   ");
		sql.append("        , HANGMOG_CODE                                                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_kensa_date", kensadate);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_uitak_code", uitakCode);
		
		List<CPL7001Q01LayDailyReportInfo> list = new JpaResultMapper().list(query, CPL7001Q01LayDailyReportInfo.class);
		
		return list;
	}
	
	@Override
	public List<CPL7001Q02LayMonthlyReportInfo> getCPL7001Q02LayMonthlyReportInfo(String hospCode, String language, String fromDate,
			String toDate, String ioGubun, String uitakCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT   DATE_FORMAT(STR_TO_DATE(X.YYYYMM, '%Y%m'), '%Y/%m')              YYYYMM                                       ");
		sql.append("       , X.HANGMOG_CODE                        HANGMOG_CODE                                                            ");
		sql.append("        , MAX(X.GUMSA_NAME)                                         GUMSA_NAME                                         ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '01' THEN X.CNT END), 0) D01                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '02' THEN X.CNT END), 0) D02                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '03' THEN X.CNT END), 0) D03                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '04' THEN X.CNT END), 0) D04                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '05' THEN X.CNT END), 0) D05                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '06' THEN X.CNT END), 0) D06                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '07' THEN X.CNT END), 0) D07                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '08' THEN X.CNT END), 0) D08                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '09' THEN X.CNT END), 0) D09                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '10' THEN X.CNT END), 0) D10                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '11' THEN X.CNT END), 0) D11                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '12' THEN X.CNT END), 0) D12                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '13' THEN X.CNT END), 0) D13                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '14' THEN X.CNT END), 0) D14                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '15' THEN X.CNT END), 0) D15                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '16' THEN X.CNT END), 0) D16                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '17' THEN X.CNT END), 0) D17                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '18' THEN X.CNT END), 0) D18                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '19' THEN X.CNT END), 0) D19                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '20' THEN X.CNT END), 0) D20                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '21' THEN X.CNT END), 0) D21                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '22' THEN X.CNT END), 0) D22                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '23' THEN X.CNT END), 0) D23                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '24' THEN X.CNT END), 0) D24                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '25' THEN X.CNT END), 0) D25                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '26' THEN X.CNT END), 0) D26                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '27' THEN X.CNT END), 0) D27                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '28' THEN X.CNT END), 0) D28                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '29' THEN X.CNT END), 0) D29                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '30' THEN X.CNT END), 0) D30                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN '31' THEN X.CNT END), 0) D31                                                        ");
		sql.append("       , IFNULL(SUM(CASE X.DD WHEN NULL THEN X.CNT END), SUM(X.CNT)) TOTAL                                             ");
		sql.append("    FROM                                                                                                               ");
		sql.append("(SELECT SUBSTR(DATE_FORMAT(IFNULL(A.RESER_DATE, A.ORDER_DATE), '%Y%m%d'), 1, 6)     YYYYMM                             ");
		sql.append("              ,SUBSTR(DATE_FORMAT(IFNULL(A.RESER_DATE, A.ORDER_DATE), '%Y%m%d'), 7) DD                                 ");
		sql.append("              , IFNULL(A.HANGMOG_CODE,FN_ADM_MSG(221,:f_language)) HANGMOG_CODE                                        ");
		sql.append("         , case IFNULL(A.HANGMOG_CODE,1) when 1 then ' ' else MAX(B.GUMSA_NAME) end  GUMSA_NAME                        ");
		sql.append("              , COUNT(A.HANGMOG_CODE)                                               CNT                                ");
		sql.append("           FROM CPL0101 B                                                                                              ");
		sql.append("              , CPL2010 A                                                                                              ");
		sql.append("          WHERE A.HOSP_CODE = :f_hosp_code                                                                             ");
		sql.append("            AND IFNULL(A.RESER_DATE, A.ORDER_DATE) BETWEEN :f_from_date AND :f_to_date                                 ");
		sql.append("            AND B.HOSP_CODE     = A.HOSP_CODE                                                                          ");
		sql.append("            AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                       ");
		sql.append("            AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                      ");
		sql.append("            AND B.EMERGENCY     = A.EMERGENCY                                                                          ");
		sql.append("            AND A.IN_OUT_GUBUN  LIKE :f_io_gubun                                                                       ");
		sql.append("            AND A.UITAK_CODE    LIKE :f_uitak_code                                                                     ");
		sql.append("            AND A.PART_JUBSU_DATE IS NOT NULL                                                                          ");
		sql.append("          GROUP BY    SUBSTR(DATE_FORMAT(IFNULL(A.RESER_DATE, A.ORDER_DATE), '%Y%m%d'), 1, 6)                          ");
		sql.append("                    , SUBSTR(DATE_FORMAT(IFNULL(A.RESER_DATE, A.ORDER_DATE), '%Y%m%d'), 7)                             ");
		sql.append("                    , A.HANGMOG_CODE WITH ROLLUP) X                                                                    ");
		sql.append("    WHERE X.YYYYMM IS NOT NULL                                                                                         ");
		sql.append("    AND X.DD IS NOT NULL                                                                                               ");
		sql.append("  GROUP BY X.YYYYMM, X.HANGMOG_CODE                                                                                    ");
		sql.append("  ORDER BY X.YYYYMM, X.HANGMOG_CODE                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date",DateUtil.toDate(fromDate, DateUtil.PATTERN_YYMMDD_BLANK));
		query.setParameter("f_to_date",DateUtil.toDate(toDate, DateUtil.PATTERN_YYMMDD_BLANK));
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_uitak_code", uitakCode);
		
		List<CPL7001Q02LayMonthlyReportInfo> list = new JpaResultMapper().list(query, CPL7001Q02LayMonthlyReportInfo.class);
		
		return list;
	}
	
	@Override
	public List<String> getCPL2010R01InitializeReserDateList(String hospCode, String hoDong, String fromDate, String toDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DATE_FORMAT(IFNULL(RESER_DATE, IFNULL(HOPE_DATE,ORDER_DATE)),'%Y/%m/%d') RESER_DATE                                                     ");
		sql.append("  FROM CPL2010                                                                                                                                 ");
		sql.append(" WHERE HOSP_CODE    = :f_hosp_code                                                                                                             ");
		sql.append("   AND IN_OUT_GUBUN = 'I'                                                                                                                      ");
		sql.append("   AND HO_DONG LIKE :f_ho_dong                                                                                                                 ");
		sql.append("   AND IFNULL(RESER_DATE, IFNULL(HOPE_DATE,ORDER_DATE))   BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')  ");
		sql.append("   AND JUBSU_DATE   IS NOT NULL                                                                                                                ");
		sql.append(" GROUP BY IFNULL(RESER_DATE, IFNULL(HOPE_DATE,ORDER_DATE)) ,  RESER_DATE , HOPE_DATE, ORDER_DATE                                               ");
		sql.append(" UNION                                                                                                                                         ");
		sql.append("SELECT DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                                                                                    ");
		sql.append("  FROM OCS6013 B                                                                                                                               ");
		sql.append("      ,CPL2010 A                                                                                                                               ");
		sql.append(" WHERE A.HOSP_CODE      = :f_hosp_code                                                                                                         ");
		sql.append("   AND B.HOSP_CODE      = A.HOSP_CODE                                                                                                          ");
		sql.append("   AND A.IN_OUT_GUBUN   = 'I'                                                                                                                  ");
		sql.append("   AND A.ORDER_DATE      BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')                                   ");
		sql.append("   AND HO_DONG LIKE :f_ho_dong                                                                                                                 ");
		sql.append("   AND IFNULL(A.DC_YN,'N') = 'N'                                                                                                               ");
		sql.append("   AND A.RESER_DATE     IS NULL                                                                                                                ");
		sql.append("   AND A.JUBSU_DATE     IS NOT NULL                                                                                                            ");
		sql.append("   AND B.FKOCS2003      = A.FKOCS2003                                                                                                          ");
		sql.append(" GROUP BY A.ORDER_DATE                                                                                                                         ");
		sql.append(" ORDER BY 1                                                                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_ho_dong", hoDong);
		
		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<CPL2010R01LaySpecimenListItemInfo> getCPL2010R01LaySpecimenListItemInfo(String hospCode, String language, String hoDong, String reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SPECIMEN_SER                                         SPECIMEN_SER                                                                                   ");
		sql.append("      , A.BUNHO                                                BUNHO                                                                                          ");
		sql.append("      , B.SUNAME                                               SUNAME                                                                                         ");
		sql.append("      , MIN(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,A.ORDER_DATE,:f_hosp_code))    DOCTOR_NAME                                                                       ");
		sql.append("      , CONCAT(SUBSTR(SPECIMEN_SER,5,2),'-',SUBSTR(SPECIMEN_SER,7))  SPECIMEN_NO                                                                              ");
		sql.append("      , FN_CPL_LOAD_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language)            SPECIMEN_NAME                                                         ");
		sql.append("      , FN_CPL_LOAD_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language)                TUBE_NAME                                                             ");
		sql.append("      , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)                      TUBE_COUNT                                                                        ");
		sql.append("      , IF(:f_ho_dong = '%', FN_ADM_MSG(221,:f_language), FN_BAS_LOAD_GWA_NAME(:f_ho_dong,SYSDATE(),:f_hosp_code,:f_language)) HO_DONG_NAME                   ");
		sql.append("      , MIN(FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(A.RESER_DATE, A.ORDER_DATE),:f_hosp_code,:f_language))    RESER_DATE                                      ");
		sql.append("      , CONCAT(IFNULL(A.BUNHO,''),IFNULL(A.SPECIMEN_SER,''),IFNULL(A.TUBE_CODE,''))               CONT_KEY                                                    ");
		sql.append("   FROM VW_INP_INP1001 D                                                                                                                                      ");
		sql.append("      , OUT0101 B                                                                                                                                             ");
		sql.append("      , CPL2010 A                                                                                                                                             ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                         ");
		sql.append("    AND A.IN_OUT_GUBUN = 'I'                                                                                                                                  ");
		sql.append("    AND IFNULL(A.RESER_DATE, A.ORDER_DATE)   = STR_TO_DATE(:f_reser_date,'%Y/%m/%d')                                                                          ");
		sql.append("    AND IFNULL(A.DC_YN,'N') = 'N'                                                                                                                             ");
		sql.append("    AND A.JUBSU_DATE IS NOT NULL                                                                                                                              ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
		sql.append("    AND B.BUNHO        = A.BUNHO                                                                                                                              ");
		sql.append("    AND D.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
		sql.append("    AND D.BUNHO        = A.BUNHO                                                                                                                              ");
		sql.append("    AND D.HO_DONG1     LIKE :f_ho_dong                                                                                                                        ");
		sql.append("  GROUP BY A.BUNHO                                                                                                                                            ");
		sql.append("         , A.SPECIMEN_SER                                                                                                                                     ");
		sql.append("         , B.SUNAME                                                                                                                                           ");
		sql.append("         , A.SPECIMEN_CODE                                                                                                                                    ");
		sql.append("         , A.TUBE_CODE                                                                                                                                        ");
		sql.append(" UNION                                                                                                                                                        ");
		sql.append(" SELECT A.SPECIMEN_SER                                         SPECIMEN_SER                                                                                   ");
		sql.append("      , A.BUNHO                                                BUNHO                                                                                          ");
		sql.append("      , B.SUNAME                                               SUNAME                                                                                         ");
		sql.append("      , MIN(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,A.ORDER_DATE,:f_hosp_code))    DOCTOR_NAME                                                                       ");
		sql.append("      , CONCAT(SUBSTR(SPECIMEN_SER,5,2),'-',SUBSTR(SPECIMEN_SER,7))  SPECIMEN_NO                                                                              ");
		sql.append("      , FN_CPL_LOAD_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language)            SPECIMEN_NAME                                                         ");
		sql.append("      , FN_CPL_LOAD_CODE_NAME('02',IFNULL(C.OUT_TUBE2,A.TUBE_CODE),:f_hosp_code,:f_language)    TUBE_NAME                                                     ");
		sql.append("      , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)                      TUBE_COUNT                                                                        ");
		sql.append("      , IF(:f_ho_dong = '%', FN_ADM_MSG(221,:f_language), FN_BAS_LOAD_GWA_NAME(:f_ho_dong,SYSDATE(),:f_hosp_code,:f_language)) HO_DONG_NAME                   ");
		sql.append("      , MIN(FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(A.RESER_DATE, A.ORDER_DATE),:f_hosp_code,:f_language))    RESER_DATE                                      ");
		sql.append("      , CONCAT(IFNULL(A.BUNHO,''),IFNULL(A.SPECIMEN_SER,''),IFNULL(C.OUT_TUBE2,A.TUBE_CODE))  CONT_KEY                                                        ");
		sql.append("   FROM VW_INP_INP1001 D                                                                                                                                      ");
		sql.append("      , CPL0101 C                                                                                                                                             ");
		sql.append("      , OUT0101 B                                                                                                                                             ");
		sql.append("      , CPL2010 A                                                                                                                                             ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                         ");
		sql.append("    AND A.IN_OUT_GUBUN  = 'I'                                                                                                                                 ");
		sql.append("    AND IFNULL(A.RESER_DATE, A.ORDER_DATE)    =  STR_TO_DATE(:f_reser_date,'%Y/%m/%d')                                                                        ");
		sql.append("    AND IFNULL(A.DC_YN,'N') = 'N'                                                                                                                             ");
		sql.append("    AND A.JUBSU_DATE IS NOT NULL                                                                                                                              ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                                                                                                         ");
		sql.append("    AND B.BUNHO         = A.BUNHO                                                                                                                             ");
		sql.append("    AND C.HOSP_CODE     = A.HOSP_CODE                                                                                                                         ");
		sql.append("    AND C.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                      ");
		sql.append("    AND C.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                     ");
		sql.append("    AND C.EMERGENCY     = A.EMERGENCY                                                                                                                         ");
		sql.append("    AND D.HOSP_CODE     = A.HOSP_CODE                                                                                                                         ");
		sql.append("    AND D.BUNHO         = A.BUNHO                                                                                                                             ");
		sql.append("    AND D.HO_DONG1      LIKE :f_ho_dong                                                                                                                       ");
		sql.append("  GROUP BY A.BUNHO                                                                                                                                            ");
		sql.append("         , A.SPECIMEN_SER                                                                                                                                     ");
		sql.append("         , B.SUNAME                                                                                                                                           ");
		sql.append("         , A.SPECIMEN_CODE                                                                                                                                    ");
		sql.append("         , IFNULL(C.OUT_TUBE2,A.TUBE_CODE)   , C.OUT_TUBE2,A.TUBE_CODE                                                                                                                    ");
		sql.append(" UNION                                                                                                                                                        ");
		sql.append(" SELECT A.SPECIMEN_SER                                         SPECIMEN_SER                                                                                   ");
		sql.append("      , A.BUNHO                                                BUNHO                                                                                          ");
		sql.append("      , B.SUNAME                                               SUNAME                                                                                         ");
		sql.append("      , MIN(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,A.ORDER_DATE,:f_hosp_code))    DOCTOR_NAME                                                                       ");
		sql.append("      , CONCAT(SUBSTR(SPECIMEN_SER,5,2),'-',SUBSTR(SPECIMEN_SER,7))  SPECIMEN_NO                                                                              ");
		sql.append("      , FN_CPL_LOAD_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language)            SPECIMEN_NAME                                                         ");
		sql.append("      , FN_CPL_LOAD_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language)                TUBE_NAME                                                             ");
		sql.append("      , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)                      TUBE_COUNT                                                                        ");
		sql.append("      , IF(:f_ho_dong = '%', FN_ADM_MSG(221,:f_language), FN_BAS_LOAD_GWA_NAME(:f_ho_dong,SYSDATE(),:f_hosp_code,:f_language)) HO_DONG_NAME                   ");
		sql.append("      , MIN(FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(A.ORDER_DATE, A.ORDER_DATE),:f_hosp_code,:f_language))    RESER_DATE                                      ");
		sql.append("      , CONCAT(IFNULL(A.BUNHO,''),IFNULL(A.SPECIMEN_SER,''),IFNULL(A.TUBE_CODE,''))               CONT_KEY                                                    ");
		sql.append("   FROM OCS6013 D                                                                                                                                             ");
		sql.append("      , OUT0101 B                                                                                                                                             ");
		sql.append("      , CPL2010 A                                                                                                                                             ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                         ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
		sql.append("    AND D.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
		sql.append("    AND A.IN_OUT_GUBUN = 'I'                                                                                                                                  ");
		sql.append("    AND A.HO_DONG      LIKE :f_ho_dong                                                                                                                        ");
		sql.append("    AND A.ORDER_DATE   =  STR_TO_DATE(:f_reser_date,'%Y/%m/%d')                                                                                               ");
		sql.append("    AND IFNULL(A.DC_YN,'N') = 'N'                                                                                                                             ");
		sql.append("    AND A.RESER_DATE IS NULL                                                                                                                                  ");
		sql.append("    AND A.JUBSU_DATE IS NOT NULL                                                                                                                              ");
		sql.append("    AND B.BUNHO        = A.BUNHO                                                                                                                              ");
		sql.append("    AND D.FKOCS2003    = A.FKOCS2003                                                                                                                          ");
		sql.append("  GROUP BY A.BUNHO                                                                                                                                            ");
		sql.append("         , A.SPECIMEN_SER                                                                                                                                     ");
		sql.append("         , B.SUNAME                                                                                                                                           ");
		sql.append("         , A.SPECIMEN_CODE                                                                                                                                    ");
		sql.append("         , A.TUBE_CODE                                                                                                                                        ");
		sql.append(" UNION                                                                                                                                                        ");
		sql.append(" SELECT A.SPECIMEN_SER                                         SPECIMEN_SER                                                                                   ");
		sql.append("      , A.BUNHO                                                BUNHO                                                                                          ");
		sql.append("      , B.SUNAME                                               SUNAME                                                                                         ");
		sql.append("      , MIN(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,A.ORDER_DATE,:f_hosp_code))    DOCTOR_NAME                                                                       ");
		sql.append("      , CONCAT(SUBSTR(SPECIMEN_SER,5,2),'-',SUBSTR(SPECIMEN_SER,7))  SPECIMEN_NO                                                                              ");
		sql.append("      , FN_CPL_LOAD_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language)            SPECIMEN_NAME                                                         ");
		sql.append("      , FN_CPL_LOAD_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language)                TUBE_NAME                                                             ");
		sql.append("      , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)                      TUBE_COUNT                                                                        ");
		sql.append("      , IF(:f_ho_dong = '%', FN_ADM_MSG(221,:f_language), FN_BAS_LOAD_GWA_NAME(:f_ho_dong,SYSDATE(),:f_hosp_code,:f_language)) HO_DONG_NAME                   ");
		sql.append("      , MIN(FN_BAS_TO_JAPAN_DATE_CONVERT('1',IFNULL(A.ORDER_DATE, A.ORDER_DATE),:f_hosp_code,:f_language))    RESER_DATE                                      ");
		sql.append("      , CONCAT(IFNULL(A.BUNHO,''),IFNULL(A.SPECIMEN_SER,''),IFNULL(C.OUT_TUBE2,A.TUBE_CODE))  CONT_KEY                                                        ");
		sql.append("   FROM OCS6013 D                                                                                                                                             ");
		sql.append("      , CPL0101 C                                                                                                                                             ");
		sql.append("      , OUT0101 B                                                                                                                                             ");
		sql.append("      , CPL2010 A                                                                                                                                             ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                         ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
		sql.append("    AND C.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
		sql.append("    AND D.HOSP_CODE     = A.HOSP_CODE                                                                                                                         ");
		sql.append("    AND A.IN_OUT_GUBUN  = 'I'                                                                                                                                 ");
		sql.append("    AND A.HO_DONG       LIKE :f_ho_dong                                                                                                                       ");
		sql.append("    AND A.ORDER_DATE    = STR_TO_DATE(:f_reser_date,'%Y/%m/%d')                                                                                               ");
		sql.append("    AND A.RESER_DATE IS NULL                                                                                                                                  ");
		sql.append("    AND A.JUBSU_DATE IS NOT NULL                                                                                                                              ");
		sql.append("    AND IFNULL(A.DC_YN,'N') = 'N'                                                                                                                             ");
		sql.append("    AND B.BUNHO         = A.BUNHO                                                                                                                             ");
		sql.append("    AND C.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                      ");
		sql.append("    AND C.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                     ");
		sql.append("    AND C.EMERGENCY     = A.EMERGENCY                                                                                                                         ");
		sql.append("    AND D.FKOCS2003     = A.FKOCS2003                                                                                                                         ");
		sql.append("  GROUP BY A.BUNHO                                                                                                                                            ");
		sql.append("         , A.SPECIMEN_SER                                                                                                                                     ");
		sql.append("         , B.SUNAME                                                                                                                                           ");
		sql.append("         , A.SPECIMEN_CODE                                                                                                                                    ");
		sql.append("         , IFNULL(C.OUT_TUBE2,A.TUBE_CODE), C.OUT_TUBE2,A.TUBE_CODE                                                                                            ");
		sql.append("  ORDER BY 2,1,6                                                                                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_ho_dong", hoDong);
		
		List<CPL2010R01LaySpecimenListItemInfo> list = new JpaResultMapper().list(query, CPL2010R01LaySpecimenListItemInfo.class);
		
		return list;
	}
	
	@Override
	public List<CPL2010R00GetBarCodeInfo> getCPL2010R00GetBarCodeInfo(String hospCode, String language, String specimenSer){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                                                                                                          ");
		sql.append("       MIN(A.JUNDAL_GUBUN)                             JUNDAL_GUBUN                                                                                                                                                                      ");
		sql.append("     , MIN(IF(B.JUNDAL_GUBUN_NAME IS NULL,IFNULL(CONCAT(FN_CPL_HANGMOG_MARK_NAME(A.SPECIMEN_SER,:f_hosp_code),' '                                                                                                                        ");
		sql.append("     ,IFNULL(FN_CPL_CODE_NAME_RE('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)))                                                                                          ");
		sql.append("     ,IFNULL(FN_CPL_CODE_NAME_RE('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language))),B.JUNDAL_GUBUN_NAME))   JUNDAL_GUBUN_NAME                                                ");
		sql.append("     , ' '                                             SPECIMEN_CODE                                                                                                                                                                     ");
		sql.append("     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language))) SPECIMEN_NAME                                                                     ");
		sql.append("     , MIN(IFNULL(B.JANGBI_OUT_CODE3,B.OUT_TUBE2))        TUBE_CODE                                                                                                                                                                      ");
		sql.append("     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',B.OUT_TUBE2,:f_hosp_code,:f_language),IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language)))) TUBE_NAME          ");
		sql.append("     , IFNULL(B.UITAK_CODE,MAX(A.EMERGENCY))                        IN_OUT_GUBUN                                                                                                                                                         ");
		sql.append("     , A.SPECIMEN_SER                          SPECIMEN_SER                                                                                                                                                                              ");
		sql.append("     , MIN(A.BUNHO)                                       BUNHO                                                                                                                                                                          ");
		sql.append("     , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))               SUNAME                                                                                                                                                                         ");
		sql.append("     , MIN(IF(A.IN_OUT_GUBUN = 'I',FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(),:f_hosp_code,:f_language),FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language)))        GWA_NAME                                                   ");
		sql.append("     , ' '                                             DANGER_YN                                                                                                                                                                         ");
		sql.append("     , CONCAT('a',A.SPECIMEN_SER,'a')                        SPECIMEN_SER_BA                                                                                                                                                             ");
		sql.append("     , MIN(A.JANGBI_CODE)                              JANGBI_CODE                                                                                                                                                                       ");
		sql.append("     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE,:f_hosp_code,:f_language))) JANGBI_NAME                                                                           ");
		sql.append("     , MIN(CONCAT(SUBSTR(A.SPECIMEN_SER,5,2),'-',SUBSTR(A.SPECIMEN_SER,7))) GUMSA_NAME_RE                                                                                                                                                ");
		sql.append("     , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)               TUBE_COUNT                                                                                                                                                           ");
		sql.append("     , MIN(CONCAT(D.CODE_NAME_RE2,IF(D.CODE_NAME_RE2 IS NULL,'','mL')))   TUBE_MAX_AMT                                                                                                                                                   ");
		sql.append("     , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))   TUBE_NUMBERING                                                                                                                        ");
		sql.append("  FROM  OUT0101 C                                                                                                                                                                                                                        ");
		sql.append("     , CPL2010 A                                                                                                                                                                                                                         ");
		sql.append("     , CPL0101 B LEFT OUTER JOIN CPL0109 D ON D.CODE_TYPE  = '02'                                                                                                                                                                        ");
		sql.append("                                          AND D.CODE    = B.TUBE_CODE                                                                                                                                                                    ");
		sql.append("                                          AND D.HOSP_CODE  = B.HOSP_CODE  AND D.LANGUAGE = :f_language                                                                                                                                                          ");
		sql.append(" WHERE B.HOSP_CODE     = 'K01'                                                                                                                                                                                                           ");
		sql.append("   AND A.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                                                                     ");
		sql.append("   AND C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                                                                     ");
		sql.append("    AND A.SPECIMEN_SER  = :f_specimen_ser                                                                                                                                                                                                ");
		sql.append("   AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                                                                                                  ");
		sql.append("   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                                                                                                 ");
		sql.append("   AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                                                                                     ");
		sql.append("   AND C.BUNHO         = A.BUNHO                                                                                                                                                                                                         ");
		sql.append("   AND B.OUT_TUBE2 IS NOT NULL                                                                                                                                                                                                           ");
		sql.append(" GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.OUT_TUBE2, A.JUNDAL_GUBUN                                                                                                                                                                      ");
		sql.append("UNION                                                                                                                                                                                                                                    ");
		sql.append("SELECT DISTINCT                                                                                                                                                                                                                          ");
		sql.append("       MIN(A.JUNDAL_GUBUN)                             JUNDAL_GUBUN                                                                                                                                                                      ");
		sql.append("     , MIN(IF(B.JUNDAL_GUBUN_NAME IS NULL,IFNULL(CONCAT(FN_CPL_HANGMOG_MARK_NAME(A.SPECIMEN_SER,:f_hosp_code),' '                                                                                                                        ");
		sql.append("     ,IFNULL(FN_CPL_CODE_NAME_RE('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)))                                                                                          ");
		sql.append("     ,IFNULL(FN_CPL_CODE_NAME_RE('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language))),B.JUNDAL_GUBUN_NAME))   JUNDAL_GUBUN_NAME                                                ");
		sql.append("     , ' '                                             SPECIMEN_CODE                                                                                                                                                                     ");
		sql.append("     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language))) SPECIMEN_NAME                                                                     ");
		sql.append("     , MIN(B.TUBE_CODE)                                TUBE_CODE                                                                                                                                                                         ");
		sql.append("     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language))) TUBE_NAME                                                                                 ");
		sql.append("     , IFNULL(B.UITAK_CODE,MAX(A.EMERGENCY))                        IN_OUT_GUBUN                                                                                                                                                         ");
		sql.append("     , A.SPECIMEN_SER                          SPECIMEN_SER                                                                                                                                                                              ");
		sql.append("     , MIN(A.BUNHO)                                       BUNHO                                                                                                                                                                          ");
		sql.append("     , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))               SUNAME                                                                                                                                                                         ");
		sql.append("     , MIN(IF(A.IN_OUT_GUBUN = 'I',FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(),:f_hosp_code,:f_language),FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language)))        GWA_NAME                                                   ");
		sql.append("     , ' '                                             DANGER_YN                                                                                                                                                                         ");
		sql.append("     , CONCAT('a',A.SPECIMEN_SER,'a')                        SPECIMEN_SER_BA                                                                                                                                                             ");
		sql.append("     , MIN(A.JANGBI_CODE)                              JANGBI_CODE                                                                                                                                                                       ");
		sql.append("     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE,:f_hosp_code,:f_language))) JANGBI_NAME                                                                           ");
		sql.append("     , MIN(CONCAT(SUBSTR(A.SPECIMEN_SER,5,2),'-',SUBSTR(A.SPECIMEN_SER,7))) GUMSA_NAME_RE                                                                                                                                                ");
		sql.append("     , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)               TUBE_COUNT                                                                                                                                                           ");
		sql.append("     , MIN(CONCAT(D.CODE_NAME_RE2,IF(D.CODE_NAME_RE2 IS NULL,'','mL')))   TUBE_MAX_AMT                                                                                                                                                   ");
		sql.append("     , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))   TUBE_NUMBERING                                                                                                                        ");
		sql.append("  FROM OUT0101 C                                                                                                                                                                                                                         ");
		sql.append("     , CPL2010 A                                                                                                                                                                                                                         ");
		sql.append("     , CPL0101 B LEFT OUTER JOIN CPL0109 D ON D.HOSP_CODE  = B.HOSP_CODE AND D.LANGUAGE = :f_language                                                                                                                                                                ");
		sql.append("     AND D.CODE_TYPE  = '02'                                                                                                                                                                                                             ");
		sql.append("   AND D.CODE       = B.TUBE_CODE                                                                                                                                                                                                        ");
		sql.append(" WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                                                                                    ");
		sql.append("   AND A.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                                                                     ");
		sql.append("   AND C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                                                                     ");
		sql.append("   AND A.SPECIMEN_SER  like :f_specimen_ser                                                                                                                                                                                              ");
		sql.append("   AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                                                                                                  ");
		sql.append("   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                                                                                                 ");
		sql.append("   AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                                                                                     ");
		sql.append("   AND C.BUNHO         = A.BUNHO                                                                                                                                                                                                         ");
		sql.append(" GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.JANGBI_OUT_CODE3, A.JUNDAL_GUBUN                                                                                                                                                               ");
		sql.append(" ORDER BY 8                                                                                                                                                                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<CPL2010R00GetBarCodeInfo> list = new JpaResultMapper().list(query, CPL2010R00GetBarCodeInfo.class);
		
		return list;
		
	}
	
	@Override
	public List<CPL3010U00LaySpecimenInfoListItemInfo> getCPL3010U00LaySpecimenInfoListItemInfo(String hospCode, String language, String specimenSer){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                           ");
		sql.append("       A.BUNHO                                          BUNHO,                                                                            ");
		sql.append("       B.SUNAME                                         SUNAME,                                                                           ");
		sql.append("       B.SEX                                            SEX,                                                                              ");
		sql.append("       B.BIRTH                                          BIRTH,                                                                            ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(A.GWA,A.ORDER_DATE,:f_hosp_code,:f_language)         GWA_NAME,                                                ");
		sql.append("       A.DOCTOR_NAME                                    DOCTOR_NAME,                                                                      ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(A.HO_DONG, A.ORDER_DATE,:f_hosp_code,:f_language)    HO_DONG_NAME,                                            ");
		sql.append("       A.HO_CODE                                        HO_CODE,                                                                          ");
		sql.append("       A.ORDER_DATE                                     ORDER_DATE,                                                                       ");
		sql.append("       A.JUBSU_DATE                                     JUBSU_DATE,                                                                       ");
		sql.append("       A.PART_JUBSU_DATE                                PART_JUBSU_DATE,                                                                  ");
		sql.append("       A.JUBSU_TIME                                     JUBSU_TIME,                                                                       ");
		sql.append("       A.PART_JUBSU_TIME                                PART_JUBSU_TIME,                                                                  ");
		sql.append("       A.JUBSUJA                                        JUBSUJA,                                                                          ");
		sql.append("       A.IN_OUT_GUBUN                                   IN_OUT_GUBUN,                                                                     ");
		sql.append("       A.JUNDAL_GUBUN                                   JUNDAL_GUBUN,                                                                     ");
		sql.append("       A.SPECIMEN_CODE                                  SPECIMEN_CODE,                                                                    ");
		sql.append("       C.CODE_NAME                                      SPECIMEN_NAME,                                                                    ");
		sql.append("       FN_CPL_TIME_LOAD(A.JUBSU_DATE, A.JUBSU_TIME, A.PART_JUBSU_DATE, A.PART_JUBSU_TIME)            TAT1,                                ");
		sql.append("       FN_CPL_TIME_LOAD_RESULT(A.PART_JUBSU_DATE, A.PART_JUBSU_TIME, A.RESULT_DATE, A.RESULT_TIME)    TAT2,                               ");
		sql.append("       FN_BAS_LOAD_AGE(SYSDATE(), B.BIRTH, '')        AGE                                                                                 ");
		sql.append("  FROM CPL2010 A LEFT OUTER JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                             ");
		sql.append("                 LEFT OUTER JOIN CPL0109 C ON C.HOSP_CODE = A.HOSP_CODE AND C.CODE = A.SPECIMEN_CODE AND C.CODE_TYPE = '04'               ");
		sql.append(" WHERE A.HOSP_CODE                  = :f_hosp_code                                                                                        ");
		sql.append("   AND A.SPECIMEN_SER               = :f_specimen_ser                                                                                     ");
		sql.append("   AND SUBSTR(A.SPECIMEN_CODE,1,1) != 'N'                                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<CPL3010U00LaySpecimenInfoListItemInfo> list = new JpaResultMapper().list(query, CPL3010U00LaySpecimenInfoListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL3010U00LayBarCodeTemp2ListItemInfo> getCPL3010U00LayBarCodeTemp2ListItemInfo(String hospCode, String language, String specimenSer){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT MIN(CONCAT(SUBSTR(A.SPECIMEN_SER,3,2),'-',SUBSTR(A.SPECIMEN_SER,5,2),'  ',SUBSTR(A.SPECIMEN_SER,7)))     JUNDAL_GUBUN                                                           ");
		sql.append("     , FN_CPL_CODE_NAME('11',B.BARCODE)               JUNDAL_GUBUN_NAME                                                                                                                ");
		sql.append("     , MIN(A.SPECIMEN_CODE)                           SPECIMEN_CODE                                                                                                                    ");
		sql.append("     , MIN(FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE))      SPECIMEN_NAME                                                                                                                  ");
		sql.append("     , MIN(IF(B.OUT_TUBE IS NULL,A.TUBE_CODE,B.OUT_TUBE))    TUBE_CODE                                                                                                                 ");
		sql.append("     , MIN(IF(B.OUT_TUBE IS NULL,IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language)),                   ");
		sql.append("                                  IFNULL(FN_CPL_CODE_NAME_RE('02',B.OUT_TUBE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',B.OUT_TUBE,:f_hosp_code,:f_language))))   TUBE_NAME       ");
		sql.append("     , IFNULL(B.UITAK_CODE,MAX(A.EMERGENCY))                             IN_OUT_GUBUN                                                                                                  ");
		sql.append("     , CONCAT(SUBSTR(A.SPECIMEN_SER,5,2),'-',SUBSTR(A.SPECIMEN_SER,7))         SPECIMEN_SER                                                                                            ");
		sql.append("     , MIN(A.BUNHO)                                      BUNHO                                                                                                                         ");
		sql.append("     , MIN(IFNULL(C.SUNAME2,'NO GANA'))                  SUNAME                                                                                                                        ");
		sql.append("     , MIN(FN_CPL_CODE_NAME_RE('06',B.UITAK_CODE,:f_hosp_code,:f_language))    UITAK_NAME                                                                                              ");
		sql.append("     , ' '                                            DANGER_YN                                                                                                                        ");
		sql.append("     , CONCAT('a',A.SPECIMEN_SER,'a')                       SPECIMEN_SER_BA                                                                                                            ");
		sql.append("     , MAX(FN_CPL_LOAD_TOTAL_AMT(A.SPECIMEN_SER,:f_hosp_code))     TUBE_AMT                                                                                                            ");
		sql.append("     , ' '                                            JANGBI_NAME                                                                                                                      ");
		sql.append("     , MAX(B.JUNDAL_GUBUN_NAME)                       GUMSA_NAME_RE                                                                                                                    ");
		sql.append("     , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))   TUBE_NUMBERING                                                                      ");
		sql.append("  FROM                                                                                                                                                                                 ");
		sql.append("       CPL0101 B,                                                                                                                                                                      ");
		sql.append("       CPL2010 A LEFT OUTER JOIN OUT0101 C ON C.BUNHO = A.BUNHO                                                                                                                        ");
		sql.append(" WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                                  ");
		sql.append("   AND C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                   ");
		sql.append("   AND A.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                   ");
		sql.append("   AND A.SPECIMEN_SER  = :f_specimen_ser                                                                                                                                               ");
		sql.append("   AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                                                ");
		sql.append("   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                                               ");
		sql.append("   AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                                   ");
		sql.append("   AND B.UITAK_CODE    IS NOT NULL                                                                                                                                                     ");
		sql.append("   AND A.JUNDAL_GUBUN  IN ('10','15')                                                                                                                                                  ");
		sql.append(" GROUP BY A.JUNDAL_GUBUN,                                                                                                                                                              ");
		sql.append("       A.SPECIMEN_CODE,                                                                                                                                                                ");
		sql.append("       A.TUBE_CODE,                                                                                                                                                                    ");
		sql.append("       A.IN_OUT_GUBUN,                                                                                                                                                                 ");
		sql.append("       B.UITAK_CODE,                                                                                                                                                                   ");
		sql.append("       A.SPECIMEN_SER,                                                                                                                                                                 ");
		sql.append("       A.GWA,                                                                                                                                                                          ");
		sql.append("       A.BUNHO,                                                                                                                                                                        ");
		sql.append("       B.OUT_TUBE,                                                                                                                                                                     ");
		sql.append("       FN_CPL_CODE_NAME('11',B.BARCODE,:f_hosp_code,:f_language),B.BARCODE                                                                                                             ");
		sql.append("UNION                                                                                                                                                                                  ");
		sql.append("SELECT MIN(CONCAT(SUBSTR(A.SPECIMEN_SER,3,2),'-',SUBSTR(A.SPECIMEN_SER,5,2),'  ',SUBSTR(A.SPECIMEN_SER,7)))     JUNDAL_GUBUN                                                           ");
		sql.append("     , FN_CPL_CODE_NAME('11',B.BARCODE,:f_hosp_code,:f_language)               JUNDAL_GUBUN_NAME                                                                                       ");
		sql.append("     , MIN(A.SPECIMEN_CODE)                           SPECIMEN_CODE                                                                                                                    ");
		sql.append("     , MIN(FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language))      SPECIMEN_NAME                                                                                         ");
		sql.append("     , MIN(IFNULL(B.OUT_TUBE2,IF(B.OUT_TUBE IS NULL,A.TUBE_CODE,B.OUT_TUBE)))    TUBE_CODE                                                                                             ");
		sql.append("     , MIN(IFNULL(IFNULL(FN_CPL_CODE_NAME_RE('02',B.OUT_TUBE2,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',B.OUT_TUBE2,:f_hosp_code,:f_language))                                   ");
		sql.append("            ,IF(B.OUT_TUBE IS NULL,IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language))                  ");
		sql.append("            ,IFNULL(FN_CPL_CODE_NAME_RE('02',B.OUT_TUBE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',B.OUT_TUBE,:f_hosp_code,:f_language)))))   TUBE_NAME                           ");
		sql.append("     , IFNULL(B.UITAK_CODE,MAX(A.EMERGENCY))                               IN_OUT_GUBUN                                                                                                ");
		sql.append("     , CONCAT(SUBSTR(A.SPECIMEN_SER,5,2),'-',SUBSTR(A.SPECIMEN_SER,7))         SPECIMEN_SER                                                                                            ");
		sql.append("     , MIN(A.BUNHO)                                      BUNHO                                                                                                                         ");
		sql.append("     , MIN(IFNULL(C.SUNAME2,'NO GANA'))                  SUNAME                                                                                                                        ");
		sql.append("     , MIN(FN_CPL_CODE_NAME_RE('06',B.UITAK_CODE,:f_hosp_code,:f_language))    UITAK_NAME                                                                                              ");
		sql.append("     , ' '                                            DANGER_YN                                                                                                                        ");
		sql.append("     , CONCAT('a',A.SPECIMEN_SER,'a')                       SPECIMEN_SER_BA                                                                                                            ");
		sql.append("     , MAX(FN_CPL_LOAD_TOTAL_AMT(A.SPECIMEN_SER,:f_hosp_code))     TUBE_AMT                                                                                                            ");
		sql.append("     , ' '                                            JANGBI_NAME                                                                                                                      ");
		sql.append("     , MAX(B.JUNDAL_GUBUN_NAME)                       GUMSA_NAME_RE                                                                                                                    ");
		sql.append("     , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))   TUBE_NUMBERING                                                                      ");
		sql.append("  FROM                                                                                                                                                                                 ");
		sql.append("       CPL0101 B,                                                                                                                                                                      ");
		sql.append("       CPL2010 A LEFT OUTER JOIN OUT0101 C ON C.BUNHO = A.BUNHO                                                                                                                        ");
		sql.append(" WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                                  ");
		sql.append("   AND A.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                   ");
		sql.append("   AND C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                   ");
		sql.append("   AND A.SPECIMEN_SER  = specimen_ser                                                                                                                                                  ");
		sql.append("   AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                                                ");
		sql.append("   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                                               ");
		sql.append("   AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                                   ");
		sql.append("   AND B.UITAK_CODE    IS NOT NULL                                                                                                                                                     ");
		sql.append("   AND A.JUNDAL_GUBUN  IN ('10','15')                                                                                                                                                  ");
		sql.append(" GROUP BY A.JUNDAL_GUBUN,                                                                                                                                                              ");
		sql.append("       A.SPECIMEN_CODE,                                                                                                                                                                ");
		sql.append("       A.TUBE_CODE,                                                                                                                                                                    ");
		sql.append("       A.IN_OUT_GUBUN,                                                                                                                                                                 ");
		sql.append("       B.UITAK_CODE,                                                                                                                                                                   ");
		sql.append("       A.SPECIMEN_SER,                                                                                                                                                                 ");
		sql.append("       A.GWA,                                                                                                                                                                          ");
		sql.append("       A.BUNHO,                                                                                                                                                                        ");
		sql.append("       B.OUT_TUBE,                                                                                                                                                                     ");
		sql.append("       FN_CPL_CODE_NAME('11',B.BARCODE,:f_hosp_code) ,B.BARCODE                                                                                                                         ");
		sql.append(" ORDER BY 8                                                                                                                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<CPL3010U00LayBarCodeTemp2ListItemInfo> list = new JpaResultMapper().list(query, CPL3010U00LayBarCodeTemp2ListItemInfo.class);
		return list;
	}

	@Override
	public List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> getCplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo2(String hospCode,String language, String specimenSer) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT MIN(A.JUNDAL_GUBUN)                             JUNDAL_GUBUN                                                                                                                                        ");
		sql.append("      , CAST(' ' AS CHAR) JUNDAL_GUBUN_NAME                                                                                                                                                                   ");
		sql.append("      , CAST(' ' AS CHAR)                                             SPECIMEN_CODE                                                                                                                          ");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language))) SPECIMEN_NAME                                       ");
		sql.append("      , MIN(IFNULL(B.JANGBI_OUT_CODE3,B.OUT_TUBE2))        TUBE_CODE                                                                                                   										");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',B.OUT_TUBE2,:f_hosp_code,:f_language),IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE,:f_hosp_code,:f_language),													");
		sql.append("  FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language)))) TUBE_NAME                  																												     ");
		sql.append("      ,case  B.UITAK_CODE                                                                                                                                                                                    ");
		sql.append(" 	 when '00' then '内'                                                                                                                                                                                     ");
		sql.append(" 	 else '外' end     IN_OUT_GUBUN                                                                                                                                                                          ");
		sql.append("      , A.SPECIMEN_SER                          SPECIMEN_SER                                                                                                                                                 ");
		sql.append("      , MIN(A.BUNHO)                                       BUNHO                                                                                                                                             ");
		sql.append("      , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))               SUNAME                                                                                                                                            ");
		sql.append("      , MIN(case A.IN_OUT_GUBUN when 'I' then FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(),:f_hosp_code,:f_language) else FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language) end)        GWA_NAME    ");
		sql.append("      , CAST(' ' AS CHAR)                                          DANGER_YN                                                                                                                                 ");
	    sql.append("      , CONCAT('a',IFNULL(A.SPECIMEN_SER,''),'a' )     SPECIMEN_SER_BA                                                                                                                                       ");
	    sql.append("      , MIN(A.JANGBI_CODE)                              JANGBI_CODE                                                                                                                                          ");
	    sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE,:f_hosp_code,:f_language))) JANGBI_NAME                                               ");
	    sql.append("      , MIN(CONCAT(IFNULL(SUBSTR(A.SPECIMEN_SER,5,2),''),'-',IFNULL(SUBSTR(A.SPECIMEN_SER,7),''))) GUMSA_NAME_RE                                                                                             ");
	    sql.append("      , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)               TUBE_COUNT                                                                                                                               ");
	    sql.append("      , MIN( CONCAT(IFNULL(D.CODE_NAME_RE2,''),IFNULL(case D.CODE_NAME_RE2 when NULL then NULL else 'mL' end,'')))   TUBE_MAX_AMT                                                                            ");
	    sql.append("      , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))   TUBE_NUMBERING                                                                                            ");
	    sql.append("   FROM CPL0109 D RIGHT JOIN CPL0101 B ON D.HOSP_CODE  = B.HOSP_CODE AND D.CODE = B.TUBE_CODE AND D.CODE_TYPE = '02'                                                                                         ");
	    sql.append("      , OUT0101 C                                                                                                                                                                                            ");
	    sql.append("      , CPL2010 A                                                                                                                                                                                            ");
	    sql.append("  WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                                                       ");
	    sql.append("    AND A.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                                        ");
	    sql.append("    AND C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                                        ");
	    sql.append("    AND A.SPECIMEN_SER  = :f_specimen_ser                                                                                                                                                                    ");
	    sql.append("    AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                                                                     ");
	    sql.append("    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                                                                    ");
	    sql.append("    AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                                                        ");
	    sql.append("    AND C.BUNHO         = A.BUNHO                                                                                                                                                                            ");
	    sql.append("    AND B.OUT_TUBE2 IS NOT NULL                                                                                                                                                                              ");
	    sql.append("  GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.OUT_TUBE2                                                                                                                                                         ");
	    sql.append(" UNION                                                                                                                                                                                                       ");
	    sql.append(" SELECT DISTINCT                                                                                                                                                                                             ");
	    sql.append("        MIN(A.JUNDAL_GUBUN)                             JUNDAL_GUBUN                                                                                                                                         ");
		sql.append("      , CAST(' ' AS CHAR) JUNDAL_GUBUN_NAME                                                                                                                                                                   ");
		sql.append("      , CAST(' ' AS CHAR)                                             SPECIMEN_CODE                                                                                                                          ");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language))) SPECIMEN_NAME                                        ");
		sql.append("      , MIN(B.TUBE_CODE)                                TUBE_CODE                                                                                                                                            ");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language))) TUBE_NAME                                                    ");
		sql.append("      , case B.UITAK_CODE                                                                                                                                                                                    ");
		sql.append(" 	 when '00' then '内'                                                                                                                                                                                     ");
		sql.append(" 	 else '外' end      IN_OUT_GUBUN                                                                                                                                                                         ");
		sql.append("      , A.SPECIMEN_SER                          SPECIMEN_SER                                                                                                                                                 ");
		sql.append("      , MIN(A.BUNHO)                                       BUNHO                                                                                                                                             ");
		sql.append("      , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))               SUNAME                                                                                                                                            ");
		sql.append(" 	 ,MIN(case A.IN_OUT_GUBUN when 'I' then FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(),:f_hosp_code,:f_language) else FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language) end)      GWA_NAME                     ");
		sql.append("      , CAST(' ' AS CHAR)                                             DANGER_YN                                                                                                                               ");
		sql.append("      , CONCAT('a',IFNULL(A.SPECIMEN_SER,''),'a')   SPECIMEN_SER_BA                                                                                                                                           ");
		sql.append("      , MIN(A.JANGBI_CODE)                              JANGBI_CODE                                                                                                                                           ");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE,:f_hosp_code,:f_language))) JANGBI_NAME                                                ");
		sql.append("      , MIN(CONCAT(IFNULL(SUBSTR(A.SPECIMEN_SER,5,2),''),'-',IFNULL(SUBSTR(A.SPECIMEN_SER,7),''))) GUMSA_NAME_RE                                                                                              ");
		sql.append("      , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)               TUBE_COUNT                                                                                                                                ");
		sql.append("      ,MIN( CONCAT(IFNULL(D.CODE_NAME_RE2,''),IFNULL(case D.CODE_NAME_RE2 when NULL then NULL else 'mL' end,'')))  TUBE_MAX_AMT                                                                               ");
		sql.append("      , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))   TUBE_NUMBERING                                                                                             ");
		sql.append("   FROM CPL0109 D RIGHT JOIN CPL0101 B ON D.HOSP_CODE = B.HOSP_CODE AND D.CODE   = B.TUBE_CODE AND D.CODE_TYPE = '02'                                                                                         ");
		sql.append("      , OUT0101 C                                                                                                                                                                                             ");
		sql.append("      , CPL2010 A                                                                                                                                                                                             ");
		sql.append("  WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                                                        ");
		sql.append("    AND A.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                                         ");
		sql.append("    AND C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                                         ");
		sql.append("    AND A.SPECIMEN_SER  = :f_specimen_ser                                                                                                                                                                     ");
		sql.append("    AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                                                                      ");
		sql.append("    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                                                                     ");
		sql.append("    AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                                                         ");
		sql.append("    AND C.BUNHO         = A.BUNHO                                                                                                                                                                             ");
		sql.append("  GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.JANGBI_OUT_CODE3                                                                                                                                                   ");
		sql.append("  ORDER BY 5, 8																																						                                          ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> listLayBarcode= new JpaResultMapper().list(query, CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo.class);
		return listLayBarcode;
	}

	@Override
	public List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> getCplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo(String hospCode,String language, Date jubsuDate, String bunho) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT MIN(A.JUNDAL_GUBUN)                             JUNDAL_GUBUN                                                                                    																		");
		sql.append("      , CAST(' ' AS CHAR) JUNDAL_GUBUN_NAME                                                                                                             																        ");
		sql.append("      , MIN(A.SPECIMEN_CODE)                     SPECIMEN_CODE                                                                                          																		");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language))) SPECIMEN_NAME                                     						");
		sql.append("      , MIN(B.OUT_TUBE2)                        TUBE_CODE                                                                                               ");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',B.OUT_TUBE2,:f_hosp_code,:f_language),IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language)))) TUBE_NAME  ");
		sql.append("      ,CASE  B.UITAK_CODE WHEN '00' THEN '内' ELSE '外' END   IN_OUT_GUBUN                                                                              ");
		sql.append("      , A.SPECIMEN_SER                          SPECIMEN_SER                                                                                            ");
		sql.append("      , MIN(A.BUNHO)                                       BUNHO                                                                                        ");
		sql.append("      , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))               SUNAME                                                                                       ");
		sql.append("      , MIN( CASE A.IN_OUT_GUBUN WHEN 'I' then FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(),:f_hosp_code,:f_language) ELSE FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language) END)     GWA_NAME   ");
		sql.append("      , CAST(' ' AS CHAR)                                             DANGER_YN                                                                                       ");
		sql.append("      ,CONCAT('a',IFNULL(A.SPECIMEN_SER,CAST(' ' AS CHAR)),'a' )     SPECIMEN_SER_BA                                                                                   ");
		sql.append("      , MIN(A.JANGBI_CODE)                              JANGBI_CODE                                                                                     ");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE,:f_hosp_code,:f_language))) JANGBI_NAME                                           ");
		sql.append("      ,MIN(CONCAT(IFNULL(SUBSTR(A.SPECIMEN_SER,5,2),CAST('' AS CHAR)),'-',IFNULL(SUBSTR(A.SPECIMEN_SER,7),CAST(' ' AS CHAR)))) GUMSA_NAME_RE                                         ");
		sql.append("      , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)                TUBE_COUNT                                                                                      ");
		sql.append("      ,MIN( CONCAT(IFNULL(D.CODE_NAME_RE2,CAST(' ' AS CHAR)  ),IFNULL(CASE D.CODE_NAME_RE2 WHEN NULL THEN NULL ELSE 'mL' END,CAST(' ' AS CHAR)  )))   TUBE_MAX_AMT                        ");
		sql.append("      , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))   TUBE_NUMBERING                                                   ");
		sql.append(" 	FROM CPL0109 D RIGHT JOIN CPL0101 B ON D.HOSP_CODE  = B.HOSP_CODE AND D.CODE = B.TUBE_CODE AND D.CODE_TYPE = '02'                                  							");
		sql.append("        , OUT0101 C                                                                                                                                    							");
		sql.append("        , CPL2010 A                                                                                                                                    							");
		sql.append("  WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                 							");
		sql.append("    AND A.HOSP_CODE     = B.HOSP_CODE                                                                                                                  							");
		sql.append("    AND C.HOSP_CODE     = B.HOSP_CODE                                                                                                                  							");
		sql.append("    AND (  (A.DUMMY     = 'Y')                                                                                                                         							");
		sql.append("         OR(A.UPD_ID    = 'CPLPRT')                                                                                                                    							");
		sql.append("        )                                                                                                                                              							");
		sql.append("    AND A.JUBSU_DATE    = :f_jubsu_date                                                                                                                							");
		sql.append("    AND A.BUNHO         = :f_bunho                                                                                                                     							");
		sql.append("    AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                               							");
		sql.append("    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                              							");
		sql.append("    AND B.EMERGENCY     = A.EMERGENCY                                                                                                                  							");
		sql.append("    AND B.OUT_TUBE2 IS NOT NULL                                                                                                                        							");
		sql.append("    AND C.BUNHO         = A.BUNHO                                                                                                                      							");
		sql.append("  GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.OUT_TUBE2                                                                                                   							");
		sql.append("  UNION                                                                                                                                                							");
		sql.append(" SELECT DISTINCT                                                                                                                                       							");
		sql.append("        MIN(A.JUNDAL_GUBUN)                             JUNDAL_GUBUN                                                                                   							");
		sql.append("      , CAST(' ' AS CHAR) JUNDAL_GUBUN_NAME                                                                                                                            ");
		sql.append("      , MIN(A.SPECIMEN_CODE)                     SPECIMEN_CODE                                                                                          				");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language))) SPECIMEN_NAME                                     ");
		sql.append("      , MIN(B.TUBE_CODE)                                TUBE_CODE                                                                                       ");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language))) TUBE_NAME                                                 ");
		sql.append("      ,case  B.UITAK_CODE when '00' then '内' else '外' end   IN_OUT_GUBUN                                                                              ");
		sql.append("      , A.SPECIMEN_SER                          SPECIMEN_SER                                                                                            ");
		sql.append("      , MIN(A.BUNHO)                                       BUNHO                                                                                        ");
		sql.append("      , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))               SUNAME                                                                                       ");
		sql.append("      , MIN(case A.IN_OUT_GUBUN when 'I' then FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(),:f_hosp_code,:f_language) else FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language) end)   GWA_NAME      ");
		sql.append("      , CAST(' ' AS CHAR)                                             DANGER_YN                                                                                       ");
		sql.append("      ,CONCAT('a',IFNULL(A.SPECIMEN_SER,CAST('' AS CHAR)),'a' )    SPECIMEN_SER_BA              														 ");
		sql.append("      , MIN(A.JANGBI_CODE)                              JANGBI_CODE                                                                                     ");
		sql.append("      , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE,:f_hosp_code,:f_language))) JANGBI_NAME                                           ");
		sql.append("      , MIN(CONCAT(IFNULL(SUBSTR(A.SPECIMEN_SER,5,2),CAST(' ' AS CHAR)  ),'-',IFNULL(SUBSTR(A.SPECIMEN_SER,7),CAST(' ' AS CHAR)  ))) GUMSA_NAME_RE                                        ");
		sql.append("      , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)                TUBE_COUNT                                                                                      ");
		sql.append("      ,MIN( CONCAT(IFNULL(D.CODE_NAME_RE2,CAST(' ' AS CHAR)  ),IFNULL(case D.CODE_NAME_RE2 when NULL then NULL else 'mL' end,CAST(' ' AS CHAR)  )))   TUBE_MAX_AMT                        ");
		sql.append("      , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))   TUBE_NUMBERING                                                   ");
		sql.append(" FROM CPL0109 D RIGHT JOIN CPL0101 B ON D.HOSP_CODE  = B.HOSP_CODE AND D.CODE = B.TUBE_CODE AND D.CODE_TYPE = '02'   	                                ");
		sql.append("    , OUT0101 C                                                                                                      	                                ");
		sql.append("    , CPL2010 A                                                                                                                                         ");
		sql.append("  WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                  ");
		sql.append("    AND A.HOSP_CODE     = B.HOSP_CODE                                                                                                                   ");
		sql.append("    AND C.HOSP_CODE     = B.HOSP_CODE                                                                                                                   ");
		sql.append("    AND (  (A.DUMMY     = 'Y')                                                                                                                          ");
		sql.append("         OR(A.UPD_ID    = 'CPLPRT')                                                                                                                     ");
		sql.append("        )                                                                                                                                               ");
		sql.append("    AND A.JUBSU_DATE    = :f_jubsu_date                                                                                                                 ");
		sql.append("    AND A.BUNHO         = :f_bunho                                                                                                                      ");
		sql.append("    AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                ");
		sql.append("    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                               ");
		sql.append("    AND B.EMERGENCY     = A.EMERGENCY                                                                                                                   ");
		sql.append("    AND C.BUNHO         = A.BUNHO                                                                                                                       ");
		sql.append("  GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.JANGBI_OUT_CODE3                                                                                             ");
		sql.append("  ORDER BY  5, 8																																		");										
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_bunho", bunho);
		List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> listLayBarcode2= new JpaResultMapper().list(query, CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo.class);
		return listLayBarcode2;
	}

	@Override
	public String callCPL2010U00PrCplMakeSpecimenSer(String hospCode,String language, Date orderDate, String bunho, String jubsuja,
			String jubsuFlag, String jubsuGubun, Date jubsuDate,String jubsuTime) {
		LOG.info("[START] callCPL2010U00PrCplMakeSpecimenSer hospitalCode=" + hospCode + ", language=" + language + ", orderDate=" + orderDate + ","
				+ " bunho=" + bunho+" jubsuja="+jubsuja+" jubsuFlag= "+jubsuFlag+" jubsuGubun="+jubsuGubun+" jubsuDate="+jubsuDate+" jubsuTime="+jubsuTime);

		String ioFlg = "";
		StoredProcedureQuery query= entityManager.createStoredProcedureQuery("PR_CPL_MAKE_SPECIMEN_SER");
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSUJA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_FLAG", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_JUBSU_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_ORDER_DATE", orderDate);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_JUBSUJA", jubsuja);
		query.setParameter("I_JUBSU_FLAG", jubsuFlag);
		query.setParameter("I_JUBSU_GUBUN", jubsuGubun);
		query.setParameter("I_JUBSU_DATE", jubsuDate);
		query.setParameter("I_JUBSU_TIME", jubsuTime);
		query.setParameter("IO_FLAG", "");

		query.execute();
		ioFlg=(String) query.getOutputParameterValue("IO_FLAG");
		LOG.info("[END] callCPL2010U00PrCplMakeSpecimenSer : "+ ioFlg);
		return ioFlg;
	}

	@Override
	public void callCPL2010U00PrSchUpdateActing(String hospCode, String iOGubun, Double fkocs1003, Date actingDate) {
		LOG.info("[START] callCPL2010U00PrSchUpdateActing hospitalCode=" + hospCode + "fkocs1003 = "+fkocs1003);
//		if(actingDate == null){
//			actingDate = DateUtil.toDate("0105/01/01", DateUtil.PATTERN_YYMMDD);
//		}
		StoredProcedureQuery query= entityManager.createStoredProcedureQuery("PR_SCH_UPDATE_ACTING");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IN_OUT_GUBUN", iOGubun);
		query.setParameter("I_FKOCS", fkocs1003);
		query.setParameter("I_ACTING_DATE", actingDate);
		
		query.execute();
	}

	@Override
	public void callCPL2010U00PrOcsUpdateJubsu(String hospCode, String iOGubun, 
			Integer fkocs1003, String jubsuBuseo, Date jubsuDate, String jubsuTime) {
		LOG.info("[START] callCPL2010U00PrOcsUpdateJubsu hospitalCode=" + hospCode + "fkocs1003 = "+fkocs1003);
		StoredProcedureQuery query= entityManager.createStoredProcedureQuery("PR_OCS_UPDATE_JUBSU");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_BUSEO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_TIME", String.class, ParameterMode.IN);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IN_OUT_GUBUN", iOGubun);
		query.setParameter("I_FKOCS", fkocs1003);
		query.setParameter("I_JUBSU_BUSEO", jubsuBuseo);
		query.setParameter("I_JUBSU_DATE", jubsuDate);
		query.setParameter("I_JUBSU_TIME", jubsuTime);
		
		Boolean isValid=query.execute();
		
	}

	@Override
	public String callCPL2010U00PrCplPartJubsu(String hospCode,String specimenSer, String jundalGunbun, Date partJubsuDate,
			String partJubsuTime, String partJubsuja, String userId) {
		LOG.info("[START] callCPL2010U00PrCplPartJubsu hospitalCode=" + hospCode + "specimenSer = "+specimenSer+"jundalGunbun:"+jundalGunbun
				+"partJubsuDate="+partJubsuDate+"partJubsuTime="+partJubsuTime+"partJubsuja="+partJubsuja+"userId:"+userId);
		
		String ioFlg = "";
		
		StoredProcedureQuery query= entityManager.createStoredProcedureQuery("PR_CPL_PART_JUBSU");
		query.registerStoredProcedureParameter("I_HOSP_CODE",  String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_SER",  String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUNDAL_GUBUN",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_PART_JUBSU_DATE",  Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PART_JUBSU_TIME",  String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PART_JUBSUJA",  String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID",  String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_FLAG",  String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SPECIMEN_SER", specimenSer);
		query.setParameter("I_JUNDAL_GUBUN", jundalGunbun);
		query.setParameter("I_PART_JUBSU_DATE", partJubsuDate);
		query.setParameter("I_PART_JUBSU_TIME", partJubsuTime);
		query.setParameter("I_PART_JUBSUJA", partJubsuja);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("IO_FLAG", "");
		
	//	Boolean isValid=query.execute();
		ioFlg=(String) query.getOutputParameterValue("IO_FLAG");
		return ioFlg;
	}

	@Override
	public CplsCPL2010U00PrCplBunhoLoadMinCPL2010ListItemInfo callCPL2010U00PrCplBunhoLoadMin(String hospCode,String language, String bunho) {
		LOG.info("[START] callCPL2010U00PrCplBunhoLoadMin hospitalCode=" + hospCode + "language = "+language+"bunho="+bunho);
		Integer age = 0;
		Date date= new Date();
		StoredProcedureQuery query= entityManager.createStoredProcedureQuery("PR_CPL_BUNHO_LOAD_MIN");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_SUNAME",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_SUJUMIN1",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_SUJUMIN2",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_SEX",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_AGE",  Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_BIRTH",  Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_ADDRESS",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_HO_DONG",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_HO_CODE",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_GWA",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_GWA_NAME",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_DOCTOR",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_DOCTOR_NAME",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_RESIDENT",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_RESIDENT_NAME",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_IN_OUT_GUBUN",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_TEL",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_JUBSU_DATE",  Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_JUBSU_TIME",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_JUBSUJA",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_PART_JUBSU_DATE",  Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_PART_JUBSU_TIME",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_PART_JUBSUJA",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_TAT1",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_TAT2",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_PA_NOTE",  String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_FLAG",  String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_BUNHO", bunho);
		
		query.setParameter("O_SUNAME", "");
		query.setParameter("O_SUJUMIN1", "");
		query.setParameter("O_SUJUMIN2", "");
		query.setParameter("O_SEX", "");
		query.setParameter("O_AGE",age);
		query.setParameter("O_BIRTH", date);
		query.setParameter("O_ADDRESS", "");
		query.setParameter("O_HO_DONG", "");
		query.setParameter("O_HO_CODE", "");
		query.setParameter("O_GWA", "");
		query.setParameter("O_GWA_NAME", "");
		query.setParameter("O_DOCTOR", "");
		query.setParameter("O_DOCTOR_NAME", "");
		query.setParameter("O_RESIDENT", "");
		query.setParameter("O_RESIDENT_NAME", "");
		query.setParameter("O_IN_OUT_GUBUN", "");
		query.setParameter("O_TEL", "");
		query.setParameter("O_JUBSU_DATE", date);
		query.setParameter("O_JUBSU_TIME", "");
		query.setParameter("O_JUBSUJA", "");
		query.setParameter("O_PART_JUBSU_DATE", date);
		query.setParameter("O_PART_JUBSU_TIME", "");
		query.setParameter("O_PART_JUBSUJA", "");
		query.setParameter("O_TAT1", "");
		query.setParameter("O_TAT2", "");
		query.setParameter("O_PA_NOTE", "");
		query.setParameter("O_FLAG", "");
		
		Boolean isValid=query.execute();
		
		CplsCPL2010U00PrCplBunhoLoadMinCPL2010ListItemInfo object = new CplsCPL2010U00PrCplBunhoLoadMinCPL2010ListItemInfo();
		object.setIoFlag((String)query.getOutputParameterValue("O_FLAG")); 
		object.setSuname((String)query.getOutputParameterValue("O_SUNAME"));
		object.setSujumin1((String)query.getOutputParameterValue("O_SUJUMIN1"));
		object.setSujumin2((String)query.getOutputParameterValue("O_SUJUMIN2"));
		object.setSex((String)query.getOutputParameterValue("O_SEX"));
		object.setAge(query.getOutputParameterValue("O_AGE").toString());
		object.setBirth(query.getOutputParameterValue("O_BIRTH").toString());
		object.setAddress((String)query.getOutputParameterValue("O_ADDRESS"));
		object.setHoDong((String)query.getOutputParameterValue("O_HO_DONG"));
		object.setHoCode((String)query.getOutputParameterValue("O_HO_CODE"));
		object.setGwa((String)query.getOutputParameterValue("O_GWA"));
		object.setGwaName((String)query.getOutputParameterValue("O_GWA_NAME"));
		object.setDoctor((String)query.getOutputParameterValue("O_DOCTOR"));
		object.setDoctorName((String)query.getOutputParameterValue("O_DOCTOR_NAME"));
		object.setResident((String)query.getOutputParameterValue("O_RESIDENT"));
		object.setResidentName((String)query.getOutputParameterValue("O_RESIDENT_NAME"));
		object.setInOutGubun((String)query.getOutputParameterValue("O_IN_OUT_GUBUN"));
		object.setTel((String)query.getOutputParameterValue("O_TEL"));
		object.setJubsuDate(query.getOutputParameterValue("O_JUBSU_DATE").toString());
		object.setJubsuTime((String)query.getOutputParameterValue("O_JUBSU_TIME"));
		object.setJubsuja((String)query.getOutputParameterValue("O_JUBSUJA"));
		object.setPartJubsuDate(query.getOutputParameterValue("O_PART_JUBSU_DATE").toString());
		object.setPartJubsuTime((String)query.getOutputParameterValue("O_PART_JUBSU_TIME"));
		object.setPartJubsuja((String)query.getOutputParameterValue("O_PART_JUBSUJA"));
		object.setTat1((String)query.getOutputParameterValue("O_TAT1"));
		object.setTat2((String)query.getOutputParameterValue("O_TAT2"));
		object.setPaNote((String)query.getOutputParameterValue("O_PA_NOTE"));
		

		
		return object;
	}

	@Override
	public List<CPL3010U01MaxInfoListItemInfo> getCPL3010U01MaxInfoListItemInfo(String hosCode, String fromPartJubsuDate, String toPartJubsuDate,String fromSeq, String toSeq) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT MAX(B.SPECIMEN_SER)                                                                  ");
		sql.append("      , MAX(DATE_FORMAT(B.PART_JUBSU_DATE,'%Y/%m/%d'))                                       ");
		sql.append("      , MAX(B.PART_JUBSU_TIME)                                                               ");
		sql.append("   FROM CPL2010 B                                                                            ");
		sql.append("  WHERE B.HOSP_CODE = :f_hosp_code                                                           ");
		sql.append("    AND B.PART_JUBSU_DATE BETWEEN STR_TO_DATE(:f_from_part_jubsu_date,'%Y/%m/%d')            ");
		sql.append("                              AND STR_TO_DATE(:f_to_part_jubsu_date,'%Y/%m/%d')              ");
		sql.append("    AND CONCAT(IFNULL(B.PART_JUBSU_DATE,''),IFNULL(B.PART_JUBSU_TIME,''))                    ");
		sql.append("    BETWEEN CONCAT(IFNULL(STR_TO_DATE(:f_from_part_jubsu_date,'%Y/%m/%d'),''),:f_from_seq)   ");
		sql.append("       AND CONCAT(IFNULL(STR_TO_DATE(:f_to_part_jubsu_date,'%Y/%m/%d'),''),:f_to_seq)        ");
		sql.append("    AND B.PART_JUBSU_DATE IS NOT NULL                                                        ");
		sql.append("    AND IFNULL(B.DC_YN,'N')  = 'N'                                                           ");
		sql.append("    AND B.UITAK_CODE      = '01'                                                             ");
		sql.append("  ORDER BY B.PART_JUBSU_DATE DESC, B.PART_JUBSU_TIME DESC, B.SPECIMEN_SER DESC  LIMIT 1      ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hosCode);
		query.setParameter("f_from_part_jubsu_date", fromPartJubsuDate);
		query.setParameter("f_to_part_jubsu_date", toPartJubsuDate);
		query.setParameter("f_from_seq", fromSeq);
		query.setParameter("f_to_seq", toSeq);
		List<CPL3010U01MaxInfoListItemInfo> listMax=new JpaResultMapper().list(query, CPL3010U01MaxInfoListItemInfo.class);
		return listMax;
	}

	@Override
	public List<CPL3010U01MaxInfoListItemInfo> getCPL3010U01MaxInfoListItemInfo2(String hospCode, String fromSpecimenSer, String toSpecimenSer) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT MAX(B.SPECIMEN_SER)                                                            ");
		sql.append("     , MAX(DATE_FORMAT(B.PART_JUBSU_DATE,'%Y/%m/%d'))                                  ");
		sql.append("     , MAX(B.PART_JUBSU_TIME)                                                          ");
		sql.append("  FROM CPL2010 B                                                                       ");
		sql.append(" WHERE B.HOSP_CODE = :f_hosp_code                                                      ");
		sql.append("   AND B.SPECIMEN_SER BETWEEN :f_from_specimen_ser                                     ");
		sql.append("                          AND :f_to_specimen_ser                                       ");
		sql.append("   AND B.PART_JUBSU_DATE IS NOT NULL                                                   ");
		sql.append("   AND IFNULL(B.DC_YN,'N')  = 'N'                                                      ");
		sql.append("   AND B.UITAK_CODE      = '01'                                                        ");
		sql.append(" ORDER BY B.PART_JUBSU_DATE DESC, B.PART_JUBSU_TIME DESC, B.SPECIMEN_SER DESC LIMIT 1  ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_specimen_ser", fromSpecimenSer);
		query.setParameter("f_to_specimen_ser", toSpecimenSer);
		List<CPL3010U01MaxInfoListItemInfo> listMax2= new JpaResultMapper().list(query, CPL3010U01MaxInfoListItemInfo.class);
		return listMax2;
	}

	@Override
	public List<CPL3010U00LayBarCodeTempListItemInfo> getCPL3010U00LayBarCodeTempListItemInfo(String hospCode, String language, String specimenSer){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                                                            ");
		sql.append("       MIN(A.JUNDAL_GUBUN)                             JUNDAL_GUBUN                                                                                                                        ");
		sql.append("     , MIN(IF(B.JUNDAL_GUBUN_NAME IS NULL,IFNULL(CONCAT(FN_CPL_HANGMOG_MARK_NAME(A.SPECIMEN_SER,:f_hosp_code),' '                                                                          ");
		sql.append("     ,IFNULL(FN_CPL_CODE_NAME_RE('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)))                                            ");
		sql.append("     ,IFNULL(FN_CPL_CODE_NAME_RE('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language))),B.JUNDAL_GUBUN_NAME))   JUNDAL_GUBUN_NAME  ");
		sql.append("     , ' '                                             SPECIMEN_CODE                                                                                                                       ");
		sql.append("     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE,:f_hosp_code,:f_language))) SPECIMEN_NAME                       ");
		sql.append("     , MIN(B.TUBE_CODE)                                TUBE_CODE                                                                                                                           ");
		sql.append("     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language))) TUBE_NAME                                   ");
		sql.append("     , IFNULL(B.UITAK_CODE,MAX(A.EMERGENCY))                        IN_OUT_GUBUN                                                                                                           ");
		sql.append("     , A.SPECIMEN_SER                          SPECIMEN_SER                                                                                                                                ");
		sql.append("     , MIN(A.BUNHO)                                       BUNHO                                                                                                                            ");
		sql.append("     , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))               SUNAME                                                                                                                           ");
		sql.append("     , MIN(IF(A.IN_OUT_GUBUN = 'I',FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(),:f_hosp_code,:f_language),FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language)))        GWA_NAME     ");
		sql.append("     , ' '                                             DANGER_YN                                                                                                                           ");
		sql.append("     , CONCAT('a',A.SPECIMEN_SER,'a')                        SPECIMEN_SER_BA                                                                                                               ");
		sql.append("     , MIN(A.JANGBI_CODE)                              JANGBI_CODE                                                                                                                         ");
		sql.append("     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE,:f_hosp_code,:f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE,:f_hosp_code,:f_language))) JANGBI_NAME                             ");
		sql.append("     , MIN(CONCAT(SUBSTR(A.SPECIMEN_SER,5,2),'-',SUBSTR(A.SPECIMEN_SER,7))) GUMSA_NAME_RE                                                                                                  ");
		sql.append("     , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)               TUBE_COUNT                                                                                                             ");
		sql.append("     , ' '                                                          HANGMOG_CODE                                                                                                           ");
		sql.append("     , MIN(CONCAT(D.CODE_NAME_RE2,IF(D.CODE_NAME_RE2 IS NULL,'','mL')))   TUBE_MAX_AMT                                                                                                     ");
		sql.append("     , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))   TUBE_NUMBERING                                                                          ");
		sql.append("  FROM OUT0101 C                                                                                                                                                                           ");
		sql.append("     , CPL2010 A                                                                                                                                                                           ");
		sql.append("     , CPL0101 B LEFT OUTER JOIN CPL0109 D ON D.HOSP_CODE  = B.HOSP_CODE                                                                                                                   ");
		sql.append("     AND D.CODE_TYPE  = '02'                                                                                                                                                               ");
		sql.append("   AND D.CODE       = B.TUBE_CODE                                                                                                                                                          ");
		sql.append(" WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                                      ");
		sql.append("   AND A.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                       ");
		sql.append("   AND C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                                       ");
		sql.append("   AND A.SPECIMEN_SER  like :f_specimen_ser                                                                                                                                                ");
		sql.append("   AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                                                    ");
		sql.append("   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                                                   ");
		sql.append("   AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                                       ");
		sql.append("   AND C.BUNHO         = A.BUNHO                                                                                                                                                           ");
		sql.append(" GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.JANGBI_OUT_CODE3                                                                                                                                 ");
		sql.append(" ORDER BY 8                                                                                                                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<CPL3010U00LayBarCodeTempListItemInfo> list = new JpaResultMapper().list(query, CPL3010U00LayBarCodeTempListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL3010U00GrdPartListItemInfo> getCPL3010U00GrdPartListItemInfo(String hospCode, String language, String partJubsuDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                               ");
		sql.append("       ' ' LAB_NO                                                                                                             ");
		sql.append("     , B.SPECIMEN_SER                                                                                                         ");
		sql.append("     , MIN(B.BUNHO)                                                                                                           ");
		sql.append("     , MIN(FN_OUT_LOAD_SUNAME2(B.BUNHO,:f_hosp_code))      SUNAME2                                                            ");
		sql.append("     , MIN(FN_BAS_LOAD_GWA_NAME(B.GWA,SYSDATE(),:f_hosp_code,:f_language))                                                    ");
		sql.append("     , MIN(B.HO_DONG)                                                                                                         ");
		sql.append("     , B.PART_JUBSU_DATE                                                                                                      ");
		sql.append("     , B.PART_JUBSU_TIME                                                                                                      ");
		sql.append("     , MIN(B.PART_JUBSUJA)                                                                                                    ");
		sql.append("     , MIN(B.JUBSUJA)                                                                                                         ");
		sql.append("     , MAX(IF(B.IN_OUT_GUBUN = 'O', C.ORDER_REMARK, A.ORDER_REMARK )) REMARK                                                  ");
		sql.append("     , MIN(IF(B.PART_JUBSU_DATE IS NULL,'N','Y')) PART_JUBSU_FLAG                                                             ");
		sql.append("     , 0                                    FKOCS                                                                             ");
		sql.append("     , MIN(B.IN_OUT_GUBUN)                                                                                                    ");
		sql.append("     , MIN(B.DOCTOR_NAME)                                                                                                     ");
		sql.append("     , MIN(E.CODE_NAME)    TUBE_NAME                                                                                          ");
		sql.append("     , MIN(B.EMERGENCY)    EMERGENCY                                                                                          ");
		sql.append("     , MAX(IF(B.IN_OUT_GUBUN = 'O', C.IF_DATA_SEND_YN , A.IF_DATA_SEND_YN )) SUNAB_YN                                         ");
		sql.append("     , MAX(IF(B.RESULT_DATE IS NULL,'N','Y'))    RESULT_YN                                                                    ");
		sql.append("     , MAX(IF(F.CODE IS NULL,'N','Y'))           LABEL_ONE_MORE                                                               ");
		sql.append("  FROM CPL0109 D,                                                                                                             ");
		sql.append("       CPL2010 B LEFT OUTER JOIN OCS2003 A ON A.HOSP_CODE = B.HOSP_CODE AND B.FKOCS2003 = A.PKOCS2003                         ");
		sql.append("                 LEFT OUTER JOIN OCS1003 C ON C.HOSP_CODE = B.HOSP_CODE AND B.FKOCS1003 = C.PKOCS1003                         ");
		sql.append("                 LEFT OUTER JOIN CPL0109 E ON E.HOSP_CODE = B.HOSP_CODE AND E.CODE_TYPE = '02' AND E.CODE = B.TUBE_CODE       ");
		sql.append("                 LEFT OUTER JOIN CPL0109 F ON F.HOSP_CODE = B.HOSP_CODE AND F.CODE_TYPE = '21' AND F.CODE = B.TUBE_CODE       ");
		sql.append(" WHERE B.HOSP_CODE             = :f_hosp_code                                                                                 ");
		sql.append("   AND D.HOSP_CODE             = B.HOSP_CODE                                                                                  ");
		sql.append("   AND B.PART_JUBSU_DATE       = STR_TO_DATE(:f_part_jubsu_date,'%Y/%m/%d')                                                   ");
		sql.append("   AND IFNULL(B.DC_YN,'N')     = 'N'                                                                                          ");
		sql.append("   AND D.CODE_TYPE             = '01'                                                                                         ");
		sql.append("   AND D.CODE                  = B.JUNDAL_GUBUN                                                                               ");
		sql.append("   AND B.SPECIMEN_SER   IS NOT NULL                                                                                           ");
		sql.append(" GROUP BY B.PART_JUBSU_DATE,B.PART_JUBSU_TIME,B.SPECIMEN_SER,B.JUNDAL_GUBUN                                                   ");
		sql.append(" ORDER BY B.SPECIMEN_SER DESC                                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_part_jubsu_date", partJubsuDate);
		
		List<CPL3010U00GrdPartListItemInfo> list = new JpaResultMapper().list(query, CPL3010U00GrdPartListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL3010U00GrdPartListItemInfo> getCPL3010U00QuerySpecimenBySer(String hospCode, String language, String specimenSer){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                      ");
		sql.append("        ' ' LAB_NO                                                                                                                   ");
		sql.append("      , B.SPECIMEN_SER                                                                                                               ");
		sql.append("      , B.BUNHO                                                                                                                      ");
		sql.append("      , C.SUNAME                                                                                                                     ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(B.GWA,SYSDATE(),:f_hosp_code,:f_language)                                                               ");
		sql.append("      , B.HO_DONG                                                                                                                    ");
		sql.append("      , B.PART_JUBSU_DATE                                                                                                            ");
		sql.append("      , B.PART_JUBSU_TIME                                                                                                            ");
		sql.append("      , B.PART_JUBSUJA                                                                                                               ");
		sql.append("      , B.JUBSUJA                                                                                                                    ");
		sql.append("      , FN_CPL_LOAD_COMMENT(B.SPECIMEN_SER,:f_hosp_code)      REMARK                                                                 ");
		sql.append("      , IF(B.PART_JUBSU_DATE IS NULL,'N','Y') PART_JUBSU_FLAG                                                                        ");
		sql.append("      , 0                                      FKOCS                                                                                 ");
		sql.append("      , B.IN_OUT_GUBUN                                                                                                               ");
		sql.append("      , B.DOCTOR_NAME                                                                                                                ");
		sql.append("      , E.CODE_NAME    TUBE_NAME                                                                                                     ");
		sql.append("      , B.EMERGENCY    EMERGENCY                                                                                                     ");
		sql.append("      , IF(B.SUNAB_DATE IS NULL,'N','Y')     SUNAB_YN                                                                                ");
		sql.append("      , IF(B.RESULT_DATE IS NULL,'N','Y')    RESULT_YN                                                                               ");
		sql.append("      , IF(F.CODE IS NULL,'N','Y')           LABEL_ONE_MORE                                                                          ");
		sql.append("   FROM CPL0109 D,                                                                                                                   ");
		sql.append("        OUT0101 C,                                                                                                                   ");
		sql.append("        CPL2010 B LEFT OUTER JOIN CPL0109 F ON F.HOSP_CODE = B.HOSP_CODE AND F.CODE_TYPE = '21' AND F.CODE = B.TUBE_CODE             ");
		sql.append("                  LEFT OUTER JOIN CPL0109 E ON E.HOSP_CODE = B.HOSP_CODE AND E.CODE_TYPE = '02' AND E.CODE = B.TUBE_CODE             ");
		sql.append("  WHERE B.HOSP_CODE       = :f_hosp_code                                                                                             ");
		sql.append("    AND C.HOSP_CODE       = B.HOSP_CODE                                                                                              ");
		sql.append("    AND D.HOSP_CODE       = B.HOSP_CODE                                                                                              ");
		sql.append("    AND B.SPECIMEN_SER    = :f_specimen_ser                                                                                          ");
		sql.append("    AND C.BUNHO           = B.BUNHO                                                                                                  ");
		sql.append("    AND IFNULL(B.DC_YN,'N')  = 'N'                                                                                                   ");
		sql.append("    AND D.CODE_TYPE       = '01'                                                                                                     ");
		sql.append("    AND D.CODE            = B.JUNDAL_GUBUN                                                                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<CPL3010U00GrdPartListItemInfo> list = new JpaResultMapper().list(query, CPL3010U00GrdPartListItemInfo.class);
		return list;
	}
	
	
	@Override
	public String getCPL3010U00GetYValue(String hospCode,String specimenSer, boolean isNull){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT 'Y'                       ");
		sql.append("   FROM CPL2010                            ");
		sql.append("  WHERE HOSP_CODE       = :f_hosp_code     ");
		sql.append("    AND SPECIMEN_SER    = :f_specimen_ser  ");
		if(isNull){
			sql.append("    AND PART_JUBSU_DATE IS NULL            ");
		}else{
			sql.append("	AND PART_JUBSU_DATE IS NOT NULL        ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<String> list = query.getResultList();
		if(list != null && list.size() > 0){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public String callPrCplPartJubsuCancel(String userId, String specimenSer, Double fkcpl2010, String gubun, String hospCode,String iOFlag){
		LOG.info("[START] callPrCplPartJubsuCancel");
		String out = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL_PART_JUBSU_CANCEL");
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_SER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKCPL2010", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_SPECIMEN_SER", specimenSer);
		query.setParameter("I_FKCPL2010", fkcpl2010);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("IO_FLAG", iOFlag);
		
		Boolean isValid = query.execute();
		out = (String)query.getOutputParameterValue("IO_FLAG");
		
		LOG.info("[END] callPrCplPartJubsuCancel");
		return out;
	}
	
	@Override
	public String checkSpecimenSerCPL3010U00Execute(String hospCode, String specimenSer){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IF(IFNULL(MIN(SPECIMEN_SER), 'N') = 'N', 'N', 'Y') ");
		sql.append("    FROM CPL2010                                          ");
		sql.append("   WHERE HOSP_CODE      = :f_hosp_code                    ");
		sql.append("     AND SPECIMEN_SER   = :f_specimen_ser                 ");
		sql.append("     AND GUM_JUBSU_DATE IS NOT NULL                       ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<String> list = query.getResultList();
		if(list != null && list.size() > 0){
			return list.get(0);
		}
		return null;
	}
	@Override
	public List<CPL3020U00SelectFromStandardListItemInfo> getCPL3020U00SelectFromStandard(
			String hospCode, Double pkcpl3020) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.FROM_STANDARD  FROM_STANDARD		");
		sql.append("	    , A.TO_STANDARD    TO_STANDARD          ");
		sql.append("	    , A.SPECIMEN_CODE  SPECIMEN_CODE        ");
		sql.append("	    , A.EMERGENCY      EMERGENCY            ");
		sql.append("	    , DATE_FORMAT(B.ORDER_DATE,'%Y/%m/%d')     ORDER_DATE           ");
		sql.append("	 FROM CPL2010 B                             ");
		sql.append("	    , CPL3020 A                             ");
		sql.append("	WHERE A.HOSP_CODE    = :hospCode         ");
		sql.append("	  AND B.HOSP_CODE    = A.HOSP_CODE          ");
		sql.append("	  AND A.PKCPL3020    = :pkcpl3020         ");
		sql.append("	  AND B.PKCPL2010    = A.FKCPL2010          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkcpl3020", pkcpl3020);
		
		List<CPL3020U00SelectFromStandardListItemInfo> listResult = new JpaResultMapper().list(query, CPL3020U00SelectFromStandardListItemInfo.class);
		return listResult;
	}

	@Override
	public List<CPL3020U00SelectInOutGubunListItemInfo> getCPL3020U00SelectInOutGubun(
			String hospCode, String fkcpl2010) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	 SELECT IN_OUT_GUBUN												");
		sql.append("	    , IF(IN_OUT_GUBUN = 'I', FKOCS2003, FKOCS1003)  FKOCS           ");
		sql.append("	 FROM CPL2010                                                       ");
		sql.append("	WHERE HOSP_CODE = :hospCode                                         ");
		sql.append("	  AND PKCPL2010 = :fkcpl2010                                        ");
		
		 
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("hospCode", hospCode);
	    query.setParameter("fkcpl2010", fkcpl2010);
	    
	    List<CPL3020U00SelectInOutGubunListItemInfo> listResult = new JpaResultMapper().list(query, CPL3020U00SelectInOutGubunListItemInfo.class);
	    return listResult;
	}

	public PrCplSpecimenInfoResultListItemInfo prCplSpecimenInfoResult(String hospCode, String specimenSer){
		String ioBunho = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL_SPECIMEN_INFO_RESULT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_SER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_BUNHO", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUNAME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SEX", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BIRTH", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUJUMIN1", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUJUMIN2", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_GWA", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DOCTOR_NAME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_HO_DONG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_HO_CODE", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ORDER_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUBSU_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PART_JUBSU_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUBSU_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PART_JUBSU_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUBSUJA", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_IN_OUT_GUBUN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_GUBUN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SPECIMEN_CODE", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SPECIMEN_NAME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_TAT1", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_TAT2", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_AGE", Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SWITCH", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SPECIMEN_SER", specimenSer);
		
		Boolean isValid = query.execute();
		PrCplSpecimenInfoResultListItemInfo info = new PrCplSpecimenInfoResultListItemInfo();
		info.setBunho((String)query.getOutputParameterValue("IO_BUNHO"));
		info.setSuname((String)query.getOutputParameterValue("IO_SUNAME"));
		info.setSex((String)query.getOutputParameterValue("IO_SEX"));
		info.setBirth((Date)query.getOutputParameterValue("IO_BIRTH"));
		info.setSujumin1((String)query.getOutputParameterValue("IO_SUJUMIN1"));
		info.setSujumin2((String)query.getOutputParameterValue("IO_SUJUMIN2"));
		info.setGwa((String)query.getOutputParameterValue("IO_GWA"));
		info.setDoctorName((String)query.getOutputParameterValue("IO_DOCTOR_NAME"));
		info.setHoDong((String)query.getOutputParameterValue("IO_HO_DONG"));
		info.setHoCode((String)query.getOutputParameterValue("IO_HO_CODE"));
		info.setOrderDate((Date)query.getOutputParameterValue("IO_ORDER_DATE"));
		info.setJubsuDate((Date)query.getOutputParameterValue("IO_JUBSU_DATE"));
		info.setPartJubsuDate((Date)query.getOutputParameterValue("IO_PART_JUBSU_DATE"));
		info.setJubsuTime((String)query.getOutputParameterValue("IO_JUBSU_TIME"));
		info.setPartJubsuTime((String)query.getOutputParameterValue("IO_PART_JUBSU_TIME"));
		info.setJubsuja((String)query.getOutputParameterValue("IO_JUBSUJA"));
		info.setInOutGubun((String)query.getOutputParameterValue("IO_IN_OUT_GUBUN"));
		info.setJundalGubun((String)query.getOutputParameterValue("IO_JUNDAL_GUBUN"));
		info.setSpecimenCode((String)query.getOutputParameterValue("IO_SPECIMEN_CODE"));
		info.setSpecimenName((String)query.getOutputParameterValue("IO_SPECIMEN_NAME"));
		info.setTat1((String)query.getOutputParameterValue("IO_TAT1"));
		info.setTat2((String)query.getOutputParameterValue("IO_TAT2"));
		info.setAge((Integer)query.getOutputParameterValue("IO_AGE"));
		info.setSwitchValue((String)query.getOutputParameterValue("IO_SWITCH"));
		return info;
	}
	
	@Override
	public List<CPL0000Q00LayJungboListItemInfo> getCPL0000Q00LayJungboListItemInfo(String hospCode, String language, String specimenSer,
			String hangmogCode, String specimenCode, String emegency){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                      ");
		sql.append("       B.ORDER_DATE                             ORDER_DATE,                                                                                          ");
		sql.append("       B.ORDER_TIME                             ORDER_TIME,                                                                                          ");
		sql.append("       B.JUBSU_DATE                             JUBSU_DATE,                                                                                          ");
		sql.append("       B.JUBSU_TIME                             JUBSU_TIME,                                                                                          ");
		sql.append("       B.PART_JUBSU_DATE                        PART_JUBSU_DATE,                                                                                     ");
		sql.append("       B.PART_JUBSU_TIME                        PART_JUBSU_TIME,                                                                                     ");
		sql.append("       B.RESULT_DATE                            RESULT_DATE,                                                                                         ");
		sql.append("       B.RESULT_TIME                            RESULT_TIME,                                                                                         ");
		sql.append("       B.SPECIMEN_SER                           SPECIMEN_SER,                                                                                        ");
		sql.append("       B.SPECIMEN_CODE                          SPECIMEN_CODE,                                                                                       ");
		sql.append("       IFNULL(C.CODE_NAME_RE, C.CODE_NAME)         SPECIMEN_NAME,                                                                                    ");
		sql.append("       D.ETC_COMMENT                                   NOTE,                                                                                         ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(B.GWA,SYSDATE(),:f_hosp_code, :f_language)      GWA_NAME,                                                                ");
		sql.append("       B.DOCTOR_NAME                            DOCTOR_NAME,                                                                                         ");
		sql.append("       FN_CPL_LOAD_COMMENT(B.SPECIMEN_SER,:f_hosp_code)      COMMENT,                                                                                ");
		sql.append("       E.NOTE                                   FIX_NOTE,                                                                                            ");
		sql.append("       FN_CPL_LOAD_RESULT_COMMENT(:f_specimen_ser,:f_hangmog_code,:f_specimen_code,:f_emergency,:f_hosp_code) HANGMOG_COMMENT,                       ");
		sql.append("       G.NOTE                                   PA_COMMENT                                                                                           ");
		sql.append("  FROM CPL2010 B LEFT OUTER JOIN CPL0109 C ON C.HOSP_CODE = B.HOSP_CODE AND C.CODE = B.SPECIMEN_CODE AND C.CODE_TYPE = '04' AND C.LANGUAGE =   :f_language  ");
		sql.append("                 LEFT OUTER JOIN CPL2090 D ON D.HOSP_CODE = B.HOSP_CODE AND D.SPECIMEN_SER = B.SPECIMEN_SER AND D.JUNDAL_PART = B.JUNDAL_GUBUN       ");
		sql.append("                 LEFT OUTER JOIN CPL0111 E ON E.HOSP_CODE = D.HOSP_CODE AND E.JUNDAL_GUBUN = D.JUNDAL_PART AND E.CODE = D.CODE                       ");
		sql.append("                 LEFT OUTER JOIN CPL1002 F ON F.HOSP_CODE = B.HOSP_CODE AND F.BUNHO = B.BUNHO                                                        ");
		sql.append("                 LEFT OUTER JOIN CPL0111 G ON G.HOSP_CODE = F.HOSP_CODE AND G.JUNDAL_GUBUN = 'PA' AND G.CODE = F.COMMENT_CODE                        ");
		sql.append(" WHERE B.HOSP_CODE       = :f_hosp_code                                                                                                              ");
		sql.append("   AND B.SPECIMEN_SER    = :f_specimen_ser                                                                                                           ");
		sql.append("   AND SUBSTR(B.SPECIMEN_CODE,1,1) != 'N'                                                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_specimen_code", specimenCode);
		query.setParameter("f_emergency", emegency);
		
		List<CPL0000Q00LayJungboListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00LayJungboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL0000Q00LayOrderListItemInfo> getCPL0000Q00LayOrder(String hospCode, String language, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                      ");
		sql.append("        A.ORDER_DATE                                                                                  ORDER_DATE     ");
		sql.append("      , IF(A.IN_OUT_GUBUN = 'O', A.GWA, FN_OCS_LOAD_ORDER_GWA(A.FKOCS2003,:f_hosp_code))              GWA            ");
		sql.append("      , IF(A.IN_OUT_GUBUN = 'O', A.DOCTOR, FN_OCS_LOAD_ORDER_DOCTOR(:f_hosp_code,A.FKOCS2003))        DOCTOR         ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                            GWA_NAME       ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)                                  DOCTOR_NAME    ");
		sql.append("      , A.IN_OUT_GUBUN                                                                                IN_OUT_GUBUN   ");
		sql.append("   FROM CPL2010 A                                                                                                    ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                   ");
		sql.append("    AND A.BUNHO     = :f_bunho                                                                                       ");
		sql.append("    AND A.ORDER_DATE IS NOT NULL                                                                                     ");
		sql.append("    AND (                                                                                                            ");
		sql.append("          (A.IN_OUT_GUBUN = 'O'                                                                                      ");
		sql.append("           AND A.FKOCS1003 NOT IN (SELECT X.FKOCS1003                                                                ");
		sql.append("                                     FROM CPL2010 X                                                                  ");
		sql.append("                                    WHERE X.HOSP_CODE = :f_hosp_code                                                 ");
		sql.append("                                      AND X.BUNHO     = :f_bunho                                                     ");
		sql.append("                                      AND X.IN_OUT_GUBUN = 'I'                                                       ");
		sql.append("                                      AND X.FKOCS1003 IS NOT NULL)                                                   ");
		sql.append("           ) OR (                                                                                                    ");
		sql.append("            A.IN_OUT_GUBUN <> 'O'                                                                                    ");
		sql.append("           )                                                                                                         ");
		sql.append("        )                                                                                                            ");
		sql.append("  ORDER BY A.ORDER_DATE DESC                                                                                         ");
				
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		List<CPL0000Q00LayOrderListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00LayOrderListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL0000Q00LayOrderListItemInfo> getCPL0000Q00LayOrderResultList(String hospCode, String language, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                                   ");
		sql.append("        A.RESULT_DATE                                                                                 RESULT_DATE  ");
		sql.append("      , IF(A.IN_OUT_GUBUN = 'O', A.GWA, FN_OCS_LOAD_ORDER_GWA(A.FKOCS2003,:f_hosp_code))              GWA          ");
		sql.append("      , IF(A.IN_OUT_GUBUN = 'O', A.DOCTOR, FN_OCS_LOAD_ORDER_DOCTOR(:f_hosp_code,A.FKOCS2003))        DOCTOR       ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                            GWA_NAME     ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)                                  DOCTOR_NAME  ");
		sql.append("      , A.IN_OUT_GUBUN                                                                                IN_OUT_GUBUN ");
		sql.append("   FROM CPL2010 A                                                                                                  ");
		sql.append("  WHERE A.HOSP_CODE  = :f_hosp_code                                                                                ");
		sql.append("    AND A.BUNHO      = :f_bunho                                                                                    ");
		sql.append("    AND A.RESULT_DATE IS NOT NULL                                                                                  ");
		sql.append("    AND (                                                                                                          ");
		sql.append("          (A.IN_OUT_GUBUN = 'O'                                                                                    ");
		sql.append("           AND A.FKOCS1003 NOT IN (SELECT X.FKOCS1003                                                              ");
		sql.append("                                     FROM CPL2010 X                                                                ");
		sql.append("                                    WHERE X.HOSP_CODE = :f_hosp_code                                               ");
		sql.append("                                      AND X.BUNHO     = :f_bunho                                                   ");
		sql.append("                                      AND X.IN_OUT_GUBUN = 'I'                                                     ");
		sql.append("                                      AND X.FKOCS1003 IS NOT NULL)                                                 ");
		sql.append("           ) OR (                                                                                                  ");
		sql.append("            A.IN_OUT_GUBUN <> 'O'                                                                                  ");
		sql.append("           )                                                                                                       ");
		sql.append("        )                                                                                                          ");
		sql.append("  ORDER BY A.RESULT_DATE DESC                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		List<CPL0000Q00LayOrderListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00LayOrderListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL0000Q00LayOrderListItemInfo> getCPL0000Q00LayOrderJubsuList(String hospCode, String language, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                                    ");
		sql.append("        A.PART_JUBSU_DATE                                                                          JUBSU_DATE       ");
		sql.append("      , IF(A.IN_OUT_GUBUN = 'O', A.GWA, FN_OCS_LOAD_ORDER_GWA(A.FKOCS2003,:f_hosp_code))           GWA              ");
		sql.append("      , IF(A.IN_OUT_GUBUN = 'O', A.DOCTOR, FN_OCS_LOAD_ORDER_DOCTOR(:f_hosp_code,A.FKOCS2003))     DOCTOR           ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                         GWA_NAME         ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)                               DOCTOR_NAME      ");
		sql.append("      , A.IN_OUT_GUBUN                                                                             IN_OUT_GUBUN     ");
		sql.append("   FROM CPL2010 A                                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                  ");
		sql.append("    AND A.BUNHO     = :f_bunho                                                                                      ");
		sql.append("    AND A.PART_JUBSU_DATE IS NOT NULL                                                                               ");
		sql.append("    AND (                                                                                                           ");
		sql.append("            (A.IN_OUT_GUBUN = 'O'                                                                                   ");
		sql.append("             AND A.FKOCS1003 NOT IN (SELECT X.FKOCS1003                                                             ");
		sql.append("                                       FROM CPL2010 X                                                               ");
		sql.append("                                      WHERE X.HOSP_CODE = :f_hosp_code                                              ");
		sql.append("                                        AND X.BUNHO     = :f_bunho                                                  ");
		sql.append("                                        AND X.IN_OUT_GUBUN = 'I'                                                    ");
		sql.append("                                        AND X.FKOCS1003 IS NOT NULL)                                                ");
		sql.append("             ) OR (                                                                                                 ");
		sql.append("              A.IN_OUT_GUBUN <> 'O'                                                                                 ");
		sql.append("             )                                                                                                      ");
		sql.append("          )                                                                                                         ");
		sql.append("  ORDER BY A.PART_JUBSU_DATE DESC                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		List<CPL0000Q00LayOrderListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00LayOrderListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL0000Q00GetSigeyulDataSelect1ListItemInfo> getCPL0000Q00FrmGraphGetSigeyul(String hospCode, String bunho, String baseDate, String userId, String conditionValue){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                      ");                 
		sql.append("        DATE_FORMAT(A.PART_JUBSU_DATE, '%Y/%m/%d')   JUBSU_DATE                                                                                      ");
		sql.append("      , SUBSTR(A.PART_JUBSU_TIME,1,3)                JUBSU_TIME                                                                                      ");
		sql.append("      , CONCAT(DATE_FORMAT(A.PART_JUBSU_DATE,'%y.%m.%d')                                                                                             ");
		sql.append("        ,'(',SUBSTR(A.PART_JUBSU_TIME,1,2),':',SUBSTR(A.PART_JUBSU_TIME,3,1),'0)')   JUBSU_TIME2                                                     ");
		sql.append("   FROM CPLTEMP C,                                                                                                                                   ");
		sql.append("        CPL3020 B,                                                                                                                                   ");
		sql.append("        CPL2010 A                                                                                                                                    ");
		sql.append("  WHERE A.HOSP_CODE     = :f_hosp_code                                                                                                               ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                                                                                                ");
		sql.append("    AND C.HOSP_CODE     = A.HOSP_CODE                                                                                                                ");
		sql.append("    AND A.BUNHO         = :f_bunho                                                                                                                   ");
		sql.append("    AND A.RESULT_DATE   IS NOT NULL                                                                                                                  ");
		if("0".equals(conditionValue)){
			sql.append(" ");
		} else if("1".equals(conditionValue)){
			sql.append("    AND CONCAT(DATE_FORMAT(A.PART_JUBSU_DATE,'%y.%m.%d'),'(',SUBSTR(A.PART_JUBSU_TIME,1,2),':'||SUBSTR(A.PART_JUBSU_TIME,3,1),'0)') < :f_base_date   ");
		} else if("2".equals(conditionValue)){
			sql.append("    AND CONCAT(DATE_FORMAT(A.PART_JUBSU_DATE,'%y.%m.%d'),'(',SUBSTR(A.PART_JUBSU_TIME,1,2),':'||SUBSTR(A.PART_JUBSU_TIME,3,1),'0)') > :f_base_date   ");
		} else {
			sql.append("    AND CONCAT(DATE_FORMAT(A.PART_JUBSU_DATE,'%y.%m.%d'),'(',SUBSTR(A.PART_JUBSU_TIME,1,2),':'||SUBSTR(A.PART_JUBSU_TIME,3,1),'0)') >= :f_base_date   ");
		} 
		sql.append("    AND B.SPECIMEN_SER  = A.SPECIMEN_SER                                                                                                             ");
		sql.append("    AND C.IP_ADDRESS    = :q_user_id                                                                                                                 ");
		sql.append("    AND C.JUNDAL_GUBUN  = 'XX'                                                                                                                       ");
		sql.append("    AND B.HANGMOG_CODE  = C.HANGMOG_CODE                                                                                                             ");
		sql.append("  ORDER BY 2,3                                                                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		if(!"0".equals(conditionValue)){
			query.setParameter("f_base_date", baseDate);
		}
		query.setParameter("q_user_id", userId);
		List<CPL0000Q00GetSigeyulDataSelect1ListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00GetSigeyulDataSelect1ListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL0000Q00LayResultListTempListItemInfo> getCPL0000Q00LayResultListTemp1(String hospCode, String language, String bunho, 
			String orderDate, String jundalGubun, String gwa, String doctor){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.JUNDAL_GUBUN                                                   SORT_A,                                                                                ");
		sql.append("             IF(A.JUNDAL_GUBUN='10',0,A.PKCPL2010)                        SORT_B,                                                                                ");
		sql.append("             IF(A.JUNDAL_GUBUN='10',0,B.PKCPL3020)                        SORT_C,                                                                                ");
		sql.append("             C.JANGBI_OUT_CODE                                                SORT_D,                                                                            ");
		sql.append("             B.FKCPL2010                                                      FKCPL2010,                                                                         ");
		sql.append("             B.HANGMOG_CODE                                                   HANGMOG_CODE,                                                                      ");
		sql.append("             B.SPECIMEN_CODE                                                  SPECIMEN_CODE,                                                                     ");
		sql.append("             E.CODE_NAME                                                      SPECIMEN_NAME,                                                                     ");
		sql.append("             CONCAT(IF(B.HANGMOG_CODE=B.SOURCE_GUMSA,'','  '),C.GUMSA_NAME)    GUMSA_NAME,                                                                       ");
		sql.append("             C.EMERGENCY                                                      EMERGENCY,                                                                         ");
		sql.append("             B.SOURCE_GUMSA                                                   SOURCE_GUMSA,                                                                      ");
		sql.append("             IF(B.CONFIRM_YN='Y',B.CPL_RESULT,'')                         CPL_RESULT,                                                                            ");
		sql.append("             B.RESULT_DATE                                                    RESULT_DATE,                                                                       ");
		sql.append("             IF(B.CONFIRM_YN='Y',B.RESULT_TIME,'')                        RESULT_TIME,                                                                           ");
		sql.append("             B.RESULT_FORM                                                    RESULT_FORM,                                                                       ");
		sql.append("             B.CONFIRM_DATE                                                   CONFIRM_DATE,                                                                      ");
		sql.append("             B.STANDARD_YN                                                    STANDARD_YN,                                                                       ");
		sql.append("             B.FROM_STANDARD                                                  FROM_STANDARD,                                                                     ");
		sql.append("             B.TO_STANDARD                                                    TO_STANDARD,                                                                       ");
		sql.append("             IF(B.TO_STANDARD IS NULL,B.FROM_STANDARD,CONCAT(B.FROM_STANDARD,' ~ ',B.TO_STANDARD))    STANDARD,                                                  ");
		sql.append("             B.PANIC_YN                                                       PANIC_YN,                                                                          ");
		sql.append("             B.DELTA_YN                                                       DELTA_YN,                                                                          ");
		sql.append("             B.BEFORE_RESULT                                                  BEFORE_RESULT,                                                                     ");
		sql.append("             C.DANUI                                                          DANUI,                                                                             ");
		sql.append("             D.CODE_NAME                                                      DANUI_NAME,                                                                        ");
		sql.append("             A.BUNHO                                                          BUNHO,                                                                             ");
		sql.append("             A.GWA                                                            GWA,                                                                               ");
		sql.append("             A.DOCTOR                                                         DOCTOR,                                                                            ");
		sql.append("             A.GUBUN                                                          GUBUN,                                                                             ");
		sql.append("             REPLACE(A.HO_DONG,'C','F')                                       HO_DONG,                                                                           ");
		sql.append("             A.HO_CODE                                                        HO_CODE,                                                                           ");
		sql.append("             A.JUNDAL_GUBUN                                                   JUNDAL_GUBUN,                                                                      ");
		sql.append("             A.SLIP_CODE                                                      SLIP_CODE,                                                                         ");
		sql.append("             A.SPECIMEN_SER                                                   SPECIMEN_SER,                                                                      ");
		sql.append("             A.ORDER_DATE                                                     ORDER_DATE,                                                                        ");
		sql.append("             A.ORDER_TIME                                                     ORDER_TIME,                                                                        ");
		sql.append("             A.JUBSU_DATE                                                     JUBSU_DATE,                                                                        ");
		sql.append("             A.JUBSU_TIME                                                     JUBSU_TIME,                                                                        ");
		sql.append("             A.PART_JUBSU_DATE                                                PART_JUBSU_DATE,                                                                   ");
		sql.append("             A.PART_JUBSU_TIME                                                PART_JUBSU_TIME,                                                                   ");
		sql.append("             IF(C.GROUP_GUBUN='01' OR C.GROUP_GUBUN='03','Y','N')                      MODIFY_YN,                                                                ");
		sql.append("             IF(B.HANGMOG_CODE=B.SOURCE_GUMSA,'Y','N')                    MODIFY_YN_1,                                                                           ");
		sql.append("             B.PKCPL3020                                                      PKCPL3020,                                                                         ");
		sql.append("             FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                        GWA_NAME,                                                 ");
		sql.append("             FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)                  DOCTOR_NAME,                                                          ");
		sql.append("             B.SOURCE_GUMSA                                                   GROUP_HANGMOG,                                                                     ");
		sql.append("             A.PART_JUBSUJA                                                   PART_JUBSUJA,                                                                      ");
		sql.append("             B.GUMSAJA                                                        GUMSAJA,                                                                           ");
		sql.append("             F.SUNAME                                                         SUNAME,                                                                            ");
		sql.append("             FN_BAS_LOAD_AGE(A.ORDER_DATE,F.BIRTH,NULL)                       AGE,                                                                               ");
		sql.append("             F.SEX                                                            SEX,                                                                               ");
		sql.append("             FN_CPL_LOAD_NOTE('2',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              FIX_NOTE,                                                             ");
		sql.append("             FN_CPL_LOAD_NOTE('1',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              NOTE,                                                                 ");
		sql.append("             IFNULL(B.JANGBI_CODE,'9')                                           JANGBI_CODE,                                                                    ");
		sql.append("             C.JANGBI_OUT_CODE                                                SRL_CODE,                                                                          ");
		sql.append("             FN_SCAN_IMAGE_YN(IFNULL(A.FKOCS2003,A.FKOCS1003),:f_hosp_code)                   IMAGE_YN,                                                          ");
		sql.append("             IFNULL(A.FKOCS2003,A.FKOCS1003)                                     FKOCS,                                                                          ");
		sql.append("             FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)                            JUNDAL_GUBUN_NAME,                                        ");
		sql.append("             FN_CPL_LOAD_COMMENT_YN(A.JUNDAL_GUBUN,A.SPECIMEN_SER,B.HANGMOG_CODE,B.SPECIMEN_CODE,B.EMERGENCY,:f_hosp_code)  COMMENTS_YN                          ");
		sql.append("        FROM OUT0101 F,                                                                                                                                          ");
		sql.append("             CPL0109 E RIGHT OUTER JOIN CPL3020 B ON E.HOSP_CODE = B.HOSP_CODE AND E.CODE = B.SPECIMEN_CODE AND E.CODE_TYPE = '04',                              ");
		sql.append("             CPL0109 D RIGHT OUTER JOIN CPL0101 C ON D.HOSP_CODE = C.HOSP_CODE AND D.CODE = C.DANUI AND D.CODE_TYPE = '03',                                      ");
		sql.append("             CPL2010 A                                                                                                                                           ");
		sql.append("       WHERE A.HOSP_CODE           = :f_hosp_code                                                                                                                ");
		sql.append("         AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                                 ");
		sql.append("         AND C.HOSP_CODE           = A.HOSP_CODE                                                                                                                 ");
		sql.append("         AND F.HOSP_CODE           = A.HOSP_CODE                                                                                                                 ");
		sql.append("         AND A.BUNHO               = :f_bunho                                                                                                                    ");
		sql.append("         AND A.ORDER_DATE          = STR_TO_DATE(:f_order_date,'%Y/%m/%d')                                                                                       ");
		sql.append("         AND B.FKCPL2010           = A.PKCPL2010                                                                                                                 ");
		sql.append("         AND IFNULL(B.DISPLAY_YN,'N') = 'Y'                                                                                                                      ");
		sql.append("         AND C.HANGMOG_CODE        = B.HANGMOG_CODE                                                                                                              ");
		sql.append("         AND C.SPECIMEN_CODE       = B.SPECIMEN_CODE                                                                                                             ");
		sql.append("         AND C.EMERGENCY           = B.EMERGENCY                                                                                                                 ");
		sql.append("         AND F.BUNHO               = A.BUNHO                                                                                                                     ");
		sql.append("         AND :f_jundal_gubun       <> 'ETC'                                                                                                                      ");
		sql.append("       UNION ALL                                                                                                                                                 ");
		sql.append("      SELECT A.JUNDAL_GUBUN                                                   SORT_A,                                                                            ");
		sql.append("             IF(A.JUNDAL_GUBUN = '10',0,A.PKCPL2010)                        SORT_B,                                                                              ");
		sql.append("             IF(A.JUNDAL_GUBUN = '10',0,B.PKCPL3020)                        SORT_C,                                                                              ");
		sql.append("             C.JANGBI_OUT_CODE                                                SORT_D,                                                                            ");
		sql.append("             B.FKCPL2010                                                      FKCPL2010,                                                                         ");
		sql.append("             B.HANGMOG_CODE                                                   HANGMOG_CODE,                                                                      ");
		sql.append("             B.SPECIMEN_CODE                                                  SPECIMEN_CODE,                                                                     ");
		sql.append("             E.CODE_NAME                                                      SPECIMEN_NAME,                                                                     ");
		sql.append("             CONCAT(IF(B.HANGMOG_CODE = B.SOURCE_GUMSA,'','  '),C.GUMSA_NAME)    GUMSA_NAME,                                                                     ");
		sql.append("             C.EMERGENCY                                                      EMERGENCY,                                                                         ");
		sql.append("             B.SOURCE_GUMSA                                                   SOURCE_GUMSA,                                                                      ");
		sql.append("             IF(B.CONFIRM_YN = 'Y',B.CPL_RESULT,'')                         CPL_RESULT,                                                                          ");
		sql.append("             B.RESULT_DATE                                                    RESULT_DATE,                                                                       ");
		sql.append("             IF(B.CONFIRM_YN = 'Y',B.RESULT_TIME,'')                        RESULT_TIME,                                                                         ");
		sql.append("             B.RESULT_FORM                                                    RESULT_FORM,                                                                       ");
		sql.append("             B.CONFIRM_DATE                                                   CONFIRM_DATE,                                                                      ");
		sql.append("             B.STANDARD_YN                                                    STANDARD_YN,                                                                       ");
		sql.append("             B.FROM_STANDARD                                                  FROM_STANDARD,                                                                     ");
		sql.append("             B.TO_STANDARD                                                    TO_STANDARD,                                                                       ");
		sql.append("             IF(B.TO_STANDARD IS NULL,B.FROM_STANDARD,CONCAT(B.FROM_STANDARD, ' ~ ' , B.TO_STANDARD))    STANDARD,                                               ");
		sql.append("             B.PANIC_YN                                                       PANIC_YN,                                                                          ");
		sql.append("             B.DELTA_YN                                                       DELTA_YN,                                                                          ");
		sql.append("             B.BEFORE_RESULT                                                  BEFORE_RESULT,                                                                     ");
		sql.append("             C.DANUI                                                          DANUI,                                                                             ");
		sql.append("             D.CODE_NAME                                                      DANUI_NAME,                                                                        ");
		sql.append("             A.BUNHO                                                          BUNHO,                                                                             ");
		sql.append("             A.GWA                                                            GWA,                                                                               ");
		sql.append("             A.DOCTOR                                                         DOCTOR,                                                                            ");
		sql.append("             A.GUBUN                                                          GUBUN,                                                                             ");
		sql.append("             A.HO_DONG                                                        HO_DONG,                                                                           ");
		sql.append("             A.HO_CODE                                                        HO_CODE,                                                                           ");
		sql.append("             A.JUNDAL_GUBUN                                                   JUNDAL_GUBUN,                                                                      ");
		sql.append("             A.SLIP_CODE                                                      SLIP_CODE,                                                                         ");
		sql.append("             A.SPECIMEN_SER                                                   SPECIMEN_SER,                                                                      ");
		sql.append("             A.ORDER_DATE                                                     ORDER_DATE,                                                                        ");
		sql.append("             A.ORDER_TIME                                                     ORDER_TIME,                                                                        ");
		sql.append("             A.JUBSU_DATE                                                     JUBSU_DATE,                                                                        ");
		sql.append("             A.JUBSU_TIME                                                     JUBSU_TIME,                                                                        ");
		sql.append("             A.PART_JUBSU_DATE                                                PART_JUBSU_DATE,                                                                   ");
		sql.append("             A.PART_JUBSU_TIME                                                PART_JUBSU_TIME,                                                                   ");
		sql.append("             IF(C.GROUP_GUBUN = '01' OR C.GROUP_GUBUN = '03','Y','N')                      MODIFY_YN,                                                            ");
		sql.append("             IF(B.HANGMOG_CODE = B.SOURCE_GUMSA,'Y','N')                    MODIFY_YN_1,                                                                         ");
		sql.append("             B.PKCPL3020                                                      PKCPL3020,                                                                         ");
		sql.append("             FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                        GWA_NAME,                                                 ");
		sql.append("             FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)                  DOCTOR_NAME,                                                          ");
		sql.append("             B.SOURCE_GUMSA                                                   GROUP_HANGMOG,                                                                     ");
		sql.append("             A.PART_JUBSUJA                                                   PART_JUBSUJA,                                                                      ");
		sql.append("             B.GUMSAJA                                                        GUMSAJA,                                                                           ");
		sql.append("             F.SUNAME                                                         SUNAME,                                                                            ");
		sql.append("             FN_BAS_LOAD_AGE(A.ORDER_DATE,F.BIRTH,NULL)                       AGE,                                                                               ");
		sql.append("             F.SEX                                                            SEX,                                                                               ");
		sql.append("             FN_CPL_LOAD_NOTE('2',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              FIX_NOTE,                                                             ");
		sql.append("             FN_CPL_LOAD_NOTE('1',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              NOTE,                                                                 ");
		sql.append("             IFNULL(B.JANGBI_CODE,'9')                                           JANGBI_CODE,                                                                    ");
		sql.append("             C.JANGBI_OUT_CODE                                                SRL_CODE,                                                                          ");
		sql.append("             FN_SCAN_IMAGE_YN(IFNULL(A.FKOCS2003,A.FKOCS1003),:f_hosp_code)                   IMAGE_YN,                                                          ");
		sql.append("             IFNULL(A.FKOCS2003,A.FKOCS1003)                                     FKOCS,                                                                          ");
		sql.append("             FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)                            JUNDAL_GUBUN_NAME,                                        ");
		sql.append("             FN_CPL_LOAD_COMMENT_YN(A.JUNDAL_GUBUN,A.SPECIMEN_SER,B.HANGMOG_CODE,B.SPECIMEN_CODE,B.EMERGENCY,:f_hosp_code)  COMMENTS_YN                          ");
		sql.append("        FROM OUT0101 F,                                                                                                                                          ");
		sql.append("             CPL0109 E RIGHT OUTER JOIN CPL3020 B ON E.HOSP_CODE = B.HOSP_CODE AND E.CODE = B.SPECIMEN_CODE AND E.CODE_TYPE = '04',                              ");
		sql.append("             CPL0109 D RIGHT OUTER JOIN CPL0101 C ON D.HOSP_CODE = C.HOSP_CODE AND D.CODE = C.DANUI AND D.CODE_TYPE = '03',                                      ");
		sql.append("             CPL2010 A                                                                                                                                           ");
		sql.append("       WHERE A.HOSP_CODE           = :f_hosp_code                                                                                                                ");
		sql.append("         AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                                 ");
		sql.append("         AND C.HOSP_CODE           = A.HOSP_CODE                                                                                                                 ");
		sql.append("         AND F.HOSP_CODE           = A.HOSP_CODE                                                                                                                 ");
		sql.append("         AND A.BUNHO               = :f_bunho                                                                                                                    ");
		sql.append("         AND A.ORDER_DATE          = STR_TO_DATE(:f_order_date,'%Y/%m/%d')                                                                                       ");
		sql.append("         AND FN_OCS_LOAD_ORDER_GWA(IF(A.IN_OUT_GUBUN='I',A.FKOCS2003,A.FKOCS1003),:f_hosp_code)        = :f_gwa                                                  ");
		sql.append("         AND FN_OCS_LOAD_ORDER_DOCTOR(:f_hosp_code,IF(A.IN_OUT_GUBUN='I',A.FKOCS2003,A.FKOCS1003))     = :f_doctor                                               ");
		sql.append("         AND A.JUNDAL_GUBUN       NOT IN ('01')                                                                                                                  ");
		sql.append("         AND B.FKCPL2010           = A.PKCPL2010                                                                                                                 ");
		sql.append("         AND IFNULL(B.DISPLAY_YN,'N') = 'Y'                                                                                                                      ");
		sql.append("         AND C.HANGMOG_CODE        = B.HANGMOG_CODE                                                                                                              ");
		sql.append("         AND C.SPECIMEN_CODE       = B.SPECIMEN_CODE                                                                                                             ");
		sql.append("         AND C.EMERGENCY           = B.EMERGENCY                                                                                                                 ");
		sql.append("         AND F.BUNHO               = A.BUNHO                                                                                                                     ");
		sql.append("         AND :f_jundal_gubun       = 'ETC'                                                                                                                       ");
		sql.append("       ORDER BY 1, 2, 3, 4                                                                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_jundal_gubun", jundalGubun);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		List<CPL0000Q00LayResultListTempListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00LayResultListTempListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL0000Q00LayResultListTempListItemInfo> getCPL0000Q00LayResultListTemp2(String hospCode, String language, String bunho,
			String resultDate, String jundalGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("      SELECT A.JUNDAL_GUBUN                                                   SORT_A,                                                                           ");
		sql.append("             IF(A.JUNDAL_GUBUN='10',0,A.PKCPL2010)                        SORT_B,                                                                               ");
		sql.append("             IF(A.JUNDAL_GUBUN='10',0,B.PKCPL3020)                        SORT_C,                                                                               ");
		sql.append("             C.JANGBI_OUT_CODE                                                SORT_D,                                                                           ");
		sql.append("             B.FKCPL2010                                                      FKCPL2010,                                                                        ");
		sql.append("             B.HANGMOG_CODE                                                   HANGMOG_CODE,                                                                     ");
		sql.append("             B.SPECIMEN_CODE                                                  SPECIMEN_CODE,                                                                    ");
		sql.append("             E.CODE_NAME                                                      SPECIMEN_NAME,                                                                    ");
		sql.append("             CONCAT(IF(B.HANGMOG_CODE=B.SOURCE_GUMSA,'','  '),C.GUMSA_NAME)    GUMSA_NAME,                                                                      ");
		sql.append("             C.EMERGENCY                                                      EMERGENCY,                                                                        ");
		sql.append("             B.SOURCE_GUMSA                                                   SOURCE_GUMSA,                                                                     ");
		sql.append("             IF(B.CONFIRM_YN='Y',B.CPL_RESULT,'')                         CPL_RESULT,                                                                           ");
		sql.append("             B.RESULT_DATE                                                    RESULT_DATE,                                                                      ");
		sql.append("             IF(B.CONFIRM_YN='Y',B.RESULT_TIME,'')                        RESULT_TIME,                                                                          ");
		sql.append("             B.RESULT_FORM                                                    RESULT_FORM,                                                                      ");
		sql.append("             B.CONFIRM_DATE                                                   CONFIRM_DATE,                                                                     ");
		sql.append("             B.STANDARD_YN                                                    STANDARD_YN,                                                                      ");
		sql.append("             B.FROM_STANDARD                                                  FROM_STANDARD,                                                                    ");
		sql.append("             B.TO_STANDARD                                                    TO_STANDARD,                                                                      ");
		sql.append("             IF(B.TO_STANDARD IS NULL,B.FROM_STANDARD,CONCAT(B.FROM_STANDARD,' ~ ',B.TO_STANDARD))    STANDARD,                                                 ");
		sql.append("             B.PANIC_YN                                                       PANIC_YN,                                                                         ");
		sql.append("             B.DELTA_YN                                                       DELTA_YN,                                                                         ");
		sql.append("             B.BEFORE_RESULT                                                  BEFORE_RESULT,                                                                    ");
		sql.append("             C.DANUI                                                          DANUI,                                                                            ");
		sql.append("             D.CODE_NAME                                                      DANUI_NAME,                                                                       ");
		sql.append("             A.BUNHO                                                          BUNHO,                                                                            ");
		sql.append("             A.GWA                                                            GWA,                                                                              ");
		sql.append("             A.DOCTOR                                                         DOCTOR,                                                                           ");
		sql.append("             A.GUBUN                                                          GUBUN,                                                                            ");
		sql.append("             A.HO_DONG                                                        HO_DONG,                                                                          ");
		sql.append("             A.HO_CODE                                                        HO_CODE,                                                                          ");
		sql.append("             A.JUNDAL_GUBUN                                                   JUNDAL_GUBUN,                                                                     ");
		sql.append("             A.SLIP_CODE                                                      SLIP_CODE,                                                                        ");
		sql.append("             A.SPECIMEN_SER                                                   SPECIMEN_SER,                                                                     ");
		sql.append("             A.ORDER_DATE                                                     ORDER_DATE,                                                                       ");
		sql.append("             A.ORDER_TIME                                                     ORDER_TIME,                                                                       ");
		sql.append("             A.JUBSU_DATE                                                     JUBSU_DATE,                                                                       ");
		sql.append("             A.JUBSU_TIME                                                     JUBSU_TIME,                                                                       ");
		sql.append("             A.PART_JUBSU_DATE                                                PART_JUBSU_DATE,                                                                  ");
		sql.append("             A.PART_JUBSU_TIME                                                PART_JUBSU_TIME,                                                                  ");
		sql.append("             IF(C.GROUP_GUBUN='01' OR C.GROUP_GUBUN='03','Y','N')                      MODIFY_YN,                                                               ");
		sql.append("             IF(B.HANGMOG_CODE=B.SOURCE_GUMSA,'Y','N')                    MODIFY_YN_1,                                                                          ");
		sql.append("             B.PKCPL3020                                                      PKCPL3020,                                                                        ");
		sql.append("             FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                        GWA_NAME,                                                ");
		sql.append("             FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)                  DOCTOR_NAME,                                                         ");
		sql.append("             B.SOURCE_GUMSA                                                   GROUP_HANGMOG,                                                                    ");
		sql.append("             A.PART_JUBSUJA                                                   PART_JUBSUJA,                                                                     ");
		sql.append("             B.GUMSAJA                                                        GUMSAJA,                                                                          ");
		sql.append("             F.SUNAME                                                         SUNAME,                                                                           ");
		sql.append("             FN_BAS_LOAD_AGE(A.ORDER_DATE,F.BIRTH,NULL)                       AGE,                                                                              ");
		sql.append("             F.SEX                                                            SEX,                                                                              ");
		sql.append("             FN_CPL_LOAD_NOTE('2',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              FIX_NOTE,                                                            ");
		sql.append("             FN_CPL_LOAD_NOTE('1',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              NOTE,                                                                ");
		sql.append("             IFNULL(B.JANGBI_CODE,'9')                                           JANGBI_CODE,                                                                   ");
		sql.append("             C.JANGBI_OUT_CODE                                                SRL_CODE,                                                                         ");
		sql.append("             FN_SCAN_IMAGE_YN(IFNULL(A.FKOCS2003,A.FKOCS1003),:f_hosp_code)                   IMAGE_YN,                                                         ");
		sql.append("             IFNULL(A.FKOCS2003,A.FKOCS1003)                                     FKOCS,                                                                         ");
		sql.append("             FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)                            JUNDAL_GUBUN_NAME,                                       ");
		sql.append("             FN_CPL_LOAD_COMMENT_YN(A.JUNDAL_GUBUN,A.SPECIMEN_SER,B.HANGMOG_CODE,B.SPECIMEN_CODE,B.EMERGENCY,:f_hosp_code)  COMMENTS_YN                         ");
		sql.append("        FROM OUT0101 F,                                                                                                                                         ");
		sql.append("             CPL0109 E RIGHT OUTER JOIN CPL3020 B ON E.HOSP_CODE = B.HOSP_CODE AND E.CODE = B.SPECIMEN_CODE AND E.CODE_TYPE = '04',                             ");
		sql.append("             CPL0109 D RIGHT OUTER JOIN CPL0101 C ON D.HOSP_CODE = C.HOSP_CODE AND D.CODE = C.DANUI AND D.CODE_TYPE = '03',                                     ");
		sql.append("             CPL2010 A                                                                                                                                          ");
		sql.append("       WHERE A.HOSP_CODE           = :f_hosp_code                                                                                                               ");
		sql.append("         AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                                ");
		sql.append("         AND C.HOSP_CODE           = A.HOSP_CODE                                                                                                                ");
		sql.append("         AND F.HOSP_CODE           = A.HOSP_CODE                                                                                                                ");
		sql.append("         AND A.BUNHO               = :f_bunho                                                                                                                   ");
		sql.append("         AND ( B.RESULT_DATE       = STR_TO_DATE(:f_result_date,'%Y/%m/%d')                                                                                     ");
		sql.append("            OR A.RESULT_DATE       = STR_TO_DATE(:f_result_date,'%Y/%m/%d'))                                                                                    ");
		sql.append("         AND A.JUNDAL_GUBUN        LIKE :f_jundal_gubun                                                                                                         ");
		sql.append("         AND B.FKCPL2010           = A.PKCPL2010                                                                                                                ");
		sql.append("         AND IFNULL(B.DISPLAY_YN,'N') = 'Y'                                                                                                                     ");
		sql.append("         AND C.HANGMOG_CODE        = B.HANGMOG_CODE                                                                                                             ");
		sql.append("         AND C.SPECIMEN_CODE       = B.SPECIMEN_CODE                                                                                                            ");
		sql.append("         AND C.EMERGENCY           = B.EMERGENCY                                                                                                                ");
		sql.append("         AND F.BUNHO               = A.BUNHO                                                                                                                    ");
		sql.append("         AND :f_jundal_gubun       <> 'ETC'                                                                                                                     ");
		sql.append("       UNION ALL                                                                                                                                                ");
		sql.append("      SELECT A.JUNDAL_GUBUN                                                   SORT_A,                                                                           ");
		sql.append("             IF(A.JUNDAL_GUBUN = '10',0,A.PKCPL2010)                        SORT_B,                                                                             ");
		sql.append("             IF(A.JUNDAL_GUBUN = '10',0,B.PKCPL3020)                        SORT_C,                                                                             ");
		sql.append("             C.JANGBI_OUT_CODE                                                SORT_D,                                                                           ");
		sql.append("             B.FKCPL2010                                                      FKCPL2010,                                                                        ");
		sql.append("             B.HANGMOG_CODE                                                   HANGMOG_CODE,                                                                     ");
		sql.append("             B.SPECIMEN_CODE                                                  SPECIMEN_CODE,                                                                    ");
		sql.append("             E.CODE_NAME                                                      SPECIMEN_NAME,                                                                    ");
		sql.append("             CONCAT(IF(B.HANGMOG_CODE = B.SOURCE_GUMSA,'','  '),C.GUMSA_NAME)    GUMSA_NAME,                                                                    ");
		sql.append("             C.EMERGENCY                                                      EMERGENCY,                                                                        ");
		sql.append("             B.SOURCE_GUMSA                                                   SOURCE_GUMSA,                                                                     ");
		sql.append("             IF(B.CONFIRM_YN = 'Y',B.CPL_RESULT,'')                         CPL_RESULT,                                                                         ");
		sql.append("             B.RESULT_DATE                                                    RESULT_DATE,                                                                      ");
		sql.append("             IF(B.CONFIRM_YN = 'Y',B.RESULT_TIME,'')                        RESULT_TIME,                                                                        ");
		sql.append("             B.RESULT_FORM                                                    RESULT_FORM,                                                                      ");
		sql.append("             B.CONFIRM_DATE                                                   CONFIRM_DATE,                                                                     ");
		sql.append("             B.STANDARD_YN                                                    STANDARD_YN,                                                                      ");
		sql.append("             B.FROM_STANDARD                                                  FROM_STANDARD,                                                                    ");
		sql.append("             B.TO_STANDARD                                                    TO_STANDARD,                                                                      ");
		sql.append("             IF(B.TO_STANDARD IS NULL,B.FROM_STANDARD,CONCAT(B.FROM_STANDARD, ' ~ ' , B.TO_STANDARD))    STANDARD,                                              ");
		sql.append("             B.PANIC_YN                                                       PANIC_YN,                                                                         ");
		sql.append("             B.DELTA_YN                                                       DELTA_YN,                                                                         ");
		sql.append("             B.BEFORE_RESULT                                                  BEFORE_RESULT,                                                                    ");
		sql.append("             C.DANUI                                                          DANUI,                                                                            ");
		sql.append("             D.CODE_NAME                                                      DANUI_NAME,                                                                       ");
		sql.append("             A.BUNHO                                                          BUNHO,                                                                            ");
		sql.append("             A.GWA                                                            GWA,                                                                              ");
		sql.append("             A.DOCTOR                                                         DOCTOR,                                                                           ");
		sql.append("             A.GUBUN                                                          GUBUN,                                                                            ");
		sql.append("             A.HO_DONG                                                        HO_DONG,                                                                          ");
		sql.append("             A.HO_CODE                                                        HO_CODE,                                                                          ");
		sql.append("             A.JUNDAL_GUBUN                                                   JUNDAL_GUBUN,                                                                     ");
		sql.append("             A.SLIP_CODE                                                      SLIP_CODE,                                                                        ");
		sql.append("             A.SPECIMEN_SER                                                   SPECIMEN_SER,                                                                     ");
		sql.append("             A.ORDER_DATE                                                     ORDER_DATE,                                                                       ");
		sql.append("             A.ORDER_TIME                                                     ORDER_TIME,                                                                       ");
		sql.append("             A.JUBSU_DATE                                                     JUBSU_DATE,                                                                       ");
		sql.append("             A.JUBSU_TIME                                                     JUBSU_TIME,                                                                       ");
		sql.append("             A.PART_JUBSU_DATE                                                PART_JUBSU_DATE,                                                                  ");
		sql.append("             A.PART_JUBSU_TIME                                                PART_JUBSU_TIME,                                                                  ");
		sql.append("             IF(C.GROUP_GUBUN = '01' OR C.GROUP_GUBUN = '03','Y','N')                      MODIFY_YN,                                                           ");
		sql.append("             IF(B.HANGMOG_CODE = B.SOURCE_GUMSA,'Y','N')                    MODIFY_YN_1,                                                                        ");
		sql.append("             B.PKCPL3020                                                      PKCPL3020,                                                                        ");
		sql.append("             FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                        GWA_NAME,                                                ");
		sql.append("             FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)                  DOCTOR_NAME,                                                         ");
		sql.append("             B.SOURCE_GUMSA                                                   GROUP_HANGMOG,                                                                    ");
		sql.append("             A.PART_JUBSUJA                                                   PART_JUBSUJA,                                                                     ");
		sql.append("             B.GUMSAJA                                                        GUMSAJA,                                                                          ");
		sql.append("             F.SUNAME                                                         SUNAME,                                                                           ");
		sql.append("             FN_BAS_LOAD_AGE(A.ORDER_DATE,F.BIRTH,NULL)                       AGE,                                                                              ");
		sql.append("             F.SEX                                                            SEX,                                                                              ");
		sql.append("             FN_CPL_LOAD_NOTE('2',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              FIX_NOTE,                                                            ");
		sql.append("             FN_CPL_LOAD_NOTE('1',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              NOTE,                                                                ");
		sql.append("             IFNULL(B.JANGBI_CODE,'9')                                           JANGBI_CODE,                                                                   ");
		sql.append("             C.JANGBI_OUT_CODE                                                SRL_CODE,                                                                         ");
		sql.append("             FN_SCAN_IMAGE_YN(IFNULL(A.FKOCS2003,A.FKOCS1003),:f_hosp_code)                   IMAGE_YN,                                                         ");
		sql.append("             IFNULL(A.FKOCS2003,A.FKOCS1003)                                     FKOCS,                                                                         ");
		sql.append("             FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)                            JUNDAL_GUBUN_NAME,                                       ");
		sql.append("             FN_CPL_LOAD_COMMENT_YN(A.JUNDAL_GUBUN,A.SPECIMEN_SER,B.HANGMOG_CODE,B.SPECIMEN_CODE,B.EMERGENCY,:f_hosp_code)  COMMENTS_YN                         ");
		sql.append("        FROM OUT0101 F,                                                                                                                                         ");
		sql.append("             CPL0109 E RIGHT OUTER JOIN CPL3020 B ON E.HOSP_CODE = B.HOSP_CODE AND E.CODE = B.SPECIMEN_CODE AND E.CODE_TYPE = '04',                             ");
		sql.append("             CPL0109 D RIGHT OUTER JOIN CPL0101 C ON D.HOSP_CODE = C.HOSP_CODE AND D.CODE = C.DANUI AND D.CODE_TYPE = '03',                                     ");
		sql.append("             CPL2010 A                                                                                                                                          ");
		sql.append("       WHERE A.HOSP_CODE           = :f_hosp_code                                                                                                               ");
		sql.append("         AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                                ");
		sql.append("         AND C.HOSP_CODE           = A.HOSP_CODE                                                                                                                ");
		sql.append("         AND F.HOSP_CODE           = A.HOSP_CODE                                                                                                                ");
		sql.append("         AND A.BUNHO               = :f_bunho                                                                                                                   ");
		sql.append("         AND ( B.RESULT_DATE       = STR_TO_DATE(:f_result_date,'%Y/%m/%d')                                                                                     ");
		sql.append("            OR A.RESULT_DATE       = STR_TO_DATE(:f_result_date,'%Y/%m/%d'))                                                                                    ");
		sql.append("         AND A.JUNDAL_GUBUN       NOT IN ('01')                                                                                                                 ");
		sql.append("         AND B.FKCPL2010           = A.PKCPL2010                                                                                                                ");
		sql.append("         AND IFNULL(B.DISPLAY_YN,'N') = 'Y'                                                                                                                     ");
		sql.append("         AND C.HANGMOG_CODE        = B.HANGMOG_CODE                                                                                                             ");
		sql.append("         AND C.SPECIMEN_CODE       = B.SPECIMEN_CODE                                                                                                            ");
		sql.append("         AND C.EMERGENCY           = B.EMERGENCY                                                                                                                ");
		sql.append("         AND F.BUNHO               = A.BUNHO                                                                                                                    ");
		sql.append("         AND :f_jundal_gubun       = 'ETC'                                                                                                                      ");
		sql.append("       ORDER BY 1, 2, 3, 4                                                                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_result_date", resultDate);
		query.setParameter("f_jundal_gubun", jundalGubun);
		List<CPL0000Q00LayResultListTempListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00LayResultListTempListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL0000Q00LayResultListTempListItemInfo> getCPL0000Q00LayResultListTemp3(String hospCode, String language, String bunho,
			String jubsuDate, String jundalGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT A.JUNDAL_GUBUN                                                   SORT_A,                                                                        ");
		sql.append("           IF(A.JUNDAL_GUBUN='10',0,A.PKCPL2010)                        SORT_B,                                                                            ");
		sql.append("           IF(A.JUNDAL_GUBUN='10',0,B.PKCPL3020)                        SORT_C,                                                                            ");
		sql.append("           C.JANGBI_OUT_CODE                                                SORT_D,                                                                        ");
		sql.append("           B.FKCPL2010                                                      FKCPL2010,                                                                     ");
		sql.append("           B.HANGMOG_CODE                                                   HANGMOG_CODE,                                                                  ");
		sql.append("           B.SPECIMEN_CODE                                                  SPECIMEN_CODE,                                                                 ");
		sql.append("           E.CODE_NAME                                                      SPECIMEN_NAME,                                                                 ");
		sql.append("           CONCAT(IF(B.HANGMOG_CODE=B.SOURCE_GUMSA,'','  '),C.GUMSA_NAME)    GUMSA_NAME,                                                                   ");
		sql.append("           C.EMERGENCY                                                      EMERGENCY,                                                                     ");
		sql.append("           B.SOURCE_GUMSA                                                   SOURCE_GUMSA,                                                                  ");
		sql.append("           IF(B.CONFIRM_YN='Y',B.CPL_RESULT,'')                         CPL_RESULT,                                                                        ");
		sql.append("           B.RESULT_DATE                                                    RESULT_DATE,                                                                   ");
		sql.append("           IF(B.CONFIRM_YN='Y',B.RESULT_TIME,'')                        RESULT_TIME,                                                                       ");
		sql.append("           B.RESULT_FORM                                                    RESULT_FORM,                                                                   ");
		sql.append("           B.CONFIRM_DATE                                                   CONFIRM_DATE,                                                                  ");
		sql.append("           B.STANDARD_YN                                                    STANDARD_YN,                                                                   ");
		sql.append("           B.FROM_STANDARD                                                  FROM_STANDARD,                                                                 ");
		sql.append("           B.TO_STANDARD                                                    TO_STANDARD,                                                                   ");
		sql.append("           IF(B.TO_STANDARD IS NULL,B.FROM_STANDARD,CONCAT(B.FROM_STANDARD,' ~ ',B.TO_STANDARD))    STANDARD,                                              ");
		sql.append("           B.PANIC_YN                                                       PANIC_YN,                                                                      ");
		sql.append("           B.DELTA_YN                                                       DELTA_YN,                                                                      ");
		sql.append("           B.BEFORE_RESULT                                                  BEFORE_RESULT,                                                                 ");
		sql.append("           C.DANUI                                                          DANUI,                                                                         ");
		sql.append("           D.CODE_NAME                                                      DANUI_NAME,                                                                    ");
		sql.append("           A.BUNHO                                                          BUNHO,                                                                         ");
		sql.append("           A.GWA                                                            GWA,                                                                           ");
		sql.append("           A.DOCTOR                                                         DOCTOR,                                                                        ");
		sql.append("           A.GUBUN                                                          GUBUN,                                                                         ");
		sql.append("           A.HO_DONG                                                        HO_DONG,                                                                       ");
		sql.append("           A.HO_CODE                                                        HO_CODE,                                                                       ");
		sql.append("           A.JUNDAL_GUBUN                                                   JUNDAL_GUBUN,                                                                  ");
		sql.append("           A.SLIP_CODE                                                      SLIP_CODE,                                                                     ");
		sql.append("           A.SPECIMEN_SER                                                   SPECIMEN_SER,                                                                  ");
		sql.append("           A.ORDER_DATE                                                     ORDER_DATE,                                                                    ");
		sql.append("           A.ORDER_TIME                                                     ORDER_TIME,                                                                    ");
		sql.append("           A.JUBSU_DATE                                                     JUBSU_DATE,                                                                    ");
		sql.append("           A.JUBSU_TIME                                                     JUBSU_TIME,                                                                    ");
		sql.append("           A.PART_JUBSU_DATE                                                PART_JUBSU_DATE,                                                               ");
		sql.append("           A.PART_JUBSU_TIME                                                PART_JUBSU_TIME,                                                               ");
		sql.append("           IF(C.GROUP_GUBUN='01' OR C.GROUP_GUBUN='03','Y','N')                      MODIFY_YN,                                                            ");
		sql.append("           IF(B.HANGMOG_CODE=B.SOURCE_GUMSA,'Y','N')                    MODIFY_YN_1,                                                                       ");
		sql.append("           B.PKCPL3020                                                      PKCPL3020,                                                                     ");
		sql.append("           FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                        GWA_NAME,                                             ");
		sql.append("           FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)                  DOCTOR_NAME,                                                      ");
		sql.append("           B.SOURCE_GUMSA                                                   GROUP_HANGMOG,                                                                 ");
		sql.append("           A.PART_JUBSUJA                                                   PART_JUBSUJA,                                                                  ");
		sql.append("           B.GUMSAJA                                                        GUMSAJA,                                                                       ");
		sql.append("           F.SUNAME                                                         SUNAME,                                                                        ");
		sql.append("           FN_BAS_LOAD_AGE(A.ORDER_DATE,F.BIRTH,NULL)                       AGE,                                                                           ");
		sql.append("           F.SEX                                                            SEX,                                                                           ");
		sql.append("           FN_CPL_LOAD_NOTE('2',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              FIX_NOTE,                                                         ");
		sql.append("           FN_CPL_LOAD_NOTE('1',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              NOTE,                                                             ");
		sql.append("           IFNULL(B.JANGBI_CODE,'9')                                           JANGBI_CODE,                                                                ");
		sql.append("           C.JANGBI_OUT_CODE                                                SRL_CODE,                                                                      ");
		sql.append("           FN_SCAN_IMAGE_YN(IFNULL(A.FKOCS2003,A.FKOCS1003),:f_hosp_code)                   IMAGE_YN,                                                      ");
		sql.append("           IFNULL(A.FKOCS2003,A.FKOCS1003)                                     FKOCS,                                                                      ");
		sql.append("           FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)                            JUNDAL_GUBUN_NAME,                                    ");
		sql.append("           FN_CPL_LOAD_COMMENT_YN(A.JUNDAL_GUBUN,A.SPECIMEN_SER,B.HANGMOG_CODE,B.SPECIMEN_CODE,B.EMERGENCY,:f_hosp_code)  COMMENTS_YN                      ");
		sql.append("      FROM OUT0101 F,                                                                                                                                      ");
		sql.append("           CPL0109 E RIGHT OUTER JOIN CPL3020 B ON E.HOSP_CODE = B.HOSP_CODE AND E.CODE = B.SPECIMEN_CODE AND E.CODE_TYPE = '04',                          ");
		sql.append("           CPL0109 D RIGHT OUTER JOIN CPL0101 C ON D.HOSP_CODE = C.HOSP_CODE AND D.CODE = C.DANUI AND D.CODE_TYPE = '03',                                  ");
		sql.append("           CPL2010 A                                                                                                                                       ");
		sql.append("     WHERE A.HOSP_CODE           = :f_hosp_code                                                                                                            ");
		sql.append("       AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                             ");
		sql.append("       AND C.HOSP_CODE           = A.HOSP_CODE                                                                                                             ");
		sql.append("       AND F.HOSP_CODE           = A.HOSP_CODE                                                                                                             ");
		sql.append("       AND A.BUNHO               = :f_bunho                                                                                                                ");
		sql.append("       AND DATE_FORMAT(A.PART_JUBSU_DATE,'%Y/%m/%d')     = :f_jubsu_date                                                                                  ");
		sql.append("       AND A.JUNDAL_GUBUN        LIKE :f_jundal_gubun                                                                                                      ");
		sql.append("       AND B.FKCPL2010           = A.PKCPL2010                                                                                                             ");
		sql.append("       AND IFNULL(B.DISPLAY_YN,'N') = 'Y'                                                                                                                  ");
		sql.append("       AND C.HANGMOG_CODE        = B.HANGMOG_CODE                                                                                                          ");
		sql.append("       AND C.SPECIMEN_CODE       = B.SPECIMEN_CODE                                                                                                         ");
		sql.append("       AND C.EMERGENCY           = B.EMERGENCY                                                                                                             ");
		sql.append("       AND F.BUNHO               = A.BUNHO                                                                                                                 ");
		sql.append("       AND :f_jundal_gubun       <> 'ETC'                                                                                                                  ");
		sql.append("     UNION ALL                                                                                                                                             ");
		sql.append("    SELECT A.JUNDAL_GUBUN                                                   SORT_A,                                                                        ");
		sql.append("           IF(A.JUNDAL_GUBUN = '10',0,A.PKCPL2010)                        SORT_B,                                                                          ");
		sql.append("           IF(A.JUNDAL_GUBUN = '10',0,B.PKCPL3020)                        SORT_C,                                                                          ");
		sql.append("           C.JANGBI_OUT_CODE                                                SORT_D,                                                                        ");
		sql.append("           B.FKCPL2010                                                      FKCPL2010,                                                                     ");
		sql.append("           B.HANGMOG_CODE                                                   HANGMOG_CODE,                                                                  ");
		sql.append("           B.SPECIMEN_CODE                                                  SPECIMEN_CODE,                                                                 ");
		sql.append("           E.CODE_NAME                                                      SPECIMEN_NAME,                                                                 ");
		sql.append("           CONCAT(IF(B.HANGMOG_CODE = B.SOURCE_GUMSA,'','  '),C.GUMSA_NAME)    GUMSA_NAME,                                                                 ");
		sql.append("           C.EMERGENCY                                                      EMERGENCY,                                                                     ");
		sql.append("           B.SOURCE_GUMSA                                                   SOURCE_GUMSA,                                                                  ");
		sql.append("           IF(B.CONFIRM_YN = 'Y',B.CPL_RESULT,'')                         CPL_RESULT,                                                                      ");
		sql.append("           B.RESULT_DATE                                                    RESULT_DATE,                                                                   ");
		sql.append("           IF(B.CONFIRM_YN = 'Y',B.RESULT_TIME,'')                        RESULT_TIME,                                                                     ");
		sql.append("           B.RESULT_FORM                                                    RESULT_FORM,                                                                   ");
		sql.append("           B.CONFIRM_DATE                                                   CONFIRM_DATE,                                                                  ");
		sql.append("           B.STANDARD_YN                                                    STANDARD_YN,                                                                   ");
		sql.append("           B.FROM_STANDARD                                                  FROM_STANDARD,                                                                 ");
		sql.append("           B.TO_STANDARD                                                    TO_STANDARD,                                                                   ");
		sql.append("           IF(B.TO_STANDARD IS NULL,B.FROM_STANDARD,CONCAT(B.FROM_STANDARD, ' ~ ' , B.TO_STANDARD))    STANDARD,                                           ");
		sql.append("           B.PANIC_YN                                                       PANIC_YN,                                                                      ");
		sql.append("           B.DELTA_YN                                                       DELTA_YN,                                                                      ");
		sql.append("           B.BEFORE_RESULT                                                  BEFORE_RESULT,                                                                 ");
		sql.append("           C.DANUI                                                          DANUI,                                                                         ");
		sql.append("           D.CODE_NAME                                                      DANUI_NAME,                                                                    ");
		sql.append("           A.BUNHO                                                          BUNHO,                                                                         ");
		sql.append("           A.GWA                                                            GWA,                                                                           ");
		sql.append("           A.DOCTOR                                                         DOCTOR,                                                                        ");
		sql.append("           A.GUBUN                                                          GUBUN,                                                                         ");
		sql.append("           A.HO_DONG                                                        HO_DONG,                                                                       ");
		sql.append("           A.HO_CODE                                                        HO_CODE,                                                                       ");
		sql.append("           A.JUNDAL_GUBUN                                                   JUNDAL_GUBUN,                                                                  ");
		sql.append("           A.SLIP_CODE                                                      SLIP_CODE,                                                                     ");
		sql.append("           A.SPECIMEN_SER                                                   SPECIMEN_SER,                                                                  ");
		sql.append("           A.ORDER_DATE                                                     ORDER_DATE,                                                                    ");
		sql.append("           A.ORDER_TIME                                                     ORDER_TIME,                                                                    ");
		sql.append("           A.JUBSU_DATE                                                     JUBSU_DATE,                                                                    ");
		sql.append("           A.JUBSU_TIME                                                     JUBSU_TIME,                                                                    ");
		sql.append("           A.PART_JUBSU_DATE                                                PART_JUBSU_DATE,                                                               ");
		sql.append("           A.PART_JUBSU_TIME                                                PART_JUBSU_TIME,                                                               ");
		sql.append("           IF(C.GROUP_GUBUN = '01' OR C.GROUP_GUBUN = '03','Y','N')                      MODIFY_YN,                                                        ");
		sql.append("           IF(B.HANGMOG_CODE = B.SOURCE_GUMSA,'Y','N')                    MODIFY_YN_1,                                                                     ");
		sql.append("           B.PKCPL3020                                                      PKCPL3020,                                                                     ");
		sql.append("           FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                        GWA_NAME,                                             ");
		sql.append("           FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)                  DOCTOR_NAME,                                                      ");
		sql.append("           B.SOURCE_GUMSA                                                   GROUP_HANGMOG,                                                                 ");
		sql.append("           A.PART_JUBSUJA                                                   PART_JUBSUJA,                                                                  ");
		sql.append("           B.GUMSAJA                                                        GUMSAJA,                                                                       ");
		sql.append("           F.SUNAME                                                         SUNAME,                                                                        ");
		sql.append("           FN_BAS_LOAD_AGE(A.ORDER_DATE,F.BIRTH,NULL)                       AGE,                                                                           ");
		sql.append("           F.SEX                                                            SEX,                                                                           ");
		sql.append("           FN_CPL_LOAD_NOTE('2',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              FIX_NOTE,                                                         ");
		sql.append("           FN_CPL_LOAD_NOTE('1',A.JUNDAL_GUBUN,A.SPECIMEN_SER,:f_hosp_code)              NOTE,                                                             ");
		sql.append("           IFNULL(B.JANGBI_CODE,'9')                                           JANGBI_CODE,                                                                ");
		sql.append("           C.JANGBI_OUT_CODE                                                SRL_CODE,                                                                      ");
		sql.append("           FN_SCAN_IMAGE_YN(IFNULL(A.FKOCS2003,A.FKOCS1003),:f_hosp_code)                   IMAGE_YN,                                                      ");
		sql.append("           IFNULL(A.FKOCS2003,A.FKOCS1003)                                     FKOCS,                                                                      ");
		sql.append("           FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN,:f_hosp_code,:f_language)                            JUNDAL_GUBUN_NAME,                                    ");
		sql.append("           FN_CPL_LOAD_COMMENT_YN(A.JUNDAL_GUBUN,A.SPECIMEN_SER,B.HANGMOG_CODE,B.SPECIMEN_CODE,B.EMERGENCY,:f_hosp_code)  COMMENTS_YN                      ");
		sql.append("      FROM OUT0101 F,                                                                                                                                      ");
		sql.append("           CPL0109 E RIGHT OUTER JOIN CPL3020 B ON E.HOSP_CODE = B.HOSP_CODE AND E.CODE = B.SPECIMEN_CODE AND E.CODE_TYPE = '04',                          ");
		sql.append("           CPL0109 D RIGHT OUTER JOIN CPL0101 C ON D.HOSP_CODE = C.HOSP_CODE AND D.CODE = C.DANUI AND D.CODE_TYPE = '03',                                  ");
		sql.append("           CPL2010 A                                                                                                                                       ");
		sql.append("     WHERE A.HOSP_CODE           = :f_hosp_code                                                                                                            ");
		sql.append("       AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                             ");
		sql.append("       AND C.HOSP_CODE           = A.HOSP_CODE                                                                                                             ");
		sql.append("       AND F.HOSP_CODE           = A.HOSP_CODE                                                                                                             ");
		sql.append("       AND A.BUNHO               = :f_bunho                                                                                                                ");
		sql.append("       AND DATE_FORMAT(A.PART_JUBSU_DATE,'%Y/%m/%d')     = :f_jubsu_date                                                                                   ");
		sql.append("       AND A.JUNDAL_GUBUN       NOT IN ('01')                                                                                                              ");
		sql.append("       AND B.FKCPL2010           = A.PKCPL2010                                                                                                             ");
		sql.append("       AND IFNULL(B.DISPLAY_YN,'N') = 'Y'                                                                                                                  ");
		sql.append("       AND C.HANGMOG_CODE        = B.HANGMOG_CODE                                                                                                          ");
		sql.append("       AND C.SPECIMEN_CODE       = B.SPECIMEN_CODE                                                                                                         ");
		sql.append("       AND C.EMERGENCY           = B.EMERGENCY                                                                                                             ");
		sql.append("       AND F.BUNHO               = A.BUNHO                                                                                                                 ");
		sql.append("       AND :f_jundal_gubun       = 'ETC'                                                                                                                   ");
		sql.append("     ORDER BY 1, 2, 3, 4                                                                                                                                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_jundal_gubun", jundalGubun);
		List<CPL0000Q00LayResultListTempListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00LayResultListTempListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL3020U02ExecuteSelectInOutGubunListItemInfo> getCPL3020U02ExecuteSelectInOutGubunListItemInfo(String hospCode,String inOutGubun, Double pkcpl2010){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IN_OUT_GUBUN                                               ");
		if("I".equalsIgnoreCase(inOutGubun)){
			sql.append("     , IF(IN_OUT_GUBUN = 'I', FKOCS2003, FKOCS1003)  FKOCS    ");
		}
		if("O".equalsIgnoreCase(inOutGubun)){
			sql.append("     , IF(IN_OUT_GUBUN = 'O', FKOCS1003, FKOCS2003)  FKOCS    ");
		}
		sql.append("  FROM CPL2010                                                ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code                               ");
		sql.append("   AND PKCPL2010 = :f_fkcpl2010                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkcpl2010", pkcpl2010);
		List<CPL3020U02ExecuteSelectInOutGubunListItemInfo> list = new JpaResultMapper().list(query, CPL3020U02ExecuteSelectInOutGubunListItemInfo.class);
		return list;
	}
	
	@Override
	public List<MultiResultViewSearchDataSigeyulInfo> getMultiResultViewSearchSigeyulInfo1(String hospCode, String bunho, String userId, String gubun, String baseDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                ");
		sql.append("       DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')   JUBSU_DATE                                                                      ");
		sql.append("     , SUBSTR(A.JUBSU_TIME,1,3)                JUBSU_TIME                                                                      ");
		sql.append("     , CONCAT(DATE_FORMAT(A.JUBSU_DATE,'%y.%m.%d'),'(',SUBSTR(A.JUBSU_TIME,1,2),':',SUBSTR(A.JUBSU_TIME,3,1),'0)') JUBSU_TIME2 ");
		sql.append("  FROM CPLTEMP C,                                                                                                              ");
		sql.append("       CPL3020 B,                                                                                                              ");
		sql.append("       CPL2010 A                                                                                                               ");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                                                                                          ");
		sql.append("   AND B.HOSP_CODE     = A.HOSP_CODE                                                                                           ");
		sql.append("   AND C.HOSP_CODE     = A.HOSP_CODE                                                                                           ");
		sql.append("  AND A.BUNHO         = :f_bunho                                                                                               ");
		sql.append("   AND A.RESULT_DATE   IS NOT NULL                                                                                             ");
		if("0".equalsIgnoreCase(gubun)) {
			sql.append("                                                                                                                           ");	
		} else if("1".equalsIgnoreCase(gubun)) {
			sql.append("   AND CONCAT(DATE_FORMAT(A.JUBSU_DATE,'%y.%m.%d'),'(',SUBSTR(A.JUBSU_TIME,1,2),':',SUBSTR(A.JUBSU_TIME,3,1),'0)') < :f_base_date    ");
		} else {
			sql.append("   AND CONCAT(DATE_FORMAT(A.JUBSU_DATE,'%y.%m.%d'),'(',SUBSTR(A.JUBSU_TIME,1,2),':',SUBSTR(A.JUBSU_TIME,3,1),'0)') > :f_base_date    ");
		}
		sql.append("   AND B.SPECIMEN_SER  = A.SPECIMEN_SER                                                                                        ");
		sql.append("   AND C.IP_ADDRESS    = :q_user_id                                                                                            ");
		sql.append("   AND C.JUNDAL_GUBUN  = 'XX'                                                                                                  ");
		sql.append("   AND B.HANGMOG_CODE  = C.HANGMOG_CODE                                                                                        ");
		sql.append(" ORDER BY 1,2                                                                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("q_user_id", userId);
		if(!"0".equalsIgnoreCase(gubun)) {
			query.setParameter("f_base_date", baseDate);
		}
		List<MultiResultViewSearchDataSigeyulInfo> list = new JpaResultMapper().list(query, MultiResultViewSearchDataSigeyulInfo.class);
		return list;
	}
	
	@Override
	public List<MultiResultViewSearchDataSigeyulInfo> getMultiResultViewSearchSigeyulInfo2(String hospCode, String bunho, String userId, String gubun, String baseDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                ");
		sql.append("       DATE_FORMAT(A.PART_JUBSU_DATE, '%Y/%m/%d')   JUBSU_DATE                                                                      ");
		sql.append("     , SUBSTR(A.PART_JUBSU_TIME,1,3)                JUBSU_TIME                                                                      ");
		sql.append("     , CONCAT(DATE_FORMAT(A.PART_JUBSU_DATE,'%y.%m.%d'),'(',SUBSTR(A.PART_JUBSU_TIME,1,2),':',SUBSTR(A.PART_JUBSU_TIME,3,1),'0)') JUBSU_TIME2 ");
		sql.append("  FROM CPLTEMP C,                                                                                                              ");
		sql.append("       CPL3020 B,                                                                                                              ");
		sql.append("       CPL2010 A                                                                                                               ");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                                                                                          ");
		sql.append("   AND B.HOSP_CODE     = A.HOSP_CODE                                                                                           ");
		sql.append("   AND C.HOSP_CODE     = A.HOSP_CODE                                                                                           ");
		sql.append("  AND A.BUNHO         = :f_bunho                                                                                               ");
		sql.append("   AND A.RESULT_DATE   IS NOT NULL                                                                                             ");
		if("0".equalsIgnoreCase(gubun)) {
			sql.append("                                                                                                                           ");	
		} else if("1".equalsIgnoreCase(gubun)) {
			sql.append("   AND CONCAT(DATE_FORMAT(A.PART_JUBSU_DATE,'%y.%m.%d'),'(',SUBSTR(A.PART_JUBSU_TIME,1,2),':',SUBSTR(A.PART_JUBSU_TIME,3,1),'0)') < :f_base_date    ");
		} else {
			sql.append("   AND CONCAT(DATE_FORMAT(A.PART_JUBSU_DATE,'%y.%m.%d'),'(',SUBSTR(A.PART_JUBSU_TIME,1,2),':',SUBSTR(A.PART_JUBSU_TIME,3,1),'0)') > :f_base_date    ");
		}
		sql.append("   AND B.SPECIMEN_SER  = A.SPECIMEN_SER                                                                                        ");
		sql.append("   AND C.IP_ADDRESS    = :q_user_id                                                                                            ");
		sql.append("   AND C.JUNDAL_GUBUN  = 'XX'                                                                                                  ");
		sql.append("   AND B.HANGMOG_CODE  = C.HANGMOG_CODE                                                                                        ");
		sql.append(" ORDER BY 1,2                                                                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("q_user_id", userId);
		query.setParameter("f_base_date", baseDate);
		List<MultiResultViewSearchDataSigeyulInfo> list = new JpaResultMapper().list(query, MultiResultViewSearchDataSigeyulInfo.class);
		return list;
	}

	@Override
	public List<OCSACT2GetPatientListCPLInfo> getOCSACT2GetPatientListCPLInfo(String hospCode, String language, String fromDate, String toDate, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.BUNHO                                                                                                                                           " );
		sql.append(" , MAX(B.SUNAME)                                                                                                                                           " );
		sql.append(" , MAX(A.IN_OUT_GUBUN)                                                                                                                                     " );
		sql.append(" , MAX(FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language)) GWA_NAME                                                                            " );
		sql.append(" , FN_SCH_RESER_YN1(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)   RESER_YN                                                           " );
		sql.append(" , MAX(A.DOCTOR)                                                                                                                                           " );
		sql.append(" , A.DOCTOR_NAME                                                                                                                                           " );
		sql.append(" , IFNULL(A.RESER_DATE, A.ORDER_DATE)                                   KIJUN_DATE                                                                         " );
		sql.append(" , IFNULL(C.EMERGENCY, 'N')                                             EMERGENCY_YN ,''                                                                   " );
		sql.append(" , IFNULL(P.NUMBER_PROTOCOL, 0)                                                               															   " );
		sql.append(" , B.SUNAME2                                                              			                                                                       ");
		sql.append(" , C.PKOCS1003                                                              		                                                                       ");
		sql.append(" , C.FKOUT1001                                                              		                                                                       ");
		sql.append(" , C.JUNDAL_TABLE                                                              		                                                                       ");
		sql.append(" FROM OCS1003 C                                                                                                                                            " );
		sql.append(" , OUT0101 B                                                                                                                                               " );
		sql.append(" , CPL2010 A                                                                                                                                               " );
		sql.append("LEFT JOIN (select COUNT(cpp.CLIS_PROTOCOL_ID) NUMBER_PROTOCOL, cpp.BUNHO from CLIS_PROTOCOL_PATIENT cpp                                                    ");
		sql.append("		 INNER JOIN CLIS_PROTOCOL	cp	ON cpp.CLIS_PROTOCOL_ID = cp.CLIS_PROTOCOL_ID                                                                      ");
		sql.append("		 AND cpp.HOSP_CODE = :f_hosp_code										AND				                                                           ");
		sql.append("		cpp.ACTIVE_FLG = 1										AND		                                                                                   ");
		sql.append("		cp.ACTIVE_FLG = 1										AND		                                                                                   ");
		sql.append("		cp.STATUS_FLG <> 1										AND		                                                                                   ");
		sql.append("		cp.END_DATE <= SYSDATE() GROUP BY cpp.BUNHO ) P ON A.BUNHO = P.BUNHO	                                                                           ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                       " );
		sql.append(" AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                          " );
		sql.append(" AND ((:f_bunho IS NULL AND IFNULL(A.RESER_DATE, A.ORDER_DATE) between STR_TO_DATE(:f_from_date,'%Y/%m/%d') and STR_TO_DATE(:f_to_date,'%Y/%m/%d'))        " );
		sql.append(" OR  (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))                                                                                                        " );
		sql.append(" AND A.JUBSU_DATE IS NOT NULL                                                                                                                              " );
		sql.append(" AND A.IN_OUT_GUBUN   = 'O'                                                                                                                                " );
		sql.append(" AND B.BUNHO          = A.BUNHO                                                                                                                            " );
		sql.append(" AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                        " );
		sql.append(" AND C.PKOCS1003      = A.FKOCS1003   AND C.JUNDAL_TABLE = 'CPL'                                                                                           " );
		sql.append(" AND EXISTS (SELECT 'X'                                                                                                                                    " );
		sql.append(" FROM OUT1001 X                                                                                                                                            " );
		sql.append(" WHERE X.HOSP_CODE   = A.HOSP_CODE                                                                                                                         " );
		sql.append(" AND X.NAEWON_DATE = IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                                                    " );
		sql.append(" AND X.BUNHO       = A.BUNHO                                                                                                                               " );
		sql.append(" AND X.GWA         != '03')                                                                                                                                " );
		sql.append(" GROUP BY A.BUNHO                                                                                                                                          " );
		sql.append(" , FN_SCH_RESER_YN1(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)                                                                      " );
		sql.append(" , A.DOCTOR_NAME                                                                                                                                           " );
		sql.append(" , FN_REQUEST_GWA_NAME(:f_hosp_code,:f_language,'O',A.BUNHO, A.GWA, A.ORDER_DATE)                                                                          " );
		sql.append(" , IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                                                                      " );
		sql.append(" , IFNULL(C.EMERGENCY, 'N')                                                                                                                                " );
		sql.append(" ORDER BY MAX(A.JUBSU_DATE) DESC, MAX(A.JUBSU_TIME) DESC																									");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_bunho", StringUtils.isEmpty(bunho) ? null : bunho);
		List<OCSACT2GetPatientListCPLInfo> listGrdPa= new JpaResultMapper().list(query, OCSACT2GetPatientListCPLInfo.class);
		return listGrdPa;
	}

	@Override
	public List<OCSACT2GetPatientListCPLInfo> getOCSACT2GetPatientListCPLInfo2(String hospCode, String language, String fromDate, String toDate, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                                                                                                        " );
		sql.append(" , MAX(B.SUNAME)                                                                                                                                       " );
		sql.append(" , MAX(A.IN_OUT_GUBUN)                                                                                                                                 " );
		sql.append(" , MAX(FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(),:f_hosp_code,:f_language)) GWA_NAME                                                                        " );
		sql.append(" , FN_SCH_RESER_YN1(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)   RESER_YN                                                       " );
		sql.append(" , MAX(A.DOCTOR)                                                                                                                                       " );
		sql.append(" , A.DOCTOR_NAME                                                                                                                                       " );
		sql.append(" , IFNULL(A.RESER_DATE, A.ORDER_DATE)    KIJUN_DATE                                                                                                    " );
		sql.append(" , IFNULL(C.EMERGENCY, 'N')     EMERGENCY_YN                                                                                                           " );
		sql.append(" , MAX(A.ORDER_TIME)    NAEWON_TIME                                                                                                                    " );
		sql.append(" , IFNULL(P.NUMBER_PROTOCOL, 0)                                                                                                                        " );
		sql.append(" , B.SUNAME2                                                              			                                                                   ");
		sql.append(" , C.PKOCS1003                                                              			                                                               ");
		sql.append(" , C.FKOUT1001                                                              			                                                               ");
		sql.append(" , C.JUNDAL_TABLE                                                              			                                                               ");
		sql.append(" FROM OCS1003 C                                                                                                                                        " );
		sql.append(" , OUT0101 B                                                                                                                                           " );
		sql.append(" , CPL2010 A                                                                                                                                           " );
		sql.append("LEFT JOIN (select COUNT(cpp.CLIS_PROTOCOL_ID) NUMBER_PROTOCOL, cpp.BUNHO from CLIS_PROTOCOL_PATIENT cpp                                                ");
		sql.append("		 INNER JOIN CLIS_PROTOCOL	cp	ON cpp.CLIS_PROTOCOL_ID = cp.CLIS_PROTOCOL_ID                                                                  ");
		sql.append("		 AND cpp.HOSP_CODE = :f_hosp_code										AND				                                                       ");
		sql.append("		cpp.ACTIVE_FLG = 1										AND		                                                                               ");
		sql.append("		cp.ACTIVE_FLG = 1										AND		                                                                               ");
		sql.append("		cp.STATUS_FLG <> 1										AND		                                                                               ");
		sql.append("		cp.END_DATE <= SYSDATE() GROUP BY cpp.BUNHO ) P ON A.BUNHO = P.BUNHO	                                                                       ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                   " );
		sql.append(" AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                      " );
		sql.append("AND ((:f_bunho IS NULL AND STR_TO_DATE(IFNULL(DATE_FORMAT(A.RESER_DATE,'%Y/%m/%d'), DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')), '%Y/%m/%d' ) between STR_TO_DATE(:f_from_date,'%Y/%m/%d') and STR_TO_DATE(:f_to_date,'%Y/%m/%d'))      " );
		sql.append(" OR  (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))                                                                                                    " );
		sql.append(" AND A.JUBSU_DATE IS NULL                                                                                                                              " );
		sql.append(" AND A.IN_OUT_GUBUN   = 'O'                                                                                                                            " );
		sql.append(" AND B.BUNHO          = A.BUNHO                                                                                                                        " );
		sql.append(" AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                    " );
		sql.append(" AND C.PKOCS1003      = A.FKOCS1003   AND C.JUNDAL_TABLE = 'CPL'                                                                                       " );
		sql.append(" AND EXISTS (SELECT 'X'                                                                                                                                " );
		sql.append(" FROM OUT1001 X                                                                                                                                        " );
		sql.append(" WHERE X.HOSP_CODE = A.HOSP_CODE                                                                                                                       " );
		sql.append(" AND X.NAEWON_DATE = IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                                                " );
		sql.append(" AND X.BUNHO = A.BUNHO                                                                                                                                 " );
		sql.append(" AND IFNULL(X.NAEWON_YN, 'N') != 'N'                                                                                                                   " );
		sql.append(" AND X.GWA   != '03')                                                                                                                                  " );
		sql.append(" GROUP BY A.BUNHO                                                                                                                                      " );
		sql.append(" , FN_SCH_RESER_YN1(:f_hosp_code,A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)                                                                  " );
		sql.append(" , A.DOCTOR_NAME                                                                                                                                       " );
		sql.append(" , FN_REQUEST_GWA_NAME(:f_hosp_code,:f_language,'O',A.BUNHO, A.GWA, A.ORDER_DATE)                                                                      " );
		sql.append(" , IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                                                                  " );
		sql.append(" , IFNULL(C.EMERGENCY, 'N')                                                                                                                            " );
		sql.append(" ORDER BY IFNULL(A.RESER_DATE, A.ORDER_DATE) , NAEWON_TIME																								");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_bunho", StringUtils.isEmpty(bunho) ? null : bunho);
		List<OCSACT2GetPatientListCPLInfo> listGrdPa= new JpaResultMapper().list(query, OCSACT2GetPatientListCPLInfo.class);
		return listGrdPa;
	}

	@Override
	public List<CPL2010U01CHANGETIMEgrdSpecimenInfo> getCPL2010U01CHANGETIMEgrdSpecimenInfo(String hospCode,
			String orderDate, String bunho, String gwa, String doctor) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PKCPL2010                                                                         ");
		sql.append("	     , IF(A.SUNAB_DATE IS NULL, 'N', 'Y')             	SUNAB_YN                           ");
		sql.append("	     , IF(A.JUBSU_DATE IS NULL, 'N', 'Y')          		  JUBSU_FLAG                       ");
		sql.append("	     , F.SLIP_NAME                                                                         ");
		sql.append("	     , A.HANGMOG_CODE                                                                      ");
		sql.append("	     , C.GUMSA_NAME                                                                        ");
		sql.append("	     , A.SPECIMEN_CODE                                                                     ");
		sql.append("	     , IFNULL(B.CODE_NAME_RE, B.CODE_NAME)  			      SPECIMEN_NAME                ");
		sql.append("	     , A.EMERGENCY                                                                         ");
		sql.append("	     , IFNULL(D.CODE_NAME, D.CODE_NAME_RE)              TUBE_NAME                          ");
		sql.append("	     , IFNULL(A.SPECIMEN_SER, '')                       SPECIMEN_SER                       ");
		sql.append("	     , FN_XRT_LOAD_COMMENT(:f_hosp_code,A.FKOCS1003,A.FKOCS2003)                           ");
		sql.append("	                                                        COMMENT_JU_CODE                    ");
		sql.append("	     , A.FKOCS1003                                                                         ");
		sql.append("	     , IFNULL(C.GROUP_GUBUN, 'N')                       GROUP_GUBUN                        ");
		sql.append("	     , IF(A.PART_JUBSU_DATE IS NULL, 'N', 'Y')          PART_JUBSU_FLAG                    ");
		sql.append("	     , IF(A.GUM_JUBSU_DATE IS NULL, 'N', 'Y')           GUM_JUBSU_FLAG                     ");
		sql.append("	     , IFNULL(A.DUMMY, '')                              DUMMY                              ");
		sql.append("	     , IF(C.GROUP_GUBUN = '03','Y','N')                 MODIFY_YN                          ");
		sql.append("	     , IF(A.HANGMOG_CODE = A.GROUP_HANGMOG,IF(C.GROUP_GUBUN = '02','N','Y'),'N')           ");
		sql.append("	                                                        MODIFY_YN_1                        ");
		sql.append("	     , A.JUNDAL_GUBUN                                                                      ");
		sql.append("	     , IFNULL(A.JUBSUJA, '')                            JUBSUJA                            ");
		sql.append("	     , A.ORDER_DATE                                                                        ");
		sql.append("	     , A.BUNHO                                                                             ");
		sql.append("	     , A.JUBSU_DATE                                                                        ");
		sql.append("	     , IFNULL(A.JUBSU_TIME, '')                         JUBSU_TIME                         ");
		sql.append("	     , IFNULL(A.ORDER_TIME, '')                         ORDER_TIME                         ");
		sql.append("	  FROM CPL2010 A                                                                           ");
		sql.append("	  LEFT JOIN CPL0109 B ON B.HOSP_CODE 	= A.HOSP_CODE                                      ");
		sql.append("						 AND B.CODE			= A.SPECIMEN_CODE                                  ");
		sql.append("						 AND B.CODE_TYPE	= '04'                                             ");
		sql.append("	  JOIN CPL0101 C ON C.HOSP_CODE         = A.HOSP_CODE                                      ");
		sql.append("				    AND C.HANGMOG_CODE      = A.HANGMOG_CODE                                   ");
		sql.append("				    AND C.SPECIMEN_CODE     = A.SPECIMEN_CODE                                  ");
		sql.append("				    AND C.EMERGENCY         = A.EMERGENCY                                      ");
		sql.append("	  LEFT JOIN CPL0109 D ON D.HOSP_CODE 	= A.HOSP_CODE                                      ");
		sql.append("						 AND D.CODE			= A.TUBE_CODE                                      ");
		sql.append("						 AND D.CODE_TYPE	= '02'                                             ");
		sql.append("	  LEFT JOIN CPL0001 F ON F.SLIP_CODE 	= A.SLIP_CODE                                      ");
		sql.append("	 WHERE A.HOSP_CODE                = :f_hosp_code                                           ");
		sql.append("	   AND A.ORDER_DATE               = STR_TO_DATE(:f_order_date,'%Y/%m/%d')                  ");
		sql.append("	   AND A.BUNHO                    = :f_bunho                                               ");
		sql.append("	   AND A.GWA                      = :f_gwa                                                 ");
		sql.append("	   AND A.DOCTOR                   = :f_doctor                                              ");
		sql.append("	   AND A.IN_OUT_GUBUN             = 'I'                                                    ");
		sql.append("	   AND IF(A.DC_YN IS NULL OR A.DC_YN = '','N',A.DC_YN)           = 'N'                     ");
		sql.append("	   AND A.JUBSU_DATE              IS NULL                                                   ");
		sql.append("	   AND ( (A.AFTER_ACT_YN IS NULL) OR                                                       ");
		sql.append("	       (A.AFTER_ACT_YN =  'N' ) )                                                          ");
		sql.append("	 ORDER BY A.HANGMOG_CODE                                                                   ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_order_date", orderDate);
		
		List<CPL2010U01CHANGETIMEgrdSpecimenInfo> listGrdPa= new JpaResultMapper().list(query, CPL2010U01CHANGETIMEgrdSpecimenInfo.class);
		return listGrdPa;
	}
	
	@Override
	public List<CPL2010U02grdSpecimenInfo> getCPL2010U02grdSpecimenInfo(String hospCode, String language,
			String jubsuYn, String bunho, String fromDate, String toDate, String hoDong, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.SPECIMEN_SER																																	");
		sql.append("         , MIN(A.SPECIMEN_CODE)																															");
		sql.append("         , MIN((SELECT X.CODE_NAME																														");
		sql.append("                  FROM CPL0109 X																														");
		sql.append("                 WHERE X.HOSP_CODE = A.HOSP_CODE																										");
		sql.append("                   AND X.CODE_TYPE = '04'																												");
		sql.append("                   AND X.CODE      = A.SPECIMEN_CODE)) SPECIMEN_NAME																					");
		sql.append("         , A.BUNHO																																		");
		sql.append("         , MIN(B.SUNAME)																																");
		sql.append("         , MIN(FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(), :f_hosp_code, :f_language))																		");
		sql.append("         , MIN(FN_BAS_LOAD_GWA_NAME(FN_INP_LOAD_HO_DONG_HISTORY(:f_hosp_code, A.BUNHO, SYSDATE()), A.ORDER_DATE, :f_hosp_code, :f_language))  HO_DONG	");
		sql.append("         , MIN(FN_INP_LOAD_HO_CODE_HISTORY(:f_hosp_code, A.BUNHO, SYSDATE()))                                      HO_CODE								");
		sql.append("         , MIN(FN_ADM_LOAD_USER_NM(:f_hosp_code, A.JUBSUJA, A.JUBSU_DATE))       JUBSUJA_NAME															");
		sql.append("         , MIN(A.JUNDAL_GUBUN)	                                                                                                                        ");
		sql.append("         , MIN(A.GUM_JUBSU_DATE)                                                                                                                        ");
		sql.append("         , MIN(A.GUM_JUBSU_TIME)                                                                                                                        ");
		sql.append("         , MIN(FN_ADM_LOAD_USER_NM(:f_hosp_code, A.GUM_JUBSUJA, A.GUM_JUBSU_DATE)) GUM_JUBSUJA_NAME                                                     ");
		sql.append("         , MIN(FN_CPL_LOAD_COMMENT(A.SPECIMEN_SER, :f_hosp_code))   REMARK							                                                    ");
		sql.append("         , MIN(IF(A.GUM_JUBSU_DATE IS NULL,'N','Y')) JUBSU_FLAG										                                                    ");
		sql.append("         , CONCAT(A.BUNHO, A.SPECIMEN_SER)															                                                    ");
		sql.append("      FROM OUT0101 B																				                                                    ");
		sql.append("         , CPL2010 A																				                                                    ");
		sql.append("     WHERE A.HOSP_CODE  = :f_hosp_code																                                                    ");
		sql.append("       AND A.IN_OUT_GUBUN = 'I'																		                                                    ");
		sql.append("       AND A.JUBSU_DATE IS NOT NULL																	                                                    ");
		sql.append("       AND (  (:f_jubsu_yn = '%')																	                                                    ");
		sql.append("           OR (:f_jubsu_yn = 'Y' AND A.GUM_JUBSU_DATE IS NOT NULL )									                                                    ");
		sql.append("           OR (:f_jubsu_yn = 'N' AND A.GUM_JUBSU_DATE IS NULL ) )									                                                    ");
		sql.append("       AND B.HOSP_CODE     = A.HOSP_CODE															                                                    ");
		sql.append("       AND B.BUNHO         = A.BUNHO																                                                    ");
		sql.append("       AND A.BUNHO      LIKE CONCAT(:f_bunho, '%')													                                                    ");
		sql.append("       AND IFNULL(A.RESER_DATE, ORDER_DATE) BETWEEN :f_from_date AND :f_to_date						                                                    ");
		sql.append("     GROUP BY A.BUNHO, A.SPECIMEN_SER																                                                    ");
		sql.append("       HAVING FN_INP_LOAD_HO_DONG_HISTORY(:f_hosp_code, A.BUNHO, SYSDATE()) LIKE CONCAT(:f_ho_dong, '%')												");
		sql.append("     ORDER BY 7,8,1																																		");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_yn", jubsuYn);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", DateUtil.toDate(fromDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_to_date", DateUtil.toDate(toDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_ho_dong", hoDong);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
	    
	    List<CPL2010U02grdSpecimenInfo> listResult = new JpaResultMapper().list(query, CPL2010U02grdSpecimenInfo.class);
	    return listResult;
	}

	@Override
	public List<CPL2010U01grdPaInfo> getCPL2010U01grdPaInfo(String hospCode, String language, String bunho,
			String reserYn, String fromDate, String toDate, String doctor, String emergencyYn, Integer startNum,
			Integer offset, boolean rbxmijubsu) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT DISTINCT																				");
		sql.append("       A.BUNHO BUNHO,																		");
		sql.append("       A.SUNAME SUNAME,																		");
		sql.append("       FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language) GWA_NAME,		");
		sql.append("       A.GWA GWA,					                                                        ");
		sql.append("       A.DOCTOR_NAME DOCTOR_NAME,	                                                        ");
		sql.append("       A.DOCTOR DOCTOR,				                                                        ");
		sql.append("       A.ORDER_DATE ORDER_DATE,		                                                        ");
		sql.append("       A.ORDER_TIME ORDER_TIME,		                                                        ");
		sql.append("       A.JUBSU_DATE JUBSU_DATE,		                                                        ");
		sql.append("       A.JUBSU_TIME JUBSU_TIME,		                                                        ");
		sql.append("       A.RESER_DATE RESER_DATE,		                                                        ");
		if (rbxmijubsu)
			sql.append("       '' JUBSUJA_NAME,				                                                        ");
		else
			sql.append("       FN_ADM_LOAD_USER_NM(:f_hosp_code, A.JUBSUJA, A.JUBSU_DATE) JUBSUJA_NAME,				");
		sql.append("       A.GROUP_SER,					                                                        ");
		sql.append("       CONCAT(						                                                        ");
		sql.append("          DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d'),											");
		sql.append("          RPAD(FN_INP_LOAD_HO_DONG_HISTORY(:f_hosp_code, A.BUNHO, CURRENT_TIMESTAMP),		");
		sql.append("               4,																			");
		sql.append("               '0'),																		");
		sql.append("          RPAD(FN_INP_LOAD_HO_CODE_HISTORY(:f_hosp_code, A.BUNHO, CURRENT_TIMESTAMP),		");
		sql.append("               4,																			");
		sql.append("               '0'),																		");
		sql.append("          RPAD(A.BUNHO, 9, '0'),															");
		sql.append("          DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d'),											");
		sql.append("          RPAD(A.ORDER_TIME, 4, '0')) KEY_ORDER												");
		sql.append("  FROM OCS2003 B, 																			");
		sql.append("       CPL2010 A																			");
		sql.append(" WHERE     A.HOSP_CODE = :f_hosp_code														");
		sql.append("       AND A.Bunho = :f_bunho																");
		sql.append("       AND (   (    :f_reser_yn = 'N'														");
		sql.append("                AND A.RESER_DATE IS NULL													");
		sql.append("                AND (A.ORDER_DATE BETWEEN :f_from_date AND :f_to_date))						");
		sql.append("            OR (    :f_reser_yn = 'Y'														");
		sql.append("                AND A.RESER_DATE BETWEEN :f_from_date AND :f_to_date))						");
		if (rbxmijubsu)
			sql.append("       AND A.JUBSU_DATE IS NULL			                                                    ");
		else
			sql.append("       AND A.JUBSU_DATE IS NOT NULL			                                                    ");
		sql.append("       AND A.IN_OUT_GUBUN = 'I'			                                                    ");
		sql.append("       AND A.DOCTOR = :f_doctor			                                                    ");
		sql.append("       AND B.HOSP_CODE = A.HOSP_CODE	                                                    ");
		sql.append("       AND B.PKOCS2003 = A.FKOCS2003	                                                    ");
		sql.append("       AND (   :f_emergency_yn = 'N' AND IFNULL(B.EMERGENCY, 'N') = 'N'						");
		sql.append("            OR :f_emergency_yn = 'Y' AND IFNULL(B.EMERGENCY, 'N') = 'Y')					");
		sql.append("       AND B.DC_YN = 'N'																	");
		sql.append("       AND B.NALSU > 0																		");
		sql.append(" ORDER BY A.ORDER_DATE DESC, A.ORDER_TIME DESC												");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_yn", reserYn);
		query.setParameter("f_from_date", DateUtil.toDate(fromDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_to_date", DateUtil.toDate(toDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_emergency_yn", emergencyYn);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
	    
	    List<CPL2010U01grdPaInfo> listResult = new JpaResultMapper().list(query, CPL2010U01grdPaInfo.class);
	    return listResult;
	}

	@Override
	public List<CPL2010U01grdPaListInfo> getCPL2010U01grdPaListInfo(String hospCode, String language, String reserYn,
			String fromDate, String toDate, String hoDong, Integer startNum, Integer offset, boolean rbxmijubsu) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.BUNHO BUNHO,																		");
		sql.append("       MAX(A.SUNAME) SUNAME,								                                ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(A.GWA,							                                ");
		sql.append("                            A.ORDER_DATE,					                                ");
		sql.append("                            :f_hosp_code,					                                ");
		sql.append("                            :f_language)					                                ");
		sql.append("          GWA_NAME,											                                ");
		sql.append("       MAX(A.DOCTOR),										                                ");
		sql.append("       A.DOCTOR_NAME DOCTOR_NAME,							                                ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(								                                ");
		sql.append("          FN_INP_LOAD_HO_DONG_HISTORY(:f_hosp_code,			                                ");
		sql.append("                                      A.BUNHO,				                                ");
		sql.append("                                      CURRENT_TIMESTAMP),	                                ");
		sql.append("          A.ORDER_DATE,										                                ");
		sql.append("          :f_hosp_code,										                                ");
		sql.append("          :f_language)										                                ");
		sql.append("          HO_DONG,											                                ");
		sql.append("       FN_INP_LOAD_HO_CODE_HISTORY(:f_hosp_code, A.BUNHO, CURRENT_TIMESTAMP)				");
		sql.append("          HO_CODE,																			");
		sql.append("       FN_SCH_RESER_YN1(:f_hosp_code,														");
		sql.append("                        A.IN_OUT_GUBUN,														");
		sql.append("                        A.FKOCS1003,														");
		sql.append("                        A.FKOCS2003,														");
		sql.append("                        A.RESER_DATE)														");
		sql.append("          RESER_YN,																			");
		sql.append("       IFNULL(C.EMERGENCY, 'N') EMERGENCY_YN												");
		sql.append("  FROM OCS2003 C, CPL2010 A																	");
		sql.append(" WHERE     A.HOSP_CODE = :f_hosp_code														");
		sql.append("       AND (   (    :f_reser_yn = 'N'														");
		sql.append("                AND (IFNULL(A.RESER_DATE, A.ORDER_DATE) BETWEEN STR_TO_DATE(				");
		sql.append("                                                                   :f_from_date,			");
		sql.append("                                                                   '%Y/%m/%d')				");
		sql.append("                                                            AND STR_TO_DATE(				");
		sql.append("                                                                   :f_to_date,				");
		sql.append("                                                                   '%Y/%m/%d')))			");
		sql.append("            OR (    :f_reser_yn = 'Y'														");
		sql.append("                AND A.RESER_DATE BETWEEN STR_TO_DATE(:f_from_date,							");
		sql.append("                                                     '%Y/%m/%d')							");
		sql.append("                                     AND STR_TO_DATE(:f_to_date, '%Y/%m/%d')))				");		
		if (rbxmijubsu)
			sql.append("       AND A.JUBSU_DATE IS NULL			                                                ");
		else
			sql.append("       AND A.JUBSU_DATE IS NOT NULL			                                            ");
		sql.append("       AND A.IN_OUT_GUBUN = 'I'																");
		sql.append("       AND C.HOSP_CODE = A.HOSP_CODE														");
		sql.append("       AND C.PKOCS2003 = A.FKOCS2003														");
		sql.append("       AND C.DC_YN = 'N'																	");
		sql.append("       AND C.NALSU > 0																		");
		sql.append(" GROUP BY FN_BAS_LOAD_GWA_NAME(																");
		sql.append("            FN_INP_LOAD_HO_DONG_HISTORY(:f_hosp_code, A.BUNHO, CURRENT_TIMESTAMP),			");
		sql.append("            A.ORDER_DATE, :f_hosp_code, :f_language),										");
		sql.append("         FN_INP_LOAD_HO_CODE_HISTORY(:f_hosp_code, A.BUNHO, CURRENT_TIMESTAMP),				");
		sql.append("         A.BUNHO,																			");
		sql.append("         FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language),				");
		sql.append("         A.DOCTOR_NAME,																		");
		sql.append("         FN_SCH_RESER_YN1(:f_hosp_code, A.IN_OUT_GUBUN,										");
		sql.append("                          A.FKOCS1003,														");
		sql.append("                          A.FKOCS2003,														");
		sql.append("                          A.RESER_DATE),													");
		sql.append("         IFNULL(C.EMERGENCY, 'N')															");
		sql.append(" HAVING FN_INP_LOAD_HO_DONG_HISTORY(:f_hosp_code, A.BUNHO, CURRENT_TIMESTAMP) LIKE			");
		sql.append("          :f_ho_dong																		");
		sql.append(" ORDER BY FN_SCH_RESER_YN1(:f_hosp_code, A.IN_OUT_GUBUN,									");
		sql.append("                          A.FKOCS1003,														");
		sql.append("                          A.FKOCS2003,														");
		sql.append("                          A.RESER_DATE),													");
		sql.append("         FN_BAS_LOAD_GWA_NAME(																");
		sql.append("            FN_INP_LOAD_HO_DONG_HISTORY(:f_hosp_code, A.BUNHO, CURRENT_TIMESTAMP),			");
		sql.append("            A.ORDER_DATE, :f_hosp_code, :f_language),										");
		sql.append("         FN_INP_LOAD_HO_CODE_HISTORY(:f_hosp_code, A.BUNHO, CURRENT_TIMESTAMP),				");
		sql.append("         A.BUNHO,																			");
		sql.append("         FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language),				");
		sql.append("         A.DOCTOR_NAME																		");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																");
		}
		
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_reser_yn", reserYn);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_ho_dong", hoDong);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
	    
	    List<CPL2010U01grdPaListInfo> listResult = new JpaResultMapper().list(query, CPL2010U01grdPaListInfo.class);
	    return listResult;
	}

	@Override
	public List<CPL2010U01grdSpecimenInfo> getCPL2010U01grdSpecimenInfo(String hospCode, String language,
			String orderDate, String bunho, String gwa, String orderTime, String doctor, String reserYn,
			String reserDate, String jubsuDate, String jubsuTime, String groupSer, String emergencyYn, Integer startNum,
			Integer offset, boolean rbxmijubsu) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.PKCPL2010,																			");
		sql.append("       CASE A.SUNAB_DATE WHEN NULL THEN 'N' ELSE 'Y' END SUNAB_YN,							");
		sql.append("       CASE A.JUBSU_DATE WHEN NULL THEN 'N' ELSE 'Y' END JUBSU_FLAG,						");
		sql.append("       F.SLIP_NAME,																			");
		sql.append("       A.HANGMOG_CODE,																		");
		sql.append("       C.GUMSA_NAME,																		");
		sql.append("       A.SPECIMEN_CODE,																		");
		sql.append("       IFNULL(B.CODE_NAME_RE, B.CODE_NAME) SPECIMEN_NAME,									");
		sql.append("       A.EMERGENCY,																			");
		sql.append("       A.TUBE_CODE,																			");
		sql.append("       IFNULL(D.CODE_NAME, D.CODE_NAME_RE) TUBE_NAME,										");
		sql.append("       A.SPECIMEN_SER COMMENT_JU_CODE,														");
		sql.append("       FN_XRT_LOAD_COMMENT(:f_hosp_code, A.FKOCS1003, A.FKOCS2003) DOC_COMMENT,				");
		sql.append("       A.FKOCS2003,																			");
		sql.append("       IFNULL(C.GROUP_GUBUN, 'N') GROUP_GUBUN,												");
		sql.append("       CASE A.PART_JUBSU_DATE WHEN NULL THEN 'N' ELSE 'Y' END PART_JUBSU_FLAG,				");
		sql.append("       CASE A.GUM_JUBSU_DATE WHEN NULL THEN 'N' ELSE 'Y' END GUM_JUBSU_FLAG,				");
		sql.append("       A.DUMMY,																				");
		sql.append("       CASE C.GROUP_GUBUN WHEN '03' THEN 'Y' ELSE 'N' END MODIFY_YN,						");
		sql.append("       CASE A.HANGMOG_CODE																	");
		sql.append("          WHEN A.GROUP_HANGMOG																");
		sql.append("          THEN																				");
		sql.append("             CASE C.GROUP_GUBUN WHEN '02' THEN 'N' ELSE 'Y' END								");
		sql.append("          ELSE																				");
		sql.append("             'N'																			");
		sql.append("       END																					");
		sql.append("          MODIFY_YN_1,																		");
		sql.append("       A.JUNDAL_GUBUN,																		");
		sql.append("       A.JUBSUJA,		                                                                    ");
		sql.append("       A.ORDER_DATE,	                                                                    ");
		sql.append("       A.BUNHO,			                                                                    ");
		sql.append("       A.JUBSU_DATE,	                                                                    ");
		sql.append("       A.JUBSU_TIME,	                                                                    ");
		sql.append("       A.ORDER_TIME,	                                                                    ");
		sql.append("       C.SPCIAL_NAME,	                                                                    ");
		sql.append("       A.GROUP_HANGMOG,	                                                                    ");
		sql.append("       FN_CPL_LOAD_CODE_NAME('11', C.BARCODE, :f_hosp_code, :f_language) BARCODE_NAME,		");
		sql.append("       C.UITAK_CODE,																		");
		sql.append("       IFNULL(C.MIDDLE_RESULT, 'N') MIDDLE_RESULT											");	
		sql.append("  FROM CPL2010 A																			");
		sql.append("       LEFT OUTER JOIN CPL0109 B															");
		sql.append("          ON     B.HOSP_CODE = A.HOSP_CODE													");
		sql.append("             AND B.CODE = A.SPECIMEN_CODE													");
		sql.append("             AND B.CODE_TYPE = '04'			                                                ");
		sql.append("       LEFT OUTER JOIN CPL0109 D			                                                ");
		sql.append("          ON     D.HOSP_CODE = A.HOSP_CODE	                                                ");
		sql.append("             AND D.CODE = A.TUBE_CODE		                                                ");
		sql.append("             AND D.CODE_TYPE = '02'			                                                ");
		sql.append("       LEFT OUTER JOIN CPL0001 F			                                                ");
		sql.append("          ON F.HOSP_CODE = A.HOSP_CODE AND F.SLIP_CODE = A.SLIP_CODE,						");
		sql.append("       CPL0101 C,						                                                    ");
		sql.append("       OCS2003 O						                                                    ");
		sql.append(" WHERE     A.HOSP_CODE = :f_hosp_code	                                                    ");
		sql.append("       AND C.HOSP_CODE = A.HOSP_CODE	                                                    ");
		sql.append("       AND A.ORDER_DATE = :f_order_date	                                                    ");
		sql.append("       AND A.BUNHO = :f_bunho			                                                    ");
		sql.append("       AND A.GWA = :f_gwa				                                                    ");
		sql.append("       AND A.ORDER_TIME = :f_order_time	                                                    ");
		sql.append("       AND A.DOCTOR = :f_doctor			                                                    ");
		sql.append("       AND A.IN_OUT_GUBUN = 'I'			                                                    ");
		sql.append("       AND (   :f_reser_yn = 'Y' AND A.RESER_DATE = :f_reser_date							");
		sql.append("            OR :f_reser_yn = 'N' AND A.RESER_DATE IS NULL)									");
		if (rbxmijubsu)
			sql.append("       AND A.JUBSU_DATE IS NULL			                                                    ");
		else {
			sql.append("       AND A.JUBSU_DATE = :f_jubsu_date		                                                ");
			sql.append("       AND A.JUBSU_TIME = :f_jubsu_time		                                                ");
		}
		sql.append("AND A.GROUP_SER = :f_group_ser																");
		sql.append("       AND IFNULL(A.DC_YN, 'N') = 'N'														");
		sql.append("       AND (A.AFTER_ACT_YN IS NULL OR A.AFTER_ACT_YN = 'N')									");
		sql.append("       AND C.HANGMOG_CODE = A.HANGMOG_CODE													");
		sql.append("       AND C.SPECIMEN_CODE = A.SPECIMEN_CODE												");
		sql.append("       AND C.EMERGENCY = A.EMERGENCY														");
		sql.append("       AND O.HOSP_CODE = A.HOSP_CODE														");
		sql.append("       AND O.PKOCS2003 = A.FKOCS2003														");
		sql.append("       AND (   :f_emergency_yn = 'N' AND IFNULL(O.EMERGENCY, 'N') = 'N'						");
		sql.append("            OR :f_emergency_yn = 'Y' AND IFNULL(O.EMERGENCY, 'N') = 'Y')					");
		sql.append("       AND O.DC_YN = 'N'																	");
		sql.append("       AND O.NALSU > 0																		");
		sql.append("ORDER BY C.UITAK_CODE,																		");
		sql.append("         LPAD(A.GROUP_HANGMOG, 10, '0'),													");
		sql.append("         CASE A.GROUP_HANGMOG WHEN A.HANGMOG_CODE THEN 1 ELSE 2 END,						");
		sql.append("         LPAD(A.HANGMOG_CODE, 10, '0'),														");
		sql.append("         A.TUBE_CODE,																		");
		sql.append("         A.ORDER_TIME,																		");
		sql.append("         A.JUNDAL_GUBUN,																	");
		sql.append("         A.SPECIMEN_CODE,																	");
		sql.append("         IFNULL(C.SERIAL, '9999999999')														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_order_time", orderTime);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_reser_yn", reserYn);
		query.setParameter("f_reser_date", DateUtil.toDate(reserDate, DateUtil.PATTERN_YYMMDD));
		if (!rbxmijubsu) {
			query.setParameter("f_jubsu_date", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
			query.setParameter("f_jubsu_time", jubsuTime);
		}
		query.setParameter("f_group_ser", groupSer);
		query.setParameter("f_emergency_yn", emergencyYn);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
	    
	    List<CPL2010U01grdSpecimenInfo> listResult = new JpaResultMapper().list(query, CPL2010U01grdSpecimenInfo.class);
	    return listResult;
	}
	

	@Override
	public List<CPL2010U01grdTubeInfo> getCPL2010U01grdTubeInfo(String hospCode, String language, String sqlIndex,
			String jubsuDate, String jubsuTime, String bunho, Date reserDate, String reserYn) {
		StringBuilder sql = new StringBuilder();
		if("1".equals(sqlIndex)){
			sql.append("	SELECT X.TUBE_CODE,                                                                                  ");
			sql.append("	       IFNULL(X.TUBE_NAME, '')	AS TUBE_NAME,                                                        ");
			sql.append("	       IFNULL(CAST(SUM(X.TUBE_COUNT) AS CHAR), '0')   CNT                                            ");
			sql.append("	  FROM (     SELECT MIN(A.TUBE_CODE)            TUBE_CODE,                                           ");
			sql.append("	                    MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code, :f_language))    TUBE_NAME,  ");
			sql.append("	                    FN_CPL_TUBE_COUNT(A.SPECIMEN_SER, :f_hosp_code)       TUBE_COUNT                 ");
			sql.append("	               FROM CPL0101 B,                                                                       ");
			sql.append("	                    CPL2010 A                                                                        ");
			sql.append("	              WHERE A.HOSP_CODE     = :f_hosp_code                                                   ");
			sql.append("	                AND B.HOSP_CODE     = A.HOSP_CODE                                                    ");
			sql.append("	                AND A.JUBSU_DATE    = STR_TO_DATE(:f_jubsu_date,'%Y/%m/%d')                          ");
			sql.append("	                AND A.JUBSU_TIME    = :f_jubsu_time                                                  ");
			sql.append("	                AND A.BUNHO         = :f_bunho                                                       ");
			sql.append("	                AND (  :f_reser_date IS NOT NULL AND A.RESER_DATE = :f_reser_date                    ");
			sql.append("	                    OR :f_reser_date IS NULL )                                                       ");
			sql.append("	                AND (  :f_reser_yn = 'Y' AND A.RESER_DATE IS NOT NULL                                ");
			sql.append("	                    OR :f_reser_yn = 'N' )AND A.JUBSU_DATE    IS NOT NULL                            ");
			sql.append("	                AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                 ");
			sql.append("	                AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                ");
			sql.append("	                AND B.EMERGENCY     = A.EMERGENCY                                                    ");
			sql.append("	              GROUP BY A.SPECIMEN_CODE,                                                              ");
			sql.append("	                    A.TUBE_CODE,                                                                     ");
			sql.append("	                    A.IN_OUT_GUBUN,                                                                  ");
			sql.append("	                    A.SPECIMEN_SER,                                                                  ");
			sql.append("	                    A.GWA,                                                                           ");
			sql.append("	                    A.BUNHO       ) X                                                                ");
			sql.append("	 GROUP BY X.TUBE_CODE, X.TUBE_NAME                                                                   ");
			sql.append("	 ORDER BY X.TUBE_CODE                                                                                ");
		}
		else if("2".equals(sqlIndex)){
			sql.append("	SELECT X.TUBE_CODE,                                                                                  ");
			sql.append("	     IFNULL(X.TUBE_NAME, '') AS TUBE_NAME,                                                           ");
			sql.append("	     IFNULL(CAST(SUM(X.TUBE_COUNT) AS CHAR), '0')   CNT                                              ");
			sql.append("	  FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,                                       ");
			sql.append("	                  MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code, :f_language)) TUBE_NAME,       ");
			sql.append("	                  FN_CPL_TUBE_COUNT(A.SPECIMEN_SER, :f_hosp_code)               	TUBE_COUNT,      ");
			sql.append("	                  A.HOSP_CODE                                                                        ");
			sql.append("	             FROM CPL0101 B,                                                                         ");
			sql.append("	                  CPL2010 A                                                                          ");
			sql.append("	            WHERE A.HOSP_CODE     = :f_hosp_code                                                     ");
			sql.append("	              AND B.HOSP_CODE     = A.HOSP_CODE                                                      ");
			sql.append("	              AND A.ORDER_DATE    = STR_TO_DATE(:f_order_date,'%Y/%m/%d')                            ");
			sql.append("	              AND A.ORDER_TIME    = :f_order_time                                                    ");
			sql.append("	              AND A.BUNHO         = :f_bunho                                                         ");
			sql.append("	              AND A.JUBSU_DATE    IS NOT NULL                                                        ");
			sql.append("	              AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                   ");
			sql.append("	              AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                  ");
			sql.append("	              AND B.EMERGENCY     = A.EMERGENCY                                                      ");
			sql.append("	            GROUP BY A.HOSP_CODE,                                                                    ");
			sql.append("	                  A.SPECIMEN_CODE,                                                                   ");
			sql.append("	                  A.TUBE_CODE,                                                                       ");
			sql.append("	                  A.IN_OUT_GUBUN,                                                                    ");
			sql.append("	                  A.SPECIMEN_SER,                                                                    ");
			sql.append("	                  A.GWA,                                                                             ");
			sql.append("	                  A.BUNHO      ) X                                                                   ");
			sql.append("	  WHERE X.HOSP_CODE = :f_hosp_code                                                                   ");
			sql.append("	  GROUP BY X.TUBE_CODE, X.TUBE_NAME                                                                  ");
			sql.append("	  ORDER BY X.TUBE_CODE                                                                               ");
		}
		else if("3".equals(sqlIndex)){
			sql.append("	SELECT X.TUBE_CODE,                                                                                  ");
			sql.append("	     IFNULL(X.TUBE_NAME, '') AS TUBE_NAME,                                                           ");
			sql.append("	     IFNULL(CAST(SUM(X.TUBE_COUNT) AS CHAR), '0')   CNT                                              ");
			sql.append("	FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,                                         ");
			sql.append("	                  MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code, :f_language)) TUBE_NAME,       ");
			sql.append("	                  1                                                  				TUBE_COUNT,      ");
			sql.append("	                  A.HOSP_CODE                                                                        ");
			sql.append("	             FROM CPL0101 B,                                                                         ");
			sql.append("	                  CPL2010 A                                                                          ");
			sql.append("	            WHERE A.HOSP_CODE     = :f_hosp_code                                                     ");
			sql.append("	              AND B.HOSP_CODE     = A.HOSP_CODE                                                      ");
			sql.append("	              AND A.ORDER_DATE    = STR_TO_DATE(:f_order_date,'%Y/%m/%d')                            ");
			sql.append("	              AND A.ORDER_TIME    = :f_order_time                                                    ");
			sql.append("	              AND A.BUNHO         = :f_bunho                                                         ");
			sql.append("	              AND A.JUBSU_DATE    IS NULL                                                            ");
			sql.append("	              AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                   ");
			sql.append("	              AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                  ");
			sql.append("	              AND B.EMERGENCY     = A.EMERGENCY                                                      ");
			sql.append("	            GROUP BY A.HOSP_CODE,                                                                    ");
			sql.append("	                  A.SPECIMEN_CODE,                                                                   ");
			sql.append("	                  A.TUBE_CODE,                                                                       ");
			sql.append("	                  A.IN_OUT_GUBUN,                                                                    ");
			sql.append("	                  A.GWA,                                                                             ");
			sql.append("	                  A.BUNHO      ) X                                                                   ");
			sql.append("	WHERE X.HOSP_CODE = :f_hosp_code                                                                     ");
			sql.append("	GROUP BY X.TUBE_CODE, X.TUBE_NAME                                                                    ");
			sql.append("	ORDER BY X.TUBE_CODE                                                                                 ");
		} else {
			return null;
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		if("1".equals(sqlIndex)){
			query.setParameter("f_jubsu_date", jubsuDate);
			query.setParameter("f_jubsu_time", jubsuTime);
			query.setParameter("f_reser_date", reserDate);
			query.setParameter("f_reser_yn", reserYn);
		}
		else if("2".equals(sqlIndex) || "3".equals(sqlIndex)){
			query.setParameter("f_order_date", jubsuDate);
			query.setParameter("f_order_time", jubsuTime);
		}
		
		 List<CPL2010U01grdTubeInfo> listResult = new JpaResultMapper().list(query, CPL2010U01grdTubeInfo.class);
		 return listResult;
	}

	@Override
	public List<CPL2010U01layBarcodeTempInfo> getCPL2010U01layBarcodeTempInfo(String hospCode, String language,
			Date jubsuDate, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT MIN(A.JUNDAL_GUBUN)                             	JUNDAL_GUBUN                                                                                                             ");
//		sql.append("	     , '' 												JUNDAL_GUBUN_NAME                                                                                                        ");
		sql.append("	     , MIN(A.SPECIMEN_CODE)                     		SPECIMEN_CODE                                                                                                            ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language)))                       ");
		sql.append("															SPECIMEN_NAME                                                                                                            ");
		sql.append("	     , MIN(B.OUT_TUBE2)                        			TUBE_CODE                                                                                                                ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',B.OUT_TUBE2, :f_hosp_code, :f_language)                                                                                               ");
		sql.append("			,IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE, :f_hosp_code, :f_language))))                                ");
		sql.append("															TUBE_NAME                                                                                                                ");
		sql.append("	     , IF(B.UITAK_CODE = '00', '内', '外')            	IN_OUT_GUBUN                                                                                                             ");
		sql.append("	     , IFNULL(A.SPECIMEN_SER,'')                        SPECIMEN_SER                                                                                                             ");
		sql.append("	     , MIN(A.BUNHO)                                     BUNHO                                                                                                                    ");
		sql.append("	     , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))             SUNAME                                                                                                                   ");
		sql.append("	     , MIN(IF(A.IN_OUT_GUBUN = 'I',FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(), :f_hosp_code, :f_language),FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(), :f_hosp_code, :f_language)))       ");
		sql.append("															GWA_NAME                                                                                                                 ");
		sql.append("	     , ' '                                             	DANGER_YN                                                                                                                ");
		sql.append("	     , IFNULL(CONCAT('a',A.SPECIMEN_SER,'a'),'')        SPECIMEN_SER_BA                                                                                                          ");
		sql.append("	     , MIN(A.JANGBI_CODE)                              	JANGBI_CODE                                                                                                              ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE, :f_hosp_code, :f_language)))                           ");
		sql.append("															JANGBI_NAME                                                                                                              ");
		sql.append("	     , MIN(CONCAT(SUBSTR(A.SPECIMEN_SER,5,2),'-',SUBSTR(A.SPECIMEN_SER,7)))                                                                                                      ");
		sql.append("															GUMSA_NAME_RE                                                                                                            ");
		sql.append("	     , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)   TUBE_COUNT                                                                                                               ");
		sql.append("	     , IFNULL(MIN(CONCAT(D.CODE_NAME_RE2,IF(D.CODE_NAME_RE2 IS NULL,NULL,'mL'))),'')                                                                                             ");
		sql.append("															TUBE_MAX_AMT                                                                                                             ");
		sql.append("	     , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))                                                                                 ");
		sql.append("															TUBE_NUMBERING                                                                                                           ");
		sql.append("	  FROM CPL2010 A                                                                                                                                                                 ");
		sql.append("	  JOIN CPL0101 B ON B.HOSP_CODE     = A.HOSP_CODE                                                                                                                                ");
		sql.append("				    AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                             ");
		sql.append("				    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                            ");
		sql.append("				    AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                ");
		sql.append("	  JOIN OUT0101 C ON C.HOSP_CODE     = A.HOSP_CODE                                                                                                                                ");
		sql.append("					AND C.BUNHO         = A.BUNHO                                                                                                                                    ");
		sql.append("	  LEFT JOIN CPL0109 D ON D.HOSP_CODE  = A.HOSP_CODE                                                                                                                              ");
		sql.append("						 AND D.CODE_TYPE  = '02'                                                                                                                                     ");
		sql.append("						 AND D.CODE       = B.TUBE_CODE                                                                                                                              ");
		sql.append("	 WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                            ");
		sql.append("	   AND (  (A.DUMMY     = 'Y')                                                                                                                                                    ");
		sql.append("	        OR(A.UPD_ID    = 'CPLPRT')                                                                                                                                               ");
		sql.append("	       )                                                                                                                                                                         ");
		sql.append("	   AND A.JUBSU_DATE    = :f_jubsu_date                                                                                                                                           ");
		sql.append("	   AND A.BUNHO         = :f_bunho                                                                                                                                                ");
		sql.append("	   AND B.OUT_TUBE2 IS NOT NULL                                                                                                                                                   ");
		sql.append("	 GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.OUT_TUBE2                                                                                                                              ");
		sql.append("	                                                                                                                                                                                 ");
		sql.append("	 UNION                                                                                                                                                                           ");
		sql.append("	                                                                                                                                                                                 ");
		sql.append("	SELECT DISTINCT                                                                                                                                                                  ");
		sql.append("	       MIN(A.JUNDAL_GUBUN)                             	JUNDAL_GUBUN                                                                                                             ");
//		sql.append("	     , '' 												JUNDAL_GUBUN_NAME                                                                                                        ");
		sql.append("	     , MIN(A.SPECIMEN_CODE)                     		SPECIMEN_CODE                                                                                                            ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language)))                       ");
		sql.append("															SPECIMEN_NAME                                                                                                            ");
		sql.append("	     , MIN(B.TUBE_CODE)                                	TUBE_CODE                                                                                                                ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE, :f_hosp_code, :f_language)))                               ");
		sql.append("															TUBE_NAME                                                                                                                ");
		sql.append("	     , IF(B.UITAK_CODE = '00', '内', '外')            	IN_OUT_GUBUN                                                                                                             ");
		sql.append("	     , IFNULL(A.SPECIMEN_SER,'')                        SPECIMEN_SER                                                                                                             ");
		sql.append("	     , MIN(A.BUNHO)                                     BUNHO                                                                                                                    ");
		sql.append("	     , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))             SUNAME                                                                                                                   ");
		sql.append("	     , MIN(IF(A.IN_OUT_GUBUN = 'I',FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(), :f_hosp_code, :f_language),FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(), :f_hosp_code, :f_language)))       ");
		sql.append("															GWA_NAME                                                                                                                 ");
		sql.append("	     , ' '                                             	DANGER_YN                                                                                                                ");
		sql.append("	     , IFNULL(CONCAT('a',A.SPECIMEN_SER,'a'),'')        SPECIMEN_SER_BA                                                                                                          ");
		sql.append("	     , MIN(A.JANGBI_CODE)                              	JANGBI_CODE                                                                                                              ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE, :f_hosp_code, :f_language)))                           ");
		sql.append("															JANGBI_NAME                                                                                                              ");
		sql.append("	     , MIN(CONCAT(SUBSTR(A.SPECIMEN_SER,5,2),'-',SUBSTR(A.SPECIMEN_SER,7)))                                                                                                      ");
		sql.append("															GUMSA_NAME_RE                                                                                                            ");
		sql.append("	     , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)   TUBE_COUNT                                                                                                               ");
		sql.append("	     , IFNULL(MIN(CONCAT(D.CODE_NAME_RE2,IF(D.CODE_NAME_RE2 IS NULL,NULL,'mL'))),'')                                                                                             ");
		sql.append("															TUBE_MAX_AMT                                                                                                             ");
		sql.append("	     , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))                                                                                 ");
		sql.append("															TUBE_NUMBERING                                                                                                           ");
		sql.append("	  FROM CPL2010 A                                                                                                                                                                 ");
		sql.append("	  JOIN CPL0101 B ON A.HOSP_CODE     = B.HOSP_CODE                                                                                                                                ");
		sql.append("					AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                             ");
		sql.append("				    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                            ");
		sql.append("				    AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                ");
		sql.append("	  JOIN OUT0101 C ON C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                ");
		sql.append("					AND C.BUNHO         = A.BUNHO                                                                                                                                    ");
		sql.append("	  LEFT JOIN CPL0109 D ON D.HOSP_CODE = B.HOSP_CODE                                                                                                                               ");
		sql.append("						 AND D.CODE_TYPE = '02'                                                                                                                                      ");
		sql.append("						 AND D.CODE	     = B.TUBE_CODE                                                                                                                               ");
		sql.append("	 WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                            ");
		sql.append("	   AND (  (A.DUMMY     = 'Y')                                                                                                                                                    ");
		sql.append("	        OR(A.UPD_ID    = 'CPLPRT')                                                                                                                                               ");
		sql.append("	       )                                                                                                                                                                         ");
		sql.append("	   AND A.JUBSU_DATE    = :f_jubsu_date                                                                                                                                           ");
		sql.append("	   AND A.BUNHO         = :f_bunho                                                                                                                                                ");
		sql.append("	 GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.JANGBI_OUT_CODE3                                                                                                                       ");
		sql.append("	 ORDER BY  TUBE_CODE, SPECIMEN_SER                                                                                                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_bunho", bunho);
		
		List<CPL2010U01layBarcodeTempInfo> listResult = new JpaResultMapper().list(query, CPL2010U01layBarcodeTempInfo.class);
		return listResult;
	}

	@Override
	public List<CPL2010U01layBarcodeTempInfo2> getCPL2010U01layBarcodeTempInfo2(String hospCode, String language,
			String specimenSer) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT MIN(A.JUNDAL_GUBUN)                             JUNDAL_GUBUN                                                                                                                   ");
//		sql.append("	     , '' 												JUNDAL_GUBUN_NAME                                                                                                              ");
//		sql.append("	     , ' '                                             	SPECIMEN_CODE                                                                                                                  ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language)))                             ");
		sql.append("															SPECIMEN_NAME                                                                                                                  ");
		sql.append("	     , MIN(IFNULL(B.JANGBI_OUT_CODE3,B.OUT_TUBE2))      TUBE_CODE                                                                                                                      ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',B.OUT_TUBE2, :f_hosp_code, :f_language)                                                                                                     ");
		sql.append("	     	,IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE, :f_hosp_code, :f_language))))                                      ");
		sql.append("															TUBE_NAME                                                                                                                      ");
		sql.append("	     , IF(B.UITAK_CODE = '00', '内', '外')            	IN_OUT_GUBUN                                                                                                                   ");
		sql.append("	     , IFNULL(A.SPECIMEN_SER,'')                          			SPECIMEN_SER                                                                                                       ");
		sql.append("	     , MIN(A.BUNHO)                                     BUNHO                                                                                                                          ");
		sql.append("	     , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))               	SUNAME                                                                                                                     ");
		sql.append("	     , MIN(IF(A.IN_OUT_GUBUN = 'I',FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(), :f_hosp_code, :f_language),FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(), :f_hosp_code, :f_language)))             ");
		sql.append("															GWA_NAME                                                                                                                       ");
//		sql.append("	     , ' '                                             	DANGER_YN                                                                                                                      ");
		sql.append("	     , IFNULL(CONCAT('a',A.SPECIMEN_SER,'a'), '')                        	SPECIMEN_SER_BA                                                                                            ");
		sql.append("	     , MIN(A.JANGBI_CODE)                              	JANGBI_CODE                                                                                                                    ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE, :f_hosp_code, :f_language)))                                 ");
		sql.append("															JANGBI_NAME                                                                                                                    ");
		sql.append("	     , IFNULL(MIN(CONCAT(SUBSTR(A.SPECIMEN_SER,5,2),'-',SUBSTR(A.SPECIMEN_SER,7),'')),'')                                                                                              ");
		sql.append("															GUMSA_NAME_RE                                                                                                                  ");
		sql.append("	     , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER, :f_hosp_code)               	TUBE_COUNT                                                                                                     ");
		sql.append("	     , IFNULL(MIN(CONCAT(D.CODE_NAME_RE2,IF(D.CODE_NAME_RE2 IS NULL,NULL,'mL'))),'')                                                                                                   ");
		sql.append("															TUBE_MAX_AMT                                                                                                                   ");
		sql.append("	     , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))                                                                                       ");
		sql.append("															TUBE_NUMBERING                                                                                                                 ");
		sql.append("	  FROM CPL2010 A                                                                                                                                                                       ");
		sql.append("	  JOIN CPL0101 B ON B.HOSP_CODE		= A.HOSP_CODE                                                                                                                                      ");
		sql.append("					AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                                   ");
		sql.append("				    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                                  ");
		sql.append("				    AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                      ");
		sql.append("	  JOIN OUT0101 C ON C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                      ");
		sql.append("					AND C.BUNHO         = A.BUNHO                                                                                                                                          ");
		sql.append("	  LEFT JOIN CPL0109 D ON D.HOSP_CODE = B.HOSP_CODE                                                                                                                                     ");
		sql.append("						 AND D.CODE_TYPE = '02'                                                                                                                                            ");
		sql.append("						 AND D.CODE 	 = B.TUBE_CODE                                                                                                                                     ");
		sql.append("	 WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                                  ");
		sql.append("	   AND A.SPECIMEN_SER  = :f_specimen_ser                                                                                                                                               ");
		sql.append("	   AND B.OUT_TUBE2 IS NOT NULL                                                                                                                                                         ");
		sql.append("	 GROUP BY A.SPECIMEN_SER, B.UITAK_CODE, B.OUT_TUBE2                                                                                                                                    ");
		sql.append("	                                                                                                                                                                                       ");
		sql.append("	UNION                                                                                                                                                                                   ");
		sql.append("	                                                                                                                                                                                       ");
		sql.append("	SELECT DISTINCT                                                                                                                                                                        ");
		sql.append("	       MIN(A.JUNDAL_GUBUN)                             	JUNDAL_GUBUN                                                                                                                   ");
//		sql.append("	     , '' 												JUNDAL_GUBUN_NAME                                                                                                              ");
//		sql.append("	     , ' '                                             	SPECIMEN_CODE                                                                                                                  ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language)))                             ");
		sql.append("															SPECIMEN_NAME                                                                                                                  ");
		sql.append("	     , MIN(B.TUBE_CODE)                                	TUBE_CODE                                                                                                                      ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('02',A.TUBE_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('02',A.TUBE_CODE, :f_hosp_code, :f_language)))                                     ");
		sql.append("															TUBE_NAME                                                                                                                      ");
		sql.append("	     , IF(B.UITAK_CODE = '00', '内', '外')            IN_OUT_GUBUN                                                                                                                       ");
		sql.append("	     , IFNULL(A.SPECIMEN_SER,'')                          			SPECIMEN_SER                                                                                                       ");
		sql.append("	     , MIN(A.BUNHO)                                     BUNHO                                                                                                                          ");
		sql.append("	     , MIN(IFNULL(C.SUNAME2,'NO KATAKANA'))               	SUNAME                                                                                                                     ");
		sql.append("	     , MIN(IF(A.IN_OUT_GUBUN = 'I',FN_BAS_LOAD_GWA_NAME(A.HO_DONG,SYSDATE(), :f_hosp_code, :f_language),FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(), :f_hosp_code, :f_language)))             ");
		sql.append("															GWA_NAME                                                                                                                       ");
//		sql.append("	     , ' '                                             	DANGER_YN                                                                                                                      ");
		sql.append("	     , IFNULL(CONCAT('a',A.SPECIMEN_SER,'a'), '')                        	SPECIMEN_SER_BA                                                                                            ");
		sql.append("	     , MIN(A.JANGBI_CODE)                              	JANGBI_CODE                                                                                                                    ");
		sql.append("	     , MIN(IFNULL(FN_CPL_CODE_NAME_RE('07',B.JANGBI_CODE, :f_hosp_code, :f_language),FN_CPL_CODE_NAME('07',B.JANGBI_CODE, :f_hosp_code, :f_language)))                                 ");
		sql.append("															JANGBI_NAME                                                                                                                    ");
		sql.append("	     , IFNULL(MIN(CONCAT(SUBSTR(A.SPECIMEN_SER,5,2),'-',SUBSTR(A.SPECIMEN_SER,7))),'')                                                                                                 ");
		sql.append("															GUMSA_NAME_RE                                                                                                                  ");
		sql.append("	     , FN_CPL_TUBE_COUNT(A.SPECIMEN_SER, :f_hosp_code)               	TUBE_COUNT                                                                                                     ");
		sql.append("	     , IFNULL(MIN(CONCAT(D.CODE_NAME_RE2,IF(D.CODE_NAME_RE2 IS NULL,NULL,'mL')))   ,'')                                                                                                ");
		sql.append("															TUBE_MAX_AMT                                                                                                                   ");
		sql.append("	     , MIN(FN_CPL_TUBE_NUMBERING(A.BUNHO,A.ORDER_DATE,A.ORDER_TIME,A.SPECIMEN_SER,:f_hosp_code))                                                                                       ");
		sql.append("															TUBE_NUMBERING                                                                                                                 ");
		sql.append("	  FROM CPL2010 A                                                                                                                                                                       ");
		sql.append("	  JOIN CPL0101 B ON B.HOSP_CODE 	= A.HOSP_CODE                                                                                                                                      ");
		sql.append("					AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                                                   ");
		sql.append("				    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                                                                  ");
		sql.append("				    AND B.EMERGENCY     = A.EMERGENCY                                                                                                                                      ");
		sql.append("	  JOIN OUT0101 C ON C.HOSP_CODE     = B.HOSP_CODE                                                                                                                                      ");
		sql.append("					AND C.BUNHO         = A.BUNHO                                                                                                                                          ");
		sql.append("	  LEFT JOIN CPL0109 D ON D.HOSP_CODE = B.HOSP_CODE                                                                                                                                     ");
		sql.append("						 AND D.CODE_TYPE = '02'                                                                                                                                            ");
		sql.append("					     AND D.CODE   	 = B.TUBE_CODE                                                                                                                                     ");
		sql.append("	 WHERE B.HOSP_CODE     = :f_hosp_code                                                                                                                                                  ");
		sql.append("	   AND A.SPECIMEN_SER  = :f_specimen_ser                                                                                                                                               ");
		sql.append("	 GROUP BY A.SPECIMEN_SER, B.UITAK_CODE,  A.JUNDAL_GUBUN                                                                                                                                ");
		sql.append("	 ORDER BY TUBE_CODE,SPECIMEN_SER                                                                                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<CPL2010U01layBarcodeTempInfo2> listResult = new JpaResultMapper().list(query, CPL2010U01layBarcodeTempInfo2.class);
		return listResult;
	}

	@Override
	public List<CPL2010U01grdTubeInfo> getXCPL2010U01grdTubeInfo(String hospCode, String language, String jubsuDate,
			String jubsuTime, String bunho, Date reserDate, String reserYn) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT X.TUBE_CODE,                                                                                       ");
		sql.append("	       X.TUBE_NAME,                                                                                       ");
		sql.append("	       IFNULL(CAST(SUM(X.TUBE_COUNT) AS CHAR), '0')   CNT                                                  ");
		sql.append("	  FROM (     SELECT MIN(A.TUBE_CODE)            TUBE_CODE,                                                ");
		sql.append("	                    MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE,:f_hosp_code,:f_language))    TUBE_NAME,        ");
		sql.append("	                    FN_CPL_TUBE_COUNT(A.SPECIMEN_SER,:f_hosp_code)       TUBE_COUNT                       ");
		sql.append("	               FROM CPL0101 B,                                                                            ");
		sql.append("	                    CPL2010 A                                                                             ");
		sql.append("	              WHERE A.HOSP_CODE     = :f_hosp_code                                                        ");
		sql.append("	                AND B.HOSP_CODE     = A.HOSP_CODE                                                         ");
		sql.append("	                AND A.JUBSU_DATE    = STR_TO_DATE(:f_jubsu_date,'%Y/%m/%d')                               ");
		sql.append("	                AND A.JUBSU_TIME    = :f_jubsu_time                                                       ");
		sql.append("	                AND A.BUNHO         = :f_bunho                                                            ");
		sql.append("	                AND (  :f_reser_date IS NOT NULL AND A.RESER_DATE = :f_reser_date                         ");
		sql.append("	                    OR :f_reser_date IS NULL )                                                            ");
		sql.append("	                AND (  :f_reser_yn = 'Y' AND A.RESER_DATE IS NOT NULL                                     ");
		sql.append("	                    OR :f_reser_yn = 'N' )AND A.JUBSU_DATE    IS NOT NULL                                 ");
		sql.append("	                AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                      ");
		sql.append("	                AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                     ");
		sql.append("	                AND B.EMERGENCY     = A.EMERGENCY                                                         ");
		sql.append("	              GROUP BY A.JUNDAL_GUBUN,                                                                    ");
		sql.append("	                    A.SPECIMEN_CODE,                                                                      ");
		sql.append("	                    A.TUBE_CODE,                                                                          ");
		sql.append("	                    A.IN_OUT_GUBUN,                                                                       ");
		sql.append("	                    A.SPECIMEN_SER,                                                                       ");
		sql.append("	                    A.GWA,                                                                                ");
		sql.append("	                    A.BUNHO       ) X                                                                     ");
		sql.append("	 GROUP BY X.TUBE_CODE, X.TUBE_NAME                                                                        ");
		sql.append("	 ORDER BY X.TUBE_CODE                                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_jubsu_time", jubsuTime);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_reser_yn", reserYn);
		
		List<CPL2010U01grdTubeInfo> listResult = new JpaResultMapper().list(query, CPL2010U01grdTubeInfo.class);
		return listResult;
	}

	@Override
	public List<CPL2010U02layBarcodeInfo> getCPL2010U02layBarcodeInfo(String hospCode, String language,
			String specimenSer) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT                                                                                                                                                                                 ");
		sql.append("	     /*'' JUNDAL_GUBUN                                                                                                                                                                 ");
		sql.append("	    ,'' JUNDAL_GUBUN_NAME*/                                                                                                                                                            ");
		sql.append("	     MIN( A.SPECIMEN_CODE ) 						SPECIMEN_CODE                                                                                                                      ");
		sql.append("	    ,MIN( IFNULL( FN_CPL_CODE_NAME_RE( '04' , A.SPECIMEN_CODE, :f_hosp_code, :f_language), FN_CPL_CODE_NAME( '04' , A.SPECIMEN_CODE, :f_hosp_code, :f_language)))                      ");
		sql.append("														SPECIMEN_NAME                                                                                                                      ");
		sql.append("	    ,MIN( B.OUT_TUBE2 ) 							TUBE_CODE                                                                                                                          ");
		sql.append("	    ,MIN( IFNULL( FN_CPL_CODE_NAME_RE( '02' , B.OUT_TUBE2, :f_hosp_code, :f_language)                                                                                                  ");
		sql.append("			, IFNULL( FN_CPL_CODE_NAME_RE( '02' , A.TUBE_CODE, :f_hosp_code, :f_language), FN_CPL_CODE_NAME( '02' , A.TUBE_CODE, :f_hosp_code, :f_language))))                             ");
		sql.append("														TUBE_NAME                                                                                                                          ");
		sql.append("	    ,IFNULL( B.UITAK_CODE , MAX( A.EMERGENCY )) 	IN_OUT_GUBUN                                                                                                                       ");
		sql.append("	    ,A.SPECIMEN_SER 								SPECIMEN_SER                                                                                                                       ");
		sql.append("	    ,MIN( A.BUNHO ) 								BUNHO                                                                                                                              ");
		sql.append("	    ,MIN( IFNULL( C.SUNAME2 , 'NO KATAKANA' )) 		SUNAME                                                                                                                             ");
		sql.append("	    ,MIN( IF(A.IN_OUT_GUBUN = 'I' , FN_BAS_LOAD_GWA_NAME( A.HO_DONG , SYSDATE(), :f_hosp_code, :f_language), FN_BAS_LOAD_GWA_NAME( A.GWA , SYSDATE(), :f_hosp_code, :f_language)))     ");
		sql.append("														GWA_NAME                                                                                                                           ");
		sql.append("	    ,' ' 											DANGER_YN                                                                                                                          ");
		sql.append("	    ,IFNULL(CONCAT('a',A.SPECIMEN_SER,'a'),'')		SPECIMEN_SER_BA                                                                                                                    ");
		sql.append("	    ,MIN( A.JANGBI_CODE ) 							JANGBI_CODE                                                                                                                        ");
		sql.append("	    ,MIN( IFNULL( FN_CPL_CODE_NAME_RE( '07' , B.JANGBI_CODE, :f_hosp_code, :f_language), FN_CPL_CODE_NAME( '07' , B.JANGBI_CODE, :f_hosp_code, :f_language)))                          ");
		sql.append("														JANGBI_NAME                                                                                                                        ");
		sql.append("	    ,MIN(CONCAT(SUBSTR( A.SPECIMEN_SER , 5 , 2 ),'-' ,SUBSTR( A.SPECIMEN_SER , 7 ))) 		                                                                                           ");
		sql.append("														GUMSA_NAME_RE                                                                                                                      ");
		sql.append("	    ,FN_CPL_TUBE_COUNT(A.SPECIMEN_SER, :f_hosp_code)                                                                                                                                   ");
		sql.append("														TUBE_COUNT                                                                                                                         ");
		sql.append("	    ,MIN(CONCAT(D.CODE_NAME_RE2,IF(D.CODE_NAME_RE2 IS NULL , NULL , 'mL' )))                                                                                                           ");
		sql.append("														TUBE_MAX_AMT                                                                                                                       ");
		sql.append("	    ,MIN( FN_CPL_TUBE_NUMBERING ( A.BUNHO , A.ORDER_DATE , A.ORDER_TIME , A.SPECIMEN_SER, :f_hosp_code))                                                                               ");
		sql.append("														TUBE_NUMBERING                                                                                                                     ");
		sql.append("	FROM CPL2010 A                                                                                                                                                                         ");
		sql.append("	JOIN CPL0101 B ON B.HOSP_CODE = A.HOSP_CODE                                                                                                                                            ");
		sql.append("				  AND B.HANGMOG_CODE 	= A.HANGMOG_CODE                                                                                                                                   ");
		sql.append("				  AND B.SPECIMEN_CODE 	= A.SPECIMEN_CODE                                                                                                                                  ");
		sql.append("				  AND B.EMERGENCY 		= A.EMERGENCY                                                                                                                                      ");
		sql.append("	JOIN OUT0101 C ON C.BUNHO 		= A.BUNHO                                                                                                                                              ");
		sql.append("				  AND C.HOSP_CODE 	= A.HOSP_CODE                                                                                                                                          ");
		sql.append("	LEFT JOIN CPL0109 D ON D.HOSP_CODE = A.HOSP_CODE                                                                                                                                       ");
		sql.append("					   AND D.CODE 	   = B.TUBE_CODE                                                                                                                                       ");
		sql.append("					   AND D.CODE_TYPE = '02'                                                                                                                                              ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                                                       ");
		sql.append("	  AND A.SPECIMEN_SER = :f_specimen_ser                                                                                                                                                 ");
		sql.append("	  AND B.OUT_TUBE2 IS NOT NULL                                                                                                                                                          ");
		sql.append("	GROUP BY A.SPECIMEN_SER ,B.UITAK_CODE                                                                                                                                                  ");
		sql.append("	                                                                                                                                                                                       ");
		sql.append("	UNION                                                                                                                                                                                  ");
		sql.append("	                                                                                                                                                                                       ");
		sql.append("	SELECT                                                                                                                                                                                 ");
		sql.append("		DISTINCT                                                                                                                                                                           ");
		sql.append("		 /*'' JUNDAL_GUBUN                                                                                                                                                                 ");
		sql.append("		,'' JUNDAL_GUBUN_NAME*/                                                                                                                                                            ");
		sql.append("		 MIN( A.SPECIMEN_CODE ) 						SPECIMEN_CODE                                                                                                                      ");
		sql.append("		,MIN( IFNULL( FN_CPL_CODE_NAME_RE( '04' , A.SPECIMEN_CODE, :f_hosp_code, :f_language), FN_CPL_CODE_NAME( '04' , A.SPECIMEN_CODE, :f_hosp_code, :f_language)))                      ");
		sql.append("														SPECIMEN_NAME                                                                                                                      ");
		sql.append("		,MIN( B.TUBE_CODE ) 							TUBE_CODE                                                                                                                          ");
		sql.append("		,MIN( IFNULL( FN_CPL_CODE_NAME_RE( '02' , A.TUBE_CODE, :f_hosp_code, :f_language), FN_CPL_CODE_NAME( '02' , A.TUBE_CODE, :f_hosp_code, :f_language)))                              ");
		sql.append("														TUBE_NAME                                                                                                                          ");
		sql.append("		,IFNULL( B.UITAK_CODE , MAX( A.EMERGENCY )) 	IN_OUT_GUBUN                                                                                                                       ");
		sql.append("		,A.SPECIMEN_SER 								SPECIMEN_SER                                                                                                                       ");
		sql.append("		,MIN( A.BUNHO ) 								BUNHO                                                                                                                              ");
		sql.append("		,MIN( IFNULL( C.SUNAME2 , 'NO KATAKANA' )) 		SUNAME                                                                                                                             ");
		sql.append("		,MIN( IF( A.IN_OUT_GUBUN = 'I' , FN_BAS_LOAD_GWA_NAME( A.HO_DONG , SYSDATE(), :f_hosp_code, :f_language), FN_BAS_LOAD_GWA_NAME( A.GWA , SYSDATE(), :f_hosp_code, :f_language)))    ");
		sql.append("														GWA_NAME                                                                                                                           ");
		sql.append("		,' ' 											DANGER_YN                                                                                                                          ");
		sql.append("		,IFNULL(CONCAT('a',A.SPECIMEN_SER,'a'),'') 		SPECIMEN_SER_BA                                                                                                                    ");
		sql.append("		,MIN( A.JANGBI_CODE ) 							JANGBI_CODE                                                                                                                        ");
		sql.append("		,MIN( IFNULL( FN_CPL_CODE_NAME_RE( '07' , B.JANGBI_CODE, :f_hosp_code, :f_language), FN_CPL_CODE_NAME( '07' , B.JANGBI_CODE, :f_hosp_code, :f_language)))                          ");
		sql.append("														JANGBI_NAME                                                                                                                        ");
		sql.append("		,MIN(CONCAT(SUBSTR( A.SPECIMEN_SER , 5 , 2 ),'-',SUBSTR( A.SPECIMEN_SER , 7 )))                                                                                                    ");
		sql.append("														GUMSA_NAME_RE                                                                                                                      ");
		sql.append("		,FN_CPL_TUBE_COUNT(A.SPECIMEN_SER, :f_hosp_code)                                                                                                                                   ");
		sql.append("														TUBE_COUNT                                                                                                                         ");
		sql.append("		,MIN(CONCAT(D.CODE_NAME_RE2, IF( D.CODE_NAME_RE2 IS NULL , NULL , 'mL' )))                                                                                                         ");
		sql.append("														TUBE_MAX_AMT                                                                                                                       ");
		sql.append("		,MIN( FN_CPL_TUBE_NUMBERING ( A.BUNHO , A.ORDER_DATE , A.ORDER_TIME , A.SPECIMEN_SER, :f_hosp_code))                                                                               ");
		sql.append("														TUBE_NUMBERING                                                                                                                     ");
		sql.append("	FROM CPL2010 A                                                                                                                                                                         ");
		sql.append("	JOIN CPL0101 B ON B.HOSP_CODE 		= A.HOSP_CODE                                                                                                                                      ");
		sql.append("				  AND B.HANGMOG_CODE 	= A.HANGMOG_CODE                                                                                                                                   ");
		sql.append("				  AND B.SPECIMEN_CODE 	= A.SPECIMEN_CODE                                                                                                                                  ");
		sql.append("				  AND B.EMERGENCY 		= A.EMERGENCY                                                                                                                                      ");
		sql.append("	JOIN OUT0101 C ON C.BUNHO = A.BUNHO                                                                                                                                                    ");
		sql.append("				  AND C.HOSP_CODE 	= A.HOSP_CODE                                                                                                                                          ");
		sql.append("	LEFT JOIN CPL0109 D ON D.HOSP_CODE = A.HOSP_CODE                                                                                                                                       ");
		sql.append("					   AND D.CODE_TYPE = '02'                                                                                                                                              ");
		sql.append("					   AND D.CODE 	   = B.TUBE_CODE                                                                                                                                       ");
		sql.append("	WHERE A.SPECIMEN_SER = :f_specimen_ser                                                                                                                                                 ");
		sql.append("	GROUP BY A.SPECIMEN_SER ,B.UITAK_CODE                                                                                                                                                  ");
		sql.append("	ORDER BY TUBE_CODE, SPECIMEN_SER                                                                                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<CPL2010U02layBarcodeInfo> listResult = new JpaResultMapper().list(query, CPL2010U02layBarcodeInfo.class);
		return listResult;
	}
	
}


