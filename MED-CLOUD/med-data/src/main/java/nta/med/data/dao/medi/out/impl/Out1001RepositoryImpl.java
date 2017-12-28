package nta.med.data.dao.medi.out.impl;

import java.math.BigInteger;
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

import nta.med.core.glossary.ModuleType;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001RepositoryCustom;
import nta.med.data.model.ihis.adma.ADM9999U00GetInformInfo;
import nta.med.data.model.ihis.bass.CreatePatientSurveyInfo;
import nta.med.data.model.ihis.bill.LoadGridBIL2016U02Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LoadChebangPrintInfo;
import nta.med.data.model.ihis.emr.OCS2015U04LoadExaminationInfo;
import nta.med.data.model.ihis.nuro.BookingLabInfo;
import nta.med.data.model.ihis.nuro.KCCKCountTotalOfBookingInfo;
import nta.med.data.model.ihis.nuro.NUR2015U01GrdOrderInfo;
import nta.med.data.model.ihis.nuro.NUR2016U02ActingDateAndSendYnInfo;
import nta.med.data.model.ihis.nuro.NuroChkGetBunhoBySujinInfo;
import nta.med.data.model.ihis.nuro.NuroNUR1001R00GetTempListItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LayoutBarCodeInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LoadCheckChojaeJpnInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LoadOUT0105Info;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01GridInfo;
import nta.med.data.model.ihis.nuro.NuroOutOrderStatus;
import nta.med.data.model.ihis.nuro.NuroPatientCommentInfo;
import nta.med.data.model.ihis.nuro.NuroPatientDetailInfo;
import nta.med.data.model.ihis.nuro.NuroPatientInfo;
import nta.med.data.model.ihis.nuro.NuroPatientInsuranceInfo;
import nta.med.data.model.ihis.nuro.NuroPatientReceptionHistoryInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00DoctorReserListItemInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReserListItemInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReseredDataListItemInfo;
import nta.med.data.model.ihis.nuro.OCS1003P01GrdPatientListItemInfo;
import nta.med.data.model.ihis.nuro.OUT1001P01GrdOUT1001ListItemInfo;
import nta.med.data.model.ihis.nuro.RES1001R00BookingInfo;
import nta.med.data.model.ihis.nuro.RES1001U01BookingClinicReferInfo;
import nta.med.data.model.ihis.ocsa.OCS0503Q00FilteringTheInformationInfo;
import nta.med.data.model.ihis.ocsa.OCS1003Q09GridOUT1001Info;
import nta.med.data.model.ihis.ocsa.OCS3003Q10GrdOrderDateListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003Q02GridOUT1001Info;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridPatientListInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayPatInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05ScheduleItemInfo;
import nta.med.data.model.ihis.nuro.MedicalInfo;
import nta.med.data.model.ihis.phys.PHY2001U04BtnDeleteGetDataTableInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdExcelInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdOut1001Info;
import nta.med.data.model.ihis.phys.PHY2001U04GrdPaCntInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdPatientListInfo;
import nta.med.data.model.ihis.phys.PHY2001U04PrOutMakeAutoJubsuInfo;
import nta.med.data.model.ihis.phys.PHY2001U04RefreshCounterInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99ReserListInfo;
import nta.med.data.model.ihis.system.LoadPatientNaewonListInfo;
import nta.med.data.model.mss.BookingExamInfo;
import nta.med.data.model.phr.SyncDrugInfo;

/**
 * @author dainguyen.
 */
