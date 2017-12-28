package nta.med.data.dao.medi.ocs.impl;

import java.math.BigInteger;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
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

import nta.med.core.domain.ocs.Ocs1003;
import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003RepositoryCustom;
import nta.med.data.model.ihis.bill.BIL2016U01LoadPatientInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL2010R02grdOrderListInfo;
import nta.med.data.model.ihis.cpls.CPL2010R02grdcpllistInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetOrderReportInfo;
import nta.med.data.model.ihis.emr.OCS2015U03OrderGubunInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01GrdOCS1003ItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01LabelNewListItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01ScheduleItemInfo;
import nta.med.data.model.ihis.nuro.NUR2016U02TranferSgCodeInfo;
import nta.med.data.model.ihis.nuro.ORCATransferOrdersClaimInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdEditInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListNonSendYnInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSMisaGetHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U12GrdSangyongOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdOrderListInfo;
import nta.med.data.model.ihis.ocsa.OCSAPPROVEGrdOrderInfo;
import nta.med.data.model.ihis.ocso.GwaListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003Q02LayQueryLayoutInfo;
import nta.med.data.model.ihis.ocso.OCS1003R00LayOCS1003Info;
import nta.med.data.model.ihis.ocso.OCSACT2GetGrdPaListInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdJearyoInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayoutQueryInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05OrderListItemInfo;
import nta.med.data.model.ihis.ocso.PatientMedicineInfo;
import nta.med.data.model.ihis.ocso.PrOcsIudBomOrderActInfo;
import nta.med.data.model.ihis.nuro.MedicalInfo;
import nta.med.data.model.ihis.nuro.MedicalInfoExt;
import nta.med.data.model.ihis.orca.ORCATransferOrdersClaimOrdersFeeInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdOutInfo;

/**
 * @author dainguyen.
 */
