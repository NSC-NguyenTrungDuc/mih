package nta.med.data.dao.medi.sch.impl;

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

import nta.med.core.domain.sch.Sch0201;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.impl.Adm0100RepositoryImpl;
import nta.med.data.dao.medi.sch.Sch0201RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.NuroCheckBookingInfo;
import nta.med.data.model.ihis.nuro.NuroInspectionOrderInfo;
import nta.med.data.model.ihis.schs.SCH0201Q05LayReserListInfo;
import nta.med.data.model.ihis.schs.SCH0201Q12GrdListItemInfo;
import nta.med.data.model.ihis.schs.SCH0201U10GrdOrderItemInfo;
import nta.med.data.model.ihis.schs.SCH0201U10LayReserInfo;
import nta.med.data.model.ihis.schs.SCH0201U99BookingInfo;
import nta.med.data.model.ihis.schs.SCH0201U99ClinicInfo;
import nta.med.data.model.ihis.schs.SCH0201U99ClinicLinkInfo;
import nta.med.data.model.ihis.schs.SCH0201U99PatientInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q01ReserListItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q02ReserList02ItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q02ReserList03ItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04GetMonthReserListInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04PrartListItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04ReserTimeListInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99DateScheduleItemInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99GrdOrderListInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99GrdTimeListInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201U99LayoutTimeListInfo;

/**
 * @author dainguyen.
 */
public class Sch0201RepositoryImpl implements Sch0201RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Adm0100RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NuroCheckBookingInfo> getNuroCheckBookingInfo(String hospitalCode, String patientCode, String reserDate) {
		StringBuilder sql = new StringBuilder();
		/* Check reservation */
		sql.append("SELECT DISTINCT                                                                ");
		sql.append("       A.BUNHO                                                                 ");
		sql.append("     , A.RESER_DATE   RESER_DATE                                               ");
		sql.append("  FROM SCH0201 A                                                               ");
		sql.append(" WHERE A.HOSP_CODE           = :hospitalCode                                   ");
		sql.append("   AND A.BUNHO               = :patientCode                                    ");
		sql.append("   AND IFNULL(A.CANCEL_YN,'N')  = 'N'                                          ");
		sql.append("   AND IFNULL(A.RESER_YN ,'N')  = 'Y'                                          ");
		if(!StringUtils.isEmpty(reserDate)) {
			sql.append("   AND A.RESER_DATE          = STR_TO_DATE(:reserDate, '%Y/%m/%d')          ");
		}
		sql.append("   AND A.RESER_DATE         >= DATE_FORMAT(SYSDATE(), '%Y-%m-%d')              ");
		sql.append("   AND A.ACTING_DATE IS NULL                                                   ");
		sql.append(" UNION                                                                         ");
		/* Appointment */
		sql.append("SELECT DISTINCT                                                                ");
		sql.append("       A.BUNHO                                                                 ");
		sql.append("     , A.NAEWON_DATE  RESER_DATE                                               ");
		sql.append("      FROM OUT1001 A                                                           ");
		sql.append(" WHERE A.HOSP_CODE      = :hospitalCode                                        ");
		sql.append("   AND A.BUNHO          = :patientCode                                         ");
		sql.append("   AND IFNULL(A.RESER_YN ,'N')  = 'Y'                                          ");
		if(!StringUtils.isEmpty(reserDate)) {
			sql.append("   AND A.NAEWON_DATE          = STR_TO_DATE(:reserDate, '%Y/%m/%d')        ");
		}
		sql.append("   AND A.NAEWON_DATE   >= DATE_FORMAT(SYSDATE(), '%Y-%m-%d')                   ");
		sql.append("   AND IFNULL(A.NAEWON_YN, 'N')  = 'N'                                         ");
		/* Injection reservation*/
		sql.append(" UNION                                                                         ");
		sql.append("SELECT DISTINCT                                                                ");
		sql.append("       A.BUNHO                                                                 ");
		sql.append("     , B.RESER_DATE   RESER_DATE                                               ");
		sql.append("  FROM INJ1001 A                                                               ");
		sql.append("     , INJ1002 B                                                               ");
		sql.append(" WHERE A.HOSP_CODE      = :hospitalCode                                        ");
		sql.append("   AND B.HOSP_CODE      = A.HOSP_CODE                                          ");
		sql.append("   AND A.BUNHO          = :patientCode                                         ");
		sql.append("   AND A.PKINJ1001      = B.FKINJ1001                                          ");
		if(!StringUtils.isEmpty(reserDate)) {
			sql.append("   AND B.RESER_DATE          = STR_TO_DATE(:reserDate, '%Y/%m/%d')         ");
		}
		sql.append("   AND B.RESER_DATE    >= DATE_FORMAT(SYSDATE(), '%Y-%m-%d')                   ");
		sql.append("   AND B.ACTING_DATE IS NULL                                                   ");
		sql.append("   AND IFNULL(B.DC_YN,'N') = 'N'                                               ");
		sql.append(" ORDER BY 2                                                                    ");
		                
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("patientCode", patientCode);
		if(!StringUtils.isEmpty(reserDate)) {
			query.setParameter("reserDate", reserDate);
		}
		
