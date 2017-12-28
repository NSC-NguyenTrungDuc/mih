package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0503RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503Q01GrdOCS0503ListInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503Q01ListDataInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GetFindWorkerConsultGwaInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GridOSC0503ListInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00ValidationCheckInfo;
import nta.med.data.model.ihis.ocso.OCS2016GetLinkingDepartmentInfo;
import nta.med.data.model.ihis.ocso.OCS2016GetUserDepartmentInfo;

/**
 * @author dainguyen.
 */
public class Ocs0503RepositoryImpl implements Ocs0503RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Ocs0503RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OcsaOCS0503Q01ListDataInfo> getOcsaOCS0503Q01ListDataInfo(
			String hospCode,String language, String bunho, String fromDate, String toDate) {
		
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.IN_OUT_GUBUN                                                         IO_GUBUN            ,      			");
		sql.append("	       A.BUNHO                                                                BUNHO               ,                 ");
		sql.append("	       A.REQ_DATE                                                             REQ_DATE            ,                 ");
		sql.append("	       A.JINRYO_PRE_DATE                                                      JINRYO_PRE_DATE     ,                 ");
		sql.append("	       A.REQ_GWA                                                              REQ_GWA             ,                 ");
		sql.append("	       A.REQ_DOCTOR                                                           REQ_DOCTOR          ,                 ");
		sql.append("	       A.APP_DATE                                                             APP_DATE            ,                 ");
		sql.append("	       A.CONSULT_GWA                                                          CONSULT_GWA         ,                 ");
		sql.append("	       A.CONSULT_DOCTOR                                                       CONSULT_DOCTOR      ,                 ");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.REQ_GWA, A.REQ_DATE,:hospCode,:language)          REQ_GWA_NAME        ,               ");
		sql.append("	       FN_BAS_LOAD_DOCTOR_NAME(A.REQ_DOCTOR, A.REQ_DATE,:hospCode )         REQ_DOCTOR_NAME     ,                   ");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.CONSULT_GWA, A.REQ_DATE,:hospCode,:language)      CONSULT_GWA_NAME    ,               ");
		sql.append("	       FN_BAS_LOAD_DOCTOR_NAME(A.CONSULT_DOCTOR, A.REQ_DATE,:hospCode)     CONSULT_DOCTOR_NAME                      ");
		sql.append("	  FROM OCS0503 A                                                                                                    ");
		sql.append("	 WHERE A.BUNHO     = :bunho                                                                                         ");
		sql.append("	   AND A.HOSP_CODE = :hospCode                                                                                      ");
		sql.append("	   AND A.JINRYO_PRE_DATE  BETWEEN STR_TO_DATE(:fromDate,'%Y/%m/%d') AND  STR_TO_DATE(:toDate,'%Y/%m/%d')            ");
		sql.append("	 ORDER BY CONCAT(DATE_FORMAT(A.JINRYO_PRE_DATE, '%Y/%m/%d'),LTRIM(LPAD(PKOCS0503,10,'0'))) DESC;					");
		 
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		query.setParameter("fromDate",fromDate );
		query.setParameter("toDate",toDate);
		
		List<OcsaOCS0503Q01ListDataInfo> list = new JpaResultMapper().list(query, OcsaOCS0503Q01ListDataInfo.class);
		return list;
	}

	@Override
	public List<OcsaOCS0503Q01GrdOCS0503ListInfo> getOcsaOCS0503Q01GrdOCS0503ListInfo(
			String hospCode, String reqDate, String bunho, String consultDoctor) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.BUNHO               ,																																						  ");
		sql.append("	       A.REQ_DATE            ,                                                                                                                                                         ");
		sql.append("	       A.REQ_GWA             ,                                                                                                                                                         ");
		sql.append("	       A.REQ_DOCTOR          ,                                                                                                                                                         ");
		sql.append("	       A.PKOCS0503           ,                                                                                                                                                         ");
		sql.append("	       A.CONSULT_GWA         ,                                                                                                                                                         ");
		sql.append("	       A.CONSULT_DOCTOR      ,                                                                                                                                                         ");
		sql.append("	       A.WANGJIN_YN          ,                                                                                                                                                         ");
		sql.append("	       A.SANG_CODE1          ,                                                                                                                                                         ");
		sql.append("	       A.SANG_NAME1          ,                                                                                                                                                         ");
		sql.append("	       A.SANG_CODE2          ,																																						   ");
		sql.append("	       A.SANG_NAME2          ,                                                                                                                                                         " );
		sql.append("	       A.SANG_CODE3          ,                                                                                                                                                         " );
		sql.append("	       A.SANG_NAME3          ,                                                                                                                                                         " );
		sql.append("	       A.CONSULT_SANG_NAME   ,                                                                                                                                                         " );
		sql.append("	       A.REQ_REMARK          ,                                                                                                                                                         " );
		sql.append("	       A.APP_DATE            ,                                                                                                                                                         " );
		sql.append("	       A.ANSWER              ,                                                                                                                                                         " );
		sql.append("	       A.IN_OUT_GUBUN        ,                                                                                                                                                         " );
		sql.append("	       A.CONSULT_FKOUT1001   ,                                                                                                                                                         " );
		sql.append("	       A.FKINP1001           ,                                                                                                                                                         " );
		sql.append("	       A.PRINT_YN            ,                                                                                                                                                         " );
		sql.append("	       A.EMER_GUBUN          ,                                                                                                                                                         " );
		sql.append("	       A.REAL_JINRYO_DATE    ,                                                                                                                                                         " );
		sql.append("	       A.RESULT_ARRIVE_DATE  ,                                                                                                                                                         " );
		sql.append("	       A.CONFIRM_YN          ,                                                                                                                                                         " );
		sql.append("	       A.ANSWER_END_YN       ,                                                                                                                                                         " );
		sql.append("	       A.JINRYO_PRE_DATE     ,                                                                                                                                                         " );
		sql.append("	       A.AMPM_GUBUN          ,                                                                                                                                                         " );
		sql.append("	       A.REQ_END_YN          ,                                                                                                                                                         " );
		sql.append("	       IFNULL(A.DISPLAY_YN, 'N') DISPLAY_YN   ,                                                                                                                                        " );
		sql.append("	       B.SUNAME  ,                                                                                                                                                                     " );
		sql.append("	       B.SEX     ,                                                                                                                                                                     " );
		sql.append("	       FN_BAS_LOAD_AGE        (DATE_FORMAT(SYSDATE(),'%Y/%m/%d')  ,B.BIRTH    ,NULL)  AGE                      ,                                                                       " );
		sql.append("	       FN_BAS_LOAD_GWA_NAME   (A.CONSULT_GWA   ,A.REQ_DATE,:hospCode, 'JA')        CONSULT_GWA_NAME   ,                                                                             " );
		sql.append("	       FN_BAS_LOAD_DOCTOR_NAME(A.CONSULT_DOCTOR,A.REQ_DATE,:hospCode)              CONSULT_DOCTOR_NAME,                                                                             " );
		sql.append("	       FN_BAS_LOAD_GWA_NAME   (A.REQ_GWA       ,A.REQ_DATE,:hospCode, 'JA')         REQ_GWA_NAME       ,                                                                            " );
		sql.append("	       FN_BAS_LOAD_DOCTOR_NAME(A.REQ_DOCTOR    ,A.REQ_DATE,:hospCode)               REQ_DOCTOR_NAME         ,                                                                       " );
		sql.append("	       A.ANSWER_END_YN                                                                OLD_ANSWER_END_YN                                                                                " );
		sql.append("	  FROM OCS0503 A,                                                                                                                                                                      " );
		sql.append("	       OUT0101 B                                                                                                                                                                       " );
		sql.append("	 WHERE A.HOSP_CODE       = :hospCode                                                                                                                                                " );
		sql.append("	   AND A.JINRYO_PRE_DATE = :reqDate                                                                                                                                                 " );
		sql.append("	   AND A.BUNHO           = :bunho                                                                                                                                                    " );
		sql.append("	   AND ( ( IFNULL(SUBSTRING(A.CONSULT_DOCTOR, (LENGTH(A.CONSULT_DOCTOR)-5)+1), '%') LIKE CONCAT( SUBSTRING(:consultDoctor, (LENGTH(:consultDoctor)-5)+1), '%' )) OR              " );
		sql.append("	         ( EXISTS ( SELECT 'X'                                                                                                                                                         " );
		sql.append("	                      FROM BAS0270 X                                                                                                                                                   " );
		sql.append("	                     WHERE X.HOSP_CODE        = A.HOSP_CODE                                                                                                                            " );
		sql.append("	                       AND X.DOCTOR_GWA       = A.CONSULT_GWA                                                                                                                          " );
		sql.append("	                       AND X.DOCTOR           = A.CONSULT_DOCTOR                                                                                                                       " );
		sql.append("	                       AND X.COMMON_DOCTOR_YN = 'Y' ) ) )                                                                                                                              " );
		sql.append("	                                                                                                                                                                                       " );
		sql.append("	   AND B.HOSP_CODE       = A.HOSP_CODE                                                                                                                                                 " );
		sql.append("	   AND B.BUNHO           = A.BUNHO                                                                                                                                                     " );
		sql.append("	 ORDER BY A.REQ_DATE DESC, A.REQ_GWA DESC;                                                                                                                                             " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("reqDate",DateUtil.toDate(reqDate, DateUtil.PATTERN_YYMMDD) );
		query.setParameter("consultDoctor",consultDoctor);
		
		List<OcsaOCS0503Q01GrdOCS0503ListInfo> list = new JpaResultMapper().list(query, OcsaOCS0503Q01GrdOCS0503ListInfo.class);
		return list;
	}

	@Override
	public Double getSeqOcs0503() {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT SWF_NextVal('OCS0503_SEQ')");
		Query query = entityManager.createNativeQuery(sql.toString());
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return Double.parseDouble(listResult.get(0).toString());
		}
		return null;
	}

	@Override
	public Double getOCS0503U00CheckInpPatient(String hopsCode,String bunho) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT A.PKINP1001  FROM VW_OCS_INP1001 A WHERE A.BUNHO = :bunho AND A.HOSP_CODE = :hopsCode LIMIT 1");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("bunho", bunho);
		query.setParameter("hopsCode", hopsCode);
		
		List<Double> checkInPatient=query.getResultList();
		if(!CollectionUtils.isEmpty(checkInPatient)){
			return checkInPatient.get(0);
		}
		return null;
	}

	@Override
	public List<OcsaOCS0503U00ValidationCheckInfo> getOCS0503U00ValidationCheck(String hospCode,Double fkout1001) {
		StringBuilder sql=new StringBuilder();
		sql.append("SELECT A.NAEWON_YN, FN_OUT_CHECK_NAEWON_YN( A.BUNHO,A.NAEWON_DATE ,A.GWA,A.DOCTOR,A.NAEWON_TYPE,A.JUBSU_NO,A.CHOJAE)  ORDER_YN "
				+ "FROM OUT1001 A WHERE A.HOSP_CODE = :hospCode AND A.PKOUT1001 = :fkout1001");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("fkout1001", fkout1001);
		List<OcsaOCS0503U00ValidationCheckInfo> listValidateCheck= new JpaResultMapper().list(query, OcsaOCS0503U00ValidationCheckInfo.class);
		return listValidateCheck;
	}

	@Override
	public String getGwaNameOCS0503U00(String hospCode,String language, String code) {
		StringBuilder sql=new StringBuilder();                                                         
		
		sql.append("   SELECT A.GWA_NAME FROM VW_BAS_GWA A                                            ");
		sql.append("   WHERE GWA = :f_code1 AND A.HOSP_CODE = :hospCode                               ");
		sql.append("   AND A.LANGUAGE= :language                                                      ");
		sql.append("   AND ( A.OUT_JUBSU_YN   = 'Y'  OR A.IPWON_YN = 'Y' )                             ");
		sql.append("   AND A.START_DATE = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, SYSDATE(),A.HOSP_CODE)     ");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code1", code);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<String> listGwaName=query.getResultList();
		if(!CollectionUtils.isEmpty(listGwaName)){
			return listGwaName.get(0);
		}
		return null;
	}

	@Override
	public List<OcsaOCS0503U00GridOSC0503ListInfo> getOcsaOCS0503U00GridOSC0503ListInfo(
			String hospCode,String language, String bunho, String reqDoctor) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT A.BUNHO                                                                             , ");
		sql.append("      A.REQ_DATE                                                                          ,  ");
		sql.append("      A.REQ_GWA                                                                           ,  ");
		sql.append("      A.REQ_DOCTOR                                                                        ,  ");
		sql.append("      A.PKOCS0503                                                                         ,  ");
		sql.append("      A.CONSULT_GWA                                                                       ,  ");
		sql.append("      A.CONSULT_DOCTOR                                                                    ,  ");
		sql.append("      A.WANGJIN_YN                                                                        ,  ");
		sql.append("      A.SANG_CODE1                                                                        ,  ");
		sql.append("      A.SANG_NAME1                                                                        ,  ");
		sql.append("      A.SANG_CODE2                                                                        ,  ");
		sql.append("      A.SANG_NAME2                                                                        ,  ");
		sql.append("      A.SANG_CODE3                                                                        ,  ");
		sql.append("      A.SANG_NAME3                                                                        ,  ");
		sql.append("      A.CONSULT_SANG_NAME                                                                 ,  ");
		sql.append("      A.REQ_REMARK                                                                        ,  ");
		sql.append("      A.APP_DATE                                                                          ,  ");
		sql.append("      A.ANSWER                                                                            ,  ");
		sql.append("      A.IN_OUT_GUBUN                                                                      ,  ");
		sql.append("      A.CONSULT_FKOUT1001                                                                 ,  ");
		sql.append("      A.FKINP1001                                                                         ,  ");
		sql.append("      IFNULL(A.PRINT_YN,'N')                                                              ,  ");
		sql.append("      A.EMER_GUBUN                                                                        ,  ");
		sql.append("      A.REAL_JINRYO_DATE                                                                  ,  ");
		sql.append("      A.RESULT_ARRIVE_DATE                                                                ,  ");
		sql.append("      A.CONFIRM_YN                                                                        ,  ");
		sql.append("      A.ANSWER_END_YN                                                                     ,  ");
		sql.append("      A.JINRYO_PRE_DATE                                                                   ,  ");
		sql.append("      A.RESER_TIME                                                                         , ");
		sql.append("      A.REQ_END_YN                                                                        ,  ");
		sql.append("      IFNULL(A.DISPLAY_YN, 'N') DISPLAY_YN                                                 , ");
		sql.append("      B.SUNAME                                                                            ,  ");
		sql.append("      B.SEX                                                                               ,  ");
		sql.append("      FN_BAS_LOAD_AGE        (SYSDATE() ,B.BIRTH    , NULL)     AGE,                         ");
		sql.append("      FN_BAS_LOAD_GWA_NAME   (A.CONSULT_GWA   ,A.REQ_DATE,:f_hosp_code,:f_language)    CONSULT_GWA_NAME   ,  ");
		sql.append("      FN_BAS_LOAD_DOCTOR_NAME(A.CONSULT_DOCTOR,A.REQ_DATE,:f_hosp_code)    CONSULT_DOCTOR_NAME,  ");
		sql.append("      FN_BAS_LOAD_GWA_NAME   (A.REQ_GWA       ,A.REQ_DATE,:f_hosp_code,:f_language)    REQ_GWA_NAME       ,  ");
		sql.append("      FN_BAS_LOAD_DOCTOR_NAME(A.REQ_DOCTOR    ,A.REQ_DATE,:f_hosp_code)     REQ_DOCTOR_NAME    ,  ");
		sql.append("      A.ANSWER_END_YN                                                  OLD_ANSWER_END_YN  ,  ");
		sql.append("      CASE                                                                                   ");
		sql.append("          WHEN :f_req_doctor = A.CONSULT_DOCTOR THEN '0'                                     ");
		sql.append("          ELSE '1'                                                                           ");
		sql.append("      END           ORDER_BY_KEY                                                             ");
		sql.append(" FROM OCS0503 A,                                                                             ");
		sql.append("      OUT0101 B,                                                                             ");
		sql.append("      BAS0270 C,                                                                             ");
		sql.append("      BAS0270 D                                                                              ");
		sql.append("WHERE                                                                                        ");
		sql.append("  A.BUNHO      = :f_bunho                                                                    ");
		sql.append("  AND A.HOSP_CODE  = :f_hosp_code                                                            ");
		sql.append("  AND B.BUNHO      = A.BUNHO                                                                 ");
		sql.append("  AND B.HOSP_CODE  = A.HOSP_CODE                                                             ");
		sql.append("  AND C.DOCTOR     = A.REQ_DOCTOR                                                            ");
		sql.append("  AND C.HOSP_CODE  = A.HOSP_CODE                                                             ");
		sql.append("  AND A.REQ_DATE   BETWEEN C.START_DATE AND C.END_DATE                                       ");
	    sql.append("  AND D.DOCTOR     = :f_req_doctor                                                           ");
		sql.append("  AND D.HOSP_CODE  = A.HOSP_CODE                                                             ");
		sql.append("  AND A.REQ_DATE   BETWEEN D.START_DATE AND D.END_DATE                                       ");
		sql.append("ORDER BY ORDER_BY_KEY, A.REQ_DATE DESC, A.REQ_GWA DESC                                     ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_req_doctor", reqDoctor);
		List<OcsaOCS0503U00GridOSC0503ListInfo> listGrid=new JpaResultMapper().list(query, OcsaOCS0503U00GridOSC0503ListInfo.class);
		return listGrid;
	}

	@Override
	public List<OcsaOCS0503U00GetFindWorkerConsultGwaInfo> getOcsaOCS0503U00GetFindWorkerListInfoProcess1(String hospCode,String language) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.GWA, A.GWA_NAME                                                                              ");
		sql.append(" FROM VW_BAS_GWA A                                                                                     ");
		sql.append(" WHERE A.OUT_JUBSU_YN = 'Y'                                                                            ");
		sql.append(" AND A.START_DATE = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA,SYSDATE() ,A.HOSP_CODE )                          ");
		sql.append(" AND A.HOSP_CODE  = :hospCode AND A.LANGUAGE = :language                                                ");
		sql.append(" ORDER BY A.GWA                                                                                        ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		List<OcsaOCS0503U00GetFindWorkerConsultGwaInfo> listWorker=new JpaResultMapper().list(query, OcsaOCS0503U00GetFindWorkerConsultGwaInfo.class);
		return listWorker;
	}

	@Override
	public String checkCanReserOCS0503U00(String hospCode,Date reserDate, String reserTime,String reserDoctor) {
		StringBuilder sql=new StringBuilder();
		sql.append("SELECT FN_OUT_CHECK_CAN_RESER_YN(:f_hosp_code,:f_reser_date, :f_reser_time, :f_reser_doctor) FROM DUAL");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_reser_time", reserTime);
		query.setParameter("f_reser_doctor", reserDoctor);
		List<String> result=query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public String getNoConfirmConsult(String hospCode, String bunho, Date naewonDate, String gwa, String doctor, String ioGubun){
		StringBuilder sql=new StringBuilder();
		sql.append(" SELECT FN_OCS_IS_NOCONFIRM_CONSULT(:f_hosp_code,:f_bunho,:f_naewon_date,:f_gwa,:f_doctor,:f_io_gubun) ");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_io_gubun", ioGubun);
		List<String> result=query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<OCS2016GetLinkingDepartmentInfo> getListOCS2016GetLinkingDepartmentInfo(String hospCode,
			String language, String find1) {
		
		StringBuilder sql=new StringBuilder();
		sql.append("	SELECT A.GWA          AS  departmentCode												");
		sql.append("	      ,A.GWA_NAME     AS  departmentName												");
		sql.append("	FROM VW_BAS_GWA A																		");
		sql.append("	WHERE A.OUT_JUBSU_YN = 'Y'																");
		sql.append("	  AND A.START_DATE = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA,SYSDATE() ,A.HOSP_CODE )			");
		sql.append("	  AND A.HOSP_CODE = :hospCode															");
		sql.append("	  AND A.LANGUAGE  = :language															");
		sql.append("	  AND (A.GWA LIKE :find1 OR A.GWA_NAME LIKE :find1)									");
		sql.append("	ORDER BY A.GWA");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("find1", find1 + "%");
		
		List<OCS2016GetLinkingDepartmentInfo> listInfo= new JpaResultMapper().list(query, OCS2016GetLinkingDepartmentInfo.class);
		return listInfo;
	}
	
	@Override
	public List<OCS2016GetUserDepartmentInfo> getOCS2016GetUserDepartmentInfo(String hospCode, String doctor, String language){
		StringBuilder sql=new StringBuilder();
		sql.append("	SELECT  B.GWA           AS  departmentCode,		");
		sql.append("	        B.GWA_NAME      AS  departmentName		");
		sql.append("	FROM BAS0270 A 									");
		sql.append("	JOIN VW_BAS_GWA B ON A.DOCTOR_GWA = B.GWA		");
		sql.append("	                 AND A.HOSP_CODE = B.HOSP_CODE	");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code				");
		sql.append("	  AND A.SABUN = :f_doctor						");
		sql.append("	  AND B.LANGUAGE = :f_language					");

		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_language", language);
		
		List<OCS2016GetUserDepartmentInfo> listInfo= new JpaResultMapper().list(query, OCS2016GetUserDepartmentInfo.class);
		return listInfo;
	}
	
}