public class Ocs1003RepositoryImpl implements Ocs1003RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Ocs1003RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<InjsINJ1001U01ScheduleItemInfo> getInjsINJ1001U01ScheduleItemInfo(String hospitalCode, String language,
			String bunho, Date orderDate, String postOrderYn, String preOrderYn, Date reserDate, String actingFlg){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DATE_FORMAT(C.RESER_DATE, '%Y/%m/%d')                                                                                 ");
		sql.append("     , DATE_FORMAT(B.ORDER_DATE, '%Y/%m/%d')                                                                                 ");
		sql.append("     , DATE_FORMAT(C.ACTING_DATE, '%Y/%m/%d')                                                                                ");
		sql.append("     , B.GWA                                                                                                                 ");
		sql.append("     , SUBSTR(FN_BAS_LOAD_GWA_NAME(B.GWA, B.ORDER_DATE, :hospitalCode, :language),1,20) GWA_NAME                             ");
		sql.append("     , B.DOCTOR                                                                                                              ");
		sql.append("     , SUBSTR(FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, B.ORDER_DATE, :hospitalCode),1,20) DOCTOR_NAME                               ");
		sql.append("     , B.IF_DATA_SEND_YN                                                                                                     ");
		sql.append("  FROM OCS1003 B                                                                                                             ");
		sql.append("     , INJ1002 C                                                                                                             ");
		sql.append("     , INJ1001 A                                                                                                             ");
		sql.append(" WHERE A.HOSP_CODE = :hospitalCode                                                                                           ");
		if (!StringUtils.isEmpty(bunho)) {
			sql.append("   AND A.BUNHO     = :bunho                                                                                              ");
		}
		sql.append("   AND B.HOSP_CODE  = A.HOSP_CODE                                                                                            ");
		if (orderDate != null) {
			sql.append("   AND B.ORDER_DATE = :f_order_date                                                                                      ");
		}
		sql.append("   AND B.PKOCS1003  = A.FKOCS1003                                                                                            ");
		sql.append("   AND C.HOSP_CODE  = A.HOSP_CODE                                                                                            ");
		sql.append("   AND C.FKINJ1001  = A.PKINJ1001                                                                                            ");
		sql.append("   AND (   (:f_post_order_yn = 'Y' AND IFNULL(C.ACTING_DATE, C.RESER_DATE) >= :f_reser_date	) 								 ");
		sql.append("        OR (:f_pre_order_yn  = 'Y' AND IFNULL(C.ACTING_DATE, C.RESER_DATE) <= :f_reser_date	)								 ");
		sql.append("        OR (:f_reser_date    = IFNULL(C.ACTING_DATE, C.RESER_DATE))                                                          ");
		sql.append("       )                                                                                                                     ");
		if (!StringUtils.isEmpty(actingFlg)) {
			sql.append("   AND IFNULL(C.ACTING_FLAG, 'N') = :f_acting_flag                                                                       ");
		}
		sql.append(" GROUP BY C.RESER_DATE, B.ORDER_DATE, C.ACTING_DATE                                                                          ");
		sql.append("     , B.GWA                                                                                                                 ");
		sql.append("     , B.DOCTOR                                                                                                              ");
		sql.append("     , SUBSTR(FN_BAS_LOAD_GWA_NAME(B.GWA, B.ORDER_DATE, :hospitalCode, :language),1,20)                                      ");
		sql.append("     , SUBSTR(FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, B.ORDER_DATE, :hospitalCode),1,20)                                           ");
		sql.append("     , B.IF_DATA_SEND_YN                                                                                                     ");
		sql.append(" ORDER BY C.RESER_DATE, B.ORDER_DATE, B.GWA, B.DOCTOR                                                                        ");
		   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		if (!StringUtils.isEmpty(bunho)) {
			query.setParameter("bunho", bunho);
		}
		if (orderDate != null) {
			query.setParameter("f_order_date", orderDate);
		}
		query.setParameter("f_post_order_yn", postOrderYn);
		query.setParameter("f_pre_order_yn", preOrderYn);
		query.setParameter("f_reser_date", reserDate);
		if (!StringUtils.isEmpty(actingFlg)) {
			query.setParameter("f_acting_flag", actingFlg);
		}
		
		List<InjsINJ1001U01ScheduleItemInfo> list = new JpaResultMapper().list(query, InjsINJ1001U01ScheduleItemInfo.class);
		
		return list;
	}
	
	public List<OcsoOCS1003P01LayoutQueryInfo> getOcsoOCS1003P01LayoutQueryInfo(String language, String hospCode, String bunho, Double fkout1001,
			String queryGubun, String inputGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.FKOUT1001 IN_OUT_KEY,                                                                                                        ");
		sql.append("         A.PKOCS1003 PKOCSKEY,                                                                                                          ");
		sql.append("         A.BUNHO BUNHO,                                                                                                                 ");
		sql.append("         DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d') ORDER_DATE,                                                                              ");
		sql.append("         A.GWA GWA,                                                                                                                     ");
		sql.append("         A.DOCTOR DOCTOR,                                                                                                               ");
		sql.append("         A.DOCTOR RESIDENT,                                                                                                             ");
		sql.append("         A.NAEWON_TYPE NAEWON_TYPE,                                                                                                     ");
		sql.append("         E.JUBSU_NO JUBSU_NO,                                                                                                           ");
		sql.append("         A.INPUT_ID INPUT_ID,                                                                                                           ");
		sql.append("         A.INPUT_PART INPUT_PART,                                                                                                       ");
		sql.append("         A.GWA INPUT_GWA,                                                                                                               ");
		sql.append("         A.INPUT_ID INPUT_DOCTOR,                                                                                                       ");
		sql.append("         A.INPUT_GUBUN INPUT_GUBUN,                                                                                                     ");
		sql.append("         FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN', A.INPUT_GUBUN, :hospCode, :language) INPUT_GUBUN_NAME,                                    ");
		sql.append("         A.GROUP_SER GROUP_SER,                                                                                                         ");
		sql.append("         A.INPUT_TAB INPUT_TAB,                                                                                                         ");
		sql.append("         FN_OCS_LOAD_CODE_NAME('INPUT_TAB', A.INPUT_TAB, :hospCode, :language) INPUT_TAB_NAME,                                          ");
		sql.append("         A.ORDER_GUBUN ORDER_GUBUN,                                                                                                     ");
		sql.append("         FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN', A.ORDER_GUBUN, :hospCode, :language) ORDER_GUBUN_NAME,                                    ");
		sql.append("         B.GROUP_YN GROUP_YN,                                                                                                           ");
		sql.append("         A.SEQ SEQ,                                                                                                                     ");
		sql.append("         A.SLIP_CODE SLIP_CODE,                                                                                                         ");
		sql.append("         A.HANGMOG_CODE HANGMOG_CODE,                                                                                                   ");
		sql.append("         IF(A.GENERAL_DISP_YN = 'Y', I.GENERIC_NAME, B.HANGMOG_NAME) HANGMOG_NAME,                                                      ");
		sql.append("         A.SPECIMEN_CODE SPECIMEN_CODE,                                                                                                 ");
		sql.append("         C.SPECIMEN_NAME SPECIMEN_NAME,                                                                                                 ");
		sql.append("         A.SURYANG SURYANG,                                                                                                             ");
		sql.append("         A.SUNAB_SURYANG SUNAB_SURYANG,                                                                                                 ");
		sql.append("         A.SUBUL_SURYANG SUBUL_SURYANG,                                                                                                 ");
		sql.append("         A.ORD_DANUI ORD_DANUI,                                                                                                         ");
		sql.append("         FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :hospCode, :language) ORD_DANUI_NAME,                                          ");
		sql.append("         A.DV_TIME DV_TIME,                                                                                                             ");
		sql.append("         A.DV DV,                                                                                                                       ");
		sql.append("         A.DV_1 DV_1,                                                                                                                   ");
		sql.append("         A.DV_2 DV_2,                                                                                                                   ");
		sql.append("         A.DV_3 DV_3,                                                                                                                   ");
		sql.append("         A.DV_4 DV_4,                                                                                                                   ");
		sql.append("         A.NALSU NALSU,                                                                                                                 ");
		sql.append("         '' SUNAB_NALSU,                                                                                                              	");
		sql.append("         A.JUSA JUSA,                                                                                                                   ");
		sql.append("         FN_OCS_LOAD_CODE_NAME ('JUSA', A.JUSA, :hospCode, :language) JUSA_NAME,                                                        ");
		sql.append("         A.JUSA_SPD_GUBUN JUSA_SPD_GUBUN,                                                                                               ");
		sql.append("         A.BOGYONG_CODE BOGYONG_CODE,                                                                                                   ");
		sql.append("         CASE                                                                                                                           ");
		sql.append("            WHEN (B.INPUT_CONTROL = 'A')                                                                                                ");
		sql.append("            THEN                                                                                                                        ");
		sql.append("               FN_CHT_LOAD_CHT0117_NAME (A.BOGYONG_CODE, :hospCode, :language)                                                          ");
		sql.append("            ELSE                                                                                                                        ");
		sql.append("               FN_DRG_LOAD_BOGYONG_NAME (A.BOGYONG_CODE, :hospCode)                                                                     ");
		sql.append("         END                                                                                                                            ");
		sql.append("            BOGYONG_NAME,                                                                                                               ");
		sql.append("         A.EMERGENCY EMERGENCY,                                                                                                         ");
		sql.append("         A.JAERYO_JUNDAL_YN JAERYO_JUNDAL_YN,                                                                                           ");
		sql.append("         A.JUNDAL_TABLE JUNDAL_TABLE,                                                                                                   ");
		sql.append("         A.JUNDAL_PART JUNDAL_PART,                                                                                                     ");
		sql.append("         A.MOVE_PART MOVE_PART,                                                                                                         ");
		sql.append("         A.PORTABLE_YN PORTABLE_YN,                                                                                                     ");
		sql.append("         A.POWDER_YN POWDER_YN,                                                                                                         ");
		sql.append("         A.HUBAL_CHANGE_YN HUBAL_CHANGE_YN,                                                                                             ");
		sql.append("         A.PHARMACY PHARMACY,                                                                                                           ");
		sql.append("         A.DRG_PACK_YN DRG_PACK_YN,                                                                                                     ");
		sql.append("         A.MUHYO MUHYO,                                                                                                                 ");
		sql.append("         '' PRN_YN,                                                                                                                     ");
		sql.append("         '' TOIWON_DRG_YN,                                                                                                              ");
		sql.append("         '' PRN_NURSE,                                                                                                                  ");
		sql.append("         '' APPEND_YN,                                                                                                                  ");
		sql.append("         A.ORDER_REMARK ORDER_REMARK,                                                                                                   ");
		sql.append("         A.NURSE_REMARK NURSE_REMARK,                                                                                                   ");
		sql.append("         '' COMMENTS,                                                                                                                   ");
		sql.append("         A.MIX_GROUP MIX_GROUP,                                                                                                         ");
		sql.append("         A.AMT AMT,                                                                                                                     ");
		sql.append("         A.PAY PAY,                                                                                                                     ");
		sql.append("         A.WONYOI_ORDER_YN WONYOI_ORDER_YN,                                                                                             ");
		sql.append("         A.DANGIL_GUMSA_ORDER_YN DANGIL_GUMSA_ORDER_YN,                                                                                 ");
		sql.append("         A.DANGIL_GUMSA_RESULT_YN DANGIL_GUMSA_RESULT_YN,                                                                               ");
		sql.append("         A.BOM_OCCUR_YN BOM_OCCUR_YN,                                                                                                   ");
		sql.append("         A.BOM_SOURCE_KEY BOM_SOURCE_KEY,                                                                                               ");
		sql.append("         A.DISPLAY_YN DISPLAY_YN,                                                                                                       ");
		sql.append("         A.SUNAB_YN SUNAB_YN,                                                                                                           ");
		sql.append("         DATE_FORMAT(A.SUNAB_DATE, '%Y/%m/%d') SUNAB_DATE,                                                                              ");
		sql.append("         A.SUNAB_TIME SUNAB_TIME,                                                                                                       ");
		sql.append("         DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d') HOPE_DATE,                                                                                ");
		sql.append("         A.HOPE_TIME HOPE_TIME,                                                                                                         ");
		sql.append("         A.NURSE_CONFIRM_USER NURSE_CONFIRM_USER,                                                                                       ");
		sql.append("         DATE_FORMAT(A.NURSE_CONFIRM_DATE, '%Y/%m/%d') NURSE_CONFIRM_DATE,                                                              ");
		sql.append("         A.NURSE_CONFIRM_TIME NURSE_CONFIRM_TIME,                                                                                       ");
		sql.append("         '' NURSE_PICKUP_USER,                                                                                                          ");
		sql.append("         '' NURSE_PICKUP_DATE,                                                                                                          ");
		sql.append("         '' NURSE_PICKUP_TIME,                                                                                                          ");
		sql.append("         '' NURSE_HOLD_USER,                                                                                                            ");
		sql.append("         '' NURSE_HOLD_DATE,                                                                                                            ");
		sql.append("         '' NURSE_HOLD_TIME,                                                                                                            ");
		sql.append("         DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d') RESER_DATE,                                                                              ");
		sql.append("         A.RESER_TIME RESER_TIME,                                                                                                       ");
		sql.append("         DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d') JUBSU_DATE,                                                                              ");
		sql.append("         A.JUBSU_TIME JUBSU_TIME,                                                                                                       ");
		sql.append("         DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d') ACTING_DATE,                                                                            ");
		sql.append("         A.ACTING_TIME ACTING_TIME,                                                                                                     ");
		sql.append("         A.ACTING_DAY ACTING_DAY,                                                                                                       ");
		sql.append("         DATE_FORMAT(A.RESULT_DATE, '%Y/%m/%d') RESULT_DATE,                                                                            ");
		sql.append("         A.DC_GUBUN DC_GUBUN,                                                                                                           ");
		sql.append("         A.DC_YN DC_YN,                                                                                                                 ");
		sql.append("         A.BANNAB_YN BANNAB_YN,                                                                                                         ");
		sql.append("         A.BANNAB_CONFIRM BANNAB_CONFIRM,                                                                                               ");
		sql.append("         A.SOURCE_FKOCS1003 SOURCE_ORD_KEY,                                                                                             ");
		sql.append("         A.OCS_FLAG OCS_FLAG,                                                                                                           ");
		sql.append("         A.SG_CODE SG_CODE,                                                                                                             ");
		sql.append("         A.SG_YMD SG_YMD,                                                                                                               ");
		sql.append("         A.IO_GUBUN IO_GUBUN,                                                                                                           ");
		sql.append("         A.AFTER_ACT_YN AFTER_ACT_YN,                                                                                                   ");
		sql.append("         A.BICHI_YN BICHI_YN,                                                                                                           ");
		sql.append("         A.DRG_BUNHO DRG_BUNHO,                                                                                                         ");
		sql.append("         A.SUB_SUSUL SUB_SUSUL,                                                                                                         ");
		sql.append("         A.PRINT_YN PRINT_YN,                                                                                                           ");
		sql.append("         A.CHISIK CHISIK,                                                                                                               ");
		sql.append("         A.TEL_YN TEL_YN,                                                                                                               ");
		sql.append("         B.ORDER_GUBUN ORDER_GUBUN_BAS,                                                                                                 ");
		sql.append("         B.INPUT_CONTROL INPUT_CONTROL,                                                                                                 ");
		sql.append("         B.SUGA_YN SUGA_YN,                                                                                                             ");
		sql.append("         B.JAERYO_YN JAERYO_YN,                                                                                                         ");
		sql.append("         IF(B.WONYOI_ORDER_YN = 'Z', 'Y', 'N') WONYOI_CHECK,                                                                            ");
		sql.append("         IF(IFNULL(B.EMERGENCY, 'Z') = 'Z', 'Y', IFNULL(B.EMERGENCY, 'Z')) EMERGENCY_CHECK,                                             ");
		sql.append("         B.SPECIMEN_YN SPECIMEN_CHECK,                                                                                                  ");
		sql.append("         B.PORTABLE_CHECK PORTABLE_CHECK,                                                                                               ");
		sql.append("         CASE                                                                                                                           ");
		sql.append("            WHEN (B.END_DATE IS NULL) THEN 'N'                                                                                          ");
		sql.append("            WHEN (B.END_DATE = DATE_FORMAT('99981231', '%Y%m%d')) THEN 'N'                                                              ");
		sql.append("            ELSE 'Y'                                                                                                                    ");
		sql.append("         END                                                                                                                            ");
		sql.append("            BULYONG_CHECK,                                                                                                              ");
		sql.append("         IF(A.SUNAB_DATE IS NULL, 'N', 'Y') SUNAB_CHECK,                                                                                ");
		sql.append("         IF(SIGN(A.NALSU) =  1 OR SIGN(A.NALSU) = 0, 'N',  'Y') DC_CHECK,                                                               ");
		sql.append("         A.DC_GUBUN DC_GUBUN_CHECK,                                                                                                     ");
		sql.append("         IF(A.NURSE_CONFIRM_DATE IS NULL, 'N', 'Y') CONFIRM_CHECK,                                                                      ");
		sql.append("         IF(A.RESER_DATE IS NULL, 'N', 'Y') RESER_YN_CHECK,                                                                             ");
		sql.append("         IF(A.CHISIK = '', 'N', 'Y') CHISIK_YN,                                                                                         ");
		sql.append("         A.NDAY_YN NDAY_YN,                                                                                                             ");
		sql.append("         FN_OCS_LOAD_JAERYO_JUNDAL_YN (:hospCode,'O', A.INPUT_PART, A.HANGMOG_CODE) DEFAULT_JAERYO_JUNDAL_YN,                           ");
		sql.append("         CASE                                                                                                                           ");
		sql.append("            WHEN (   A.ORDER_GUBUN NOT IN ('A', 'B', 'C', 'D')                                                                          ");
		sql.append("                  OR A.WONYOI_ORDER_YN = 'Z'                                                                                            ");
		sql.append("                  OR A.WONYOI_ORDER_YN = 'Y')                                                                                           ");
		sql.append("            THEN                                                                                                                        ");
		sql.append("               'N'                                                                                                                      ");
		sql.append("            ELSE                                                                                                                        ");
		sql.append("               'Y'                                                                                                                      ");
		sql.append("         END                                                                                                                            ");
		sql.append("            DEFAULT_WONYOI_YN,                                                                                                          ");
		sql.append("         D.SPECIFIC_COMMENT SPECIFIC_COMMENT,                                                                                           ");
		sql.append("         D.SPECIFIC_COMMENT_NAME SPECIFIC_COMMENT_NAME,                                                                                 ");
		sql.append("         D.SPECIFIC_COMMENT_SYS_ID SPECIFIC_COMMENT_SYS_ID,                                                                             ");
		sql.append("         D.SPECIFIC_COMMENT_PGM_ID SPECIFIC_COMMENT_PGM_ID,                                                                             ");
		sql.append("         D.SPECIFIC_COMMENT_NOT_NULL SPECIFIC_COMMENT_NOT_NULL,                                                                         ");
		sql.append("         D.SPECIFIC_COMMENT_TABLE_ID SPECIFIC_COMMENT_TABLE_ID,                                                                         ");
		sql.append("         D.SPECIFIC_COMMENT_COL_ID SPECIFIC_COMMENT_COL_ID,                                                                             ");
		sql.append("         FN_DRG_LOAD_DONBOK_YN (A.BOGYONG_CODE, :hospCode) DONBOG_YN,                                                                   ");
		sql.append("         FN_OCS_LOAD_CODE_NAME ('ORDER_GUBUN_BAS', SUBSTR(A.ORDER_GUBUN, 2, 1), :hospCode, :language) ORDER_GUBUN_BAS_NAME,             ");
		sql.append("         A.ACT_DOCTOR ACT_DOCTOR,                                                                                                       ");
		sql.append("         A.ACT_BUSEO ACT_BUSEO,                                                                                                         ");
		sql.append("         A.ACT_GWA ACT_GWA,                                                                                                             ");
		sql.append("         A.HOME_CARE_YN HOME_CARE_YN,                                                                                                   ");
		sql.append("         A.REGULAR_YN REGULAR_YN,                                                                                                       ");
		sql.append("         A.SORT_FKOCSKEY SORT_FKOCSKEY,                                                                                                 ");
		sql.append("         CASE                                                                                                                           ");
		sql.append("            WHEN (IF(A.BOM_SOURCE_KEY IS NULL, FN_OCS_LOAD_CHILD_GUBUN(A.HOSP_CODE, 'O', A.PKOCS1003),                                  ");
		sql.append("                          '3') != '3') THEN 'N'                                                                                         ");
		sql.append("            ELSE 'Y'                                                                                                                    ");
		sql.append("         END                                                                                                                            ");
		sql.append("            CHILD_YN,                                                                                                                   ");
		sql.append("         B.IF_INPUT_CONTROL IF_INPUT_CONTROL,                                                                                           ");
		sql.append("         F.SLIP_NAME SLIP_NAME,                                                                                                         ");
		sql.append("         A.PKOCS1003 ORG_KEY,                                                                                                           ");
		sql.append("         A.BOM_SOURCE_KEY PARENT_KEY,                                                                                                   ");
		sql.append("         G.BUN_CODE BUN_CODE,                                                                                                           ");
		sql.append("         CASE                                                                                                                           ");
		sql.append("            WHEN (B.ORDER_GUBUN IN ('B', 'C', 'D'))                                                                                     ");
		sql.append("            THEN                                                                                                                        ");
		sql.append("               IFNULL(B.WONNAE_DRG_YN, 'N')                                                                                             ");
		sql.append("            ELSE                                                                                                                        ");
		sql.append("               '%'                                                                                                                      ");
		sql.append("         END                                                                                                                            ");
		sql.append("            WONNAE_DRG_YN,                                                                                                              ");
		sql.append("         ' ' HUBAL_CHANGE_CHECK,                                                                                                        ");
		sql.append("         ' ' DRG_PACK_CHECK,                                                                                                            ");
		sql.append("         ' ' PHARMACY_CHECK,                                                                                                            ");
		sql.append("         ' ' POWER_CHECK,                                                                                                               ");
		sql.append("         IFNULL(A.IMSI_DRUG_YN, 'N') IMSI_DRUG_YN,                                                                                      ");
		sql.append("         IFNULL(A.GENERAL_DISP_YN, 'N') GENERAL_DISP_YN,                                                                                ");
		sql.append("         A.DV_5 DV_5,                                                                                                                   ");
		sql.append("         A.DV_6 DV_6,                                                                                                                   ");
		sql.append("         A.DV_7 DV_7,                                                                                                                   ");
		sql.append("         A.DV_8 DV_8,                                                                                                                   ");
		sql.append("         A.BOGYONG_CODE_SUB BOGYONG_CODE_SUB,                                                                                           ");
		sql.append("         CASE                                                                                                                           ");
		sql.append("            WHEN (   SUBSTR(A.ORDER_GUBUN, 2) = 'A'                                                                                     ");
		sql.append("                  OR SUBSTR(A.ORDER_GUBUN, 2) = 'B'                                                                                     ");
		sql.append("                  OR SUBSTR(A.ORDER_GUBUN, 2) = 'D')                                                                                    ");
		sql.append("            THEN                                                                                                                        ");
		sql.append("               FN_CHT_LOAD_CHT0117_NAME(A.BOGYONG_CODE_SUB, :hospCode, :language)                                                       ");
		sql.append("            ELSE                                                                                                                        ");
		sql.append("               FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE_SUB, :hospCode)                                                                  ");
		sql.append("         END                                                                                                                            ");
		sql.append("            BOGYONG_NAME_SUB,                                                                                                           ");
		sql.append("         B.LIMIT_NALSU LIMIT_NALSU,                                                                                                     ");
		sql.append("         B.LIMIT_SURYANG LIMIT_SURYANG,                                                                                                 ");
		sql.append("         J.GWA_NAME GWA_NAME,                                                                                                           ");
		sql.append("         IFNULL(A.INSTEAD_YN, 'N') INSTEAD_YN,                                                                                          ");
		sql.append("         IFNULL(A.APPROVE_YN, 'N') APPROVE_YN,                                                                                          ");
		sql.append("         IFNULL(A.POSTAPPROVE_YN, 'N') POSTAPPROVE_YN,                                                                                  ");
		sql.append("         FN_OCS_LOAD_ORDER_SORT_KEY ('O', A.PKOCS1003,:hospCode) ORDER_BY_KEY,                                                          ");
		//sql.append("		 CASE WHEN B.COMMON_YN IS NULL OR B.COMMON_YN = 'N' THEN 'N' ELSE 'Y' END AS ACTION_DO_YN										");
		sql.append("		 'Y' AS ACTION_DO_YN																											");
		sql.append("    FROM                                                                                                                                ");
		sql.append("         OCS1003 A                                                                                                                      ");
		sql.append("         LEFT JOIN OCS0116 C ON C.HOSP_CODE = A.HOSP_CODE AND C.SPECIMEN_CODE = A.SPECIMEN_CODE                                         ");
		sql.append("         INNER JOIN OUT1001 E ON E.HOSP_CODE = A.HOSP_CODE AND E.PKOUT1001 = A.FKOUT1001                                                ");
		sql.append("         INNER JOIN OCS0102 F ON F.HOSP_CODE = A.HOSP_CODE AND A.SLIP_CODE = F.SLIP_CODE 												");
		sql.append("         INNER JOIN BAS0260 J ON J.HOSP_CODE = A.HOSP_CODE AND J.GWA = A.JUNDAL_PART AND F.LANGUAGE = J.LANGUAGE AND J.LANGUAGE = :language                        ");
		sql.append("         , OCS0103 B                                                                                                                    ");
		sql.append("         LEFT JOIN OCS0170 D ON D.HOSP_CODE = B.HOSP_CODE AND D.SPECIFIC_COMMENT = B.SPECIFIC_COMMENT                                   ");
		sql.append("         LEFT JOIN (SELECT A.SG_CODE,                                                                                                   ");
		sql.append("                 A.SG_NAME,                                                                                                             ");
		sql.append("                 A.BUN_CODE,                                                                                                            ");
		sql.append("                 A.HOSP_CODE                                                                                                            ");
		sql.append("            FROM BAS0310 A                                                                                                              ");
		sql.append("           WHERE A.HOSP_CODE = :hospCode                                                                                                ");
		sql.append("             AND A.SG_CODE IN (SELECT SG_CODE FROM OCS1003 WHERE HOSP_CODE = :hospCode AND BUNHO = :bunho AND FKOUT1001 = :fkout1001)   ");
		sql.append("             AND A.SG_YMD =                                                                                                             ");
		sql.append("                    (SELECT MAX(Z.SG_YMD)                                                                                               ");
		sql.append("                       FROM BAS0310 Z                                                                                                   ");
		sql.append("                      WHERE Z.HOSP_CODE = A.HOSP_CODE                                                                                   ");
		sql.append("                            AND Z.SG_CODE = A.SG_CODE																                    ");
		sql.append("                            AND Z.SG_YMD <= SYSDATE())) G ON G.HOSP_CODE = B.HOSP_CODE AND G.SG_CODE = B.SG_CODE                        ");
//		sql.append("         LEFT JOIN VW_OCS_GENERIC I ON I.HOSP_CODE = B.HOSP_CODE AND I.HANGMOG_CODE = B.HANGMOG_CODE                                    ");	
//		turning performace not using view VW_OCS_GENERIC
		sql.append(" LEFT JOIN ( select distinct A.HOSP_CODE AS HOSP_CODE ,A.HANGMOG_CODE AS HANGMOG_CODE, C.GENERIC_NAME AS GENERIC_NAME                   ");
		sql.append("               FROM OCS0109 C INNER JOIN OCS0110 B ON C.HOSP_CODE = B.HOSP_CODE AND C.GENERIC_CODE_ORG = B.GENERIC_CODE_ORG             ");
		sql.append("                              INNER JOIN OCS0103 A ON B.HOSP_CODE = A.HOSP_CODE AND B.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE                 ");
		sql.append("         AND A.START_DATE <= SYSDATE() AND A.END_DATE >= SYSDATE()                                                                      ");
		sql.append(" AND A.START_DATE = (SELECT MAX(S.START_DATE) FROM OCS0103 S where S.HOSP_CODE = A.HOSP_CODE AND S.HANGMOG_CODE = A.HANGMOG_CODE)       ");
		sql.append("                              WHERE  B.HOSP_CODE = :hospCode                                                                            ");
		sql.append("            union all                                                                                                                   ");
		sql.append("            select distinct A.HOSP_CODE AS HOSP_CODE ,A.HANGMOG_CODE AS HANGMOG_CODE, C.GENERIC_NAME AS GENERIC_NAME                    ");
		sql.append("            FROM OCS0109 C INNER JOIN OCS0103 A ON C.HOSP_CODE = A.HOSP_CODE AND C.GENERIC_CODE = A.YAK_KIJUN_CODE_SHORT                ");
		sql.append("         AND A.START_DATE <= SYSDATE() AND A.END_DATE >= SYSDATE()                                                                      ");
		sql.append(" AND A.START_DATE = (SELECT MAX(S.START_DATE) FROM OCS0103 S where S.HOSP_CODE = A.HOSP_CODE AND S.HANGMOG_CODE = A.HANGMOG_CODE)       ");
		sql.append("            WHERE C.HOSP_CODE = :hospCode AND                                                                                           ");
		sql.append("                 (not (exists(SELECT NULL FROM OCS0110 Z                                                                                ");
		sql.append("                                WHERE Z.HOSP_CODE = A.HOSP_CODE AND                                                                     ");
		sql.append("                                Z.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE)))) I                                                               ");
		sql.append("                           ON I.HOSP_CODE = B.HOSP_CODE AND I.HANGMOG_CODE = B.HANGMOG_CODE										    	");
		sql.append("   WHERE  A.HOSP_CODE = :hospCode                                                                                                       ");
		sql.append("         AND A.BUNHO = :bunho                                                                                                           ");
		sql.append("         AND A.FKOUT1001 = :fkout1001                                                                                                   ");
		sql.append("         AND (IFNULL(A.INSTEAD_YN, 'N') = 'N'                                                                                           ");
		sql.append("              OR (IFNULL(A.INSTEAD_YN, 'N') = 'Y'                                                                                       ");
		sql.append("                  AND IFNULL(A.APPROVE_YN, 'N') LIKE                                                                                    ");
		sql.append("                         IF(:queryGubun = 'Y', 'Y', '%')))                                                                              ");
		sql.append("         AND ( (:queryGubun = 'D' AND A.INPUT_GUBUN LIKE 'D%')                                                                          ");
		sql.append("              OR (:queryGubun != 'D'                                                                                                    ");
		sql.append("                  AND (A.INPUT_GUBUN LIKE 'D%'                                                                                          ");
		sql.append("                       OR A.INPUT_GUBUN = :inputGubun)))                                                                                ");
		sql.append("         AND B.HOSP_CODE = A.HOSP_CODE                                                                                                  ");
		sql.append("         AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                            ");
		sql.append("         AND B.START_DATE <= SYSDATE() AND B.END_DATE >= SYSDATE()                                                                      ");
		sql.append(" AND B.START_DATE = (SELECT MAX(S.START_DATE) FROM OCS0103 S where S.HOSP_CODE = B.HOSP_CODE AND S.HANGMOG_CODE = B.HANGMOG_CODE)       ");
		sql.append("         AND A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE                                                                           ");
		sql.append("         AND J.LANGUAGE = :language                                                                                                     ");
		sql.append("ORDER BY CASE WHEN ORDER_BY_KEY IS NULL THEN A.PKOCS1003  ELSE ORDER_BY_KEY END                                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		query.setParameter("fkout1001", fkout1001);
		query.setParameter("queryGubun", queryGubun);
		query.setParameter("inputGubun", inputGubun);
		List<OcsoOCS1003P01LayoutQueryInfo> list = new JpaResultMapper().list(query, OcsoOCS1003P01LayoutQueryInfo.class);

		return list;
	}
	
	@Override
	public String callOcsoOCS1003P01OutOrderEndTemp(String hospCode, Double fkout1001, Date orderDate){
		LOG.info("[START] callOcsoOCS1003P01OutOrderEndTemp " + hospCode + " , " + fkout1001 + " , " + orderDate);
		String ioFlg = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_OUT_ORDER_END_TEMP");
		query.registerStoredProcedureParameter("I_FKOUT1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_FKOUT1001", fkout1001);
		query.setParameter("I_ORDER_DATE", orderDate);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("IO_FLAG", "");
		
		query.execute();
		ioFlg = (String)query.getOutputParameterValue("IO_FLAG");
		LOG.info("[END] callOcsoOCS1003P01OutOrderEndTemp");
		return ioFlg;
	}
	
	@Override
	public String callPrOcsUpdateDcYn(String hospCode, String ioGubun, Double sourcePkOcs){
		String ioFlg = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_UPDATE_DC_YN");
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SOURCE_PK_OCS", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_SOURCE_PK_OCS", sourcePkOcs);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("IO_FLAG", "");
		query.execute();
		ioFlg = (String)query.getOutputParameterValue("IO_FLAG");
		return ioFlg;
	}
	
	@Override
	public String getOcsoOCS1003P01GetOcsKeySeq(){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT SWF_NextVal('OCSKEY_SEQ') ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		return null;

	}
	
	@Override
	public List<OcsoOCS1003Q05OrderListItemInfo> getOcsoOCS1003Q05OrderList(String hospCode, String language, String genericYn, String pkOrder, String inputTab,
			String inputGubun, String telYn, String bunho, String jubsuNo, String kijun, Date naewonDate, String gwa, String doctor){

		List<OCSAPPROVEGrdOrderInfo> list = getOCSAPPROVEGrdOrderListItem(hospCode, language, CommonUtils.parseDouble(pkOrder),
				inputTab, "", "", "", bunho, jubsuNo, doctor,naewonDate, true, genericYn,inputGubun, telYn);
		if(!CollectionUtils.isEmpty(list)){
			for(OCSAPPROVEGrdOrderInfo item : list){
				String buyoCheck = "";
				try {
					buyoCheck = fnOcsBulyongCheckOut(item, buyoCheck);
				} catch (ParseException e) {
					LOG.error(e.getMessage(), e);
				}
				if(!buyoCheck.equalsIgnoreCase("Y")){
					buyoCheck = "N";
				}else if(buyoCheck.equalsIgnoreCase("Y") && item.getBulyongCheck().equalsIgnoreCase(item.getHangmogCode())){
					buyoCheck = "Z";
				}else{
					buyoCheck = "Y";
				}
				item.setBulyongCheck(buyoCheck);
			}
		}
		
		List<OCSAPPROVEGrdOrderInfo> listUnion = getOCSAPPROVEGrdOrderListItemUnion(hospCode, language, CommonUtils.parseDouble(pkOrder),
				inputTab, "", "", "", bunho, jubsuNo, doctor,naewonDate, true,inputGubun, telYn,kijun, gwa);
		if(!CollectionUtils.isEmpty(listUnion)){
			for(OCSAPPROVEGrdOrderInfo item : listUnion){
				String buyoCheck = "";
				try {
					buyoCheck = fnOcsBulyongCheckOut(item, buyoCheck);
				} catch (ParseException e) {
					LOG.error(e.getMessage(), e);
				}
				item.setBulyongCheck(buyoCheck);
			}
		}
		// UNION ALL
		list.addAll(listUnion);
	    
	    // sort by CONT_KEY
	    Collections.sort(list, new Comparator<OCSAPPROVEGrdOrderInfo>() {
			@Override
			public int compare(OCSAPPROVEGrdOrderInfo o1,
							   OCSAPPROVEGrdOrderInfo o2) {
				if (o1.getContKey() == null) return 1;
				if (o2.getContKey() == null) return -1;
				return (o2.getContKey()).compareTo(o1.getContKey());
			}
		});
		
	    List<OcsoOCS1003Q05OrderListItemInfo> listResult = new ArrayList<OcsoOCS1003Q05OrderListItemInfo>();
	     
	    for(OCSAPPROVEGrdOrderInfo entry : list){
	           OcsoOCS1003Q05OrderListItemInfo info = new OcsoOCS1003Q05OrderListItemInfo();
	           
	           if (!StringUtils.isEmpty(entry.getInputGubunName())) {
					info.setInputGubunName(entry.getInputGubunName());
				}
				if (entry.getGroupSer() != null) {
					info.setGroupSer(entry.getGroupSer());
				}
				if (!StringUtils.isEmpty(entry.getOrderGubunName())) {
					info.setOrderGubunName(entry.getOrderGubunName());
				}
				if (!StringUtils.isEmpty(entry.getHangmogCode())) {
					info.setHangmogCode(entry.getHangmogCode());
				}
				if (!StringUtils.isEmpty(entry.getHangmogName())) {
					info.setHangmogName(entry.getHangmogName());
				}
				if (!StringUtils.isEmpty(entry.getSpecimenCode())) {
					info.setSpecimenCode(entry.getSpecimenCode());
				}
				if (!StringUtils.isEmpty(entry.getSpecimenName())) {
					info.setSpecimenName(entry.getSpecimenName());
				}
				if (entry.getSuryang() != null) {
					info.setSuryang(entry.getSuryang());
				}
				if (!StringUtils.isEmpty(entry.getOrdDanui())) {
					info.setOrdDanui(entry.getOrdDanui());
				}
				if (!StringUtils.isEmpty(entry.getOrdDanuiName())) {
					info.setOrdDanuiName(entry.getOrdDanuiName());
				}
				if (!StringUtils.isEmpty(entry.getDvTime())) {
					info.setDvTime(entry.getDvTime());
				}
				if (entry.getDv() != null) {
					info.setDv(entry.getDv());
				}
				if (entry.getNalsu() != null) {
					info.setNalsu(entry.getNalsu());
				}
				if (!StringUtils.isEmpty(entry.getJusa())) {
					info.setJusa(entry.getJusa());
				}
				if (!StringUtils.isEmpty(entry.getJusaName())) {
					if (entry.getJusaName().equals("NULL")) {
						info.setJusaName("");
					} else {
						info.setJusaName(entry.getJusaName());
					}
				}
				if (!StringUtils.isEmpty(entry.getBogyongCode())) {
					info.setBogyongCode(entry.getBogyongCode());
				}
				if (!StringUtils.isEmpty(entry.getBogyongName())) {
					info.setBogyongName(entry.getBogyongName());
				}
				if (!StringUtils.isEmpty(entry.getJusaSpdGubun())) {
					info.setJusaSpdGubun(entry.getJusaSpdGubun());
				}
				if (!StringUtils.isEmpty(entry.getHubalChangeYn())) {
					info.setHubalChangeYn(entry.getHubalChangeYn());
				}
				if (!StringUtils.isEmpty(entry.getPharmacy())) {
					info.setPharmacy(entry.getPharmacy());
				}
				if (!StringUtils.isEmpty(entry.getDrgPackYn())) {
					info.setDrgPackYn(entry.getDrgPackYn());
				}
				if (!StringUtils.isEmpty(entry.getPowderYn())) {
					info.setPowderYn(entry.getPowderYn());
				}
				if (!StringUtils.isEmpty(entry.getWonyoiOrderYn())) {
					info.setWonyoiOrderYn(entry.getWonyoiOrderYn());
				}
				if (!StringUtils.isEmpty(entry.getDangilGumsaOrderYn())) {
					info.setDangilGumsaOrderYn(entry.getDangilGumsaOrderYn());
				}
				if (!StringUtils.isEmpty(entry.getDangilGumsaResultYn())) {
					info.setDangilGumsaResultYn(entry.getDangilGumsaResultYn());
				}
				if (!StringUtils.isEmpty(entry.getEmergency())) {
					info.setEmergency(entry.getEmergency());
				}
				if (!StringUtils.isEmpty(entry.getPay())) {
					info.setPay(entry.getPay());
				}
				if (!StringUtils.isEmpty(entry.getAntiCancerYn())) {
					info.setAntiCancerYn(entry.getAntiCancerYn());
				}
				if (!StringUtils.isEmpty(entry.getMuhyo())) {
					info.setMuhyo(entry.getMuhyo());
				}
				if (!StringUtils.isEmpty(entry.getPortableYn())) {
					info.setPortableYn(entry.getPortableYn());
				}
				if (!StringUtils.isEmpty(entry.getOcsFlag())) {
					info.setOcsFlag(entry.getOcsFlag());
				}
				if (!StringUtils.isEmpty(entry.getOrderGubun())) {
					info.setOrderGubun(entry.getOrderGubun());
				}
				if (!StringUtils.isEmpty(entry.getInputTab())) {
					info.setInputTab(entry.getInputTab());
				}
				if (!StringUtils.isEmpty(entry.getInputGubun())) {
					info.setInputGubun(entry.getInputGubun());
				}
				if (!StringUtils.isEmpty(entry.getAfterActYn())) {
					info.setAfterActYn(entry.getAfterActYn());
				}
				if (!StringUtils.isEmpty(entry.getJundalTable())) {
					info.setJundalTable(entry.getJundalTable());
				}
				if (!StringUtils.isEmpty(entry.getJundalPart())) {
					info.setJundalPart(entry.getJundalPart());
				}
				if (!StringUtils.isEmpty(entry.getMovePart())) {
					info.setMovePart(entry.getMovePart());
				}
				if (!StringUtils.isEmpty(entry.getBunho())) {
					info.setBunho(entry.getBunho());
				}
				if (entry.getOrderDate() != null) {
					info.setOrderDate(entry.getOrderDate());
				}
				if (!StringUtils.isEmpty(entry.getGwa())) {
					info.setGwa(entry.getGwa());
				}
				if (!StringUtils.isEmpty(entry.getDoctor())) {
					info.setDoctor(entry.getDoctor());
				}
				if (!StringUtils.isEmpty(entry.getNaewonType())) {
					info.setNaewonType(entry.getNaewonType());
				}
				if (entry.getPkOrder() != null) {
					info.setPkOrder(entry.getPkOrder());
				}
				if (entry.getSeq() != null) {
					info.setSeq(entry.getSeq());
				}
				if (entry.getPkocs1003() != null) {
					info.setPkocs1003(entry.getPkocs1003());
				}
				if (!StringUtils.isEmpty(entry.getSubSusul())) {
					info.setSubSusul(entry.getSubSusul());
				}
				if (!StringUtils.isEmpty(entry.getSutakYn())) {
					info.setSutakYn(entry.getSutakYn());
				}
				if (entry.getAmt() != null) {
					info.setAmt(entry.getAmt());
				}
				if (entry.getDv1() != null) {
					info.setDv1(entry.getDv1());
				}
				if (entry.getDv2() != null) {
					info.setDv2(entry.getDv2());
				}
				if (entry.getDv3() != null) {
					info.setDv3(entry.getDv3());
				}
				if (entry.getDv4() != null) {
					info.setDv4(entry.getDv4());
				}
				if (!StringUtils.isEmpty(entry.getHopeDate())) {
					info.setHopeDate(entry.getHopeDate());
				}
				if (!StringUtils.isEmpty(entry.getOrderRemark())) {
					info.setOrderRemark(entry.getOrderRemark());
				}
				if (!StringUtils.isEmpty(entry.getMixGroup())) {
					info.setMixGroup(entry.getMixGroup());
				}
				if (!StringUtils.isEmpty(entry.getHomeCareYn())) {
					info.setHomeCareYn(entry.getHomeCareYn());
				}
				if (!StringUtils.isEmpty(entry.getRegularYn())) {
					info.setRegularYn(entry.getRegularYn());
				}
				if (!StringUtils.isEmpty(entry.getGongbiCode())) {
					info.setGongbiCode(entry.getGongbiCode());
				}
				if (!StringUtils.isEmpty(entry.getGongbiName())) {
					info.setGongbiName(entry.getGongbiName());
				}
				if (!StringUtils.isEmpty(entry.getDonbokYn())) {
					info.setDonbokYn(entry.getDonbokYn());
				}
				if (!StringUtils.isEmpty(entry.getDvName())) {
					info.setDvName(entry.getDvName());
				}
				if (!StringUtils.isEmpty(entry.getSlipCode())) {
					info.setSlipCode(entry.getSlipCode());
				}
				if (!StringUtils.isEmpty(entry.getGroupYn())) {
					info.setGroupYn(entry.getGroupYn());
				}
				if (!StringUtils.isEmpty(entry.getSgCode())) {
					info.setSgCode(entry.getSgCode());
				}
				if (!StringUtils.isEmpty(entry.getOrderGubunBas())) {
					info.setOrderGubunBas(entry.getOrderGubunBas());
				}
				if (!StringUtils.isEmpty(entry.getInputControl())) {
					info.setInputControl(entry.getInputControl());
				}
				if (!StringUtils.isEmpty(entry.getSugaYn())) {
					info.setSugaYn(entry.getSugaYn());
				}
				if (!StringUtils.isEmpty(entry.getEmergencyCheck())) {
					info.setEmergencyCheck(entry.getEmergencyCheck());
				}
				if (entry.getLimitSuryang() != null) {
					info.setLimitSuryang(entry.getLimitSuryang());
				}
				if (!StringUtils.isEmpty(entry.getSpecimenYn())) {
					info.setSpecimenYn(entry.getSpecimenYn());
				}
				if (!StringUtils.isEmpty(entry.getJaeryoYn())) {
					info.setJaeryoYn(entry.getJaeryoYn());
				}
				if (!StringUtils.isEmpty(entry.getOrdDanuiCheck())) {
					info.setOrdDanuiCheck(entry.getOrdDanuiCheck());
				}
				if (!StringUtils.isEmpty(entry.getOrdDanuiBas())) {
					info.setOrdDanuiBas(entry.getOrdDanuiBas());
				}
				if (!StringUtils.isEmpty(entry.getJundalTableOut())) {
					info.setJundalTableOut(entry.getJundalTableOut());
				}
				if (!StringUtils.isEmpty(entry.getJundalPartOut())) {
					info.setJundalPartOut(entry.getJundalPartOut());
				}
				if (!StringUtils.isEmpty(entry.getMovePartOut())) {
					info.setMovePartOut(entry.getMovePartOut());
				}
				if (!StringUtils.isEmpty(entry.getJundalTableInp())) {
					info.setJundalTableInp(entry.getJundalTableInp());
				}
				if (!StringUtils.isEmpty(entry.getJundalPartInp())) {
					info.setJundalPartInp(entry.getJundalPartInp());
				}
				if (!StringUtils.isEmpty(entry.getMovePartInp())) {
					info.setMovePartInp(entry.getMovePartInp());
				}
				if (!StringUtils.isEmpty(entry.getBulyongCheck())) {
					info.setBulyongCheck(entry.getBulyongCheck());
				}
				if (!StringUtils.isEmpty(entry.getWonyoiOrderCrYn())) {
					info.setWonyoiOrderCrYn(entry.getWonyoiOrderCrYn());
				}
				if (!StringUtils.isEmpty(entry.getDefaultWonyoiOrderYn())) {
					info.setDefaultWonyoiOrderYn(entry.getDefaultWonyoiOrderYn());
				}
				if (!StringUtils.isEmpty(entry.getNdayYn())) {
					info.setNdayYn(entry.getNdayYn());
				}
				if (!StringUtils.isEmpty(entry.getMuhyoYn())) {
					info.setMuhyoYn(entry.getMuhyoYn());
				}
				if (!StringUtils.isEmpty(entry.getTelYn())) {
					info.setTelYn(entry.getTelYn());
				}
				if (!StringUtils.isEmpty(entry.getDrgInfo())) {
					info.setDrgInfo(entry.getDrgInfo());
				}
				if (!StringUtils.isEmpty(entry.getDrgBunryu())) {
					info.setDrgBunryu(entry.getDrgBunryu());
				}
				if (!StringUtils.isEmpty(entry.getChildYn())) {
					info.setChildYn(entry.getChildYn());
				}
				if (entry.getBomSourceKey() != null) {
					info.setBomSourceKey(entry.getBomSourceKey());
				}
				if (!StringUtils.isEmpty(entry.getBomOccurYn())) {
					info.setBomOccurYn(entry.getBomOccurYn());
				}
				if (entry.getOrgKey() != null) {
					info.setOrgKey(entry.getOrgKey());
				}
				if (entry.getParentKey() != null) {
					info.setParentKey(entry.getParentKey());
				}
				if (!StringUtils.isEmpty(entry.getBunCode())) {
					info.setBunCode(entry.getBunCode());
				}
				if (!StringUtils.isEmpty(entry.getContKey())) {
					info.setContKey(entry.getContKey());
				}
				if (entry.getFkout1001() != null) {
					info.setFkout1001(entry.getFkout1001());
				}
				if (!StringUtils.isEmpty(entry.getWonnaeDrgYn())) {
					info.setWonnaeDrgYn(entry.getWonnaeDrgYn());
				}
				if (!StringUtils.isEmpty(entry.getDcYn())) {
					info.setDcYn(entry.getDcYn());
				}
				if (entry.getResultDate() != null) {
					info.setResultDate(DateUtil.toString(entry.getResultDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(entry.getConfirmCheck())) {
					info.setConfirmCheck(entry.getConfirmCheck());
				}
				if (!StringUtils.isEmpty(entry.getSunabCheck())) {
					info.setSunabCheck(entry.getSunabCheck());
				}
				if (entry.getDv5() != null) {
					info.setDv5(entry.getDv5());
				}
				if (entry.getDv6() != null) {
					info.setDv6(entry.getDv6());
				}
				if (entry.getDv7() != null) {
					info.setDv7(entry.getDv7());
				}
				if (entry.getDv8() != null) {
					info.setDv8(entry.getDv8());
				}
				if (!StringUtils.isEmpty(entry.getGeneralDispYn())) {
					info.setGeneralDispYn(entry.getGeneralDispYn());
				}
				if (!StringUtils.isEmpty(entry.getGenericName())) {
					info.setGenericName(entry.getGenericName());
				}
				if (!StringUtils.isEmpty(entry.getNoValue())) {
					info.setState(entry.getNoValue());
				}
				if (!StringUtils.isEmpty(entry.getBogyongCodeSub())) {
					info.setBogyongCodeSub(entry.getBogyongCodeSub());
				}
				if (!StringUtils.isEmpty(entry.getBogyongNameSub())) {
					info.setBogyongNameSub(entry.getBogyongNameSub());
				}
				if (!StringUtils.isEmpty(entry.getOriHopeDate())) {
					info.setOriHopeDate(entry.getOriHopeDate());
				}
				if (!StringUtils.isEmpty(entry.getIoYn())) {
					info.setIoYn(entry.getIoYn());
				}
				if (!StringUtils.isEmpty(entry.getBroughtDrgYn())) {
					info.setBroughtDrgYn(entry.getBroughtDrgYn());
				}
				if (!StringUtils.isEmpty(entry.getTrialFlg())) {
					info.setTrialFlg(entry.getTrialFlg());
				}
				if (!StringUtils.isEmpty(entry.getYjCode())) {
					info.setYjCode(entry.getYjCode());
				}
				listResult.add(info);
	        }
	    LOG.info("[END] getOcsoOCS1003Q05OrderList");
		return listResult;
	}
	@Override	
	public List<InjsINJ1001U01LabelNewListItemInfo> getInjsINJ1001U01LabelNewListItemInfo(String hospitalCode, String language, String gwa, String doctor,
			String bunho, Date jubsuDate, String groupSer, String mixGroup, String fkinj1001){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT H.BUNHO BUNHO                                                                                                                                     ");                  
		sql.append("  ,F.SUNAME SUNAME                                                                                                                                       ");
		sql.append("  ,F.SUNAME2 SUNAME2                                                                                                                                     ");
		sql.append("  ,FN_BAS_LOAD_AGE(H.ORDER_DATE, F.BIRTH, '') AGE                                                                                                        ");
		sql.append("  ,F.SEX SEX                                                                                                                                             ");
		sql.append("  ,J.JUBSU_DATE JUBSU_DATE                                                                                                                               ");
		sql.append("  ,MAX(G.DV) CNT                                                                                                                                         ");
		sql.append("  ,G.SURYANG SURYANG                                                                                                                                     ");
		sql.append("  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', G.ORD_DANUI, :hospitalCode, :language) DANUI_NAME                                                                  ");
		sql.append("  ,MAX(CONCAT (G.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(G.JUSA_SPD_GUBUN,'0'), :hospitalCode, :language))) BOGYONG_NAME        ");
		sql.append("  ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(G.JUSA,'0'), :hospitalCode, :language) JUSA_NAME                                                                  ");
		sql.append("  ,TRIM(FN_JAERYO_NAME(K.JAERYO_CODE, :hospitalCode)) JAERYO_NAME                                                                                        ");
		sql.append("  ,'' ORDER_REMARK                                                                                                                                       ");
		sql.append("  ,'A' DATA_GUBUN                                                                                                                                        ");
		sql.append("  ,IF(:mix_group is null, 'N','Y') MIX_YN                                                                                                                ");
		sql.append("  FROM OCS0103 K                                                                                                                                         ");
		sql.append("  ,OUT0101 F                                                                                                                                             ");
		sql.append("  ,OCS1003 G                                                                                                                                             ");
		sql.append("  ,INJ1002 J                                                                                                                                             ");
		sql.append("  ,INJ1001 H                                                                                                                                             ");
		sql.append("  WHERE H.HOSP_CODE = :hospitalCode                                                                                                                      ");
		sql.append("  AND J.HOSP_CODE = H.HOSP_CODE                                                                                                                          ");
		sql.append("  AND G.HOSP_CODE = H.HOSP_CODE                                                                                                                          ");
		sql.append("  AND F.HOSP_CODE = H.HOSP_CODE                                                                                                                          ");
		sql.append("  AND K.HOSP_CODE = H.HOSP_CODE                                                                                                                          ");
		if (!StringUtils.isEmpty(bunho)) {
			sql.append("  AND H.BUNHO = :bunho                                                                                                                                   ");
		}
		if (!StringUtils.isEmpty(gwa)) {
			sql.append("  AND H.GWA = :gwa                                                                                                                                       ");
		}
		if (!StringUtils.isEmpty(doctor)) {
			sql.append("  AND H.DOCTOR = :doctor                                                                                                                                 ");
		}
		sql.append("  AND H.NALSU > 0                                                                                                                                        ");
		sql.append("  AND J.FKINJ1001 = H.PKINJ1001                                                                                                                          ");
		if (jubsuDate != null) {
			sql.append("  AND J.JUBSU_DATE = IFNULL(:jubsu_date, SYSDATE())                                                                                                      ");
			sql.append("  AND IFNULL(:jubsu_date, SYSDATE()) BETWEEN K.START_DATE AND K.END_DATE                                                                                ");
		}
		sql.append("  AND J.ACTING_FLAG = 'Y'                                                                                                                                ");
		sql.append("  AND IFNULL(J.DC_YN,'N') = 'N'                                                                                                                          ");
		if (!StringUtils.isEmpty(groupSer)) {
			sql.append("  AND IFNULL(J.GROUP_SER,0) = IFNULL(:group_ser, 0)                                                                                                      ");
		}
		if (!StringUtils.isEmpty(mixGroup) || !StringUtils.isEmpty(fkinj1001)) {
			sql.append("  AND IFNULL(J.MIX_GROUP, J.FKINJ1001) = IFNULL(:mix_group, :fkinj1001)                                                                                  ");
		}
		sql.append("  AND F.BUNHO = H.BUNHO                                                                                                                                  ");
		sql.append("  AND K.HANGMOG_CODE = G.HANGMOG_CODE                                                                                                                    ");
		sql.append("  AND G.PKOCS1003 = H.FKOCS1003                                                                                                                          ");
		sql.append("  GROUP BY H.BUNHO                                                                                                                                       ");
		sql.append("  ,F.SUNAME                                                                                                                                              ");
		sql.append("  ,F.SUNAME2                                                                                                                                             ");
		sql.append("  ,FN_BAS_LOAD_AGE(H.ORDER_DATE, F.BIRTH, '')                                                                                                            ");
		sql.append("  ,F.SEX                                                                                                                                                 ");
		sql.append("  ,J.JUBSU_DATE                                                                                                                                          ");
		sql.append("  ,G.SURYANG                                                                                                                                             ");
		sql.append("  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', G.ORD_DANUI, :hospitalCode, :language)                                                                             ");
		sql.append("  ,TRIM(FN_JAERYO_NAME(K.JAERYO_CODE,:hospitalCode))                                                                                                     ");
		sql.append("  ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(G.JUSA,'0'), :hospitalCode, :language)                                                                            ");
		sql.append("  ,G.ORDER_REMARK;                                                                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		if (!StringUtils.isEmpty(gwa)) {
			query.setParameter("gwa", gwa);
		}
		if (!StringUtils.isEmpty(doctor)) {
			query.setParameter("doctor", doctor);
		}
		if (!StringUtils.isEmpty(bunho)) {
			query.setParameter("bunho", bunho);
		}
		if (jubsuDate != null) {
			query.setParameter("jubsu_date", jubsuDate);
		}
		if (!StringUtils.isEmpty(groupSer)) {
			query.setParameter("group_ser", groupSer);
		}
		query.setParameter("mix_group", mixGroup);
		if (!StringUtils.isEmpty(fkinj1001)) {
			query.setParameter("fkinj1001", fkinj1001);
		}
		
		List<InjsINJ1001U01LabelNewListItemInfo> list = new JpaResultMapper().list(query, InjsINJ1001U01LabelNewListItemInfo.class);
		
		return list;
	}
	
	@Override
	public String getInjsINJ1001U01CplOrderStatus(String hospCode, String ioGubun, String bunho, Date date, String jundalPart) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_INJ_CPL_CHK_YN(:ioGubun, :bunho, :date, :jundalPart, :hospCode) FROM DUAL;");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("bunho", bunho);
		query.setParameter("date", date);
		query.setParameter("jundalPart", jundalPart);
		
		List<String> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0);
		}
		return "";
	}

	@Override
	public List<String> callPrOcsUpdateHopeDate(String hospCode,
			String inOutGubun, Double fkocs, String hopeDate, String io_Msg,
			String io_Flg) {
		LOG.info("[START] callPrOcsUpdateHopeDate hospCode=" + hospCode + 
				", inOutGubun=" + inOutGubun + ", fkocs=" + fkocs + ", hopeDate=" + hopeDate + ", io_Msg=" + io_Msg);
		

		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_UPDATE_HOPE_DATE");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOPE_DATE", Date.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		query.setParameter("I_FKOCS", fkocs);
		query.setParameter("I_HOPE_DATE", DateUtil.toDate(hopeDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("IO_MSG", io_Msg);
		query.setParameter("IO_FLAG", io_Flg);
		
		List<String> listResult = new ArrayList<String>();
		listResult.add((String)query.getOutputParameterValue("IO_FLAG"));
		listResult.add(query.getOutputParameterValue("IO_MSG") == null ? null  : (String)query.getOutputParameterValue("IO_MSG"));
		return listResult;
	}
	
	@Override
	public List<String> validatePrintAdmMediRequest(String hospCode, String jubsuDate, String drgBunho, String bunho,String handlerName) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT SUBSTR(A.ORDER_GUBUN,2,1) ORDER_GUBUN                              ");
		sql.append("FROM OCS1003 A                                                                     ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                                                      ");
		sql.append(" AND A.PKOCS1003 IN (SELECT B.FKOCS1003                                            ");
		sql.append("                       FROM DRG2010 B                                              ");
		sql.append("                      WHERE B.HOSP_CODE  = A.HOSP_CODE                             ");
		if (!StringUtils.isEmpty(jubsuDate)) {
			sql.append("                        AND DATE_FORMAT(B.JUBSU_DATE, '%Y/%m/%d') = :jubsu_date    ");
		}
		if (!StringUtils.isEmpty(drgBunho)) {
			sql.append("                        AND B.DRG_BUNHO  = :drg_bunho                              ");
		}
		if (!StringUtils.isEmpty(bunho)) {
			sql.append("                        AND B.BUNHO      = :bunho                                  ");
		}
		sql.append("                        )                                                            ");
		if(!handlerName.isEmpty()){
			sql.append("AND SUBSTR(A.ORDER_GUBUN,2,1) IN ('B')                                           "); 
		}else{
			sql.append("AND SUBSTR(A.ORDER_GUBUN,2,1) IN ('C', 'D')                                        "); 
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		if (!StringUtils.isEmpty(jubsuDate)) {
			query.setParameter("jubsu_date", jubsuDate);
		}
		if (!StringUtils.isEmpty(drgBunho)) {
			query.setParameter("drg_bunho", drgBunho);
		}
		if (!StringUtils.isEmpty(bunho)) {
			query.setParameter("bunho", bunho);
		}
		
		return query.getResultList();
	}

	@Override
	public String getOrderCancelGetYN(Double pkocs1003) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT IFNULL(IF_DATA_SEND_YN, 'N') ");
		sql.append(" FROM OCS1003                        ");
		sql.append(" WHERE PKOCS1003 = :f_fkocs1003      ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_fkocs1003", pkocs1003);
		List<String> getYN= query.getResultList();
		if(!CollectionUtils.isEmpty(getYN)){
			return getYN.get(0);
		}
		return null;
	}
	@Override
	public List<InjsINJ1001U01GrdOCS1003ItemInfo> getINJ1001U01GrdOCS1003ItemInfo(String hospCode, String language, String bunho, Date startDate,Date endDate) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT STR_TO_DATE(C.RESER_DATE, '%Y/%m/%d')                                                       ");
		sql.append("      , STR_TO_DATE(B.ORDER_DATE, '%Y/%m/%d')                                                       ");
		sql.append("      , STR_TO_DATE(C.ACTING_DATE, '%Y/%m/%d')                                                      ");
		sql.append("      , B.GWA                                                                                       ");
		sql.append("      , SUBSTR(FN_BAS_LOAD_GWA_NAME(B.GWA, B.ORDER_DATE,:f_hosp_code,:f_language),1,20) GWA_NAME    ");
		sql.append("      , B.DOCTOR                                                                                    ");
		sql.append("      , SUBSTR(FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, B.ORDER_DATE,:f_hosp_code),1,20) DOCTOR_NAME       ");
		sql.append("   FROM OCS1003 B                                                                                   ");
		sql.append("      , INJ1002 C                                                                                   ");
		sql.append("      , INJ1001 A                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                  ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                   ");
		sql.append("    AND C.HOSP_CODE = A.HOSP_CODE                                                                   ");
		sql.append("    AND A.BUNHO = :f_bunho                                                                          ");
		sql.append("    AND C.RESER_DATE BETWEEN :f_start_date AND :f_end_date                                          ");
		sql.append("    AND B.PKOCS1003 = A.FKOCS1003                                                                   ");
		sql.append("    AND C.FKINJ1001 = A.PKINJ1001                                                                   ");
		sql.append("  GROUP BY C.RESER_DATE, B.ORDER_DATE, C.ACTING_DATE                                                ");
		sql.append("      , B.GWA                                                                                       ");
		sql.append("      , B.DOCTOR                                                                                    ");
		sql.append("      , SUBSTR(FN_BAS_LOAD_GWA_NAME(B.GWA, B.ORDER_DATE,:f_hosp_code,:f_language),1,20)             ");
		sql.append("      , SUBSTR(FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, B.ORDER_DATE,:f_hosp_code),1,20)                   ");
		sql.append("  ORDER BY C.RESER_DATE, B.ORDER_DATE, B.GWA, B.DOCTOR												");
		 
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_start_date", startDate);
		query.setParameter("f_end_date", endDate);
		List<InjsINJ1001U01GrdOCS1003ItemInfo> getInjsINJ1001U01GrdOCS1003ItemInfo= new JpaResultMapper().list(query, InjsINJ1001U01GrdOCS1003ItemInfo.class);
		return getInjsINJ1001U01GrdOCS1003ItemInfo;
	}
	
	@Override
	public Integer updatePrOcsUpdateHopeDateCaseOut(String hospCode, Date hopeDate, List<Double> pkocs1003) {
		StringBuilder sql= new StringBuilder();
		sql.append("UPDATE OCS1003                      ");
		sql.append("      SET HOPE_DATE = :hopeDate     ");
		sql.append("      WHERE HOSP_CODE = :hospCode   ");
		sql.append("      AND PKOCS1003 IN :pkocs1003   ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hopeDate", hopeDate);
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkocs1003", pkocs1003);
		
		return query.executeUpdate();
	}

	@Override
	public String callFnOcsInsteadModifiedCheck(String hospCode,Integer pkocskey, String inputGubun, String ioGubun) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT FN_OCS_INSTEAD_MODIFIED_CHECK(:f_hosp_code, :f_pkocskey, :f_input_gubun, :f_io_gubun)  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocskey", pkocskey);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_io_gubun", ioGubun);
		List<String> listResult=query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<OCS0103U13GrdOrderListInfo> getOCS0103U13GrdOrderListInfo(String hospCode, String language, String orderMode, String memb,
			String yaksolCode, String inputTab, Double fkInOutKey, String request) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.PKOCS0303                                            PK_ORD_KEY                                                                                   ");
		sql.append("      , A.MEMB                                                 MEMB                                                                                         ");
		sql.append("      , A.YAKSOK_CODE                                          YAKSOK_CODE                                                                                  ");
		sql.append("      , 'NULL'                                                   BUNHO                                                                                        ");
		sql.append("      , 'S'                                                    IO_GUBUN                                                                                     ");
		sql.append("      , cast(null as datetime)                                 ORDER_DATE                                                                                   ");
		sql.append("      , 'NULL'                                                   ORDER_TIME                                                                                   ");
		sql.append("      , 'NULL'                                                   GWA                                                                                          ");
		sql.append("      , 'NULL'                                                   DOCTOR                                                                                       ");
		sql.append("      , 'NULL'                                                   RESIDENT                                                                                     ");
		sql.append("      , 'NULL'                                                   NAEWON_TYPE                                                                                  ");
		sql.append("      , 'NULL'                                                   INPUT_ID                                                                                     ");
		sql.append("      , 'NULL'                                                   INPUT_PART                                                                                   ");
		sql.append("      , 'NULL'                                                   INPUT_GWA                                                                                    ");
		sql.append("      , 'NULL'                                                   INPUT_DOCTOR                                                                                 ");
		sql.append("      , 'NULL'                                                   INPUT_GUBUN                                                                                  ");
		sql.append("      , 'NULL'                                                   INPUT_GUBUN_NAME                                                                             ");
		sql.append("      , A.GROUP_SER                                            GROUP_SER                                                                                    ");
		sql.append("      , A.INPUT_TAB                                            INPUT_TAB                                                                                    ");
		sql.append("      , B.CODE_NAME                                            INPUT_TAB_NAME                                                                               ");
		sql.append("      , A.ORDER_GUBUN                                          ORDER_GUBUN                                                                                  ");
		sql.append("      , C.CODE_NAME                                            ORDER_GUBUN_NAME                                                                             ");
		sql.append("      , A.NDAY_YN                                              NDAY_YN                                                                                      ");
		sql.append("      , A.SEQ                                                  SEQ                                                                                          ");
		sql.append("      , D.SLIP_CODE                                            SLIP_CODE                                                                                    ");
		sql.append("      , A.HANGMOG_CODE                                         HANGMOG_CODE                                                                                 ");
		sql.append("      , D.HANGMOG_NAME                                         HANGMOG_NAME                                                                                 ");
		sql.append("      , A.SPECIMEN_CODE                                        SPECIMEN_CODE                                                                                ");
		sql.append("      , FN_OCS_LOAD_SPECIMEN_NAME(A.HOSP_CODE,A.SPECIMEN_CODE)             SPECIMEN_NAME                                                                    ");
		sql.append("      , A.SURYANG                                              SURYANG                                                                                      ");
		sql.append("      , CAST(null as DECIMAL)                                   SUNAB_SURYANG                                                                                ");
		sql.append("      , 'NULL'                                                   SUBUL_SURYANG                                                                                ");
		sql.append("      , A.ORD_DANUI                                            ORD_DANUI                                                                                    ");
		sql.append("      , F.CODE_NAME                                            ORD_DANUI_NAME                                                                               ");
		sql.append("      , A.DV_TIME                                              DV_TIME                                                                                      ");
		sql.append("      , A.DV                                                   DV                                                                                           ");
		sql.append("      , A.DV_1                                                 DV_1                                                                                         ");
		sql.append("      , A.DV_2                                                 DV_2                                                                                         ");
		sql.append("      , A.DV_3                                                 DV_3                                                                                         ");
		sql.append("      , A.DV_4                                                 DV_4                                                                                         ");
		sql.append("      , A.NALSU                                                NALSU                                                                                        ");
		sql.append("      , CAST(null as DECIMAL)                                  SUNAB_NALSU                                                                                  ");
		sql.append("      , A.JUSA                                                 JUSA                                                                                         ");
		sql.append("      , G.CODE_NAME                                            JUSA_NAME                                                                                    ");
		sql.append("      , A.JUSA_SPD_GUBUN                                       JUSA_SPD_GUBUN                                                                               ");
		sql.append("      , A.BOGYONG_CODE                                         BOGYONG_CODE                                                                                 ");
		sql.append("      , FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE,A.HOSP_CODE)               BOGYONG_NAME                                                                     ");
		sql.append("      , A.EMERGENCY                                            EMERGENCY                                                                                    ");
		sql.append("      , D.INV_JUNDAL_YN                                        JAERYO_JUNDAL_YN                                                                             ");
		sql.append("      , 'NULL'                                                   JUNDAL_TABLE                                                                                 ");
		sql.append("      , 'NULL'                                                   JUNDAL_PART                                                                                  ");
		sql.append("      , D.MOVE_PART                                            MOVE_PART                                                                                    ");
		sql.append("      , A.PORTABLE_YN                                          PORTABLE_YN                                                                                  ");
		sql.append("      , A.POWDER_YN                                            POWDER_YN                                                                                    ");
		sql.append("      , A.HUBAL_CHANGE_YN                                      HUBAL_CHANGE_YN                                                                              ");
		sql.append("      , 'N'                                                    PHAMACY                                                                                      ");
		sql.append("      , A.DRG_PACK_YN                                          DRG_PACK_YN                                                                                  ");
		sql.append("      , A.MUHYO                                                MUHYO                                                                                        ");
		sql.append("      , A.PRN_YN                                               PRN_YN                                                                                       ");
		sql.append("      , 'NULL'                                                   TOIWON_DRG_YN                                                                                ");
		sql.append("      , 'N'                                                    PRN_NURSE                                                                                    ");
		sql.append("      , 'N'                                                    APPEND_YN                                                                                    ");
		sql.append("      , A.ORDER_REMARK                                         ORDER_REMARK                                                                                 ");
		sql.append("      , A.NURSE_REMARK                                         NURSE_REMARK                                                                                 ");
		sql.append("      , A.MIX_GROUP                                            MIX_GROUP                                                                                    ");
		sql.append("      , A.AMT                                                  AMT                                                                                          ");
		sql.append("      , A.PAY                                                  PAY                                                                                          ");
		sql.append("      , A.WONYOI_ORDER_YN                                      WONYOI_ORDER_YN                                                                              ");
		sql.append("      , A.DANGIL_GUMSA_ORDER_YN                                DANGIL_GUMSA_ORDER_YN                                                                        ");
		sql.append("      , A.DANGIL_GUMSA_RESULT_YN                               DANGIL_GUMSA_RESULT_YN                                                                       ");
		sql.append("      , 'N'                                                    BOM_OCCUR_YN                                                                                 ");
		sql.append("      , A.BOM_SOURCE_KEY                                       BOM_SOURCE_KEY                                                                               ");
		sql.append("      , 'Y'                                                    DISPLAY_YN                                                                                   ");
		sql.append("      , 'N'                                                    SUNAB_YN                                                                                     ");
		sql.append("      , cast(null as datetime)                                 SUNAB_DATE                                                                                   ");
		sql.append("      , 'NULL '                                                  SUNAB_TIME                                                                                   ");
		sql.append("      , cast(null as datetime)                                HOPE_DATE                                                                                    ");
		sql.append("      , 'NULL '                                                  HOPE_TIME                                                                                    ");
		sql.append("      , 'NULL'                                                   NURSE_CONFIRM_USER                                                                           ");
		sql.append("      ,cast(null as datetime)                                  NURSE_CONFIRM_DATE                                                                           ");
		sql.append("      , 'NULL'                                                   NURSE_CONFIRM_TIME                                                                           ");
		sql.append("      , 'NULL'                                                   NURSE_PICKUP_USER                                                                            ");
		sql.append("      , cast(null as datetime)                                 NURSE_PICKUP_DATE                                                                            ");
		sql.append("      , 'NULL'                                                   NURSE_PICKUP_TIME                                                                            ");
		sql.append("      ,' NULL'                                                   NURSE_HOLD_USER                                                                              ");
		sql.append("      , cast(null as datetime)                                 NURSE_HOLD_DATE                                                                              ");
		sql.append("      , 'NULL'                                                   NURSE_HOLD_TIME                                                                              ");
		sql.append("      , cast(null as datetime)                                   RESER_DATE                                                                                   ");
		sql.append("      , 'NULL'                                                   RESER_TIME                                                                                   ");
		sql.append("      , cast(null as datetime)                                   JUBSU_DATE                                                                                   ");
		sql.append("      , 'NULL'                                                   JUBSU_TIME                                                                                   ");
		sql.append("      , cast(null as datetime)                                   ACTING_DATE                                                                                  ");
		sql.append("      , 'NULL'                                                   ACTING_TIME                                                                                  ");
		sql.append("      ,  cast(null AS DECIMAL)                                   ACTING_DAY                                                                                   ");
		sql.append("      , cast(null as datetime)                                   RESULT_DATE                                                                                  ");
		sql.append("      , 'NULL'                                                   DC_GUBUN                                                                                     ");
		sql.append("      , 'NULL'                                                   DC_YN                                                                                        ");
		sql.append("      , 'NULL'                                                   BANNAB_YN                                                                                    ");
		sql.append("      , 'NULL'                                                   BANNAB_CONFIRM                                                                               ");
		sql.append("      , cast(null AS DECIMAL)                                   SOURCE_ORD_KEY                                                                               ");
		sql.append("      , '0'                                                    OCS_FLAG                                                                                     ");
		sql.append("      , 'NULL'                                                   SG_CODE                                                                                      ");
		sql.append("      , cast(null as datetime)                                  SG_YMD                                                                                       ");
		sql.append("      , 'NULL'                                                   IO_GUBUN2                                                                                     ");
		sql.append("      , 'NULL'                                                   AFTER_ACT_YN                                                                                 ");
		sql.append("      , 'NULL'                                                   BICHI_YN                                                                                     ");
		sql.append("      , 'NULL'                                                   DRG_BUNHO                                                                                    ");
		sql.append("      , 'NULL'                                                   SUB_SUSUL                                                                                    ");
		sql.append("      , 'N'                                                    PRINT_YN                                                                                     ");
		sql.append("      , 'NULL'                                                   CHISIK                                                                                       ");
		sql.append("      , 'N'                                                    TEL_YN                                                                                       ");
		sql.append("      , SUBSTR(A.ORDER_GUBUN, 2, 1)                            ORDER_GUBUN_BAS                                                                              ");
		sql.append("      , D.INPUT_CONTROL                                        INPUT_CONTROL                                                                                ");
		sql.append("      , D.SUGA_YN                                              SUGA_YN                                                                                      ");
		sql.append("      , D.JAERYO_YN                                            JAERYO_YN                                                                                    ");
		sql.append("      , case IFNULL(D.WONYOI_ORDER_YN,'Z') when 'Y' then 'N' when  'N' then 'N' else 'Y' end WONYOI_CHECK                                                   ");
		sql.append("      ,case IFNULL(D.EMERGENCY,'Z') when 'Y' then 'N' when 'N' then 'N' else 'Y' end   EMERGENCY_CHECK                                                      ");
		sql.append("      ,case IFNULL(D.SPECIMEN_YN,'Z') when 'Y' then 'N' when 'N' then 'N' else 'Y' end  SPECIMEN_CHECK                                                      ");
		sql.append("      , IFNULL(D.PORTABLE_CHECK, 'N')                             PORTABLE_CHECK                                                                            ");
		sql.append("      , case D.END_DATE when NULL then 'Y' else 'N' end           BULYONG_CHECK                                                                             ");
		sql.append("      , 'N'                                                    SUNAB_CHECK                                                                                  ");
		sql.append("      , 'N'                                                    SUNAB_CHECK2                                                                                  ");
		sql.append("      , case SIGN(A.NALSU) when 1 then 'N' when 0 then 'N' else 'Y' end   DC_CHECK                                                                          ");
		sql.append("      , 'N'                                                    DC_GUBUN_CHECK                                                                               ");
		sql.append("      , 'N'                                                    CONFIRM_CHECK                                                                                ");
		sql.append("      , 'N'                                                    RESER_YN_CHECK                                                                               ");
		sql.append("      , 'N'                                                    CHISIK_CHECK                                                                                 ");
		sql.append("      , A.NDAY_YN                                              NDAY_YN2                                                                                      ");
		sql.append("      , D.INV_JUNDAL_YN                                        DEFAULT_JAERYO_JUNDAL_YN                                                                     ");
		sql.append("      , D.WONYOI_ORDER_YN                                      DEFAULT_WONYOI_ORDER_YN                                                                      ");
		sql.append("      , 'NULL'                                                   SPECIFIC_COMMENTS                                                                            ");
		sql.append("      , 'NULL'                                                   SPECIFIC_COMMENT_NAME                                                                        ");
		sql.append("      , 'NULL'                                                   SPECIFIC_COMMENT_SYS_ID                                                                      ");
		sql.append("      , 'NULL'                                                   SPECIFIC_COMMENT_PGM_ID                                                                      ");
		sql.append("      , CONCAT(IFNULL(SUBSTR(A.ORDER_GUBUN, 2, 1),'') , A.GROUP_SER, A.SEQ ,A.PKOCS0303 )       ORDER_BY_KEY                                              ");
		sql.append("   FROM  OCS0103 D                                                                                                                                          ");
		sql.append("      , OCS0132 C                                                                                                                                           ");
		sql.append("      , OCS0132 B                                                                                                                                           ");
		sql.append("      , (OCS0132 F  RIGHT JOIN OCS0303 A ON F.HOSP_CODE= A.HOSP_CODE AND F.CODE= A.ORD_DANUI                                                                ");
		sql.append("      AND F.CODE_TYPE = 'ORD_DANUI' AND F.LANGUAGE = :f_language )                                                                                          ");
		sql.append("      LEFT JOIN OCS0132 G ON G.HOSP_CODE = A.HOSP_CODE AND G.CODE = A.JUSA  AND G.CODE_TYPE  = 'JUSA' AND G.LANGUAGE = :f_language                          ");
		sql.append("  WHERE :f_order_mode  = '1'                                                                                                                                ");
		sql.append("    AND A.HOSP_CODE    = :f_hosp_code                                                                                                                       ");
		sql.append("    AND A.MEMB         = :f_memb                                                                                                                            ");
		sql.append("    AND A.YAKSOK_CODE  = :f_yaksok_code                                                                                                                     ");
		sql.append("    AND A.INPUT_TAB    = :f_input_tab                                                                                                                       ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                        ");
		sql.append("    AND B.CODE         = A.INPUT_TAB                                                                                                                        ");
		sql.append("    AND B.CODE_TYPE    = 'INPUT_TAB'                                                                                                                        ");
		sql.append("    AND C.HOSP_CODE    = A.HOSP_CODE                                                                                                                        ");
		sql.append("    AND C.CODE         = A.ORDER_GUBUN                                                                                                                      ");
		sql.append("    AND C.CODE_TYPE    = 'ORDER_GUBUN'                                                                                                                      ");
		sql.append("    AND D.HOSP_CODE    = A.HOSP_CODE                                                                                                                        ");
		sql.append("    AND D.HANGMOG_CODE = A.HANGMOG_CODE                                                                                                                     ");
		sql.append("    AND SYSDATE() BETWEEN D.START_DATE AND IFNULL(D.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                            ");
		sql.append("  UNION ALL                                                                                                                                                 ");
		sql.append(" SELECT A.PKOCS1003                                            PK_ORD_KEY                                                                                   ");
		sql.append("      , 'NULL'                                                   MEMB                                                                                         ");
		sql.append("      , 'NULL'                                                   YAKSOK_CODE                                                                                  ");
		sql.append("      , A.BUNHO                                                BUNHO                                                                                        ");
		sql.append("      , 'O'                                                    IO_GUBUN                                                                                     ");
		sql.append("      , A.ORDER_DATE                                           ORDER_DATE                                                                                   ");
	    sql.append("      , DATE_FORMAT(A.SYS_DATE, '%Y-%m-%d %H:%m:%s')           ORDER_TIME                                                                                   ");
		sql.append("      , A.GWA                                                  GWA                                                                                          ");
		sql.append("      , A.DOCTOR                                               DOCTOR                                                                                       ");
		sql.append("      , A.DOCTOR                                               RESIDENT                                                                                     ");
		sql.append("      , E.NAEWON_TYPE                                          NAEWON_TYPE                                                                                  ");
		sql.append("      , A.INPUT_ID                                             INPUT_ID                                                                                     ");
		sql.append("      , A.INPUT_PART                                           INPUT_PART                                                                                   ");
		sql.append("      , A.GWA                                                  INPUT_GWA                                                                                    ");
		sql.append("      , A.DOCTOR                                               INPUT_DOCTOR                                                                                 ");
		sql.append("      , A.INPUT_GUBUN                                          INPUT_GUBUN                                                                                  ");
		sql.append("      , FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN', A.INPUT_GUBUN,A.HOSP_CODE,:f_language)    INPUT_GUBUN_NAME                                                     ");
		sql.append("      , A.GROUP_SER                                            GROUP_SER                                                                                    ");
		sql.append("      , A.INPUT_TAB                                            INPUT_TAB                                                                                    ");
		sql.append("      , B.CODE_NAME                                            INPUT_TAB_NAME                                                                               ");
		sql.append("      , A.ORDER_GUBUN                                          ORDER_GUBUN                                                                                  ");
		sql.append("      , C.CODE_NAME                                            ORDER_GUBUN_NAME                                                                             ");
		sql.append("      , A.NDAY_YN                                              NDAY_YN                                                                                      ");
		sql.append("      , A.SEQ                                                  SEQ                                                                                          ");
		sql.append("      , D.SLIP_CODE                                            SLIP_CODE                                                                                    ");
		sql.append("      , A.HANGMOG_CODE                                         HANGMOG_CODE                                                                                 ");
	    sql.append("      , D.HANGMOG_NAME                                         HANGMOG_NAME                                                                                 ");
		sql.append("      , A.SPECIMEN_CODE                                        SPECIMEN_CODE                                                                                ");
		sql.append("      , FN_OCS_LOAD_SPECIMEN_NAME(A.HOSP_CODE,A.SPECIMEN_CODE)             SPECIMEN_NAME                                                                    ");
		sql.append("      , A.SURYANG                                              SURYANG                                                                                      ");
		sql.append("      , A.SUNAB_SURYANG                                        SUNAB_SURYANG                                                                                ");
		sql.append("      , A.SUBUL_SURYANG                                        SUBUL_SURYANG                                                                                ");
		sql.append("      , A.ORD_DANUI                                            ORD_DANUI                                                                                    ");
		sql.append("      , F.CODE_NAME                                            ORD_DANUI_NAME                                                                               ");
		sql.append("      , A.DV_TIME                                              DV_TIME                                                                                      ");
		sql.append("      , A.DV                                                   DV                                                                                           ");
		sql.append("      , A.DV_1                                                 DV_1                                                                                         ");
		sql.append("      , A.DV_2                                                 DV_2                                                                                         ");
		sql.append("      , A.DV_3                                                 DV_3                                                                                         ");
		sql.append("      , A.DV_4                                                 DV_4                                                                                         ");
		sql.append("      , A.NALSU                                                NALSU                                                                                        ");
		sql.append("      , A.NALSU                                                SUNAB_NALSU                                                                                  ");
		sql.append("      , A.JUSA                                                 JUSA                                                                                         ");
		sql.append("      , G.CODE_NAME                                            JUSA_NAME                                                                                    ");
		sql.append("      , A.JUSA_SPD_GUBUN                                       JUSA_SPD_GUBUN                                                                               ");
		sql.append("      , A.BOGYONG_CODE                                         BOGYONG_CODE                                                                                 ");
		sql.append("      , FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE,A.HOSP_CODE)               BOGYONG_NAME                                                                     ");
		sql.append("      , A.EMERGENCY                                            EMERGENCY                                                                                    ");
		sql.append("      , A.JAERYO_JUNDAL_YN                                     JAERYO_JUNDAL_YN                                                                             ");
		sql.append("      , A.JUNDAL_TABLE                                         JUNDAL_TABLE                                                                                 ");
		sql.append("      , A.JUNDAL_PART                                          JUNDAL_PART                                                                                  ");
		sql.append("      , A.MOVE_PART                                            MOVE_PART                                                                                    ");
		sql.append("      , A.PORTABLE_YN                                          PORTABLE_YN                                                                                  ");
		sql.append("      , A.POWDER_YN                                            POWDER_YN                                                                                    ");
		sql.append("      , A.HUBAL_CHANGE_YN                                      HUBAL_CHANGE_YN                                                                              ");
		sql.append("      , A.PHARMACY                                             PHARMACY                                                                                     ");
		sql.append("      , A.DRG_PACK_YN                                          DRG_PACK_YN                                                                                  ");
		sql.append("      , A.MUHYO                                                MUHYO                                                                                        ");
		sql.append("      , 'NULL'                                                  PRN_YN                                                                           ");
		sql.append("      , 'NULL'                                                   TOIWON_DRG_YN                                                                  ");
		sql.append("      , 'NULL'                                                  PRN_NURSE                                                                       ");
		sql.append("      , 'NULL'                                                   APPEND_YN                                                                      ");
		sql.append("      , A.ORDER_REMARK                                         ORDER_REMARK                                                                                 ");
		sql.append("      , 'NULL'                                                   NURSE_REMARK                                                                               ");
		sql.append("      , A.MIX_GROUP                                            MIX_GROUP                                                                                    ");
		sql.append("      , A.AMT                                                  AMT                                                                                          ");
		sql.append("      , A.PAY                                                  PAY                                                                                          ");
		sql.append("      , A.WONYOI_ORDER_YN                                      WONYOI_ORDER_YN                                                                              ");
		sql.append("      , A.DANGIL_GUMSA_ORDER_YN                                DANGIL_GUMSA_ORDER_YN                                                                        ");
		sql.append("      , A.DANGIL_GUMSA_RESULT_YN                               DANGIL_GUMSA_RESULT_YN                                                                       ");
		sql.append("      , A.BOM_OCCUR_YN                                         BOM_OCCUR_YN                                                                                 ");
		sql.append("      , A.BOM_SOURCE_KEY                                       BOM_SOURCE_KEY                                                                               ");
		sql.append("      , A.DISPLAY_YN                                           DISPLAY_YN                                                                                   ");
		sql.append("      , A.SUNAB_YN                                             SUNAB_YN                                                                                     ");
		sql.append("      , A.SUNAB_DATE                                           SUNAB_DATE                                                                                   ");
		sql.append("      , A.SUNAB_TIME                                           SUNAB_TIME                                                                                   ");
		sql.append("      , A.HOPE_DATE                                            HOPE_DATE                                                                                    ");
		sql.append("      , A.HOPE_TIME                                            HOPE_TIME                                                                                    ");
		sql.append("      , A.NURSE_CONFIRM_USER                                   NURSE_CONFIRM_USER                                                                           ");
		sql.append("      , A.NURSE_CONFIRM_DATE                                   NURSE_CONFIRM_DATE                                                                           ");
		sql.append("      , A.NURSE_CONFIRM_TIME                                   NURSE_CONFIRM_TIME                                                                           ");
		sql.append("      , 'NULL'                                                  NURSE_PICKUP_USER                                                              ");
		sql.append("      , cast(null as datetime)                                NURSE_PICKUP_DATE                                                                            ");
		sql.append("      , 'NULL'                                                   NURSE_PICKUP_TIME                                                              ");
		sql.append("      , 'NULL'                                                   NURSE_HOLD_USER                                                                ");
		sql.append("      , cast(null as datetime)                                 NURSE_HOLD_DATE                                                                              ");
		sql.append("      , 'NULL'                                                  NURSE_HOLD_TIME                                                                ");
		sql.append("      , A.RESER_DATE                                           RESER_DATE                                                                                   ");
		sql.append("      , A.RESER_TIME                                           RESER_TIME                                                                                   ");
		sql.append("      , A.JUBSU_DATE                                           JUBSU_DATE                                                                                   ");
		sql.append("      , A.JUBSU_TIME                                           JUBSU_TIME                                                                                   ");
		sql.append("      , A.ACTING_DATE                                          ACTING_DATE                                                                                  ");
		sql.append("      , A.ACTING_TIME                                          ACTING_TIME                                                                                  ");
		sql.append("      , A.ACTING_DAY                                           ACTING_DAY                                                                                   ");
		sql.append("      , A.RESULT_DATE                                          RESULT_DATE                                                                                  ");
		sql.append("      , A.DC_GUBUN                                             DC_GUBUN                                                                                     ");
		sql.append("      , A.DC_YN                                                DC_YN                                                                                        ");
		sql.append("      , A.BANNAB_YN                                            BANNAB_YN                                                                                    ");
		sql.append("      , A.BANNAB_CONFIRM                                       BANNAB_CONFIRM                                                                               ");
		sql.append("      , A.SOURCE_FKOCS1003                                     SOURCE_ORD_KEY                                                                               ");
		sql.append("      , A.OCS_FLAG                                             OCS_FLAG                                                                                     ");
		sql.append("      , A.SG_CODE                                              SG_CODE                                                                                      ");
		sql.append("      , A.SG_YMD                                               SG_YMD                                                                                       ");
		sql.append("      , A.IO_GUBUN                                             IO_GUBUN2                                                                                     ");
		sql.append("      , A.AFTER_ACT_YN                                         AFTER_ACT_YN                                                                                 ");
		sql.append("      , A.BICHI_YN                                             BICHI_YN                                                                                     ");
		sql.append("      , A.DRG_BUNHO                                            DRG_BUNHO                                                                                    ");
		sql.append("      , A.SUB_SUSUL                                            SUB_SUSUL                                                                                    ");
		sql.append("      , A.PRINT_YN                                             PRINT_YN                                                                                     ");
		sql.append("      , A.CHISIK                                               CHISIK                                                                                       ");
		sql.append("      , A.TEL_YN                                               TEL_YN                                                                                       ");
		sql.append("      , SUBSTR(A.ORDER_GUBUN, 2, 1)                            ORDER_GUBUN_BAS                                                                              ");
		sql.append("      , D.INPUT_CONTROL                                        INPUT_CONTROL                                                                                ");
		sql.append("      , D.SUGA_YN                                              SUGA_YN                                                                                      ");
		sql.append("      , D.JAERYO_YN                                            JAERYO_YN                                                                                    ");
		sql.append("      , case IFNULL(D.WONYOI_ORDER_YN,'Z') when 'Y' then 'N' when 'N' then 'N' else 'Y' end WONYOI_CHECK                                                    ");
		sql.append("      , case IFNULL(D.EMERGENCY,'Z')  when 'Y' then 'N' when 'N' then 'N' else 'Y' end   EMERGENCY_CHECK                                                    ");
		sql.append("      , case IFNULL(D.SPECIMEN_YN,'Z') when 'Y' then 'N' when 'N' then 'N' else 'Y' end    SPECIMEN_CHECK                                                   ");
		sql.append("      , IFNULL(D.PORTABLE_CHECK, 'N')                             PORTABLE_CHECK                                                                            ");
		sql.append("      ,case D.END_DATE when NULL then 'Y' else 'N'  end        BULYONG_CHECK                                                                                ");
		sql.append("      , case A.SUNAB_DATE when NULL then 'N' else 'Y'  end     SUNAB_CHECK                                                                                  ");
		sql.append("      , case A.SUNAB_DATE when NULL then 'N' else 'Y'  end     SUNAB_CHECK2                                                                                  ");
		sql.append("      , case SIGN(A.NALSU) when 1 then 'N' when 0 then 'N' else 'Y'  end          DC_CHECK                                                                  ");
		sql.append("      , 'N'                                                    DC_GUBUN_CHECK                                                                               ");
		sql.append("      , case A.NURSE_CONFIRM_DATE when NULL then 'N' else 'Y' end  CONFIRM_CHECK                                                                            ");
		sql.append("      ,case D.RESER_YN_OUT when 'Y' then 'Y' else 'N' end       RESER_YN_CHECK                                                                              ");
		sql.append("      , case A.CHISIK when NULL then 'N' else 'Y' end          CHISIK_CHECK                                                                                 ");
		sql.append("      , A.NDAY_YN                                              NDAY_YN2                                                                                      ");
		sql.append("      , D.INV_JUNDAL_YN                                        DEFAULT_JAERYO_JUNDAL_YN                                                                     ");
		sql.append("      , D.WONYOI_ORDER_YN                                      DEFAULT_WONYOI_ORDER_YN                                                                      ");
		sql.append("      , H.SPECIFIC_COMMENT                                     SPECIFIC_COMMENTS                                                                            ");
		sql.append("      , H.SPECIFIC_COMMENT_NAME                                SPECIFIC_COMMENT_NAME                                                                        ");
		sql.append("      , H.SPECIFIC_COMMENT_SYS_ID                              SPECIFIC_COMMENT_SYS_ID                                                                      ");
		sql.append("      , H.SPECIFIC_COMMENT_PGM_ID                              SPECIFIC_COMMENT_PGM_ID                                                                      ");
		sql.append("      , CONCAT(IFNULL(SUBSTR(A.ORDER_GUBUN, 2, 1),'') , A.GROUP_SER, A.SEQ ,A.PKOCS1003 )              ORDER_BY_KEY                                         ");
		sql.append("   FROM OUT1001 E                                                                                                                                           ");
		sql.append("      , OCS0132 C                                                                                                                                           ");
		sql.append("      , OCS0132 B                                                                                                                                           ");
		sql.append("      , (((OCS0132 F RIGHT JOIN  OCS1003 A ON F.HOSP_CODE  = A.HOSP_CODE AND F.CODE  = A.ORD_DANUI                                                          ");
		sql.append("      AND F.CODE_TYPE = 'ORD_DANUI' AND F.LANGUAGE = :f_language )                                                                                          ");
		sql.append("      LEFT JOIN  OCS0132 G ON  G.HOSP_CODE = A.HOSP_CODE AND G.CODE = A.JUSA  AND G.CODE_TYPE = 'JUSA' AND G.LANGUAGE = :f_language)                        ");
		if(request.equalsIgnoreCase("OCS0103U13GrdOrderListRequest")){
			sql.append("      LEFT JOIN OCS0170 H ON H.HOSP_CODE = A.HOSP_CODE ) RIGHT JOIN OCS0103 D ON H.SPECIFIC_COMMENT = D.SPECIFIC_COMMENT                                    ");
		} else{
			sql.append("      ,OCS0170 H  RIGHT JOIN OCS0103 D ON  H.HOSP_CODE = D.HOSP_CODE AND H.SPECIFIC_COMMENT = D.SPECIFIC_COMMENT                                    ");
		}
		sql.append("                                                                                                                                                            ");
		sql.append("  WHERE :f_order_mode      = '2'                                                                                                   					        ");
		sql.append("    AND A.HOSP_CODE        = :f_hosp_code                                                                                                                   ");
		sql.append("    AND A.FKOUT1001        = :f_fk_in_out_key                                                                                                               ");
		sql.append("    AND A.INPUT_TAB        = :f_input_tab                                                                                                                   ");
		sql.append("    AND B.HOSP_CODE        = A.HOSP_CODE                                                                                                                    ");
		sql.append("    AND B.CODE             = A.INPUT_TAB                                                                                                                    ");
		sql.append("    AND B.CODE_TYPE        = 'INPUT_TAB'                                                                                                                    ");
		sql.append("    AND C.HOSP_CODE        = A.HOSP_CODE                                                                                                                    ");
		sql.append("    AND C.CODE             = A.ORDER_GUBUN                                                                                                                  ");
		sql.append("    AND C.CODE_TYPE        = 'ORDER_GUBUN'                                                                                                                  ");
		sql.append("    AND D.HOSP_CODE        = A.HOSP_CODE                                                                                                                    ");
		sql.append("    AND D.HANGMOG_CODE     = A.HANGMOG_CODE                                                                                                                 ");
		sql.append("    AND SYSDATE()     BETWEEN D.START_DATE AND IFNULL(D.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                        ");
		sql.append("    AND E.HOSP_CODE        = A.HOSP_CODE                                                                                                                    ");
		sql.append("    AND E.PKOUT1001        = A.FKOUT1001                                                                                                                    ");
		sql.append("  ORDER BY ORDER_BY_KEY																																		");

		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language",language );
		query.setParameter("f_order_mode",orderMode );
		query.setParameter("f_memb", memb);
		query.setParameter("f_yaksok_code", yaksolCode);
		query.setParameter("f_input_tab",inputTab );
		query.setParameter("f_fk_in_out_key", fkInOutKey); 
		
		List<OCS0103U13GrdOrderListInfo> listResult= new JpaResultMapper().list(query, OCS0103U13GrdOrderListInfo.class);
		return listResult;
	}
	@Override
	public List<OCS0103U12GrdSangyongOrderInfo> getOCS0103U12GrdSangyongOrder(
			String user, String hospCode, String ioGubun, String orderGubun,
			Date orderDate, String searchWord, String wonnaeDrgYn, String protocolId, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DD.SLIP_CODE                SLIP_CODE     ,                					");           
		sql.append("	       DD.SLIP_NAME                SLIP_NAME     ,                                  ");
		sql.append("	       DD.HANGMOG_CODE             HANGMOG_CODE  ,                                  ");
		sql.append("	       DD.HANGMOG_NAME             HANGMOG_NAME  ,                                  ");
		sql.append("	       ''                          SEQ           ,                                  ");
		sql.append("	       DD.HOSP_CODE                HOSP_CODE     ,                                  ");
		sql.append("	       :user                       MEMB          ,                                  ");
		sql.append("	       ''                          MEMB_GUBUN    ,                                  ");
		sql.append("	       IFNULL(DD.WONNAE_DRG_YN, 'N')  WONNAE_DRG_YN ,                               ");
		sql.append("		   DD.TRIAL_FLG 							TRIAL_FLG,							");
		sql.append("	      CAST( DD.ROWNUM  AS UNSIGNED)                                                 ");
		sql.append("	  FROM ( SELECT  @rank \\:=@rank+1 ROWNUM,                                          ");
		sql.append("	      AA.* from ( SELECT DISTINCT                                                   ");
		sql.append("	               :user            DOCTOR,                                             ");
		sql.append("	               B.SLIP_CODE      SLIP_CODE,                                          ");
		sql.append("	               C.SLIP_NAME      SLIP_NAME,                                          ");
		sql.append("	               A.HANGMOG_CODE   HANGMOG_CODE,                                       ");
		sql.append("	               B.HANGMOG_NAME   HANGMOG_NAME,                                       ");
		sql.append("	               ''               SEQ,                                                ");
		sql.append("	               A.HOSP_CODE      HOSP_CODE,                                          ");
		sql.append("	               ''               MEMB_GUBUN,                                         ");
		sql.append("	               IFNULL(B.WONNAE_DRG_YN, 'N')     WONNAE_DRG_YN,                      ");
		sql.append("	               B.TRIAL_FLG TRIAL_FLG,                                               ");
		sql.append("	               COUNT(*)                                                             ");
		sql.append("	          FROM OCS2003 A                                                            ");
		sql.append("	              ,OCS0103 B                                                            ");
		sql.append("	           ,OCS0102 C                                                               ");
		sql.append("	         WHERE A.HOSP_CODE               = :hospCode                                ");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))            ");
		}else{
			sql.append("	 AND B.TRIAL_FLG = 'N'                                                                              ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                ");
		sql.append("	           AND 'I'                       = :ioGubun                                 ");
		sql.append("	           AND SUBSTR(A.INPUT_DOCTOR, 3) = :user                                    ");
		sql.append("	           AND B.ORDER_GUBUN             = :orderGubun                              ");
		sql.append("	           AND B.HOSP_CODE               = A.HOSP_CODE                              ");
		sql.append("	           AND B.HANGMOG_CODE            = A.HANGMOG_CODE                           ");
		sql.append("	           AND :orderDate BETWEEN B.START_DATE                                      ");
		sql.append("	                                 AND B.END_DATE                                     ");
		sql.append("	           AND B.HANGMOG_NAME_INX LIKE	:searchWord				                    ");
		sql.append("	           AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :wonnaeDrgYn                      " );
		sql.append("	           AND C.HOSP_CODE = B.HOSP_CODE                                            ");
		sql.append("	           AND C.SLIP_CODE = B.SLIP_CODE                                            ");
		sql.append("	           AND C.LANGUAGE = :language                                            	");
		sql.append("	         GROUP BY :user       	                                                    ");
		sql.append("	                , B.SLIP_CODE                                                       ");
		sql.append("	                , C.SLIP_NAME                                                       ");
		sql.append("	                , A.HANGMOG_CODE                                                    ");
		sql.append("	                , B.HANGMOG_NAME                                                    ");
		sql.append("	                , ''                                                                ");
		sql.append("	                , A.HOSP_CODE                                                       ");
		sql.append("	                , IFNULL(B.WONNAE_DRG_YN, 'N')                                      ");
		sql.append("	                                                                                    ");
		sql.append("	        UNION ALL                                                                   ");
		sql.append("	                                                                                    ");
		sql.append("	        SELECT DISTINCT                                                             ");
		sql.append("	               :user           DOCTOR      ,                                        ");
		sql.append("	               B.SLIP_CODE      SLIP_CODE   ,                                       ");
		sql.append("	               C.SLIP_NAME      SLIP_NAME,                                          ");
		sql.append("	               A.HANGMOG_CODE   HANGMOG_CODE,                                       ");
		sql.append("	               B.HANGMOG_NAME   HANGMGO_NAME,                                       ");
		sql.append("	               ''               SEQ         ,                                       ");
		sql.append("	               A.HOSP_CODE      HOSP_CODE   ,                                       ");
		sql.append("	               ''               MEMB_GUBUN  ,                                       ");
		sql.append("	               IFNULL(B.WONNAE_DRG_YN, 'N')     WONNAE_DRG_YN,                      ");
		sql.append("	               B.TRIAL_FLG TRIAL_FLG,                                               ");
		sql.append("	               COUNT(*)                                                             ");
		sql.append("	          FROM OCS1003 A                                                            ");
		sql.append("	              ,OCS0103 B                                                            ");
		sql.append("	              ,OCS0102 C                                                            ");
		sql.append("	         WHERE A.HOSP_CODE              = :hospCode                                 ");
		if(!StringUtils.isEmpty(protocolId)){
			sql.append("	 AND (B.TRIAL_FLG = 'N' OR (B.TRIAL_FLG = 'Y' AND B.CLIS_PROTOCOL_ID = :f_protocol_id ))            ");
		}else{
			sql.append("	 AND B.TRIAL_FLG = 'N'                                                                              ");
		}
		sql.append("     AND IFNULL(B.COMMON_YN, 'N') != 'Y'                                                ");
		sql.append("	           AND 'O'                      = :ioGubun                                  ");
		sql.append("	           AND SUBSTR(A.DOCTOR, 3)      = :user                                     ");
		sql.append("	           AND B.ORDER_GUBUN            = :orderGubun                               ");
		sql.append("	           AND B.HOSP_CODE              = A.HOSP_CODE                               ");
		sql.append("	           AND B.HANGMOG_CODE           = A.HANGMOG_CODE                            ");
		sql.append("	           AND :orderDate BETWEEN B.START_DATE             	                        ");
		sql.append("	                                 AND B.END_DATE                                     ");
		sql.append("	           AND B.HANGMOG_NAME_INX LIKE :searchWord				                    ");
		sql.append("	           AND IFNULL(B.WONNAE_DRG_YN, 'N') LIKE :wonnaeDrgYn                       ");
		sql.append("	           AND C.HOSP_CODE = B.HOSP_CODE                                            ");
		sql.append("	           AND C.SLIP_CODE = B.SLIP_CODE                                            ");
		sql.append("	           AND C.LANGUAGE = :language                                            	");
		sql.append("	         GROUP BY :user        	                                                    ");
		sql.append("	                , B.SLIP_CODE                                                       ");
		sql.append("	                , C.SLIP_NAME                                                       ");
		sql.append("	                , A.HANGMOG_CODE                                                    ");
		sql.append("	                , B.HANGMOG_NAME                                                    ");
		sql.append("	                , ''                                                                ");
		sql.append("	                , A.HOSP_CODE                                                       ");
		sql.append("	                , IFNULL(B.WONNAE_DRG_YN, 'N')                                      ");
		sql.append("	        ORDER BY 10 DESC                                                            ");
		sql.append("	      )  AA , (SELECT @rank \\:=0) r) DD                                            ");
		sql.append("	      WHERE DD.ROWNUM < 50 															 ");

		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("user", user);
		query.setParameter("hospCode", hospCode);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("orderGubun", orderGubun);
		query.setParameter("orderDate", orderDate);
		query.setParameter("searchWord", searchWord);
		query.setParameter("wonnaeDrgYn", wonnaeDrgYn);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(protocolId)){
			query.setParameter("f_protocol_id", CommonUtils.parseInteger(protocolId));
		}
		
		List<OCS0103U12GrdSangyongOrderInfo> list = new JpaResultMapper().list(query, OCS0103U12GrdSangyongOrderInfo.class);
		return list;
	}
	@Override
	public String callFnOcsCheckOrderInputYn(String hospCode, String language,
			String iudGubun, String ioGubun, Double pkOcsKey) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_OCS_CHECK_ORDER_INPUT_YN(:hospCode, :language, :iudGubun, :ioGubun, :pkOcsKey)");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("iudGubun", iudGubun);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("pkOcsKey", pkOcsKey);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String callFnRehIsResultToConsult(String hospCode, String pkOcsKey,
			String ioGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_REH_IS_RESULT_TO_CONSULT(:hospCode, :pkOcsKey, :ioGubun) ");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkOcsKey", pkOcsKey);
		query.setParameter("ioGubun", ioGubun);

		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public Integer getOrderCount(String hospCode, String ioGunbun, String bunho, Date orderDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_ORDER_COUNT(:f_hosp_code,:f_io_gubun,:f_bunho,:f_order_date) ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_io_gubun", ioGunbun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);

		List<Integer> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0);
		}
		return null;
	}
	
	public String getDupCheckInputOutOrder(String hospCode, String language, String bunho,
			Date naewonDate, String hangmogCode, Date hopeDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_DUP_OUT_ORDER_CHECK(:f_hosp_code,:f_language,:f_bunho,:f_naewon_date,:f_hangmog_code,:f_hope_date) ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_hope_date", hopeDate);

		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0);
		}
		return null;
		
	}

	@Override
	public List<OCS1003Q02LayQueryLayoutInfo> getOCS1003Q02LayQueryLayoutInfo(String hospCode, String language, String bunho, Double fkout1001,
			String queryGubun, String inputGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.FKOUT1001                                          IN_OUT_KEY                                                                                        " );
		sql.append("      , A.PKOCS1003                                          PKOCSKEY                                                                                          " );
		sql.append("      , A.BUNHO                                              BUNHO                                                                                             " );
		sql.append("      , DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                  ORDER_DATE                                                                                      " );
		sql.append("      , A.GWA                                                GWA                                                                                               " );
		sql.append("      , A.DOCTOR                                             DOCTOR                                                                                            " );
		sql.append("      , A.DOCTOR                                             RESIDENT                                                                                          " );
		sql.append("      , A.NAEWON_TYPE                                        NAEWON_TYPE                                                                                       " );
		sql.append("      , E.JUBSU_NO                                           JUBSU_NO                                                                                          " );
		sql.append("      , A.INPUT_ID                                           INPUT_ID                                                                                          " );
		sql.append("      , A.INPUT_PART                                         INPUT_PART                                                                                        " );
		sql.append("      , A.GWA                                                INPUT_GWA                                                                                         " );
		sql.append("      , A.INPUT_ID                                           INPUT_DOCTOR                                                                                      " );
		sql.append("      , A.INPUT_GUBUN                                        INPUT_GUBUN                                                                                       " );
		sql.append("      , FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN', A.INPUT_GUBUN,:f_hosp_code,:f_language)  INPUT_GUBUN_NAME                                                         " );
		sql.append("      , A.GROUP_SER                                          GROUP_SER                                                                                         " );
		sql.append("      , A.INPUT_TAB                                          INPUT_TAB                                                                                         " );
		sql.append("      , FN_OCS_LOAD_CODE_NAME('INPUT_TAB', A.INPUT_TAB,:f_hosp_code,:f_language)      INPUT_TAB_NAME                                                           " );
		sql.append("      , A.ORDER_GUBUN                                        ORDER_GUBUN                                                                                       " );
		sql.append("      , FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN', A.ORDER_GUBUN,:f_hosp_code,:f_language)  ORDER_GUBUN_NAME                                                         " );
		sql.append("      , B.GROUP_YN                                           GROUP_YN                                                                                          " );
		sql.append("      , A.SEQ                                                SEQ                                                                                               " );
		sql.append("      , A.SLIP_CODE                                          SLIP_CODE                                                                                         " );
		sql.append("      , A.HANGMOG_CODE                                       HANGMOG_CODE                                                                                      " );
		sql.append("      , B.HANGMOG_NAME                                       HANGMOG_NAME                                                                                      " );
		sql.append("      , A.SPECIMEN_CODE                                      SPECIMEN_CODE                                                                                     " );
		sql.append("      , C.SPECIMEN_NAME                                      SPECIMEN_NAME                                                                                     " );
		sql.append("      , A.SURYANG                                            SURYANG                                                                                           " );
		sql.append("      , A.SUNAB_SURYANG                                      SUNAB_SURYANG                                                                                     " );
		sql.append("      , A.SUBUL_SURYANG                                      SUBUL_SURYANG                                                                                     " );
		sql.append("      , A.ORD_DANUI                                          ORD_DANUI                                                                                         " );
		sql.append("      , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code,:f_language)      ORD_DANUI_NAME                                                           " );
		sql.append("      , A.DV_TIME                                            DV_TIME                                                                                           " );
		sql.append("      , A.DV                                                 DV                                                                                                " );
		sql.append("      , A.DV_1                                               DV_1                                                                                              " );
		sql.append("      , A.DV_2                                               DV_2                                                                                              " );
		sql.append("      , A.DV_3                                               DV_3                                                                                              " );
		sql.append("      , A.DV_4                                               DV_4                                                                                              " );
		sql.append("      , A.NALSU                                              NALSU                                                                                             " );
		sql.append("      , 'NULL'                                                SUNAB_NALSU                                                                                        " );
		sql.append("      , A.JUSA                                               JUSA                                                                                              " );
		sql.append("      , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA,:f_hosp_code,:f_language)                JUSA_NAME                                                                " );
		sql.append("      , A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN                                                                                    " );
		sql.append("      , A.BOGYONG_CODE                                       BOGYONG_CODE                                                                                      " );
		sql.append("      , CASE WHEN (B.INPUT_CONTROL = 'A')                                                                                                                      " );
		sql.append("             THEN FN_CHT_LOAD_CHT0117_NAME ( A.BOGYONG_CODE,:f_hosp_code, :f_language )                                                                        " );
		sql.append("             ELSE FN_DRG_LOAD_BOGYONG_NAME ( A.BOGYONG_CODE,:f_hosp_code )                                                                                     " );
		sql.append("        END                                                  BOGYONG_NAME                                                                                      " );
		sql.append("      , A.EMERGENCY                                          EMERGENCY                                                                                         " );
		sql.append("      , A.JAERYO_JUNDAL_YN                                   JAERYO_JUNDAL_YN                                                                                  " );
		sql.append("      , A.JUNDAL_TABLE                                       JUNDAL_TABLE                                                                                      " );
		sql.append("      , A.JUNDAL_PART                                        JUNDAL_PART                                                                                       " );
		sql.append("      , A.MOVE_PART                                          MOVE_PART                                                                                         " );
		sql.append("      , A.PORTABLE_YN                                        PORTABLE_YN_1                                                                                       " );
		sql.append("      , A.POWDER_YN                                          POWDER_YN                                                                                         " );
		sql.append("      , A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN                                                                                   " );
		sql.append("      , A.PHARMACY                                           PHARMACY                                                                                          " );
		sql.append("      , A.DRG_PACK_YN                                        DRG_PACK_YN                                                                                       " );
		sql.append("      , A.MUHYO                                              MUHYO                                                                                             " );
		sql.append("      , 'NULL'                                                 PRN_YN                                                                                            " );
		sql.append("      , 'NULL'                                                 TOIWON_DRG_YN                                                                                     " );
		sql.append("      , 'NULL'                                                 PRN_NURSE                                                                                         " );
		sql.append("      , 'NULL'                                                 APPEND_YN                                                                                         " );
		sql.append("      , A.ORDER_REMARK                                       ORDER_REMARK                                                                                      " );
		sql.append("      , A.NURSE_REMARK                                       NURSE_REMARK                                                                                      " );
		sql.append("      , 'NULL'                                                 COMMENTS                                                                                          " );
		sql.append("      , A.MIX_GROUP                                          MIX_GROUP                                                                                         " );
		sql.append("      , A.AMT                                                AMT                                                                                               " );
		sql.append("      , A.PAY                                                PAY                                                                                               " );
		sql.append("      , A.WONYOI_ORDER_YN                                    WONYOI_ORDER_YN                                                                                   " );
		sql.append("      , A.DANGIL_GUMSA_ORDER_YN                              DANGIL_GUMSA_ORDER_YN                                                                             " );
		sql.append("      , A.DANGIL_GUMSA_RESULT_YN                             DANGIL_GUMSA_RESULT_YN                                                                            " );
		sql.append("      , A.BOM_OCCUR_YN                                       BOM_OCCUR_YN                                                                                      " );
		sql.append("      , A.BOM_SOURCE_KEY                                     BOM_SOURCE_KEY                                                                                    " );
		sql.append("      , A.DISPLAY_YN                                         DISPLAY_YN                                                                                        " );
		sql.append("      , A.SUNAB_YN                                           SUNAB_YN                                                                                          " );
		sql.append("      , DATE_FORMAT(A.SUNAB_DATE, '%Y/%m/%d')                  SUNAB_DATE                                                                                      " );
		sql.append("      , A.SUNAB_TIME                                         SUNAB_TIME                                                                                        " );
		sql.append("      , DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')                   HOPE_DATE                                                                                       " );
		sql.append("      , A.HOPE_TIME                                          HOPE_TIME                                                                                         " );
		sql.append("      , A.NURSE_CONFIRM_USER                                 NURSE_CONFIRM_USER                                                                                " );
		sql.append("      , DATE_FORMAT(A.NURSE_CONFIRM_DATE, '%Y/%m/%d')          NURSE_CONFIRM_DATE                                                                              " );
		sql.append("      , A.NURSE_CONFIRM_TIME                                 NURSE_CONFIRM_TIME                                                                                " );
		sql.append("      , 'NULL'                                                 NURSE_PICKUP_USER                                                                                 " );
		sql.append("      , 'NULL'                                                 NURSE_PICKUP_DATE                                                                                 " );
		sql.append("      , 'NULL'                                                 NURSE_PICKUP_TIME                                                                                 " );
		sql.append("      , 'NULL'                                                 NURSE_HOLD_USER                                                                                   " );
		sql.append("      , 'NULL'                                                 NURSE_HOLD_DATE                                                                                   " );
		sql.append("      , 'NULL'                                                 NURSE_HOLD_TIME                                                                                   " );
		sql.append("      , DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d')                  RESER_DATE                                                                                      " );
		sql.append("      , A.RESER_TIME                                         RESER_TIME                                                                                        " );
		sql.append("      , DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')                  JUBSU_DATE                                                                                      " );
		sql.append("      , A.JUBSU_TIME                                         JUBSU_TIME                                                                                        " );
		sql.append("      , DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d')                 ACTING_DATE                                                                                     " );
		sql.append("      , A.ACTING_TIME                                        ACTING_TIME                                                                                       " );
		sql.append("      , A.ACTING_DAY                                         ACTING_DAY                                                                                        " );
		sql.append("      , DATE_FORMAT(A.RESULT_DATE , '%Y/%m/%d')                RESULT_DATE                                                                                     " );
		sql.append("      , A.DC_GUBUN                                           DC_GUBUN                                                                                          " );
		sql.append("      , A.DC_YN                                              DC_YN                                                                                             " );
		sql.append("      , A.BANNAB_YN                                          BANNAB_YN                                                                                         " );
		sql.append("      , A.BANNAB_CONFIRM                                     BANNAB_CONFIRM                                                                                    " );
		sql.append("      , A.SOURCE_FKOCS1003                                   SOURCE_ORD_KEY                                                                                    " );
		sql.append("      , A.OCS_FLAG                                           OCS_FLAG                                                                                          " );
		sql.append("      , A.SG_CODE                                            SG_CODE                                                                                           " );
		sql.append("      , A.SG_YMD                                             SG_YMD                                                                                            " );
		sql.append("      , A.IO_GUBUN                                           IO_GUBUN                                                                                          " );
		sql.append("      , A.AFTER_ACT_YN                                       AFTER_ACT_YN                                                                                      " );
		sql.append("      , A.BICHI_YN                                           BICHI_YN                                                                                          " );
		sql.append("      , A.DRG_BUNHO                                          DRG_BUNHO                                                                                         " );
		sql.append("      , A.SUB_SUSUL                                          SUB_SUSUL                                                                                         " );
		sql.append("      , A.PRINT_YN                                           PRINT_YN                                                                                          " );
		sql.append("      , A.CHISIK                                             CHISIK                                                                                            " );
		sql.append("      , A.TEL_YN                                             TEL_YN                                                                                            " );
		sql.append("      , B.ORDER_GUBUN                                        ORDER_GUBUN_BAS                                                                                   " );
		sql.append("      , B.INPUT_CONTROL                                      INPUT_CONTROL                                                                                     " );
		sql.append("      , B.SUGA_YN                                            SUGA_YN                                                                                           " );
		sql.append("      , B.JAERYO_YN                                          JAERYO_YN                                                                                         " );
		sql.append("      , case B.WONYOI_ORDER_YN when 'Z' then 'Y' else 'N' end    WONYOI_CHECK                                                                                  " );
		sql.append("      , case IFNULL(B.EMERGENCY, 'Z') when 'Z' then 'Y' else IFNULL(B.EMERGENCY, 'Z') end                                                                      " );
		sql.append("                                                             EMERGENCY_CHECK                                                                                   " );
		sql.append("      , B.SPECIMEN_YN                                        SPECIMEN_CHECK                                                                                    " );
		sql.append("      , A.PORTABLE_YN                                        PORTABLE_YN_2                                                                                       " );
		sql.append("      , CASE WHEN B.END_DATE IS NULL THEN 'N'                                                                                                                  " );
		sql.append("             WHEN B.END_DATE = DATE_FORMAT('99981231','%Y%m%d') THEN 'N'                                                                                       " );
		sql.append("             ELSE 'Y'                                                                                                                                          " );
		sql.append("        END                                                  BULYONG_CHECK                                                                                     " );
		sql.append("      ,case  A.SUNAB_DATE when NULL then 'N' else 'Y' end    SUNAB_CHECK                                                                                       " );
		sql.append("      ,case SIGN(A.NALSU) when 1 then 'N' when 0 then 'N' else 'Y' end                                                                                         " );
		sql.append("                                                             DC_CHECK                                                                                          " );
		sql.append("      , A.DC_GUBUN                                           DC_GUBUN_CHECK                                                                                    " );
		sql.append("      ,case A.NURSE_CONFIRM_DATE when NULL then 'N' else 'Y' end                                                                                               " );
		sql.append("                                                             CONFIRM_CHECK                                                                                     " );
		sql.append("      ,case A.RESER_DATE when NULL then 'N' else 'Y' end                                                                                                       " );
		sql.append("                                                             RESER_YN_CHECK                                                                                    " );
		sql.append("      ,case A.CHISIK when NULL then 'N' else 'Y' end                                                                                                           " );
		sql.append("                                                             CHISIK_YN                                                                                         " );
		sql.append("      , A.NDAY_YN                                            NDAY_YN                                                                                           " );
		sql.append("      , FN_OCS_LOAD_JAERYO_JUNDAL_YN (:f_hosp_code,'O', A.INPUT_PART,                                                                                          " );
		sql.append("                                      A.HANGMOG_CODE)        DEFAULT_JAERYO_JUNDAL_YN                                                                          " );
		sql.append("      , CASE WHEN (A.ORDER_GUBUN NOT IN ('A', 'B', 'C', 'D')                                                                                                   " );
		sql.append("                     OR A.WONYOI_ORDER_YN = 'Z'                                                                                                                " );
		sql.append("                     OR A.WONYOI_ORDER_YN = 'Y'                                                                                                                " );
		sql.append("                    )                                                                                                                                          " );
		sql.append("                    THEN 'N'                                                                                                                                   " );
		sql.append("                    ELSE 'Y' END                             DEFAULT_WONYOI_YN                                                                                 " );
		sql.append("      , D.SPECIFIC_COMMENT                                   SPECIFIC_COMMENT                                                                                  " );
		sql.append("      , D.SPECIFIC_COMMENT_NAME                              SPECIFIC_COMMENT_NAME                                                                             " );
		sql.append("      , D.SPECIFIC_COMMENT_SYS_ID                            SPECIFIC_COMMENT_SYS_ID                                                                           " );
		sql.append("      , D.SPECIFIC_COMMENT_PGM_ID                            SPECIFIC_COMMENT_PGM_ID                                                                           " );
		sql.append("      , D.SPECIFIC_COMMENT_NOT_NULL                          SPECIFIC_COMMENT_NOT_NULL                                                                         " );
		sql.append("      , D.SPECIFIC_COMMENT_TABLE_ID                          SPECIFIC_COMMENT_TABLE_ID                                                                         " );
		sql.append("      , D.SPECIFIC_COMMENT_COL_ID                            SPECIFIC_COMMENT_COL_ID                                                                           " );
		sql.append("      , FN_DRG_LOAD_DONBOK_YN ( A.BOGYONG_CODE,:f_hosp_code )             DONBOG_YN                                                                            " );
		sql.append("      , FN_OCS_LOAD_CODE_NAME ( 'ORDER_GUBUN_BAS', SUBSTR(A.ORDER_GUBUN, 2, 1),:f_hosp_code,:f_language)                                                       " );
		sql.append("                                                             ORDER_GUBUN_BAS_NAME                                                                              " );
		sql.append("      , A.ACT_DOCTOR                                         ACT_DOCTOR                                                                                        " );
		sql.append("      , A.ACT_BUSEO                                          ACT_BUSEO                                                                                         " );
		sql.append("      , A.ACT_GWA                                            ACT_GWA                                                                                           " );
		sql.append("      , A.HOME_CARE_YN                                       HOME_CARE_YN                                                                                      " );
		sql.append("      , A.REGULAR_YN                                         REGULAR_YN                                                                                        " );
		sql.append("      , A.SORT_FKOCSKEY                                      SORT_FKOCSKEY                                                                                     " );
		sql.append("      , CASE WHEN ((case A.BOM_SOURCE_KEY when NULL then FN_OCS_LOAD_CHILD_GUBUN(:f_hosp_code,'O',A.PKOCS1003) else '3' end)!= '3')                            " );
		sql.append("                  THEN 'N'                                                                                                                                     " );
		sql.append("                  ELSE 'Y'                                                                                                                                     " );
		sql.append("        END                                                  CHILD_YN                                                                                          " );
		sql.append("      , B.IF_INPUT_CONTROL                                   IF_INPUT_CONTROL                                                                                  " );
		sql.append("      , F.SLIP_NAME                                          SLIP_NAME                                                                                         " );
		sql.append("      , A.PKOCS1003                                          ORG_KEY                                                                                           " );
		sql.append("      , A.BOM_SOURCE_KEY                                     PARENT_KEY                                                                                        " );
		sql.append("      , G.BUN_CODE                                           BUN_CODE                                                                                          " );
		sql.append("      , DV_5                                                                                                                                                   " );
		sql.append("      , DV_6                                                                                                                                                   " );
		sql.append("      , DV_7                                                                                                                                                   " );
		sql.append("      , DV_8                                                                                                                                                   " );
		sql.append("      , CASE WHEN (B.ORDER_GUBUN IN ( 'B', 'C', 'D') )                                                                                                         " );
		sql.append("                  THEN IFNULL(B.WONNAE_DRG_YN, 'N')                                                                                                            " );
		sql.append("                  ELSE '%'                                                                                                                                     " );
		sql.append("        END                                                  WONNAE_DRG_YN                                                                                     " );
		sql.append("      , IFNULL(H.TOIJANG_YN, 'N')                               HUBAL_CHANGE_CHECK                                                                             " );
		sql.append("      , IFNULL(H.CHK3, 'N')                                     DRG_PACK_CHECK                                                                                 " );
		sql.append("      , IFNULL(H.CHK2, 'N')                                     PHARMACY_CHECK                                                                                 " );
		sql.append("      , IFNULL(H.CHK1, 'N')                                     POWER_CHECK                                                                                    " );
		sql.append("      , IFNULL(A.IMSI_DRUG_YN, 'N')                             IMSI_DRUG_YN                                                                                   " );
		sql.append("                                                                                                                                                               " );
		sql.append("      , FN_OCS_LOAD_ORDER_SORT_KEY('O', A.PKOCS1003,:f_hosp_code)         ORDER_BY_KEY                                                                         " );
		sql.append("   FROM                                                                                                                                                        " );
		sql.append("       OCS0102 F                                                                                                                                               " );
		sql.append("      , OUT1001 E                                                                                                                                              " );
		sql.append("      , ( OCS0170 D RIGHT JOIN OCS0103 B ON D.HOSP_CODE = B.HOSP_CODE AND D.SPECIFIC_COMMENT = B.SPECIFIC_COMMENT)                                             " );
		sql.append("      LEFT JOIN ( SELECT A.SG_CODE                                                                                                                             " );
		sql.append("               , A.SG_NAME                                                                                                                                     " );
		sql.append("               , A.BUN_CODE                                                                                                                                    " );
		sql.append("               , A.HOSP_CODE                                                                                                                                   " );
		sql.append("            FROM BAS0310 A                                                                                                                                     " );
		sql.append("           WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                    " );
		sql.append("             AND A.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                                                          " );
		sql.append("                                   FROM BAS0310 Z                                                                                                              " );
		sql.append("                                  WHERE Z.HOSP_CODE = A.HOSP_CODE                                                                                              " );
		sql.append("                                    AND Z.SG_CODE   = A.SG_CODE                                                                                                " );
		sql.append("                                    AND Z.SG_YMD   <= SYSDATE() )                                                                                              " );
		sql.append("        ) G ON G.HOSP_CODE = B.HOSP_CODE  AND G.SG_CODE   = B.SG_CODE                                                                                          " );
		sql.append("      , ( OCS0116 C RIGHT JOIN OCS1003 A ON  C.HOSP_CODE = A.HOSP_CODE AND C.SPECIMEN_CODE = A.SPECIMEN_CODE )                                                 " );
		sql.append("      LEFT JOIN INV0110 H ON H.HOSP_CODE = A.HOSP_CODE AND H.JAERYO_CODE = A.HANGMOG_CODE                                                                      " );
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                                                                                                                        " );
		sql.append("    AND A.BUNHO          = :f_bunho                                                                                                                            " );
		sql.append("    AND A.FKOUT1001      = :f_fkout1001                                                                                                                        " );
		sql.append("    AND (                                                                                                                                                      " );
		sql.append("             ( :f_query_gubun = 'D'  AND   A.INPUT_GUBUN LIKE 'D%' )                                                                                           " );
		sql.append("          OR ( :f_query_gubun != 'D' AND ( A.INPUT_GUBUN LIKE 'D%'                                                                                             " );
		sql.append("                                           OR A.INPUT_GUBUN = :f_input_gubun                                                                                   " );
		sql.append("                                         )                                                                                                                     " );
		sql.append("             )                                                                                                                                                 " );
		sql.append("        )                                                                                                                                                      " );
		sql.append("    AND B.HOSP_CODE        = A.HOSP_CODE                                                                                                                       " );
		sql.append("    AND B.HANGMOG_CODE     = A.HANGMOG_CODE                                                                                                                    " );
		sql.append("    AND A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE                                                                                                       " );
		sql.append("    AND E.HOSP_CODE        = A.HOSP_CODE                                                                                                                       " );
		sql.append("    AND E.PKOUT1001        = A.FKOUT1001                                                                                                                       " );
		sql.append("    AND F.HOSP_CODE        = A.HOSP_CODE                                                                                                                       " );
		sql.append("    AND A.SLIP_CODE        = F.SLIP_CODE                                                                                                                       " );
		sql.append("    AND F.LANGUAGE        = :f_language                                                                                                                       " );
		sql.append("  ORDER BY ORDER_BY_KEY 																																		");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkout1001", fkout1001);
		query.setParameter("f_query_gubun", queryGubun);
		query.setParameter("f_input_gubun", inputGubun);
		List<OCS1003Q02LayQueryLayoutInfo> list = new JpaResultMapper().list(query, OCS1003Q02LayQueryLayoutInfo.class);
		return list;
	}

	@Override
	public List<OCS1003R00LayOCS1003Info> getOCS1003R00LayOCS1003Info(String hospCode, String language, String bunho, String naewonDate,
			String gwa, String doctor, String naewonType, String inputGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                                                            ");
		sql.append("        C.CODE_NAME                                                INPUT_GUBUN_NAME        ,                                                                                            ");
		sql.append("        A.GROUP_SER                                                GROUP_SER               ,                                                                                            ");
		sql.append("        A.MIX_GROUP                                                MIX_GROUP               ,                                                                                            ");
		sql.append("        A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                                                            ");
		sql.append("        IFNULL(FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN', A.ORDER_GUBUN,:f_hosp_code,:f_language), 'Etc')                                                                                     ");
		sql.append("                                                                   ORDER_GUBUN_NAME        ,                                                                                            ");
		sql.append("        B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,                                                                                            ");
		sql.append("        A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                                                            ");
		sql.append("        B.HANGMOG_NAME                                             HANGMOG_NAME            ,                                                                                            ");
		sql.append("        B.SG_CODE                                                  SG_CODE                 ,                                                                                            ");
		sql.append("        IFNULL(E.SG_NAME, B.HANGMOG_NAME)                             SG_NAME                 ,                                                                                         ");
		sql.append("        (CASE WHEN B.INPUT_CONTROL = '1' THEN IF(SUBSTR(LTRIM(A.SURYANG), 1, 1) = '.', CONCAT('0',LTRIM(A.SURYANG)), LTRIM(A.SURYANG))                                                  ");
		sql.append("              WHEN B.INPUT_CONTROL = 'C' THEN IF(SUBSTR(LTRIM(A.SURYANG), 1, 1) = '.', CONCAT('0',LTRIM(A.SURYANG)), LTRIM(A.SURYANG))                                                  ");
		sql.append("              WHEN B.INPUT_CONTROL = '2' THEN IF(SUBSTR(LTRIM(A.SURYANG), 1, 1) = '.', CONCAT('0',LTRIM(A.SURYANG)), LTRIM(A.SURYANG))                                                  ");
		sql.append("              WHEN B.INPUT_CONTROL = '3' THEN IF(SUBSTR(LTRIM(A.SURYANG), 1, 1) = '.', CONCAT('0',LTRIM(A.SURYANG)), LTRIM(A.SURYANG))                                                  ");
		sql.append("              WHEN B.INPUT_CONTROL = '6' THEN IF(SUBSTR(LTRIM(A.SURYANG), 1, 1) = '.', CONCAT('0',LTRIM(A.SURYANG)), LTRIM(A.SURYANG))                                                  ");
		sql.append("              WHEN B.INPUT_CONTROL = '7' THEN IF(SUBSTR(LTRIM(A.SURYANG), 1, 1) = '.', CONCAT('0',LTRIM(A.SURYANG)), LTRIM(A.SURYANG))                                                  ");
		sql.append("             ELSE '' END)                                             SURYANG                 ,                                                                                         ");
		sql.append("        A.ORD_DANUI                                                ORD_DANUI               ,                                                                                            ");
		sql.append("        (CASE WHEN B.ORDER_GUBUN         = 'K' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code,:f_language)                                                            ");
		sql.append("              WHEN B.INPUT_CONTROL       = '1' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code,:f_language)                                                            ");
		sql.append("              WHEN B.INPUT_CONTROL       = 'C' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code,:f_language)                                                            ");
		sql.append("              WHEN B.INPUT_CONTROL       = '2' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code,:f_language)                                                            ");
		sql.append("              WHEN B.INPUT_CONTROL       = '3' AND IFNULL(E.BUN_CODE, 'XX') = 'T2' THEN 'L'                                                                                             ");
		sql.append("              WHEN B.INPUT_CONTROL       = '3' THEN 'H'                                                                                                                                 ");
		sql.append("              ELSE '' END )                                        ORD_DANUI_NAME          ,                                                                                            ");
		sql.append("        (CASE WHEN B.INPUT_CONTROL = '1' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME,:f_hosp_code,:f_language)                                                                      ");
		sql.append("              WHEN B.INPUT_CONTROL = '2' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME,:f_hosp_code,:f_language)                                                                      ");
		sql.append("              ELSE '' END )                                        DV_TIME                 ,                                                                                            ");
		sql.append("        (CASE WHEN B.INPUT_CONTROL = '1' THEN TRIM(A.DV)                                                                                                                                ");
		sql.append("              WHEN B.INPUT_CONTROL = '2' THEN TRIM(A.DV)                                                                                                                                ");
		sql.append("              ELSE '' END )                                        DV                      ,                                                                                            ");
		sql.append("        (CASE WHEN B.INPUT_CONTROL = '1' THEN CONCAT(LTRIM(A.NALSU),'D')                                                                                                                ");
		sql.append("              WHEN B.INPUT_CONTROL = '2' THEN CONCAT(LTRIM(A.NALSU),'D')                                                                                                                ");
		sql.append("              WHEN B.INPUT_CONTROL = '3' THEN CONCAT(LTRIM(A.NALSU),'M')                                                                                                                ");
		sql.append("              WHEN B.INPUT_CONTROL = '7' THEN CONCAT(LTRIM(A.NALSU),'D')                                                                                                                ");
		sql.append("              WHEN B.INPUT_CONTROL = '8' THEN CONCAT(LTRIM(A.NALSU),'D')                                                                                                                ");
		sql.append("             ELSE '' END)                                         NALSU                   ,                                                                                             ");
		sql.append("        A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,                                                                                            ");
		sql.append("        A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,                                                                                            ");
		sql.append("        D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,                                                                                            ");
		sql.append("        A.JUSA                                                     JUSA                    ,                                                                                            ");
		sql.append("        FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA,:f_hosp_code,:f_language)                      JUSA_NAME               ,                                                                   ");
		sql.append("        A.BOGYONG_CODE                                             BOGYONG_CODE            ,                                                                                            ");
		sql.append("        FN_OCS_LOAD_BOGYONG_COL_NAME(:f_hosp_code, :f_language, B.ORDER_GUBUN, A.BOGYONG_CODE)                                                                                          ");
		sql.append("                                                                   BOGYONG_NAME            ,                                                                                            ");
		sql.append("        A.HOPE_DATE               ,                                                                                                                                                     ");
		sql.append("        A.ORDER_REMARK                                             ORDER_REMARK            ,                                                                                            ");
		sql.append("        ( CASE WHEN A.JUNDAL_PART  <> 'HOM'                                                                                                                                             ");
		sql.append("                AND A.JUNDAL_TABLE IN ('CPL', 'PFE', 'XRT', 'APL')                                                                                                                      ");
		sql.append("               THEN IF(A.ORDER_DATE = IFNULL(A.ACTING_DATE, STR_TO_DATE('99991231', '%Y%m%d')), 'Y',                                                                                    ");
		sql.append("                                         IFNULL(A.DANGIL_GUMSA_ORDER_YN , 'N'))                                                                                                         ");
		sql.append("               ELSE 'N' END )                                      DANGIL_GUMSA_ORDER_YN   ,                                                                                            ");
		sql.append("        ( CASE WHEN A.JUNDAL_PART  <> 'HOM'                                                                                                                                             ");
		sql.append("                AND A.JUNDAL_TABLE IN ('CPL', 'PFE', 'XRT', 'APL')                                                                                                                      ");
		sql.append("               THEN IFNULL(A.DANGIL_GUMSA_RESULT_YN , 'N')                                                                                                                              ");
		sql.append("               ELSE 'N' END )                                      DANGIL_GUMSA_RESULT_YN  ,                                                                                            ");
		sql.append("        IFNULL(A.EMERGENCY             , 'N')                         EMERGENCY               ,                                                                                         ");
		sql.append("        ( CASE WHEN A.JUNDAL_PART  <> 'HOM'                                                                                                                                             ");
		sql.append("                AND A.JUNDAL_TABLE IN ('CPL', 'PFE', 'XRT', 'APL')                                                                                                                      ");
		sql.append("                AND IF(A.ORDER_DATE = IFNULL(A.ACTING_DATE, STR_TO_DATE('99991231', '%Y%m%d')), 'Y',                                                                                    ");
		sql.append("                                         IFNULL(A.DANGIL_GUMSA_ORDER_YN , 'N'))= 'N'                                                                                                    ");
		sql.append("                AND IFNULL(A.DANGIL_GUMSA_ORDER_YN , 'N') = 'N'                                                                                                                         ");
		sql.append("                AND IFNULL(A.DANGIL_GUMSA_RESULT_YN, 'N') = 'N'                                                                                                                         ");
		sql.append("               THEN 'Y'                                                                                                                                                                 ");
		sql.append("               ELSE 'N' END )                                      RESER_YN                ,                                                                                            ");
		sql.append("        A.SEQ                                                      SEQ,                                                                                                                 ");
		sql.append("        A.RESER_DATE                                               RESER_DATE,                                                                                                          ");
		sql.append("        A.ACTING_DATE                                              ACTING_DATE,                                                                                                         ");
		sql.append("     CONCAT(LPAD(A.GROUP_SER,11,'0'),                                                                                                                                                   ");
		sql.append("      CASE WHEN A.SOURCE_FKOCS1003 IS NOT NULL THEN A.SOURCE_FKOCS1003                                                                                                                  ");
		sql.append("                     WHEN A.BOM_SOURCE_KEY IS NULL THEN A.PKOCS1003                                                                                                                     ");
		sql.append("                     ELSE A.BOM_SOURCE_KEY END ,                                                                                                                                        ");
		sql.append("      A.PKOCS1003)                                          ORDER_BY_KEY                                                                                                                ");
		sql.append("   FROM OCS1003 A LEFT JOIN OCS0132 C ON C.CODE = A.INPUT_GUBUN AND C.CODE_TYPE = 'INPUT_GUBUN' AND C.HOSP_CODE = A.HOSP_CODE AND C.LANGUAGE = :f_language                              ");
		sql.append("                                  LEFT JOIN OCS0116 D ON D.SPECIMEN_CODE = A.SPECIMEN_CODE AND D.HOSP_CODE = A.HOSP_CODE                                                                ");
		sql.append("                                  LEFT JOIN OCS0132 F ON F.CODE = A.ORDER_GUBUN AND F.CODE_TYPE = 'ORDER_GUBUN' AND F.HOSP_CODE = A.HOSP_CODE AND F.LANGUAGE = :f_language              ");
		sql.append("        , OCS0103 B LEFT JOIN ( SELECT A.SG_CODE,                                                                                                                                       ");
		sql.append("                  A.BUN_CODE,                                                                                                                                                           ");
		sql.append("                  A.SG_NAME,                                                                                                                                                            ");
		sql.append("                  A.HOSP_CODE                                                                                                                                                           ");
		sql.append("         FROM  BAS0310 A                                                                                                                                                                ");
		sql.append("         WHERE A.HOSP_CODE = :f_hosp_code AND A.SG_YMD = (                                                                                                                              ");
		sql.append("               SELECT MAX(Z.SG_YMD)                                                                                                                                                     ");
		sql.append("                     FROM BAS0310 Z                                                                                                                                                     ");
		sql.append("                    WHERE Z.SG_CODE = A.SG_CODE                                                                                                                                         ");
		sql.append("                      AND Z.SG_YMD <= SYSDATE() 																																		");
		sql.append("                      AND Z.HOSP_CODE = A.HOSP_CODE)                                                                                                         							");
		sql.append("        ) E ON E.SG_CODE = B.SG_CODE AND E.HOSP_CODE = B.HOSP_CODE                                                                                                                      ");
		sql.append("                                                                                                                                                                                        ");
		sql.append("  WHERE A.BUNHO                 = :f_bunho                                                                                                                                              ");
		sql.append("    AND A.ORDER_DATE            = STR_TO_DATE(:f_naewon_date,'%Y/%m/%d')                                                                                                                ");
		sql.append("    AND A.GWA                   = :f_gwa                                                                                                                                                ");
		sql.append("    AND A.DOCTOR                = :f_doctor                                                                                                                                             ");
		sql.append("    AND A.NAEWON_TYPE           = :f_naewon_type                                                                                                                                        ");
		sql.append("    AND A.HOSP_CODE             = :f_hosp_code                                                                                                                                          ");
		sql.append("    AND (( A.INPUT_GUBUN = :f_input_gubun   ) OR                                                                                                                                        ");
		sql.append("           ( :f_input_gubun = 'D%' AND A.INPUT_GUBUN LIKE :f_input_gubun ) )                                                                                                            ");
		sql.append("    AND IFNULL(A.DISPLAY_YN , 'Y') = 'Y'                                                                                                                                                ");
		sql.append("    AND IFNULL(A.DC_YN,'N')        = 'N'                                                                                                                                                ");
		sql.append("    AND A.NALSU                 >= 0                                                                                                                                                    ");
		sql.append("    AND B.HANGMOG_CODE          = A.HANGMOG_CODE                                                                                                                                        ");
		sql.append("    AND B.HOSP_CODE             = A.HOSP_CODE                                                                                                                                           ");
		sql.append("    ORDER BY ORDER_BY_KEY																																								");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_naewon_type", naewonType);
		query.setParameter("f_input_gubun", inputGubun);
		List<OCS1003R00LayOCS1003Info> list = new JpaResultMapper().list(query, OCS1003R00LayOCS1003Info.class);
		return list;
	}

	@Override
	public void callPrOcsUpdateActing(String hospCode, String inOutGubun,
			Double fkocs, String actBuseo, Date jubsuDate, String jubsuTime,
			Date actingDate, String actingTime, String actDoctor) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_OCS_UPDATE_ACTING");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACT_BUSEO", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_JUBSU_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ACTING_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ACT_DOCTOR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		query.setParameter("I_FKOCS", fkocs);
		query.setParameter("I_ACT_BUSEO", actBuseo);
		query.setParameter("I_JUBSU_DATE", jubsuDate);
		query.setParameter("I_JUBSU_TIME", jubsuTime);
		query.setParameter("I_ACTING_DATE", actingDate);
		query.setParameter("I_ACTING_TIME", actingTime);
		query.setParameter("I_ACT_DOCTOR", actDoctor);
		
		Boolean isValid = query.execute();
	}

	
	public List<OCSACTGrdJearyoInfo> getOCSACTGrdJearyoInfo (String bunho, String orderDate, String ioGubun, String jundalPart, Double fkocs,
			String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.JAERYO_CODE             JAERYO_CODE																   ");
		sql.append("	     , D.HANGMOG_NAME             JAERYO_NAME                                                                  ");
		sql.append("	     , CASE SUBSTR(IFNULL(IFNULL(F.SURYANG,G.SURYANG),0),1,1)                                                  ");
		sql.append("	       WHEN '.' THEN CONCAT('0', ROUND(IFNULL(F.SURYANG,G.SURYANG),3))                                         ");
		sql.append("	       ELSE CAST(ROUND(IFNULL(F.SURYANG,G.SURYANG),3) AS CHAR)                                                 ");
		sql.append("	       END  SURYANG                                                                                            ");
		sql.append("	     , IFNULL(F.ORD_DANUI,G.ORD_DANUI)   ORD_DANUI                                                             ");
		sql.append("	     , A.PKINV1001                                                                                             ");
		sql.append("	     , :f_bunho                                                                                                ");
		sql.append("	     , :f_order_date                                                                                           ");
		sql.append("	     , :f_io_gubun                                                                                             ");
		sql.append("	     , A.ACTING_DATE                                                                                           ");
		sql.append("	     , :f_jundal_part                                                                                          ");
		sql.append("	     , CASE A.IN_OUT_GUBUN WHEN 'I' THEN A.FKOCS2003 WHEN 'O' THEN A.FKOCS1003 END                             ");
		sql.append("	     , IF(:f_fkocs = '', CAST(' 'AS CHAR), :f_fkocs  )                                                         ");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME ('ORD_DANUI',IFNULL(F.ORD_DANUI,G.ORD_DANUI),:f_hosp_code, :f_language) DANUI_NAME ");
		sql.append("	     , ''	BUNRYU2                                                                                             ");
		sql.append("	     , ''   JAERYO_GUBUN                                                                                        ");
		sql.append("	     , ''  BJAERYO_CODE                                                    										");
		sql.append("	     , D.INPUT_CONTROL                                                                                         ");
		sql.append("	     , H.BUN_CODE    BUN_CODE                                                                                  ");
		sql.append("	     , A.NALSU                                                                                                 ");
		sql.append("	     , CASE :f_io_gubun WHEN 'I' THEN F.PKOCS2003 WHEN 'O' THEN G.PKOCS1003 END                                ");
		sql.append("	  FROM                                                                                                         ");
		sql.append("	      OCS1003 G RIGHT JOIN INV1001 A ON G.HOSP_CODE = A.HOSP_CODE AND G.PKOCS1003 = A.FKOCS1003                ");
		sql.append("	       LEFT JOIN OCS2003 F ON F.HOSP_CODE = A.HOSP_CODE AND F.PKOCS2003 = A.FKOCS2003                          ");
		sql.append("	     , (SELECT AA.SG_CODE                                                                                      ");
		sql.append("	             , AA.BUN_CODE                                                                                     ");
		sql.append("	          FROM BAS0310 AA                                                                                      ");
		sql.append("	         WHERE AA.HOSP_CODE = :f_hosp_code                                                                     ");
		sql.append("	           AND AA.SG_YMD    = ( SELECT MAX(SG_YMD)                                                             ");
		sql.append("	                                 FROM BAS0310 BB                                                               ");
		sql.append("	                                WHERE BB.HOSP_CODE = AA.HOSP_CODE                                              ");
		sql.append("	                                  AND BB.SG_CODE   = AA.SG_CODE                                                ");
		sql.append("	                                  AND BB.SG_YMD   <= SYSDATE()                                                 ");
		sql.append("	                             	 AND BB.HOSP_CODE = :f_hosp_code )                                             ");
		sql.append("	       ) H RIGHT JOIN OCS0103 D ON H.SG_CODE = D.SG_CODE                                                       ");
		sql.append("	WHERE A.HOSP_CODE      = :f_hosp_code                                                                          ");
		sql.append("	  AND A.BOM_SOURCE_KEY = :f_fkocs                                                                              ");
		sql.append("	  AND D.HOSP_CODE      = A.HOSP_CODE                                                                           ");
		sql.append("	  AND D.HANGMOG_CODE   = A.JAERYO_CODE                                                                         ");
		sql.append("	  AND A.ORDER_DATE BETWEEN D.START_DATE AND D.END_DATE                                                         ");
		sql.append("	ORDER BY A.JAERYO_CODE                                                                                         ");

		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_fkocs", fkocs);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);

		List<OCSACTGrdJearyoInfo> list = new JpaResultMapper().list(query, OCSACTGrdJearyoInfo.class);
		return list;
	}
	


	@Override
	public List<String> getIfNullIfDataSendYnOCS1003(String hospCode,Double pkOcs1003) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(A.IF_DATA_SEND_YN , 'N') IF_DATA_SEND_YN             ");
		sql.append(" FROM OCS1003 A                                                     ");
		sql.append(" WHERE A.HOSP_CODE =:f_hosp_code AND A.PKOCS1003 = :f_pkocs			");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs", pkOcs1003);
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public Double callPrOcsoRealOrderFromDummy(String hospCode,String ioGubun,Double srcFkocs, String userId, String inputGubun,String hangmogCode) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_OCS_REAL_ORDER_FROM_DUMMY");
		Double newPkocs = null;
		
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SRC_FKOCS", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_NEW_PKOCS", Double.class, ParameterMode.OUT);

		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SRC_FKOCS", srcFkocs);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_INPUT_GUBUN", inputGubun);
		query.setParameter("I_JUBSU_DATE", hangmogCode);
		query.execute();
		newPkocs = (Double) query.getOutputParameterValue("O_NEW_PKOCS");
		return newPkocs;
	}

	@Override
	public PrOcsIudBomOrderActInfo callPrOcsIudBomOutOrderAct(String hospCode,
			String language, String iudGubun, String inputId, String inputPart,
			Double bomSourceKey, Double pkOcs1003,
			String hangmogCode, Double suryang, Date actingDate,
			String actingTime, String orderGubun, Double nalsu, String ordDanui) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_IUD_BOM_OUT_ORDER_ACT ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_PART", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BOM_SOURCE_KEY", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_PKOCS1003", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SURYANG", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ACTING_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ORDER_GUBUN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_NALSU", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ORD_DANUI", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_PKOCS1003", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_IUD_GUBUN", iudGubun);
		query.setParameter("I_INPUT_ID", inputId);
		query.setParameter("I_INPUT_PART", inputPart);
		query.setParameter("I_BOM_SOURCE_KEY", bomSourceKey);
		query.setParameter("I_PKOCS1003", pkOcs1003);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_SURYANG", suryang);
		query.setParameter("I_ACTING_DATE", actingDate);
		query.setParameter("I_ACTING_TIME", actingTime);
		query.setParameter("I_ORDER_GUBUN", orderGubun);
		query.setParameter("I_NALSU", nalsu);
		query.setParameter("I_ORD_DANUI", ordDanui);
		Boolean isValid = query.execute();
		
		PrOcsIudBomOrderActInfo info = new PrOcsIudBomOrderActInfo();
		info.setIoPkocs2003((Double)query.getOutputParameterValue("IO_PKOCS1003"));
		info.setIoErrMsg((String)query.getOutputParameterValue("IO_ERR_MSG"));
		info.setIoErr((String)query.getOutputParameterValue("IO_ERR"));
		return info;
	}

	@Override
	public List<OCSAPPROVEGrdOrderInfo> getOCSAPPROVEGrdOrderListItem(
			String hospCode, String language, Double pkOrder, String inputTab,
			String insteadYN, String approveYn, String prepostGubun,
			String bunho, String jubsuNo, String doctor, Date naewonDate,
			boolean ocs1003Q09, String genericYn, String inputGubun, String telYn) {
		LOG.info("[START] getOCSAPPROVEGrdOrderListItem");
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,																				");
		sql.append("	       A.GROUP_SER                                                GROUP_SER               ,                                                                             ");
		sql.append("	       IFNULL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,                                                                          ");
		sql.append("	       A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                                             ");
		if(ocs1003Q09){
			sql.append("	       IF(:f_generic_yn = 'N', B.HANGMOG_NAME, IF(A.GENERAL_DISP_YN = 'Y', I.GENERIC_NAME, B.HANGMOG_NAME)) HANGMOG_NAME,                                           ");
		}else{
			sql.append("	       IF(A.GENERAL_DISP_YN = 'Y', I.GENERIC_NAME , B.HANGMOG_NAME) HANGMOG_NAME      ,                                                                                 ");
		}
		sql.append("	       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,                                                                             ");
		sql.append("	       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,                                                                             ");
		sql.append("	       A.SURYANG                                                  SURYANG                 ,                                                                             ");
		sql.append("	       A.ORD_DANUI                                                ORD_DANUI               ,                                                                             ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code, :language)            ORD_DANUI_NAME          ,                                                     ");
		sql.append("	       A.DV_TIME                                                  DV_TIME                 ,                                                                             ");
		sql.append("	       A.DV                                                       DV                      ,                                                                             ");
		sql.append("	       A.NALSU                                                    NALSU                   ,                                                                             ");
		sql.append("	       A.JUSA                                  JUSA                    ,                                                                                                ");
		sql.append("	       CASE B.ORDER_GUBUN WHEN 'A' THEN FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA,:f_hosp_code, :language)                                                                   ");
		sql.append("	                          WHEN 'B' THEN FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA,:f_hosp_code, :language)                                                                   ");
		sql.append("	                          ELSE  'NULL'    END                       JUSA_NAME               ,                                                                             ");
		sql.append("	       A.BOGYONG_CODE                                             BOGYONG_CODE            ,                                                                             ");
		sql.append("	       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN,:f_hosp_code, :language)                                                                 ");
		sql.append("	                                                                  BOGYONG_NAME            ,                                                                             ");
		sql.append("	       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,                                                                             ");
		sql.append("	       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,                                                                             ");
		sql.append("	       A.PHARMACY                                                 PHARMACY                ,                                                                             ");
		sql.append("	       A.DRG_PACK_YN                                              DRG_PACK_YN             ,                                                                             ");
		sql.append("	       A.POWDER_YN                                                POWDER_YN               ,                                                                             ");
		sql.append("	       IFNULL(A.WONYOI_ORDER_YN       , 'N')                         WONYOI_ORDER_YN         ,                                                                          ");
		sql.append("	       IFNULL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN   ,                                                                          ");
		sql.append("	       IFNULL(A.DANGIL_GUMSA_RESULT_YN, 'N')                         DANGIL_GUMSA_RESULT_YN  ,                                                                          ");
		sql.append("	       IFNULL(A.EMERGENCY             , 'N')                         EMERGENCY               ,                                                                          ");
		sql.append("	       A.PAY                                                      PAY                     ,                                                                             ");
		sql.append("	       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,                                                                             ");
		sql.append("	       A.MUHYO                                                    MUHYO                   ,                                                                             ");
		sql.append("	       A.PORTABLE_YN                                              PORTABLE_YN             ,                                                                             ");
		sql.append("	       A.OCS_FLAG                                                 OCS_FLAG                ,                                                                             ");
		sql.append("	       A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                                             ");
		sql.append("	       A.INPUT_TAB                                                INPUT_TAB               ,                                                                             ");
		sql.append("	       A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                                             ");
		sql.append("	       A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,                                                                             ");
		sql.append("	       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,                                                                             ");
		sql.append("	       A.JUNDAL_PART                                              JUNDAL_PART             ,                                                                             ");
		sql.append("	       A.MOVE_PART                                                MOVE_PART               ,                                                                             ");
		sql.append("	       A.BUNHO                                                    BUNHO                   ,                                                                             ");
		sql.append("	       DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                      ORDER_DATE              ,                                                                             ");
		sql.append("	       A.GWA                                                      GWA                     ,                                                                             ");
		sql.append("	       A.DOCTOR                                                   DOCTOR                  ,                                                                             ");
		sql.append("	       A.NAEWON_TYPE                                              NAEWON_TYPE             ,                                                                             ");
		sql.append("	       A.FKOUT1001                                                PK_ORDER                ,                                                                             ");
		sql.append("	       A.SEQ                                                      SEQ                     ,                                                                             ");
		sql.append("	       A.PKOCS1003                                                PKOCS1003               ,                                                                             ");
		sql.append("	       A.SUB_SUSUL                                                SUB_SUSUL               ,                                                                             ");
		sql.append("	       A.SUTAK_YN                                                 SUTAK_YN                ,                                                                             ");
		sql.append("	       A.AMT                                                      AMT                     ,                                                                             ");
		sql.append("	       IF(A.DV_1 = 0, NULL, A.DV_1)                               DV_1                    ,                                                                             ");
		sql.append("	       IF(A.DV_2 = 0, NULL, A.DV_2)                               DV_2                    ,                                                                             ");
		sql.append("	       IF(A.DV_3 = 0, NULL, A.DV_3)                               DV_3                    ,                                                                             ");
		sql.append("	       IF(A.DV_4 = 0, NULL, A.DV_4)                               DV_4                    ,                                                                             ");
		sql.append("	       ''                                                         HOPE_DATE               ,                                                                             ");
		sql.append("	       A.ORDER_REMARK                                             ORDER_REMARK            ,                                                                             ");
		sql.append("	       A.MIX_GROUP                                                MIX_GROUP               ,                                                                             ");
		sql.append("	       A.HOME_CARE_YN                                             HOME_CARE_YN            ,                                                                             ");
		sql.append("	       IFNULL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,                                                                          ");
		sql.append("	       A.GONGBI_CODE                                              GONGBI_CODE             ,                                                                             ");
		sql.append("	       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE, :language)       GONGBI_NAME             ,                                                                  ");
		sql.append("	       IF( B.ORDER_GUBUN = 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE,:f_hosp_code), 'N' )                                                                               ");
		sql.append("	                                                                  DONBOK_YN               ,                                                                             ");
		sql.append("	       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)  DV_NAME                 ,                                             ");
		sql.append("	       B.SLIP_CODE                                                SLIP_CODE               ,                                                                             ");
		sql.append("	       B.GROUP_YN                                                 GROUP_YN                ,                                                                             ");
		sql.append("	       B.SG_CODE                                                  SG_CODE                 ,                                                                             ");
		sql.append("	       SUBSTR(B.ORDER_GUBUN,1,1)                                  ORDER_GUBUN_BAS         ,                                                                             ");
		sql.append("	       B.INPUT_CONTROL                                            INPUT_CONTROL           ,                                                                             ");
		sql.append("	       IFNULL(B.SUGA_YN,'N')                                         SUGA_YN                 ,                                                                          ");
		sql.append("	       CASE IFNULL(B.EMERGENCY,'Z') WHEN 'Y' THEN 'N'                                                                                                                   ");
		sql.append("	                                    WHEN 'N' THEN 'N' ELSE 'Y' END          EMERGENCY_CHECK         ,                                                                    ");
		sql.append("	       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,                                                                             ");
		sql.append("	       IFNULL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,                                                                          ");
		sql.append("	       IFNULL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,                                                                          ");
		sql.append("	       IF(B.ORD_DANUI IS NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,                                                                               ");
		sql.append("	       B.ORD_DANUI                                                ORD_DANUI_BAS           ,                                                                             ");
		if(ocs1003Q09){
			sql.append("	       A.JUNDAL_TABLE                                         JUNDAL_TABLE_OUT        ,                                                                             ");
			sql.append("	       A.JUNDAL_PART                                          JUNDAL_PART_OUT         ,                                                                             ");
			sql.append("	       A.MOVE_PART                                                MOVE_PART_OUT           ,                                                                             ");
		}else{
			sql.append("	       B.JUNDAL_TABLE_OUT                                         JUNDAL_TABLE_OUT        ,                                                                             ");
			sql.append("	       B.JUNDAL_PART_OUT                                          JUNDAL_PART_OUT         ,                                                                             ");
			sql.append("	       B.MOVE_PART                                                MOVE_PART_OUT           ,                                                                             ");
		}
		sql.append("	       B.JUNDAL_TABLE_INP                                         JUNDAL_TABLE_INP        ,                                                                             ");
		sql.append("	       B.JUNDAL_PART_INP                                          JUNDAL_PART_INP         ,                                                                             ");
		sql.append("	       B.MOVE_PART                                                MOVE_PART_INP           ,                                                                             ");
		sql.append("           FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, SYSDATE(),:f_hosp_code)            BULYONG_CHECK,                                                         ");
//		sql.append("	       ( CASE WHEN FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE(),:f_hosp_code) <> 'Y'                                                                              ");
//		sql.append("	              THEN 'N'                                                                                                                                                  ");
//		sql.append("	              WHEN FN_OCS_BULYONG_CHECK_OUT   (B.HANGMOG_CODE, SYSDATE(),:f_hosp_code) = 'Y'                                                                            ");
//		sql.append("	               AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, SYSDATE(),:f_hosp_code) <> A.HANGMOG_CODE                                             ");
//		sql.append("	              THEN 'Z'                                                                                                                                                  ");
//		sql.append("	              ELSE 'Y' END )                                      BULYONG_CHECK           ,                                                                             ");
		sql.append("	       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE,:f_hosp_code)                   WONYOI_ORDER_CR_YN      ,                                                                ");
		sql.append("	       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,                                                                             ");
		sql.append("	       IFNULL(B.NDAY_YN,'N')                                         NDAY_YN                 ,                                                                          ");
		sql.append("	       IFNULL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,                                                                          ");
		sql.append("	       A.TEL_YN                                                   TEL_YN                  ,                                                                             ");
		sql.append("	       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE,:f_hosp_code)                        DRG_INFO                ,                                                                ");
		sql.append("	       'NULL'                                                         DRG_BUNRYU              ,                                                                             ");
		sql.append("	       CASE WHEN A.BOM_SOURCE_KEY IS NULL THEN 'N' ELSE 'Y' END  CHILD_YN,                                                                                              ");
		sql.append("	       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,                                                                                        ");
		sql.append("	       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,                                                                                          ");
		sql.append("	       A.PKOCS1003                                               ORG_KEY,                                                                                               ");
		sql.append("	       A.BOM_SOURCE_KEY                                          PARENT_KEY,                                                                                            ");
		sql.append("	       H.BUN_CODE                                                BUN_CODE  ,                                                                                            ");
		sql.append("	      CAST( CONCAT(SUBSTR(LPAD(A.GROUP_SER, 4, 0), 0, 2), IF(A.BOM_SOURCE_KEY = NULL, A.PKOCS1003, A.BOM_SOURCE_KEY)                                                    ");
		sql.append("	       , A.PKOCS1003) AS CHAR)                                CONT_KEY,                                                                                                 ");
		sql.append("	    A.FKOUT1001,                                                                                                                                                        ");
		sql.append("	       IFNULL(B.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN,                                                                                                                      ");
		sql.append("	       A.DC_YN                                                   DC_YN,                                                                                                 ");
		sql.append("	       A.RESULT_DATE                                             RESULT_DATE,                                                                                           ");
		sql.append("	       IF(A.NURSE_CONFIRM_DATE IS NULL, 'N', 'Y')              CONFIRM_CHECK,                                                                                           ");
		sql.append("	       IF(A.SUNAB_DATE IS NULL, 'N','Y')                       SUNAB_CHECK,                                                                                             ");
		sql.append("	       IF(A.DV_5 = 0, NULL, A.DV_5)                 DV_5,                                                                                                               ");
		sql.append("	       IF(A.DV_6 = 0, NULL, A.DV_6)                 DV_6,                                                                                                               ");
		sql.append("	       IF(A.DV_7 = 0, NULL, A.DV_7)                 DV_7,                                                                                                               ");
		sql.append("	       IF(A.DV_8 = 0, NULL, A.DV_8)                 DV_8,                                                                                                               ");
		sql.append("	       IFNULL(A.GENERAL_DISP_YN, 'N') GENERAL_DISP_YN,                                                                                                                  ");
		sql.append("	       I.GENERIC_NAME,                                                                                                                                                  ");
		sql.append("	       'N',                                                                                                                                                             ");
		sql.append("	       A.BOGYONG_CODE_SUB,                                                                                                                                              ");
		sql.append("	       CASE WHEN (SUBSTR(A.ORDER_GUBUN, 2) = 'A' OR SUBSTR(A.ORDER_GUBUN, 2) = 'B' OR SUBSTR(A.ORDER_GUBUN, 2) = 'D')                                                   ");
		sql.append("	            THEN FN_CHT_LOAD_CHT0117_NAME ( A.BOGYONG_CODE_SUB ,:f_hosp_code, :language)                                                                                ");
		sql.append("	            ELSE FN_DRG_LOAD_BOGYONG_NAME ( A.BOGYONG_CODE_SUB,:f_hosp_code )                                                                                           ");
		sql.append("	       END                                                      BOGYONG_NAME_SUB,                                                                                       ");
		sql.append("	       DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')                       ORI_HOPE_DATE,                                                                                        ");
		sql.append("	       IFNULL(J.IO_GUBUN, 'A')                                     IO_YN,                                                                                               ");
		sql.append("	       'N'                                                      BROUGHT_DRG_YN, B.TRIAL_FLG  ,                                                                          ");
		if(ocs1003Q09){
			sql.append("	      ' '                   SPECIFIC_COMMENT,                                                                                                          ");
			sql.append("	      ' '                   INSTEAD_ID,                                                                                                                ");
			sql.append("	      ' '                     POSTAPPROVE_YN,                                                                                                           ");
		}else{
			sql.append("	       B.SPECIFIC_COMMENT                    SPECIFIC_COMMENT,                                                                                                          ");
			sql.append("	       A.INSTEAD_ID                        INSTEAD_ID,                                                                                                                  ");
			sql.append("	       A.POSTAPPROVE_YN                        POSTAPPROVE_YN,                                                                                                           ");
		}
		sql.append("	       'NULL',                                                                                                                                                              ");
		//[START] get data to process FN_OCS_BULYONG_CHECK_OUT in java --> turning performance   
		sql.append("	       B.HANGMOG_CODE B_HANGMOG_CODE,                                                                                                                                   ");
		sql.append("	       DATE_FORMAT(B.START_DATE, '%Y/%m/%d')                     																										");
		sql.append("           ,IFNULL(DATE_FORMAT(Z.BULYONG_YMD, '%Y/%m/%d'), '9998/12/31'), B.SG_CODE BSG_CODE, B.ORDER_GUBUN  BORDER_GUBUN                                                   ");
		sql.append("           ,B.YJ_CODE                                                                                                                                                       ");
		//[END] get data to process FN_OCS_BULYONG_CHECK_OUT in java  
		sql.append("	FROM OCS1003 A 																										                                                    ");	
		sql.append("	       INNER JOIN OCS0103 B ON B.HOSP_CODE = :f_hosp_code   AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                          ");
		sql.append("	           AND A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE                                                                                                         ");
		//[START] get data to process FN_OCS_BULYONG_CHECK_OUT in java --> turning performance
		sql.append("	       LEFT JOIN(SELECT X.SG_CODE                                                                                                                                       ");
		sql.append("	                  , X.HOSP_CODE                                                                                                                                         ");
		sql.append("	                  , X.BULYONG_YMD                                                                                                                                       ");
		sql.append("	      FROM (SELECT SG_CODE, HOSP_CODE, BULYONG_YMD, SG_YMD FROM BAS0310 WHERE HOSP_CODE = :f_hosp_code) X                                                                                                                                                    ");
		sql.append("	      WHERE X.SG_YMD =(SELECT MAX(Y.SG_YMD)                                                                                                                             ");
		sql.append("	         FROM (SELECT SG_CODE, SG_YMD FROM BAS0310 WHERE HOSP_CODE = :f_hosp_code) Y                                                                                                                                                 ");
		sql.append("	         WHERE Y.SG_CODE = X.SG_CODE                                                                                                                                    ");
		sql.append("	         AND Y.SG_YMD <= SYSDATE()) AND HOSP_CODE = :f_hosp_code) Z ON Z.HOSP_CODE = B.HOSP_CODE AND Z.SG_CODE = B.SG_CODE                                                                           ");
		sql.append("	         AND B.START_DATE =                                                                                                                                             ");
		sql.append("	          (SELECT MAX(Z.START_DATE)  FROM OCS0103 Z WHERE Z.HANGMOG_CODE = B.HANGMOG_CODE AND Z.START_DATE <= SYSDATE() AND HOSP_CODE = :f_hosp_code)                                               ");
		//[END] get data to process FN_OCS_BULYONG_CHECK_OUT in java
		sql.append("	       INNER JOIN OCS0140 G ON G.HOSP_CODE        = :f_hosp_code                                                                                                         ");
		sql.append("	             AND G.ORDER_GUBUN      = A.ORDER_GUBUN                                                                                                                     ");
		sql.append("	             AND G.INPUT_TAB        = A.INPUT_TAB                                                                                                                       ");
		sql.append("	       LEFT JOIN OCS0132 C ON C.HOSP_CODE = :f_hosp_code                                                                                                                 ");
		sql.append("	             AND C.CODE   = A.ORDER_GUBUN                                                                                                                               ");
		sql.append("	             AND C.CODE_TYPE = 'ORDER_GUBUN'                                                                                                                             ");
		sql.append("	             AND C.LANGUAGE = :language                                                                                                                                 ");
		sql.append("	       LEFT JOIN OCS0116 D ON D.HOSP_CODE = :f_hosp_code AND D.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                           ");
		sql.append("	       LEFT JOIN OCS0132 F ON F.HOSP_CODE = :f_hosp_code                                                                                                                 ");
		sql.append("	             AND F.CODE = A.INPUT_GUBUN                                                                                                                                 ");
		sql.append("	             AND F.CODE_TYPE = 'INPUT_GUBUN'                                                                                                                            ");
		sql.append("	             AND F.LANGUAGE = :language                                                                                                                                 ");
		sql.append("	       LEFT JOIN ( SELECT X.SG_CODE                                                                                                                                     ");
		sql.append("	              , X.SG_NAME                                                                                                                                               ");
		sql.append("	              , X.BUN_CODE                                                                                                                                              ");
		sql.append("	              , X.BULYONG_YMD                                                                                                                                           ");
		sql.append("	              , X.HOSP_CODE                                                                                                                                             ");
		sql.append("	           FROM (SELECT SG_CODE, SG_NAME, BUN_CODE,BULYONG_YMD, HOSP_CODE, SG_YMD FROM BAS0310 WHERE HOSP_CODE = :f_hosp_code) X                                                                                                                                               ");
		sql.append("	          WHERE X.HOSP_CODE = :f_hosp_code                                                                                                                              ");
		sql.append("	            AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                                                       ");
		sql.append("	                               FROM BAS0310 Z                                                                                                                           ");
		sql.append("	                              WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                                                           ");
		sql.append("	                                AND Z.SG_CODE = X.SG_CODE AND HOSP_CODE = :f_hosp_code) ) H                                                                             ");
		sql.append("	          ON H.SG_CODE = B.SG_CODE                                                                                                                                      ");
//		sql.append("	       LEFT JOIN VW_OCS_GENERIC I ON I.HOSP_CODE  = :f_hosp_code  AND I.HANGMOG_CODE = B.HANGMOG_CODE                                                                    ");
		sql.append("          LEFT JOIN ( select distinct A.HOSP_CODE AS HOSP_CODE ,A.HANGMOG_CODE AS HANGMOG_CODE, C.GENERIC_NAME AS GENERIC_NAME                   						     ");
		sql.append("               FROM OCS0109 C INNER JOIN OCS0110 B ON C.HOSP_CODE = B.HOSP_CODE AND C.GENERIC_CODE_ORG = B.GENERIC_CODE_ORG             			                         ");
		sql.append("                              INNER JOIN OCS0103 A ON B.HOSP_CODE = A.HOSP_CODE AND B.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE                				                         ");
		sql.append("                              WHERE  B.HOSP_CODE = :f_hosp_code                                                                            		                             ");
		sql.append("            union all                                                                                                                  				                         ");
		sql.append("            select distinct A.HOSP_CODE AS HOSP_CODE ,A.HANGMOG_CODE AS HANGMOG_CODE, C.GENERIC_NAME AS GENERIC_NAME                   				                         ");
		sql.append("            FROM OCS0109 C INNER JOIN OCS0103 A ON C.HOSP_CODE = A.HOSP_CODE AND C.GENERIC_CODE = A.YAK_KIJUN_CODE_SHORT               				                         ");
		sql.append("            WHERE C.HOSP_CODE = :f_hosp_code AND                                                                                           		                             ");
		sql.append("                 (not (exists(SELECT NULL FROM OCS0110 Z                                                                               				                         ");
		sql.append("                                WHERE Z.HOSP_CODE = A.HOSP_CODE AND                                                                    				                         ");
		sql.append("                                Z.YAK_KIJUN_CODE = A.YAK_KIJUN_CODE)))) I ON I.HOSP_CODE  = :f_hosp_code  AND I.HANGMOG_CODE = B.HANGMOG_CODE                                 ");
		//sql.append("	       LEFT JOIN DRG0120 J ON J.HOSP_CODE = :f_hosp_code   AND J.BOGYONG_CODE  = A.BOGYONG_CODE                                                                          ");
		sql.append("	       LEFT JOIN DRG0120 J ON J.BOGYONG_CODE  = A.BOGYONG_CODE  AND J.LANGUAGE = :language   AND J.HOSP_CODE = :f_hosp_code                                               ");
		sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                                    ");
		sql.append("	   AND A.FKOUT1001    = :f_pk_order                                                                                                                                     ");
		sql.append("	   AND A.INPUT_TAB LIKE :f_input_tab                                                                                                                                    ");
		if(ocs1003Q09){
			 sql.append(" AND (															");
			 sql.append("       (     :f_input_gubun = 'D%'                             ");
			 sql.append("         AND A.INPUT_GUBUN LIKE 'D%' )                         ");
			 sql.append("       OR                                                      ");
			 sql.append("       ( :f_input_gubun = 'NR'                                 ");
			 sql.append("         AND (   A.INPUT_GUBUN LIKE 'D%'                       ");
			 sql.append("              OR A.INPUT_GUBUN = 'NR' ) )                      ");
			 sql.append("       OR                                                      ");
			 sql.append("       ( :f_input_gubun NOT IN ('D%', 'NR')                    ");
			 sql.append("         AND (   A.INPUT_GUBUN LIKE 'D%'                       ");
			 sql.append("              OR A.INPUT_GUBUN = :f_input_gubun ) )            ");
			 sql.append("     )                                                         ");
			 sql.append(" AND IFNULL(A.TEL_YN     , 'N') LIKE :f_tel_yn                 ");
		}else{
			sql.append("	   AND IFNULL(A.INSTEAD_YN, 'N') = :f_instead_yn                                                                                                                        ");
			sql.append("	   AND IFNULL(A.APPROVE_YN, 'N') = :f_approve_yn                                                                                                                        ");
			sql.append("	   AND IFNULL(A.POSTAPPROVE_YN, 'N') = :f_prepost_gubun                                                                                                                 ");
		}
		sql.append("	   AND A.NALSU  >= 0                                                                                                                                                        ");
		sql.append("	   AND IFNULL(A.DISPLAY_YN , 'Y') = 'Y'                  		                                                                                                            ");
		sql.append("	   AND IFNULL(A.DC_YN,'N')   = 'N'                    		                                                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_pk_order", pkOrder);
		query.setParameter("f_input_tab", inputTab);

		if(ocs1003Q09){
			query.setParameter("f_generic_yn", genericYn);
			query.setParameter("f_input_gubun", inputGubun);
			query.setParameter("f_tel_yn", telYn);
		}else{
			query.setParameter("f_instead_yn", insteadYN);
			query.setParameter("f_approve_yn", approveYn);
			query.setParameter("f_prepost_gubun", prepostGubun);
		}
		
		
		List<OCSAPPROVEGrdOrderInfo> list = new JpaResultMapper().list(query, OCSAPPROVEGrdOrderInfo.class);
		LOG.info("[END] getOCSAPPROVEGrdOrderListItem");
		return list;
	}

	@Override
	public List<OCSAPPROVEGrdOrderInfo> getOCSAPPROVEGrdOrderListItemUnion(
			String hospCode, String language, Double pkOrder, String inputTab,
			String insteadYN, String approveYn, String prepostGubun,
			String bunho, String jubsuNo, String doctor, Date naewonDate, boolean ocs1003Q09
			, String inputGubun, String telYn, String kijun, String gwa) {
		LOG.info("[START] getOCSAPPROVEGrdOrderListItemUnion");
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,                                                                             ");
		sql.append("	       A.GROUP_SER                                                GROUP_SER               ,                                                                             ");
		sql.append("	       IFNULL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,                                                                          ");
		sql.append("	       A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                                             ");
		sql.append("	       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')                                                                                                                ");
		sql.append("	              THEN CONCAT(IFNULL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE,:f_hosp_code), ''),B.HANGMOG_NAME)                                                                     ");
		sql.append("	              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,                                                                             ");
		sql.append("	       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,                                                                             ");
		sql.append("	       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,                                                                             ");
		sql.append("	       A.SURYANG                                                  SURYANG                 ,                                                                             ");
		sql.append("	       A.ORD_DANUI                                                ORD_DANUI               ,                                                                             ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,:f_hosp_code, :language)            ORD_DANUI_NAME          ,                                                     ");
		sql.append("	       A.DV_TIME                                                  DV_TIME                 ,                                                                             ");
		sql.append("	       A.DV                                                       DV                      ,                                                                             ");
		sql.append("	       A.NALSU                                                    NALSU                   ,                                                                             ");
		sql.append("	       A.JUSA                                                     JUSA                    ,                                                                             ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA,:f_hosp_code, :language)                      JUSA_NAME               ,                                                     ");
		sql.append("	       A.BOGYONG_CODE                                             BOGYONG_CODE            ,                                                                             ");
		sql.append("	       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN,:f_hosp_code, :language)                                                                 ");
		sql.append("	                                                                  BOGYONG_NAME            ,                                                                             ");
		sql.append("	       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,                                                                             ");
		sql.append("	       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,                                                                             ");
		sql.append("	       A.PHARMACY                                                 PHARMACY                ,                                                                             ");
		sql.append("	       A.DRG_PACK_YN                                              DRG_PACK_YN             ,                                                                             ");
		sql.append("	       A.POWDER_YN                                                POWDER_YN               ,                                                                             ");
		sql.append("	       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,                                                                             ");
		sql.append("	       'N'                                                        DANGIL_GUMSA_ORDER_YN   ,                                                                             ");
		sql.append("	       'N'                                                        DANGIL_GUMSA_RESULT_YN  ,                                                                             ");
		sql.append("	       IFNULL(A.EMERGENCY  , 'N')                                    EMERGENCY               ,                                                                          ");
		sql.append("	       A.PAY                                                      PAY                     ,                                                                             ");
		sql.append("	       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,                                                                             ");
		sql.append("	       A.MUHYO                                                    MUHYO                   ,                                                                             ");
		sql.append("	       A.PORTABLE_YN                                              PORTABLE_YN             ,                                                                             ");
		sql.append("	       A.OCS_FLAG                                                 OCS_FLAG                ,                                                                             ");
		sql.append("	       A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                                             ");
		sql.append("	       A.INPUT_TAB                                                INPUT_TAB               ,                                                                             ");
		sql.append("	       A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                                             ");
		sql.append("	       'N'                                                        AFTER_ACT_YN            ,                                                                             ");
		sql.append("	       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,                                                                             ");
		sql.append("	       A.JUNDAL_PART                                              JUNDAL_PART             ,                                                                             ");
		sql.append("	       ''                                                       MOVE_PART               ,                                                                             ");
		sql.append("	       A.BUNHO                                                    BUNHO                   ,                                                                             ");
		sql.append("	       DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                       NAEWON_DATE             ,                                                                             ");
		sql.append("	       A.INPUT_GWA                                                GWA                     ,                                                                             ");
		sql.append("	       A.INPUT_DOCTOR                                             DOCTOR                  ,                                                                             ");
		sql.append("	       '0'                                                        NAEWON_TYPE             ,                                                                             ");
		sql.append("	       A.FKINP1001                                                PK_ORDER                ,                                                                             ");
		sql.append("	       A.SEQ                                                      SEQ                     ,                                                                             ");
		sql.append("	       A.PKOCS2003                                                PKOCS1003               ,                                                                             ");
		sql.append("	       A.SUB_SUSUL                                                SUB_SUSUL               ,                                                                             ");
		sql.append("	       ''                                                       SUTAK_YN                ,                                                                             ");
		sql.append("	       A.AMT                                                      AMT                     ,                                                                             ");
		sql.append("	       IF(A.DV_1 = 0, NULL, A.DV_1)                            DV_1                    ,                                                                                ");
		sql.append("	       IF(A.DV_2 = 0, NULL, A.DV_2)                            DV_2                    ,                                                                                ");
		sql.append("	       IF(A.DV_3 = 0, NULL, A.DV_3)                            DV_3                    ,                                                                                ");
		sql.append("	       IF(A.DV_4 = 0, NULL, A.DV_4)                            DV_4                    ,                                                                                ");
		sql.append("	       CAST('' AS DATETIME)                                                       HOPE_DATE               ,                                                                             ");
		sql.append("	       A.ORDER_REMARK                                             ORDER_REMARK            ,                                                                             ");
		sql.append("	       A.MIX_GROUP                                                MIX_GROUP               ,                                                                             ");
		sql.append("	       'N'                                                        HOME_CARE_YN            ,                                                                             ");
		sql.append("	       IFNULL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,                                                                          ");
		sql.append("	       A.GONGBI_CODE                                              GONGBI_CODE             ,                                                                             ");
		sql.append("	       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE, :language)       GONGBI_NAME             ,                                                                ");
		sql.append("	       IF( B.ORDER_GUBUN = 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE,:f_hosp_code), 'N' )                                                                               ");
		sql.append("	                                                                  DONBOK_YN               ,                                                                             ");
		sql.append("	       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)  DV_NAME                 ,                                             ");
		sql.append("	       B.SLIP_CODE                                                SLIP_CODE               ,                                                                             ");
		sql.append("	       B.GROUP_YN                                                 GROUP_YN                ,                                                                             ");
		sql.append("	       B.SG_CODE                                                  SG_CODE                 ,                                                                             ");
		sql.append("	       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,                                                                             ");
		sql.append("	       B.INPUT_CONTROL                                            INPUT_CONTROL           ,                                                                             ");
		sql.append("	       IFNULL(B.SUGA_YN,'N')                                         SUGA_YN                 ,                                                                          ");
		sql.append("	       CASE IFNULL(B.EMERGENCY,'Z') WHEN 'Y' THEN 'N'                                                                                                                   ");
		sql.append("	                                    WHEN 'N' THEN 'N' ELSE'Y' END                EMERGENCY_CHECK         ,                                                              ");
		sql.append("	       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,                                                                             ");
		sql.append("	       IFNULL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,                                                                          ");
		sql.append("	       IFNULL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,                                                                          ");
		sql.append("	       IF(B.ORD_DANUI IS NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,                                                                               ");
		sql.append("	       B.ORD_DANUI                                                ORD_DANUI_BAS           ,                                                                             ");
		sql.append("	       B.JUNDAL_TABLE_OUT                                         JUNDAL_TABLE_OUT        ,                                                                             ");
		sql.append("	       B.JUNDAL_PART_OUT                                          JUNDAL_PART_OUT         ,                                                                             ");
		sql.append("	       B.MOVE_PART                                                MOVE_PART_OUT           ,                                                                             ");
		if(ocs1003Q09){
			sql.append("	       A.JUNDAL_TABLE                                         JUNDAL_TABLE_INP        ,                                                                             ");
			sql.append("	       A.JUNDAL_PART                                          JUNDAL_PART_INP         ,                                                                             ");
			sql.append("	       A.MOVE_PART                                                MOVE_PART_INP           ,                                                                             ");
		}else{
			sql.append("	       B.JUNDAL_TABLE_INP                                         JUNDAL_TABLE_INP        ,                                                                             ");
			sql.append("	       B.JUNDAL_PART_INP                                          JUNDAL_PART_INP         ,                                                                             ");
			sql.append("	       B.MOVE_PART                                                MOVE_PART_INP           ,                                                                             ");
		}
		sql.append("	       ''                                                         BULYONG_CHECK           ,                                                              ");
		sql.append("	       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE,:f_hosp_code)                   WONYOI_ORDER_CR_YN      ,                                                                ");
		sql.append("	       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,                                                                             ");
		sql.append("	       IFNULL(B.NDAY_YN,'N')                                         NDAY_YN                 ,                                                                          ");
		sql.append("	       IFNULL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,                                                                          ");
		sql.append("	       A.TEL_YN                                                   TEL_YN                  ,                                                                             ");
		sql.append("	       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE,:f_hosp_code)                        DRG_INFO                ,                                                                ");
		sql.append("	       ''                                                         DRG_BUNRYU              ,                                                                             ");
		sql.append("	       CASE WHEN A.BOM_SOURCE_KEY IS NULL THEN 'N' ELSE 'Y' END  CHILD_YN,                                                                                              ");
		sql.append("	       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,                                                                                        ");
		sql.append("	       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,                                                                                          ");
		sql.append("	       A.PKOCS2003                                               ORG_KEY,                                                                                               ");
		sql.append("	       A.BOM_SOURCE_KEY                                          PARENT_KEY,                                                                                            ");
		sql.append("	       H.BUN_CODE                                                BUN_CODE  ,                                                                                            ");
		sql.append("	       CAST(CONCAT(SUBSTR(LPAD(A.GROUP_SER, 4, 0), 0, 2) , IF(A.BOM_SOURCE_KEY IS NULL, A.PKOCS2003, A.BOM_SOURCE_KEY)                                                  ");
		sql.append("	       , A.PKOCS2003) AS CHAR)                                 CONT_KEY,                                                                                                ");
		sql.append("	       A.FKINP1001,                                                                                                                                                     ");
		sql.append("	       IFNULL(B.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN,                                                                                                                      ");
		sql.append("	       A.DC_YN                                                   DC_YN,                                                                                                 ");
		sql.append("	       A.RESULT_DATE                                             RESULT_DATE,                                                                                           ");
		sql.append("	       IF(A.NURSE_CONFIRM_DATE IS NULL, 'N', 'Y')              CONFIRM_CHECK,                                                                                           ");
		sql.append("	       IF(A.SUNAB_DATE IS NULL, 'N','Y')                       SUNAB_CHECK,                                                                                             ");
		sql.append("	       IF(A.DV_5 = 0, NULL, A.DV_5)                 DV_5,                                                                                                               ");
		sql.append("	       IF(A.DV_6 = 0, NULL, A.DV_6)                 DV_6,                                                                                                               ");
		sql.append("	       IF(A.DV_7 = 0, NULL, A.DV_7)                 DV_7,                                                                                                               ");
		sql.append("	       IF(A.DV_8 = 0, NULL, A.DV_8)                 DV_8,                                                                                                               ");
		sql.append("	       'N',                                                                                                                                                             ");
		sql.append("	       B.HANGMOG_NAME BHANGMOG_NAME,                                                                                                                                                  ");
		sql.append("	       'N' NOVALUE,                                                                                                                                                             ");
		sql.append("	       A.BOGYONG_CODE_SUB,                                                                                                                                              ");
		sql.append("	       CASE WHEN (SUBSTR(A.ORDER_GUBUN, 2) = 'A' OR SUBSTR(A.ORDER_GUBUN, 2) = 'B' OR SUBSTR(A.ORDER_GUBUN, 2) = 'D')                                                   ");
		sql.append("	            THEN FN_CHT_LOAD_CHT0117_NAME ( A.BOGYONG_CODE_SUB,:f_hosp_code, :language )                                                                                ");
		sql.append("	            ELSE FN_DRG_LOAD_BOGYONG_NAME ( A.BOGYONG_CODE_SUB,:f_hosp_code )                                                                                           ");
		sql.append("	       END                                                          BOGYONG_NAME_SUB,                                                                                   ");
		sql.append("	        DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')                         ORI_HOPE_DATE,                                                                                     ");
		sql.append("	       IFNULL(J.IO_GUBUN, 'A')                                     IO_YN,                                                                                               ");
		sql.append("	       IFNULL(A.BROUGHT_DRG_YN, 'N')                               BROUGHT_DRG_YN, B.TRIAL_FLG  ,                                                                       ");
		if(ocs1003Q09){
			sql.append("	      ' '                   SPECIFIC_COMMENT,                                                                                                          ");
			sql.append("	      ' '                   INSTEAD_ID,                                                                                                                ");
			sql.append("	      ' '                     POSTAPPROVE_YN,                                                                                                           ");
		}else{
			sql.append("	       B.SPECIFIC_COMMENT                    SPECIFIC_COMMENT,                                                                                                          ");
			sql.append("	       A.INSTEAD_ID                          INSTEAD_ID,                                                                                                                ");
			sql.append("	       A.POSTAPPROVE_YN                        POSTAPPROVE_YN,                                                                                                           ");
		}
		sql.append("	       '' ,B.HANGMOG_CODE BHANGMOG_CODE ,DATE_FORMAT(B.START_DATE,'%Y/%m/%d') BSTART_DATE,IFNULL(DATE_FORMAT(Z.BULYONG_YMD,'%Y/%m/%d'), '9998/12/31') BBULYONG_YMD,B.SG_CODE BSG_CODE,B.ORDER_GUBUN  BORDER_GUBUN ,            ");
		sql.append("	       B.YJ_CODE                                                                                                                                                        ");
		sql.append("	FROM 																																			                         ");
		sql.append("	      OCS2003 A 					                                                                                                                                     ");
		sql.append("	      INNER JOIN OCS0103 B ON  B.HOSP_CODE = :f_hosp_code AND B.HANGMOG_CODE = A.HANGMOG_CODE AND A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE                        ");
		sql.append("	       LEFT JOIN(SELECT X.SG_CODE                                                                                                                                       ");
		sql.append("	                  , X.HOSP_CODE                                                                                                                                         ");
		sql.append("	                  , X.BULYONG_YMD                                                                                                                                       ");
		sql.append("	      FROM (SELECT SG_CODE, HOSP_CODE, BULYONG_YMD, SG_YMD FROM BAS0310 WHERE HOSP_CODE = :f_hosp_code) X                                                                                                                                                    ");
		sql.append("	      WHERE X.SG_YMD =(SELECT MAX(Y.SG_YMD)                                                                                                                             ");
		sql.append("	         FROM (SELECT SG_CODE, SG_YMD FROM BAS0310 WHERE HOSP_CODE = :f_hosp_code) Y                                                                                                                                                 ");
		sql.append("	         WHERE Y.SG_CODE = X.SG_CODE                                                                                                                                    ");
		sql.append("	         AND Y.SG_YMD <= SYSDATE()) AND HOSP_CODE = :f_hosp_code) Z ON Z.HOSP_CODE = B.HOSP_CODE AND Z.SG_CODE = B.SG_CODE                                                                           ");
		sql.append("	         AND B.START_DATE =                                                                                                                                             ");
		sql.append("	          (SELECT MAX(Z.START_DATE)  FROM OCS0103 Z WHERE Z.HANGMOG_CODE = B.HANGMOG_CODE AND Z.START_DATE <= SYSDATE() AND HOSP_CODE = :f_hosp_code)                                               ");
		sql.append("	      LEFT JOIN OCS0132 C ON  C.HOSP_CODE = :f_hosp_code AND C.CODE = A.ORDER_GUBUN AND C.CODE_TYPE = 'ORDER_GUBUN' AND C.LANGUAGE = :language                           ");
		sql.append("	      LEFT JOIN OCS0132 F ON  F.HOSP_CODE = :f_hosp_code AND F.CODE = A.INPUT_GUBUN AND F.CODE_TYPE = 'INPUT_GUBUN' AND F.LANGUAGE = :language                            ");
		sql.append("	      LEFT JOIN OCS0116 D ON  D.HOSP_CODE = :f_hosp_code AND D.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                            ");
		sql.append("	      INNER JOIN OCS0140 G ON G.HOSP_CODE = :f_hosp_code AND G.ORDER_GUBUN = A.ORDER_GUBUN AND G.INPUT_TAB = A.INPUT_TAB                                                  ");
		sql.append("	      LEFT JOIN( SELECT X.SG_CODE , X.SG_NAME , X.BUN_CODE                                                                                                               ");
		sql.append("	              , X.BULYONG_YMD                                                                                                                                            ");
		sql.append("	              , X.HOSP_CODE                                                                                                                                              ");
		sql.append("	           FROM (SELECT SG_CODE, SG_NAME, BUN_CODE, BULYONG_YMD, HOSP_CODE,SG_YMD  FROM BAS0310 WHERE HOSP_CODE = :f_hosp_code) X                                                                                                                                                ");
		sql.append("	          WHERE X.HOSP_CODE = :f_hosp_code                                                                                                                               ");
		sql.append("	            AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                                                        ");
		sql.append("	                               FROM BAS0310 Z                                                                                                                            ");
		sql.append("	                              WHERE Z.HOSP_CODE = X.HOSP_CODE                                                                                                            ");
		sql.append("	                                AND Z.SG_CODE = X.SG_CODE AND HOSP_CODE = :f_hosp_code ) ) H ON H.HOSP_CODE = B.HOSP_CODE AND H.SG_CODE = B.SG_CODE                                                   ");
		//sql.append("	      LEFT JOIN DRG0120 J ON J.HOSP_CODE = :f_hosp_code AND J.BOGYONG_CODE = A.BOGYONG_CODE                                                                              ");
		sql.append("	      LEFT JOIN DRG0120 J ON J.BOGYONG_CODE = A.BOGYONG_CODE  AND J.LANGUAGE = :language   AND J.HOSP_CODE = :f_hosp_code                                                                         	 ");
		sql.append("	 WHERE A.HOSP_CODE        = :f_hosp_code                                                                                                                                 ");
		sql.append("	   AND A.BUNHO            = :f_bunho                                                                                                                                     ");
		sql.append("	   AND A.FKINP1001        = :f_jubsu_no                                                                                                                                  ");
		if(ocs1003Q09){
			sql.append("	   AND IF(:f_kijun = 'H', IFNULL(A.HOPE_DATE, IFNULL(A.RESER_DATE, A.ORDER_DATE)), A.ORDER_DATE)  = :f_naewon_date                                                   ");
			sql.append("	   AND A.INPUT_GWA        = :f_gwa																																	");
		}else{
			sql.append("	   AND A.ORDER_DATE       = :f_naewon_date                                                                                                                               ");
		}
		sql.append("	   AND A.INPUT_DOCTOR     = :f_doctor                                                                                                                                    ");
		sql.append("	   AND A.INPUT_TAB     LIKE :f_input_tab                                                                                                                                 ");
		if(ocs1003Q09){
			 sql.append(" AND (																																									");
			 sql.append("       (     :f_input_gubun = 'D%'                           																											");
			 sql.append("         AND A.INPUT_GUBUN LIKE 'D%' )                       																											");
			 sql.append("       OR                                                    																											");
			 sql.append("       ( :f_input_gubun = 'NR'                               																											");
			 sql.append("         AND (   A.INPUT_GUBUN LIKE 'D%'                     																											");
			 sql.append("              OR A.INPUT_GUBUN = 'NR' ) )                    																											");
			 sql.append("       OR                                                    																											");
			 sql.append("       ( :f_input_gubun NOT IN ('D%', 'NR')                  																											");
			 sql.append("         AND (   A.INPUT_GUBUN LIKE 'D%'                     																											");
			 sql.append("              OR A.INPUT_GUBUN = :f_input_gubun ) )          																											");
			 sql.append("     )                                                       																											");
			 sql.append(" AND IFNULL(A.TEL_YN     , 'N') LIKE :f_tel_yn               																											   ");
		}else{
			sql.append("	   AND IFNULL(A.INSTEAD_YN, 'N') = :f_instead_yn                                                                                                                        ");
			sql.append("	   AND IFNULL(A.APPROVE_YN, 'N') = :f_approve_yn                                                                                                                        ");
			sql.append("	   AND IFNULL(A.POSTAPPROVE_YN, 'N') = :f_prepost_gubun                                                                                                                 ");
		}
		sql.append("	   AND IFNULL(A.DISPLAY_YN , 'Y') = 'Y'                                                                                                                                  ");
		sql.append("	   AND IFNULL(A.DC_YN,'N')   = 'N'                                                                                                                                       ");
		sql.append("	   AND A.NALSU           >= 0                                                                                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_jubsu_no", jubsuNo);
		query.setParameter("f_naewon_date", naewonDate);
		if(ocs1003Q09){
			query.setParameter("f_input_gubun", inputGubun);
			query.setParameter("f_tel_yn", telYn);
			query.setParameter("f_kijun", kijun);
			query.setParameter("f_gwa", gwa);
		}else{
			query.setParameter("f_instead_yn", insteadYN);
			query.setParameter("f_approve_yn", approveYn);
			query.setParameter("f_prepost_gubun", prepostGubun);
		}
		
		List<OCSAPPROVEGrdOrderInfo> list = new JpaResultMapper().list(query, OCSAPPROVEGrdOrderInfo.class);
		LOG.info("[END] getOCSAPPROVEGrdOrderListItemUnion");
		return list;
	}
	
	private String fnOcsBulyongCheckOut(OCSAPPROVEGrdOrderInfo item,
			String buyoCheck) throws ParseException {
		Date date = DateUtil.toDate(item.getbBulyongYmd(), DateUtil.PATTERN_YYMMDD);
		if(StringUtils.isEmpty(item.getbBulyongYmd()) ||( new Date().equals(date) || new Date().after(date))){
			buyoCheck = "N";
		}else{
			buyoCheck = "Y";
		}
		return buyoCheck;
	}

	@Override
	public void callPrOcsUpdateXrtJubsu(String hospCode, String inOutGubun,Double fkOcs, String userId, Date jubsuDate, String jubsuTime,String actDoctor) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_UPDATE_XRT_JUBSU ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_JUBSU_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ACT_DOCTOR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		query.setParameter("I_FKOCS", fkOcs);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_JUBSU_DATE", jubsuDate);
		query.setParameter("I_JUBSU_TIME", jubsuTime);
		query.setParameter("I_ACT_DOCTOR", actDoctor);
		
		Boolean isValid = query.execute();
		
	}

	@Override
	public void callPrOcsUpdateXrtAacting(String hospCode, String inOutGubun,
			Double fkOcs, String userId, String actBuseo, Date actingDate,
			String actingTime, String resultDate, String xrtDrYn) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_UPDATE_XRT_ACTING ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACT_BUSEO", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_ACTING_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_RESULT_DATE", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_XRT_DR_YN", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		query.setParameter("I_FKOCS", fkOcs);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_ACT_BUSEO", actBuseo);
		query.setParameter("I_ACTING_DATE", actingDate);
		query.setParameter("I_ACTING_TIME", actingTime);
		query.setParameter("I_RESULT_DATE", resultDate);
		query.setParameter("I_XRT_DR_YN", xrtDrYn);
		
		Boolean isValid = query.execute();
	}

	@Override
	public List<ComboListItemInfo> getNut0001U00InitializeScreenOcs1003DoctorGwaInfo(
			String hospCode, Double pkocs1003) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.DOCTOR  DOCTOR					");
		sql.append("	        , A.GWA   GWA                   ");
		sql.append("	 FROM OCS1003 A                         ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code        ");
		sql.append("	  AND A.PKOCS1003 = :f_pkocskey         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocskey", pkocs1003);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public ComboListItemInfo callPrRehAddRehasinryouryou(String hospCode,String language, Date iOrderDate, String iBunho,
			Double iFkout1001, String iDoctor, String iSinryouryouGubun,String iInputId, String iInputTab, String iIudGubun) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_REH_ADD_REHASINRYOURYOU ");
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOUT1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SINRYOURYOU_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_TAB", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_RESULT", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_RESULT_MSG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_ORDER_DATE", iOrderDate);
		query.setParameter("I_BUNHO", iBunho);
		query.setParameter("I_FKOUT1001", iFkout1001);
		query.setParameter("I_DOCTOR", iDoctor);
		query.setParameter("I_SINRYOURYOU_GUBUN", iSinryouryouGubun);
		query.setParameter("I_INPUT_ID", iInputId);
		query.setParameter("I_INPUT_TAB", iInputTab);
		query.setParameter("I_IUD_GUBUN", iIudGubun);
		
		Boolean isValid = query.execute();
		ComboListItemInfo info = new ComboListItemInfo((String) query.getOutputParameterValue("O_RESULT"),
				(String) query.getOutputParameterValue("O_RESULT_MSG"));
		return info;
	}
	
	@Override
	public List<PHY2001U04GrdOutInfo> getPHY2001U04GrdOutInfo(String hospCode,Date orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')       ");
		sql.append("      , A.BUNHO                                     ");
		sql.append("      , B.SUNAME                                    ");
		sql.append("      , B.SUNAME2                                   ");
		sql.append("      , D.DOCTOR_NAME                               ");
		sql.append("      , A.HANGMOG_CODE                              ");
		sql.append("      , E.HANGMOG_NAME                              ");
		sql.append("      , C.PT_FLAG                                   ");
		sql.append("      , C.OT_FLAG                                   ");
		sql.append("      , C.ST_FLAG                                   ");
		sql.append("      , C.BU_FLAG                                   ");
		sql.append("      , A.OCS_FLAG                                  ");
		sql.append("   FROM OCS1003 A                                   ");
		sql.append("       ,OUT0101 B                                   ");
		sql.append("       ,PHY8002 C                                   ");
		sql.append("       ,BAS0270 D                                   ");
		sql.append("       ,OCS0103 E                                   ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code               ");
		sql.append("    AND A.ORDER_DATE   = :f_order_date              ");
		sql.append("    AND A.INPUT_TAB    = '10'                       ");
		sql.append("    AND A.JUNDAL_TABLE = 'HOM'                      ");
		sql.append("    AND A.JUNDAL_PART  = 'HOM'                      ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                   ");
		sql.append("    AND B.BUNHO     = A.BUNHO                       ");
		sql.append("    AND C.HOSP_CODE = A.HOSP_CODE                   ");
		sql.append("    AND C.FK_OCS    = A.PKOCS1003                   ");
		sql.append("    AND D.HOSP_CODE  = A.HOSP_CODE                  ");
		sql.append("    AND D.DOCTOR     = A.DOCTOR                     ");
		sql.append("    AND E.HOSP_CODE    = A.HOSP_CODE                ");
		sql.append("    AND E.HANGMOG_CODE = A.HANGMOG_CODE             ");
		sql.append("  ORDER BY A.ORDER_DATE DESC						");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate);
		List<PHY2001U04GrdOutInfo> list = new JpaResultMapper().list(query, PHY2001U04GrdOutInfo.class);
		return list;
	}

	@Override
	public BigInteger getNewOrderFormOUT(String hospCode, Date orderDate,String timeHour, String timeMin, String timeSec) {
		StringBuilder sql = new StringBuilder();
		String time = "000 " + timeHour + ":" + timeMin + ":" + timeSec;
		sql.append(" SELECT COUNT(A.SYS_DATE)                            ");
		sql.append("   FROM OCS1003 A                                    ");
		sql.append("      , PHY8002 C                                    ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                ");
		sql.append("    AND A.ORDER_DATE   = :f_order_date               ");
		sql.append("    AND A.INPUT_TAB    = '10'                        ");
		sql.append("    AND A.JUNDAL_TABLE = 'HOM'                       ");
		sql.append("    AND A.JUNDAL_PART  = 'HOM'                       ");
		sql.append("    AND A.OCS_FLAG     = '1'                         ");
		sql.append("    AND ADDTIME(A.SYS_DATE , :f_time) > SYSDATE()   ");
		sql.append("    AND C.HOSP_CODE = A.HOSP_CODE                    ");
		sql.append("    AND C.FK_OCS    = A.PKOCS1003                    ");
		sql.append("  ORDER BY A.ORDER_DATE DESC						 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_time", time);
		List<BigInteger> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}     

	@Override
	public BigInteger getPhy8002U01GetLayJissekiDataOcs1003Count(String hospCode,
			Double fkOcs) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT COUNT(*) CNT						");
		sql.append("	FROM OCS1003 A                          ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code        ");
		sql.append("	AND A.SORT_FKOCSKEY = :f_fk_ocs         ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fk_ocs", fkOcs);
		
		List<BigInteger> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	public List<OCS2015U03OrderGubunInfo> getOCS2015U03OrderGubunInfo(String hospCode, String patientCode, Double reservationCode){
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT 								");
		sql.append("	INPUT_TAB                         ");
		sql.append("	FROM OCS1003                        ");
		sql.append("	WHERE                               ");
		sql.append("	HOSP_CODE = :f_hopital_code         ");
		sql.append("	AND BUNHO = :f_patient_code         ");
		sql.append("	AND FKOUT1001 = :f_reservation_code ");
		sql.append("	GROUP BY                            ");
		sql.append("	INPUT_TAB                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hopital_code", hospCode);
		query.setParameter("f_patient_code", patientCode);
		query.setParameter("f_reservation_code", reservationCode);
		
		List<OCS2015U03OrderGubunInfo> list = new JpaResultMapper().list(query, OCS2015U03OrderGubunInfo.class);
		return list;
	}

	@Override
	public List<ORDERTRANSGrdEditInfo> getORDERTRANSGrdEditInfo(
			String hospCode, String language, String sendYn, Double pk1001,
			Date actingDate, String bunho, String gwa, String doctor) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT   A.FKOUT1003                                            pk1001                                                             ");
		sql.append("    , A.PKOCS1003                                                PKOCS                                                              ");
		sql.append("    , A.GROUP_SER                                                GROUP_SER                                                          ");
		sql.append("    , CONCAT(IFNULL(A.GROUP_SER,''),IFNULL(A.FKOUT1001,''))      GROUP_OUT1001                                                      ");
		sql.append("    , IFNULL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME                                                ");
		sql.append("    , A.HANGMOG_CODE                                             HANGMOG_CODE                                                       ");
		sql.append("    , B.HANGMOG_NAME                                             HANGMOG_NAME                                                       ");
		sql.append("    , A.SPECIMEN_CODE                                            SPECIMEN_CODE                                                      ");
		sql.append("    , D.SPECIMEN_NAME                                            SPECIMEN_NAME                                                      ");
		sql.append("    , A.SURYANG                                                  SURYANG                                                            ");
		sql.append("    , A.ORD_DANUI                                                ORD_DANUI                                                          ");
		sql.append("    , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code,:f_language)            ORD_DANUI_NAME                           ");
		sql.append("    , A.DV_TIME                                                  DV_TIME                                                            ");
		sql.append("    , A.DV                                                       DV                                                                 ");
		sql.append("    , A.NALSU                                                    NALSU                                                              ");
		sql.append("    , A.JUSA                                                     JUSA                                                               ");
		sql.append("    , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA, :f_hosp_code,:f_language)                      JUSA_NAME                                ");
		sql.append("    , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', A.JUSA_SPD_GUBUN, :f_hosp_code,:f_language)  JUSA_SPD_NAME                            ");
		sql.append("    , A.BOGYONG_CODE                                             BOGYONG_CODE                                                       ");
		sql.append("    , FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN, :f_hosp_code,:f_language)                            ");
		sql.append("    , IFNULL(A.EMERGENCY, 'N')                                      EMERGENCY                                                       ");
		sql.append("    , A.JUNDAL_PART                                              JUNDAL_PART                                                        ");
		sql.append("    , A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN                                                    ");
		sql.append("    , IFNULL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN                                           ");
		sql.append("    , A.OCS_FLAG                                                 OCS_FLAG                                                           ");
		sql.append("    , A.ORDER_GUBUN                                              ORDER_GUBUN                                                        ");
		sql.append("    , A.BUNHO                                                    BUNHO                                                              ");
		sql.append("    , A.ORDER_DATE                                               ORDER_DATE                                                         ");
		sql.append("    , A.GWA                                                      GWA                                                                ");
		sql.append("    , A.DOCTOR                                                   DOCTOR                                                             ");
		sql.append("    , A.SEQ                                                      SEQ                                                                ");
		sql.append("    , A.SOURCE_FKOCS1003                                         FKOCS003                                                           ");
		sql.append("    , A.SUB_SUSUL                                                SUB_SUSUL                                                          ");
		sql.append("    , A.ACTING_DATE      ACTING_DATE                                      															");
		sql.append("  , CASE WHEN A.JUNDAL_PART  IN ('HOM','PA') THEN NULL                                                                              ");
		sql.append("     ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)) END HOPE_DATE                                                     ");
		sql.append("  , A.SUNAB_DATE                                               SUNAB_DATE                                                           ");
		sql.append("  , IFNULL(A.HOME_CARE_YN , 'N')                                  HOME_CARE_YN                                                      ");
		sql.append("  , IFNULL(A.REGULAR_YN, 'N')                                     REGULAR_YN                                                        ");
		sql.append("  , A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN                                                      ");
		sql.append("  , E.BUN_CODE                                                 BUN_CODE                                                             ");
		sql.append("  , B.INPUT_CONTROL                                            INPUT_CONTROL                                                        ");
		sql.append("  , B.ORDER_GUBUN                                              ORDER_GUBUN_BAS                                                      ");
		sql.append("  , CASE WHEN (A.JUNDAL_PART = 'HOM' OR (A.JUNDAL_PART = 'PA' AND IFNULL(B.WONNAE_DRG_YN, 'N') = 'N')) THEN 'Y'						");
		sql.append("    WHEN A.ACTING_DATE IS NOT NULL THEN 'Y'  ELSE  'N' END ACTING_YN                                                                ");
		sql.append("  , :f_send_yn                                                 SELECT_YN                                                            ");
		sql.append("  , A.IF_DATA_SEND_YN                                          SEND_YN                                                              ");
		sql.append("  , F.IF_FLAG                                                  IF_FLAG                                                              ");
		sql.append("  , F.FKIFS1004                                                FKIFS1004                                                            ");
		sql.append("  , AA.NAEWON_YN                                               NAEWON_YN                                                            ");
		sql.append("  ,CONCAT(TRIM(LPAD(C.SORT_KEY, 2, '0'))                                                                                            ");
		sql.append("    , TRIM(LPAD(A.GROUP_SER,10, '0'))                                                                                               ");
		sql.append("    , TRIM(LPAD(AA.PKOUT1001,10, '0'))                                                                                              ");
		sql.append("    , TRIM(LPAD(IFNULL(A.BOM_SOURCE_KEY, A.PKOCS1003),11, '0'))                                                                     ");
		sql.append("    , CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9' ELSE '0' END                                                                  ");
		sql.append("    , TRIM(LPAD(A.SEQ,11, '0'))                                                                                                     ");
		sql.append("    , TRIM(LPAD(A.PKOCS1003,11, '0')))   ORDER_BY_KEY                                                                               ");
		sql.append("    , B.TRIAL_FLG   TRIAL_FLG                                                                               						");
		sql.append("  , G.CODE_NAME   TRANS_YN						                                                                        			");
		sql.append("  , FN_BAS_LOAD_NU_CODE(:f_hosp_code,'100', :f_acting_date, B.ORDER_GUBUN, E.BUN_CODE, 'N', 'N', '00', '%', '%', 'N', '%') CLS_CODE	");
		sql.append("    ,  B.SG_CODE SG_CODE                                              												                ");
		sql.append("    , IFNULL(A.ORDER_STATUS, '')																									");
		sql.append("    FROM   OCS1003 A LEFT JOIN  OUT1001 AA ON AA.PKOUT1001 = A.FKOUT1001                                                            ");
		sql.append("           LEFT JOIN OCS0132 C ON C.HOSP_CODE = A.HOSP_CODE AND C.LANGUAGE = :f_language                                           	");
		sql.append("           AND C.CODE_TYPE = 'ORDER_GUBUN_BAS' AND C.CODE = SUBSTR(A.ORDER_GUBUN, 2, 1)                                         	");
		sql.append("           LEFT JOIN  OCS0116 D ON D.HOSP_CODE = A.HOSP_CODE AND D.SPECIMEN_CODE = A.SPECIMEN_CODE                            		");
		sql.append("           LEFT JOIN (SELECT X.HOSP_CODE, X.FKOCS1003, X.FKOUT1003, X.IF_FLAG, X.FKIFS1004                                 			");
		sql.append("                       FROM IFS2011 X                                                                                               ");
		sql.append("                      WHERE X.HOSP_CODE = :f_hosp_code                                                                              ");
		sql.append("                        AND X.FKOUT1003 = :f_pk1001                                                                                 ");
		sql.append("                        AND X.PKIFS2011 IN (SELECT MAX(Z.PKIFS2011) PKIFS2011                                                       ");
		sql.append("                                              FROM IFS2011 Z                                                                        ");
		sql.append("                                             WHERE Z.HOSP_CODE = X.HOSP_CODE                                                        ");
		sql.append("                                               AND Z.BUNHO = X.BUNHO                                                                ");
		sql.append("                                             GROUP BY  Z.FKOCS1003, Z.HOSP_CODE, Z.FKOUT1003)) F ON F.HOSP_CODE = A.HOSP_CODE       ");
		sql.append("           AND F.FKOUT1003 = A.FKOUT1003 AND F.FKOCS1003 = A.PKOCS1003                                 								");
		sql.append("           LEFT JOIN BAS0102 G ON G.HOSP_CODE = A.HOSP_CODE AND G.CODE_TYPE = 'CLIS_FLG' AND G.CODE = 'TRANS_YN'                    ");
		sql.append("           AND G.LANGUAGE = :f_language                                                                                             ");
		sql.append("      , (                                                                                                                           ");
		sql.append("   SELECT A.HANGMOG_CODE , A.ORDER_GUBUN  , A.HANGMOG_NAME , A.INPUT_CONTROL , A.ORDER_GUBUN  B_ORDER_GUBUN							");
		sql.append("			, A.SG_CODE , A.TRIAL_FLG, A.WONNAE_DRG_YN																				");
		sql.append("           FROM OCS0103 A                                                                                                           ");
		sql.append("          WHERE A.HOSP_CODE           = :f_hosp_code                                                                                ");
		sql.append("            AND A.START_DATE          = (SELECT MAX(Z.START_DATE)                                                                   ");
		sql.append("                                           FROM OCS0103 Z                                                                           ");
		sql.append("                                          WHERE Z.HOSP_CODE       = :f_hosp_code                                                    ");
		sql.append("                                            AND Z.HANGMOG_CODE    = A.HANGMOG_CODE                                                  ");
		sql.append("                                            AND Z.START_DATE      <= :f_acting_date                                                 ");
		sql.append("                                            AND (   Z.END_DATE    IS NULL                                                           ");
		sql.append("                                                 OR Z.END_DATE    >= :f_acting_date                                                 ");
		sql.append("                                                )                                                                                   ");
		sql.append("                                         )                                                                                          ");
		sql.append("            AND (   A.END_DATE    IS NULL                                                                                           ");
		sql.append("                 OR A.END_DATE    >= :f_acting_date                                                                                 ");
		sql.append("                )                                                                                                                   ");
		sql.append("        )       B                                                                                                                   ");
		sql.append("      , (                                                                                                                           ");
		sql.append("        SELECT A.SG_CODE  , A.BUN_CODE                                                                                              ");
		sql.append("           FROM BAS0310 A                                                                                                           ");
		sql.append("          WHERE A.HOSP_CODE           = :f_hosp_code                                                                                ");
		sql.append("            AND A.SG_YMD              = (SELECT MAX(Z.SG_YMD)                                                                       ");
		sql.append("              FROM BAS0310 Z                                                                                                        ");
		sql.append("             WHERE Z.HOSP_CODE       = :f_hosp_code                                                                                 ");
		sql.append("                                                 AND Z.SG_CODE         = A.SG_CODE                                                  ");
		sql.append("                                                 AND Z.SG_YMD          <= :f_acting_date                                            ");
		sql.append("                                                 AND (   Z.BULYONG_YMD IS NULL                                                      ");
		sql.append("                                                      OR Z.BULYONG_YMD >= :f_acting_date                                            ");
		sql.append("                                                     )                                                                              ");
		sql.append("                                              )                                                                                     ");
		sql.append("                 AND (   A.BULYONG_YMD IS NULL                                                                                      ");
		sql.append("                      OR A.BULYONG_YMD >= :f_acting_date                                                                            ");
		sql.append("                     )                                                                                                              ");
		sql.append("             )       E                                                                                                              ");
		sql.append("      WHERE A.HOSP_CODE        = :f_hosp_code                                                                                       ");
		sql.append("        AND (A.FKOUT1003 IS NULL OR A.FKOUT1003 = :f_pk1001)                                                                        ");
		sql.append("        AND IFNULL(A.IF_DATA_SEND_YN, 'N')  = :f_send_yn                                                                            ");
		sql.append("                                                                                                                                    ");
		sql.append("        AND (   IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, ORDER_DATE)))  = :f_acting_date                      ");
		sql.append("             OR (    A.ORDER_DATE   = :f_acting_date                                                                                ");
		sql.append("                 AND A.JUNDAL_PART IN ('HOM', 'PA')                                                                                 ");
		sql.append("                                                                                                                                    ");
		sql.append("                )                                                                                                                   ");
		sql.append("            )                                                                                                                       ");
		sql.append("        AND A.BUNHO                          = :f_bunho                                                                             ");
		sql.append("        AND IFNULL(A.ACTING_DATE, A.ORDER_DATE) = :f_acting_date                                                                    ");
		sql.append("        AND A.GWA                            = :f_gwa                                                                               ");
		sql.append("        AND A.DOCTOR                         = :f_doctor                                                                            ");
		sql.append("     AND A.NALSU            >= 0                                                                                                    ");
		sql.append("     AND IFNULL(A.DC_YN,'N')   = 'N'                                                                                                ");
		sql.append("     AND IFNULL(A.MUHYO,'N')   = 'N'                                                                                                ");
		sql.append("     AND B.HANGMOG_CODE     = A.HANGMOG_CODE                                                                                        ");
		sql.append("     AND E.SG_CODE          = B.SG_CODE                                                                                             ");
		sql.append("   ORDER BY ORDER_BY_KEY																											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_pk1001", pk1001);
		query.setParameter("f_acting_date", actingDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		
		List<ORDERTRANSGrdEditInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdEditInfo.class);
		return list;
	}

	@Override
	public List<ORDERTRANSGrdListNonSendYnInfo> getORDERTRANSGrdListNonSendYnInfo(
			String hospCode, String language, Date actingDate, String bunho) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT   A.FKOUT1001                                                   fkout1001                                                   ");
		sql.append("  , A.BUNHO                                                    BUNHO                                                                ");
		sql.append("  , F.SUNAME                                                   SUNAME                                                               ");
		sql.append("  , IFNULL(A.ACTING_DATE, A.ORDER_DATE)                           ACTING_DATE                                                       ");
		sql.append("  , A.GWA                                                      GWA                                                                  ");
		sql.append("  , FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), :f_hosp_code,:f_language)                GWA_NAME                                        ");
		sql.append("  , A.DOCTOR                                                   DOCTOR                                                               ");
		sql.append("  , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE(), :f_hosp_code)          DOCTOR_NAME                                                 ");
		sql.append("  , IFNULL(MAX(AA.GUBUN), '##')                                   GUBUN                                                             ");
		sql.append("  , FN_BAS_LOAD_GUBUN_NAME(IFNULL(MAX(AA.GUBUN), '##') , SYSDATE(), :f_hosp_code) GUBUN_NAME                                        ");
		sql.append("  ,case  TRIM(MAX(A.IF_DATA_SEND_DATE)) when null then 'N' else 'Y' end SENDED_YN                                                   ");
		sql.append("  , MAX(AA.NAEWON_YN)                                            NAEWON_YN                                                          ");
		sql.append("  , CONCAT(DATE_FORMAT(IFNULL(A.ACTING_DATE, A.ORDER_DATE), '%Y%m%d')                                                               ");
		sql.append("    , A.GWA                                                                                                                         ");
		sql.append("    , A.DOCTOR)                                             ORDER_BY_KEY                                                            ");
		sql.append("        ,FN_BAS_LOAD_CODE_NAME('CHOJAE',AA.CHOJAE,:f_hosp_code,:f_language)              CHOJAE_NAME                                 ");
		sql.append("     FROM  OCS1003 A LEFT JOIN OCS0132 C ON  C.HOSP_CODE = A.HOSP_CODE  AND C.LANGUAGE =  :f_language                               ");
		sql.append("                          AND C.CODE_TYPE = 'ORDER_GUBUN_BAS'                                                                       ");
		sql.append("                          AND C.CODE = SUBSTR(A.ORDER_GUBUN, 2, 1)                                                                  ");
		sql.append("                            LEFT JOIN  OCS0116 D ON D.HOSP_CODE = A.HOSP_CODE                                                       ");
		sql.append("                              AND D.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                 ");
		sql.append("         , OUT1001 AA                                                                                                               ");
		sql.append("         , (                                                                                                                        ");
		sql.append("            SELECT A.HANGMOG_CODE  , A.SG_CODE                                                                                      ");
		sql.append("              FROM OCS0103 A                                                                                                        ");
		sql.append("             WHERE A.HOSP_CODE           = :f_hosp_code                                                                             ");
		sql.append("               AND A.START_DATE          = (SELECT MAX(Z.START_DATE)                                                                ");
		sql.append("                                              FROM OCS0103 Z                                                                        ");
		sql.append("                                             WHERE Z.HOSP_CODE       = :f_hosp_code                                                 ");
		sql.append("                                               AND Z.HANGMOG_CODE    = A.HANGMOG_CODE                                               ");
		sql.append("                                               AND Z.START_DATE      <= :f_acting_date                                              ");
		sql.append("                                               AND (   Z.END_DATE    IS NULL                                                        ");
		sql.append("                                                    OR Z.END_DATE    >= :f_acting_date                                              ");
		sql.append("                                                   )                                                                                ");
		sql.append("                                            )                                                                                       ");
		sql.append("               AND (   A.END_DATE    IS NULL                                                                                        ");
		sql.append("                    OR A.END_DATE    >= :f_acting_date                                                                              ");
		sql.append("                   )                                                                                                                ");
		sql.append("           )       B                                                                                                                ");
		sql.append("         , (                                                                                                                        ");
		sql.append("           SELECT A.SG_CODE                                                                                                         ");
		sql.append("              FROM BAS0310 A                                                                                                        ");
		sql.append("             WHERE A.HOSP_CODE           = :f_hosp_code                                                                             ");
		sql.append("               AND A.SG_YMD              = (SELECT MAX(Z.SG_YMD)                                                                    ");
		sql.append("                                              FROM BAS0310 Z                                                                        ");
		sql.append("                                             WHERE Z.HOSP_CODE       = :f_hosp_code                                                 ");
		sql.append("                                               AND Z.SG_CODE         = A.SG_CODE                                                    ");
		sql.append("                                               AND Z.SG_YMD          <= :f_acting_date                                              ");
		sql.append("                                               AND (   Z.BULYONG_YMD IS NULL                                                        ");
		sql.append("                                                    OR Z.BULYONG_YMD >= :f_acting_date                                              ");
		sql.append("                                                   )                                                                                ");
		sql.append("                                            )                                                                                       ");
		sql.append("               AND (   A.BULYONG_YMD IS NULL                                                                                        ");
		sql.append("                    OR A.BULYONG_YMD >= :f_acting_date                                                                              ");
		sql.append("                   )                                                                                                                ");
		sql.append("           )       E                                                                                                                ");
		sql.append("         , OUT0101 F                                                                                                                ");
		sql.append("      WHERE A.HOSP_CODE        = :f_hosp_code                                                                                       ");
		sql.append("        AND A.BUNHO            LIKE :f_bunho                                                                                        ");
		sql.append("                                                                                                                                    ");
		sql.append("        AND IFNULL(A.IF_DATA_SEND_YN, 'N')  = 'N'                                                                                   ");
		sql.append("                                                                                                                                    ");
		sql.append("        AND (   IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, ORDER_DATE)))  <= :f_acting_date                     ");
		sql.append("             OR (    A.ORDER_DATE   <= :f_acting_date                                                                               ");
		sql.append("                 AND A.JUNDAL_PART IN ('HOM', 'PA')                                                                                 ");
		sql.append("                                                                                                                                    ");
		sql.append("                )                                                                                                                   ");
		sql.append("            )                                                                                                                       ");
		sql.append("        AND A.NALSU            >= 0                                                                                                 ");
		sql.append("        AND IFNULL(A.DC_YN,'N')   = 'N'                                                                                             ");
		sql.append("        AND IFNULL(A.MUHYO,'N')   = 'N'                                                                                             ");
		sql.append("        AND AA.PKOUT1001       = A.FKOUT1001                                                                                        ");
		//TODO check why have this code will get slow in vietnam hospital
