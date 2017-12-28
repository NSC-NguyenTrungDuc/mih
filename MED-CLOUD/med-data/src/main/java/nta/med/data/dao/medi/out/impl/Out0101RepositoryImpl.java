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

import nta.med.common.util.DateTimes;
import nta.med.core.domain.out.Out0101;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.PatientContact;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out0101RepositoryCustom;
import nta.med.data.model.ihis.bass.INP1003ChkBunhoListItemInfo;
import nta.med.data.model.ihis.bass.Inp1003U00GrdInpReserListItem;
import nta.med.data.model.ihis.clis.CLIS2015U03PatientListInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00SelectOUT0101ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00GrdPaListItemInfo;
import nta.med.data.model.ihis.cpls.MultiResultViewLayPaInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LoadMakayJungboInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetPatientInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001FormJusaBedLayPatientItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01TempListItemInfo;
import nta.med.data.model.ihis.inps.INP1003U00SaveLayoutChkBunhoInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangeddtBunhoInfo;
import nta.med.data.model.ihis.inps.INP1003U01layBunhoValidationInfo;
import nta.med.data.model.ihis.inps.INPBATCHTRANSlayOut0101Info;
import nta.med.data.model.ihis.nuri.NUR1001U00LayINP1001Info;
import nta.med.data.model.ihis.nuri.NUR2004U00layCurrentBedInfo;
import nta.med.data.model.ihis.nuro.NUR2016Q00GrdPatientListInfo;
import nta.med.data.model.ihis.nuro.NuroManagePatient;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetInsuranceCode;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridBoheomInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridCommentInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridGongbiListInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridPatientInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02HospitalItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02LayDupPatientInfo;
import nta.med.data.model.ihis.nuro.NuroSearchPatientInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSLayOut0101Info;
import nta.med.data.model.ihis.nuro.OUT0101Q01GrdPatientListInfo;
import nta.med.data.model.ihis.nuro.OUT0101U02PatientExportInfo;
import nta.med.data.model.ihis.nuro.OUT1001P03BunhoListItemInfo;
import nta.med.data.model.ihis.nuro.OUT1001P03GrdAfterJubsuInfo;
import nta.med.data.model.ihis.nuro.OUT1001P03GrdBeforeJubsuInfo;
import nta.med.data.model.ihis.nuro.OUT1001R01LayOut0101Info;
import nta.med.data.model.ihis.nuro.PatientDetailInfo;
import nta.med.data.model.ihis.nuro.RES1001R00PatientNameInfo;
import nta.med.data.model.ihis.ocsa.OCS0503Q00LoadConsultInfo;
import nta.med.data.model.ihis.ocsa.OCSAPPROVEGrdPatientListInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02grdPatientListInfo;
import nta.med.data.model.ihis.ocso.OCS1003R00LayOUT1001Info;
import nta.med.data.model.ihis.ocso.OCS1003R02DTListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003R02LayR03ListInfo;
import nta.med.data.model.ihis.ocso.OCSACT2GetPatientListOCSInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdOrderInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdPaListInfo;
import nta.med.data.model.ihis.schs.SCH0201U99BookingDetailInfo;
import nta.med.data.model.ihis.schs.Schs0201U99InsertResultInfo;
import nta.med.data.model.ihis.system.FindPatientInfo;
import nta.med.data.model.ihis.system.LoadPatientBaseInfo;
import nta.med.data.model.ihis.system.PatientAccountInfo;
import nta.med.data.model.ihis.system.PatientByCodeInfo;
import nta.med.data.model.ihis.system.PrOcsLoadNaewonInfo;
import nta.med.data.model.ihis.system.XPaInfoBoxInfo;

/**
 * @author dainguyen.
 */
