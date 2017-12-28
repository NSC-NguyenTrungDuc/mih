package nta.med.data.dao.medi.bas.impl;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0270RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0270FwdDoctorInfo;
import nta.med.data.model.ihis.bass.Inp1003U00FwkDoctorListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetDoctorInfo;
import nta.med.data.model.ihis.inps.INP1003U00fwkDoctorInfo;
import nta.med.data.model.ihis.inps.INP1003U01fbxInp1003Info;
import nta.med.data.model.ihis.nuro.DoctorInfo;
import nta.med.data.model.ihis.nuro.KcckApiDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01DoctorNameInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01FwkDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GetDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00DoctorReservationStatusListItemInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0503Q00DoctorListInfo;
import nta.med.data.model.ihis.ocsa.OCSAOCS0270Q00GridBAS0270RowInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1;
import nta.med.data.model.ihis.ocsa.PatientLinkingFwkDoctorInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99LayoutCommonListInfo;

/**
 * @author dainguyen.
 */
public class Bas0270RepositoryImpl implements Bas0270RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Bas0270RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<String> getNuroNUR2001U04DoctorName(String hospitalCode, String doctorCode, String date) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR_NAME                                                             ");
		sql.append("FROM BAS0270 A                                                                   ");
		sql.append("WHERE A.HOSP_CODE = :hospitalCode                                                ");
		sql.append("        AND A.DOCTOR = :doctorCode                                               ");
		sql.append("        AND STR_TO_DATE(:date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("doctorCode", doctorCode);
		query.setParameter("date", date);
		List<String> list = (List<String>)query.getResultList();
		
		return list;
	}

	@Override
	public List<NuroOUT1101Q01FwkDoctorInfo> getNuroOUT1101Q01FwkDoctorInfo(String hospCode, String deptCode, String find1){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT A.SABUN, A.DOCTOR_NAME                                             ");
		sql.append("		FROM BAS0270 A                                                             ");
		sql.append("		WHERE A.HOSP_CODE  = :hospCode                                             ");
		sql.append("		  AND A.DOCTOR_GWA LIKE CONCAT(:deptCode, '%')                          ");
		sql.append("		  AND (A.DOCTOR  LIKE CONCAT(:find1, '%')                                  ");
		sql.append("		  OR A.DOCTOR_NAME LIKE CONCAT(:find1, '%'))                               ");
		sql.append("		  AND A.START_DATE = ( SELECT MAX(B.START_DATE)                            ");
		sql.append("		                       FROM BAS0270 B                                      ");
		sql.append("		                       WHERE B.HOSP_CODE = A.HOSP_CODE                     ");
		sql.append("		                       AND B.DOCTOR = A.DOCTOR)                            ");
		sql.append("		  AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) > SYSDATE()");
		sql.append("		ORDER BY 1                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("deptCode", deptCode);
		query.setParameter("find1", find1);
		
		List<NuroOUT1101Q01FwkDoctorInfo> list = new JpaResultMapper().list(query, NuroOUT1101Q01FwkDoctorInfo.class);
		return list;
	}
	
	@Override
	public List<NuroOUT1101Q01DoctorNameInfo> getNuroOUT1101Q01DoctorNameInfo(String hospCode, String gwa, String doctor){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT DISTINCT A.DOCTOR_NAME                                             ");
		sql.append("   FROM BAS0270 A                                                            ");
		sql.append("   WHERE A.HOSP_CODE  = :hospCode                                            ");
		sql.append("   AND A.DOCTOR_GWA LIKE :gwa				                                  ");
		sql.append("   AND A.SABUN      = :doctor                                                ");
		sql.append("   AND A.START_DATE = ( SELECT MAX(B.START_DATE)                             ");
		sql.append("   FROM BAS0270 B                                                            ");
		sql.append("   WHERE B.HOSP_CODE = A.HOSP_CODE                                           ");
		sql.append("   AND B.DOCTOR = A.DOCTOR)                                                  ");
		sql.append("   AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) > SYSDATE() ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("gwa", gwa + "%");
		query.setParameter("doctor", doctor);
		
		List<NuroOUT1101Q01DoctorNameInfo> list = new JpaResultMapper().list(query, NuroOUT1101Q01DoctorNameInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getNuroRES0102U00CboDoctorItemInfo(String hospCode, String departmentCode, String appDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.DOCTOR                                              DOCTOR ,                                      ");
		sql.append("          CONCAT ('[',A.DOCTOR,']',A.DOCTOR_NAME )         DOCTOR_NAME                                        ");
		sql.append("   FROM BAS0270 A                                                                                             ");
		sql.append("   WHERE A.HOSP_CODE  = :hospCode                                                                             ");
		sql.append("      AND A.DOCTOR_GWA = :departmentCode                                                                      ");
		sql.append("      AND DATE_FORMAT(:appDate, '%Y/%m/%d') BETWEEN A.START_DATE                                              ");
		sql.append("                                                AND IFNULL(A.END_DATE, DATE_FORMAT('9998/12/31', '%Y/%m/%d')) ");
		sql.append("   ORDER BY SUBSTR(A.DOCTOR, 3, 1), A.DOCTOR                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("departmentCode", departmentCode);
		query.setParameter("appDate", appDate);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<NuroRES0102U00GetDoctorInfo> getNuroRES0102U00GetDoctorInBetweenDate(String hospCode, String doctor, String startDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(A.TONGGYE_DOCTOR,A.DOCTOR) DOCTOR ");
		sql.append("FROM BAS0270 A                                  ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                   ");
		sql.append("  AND A.DOCTOR = :doctor                        ");
		sql.append("  AND STR_TO_DATE(:startDate, '%Y/%m/%d')       ");
		sql.append("  BETWEEN A.START_DATE AND A.END_DATE           ");
		sql.append("LIMIT 1                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("startDate", startDate);
		
		List<NuroRES0102U00GetDoctorInfo> list = new JpaResultMapper().list(query, NuroRES0102U00GetDoctorInfo.class);
		return list;
	}
	
	@Override
	public List<NuroRES1001U00DoctorReservationStatusListItemInfo> getDoctorReservationStatusList(String hospitalCode, String deptCode, String doctorCode, boolean isOtherClinic){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR_NAME,                                                              ");
		sql.append("        IFNULL(A.RESER_YN, 'N')    RESER_YN                                        ");
		sql.append("FROM BAS0270 A                                                                     ");
		sql.append("WHERE A.HOSP_CODE  = :hospitalCode                                                 ");
		if (!StringUtils.isEmpty(doctorCode)) {
			sql.append("        AND A.DOCTOR     = :doctorCode                                         ");
		}
		if (!StringUtils.isEmpty(deptCode)) {
			sql.append("        AND A.DOCTOR_GWA = :deptCode                                           ");
		}
		if(isOtherClinic){
			sql.append("        AND A.RESER_OUT_YN  = 'Y'                                               ");
		}
		sql.append("        AND DATE_FORMAT(SYSDATE(), '%Y-%m-%d') BETWEEN A.START_DATE AND A.END_DATE ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(deptCode)) {
			query.setParameter("deptCode", deptCode);
		}
		if (!StringUtils.isEmpty(doctorCode)) {
			query.setParameter("doctorCode", doctorCode);
		}
		
		List<NuroRES1001U00DoctorReservationStatusListItemInfo> list = new JpaResultMapper().list(query, NuroRES1001U00DoctorReservationStatusListItemInfo.class);
		return list;
	}
	
	@Override
	public List<NuroOUT1001U01GetDoctorInfo> getNuroOUT1001U01GetDoctorInfo(String language, String hospCode, String naewonDate, String gwa, String find1){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT  A.GWA, A.GWA_NAME                                                                                             ");
		sql.append("      , A.DOCTOR                                                                                                      ");
		sql.append("       , A.DOCTOR_NAME                                                                                                ");
		sql.append("      , IFNULL(Z.WAITING_PATIENT, 0)                                                                                  ");
		sql.append("      , IFNULL(Z.TOTAL_PATIENT, 0)                                                                                    ");
		sql.append("  FROM                                                                                                                ");
		sql.append("  ( SELECT A.DOCTOR            DOCTOR                                                                                 ");
		sql.append("               , A.DOCTOR_GWA        GWA                                                                              ");
		sql.append("               , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, DATE_FORMAT(:naewonDate,'%Y/%m/%d'), :hospCode)      DOCTOR_NAME   ");
		sql.append("               , FN_BAS_LOAD_GWA_NAME(A.DOCTOR_GWA, A.START_DATE, :hospCode, :language)        GWA_NAME               ");
		sql.append("               , A.HOSP_CODE                                                                                          ");
		sql.append("            FROM BAS0270 A                                                                                            ");
		sql.append("           WHERE A.HOSP_CODE    = :hospCode                                                                           ");
		sql.append("             AND A.DOCTOR_GWA   = :gwa                                                                                ");
		sql.append("             AND DATE_FORMAT(:naewonDate,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE                              ");
		sql.append("        ) A  LEFT OUTER JOIN                                                                                          ");
		sql.append("        ( SELECT A.DOCTOR                                                                                             ");
		sql.append("               , SUM(IF(A.NAEWON_YN = 'Y' OR A.NAEWON_YN = 'H', 1, 0)) WAITING_PATIENT                                ");
		sql.append("               , COUNT(1)                            TOTAL_PATIENT                                                    ");
		sql.append("               , A.HOSP_CODE                         HOSP_CODE                                                        ");
		sql.append("            FROM OUT1001 A                                                                                            ");
		sql.append("           WHERE A.HOSP_CODE   = :hospCode                                                                            ");
		sql.append("             AND DATE_FORMAT(A.NAEWON_DATE ,'%Y/%m/%d') = :naewonDate                                                 ");
		sql.append("             AND A.GWA         = :gwa                                                                                 ");
		sql.append("           GROUP BY A.GWA, A.DOCTOR, A.HOSP_CODE                                                                      ");
		sql.append("        ) Z ON  Z.HOSP_CODE     = A.HOSP_CODE                                                                         ");
		sql.append("    AND Z.DOCTOR         = A.DOCTOR                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE      = :hospCode                                                                                  ");
		sql.append("     AND A.DOCTOR_NAME    LIKE :find1                                                                                 ");
		sql.append("  ORDER BY A.DOCTOR                                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("gwa", gwa);
		query.setParameter("find1", "%" + find1 + "%");
		
		List<NuroOUT1001U01GetDoctorInfo> list = new JpaResultMapper().list(query, NuroOUT1001U01GetDoctorInfo.class);
		return list;
	}
	
	@Override
	public List<OCSAOCS0270Q00GridBAS0270RowInfo> getOCSAOCS0270Q00GridBAS0270RowInfo(String language, String hospCode, String allGubun, String gwa,
			String doctorGrade, String fQuery, String osimGubun, String date, boolean reserOutFlg){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT A.DOCTOR      DOCTOR                                                                                                                                                     		");
		sql.append("     , A.DOCTOR_NAME          DOCTOR_NAME                                                                                                                                                		");
		sql.append("     , A.CONT_KEY             CONT_KEY , A.DEPARTMENT_NAME    FROM (                                                                                                                          	");
		if(!StringUtils.isEmpty(allGubun) && allGubun.equalsIgnoreCase("Y")){
			sql.append("  SELECT '%'                                   DOCTOR                                                                                                                              			");
			sql.append("             , FN_NUR_LOAD_CODE_NAME('ALLTEXT', '%', :hospCode, :language) DOCTOR_NAME                                                                                              		");
			sql.append("             ,'%%'                               CONT_KEY                                                                                                                                	");
			sql.append("             ,'%'                               DEPARTMENT_NAME                                                                                                                           	");
			sql.append("         UNION ALL                                                                                                                                                                      	");
		}
		
		sql.append("        SELECT DISTINCT                                                                                                                                                                  		");
		sql.append("               A.DOCTOR                              DOCTOR                                                                                                                              		");
		sql.append("             , A.DOCTOR_NAME                         DOCTOR_NAME                                                                                                                         		");
		sql.append("             , CONCAT(IFNULL(A.DOCTOR_NAME2,''),IFNULL(A.TONGGYE_DOCTOR,''))      CONT_KEY  , B.BUSEO_NAME   DEPARTMENT_NAME                                                               		");
		sql.append("          FROM BAS0270 A  INNER JOIN BAS0260 B ON A.HOSP_CODE = B.HOSP_CODE AND A.DOCTOR_GWA = B.GWA AND B.LANGUAGE = :language  AND B.BUSEO_GUBUN = '1'                                        ");
		sql.append("         WHERE A.HOSP_CODE     = :hospCode                                                                                                                                            			");
		sql.append("           AND A.DOCTOR_GWA LIKE :gwa                                                                                                                                                  			");
		sql.append("           AND A.DOCTOR_GRADE LIKE :doctorGrade                                                                                                                                       			");
		sql.append("           AND (A.DOCTOR LIKE :fQuery OR A.DOCTOR_NAME LIKE :fQuery)                                                                                                                   			");
		sql.append("            AND ((:osimGubun != '%' AND A.DOCTOR_NAME2 LIKE CONCAT(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '01',:hospCode, :language),                     					");
		sql.append("                                          IF(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '01',:hospCode, :language) = NULL, '', '%')))                            				");
		sql.append("            OR  (:osimGubun = '%'))                                                                                                                                                   			");
		sql.append("           AND  IFNULL(DATE_FORMAT(:date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE                                                                                  			");
		if(reserOutFlg){
			sql.append("	   AND A.RESER_OUT_YN = 'Y'																																								");
		}
		
		sql.append("        UNION ALL                                                                                                                                                                        		");
		
		sql.append("        SELECT DISTINCT                                                                                                                                                                  		");
		sql.append("               A.DOCTOR                              DOCTOR                                                                                                                              		");
		sql.append("             , A.DOCTOR_NAME                         DOCTOR_NAME                                                                                                                         		");
		sql.append("             , CONCAT(IFNULL(A.DOCTOR_NAME2,''),IFNULL(A.TONGGYE_DOCTOR,''))      CONT_KEY , B.BUSEO_NAME   DEPARTMENT_NAME                                                                		");
		sql.append("          FROM BAS0270 A  INNER JOIN BAS0260 B ON A.HOSP_CODE = B.HOSP_CODE AND A.DOCTOR_GWA = B.GWA AND B.LANGUAGE = :language  AND B.BUSEO_GUBUN = '1'                                        ");
		sql.append("         WHERE A.HOSP_CODE     = :hospCode                                                                                                                                            			");
		sql.append("           AND A.DOCTOR_GWA LIKE :gwa                                                                                                                                                  			");
		sql.append("           AND A.DOCTOR_GRADE LIKE :doctorGrade                                                                                                                                       			");
		sql.append("           AND (A.DOCTOR LIKE :fQuery OR A.DOCTOR_NAME LIKE :fQuery)                                                                                                                   			");
		sql.append("             AND ((:osimGubun != '%' AND A.DOCTOR_NAME2 LIKE CONCAT(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '02',:hospCode, :language),                    					");
		sql.append("                                          IF(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '02',:hospCode, :language) = NULL, '', '%')))                            				");
		sql.append("            OR  (:osimGubun = '%'))                                                                                                                                                   			");
		sql.append("           AND  IFNULL(DATE_FORMAT(:date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE                                                                                  			");
		if(reserOutFlg){
			sql.append("	   AND A.RESER_OUT_YN = 'Y'																																								");
		}
		
		sql.append("         UNION ALL                                                                                                                                                                       		");
		
		sql.append("        SELECT DISTINCT                                                                                                                                                                  		");
		sql.append("               A.DOCTOR                              DOCTOR                                                                                                                              		");
		sql.append("             , A.DOCTOR_NAME                         DOCTOR_NAME                                                                                                                         		");
		sql.append("             , CONCAT(IFNULL(A.DOCTOR_NAME2,''),IFNULL(A.TONGGYE_DOCTOR,'') )     CONT_KEY  , B.BUSEO_NAME   DEPARTMENT_NAME                                                            		");
		sql.append("          FROM BAS0270 A  INNER JOIN BAS0260 B ON A.HOSP_CODE = B.HOSP_CODE AND A.DOCTOR_GWA = B.GWA AND B.LANGUAGE = :language  AND B.BUSEO_GUBUN = '1'                                    	");
		sql.append("         WHERE A.HOSP_CODE     = :hospCode                                                                                                                                            			");
		sql.append("           AND A.DOCTOR_GWA LIKE :gwa                                                                                                                                                  			");
		sql.append("           AND A.DOCTOR_GRADE LIKE :doctorGrade                                                                                                                                       			");
		sql.append("           AND (A.DOCTOR LIKE :fQuery OR A.DOCTOR_NAME LIKE :fQuery)                                                                                                                   			");
		sql.append("            AND ((:osimGubun != '%' AND A.DOCTOR_NAME2 LIKE CONCAT(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '03',:hospCode, :language),                     					");
		sql.append("                                          IF(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '03',:hospCode, :language) = NULL, '', '%')))                            				");
		sql.append("            OR  (:osimGubun = '%'))                                                                                                                                                   			");
		sql.append("           AND  IFNULL(DATE_FORMAT(:date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE                                                                                  			");
		if(reserOutFlg){
			sql.append("	   AND A.RESER_OUT_YN = 'Y'																																								");
		}
		
		sql.append("         UNION ALL                                                                                                                                                                       		");
		
		sql.append("        SELECT DISTINCT                                                                                                                                                                  		");
		sql.append("               A.DOCTOR                              DOCTOR                                                                                                                              		");
		sql.append("             , A.DOCTOR_NAME                         DOCTOR_NAME                                                                                                                         		");
		sql.append("             , CONCAT(IFNULL(A.DOCTOR_NAME2,''),IFNULL(A.TONGGYE_DOCTOR,'')   )   CONT_KEY , B.BUSEO_NAME   DEPARTMENT_NAME                                                               		");
		sql.append("          FROM BAS0270 A  INNER JOIN BAS0260 B ON A.HOSP_CODE = B.HOSP_CODE AND A.DOCTOR_GWA = B.GWA AND B.LANGUAGE = :language   AND B.BUSEO_GUBUN = '1'                                   	");
		sql.append("         WHERE A.HOSP_CODE     = :hospCode                                                                                                                                            			");
		sql.append("           AND A.DOCTOR_GWA LIKE :gwa                                                                                                                                                  			");
		sql.append("           AND A.DOCTOR_GRADE LIKE :doctorGrade                                                                                                                                       			");
		sql.append("           AND (A.DOCTOR LIKE :fQuery OR A.DOCTOR_NAME LIKE :fQuery)                                                                                                                   			");
		sql.append("             AND ((:osimGubun != '%' AND A.DOCTOR_NAME2 LIKE CONCAT(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '04',:hospCode, :language),                    					");
		sql.append("                                          IF(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '04',:hospCode, :language) = NULL, '', '%')))                            				");
		sql.append("            OR  (:osimGubun = '%'))                                                                                                                                                   			");
		sql.append("           AND  IFNULL(DATE_FORMAT(:date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE                                                                                  			");
		if(reserOutFlg){
			sql.append("	   AND A.RESER_OUT_YN = 'Y'																																								");
		}
		
		sql.append("         UNION ALL                                                                                                                                                                       		");
		
		sql.append("        SELECT DISTINCT A.DOCTOR                     DOCTOR                                                                                                                              		");
		sql.append("             , A.DOCTOR_NAME                         DOCTOR_NAME                                                                                                                         		");
		sql.append("             , CONCAT(IFNULL(A.DOCTOR_NAME2,''),IFNULL(A.TONGGYE_DOCTOR,'')  )    CONT_KEY  , B.BUSEO_NAME   DEPARTMENT_NAME                                                               		");
		sql.append("          FROM BAS0270 A   INNER JOIN BAS0260 B ON A.HOSP_CODE = B.HOSP_CODE AND A.DOCTOR_GWA = B.GWA AND B.LANGUAGE = :language  AND B.BUSEO_GUBUN = '1'                                   	");
		sql.append("         WHERE A.HOSP_CODE     = :hospCode                                                                                                                                            			");
		sql.append("           AND A.DOCTOR_GWA LIKE :gwa                                                                                                                                                  			");
		sql.append("           AND A.DOCTOR_GRADE LIKE :doctorGrade                                                                                                                                       			");
		sql.append("           AND (A.DOCTOR LIKE :fQuery OR A.DOCTOR_NAME LIKE :fQuery)                                                                                                                   			");
		sql.append("             AND ((:osimGubun != '%' AND A.DOCTOR_NAME2 LIKE CONCAT(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '05',:hospCode, :language),                    					");
		sql.append("                                          IF(FN_OCS_LOAD_CODE_NAME(CONCAT('OSIM_GUBUN','_',:osimGubun), '05',:hospCode, :language) = NULL, '', '%')))                            				");
		sql.append("            OR  (:osimGubun = '%'))                                                                                                                                                   			");
		if(reserOutFlg){
			sql.append("	   AND A.RESER_OUT_YN = 'Y'	");
		} 
		sql.append("           AND  IFNULL(DATE_FORMAT(:date, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE   ) A                                                                            			");
		
		sql.append(" ORDER BY 4                                                                                                                                                                              		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		query.setParameter("osimGubun", osimGubun);
		query.setParameter("gwa", gwa);
		query.setParameter("date", date);
		query.setParameter("doctorGrade", doctorGrade);
		query.setParameter("fQuery", "%" + fQuery + "%");
				
		List<OCSAOCS0270Q00GridBAS0270RowInfo> list = new JpaResultMapper().list(query, OCSAOCS0270Q00GridBAS0270RowInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getNuroNUR1001R00GetGwaDoctorList(String hospCode, String gwa, String month){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                   ");
		sql.append("       A.DOCTOR                                                                                   ");
		sql.append("     , A.DOCTOR_NAME                                                                              ");
		sql.append("  FROM BAS0270 A                                                                                  ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                                                                ");
		sql.append("   AND A.DOCTOR_GWA = :f_gwa                                                                      ");
		sql.append(" AND  :f_month BETWEEN DATE_FORMAT(A.START_DATE, '%Y%m') AND  DATE_FORMAT(A.END_DATE, '%Y%m')      ");
		sql.append("   AND IFNULL(A.COMMON_DOCTOR_YN, 'N') = 'N'                                                      ");
		sql.append(" ORDER BY 1                                                                                       ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_month", month);
				
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getOcsaOCS0503Q00DoctorNameList(String hospCode, String gwa, String code){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR_NAME                                                                                           ");
		sql.append("  FROM BAS0270 A                                                                                               ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                                                                             ");
		sql.append("   AND A.DOCTOR_GWA = :f_gwa                                                                                   ");
		sql.append("   AND A.START_DATE = FN_BAS_LOAD_DOCTOR_YMD( A.DOCTOR , DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), :f_hosp_code )    ");
		sql.append("   AND IFNULL(A.END_DATE, DATE_ADD(SYSDATE(),INTERVAL 1 MONTH)) > SYSDATE()                                    ");
		sql.append("   AND A.DOCTOR     = :f_code                                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
				
		List<String> listDoctorName = query.getResultList();
		if(!CollectionUtils.isEmpty(listDoctorName)){
			return listDoctorName.get(0);
		}
		return null;
	}
	
	@Override
	public List<OCS0503Q00DoctorListInfo> getOcsaOCS0503Q00DoctorList(String hospCode, String language, String gwa){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT '%' DOCTOR, FN_ADM_MSG(221, :f_language) DOCTOR_NAME, '0' SORT                                              ");
		sql.append("     UNION ALL                                                                                                     ");
		sql.append("    SELECT A.DOCTOR DOCTOR, A.DOCTOR_NAME, CONCAT(SUBSTR(A.DOCTOR, 3, 1), A.DOCTOR) SORT                           ");
		sql.append("      FROM BAS0270 A                                                                                               ");
		sql.append("     WHERE A.HOSP_CODE = :f_hosp_code                                                                              ");
		sql.append("       AND A.START_DATE = FN_BAS_LOAD_DOCTOR_YMD( A.DOCTOR , DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), :f_hosp_code )    ");
		sql.append("       AND IFNULL(A.END_DATE, DATE_ADD(SYSDATE(),INTERVAL 1 MONTH)) > SYSDATE()                                    ");
		sql.append("       AND A.DOCTOR_GWA = :f_gwa                                                                                   ");
		sql.append("     ORDER BY 3                                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
				
		List<OCS0503Q00DoctorListInfo> list = new JpaResultMapper().list(query, OCS0503Q00DoctorListInfo.class);
		return list;
	}
	
	
	@Override
	public List<SchsSCH0201U99LayoutCommonListInfo> getSchsSCH0201U99LayoutCommonListInfo(String hospCode, String doctor, String gwa) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.DOCTOR_NAME   																			");
		sql.append("	     , IFNULL(A.RESER_YN, 'N')    RESER_YN                                                      ");
		sql.append("	 FROM BAS0270 A                                                                                 ");
		sql.append("	WHERE A.HOSP_CODE  = :hospCode                                                               ");
		sql.append("	  AND A.DOCTOR     = :doctor                                                                  ");
		sql.append("	  AND A.DOCTOR_GWA = :gwa                                                                     ");
		sql.append("	  AND DATE_FORMAT(SYSDATE(),'%Y-%m-%d %H:%m:%s') BETWEEN A.START_DATE AND A.END_DATE ;          ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("gwa", gwa);
				
		List<SchsSCH0201U99LayoutCommonListInfo> list = new JpaResultMapper().list(query, SchsSCH0201U99LayoutCommonListInfo.class);
		return list;
	}

	@Override
	public String getDoctorNameOCS0503U00(String hospCode, String code) {
		StringBuilder sql=new StringBuilder();
		sql.append("SELECT A.DOCTOR_NAME FROM BAS0270 A ");
		sql.append("WHERE A.HOSP_CODE = :hospCode ");
		sql.append("AND A.DOCTOR= :f_code ");
		sql.append("AND A.START_DATE = FN_BAS_LOAD_DOCTOR_YMD( A.doctor,SYSDATE(),A.HOSP_CODE) ");
		sql.append("AND IFNULL(A.END_DATE, ADDDATE(SYSDATE(),1)) > SYSDATE() ");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_code", code);
		List<String> listDoctorName=query.getResultList();
		if(!CollectionUtils.isEmpty(listDoctorName)){
			return listDoctorName.get(0);
		}
		return null;
	}

	@Override
	public List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1> getOcsaOCS0503U00GetFindWorkerListInfoProcess2(String hospCode, String refCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.DOCTOR, A.DOCTOR_NAME                                                                          ");
		sql.append(" FROM BAS0270 A                                                                                          ");
		sql.append(" WHERE A.DOCTOR_GWA = :refCode                                                                           ");
		sql.append(" AND A.HOSP_CODE  = :hospCode                                                                            ");
		sql.append(" AND A.START_DATE = FN_BAS_LOAD_DOCTOR_YMD( A.DOCTOR ,SYSDATE(),A.HOSP_CODE )                            ");
		sql.append(" AND IFNULL(A.END_DATE, ADDDATE(SYSDATE(),1)) > SYSDATE()                                                ");
		sql.append(" ORDER BY SUBSTR(A.DOCTOR, 3, 1), A.DOCTOR                                                               ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("refCode", refCode);
		query.setParameter("hospCode", hospCode);
		List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1> listWorker= new JpaResultMapper().list(query, OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1.class);
		return listWorker;
	}

	@Override
	public List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1> getOcsaOCS0503U00GetFindWorkerListInfoProcess5(
			String hospCode, String refCode) {
		//the same sql as process 2
		return null;
	}
	
	@Override
	public String getOUTSANGU00DoctorName(String hospCode, String gwa, String find, Date doctorYmd) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT     A.DOCTOR_NAME                                                                ");
		sql.append("	 FROM BAS0270 A                                                                         ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                                                       	");
		sql.append("	 AND IF(:gwa = '%', '%', A.DOCTOR_GWA)   = :gwa                                      	");
		sql.append("	 AND  (A.DOCTOR       LIKE CONCAT('%' , :find , '%')                                 	");
		sql.append("	                 OR A.DOCTOR_NAME  LIKE CONCAT('%' , :find , '%'))                   	");
		sql.append("	 AND A.START_DATE = ( SELECT MAX(B.START_DATE)                                          ");
		sql.append("	                       FROM BAS0270 B                                                   ");
		sql.append("	                       WHERE B.HOSP_CODE   = A.HOSP_CODE                                ");
		sql.append("	                       AND B.DOCTOR      = A.DOCTOR                                     ");
		sql.append("	                       AND B.START_DATE <= :doctorYmd )                             	");
		sql.append("	 AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) >    :doctorYmd      	 ");                                    
		sql.append("	 ORDER BY  SORT_KEY;                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("hospCode", hospCode);
	    query.setParameter("gwa", gwa);
	    query.setParameter("find", find);
	    query.setParameter("doctorYmd", doctorYmd);
	     
	     List<String> listResult = query.getResultList();
			if(listResult != null && !listResult.isEmpty()){
				return listResult.get(0);
			}
		return null;
	}
	
	@Override
	public String getDoctorNameBAS0270(String hospCode, String gwa, String doctor, String date){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DOCTOR_NAME                        ");
		sql.append("   FROM BAS0270                            ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code           ");
		sql.append("    AND DOCTOR_GWA = :f_gwa                ");
		sql.append("    AND DOCTOR     = :f_doctor             ");
		sql.append("    AND STR_TO_DATE(:f_date, '%Y/%m/%d')   ");
		sql.append("BETWEEN START_DATE AND END_DATE            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_gwa", gwa);
	    query.setParameter("f_doctor", doctor);
	    query.setParameter("f_date", date);
	     
	    List<String> listResult = query.getResultList();
			if(listResult != null && !listResult.isEmpty()){
				return listResult.get(0);
			}
		return null;
	}
	
	@Override
	public List<BAS0270FwdDoctorInfo> getBAS0270FwdDoctorInfo(String hospCode, String find1){
		find1 += "%";
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                         ");
		sql.append(" DOCTOR                                                 ");
		sql.append(" , DOCTOR_NAME                                          ");
		sql.append(" , DOCTOR_GWA                                           ");
		sql.append(" FROM BAS0270                                           ");
		sql.append(" WHERE HOSP_CODE = :hosp_code                           ");
		sql.append(" AND ( DOCTOR LIKE :find1 OR DOCTOR_NAME LIKE :find1 )  ");
		sql.append(" ORDER BY DOCTOR_GWA, DOCTOR_NAME;                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("find1", find1);
		List<BAS0270FwdDoctorInfo> list = new JpaResultMapper().list(query, BAS0270FwdDoctorInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOcsOrderBizLoadComboDataSourceListItem(
			String hospCode, String doctor, String date) {
		StringBuilder sql = new StringBuilder();
		if(StringUtils.isEmpty(doctor)){
			doctor = null;
		}
		sql.append("	SELECT A.DOCTOR CODE, 													");																	
		sql.append("	A.DOCTOR_NAME CODE_NAME                                                 ");
		sql.append("	FROM BAS0270 A                                                          ");
		sql.append("	WHERE A.HOSP_CODE   = :hospCode                                         ");
		sql.append("	 AND A.DOCTOR_GWA LIKE CASE :doctor WHEN '' THEN '%' ELSE :doctor END   ");
		sql.append("	 AND STR_TO_DATE(:date,  '%Y/%m/%d') BETWEEN A.START_DATE               ");
		sql.append("			 AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))       ");
		sql.append("	ORDER BY A.DOCTOR                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("date", date);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getMainGwaDoctorCodeInfo(String hospCode, String memb) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.DOCTOR                                                                                    ");
		sql.append("    FROM BAS0270 A                                                                                  ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                                                 ");
		sql.append("     AND A.SABUN = :f_memb                                                                          ");
		sql.append("     AND SYSDATE() BETWEEN A.START_DATE AND IFNULL(A.END_DATE,STR_TO_DATE('99981231', '%Y%m%d'))    ");
		sql.append("     AND IFNULL(A.MAIN_GWA_YN, 'N') = 'Y'                                                           ");
		sql.append("   ORDER BY A.DOCTOR LIMIT 1																		");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", memb);
		List<String> listResult =query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public String getLoadColumnCodeNameInfoCaseGwaDoctor(String hospCode,String arg1, String arg2, String arg3) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT A.DOCTOR_NAME                                                                                  ");
		sql.append("   FROM BAS0270 A                                                                                               ");
		sql.append("  WHERE A.DOCTOR_GWA LIKE :f_aArgu1                                                                             ");
		sql.append("    AND A.DOCTOR     = :f_aArgu2                                                                                ");
		if(!StringUtils.isEmpty(arg3)){
			sql.append("    AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:f_aArgu3) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')   ");
			sql.append("    AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:f_aArgu3) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')   ");
		}
		sql.append("    AND A.HOSP_CODE  = :f_hosp_code																				");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aArgu1", arg1);
		query.setParameter("f_aArgu2", arg2);
		if(!StringUtils.isEmpty(arg3)){
			query.setParameter("f_aArgu3", arg3);  
		}
		 
		List<String> listResult =query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	public List<ComboListItemInfo> getDoctorComboListItemInfo(String hospCode, String doctorGwa){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.DOCTOR, A.DOCTOR_NAME 	");
		sql.append("	FROM BAS0270 A 	");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code	");
		sql.append("	AND A.DOCTOR_GWA = :f_doctor_gwa	");
		sql.append("	AND DATE_FORMAT(SYSDATE() ,'%Y%m%d') BETWEEN A.START_DATE 	");
		sql.append("	AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d')) 	");
		sql.append("	ORDER BY SUBSTR(A.DOCTOR, 3, 1), A.DOCTOR	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor_gwa", doctorGwa);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	public List<Inp1003U00FwkDoctorListItemInfo> getInp1003U00FwkDoctorListItemInfo(Date doctorYmd, 
			String hospCode, String language, String gwa, String find1){
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT A.DOCTOR																									");
		sql.append("	     , A.DOCTOR_NAME                                                                                                ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.DOCTOR_GWA, STR_TO_DATE(:f_doctor_ymd, '%Y%m%d'), :f_hosp_code, :language) GWA_NAME   ");
		sql.append("	  FROM BAS0270 A                                                                                                    ");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code                                                                                  ");
		sql.append("	   AND IF(:f_gwa = '%', '%', A.DOCTOR_GWA)   = :f_gwa                                                               ");
		sql.append("	   AND (   A.DOCTOR       LIKE '%' || :f_find1 || '%'                                                               ");
		sql.append("	        OR A.DOCTOR_NAME  LIKE '%' || :f_find1 || '%')                                                              ");
		sql.append("	   AND STR_TO_DATE(:f_doctor_ymd, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE                                     ");
		sql.append("	 ORDER BY A.DOCTOR, A.DOCTOR_GWA                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_doctor_ymd", doctorYmd);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_find1", find1);
		
		List<Inp1003U00FwkDoctorListItemInfo> list = new JpaResultMapper().list(query, Inp1003U00FwkDoctorListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getPHY2001U04CboDoctor(String hospCode, String gwa) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.DOCTOR , A.DOCTOR_NAME   FROM BAS0270 A WHERE A.HOSP_CODE = :f_hosp_code                   ");
		sql.append("   AND A.DOCTOR_GWA = :f_gwa   AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE ORDER BY A.DOCTOR   ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getOCS0203U00LoadAllMemb(String hospCode, String gwa){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DOCTOR, CONCAT('[',DOCTOR,']',DOCTOR_NAME)  MEMB_NAME  ");
		sql.append("  FROM BAS0270                                                ");
		sql.append("WHERE SYSDATE() BETWEEN START_DATE AND END_DATE               ");
		sql.append("  AND DOCTOR_GWA LIKE :f_gwa                                  ");
		sql.append("  AND HOSP_CODE     = :f_hosp_code                            ");
		sql.append("ORDER BY DOCTOR                                               ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa + "%");
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public OCS2015U00GetDoctorInfo getOCS2015U00GetDoctorInfo(String hospCode, String language, String doctor) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  A.DOCTOR_NAME ,                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
		sql.append("    B.GWA_NAME         ,                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                         
		sql.append("    C.YOYANG_NAME2     ,                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                             
		sql.append("    C.ADDRESS          ,                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                        
		sql.append("    C.TEL              ,                                  	");
		sql.append("    C.FAX              ,                                   	");
		sql.append("    C.HOMEPAGE                                            	");
		sql.append("    FROM                                                    ");                                                                                                                                                                                                                                                                                                                                                                                                                                                          
		sql.append("      BAS0270      A  ,                                     ");                                                                                                                                                                                                                                                                                                                                                                                                                                       
		sql.append("      BAS0260     B   ,                                     ");                                                                                                                                                                                                                                                                                                                                                                                                                                      
		sql.append("      BAS0001     C                                         ");                                                                                                                                                                                                                                                                                                                                                                                                                                     
		sql.append("     WHERE  A.HOSP_CODE      =        B.HOSP_CODE           ");                                                                                                                                                                                                                                                                                                                                                                                                                                           
		sql.append("    AND A.HOSP_CODE             =        C.HOSP_CODE        ");                                                                                                                                                                                                                                                                                                                                                                                                                                              
		sql.append("    AND A.DOCTOR_GWA            =        B.GWA              ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
		sql.append("    AND SYSDATE()  BETWEEN     C.START_DATE AND C.END_DATE  ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
		sql.append("    AND  A.HOSP_CODE            =        :hosp_code         ");   
		sql.append("    AND B.LANGUAGE             = :language                  ");   
		sql.append("    AND C.LANGUAGE             = :language                  ");   
		sql.append("    AND A.DOCTOR               =        :doctor             ");   
		sql.append("   ORDER BY B.START_DATE desc limit 1						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language );
		query.setParameter("doctor", doctor );
		List<OCS2015U00GetDoctorInfo> list = new JpaResultMapper().list(query, OCS2015U00GetDoctorInfo.class);
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<PatientLinkingFwkDoctorInfo> getPatientLinkingFwkDoctorInfo(String hospCode, String refCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.SABUN, A.DOCTOR_NAME                                                                           ");
		sql.append(" FROM BAS0270 A                                                                                          ");
		sql.append(" WHERE A.DOCTOR_GWA = :refCode                                                                           ");
		sql.append(" AND A.HOSP_CODE  = :hospCode                                                                            ");
		sql.append(" AND A.START_DATE = FN_BAS_LOAD_DOCTOR_YMD( A.DOCTOR ,SYSDATE(),A.HOSP_CODE )                            ");
		sql.append(" AND IFNULL(A.END_DATE, ADDDATE(SYSDATE(),1)) > SYSDATE()                                                ");
		sql.append(" AND A.OUT_DISCUSS_YN = 'Y' 																			 ");
		sql.append(" ORDER BY SUBSTR(A.DOCTOR, 3, 1), A.DOCTOR                                                               ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("refCode", refCode);
		query.setParameter("hospCode", hospCode);
		List<PatientLinkingFwkDoctorInfo> listWorker= new JpaResultMapper().list(query, PatientLinkingFwkDoctorInfo.class);
		return listWorker;
	}

	@Override
	public List<KcckApiDoctorInfo> getKcckApiGetDoctors(String hospCode, String department) {
		
		StringBuilder sql= new StringBuilder();
		sql.append("    SELECT DISTINCT                                                           ");
		sql.append("      A.DOCTOR,														          ");
		sql.append("    	A.DOCTOR_GRADE,													      ");
		sql.append("    	A.DOCTOR_NAME                                                         ");
		sql.append("    	,B.ID DEPARTMENT_ID                                                   ");
		sql.append("    	,A.ID DOCTOR_ID                                                       ");
		sql.append("    FROM 		BAS0271 A,											          ");
		sql.append("        		BAS0272 B,											          ");
		sql.append("	    		RES0102 C	                                         		  ");
		sql.append("    WHERE 1 = 1                                                               ");
		sql.append("    AND A.HOSP_CODE					=	B.HOSP_CODE						      ");
		sql.append("    AND	A.DOCTOR					  =	B.DOCTOR						      ");
		sql.append("    AND	A.HOSP_CODE					=	:hospCode						      ");
		sql.append("    AND	B.DOCTOR_GWA				=	:department                       	  ");
//		sql.append("    AND	A. RESER_YN					=	'Y'								      ");
		sql.append("    AND	A.END_DATE          >= CURRENT_DATE                               	  ");
		sql.append("	AND C.JINRYO_BREAK_YN   = 'N'                                    		  ");
		sql.append("    AND C.HOSP_CODE					=	A.HOSP_CODE						      ");
		sql.append("    AND C.DOCTOR = CONCAT(:department , A.DOCTOR)						      ");
		sql.append("    AND C.GWA					      =	B.DOCTOR_GWA                          ");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("department", department);
		
		List<KcckApiDoctorInfo> listKcckApiDoctorInfo= new JpaResultMapper().list(query, KcckApiDoctorInfo.class);
		return listKcckApiDoctorInfo;
	}

	@Override
	public List<KcckApiDoctorInfo> getKcckApiSearchDoctors(String hospCode, String department, String startDate, 
			String endDate, String locale, String reservationDate, String reservationTime, Integer pageSize, Integer pageIndex) {
		// getNuroRES0102U00GetDoctorInBetweenDate
		StringBuilder sql= new StringBuilder();
		sql.append("    SELECT                                                                    ");
		sql.append("      A.DOCTOR,														          ");
		sql.append("    	A.DOCTOR_GRADE,													      ");
		sql.append("    	A.DOCTOR_NAME                                                         ");
		sql.append("    	,B.ID DEPARTMENT_ID                                                   ");
		sql.append("    	,A.ID DOCTOR_ID                                                       ");
		sql.append("    FROM 		BAS0271 A,											          ");
		sql.append("        		BAS0272 B,											          ");
		sql.append("	    		RES0102 C	                                         		  ");
		sql.append("    WHERE 1 = 1                                                               ");
		sql.append("    AND A.HOSP_CODE					=	B.HOSP_CODE						      ");
		sql.append("    AND	A.DOCTOR					  =	B.DOCTOR						      ");
		sql.append("    AND	A.HOSP_CODE					=	:hospCode						      ");
		sql.append("    AND	B.DOCTOR_GWA				=	:department                       	  ");
//		sql.append("    AND	A. RESER_YN					=	'Y'								      ");
		sql.append("    AND	A.END_DATE          >= CURRENT_DATE                               	  ");
		sql.append("	AND C.JINRYO_BREAK_YN   = 'N'                                    		  ");
		sql.append("    AND C.HOSP_CODE					=	A.HOSP_CODE						      ");
		sql.append("    AND C.DOCTOR = CONCAT(:department , A.DOCTOR)							  ");
		sql.append("    AND C.GWA					      =	B.DOCTOR_GWA                          ");

		if(!StringUtils.isEmpty(startDate)){
			sql.append("    AND :startDate BETWEEN C.START_DATE AND C.END_DATE  				    ");
		}
		if(!StringUtils.isEmpty(endDate)){
			sql.append("    AND :endDate BETWEEN C.START_DATE AND C.END_DATE						");
		}
		if(!StringUtils.isEmpty(reservationDate)){
			sql.append("    AND :reservationDate BETWEEN C.START_DATE AND C.END_DATE                ");
		}
		if(!StringUtils.isEmpty(reservationTime)){
			// TODO
		}
		if(pageSize != null && pageIndex != null){
			sql.append(" limit :f_page_index, :f_page_size 											");
		}
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("department", department);
		if(!StringUtils.isEmpty(startDate)){
			query.setParameter("startDate", startDate);
		}
		if(!StringUtils.isEmpty(endDate)){
			query.setParameter("endDate", endDate);
		}
		if(!StringUtils.isEmpty(reservationDate)){
			query.setParameter("reservationDate", reservationDate);
		}
		if(!StringUtils.isEmpty(reservationTime)){
			// TODO
		}
		if(pageSize != null && pageIndex != null){
			query.setParameter("f_page_index", pageIndex);
			query.setParameter("f_page_size", pageSize);
		}
		
		List<KcckApiDoctorInfo> listKcckApiDoctorInfo= new JpaResultMapper().list(query, KcckApiDoctorInfo.class);
		return listKcckApiDoctorInfo;
	}
	
	@Override
	public String getDoctorNameBAS0271(String hospCode, String doctor, String date){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DOCTOR_NAME                        ");
		sql.append("   FROM BAS0271                            ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code           ");
		sql.append("    AND DOCTOR     = :f_doctor             ");
		sql.append("    AND STR_TO_DATE(:f_date, '%Y/%m/%d')   ");
		sql.append("BETWEEN START_DATE AND END_DATE            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_doctor", doctor);
	    query.setParameter("f_date", date);
	     
	    List<String> listResult = query.getResultList();
			if(listResult != null && !listResult.isEmpty()){
				return listResult.get(0);
			}
		return null;
	}
	
	@Override
	public BigInteger getKcckApiTotalRecordSearchDoctors(String hospCode, String department, String startDate, 
			String endDate, String locale, String reservationDate, String reservationTime) {
		// getNuroRES0102U00GetDoctorInBetweenDate
		StringBuilder sql= new StringBuilder();
		sql.append("    SELECT    COUNT(1)                                                        ");
		sql.append("    FROM 		BAS0271 A,											          ");
		sql.append("        		BAS0272 B,											          ");
		sql.append("	    		RES0102 C	                                         		  ");
		sql.append("    WHERE 1 = 1                                                               ");
		sql.append("    AND A.HOSP_CODE					=	B.HOSP_CODE						      ");
		sql.append("    AND	A.DOCTOR					  =	B.DOCTOR						      ");
		sql.append("    AND	A.HOSP_CODE					=	:hospCode						      ");
		sql.append("    AND	B.DOCTOR_GWA				=	:department                       	  ");
//		sql.append("    AND	A. RESER_YN					=	'Y'								      ");
		sql.append("    AND	A.END_DATE          >= CURRENT_DATE                               	  ");
		sql.append("	AND C.JINRYO_BREAK_YN   = 'N'                                    		  ");
		sql.append("    AND C.HOSP_CODE					=	A.HOSP_CODE						      ");
		sql.append("    AND C.DOCTOR = CONCAT(:department , A.DOCTOR)							  ");
		sql.append("    AND C.GWA					      =	B.DOCTOR_GWA                          ");
		
		if(!StringUtils.isEmpty(startDate)){
			sql.append("    AND :startDate BETWEEN C.START_DATE AND C.END_DATE  				    ");
		}
		if(!StringUtils.isEmpty(endDate)){
			sql.append("    AND :endDate BETWEEN C.START_DATE AND C.END_DATE						");
		}
		if(!StringUtils.isEmpty(reservationDate)){
			sql.append("    AND :reservationDate BETWEEN C.START_DATE AND C.END_DATE                ");
		}
		if(!StringUtils.isEmpty(reservationTime)){
			// TODO
		}
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("department", department);
		if(!StringUtils.isEmpty(startDate)){
			query.setParameter("startDate", startDate);
		}
		if(!StringUtils.isEmpty(endDate)){
			query.setParameter("endDate", endDate);
		}
		if(!StringUtils.isEmpty(reservationDate)){
			query.setParameter("reservationDate", reservationDate);
		}
		if(!StringUtils.isEmpty(reservationTime)){
			// TODO
		}
		
		List<BigInteger> list = query.getResultList();
		if(list != null && list.size() > 0 ){
			return list.get(0);
		}
		return BigInteger.ZERO;
	}
	@Override
	public List<DoctorInfo> searchDoctors(String hospCode, String department, String startDate, String endDate) {
		// getNuroRES0102U00GetDoctorInBetweenDate
		StringBuilder sql= new StringBuilder();
		sql.append("    SELECT                                                                    ");
		sql.append("      A.DOCTOR,														          ");
		sql.append("    	A.DOCTOR_GRADE,													      ");
		sql.append("    	A.DOCTOR_NAME                                                         ");
		sql.append("    	,B.ID DEPARTMENT_ID                                                   ");
		sql.append("    	,B.DOCTOR_GWA DOCTOR_GWA                                               ");
		sql.append("    	,A.ID DOCTOR_ID                                                       ");
		sql.append("    FROM 		BAS0271 A,											          ");
		sql.append("        		BAS0272 B,											          ");
		sql.append("	    		RES0102 C	                                         		  ");
		sql.append("    WHERE 1 = 1                                                               ");
		sql.append("    AND A.HOSP_CODE					=	B.HOSP_CODE						      ");
		sql.append("    AND	A.DOCTOR					  =	B.DOCTOR						      ");
		sql.append("    AND	A.HOSP_CODE					=	:hospCode						      ");
		if(!StringUtils.isEmpty(department))
		{
			sql.append("    AND	B.DOCTOR_GWA				=	:department                       ");
		}
//		sql.append("    AND	A. RESER_YN					=	'Y'								      ");
		sql.append("    AND	A.END_DATE          >= CURRENT_DATE                               	  ");
		sql.append("	AND C.JINRYO_BREAK_YN   = 'N'                                    		  ");
		sql.append("    AND C.HOSP_CODE					=	A.HOSP_CODE						      ");
		sql.append("    AND C.DOCTOR = CONCAT(:department , A.DOCTOR)					      	  ");
		sql.append("    AND C.GWA					      =	B.DOCTOR_GWA                          ");

		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		if(!StringUtils.isEmpty(department))
		{
			query.setParameter("department", department);
		}
		List<DoctorInfo> doctorInfos= new JpaResultMapper().list(query, DoctorInfo.class);
		return doctorInfos;
	}
	
	@Override
	public List<PatientLinkingFwkDoctorInfo> getOcs2015U00DoctorNameInfo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		 sql.append("SELECT  DOCTOR ,DOCTOR_NAME												    ");
		 sql.append("FROM BAS0270                                                                   ");
		 sql.append("WHERE HOSP_CODE = :f_hosp_code                            		                ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		List<PatientLinkingFwkDoctorInfo> listDoctorInfos= new JpaResultMapper().list(query, PatientLinkingFwkDoctorInfo.class);
		return listDoctorInfos;
	}
	
	@Override
	public List<INP1003U01fbxInp1003Info> getINP1003U01fbxInp1003Info(String hospCode, String find, String buseoYmd, String gwa, String doctorYmd, String nameControl){
		StringBuilder sql = new StringBuilder();
		if (nameControl.equals("fbxDoctor")){
			sql.append("     SELECT A.DOCTOR															");
			sql.append("          , A.DOCTOR_NAME														");
			sql.append("          , CONCAT(A.DOCTOR_GWA, A.DOCTOR)            CONT_KEY					");
			sql.append("       FROM BAS0270 A															");
			sql.append("      WHERE A.HOSP_CODE         = :f_hosp_code									");
			sql.append("        AND (CASE :f_gwa														");
			sql.append("               WHEN '%' THEN '%'												");
			sql.append("             ELSE A.DOCTOR_GWA													");
			sql.append("             END)               = :f_gwa										");
			sql.append("        AND(A.DOCTOR            LIKE CONCAT('%', :f_find, '%')					");
			sql.append("         OR A.DOCTOR_NAME       LIKE CONCAT('%', :f_find, '%'))					");
			sql.append("        AND :f_doctor_ymd       BETWEEN A.START_DATE							");
			sql.append("                                    AND A.END_DATE								");
			sql.append("      ORDER BY CONT_KEY															");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_gwa", gwa);
			query.setParameter("f_find", find);
			query.setParameter("f_doctor_ymd", doctorYmd);
			
			List<INP1003U01fbxInp1003Info> list = new JpaResultMapper().list(query, INP1003U01fbxInp1003Info.class);
			return list;
		}else if (nameControl.equals("fbxJisiDoctor")){
			sql.append("     SELECT A.DOCTOR															");
			sql.append("          , A.DOCTOR_NAME														");
			sql.append("          , CONCAT(A.DOCTOR_GWA, A.DOCTOR_NAME2, A.DOCTOR)     CONT_KEY			");
			sql.append("       FROM BAS0270 A															");
			sql.append("      WHERE A.HOSP_CODE         = :f_hosp_code									");
			sql.append("        AND (CASE :f_gwa														");
			sql.append("               WHEN '%' THEN '%'												");
			sql.append("             ELSE A.DOCTOR_GWA													");
			sql.append("             END)               = :f_gwa										");
			sql.append("        AND(A.DOCTOR            LIKE CONCAT('%', :f_find, '%')					");
			sql.append("         OR A.DOCTOR_NAME       LIKE CONCAT('%', :f_find, '%'))					");
			sql.append("        AND :f_doctor_ymd       BETWEEN A.START_DATE							");
			sql.append("                                    AND A.END_DATE								");
			sql.append("      ORDER BY CONT_KEY															");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_gwa", gwa);
			query.setParameter("f_find", find);
			query.setParameter("f_doctor_ymd", doctorYmd);
			
			List<INP1003U01fbxInp1003Info> list = new JpaResultMapper().list(query, INP1003U01fbxInp1003Info.class);
			return list;
		}else{
			sql.append("     SELECT A.GWA																");
			sql.append("          , A.GWA_NAME															");
			sql.append("          , A.BUSEO_CODE														");
			sql.append("       FROM BAS0260 A															");
			sql.append("      WHERE A.HOSP_CODE         = :f_hosp_code									");
			sql.append("        AND A.BUSEO_GUBUN       = '1'/*診療科（진료과）*/							");
			sql.append("        AND :f_buseo_ymd        BETWEEN A.START_DATE 							");
			sql.append("                                    AND A.END_DATE								");
			sql.append("        AND(A.GWA               LIKE CONCAT('%', :f_find, '%')					");
			sql.append("         OR A.GWA_NAME          LIKE CONCAT('%', :f_find, '%'))					");
			sql.append("        AND A.IPWON_YN          = 'Y'											");
			sql.append("      ORDER BY A.GWA															");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_find", find);
			query.setParameter("f_buseo_ymd", buseoYmd);
			
			List<INP1003U01fbxInp1003Info> list = new JpaResultMapper().list(query, INP1003U01fbxInp1003Info.class);
			return list;
		}
	}
	
	public String getExsitReserDateINP1003U01SaveLayout(String hospCode, String gwa, Date reserDate, String doctor){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT 'Y'																				");
		sql.append("       FROM DUAL																			");
		sql.append("      WHERE EXISTS (SELECT 'X'																");
		sql.append("                      FROM BAS0270 A														");
		sql.append("                     WHERE A.HOSP_CODE  = :f_hosp_code										");
		sql.append("                       AND A.DOCTOR     = :f_doctor											");
		sql.append("                       AND A.DOCTOR_GWA = :f_gwa											");
		sql.append("                       AND IFNULL(DATE_FORMAT(:f_reser_date, '%Y/%m/%d'), SYSDATE()) 		");
		sql.append("                                       BETWEEN A.START_DATE 								");
		sql.append("                                           AND A.END_DATE )									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("f_doctor", doctor);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public String getDoctorByDoctorGwaAndCommonDoctorYn(String hospCode, String doctorGwa, String commonYn) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DOCTOR    						");
		sql.append("   FROM BAS0270    				 		");
		sql.append("   WHERE HOSP_CODE  = :f_hosp_code      ");
		sql.append("   AND DOCTOR_GWA = :f_gwa      		");
		sql.append("   AND COMMON_DOCTOR_YN = :f_commonYn   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", doctorGwa);
		query.setParameter("f_commonYn", commonYn);
		List<String> listResult =query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	@Override
	public List<INP1003U00fwkDoctorInfo> getINP1003U00fwkDoctorInfo(String hospCode, String gwa, String find, String doctorYmd, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																														");
		sql.append("		A.DOCTOR,																												");
		sql.append("	  	A.DOCTOR_NAME,																											");
		sql.append("	  	FN_BAS_LOAD_GWA_NAME(A.DOCTOR_GWA, STR_TO_DATE(:f_doctor_ymd, '%Y/%m/%d'), :f_hosp_code, :f_language) GWA_NAME			");
		sql.append("	FROM																														");
		sql.append("		BAS0270 A																												");
		sql.append("	WHERE																														");
		sql.append("	 	A.HOSP_CODE  = :f_hosp_code																								");
		sql.append("		AND IF(:f_gwa = '%', '%', A.DOCTOR_GWA) = :f_gwa																		");
		sql.append("	  	AND (A.DOCTOR LIKE :f_find OR A.DOCTOR_NAME LIKE :f_find)																");
		sql.append("	  	AND STR_TO_DATE(:f_doctor_ymd, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE   										");
		sql.append("	ORDER BY																													");
		sql.append("		A.DOCTOR, A.DOCTOR_GWA																									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_find", "%" + find + "%");
		query.setParameter("f_doctor_ymd", doctorYmd);
		query.setParameter("f_language", language);
		
		List<INP1003U00fwkDoctorInfo> list = new JpaResultMapper().list(query, INP1003U00fwkDoctorInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> findDoctorByHospCodeSysDateDoctorGwa(String hospCode, String language, String doctorGwa, boolean isAll) {
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append("SELECT '%', FN_ADM_MSG('221',:f_language)                                                     									");
			sql.append("UNION                                                                                         									");
		}
		
		sql.append("	(SELECT A.DOCTOR, A.DOCTOR_NAME																									");
		sql.append("	FROM BAS0270 A 																													");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																								");
		if(!StringUtils.isEmpty(doctorGwa)){
			sql.append("  AND A.DOCTOR_GWA = :f_doctor_gwa																								");
		}
		sql.append("	  AND CURRENT_DATE() BETWEEN A.START_DATE AND DATE_ADD(IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d')), INTERVAL 1 MONTH)	");
		sql.append("	ORDER BY A.DOCTOR)																												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		if(!StringUtils.isEmpty(doctorGwa)){
			query.setParameter("f_doctor_gwa", doctorGwa);
		}
		
		if(isAll){
			query.setParameter("f_language", language);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getOCS2003P01IsCommonDocConsultInfo(String hospCode, String doctor, String date) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y' 												");
		sql.append("   FROM BAS0270 A 											");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code							");
		sql.append("    AND A.DOCTOR = :f_doctor 								");
		sql.append("    AND IFNULL(A.COMMON_DOCTOR_YN, 'N') = 'Y' 				");
		sql.append("    AND A.START_DATE = ( SELECT MAX(X.START_DATE) 			");
		sql.append("                           FROM BAS0270 X 					");
		sql.append("                          WHERE X.HOSP_CODE = A.HOSP_CODE 	");
		sql.append("                            AND X.DOCTOR = A.DOCTOR 		");
		sql.append("                            AND X.START_DATE <= :f_date )	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_date", DateUtil.toDate(date, DateUtil.PATTERN_YYMMDD));
		List<String> listResult =query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> findByHospCodeDoctorGwaFDate(String hospCode, String doctorGwa, String ipwonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.DOCTOR, A.DOCTOR_NAME													");
		sql.append("	FROM BAS0270  A 																");
		sql.append("	WHERE A.HOSP_CODE  = :f_hosp_code 												");
		sql.append("	AND A.DOCTOR_GWA = :f_doctor_gwa 												");
		sql.append("	AND STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor_gwa", doctorGwa);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getNUR2004U00fbxToDoctor(String hospCode, String date, String gwa, String find1) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																										");
		sql.append("		DISTINCT A.DOCTOR         	doctor,																		");
		sql.append("	    A.DOCTOR_NAME    			doctor_name																	");
		sql.append("	FROM																										");
		sql.append("		BAS0270 A																								");
		sql.append("	WHERE																										");
		sql.append("		A.HOSP_CODE  							= :f_hosp_code													");
		sql.append("	   AND A.DOCTOR_GWA 						LIKE :f_gwa														");
		sql.append("	   AND STR_TO_DATE(:f_date, '%Y/%m/%d') 	BETWEEN A.START_DATE AND A.END_DATE								");
		sql.append("	   AND A.DOCTOR     						LIKE :f_find1													");
		sql.append("	 ORDER BY A.DOCTOR																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		query.setParameter("f_gwa", gwa + "%");
		query.setParameter("f_find1", find1 + "%");
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<DataStringListItemInfo> getNUR2004U00layValidCheckDoctor(String hospCode, String gwa, String code, String date) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																					");
		sql.append("		DOCTOR_NAME																			");
		sql.append("	FROM																					");
		sql.append("		BAS0270 																			");
		sql.append("	WHERE																					");
		sql.append("		HOSP_CODE 								= :f_hosp_code								");
		sql.append("		AND DOCTOR_GWA 							= :f_gwa									");
		sql.append("		AND DOCTOR 								= :f_code									");
		sql.append("		AND STR_TO_DATE(:f_date, '%Y/%m/%d') 	BETWEEN START_DATE AND END_DATE				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_code", code);
		query.setParameter("f_date", date);
		
		List<DataStringListItemInfo> listInfo = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return listInfo;
	}
	
}