//		sql.append("        AND B.HOSP_CODE        = A.HOSP_CODE                                                                                        ");
		sql.append("        AND B.HANGMOG_CODE     = A.HANGMOG_CODE                                                                                     ");
//		sql.append("        AND E.HOSP_CODE        = B.HOSP_CODE                                                                                        ");
		sql.append("        AND E.SG_CODE          = B.SG_CODE                                                                                          ");
		sql.append("        AND F.HOSP_CODE           = A.HOSP_CODE                                                                                     ");
		sql.append("        AND F.BUNHO               = A.BUNHO                                                                                         ");
		sql.append("      GROUP BY A.FKOUT1001                                                                                                          ");
		sql.append("            ,  A.BUNHO                                                                                                              ");
		sql.append("            , F.SUNAME                                                                                                              ");
		sql.append("            , IFNULL(A.ACTING_DATE, A.ORDER_DATE)                                                                                   ");
		sql.append("            , A.GWA                                                                                                                 ");
		sql.append("            , A.DOCTOR                                                                                                              ");
		sql.append("            ,CONCAT(DATE_FORMAT(IFNULL(A.ACTING_DATE, A.ORDER_DATE), '%Y%m%d')                                                      ");
		sql.append("              , A.GWA                                                                                                               ");
		sql.append("              , A.DOCTOR )                                                                                                          ");
		sql.append("      , FN_BAS_LOAD_CODE_NAME('CHOJAE',AA.CHOJAE,:f_hosp_code,:f_language )        				 					     			");
		sql.append("      ORDER BY ORDER_BY_KEY DESC																									");
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_acting_date", actingDate);
		query.setParameter("f_bunho", bunho);
		List<ORDERTRANSGrdListNonSendYnInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdListNonSendYnInfo.class);
		return list;
	}
	@Override
	public String callPrOutCheckOrderEnd(String hospCode, String langage,
			Date actingDate, String doctor, String bunho) {
		String oChk = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OUT_CHECK_ORDER_END");
		query.registerStoredProcedureParameter("I_HOSP_CODE" , String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE" , String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE" , Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR" , String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO" , String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_CHK" , String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", langage);
		query.setParameter("I_ACTING_DATE", actingDate);
		query.setParameter("I_DOCTOR", doctor);
		query.setParameter("I_BUNHO", bunho);
		Boolean isValid = query.execute();
		oChk = (String) query.getOutputParameterValue("O_CHK");
		return oChk;
	}

	@Override
	public List<ORCATransferOrdersClaimInfo> getORCATransferOrdersClaimInfo(String hospCode, String bunho, Double pkout1001) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT  ''	DOC_UID_03 ,				    ");
		sql.append("		UPD_DATE 	CONFIRM_DATE_03 ,		");
		sql.append("		DATE_FORMAT(ACTING_DATE, '%Y/%m/%d')  PERFORM_TIME , ACTING_TIME   ACTING_TIME , ");
		sql.append("		SURYANG		BUNDLE_NUMBER ,			");
		sql.append("		HANGMOG_CODE		HANGMOG_CODE ,	");
		sql.append("		DOCTOR				DOCTOR_ID ,		");
		sql.append("		GWA				GWA 	,		    ");
		sql.append("		''		GWA_NAME 	 , SG_CODE      ");
		sql.append("	FROM OCS1003 WHERE BUNHO = :bunho		");
		sql.append("		AND HOSP_CODE	= :hosp_code		");
		sql.append("		AND FKOUT1001	= :pkout1001 		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("pkout1001", pkout1001);
		List<ORCATransferOrdersClaimInfo> list = new JpaResultMapper().list(query, ORCATransferOrdersClaimInfo.class);
		return list;
	}
	
	@Override
	public List<ORCATransferOrdersClaimOrdersFeeInfo> getORCATransferOrdersClaimOrdersFeeInfo(
			String hospCode, String language, String bunho, Double pkout1001, List<String> listHangmocCode) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT 	 '' 														DOC_UID																	");
		sql.append("			,T.CONFIRM_DATE																														");
		sql.append("			,T.PERFORM_TIME																														");
		sql.append("			,CASE 																																");
		sql.append("			 WHEN T.CLASS_CODE IN ('210','211','230', '231', '290', '291','141', '148') OR LEFT(T.CLASS_CODE, 1) = '7' THEN T.NALSU				");
		sql.append("			 WHEN T.CLASS_CODE IN ('220', '221') THEN T.DV																						");
		sql.append("			 ELSE '1' END												BUNDLE_NUMBER															");
		sql.append("			,T.HANGMOG_CODE																														");
		sql.append("			,T.DOCTOR_ID																														");
		sql.append("			,T.GWA																																");
		sql.append("			,IFNULL(T.NUMB, '')											NUMB																	");
		sql.append("			,'10'                                                       NUMBER_CODE																");
		sql.append("			,IFNULL(T.CLASS_CODE, '')									CLS_CODE																");
		sql.append("			,IFNULL(TT.GWA_NAME, '')									GWA_NAME																");
		sql.append("			,T.ACTING_DATE																														");
		sql.append("	FROM																																		");
		sql.append("	(																																			");
		sql.append("		SELECT																																	");
		sql.append("				 A.UPD_DATE                                                         CONFIRM_DATE												");
		sql.append("				,A.ACTING_DATE                                                       PERFORM_TIME												");
		sql.append("				,X.IF_CODE                                                          HANGMOG_CODE												");
		sql.append("				,Y.IF_CODE                                                          DOCTOR_ID													");
		sql.append("				,Z.IF_CODE                                                          GWA															");
		sql.append("				,A.SURYANG*A.NALSU*A.DV                                             NUMB														");
		sql.append("				,FN_BAS_LOAD_NU_CODE(A.HOSP_CODE, '100', A.ACTING_DATE,																			");
		sql.append("					substring(A.ORDER_GUBUN, -1), C.BUN_CODE, 'N', 'N',																			");
		sql.append("					'00','%', IFNULL(C.TAX_YN, '%'),'N', '%') CLASS_CODE																		");
		sql.append("				,A.ACTING_DATE                                                      ACTING_DATE													");
		sql.append("				,A.NALSU																														");
		sql.append("				,A.DV																															");
		sql.append("		FROM OCS1003 A																															");
		sql.append("		LEFT OUTER JOIN IFS0003 X ON A.HANGMOG_CODE = X.OCS_CODE																				");
		sql.append("								 AND X.MAP_GUBUN = 'IF_ORCA_HANGMOG'																			");
		sql.append("								 AND X.HOSP_CODE = :f_hosp_code																					");
		sql.append("		LEFT OUTER JOIN IFS0003 Y ON SUBSTRING(A.DOCTOR, 3, 10) = Y.OCS_CODE																	");
		sql.append("								 AND Y.MAP_GUBUN = 'IF_ORCA_DOCTOR'																				");
		sql.append("								 AND Y.HOSP_CODE = :f_hosp_code																					");
		sql.append("		LEFT OUTER JOIN IFS0003 Z ON A.GWA = Z.OCS_CODE																							");
		sql.append("								 AND Z.MAP_GUBUN = 'IF_ORCA_GWA'																				");
		sql.append("								 AND Z.HOSP_CODE = :f_hosp_code																					");
		sql.append("		LEFT OUTER JOIN BAS0310 C ON A.HOSP_CODE = C.HOSP_CODE																					");
		sql.append("								 AND A.SG_CODE = C.SG_CODE																						");
		sql.append("								 AND C.SG_YMD = (SELECT MAX(Z.SG_YMD)																			");
		sql.append("												 FROM BAS0310 Z																					");
		sql.append("												 WHERE Z.HOSP_CODE = A.HOSP_CODE																");
		sql.append("												   AND Z.SG_CODE = A.SG_CODE																	");
		sql.append("												   AND Z.SG_YMD <= A.ACTING_DATE																");
		sql.append("												   AND IFNULL(Z.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) > A.ACTING_DATE)				");
		sql.append("		WHERE A.BUNHO = :f_bunho																												");
		sql.append("		  AND A.HOSP_CODE = :f_hosp_code 																										");
		sql.append("		  AND A.FKOUT1001 = :f_pkout_1001																										");
		sql.append("		  AND A.HANGMOG_CODE IN :listHangmocCode																								");
		sql.append("		  ORDER BY CLASS_CODE																													");
		sql.append("	) T																																			");
		sql.append("	LEFT OUTER JOIN BAS0260 TT ON T.GWA = TT.GWA																								");
		sql.append("							  AND TT.LANGUAGE = :f_language																						");
		sql.append(" 							  AND TT.HOSP_CODE = :f_hosp_code																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkout_1001", pkout1001);
		query.setParameter("listHangmocCode", listHangmocCode);
		
		List<ORCATransferOrdersClaimOrdersFeeInfo> list = new JpaResultMapper().list(query, ORCATransferOrdersClaimOrdersFeeInfo.class);
		return list;
	}
	
	@Override
	public String callFnOcsIsNextKensaReser(String hospCode, String buho,Date newDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OCS_IS_NEXT_KENSA_RESER(:I_HOSP_CODE, :I_BUNHO,:I_NAEWON_DATE) "); 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", buho);
		query.setParameter("I_NAEWON_DATE", newDate);
		List<String> result = query.getResultList();
		if(!result.isEmpty() && result.get(0) != null){
			 return result.get(0);
		}
		return null;
	}

	@Override
	public List<OCS2015U00GetOrderReportInfo> getOCS2015U00GetOrderReportInfo(String hospCode, String language, String bunho, Double pkout1001) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT A.HANGMOG_CODE  ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("        FN_DRG_HANGMOG_NAME(:hosp_code, A.HANGMOG_CODE)  ,  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("        A.SURYANG       ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("        A.DV            ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("        A.NALSU         ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("        B.BOGYONG_NAME  ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("        C.CODE_NAME     ,                                    ");
		sql.append("        FN_DRG_WONYOI_TOT_SURYANG(A.NALSU, A.SURYANG, A.DV, A.DV_TIME)   ");
		sql.append("    FROM  OCS1003                        A,                 ");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("          DRG0120                        B,                 ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("          OCS0132                        C                  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    WHERE  A.ORD_DANUI         =         C.CODE             ");                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("   AND A.HOSP_CODE                =         C.HOSP_CODE     ");
		sql.append("   AND :hosp_code                =         C.HOSP_CODE     ");
		sql.append("   AND C.LANGUAGE                 =         :language       ");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("   AND C.CODE_TYPE                =         'ORD_DANUI'     ");                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("   AND A.BOGYONG_CODE             =         B.BOGYONG_CODE  ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("   AND A.FKOUT1001                =         :pkout1001      ");                                                                                                                                                                                                                                                                                                                                                                                                                                               
		sql.append("   AND A.BUNHO                    =         :bunho          ");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("   AND A.HOSP_CODE                =         :hosp_code      ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("   AND A.JUNDAL_TABLE             =         'DRG'  			");
		sql.append("   AND B.LANGUAGE                 =         :language  		");
		sql.append("   AND B.HOSP_CODE                =         :hosp_code  	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		query.setParameter("pkout1001", pkout1001);
		List<OCS2015U00GetOrderReportInfo> list = new JpaResultMapper().list(query, OCS2015U00GetOrderReportInfo.class);
		return list;
	}

	@Override
	public List<String> checkOrderStatus(String hospCode, String bunho, Double pkout1001) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT 'Y' FROM DUAL								");
		sql.append("	WHERE EXISTS										");
		sql.append("		(SELECT ACTING_DATE								");
		sql.append("		 FROM OCS1003									");
		sql.append("		 WHERE OCS1003.BUNHO       =	:bunho			");
		sql.append("		   AND OCS1003.HOSP_CODE   =	:hospCode		");
		sql.append("		   AND OCS1003.FKOUT1001   =	:pkout1001		");
		sql.append("		)												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		
		query.setParameter("bunho", bunho);
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkout1001", pkout1001);
		
		List<String> listResult = query.getResultList();
		return listResult;
	}
	
	@Override
	public List<ORDERTRANSMisaGetHangmogInfo> getORDERTRANSMisaGetHangmogInfo(String hospCode, String bunho,
			String pkout1001) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT HANGMOG_CODE,                                              ");
		sql.append("	HANGMOG_NAME,                                                     ");
		sql.append("	SURYANG,                                                          ");
		sql.append("	NALSU,                                                            ");
		sql.append("	DV                                                                ");
		sql.append("	FROM OCS1003                                                      ");
		sql.append("	WHERE HOSP_CODE = :hospCode                                       ");
		sql.append("	AND BUNHO = :bunho                                                ");
		sql.append("	AND FKOUT1001 = :pkout1001                                        ");
		sql.append("	AND ACTING_DATE IS NULL                                           ");
		sql.append("	AND( IF_DATA_SEND_YN <> 'Y' OR IF_DATA_SEND_YN IS NULL)           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("pkout1001", pkout1001);
		
		List<ORDERTRANSMisaGetHangmogInfo> listResult = new JpaResultMapper().list(query, ORDERTRANSMisaGetHangmogInfo.class);
		return listResult;
	}

	@Override
	public List<Ocs1003> getByHospCodeAndFks0201(String hospCode, Double fksch0201) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT a  from Ocs1003 a , Sch0201 b  																							");
		sql.append(" WHERE a.hospCode  = :f_hosp_code and a.hospCode =  b.hospCode  AND  a.pkocs1003   =  b.fkocs AND b.pksch0201   =:f_fksch0201 ");


		Query query = entityManager.createQuery(sql.toString());

		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fksch0201", fksch0201);


		return query.getResultList();
	}

	@Override
	public List<PatientMedicineInfo> getPatientMedicine(String patientCode, String hospCode, String language) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 	A.ID                                      AS  id,											");
		sql.append("	      	DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')     AS  datetimeRecord,								");
		sql.append("	      	CAST(A.GROUP_SER AS CHAR)                 AS  prescriptionName,								");
		sql.append("	      	B.HANGMOG_NAME                            AS  medicineName,									");
		sql.append("	      	CAST(A.SURYANG AS CHAR)                   AS  dose,											");
		sql.append("	      	A.ORD_DANUI                               AS  unitCode,										");
		sql.append("	      	E.CODE_NAME                               AS  unit,											");
		sql.append("	      	CAST(A.DV AS CHAR)                        AS  frequency,									");
		sql.append("	      	CAST(A.NALSU AS CHAR)                     AS  days,											");
		sql.append("	      	C.BOGYONG_NAME                            AS  dosage,										");
		sql.append("	      	B.INPUT_CONTROL                           AS  medicineMethod,								");
		sql.append("	        D.YOYANG_NAME                             AS  hospName,										");
		sql.append("	        A.FKOUT1001                               AS  neawonKey,									");
		sql.append("	        B.HANGMOG_CODE                            AS  hangmogCode									");
		sql.append("	FROM  OCS1003 A,																					");
		sql.append("	      OCS0103 B,																					");
		sql.append("	      DRG0120 C,																					");
		sql.append("	      BAS0001 D,																					");
		sql.append("	      OCS0132 E																						");
		sql.append("	WHERE A.BUNHO = :f_patient_code																		");
		sql.append("	  AND A.HOSP_CODE = :f_hosp_code																	");
		sql.append("	  AND C.HOSP_CODE = :f_hosp_code																	");
		sql.append("	  AND A.HOSP_CODE = B.HOSP_CODE																		");
		sql.append("	  AND A.HOSP_CODE = E.HOSP_CODE																		");
		sql.append("	  AND A.HANGMOG_CODE = B.HANGMOG_CODE																");
		sql.append("	  AND B.INPUT_CONTROL IN ('1', 'C')																	");
		sql.append("	  AND B.JUNDAL_TABLE_OUT = 'DRG'																	");
		sql.append("	  AND B.JUNDAL_PART_OUT = 'PA'																		");
		sql.append("	  AND C.BOGYONG_CODE = A.BOGYONG_CODE																");
		sql.append("	  AND A.HOSP_CODE = D.HOSP_CODE																		");
		sql.append("	  AND D.START_DATE = (SELECT MAX(D1.START_DATE) FROM BAS0001 D1 WHERE D1.HOSP_CODE = :f_hosp_code)	");
		sql.append("	  AND A.ORD_DANUI = E.CODE																			");
		sql.append("	  AND E.CODE_TYPE = 'ORD_DANUI'																		");
		sql.append("	  AND E.LANGUAGE = D.LANGUAGE	AND C.LANGUAGE = :f_language										");
		sql.append("	ORDER BY A.ORDER_DATE																				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_patient_code", patientCode);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<PatientMedicineInfo> listResult = new JpaResultMapper().list(query, PatientMedicineInfo.class);
		return listResult;
	}

	@Override
	public List<NUR2016U02TranferSgCodeInfo> getNUR2016U02TranferInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HANGMOG_CODE,                 ");
		sql.append(" A.PKOCS1003,                           ");
		sql.append(" C.HANGMOG_NAME,                        ");
		sql.append(" A.SG_CODE,                             ");
		sql.append(" DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d')  ");
		sql.append(" FROM OCS1003 A, OUT1001 B, OCS0103 C   ");
		sql.append(" WHERE A.HOSP_CODE = :hosp_code         ");
		sql.append(" AND A.HOSP_CODE = B.HOSP_CODE          ");
		sql.append(" AND A.BUNHO = :bunho                   ");
		sql.append(" AND A.FKOUT1001 =  B.PKOUT1001         ");
		sql.append(" AND A.HOSP_CODE =  C.HOSP_CODE         ");
		sql.append(" AND C.HANGMOG_CODE = A.HANGMOG_CODE    ");
		sql.append(" AND A.SG_CODE = C.SG_CODE              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		
		List<NUR2016U02TranferSgCodeInfo> listResult = new JpaResultMapper().list(query, NUR2016U02TranferSgCodeInfo.class);
		return listResult;
	}
	
	@Override
	public List<NUR2016U02TranferSgCodeInfo> getNUR2016U02TranferInfoExt(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HANGMOG_CODE,                 			");
		sql.append(" A.PKOCS1003,                           			");
		sql.append(" C.HANGMOG_NAME,                        			");
		sql.append(" A.SG_CODE,                             			");
		sql.append(" DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d')  			");
		sql.append(" FROM OCS1003 A, OUT1001 B, OCS0103 C   			");
		sql.append(" WHERE A.HOSP_CODE = :hosp_code         			");
		sql.append(" AND A.HOSP_CODE = B.HOSP_CODE          			");
		sql.append(" AND A.BUNHO = :bunho                   			");
		sql.append(" AND A.FKOUT1001 =  B.PKOUT1001         			");
		sql.append(" AND A.HOSP_CODE =  C.HOSP_CODE         			");
		sql.append(" AND C.HANGMOG_CODE = A.HANGMOG_CODE   				");
		//sql.append(" AND A.SG_CODE = C.SG_CODE              			");
		sql.append(" AND IFNULL(A.SG_CODE, '') = IFNULL(C.SG_CODE, '')  ");
		sql.append(" AND IFNULL(A.IF_DATA_SEND_YN, '') <> 'Y'           ");
		sql.append(" AND B.NAEWON_YN = 'E'              				");
		sql.append(" AND A.ACTING_DATE IS NOT NULL          			");
		sql.append(" AND IFNULL(A.ORDER_STATUS, '') = ''    			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		
		List<NUR2016U02TranferSgCodeInfo> listResult = new JpaResultMapper().list(query, NUR2016U02TranferSgCodeInfo.class);
		return listResult;
	}

	@Override
	public List<OCSACT2GetGrdPaListInfo> getOCSACT2GetGrdPaListInfo(String hospCode, String language,
			String jundalTable, String gwa, Date orderDateFrom, Date orderDateTo, String bunho, String actingFlag, boolean isCPL) {
		StringBuilder sql = new StringBuilder();
		bunho = StringUtils.isEmpty(bunho) ? null : bunho;
		sql.append(" SELECT                                                                                                                                        ");
		sql.append("         IF(F.NUM_PROTOCOL IS NULL ,'-','O')                                                       TRIAL_FLG                                   ");
		sql.append("         ,FN_OUT_LOAD_SUNAME(A.BUNHO, :f_hosp_code)                                                 SUNAME                                     ");
		sql.append("         ,CASE WHEN (A.JUNDAL_TABLE = 'DRG' AND A.JUNDAL_PART = 'IR') THEN 'INJ' ELSE A.JUNDAL_TABLE END     JUNDAL_TABLE                      ");
		sql.append("         ,A.GWA                                                                                      GWA                                       ");
		sql.append("         ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)                            GWA_NAME                               ");
		sql.append("         ,A.DOCTOR                                                                                    DOCTOR                                   ");
		sql.append("         ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE, :f_hosp_code)                               DOCTOR_NAME                                ");
		sql.append("         ,FN_OUT_LOAD_SUNAME2(A.BUNHO, :f_hosp_code)                                                SUNAME2                                    ");
		sql.append("         ,A.BUNHO                                                                                       BUNHO                                  ");
		sql.append("         ,A.PKOCS1003                                                                                   PKOCS1003                              ");
		sql.append("         ,A.FKOUT1001                                                                                    FKOUT1001                             ");
		sql.append("         ,''                                                                                                RESER_GUBUN                        ");
		sql.append("         ,DATE_FORMAT(C.NAEWON_DATE, '%Y/%m/%d')                                                            ORDER_DATE                         ");
		sql.append("         ,''                                                                                                RESER_DATE                         ");
		sql.append("         ,'O'                                                                                         IN_OUT_GUBUN                             ");
		if(CommonEnum.JUNDAL_TABLE_PFE.getValue().equals(jundalTable) || CommonEnum.JUNDAL_TABLE_TST.getValue().equals(jundalTable)){
			sql.append(" ,CASE WHEN A.RESER_DATE IS NULL THEN 'N' ELSE 'Y' END RESER_YN                                                                            ");
		}else if(CommonEnum.JUNDAL_TABLE_CPL.getValue().equals(jundalTable) || isCPL){
			sql.append(" ,FN_SCH_RESER_YN1(:f_hosp_code,B.IN_OUT_GUBUN,B.FKOCS1003,B.FKOCS2003,B.RESER_DATE)   RESER_YN                                            ");
		}else{
			sql.append("         ,'N'                                                                               RESER_YN                                        ");
		}
		sql.append("         ,''                                                                                                KIJUN_DATE                         ");
		sql.append("         ,''                                                                                                NAEWON_TIME                        ");
		sql.append("         ,IFNULL(A.EMERGENCY, 'N')                                                                          EMERGENCY_YN                       ");
		sql.append("         , CASE WHEN  A.ACTING_DATE IS NULL THEN 'N' ELSE 'Y' END                                           ACTING_YN                          ");
		sql.append(" FROM  OCS1003 A LEFT JOIN                                                                                                                     ");
		sql.append("         (SELECT D.CLIS_PROTOCOL_ID NUM_PROTOCOL  , D.HOSP_CODE HOSP_CODE   , D.BUNHO BUNHO                                                    ");                                          
		sql.append("        FROM CLIS_PROTOCOL_PATIENT D LEFT JOIN CLIS_PROTOCOL E ON D.CLIS_PROTOCOL_ID = E.CLIS_PROTOCOL_ID AND D.HOSP_CODE = E.HOSP_CODE        ");                                                   
		sql.append("        WHERE D.HOSP_CODE = :f_hosp_code                                                                                                       ");                                                   
		sql.append("        AND D.ACTIVE_FLG = 1                                                                                                                   ");                                                   
		sql.append("        AND E.ACTIVE_FLG = 1                                                                                                                   ");                                                   
		sql.append("        AND E.STATUS_FLG <> 1                                                                                                                  ");                                                   
		sql.append("        AND E.END_DATE >= SYSDATE()) F ON F.HOSP_CODE = A.HOSP_CODE AND F.BUNHO = A.BUNHO                                                      ");
		sql.append(" LEFT JOIN OUT1001 C ON C.PKOUT1001 = A.FKOUT1001 AND C.BUNHO = A.BUNHO AND C.HOSP_CODE = A.HOSP_CODE                                          ");
		if(CommonEnum.JUNDAL_TABLE_CPL.getValue().equals(jundalTable) || isCPL){
			sql.append("  LEFT JOIN CPL2010 B ON A.HOSP_CODE = B.HOSP_CODE  AND  A.PKOCS1003      = B.FKOCS1003                                                    	");
			sql.append("  AND ((:f_bunho IS NULL AND STR_TO_DATE(IFNULL(DATE_FORMAT(B.RESER_DATE,'%Y/%m/%d'), DATE_FORMAT(B.ORDER_DATE,'%Y/%m/%d')), '%Y/%m/%d' )  	");
			sql.append("  between STR_TO_DATE(:f_order_date_from,'%Y/%m/%d') and STR_TO_DATE(:f_order_date_to,'%Y/%m/%d'))                                          ");
			sql.append("  OR  (:f_bunho IS NOT NULL AND B.BUNHO = :f_bunho))                                                                                        ");
			sql.append(" AND B.JUBSU_DATE IS NULL                    AND B.IN_OUT_GUBUN   = 'O' 																	"); 
		}
		
		if(StringUtils.isEmpty(gwa)){
			sql.append(" WHERE  A.HOSP_CODE = :f_hosp_code                       																					");
			sql.append("   AND (((A.ORDER_DATE BETWEEN :f_order_date_from AND :f_order_date_to) AND A.HOPE_DATE IS NULL) OR (A.HOPE_DATE IS NOT NULL AND A.HOPE_DATE BETWEEN :f_order_date_from AND :f_order_date_to))	");
			
		} else {
			sql.append(" WHERE  A.HOSP_CODE = :f_hosp_code AND A.GWA  = :f_gwa                      																");
			sql.append("   AND (((A.ORDER_DATE BETWEEN :f_order_date_from AND :f_order_date_to) AND A.HOPE_DATE IS NULL) OR (A.HOPE_DATE IS NOT NULL AND A.HOPE_DATE BETWEEN :f_order_date_from AND :f_order_date_to))	");
		}
		
		if(CommonEnum.JUNDAL_TABLE_INJ.getValue().equalsIgnoreCase(jundalTable)){
			sql.append(" AND A.JUNDAL_TABLE = 'DRG' AND A.JUNDAL_PART = 'IR'                                                                                       	");
		}else if(!CommonEnum.PERCENTAGE.getValue().equals(jundalTable)){
			sql.append(" AND A.JUNDAL_TABLE = :f_jundal_table                                                                                                       ");
		}else if(CommonEnum.PERCENTAGE.getValue().equals(jundalTable)){
			sql.append(" AND (A.JUNDAL_TABLE in ('CPL', 'PFE', 'TST') OR (A.JUNDAL_TABLE = 'DRG' AND A.JUNDAL_PART = 'IR'))                                         ");
		}
		if(!StringUtils.isEmpty(bunho)){
			sql.append("AND A.BUNHO                        = :f_bunho                                                                                              	");
		}
		if("1".equals(actingFlag)){
			sql.append(" AND A.ACTING_DATE is NULL                                                                                                                  ");
		}else if("2".equals(actingFlag)){
			sql.append(" AND A.ACTING_DATE is not NULL                                                                                                              ");
		}
		sql.append(" GROUP BY BUNHO, JUNDAL_TABLE  ORDER BY    JUNDAL_TABLE       DESC                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(!StringUtils.isEmpty(gwa)){
			query.setParameter("f_gwa", gwa);
		}
		
		query.setParameter("f_language", language);
		query.setParameter("f_order_date_from", orderDateFrom);
		query.setParameter("f_order_date_to", orderDateTo);
		if(!StringUtils.isEmpty(bunho) || CommonEnum.JUNDAL_TABLE_CPL.getValue().equals(jundalTable) || isCPL){
			query.setParameter("f_bunho", bunho);
		}
		if(!CommonEnum.PERCENTAGE.getValue().equalsIgnoreCase(jundalTable) && !CommonEnum.JUNDAL_TABLE_INJ.getValue().equalsIgnoreCase(jundalTable)){
			query.setParameter("f_jundal_table", jundalTable);
		}
		
		List<OCSACT2GetGrdPaListInfo> listResult = new JpaResultMapper().list(query, OCSACT2GetGrdPaListInfo.class);
		return listResult;
	}

	@Override
	public void callProLogicInsertOcs1003(String hospCode, Double pkocs1003) {
		LOG.info("[START] callOcsoOCS1003P01OutOrderEndTemp " + hospCode + " , " + pkocs1003);
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_LOGIC_INSERT_OCS1003");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS1003", Double.class, ParameterMode.IN);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PKOCS1003", pkocs1003);
		
		query.execute();
		LOG.info("[END] callOcsoOCS1003P01OutOrderEndTemp");
	}

	@Override
	public boolean isExistJundalTableIsCPL(String hospCode, String gwa,
			Date orderDateFrom, Date orderDateTo, String bunho, String actingFlag) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y'                                                         ");
		sql.append(" FROM OCS1003  A                                                    ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                   ");
		sql.append(" AND A.JUNDAL_TABLE = 'CPL' AND A.GWA = :f_gwa                      ");
		sql.append(" AND A.ORDER_DATE BETWEEN :f_order_date_from AND :f_order_date_to   ");
		if(!StringUtils.isEmpty(bunho)){
			sql.append("AND A.BUNHO                        = :f_bunho                   ");
		}
		if("1".equals(actingFlag)){
			sql.append(" AND A.ACTING_DATE is NULL                                      ");
		}else if("2".equals(actingFlag)){ 
			sql.append(" AND A.ACTING_DATE is not NULL                                  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_order_date_from", orderDateFrom);
		query.setParameter("f_order_date_to", orderDateTo);
		if(!StringUtils.isEmpty(bunho)){
			query.setParameter("f_bunho", bunho);
		}
		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){
			return true;
		}
		return false;
	}

	public boolean isCompleteOrder(String hospCode,double pkOCS1003)
	{
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y'                                                    		");
		sql.append(" FROM OCS1003  A                                                    ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code AND PKOCS1003 = :f_pkOCS1003        ");
		sql.append(" AND IFNULL(DC_YN,'N') = 'N' AND JUNDAL_PART NOT IN('NUT','NUE') 	");
		sql.append(" AND (JUBSU_DATE IS NOT NULL OR ACTING_DATE IS NOT NULL) 			");


		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkOCS1003", pkOCS1003);

		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results) && results.get(0).equals("Y")){
			return true;
		}
		else
		{
			return false;
		}
	}

	@Override
	public List<BIL2016U01LoadPatientInfo> getBIL2016U01LoadPatientInfo(String hospCode, String language, Date fromDate, Date toDate, String bunho, String suname, String billNumber) {
		StringBuilder sql = new StringBuilder();
//		sql.append("  SELECT    cast(null as datetime),                                                         ");
//		sql.append("  	   '',                                                                                  ");
//		sql.append("  	   B.BUNHO,                                                                             ");
//		sql.append("  	   B.SUNAME,                                                                            ");
//		sql.append("  	   CONCAT(IFNULL(B.ADDRESS1,''),IFNULL(B.ADDRESS2,'')) ADDRESS,                         ");
//		sql.append("  	   B.SEX,                                                                               ");
//		sql.append("  	   E.NAEWON_DATE,                                                                       ");
//		sql.append("  	   F.CODE,                                                                              ");
//		sql.append("  	   F.CODE_NAME,                                                                         ");
//		sql.append("  	   B.BIRTH,                                                                             ");
//		sql.append("       A.FKOUT1001,                                                                         ");
//		sql.append("	   B.TEL,																				");
//		sql.append("	   ' '	paid_name	,																	");
//		sql.append("	   '1'	type_money		,																");
//		sql.append("	   cast('' as decimal)	sum_amount	,													");
//		sql.append("	   cast('' as decimal)	sum_discount	,												");
//		sql.append("	   cast('' as decimal)	sum_paid		,												");
//		sql.append("	   cast('' as decimal)	sum_debt		,												");
//		sql.append("	   	' '         PARENT_INVOICE_NO		,												");
//		sql.append("	   	cast('' as decimal)         status_flg							        			");
//		sql.append("  FROM OCS1003 A ,                                                                          ");
//		sql.append("       OUT0101 B LEFT JOIN BAS0102 F ON B.HOSP_CODE = F.HOSP_CODE                           ");
//		sql.append("   AND F.CODE_TYPE = 'BILLING_TYPE' AND F.LANGUAGE = :language AND F.CODE = B.BILLING_TYPE  ");
//		sql.append("  ,  OUT1001 E                                         						                ");
//		sql.append("  WHERE E.BUNHO = B.BUNHO                                                                   ");
//		sql.append("  AND E.BUNHO =  A.BUNHO                                                                    ");
//		sql.append("  AND A.HOSP_CODE = :hosp_code                                                              ");
//		sql.append("  AND A.HOSP_CODE = B.HOSP_CODE                                                             ");
////		sql.append("  AND A.HOSP_CODE = C.HOSP_CODE                                                             ");
////		sql.append("  AND A.HOSP_CODE = D.HOSP_CODE                                                             ");
////		sql.append("  AND D.DOCTOR    = E.DOCTOR                                                                ");
//		sql.append("  AND A.HOSP_CODE = E.HOSP_CODE                                                             ");
//		sql.append("  AND A.FKOUT1001 = E.PKOUT1001                                                             ");
//		sql.append("  AND E.NAEWON_DATE >= :from_date    AND E.NAEWON_DATE <= :to_date                          ");
////		sql.append("  AND C.LANGUAGE = :language                                                                ");
////		sql.append(" AND C.GWA = E.GWA                                                                          ");
//		sql.append(" AND IFNULL(A.PAID_YN,'N') = 'N'                                                            ");
//		if(!StringUtils.isEmpty(bunho)){
//			sql.append(" AND E.BUNHO = :bunho                                                                   ");
//		}
//		if(!StringUtils.isEmpty(suname)){
//			sql.append(" AND B.SUNAME LIKE :suname                                                              ");
//		}
//		sql.append("  GROUP BY A.FKOUT1001	UNION																	");		
		sql.append("  SELECT    cast(null as datetime),                               		                         ");
		sql.append(" 	   ' ',                                                                                      ");
		sql.append(" 	   B.BUNHO,                                                                                 ");
		sql.append(" 	   B.SUNAME,                                                                                ");
		sql.append(" 	   CONCAT(IFNULL(B.ADDRESS1,''),IFNULL(B.ADDRESS2,'')) ADDRESS,                             ");
		sql.append(" 	   B.SEX,                                                                                   ");
		sql.append(" 	   E.NAEWON_DATE,                                                                           ");
		sql.append(" 	   F.CODE,                                                                                  ");
		sql.append(" 	   F.CODE_NAME,                                                                             ");
		sql.append(" 	   B.BIRTH,                                                                                 ");
		sql.append("     E.PKOUT1001,                                                                               ");
		sql.append("   B.TEL,																				        ");
		sql.append("   ' '	paid_name	,																	        ");
		sql.append("   ' '	type_money		,																        ");
		sql.append("   cast('' as decimal)	sum_amount	,													        ");
		sql.append("   cast('' as decimal)	sum_discount	,												        ");
		sql.append("   cast('' as decimal)	sum_paid		,												        ");
		sql.append("   cast('' as decimal)	sum_debt		,												        ");
		sql.append("   	' '         PARENT_INVOICE_NO		,												        ");
		sql.append("	cast('' as decimal)         status_flg						    	            			");
		sql.append("    FROM OUT1001 E INNER JOIN OUT0101 B ON E.HOSP_CODE = B.HOSP_CODE 	AND E.BUNHO = B.BUNHO   ");
		if(!StringUtils.isEmpty(suname)){
			sql.append("  AND B.SUNAME like :suname                                                                 ");
		}
		sql.append("    LEFT JOIN BAS0102 F ON B.HOSP_CODE = F.HOSP_CODE                                            ");
		sql.append("       AND F.CODE_TYPE = 'BILLING_TYPE' AND F.LANGUAGE = :language AND F.CODE = B.BILLING_TYPE  ");
		sql.append("    LEFT JOIN OCS1003 C ON C.HOSP_CODE = E.HOSP_CODE AND C.FKOUT1001 = E.PKOUT1001              ");
		sql.append("   WHERE E.HOSP_CODE = :hosp_code                                                               ");
		sql.append("  AND E.NAEWON_DATE >= :from_date    AND E.NAEWON_DATE <= :to_date                     	        ");
		sql.append(" AND (IFNULL(E.PAID_YN,'N') = 'N' OR (C.PKOCS1003 IS NOT NULL AND IFNULL(C.PAID_YN,'N') = 'N')) ");
		if(!StringUtils.isEmpty(bunho)){
			sql.append(" AND E.BUNHO = :bunho                                                                       ");
		}
		sql.append("  GROUP BY E.PKOUT1001	    																	");	
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("from_date", fromDate);
		query.setParameter("to_date", toDate);
		
		if(!StringUtils.isEmpty(bunho)){
			query.setParameter("bunho", bunho);
		}
		
		if(!StringUtils.isEmpty(suname)){
			query.setParameter("suname", "%" + suname + "%");
		}
		
		List<BIL2016U01LoadPatientInfo> listResult = new JpaResultMapper().list(query, BIL2016U01LoadPatientInfo.class);
		return listResult;
	}
	
	@Override
	public String getRemarkOcs1003(String hospCode, Double pkocs1003, Double pkout1001, String language){
		StringBuilder sql = new StringBuilder();
		if(pkout1001 != null  && pkout1001 > 0){
			sql.append("	SELECT CONCAT(A.PKOUT1001, ' - ', IFNULL(B.SUNAME, ''), ' (', A.BUNHO, ')', ' - ', IF(A.NAEWON_DATE IS NULL, '', DATE_FORMAT(A.NAEWON_DATE,'%Y/%m/%d')), ' - ', IFNULL(C.GWA_NAME, ''), ' (', IFNULL(A.GWA, ''), ')', ' - ', IFNULL(D.DOCTOR_NAME, ''), ' (', A.DOCTOR, ')')	");
			sql.append("	FROM OUT1001 A																																																																	");
			sql.append("	LEFT JOIN OUT0101 B ON A.HOSP_CODE = B.HOSP_CODE																																																								");
			sql.append("	                   AND A.BUNHO = B.BUNHO																																																										");
			sql.append("	LEFT JOIN BAS0260 C ON A.HOSP_CODE = C.HOSP_CODE																																																								");
			sql.append("	                   AND A.GWA = C.GWA																																																											");
			sql.append("	                   AND C.LANGUAGE = :f_language																																																									");
			sql.append("	LEFT JOIN BAS0270 D ON A.HOSP_CODE = D.HOSP_CODE																																																								");
			sql.append("	                   AND A.DOCTOR = D.DOCTOR																																																										");
			sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																																																												");
			sql.append("  	  AND A.PKOUT1001 = :f_pkout1001																																																												");
		} else {
			sql.append("	SELECT CONCAT(A.PKOUT1001, ' - ', IFNULL(C.SUNAME, ''), ' (', A.BUNHO, ')', ' - ', IF(A.NAEWON_DATE IS NULL, '', DATE_FORMAT(A.NAEWON_DATE,'%Y/%m/%d')), ' - ', IFNULL(D.GWA_NAME, ''), ' (', IFNULL(A.GWA, ''), ')', ' - ', IFNULL(E.DOCTOR_NAME, ''), ' (', A.DOCTOR, ')')	");
			sql.append("	FROM OUT1001 A																																																																	");
			sql.append("	JOIN OCS1003 B ON A.HOSP_CODE = B.HOSP_CODE																																																										");
			sql.append("              	  AND A.PKOUT1001 = B.FKOUT1001																																																										");
			sql.append("	LEFT JOIN OUT0101 C ON A.HOSP_CODE = C.HOSP_CODE																																																								");
			sql.append("	                   AND A.BUNHO = C.BUNHO																																																										");
			sql.append("	LEFT JOIN BAS0260 D ON A.HOSP_CODE = D.HOSP_CODE																																																								");
			sql.append("	                   AND A.GWA = D.GWA																																																											");
			sql.append("	                   AND D.LANGUAGE = :f_language																																																									");
			sql.append("	LEFT JOIN BAS0270 E ON A.HOSP_CODE = E.HOSP_CODE																																																								");
			sql.append("	                   AND A.DOCTOR = E.DOCTOR																																																										");
			sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																																																												");
			sql.append("  	  AND B.PKOCS1003 = :f_pkocs1003																																																												");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		if(pkout1001 != null  && pkout1001 > 0){
			query.setParameter("f_pkout1001", pkout1001);
		} else {
			query.setParameter("f_pkocs1003", pkocs1003);
		}
		
		List<String> listResult = query.getResultList();
		return CollectionUtils.isEmpty(listResult) ? "" : listResult.get(0);
	}

	@Override
	public List<MedicalInfoExt> getMedicalInfo(String hospCode, String bunho, Double pkout1001, List<String> listHangmocCode, boolean isTransfered) {
		StringBuilder sql = new StringBuilder();
		sql.append(" 	SELECT IFNULL(T.CLASS_CODE, '999')                         						AS MedicalClass																			");
		sql.append("		, FN_DRG_WONYOI_TOT_SURYANG(T.NALSU, T.SURYANG, T.DV, T.DV_TIME)/T.SURYANG 	AS MedicalClassNumber																	");		
		sql.append("   		, T.SURYANG                       											AS MedicationNumber																		");
		sql.append("        , T.IF_CODE                          										AS MedicationCode																		");
		sql.append(" 	FROM																																									");
		sql.append(" 	(																																										");
		sql.append(" 		SELECT  FN_BAS_LOAD_NU_CODE(A.HOSP_CODE, '100', A.ACTING_DATE, SUBSTRING(A.ORDER_GUBUN, -1), 																		");
		sql.append("                                 C.BUN_CODE, 'N', 'N', '00','%', IFNULL(C.TAX_YN, 'N'),IF(A.WONYOI_ORDER_YN = '', '%', A.WONYOI_ORDER_YN), '%')   AS CLASS_CODE				");
		sql.append("           , IFNULL(CAST(A.SURYANG AS CHAR), '')	AS SURYANG																												");
		sql.append("           , X.IF_CODE																																						");
		sql.append("           , A.NALSU																																						");
		sql.append("           , A.DV																																							");
		sql.append("           , A.DV_TIME																																						");
		sql.append(" 		FROM OCS1003 A																																						");
		sql.append(" 		LEFT OUTER JOIN IFS0003 X ON A.HANGMOG_CODE = X.OCS_CODE																											");
		sql.append(" 								 AND X.MAP_GUBUN = 'IF_ORCA_HANGMOG'																										");
		sql.append(" 								 AND X.HOSP_CODE = :f_hosp_code																												");
		sql.append(" 		LEFT OUTER JOIN BAS0310 C ON A.HOSP_CODE = C.HOSP_CODE																												");
		sql.append(" 								 AND A.SG_CODE = C.SG_CODE																													");
		sql.append(" 								 AND C.SG_YMD = (SELECT MAX(Z.SG_YMD)																										");
		sql.append(" 												 FROM BAS0310 Z																												");
		sql.append(" 												 WHERE Z.HOSP_CODE = A.HOSP_CODE																							");
		sql.append(" 												   AND Z.SG_CODE = A.SG_CODE																								");
		sql.append(" 												   AND Z.SG_YMD <= A.ACTING_DATE																							");
		sql.append(" 												   AND IFNULL(Z.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) > A.ACTING_DATE)											");
		sql.append(" 		WHERE A.BUNHO = :f_bunho																																			");
		sql.append(" 		  AND A.HOSP_CODE = :f_hosp_code 																																	");
		sql.append(" 		  AND A.FKOUT1001 = :f_pkout_1001																																	");
		if(isTransfered){
			sql.append(" 		AND A.HANGMOG_CODE NOT IN :listHangmocCode																														");
			sql.append(" 		AND A.ORDER_STATUS = '20'																																		");
		} else {
			sql.append(" 		AND A.HANGMOG_CODE IN :listHangmocCode																															");
		}
		sql.append(" 		  ORDER BY CLASS_CODE																																				");
		sql.append(" 	) T																																										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkout_1001", pkout1001);
		query.setParameter("listHangmocCode", listHangmocCode);
		
		List<MedicalInfoExt> listResult = new JpaResultMapper().list(query, MedicalInfoExt.class);
		return listResult;
	}
	
	@Override                                                                          
	public boolean isExistedOCS1003(String hospCode, Double pkocs1003) {  
		StringBuilder sql = new StringBuilder();                                       
		                                                                               
		sql.append("	SELECT 'Y'  									");            
		sql.append("	FROM OCS1003 A                         	 	    ");            
		sql.append("	WHERE A.HOSP_CODE     = :f_hosp_code   		    ");            
		sql.append("	AND A.PKOCS1003       = :f_pkocs1003            ");            
		                                                                               
		Query query= entityManager.createNativeQuery(sql.toString());                  
		query.setParameter("f_hosp_code", hospCode); 
		query.setParameter("f_pkocs1003", pkocs1003);
		                                                                               
		List<String> result = query.getResultList();                                   
		if(!CollectionUtils.isEmpty(result)){                                          
			return true;                                                               
		}                                                                              
		return false;  
	}
	
	@Override
	public List<GwaListItemInfo> getMedicineInfo(String hospCode, String bunho, Date orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT B.HANGMOG_NAME						");
		sql.append("      ,C.BOGYONG_NAME						");
		sql.append("    FROM OCS1003 A,							");
		sql.append("         OCS0103 B,							");
		sql.append("         DRG0120 C							");
		sql.append("    WHERE A.HOSP_CODE    = :f_hosp_code		");
		sql.append("      AND A.HOSP_CODE    = B.HOSP_CODE		");
		sql.append("      AND A.HOSP_CODE    = C.HOSP_CODE		");
		sql.append("      AND A.HANGMOG_CODE = B.HANGMOG_CODE	");
		sql.append("      AND A.BOGYONG_CODE = C.BOGYONG_CODE	");
		sql.append("      AND A.BUNHO        = :f_bunho			");
		sql.append("      AND A.ORDER_DATE   = :f_order_date	");
		sql.append("      AND A.JUNDAL_TABLE = 'DRG'			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		
		List<GwaListItemInfo> listResult = new JpaResultMapper().list(query, GwaListItemInfo.class);
		return listResult;
	}

	@Override
	public Integer getOrderCount(Double pkout1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT COUNT(*)   						");
		sql.append(" 	  FROM OCS1003 						");
		sql.append(" 	  WHERE FKOUT1001 = :f_pkout1001 	");
//		sql.append(" 	    AND BUNHO     = :f_bunho 		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_pkout1001", pkout1001);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) !=null){
			return CommonUtils.parseInteger(result.get(0).toString());
		}
		return null;
	}
	
	@Override
	public List<OCS2015U00GetOrderReportInfo> getOCS2015U00OrderReportInfo(String hospCode, String language, String bunho) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT A.HANGMOG_CODE  ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("        FN_DRG_HANGMOG_NAME(:hosp_code, A.HANGMOG_CODE)  ,  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("        A.SURYANG       ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("        A.DV            ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("        A.NALSU         ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("        B.BOGYONG_NAME  ,                                   ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("        C.CODE_NAME     ,                                    ");
		sql.append("        FN_DRG_WONYOI_TOT_SURYANG(A.NALSU, A.SURYANG, A.DV, A.DV_TIME)   ");
		sql.append("    FROM  OCS1003                        A,                 ");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("          DRG0120                        B,                 ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("          OCS0132                        C                  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    WHERE  A.ORD_DANUI         =         C.CODE             ");                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("   AND A.HOSP_CODE                =         C.HOSP_CODE     ");
		sql.append("   AND :hosp_code                =         C.HOSP_CODE     ");
		sql.append("   AND C.LANGUAGE                 =         :language       ");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("   AND C.CODE_TYPE                =         'ORD_DANUI'     ");                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("   AND A.BOGYONG_CODE             =         B.BOGYONG_CODE  ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("   AND A.BUNHO                    =         :bunho          ");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("   AND A.HOSP_CODE                =         :hosp_code      ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("   AND A.JUNDAL_TABLE             =         'DRG'  			");
		sql.append("   AND B.LANGUAGE                 =         :language  		");
		sql.append("   AND B.HOSP_CODE                =         :hosp_code  	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		List<OCS2015U00GetOrderReportInfo> list = new JpaResultMapper().list(query, OCS2015U00GetOrderReportInfo.class);
		return list;
	}

	@Override
	public List<CPL2010R02grdcpllistInfo> getCPL2010R02grdcpllistInfo(String hospCode, String language,
			String inOutGubun, String bunho, String orderDate, String gwa, String doctor, String specimenCode,
			String reOutput, String fkinp1001) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT  C.BUNHO                                     BUNHO											");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("       , C.SUNAME                                    SUNAME											");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("       , C.SUNAME2                                   SUNAME2                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("       , ''                                          HO_DONG                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("       , ''                                          HO_CODE                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("       , C.BIRTH                                     BIRTH											");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , FN_BAS_TO_JAPAN_DATE_CONVERT('1', C.BIRTH, :f_hosp_code, :f_language)  BIRTH_JAPAN			");
		sql.append("       , C.SEX                                       SEX			                                ");
		sql.append("       , FN_BAS_LOAD_AGE(SYSDATE(), C.BIRTH, NULL)     AGE			                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("       , A.ORDER_DATE                                ORDER_DATE		                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language)   GWA_NAME			");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , FN_OCS_LOAD_ORDER_DOCTOR_NAME(:f_hosp_code, A.PKOCS1003)  DOCTOR_NAME						");                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("       , CONCAT('9', A.PKOCS1003)                    PKOCS											");
		sql.append("       , FN_NUR_LOAD_WEIGHT_HEIGHT('W', C.BUNHO, :f_hosp_code)     WEIGHT	                        ");
		sql.append("       , FN_NUR_LOAD_WEIGHT_HEIGHT('H', C.BUNHO, :f_hosp_code)     HEIGHT	                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("       , A.ACTING_DATE                               ACTING_DATE			                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("       , A.HANGMOG_CODE                              HANGMOG_CODE			                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , B.HANGMOG_NAME                              HANGMOG_NAME			                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("       , FN_CPL_LOAD_CODE_NAME('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language) SPECIMEN_NAME		");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , CASE WHEN A.HANGMOG_CODE 																	");
		sql.append("         IN ('00301','00321','00351','00302','00353') 												");
		sql.append("         THEN 'Y' ELSE 'N' END                       NYO_YN											");
		sql.append("       , IF(A.EMERGENCY = 'Y','◎','')             EMERGENCY											");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("       , IFNULL(A.HOPE_DATE, A.ORDER_DATE)              HOPE_DATE									");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("   FROM  OCS1003 A                                                                                  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("       , OCS0103 B                                                                                  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("       , OUT0101 C                                                                                  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("  WHERE  A.HOSP_CODE     = :f_hosp_code                                                             ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  'O'             = :f_in_out_gubun	                                                        ");
		sql.append("    AND  A.BUNHO         = :f_bunho			                                                        ");
		sql.append("    AND  A.DC_YN         = 'N'				                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("    AND  A.NALSU         > 0				                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  A.ORDER_DATE    = :f_order_date	                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  A.HOSP_CODE     = B.HOSP_CODE		                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("    AND  A.HANGMOG_CODE  = B.HANGMOG_CODE	                                                        ");
		sql.append("    AND  A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE	                                        ");
		sql.append("    AND  A.BUNHO         = C.BUNHO							                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("    AND  A.GWA           = :f_gwa							                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("    AND  A.DOCTOR        = :f_doctor						                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  A.SPECIMEN_CODE =:f_specimen_code					                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("    AND  A.SLIP_CODE IN ( 'B000' )							                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  ((:f_re_output = 'N' AND A.JUBSU_DATE IS NULL) OR	                                        ");
		sql.append("         (:f_re_output = 'Y'))								                                        ");
		sql.append(" UNION														                                        ");
		sql.append(" SELECT  C.BUNHO                                           BUNHO	                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("       , C.SUNAME                                          SUNAME	                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("       , C.SUNAME2                                         SUNAME2	                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("       , ''                                                HO_DONG	                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("       , ''                                                HO_CODE	                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("       , C.BIRTH                                           BIRTH	                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , FN_BAS_TO_JAPAN_DATE_CONVERT('1', C.BIRTH, :f_hosp_code, :f_language)        BIRTH_JAPAN	");
		sql.append("       , C.SEX                                             SEX			                            ");
		sql.append("       , FN_BAS_LOAD_AGE(SYSDATE(), C.BIRTH, NULL)           AGE		                            ");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("       , A.ORDER_DATE                                      ORDER_DATE	                            ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , FN_BAS_LOAD_GWA_NAME(A.INPUT_GWA, A.ORDER_DATE, :f_hosp_code, :f_language)   GWA_NAME		");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , FN_OCS_LOAD_ORDER_DOCTOR_NAME(:f_hosp_code, A.PKOCS2003)        DOCTOR_NAME				");                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("       , CONCAT('9', A.PKOCS2003)                                PKOCS				                ");
		sql.append("       , FN_NUR_LOAD_WEIGHT_HEIGHT('W', C.BUNHO, :f_hosp_code)           WEIGHT	                    ");
		sql.append("       , FN_NUR_LOAD_WEIGHT_HEIGHT('H', C.BUNHO, :f_hosp_code)           HEIGHT	                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("       , A.ACTING_DATE                                     ACTING_DATE			                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("       , A.HANGMOG_CODE                                    HANGMOG_CODE			                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , B.HANGMOG_NAME                                    HANGMOG_NAME			                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("       , FN_CPL_LOAD_CODE_NAME('04',A.SPECIMEN_CODE, :f_hosp_code, :f_language)       SPECIMEN_NAME	");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("       , CASE WHEN A.HANGMOG_CODE 																	");
		sql.append("         IN ('00301','00302','00353')																");
		sql.append("         THEN 'Y' ELSE 'N' END                             NYO_YN									");
		sql.append("       , IF(A.EMERGENCY = 'Y','◎','')                   EMERGENCY									");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("       , IFNULL(A.HOPE_DATE, A.ORDER_DATE)                    HOPE_DATE								");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("   FROM  OCS2003 A                                                                                  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("       , OCS0103 B                                                                                  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("       , OUT0101 C                                                                                  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("  WHERE  A.HOSP_CODE          = :f_hosp_code                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  'I'                  = :f_in_out_gubun	                                                    ");
		sql.append("    AND  A.BUNHO              = :f_bunho		                                                    ");
		sql.append("    AND  A.ORDER_DATE         = :f_order_date	                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("    AND  A.FKINP1001          = :f_fkinp1001	                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  A.DC_YN              = 'N'				                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  A.NALSU              > 0				                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("    AND  A.HOSP_CODE          = B.HOSP_CODE		                                                    ");
		sql.append("    AND  A.HANGMOG_CODE       = B.HANGMOG_CODE	                                                    ");
		sql.append("    AND  A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE											");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("    AND  A.BUNHO              = C.BUNHO																");                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("    AND  A.INPUT_GWA          = :f_gwa																");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  A.DOCTOR             = :f_doctor															");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("    AND  A.SPECIMEN_CODE      =:f_specimen_code														");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND  A.SLIP_CODE IN ( 'B000' )																	");
		sql.append("    AND  ((:f_re_output = 'N' AND A.JUBSU_DATE IS NULL) OR											");
		sql.append("         (:f_re_output = 'Y'))																		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_in_out_gubun", inOutGubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_specimen_code", specimenCode);
		query.setParameter("f_re_output", reOutput);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		List<CPL2010R02grdcpllistInfo> list = new JpaResultMapper().list(query, CPL2010R02grdcpllistInfo.class);
		return list;
	}

	@Override
	public List<CPL2010R02grdOrderListInfo> getCPL2010R02grdOrderListInfo(String hospCode, String language,
			String bunho, String orderDate, String reOutput) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT A.HOSP_CODE			                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("      , 'O'					                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("      , A.BUNHO				                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("      , A.PKOCS1003     	                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("      , A.ORDER_DATE		                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("      , A.HANGMOG_CODE		                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("      , B.HANGMOG_NAME		                                                                    ");
		sql.append("      , A.JUNDAL_PART		                                                                    ");
		sql.append("      , A.SLIP_CODE			                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("      , A.FKOUT1001			                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("      , A.SPECIMEN_CODE		                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("      , A.GWA				                                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("      , A.DOCTOR			                                                                    ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE,:f_hosp_code,:f_language)      GWA_NAME		");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,A.ORDER_DATE,:f_hosp_code) DOCTOR_NAME					");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("   FROM OCS0103 B					                                                            ");                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("      , OCS1003 A					                                                            ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code	                                                            ");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("    AND A.HOSP_CODE = B.HOSP_CODE	                                                            ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND A.BUNHO = :f_bunho			                                                            ");
		sql.append("    AND A.ORDER_DATE = :f_order_date                                                            ");
		sql.append("    AND A.JUNDAL_TABLE = 'CPL'		                                                            ");
		sql.append("    AND A.SLIP_CODE IN ( 'B000' )	                                                            ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("    AND A.DC_YN = 'N'				                                                            ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("    AND A.NALSU > 0					                                                            ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("    AND A.HANGMOG_CODE = B.HANGMOG_CODE															");                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("    AND B.START_DATE   = ( SELECT MAX(X.START_DATE)												");                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("                             FROM OCS0103 X														");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("                            WHERE X.HOSP_CODE    = B.HOSP_CODE									");
		sql.append("                              AND X.HANGMOG_CODE = B.HANGMOG_CODE 								");
		sql.append("                              AND X.START_DATE  <= A.ORDER_DATE   )								");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("    AND ((:f_re_output = 'N' AND A.JUBSU_DATE IS NULL) OR										");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("        (:f_re_output = 'Y'))																	");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append(" 																								");                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("  UNION ALL																						");
		sql.append(" SELECT A.HOSP_CODE																				");
		sql.append("      , 'I'				                                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("      , A.BUNHO			                                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("      , A.PKOCS2003                                                                             ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("      , A.ORDER_DATE	                                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("      , A.HANGMOG_CODE	                                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("      , B.HANGMOG_NAME	                                                                        ");
		sql.append("      , A.JUNDAL_PART	                                                                        ");
		sql.append("      , A.SLIP_CODE		                                                                        ");
		sql.append("      , A.FKINP1001		                                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("      , A.SPECIMEN_CODE	                                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("      , A.INPUT_GWA		                                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("      , A.DOCTOR		                                                                        ");                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.INPUT_GWA, A.ORDER_DATE,:f_hosp_code,:f_language)      GWA_NAME	");                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,A.ORDER_DATE,:f_hosp_code) DOCTOR_NAME					");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("   FROM OCS0103 B																				");
		sql.append("      , OCS2003 A																				");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code																");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("    AND A.HOSP_CODE = B.HOSP_CODE																");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND A.BUNHO = :f_bunho																		");                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND A.ORDER_DATE = :f_order_date															");                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("    AND A.JUNDAL_TABLE = 'CPL'																	");
		sql.append("    AND A.SLIP_CODE IN ( 'B000' )																");
		sql.append("    AND A.DC_YN = 'N'																			");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("    AND A.NALSU > 0																				");                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("    AND A.HANGMOG_CODE = B.HANGMOG_CODE															");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("    AND B.START_DATE   = ( SELECT MAX(X.START_DATE)												");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("                             FROM OCS0103 X														");                                                                                                                                                                                                                                                                                                                                                                                                                                            
		sql.append("                            WHERE X.HOSP_CODE    = B.HOSP_CODE									");
		sql.append("                              AND X.HANGMOG_CODE = B.HANGMOG_CODE 								");
		sql.append("                              AND X.START_DATE  <= A.ORDER_DATE   )								");
		sql.append("    AND ((:f_re_output = 'N' AND A.JUBSU_DATE IS NULL) OR										");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("         (:f_re_output = 'Y'))																	");                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append(" ORDER BY 4																						");       

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_re_output", reOutput);
		List<CPL2010R02grdOrderListInfo> list = new JpaResultMapper().list(query, CPL2010R02grdOrderListInfo.class);
		return list;
	}

	@Override
	public Integer callFnOcsGetBeforeApporder(String hospCode, String ioGubun, String insteadYn, String approveYn,
			String doctorId, String key) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OCS_GET_BEFORE_APPORDER(:f_hosp_code, :f_io_gubun, :f_instead_yn, :f_approve_yn, :f_doctor_id, :f_key)  "); 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_instead_yn", insteadYn);
		query.setParameter("f_approve_yn", approveYn);
		query.setParameter("f_doctor_id", doctorId);
		query.setParameter("f_key", key);
		List<Integer> result = query.getResultList();
		if(!result.isEmpty() && result.get(0) != null){
			 return result.get(0);
		}
		return null;
	}
}

