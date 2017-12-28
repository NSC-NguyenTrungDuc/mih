package nta.med.data.dao.medi.bas.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0001RepositoryCustom;
import nta.med.data.dao.medi.out.impl.Out1001RepositoryImpl;
import nta.med.data.model.ihis.adma.ADMS2015U00GetHospitalInfo;
import nta.med.data.model.ihis.bass.BAS0001U00GrdBAS0001Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.NUR2016Q00GrdHospListInfo;
import nta.med.data.model.ihis.nuro.OUT1001R01GrdListInfo;
import nta.med.data.model.ihis.nuro.RES1001R00ClinicInfo;
import nta.med.data.model.ihis.nuro.RES1001R00ClinicNameInfo;
import nta.med.data.model.ihis.nuro.RES1001U00FbxHospCodeLinkListItemInfo;
import nta.med.data.model.ihis.ocsa.DOC4003U00GetHospInfo;
import nta.med.data.model.ihis.ocso.OCS1003R02DTHospListItemInfo;
import nta.med.data.model.ihis.orca.ORCALibGetDocInfo;
import nta.med.data.model.ihis.orca.ORCATransferOrdersHeaderInfo;
import nta.med.data.model.ihis.orca.ORCATransferOrdersHealthInsuranceInfo;
import nta.med.data.model.ihis.phys.Phy8002U01BtnPrintGetDataWindowInfo;

/**
 * @author dainguyen.
 */
public class Bas0001RepositoryImpl implements Bas0001RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Out1001RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<String> getNuroInspectionOrderGetTel(String hospitalCode, String reserDate) {
		LOG.info("updatePatientInfo: hospitalCode=" + hospitalCode + ", reserDate=" + reserDate);
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT TEL                                                                   ");
		sql.append("  FROM BAS0001                                                               ");
		sql.append(" WHERE HOSP_CODE = :hospitalCode                                             ");
		sql.append("   AND STR_TO_DATE(:reserDate, '%Y/%m/%d') BETWEEN START_DATE AND END_DATE;  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("reserDate", reserDate);
		List<String> list  = query.getResultList();

		return list;
	}
	