		List<NuroCheckBookingInfo > list = new JpaResultMapper().list(query, NuroCheckBookingInfo.class);
		return list;
	}
	
	@Override
	public List<NuroInspectionOrderInfo> getNuroInspectionOrderInfo(String hospitalCode, String language, String patientCode, String reserDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                                                     ");
		sql.append("       ''                                                                          GWA                                                                              ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.RESER_DATE, :hospitalCode, :language)     GWA_NAME                                                                             ");
		sql.append("     ,  A.BUNHO                                                                    BUNHO                                                                            ");
		sql.append("     , IFNULL(A.SUNAME,C.SUNAME)                                                   SUNAME                                                                           ");
		sql.append("     , A.RESER_DATE                                                                RESER_DATE                                                                       ");
		sql.append("     , IF(A.JUNDAL_TABLE ='CPL',B.JUNDAL_PART_NAME, D.HANGMOG_NAME)                HANGMOG_NAME                                                                     ");
		sql.append("     , A.RESER_TIME                                                                RESER_TIME                                                                       ");
		sql.append("     , FN_BAS_LOAD_GWA_POSITION(D.MOVE_PART,SYSDATE(), :hospitalCode, :language)              MOVE_NAME                                                             ");
		sql.append("     , DATE_FORMAT(A.RESER_DATE,'%w') + 1                                             RESER_DAY                                                                     ");
		sql.append("     , FN_BAS_LOAD_AGE(DATE_FORMAT(SYSDATE(), '%Y-%m-%d'), C.BIRTH, '')            AGE                                                                              ");
		sql.append("     , DATE_FORMAT(C.BIRTH,'%Y/%m/%d')                                             BIRTH                                                                            ");
		sql.append("     , C.SUNAME2                                                                   SUNAME2                                                                          ");
		sql.append("     , IF(D.SLIP_CODE = 'E15', 'ECHO', A.JUNDAL_PART)                              JUNDAL_PART /* E15(Echocardiography)	 */                                         ");
		sql.append("     , NULL                                                                        RESER_MOVE_NAME                                                                  ");
		sql.append("     , IF(A.JUNDAL_PART = 'CPL' OR A.JUNDAL_PART = 'CPR' OR A.JUNDAL_PART = 'CPH',A.JUNDAL_PART, A.HANGMOG_CODE )   HANGMOG_CODE                                    ");
		sql.append("     , A.JUNDAL_TABLE                                                              JUNDAL_TABLE                                                                     ");
		sql.append("     , A.HOPE_DATE                                                                 HOPE_DATE                                                                        ");
		sql.append("     , IF(A.JUNDAL_PART = 'CPL' OR A.JUNDAL_PART = 'CPR' OR A.JUNDAL_PART = 'CPH',FN_SCH_LOAD_SEQ(A.BUNHO,A.RESER_DATE,A.JUNDAL_PART, :hospitalCode), A.SEQ) SEQ    ");
		sql.append("     , '0'                                                                         SORT                                                                             ");
		sql.append("     , IFNULL(A.RESER_TIME, '0000')                                                   SORT_TIME                                                                     ");
		sql.append("  FROM SCH0001 B LEFT OUTER JOIN SCH0201 A ON B.HOSP_CODE = A.HOSP_CODE                                                                                             ");
		sql.append("                                             AND B.JUNDAL_TABLE = A.JUNDAL_TABLE                                                                                    ");
		sql.append("                                             AND B.JUNDAL_PART = A.JUNDAL_PART                                                                                      ");
		sql.append("      ,OCS0103 D                                                                                                                                                    ");
		sql.append("      , OUT0101 C                                                                                                                                                   ");
		sql.append(" WHERE A.HOSP_CODE      = :hospitalCode                                                                                                                             ");
		sql.append("   AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                               ");
		sql.append("   AND D.HOSP_CODE      = A.HOSP_CODE                                                                                                                               ");
		sql.append("   AND A.BUNHO          = :patientCode                                                                                                                              ");
		sql.append("   AND A.RESER_DATE     = STR_TO_DATE(:reserDate,'%Y/%m/%d ')                                                                                                       ");
		sql.append("   AND A.RESER_YN       = 'Y'                                                                                                                                       ");
		sql.append("   AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                                                                ");
		sql.append("   AND ((A.JUNDAL_TABLE = 'XRT' AND A.JUNDAL_PART  LIKE 'RI%') OR                                                                                                   ");
		sql.append("        (A.JUNDAL_PART  NOT LIKE 'RI%' AND A.PART_PKKEY IS NULL))                                                                                                   ");
		sql.append("   AND C.BUNHO          = A.BUNHO                                                                                                                                   ");
		sql.append("   AND D.HANGMOG_CODE   = A.HANGMOG_CODE                                                                                                                            ");
		sql.append("   AND A.ACTING_DATE IS NULL                                                                                                                                        ");
		sql.append(" UNION ALL                                                                                                                                                          ");
		sql.append("SELECT DISTINCT                                                                                                                                                     ");
		sql.append("       A.GWA                                                       GWA                                                                                              ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :hospitalCode, :language)                  GWA_NAME                                                               ");
		sql.append("     , A.BUNHO                                                     BUNHO                                                                                            ");
		sql.append("     , B.SUNAME                                                    SUNAME                                                                                           ");
		sql.append("     , A.NAEWON_DATE                                               RESER_DATE                                                                                       ");
		sql.append("     ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, DATE_FORMAT(A.NAEWON_DATE, '%Y-%m-%d'), :hospitalCode)  HANGMOG_NAME                                                        ");
		sql.append("     , A.JUBSU_TIME                                                          RESER_TIME /* Do not show examination reservation time in Kujukuri hospital	*/  	");
		sql.append("     , FN_BAS_LOAD_GWA_POSITION(A.GWA, SYSDATE(), :hospitalCode, :language)   MOVE_NAME                                                                             ");
		sql.append("     , DATE_FORMAT(A.NAEWON_DATE,'%w') + 1                         RESER_DAY                                                                                        ");
		sql.append("     , FN_BAS_LOAD_AGE(DATE_FORMAT(SYSDATE(), '%Y-%m-%d'), B.BIRTH, '')  AGE                                                                                        ");
		sql.append("     , DATE_FORMAT(B.BIRTH,'%Y/%m/%d')              		   BIRTH                                                                                                ");
		sql.append("     , B.SUNAME2                                                   SUNAME2                                                                                          ");
		sql.append("     , ''                                                          JUNDAL_PART                                                                                      ");
		sql.append("     , NULL                                                                        RESER_MOVE_NAME                                                                  ");
		sql.append("     , A.GWA                                                       HANGMOG_CODE                                                                                     ");
		sql.append("     , ''                                                          JUNDAL_TABLE                                                                                     ");
		sql.append("     , NULL                                                        HOPE_DATE                                                                                        ");
		sql.append("     , IFNULL(A.JUBSU_NO,99)                                          SEQ                                                                                           ");
		sql.append("     , '0'                                                         SORT                                                                                             ");
		sql.append("     , IFNULL(A.JUBSU_TIME, '0000')                                   SORT_TIME                                                                                     ");
		sql.append("  FROM OUT0101 B,                                                                                                                                                   ");
		sql.append("       OUT1001 A                                                                                                                                                    ");
		sql.append(" WHERE A.HOSP_CODE        = :hospitalCode                                                                                                                           ");
		sql.append("   AND B.HOSP_CODE        = A.HOSP_CODE                                                                                                                             ");
		sql.append("   AND A.BUNHO            = :patientCode                                                                                                                            ");
		sql.append("   AND A.NAEWON_DATE      = STR_TO_DATE(:reserDate,'%Y/%m/%d ')                                                                                                     ");
		sql.append("   AND IFNULL(RESER_YN, 'N') = 'Y'                                                                                                                                  ");
		sql.append("   AND B.BUNHO            = A.BUNHO                                                                                                                                 ");
		sql.append("   AND IFNULL(A.NAEWON_YN, 'N') = 'N'                                                                                                                               ");
		sql.append(" UNION ALL                                                                                                                                                          ");
		sql.append("SELECT DISTINCT                                                                                                                                                     ");
		sql.append("       ''                                                          GWA                                                                                              ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME(A.GWA, B.RESER_DATE, :hospitalCode, :language)       GWA_NAME                                                                           ");
		sql.append("     , A.BUNHO                                                     BUNHO                                                                                            ");
		sql.append("     , C.SUNAME                                                    SUNAME                                                                                           ");
		sql.append("     , B.RESER_DATE                                                RESER_DATE                                                                                       ");
		sql.append("     , CONCAT(FN_ADM_MSG(4108, :language),'  ', FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, DATE_FORMAT(B.RESER_DATE, '%Y-%m-%d'), :hospitalCode))       HANGMOG_NAME         ");
		sql.append("     , B.RESER_TIME                                                RESER_TIME                                                                                       ");
		sql.append("     , FN_BAS_LOAD_GWA_POSITION(A.JUNDAL_PART, SYSDATE(), :hospitalCode, :language)   MOVE_NAME                                                                     ");
		sql.append("     , DATE_FORMAT(B.RESER_DATE,'%w') + 1                          RESER_DAY                                                                                        ");
		sql.append("     , FN_BAS_LOAD_AGE(DATE_FORMAT(SYSDATE(), '%Y-%m-%d'), C.BIRTH, '')               AGE                                                                           ");
		sql.append("     , DATE_FORMAT(C.BIRTH,'%Y/%m/%d')                             BIRTH                                                                                            ");
		sql.append("     , C.SUNAME2                                                   SUNAME2                                                                                          ");
		sql.append("     , ''                                                          JUNDAL_PART                                                                                      ");
		sql.append("     , NULL                                                                        RESER_MOVE_NAME                                                                  ");
		sql.append("     , 'INJ'                                                       HANGMOG_CODE                                                                                     ");
		sql.append("     , ''                                                          JUNDAL_TABLE                                                                                     ");
		sql.append("     , NULL                                                        HOPE_DATE                                                                                        ");
		sql.append("     , 0                                                           SEQ                                                                                              ");
		sql.append("     , '0'                                                         SORT                                                                                             ");
		sql.append("     , IFNULL(B.RESER_TIME, '0000')                                   SORT_TIME                                                                                     ");
		sql.append("  FROM OUT0101 C                                                                                                                                                    ");
		sql.append("     , INJ1001 A                                                                                                                                                    ");
		sql.append("     , INJ1002 B                                                                                                                                                    ");
		sql.append(" WHERE A.HOSP_CODE      = :hospitalCode                                                                                                                             ");
		sql.append("   AND B.HOSP_CODE      = A.HOSP_CODE                                                                                                                               ");
		sql.append("   AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                               ");
		sql.append("   AND A.BUNHO          = :patientCode                                                                                                                              ");
		sql.append("   AND A.PKINJ1001      = B.FKINJ1001                                                                                                                               ");
		sql.append("   AND B.RESER_DATE     = STR_TO_DATE(:reserDate,'%Y/%m/%d ')                                                                                                       ");
		sql.append("   AND A.BUNHO          = C.BUNHO                                                                                                                                   ");
		sql.append("   AND IFNULL(A.DC_YN,'N') = 'N'                                                                                                                                    ");
		sql.append("   AND B.ACTING_DATE IS NULL                                                                                                                                        ");
		sql.append(" UNION ALL                                                                                                                                                          ");
		sql.append("SELECT NULL                                                        GWA                                                                                              ");
		sql.append("     , NULL                                                        GWA_NAME                                                                                         ");
		sql.append("     , NULL                                                        BUNHO                                                                                            ");
		sql.append("     , NULL                                                        SUNAME                                                                                           ");
		sql.append("     , NULL                                                        RESER_DATE                                                                                       ");
		sql.append("     , A.MOVE_COMMENT                                              HANGMOG_NAME                                                                                     ");
		sql.append("     , NULL                                                        RESER_TIME                                                                                       ");
		sql.append("     , ''                                                          MOVE_NAME                                                                                        ");
		sql.append("     , NULL                                                        RESER_DAY                                                                                        ");
		sql.append("     , NULL                                                        AGE                                                                                              ");
		sql.append("     , NULL                                                        BIRTH                                                                                            ");
		sql.append("     , NULL                                                        SUNAME2                                                                                          ");
		sql.append("     , NULL                                                        JUNDAL_PART                                                                                      ");
		sql.append("     , NULL                                                                        RESER_MOVE_NAME                                                                  ");
		sql.append("     , NULL                                                        HANGMOG_CODE                                                                                     ");
		sql.append("     , NULL                                                        JUNDAL_TABLE                                                                                     ");
		sql.append("     , NULL                                                        HOPE_DATE                                                                                        ");
		sql.append("     , NULL                                                        SEQ                                                                                              ");
		sql.append("     , 'Z'                                                         SORT                                                                                             ");
		sql.append("     , '9999'                                                      SORT_TIME                                                                                        ");
		sql.append("  FROM BAS0260 A                                                                                                                                                    ");
		sql.append(" WHERE A.HOSP_CODE      = :hospitalCode  AND A.LANGUAGE = :language                                                                                                 ");
		sql.append("   AND A.BUSEO_CODE = '51190' /* Accounting window      */                                                                                                          ");
		sql.append(" ORDER BY 19 /* SORT   */                                                                                                                                           ");
		sql.append("        , 20  /* SORT_TIME     */                                                                                                                                   ");
		sql.append("        , 13 /* JUNDAL_PART    */                                                                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		query.setParameter("patientCode", patientCode);
		query.setParameter("reserDate", reserDate);
		
		List<NuroInspectionOrderInfo > list = new JpaResultMapper().list(query, NuroInspectionOrderInfo.class);
		return list;
	}



	@Override
	public List<ComboListItemInfo> getSchsSCH0201Q01SCH0109ComboList(
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT '%', FN_ADM_MSG(221,:language)		");
		sql.append("	 UNION                                      ");
		sql.append("	(SELECT CODE                                ");
		sql.append("	     , CODE_NAME                            ");
		sql.append("	  FROM SCH0109                              ");
		sql.append("	 WHERE HOSP_CODE = :hospCode                ");
		sql.append("	   AND CODE_TYPE = 'GROUP'                  ");
		sql.append("	   AND LANGUAGE = :language                 ");
		sql.append("	 ORDER BY CODE_NAME2)                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getSchsSCH0201Q01SCH0001ComboList(
			String hospCode, String jundalTable, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT '%', FN_ADM_MSG(221, :language)						   ");
		sql.append("	 UNION                                                         " );
		sql.append("	SELECT A.JUNDAL_PART                    JUNDAL_PART            " );
		sql.append("	     , A.JUNDAL_PART_NAME               JUNDAL_PART_NAME       " );
		sql.append("	 FROM SCH0001 A                                                " );
		sql.append("	WHERE A.HOSP_CODE    = :hospCode                           	   " );
		sql.append("	  AND A.JUNDAL_TABLE = :jundalTable                            " );
		sql.append("	ORDER BY 1                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalTable", jundalTable);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getSchsSCH0201Q01ExitsJundalTable(String hospCode,
			String hangmogCode, String jundalTable) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'							     ");
		sql.append("	 FROM SCH0002                            ");
		sql.append("	WHERE HOSP_CODE = :hospCode              ");
		sql.append("	  AND HANGMOG_CODE = :hangmogCode        ");
		sql.append("	  AND JUNDAL_TABLE  = :jundalTable       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("jundalTable", jundalTable);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	public List<SchsSCH0201Q01ReserListItemInfo> getSchsSCH0201Q01ReserListItemInfo(
			String hospCode, String fromDate, String toDate,
			String jundalTable, String jundalPart, boolean chkchecked) {
		StringBuilder sql = new StringBuilder();
		
		sql.append ("	SELECT DISTINCT																																								");
		sql.append ("	                                                                                                                                                                            ");
		sql.append ("	       IF(A.JUNDAL_TABLE = 'CPL', '', A.PKSCH0201) PKSCH0201,                                                                                                               ");
		sql.append ("	       A.IN_OUT_GUBUN IN_OUT_GUBUN,                                                                                                                                         ");
		sql.append ("	       IF(A.JUNDAL_TABLE = 'CPL', '', A.FKOCS) FKOCS,                                                                                                                       ");
		sql.append ("	       A.BUNHO BUNHO,                                                                                                                                                       ");
		sql.append ("	       A.GWA GWA,                                                                                                                                                           ");
		sql.append ("	       A.GUMSAJA GUMSAJA,                                                                                                                                                   ");
		sql.append ("	       IF(A.JUNDAL_TABLE = 'CPL', '', A.HANGMOG_CODE) HANGMOG_CODE,                                                                                                         ");
		sql.append ("	       A.JUNDAL_TABLE JUNDAL_TABLE,                                                                                                                                         ");
		sql.append ("	       A.JUNDAL_PART JUNDAL_PART,                                                                                                                                           ");
		sql.append ("	       DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d') RESER_DATE,                                                                                                                    ");
		sql.append ("	       A.RESER_TIME RESER_TIME,                                                                                                                                             ");
		sql.append ("	       DATE_FORMAT(A.INPUT_DATE, '%Y/%m/%d') INPUT_DATE,                                                                                                                    ");
		sql.append ("	       A.INPUT_ID INPUT_ID,                                                                                                                                                 ");
		sql.append ("	       CONCAT(IF(A.FKOCS = NULL, FN_SCH_LOAD_CODE_NAME('K01','SOGAE_TEXT', '01'), ''),B.SUNAME,' [', B.SUNAME2,']') SUNAME,                                                 ");
		sql.append ("	       A.RESER_YN RESER_YN,                                                                                                                                                 ");
		sql.append ("	       A.CANCEL_YN CANCEL_YN,                                                                                                                                               ");
		sql.append ("	       DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d') ACTING_DATE,                                                                                                                  ");
		sql.append ("	       DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d') HOPE_DATE,                                                                                                                      ");
		sql.append ("	       A.COMMENTS COMMENTS,                                                                                                                                                 ");
		sql.append ("	       CONCAT(                                                                                                                                                              ");
		sql.append ("	          IF(A.JUNDAL_TABLE,'CPL',CONCAT('検体検査', '[',A.Order_Date,':GR-',FN_SCH_OCS_GROUP_SER(A.HOSP_CODE, A.FKOCS),']',C.HANGMOG_NAME)),                                 ");
		sql.append ("	          IF(IFNULL(A.JUSA_RESER_YN, 'N') = 'Y', CONCAT('(', FN_ADM_MSG(4108, 'JA'), ')'),''))      HANGMOG_NAME                                                            ");
		sql.append ("	        ,IFNULL(D.JUNDAL_PART_NAME, FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.RESER_DATE, :hospCode, 'JA'))   JUNDAL_PART_NAME                                               ");
		sql.append ("	        ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.INPUT_DATE, :hospCode, 'JA')                               GWA_NAME                                                               ");
		sql.append ("	        ,HO_DONG1                                                                HO_DONG1                                                                                   ");
		sql.append ("	        ,B.SEX                                                                   SEX                                                                                        ");
		sql.append ("	        ,FN_BAS_LOAD_AGE(DATE_FORMAT(SYSDATE(), '%Y-%m-%d'), B.BIRTH, NULL)                          AGE                                                                    ");
		sql.append ("	        ,B.BIRTH                                                          BIRTH                                                                                      ");
		sql.append ("	        ,CASE A.IN_OUT_GUBUN WHEN 'I' THEN CONCAT(FN_BAS_LOAD_GWA_NAME(E.HO_DONG1, DATE_FORMAT(SYSDATE(),'%Y-%m-%d'), :hospCode, 'JA'), '-' , E.HO_CODE1)                ");
		sql.append ("	                             WHEN 'O' THEN FN_BAS_LOAD_GWA_NAME(A.GWA, DATE_FORMAT(SYSDATE(), '%Y-%m-%d'), :hospCode, 'JA') END  INPUT_GWA                               ");
		sql.append ("	        ,FN_SCH_LOAD_DOCTOR_NAME(:hospCode,A.IN_OUT_GUBUN, A.FKOCS)                        DOCTOR_NAME                                                                   ");
		sql.append ("	        ,FN_ADM_LOAD_USER_NAME(A.UPD_ID,:hospCode)                                         UPD_NAME                                                                      ");
		sql.append ("	        ,IF((SELECT Z.PORTABLE_YN                                                                                                                                           ");
		sql.append ("	                   FROM OCS2003 Z                                                                                                                                           ");
		sql.append ("	                  WHERE Z.HOSP_CODE = 'K01'                                                                                                                                 ");
		sql.append ("	                    AND Z.PKOCS2003 = A.FKOCS)= 'Y', 'O', '')                   PORTABLE_YN                                                                                 ");
		sql.append ("	                                                                                                                                                                            ");
		sql.append ("	   FROM SCH0201 A LEFT JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                                                                    ");
		sql.append ("	  LEFT JOIN SCH0001 D ON D.HOSP_CODE = A.HOSP_CODE AND D.JUNDAL_PART = A.JUNDAL_PART                                                                                        ");
		sql.append ("	  LEFT JOIN INP1001 E ON E.HOSP_CODE = A.HOSP_CODE AND E.BUNHO = A.BUNHO AND E.TOIWON_DATE IS NULL                                                                          ");
		sql.append ("	  JOIN OCS0103 C ON  C.HOSP_CODE     = A.HOSP_CODE AND C.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                     ");
		sql.append ("	                                                                                                                                                                            ");
		sql.append ("	  WHERE A.HOSP_CODE     = :hospCode                                                                                                                                      ");
		if(!StringUtils.isEmpty(fromDate) &&!StringUtils.isEmpty(toDate)) {
		sql.append ("	    AND A.RESER_DATE    BETWEEN STR_TO_DATE(:fromDate,'%Y/%m/%d') AND STR_TO_DATE(:toDate,'%Y/%m/%d')                                                                 ");
		}
		sql.append ("	    AND A.JUNDAL_TABLE  LIKE CONCAT('%' ,:jundalTable,'%')                                                                                                               ");
		sql.append ("	    AND (A.JUNDAL_PART   LIKE CONCAT('%' ,:jundalPart,'%') OR A.JUNDAL_TABLE  LIKE CONCAT( '%' ,:jundalPart,'%'))                                                     ");
		sql.append ("	    AND A.RESER_YN      = 'Y'                                                                                                                                               ");
		sql.append ("	    AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                                                                       ");
		sql.append ("	 UNION ALL                                                                                                                                                                  ");
		sql.append ("	  SELECT DISTINCT                                                                                                                                                           ");
		sql.append ("	         IF(A.JUNDAL_TABLE = 'CPL', '', A.PKSCH0201)                          PKSCH0201                                                                                     ");
		sql.append ("	        ,A.IN_OUT_GUBUN                                                          IN_OUT_GUBUN                                                                               ");
		sql.append ("	        ,IF(A.JUNDAL_TABLE ='CPL', '', A.FKOCS)                              FKOCS                                                                                          ");
		sql.append ("	        ,A.BUNHO                                                                 BUNHO                                                                                      ");
		sql.append ("	        ,A.GWA                                                                   GWA                                                                                        ");
		sql.append ("	        ,A.GUMSAJA                                                               GUMSAJA                                                                                    ");
		sql.append ("	        ,IF(A.JUNDAL_TABLE ='CPL', '', A.HANGMOG_CODE)                       HANGMOG_CODE                                                                                   ");
		sql.append ("	        ,A.JUNDAL_TABLE                                                          JUNDAL_TABLE                                                                               ");
		sql.append ("	        ,A.JUNDAL_PART                                                           JUNDAL_PART                                                                                ");
		sql.append ("	        ,STR_TO_DATE(A.RESER_DATE, '%Y/%m/%d')                                     RESER_DATE                                                                               ");
		sql.append ("	        ,A.RESER_TIME                                                            RESER_TIME                                                                                 ");
		sql.append ("	        ,STR_TO_DATE(A.INPUT_DATE, '%Y/%m/%d')                                     INPUT_DATE                                                                               ");
		sql.append ("	        ,A.INPUT_ID                                                              INPUT_ID                                                                                   ");
		sql.append ("	        ,CONCAT(IF(A.FKOCS = NULL, FN_SCH_LOAD_CODE_NAME('SOGAE_TEXT', '01'), ''), B.SUNAME , ' [' ,  B.SUNAME2 , ']')      SUNAME                                          ");
		sql.append ("	        ,A.RESER_YN                                                              RESER_YN                                                                                   ");
		sql.append ("	        ,A.CANCEL_YN                                                             CANCEL_YN                                                                                  ");
		sql.append ("	        ,STR_TO_DATE(A.ACTING_DATE, '%Y/%m/%d')                                    ACTING_DATE                                                                              ");
		sql.append ("	        ,STR_TO_DATE(A.HOPE_DATE, '%Y/%m/%d')                                      HOPE_DATE                                                                                ");
		sql.append ("	        ,A.COMMENTS                                                              COMMENTS                                                                                   ");
		sql.append ("	        ,IF( A.JUNDAL_TABLE = 'CPL' , D.JUNDAL_PART_NAME                                                                                                                    ");
		sql.append ("	         ,CONCAT(C.HANGMOG_NAME ,IF(IFNULL(A.JUSA_RESER_YN,'N') = 'Y',CONCAT('(',FN_ADM_MSG(4108,'JA'),')'),'')))     HANGMOG_NAME                                          ");
		sql.append ("	        ,IFNULL(D.JUNDAL_PART_NAME, FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.RESER_DATE, :hospCode, 'JA'))   JUNDAL_PART_NAME                                               ");
		sql.append ("	        ,''                                                                      GWA_NAME                                                                                   ");
		sql.append ("	        ,''                                                                      HO_DONG1                                                                                   ");
		sql.append ("	        ,B.SEX                                                                   SEX                                                                                        ");
		sql.append ("	        ,FN_BAS_LOAD_AGE(DATE_FORMAT(SYSDATE(), '%Y-%m-%d'), B.BIRTH, NULL)                          AGE                                                                    ");
		sql.append ("	        ,B.BIRTH                                               BIRTH                                                                                      ");
		sql.append ("	        ,''                                                                      INPUT_GWA                                                                                  ");
		sql.append ("	        ,''                                                                      DOCTOR_NAME                                                                                ");
		sql.append ("	        ,FN_ADM_LOAD_USER_NAME(A.UPD_ID)                                         UPD_NAME                                                                                   ");
		sql.append ("	        ,''                                                                      PORTABLE_YN                                                                                ");
		sql.append ("	                                                                                                                                                                            ");
		sql.append ("	   FROM SCH0201 A LEFT JOIN OUT0101 B ON B.HOSP_CODE  = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                                                                   ");
		sql.append ("	  LEFT JOIN SCH0001 D ON D.HOSP_CODE  = A.HOSP_CODE AND D.JUNDAL_PART = A.JUNDAL_PART                                                                                       ");
		sql.append ("	  JOIN  OCS0103 C ON  C.HOSP_CODE     = A.HOSP_CODE  AND C.HANGMOG_CODE       = A.HANGMOG_CODE                                                                              ");
		sql.append ("	                                                                                                                                                                            ");
		sql.append ("	  WHERE A.HOSP_CODE     = :hospCode                                                                                                                                      ");
		if(!StringUtils.isEmpty(fromDate) &&!StringUtils.isEmpty(toDate)) {
			sql.append ("	    AND A.RESER_DATE         BETWEEN STR_TO_DATE(:fromDate,'%Y/%m/%d') AND STR_TO_DATE(:toDate,'%Y/%m/%d')                                                            ");
		}
		sql.append ("	    AND A.JUNDAL_TABLE  LIKE CONCAT('%' , :jundalTable,'%')                                                                                                              ");
		sql.append ("	    AND (A.JUNDAL_PART   LIKE CONCAT('%' ,:jundalPart,'%' OR A.JUNDAL_TABLE  LIKE '%' ,:jundalPart,'%'))                                                              ");
		sql.append ("	    AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                                                                       ");
		sql.append ("	    AND A.IN_OUT_GUBUN       = 'X'																																			");

		if(chkchecked){
			sql.append("	   ORDER BY 4 , 10 , 11;                                                                               ");
		}else {
			sql.append("	  ORDER BY 9 /*JUNDAL_PART*/ , 10 /*RESER_DATE*/ , 11 /*RESER_TIME*/ , 4 /*BUNHO*/ ;          ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("fromDate", fromDate);
		query.setParameter("toDate", toDate);
		query.setParameter("jundalTable", jundalTable);
		query.setParameter("jundalPart", jundalPart);
		
		
		List<SchsSCH0201Q01ReserListItemInfo> list = new JpaResultMapper().list(query, SchsSCH0201Q01ReserListItemInfo.class);
		return list;
	}

	@Override
	public List<SchsSCH0201Q02ReserList02ItemInfo> getSchsSCH0201Q02ReserList02ItemInfo(
			String hospCode, String fromDate, String toDate, String gwa) {
		StringBuilder sql = new StringBuilder();
		
		 sql.append("	 SELECT  A.PKSCH0201                                         PKSCH0201																	");
		 sql.append("	        ,A.IN_OUT_GUBUN                                      IN_OUT_GUBUN                                                              " );
		 sql.append("	        ,A.FKOCS                                             FKOCS                                                                     " );
		 sql.append("	        ,A.BUNHO                                             BUNHO                                                                     " );
		 sql.append("	        ,A.GWA                                               GWA                                                                       " );
		 sql.append("	        ,A.GUMSAJA                                           GUMSAJA                                                                   " );
		 sql.append("	        ,A.HANGMOG_CODE                                      HANGMOG_CODE                                                              " );
		 sql.append("	        ,A.JUNDAL_TABLE                                      JUNDAL_TABLE                                                              " );
		 sql.append("	        ,A.JUNDAL_PART                                       JUNDAL_PART                                                               " );
		 sql.append("	        ,DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d')                 RESER_DATE                                                              " );
		 sql.append("	        ,A.RESER_TIME                                        RESER_TIME                                                                " );
		 sql.append("	        ,DATE_FORMAT(A.INPUT_DATE, '%Y/%m/%d')                 INPUT_DATE                                                              " );
		 sql.append("	        ,A.INPUT_ID                                          INPUT_ID                                                                  " );
		 sql.append("	        ,CONCAT(IF(A.FKOCS = NULL, FN_SCH_LOAD_CODE_NAME(:hospCode,'SOGAE_TEXT', '01'), '') , IFNULL(A.SUNAME,B.SUNAME)) SUNAME        " );
		 sql.append("	        ,A.RESER_YN                                          RESER_YN                                                                  " );
		 sql.append("	        ,A.CANCEL_YN                                         CANCEL_YN                                                                 " );
		 sql.append("	        ,DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d')                ACTING_DATE                                                             " );
		 sql.append("	        ,DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d')                  HOPE_DATE                                                               " );
		 sql.append("	        ,A.COMMENTS                                          COMMENTS                                                                  " );
		 sql.append("	        ,CONCAT(C.HANGMOG_NAME ,                                                                                                       " );
		 sql.append("	         IF(IFNULL(A.JUSA_RESER_YN,'N')='Y',CONCAT('(',FN_ADM_MSG(4108,'JA'),')'),'')) HANGMOG_NAME                                    " );
		 sql.append("	        ,FN_BAS_LOAD_GWA_NAME(A.GWA, DATE_FORMAT(SYSDATE(), '%Y-%m-%d'), :hospCode,'JA')           GWA_NAME                            " );
		 sql.append("	        ,FN_ADM_LOAD_USER_NAME(A.UPD_ID,:hospCode)                                         UPD_NAME                                    " );
		 sql.append("	                                                                                                                                       " );
		 sql.append("	   FROM OUT0101 B RIGHT JOIN SCH0201 A ON B.HOSP_CODE = A.HOSP_CODE   AND B.BUNHO = A.BUNHO                                            " );
		 sql.append("	        JOIN OCS0103 C ON  C.HOSP_CODE    = A.HOSP_CODE AND C.HANGMOG_CODE = A.HANGMOG_CODE                                            " );
		 sql.append("	                                                                                                                                       " );
		 sql.append("	  WHERE A.HOSP_CODE    = :hospCode                                                                                                     " );
		 sql.append("	   AND C.HOSP_CODE    = A.HOSP_CODE                                                                                                    " );
		 if(!StringUtils.isEmpty(fromDate) &&!StringUtils.isEmpty(toDate)) {
			 sql.append("	    AND A.RESER_DATE   BETWEEN STR_TO_DATE(:fromDate,'%Y/%m/%d') AND STR_TO_DATE(:toDate,'%Y/%m/%d')                               " );
		 }
		 sql.append("	    AND A.GWA          LIKE :gwa                                                                                                       " );
		 
			// sql.append("	    AND A.BUNHO        LIKE CONCAT(:bunho,'%')                                                                                       " );
		 
		 sql.append("	    AND A.RESER_YN     = 'Y'                                                                                                           " );
		 sql.append("	    AND A.CANCEL_YN    = 'N'                                                                                                           " );
		 sql.append("	    AND ((FN_SCH_ORDER_CHK(:hospCode,A.IN_OUT_GUBUN, A.FKOCS) = 'Y')                                                                   " );
		 sql.append("	     OR  (A.FKOCS IS NULL))                                                                                                            " );
		 sql.append("	                                                                                                                                       " );
		 sql.append("	  ORDER BY A.GWA, A.RESER_DATE, A.BUNHO, A.RESER_TIME;                                                                                 " );

		 Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("hospCode", hospCode);
		 query.setParameter("fromDate", fromDate);
		 query.setParameter("toDate", toDate);
		 query.setParameter("gwa", gwa);
		 //query.setParameter("bunho", bunho);

		 List<SchsSCH0201Q02ReserList02ItemInfo> list = new JpaResultMapper().list(query, SchsSCH0201Q02ReserList02ItemInfo.class);
		 return list;
	}

	@Override
	public List<SchsSCH0201Q02ReserList03ItemInfo> getSchsSCH0201Q02ReserList03ItemInfo(
			String hospCode, String fromDate, String toDate, String gwa) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT																											         	   ");
		sql.append("	       DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d') RESER_DATE,                                                                               ");
		sql.append("	       CONCAT(IF(A.FKOCS = NULL,FN_SCH_LOAD_CODE_NAME(:hospCode, 'SOGAE_TEXT', '01'),''),                                              ");
		sql.append("	       IFNULL(A.SUNAME, B.SUNAME))                                                                  SUNAME,                            ");
		sql.append("	       FN_BAS_LOAD_CODE_NAME('IN_OUT_GUBUN', A.IN_OUT_GUBUN,:hospCode,'JA')                      IN_OUT_GUBUN,                         ");
		sql.append("	       A.BUNHO                                                                                        BUNHO,                           ");
		sql.append("	       DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d')                                                         ACTING_DATE,                     ");
		sql.append("	       A.COMMENTS                                                                                     COMMENTS,                        ");
		sql.append("	       FN_SCH_LOAD_JUNDAL_PART_NAME(A.JUNDAL_TABLE, A.JUNDAL_PART, :hospCode)                                     JUNDAL_PART_NAME,    ");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.GWA,A.RESER_DATE,:hospCode,'JA')                                      GWA_NAME,                          ");
		sql.append("	       FN_ADM_LOAD_USER_NAME(A.UPD_ID, :hospCode)                                                    UPD_NAME,                         ");
		sql.append("	       CONCAT(A.GWA,                                                                                                                   ");
		sql.append("	              DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d'),                                                                                   ");
		sql.append("	              A.BUNHO,                                                                                                                 ");
		sql.append("	              IFNULL(A.RESER_TIME, '0000'),                                                                                            ");
		sql.append("	              A.IN_OUT_GUBUN,                                                                                                          ");
		sql.append("	              LPAD(A.JUNDAL_PART, 6, '0'))                                                                CONT_KEY                     ");
		sql.append("	                                                                                                                                       ");
		sql.append("	  FROM OUT0101 B RIGHT JOIN SCH0201 A ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                               ");
		sql.append("	                                                                                                                                       ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                                                                                                         ");
		sql.append("	                                                                                                                                       ");
		if(!StringUtils.isEmpty(fromDate) &&!StringUtils.isEmpty(toDate)) {
		sql.append("	   AND A.RESER_DATE   BETWEEN STR_TO_DATE(:fromDate,'%Y/%m/%d') AND STR_TO_DATE(:toDate,'%Y/%m/%d')                                    ");
		}
		sql.append("	   AND A.GWA          LIKE :gwa                                                                                                        ");
		sql.append("	   AND A.RESER_YN     = 'Y'                                                                                                            ");
		sql.append("	   AND A.CANCEL_YN    = 'N'                                                                                                            ");
		sql.append("	   AND ((FN_SCH_ORDER_CHK(:hospCode ,A.IN_OUT_GUBUN, A.FKOCS) = 'Y')                                                                   ");
		sql.append("	    OR  (A.FKOCS IS NULL))                                                                                                             ");
		sql.append("	 ORDER BY CONT_KEY;                                                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("fromDate", fromDate);
		query.setParameter("toDate", toDate);
		query.setParameter("gwa", gwa);

		List<SchsSCH0201Q02ReserList03ItemInfo> list = new JpaResultMapper().list(query, SchsSCH0201Q02ReserList03ItemInfo.class);
		return list;
	}

	@Override
	public List<SchsSCH0201Q04PrartListItemInfo> getSchsSCH0201Q04PrartListItemInfo(
			String hospCode, String jundalTable) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT JUNDAL_TABLE											");
		sql.append("	     , JUNDAL_PART                                         " );
		sql.append("	     , JUNDAL_PART_NAME                                    " );
		sql.append("	  FROM SCH0001                                             " );
		sql.append("	 WHERE HOSP_CODE    = :hospCode                            " );
		sql.append("	   AND JUNDAL_TABLE = :jundalTable                         " );
		sql.append("	   AND JUNDAL_PART NOT LIKE 'NUT%'                         " );
		sql.append("	   AND :jundalTable <> 'NUT'                               " );
		sql.append("	 UNION ALL                                                 " );
		sql.append("	SELECT JUNDAL_TABLE                                        " );
		sql.append("	     , JUNDAL_PART                                         " );
		sql.append("	     , JUNDAL_PART_NAME                                    " );
		sql.append("	  FROM SCH0001                                             " );
		sql.append("	 WHERE HOSP_CODE    = :hospCode                            " );
		sql.append("	   AND JUNDAL_TABLE = 'PFE'                                " );
		sql.append("	   AND JUNDAL_PART  LIKE 'NUT%'                            " );
		sql.append("	   AND :jundalTable = 'NUT'                                ");
		sql.append("	 ORDER BY JUNDAL_TABLE, JUNDAL_PART, JUNDAL_PART_NAME      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalTable", jundalTable);


		List<SchsSCH0201Q04PrartListItemInfo> list = new JpaResultMapper().list(query, SchsSCH0201Q04PrartListItemInfo.class);
		return list;
	}

	@Override
	public List<SchsSCH0201Q04GetMonthReserListInfo> getSchsSCH0201Q04GetMonthReserListInfo(
			String hospCode, String judalTable, String judalPart, String month) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.HOLI_DAY,																					" );
		sql.append("	       FN_SCH_PART_RESER_CNT(:hospCode,:judalTable, :judalPart, A.HOLI_DAY)        RESER_CNT,       " );
		sql.append("	       FN_SCH_PART_RESER_INWON(:hospCode,:judalTable, :judalPart, A.HOLI_DAY)      INWON_CNT        " );
		sql.append("	  FROM RES0101 A                                                                                    " );
		sql.append("	 WHERE DATE_FORMAT(HOLI_DAY, '%Y%m') = :month                                                       " );
		sql.append("	 ORDER BY A.HOLI_DAY																				" );
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("judalTable", judalTable);
		query.setParameter("judalPart", judalPart);
		query.setParameter("month", month);


		List<SchsSCH0201Q04GetMonthReserListInfo> list = new JpaResultMapper().list(query, SchsSCH0201Q04GetMonthReserListInfo.class);
		return list;
	}

	@Override
	public List<SchsSCH0201Q04ReserTimeListInfo> getSchsSCH0201Q04ReserTimeListInfo(
			String hospCode, String ipAddress) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.HANGMOG_CODE                               HANGMOG_CODE														          ");
		sql.append("	     , A.HANGMOG_NAME                               HANGMOG_NAME                                                                  ");
		sql.append("	     , A.RESER_DATE                                 RESER_DATE                                                                    ");
		sql.append("	     , A.FROM_TIME                                  RESER_TIME                                                                    ");
		sql.append("	     , CONCAT(A.SUNAME, IF( IFNULL(A.SUNAME,'X') = 'X','', CONCAT(' (', FN_OUT_LOAD_SUNAME2(A.BUNHO,:hospCode) , ')')))  SUNAME   ");
		sql.append("	     , B.INPUT_ID                                   INPUT_ID                                                                      ");
		sql.append("	     , B.IN_OUT_GUBUN                               IN_OUT_GUBUN                                                                  ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.GWA, B.INPUT_DATE,:hospCode, 'JA')    INPUT_GWA                                                     ");
		sql.append("	     , C.SEX                                        SEX                                                                           ");
		sql.append("	     , FN_BAS_LOAD_AGE(B.INPUT_DATE, C.BIRTH, NULL) AGE                                                                           ");
		sql.append("	     , B.ACTING_DATE                                ACTING_DATE                                                                   ");
		sql.append("	     , B.COMMENTS                                   COMMENTS                                                                      ");
		sql.append("	     , B.BUNHO                                      BUNHO                                                                         ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, SYSDATE(),:hospCode)   DOCTOR                                                            ");
		sql.append("	     , FN_ADM_LOAD_USER_NAME(A.UPD_ID,:hospCode)              UPD_NAME                                                            ");
		sql.append("	                                                                                                                                  ");
		sql.append("	 FROM SCH_TEMP A LEFT JOIN SCH0201  B ON A.HOSP_CODE = B.HOSP_CODE  AND A.PKSCH0201 = B.PKSCH0201                                 ");
		sql.append("	      LEFT JOIN   OUT0101  C ON A.HOSP_CODE = C.HOSP_CODE  AND A.BUNHO = C.BUNHO                                                  ");
		sql.append("	                                                                                                                                  ");
		sql.append("	 WHERE A.HOSP_CODE    = :hospCode                                                                                                 ");
		sql.append("	   AND A.IP_ADDRESS   = :ipAddress                                                                                                ");
		sql.append("	   AND B.BUNHO IS NOT NULL                                                                                                        ");
		sql.append("	 ORDER BY A.FROM_TIME, A.BUNHO;                                                                                                   ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("ipAddress", ipAddress);

		List<SchsSCH0201Q04ReserTimeListInfo> list = new JpaResultMapper().list(query, SchsSCH0201Q04ReserTimeListInfo.class);
		return list;
	}

	@Override
	public void callSchsSCH0201Q04PrSchTimeList(String hospCode,
			String ipAddress, String jundalTable, String jundalPart,
			String gumsaja, String reserDate) {
		LOGGER.info("[START] callSchsSCH0201Q04PrSchTimeList  hospCode =" + hospCode + ", ipAddress=" + ipAddress + ", jundalTable=" + jundalTable + ","
				+ " jundalPart=" + jundalPart + ", gumsaja=" + gumsaja + ", reserDate=" + reserDate);
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_SCH_TIME_LIST");
		query.registerStoredProcedureParameter("I_HOSPCODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IP_ADDRESS", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUNDAL_TABLE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUNDAL_PART", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_GUMSAJA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESER_DATE", Date.class, ParameterMode.IN);
		
		query.setParameter("I_HOSPCODE", hospCode);
		query.setParameter("I_IP_ADDRESS", ipAddress);
		query.setParameter("I_JUNDAL_TABLE", jundalTable);
		query.setParameter("I_JUNDAL_PART", jundalPart);
		query.setParameter("I_GUMSAJA", gumsaja);
		query.setParameter("I_RESER_DATE", DateUtil.toDate(reserDate, DateUtil.PATTERN_YYMMDD));
		
		query.execute();
	}

	@Override
	public List<ComboListItemInfo> getSCH0201Q12FwkDoctorList(String hospCode, String gwa, String find1) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT DISTINCT A.SABUN, A.DOCTOR_NAME																		    ");
		sql.append(" 	  FROM BAS0270 A                                                                                            ");
		sql.append(" 	 WHERE A.HOSP_CODE  = :f_hosp_code                                                                          ");
		sql.append(" 	   AND A.DOCTOR_GWA LIKE :f_gwa                                                                             ");
		sql.append(" 		AND ( A.DOCTOR  LIKE :f_find1                                                                           ");
		sql.append("         OR                                                                                                     ");
		sql.append("          A.DOCTOR_NAME LIKE :f_find1                                                                           ");
		sql.append("        ) 	                                                                                                    ");
		sql.append(" 	   AND A.START_DATE = ( SELECT MAX(B.START_DATE)                                                            ");
		sql.append(" 	                          FROM BAS0270 B                                                                    ");
		sql.append(" 	                        WHERE B.HOSP_CODE = A.HOSP_CODE                                                     ");
		sql.append(" 	                          AND B.DOCTOR = A.DOCTOR)                                                          ");
		sql.append(" 	   AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) > DATE_FORMAT(SYSDATE(), '%Y/%m/%d')       ");
		sql.append(" 	   ORDER BY 1   																							");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa + "%");
		query.setParameter("f_find1", find1 + "%");

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<SCH0201Q12GrdListItemInfo> getSCH0201Q12GrdListItemInfo(
			String hospCode, String bunho, String statFlg, String naewonDate,
			String gwa, String doctor, String reserGubun, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.ORDER_DATE                                                 AS KIZYUN_DATE												    ");						
		sql.append("	            , A.GWA                                                        AS GWA                                   				");
		sql.append("	            , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :hospCode, :f_language)                    AS GWA_NAME             		    ");
		sql.append("	            , A.DOCTOR                                                     AS DOCTOR                                				");
		sql.append("	            , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, :hospCode)              AS DOCTOR_NAME                				");
		sql.append("	            , A.HANGMOG_CODE                                               AS HANGMOG_CODE                          				");
		sql.append("	            , B.HANGMOG_NAME                                               AS HANGMOG_NAME                          				");
		sql.append("	            , A.JUNDAL_TABLE                                               AS JUNDAL_TABLE                          				");
		sql.append("	            , A.JUNDAL_PART                                                AS JUNDAL_PART                           				");
		sql.append("	            , C.BUSEO_NAME                                                 AS JUNDAL_PART_NAME                      				");
		sql.append("	            , A.RESER_TIME                                                 AS RESER_TIME                            				");
		sql.append("	            , 'A'                                                          AS RESER_YN                              				");
		sql.append("	            , CASE A.OCS_FLAG WHEN '1' THEN 'N' WHEN '2' THEN 'N' ELSE 'Y' END                  AS ACT_YN           				");
		sql.append("	            , A.ORDER_DATE                                                 AS ORDER_DATE                            				");
		sql.append("	            , 0                                                            AS PKSCH                                 				");
		sql.append("	         FROM OCS1003 A                                                                                             				");
		sql.append("	            , OCS0103 B                                                                                             				");
		sql.append("	            , BAS0260 C                                                                                             				");
		sql.append("	        WHERE A.HOSP_CODE    = :hospCode                                                                            				");
		sql.append("	          AND A.BUNHO        = :bunho  AND C.LANGUAGE = :f_language                                                                 ");
		sql.append("	          AND (:statFlg   = 'A' AND A.OCS_FLAG = '1'                                                                				");
		sql.append("	            OR :statFlg   = 'P' AND A.ORDER_DATE < STR_TO_DATE(:naewonDate, '%Y/%m/%d') 											");
		sql.append("								AND A.OCS_FLAG = '1'                               														");
		sql.append("	            OR :statFlg   = 'C' AND A.ORDER_DATE = STR_TO_DATE(:naewonDate, '%Y/%m/%d')                    							");
		sql.append("	            OR :statFlg   = 'F' AND A.ORDER_DATE > STR_TO_DATE(:naewonDate, '%Y/%m/%d'))                   							");
		if (!StringUtils.isEmpty(gwa) && !"%".equals(gwa))
			sql.append("	          AND A.GWA          LIKE :gwa                                                                 				            ");
		if (!StringUtils.isEmpty(doctor) && !"%".equals(doctor))
			sql.append("	          AND A.DOCTOR       LIKE :doctor                                                              				            ");
		if (!StringUtils.isEmpty(reserGubun) && !"%".equals(reserGubun))
			sql.append("	          AND A.JUNDAL_TABLE LIKE :reserGubun				                                                      				");
		sql.append("	          AND A.HOPE_DATE    IS NULL                                                                                				");
		sql.append("	          AND A.OCS_FLAG     <> '2'                                                                                 				");
		sql.append("	          AND B.HOSP_CODE    = A.HOSP_CODE                                                                          				");
		sql.append("	          AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                       				");
		sql.append("	          AND B.SLIP_CODE REGEXP  'B|E|G|J|M|N'                                                                     				");
		sql.append("	          AND STR_TO_DATE(:naewonDate, '%Y/%m/%d') BETWEEN B.START_DATE AND B.END_DATE                     				 			");
		sql.append("	          AND C.HOSP_CODE    = A.HOSP_CODE                                                                          				");
		sql.append("	          AND C.GWA          = A.JUNDAL_PART                                                                        				");
		sql.append("	          AND STR_TO_DATE(:naewonDate, '%Y/%m/%d') BETWEEN C.START_DATE AND C.END_DATE                    				            ");
		sql.append("	          AND (   (IFNULL(A.INSTEAD_YN, 'N') = 'N')                                                                 				");
		sql.append("	               OR (IFNULL(A.INSTEAD_YN, 'N') = 'Y' AND IFNULL(A.APPROVE_YN, 'N') = 'Y')                             				");
		sql.append("	              )                                                                                                     				");
		sql.append("	 UNION ALL                                                                                                                          ");
		sql.append("	  SELECT A.RESER_DATE                                                 AS KIZYUN_DATE                                                ");
		sql.append("	             , A.GWA                                                        AS GWA                                                  ");
		sql.append("	             , FN_BAS_LOAD_GWA_NAME(A.GWA, A.INPUT_DATE,:hospCode, :f_language)                    AS GWA_NAME                        ");
		sql.append("	             , A.DOCTOR                                                     AS DOCTOR                                               ");
		sql.append("	             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:hospCode)              AS DOCTOR_NAME                                ");
		sql.append("	             , A.HANGMOG_CODE                                               AS HANGMOG_CODE                                         ");
		sql.append("	             , B.HANGMOG_NAME                                               AS HANGMOG_NAME                                         ");
		sql.append("	             , A.JUNDAL_TABLE                                               AS JUNDAL_TABLE                                         ");
		sql.append("	             , A.JUNDAL_PART                                                AS JUNDAL_PART                                          ");
		sql.append("	             , C.JUNDAL_PART_NAME                                           AS JUNDAL_PART_NAME                                     ");
		sql.append("	             , A.RESER_TIME                                                 AS RESER_TIME                                           ");
		sql.append("	             , IF(A.RESER_DATE= NULL, 'N', 'Y')                            AS RESER_YN                                              ");
		sql.append("	             , IF(A.ACTING_DATE= NULL, 'N', 'Y')                          AS ACT_YN                                                 ");
		sql.append("	             , A.ORDER_DATE                                                 AS ORDER_DATE                                           ");
		sql.append("	             , A.PKSCH0201                                                  AS PKSCH                                                ");
		sql.append("	          FROM SCH0201 A                                                                                                            ");
		sql.append("	             , OCS0103 B                                                                                                            ");
		sql.append("	             , SCH0001 C                                                                                                            ");
		sql.append("	             , OCS1003 D                                                                                                            ");
		sql.append("	         WHERE A.HOSP_CODE    = :hospCode                                                                                           ");
		sql.append("	           AND A.BUNHO        = :bunho                                                                                              ");
		sql.append("	           AND (:statFlg   = 'A' AND A.ACTING_DATE IS NULL                                                                          ");
		sql.append("	             OR :statFlg   = 'P' AND A.RESER_DATE < STR_TO_DATE(:naewonDate, '%Y/%m/%d') 											");
		sql.append("							 AND IF(A.ACTING_DATE = NULL, 'N', 'Y') = 'N'                        										");
		sql.append("	             OR :statFlg   = 'C' AND A.RESER_DATE = STR_TO_DATE(:naewonDate, '%Y/%m/%d')                                   			");
		sql.append("	             OR :statFlg   = 'F' AND A.RESER_DATE > STR_TO_DATE(:naewonDate, '%Y/%m/%d'))                                  			");
		if (!StringUtils.isEmpty(gwa) && !"%".equals(gwa))
			sql.append("	          AND A.GWA          LIKE :gwa                                                                 				            ");
		if (!StringUtils.isEmpty(doctor) && !"%".equals(doctor))
			sql.append("	          AND A.DOCTOR       LIKE :doctor                                                              				            ");
		if (!StringUtils.isEmpty(reserGubun) && !"%".equals(reserGubun))
			sql.append("	          AND A.JUNDAL_TABLE LIKE :reserGubun				                                                      				");
		sql.append("	           AND A.IN_OUT_GUBUN = 'O'                                                                                                 ");
		sql.append("	           AND A.JUNDAL_TABLE <> 'PHY'                                                                                              ");
		sql.append("	           AND IFNULL(A.CANCEL_YN, 'N') = 'N'                                                                                       ");
		sql.append("	           AND B.HOSP_CODE    = A.HOSP_CODE                                                                                         ");
		sql.append("	           AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                      ");
		sql.append("	           AND STR_TO_DATE(:naewonDate, '%Y/%m/%d') BETWEEN B.START_DATE AND B.END_DATE                                    			");
		sql.append("	           AND C.HOSP_CODE    = A.HOSP_CODE                                                                                         ");
		sql.append("	           AND C.JUNDAL_TABLE = A.JUNDAL_TABLE                                                                                      ");
		sql.append("	           AND C.JUNDAL_PART  = A.JUNDAL_PART                                                                                       ");
		sql.append("	                                                                                                                                    ");
		sql.append("	           AND D.HOSP_CODE = A.HOSP_CODE                                                                                            ");
		sql.append("	           AND D.PKOCS1003 = A.FKOCS                                                                                                ");
		sql.append("	           AND (   (IFNULL(D.INSTEAD_YN, 'N') = 'N')                                                                                ");
		sql.append("	                OR (IFNULL(D.INSTEAD_YN, 'N') = 'Y' AND IFNULL(D.APPROVE_YN, 'N') = 'Y')                                            ");
		sql.append("	               )                                                                                                                    ");
		sql.append("	 UNION ALL                                                                                                                          ");
		sql.append("	 SELECT B.RESER_DATE                                                 AS KIZYUN_DATE                                                 ");
		sql.append("	             , A.GWA                                                        AS GWA                                                  ");
		sql.append("	             , FN_BAS_LOAD_GWA_NAME(A.GWA, B.RESER_DATE,:hospCode, :f_language)                    AS GWA_NAME                        ");
		sql.append("	             , A.DOCTOR                                                     AS DOCTOR                                               ");
		sql.append("	             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, B.RESER_DATE,:hospCode)              AS DOCTOR_NAME                                ");
		sql.append("	             , B.HANGMOG_CODE                                               AS HANGMOG_CODE                                         ");
		sql.append("	             , C.HANGMOG_NAME                                               AS HANGMOG_NAME                                         ");
		sql.append("	             , 'INJ'                                                        AS JUNDAL_TABLE                                         ");
		sql.append("	             , A.JUNDAL_PART                                                AS JUNDAL_PART                                          ");
		sql.append("	             , D.BUSEO_NAME                                                 AS JUNDAL_PART_NAME                                     ");
		sql.append("	             , B.RESER_TIME                                                 AS RESER_TIME                                           ");
		sql.append("	             , IF(B.RESER_DATE= NULL, 'N', 'Y')                         AS RESER_YN                                                 ");
		sql.append("	             , IF(B.ACTING_DATE= NULL, 'N', 'Y')                        AS ACT_YN                                                   ");
		sql.append("	             , A.ORDER_DATE                                                 AS ORDER_DATE                                           ");
		sql.append("	             , B.PKINJ1002                                                  AS PKSCH                                                ");
		sql.append("	          FROM BAS0260 D                                                                                                            ");
		sql.append("	             , OCS0103 C                                                                                                            ");
		sql.append("	             , INJ1002 B                                                                                                            ");
		sql.append("	             , INJ1001 A                                                                                                            ");
		sql.append("	             , OCS1003 E                                                                                                            ");
		sql.append("	         WHERE A.HOSP_CODE    = :hospCode                                                                                           ");
		sql.append("	           AND A.BUNHO        = :bunho  AND D.LANGUAGE = :f_language                                                                ");
		if (!StringUtils.isEmpty(gwa) && !"%".equals(gwa))
			sql.append("	          AND A.GWA          LIKE :gwa                                                                 				            ");
		if (!StringUtils.isEmpty(doctor) && !"%".equals(doctor))
			sql.append("	          AND A.DOCTOR       LIKE :doctor                                                              				            ");
		if (!StringUtils.isEmpty(reserGubun) && !"%".equals(reserGubun))
			sql.append("	          AND 'INJ' LIKE :reserGubun				                                                      				        ");
		sql.append("	           AND B.HOSP_CODE    = A.HOSP_CODE                                                                                         ");
		sql.append("	           AND B.FKINJ1001    = A.PKINJ1001                                                                                         ");
		sql.append("	           AND (:statFlg   = 'A' AND B.ACTING_DATE IS NULL                                                                          ");
		sql.append("	             OR :statFlg   = 'P' AND B.RESER_DATE < STR_TO_DATE(:naewonDate, '%Y/%m/%d') 									        ");
		sql.append("							 AND IF(B.ACTING_DATE= NULL, 'N', 'Y') = 'N'                        										");
		sql.append("	             OR :statFlg   = 'C' AND A.ORDER_DATE <> B.RESER_DATE 																	");
		sql.append("										AND B.RESER_DATE = STR_TO_DATE(:naewonDate, '%Y/%m/%d')   							        	");
		sql.append("	             OR :statFlg   = 'F' AND B.RESER_DATE > STR_TO_DATE(:naewonDate, '%Y/%m/%d'))                                           ");
		sql.append("	           AND IFNULL(B.DC_YN, 'N') = 'N'                                                                                           ");
		sql.append("	           AND C.HOSP_CODE    = B.HOSP_CODE                                                                                         ");
		sql.append("	           AND C.HANGMOG_CODE = B.HANGMOG_CODE                                                                                      ");
		sql.append("	           AND STR_TO_DATE(:naewonDate, '%Y/%m/%d') BETWEEN C.START_DATE AND C.END_DATE                                             ");
		sql.append("	           AND D.HOSP_CODE    = A.HOSP_CODE                                                                                         ");
		sql.append("	           AND D.GWA          = A.JUNDAL_PART                                                                                       ");
		sql.append("	           AND STR_TO_DATE(:naewonDate, '%Y/%m/%d') BETWEEN D.START_DATE AND D.END_DATE                                             ");
		sql.append("	           AND E.HOSP_CODE = A.HOSP_CODE                                                                                            ");
		sql.append("	           AND E.PKOCS1003 = A.FKOCS1003                                                                                            ");
		sql.append("	           AND (   (IFNULL(E.INSTEAD_YN, 'N') = 'N')                                                                                ");
		sql.append("	                OR (IFNULL(E.INSTEAD_YN, 'N') = 'Y' AND IFNULL(E.APPROVE_YN, 'N') = 'Y')                                            ");
		sql.append("	               )                                                                                                                    ");
		sql.append("	ORDER BY KIZYUN_DATE, GWA, DOCTOR, JUNDAL_TABLE, JUNDAL_PART,( RESER_TIME IS NOT NULL), RESER_TIME DESC , RESER_YN                  ");
		                                                                                                                     
		                                                                                                                     
		                           
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("statFlg", statFlg);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("f_language", language);
		if (!StringUtils.isEmpty(gwa) && !"%".equals(gwa))
			query.setParameter("gwa", gwa);
		if (!StringUtils.isEmpty(doctor) && !"%".equals(doctor))
			query.setParameter("doctor", doctor);
		if (!StringUtils.isEmpty(reserGubun) && !"%".equals(reserGubun))
			query.setParameter("reserGubun", reserGubun);

		
		List<SCH0201Q12GrdListItemInfo> list = new JpaResultMapper().list(query, SCH0201Q12GrdListItemInfo.class);
		return list;
	}

	@Override
	public List<String> getSCH0201Q12DistinctDoctorNameListInfo(String hospCode, String gwa, String doctor) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT A.DOCTOR_NAME																		  	");
		sql.append("	 FROM BAS0270 A                                                                                      	");
		sql.append("	WHERE A.HOSP_CODE  = :hospCode                                                                      	");
		sql.append("	  AND A.DOCTOR_GWA LIKE CONCAT(:gwa , '%')                                                          	");
		sql.append("	  AND A.SABUN      = :doctor                                                                         	");
		sql.append("	  AND A.START_DATE = ( SELECT MAX(B.START_DATE)                                                         ");
		sql.append("	                         FROM BAS0270 B                                                                 ");
		sql.append("	                       WHERE B.HOSP_CODE = A.HOSP_CODE                                                  ");
		sql.append("	                         AND B.DOCTOR = A.DOCTOR)                                                       ");
		sql.append("	  AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) > DATE_FORMAT(SYSDATE(), '%Y-%m-%d');   ");
		
        
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("gwa", gwa);
		query.setParameter("doctor", doctor);

		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public String callPrSchSch0210Iud(String hospCode, String iudGubun,
			String fksch0201, Date reserDate, String reserTime,
			String inputId, String ioErr) {
		LOGGER.info("[START] callPrSchSch0210Iud: hospCode"+ hospCode + ", iudGubun" + iudGubun + ", fksch0201" + fksch0201
				+ ", reserDate" + reserDate + ", reserTime" + reserTime + ", inputId" + inputId + ", ioErr" + ioErr);
		
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_SCH_SCH0201_IUD");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKSCH0201", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESER_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_RESER_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IUD_GUBUN", iudGubun);
		query.setParameter("I_FKSCH0201", CommonUtils.parseDouble(fksch0201));
		query.setParameter("I_RESER_DATE", reserDate);
		if(!StringUtils.isEmpty(reserTime)){
			query.setParameter("I_RESER_TIME", reserTime);
		}else{
			query.setParameter("I_RESER_TIME", null);
		}
		query.setParameter("I_INPUT_ID", inputId);
		query.setParameter("IO_ERR", ioErr);
		query.execute();
		
		String result = (String)query.getOutputParameterValue("IO_ERR");
		return result;
	}

	@Override
	public List<SchsSCH0201U99GrdOrderListInfo> getSchsSCH0201U99GrdOrderListInfo(
			String hospCode,String language, String flag, String bunho, String fkocs,
			String reserStatus, String reserGubun, String reserPart, String isMyclinic) {
		StringBuilder sql = new StringBuilder();
		if(StringUtils.isEmpty(reserGubun)){
			reserGubun = null;
		}
		if(StringUtils.isEmpty(reserPart)){
			reserPart = null;
		}
		sql.append("	SELECT A.HANGMOG_CODE                                                         HANGMOG_CODE													    ");
		sql.append("	     , B.HANGMOG_NAME                                                         HANGMOG_NAME                                                      ");
		sql.append("	     , A.JUNDAL_TABLE                                                         JUNDAL_TABLE                                                      ");
		sql.append("	     , A.JUNDAL_PART                                                          JUNDAL_PART														");
		sql.append("	     , C.JUNDAL_PART_NAME                                                     JUNDAL_PART_NAME                                                  ");
		sql.append("	     , A.PKSCH0201                                                            PKSCH0201                                                         ");
		sql.append("	     , A.BUNHO                                                                BUNHO                                                             ");
		sql.append("	     , A.SUNAME                                                               SUNAME                                                            ");
		sql.append("	     , A.GWA                                                                  GWA                                                               ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.INPUT_DATE,:hospCode, :language)            GWA_NAME                                                       ");
		sql.append("	     , A.DOCTOR                                                                DOCTOR                                                           ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:hospCode)            DOCTOR_NAME                                                         ");
		sql.append("	     , A.ORDER_DATE                                                            ORDER_DATE                                                       ");
		sql.append("	     , IFNULL(A.EMERGENCY,'N')                                                    EMERGENCY                                                     ");
		sql.append("	     , A.RESER_DATE                                                            RESER_DATE                                                       ");
		sql.append("	     , A.RESER_TIME                                                            RESER_TIME                                                       ");
		sql.append("	     , FN_SCH_ORDER_REMARK(:hospCode,A.IN_OUT_GUBUN,A.FKOCS)                ORDER_REMARK                                                        ");
		sql.append("	     , IF(A.RESER_DATE = NULL, 'N', 'Y')                                       RESER_YN                                                         ");
		sql.append("	     , (SELECT D.FKOUT1001                                                                                                                      ");
		sql.append("	          FROM OCS1003 D                                                                                                                        ");
		sql.append("	         WHERE D.HOSP_CODE = :hospCode                                                                                                          ");
		sql.append("	           AND D.PKOCS1003 = A.FKOCS)   PKOUT1001                                                                                               ");
		sql.append("	     ,FN_SCH_OCS_GROUP_SER(A.HOSP_CODE, A.FKOCS)          GROUP_SER                                                                             ");
		sql.append("	     ,A.OUT_HOSP_CODE                                OUT_HOSP_CODE                                               								");
		sql.append("	     ,A.PKSCH0201_OUT                                PKSCH0201_OUT                                               								");
		sql.append("	  FROM SCH0001 C                                                                                                                                ");
		sql.append("	     , OCS0103 B                                                                                                                                ");
		sql.append("	     , SCH0201 A                                                                                                                                ");
		sql.append("	 WHERE A.HOSP_CODE           = :hospCode                                                                                                        ");
		sql.append("	   AND (:flag = 'N' AND A.BUNHO = :bunho                                                                                                        ");
		sql.append("	     OR :flag = 'O' AND A.FKOCS = :fkocs)                                                                                                       ");
		sql.append("	   AND (:flag = 'O'                                                                                                                             ");
		sql.append("	     OR :flag = 'N' AND A.RESER_DATE IS NULL                                                                                                    ");
		sql.append("	     OR :flag = 'N' AND A.RESER_DATE IS NOT NULL AND A.ACTING_DATE   IS NULL)                                                                   ");
		sql.append("	   AND (:flag = 'O'                                                                                                                             ");
		sql.append("	     OR :flag = 'N' AND FN_SCH_OCS_JUBSU_YN(A.HOSP_CODE, A.IN_OUT_GUBUN, A.FKOCS) = 'N')                                                        ");
		sql.append("	   AND (:reserStatus = 'A'                                                                                                                      ");
		sql.append("	     OR :reserStatus = 'N' AND A.RESER_DATE IS NULL                                                                                             ");
		sql.append("	     OR :reserStatus = 'D' AND A.RESER_DATE IS NOT NULL AND A.RESER_TIME IS NULL                                                                ");
		sql.append("	     OR :reserStatus = 'T' AND A.RESER_DATE IS NOT NULL AND A.RESER_TIME IS NOT NULL)                                                           ");
		sql.append("	   AND A.JUNDAL_TABLE        LIKE IFNULL(:reserGubun, '%')                                                                                      ");
		sql.append("	   AND A.JUNDAL_PART         LIKE IFNULL(:reserPart, '%')                                                                                       ");
		sql.append("	   AND IFNULL(A.CANCEL_YN,'N')  = 'N'                                                                                                           ");
		sql.append("	   AND B.HOSP_CODE           = A.HOSP_CODE                                                                                                      ");
		sql.append("	   AND B.HANGMOG_CODE        = A.HANGMOG_CODE                                                                                                   ");
		sql.append("	   AND DATE_FORMAT(SYSDATE(),'%Y-%m-%d %H:%m:%s')        BETWEEN START_DATE AND END_DATE                                                        ");
		sql.append("	   AND C.HOSP_CODE           = A.HOSP_CODE                                                                                                      ");
		sql.append("	   AND C.JUNDAL_TABLE        = A.JUNDAL_TABLE                                                                                                   ");
		sql.append("	   AND C.JUNDAL_PART         = A.JUNDAL_PART                                                                                                 ");


		if(isMyclinic.equals("Y"))
		{
			sql.append("	   AND A.FKOCS IS NOT NULL                                                                                   								");
		}
		else if(isMyclinic.equals("N"))
		{
			sql.append("	   AND FKOCS IS NULL AND IFNULL(B.COMMON_YN, 'N') = 'Y'                                                                                									");
		}
		sql.append("	ORDER BY A.RESER_YN, A.RESER_DATE, A.RESER_TIME, A.ORDER_DATE, A.GWA, GROUP_SER, A.DOCTOR, A.JUNDAL_TABLE, A.JUNDAL_PART, A.HANGMOG_CODE;       ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("flag", flag);
		query.setParameter("bunho", bunho);
		query.setParameter("fkocs", fkocs);
		query.setParameter("reserStatus", reserStatus);
		query.setParameter("reserGubun", reserGubun);
		query.setParameter("reserPart", reserPart);
		//query.setParameter("wonyoi_order_yn", wonyoi_order_yn);

		List<SchsSCH0201U99GrdOrderListInfo> list = new JpaResultMapper().list(query, SchsSCH0201U99GrdOrderListInfo.class);


		return list;
	}

	@Override
	public List<SchsSCH0201U99GrdTimeListInfo> getSchsSCH0201U99GrdTimeListInfo(
			String hospCode, String ipAddress) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.FROM_TIME       FROM_TIME														   " );
		sql.append("	     , A.BUNHO           BUNHO                                                             " );
		sql.append("	     , A.SUNAME          SUNAME                                                            " );
		sql.append("	     , A.HANGMOG_NAME    HANGMOG_NAME                                                      " );
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME( B.DOCTOR, B.ORDER_DATE,:hospCode) DOCTOR_NAME              " );
		sql.append("	     , B.INPUT_DATE      INPUT_DATE                                                        " );
		sql.append("	     , B.ORDER_DATE      ORDER_DATE                                                        " );
		sql.append("	     , B.RESER_DATE      RESER_DATE                                                        " );
		sql.append("	     , A.PKSCH0201       PKSCH0201                                                         " );
		sql.append("	     , B.OUT_HOSP_CODE       OUT_HOSP_CODE                                                 " );
		sql.append("	     ,(SELECT       YOYANG_NAME  FROM BAS0001 A                                            " );
		sql.append("	     WHERE START_DATE = (SELECT MAX(START_DATE) FROM BAS0001                               " );
		sql.append("	    WHERE HOSP_CODE = A.HOSP_CODE)     and HOSP_CODE = B.OUT_HOSP_CODE  )    YOYANG_NAME   " );
		sql.append("	  FROM SCH0201 B RIGHT JOIN SCH_TEMP A                                                     " );
		sql.append("	  ON   B.HOSP_CODE = A.HOSP_CODE                                                           " );
		sql.append("	  AND B.PKSCH0201 = A.PKSCH0201                                                            " );
		sql.append("	 WHERE A.HOSP_CODE    = :hospCode                                                          " );
		sql.append("	   AND A.IP_ADDRESS   = :ipAddress                                                         " );
		sql.append("	ORDER BY A.FROM_TIME, A.SUNAME;                                                            " );
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("ipAddress", ipAddress);

		List<SchsSCH0201U99GrdTimeListInfo> list = new JpaResultMapper().list(query, SchsSCH0201U99GrdTimeListInfo.class);
		return list;
	}

	@Override
	public List<SchsSCH0201U99LayoutTimeListInfo> getSchsSCH0201U99LayoutTimeListInfo(
			String hospCode, String ipAddress) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.RESER_DATE          RESER_DATE																													");
		sql.append("	      ,A.FROM_TIME           FROM_TIME                                                                                                                  ");
		sql.append("	      ,A.BUNHO               BUNHO                                                                                                                      ");
		sql.append("	      ,A.SUNAME              SUNAME                                                                                                                     ");
		sql.append("	      ,A.HANGMOG_CODE        HANGMOG_CODE                                                                                                               ");
		sql.append("	      ,A.HANGMOG_NAME        HANGMOG_NAME                                                                                                               ");
		sql.append("	      ,A.GWA                 GWA                                                                                                                        ");
		sql.append("	      ,FN_BAS_LOAD_DOCTOR_NAME(IFNULL(FN_OCS_LOAD_ORDER_DOCTOR(:hospCode,B.FKOCS), B.DOCTOR), B.ORDER_DATE, :hospCode) DOCTOR_NAME                      ");
		sql.append("	      ,IF(B.ACTING_DATE = NULL, 'N', 'Y') ACT_YN                                                                                                        ");
		sql.append("	  FROM SCH0201 B RIGHT JOIN SCH_TEMP A ON  B.HOSP_CODE = A.HOSP_CODE  AND B.PKSCH0201 = A.PKSCH0201                                                     ");
		sql.append("	                                                                                                                                                        ");
		sql.append("	 WHERE A.HOSP_CODE    = :hospCode                                                                                                                       ");
		sql.append("	   AND A.IP_ADDRESS   = :ipAddress                                                                                                                      ");
		sql.append("	 ORDER BY A.FROM_TIME, A.SUNAME;                                                                                                                        ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("ipAddress", ipAddress);

		List<SchsSCH0201U99LayoutTimeListInfo> list = new JpaResultMapper().list(query, SchsSCH0201U99LayoutTimeListInfo.class);
		return list;
	}

	@Override
	public String callPrSchSch0201EtcInsert(String hospCode, String iBunho,
			String iJundalTable, String iJundalPar, String iHangmogCode,
			String iUserId) {
		
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_SCH_SCH0201_ETC_INSERT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUNDAL_TABLE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUNDAL_PART", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", iBunho);
		query.setParameter("I_JUNDAL_TABLE", iJundalTable);
		query.setParameter("I_JUNDAL_PART", iJundalPar);
		query.setParameter("I_HANGMOG_CODE", iHangmogCode);
		query.setParameter("I_USER_ID", iUserId);
		
		String result = (String)query.getOutputParameterValue("O_ERR");
		return result;
	}

	@Override
	public List<SchsSCH0201U99DateScheduleItemInfo> getSchsSCH0201U99DateScheduleListInfo(
			String hospCode, String jundalTable, String jundalPart,
			String hangmogCode, String startDate) {
		StringBuilder sql = new StringBuilder();
		
		 sql.append("	SELECT																																							  ");
		 sql.append("	  DATE_ADD(STR_TO_DATE(:startDate, '%Y/%m/%d'), INTERVAL B.CNT DAY) DAYOFMON                                                                                      ");
		 sql.append("	   , FN_SCH_DAY_RESER_CHECK(:hospCode,:jundalTable, :jundalPart, :hangmogCode, DATE_ADD(STR_TO_DATE(:startDate, '%Y/%m/%d'), INTERVAL B.CNT DAY)) CHECK_YN        ");
		 sql.append("	   , FN_SCH_TOTAL_INWON(:hospCode,:jundalTable, :jundalPart, DATE_ADD(STR_TO_DATE(:startDate, '%Y/%m/%d'), INTERVAL B.CNT DAY)) INWON                             ");
		 sql.append("	   , FN_SCH_TOTAL_OUTWON(:hospCode,:jundalTable, :jundalPart, DATE_ADD(STR_TO_DATE(:startDate, '%Y/%m/%d'), INTERVAL B.CNT DAY)) OUTWON                           ");
		 sql.append("	   FROM (SELECT id-1 CNT                                                                                                                                          ");
		 sql.append("	   FROM LEVEL                                                                                                                                                     ");
		 sql.append("	   limit 43) B;																																					  ");
		
		 Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("hospCode", hospCode);
		 query.setParameter("jundalTable", jundalTable);
		 query.setParameter("jundalPart", jundalPart);
		 query.setParameter("hangmogCode", hangmogCode);
		 query.setParameter("startDate", startDate);
		 
		 List<SchsSCH0201U99DateScheduleItemInfo> listResult = new JpaResultMapper().list(query, SchsSCH0201U99DateScheduleItemInfo.class);
		 return listResult;
	}

	@Override
	public String getSCH0201U99ReserTimeChk(String hospCode, String bunho,
			String reserDate, String reserTime, Double pksch0201) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'															 ");
		sql.append("	  FROM SCH0201 A                                                     ");
		sql.append("	 WHERE A.HOSP_CODE          = :hospCode                              ");
		sql.append("	   AND A.BUNHO              = :bunho                                 ");
		sql.append("	   AND A.RESER_DATE         = STR_TO_DATE(:reserDate,'%Y/%m/%d')     ");
		sql.append("	   AND A.RESER_TIME         = :reserTime                             ");
		sql.append("	   AND A.PKSCH0201         <> :pksch0201                             ");
		sql.append("	  AND IFNULL(A.CANCEL_YN,'N') = 'N'                                  ");
		sql.append("	  AND A.ACTING_DATE IS NULL;                                         ");
		
		 Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("hospCode", hospCode);
		 query.setParameter("bunho", bunho);
		 query.setParameter("reserDate", reserDate);
		 query.setParameter("reserTime", reserTime);
		 query.setParameter("pksch0201", pksch0201);
		 
		 List<Object> listResult = query.getResultList();
		 if(listResult != null && !listResult.isEmpty()){
			 return listResult.get(0).toString();
		 }
		 return null;
	}
	
	@Override
	public List<SCH0201Q05LayReserListInfo> getSCH0201Q05LayReserListInfo(String hospCode, String language, String bunho){
		 StringBuilder sql = new StringBuilder();
		 sql.append("SELECT  A.PKSCH0201            PKSCH0201                                                                                                                      ");
		 sql.append("       ,A.IN_OUT_GUBUN         IN_OUT_GUBUN                                                                                                                   ");
		 sql.append("       ,A.FKOCS                FKOCS                                                                                                                          ");
		 sql.append("       ,A.BUNHO                BUNHO                                                                                                                          ");
		 sql.append("       ,A.GWA                  GWA                                                                                                                            ");
		 sql.append("       ,A.GUMSAJA              GUMSAJA                                                                                                                        ");
		 sql.append("       ,A.HANGMOG_CODE         HANGMOG_CODE                                                                                                                   ");
		 sql.append("       ,A.JUNDAL_TABLE         JUNDAL_TABLE                                                                                                                   ");
		 sql.append("       ,A.JUNDAL_PART          JUNDAL_PART                                                                                                                    ");
		 sql.append("       ,A.RESER_DATE           RESER_DATE                                                                                                                     ");
		 sql.append("       ,A.RESER_TIME           RESER_TIME                                                                                                                     ");
		 sql.append("       ,A.INPUT_DATE           INPUT_DATE                                                                                                                     ");
		 sql.append("       ,A.INPUT_ID             INPUT_ID                                                                                                                       ");
		 sql.append("       ,CONCAT(IF(A.FKOCS IS NULL, FN_SCH_LOAD_CODE_NAME(:f_hosp_code,'SOGAE_TEXT', '01'), '') ,IFNULL(A.SUNAME,B.SUNAME)) SUNAME                             ");
		 sql.append("       ,A.RESER_YN             RESER_YN                                                                                                                       ");
		 sql.append("       ,A.CANCEL_YN            CANCEL_YN                                                                                                                      ");
		 sql.append("       ,A.ACTING_DATE          ACTING_DATE                                                                                                                    ");
		 sql.append("       ,A.HOPE_DATE            HOPE_DATE                                                                                                                      ");
		 sql.append("       ,A.COMMENTS             COMMENTS                                                                                                                       ");
		 sql.append("       ,CONCAT(IF(A.JUNDAL_TABLE = 'CPL',D.JUNDAL_PART_NAME, C.HANGMOG_NAME) ,                                                                                ");
		 sql.append("        IF(IFNULL(A.JUSA_RESER_YN,'N') = 'Y',CONCAT('(',FN_ADM_MSG(4108,:f_language),')'),'')) HANGMOG_NAME                                                   ");
		 sql.append("       ,IFNULL(D.JUNDAL_PART_NAME,                                                                                                                            ");
		 sql.append("           FN_BAS_LOAD_JUNDAL_PART_NAME(:f_hosp_code,A.IN_OUT_GUBUN, CASE A.IN_OUT_GUBUN WHEN 'I' THEN C.JUNDAL_PART_INP                                      ");
		 sql.append("                                                                               WHEN 'O' THEN C.JUNDAL_PART_OUT END , A.RESER_DATE))     JUNDAL_PART_NAME      ");
		 sql.append("       ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.INPUT_DATE, :f_hosp_code, :f_language) GWA_NAME                                                                         ");
		 sql.append("       ,HO_DONG1               HO_DONG1                                                                                                                       ");
		 sql.append("       ,B.SEX                  SEX                                                                                                                            ");
		 sql.append("       ,FN_BAS_LOAD_AGE(SYSDATE(), B.BIRTH, NULL) AGE                                                                                                         ");
		 sql.append("       ,B.BIRTH                BIRTH                                                                                                                          ");
		 sql.append("       ,CASE A.IN_OUT_GUBUN WHEN 'I' THEN FN_BAS_LOAD_GWA_NAME(E.HO_DONG1, SYSDATE(), :f_hosp_code, :f_language)                                              ");
		 sql.append("                             WHEN 'O' THEN FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), :f_hosp_code, :f_language) END INPUT_GWA                                    ");
		 sql.append("       ,FN_SCH_LOAD_DOCTOR_NAME(:f_hosp_code, A.IN_OUT_GUBUN, A.FKOCS) DOCTOR_NAME                                                                            ");
		 sql.append("       ,FN_ADM_LOAD_USER_NAME(A.UPD_ID, :f_hosp_code)                                         UPD_NAME                                                        ");
		 sql.append("  FROM                                                                                                                                                        ");
		 sql.append("       SCH0201 A LEFT JOIN OUT0101 B ON B.HOSP_CODE = A.HOSP_CODE AND B.BUNHO = A.BUNHO                                                                       ");
		 sql.append("                 LEFT JOIN SCH0001 D ON D.HOSP_CODE = A.HOSP_CODE AND D.JUNDAL_PART = A.JUNDAL_PART                                                           ");
		 sql.append("                 LEFT JOIN INP1001 E ON E.HOSP_CODE = A.HOSP_CODE AND E.BUNHO = A.BUNHO AND E.TOIWON_DATE IS NULL                                             ");
		 sql.append("                 JOIN OCS0103 C ON C.HOSP_CODE = A.HOSP_CODE                                                                                                  ");
		 sql.append(" WHERE A.HOSP_CODE          = :f_hosp_code                                                                                                                    ");
		 sql.append("   AND A.BUNHO              = :f_bunho                                                                                                                        ");
		 sql.append("   AND A.RESER_YN           = 'Y'                                                                                                                             ");
		 sql.append("   AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                                                          ");
		 sql.append("   AND ((FN_SCH_ORDER_CHK(:f_hosp_code,A.IN_OUT_GUBUN, A.FKOCS) = 'Y')                                                                                        ");
		 sql.append("    OR  (A.FKOCS IS NULL))AND C.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                ");
		 sql.append(" ORDER BY A.RESER_DATE IS NULL DESC , A.RESER_TIME, A.JUNDAL_TABLE, A.JUNDAL_PART, A.BUNHO                                                                     ");
		 
		 Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("f_hosp_code", hospCode);
		 query.setParameter("f_bunho", bunho);
		 query.setParameter("f_language", language);
		 
		 List<SCH0201Q05LayReserListInfo> listResult = new JpaResultMapper().list(query, SCH0201Q05LayReserListInfo.class);
		 return listResult;
	}
	
	@Override
	public List<SCH0201U10GrdOrderItemInfo> getSCH0201U10GrdOrderItemInfo(String hospCode, String language, String bunho, String reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT MIN(A.PKSCH0201)                                                   PKKEY                                                            	 ");
		sql.append("      ,'N'                                                                GUBUN                                                            	 ");
		sql.append("      ,''                                                                 GWA                                                              	 ");
		sql.append("      ,''                                                                 GWA_NAME                                                         	 ");
		sql.append("      ,''                                                                 DOCTOR                                                           	 ");
		sql.append("      ,''                                                                 DOCTOR_NAME                                                      	 ");
		sql.append("      ,A.JUNDAL_PART                                                      HANGMOG_CODE                                                     	 ");
		sql.append("      ,D.JUNDAL_PART_NAME                                                 HANGMOG_NAME                                                     	 ");
		sql.append("      ,A.RESER_TIME                                                       RESER_TIME                                                       	 ");
		sql.append("      ,A.SEQ                                                              SEQ                                                              	 ");
		sql.append("      ,IFNULL(FN_ADM_TO_NUMBER(IFNULL(A.RESER_TIME,'0000')), A.SEQ)              SORT                                                      	 ");
		sql.append("  FROM SCH0201 A LEFT JOIN SCH0001 D ON D.JUNDAL_TABLE = A.JUNDAL_TABLE AND D.JUNDAL_PART = A.JUNDAL_PART                                  	 ");
		sql.append("      INNER JOIN OCS0103 B ON B.HANGMOG_CODE = A.HANGMOG_CODE                                                                              	 ");
		sql.append(" WHERE A.HOSP_CODE  = :hospitalCode                                                                                                        	 ");
		sql.append("   AND A.BUNHO      = :f_bunho                                                                                                             	 ");
		sql.append("   AND DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d') = :f_reser_date                                                                               	 ");
		sql.append("   AND A.JUNDAL_TABLE = 'CPL'                                                                                                              	 ");
		sql.append("   AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                                       	 ");
		sql.append("   AND A.ACTING_DATE IS NULL                                                                                                               	 ");
		sql.append(" GROUP BY A.JUNDAL_PART, D.JUNDAL_PART_NAME, A.RESER_TIME, A.SEQ                                                                           	 ");
		sql.append("                                                                                                                                           	 ");
		sql.append("UNION ALL                                                                                                                                  	 ");
		sql.append("SELECT A.PKSCH0201                                               PKKEY                                                                     	 ");
		sql.append("      ,'N'                                                                GUBUN                                                            	 ");
		sql.append("      ,A.GWA                                                              GWA                                                              	 ");
		sql.append("      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :hospitalCode, :language) GWA_NAME                                                        	 ");
		sql.append("      ,A.DOCTOR                                                           DOCTOR                                                           	 ");
		sql.append("      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, :hospitalCode)     DOCTOR_NAME                                                      	 ");
		sql.append("      ,A.HANGMOG_CODE                                                     HANGMOG_CODE                                                     	 ");
		sql.append("      ,CONCAT(IFNULL(B.HANGMOG_NAME,''), IF(IFNULL(A.JUSA_RESER_YN,'N') = 'Y', CONCAT('(',FN_ADM_MSG(4108, :language),')'),'')) HANGMOG_NAME ");
		sql.append("      ,A.RESER_TIME                                                       RESER_TIME                                                       	 ");
		sql.append("      ,A.SEQ                                                              SEQ                                                              	 ");
		sql.append("      ,IFNULL(FN_ADM_TO_NUMBER(IFNULL(A.RESER_TIME,'0000')) , A.SEQ)              SORT                                                     	 ");
		sql.append("  FROM OCS0103 B                                                                                                                           	 ");
		sql.append("      ,SCH0201 A                                                                                                                           	 ");
		sql.append(" WHERE A.HOSP_CODE  = :hospitalCode                                                                                                        	 ");
		sql.append("   AND A.BUNHO      = :f_bunho                                                                                                             	 ");
		sql.append("   AND DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d') = :f_reser_date                                                                               	 ");
		sql.append("   AND A.JUNDAL_TABLE <> 'CPL'                                                                                                             	 ");
		sql.append("   AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                                       	 ");
		sql.append("   AND A.ACTING_DATE IS NULL                                                                                                               	 ");
		sql.append("   AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                                     	 ");
		sql.append("                                                                                                                                           	 ");
		sql.append(" UNION ALL                                                                                                                                 	 ");
		sql.append("SELECT A.PKOUT1001                             PKKEY                                                                                       	 ");
		sql.append("      ,'Y'                                              GUBUN                                                                              	 ");
		sql.append("      ,A.GWA                                            GWA                                                                                	 ");
		sql.append("      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :hospitalCode, :language)       GWA_NAME                                                 	 ");
		sql.append("      ,A.DOCTOR                                         DOCTOR                                                                             	 ");
		sql.append("      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :hospitalCode) DOCTOR_NAME                                                         	 ");
		sql.append("      ,''                                               HANGMOG_CODE                                                                       	 ");
		sql.append("      ,''                                               HANGMOG_NAME                                                                       	 ");
		sql.append("      ,A.JUBSU_TIME                                     RESER_TIME                                                                         	 ");
		sql.append("      ,A.JUBSU_NO                                       SEQ                                                                                	 ");
		sql.append("      ,IFNULL(FN_ADM_TO_NUMBER(IFNULL(A.JUBSU_TIME,'0000')), A.JUBSU_NO)         SORT                                                      	 ");
		sql.append("  FROM OUT1001 A                                                                                                                           	 ");
		sql.append(" WHERE A.HOSP_CODE   = :hospitalCode                                                                                                       	 ");
		sql.append("   AND A.BUNHO       = :f_bunho                                                                                                            	 ");
		sql.append("   AND DATE_FORMAT(A.NAEWON_DATE, '%Y/%m/%d') = :f_reser_date                                                                              	 ");
		sql.append("   AND A.RESER_YN    = 'Y'                                                                                                                 	 ");
		sql.append("                                                                                                                                           	 ");
		sql.append(" UNION ALL                                                                                                                                 	 ");
		sql.append(" ( SELECT ''                           PKKEY                                                                                               	 ");
		sql.append("      ,'J'                                              GUBUN                                                                              	 ");
		sql.append("      ,''                                               GWA                                                                                	 ");
		sql.append("      ,''                                               GWA_NAME                                                                           	 ");
		sql.append("      ,''                                               DOCTOR                                                                             	 ");
		sql.append("      ,''                                               DOCTOR_NAME                                                                        	 ");
		sql.append("      ,''                                               HANGMOG_CODE                                                                       	 ");
		sql.append("      ,FN_ADM_MSG(4108, :language)                      HANGMOG_NAME                                                                       	 ");
		sql.append("      ,''                                               RESER_TIME                                                                         	 ");
		sql.append("      ,0                                                SEQ                                                                                	 ");
		sql.append("      ,FN_ADM_TO_NUMBER('0000')                         SORT                                                                               	 ");
		sql.append("  FROM DUAL                                                                                                                                	 ");
		sql.append(" WHERE EXISTS(                                                                                                                             	 ");
		sql.append("                SELECT A.PKINJ1001   PKKEY                                                                                                 	 ");
		sql.append("                  FROM INJ1001 A                                                                                                           	 ");
		sql.append("                     , INJ1002 B                                                                                                           	 ");
		sql.append("                 WHERE A.HOSP_CODE      = :hospitalCode                                                                                    	 ");
		sql.append("                   AND B.HOSP_CODE      = A.HOSP_CODE                                                                                      	 ");
		sql.append("                   AND A.BUNHO          = :f_bunho                                                                                         	 ");
		sql.append("                   AND A.PKINJ1001      = B.FKINJ1001                                                                                      	 ");
		sql.append("                   AND DATE_FORMAT(B.RESER_DATE, '%Y/%m/%d') = :f_reser_date                                                               	 ");
		sql.append("                   AND IFNULL(B.DC_YN,'N') = 'N'))                                                                                         	 ");
		sql.append(" ORDER BY SORT;                                                                                                                            	 ");
		 
		 
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("language", language);
		query.setParameter("f_reser_date", reserDate);
		
		List<SCH0201U10GrdOrderItemInfo> listResult = new JpaResultMapper().list(query, SCH0201U10GrdOrderItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<SCH0201U10LayReserInfo> getSCH0201U10LayReserInfo(String hospCode, String language, String bunho, String reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                                                  ");  
		sql.append("        ' '                                                                          GWA                                          ");
		sql.append("      , ' '                                                                          GWA_NAME                                     ");
		sql.append("      ,  A.BUNHO                                                                    BUNHO                                         ");
		sql.append("      , IFNULL(A.SUNAME,C.SUNAME)                                                   SUNAME                                        ");
		sql.append("      , A.RESER_DATE                                                                RESER_DATE                                    ");
		sql.append("      , IF(A.JUNDAL_TABLE = 'CPL',B.JUNDAL_PART_NAME, D.HANGMOG_NAME)             HANGMOG_NAME                                    ");
		sql.append("      , A.RESER_TIME                                                                RESER_TIME                                    ");
		sql.append("      , FN_BAS_LOAD_GWA_POSITION(D.MOVE_PART,SYSDATE(), :hospCode, :language)                  MOVE_NAME                                     ");
		sql.append("      , dayofweek(STR_TO_DATE(A.RESER_DATE, '%Y/%m/%d'))                            RESER_DAY                                     ");
		sql.append("      , FN_BAS_LOAD_AGE(SYSDATE(), C.BIRTH, '')                                     AGE                                           ");
		sql.append("      , DATE_FORMAT(C.BIRTH, '%Y/%m/%d')                                            BIRTH                                         ");
		sql.append("      , C.SUNAME2                                                                   SUNAME2                                       ");
		sql.append("      , A.JUNDAL_PART                                                               JUNDAL_PART                                   ");
		sql.append("      , ' '                                                                          RESER_MOVE_NAME                              ");
		sql.append("      , IF(A.JUNDAL_PART NOT IN('CPL','CPR','CPH'), A.HANGMOG_CODE, A.JUNDAL_PART)   HANGMOG_CODE                                 ");
		sql.append("      , A.JUNDAL_TABLE                                                              JUNDAL_TABLE                                  ");
		sql.append("      , A.HOPE_DATE                                                                 HOPE_DATE                                     ");
		sql.append("      , CASE A.JUNDAL_PART WHEN 'CPL' THEN FN_SCH_LOAD_SEQ(A.BUNHO,A.RESER_DATE,A.JUNDAL_PART, :hospCode)                         ");
		sql.append("                           WHEN 'CPR' THEN FN_SCH_LOAD_SEQ(A.BUNHO,A.RESER_DATE,A.JUNDAL_PART, :hospCode)                         ");
		sql.append("                           WHEN 'CPH' THEN FN_SCH_LOAD_SEQ(A.BUNHO,A.RESER_DATE,A.JUNDAL_PART, :hospCode)                         ");
		sql.append("                           ELSE A.SEQ END  SEQ                                                                                    ");
		sql.append("      , '0'                                                                SORT                                                   ");
		sql.append("   FROM SCH0201 A                                                                                                                 ");
		sql.append("        LEFT JOIN  SCH0001 B ON B.HOSP_CODE = A.HOSP_CODE AND B.JUNDAL_TABLE = A.JUNDAL_TABLE AND B.JUNDAL_PART = A.JUNDAL_PART   ");
		sql.append("        INNER JOIN OUT0101 C ON C.HOSP_CODE = A.HOSP_CODE AND C.BUNHO          = A.BUNHO                                          ");
		sql.append("        INNER JOIN OCS0103 D ON D.HOSP_CODE = A.HOSP_CODE AND D.HANGMOG_CODE   = A.HANGMOG_CODE                                   ");
		sql.append("  WHERE A.HOSP_CODE      = :hospCode                                                                                              ");
		sql.append("    AND A.BUNHO          = :f_bunho                                                                                               ");
		sql.append("    AND DATE_FORMAT(A.RESER_DATE,'%Y/%m/%d') = :f_reser_date                                                                      ");
		sql.append("    AND A.GWA            LIKE '%'                                                                                                 ");
		sql.append("    AND A.RESER_YN       = 'Y'                                                                                                    ");
		sql.append("    AND IFNULL(A.CANCEL_YN,'N') = 'N'                                                                                             ");
		sql.append("    AND A.ACTING_DATE    IS NULL                                                                                                  ");
		sql.append("    AND ((A.JUNDAL_TABLE = 'XRT' AND A.JUNDAL_PART  LIKE 'RI%') OR                                                                ");
		sql.append("         (A.JUNDAL_PART  NOT LIKE 'RI%' AND A.PART_PKKEY IS NULL))                                                                ");
		sql.append("  UNION ALL                                                                                                                       ");
		sql.append(" SELECT DISTINCT                                                                                                                  ");
		sql.append("        A.GWA                                                       GWA                                                           ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :hospCode, :language)                  GWA_NAME                                ");
		sql.append("      , A.BUNHO                                                     BUNHO                                                         ");
		sql.append("      , B.SUNAME                                                    SUNAME                                                        ");
		sql.append("      , A.NAEWON_DATE                                               RESER_DATE                                                    ");
		sql.append("      , CONCAT(IFNULL(FN_NUR_lOAD_CODE_NAME('NUR1001R99_TEXT', '01', :hospCode, :language),''),' ',                               ");
		sql.append("         IFNULL(FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :hospCode, :language),''),'  ',                                        ");
		sql.append("         IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE, :hospCode),'')) HANGMOG_NAME                                     ");
		sql.append("      , A.JUBSU_TIME                                                RESER_TIME                                                    ");
		sql.append("      , FN_BAS_LOAD_GWA_POSITION(A.GWA,SYSDATE(), :hospCode, :language)        MOVE_NAME                                                     ");
		sql.append("      , dayofweek(STR_TO_DATE(A.NAEWON_DATE, '%Y/%m/%d'))           RESER_DAY                                                     ");
		sql.append("      , FN_BAS_LOAD_AGE(SYSDATE(), B.BIRTH, '')                     AGE                                                           ");
		sql.append("      , DATE_FORMAT(B.BIRTH, '%Y/%m/%d')                            BIRTH                                                         ");
		sql.append("      , B.SUNAME2                                                   SUNAME2                                                       ");
		sql.append("      , ' '                                                          JUNDAL_PART                                                  ");
		sql.append("      , ' '                                                          RESER_MOVE_NAME                                              ");
		sql.append("      , A.GWA                                                       HANGMOG_CODE                                                  ");
		sql.append("      , ' '                                                          JUNDAL_TABLE                                                 ");
		sql.append("      , cast( null as datetime)                                                        HOPE_DATE                                  ");
		sql.append("      , IFNULL(A.JUBSU_NO,99)                                       SEQ                                                           ");
		sql.append("      , '0'                                                         SORT                                                          ");
		sql.append("   FROM OUT0101 B,                                                                                                                ");
		sql.append("        OUT1001 A                                                                                                                 ");
		sql.append("  WHERE A.HOSP_CODE      = :hospCode                                                                                              ");
		sql.append("    AND B.HOSP_CODE      = A.HOSP_CODE                                                                                            ");
		sql.append("    AND A.BUNHO           = :f_bunho                                                                                              ");
		sql.append("    AND DATE_FORMAT(A.NAEWON_DATE,'%Y/%m/%d') = :f_reser_date                                                                     ");
		sql.append("    AND A.RESER_YN        = 'Y'                                                                                                   ");
		sql.append("    AND B.BUNHO           = A.BUNHO                                                                                               ");
		sql.append("  UNION ALL                                                                                                                       ");
		sql.append(" SELECT DISTINCT                                                                                                                  ");
		sql.append("        ' '                                                          GWA                                                          ");
		sql.append("      , FN_BAS_LOAD_GWA_NAME(A.GWA, B.RESER_DATE, :hospCode, :language) GWA_NAME                                                  ");
		sql.append("      , A.BUNHO                                                     BUNHO                                                         ");
		sql.append("      , C.SUNAME                                                    SUNAME                                                        ");
		sql.append("      , B.RESER_DATE                                                RESER_DATE                                                    ");
		sql.append("      , FN_ADM_MSG(4108, :language)                                 HANGMOG_NAME                                                  ");
		sql.append("      , B.RESER_TIME                                                RESER_TIME                                                    ");
		sql.append("      , IF(A.JUNDAL_PART = 'IRH',FN_BAS_LOAD_GWA_POSITION(A.GWA,SYSDATE(), :hospCode, :language),                                            ");
		sql.append("  			FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART,SYSDATE(), :hospCode, :language)) MOVE_NAME                                        ");
		sql.append("      , dayofweek(STR_TO_DATE(B.RESER_DATE, '%Y/%m/%d'))             RESER_DAY                                                    ");
		sql.append("      , FN_BAS_LOAD_AGE(SYSDATE(), C.BIRTH, '')                AGE                                                                ");
		sql.append("      , DATE_FORMAT(C.BIRTH, '%Y/%m/%d')                   BIRTH                                                                  ");
		sql.append("      , C.SUNAME2                                                   SUNAME2                                                       ");
		sql.append("      , ' '                                           JUNDAL_PART                                                                 ");
		sql.append("      , ' '                                          RESER_MOVE_NAME                                                              ");
		sql.append("      , 'INJ'                                                       HANGMOG_CODE                                                  ");
		sql.append("      , ' '                                           JUNDAL_TABLE                                                                ");
		sql.append("      , cast( null as datetime)                                                        HOPE_DATE                                  ");
		sql.append("      , 99                                                          SEQ                                                           ");
		sql.append("      , '0'                                                 SORT                                                                  ");
		sql.append("   FROM OUT0101 C                                                                                                                 ");
		sql.append("      , INJ1001 A                                                                                                                 ");
		sql.append("      , INJ1002 B                                                                                                                 ");
		sql.append("  WHERE A.HOSP_CODE      = :hospCode                                                                                              ");
		sql.append("    AND B.HOSP_CODE      = A.HOSP_CODE                                                                                            ");
		sql.append("    AND C.HOSP_CODE      = A.HOSP_CODE                                                                                            ");
		sql.append("    AND A.BUNHO          = :f_bunho                                                                                               ");
		sql.append("    AND A.PKINJ1001      = B.FKINJ1001                                                                                            ");
		sql.append("    AND DATE_FORMAT(B.RESER_DATE,'%Y/%m/%d') = :f_reser_date                                                                      ");
		sql.append("    AND A.BUNHO          = C.BUNHO                                                                                                ");
		sql.append("    AND IFNULL(A.DC_YN,'N') = 'N'                                                                                                 ");
		sql.append("  UNION ALL                                                                                                                       ");
		sql.append(" SELECT  cast( null as char)                                        GWA                                                           ");
		sql.append("      , cast( null as char)                                                         GWA_NAME                                      ");
		sql.append("      , cast( null as char)                                                         BUNHO                                         ");
		sql.append("      , cast( null as char)                                                         SUNAME                                        ");
		sql.append("      , cast( null as datetime)                                                         RESER_DATE                                ");
		sql.append("      , A.BUSEO_NAME                                                HANGMOG_NAME                                                  ");
		sql.append("      , cast( null as char)                                                         RESER_TIME                                    ");
		sql.append("      , A.MOVE_COMMENT                                              MOVE_NAME                                                     ");
		sql.append("      , cast( null as char)                                                         RESER_DAY                                     ");
		sql.append("      , cast( null as char)                                                         AGE                                           ");
		sql.append("      , cast( null as char)                                                         BIRTH                                         ");
		sql.append("      , cast( null as char)                                                         SUNAME2                                       ");
		sql.append("      , cast( null as char)                                                         JUNDAL_PART                                   ");
		sql.append("      , ' '                                           RESER_MOVE_NAME                                                             ");
		sql.append("      , cast( null as char)                                                         HANGMOG_CODE                                  ");
		sql.append("      , cast( null as char)                                                         JUNDAL_TABLE                                  ");
		sql.append("      , cast( null as datetime)                                                         HOPE_DATE                                 ");
		sql.append("      , cast( null as decimal)                                                         SEQ                                        ");
		sql.append("      , 'Z'                                                         SORT                                                          ");
		sql.append("   FROM BAS0260 A                                                                                                                 ");
		sql.append("  WHERE A.HOSP_CODE      = :hospCode                                                                                              ");
		sql.append("    AND A.BUSEO_CODE = '51190' /* Accounting window */                                                                            ");
		sql.append("    AND A.LANGUAGE = :language                                                                                                    ");
		sql.append("  ORDER BY 19,18, 7                                                                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_date", reserDate);
		
		List<SCH0201U10LayReserInfo> listResult = new JpaResultMapper().list(query, SCH0201U10LayReserInfo.class);
		return listResult;
	}
	
	@Override
	public List<SCH0201U99ClinicLinkInfo> getLinkedClinic(String hospCodeLink, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT A.YOYANG_NAME,                    												");
		sql.append(" A.TEL, A.ADDRESS                     															");
		sql.append(" FROM BAS0001 A , OUT2016 B              														");
		sql.append(" WHERE A.HOSP_CODE = B.HOSP_CODE_LINK    														");
		sql.append(" AND  A.LANGUAGE = :language             														");
		sql.append(" AND B.HOSP_CODE_LINK = :hosp_code_Link  														");
		sql.append(" AND A.START_DATE = (SELECT MAX(C.START_DATE) FROM BAS0001 C WHERE C.HOSP_CODE = A.HOSP_CODE) 	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code_Link", hospCodeLink);
		query.setParameter("language", language);
		
		List<SCH0201U99ClinicLinkInfo> list = new JpaResultMapper().list(query, SCH0201U99ClinicLinkInfo.class);
		return list;
	}
	
	@Override
	public List<SCH0201U99PatientInfo> getSCH0201U99PatientInfo(String hospCode, String hospCodeLink, String bunhoLink) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SUNAME,  DATE_FORMAT(A.BIRTH,'%Y/%m/%d') BIRTH,                    ");
		sql.append(" DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(A.BIRTH, '%Y') AS AGE,               ");
		sql.append(" A.BUNHO                													 ");
		sql.append(" FROM OUT0101 A, OUT2016 B                                                   ");
		sql.append(" WHERE                                                    					 ");
		sql.append(" A.HOSP_CODE = B.HOSP_CODE                                               	 ");
		sql.append(" AND A.BUNHO = B.BUNHO                                               	 	 ");
		sql.append(" AND A.HOSP_CODE = :hospCode                                                 ");
		sql.append(" AND B.HOSP_CODE_LINK = :hospCodeLink                                        ");
		sql.append(" AND B.BUNHO_LINK = :bunhoLink                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hospCodeLink", hospCodeLink);
		query.setParameter("bunhoLink", bunhoLink);

		List<SCH0201U99PatientInfo> list = new JpaResultMapper().list(query, SCH0201U99PatientInfo.class);
		return list;
	}
	
	@Override
	public List<SCH0201U99ClinicInfo> getSCH0201U99ClinicInfo(String hospCode, String language, String bunhoLink, String hospCodeLink, String reserDate, String reserTime) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.YOYANG_NAME,           																			");
		sql.append("     B.GWA_NAME,              																	    		");
		sql.append("     C.DOCTOR_NAME  																                    	");
		sql.append("  FROM 	 BAS0001 A, BAS0260 B, BAS0271 C, OUT2016 D, SCH0201 E									    		");
		sql.append(" 	 WHERE 1 = 1  																							");
		sql.append(" 	 AND A.HOSP_CODE = B.HOSP_CODE  																		");
		sql.append(" 	 AND A.HOSP_CODE = C.HOSP_CODE    																		");
		sql.append(" 	 AND A.HOSP_CODE = D.HOSP_CODE	    																	");
		sql.append(" 	 AND A.HOSP_CODE = E.HOSP_CODE	    																	");
		sql.append(" 	 AND A.HOSP_CODE = :hospCode    																		");
		sql.append(" 	 AND A.START_DATE = (SELECT MAX(START_DATE) FROM BAS0001  C WHERE C.HOSP_CODE = B.HOSP_CODE) 	 		");
		sql.append(" 	 AND B.GWA = E.GWA    																					");
		sql.append(" 	 AND C.DOCTOR = E.GUMSAJA    																			");
		sql.append(" 	 AND D.BUNHO_LINK = :bunhoLink    																		");
		sql.append(" 	 AND D.HOSP_CODE_LINK = :hospCodeLink    																");
		sql.append(" 	 AND D.BUNHO = E.BUNHO	    																			");
		sql.append(" 	 AND E.RESER_YN = 'Y' and E.CANCEL_YN='N'		    													");
		sql.append(" 	 AND DATE_FORMAT(E.RESER_DATE, '%Y/%m/%d') = :reserDate			    									");
		sql.append(" 	 AND E.RESER_TIME = :reserTime                                                                  		");
		sql.append(" 	 AND B.LANGUAGE = :language                                                                     		");
		sql.append(" 	 AND A.LANGUAGE = :language                                                                     		");
 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunhoLink", bunhoLink);
		query.setParameter("hospCodeLink", hospCodeLink);
		query.setParameter("reserDate", reserDate);
		query.setParameter("reserTime", reserTime);
		
		List<SCH0201U99ClinicInfo> list = new JpaResultMapper().list(query, SCH0201U99ClinicInfo.class);
		return list;
	}
	
	@Override
	public List<SCH0201U99BookingInfo> getSCH0201U99BookingInfo(String hospCode, String language, String bunhoLink, String hospCodeLink, String hangmogCode, String reserDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT															          ");
		sql.append(" A.BUNHO_LINK,													          ");
		sql.append(" B.HANGMOG_NAME,													      ");
		sql.append(" DATE_FORMAT(C.RESER_DATE, '%Y/%m/%d'),								      ");
		sql.append(" C.RESER_TIME,													          ");
		sql.append(" D.MOVE_COMMENT													          ");
		sql.append(" FROM OUT2016 A, OCS0103 B, SCH0201 C, BAS0260 D					      ");
		sql.append(" WHERE	1 = 1													          ");
		sql.append(" 		AND A.BUNHO_LINK = :bunhoLink							          ");
		sql.append(" 		AND A.HOSP_CODE_LINK = :hospCodeLink					          ");
		sql.append(" 		AND A.HOSP_CODE = :hospCode								          ");
		sql.append(" 		AND C.BUNHO = A.BUNHO_LINK								          ");
		sql.append(" 		AND A.HOSP_CODE_LINK = C.HOSP_CODE						          ");
		sql.append(" 		AND C.OUT_HOSP_CODE = :hospCode							          ");
		sql.append(" 		AND B.HANGMOG_CODE = C.HANGMOG_CODE						          ");
		sql.append(" 		AND B.HOSP_CODE = C.HOSP_CODE						          	  ");
		sql.append(" 		AND C.HANGMOG_CODE = :hangmogCode                                 ");
		sql.append(" 		AND DATE_FORMAT(C.RESER_DATE, '%Y/%m/%d') = :reserDate            ");
		sql.append(" 		AND C.JUNDAL_PART = D.GWA								          ");
		sql.append(" 		AND D.LANGUAGE = :language								          ");
		sql.append(" 		AND D.HOSP_CODE = A.HOSP_CODE							          ");
		sql.append(" 		AND C.RESER_YN='Y' and C.CANCEL_YN='N'		                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunhoLink", bunhoLink);
		query.setParameter("hospCodeLink", hospCodeLink);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("reserDate", reserDate);

		List<SCH0201U99BookingInfo> list = new JpaResultMapper().list(query, SCH0201U99BookingInfo.class);
		return list;
	}
	
	@Override
	public String getBarcodeLinkedPatient(String bunhoLink) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 							");
		sql.append(" 	BUNHO_LINK						");
		sql.append(" FROM								");
		sql.append(" 		OUT2016						");
		sql.append(" WHERE								");
		sql.append(" 		BUNHO_LINK= :bunhoLink		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("bunhoLink", bunhoLink);
		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){
			return results.get(0);
		}		
		return null;
	}

	@Override
	public String callPrSchSch0210IudOther(String hospCode, String sessionHospCode, String iudGubun, String fksch0201,
			Date reserDate, String reserTime, String inputId, String ioErr) {
		LOGGER.info("[START] callPrSchSch0210Iud: hospCode"+ hospCode + ", iudGubun" + iudGubun + ", fksch0201" + fksch0201
				+ ", reserDate" + reserDate + ", reserTime" + reserTime + ", inputId" + inputId + ", ioErr" + ioErr);
		
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_SCH_SCH0201_IUD_OTHER");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SESION_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKSCH0201", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESER_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_RESER_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SESION_HOSP_CODE", sessionHospCode);
		query.setParameter("I_IUD_GUBUN", iudGubun);
		query.setParameter("I_FKSCH0201", CommonUtils.parseDouble(fksch0201));
		query.setParameter("I_RESER_DATE", reserDate);
		if(!StringUtils.isEmpty(reserTime)){
			query.setParameter("I_RESER_TIME", reserTime);
		}else{
			query.setParameter("I_RESER_TIME", null);
		}
		query.setParameter("I_INPUT_ID", inputId);
		query.setParameter("IO_ERR", ioErr);
		query.execute();
		
		String result = (String)query.getOutputParameterValue("IO_ERR");
		return result;
	}

	@Override
	public void callSchsSCH0201Q04PrSchTimeListOther(String hospCode, String sessionHospCode, String ipAddress,
			String jundalTable, String jundalPart, String gumsaja, String reserDate) {
		LOGGER.info("[START] callSchsSCH0201Q04PrSchTimeList  hospCode =" + hospCode + ", ipAddress=" + ipAddress + ", jundalTable=" + jundalTable + ","
				+ " jundalPart=" + jundalPart + ", gumsaja=" + gumsaja + ", reserDate=" + reserDate);
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_SCH_TIME_LIST_OTHER");
		query.registerStoredProcedureParameter("I_HOSPCODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SESION_HOSPCODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IP_ADDRESS", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUNDAL_TABLE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUNDAL_PART", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_GUMSAJA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESER_DATE", Date.class, ParameterMode.IN);
		
		query.setParameter("I_HOSPCODE", hospCode);
		query.setParameter("I_SESION_HOSPCODE", sessionHospCode);
		query.setParameter("I_IP_ADDRESS", ipAddress);
		query.setParameter("I_JUNDAL_TABLE", jundalTable);
		query.setParameter("I_JUNDAL_PART", jundalPart);
		query.setParameter("I_GUMSAJA", gumsaja);
		query.setParameter("I_RESER_DATE", DateUtil.toDate(reserDate, DateUtil.PATTERN_YYMMDD));
		
		query.execute();
	}
	

	public boolean isOrderEffected(String hospCode, String hangmogCode, String reserDate)
	{
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y' FROM OCS0103 where HANGMOG_CODE= :hangmogCode AND HOSP_CODE= :hospCode AND COMMON_YN = 'Y' AND   		");
		sql.append(" IFNULL(STR_TO_DATE( :reserDate, '%Y/%m/%d'), SYSDATE()) BETWEEN START_DATE AND IFNULL(END_DATE, SYSDATE())         ");

		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("reserDate", reserDate);

		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){
			return results.get(0).equals("Y");
		}
		return false;
	}
	@Override
	public String getSchTotalInWon(String hospCode, String jundalTable, String jundalPart, String reserDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_SCH_TOTAL_INWON(:hospCode,:jundalTable, :jundalPart, STR_TO_DATE(:reserDate, '%Y/%m/%d')) INWON  ");
		          
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalTable", jundalTable);
		query.setParameter("jundalPart", jundalPart);
		query.setParameter("reserDate", reserDate);
		
		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){
			return results.get(0);
		}		
		return null;
	}
	@Override
	public String getSchTotalInWonByTime(String hospCode, String jundalTable, String jundalPart, String reserDate, String reserTime) {

		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_SCH_TOTAL_INWON_BY_TIME(:hospCode,:jundalTable, :jundalPart, STR_TO_DATE(:reserDate, '%Y/%m/%d'), :reserTime ) INWON  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalTable", jundalTable);
		query.setParameter("jundalPart", jundalPart);
		query.setParameter("reserDate", reserDate);
		query.setParameter("reserTime", reserTime);

		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){
			return results.get(0);
		}
		return null;
	}
	@Override
	public String getSchTotalOutWon(String hospCode, String jundalTable, String jundalPart, String reserDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_SCH_TOTAL_OUTWON(:hospCode,:jundalTable, :jundalPart, STR_TO_DATE(:reserDate, '%Y/%m/%d')) OUTWON  ");
		          
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalTable", jundalTable);
		query.setParameter("jundalPart", jundalPart);
		query.setParameter("reserDate", reserDate);
		
		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){
			return results.get(0);
		}		
		return null;
	}
	public String getSchTotalOutWonByTime(String hospCode, String jundalTable, String jundalPart, String reserDate,String reserTime)
	{
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_SCH_TOTAL_OUTWON_BY_TIME(:hospCode,:jundalTable, :jundalPart, STR_TO_DATE(:reserDate, '%Y/%m/%d'), :reserTime) OUTWON  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalTable", jundalTable);
		query.setParameter("jundalPart", jundalPart);
		query.setParameter("reserDate", reserDate);
		query.setParameter("reserTime", reserTime);

		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){
			return results.get(0);
		}
		return null;
	}
	@Override
	public Double getPkSCH0101ByFkOcs(String fkOCS, String hangmogCode)
	{
		StringBuilder sql = new StringBuilder();

		sql.append(" SELECT PKSCH0201 from SCH0201 where FKOCS = :fkOCS and HANGMOG_CODE =:hangmogCode order by ID DESC");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("fkOCS", fkOCS);
		query.setParameter("hangmogCode", hangmogCode);

		List<Double> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){

			return results.get(0);
		}
		return null;
	}
	public Sch0201 getPkSCH0101ByFkOcs(Double fkOCS, String hangmogCode, String hospCode)
	{
		StringBuilder sql = new StringBuilder();

		sql.append(" SELECT a from Sch0201 a where a.fkocs = :fkOCS and a.hangmogCode =:hangmogCode and a.hospCode = :hospCode AND a.cancelYn = 'N' order by a.id DESC");
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("fkOCS", fkOCS);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("hospCode", hospCode);

		List<Sch0201> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){

			return results.get(0);
		}
		return null;
	}


	public List<Sch0201> findByFkOscAndHangCodeAndHospCode(Double fkOCS, String hangmogCode, String hospCode)
	{
		StringBuilder sql = new StringBuilder();

		sql.append(" SELECT a from Sch0201 a where a.fkocs = :fkOCS and a.hangmogCode =:hangmogCode and a.hospCode = :hospCode order by a.id ASC");
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("fkOCS", fkOCS);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("hospCode", hospCode);

		return query.getResultList();

	}
	public String isExistBookingDate(String reserDate, Double fkOCS, String hangmogCode, String hospCode)
	{
		StringBuilder sql = new StringBuilder();

		sql.append(" SELECT 'Y' from SCH0201  where FKOCS = :fkOCS and HANGMOG_CODE =:hangmogCode and HOSP_CODE = :hospCode  ");
		sql.append("   AND RESER_TIME IS NOT NULL AND CANCEL_YN = 'N'  order by ID DESC ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("fkOCS", fkOCS);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("hospCode", hospCode);

		List<String> results = query.getResultList();
		if(!CollectionUtils.isEmpty(results)){

			return results.get(0);
		}
		return "N";
	}
}