public class Out0101RepositoryImpl implements Out0101RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Out0101RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;

	public List<NuroSearchPatientInfo> getNuroSearchPatientInfo(
			String hospCode, String patientCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUNHO, A.SUNAME, A.SUNAME2, DATE_FORMAT(A.BIRTH, '%Y/%m/%d') BIRTH");
		sql.append("  FROM OUT0101 A                                                  ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode AND A.BUNHO = :patientCode         ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);

		List<NuroSearchPatientInfo> list = new JpaResultMapper().list(query,NuroSearchPatientInfo.class);

		return list;
	}

	@Override
	public List<NuroManagePatient> getNuroManagePatientInfo(String hospCode,
			String language, String patientCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUNHO                                                                ");
		sql.append("     , A.SUNAME                                                               ");
		sql.append("     , A.SUNAME2                                                              ");
		sql.append("     , A.BIRTH                                                                ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('SEX', A.SEX, :hospCode, :language)              ");
		sql.append("     , A.ZIP_CODE1                                            ZIP_CODE1       ");
		sql.append("     , A.ZIP_CODE2                                            ZIP_CODE2       ");
		sql.append("     , A.ADDRESS1                                             ADDRESS1        ");
		sql.append("     , A.ADDRESS2                                             ADDRESS2        ");
		sql.append("     , A.TEL                                                  TEL             ");
		sql.append("     , A.TEL1                                                 TEL1            ");
		sql.append("     , A.TEL_HP                                               TEL_HP          ");
		sql.append("     , A.TEL_GUBUN                                                            ");
		sql.append("     , A.TEL_GUBUN2                                                           ");
		sql.append("     , A.TEL_GUBUN3                                                           ");
		sql.append("     , A.EMAIL                                                EMAIL           ");
		sql.append("     , A.PACE_MAKER_YN                                        PACE_MAKER_YN   ");
		sql.append("     , A.SELF_PACE_MAKER                                      SELF_PACE_MAKER ");
		sql.append("FROM OUT0101 A                                                                ");
		sql.append("WHERE A.HOSP_CODE  = :hospCode                                                ");
		sql.append("AND A.BUNHO      = :patientCode                                               ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("patientCode", patientCode);

		List<NuroManagePatient> list = new JpaResultMapper().list(query,
				NuroManagePatient.class);
		return list;
	}

	@Override
	public List<PatientByCodeInfo> getGetPatientByCode(String hospCode, String patientCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SUNAME ,A.SUNAME2 ,A.SEX                                                                            ");
		sql.append("      ,FN_BAS_LOAD_AGE(SYSDATE(), A.BIRTH, '') YEAR_AGE                                                      ");
		sql.append("      ,FN_BAS_LOAD_AGE_MONTH(SYSDATE(), A.BIRTH) MONTH_AGE                                                   ");
		sql.append("      ,A.GUBUN ,FN_ADM_DICT_NM('GUBUN',A.GUBUN, :language) ,DATE_FORMAT(A.BIRTH,'%Y/%m/%d')   ,A.TEL ,A.TEL1 ,A.TEL_HP  ");
		sql.append("      ,A.EMAIL ,A.ZIP_CODE1 ,A.ZIP_CODE2 ,A.ADDRESS1 ,A.ADDRESS2                                             ");
		sql.append("	  ,A.TEL_GUBUN, A.TEL_GUBUN2, A.TEL_GUBUN3, A.PWD														 ");
		sql.append("                                                                                                             ");
		sql.append("FROM OUT0101 A                                                                                               ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                                                                                ");
		sql.append("AND A.BUNHO = :patientCode                                                                                   ");
		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("language", language);
		List<PatientByCodeInfo> list = new JpaResultMapper().list(query, PatientByCodeInfo.class);
		return list;
	}

	@Override
	public Integer updateNuroPatientInfo(String hospCode, String patientCode,
			String zipCode1, String zipCode2, String address1, String address2,
			String tel, String tel1, String telHp, String telGubun,
			String telGubun2, String telGubun3, String email,
			String paceMakerYn, String selfPaceMaker){
		
		StringBuilder sql = new StringBuilder();
		sql.append("UPDATE OUT0101                           ");
		sql.append("SET ZIP_CODE1          = :zipCode1       ");
		sql.append("  , ZIP_CODE2          = :zipCode2       ");
		sql.append("  , ADDRESS1           = :address1       ");
		sql.append("  , ADDRESS2           = :address2       ");
		sql.append("  , TEL                = :tel            ");
		sql.append("  , TEL1               = :tel1           ");
		sql.append("  , TEL_HP             = :telHp          ");
		sql.append("  , TEL_GUBUN          = :telGubun       ");
		sql.append("  , TEL_GUBUN2         = :telGubun2      ");
		sql.append("  , TEL_GUBUN3         = :telGubun3      ");
		sql.append("  , EMAIL              = :email          ");
		sql.append("  , PACE_MAKER_YN      = :paceMakerYn    ");
		sql.append("  , SELF_PACE_MAKER    = :selfPaceMaker  ");
		sql.append("WHERE HOSP_CODE          = :hospCode     ");
		sql.append("  AND BUNHO              = :patientCode  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("zipCode1", zipCode1);
		query.setParameter("zipCode2", zipCode2);
		query.setParameter("address1", address1);
		query.setParameter("address2", address2);
		query.setParameter("tel", tel);
		query.setParameter("tel1", tel1);
		query.setParameter("telHp", telHp);
		query.setParameter("telGubun", telGubun);
		query.setParameter("telGubun2", telGubun2);
		query.setParameter("telGubun3", telGubun3);
		query.setParameter("email", email);
		query.setParameter("paceMakerYn", paceMakerYn);
		query.setParameter("selfPaceMaker", selfPaceMaker);
		
		return query.executeUpdate();	
	}
	
	@Override
	public List<FindPatientInfo> getFindPatientInfo(String hospCode, String language, String patientName2, String sex , String birth, String tel, String type, Integer startNum, Integer offset){
		
		StringBuilder sql = new StringBuilder();

		sql.append(" SELECT A.BUNHO 																								");
		sql.append(" ,A.SUNAME 																										");
		sql.append(" ,A.SUNAME2 																									");
		sql.append(" ,FN_BAS_LOAD_CODE_NAME('SEX_GUBUN', A.SEX, :hospCode, :language) 												");
		sql.append("      ,A.BIRTH                                                                                                  ");
		sql.append("      ,FN_OUT_LOAD_LAST_NAEWON_DATE_NEW(A.BUNHO, '%', :hospCode)                                                ");
		sql.append("      ,CONCAT(IFNULL(A.ADDRESS1,'') , ' ' , IFNULL(A.ADDRESS2,'')   )                                           ");
		sql.append("      ,IF(FN_INP_LOAD_JAEWON_HO_DONG(:hospCode, A.BUNHO) IS NULL, NULL ,FN_ADM_MSG('3122', :language)) IPWON_YN ");
		sql.append("      ,FN_INP_LOAD_JAEWON_HO_DONG(:hospCode, A.BUNHO)      HO_DONG                                              ");
		sql.append("      ,IFNULL(A.TEL, '')                                                                                        ");
		sql.append("  FROM OUT0101 A                                                                                                ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                                                                  ");
		if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
			sql.append("   AND A.SUNAME2 LIKE :patientName2                                                                         ");
		}else{
			sql.append("   AND A.SUNAME LIKE :patientName2                                                                          ");
		}
		sql.append("   AND IFNULL(A.SEX, '%') LIKE :sex                                                                             ");
		sql.append("   AND IF(IFNULL(DATE_FORMAT(:birth, '%Y/%m/%d') , '9999/12/31') = '9999/12/31', '9999/12/31',DATE_FORMAT( A.BIRTH, '%Y/%m/%d' )) = IFNULL(DATE_FORMAT(:birth, '%Y/%m/%d'), '9999/12/31')  ");
		sql.append("   AND IFNULL(A.TEL, '%')  LIKE :tel                                                                            ");
		sql.append("   AND IFNULL(A.DELETE_YN, 'N') = 'N'                                                                           ");
		sql.append("   AND (  ( :type = 'J' AND FN_INP_LOAD_JAEWON_HO_DONG(:hospCode, A.BUNHO) IS NOT NULL )                        ");
		sql.append("       OR ( :type = 'A' AND 'A' = 'A' ) )                                                                       ");
		sql.append(" ORDER BY A.SUNAME2, A.BUNHO                                                                                    ");
		sql.append("   LIMIT :startNum, :offset 																		    		");

		if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
			patientName2 = patientName2 + "%";
		}else{
			patientName2 = "%" + patientName2 + "%";
		}

		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("patientName2", patientName2);
		query.setParameter("sex", sex + "%");
		query.setParameter("birth", birth);
		query.setParameter("tel", "%" + tel + "%");
		query.setParameter("type", type);
		query.setParameter("startNum", startNum);
		query.setParameter("offset", offset);
		
		List<FindPatientInfo> list = new JpaResultMapper().list(query, FindPatientInfo.class);
		return list;
	}
	
	@Override	
	public List<XPaInfoBoxInfo> getXPaInfoBoxInfo(String hospCode, String patientCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SUNAME ,A.SUNAME2 ,A.SEX                                         ");
		sql.append("      ,FN_BAS_LOAD_AGE(SYSDATE(), A.BIRTH,'') YEAR_AGE                    ");
		sql.append("      ,FN_BAS_LOAD_AGE_MONTH(SYSDATE(), A.BIRTH) MONTH_AGE                ");
		sql.append("      ,A.GUBUN ,FN_ADM_DICT_NM('GUBUN',A.GUBUN, :language)                ");
		sql.append("	  ,DATE_FORMAT(A.BIRTH,'%Y/%m/%d') ,A.TEL ,A.TEL1 ,A.TEL_HP           ");
		sql.append("      ,A.EMAIL ,A.ZIP_CODE1 ,A.ZIP_CODE2 ,A.ADDRESS1 ,A.ADDRESS2          ");
		sql.append("FROM OUT0101 A                                                            ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                                             ");
		sql.append("  AND A.BUNHO = :patientCode                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("language", language);
		
		List<XPaInfoBoxInfo> list = new JpaResultMapper().list(query,XPaInfoBoxInfo.class);
		return list;
	}

	@Override
	public List<NuroOUT0101U02GridCommentInfo> getOUT0101U02GridCommentInfo(
			String hospCode , String patientCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" 	SELECT A.SER SER				");
		sql.append("  , A.COMMENTS COMMENTS				");
		sql.append("  , A.BUNHO BUNHO					");
		sql.append("  FROM OUT0106 A					");
		sql.append("  WHERE A.HOSP_CODE = :hospCode 	");
		sql.append("  AND A.BUNHO = :patientCode		");
		sql.append(" ORDER BY SER						");		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		
		List<NuroOUT0101U02GridCommentInfo> list = new JpaResultMapper().list(query,NuroOUT0101U02GridCommentInfo.class);
		return list;
	}

	@Override
	public List<NuroOUT0101U02GridBoheomInfo> getNuroOUT0101U02GridBoheomInfo(
			String language, String hospCode, String patientCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.START_DATE																							");
		sql.append("  , A.BUNHO																									");
		sql.append("  , D.SUNAME				                                                                                ");
		sql.append("  , A.GUBUN                                                                                                 ");
		sql.append("  , FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, DATE_FORMAT(SYSDATE(), '%Y-%m-%d'),:hospCode ) GUBUN_NAME               ");
		sql.append("  , A.JOHAP                                                                                                 ");
		sql.append("  , FN_BAS_LOAD_JOHAP_NAME(A.GUBUN, A.JOHAP, A.START_DATE, :language) JOHAP_NAME                            ");
		sql.append("  , '' TEL                                                                                                  ");
		sql.append("  , A.GAEIN                                                                                                 ");
		sql.append("  , A.GAEIN_NO                                                                                              ");
		sql.append("  , A.BON_GA_GUBUN                                                                                          ");
		sql.append("  , FN_BAS_LOAD_CODE_NAME('BON_GA_GUBUN', A.BON_GA_GUBUN, :hospCode , :language) BONIN_GUBUN_NAME           ");
		sql.append("  , A.PINAME                                                                                                ");
		sql.append("  , IF(A.LAST_CHECK_DATE IS NULL, '00/00/00', DATE_FORMAT(A.LAST_CHECK_DATE, '%Y/%m/%d'))	LAST_CHECK_DATE	");
		sql.append("  , A.END_DATE                                                                                              ");
		sql.append("  , E.JOHAP_GUBUN                                                                                           ");
		sql.append("  , A.GUBUN OLD_GUBUN                                                                                       ");
		sql.append("  , 'Y' RETRIEVE_YN                                                                                         ");
		sql.append("  , A.START_DATE OLD_START_DATE                                                                             ");
		sql.append("  , IF(A.CHUIDUK_DATE IS NULL, '', DATE_FORMAT(A.CHUIDUK_DATE, '%Y/%m/%d'))	CHUIDUK_DATE					");
		sql.append("  , CASE WHEN A.END_DATE < DATE_FORMAT(SYSDATE(), '%Y-%m-%d') THEN 'Y'                                      ");
		sql.append("  ELSE 'N' END END_YN                                                                                       ");
		sql.append("  FROM BAS0210 E                                                                                            ");
		sql.append("  , OUT0101 D                                                                                               ");
		sql.append("  , OUT0102 A                                                                                               ");
		sql.append("  WHERE A.HOSP_CODE = :hospCode                                                                             ");
		sql.append("  AND D.HOSP_CODE = A.HOSP_CODE                                                                             ");
		sql.append("  AND A.BUNHO = :patientCode                                                                                ");
		sql.append("  AND A.BUNHO = D.BUNHO                                                                                     ");
		sql.append("  AND A.GUBUN = E.GUBUN   AND E.LANGUAGE = :language                                                        ");
		sql.append("  AND DATE_FORMAT(SYSDATE(), '%Y-%m-%d') BETWEEN E.START_DATE AND E.END_DATE                                ");
		sql.append("  ORDER BY CONCAT(DATE_FORMAT(A.START_DATE,'%Y%m%d'), A.GUBUN) DESC                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("patientCode", patientCode);
		
		List<NuroOUT0101U02GridBoheomInfo> list = new JpaResultMapper().list(query,NuroOUT0101U02GridBoheomInfo.class);
		return list;
	}

	@Override
	public List<NuroOUT0101U02GridGongbiListInfo> getNuroOUT0101U02GridGongbiListInfo(String hospCode, String patientCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.START_DATE START_DATE														");	
		sql.append(" , A.BUNHO                                                                          ");
		sql.append(" , A.BUDAMJA_BUNHO                                                                  ");
		sql.append(" , A.GONGBI_CODE                                                                    ");
		sql.append(" , A.SUGUBJA_BUNHO                                                                  ");
		sql.append(" , A.END_DATE                                                                       ");
		sql.append(" , A.REMARK                                                                         ");
		sql.append(" , A.LAST_CHECK_DATE                                                                ");
		sql.append(" , B.GONGBI_NAME                                                                    ");
		sql.append(" , 'Y' RETRIEVE_YN                                                                  ");
		sql.append(" , A.START_DATE OLD_START_DATE                                                      ");
		sql.append(" , CASE WHEN A.END_DATE < DATE_FORMAT(SYSDATE(), '%Y-%m-%d') THEN 'Y'               ");
		sql.append(" ELSE 'N' END END_YN                                                                ");
		sql.append(" FROM BAS0212 B                                                                     ");
		sql.append(" , OUT0105 A                                                                        ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                                      ");
		sql.append(" AND A.BUNHO = :patientCode                                                         ");
		sql.append(" AND A.GONGBI_CODE = B.GONGBI_CODE  AND B.LANGUAGE = :language                      ");
		sql.append(" AND DATE_FORMAT(SYSDATE(), '%Y-%m-%d') BETWEEN B.START_DATE AND B.END_DATE         ");
		sql.append(" ORDER BY A.GONGBI_CODE																");


		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("language", language);
		List<NuroOUT0101U02GridGongbiListInfo> list = new JpaResultMapper().list(query,NuroOUT0101U02GridGongbiListInfo.class);
		return list;
	}

	@Override
	public List<NuroOUT0101U02GridPatientInfo> getNuroOUT0101U02GridPatientInfo(String hospCode, String patientCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("   SELECT A.BUNHO BUNHO															                  	   ");
		sql.append("    , A.SUNAME SUNAME	                                                                               ");
		sql.append("    , A.SEX SEX                                                                                        ");
		sql.append("    , A.BIRTH BIRTH                                                                                    ");
		sql.append("    , A.ZIP_CODE1 ZIP_CODE1                                                                            ");
		sql.append("    , A.ZIP_CODE2 ZIP_CODE2                                                                            ");
		sql.append("    , A.ADDRESS1 ADDRESS1                                                                              ");
		sql.append("    , A.ADDRESS2 ADDRESS2                                                                              ");
		sql.append("    , A.TEL TEL                                                                                        ");
		sql.append("    , A.TEL1 TEL1                                                                                      ");
		sql.append("    , A.GUBUN GUBUN                                                                                    ");
		sql.append("    , A.TEL_HP TEL_HP                                                                                  ");
		sql.append("    , A.EMAIL EMAIL                                                                                    ");
		sql.append("    , FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, DATE_FORMAT(SYSDATE(), '%Y-%m-%d'),:hospCode) GUBUN_NAME         ");
		sql.append("    ,''  DONG_NAME                                                                                     "); // NULL
		sql.append("    , A.SUNAME2                                                                                        ");
		sql.append("    , FN_BAS_LOAD_AGE(SYSDATE(), A.BIRTH, ' ')                                                         ");
		sql.append("    , A.TEL_GUBUN                                                                                      ");
		sql.append("    , A.TEL_GUBUN2                                                                                     ");
		sql.append("    , A.TEL_GUBUN3                                                                                     ");
		sql.append("    , IFNULL(A.DELETE_YN, 'N')                                                                         ");
		sql.append("    , A.PACE_MAKER_YN                                                                                  ");
		sql.append("    , A.SELF_PACE_MAKER                                                                                ");
		sql.append("    , A.BUNHO_TYPE BUNHO_TYPE                                                                          ");
		sql.append("    , 'Y' RETRIEVE_YN                                                                                  ");
		sql.append("    , A.BUNHO_EXT BUNHO_EXT                                                                            ");
		sql.append("    , B.CODE CODE                                                                            ");
		sql.append("    FROM OUT0101 A LEFT JOIN BAS0102 B ON B.CODE = A.BILLING_TYPE AND B.CODE_TYPE = 'BILLING_TYPE'    ");
		sql.append("   AND B.HOSP_CODE = :hospCode   AND B.LANGUAGE = :language                                            ");
		sql.append("    WHERE A.HOSP_CODE = :hospCode                                                                      ");
		sql.append("    AND A.BUNHO = :patientCode                                                                         ");
				
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("patientCode", patientCode);
		
		List<NuroOUT0101U02GridPatientInfo> list = new JpaResultMapper().list(query,NuroOUT0101U02GridPatientInfo.class);
		return list;
	}

	@Override
	public List<NuroOUT0101U02LayDupPatientInfo> getNuroOUT0101U02LayDupPatientInfo(
			String hospCode,String language, String suname2, String birth, String sex,String codeType) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.BUNHO																															");
		sql.append("     , A.SUNAME                                                                                                                         ");
		sql.append("     , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.BIRTH,:hospCode, :language)                                                                  ");
		sql.append("     , B.CODE_NAME                                                                                                                      ");
		sql.append("  FROM BAS0102 B LEFT OUTER JOIN OUT0101 A ON B.HOSP_CODE = A.HOSP_CODE    AND A.SEX          = B.CODE   AND B.CODE_TYPE = :codeType	");
		sql.append(" WHERE A.HOSP_CODE    = :hospCode                                                                                                       ");
		sql.append("   AND A.SUNAME2      = :suname2                                                                                                        ");
		sql.append("   AND A.BIRTH        = STR_TO_DATE(:birth, '%m/%d/%Y')                                                                                 ");
		sql.append("   AND A.SEX          = :sex                                                                                                            ");
		sql.append(" ORDER BY A.BUNHO                                                                                                                       ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("suname2", suname2);
		query.setParameter("birth", birth);
		query.setParameter("sex", sex);
		query.setParameter("codeType", codeType);
		
		List<NuroOUT0101U02LayDupPatientInfo> list = new JpaResultMapper().list(query,NuroOUT0101U02LayDupPatientInfo.class);
		return list;
	}
	
	public List<NuroOUT0101U02GetInsuranceCode> getNuroOUT0101U02GetInsuranceCode(String lawNo, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT GONGBI_CODE									  ");	
		sql.append(" FROM BAS0212                                         ");
		sql.append(" WHERE LAW_NO    = :lawNo AND LANGUAGE = :language    ");
		sql.append("  AND SYSDATE() BETWEEN START_DATE AND END_DATE       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("lawNo", lawNo);
		query.setParameter("language", language);
		
		List<NuroOUT0101U02GetInsuranceCode> list = new JpaResultMapper().list(query, NuroOUT0101U02GetInsuranceCode.class);
		return list;
	}
	@Override
	public String getNuroOUT0101U02GetBirthDay(String sysDate, String birth) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_AGE(STR_TO_DATE(:sysDate,'%Y/%m/%d'), STR_TO_DATE(:birth,'%Y/%m/%d'), ' ') ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("sysDate", sysDate);
		query.setParameter("birth", birth);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	public String getNuroOUT0101U02CheckExistsX(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT 'Y'														");
		sql.append(" FROM OUT0101 A                                                 ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode AND A.BUNHO     = :bunho         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}

	
	
	@Override
	public List<InjsINJ1001U01TempListItemInfo> getInjsINJ1001U01TempListItemInfo (String hospitalCode, String language,
			String bunho,	String doctor, Date reserDate, Date jubsuDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CONCAT (IFNULL(J.GROUP_SER,'0'), IFNULL(J.MIX_GROUP,G.HANGMOG_CODE)) SERIAL_V                                                                 ");
		sql.append("  ,H.BUNHO BUNHO                                                                                                                                     ");
		sql.append("  ,F.SUNAME SUNAME                                                                                                                                   ");
		sql.append("  ,F.SUNAME2 SUNAME2                                                                                                                                 ");
		sql.append("  ,FN_BAS_LOAD_AGE(H.ORDER_DATE, F.BIRTH, '') AGE                                                                                                    ");
		sql.append("  ,F.SEX SEX                                                                                                                                         ");
		sql.append("  ,H.ORDER_DATE ORDER_DATE                                                                                                                           ");
		sql.append("  ,IFNULL(J.JUBSU_DATE, STR_TO_DATE(:jubsu_date, '%Y/%m/%d')) JUBSU_DATE                                                                             ");
		sql.append("  ,MAX(G.DV) CNT                                                                                                                                     ");
		sql.append("  ,G.SURYANG SURYANG                                                                                                                                 ");
		sql.append("  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', G.ORD_DANUI, :hospitalCode, :language) DANUI_NAME                                                              ");
		sql.append("  ,MAX(CONCAT (G.BOGYONG_CODE, ' ', FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(G.JUSA_SPD_GUBUN,'0'), :hospitalCode, :language) )) BOGYONG_NAME   ");
		sql.append("  ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(G.JUSA,'0'), :hospitalCode, :language) JUSA_NAME                                                              ");
		sql.append("  ,TRIM(FN_JAERYO_NAME(K.JAERYO_CODE, :hospitalCode)) JAERYO_NAME                                                                                    ");
		sql.append("  ,G.ORDER_REMARK ORDER_REMARK                                                                                                                       ");
		sql.append("  ,'A' DATA_GUBUN                                                                                                                                    ");
		sql.append("  ,FN_BAS_TO_JAPAN_DATE_CONVERT('5', F.BIRTH, :hospitalCode, :language) BIRTH                                                                        ");
		sql.append("  ,FN_BAS_LOAD_DOCTOR_NAME(H.DOCTOR, H.ORDER_DATE, :hospitalCode) DOCTOR_NAME                                                                        ");
		sql.append("  ,FN_BAS_LOAD_GWA_NAME(H.GWA, H.ORDER_DATE, :hospitalCode, :language) GWA_NAME                                                                      ");
		sql.append("  FROM OUT0101 F                                                                                                                                     ");
		sql.append("  INNER JOIN OCS0103 K ON K.HOSP_CODE = F.HOSP_CODE                                                                                                  ");
		sql.append("  INNER JOIN OCS1003 G ON G.HOSP_CODE = F.HOSP_CODE AND K.HANGMOG_CODE = G.HANGMOG_CODE                                                              ");
		sql.append("  INNER JOIN INJ1002 J ON J.HOSP_CODE = F.HOSP_CODE AND IFNULL(J.DC_YN,'N') = 'N'                                                                    ");
		sql.append("  INNER JOIN INJ1001 H  ON H.HOSP_CODE = F.HOSP_CODE AND F.BUNHO = H.BUNHO AND H.NALSU > 0 AND J.FKINJ1001 = H.PKINJ1001                             ");
		sql.append("  WHERE F.HOSP_CODE = :hospitalCode                                                                                                                  ");
		if (!StringUtils.isEmpty(bunho)) {
			sql.append("  AND H.BUNHO = :bunho                                                                                                                           ");
		}
		if (!StringUtils.isEmpty(doctor)) {
			sql.append("  AND H.DOCTOR = :doctor                                                                                                                         ");
		}
		if (reserDate != null) {
			sql.append("  AND J.RESER_DATE = :reser_date			                                                                                                     ");
		}
		if (jubsuDate != null) {
			sql.append("  AND IFNULL(:jubsu_date, SYSDATE()) BETWEEN K.START_DATE AND K.END_DATE                                              						     ");
		}
		sql.append("  AND G.PKOCS1003 = H.FKOCS1003                                                                                                                      ");
		sql.append("  GROUP BY CONCAT (IFNULL(J.GROUP_SER,'0'), IFNULL(J.MIX_GROUP,G.HANGMOG_CODE))                                                                      ");
		sql.append("  , H.BUNHO                                                                                                                                          ");
		sql.append("  ,F.SUNAME                                                                                                                                          ");
		sql.append("  ,F.SUNAME2                                                                                                                                         ");
		sql.append("  ,FN_BAS_LOAD_AGE(H.ORDER_DATE, F.BIRTH, '')                                                                                                        ");
		sql.append("  ,F.SEX                                                                                                                                             ");
		sql.append("  ,H.ORDER_DATE                                                                                                                                      ");
		sql.append("  ,J.JUBSU_DATE                                                                                                                                      ");
		sql.append("  ,G.DV                                                                                                                                              ");
		sql.append("  ,G.SURYANG                                                                                                                                         ");
		sql.append("  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', G.ORD_DANUI, :hospitalCode, :language)                                                                         ");
		sql.append("  ,TRIM(FN_JAERYO_NAME(K.JAERYO_CODE, :hospitalCode))                                                                                                ");
		sql.append("  ,FN_OCS_LOAD_CODE_NAME('JUSA',IFNULL(G.JUSA,'0'), :hospitalCode, :language)                                                                        ");
		sql.append("  ,G.ORDER_REMARK                                                                                                                                    ");
		sql.append("  ,CONCAT (IFNULL(J.GROUP_SER,'0'), IFNULL(J.MIX_GROUP,G.HANGMOG_CODE) )                                                                             ");
		sql.append("  ,F.BIRTH                                                                                                                                           ");
		sql.append("  ,FN_BAS_LOAD_DOCTOR_NAME(H.DOCTOR, H.ORDER_DATE, :hospitalCode)                                                                                    ");
		sql.append("  ,FN_BAS_LOAD_GWA_NAME(H.GWA, H.ORDER_DATE, :hospitalCode, :language)                                                                               ");
		sql.append("  ,CONCAT (LTRIM(LPAD(G.GROUP_SER, 4,'0')), IFNULL(G.MIX_GROUP, ' '),                                                                                ");
		sql.append("  LTRIM(LPAD(IF(G.BOM_OCCUR_YN = 'Y', G.SEQ + 100, G.SEQ), 4, '0')),                                                                                 ");
		sql.append("  LTRIM(LPAD(G.PKOCS1003,10, '0')) )                                                                                                                 ");
		sql.append("  ORDER BY CONCAT(LTRIM(LPAD(G.GROUP_SER, 4,'0')), IFNULL(G.MIX_GROUP, ' '),                                                                         ");
		sql.append("  LTRIM(LPAD(IF(G.BOM_OCCUR_YN = 'Y', G.SEQ + 100, G.SEQ) , 4,'0')),LTRIM(LPAD(G.PKOCS1003, 10, '0')) )                                              ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		if (!StringUtils.isEmpty(bunho)) {
			query.setParameter("bunho", bunho);
		}
		if (!StringUtils.isEmpty(doctor)) {
			query.setParameter("doctor", doctor);
		}
		if (reserDate != null) {
			query.setParameter("reser_date", reserDate);
		}
		if (jubsuDate != null) {
			query.setParameter("jubsu_date", jubsuDate);
		}
		
		List<InjsINJ1001U01TempListItemInfo> list = new JpaResultMapper().list(query,InjsINJ1001U01TempListItemInfo.class);
		return list;
	}
	

	@Override
	public List<OCS0503Q00LoadConsultInfo> getOCS0503Q00GrdConsultList(String hospCode, String language, String doctor,
			String fromDate, String toDate, String answerYn, String ioGubun, String gwaConsultYn, String naewonYn){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT * FROM                                                                                                                      ");
		sql.append(" (SELECT 'O'                                                    IO_GUBUN            ,                                               ");
		sql.append("        IFNULL(C.CONFIRM_YN, 'N')                              ANSWER_YN           ,                                                ");
		sql.append("        IF(C.CONSULT_DOCTOR IS NULL,'Y','N')                  GWA_CONSULT_YN      ,                                                 ");
		sql.append("        C.REQ_DATE                                             NAEWON_DATE         ,                                                ");
		sql.append("        A.JUBSU_TIME                                           JINRYO_TIME         ,                                                ");
		sql.append("        C.BUNHO                                                BUNHO               ,                                                ");
		sql.append("        B.SUNAME                                               SUNAME              ,                                                ");
		sql.append("        B.SUNAME2                                              SUNAME2             ,                                                ");
		sql.append("        ' '                                                    HO_DONG             ,                                                ");
		sql.append("        FN_OCS_LOAD_SEX_AGE(C.BUNHO, C.REQ_DATE, :f_hosp_code) SEX_AGE             ,                                                ");
		sql.append("        FN_BAS_LOAD_GUBUN_NAME('01', C.REQ_DATE, :f_hosp_code) GUBUN_NAME          ,                                                ");
		sql.append("        A.GWA                                                  GWA                 ,                                                ");
		sql.append("        A.DOCTOR                                               DOCTOR              ,                                                ");
		sql.append("        A.NAEWON_TYPE                                          NAEWON_TYPE         ,                                                ");
		sql.append("        A.JUBSU_NO                                             JUBSU_NO            ,                                                ");
		sql.append("        A.CHOJAE                                               CHOJAE              ,                                                ");
		sql.append("        FN_BAS_LOAD_CODE_NAME('CHOJAE',A.CHOJAE,:f_hosp_code,:f_language)              CHOJAE_NAME         ,                        ");
		sql.append("        A.PKOUT1001                                            PK_NAEWON           ,                                                ");
		sql.append("        IF(IFNULL(A.NAEWON_YN,'N') = 'Y' OR IFNULL(A.NAEWON_YN,'N') = 'E','Y','N')       NAEWON_YN           ,                      ");
		sql.append("        C.REQ_DATE                                             REQ_DATE            ,                                                ");
		sql.append("        C.REQ_GWA                                              REQ_GWA             ,                                                ");
		sql.append("        C.REQ_DOCTOR                                           REQ_DOCTOR          ,                                                ");
		sql.append("        C.CONSULT_GWA                                          CONSULT_GWA         ,                                                ");
		sql.append("        C.CONSULT_DOCTOR                                       CONSULT_DOCTOR      ,                                                ");
		sql.append("        C.IN_OUT_GUBUN                                         REQ_IO_GUBUN        ,                                                ");
		sql.append("        FN_BAS_LOAD_GWA_NAME(C.CONSULT_GWA, C.REQ_DATE,:f_hosp_code,:f_language)        GWA_NAME            ,                       ");
		sql.append("        FN_BAS_LOAD_DOCTOR_NAME(C.CONSULT_DOCTOR, C.REQ_DATE,:f_hosp_code)  DOCTOR_NAME         ,                                   ");
		sql.append("        IF(TRIM(C.ANSWER) IS NULL,'Y','N')                     ANSWER_UPD_YN       ,                                                ");
		sql.append("        C.APP_DATE                                             APP_DATE            ,                                                ");
		sql.append("        C.PKOCS0503                                            PKOCS0503           ,                                                ");
		sql.append("        FN_OCSO_ORDER_END_YN(A.HOSP_CODE, A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, A.NAEWON_TYPE, A.JUBSU_NO) ORDER_END_YN          ");
		sql.append("   FROM OUT0101 B,                                                                                                                  ");
		sql.append("        OUT1001 A RIGHT OUTER JOIN OCS0503 C ON A.HOSP_CODE = C.HOSP_CODE AND A.PKOUT1001 = C.CONSULT_FKOUT1001,                    ");
		sql.append("        BAS0270 D                                                                                                                   ");
		sql.append("  WHERE C.HOSP_CODE         = :f_hosp_code                                                                                          ");
		sql.append("    AND C.REQ_DATE BETWEEN DATE_FORMAT(:f_from_date,'%Y/%m/%d') AND DATE_FORMAT(:f_to_date,'%Y/%m/%d')                              ");
		sql.append("    AND C.REQ_DOCTOR        = :f_doctor                                                                                             ");
		sql.append("    AND C.IN_OUT_GUBUN      = 'O'                                                                                                   ");
		sql.append("    AND B.HOSP_CODE         = C.HOSP_CODE                                                                                           ");
		sql.append("    AND B.BUNHO             = C.BUNHO                                                                                               ");
		sql.append("    AND NOT EXISTS ( SELECT 'X'                                                                                                     ");
		sql.append("                       FROM OCS0503 F                                                                                               ");
		sql.append("                            ,RES1001 G                                                                                              ");
		sql.append("                      WHERE F.HOSP_CODE         = C.HOSP_CODE                                                                       ");
		sql.append("                        AND F.PKOCS0503         = C.PKOCS0503 )                                                                     ");
		sql.append("    AND D.HOSP_CODE         = C.HOSP_CODE                                                                                           ");
		sql.append("    AND D.DOCTOR            = C.REQ_DOCTOR                                                                                          ");
		sql.append("    AND C.REQ_DATE BETWEEN D.START_DATE AND IFNULL(D.END_DATE, '9998/12/31')                                                        ");
		sql.append(" UNION ALL                                                                                                                          ");
		sql.append(" SELECT 'I'                                                    IO_GUBUN        ,                                                    ");
		sql.append("        IFNULL(C.CONFIRM_YN, 'N')                              ANSWER_YN       ,                                                    ");
		sql.append("        IF(C.CONSULT_DOCTOR IS NULL,'Y','N')                   GWA_CONSULT_YN  ,                                                    ");
		sql.append("        C.REQ_DATE                                             NAEWON_DATE     ,                                                    ");
		sql.append("        DATE_FORMAT(C.SYS_DATE,'%H%i')                         JINRYO_TIME     ,                                                    ");
		sql.append("        C.BUNHO                                                BUNHO           ,                                                    ");
		sql.append("        B.SUNAME                                               SUNAME          ,                                                    ");
		sql.append("        B.SUNAME2                                              SUNAME2         ,                                                    ");
		sql.append("        'OUT'                                                  HO_DONG         ,                                                    ");
		sql.append("        FN_OCS_LOAD_SEX_AGE(C.BUNHO, C.REQ_DATE,:f_hosp_code)               SEX_AGE         ,                                       ");
		sql.append("        FN_BAS_LOAD_GUBUN_NAME('01', C.REQ_DATE,:f_hosp_code)               GUBUN_NAME      ,                                       ");
		sql.append("        A.GWA                                                  GWA             ,                                                    ");
		sql.append("        A.DOCTOR                                               DOCTOR          ,                                                    ");
		sql.append("        A.IPWON_TYPE                                           NAEWON_TYPE     ,                                                    ");
		sql.append("        0                                                      JUBSU_NO        ,                                                    ");
		sql.append("        A.CHOJAE                                               CHOJAE          ,                                                    ");
		sql.append("        FN_BAS_LOAD_CODE_NAME('CHOJAE',A.CHOJAE,:f_hosp_code,:f_language)               CHOJAE_NAME     ,                           ");
		sql.append("        A.PKINP1001                                            PK_NAEWON       ,                                                    ");
		sql.append("        ' '                                                    NAEWON_YN       ,                                                    ");
		sql.append("        C.REQ_DATE                                             REQ_DATE        ,                                                    ");
		sql.append("        C.REQ_GWA                                              REQ_GWA         ,                                                    ");
		sql.append("        C.REQ_DOCTOR                                           REQ_DOCTOR      ,                                                    ");
		sql.append("        C.CONSULT_GWA                                          CONSULT_GWA     ,                                                    ");
		sql.append("        C.CONSULT_DOCTOR                                       CONSULT_DOCTOR  ,                                                    ");
		sql.append("        C.IN_OUT_GUBUN                                         REQ_IO_GUBUN    ,                                                    ");
		sql.append("        FN_BAS_LOAD_GWA_NAME(C.CONSULT_GWA, C.REQ_DATE,:f_hosp_code,:f_language)        GWA_NAME        ,                           ");
		sql.append("        FN_BAS_LOAD_DOCTOR_NAME(C.CONSULT_DOCTOR, C.REQ_DATE,:f_hosp_code)   DOCTOR_NAME     ,                                      ");
		sql.append("        IF(TRIM(C.ANSWER) IS NULL,'Y','N')                    ANSWER_UPD_YN   ,                                                     ");
		sql.append("        C.APP_DATE                                             APP_DATE        ,                                                    ");
		sql.append("        C.PKOCS0503                                            PKOCS0503       ,                                                    ");
		sql.append("        'N'                                                    ORDER_END_YN                                                         ");
		sql.append("   FROM                                                                                                                             ");
		sql.append("        OUT0101 B,                                                                                                                  ");
		sql.append("        INP1001 A RIGHT OUTER JOIN OCS0503 C ON A.HOSP_CODE = C.HOSP_CODE AND A.PKINP1001 = C.FKINP1001,                            ");
		sql.append("        BAS0270 D                                                                                                                   ");
		sql.append("  WHERE C.HOSP_CODE         = :f_hosp_code                                                                                          ");
		sql.append("    AND C.REQ_DATE          BETWEEN DATE_FORMAT(:f_from_date,'%Y/%m/%d') AND DATE_FORMAT(:f_to_date,'%Y/%m/%d')                     ");
		sql.append("    AND C.IN_OUT_GUBUN      = 'I'                                                                                                   ");
		sql.append("    AND C.REQ_DOCTOR        = :f_doctor                                                                                             ");
		sql.append("    AND B.HOSP_CODE         = C.HOSP_CODE                                                                                           ");
		sql.append("    AND B.BUNHO             = C.BUNHO                                                                                               ");
		sql.append("    AND D.HOSP_CODE         = C.HOSP_CODE                                                                                           ");
		sql.append("    AND D.DOCTOR            = C.REQ_DOCTOR                                                                                          ");
		sql.append("    AND C.REQ_DATE BETWEEN D.START_DATE AND IFNULL(D.END_DATE, '9998/12/31')                                                        ");
		sql.append("   ORDER BY 5 DESC) A                                                                                                               ");
		sql.append("   WHERE 1 = 1                                                                                                                      ");
		if (!StringUtils.isEmpty(answerYn)) {
			sql.append("   AND A.ANSWER_YN = :f_answer_yn                                                                                               ");
		}
		if (!StringUtils.isEmpty(ioGubun)) {
			sql.append("   AND A.IO_GUBUN = :f_io_gubun                                                                                                 ");
		}
		if (!StringUtils.isEmpty(gwaConsultYn)) {
			sql.append("    AND A.GWA_CONSULT_YN = :f_gwa_consult_yn                                                                                    ");
		}
		if (!StringUtils.isEmpty(naewonYn)) {
			sql.append("   AND A.NAEWON_YN  = :f_naewon_yn                                                                                              ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		if (!StringUtils.isEmpty(answerYn)) {
			query.setParameter("f_answer_yn", answerYn);
		}
		if (!StringUtils.isEmpty(ioGubun)) {
			query.setParameter("f_io_gubun", ioGubun);
		}
		if (!StringUtils.isEmpty(gwaConsultYn)) {
			query.setParameter("f_gwa_consult_yn", gwaConsultYn);
		}
		if (!StringUtils.isEmpty(naewonYn)) {
			query.setParameter("f_naewon_yn", naewonYn);
		}
		
		List<OCS0503Q00LoadConsultInfo> list = new JpaResultMapper().list(query,OCS0503Q00LoadConsultInfo.class);
		return list;
	}
	
	@Override
	public List<OCS0503Q00LoadConsultInfo> getOcsaOCS0503Q00GrdRequestList(String hospCode, String language, String doctor,
			String fromDate, String toDate, String answerYn, String ioGubun, String gwaConsultYn, String naewonYn){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT * FROM                                                                                                                   ");
		sql.append("(SELECT 'O'                                                    IO_GUBUN            ,                                            ");
		sql.append("       IFNULL(C.CONFIRM_YN, 'N')                              ANSWER_YN           ,                                             ");
		sql.append("       IF(C.CONSULT_DOCTOR IS NULL,'Y','N')                  GWA_CONSULT_YN      ,                                              ");
		sql.append("       C.REQ_DATE                                             NAEWON_DATE         ,                                             ");
		sql.append("       A.JUBSU_TIME                                           JINRYO_TIME         ,                                             ");
		sql.append("       C.BUNHO                                                BUNHO               ,                                             ");
		sql.append("       B.SUNAME                                               SUNAME              ,                                             ");
		sql.append("       B.SUNAME2                                              SUNAME2             ,                                             ");
		sql.append("       ' '                                                    HO_DONG             ,                                             ");
		sql.append("       FN_OCS_LOAD_SEX_AGE(C.BUNHO, C.REQ_DATE, :f_hosp_code) SEX_AGE             ,                                             ");
		sql.append("       FN_BAS_LOAD_GUBUN_NAME('01', C.REQ_DATE, :f_hosp_code) GUBUN_NAME          ,                                             ");
		sql.append("       A.GWA                                                  GWA                 ,                                             ");
		sql.append("       A.DOCTOR                                               DOCTOR              ,                                             ");
		sql.append("       A.NAEWON_TYPE                                          NAEWON_TYPE         ,                                             ");
		sql.append("       A.JUBSU_NO                                             JUBSU_NO            ,                                             ");
		sql.append("       A.CHOJAE                                               CHOJAE              ,                                             ");
		sql.append("       FN_BAS_LOAD_CODE_NAME('CHOJAE',A.CHOJAE,:f_hosp_code,:f_language)              CHOJAE_NAME         ,                     ");
		sql.append("       A.PKOUT1001                                            PK_NAEWON           ,                                             ");
		sql.append("       IF(IFNULL(A.NAEWON_YN,'N') = 'Y' OR IFNULL(A.NAEWON_YN,'N') = 'E','Y','N')       NAEWON_YN           ,                   ");
		sql.append("       C.REQ_DATE                                             REQ_DATE            ,                                             ");
		sql.append("       C.REQ_GWA                                              REQ_GWA             ,                                             ");
		sql.append("       C.REQ_DOCTOR                                           REQ_DOCTOR          ,                                             ");
		sql.append("       C.CONSULT_GWA                                          CONSULT_GWA         ,                                             ");
		sql.append("       C.CONSULT_DOCTOR                                       CONSULT_DOCTOR      ,                                             ");
		sql.append("       C.IN_OUT_GUBUN                                         REQ_IO_GUBUN        ,                                             ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(C.CONSULT_GWA, C.REQ_DATE,:f_hosp_code,:f_language)        GWA_NAME            ,                    ");
		sql.append("       FN_BAS_LOAD_DOCTOR_NAME(C.CONSULT_DOCTOR, C.REQ_DATE,:f_hosp_code)  DOCTOR_NAME         ,                                ");
		sql.append("       IF(TRIM(C.ANSWER) IS NULL,'Y','N')                     ANSWER_UPD_YN       ,                                             ");
		sql.append("       C.APP_DATE                                             APP_DATE            ,                                             ");
		sql.append("       C.PKOCS0503                                            PKOCS0503           ,                                             ");
		sql.append("        FN_OCSO_ORDER_END_YN(A.HOSP_CODE, A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, A.NAEWON_TYPE, A.JUBSU_NO) ORDER_END_YN      ");
		sql.append("  FROM                                                                                                                          ");
		sql.append("       OUT0101 B,                                                                                                               ");
		sql.append("       OUT1001 A RIGHT OUTER JOIN OCS0503 C ON A.HOSP_CODE = C.HOSP_CODE AND A.PKOUT1001 = C.CONSULT_FKOUT1001,                 ");
		sql.append("       BAS0270 D                                                                                                                ");
		sql.append(" WHERE C.HOSP_CODE         = :f_hosp_code                                                                                       ");
		sql.append("   AND C.REQ_DATE BETWEEN DATE_FORMAT(:f_from_date,'%Y/%m/%d') AND DATE_FORMAT(:f_to_date,'%Y/%m/%d')                           ");
		sql.append("   AND C.REQ_DOCTOR        = :f_doctor                                                                                          ");
		sql.append("   AND C.IN_OUT_GUBUN      = 'O'                                                                                                ");
		sql.append("   AND B.HOSP_CODE         = C.HOSP_CODE                                                                                        ");
		sql.append("   AND B.BUNHO             = C.BUNHO                                                                                            ");
		sql.append("   AND NOT EXISTS ( SELECT 'X'                                                                                                  ");
		sql.append("                      FROM OCS0503 F                                                                                            ");
		sql.append("                           ,RES1001 G                                                                                           ");
		sql.append("                     WHERE F.HOSP_CODE         = C.HOSP_CODE                                                                    ");
		sql.append("                       AND F.PKOCS0503         = C.PKOCS0503                                                                    ");
		sql.append("                   )                                                                                                            ");
		sql.append("   AND D.HOSP_CODE         = C.HOSP_CODE                                                                                        ");
		sql.append("   AND D.DOCTOR            = C.REQ_DOCTOR                                                                                       ");
		sql.append("   AND C.REQ_DATE BETWEEN D.START_DATE AND IFNULL(D.END_DATE, '9998/12/31')                                                     ");
		sql.append("UNION ALL                                                                                                                       ");
		sql.append("SELECT 'I'                                                    IO_GUBUN        ,                                                 ");
		sql.append("       IFNULL(C.CONFIRM_YN, 'N')                              ANSWER_YN       ,                                                 ");
		sql.append("       IF(C.CONSULT_DOCTOR IS NULL,'Y','N')                   GWA_CONSULT_YN  ,                                                 ");
		sql.append("       C.REQ_DATE                                             NAEWON_DATE     ,                                                 ");
		sql.append("       DATE_FORMAT(C.SYS_DATE,'%H%i')                         JINRYO_TIME     ,                                                 ");
		sql.append("       C.BUNHO                                                BUNHO           ,                                                 ");
		sql.append("       B.SUNAME                                               SUNAME          ,                                                 ");
		sql.append("       B.SUNAME2                                              SUNAME2         ,                                                 ");
		sql.append("       'OUT'                                                  HO_DONG         ,                                                 ");
		sql.append("       FN_OCS_LOAD_SEX_AGE(C.BUNHO, C.REQ_DATE,:f_hosp_code)               SEX_AGE         ,                                    ");
		sql.append("       FN_BAS_LOAD_GUBUN_NAME('01', C.REQ_DATE,:f_hosp_code)               GUBUN_NAME      ,                                    ");
		sql.append("       A.GWA                                                  GWA             ,                                                 ");
		sql.append("       A.DOCTOR                                               DOCTOR          ,                                                 ");
		sql.append("       A.IPWON_TYPE                                           NAEWON_TYPE     ,                                                 ");
		sql.append("       0                                                      JUBSU_NO        ,                                                 ");
		sql.append("       A.CHOJAE                                               CHOJAE          ,                                                 ");
		sql.append("       FN_BAS_LOAD_CODE_NAME('CHOJAE',A.CHOJAE,:f_hosp_code,:f_language)               CHOJAE_NAME     ,                        ");
		sql.append("       A.PKINP1001                                            PK_NAEWON       ,                                                 ");
		sql.append("       ' '                                                    NAEWON_YN       ,                                                 ");
		sql.append("       C.REQ_DATE                                             REQ_DATE        ,                                                 ");
		sql.append("       C.REQ_GWA                                              REQ_GWA         ,                                                 ");
		sql.append("       C.REQ_DOCTOR                                           REQ_DOCTOR      ,                                                 ");
		sql.append("       C.CONSULT_GWA                                          CONSULT_GWA     ,                                                 ");
		sql.append("       C.CONSULT_DOCTOR                                       CONSULT_DOCTOR  ,                                                 ");
		sql.append("       C.IN_OUT_GUBUN                                         REQ_IO_GUBUN    ,                                                 ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(C.CONSULT_GWA, C.REQ_DATE,:f_hosp_code,:f_language)        GWA_NAME        ,                        ");
		sql.append("       FN_BAS_LOAD_DOCTOR_NAME(C.CONSULT_DOCTOR, C.REQ_DATE,:f_hosp_code)   DOCTOR_NAME     ,                                   ");
		sql.append("       IF(TRIM(C.ANSWER) IS NULL,'Y','N')                    ANSWER_UPD_YN   ,                                                  ");
		sql.append("       C.APP_DATE                                             APP_DATE        ,                                                 ");
		sql.append("       C.PKOCS0503                                            PKOCS0503       ,                                                 ");
		sql.append("       'N'                                                    ORDER_END_YN                                                      ");
		sql.append("  FROM                                                                                                                          ");
		sql.append("       OUT0101 B,                                                                                                               ");
		sql.append("       INP1001 A RIGHT OUTER JOIN OCS0503 C ON A.HOSP_CODE = C.HOSP_CODE AND A.PKINP1001 = C.FKINP1001,                         ");
		sql.append("       BAS0270 D                                                                                                                ");
		sql.append(" WHERE C.HOSP_CODE         = :f_hosp_code                                                                                       ");
		sql.append("   AND C.REQ_DATE          BETWEEN DATE_FORMAT(:f_from_date,'%Y/%m/%d') AND DATE_FORMAT(:f_to_date,'%Y/%m/%d')                  ");
		sql.append("   AND C.IN_OUT_GUBUN      = 'I'                                                                                                ");
		sql.append("   AND C.REQ_DOCTOR        = :f_doctor                                                                                          ");
		sql.append("   AND B.HOSP_CODE         = C.HOSP_CODE                                                                                        ");
		sql.append("   AND B.BUNHO             = C.BUNHO                                                                                            ");
		sql.append("                                                                                                                                ");
		sql.append("   AND D.HOSP_CODE         = C.HOSP_CODE                                                                                        ");
		sql.append("   AND D.DOCTOR            = C.REQ_DOCTOR                                                                                       ");
		sql.append("   AND C.REQ_DATE BETWEEN D.START_DATE AND IFNULL(D.END_DATE, '9998/12/31')                                                     ");
		sql.append("  ORDER BY 5 DESC) A                                                                                                            ");
		sql.append("  WHERE 1 = 1                                                                                                                   ");

		if (!StringUtils.isEmpty(answerYn)) {
			sql.append("   AND A.ANSWER_YN = :f_answer_yn                                                                                           ");
		}
		if (!StringUtils.isEmpty(ioGubun)) {
			sql.append("   AND A.IO_GUBUN = :f_io_gubun                                                                                             ");
		}
		if (!StringUtils.isEmpty(gwaConsultYn)) {
			sql.append("    AND A.GWA_CONSULT_YN = :f_gwa_consult_yn                                                                                ");
		}
		if (!StringUtils.isEmpty(naewonYn)) {
			sql.append("   AND A.NAEWON_YN  = :f_naewon_yn                                                                                          ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		if (!StringUtils.isEmpty(answerYn)) {
			query.setParameter("f_answer_yn", answerYn);
		}
		if (!StringUtils.isEmpty(ioGubun)) {
			query.setParameter("f_io_gubun", ioGubun);
		}
		if (!StringUtils.isEmpty(gwaConsultYn)) {
			query.setParameter("f_gwa_consult_yn", gwaConsultYn);
		}
		if (!StringUtils.isEmpty(naewonYn)) {
			query.setParameter("f_naewon_yn", naewonYn);
		}
		
		List<OCS0503Q00LoadConsultInfo> list = new JpaResultMapper().list(query,OCS0503Q00LoadConsultInfo.class);
		return list;
	}
	
	@Override
	public DrgsDRG5100P01LoadMakayJungboInfo getDrgsDRG5100P01LoadMakayJungboInfo(String hospCode, String language,
			String ioGubun, Date jubsuDate, Double drgBunho){
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_LOAD_MAKAY_JUNGBO");
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DRG_BUNHO", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_DOCTOR_NAME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_LICENCE", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ADDRESS1", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ADDRESS2", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_JUBSU_DATE", jubsuDate);
		query.setParameter("I_DRG_BUNHO", drgBunho);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		
		query.execute();
		DrgsDRG5100P01LoadMakayJungboInfo result = new DrgsDRG5100P01LoadMakayJungboInfo((String)query.getOutputParameterValue("IO_DOCTOR_NAME"),
				(String)query.getOutputParameterValue("IO_LICENCE"),
				(String)query.getOutputParameterValue("IO_ADDRESS1"), 
				(String)query.getOutputParameterValue("IO_ADDRESS2"));

		return result;
		
	}

	@Override
	public String getNuroOUT0101U02CheckExistsY(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT 'Y'							");
		sql.append("	  FROM OUT0101                              ");
		sql.append("	 WHERE HOSP_CODE = :hospCode                ");
		sql.append("	AND BUNHO     = :bunho  ;                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null; 
	}
	@Override
	public List<CPL3020U00GrdPaListItemInfo> getGrdPaListItem(String hospCode,
			String jundalGubun, String gubun, String fromDate, String toDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT																											");
		sql.append("	       SUBSTR(A.LAB_NO,7,4) LAB_NO  ,                                                                                   ");
		sql.append("	       C.SUNAME                     ,                                                                                   ");
		sql.append("	       A.SPECIMEN_SER               ,                                                                                   ");
		sql.append("	       A.LAB_NO             LAB_SORT,                                                                                   ");
		sql.append("	       A.PART_JUBSU_DATE            ,                                                                                   ");
		sql.append("	       A.JUNDAL_GUBUN               ,                                                                                   "); 
		sql.append("	       :gubun                GUBUN ,                                                                                    "); 
		sql.append("	      FN_CPL_SPECIMEN_SER_RESULT_YN (:hospCode,A.SPECIMEN_SER,:jundalGubun)         RESULT_YN,                          "); 
		sql.append("	      FN_CPL_SPECIMEN_SER_CONFIRM_YN(:hospCode,A.SPECIMEN_SER,:jundalGubun)         CONFIRM_YN                          "); 
		sql.append("	  FROM OUT0101 C,                                                                                                       "); 
		sql.append("	       CPL2010 B,                                                                                                       "); 
		sql.append("	       CPL3010 A                                                                                                        "); 
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                                                                                          "); 
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                                                                        "); 
		sql.append("	   AND C.HOSP_CODE = A.HOSP_CODE                                                                                        "); 
		sql.append("	  AND A.PART_JUBSU_DATE BETWEEN STR_TO_DATE(:fromDate,'%Y/%m/%d') AND STR_TO_DATE(:toDate,'%Y/%m/%d')                   "); 
		sql.append("	   AND A.JUNDAL_GUBUN          = :jundalGubun                                                                           "); 
		sql.append("	   AND B.SPECIMEN_SER = A.SPECIMEN_SER                                                                                  "); 
		sql.append("	   AND ( :gubun = 'Y'                                                                                                   "); 
		sql.append("	    OR   :gubun = 'N' AND FN_CPL_SPECIMEN_SER_CONFIRM_YN(:hospCode,A.SPECIMEN_SER,:jundalGubun) <> 'Y')                 "); 
		sql.append("	   AND C.BUNHO                 = B.BUNHO                                                                                "); 
		sql.append("	 ORDER BY LAB_NO                                                                                                        "); 
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalGubun", jundalGubun);
		query.setParameter("gubun", gubun);
		query.setParameter("fromDate", fromDate);
		query.setParameter("toDate", toDate);
		
		List<CPL3020U00GrdPaListItemInfo> listResult = new JpaResultMapper().list(query, CPL3020U00GrdPaListItemInfo.class);
		return listResult;
	}

	@Override
	public List<CPL0000Q00SelectOUT0101ListItemInfo> getCPL0000Q00SelectOUT0101ListItemInfo(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                             ");
		sql.append("         A.BUNHO                                  BUNHO     ");
		sql.append("       , A.SUNAME                                 SUNAME    ");
		sql.append("       , DATE_FORMAT(A.BIRTH, '%Y/%m/%d')         BIRTH     ");
		sql.append("       , A.SEX                                    SEX       ");
		sql.append("       , FN_BAS_LOAD_AGE(SYSDATE(),A.BIRTH,NULL)  AGE       ");
		sql.append("    FROM OUT0101 A                                          ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                         ");
		sql.append("     AND A.BUNHO     = :f_bunho                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<CPL0000Q00SelectOUT0101ListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00SelectOUT0101ListItemInfo.class);
		return list;
	}

	@Override
	public List<InjsINJ1001FormJusaBedLayPatientItemInfo> getInjsINJ1001FormJusaBedLayPatientItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE,A.CODE,A.CODE_NAME ,B.SUNAME ,B.SEX                                             ");
		sql.append(" FROM  OUT0101 B RIGHT JOIN INJ0102 A ON  B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO  = A.CODE_NAME      ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code AND A.CODE_TYPE    LIKE 'BED%'                                 ");
		sql.append("   AND A.LANGUAGE  = :f_language       																");
		sql.append(" ORDER BY A.CODE_TYPE,CAST(A.CODE AS SIGNED)     													");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<InjsINJ1001FormJusaBedLayPatientItemInfo> listInjsINJ1001FormJusaBedLayPatientItemInfo= new JpaResultMapper().list(query, InjsINJ1001FormJusaBedLayPatientItemInfo.class);
		return listInjsINJ1001FormJusaBedLayPatientItemInfo;
	}

	@Override
	public List<OUT0101Q01GrdPatientListInfo> getOUT0101Q01GrdPatientListInfo(String hospCode, String language, String suname2, String sex,Date birth, String tel, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		//suname2=suname2+"%";
		sex=sex+"%";
		tel="%"+tel;
		sql.append(" SELECT A.BUNHO                                                                             ");
		sql.append("      , A.SUNAME                                                                            ");
		sql.append("      , A.SUNAME2                                                                           ");
		sql.append("      , A.SEX                                                                               ");
		sql.append("      , A.BIRTH                                                                             ");
		sql.append("      , A.ZIP_CODE1                                                                         ");
		sql.append("      , A.ZIP_CODE2                                                                         ");
		sql.append("      , A.ADDRESS1                                                                          ");
		sql.append("      , A.ADDRESS2                                                                          ");
		sql.append("      , CONCAT(IFNULL(A.ADDRESS1,''), ' ' ,IFNULL( A.ADDRESS2,'')) ADDRESS                  ");
		sql.append("      , A.TEL                                                                               ");
		sql.append("      , A.TEL1                                                                              ");
		sql.append("      , A.GUBUN                                                                             ");
		sql.append("      , A.JUBSU_BREAK                                                                       ");
		sql.append("      , A.JUBSU_BREAK_REASON                                                                ");
		sql.append("      , A.DELETE_YN                                                                         ");
		sql.append("      , A.REMARK                                                                            ");
		sql.append("      , A.TEL_HP                                                                            ");
		sql.append("      , A.EMAIL                                                                             ");
		sql.append("      , FN_OUT_LOAD_LAST_NAEWON_DATE(A.BUNHO, '%',:f_hosp_code)                             ");
		sql.append("      , FN_BAS_LOAD_CODE_NAME('SEX_GUBUN', A.SEX,:f_hosp_code,:f_language)                  ");
		sql.append("      ,' ' NO_HEADER                                                                        ");
		sql.append("      , FN_INP_LOAD_JAEWON_HO_DONG(:f_hosp_code, A.BUNHO)      HO_DONG                      ");
		sql.append("      , CONCAT(IFNULL(A.SUNAME2,'') ,IFNULL(A.BUNHO,'')) CONT_KEY                           ");
		sql.append("   FROM OUT0101 A                                                                           ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                                                     ");
		if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
			sql.append("   AND A.SUNAME2 LIKE :f_suname2                                                        ");
		} else {
			sql.append("   AND A.SUNAME LIKE :f_suname2                                                         ");
		}
		sql.append("    AND IFNULL(A.SEX, '%')  LIKE :f_sex                                                     ");
		sql.append("    AND case IFNULL(:f_birth, STR_TO_DATE('9998/12/31','%Y/%m/%d'))                         ");
		sql.append("    when  STR_TO_DATE('9998/12/31','%Y/%m/%d') then STR_TO_DATE('9998/12/31','%Y/%m/%d')    ");
		sql.append("    else A.BIRTH end = IFNULL(:f_birth, STR_TO_DATE('9998/12/31','%Y/%m/%d'))               ");
		sql.append("     AND IFNULL(A.TEL, '%')  LIKE  :f_tel                                                   ");
		sql.append("    AND IFNULL(A.DELETE_YN, 'N') = 'N'                                                      ");
		sql.append("  ORDER BY CONT_KEY																			");
		sql.append("  limit :startNum, :offset                                                                  ");
		
		if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
			suname2 = suname2 + "%";
		} else {
			suname2 = "%" + suname2 + "%";
		}
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_suname2", suname2);
		query.setParameter("f_sex", sex);
		query.setParameter("f_birth", birth);

		query.setParameter("f_tel", tel);
		query.setParameter("startNum", startNum);
		query.setParameter("offset", offset);
		List<OUT0101Q01GrdPatientListInfo> listOUT0101Q01GrdPatientListInfo= new JpaResultMapper().list(query, OUT0101Q01GrdPatientListInfo.class);
		return listOUT0101Q01GrdPatientListInfo;
	}

	@Override
	public String OCSLibOrderBizGetIsToiwonGojiYNandEndOrder(String hospCode,
			Double pkinp1001) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT IFNULL(A.TOIWON_GOJI_YN ,'N') TOIWON_GOJI_YN		");
		sql.append("	 FROM VW_OCS_INP1001_02 A                               ");
		sql.append("	WHERE A.HOSP_CODE = :hospCode                           ");
		sql.append("	  AND A.PKINP1001 = :pkinp1001                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkinp1001", pkinp1001);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null; 
	}

	@Override
	public PrOcsLoadNaewonInfo callPrOcsLoadNaewonInfo(String hospCode, Double pkKey) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_OCS_LOAD_NAEWON_INFO");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE",String.class,ParameterMode.IN); 
		query.registerStoredProcedureParameter("I_PK_KEY",Double.class,ParameterMode.IN); 
		query.registerStoredProcedureParameter("IO_CHISIK_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_WEIGHT_INPUT_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_WONYOI_ORDER_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_WONNAE_SAYU_CODE",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_WONNAE_SAYU_NAME",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_INP_BONIN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_SABUN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_SABUN_NAME",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_GA_JUBSU_GUBUN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_OUT_TOIWON_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_DRG_NALSU",Integer.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_JINRYO_RESULT",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_SOA_NUTJIDO_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_ATC_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_SUNNAB_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_HUBAL_CHANGE_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_NEXT_JINRYO_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_DANGIL_GUMSA_YN",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_DUMMY2",String.class,ParameterMode.INOUT); 
		query.registerStoredProcedureParameter("IO_DUMMY3", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);

		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PK_KEY", pkKey);
		 
		PrOcsLoadNaewonInfo info = new PrOcsLoadNaewonInfo((String)query.getOutputParameterValue("IO_CHISIK_YN"),(String)query.getOutputParameterValue("IO_WEIGHT_INPUT_YN"),
				(String)query.getOutputParameterValue("IO_WONYOI_ORDER_YN"),(String)query.getOutputParameterValue("IO_WONNAE_SAYU_CODE"),(String)query.getOutputParameterValue("IO_SABUN_NAME"),
				(String)query.getOutputParameterValue("IO_INP_BONIN"),(String)query.getOutputParameterValue("IO_SABUN"),(String)query.getOutputParameterValue("IO_SABUN_NAME"),(String)query.getOutputParameterValue("IO_GA_JUBSU_GUBUN"),
				(String)query.getOutputParameterValue("IO_OUT_TOIWON_YN"),(Integer)query.getOutputParameterValue("IO_DRG_NALSU"),(String)query.getOutputParameterValue("IO_JINRYO_RESULT"),(String)query.getOutputParameterValue("IO_SOA_NUTJIDO_YN"),
				(String)query.getOutputParameterValue("IO_ATC_YN"),(String)query.getOutputParameterValue("IO_SUNNAB_YN"),(String)query.getOutputParameterValue("IO_HUBAL_CHANGE_YN"),
				(String)query.getOutputParameterValue("IO_NEXT_JINRYO_YN"),(String)query.getOutputParameterValue("IO_DANGIL_GUMSA_YN"),(String)query.getOutputParameterValue("IO_FLAG"));
		
		return info;
	}	
@Override
	public LoadPatientBaseInfo callPrOcsLoadBunhoInfo(String hospCode, Date naewonDate, String bunho){
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_LOAD_BUNHO_INFO");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NAEWON_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_SUNAME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUNAME2", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUJUMIN1", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SUJUMIN2", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SEX", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_BIRTH", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_AGE", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_AGE_NUM", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_WEIGHT", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_HEIGHT", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ZIP_CODE1", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ZIP_CODE2", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ADDRESS1", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ADDRESS2", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_TEL", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_TEL1", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_TEL_HP", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_PACE_MAKER_YN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY2", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_DUMMY3", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
			
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_NAEWON_DATE", naewonDate);
		query.setParameter("I_BUNHO", bunho);
		
		query.execute();
		LoadPatientBaseInfo result = new LoadPatientBaseInfo((String)query.getOutputParameterValue("IO_SUNAME"),
				(String)query.getOutputParameterValue("IO_SUNAME2"),
				(String)query.getOutputParameterValue("IO_SUJUMIN1"), 
				(String)query.getOutputParameterValue("IO_SUJUMIN2"),
				(String)query.getOutputParameterValue("IO_SEX"),
				(Date)query.getOutputParameterValue("IO_BIRTH"), 
				(String)query.getOutputParameterValue("IO_AGE"),
				(Double)query.getOutputParameterValue("IO_AGE_NUM"),
				(Double)query.getOutputParameterValue("IO_WEIGHT"),
				(Double)query.getOutputParameterValue("IO_HEIGHT"), 
				(String)query.getOutputParameterValue("IO_ZIP_CODE1"),
				(String)query.getOutputParameterValue("IO_ZIP_CODE2"),
				(String)query.getOutputParameterValue("IO_ADDRESS1"), 
				(String)query.getOutputParameterValue("IO_ADDRESS2"),
				(String)query.getOutputParameterValue("IO_TEL"),
				(String)query.getOutputParameterValue("IO_TEL1"),
				(String)query.getOutputParameterValue("IO_TEL_HP"), 
				(String)query.getOutputParameterValue("IO_PACE_MAKER_YN"),
				(String)query.getOutputParameterValue("IO_DUMMY2"),
				(String)query.getOutputParameterValue("IO_DUMMY3"), 
				(String)query.getOutputParameterValue("IO_FLAG"));

		return result;
		
	}

	@Override
	public List<OCSAPPROVEGrdPatientListInfo> getOCSAPPROVEGrdPatientListItem(
			String hospCode, String language, String inputGubun, String ioGubun,
			String doctor, String insteadYn, String approveYn, String inputTab) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.NAEWON_DATE                             NAEWON_DATE,    											");
		sql.append("	       A.GWA                                     GWA,                                                       ");
		sql.append("	       FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE, :f_hosp_code, :language)     GWA_NAME,                   ");
		sql.append("	       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :f_hosp_code) DOCTOR_NAME,                          ");
		sql.append("	       0                                         NALSU,                                                     ");
		sql.append("	       A.BUNHO                                   BUNHO,                                                     ");
		sql.append("	       A.DOCTOR                                  DOCTOR,                                                    ");
		sql.append("	       FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.NAEWON_DATE, :f_hosp_code)      GUBUN_NAME ,                       ");
		sql.append("	       FN_BAS_LOAD_CODE_NAME ('CHOJAE', A.CHOJAE, :f_hosp_code, :language)     CHOJAE_NAME,                 ");
		sql.append("	       A.NAEWON_TYPE                             NAEWON_TYPE,                                               ");
		sql.append("	       A.JUBSU_NO                                JUBSU_NO,                                                  ");
		sql.append("	       A.PKOUT1001                               PK_ORDER,                                                  ");
		sql.append("	       TRIM(RPAD(:f_input_gubun,10,1))             INPUT_GUBUN,                                             ");
		sql.append("	       'N'                                       TOIWON_DRG,                                                ");
		sql.append("	       '%'                                       INPUT_TAB,                                                 ");
		sql.append("	       :f_io_gubun                               IO_GUBUN,                                                  ");
		sql.append("	       B.SUNAME                                         PATIENT_NAME,                                       ");
		sql.append("	       'N'                                  SELECT_YN                                                       ");
		sql.append("	  FROM OUT1001 A                                                                                            ");
		sql.append("	     , OUT0101 B                                                                                            ");
		sql.append("	 WHERE :f_io_gubun    = 'O'                                                                                 ");
		sql.append("	   AND A.HOSP_CODE    = :f_hosp_code                                                                        ");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                         ");
		sql.append("	   AND B.BUNHO        = A.BUNHO                                                                             ");
		sql.append("	   AND EXISTS( SELECT 'X'                                                                                   ");
		sql.append("	                 FROM OCS0140 C                                                                             ");
		sql.append("	            , OCS1003 B                                                                                     ");
		sql.append("	                WHERE B.BUNHO           = A.BUNHO                                                           ");
		sql.append("	          AND SUBSTR(B.DOCTOR, 3) = :f_doctor                                                               ");
		sql.append("	                  AND B.FKOUT1001       = A.PKOUT1001                                                       ");
		sql.append("	                  AND B.HOSP_CODE       = A.HOSP_CODE                                                       ");
		sql.append("	           AND IFNULL(B.INSTEAD_YN, 'N')  = :f_instead_yn                                                   ");
		sql.append("	          AND IFNULL(B.APPROVE_YN, 'N')  = :f_approve_yn                                                    ");
		sql.append("	                  AND IFNULL(B.DISPLAY_YN , 'Y') = 'Y'                                                      ");
		sql.append("	                  AND IFNULL(B.DC_YN,'N')  = 'N'                                                            ");
		sql.append("	                  AND B.NALSU           >= 0                                                                ");
		sql.append("	                  AND B.INPUT_TAB       LIKE :f_input_tab                                                   ");
		sql.append("	                  AND C.ORDER_GUBUN     = B.ORDER_GUBUN                                                     ");
		sql.append("	                  AND C.HOSP_CODE       = B.HOSP_CODE                                                       ");
		sql.append("	                  AND C.INPUT_TAB       = B.INPUT_TAB                                                       ");
		sql.append("	                  LIMIT 1 )                                                                                 ");
		sql.append("	  UNION ALL                                                                                                 ");
		sql.append("	  SELECT A.ORDER_DATE                                            ORDER_DATE ,                               ");
		sql.append("	         A.INPUT_GWA                                             GWA        ,                               ");
		sql.append("	         FN_BAS_LOAD_GWA_NAME( A.INPUT_GWA, A.ORDER_DATE, :f_hosp_code, :language)         GWA_NAME,        ");
		sql.append("	         FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE, :f_hosp_code)      DOCTOR_NAME,              ");
		sql.append("	         0                                                 NALSU,                                           ");
		sql.append("	         A.BUNHO                                           BUNHO      ,                                     ");
		sql.append("	         A.INPUT_DOCTOR                                    DOCTOR     ,                                     ");
		sql.append("	         ' '                                               GUBUN_NAME ,                                     ");
		sql.append("	         ' '                                               CHOJAE_NAME,                                     ");
		sql.append("	         '0'                                               NAEWON_TYPE,                                     ");
		sql.append("	         A.FKINP1001                                       JUBSU_NO   ,                                     ");
		sql.append("	         A.FKINP1001                                       PK_ORDER   ,                                     ");
		sql.append("	         TRIM(RPAD(:f_input_gubun,10,1))                     INPUT_GUBUN,                                   ");
		sql.append("	         FN_OCS_EXISTS_TOIWON_DRG(A.BUNHO, A.FKINP1001, A.ORDER_DATE, :f_hosp_code)     TOIWON_DRG,         ");
		sql.append("	         '%'                                              INPUT_TAB,                                        ");
		sql.append("	         :f_io_gubun                                       IO_GUBUN,                                        ");
		sql.append("	           C.SUNAME                                 PATIENT_NAME,                                           ");
		sql.append("	         'N'                                      SELECT_YN                                                 ");
		sql.append("	  FROM OCS0140 B                                                                                            ");
		sql.append("	     , OCS2003 A                                                                                            ");
		sql.append("	     , OUT0101 C                                                                                            ");
		sql.append("	 WHERE :f_io_gubun          = 'I'                                                                           ");
		sql.append("	   AND A.IO_GUBUN           IS NULL                                                                         ");
		sql.append("	   AND A.HOSP_CODE          = :f_hosp_code                                                                  ");
		sql.append("	   AND SUBSTR(A.INPUT_DOCTOR, 3) = :f_doctor                                                                ");
		sql.append("	   AND IFNULL(A.INSTEAD_YN, 'N')     = :f_instead_yn                                                        ");
		sql.append("	   AND IFNULL(A.APPROVE_YN, 'N')     = :f_approve_yn                                                        ");
		sql.append("	   AND A.NALSU                 >= 0                                                                         ");
		sql.append("	   AND IFNULL(A.DISPLAY_YN ,'Y')     = 'Y'                                                                  ");
		sql.append("	   AND IFNULL(A.DC_YN      ,'N')     = 'N'                                                                  ");
		sql.append("	   AND B.ORDER_GUBUN           = A.ORDER_GUBUN                                                              ");
		sql.append("	   AND B.HOSP_CODE             = A.HOSP_CODE                                                                ");
		sql.append("	   AND B.INPUT_TAB             = A.INPUT_TAB                                                                ");
		sql.append("	   AND C.HOSP_CODE = A.HOSP_CODE                                                                            ");
		sql.append("	   AND C.BUNHO     = A.BUNHO                                                                                ");
		sql.append("	 GROUP BY A.ORDER_DATE                                                                                      ");
		sql.append("	        , A.INPUT_GWA                                                                                       ");
		sql.append("	        , FN_BAS_LOAD_GWA_NAME( A.INPUT_GWA, A.ORDER_DATE, :f_hosp_code, :language)                         ");
		sql.append("	        , FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE, :f_hosp_code)                               ");
		sql.append("	        , NALSU                                                                                             ");
		sql.append("	        , A.BUNHO                                                                                           ");
		sql.append("	        , A.INPUT_DOCTOR                                                                                    ");
		sql.append("	        , ' '                                                                                               ");
		sql.append("	        , ' '                                                                                               ");
		sql.append("	        , '0'                                                                                               ");
		sql.append("	        , A.FKINP1001                                                                                       ");
		sql.append("	        , A.FKINP1001                                                                                       ");
		sql.append("	        , TRIM(RPAD('',10,1))                                                                               ");
		sql.append("	        , ''                                                                                                ");
		sql.append("	        , FN_OCS_EXISTS_TOIWON_DRG(A.BUNHO, A.FKINP1001, A.ORDER_DATE, :f_hosp_code)                        ");
		sql.append("	        , ''                                                                                                ");
		sql.append("	        , ''                                                                                                ");
		sql.append("	        , C.SUNAME                                                                                          ");
		sql.append("	        , ''                                                                                                ");
		sql.append("	  ORDER BY 1 DESC, 12 DESC;                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_instead_yn", insteadYn);
		query.setParameter("f_approve_yn", approveYn);
		query.setParameter("f_input_tab", inputTab);
		
		
		List<OCSAPPROVEGrdPatientListInfo> list = new JpaResultMapper().list(query, OCSAPPROVEGrdPatientListInfo.class);
		return list;
	}

	@Override
	public String getIsJaewonPatientInfo(String bunho, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y' 						   ");
		sql.append("	  FROM VW_OCS_INP1001_01 A         ");
		sql.append("	 WHERE A.BUNHO = :bunho            ");
		sql.append("	   AND A.HOSP_CODE = :hospCode     ");
		sql.append("	   LIMIT 1                         ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("bunho", bunho);
		query.setParameter("hospCode", hospCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	public List<Inp1003U00GrdInpReserListItem> getInp1003U00GrdInpReserListItem(String hospCode, 
			String language, Date reserDate, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.RESER_DATE 																						");
		sql.append("	, A.BUNHO                                                                                                   ");
		sql.append("	, B.SUNAME                                                                                                  ");
		sql.append("	, A.GWA                                                                                                     ");
		sql.append("	, FN_BAS_LOAD_GWA_NAME(A.GWA, A.RESER_DATE,:f_hosp_code, :language ) GWA_NAME                               ");
		sql.append("	, A.HO_CODE                                                                                                 ");
		sql.append("	, A.DOCTOR                                                                                                  ");
		sql.append("	, FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.RESER_DATE,:f_hosp_code) DOCTOR_NAME                                  ");
		sql.append("	, A.IPWON_RTN2                                                                                              ");
		sql.append("	, C.CODE_NAME PWON_RTN2_NAME                                                                                ");
		sql.append("	, A.TEL1                                                                                                    ");
		sql.append("	, A.TEL2                                                                                                    ");
		sql.append("	, A.RESER_END_TYPE                                                                                          ");
		sql.append("	, A.SUSUL_RESER_YN                                                                                          ");
		sql.append("	, A.REMARK                                                                                                  ");
		sql.append("	, A.PKINP1003                                                                                               ");
		sql.append("	, A.JUNPYO_DATE                                                                                             ");
		sql.append("	, A.HO_DONG                                                                                                 ");
		sql.append("	, A.BED_NO                                                                                                  ");
		sql.append("	, A.IPWON_MOKJUK                                                                                            ");
		sql.append("	, A.RESER_FKINP1001                                                                                         ");
		sql.append("	, A.IPWONSI_ORDER_YN                                                                                        ");
		sql.append("	, A.JISI_DOCTOR                                                                                             ");
		sql.append("	, FN_BAS_LOAD_DOCTOR_NAME (A.JISI_DOCTOR, A.RESER_DATE,:f_hosp_code) JISI_DOCTOR_NAME                       ");
		sql.append("	, A.SANG_BIGO                                                                                               ");
		sql.append("	, IFNULL(A.SOGYE_YN, 0)                                                                                     ");
		sql.append("	, IFNULL(A.HOPE_ROOM, ' ')                                                                                  ");
		sql.append("	, FN_ADM_USER_NM ( :f_hosp_code, A.SYS_ID )                                                                 ");
		sql.append("	FROM OUT0101 B RIGHT JOIN INP1003 A ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                      ");
		sql.append("	LEFT JOIN BAS0102 C ON C.HOSP_CODE = A.HOSP_CODE AND C.CODE_TYPE = 'IPWON_RTN2' AND C.CODE = A.IPWON_RTN2   ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                                            ");
		sql.append("	AND A.RESER_DATE >= :f_reser_date                                                                           ");
		sql.append("	AND A.RESER_END_TYPE <> '5'                                                                                 ");
		sql.append("	AND IFNULL(A.HO_DONG, '%') LIKE :f_ho_dong                                                                  ");
		sql.append("	ORDER BY RESER_DATE                                                                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_ho_dong", hoDong);
		
		List<Inp1003U00GrdInpReserListItem> list = new JpaResultMapper().list(query, Inp1003U00GrdInpReserListItem.class);
		return list;
	}
	
	public List<ComboListItemInfo> getSurnameTelListItemInfo (String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.SUNAME    suname                   ");
		sql.append("	    , A.TEL   tel                           ");
		sql.append("	    , IFNULL(A.DELETE_YN, 'N')   delete_yn  ");
		sql.append("	 FROM OUT0101 A                             ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code            ");
		sql.append("	  AND A.BUNHO = :f_bunho                    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	public List<INP1003ChkBunhoListItemInfo> getINP1003ChkBunhoListItemInfo(String hospCode, String language, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.DELETE_YN, 'N') DELETE_YN															   ");
		sql.append("	, IFNULL(A.JUBSU_BREAK, 'N') JUBSU_BREAK                                                               ");
		sql.append("	, FN_BAS_LOAD_CODE_NAME('JUBSU_BREAK_REASON', A.JUBSU_BREAK_REASON, :f_hosp_code, :language) CODE_NAME ");
		sql.append("	FROM OUT0101 A                                                                                         ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                                       ");
		sql.append("	AND A.BUNHO = :f_bunho                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_bunho", bunho);
		
		List<INP1003ChkBunhoListItemInfo> list = new JpaResultMapper().list(query, INP1003ChkBunhoListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS1003R00LayOUT1001Info> getOCS1003R00LayOUT1001Info(String hospCode, String language, String inputGubun,
			Date naewonDate, String bunho, String gwa, String doctor,String naewonType, String jubsuNo) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                        ");
		sql.append("        'N'                                               RESER_YN       ,                              ");
		sql.append("        A.BUNHO                                           BUNHO          ,                              ");
		sql.append("        B.SUNAME                                          SUNAME         ,                              ");
		sql.append("        B.SUNAME2                                         SUNAME2        ,                              ");
		sql.append("        DATE_FORMAT(B.BIRTH,'%Y/%m/%d')                   BIRTH          ,                              ");
		sql.append("        FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.NAEWON_DATE, :hospCode) SEX_AGE ,                                ");
		sql.append("        A.DOCTOR                                          DOCTOR         ,                              ");
		sql.append("        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :hospCode)  DOCTOR_NAME,                       ");
		sql.append("        A.GWA                                             GWA            ,                              ");
		sql.append("        FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :hospCode, :language) GWA_NAME,                      ");
		sql.append("        A.CHOJAE                                          CHOJAE         ,                              ");
		sql.append("        FN_BAS_LOAD_CODE_NAME('CHOJAE',A.CHOJAE, :hospCode, :language) CHOJAE_NAME,                     ");
		sql.append("        DATE_FORMAT(A.NAEWON_DATE,'%Y/%m/%d')             NAEWON_DATE    ,                              ");
		sql.append("        :f_input_gubun                                    INPUT_GUBUN    ,                              ");
		sql.append("        'N'                                               ORDER_END_YN                                  ");
		sql.append("   FROM OUT0101 B,                                                                                      ");
		sql.append("        OUT1001 A                                                                                       ");
		sql.append("  WHERE B.BUNHO        = A.BUNHO                                                                        ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE																	");
		sql.append("    AND A.NAEWON_DATE  =    :f_naewon_date                                                              ");
		sql.append("    AND A.BUNHO        =    :f_bunho                                                                    ");
		sql.append("    AND A.GWA          =    :f_gwa                                                                      ");
		sql.append("    AND A.DOCTOR       LIKE :f_doctor                                                                   ");
		sql.append("    AND A.NAEWON_TYPE  =    :f_naewon_type                                                              ");
		sql.append("    AND ( :f_jubsu_no = 0 OR ( :f_jubsu_no <> 0 AND A.JUBSU_NO = :f_jubsu_no))                          ");
		sql.append(" UNION ALL                                                                                              ");
		sql.append(" SELECT DISTINCT                                                                                        ");
		sql.append("        'Y'                                                  RESER_YN       ,                           ");
		sql.append("        A.BUNHO                                              BUNHO          ,                           ");
		sql.append("        B.SUNAME                                             SUNAME         ,                           ");
		sql.append("        B.SUNAME2                                            SUNAME2        ,                           ");
		sql.append("        DATE_FORMAT(B.BIRTH,'%Y/%m/%d')                      BIRTH          ,                           ");
		sql.append("        FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.JINRYO_PRE_DATE, :hospCode) SEX_AGE  ,                           ");
		sql.append("        A.DOCTOR                                             DOCTOR         ,                           ");
		sql.append("        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.JINRYO_PRE_DATE, :hospCode) DOCTOR_NAME ,                   ");
		sql.append("        A.GWA                                                GWA            ,                           ");
		sql.append("        FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :hospCode, :language) GWA_NAME ,                     ");
		sql.append("        A.CHOJAE                                             CHOJAE         ,                           ");
		sql.append("        FN_BAS_LOAD_CODE_NAME('CHOJAE',A.CHOJAE, :hospCode, :language) CHOJAE_NAME,                     ");
		sql.append("        DATE_FORMAT(A.JINRYO_PRE_DATE,'%Y/%m/%d') NAEWON_DATE    ,                                      ");
		sql.append("        :f_input_gubun                                       INPUT_GUBUN    ,                           ");
		sql.append("        'N'                                                  ORDER_END_YN                               ");
		sql.append("   FROM OUT0101 B,                                                                                      ");
		sql.append("        RES1001 A                                                                                       ");
		sql.append("  WHERE A.HOSP_CODE       =    :hospCode                                                                ");
		sql.append("    AND A.JINRYO_PRE_DATE =    :f_naewon_date                                                           ");
		sql.append("    AND A.BUNHO           =    :f_bunho                                                                 ");
		sql.append("    AND A.GWA             =    :f_gwa                                                                   ");
		sql.append("    AND A.DOCTOR          LIKE :f_doctor                                                                ");
		sql.append("    AND A.NAEWON_TYPE     =    :f_naewon_type                                                           ");
		sql.append("    AND B.BUNHO           =    A.BUNHO                                                                  ");
		sql.append("    AND B.HOSP_CODE       =    A.HOSP_CODE																");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_naewon_type", naewonType);
		query.setParameter("f_jubsu_no", jubsuNo);
		List<OCS1003R00LayOUT1001Info> list = new JpaResultMapper().list(query, OCS1003R00LayOUT1001Info.class);
		return list;
	}

	@Override
	public List<OCSACTGrdPaListInfo> getOCSACTGrdPaListInfo(String hospCode,
			String language, String bunho, Date fromDate, Date toDate,
			String actGubun, String code,List<String> jundalPartParam, String iOGubun) {
		StringBuilder sql = new StringBuilder();
		if(StringUtils.isEmpty(bunho)){
			bunho = null;
		}
		sql.append("SELECT DISTINCT                                                                                                                                                   				 ");
		sql.append("        'O'                                                IN_OUT_GUBUN                                                                                           				 ");
		sql.append("       , A.BUNHO                                           BUNHO                                                                                                  				 ");
		sql.append("       , B.SUNAME                                          SUNAME                                                                                                 				 ");
		sql.append("       , B.SUNAME2                                         SUNAME2                                                                                                				 ");
		sql.append("       , A.GWA                                             GWA                                                                                                    				 ");
		sql.append("       , FN_BAS_LOAD_GWA_NAME(A.GWA, A.SYS_DATE,:f_hosp_code,:f_language)           GWA_NAME                                                                      				 ");
		sql.append("       , A.DOCTOR                                          DOCTOR                                                                                                 				 ");
		sql.append("       , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE,:f_hosp_code)     DOCTOR_NAME                                                                               				 ");
		sql.append("       , A.JUNDAL_TABLE                                    JUNDAL_TABLE                                                                                           				 ");
		sql.append("       ,CASE WHEN A.RESER_DATE IS NULL THEN 'N' ELSE 'Y' END RESER_YN                                                                                             				 ");
		sql.append("       , A.EMERGENCY                                                                                                                                              				 ");
		sql.append("       , IF(F.NUM_PROTOCOL IS NULL ,'N','Y')                                                                                                                      				 ");
		sql.append("    FROM OUT0101 B                                                                                                                                                				 ");
		sql.append("       , OCS1003 A                                                                                                                                                				 ");
		sql.append("       LEFT JOIN (SELECT D.CLIS_PROTOCOL_ID NUM_PROTOCOL  , D.HOSP_CODE HOSP_CODE   , D.BUNHO BUNHO                                                               				 ");
		sql.append("       FROM CLIS_PROTOCOL_PATIENT D LEFT JOIN CLIS_PROTOCOL E ON D.CLIS_PROTOCOL_ID = E.CLIS_PROTOCOL_ID AND D.HOSP_CODE = E.HOSP_CODE                            				 ");
		sql.append("       WHERE D.HOSP_CODE = :f_hosp_code                                                                                                                           				  ");
		sql.append("       AND D.ACTIVE_FLG = 1                                                                                                                                       				 ");
		sql.append("       AND E.ACTIVE_FLG = 1                                                                                                                                       				 ");
		sql.append("       AND E.STATUS_FLG <> 1                                                                                                                                      				 ");
		sql.append("       AND E.END_DATE >= SYSDATE()) F ON F.HOSP_CODE = A.HOSP_CODE AND F.BUNHO = A.BUNHO                                                                          				 ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                               				 ");
		sql.append("         AND ((:f_bunho IS NULL AND IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date)           				 ");
		sql.append("          OR (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))                                                                                                       				 ");
		sql.append("         AND ( ( :f_act_gubun = '1' )                                                                                                                             				 ");
		sql.append("          OR ( :f_act_gubun = '2' AND A.ACTING_DATE IS NULL )                                                                                                     				 ");
		sql.append("          OR ( :f_act_gubun = '3' AND A.ACTING_DATE IS NOT NULL ) )                                                                                               				 ");
		sql.append("         AND A.JUNDAL_TABLE   = (SELECT X.MENT                                                                                                                    				 ");
		sql.append("                                   FROM OCS0132 X                                                                                                                 				 ");
		sql.append("                                  WHERE X.HOSP_CODE = :f_hosp_code                                                                                                				 ");
		sql.append("                                    AND X.LANGUAGE  = :f_language                                                                                                 				 ");
		sql.append("                                    AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'                                                                                            				 ");
		sql.append("                                    AND X.CODE      = :f_code)                                                                                                    				 ");
		if(!CollectionUtils.isEmpty(jundalPartParam))
		{
			sql.append("         AND A.JUNDAL_PART    IN ( :jundal_part_param )                                                                                                           			  ");
		}

		sql.append("         AND :f_io_gubun      IN ('1','2','4')                                                                                                                    				 ");
		sql.append("         AND ( (:f_io_gubun   = '4' AND EXISTS (SELECT 'X' FROM OUT1001 X WHERE X.NAEWON_DATE = STR_TO_DATE(DATE_FORMAT(SYSDATE(),'%Y%m%d'),'%Y%m%d') AND X.BUNHO = A.BUNHO))    ");
		sql.append("          OR :f_io_gubun   <> '4' )                                                                                                                                              ");
		sql.append("         AND A.DC_YN          = 'N'                                                                                                                                              ");
		sql.append("         AND A.NALSU          > 0                                                                                                                                                ");
		sql.append("         AND B.HOSP_CODE      = A.HOSP_CODE                                                                                                                                      ");
		sql.append("         AND B.BUNHO          = A.BUNHO                                                                                                                                          ");
		sql.append(" UNION                                                                                                                                                                           ");
		sql.append(" SELECT DISTINCT                                                                                                                                                                 ");
		sql.append("        'I'                                                IN_OUT_GUBUN                                                                                                          ");
		sql.append("       , A.BUNHO                                           BUNHO                                                                                                                 ");
		sql.append("       , C.SUNAME                                          SUNAME                                                                                                                ");
		sql.append("       , C.SUNAME2                                         SUNAME2                                                                                                               ");
		sql.append("       , B.GWA                                             GWA                                                                                                                   ");
		sql.append("       , FN_BAS_LOAD_GWA_NAME(B.GWA, A.SYS_DATE,:f_hosp_code,:f_language)           GWA_NAME                                                                                     ");
		sql.append("       , A.DOCTOR                                          DOCTOR                                                                                                                ");
		sql.append("       , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE,:f_hosp_code)     DOCTOR_NAME                                                                                              ");
		sql.append("       , A.JUNDAL_TABLE                                    JUNDAL_TABLE                                                                                                          ");
		sql.append("       ,CASE WHEN A.RESER_DATE IS NULL THEN 'N' ELSE 'Y' END RESER_YN                                                                                                            ");
		sql.append("       , A.EMERGENCY                                                                                                                                                             ");
		sql.append("       , IF(F.NUM_PROTOCOL IS NULL ,'N','Y')                                                                                                                                     ");
		sql.append("    FROM OUT0101 C                                                                                                                                                               ");
		sql.append("       , INP1001 B                                                                                                                                                               ");
		sql.append("       , OCS2003 A                                                                                                                                                               ");
		sql.append("       LEFT JOIN (SELECT D.CLIS_PROTOCOL_ID NUM_PROTOCOL  , D.HOSP_CODE HOSP_CODE ,  D.BUNHO BUNHO                                                                              ");
		sql.append("       FROM CLIS_PROTOCOL_PATIENT D LEFT JOIN CLIS_PROTOCOL E ON D.CLIS_PROTOCOL_ID = E.CLIS_PROTOCOL_ID AND D.HOSP_CODE = E.HOSP_CODE                                           ");
		sql.append("       WHERE D.HOSP_CODE = :f_hosp_code                                                                                                                                           ");
		sql.append("       AND D.ACTIVE_FLG = 1                                                                                                                                                      ");
		sql.append("       AND E.ACTIVE_FLG = 1                                                                                                                                                      ");
		sql.append("       AND E.STATUS_FLG <> 1                                                                                                                                                     ");
		sql.append("       AND E.END_DATE >= SYSDATE()) F ON F.HOSP_CODE = A.HOSP_CODE  AND F.BUNHO = A.BUNHO                                                                                        ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                                              ");
		sql.append("     AND ((:f_bunho IS NULL AND IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date)                              ");
		sql.append("      OR (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))                                                                                                                          ");
		sql.append("     AND ( ( :f_act_gubun = '1' )                                                                                                                                                ");
		sql.append("      OR ( :f_act_gubun = '2' AND A.ACTING_DATE IS NULL )                                                                                                                        ");
		sql.append("      OR ( :f_act_gubun = '3' AND A.ACTING_DATE IS NOT NULL ) )                                                                                                                  ");
		sql.append("     AND A.JUNDAL_TABLE   = (SELECT X.MENT                                                                                                                                       ");
		sql.append("                               FROM OCS0132 X                                                                                                                                    ");
		sql.append("                              WHERE X.HOSP_CODE = :f_hosp_code                                                                                                                   ");
		sql.append("                                AND X.LANGUAGE  = :f_language                                                                                                                    ");
		sql.append("                                AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'                                                                                                               ");
		sql.append("                                AND X.CODE      = :f_code)                                                                                                                       ");

		if(!CollectionUtils.isEmpty(jundalPartParam))
		{
			sql.append("         AND A.JUNDAL_PART    IN (:jundal_part_param)                                                                                  										  ");
		}
		sql.append("     AND :f_io_gubun      IN ('1','3')                                                                                                                                           ");
		sql.append("     AND ( (:f_io_gubun = '4' AND EXISTS (SELECT 'X' FROM OUT1001 X WHERE X.NAEWON_DATE = STR_TO_DATE(DATE_FORMAT(SYSDATE(),'%Y%m%d'),'%Y%m%d') AND X.BUNHO = A.BUNHO))                                        ");
		sql.append("      OR :f_io_gubun <> '4' )                                                                                                                                      				 ");
		sql.append("     AND A.DC_YN = 'N'                                                                                                                                             				 ");
		sql.append("     AND A.NALSU > 0                                                                                                                                               				 ");
		sql.append("     AND B.HOSP_CODE      = A.HOSP_CODE                                                                                                                            				 ");
		sql.append("     AND B.PKINP1001      = A.FKINP1001                                                                                                                            				 ");
		sql.append("     AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                            				 ");
		sql.append("     AND C.BUNHO          = A.BUNHO                                                                                                                                				 ");
		sql.append("    ORDER BY 1,2,3,6											                                                                                                   				 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());                                                                                                                 
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_act_gubun", actGubun);
		query.setParameter("f_code", code);
		if(!CollectionUtils.isEmpty(jundalPartParam))
		{
			query.setParameter("jundal_part_param", jundalPartParam);
		}

		query.setParameter("f_io_gubun", iOGubun);
		List<OCSACTGrdPaListInfo> list = new JpaResultMapper().list(query, OCSACTGrdPaListInfo.class);
		return list;
	}
	
	public List<OCSACTGrdOrderInfo> getOCSACTGrdOrderInfo (String hospCode, String language, String bunho, String dataValue, 
			List<String> jundalPartParam, String ioGubun, Date fromDate, Date toDate, String gwa, 
			String doctor, boolean rbxNonAct, boolean rbxAct){
		StringBuilder sql = new StringBuilder();
		if("O".equalsIgnoreCase(ioGubun)) {
			sql.append("	SELECT 'O'  IN_OUT_GUBUN																																	 ");
			sql.append("	     , A.PKOCS1003                                                                                                                                           ");
			sql.append("	     , IF(A.ACTING_DATE IS NULL,'N','Y')  ACT_YN                                                                                                             ");
			sql.append("	     , A.HANGMOG_CODE                                                                                                                                        ");
			sql.append("	     , D.HANGMOG_NAME                                                                                                                                        ");
			sql.append("	     , A.JUBSU_DATE                        JUBSU_DATE                                                                                                        ");
			sql.append("	     , A.JUBSU_TIME                        JUBSU_TIME                                                                                                        ");
			sql.append("	     , A.ACTING_DATE                       ACTING_DATE                                                                                                       ");
			sql.append("	     , A.ACTING_TIME                       ACTING_TIME                                                                                                       ");
			sql.append("	     , A.ORDER_DATE                        ORDER_DATE                                                                                                        ");
			sql.append("	     , DATE_FORMAT(A.SYS_DATE,'%H%i')        ORDER_TIME                                                                                                      ");
			sql.append("	     , IFNULL(A.RESER_DATE, A.HOPE_DATE)           RESER_DATE                                                                                                ");
			sql.append("	     , A.RESER_TIME                                                                                                                                          ");
			sql.append("	     , A.ACT_DOCTOR                                                                                                                                          ");
			sql.append("	     , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR,:f_hosp_code) ACT_DOCTOR_NAME                                                                                      ");
			sql.append("	     , A.ACT_BUSEO                                                                                                                                           ");
			sql.append("	     , A.ACT_GWA                                                                                                                                             ");
			sql.append("	     , A.BUNHO                                                                                                                                               ");
			sql.append("	     , B.SUNAME                                                                                                                                              ");
			sql.append("	     , B.SUNAME2                                                                                                                                             ");
			sql.append("	     , A.GWA                                                                                                                                                 ");
			sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.SYS_DATE,:f_hosp_code, :language)                                                                                       ");
			sql.append("	     , A.DOCTOR                                                                                                                                              ");
			sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE,:f_hosp_code)                                                                                            ");
			sql.append("	     , A.ORDER_REMARK                                                                                                                                        ");
			sql.append("	     , B.BIRTH                                                                                                                                               ");
			sql.append("	     , CONCAT(B.SEX,'/',FN_BAS_LOAD_AGE(SYSDATE(),B.BIRTH,NULL))                                                                                             ");
			sql.append("	     , CONCAT(FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO,:f_hosp_code),'/',FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO,:f_hosp_code))                                   ");
			sql.append("	     , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','O',:f_hosp_code, :language)                                                                                        ");
			sql.append("	     , B.PACE_MAKER_YN                                                                                                                                       ");
			sql.append("	     , CAST(' ' AS CHAR)     EMPTY_STRING                                                                                                                                               ");
			sql.append("	     , FN_OCS_LAST_ACT_DATE(:f_hosp_code, :language,A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)                                                                    ");
			sql.append("	     , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO,:f_hosp_code)                                                                                                     ");
			sql.append("	     , A.JUNDAL_TABLE                                                                                                                                        ");
			sql.append("	     , A.JUNDAL_PART                                                                                                                                         ");
			sql.append("	     , A.FKOUT1001                                                                                                                                           ");
			sql.append("	     , IF(A.RESER_DATE IS NULL,'N','Y') RESER_YN                                                                                                             ");
			sql.append("	     , A.EMERGENCY                                                                                                                                           ");
			sql.append("	     , IF(A.ACTING_DATE IS NULL,'N','Y')  OLD_ACT_YN                                                                                                         ");
			sql.append("	     , A.IF_DATA_SEND_YN                                                                                                                                     ");
			sql.append("	     , D.SPECIFIC_COMMENT                                                                                                                                    ");
			sql.append("	     , A.SORT_FKOCSKEY                                                                                                                                       ");
			sql.append("	     , D.INPUT_CONTROL                                                                                                                                       ");
			sql.append("	     , E.BUN_CODE                                                                                                                                            ");
			sql.append("	     , A.SURYANG                                                                                                                                             ");
			sql.append("	     , A.NALSU                                                                                                                                               ");
			sql.append("	  FROM OUT0101 B                                                                                                                                             ");
			sql.append("	     , OCS1003 A                                                                                                                                             ");
			sql.append("	     , (SELECT A.SG_CODE                                                                                                                                     ");
			sql.append("	             , A.BUN_CODE                                                                                                                                    ");
			sql.append("	          FROM BAS0310 A                                                                                                                                     ");
			sql.append("	         WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                    ");
			sql.append("	           AND A.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                                                          ");
			sql.append("	                                 FROM BAS0310 Z                                                                                                              ");
			sql.append("	                                WHERE Z.HOSP_CODE  =  A.HOSP_CODE                                                                                            ");
			sql.append("	                                  AND Z.SG_CODE = A.SG_CODE                                                                                                  ");
			sql.append("	                                  AND Z.SG_YMD <= SYSDATE())) E RIGHT JOIN OCS0103 D ON E.SG_CODE = D.SG_CODE                                                ");
			sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                         ");
			sql.append("	   AND A.BUNHO        = :f_bunho                                                                                                                             ");
			sql.append("	   AND A.JUNDAL_TABLE = (SELECT X.MENT                                                                                                                       ");
			sql.append("	                                 FROM OCS0132 X                                                                                                              ");
			sql.append("	                                WHERE X.HOSP_CODE = :f_hosp_code   AND X.LANGUAGE = :language                                                              ");
			sql.append("	                                  AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'                                                                                         ");
			sql.append("	                                  AND X.CODE      = :dataValue)                                                                                              ");
			sql.append("	   AND A.JUNDAL_PART  IN ( :jundal_part_param)                                                                                                               ");
			sql.append("	   AND :f_io_gubun    = 'O'                                                                                                                                  ");
			if (rbxNonAct==true) {
				sql.append("	   AND A.ACTING_DATE  IS NULL                                                                                                                                ");
			} else if (rbxAct==true) {
				sql.append("	   AND A.ACTING_DATE  IS NOT NULL                                                                                                                                ");
			}
			sql.append("	   AND IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date                                    ");
			if (rbxAct==true) {
				sql.append("	   AND A.HANGMOG_CODE NOT IN (SELECT CODE FROM VW_OCS_DUMMY_ORDER_MASTER)                                                                                                                                ");
			}
			sql.append("	   AND A.GWA          = :f_gwa                                                                                                                               ");
			sql.append("	   AND A.DOCTOR       = :f_doctor                                                                                                                            ");
			sql.append("	   AND B.BUNHO        = A.BUNHO                                                                                                                              ");
			sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
			sql.append("	   AND D.HANGMOG_CODE = A.HANGMOG_CODE                                                                                                                       ");
			sql.append("	   AND D.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
		} else if("I".equalsIgnoreCase(ioGubun)) {
			sql.append("	SELECT 'I'  IN_OUT_GUBUN                                                                                                                                     ");
			sql.append("	     , A.PKOCS2003                                                                                                                                           ");
			sql.append("	     , IF(A.ACTING_DATE IS NULL,'N','Y')  ACT_YN                                                                                                             ");
			sql.append("	     , A.HANGMOG_CODE                                                                                                                                        ");
			sql.append("	     , D.HANGMOG_NAME                                                                                                                                        ");
			sql.append("	     , A.JUBSU_DATE                        JUBSU_DATE                                                                                                        ");
			sql.append("	     , A.JUBSU_TIME                        JUBSU_TIME                                                                                                        ");
			sql.append("	     , A.ACTING_DATE                       ACTING_DATE                                                                                                       ");
			sql.append("	     , A.ACTING_TIME                       ACTING_TIME                                                                                                       ");
			sql.append("	     , A.ORDER_DATE                        ORDER_DATE                                                                                                        ");
			sql.append("	     , DATE_FORMAT(A.SYS_DATE,'%H%i')        ORDER_TIME                                                                                                      ");
			sql.append("	     , IFNULL(A.RESER_DATE, A.HOPE_DATE)           RESER_DATE                                                                                                ");
			sql.append("	     , A.RESER_TIME                                                                                                                                          ");
			sql.append("	     , A.ACT_DOCTOR                                                                                                                                          ");
			sql.append("	     , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR,:f_hosp_code) ACT_DOCTOR_NAME                                                                                      ");
			sql.append("	     , A.ACT_BUSEO                                                                                                                                           ");
			sql.append("	     , A.ACT_GWA                                                                                                                                             ");
			sql.append("	     , A.BUNHO                                                                                                                                               ");
			sql.append("	     , B.SUNAME                                                                                                                                              ");
			sql.append("	     , B.SUNAME2                                                                                                                                             ");
			sql.append("	     , E.GWA                                                                                                                                                 ");
			sql.append("	     , FN_BAS_LOAD_GWA_NAME(E.GWA, A.SYS_DATE,:f_hosp_code, :language)                                                                                       ");
			sql.append("	     , A.DOCTOR                                                                                                                                              ");
			sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE,:f_hosp_code)                                                                                            ");
			sql.append("	     , A.ORDER_REMARK                                                                                                                                        ");
			sql.append("	     , B.BIRTH                                                                                                                                               ");
			sql.append("	      , CONCAT(B.SEX,'/',FN_BAS_LOAD_AGE(SYSDATE(),B.BIRTH,NULL))                                                                                            ");
			sql.append("	     , CONCAT(FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO,:f_hosp_code),'/',FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO,:f_hosp_code))                                   ");
			sql.append("	     , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','O',:f_hosp_code, :language)                                                                                        ");
			sql.append("	     , B.PACE_MAKER_YN                                                                                                                                       ");
			sql.append("	     , CONCAT(FN_BAS_LOAD_HO_DONG_NAME(E.HO_DONG1,A.ORDER_DATE,:f_hosp_code, :language),'/',FN_BAS_LOAD_HO_CODE_NAME(:f_hosp_code, E.HO_DONG1,E.HO_CODE1,A.ORDER_DATE))   EMPTY_STRING  ");
			sql.append("	     , FN_OCS_LAST_ACT_DATE(:f_hosp_code, :language,A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)                                                                    ");
			sql.append("	     , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO,:f_hosp_code)                                                                                                     ");
			sql.append("	     , A.JUNDAL_TABLE                                                                                                                                        ");
			sql.append("	     , A.JUNDAL_PART                                                                                                                                         ");
			sql.append("	     , A.FKINP1001   FKOUT1001                                                                                                                               ");
			sql.append("	     , IF(A.RESER_DATE IS NULL,'N','Y') RESER_YN                                                                                                             ");
			sql.append("	     , A.EMERGENCY                                                                                                                                           ");
			sql.append("	     , IF(A.ACTING_DATE IS NULL,'N','Y')  OLD_ACT_YN                                                                                                         ");
			sql.append("	     , A.IF_DATA_SEND_YN																								                                     ");
			sql.append("	     , D.SPECIFIC_COMMENT                                                                                                                                    ");
			sql.append("	     , A.SORT_FKOCSKEY                                                                                                                                       ");
			sql.append("	     , D.INPUT_CONTROL                                                                                                                                       ");
			sql.append("	     , F.BUN_CODE                                                                                                                                            ");
			sql.append("	     , A.SURYANG                                                                                                                                             ");
			sql.append("	     , A.NALSU                                                                                                                                               ");
			sql.append("	  FROM INP1001 E                                                                                                                                             ");
			sql.append("	     , OUT0101 B                                                                                                                                             ");
			sql.append("	     , OCS2003 A                                                                                                                                             ");
			sql.append("	     , (SELECT A.SG_CODE                                                                                                                                     ");
			sql.append("	             , A.BUN_CODE                                                                                                                                    ");
			sql.append("	          FROM BAS0310 A                                                                                                                                     ");
			sql.append("	         WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                    ");
			sql.append("	           AND A.SG_YMD    = ( SELECT MAX(Z.SG_YMD)                                                                                                          ");
			sql.append("	                                 FROM BAS0310 Z                                                                                                              ");
			sql.append("	                                WHERE Z.HOSP_CODE  =  A.HOSP_CODE                                                                                            ");
			sql.append("	                                  AND Z.SG_CODE = A.SG_CODE                                                                                                  ");
			sql.append("	                                  AND Z.SG_YMD <= SYSDATE() )) F RIGHT JOIN OCS0103 D ON F.SG_CODE = D.SG_CODE                                               ");
			sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                         ");
			sql.append("	   AND A.BUNHO        = :f_bunho                                                                                                                             ");
			sql.append("	   AND A.DC_YN        = 'N'                                                                                                                                  ");
			sql.append("	   AND A.NALSU        > 0                                                                                                                                    ");
			sql.append("	   AND A.JUNDAL_TABLE = (SELECT X.MENT                                                                                                                       ");
			sql.append("	                                 FROM OCS0132 X                                                                                                              ");
			sql.append("	                                WHERE X.HOSP_CODE = :f_hosp_code     AND X.LANGUAGE = :language                                                            ");
			sql.append("	                                  AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'                                                                                         ");
			sql.append("	                                  AND X.CODE      = :dataValue)                                                                                              ");
			sql.append("	   AND A.JUNDAL_PART  IN ( :jundal_part_param)                                                                                                               ");
			sql.append("	   AND :f_io_gubun    = 'I'                                                                                                                                  ");
			if (rbxNonAct==true) {
				sql.append("	   AND A.ACTING_DATE  IS NULL                                                                                                                                ");
			} else if (rbxAct==true) {
				sql.append("	   AND A.ACTING_DATE  IS NOT NULL                                                                                                                                ");
			}
			sql.append("	   AND IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date                                    ");
			if (rbxAct==true) {
				sql.append("	   AND A.HANGMOG_CODE NOT IN (SELECT CODE FROM VW_OCS_DUMMY_ORDER_MASTER)                                                                                                                                ");
			}
			sql.append("	   AND E.GWA          = :f_gwa                                                                                                                               ");
			sql.append("	   AND A.DOCTOR       = :f_doctor                                                                                                                            ");
			sql.append("	   AND B.BUNHO        = A.BUNHO                                                                                                                              ");
			sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
			sql.append("	   AND D.HANGMOG_CODE = A.HANGMOG_CODE                                                                                                                       ");
			sql.append("	   AND D.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
			sql.append("	   AND E.PKINP1001    = A.FKINP1001                                                                                                                          ");
			sql.append("	   AND E.HOSP_CODE    = A.HOSP_CODE                                                                                                                          ");
		}
		if (rbxAct==true) {
			sql.append("	 ORDER BY JUBSU_DATE DESC, JUBSU_TIME DESC                                                                                                                             ");
		} else {
			sql.append("	 ORDER BY ORDER_DATE, ORDER_TIME                                                                                                                             ");
		}
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("dataValue", dataValue);
		query.setParameter("jundal_part_param", jundalPartParam);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		
		List<OCSACTGrdOrderInfo> list = new JpaResultMapper().list(query, OCSACTGrdOrderInfo.class);
		return list;
	}

	@Override	
	public List<MultiResultViewLayPaInfo> getMultiResultViewLayPaInfo(String hospCode, String bunho, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SUNAME ,A.SUNAME2 ,A.SEX                                         ");
		sql.append("      ,FN_BAS_LOAD_AGE(SYSDATE(), A.BIRTH,'') YEAR_AGE                    ");
		sql.append("      ,FN_BAS_LOAD_AGE_MONTH(SYSDATE(), A.BIRTH) MONTH_AGE                ");
		sql.append("      ,A.GUBUN ,FN_ADM_DICT_NM('GUBUN',A.GUBUN, :language)                ");
		sql.append("	  ,DATE_FORMAT(A.BIRTH,'%Y/%m/%d') ,A.TEL ,A.TEL1 ,A.TEL_HP           ");
		sql.append("      ,A.EMAIL ,A.ZIP_CODE1 ,A.ZIP_CODE2 ,A.ADDRESS1 ,A.ADDRESS2          ");
		sql.append("      ,IFNULL(FN_INP_JAEWON_CHECK(:hospCode,BUNHO),'N')                   ");
		sql.append("FROM OUT0101 A                                                            ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                                             ");
		sql.append("  AND A.BUNHO = :bunho                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("language", language);
		
		List<MultiResultViewLayPaInfo> list = new JpaResultMapper().list(query, MultiResultViewLayPaInfo.class);
		return list;
	}
	
	public ComboListItemInfo getPatientCodeName (String emrRecordId) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT BUNHO, 										");
		sql.append("	       CONCAT(SUNAME,'   ', SUNAME2)                ");
		sql.append("	FROM OUT0101                                        ");
		sql.append("	WHERE BUNHO = (                                     ");
		sql.append("	SELECT EMR_RECORD.BUNHO                             ");
		sql.append("	FROM EMR_RECORD                                     ");
		sql.append("	WHERE EMR_RECORD.EMR_RECORD_ID = :f_emr_record_id)  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_emr_record_id", emrRecordId);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<ORDERTRANSLayOut0101Info> getORDERTRANSLayOut0101Info(
			String hospCode, String language, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SUNAME                                                                        ");
		sql.append("      , A.SUNAME2                                                                       ");
		sql.append("      , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.BIRTH, :f_hosp_code, :f_language) BIRTH     ");
		sql.append("      , A.TEL                                                                           ");
		sql.append("      , FN_BAS_LOAD_CODE_NAME('SEX', A.SEX, :f_hosp_code, :f_language) SEX              ");
		sql.append("      , FN_BAS_LOAD_AGE(SYSDATE(), A.BIRTH,'') AGE                                      ");
		sql.append("      , A.IF_VALID_YN                                                                   ");
		sql.append("   FROM OUT0101 A                                                                       ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                    ");
		sql.append("    AND A.BUNHO       = :f_bunho														");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		List<ORDERTRANSLayOut0101Info> list = new JpaResultMapper().list(query, ORDERTRANSLayOut0101Info.class);
		return list;
	}

	@Override
	public List<OCS1003R02DTListItemInfo> getOCS1003R02DTListItemInfo(
			String hospCode, String language, String gwa, String naewonDate,
			String bunho, String doctor, String naewonType, String jubsuNo) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT :f_gwa                                                                    GWA                                                           ");
		sql.append(" ,FN_BAS_LOAD_GWA_NAME(:f_gwa, SYSDATE(), :f_hosp_code, :f_language)              GWA_NAME                                                      ");
		sql.append(" ,A.BUNHO                                                                         BUNHO                                                         ");
		sql.append(" ,A.SUNAME                                                                        SUNAME                                                        ");
		sql.append(" ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', SYSDATE(), :f_hosp_code, :f_language)         BALHEANG_DATE                                                 ");
		sql.append(" ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.BIRTH, :f_hosp_code, :f_language)           BIRTH                                                         ");
		sql.append(" ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', STR_TO_DATE(:f_naewon_date, '%Y/%m/%d'), :f_hosp_code, :f_language) NAEWON_DATE                             ");
		sql.append(" ,CONCAT('*', IFNULL(A.BUNHO, ''), '*')                                                               BUNHO_1                                   ");
		sql.append(" ,FN_NUR_DANGIL_GUMSA_RESULT_YN( :f_hosp_code, :f_naewon_date,:f_bunho,:f_gwa,:f_doctor,:f_naewon_type,:f_jubsu_no) DANGIL_GUMSA_RESULT_YN      ");
		sql.append(" FROM OUT0101 A                                                                                                                                 ");
		sql.append(" WHERE                                                                                                                                          ");
		sql.append("  A.BUNHO     = :f_bunho                                                                                                                        ");
		sql.append("  AND A.HOSP_CODE = :f_hosp_code																												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_naewon_type", naewonType);
		query.setParameter("f_jubsu_no", jubsuNo);
		List<OCS1003R02DTListItemInfo> list = new JpaResultMapper().list(query, OCS1003R02DTListItemInfo.class);
		return list;
	}
	
	@Override
	public List<OUT1001R01LayOut0101Info> getOUT1001R01LayOut0101Info(String hospCode, String bunho, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SUNAME, A.SUNAME2,                                                        ");
		sql.append("       FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.BIRTH,:f_hosp_code,:f_language) BIRTH   ");
		sql.append("   FROM OUT0101 A                                                                  ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                               ");
		sql.append("    AND A.BUNHO       = :f_bunho                                                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		List<OUT1001R01LayOut0101Info> list = new JpaResultMapper().list(query, OUT1001R01LayOut0101Info.class);
		return list;
	}
	@Override
	public List<OUT1001P03BunhoListItemInfo> getOUT1001P03BunhoListItemInfo(
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT  A.BUNHO																 ");
		sql.append("	      , A.SUNAME                                                             ");
		sql.append("	      , FN_BAS_LOAD_CODE_NAME('SEX', A.SEX, :hospCode, :language)   SEX      ");
		sql.append("	    FROM OUT0101 A                                                           ");
		sql.append("	   WHERE A.HOSP_CODE  =  :hospCode                                           ");
		sql.append("	     AND A.BUNHO_TYPE = '2'                                                  ");
		sql.append("	     AND A.BUNHO IN ( SELECT DISTINCT X.BUNHO                                ");
		sql.append("	                      FROM OUT1001 X                                         ");
		sql.append("	                     WHERE X.HOSP_CODE = A.HOSP_CODE                         ");
		sql.append("	                       AND IFNULL(X.NAEWON_YN, 'N') = 'N'                    ");
		sql.append("	                       AND X.NAEWON_DATE >= SYSDATE() )                      ");
		sql.append("	  ORDER BY A.BUNHO                                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<OUT1001P03BunhoListItemInfo> list = new JpaResultMapper().list(query, OUT1001P03BunhoListItemInfo.class);
		return list;
	}

	@Override
	public List<OUT1001P03GrdBeforeJubsuInfo> getOUT1001P03GrdBeforeJubsuInfo(String hospCode, String language, String ioGubun, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'O'                                                                   IO_GUBUN                                        ");
		sql.append("      , A.PKOUT1001                                                           PK_KEY                                          ");
		sql.append("      , A.BUNHO                                                               BUNHO                                           ");
		sql.append("      , B.SUNAME                                                              SUNAME                                          ");
		sql.append("      , A.NAEWON_DATE                                                         NAEWON_DATE                                     ");
		sql.append("      , A.GWA                                                                 GWA                                             ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA,A.NAEWON_DATE,:f_hosp_code,:f_language)    GWA_NAME                                        ");
		sql.append("      , A.DOCTOR                                                              DOCTOR                                          ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE,:f_hosp_code)         DOCTOR_NAME                                     ");
		sql.append("      , A.JUBSU_TIME                                                          NAEWON_TIME                                     ");
		sql.append("      , 'N'                                                                   SELECT_YN                                       ");
		sql.append("      , C.COMMENTS                                                            COMMENTS                                        ");
		sql.append("      , IFNULL(B.BUNHO_TYPE,'0')                                              BUNHO_TYPE                                      ");
		sql.append("      , IFNULL(A.RESER_YN, 'N')                                               RESER_YN                                        ");
		sql.append("      ,CONCAT( FN_BAS_LOAD_CODE_NAME('RESER_GUBUN',IFNULL(C.RESER_GUBUN,'O'),:f_hosp_code,:f_language) ,                      ");
		sql.append("          CASE WHEN C.UP_DOWN_GUBUN IS NOT NULL THEN                                                                          ");
		sql.append("            CONCAT('[',FN_BAS_LOAD_CODE_NAME('UP_DOWN_GUBUN', C.UP_DOWN_GUBUN,:f_hosp_code,:f_language),']')                  ");
		sql.append("          ELSE ''                                                                                                             ");
		sql.append("          END)                                                                RESER_GUBUN                                     ");
		sql.append("  FROM OUT1001 A LEFT JOIN OUT0123 C ON C.HOSP_CODE = A.HOSP_CODE AND C.FKOUT1001 = A.PKOUT1001 AND C.COMMENT_TYPE = '1'      ");
		sql.append("                 JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                            ");
		sql.append("  WHERE :f_io_gubun = 'O'                                                                                                     ");
		sql.append("    AND A.HOSP_CODE = :f_hosp_code                                                                                            ");
		sql.append("    AND A.BUNHO = :f_bunho                                                                                                    ");
		sql.append("    AND A.NAEWON_DATE >= DATE_FORMAT(SYSDATE(),'%Y/%m/%d')  																  ");
		sql.append("    UNION ALL                                                                                  								  ");
		sql.append(" SELECT 'I'                                                                   IO_GUBUN                                        ");
		sql.append("      , A.PKINP1001                                                           PK_KEY                                          ");
		sql.append("      , A.BUNHO                                                               BUNHO                                           ");
		sql.append("      , B.SUNAME                                                              SUNAME                                          ");
		sql.append("      , A.IPWON_DATE                                                          NAEWON_DATE                                     ");
		sql.append("      , A.GWA                                                                 GWA                                             ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA,A.IPWON_DATE,:f_hosp_code,:f_language)     GWA_NAME                                        ");
		sql.append("      , A.DOCTOR                                                              DOCTOR                                          ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.IPWON_DATE,:f_hosp_code)          DOCTOR_NAME                                     ");
		sql.append("      , A.IPWON_TIME                                                          NAEWON_TIME                                     ");
		sql.append("      , 'N'                                                                   SELECT_YN                                       ");
		sql.append("      , C.COMMENTS                                                            COMMENTS                                        ");
		sql.append("      , IFNULL(B.BUNHO_TYPE,'0')                                              BUNHO_TYPE                                      ");
		sql.append("      , 'N'                                                                   RESER_YN                                        ");
		sql.append("      , CONCAT(FN_BAS_LOAD_CODE_NAME('RESER_GUBUN',IFNULL(C.RESER_GUBUN,'O'),:f_hosp_code,:f_language) ,                      ");
		sql.append("          CASE WHEN C.UP_DOWN_GUBUN IS NOT NULL THEN                                                                          ");
		sql.append("            CONCAT('[',FN_BAS_LOAD_CODE_NAME('UP_DOWN_GUBUN', C.UP_DOWN_GUBUN,:f_hosp_code,:f_language),']')                  ");
		sql.append("          ELSE ''                                                                                                             ");
		sql.append("          END)                                                                RESER_GUBUN                                     ");
		sql.append("   FROM INP1001 A LEFT JOIN OUT0123 C ON C.HOSP_CODE = A.HOSP_CODE AND C.FKINP1001 = A.PKINP1001 AND C.COMMENT_TYPE = '1'     ");
		sql.append("                  JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                           ");
		sql.append("  WHERE :f_io_gubun = 'I'                                                                                                     ");
		sql.append("    AND A.HOSP_CODE = :f_hosp_code                                                                                            ");
		sql.append("    AND A.BUNHO = :f_bunho                                                                                                    ");
		sql.append("    AND IFNULL(A.CANCEL_YN, 'N') = 'N'                                                                                        ");
		sql.append("  ORDER BY 5 DESC, 10 DESC, 6, 8                                                                                              ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_bunho", bunho);
		List<OUT1001P03GrdBeforeJubsuInfo> list = new JpaResultMapper().list(query, OUT1001P03GrdBeforeJubsuInfo.class);
		return list;
	}
	
	@Override
	public List<OUT1001P03GrdAfterJubsuInfo> getOUT1001P03GrdAfterJubsuInfo(String hospCode, String language, String ioGubun, String bunho){
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT 'O'                                                                   IO_GUBUN                                        ");
		sql.append("      , A.PKOUT1001                                                           PK_KEY                                          ");
		sql.append("      , A.BUNHO                                                               BUNHO                                           ");
		sql.append("      , B.SUNAME                                                              SUNAME                                          ");
		sql.append("      , A.NAEWON_DATE                                                         NAEWON_DATE                                     ");
		sql.append("      , A.GWA                                                                 GWA                                             ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA,A.NAEWON_DATE,:f_hosp_code,:f_language)    GWA_NAME                                        ");
		sql.append("      , A.DOCTOR                                                              DOCTOR                                          ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE,:f_hosp_code)         DOCTOR_NAME                                     ");
		sql.append("      , A.JUBSU_TIME                                                          NAEWON_TIME                                     ");
		sql.append("      , C.COMMENTS                                                            COMMENTS                                        ");
		sql.append("      , IFNULL(B.BUNHO_TYPE,'0')                                              BUNHO_TYPE                                      ");
		sql.append("      , IFNULL(A.RESER_YN, 'N')                                               RESER_YN                                        ");
		sql.append("      ,CONCAT( FN_BAS_LOAD_CODE_NAME('RESER_GUBUN',IFNULL(C.RESER_GUBUN,'O'),:f_hosp_code,:f_language) ,                      ");
		sql.append("          CASE WHEN C.UP_DOWN_GUBUN IS NOT NULL THEN                                                                          ");
		sql.append("            CONCAT('[',FN_BAS_LOAD_CODE_NAME('UP_DOWN_GUBUN', C.UP_DOWN_GUBUN,:f_hosp_code,:f_language),']')                  ");
		sql.append("          ELSE ''                                                                                                             ");
		sql.append("          END)                                                                RESER_GUBUN                                     ");
		sql.append("  FROM OUT1001 A LEFT JOIN OUT0123 C ON C.HOSP_CODE = A.HOSP_CODE AND C.FKOUT1001 = A.PKOUT1001 AND C.COMMENT_TYPE = '1'      ");
		sql.append("                 JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                            ");
		sql.append("  WHERE :f_io_gubun = 'O'                                                                                                     ");
		sql.append("    AND A.HOSP_CODE = :f_hosp_code                                                                                            ");
		sql.append("    AND A.BUNHO = :f_bunho                                                                                                    ");
		sql.append("    AND A.NAEWON_DATE >= DATE_FORMAT(SYSDATE(),'%Y/%m/%d')                                                                    ");
		sql.append("    UNION ALL                                                                                                                 ");
		sql.append(" SELECT 'I'                                                                   IO_GUBUN                                        ");
		sql.append("      , A.PKINP1001                                                           PK_KEY                                          ");
		sql.append("      , A.BUNHO                                                               BUNHO                                           ");
		sql.append("      , B.SUNAME                                                              SUNAME                                          ");
		sql.append("      , A.IPWON_DATE                                                          NAEWON_DATE                                     ");
		sql.append("      , A.GWA                                                                 GWA                                             ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA,A.IPWON_DATE,:f_hosp_code,:f_language)     GWA_NAME                                        ");
		sql.append("      , A.DOCTOR                                                              DOCTOR                                          ");
		sql.append("      , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.IPWON_DATE,:f_hosp_code)          DOCTOR_NAME                                     ");
		sql.append("      , A.IPWON_TIME                                                          NAEWON_TIME                                     ");
		sql.append("      , C.COMMENTS                                                            COMMENTS                                        ");
		sql.append("      , IFNULL(B.BUNHO_TYPE,'0')                                              BUNHO_TYPE                                      ");
		sql.append("      , 'N'                                                                   RESER_YN                                        ");
		sql.append("      , CONCAT(FN_BAS_LOAD_CODE_NAME('RESER_GUBUN',IFNULL(C.RESER_GUBUN,'O'),:f_hosp_code,:f_language) ,                      ");
		sql.append("          CASE WHEN C.UP_DOWN_GUBUN IS NOT NULL THEN                                                                          ");
		sql.append("            CONCAT('[',FN_BAS_LOAD_CODE_NAME('UP_DOWN_GUBUN', C.UP_DOWN_GUBUN,:f_hosp_code,:f_language),']')                  ");
		sql.append("          ELSE ''                                                                                                             ");
		sql.append("          END)                                                                RESER_GUBUN                                     ");
		sql.append("   FROM INP1001 A LEFT JOIN OUT0123 C ON C.HOSP_CODE = A.HOSP_CODE AND C.FKINP1001 = A.PKINP1001 AND C.COMMENT_TYPE = '1'     ");
		sql.append("                  JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                           ");
		sql.append("  WHERE :f_io_gubun = 'I'                                                                                                     ");
		sql.append("    AND A.HOSP_CODE = :f_hosp_code                                                                                            ");
		sql.append("    AND A.BUNHO = :f_bunho                                                                                                    ");
		sql.append("    AND IFNULL(A.CANCEL_YN, 'N') = 'N'                                                                                        ");
		sql.append("  ORDER BY 5 DESC, 10 DESC, 6, 8                                                                                              ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_bunho", bunho);
		List<OUT1001P03GrdAfterJubsuInfo> list = new JpaResultMapper().list(query, OUT1001P03GrdAfterJubsuInfo.class);
		return list;
	}

	@Override
	public List<OCS1003R02LayR03ListInfo> getOCS1003R02LayR03ListInfo(
			String hospCode, String langauge, String gwa, String naewonDate,
			String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_BAS_LOAD_GWA_NAME(:f_gwa, SYSDATE(), :f_hosp_code, :f_language)                                    GWA_NAME      ");
		sql.append("       ,A.BUNHO                                                                         BUNHO                               ");
		sql.append("       ,A.SUNAME                                                                        SUNAME                              ");
		sql.append("       ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', SYSDATE(), :f_hosp_code, :f_language)                             BALHEANG_DATE   ");
		sql.append("       ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.BIRTH, :f_hosp_code, :f_language)                               BIRTH           ");
		sql.append("       ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', STR_TO_DATE(:f_naewon_date, '%Y/%m/%d'), :f_hosp_code, :f_language) NAEWON_DATE   ");
		sql.append("       ,CONCAT('*', IFNULL(A.BUNHO, ''), '*')                                                                BUNHO_1        ");
		sql.append("   FROM OUT0101 A                                                                                                           ");
		sql.append("  WHERE A.BUNHO     = :f_bunho                                                                                              ");
		sql.append("    AND A.HOSP_CODE = :f_hosp_code																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", langauge);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_bunho", bunho);
		List<OCS1003R02LayR03ListInfo> list = new JpaResultMapper().list(query, OCS1003R02LayR03ListInfo.class);
		return list;
	}

	@Override
	public List<CLIS2015U03PatientListInfo> getCLIS2015U03PatientListInfo(Integer protocolId) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT B.BUNHO ,                                             ");
		sql.append("	B.SUNAME ,                                                   ");
		sql.append("	B.SUNAME2 ,                                                  ");
		sql.append("	CONCAT(IFNULL(B.SUNAME,''),' ',IFNULL(B.SUNAME2,'')) ,       ");
		sql.append("	B.SEX ,                                                      ");
		sql.append("	 FN_BAS_LOAD_AGE(SYSDATE(), B.BIRTH,'')   ,                  ");
		sql.append("	CAST(A.CLIS_PROTOCOL_ID AS CHAR)                             ");
		sql.append("	FROM CLIS_PROTOCOL_PATIENT A, OUT0101 B                      ");
		sql.append("	WHERE A.CLIS_PROTOCOL_ID = :f_protocol_id                    ");
		sql.append("	AND B.HOSP_CODE = A.HOSP_CODE                                ");
		sql.append("	AND B.BUNHO = A.BUNHO                                        ");
		sql.append("	AND A.ACTIVE_FLG = '1'                                       ");
		sql.append("	ORDER BY B.BUNHO    				                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_protocol_id", protocolId);

		List<CLIS2015U03PatientListInfo> list = new JpaResultMapper().list(query, CLIS2015U03PatientListInfo.class);
		return list;
	}

	@Override
	public List<CLIS2015U03PatientListInfo> getCLIS2015U03SearchPatient(
			String hospCode, String sex, Integer fromAge, Integer toAge,
			Date naewonDateFrom, Date naewonDateTo, String makerYn,
			String join, String filterStringOutsang,
			String filterStringOcs1003, String filterStringView,
			String filterStringEmr, String filterCommandOutsang, String filterCommandOcs1003, String filterCommandView) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                ");
		sql.append(" OUT0101.BUNHO        ,                                                         ");
		sql.append(" OUT0101.SUNAME        ,                                                        ");
		sql.append(" OUT0101.SUNAME2,                                                               ");
		sql.append(" CONCAT(IFNULL(OUT0101.SUNAME,''),' ',IFNULL(OUT0101.SUNAME2,'')) FULL_NAME,    ");
		sql.append(" OUT0101.SEX                ,                                                   ");
		sql.append(" FN_BAS_LOAD_AGE(SYSDATE(),OUT0101.BIRTH,''),       ''  EMPTY_DATA              ");
		sql.append(" FROM OUT0101																	");
		if(naewonDateFrom != null && naewonDateTo != null){
			sql.append(" INNER JOIN OUT1001 ON OUT0101.BUNHO = OUT1001.BUNHO                        ");
			sql.append(" AND OUT1001.NAEWON_DATE BETWEEN :f_naewon_date_from AND :f_naewon_date_to  ");
			sql.append(" AND OUT1001.HOSP_CODE = :f_hosp_code									    ");
		}
		if(!StringUtils.isEmpty(filterStringOutsang)){
			sql.append(" INNER JOIN OUTSANG ON OUT0101.BUNHO = OUTSANG.BUNHO ");
		}
		if(!StringUtils.isEmpty(filterStringOcs1003)){
			sql.append(" INNER JOIN OCS1003 ON OUT0101.BUNHO = OCS1003.BUNHO ");
		}
		if(!StringUtils.isEmpty(filterStringView)){
			sql.append(" INNER JOIN VW_CPL_TEST_RESULT ON OUT0101.BUNHO = VW_CPL_TEST_RESULT.BUNHO ");
		}
		if(!StringUtils.isEmpty(filterStringEmr)){
			sql.append(" INNER JOIN EMR_RECORD ON OUT0101.BUNHO = EMR_RECORD.BUNHO                   ");
		}
		sql.append(" WHERE OUT0101.HOSP_CODE = :f_hosp_code                                         ");
		if(!StringUtils.isEmpty(sex)){
			sql.append(" AND OUT0101.SEX = :f_sex                                                    ");
		}
		if(fromAge != null && toAge != null){
			sql.append("AND FN_BAS_LOAD_AGE(SYSDATE(),OUT0101.BIRTH,'') BETWEEN :f_from_age and :f_to_age       ");
		}
		//TODO check sql injection latter
		//[START] break from Join
		if(!StringUtils.isEmpty(filterStringOutsang) && !StringUtils.isEmpty(filterCommandOutsang)){
			sql.append(filterCommandOutsang + " " + filterStringOutsang);
		}
		if(!StringUtils.isEmpty(filterStringOcs1003) && !StringUtils.isEmpty(filterCommandOcs1003)){
			sql.append(filterCommandOcs1003 + " " + filterStringOcs1003);
		}
		if(!StringUtils.isEmpty(filterStringView) && !StringUtils.isEmpty(filterCommandView)){
			sql.append(filterCommandView + " " + filterStringView);
		}
		if(!StringUtils.isEmpty(filterStringEmr)){
			sql.append(" AND " + filterStringEmr);
		}
		if ("Y".equals(makerYn))
		{
			sql.append(" AND (OUT0101.PACE_MAKER_YN = :makerYn OR OUT0101.SELF_PACE_MAKER = :makerYn)                   	");
		}else if("N".equals(makerYn)){
			//sql.append(" AND (IFNULL(OUT0101.PACE_MAKER_YN, 'N') = 'N' AND IFNULL(OUT0101.SELF_PACE_MAKER, 'N') = 'N' ) 	");
			sql.append(" AND (IF(OUT0101.PACE_MAKER_YN is null or OUT0101.PACE_MAKER_YN = '', 'N', OUT0101.PACE_MAKER_YN) = 'N' AND IF(OUT0101.SELF_PACE_MAKER is null or OUT0101.SELF_PACE_MAKER = '', 'N', OUT0101.SELF_PACE_MAKER) = 'N' )");
		}
		//[END] break from Join
		if("Y".equalsIgnoreCase(join)){
			sql.append(" AND EXISTS(                                                            ");
			sql.append("            SELECT  B.CLIS_PROTOCOL_ID                                  ");
			sql.append("            FROM  CLIS_PROTOCOL_PATIENT   A , CLIS_PROTOCOL  B          ");
			sql.append("            WHERE                                                       ");
			sql.append("                    B.HOSP_CODE = :f_hosp_code  AND                     ");
			sql.append("                    A.BUNHO = OUT0101.BUNHO    AND                      ");
			sql.append("                    B.ACTIVE_FLG = '1'       AND                        ");
			sql.append("                    A.CLIS_PROTOCOL_ID = B.CLIS_PROTOCOL_ID  AND        ");
			sql.append("                    B.STATUS_FLG IN ('03', '01')      AND               ");
			sql.append("                    A.ACTIVE_FLG = '1'    AND                           ");
			sql.append("                    A.HOSP_CODE = :f_hosp_code                          ");
			sql.append("    )																	");
		}else if("N".equalsIgnoreCase(join)){
			sql.append(" AND NOT EXISTS                                     ");
			sql.append("         ( SELECT  B.CLIS_PROTOCOL_ID               ");
			sql.append("             FROM CLIS_PROTOCOL_PATIENT B           ");
			sql.append("             WHERE                                  ");
			sql.append("             B.HOSP_CODE = :f_hosp_code  AND        ");
			sql.append("             B.BUNHO = OUT0101.BUNHO   AND          ");
			sql.append("             B.ACTIVE_FLG = '1'                     ");
			sql.append("         )											");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(naewonDateFrom != null && naewonDateTo != null){
			query.setParameter("f_naewon_date_from", naewonDateFrom);
			query.setParameter("f_naewon_date_to", naewonDateTo);
		}
		if(!StringUtils.isEmpty(sex)){
			query.setParameter("f_sex", sex);
		}
		if(fromAge != null && toAge != null){
			query.setParameter("f_from_age", fromAge);
			query.setParameter("f_to_age", toAge);
		}
		if ("Y".equals(makerYn))
		{
			query.setParameter("makerYn", makerYn);
		}
		
		List<CLIS2015U03PatientListInfo> list = new JpaResultMapper().list(query, CLIS2015U03PatientListInfo.class);
		return list;
	}

	@Override
	public String getLatestBunho() {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT MAX(BUNHO) from OUT0101  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){
			return results.get(0);
		}
		return null;
	}

	@Override
	public OCS2015U00GetPatientInfo getOCS2015U00GetPatientInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT   SUNAME ,                                                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("  DATE_FORMAT(BIRTH,'%Y/%m/%d') ,                                                 ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		sql.append("     SEX         ,                                                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
		sql.append("    IF(ADDRESS1 IS NULL OR ADDRESS1 = '',ADDRESS2 ,ADDRESS1)    ,                 ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
		sql.append("     TEL                                                                          ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("    FROM   OUT0101                                                                ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("    WHERE   BUNHO   =  :bunho                                                     ");                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("    AND HOSP_CODE   =  :hosp_code                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);

		List<OCS2015U00GetPatientInfo> list = new JpaResultMapper().list(query, OCS2015U00GetPatientInfo.class);
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<RES1001R00PatientNameInfo> getRES1001R00PatientName(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SUNAME,  DATE_FORMAT(A.BIRTH,'%Y/%m/%d'),                          ");
		sql.append(" DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(A.BIRTH, '%Y') AS age                ");
		sql.append(" FROM OUT0101 A, OUT2016 B                                                   ");
		sql.append(" WHERE A.BUNHO = B.BUNHO                                                     ");
		sql.append(" AND B.BUNHO_LINK = :bunho                                                   ");
		sql.append(" AND A.HOSP_CODE = :hospCode                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);

		List<RES1001R00PatientNameInfo> list = new JpaResultMapper().list(query, RES1001R00PatientNameInfo.class);
		return list;
	}

	@Override
	public List<NUR2016Q00GrdPatientListInfo> getNUR2016Q00GrdPatientListInfo(String hospCode, String sunName, String sunName2, String address, Date birth,
			 Integer startNum, Integer offset, String sesionHospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		//sql.append(" SELECT BUNHO ,CONCAT(SUNAME, SUNAME2) PATIENT_NAME , CONCAT(IFNULL(ADDRESS1,'') , ' ' , IFNULL(ADDRESS2,'')), BIRTH, SUNAME, SUNAME2, SEX, TEL	");
		//sql.append(" FROM OUT0101 WHERE SUNAME2 like :f_suname2    																									");
		sql.append("	SELECT A.BUNHO ,CONCAT(A.SUNAME, A.SUNAME2) PATIENT_NAME , CONCAT(IFNULL(A.ADDRESS1,'') , ' '							");
		sql.append("	      ,IFNULL(A.ADDRESS2,'')), A.BIRTH, A.SUNAME, A.SUNAME2, A.SEX, A.TEL												");
		sql.append("	      ,CASE WHEN B.EMR_LINK_FLG = 1 THEN 'Y' ELSE 'N' END AS EMR_LINK_FLG												");
		sql.append("	FROM OUT0101 A 																											");
		sql.append("	LEFT JOIN OUT2016 B ON A.HOSP_CODE = B.HOSP_CODE_LINK																	");
		sql.append("	              AND A.BUNHO = B.BUNHO_LINK																				");
		sql.append("				  AND B.HOSP_CODE = :f_sesion_hosp_code																		");
		sql.append("				  AND B.BUNHO = :f_bunho																					");
		sql.append("				  AND B.ACTIVE_FLG = 1																						");
		sql.append("	WHERE FN_ADM_CONVERT_KATAKANA_FULL(A.SUNAME2,:hospCode)  like :f_suname2					            				");
		if(birth == null){
			sql.append(" AND A.BIRTH is null 						 																			");
		}else{
			sql.append(" AND A.BIRTH = :f_birth 						 																		");
		}
		sql.append(" AND A.HOSP_CODE = :hospCode 																            					");
		sql.append(" limit :startNum, :offset 																		    						");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_suname2", StringUtils.isEmpty(sunName2) ? "%" : "%" + sunName2 + "%");
		if(birth != null){
			query.setParameter("f_birth", birth);
		}
		
		query.setParameter("f_sesion_hosp_code", sesionHospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("startNum", startNum);
		query.setParameter("offset", offset);
		
		List<NUR2016Q00GrdPatientListInfo> list = new JpaResultMapper().list(query, NUR2016Q00GrdPatientListInfo.class);
		return list;
	}
	
	@Override
	public List<NuroOUT0101U02HospitalItemInfo> getNuroOUT0101U02HospitalListInfo(String hospitalCode, String language, String bunho){
		
		StringBuilder sql = new StringBuilder();
		sql.append("	select A.YOYANG_NAME, A.ADDRESS, A.TEL, B.PWD, B.SUNAME	 ");
		sql.append("	from BAS0001 A, OUT0101 B                             	 ");
		sql.append("	where A.HOSP_CODE = B.HOSP_CODE                          ");
		sql.append("	AND A.HOSP_CODE = :hospitalCode                          ");
		sql.append("	AND A.LANGUAGE = :language                             	 ");
		sql.append("	AND B.BUNHO = :bunho                             	     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		
		List<NuroOUT0101U02HospitalItemInfo> list = new JpaResultMapper().list(query, NuroOUT0101U02HospitalItemInfo.class);

		return list;
	}

	@Override
	public List<SCH0201U99BookingDetailInfo> getSCH0201U99BookingDetailInfo(String hospCode, String language,  String reservation,
			String jundalTable, String jundalPart, Date reserDate, List<String> bunho, List<String> hospCodeLink) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  A.BUNHO                                                                                        						");
		sql.append("   ,A.SUNAME                                                                                            						");
		sql.append("   ,A.BIRTH                                                                                             						");
		sql.append("   ,A.SEX                                                                                               						");
		sql.append("   ,B.HOSP_CODE                                                                                         						");
		sql.append("   ,B.YOYANG_NAME                                                                                       						");
		sql.append("   ,B.TEL                                                                                               						");
		sql.append("   ,C.RESER_DATE                                                                                        						");
		sql.append("   ,C.RESER_TIME                                                                                        						");
		sql.append("   ,CONCAT(IFNULL(DATE_FORMAT(C.RESER_DATE , '%Y/%m/%d'),''),' ',IFNULL(C.RESER_TIME,'')) BOOKING_DATE  						");
		sql.append("   ,C.OUT_HOSP_CODE                                                                                     						");
		sql.append("   ,C.HANGMOG_CODE                                                                                      						");
		sql.append("   ,IFNULL(X.EMR_LINK_FLG, 0)                                                                           						");
		sql.append("  FROM OUT0101 A LEFT OUTER JOIN SCH0201 C ON A.BUNHO = C.BUNHO  AND A.HOSP_CODE = C.HOSP_CODE                                	");
		sql.append("  LEFT OUTER JOIN BAS0001 B ON B.HOSP_CODE = C.OUT_HOSP_CODE                                            						");
		sql.append("  LEFT OUTER JOIN                                                                                       						");
		sql.append("  (                                                                                                     						");
		sql.append("   SELECT A.BUNHO , A.EMR_LINK_FLG                                                                      						");
		sql.append("   FROM                                                                                                 						");
		sql.append("    OUT2016 A  LEFT OUTER JOIN OUT0101 B ON A.BUNHO = B.BUNHO   AND A.HOSP_CODE = B.HOSP_CODE                          			");
		sql.append("   WHERE                                                                                                						");
		sql.append("    A.BUNHO IN (:bunho)                                                                                 						");
		sql.append("    AND A.HOSP_CODE = :hosp_code                                                                        						");
		sql.append("    AND A.HOSP_CODE_LINK IN (:hosp_code_link)                                                           						");
		sql.append("  ) X ON A.BUNHO = X.BUNHO                                                                              						");
		sql.append("  WHERE                                                                                                 						");
		sql.append("   C.UPD_DATE         = (SELECT MAX(C.UPD_DATE) FROM SCH0201 S WHERE S.HOSP_CODE = C.HOSP_CODE AND S.BUNHO = C.BUNHO            ");
		sql.append(" AND S.HANGMOG_CODE = C.HANGMOG_CODE AND S.RESER_DATE    =  C.RESER_DATE)                                                    	");
		sql.append("   AND B.START_DATE       = (SELECT MAX(E.START_DATE) FROM BAS0001 E WHERE E.HOSP_CODE = B.HOSP_CODE AND LANGUAGE = :language)  ");
		sql.append("   AND C.HOSP_CODE       = :hosp_code                                                                   						");
		sql.append("   AND C.RESER_YN         = 'Y'                                                                         						");
		sql.append("   AND C.CANCEL_YN       = 'N'                                                                          						");
		sql.append("   AND C.JUNDAL_TABLE       = :f_jundal_table                                                           						");
		sql.append("   AND C.JUNDAL_PART      = :f_jundal_part 																						");
		if("D".equals(reservation)){
			sql.append("           AND   C.RESER_TIME IS NULL										     		        				 			");
		}else if("T".equals(reservation)){
			sql.append("           AND C.RESER_TIME IS NOT NULL												        	     			 			");
		}
		sql.append("   AND C.RESER_DATE    = :f_reser_date						        															 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("bunho", bunho);
		query.setParameter("hosp_code_link", hospCodeLink);
		query.setParameter("f_jundal_table", jundalTable);
		query.setParameter("f_jundal_part", jundalPart);
		
		List<SCH0201U99BookingDetailInfo> list = new JpaResultMapper().list(query, SCH0201U99BookingDetailInfo.class);
		return list;
	}

	@Override
	public List<Schs0201U99InsertResultInfo> getSchs0201U99InsertResultInfo(String hospCode, String pkOut) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DOCTOR, GWA, HOSP_CODE, BUNHO FROM OUT1001  PKOUT1001 = :pkOut  AND HOSP_CODE = :f_hosp_code");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("pkOut", pkOut);
		query.setParameter("f_hosp_code", hospCode);

		List<Schs0201U99InsertResultInfo> schs0201U99InsertResultInfos =  new JpaResultMapper().list(query, Schs0201U99InsertResultInfo.class);


		return schs0201U99InsertResultInfos;

	}

	@Override
	public PatientAccountInfo verifyPatientAccount(String username, String password, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  B.HOSP_CODE, B.YOYANG_NAME, A.BUNHO															");
		sql.append(" FROM    OUT0101 A, BAS0001 B																			");
		sql.append(" WHERE   A.HOSP_CODE = :f_hosp_code																		");
		sql.append("   AND   B.HOSP_CODE = :f_hosp_code																		");
		sql.append("   AND   B.START_DATE = (SELECT MAX(B1.START_DATE) FROM BAS0001 B1 WHERE B1.HOSP_CODE = :f_hosp_code)	");
		sql.append("   AND   A.BUNHO = :f_bunho																				");
		sql.append("   AND   A.PWD = :f_pwd																					");
		sql.append(" LIMIT 1																								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", username);
		query.setParameter("f_pwd", password);
		
		List<PatientAccountInfo> listData =  new JpaResultMapper().list(query, PatientAccountInfo.class);
		return !CollectionUtils.isEmpty(listData) ? listData.get(0) : null; 
	}
	
	@Override
	public List<PatientDetailInfo> getPatientDetailResultInfo(String hospCode, String diseaseName, String fromLastestGoHospital, String toLastestGoHospital, Integer fromPatientAge, Integer toPatientAge, String patientSex, String statusOfDisease, String patientContact, 
			Integer pageSize, Integer pageIndex, String column, String dir) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT  	DATE_FORMAT(MAX(C.NAEWON_DATE), '%Y/%m/%d') lastestGoHospital,			");
		//sql.append("   			B.SANG_NAME 								diseaseName,            ");
		sql.append("   			GROUP_CONCAT(DISTINCT B.SANG_NAME SEPARATOR ',')	diseaseName,        ");
		sql.append("   			A.SUNAME 									patientName,                ");
		sql.append("   			A.SEX 										patientSex,                 ");
		sql.append("   			DATE_FORMAT(A.BIRTH, '%Y/%m/%d') 			birth,                      ");
		sql.append("   			TIMESTAMPDIFF(YEAR, A.BIRTH, CURDATE())  	patientAge,                 ");
		sql.append("   			A.EMAIL 									patientEmail,               ");
		sql.append("   			A.TEL 										patientTel,		            ");
		sql.append("   			B.SANG_END_SAYU                                                         ");
		sql.append("   FROM OUT0101 A , OUTSANG B, OUT1001 C											");
		sql.append("   WHERE A.HOSP_CODE = :hospCode													");
		sql.append("         AND A.HOSP_CODE = B.HOSP_CODE												");
		sql.append("         AND A.BUNHO = B.BUNHO														");
		sql.append("         AND A.HOSP_CODE = C.HOSP_CODE												");
		sql.append("         AND A.BUNHO = C.BUNHO														");
		if(!StringUtils.isEmpty(patientContact)){
			if(patientContact.equals(PatientContact.EMAIL.getValue()) || patientContact.equals(PatientContact.ALL.getValue())){
				sql.append("         AND A.EMAIL IS NOT NULL													");
				sql.append("         AND TRIM(A.EMAIL) <>  ''													");
			}
			if(patientContact.equals(PatientContact.PHONE.getValue()) || patientContact.equals(PatientContact.ALL.getValue())){
				sql.append("         AND A.TEL IS NOT NULL														");
				sql.append("         AND TRIM(A.TEL) <>  ''														");
			}
		}
		if(!StringUtils.isEmpty(diseaseName)){
			sql.append("         AND B.SANG_NAME LIKE :f_disease_name									");
		}
		if(!StringUtils.isEmpty(fromLastestGoHospital)){
			sql.append("         AND DATE_FORMAT(C.NAEWON_DATE, '%Y/%m/%d') >= :f_from_lastest_go_hosp	");
		}
		if(!StringUtils.isEmpty(toLastestGoHospital)){
			sql.append("         AND DATE_FORMAT(C.NAEWON_DATE, '%Y/%m/%d') <= :f_to_lastest_go_hosp	");
		}
		if(!StringUtils.isEmpty(statusOfDisease)){
			sql.append("         AND B.SANG_END_SAYU = :f_status_of_disease									");
		} else {
			sql.append("         AND B.SANG_END_SAYU <> '3'													");
		}
		if(!StringUtils.isEmpty(patientSex)){
			sql.append("         AND A.SEX = :f_patient_sex													");	
		}
		if(fromPatientAge != null && fromPatientAge >= 0){
			sql.append("         AND TIMESTAMPDIFF(YEAR, A.BIRTH, CURDATE()) >= :f_from_patient_age			");
		}
		if(toPatientAge != null && toPatientAge >= 0){
			sql.append("         AND TIMESTAMPDIFF(YEAR, A.BIRTH, CURDATE()) <= :f_to_patient_age			");
		}
		sql.append(" 		  GROUP BY C.BUNHO																");
		if(!StringUtils.isEmpty(column)) {
			sql.append("  	  ORDER BY " + column + " " + dir);
		}
		sql.append(" limit :f_page_index, :f_page_size 													");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);	
		if(!StringUtils.isEmpty(diseaseName)){
			query.setParameter("f_disease_name", "%" + diseaseName + "%");
		}
		if(!StringUtils.isEmpty(fromLastestGoHospital)){
			query.setParameter("f_from_lastest_go_hosp", fromLastestGoHospital);	
		}
		if(!StringUtils.isEmpty(toLastestGoHospital)){
			query.setParameter("f_to_lastest_go_hosp", toLastestGoHospital);	
		}
		if(!StringUtils.isEmpty(statusOfDisease)){
			query.setParameter("f_status_of_disease", statusOfDisease);	
		}
		if(!StringUtils.isEmpty(patientSex)){
			query.setParameter("f_patient_sex", patientSex);
		}
		if(fromPatientAge != null && fromPatientAge >= 0){
			query.setParameter("f_from_patient_age", fromPatientAge);	
		}
		if(toPatientAge != null && toPatientAge >= 0){
			query.setParameter("f_to_patient_age", toPatientAge);	
		}
		query.setParameter("f_page_index", pageIndex);
		query.setParameter("f_page_size", pageSize);
		List<PatientDetailInfo> info =  new JpaResultMapper().list(query, PatientDetailInfo.class);
		return info;
	}
	
	
	@Override
	public BigInteger getTotalRecord(String hospCode, String diseaseName, String fromLastestGoHospital, String toLastestGoHospital, Integer fromPatientAge, Integer toPatientAge, String patientSex, String statusOfDisease, String patientContact){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT  	COUNT(1)																");
		sql.append("   FROM (																			");
		sql.append("   SELECT  	DATE_FORMAT(MAX(C.NAEWON_DATE), '%Y/%m/%d'),							");
		//sql.append("   			B.SANG_NAME ,                                                       ");
		sql.append("   			GROUP_CONCAT(DISTINCT B.SANG_NAME SEPARATOR ',') ,						");
		sql.append("   			A.SUNAME ,                                                              ");
		sql.append("   			A.SEX ,                                                                 ");
		sql.append("   			DATE_FORMAT(A.BIRTH, '%Y/%m/%d') ,                                      ");
		sql.append("   			TIMESTAMPDIFF(YEAR, A.BIRTH, CURDATE())  ,                        		");
		sql.append("   			A.EMAIL ,                                                               ");
		sql.append("   			B.SANG_END_SAYU                                                         ");
		sql.append("   FROM OUT0101 A , OUTSANG B, OUT1001 C											");
		sql.append("   WHERE A.HOSP_CODE = :hospCode													");
		sql.append("         AND A.HOSP_CODE = B.HOSP_CODE												");
		sql.append("         AND A.BUNHO = B.BUNHO														");
		sql.append("         AND A.HOSP_CODE = C.HOSP_CODE												");
		sql.append("         AND A.BUNHO = C.BUNHO														");
		if(!StringUtils.isEmpty(patientContact)){
			if(patientContact.equals(PatientContact.EMAIL.getValue()) || patientContact.equals(PatientContact.ALL.getValue())){
				sql.append("         AND A.EMAIL IS NOT NULL													");
				sql.append("         AND TRIM(A.EMAIL) <>  ''													");
			}
			if(patientContact.equals(PatientContact.PHONE.getValue()) || patientContact.equals(PatientContact.ALL.getValue())){
				sql.append("         AND A.TEL IS NOT NULL														");
				sql.append("         AND TRIM(A.TEL) <>  ''														");
			}
		}
		if(!StringUtils.isEmpty(diseaseName)){
			sql.append("         AND B.SANG_NAME LIKE :f_disease_name										");
		}
		if(!StringUtils.isEmpty(fromLastestGoHospital)){
			sql.append("         AND DATE_FORMAT(C.NAEWON_DATE, '%Y/%m/%d') >= :f_from_lastest_go_hosp		");
		}
		if(!StringUtils.isEmpty(toLastestGoHospital)){
			sql.append("         AND DATE_FORMAT(C.NAEWON_DATE, '%Y/%m/%d') <= :f_to_lastest_go_hosp		");
		}
		if(!StringUtils.isEmpty(statusOfDisease)){
			sql.append("         AND B.SANG_END_SAYU = :f_status_of_disease									");
		} else {
			sql.append("         AND B.SANG_END_SAYU <> '3'													");
		}
		if(!StringUtils.isEmpty(patientSex)){
			sql.append("         AND A.SEX = :f_patient_sex													");	
		}
		if(fromPatientAge != null && fromPatientAge >= 0){
			sql.append("         AND TIMESTAMPDIFF(YEAR, A.BIRTH, CURDATE()) >= :f_from_patient_age			");
		}
		if(toPatientAge != null && toPatientAge >= 0){
			sql.append("         AND TIMESTAMPDIFF(YEAR, A.BIRTH, CURDATE()) <= :f_to_patient_age			");
		}
		sql.append(" 		  GROUP BY C.BUNHO																");
		sql.append(" 	) D																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);	
		if(!StringUtils.isEmpty(diseaseName)){
			query.setParameter("f_disease_name", "%" + diseaseName + "%");
		}
		if(!StringUtils.isEmpty(fromLastestGoHospital)){
			query.setParameter("f_from_lastest_go_hosp", fromLastestGoHospital);	
		}
		if(!StringUtils.isEmpty(toLastestGoHospital)){
			query.setParameter("f_to_lastest_go_hosp", toLastestGoHospital);	
		}
		if(!StringUtils.isEmpty(statusOfDisease)){
			query.setParameter("f_status_of_disease", statusOfDisease);	
		}
		if(!StringUtils.isEmpty(patientSex)){
			query.setParameter("f_patient_sex", patientSex);
		}
		if(fromPatientAge != null && fromPatientAge >= 0){
			query.setParameter("f_from_patient_age", fromPatientAge);	
		}
		if(toPatientAge != null && toPatientAge >= 0){
			query.setParameter("f_to_patient_age", toPatientAge);	
		}
		List<BigInteger> list = query.getResultList();
		if(list != null && list.size() > 0 ){
			return list.get(0);
		}
		return null;
	
	}

	@Override
	public List<OCSACT2GetPatientListOCSInfo> getOCSACT2GetPatientListOCSInfo(String hospCode, String language,
			String bunho, Date fromDate, Date toDate, String actGubun, String code, List<String> jundalPartParam,
			String iOGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                                   				 ");
		sql.append("        'O'                                                IN_OUT_GUBUN                                                                                           				 ");
		sql.append("       , A.BUNHO                                           BUNHO                                                                                                  				 ");
		sql.append("       , B.SUNAME                                          SUNAME                                                                                                 				 ");
		sql.append("       , B.SUNAME2                                         SUNAME2                                                                                                				 ");
		sql.append("       , A.GWA                                             GWA                                                                                                    				 ");
		sql.append("       , FN_BAS_LOAD_GWA_NAME(A.GWA, A.SYS_DATE,:f_hosp_code,:f_language)           GWA_NAME                                                                      				 ");
		sql.append("       , A.DOCTOR                                          DOCTOR                                                                                                 				 ");
		sql.append("       , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE,:f_hosp_code)     DOCTOR_NAME                                                                               				 ");
		sql.append("       , A.JUNDAL_TABLE                                    JUNDAL_TABLE                                                                                           				 ");
		sql.append("       ,CASE WHEN A.RESER_DATE IS NULL THEN 'N' ELSE 'Y' END RESER_YN                                                                                             				 ");
		sql.append("       , A.EMERGENCY                                                                                                                                              				 ");
		sql.append("       , IF(F.NUM_PROTOCOL IS NULL ,'N','Y')                                                                                                                      				 ");
		sql.append("       , A.PKOCS1003 , A.FKOUT1001                                                                                                                      			        	 ");
		sql.append("    FROM OUT0101 B                                                                                                                                                				 ");
		sql.append("       , OCS1003 A                                                                                                                                                				 ");
		sql.append("       LEFT JOIN (SELECT D.CLIS_PROTOCOL_ID NUM_PROTOCOL  , D.HOSP_CODE HOSP_CODE   , D.BUNHO BUNHO                                                               				 ");
		sql.append("       FROM CLIS_PROTOCOL_PATIENT D LEFT JOIN CLIS_PROTOCOL E ON D.CLIS_PROTOCOL_ID = E.CLIS_PROTOCOL_ID AND D.HOSP_CODE = E.HOSP_CODE                            				 ");
		sql.append("       WHERE D.HOSP_CODE = :f_hosp_code                                                                                                                           				  ");
		sql.append("       AND D.ACTIVE_FLG = 1                                                                                                                                       				 ");
		sql.append("       AND E.ACTIVE_FLG = 1                                                                                                                                       				 ");
		sql.append("       AND E.STATUS_FLG <> 1                                                                                                                                      				 ");
		sql.append("       AND E.END_DATE >= SYSDATE()) F ON F.HOSP_CODE = A.HOSP_CODE AND F.BUNHO = A.BUNHO                                                                          				 ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                               				 ");
		sql.append("         AND ((:f_bunho IS NULL AND IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date)           				 ");
		sql.append("          OR (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))                                                                                                       				 ");
		sql.append("         AND ( ( :f_act_gubun = '1' )                                                                                                                             				 ");
		sql.append("          OR ( :f_act_gubun = '2' AND A.ACTING_DATE IS NULL )                                                                                                     				 ");
		sql.append("          OR ( :f_act_gubun = '3' AND A.ACTING_DATE IS NOT NULL ) )                                                                                               				 ");
		sql.append("         AND A.JUNDAL_TABLE   = (SELECT X.MENT                                                                                                                    				 ");
		sql.append("                                   FROM OCS0132 X                                                                                                                 				 ");
		sql.append("                                  WHERE X.HOSP_CODE = :f_hosp_code                                                                                                				 ");
		sql.append("                                    AND X.LANGUAGE  = :f_language                                                                                                 				 ");
		sql.append("                                    AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'                                                                                            				 ");
		sql.append("                                    AND X.CODE      = :f_code)                                                                                                    				 ");
		if(!CollectionUtils.isEmpty(jundalPartParam))
		{
			sql.append("         AND A.JUNDAL_PART    IN ( :jundal_part_param )                                                                                                           			  ");
		}

		sql.append("         AND :f_io_gubun      IN ('1','2','4')                                                                                                                    				 ");
		sql.append("         AND ( (:f_io_gubun   = '4' AND EXISTS (SELECT 'X' FROM OUT1001 X WHERE X.NAEWON_DATE = STR_TO_DATE(DATE_FORMAT(SYSDATE(),'%Y%m%d'),'%Y%m%d') AND X.BUNHO = A.BUNHO))    ");
		sql.append("          OR :f_io_gubun   <> '4' )                                                                                                                                              ");
		sql.append("         AND A.DC_YN          = 'N'                                                                                                                                              ");
		sql.append("         AND A.NALSU          > 0     AND (A.JUNDAL_TABLE = 'TST' OR A.JUNDAL_TABLE = 'PFE')                                                                                     ");
		sql.append("         AND B.HOSP_CODE      = A.HOSP_CODE                                                                                                                                      ");
		sql.append("         AND B.BUNHO          = A.BUNHO                                                                                                                                          ");
		sql.append(" UNION                                                                                                                                                                           ");
		sql.append(" SELECT DISTINCT                                                                                                                                                                 ");
		sql.append("        'I'                                                IN_OUT_GUBUN                                                                                                          ");
		sql.append("       , A.BUNHO                                           BUNHO                                                                                                                 ");
		sql.append("       , C.SUNAME                                          SUNAME                                                                                                                ");
		sql.append("       , C.SUNAME2                                         SUNAME2                                                                                                               ");
		sql.append("       , B.GWA                                             GWA                                                                                                                   ");
		sql.append("       , FN_BAS_LOAD_GWA_NAME(B.GWA, A.SYS_DATE,:f_hosp_code,:f_language)           GWA_NAME                                                                                     ");
		sql.append("       , A.DOCTOR                                          DOCTOR                                                                                                                ");
		sql.append("       , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE,:f_hosp_code)     DOCTOR_NAME                                                                                              ");
		sql.append("       , A.JUNDAL_TABLE                                    JUNDAL_TABLE                                                                                                          ");
		sql.append("       ,CASE WHEN A.RESER_DATE IS NULL THEN 'N' ELSE 'Y' END RESER_YN                                                                                                            ");
		sql.append("       , A.EMERGENCY                                                                                                                                                             ");
		sql.append("       , IF(F.NUM_PROTOCOL IS NULL ,'N','Y')                                                                                                                                     ");
		sql.append("       , CAST(null as DECIMAL) ,  CAST(null as DECIMAL)                                                                                                                     	 ");
		sql.append("    FROM OUT0101 C                                                                                                                                                               ");
		sql.append("       , INP1001 B                                                                                                                                                               ");
		sql.append("       , OCS2003 A                                                                                                                                                               ");
		sql.append("       LEFT JOIN (SELECT D.CLIS_PROTOCOL_ID NUM_PROTOCOL  , D.HOSP_CODE HOSP_CODE ,  D.BUNHO BUNHO                                                                              ");
		sql.append("       FROM CLIS_PROTOCOL_PATIENT D LEFT JOIN CLIS_PROTOCOL E ON D.CLIS_PROTOCOL_ID = E.CLIS_PROTOCOL_ID AND D.HOSP_CODE = E.HOSP_CODE                                           ");
		sql.append("       WHERE D.HOSP_CODE = :f_hosp_code                                                                                                                                           ");
		sql.append("       AND D.ACTIVE_FLG = 1                                                                                                                                                      ");
		sql.append("       AND E.ACTIVE_FLG = 1                                                                                                                                                      ");
		sql.append("       AND E.STATUS_FLG <> 1                                                                                                                                                     ");
		sql.append("       AND E.END_DATE >= SYSDATE()) F ON F.HOSP_CODE = A.HOSP_CODE  AND F.BUNHO = A.BUNHO                                                                                        ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                                              ");
		sql.append("     AND ((:f_bunho IS NULL AND IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date)                              ");
		sql.append("      OR (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))                                                                                                                          ");
		sql.append("     AND ( ( :f_act_gubun = '1' )                                                                                                                                                ");
		sql.append("      OR ( :f_act_gubun = '2' AND A.ACTING_DATE IS NULL )                                                                                                                        ");
		sql.append("      OR ( :f_act_gubun = '3' AND A.ACTING_DATE IS NOT NULL ) )                                                                                                                  ");
		sql.append("     AND A.JUNDAL_TABLE   = (SELECT X.MENT                                                                                                                                       ");
		sql.append("                               FROM OCS0132 X                                                                                                                                    ");
		sql.append("                              WHERE X.HOSP_CODE = :f_hosp_code                                                                                                                   ");
		sql.append("                                AND X.LANGUAGE  = :f_language                                                                                                                    ");
		sql.append("                                AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'                                                                                                               ");
		sql.append("                                AND X.CODE      = :f_code)                                                                                                                       ");

		if(!CollectionUtils.isEmpty(jundalPartParam))
		{
			sql.append("         AND A.JUNDAL_PART    IN (:jundal_part_param)                                                                                  										  ");
		}
		sql.append("     AND :f_io_gubun      IN ('1','3')                                                                                                                                           ");
		sql.append("     AND ( (:f_io_gubun = '4' AND EXISTS (SELECT 'X' FROM OUT1001 X WHERE X.NAEWON_DATE = STR_TO_DATE(DATE_FORMAT(SYSDATE(),'%Y%m%d'),'%Y%m%d') AND X.BUNHO = A.BUNHO))                                        ");
		sql.append("      OR :f_io_gubun <> '4' )                                                                                                                                      				 ");
		sql.append("     AND A.DC_YN = 'N'                                                                                                                                             				 ");
		sql.append("     AND A.NALSU > 0                                                                                                                                               				 ");
		sql.append("     AND B.HOSP_CODE      = A.HOSP_CODE                                                                                                                            				 ");
		sql.append("     AND B.PKINP1001      = A.FKINP1001                                                                                                                            				 ");
		sql.append("     AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                            				 ");
		sql.append("     AND C.BUNHO          = A.BUNHO                                                                                                                                				 ");
		sql.append("    ORDER BY 1,2,3,6											                                                                                                   				 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());                                                                                                                 
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", StringUtils.isEmpty(bunho) ? null : bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_act_gubun", actGubun);
		query.setParameter("f_code", code);
		if(!CollectionUtils.isEmpty(jundalPartParam))
		{
			query.setParameter("jundal_part_param", jundalPartParam);
		}

		query.setParameter("f_io_gubun", iOGubun);
		List<OCSACT2GetPatientListOCSInfo> list = new JpaResultMapper().list(query, OCSACT2GetPatientListOCSInfo.class);
		return list;
	}

	@Override
	public List<OUT0101U02PatientExportInfo> getOUT0101U02PatientExportInfo(String hospCode, Date fromDate, Date toDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(SYS_DATE,'%Y/%m/%d'),   ");
		sql.append("     SYS_ID,                            ");
		sql.append("     DATE_FORMAT(UPD_DATE, '%Y/%m/%d'), ");
		sql.append("     UPD_ID,                            ");
		sql.append("     HOSP_CODE,                         ");
		sql.append("     BUNHO,                             ");
		sql.append("     SUNAME,                            ");
		sql.append("     SUNAME2,                           ");
		sql.append("     SEX,                               ");
		sql.append("     DATE_FORMAT(BIRTH,'%Y/%m/%d'),     ");
		sql.append("     CONCAT(ZIP_CODE1, ZIP_CODE2),      ");
		sql.append("     ADDRESS1,                          ");
		sql.append("     ADDRESS2,                          ");
		sql.append("     TEL,                               ");
		sql.append("     TEL1,                              ");
		sql.append("     TEL_HP,                            ");
		sql.append("     TEL_GUBUN,                         ");
		sql.append("     TEL_GUBUN2,                        ");
		sql.append("     TEL_GUBUN3,                        ");
		sql.append("     GUBUN,                             ");
		sql.append("     JUBSU_BREAK,                       ");
		sql.append("     JUBSU_BREAK_REASON,                ");
		sql.append("     DELETE_YN,                         ");
		sql.append("     REMARK,                            ");
		sql.append("     EMAIL,                             ");
		sql.append("     PACE_MAKER_YN,                     ");
		sql.append("     SELF_PACE_MAKER,                   ");
		sql.append("     PWD,                               ");
		sql.append("     BUNHO_TYPE                         ");
		sql.append(" FROM OUT0101                           ");
		sql.append(" WHERE HOSP_CODE = :hosp_code           ");
		sql.append(" AND   SYS_DATE >= :from_date           ");
		sql.append(" AND SYS_DATE <= :to_date				");
		Query query = entityManager.createNativeQuery(sql.toString());                                                                                                                 
		query.setParameter("hosp_code", hospCode);
		query.setParameter("from_date", fromDate);
		query.setParameter("to_date", toDate);
		List<OUT0101U02PatientExportInfo> list = new JpaResultMapper().list(query, OUT0101U02PatientExportInfo.class);
		return list;
	}

	@Override
	public String callProcMergePatient(String hospCode, String sysId, String ignoreDuplicateYn) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OUT0101U02_IMPORT_PATIENT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SYS_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IGNORE_DUPLICATE_YN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SYS_ID", sysId);
		query.setParameter("I_IGNORE_DUPLICATE_YN", ignoreDuplicateYn);
		
		query.execute();
		String result = (String)query.getOutputParameterValue("O_ERR");
		return result;
	}
	
	@Override
	public void saveBatchPatients(List<Out0101> patientList, boolean ignoreDuplicate) {
		StringBuilder sqlQuery = new StringBuilder();
		sqlQuery.append("INSERT ");
		if(ignoreDuplicate){
			sqlQuery.append("IGNORE ");
		}
		
		sqlQuery.append("INTO OUT0101(SYS_DATE, SYS_ID, UPD_DATE, UPD_ID, "
				+ "HOSP_CODE, BUNHO, SUNAME, SUNAME2, SEX, BIRTH, "
				+ "ZIP_CODE1, ZIP_CODE2, ADDRESS1, ADDRESS2, TEL, "
				+ "TEL1, TEL_HP, TEL_GUBUN, TEL_GUBUN2, TEL_GUBUN3, GUBUN, JUBSU_BREAK, "
				+ "JUBSU_BREAK_REASON, DELETE_YN, REMARK, EMAIL, "
				+ "PACE_MAKER_YN, SELF_PACE_MAKER, IF_VALID_YN, BUNHO_TYPE, BUNHO_EXT, PWD, PARENT_CODE) VALUES ");
		
		for(int i = 0; i < patientList.size(); i++) {
			sqlQuery.append("(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
			if(i < patientList.size() - 1) sqlQuery.append(","); 
		}
		
		long timeOffset = DateTimes.parse("yyyy-MM-dd HH:mm:ss.SSS", "2016-01-01 00:00:00.000");
		String contextID = String.valueOf((System.currentTimeMillis() - timeOffset)/1000);
		
		if(!ignoreDuplicate) {
			//Never update SYS_ID on DUPLICATE KEY
			sqlQuery.append(" ON DUPLICATE KEY UPDATE SYS_DATE=VALUES(SYS_DATE),UPD_DATE=VALUES(UPD_DATE),UPD_ID=VALUES(UPD_ID),"
					+ "HOSP_CODE=VALUES(HOSP_CODE),BUNHO=VALUES(BUNHO),SUNAME=VALUES(SUNAME),SUNAME2=VALUES(SUNAME2),SEX=VALUES(SEX),BIRTH=VALUES(BIRTH),"
					+ "ZIP_CODE1=VALUES(ZIP_CODE1),ZIP_CODE2=VALUES(ZIP_CODE2),ADDRESS1=VALUES(ADDRESS1),ADDRESS2=VALUES(ADDRESS2),TEL=VALUES(TEL),"
					+ "TEL1=VALUES(TEL1),TEL_HP=VALUES(TEL_HP),TEL_GUBUN=VALUES(TEL_GUBUN),TEL_GUBUN2=VALUES(TEL_GUBUN2),TEL_GUBUN3=VALUES(TEL_GUBUN3),GUBUN=VALUES(GUBUN),"
					+ "JUBSU_BREAK=VALUES(JUBSU_BREAK),JUBSU_BREAK_REASON=VALUES(JUBSU_BREAK_REASON),DELETE_YN=VALUES(DELETE_YN),REMARK=VALUES(REMARK),EMAIL=VALUES(EMAIL),"
					+ "PACE_MAKER_YN=VALUES(PACE_MAKER_YN),SELF_PACE_MAKER=VALUES(SELF_PACE_MAKER),IF_VALID_YN=VALUES(IF_VALID_YN),BUNHO_TYPE=VALUES(BUNHO_TYPE),BUNHO_EXT=VALUES(BUNHO_EXT),PWD=VALUES(PWD),PARENT_CODE=VALUES(PARENT_CODE)");	
		}
		
		Query query = entityManager.createNativeQuery(sqlQuery.toString());
		for(int i = 0; i < patientList.size(); i++) {
			Out0101 item = patientList.get(i);
			int offset = i * 33;
			query.setParameter(offset + 1, item.getSysDate());
			query.setParameter(offset + 2, contextID);
			query.setParameter(offset + 3, item.getUpdDate());
			query.setParameter(offset + 4, item.getUpdId());
			query.setParameter(offset + 5, item.getHospCode());
			query.setParameter(offset + 6, item.getBunho());
			query.setParameter(offset + 7, item.getSuname());
			query.setParameter(offset + 8, item.getSuname2());
			query.setParameter(offset + 9, item.getSex());			
			query.setParameter(offset + 10, item.getBirth());
			query.setParameter(offset + 11, item.getZipCode1());
			query.setParameter(offset + 12, item.getZipCode2());
			query.setParameter(offset + 13, item.getAddress1());
			query.setParameter(offset + 14, item.getAddress2());
			query.setParameter(offset + 15, item.getTel());
			query.setParameter(offset + 16, item.getTel1());
			query.setParameter(offset + 17, item.getTelHp());
			query.setParameter(offset + 18, item.getTelGubun());
			query.setParameter(offset + 19, item.getTelGubun2());			
			query.setParameter(offset + 20, item.getTelGubun3());
			query.setParameter(offset + 21, item.getGubun());
			query.setParameter(offset + 22, item.getJubsuBreak());
			query.setParameter(offset + 23, item.getJubsuBreakReason());
			query.setParameter(offset + 24, item.getDeleteYn());
			query.setParameter(offset + 25, item.getRemark());
			query.setParameter(offset + 26, item.getEmail());
			query.setParameter(offset + 27, item.getPaceMakerYn());
			query.setParameter(offset + 28, item.getSelfPaceMaker());
			query.setParameter(offset + 29, item.getIfValidYn());			
			query.setParameter(offset + 30, item.getBunhoType());
			query.setParameter(offset + 31, item.getBunhoExt());
			query.setParameter(offset + 32, item.getPwd());
			query.setParameter(offset + 33, item.getParentCode());
		}
		
		query.executeUpdate();
		
		// Insert default insurance
		StringBuilder sqlIns = new StringBuilder();
		sqlIns.append("INSERT INTO OUT0102(SYS_DATE, SYS_ID, UPD_DATE, UPD_ID, HOSP_CODE, START_DATE, BUNHO, GUBUN, JOHAP, END_DATE)						");
		sqlIns.append("SELECT SYSDATE(), SYS_ID, SYSDATE(), UPD_ID, HOSP_CODE, CURRENT_DATE(), BUNHO, 'Z0', null, STR_TO_DATE('9999/12/31', '%Y/%m/%d')		");
		sqlIns.append("FROM OUT0101																															");
		sqlIns.append("WHERE HOSP_CODE = :f_hosp_code AND SYS_ID = :f_sys_id																				");
		
		Query queryIns = entityManager.createNativeQuery(sqlIns.toString());
		queryIns.setParameter("f_hosp_code", patientList.get(0).getHospCode());
		queryIns.setParameter("f_sys_id", contextID);
		queryIns.executeUpdate();
	}

	@Override
	public List<INPBATCHTRANSlayOut0101Info> getINPBATCHTRANSlayOut0101Info(String hospCode, String language,
			String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SUNAME       																	");
		sql.append("     , A.SUNAME2       																	");
		sql.append("     , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.BIRTH, :f_hosp_code, :f_language) BIRTH      ");
		sql.append("     , A.TEL        																	");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('SEX', A.SEX, :f_hosp_code, :f_language) SEX       		");
		sql.append("     , FN_BAS_LOAD_AGE(SYSDATE(), A.BIRTH,'') AGE       								");
		sql.append("     , A.IF_VALID_YN       																");
		sql.append("  FROM OUT0101 A       																	");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code       												");
		sql.append("   AND A.BUNHO       = :f_bunho          												");		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);

		List<INPBATCHTRANSlayOut0101Info> list = new JpaResultMapper().list(query,INPBATCHTRANSlayOut0101Info.class);
		return list;
	}
	
	@Override
	public List<INP1003U01layBunhoValidationInfo> getINP1003U01layBunhoValidationInfo(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT A.SUNAME																		");
		sql.append("          , IFNULL(A.TEL, '')																");
		sql.append("          , IFNULL(A.TEL1, '')																");
		sql.append("          , IFNULL(A.DELETE_YN, 'N')														");
		sql.append("          , IFNULL(A.JUBSU_BREAK, 'N')														");
		sql.append("          , IFNULL(B.CODE_NAME, '') JUBSU_BREAK_REASON										");
		sql.append("          , A.SEX																			");
		sql.append("          , '0'																				");
		sql.append("       FROM OUT0101 A																		");
		sql.append("       LEFT JOIN BAS0102 B																	");
		sql.append("              ON B.HOSP_CODE = A.HOSP_CODE													");
		sql.append("             AND B.CODE_TYPE = 'JUBSU_BREAKE_REASON'										");
		sql.append("             AND B.CODE      = A.JUBSU_BREAK_REASON											");
		sql.append("      WHERE A.HOSP_CODE      = :f_hosp_code													");
		sql.append("        AND A.BUNHO          = :f_bunho														");
		sql.append("        AND IFNULL(A.DELETE_YN, 'N') = 'N'													");
		
		Query query = entityManager.createNativeQuery(sql.toString());                                                                                                                 
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		List<INP1003U01layBunhoValidationInfo> list = new JpaResultMapper().list(query, INP1003U01layBunhoValidationInfo.class);
		
		return list;
	}
	
	@Override
	public String getTelINP1003U01SaveLayout(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT A.TEL												");
		sql.append("       FROM OUT0101 A											");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code							");
		sql.append("        AND A.BUNHO     = :f_bunho								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<INP1003U00grdInpReserGridColumnChangeddtBunhoInfo> getINP1003U00grdInpReserGridColumnChangeddtBunho(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT												");
		sql.append("		A.SUNAME                          suname,		");
		sql.append("		A.TEL                             tel,			");
		sql.append("		IFNULL(A.DELETE_YN, 'N')          delete_yn		");
		sql.append("	FROM												");
		sql.append("		OUT0101 A										");
		sql.append("	WHERE												");
		sql.append("		A.HOSP_CODE = :f_hosp_code						");
		sql.append("		AND A.BUNHO = :f_bunho							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<INP1003U00grdInpReserGridColumnChangeddtBunhoInfo> list = new JpaResultMapper().list(query, INP1003U00grdInpReserGridColumnChangeddtBunhoInfo.class);
		return list;
	}

	@Override
	public List<INP1003U00SaveLayoutChkBunhoInfo> getOut0101U00ByBunho(String hospCode, String language, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																							                        ");
		sql.append("		IFNULL(A.DELETE_YN, 'N')          										delete_yn,			                        ");
		sql.append("		IFNULL(A.JUBSU_BREAK, 'N')        										jubsu_break,								");
		sql.append("		FN_BAS_LOAD_CODE_NAME('JUBSU_BREAK_REASON', A.JUBSU_BREAK_REASON, :f_hosp_code, :f_language) 		code_name		");
		sql.append("	FROM																							                        ");
		sql.append("		OUT0101 A																					                        ");
		sql.append("	WHERE																							                        ");
		sql.append("		A.HOSP_CODE = :f_hosp_code																	                        ");
		sql.append("		AND A.BUNHO = :f_bunho																		                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		List<INP1003U00SaveLayoutChkBunhoInfo> list = new JpaResultMapper().list(query, INP1003U00SaveLayoutChkBunhoInfo.class);
		return list;
	}
	
	@Override
	public List<OCS2005U02grdPatientListInfo> getOCS2005U02grdPatientListInfo(String hospCode, String orderDate, String language, String inputGubun, String bunho,
			String hoDong, String hoCode, String jaewonYn, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT AA.PK_KEY																																");
		sql.append("          , AA.HO_DONG																																");
		sql.append("          , AA.HO_DONG_NAME																															");
		sql.append("          , AA.HO_CODE																																");
		sql.append("          , AA.HO_CODE_NAME																															");
		sql.append("          , AA.BUNHO																																");
		sql.append("          , AA.SUNAME																																");
		sql.append("          , AA.SUNAME2																																");
		sql.append("          , AA.SEX																																	");
		sql.append("          , CAST(AA.AGE AS CHAR)																													");
		sql.append("          , AA.GUBUN																																");
		sql.append("          , AA.GUBUN_NAME																															");
		sql.append("          , AA.DOCTOR																																");
		sql.append("          , AA.DOCTOR_NAME																															");
		sql.append("          , AA.GWA																																	");
		sql.append("          , AA.GWA_NAME																																");
		sql.append("          , AA.IPWON_DATE																															");
		sql.append("          , AA.IPWON_RESER_YN																														");
		sql.append("          , AA.IPWON_TYPE																															");
		sql.append("          , AA.COUSULT_GUBUN																														");
		sql.append("          , AA.JINRYO_END_YN																														");
		sql.append("          , ''						AS	CONSULT_KEY																									");
		sql.append("          , AA.COMMONT_DOCTOR_YN																													");
		sql.append("          , AA.TOIWON_DATE																															");
		sql.append("          , AA.JAEWON_YN																															");
		sql.append("       FROM (																																		");
		sql.append("         SELECT A.PKINP1001                                         PK_KEY,																			");
		sql.append("                A.HO_DONG1                                          HO_DONG,																		");
		sql.append("                IFNULL(FN_BAS_LOAD_HO_DONG_NAME(A.HO_DONG1, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.HOSP_CODE, :f_language),'')					");
		sql.append("                                                                    HO_DONG_NAME,																	");
		sql.append("                A.HO_CODE1                                          HO_CODE,																		");
		sql.append("                IFNULL(FN_BAS_LOAD_HO_CODE_NAME(A.HOSP_CODE, A.HO_DONG1, A.HO_CODE1, STR_TO_DATE(:f_order_date,'%Y/%m/%d')),'') HO_CODE_NAME,		");
		sql.append("                A.BUNHO                                             BUNHO,																			");
		sql.append("                A.SUNAME                                            SUNAME,																			");
		sql.append("                A.SUNAME2                                           SUNAME2,																		");
		sql.append("                A.SEX                                               SEX,																			");
		sql.append("                FLOOR(IFNULL(TIMESTAMPDIFF(MONTH, A.BIRTH, STR_TO_DATE(:f_order_date,'%Y/%m/%d')),0)/12)											");
		sql.append("                                                                    AGE,																			");
		sql.append("                A.GUBUN                                             GUBUN,																			");
		sql.append("                IFNULL(FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.HOSP_CODE),'')      GUBUN_NAME,						");
		sql.append("                A.DOCTOR                                            DOCTOR,																			");
		sql.append("                IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.HOSP_CODE),'')    DOCTOR_NAME,					");
		sql.append("                A.GWA                                               GWA,																			");
		sql.append("                IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.HOSP_CODE, :f_language),'')          GWA_NAME,			");
		sql.append("                DATE_FORMAT(A.IPWON_DATE, '%Y/%m/%d')               IPWON_DATE,																		");
		sql.append("                IFNULL(A.IPWON_RESER_YN,'')                                    IPWON_RESER_YN,														");
		sql.append("                A.IPWON_TYPE                                        IPWON_TYPE,																		");
		sql.append("                'N'                                                 COUSULT_GUBUN,																	");
		sql.append("                SUBSTRING(FN_OCS_INP_ORDER_STATUS_CHECK(A.HOSP_CODE, A.BUNHO, A.PKINP1001,																");
		sql.append("                           STR_TO_DATE(:f_order_date,'%Y/%m/%d'), :f_input_gubun), 1, 1)															");
		sql.append("                                                                    JINRYO_END_YN,																	");
//		sql.append("                ''                                                CONSULT_KEY  ,																	");
		sql.append("                FN_BAS_LOAD_COMMON_DOCTOR_YN(A.HOSP_CODE, A.GWA, A.DOCTOR,																			");
		sql.append("                           STR_TO_DATE(:f_order_date,'%Y/%m/%d'))  COMMONT_DOCTOR_YN,																");
		sql.append("                ''                                                TOIWON_DATE,																		");
		sql.append("                'Y' JAEWON_YN,																														");
		sql.append("               IFNULL( CONCAT('N',A.IPWON_RESER_YN,RPAD(IFNULL(A.HO_DONG1, '0'), 4, '0'),RPAD(A.HO_CODE1, 10 ,'')									");
		sql.append("                                       ,A.BUNHO,LPAD(CAST(A.PKINP1001 AS CHAR), 10,'0')), '') CONT_KEY												");
		sql.append("           FROM VW_OCS_INP1001_RES_11 A																												");
		sql.append("           , (select @kcck_hosp_code\\:=:f_hosp_code) TMP																								");
		sql.append("          WHERE A.IPWON_DATE        <= STR_TO_DATE(:f_order_date,'%Y/%m/%d')																		");
		sql.append("            AND A.BUNHO             LIKE :f_bunho																									");
		sql.append("            AND IFNULL(A.HO_DONG1,'EMPTY') LIKE TRIM(:f_ho_dong)																					");
		sql.append("            AND IFNULL(A.HO_CODE1,'EMPTY') LIKE TRIM(:f_ho_code)																					");
		sql.append("            AND A.HOSP_CODE         =    :f_hosp_code																								");
		sql.append("     UNION 																																			");
		sql.append("         SELECT A.PKINP1001                                         PK_KEY,																			");
		sql.append("                A.HO_DONG1                                          HO_DONG,																		");
		sql.append("                IFNULL(FN_BAS_LOAD_HO_DONG_NAME(A.HO_DONG1, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.HOSP_CODE, :f_language),'')					");
		sql.append("                                                                    HO_DONG_NAME,																	");
		sql.append("                A.HO_CODE1                                          HO_CODE,																		");
		sql.append("                IFNULL(FN_BAS_LOAD_HO_CODE_NAME(A.HOSP_CODE, A.HO_DONG1, A.HO_CODE1, STR_TO_DATE(:f_order_date,'%Y/%m/%d')),'') HO_CODE_NAME,		");
		sql.append("                B.BUNHO                                             BUNHO,																			");
		sql.append("                B.SUNAME                                            SUNAME,																			");
		sql.append("                B.SUNAME2                                           SUNAME2,																		");
		sql.append("                B.SEX                                               SEX,																			");
		sql.append("                FLOOR(IFNULL(TIMESTAMPDIFF(MONTH, B.BIRTH, STR_TO_DATE(:f_order_date,'%Y/%m/%d')),0)/12)											");
		sql.append("                                                                    AGE,																			");
		sql.append("                B.GUBUN                                             GUBUN,																			");
		sql.append("                IFNULL(FN_BAS_LOAD_GUBUN_NAME(B.GUBUN, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.HOSP_CODE),'')      GUBUN_NAME,						");
		sql.append("                A.DOCTOR                                            DOCTOR,																			");
		sql.append("                IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.HOSP_CODE),'')    DOCTOR_NAME,					");
		sql.append("                A.GWA                                               GWA,																			");
		sql.append("                IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, STR_TO_DATE(:f_order_date,'%Y/%m/%d'), A.HOSP_CODE, :f_language),'')          GWA_NAME,			");
		sql.append("                DATE_FORMAT(A.IPWON_DATE,'%Y/%m/%d')                                        IPWON_DATE,												");
		sql.append("                ''                                                IPWON_RESER_YN,																	");
		sql.append("                A.IPWON_TYPE                                        IPWON_TYPE,																		");
		sql.append("                'N'                                                 COUSULT_GUBUN,																	");
		sql.append("                SUBSTRING(FN_OCS_INP_ORDER_STATUS_CHECK(A.HOSP_CODE, A.BUNHO, A.PKINP1001, 															");
		sql.append("                                 STR_TO_DATE(:f_order_date,'%Y/%m/%d'), :f_input_gubun), 1, 1)														");
		sql.append("                                                                    JINRYO_END_YN,																	");
//		sql.append("                ''                                                CONSULT_KEY  ,																	");
		sql.append("                FN_BAS_LOAD_COMMON_DOCTOR_YN(A.HOSP_CODE, A.GWA, A.DOCTOR, STR_TO_DATE(:f_order_date,'%Y/%m/%d'))  COMMONT_DOCTOR_YN,				");
		sql.append("                DATE_FORMAT(A.TOIWON_DATE, '%Y/%m/%d')                TOIWON_DATE,																	");
		sql.append("                'N' JAEWON_YN,																														");
		sql.append("                IFNULL(CONCAT('N',RPAD(IFNULL(A.HO_DONG1, '0'), 4, '0'),RPAD(A.HO_CODE1, 10,''),A.BUNHO												");
		sql.append("                           ,LPAD(CAST(A.PKINP1001 AS CHAR), 10, '0')),'') CONT_KEY																	");
		sql.append("           FROM (SELECT Z.*    																														");
		sql.append("                   FROM INP1001 Z																													");
		sql.append("                  WHERE Z.HOSP_CODE = :f_hosp_code																									");
		sql.append("                    AND Z.PKINP1001 = (SELECT MAX(Y.PKINP1001)																						");
		sql.append("                                         FROM INP1001 Y																								");
		sql.append("                                        WHERE Y.HOSP_CODE = Z.HOSP_CODE																				");
		sql.append("                                          AND Y.BUNHO     = Z.BUNHO																					");
		sql.append("                                          AND Y.TOIWON_DATE IS NOT NULL)) A																			");
		sql.append("           JOIN OUT0101 B																															");
		sql.append("             ON B.HOSP_CODE = A.HOSP_CODE																											");
		sql.append("            AND B.BUNHO     = A.BUNHO																												");
		sql.append("          WHERE A.HOSP_CODE         =    :f_hosp_code																								");
		sql.append("            AND A.IPWON_DATE        <= STR_TO_DATE(:f_order_date,'%Y/%m/%d')																		");
		sql.append("            AND A.BUNHO             LIKE :f_bunho																									");
		sql.append("            AND A.TOIWON_DATE IS NOT NULL																											");
		sql.append("            AND IFNULL(A.HO_DONG1,'EMPTY') LIKE TRIM(:f_ho_dong)																					");
		sql.append("            AND IFNULL(A.HO_CODE1,'EMPTY') LIKE TRIM(:f_ho_code)																					");
		sql.append("     ) AA																																			");
		sql.append("       WHERE AA.JAEWON_YN = :f_jaewon_yn																											");
		sql.append("     ORDER BY AA.BUNHO																																");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																														");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jaewon_yn", jaewonYn);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_bunho", bunho);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<OCS2005U02grdPatientListInfo> list = new JpaResultMapper().list(query, OCS2005U02grdPatientListInfo.class);
		return list;
	}
	
	@Override
	public String OCS2005U02IsSameNameCHK(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT FN_ADM_IS_SAME_NAME_YN_INP_T(:f_bunho, :f_hosp_code) FROM DUAL																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return "";
	}

	@Override
	public String loadOutSuname(String bunho, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OUT_LOAD_SUNAME(:f_bunho, :f_hosp_code) FROM DUAL	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hosp_code", hospCode);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public List<NUR2004U00layCurrentBedInfo> getNUR2004U00layCurrentBedInfo(String hospCode, String bunho, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																													");
		sql.append("	  	DISTINCT A.GWA,																										");
		sql.append("	    FN_BAS_LOAD_GWA_NAME(A.GWA, A.IPWON_DATE, :f_hosp_code, :f_language)							GWA_NAME,			");
		sql.append("	    A.DOCTOR,																											");
		sql.append("	    FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, CURRENT_DATE(), :f_hosp_code) 								DOCTOR_NAME,		");
		sql.append("	    A.HO_DONG1,																											");
		sql.append("	    A.HO_CODE1,																											");
		sql.append("	    A.BED_NO,																											");
		sql.append("	    B.SUNAME,																											");
		sql.append("	    A.IPWON_DATE,																										");
		sql.append("	    A.TOIWON_RES_DATE,																									");
		sql.append("	    CASE A.TOIWON_RES_DATE WHEN '' THEN 'N' ELSE 'Y' END                      						TOIWON_RES_YN,		");
		sql.append("	    ''             																					TOT_BED,			");
		sql.append("	    A.PKINP1001,																										");
		sql.append("	    ''             																					TRANS_CNT,			");
		sql.append("	    FN_NUR_LOAD_BUDOCTOR_LIST(:f_hosp_code, :f_bunho, A.PKINP1001, CURRENT_DATE()) 					BU_DOCTOR_LIST,		");
		sql.append("	    A.HO_GRADE1,																										");
		sql.append("	    A.KAIKEI_HODONG,																									");
		sql.append("	    A.KAIKEI_HOCODE																										");
		sql.append("	 FROM VW_OCS_INP1001_01 A                                                                                               ");
		sql.append("	 JOIN 	OUT0101 B ON  B.HOSP_CODE 	= A.HOSP_CODE 																		");
		sql.append("	                  AND A.BUNHO   	= B.BUNHO																			");
		sql.append("	 ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP 																		");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code																					");
		sql.append("	   AND A.BUNHO         = :f_bunho																						");
		sql.append("	   AND A.JAEWON_FLAG   = 'Y'																							");
		sql.append("	   AND A.TOIWON_DATE   IS NULL				                                                                            ");
		                  
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		
		List<NUR2004U00layCurrentBedInfo> list = new JpaResultMapper().list(query, NUR2004U00layCurrentBedInfo.class);
		return list;
	}
	
	@Override
	public List<NUR1001U00LayINP1001Info> getNUR1001U00LayINP1001Info(String hospCode, String bunho, String language, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CONCAT(A.ADDRESS1,' ',A.ADDRESS2)                            ADDRESS,                ");
		sql.append("          A.TEL                                                        TEL,                    ");
		sql.append("          FN_BAS_LOAD_GUBUN_NAME(A.GUBUN,SYSDATE(), A.HOSP_CODE)       GUBUN_NAME,             ");
		sql.append("          DATE_FORMAT(B.IPWON_DATE, '%Y/%m/%d')                        IPWON_DATE,             ");
		sql.append("          DATE_FORMAT(B.TOIWON_DATE, '%Y/%m/%d')                       TOIWON_DATE,            ");
		sql.append("          FN_BAS_LOAD_GWA_NAME(B.GWA, SYSDATE(), A.HOSP_CODE, :f_language) GWA_NAME,           ");
		sql.append("          FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, SYSDATE(), A.HOSP_CODE)    DOCTOR_NAME,            ");
		sql.append("          FN_BAS_LOAD_GWA_NAME(B.HO_DONG1, SYSDATE(),A.HOSP_CODE, :f_language) HO_DONG_NAME,   ");
		sql.append("          B.HO_CODE1                                                   HO_CODE,                ");
		sql.append("          B.BED_NO                                                     BED_NO,                 ");
		sql.append("          B.HO_DONG1                                                   HO_DONG,                ");
		sql.append("          B.GWA                                                        GWA                     ");
		sql.append("     FROM OUT0101 A                                                                            ");
		sql.append("     LEFT JOIN INP1001 B                                                                       ");
		sql.append("       ON B.HOSP_CODE  = A.HOSP_CODE                                                           ");
		sql.append("      AND B.BUNHO      = A.BUNHO                                                               ");
		sql.append("      AND B.PKINP1001  = :f_fkinp1001                                                          ");
		sql.append("    WHERE A.HOSP_CODE  = :f_hosp_code                                                          ");
		sql.append("      AND A.BUNHO      = :f_bunho                                                              ");
		sql.append("     LIMIT 0, 1                                                                                ");
		                  
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<NUR1001U00LayINP1001Info> list = new JpaResultMapper().list(query, NUR1001U00LayINP1001Info.class);
		return list;
	}
}