	@Override
	public List<BAS0001U00GrdBAS0001Info> getBAS0001U00GrdBAS0001Info(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.START_DATE                                                                            ");
		sql.append("     , A.END_DATE                                                                              ");
		sql.append("     , A.YOYANG_GIHO                                                                           ");
		sql.append("     , A.YOYANG_NAME                                                                           ");
		sql.append("     , A.YOYANG_NAME2                                                                          ");
		sql.append("     , A.ZIP_CODE1                                                                             ");
		sql.append("     , A.ZIP_CODE2                                                                             ");
		sql.append("     , A.ZIP_CODE                                                                              ");
		sql.append("     , A.ADDRESS                                                                               ");
		sql.append("     , A.ADDRESS1                                                                              ");
		sql.append("     , A.TEL                                                                                   ");
		sql.append("     , A.TEL1                                                                                  ");
		sql.append("     , A.FAX                                                                                   ");
		sql.append("     , A.TOT_BED                                                                               ");
		sql.append("     , A.HOMEPAGE                                                                              ");
		sql.append("     , A.EMAIL                                                                                 ");
		sql.append("     , A.HOSP_JIN_GUBUN                                                                        ");
		sql.append("     , A.DODOBUHYEUN_NO                                                                        ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('DODOBUHYEUN_NO', A.DODOBUHYEUN_NO,:f_hosp_code,:f_language)      ");
		sql.append("     , A.JAEDAN_NAME                                                                           ");
		sql.append("     , A.SIMPLE_YOYANG_NAME                                                                    ");
		sql.append("     , A.BANK_NAME                                                                             ");
		sql.append("     , A.BANK_JIJUM                                                                            ");
		sql.append("     , A.BANK_NO                                                                               ");
		sql.append("     , A.BANK_ACC_NAME                                                                         ");
		sql.append("     , A.PRESIDENT_NAME                                                                        ");
		sql.append("     , A.ORCA_GIGWAN_CODE                                                                      ");
		sql.append("     , A.ACCT_REF_ID                                                                     	   ");
		sql.append("     , A.VPN_YN                                                                     	       ");
		sql.append("     , A.TIME_ZONE                                                                     	       ");
		sql.append("  FROM BAS0001 A                                                                               ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                              ");
		sql.append(" ORDER BY CONCAT(DATE_FORMAT(A.START_DATE, '%Y%m%d') , A.YOYANG_GIHO) DESC                     ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<BAS0001U00GrdBAS0001Info> list = new JpaResultMapper().list(query, BAS0001U00GrdBAS0001Info.class);
		return list;
	}
	
	public String getYoyangNameInfo (String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT YOYANG_NAME FROM BAS0001 WHERE HOSP_CODE = :f_hosp_code AND LANGUAGE = :language ORDER BY SYS_DATE DESC LIMIT 1");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		
		@SuppressWarnings("unchecked")
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<Phy8002U01BtnPrintGetDataWindowInfo> getPhy8002U01BtnPrintGetDataWindowListItem(
			String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.YOYANG_NAME									");
		sql.append("	     ,A.SIMPLE_YOYANG_NAME                              ");
		sql.append("	     ,A.TEL                                             ");
		sql.append("	     ,A.HOMEPAGE                                        ");
		sql.append("	 FROM BAS0001 A                                         ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                        ");
		sql.append("	  AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
				List<Phy8002U01BtnPrintGetDataWindowInfo> list = new JpaResultMapper().list(query, Phy8002U01BtnPrintGetDataWindowInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getAdm103UHospitalInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT HOSP_CODE, IFNULL(YOYANG_NAME,YOYANG_NAME2)	                                       ");
		sql.append("	FROM BAS0001  A                                                                            ");
		sql.append("	WHERE START_DATE = (SELECT MAX(START_DATE)    FROM BAS0001  WHERE HOSP_CODE = A.HOSP_CODE) ");
		sql.append(" AND HOSP_CODE LIKE :hospCode                                                                  ");
		if(!StringUtils.isEmpty(language)){
			sql.append("	AND LANGUAGE = :language                                                                   ");
		}
		sql.append(" ORDER BY HOSP_CODE ASC                                                                        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		if(!StringUtils.isEmpty(language)){
			query.setParameter("language", language);
		}
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getBas0001YoYangName(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(YOYANG_NAME, YOYANG_NAME2) YOYANG_NAME FROM BAS0001     " );
		sql.append(" WHERE   HOSP_CODE = :f_hosp_code                                      " );
		if(!StringUtils.isEmpty(language)){
			sql.append("	AND LANGUAGE = :f_language                                       ");
		}
		sql.append(" ORDER BY START_DATE DESC LIMIT 1										");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(!StringUtils.isEmpty(language)){
			query.setParameter("f_language", language);
		}
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public List<ComboListItemInfo> loadHospitalList(String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT HOSP_CODE                                    ");
		sql.append("     , YOYANG_NAME                                  ");
		sql.append("  FROM BAS0001 A                                    ");
		sql.append(" WHERE START_DATE = (SELECT MAX(START_DATE)         ");
		sql.append("                     FROM BAS0001                   ");
		sql.append("                    WHERE HOSP_CODE = A.HOSP_CODE)  ");
		sql.append("	AND LANGUAGE = :language                         ");
		sql.append(" GROUP BY HOSP_CODE ,YOYANG_NAME                     ");
		sql.append(" ORDER BY HOSP_CODE ASC                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getHospital(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT HOSP_CODE                                    ");
		sql.append("     , YOYANG_NAME                                  ");
		sql.append("  FROM BAS0001 A                                    ");
		sql.append(" WHERE START_DATE = (SELECT MAX(START_DATE)         ");
		sql.append("                     FROM BAS0001                   ");
		sql.append("                    WHERE HOSP_CODE = A.HOSP_CODE)  ");
		if("%".equalsIgnoreCase(hospCode)){
			sql.append("   AND HOSP_CODE LIKE :f_hosp_code                  ");
			
		}else{
			sql.append("   AND HOSP_CODE = :f_hosp_code                  ");
		}
		if(!StringUtils.isEmpty(language)){
			sql.append("	AND LANGUAGE = :f_language                         ");
		}
		sql.append(" GROUP BY HOSP_CODE  , YOYANG_NAME                   ");
		sql.append(" ORDER BY HOSP_CODE ASC                             ");
		Query query = entityManager.createNativeQuery(sql.toString());
		if("%".equalsIgnoreCase(hospCode)){
			query.setParameter("f_hosp_code", hospCode);
			
		}else{
			query.setParameter("f_hosp_code", hospCode);
		}
		if(!StringUtils.isEmpty(language)){
			query.setParameter("f_language", language);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	public ADMS2015U00GetHospitalInfo getADMS2015U00GetHospitalInfo(String hospCode, String language) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT HOSP_CODE, 				");
		sql.append("	       YOYANG_NAME,             ");
		sql.append("	       YOYANG_NAME2             ");
		sql.append("	FROM BAS0001                    ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code  ");
		sql.append("	AND LANGUAGE = :f_language		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ADMS2015U00GetHospitalInfo> list = new JpaResultMapper().list(query, ADMS2015U00GetHospitalInfo.class);
		if (!CollectionUtils.isEmpty(list)&&list.get(0)!=null) {
			return list.get(0);
		}
		return null;
	}

	@Override
	public String checkAutoGenHospital(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(AUTO_BUNHO_FLG AS CHAR)			");
		sql.append("	FROM BAS0001                    ");
		sql.append("	WHERE HOSP_CODE = :hospCode     ");
		sql.append("	AND LANGUAGE = :language        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<String> list = query.getResultList();
		if (!CollectionUtils.isEmpty(list) && list.get(0)!=null) {
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<OCS1003R02DTHospListItemInfo> getOCS1003R02DTHospListItemInfo(
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JAEDAN_NAME                                               ");
		sql.append("        ,A.SIMPLE_YOYANG_NAME                                       ");
		sql.append("        ,A.TEL                                                      ");
		sql.append("        ,A.HOMEPAGE                                                 ");
		sql.append("    FROM BAS0001 A                                                  ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code AND LANGUAGE = :f_language      ");
		sql.append("     AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE				");
		sql.append("   ORDER BY A.START_DATE DESC LIMIT 1								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<OCS1003R02DTHospListItemInfo> list = new JpaResultMapper().list(query, OCS1003R02DTHospListItemInfo.class);
		return list;
	}
	
	@Override
	public List<OUT1001R01GrdListInfo> getOUT1001R01GrdListInfo(String hospCode, String language, String bunho, String naewonDate){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO                                                                                                                             ");
		sql.append(" ,B.SUNAME                                                                                                                                  ");
		sql.append(" ,B.SUNAME2                                                                                                                                 ");
		sql.append(" ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', B.BIRTH,:f_hosp_code,:f_language)                                                                       ");
		sql.append(" ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.NAEWON_DATE,:f_hosp_code,:f_language)                                                                 ");
		sql.append(" ,A.NAEWON_DATE                                                                                                                             ");
		sql.append(" ,A.SUJIN_NO                                                                                                                                ");
		sql.append(" ,A.JUBSU_NO                                                                                                                                ");
		sql.append(" ,A.GWA                                                                                                                                     ");
		sql.append(" ,FN_BAS_LOAD_GWA_NAME(A.GWA,A.NAEWON_DATE,:f_hosp_code,:f_language) GWA_NAME                                                               ");
		sql.append(" ,A.DOCTOR                                                                                                                                  ");
		sql.append(" ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,A.NAEWON_DATE,:f_hosp_code) DOCTOR_NAME                                                                  ");
		sql.append(" ,A.JUBSU_GUBUN                                                                                                                             ");
		sql.append(" ,FN_BAS_LOAD_CODE_NAME('JUBSU_GUBUN',A.JUBSU_GUBUN,:f_hosp_code,:f_language) GUBUN_NAME                                                    ");
		sql.append(" ,CASE WHEN IFNULL(A.RESER_YN,'N') = 'Y' THEN A.JUBSU_TIME                                                                                  ");
		sql.append("   ELSE ''                                                                                                                                  ");
		sql.append(" END JUBSU_TIME                                                                                                                             ");
		sql.append(" ,FN_BAS_LOAD_CODE_NAME('CHOJAE', A.CHOJAE,:f_hosp_code,:f_language) CHOJAE_NAME                                                            ");
		sql.append(" ,IF(A.RESER_YN = 'Y', '◎', '' )           RESER_YN                                                                                         ");
		sql.append("        ,A.ARRIVE_TIME                                ARRIVE_TIME                                                                           ");
		sql.append("        ,A.NAEWON_YN                                  NAEWON_YN                                                                             ");
		sql.append("        ,C.YOYANG_NAME                                YOYANG_NAME                                                                           ");
		sql.append("        ,LPAD(CONCAT('0' , A.JUBSU_TIME , A.JUBSU_NO),9,'0')            SORT_KEY                                                            ");
		sql.append("        ,''                                           JUNDAL_PART                                                                           ");
		sql.append("    FROM OUT1001 A, OUT0101 B, BAS0001 C, BAS0102 D                                                                                         ");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                         ");
		sql.append("   AND A.BUNHO       = :f_bunho                                                                                                             ");
		sql.append("   AND A.NAEWON_DATE = STR_TO_DATE(:f_naewon_date,'%Y/%m/%d')                                                                               ");
		sql.append("   AND A.NAEWON_YN   != 'E'                                                                                                                 ");
		sql.append("   AND B.HOSP_CODE   = A.HOSP_CODE                                                                                                          ");
		sql.append("   AND B.BUNHO       = A.BUNHO                                                                                                              ");
		sql.append("   AND C.HOSP_CODE   = A.HOSP_CODE                                                                                                          ");
		sql.append("   AND A.NAEWON_DATE BETWEEN C.START_DATE AND IFNULL(C.END_DATE, '9998/12/31')                                                              ");
		sql.append("   AND D.HOSP_CODE   = A.HOSP_CODE                                                                                                          ");
		sql.append("   AND D.CODE_TYPE   = 'JUBSU_GUBUN'                                                                                                        ");
		sql.append("   AND D.CODE        = A.JUBSU_GUBUN                                                                                                        ");
		sql.append("   AND D.LANGUAGE    = :f_language                                                                                                          ");
		sql.append("   AND D.GROUP_KEY   IN ('1', '2')                                                                                                          ");
		sql.append(" UNION ALL                                                                                                                                  ");
		sql.append(" SELECT DISTINCT                                                                                                                            ");
		sql.append("         A.BUNHO                                                                                                                            ");
		sql.append("        ,B.SUNAME                                                                                                                           ");
		sql.append("        ,B.SUNAME2                                                                                                                          ");
		sql.append("        ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', B.BIRTH,:f_hosp_code,:f_language)                                                                ");
		sql.append("        ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.RESER_DATE,:f_hosp_code,:f_language)                                                           ");
		sql.append("        ,A.RESER_DATE                                                                                                                       ");
		sql.append("        ,0                   SUJIN_NO                                                                                                       ");
		sql.append("        ,0                   JUBSU_NO                                                                                                       ");
		sql.append("        ,A.GWA                                                                                                                              ");
		sql.append("        ,FN_BAS_LOAD_GWA_NAME ( A.GWA, A.RESER_DATE,:f_hosp_code,:f_language)      GWA_NAME                                                 ");
		sql.append("         ,A.DOCTOR                                                                                                                          ");
		sql.append("        ,FN_BAS_LOAD_DOCTOR_NAME ( A.DOCTOR, A.RESER_DATE,:f_hosp_code) DOCTOR_NAME                                                         ");
		sql.append("        , A.JUNDAL_TABLE                                                                                                                    ");
		sql.append("        , IF(A.JUNDAL_TABLE = 'CPL', FN_SCH_LOAD_JUNDAL_PART_NAME(A.JUNDAL_TABLE, A.JUNDAL_TABLE, :f_hosp_code) , D.HANGMOG_NAME) GUBUN_NAME");
		sql.append("        , IFNULL(A.RESER_TIME, '')                          JUBSU_TIME                                                                      ");
		sql.append("        , ''                                             CHOJAE_NAME                                                                        ");
		sql.append("        ,IF(A.RESER_YN = 'Y', '◎', '' )              RESER_YN                                                                               ");
		sql.append("        ,''                                              ARRIVE_TIME                                                                        ");
		sql.append("        ,'Y'                                             NAEWON_YN                                                                          ");
		sql.append("        ,C.YOYANG_NAME                                   YOYANG_NAME                                                                        ");
		sql.append("        ,LPAD(CONCAT('1','0000','0000'),9,'0')  SORT_KEY                                                                                    ");
		sql.append("        ,A.JUNDAL_PART                                            JUNDAL_PART                                                               ");
		sql.append(" FROM  OCS0103 D,                                                                                                                           ");
		sql.append("       BAS0001 C,                                                                                                                           ");
		sql.append("       OUT0101 B,                                                                                                                           ");
		sql.append("       SCH0201 A                                                                                                                            ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                                                                                                     ");
		sql.append("    AND A.BUNHO          = :f_bunho                                                                                                         ");
		sql.append("    AND A.RESER_DATE     = STR_TO_DATE(:f_naewon_date,'%Y/%m/%d')                                                                           ");
		sql.append("    AND A.GWA            LIKE '%'                                                                                                           ");
		sql.append("    AND A.RESER_YN       = 'Y'                                                                                                              ");
		sql.append("    AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                                       ");
		sql.append("    AND ((A.JUNDAL_TABLE = 'XRT' AND A.JUNDAL_PART  LIKE 'RI%') OR                                                                          ");
		sql.append("         (A.JUNDAL_PART  NOT LIKE 'RI%' AND A.PART_PKKEY IS NULL))                                                                          ");
		sql.append("    AND A.ACTING_DATE IS NULL                                                                                                               ");
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                                                                         ");
		sql.append("   AND B.BUNHO       = A.BUNHO                                                                                                              ");
		sql.append("   AND C.HOSP_CODE   = A.HOSP_CODE                                                                                                          ");
		sql.append("   AND A.RESER_DATE BETWEEN C.START_DATE AND IFNULL(C.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))                                       ");
		sql.append("   AND D.HOSP_CODE      = A.HOSP_CODE                                                                                                       ");
		sql.append("   AND D.HANGMOG_CODE   = A.HANGMOG_CODE                                                                                                    ");
		sql.append("   AND A.RESER_DATE BETWEEN  D.START_DATE AND IFNULL(D.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))                                      ");
		sql.append("   UNION ALL                                                                                                                                ");
		sql.append("   SELECT DISTINCT                                                                                                                          ");
		sql.append("         A.BUNHO                                                                                                                            ");
		sql.append("        ,C.SUNAME                                                                                                                           ");
		sql.append("        ,C.SUNAME2                                                                                                                          ");
		sql.append("        ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', C.BIRTH,:f_hosp_code,:f_language)                                                                ");
		sql.append("        ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', B.RESER_DATE,:f_hosp_code,:f_language)                                                           ");
		sql.append("        ,B.RESER_DATE                                                                                                                       ");
		sql.append("        ,0                   SUJIN_NO                                                                                                       ");
		sql.append("        ,0                   JUBSU_NO                                                                                                       ");
		sql.append("        ,B.GWA                                                                                                                              ");
		sql.append("        ,FN_BAS_LOAD_GWA_NAME( B.GWA, B.RESER_DATE,:f_hosp_code,:f_language)      GWA_NAME                                                  ");
		sql.append("         ,A.DOCTOR                                                                                                                          ");
		sql.append("        ,FN_BAS_LOAD_DOCTOR_NAME ( A.DOCTOR, B.RESER_DATE,:f_hosp_code) DOCTOR_NAME                                                         ");
		sql.append("        ,''                                                                                                                                 ");
		sql.append("        ,FN_ADM_MSG(4108,:f_language)                                  GUBUN_NAME                                                           ");
		sql.append("        ,IFNULL(B.RESER_TIME, '')                             JUBSU_TIME                                                                    ");
		sql.append("        , ''                                               CHOJAE_NAME                                                                      ");
		sql.append("        ,'◎'                                              RESER_YN                                                                          ");
		sql.append("        ,''                                                ARRIVE_TIME                                                                      ");
		sql.append("        ,'Y'                                               NAEWON_YN                                                                        ");
		sql.append("        ,D.YOYANG_NAME                                     YOYANG_NAME                                                                      ");
		sql.append("        ,LPAD(CONCAT('2','0000','0000'),9,'0')  SORT_KEY                                                                                    ");
		sql.append("        ,''                                           	  JUNDAL_PART                                                                       ");
		sql.append("   FROM BAS0001 D                                                                                                                           ");
		sql.append("      ,  OUT0101 C                                                                                                                          ");
		sql.append("      , INJ1001 A                                                                                                                           ");
		sql.append("      , INJ1002 B                                                                                                                           ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                                                                                                     ");
		sql.append("    AND A.BUNHO          = :f_bunho                                                                                                         ");
		sql.append("    AND IFNULL(A.DC_YN,'N') = 'N'                                                                                                           ");
		sql.append("    AND B.HOSP_CODE      = A.HOSP_CODE                                                                                                      ");
		sql.append("    AND B.FKINJ1001      = A.PKINJ1001                                                                                                      ");
		sql.append("    AND B.RESER_DATE     = STR_TO_DATE(:f_naewon_date,'%Y/%m/%d')                                                                           ");
		sql.append("    AND B.ACTING_DATE IS NULL                                                                                                               ");
		sql.append("    AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                      ");
		sql.append("    AND C.BUNHO          = A.BUNHO                                                                                                          ");
		sql.append("    AND D.HOSP_CODE      = B.HOSP_CODE                                                                                                      ");
		sql.append("    AND B.RESER_DATE BETWEEN D.START_DATE AND IFNULL(D.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))                                      ");
		sql.append("  ORDER BY SORT_KEY, JUNDAL_PART                                                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);
		List<OUT1001R01GrdListInfo> list = new JpaResultMapper().list(query, OUT1001R01GrdListInfo.class);
		return list;
	}
	
	@Override
	public List<DOC4003U00GetHospInfo> getDOC4003U00GetHospInfo(String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CONCAT(SUBSTR(A.ZIP_CODE, 1, 3), '-', SUBSTR(A.ZIP_CODE, 4)) ZIP_CODE ");
		sql.append("		 , A.ADDRESS                                                          ");
		sql.append("		 , CONCAT('TEL:', IFNULL(A.TEL,''),' FAX:', IFNULL(A.FAX,'')) TEL     ");
		sql.append("		 , A.YOYANG_NAME                                                      ");
		sql.append("	  FROM BAS0001 A                                                          ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                                            ");
		sql.append("	   AND SYSDATE() BETWEEN A.START_DATE                                     ");
		sql.append("					   AND A.END_DATE;                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		
		List<DOC4003U00GetHospInfo> list = new JpaResultMapper().list(query, DOC4003U00GetHospInfo.class);
		return list;
	}

	@Override
	public List<ORCATransferOrdersHeaderInfo> getORCATransferOrdersHeaderInfo(String hospCode, String langauge) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  :hosp_code  							FACILITYID ,                                ");
		sql.append("  DATE_FORMAT(SYSDATE(),'%Y/%m/%d %H:%i:%s')  	SYS_DATE ,                                  ");
		sql.append("          YOYANG_NAME        					HOSP_NAME ,                                 ");
		sql.append("         ADDRESS          						HOSP_ADDRESS ,                              ");
		sql.append("        CONCAT(IFNULL(ZIP_CODE1, '') , '-' , IFNULL(ZIP_CODE2,''))	HOSP_ZIPCODE  ,         ");
//		sql.append(" 	(SELECT CODE_NAME																		 ");
//		sql.append(" 	 FROM BAS0102																			 ");
//		sql.append(" 	 WHERE CODE = 'HOSP_CODE'																 ");
//		sql.append(" 	   AND CODE_TYPE = 'ACCT_ORCA'															 ");
//		sql.append("       AND LANGUAGE = :langauge																 ");
//		sql.append(" 	   AND HOSP_CODE = :hosp_code															 ");
//		sql.append("	 LIMIT 1) 														FACILITY_CODE,  		 ");
		sql.append("	     ACCT_REF_ID 												FACILITY_CODE, 		     ");
		sql.append("         'doctor'   												CREATER_TEXT , 			 ");
		sql.append("         COUNTRY_CODE       										COUNTRY_TYPE			 ");
		sql.append(" FROM BAS0001  WHERE HOSP_CODE   = :hosp_code AND LANGUAGE = :langauge                       ");
		sql.append("  ORDER BY START_DATE DESC LIMIT 1                                                           ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("langauge", langauge);
		
		List<ORCATransferOrdersHeaderInfo> list = new JpaResultMapper().list(query, ORCATransferOrdersHeaderInfo.class);
		return list;
	}

	@Override
	public List<ORCATransferOrdersHealthInsuranceInfo> getORCATransferOrdersHealthInsuranceInfo(String hospCode, String bunho, Double pkout1001, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT   ''                                              PRIORITY_NUMBER,       ");         
		sql.append("          ''                                              PROVIDER_NAME,         ");         
		sql.append("          ''                                              PUBLIC_START_DATE,     ");         
		sql.append("          ''                                              PUBLIC_END_DATE,       ");         
		sql.append("          ''                                              ENCOUNTER_DATE,        ");         
		sql.append("          N.GUBUN                                   INSURANCE_CODE,              ");         
		sql.append("          N.JOHAP                                   INS_NUMBER,                  ");         
		sql.append("          DATE_FORMAT(START_DATE, '%Y/%m/%d')                INS_START_DATE,     ");         
		sql.append("          DATE_FORMAT(END_DATE, '%Y/%m/%d')                   INS_END_DATE       ");         
		sql.append(" FROM OUT0102 N  INNER JOIN OUT1001 M             								 ");         
		sql.append("   ON N.BUNHO = M.BUNHO AND N.HOSP_CODE = M.HOSP_CODE AND N.GUBUN = M.GUBUN      ");
		sql.append("   AND M.PKOUT1001 = :pkout1001 												 ");
		sql.append(" WHERE N.BUNHO   = :bunho                                                        ");         
		sql.append("   AND N.HOSP_CODE  =  :hosp_code                                                ");         
		sql.append("   AND SYSDATE() BETWEEN START_DATE  AND END_DATE                                ");         
		sql.append("  UNION ALL                                                                      ");         
		sql.append("  SELECT                                                                         ");         
		sql.append("          B.PRIORITY                             PRIORITY_NUMBER,                ");         
		sql.append("          D.GONGBI_NAME                          PROVIDER_NAME,                  ");         
		sql.append("          DATE_FORMAT(C.START_DATE, '%Y/%m/%d')     PUBLIC_START_DATE,           ");         
		sql.append("          DATE_FORMAT(C.END_DATE, '%Y/%m/%d')       PUBLIC_END_DATE,             ");         
		sql.append("          DATE_FORMAT(A.NAEWON_DATE, '%Y/%m/%d')       ENCOUNTER_DATE,           ");         
		sql.append("          ''                                             INSURANCE_CODE,         ");         
		sql.append("          ''                                             INS_NUMBER,             ");         
		sql.append("          ''                                             INS_START_DATE,         ");         
		sql.append("          ''                                             INS_END_DATE            ");         
		sql.append("  FROM                                                                           ");         
		sql.append("          OUT1001 A LEFT JOIN OUT1002 B   ON     B.FKOUT1001 = A.PKOUT1001       ");         
		sql.append("  LEFT JOIN OUT0105 C ON    C.GONGBI_CODE = B.GONGBI_CODE                        ");         
		sql.append("  LEFT JOIN BAS0212 D ON D.GONGBI_CODE = B.GONGBI_CODE AND D.LANGUAGE = :language ");         
		sql.append("  WHERE    A.BUNHO      =    :bunho                                              ");         
		sql.append("          AND A.HOSP_CODE    =  :hosp_code                                       ");         
		sql.append("          AND B.FKOUT1001    =   :pkout1001                						 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("pkout1001", pkout1001);
		query.setParameter("bunho", bunho);
		query.setParameter("language", language);
		
		List<ORCATransferOrdersHealthInsuranceInfo> list = new JpaResultMapper().list(query, ORCATransferOrdersHealthInsuranceInfo.class);
		return list;
	}

	@Override
	public List<ORCALibGetDocInfo> getORCALibGetDocInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT A.YOYANG_GIHO,                ");
		sql.append("        A.YOYANG_NAME,                ");
		sql.append("        A.ZIP_CODE,                   ");
		sql.append("        A.ADDRESS,                    ");
		sql.append("        A.TEL,                        ");
		sql.append("        A.PRESIDENT_NAME,             ");
		sql.append("        A.ORCA_GIGWAN_CODE            ");
		sql.append(" FROM BAS0001 A                       ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code     ");
		sql.append("  AND A.LANGUAGE  = :f_language       ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ORCALibGetDocInfo> list = new JpaResultMapper().list(query, ORCALibGetDocInfo.class);
		return list;
	}

	@Override
	public Bas0001 getHospCodeByAcctRefId(String acctRefId) {
		StringBuilder sql = new StringBuilder();

		sql.append(" Select bas0001 from Bas0001 bas0001 WHERE acctRefId = :acctRefId ORDER BY startDate DESC ");

		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("acctRefId", acctRefId);

		List<Bas0001> result = query.getResultList();
		if(!result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public Bas0001 getByHospCode(String hospCode) {
		String sql = "Select bas0001 from Bas0001 bas0001 WHERE hospCode = :hospCode ORDER BY startDate DESC ";
		
		Query query = entityManager.createQuery(sql);
		query.setParameter("hospCode", hospCode);

		List<Bas0001> result = query.getResultList();
		if(!result.isEmpty()){
			return result.get(0);
		}
		
		return null;
	}

	@Override
	public List<RES1001R00ClinicNameInfo> getRES1001R00ClinicName(String hospCodeLink, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT A.YOYANG_NAME           ");
		sql.append("  ,A.ADDRESS,  A.TEL                     ");
		sql.append(" FROM BAS0001 A , OUT2016 B              ");
		sql.append(" WHERE A.HOSP_CODE = B.HOSP_CODE_LINK    ");
		sql.append(" AND  A.LANGUAGE = :language             ");
		sql.append(" AND B.HOSP_CODE_LINK = :hosp_code_Link  ");
		sql.append(" AND A.START_DATE = (SELECT MAX(START_DATE) FROM BAS0001 C WHERE B.HOSP_CODE_LINK = C.HOSP_CODE ) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code_Link", hospCodeLink);
		query.setParameter("language", language);
		List<RES1001R00ClinicNameInfo> results = new JpaResultMapper().list(query, RES1001R00ClinicNameInfo.class);	
		return results;
	}

	@Override
	public List<RES1001R00ClinicInfo> getRES1001R00ClinicInfo(String hospCode, String hospCodeLink, String language, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.YOYANG_NAME,                  ");
		sql.append("        B.BUNHO                         ");
		sql.append(" FROM BAS0001 A, OUT2016 B              ");
		sql.append(" WHERE A.HOSP_CODE = :hosp_code         ");
		sql.append(" AND A.HOSP_CODE = B.HOSP_CODE          ");
		sql.append(" AND B.HOSP_CODE_LINK = :hosp_code_link ");
		sql.append(" AND A.LANGUAGE   = :language           ");
		sql.append(" AND B.BUNHO_LINK      = :bunho         ");
		sql.append(" AND A.START_DATE = (SELECT MAX(START_DATE) FROM BAS0001 C WHERE B.HOSP_CODE = C.HOSP_CODE ) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("hosp_code_link", hospCodeLink);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		List<RES1001R00ClinicInfo> list = new JpaResultMapper().list(query, RES1001R00ClinicInfo.class);
		return list;
	}

	@Override
	public List<RES1001U00FbxHospCodeLinkListItemInfo> getRES1001U00FbxHospCodeLinkInfo(String hospCode, String language, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HOSP_CODE_LINK,               ");
		sql.append("        B.YOYANG_NAME,                  ");
		sql.append("        B.ADDRESS,                      ");
		sql.append("        B.TEL                          ");
		sql.append(" FROM OUT2016 A, BAS0001 B              ");
		sql.append(" WHERE A.HOSP_CODE_LINK = B.HOSP_CODE   ");
		sql.append(" AND A.HOSP_CODE = :hosp_code           ");
		sql.append(" AND A.BUNHO     = :bunho               ");
		sql.append(" AND B.LANGUAGE  = :language			");
		sql.append(" AND A.ACTIVE_FLG    = 1                ");
		sql.append(" AND B.START_DATE = (SELECT MAX(START_DATE) FROM BAS0001 C WHERE A.HOSP_CODE_LINK = C.HOSP_CODE ) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		List<RES1001U00FbxHospCodeLinkListItemInfo> list = new JpaResultMapper().list(query, RES1001U00FbxHospCodeLinkListItemInfo.class);
		return list;
	}
	
	@Override
	public List<NUR2016Q00GrdHospListInfo> getNUR2016Q00GrdHospListInfo(String hospCode, String language, String yoyangName, String address, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HOSP_CODE 																			 ");
		sql.append("        , IFNULL(A.YOYANG_NAME,'')         YOYANG_NAME                                           ");
		sql.append("        , IFNULL(A.YOYANG_NAME2,'')        KANA_NAME  									    	 ");
		sql.append(" 		, A.ADDRESS																			     ");
		sql.append("		, A.TEL FROM BAS0001 A									                     			 ");
		sql.append(" WHERE  A.HOSP_CODE LIKE :f_hosp_code	AND A.LANGUAGE = :language				                 ");
		sql.append(" AND A.YOYANG_NAME LIKE :f_yoyang_name	                        				                 ");
		sql.append(" AND (A.ADDRESS LIKE :f_address	OR A.ADDRESS IS NULL )				    				         ");
		sql.append(" AND A.START_DATE = (SELECT MAX(START_DATE) FROM BAS0001 B WHERE B.HOSP_CODE = A.HOSP_CODE )     ");
		sql.append(" limit :startNum, :offset                                                                        ");
		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("f_hosp_code", StringUtils.isEmpty(hospCode) ? "%" : "%" + hospCode + "%");
		query.setParameter("language", language);
		query.setParameter("f_yoyang_name", StringUtils.isEmpty(yoyangName) ? "%" : "%" + yoyangName + "%");
		query.setParameter("f_address", StringUtils.isEmpty(address) ? "%" : "%" + address + "%");
		query.setParameter("startNum", startNum);
		query.setParameter("offset", offset);

		List<NUR2016Q00GrdHospListInfo> list = new JpaResultMapper().list(query, NUR2016Q00GrdHospListInfo.class);

		return list;

	}
	
	@Override
	public List<ComboListItemInfo> getHospitalInShard(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT HOSP_CODE                                    																				");
		sql.append("     , YOYANG_NAME                                  																				");
		sql.append("  FROM BAS0001 A                                    																				");
		sql.append(" WHERE START_DATE = (SELECT MAX(START_DATE)         																				");
		sql.append("                     FROM BAS0001                   																				");
		sql.append("                    WHERE HOSP_CODE = A.HOSP_CODE)  																				");
		sql.append(" AND A.SHARDING_ID IN (SELECT A1.SHARDING_ID FROM BAS0001 A1 WHERE A1.HOSP_CODE = :f_hosp_code AND A1.LANGUAGE = :f_language)		");
		sql.append(" AND A.HOSP_CODE <> :f_hosp_code																									");
		if(!StringUtils.isEmpty(language)){
			sql.append("	AND LANGUAGE = :f_language                         																			");
		}
		sql.append(" AND EXISTS (SELECT 'Y' FROM BAS0272 B WHERE B.HOSP_CODE = A.HOSP_CODE AND B.OUT_DISCUSS_YN = 'Y')                                   ");
		sql.append(" GROUP BY HOSP_CODE  , YOYANG_NAME                   																				");
		sql.append(" ORDER BY HOSP_CODE ASC                             																				");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(!StringUtils.isEmpty(language)){
			query.setParameter("f_language", language);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String checkAdminUser(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT B.MASTER_GROUP_HOSP						");
		sql.append("	FROM BAS0001 A ,  BAS0003 B                     ");
		sql.append("	WHERE HOSP_CODE = :hospCode     				");
		sql.append("	AND A.GROUP_CODE = B.GROUP_CODE       			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		
		List<Object> list = query.getResultList();
		if (!CollectionUtils.isEmpty(list) && list.get(0)!=null) {
			return list.get(0).toString();
		}
		return null;
	}

	@Override
	public String getGroupCodeByHospCode(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT G.GROUP_CODE FROM BAS0001 G WHERE G.HOSP_CODE = :hospCode  AND G.LANGUAGE =  :language                        ");     
		sql.append(" 	                        AND G.START_DATE = ((SELECT MAX(START_DATE) FROM BAS0001  WHERE HOSP_CODE = G.HOSP_CODE)) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<String> list = query.getResultList();
		if (!CollectionUtils.isEmpty(list)) {
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<String> getHospCodeInGroup(String hospitalCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HOSP_CODE                                                       ");
		sql.append("    FROM BAS0001 A , BAS0003 B                                            ");
		sql.append(" WHERE B.MASTER_GROUP_HOSP = :hospitalCode                                ");
		sql.append("   AND A.GROUP_CODE = B.GROUP_CODE                                        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		List<String> list  = query.getResultList();

		return list;
	}

}

