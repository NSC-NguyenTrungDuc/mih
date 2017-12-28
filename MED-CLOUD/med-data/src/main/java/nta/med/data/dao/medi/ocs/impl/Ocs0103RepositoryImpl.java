package nta.med.data.dao.medi.ocs.impl;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.domain.ocs.Ocs0103;
import nta.med.data.model.ihis.bill.BIL2016U00DetailServiceInfo;
import nta.med.data.model.ihis.bill.BIL2016U00ServiceInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0103RepositoryCustom;
import nta.med.data.model.ihis.bass.ComBizGetFindWorkerInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DRG3010Q12AntibioticListgrdAntibioticListInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00SunalAndSubulInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U10GrdDrgOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U10GrdGeneralInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U10SetTabWonnaeDrgInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U10SetTabWonnaeInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U11GrdSlipHangMogListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U11LoadSlipHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U12LoadDrgOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdSangyongOrderListInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdSearchOrderListInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdSpecimenListInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13LaySpecimenTreeListInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U14GrdSlipHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U15GrdSlipHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U16GrdSangyongOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U16GrdSlipHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U17GrdSearchOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0108U00grdOCS0103ItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0113U00GrdOCS0103ListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0118U00GrdOCS0118Info;
import nta.med.data.model.ihis.ocsa.OCS0203U00GrdOcs0203P1Info;
import nta.med.data.model.ihis.ocsa.OCS0311Q00LayDownListQueryEndResInfo;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetHangmogGridFindListInfo;
import nta.med.data.model.ihis.ocsa.OCS0311U00laySetHangmogListInfo;
import nta.med.data.model.ihis.ocsa.Ocs0103Q00LoadOcs0103ListItemInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridReserOrderListInfo;
import nta.med.data.model.ihis.ocso.PrOcsLoadSubulSuryangInfo;
import nta.med.data.model.ihis.pfes.PFE7001Q01LayDailyReportInfo;
import nta.med.data.model.ihis.pfes.PFE7001Q02LayMonthlyReportInfo;
import nta.med.data.model.ihis.system.GetJundaTableResponseInfo;
import nta.med.data.model.ihis.system.LoadHangmogInfo;
import nta.med.data.model.ihis.system.OBGetJundaTable1Info;
import nta.med.data.model.ihis.system.OBLoadSearchOrderInfoDRGInfo;
import nta.med.data.model.ihis.system.OCS0103U12SetTabWonnaeDrugInfo;
import nta.med.data.model.ihis.xrts.XRT0000Q00LayOrderListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdJaeryoItemInfo;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdOrderItemInfo;

/**
 * @author dainguyen.
 */