public class Out1001RepositoryImpl implements Out1001RepositoryCustom {
	private static final Log LOG = LogFactory
			.getLog(Out1001RepositoryImpl.class);

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<NuroOutOrderStatus> getNuroOutOrderStatusInfo(String hospCode,
															  String bunho, String naewonDate, String gwa, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT  A.PKOUT1001                                                                                                       ");
		sql.append("      , A.BUNHO                                            BUNHO                                                          ");
		sql.append("      , B.SUNAME                                           SUNAME                                                         ");
		sql.append("      , A.JUBSU_TIME                                       JUBSU_TIME                                                     ");
		sql.append("      , A.NAEWON_DATE                                      NAEWON_DATE                                                    ");
		sql.append("      , IFNULL(A.RESER_YN, 'N')                               RESER_YN                                                    ");
		sql.append("      , A.GWA                                              GWA                                                            ");
		sql.append("      , A.DOCTOR                                           DOCTOR                                                         ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME ( A.GWA, A.NAEWON_DATE, :hospCode, :language )      GWA_NAME                                 ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME ( A.DOCTOR, A.NAEWON_DATE, :hospCode) DOCTOR_NAME                                         ");
		sql.append("      , A.JUBSU_GUBUN                                                                                                     ");
		sql.append("      , IF(A.NAEWON_YN='E','Y','N' )                   NAEWON_YN                                                          ");
		sql.append("      , C.TOT_CNT                                                                                                         ");
		sql.append("      , CONCAT(C.ACTING_CNT , '/' , C.TOT_CNT)              ACTING_PER                                                    ");
		sql.append("      , IF(TOT_CNT = ACTING_CNT, 'Y', 'N')              ALL_END_YN                                                        ");
		sql.append("      , C.ACTING_TIME                                      ACTING_TIME                                                    ");
		sql.append("      , C.DATA_SEND_YN                                     DATA_SEND_YN                                                   ");
		sql.append("  FROM  OUT1001 A                                                                                                         ");
		sql.append("      , OUT0101 B                                                                                                         ");
		sql.append("      , (SELECT Z.HOSP_CODE                                                                                               ");
		sql.append("              , Z.PKOUT1001                                                                                               ");
		sql.append("              , Z.NAEWON_DATE                                                                                             ");
		sql.append("              , COUNT(*) TOT_CNT                                                                                          ");
		sql.append("              , SUM(CASE WHEN Y.ACTING_DATE IS NOT NULL THEN 1                                                            ");
		sql.append("                         WHEN Y.JUNDAL_PART ='HOM' OR Y.JUNDAL_PART='PA' THEN 1                                           ");
		sql.append("                         ELSE 0 END) ACTING_CNT                                                                           ");
		sql.append("                                                                                                                          ");
		sql.append("              , MAX(CASE WHEN Y.JUNDAL_PART = 'PA' OR Y.JUNDAL_PART='HOM' THEN DATE_FORMAT(Y.UPD_DATE,'%Y-%m-%d %H:%m:%s')");
		sql.append("                         ELSE Y.ACTING_TIME END) ACTING_TIME                                                              ");
		sql.append("              , MAX(IFNULL(Y.IF_DATA_SEND_YN, 'N'))    DATA_SEND_YN                                                       ");
		sql.append("           FROM OUT1001 Z                                                                                                 ");
		sql.append("              , OCS1003 Y                                                                                                 ");
		sql.append("          WHERE Y.HOSP_CODE = Z.HOSP_CODE                                                                                 ");
		sql.append("            AND Y.BUNHO = Z.BUNHO                                                                                         ");
		sql.append("            AND Y.FKOUT1001 = Z.PKOUT1001                                                                                 ");
		sql.append("            AND Z.NAEWON_YN = 'E'                                                                                         ");
		sql.append("            GROUP BY Z.HOSP_CODE, Z.PKOUT1001, Z.NAEWON_DATE, Y.IF_DATA_SEND_YN                                           ");
		sql.append("            ORDER BY ACTING_TIME) C                                                                                       ");
		sql.append("      , BAS0102 D                                                                                                         ");
		sql.append("  WHERE A.HOSP_CODE   =  :hospCode                                                                                        ");
		sql.append("       AND A.BUNHO       LIKE  :bunho                                                                                     ");
		sql.append("       AND A.NAEWON_DATE = STR_TO_DATE(:naewonDate,'%Y/%m/%d')                                                            ");
		sql.append("           AND A.GWA        LIKE  :gwa                                                                                    ");
		sql.append("           AND D.LANGUAGE = :language                                                                                     ");
		sql.append("    AND D.HOSP_CODE  = A.HOSP_CODE                                                                                        ");
		sql.append("    AND D.CODE_TYPE   = 'JUBSU_GUBUN'                                                                                     ");
		sql.append("    AND D.CODE        = A.JUBSU_GUBUN                                                                                     ");
		sql.append("    AND ((    IFNULL(D.GROUP_KEY, 'X')   = '1'                                                                            ");
		sql.append("          AND A.NAEWON_YN   = 'E')                                                                                        ");
		sql.append("        OR                                                                                                                ");
		sql.append("          (   IFNULL(D.GROUP_KEY, 'X')   != '1'                                                                           ");
		sql.append("          AND A.NAEWON_YN  IN ('Y','E')))                                                                                 ");
		sql.append("    AND B.HOSP_CODE  = A.HOSP_CODE                                                                                        ");
		sql.append("    AND B.BUNHO      = A.BUNHO                                                                                            ");
		sql.append("    AND C.HOSP_CODE  = A.HOSP_CODE                                                                                        ");
		sql.append("    AND C.PKOUT1001  = A.PKOUT1001                                                                                        ");
		sql.append("    AND C.NAEWON_DATE= A.NAEWON_DATE                                                                                      ");
		sql.append("   ORDER BY NAEWON_DATE, DATA_SEND_YN, ALL_END_YN DESC, ACTING_TIME, JUBSU_TIME                                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("gwa", gwa);
		query.setParameter("language", language);

		List<NuroOutOrderStatus> list = new JpaResultMapper().list(query,
				NuroOutOrderStatus.class);
		return list;
	}

	@Override
	public List<NuroPatientInfo> getNuroPatientListInfo(String language,
														String hospitalCode, String comingDate, String departmentCode,
														String doctorCode, String patientCode, String receptionType,
														String examStatus, String comingStatus, String currentSystemId, boolean ignoreLanguage) {
		LOG.info("[START] getNuroPatientListInfo comingDate=" + comingDate
				+ ", departmentCode =" + departmentCode + ", doctorCode="
				+ doctorCode + ", patientCode=" + patientCode
				+ ", receptionType=" + receptionType + ", examStatus="
				+ examStatus + ", comingStatus=" + comingStatus
				+ ", currentSystemId=" + currentSystemId);
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.GWA                                                                              departmentCode                    ");
		sql.append("          , FN_BAS_LOAD_GWA_NAME(A.GWA, DATE_FORMAT(A.NAEWON_DATE, '%Y-%m-%d'), :hospitalCode, :language) departmentName 	");
		sql.append("          , A.BUNHO                                                                       patientCode                       ");
		sql.append("          , B.SUNAME                                                                      patientName                       ");
		sql.append("          , B.SUNAME2                                                                     patientName2                      ");
		sql.append("          , A.NAEWON_DATE                                                                 comingDate                        ");
		sql.append("          , A.DOCTOR                                                                      doctorCode                        ");
		sql.append("          , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, DATE_FORMAT(A.NAEWON_DATE, '%Y-%m-%d'), :hospitalCode)     doctorName     	");
		sql.append("          , A.NAEWON_TYPE                                                                 comingType                        ");
		sql.append("          , A.JUBSU_NO                                                                    receptionCode                     ");
		sql.append("          , B.BIRTH                                                                       birth                             ");
		sql.append("          , CONCAT(FN_BAS_LOAD_AGE(A.NAEWON_DATE,B.BIRTH,''),' / ',B.SEX)                 ageSex                            ");
		sql.append("          , A.PKOUT1001                                                                   outResKey                         ");
		sql.append("          , A.JUBSU_TIME                                                                  receptionTime                     ");
		sql.append("          , IF(A.NAEWON_YN = 'E', 'Y', 'N')                                               orderEndYn                        ");
		sql.append("          , IF(A.NAEWON_YN = 'H', 'Y', 'N')                                               holdYn                            ");
		sql.append("          , ''                                                                            resultYn                          ");
		sql.append("          , RESER_YN                                                                      reserYn                           ");
		sql.append("          , FN_CHT_JAEWON_YN(A.HOSP_CODE, A.BUNHO)			                                              ipwonYn           ");
		sql.append("          , FN_OUT_LOAD_SUNAB_CHECK_YN(A.PKOUT1001, A.NAEWON_DATE, :hospitalCode)     sunabYn                          		");
		sql.append("          , IF(IFNULL(NAEWON_YN, 'N') ='N', 'N', 'Y')                                     comingStatus                      ");
		sql.append("          , A.JUBSU_GUBUN                                                                 receptionType                     ");
		sql.append("          , C.CODE_NAME                                                                   receptionTypeName                 ");
		sql.append("          , C.REMARK                                                                      remark                            ");
		sql.append("          , A.ARRIVE_TIME                                                                 arriveTime                        ");
		sql.append("          , A.GUBUN                                                                       TYPE                              ");
		sql.append("          , FN_OUT_LOAD_LAST_NAEWON_DATE_NEW(A.BUNHO, '%', :hospitalCode)                 lastComingDate                    ");
		sql.append("          , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO, :hospitalCode)                           ocsComment                        ");
		sql.append("          , A.CHOJAE                                                                      chojae                            ");
		sql.append("          , C.GROUP_KEY                                                                   groupKey                          ");
		sql.append("          , B.BUNHO_TYPE                                                                  patientType                       ");
		sql.append("          , IF(D.HOSP_CODE IS NULL, '', D.KAIGO_YN)										  careStatus                        ");
		sql.append("          , D.GAEIN                                                                       percentage                        ");
		sql.append("          , A.KENSA_YN                                                                    examStatus                        ");
		sql.append("	      , IFNULL( E.NUM_PROTOCOL ,'')                                		              trialYn       				    ");
		sql.append("	      , IFNULL( A.SYS_ID ,'')                                		              	  sysId       				    	");
		sql.append("	      , IFNULL( B.SYS_ID ,'')                                		              	  sysIdOut1001       				");
		sql.append("          FROM OUT0101 B , BAS0102 C, OUT1001 A                                                                             ");
		sql.append("          LEFT OUTER JOIN (SELECT X.HOSP_CODE, X.BUNHO, 'Y' KAIGO_YN, X.GAEIN                                               ");
		sql.append("                   FROM OUT0102 X                                                                                           ");
		sql.append("                  WHERE X.HOSP_CODE = :hospitalCode                                                                         ");
		sql.append("                        AND X.GUBUN = '70'                                                                                  ");
		sql.append("                        AND X.START_DATE = (SELECT MAX(Y.START_DATE)                                                        ");
		sql.append("                                                                  FROM OUT0102 Y                                            ");
		sql.append("                                                                 WHERE Y.HOSP_CODE = X.HOSP_CODE                            ");
		sql.append("                                                                   AND Y.GUBUN = X.GUBUN                                    ");
		sql.append("                                                                   AND :comingDate BETWEEN X.START_DATE AND X.END_DATE)) D  ");
		sql.append("        ON D.HOSP_CODE = A.HOSP_CODE                                                                                     	");
		sql.append("        AND D.BUNHO     = A.BUNHO                                                                                           ");
		sql.append("	    LEFT JOIN (SELECT	A.CLIS_PROTOCOL_ID	 AS	NUM_PROTOCOL	, A.HOSP_CODE HOSP_CODE, A.BUNHO BUNHO                  ");
		sql.append("	    FROM	CLIS_PROTOCOL_PATIENT A	 LEFT JOIN CLIS_PROTOCOL B ON A.CLIS_PROTOCOL_ID = B.CLIS_PROTOCOL_ID	            ");
		sql.append("	    WHERE	A.HOSP_CODE = :hospitalCode	                                                                                ");
		if (!StringUtils.isEmpty(patientCode)) {
			sql.append("	 AND	A.BUNHO = :patientCode	 																					");
		}
		sql.append("	    AND	A.ACTIVE_FLG = 1	                                                                                            ");
		sql.append("	    AND	B.ACTIVE_FLG = 1	                                                                                            ");
		sql.append("	    AND	B.STATUS_FLG = 2	                                                                                            ");
		sql.append("	    AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE ) E ON A.HOSP_CODE = E.HOSP_CODE AND A.BUNHO = E.BUNHO 			");
		sql.append("  WHERE A.HOSP_CODE   = :hospitalCode   																					");
		sql.append("	AND C.HOSP_CODE   = A.HOSP_CODE																							");
		sql.append("	AND B.HOSP_CODE   = A.HOSP_CODE                                                                                         ");
		sql.append("	AND A.BUNHO       = B.BUNHO                                                                                				");
		sql.append("        AND STR_TO_DATE(DATE_FORMAT(A.NAEWON_DATE,'%Y/%m/%d'),'%Y/%m/%d') = STR_TO_DATE(:comingDate,'%Y/%m/%d')             ");
		sql.append("        AND A.GWA         LIKE CONCAT (:departmentCode, '%')                                                       			");
		
		if(!ignoreLanguage){
			sql.append("    AND C.LANGUAGE = :language							                                                    			");
		}

		if (!StringUtils.isEmpty(doctorCode)) {
			doctorCode += "%";
			sql.append("        AND A.DOCTOR      LIKE :doctorCode                                                                              ");
		}

		if (!StringUtils.isEmpty(patientCode)) {
			patientCode += "%";
			sql.append("        AND A.BUNHO       LIKE :patientCode                                                                             ");
		}

		sql.append("        AND C.CODE_TYPE   = 'JUBSU_GUBUN'                                                                                   ");
		sql.append("        AND A.JUBSU_GUBUN = C.CODE                                                                                          ");
		if (!StringUtils.isEmpty(receptionType)) {
			sql.append("        AND A.JUBSU_GUBUN LIKE :receptionType                                                                           ");
		}

		if (!StringUtils.isEmpty(examStatus)) {
			sql.append("        AND ((:examStatus = 'ALL' AND 1 = 1 ) OR                                                                        ");
			sql.append("                 (:examStatus = 'Y' AND NAEWON_YN = 'E') OR                                                             ");
			sql.append("                 (:examStatus = 'N' AND NAEWON_YN != 'E'))                                                              ");
		}

		if (!StringUtils.isEmpty(comingStatus)) {
			sql.append("        AND ((:comingStatus = 'ALL' AND 1 = 1 ) OR                                                                      ");
			sql.append("                 (:comingStatus = 'Y' AND IFNULL(NAEWON_YN, 'N') != 'N') OR                                             ");
			sql.append("                 (:comingStatus = 'N' AND IFNULL(NAEWON_YN, 'N')  = 'N'))                                               ");
		}

		if (ModuleType.NURO.getValue().equals(currentSystemId)) {
			sql.append("		ORDER BY A.JUBSU_TIME, A.ARRIVE_TIME ,A.BUNHO, A.JUBSU_NO 														");
		} else if (ModuleType.OUTS.getValue().equals(currentSystemId)) {
			sql.append("		ORDER BY A.JUBSU_TIME DESC, A.ARRIVE_TIME DESC, A.BUNHO, A.JUBSU_NO 											");
		} else {
			sql.append("		ORDER BY A.JUBSU_TIME DESC, A.ARRIVE_TIME DESC, A.BUNHO, A.JUBSU_NO 											");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("comingDate", comingDate);
		query.setParameter("departmentCode", departmentCode);
		if (!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		if (!StringUtils.isEmpty(patientCode)) {
			query.setParameter("patientCode", patientCode);
		}
		if (!StringUtils.isEmpty(receptionType)) {
			query.setParameter("receptionType", receptionType);
		}
		if (!StringUtils.isEmpty(examStatus)) {
			query.setParameter("examStatus", examStatus);
		}
		if (!StringUtils.isEmpty(comingStatus)) {
			query.setParameter("comingStatus", comingStatus);
		}

		List<NuroPatientInfo> list = new JpaResultMapper().list(query,
				NuroPatientInfo.class);
		return list;
	}

	// TODO: FOR OUT1001P03: DONE SQL, not apply to proto. Waiting BA Confirm
	// with Dejaview
	public List<NuroPatientInfo> getBeforePatienInfo(String language,
													 String hospitalCode, String patientCode, String typeIO,
													 boolean isSelectYN) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'O'                                              IO_GUBUN                                                                                      ");
		sql.append("     , A.PKOUT1001                                      PK_KEY                                                                                        ");
		sql.append("     , A.BUNHO                                          BUNHO                                                                                         ");
		sql.append("     , B.SUNAME                                         SUNAME                                                                                        ");
		sql.append("     , A.NAEWON_DATE                                    NAEWON_DATE                                                                                   ");
		sql.append("     , A.GWA                                            GWA                                                                                           ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE,  :hospitalCode, :language )    GWA_NAME                                                            ");
		sql.append("     , A.DOCTOR                                         DOCTOR                                                                                        ");
		sql.append("     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :language) DOCTOR_NAME                                                                        ");
		sql.append("     , A.JUBSU_TIME                                     NAEWON_TIME                                                                                   ");
		if (isSelectYN) {
			sql.append("     , 'N'                                              SELECT_YN                                                                                 ");
		} else {
			sql.append("     , NULL                                              SELECT_YN                                                                                ");
		}
		sql.append("     , C.COMMENTS                                             COMMENTS                                                                                ");
		sql.append("     , IFNULL(B.BUNHO_TYPE,'0')                                  BUNHO_TYPE                                                                           ");
		sql.append("     , IFNULL(A.RESER_YN, 'N')                             RESER_YN                                                                                   ");
		sql.append("     , CONCAT (FN_BAS_LOAD_CODE_NAME('RESER_GUBUN',IFNULL(C.RESER_GUBUN,'O'), :hospitalCode, :language),                                              ");
		sql.append("         IF(C.UP_DOWN_GUBUN IS NOT NULL, CONCAT ('[', FN_BAS_LOAD_CODE_NAME('UP_DOWN_GUBUN', C.UP_DOWN_GUBUN, :hospitalCode, :language), ']'), '')    ");
		sql.append("         )RESER_GUBUN                                                                                                                                 ");
		sql.append("	 , IFNULL( A.SYS_ID ,'')																														  ");
		sql.append("	 , ''																														  					  ");
		sql.append(" FROM OUT1001 A                                                                                                                                       ");
		sql.append("    RIGHT OUTER JOIN OUT0123 C ON  C.HOSP_CODE = A.HOSP_CODE   AND C.FKOUT1001 = A.PKOUT1001 AND C.COMMENT_TYPE = '1'                                 ");
		sql.append("    JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE  AND B.BUNHO = A.BUNHO                                                                                ");
		sql.append(" WHERE :typeIO = 'O'                                                                                                                                  ");
		sql.append("   AND A.HOSP_CODE = :hospitalCode                                                                                                                    ");
		sql.append("   AND A.BUNHO = :patientCode                                                                                                                         ");
		sql.append("   AND A.NAEWON_DATE >= DATE_FORMAT(SYSDATE(), '%Y-%m-%d')                                                                                            ");
		sql.append(" UNION ALL                                                                                                                                            ");
		sql.append("SELECT 'I'                                              IO_GUBUN                                                                                      ");
		sql.append("     , A.PKINP1001                                      PK_KEY                                                                                        ");
		sql.append("     , A.BUNHO                                          BUNHO                                                                                         ");
		sql.append("     , B.SUNAME                                         SUNAME                                                                                        ");
		sql.append("     , A.IPWON_DATE                                     NAEWON_DATE                                                                                   ");
		sql.append("     , A.GWA                                            GWA                                                                                           ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME ( A.GWA, A.IPWON_DATE,  :hospitalCode, :language )    GWA_NAME                                                            ");
		sql.append("     , A.DOCTOR                                         DOCTOR                                                                                        ");
		sql.append("     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.IPWON_DATE, :language) DOCTOR_NAME                                                                         ");
		sql.append("     , A.IPWON_TIME                                     NAEWON_TIME                                                                                   ");
		if (isSelectYN) {
			sql.append("     , 'N'                                              SELECT_YN                                                                                 ");
		} else {
			sql.append("     , NULL                                              SELECT_YN                                                                                ");
		}
		sql.append("     , C.COMMENTS                                             COMMENTS                                                                                ");
		sql.append("     , IFNULL(B.BUNHO_TYPE,'0')                                  BUNHO_TYPE                                                                           ");
		sql.append("     , 'N'                                              RESER_YN                                                                                      ");
		sql.append("     , CONCAT (FN_BAS_LOAD_CODE_NAME('RESER_GUBUN',IFNULL(C.RESER_GUBUN,'O'), :hospitalCode, :language),                                              ");
		sql.append("         IF( C.UP_DOWN_GUBUN IS NOT NULL,CONCAT('[',FN_BAS_LOAD_CODE_NAME('UP_DOWN_GUBUN', C.UP_DOWN_GUBUN, :hospitalCode, :language),']'), '')       ");
		sql.append("         ) RESER_GUBUN                                                                                                                                ");
		sql.append("	 , ''																																			  ");
		sql.append("  FROM INP1001 A                                                                                                                                      ");
		sql.append("     JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE  AND B.BUNHO = A.BUNHO                                                                               ");
		sql.append("     RIGHT OUTER JOIN OUT0123 C ON C.HOSP_CODE = A.HOSP_CODE   AND C.FKINP1001 = A.PKINP1001  AND C.COMMENT_TYPE = '1'                                ");
		sql.append(" WHERE :typeIO = 'I'                                                                                                                                  ");
		sql.append("   AND A.HOSP_CODE = :hospitalCode                                                                                                                    ");
		sql.append("   AND A.BUNHO = :patientCode                                                                                                                         ");
		sql.append("   AND IFNULL(A.CANCEL_YN, 'N') = 'N'                                                                                                                 ");
		sql.append(" ORDER BY 5 DESC, 10 DESC, 6, 8                                                                                                                       ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("typeIO", typeIO);

		List<NuroPatientInfo> list = new JpaResultMapper().list(query,
				NuroPatientInfo.class);
		return list;
	}

	// TODO: FOR OUT1001P03: DONE SQL, not apply to proto. Waiting BA Confirm
	// with Dejaview
	public List<NuroPatientInfo> getPharmacyInfo(String hospitalCode,
												 String patientCode, String typeIO, String comingKey,
												 boolean isNeedOutPatientCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.PKOCS1003       PKOCSKEY                                                             ");
		sql.append("     , A.ORDER_GUBUN     ORDER_GUBUN                                                          ");
		sql.append("     , B.CODE_NAME       ORDER_GUBUN_NAME                                                     ");
		sql.append("     , A.HANGMOG_CODE    HANGMOG_CODE                                                         ");
		sql.append("     , C.HANGMOG_NAME    HANGMOG_NAME                                                         ");
		sql.append("     , A.SURYANG         SURYANG                                                              ");
		sql.append("     , D.CODE_NAME       ORD_DANUI                                                            ");
		sql.append("     , A.NALSU           NALSU                                                                ");
		sql.append("  FROM OCS1003 A                                                                              ");
		sql.append("       RIGHT OUTER JOIN OCS0132 D ON D.CODE_TYPE = 'ORD_DANUI' AND D.CODE = A.ORD_DANUI       ");
		sql.append("     , OCS0132 B                                                                              ");
		sql.append("     , OCS0103 C                                                                              ");
		sql.append(" WHERE :typeIO = 'O'                                                                          ");
		sql.append("   AND A.HOSP_CODE = :hospitalCode                                                            ");
		if (isNeedOutPatientCode) {
			sql.append("   AND A.BUNHO     = :patientCode                                                         ");
		}
		sql.append("   AND A.FKOUT1001 = :comingKey                                                               ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("   AND B.CODE_TYPE = 'ORDER_GUBUN_BAS'                                                        ");
		sql.append("   AND B.CODE      = SUBSTR(A.ORDER_GUBUN, 2, 1)                                              ");
		sql.append("   AND C.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("   AND C.HANGMOG_CODE = A.HANGMOG_CODE                                                        ");
		sql.append("   AND D.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append(" UNION ALL                                                                                    ");
		sql.append("SELECT A.PKOCS2003       PKOCSKEY                                                             ");
		sql.append("     , A.ORDER_GUBUN     ORDER_GUBUN                                                          ");
		sql.append("     , B.CODE_NAME       ORDER_GUBUN_NAME                                                     ");
		sql.append("     , A.HANGMOG_CODE    HANGMOG_CODE                                                         ");
		sql.append("     , C.HANGMOG_NAME    HANGMOG_NAME                                                         ");
		sql.append("     , A.SURYANG         SURYANG                                                              ");
		sql.append("     , D.CODE_NAME       ORD_DANUI                                                            ");
		sql.append("     , A.NALSU           NALSU                                                                ");
		sql.append("  FROM OCS2003 A                                                                              ");
		sql.append("      RIGHT OUTER JOIN OCS0132 D ON D.CODE = A.ORD_DANUI AND D.CODE_TYPE = 'ORD_DANUI'        ");
		sql.append("     , OCS0132 B                                                                              ");
		sql.append("     , OCS0103 C                                                                              ");
		sql.append(" WHERE :typeIO = 'I'                                                                          ");
		sql.append("   AND A.HOSP_CODE = :hospitalCode                                                            ");
		sql.append("   AND A.BUNHO     = :patientCode                                                             ");
		sql.append("   AND A.FKINP1001 = :comingKey                                                               ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("   AND B.CODE_TYPE = 'ORDER_GUBUN_BAS'                                                        ");
		sql.append("   AND B.CODE      = SUBSTR(A.ORDER_GUBUN, 2, 1)                                              ");
		sql.append("   AND C.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append("   AND C.HANGMOG_CODE = A.HANGMOG_CODE                                                        ");
		sql.append("   AND D.HOSP_CODE = A.HOSP_CODE                                                              ");
		sql.append(" ORDER BY 2, 1, 3                                                                             ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("comingKey", comingKey);
		query.setParameter("typeIO", typeIO);

		List<NuroPatientInfo> list = new JpaResultMapper().list(query, NuroPatientInfo.class);
		return list;
	}

	@Override
	public List<NuroOUT1101Q01GridInfo> getNuroOUT1101Q01GridInfo(
			String hospCode, String gwa, String doctor, String language,
			String naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT   A.BUNHO                                           BUNHO                                   ");
		sql.append("       , B.SUNAME                                          SUNAME                                  ");
		sql.append("       , B.SUNAME2                                         SUNAME2                                 ");
		sql.append("       ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', B.BIRTH, :hospCode, :language)                           ");
		sql.append("       ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.NAEWON_DATE, :hospCode, :language)                     ");
		sql.append("       ,A.NAEWON_DATE                                                                              ");
		sql.append("       ,A.SUJIN_NO                                                                                 ");
		sql.append("       ,A.JUBSU_NO                                                                                 ");
		sql.append("       ,A.GWA                                                                                      ");
		sql.append("       ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :hospCode, :language )      GWA_NAME            ");
		sql.append("       ,A.DOCTOR                                                                                   ");
		sql.append("       ,FN_BAS_LOAD_DOCTOR_NAME( A.DOCTOR, A.NAEWON_DATE, :hospCode) DOCTOR_NAME                   ");
		sql.append("       ,A.JUBSU_GUBUN                                                                              ");
		sql.append("       ,FN_BAS_LOAD_CODE_NAME('JUBSU_GUBUN', A.JUBSU_GUBUN, :hospCode, :language) GUBUN_NAME       ");
		sql.append("       ,A.JUBSU_TIME                                                                               ");
		sql.append("       ,C.YOYANG_NAME                                                                              ");
		sql.append("FROM OUT1001 A, OUT0101 B, BAS0001 C, BAS0102 D                                                    ");
		sql.append("WHERE A.HOSP_CODE   = :hospCode                                                                    ");
		sql.append("  AND A.NAEWON_DATE = STR_TO_DATE(:naewonDate , '%Y/%m/%d')                                        ");
		sql.append("  AND A.GWA        LIKE CONCAT('%',:gwa)                                                           ");
		sql.append("  AND A.DOCTOR     LIKE CONCAT('%',:doctor)                                                        ");
		sql.append("  AND A.RESER_YN   = 'Y'                                                                           ");
		sql.append("  AND B.HOSP_CODE  = A.HOSP_CODE                                                                   ");
		sql.append("  AND B.BUNHO      = A.BUNHO                                                                       ");
		sql.append("  AND C.HOSP_CODE  = A.HOSP_CODE                                                                   ");
		sql.append("  AND SYSDATE() BETWEEN C.START_DATE AND C.END_DATE                                                ");
		sql.append("   AND C.UPD_DATE = (SELECT MAX(UPD_DATE) FROM BAS0001 WHERE HOSP_CODE = :hospCode)	               ");
		sql.append("  AND D.HOSP_CODE  = A.HOSP_CODE                                                                   ");
		sql.append("  AND D.CODE_TYPE   = 'JUBSU_GUBUN'                                                                ");
		sql.append("  AND D.CODE        = A.JUBSU_GUBUN                                                                ");
		sql.append("  AND D.GROUP_KEY   IN ('1', '2')    					                                           ");
		sql.append(" AND D.LANGUAGE = :language                                                                        ");
		sql.append(" ORDER BY SUBSTR(A.DOCTOR,3), A.GWA, A.JUBSU_TIME                                                  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("gwa", gwa);
		query.setParameter("doctor", doctor);
		List<NuroOUT1101Q01GridInfo> list = new JpaResultMapper().list(query,
				NuroOUT1101Q01GridInfo.class);
		return list;
	}

	@Override
	public List<NuroPatientDetailInfo> getNuroPatientDetailListItemInfo(
			String language, String hospitalCode, String patientCode,
			String comingDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.GWA                GWA																			");
		sql.append("     , FN_BAS_LOAD_GWA_NAME(A.GWA,  A.NAEWON_DATE , :hospitalCode, :language)           GWA_NAME  	    ");
		sql.append("     , A.DOCTOR             DOCTOR    																    ");
		sql.append("     , F.DOCTOR_NAME        DOCTOR_NAME																	");
		sql.append("     , A.CHOJAE             CHOJAE																		");
		sql.append("     , A.JUBSU_NO           JUBSU_NO																	");
		sql.append("     , C.GUBUN              GUBUN																		");
		sql.append("     , FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.NAEWON_DATE, :hospitalCode) GUBUN_NAME	      				    ");
		sql.append("     , A.BUNHO              BUNHO																		");
		sql.append("     , A.NAEWON_DATE        NAEWON_DATE																	");
		sql.append("     , A.PKOUT1001          PKOUT1001																	");
		sql.append("     , A.JUBSU_TIME         JUBSU_TIME																	");
		sql.append("     , A.NAEWON_YN          NAEWON_YN																	");
		sql.append("     , A.NAEWON_TYPE        NAEWON_TYPE																	");
		sql.append("     , A.SUNNAB_YN          SUNNAB_YN																	");
		sql.append("     , A.FKINP1001          FKINP1001																	");
		sql.append("     , A.JUBSU_GUBUN        JUBSU_GUBUN																	");
		sql.append("     , A.INP_TRANS_YN       INP_TRANS_YN																");
		sql.append("     , A.BIGO               BIGO																		");
		sql.append("     , ''                   GONGBI_CODE1																");
		sql.append("     , ''                   GONGBI_CODE2																");
		sql.append("     , ''                   GONGBI_CODE3																");
		sql.append("     , ''                   GONGBI_CODE4																");
		sql.append("     , ''                   PRIORITY1																	");
		sql.append("     , ''                   PRIORITY2																	");
		sql.append("     , ''                   PRIORITY3																	");
		sql.append("     , ''                   PRIORITY4																	");
		sql.append("     , A.SUJIN_NO           SUJIN_NO																	");
		sql.append("     , IFNULL(A.WONYOI_ORDER_YN, 'Y')    WONYOI_ORDER_YN  												");
		sql.append("     , A.RESER_YN           RESER_YN																	");
		sql.append("     , '' BUTTON																						");
		sql.append("     , IF(IFNULL(A.NAEWON_YN, 'N')= 'N', 'N', 'Y') CHECK_NAEWON											");
		sql.append("     , A.ARRIVE_TIME        ARRIVE_TIME 																");
		sql.append("     , B.GROUP_KEY          GROUP_KEY																	");
		sql.append(" 	 , CONCAT('2',A.PKOUT1001 )  	CONT_KEY															");
		sql.append("     , IFNULL(A.SYS_ID, '')			SYS_ID																");
		sql.append("  FROM OUT0101 C , BAS0270 F    LEFT OUTER JOIN OUT1001 A 												");
		sql.append("       ON   F.HOSP_CODE  = A.HOSP_CODE    AND F.DOCTOR = A.DOCTOR										");
		sql.append("       RIGHT OUTER JOIN  BAS0102 B																		");
		sql.append("  ON B.HOSP_CODE   = A.HOSP_CODE AND B.CODE   = A.JUBSU_GUBUN											");
		sql.append(" WHERE A.HOSP_CODE    = :hospitalCode																	");
		sql.append(" AND B.CODE_TYPE = 'JUBSU_GUBUN'																		");
		sql.append(" AND A.NAEWON_DATE  = STR_TO_DATE(:comingDate, '%Y/%m/%d')												");
		sql.append("   AND A.BUNHO        = :patientCode 																	");
		sql.append("   AND A.GWA          NOT IN ( 'HC' )																	");
		sql.append("   AND STR_TO_DATE(:comingDate, '%Y/%m/%d') BETWEEN F.START_DATE AND F.END_DATE							");
		sql.append("   AND C.HOSP_CODE       = A.HOSP_CODE																	");
		sql.append("   AND C.BUNHO           = A.BUNHO																		");
		sql.append(" AND B.LANGUAGE = :language																				");
		sql.append(" ORDER BY JUBSU_NO																						");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("comingDate", comingDate);
		List<NuroPatientDetailInfo> list = new JpaResultMapper().list(query,
				NuroPatientDetailInfo.class);

		return list;
	}

	@Override
	public List<NuroPatientInsuranceInfo> getNuroPatientInsuranceListItemInfo(
			String language, String hospitalCode, String patientCode,
			String comingDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'N'																			");
		sql.append("     , A.GONGBI_CODE																");
		sql.append("     , B.GONGBI_NAME																");
		sql.append("     , A.LAST_CHECK_DATE															");
		sql.append("     , A.START_DATE																	");
		sql.append("     , A.BUNHO																		");
		sql.append("     , A.BUDAMJA_BUNHO																");
		sql.append("     , B.GONGBI_JIYEOK																");
		sql.append("  FROM BAS0212 B																	");
		sql.append("     , OUT0105 A																	");
		sql.append(" WHERE A.HOSP_CODE     = :hospitalCode												");
		sql.append("   AND A.BUNHO         = :patientCode												");
		sql.append("   AND DATE_FORMAT(:comingDate, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE     ");
		sql.append("   AND B.GONGBI_CODE   = A.GONGBI_CODE	AND B.LANGUAGE = :language					");
		sql.append("   AND DATE_FORMAT(:comingDate, '%Y/%m/%d') BETWEEN B.START_DATE AND B.END_DATE	    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("comingDate", comingDate);
		query.setParameter("language", language);
		List<NuroPatientInsuranceInfo> list = new JpaResultMapper().list(query,
				NuroPatientInsuranceInfo.class);

		return list;
	}

	@Override
	public List<NuroPatientCommentInfo> getNuroPatientCommentListItemInfo(
			String language, String hospitalCode, String patientCode) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.COMMENTS       COMMENTS						");
		sql.append("	    , A.SER            SER								");
		sql.append("	    , A.BUNHO          BUNHO							");
		sql.append("	    , CONCAT(A.BUNHO, LPAD(A.SER,10,'0')) CONT_KEY		");
		sql.append("	 FROM OUT0106 A											");
		sql.append("	WHERE A.HOSP_CODE     = :hospitalCode					");
		sql.append("	  AND A.BUNHO         = :patientCode				    ");
		sql.append("	ORDER BY CONT_KEY;										");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("patientCode", patientCode);

		List<NuroPatientCommentInfo> list = new JpaResultMapper().list(query,
				NuroPatientCommentInfo.class);
		return list;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<String> getNuroNUR2001U04ComingStatus(String hospitalCode,
													  String patientCode, String comingDate, String departmentCode,
													  String doctorCode, String comingType, Integer oldReceptionNo,
													  String examStatus) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OUT_CHECK_NAEWON_YN(:patientCode,STR_TO_DATE(:comingDate, '%Y/%m/%d'),:departmentCode ,:doctorCode,:comingType,:oldReceptionNo, :hospitalCode) ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("patientCode", patientCode);
		query.setParameter("comingDate", comingDate);
		query.setParameter("departmentCode", departmentCode);
		query.setParameter("doctorCode", doctorCode);
		query.setParameter("comingType", comingType);
		query.setParameter("oldReceptionNo", oldReceptionNo);
		// query.setParameter("examStatus", examStatus);
		query.setParameter("hospitalCode", hospitalCode);
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<String> getNuroNUR2001U04ExistingKeyStatus(String hospitalCode,
														   String pkout1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'Y'                              ");
		sql.append("FROM DUAL                               ");
		sql.append("WHERE EXISTS (                          ");
		sql.append("        SELECT 'X'                      ");
		sql.append("        FROM OUT1001                    ");
		sql.append("        WHERE HOSP_CODE = :hospitalCode ");
		sql.append("        AND PKOUT1001 = :pkout1001 );   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("pkout1001", pkout1001);
		List<String> list = query.getResultList();

		return list;
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<String> getNuroNUR2001U04ForeignKey(String hospitalCode,
													String comingDate, String patientCode, String departmentCode,
													String doctorCode, String comingType, String receptionNo) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT PKOUT1001                           ");
		sql.append("FROM OUT1001                               ");
		sql.append("WHERE HOSP_CODE   = :hospitalCode          ");
		if (!StringUtils.isEmpty(comingDate)) {
			sql.append("        AND NAEWON_DATE = :comingDate      ");
		}
		if (!StringUtils.isEmpty(patientCode)) {
			sql.append("        AND BUNHO       = :patientCode     ");
		}
		if (!StringUtils.isEmpty(departmentCode)) {
			sql.append("        AND GWA         = :departmentCode  ");
		}
		if (!StringUtils.isEmpty(doctorCode)) {
			sql.append("        AND DOCTOR      = :doctorCode      ");
		}
		if (!StringUtils.isEmpty(comingType)) {
			sql.append("        AND NAEWON_TYPE = :comingType      ");
		}
		if (!StringUtils.isEmpty(receptionNo)) {
			sql.append("        AND JUBSU_NO    = :receptionNo     ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(comingDate)) {
			query.setParameter("comingDate", comingDate);
		}
		if (!StringUtils.isEmpty(patientCode)) {
			query.setParameter("patientCode", patientCode);
		}
		if (!StringUtils.isEmpty(departmentCode)) {
			query.setParameter("departmentCode", departmentCode);
		}
		if (!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		if (!StringUtils.isEmpty(comingType)) {
			query.setParameter("comingType", comingType);
		}
		if (!StringUtils.isEmpty(receptionNo)) {
			query.setParameter("receptionNo", receptionNo);
		}
		List<String> list = query.getResultList();

		return list;
	}

	@Override
	public Integer updateComingStatus(String hospitalCode, String comingStatus,
									  String pkout1001) {
		LOG.info("updateComingStatus: hospitalCode=" + hospitalCode
				+ ", comingStatus=" + comingStatus + ", pkout1001=" + pkout1001);
		StringBuilder sql = new StringBuilder();
		sql.append("UPDATE OUT1001                         ");
		sql.append("        SET NAEWON_YN = :comingStatus ");
		sql.append("WHERE HOSP_CODE = :hospitalCode         ");
		sql.append("        AND PKOUT1001 = :pkout1001   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("comingStatus", comingStatus);
		query.setParameter("pkout1001", pkout1001);

		return query.executeUpdate();

	}

	@Override
	public Integer updatePatientInfo(String hospitalCode, String updId,
									 String comingStatus, String arriveTime, String receptionType,
									 String pkout1001) {
		LOG.info("updatePatientInfo: hospitalCode=" + hospitalCode + ", updId="
				+ updId + ", comingStatus=" + comingStatus + ", arriveTime="
				+ arriveTime + ", receptionType=" + receptionType
				+ ", pkout1001=" + pkout1001);
		StringBuilder sql = new StringBuilder();
		sql.append("UPDATE OUT1001                         ");
		sql.append("        SET UPD_ID      = :updId,      ");
		sql.append("        UPD_DATE    = SYSDATE(),       ");
		sql.append("        NAEWON_YN   = :comingStatus,   ");
		sql.append("        ARRIVE_TIME = :arriveTime,     ");
		sql.append("        JUBSU_GUBUN = :receptionType   ");
		sql.append("WHERE HOSP_CODE   = :hospitalCode      ");
		sql.append("AND PKOUT1001   = :pkout1001           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("updId", updId);
		query.setParameter("comingStatus", comingStatus);
		query.setParameter("arriveTime", arriveTime);
		query.setParameter("receptionType", receptionType);
		query.setParameter("pkout1001", pkout1001);

		return query.executeUpdate();
	}

	@Override
	public boolean deletePatientInfo(String hospitalCode, String pkout1001) {
		LOG.info("updatePatientInfo: hospitalCode=" + hospitalCode
				+ ", pkout1001=" + pkout1001);
		try {
			StringBuilder sql = new StringBuilder();
			sql.append("DELETE FROM OUT1001                 ");
			sql.append("WHERE HOSP_CODE = :hospitalCode     ");
			sql.append("        AND PKOUT1001 = :pkout1001  ");

			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("hospitalCode", hospitalCode);
			query.setParameter("pkout1001", pkout1001);
			query.executeUpdate();
			return true;
		} catch (Exception ex) {
			LOG.error(ex.getMessage(), ex);
			return false;
		}
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<String> getInspectionOrderReserMoveName(String hospitalCode, String language, 
														String patientCode, String reserDate, String departmentCode,
														String reserYn, String rowNum) {
		LOG.info("updatePatientInfo: hospitalCode=" + hospitalCode
				+ ", patientCode=" + patientCode + ", reserDate=" + reserDate
				+ ", departmentCode=" + departmentCode + ", reserYn=" + reserYn
				+ ", rowNum=" + rowNum);


		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_GWA_POSITION(A.GWA,SYSDATE(),:hospitalCode, :language) RESER_MOVE_NAME ");
		sql.append("              FROM OUT1001 A                                                   ");
		sql.append("             WHERE A.HOSP_CODE   = :hospitalCode                               ");
		sql.append("               AND A.BUNHO       = :patientCode                                ");
		sql.append("               AND A.NAEWON_DATE = :reserDate                                  ");
		sql.append("               AND A.GWA         = :departmentCode                             ");
		sql.append("               AND A.RESER_YN    = :reserYn                                    ");
		sql.append("LIMIT 0,:rowNum                                 							   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		query.setParameter("patientCode", patientCode);
		query.setParameter("reserDate", reserDate);
		query.setParameter("departmentCode", departmentCode);
		query.setParameter("reserYn", reserYn);
		query.setParameter("rowNum", Integer.parseInt(rowNum));
		List<String> list = query.getResultList();

		return list;
	}

	@Override
	public List<NuroPatientReceptionHistoryInfo> getNuroPatientReceptionHistoryInfo(
			String language, String hospitalCode, String patientCode) {
		StringBuilder sql = new StringBuilder();

		sql.append(" SELECT DISTINCT  A.NAEWON_DATE                                     NAEWON_DATE	            ");
		sql.append("      , A.NAEWON_DATE                                               JINRYO_PRE_DATE			");// check
		sql.append("      , A.JUBSU_TIME                                                JINRYO_PRE_TIME			");// check
		sql.append("      , A.GWA                                                       GWA						");// check
		sql.append("      , B.DOCTOR_NAME                                               DOCTOR					");// check
		sql.append("      , ''                                          				GUBUN					");// check
		sql.append("      , IFNULL(A.SUNNAB_YN,'N')                                     SUNNAB_YN	     		");// check
		sql.append("      , A.CHOJAE                                                    CHOJAE					");// check
		sql.append("      , CASE A.NAEWON_YN WHEN 'Y' THEN 'Y' WHEN 'E' THEN 'Y' ELSE 'N' END AS NAEWON_YN    	");// check
		sql.append("      , A.BUNHO                                                     BUNHO					");// check
		sql.append("      , ''                                                          JUBSU_TIME				");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :hospitalCode, :language)    GWA_NAME	");
		sql.append("      , A.SUJIN_NO                                                  SUJIN_NO				");
		sql.append("      , ''                                                          DOKU_YN					");// check
		sql.append("      , CONCAT(DATE_FORMAT(A.NAEWON_DATE, '%Y%m%d') , A.GWA , A.DOCTOR						");// check
		sql.append("      , A.NAEWON_TYPE ,  LPAD(A.JUBSU_NO,10,'0'))   CONT_KEY          						");
		sql.append("      , A.PKOUT1001 PKOUT1001         														");
		sql.append("	  , IFNULL(A.SYS_ID, '')										SYS_ID					");
		sql.append("   FROM    BAS0270 B																		");
		sql.append("      , OUT1001 A																			");
		sql.append("  WHERE A.HOSP_CODE      = :hospitalCode													");
		sql.append("   AND A.BUNHO          =  :patientCode														");
		sql.append("     AND B.HOSP_CODE      = A.HOSP_CODE														");
		sql.append("    AND B.DOCTOR         = A.DOCTOR															");
		sql.append("    AND A.NAEWON_DATE BETWEEN B.START_DATE AND B.END_DATE									");
		sql.append("    ORDER BY CONT_KEY DESC																	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("patientCode", patientCode);

		List<NuroPatientReceptionHistoryInfo> list = new JpaResultMapper()
				.list(query, NuroPatientReceptionHistoryInfo.class);
		return list;
	}
	
	@Override
	public List<NuroPatientReceptionHistoryInfo> getNuroPatientReceptionHistoryInfo2(
			String language, String hospitalCode, String patientCode) {
		StringBuilder sql = new StringBuilder();

		sql.append(" SELECT DISTINCT  A.NAEWON_DATE                                     NAEWON_DATE	            ");
		sql.append("      , A.NAEWON_DATE                                               JINRYO_PRE_DATE			");// check
		sql.append("      , A.JUBSU_TIME                                                JINRYO_PRE_TIME			");// check
		sql.append("      , A.GWA                                                       GWA						");// check
		sql.append("      , B.DOCTOR_NAME                                               DOCTOR					");// check
		sql.append("      , ''                                          				GUBUN					");// check
		sql.append("      , IFNULL(A.SUNNAB_YN,'N')                                     SUNNAB_YN	     		");// check
		sql.append("      , A.CHOJAE                                                    CHOJAE					");// check
		sql.append("      , CASE A.NAEWON_YN WHEN 'Y' THEN 'Y' WHEN 'E' THEN 'E' ELSE 'N' END AS NAEWON_YN    	");// check
		sql.append("      , A.BUNHO                                                     BUNHO					");// check
		sql.append("      , ''                                                          JUBSU_TIME				");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :hospitalCode, :language)    GWA_NAME	");
		sql.append("      , A.SUJIN_NO                                                  SUJIN_NO				");
		sql.append("      , ''                                                           DOKU_YN				");// check
		sql.append("      , CONCAT(DATE_FORMAT(A.NAEWON_DATE, '%Y%m%d') , A.GWA , A.DOCTOR ,					");// check
		sql.append("        A.NAEWON_TYPE ,  LPAD(A.JUBSU_NO,10,'0'))   CONT_KEY          						");
		sql.append("       ,A.PKOUT1001 PKOUT1001         														");
		sql.append("	  , IFNULL(A.SYS_ID, '')										SYS_ID					");
		sql.append("   FROM    BAS0270 B																			");
		sql.append("      , OUT1001 A																			");
		sql.append("  WHERE A.HOSP_CODE      = :hospitalCode													");
		sql.append("   AND A.BUNHO          =  :patientCode														");
		sql.append("     AND B.HOSP_CODE      = A.HOSP_CODE														");
		sql.append("    AND B.DOCTOR         = A.DOCTOR															");
		sql.append("    AND A.NAEWON_DATE BETWEEN B.START_DATE AND B.END_DATE									");
		sql.append("    ORDER BY CONT_KEY DESC																	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("patientCode", patientCode);

		List<NuroPatientReceptionHistoryInfo> list = new JpaResultMapper()
				.list(query, NuroPatientReceptionHistoryInfo.class);
		return list;
	}
	
	@Override
	@SuppressWarnings("unchecked")
	public String getNuroRES0102U00ChkHyujin(String hospCode, String doctor,
											 String startDate, String endDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT 'Y'                                                                     ");
		sql.append("       FROM OUT1001 A                                                                   ");
		sql.append("       WHERE     A.HOSP_CODE = :hospCode                                                ");
		sql.append("             AND A.RESER_YN = 'Y'                                                       ");
		sql.append("             AND A.NAEWON_DATE BETWEEN DATE_FORMAT(:startDate,'%Y/%m/%d')               ");
		sql.append("             AND DATE_FORMAT(:endDate,'%Y/%m/%d')                                       ");
		sql.append("             AND A.DOCTOR IN (SELECT B.DOCTOR                                           ");
		sql.append("                              FROM BAS0270 B                                            ");
		sql.append("                              WHERE     B.HOSP_CODE = A.HOSP_CODE                       ");
		sql.append("                                    AND IFNULL(B.TONGGYE_DOCTOR, B.DOCTOR) = :doctor    ");
		sql.append("                                    AND STR_TO_DATE( :startDate, '%Y/%m/%d')            ");
		sql.append("									BETWEEN B.START_DATE AND B.END_DATE)                ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("doctor", doctor);
		query.setParameter("hospCode", hospCode);
		query.setParameter("startDate", startDate);
		query.setParameter("endDate", endDate);

		List<String> result = query.getResultList();
		if (!result.isEmpty()) {
			return result.get(0);
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<String> getNuroRES1001U00TypeRequest(String hospitalCode, String sessionHospCode, String patientCode, String departmentCode, boolean isOtherClinic) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT Z.GUBUN                                                  ");
		sql.append("FROM (                                                          ");
		sql.append("        SELECT A.GUBUN                                          ");
		sql.append("        FROM OUT1001 A                                          ");
		if (isOtherClinic) {
			sql.append("WHERE A.HOSP_CODE         = :hospitalCode                   ");
			sql.append("        AND A.OUT_HOSP_CODE = :sessionHospCode              ");
		}else{
			sql.append("        WHERE A.HOSP_CODE           = :sessionHospCode      ");
		}
		if (!StringUtils.isEmpty(patientCode)) {
			sql.append("                AND A.BUNHO     = :patientCode              ");
		}
		if (!StringUtils.isEmpty(departmentCode)) {
			sql.append("                AND A.GWA       = :departmentCode           ");
		}
		sql.append("                AND A.NAEWON_DATE = (                           ");
		sql.append("                        SELECT MAX(B.NAEWON_DATE)               ");
		sql.append("                        FROM OUT1001 B                          ");
		sql.append("                        WHERE B.HOSP_CODE = A.HOSP_CODE         ");
		if(isOtherClinic){
			sql.append("                    AND B.OUT_HOSP_CODE  = :sessionHospCode ");
		}
		sql.append("                                AND B.BUNHO     = A.BUNHO       ");
		sql.append("                                AND B.GWA       = A.GWA ) )Z    ");
		sql.append("limit 0,1                                                       ");

		Query query = entityManager.createNativeQuery(sql.toString());
		if(isOtherClinic){
			query.setParameter("hospitalCode", hospitalCode);
		}
		query.setParameter("sessionHospCode", sessionHospCode);
		if (!StringUtils.isEmpty(patientCode)) {
			query.setParameter("patientCode", patientCode);
		}
		if (!StringUtils.isEmpty(departmentCode)) {
			query.setParameter("departmentCode", departmentCode);
		}

		List<String> list = query.getResultList();
		return list;
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<String> getDoctorName(String hospitalCode, String sessionHospCode, String patientCode, String departmentCode, String examPreDate, String examPreTime,
			boolean isOtherClinic) {

		StringBuilder sql = new StringBuilder();
		if (isOtherClinic) {
			sql.append("SELECT FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE,:hospitalCode) DOCTOR_NAME  ");
			sql.append("FROM OUT1001 A                                                                     ");
			sql.append("WHERE  A.HOSP_CODE         = :hospitalCode                                         ");
			sql.append("        AND A.OUT_HOSP_CODE  = :sessionHospCode                                    ");
		}else{
			sql.append("SELECT FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE,:sessionHospCode) DOCTOR_NAME ");
			sql.append("FROM OUT1001 A                                                                       ");
			sql.append("        WHERE A.HOSP_CODE           = :sessionHospCode                               ");
		}
		sql.append("        AND A.RESER_YN    = 'Y'                                      ");
		if (!StringUtils.isEmpty(patientCode)) {
			sql.append("        AND A.BUNHO       = :patientCode                         ");
		}
		if (!StringUtils.isEmpty(departmentCode)) {
			sql.append("        AND A.GWA         = :departmentCode                      ");
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			sql.append("        AND A.NAEWON_DATE = :examPreDate                         ");
		}
		if (!StringUtils.isEmpty(examPreTime)) {
			sql.append("        AND A.JUBSU_TIME  = :examPreTime                         ");
		}
		sql.append("limit 0,1                                                            ");

		Query query = entityManager.createNativeQuery(sql.toString());
		if(isOtherClinic){
			query.setParameter("hospitalCode", hospitalCode);
		}
		query.setParameter("sessionHospCode", sessionHospCode);
		if (!StringUtils.isEmpty(patientCode)) {
			query.setParameter("patientCode", patientCode);
		}
		if (!StringUtils.isEmpty(departmentCode)) {
			query.setParameter("departmentCode", departmentCode);
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			query.setParameter("examPreDate",
					DateUtil.toDate(examPreDate, DateUtil.PATTERN_YYMMDD));
		}
		if (!StringUtils.isEmpty(examPreTime)) {
			query.setParameter("examPreTime", examPreTime);
		}

		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public String callNuroProcOcsoDoctorChange2(String hospitalCode,
												String pkout1001, String doctorCode, String clinicCode) {
		LOG.info("[START] callNuroProcOcsoDoctorChange2 hospitalCode="
				+ hospitalCode + ", pkout1001=" + pkout1001 + ", doctorCode="
				+ doctorCode + ", clinicCode=" + clinicCode);
		String ioFlg = "";
		/*
		 * sql.append(
		 * "SET @test = '';                                                                           "
		 * ); sql.append(
		 * "CALL PR_OCSO_DOCTOR_CHANGE2(:pkout1001, :doctorCode, :clinicCode, :hospitalCode, @test);  "
		 * ); sql.append(
		 * "SELECT @test as IO_FLAG;                                                                  "
		 * );
		 */

		StoredProcedureQuery query = entityManager
				.createStoredProcedureQuery("PR_OCSO_DOCTOR_CHANGE2");
		query.registerStoredProcedureParameter("I_PKOUT1001", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_DOCTOR", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_CLINIC_CODE",
				String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,
				ParameterMode.IN);
		;
		query.registerStoredProcedureParameter("IO_FLAG", String.class,
				ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospitalCode);
		query.setParameter("I_PKOUT1001", pkout1001);
		query.setParameter("I_TO_DOCTOR", doctorCode);
		query.setParameter("I_TO_CLINIC_CODE", clinicCode);
		query.setParameter("IO_FLAG", "");

		ioFlg = (String) query.getOutputParameterValue("IO_FLAG");
		return ioFlg;
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<Double> getNuroRES1001U00ReceptionNumber(String hospitalCode, String sessionHospCode, String patientCode, String examPreDate, boolean isOtherClinic) {


		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(MAX(A.JUBSU_NO), 0) + 1 JUBSU_NO                           ");
		sql.append("FROM OUT1001 A                                                          ");
		if (isOtherClinic) {
			sql.append("WHERE  A.HOSP_CODE        = :hospitalCode                           ");
			sql.append("        AND A.OUT_HOSP_CODE      = :sessionHospCode                 ");
		}else{
			sql.append("        WHERE A.HOSP_CODE           = :sessionHospCode              ");
		}
		if (!StringUtils.isEmpty(patientCode)) {
			sql.append("        AND A.BUNHO       = :patientCode                             ");
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			sql.append("        AND A.NAEWON_DATE = :examPreDate                             ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		if(isOtherClinic){
			query.setParameter("hospitalCode", hospitalCode);
		}
		query.setParameter("sessionHospCode", sessionHospCode);
		if (!StringUtils.isEmpty(patientCode)) {
			query.setParameter("patientCode", patientCode);
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			query.setParameter("examPreDate",
					DateUtil.toDate(examPreDate, DateUtil.PATTERN_YYMMDD));
		}
		List<Double> list = query.getResultList();
		return list;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getNuroOUT1001U01LayLastCheckDate(String hospCode,
													String gubun, String bunho, String date) {
		StringBuilder sql = new StringBuilder();

		sql.append("SELECT DATE_FORMAT(A.LAST_CHECK_DATE, '%Y/%m/%d')			     ");
		sql.append("  FROM OUT0102 A                                                 ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                   ");
		sql.append("   AND A.GUBUN     = :gubun                                      ");
		sql.append("   AND A.BUNHO     = :bunho                                      ");
		sql.append("   AND STR_TO_DATE(:date,'%Y/%m/%d')     BETWEEN A.START_DATE    ");
		sql.append("                       AND A.END_DATE;                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("gubun", gubun);
		query.setParameter("bunho", bunho);
		query.setParameter("date", date);

		List<String> listResult = query.getResultList();
		if (listResult != null && !listResult.isEmpty()) {
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<NuroOUT1001U01LayoutBarCodeInfo> getNuroOUT1001U01LayoutBarCodeInfo(
			String hospCode, String language, String bunho) {
		StringBuilder sql = new StringBuilder();

		sql.append(" SELECT BUNHO,																	");
		sql.append("        SUNAME,                                                                 ");
		sql.append("        SEX,                                                                    ");
		sql.append("        FN_BAS_TO_JAPAN_DATE_CONVERT ('1', BIRTH,:hospCode, :language )         ");
		sql.append("        ,CONCAT( '*' , BUNHO , '*')                                             ");
		sql.append("   FROM OUT0101                                                                 ");
		sql.append("  WHERE HOSP_CODE = :hospCode AND BUNHO = :bunho                                ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);

		List<NuroOUT1001U01LayoutBarCodeInfo> list = new JpaResultMapper()
				.list(query, NuroOUT1001U01LayoutBarCodeInfo.class);
		return list;
	}

	@Override
	public List<NuroOUT1001U01LoadOUT0105Info> getNuroOUT1001U01LoadOUT0105Info(
			String hospCode, String gongbiCode, String fkout1001) {
		StringBuilder sql = new StringBuilder();

		sql.append("SELECT GONGBI_CODE								");
		sql.append("     , PRIORITY                                 ");
		sql.append("  FROM OUT1002                                  ");
		sql.append(" WHERE HOSP_CODE   = :hospCode                  ");
		sql.append("   AND GONGBI_CODE = TRIM(:gongbiCode)          ");
		sql.append("   AND FKOUT1001   = TRIM(:fkout1001)           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("gongbiCode", gongbiCode);
		query.setParameter("fkout1001", fkout1001);

		List<NuroOUT1001U01LoadOUT0105Info> list = new JpaResultMapper().list(
				query, NuroOUT1001U01LoadOUT0105Info.class);
		return list;

	}

	@Override
	@SuppressWarnings("unchecked")
	public String getNuroOUT1001U01GetDbMaxJubsuNo(String hospCode,
												   String bunho, String naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CAST(MAX( A.JUBSU_NO)  AS CHAR)                               ");
		sql.append("         FROM OUT1001 A                                              ");
		sql.append("        WHERE A.HOSP_CODE     = :hospCode                            ");
		sql.append("          AND A.BUNHO         = :bunho                               ");
		sql.append("          AND DATE_FORMAT(A.NAEWON_DATE,'%Y/%m/%d') = :naewonDate 	 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("naewonDate", naewonDate);

		List<String> listResult = query.getResultList();
		if (!StringUtils.isEmpty(listResult)) {
			return listResult.get(0);
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getNuroOUT1001U01CheckDoctor(String type, String date,
											   String time, String doctor, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OUT_CHECK_DOCTOR_JINRYO(:type, STR_TO_DATE(:date,'%Y/%m/%d'), :time,:doctor, :hospCode)");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("type", type);
		query.setParameter("date", date);
		query.setParameter("time", time);
		query.setParameter("doctor", doctor);
		query.setParameter("hospCode", hospCode);

		List<String> listResult = query.getResultList();
		if (listResult != null && !listResult.isEmpty()) {
			return listResult.get(0);
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getNuroOUT1001U01CheckNaewonYn(String bunho,
												 String naewonDate, String gwa, String doctor, String naewonType,
												 String oldJubsuno, String hospCode) {
		StringBuilder sql = new StringBuilder();

		if (StringUtils.isEmpty(bunho) || StringUtils.isEmpty(bunho)
				|| StringUtils.isEmpty(gwa) || StringUtils.isEmpty(doctor)
				|| StringUtils.isEmpty(naewonType)
				|| StringUtils.isEmpty(oldJubsuno)) {
			return null;
		} else {
			sql.append("SELECT FN_OUT_CHECK_NAEWON_YN (:bunho,          ");
			sql.append("                               :naewonDate,    ");
			sql.append("                               :gwa,            ");
			sql.append("                               :doctor,         ");
			sql.append("                               :naewonType,    ");
			sql.append("                               :oldJubsuno,   ");
			sql.append("                               :hospCode)      ");

			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("bunho", bunho);
			query.setParameter("naewonDate", naewonDate);
			query.setParameter("gwa", gwa);
			query.setParameter("doctor", doctor);
			query.setParameter("naewonType", naewonType);
			query.setParameter("oldJubsuno", oldJubsuno);
			query.setParameter("hospCode", hospCode);

			List<Object> listResult = query.getResultList();
			if (listResult != null && !listResult.isEmpty()) {
				return listResult.get(0).toString();
			}
			return null;
		}
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getNuroOUT1001U01CheckY(String hospCode, Double pkout1001) {
		StringBuilder sql = new StringBuilder();

		sql.append("SELECT 'Y'																");
		sql.append("  FROM OUT1001 A                                                        ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode AND A.PKOUT1001 = :pkout1001             ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkout1001", pkout1001);

		List<Object> listResult = query.getResultList();
		if (listResult != null && !listResult.isEmpty()) {
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getNuroOUT1001U01GetOut1001Seq(String seqName) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT SWF_NextVal(:seqName)  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("seqName", seqName);

		List<Object> result = query.getResultList();
		if (!result.isEmpty()) {
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getNuroOUT1001U01GetGubunName(String gubun,
												String naewonDate, String bunho, String hospCode) {
		StringBuilder sql = new StringBuilder("SELECT FN_OUT_LOAD_GUBUN_NAME_NEW(:gubun, DATE_FORMAT(:naewonDate, '%Y/%m/%d'), :bunho, :hospCode) ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("gubun", gubun);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("bunho", bunho);
		query.setParameter("hospCode", hospCode);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<NuroRES1001U00ReserListItemInfo> getNuroRES1001U00ReserListItemInfo(
			String hospitalCode, String sessionHospCode, String language, String patientCode, boolean isOtherClinic) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.NAEWON_DATE   ,                                                                                                    ");
		sql.append("        IF( LENGTH( A.JUBSU_TIME ) = 4,CONCAT(SUBSTR(A.JUBSU_TIME, 1, 2),':',SUBSTR(A.JUBSU_TIME, 3)),'') JINRYO_PRE_TIME,  ");
		if(isOtherClinic){
			sql.append("        FN_BAS_LOAD_GWA_NAME (A.GWA   , A.NAEWON_DATE, :hospitalCode, :language) GWA_NAME       ,                       ");
			sql.append("        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :hospitalCode) DOCTOR_NAME                                     ");
		}else{
			sql.append("        FN_BAS_LOAD_GWA_NAME (A.GWA   , A.NAEWON_DATE, :sessionHospCode, :language) GWA_NAME       ,                    ");
			sql.append("        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :sessionHospCode) DOCTOR_NAME                                  ");
		}
		sql.append("FROM OUT1001 A                                                                                                              ");
		if (isOtherClinic) {
			sql.append("        WHERE A.HOSP_CODE        = :hospitalCode                                                                        ");
			sql.append("        AND A.OUT_HOSP_CODE        = :sessionHospCode                                                                   ");
		}else{
			sql.append("        WHERE A.HOSP_CODE        = :sessionHospCode                                                                     ");
		}
		sql.append("        AND A.RESER_YN         = 'Y'                                                                                        ");
		if (!StringUtils.isEmpty(patientCode)) {
			sql.append("        AND A.BUNHO            = :patientCode                                                                           ");
		}
		sql.append("        AND A.NAEWON_DATE     >= DATE_FORMAT(SYSDATE(), '%Y/%m/%d')                                                         ");
		sql.append("ORDER BY A.NAEWON_DATE, A.JUBSU_TIME                                                                                        ");
		Query query = entityManager.createNativeQuery(sql.toString());
		if(isOtherClinic){
			query.setParameter("hospitalCode", hospitalCode);
		}
		query.setParameter("sessionHospCode", sessionHospCode);
		query.setParameter("language", language);
		if (!StringUtils.isEmpty(patientCode)) {
			query.setParameter("patientCode", patientCode);
		}

		List<NuroRES1001U00ReserListItemInfo> list = new JpaResultMapper().list(query, NuroRES1001U00ReserListItemInfo.class);
		return list;
	}
	//	FN_BAS_LOAD_GUBUN_NAME
	@Override
	public List<NuroRES1001U00ReseredDataListItemInfo> getNuroRES1001U00ReseredDataListItemInfo(
			String hospitalCode, String sessionHospCode, String departmentCode, String doctorCode,
			String examPreDate, String fromTime, String toTime,
			String reserToTime, boolean isOtherClinic) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.JUBSU_TIME                                     JUBSU_TIME,                                                   ");
		sql.append("        A.BUNHO                                          BUNHO,                                                       ");
		sql.append("        B.SUNAME                                         SUNAME,                                                      ");
		sql.append("        B.SUNAME2                                        SUNAME2,                                                     ");
		sql.append("        A.CHOJAE                                         CHOJAE,                                                      ");
		sql.append("        DATE_FORMAT(A.UPD_DATE, '%Y/%m/%d')              UPD_DATE,                                                    ");
		sql.append("        A.PKOUT1001                                      PKOUT1001,                                                   ");
		sql.append("        A.NAEWON_DATE                                    NAEWON_DATE,                                                 ");
		sql.append("        A.GWA                                            GWA,                                                         ");
		sql.append("        A.JUBSU_NO                                       JUBSU_NO,                                                    ");
		sql.append("        A.GUBUN                                          GUBUN,                                                       ");
		sql.append("        A.DOCTOR                                         DOCTOR,                                                      ");
		sql.append("        A.RES_GUBUN                                      RES_GUBUN,                                                   ");
		if(isOtherClinic){
			//sql.append("        FN_ADM_LOAD_USER_NAME(A.RES_CHANGGU, :hospitalCode) RES_USER_NAME,                                      ");
			sql.append("        FN_ADM_LOAD_USER_NAME(A.RES_CHANGGU, IFNULL(A.OUT_HOSP_CODE, A.HOSP_CODE)) RES_USER_NAME,                 ");
		}else{
			//sql.append("        FN_ADM_LOAD_USER_NAME(A.RES_CHANGGU, :sessionHospCode) RES_USER_NAME,                                     ");
			sql.append("        FN_ADM_LOAD_USER_NAME(A.RES_CHANGGU, IFNULL(A.OUT_HOSP_CODE, A.HOSP_CODE)) RES_USER_NAME,                 ");
		}
		sql.append("        A.RES_INPUT_GUBUN        ,                                                                                    ");
		sql.append("        IFNULL(A.NAEWON_YN, 'N')                         NAEWON_YN,                                                   ");
		sql.append("        'N'                                              NEWROW,                                                      ");
		if(isOtherClinic){
			sql.append("        FN_RES_LOAD_JINRYO_TIME_YN( A.DOCTOR, A.NAEWON_DATE, A.JUBSU_TIME, :hospitalCode) JINRYO_YN,              ");	
		}else{
			sql.append("        FN_RES_LOAD_JINRYO_TIME_YN( A.DOCTOR, A.NAEWON_DATE, A.JUBSU_TIME, :sessionHospCode) JINRYO_YN,           ");
		}
		sql.append("        IF(A.NAEWON_TYPE = '1', 'Y', 'N')             	 JINRYO_IRAI_YN,                                              ");
		sql.append("        A.RES_CHANGGU                                    RES_USER,                                                    ");
		sql.append("        FN_CHT_JAEWON_YN(A.HOSP_CODE, A.BUNHO)                       		 IPWON_YN,                                ");
		sql.append("        C.COMMENTS                                       RESER_COMMENTS,                                              ");
		sql.append("        C.RESER_GUBUN                                    RESER_GUBUN  ,                                               ");
		sql.append("        D.YOYANG_NAME                                    YOYANG_NAME                                                  ");
		sql.append(" FROM                                                                                                                 ");
		sql.append("      OUT1001 A                                                                                                       ");
		sql.append("      INNER JOIN OUT0101 B ON  B.HOSP_CODE = A.HOSP_CODE  AND B.BUNHO = A.BUNHO                                       ");
		sql.append("      LEFT JOIN OUT0123 C  ON C.BUNHO = A.BUNHO AND  C.FKOUT1001 = A.PKOUT1001 AND C.HOSP_CODE = A.HOSP_CODE          ");
		sql.append("        AND C.SEQ = '1' AND C.COMMENT_TYPE = '1'                                                                      ");
		sql.append("  INNER JOIN BAS0001 D ON A.OUT_HOSP_CODE = D.HOSP_CODE                                                               ");
		if(isOtherClinic){
			sql.append("WHERE A.HOSP_CODE      = :hospitalCode                                                                             ");
			sql.append("        AND A.OUT_HOSP_CODE        = :sessionHospCode                                                             ");
		}else{
			sql.append("WHERE A.HOSP_CODE        = :sessionHospCode                                                                       ");
		}
		sql.append("        AND A.RESER_YN         = 'Y'                                                                                  ");
		sql.append(" AND D.START_DATE = (SELECT MAX(START_DATE) FROM BAS0001 C WHERE A.OUT_HOSP_CODE = C.HOSP_CODE )                      ");
		if (!StringUtils.isEmpty(departmentCode)) {
			sql.append("        AND A.GWA              = :departmentCode                                                                  ");
		}
		if (!StringUtils.isEmpty(doctorCode)) {
			sql.append("       AND A.DOCTOR           = :doctorCode                                                                       ");
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			sql.append("       AND A.NAEWON_DATE      = STR_TO_DATE(:examPreDate, '%Y/%m/%d')                                             ");
		}
		if (!StringUtils.isEmpty(fromTime)) {
			sql.append("       AND A.JUBSU_TIME >= IF(:fromTime = '0000',:reserToTime,:fromTime)                                          ");
		}
		if (!StringUtils.isEmpty(toTime)) {
			sql.append("       AND A.JUBSU_TIME <= IF(:toTime = '0000',:reserToTime  ,:toTime)                                            ");
		}
		sql.append("ORDER BY 1, 15                                                                                                        ");
		Query query = entityManager.createNativeQuery(sql.toString());
		if(isOtherClinic){
			query.setParameter("hospitalCode", hospitalCode);
		}
		query.setParameter("sessionHospCode", sessionHospCode);
		if (!StringUtils.isEmpty(departmentCode)) {
			query.setParameter("departmentCode", departmentCode);
		}
		if (!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			query.setParameter("examPreDate", examPreDate);
		}
		if (!StringUtils.isEmpty(fromTime)) {
			query.setParameter("fromTime", fromTime);
		}
		if (!StringUtils.isEmpty(toTime)) {
			query.setParameter("toTime", toTime);
		}
		if (!StringUtils.isEmpty(reserToTime)
				&& (!StringUtils.isEmpty(fromTime) || !StringUtils.isEmpty(toTime))) {
			query.setParameter("reserToTime", reserToTime);
		}

		List<NuroRES1001U00ReseredDataListItemInfo> list = new JpaResultMapper().list(query, NuroRES1001U00ReseredDataListItemInfo.class);
		return list;
	}

	@Override
	public List<NuroRES1001U00DoctorReserListItemInfo> getNuroRES1001U00DoctorReserListItemInfo(
			String hospitalCode, String sessionHospCode, String language, String patientCode, boolean isOtherClinic, boolean isAllClinic) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.NAEWON_DATE   ,                                                                                                     ");
		sql.append("        IF(LENGTH( A.JUBSU_TIME ) = 4, CONCAT(SUBSTR(A.JUBSU_TIME, 1, 2),':',SUBSTR(A.JUBSU_TIME, 3)), '') JINRYO_PRE_TIME,  ");
		if(isOtherClinic){
			sql.append("        FN_BAS_LOAD_GWA_NAME   (A.GWA , A.NAEWON_DATE, :hospitalCode, :language) GWA_NAME,                               ");
			sql.append("        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :hospitalCode) DOCTOR_NAME,                                     ");
		}else{
			sql.append("        FN_BAS_LOAD_GWA_NAME   (A.GWA , A.NAEWON_DATE, :sessionHospCode, :language) GWA_NAME,                            ");
			sql.append("        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :sessionHospCode) DOCTOR_NAME,                                  ");
		}
		sql.append("        A.PKOUT1001                PKOUT1001,                                                                                ");
		sql.append("        IFNULL(A.NAEWON_YN, 'N')      NAEWON_YN,                                                                             ");
		sql.append("        A.BUNHO                    BUNHO,                                                                                    ");
		sql.append("        A.GWA                      GWA,                                                                                      ");
		sql.append("        A.DOCTOR                   DOCTOR,                                                                                   ");
		sql.append("        IF(A.NAEWON_TYPE = '1', 'Y', 'N') JINRYO_IRAI_YN,                                                                    ");
		sql.append("        A.SYS_DATE                 IRAI_DATE,                                                                                ");
		sql.append("        A.RES_CHANGGU              RES_USER,                                                                                 ");
		sql.append("        B.COMMENTS                 RESER_COMMENT,                                                                            ");
		sql.append("        B.RESER_GUBUN              RESER_GUBUN  ,                                                                            ");
		sql.append("        D.YOYANG_NAME                                    CLINIC_NAME                                                         ");
		sql.append("FROM OUT1001 A LEFT JOIN OUT0123 B                                                                                           ");
		sql.append("     ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO AND B.FKOUT1001 = A.PKOUT1001                                        ");
		sql.append("     AND B.COMMENT_TYPE = '1' AND B.SEQ = '1'                                                                                ");
		sql.append("  INNER JOIN BAS0001 D ON A.OUT_HOSP_CODE = D.HOSP_CODE                                                                      ");
		sql.append(" AND D.START_DATE = (SELECT MAX(START_DATE) FROM BAS0001 C WHERE A.OUT_HOSP_CODE = C.HOSP_CODE )                             ");
		if (isOtherClinic) {
			sql.append("WHERE A.HOSP_CODE      =  :hospitalCode                                                                                  ");
			sql.append("       AND A.OUT_HOSP_CODE        = :sessionHospCode                                                                     ");
		}else{
			sql.append("      WHERE   A.HOSP_CODE           = :sessionHospCode                                                                   ");
		}
		sql.append("        AND A.RESER_YN = 'Y'                                                                                                 ");
		sql.append("        AND A.BUNHO            = :patientCode                                                                                ");
		sql.append("        AND A.NAEWON_DATE >= DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                               ");
		
		sql.append("ORDER BY A.NAEWON_DATE, A.JUBSU_TIME                                                                                         ");
		Query query = entityManager.createNativeQuery(sql.toString());
		if(isOtherClinic){
			query.setParameter("hospitalCode", hospitalCode);
		}
		query.setParameter("sessionHospCode", sessionHospCode);
		query.setParameter("language", language);
		query.setParameter("patientCode", patientCode);

		List<NuroRES1001U00DoctorReserListItemInfo> list = new JpaResultMapper().list(query, NuroRES1001U00DoctorReserListItemInfo.class);
		return list;
	}

	@Override
	public List<OcsoOCS1003P01GridPatientListInfo> getOcsoOCS1003P01GridPatientListInfo(
			String hospCode, String language, String naewonDate,
			String naewonYn, String reserYn, String doctorModeYn,
			String doctor, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO,                                                                                                                                                   ");
		sql.append("          A.NAEWON_DATE,                                                                                                                                           ");
		sql.append("          A.GWA,                                                                                                                                                   ");
		sql.append("          A.DOCTOR,                                                                                                                                                ");
		sql.append("          A.NAEWON_TYPE,                                                                                                                                           ");
		sql.append("          IFNULL(A.RESER_YN, 'N') RESER_YN,                                                                                                                        ");
		sql.append("          A.JUBSU_TIME JUBSU_TIME,                                                                                                                                 ");
		sql.append("          A.ARRIVE_TIME ARRIVE_TIME,                                                                                                                               ");
		sql.append("          CONCAT( IF(A.NAEWON_YN = 'H', CONCAT('[', FN_BAS_LOAD_CODE_NAME ('NAEWON_YN', A.NAEWON_YN, :hospCode, :language), '] '),'') , B.SUNAME) SUNAME,     ");
		sql.append("          B.SUNAME2,                                                                                                                                               ");
		sql.append("          FN_BAS_LOAD_CODE_NAME ('SEX', B.SEX, :hospCode, :language) SEX,                                                                                     ");
		sql.append("          FN_BAS_LOAD_AGE (A.NAEWON_DATE, B.BIRTH, 'XXXX') AGE,                                                                                                    ");
		sql.append("          FN_BAS_LOAD_GUBUN_NAME (A.GUBUN, A.NAEWON_DATE, :hospCode) GUBUN_NAME,                                                                                ");
		sql.append("          FN_BAS_LOAD_GWA_NAME (A.GWA, A.NAEWON_DATE, :hospCode, :language) GWA_NAME,                                                                         ");
		sql.append("          FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, A.NAEWON_DATE, :hospCode) DOCTOR_NAME,                                                                             ");
		sql.append("          FN_BAS_LOAD_CODE_NAME ('CHOJAE', A.CHOJAE, :hospCode, :language) CHOJAE_NAME,                                                                       ");
		sql.append("          CASE WHEN (A.NAEWON_YN = 'E') THEN 'Y' ELSE 'N' END JINRYO_END_YN,                                                                                       ");
		sql.append("          A.PKOUT1001 PK_NAEWON,                                                                                                                                   ");
		sql.append("          A.NAEWON_YN NAEWON_YN,                                                                                                                                   ");
		sql.append("          A.SUNNAB_YN SUNNAB_YN,                                                                                                                                   ");
		sql.append("          A.JUBSU_GUBUN JUBSU_GUBUN,                                                                                                                               ");
		sql.append("          CASE                                                                                                                                                     ");
		sql.append("             WHEN (FN_OCS_LOAD_TA_GWA_JINRYO_CNT (A.BUNHO, A.NAEWON_DATE, A.GWA, :hospCode) >                                                                   ");
		sql.append("                      0)                                                                                                                                           ");
		sql.append("             THEN                                                                                                                                                  ");
		sql.append("                'Y'                                                                                                                                                ");
		sql.append("             ELSE                                                                                                                                                  ");
		sql.append("                'N'                                                                                                                                                ");
		sql.append("          END                                                                                                                                                      ");
		sql.append("             OTHER_GWA,                                                                                                                                            ");
		sql.append("          CASE WHEN (C.PKOCS0503 IS NULL) THEN 'N' ELSE 'Y' END CONSULT_YN,                                                                                        ");
		sql.append("          IFNULL(D.COMMON_DOCTOR_YN, 'N') COMMON_DOCTOR_YN,                                                                                                        ");
		sql.append("          A.GUBUN GUBUN,                                                                                                                                           ");
		sql.append("          IFNULL (E.GROUP_KEY, '0') GROUP_KEY,                                                                                                                     ");
		sql.append("          A.KENSA_YN KENSA_YN,                                                                                                                                     ");
		sql.append("          IF (                                                                                                                                                     ");
		sql.append("             FN_OCS_GET_NOTAPPROVE_ORDERCNT (                                                                                                                      ");
		sql.append("                A.HOSP_CODE,                                                                                                                                       ");
		sql.append("                'O',                                                                                                                                               ");
		sql.append("                'Y',                                                                                                                                               ");
		sql.append("                'N',                                                                                                                                               ");
		sql.append("                SUBSTR(A.DOCTOR, LENGTH (A.DOCTOR) - 4),                                                                                                           ");
		sql.append("                A.PKOUT1001) = 0, 'N',                                                                                                                             ");
		sql.append("             'Y')                                                                                                                                                  ");
		sql.append("             UNAPPROVE_YN                                                                                                                                          ");
		sql.append(" FROM OUT1001 A                                                                                                                                                    ");
		sql.append("          LEFT JOIN OCS0503 C ON C.HOSP_CODE = A.HOSP_CODE AND C.CONSULT_FKOUT1001 = A.PKOUT1001                                                                   ");
		sql.append("          LEFT JOIN  BAS0102 E ON E.CODE = A.JUBSU_GUBUN AND E.CODE_TYPE = 'JUBSU_GUBUN' AND E.HOSP_CODE = A.HOSP_CODE                                             ");
		sql.append("          INNER JOIN BAS0270 D on D.HOSP_CODE = A.HOSP_CODE AND D.DOCTOR = A.DOCTOR                                                                                ");
		sql.append("          INNER JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                                                                  ");
		sql.append("                                                                                                                                                                   ");
		sql.append("    WHERE     A.HOSP_CODE = :hospCode                                                                                                                           ");
		sql.append("          AND A.NAEWON_DATE = DATE_FORMAT(:naewonDate,'%Y/%m/%d')                                                                                               ");
		sql.append("          AND A.NAEWON_YN IN ('Y', 'E', 'H')                                                                                                                       ");
		sql.append("          AND CASE WHEN (A.NAEWON_YN IN ('E', 'H')) THEN 'Y' ELSE 'N' END LIKE                                                                                     ");
		sql.append("                 :naewonYn                                                                                                                                      ");
		sql.append("          AND IFNULL (A.RESER_YN, 'N') LIKE :reserYn                                                                                                            ");
		sql.append("          AND ( (:doctorModeYn = 'Y'                                                                                                                           ");
		sql.append("                 AND (A.DOCTOR LIKE CONCAT('%' , SUBSTR(:doctor, 3))                                                                                             ");
		sql.append("                      OR D.COMMON_DOCTOR_YN = 'Y'))                                                                                                                ");
		sql.append("               OR (:doctorModeYn != 'Y'                                                                                                                        ");
		sql.append("                  AND (A.DOCTOR LIKE CONCAT( '%' , SUBSTR(:doctor, 3)))))                                                                                        ");
		sql.append("          AND A.BUNHO LIKE :bunho                                                                                                                                ");
		sql.append("          AND ( (:doctorModeYn = 'Y' AND IFNULL(E.GROUP_KEY, '0') = '1')                                                                                       ");
		sql.append("               OR :doctorModeYn != 'Y')                                                                                                                        ");
		sql.append("          AND E.LANGUAGE = :language                                                                                                                             ");
		sql.append("          AND A.NAEWON_DATE BETWEEN D.START_DATE AND D.END_DATE                                                                                                    ");
		sql.append(" ORDER BY IFNULL(A.ARRIVE_TIME, A.JUBSU_TIME), A.BUNHO, A.JUBSU_NO                                                                                                 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("naewonYn", naewonYn);
		query.setParameter("reserYn", reserYn);
		query.setParameter("doctorModeYn", doctorModeYn);
		query.setParameter("doctor", doctor);
		query.setParameter("bunho", bunho);

		List<OcsoOCS1003P01GridPatientListInfo> list = new JpaResultMapper()
				.list(query, OcsoOCS1003P01GridPatientListInfo.class);
		return list;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getOcsoOCS1003P01CheckY(String hospCode, Double pkout1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT 'Y'                                           ");
		sql.append(" FROM OUT1001 A                                               ");
		sql.append("      , BAS0270 B                                             ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                                 ");
		sql.append("  AND A.PKOUT1001 = :pkout1001                                ");
		sql.append("  AND B.HOSP_CODE = A.HOSP_CODE                               ");
		sql.append("  AND B.DOCTOR = A.DOCTOR                                     ");
		sql.append("  AND B.DOCTOR_GWA = A.GWA                                    ");
		sql.append("  AND A.NAEWON_DATE BETWEEN B.START_DATE                      ");
		sql.append("  AND IFNULL(B.END_DATE, DATE_FORMAT('99981231', '%Y%m%d'))   ");
		sql.append("  AND IFNULL(B.COMMON_DOCTOR_YN, 'N') = 'Y'                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkout1001", pkout1001);
		List<Object> result = query.getResultList();
		if (!result.isEmpty()) {
			return result.get(0).toString();
		}

		return null;
	}

	@Override
	public NuroOUT1001U01LoadCheckChojaeJpnInfo getNuroOUT1001U01LoadCheckChojaeJpnInfo(
			String hospCode, String date, String bunho, String gubun,
			String gwa, double jubsuNo, String oChojae, String oChtChojae,
			String oGajubsu_GUBUN, String oErr) {
		LOG.info("[START] getNuroOUT1001U01LoadCheckChojaeJpnInfo hospCode="
				+ hospCode + ", date=" + date + ", bunho=" + bunho + ", gubun="
				+ gubun + ", gwa=" + gwa + ", jubsuNo=" + jubsuNo
				+ ", oChojae=" + oChojae + ", gubun=" + oChtChojae
				+ ", oGajubsu_GUBUN=" + oGajubsu_GUBUN + ", oErr=" + oErr);

		StoredProcedureQuery query = entityManager
				.createStoredProcedureQuery("PR_OUT_LOAD_CHECK_CHOJAE_JPN");
		query.registerStoredProcedureParameter("I_HOSPCODE", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DATE", Date.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class,
				ParameterMode.IN);
		;
		query.registerStoredProcedureParameter("I_GWA", String.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_NO", Double.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("O_CHOJAE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_CHT_CHOJAE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_GAJUBSU_GUBUN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_ERR", String.class,
				ParameterMode.INOUT);

		query.setParameter("I_HOSPCODE", hospCode);
		query.setParameter("I_DATE",
				DateUtil.toDate(date, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_GWA", gwa);
		query.setParameter("I_JUBSU_NO", jubsuNo);
		query.setParameter("O_CHOJAE", oChojae);
		query.setParameter("O_CHT_CHOJAE", oChtChojae);
		query.setParameter("O_GAJUBSU_GUBUN", oGajubsu_GUBUN);
		query.setParameter("O_ERR", oErr);

		NuroOUT1001U01LoadCheckChojaeJpnInfo result = new NuroOUT1001U01LoadCheckChojaeJpnInfo(
				(String) query.getOutputParameterValue("O_CHOJAE"),
				(String) query.getOutputParameterValue("O_CHT_CHOJAE"),
				(String) query.getOutputParameterValue("O_GAJUBSU_GUBUN"),
				(String) query.getOutputParameterValue("O_ERR"));

		return result;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String checkOcsoOCS1003P01CheckIsSameNameYn(String hospCode,
													   String language, String naewonDate, String gwa, String naewonYn,
													   String reserYn, String doctorModeYn, String doctor, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_ADM_IS_SAME_NAME_YN_T(  ");
		sql.append("     :naewonDate,               ");
		sql.append("     :gwa,                       ");
		sql.append("     :naewonYn,                 ");
		sql.append("     :reserYn,                  ");
		sql.append("     :doctorModeYn,            ");
		sql.append("     :doctor,                    ");
		sql.append("     :bunho,                     ");
		sql.append("     :hospCode,                 ");
		sql.append("     :language)                  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("gwa", gwa);
		query.setParameter("naewonYn", naewonYn);
		query.setParameter("reserYn", reserYn);
		query.setParameter("doctorModeYn", doctorModeYn);
		query.setParameter("doctor", doctor);
		query.setParameter("bunho", bunho);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", hospCode);

		List<Object> result = query.getResultList();
		if (!result.isEmpty()) {
			return result.get(0).toString();
		}

		return null;

	}

	@Override
	public List<OcsoOCS1003Q05ScheduleItemInfo> getOcsoOCS1003Q05Schedule(
			String hospCode, String language, String inputGubun, String telYn,
			String inpuTab, String ioGubun, String selectedInputTab,
			String bunho, String kijun, String naewonDate, String gwa) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("   SELECT  X.NAEWON_DATE,                                                                                                                                                              									");
		sql.append("           X.GWA,GWA_NAME,                                                                                                                                                              									");
		sql.append("           X.DOCTOR_NAME,                                                                                                                                                              									");
		sql.append("           X.NALSU,                                                                                                                                                              									");
		sql.append("           X.BUNHO,                                                                                                                                                              									");
		sql.append("           X.DOCTOR,                                                                                                                                                              									");
		sql.append("           X.GUBUN_NAME,                                                                                                                                                              									");
		sql.append("           X.CHOJAE_NAME,                                                                                                                                                              									");
		sql.append("           X.NAEWON_TYPE,                                                                                                                                                              									");
		sql.append("           X.JUBSU_NO,                                                                                                                                                              									");
		sql.append("           X.PK_ORDER,                                                                                                                                                              									");
		sql.append("           X.INPUT_GUBUN,                                                                                                                                                              									");
		sql.append("           X.TEL_YN,                                                                                                                                                              									");
		sql.append("           X.TOIWON_DRG,                                                                                                                                                              									");
		sql.append("           X.INPUT_TAB,                                                                                                                                                              									");
		sql.append("           X.IO_GUBUN,                                                                                                                                                              									");
		sql.append("           X.OCS_CNT                                                                                                                                                              									");
		sql.append("   FROM (                                                                                                                                                              									");
		sql.append("SELECT A.NAEWON_DATE                     NAEWON_DATE,                                                                                                                                                                 									");
		sql.append("       A.GWA                             GWA,                                                                                                                                                                         									");
		sql.append("       FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE, :hospCode, :language)                                                                                                                                         										");
		sql.append("                                         GWA_NAME,                                                                                                                                                                    									");
		sql.append("       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :hospCode)                                                                                                                                                										");
		sql.append("                                         DOCTOR_NAME,                                                                                                                                                                 									");
		sql.append("       0                                 NALSU,                                                                                                                                                                       									");
		sql.append("       A.BUNHO                           BUNHO,                                                                                                                                                                       									");
		sql.append("       A.DOCTOR                          DOCTOR,                                                                                                                                                                      									");
		sql.append("       FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.NAEWON_DATE, :hospCode)                                                                                                                                                   										");
		sql.append("                                         GUBUN_NAME ,                                                                                                                                                                 									");
		sql.append("       FN_BAS_LOAD_CODE_NAME ('CHOJAE', A.CHOJAE, :hospCode, :language)                                                                                                                                          										");
		sql.append("                                         CHOJAE_NAME,                                                                                                                                                                 									");
		sql.append("       A.NAEWON_TYPE                     NAEWON_TYPE,                                                                                                                                                                 									");
		sql.append("       A.JUBSU_NO                        JUBSU_NO   ,                                                                                                                                                                 									");
		sql.append("       A.PKOUT1001                       PK_ORDER,                                                                                                                                                                    									");
		sql.append("       IFNULL(TRIM(RPAD(:inputGubun,10,'')),TRIM(:inputGubun))    INPUT_GUBUN,                                                                                                                                  										");
		sql.append("       :telYn                         TEL_YN,                                                                                                                                                                      										");
		sql.append("       'N'                               TOIWON_DRG,                                                                                                                                                                  									");
		sql.append("       :inpuTab                      INPUT_TAB,                                                                                                                                                                   										");
		sql.append("       :ioGubun                       IO_GUBUN,                                                                                                                                                                    										");
		sql.append("       IF(:selectedInputTab = '%', 'Y' ,                                                                                                                                                                          										");
		sql.append("        FN_OCS_DO_ORDER_COUNT(  :hospCode, 'O', :bunho, A.PKOUT1001, A.DOCTOR, :selectedInputTab , :inputGubun, :kijun, A.NAEWON_DATE ))  OCS_CNT                                                       												");
		sql.append("  FROM OUT1001 A                                                                                                                                                                                                      									");
		sql.append(" WHERE :ioGubun    = 'O'                                                                                                                                                                                           										");
		sql.append("   AND A.HOSP_CODE    = :hospCode                                                                                                                                                                                  										");
		sql.append("   AND A.BUNHO        = :bunho                                                                                                                                                                                      									");
		sql.append("   AND A.NAEWON_DATE  <= :naewonDate                                                                                                                                                                               										");
		sql.append("   AND A.GWA         LIKE :gwa                                                                                                                                                                                      									");
		sql.append("   AND EXISTS( SELECT DISTINCT 'X'                                                                                                                                                                                    									");
		sql.append("                 FROM OCS0140 C,                                                                                                                                                                                      									");
		sql.append("                      OCS1003 B                                                                                                                                                                                       									");
		sql.append("                WHERE B.BUNHO        = A.BUNHO                                                                                                                                                                        									");
		sql.append("                  AND B.FKOUT1001    = A.PKOUT1001                                                                                                                                                                    									");
		sql.append("                  AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                                                                    									");
		sql.append("                  AND IFNULL(B.TEL_YN     , 'N') LIKE :telYn                                                                                                                                                       										");
		sql.append("                  AND IFNULL(B.DISPLAY_YN , 'Y') = 'Y'                                                                                                                                                                									");
		sql.append("                  AND IFNULL(B.DC_YN,'N')   = 'N'                                                                                                                                                                     									");
		sql.append("                  AND B.NALSU           >= 0                                                                                                                                                                          									");
		sql.append("                  AND B.INPUT_TAB       LIKE :inpuTab                                                                                                                                                             										");
		sql.append("                  AND (                                                                                                                                                                                               									");
		sql.append("                        ( :inputGubun LIKE  'D%'                                                                                                                                                                   										");
		sql.append("                          AND                                                                                                                                                                                         									");
		sql.append("                          B.INPUT_GUBUN LIKE 'D%' )                                                                                                                                                                   									");
		sql.append("                        OR                                                                                                                                                                                            									");
		sql.append("                        ( :inputGubun = 'NR'                                                                                                                                                                       										");
		sql.append("                          AND                                                                                                                                                                                         									");
		sql.append("                          ( B.INPUT_GUBUN LIKE 'D%'                                                                                                                                                                   									");
		sql.append("                            OR                                                                                                                                                                                        									");
		sql.append("                            B.INPUT_GUBUN = 'NR' ) )                                                                                                                                                                  									");
		sql.append("                        OR                                                                                                                                                                                            									");
		sql.append("                        ( :inputGubun NOT IN ('D%', 'NR')                                                                                                                                                          										");
		sql.append("                           AND                                                                                                                                                                                        									");
		sql.append("                           ( B.INPUT_GUBUN LIKE 'D%'                                                                                                                                                                  									");
		sql.append("                             OR                                                                                                                                                                                       									");
		sql.append("                             B.INPUT_GUBUN = :inputGubun ) )                                                                                                                                                       										");
		sql.append("                      )                                                                                                                                                                                               									");
		sql.append("                  AND C.ORDER_GUBUN     = B.ORDER_GUBUN                                                                                                                                                               									");
		sql.append("                  AND C.HOSP_CODE       = B.HOSP_CODE                                                                                                                                                                 									");
		sql.append("                  AND C.INPUT_TAB       = B.INPUT_TAB                                                                                                                                                                 									");
		sql.append("                   )                                                                                                                                                                                                  									");
		sql.append("  UNION ALL                                                                                                                                                                                                           									");
		sql.append("  SELECT IF(:kijun = 'H', IFNULL(A.HOPE_DATE, IFNULL(A.RESER_DATE, A.ORDER_DATE)), A.ORDER_DATE)              ORDER_DATE ,                                                                                          									");
		sql.append("         A.INPUT_GWA                                                       GWA        ,                                                                                                                               									");
		sql.append("                FN_BAS_LOAD_GWA_NAME( A.INPUT_GWA, A.ORDER_DATE, :hospCode, :language )                 GWA_NAME,                                                                                                										");
		sql.append("         FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE, :hospCode)          DOCTOR_NAME,                                                                                                                    										");
		sql.append("         0                                                                 NALSU,                                                                                                                                     									");
		sql.append("         A.BUNHO                                                           BUNHO      ,                                                                                                                               									");
		sql.append("         A.INPUT_DOCTOR                                                    DOCTOR     ,                                                                                                                               									");
		sql.append("         ' '                                                               GUBUN_NAME ,                                                                                                                               									");
		sql.append("         ' '                                                               CHOJAE_NAME,                                                                                                                               									");
		sql.append("         '0'                                                               NAEWON_TYPE,                                                                                                                               									");
		sql.append("         A.FKINP1001                                                       JUBSU_NO   ,                                                                                                                               									");
		sql.append("         A.FKINP1001                                                       PK_ORDER   ,                                                                                                                               									");
		sql.append("         IFNULL(TRIM(RPAD(:inputGubun,10,'')),TRIM(:inputGubun))                                     INPUT_GUBUN,                                                                                               										");
		sql.append("         :telYn                                                         TEL_YN     ,                                                                                                                               										");
		sql.append("         FN_OCS_EXISTS_TOIWON_DRG(A.BUNHO, A.FKINP1001, A.ORDER_DATE, :hospCode)         TOIWON_DRG,                                                                                                               										");
		sql.append("         :inpuTab                                                      INPUT_TAB,                                                                                                                                 										");
		sql.append("         :ioGubun                                                       IO_GUBUN,                                                                                                                                  										");
		sql.append("         IF(:selectedInputTab = '%', 'Y'                                                                                                                                                                          										");
		sql.append("                                          , FN_OCS_DO_ORDER_COUNT(  :hospCode, 'I', :bunho, A.FKINP1001, A.INPUT_DOCTOR, :selectedInputTab                                                                   											");
		sql.append("                                                                  , :inputGubun, :kijun, IF(:kijun = 'H', IFNULL(A.HOPE_DATE, IFNULL(A.RESER_DATE, A.ORDER_DATE)), A.ORDER_DATE)) )  OCS_CNT                   											");
		sql.append("  FROM OCS0140  B,                                                                                                                                                                                                    									");
		sql.append("       OCS2003  A                                                                                                                                                                                                     									");
		sql.append(" WHERE :ioGubun            = 'I'                                                                                                                                                                                   										");
		sql.append("   AND A.HOSP_CODE            = :hospCode                                                                                                                                                                          										");
		sql.append("   AND (A.IO_GUBUN             IS NULL OR A.IO_GUBUN = '')                                                                                                                                                     									");
		sql.append("   AND A.BUNHO                = :bunho                                                                                                                                                                              									");
		sql.append("   AND A.ORDER_DATE           <= :naewonDate                                                                                                                                                                       										");
		sql.append("  AND A.INPUT_GWA            LIKE :gwa                                                                                                                                                                              									");
		sql.append("   AND (                                                                                                                                                                                                              									");
		sql.append("         ( :inputGubun LIKE 'D%'                                                                                                                                                                                   										");
		sql.append("           AND                                                                                                                                                                                                        									");
		sql.append("           A.INPUT_GUBUN LIKE 'D%' )                                                                                                                                                                                  									");
		sql.append("         OR                                                                                                                                                                                                           									");
		sql.append("         ( :inputGubun = 'NR'                                                                                                                                                                                      										");
		sql.append("           AND                                                                                                                                                                                                        									");
		sql.append("           ( A.INPUT_GUBUN LIKE 'D%'                                                                                                                                                                                  									");
		sql.append("             OR                                                                                                                                                                                                       									");
		sql.append("             A.INPUT_GUBUN = 'NR' ) )                                                                                                                                                                                 									");
		sql.append("         OR                                                                                                                                                                                                           									");
		sql.append("         ( ( :inputGubun NOT LIKE 'D%' AND :inputGubun != 'NR' )                                                                                                                                                										");
		sql.append("           AND                                                                                                                                                                                                        									");
		sql.append("           ( A.INPUT_GUBUN LIKE 'D%'                                                                                                                                                                                  									");
		sql.append("             OR                                                                                                                                                                                                       									");
		sql.append("             A.INPUT_GUBUN = :inputGubun ) )                                                                                                                                                                       										");
		sql.append("       )                                                                                                                                                                                                              									");
		sql.append("   AND A.NALSU               >= 0                                                                                                                                                                                     									");
		sql.append("   AND CASE(A.DISPLAY_YN) WHEN '' THEN 'Y' ELSE IFNULL(A.DISPLAY_YN ,'Y') END = 'Y'                                                                                                                                 									");
		sql.append("   AND CASE(A.DC_YN) WHEN '' THEN 'N' ELSE IFNULL(A.DC_YN,'N') END = 'N'                                                                                                                                                       									");
		sql.append("   AND B.ORDER_GUBUN   = A.ORDER_GUBUN                                                                                                                                                                                									");
		sql.append("   AND B.HOSP_CODE     = A.HOSP_CODE                                                                                                                                                                                  									");
		sql.append("   AND B.INPUT_TAB     = A.INPUT_TAB                                                                                                                                                                                  									");
		sql.append(" 	   ) X																														                                                                                   											");
		sql.append(" 	 GROUP BY X.NAEWON_DATE,																														                                                                                   											");
		sql.append(" 	          X.GWA,GWA_NAME,																														                                                                                   											");
		sql.append(" 	          X.DOCTOR_NAME,																														                                                                                   											");
		sql.append(" 	          X.NALSU,																														                                                                                   											");
		sql.append(" 	          X.BUNHO,																														                                                                                   											");
		sql.append(" 	          X.DOCTOR,																														                                                                                   											");
		sql.append(" 	          X.GUBUN_NAME,																														                                                                                   											");
		sql.append(" 	          X.CHOJAE_NAME,																														                                                                                   											");
		sql.append(" 	          X.NAEWON_TYPE,																														                                                                                   											");
		sql.append(" 	          X.JUBSU_NO,																														                                                                                   											");
		sql.append(" 	          X.PK_ORDER,																														                                                                                   											");
		sql.append(" 	          X.INPUT_GUBUN,																														                                                                                   											");
		sql.append(" 	          X.TEL_YN,																														                                                                                   											");
		sql.append(" 	          X.TOIWON_DRG,																														                                                                                   											");
		sql.append(" 	          X.INPUT_TAB,																														                                                                                   											");
		sql.append(" 	          X.IO_GUBUN,																														                                                                                   											");
		sql.append(" 	          X.OCS_CNT																														                                                                                   											");
		sql.append("  ORDER BY X.NAEWON_DATE DESC, X.INPUT_GUBUN DESC                                                                                                                                                                                            								   	");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("inputGubun", inputGubun);
		query.setParameter("telYn", telYn);
		query.setParameter("inpuTab", inpuTab);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("selectedInputTab", selectedInputTab);
		query.setParameter("bunho", bunho);
		query.setParameter("kijun", kijun);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("gwa", gwa);

		List<OcsoOCS1003Q05ScheduleItemInfo> list = new JpaResultMapper().list(
				query, OcsoOCS1003Q05ScheduleItemInfo.class);
		return list;
	}

	@Override
	public List<NuroNUR1001R00GetTempListItemInfo> getNuroNUR1001R00GetTempListItem(
			String hospCode, String doctorName, String month, String gwa,
			String doctor) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT :f_doctor_name,                                                                 ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 01, A.NUM, 0)), 0) NUM1,       ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 02, A.NUM, 0)), 0) NUM2,       ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 03, A.NUM, 0)), 0) NUM3,       ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 04, A.NUM, 0)), 0) NUM4,       ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 05, A.NUM, 0)), 0) NUM5,       ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 06, A.NUM, 0)), 0) NUM6,       ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 07, A.NUM, 0)), 0) NUM7,       ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 08, A.NUM, 0)), 0) NUM8,       ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 09, A.NUM, 0)), 0) NUM9,       ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 10, A.NUM, 0)), 0) NUM10,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 11, A.NUM, 0)), 0) NUM11,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 12, A.NUM, 0)), 0) NUM12,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 13, A.NUM, 0)), 0) NUM13,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 14, A.NUM, 0)), 0) NUM14,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 15, A.NUM, 0)), 0) NUM15,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 16, A.NUM, 0)), 0) NUM16,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 17, A.NUM, 0)), 0) NUM17,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 18, A.NUM, 0)), 0) NUM18,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 19, A.NUM, 0)), 0) NUM19,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 20, A.NUM, 0)), 0) NUM20,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 21, A.NUM, 0)), 0) NUM21,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 22, A.NUM, 0)), 0) NUM22,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 23, A.NUM, 0)), 0) NUM23,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 24, A.NUM, 0)), 0) NUM24,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 25, A.NUM, 0)), 0) NUM25,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 26, A.NUM, 0)), 0) NUM26,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 27, A.NUM, 0)), 0) NUM27,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 28, A.NUM, 0)), 0) NUM28,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 29, A.NUM, 0)), 0) NUM29,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 30, A.NUM, 0)), 0) NUM30,      ");
		sql.append("       IFNULL(SUM(IF(DATE_FORMAT(A.NAEWON_DATE, '%d') = 31, A.NUM, 0)), 0) NUM31,      ");
		sql.append("        DATE_FORMAT(LAST_DAY(STR_TO_DATE(CONCAT(:f_month,'01'),'%Y%m%d')),'%d')        ");
		sql.append("  FROM (SELECT NAEWON_DATE NAEWON_DATE,                                                ");
		sql.append("               COUNT(BUNHO)             NUM                                            ");
		sql.append("          FROM OUT1001                                                                 ");
		sql.append("         WHERE HOSP_CODE = :f_hosp_code                                                ");
		sql.append("           AND GWA       = :f_gwa                                                      ");
		sql.append("           AND DOCTOR    = :f_doctor                                                   ");
		sql.append("           AND NAEWON_DATE IN (SELECT DATE_FORMAT(HOLI_DAY,'%Y%m%d')                   ");
		sql.append("                                 FROM RES0101                                          ");
		sql.append("                                  WHERE DATE_FORMAT(HOLI_DAY, '%Y%m') = :f_month)      ");
		sql.append("           AND IF(NAEWON_YN = 'N', 'N', 'Y') = 'Y'                                     ");
		sql.append("         GROUP BY NAEWON_DATE) A                                                       ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor_name", doctorName);
		query.setParameter("f_month", month);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);

		List<NuroNUR1001R00GetTempListItemInfo> list = new JpaResultMapper()
				.list(query, NuroNUR1001R00GetTempListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS0503Q00FilteringTheInformationInfo> getOcsaOCS0503Q00GrdRequestOUT1001List(
			String hospCode, String language, String bunho, String naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CASE WHEN IFNULL(A.RESER_YN, 'N') = 'Y'                                                       ");
		sql.append("             AND IFNULL(A.NAEWON_TYPE, '0') = '1'                                                    ");
		sql.append("             AND A.NAEWON_DATE > SYSDATE() THEN 'Y'                                                  ");
		sql.append("            ELSE    'N'                                                                              ");
		sql.append("       END  RESER_YN ,                                                                               ");
		sql.append("       A.JUBSU_TIME                                     JINRYO_TIME,                                 ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :f_hosp_code, :f_language)       GWA_NAME   ,      ");
		sql.append("       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,A.NAEWON_DATE, :f_hosp_code)  DOCTOR_NAME,                   ");
		sql.append("       IF(IFNULL(A.NAEWON_YN,'N') = 'Y' OR IFNULL(A.NAEWON_YN,'N') = 'E','Y','N') NAEWON_YN  ,       ");
		sql.append("       A.BUNHO                                          BUNHO      ,                                 ");
		sql.append("       A.NAEWON_DATE                                    NAEWON_DATE,                                 ");
		sql.append("       A.GWA                                            GWA        ,                                 ");
		sql.append("       A.DOCTOR                                         DOCTOR     ,                                 ");
		sql.append("       A.NAEWON_TYPE                                    NAEWON_TYPE,                                 ");
		sql.append("       A.JUBSU_NO                                       JUBSU_NO                                     ");
		sql.append("  FROM OUT1001 A                                                                                     ");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                                                                  ");
		sql.append("   AND A.NAEWON_DATE = DATE_FORMAT(:f_naewon_date,'%Y/%m/%d')                                        ");
		sql.append("   AND A.BUNHO       = :f_bunho                                                                      ");
		sql.append(" ORDER BY 2                                                                                          ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);

		List<OCS0503Q00FilteringTheInformationInfo> list = new JpaResultMapper()
				.list(query, OCS0503Q00FilteringTheInformationInfo.class);
		return list;
	}

	@Override
	public DrgsDRG5100P01LoadChebangPrintInfo getDrgsDRG5100P01LoadChebangPrintInfo(
			String hospCode, Double fkOut1001) {
		StoredProcedureQuery query = entityManager
				.createStoredProcedureQuery("PR_OUT_LOAD_CHEBANG_PRINT");
		query.registerStoredProcedureParameter("I_FKOCS1003", Double.class,
				ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSPCODE", String.class,
				ParameterMode.IN);

		query.registerStoredProcedureParameter("IO_GUBUN_NAME", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JOHAP", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_GAEIN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_GAEIN_NO", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BONIN_GUBUN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BON_RATE", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BUDAMJA_BUNHO1",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUGUBJA_BUNHO1",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BUDAMJA_BUNHO2",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUGUBJA_BUNHO2",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUNWON_GUBUN", String.class,
				ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_NOIN_RATE_NAME",
				String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class,
				ParameterMode.INOUT);

		query.setParameter("I_FKOCS1003", fkOut1001);
		query.setParameter("I_HOSPCODE", hospCode);

		query.execute();
		DrgsDRG5100P01LoadChebangPrintInfo result = new DrgsDRG5100P01LoadChebangPrintInfo(
				(String) query.getOutputParameterValue("IO_GUBUN_NAME"),
				(String) query.getOutputParameterValue("IO_JOHAP"),
				(String) query.getOutputParameterValue("IO_GAEIN"),
				(String) query.getOutputParameterValue("IO_GAEIN_NO"),
				(String) query.getOutputParameterValue("IO_BONIN_GUBUN"),
				(String) query.getOutputParameterValue("IO_BON_RATE"),
				(String) query.getOutputParameterValue("IO_BUDAMJA_BUNHO1"),
				(String) query.getOutputParameterValue("IO_SUGUBJA_BUNHO1"),
				(String) query.getOutputParameterValue("IO_BUDAMJA_BUNHO2"),
				(String) query.getOutputParameterValue("IO_SUGUBJA_BUNHO2"),
				(String) query.getOutputParameterValue("IO_SUNWON_GUBUN"),
				(String) query.getOutputParameterValue("IO_NOIN_RATE_NAME"),
				(String) query.getOutputParameterValue("IO_ERR"));

		return result;
	}

	@Override
	public List<SchsSCH0201U99ReserListInfo> getSchsSCH0201U99ReserListInfo(
			String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.NAEWON_DATE   ,																					");
		sql.append("	        ( CASE WHEN LENGTH( A.JUBSU_TIME ) = 4                                                              ");
		sql.append("	               THEN CONCAT(SUBSTRING(A.JUBSU_TIME, 1, 2),':',SUBSTR(A.JUBSU_TIME, 3))                       ");
		sql.append("	               ELSE '' END )                                                     JINRYO_PRE_TIME,           ");
		sql.append("	        FN_BAS_LOAD_GWA_NAME   (A.GWA   , A.NAEWON_DATE,:hospCode, 'JA')      GWA_NAME,                     ");
		sql.append("	        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE,:hospCode)            DOCTOR_NAME                   ");
		sql.append("	   FROM OUT1001 A                                                                                           ");
		sql.append("	  WHERE A.HOSP_CODE        = :hospCode                                                                      ");
		sql.append("	    AND A.RESER_YN         = 'Y'                                                                            ");
		sql.append("	    AND A.BUNHO            = :bunho                                                                         ");
		sql.append("	    AND A.NAEWON_DATE     >= DATE_FORMAT(SYSDATE(),'%Y-%m-%d %H:%m:%s')                                     ");
		sql.append("	 ORDER BY A.NAEWON_DATE, A.JUBSU_TIME ;                                                                     ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);

		List<SchsSCH0201U99ReserListInfo> list = new JpaResultMapper().list(
				query, SchsSCH0201U99ReserListInfo.class);
		return list;
	}

	@Override
	public String callPrResDoctorScheduleNew(String hospCode, String sessionHospCode, String doctor,
											 String yyMm, String isOtherClinic,  String oErr) {
		StoredProcedureQuery query = entityManager
				.createStoredProcedureQuery("PR_RES_DOCTOR_SCHEDULE_NEW");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SESSION_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_YYMM", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IS_OTHER_CLINIC", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SESSION_HOSP_CODE", sessionHospCode);
		query.setParameter("I_DOCTOR", doctor);
		query.setParameter("I_YYMM", yyMm);
		query.setParameter("IS_OTHER_CLINIC", isOtherClinic);
		query.setParameter("O_ERR", oErr);

		String result = (String) query.getOutputParameterValue("O_ERR");
		if (result != null && !result.isEmpty()) {
			return result;
		}
		return null;
	}

	@Override
	public List<OUT1001P01GrdOUT1001ListItemInfo> getOUT1001P01GrdOUT1001(
			String hospCode, String bunho, Date naewonDate, Double pkout1001,
			String language) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.PKOUT1001															");
		sql.append("	    , A.BUNHO                                                               ");
		sql.append("	    , A.GWA                                                                 ");
		sql.append("	    , FN_BAS_LOAD_GWA_NAME    (A.GWA, A.NAEWON_DATE,:hospCode,:language)    ");
		sql.append("	    , A.DOCTOR                                                              ");
		sql.append("	    , FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, A.NAEWON_DATE,:hospCode)           ");
		sql.append("	    , A.JUBSU_NO                                                            ");
		sql.append("	 FROM OUT1001 A                                                             ");
		sql.append("	WHERE A.HOSP_CODE   = :hospCode                                             ");
		sql.append("	  AND A.BUNHO       = :bunho                                                 ");
		sql.append("	  AND A.NAEWON_DATE =   :naewonDate						                    ");
		sql.append("	  AND ((:pkout1001 IS NOT NULL AND A.PKOUT1001 = :pkout1001)                ");
		sql.append("	     OR(:pkout1001 IS NULL))                                                ");
		sql.append("	  AND A.GWA NOT IN ('HC')                                                   ");
		sql.append("	ORDER BY A.PKOUT1001                                                        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("pkout1001", pkout1001);
		query.setParameter("language", language);

		List<OUT1001P01GrdOUT1001ListItemInfo> list = new JpaResultMapper()
				.list(query, OUT1001P01GrdOUT1001ListItemInfo.class);
		return list;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getLastGubun(String hospCode, String bunho, String gwa,
							   String naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.GUBUN                                                                 ");
		sql.append("  FROM OUT1001 A                                                               ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                              ");
		sql.append("   AND A.BUNHO     = :f_bunho                                                  ");
		sql.append("   AND A.GWA       = :f_gwa                                                   ");
		sql.append("   AND A.NAEWON_DATE = (SELECT MAX(Z.NAEWON_DATE)                              ");
		sql.append("                          FROM OUT1001 Z                                       ");
		sql.append("                         WHERE Z.HOSP_CODE = A.HOSP_CODE                       ");
		sql.append("                           AND Z.BUNHO     = A.BUNHO                           ");
		sql.append("                           AND Z.GWA       = A.GWA                             ");
		sql.append("                           AND NAEWON_DATE < STR_TO_DATE(:f_date, '%Y/%m/%d')) ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_date", naewonDate);
		List<String> result = query.getResultList();
		if (!result.isEmpty()) {
			return result.get(0);
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getRecentlyDoctor(String hospCode, String bunho, String gwa,
									String naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR                                                                ");
		sql.append("  FROM OUT1001 A                                                               ");
		sql.append("     , BAS0270 B                                                               ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                              ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                               ");
		sql.append("   AND B.DOCTOR    = A.DOCTOR                                                  ");
		sql.append("   AND STR_TO_DATE(:f_date, '%Y/%m/%d') BETWEEN B.START_DATE AND B.END_DATE    ");
		sql.append("   AND A.BUNHO     = :f_bunho                                                  ");
		sql.append("   AND A.GWA       = :f_gwa                                                    ");
		sql.append("   AND A.NAEWON_DATE = (SELECT MAX(Z.NAEWON_DATE)                              ");
		sql.append("                          FROM OUT1001 Z                                       ");
		sql.append("                         WHERE Z.HOSP_CODE  = A.HOSP_CODE                      ");
		sql.append("                           AND Z.BUNHO      = A.BUNHO                          ");
		sql.append("                           AND Z.GWA        = A.GWA                            ");
		sql.append("                           AND NAEWON_DATE <= STR_TO_DATE(:f_date, '%Y/%m/%d'))");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_date", naewonDate);
		List<String> result = query.getResultList();
		if (!result.isEmpty()) {
			return result.get(0);
		}
		return null;
	}

	@Override
	public NuroChkGetBunhoBySujinInfo getNuroChkGetBunhoBySujinInfo(
			String hospCode, String naewonDate, String sujinNo) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                               ");
		sql.append("        BUNHO                                   BUNHO         ");
		sql.append("      , FN_OUT_LOAD_SUNAME(BUNHO, :f_hosp_code) SUNAME        ");
		sql.append("   FROM OUT1001                                               ");
		sql.append("  WHERE HOSP_CODE   = :f_hosp_code                            ");
		sql.append("    AND NAEWON_DATE = STR_TO_DATE(:f_naewon_date,'%Y/%m/%d')  ");
		sql.append("    AND SUJIN_NO    = :f_sujin_no                             ");
		sql.append("    AND IFNULL(SUNNAB_YN, 'N') = 'N'                          ");
		sql.append("    AND IFNULL(SUJIN_NO,0) <> 0                               ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_sujin_no", sujinNo);

		List<NuroChkGetBunhoBySujinInfo> list = new JpaResultMapper().list(
				query, NuroChkGetBunhoBySujinInfo.class);
		if (list != null && list.size() > 0) {
			return list.get(0);
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<String> getNuroLoadTableReserYN(String hospCode, String bunho,
												String gwa, String naewonDate, String doctor) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT JUBSU_TIME                                                    ");
		sql.append("        FROM OUT1001                                                 ");
		sql.append("       WHERE HOSP_CODE   = :f_hosp_code                              ");
		sql.append("         AND RESER_YN    = 'Y'                                       ");
		sql.append("         AND BUNHO       = :f_bunho                                  ");
		sql.append("         AND GWA         = :f_gwa                                    ");
		sql.append("         AND NAEWON_DATE = STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')   ");
		sql.append("		 AND DOCTOR      = :f_doctor                                 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_doctor", doctor);

		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public List<OCS1003P01GrdPatientListItemInfo> getOCS1003P01GrdPatientListItem(
			String hospCode, Date naewonDate, String naewonYn, String reserYn,
			String doctorModeYn, String doctor, String bunho, String language) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.BUNHO																																				                   	");
		sql.append("	   , A.NAEWON_DATE                                                                                                                                                             ");
		sql.append("	   , A.GWA                                                                                                                                                                     ");
		sql.append("	   , A.DOCTOR                                                                                                                                                                  ");
		sql.append("	   , A.NAEWON_TYPE                                                                                                                                                             ");
		sql.append("	   , IFNUlL(A.RESER_YN, 'N')                                        RESER_YN                                                                                                   ");
		sql.append("	   , A.JUBSU_TIME                                                JUBSU_TIME                                                                                                    ");
		sql.append("	   , A.ARRIVE_TIME                                               ARRIVE_TIME                                                                                                   ");
		sql.append("	   , CONCAT(IF(A.NAEWON_YN  = 'H', CONCAT( '[',FN_BAS_LOAD_CODE_NAME('NAEWON_YN', A.NAEWON_YN,:f_hosp_code, :language),'] ') , ''), B.SUNAME) SUNAME                           ");
		sql.append("	   , B.SUNAME2                                                                                                                                                                 ");
		sql.append("	   , FN_BAS_LOAD_CODE_NAME( 'SEX', B.SEX,:f_hosp_code, :language )                       SEX                                                                                   ");
		sql.append("	   , FN_BAS_LOAD_AGE ( A.NAEWON_DATE, B.BIRTH, 'XXXX')                                   AGE                                                                                   ");
		sql.append("	   , FN_BAS_LOAD_GUBUN_NAME ( A.GUBUN, A.NAEWON_DATE ,:f_hosp_code)                                   GUBUN_NAME                                                               ");
		sql.append("	   , FN_BAS_LOAD_GWA_NAME ( A.GWA, A.NAEWON_DATE,:f_hosp_code, :language )                                       GWA_NAME                                                      ");
		sql.append("	   , FN_BAS_LOAD_DOCTOR_NAME ( A.DOCTOR, A.NAEWON_DATE,:f_hosp_code )                                 DOCTOR_NAME                                                              ");
		sql.append("	   , FN_BAS_LOAD_CODE_NAME ( 'CHOJAE', A.CHOJAE ,:f_hosp_code, :language)                CHOJAE_NAME                                                                           ");
		sql.append("	   , IF(A.NAEWON_YN = 'E','Y','N')                                                        JINRYO_END_YN                                                                        ");
		sql.append("	   , A.PKOUT1001                                                                          PK_NAEWON                                                                            ");
		sql.append("	   , A.NAEWON_YN                                                                          NAEWON_YN                                                                            ");
		sql.append("	   , A.SUNNAB_YN                                                                          SUNNAB_YN                                                                            ");
		sql.append("	   , A.JUBSU_GUBUN                                                                        JUBSU_GUBUN                                                                          ");
		sql.append("	   , IF(FN_OCS_LOAD_TA_GWA_JINRYO_CNT ( A.BUNHO, A.NAEWON_DATE, A.GWA,:f_hosp_code ) > 0,'Y','N')      OTHER_GWA                                                               ");
		sql.append("	   , IF(C.PKOCS0503 IS NULL, 'N','Y')                                                     CONSULT_YN                                                                           ");
		sql.append("	   , IFNULL(D.COMMON_DOCTOR_YN , 'N')                                                        COMMON_DOCTOR_YN                                                                  ");
		sql.append("	   , A.GUBUN                                                                                   GUBUN                                                                           ");
		sql.append("	   , IFNULL(E.GROUP_KEY, '0')                                                               GROUP_KEY                                                                          ");
		sql.append("	   , A.KENSA_YN                                                                          KENSA_YN                                                                              ");
		sql.append("	   , IF(FN_OCS_GET_NOTAPPROVE_ORDERCNT(A.HOSP_CODE, 'O', 'Y', 'N', SUBSTR(A.DOCTOR, LENGTH(A.DOCTOR) -4), A.PKOUT1001) =  0, 'N', 'Y') UNAPPROVE_YN                            ");
		sql.append("	   , IFNULL(A.SYS_ID, '')                            																														   ");
		sql.append("	   , ''                           																														   ");
		sql.append("	 FROM  ((( BAS0102 E  RIGHT JOIN OUT1001 A ON   E.CODE  = A.JUBSU_GUBUN AND E.LANGUAGE = :language AND E.CODE_TYPE = 'JUBSU_GUBUN' AND E.HOSP_CODE     = A.HOSP_CODE )                  ");
		sql.append("	       LEFT JOIN OCS0503 C ON  C.HOSP_CODE  = A.HOSP_CODE AND C.CONSULT_FKOUT1001 = A.PKOUT1001 )                                                                                   ");
		sql.append("	    JOIN  BAS0270 D ON  D.HOSP_CODE             = A.HOSP_CODE    AND D.DOCTOR  = A.DOCTOR AND A.NAEWON_DATE BETWEEN D.START_DATE  AND D.END_DATE)                                   ");
		sql.append("	    JOIN OUT0101 B ON  B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO     = A.BUNHO                                                                                                          ");
		sql.append("	                                                                                                                                                                                    ");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                                                                  ");
		sql.append("	 AND A.NAEWON_DATE = :naewonDate                                                                                                                                                 ");
		sql.append("	 AND A.NAEWON_YN  IN ('Y', 'E', 'H')                                                                                                                                                ");
		sql.append("	 AND IF (A.NAEWON_YN IN ('E', 'H'),'Y','N') LIKE :naewonYn                                                                                                                       ");
		sql.append("	 AND IFNULL(A.RESER_YN, 'N') LIKE :reserYn                                                                                                                                       ");
		sql.append("	 AND (( :doctorModeYn = 'Y' AND ( A.DOCTOR   LIKE CONCAT('%',SUBSTR(:doctor, 3))                                                                                              ");
		sql.append("	                                 OR D.COMMON_DOCTOR_YN = 'Y'))                                                                                                                      ");
		sql.append("	     OR ( :doctorModeYn != 'Y' AND ( A.DOCTOR   LIKE CONCAT('%',SUBSTR(:doctor, 3)))))                                                                                        ");
		sql.append("	 AND A.BUNHO LIKE :bunho                                                                                                                                                          ");
		sql.append("	 AND ((:doctorModeYn = 'Y' AND IFNULL(E.GROUP_KEY, '0') = '1')                                                                                                                  ");
		sql.append("	        OR :doctorModeYn != 'Y')                                                                                                                                                ");
		sql.append("	ORDER BY IFNULL(A.ARRIVE_TIME, A.JUBSU_TIME), A.BUNHO, A.JUBSU_NO                                                                                                                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("naewonYn", naewonYn);
		query.setParameter("reserYn", reserYn);
		query.setParameter("doctorModeYn", doctorModeYn);
		query.setParameter("doctor", doctor);
		query.setParameter("bunho", bunho);

		List<OCS1003P01GrdPatientListItemInfo> list = new JpaResultMapper()
				.list(query, OCS1003P01GrdPatientListItemInfo.class);
		return list;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String callFnOcsGetNotapproveOrdercnt(String hospCode,
												 String ioGubun, String insteadYn, String approveYn,
												 String doctorId, String key) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OCS_GET_NOTAPPROVE_ORDERCNT(:hospCode, :ioGubun, :insteadYn, :approveYn, :doctorId, :key) ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("insteadYn", insteadYn);
		query.setParameter("approveYn", approveYn);
		query.setParameter("doctorId", doctorId);
		query.setParameter("key", key);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getOcsLibNaewonYNInfo1(String hospCode, String bunho,
										 Date naewonDate, Double pkout1001) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.NAEWON_YN 						 ");
		sql.append("	  FROM OUT1001 A                         ");
		sql.append("	 WHERE A.HOSP_CODE   = :hospCode         ");
		sql.append("	   AND A.BUNHO       = :bunho            ");
		sql.append("	   AND A.NAEWON_DATE = :naewonDate       ");
		sql.append("	   AND A.PKOUT1001   = :pkout1001        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("pkout1001", pkout1001);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getOcsLibNaewonYNInfo2(String hospCode, Double pkout1001) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.NAEWON_YN 					     ");
		sql.append("	 FROM OUT1001 A                          ");
		sql.append("	WHERE A.HOSP_CODE   = :hospCode          ");
		sql.append("	  AND A.PKOUT1001   = :pkout1001         ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkout1001", pkout1001);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}

	//fix bug MED-3820 remove doctor and naewon_date condition
	@Override
	public List<LoadPatientNaewonListInfo> getLoadPatientNaewonListItem(
			String hospcode, String language, String approveDoctor,
			String doctorModeYn, String ioGubun, String pkKeyOut, String bunho,
			String naewonDate, String gwa, String doctor, String jaewonFlag,
			String pkKeyInp, String isEnableIpwonReser) {
		StringBuilder sql = new StringBuilder();
		if (StringUtils.isEmpty(pkKeyOut)) {
			pkKeyOut = null;
		}

		if (StringUtils.isEmpty(pkKeyInp)) {
			pkKeyInp = null;
		}

		if (StringUtils.isEmpty(naewonDate)) {
			naewonDate = null;
		}
		sql.append("	SELECT 'O'                                                                        IOE_GUBUN,                                   	");
		sql.append("	       'OUT'                                                                       DATA_GUBUN,                                   ");
		sql.append("	       A.BUNHO                                                                   BUNHO,                                          ");
		sql.append("	       A.NAEWON_DATE                                                             NAEWON_DATE,                                    ");
		sql.append("	       A.GWA                                                                     GWA,                                            ");
		sql.append("	       A.DOCTOR                                                                  DOCTOR,                                         ");
		sql.append("	       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE,:hospcode)             DOCTOR_NAME,                                    	 ");
		sql.append("	       A.NAEWON_TYPE                                                             NAEWON_TYPE,                                    ");
		sql.append("	       A.JUBSU_NO                                                                JUBSU_NO,                                       ");
		sql.append("	       IFNULL(A.JUBSU_TIME,'0000')                                               JINRYO_TIME,                                    ");
		sql.append("	       A.PKOUT1001                                                               PK_KEY,                                         ");
		sql.append("	       A.RESER_YN                                                                RESER_DATA_YN,                                  ");
		sql.append("	       A.GUBUN                                                                   GUBUN,                                          ");
		sql.append("	       FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.NAEWON_DATE,:hospcode)               GUBUN_NAME,                                     	 ");
		sql.append("	       A.CHOJAE                                                                  CHOJAE,                                         ");
		sql.append("	       FN_BAS_LOAD_CODE_NAME('CHOJAE',A.CHOJAE,:hospcode,:language)         CHOJAE_NAME,                                    	 ");
		sql.append("	       'N'                      SPECIAL_YN,                                                                                      ");
		sql.append("	       IF(IFNULL(A.NAEWON_YN,'N') = 'Y' OR IFNULL(A.NAEWON_YN,'N') = 'E' OR IFNULL(A.NAEWON_YN,'N') = 'H','Y','N') NAEWON_YN,    ");
		sql.append("	       IFNULL(A.SUNNAB_YN,'N')                                                   SUNNAB_YN,                                      ");
		sql.append("	       ''                                                                       HO_DONG,                                         ");
		sql.append("	       ''                                                                       HO_CODE,                                         ");
		sql.append("	       'Y'                                                                       JAEWON_FLAG,                                    ");
		sql.append("	       'N'                                                                       IPWON_RESER_YN,                                 ");
		sql.append("	       A.NAEWON_YN                                                               REAL_NAEWON_YN                                 ");
		sql.append("	       , IF(:approveDoctor = '', CAST(' 'AS CHAR), :approveDoctor  )                                																			 ");
		sql.append("	FROM OUT1001 A,                                                                                                                  ");
		sql.append("		(SELECT D.GROUP_KEY, D.CODE, D.HOSP_CODE FROM BAS0102 D                                                                      ");
		sql.append("		 WHERE D.HOSP_CODE = :hospcode AND D.CODE_TYPE = 'JUBSU_GUBUN' AND D.LANGUAGE = :language) F                                 ");
		sql.append("	WHERE A.HOSP_CODE = :hospcode                                                                                                    ");
		sql.append("	AND F.HOSP_CODE = A.HOSP_CODE                                                                                                    ");
		sql.append("	AND F.CODE      = A.JUBSU_GUBUN                                                                                                  ");
		sql.append("	AND ( ( :doctorModeYn = 'Y' AND F.GROUP_KEY = '1') OR (:doctorModeYn != 'Y') )                                                   ");
		sql.append("	AND 'O' LIKE TRIM(:ioGubun)                                                                                                    	 ");
		sql.append("	AND ((:pkKeyOut IS NOT NULL AND A.PKOUT1001 = IFNULL(:pkKeyOut, '0'))                                                    		 ");
		sql.append("	    OR (:pkKeyOut IS NULL                                                                                                    	 ");
		sql.append("	    AND A.BUNHO = TRIM(:bunho)                                                                                                 	 ");
//		sql.append("	    AND ((TRIM(:naewonDate) IS NULL)                                                                                          	 ");
//		sql.append("	    OR (TRIM(:naewonDate) IS NOT NULL AND A.NAEWON_DATE = STR_TO_DATE(:naewonDate, '%Y/%m/%d')))                           		 ");
		sql.append("	    AND A.GWA LIKE TRIM(:gwa)))                                                                                                  ");
//		sql.append("	    AND A.DOCTOR LIKE TRIM(:doctor)))                                                                                          	 ");
		sql.append("	AND 'Y' LIKE TRIM(:jaewonFlag)                                                                                                	 ");
		//sql.append("	UNION ALL				                                                                                                         ");
		sql.append("	  UNION                                                                                                                               ");
		sql.append("	SELECT 'I'                  IOE_GUBUN,                                                                                           ");
		sql.append("	   'INP'                    DATA_GUBUN,                                                                                          ");
		sql.append("	   A.BUNHO                  BUNHO,                                                                                               ");
		sql.append("	   A.IPWON_DATE             NAEWON_DATE,                                                                                         ");
		sql.append("	   A.GWA                    GWA,                                                                                                 ");
		sql.append("	   A.DOCTOR                 DOCTOR,                                                                                              ");
		sql.append("	   FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE(),:hospcode) DOCTOR_NAME,                                                        	 ");
		sql.append("	   A.IPWON_TYPE             NAEWON_TYPE,                                                                                         ");
		sql.append("	   1                        JUBSU_NO,                                                                                            ");
		sql.append("	   IFNULL(A.IPWON_TIME,'0000') JINRYO_TIME,                                                                                      ");
		sql.append("	   A.PKINP1001              PK_KEY,                                                                                              ");
		sql.append("	   'Y'                      RESER_DATA_YN,                                                                                       ");
		sql.append("	   A.GUBUN                  GUBUN,                                                                                               ");
		sql.append("	   FN_BAS_LOAD_GUBUN_NAME(A.GUBUN,SYSDATE(),:hospcode)   GUBUN_NAME,                                                             ");
		sql.append("	   4                      CHOJAE,                                                                                                ");
		sql.append("	   FN_BAS_LOAD_CODE_NAME('CHOJAE','4',:hospcode, :language)   CHOJAE_NAME,                                                       ");
		sql.append("	   'N'                      SPECIAL_YN,                                                                                          ");
		sql.append("	   'Y'                      NAEWON_YN,                                                                                           ");
		sql.append("	   'Y'                      SUNNAB_YN,                                                                                           ");
		sql.append("	   A.HO_DONG1               HO_DONG,                                                                                             ");
		sql.append("	   A.HO_CODE1               HO_CODE,                                                                                             ");
		sql.append("	   IFNULL(A.JAEWON_FLAG, 'N')  JAEWON_FLAG,                                                                                      ");
		sql.append("	   A.IPWON_RESER_YN         IPWON_RESER_YN,                                                                                      ");
		sql.append("	   'N'                      REAL_NAEWON_YN                                                                                       ");
		sql.append("	   , IF(:approveDoctor = '', CAST(' 'AS CHAR), :approveDoctor  )   															     ");
		sql.append("	FROM VW_OCS_INP1001_RES_12 A                                                                                                     ");
		sql.append("		 ,(select @kcck_hosp_code\\:=:hospcode) TMP																				 ");
		sql.append("	WHERE 'I' LIKE RTRIM(:ioGubun)                                                                                                   ");
		sql.append("	AND ((:pkKeyInp IS NOT NULL AND A.PKINP1001 = IFNULL(:pkKeyInp, '0'))                                                        	 ");
		sql.append("		OR  (:pkKeyInp IS     NULL                                                                                                 ");
		sql.append("	AND   A.BUNHO           = RTRIM(:bunho)                                                                                        ");
//		sql.append("	AND   ((TRIM(:naewonDate) IS NULL)                                                                                             ");
//		sql.append("		OR (TRIM(:naewonDate) IS NOT NULL                                                                                          ");
//		sql.append("		AND A.IPWON_DATE <= STR_TO_DATE(:naewonDate, '%Y/%m/%d')) )                                                                ");
		sql.append("	AND   A.GWA             LIKE TRIM(:gwa)))                                                                                        ");
//		sql.append("	AND   A.DOCTOR          LIKE TRIM(:doctor)))                                                                                   ");
		sql.append("	AND A.JAEWON_FLAG     LIKE TRIM(:jaewonFlag)                                                                                   ");
		sql.append("	AND ( TRIM(:isEnableIpwonReser) = 'Y' OR ( TRIM(:isEnableIpwonReser) != 'Y' AND A.IPWON_RESER_YN = 'N' ))                    	 ");
		sql.append("	AND IFNULL(A.CANCEL_YN,'N') !='Y'                                                                                                ");
		sql.append("	ORDER BY 4 DESC, 1, 5, 10, 22                                                                                                    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospcode", hospcode);
		query.setParameter("language", language);
		query.setParameter("approveDoctor", approveDoctor);
		query.setParameter("doctorModeYn", doctorModeYn);
		query.setParameter("ioGubun", ioGubun + "%");
		query.setParameter("pkKeyOut", pkKeyOut);
		query.setParameter("bunho", bunho);
//		query.setParameter("naewonDate", naewonDate);
		query.setParameter("gwa", gwa);
//		query.setParameter("doctor", doctor);
		query.setParameter("jaewonFlag", jaewonFlag + "%");
		query.setParameter("pkKeyInp", pkKeyInp);
		query.setParameter("isEnableIpwonReser", isEnableIpwonReser);

		List<LoadPatientNaewonListInfo> listResult = new JpaResultMapper().list(query, LoadPatientNaewonListInfo.class);
		return listResult;
	}

	@Override
	@SuppressWarnings("unchecked")
	public Integer getOutTaGwaJinryoCnt(String hospCode, String bunho,
										String gwa, Date naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_LOAD_TA_GWA_JINRYO_CNT(:f_bunho, :f_naewon_date, :f_gwa, :f_hosp_code) ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_gwa", gwa);

		List<Integer> list = query.getResultList();
		if (list != null && list.size() > 0) {
			return list.get(0);
		}

		return null;
	}

	//fix bug MED-3820 remove doctor and naewon_date condition
	@Override
	public List<OcsoOCS1003P01LayPatInfo> getOcsoOCS1003P01LayPatInfo(
			String hospCode, String language, String doctor, String bunho,
			String naewonDate, String loginDoctorYn) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.GWA, A.BUNHO, A.DOCTOR, B.GROUP_KEY, A.NAEWON_YN                                  ");
		sql.append("     FROM OUT1001 A                                                                         ");
		sql.append("         ,BAS0102 B                                                                         ");
		sql.append("    WHERE A.HOSP_CODE         = :f_hosp_code                                                ");
//		sql.append("      AND SUBSTR(A.DOCTOR, 3) = SUBSTR(:f_doctor, 3)                                        ");
		sql.append("      AND A.BUNHO             = :f_bunho                                                    ");
//		sql.append("      AND A.NAEWON_DATE       = STR_TO_DATE(:f_naewon_date,'%Y/%m/%d')                      ");
		sql.append("      AND B.HOSP_CODE = A.HOSP_CODE                                                         ");
		sql.append("      AND B.CODE_TYPE = 'JUBSU_GUBUN'                                                       ");
		sql.append("      AND B.LANGUAGE = :f_language                                                          ");
		sql.append("      AND B.CODE      = A.JUBSU_GUBUN                                                       ");
		sql.append("      AND ((:f_login_doctor_yn = 'Y' AND B.GROUP_KEY = '1') OR (:f_login_doctor_yn = 'N'))  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
//		query.setParameter("f_doctor", doctor);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
//		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_login_doctor_yn", loginDoctorYn);

		List<OcsoOCS1003P01LayPatInfo> listResult = new JpaResultMapper().list(query, OcsoOCS1003P01LayPatInfo.class);
		return listResult;
	}

	@Override
	public List<OCS1003Q02GridOUT1001Info> getOCS1003Q02GridOUT1001(
			String hospCode, String language, Date naewonDate, String bunho,
			String gwa, String doctor, String naewonYn) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT case IFNULL(A.RESER_YN, 'N') when 'Y' then 'N' else 'Y' end      JUBSU,                            ");
		sql.append("        IFNULL(A.RESER_YN, 'N')                             RESER_YN,                                      ");
		sql.append("        A.JUBSU_TIME                                     JINRYO_TIME,                                      ");
		sql.append("        FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE,:f_hosp_code,:f_language)       GWA_NAME,                ");
		sql.append("        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE,:f_hosp_code) DOCTOR_NAME,                         ");
		sql.append("        FN_BAS_LOAD_CODE_NAME('NAEWON_YN', A.NAEWON_YN,:f_hosp_code,:f_language)  NAEWON_YN_NAME,          ");
		sql.append("        A.BUNHO                                          BUNHO,                                            ");
		sql.append("        A.NAEWON_DATE                                    NAEWON_DATE,                                      ");
		sql.append("        A.GWA                                            GWA,                                              ");
		sql.append("        A.DOCTOR                                         DOCTOR,                                           ");
		sql.append("        A.NAEWON_TYPE                                    NAEWON_TYPE,                                      ");
		sql.append("        A.JUBSU_NO                                       JUBSU_NO,                                         ");
		sql.append("        A.PKOUT1001                                      PK_NAEWON,                                        ");
		sql.append("        A.NAEWON_YN                                      ORDER_END_YN                                      ");
		sql.append("   FROM OUT0101 B,                                                                                         ");
		sql.append("        OUT1001 A                                                                                          ");
		sql.append("  WHERE A.HOSP_CODE     = :f_hosp_code                                                                     ");
		sql.append("    AND A.NAEWON_DATE   = :f_naewon_date                                                                   ");
		sql.append("    AND A.BUNHO         = :f_bunho                                                                         ");
		sql.append("    AND ( A.GWA <> :f_gwa OR A.DOCTOR <> :f_doctor )                                                       ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                                                      ");
		sql.append("    AND B.BUNHO         = A.BUNHO                                                                          ");
		sql.append("    AND (                                                                                                  ");
		sql.append("          ( :f_naewon_yn = '%' )                                                                           ");
		sql.append("          OR                                                                                               ");
		sql.append("          ( :f_naewon_yn = 'Y'                                                                             ");
		sql.append("            AND                                                                                            ");
		sql.append("            A.NAEWON_YN = 'E'  )                                                                           ");
		sql.append("          OR                                                                                               ");
		sql.append("          ( :f_naewon_yn = 'N'                                                                             ");
		sql.append("            AND                                                                                            ");
		sql.append("            A.NAEWON_YN != 'E' )                                                                           ");
		sql.append("        )                                                                                                  ");
		sql.append("  ORDER BY 3																								");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_naewon_yn", naewonYn);
		List<OCS1003Q02GridOUT1001Info> listResult = new JpaResultMapper()
				.list(query, OCS1003Q02GridOUT1001Info.class);
		return listResult;
	}

	@Override
	public List<OCS1003Q09GridOUT1001Info> getOCS1003Q09GridOUT1001ListItem(
			String hospCode, String language, String kijun, String inputGubun,
			String telYN, String inputTab, String ioGubun,
			String selectedInputTab, String bunho, Date naewonDate, String gwa) {
		StringBuilder sql = new StringBuilder();

		sql.append("	  SELECT																									");
		sql.append("	       IF(:f_kijun ='H', IFNULL(B.HOPE_DATE, IFNULL(B.RESER_DATE, B.ORDER_DATE)),                           ");
		sql.append("	                 B.ORDER_DATE)  ORDER_DATE,                                                                 ");
		sql.append("	         A.GWA GWA,                                                                                         ");
		sql.append("	         FN_BAS_LOAD_GWA_NAME (A.GWA, A.NAEWON_DATE,:f_hosp_code, :language) GWA_NAME,                                 ");
		sql.append("	         FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, A.NAEWON_DATE,:f_hosp_code) DOCTOR_NAME,                        ");
		sql.append("	         0 NALSU,                                                                                           ");
		sql.append("	         A.BUNHO BUNHO,                                                                                     ");
		sql.append("	         A.DOCTOR DOCTOR,                                                                                   ");
		sql.append("	         FN_BAS_LOAD_GUBUN_NAME (A.GUBUN, A.NAEWON_DATE,:f_hosp_code) GUBUN_NAME,                           ");
		sql.append("	         FN_BAS_LOAD_CODE_NAME ('CHOJAE', A.CHOJAE,:f_hosp_code , :language) CHOJAE_NAME,                   ");
		sql.append("	         A.NAEWON_TYPE NAEWON_TYPE,                                                                         ");
		sql.append("	         A.JUBSU_NO JUBSU_NO,                                                                               ");
		sql.append("	         A.PKOUT1001 PK_ORDER,                                                                              ");
		sql.append("	         TRIM(SUBSTR(:f_input_gubun,1, 10)) INPUT_GUBUN,                                                    ");
		sql.append("	         :f_tel_yn TEL_YN,                                                                                  ");
		sql.append("	         'N' TOIWON_DRG,                                                                                    ");
		sql.append("	         :f_input_tab INPUT_TAB,                                                                            ");
		sql.append("	         :f_io_gubun IO_GUBUN,                                                                              ");
		sql.append("	         IF (:f_selected_input_tab ='%', 'Y',                                                               ");
		sql.append("	             FN_OCS_DO_ORDER_COUNT (:f_hosp_code,                                                           ");
		sql.append("	                                  'O',                                                                      ");
		sql.append("	                                  :f_bunho,                                                                 ");
		sql.append("	                                  A.PKOUT1001,                                                              ");
		sql.append("	                                  A.DOCTOR,                                                                 ");
		sql.append("	                                  :f_selected_input_tab,                                                    ");
		sql.append("	                                  :f_input_gubun,                                                           ");
		sql.append("	                                  :f_kijun,                                                                 ");
		sql.append("	                                  A.NAEWON_DATE)) OCS_CNT                                                   ");
		sql.append("	                                                                                                            ");
		sql.append("	    FROM OUT1001 A, OCS1003 B                                                                               ");
		sql.append("	   WHERE     :f_io_gubun = 'O'                                                                              ");
		sql.append("	         AND A.HOSP_CODE = :f_hosp_code                                                                     ");
		sql.append("	         AND A.BUNHO = :f_bunho                                                                             ");
		sql.append("	         AND A.NAEWON_DATE <= :f_naewon_date                                                                ");
		sql.append("	         AND A.GWA LIKE :f_gwa                                                                              ");
		sql.append("	         AND EXISTS                                                                                         ");
		sql.append("	                (SELECT 'X'                                                                                 ");
		sql.append("	                   FROM OCS0140 C, OCS1003 B                                                                ");
		sql.append("	                  WHERE     B.BUNHO = A.BUNHO                                                               ");
		sql.append("	                        AND B.FKOUT1001 = A.PKOUT1001                                                       ");
		sql.append("	                        AND B.HOSP_CODE = A.HOSP_CODE                                                       ");
		sql.append("	                        AND IFNULL(B.TEL_YN, 'N') LIKE :f_tel_yn                                            ");
		sql.append("	                        AND IFNULL(B.DISPLAY_YN, 'Y') = 'Y'                                                 ");
		sql.append("	                        AND IFNULL(B.DC_YN, 'N') = 'N'                                                      ");
		sql.append("	                        AND B.NALSU >= 0                                                                    ");
		sql.append("	                        AND B.INPUT_TAB LIKE :f_input_tab                                                   ");
		sql.append("	                        AND ( (:f_input_gubun LIKE 'D%'                                                     ");
		sql.append("	                               AND B.INPUT_GUBUN LIKE 'D%')                                                 ");
		sql.append("	                             OR (:f_input_gubun = 'NR'                                                      ");
		sql.append("	                                 AND (B.INPUT_GUBUN LIKE 'D%'                                               ");
		sql.append("	                                      OR B.INPUT_GUBUN = 'NR'))                                             ");
		sql.append("	                             OR (:f_input_gubun NOT IN ('D%', 'NR')                                         ");
		sql.append("	                                 AND (B.INPUT_GUBUN LIKE 'D%'                                               ");
		sql.append("	                                      OR B.INPUT_GUBUN = :f_input_gubun)))                                  ");
		sql.append("	                        AND C.ORDER_GUBUN = B.ORDER_GUBUN                                                   ");
		sql.append("	                        AND C.HOSP_CODE = B.HOSP_CODE                                                       ");
		sql.append("	                        AND C.INPUT_TAB = B.INPUT_TAB                                                       ");
		sql.append("	                        LIMIT 1)                                                                            ");
		sql.append("	         AND B.HOSP_CODE = A.HOSP_CODE                                                                      ");
		sql.append("	         AND B.FKOUT1001 = A.PKOUT1001                                                                      ");
		sql.append("	GROUP BY IF (:f_kijun ='H',                                                                                 ");
		sql.append("	          IFNULL(B.HOPE_DATE, IFNULL(B.RESER_DATE, B.ORDER_DATE)),                                          ");
		sql.append("	                 B.ORDER_DATE),                                                                             ");
		sql.append("	                 A.GWA,                                                                                     ");
		sql.append("	         FN_BAS_LOAD_GWA_NAME (A.GWA, A.NAEWON_DATE,:f_hosp_code, :language),                               ");
		sql.append("	         FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, A.NAEWON_DATE,:f_hosp_code),                                    ");
		sql.append("	         NALSU,                                                                                             ");
		sql.append("	         A.BUNHO,                                                                                           ");
		sql.append("	         A.DOCTOR,                                                                                          ");
		sql.append("	         FN_BAS_LOAD_GUBUN_NAME (A.GUBUN, A.NAEWON_DATE,:f_hosp_code),                                      ");
		sql.append("	         FN_BAS_LOAD_CODE_NAME ('CHOJAE', A.CHOJAE,:f_hosp_code , :language),                               ");
		sql.append("	         A.NAEWON_TYPE,                                                                                     ");
		sql.append("	         A.JUBSU_NO,                                                                                        ");
		sql.append("	         A.PKOUT1001,                                                                                       ");
		sql.append("	         TRIM(SUBSTR(:f_input_gubun,1,10)),                                                                 ");
		sql.append("	         :f_tel_yn,                                                                                         ");
		sql.append("	         'N',                                                                                               ");
		sql.append("	         :f_input_tab,                                                                                      ");
		sql.append("	         :f_io_gubun,                                                                                       ");
		sql.append("	         IF (:f_selected_input_tab='%', 'Y',                                                                ");
		sql.append("	                 FN_OCS_DO_ORDER_COUNT (:f_hosp_code,                                                       ");
		sql.append("	                                        'O',                                                                ");
		sql.append("	                                        :f_bunho,                                                           ");
		sql.append("	                                        A.PKOUT1001,                                                        ");
		sql.append("	                                        A.DOCTOR,                                                           ");
		sql.append("	                                        :f_selected_input_tab,                                              ");
		sql.append("	                                        :f_input_gubun,                                                     ");
		sql.append("	                                        :f_kijun,                                                           ");
		sql.append("	                                        A.NAEWON_DATE))                                                     ");
		sql.append("	UNION ALL                                                                                                   ");
		sql.append("	  SELECT IF(:f_kijun = 'H', IFNULL(A.HOPE_DATE,                                                             ");
		sql.append("	          IFNULL(A.RESER_DATE, A.ORDER_DATE)),A.ORDER_DATE)                                                 ");
		sql.append("	            ORDER_DATE,                                                                                     ");
		sql.append("	         A.INPUT_GWA GWA,                                                                                   ");
		sql.append("	         FN_BAS_LOAD_GWA_NAME (A.INPUT_GWA, A.ORDER_DATE,:f_hosp_code, :language) GWA_NAME,                 ");
		sql.append("	         FN_BAS_LOAD_DOCTOR_NAME (A.INPUT_DOCTOR, A.ORDER_DATE,:f_hosp_code) DOCTOR_NAME,                   ");
		sql.append("	         0 NALSU,                                                                                           ");
		sql.append("	         A.BUNHO BUNHO,                                                                                     ");
		sql.append("	         A.INPUT_DOCTOR DOCTOR,                                                                             ");
		sql.append("	         ' ' GUBUN_NAME,                                                                                    ");
		sql.append("	         ' ' CHOJAE_NAME,                                                                                   ");
		sql.append("	         '0' NAEWON_TYPE,                                                                                   ");
		sql.append("	         A.FKINP1001 JUBSU_NO,                                                                              ");
		sql.append("	         A.FKINP1001 PK_ORDER,                                                                              ");
		sql.append("	         TRIM(SUBSTR(:f_input_gubun,1, 10)) INPUT_GUBUN,                                                    ");
		sql.append("	         :f_tel_yn TEL_YN,                                                                                  ");
		sql.append("	         FN_OCS_EXISTS_TOIWON_DRG (A.BUNHO, A.FKINP1001, A.ORDER_DATE, :f_hosp_code)                        ");
		sql.append("	            TOIWON_DRG,                                                                                     ");
		sql.append("	         :f_input_tab INPUT_TAB,                                                                            ");
		sql.append("	         :f_io_gubun IO_GUBUN,                                                                              ");
		sql.append("	         IF (                                                                                               ");
		sql.append("	            :f_selected_input_tab = '%', 'Y',                                                               ");
		sql.append("	            FN_OCS_DO_ORDER_COUNT (                                                                         ");
		sql.append("	               :f_hosp_code,                                                                                ");
		sql.append("	               'I',                                                                                         ");
		sql.append("	               :f_bunho,                                                                                    ");
		sql.append("	               A.FKINP1001,                                                                                 ");
		sql.append("	               A.INPUT_DOCTOR,                                                                              ");
		sql.append("	               :f_selected_input_tab,                                                                       ");
		sql.append("	               :f_input_gubun,                                                                              ");
		sql.append("	               :f_kijun,                                                                                    ");
		sql.append("	               IF (                                                                                         ");
		sql.append("	                  :f_kijun ='H',                                                                            ");
		sql.append("	                  IFNULL(A.HOPE_DATE, IFNULL(A.RESER_DATE, A.ORDER_DATE)),                                  ");
		sql.append("	                  A.ORDER_DATE)))  OCS_CNT                                                                  ");
		sql.append("	    FROM OCS0140 B, OCS2003 A                                                                               ");
		sql.append("	   WHERE     :f_io_gubun = 'I'                                                                              ");
		sql.append("	         AND A.HOSP_CODE = :f_hosp_code                                                                     ");
		sql.append("	         AND A.IO_GUBUN IS NULL                                                                             ");
		sql.append("	         AND A.BUNHO = :f_bunho                                                                             ");
		sql.append("	         AND A.ORDER_DATE <= :f_naewon_date                                                                 ");
		sql.append("	         AND A.INPUT_GWA LIKE :f_gwa                                                                        ");
		sql.append("	         AND ( (:f_input_gubun LIKE 'D%' AND A.INPUT_GUBUN LIKE 'D%')                                       ");
		sql.append("	              OR (:f_input_gubun = 'NR'                                                                     ");
		sql.append("	                  AND (A.INPUT_GUBUN LIKE 'D%' OR A.INPUT_GUBUN = 'NR'))                                    ");
		sql.append("	              OR ( (:f_input_gubun NOT LIKE 'D%' AND :f_input_gubun != 'NR')                                ");
		sql.append("	                  AND (A.INPUT_GUBUN LIKE 'D%'                                                              ");
		sql.append("	                       OR A.INPUT_GUBUN = :f_input_gubun)))                                                 ");
		sql.append("	         AND A.NALSU >= 0                                                                                   ");
		sql.append("	         AND IFNULL(A.DISPLAY_YN, 'Y') = 'Y'                                                                ");
		sql.append("	         AND IFNULL(A.DC_YN, 'N') = 'N'                                                                     ");
		sql.append("	         AND B.ORDER_GUBUN = A.ORDER_GUBUN                                                                  ");
		sql.append("	         AND B.HOSP_CODE = A.HOSP_CODE                                                                      ");
		sql.append("	         AND B.INPUT_TAB = A.INPUT_TAB                                                                      ");
		sql.append("	      GROUP BY IF(:f_kijun = 'H', IFNULL(A.HOPE_DATE,                                                      	");
		sql.append("	      	          IFNULL(A.RESER_DATE, A.ORDER_DATE)),A.ORDER_DATE),                                        ");
		sql.append("	      	         A.INPUT_GWA,                                                                               ");
		sql.append("	      	         FN_BAS_LOAD_GWA_NAME (A.INPUT_GWA, A.ORDER_DATE,:f_hosp_code, :language),                 	");
		sql.append("	      	         FN_BAS_LOAD_DOCTOR_NAME (A.INPUT_DOCTOR, A.ORDER_DATE,:f_hosp_code),                       ");
		sql.append("	      	         NALSU,                                                                                     ");
		sql.append("	      	         A.BUNHO,                                                                                   ");
		sql.append("	      	         A.INPUT_DOCTOR,                                                                            ");
		sql.append("	      	         GUBUN_NAME,                                                                                ");
		sql.append("	      	         CHOJAE_NAME,                                                                               ");
		sql.append("	      	         NAEWON_TYPE,                                                                               ");
		sql.append("	      	         A.FKINP1001,                                                                               ");
		sql.append("	      	         A.FKINP1001,                                                                               ");
		sql.append("	      	         TRIM(SUBSTR(:f_input_gubun,1, 10)),                                                        ");
		sql.append("	      	         :f_tel_yn,                                                                                 ");
		sql.append("	      	         FN_OCS_EXISTS_TOIWON_DRG (A.BUNHO, A.FKINP1001, A.ORDER_DATE, :f_hosp_code),               ");
		sql.append("	      	         :f_input_tab,                                                                              ");
		sql.append("	      	         :f_io_gubun,                                                                               ");
		sql.append("	      	         IF (                                                                                       ");
		sql.append("	      	            :f_selected_input_tab = '%', 'Y',                                                       ");
		sql.append("	      	            FN_OCS_DO_ORDER_COUNT (                                                                 ");
		sql.append("	      	               :f_hosp_code,                                                                        ");
		sql.append("	      	               'I',                                                                                 ");
		sql.append("	      	               :f_bunho,                                                                            ");
		sql.append("	      	               A.FKINP1001,                                                                         ");
		sql.append("	      	               A.INPUT_DOCTOR,                                                                      ");
		sql.append("	      	               :f_selected_input_tab,                                                               ");
		sql.append("	      	               :f_input_gubun,                                                                      ");
		sql.append("	      	               :f_kijun,                                                                            ");
		sql.append("	      	               IF (                                                                                 ");
		sql.append("	      	                  :f_kijun ='H',                                                                    ");
		sql.append("	      	                  IFNULL(A.HOPE_DATE, IFNULL(A.RESER_DATE, A.ORDER_DATE)),                          ");
		sql.append("	      	                  A.ORDER_DATE)))        															");
		sql.append("	      	                  ORDER BY 1 DESC, 12 DESC         													");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_kijun", kijun);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_tel_yn", telYN);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_selected_input_tab", selectedInputTab);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_naewon_date", naewonDate);

		List<OCS1003Q09GridOUT1001Info> list = new JpaResultMapper().list(
				query, OCS1003Q09GridOUT1001Info.class);
		return list;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<String> getReserMoveName(String hospCode, String language, String bunho, Date reserDate, String gwa) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_GWA_POSITION(A.GWA,SYSDATE(), :hospCode, :language ) RESER_MOVE_NAME ");
		sql.append("  FROM OUT1001 A                                                            ");
		sql.append(" WHERE A.HOSP_CODE   = :hospCode                 	                 	    ");
		sql.append("   AND A.BUNHO       = :bunho                                               ");
		sql.append("   AND A.NAEWON_DATE = :reserDate                                 	        ");
		sql.append("   AND A.GWA         = :gwa                                    	            ");
		sql.append("   AND A.RESER_YN    = 'Y'                                                  ");
		sql.append("     LIMIT         1                                                        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		query.setParameter("reserDate", reserDate);
		query.setParameter("gwa", gwa);

		return query.getResultList();
	}

	@Override
	public String callPrOutChangeGwaDoctor(String hospCode, String bunho, String pkout1001, String toGwa, String toDoctor, String userId) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_OUT_CHANGE_GWA_DOCTOR");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOUT1001", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERROR", String.class, ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_PKOUT1001", pkout1001);
		query.setParameter("I_TO_GWA", toGwa);
		query.setParameter("I_TO_DOCTOR", toDoctor);
		query.setParameter("I_USER_ID", userId);

		String result = (String) query.getOutputParameterValue("IO_ERROR");
		return result;
	}

	@Override
	public PHY2001U04PrOutMakeAutoJubsuInfo callPrOutMakeAutoJubsuInfo(String hospCode,Double iSourcePkKey, String iGwa, String iDoctor,
																	   String iJubsuGubun, String iUserId) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_OUT_MAKE_AUTO_JUBSU");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SOURCE_PKKEY", Double.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GWA", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_GUBUN", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_NEW_PKOUT1001", Double.class,ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class,ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SOURCE_PKKEY", iSourcePkKey);
		query.setParameter("I_GWA", iGwa);
		query.setParameter("I_DOCTOR", iDoctor);
		query.setParameter("I_JUBSU_GUBUN", iJubsuGubun);
		query.setParameter("I_USER_ID", iUserId);

		query.execute();
		PHY2001U04PrOutMakeAutoJubsuInfo result = new PHY2001U04PrOutMakeAutoJubsuInfo();
		result.setIoNewPkout1001((Double) query.getOutputParameterValue("IO_NEW_PKOUT1001"));
		result.setIoErr((String) query.getOutputParameterValue("IO_ERR"));
		return result;
	}

	@Override
	public List<PHY2001U04BtnDeleteGetDataTableInfo> getPHY2001U04DeleteClickInfo(String hospCode,String language, String bunho, Double pkOut1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PKOUT1001, B.PKOCS1003, B.HANGMOG_CODE, C.VALUE_POINT SINRYOURYOU_GUBUN, B.SUNAB_DATE       ");
		sql.append("   FROM OUT1001 A                                                                                     ");
		sql.append("       ,OCS1003 B                                                                                     ");
		sql.append("       ,OCS0132 C                                                                                     ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                  ");
		sql.append("    AND A.BUNHO       = :f_bunho                                                                      ");
		sql.append("    AND A.PKOUT1001   = :f_pkout1001                                                                  ");
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                                   ");
		sql.append("    AND B.FKOUT1001   = A.PKOUT1001                                                                   ");
		sql.append("    AND C.HOSP_CODE   = B.HOSP_CODE                                                                   ");
		sql.append("    AND C.CODE_TYPE   = 'REHA_SINRYOURYOU'                                                            ");
		sql.append("    AND C.CODE_NAME   = B.HANGMOG_CODE                                                                ");
		sql.append("    AND C.LANGUAGE    = :f_language																	  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkout1001", pkOut1001);
		List<PHY2001U04BtnDeleteGetDataTableInfo> list = new JpaResultMapper().list(query, PHY2001U04BtnDeleteGetDataTableInfo.class);
		return list;
	}

	@Override
	public String callFnPhyDupJubsuGubun(String hospCode, String jubsuGubun,String bunho, String gwa, Date naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_PHY_DUP_JUBSU_GUBUN(:f_jubsu_gubun, :f_bunho, :f_gwa, :f_naewon_date, :f_hosp_code )");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jubsu_gubun", jubsuGubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_naewon_date", naewonDate);
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<PHY2001U04GrdPaCntInfo> getPHY2001U04GrdPaCntInfo(String hospCode, String language, Date naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA                                            GWA                                                ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :f_hosp_code, :f_langauge)       GWA_NAME                ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :f_hosp_code) DOCTOR_NAME                          ");
		sql.append("      , COUNT(1)                                         PA_CNT                                             ");
		sql.append("   FROM OUT1001 A                                                                                           ");
		sql.append("      , BAS0102 B                                                                                           ");
		sql.append("  WHERE A.HOSP_CODE            = :f_hosp_code                                                               ");
		sql.append("    AND A.NAEWON_DATE          = :f_naewon_date                                                             ");
		sql.append("    AND IFNULL(A.NAEWON_YN, 'N')  <> 'N'                                                                    ");
		sql.append("    AND IFNULL(A.NAEWON_YN, 'N')  <> 'E'                                                                    ");
		sql.append("    AND A.JUBSU_GUBUN          = B.CODE                                                                     ");
		sql.append("    AND B.CODE_TYPE            = 'JUBSU_GUBUN'                                                              ");
		sql.append("    AND B.GROUP_KEY            IN ('1','2')                                                                 ");
		sql.append("    AND B.LANGUAGE     = :f_langauge                                                                        ");
		sql.append("  GROUP BY A.NAEWON_DATE, A.GWA,  A.DOCTOR                                                                  ");
		sql.append("  ORDER BY  substr(A.DOCTOR,3) ,A.GWA, A.DOCTOR																");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_langauge", language);
		query.setParameter("f_naewon_date", naewonDate);

		List<PHY2001U04GrdPaCntInfo> list = new JpaResultMapper().list(query, PHY2001U04GrdPaCntInfo.class);
		return list;
	}

	@Override
	public List<PHY2001U04RefreshCounterInfo> getPHY2001U04RefreshCounterInfo(String hospCode, String gwa, Date naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CNT G1, B.CNT G2, C.CNT SA, D.CNT RE    ");
		sql.append("  FROM (SELECT count(*) CNT                       ");
		sql.append("        FROM OUT1001 A                            ");
		sql.append("       WHERE A.HOSP_CODE   = :f_hosp_code         ");
		sql.append("         AND A.GWA         = :f_gwa               ");
		sql.append("         AND A.JUBSU_GUBUN = '20'                 ");
		sql.append("         AND A.NAEWON_DATE = :f_naewon_date) A,   ");
		sql.append("     (SELECT count(*) CNT                         ");
		sql.append("        FROM OUT1001 A                            ");
		sql.append("       WHERE A.HOSP_CODE   = :f_hosp_code         ");
		sql.append("         AND A.GWA         = :f_gwa               ");
		sql.append("         AND A.JUBSU_GUBUN = '21'                 ");
		sql.append("         AND A.NAEWON_DATE = :f_naewon_date) B,   ");
		sql.append("     (SELECT count(*) CNT                         ");
		sql.append("        FROM OUT1001 A                            ");
		sql.append("       WHERE A.HOSP_CODE   = :f_hosp_code         ");
		sql.append("         AND A.GWA         = :f_gwa               ");
		sql.append("         AND A.JUBSU_GUBUN = '22'                 ");
		sql.append("         AND A.NAEWON_DATE = :f_naewon_date) C,   ");
		sql.append("     (SELECT count(*) CNT                         ");
		sql.append("        FROM OUT1001 A                            ");
		sql.append("       WHERE A.HOSP_CODE   = :f_hosp_code         ");
		sql.append("         AND A.GWA         = :f_gwa               ");
		sql.append("         AND A.JUBSU_GUBUN = '10'                 ");
		sql.append("         AND A.NAEWON_DATE = :f_naewon_date) D    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_naewon_date", naewonDate);
		List<PHY2001U04RefreshCounterInfo> list = new JpaResultMapper().list(query, PHY2001U04RefreshCounterInfo.class);
		return list;
	}

	@Override
	public List<PHY2001U04GrdOut1001Info> getPHY2001U04GrdOut1001Info(String hospCode, String language, String gwa, String bunho,Date naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                                                                                       "  );
		sql.append("       ,CONCAT(IFNULL(DATE_FORMAT(A.NAEWON_DATE, '%m/%d'), '') , ' (' , IFNULL(CASE DAYOFWEEK(A.NAEWON_DATE)                          "  );
		sql.append("                                           WHEN  '1' THEN  FN_ADM_MSG('1135',:f_language)                                             "  );
		sql.append("                                           WHEN  '2' THEN  FN_ADM_MSG('1136',:f_language)                                             "  );
		sql.append("                                           WHEN  '3' THEN  FN_ADM_MSG('1137',:f_language)                                             "  );
		sql.append("                                           WHEN  '4' THEN  FN_ADM_MSG('1138',:f_language)                                             "  );
		sql.append("                                           WHEN  '5' THEN  FN_ADM_MSG('1139',:f_language)                                             "  );
		sql.append("                                           WHEN  '6' THEN  FN_ADM_MSG('1140',:f_language)                                             "  );
		sql.append("                                           WHEN  '7' THEN  FN_ADM_MSG('1141',:f_language)                                             "  );
		sql.append("                                           END, '') , ')') NAEWON_DATE                                                                "  );
		sql.append("       ,A.JUBSU_GUBUN                                                                                                                 "  );
		sql.append("       ,CASE A.JUBSU_GUBUN WHEN  '20' THEN  CONCAT(IFNULL(DATE_FORMAT(A.NAEWON_DATE + 7,  '%m/%d'), '') , ' (外1)')                   "  );
		sql.append("                             WHEN  '21' THEN  CONCAT(IFNULL(DATE_FORMAT(A.NAEWON_DATE + 14, '%m/%d'), '') , ' (外2)') END NEXT        "  );
		sql.append("   FROM OUT1001 A                                                                                                                     "  );
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                                    "  );
		sql.append("   AND A.GWA       = :f_gwa                                                                                                           "  );
		sql.append("    AND A.BUNHO     = :f_bunho                                                                                                        "  );
		sql.append("    AND A.NAEWON_DATE != :f_naewon_date                                                                                               "  );
		sql.append("    AND A.NAEWON_DATE >= '2013/02/22'                                                                                                 "  );
		sql.append("  ORDER BY A.NAEWON_DATE DESC, A.BUNHO, A.JUBSU_GUBUN																					");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);
		List<PHY2001U04GrdOut1001Info> list = new JpaResultMapper().list(query, PHY2001U04GrdOut1001Info.class);
		return list;
	}

	@Override
	public List<PHY2001U04GrdPatientListInfo> getPHY2001U04GrdPatientListInfo(
			String hospCode, String language, String naewonDate, String gwa,
			String doctor, String bunho, String jubsuGubun, String jinryoYn,
			String naewonYn, String userId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA                                                                       GWA                                         ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :f_hosp_code, :f_language)       GWA_NAME                                     ");
		sql.append("     , A.BUNHO                                                                     BUNHO                                        ");
		sql.append("     , B.SUNAME                                                                    SUNAME                                       ");
		sql.append("     , B.SUNAME2                                                                   SUNAME2                                      ");
		sql.append("     , A.NAEWON_DATE                                                               NAEWON_DATE                                  ");
		sql.append("     , A.DOCTOR                                                                    DOCTOR                                       ");
		sql.append("     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :f_hosp_code)              DOCTOR_NAME                                  ");
		sql.append("     , A.NAEWON_TYPE                                                               NAEWON_TYPE                                  ");
		sql.append("     , A.JUBSU_NO                                                                  JUBSU_NO                                     ");
		sql.append("     , B.BIRTH                                                                     BIRTH                                        ");
		sql.append("     , CONCAT(IFNULL(FN_BAS_LOAD_AGE(A.NAEWON_DATE,B.BIRTH,''),''),' / ',IFNULL(B.SEX,'') )              AGE_SEX                ");
		sql.append("     , A.PKOUT1001                                                                 OUT_RES_KEY                                  ");
		sql.append("     , A.JUBSU_TIME                                                                JUBSU_TIME                                   ");
		sql.append("     ,case IFNULL(NAEWON_YN, 'N') when 'E' then  'Y' else 'N' end                  ORDER_END_YN                                 ");
		sql.append("     ,case A.NAEWON_YN when 'H' then 'Y' else 'N' end                              HOLD_YN                                      ");
		sql.append("     , ''                                                                          RESULT_YN                                    ");
		sql.append("     , RESER_YN                                                                    RESER_YN                                     ");
		sql.append("     , 'N'                                                                         IPWON_YN                                     ");
		sql.append("     , FN_OUT_LOAD_SUNAB_CHECK_YN(A.PKOUT1001, A.NAEWON_DATE, :f_hosp_code)        SUNAB_YN                                     ");
		sql.append("     , case IFNULL(NAEWON_YN, 'N') when 'N' then 'N' else  'Y' end                 NAEWON_YN                                    ");
		sql.append("     , A.JUBSU_GUBUN                                                               JUBSU_GUBUN                                  ");
		sql.append("     , C.CODE_NAME                                                                 JUBSU_GUBUN_NAME                             ");
		sql.append("     , C.REMARK                                                                    REMARK                                       ");
		sql.append("     , A.ARRIVE_TIME                                                               ARRIVE_TIME                                  ");
		sql.append("     , A.GUBUN                                                                     GUBUN                                        ");
		sql.append("     , FN_OUT_LOAD_LAST_NAEWON_DATE(A.BUNHO, '%', :f_hosp_code)                    LAST_NAEWON_DATE                             ");
		sql.append("     , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO, :f_hosp_code)                          OCS_COMMENT                                  ");
		sql.append("     , A.CHOJAE                                                                    CHOJAE                                       ");
		sql.append("     , C.GROUP_KEY                                                                 GROUP_KEY                                    ");
		sql.append("     , B.BUNHO_TYPE                                                                BUNHO_TYPE                                   ");
		sql.append("     , D.KAIGO_YN                                                                  KAIGO_YN                                     ");
		sql.append("     , D.GAEIN                                                                     GAEIN                                        ");
		sql.append("     , E.BP_TO                                                                                                                  ");
		sql.append("     , E.BP_FROM                                                                                                                ");
		sql.append("     , E.PULSE                                                                                                                  ");
		sql.append("     , E.BODY_HEAT                                                                                                              ");
		sql.append("  FROM ( OUT1001 A LEFT JOIN (SELECT X.HOSP_CODE, X.BUNHO, 'Y' KAIGO_YN, X.GAEIN                                                ");
		sql.append("          FROM OUT0102 X                                                                                                        ");
		sql.append("         WHERE X.HOSP_CODE = :f_hosp_code                                                                                       ");
		sql.append("           AND X.GUBUN = '70'                                                                                                   ");
		sql.append("           AND X.START_DATE = (SELECT MAX(Y.START_DATE)                                                                         ");
		sql.append("                                 FROM OUT0102 Y                                                                                 ");
		sql.append("                                WHERE Y.HOSP_CODE = X.HOSP_CODE                                                                 ");
		sql.append("                                  AND Y.GUBUN     = X.GUBUN                                                                     ");
		sql.append("                                  AND STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')  BETWEEN X.START_DATE                             ");
		sql.append("                                                         AND X.END_DATE)                                                        ");
		sql.append("         GROUP BY X.HOSP_CODE, X.BUNHO, X.GAEIN, X.START_DATE                                                                   ");
		sql.append("        HAVING X.START_DATE = MAX(X.START_DATE)) D ON   D.HOSP_CODE = A.HOSP_CODE AND D.BUNHO = A.BUNHO  )                      ");
		sql.append("        LEFT JOIN ( SELECT * FROM NUR7001 EA                                                                                    ");
		sql.append("          WHERE EA.HOSP_CODE = :f_hosp_code                                                                                     ");
		sql.append("            AND EA.MEASURE_DATE = STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')                                                       ");
		sql.append("            AND EA.SEQ = (SELECT MAX(EB.SEQ) FROM NUR7001 EB                                                                    ");
		sql.append("                           WHERE EB.HOSP_CODE    = :f_hosp_code                                                                 ");
		sql.append("                             AND EB.BUNHO        = EA.BUNHO                                                                     ");
		sql.append("                             AND EB.MEASURE_DATE = STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')                                      ");
		sql.append("                             AND EB.VALD         = 'Y')) E ON E.HOSP_CODE = A.HOSP_CODE                                         ");
		sql.append("                             AND E.BUNHO  = A.BUNHO AND E.MEASURE_DATE = STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')                ");
		sql.append("     , OUT0101 B                                                                                                                ");
		sql.append("     , BAS0102 C                                                                                                                ");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                                                                                             ");
		sql.append("   AND B.HOSP_CODE   = A.HOSP_CODE                                                                                              ");
		sql.append("   AND C.HOSP_CODE   = A.HOSP_CODE                                                                                              ");
		sql.append("   AND C.LANGUAGE    = :f_language                                                                                              ");
		sql.append("   AND A.NAEWON_DATE = STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')                                                                  ");
		sql.append("   AND A.GWA         LIKE :f_gwa                                                                                                ");
		sql.append("   AND A.DOCTOR      LIKE :f_doctor                                                                                             ");
		sql.append("   AND A.BUNHO       LIKE :f_bunho                                                                                              ");
		sql.append("   AND A.BUNHO       = B.BUNHO                                                                                                  ");
		sql.append("   AND C.CODE_TYPE   = 'JUBSU_GUBUN'                                                                                            ");
		sql.append("   AND A.JUBSU_GUBUN = C.CODE                                                                                                   ");
		sql.append("   AND (                                                                                                                        ");
		sql.append("        (:f_jubsu_gubun = '88' AND A.JUBSU_GUBUN IN ('20','21','22'))                                                           ");
		sql.append("        OR (:f_jubsu_gubun != '88' AND A.JUBSU_GUBUN LIKE :f_jubsu_gubun)                                                       ");
		sql.append("       )                                                                                                                        ");
		sql.append("                                                                                                                                ");
		sql.append("   AND ((:f_jinryo_yn = 'ALL' AND 1 = 1 ) OR                                                                                    ");
		sql.append("        (:f_jinryo_yn = 'Y' AND IFNULL(NAEWON_YN, 'N')  = 'E') OR                                                               ");
		sql.append("        (:f_jinryo_yn = 'N' AND IFNULL(NAEWON_YN, 'N') != 'E'))                                                                 ");
		sql.append("   AND ((:f_naewon_yn = 'ALL' AND 1 = 1 ) OR                                                                                    ");
		sql.append("        (:f_naewon_yn = 'Y' AND IFNULL(NAEWON_YN, 'N') != 'N') OR                                                               ");
		sql.append("        (:f_naewon_yn = 'N' AND IFNULL(NAEWON_YN, 'N')  = 'N'))																	");
		if("NURO".equalsIgnoreCase(userId)){
			sql.append("        ORDER BY A.JUBSU_TIME, A.ARRIVE_TIME ,A.BUNHO, A.JUBSU_NO														   	");
		}else{
			sql.append("        ORDER BY A.JUBSU_TIME DESC, A.ARRIVE_TIME DESC, A.BUNHO, A.JUBSU_NO											   	");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_gwa", gwa + "%");
		query.setParameter("f_doctor", doctor + "%");
		query.setParameter("f_bunho", bunho + "%");
		query.setParameter("f_jubsu_gubun", jubsuGubun);
		query.setParameter("f_jinryo_yn", jinryoYn);
		query.setParameter("f_naewon_yn", naewonYn);
		List<PHY2001U04GrdPatientListInfo> list = new JpaResultMapper().list(query, PHY2001U04GrdPatientListInfo.class);
		return list;
	}

	@Override
	public List<PHY2001U04GrdExcelInfo> getPHY2001U04GrdExcelInfo(
			String hospCode, String langauge, String naewonDate, String gwa,
			String doctor, String bunho, String jubsuGubun, String jinryoYn,
			String naewonYn) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :f_hosp_code, :f_language)       GWA_NAME                            ");
		sql.append("      , A.BUNHO                                                                     BUNHO                               ");
		sql.append("      , B.SUNAME                                                                    SUNAME                              ");
		sql.append("      , B.SUNAME2                                                                   SUNAME2                             ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :f_hosp_code)               DOCTOR_NAME                        ");
		sql.append("      , B.BIRTH                                                                     BIRTH                               ");
		sql.append("      , CONCAT(IFNULL(FN_BAS_LOAD_AGE(A.NAEWON_DATE,B.BIRTH,''),''),' / ',IFNULL(B.SEX,'' ))      AGE_SEX               ");
		sql.append("      , A.JUBSU_TIME                                                                JUBSU_TIME                          ");
		sql.append("      ,case IFNULL(NAEWON_YN, 'N') when  'E' then '終了' else '未終了' end          ORDER_END_YN                          ");
		sql.append("      ,case A.NAEWON_YN when 'H' then '保留' else '未保留' end                      HOLD_YN                               ");
		sql.append("      ,case FN_OUT_LOAD_SUNAB_CHECK_YN(A.PKOUT1001, A.NAEWON_DATE, :f_hosp_code)                                        ");
		sql.append("      when 'Y' then '会計済' when 'N' then '未会計' else '未会計' end                SUNAB_YN                               ");
		sql.append("      ,case IFNULL(NAEWON_YN, 'N') when 'N' then '未来院' else '来院' end           NAEWON_YN                             ");
		sql.append("      , C.CODE_NAME                                                                 JUBSU_GUBUN                         ");
		sql.append("      , A.ARRIVE_TIME                                                               ARRIVE_TIME                         ");
		sql.append("      , FN_OUT_LOAD_LAST_NAEWON_DATE(A.BUNHO, '%', :f_hosp_code)                    LAST_NAEWON_DATE                    ");
		sql.append("      , D.GAEIN                                                                     GAEIN                               ");
		sql.append("      , E.BP_TO                                                                     BP_TO                               ");
		sql.append("      , E.BP_FROM                                                                   BP_FROM                             ");
		sql.append("      , E.PULSE                                                                     PULSE                               ");
		sql.append("      , E.BODY_HEAT                                                                 BODY_HEAT                           ");
		sql.append("   FROM (OUT1001 A LEFT JOIN (SELECT X.HOSP_CODE, X.BUNHO, 'Y' KAIGO_YN, X.GAEIN                                        ");
		sql.append("           FROM OUT0102 X                                                                                               ");
		sql.append("          WHERE X.HOSP_CODE = :f_hosp_code                                                                              ");
		sql.append("            AND X.GUBUN = '70'                                                                                          ");
		sql.append("            AND X.START_DATE = (SELECT MAX(Y.START_DATE)                                                                ");
		sql.append("                                  FROM OUT0102 Y                                                                        ");
		sql.append("                                 WHERE Y.HOSP_CODE = X.HOSP_CODE                                                        ");
		sql.append("                                   AND Y.GUBUN     = X.GUBUN                                                            ");
		sql.append("                                   AND :f_naewon_date BETWEEN X.START_DATE                                              ");
		sql.append("                                                          AND X.END_DATE)                                               ");
		sql.append("          GROUP BY X.HOSP_CODE, X.BUNHO, X.GAEIN, X.START_DATE                                                          ");
		sql.append("         HAVING X.START_DATE = MAX(X.START_DATE)) D  ON D.HOSP_CODE = A.HOSP_CODE AND D.BUNHO = A.BUNHO)                ");
		sql.append("         LEFT JOIN ( SELECT * FROM NUR7001 EA                                                                           ");
		sql.append("           WHERE EA.HOSP_CODE = :f_hosp_code                                                                            ");
		sql.append("             AND EA.MEASURE_DATE = STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')                                              ");
		sql.append("             AND EA.SEQ = (SELECT MAX(EB.SEQ) FROM NUR7001 EB                                                           ");
		sql.append("                            WHERE EB.HOSP_CODE    = :f_hosp_code                                                        ");
		sql.append("                              AND EB.BUNHO        = EA.BUNHO                                                            ");
		sql.append("                              AND EB.MEASURE_DATE = STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')                             ");
		sql.append("                              AND EB.VALD         = 'Y')) E ON E.HOSP_CODE  = A.HOSP_CODE                               ");
		sql.append("                              AND E.BUNHO  = A.BUNHO AND E.MEASURE_DATE = STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')       ");
		sql.append("      , OUT0101 B                                                                                                       ");
		sql.append("      , BAS0102 C                                                                                                       ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                                    ");
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                                                     ");
		sql.append("    AND C.HOSP_CODE   = A.HOSP_CODE                                                                                     ");
		sql.append("    AND A.NAEWON_DATE = STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')                                                         ");
		sql.append("    AND A.GWA         LIKE :f_gwa                                                                                       ");
		sql.append("    AND A.DOCTOR      LIKE :f_doctor                                                                                    ");
		sql.append("    AND A.BUNHO       LIKE :f_bunho                                                                                     ");
		sql.append("    AND A.BUNHO       = B.BUNHO                                                                                         ");
		sql.append("    AND C.CODE_TYPE   = 'JUBSU_GUBUN'                                                                                   ");
		sql.append("    AND C.LANGUAGE    = :f_language                                                                                     ");
		sql.append("    AND A.JUBSU_GUBUN = C.CODE                                                                                          ");
		sql.append("    AND (                                                                                                               ");
		sql.append("         (:f_jubsu_gubun = '88' AND A.JUBSU_GUBUN IN ('20','21','22'))                                                  ");
		sql.append("         OR (:f_jubsu_gubun != '88' AND A.JUBSU_GUBUN LIKE :f_jubsu_gubun)                                              ");
		sql.append("        )                                                                                                               ");
		sql.append("                                                                                                                        ");
		sql.append("    AND ((:f_jinryo_yn = 'ALL' AND 1 = 1 ) OR                                                                           ");
		sql.append("         (:f_jinryo_yn = 'Y' AND IFNULL(NAEWON_YN, 'N')  = 'E') OR                                                      ");
		sql.append("         (:f_jinryo_yn = 'N' AND IFNULL(NAEWON_YN, 'N') != 'E'))                                                        ");
		sql.append("    AND ((:f_naewon_yn = 'ALL' AND 1 = 1 ) OR                                                                           ");
		sql.append("         (:f_naewon_yn = 'Y' AND IFNULL(NAEWON_YN, 'N') != 'N') OR                                                      ");
		sql.append("         (:f_naewon_yn = 'N' AND IFNULL(NAEWON_YN, 'N')  = 'N'))                                                        ");
		sql.append("  ORDER BY A.JUBSU_TIME DESC, A.ARRIVE_TIME DESC, A.BUNHO, A.JUBSU_NO													");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", langauge);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_gwa", gwa + "%");
		query.setParameter("f_doctor", doctor + "%");
		query.setParameter("f_bunho", bunho + "%");
		query.setParameter("f_jubsu_gubun", jubsuGubun);
		query.setParameter("f_jinryo_yn", jinryoYn);
		query.setParameter("f_naewon_yn", naewonYn);
		List<PHY2001U04GrdExcelInfo> list = new JpaResultMapper().list(query, PHY2001U04GrdExcelInfo.class);
		return list;
	}

	@Override
	public List<OCS3003Q10GrdOrderDateListItemInfo> getOCS3003Q10GrdOrderDateListItemInfo(String hospCode, String language, String ioGubun, String bunho,
																						  String orderDate, String orderGubun){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.ORDER_DATE                                                            ORDER_DATE,              ");
		sql.append("        A.GWA                                                                   GWA,                     ");
		sql.append("        FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE,:f_hosp_code, :language)     GWA_NAME,                ");
		sql.append("        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :f_hosp_code)          DOCTOR_NAME,             ");
		sql.append("        A.BUNHO                                                                 BUNHO,                   ");
		sql.append("        A.DOCTOR                                                                DOCTOR,                  ");
		sql.append("        A.NAEWON_TYPE                                                           NAEWON_TYPE,             ");
		sql.append("        A.JUBSU_NO                                                              JUBSU_NO,                ");
		sql.append("        A.PKOUT1001                                                             PK_ORDER,                ");
		sql.append("        'O'                                                                     IO_GUBUN,                ");
		sql.append("        D.SPECIFIC_COMMENT                                                      SPECIFIC_COMMENT ,       ");
		sql.append("        B.PKOCS1003                                                             PKOCSKEY,                ");
		sql.append("        FN_DRG_HANGMOG_NAME(:f_hosp_code, B.HANGMOG_CODE)                       HANGMOG_NAME,            ");
		sql.append("        B.HANGMOG_CODE                                                          HANGMOG_CODE,            ");
		sql.append("        B.JUNDAL_PART                                                           JUNDAL_PART,             ");
		sql.append("        C.IRAI_KUBUN                                                            IRAI_KUBUN,              ");
		sql.append("        C.IMAGE                                                                 IMAGE,                   ");
		sql.append("        C.IMAGE_PATH                                                            IMAGE_PATH,              ");
		sql.append("        C.CR_TIME                                                               CR_TIME                  ");
		sql.append("   FROM OUT1001 A                                                                                        ");
		sql.append("       ,OCS1003 B                                                                                        ");
		sql.append("       ,PHY8002 C                                                                                        ");
		sql.append("       ,OCS0103 D                                                                                        ");
		sql.append("  WHERE :f_io_gubun    = 'O'                                                                             ");
		sql.append("    AND A.BUNHO        = :f_bunho                                                                        ");
		sql.append("    AND A.NAEWON_DATE <= STR_TO_DATE(:f_order_date,'%Y/%m/%d')                                           ");
		sql.append("    AND A.HOSP_CODE    = :f_hosp_code                                                                    ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                        ");
		sql.append("    AND B.FKOUT1001 = A.PKOUT1001                                                                        ");
		sql.append("    AND C.HOSP_CODE = B.HOSP_CODE                                                                        ");
		sql.append("    AND C.FK_OCS    = B.PKOCS1003                                                                        ");
		sql.append("    AND D.HOSP_CODE = B.HOSP_CODE                                                                        ");
		sql.append("    AND D.HANGMOG_CODE = B.HANGMOG_CODE                                                                  ");
		sql.append(" UNION                                                                                                   ");
		sql.append(" SELECT A.ORDER_DATE                                                               NAEWON_DATE,          ");
		sql.append("       FN_BAS_LOAD_DOCTOR_GWA(:f_hosp_code, A.INPUT_DOCTOR, A.ORDER_DATE)          GWA,                  ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(FN_BAS_LOAD_DOCTOR_GWA(:f_hosp_code, A.INPUT_DOCTOR, A.ORDER_DATE),          ");
		sql.append("       A.ORDER_DATE,:f_hosp_code, :language)                                         GWA_NAME,           ");
		sql.append("       FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE, :f_hosp_code)           DOCTOR_NAME,        ");
		sql.append("       A.BUNHO                                                                     BUNHO,                ");
		sql.append("       A.INPUT_DOCTOR                                                              DOCTOR,               ");
		sql.append("       '0'                                                                         NAEWON_TYPE,          ");
		sql.append("       IFNULL(A.FKINP1001,1)                                                       JUBSU_NO,             ");
		sql.append("       PKOCS2003                                                                   PK_ORDER,             ");
		sql.append("       'I'                                                                         IO_GUBUN,             ");
		sql.append("       D.SPECIFIC_COMMENT                                                          SPECIFIC_COMMENT ,    ");
		sql.append("       A.PKOCS2003                                                                 PKOCSKEY,             ");
		sql.append("      FN_DRG_HANGMOG_NAME(:f_hosp_code, A.HANGMOG_CODE)                            HANGMOG_NAME,         ");
		sql.append("       A.HANGMOG_CODE                                                              HANGMOG_CODE,         ");
		sql.append("       A.JUNDAL_PART                                                               JUNDAL_PART,          ");
		sql.append("       B.IRAI_KUBUN                                                                IRAI_KUBUN,           ");
		sql.append("       B.IMAGE                                                                     IMAGE,                ");
		sql.append("       B.IMAGE_PATH                                                                IMAGE_PATH,           ");
		sql.append("       B.CR_TIME                                                                   CR_TIME               ");
		sql.append("  FROM ADM3200 C                                                                                         ");
		sql.append("       RIGHT JOIN OCS2003 A ON C.USER_ID = A.INPUT_ID AND C.HOSP_CODE = A.HOSP_CODE                      ");
		sql.append("       ,PHY8002 B                                                                                        ");
		sql.append("       ,OCS0103 D                                                                                        ");
		sql.append(" WHERE :f_io_gubun            = 'I'                                                                      ");
		sql.append("   AND A.BUNHO                = :f_bunho                                                                 ");
		sql.append("   AND A.ORDER_DATE          <= STR_TO_DATE(:f_order_date,'%Y/%m/%d')                                    ");
		sql.append("   AND A.HOSP_CODE            = :f_hosp_code                                                             ");
		sql.append("   AND A.IO_GUBUN             IS NULL                                                                    ");
		sql.append("   AND IFNULL(A.DISPLAY_YN,'Y')  = 'Y'                                                                   ");
		sql.append("   AND (( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('I')))                                ");
		sql.append("   AND EXISTS ( SELECT 'X'                                                                               ");
		sql.append("                FROM VW_OCS_INP1001_RES_02 Z                                                             ");
		sql.append("                WHERE Z.PKINP1001 = A.FKINP1001 )                                                        ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                                                         ");
		sql.append("   AND B.FK_OCS = A.PKOCS2003                                                                            ");
		sql.append("   AND D.HOSP_CODE = A.HOSP_CODE                                                                         ");
		sql.append("   AND D.HANGMOG_CODE = A.HANGMOG_CODE                                                                   ");
		sql.append(" ORDER BY 1 DESC, 9 DESC                                                                                 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_order_gubun",orderGubun);
		List<OCS3003Q10GrdOrderDateListItemInfo> list = new JpaResultMapper().list(query, OCS3003Q10GrdOrderDateListItemInfo.class);
		return list;
	}

	public List<OCS2015U04LoadExaminationInfo> getOCS2015U04LoadExaminationInfo (String hospCode, String patientCode){
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT 							");
		sql.append("	PKOUT1001,                      ");
		sql.append("	NAEWON_DATE,                    ");
		sql.append("	GWA                             ");
		sql.append("	FROM                            ");
		sql.append("	OUT1001                         ");
		sql.append("	WHERE                           ");
		sql.append("	HOSP_CODE = :f_hosp_code    ");
		sql.append("	AND BUNHO = :f_patient_code     ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_patient_code", patientCode);

		List<OCS2015U04LoadExaminationInfo> list = new JpaResultMapper().list(query, OCS2015U04LoadExaminationInfo.class);
		return list;
	}

	public String getFnOutCheckNaewonYn(String hospCode, Double fkout1001){
		StringBuffer sql = new StringBuffer();
		sql.append("SELECT FN_OUT_CHECK_NAEWON_YN(  A.BUNHO                 ");
		sql.append("                               ,A.NAEWON_DATE           ");
		sql.append("                               ,A.GWA                   ");
		sql.append("                               ,A.DOCTOR                ");
		sql.append("                               ,A.NAEWON_TYPE           ");
		sql.append("                               ,A.JUBSU_NO              ");
		sql.append("                               ,A.CHOJAE)  ORDER_YN     ");
		sql.append("   FROM OUT1001 A                                       ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                      ");
		sql.append("    AND A.PKOUT1001 = :f_fkout1001                      ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkout1001", fkout1001);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String callPrNurChangeBunho(String hospCode, String ioGubun, String fromBunho, Double naewonKey, String toBunho, String userId){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_NUR_CHANGE_BUNHO");

		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NAEWON_KEY", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);

		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_FROM_BUNHO", fromBunho);
		query.setParameter("I_NAEWON_KEY", naewonKey);
		query.setParameter("I_TO_BUNHO", toBunho);
		query.setParameter("I_USER_ID", userId);

		query.execute();
		String result = (String) query.getOutputParameterValue("IO_ERR");
		if (result != null && !result.isEmpty()) {
			return result;
		}
		return null;
	}

	@Override
	public List<RES1001R00BookingInfo> getRES1001R00BookingInfo(String hospCode, String language, String bunhoLink, String gwa, String doctor, Date naewonDate, String jubsuTime) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.BUNHO_LINK,                         ");
		sql.append("         B.GWA_NAME,                            ");
		sql.append("         D.DOCTOR_NAME,                         ");
		sql.append(" DATE_FORMAT(C.NAEWON_DATE, '%Y/%m/%d'),        ");
		sql.append("         C.JUBSU_TIME                           ");
		sql.append("  FROM OUT2016 A, BAS0260 B,                    ");
		sql.append("       OUT1001 C, BAS0270 D                     ");
		sql.append("  WHERE A.HOSP_CODE_LINK = :hosp_code_link      ");
		sql.append("    AND A.HOSP_CODE_LINK = B.HOSP_CODE          ");
		sql.append("    AND A.HOSP_CODE_LINK = C.HOSP_CODE          ");
		sql.append("    AND A.HOSP_CODE_LINK = D.HOSP_CODE          ");
		sql.append("    AND A.BUNHO_LINK = :bunho_link              ");
		sql.append("    AND A.BUNHO_LINK = C.BUNHO                  ");
		sql.append("    AND C.GWA = :gwa                            ");
		sql.append("    AND B.GWA = C.GWA                           ");
		sql.append("    AND B.LANGUAGE = :language                  ");
		sql.append("    AND C.DOCTOR = :doctor                      ");
		sql.append("    AND C.DOCTOR = D.DOCTOR                     ");
		sql.append("    AND C.NAEWON_DATE = :naewon_date            ");
		sql.append("    AND C.JUBSU_TIME  = :jubsu_time				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code_link", hospCode);
		query.setParameter("language", language);
		query.setParameter("doctor", doctor);
		query.setParameter("gwa", gwa);
		query.setParameter("bunho_link", bunhoLink);
		query.setParameter("naewon_date", naewonDate);
		query.setParameter("jubsu_time", jubsuTime);

		List<RES1001R00BookingInfo> list = new JpaResultMapper().list(query, RES1001R00BookingInfo.class);
		return list;
	}
	
	@Override
	public List<RES1001U01BookingClinicReferInfo> getRES1001U01BookingClinicReferInfo(String naewonDate, String hospCode, String gwa,String doctor) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT  A.BUNHO					                                      as patientId,									");
		sql.append("    		A.SUNAME					                                  as patientName,								");
		sql.append("    		DATE_FORMAT(A.BIRTH, '%Y/%m/%d')							  as birthday,									");
		sql.append("    		A.SEX                                                 		  as sex,										");
		sql.append("    		B.HOSP_CODE					                                  as bookingClinicId,							");
		sql.append("    		B.YOYANG_NAME					                              as bookingClinicName,							");
		sql.append("    		B.TEL					                                      as tel,										");
		sql.append("    		DATE_FORMAT(C.NAEWON_DATE, '%Y/%m/%d')                		  as bookingDate,								");
		sql.append("        	C.JUBSU_TIME                                          		  as bookingTime,								");
		sql.append("        	C.OUT_HOSP_CODE 					                          as outHospCode,								");
		sql.append("        	CASE WHEN D.EMR_LINK_FLG = '1' THEN '1' ELSE '' END   		  as linkEmrInformation 						");
		sql.append("	FROM  OUT1001	C 																									");
		sql.append("	JOIN  BAS0001	B ON C.OUT_HOSP_CODE = B.HOSP_CODE																	");
		sql.append("					 AND B.START_DATE = (SELECT MAX(B1.START_DATE) FROM BAS0001 B1 WHERE B1.HOSP_CODE = B.HOSP_CODE)	");
		sql.append("	JOIN  OUT0101 A ON C.BUNHO = A.BUNHO																				");
		sql.append("	LEFT JOIN OUT2016 D ON D.BUNHO = A.BUNHO																			");
		sql.append("	                   AND D.HOSP_CODE = :f_hosp_code																	");
		sql.append("	                   AND D.HOSP_CODE_LINK = C.OUT_HOSP_CODE															");
		sql.append("					   AND C.OUT_HOSP_CODE IS NOT NULL																	");
		sql.append("					   AND C.OUT_HOSP_CODE <> :f_hosp_code																");
		sql.append("	WHERE C.NAEWON_DATE = DATE_FORMAT(:f_naewon_date,'%Y/%m/%d')														");
		sql.append("	  AND C.HOSP_CODE 	= :f_hosp_code																					");
		sql.append("	  AND A.HOSP_CODE 	= :f_hosp_code																					");
		sql.append("	  AND C.DOCTOR 		= :f_doctor																						");
		sql.append("	  AND C.GWA			= :f_gwa																						");
		sql.append("	  AND C.RESER_YN   	= 'Y'																							");
		sql.append("	  AND (D.ACTIVE_FLG = 1 OR D.ACTIVE_FLG IS NULL)																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_gwa", gwa);
		
		List<RES1001U01BookingClinicReferInfo> list = new JpaResultMapper().list(query, RES1001U01BookingClinicReferInfo.class);
		return list;
	}

	@Override
	public List<BookingLabInfo> getBookingLabInfo(String doctor, String gwa, String bunho, String hospCode, String nawon, String reserTime) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT ID, DOCTOR,GWA,PKOUT1001,HOSP_CODE ,BUNHO, JUBSU_TIME		");
		sql.append(" FROM OUT1001  WHERE DOCTOR = :f_doctor AND   GWA = :f_gwa			");
		sql.append(" AND   RESER_YN = 'Y'  AND  BUNHO = :f_bunho_link  					");
		sql.append(" AND  HOSP_CODE = :f_hosp_code AND  NAEWON_DATE = :f_naewon_date	");
		sql.append(" AND  JUBSU_TIME = :f_reser_time 										");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho_link", bunho);
		query.setParameter("f_naewon_date", nawon);
		query.setParameter("f_reser_time", reserTime);

		List<BookingLabInfo> list = new JpaResultMapper().list(query, BookingLabInfo.class);
		return list;

	}

	public String getGubun(String fkOUT1001, String hospCode)
	{
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT GUBUN FROM OUT1001								    ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code and PKOUT1001 = :fk_out1001 ");

		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("fk_out1001", fkOUT1001);

		List<String> list = query.getResultList();

		if(!CollectionUtils.isEmpty(list))
		{
			return list.get(0);
		}
		return "";

	}

	@Override
	public List<KCCKCountTotalOfBookingInfo> getKCCKCountTotalOfBookingInfo(String hospCode, String doctor, Date startDate, Date endDate) {
		StringBuffer sql = new StringBuffer();
		sql.append("   SELECT DATE_FORMAT(NAEWON_DATE, '%Y%m%d'),                        ");
		sql.append("          JUBSU_TIME,                                                ");
		sql.append("           RES_INPUT_GUBUN                                           ");
		sql.append("   FROM OUT1001                                                      ");
		sql.append("   WHERE (HOSP_CODE   = :hosp_code OR OUT_HOSP_CODE  = :hosp_code )  ");
		sql.append("   AND RESER_YN    = 'Y'                                             ");
		sql.append("   AND DOCTOR      = :doctor                                         ");
		sql.append("   AND NAEWON_DATE = :naewon_date						             ");
		sql.append("   AND NAEWON_DATE <= :end_date		     				             ");
		sql.append("   ORDER BY JUBSU_TIME      		     				             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("naewon_date", startDate);
		query.setParameter("end_date", startDate);
		List<KCCKCountTotalOfBookingInfo> list = new JpaResultMapper().list(query, KCCKCountTotalOfBookingInfo.class);
		return list;
	}

	@Override
	public List<ADM9999U00GetInformInfo> getADM9999U00GetInformInfo(BigInteger id) {
		StringBuffer sql = new StringBuffer();
		sql.append("   SELECT   									                    	");
		sql.append("          SYS_DATE,                                                		");
		sql.append("           SYS_ID,                                       		    	");
		sql.append("          UPD_DATE,                                                		");
		sql.append("           BUNHO                                        		   		");
		sql.append("   FROM OUT1001                                                      	");
		sql.append("   WHERE ID = :id  														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("id", id);
		
		List<ADM9999U00GetInformInfo> list = new JpaResultMapper().list(query, ADM9999U00GetInformInfo.class);
		
		return list;
	}
	
	@Override
	public List<CreatePatientSurveyInfo> getPatientSurveyInfo(String hospCode) {
		StringBuffer sql = new StringBuffer();
		sql.append("   SELECT	A.BUNHO,								                    ");
		sql.append("          	B.SUNAME,                                                	");
		sql.append("           	C.GWA,                                       		    	");
		sql.append("          	C.GWA_NAME,                                                	");
		sql.append("           	DATE_FORMAT(A.NAEWON_DATE, '%Y/%m/%d'),						");
		sql.append("          	A.JUBSU_TIME,                                        		");
		sql.append("           	CAST(A.PKOUT1001 AS CHAR),									");
		sql.append("           	B.PWD		                                       		   	");
		sql.append("   FROM OUT1001 A, OUT0101 B, BAS0260 C                                 ");
		sql.append("   WHERE A.HOSP_CODE = :hosp_code  										");
		sql.append("   AND A.HOSP_CODE = B.HOSP_CODE  										");
		sql.append("   AND A.BUNHO = B.BUNHO  												");
		sql.append("   AND A.HOSP_CODE = C.HOSP_CODE  										");
		sql.append("   AND A.GWA = C.GWA  													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		
		List<CreatePatientSurveyInfo> list = new JpaResultMapper().list(query, CreatePatientSurveyInfo.class);
		
		return list;
	}
	@Override

	public List<BookingExamInfo> getPatientSurveyInfo(String hospCode, String pkout1001, String language) {
		StringBuffer sql = new StringBuffer();
		sql.append("  	SELECT	A.BUNHO,								                    					");
		sql.append("           	C.ID DEPARTMENT_ID,                                                    			");
		sql.append("           	C.GWA,                                                              			");
		sql.append("          	C.GWA_NAME,                                                         			");
		sql.append("           	D.ID DOCTOR_ID,                                                        			");
		sql.append("           	D.DOCTOR,                                                              			");
		sql.append("           	D.DOCTOR_NAME,                                                         			");
		sql.append("           	DATE_FORMAT(A.NAEWON_DATE, '%Y%m%d'),			                    			");
		sql.append("          	A.JUBSU_TIME,                                                     				");
		sql.append("           	CAST(A.PKOUT1001 AS CHAR) PKOUT1001				                			");
		sql.append("    FROM OUT1001 A, BAS0260 C, BAS0271 D                               						");
		sql.append("    WHERE A.HOSP_CODE = :hosp_code  														");
		sql.append("    AND A.HOSP_CODE = C.HOSP_CODE                                                 			");
		sql.append("    AND A.HOSP_CODE = D.HOSP_CODE                                                 			");
		sql.append("    AND SUBSTR(A.DOCTOR, 3) = D.DOCTOR                                            			");
		sql.append("    AND A.GWA = C.GWA  AND A.pkout1001 = :pkout1001	AND C.LANGUAGE = :language				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("pkout1001", pkout1001);
		query.setParameter("language", language);
		List<BookingExamInfo> list = new JpaResultMapper().list(query, BookingExamInfo.class);

		return list;
	}
	@Override
	public List<NUR2016U02ActingDateAndSendYnInfo> getNUR2016U02ActingDateAndSendYn(String hospCode, List<String> bunho) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT DISTINCT S.BUNHO, S.ACTING_DATE, S.IF_DATA_SEND_YN, A.GWA, A.DOCTOR, A.NAEWON_DATE									");
		sql.append(" FROM OUT1001 A    INNER JOIN OCS1003 S ON	S.HOSP_CODE = A.HOSP_CODE AND S.BUNHO = A.BUNHO AND S.FKOUT1001 = A.PKOUT1001   ");	
		sql.append(" WHERE A.HOSP_CODE   = :hosp_code                                                                                           ");
		if(!CollectionUtils.isEmpty(bunho)){
			sql.append(" AND A.BUNHO IN (:bunho)																						        ");

		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		if(!CollectionUtils.isEmpty(bunho)){
			query.setParameter("bunho", bunho);
		}
		List<NUR2016U02ActingDateAndSendYnInfo> list = new JpaResultMapper().list(query, NUR2016U02ActingDateAndSendYnInfo.class);
		
		return list;
	}
	
	@Override
	public List<NUR2015U01GrdOrderInfo> getNUR2015U01GrdOrderInfo(String hospCode, String bunho, String language){
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT DATE_FORMAT(A.NAEWON_DATE, '%Y/%m/%d'), A.GWA, A.PKOUT1001, B.GWA_NAME	");
		sql.append("	FROM OUT1001 A																	");
		sql.append("	JOIN BAS0260 B ON A.HOSP_CODE = B.HOSP_CODE AND A.GWA = B.GWA					");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code												");
		sql.append("	  AND A.BUNHO = :bunho															");
		sql.append("	  AND B.LANGUAGE = :language													");
		sql.append("	ORDER BY A.PKOUT1001 DESC														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("language", language);
		List<NUR2015U01GrdOrderInfo> listResult = new JpaResultMapper().list(query, NUR2015U01GrdOrderInfo.class);
		return listResult;
	}

	@Override
	public List<SyncDrugInfo> getDrugInfo(String hospCode, String patientCode, String language) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT                                                                                                                 ");
		sql.append("	    CONCAT(DATE_FORMAT(F.NAEWON_DATE, '%Y-%m-%d'), ' ', F.JUBSU_TIME) as datetime_record,		                       ");
		sql.append("	    A.FKOUT1001								as		prescription_name,                                                 ");
		sql.append("	    F.ID								    as		prescription_id,										           ");
		sql.append("	    F.SYS_DATE								as		presciption_created,										       ");
		sql.append("	    F.UPD_DATE								as		presciption_updated,										       ");
		sql.append("	    A.ID								      as		medicine_id,										           ");
		sql.append("	    B.HANGMOG_NAME						as		medicine_name,										                   ");
		sql.append("	    A.SURYANG								  as		dose,										                   ");
		sql.append("	    A.ORD_DANUI								as 		unit_code,										                   ");
		sql.append("	    E.CODE_NAME								as		unit,										                       ");
		sql.append("	    A.DV								      as		frequency,										               ");
		sql.append("	    A.NALSU								    as		days,										                       ");
		sql.append("	    C.BOGYONG_NAME						as		note,										                           ");
		sql.append("	    B.INPUT_CONTROL						as		medicine_method,										               ");
		sql.append("	    D.YOYANG_NAME							as		hosp_name,										                   ");
		sql.append("	    A.SYS_DATE								as		created,										                   ");
		sql.append("	    A.UPD_DATE								as		updated                                                            ");
		sql.append("	FROM                                                                                                                   ");
		sql.append("	  OCS1003 A, 																                                           ");
		sql.append("	  OCS0103 B,																                                           ");
		sql.append("	  DRG0120	C,																                                           ");
		sql.append("	  BAS0001	D,																                                           ");
		sql.append("	  OCS0132	E,																                                           ");
		sql.append("	  OUT1001	F																                                           ");
		sql.append("	WHERE 1 = 1														                                                       ");
		sql.append("	  AND A.BUNHO 								  =		:patientCode										               ");
		sql.append("	  AND A.HOSP_CODE								=		:hospCode										               ");
		sql.append("	  AND A.HOSP_CODE								=		B.HOSP_CODE										               ");
		sql.append("	  AND A.HOSP_CODE								=		E.HOSP_CODE										               ");
		sql.append("	  AND A.HANGMOG_CODE 						=		B.HANGMOG_CODE										               ");
		sql.append("	  AND B.INPUT_CONTROL						IN		('1','C')										                   ");
		sql.append("	  AND B.JUNDAL_TABLE_OUT				=		'DRG'										                           ");
		sql.append("	  AND B.JUNDAL_PART_OUT					=		'PA'										                           ");
		sql.append("	  AND C.BOGYONG_CODE						=		A.BOGYONG_CODE										               ");
		sql.append("	  AND A.HOSP_CODE								=		D.HOSP_CODE										               ");
		sql.append("	  AND D.START_DATE							=		(select MAX(START_DATE) from BAS0001 where HOSP_CODE = :hospCode ) ");
		sql.append("	  AND A.ORD_DANUI								=		E.CODE										                   ");
		sql.append("	  AND E.CODE_TYPE								=		'ORD_DANUI'										               ");
		sql.append("	  AND F.PKOUT1001								=		A.FKOUT1001										               ");
		sql.append("	  AND A.HOSP_CODE								=		F.HOSP_CODE										               ");
		sql.append("	  AND A.BUNHO 								  =		F.BUNHO			                                                   ");
		sql.append("	  AND D.LANGUAGE                =   :language                                                                          ");
		sql.append("	  AND E.LANGUAGE                =   :language     AND C.LANGUAGE = :language                                           ");
		sql.append("	  AND C.HOSP_CODE								=		:hospCode										               ");
		sql.append("	ORDER BY																				                               ");
		sql.append("	  A.ORDER_DATE ASC ;                                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("language", language);
		List<SyncDrugInfo> listResult = new JpaResultMapper().list(query, SyncDrugInfo.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> getRES1001U00CheckDuplicate(String hospitalCode, String sessionHospCode,
			String patientCode, String departmentCode, String examPreDate, String examPreTime, String language, boolean isOtherClinic) {
		StringBuilder sql = new StringBuilder();
		if (isOtherClinic) {
			sql.append(" SELECT FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE,:sessionHospCode) DOCTOR_NAME, B.GWA_NAME   ");
			sql.append(" FROM OUT1001 A  LEFT JOIN BAS0260 B ON A.HOSP_CODE = B.HOSP_CODE AND B.BUSEO_GUBUN = '1'           ");
			sql.append("   AND B.GWA   = :departmentCode AND B.LANGUAGE = :language                                         ");
			sql.append(" WHERE  A.HOSP_CODE         = :hospitalCode                                                         ");
			sql.append("        AND A.OUT_HOSP_CODE  = :sessionHospCode                                                     ");
		}else{
			sql.append(" SELECT FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE,:sessionHospCode) DOCTOR_NAME, B.GWA_NAME   ");
			sql.append(" FROM OUT1001 A  LEFT JOIN BAS0260 B ON A.HOSP_CODE = B.HOSP_CODE AND B.BUSEO_GUBUN = '1'           ");
			sql.append("   AND B.GWA   = :departmentCode AND B.LANGUAGE = :language                                          ");
			sql.append("         WHERE A.HOSP_CODE           = :sessionHospCode												");
		}
		sql.append("        AND A.RESER_YN    = 'Y'                                      ");
		if (!StringUtils.isEmpty(patientCode)) {
			sql.append("        AND A.BUNHO       = :patientCode                         ");
		}
		if (!StringUtils.isEmpty(departmentCode)) {
			sql.append("        AND A.GWA         = :departmentCode                      ");
		}
		if (!StringUtils.isEmpty(examPreDate)) {
			sql.append("        AND A.NAEWON_DATE = :examPreDate                         ");
		}
		if (!StringUtils.isEmpty(examPreTime)) {
			sql.append("        AND A.JUBSU_TIME  = :examPreTime                         ");
		}
		sql.append("limit 0,1                                                            ");

		Query query = entityManager.createNativeQuery(sql.toString());
		if(isOtherClinic){
			query.setParameter("hospitalCode", hospitalCode);
		}
		query.setParameter("sessionHospCode", sessionHospCode);
		query.setParameter("language", language);
		if (!StringUtils.isEmpty(patientCode)) {
			query.setParameter("patientCode", patientCode);
		}
//		if (!StringUtils.isEmpty(departmentCode)) {
			query.setParameter("departmentCode", departmentCode);
//		}
		if (!StringUtils.isEmpty(examPreDate)) {
			query.setParameter("examPreDate", DateUtil.toDate(examPreDate, DateUtil.PATTERN_YYMMDD));
		}
		if (!StringUtils.isEmpty(examPreTime)) {
			query.setParameter("examPreTime", examPreTime);
		}

		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<LoadGridBIL2016U02Info> getInvoiceUnPayForAdmissionFeeDetailList(String hospCode, String language, String bunho, Double pkout1001, String bunhoType) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.CHOJAE,																																");          
		sql.append("	        C.CODE_NAME,																													        ");
		sql.append("	        CASE																																    ");
		sql.append("          WHEN :language = 'JA' THEN '回'																							                ");
		sql.append("          WHEN :language = 'VI' THEN 'lần'																							                ");
		sql.append("          WHEN :language = 'EN' THEN 'time'																							                ");
		sql.append("        END      ,																										                            ");
		sql.append("        CASE																																        ");
		sql.append("          WHEN :f_bunho_type = 'I' THEN B.PRICE1																							        ");
		sql.append("          WHEN :f_bunho_type = 'N' THEN B.PRICE2																							        ");
		sql.append("          WHEN :f_bunho_type = 'F' THEN B.PRICE3																							        ");
		sql.append("        END                                                                                          AS PRICE,			                            ");
		sql.append("        '1'			     AS QUANTITY,	                    	                                                                                    ");
		sql.append("        CASE 																																        ");
		sql.append("          WHEN :f_bunho_type = 'I' THEN CAST(B.PRICE1 AS decimal(15,2))	                                                                            ");
		sql.append("          WHEN :f_bunho_type = 'N' THEN CAST(B.PRICE2 AS decimal(15,2))	                                                                            ");
		sql.append("          WHEN :f_bunho_type = 'F' THEN CAST(B.PRICE3 AS decimal(15,2))	                                                                            ");
		sql.append("		  ELSE 0																															        ");
		sql.append("        END                                                                                                               AS AMOUNT,		        ");
		sql.append("        CASE WHEN :f_bunho_type = 'I' THEN CAST(B.PRICE1 AS decimal(15,2)) ELSE 0 END AS INSURANCE_PAY,                                             ");
		sql.append("        CASE 																																        ");
		sql.append("          WHEN :f_bunho_type = 'I' THEN CAST('0' AS decimal(15,2))																			        ");
		sql.append("          WHEN :f_bunho_type = 'N' THEN CAST(B.PRICE2 AS decimal(15,2))	                                                                            ");
		sql.append("          WHEN :f_bunho_type = 'F' THEN CAST(B.PRICE3 AS decimal(15,2))	                                                                            ");
		sql.append("		  ELSE 0																															        ");
		sql.append("        END                                                                                                               AS PATIENT_PAY,	        ");
		sql.append("        CAST('0' AS decimal(15,2))                 					                                                      AS DISCOUNT,		        ");
		sql.append(" 	        ''	                                        											AS DEPT_REQ_CD,						            ");
		sql.append(" 	        ''                                        											AS DEPT_REQ_NM,						                ");
		sql.append(" 	        ''                                     												AS DOCTOR_REQ_CD,					                ");
		sql.append(" 	        ''                                     											AS DOCTOR_REQ_NM,					                    ");
		sql.append("	        ''		                                       											AS DEPT_EXC_CD,						            ");
		sql.append("	        ''                                      											AS DEPT_EXC_NM,						                ");
		sql.append("	        ''	                        											AS DOCTOR_EXC_CD,					                            ");
		sql.append("	        ''                      											AS DOCTOR_EXC_NM,					                                ");
		sql.append("	        ''                         												AS ORDER_GRP_CD,					                            ");
		sql.append("	        CASE																																    ");
		sql.append("          		WHEN :language = 'JA' THEN '診'																							            ");
		sql.append("         		WHEN :language = 'VI' THEN 'Khám'																							        ");
		sql.append("     		    WHEN :language = 'EN' THEN 'Admission'																							    ");
		sql.append("       		END    ORDER_GRP_NM  ,																										            ");
		sql.append("			IFNULL(DATE_FORMAT(A.NAEWON_DATE, '%Y/%m/%d'), '')											AS ORDER_DATE,						        ");
		sql.append("			IFNULL(DATE_FORMAT(A.NAEWON_DATE, '%Y/%m/%d'), '')											AS ACTING_DATE,						        ");
		sql.append("			''																							AS PAYMENT_NM,						        ");
		sql.append("			''																							AS PAYMENT_CD,						        ");
		sql.append("			''																							AS PAID_NAME,						        ");
		sql.append("			''																							AS DISCOUNT_REASON,					        ");
		sql.append("	        A.PKOUT1001,																													        ");
		sql.append("	        CAST(0 AS decimal(15,2))																	AS TOTAL_DISCOUNT,					        ");
		sql.append("			''																							AS DISCOUNT_TYPE,					        ");
		sql.append("			''																							AS DISCOUNT_REASON_MASTER,			        ");
		sql.append("			''																							AS REVERT_TYPE,						        ");
		sql.append("			''																							AS REVERT_COMMENT	,				        ");
		sql.append("			CAST(0 AS decimal(15,2))																	AS amount_paid		,		     			");
		sql.append("			CAST(0 AS decimal(15,2))																	AS amount_debt				  			  	");
		sql.append("			FROM OUT1001 A LEFT JOIN BIL0001 B ON B.HOSP_CODE = A.HOSP_CODE    AND A.CHOJAE = B.HANGMOG_CODE                                        ");                                                     
		sql.append("				LEFT JOIN BAS0102 C ON A.HOSP_CODE = C.HOSP_CODE AND A.CHOJAE = C.CODE AND  C.LANGUAGE = :language  AND C.CODE_TYPE = 'CHOJAE'      ");                                                                                                            
		sql.append("			WHERE A.HOSP_CODE = :hosp_code                                                                                                          ");
		sql.append("		 AND A.PKOUT1001 = :pkout1001	                                                                                                            ");
		sql.append("      AND IFNULL(A.PAID_YN,'N') = 'N'																												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_bunho_type", bunhoType);
		query.setParameter("pkout1001", pkout1001);
		
		List<LoadGridBIL2016U02Info> listResult = new JpaResultMapper().list(query, LoadGridBIL2016U02Info.class);
		return listResult;
	}
	
	@Override
	public List<MedicalInfo> getExaminationFee(String hospCode, String bunho, Double pkout1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  IF(A.CHOJAE = '1', '110', '120')        AS MedicalClass,					");
		sql.append("         '1'                                     AS MedicalClassNumber,				");
		sql.append("         '1'                                     AS MedicationNumber,				");
		sql.append("         C.IF_CODE                               AS MedicationCode					");
		sql.append(" FROM OUT1001 A																		");
		sql.append(" JOIN BAS0355 B ON A.HOSP_CODE = B.HOSP_CODE										");
		sql.append("               AND (																");
		sql.append("                 (A.CHOJAE = '1' AND B.CONDITION = '01') OR							");
		sql.append("                 (A.CHOJAE = '2' AND B.CONDITION = '02') OR							");
		sql.append("                 (A.CHOJAE = '3' AND B.CONDITION = '03') OR							");
		sql.append("                 (A.CHOJAE = '4' AND B.CONDITION = '04')							");
		sql.append("               )																	");
		sql.append(" JOIN IFS0003 C ON A.HOSP_CODE = C.HOSP_CODE										");
		sql.append("               AND C.MAP_GUBUN = 'IF_ORCA_HANGMOG'									");
		sql.append("               AND C.OCS_CODE = B.SG_CODE											");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code													");
		sql.append("   AND A.BUNHO = :f_bunho															");
		sql.append("   AND A.PKOUT1001 = :f_pkout1001													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkout1001", pkout1001);
		
		List<MedicalInfo> listResult = new JpaResultMapper().list(query, MedicalInfo.class);
		return listResult;
	}

	@Override
	public List<OCS1003P01GrdPatientListItemInfo> getOCS2015U21GrdPatientListItem(String hospCode, Date naewonDate,
			String naewonYn, String reserYn, String doctorModeYn, String doctor, String bunho, String language,
			String gwa) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.BUNHO																																				                   	");
		sql.append("	   , A.NAEWON_DATE                                                                                                                                                             ");
		sql.append("	   , A.GWA                                                                                                                                                                     ");
		sql.append("	   , A.DOCTOR                                                                                                                                                                  ");
		sql.append("	   , A.NAEWON_TYPE                                                                                                                                                             ");
		sql.append("	   , IFNUlL(A.RESER_YN, 'N')                                        RESER_YN                                                                                                   ");
		sql.append("	   , A.JUBSU_TIME                                                JUBSU_TIME                                                                                                    ");
		sql.append("	   , A.ARRIVE_TIME                                               ARRIVE_TIME                                                                                                   ");
		sql.append("	   , CONCAT(IF(A.NAEWON_YN  = 'H', CONCAT( '[',FN_BAS_LOAD_CODE_NAME('NAEWON_YN', A.NAEWON_YN,:f_hosp_code, :language),'] ') , ''), B.SUNAME) SUNAME                           ");
		sql.append("	   , B.SUNAME2                                                                                                                                                                 ");
		sql.append("	   , FN_BAS_LOAD_CODE_NAME( 'SEX', B.SEX,:f_hosp_code, :language )                       SEX                                                                                   ");
		sql.append("	   , FN_BAS_LOAD_AGE ( A.NAEWON_DATE, B.BIRTH, 'XXXX')                                   AGE                                                                                   ");
		sql.append("	   , FN_BAS_LOAD_GUBUN_NAME ( A.GUBUN, A.NAEWON_DATE ,:f_hosp_code)                                   GUBUN_NAME                                                               ");
		sql.append("	   , FN_BAS_LOAD_GWA_NAME ( A.GWA, A.NAEWON_DATE,:f_hosp_code, :language )                                       GWA_NAME                                                      ");
		sql.append("	   , FN_BAS_LOAD_DOCTOR_NAME ( A.DOCTOR, A.NAEWON_DATE,:f_hosp_code )                                 DOCTOR_NAME                                                              ");
		sql.append("	   , FN_BAS_LOAD_CODE_NAME ( 'CHOJAE', A.CHOJAE ,:f_hosp_code, :language)                CHOJAE_NAME                                                                           ");
		sql.append("	   , IF(A.NAEWON_YN = 'E','Y','N')                                                        JINRYO_END_YN                                                                        ");
		sql.append("	   , A.PKOUT1001                                                                          PK_NAEWON                                                                            ");
		sql.append("	   , A.NAEWON_YN                                                                          NAEWON_YN                                                                            ");
		sql.append("	   , A.SUNNAB_YN                                                                          SUNNAB_YN                                                                            ");
		sql.append("	   , A.JUBSU_GUBUN                                                                        JUBSU_GUBUN                                                                          ");
		sql.append("	   , IF(FN_OCS_LOAD_TA_GWA_JINRYO_CNT ( A.BUNHO, A.NAEWON_DATE, A.GWA,:f_hosp_code ) > 0,'Y','N')      OTHER_GWA                                                               ");
		sql.append("	   , IF(C.PKOCS0503 IS NULL, 'N','Y')                                                     CONSULT_YN                                                                           ");
		sql.append("	   , IFNULL(D.COMMON_DOCTOR_YN , 'N')                                                        COMMON_DOCTOR_YN                                                                  ");
		sql.append("	   , A.GUBUN                                                                                   GUBUN                                                                           ");
		sql.append("	   , IFNULL(E.GROUP_KEY, '0')                                                               GROUP_KEY                                                                          ");
		sql.append("	   , A.KENSA_YN                                                                          KENSA_YN                                                                              ");
		sql.append("	   , IF(FN_OCS_GET_NOTAPPROVE_ORDERCNT(A.HOSP_CODE, 'O', 'Y', 'N', SUBSTR(A.DOCTOR, LENGTH(A.DOCTOR) -4), A.PKOUT1001) =  0, 'N', 'Y') UNAPPROVE_YN                            ");
		sql.append("	   , IFNULL(A.SYS_ID, '')                           																														   					");
		sql.append("	   , D.SABUN                            																														   						");
		sql.append("	 FROM  ((( BAS0102 E  RIGHT JOIN OUT1001 A ON   E.CODE  = A.JUBSU_GUBUN AND E.LANGUAGE = :language AND E.CODE_TYPE = 'JUBSU_GUBUN' AND E.HOSP_CODE     = A.HOSP_CODE )                  ");
		sql.append("	       LEFT JOIN OCS0503 C ON  C.HOSP_CODE  = A.HOSP_CODE AND C.CONSULT_FKOUT1001 = A.PKOUT1001 )                                                                                   ");
		sql.append("	    JOIN  BAS0270 D ON  D.HOSP_CODE             = A.HOSP_CODE    AND D.DOCTOR  = A.DOCTOR AND A.NAEWON_DATE BETWEEN D.START_DATE  AND D.END_DATE)                                   ");
		sql.append("	    JOIN OUT0101 B ON  B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO     = A.BUNHO                                                                                                          ");
		sql.append("	                                                                                                                                                                                    ");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                                                                  ");
		sql.append("	 AND A.NAEWON_DATE = :naewonDate                                                                                                                                                 ");
		sql.append("	 AND A.NAEWON_YN  IN ('Y', 'E', 'H')                                                                                                                                                ");
		sql.append("	 AND IF (A.NAEWON_YN IN ('E', 'H'),'Y','N') LIKE :naewonYn                                                                                                                       ");
		sql.append("	 AND IFNULL(A.RESER_YN, 'N') LIKE :reserYn                                                                                                                                       ");
		sql.append("	 AND (( :doctorModeYn = 'Y' AND ( A.DOCTOR   LIKE CONCAT('%',SUBSTR(:doctor, 3))                                                                                              	");
		sql.append("	                                 OR D.COMMON_DOCTOR_YN = 'Y'))                                                                                                                      ");
		sql.append("	     OR ( :doctorModeYn != 'Y' AND ( A.DOCTOR   LIKE CONCAT('%',SUBSTR(:doctor, 3)))))                                                                                        	");
		sql.append("	 AND A.BUNHO LIKE :bunho                                                                                                                                                          ");
		sql.append("	 AND ((:doctorModeYn = 'Y' AND IFNULL(E.GROUP_KEY, '0') = '1')                                                                                                                  ");
		sql.append("	        OR :doctorModeYn != 'Y')                                                                                                                                                ");
		sql.append("	 AND A.GWA LIKE :f_gwa                                                                                                                                                          ");
		sql.append("	ORDER BY IFNULL(A.ARRIVE_TIME, A.JUBSU_TIME), A.BUNHO, A.JUBSU_NO                                                                                                                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("naewonYn", naewonYn);
		query.setParameter("reserYn", reserYn);
		query.setParameter("doctorModeYn", doctorModeYn);
		query.setParameter("doctor", doctor);
		query.setParameter("bunho", bunho);
		query.setParameter("f_gwa", gwa);

		List<OCS1003P01GrdPatientListItemInfo> list = new JpaResultMapper()
				.list(query, OCS1003P01GrdPatientListItemInfo.class);
		return list;
	}

	@Override
	public String getNURILIBwonyoiYn(String hospCode, String bunho, String naewonDate, String jubsuTime) {
		StringBuffer sql = new StringBuffer();
		sql.append("SELECT DISTINCT 																																						");
		sql.append("	IFNULL(A.WONYOI_ORDER_YN,'N')																																		");
		sql.append("	FROM OUT1001 A																																						");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code 																																	");
		sql.append("	AND A.BUNHO     = :f_bunho																																			");
		sql.append("	AND CONCAT(DATE_FORMAT(A.NAEWON_DATE,'%Y%m%d'),IFNULL(A.JUBSU_TIME,'0000')) =(SELECT MAX(CONCAT(DATE_FORMAT(Z.NAEWON_DATE,'%Y%m%d'),IFNULL(Z.JUBSU_TIME,'0000')))	");
		sql.append("   		FROM OUT1001 Z																																					");
		sql.append("   		WHERE Z.HOSP_CODE = A.HOSP_CODE																																	");
		sql.append("   		AND Z.BUNHO = :f_bunho																																			");
		sql.append("   		AND CONCAT(DATE_FORMAT(Z.NAEWON_DATE,'%Y%m%d'),IFNULL(Z.JUBSU_TIME,'0000')) <=																					");
		sql.append("   		CONCAT(DATE_FORMAT(STR_TO_DATE(:f_naewon_date,'%Y/%m/%d'),'%Y%m%d'),																							");
		sql.append("   		IFNULL(:f_jubsu_time,'0000'))																																	");
		sql.append("   		AND IFNULL(Z.NAEWON_YN,'N') <> 'N')																																");
		sql.append("	AND IFNULL(A.NAEWON_YN,'N') <> 'N'																																	");
		sql.append("	LIMIT 1																																								");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_jubsu_time", jubsuTime);

		List<Object> result = query.getResultList();
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0).toString();
		}
		return null;
	}
}