public class Ocs0103RepositoryImpl implements Ocs0103RepositoryCustom {
	private static final Log LOG = LogFactory
			.getLog(Ocs0103RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OcsoOCS1003P01GridReserOrderListInfo> getOcsoOCS1003P01GridReserOrderList(
			String language, String hospCode, String bunho, String naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT   KIZYUN_DATE,                                                                                       ");
		sql.append("          GWA,                                                                                               ");
		sql.append("          GWA_NAME,                                                                                          ");
		sql.append("          DOCTOR,                                                                                            ");
		sql.append("          DOCTOR_NAME,                                                                                       ");
		sql.append("          HANGMOG_CODE,                                                                                      ");
		sql.append("          HANGMOG_NAME,                                                                                      ");
		sql.append("          JUNDAL_TABLE,                                                                                      ");
		sql.append("          JUNDAL_PART,                                                                                       ");
		sql.append("          JUNDAL_PART_NAME,                                                                                  ");
		sql.append("          RESER_TIME,                                                                                        ");
		sql.append("          RESER_YN,                                                                                          ");
		sql.append("          ACT_YN,                                                                                            ");
		sql.append("          ORDER_DATE,                                                                                        ");
		sql.append("          PKSCH                                                                                              ");
		sql.append("     FROM (SELECT A.RESER_DATE AS KIZYUN_DATE,                                                               ");
		sql.append("                  A.GWA AS GWA,                                                                              ");
		sql.append("                  FN_BAS_LOAD_GWA_NAME(A.GWA, A.INPUT_DATE, :hospCode, :language) AS GWA_NAME,               ");
		sql.append("                  A.DOCTOR AS DOCTOR,                                                                        ");
		sql.append("                  FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, :hospCode)                                 ");
		sql.append("                     AS DOCTOR_NAME,                                                                         ");
		sql.append("                  A.HANGMOG_CODE AS HANGMOG_CODE,                                                            ");
		sql.append("                  B.HANGMOG_NAME AS HANGMOG_NAME,                                                            ");
		sql.append("                  A.JUNDAL_TABLE AS JUNDAL_TABLE,                                                            ");
		sql.append("                  A.JUNDAL_PART AS JUNDAL_PART,                                                              ");
		sql.append("                  C.JUNDAL_PART_NAME AS JUNDAL_PART_NAME,                                                    ");
		sql.append("                  A.RESER_TIME AS RESER_TIME,                                                                ");
		sql.append("                  IF(A.RESER_DATE = NULL, 'N', 'Y') AS RESER_YN,                                             ");
		sql.append("                  IF(A.ACTING_DATE = NULL, 'N', 'Y') AS ACT_YN,                                              ");
		sql.append("                  A.ORDER_DATE AS ORDER_DATE,                                                                ");
		sql.append("                  A.PKSCH0201 AS PKSCH                                                                       ");
		sql.append("             FROM SCH0201 A,                                                                                 ");
		sql.append("                  OCS0103 B,                                                                                 ");
		sql.append("                  SCH0001 C,                                                                                 ");
		sql.append("                  OCS1003 D                                                                                  ");
		sql.append("            WHERE     A.HOSP_CODE = :hospCode                                                                ");
		sql.append("                  AND A.BUNHO = :bunho                                                                       ");
		sql.append("                  AND A.RESER_DATE = DATE_FORMAT(:naewonDate,'%Y/%m/%d')                                     ");
		sql.append("                  AND A.IN_OUT_GUBUN = 'O'                                                                   ");
		sql.append("                  AND A.JUNDAL_TABLE <> 'PHY'                                                                ");
		sql.append("                  AND IFNULL(A.CANCEL_YN, 'N') = 'N'                                                         ");
		sql.append("                  AND B.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("                  AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                        ");
		sql.append("                  AND DATE_FORMAT(:naewonDate,'%Y/%m/%d') BETWEEN B.START_DATE AND B.END_DATE                ");
		sql.append("                  AND C.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("                  AND C.JUNDAL_TABLE = A.JUNDAL_TABLE                                                        ");
		sql.append("                  AND C.JUNDAL_PART = A.JUNDAL_PART                                                          ");
		sql.append("                                                                                                             ");
		sql.append("                  AND D.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("                  AND D.PKOCS1003 = A.FKOCS                                                                  ");
		sql.append("                  AND ( (IFNULL(D.INSTEAD_YN, 'N') = 'N')                                                    ");
		sql.append("                       OR (IFNULL(D.INSTEAD_YN, 'N') = 'Y'                                                   ");
		sql.append("                           AND IFNULL(D.APPROVE_YN, 'N') = 'Y'))                                             ");
		sql.append("           UNION ALL                                                                                         ");
		sql.append("           SELECT B.RESER_DATE AS KIZYUN_DATE,                                                               ");
		sql.append("                  A.GWA AS GWA,                                                                              ");
		sql.append("                  FN_BAS_LOAD_GWA_NAME (A.GWA, B.RESER_DATE, :hospCode, :language) AS GWA_NAME,              ");
		sql.append("                  A.DOCTOR AS DOCTOR,                                                                        ");
		sql.append("                  FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, B.RESER_DATE, :hospCode)                                ");
		sql.append("                     AS DOCTOR_NAME,                                                                         ");
		sql.append("                  B.HANGMOG_CODE AS HANGMOG_CODE,                                                            ");
		sql.append("                  C.HANGMOG_NAME AS HANGMOG_NAME,                                                            ");
		sql.append("                  'INJ' AS JUNDAL_TABLE,                                                                     ");
		sql.append("                  A.JUNDAL_PART AS JUNDAL_PART,                                                              ");
		sql.append("                  D.BUSEO_NAME AS JUNDAL_PART_NAME,                                                          ");
		sql.append("                  B.RESER_TIME AS RESER_TIME,                                                                ");
		sql.append("                  IF(B.RESER_DATE= NULL, 'N', 'Y') AS RESER_YN,                                              ");
		sql.append("                  IF(B.ACTING_DATE = NULL, 'N', 'Y') AS ACT_YN,                                              ");
		sql.append("                  A.ORDER_DATE AS ORDER_DATE,                                                                ");
		sql.append("                  B.PKINJ1002 AS PKSCH                                                                       ");
		sql.append("             FROM BAS0260 D,                                                                                 ");
		sql.append("                  OCS0103 C,                                                                                 ");
		sql.append("                  INJ1002 B,                                                                                 ");
		sql.append("                  INJ1001 A,                                                                                 ");
		sql.append("                  OCS1003 E                                                                                  ");
		sql.append("            WHERE     A.HOSP_CODE = :hospCode                                                                ");
		sql.append("                  AND A.BUNHO = :bunho                                                                       ");
		sql.append("                  AND B.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("                  AND B.FKINJ1001 = A.PKINJ1001                                                              ");
		sql.append("                  AND A.ORDER_DATE <> B.RESER_DATE                                                           ");
		sql.append("                  AND B.RESER_DATE = DATE_FORMAT(:naewonDate,'%Y/%m/%d')                                     ");
		sql.append("                  AND IFNULL(B.DC_YN, 'N') = 'N'                                                             ");
		sql.append("                  AND C.HOSP_CODE = B.HOSP_CODE                                                              ");
		sql.append("                  AND C.HANGMOG_CODE = B.HANGMOG_CODE                                                        ");
		sql.append("                  AND DATE_FORMAT(:naewonDate,'%Y/%m/%d') BETWEEN C.START_DATE AND C.END_DATE                ");
		sql.append("                  AND D.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("                  AND D.GWA = A.JUNDAL_PART                                                                  ");
		sql.append("                  AND D.LANGUAGE = :language                                                                 ");
		sql.append("                  AND DATE_FORMAT(:naewonDate,'%Y/%m/%d') BETWEEN D.START_DATE AND D.END_DATE                ");
		sql.append("                                                                                                             ");
		sql.append("                  AND E.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("                  AND E.PKOCS1003 = A.FKOCS1003                                                              ");
		sql.append("                  AND ( (IFNULL(E.INSTEAD_YN, 'N') = 'N')                                                    ");
		sql.append("                       OR (IFNULL(E.INSTEAD_YN, 'N') = 'Y'                                                   ");
		sql.append("                           AND IFNULL(E.APPROVE_YN, 'N') = 'Y'))) A                                          ");
		sql.append(" ORDER BY KIZYUN_DATE,                                                                                       ");
		sql.append("          ORDER_DATE,                                                                                        ");
		sql.append("          GWA,                                                                                               ");
		sql.append("          DOCTOR,                                                                                            ");
		sql.append("          JUNDAL_TABLE,                                                                                      ");
		sql.append("          JUNDAL_PART,                                                                                       ");
		sql.append("          RESER_TIME,                                                                                        ");
		sql.append("          RESER_YN                                                                                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		query.setParameter("naewonDate", naewonDate);

		List<OcsoOCS1003P01GridReserOrderListInfo> list = new JpaResultMapper()
				.list(query, OcsoOCS1003P01GridReserOrderListInfo.class);

		return list;
	}

	@Override
	public List<PFE7001Q01LayDailyReportInfo> getPFE7001Q01LayDailyReportInfo(
			String hospCode, String language, String kensadate, String ioGubun,
			String partCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT :f_kensa_date                                       GUMSA_DATE                              ");
		sql.append("      , 'O'                                                 IO_GUBUN                               ");
		sql.append("      , A.BUNHO                                             BUNHO                                  ");
		sql.append("      , C.SUNAME                                            SUNAME                                 ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)           GWA           ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)     DOCTOR_NAME               ");
		sql.append("      , (SELECT X.CODE_NAME                                                                        ");
		sql.append("           FROM OCS0132 X                                                                          ");
		sql.append("          WHERE X.HOSP_CODE = A.HOSP_CODE                                                          ");
		sql.append("            AND X.CODE_TYPE = 'OCS_ACT_PART_02'                                                    ");
		sql.append("            AND X.CODE      = A.JUNDAL_PART                                                        ");
		sql.append("            AND X.LANGUAGE  = :f_language)                JUNDAL_PART                              ");
		sql.append("      , A.HANGMOG_CODE                                      HANGMOG_CODE                           ");
		sql.append("      , B.HANGMOG_NAME                                      HANGMOG_NAME                           ");
		sql.append("    FROM OUT0101 C                                                                                 ");
		sql.append("       , OCS0103 B                                                                                 ");
		sql.append("       , OCS1003 A                                                                                 ");
		sql.append("  WHERE A.HOSP_CODE        = :f_hosp_code                                                          ");
		sql.append("    AND IFNULL(A.RESER_DATE, A.ORDER_DATE) = :f_kensa_date                                         ");
		sql.append("    AND 'O'                LIKE :f_io_gubun                                                        ");
		sql.append("    AND A.ACTING_DATE      IS NOT NULL                                                             ");
		sql.append("    AND A.SLIP_CODE        LIKE 'E%'                                                               ");
		sql.append("    AND A.JUNDAL_TABLE     IN ('PFE', 'CPL')                                                       ");
		sql.append("    AND A.JUNDAL_PART      LIKE :f_part_code                                                       ");
		sql.append("    AND IFNULL(A.DC_YN, 'N')  = 'N'                                                                ");
		sql.append("    AND B.HOSP_CODE        = A.HOSP_CODE                                                           ");
		sql.append("    AND B.HANGMOG_CODE     = A.HANGMOG_CODE                                                        ");
		sql.append("    AND B.SG_CODE          IS NOT NULL                                                             ");
		sql.append("    AND A.ORDER_DATE       BETWEEN B.START_DATE AND B.END_DATE                                     ");
		sql.append("    AND C.HOSP_CODE        = A.HOSP_CODE                                                           ");
		sql.append("    AND C.BUNHO            = A.BUNHO                                                               ");
		sql.append(" UNION                                                                                             ");
		sql.append(" SELECT :f_kensa_date                                       GUMSA_DATE                             ");
		sql.append("      , 'I'                                                 IO_GUBUN                               ");
		sql.append("      , A.BUNHO                                             BUNHO                                  ");
		sql.append("      , C.SUNAME                                            SUNAME                                 ");
		sql.append("      , CONCAT(IFNULL(D.HO_DONG,''), '-', IFNULL(D.HO_CODE,''))                       GWA          ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)     DOCTOR_NAME               ");
		sql.append("      , (SELECT X.CODE_NAME                                                                        ");
		sql.append("           FROM OCS0132 X                                                                          ");
		sql.append("          WHERE X.HOSP_CODE = A.HOSP_CODE                                                          ");
		sql.append("            AND X.CODE_TYPE = 'OCS_ACT_PART_02'                                                    ");
		sql.append("            AND X.CODE      = A.JUNDAL_PART                                                        ");
		sql.append("            AND X.LANGUAGE  = :f_language)                JUNDAL_PART                              ");
		sql.append("      , A.HANGMOG_CODE                                      HANGMOG_CODE                           ");
		sql.append("      , B.HANGMOG_NAME                                      HANGMOG_NAME                           ");
		sql.append("    FROM PFE0201 D                                                                                 ");
		sql.append("       , OUT0101 C                                                                                 ");
		sql.append("       , OCS0103 B                                                                                 ");
		sql.append("       , OCS2003 A                                                                                 ");
		sql.append("  WHERE A.HOSP_CODE        = :f_hosp_code                                                          ");
		sql.append("    AND IFNULL(A.RESER_DATE, A.ORDER_DATE) = :f_kensa_date                                         ");
		sql.append("    AND 'I'                LIKE :f_io_gubun                                                        ");
		sql.append("    AND A.ACTING_DATE      IS NOT NULL                                                             ");
		sql.append("    AND A.SLIP_CODE        LIKE 'E%'                                                               ");
		sql.append("    AND A.JUNDAL_TABLE     IN ('PFE', 'CPL')                                                       ");
		sql.append("    AND A.JUNDAL_PART      LIKE :f_part_code                                                       ");
		sql.append("    AND IFNULL(A.DC_YN, 'N')  = 'N'                                                                ");
		sql.append("    AND B.HOSP_CODE        = A.HOSP_CODE                                                           ");
		sql.append("    AND B.HANGMOG_CODE     = A.HANGMOG_CODE                                                        ");
		sql.append("    AND B.SG_CODE          IS NOT NULL                                                             ");
		sql.append("    AND A.ORDER_DATE       BETWEEN B.START_DATE AND B.END_DATE                                     ");
		sql.append("    AND C.HOSP_CODE        = A.HOSP_CODE                                                           ");
		sql.append("    AND C.BUNHO            = A.BUNHO                                                               ");
		sql.append("    AND D.HOSP_CODE        = A.HOSP_CODE                                                           ");
		sql.append("    AND D.FKOCS2003        = A.PKOCS2003                                                           ");
		sql.append("  ORDER BY IO_GUBUN                                                                                ");
		sql.append("         , BUNHO                                                                                   ");
		sql.append("         , GWA                                                                                     ");
		sql.append("         , DOCTOR_NAME                                                                             ");
		sql.append("         , HANGMOG_CODE                                                                            ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_kensa_date", kensadate);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_part_code", partCode);

		List<PFE7001Q01LayDailyReportInfo> list = new JpaResultMapper().list(
				query, PFE7001Q01LayDailyReportInfo.class);

		return list;

	}

	// TODO check message in IFNULL(A.HANGMOG_CODE,FN_ADM_MSG(221,:f_language))
	// HANGMOG_CODE
	@Override
	public List<PFE7001Q02LayMonthlyReportInfo> getPFE7001Q02LayMonthlyReportInfo(
			String hospCode, String language, String fromDate, String toDate,
			String ioGubun, String partCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT   DATE_FORMAT(STR_TO_DATE(X.YYYYMM, '%Y%m'), '%Y/%m/01')            YYYYMM					");
		sql.append("        ,X.HANGMOG_CODE                                                    	HANGMOG_CODE          	");
		sql.append("        , MAX(X.GUMSA_NAME)                                         		GUMSA_NAME              ");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '01' THEN X.CNT END), 0) D01                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '02' THEN X.CNT END), 0) D02                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '03' THEN X.CNT END), 0) D03                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '04' THEN X.CNT END), 0) D04                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '05' THEN X.CNT END), 0) D05                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '06' THEN X.CNT END), 0) D06                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '07' THEN X.CNT END), 0) D07                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '08' THEN X.CNT END), 0) D08                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '09' THEN X.CNT END), 0) D09                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '10' THEN X.CNT END), 0) D10                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '11' THEN X.CNT END), 0) D11                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '12' THEN X.CNT END), 0) D12                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '13' THEN X.CNT END), 0) D13                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '14' THEN X.CNT END), 0) D14                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '15' THEN X.CNT END), 0) D15                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '16' THEN X.CNT END), 0) D16                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '17' THEN X.CNT END), 0) D17                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '18' THEN X.CNT END), 0) D18                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '19' THEN X.CNT END), 0) D19                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '20' THEN X.CNT END), 0) D20                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '21' THEN X.CNT END), 0) D21                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '22' THEN X.CNT END), 0) D22                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '23' THEN X.CNT END), 0) D23                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '24' THEN X.CNT END), 0) D24                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '25' THEN X.CNT END), 0) D25                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '26' THEN X.CNT END), 0) D26                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '27' THEN X.CNT END), 0) D27                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '28' THEN X.CNT END), 0) D28                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '29' THEN X.CNT END), 0) D29                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '30' THEN X.CNT END), 0) D30                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN '31' THEN X.CNT END), 0) D31                                 	");
		sql.append("        , IFNULL(SUM(CASE X.DD WHEN X.DD IS NULL THEN X.CNT END), SUM(X.CNT)) TOTAL              	");
		sql.append("     FROM                                                                                        	");
		sql.append(" (SELECT   'O' IO_GUBUN                                                                          	");
		sql.append("         , SUBSTR(DATE_FORMAT(IFNULL(A.RESER_DATE, A.ORDER_DATE), '%Y%m%d'), 1, 6) YYYYMM        	");
		sql.append("         , SUBSTR(DATE_FORMAT(IFNULL(A.RESER_DATE, A.ORDER_DATE), '%Y%m%d'), 7) DD               	");
		sql.append("         , IFNULL(A.HANGMOG_CODE,FN_ADM_MSG(221,:f_language)) HANGMOG_CODE                       	");
		sql.append("         , case IFNULL(A.HANGMOG_CODE,1) when 1 then ' ' else MAX(B.HANGMOG_NAME) end  GUMSA_NAME 	");
		sql.append("         , COUNT(A.HANGMOG_CODE) CNT                                                             	");
		sql.append(" FROM     OCS0103 B, OCS1003 A                                                                   	");
		sql.append(" WHERE    A.HOSP_CODE = :f_hosp_code                                                             	");
		sql.append("      AND IFNULL(A.RESER_DATE, A.ORDER_DATE) BETWEEN STR_TO_DATE(:f_from_date, '%Y%m%d')       		");
		sql.append("                                                 AND STR_TO_DATE(:f_to_date, '%Y%m%d')         		");
		sql.append("      AND 'O' LIKE :f_io_gubun                                                                   	");
		sql.append("      AND A.SLIP_CODE LIKE 'E%'                                                                  	");
		sql.append("      AND A.JUNDAL_TABLE IN ('PFE', 'CPL')                                                       	");
		sql.append("      AND A.ACTING_DATE IS NOT NULL                                                              	");
		sql.append("      AND A.JUNDAL_PART LIKE :f_part_code                                                        	");
		sql.append("      AND IFNULL(A.DC_YN, 'N') = 'N'                                                             	");
		sql.append("      AND B.HOSP_CODE = A.HOSP_CODE                                                              	");
		sql.append("      AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                        	");
		sql.append("      AND B.SG_CODE IS NOT NULL                                                                  	");
		sql.append("      AND A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE                                       	");
		sql.append(" GROUP BY YYYYMM, DD, A.HANGMOG_CODE WITH ROLLUP                                                 	");
		sql.append(" UNION                                                                                           	");
		sql.append(" SELECT   'I' IO_GUBUN                                                                           	");
		sql.append("         , SUBSTR(DATE_FORMAT(IFNULL(A.RESER_DATE, A.ORDER_DATE), '%Y%m%d'), 1, 6) YYYYMM        	");
		sql.append("         , SUBSTR(DATE_FORMAT(IFNULL(A.RESER_DATE, A.ORDER_DATE), '%Y%m%d'), 7) DD               	");
		sql.append("         , IFNULL(A.HANGMOG_CODE,FN_ADM_MSG(221,:f_language)) HANGMOG_CODE                       	");
		sql.append("          ,case IFNULL(A.HANGMOG_CODE,1) when 1 then ' ' else MAX(B.HANGMOG_NAME) end  GUMSA_NAME  	");
		sql.append("         , COUNT(A.HANGMOG_CODE) CNT                                                             	");
		sql.append(" FROM     OCS0103 B, OCS2003 A                                                                   	");
		sql.append(" WHERE    A.HOSP_CODE = :f_hosp_code                                                             	");
		sql.append("      AND IFNULL(A.RESER_DATE, A.ORDER_DATE) BETWEEN STR_TO_DATE(:f_from_date, '%Y%m%d')         	");
		sql.append("                                                 AND STR_TO_DATE(:f_to_date, '%Y%m%d')           	");
		sql.append("      AND 'I' LIKE :f_io_gubun                                                                   	");
		sql.append("      AND A.SLIP_CODE LIKE 'E%'                                                                  	");
		sql.append("      AND A.JUNDAL_TABLE IN ('PFE', 'CPL')                                                       	");
		sql.append("      AND A.ACTING_DATE IS NOT NULL                                                              	");
		sql.append("      AND A.JUNDAL_PART LIKE :f_part_code                                                        	");
		sql.append("      AND IFNULL(A.DC_YN, 'N') = 'N'                                                             	");
		sql.append("      AND B.HOSP_CODE = A.HOSP_CODE                                                              	");
		sql.append("      AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                        	");
		sql.append("      AND B.SG_CODE IS NOT NULL                                                                  	");
		sql.append("      AND A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE                                       	");
		sql.append(" GROUP BY YYYYMM, DD, A.HANGMOG_CODE WITH ROLLUP) X                                              	");
		sql.append("     WHERE X.YYYYMM IS NOT NULL                                                                  	");
		sql.append("     AND X.DD IS NOT NULL                                                                        	");
		sql.append("   GROUP BY X.IO_GUBUN, X.YYYYMM, X.HANGMOG_CODE                                                 	");
		sql.append("    ORDER BY X.IO_GUBUN, X.YYYYMM, X.HANGMOG_CODE                                                	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_part_code", partCode);

		List<PFE7001Q02LayMonthlyReportInfo> list = new JpaResultMapper().list(
				query, PFE7001Q02LayMonthlyReportInfo.class);

		return list;
	}

	@Override
	public List<XRT0000Q00LayOrderListItemInfo> getXRT0000Q00LayOrderList(
			String hopsCode, String language, String bunho, String jubdalPar,
			String sort) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                                                                                                             ");
		sql.append("      , case :f_sort when '1' then DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d') else DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d') end                                      ");
		sql.append("      , 'O'                                                                                                                                                 ");
		sql.append("      , A.GWA                                                                                                                                               ");
		sql.append("      , A.DOCTOR                                                                                                                                            ");
		sql.append("      , B.DOCTOR_NAME                                                                                                                                       ");
		sql.append("      , NULL                                                                                                                                                ");
		sql.append("      , A.HANGMOG_CODE                                                                                                                                      ");
		sql.append("      , C.HANGMOG_NAME                                                                                                                                      ");
		sql.append("      , NULL                                     PANDOK_SERIAL                                                                                              ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA,A.ORDER_DATE,:f_hosp_code,:language) GWA_NAME                                                                            ");
		sql.append("      , 'N'                                      CHK                                                                                                        ");
		sql.append("      , A.PKOCS1003                                                                                                                                         ");
		sql.append("      , A.IF_ACT_SEND_YN                                                                                                                                    ");
		sql.append("      , NULL                                     PANDOK_STATUS                                                                                              ");
		sql.append("      , NULL                                     PORTABLE_YN2                                                                                               ");
		sql.append("      , D.PANDOK_REQUEST_YN                                                                                                                                 ");
		sql.append("      , case :f_sort when '2' then DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d') else DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d') end XRAY_DATE                            ");
		sql.append("      , DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d')      ACT_DATE                                                                                                 ");
		sql.append("      , NULL                                     HO_DONG                                                                                                    ");
		sql.append("      , NULL                                     HO_CODE                                                                                                    ");
		sql.append("      , D.GUMSA_MOKJUK                                                                                                                                      ");
		sql.append("      , A.JUNDAL_PART                            XRAY_GUBUN                                                                                                 ");
		sql.append("      ,case :f_sort when '1' then  A.ACTING_DATE else  A.ORDER_DATE end  SORT_DATE                                                                          ");
		sql.append("   FROM XRT1002 D RIGHT JOIN OCS1003 A ON D.HOSP_CODE = A.HOSP_CODE AND D.FKOCS   = A.PKOCS1003 AND D.IN_OUT_GUBUN = 'O'                                    ");
		sql.append("      , OCS0103 C                                                                                                                                           ");
		sql.append("      , BAS0270 B                                                                                                                                           ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                          ");
		sql.append("    AND A.BUNHO           = :f_bunho                                                                                                                        ");
		sql.append("    AND A.JUNDAL_TABLE    = 'XRT'                                                                                                                           ");
		sql.append("    AND A.JUNDAL_PART     LIKE :f_jundal_part                                                                                                               ");
		sql.append("    AND (   ( :f_sort = '1' AND A.ACTING_DATE     IS NOT NULL)                                                                                              ");
		sql.append("         OR ( :f_sort = '2' ) )                                                                                                                             ");
		sql.append("    AND B.HOSP_CODE       = A.HOSP_CODE                                                                                                                     ");
		sql.append("    AND B.DOCTOR          = A.DOCTOR                                                                                                                        ");
		sql.append("    AND C.HOSP_CODE       = A.HOSP_CODE                                                                                                                     ");
		sql.append("    AND C.HANGMOG_CODE    = A.HANGMOG_CODE                                                                                                                  ");
		sql.append("  UNION ALL                                                                                                                                                 ");
		sql.append(" SELECT A.BUNHO                                                                                                                                             ");
		sql.append("      ,case  :f_sort when '1' then DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d') else DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d') end                                      ");
		sql.append("      , 'I'                                                                                                                                                 ");
		sql.append("      , E.GWA                                                                                                                                               ");
		sql.append("      , A.DOCTOR                                                                                                                                            ");
		sql.append("      , B.DOCTOR_NAME                                                                                                                                       ");
		sql.append("      , NULL                                                                                                                                                ");
		sql.append("      , A.HANGMOG_CODE                                                                                                                                      ");
		sql.append("      , C.HANGMOG_NAME                                                                                                                                      ");
		sql.append("      , NULL                                     PANDOK_SERIAL                                                                                              ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(E.GWA,A.ORDER_DATE,:f_hosp_code,:language) GWA_NAME                                                                            ");
		sql.append("      , 'N'                                      CHK                                                                                                        ");
		// sql.append("      , A.PKOCS2003                                                                                                                                         ");
		sql.append("      , A.PKOCS2003                                                                                                                                         ");
		sql.append("      , A.IF_ACT_SEND_YN                                                                                                                                    ");
		sql.append("      , NULL                                     PANDOK_STATUS                                                                                              ");
		sql.append("      , NULL                                     PORTABLE_YN2                                                                                               ");
		sql.append("      , D.PANDOK_REQUEST_YN                                                                                                                                 ");
		sql.append("      ,case  :f_sort when '2' then DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d') else DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d') end  XRAY_DATE                           ");
		sql.append("      , DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d')      ACT_DATE                                                                                                 ");
		sql.append("      , E.HO_DONG1                               HO_DONG                                                                                                    ");
		sql.append("      , E.HO_CODE1                               HO_CODE                                                                                                    ");
		sql.append("      , D.GUMSA_MOKJUK                                                                                                                                      ");
		sql.append("      , A.JUNDAL_PART                            XRAY_GUBUN                                                                                                 ");
		sql.append("      ,case :f_sort when '1' then  A.ACTING_DATE else A.ORDER_DATE end  SORT_DATE                                                                           ");
		sql.append("   FROM INP1001 E                                                                                                                                           ");
		sql.append("      , XRT1002 D RIGHT JOIN OCS2003 A ON D.HOSP_CODE  = A.HOSP_CODE AND D.FKOCS  = A.PKOCS2003 AND D.IN_OUT_GUBUN = 'I'                                    ");
		sql.append("      , OCS0103 C                                                                                                                                           ");
		sql.append("      , BAS0270 B                                                                                                                                           ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                          ");
		sql.append("    AND A.BUNHO           = :f_bunho                                                                                                                        ");
		sql.append("    AND A.JUNDAL_TABLE    = 'XRT'                                                                                                                           ");
		sql.append("    AND A.JUNDAL_PART     LIKE :f_jundal_part                                                                                                               ");
		sql.append("    AND (   ( :f_sort = '1' AND A.ACTING_DATE     IS NOT NULL)                                                                                              ");
		sql.append("         OR ( :f_sort = '2' ) )                                                                                                                             ");
		sql.append("    AND B.HOSP_CODE       = A.HOSP_CODE                                                                                                                     ");
		sql.append("    AND B.DOCTOR          = A.DOCTOR                                                                                                                        ");
		sql.append("    AND C.HOSP_CODE       = A.HOSP_CODE                                                                                                                     ");
		sql.append("    AND C.HANGMOG_CODE    = A.HANGMOG_CODE                                                                                                                  ");
		sql.append("    AND E.HOSP_CODE       = A.HOSP_CODE                                                                                                                     ");
		sql.append("    AND E.PKINP1001       = A.FKINP1001                                                                                                                     ");
		sql.append("  ORDER BY 24 DESC, 12 DESC																																	");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_sort", sort);
		query.setParameter("f_hosp_code", hopsCode);
		query.setParameter("language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_jundal_part", jubdalPar);
		List<XRT0000Q00LayOrderListItemInfo> listLayOrder = new JpaResultMapper()
				.list(query, XRT0000Q00LayOrderListItemInfo.class);
		return listLayOrder;
	}

	@Override
	public List<OCS0311U00grdSetHangmogGridFindListInfo> getOCS0311U00grdSetHangmogGridFindListInfo(
			String hospCode, String language, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI,:f_hosp_code,:language) , B.SEQ        ");
		sql.append(" FROM OCS0108 B , OCS0103 A                                                                                ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                          ");
		sql.append(" AND A.HANGMOG_CODE = :f_hangmogCode                                                                       ");
		sql.append(" AND B.HOSP_CODE = A.HOSP_CODE AND B.HANGMOG_CODE = A.HANGMOG_CODE                                         ");
		sql.append(" AND B.HANGMOG_START_DATE = A.START_DATE 																	");
		sql.append(" AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                                                         ");
		sql.append(" ORDER BY 3, 1, 2 	 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_hangmogCode", hangmogCode);
		List<OCS0311U00grdSetHangmogGridFindListInfo> listSetHangmogGrd = new JpaResultMapper()
				.list(query, OCS0311U00grdSetHangmogGridFindListInfo.class);
		return listSetHangmogGrd;
	}

	@Override
	public List<OCS0311U00laySetHangmogListInfo> getOCS0311U00laySetHangmogListInfo(
			String hospCode, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HANGMOG_NAME, A.ORD_DANUI , B.CODE_NAME                                                                               ");
		sql.append(" FROM OCS0132 B RIGHT JOIN OCS0103 A ON B.HOSP_CODE = A.HOSP_CODE AND B.CODE = A.ORD_DANUI  AND B.CODE_TYPE= 'ORD_DANUI'        ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code AND A.HANGMOG_CODE = :f_code																	");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		List<OCS0311U00laySetHangmogListInfo> listLaySetHangmog = new JpaResultMapper()
				.list(query, OCS0311U00laySetHangmogListInfo.class);
		return listLaySetHangmog;
	}

	@Override
	public String getSCH3001U00VsvHangmogCode(String hospCode,
			String hangmogCode, boolean limit) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT HANGMOG_NAME                ");
		sql.append("   FROM OCS0103                     ");
		sql.append("  WHERE HANGMOG_CODE = :f_code      ");
		sql.append("    AND HOSP_CODE    = :f_hosp_code ");
		if (limit) {
			sql.append("    LIMIT 1 ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code", hangmogCode);
		query.setParameter("f_hosp_code", hospCode);

		List<String> result = query.getResultList();
		if (!result.isEmpty()) {
			return result.get(0);
		}
		return null;
	}

	@Override
	public String getSCH3001U00GrdSCH0002ValidateGridColumnChanged(
			String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT HANGMOG_NAME                                                                          ");
		sql.append("   FROM OCS0103                                                                              ");
		sql.append("  WHERE HOSP_CODE    = :f_hosp_code                                                          ");
		sql.append("    AND HANGMOG_CODE = :f_hangmog_code                                                       ");
		sql.append("    AND SYSDATE() BETWEEN START_DATE AND IFNULL(END_DATE, STR_TO_DATE('99981231', '%Y%m%d')) ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);

		List<String> result = query.getResultList();
		if (!result.isEmpty()) {
			return result.get(0);
		}
		return null;
	}

	@Override
	public String getLoadColumnCodeNameInfoCaseHangmogCode(String hospCode,
			String arg1, String arg2) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.HANGMOG_NAME FROM OCS0103 A                                                                          ");
		sql.append(" WHERE A.HANGMOG_CODE = :f_aArgu1                                                                               ");
		sql.append(" AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:f_aArgu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')       ");
		sql.append(" AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:f_aArgu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')       ");
		sql.append(" AND A.HOSP_CODE = :f_hosp_code																					");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aArgu1", arg1);
		query.setParameter("f_aArgu2", arg2);
		List<String> listResult = query.getResultList();
		if (!CollectionUtils.isEmpty(listResult)) {
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<OCS0103U13LaySpecimenTreeListInfo> getOCS0103U13LaySpecimenTreeListInfo(String hospCode, String language, String user) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SLIP_GUBUN  ,A.SLIP_GUBUN_NAME,B.SLIP_CODE,B.SLIP_NAME,'Y' CPL_CODE_YN ,0     													");
		sql.append(" FROM OCS0101 A,OCS0102 B                                                               													");
		sql.append(" WHERE A.SLIP_GUBUN = 'B' AND B.HOSP_CODE  = :f_hosp_code                               													");
		sql.append(" AND B.SLIP_GUBUN = A.SLIP_GUBUN  AND A.LANGUAGE = :language AND A.LANGUAGE = B.LANGUAGE                                                 								");
		sql.append(" UNION ALL                                                                              													");
		sql.append(" SELECT DISTINCT  D.SLIP_GUBUN, D.SLIP_GUBUN_NAME, C.SLIP_CODE                          													");
		sql.append(" , C.SLIP_NAME,'N'  CPL_CODE_YN ,0                                                      													");
		sql.append(" FROM OCS0142 A, (Select Distinct HOSP_CODE,ORDER_GUBUN,SLIP_CODE From OCS0103 Where HOSP_CODE = :f_hosp_code ) B, OCS0102 C, OCS0101 D 	");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                                                      													");
		sql.append(" AND A.INPUT_TAB   = '04'                                                                													");
		sql.append(" AND A.MAIN_YN     = 'N'                                                                 													");
		sql.append(" AND B.HOSP_CODE   = A.HOSP_CODE                                                         													");
		sql.append(" AND B.ORDER_GUBUN = A.ORDER_GUBUN                                                       													");
		sql.append(" AND C.HOSP_CODE   = B.HOSP_CODE                                                         													");
		sql.append(" AND C.SLIP_CODE   = B.SLIP_CODE                                                         													");
		sql.append(" AND D.SLIP_GUBUN  = C.SLIP_GUBUN AND C.LANGUAGE = D.LANGUAGE  AND D.LANGUAGE = :language                                                  								");
		sql.append(" UNION ALL                                                                               													");
		sql.append(" SELECT 'AAAA' ,'セット検査' ,B.YAKSOK_CODE,B.YAKSOK_NAME                                  													")													;
		sql.append("  ,'U'   CPL_CODE_YN ,B.SEQ                                                              													");
		sql.append(" FROM OCS0300 A ,OCS0301 B                                                               													");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                                                    													");
		sql.append(" AND A.MEMB          = 'ADMIN'                                                           													");
		sql.append(" AND A.INPUT_TAB     = '04'                                                              													");
		sql.append(" AND B.HOSP_CODE     = A.HOSP_CODE                                                       													");
		sql.append(" AND B.FKOCS0300_SEQ = A.PK_SEQ                                                          													");
		sql.append(" AND B.MEMB          = A.MEMB                                                            													");
		sql.append(" UNION ALL                                                                               													");
		sql.append(" SELECT 'AAAB' ,'セット検査(個人)',B.YAKSOK_CODE                                             												");
		sql.append(" ,B.YAKSOK_NAME,'K'   CPL_CODE_YN,B.SEQ                                                  													");
		sql.append(" FROM OCS0300 A ,OCS0301 B                                                               													");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                                                    													");
		sql.append(" AND A.MEMB          = :f_user                                                           													");
		sql.append(" AND A.INPUT_TAB     = '04'                                                              													");
		sql.append(" AND B.HOSP_CODE     = A.HOSP_CODE                                                       													");
		sql.append(" AND B.FKOCS0300_SEQ = A.PK_SEQ                                                          													");
		sql.append(" AND B.MEMB          = A.MEMB                                                            													");
		sql.append("  ORDER BY 1, 2, 6, 3																	 													");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user", user);
		query.setParameter("language", language);
		List<OCS0103U13LaySpecimenTreeListInfo> listResult = new JpaResultMapper()
				.list(query, OCS0103U13LaySpecimenTreeListInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U13GrdSearchOrderListInfo> getOCS0103U13GrdSearchOrderListInfo(
			String hospCode, String searchWord, String orderDate,
			String protocolId, Integer startNum, Integer offset, String language) {
		StringBuilder sql = new StringBuilder();
		searchWord = "%" + searchWord + "%";
		sql.append(" SELECT A.SLIP_CODE       SLIP_CODE                                                                                                 ");
		sql.append("      , B.SLIP_NAME       SLIP_NAME                                                                                                 ");
		sql.append("      , A.HANGMOG_CODE    HANGMOG_CODE                                                                                              ");
		sql.append("      , A.HANGMOG_NAME    HANGMOG_NAME                                                                                              ");
		sql.append("      , A.HOSP_CODE       HOSP_CODE , A.TRIAL_FLG, A.START_DATE ,A.END_DATE                                                         ");
		sql.append("   FROM OCS0102 B                                                                                                                   ");
		sql.append("      , OCS0103 A                                                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                                  ");
		sql.append("    AND A.HANGMOG_NAME_INX LIKE :f_search_word                                                                                      ");
		sql.append("     AND STR_TO_DATE(:f_order_date, '%Y/%m/%d') BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y/%m/%d'))    ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                                                   ");
		sql.append("    AND B.SLIP_CODE = A.SLIP_CODE                                                                                                   ");
		sql.append("    AND B.LANGUAGE = :language                                                                                                   ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    				");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                     					");
		}
		sql.append("  LIMIT :f_start_num, :f_offset																					                	");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_search_word", searchWord);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("protocolId", protocolId);
		query.setParameter("f_start_num", startNum);
		query.setParameter("f_offset", offset);
		query.setParameter("language", language);

		List<OCS0103U13GrdSearchOrderListInfo> listResult = new JpaResultMapper()
				.list(query, OCS0103U13GrdSearchOrderListInfo.class);
		return listResult;

	}

	@Override
	public List<OCS0103U13GrdSpecimenListInfo> getOCS0103U13GrdSpecimenListInfo(
			String hospCode, String cqlCodeYn, String mode, String slipCode,
			String searchWord, String wonnaeDrg, Date orderDate,
			String inputTab, String user, String protocolId, Integer startNum,
			Integer endNum) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                                               ");
		sql.append("        A.SLIP_CODE                                 ,                                                                          ");
		sql.append("        A.POSITION                                  ,                                                                          ");
		sql.append("        A.SEQ                                       ,                                                                          ");
		sql.append("        A.HANGMOG_CODE                              ,                                                                          ");
		sql.append("        A.HANGMOG_NAME                              ,                                                                          ");
		sql.append("        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                       ");
		sql.append("        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                                    ");
		sql.append("             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                                ");
		sql.append("             ELSE 'N'                                                                                                          ");
		sql.append("        END                                BULYONG_CHECK,                                                                      ");
		sql.append("        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                                     ");
		sql.append("         'N' SELECT_YN,                                                                                                        ");
		sql.append("        A.HANGMOG_NAME 						HANGMOG_NAME2,                                                                     ");
		sql.append("        A.TRIAL_FLG 						TRIAL_FLG                                                                          ");
		sql.append("   FROM  OCS0113 B                                                                                                             ");
		sql.append("      , OCS0142 C                                                                                                              ");
		sql.append("      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                         ");
		sql.append("            FROM BAS0310 X                                                                                                     ");
		sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                                    ");
		sql.append("             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                          ");
		sql.append("                                   FROM BAS0310 Z                                                                              ");
		sql.append("                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                              ");
		sql.append("                                    AND Z.SG_CODE   = X.SG_CODE                                                                ");
		sql.append("                                    AND Z.SG_YMD <= SYSDATE() )                                                                ");
		sql.append("        ) D RIGHT JOIN OCS0103 A ON D.SG_CODE  = A.SG_CODE AND D.HOSP_CODE = A.HOSP_CODE                                       ");
		sql.append("      , OCS0116 E                                                                                                              ");
		sql.append("  WHERE :f_cpl_code_yn = 'Y'                                                                                                   ");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    	       ");
		}else{
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                     			   ");
		}   
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                       ");
		sql.append("    AND (                                                                                                                      ");
		sql.append("             (:f_mode = '1' AND A.SLIP_CODE         = :f_slip_code)                                                            ");
		sql.append("          OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                                       ");
		sql.append("        )                                                                                                                      ");
		sql.append("    AND A.HOSP_CODE             = :f_hosp_code     																	           ");
		sql.append("    AND B.HOSP_CODE             = A.HOSP_CODE                                                                                  ");
		sql.append("    AND B.HANGMOG_CODE          = A.HANGMOG_CODE                                                                               ");
		sql.append("    AND B.HANGMOG_START_DATE    = A.START_DATE                                                                                 ");
		sql.append("    AND (                                                                                                                      ");
		sql.append("          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                 ");
		sql.append("            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                           ");
		sql.append("	          OR                                                                                                               ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                ");
		sql.append("        )                                                                                                                      ");
		sql.append("    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                           ");
		sql.append("    AND C.HOSP_CODE   = A.HOSP_CODE                                                                                            ");
		sql.append("    AND C.ORDER_GUBUN = A.ORDER_GUBUN                                                                                          ");
		sql.append("    AND C.INPUT_TAB   = :f_input_tab                                                                                           ");
		sql.append("    AND E.HOSP_CODE     = B.HOSP_CODE                                                                                          ");
		sql.append("    AND E.SPECIMEN_CODE = B.SPECIMEN_CODE                                                                                      ");
		sql.append("  UNION ALL                                                                                                                    ");
		sql.append(" SELECT A.SLIP_CODE                                 ,                                                                          ");
		sql.append("        A.POSITION                                  ,                                                                          ");
		sql.append("        A.SEQ                                       ,                                                                          ");
		sql.append("        A.HANGMOG_CODE                              ,                                                                          ");
		sql.append("        A.HANGMOG_NAME                              ,                                                                          ");
		sql.append("        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                       ");
		sql.append("        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                                    ");
		sql.append("             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                                ");
		sql.append("             ELSE 'N'                                                                                                          ");
		sql.append("        END                                BULYONG_CHECK,                                                                      ");
		sql.append("        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                                     ");
		sql.append("         'N' SELECT_YN,                                                                                                        ");
		sql.append("        A.HANGMOG_NAME  					HANGMOG_NAME2,                                                                     ");
		sql.append("        A.TRIAL_FLG 						TRIAL_FLG                                                                          ");
		sql.append("   FROM                                                                                                                        ");
		sql.append("        OCS0142 C                                                                                                              ");
		sql.append("      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                         ");
		sql.append("            FROM BAS0310 X                                                                                                     ");
		sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                                    ");
		sql.append("             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                          ");
		sql.append("                                   FROM BAS0310 Z                                                                              ");
		sql.append("                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                              ");
		sql.append("                                    AND Z.SG_CODE   = X.SG_CODE                                                                ");
		sql.append("                                    AND Z.SG_YMD <= SYSDATE())                                                                ");
		sql.append("        ) D RIGHT JOIN OCS0103 A ON   D.SG_CODE = A.SG_CODE AND  D.HOSP_CODE = A.HOSP_CODE                                     ");
		sql.append("  WHERE :f_cpl_code_yn = 'N'                                                                                                   ");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    	       ");
		}else{
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                     			   ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                       ");
		sql.append("    AND (                                                                                                                      ");
		sql.append("             (:f_mode = '1' AND A.SLIP_CODE         = :f_slip_code)                                                            ");
		sql.append("          OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                                       ");
		sql.append("        )                                                                                                                      ");
		sql.append("    AND A.HOSP_CODE             = :f_hosp_code    																               ");
		sql.append("                                                                                                                               ");
		sql.append("    AND (                                                                                                                      ");
		sql.append("          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                 ");
		sql.append("            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                           ");
		sql.append("	          OR                                                                                                               ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)                 ");
		sql.append("        )                                                                                                                      ");
		sql.append("    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                           ");
		sql.append("    AND C.HOSP_CODE   = A.HOSP_CODE                                                                                            ");
		sql.append("    AND C.ORDER_GUBUN = A.ORDER_GUBUN                                                                                          ");
		sql.append("    AND C.INPUT_TAB   = :f_input_tab                                                                                           ");
		sql.append(" UNION ALL                                                                                                                     ");
		sql.append(" SELECT DISTINCT                                                                                                               ");
		sql.append("        B.SLIP_CODE                                 ,                                                                          ");
		sql.append("        B.POSITION                                  ,                                                                          ");
		sql.append("        A.SEQ                                       ,                                                                          ");
		sql.append("        B.HANGMOG_CODE                              ,                                                                          ");
		sql.append("        B.HANGMOG_NAME                              ,                                                                          ");
		sql.append("        IFNULL(B.GROUP_YN        , 'N')   GROUP_YN     ,                                                                       ");
		sql.append("        CASE WHEN IFNULL(B.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                                    ");
		sql.append("             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                                ");
		sql.append("             ELSE 'N'                                                                                                          ");
		sql.append("        END                BULYONG_CHECK,                                                                                      ");
		sql.append("        IFNULL(B.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                                     ");
		sql.append("        'N' SELECT_YN,                                                                                                         ");
		sql.append("        LPAD(A.SEQ, 5, '0'),                                                                                                    ");
		sql.append("        B.TRIAL_FLG 						TRIAL_FLG                                                                          ");
		sql.append("   FROM OCS0303 A                                                                                                              ");
		sql.append("       ,OCS0142 C                                                                                                              ");
		sql.append("       ,( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                         ");
		sql.append("            FROM BAS0310 X                                                                                                     ");
		sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                                    ");
		sql.append("             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                          ");
		sql.append("                                   FROM BAS0310 Z                                                                              ");
		sql.append("                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                              ");
		sql.append("                                    AND Z.SG_CODE   = X.SG_CODE                                                                ");
		sql.append("                                    AND Z.SG_YMD <= SYSDATE() )                                                                ");
		sql.append("        ) D RIGHT JOIN OCS0103 B ON  D.SG_CODE = B.SG_CODE AND D.HOSP_CODE = B.HOSP_CODE                                       ");
		sql.append("  WHERE :f_cpl_code_yn = 'U'                                                                                                   ");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))                    	       ");
		}else{
			sql.append("	 AND B.TRIAL_FLG = 'N'                                                                                     			   ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                                       ");
		sql.append("    AND (                                                                                                                      ");
		sql.append("             (:f_mode = '1' AND A.YAKSOK_CODE = :f_slip_code)                                                                  ");
		sql.append("          OR (:f_mode = '2' AND B.HANGMOG_NAME_INX  LIKE :f_search_word)                                                       ");
		sql.append("        )                                                                                                                      ");
		sql.append("                                                                                                                               ");
		sql.append("    AND (                                                                                                                      ");
		sql.append("          ( B.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                 ");
		sql.append("            AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                           ");
		sql.append("	          OR                                                                                                               ");
		sql.append("	          ( B.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)                 ");
		sql.append("        )                                                                                                                      ");
		sql.append("    AND :f_order_date BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                           ");
		sql.append("                                                                                                                               ");
		sql.append("    AND A.HOSP_CODE    = :f_hosp_code                                                                                          ");
		sql.append("    AND A.MEMB         = 'ADMIN'                                                                                               ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE    										                                               ");
		sql.append("    AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                        ");
		sql.append("    AND C.HOSP_CODE    = B.HOSP_CODE                                                                                           ");
		sql.append("    AND C.ORDER_GUBUN  = B.ORDER_GUBUN                                                                                         ");
		sql.append("    AND C.INPUT_TAB    = :f_input_tab                                                                                          ");
		sql.append(" UNION ALL                                                                                                                     ");
		sql.append(" SELECT DISTINCT                                                                                                               ");
		sql.append("        B.SLIP_CODE                                 ,                                                                          ");
		sql.append("        B.POSITION                                  ,                                                                          ");
		sql.append("        A.SEQ                                       ,                                                                          ");
		sql.append("        B.HANGMOG_CODE                              ,                                                                          ");
		sql.append("        B.HANGMOG_NAME                              ,                                                                          ");
		sql.append("        IFNULL(B.GROUP_YN        , 'N')   GROUP_YN     ,                                                                       ");
		sql.append("        CASE WHEN IFNULL(B.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                                    ");
		sql.append("             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                                ");
		sql.append("             ELSE 'N'                                                                                                          ");
		sql.append("        END                BULYONG_CHECK,                                                                                      ");
		sql.append("        IFNULL(B.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                                     ");
		sql.append("     'N' SELECT_YN ,                                                                                                           ");
		sql.append("        LPAD(A.SEQ, 5, '0'),                                                                                                    ");
		sql.append("        B.TRIAL_FLG 						TRIAL_FLG                                                                          ");
		sql.append("   FROM OCS0303 A                                                                                                              ");
		sql.append("       ,OCS0142 C                                                                                                              ");
		sql.append("       ,( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                         ");
		sql.append("            FROM BAS0310 X                                                                                                     ");
		sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                                    ");
		sql.append("             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                          ");
		sql.append("                                   FROM BAS0310 Z                                                                              ");
		sql.append("                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                              ");
		sql.append("                                    AND Z.SG_CODE   = X.SG_CODE                                                                ");
		sql.append("                                    AND Z.SG_YMD <= SYSDATE() )                                                                ");
		sql.append("        ) D RIGHT JOIN OCS0103 B ON D.SG_CODE = B.SG_CODE AND D.HOSP_CODE = B.HOSP_CODE                                        ");
		sql.append("  WHERE :f_cpl_code_yn = 'K'                                                                                                   ");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))                    	       ");
		}else{
			sql.append("	 AND B.TRIAL_FLG = 'N'                                                                                     			   ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                                       ");
		sql.append("    AND (                                                                                                                      ");
		sql.append("             (:f_mode = '1' AND A.YAKSOK_CODE = :f_slip_code)                                                                  ");
		sql.append("          OR (:f_mode = '2' AND B.HANGMOG_NAME_INX  LIKE :f_search_word)                                                       ");
		sql.append("        )                                                                                                                      ");
		sql.append("                                                                                                                               ");
		sql.append("    AND (                                                                                                                      ");
		sql.append("          ( B.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                 ");
		sql.append("            AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                           ");
		sql.append("	          OR                                                                                                               ");
		sql.append("	          ( B.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)                 ");
		sql.append("        )                                                                                                                      ");
		sql.append("    AND :f_order_date BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                           ");
		sql.append("                                                                                                                               ");
		sql.append("    AND A.HOSP_CODE    = :f_hosp_code                                                                                          ");
		sql.append("    AND A.MEMB         = :f_user                                                                                               ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE                    						                                               ");
		sql.append("    AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                        ");
		sql.append("    AND C.HOSP_CODE    = B.HOSP_CODE                                                                                           ");
		sql.append("    AND C.ORDER_GUBUN  = B.ORDER_GUBUN                                                                                         ");
		sql.append("    AND C.INPUT_TAB    = :f_input_tab                                                                                          ");
		sql.append(" ORDER BY 10																													");
		if (endNum != 0) {
			sql.append(" LIMIT :startNum, :endNum 	 																							   ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_cpl_code_yn", cqlCodeYn);
		query.setParameter("f_user", user);
		query.setParameter("f_wonnae_drg_yn", wonnaeDrg);
		query.setParameter("f_search_word", searchWord);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("f_slip_code", slipCode);
		query.setParameter("f_mode", mode);
		query.setParameter("f_order_date", orderDate);
		if (endNum != 0) {
			query.setParameter("startNum", startNum);
			query.setParameter("endNum", endNum);
		}
		if(!StringUtils.isEmpty(protocolId)){
	    	query.setParameter("f_protocol_id", protocolId);	
	    }
		List<OCS0103U13GrdSpecimenListInfo> listResult = new JpaResultMapper()
				.list(query, OCS0103U13GrdSpecimenListInfo.class);

		return listResult;
	}

	@Override
	public String getOCS0101U00Grd0103CheckData(String hospCode, String slipCode) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT 'Y'              			");
		sql.append("	  FROM OCS0103                      ");
		sql.append("	 WHERE SLIP_CODE = :slipCode        ");
		sql.append("	   AND HOSP_CODE  = :hospCode       ");
		sql.append("	   LIMIT 1                          ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("slipCode", slipCode);
		query.setParameter("hospCode", hospCode);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS0113U00GrdOCS0103ListItemInfo> getOCS0113U00GrdOcs0103ListItem(
			String hospCode, String slipCode, String hangmogName) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.SLIP_CODE             , 								");
		sql.append("	       A.HANGMOG_CODE          ,                                ");
		sql.append("	       A.HANGMOG_NAME                                           ");
		sql.append("	  FROM OCS0103 A                                                ");
		sql.append("	 WHERE A.HOSP_CODE             = :hospCode                      ");
		sql.append("	   AND A.SLIP_CODE        LIKE :slipCode                        ");
		sql.append("	   AND A.HANGMOG_NAME_INX LIKE :hangmogName                     ");
		sql.append("	   AND IFNULL(A.SPECIMEN_YN, 'N') = 'Y'                         ");
		sql.append("	 ORDER BY A.HANGMOG_CODE                                        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("slipCode", slipCode);
		query.setParameter("hangmogName", hangmogName);

		List<OCS0113U00GrdOCS0103ListItemInfo> listResult = new JpaResultMapper()
				.list(query, OCS0113U00GrdOCS0103ListItemInfo.class);
		return listResult;
	}

	@Override
	public List<GetJundaTableResponseInfo> getOCSLibOrderBizGetJundaTableListItemInfo(
			String hospCode, String hangmongCode, String appDate,
			String ioeGubun, String jundalPart) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT B.JUNDAL_TABLE_OUT, B.JUNDAL_PART_OUT, B.MOVE_PART, B.JUNDAL_TABLE_INP, B.JUNDAL_PART_INP ");
		sql.append("	  FROM OCS0103 A                                                                                  ");
		sql.append("	     , OCS0115 B                                                                                  ");
		sql.append("	 WHERE A.HOSP_CODE          = :hospCode                                                           ");
		sql.append("	   AND A.HANGMOG_CODE       = :hangmongCode                                                       ");
		sql.append("	   AND B.HOSP_CODE          = A.HOSP_CODE                                                         ");
		sql.append("	   AND B.HANGMOG_CODE       = A.HANGMOG_CODE                                                      ");
		sql.append("	   AND B.HANGMOG_START_DATE = A.START_DATE                                                        ");
		if (!StringUtils.isEmpty(appDate)) {
			sql.append("	   AND STR_TO_DATE(:appDate, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE                  ");
			sql.append("	   AND STR_TO_DATE(:appDate , '%Y/%m/%d') BETWEEN B.START_DATE AND B.END_DATE                 ");
		} else {
			sql.append("	   AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                     				      ");
			sql.append("	   AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE                                          ");
		}
		if (ioeGubun.equalsIgnoreCase("O")) {
			sql.append("	    AND B.JUNDAL_PART_OUT  =  :jundalPart                                                         ");
		} else {
			sql.append("	    AND B.JUNDAL_PART_INP =  :jundalPart                                                          ");
		}
		sql.append("	     LIMIT  1                                                        						      ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmongCode", hangmongCode);
		if (!StringUtils.isEmpty(appDate)) {
			query.setParameter("appDate", appDate);
		}
		query.setParameter("jundalPart", jundalPart);

		List<GetJundaTableResponseInfo> listResult = new JpaResultMapper()
				.list(query, GetJundaTableResponseInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U13GrdSangyongOrderListInfo> getGrdSangyongOrderListInfo(
			String hospCode, String user, String ioGubun, String orderGubun,
			Date orderDate, String searchWord, String wonaeDrgYn,
			String protocolId, Integer startNum, Integer endNum, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT AA.SLIP_CODE                SLIP_CODE     ,                                                         ");
		sql.append("        AA.SLIP_NAME                SLIP_NAME     ,                                                         ");
		sql.append("        AA.HANGMOG_CODE             HANGMOG_CODE  ,                                                         ");
		sql.append("        AA.HANGMOG_NAME             HANGMOG_NAME  ,                                                         ");
		sql.append("        ''                          SEQ           ,                                                         ");
		sql.append("        AA.HOSP_CODE                HOSP_CODE     ,                                                         ");
		sql.append("        :f_user                     MEMB          ,                                                         ");
		sql.append("        ''                          MEMB_GUBUN    ,                                                         ");
		sql.append("        IFNULL(AA.WONNAE_DRG_YN, 'N')  WONNAE_DRG_YN  , CAST((@rownum\\:=@rownum+1) AS CHAR) ROWNUM,        ");
		sql.append("        AA.TRIAL_FLG                  TRIAL_FLG                                                              ");
		sql.append("   FROM (                                                                                                   ");
		sql.append("         SELECT DISTINCT                                                                                    ");
		sql.append("                :f_user          DOCTOR,                                                                    ");
		sql.append("                B.SLIP_CODE      SLIP_CODE,                                                                 ");
		sql.append("                C.SLIP_NAME      SLIP_NAME,                                                                 ");
		sql.append("                A.HANGMOG_CODE   HANGMOG_CODE,                                                              ");
		sql.append("                B.HANGMOG_NAME   HANGMOG_NAME,                                                              ");
		sql.append("                ''               SEQ,                                                                       ");
		sql.append("                A.HOSP_CODE      HOSP_CODE,                                                                 ");
		sql.append("                ''               MEMB_GUBUN,                                                                ");
		sql.append("                IFNULL(B.WONNAE_DRG_YN, 'N')     WONNAE_DRG_YN,                                             ");
		sql.append("                COUNT(*) , @rownum\\:=0 r  , B.TRIAL_FLG     TRIAL_FLG                                      ");
		sql.append("           FROM OCS2003 A,OCS0103 B ,OCS0102 C                                                              ");
		sql.append("          WHERE A.HOSP_CODE               = :f_hosp_code   													");
		sql.append("          AND C.LANGUAGE               = :language   													");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))        	");
		}else{
			sql.append("	 AND B.TRIAL_FLG = 'N'                                                                              ");
		}
		sql.append("            AND 'I'                       = :f_io_gubun                                                     ");
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                    ");
		sql.append("            AND SUBSTR(A.INPUT_DOCTOR, 3) = :f_user                                                         ");
		sql.append("            AND B.ORDER_GUBUN             = :f_order_gubun                                                  ");
		sql.append("            AND B.HOSP_CODE               = A.HOSP_CODE                                                     ");
		sql.append("            AND B.HANGMOG_CODE            = A.HANGMOG_CODE                                                  ");
		sql.append("            AND :f_order_date BETWEEN B.START_DATE  AND B.END_DATE                                          ");
		sql.append("            AND B.HANGMOG_NAME_INX LIKE :f_search_word                                                      ");
		sql.append("            AND IFNULL(B.WONNAE_DRG_YN, 'N')           LIKE :f_wonnae_drg_yn                                ");
		sql.append("            AND C.HOSP_CODE = B.HOSP_CODE                                                                   ");
		sql.append("            AND C.SLIP_CODE = B.SLIP_CODE                                                                   ");
		sql.append("          GROUP BY :f_user , B.SLIP_CODE , C.SLIP_NAME , A.HANGMOG_CODE                                     ");
		sql.append("           , B.HANGMOG_NAME , A.HOSP_CODE, IFNULL(B.WONNAE_DRG_YN, 'N')                                     ");
		sql.append("         UNION ALL                                                                                           ");
		sql.append("         SELECT DISTINCT                                                                                     ");
		sql.append("                :f_user          DOCTOR      ,                                                               ");
		sql.append("                B.SLIP_CODE      SLIP_CODE   ,                                                               ");
		sql.append("                C.SLIP_NAME      SLIP_NAME,                                                                  ");
		sql.append("                A.HANGMOG_CODE   HANGMOG_CODE,                                                               ");
		sql.append("                B.HANGMOG_NAME   HANGMGO_NAME,                                                               ");
		sql.append("                ''               SEQ         ,                                                               ");
		sql.append("                A.HOSP_CODE      HOSP_CODE   ,                                                               ");
		sql.append("                ''               MEMB_GUBUN  ,                                                               ");
		sql.append("                IFNULL(B.WONNAE_DRG_YN, 'N')     WONNAE_DRG_YN,                                              ");
		sql.append("                COUNT(*),@rownum\\:=0 e,                                                                     ");
		sql.append("                B.TRIAL_FLG     TRIAL_FLG                                                                    ");
		sql.append("           FROM OCS1003 A ,OCS0103 B,OCS0102 C                                                               ");
		sql.append("          WHERE A.HOSP_CODE              = :f_hosp_code   							                         ");
		sql.append("          AND C.LANGUAGE               = :language   													");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))        	");
		}else{
			sql.append("	 AND B.TRIAL_FLG = 'N'                                                                              ");
		}
		sql.append("             AND 'O'                      = :f_io_gubun                                                      ");
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                     ");
		sql.append("            AND SUBSTR(A.DOCTOR, 3)      = :f_user                                                           ");
		sql.append("            AND B.ORDER_GUBUN            = :f_order_gubun                                                    ");
		sql.append("            AND B.HOSP_CODE              = A.HOSP_CODE                                                       ");
		sql.append("            AND B.HANGMOG_CODE           = A.HANGMOG_CODE                                                    ");
		sql.append("            AND :f_order_date BETWEEN B.START_DATE AND B.END_DATE                                            ");
		sql.append("            AND B.HANGMOG_NAME_INX LIKE :f_search_word                                                       ");
		sql.append("            AND IFNULL(B.WONNAE_DRG_YN, 'N')           LIKE :f_wonnae_drg_yn                                 ");
		sql.append("            AND C.HOSP_CODE = B.HOSP_CODE                                                                    ");
		sql.append("            AND C.SLIP_CODE = B.SLIP_CODE                                                                    ");
		sql.append("          GROUP BY :f_user , B.SLIP_CODE , C.SLIP_NAME, A.HANGMOG_CODE                                       ");
		sql.append("           , B.HANGMOG_NAME, A.HOSP_CODE, IFNULL(B.WONNAE_DRG_YN, 'N')                                       ");
		sql.append("         ORDER BY 10 DESC                                                                                    ");
		sql.append("       ) AA                                                                                                  ");
		sql.append("      LIMIT :startNum, :endNum 												    	                    	 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user", user);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_order_gubun", orderGubun);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_search_word", "%" + searchWord + "%");
		query.setParameter("f_wonnae_drg_yn", wonaeDrgYn);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(protocolId)){
			query.setParameter("f_protocol_id", CommonUtils.parseInteger(protocolId));
		}
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);
		List<OCS0103U13GrdSangyongOrderListInfo> listResult = new JpaResultMapper().list(query, OCS0103U13GrdSangyongOrderListInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U16GrdSangyongOrderInfo> getOCS0103U16GrdSangyongOrderInfo(
			String hospCode, String language, String codeYn, String user,
			String ioGubun, Date orderDate, String searchWord,
			String wonaeDrgYn, String orderGubun, String protocolId) {
		StringBuilder sql = new StringBuilder();
		searchWord = "%" + searchWord + "%";
		sql.append(" SELECT AA.SLIP_CODE                SLIP_CODE     ,                                                                                                                    ");
		sql.append("        AA.SLIP_NAME                SLIP_NAME     ,                                                                                                                    ");
		sql.append("        AA.HANGMOG_CODE             HANGMOG_CODE  ,                                                                                                                    ");
		sql.append("        AA.HANGMOG_NAME             HANGMOG_NAME  ,                                                                                                                    ");
		sql.append("        ''                          SEQ           ,                                                                                                                    ");
		sql.append("        AA.HOSP_CODE                HOSP_CODE     ,                                                                                                                    ");
		sql.append("        :f_user                     MEMB          ,                                                                                                                    ");
		sql.append("        ''                          MEMB_GUBUN    ,                                                                                                                    ");
		sql.append("        IFNULL(AA.WONNAE_DRG_YN, 'N')  WONNAE_DRG_YN ,                                                                                                                 ");
		sql.append("        CAST((@rownum\\:=@rownum+1) AS CHAR)  ROWNUM,  AA.TRIAL_FLG                                                                                                                    ");
		sql.append("   FROM (                                                                                                                                                              ");
		sql.append("         SELECT DISTINCT                                                                                                                                               ");
		sql.append("                :f_user          DOCTOR,                                                                                                                               ");
		sql.append("                B.SLIP_CODE      SLIP_CODE,                                                                                                                            ");
		sql.append("                D.CODE_NAME      SLIP_NAME,                                                                                                                            ");
		sql.append("                A.HANGMOG_CODE   HANGMOG_CODE,                                                                                                                         ");
		sql.append("                B.HANGMOG_NAME   HANGMOG_NAME,                                                                                                                         ");
		sql.append("                CAST(' ' AS CHAR)               SEQ,                                                                                                                                  ");
		sql.append("                A.HOSP_CODE      HOSP_CODE,                                                                                                                            ");
		sql.append("                CAST(' ' AS CHAR)               MEMB_GUBUN,                                                                                                                           ");
		sql.append("                IFNULL(B.WONNAE_DRG_YN, 'N')     WONNAE_DRG_YN,                                                                                                        ");
		sql.append("                COUNT(*), @rownum\\:= 0 r ,B.TRIAL_FLG   TRIAL_FLG                                                                                                     ");
		sql.append("           FROM OCS2003 A                                                                                                                                              ");
		sql.append("               ,OCS0103 B                                                                                                                                              ");
		sql.append("               ,XRT0001 C                                                                                                                                              ");
		sql.append("               ,XRT0102 D                                                                                                                                              ");
		sql.append("          WHERE :f_code_yn = 'Y'                                                                                                                                       ");
		sql.append("            AND A.HOSP_CODE               = :f_hosp_code                                                                                                               ");
		sql.append("            AND 'I'                       = :f_io_gubun                                                                                                                ");
		sql.append("            AND SUBSTR(A.INPUT_DOCTOR, 3) = :f_user                                                                                                                    ");
		sql.append("            AND B.HOSP_CODE               = A.HOSP_CODE                                                                                                                ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id )) ");
		} else {
			sql.append(" AND B.TRIAL_FLG = 'N' ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                                                                               ");
		sql.append("            AND B.HANGMOG_CODE            = A.HANGMOG_CODE                                                                                                             ");
		sql.append("            AND :f_order_date BETWEEN B.START_DATE AND B.END_DATE                                                                                                      ");
		sql.append("            AND B.HANGMOG_NAME_INX LIKE :f_search_word                                                                                                                 ");
		sql.append("            AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                                                                     ");
		sql.append("            AND C.HOSP_CODE  = B.HOSP_CODE                                                                                                                             ");
		sql.append("            AND C.XRAY_CODE  = B.HANGMOG_CODE                                                                                                                          ");
		sql.append("            AND C.XRAY_GUBUN = :f_order_gubun                                                                                                                          ");
		sql.append("            AND D.HOSP_CODE = C.HOSP_CODE                                                                                                                              ");
		sql.append("            AND D.CODE      = C.XRAY_GUBUN                                                                                                                             ");
		sql.append("            AND D.CODE_TYPE = 'X1'                                                                                                                                     ");
		sql.append("            AND D.LANGUAGE = :f_language                                                                                                                               ");
		sql.append("          GROUP BY  :f_user                                                                                                                                            ");
		sql.append("                 , B.SLIP_CODE                                                                                                                                         ");
		sql.append("                 , D.CODE_NAME                                                                                                                                         ");
		sql.append("                 , A.HANGMOG_CODE                                                                                                                                      ");
		sql.append("                 , B.HANGMOG_NAME                                                                                                                                      ");
		sql.append("                 , CAST(' ' AS CHAR)                                                                                                                                                  ");
		sql.append("                 , A.HOSP_CODE                                                                                                                                         ");
		sql.append("                 , IFNULL(B.WONNAE_DRG_YN, 'N')                                                                                                                        ");
		sql.append("         UNION ALL                                                                                                                                                     ");
		sql.append("         SELECT DISTINCT                                                                                                                                               ");
		sql.append("                :f_user          DOCTOR      ,                                                                                                                         ");
		sql.append("                B.SLIP_CODE      SLIP_CODE   ,                                                                                                                         ");
		sql.append("                D.CODE_NAME      SLIP_NAME   ,                                                                                                                         ");
		sql.append("                A.HANGMOG_CODE   HANGMOG_CODE,                                                                                                                         ");
		sql.append("                B.HANGMOG_NAME   HANGMGO_NAME,                                                                                                                         ");
		sql.append("                CAST(' ' AS CHAR)               SEQ         ,                                                                                                                         ");
		sql.append("                A.HOSP_CODE      HOSP_CODE   ,                                                                                                                         ");
		sql.append("                CAST(' ' AS CHAR)              MEMB_GUBUN  ,                                                                                                                         ");
		sql.append("                IFNULL(B.WONNAE_DRG_YN, 'N')     WONNAE_DRG_YN,                                                                                                        ");
		sql.append("                COUNT(*),'', B.TRIAL_FLG   TRIAL_FLG                                                                                                                   ");
		sql.append("           FROM OCS1003 A                                                                                                                                              ");
		sql.append("               ,OCS0103 B                                                                                                                                              ");
		sql.append("               ,XRT0001 C                                                                                                                                              ");
		sql.append("               ,XRT0102 D                                                                                                                                              ");
		sql.append("          WHERE :f_code_yn = 'Y'                                                                                                                                       ");
		sql.append("            AND A.HOSP_CODE              = :f_hosp_code                                                                                                                ");
		sql.append("            AND 'O'                      = :f_io_gubun                                                                                                                 ");
		sql.append("            AND SUBSTR(A.DOCTOR, 3)      = :f_user                                                                                                                     ");
		sql.append("            AND B.HOSP_CODE              = A.HOSP_CODE                                                                                                                 ");
		// sql.append("            AND B.TRIAL_FLG               = 'N'                                                                                                                        ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id )) ");
		} else {
			sql.append(" AND B.TRIAL_FLG = 'N' ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                                                                               ");
		sql.append("            AND B.HANGMOG_CODE           = A.HANGMOG_CODE                                                                                                              ");
		sql.append("            AND :f_order_date BETWEEN B.START_DATE  AND B.END_DATE                                                                                                     ");
		sql.append("            AND B.HANGMOG_NAME_INX LIKE :f_search_word                                                                                                                 ");
		sql.append("            AND IFNULL(B.WONNAE_DRG_YN, 'N')           LIKE :f_wonnae_drg_yn                                                                                           ");
		sql.append("            AND C.HOSP_CODE  = B.HOSP_CODE                                                                                                                             ");
		sql.append("            AND C.XRAY_CODE  = B.HANGMOG_CODE                                                                                                                          ");
		sql.append("            AND C.XRAY_GUBUN = :f_order_gubun                                                                                                                          ");
		sql.append("            AND D.HOSP_CODE  = C.HOSP_CODE                                                                                                                             ");
		sql.append("            AND D.CODE       = C.XRAY_GUBUN                                                                                                                            ");
		sql.append("            AND D.CODE_TYPE  = 'X1'                                                                                                                                    ");
		sql.append("            AND D.LANGUAGE = :f_language                                                                                                                               ");
		sql.append("          GROUP BY :f_user                                                                                                                                             ");
		sql.append("                 , B.SLIP_CODE                                                                                                                                         ");
		sql.append("                 , D.CODE_NAME                                                                                                                                         ");
		sql.append("                 , A.HANGMOG_CODE                                                                                                                                      ");
		sql.append("                 , B.HANGMOG_NAME                                                                                                                                      ");
		sql.append("                 , ''                                                                                                                                                  ");
		sql.append("                 , A.HOSP_CODE                                                                                                                                         ");
		sql.append("                 , IFNULL(B.WONNAE_DRG_YN, 'N')                                                                                                                        ");
		sql.append("         UNION ALL                                                                                                                                                     ");
		sql.append("         SELECT DISTINCT                                                                                                                                               ");
		sql.append("                :f_user          DOCTOR,                                                                                                                               ");
		sql.append("                B.SLIP_CODE      SLIP_CODE,                                                                                                                            ");
		sql.append("                C.SLIP_NAME      SLIP_NAME,                                                                                                                            ");
		sql.append("                A.HANGMOG_CODE   HANGMOG_CODE,                                                                                                                         ");
		sql.append("                B.HANGMOG_NAME   HANGMOG_NAME,                                                                                                                         ");
		sql.append("                CAST(' ' AS CHAR)              SEQ,                                                                                                                                  ");
		sql.append("                A.HOSP_CODE      HOSP_CODE,                                                                                                                            ");
		sql.append("                CAST(' ' AS CHAR)               MEMB_GUBUN,                                                                                                                           ");
		sql.append("                IFNULL(B.WONNAE_DRG_YN, 'N')     WONNAE_DRG_YN,                                                                                                        ");
		sql.append("                COUNT(*),'',B.TRIAL_FLG   TRIAL_FLG                      				                                                                               ");
		sql.append("           FROM OCS2003 A                                                                                                                                              ");
		sql.append("               ,OCS0103 B                                                                                                                                              ");
		sql.append("               ,OCS0102 C                                                                                                                                              ");
		sql.append("          WHERE :f_code_yn = 'N'                                                                                                                                       ");
		sql.append("            AND A.HOSP_CODE               = :f_hosp_code                                                                                                               ");
		sql.append("            AND 'I'                       = :f_io_gubun                                                                                                                ");
		sql.append("            AND SUBSTR(A.INPUT_DOCTOR, 3) = :f_user                                                                                                                    ");
		sql.append("            AND B.ORDER_GUBUN             = :f_order_gubun                                                                                                             ");
		sql.append("            AND B.HOSP_CODE               = A.HOSP_CODE                                                                                                                ");
		sql.append("            AND C.LANGUAGE               = :f_language                                                                                                                 ");
		// sql.append("            AND B.TRIAL_FLG               = 'N'                                                                                                                        ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id )) ");
		} else {
			sql.append(" AND B.TRIAL_FLG = 'N' ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                                                                               ");
		sql.append("            AND B.HANGMOG_CODE            = A.HANGMOG_CODE                                                                                                             ");
		sql.append("            AND :f_order_date BETWEEN B.START_DATE  AND B.END_DATE                                                                                                     ");
		sql.append("            AND B.HANGMOG_NAME_INX LIKE :f_search_word                                                                                                                 ");
		sql.append("            AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                                                                     ");
		sql.append("            AND C.HOSP_CODE = B.HOSP_CODE                                                                                                                              ");
		sql.append("            AND C.SLIP_CODE = B.SLIP_CODE                                                                                                                              ");
		sql.append("          GROUP BY :f_user                                                                                                                                             ");
		sql.append("                 , B.SLIP_CODE                                                                                                                                         ");
		sql.append("                 , C.SLIP_NAME                                                                                                                                         ");
		sql.append("                 , A.HANGMOG_CODE                                                                                                                                      ");
		sql.append("                 , B.HANGMOG_NAME                                                                                                                                      ");
		sql.append("                 , ''                                                                                                                                                  ");
		sql.append("                 , A.HOSP_CODE                                                                                                                                         ");
		sql.append("                 , IFNULL(B.WONNAE_DRG_YN, 'N')                                                                                                                        ");
		sql.append("         UNION ALL                                                                                                                                                     ");
		sql.append("         SELECT DISTINCT                                                                                                                                               ");
		sql.append("                :f_user          DOCTOR      ,                                                                                                                         ");
		sql.append("                B.SLIP_CODE      SLIP_CODE   ,                                                                                                                         ");
		sql.append("                C.SLIP_NAME      SLIP_NAME  ,                                                                                                                          ");
		sql.append("                A.HANGMOG_CODE   HANGMOG_CODE,                                                                                                                         ");
		sql.append("                B.HANGMOG_NAME   HANGMGO_NAME,                                                                                                                         ");
		sql.append("                ''               SEQ         ,                                                                                                                         ");
		sql.append("                A.HOSP_CODE      HOSP_CODE   ,                                                                                                                         ");
		sql.append("                ''               MEMB_GUBUN  ,                                                                                                                         ");
		sql.append("                IFNULL(B.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN,                                                                                                            ");
		sql.append("                COUNT(*),'',B.TRIAL_FLG   TRIAL_FLG                      				                                                                               ");
		sql.append("           FROM OCS1003 A                                                                                                                                              ");
		sql.append("               ,OCS0103 B                                                                                                                                              ");
		sql.append("               ,OCS0102 C                                                                                                                                              ");
		sql.append("          WHERE :f_code_yn = 'N'                                                                                                                                       ");
		sql.append("            AND A.HOSP_CODE              = :f_hosp_code                                                                                                                ");
		sql.append("            AND 'O'                      = :f_io_gubun                                                                                                                 ");
		sql.append("            AND SUBSTR(A.DOCTOR, 3)      = :f_user                                                                                                                     ");
		sql.append("            AND B.ORDER_GUBUN            = :f_order_gubun                                                                                                              ");
		sql.append("            AND B.HOSP_CODE              = A.HOSP_CODE                                                                                                                 ");
		sql.append("            AND C.LANGUAGE               = :f_language                                                                                                                 ");
		// sql.append("            AND B.TRIAL_FLG               = 'N'                                                                                                                        ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id )) ");
		} else {
			sql.append(" AND B.TRIAL_FLG = 'N' ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                                                                               ");
		sql.append("            AND B.HANGMOG_CODE           = A.HANGMOG_CODE                                                                                                              ");
		sql.append("            AND :f_order_date BETWEEN B.START_DATE                                                                                                                     ");
		sql.append("                                  AND B.END_DATE                                                                                                                       ");
		sql.append("            AND B.HANGMOG_NAME_INX LIKE :f_search_word                                                                                                                 ");
		sql.append("            AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                                                                     ");
		sql.append("            AND C.HOSP_CODE = B.HOSP_CODE                                                                                                                              ");
		sql.append("            AND C.SLIP_CODE = B.SLIP_CODE                                                                                                                              ");
		sql.append("          GROUP BY :f_user                                                                                                                                             ");
		sql.append("                 , B.SLIP_CODE                                                                                                                                         ");
		sql.append("                 , C.SLIP_NAME                                                                                                                                         ");
		sql.append("                 , A.HANGMOG_CODE                                                                                                                                      ");
		sql.append("                 , B.HANGMOG_NAME                                                                                                                                      ");
		sql.append("                 , ''                                                                                                                                                  ");
		sql.append("                 , A.HOSP_CODE                                                                                                                                         ");
		sql.append("                 , IFNULL(B.WONNAE_DRG_YN, 'N')                                                                                                                        ");
		sql.append("         ORDER BY 10 DESC                                                                                                                                              ");
		sql.append("       ) AA                                                                                                                                                            ");
		sql.append("   LIMIT 50																				                                                                               ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_yn", codeYn);
		query.setParameter("f_user", user);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_order_gubun", orderGubun);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_search_word", searchWord);
		query.setParameter("f_wonnae_drg_yn", wonaeDrgYn);
		if (!StringUtils.isEmpty(protocolId)) {
			query.setParameter("f_protocol_id", CommonUtils.parseInteger(protocolId));
		}
		List<OCS0103U16GrdSangyongOrderInfo> listResult = new JpaResultMapper().list(query, OCS0103U16GrdSangyongOrderInfo.class);

		return listResult;

	}


	@Override
	public List<OCS0103U16GrdSlipHangmogInfo> getOCS0103U16GrdSlipHangmogInfo(
			String hospCode, String language, String mode, String xrayCodeYn,
			String slipCode, Date orderDate, String inputTab, String xrayBuwi,
			String wonnaeDrgYn, String searchWord) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SLIP_CODE                                 ,                                                                   ");
		sql.append("        A.POSITION                                  ,                                                                   ");
		sql.append("        A.SEQ                                       ,                                                                   ");
		sql.append("        A.HANGMOG_CODE                              ,                                                                   ");
		sql.append("        A.HANGMOG_NAME                              ,                                                                   ");
		sql.append("        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                                ");
		sql.append("        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                ");
		sql.append("        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                             ");
		sql.append("             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                         ");
		sql.append("             ELSE 'N'                                                                                                   ");
		sql.append("        END                                BULYONG_CHECK,                                                               ");
		sql.append("        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                              ");
		sql.append("        CONCAT( TRIM(LPAD(IFNULL(F.SORT_SEQ, 0),7, '0')) , IFNULL(E.SORT,''),IFNULL(A.HANGMOG_NAME,''))   ORDERBYKEY    ");
		sql.append("        , A.TRIAL_FLG									                                                                ");
		sql.append("   FROM OCS0142 B                                                                                                       ");
		sql.append("      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                  ");
		sql.append("            FROM BAS0310 X                                                                                              ");
		sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                             ");
		sql.append("             AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                      ");
		sql.append("                                FROM BAS0310 Z                                                                          ");
		sql.append("                               WHERE Z.HOSP_CODE = X.HOSP_CODE                                                          ");
		sql.append("                                 AND Z.SG_CODE   = X.SG_CODE                                                            ");
		sql.append("                                 AND Z.SG_YMD <= SYSDATE())                                                             ");
		sql.append("        ) D RIGHT JOIN  OCS0103 A ON  D.HOSP_CODE= A.HOSP_CODE  AND D.SG_CODE  = A.SG_CODE                              ");
		sql.append("      , XRT0122 F RIGHT JOIN XRT0001 E ON F.HOSP_CODE  = E.HOSP_CODE AND  F.BUWI_CODE = E.XRAY_BUWI                     ");
		sql.append("       AND F.LANGUAGE = :language                                                                                       ");
		sql.append("  WHERE :f_mode         = '1'                                                                                           ");
		sql.append("    AND :f_xray_code_yn = 'Y'                                                                                           ");
		sql.append("    AND A.SLIP_CODE LIKE :f_slip_code                                                                                   ");
		sql.append("    AND A.HOSP_CODE     = :f_hosp_code                                                                                  ");
		sql.append("    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                    ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                                                                   ");
		sql.append("    AND B.ORDER_GUBUN   = A.ORDER_GUBUN                                                                                 ");
		sql.append("    AND B.INPUT_TAB     = :f_input_tab                                                                                  ");
		sql.append("    AND E.HOSP_CODE     = A.HOSP_CODE                                                                                   ");
		sql.append("    AND E.XRAY_CODE     = A.HANGMOG_CODE                                                                                ");
		sql.append("    AND E.XRAY_BUWI     LIKE :f_xray_buwi                                                                               ");
		sql.append("    AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                 ");
		sql.append("  UNION ALL                                                                                                             ");
		sql.append(" SELECT A.SLIP_CODE                                 ,                                                                   ");
		sql.append("        A.POSITION                                  ,                                                                   ");
		sql.append("        A.SEQ                                       ,                                                                   ");
		sql.append("        A.HANGMOG_CODE                              ,                                                                   ");
		sql.append("        A.HANGMOG_NAME                              ,                                                                   ");
		sql.append("        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                                ");
		sql.append("        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                ");
		sql.append("        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                             ");
		sql.append("             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                         ");
		sql.append("             ELSE 'N'                                                                                                   ");
		sql.append("        END                                BULYONG_CHECK,                                                               ");
		sql.append("        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                              ");
		sql.append("        A.HANGMOG_NAME                   ORDERBYKEY                                                                     ");
		sql.append("        , A.TRIAL_FLG									                                                                ");
		sql.append("   FROM  OCS0142 B                                                                                                      ");
		sql.append("      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                  ");
		sql.append("            FROM BAS0310 X                                                                                              ");
		sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                             ");
		sql.append("             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                   ");
		sql.append("                                   FROM BAS0310 Z                                                                       ");
		sql.append("                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                       ");
		sql.append("                                    AND Z.SG_CODE   = X.SG_CODE                                                         ");
		sql.append("                                    AND Z.SG_YMD <= SYSDATE() )                                                         ");
		sql.append("        ) D RIGHT JOIN  OCS0103 A ON D.HOSP_CODE = A.HOSP_CODE AND D.SG_CODE = A.SG_CODE                                ");
		sql.append("  WHERE :f_mode                 = '1'                                                                                   ");
		sql.append("    AND :f_xray_code_yn         = 'N'                                                                                   ");
		sql.append("    AND A.SLIP_CODE             LIKE :f_slip_code                                                                       ");
		sql.append("    AND A.HOSP_CODE             = :f_hosp_code                                                                          ");
		sql.append("    AND (                                                                                                               ");
		sql.append("          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                          ");
		sql.append("            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                    ");
		sql.append("	          OR                                                                                                        ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)          ");
		sql.append("        )                                                                                                               ");
		sql.append("    AND :f_order_date BETWEEN A.START_DATE  AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                   ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                    ");
		sql.append("    AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                                  ");
		sql.append("    AND B.INPUT_TAB    = :f_input_tab                                                                                   ");
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                ");
		sql.append("  UNION ALL                                                                                                             ");
		sql.append(" SELECT A.SLIP_CODE                                 ,                                                                   ");
		sql.append("        A.POSITION                                  ,                                                                   ");
		sql.append("        A.SEQ                                       ,                                                                   ");
		sql.append("        A.HANGMOG_CODE                              ,                                                                   ");
		sql.append("        A.HANGMOG_NAME                              ,                                                                   ");
		sql.append("        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                                ");
		sql.append("        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                ");
		sql.append("        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                             ");
		sql.append("             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                         ");
		sql.append("             ELSE 'N'                                                                                                   ");
		sql.append("        END                                BULYONG_CHECK,                                                               ");
		sql.append("        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                              ");
		sql.append("       CONCAT( TRIM(LPAD(IFNULL(F.SORT_SEQ, 9),7, '0')),IFNULL( A.HANGMOG_NAME,''))   ORDERBYKEY                        ");
		sql.append("        , A.TRIAL_FLG									                                                                ");
		sql.append("   FROM OCS0142 B                                                                                                       ");
		sql.append("      , ((( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                ");
		sql.append("            FROM BAS0310 X                                                                                              ");
		sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                             ");
		sql.append("             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                   ");
		sql.append("                                   FROM BAS0310 Z                                                                       ");
		sql.append("                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                       ");
		sql.append("                                    AND Z.SG_CODE   = X.SG_CODE                                                         ");
		sql.append("                                    AND Z.SG_YMD <= SYSDATE() )                                                         ");
		sql.append("        ) D RIGHT JOIN OCS0103 A ON D.HOSP_CODE = A.HOSP_CODE  AND D.SG_CODE = A.SG_CODE )                              ");
		sql.append("        LEFT JOIN XRT0001 E ON E.HOSP_CODE = A.HOSP_CODE  AND  E.XRAY_CODE = A.HANGMOG_CODE )                           ");
		sql.append("        LEFT JOIN XRT0122 F ON F.HOSP_CODE = E.HOSP_CODE AND F.BUWI_CODE = E.XRAY_BUWI  AND F.LANGUAGE = :language      ");
		sql.append("  WHERE :f_mode                 = '2'                                                                                   ");
		sql.append("    AND A.HOSP_CODE             = :f_hosp_code                                                                          ");
		sql.append("    AND (                                                                                                               ");
		sql.append("          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                          ");
		sql.append("            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                    ");
		sql.append("	          OR                                                                                                        ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)          ");
		sql.append("        )                                                                                                               ");
		sql.append("    AND A.HANGMOG_NAME_INX LIKE :f_search_word                                                                          ");
		sql.append("    AND :f_order_date BETWEEN A.START_DATE                                                                              ");
		sql.append("                           AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                    ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                                                                   ");
		sql.append("    AND B.ORDER_GUBUN   = A.ORDER_GUBUN                                                                                 ");
		sql.append("    AND B.INPUT_TAB     = :f_input_tab                                                                                  ");
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                ");
		sql.append("  ORDER BY ORDERBYKEY																									");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_mode", mode);
		query.setParameter("f_xray_code_yn", xrayCodeYn);
		query.setParameter("f_slip_code", slipCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("f_xray_buwi", xrayBuwi);
		query.setParameter("f_wonnae_drg_yn", wonnaeDrgYn);
		query.setParameter("f_search_word", searchWord);
		List<OCS0103U16GrdSlipHangmogInfo> listResult = new JpaResultMapper()
				.list(query, OCS0103U16GrdSlipHangmogInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U14GrdSlipHangmogInfo> getOCS0103U14GrdSlipHangmogInfo(
			String hospCode, String pfeCodeYn, String mode, String slipCode,
			String serachWord, String wonnaeDrgYn, Date orderDate,
			String inputTab, String user, String protocolId, Integer startNum,
			Integer endNum) {
		StringBuilder sql = new StringBuilder();

		sql.append("	 SELECT  AA.SLIP_CODE , 																											");
		sql.append("	 AA.POSITION          ,                                                                                                             ");
		sql.append("	 AA.SEQ          ,                                                                                                                  ");
		sql.append("	 AA.HANGMOG_CODE       ,                                                                                                            ");
		sql.append("	 AA.HANGMOG_NAME       ,                                                                                                            ");
		sql.append("	 AA.SPECIMEN_CODE        ,                                                                                                          ");
		sql.append("	 AA.GROUP_YN             ,                                                                                                          ");
		sql.append("	 AA.BULYONG_CHECK        ,                                                                                                          ");
		sql.append("	 AA.WONNAE_DRG_YN        ,                                                                                                          ");
		sql.append("	 AA.TRIAL_FLG                                                                                                                       ");
		sql.append("	 FROM (SELECT A.SLIP_CODE                                 ,                                                               			");
		sql.append("	        A.POSITION                                  ,                                                                               ");
		sql.append("	        A.SEQ                                       ,                                                                               ");
		sql.append("	        A.HANGMOG_CODE                              ,                                                                               ");
		sql.append("	        A.HANGMOG_NAME                              ,                                                                               ");
		sql.append("	        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                                            ");
		sql.append("	        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                            ");
		sql.append("	        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                                         ");
		sql.append("	             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                                     ");
		sql.append("	             ELSE 'N'                                                                                                               ");
		sql.append("	        END                                BULYONG_CHECK,                                                                           ");
		sql.append("	        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN   , A.TRIAL_FLG                                                           ");
		sql.append("	   FROM OCS0142 B                                                                                                                   ");
		sql.append("	      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                              ");
		sql.append("	            FROM BAS0310 X                                                                                                          ");
		sql.append("	           WHERE X.HOSP_CODE = :f_hosp_code                                                                                         ");
		sql.append("	             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                               ");
		sql.append("	                                   FROM BAS0310 Z                                                                                   ");
		sql.append("	                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                   ");
		sql.append("	                                    AND Z.SG_CODE   = X.SG_CODE                                                                     ");
		sql.append("	                                    AND Z.SG_YMD <= SYSDATE() )                                                                     ");
		sql.append("	        ) D RIGHT JOIN OCS0103 A ON  D.HOSP_CODE  = A.HOSP_CODE AND D.SG_CODE   = A.SG_CODE                                         ");
		sql.append("	  WHERE :f_pfe_code_yn = 'Y'                                                                                                        ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                                        ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                                          ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                                ");
		sql.append("	    AND (                                                                                                                           ");
		sql.append("	             (:f_mode = '1' AND A.SLIP_CODE         = :f_slip_code)                                                                 ");
		sql.append("	          OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                                            ");
		sql.append("	        )                                                                                                                           ");
		sql.append("	    AND A.HOSP_CODE             = :f_hosp_code                                                                                      ");
		sql.append("	    AND (                                                                                                                           ");
		sql.append("	          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                      ");
		sql.append("	            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                                ");
		sql.append("	          OR                                                                                                                        ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)                          ");
		sql.append("	        )                                                                                                                           ");
		sql.append("	    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                ");
		sql.append("	    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                ");
		sql.append("	    AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                                              ");
		sql.append("	    AND B.INPUT_TAB    = :f_input_tab                                                                                               ");
		sql.append("	 UNION ALL                                                                                                                          ");
		sql.append("	 SELECT A.SLIP_CODE                                 ,                                                                               ");
		sql.append("	        A.POSITION                                  ,                                                                               ");
		sql.append("	        E.SEQ                                       ,                                                                               ");
		sql.append("	        A.HANGMOG_CODE                              ,                                                                               ");
		sql.append("	        A.HANGMOG_NAME                              ,                                                                               ");
		sql.append("	        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                                            ");
		sql.append("	        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                            ");
		sql.append("	        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                                         ");
		sql.append("	             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                                     ");
		sql.append("	             ELSE 'N'                                                                                                               ");
		sql.append("	        END                BULYONG_CHECK,                                                                                           ");
		sql.append("	        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN       , A.TRIAL_FLG                                                       ");
		sql.append("	   FROM  OCS0142 B                                                                                                                  ");
		sql.append("	      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                              ");
		sql.append("	            FROM BAS0310 X                                                                                                          ");
		sql.append("	           WHERE X.HOSP_CODE = :f_hosp_code                                                                                         ");
		sql.append("	             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                               ");
		sql.append("	                                   FROM BAS0310 Z                                                                                   ");
		sql.append("	                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                   ");
		sql.append("	                                    AND Z.SG_CODE   = X.SG_CODE                                                                     ");
		sql.append("	                                    AND Z.SG_YMD <= SYSDATE() )                                                                     ");
		sql.append("	        ) D RIGHT JOIN OCS0103 A ON D.HOSP_CODE= A.HOSP_CODE AND D.SG_CODE = A.SG_CODE                                              ");
		sql.append("	      , OCS0303 E                                                                                                                   ");
		sql.append("	  WHERE :f_pfe_code_yn = 'U'                                                                                                        ");				
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                                        ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                                          ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                                ");
		sql.append("	    AND (                                                                                                                           ");
		sql.append("	             (:f_mode = '1' AND E.YAKSOK_CODE         = :f_slip_code)                                                               ");
		sql.append("	          OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                                            ");
		sql.append("	        )                                                                                                                           ");
		sql.append("	    AND A.HOSP_CODE             = :f_hosp_code                                                                                      ");
		sql.append("	    AND (                                                                                                                           ");
		sql.append("	          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                      ");
		sql.append("	            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                                             ");
		sql.append("	          OR                                                                                                                        ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)                          ");
		sql.append("	        )                                                                                                                           ");
		sql.append("	    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                ");
		sql.append("	    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                ");
		sql.append("	    AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                                              ");
		sql.append("	    AND B.INPUT_TAB    = :f_input_tab                                                                                               ");
		sql.append("	    AND E.HOSP_CODE    = A.HOSP_CODE                                                                                                ");
		sql.append("	    AND E.HANGMOG_CODE = A.HANGMOG_CODE                                                                                             ");
		sql.append("	    AND E.MEMB         = 'ADMIN'                                                                                                    ");
		sql.append("	 UNION ALL                                                                                                                          ");
		sql.append("	 SELECT A.SLIP_CODE                                 ,                                                                               ");
		sql.append("	        A.POSITION                                  ,                                                                               ");
		sql.append("	        E.SEQ                                       ,                                                                               ");
		sql.append("	        A.HANGMOG_CODE                              ,                                                                               ");
		sql.append("	        A.HANGMOG_NAME                              ,                                                                               ");
		sql.append("	        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                                            ");
		sql.append("	        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                            ");
		sql.append("	        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                                         ");
		sql.append("	             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                                     ");
		sql.append("	             ELSE 'N'                                                                                                               ");
		sql.append("	        END                BULYONG_CHECK,                                                                                           ");
		sql.append("	        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN      , A.TRIAL_FLG                                                        ");
		sql.append("	   FROM OCS0142 B                                                                                                                   ");
		sql.append("	      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                              ");
		sql.append("	            FROM BAS0310 X                                                                                                          ");
		sql.append("	           WHERE X.HOSP_CODE = :f_hosp_code                                                                                         ");
		sql.append("	             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                               ");
		sql.append("	                                   FROM BAS0310 Z                                                                                   ");
		sql.append("	                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                   ");
		sql.append("	                                    AND Z.SG_CODE   = X.SG_CODE                                                                     ");
		sql.append("	                                    AND Z.SG_YMD <= SYSDATE())                                                                      ");
		sql.append("	        ) D RIGHT JOIN OCS0103 A ON  D.HOSP_CODE = A.HOSP_CODE AND D.SG_CODE = A.SG_CODE                                           ");
		sql.append("	      , OCS0303 E                                                                                                                  ");
		sql.append("	  WHERE :f_pfe_code_yn = 'K'                                                                                                       ");				
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                                       ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                                         ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                               ");
		sql.append("	    AND (                                                                                                                          ");
		sql.append("	             (:f_mode = '1' AND E.YAKSOK_CODE         = :f_slip_code)                                                              ");
		sql.append("	          OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                                           ");
		sql.append("	        )                                                                                                                          ");
		sql.append("	    AND A.HOSP_CODE             = :f_hosp_code                                                                                     ");
		sql.append("	    AND (                                                                                                                          ");
		sql.append("	          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                     ");
		sql.append("	            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                                            ");
		sql.append("	          OR                                                                                                                       ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)                         ");
		sql.append("	        )                                                                                                                          ");
		sql.append("	    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                               ");
		sql.append("	    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                               ");
		sql.append("	    AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                                             ");
		sql.append("	    AND B.INPUT_TAB    = :f_input_tab                                                                                              ");
		sql.append("	    AND E.HOSP_CODE    = A.HOSP_CODE                                                                                               ");
		sql.append("	    AND E.HANGMOG_CODE = A.HANGMOG_CODE                                                                                            ");
		sql.append("	    AND E.MEMB         = :f_user                                                                                                   ");
		sql.append("	 UNION ALL                                                                                                                         ");
		sql.append("	 SELECT A.SLIP_CODE                                 ,                                                                              ");
		sql.append("	        A.POSITION                                  ,                                                                              ");
		sql.append("	        A.SEQ                                       ,                                                                              ");
		sql.append("	        A.HANGMOG_CODE                              ,                                                                              ");
		sql.append("	        A.HANGMOG_NAME                              ,                                                                              ");
		sql.append("	        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                                           ");
		sql.append("	        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                           ");
		sql.append("	        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                                        ");
		sql.append("	             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                                    ");
		sql.append("	             ELSE 'N'                                                                                                              ");
		sql.append("	        END                BULYONG_CHECK,                                                                                          ");
		sql.append("	        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN       , A.TRIAL_FLG                                                      ");
		sql.append("	   FROM OCS0142 B                                                                                                                  ");
		sql.append("	      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                             ");
		sql.append("	            FROM BAS0310 X                                                                                                         ");
		sql.append("	           WHERE X.HOSP_CODE = :f_hosp_code                                                                                        ");
		sql.append("	             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                              ");
		sql.append("	                                   FROM BAS0310 Z                                                                                  ");
		sql.append("	                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                  ");
		sql.append("	                                    AND Z.SG_CODE   = X.SG_CODE                                                                    ");
		sql.append("	                                    AND Z.SG_YMD <= SYSDATE() )                                                                    ");
		sql.append("	        ) D RIGHT JOIN OCS0103 A ON D.HOSP_CODE = A.HOSP_CODE AND D.SG_CODE = A.SG_CODE                                            ");
		sql.append("	      , OCS0303 E                                                                                                                  ");
		sql.append("	  WHERE :f_pfe_code_yn = 'M'                                                                                                       ");					
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                                       ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                                         ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                               ");
		sql.append("	    AND (                                                                                                                          ");
		sql.append("	             (:f_mode = '1' AND E.YAKSOK_CODE         = :f_slip_code)                                                              ");
		sql.append("	          OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                                           ");
		sql.append("	        )                                                                                                                          ");
		sql.append("	    AND A.HOSP_CODE             = :f_hosp_code                                                                                     ");
		sql.append("	    AND (                                                                                                                          ");
		sql.append("	          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                     ");
		sql.append("	            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                                            ");
		sql.append("	          OR                                                                                                                       ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)                         ");
		sql.append("	        )                                                                                                                          ");
		sql.append("	    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                               ");
		sql.append("	    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                               ");
		sql.append("	    AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                                             ");
		sql.append("	    AND B.INPUT_TAB    = :f_input_tab                                                                                              ");
		sql.append("	    AND E.HOSP_CODE    = A.HOSP_CODE                                                                                               ");
		sql.append("	    AND E.HANGMOG_CODE = A.HANGMOG_CODE                                                                                            ");
		sql.append("	    AND E.MEMB         = 'ADMIN'                                                                                                   ");
		sql.append("	 UNION ALL                                                                                                                         ");
		sql.append("	 SELECT A.SLIP_CODE                                 ,                                                                              ");
		sql.append("	        A.POSITION                                  ,                                                                              ");
		sql.append("	        A.SEQ                                       ,                                                                              ");
		sql.append("	        A.HANGMOG_CODE                              ,                                                                              ");
		sql.append("	        A.HANGMOG_NAME                              ,                                                                              ");
		sql.append("	        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                                           ");
		sql.append("	        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                                           ");
		sql.append("	        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                                        ");
		sql.append("	             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                                    ");
		sql.append("	             ELSE 'N'                                                                                                              ");
		sql.append("	        END                BULYONG_CHECK,                                                                                          ");
		sql.append("	        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN ,  A.TRIAL_FLG                                                           ");
		sql.append("	   FROM OCS0142 B                                                                                                                  ");
		sql.append("	      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                             ");
		sql.append("	            FROM BAS0310 X                                                                                                         ");
		sql.append("	           WHERE X.HOSP_CODE = :f_hosp_code                                                                                        ");
		sql.append("	             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                              ");
		sql.append("	                                   FROM BAS0310 Z                                                                                  ");
		sql.append("	                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                  ");
		sql.append("	                                    AND Z.SG_CODE   = X.SG_CODE                                                                    ");
		sql.append("	                                    AND Z.SG_YMD <= SYSDATE() )                                                                    ");
		sql.append("	        ) D RIGHT JOIN  OCS0103 A ON D.HOSP_CODE = A.HOSP_CODE AND D.SG_CODE = A.SG_CODE                                           ");
		sql.append("	      , OCS0303 E                                                                                                                  ");
		sql.append("	  WHERE :f_pfe_code_yn = 'N'                                                                                                       ");						
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                                       ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                                         ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                               ");
		sql.append("	    AND (                                                                                                                          ");
		sql.append("	             (:f_mode = '1' AND E.YAKSOK_CODE         = :f_slip_code)                                                              ");
		sql.append("	          OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                                           ");
		sql.append("	        )                                                                                                                          ");
		sql.append("	    AND A.HOSP_CODE             = :f_hosp_code                                                                                     ");
		sql.append("	    AND (                                                                                                                          ");
		sql.append("	          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                     ");
		sql.append("	            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                                            ");
		sql.append("	          OR                                                                                                                       ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)                         ");
		sql.append("	        )                                                                                                                          ");
		sql.append("	    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                               ");
		sql.append("	    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                               ");
		sql.append("	    AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                                             ");
		sql.append("	    AND B.INPUT_TAB    = :f_input_tab                                                                                              ");
		sql.append("	    AND E.HOSP_CODE    = A.HOSP_CODE                                                                                               ");
		sql.append("	    AND E.HANGMOG_CODE = A.HANGMOG_CODE                                                                                            ");
		sql.append("	    AND E.MEMB         = :f_user                                                                                                   ");
		sql.append("	 ORDER BY 3		)	  	AA                                                                                                         ");
		if (endNum != 0) {
			sql.append(" LIMIT :startNum, :endNum																			    	    				   ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pfe_code_yn", pfeCodeYn);
		query.setParameter("f_mode", mode);
		query.setParameter("f_slip_code", slipCode);
		query.setParameter("f_search_word", serachWord);
		query.setParameter("f_wonnae_drg_yn", wonnaeDrgYn);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("f_user", user);
		if (!StringUtils.isEmpty(protocolId)) {
			query.setParameter("f_protocol_id",
					CommonUtils.parseInteger(protocolId));
		}
		if (endNum != 0) {
			query.setParameter("startNum", startNum);
			query.setParameter("endNum", endNum);
		}

		List<OCS0103U14GrdSlipHangmogInfo> listResult = new JpaResultMapper()
				.list(query, OCS0103U14GrdSlipHangmogInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U12LoadDrgOrderInfo> getOCS0103U12LoadDrgOrderListItem(
			String hospCode, String language, String mode, String code,
			String wonnaeDrgYn, Date orderDate, String searchWord,
			String protocolId, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT /*+ RULE  */																																		   ");
		sql.append("	        C.HANGMOG_CODE                                           HANGMOG_CODE            ,                                                                 ");
		sql.append("	        C.HANGMOG_NAME                                           HANGMOG_NAME            ,                                                                 ");
		sql.append("	        FN_OCS_LOAD_WONYOI_CHECK(C.HANGMOG_CODE, :hospCode)                 WONYOI_ORDER_CR_YN      ,                                                      ");
		sql.append("	        C.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                                                                 ");
		sql.append("	        A.CODE1                                                  CODE1                   ,                                                                 ");
		sql.append("	        FN_DRG_LOAD_COMMENT(C.HANGMOG_CODE, :hospCode)                      DRG_INFO                ,                                                      ");
		sql.append("	        C.ORDER_GUBUN                                            ORDER_GUBUN             ,                                                                 ");
		sql.append("	        FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', C.ORDER_GUBUN, :hospCode, :language)  ORDER_GUBUN_NAME,                                                   ");
		sql.append("			C.TRIAL_FLG 							TRIAL_FLG,																			       				   ");
		sql.append("	        IFNULL(C.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN                                                                          ");
		sql.append("	   FROM OCS0103 C,                                                                                                                                         ");
		sql.append("	        INV0110 B,                                                                                                                                         ");
		sql.append("	        DRG0141 A                                                                                                                                          ");
		sql.append("	  WHERE :f_mode       = '1'                                                                                                                                ");
		sql.append("	    AND A.LANGUAGE = :language                                                                                                                             ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (C.TRIAL_FLG = 'N' OR (C.TRIAL_FLG = 'Y' AND C.CLIS_PROTOCOL_ID = :f_protocol_id ))                                                               ");
		} else {
			sql.append("	 AND C.TRIAL_FLG = 'N'                                                                                                                                 ");
		}
		sql.append("     AND IFNULL(C.COMMON_YN, 'N') != 'Y'                                                                                                                       ");
		sql.append("	    AND A.HOSP_CODE = :hospCode                                                                                                                            ");
		sql.append("	    AND A.CODE1         LIKE :f_code1                                                                                                                      ");
		sql.append("	    AND B.HOSP_CODE = A.HOSP_CODE                                                                                                                          ");
		sql.append("	    AND B.SMALL_CODE  = A.CODE1                                                                                                                            ");
		sql.append("	    AND B.SMALL_CODE       IS  NOT NULL                                                                                                                    ");
		sql.append("	    AND B.JAERYO_GUBUN     =  'A'                                                                                                                          ");
		sql.append("	    AND C.HOSP_CODE = B.HOSP_CODE                                                                                                                          ");
		sql.append("	    AND C.JAERYO_CODE      =  B.JAERYO_CODE                                                                                                                ");
		sql.append("	    AND C.ORDER_GUBUN      IN ('B')                                                                                                                        ");
		sql.append("	    AND IFNULL(C.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                                                                 ");
		sql.append("	    AND :f_order_date BETWEEN C.START_DATE                                                                                                                 ");
		sql.append("	                      AND IFNULL(C.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                                            ");
		sql.append("	UNION ALL                                                                                                                                                  ");
		sql.append("	SELECT /*+ RULE  */                                                                                                                                        ");
		sql.append("	        B.HANGMOG_CODE                                           HANGMOG_CODE            ,                                                                 ");
		sql.append("	        B.HANGMOG_NAME                                           HANGMOG_NAME            ,                                                                 ");
		sql.append("	        FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE, :hospCode)                 WONYOI_ORDER_CR_YN      ,                                                      ");
		sql.append("	        B.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                                                                 ");
		sql.append("	        '999'                                                    CODE1                   ,                                                                 ");
		sql.append("	        FN_DRG_LOAD_COMMENT(B.HANGMOG_CODE, :hospCode)                     DRG_INFO                ,                                                       ");
		sql.append("	        B.ORDER_GUBUN                                            ORDER_GUBUN             ,                                                                 ");
		sql.append("	        FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', B.ORDER_GUBUN, :hospCode, :language)  ORDER_GUBUN_NAME        ,                                           ");
		sql.append("	        B.TRIAL_FLG        ,                                           																					   ");
		sql.append("	        IFNULL(B.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN                                                                          ");
		sql.append("	   FROM OCS0103 B,                                                                                                                                         ");
		sql.append("	        INV0110 A                                                                                                                                          ");
		sql.append("	  WHERE :f_mode        = '1'                                                                                                                               ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))                                                               ");
		} else {
			sql.append("	 AND B.TRIAL_FLG = 'N'                                                                                                                                 ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                                                                       ");
		sql.append("	    AND A.HOSP_CODE = :hospCode                                                                                                                            ");
		sql.append("	    AND :f_code1       =   '999'                                                                                                                           ");
		sql.append("	    AND A.SMALL_CODE   IS  NULL                                                                                                                            ");
		sql.append("	    AND A.JAERYO_GUBUN =  'A'                                                                                                                              ");
		sql.append("	    AND B.HOSP_CODE = A.HOSP_CODE                                                                                                                          ");
		sql.append("	    AND B.JAERYO_CODE  =   A.JAERYO_CODE                                                                                                                   ");
		sql.append("	    AND B.ORDER_GUBUN  IN ('B')                                                                                                                            ");
		sql.append("	    AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                                                                 ");
		sql.append("	    AND :f_order_date BETWEEN B.START_DATE                                                                                                                 ");
		sql.append("	                      AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                                            ");
		sql.append("	 UNION ALL                                                                                                                                                 ");
		sql.append("	SELECT /*+ RULE  */                                                                                                                                        ");
		sql.append("	        B.HANGMOG_CODE                                           HANGMOG_CODE            ,                                                                 ");
		sql.append("	        B.HANGMOG_NAME                                           HANGMOG_NAME            ,                                                                 ");
		sql.append("	        FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE, :hospCode)                 WONYOI_ORDER_CR_YN      ,                                                      ");
		sql.append("	        B.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                                                                 ");
		sql.append("	        '999'                                                    CODE1                   ,                                                                 ");
		sql.append("	        FN_DRG_LOAD_COMMENT(B.HANGMOG_CODE, :hospCode)                      DRG_INFO                ,                                                      ");
		sql.append("	        B.ORDER_GUBUN                                            ORDER_GUBUN             ,                                                                 ");
		sql.append("	        FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', B.ORDER_GUBUN, :hospCode, :language)  ORDER_GUBUN_NAME        ,                                           ");
		sql.append("	        B.TRIAL_FLG        ,                                           																					   ");
		sql.append("	        IFNULL(B.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN                                                                          ");
		sql.append("	   FROM OCS0103 B                                                                                                                                          ");
		sql.append("	  WHERE :f_mode        = '2'                                                                                                                               ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))                                                               ");
		} else {
			sql.append("	 AND B.TRIAL_FLG = 'N'                                                                                                                                 ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                                                                      ");
		sql.append("	    AND B.HOSP_CODE = :hospCode                                                                                                                            ");
		sql.append("	    AND B.ORDER_GUBUN IN ( 'B' )                                                                                                                           ");
		sql.append("	    AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                                                                 ");
		sql.append("	    AND B.HANGMOG_NAME_INX LIKE :f_search_word                                                                                                             ");
		sql.append("	    AND :f_order_date BETWEEN B.START_DATE                                                                                                                 ");
		sql.append("	                      AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                                            ");
		sql.append("	                                                                                                                                                           ");
		sql.append("	UNION ALL                                                                                                                                                  ");
		sql.append("	SELECT /*+ RULE  */                                                                                                                                        ");
		sql.append("	               B.HANGMOG_CODE                                           HANGMOG_CODE            ,                                                          ");
		sql.append("	               B.HANGMOG_NAME                                           HANGMOG_NAME            ,                                                          ");
		sql.append("	               FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE, :hospCode)                WONYOI_ORDER_CR_YN      ,                                                ");
		sql.append("	               B.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                                                          ");
		sql.append("	               '999'                                                    CODE1                   ,                                                          ");
		sql.append("	               FN_DRG_LOAD_COMMENT(B.HANGMOG_CODE, :hospCode)                      DRG_INFO                ,                                               ");
		sql.append("	               B.ORDER_GUBUN                                            ORDER_GUBUN             ,                                                          ");
		sql.append("	               FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', B.ORDER_GUBUN, :hospCode, :language)  ORDER_GUBUN_NAME        ,                                    ");
		sql.append("	        B.TRIAL_FLG        ,                                           																					   ");
		sql.append("	               IFNULL(B.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN                                                                   ");
		sql.append("	  FROM OCS0303 A                                                                                                                                           ");
		sql.append("	      ,OCS0142 C                                                                                                                                           ");
		sql.append("	      ,( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                                                                      ");
		sql.append("	           FROM BAS0310 X                                                                                                                                  ");
		sql.append("	          WHERE X.HOSP_CODE = 'K01'                                                                                                                        ");
		sql.append("	            AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                                                       ");
		sql.append("	                                  FROM BAS0310 Z                                                                                                           ");
		sql.append("	                                 WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                                           ");
		sql.append("	                                   AND Z.SG_CODE   = X.SG_CODE                                                                                             ");
		sql.append("	                                   AND Z.SG_YMD <= SYSDATE())) D RIGHT JOIN OCS0103 B ON D.SG_CODE = B.SG_CODE AND D.HOSP_CODE = B.HOSP_CODE               ");
		sql.append("	WHERE  ((:f_mode = '1' AND A.YAKSOK_CODE = :f_code1)                                                                                                       ");
		sql.append("	         OR (:f_mode = '2' AND B.HANGMOG_NAME_INX  LIKE :f_search_word))                                                                                   ");
		sql.append("	   AND (( B.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                                               ");
		sql.append("	           AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                                                                        ");
		sql.append("	         OR( B.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' )))                                                                                                      ");
		sql.append("	   AND :f_order_date BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                        ");
		sql.append("	   AND A.HOSP_CODE    = :hospCode                                                                                                                          ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))                                                               ");
		} else {
			sql.append("	 AND B.TRIAL_FLG = 'N'                                                                                                                                 ");
		}
		sql.append("	   AND A.MEMB         = 'ADMIN'                                                                                                                            ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                        ");
		sql.append("	   AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                                                     ");
		sql.append("	   AND C.HOSP_CODE    = B.HOSP_CODE                                                                                                                        ");
		sql.append("	   AND C.ORDER_GUBUN  = B.ORDER_GUBUN                                                                                                                      ");
		sql.append("	   AND C.INPUT_TAB    = '03'                                                                                                                               ");
		sql.append("	   ORDER BY 2, 1                                                                                                                                           ");
		sql.append("	   limit :startNum, :offset                                                                                                                                ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_wonnae_drg_yn", wonnaeDrgYn);
		query.setParameter("f_mode", mode);
		query.setParameter("f_code1", code);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_search_word", searchWord);
		query.setParameter("language", language);
		query.setParameter("startNum", startNum);
		query.setParameter("offset", offset);
		if (!StringUtils.isEmpty(protocolId)) {
			query.setParameter("f_protocol_id",
					CommonUtils.parseInteger(protocolId));
		}
		List<OCS0103U12LoadDrgOrderInfo> listResult = new JpaResultMapper()
				.list(query, OCS0103U12LoadDrgOrderInfo.class);
		return listResult;
	}

	@Override
	public String callFnOcsCheckBreakPatStatus(String hospCode, String bunho,
			String hangmogCode) {
		StringBuilder sql = new StringBuilder();

		sql.append(" SELECT FN_OCS_CHECK_BREAK_PAT_STATUS(:hospCode, :bunho, :hangmogCode); ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("hangmogCode", hangmogCode);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public LoadHangmogInfo callPrOcsLoadHangmogInfo(String hospCode,
			Date appDate, String inputPart, String inputGwa,
			String hangmogCode, String inputTab) {

		StoredProcedureQuery query = entityManager
				.createStoredProcedureQuery("PR_OCS_LOAD_HANGMOG_INFO ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_APP_DATE", Date.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_PART", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GWA", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_TAB", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_HANGMOG_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_HANGMOG_NAME", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SLIP_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_GROUP_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_INPUT_TAB", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ORDER_GUBUN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_INPUT_CONTROL",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_TABLE_OUT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_TABLE_INP",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_PART_OUT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_PART_INP",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JAERYO_JUNDAL_YN_OUT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JAERYO_JUNDAL_YN_INP",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MOVE_PART", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SURYANG", Double.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ORD_DANUI", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DV_TIME", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DV", Double.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUSA", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BOGYONG_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUGA_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SG_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JAERYO_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JAERYO_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BULYONG_YMD", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BULYONG_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BULYONG_CHECK_OUT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SPECIMEN_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SPECIMEN_DEFAULT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PORTABLE_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PORTABLE_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_XRAY_BUWI", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_RESER_YN_OUT", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_RESER_YN_INP", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_EMERGENCY", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_EMERGENCY_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BOM_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BICHI_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_WONYOI_ORDER_YN",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_WONYOI_CHECK", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_POWDER_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_POWDER_CHECK", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_NDAY_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_CHISIK_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MUHYO_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_NURSE_INPUT_YN",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUPPLY_INPUT_YN",
				String.class, ParameterMode.INOUT);

		query.registerStoredProcedureParameter("IO_LIMIT_NALSU", Double.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_LIMIT_SURYANG",
				Double.class, ParameterMode.INOUT);

		query.registerStoredProcedureParameter("IO_REMARK", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_NURSE_CONFIRM_GUBUN",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SPECIFIC_COMMENT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_HUBAL_CHANGE_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PHARMACY_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DRG_PACK_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY1", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY2", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY3", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY4", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY5", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY6", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY7", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY8", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY9", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_COMMON_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MSG", String.class,
				ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_APP_DATE", appDate);
		query.setParameter("I_INPUT_PART", inputPart);
		query.setParameter("I_INPUT_GWA", inputGwa);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_INPUT_TAB", inputTab);

		Boolean isValid = query.execute();

		LoadHangmogInfo info = new LoadHangmogInfo();
		info.setHangmogCode((String) query
				.getOutputParameterValue("IO_HANGMOG_CODE"));
		info.setHangmogName((String) query
				.getOutputParameterValue("IO_HANGMOG_NAME"));
		info.setSlipCode((String) query.getOutputParameterValue("IO_SLIP_CODE"));
		info.setGroupYn((String) query.getOutputParameterValue("IO_GROUP_YN"));
		info.setInputTab((String) query.getOutputParameterValue("IO_INPUT_TAB"));
		info.setOrderGubun((String) query
				.getOutputParameterValue("IO_ORDER_GUBUN"));
		info.setInputControl((String) query
				.getOutputParameterValue("IO_INPUT_CONTROL"));
		info.setJundalTableOut((String) query
				.getOutputParameterValue("IO_JUNDAL_TABLE_OUT"));
		info.setJundalTableInp((String) query
				.getOutputParameterValue("IO_JUNDAL_TABLE_INP"));
		info.setJundalPartOut((String) query
				.getOutputParameterValue("IO_JUNDAL_PART_OUT"));
		info.setJundalPartInp((String) query
				.getOutputParameterValue("IO_JUNDAL_PART_INP"));
		info.setJaeryoJundalYnOut((String) query
				.getOutputParameterValue("IO_JAERYO_JUNDAL_YN_OUT"));
		info.setJaeryoJundalYnInp((String) query
				.getOutputParameterValue("IO_JAERYO_JUNDAL_YN_INP"));
		info.setMovePart((String) query.getOutputParameterValue("IO_MOVE_PART"));
		info.setSuryang((Double) query.getOutputParameterValue("IO_SURYANG"));
		info.setOrdDanui((String) query.getOutputParameterValue("IO_ORD_DANUI"));
		info.setDvTime((String) query.getOutputParameterValue("IO_DV_TIME"));
		info.setDv((Double) query.getOutputParameterValue("IO_DV"));
		info.setJusa((String) query.getOutputParameterValue("IO_JUSA"));
		info.setBogyongCode((String) query
				.getOutputParameterValue("IO_BOGYONG_CODE"));
		info.setSugaYn((String) query.getOutputParameterValue("IO_SUGA_YN"));
		info.setSgCode((String) query.getOutputParameterValue("IO_SG_CODE"));
		info.setJaeryoYn((String) query.getOutputParameterValue("IO_JAERYO_YN"));
		info.setJaeryoCode((String) query
				.getOutputParameterValue("IO_JAERYO_CODE"));
		info.setBulyongYmd((String) query
				.getOutputParameterValue("IO_BULYONG_YMD"));
		info.setBulyongCheck((String) query
				.getOutputParameterValue("IO_BULYONG_CHECK"));
		info.setBulyongCheckOut((String) query
				.getOutputParameterValue("IO_BULYONG_CHECK_OUT"));
		info.setSpecimenYn((String) query
				.getOutputParameterValue("IO_SPECIMEN_YN"));
		info.setSpecimenDefault((String) query
				.getOutputParameterValue("IO_SPECIMEN_DEFAULT"));
		info.setPortableYn((String) query
				.getOutputParameterValue("IO_PORTABLE_YN"));
		info.setPortableCheck((String) query
				.getOutputParameterValue("IO_PORTABLE_CHECK"));
		info.setXrayBuwi((String) query.getOutputParameterValue("IO_XRAY_BUWI"));
		info.setReserYnOut((String) query
				.getOutputParameterValue("IO_RESER_YN_OUT"));
		info.setReserYnInp((String) query
				.getOutputParameterValue("IO_RESER_YN_INP"));
		info.setEmergency((String) query
				.getOutputParameterValue("IO_EMERGENCY"));
		info.setEmergencyCheck((String) query
				.getOutputParameterValue("IO_EMERGENCY_CHECK"));
		info.setBomYn((String) query.getOutputParameterValue("IO_BOM_YN"));
		info.setBichiYn((String) query.getOutputParameterValue("IO_BICHI_YN"));
		info.setWonyoiOrderYn((String) query
				.getOutputParameterValue("IO_WONYOI_ORDER_YN"));
		info.setWonyoiCheck((String) query
				.getOutputParameterValue("IO_WONYOI_CHECK"));
		info.setPowderYn((String) query.getOutputParameterValue("IO_POWDER_YN"));
		info.setPowderCheck((String) query
				.getOutputParameterValue("IO_POWDER_CHECK"));
		info.setNdayYn((String) query.getOutputParameterValue("IO_NDAY_YN"));
		info.setChisikYn((String) query.getOutputParameterValue("IO_CHISIK_YN"));
		info.setMuhyoYn((String) query.getOutputParameterValue("IO_MUHYO_YN"));
		info.setNurseInputYn((String) query
				.getOutputParameterValue("IO_NURSE_INPUT_YN"));
		info.setSupplyInputYn((String) query
				.getOutputParameterValue("IO_SUPPLY_INPUT_YN"));

		info.setLimitSuryang((Double) query
				.getOutputParameterValue("IO_LIMIT_SURYANG"));

		info.setLimitNalsu((Double) query
				.getOutputParameterValue("IO_LIMIT_NALSU"));
		info.setRemark((String) query.getOutputParameterValue("IO_REMARK"));
		info.setNurseConfirmGubun((String) query
				.getOutputParameterValue("IO_NURSE_CONFIRM_GUBUN"));
		info.setSpecificComment((String) query
				.getOutputParameterValue("IO_SPECIFIC_COMMENT"));
		info.setHubalChangeCheck((String) query
				.getOutputParameterValue("IO_HUBAL_CHANGE_CHECK"));
		info.setPharmacyCheck((String) query
				.getOutputParameterValue("IO_PHARMACY_CHECK"));
		info.setDrgPackCheck((String) query
				.getOutputParameterValue("IO_DRG_PACK_CHECK"));
		info.setDummy((String) query.getOutputParameterValue("IO_DUMMY"));
		info.setDummy1((String) query.getOutputParameterValue("IO_DUMMY1"));
		info.setDummy2((String) query.getOutputParameterValue("IO_DUMMY2"));
		info.setDummy3((String) query.getOutputParameterValue("IO_DUMMY3"));
		info.setDummy4((String) query.getOutputParameterValue("IO_DUMMY4"));
		info.setDummy5((String) query.getOutputParameterValue("IO_DUMMY5"));
		info.setDummy6((String) query.getOutputParameterValue("IO_DUMMY6"));
		info.setDummy7((String) query.getOutputParameterValue("IO_DUMMY7"));
		info.setDummy8((String) query.getOutputParameterValue("IO_DUMMY8"));
		info.setDummy9((String) query.getOutputParameterValue("IO_DUMMY9"));
		info.setFlag((String) query.getOutputParameterValue("IO_FLAG"));
		info.setMsg((String) query.getOutputParameterValue("IO_MSG"));
		info.setCommonYn((String) query.getOutputParameterValue("IO_COMMON_YN"));

		return info;
	}

	@Override
	public List<OCS0103U10GrdDrgOrderInfo> listOCS0103U10GrdDrgOrderInfo(
			String hospCode, String language, String mode, String code1,
			String wonnaeDrgYn, Date orderDate, String searchWord,
			String protocolId, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
//		turning performance MED-8745
		if("1".equals(mode)){
//			case code1 equal 999 mean different , CODE1 = '999' dont have in table DRG0141, checked and confirmed with BA  
			if("999".equals(code1)){
				sql.append("  SELECT B.HANGMOG_CODE                                           HANGMOG_CODE            ,                          ");
				sql.append("         B.HANGMOG_NAME                                           HANGMOG_NAME            ,                          ");
				sql.append("         FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE,:f_hosp_code)    WONYOI_ORDER_CR_YN      ,                          ");
				sql.append("         B.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                          ");
				sql.append("         '999'                                                    CODE1                   ,                          ");
				sql.append("         FN_DRG_LOAD_COMMENT(B.HANGMOG_CODE,:f_hosp_code)         DRG_INFO                ,                          ");
				sql.append("         B.ORDER_GUBUN                                            ORDER_GUBUN             ,                          ");
				sql.append("         FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', B.ORDER_GUBUN,:f_hosp_code,:f_language)  ORDER_GUBUN_NAME,         ");
				sql.append("         IFNULL(B.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN  , B.TRIAL_FLG                    ");
				sql.append("   FROM OCS0103 B, INV0110 A                                                                                         ");
				sql.append("   WHERE :f_mode        = '1'     							                                                          ");
				if(!StringUtils.isEmpty(protocolId)){
					sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))                     ");
				}else{
					sql.append("	 AND B.TRIAL_FLG = 'N' 																						 ");
				}
				sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                             ");
				sql.append("         AND :f_code1       =   '999'                                                                                ");
				sql.append("         AND A.HOSP_CODE    = :f_hosp_code                                                                           ");
				sql.append("         AND A.SMALL_CODE   IS  NULL                                                                                 ");
				sql.append("         AND A.JAERYO_GUBUN = 'A'                                                                                    ");
				sql.append("         AND B.HOSP_CODE    = A.HOSP_CODE                                                                            ");
				sql.append("         AND B.JAERYO_CODE  = A.JAERYO_CODE                                                                          ");
				sql.append("         AND B.ORDER_GUBUN  IN ('C', 'D')                                                                            ");
				sql.append("         AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                      ");
				sql.append("         AND :f_order_date BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))            ");
				sql.append("  ORDER BY 2, 1																								         ");
				if(startNum != null && offset != null){
					sql.append("       LIMIT :f_start_num, :f_offset 																		     ");
				}
				
			}else{
//				sql.append(" UNION ALL                                                                                                           ");
				sql.append("  SELECT C.HANGMOG_CODE                                           HANGMOG_CODE,                                      ");
				sql.append("         C.HANGMOG_NAME                                           HANGMOG_NAME            ,                          ");
				sql.append("         FN_OCS_LOAD_WONYOI_CHECK(C.HANGMOG_CODE,:f_hosp_code)    WONYOI_ORDER_CR_YN      ,                          ");
				sql.append("         C.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                          ");
				sql.append("         A.CODE1                                                  CODE1                   ,                          ");
				sql.append("         FN_DRG_LOAD_COMMENT(C.HANGMOG_CODE,:f_hosp_code)         DRG_INFO                ,                          ");
				sql.append("         C.ORDER_GUBUN                                            ORDER_GUBUN             ,                          ");
				sql.append("         FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', C.ORDER_GUBUN,:f_hosp_code,:f_language)  ORDER_GUBUN_NAME,         ");
				sql.append("         IFNULL(C.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN    , C.TRIAL_FLG                  ");
				sql.append("   FROM OCS0103 C, INV0110 B, DRG0141 A                                                                              ");
				sql.append("   WHERE :f_mode            = '1'           							                                            ");
				if(!StringUtils.isEmpty(protocolId)){
					sql.append("	 AND (C.TRIAL_FLG = 'N' OR (C.TRIAL_FLG = 'Y' AND C.CLIS_PROTOCOL_ID = :f_protocol_id ))                     ");
				}else{
					sql.append("	 AND C.TRIAL_FLG = 'N' 																						 ");
				}
				sql.append("     AND IFNULL(C.COMMON_YN, 'N') != 'Y'                                                                             ");
				sql.append("         AND A.HOSP_CODE        = :f_hosp_code                                                                       ");
				sql.append("         AND A.CODE1            LIKE :f_code1                                                                        ");
				sql.append("         AND B.HOSP_CODE        = A.HOSP_CODE                                                                        ");
				sql.append("         AND B.SMALL_CODE       = A.CODE1                                                                            ");
				sql.append("         AND B.SMALL_CODE       IS NOT NULL                                                                          ");
				sql.append("         AND B.JAERYO_GUBUN     = 'A'                                                                                ");
				sql.append("         AND C.HOSP_CODE        = B.HOSP_CODE                                                                        ");
				sql.append("         AND C.JAERYO_CODE      = B.JAERYO_CODE                                                                      ");
				sql.append("         AND C.ORDER_GUBUN      IN ('C', 'D')                                                                        ");
				sql.append("         AND IFNULL(C.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                      ");
				sql.append("         AND :f_order_date BETWEEN C.START_DATE AND IFNULL(C.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))            ");
				sql.append("         AND A.LANGUAGE         = :f_language                                                                        ");
				sql.append("  ORDER BY 2, 1																								         ");
				if(startNum != null && offset != null){
					sql.append("       LIMIT :f_start_num, :f_offset 																		     ");
				}
			}
		}else if("2".equals(mode)){
//			sql.append(" UNION ALL                                                                                                           ");
			sql.append("   SELECT B.HANGMOG_CODE                                           HANGMOG_CODE            ,                          ");
			sql.append("         B.HANGMOG_NAME                                           HANGMOG_NAME            ,                          ");
			sql.append("         FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE,:f_hosp_code)    WONYOI_ORDER_CR_YN      ,                          ");
			sql.append("         B.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                          ");
			sql.append("         '999'                                                    CODE1                   ,                          ");
			sql.append("         FN_DRG_LOAD_COMMENT(B.HANGMOG_CODE,:f_hosp_code)         DRG_INFO                ,                          ");
			sql.append("         B.ORDER_GUBUN                                            ORDER_GUBUN             ,                          ");
			sql.append("         FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', B.ORDER_GUBUN,:f_hosp_code,:f_language)  ORDER_GUBUN_NAME,         ");
			sql.append("         IFNULL(B.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN     , B.TRIAL_FLG                 ");
			sql.append("   FROM OCS0103 B                                                                                                    ");
			sql.append("   WHERE :f_mode        = '2'                                                                                        ");
			if(!StringUtils.isEmpty(protocolId)){
				sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))                     ");
			}else{
				sql.append("	 AND B.TRIAL_FLG = 'N' 																						 ");
			}
			sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                                             ");
			sql.append("         AND B.HOSP_CODE    = :f_hosp_code                                                                           ");
			sql.append("         AND B.ORDER_GUBUN IN ( 'C', 'D' )                                                                           ");
			sql.append("         AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                      ");
			sql.append("         AND B.HANGMOG_NAME_INX LIKE :f_search_word                                                                  ");
			sql.append("         AND :f_order_date BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))            ");
			sql.append("  ORDER BY 2, 1																								         ");
			if(startNum != null && offset != null){
				sql.append("       LIMIT :f_start_num, :f_offset 																		     ");
			}
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_mode", mode);
		query.setParameter("f_wonnae_drg_yn", wonnaeDrgYn);
		query.setParameter("f_order_date", orderDate);
		if("1".equals(mode)){
			query.setParameter("f_code1", code1);
		}else if("2".equals(mode)){
			query.setParameter("f_search_word", searchWord);
		}
		if(startNum != null && offset != null){
			query.setParameter("f_start_num", startNum);
			query.setParameter("f_offset", offset);
		}
		if(!StringUtils.isEmpty(protocolId)){
			query.setParameter("f_protocol_id", protocolId);
		}
		List<OCS0103U10GrdDrgOrderInfo> listResult = new JpaResultMapper().list(query, OCS0103U10GrdDrgOrderInfo.class);						
		return listResult;
	}

	@Override
	public List<OCS0103U10GrdGeneralInfo> listOCS0103U10GrdGeneralInfo(
			String hospCode, String filter, String yakkijunCode,
			String orderDate, String hangmogCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.SLIP_CODE, B.SLIP_NAME , A.HANGMOG_CODE, A.HANGMOG_NAME                                              ");
		sql.append("       , IFNULL(A.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN                                                             ");
		sql.append("    FROM OCS0102 B , OCS0103 A                                                                                  ");
		sql.append("   WHERE A.HOSP_CODE  = :f_hosp_code                                                                            ");
		sql.append("     AND SUBSTR(A.YAK_KIJUN_CODE, 1, :f_filter) = SUBSTR(:f_yak_kijun_code, 1, :f_filter)                       ");
		sql.append("     AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE          ");
		sql.append("     AND IFNULL(A.WONNAE_DRG_YN,'N') = 'Y'                                                                      ");
		sql.append("     AND A.ORDER_GUBUN IN ('C', 'D')                                                                            ");
		sql.append("     AND A.HANGMOG_CODE != :f_hangmog_code                                                                      ");
		sql.append("     AND B.HOSP_CODE = A.HOSP_CODE                                                                              ");
		sql.append("     AND B.SLIP_CODE = A.SLIP_CODE                                                                              ");
		sql.append("     AND B.LANGUAGE = :language                                                                              	");
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                        ");
//		sql.append("   ORDER BY 1, 3																								");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_filter", filter);
		query.setParameter("f_yak_kijun_code", yakkijunCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("language", language);
		List<OCS0103U10GrdGeneralInfo> listResult = new JpaResultMapper().list(
				query, OCS0103U10GrdGeneralInfo.class);
		return listResult;
	}

	public List<OCS0103U12SetTabWonnaeDrugInfo> getOCS0103U12SetTabWonnaeDrugListItem(
			String hospCode, String yakKijunCode, String orderDate,
			String hangmogCode) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT '4' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 4)											");
		sql.append("	  FROM OCS0103 A                                                                                            ");
		sql.append("	  WHERE A.HOSP_CODE = :f_hosp_code                                                                          ");
		sql.append("	    AND SUBSTR(A.YAK_KIJUN_CODE, 1, 4) = SUBSTR(:f_yak_kijun_code, 1, 4)                                    ");
		sql.append("	    AND A.WONNAE_DRG_YN = 'Y'                                                                               ");
		sql.append("	    AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE       ");
		sql.append("	    AND A.ORDER_GUBUN = 'B'                                                                                 ");
		sql.append("	    AND A.HANGMOG_CODE != :f_hangmog_code                                                                   ");
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                        ");
		sql.append("	  GROUP BY '4', SUBSTR(:f_yak_kijun_code, 1, 4)                                                             ");
		sql.append("	                                                                                                            ");
		sql.append("	  UNION ALL                                                                                                 ");
		sql.append("	 SELECT '7' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 7)                                           ");
		sql.append("	   FROM OCS0103 A                                                                                           ");
		sql.append("	  WHERE A.HOSP_CODE = :f_hosp_code                                                                          ");
		sql.append("	    AND SUBSTR(A.YAK_KIJUN_CODE, 1, 7) = SUBSTR(:f_yak_kijun_code, 1, 7)                                    ");
		sql.append("	    AND A.WONNAE_DRG_YN = 'Y'                                                                               ");
		sql.append("	    AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE       ");
		sql.append("	    AND A.ORDER_GUBUN = 'B'                                                                                 ");
		sql.append("	    AND A.HANGMOG_CODE != :f_hangmog_code                                                                   ");
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                        ");
		sql.append("	  GROUP BY '7', SUBSTR(:f_yak_kijun_code, 1, 7)                                                             ");
		sql.append("	                                                                                                            ");
		sql.append("	  UNION ALL                                                                                                 ");
		sql.append("	 SELECT '8' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 8)                                           ");
		sql.append("	   FROM OCS0103 A                                                                                           ");
		sql.append("	  WHERE A.HOSP_CODE = :f_hosp_code                                                                          ");
		sql.append("	    AND SUBSTR(A.YAK_KIJUN_CODE, 1, 8) = SUBSTR(:f_yak_kijun_code, 1, 8)                                    ");
		sql.append("	    AND A.WONNAE_DRG_YN = 'Y'                                                                               ");
		sql.append("	    AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE       ");
		sql.append("	    AND A.ORDER_GUBUN = 'B'                                                                                 ");
		sql.append("	    AND A.HANGMOG_CODE != :f_hangmog_code                                                                   ");
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                        ");
		sql.append("	  GROUP BY '8', SUBSTR(:f_yak_kijun_code, 1, 8)                                                             ");
		sql.append("	  UNION ALL                                                                                                 ");
		sql.append("	 SELECT '9' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 9)                                           ");
		sql.append("	   FROM OCS0103 A                                                                                           ");
		sql.append("	  WHERE A.HOSP_CODE = :f_hosp_code                                                                          ");
		sql.append("	    AND SUBSTR(A.YAK_KIJUN_CODE, 1, 9) = SUBSTR(:f_yak_kijun_code, 1, 9)                                    ");
		sql.append("	    AND A.WONNAE_DRG_YN = 'Y'                                                                               ");
		sql.append("	    AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE       ");
		sql.append("	    AND A.ORDER_GUBUN = 'B'                                                                                 ");
		sql.append("	    AND A.HANGMOG_CODE != :f_hangmog_code                                                                   ");
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                        ");
		sql.append("	  GROUP BY '9', SUBSTR(:f_yak_kijun_code, 1, 9);                                                            ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_yak_kijun_code", yakKijunCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hangmog_code", hangmogCode);

		List<OCS0103U12SetTabWonnaeDrugInfo> listResult = new JpaResultMapper()
				.list(query, OCS0103U12SetTabWonnaeDrugInfo.class);
		return listResult;
	}

	@Override
	public List<OCS0103U10SetTabWonnaeDrgInfo> getOCS0103U10SetTabWonnaeDrgInfo(
			String hospCode, String yakKijunCode, String orderDate,
			String hangmogCode) {
		StringBuilder sql = new StringBuilder();
//		sql.append(" SELECT '4' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 4)                                              ");
//		sql.append("   FROM OCS0103 A                                                                                              ");
//		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                             ");
//		sql.append("    AND SUBSTR(A.YAK_KIJUN_CODE, 1, 4) = SUBSTR(:f_yak_kijun_code, 1, 4)                                       ");
//		sql.append("    AND A.WONNAE_DRG_YN = 'Y'                                                                                  ");
//		sql.append("    AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE          ");
//		sql.append("    AND A.ORDER_GUBUN IN ('C', 'D')                                                                            ");
//		sql.append("    AND A.HANGMOG_CODE != :f_hangmog_code                                                                      ");
//		sql.append("  GROUP BY '4', SUBSTR(:f_yak_kijun_code, 1, 4)                                                                ");
//		sql.append("  UNION ALL                                                                                                    ");
//		sql.append(" SELECT '7' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 7)                                              ");
//		sql.append("   FROM OCS0103 A                                                                                              ");
//		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                             ");
//		sql.append("    AND SUBSTR(A.YAK_KIJUN_CODE, 1, 7) = SUBSTR(:f_yak_kijun_code, 1, 7)                                       ");
//		sql.append("    AND A.WONNAE_DRG_YN = 'Y'                                                                                  ");
//		sql.append("    AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE          ");
//		sql.append("    AND A.ORDER_GUBUN IN ('C', 'D')                                                                            ");
//		sql.append("    AND A.HANGMOG_CODE != :f_hangmog_code                                                                      ");
//		sql.append("  GROUP BY '7', SUBSTR(:f_yak_kijun_code, 1, 7)                                                                ");
//		sql.append("  UNION ALL                                                                                                    ");
//		sql.append(" SELECT '8' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 8)                                              ");
//		sql.append("   FROM OCS0103 A                                                                                              ");
//		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                             ");
//		sql.append("    AND SUBSTR(A.YAK_KIJUN_CODE, 1, 8) = SUBSTR(:f_yak_kijun_code, 1, 8)                                       ");
//		sql.append("    AND A.WONNAE_DRG_YN = 'Y'                                                                                  ");
//		sql.append("    AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE          ");
//		sql.append("    AND A.ORDER_GUBUN IN ('C', 'D')                                                                            ");
//		sql.append("    AND A.HANGMOG_CODE != :f_hangmog_code                                                                      ");
//		sql.append("  GROUP BY '8', SUBSTR(:f_yak_kijun_code, 1, 8)                                                                ");
//		sql.append("  UNION ALL                                                                                                    ");
//		sql.append(" SELECT '9' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 9)                                              ");
//		sql.append("   FROM OCS0103 A                                                                                              ");
//		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                             ");
//		sql.append("    AND SUBSTR(A.YAK_KIJUN_CODE, 1, 9) = SUBSTR(:f_yak_kijun_code, 1, 9)                                       ");
//		sql.append("    AND A.WONNAE_DRG_YN = 'Y'                                                                                  ");
//		sql.append("    AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE          ");
//		sql.append("    AND A.ORDER_GUBUN IN ('C', 'D')                                                                            ");
//		sql.append("    AND A.HANGMOG_CODE != :f_hangmog_code                                                                      ");
//		sql.append("  GROUP BY '9', SUBSTR(:f_yak_kijun_code, 1, 9)																	");

		sql.append(" SELECT '4' ,SUM(IF(SUBSTR(A.YAK_KIJUN_CODE, 1, 4) = SUBSTR(:f_yak_kijun_code, 1, 4), 1, 0)) CNT_4, SUBSTR(:f_yak_kijun_code, 1, 4), 	");
		sql.append(" '7',SUM(IF(SUBSTR(A.YAK_KIJUN_CODE, 1, 7) = SUBSTR(:f_yak_kijun_code, 1, 7), 1, 0)) CNT_7, SUBSTR(:f_yak_kijun_code, 1, 7),			");
		sql.append("  '8',SUM(IF(SUBSTR(A.YAK_KIJUN_CODE, 1, 8) = SUBSTR(:f_yak_kijun_code, 1, 8), 1, 0)) CNT_8, SUBSTR(:f_yak_kijun_code, 1, 8), 			");
		sql.append("  '9', SUM(IF(SUBSTR(A.YAK_KIJUN_CODE, 1, 9) = SUBSTR(:f_yak_kijun_code, 1, 9), 1, 0)) CNT_9, SUBSTR(:f_yak_kijun_code, 1, 9)			");
		sql.append(" FROM OCS0103 A WHERE A.HOSP_CODE = :f_hosp_code  																						");
		sql.append("   AND IFNULL(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE   									");
		sql.append("  AND A.ORDER_GUBUN IN ('C', 'D')          																								");
		sql.append(" AND A.HANGMOG_CODE !=:f_hangmog_code  																									");
		sql.append(" AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                                    ");


		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_yak_kijun_code", yakKijunCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<OCS0103U10SetTabWonnaeInfo> infos  = new JpaResultMapper()
				.list(query, OCS0103U10SetTabWonnaeInfo.class);



		List<OCS0103U10SetTabWonnaeDrgInfo> listResult = new ArrayList<>();
		if(!CollectionUtils.isEmpty(infos))
		{
			OCS0103U10SetTabWonnaeInfo info = infos.get(0);
			OCS0103U10SetTabWonnaeDrgInfo oCS0103U10SetTabWonnaeDrgInfo = new OCS0103U10SetTabWonnaeDrgInfo();
			oCS0103U10SetTabWonnaeDrgInfo.setFilter(info.getFilter4());
			oCS0103U10SetTabWonnaeDrgInfo.setCnt(info.getCnt4());
			oCS0103U10SetTabWonnaeDrgInfo.setYakKijunCode(info.getKijunCode4());
			listResult.add(oCS0103U10SetTabWonnaeDrgInfo);

			oCS0103U10SetTabWonnaeDrgInfo = new OCS0103U10SetTabWonnaeDrgInfo();
			oCS0103U10SetTabWonnaeDrgInfo.setFilter(info.getFilter7());
			oCS0103U10SetTabWonnaeDrgInfo.setCnt(info.getCnt7());
			oCS0103U10SetTabWonnaeDrgInfo.setYakKijunCode(info.getKijunCode7());
			listResult.add(oCS0103U10SetTabWonnaeDrgInfo);

			oCS0103U10SetTabWonnaeDrgInfo = new OCS0103U10SetTabWonnaeDrgInfo();
			oCS0103U10SetTabWonnaeDrgInfo.setFilter(info.getFilter8());
			oCS0103U10SetTabWonnaeDrgInfo.setCnt(info.getCnt8());
			oCS0103U10SetTabWonnaeDrgInfo.setYakKijunCode(info.getKijunCode8());
			listResult.add(oCS0103U10SetTabWonnaeDrgInfo);

			oCS0103U10SetTabWonnaeDrgInfo = new OCS0103U10SetTabWonnaeDrgInfo();
			oCS0103U10SetTabWonnaeDrgInfo.setFilter(info.getFilter9());
			oCS0103U10SetTabWonnaeDrgInfo.setCnt(info.getCnt9());
			oCS0103U10SetTabWonnaeDrgInfo.setYakKijunCode(info.getKijunCode9());
			listResult.add(oCS0103U10SetTabWonnaeDrgInfo);

		}



		return listResult;
	}

	@Override
	public List<OCS0108U00grdOCS0103ItemInfo> getOCS0108U00grdOCS0103ItemInfo(
			String hospCode, String language, String hangmogNameInx,
			String slipCode) {
		StringBuilder sql = new StringBuilder();
		hangmogNameInx = "%" + hangmogNameInx + "%";
		slipCode = slipCode + "%";
		sql.append(" SELECT A.SLIP_CODE                                                                 ,                                   ");
		sql.append("        A.HANGMOG_CODE                                                              ,                                   ");
		sql.append("        A.HANGMOG_NAME                                                              ,                                   ");
		sql.append("        B.DANUI                                                SUNAB_DANUI          ,                                   ");
		sql.append("        FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.DANUI ,:f_hosp_code,:f_language     )      SUNAB_DANUI_NAME     ,          ");
		sql.append("        C.SUBUL_DANUI                                          SUBUL_DANUI          ,                                   ");
		sql.append("        FN_OCS_LOAD_CODE_NAME('ORD_DANUI', C.SUBUL_DANUI,:f_hosp_code,:f_language )      SUBUL_DANUI_NAME     ,         ");
		sql.append("        A.START_DATE                                           HANGMOG_START_DATE                                       ");
		sql.append("   FROM (( SELECT X.SG_CODE                                                                                             ");
		sql.append("               , X.DANUI                                                                                                ");
		sql.append("            FROM BAS0310 X                                                                                              ");
		sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                             ");
		sql.append("             AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                      ");
		sql.append("                                FROM BAS0310 Z                                                                          ");
		sql.append("                               WHERE Z.HOSP_CODE = X.HOSP_CODE                                                          ");
		sql.append("                                 AND Z.SG_CODE   = X.SG_CODE                                                            ");
		sql.append("                                 AND Z.SG_YMD   <= SYSDATE() )                                                          ");
		sql.append("        ) B RIGHT JOIN OCS0103 A ON B.SG_CODE  = A.SG_CODE)                                                             ");
		sql.append("        LEFT JOIN  INV0110 C ON C.JAERYO_CODE  = A.JAERYO_CODE AND C.HOSP_CODE   = A.HOSP_CODE                          ");
		sql.append("  WHERE A.HOSP_CODE           = :f_hosp_code                                                                            ");
		sql.append("    AND A.HANGMOG_NAME_INX LIKE :f_hangmog_name_inx                                                                     ");
		sql.append("    AND A.SLIP_CODE        LIKE :f_slip_code                                                                            ");
		sql.append("    AND ( A.HANGMOG_CODE LIKE '6%' OR A.HANGMOG_CODE LIKE '7%' )                                                        ");
		sql.append("  ORDER BY A.HANGMOG_CODE																								");
		sql.append("  LIMIT  500             																								");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hangmog_name_inx", hangmogNameInx);
		query.setParameter("f_slip_code", slipCode);
		List<OCS0108U00grdOCS0103ItemInfo> listResult = new JpaResultMapper()
				.list(query, OCS0108U00grdOCS0103ItemInfo.class);
		return listResult;
	}

	@Override
	public List<OBLoadSearchOrderInfoDRGInfo> getOBLoadSearchOrderInfoDRGInfo(
			String hospCode, String language, String genericSearchYn,
			String searchWord, String gijunDate, String wonnaeDrgYn,
			String inputTab, String protocolId, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		if (StringUtils.isEmpty(searchWord)) {
			searchWord = "%";
		}
		if(YesNo.YES.getValue().equals(genericSearchYn)){
			sql.append(" SELECT  A.SLIP_CODE                                                                                                                    ");
			sql.append("     , B.SLIP_NAME                                                                                                                      ");
			sql.append("     , A.HANGMOG_CODE                                                                                                                   ");
			sql.append("     , A.HANGMOG_NAME                                                                                                                   ");
			sql.append("     , IFNULL(A.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN                                                                                       ");
			sql.append("     , F.GENERIC_NAME                                                                                                                   ");
			sql.append("     , CAST(' ' AS CHAR)                                                                                                                ");
			sql.append("     , SUBSTR(F.GENERIC_CODE_ORG, 1, 9)                                                                                                 ");
			sql.append("     , F.GENERIC_CODE_ORG                                                                                                               ");
			sql.append("     , A.YAK_KIJUN_CODE , A.TRIAL_FLG                                                                                                   ");
			sql.append("  FROM                                                                                                                                  ");
			sql.append("      (( XRT0001 D RIGHT JOIN  OCS0103 A ON D.HOSP_CODE  = A.HOSP_CODE AND D.XRAY_CODE = A.HANGMOG_CODE )                               ");
			sql.append("       LEFT JOIN XRT0122 E  ON E.HOSP_CODE = D.HOSP_CODE AND E.BUWI_CODE = D.XRAY_BUWI AND E.LANGUAGE = :f_language)                    ");
			sql.append("       LEFT JOIN ( SELECT DISTINCT A.HOSP_CODE AS HOSP_CODE																				");
			sql.append("                                   , A.HANGMOG_CODE AS HANGMOG_CODE  										                            ");
			sql.append("                                   , A.HANGMOG_NAME AS HANGMOG_NAME                                                                     ");
			sql.append("                                   , A.YAK_KIJUN_CODE AS YAK_KIJUN_CODE                                                                 ");
			sql.append("                                   , C.GENERIC_CODE_ORG AS GENERIC_CODE_ORG                                                             ");
			sql.append("                                   , C.GENERIC_NAME AS GENERIC_NAME 								                                    ");
			sql.append("	   FROM ((OCS0109 C JOIN OCS0110 B) JOIN OCS0103 A)   																				");
			sql.append("       WHERE ((B.HOSP_CODE = A.HOSP_CODE) AND (B.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE)                                                     ");
			sql.append("          AND (C.HOSP_CODE = B.HOSP_CODE) AND (C.GENERIC_CODE_ORG = B.GENERIC_CODE_ORG))                                                ");
			sql.append("	      AND C.HOSP_CODE = :f_hosp_code   																							    ");
			sql.append("          AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                           ");
			sql.append("	   UNION ALL 																													    ");
			sql.append("          SELECT DISTINCT A.HOSP_CODE AS HOSP_CODE																						");
			sql.append("                         , A.HANGMOG_CODE AS HANGMOG_CODE																				");
			sql.append("                         , A.HANGMOG_NAME AS HANGMOG_NAME                                                                               ");
			sql.append("                         , A.YAK_KIJUN_CODE AS YAK_KIJUN_CODE																		    ");
			sql.append("                         , C.GENERIC_CODE_ORG AS GENERIC_CODE_ORG																		");
			sql.append("                         , C.GENERIC_NAME AS GENERIC_NAME              																    ");
			sql.append("          FROM (OCS0109 C JOIN OCS0103 A)    																							");
			sql.append("	      WHERE ((C.HOSP_CODE = A.HOSP_CODE) AND (C.GENERIC_CODE = A.YAK_KIJUN_CODE_SHORT)    											");
			sql.append("	           AND C.HOSP_CODE = :f_hosp_code AND (NOT(EXISTS(SELECT NULL FROM OCS0110 Z WHERE ((Z.HOSP_CODE = A.HOSP_CODE)             ");
			sql.append("               AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                      ");
			sql.append("               AND (Z.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE)))))))  F 																		");                       
			sql.append("          ON F.HOSP_CODE = A.HOSP_CODE AND F.HANGMOG_CODE= A.HANGMOG_CODE         														");
			sql.append("  , OCS0142 C, OCS0102 B        							   																		    ");	
			sql.append("   WHERE  :f_aGenericSearchYN  = 'Y'								                                                                    ");
			if(!StringUtils.isEmpty(protocolId)){
				sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id )) 										");
			}else{
				sql.append("	 AND A.TRIAL_FLG = 'N'																											");
			}
			sql.append("     AND F.GENERIC_NAME LIKE CONCAT('【般】', :f_searchWord)                                                                              ");
			sql.append("     AND A.HOSP_CODE = :f_hosp_code                                                                                                     ");
			sql.append("     AND IFNULL(STR_TO_DATE(:f_aGijunDate, '%Y/%m/%d'),SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE                                   ");
			sql.append("     AND (                                                                                                                              ");
			sql.append("           ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                         ");
			sql.append("             AND                                                                                                                        ");
			sql.append("             IFNULL(A.WONNAE_DRG_YN,'N') LIKE :f_aWonnaeDrgYn )                                                                         ");
			sql.append("           OR                                                                                                                           ");
			sql.append("           ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) )                                                                                   ");
			sql.append("         )                                                                                                                              ");
			sql.append("     AND A.HOSP_CODE = B.HOSP_CODE                                                                                                      ");
			sql.append("         AND A.SLIP_CODE = B.SLIP_CODE                                                                                                  ");
			sql.append("         AND C.HOSP_CODE = A.HOSP_CODE                                                                                                  ");
			sql.append("         AND C.ORDER_GUBUN = A.ORDER_GUBUN                                                                                              ");
			sql.append("         AND C.INPUT_TAB LIKE :f_aInputTab                                                                                              ");
			sql.append("         AND B.LANGUAGE = :f_language                                                                                              		");
			sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                                ");
			if(startNum != null && offset != null){
				sql.append("       LIMIT :f_start_num, :f_offset 																		    					");
			}
		}else if(YesNo.NO.getValue().equals(genericSearchYn)){
//			sql.append("     UNION ALL                                                                                                                          ");
			sql.append("         SELECT  A.SLIP_CODE                                                                                                            ");
			sql.append("             , B.SLIP_NAME                                                                                                              ");
			sql.append("             , A.HANGMOG_CODE                                                                                                           ");
			sql.append("             , A.HANGMOG_NAME                                                                                                           ");
			sql.append("             , IFNULL(A.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN                                                                               ");
			sql.append("             , F.GENERIC_NAME                                                                                                           ");
			sql.append("             , CAST(' ' AS CHAR)                                                                                                        ");
			sql.append("             , SUBSTR(F.GENERIC_CODE_ORG, 1, 9)                                                                                         ");
			sql.append("             , F.GENERIC_CODE_ORG                                                                                                       ");
			sql.append("             , A.YAK_KIJUN_CODE  , A.TRIAL_FLG                                                                                          ");
			sql.append("          FROM                                                                                                                          ");
			sql.append("              (( XRT0001 D RIGHT JOIN OCS0103 A ON  D.HOSP_CODE = A.HOSP_CODE AND D.XRAY_CODE = A.HANGMOG_CODE)                         ");
			sql.append("             LEFT JOIN XRT0122 E ON E.HOSP_CODE = D.HOSP_CODE AND E.BUWI_CODE= D.XRAY_BUWI AND E.LANGUAGE = :f_language)                ");
			sql.append("       LEFT JOIN ( SELECT DISTINCT A.HOSP_CODE AS HOSP_CODE																				");
			sql.append("                                   , A.HANGMOG_CODE AS HANGMOG_CODE  										                            ");
			sql.append("                                   , A.HANGMOG_NAME AS HANGMOG_NAME                                                                     ");
			sql.append("                                   , A.YAK_KIJUN_CODE AS YAK_KIJUN_CODE                                                                 ");
			sql.append("                                   , C.GENERIC_CODE_ORG AS GENERIC_CODE_ORG                                                             ");
			sql.append("                                   , C.GENERIC_NAME AS GENERIC_NAME 								                                    ");
			sql.append("	   FROM ((OCS0109 C JOIN OCS0110 B) JOIN OCS0103 A)   																				");
			sql.append("       WHERE ((B.HOSP_CODE = A.HOSP_CODE) AND (B.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE)                                                     ");
			sql.append("          AND (C.HOSP_CODE = B.HOSP_CODE) AND (C.GENERIC_CODE_ORG = B.GENERIC_CODE_ORG))                                                ");
			sql.append("	      AND C.HOSP_CODE = :f_hosp_code   																							    ");
			sql.append("          AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                           ");
			sql.append("	   UNION ALL 																													    ");
			sql.append("          SELECT DISTINCT A.HOSP_CODE AS HOSP_CODE																						");
			sql.append("                         , A.HANGMOG_CODE AS HANGMOG_CODE																				");
			sql.append("                         , A.HANGMOG_NAME AS HANGMOG_NAME                                                                               ");
			sql.append("                         , A.YAK_KIJUN_CODE AS YAK_KIJUN_CODE																		    ");
			sql.append("                         , C.GENERIC_CODE_ORG AS GENERIC_CODE_ORG																		");
			sql.append("                         , C.GENERIC_NAME AS GENERIC_NAME              																    ");
			sql.append("          FROM (OCS0109 C JOIN OCS0103 A)    																							");
			sql.append("	      WHERE ((C.HOSP_CODE = A.HOSP_CODE) AND (C.GENERIC_CODE = A.YAK_KIJUN_CODE_SHORT)    											");
			sql.append("	           AND C.HOSP_CODE = :f_hosp_code AND (NOT(EXISTS(SELECT NULL FROM OCS0110 Z WHERE ((Z.HOSP_CODE = A.HOSP_CODE)             ");
			sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                                ");
			sql.append("               AND (Z.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE)))))))  F 																		");                       
			sql.append("          ON F.HOSP_CODE = A.HOSP_CODE AND F.HANGMOG_CODE= A.HANGMOG_CODE         														");
			sql.append("  , OCS0142 C, OCS0102 B        							   																		    ");	
			sql.append("   WHERE  :f_aGenericSearchYN  = 'N'     																								");
			if(!StringUtils.isEmpty(protocolId)){
				sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id )) 										");
			}else{
				sql.append("	 AND A.TRIAL_FLG = 'N'																											");
			}
			sql.append("         AND A.HANGMOG_NAME_INX LIKE :f_searchWord                                                                                      ");
			sql.append("         AND A.HOSP_CODE = :f_hosp_code                                                                                                 ");
			sql.append("         AND IFNULL(STR_TO_DATE(:f_aGijunDate, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE                              ");
			sql.append("         AND (                                                                                                                          ");
			sql.append("               ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                                     ");
			sql.append("                 AND                                                                                                                    ");
			sql.append("                 IFNULL(A.WONNAE_DRG_YN,'N') LIKE :f_aWonnaeDrgYn )                                                                     ");
			sql.append("               OR                                                                                                                       ");
			sql.append("               ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) )                                                                               ");
			sql.append("             )                                                                                                                          ");
			sql.append("         AND A.HOSP_CODE = B.HOSP_CODE                                                                                                  ");
			sql.append("         AND A.SLIP_CODE = B.SLIP_CODE                                                                                                  ");
			sql.append("         AND C.HOSP_CODE = A.HOSP_CODE                                                                                                  ");
			sql.append("         AND C.ORDER_GUBUN = A.ORDER_GUBUN                                                                                              ");
			sql.append("         AND B.LANGUAGE = :f_language                                                                                              ");
			sql.append("         AND C.INPUT_TAB LIKE :f_aInputTab                                                                                              ");
			sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                                                ");
//			sql.append("       ORDER BY 1, 3																													");
			if(startNum != null && offset != null){
				sql.append("       LIMIT :f_start_num, :f_offset 																		    					");
			}
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_aGenericSearchYN", genericSearchYn);
		query.setParameter("f_searchWord", searchWord);
		query.setParameter("f_aGijunDate", gijunDate);
		query.setParameter("f_aWonnaeDrgYn", wonnaeDrgYn);
		query.setParameter("f_aInputTab", inputTab);
		if(startNum != null && offset != null){
			query.setParameter("f_start_num", startNum);
			query.setParameter("f_offset", offset);
		}		
		List<OBLoadSearchOrderInfoDRGInfo> listResult = new JpaResultMapper()
				.list(query, OBLoadSearchOrderInfoDRGInfo.class);
		return listResult;
	}

	@Override
	public List<OBGetJundaTable1Info> getOBGetJundaTable1Info(String hospCode,
			String hangmogCode, String ioeGubun, String jundalPart) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.JUNDAL_TABLE_OUT, B.JUNDAL_PART_OUT, B.MOVE_PART, B.JUNDAL_TABLE_INP, B.JUNDAL_PART_INP      ");
		sql.append("    FROM OCS0103 A                                                                                     ");
		sql.append("       , OCS0115 B                                                                                     ");
		sql.append("   WHERE A.HOSP_CODE          = :f_hosp_code                                                           ");
		sql.append("     AND A.HANGMOG_CODE       = :f_aHangmogCode                                                        ");
		sql.append("     AND SYSDATE()       BETWEEN A.START_DATE AND A.END_DATE                                           ");
		sql.append("     AND B.HOSP_CODE          = A.HOSP_CODE                                                            ");
		sql.append("     AND B.HANGMOG_CODE       = A.HANGMOG_CODE                                                         ");
		sql.append("     AND B.HANGMOG_START_DATE = A.START_DATE                                                           ");
		sql.append("     AND SYSDATE()        BETWEEN B.START_DATE AND B.END_DATE                                          ");
		if (ioeGubun.equalsIgnoreCase("O")) {
			sql.append("     AND B.JUNDAL_PART_OUT  =:f_aJundalPart                                                         ");
		} else {
			sql.append("    AND B.JUNDAL_PART_INP = :f_aJundalPart                                                          ");
		}
		sql.append("   LIMIT  1																								");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aHangmogCode", hangmogCode);
		query.setParameter("f_aJundalPart", jundalPart);
		List<OBGetJundaTable1Info> listResult = new JpaResultMapper().list(
				query, OBGetJundaTable1Info.class);
		return listResult;
	}

	@Override
	public List<OCS0103U17GrdSearchOrderInfo> getOCS0103U17LoadHangwiOrder3ListItem(
			String hospCode, String codeYn, String mode, String slipCode,
			String searchWord, String wonnaeDrgYn, Date orderDate,
			String inputTab, String user, String protocolId,
			Integer pageNumber, Integer offset, String language) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.SLIP_CODE                                 ,															");
		sql.append("	       A.POSITION                                  ,                                                            ");
		sql.append("	       A.SEQ                                       ,                                                            ");
		sql.append("	       A.HANGMOG_CODE                              ,                                                            ");
		sql.append("	       A.HANGMOG_NAME                              ,                                                            ");
		sql.append("	       IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                         ");
		sql.append("	       IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                         ");
		sql.append("	       CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                      ");
		sql.append("	            WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                  ");
		sql.append("	            ELSE 'N'                                                                                            ");
		sql.append("	       END                BULYONG_CHECK,                                                                        ");
		sql.append("	       IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                       ");
		sql.append("	       F.SLIP_NAME,                                                                                             ");
		sql.append("	       A.TRIAL_FLG  TRIAL_FLG                                                                                   ");
		sql.append("	  FROM OCS0142 B                                                                                                ");
		sql.append("	     , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                           ");
		sql.append("	           FROM BAS0310 X                                                                                       ");
		sql.append("	          WHERE X.HOSP_CODE = :hospCode                                                                         ");
		sql.append("	            AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                            ");
		sql.append("	                                  FROM BAS0310 Z                                                                ");
		sql.append("	                                 WHERE Z.HOSP_CODE = X.HOSP_CODE                                                ");
		sql.append("	                                   AND Z.SG_CODE   = X.SG_CODE                                                  ");
		sql.append("	                                   AND Z.SG_YMD <= SYSDATE() )                                                  ");
		sql.append("	       ) D RIGHT JOIN  OCS0103 A ON  D.HOSP_CODE = A.HOSP_CODE    AND D.SG_CODE   = A.SG_CODE                   ");
		sql.append("	     , OCS0102 F                                                                                                ");
		sql.append("	 WHERE :f_code_yn = 'Y'                                                                                         ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                      ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                            ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	            (:f_mode = '1' AND A.SLIP_CODE         = :f_slip_code)                                              ");
		sql.append("	         OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                         ");
		sql.append("	       )                                                                                                        ");
		sql.append("	                                                                                                                ");
		sql.append("	   AND A.HOSP_CODE             = :hospCode                                                                      ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	         ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                   ");
		sql.append("	           AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                             ");
		sql.append("	          OR                                                                                                    ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)      ");
		sql.append("	       )                                                                                                        ");
		sql.append("	   AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))             ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                             ");
		sql.append("	   AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                           ");
		sql.append("	   AND B.INPUT_TAB    = :f_input_tab                                                                            ");
		sql.append("	   AND F.HOSP_CODE = A.HOSP_CODE                                                                                ");
		sql.append("	   AND F.SLIP_CODE = A.SLIP_CODE                                                                                ");
		sql.append("       AND F.LANGUAGE = :f_language                                                                                              ");
		sql.append("	UNION ALL                                                                                                       ");
		sql.append("	SELECT A.SLIP_CODE                                 ,                                                            ");
		sql.append("	       A.POSITION                                  ,                                                            ");
		sql.append("	       E.SEQ                                       ,                                                            ");
		sql.append("	       A.HANGMOG_CODE                              ,                                                            ");
		sql.append("	       A.HANGMOG_NAME                              ,                                                            ");
		sql.append("	       IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                         ");
		sql.append("	       IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                         ");
		sql.append("	       CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                      ");
		sql.append("	            WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                  ");
		sql.append("	            ELSE 'N'                                                                                            ");
		sql.append("	       END                BULYONG_CHECK,                                                                        ");
		sql.append("	       IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                       ");
		sql.append("	       F.SLIP_NAME,                                                                                             ");
		sql.append("	       A.TRIAL_FLG  TRIAL_FLG                                                                                   ");
		sql.append("	  FROM OCS0142 B                                                                                                ");
		sql.append("	     , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                           ");
		sql.append("	           FROM BAS0310 X                                                                                       ");
		sql.append("	          WHERE X.HOSP_CODE = :hospCode                                                                         ");
		sql.append("	            AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                            ");
		sql.append("	                                  FROM BAS0310 Z                                                                ");
		sql.append("	                                 WHERE Z.HOSP_CODE = X.HOSP_CODE                                                ");
		sql.append("	                                   AND Z.SG_CODE   = X.SG_CODE                                                  ");
		sql.append("	                                   AND Z.SG_YMD <= SYSDATE() )                                                  ");
		sql.append("	       ) D RIGHT JOIN  OCS0103 A ON  D.HOSP_CODE = A.HOSP_CODE    AND D.SG_CODE   = A.SG_CODE                   ");
		sql.append("	     , OCS0303 E                                                                                                ");
		sql.append("	     , OCS0102 F                                                                                                ");
		sql.append("	 WHERE :f_code_yn = 'U'                                                                                         ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                      ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                            ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	            (:f_mode = '1' AND E.YAKSOK_CODE         = :f_slip_code)                                            ");
		sql.append("	         OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                         ");
		sql.append("	       )                                                                                                        ");
		sql.append("	   AND A.HOSP_CODE             = :hospCode                                                                      ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	         ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                   ");
		sql.append("	           AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                             ");
		sql.append("	          OR                                                                                                    ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)      ");
		sql.append("	       )                                                                                                        ");
		sql.append("	   AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))             ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                             ");
		sql.append("	   AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                           ");
		sql.append("	   AND B.INPUT_TAB    = :f_input_tab                                                                            ");
		sql.append("	   AND E.HOSP_CODE    = A.HOSP_CODE                                                                             ");
		sql.append("	   AND E.HANGMOG_CODE = A.HANGMOG_CODE                                                                          ");
		sql.append("	   AND E.MEMB         = 'ADMIN'                                                                                 ");
		sql.append("	   AND F.HOSP_CODE = A.HOSP_CODE                                                                                ");
		sql.append("	   AND F.SLIP_CODE = A.SLIP_CODE                                                                                ");
		sql.append("       AND F.LANGUAGE = :f_language                                                                                              ");
		sql.append("	UNION ALL                                                                                                       ");
		sql.append("	SELECT A.SLIP_CODE                                 ,                                                            ");
		sql.append("	       A.POSITION                                  ,                                                            ");
		sql.append("	       E.SEQ                                       ,                                                            ");
		sql.append("	       A.HANGMOG_CODE                              ,                                                            ");
		sql.append("	       A.HANGMOG_NAME                              ,                                                            ");
		sql.append("	       IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                         ");
		sql.append("	       IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                         ");
		sql.append("	       CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                      ");
		sql.append("	            WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                  ");
		sql.append("	            ELSE 'N'                                                                                            ");
		sql.append("	       END                BULYONG_CHECK,                                                                        ");
		sql.append("	       IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                       ");
		sql.append("	       F.SLIP_NAME,                                                                                             ");
		sql.append("	       A.TRIAL_FLG  TRIAL_FLG                                                                                   ");
		sql.append("	  FROM OCS0142 B                                                                                                ");
		sql.append("	     , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                           ");
		sql.append("	           FROM BAS0310 X                                                                                       ");
		sql.append("	          WHERE X.HOSP_CODE = :hospCode                                                                         ");
		sql.append("	            AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                            ");
		sql.append("	                                  FROM BAS0310 Z                                                                ");
		sql.append("	                                 WHERE Z.HOSP_CODE = X.HOSP_CODE                                                ");
		sql.append("	                                   AND Z.SG_CODE   = X.SG_CODE                                                  ");
		sql.append("	                                   AND Z.SG_YMD <= SYSDATE() )                                                  ");
		sql.append("	       ) D RIGHT JOIN OCS0103 A  ON D.HOSP_CODE = A.HOSP_CODE  AND D.SG_CODE = A.SG_CODE                        ");
		sql.append("	     , OCS0303 E                                                                                                ");
		sql.append("	     , OCS0102 F                                                                                                ");
		sql.append("	 WHERE :f_code_yn = 'K'                                                                                         ");
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                      ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                            ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	            (:f_mode = '1' AND E.YAKSOK_CODE         = :f_slip_code)                                            ");
		sql.append("	         OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                         ");
		sql.append("	       )                                                                                                        ");
		sql.append("	   AND A.HOSP_CODE             = :hospCode                                                                      ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	         ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                   ");
		sql.append("	           AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                             ");
		sql.append("	          OR                                                                                                    ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)      ");
		sql.append("	       )                                                                                                        ");
		sql.append("	   AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))             ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                             ");
		sql.append("	   AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                           ");
		sql.append("	   AND B.INPUT_TAB    = :f_input_tab                                                                            ");
		sql.append("	   AND E.HOSP_CODE    = A.HOSP_CODE                                                                             ");
		sql.append("	   AND E.HANGMOG_CODE = A.HANGMOG_CODE                                                                          ");
		sql.append("	   AND E.MEMB         = :f_user                                                                                 ");
		sql.append("	   AND F.HOSP_CODE = A.HOSP_CODE                                                                                ");
		sql.append("	   AND F.SLIP_CODE = A.SLIP_CODE                                                                                ");
		sql.append("       AND F.LANGUAGE = :f_language                                                                                              ");
		sql.append("	UNION ALL                                                                                                       ");
		sql.append("	SELECT A.SLIP_CODE                                 ,                                                            ");
		sql.append("	       A.POSITION                                  ,                                                            ");
		sql.append("	       A.SEQ                                       ,                                                            ");
		sql.append("	       A.HANGMOG_CODE                              ,                                                            ");
		sql.append("	       A.HANGMOG_NAME                              ,                                                            ");
		sql.append("	       IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                         ");
		sql.append("	       IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                         ");
		sql.append("	       CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                      ");
		sql.append("	            WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                  ");
		sql.append("	            ELSE 'N'                                                                                            ");
		sql.append("	       END                BULYONG_CHECK,                                                                        ");
		sql.append("	       IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                       ");
		sql.append("	       F.SLIP_NAME,                                                                                             ");
		sql.append("	       A.TRIAL_FLG  TRIAL_FLG                                                                                   ");
		sql.append("	  FROM OCS0142 B                                                                                                ");
		sql.append("	     , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                           ");
		sql.append("	           FROM BAS0310 X                                                                                       ");
		sql.append("	          WHERE X.HOSP_CODE = :hospCode                                                                         ");
		sql.append("	            AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                            ");
		sql.append("	                                  FROM BAS0310 Z                                                                ");
		sql.append("	                                 WHERE Z.HOSP_CODE = X.HOSP_CODE                                                ");
		sql.append("	                                   AND Z.SG_CODE   = X.SG_CODE                                                  ");
		sql.append("	                                   AND Z.SG_YMD <= SYSDATE() )                                                  ");
		sql.append("	       ) D RIGHT JOIN OCS0103 A  ON D.HOSP_CODE = A.HOSP_CODE  AND D.SG_CODE = A.SG_CODE                        ");
		sql.append("	     , OCS0303 E                                                                                                ");
		sql.append("	     , OCS0102 F                                                                                                ");
		sql.append("	 WHERE :f_code_yn = 'M'                                                                                         ");				
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                      ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                            ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	            (:f_mode = '1' AND E.YAKSOK_CODE         = :f_slip_code)                                            ");
		sql.append("	         OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                         ");
		sql.append("	       )                                                                                                        ");
		sql.append("	   AND A.HOSP_CODE             = :hospCode                                                                      ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	         ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                   ");
		sql.append("	           AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                             ");
		sql.append("	          OR                                                                                                    ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)      ");
		sql.append("	       )                                                                                                        ");
		sql.append("	   AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))             ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                             ");
		sql.append("	   AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                           ");
		sql.append("	   AND B.INPUT_TAB    = :f_input_tab                                                                            ");
		sql.append("	   AND E.HOSP_CODE    = A.HOSP_CODE                                                                             ");
		sql.append("	   AND E.HANGMOG_CODE = A.HANGMOG_CODE                                                                          ");
		sql.append("	   AND E.MEMB         = 'ADMIN'                                                                                 ");
		sql.append("	   AND F.HOSP_CODE = A.HOSP_CODE                                                                                ");
		sql.append("	   AND F.SLIP_CODE = A.SLIP_CODE                                                                                ");
		sql.append("       AND F.LANGUAGE = :f_language                                                                                              ");
		sql.append("	UNION ALL                                                                                                       ");
		sql.append("	SELECT A.SLIP_CODE                                 ,                                                            ");
		sql.append("	       A.POSITION                                  ,                                                            ");
		sql.append("	       A.SEQ                                       ,                                                            ");
		sql.append("	       A.HANGMOG_CODE                              ,                                                            ");
		sql.append("	       A.HANGMOG_NAME                              ,                                                            ");
		sql.append("	       IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                         ");
		sql.append("	       IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                         ");
		sql.append("	       CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                      ");
		sql.append("	            WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'                  ");
		sql.append("	            ELSE 'N'                                                                                            ");
		sql.append("	       END                BULYONG_CHECK,                                                                        ");
		sql.append("	       IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                       ");
		sql.append("	       F.SLIP_NAME,                                                                                             ");
		sql.append("	       A.TRIAL_FLG  TRIAL_FLG                                                                                   ");
		sql.append("	  FROM OCS0142 B                                                                                                ");
		sql.append("	     , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                           ");
		sql.append("	           FROM BAS0310 X                                                                                       ");
		sql.append("	          WHERE X.HOSP_CODE = :hospCode                                                                         ");
		sql.append("	            AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                            ");
		sql.append("	                                  FROM BAS0310 Z                                                                ");
		sql.append("	                                 WHERE Z.HOSP_CODE = X.HOSP_CODE                                                ");
		sql.append("	                                   AND Z.SG_CODE   = X.SG_CODE                                                  ");
		sql.append("	                                   AND Z.SG_YMD <= SYSDATE() )                                                  ");
		sql.append("	       ) D RIGHT JOIN OCS0103 A  ON D.HOSP_CODE = A.HOSP_CODE  AND D.SG_CODE = A.SG_CODE                        ");
		sql.append("	     , OCS0303 E                                                                                                ");
		sql.append("	     , OCS0102 F                                                                                                ");
		sql.append("	 WHERE :f_code_yn = 'N'                                                                                         ");			
		if (!StringUtils.isEmpty(protocolId)) {
			sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))                    ");
		} else {
			sql.append("	 AND A.TRIAL_FLG = 'N'                                                                                      ");
		}
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                            ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	            (:f_mode = '1' AND E.YAKSOK_CODE         = :f_slip_code)                                            ");
		sql.append("	         OR (:f_mode = '2' AND A.HANGMOG_NAME_INX  LIKE :f_search_word)                                         ");
		sql.append("	       )                                                                                                        ");
		sql.append("	   AND A.HOSP_CODE             = :hospCode                                                                      ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	         ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                                   ");
		sql.append("	           AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                             ");
		sql.append("	          OR                                                                                                    ");
		sql.append("	          ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn)      ");
		sql.append("	       )                                                                                                        ");
		sql.append("	   AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))             ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                             ");
		sql.append("	   AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                           ");
		sql.append("	   AND B.INPUT_TAB    = :f_input_tab                                                                            ");
		sql.append("	   AND E.HOSP_CODE    = A.HOSP_CODE                                                                             ");
		sql.append("	   AND E.HANGMOG_CODE = A.HANGMOG_CODE                                                                          ");
		sql.append("	   AND E.MEMB         = :f_user                                                                                 ");
		sql.append("	   AND F.HOSP_CODE = A.HOSP_CODE                                                                                ");
		sql.append("	   AND F.SLIP_CODE = A.SLIP_CODE                                                                                ");
		sql.append("       AND F.LANGUAGE = :f_language                                                                                              ");
		sql.append("	ORDER BY 3                                                                                                      ");
		sql.append(" LIMIT :f_page_number,:f_offset                                                                                     ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_code_yn", codeYn);
		query.setParameter("f_mode", mode);
		query.setParameter("f_slip_code", slipCode);
		query.setParameter("f_search_word", searchWord);
		query.setParameter("f_wonnae_drg_yn", wonnaeDrgYn);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("f_language", language);
		query.setParameter("f_user", user);
		if (!StringUtils.isEmpty(protocolId)) {
			query.setParameter("f_protocol_id",
					CommonUtils.parseInteger(protocolId));
		}
		query.setParameter("f_offset", offset);
		query.setParameter("f_page_number", (pageNumber - 1) * offset);

		List<OCS0103U17GrdSearchOrderInfo> list = new JpaResultMapper().list(
				query, OCS0103U17GrdSearchOrderInfo.class);
		return list;
	}

	@Override
	public String getOCS0103U17IsJundalTable(String hospCode,
			String hangmogCode, String ioGubun, String jundalTable) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT COUNT(*) CNT																");
		sql.append("	  FROM OCS0103 A                                                                ");
		sql.append("	     , OCS0115 B                                                                ");
		sql.append("	 WHERE A.HOSP_CODE    = :hospCode                                               ");
		sql.append("	   AND A.HANGMOG_CODE = :hangmogCode                                            ");
		sql.append("	   AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                            ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                             ");
		sql.append("	   AND B.HANGMOG_CODE = A.HANGMOG_CODE                                          ");
		sql.append("	   AND B.HANGMOG_START_DATE = A.START_DATE                                      ");
		sql.append("	   AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE                            ");
		sql.append("	   AND (('O' = :ioGubun AND B.JUNDAL_TABLE_OUT = :jundalTable)                  ");
		sql.append("	        OR ('I' = :ioGubun AND B.JUNDAL_TABLE_INP = :jundalTable))              ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("jundalTable", jundalTable);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getHIGetGenericName(String hospCode, String hangmogCode) {
		LOG.info("[START] getHIGetGenericName : hospCode=" + hospCode
				+ ", hangmogCode=" + hangmogCode);
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT FN_OCS_GET_GENERIC(:f_hosp_code,:f_aHangmog_code)              ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aHangmog_code", hangmogCode);
		List<String> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result)) {
			return result.get(0);
		}
		LOG.info("[END] getHIGetGenericName : hospCode=" + hospCode
				+ ", hangmogCode=" + hangmogCode);
		return null;
	}

	@Override
	public String getHIGetHangmogName(String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT FN_DRG_HANGMOG_NAME( :f_hosp_code,:f_aHangmog_code) ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aHangmog_code", hangmogCode);
		List<String> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result)) {
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<OCS0103U11GrdSlipHangMogListItemInfo> getOCS0103U11GrdSlipHangMog(
			String hospCode, String language, String slipCode,
			String searchWord, Date orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT C.HANGMOG_CODE                                           HANGMOG_CODE,                                          ");
		sql.append("        C.HANGMOG_NAME                                           HANGMOG_NAME,                                          ");
		sql.append("        C.ORDER_GUBUN                                            ORDER_GUBUN,                                           ");
		sql.append("        FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', C.ORDER_GUBUN,:f_hosp_code,:f_language)  ORDER_GUBUN_NAME,             ");
		sql.append("        C.SPECIFIC_COMMENT                                                                                              ");
		sql.append("   FROM OCS0103 C                                                                                                       ");
		sql.append("  WHERE C.HOSP_CODE        = :f_hosp_code                                                                               ");
		sql.append("    AND C.ORDER_GUBUN      IN ('I')                                                                                     ");
		sql.append("    AND C.SLIP_CODE        LIKE :f_slip_code                                                                            ");
		sql.append("    AND C.HANGMOG_NAME_INX LIKE :f_search_word                                                                          ");
		sql.append("    AND :f_order_date BETWEEN C.START_DATE  AND IFNULL(C.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                   ");
		sql.append("  ORDER BY 5, 2, 1																										");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_slip_code", slipCode);
		query.setParameter("f_search_word", searchWord);
		query.setParameter("f_order_date", orderDate);
		List<OCS0103U11GrdSlipHangMogListItemInfo> list = new JpaResultMapper()
				.list(query, OCS0103U11GrdSlipHangMogListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS0103U11LoadSlipHangmogInfo> getOCS0103U11LoadSlipHangmogListItem(
			String hospCode, String language, String slipCode,
			String searchWord, Date orderDate, String protocolId) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT C.HANGMOG_CODE                                           HANGMOG_CODE,									");
		sql.append("	       C.HANGMOG_NAME                                           HANGMOG_NAME,                                   ");
		sql.append("	       C.ORDER_GUBUN                                            ORDER_GUBUN,                                    ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', C.ORDER_GUBUN, :f_hosp_code, :language )  ORDER_GUBUN_NAME,     ");
		sql.append("	       C.SPECIFIC_COMMENT,                                                                                      ");
		sql.append("	       C.TRIAL_FLG                                                                                       		");
		sql.append("	 FROM OCS0103 C                                                                                                 ");
		sql.append("	 WHERE C.HOSP_CODE        = :f_hosp_code   							                                           ");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (C.TRIAL_FLG = 'N' OR (C.TRIAL_FLG = 'Y' AND C.CLIS_PROTOCOL_ID = :f_protocol_id )) 					");
		}else{
			sql.append("	 AND C.TRIAL_FLG = 'N' 																						");
		}
		sql.append("	   AND C.ORDER_GUBUN      IN ('I')                                                                              ");
		sql.append("	   AND C.SLIP_CODE        LIKE :f_slip_code                                                                     ");
		sql.append("	   AND C.HANGMOG_NAME_INX LIKE :f_search_word                                                                   ");
		sql.append("	   AND :f_order_date BETWEEN C.START_DATE                                                                       ");
		sql.append("	                          AND IFNULL(C.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                             ");
		sql.append("	 ORDER BY ISNULL(C.SPECIFIC_COMMENT), 2, 1                                                                      ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_slip_code", slipCode);
		query.setParameter("f_search_word", searchWord);
		query.setParameter("f_order_date", orderDate);
		if(!StringUtils.isEmpty(protocolId)){
			query.setParameter("f_protocol_id", protocolId);
		}
		List<OCS0103U11LoadSlipHangmogInfo> list = new JpaResultMapper().list(
				query, OCS0103U11LoadSlipHangmogInfo.class);
		return list;
	}

	@Override
	public String fnOcsIsGeneralYn(String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();

		sql.append("SELECT FN_OCS_IS_GENERAL_YN(:hospCode, :hangmogCode) ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmogCode", hangmogCode);

		List<Object> list = query.getResultList();
		if (!CollectionUtils.isEmpty(list) && list.get(0) != null) {
			return list.get(0).toString();
		}
		return null;
	}

	@Override
	public List<Ocs0103Q00LoadOcs0103ListItemInfo> getOcs0103Q00LoadOcs0103(
			String hospCode, String queryCode, String orderGubun,
			String childYn, String inputTab, Integer startNum, Integer offset, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT CONCAT('0' , A.ORDER_GUBUN ) ORDER_GUBUN,                                           ");
		sql.append("       A.SLIP_CODE,                                                                                 ");
		sql.append("       IFNULL(B.SLIP_NAME, ' ') SLIP_NAME,                                                          ");
		sql.append("       A.HANGMOG_CODE,                                                                              ");
		sql.append("       A.HANGMOG_NAME,                                                                              ");
		sql.append("       A.SG_CODE                                          SG_CODE      ,                            ");
		sql.append("       CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE()    THEN 'Y'      ");
		sql.append("            WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'      ");
		sql.append("            ELSE 'N'                                                                                ");
		sql.append("            END    BULYONG_CHECK,                                                                   ");
		sql.append("       A.INPUT_CONTROL,                                                                             ");
		sql.append("       IFNULL(D.BUN_CODE, ''),																		");
		sql.append("       A.SEQ  SEQ,                                                                                  ");
		sql.append("       IFNULL(A.WONNAE_DRG_YN, 'N')   WONNAE_DRG_YN                                                 ");
		sql.append("  FROM OCS0103 A LEFT JOIN ( SELECT X.SG_CODE                                                      	");
		sql.append("              , X.SG_NAME                                                                           ");
		sql.append("              , X.SG_YMD                                                                            ");
		sql.append("              , X.BULYONG_YMD                                                                       ");
		sql.append("              , X.BUN_CODE                                                                          ");
		sql.append("              , X.HOSP_CODE                                                                         ");
		sql.append("           FROM BAS0310 X                                                                           ");
		sql.append("          WHERE X.HOSP_CODE = :f_hosp_code AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                    ");
		sql.append("                               FROM BAS0310 Z                                                       ");
		sql.append("                              WHERE Z.HOSP_CODE = :f_hosp_code                                      ");
		sql.append("                                AND Z.SG_CODE = X.SG_CODE                                           ");
		sql.append("                                AND Z.SG_YMD <= SYSDATE())                                          ");
		sql.append("       ) D ON D.HOSP_CODE = :f_hosp_code AND A.SG_CODE = D.SG_CODE                                  ");
		sql.append("         JOIN OCS0102 B ON B.HOSP_CODE = :f_hosp_code AND B.SLIP_CODE = A.SLIP_CODE                 ");
		sql.append("         JOIN OCS0142 C ON C.HOSP_CODE = :f_hosp_code AND A.ORDER_GUBUN = C.ORDER_GUBUN             ");
		sql.append(" WHERE UPPER(A.HANGMOG_NAME_INX) LIKE UPPER(:f_query_code)											");
		sql.append("   AND A.ORDER_GUBUN      LIKE :f_order_gubun                                                       ");
		sql.append("   AND A.HOSP_CODE        = :f_hosp_code                                                            ");
		sql.append("   AND (                                                                                            ");
		sql.append("         ( :f_child_yn = 'Y'                                                                        ");
		sql.append("           AND                                                                                      ");
		sql.append("           A.IF_INPUT_CONTROL != 'P' )                                                              ");
		sql.append("         OR                                                                                         ");
		sql.append("         ( :f_child_yn = 'N'                                                                        ");
		sql.append("           AND                                                                                      ");
		sql.append("           A.IF_INPUT_CONTROL = 'P' )                                                               ");
		sql.append("         OR                                                                                         ");
		sql.append("         ( :f_child_yn = '%' )                                                                      ");
		sql.append("       )                                                                                            ");
		sql.append("                                                                                                    ");
		sql.append("   AND C.INPUT_TAB     LIKE :f_input_tab                                                            ");
		sql.append("   AND B.LANGUAGE     = :f_language                                                              	");
		sql.append("   AND SYSDATE() BETWEEN A.START_DATE AND IFNULl(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))     ");
		sql.append(" LIMIT :f_start_num,:f_offset                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_query_code", "%" + queryCode + "%");
		query.setParameter("f_order_gubun", orderGubun);
		query.setParameter("f_child_yn", childYn);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("f_offset", offset);
		query.setParameter("f_start_num", startNum);
		query.setParameter("f_language", language);

		List<Ocs0103Q00LoadOcs0103ListItemInfo> list = new JpaResultMapper().list(query, Ocs0103Q00LoadOcs0103ListItemInfo.class);
		return list;
	}

	@Override
	public PrOcsLoadSubulSuryangInfo callPrOcsLoadSubulSuryang(String hospCode,
			String gubun, String hangmogCode, String orderDanui,
			Integer divide, String dvTime, Integer orderSuyang, Integer nalsu,
			Date appDate) {

		String ioFlag = null;

		StoredProcedureQuery query = entityManager
				.createStoredProcedureQuery("PR_OCS_LOAD_SUBUL_SURYANG");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DANUI", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DIVIDE", Integer.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DV_TIME", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_SURYANG",
				Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NALSU", Integer.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_APP_DATE", Date.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("O_SUBUL_DANUI", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_SUBUL_SURYANG",
				Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_SUBUL_QTY", Integer.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_FLAG", String.class,
				ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_ORDER_DANUI", orderDanui);
		query.setParameter("I_DIVIDE", divide);
		query.setParameter("I_DV_TIME", dvTime);
		query.setParameter("I_ORDER_SURYANG", orderSuyang);
		query.setParameter("I_NALSU", nalsu);
		query.setParameter("I_APP_DATE", appDate);
		Boolean isValid = query.execute();
		PrOcsLoadSubulSuryangInfo info = new PrOcsLoadSubulSuryangInfo();

		info.setSubulDanui((String) query
				.getOutputParameterValue("O_SUBUL_DANUI"));
		info.setSubulSuryang((Integer) query
				.getOutputParameterValue("O_SUBUL_SURYANG"));
		info.setoFlag((String) query.getOutputParameterValue("O_FLAG"));
		return info;
	}

	@Override
	public List<OCS0311Q00LayDownListQueryEndResInfo> getOCS0311Q00LayDownListQueryEndResInfo(
			String hospCode, String language, String convertHangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HANGMOG_NAME    HANGMOG_NAME                                                                                          ");
		sql.append("       , A.ORD_DANUI       ORD_DANUI                                                                                            ");
		sql.append("       , B.CODE_NAME       ORD_DANUI_NAME                                                                                       ");
		sql.append("       , FN_OCS_BULYONG_CHECK(:f_hosp_code,:t_convert_hangmog_code,SYSDATE()) BULYONG_YN                                        ");
		sql.append("       , C.SLIP_NAME       SLIP_NAME                                                                                            ");
		sql.append("    FROM  OCS0132 B RIGHT JOIN OCS0103 A ON  B.HOSP_CODE = A.HOSP_CODE  AND B.CODE_TYPE = 'ORD_DANUI'                           ");
		sql.append("     AND A.ORD_DANUI    = B.CODE AND B.LANGUAGE = :f_language                                                                   ");
		sql.append("       RIGHT JOIN OCS0102 C ON C.HOSP_CODE = A.HOSP_CODE AND A.SLIP_CODE    = C.SLIP_CODE   AND A.SLIP_CODE    = C.SLIP_CODE    ");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code                                                                                          ");
		sql.append("     AND A.HANGMOG_CODE = TRIM(:t_convert_hangmog_code)																			");
		sql.append("     AND C.LANGUAGE = :f_language																			");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("t_convert_hangmog_code", convertHangmogCode);

		List<OCS0311Q00LayDownListQueryEndResInfo> list = new JpaResultMapper()
				.list(query, OCS0311Q00LayDownListQueryEndResInfo.class);
		return list;
	}

	@Override
	public List<XRT0201U00GrdOrderItemInfo> getXRT0201U00GrdOrderItem(
			String hospCode, String language, String ioGubun, String actGubun,
			String reserYn, Date orderDate, Date fromDate, Date toDate,
			String naewonKey, String emergency, String jundalTableCode,
			String jundalPart, String bunho, String doctor) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT																																			");
		sql.append("	       'O'  IN_OUT_GUBUN                                                                                                                        ");
		sql.append("	     , A.PKOCS1003                                                                                                                              ");
		sql.append("	     , IF(A.JUBSU_DATE IS NULL,'N','Y') JUBSU_YN                                                                                                ");
		sql.append("	     , A.HANGMOG_CODE                                                                                                                           ");
		sql.append("	     , D.HANGMOG_NAME                                                                                                                           ");
		sql.append("	     , A.JUBSU_DATE                                                                                                                             ");
		sql.append("	     , A.JUBSU_TIME                                                                                                                             ");
		sql.append("	     , A.ORDER_DATE                                                                                                                             ");
		sql.append("	     , DATE_FORMAT(A.SYS_DATE,'%H%i')           ORDER_TIME                                                                                      ");
		sql.append("	     , IFNULL(A.RESER_DATE, A.HOPE_DATE)                RESER_DATE                                                                              ");
		sql.append("	     , A.RESER_TIME                                                                                                                             ");
		sql.append("	     , A.ACT_DOCTOR                                                                                                                             ");
		sql.append("	     , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR, :f_hosp_code) ACT_DOCTOR_NAME                                                                        ");
		sql.append("	     , A.ACT_BUSEO                                                                                                                              ");
		sql.append("	     , A.ACT_GWA                                                                                                                                ");
		sql.append("	     , A.BUNHO                                                                                                                                  ");
		sql.append("	     , B.SUNAME                                                                                                                                 ");
		sql.append("	     , B.SUNAME2                                                                                                                                ");
		sql.append("	     , A.GWA                                                                                                                                    ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.SYS_DATE, :f_hosp_code, :language)                                                                         ");
		sql.append("	     , A.DOCTOR                                                                                                                                 ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, :f_hosp_code)                                                                            ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, :f_hosp_code)    INPUT_DOCTOR                                                            ");
		sql.append("	     , A.ORDER_REMARK                                                                                                                           ");
		sql.append("	     , B.BIRTH                                                                                                                                  ");
		sql.append("	     , CONCAT(B.SEX,'/',FN_BAS_LOAD_AGE(SYSDATE(),B.BIRTH,NULL))                                                                                ");
		sql.append("	     , CONCAT(FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO, :f_hosp_code),'/',FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO, :f_hosp_code))  WEIGHT_HEIGHT     ");
		sql.append("	     , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','O', :f_hosp_code, :language)                                                                          ");
		sql.append("	     , B.PACE_MAKER_YN                                                                                                                          ");
		sql.append("	     , ''                                                                                                                                       ");
		sql.append("	     , FN_OCS_LAST_ACT_DATE(:f_hosp_code, :language,A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)                                                       ");
		sql.append("	     , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO, :f_hosp_code)                                                                                       ");
		sql.append("	     , A.JUNDAL_TABLE                                                                                                                           ");
		sql.append("	     , A.JUNDAL_PART                                                                                                                            ");
		sql.append("	     , A.FKOUT1001                                                                                                                              ");
		sql.append("	     , IF(A.RESER_DATE IS NULL,'N','Y') RESER_YN                                                                                                ");
		sql.append("	     , A.EMERGENCY                                                                                                                              ");
		sql.append("	     , A.SUNAB_SURYANG                                                                                                                          ");
		sql.append("	     , IF(A.ACTING_DATE IS NULL,'N','Y') OLD_ACT_YN                                                                                             ");
		sql.append("	     , A.IF_DATA_SEND_YN                                                                                                                        ");
		sql.append("	     , CASE WHEN A.JUNDAL_PART = 'DR' THEN IFNULL(A.XRT_DR_YN, 'Y')                                                                             ");
		sql.append("	            ELSE A.XRT_DR_YN                                                                                                                    ");
		sql.append("	       END  AS XRT_DR_YN                                                                                                                        ");
		sql.append("	     , IF(A.ACTING_DATE IS NULL,'N','Y')  ACT_YN                                                                                                ");
		sql.append("	     , A.ACTING_DATE                                                                                                                            ");
		sql.append("	     , A.ACTING_TIME                                                                                                                            ");
		sql.append("	     , A.DANGIL_GUMSA_RESULT_YN                                                                                                                 ");
		sql.append("	     , ''                            PORTABLE_YN                                                                                                ");
		sql.append("	  FROM OCS0103 D                                                                                                                                ");
		sql.append("	     , OCS0132 C                                                                                                                                ");
		sql.append("	     , OUT0101 B                                                                                                                                ");
		sql.append("	     , OCS1003 A                                                                                                                                ");
		sql.append("	 WHERE :f_io_gubun    = 'O'                                                                                                                     ");
		sql.append("	   AND ( ( :f_act_gubun = '1' )                                                                                                                 ");
		sql.append("	      OR ( :f_act_gubun = '2' AND A.JUBSU_DATE IS NULL AND A.ACTING_DATE IS NULL AND A.RESULT_DATE IS NULL)                                     ");
		sql.append("	      OR ( :f_act_gubun = '3' AND A.JUBSU_DATE IS NOT NULL AND A.ACTING_DATE IS NULL AND A.RESULT_DATE IS NULL)                                 ");
		sql.append("	      OR ( :f_act_gubun = '4' AND A.JUBSU_DATE IS NOT NULL AND A.ACTING_DATE IS NOT NULL AND A.RESULT_DATE IS NOT NULL) )                       ");
		sql.append("	   AND A.HOSP_CODE    = :f_hosp_code                                                                                                            ");
		sql.append("	   AND ( (:f_reser_yn = 'N' AND A.RESER_DATE IS NULL AND A.ORDER_DATE = :f_order_date)                                                          ");
		sql.append("	      OR (:f_reser_yn = 'Y' AND A.ORDER_DATE = :f_order_date AND A.RESER_DATE BETWEEN :f_from_date AND :f_to_date))                             ");
		sql.append("	   AND IFNULL(A.DC_YN, 'N') != 'Y'                                                                                                              ");
		sql.append("	   AND A.NALSU > 0                                                                                                                              ");
		sql.append("	  AND A.FKOUT1001    = :f_naewon_key                                                                                                           ");
		sql.append("	  AND A.EMERGENCY    = :f_emergency                                                                                                             ");
		sql.append("	   AND C.CODE_TYPE    = 'OCS_ACT_SYSTEM'                                                                                                        ");
		sql.append("	  AND C.MENT         = :f_jundal_table_code                                                                                                     ");
		sql.append("	   AND C.HOSP_CODE    = A.HOSP_CODE                                                                                                             ");
		sql.append("	   AND C.LANGUAGE     = :language                                                                                                               ");
		sql.append("	   AND A.JUNDAL_TABLE = C.MENT                                                                                                                  ");
		sql.append("	  AND A.JUNDAL_PART  LIKE :f_jundal_part                                                                                                        ");
		sql.append("	  AND A.BUNHO        = :f_bunho                                                                                                   			    ");
		sql.append("	   AND B.BUNHO        = A.BUNHO                                                                                                                 ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                             ");
		sql.append("	   AND D.HANGMOG_CODE = A.HANGMOG_CODE                                                                                                          ");
		sql.append("	   AND D.HOSP_CODE    = A.HOSP_CODE                                                                                                             ");
		sql.append("	   AND EXISTS (SELECT 'X'                                                                                                                       ");
		sql.append("	                 FROM OUT1001 X                                                                                                                 ");
		sql.append("	                WHERE X.HOSP_CODE   = A.HOSP_CODE                                                                                               ");
		sql.append("	                  AND X.NAEWON_DATE = IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                                        ");
		sql.append("	                  AND X.BUNHO       = A.BUNHO                                                                                                   ");
		sql.append("	                  AND X.GWA         != '03')                                                                                                    ");
		sql.append("	 UNION ALL                                                                                                                                      ");
		sql.append("	SELECT                                                                                                                                          ");
		sql.append("	       'I'  IN_OUT_GUBUN                                                                                                                        ");
		sql.append("	     , A.PKOCS2003                                                                                                                              ");
		sql.append("	     , IF(A.JUBSU_DATE IS NULL,'N','Y') JUBSU_YN                                                                                                ");
		sql.append("	     , A.HANGMOG_CODE                                                                                                                           ");
		sql.append("	     , D.HANGMOG_NAME                                                                                                                           ");
		sql.append("	     , A.JUBSU_DATE                                                                                                                             ");
		sql.append("	     , A.JUBSU_TIME                                                                                                                             ");
		sql.append("	     , A.ORDER_DATE                                                                                                                             ");
		sql.append("	     , DATE_FORMAT(A.SYS_DATE,'%H%i')           ORDER_TIME                                                                                      ");
		sql.append("	     , IFNULL(A.RESER_DATE, A.HOPE_DATE)                RESER_DATE                                                                              ");
		sql.append("	     , A.RESER_TIME                                                                                                                             ");
		sql.append("	     , A.ACT_DOCTOR                                                                                                                             ");
		sql.append("	     , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR, :f_hosp_code) ACT_DOCTOR_NAME                                                                        ");
		sql.append("	     , A.ACT_BUSEO                                                                                                                              ");
		sql.append("	     , A.ACT_GWA                                                                                                                                ");
		sql.append("	     , A.BUNHO                                                                                                                                  ");
		sql.append("	     , B.SUNAME                                                                                                                                 ");
		sql.append("	     , B.SUNAME2                                                                                                                                ");
		sql.append("	     , E.GWA                                                                                                                                    ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(E.GWA, A.SYS_DATE, :f_hosp_code, :language)                                                                         ");
		sql.append("	     , A.DOCTOR                                                                                                                                 ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE, :f_hosp_code)                                                                              ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE, :f_hosp_code)    INPUT_DOCTOR                                                      ");
		sql.append("	     , A.ORDER_REMARK                                                                                                                           ");
		sql.append("	     , B.BIRTH                                                                                                                                  ");
		sql.append("	     , CONCAT(B.SEX,'/',FN_BAS_LOAD_AGE(SYSDATE(),B.BIRTH,NULL))                                                                                ");
		sql.append("	     , CONCAT(FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO, :f_hosp_code),'/',FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO, :f_hosp_code)) WEIGHT_HEIGHT      ");
		sql.append("	     , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','I', :f_hosp_code, :language)                                                                          ");
		sql.append("	     , B.PACE_MAKER_YN                                                                                                                          ");
		sql.append("	     , CONCAT(FN_BAS_LOAD_HO_DONG_NAME(E.HO_DONG1,A.ORDER_DATE, :f_hosp_code, :language),'/'                                                    ");
		sql.append("	     ,FN_BAS_LOAD_HO_CODE_NAME(:f_hosp_code, E.HO_DONG1,E.HO_CODE1,A.ORDER_DATE))                                                                             ");
		sql.append("	     , FN_OCS_LAST_ACT_DATE(:f_hosp_code, :language, A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)                                                      ");
		sql.append("	     , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO, :f_hosp_code)                                                                                       ");
		sql.append("	     , A.JUNDAL_TABLE                                                                                                                           ");
		sql.append("	     , A.JUNDAL_PART                                                                                                                            ");
		sql.append("	     , A.FKINP1001   FKOUT1001                                                                                                                  ");
		sql.append("	     , IF(A.RESER_DATE IS NULL,'N','Y') RESER_YN                                                                                                ");
		sql.append("	     , A.EMERGENCY                                                                                                                              ");
		sql.append("	     , A.SUNAB_SURYANG                                                                                                                          ");
		sql.append("	     , IF(A.ACTING_DATE IS NULL,'N','Y')  OLD_ACT_YN                                                                                            ");
		sql.append("	     , A.IF_DATA_SEND_YN                                                                                                                        ");
		sql.append("	     , ''                                  XRT_DR_YN                                                                                            ");
		sql.append("	     , IF(A.ACTING_DATE IS NULL,'N','Y')  ACT_YN                                                                                                ");
		sql.append("	     , A.ACTING_DATE                                                                                                                            ");
		sql.append("	     , A.ACTING_TIME                                                                                                                            ");
		sql.append("	     , ''                      DANGIL_GUMSA_RESULT_YN                                                                                           ");
		sql.append("	     , A.PORTABLE_YN           PORTABLE_YN                                                                                                      ");
		sql.append("	  FROM INP1001 E                                                                                                                                ");
		sql.append("	     , OCS0103 D                                                                                                                                ");
		sql.append("	     , OCS0132 C                                                                                                                                ");
		sql.append("	     , OUT0101 B                                                                                                                                ");
		sql.append("	     , OCS2003 A                                                                                                                                ");
		sql.append("	 WHERE :f_io_gubun    = 'I'                                                                                                                     ");
		sql.append("	   AND ( ( :f_act_gubun = '1' )                                                                                                                 ");
		sql.append("	      OR ( :f_act_gubun = '2' AND A.JUBSU_DATE IS NULL AND A.ACTING_DATE IS NULL AND A.RESULT_DATE IS NULL)                                     ");
		sql.append("	      OR ( :f_act_gubun = '3' AND A.JUBSU_DATE IS NOT NULL AND A.ACTING_DATE IS NULL AND A.RESULT_DATE IS NULL)                                 ");
		sql.append("	      OR ( :f_act_gubun = '4' AND A.JUBSU_DATE IS NOT NULL AND A.ACTING_DATE IS NOT NULL AND A.RESULT_DATE IS NOT NULL) )                       ");
		sql.append("	   AND A.HOSP_CODE    = :f_hosp_code                                                                                                            ");
		sql.append("	   AND ( (:f_reser_yn = 'N' AND A.RESER_DATE IS NULL AND A.ORDER_DATE = :f_order_date)                                                          ");
		sql.append("	      OR (:f_reser_yn = 'Y' AND A.ORDER_DATE = :f_order_date AND A.RESER_DATE BETWEEN :f_from_date AND :f_to_date))                             ");
		sql.append("	   AND IFNULL(A.DC_YN, 'N') != 'Y'                                                                                                              ");
		sql.append("	   AND A.NALSU > 0                                                                                                                              ");
		sql.append("	   AND C.CODE_TYPE    = 'OCS_ACT_SYSTEM'                                                                                                        ");
		sql.append("	   AND C.MENT         = :f_jundal_table_code                                                                                                    ");
		sql.append("	   AND C.HOSP_CODE    = A.HOSP_CODE                                                                                                             ");
		sql.append("	   AND C.LANGUAGE = :language                                                                                                                   ");
		sql.append("	   AND A.JUNDAL_TABLE = C.MENT                                                                                                                  ");
		sql.append("	   AND A.JUNDAL_PART  LIKE :f_jundal_part                                                                                                       ");
		sql.append("	   AND A.BUNHO        = :f_bunho                                                                                                                ");
		sql.append("	   AND A.EMERGENCY    = :f_emergency                                                                                                            ");
		sql.append("	   AND A.DOCTOR       = :f_doctor                                                                                                               ");
		sql.append("	   AND B.BUNHO        = A.BUNHO                                                                                                                 ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                             ");
		sql.append("	   AND D.HANGMOG_CODE = A.HANGMOG_CODE                                                                                                          ");
		sql.append("	   AND D.HOSP_CODE    = A.HOSP_CODE                                                                                                             ");
		sql.append("	   AND E.PKINP1001    = A.FKINP1001                                                                                                             ");
		sql.append("	   AND E.HOSP_CODE    = A.HOSP_CODE                                                                                                             ");
		sql.append("	 ORDER BY 6 desc, 10 DESC, 8 DESC, 2                                                                                                            ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_table_code", jundalTableCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_emergency", emergency);
		query.setParameter("f_reser_yn", reserYn);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_act_gubun", actGubun);
		query.setParameter("language", language);
		query.setParameter("f_naewon_key", naewonKey);
		query.setParameter("f_emergency", emergency);
		query.setParameter("f_doctor", doctor);

		List<XRT0201U00GrdOrderItemInfo> list = new JpaResultMapper().list(
				query, XRT0201U00GrdOrderItemInfo.class);
		return list;
	}

	@Override
	public List<XRT0201U00GrdJaeryoItemInfo> getXRT0201U00GrdJaeryoItem(
			String bunho, String orderDate, String ioGubun, String jundalPart,
			Double fkocs, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.JAERYO_CODE             JAERYO_CODE																					");
		sql.append("	         , D.HANGMOG_NAME             JAERYO_NAME                                                                               ");
		sql.append("	         , IF(SUBSTR(IFNULL(IFNULL(F.SURYANG,G.SURYANG),0),1,1) = '.', CONCAT('0',ROUND(IFNULL(F.SURYANG,G.SURYANG),3))         ");
		sql.append("	         , ROUND(IFNULL(F.SURYANG,G.SURYANG),3)) SURYANG                                                                        ");
		sql.append("	         , IFNULL(F.ORD_DANUI,G.ORD_DANUI)                                        ORD_DANUI                                     ");
		sql.append("	         , A.PKINV1001                                                                                                          ");
		sql.append("	         , :f_bunho                                                                                                             ");
		sql.append("	         , :f_order_date                                                                                                        ");
		sql.append("	         , :f_io_gubun                                                                                                          ");
		sql.append("	         , A.ACTING_DATE                                                                                                        ");
		sql.append("	         , :f_jundal_part                                                                                                       ");
		sql.append("	         , CASE A.IN_OUT_GUBUN WHEN 'I' THEN A.FKOCS2003 WHEN 'O' THEN A.FKOCS1003 END                                          ");
		sql.append("	         , :f_fkocs                                                                                                             ");
		sql.append("	         , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',IFNULL(F.ORD_DANUI,G.ORD_DANUI),:f_hosp_code, :language)         DANUI_NAME        ");
		sql.append("	         , ' '                                                  BUNRYU2                                                         ");
		sql.append("	         , ' '													JAERYO_GUBUN                                                    ");
		sql.append("	         , ' '                    							    JAERYO_YN                                                       ");
		sql.append("	         , D.INPUT_CONTROL                                                                                                      ");
		sql.append("	         , ''    BUN_CODE                                                                                                       ");
		sql.append("	         , A.NALSU                                                                                                              ");
		sql.append("	  FROM  OCS0103 D                                                                                                               ");
		sql.append("	         , INV1001 A																						                    ");
		sql.append("	          LEFT JOIN OCS2003 F ON F.HOSP_CODE = A.HOSP_CODE AND F.PKOCS2003 = A.FKOCS2003                                        ");
		sql.append("	          LEFT JOIN OCS1003 G ON  G.HOSP_CODE = A.HOSP_CODE AND G.PKOCS1003  = A.FKOCS1003                                      ");
		sql.append("	 WHERE A.HOSP_CODE         = :f_hosp_code                                                                                       ");
		sql.append("	   AND A.BOM_SOURCE_KEY    = :f_fkocs                                                                                           ");
		sql.append("	   AND D.HOSP_CODE         = A.HOSP_CODE                                                                                        ");
		sql.append("	   AND D.HANGMOG_CODE      = A.JAERYO_CODE                                                                                      ");
		sql.append("	   AND A.ORDER_DATE        BETWEEN D.START_DATE AND D.END_DATE                                                                  ");
		sql.append("	 ORDER BY A.JAERYO_CODE                                                                						    				");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_fkocs", fkocs);

		List<XRT0201U00GrdJaeryoItemInfo> list = new JpaResultMapper().list(
				query, XRT0201U00GrdJaeryoItemInfo.class);
		return list;
	}

	@Override
	public List<ComBizGetFindWorkerInfo> getComBizGetFindWorkerCaseHangmogCode(
			String hospCode, String find, String arg1) {
		StringBuilder sql = new StringBuilder();

		sql.append("	  SELECT A.HANGMOG_CODE, A.HANGMOG_NAME, A.HANGMOG_NAME_INX 													");
		sql.append("	  FROM OCS0103 A                                                                                                ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                                                                                  ");
		sql.append("	   AND A.HANGMOG_NAME_INX LIKE find                                                                             ");
		sql.append("	   AND A.DISPLAY_YN = 'Y'                                                                                       ");
		sql.append("	   AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:arg1) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')         ");
		sql.append("	   AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:arg1) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')         ");
		sql.append("	 ORDER BY 1, 2                                                                                                  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("find", "%" + find.toUpperCase() + "%");
		query.setParameter("arg1", arg1);

		List<ComBizGetFindWorkerInfo> list = new JpaResultMapper().list(query,
				ComBizGetFindWorkerInfo.class);
		return list;
	}

	@Override
	public List<OCS0103U15GrdSlipHangmogInfo> getOCS0103U15GrdSlipHangmogInfo(
			String hospCode, String mode, String slipCode, String wonnaeDrgYn,
			Date orderDate, String inputTab, String searchWord,
			String protocolId, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		if("1".equals(mode)){
			sql.append(" SELECT A.SLIP_CODE                                 ,                                                      ");
			sql.append("        A.POSITION                                  ,                                                      ");
			sql.append("        A.SEQ                                       ,                                                      ");
			sql.append("        A.HANGMOG_CODE                              ,                                                      ");
			sql.append("        A.HANGMOG_NAME                              ,                                                      ");
			sql.append("        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                   ");
			sql.append("        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                   ");
			sql.append("        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                ");
			sql.append("             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'            ");
			sql.append("             ELSE 'N'                                                                                      ");
			sql.append("        END				BULYONG_CHECK,                                                                     ");
			sql.append("        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                 ");
			sql.append("        A.TRIAL_FLG                         TRIAL_FLG                                                      ");
			sql.append("   FROM OCS0142 B                                                                                          ");
			sql.append("      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                     ");
			sql.append("            FROM BAS0310 X                                                                                 ");
			sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                ");
			sql.append("             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                      ");
			sql.append("                                   FROM BAS0310 Z                                                          ");
			sql.append("                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                          ");
			sql.append("                                    AND Z.SG_CODE   = X.SG_CODE                                            ");
			sql.append("                                    AND Z.SG_YMD <= SYSDATE() )                                            ");
			sql.append("        ) D RIGHT JOIN OCS0103 A ON D.HOSP_CODE = A.HOSP_CODE AND D.SG_CODE	= A.SG_CODE                    ");
			sql.append("  WHERE :f_mode                 = '1'                                                                      ");
			sql.append("    AND A.SLIP_CODE             = :f_slip_code                                                             ");
			sql.append("    AND A.HOSP_CODE             = :f_hosp_code                                                             ");
			sql.append("    AND (                                                                                                  ");
			sql.append("          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                             ");
			sql.append("            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                       ");
			sql.append("	          OR                                                                                           ");
			sql.append("	      ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )");
			sql.append("        )                                                                                                  ");
			sql.append("    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))       ");
			sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                                        ");
			sql.append("    AND B.ORDER_GUBUN = A.ORDER_GUBUN                                                                      ");
			sql.append("    AND B.INPUT_TAB   = :f_input_tab                                                                       ");
			if(!StringUtils.isEmpty(protocolId)){
				sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))           ");
			}else{
				sql.append("	 AND A.TRIAL_FLG = 'N'                                                                             ");
			}
			sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                   ");
			sql.append(" LIMIT :f_start_num,:f_offset                                                                              ");
		}else if("2".equals(mode)){
//			sql.append(" UNION ALL                                                                                                 ");
			sql.append(" SELECT A.SLIP_CODE                                 ,                                                      ");
			sql.append("        A.POSITION                                  ,                                                      ");
			sql.append("        A.SEQ                                       ,                                                      ");
			sql.append("        A.HANGMOG_CODE                              ,                                                      ");
			sql.append("        A.HANGMOG_NAME                              ,                                                      ");
			sql.append("        IFNULL(A.SPECIMEN_DEFAULT, '*')   SPECIMEN_CODE,                                                   ");
			sql.append("        IFNULL(A.GROUP_YN        , 'N')   GROUP_YN     ,                                                   ");
			sql.append("        CASE WHEN IFNULL(A.END_DATE, STR_TO_DATE('99981231','%Y%m%d')) < SYSDATE() THEN 'Y'                ");
			sql.append("             WHEN IFNULL(D.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) < SYSDATE() THEN 'Y'            ");
			sql.append("             ELSE 'N'                                                                                      ");
			sql.append("        END				BULYONG_CHECK,                                                                     ");
			sql.append("        IFNULL(A.WONNAE_DRG_YN, 'N')        WONNAE_DRG_YN,                                                 ");
			sql.append("        A.TRIAL_FLG                         TRIAL_FLG                                                      ");
			sql.append("   FROM OCS0142 B                                                                                          ");
			sql.append("      , ( SELECT X.BULYONG_YMD, X.SG_CODE, X.HOSP_CODE                                                     ");
			sql.append("            FROM BAS0310 X                                                                                 ");
			sql.append("           WHERE X.HOSP_CODE = :f_hosp_code                                                                ");
			sql.append("             AND X.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                      ");
			sql.append("                                   FROM BAS0310 Z                                                          ");
			sql.append("                                  WHERE Z.HOSP_CODE = X.HOSP_CODE                                          ");
			sql.append("                                    AND Z.SG_CODE   = X.SG_CODE                                            ");
			sql.append("                                    AND Z.SG_YMD <= SYSDATE() )                                            ");
			sql.append("        ) D RIGHT JOIN OCS0103 A ON D.HOSP_CODE = A.HOSP_CODE AND D.SG_CODE	= A.SG_CODE                    ");
			sql.append("  WHERE :f_mode                 = '2'                                                                      ");
			sql.append("    AND A.HOSP_CODE             = :f_hosp_code                                                             ");
			sql.append("    AND (                                                                                                  ");
			sql.append("          ( A.ORDER_GUBUN IN ( 'B', 'C', 'D' )                                                             ");
			sql.append("            AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )                                       ");
			sql.append("	          OR                                                                                           ");
			sql.append("	      ( A.ORDER_GUBUN NOT IN ( 'B', 'C', 'D' ) AND IFNULL(A.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn )");
			sql.append("        )                                                                                                  ");
			sql.append("    AND A.HANGMOG_NAME_INX LIKE :f_search_word                                                             ");
			sql.append("    AND :f_order_date BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))       ");
			sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                          ");
			sql.append("    AND B.ORDER_GUBUN = A.ORDER_GUBUN                                                                      ");
			sql.append("    AND B.INPUT_TAB   = :f_input_tab                                                                       ");
			if(!StringUtils.isEmpty(protocolId)){
				sql.append("	 AND (A.TRIAL_FLG = 'N' OR (A.TRIAL_FLG = 'Y' AND A.CLIS_PROTOCOL_ID = :f_protocol_id ))           ");
			}else{
				sql.append("	 AND A.TRIAL_FLG = 'N'                                                                             ");
			}
			sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                   ");
//			sql.append(" ORDER BY 3                                                                                                ");
			sql.append(" LIMIT :f_start_num,:f_offset                                                                              ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_mode", mode);
		query.setParameter("f_wonnae_drg_yn", wonnaeDrgYn);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_tab", inputTab);
		if(!StringUtils.isEmpty(protocolId)){
			query.setParameter("f_protocol_id", protocolId);
		}
		if("1".equals(mode)){
			query.setParameter("f_slip_code", slipCode);
		}else if("2".equals(mode)){
			query.setParameter("f_search_word", searchWord);
		}
		query.setParameter("f_offset", offset);
		query.setParameter("f_start_num", startNum);

		List<OCS0103U15GrdSlipHangmogInfo> list = new JpaResultMapper().list(
				query, OCS0103U15GrdSlipHangmogInfo.class);
		return list;
	}

	@Override
	public List<OCS0203U00GrdOcs0203P1Info> getOCS0203U00GrdOcs0203P1Info(
			String hospCode, String slipCode, String memb) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT :f_memb      MEMB,                    ");
		sql.append("        B.SLIP_CODE      ,                    ");
		sql.append("        999              ,                    ");
		sql.append("        'N'              ,                    ");
		sql.append("        B.HANGMOG_CODE   ,                    ");
		sql.append("        B.HANGMOG_NAME   ,                    ");
		sql.append("        ( CASE WHEN B.END_DATE < SYSDATE()    ");
		sql.append("               THEN 'Y'                       ");
		sql.append("               ELSE 'N' END ) BULYONG_YN,     ");
		sql.append("        'N'     NEW_FLAG                      ");
		sql.append("   FROM OCS0103 B                             ");
		sql.append("  WHERE B.HOSP_CODE        = :f_hosp_code     ");
		sql.append("    AND B.SLIP_CODE        = :f_slip_code     ");
		sql.append(" ORDER BY 4 DESC, 3                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_slip_code", slipCode);
		query.setParameter("f_memb", memb);
		List<OCS0203U00GrdOcs0203P1Info> list = new JpaResultMapper().list(
				query, OCS0203U00GrdOcs0203P1Info.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0118U00FwkOCS0103Info(String hospCode,
			String find1) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.HANGMOG_CODE ,																					");
		sql.append("	       A.HANGMOG_NAME                                                                                   ");
		sql.append("	  FROM OCS0103 A                                                                                        ");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code                                                                      ");
		sql.append("	  AND (A.HANGMOG_NAME_INX LIKE  :f_find1                                                                ");
		sql.append("	        OR A.HANGMOG_CODE     LIKE :f_find1)                                                            ");
		sql.append("	   AND SYSDATE() BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))      ");
		sql.append("	 ORDER BY A.HANGMOG_CODE                                                                                ");
		sql.append("	 LIMIT 100                                                                                              ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", "%" + find1 + "%");

		List<ComboListItemInfo> list = new JpaResultMapper().list(query,
				ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS0118U00GrdOCS0118Info> getOCS0118U00GrdOCS0118Info(
			String hospCode, String hangmogName) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.CONV_CLASS                    ,						");
		sql.append("	      A.CONV_GUBUN                    ,                         ");
		sql.append("	      A.HANGMOG_CODE                  ,                         ");
		sql.append("	      B.HANGMOG_NAME                  ,                         ");
		sql.append("	      A.CONV_HANGMOG                  ,                         ");
		sql.append("	      C.HANGMOG_NAME CONV_HANGMOG_NAME,                         ");
		sql.append("	      A.REMARK                        ,                         ");
		sql.append("	      A.START_DATE                                              ");
		sql.append("	 FROM OCS0118   A,                                              ");
		sql.append("	      OCS0103   B,                                              ");
		sql.append("	      OCS0103   C                                               ");
		sql.append("	WHERE A.CONV_CLASS       = '2'                                  ");
		sql.append("	  AND A.CONV_GUBUN       = '1'                                  ");
		sql.append("	  AND A.HOSP_CODE        = :f_hosp_code                         ");
		sql.append("	  AND B.HANGMOG_CODE     = A.HANGMOG_CODE                       ");
		sql.append("	  AND B.HOSP_CODE        = A.HOSP_CODE                          ");
		sql.append("	  AND C.HANGMOG_CODE     = A.CONV_HANGMOG                       ");
		sql.append("	  AND C.HOSP_CODE        = A.HOSP_CODE                          ");
		sql.append("	  AND ( B.HANGMOG_NAME_INX LIKE :f_hangmog_name_inx             ");
		sql.append("	       OR C.HANGMOG_NAME_INX LIKE :f_hangmog_name_inx )         ");
		sql.append("	ORDER BY A.HANGMOG_CODE, A.START_DATE DESC                      ");
		sql.append("	LIMIT 100                                                       ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_name_inx", "%" + hangmogName + "%");

		List<OCS0118U00GrdOCS0118Info> list = new JpaResultMapper().list(query,
				OCS0118U00GrdOCS0118Info.class);
		return list;
	}

	@Override
	public String callPrAdmUpdateMasterSakura(String hospCode, String userId,
			String procGubun) {
		StoredProcedureQuery query = entityManager
				.createStoredProcedureQuery("PR_ADM_UPDATE_MASTER_SAKURA");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PROC_GUBUN", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_FLAG", String.class,
				ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_PROC_GUBUN", procGubun);

		String result = (String) query.getOutputParameterValue("IO_ERR_FLAG");
		return result;
	}

	@Override
	public String callPrAdmUpdateMasterGd(String hospCode, String userId,
			String procGubun) {
		StoredProcedureQuery query = entityManager
				.createStoredProcedureQuery("PR_ADM_UPDATE_MASTER_GDS");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PROC_GUBUN", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_FLAG", String.class,
				ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_PROC_GUBUN", procGubun);

		String result = (String) query.getOutputParameterValue("IO_ERR_FLAG");
		return result;
	}

	@Override
	public List<ComboListItemInfo> getClis2015U13TrialItemListInfo(
			String hospCode, String protocolId) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT HANGMOG_CODE, HANGMOG_NAME	      ");
		sql.append("	FROM OCS0103                              ");
		sql.append("	WHERE TRIAL_FLG = 'Y'                     ");
		sql.append("	AND CLIS_PROTOCOL_ID = :protocolId        ");
		sql.append("	AND HOSP_CODE = :hospCode                 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("protocolId", protocolId);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query,
				ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getClis2015U02TrialItemListInfo(
			String hospCode, Integer protocolId, Integer pageNumber,
			Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT HANGMOG_CODE, HANGMOG_NAME	      ");
		sql.append("	FROM OCS0103                              ");
		sql.append("	WHERE TRIAL_FLG = 'Y'                     ");
		sql.append("	AND CLIS_PROTOCOL_ID = :protocolId        ");
		sql.append("	AND HOSP_CODE = :hospCode                 ");
		sql.append("	ORDER BY HANGMOG_CODE                     ");
		if (pageNumber != null) {
			sql.append(" LIMIT :f_page_number,:f_offset           ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("protocolId", protocolId);
		if (pageNumber != null) {
			query.setParameter("f_page_number", pageNumber);
			query.setParameter("f_offset", offset);
		}
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,
				ComboListItemInfo.class);
		return list;
	}

	@Override
	public OCS0103U00SunalAndSubulInfo callFnOcsLoadSunalAndSubulDanuiName(
			String hospCode, String language, String hangmogCode,
			Date hangmogStartDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" select FN_OCS_LOAD_SUNAB_DANUI_NAME(:f_hosp_code, :f_language, :f_hangmog_code, :f_hangmog_start_date ) as sunab, ");
		sql.append(" FN_OCS_LOAD_SUBUL_DANUI_NAME(:f_hosp_code, :f_language, :f_hangmog_code, :f_hangmog_start_date ) as subul         ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_hangmog_start_date", hangmogStartDate);
		List<OCS0103U00SunalAndSubulInfo> list = new JpaResultMapper().list(
				query, OCS0103U00SunalAndSubulInfo.class);
		if (!CollectionUtils.isEmpty(list)) {
			return list.get(0);
		}
		return null;
	}


	@Override
	public List<OCS0103U10GrdDrgOrderInfo> listOCS0103U10GrdDrgOrderInfoCaseTrialFlg(
			String hospCode, String language, String mode, String code1,
			String wonnaeDrgYn, Date orderDate, String searchWord,
			String protocolId) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT C.HANGMOG_CODE                           HANGMOG_CODE ,                         					    ");
		sql.append("         C.HANGMOG_NAME                                           HANGMOG_NAME            ,                     ");
		sql.append("         FN_OCS_LOAD_WONYOI_CHECK(C.HANGMOG_CODE,:f_hosp_code)    WONYOI_ORDER_CR_YN      ,                     ");
		sql.append("         C.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                     ");
		sql.append("         A.CODE1                                                  CODE1                   ,                     ");
		sql.append("         FN_DRG_LOAD_COMMENT(C.HANGMOG_CODE,:f_hosp_code)         DRG_INFO                ,                     ");
		sql.append("         C.ORDER_GUBUN                                            ORDER_GUBUN             ,                     ");
		sql.append("         FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', C.ORDER_GUBUN,:f_hosp_code,:f_language)  ORDER_GUBUN_NAME,    ");
		sql.append("         IFNULL(C.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN    , C.TRIAL_FLG             ");
		sql.append("   FROM OCS0103 C, INV0110 B, DRG0141 A  													                    ");
		sql.append("   WHERE :f_mode            = '1'                                                                               ");
		sql.append("          AND A.HOSP_CODE        = :f_hosp_code                                                                 ");
		sql.append("          AND A.CODE1            LIKE :f_code1                                                                  ");
		sql.append("          AND B.HOSP_CODE        = A.HOSP_CODE                                                                  ");
		sql.append("          AND B.SMALL_CODE       = A.CODE1                                                                      ");
		sql.append("          AND B.SMALL_CODE       IS NOT NULL                                                                    ");
		sql.append("          AND B.JAERYO_GUBUN     = 'A'                                                                          ");
		sql.append("          AND C.HOSP_CODE        = B.HOSP_CODE                                                                  ");
		sql.append("          AND C.JAERYO_CODE      = B.JAERYO_CODE                                                                ");
		sql.append("          AND C.ORDER_GUBUN      IN ('C', 'D')                                                                  ");
		sql.append("          AND IFNULL(C.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                ");
		sql.append("          AND :f_order_date BETWEEN C.START_DATE AND IFNULL(C.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))      ");
		sql.append("          AND C.TRIAL_FLG = 'Y'													      	                        ");
		sql.append("          AND C.CLIS_PROTOCOL_ID = :protocolId								                                    ");
		sql.append("          AND A.LANGUAGE         = :f_language                                                                  ");
		sql.append(" UNION ALL                                                                                                      ");
		sql.append("  SELECT B.HANGMOG_CODE                                           HANGMOG_CODE    ,                             ");
		sql.append("         B.HANGMOG_NAME                                           HANGMOG_NAME            ,                     ");
		sql.append("         FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE,:f_hosp_code)    WONYOI_ORDER_CR_YN      ,                     ");
		sql.append("         B.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                     ");
		sql.append("         '999'                                                    CODE1                   ,                     ");
		sql.append("         FN_DRG_LOAD_COMMENT(B.HANGMOG_CODE,:f_hosp_code)         DRG_INFO                ,                     ");
		sql.append("         B.ORDER_GUBUN                                            ORDER_GUBUN             ,                     ");
		sql.append("         FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', B.ORDER_GUBUN,:f_hosp_code,:f_language)  ORDER_GUBUN_NAME,    ");
		sql.append("         IFNULL(B.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN  , B.TRIAL_FLG               ");
		sql.append("  FROM OCS0103 B, INV0110 A   																				    ");
		sql.append("  WHERE :f_mode        = '1'                                                                                    ");
		sql.append("         AND :f_code1       =   '999'                                                                           ");
		sql.append("         AND A.HOSP_CODE    = :f_hosp_code                                                                      ");
		sql.append("         AND A.SMALL_CODE   IS  NULL                                                                            ");
		sql.append("         AND A.JAERYO_GUBUN = 'A'                                                                               ");
		sql.append("         AND B.HOSP_CODE    = A.HOSP_CODE                                                                       ");
		sql.append("         AND B.JAERYO_CODE  = A.JAERYO_CODE                                                                     ");
		sql.append("         AND B.ORDER_GUBUN  IN ('C', 'D')                                                                       ");
		sql.append("         AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                 ");
		sql.append("         AND :f_order_date BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))       ");
		sql.append("         AND B.TRIAL_FLG = 'Y'													    	                        ");
		sql.append("         AND B.CLIS_PROTOCOL_ID = :protocolId								                                    ");
		sql.append(" UNION ALL                                                                                                      ");
		sql.append("  SELECT  B.HANGMOG_CODE                                           HANGMOG_CODE            ,                    ");
		sql.append("         B.HANGMOG_NAME                                           HANGMOG_NAME            ,                     ");
		sql.append("         FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE,:f_hosp_code)    WONYOI_ORDER_CR_YN      ,                     ");
		sql.append("         B.WONYOI_ORDER_YN                                        DEFAULT_WONYOI_ORDER_YN ,                     ");
		sql.append("         '999'                                                    CODE1                   ,                     ");
		sql.append("         FN_DRG_LOAD_COMMENT(B.HANGMOG_CODE,:f_hosp_code)         DRG_INFO                ,                     ");
		sql.append("         B.ORDER_GUBUN                                            ORDER_GUBUN             ,                     ");
		sql.append("         FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', B.ORDER_GUBUN,:f_hosp_code,:f_language)  ORDER_GUBUN_NAME,    ");
		sql.append("         IFNULL(B.WONNAE_DRG_YN, 'N')                                WONNAE_DRG_YN     , B.TRIAL_FLG            ");
		sql.append("   FROM OCS0103 B  																                                ");
		sql.append("   WHERE :f_mode        = '2'                                                                                   ");
		sql.append("         AND B.HOSP_CODE    = :f_hosp_code                                                                      ");
		sql.append("         AND B.ORDER_GUBUN IN ( 'C', 'D' )                                                                      ");
		sql.append("         AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :f_wonnae_drg_yn                                                 ");
		sql.append("         AND B.HANGMOG_NAME_INX LIKE :f_search_word                                                             ");
		sql.append("         AND :f_order_date BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))       ");
		sql.append("         AND B.TRIAL_FLG = 'Y'													       	                        ");
		sql.append("         AND B.CLIS_PROTOCOL_ID = :protocolId								                                    ");
		sql.append("   ORDER BY 2, 1																								");
		
		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_mode", mode);
		query.setParameter("f_code1", code1);
		query.setParameter("f_wonnae_drg_yn", wonnaeDrgYn);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_search_word", searchWord);
		query.setParameter("protocolId", protocolId);
		List<OCS0103U10GrdDrgOrderInfo> listResult = new JpaResultMapper()
				.list(query, OCS0103U10GrdDrgOrderInfo.class);
		return listResult;
	}
	@Override
	public List<String> getClassCodeFromOrcaMappring(String hospCode, String sgCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT   A.CLASS_CODE                                  ");    
		sql.append(" FROM  ORCA_MAPPING A                                   ");
		sql.append(" LEFT JOIN OCS0103 B ON   B.SG_CODE = A.ACT_CODE        ");    
		sql.append(" WHERE A.ACT_CODE = :sg_code                            ");
		sql.append(" AND B.HOSP_CODE = :f_hosp_code                         ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("sg_code", sgCode);
		query.setParameter("f_hosp_code", hospCode);
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public List<String> findHangmogCodeExt(String hospCode, String bunho, BigDecimal fkout1001, String hangmogCode){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  A.HANGMOG_CODE_EXT				");
		sql.append(" FROM  OCS0103 A, OCS1003 B				");
		sql.append(" WHERE A.HOSP_CODE = B.HOSP_CODE		");
		sql.append(" AND A.HANGMOG_CODE = B.HANGMOG_CODE	");
		sql.append(" AND B.ACTING_DATE IS NULL				");
		sql.append(" AND A.HOSP_CODE = :f_hosp_code			");
		sql.append(" AND B.FKOUT1001 = :f_fkout1001			");
		sql.append(" AND B.BUNHO = :f_bunho					");
		sql.append(" AND A.HANGMOG_CODE = :f_hangmog_code   ");
		sql.append(" ORDER BY A.START_DATE DESC LIMIT 1		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkout1001", fkout1001);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public String callPrOcs0103U00UpdateMaster(String hospCode) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_OCS0103U00_UPDATE_MASTER_DATA ");
			query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,ParameterMode.IN);
			query.registerStoredProcedureParameter("O_ERR", String.class,ParameterMode.OUT);
			
			query.setParameter("I_HOSP_CODE", hospCode);
			query.execute();
			String erFlg = (String)query.getOutputParameterValue("O_ERR");
			return erFlg;
	}

	@Override
	public LoadHangmogInfo callPrOcsLoadHangmogInfoCommonYn(String hospCode, Date appDate, String inputPart,
			String inputGwa, String hangmogCode, String inputTab) {
		StoredProcedureQuery query = entityManager
				.createStoredProcedureQuery("PR_OCS_LOAD_HANGMOG_INFO_COMMON_ORDER");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_APP_DATE", Date.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_PART", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GWA", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_TAB", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_HANGMOG_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_HANGMOG_NAME", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SLIP_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_GROUP_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_INPUT_TAB", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ORDER_GUBUN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_INPUT_CONTROL",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_TABLE_OUT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_TABLE_INP",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_PART_OUT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_PART_INP",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JAERYO_JUNDAL_YN_OUT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JAERYO_JUNDAL_YN_INP",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MOVE_PART", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SURYANG", Double.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ORD_DANUI", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DV_TIME", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DV", Double.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUSA", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BOGYONG_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUGA_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SG_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JAERYO_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JAERYO_CODE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BULYONG_YMD", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BULYONG_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BULYONG_CHECK_OUT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SPECIMEN_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SPECIMEN_DEFAULT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PORTABLE_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PORTABLE_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_XRAY_BUWI", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_RESER_YN_OUT", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_RESER_YN_INP", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_EMERGENCY", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_EMERGENCY_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BOM_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BICHI_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_WONYOI_ORDER_YN",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_WONYOI_CHECK", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_POWDER_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_POWDER_CHECK", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_NDAY_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_CHISIK_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MUHYO_YN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_NURSE_INPUT_YN",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUPPLY_INPUT_YN",
				String.class, ParameterMode.INOUT);

		query.registerStoredProcedureParameter("IO_LIMIT_NALSU", Double.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_LIMIT_SURYANG",
				Double.class, ParameterMode.INOUT);

		query.registerStoredProcedureParameter("IO_REMARK", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_NURSE_CONFIRM_GUBUN",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SPECIFIC_COMMENT",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_HUBAL_CHANGE_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PHARMACY_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DRG_PACK_CHECK",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY1", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY2", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY3", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY4", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY5", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY6", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY7", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY8", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY9", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MSG", String.class,
				ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_APP_DATE", appDate);
		query.setParameter("I_INPUT_PART", inputPart);
		query.setParameter("I_INPUT_GWA", inputGwa);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_INPUT_TAB", inputTab);

		Boolean isValid = query.execute();

		LoadHangmogInfo info = new LoadHangmogInfo();
		info.setHangmogCode((String) query
				.getOutputParameterValue("IO_HANGMOG_CODE"));
		info.setHangmogName((String) query
				.getOutputParameterValue("IO_HANGMOG_NAME"));
		info.setSlipCode((String) query.getOutputParameterValue("IO_SLIP_CODE"));
		info.setGroupYn((String) query.getOutputParameterValue("IO_GROUP_YN"));
		info.setInputTab((String) query.getOutputParameterValue("IO_INPUT_TAB"));
		info.setOrderGubun((String) query
				.getOutputParameterValue("IO_ORDER_GUBUN"));
		info.setInputControl((String) query
				.getOutputParameterValue("IO_INPUT_CONTROL"));
		info.setJundalTableOut((String) query
				.getOutputParameterValue("IO_JUNDAL_TABLE_OUT"));
		info.setJundalTableInp((String) query
				.getOutputParameterValue("IO_JUNDAL_TABLE_INP"));
		info.setJundalPartOut((String) query
				.getOutputParameterValue("IO_JUNDAL_PART_OUT"));
		info.setJundalPartInp((String) query
				.getOutputParameterValue("IO_JUNDAL_PART_INP"));
		info.setJaeryoJundalYnOut((String) query
				.getOutputParameterValue("IO_JAERYO_JUNDAL_YN_OUT"));
		info.setJaeryoJundalYnInp((String) query
				.getOutputParameterValue("IO_JAERYO_JUNDAL_YN_INP"));
		info.setMovePart((String) query.getOutputParameterValue("IO_MOVE_PART"));
		info.setSuryang((Double) query.getOutputParameterValue("IO_SURYANG"));
		info.setOrdDanui((String) query.getOutputParameterValue("IO_ORD_DANUI"));
		info.setDvTime((String) query.getOutputParameterValue("IO_DV_TIME"));
		info.setDv((Double) query.getOutputParameterValue("IO_DV"));
		info.setJusa((String) query.getOutputParameterValue("IO_JUSA"));
		info.setBogyongCode((String) query
				.getOutputParameterValue("IO_BOGYONG_CODE"));
		info.setSugaYn((String) query.getOutputParameterValue("IO_SUGA_YN"));
		info.setSgCode((String) query.getOutputParameterValue("IO_SG_CODE"));
		info.setJaeryoYn((String) query.getOutputParameterValue("IO_JAERYO_YN"));
		info.setJaeryoCode((String) query
				.getOutputParameterValue("IO_JAERYO_CODE"));
		info.setBulyongYmd((String) query
				.getOutputParameterValue("IO_BULYONG_YMD"));
		info.setBulyongCheck((String) query
				.getOutputParameterValue("IO_BULYONG_CHECK"));
		info.setBulyongCheckOut((String) query
				.getOutputParameterValue("IO_BULYONG_CHECK_OUT"));
		info.setSpecimenYn((String) query
				.getOutputParameterValue("IO_SPECIMEN_YN"));
		info.setSpecimenDefault((String) query
				.getOutputParameterValue("IO_SPECIMEN_DEFAULT"));
		info.setPortableYn((String) query
				.getOutputParameterValue("IO_PORTABLE_YN"));
		info.setPortableCheck((String) query
				.getOutputParameterValue("IO_PORTABLE_CHECK"));
		info.setXrayBuwi((String) query.getOutputParameterValue("IO_XRAY_BUWI"));
		info.setReserYnOut((String) query
				.getOutputParameterValue("IO_RESER_YN_OUT"));
		info.setReserYnInp((String) query
				.getOutputParameterValue("IO_RESER_YN_INP"));
		info.setEmergency((String) query
				.getOutputParameterValue("IO_EMERGENCY"));
		info.setEmergencyCheck((String) query
				.getOutputParameterValue("IO_EMERGENCY_CHECK"));
		info.setBomYn((String) query.getOutputParameterValue("IO_BOM_YN"));
		info.setBichiYn((String) query.getOutputParameterValue("IO_BICHI_YN"));
		info.setWonyoiOrderYn((String) query
				.getOutputParameterValue("IO_WONYOI_ORDER_YN"));
		info.setWonyoiCheck((String) query
				.getOutputParameterValue("IO_WONYOI_CHECK"));
		info.setPowderYn((String) query.getOutputParameterValue("IO_POWDER_YN"));
		info.setPowderCheck((String) query
				.getOutputParameterValue("IO_POWDER_CHECK"));
		info.setNdayYn((String) query.getOutputParameterValue("IO_NDAY_YN"));
		info.setChisikYn((String) query.getOutputParameterValue("IO_CHISIK_YN"));
		info.setMuhyoYn((String) query.getOutputParameterValue("IO_MUHYO_YN"));
		info.setNurseInputYn((String) query
				.getOutputParameterValue("IO_NURSE_INPUT_YN"));
		info.setSupplyInputYn((String) query
				.getOutputParameterValue("IO_SUPPLY_INPUT_YN"));

		info.setLimitSuryang((Double) query
				.getOutputParameterValue("IO_LIMIT_SURYANG"));

		info.setLimitNalsu((Double) query
				.getOutputParameterValue("IO_LIMIT_NALSU"));
		info.setRemark((String) query.getOutputParameterValue("IO_REMARK"));
		info.setNurseConfirmGubun((String) query
				.getOutputParameterValue("IO_NURSE_CONFIRM_GUBUN"));
		info.setSpecificComment((String) query
				.getOutputParameterValue("IO_SPECIFIC_COMMENT"));
		info.setHubalChangeCheck((String) query
				.getOutputParameterValue("IO_HUBAL_CHANGE_CHECK"));
		info.setPharmacyCheck((String) query
				.getOutputParameterValue("IO_PHARMACY_CHECK"));
		info.setDrgPackCheck((String) query
				.getOutputParameterValue("IO_DRG_PACK_CHECK"));
		info.setDummy((String) query.getOutputParameterValue("IO_DUMMY"));
		info.setDummy1((String) query.getOutputParameterValue("IO_DUMMY1"));
		info.setDummy2((String) query.getOutputParameterValue("IO_DUMMY2"));
		info.setDummy3((String) query.getOutputParameterValue("IO_DUMMY3"));
		info.setDummy4((String) query.getOutputParameterValue("IO_DUMMY4"));
		info.setDummy5((String) query.getOutputParameterValue("IO_DUMMY5"));
		info.setDummy6((String) query.getOutputParameterValue("IO_DUMMY6"));
		info.setDummy7((String) query.getOutputParameterValue("IO_DUMMY7"));
		info.setDummy8((String) query.getOutputParameterValue("IO_DUMMY8"));
		info.setDummy9((String) query.getOutputParameterValue("IO_DUMMY9"));
		info.setFlag((String) query.getOutputParameterValue("IO_FLAG"));
		info.setMsg((String) query.getOutputParameterValue("IO_MSG"));

		return info;
	}
	public List<BIL2016U00ServiceInfo> getBIL2016U00ServiceInfo(String hospCode, String hangmogNameInx, String orderGubun, String codeType, String language, Integer pageNumber, Integer offset)
	{
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                                														    			");
		sql.append("			OCS.HANGMOG_CODE , 																								");
		sql.append("			OCS.HANGMOG_NAME ,														 										");
		sql.append("			C.CODE_NAME, 																									");
		sql.append("			BIL.PRICE1, 																									");
		sql.append("			BIL.PRICE2, 																									");
		sql.append("			BIL.PRICE3					   																					");
		sql.append(" FROM OCS0103 OCS LEFT JOIN OCS0132 C  ON OCS.HOSP_CODE = C.HOSP_CODE AND OCS.ORDER_GUBUN = C.CODE			                ");
		sql.append("                  LEFT JOIN BIL0001	BIL	ON	OCS.HOSP_CODE = BIL.HOSP_CODE AND OCS.HANGMOG_CODE = BIL.HANGMOG_CODE 		    ");
		sql.append(" WHERE OCS.HOSP_CODE = :f_hosp_code																						    ");
		sql.append("    AND C.LANGUAGE = :f_language														    							    ");
		sql.append("    AND C.CODE_TYPE = 'ORDER_GUBUN_BAS'				                                                                        ");
		
		
		if(!Strings.isEmpty(hangmogNameInx))
		{
			sql.append(" AND OCS.HANGMOG_NAME_INX LIKE :f_hangmog_name																			");
		}
		if(!Strings.isEmpty(orderGubun))
		{
			sql.append(" AND OCS.ORDER_GUBUN LIKE :f_order_gubun																				");
		}
		sql.append(" ORDER BY ISNULL(BIL.PRICE1) ASC , ISNULL(BIL.PRICE2) ASC , ISNULL(BIL.PRICE3) ASC , OCS.HANGMOG_CODE ASC   				");
		if(pageNumber != null && offset != null){
			sql.append(" LIMIT :f_page_number,:f_offset 																					    ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);

		if(!Strings.isEmpty(hangmogNameInx))
		{
			query.setParameter("f_hangmog_name", "%"+hangmogNameInx+"%");
		}
		if(!Strings.isEmpty(orderGubun))
		{
			query.setParameter("f_order_gubun", orderGubun);
		}
		if(pageNumber != null && offset != null){
			query.setParameter("f_page_number",pageNumber);
			query.setParameter("f_offset", offset);
		}
		List<BIL2016U00ServiceInfo> listResult = new JpaResultMapper()
				.list(query, BIL2016U00ServiceInfo.class);
		return listResult;
	}
	
	public List<String> getCommonYnList(String hospCode, List<String> hangmog){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.COMMON_YN                      	    			");
		sql.append("	 FROM OCS0103 A 										");
		sql.append("	 WHERE  A.HOSP_CODE = :f_hosp_code AND					");
		if(!CollectionUtils.isEmpty(hangmog)) {
			sql.append("	      A.HANGMOG_CODE IN :f_hangmog	AND				");
		}
		sql.append("	    SYSDATE()  BETWEEN A.START_DATE AND A.END_DATE   	");

		Query query = entityManager.createNativeQuery(sql.toString());
		if(!CollectionUtils.isEmpty(hangmog)) {
			query.setParameter("f_hangmog", hangmog);
		}
		query.setParameter("f_hosp_code", hospCode);
		List<String> listResult = query.getResultList();
		return listResult;
	}
	
	// START MIH
	@Override
	public String loadJaeryoYn(String hospCode, String hangmogCode){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_BAS_LOAD_JAERYO_YN(:f_hosp_code, :f_hangmog_code) JAERYO_YN FROM DUAL ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<String> lstResult = query.getResultList();
		return CollectionUtils.isEmpty(lstResult) ? "" : lstResult.get(0);
	}

	@Override
	public List<ComboListItemInfo> getOCS2005U00SetHangmogName(String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.HANGMOG_NAME, B.SLIP_NAME			");
		sql.append("	  FROM OCS0103 A     						");
		sql.append("	     , OCS0102 B     						");
		sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code     	");
		sql.append("	   AND A.SLIP_CODE    = B.SLIP_CODE     	");
		sql.append("	   AND A.HOSP_CODE    = B.HOSP_CODE     	");
		sql.append("	   AND A.HANGMOG_CODE = :f_hangmog_code     ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query,
				ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getOCS2005U00checkInputControl(String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT IF(INPUT_CONTROL = 'A', 'Y', 'N')     INPUT_CONTROL	");
		sql.append("	  FROM OCS0103												");
		sql.append("	 WHERE HOSP_CODE    = :f_hosp_code							");
		sql.append("	   AND SYSDATE() BETWEEN START_DATE AND END_DATE			");
		sql.append("	   AND HANGMOG_CODE = :f_hangmog_code						");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<DRG3010Q12AntibioticListgrdAntibioticListInfo> getDRG3010Q12AntibioticListgrdAntibioticListInfo (String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT C.HANGMOG_CODE                                                       HANGMOG_CODE							");
		sql.append("          , C.HANGMOG_NAME                                                       HANGMOG_NAME							");
		sql.append("          , CASE(:f_language) WHEN 'JA' THEN																			");
		sql.append("             (CASE(C.ORDER_GUBUN) WHEN 'B' THEN '注射薬' WHEN 'C' THEN '内服薬' ELSE '外用薬' END)							");
		sql.append("              WHEN 'VI' THEN																							");
		sql.append("              (CASE(C.ORDER_GUBUN) WHEN 'B' THEN 'Thuốc tiêm' WHEN 'C' THEN 'Thuốc nội' ELSE 'Thuốc ngoại' END)			");
		sql.append("              ELSE																										");
		sql.append("              (CASE(C.ORDER_GUBUN) WHEN 'B' THEN 'Injectable medicine' WHEN 'C' THEN 'Internal medicine'				");
		sql.append("              ELSE 'External medicine' END) END                                  ORDER_GUBUN							");
		sql.append("          , C.YAK_KIJUN_CODE                                                     YAK_KIJUN_CODE							");
		sql.append("          , IFNULL(A.SMALL_CODE, '')                                             SMALL_CODE								");
		sql.append("       FROM OCS0103 C																									");
		sql.append("       JOIN INV0110 A																									");
		sql.append("         ON A.HOSP_CODE               = C.HOSP_CODE																		");
		sql.append("        AND A.JAERYO_CODE             = C.HANGMOG_CODE																	");
		sql.append("        AND A.SMALL_CODE              LIKE '61%'																		");
		sql.append("      WHERE C.HOSP_CODE               = :f_hosp_code																	");
		sql.append("        AND C.WONNAE_DRG_YN           = 'Y'																				");
		sql.append("        AND CURRENT_DATE()            BETWEEN C.START_DATE AND C.END_DATE												");
		sql.append("     ORDER BY C.SLIP_CODE, C.HANGMOG_NAME																				");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<DRG3010Q12AntibioticListgrdAntibioticListInfo> list = new JpaResultMapper().list(query, DRG3010Q12AntibioticListgrdAntibioticListInfo.class);
		return list;
	}
}
