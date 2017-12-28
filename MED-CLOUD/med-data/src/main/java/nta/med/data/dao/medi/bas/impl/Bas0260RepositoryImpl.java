package nta.med.data.dao.medi.bas.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0260DepartmentInfo;
import nta.med.data.model.ihis.bass.BAS0260GrdBuseoListItemInfo;
import nta.med.data.model.ihis.bass.Inp1003U00FwkGwaListItemInfo;
import nta.med.data.model.ihis.bass.LoadGrdBAS0260U01Info;
import nta.med.data.model.ihis.bass.WaitingPatientInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00GetSpecimenInfoListItemInfo;
import nta.med.data.model.ihis.inps.INP1003U00fwkGwaInfo;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangeddtGwaInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetDepartmentInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003R02LayR03ListItemInfo;
import nta.med.data.model.ihis.ocso.OUTSANGU00findBoxToDoctorInfo;
import nta.med.data.model.ihis.ocso.OUTSANGU00findBoxToGwaInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayJinryoGwaInfo;
import nta.med.data.model.ihis.system.BuseoInfo;
import nta.med.data.model.ihis.system.FormGwaItemInfo;
import nta.med.data.model.ihis.system.HIOcsCheckJundalPartLoadJaeryoJundalInfo;
import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * @author dainguyen.
 */
public class Bas0260RepositoryImpl implements Bas0260RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> generateNuroDeparmentList(String language, String hospCode){
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT '%', FN_ADM_MSG('221',:language)                                                     ");
		sql.append("UNION                                                                                         ");
		sql.append("SELECT A.GWA, A.GWA_NAME                                                                      ");
		sql.append("  FROM BAS0260 A                                                                              ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode AND A.BUSEO_GUBUN = '1' AND A.LANGUAGE = :language      ");
		sql.append("       AND A.START_DATE =                                                                     ");
		sql.append("              (SELECT MAX(Z.START_DATE)                                                       ");
		sql.append("                 FROM BAS0260 Z                                                               ");
		sql.append("                WHERE     Z.HOSP_CODE = A.HOSP_CODE                                           ");
		sql.append("                      AND Z.BUSEO_CODE = A.BUSEO_CODE                                         ");
		sql.append("                      AND Z.START_DATE <= DATE_FORMAT(SYSDATE(), '%Y-%m-%d'))                 ");
		sql.append("ORDER BY 1                                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getComboDepartmentItemInfo(String language, String hospCode, Date comingDate, boolean isAll) {
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append("SELECT '%', FN_ADM_MSG('221', :language)                                         ");                                      
			sql.append("UNION                                                                            ");
		}
		sql.append("SELECT GWA, GWA_NAME                                                             ");
		sql.append("        FROM BAS0260                                                             ");
		sql.append("        WHERE HOSP_CODE = :hospCode		                                         ");
		sql.append("        AND LANGUAGE = :language                                                 ");
		sql.append("        AND BUSEO_GUBUN = '1'                                                    ");
		if (comingDate != null) {
			sql.append("   AND  :comingDate  BETWEEN START_DATE AND END_DATE                 ");
		}
		sql.append("        ORDER BY 1                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		if (comingDate != null) {
			query.setParameter("comingDate", comingDate);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getNuroRES0102U00CboGwa(String language, String hospCode, String appDate){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.GWA,                                              											");                           
		sql.append("	       A.GWA_NAME                                                                                   ");
		sql.append("	FROM BAS0260 A                                                                                      ");
		sql.append("	WHERE A.HOSP_CODE    = :hospCode                                                                    ");
		sql.append("	  AND A.LANGUAGE = :language                                                                        ");
		sql.append("	  AND A.OUT_JUBSU_YN = 'Y'                                                                          ");
		sql.append("	  AND A.BUSEO_GUBUN = '1'                                                                           ");
		sql.append("	  AND DATE_FORMAT(:appDate, '%Y/%m/%d')                                                             ");
		sql.append("	      BETWEEN A.START_DATE AND IFNULL(A.END_DATE, DATE_FORMAT('9998/12/31', '%Y/%m/%d'))            ");
		sql.append("	ORDER BY A.GWA                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		query.setParameter("appDate", appDate);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<NuroOUT1001U01GetDepartmentInfo> getNuroOUT1001U01GetDepartmentInfo(String language, String hospCode, String buseoYmd, String buseoGubun, String find1){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.GWA                                                                                ");
		sql.append("      , A.GWA_NAME                                                                          ");
		sql.append("      , A.BUSEO_CODE                                                                        ");
		sql.append("   FROM BAS0260 A                                                                           ");
		sql.append("  WHERE A.HOSP_CODE   = :hospCode                                                        ");
		sql.append("    AND A.LANGUAGE = :language                                                            ");
		sql.append("    AND A.BUSEO_GUBUN = :buseoGubun  /*진료과*/                                                     ");
		sql.append("     AND DATE_FORMAT(:buseoYmd,'%Y/%m/%d')  BETWEEN A.START_DATE AND A.END_DATE          ");
		sql.append("    AND(A.GWA         LIKE :find1                                                         ");
		sql.append("     OR A.GWA_NAME    LIKE :find1 )                                                       ");
		sql.append("  ORDER BY A.GWA                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		query.setParameter("buseoYmd", buseoYmd);
		query.setParameter("buseoGubun", buseoGubun);
		query.setParameter("find1", "%"+find1+"%");
		
		List<NuroOUT1001U01GetDepartmentInfo> list = new JpaResultMapper().list(query, NuroOUT1001U01GetDepartmentInfo.class);
		return list;
	}
	
	@Override
	public List<OcsoOCS1003P01LayJinryoGwaInfo> getOcsoOCS1003P01LayJinryoGwaInfo(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
	    sql.append("SELECT A.GWA, A.GWA_NAME                                                                             ");
	    sql.append("  FROM VW_BAS_GWA A                                                                                  ");
	    sql.append(" WHERE A.OUT_JUBSU_YN = 'Y'                                                                          ");
	    sql.append("   AND A.START_DATE = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, DATE_FORMAT(SYSDATE(),'%Y/%m/%d'),:hospCode) ");
	    sql.append("   AND A.HOSP_CODE  = :hospCode                                                                      ");
	    sql.append("   AND A.LANGUAGE = :language                                                                        ");
	    sql.append(" UNION                                                                                               ");
	    sql.append("SELECT '%' as GWA, FN_ADM_MSG(221, :language) as GWA_NAME                                            ");
	    sql.append("ORDER BY GWA                                                                                         ");
	    
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		
		List<OcsoOCS1003P01LayJinryoGwaInfo> list = new JpaResultMapper().list(query, OcsoOCS1003P01LayJinryoGwaInfo.class);
		return list;
	}
	
	public String getBasLoadGwaName(String gwa, String buseoYmd, String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_GWA_NAME(:gwa, STR_TO_DATE(:buseoYmd,'%Y/%m/%d'), :hospCode, :language)  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("gwa", gwa);
		query.setParameter("buseoYmd", buseoYmd);
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		
		List object = query.getResultList();
		if(object != null){
			return object.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<BuseoInfo> getBuseoInfo(String hospCode,String language, String buseoGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUSEO_CODE BUSEO_CODE, A.BUSEO_NAME BUSEO_NAME  ");
		sql.append("FROM VW_GWA_NAME A                                                      ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                                        ");
		sql.append("AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                       ");
		sql.append("AND LANGUAGE = :language                                              ");
		sql.append("AND A.BUSEO_GUBUN = :buseoGubun                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("buseoGubun", buseoGubun);
		
		List<BuseoInfo> list = new JpaResultMapper().list(query, BuseoInfo.class);
		return list;
	}

	@Override
	public String getOcsaOCS0503Q00DepartmentNameList(String hospCode, String language, String gwa){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA_NAME                                                                                                  ");
		sql.append("   FROM VW_GWA_NAME A                                                                                                ");
		sql.append("  WHERE A.HOSP_CODE       = :f_hosp_code                                                                            ");
		sql.append("    AND ( A.OUT_JUBSU_YN  = 'Y'  OR A.IPWON_YN = 'Y' )                                                              ");
		sql.append("    AND A.START_DATE      = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), :f_hosp_code )    ");
		sql.append("    AND A.GWA = :f_gwa                                                                                             ");
		sql.append("    AND A.LANGUAGE = :f_language                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_gwa", gwa);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public List<ComboListItemInfo> getOcsaOCS0503Q00DepartmentList(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.GWA, A.GWA_NAME                                                                                          ");
		sql.append("    FROM VW_GWA_NAME A                                                                                               ");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code                                                                              ");
		sql.append("     AND A.START_DATE   = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), :f_hosp_code )      ");
		sql.append("     AND A.OUT_JUBSU_YN = 'Y'                                                                                       ");
		sql.append("     AND A.LANGUAGE = :f_language                                                                                   ");
		sql.append("   ORDER BY A.GWA                                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getComboListItemOcsaOCS0204U00CommonData(String hospCode, String language, String sabun){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.DOCTOR_GWA, B.GWA_NAME                                                                                         ");
		sql.append("   FROM BAS0272 A, BAS0260 B                                                                                             ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                       ");
		sql.append("	AND A.SABUN = :f_sabun                                                                                               ");
		sql.append("	AND B.HOSP_CODE = A.HOSP_CODE                                                                                        ");
		sql.append("	AND B.LANGUAGE = :f_language                                                                                         ");
		sql.append("	AND A.DOCTOR_GWA = B.GWA                                                                                             ");
		sql.append("	AND DATE_FORMAT(SYSDATE(),'%Y%m%d') BETWEEN B.START_DATE AND IFNULL(B.END_DATE, DATE_FORMAT('99981231', '%Y%m%d'))   ");
		sql.append("  ORDER BY CONCAT(IF(IFNULL(A.MAIN_GWA_YN, 'N') = 'Y', '0', '9') , A.DOCTOR_GWA)                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_sabun", sabun);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getOcsaOCS0150U00DepartmentList(String hospCode, String language, String fMemb){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT '%', FN_ADM_MSG('221',:f_language)                                                                                  ");        
		sql.append("  UNION ALL                                                                                                                ");
		sql.append(" SELECT A.DOCTOR_GWA, B.GWA_NAME                                                                                           ");
		sql.append("   FROM BAS0272 A                                                                                                          ");
		sql.append("      , BAS0260 B                                                                                                          ");
		sql.append("  WHERE A.HOSP_CODE  = :f_hosp_code                                                                                        ");
		sql.append("    AND A.SABUN      = :f_memb                                                                                             ");
		sql.append("    AND B.HOSP_CODE  = A.HOSP_CODE                                                                                         ");
		sql.append("    AND B.LANGUAGE = :f_language                                                                                           ");
		sql.append("    AND A.DOCTOR_GWA = B.GWA                                                                                               ");
		sql.append("    AND DATE_FORMAT(SYSDATE(),'%Y%m%d') BETWEEN B.START_DATE AND IFNULL(B.END_DATE, DATE_FORMAT('99981231', '%Y%m%d'))     ");
		sql.append("    AND DATE_FORMAT(SYSDATE(),'%Y%m%d') BETWEEN A.START_DATE AND IFNULL(A.END_DATE, DATE_FORMAT('99981231', '%Y%m%d'))     ");
		sql.append("  ORDER BY 1                                                                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_memb", fMemb);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public String getSchsSCH0201U99GetGwaName(String hospCode, String gwa,
			Date today) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_BAS_LOAD_GWA_NAME(:gwa, :today,:hospCode, 'JA') GWA_NAME;");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("gwa", gwa);
		query.setParameter("today", today);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	public String getSCH0201U99GetJundalPartName(String hospCode,
			String ioGubun, String jundalPart, Date today) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_BAS_LOAD_JUNDAL_PART_NAME(:hospCode, :ioGubun,:jundalPart,:today);");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("jundalPart", jundalPart);
		query.setParameter("today", today);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<ComboListItemInfo> getOCS0301U00CboDoctorGwa(String hospCode, String language, String userId){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT '%', FN_ADM_MSG(4295,:language)                           ");
		sql.append("UNION ALL                                                        ");
		sql.append("SELECT A.DOCTOR_GWA, B.GWA_NAME                                  ");
		sql.append("  FROM BAS0272 A                                                 ");
		sql.append("     , BAS0260 B                                                 ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                   ");
		sql.append("   AND B.LANGUAGE = :language                                    ");
		if (!StringUtils.isEmpty(userId))
			sql.append("   AND A.SABUN = :userId                                         ");
		sql.append("   AND A.START_DATE <= ( SELECT MAX(X.START_DATE)                 ");
		sql.append("                          FROM BAS0272 X                         ");
		sql.append("                         WHERE X.HOSP_CODE = A.HOSP_CODE         ");
		sql.append("                           AND X.SABUN = A.SABUN                 ");
		sql.append("                           AND X.START_DATE <= SYSDATE() AND X.END_DATE >= SYSDATE())       ");
		sql.append("   AND B.HOSP_CODE  = A.HOSP_CODE                                ");
		sql.append("   AND B.GWA        = A.DOCTOR_GWA                               ");
		sql.append("   AND B.START_DATE <= ( SELECT MAX(Z.START_DATE)                 ");
		sql.append("                          FROM BAS0260 Z                         ");
		sql.append("                         WHERE Z.HOSP_CODE  = B.HOSP_CODE        ");
		sql.append("                           AND Z.BUSEO_CODE = B.BUSEO_CODE       ");
		sql.append("                           AND Z.START_DATE <= SYSDATE() AND Z.END_DATE >= SYSDATE())       ");
		sql.append(" ORDER BY 1                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		if (!StringUtils.isEmpty(userId))
			query.setParameter("userId", userId);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<TripleListItemInfo> getOCS0301U00CboGwa(String hospCode, String language, String find, String queryMode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'ADMIN', FN_ADM_MSG(4295,:language),  cast(1 as char)    ");
		sql.append("FROM DUAL                                                       ");
		sql.append(" WHERE :queryMode = '0'              	                        ");
		sql.append(" UNION ALL                                                      ");
		sql.append("SELECT A.GWA, A.GWA_NAME,  cast(2 as char)                      ");
		sql.append("  FROM BAS0260 A                                                ");
		sql.append(" WHERE A.HOSP_CODE   = :hospCode 	                            ");
		sql.append("   AND :queryMode = '0'                 	                    ");
		sql.append("   AND A.LANGUAGE = :language                                   ");
		sql.append("   AND A.GWA IS NOT NULL                                        ");
		sql.append("   AND A.START_DATE = ( SELECT MAX(Z.START_DATE)                ");
		sql.append("                          FROM BAS0260 Z                        ");
		sql.append("                         WHERE Z.HOSP_CODE  = A.HOSP_CODE       ");
		sql.append("                           AND Z.BUSEO_CODE = A.BUSEO_CODE      ");
		sql.append("                           AND Z.START_DATE <= SYSDATE() )      ");
		if (!StringUtils.isEmpty(find)) {
			find += "%";
			sql.append("   AND A.GWA_NAME LIKE :find                                ");
		}
		sql.append(" UNION ALL                                                      ");
		sql.append("SELECT A.USER_ID, B.USER_NM, cast(3 as char)                    ");
		sql.append("  FROM ADM3200 A, ADM3211 B                                     ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode	                                ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                ");
		sql.append("   AND B.USER_ID   = A.USER_ID                                  ");
		sql.append("   AND B.START_DATE = ( SELECT MAX(X.START_DATE)                ");
		sql.append("                          FROM ADM3211 X                        ");
		sql.append("                         WHERE X.HOSP_CODE = B.HOSP_CODE        ");
		sql.append("                           AND X.USER_ID   = B.USER_ID          ");
		sql.append("                           AND X.START_DATE <= SYSDATE() )      ");
		if (!StringUtils.isEmpty(find)) {
			sql.append("   AND B.USER_NM LIKE :find                                 ");
		}
		sql.append("ORDER BY 3, 1                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("queryMode", queryMode);
		if (!StringUtils.isEmpty(find)) {
			query.setParameter("find", find);
		}
		
		List<TripleListItemInfo> list = new JpaResultMapper().list(query, TripleListItemInfo.class);
		return list;
	}

	@Override
	public List<OUTSANGU00findBoxToGwaInfo> getOUTSANGU00findBoxToGwaInfo(
			String hospCode, Date startDate, String find, String language) {
		StringBuilder sql = new StringBuilder();
		 sql.append("	SELECT A.GWA																			");
		 sql.append("	     , A.GWA_NAME                                                                       ");
		 sql.append("	     , A.BUSEO_CODE                                                                     ");
		 sql.append("	FROM BAS0260 A                                                                          ");
		 sql.append("	WHERE A.HOSP_CODE = :hospCode                                                        	");
		 sql.append("	AND A.BUSEO_GUBUN = '1'                                                                 ");
		 sql.append("	AND A.START_DATE = ( SELECT MAX(B.START_DATE)                                           ");
		 sql.append("	                      FROM BAS0260 B                                                    ");
		 sql.append("	                      WHERE B.HOSP_CODE   = A.HOSP_CODE                                 ");
		 sql.append("	                      AND B.GWA         = A.GWA                                         ");
		 sql.append("	                      AND B.START_DATE <= :startDate)                               	 ");
		 sql.append("	AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) > :startDate          	 ");
		 sql.append("   AND A.LANGUAGE = :language                                   ");
		 sql.append("	AND(A.GWA       LIKE CONCAT( '%' , :find , '%')                                     	 ");
		 sql.append("	 OR A.GWA_NAME  LIKE CONCAT( '%' , :find , '%'))                                    	 ");
		 sql.append("	ORDER BY A.GWA																			");
		 
		 Query query = entityManager.createNativeQuery(sql.toString());
	     query.setParameter("hospCode", hospCode);
	     query.setParameter("startDate", startDate);
	     query.setParameter("language", language);
	     query.setParameter("find", find);
	     
		 List<OUTSANGU00findBoxToGwaInfo> listResult = new JpaResultMapper().list(query, OUTSANGU00findBoxToGwaInfo.class);
		 return listResult;
			
	}

	@Override
	public List<OUTSANGU00findBoxToDoctorInfo> getOUTSANGU00findBoxToDoctorInfo(
			String hospCode, String gwa, String find, Date doctorYmd) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.DOCTOR																			");
		sql.append("	         , A.DOCTOR_NAME                                                                ");
		sql.append("	         , CONCAT(A.SORT_KEY , A.DOCTOR)            CONT_KEY                            ");
		sql.append("	 FROM BAS0270 A                                                                         ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                                                       	");
		sql.append("	 AND IF(:gwa = '%', '%', A.DOCTOR_GWA)   = :gwa                                    	    ");
		sql.append("	 AND  (A.DOCTOR       LIKE CONCAT('%' , :find , '%')                                 	");
		sql.append("	                 OR A.DOCTOR_NAME  LIKE CONCAT('%' , :find , '%'))                   	");
		sql.append("	 AND A.START_DATE = ( SELECT MAX(B.START_DATE)                                          ");
		sql.append("	                       FROM BAS0270 B                                                   ");
		sql.append("	                       WHERE B.HOSP_CODE   = A.HOSP_CODE                                ");
		sql.append("	                       AND B.DOCTOR      = A.DOCTOR                                     ");
		sql.append("	                       AND B.START_DATE <= :doctorYmd )                             	");
		sql.append("	 AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) >    :doctorYmd      	 ");                                    
		sql.append("	 ORDER BY CONT_KEY;                                                                     ");
		
		 Query query = entityManager.createNativeQuery(sql.toString());
	     query.setParameter("hospCode", hospCode);
	     query.setParameter("gwa", gwa);
	     query.setParameter("find", find);
	     query.setParameter("doctorYmd", doctorYmd);
	     
	     List<OUTSANGU00findBoxToDoctorInfo> listResult = new JpaResultMapper().list(query, OUTSANGU00findBoxToDoctorInfo.class);
		 return listResult;
	}

	@Override
	public String getOUTSANGU00GwaName(String hospCode, Date startDate,
			String find, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT A.GWA_NAME																		");
		sql.append("	FROM BAS0260 A                                                                          ");
		sql.append("	WHERE A.HOSP_CODE = :hospCode                                                        	");
		sql.append("	AND A.BUSEO_GUBUN = '1'                                                                 ");
		sql.append("	AND A.LANGUAGE = :language                                                              ");
		sql.append("	AND A.START_DATE = ( SELECT MAX(B.START_DATE)                                           ");
		sql.append("	                      FROM BAS0260 B                                                    ");
		sql.append("	                      WHERE B.HOSP_CODE   = A.HOSP_CODE                                 ");
		sql.append("	                      AND B.GWA         = A.GWA                                         ");
		sql.append("	                      AND B.START_DATE <= :startDate)                                   ");
		sql.append("	AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) > :startDate          	");
		sql.append("	AND(A.GWA       LIKE CONCAT( '%' , :find , '%')                                     	");
		sql.append("	 OR A.GWA_NAME  LIKE CONCAT( '%' , :find , '%'))                                    	");
		sql.append("	ORDER BY A.GWA																			");
				 
		 Query query = entityManager.createNativeQuery(sql.toString());
	     query.setParameter("hospCode", hospCode);
	     query.setParameter("startDate", startDate);
	     query.setParameter("find", find);
	     query.setParameter("language", language);
		
	     List<String> listResult = query.getResultList();
			if(listResult != null && !listResult.isEmpty()){
				return listResult.get(0);
			}
			return null;
	}


	@Override
	public List<CPL3020U00GetSpecimenInfoListItemInfo> getCPL3020U00GetSpecimenInfo(
			String gwa, String orderDate, String hoDong, String hospCode,
			String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT FN_BAS_LOAD_GWA_NAME(TRIM(:gwa),STR_TO_DATE(:orderDate,'%Y/%m/%d'),:hospCode, :language)       GWA_NAME			");	
		sql.append("	  , FN_BAS_LOAD_GWA_NAME(TRIM(:hoDong) ,STR_TO_DATE(:orderDate,'%Y/%m/%d'),:hospCode, :language)   HO_DONG_NAME         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("gwa", gwa);
	    query.setParameter("orderDate", orderDate);
	    query.setParameter("hoDong", hoDong);
	    query.setParameter("hospCode", hospCode);
	    query.setParameter("language", language);
	    
	    List<CPL3020U00GetSpecimenInfoListItemInfo> listResult = new JpaResultMapper().list(query, CPL3020U00GetSpecimenInfoListItemInfo.class);
		 return listResult;
	}

	@Override
	public List<ComboListItemInfo> getSchsSCH0201Q02JundalComboList(String hospCode, String language, boolean isAndDate , boolean isAll, boolean isOutMoveYn) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT GWA, GWA_NAME FROM BAS0260                                                                ");
		sql.append(" WHERE HOSP_CODE   = :f_hosp_code AND LANGUAGE = :f_language  AND GWA IS NOT NULL                 ");
		sql.append("     AND USE_YN = 'Y'                                                                             "); 
		if(isAndDate){
			sql.append(" AND SYSDATE() BETWEEN START_DATE AND END_DATE                                                ");
		}
		if(isOutMoveYn){
			sql.append(" AND OUT_MOVE_YN = 'Y'                                                                       ");
		}else{
			sql.append(" AND BUSEO_GUBUN = '1'                                                                            ");
		}
		if(isAll){
			sql.append(" UNION ALL                                                                                    ");
			sql.append(" SELECT '%', FN_ADM_MSG(221,:f_language)              						                ");
		}
		sql.append(" ORDER BY 1                                                                                      ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> listInfo= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}
	

	@Override
	public List<ComboListItemInfo> getSCH0201Q12CboDepartmentList(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT '%', FN_ADM_MSG(221,:language)																");
		sql.append(" UNION                                                                                              ");
		sql.append(" SELECT A.GWA, A.GWA_NAME                                                                           ");
		sql.append(" FROM BAS0260 A                                                                                     ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                                                   ");
		sql.append("   AND A.BUSEO_GUBUN = '1'                                                                          ");
		sql.append("   AND A.LANGUAGE = :language                                                                       ");
		sql.append("   AND A.START_DATE = ( SELECT MAX(Z.START_DATE)                                                    ");
		sql.append("                            FROM BAS0260 Z                                                          ");
		sql.append("                           WHERE Z.HOSP_CODE = A.HOSP_CODE                                          ");
		sql.append("                 AND Z.BUSEO_CODE = A.BUSEO_CODE                                                    ");
		sql.append("                            AND Z.START_DATE <= DATE_FORMAT(SYSDATE() ,'%Y-%m-%d') )                ");
		sql.append("  ORDER BY 1                                                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<BAS0260GrdBuseoListItemInfo> getBas0260U00grdBuseoInitListItem(
			String hospCode, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.BUSEO_CODE																			");			
		sql.append("	     , A.BUSEO_NAME                                                                         ");
		sql.append("	     , A.PARENT_BUSEO                                                                       ");
		sql.append("	     , A.BUSEO_GUBUN                                                                        ");
		sql.append("	     , A.GWA_GUBUN                                                                          ");
		sql.append("	     , A.GWA                                                                                ");
		sql.append("	     , A.GWA_NAME                                                                           ");
		sql.append("	     , A.PARENT_GWA                                                                         ");
		sql.append("	     , A.OUT_JUBSU_YN                                                                       ");
		sql.append("	     , A.IPWON_YN                                                                           ");
		sql.append("	     , A.OUT_SLIP_YN                                                                        ");
		sql.append("	     , A.INP_SLIP_YN                                                                        ");
		sql.append("	     , A.EURYOSEO_YN                                                                        ");
		sql.append("	     , A.OUT_MOVE_YN                                                                        ");
		sql.append("	     , A.OUT_JUNDAL_PART_YN                                                                 ");
		sql.append("	     , A.INP_JUNDAL_PART_YN                                                                 ");
		sql.append("	     , A.INPUT_GUBUN                                                                        ");
		sql.append("	     , A.MOVE_COMMENT                                                                       ");
		sql.append("	     , A.TEL                                                                                ");
		sql.append("	     , A.GWA_ENAME                                                                          ");
		sql.append("	     , A.GWA_SNAME                                                                          ");
		sql.append("	     , A.GWA_SORT1                                                                          ");
		sql.append("	     , A.GWA_SORT2                                                                          ");
		sql.append("	     , A.RMK                                                                                ");
		sql.append("	     , A.END_DATE                                                                           ");
		sql.append("	     , A.START_DATE                                                                         ");
		sql.append("	     , A.BUSEO_NAME2                                                                        ");
		sql.append("	     , A.GWA_COLOR                                                                          ");
		sql.append("	     , A.HPC_HO_DONG_YN                                                                     ");
		sql.append("	     , A.ADD_DOCTOR                                                                         ");
		sql.append("	     , A.GWA_NAME_KANA                                                                      ");
		sql.append("	     , ''                                                                                   ");
		sql.append("	     , A.USE_YN                                                                             ");
		sql.append("	  FROM BAS0260 A                                                                            ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                                                              ");
		sql.append("	   AND STR_TO_DATE(:startDate, '%Y/%m/%d') BETWEEN A.START_DATE                             ");
		sql.append("	                                               AND A.END_DATE                               ");
		sql.append("	   AND LANGUAGE = :language              						                            ");
		sql.append("	 ORDER BY A.HOSP_CODE, A.BUSEO_CODE, A.START_DATE                                           ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("startDate", startDate);
		query.setParameter("language", language);
		
		List<BAS0260GrdBuseoListItemInfo> listInfo= new JpaResultMapper().list(query, BAS0260GrdBuseoListItemInfo.class);
		return listInfo;
	}

	@Override
	public String getBas0260U00LayDupCheck(String hospCode, String code,
			String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y' 																	");
		sql.append("	FROM BAS0260 A                                                              ");
		sql.append("	WHERE A.HOSP_CODE  = :hospCode                                           ");
		sql.append("	AND A.BUSEO_CODE = :code                                                  ");
		sql.append("	AND STR_TO_DATE(:startDate, '%Y/%m/%d') BETWEEN A.START_DATE             ");
		sql.append("	                                                AND A.END_DATE              ");
		sql.append("	AND A.LANGUAGE = :language ;                                                ");
		

		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		query.setParameter("startDate", startDate);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && StringUtils.isEmpty(result.get(0))){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getBas0260U00TransactionUpdatecheck(String hospCode,
			String buseoCode, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y' 																		 ");
		sql.append("	FROM BAS0260 A                                                                   ");
		sql.append("	WHERE A.HOSP_CODE  = :hospCode                                                   ");
		sql.append("	AND A.BUSEO_CODE = :buseoCode                                                    ");
		sql.append("	AND A.START_DATE <> STR_TO_DATE(:startDate, '%Y/%m/%d')                          ");
		sql.append("	AND STR_TO_DATE(:startDate, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE      ");
		sql.append("	AND A.LANGUAGE = :language                                                       ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("buseoCode", buseoCode);
		query.setParameter("startDate", startDate);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && !StringUtils.isEmpty(result.get(0))){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getOCS1003P01ChangeUserInfo(String hospCode, String gwa,
			String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.GWA_NAME										");
		sql.append("	FROM BAS0260 A                                          ");
		sql.append("	WHERE A.HOSP_CODE = :hospCode                        ");
		sql.append("	  AND A.GWA   = :gwa                                  ");
		sql.append("	AND A.LANGUAGE = :language                               ");
		sql.append("	  AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE     ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("gwa", gwa);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && !StringUtils.isEmpty(result.get(0))){
			return result.get(0).toString();
		}
		return null;
	}

	
	@Override
	public List<ComboListItemInfo> getComboUserInfoCheckUserSubDoctor(String hospCode, String language, String gwa){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUSEO_CODE, A.BUSEO_NAME   ");
		sql.append("   FROM BAS0260 A                   ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code  ");
		sql.append("    AND A.LANGUAGE = :f_language    ");
		sql.append("    AND A.GWA = :f_gwa              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_gwa", gwa);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<FormGwaItemInfo> getFormGwaItemInfo(String hospCode, String language, String userId, boolean isLimit){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR                                       ");
		sql.append("   , A.DOCTOR_GWA                                     ");
		sql.append("   , B.GWA_NAME                                       ");
		sql.append("FROM BAS0260 B                                        ");
		sql.append("   , BAS0270 A                                        ");
		sql.append("WHERE A.HOSP_CODE = :f_hosp_code                      ");
		sql.append(" AND A.SABUN = :f_user_id                             ");
		sql.append(" AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE    ");
		sql.append(" AND B.HOSP_CODE = A.HOSP_CODE                        ");
		sql.append(" AND B.GWA   = A.DOCTOR_GWA                           ");
		sql.append(" AND B.LANGUAGE = :f_language                         ");
		sql.append(" AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE    ");
		if(isLimit){
			sql.append("ORDER BY A.MAIN_GWA_YN DESC, A.DOCTOR_GWA, A.HOSP_CODE LIMIT 1 ");
		}else{
			sql.append("ORDER BY A.MAIN_GWA_YN, A.HOSP_CODE, A.DOCTOR_GWA ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_user_id", userId);

		List<FormGwaItemInfo> list = new JpaResultMapper().list(query, FormGwaItemInfo.class);
		return list;
	}

	@Override
	public String loadGwaNameFromVwBasGwa(String hospCode,String language,String arg1, String arg2,String buseoGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("  SELECT A.GWA_NAME FROM VW_BAS_GWA A                                                                               ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                                   ");
		sql.append("	  AND LANGUAGE = :f_language                                                                                    ");
		sql.append("   AND A.BUSEO_GUBUN = :f_buseo_gubun                                                                                ");
		if(StringUtils.isEmpty(arg2)){
			sql.append("   AND A.START_DATE <= STR_TO_DATE(DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), '%Y/%m/%d')        ");
			sql.append("   AND A.END_DATE   >= STR_TO_DATE(DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), '%Y/%m/%d')        ");
		}else{
			sql.append("   AND A.START_DATE <= STR_TO_DATE(TRIM(:f_aArgu2 ), '%Y/%m/%d')        ");
			sql.append("   AND A.END_DATE   >= STR_TO_DATE(TRIM(:f_aArgu2 ), '%Y/%m/%d')        ");
		}
		
		sql.append("   AND A.GWA = :f_aArgu1 																							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_aArgu1", arg1);
		if(!StringUtils.isEmpty(arg2)){
			query.setParameter("f_aArgu2", arg2);
		}
		query.setParameter("f_buseo_gubun", buseoGubun);
		query.setParameter("f_language", language);
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	@Override
	public String loadColumnCodeNameInfoCaseOcsGwa(String arg1) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA_NAME  FROM VW_OCS_GWA A  WHERE A.GWA = :f_aArgu1  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_aArgu1", arg1);
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public String loadColumnCodeNameInfoCaseOcsInputPart(String arg1) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT INPUT_PART_NAME FROM VW_OCS_INPUT_PART  WHERE INPUT_PART = :f_aArgu1 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_aArgu1", arg1);
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public String getOCS0103U12GwaName(String hospCode, String language,
			String gwa, String date) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.GWA_NAME 																					");
		sql.append("	 FROM VW_BAS_GWA A                                                                                  ");
		sql.append("	WHERE A.HOSP_CODE = :hospCode                                                                       ");
		sql.append("	  AND A.GWA  = :gwa                                                                                ");
		sql.append("	  AND A.INP_JUNDAL_PART_YN = 'Y'                                                                    ");
		sql.append("	  AND LANGUAGE = :language                                                                          ");
		sql.append("	  AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:date) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')),'%Y/%m/%d')    ");
		sql.append("	  AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:date) ,DATE_FORMAT(SYSDATE(),'%Y/%m/%d')), '%Y/%m/%d')    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("gwa", gwa);
		query.setParameter("date", date);
		
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<HIOcsCheckJundalPartLoadJaeryoJundalInfo> getHIOcsCheckJundalPartLoadJaeryoJundalListItem(
			String hospCode, String language, String ioGubun,
			String hangmogCode, String jundalTable, String jundalPart,
			Date orderDate, String inputPart) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT FN_OCS_CHECK_JUNDAL_PART(:hospCode,:language, :ioGubun, :hangmogCode, :jundalTable, :jundalPart, :appDate),	");
		sql.append("	        FN_OCS_LOAD_JAERYO_JUNDAL_YN(:hospCode, :ioGubun, :inputPart, :hangmogCode)                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("jundalTable", jundalTable);
		query.setParameter("jundalPart", jundalPart);
		query.setParameter("appDate", orderDate);
		query.setParameter("inputPart", inputPart);
		
		List<HIOcsCheckJundalPartLoadJaeryoJundalInfo> listResult = new JpaResultMapper().list(query, HIOcsCheckJundalPartLoadJaeryoJundalInfo.class);
		return listResult;
	}

	@Override
	public String getLoadColunmCodeNameMovePartCase(String hospCode,String language,
			String argu1, String argu2) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	 SELECT A.GWA_NAME 																							");		

		sql.append("	 FROM VW_BAS_GWA A                                                                                          ");
		sql.append("	WHERE A.HOSP_CODE = :hospCode    AND A.LANGUAGE =:language                                                  ");
		sql.append("	  AND A.GWA         = :argu1                                                                                ");
		sql.append("	  AND A.OUT_MOVE_YN = 'Y'                                                                                   ");
		sql.append("	  AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')       ");
		sql.append("	  AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("argu1", argu1);
		query.setParameter("argu2", argu2);
		
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public String getLoadColumnGwaAll(String hospCode, String orderDate,
			String gwa) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.GWA_NAME 																							");
		sql.append("	 FROM BAS0260 A                                                                                             ");
		sql.append("	WHERE A.HOSP_CODE  = :hospCode                                                                              ");
		if(!orderDate.isEmpty()){
			sql.append("	  AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:orderDate) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d') ");
			sql.append("	  AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:orderDate) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d') ");
		}else{
			sql.append("	  AND A.START_DATE <= DATE_FORMAT(SYSDATE(), '%Y/%m/%d') ");
			sql.append("	  AND A.END_DATE   >= DATE_FORMAT(SYSDATE(), '%Y/%m/%d') ");
		}
		sql.append("	  AND A.GWA = :gwa                                                                                          ");
		sql.append("	  AND A.GWA IS NOT NULL                                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		if(!orderDate.isEmpty()){
			query.setParameter("orderDate", orderDate);
		}
		query.setParameter("gwa", gwa);
		
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getOUTSANGU00createGwaDataListItem(
			String hospCode, String outJubsu, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.GWA, A.BUSEO_NAME																											");
		sql.append("	  FROM BAS0260 A                                                    																");
		sql.append("	 WHERE A.OUT_JUBSU_YN =:out_jubsu_yn   			                    																");
		sql.append("	   AND A.HOSP_CODE    = :hospCode                                   																");
		sql.append("	   AND A.LANGUAGE = :language		                                   																");
		sql.append("	   AND A.START_DATE   = (SELECT MAX(B.START_DATE)                   																");
		sql.append("	                           FROM BAS0260 B                           																");
		sql.append("	                          WHERE B.BUSEO_CODE  = A.BUSEO_CODE        																");
		sql.append("	                            AND B.START_DATE <= SYSDATE()           																");
		sql.append("	                            AND B.HOSP_CODE   = A.HOSP_CODE  )      																");
		sql.append("	UNION                                                               																");
		sql.append("	SELECT '%' as GWA , IF(:language = 'JA', '全体', IF(:language = 'VI', 'Toàn Bộ', 'All')) as BUSEO_NAME                             	");
		sql.append("	ORDER BY GWA                                                       																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("out_jubsu_yn", outJubsu);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getComboListFromVwBasGwa(String hospCode,String language, String arg1) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA,                                                                                              ");
		sql.append("        A.GWA_NAME                                                                                          ");
		sql.append("   FROM VW_BAS_GWA A                                                                                        ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code  AND A.LANGUAGE= :f_language                                             ");
		sql.append("    AND A.BUSEO_GUBUN = '1'                                                                                 ");
		sql.append("    AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM( :f_aArgu1) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')          ");
		sql.append("    AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM( :f_aArgu1) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')          ");
		sql.append("  ORDER BY A.GWA    																						");                                   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_aArgu1", arg1);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	public List<ComboListItemInfo> getGwaBuseoNameComboListItemInfo(String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.GWA, A.BUSEO_NAME 												");
		sql.append("	FROM BAS0260 A 	                                                        ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code	                                    ");
		sql.append("	AND ( A.OUT_JUBSU_YN = 'Y' OR A.IPWON_YN = 'Y') 	                    ");
		sql.append("	AND DATE_FORMAT(SYSDATE() ,'%Y%m%d') BETWEEN A.START_DATE 	            ");
		sql.append("	AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d')) 	            ");
		sql.append("	ORDER BY A.GWA 	                                                        ");
                                                                                       
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	public List<Inp1003U00FwkGwaListItemInfo> getInp1003U00FwkGwaListItemInfo(String hospCode, String buseoYmd, String find1){
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT A.GWA																	");
		sql.append("	     , A.GWA_NAME                                                               ");
		sql.append("	     , A.BUSEO_CODE                                                             ");
		sql.append("	  FROM BAS0260 A                                                                ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                                             ");
		sql.append("	   AND A.BUSEO_GUBUN = '1'                                                      ");
		sql.append("	   AND STR_TO_DATE(:f_buseo_ymd,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE ");
		sql.append("	   AND(A.GWA       LIKE :f_find1												");
		sql.append("	    OR A.GWA_NAME  LIKE :f_find1)				                                ");
		sql.append("	   AND A.IPWON_YN = 'Y'                                                         ");
		sql.append("	 ORDER BY A.GWA                                                                 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_ymd", buseoYmd);
		query.setParameter("f_find1", "%" + find1 + "%");
		
		List<Inp1003U00FwkGwaListItemInfo> list = new JpaResultMapper().list(query, Inp1003U00FwkGwaListItemInfo.class);
		return list;
	}
	
	public List<ComboListItemInfo> getAdmMsgListItem (String language, String hospCode, Date reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '%', FN_ADM_MSG(221, :f_language)									   ");
		sql.append("	UNION ALL                                                                      ");
		sql.append("	SELECT A.GWA, A.GWA_NAME                                                       ");
		sql.append("	FROM BAS0260 A                                                                 ");
		sql.append("	WHERE A.HOSP_CODE= :f_hosp_code                                                ");
		sql.append("	AND A.BUSEO_GUBUN = '2'                                                        ");
		sql.append("	AND STR_TO_DATE(:f_reser_date,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE  ");
		sql.append("	AND A.GWA > ' '                                                                ");
		sql.append("	ORDER BY 1                                                                     ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_reser_date", reserDate);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	public List<ComboListItemInfo> getGwaNameListItem (String hospCode, Date reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.GWA gwa															  ");
		sql.append("	, A.GWA_NAME gwa_name                                                          ");
		sql.append("	FROM BAS0260 A                                                                ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                              ");
		sql.append("	AND A.BUSEO_GUBUN = '2'                                                       ");
		sql.append("	AND STR_TO_DATE(:f_reser_date,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE ");
		sql.append("	AND A.GWA > ' '                                                               ");
		sql.append("	ORDER BY 1                                                                    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_reser_date", reserDate);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	public String getGwaNameItemInfo(String hospCode, String gwa, Date reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.GWA_NAME gwa_name                                                      ");
		sql.append("	 FROM BAS0260 A                                                                 ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                ");
		sql.append("	  AND A.BUSEO_GUBUN = '1'                                                       ");
		sql.append("	  AND A.GWA         = :f_gwa                                                    ");
		sql.append("	  AND DATE_FORMAT(:f_reser_date,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_reser_date", reserDate);
		
		@SuppressWarnings("unchecked")
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	public String getDoctorNameItemInfo(String jisiDoctor, Date reserDate, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_DOCTOR_NAME(:f_jisi_doctor, :f_reser_date, :hospCode) JISI_DOCTOR_NAME");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_jisi_doctor", jisiDoctor);
		query.setParameter("f_reser_date", reserDate);
		query.setParameter("hospCode", hospCode);
		
		@SuppressWarnings("unchecked")
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	

	public List<ComboListItemInfo> getADM104UBuseoCode(String hospCode, String language, String buseoCode, String gwaName){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUSEO_CODE                                              ");
		sql.append("       , A.BUSEO_NAME                                            ");
		sql.append("  FROM BAS0260 A                                                 ");
		sql.append(" WHERE A.HOSP_CODE        = :f_hosp_code                         ");
		sql.append("   AND A.LANGUAGE = :language                                    ");
		sql.append("   AND A.USE_YN = 'Y'                                            ");
		if (!StringUtils.isEmpty(buseoCode)) {
			sql.append("   AND A.BUSEO_CODE         LIKE :buseo_code					 ");
		}
		if (!StringUtils.isEmpty(gwaName)) {
			sql.append("   AND A.BUSEO_NAME         LIKE :gwa_name						 ");
		}
		sql.append("   AND A.START_DATE          = ( SELECT MAX(Z.START_DATE)        ");
		sql.append("                              FROM BAS0260 Z                     ");
		sql.append("                             WHERE Z.HOSP_CODE = A.HOSP_CODE     ");
		sql.append("                               AND Z.LANGUAGE = A.LANGUAGE       ");
		sql.append("                               AND Z.BUSEO_CODE = A.BUSEO_CODE   ");
		sql.append("                          )                                      ");
		sql.append(" ORDER BY A.HOSP_CODE, A.BUSEO_CODE                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		if (!StringUtils.isEmpty(buseoCode)) {
			query.setParameter("buseo_code", "%" + buseoCode + "%");
		}
		if (!StringUtils.isEmpty(gwaName)) {
			query.setParameter("gwa_name", "%" + gwaName + "%");
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getComboHoDongSystemCombobox(
			String hospCode, String language, String buseoGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT '%'     BUSEO_CODE								");
		sql.append("	     , FN_ADM_MSG('221',:language)  BUSEO_NAME          ");
		sql.append("	UNION                                                   ");
		sql.append("	SELECT A.BUSEO_CODE                                     ");
		sql.append("	      ,A.BUSEO_NAME                                     ");
		sql.append("	  FROM VW_GWA_NAME A                                    ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                          ");
		sql.append("	   AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE    ");
		sql.append("	   AND A.BUSEO_GUBUN = :buseoGubun                       ");
		sql.append("	   AND A.LANGUAGE = :language                           ");
		sql.append("	   ORDER BY BUSEO_CODE                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("buseoGubun", buseoGubun);
		                                                                        
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getOCS0103U00GrdOCS0115ColChangedJundalPart(String hospCode,String language, String gwa) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA_NAME                                          ");
		sql.append("    FROM BAS0260 A                                          ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                         ");
		sql.append("   AND A.LANGUAGE = :f_language                             ");
		sql.append("     AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE      ");
		sql.append("     AND A.GWA = :f_gwa                                     ");
		sql.append("     AND IFNULL(A.OUT_JUBSU_YN, 'N') = 'Y'                  ");
		sql.append("   ORDER BY A.GWA 											");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_gwa", gwa);
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getPHY2001U04ComboListItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA, A.GWA_NAME  FROM BAS0260 A WHERE A.HOSP_CODE = :f_hosp_code  AND A.LANGUAGE = :f_langauge   " );
		sql.append(" AND A.BUSEO_GUBUN = '1'   AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE ORDER BY A.GWA					");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_langauge", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}


	@Override
	public List<String> getPHY8002U00SinryoukaInfo(String hospCode, String language, String gwa){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA_NAME FROM VW_BAS_GWA A             ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                   ");
		sql.append(" AND A.LANGUAGE = :language                      ");
		sql.append(" AND A.START_DATE <= SYSDATE()                   ");
		sql.append(" AND A.END_DATE   >= SYSDATE()                   ");
		sql.append(" AND A.GWA = :gwa                                ");
	    
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		query.setParameter("gwa", gwa);
		
		List<String> list = query.getResultList();
		return list;
	}
	@Override
	public List<ComboListItemInfo> getOUTSANGQ00LayoutGwaCombo(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.GWA, A.BUSEO_NAME                                           ");
		sql.append("    FROM BAS0260 A                                                   ");
		sql.append("   WHERE A.OUT_JUBSU_YN = 'Y'                                        ");
		sql.append("     AND A.HOSP_CODE    = :f_hosp_code                               ");
		sql.append("     AND A.LANGUAGE     = :f_language                                ");
		sql.append("     AND A.BUSEO_NAME != 'ICM'                                       ");
		sql.append("     AND A.START_DATE   = (SELECT MAX(B.START_DATE)                  ");
		sql.append("                             FROM BAS0260 B                          ");
		sql.append("                            WHERE B.BUSEO_CODE  = A.BUSEO_CODE       ");
		sql.append("                              AND B.START_DATE <= SYSDATE()          ");
		sql.append("                              AND B.HOSP_CODE   = A.HOSP_CODE  )     ");
		sql.append("  UNION                                                              ");
		sql.append("  SELECT '%' AS GWA, FN_ADM_MSG('221',:f_language) AS BUSEO_NAME     ");
		sql.append("  ORDER BY GWA                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		                                                                        
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getOCS0203U00LoadGwaInfo(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  A.GWA, A.GWA_NAME                                                                                          ");
		sql.append("   FROM VW_GWA_NAME A                                                                                                ");
		sql.append("  WHERE A.HOSP_CODE       = :f_hosp_code                                                                            ");
		sql.append("    AND ( A.OUT_JUBSU_YN  = 'Y'  OR A.IPWON_YN = 'Y' )                                                              ");
		sql.append("    AND A.START_DATE      = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), :f_hosp_code )    ");
		sql.append("    AND A.LANGUAGE = :f_language                                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS1003R02LayR03ListItemInfo> getOCS1003R03LayOutListItemInfo(
			String hospCode, String language, String gwa, String gwaNameOut,
			String bunhoOut, String sunamOut, String balheangDateOut,
			String birthOut, String naewonDateOut, String bunho1Out,
			String naewonDate, String bunho, String naewonType, String doctor,
			String orderGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                            ");
		sql.append("        :f_gwa                                        GWA,                  ");
		sql.append("        :f_gwa_name_out                               GWA_NAME,             ");
		sql.append("        :f_bunho_out                                  BUNHO,                ");
		sql.append("        :f_suname_out                                 SUNAME,               ");
		sql.append("        :f_balheang_date_out                          BALHEANG_DATE,        ");
		sql.append("        :f_birth_out                                  BIRTH,                ");
		sql.append("        :f_naewon_date_out                            NAEWON_DATE,          ");
		sql.append("        FN_BAS_LOAD_GWA_POSITION(A.MOVE_PART,SYSDATE(),:f_hosp_code, :f_language) MOVE_NAME,          ");
		sql.append("        :f_bunho_1_out                                BUNHO_1,              ");
		sql.append("        A.HOPE_DATE                                   HOPE_DATE             ");
		sql.append("    FROM BAS0260 C,                                                         ");
		sql.append("         VW_OCS_OCS1003 A                                                   ");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code                                      ");
		sql.append("     AND DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')   = :f_naewon_date           ");
		sql.append("     AND A.BUNHO        = :f_bunho                                          ");
		sql.append("     AND A.GWA          = :f_gwa                                            ");
		sql.append("     AND A.NAEWON_TYPE  = :f_naewon_type                                    ");
		sql.append("     AND A.DOCTOR       = :f_doctor                                         ");
		sql.append("     AND A.MOVE_PART    <> 'HOM'                                            ");
		sql.append("     AND A.NALSU        > 0                                                 ");
		sql.append("     AND C.HOSP_CODE    = A.HOSP_CODE                                       ");
		sql.append("     AND C.GWA          = A.MOVE_PART                                       ");
		sql.append("     AND C.LANGUAGE     = :f_language                                       ");
		sql.append("     AND IFNULL(A.WONYOI_ORDER_YN, 'N') = 'N'                               ");
		sql.append("     AND (( :f_order_gubun = '1' AND A.MOVE_PART = 'IR')                    ");
		sql.append("      OR  ( :f_order_gubun = '2' AND A.MOVE_PART = 'PT')                    ");
		sql.append("      OR  ( :f_order_gubun = '3' AND A.MOVE_PART = 'TRT'))                  ");
		sql.append("     AND IFNULL(A.DC_YN,'N') = 'N'                                          ");
		sql.append("     AND A.JUNDAL_PART  <> 'HOM'                                            ");
		sql.append("     AND A.HOPE_DATE > STR_TO_DATE(:f_naewon_date, '%Y/%m/%d')              ");
		sql.append("   ORDER BY A.HOPE_DATE														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_gwa_name_out", gwaNameOut);
		query.setParameter("f_bunho_out", bunhoOut);
		query.setParameter("f_suname_out", sunamOut);
		query.setParameter("f_balheang_date_out", balheangDateOut);
		query.setParameter("f_birth_out", birthOut);
		query.setParameter("f_naewon_date_out", naewonDateOut);
		query.setParameter("f_bunho_1_out", bunho1Out);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_type", naewonType);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_order_gubun", orderGubun);
		
		List<OCS1003R02LayR03ListItemInfo> list = new JpaResultMapper().list(query, OCS1003R02LayR03ListItemInfo.class);
		return list;
	}
	
	@Override
	public List<BAS0260DepartmentInfo> getBas0260ListGetDepartment(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.ID, 																								");    
		sql.append("	       A.GWA,                                              													");                           
		sql.append("	       A.GWA_NAME,                                                                                          ");
		sql.append("	       A.AVG_TIME                                                                                           ");
		sql.append("	FROM BAS0260 A                                                                                              ");
		sql.append("	WHERE A.HOSP_CODE    = :hospCode                                                                            ");
		sql.append("	  AND A.LANGUAGE = :language                                                                                ");
		sql.append("	  AND A.OUT_JUBSU_YN = 'Y'                                                                                  ");
		sql.append("	  AND A.BUSEO_GUBUN = '1'                                                                                   ");
		sql.append("	  AND DATE_FORMAT(sysdate(), '%Y/%m/%d')                                                    				");    
		sql.append("	      BETWEEN A.START_DATE AND IFNULL(A.END_DATE, DATE_FORMAT('9998/12/31', '%Y/%m/%d'))   					");                           
		sql.append("	ORDER BY A.GWA                                 																");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<BAS0260DepartmentInfo> list = new JpaResultMapper().list(query, BAS0260DepartmentInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> findDepartmentByHospCode(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT GWA, GWA_NAME										");
		sql.append(" FROM BAS0260                                               ");
		sql.append(" WHERE HOSP_CODE = :hospCode		                        ");
		sql.append("   AND BUSEO_GUBUN = '1'                                    ");
		sql.append("   AND SYSDATE() BETWEEN START_DATE AND END_DATE        	");
		sql.append("   AND LANGUAGE	 = :language								");
		sql.append(" ORDER BY 1                                          		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	
	@Override
	public List<ComboListItemInfo> getAssignDeptCombo(String hospCode, String language) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT '%' CODE , FN_ADM_MSG('221',:f_language) CODE_NAME   		");
		sql.append(" UNION ALL 															");
		sql.append("  SELECT DISTINCT  A.GWA  CODE , A.GWA_NAME  CODE_NAME              ");
		sql.append("    FROM BAS0260 A                    		        				");
		sql.append("    WHERE HOSP_CODE = :f_hosp_code  			    				");
		sql.append("      AND A.BUSEO_GUBUN = '1' 										");
		sql.append("      AND LANGUAGE = :f_language                                    ");
		sql.append("      AND SYSDATE() BETWEEN START_DATE AND END_DATE      			");
		sql.append("    ORDER BY 1     					                				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getINV4001LoadBuseo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUSEO_CODE    , A.BUSEO_NAME  FROM BAS0260 A  ");
		sql.append(" WHERE A.HOSP_CODE  = :hosp_code                        ");
		sql.append(" AND A.LANGUAGE     = :language                         ");
		sql.append(" AND A.BUSEO_CODE = '42100'								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	
	@Override
	public List<ComboListItemInfo> getExeDeptComboListItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT '%' CODE , FN_ADM_MSG('221',:f_language) CODE_NAME   								                                                          ");
		sql.append(" UNION ALL 																					                                                          ");
		sql.append("SELECT DISTINCT A.GWA	CODE														                                                   				  ");
		sql.append("     , A.GWA_NAME   CODE_NAME                                                                                                                         ");
		sql.append("  FROM BAS0260 A                                                                                                                                      ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                  ");
		sql.append("   AND A.LANGUAGE    = :f_language                                                                                                             		  ");
		sql.append("   AND A.GWA   IS NOT NULL                                                                                                                            ");
		sql.append("   AND A.BUSEO_CODE IN (SELECT DEPT_CODE FROM ADM3200 WHERE USER_GROUP IN ('NUR', 'NUT', 'OCS','XRT', 'CPL', 'DRG') AND HOSP_CODE = :f_hosp_code )    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
	
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}
	
	
	@Override
	public List<LoadGrdBAS0260U01Info> getBas0260ListGetDepartment(String language, String buseoGubun, String gwaName, String activeFlg){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	   SELECT A.ID, 																						    ");    
		sql.append("              A.BUSEO_CODE,	                                                                                    ");
		sql.append("              A.BUSEO_NAME,	                                                                                    "); 
		sql.append("              A.BUSEO_NAME2,  	                                                                                ");
		sql.append("              A.BUSEO_GUBUN,  	                                                                                ");
		sql.append("              A.PARENT_BUSEO,  	                                                                                ");
		sql.append("              A.GWA,		  	                                                                                ");
		sql.append("              A.GWA_NAME,	  	                                                                                ");
		sql.append("              A.GWA_NAME2,	                                                                                    ");
		sql.append("              A.GWA_GUBUN,	                                                                                    ");
		sql.append("              A.PARENT_GWA,	                                                                                    ");
		sql.append("              A.NOTE,		  	                                                                                ");
		sql.append("              A.LANGUAGE,	  	                                                                                ");
		sql.append("              A.ACTIVE_FLG	                                                                                    ");
		sql.append("	FROM BAS0260S A                                                                                             ");
		sql.append("	WHERE 1 = 1                                                                                                 ");
		if (!StringUtils.isEmpty(buseoGubun)) {
			sql.append("	  AND A.BUSEO_GUBUN    LIKE :f_buseo_gubun                                                              ");
		}
		
		sql.append("	  AND A.LANGUAGE      = :f_language                                                                         ");
		
		if (!StringUtils.isEmpty(gwaName)) {
			sql.append("	  AND A.GWA_NAME      LIKE :f_gwa_name                                                                  ");
		}
		
		sql.append("	  AND A.ACTIVE_FLG    = '1'                                                                       			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		
		if (!StringUtils.isEmpty(buseoGubun)) {
			query.setParameter("f_buseo_gubun", "%" + buseoGubun + "%");
		}
		if (!StringUtils.isEmpty(gwaName)) {
			query.setParameter("f_gwa_name", "%" + gwaName + "%");
		}
		query.setParameter("f_language", language);
		
		List<LoadGrdBAS0260U01Info> list = new JpaResultMapper().list(query, LoadGrdBAS0260U01Info.class);
		return list;
	}
	
	@Override
	public boolean isExistedBAS0260(String hospCode, String buseoCode, String startDate, String language) {
		StringBuilder sql = new StringBuilder();
	
		sql.append("	SELECT 'Y' 																		 ");
		sql.append("	FROM BAS0260 A                                                                   ");
		sql.append("	WHERE A.HOSP_CODE  = :hospCode                                                   ");
		sql.append("	AND A.BUSEO_CODE = :buseoCode                                                    ");
		sql.append("	AND A.START_DATE = STR_TO_DATE(:startDate, '%Y/%m/%d')                          ");
		sql.append("	AND A.LANGUAGE = :language                                                       ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("buseoCode", buseoCode);
		query.setParameter("startDate", startDate);
		query.setParameter("language", language);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}
	public List<WaitingPatientInfo> getWaitingPatients(String doctor, String examinationDate, String hospCode, String deptCode, String language)
	{
		StringBuilder sql = new StringBuilder();
		sql.append("select A.PKOUT1001, A.NAEWON_DATE, A.JUBSU_TIME, D.GWA, D.GWA_NAME, C.SUNAME, A.BUNHO, C.SUNAME2,                              	 							   						 ");
		sql.append("B.DOCTOR, B.DOCTOR_NAME, A.SYS_ID, A.ARRIVE_TIME, A.NAEWON_YN from OUT1001 A,BAS0270 B,OUT0101 C,BAS0260 D WHERE                                             			    		");
		sql.append("A.GWA = B.DOCTOR_GWA and A.DOCTOR = B.DOCTOR and A.HOSP_CODE = B.HOSP_CODE and A.HOSP_CODE = C.HOSP_CODE                       														");
		sql.append("and A.HOSP_CODE = D.HOSP_CODE and A.BUNHO = C.BUNHO and A.GWA = D.GWA and D.LANGUAGE = :language                               														");
		sql.append("and DATE_FORMAT(A.NAEWON_DATE , '%Y/%m/%d') = :examinationDate and  SUBSTR(A.DOCTOR, 3) = :doctor and A.HOSP_CODE = :hospCode and A.NAEWON_YN = 'Y' AND A.SYS_ID ='MBSO' ");


		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("examinationDate", examinationDate);
//		query.setParameter("deptCode", deptCode);
		query.setParameter("language", language);

		List<WaitingPatientInfo> list = new JpaResultMapper().list(query, WaitingPatientInfo.class);
		return list;

	}
	public List<WaitingPatientInfo> getWaitingOfPatient(String examinationDate, String hospCode, String language, List<String> patientCodes)
	{
		StringBuilder sql = new StringBuilder();
		sql.append("select A.PKOUT1001, A.NAEWON_DATE, A.JUBSU_TIME, D.GWA, D.GWA_NAME, C.SUNAME, A.BUNHO, C.SUNAME2,                              	 							    ");
		sql.append("B.DOCTOR, B.DOCTOR_NAME, A.SYS_ID, A.ARRIVE_TIME, A.NAEWON_YN from OUT1001 A,BAS0270 B,OUT0101 C,BAS0260 D WHERE                                             	");
		sql.append("A.GWA = B.DOCTOR_GWA and A.DOCTOR = B.DOCTOR and A.HOSP_CODE = B.HOSP_CODE and A.HOSP_CODE = C.HOSP_CODE                       									");
		sql.append("and A.HOSP_CODE = D.HOSP_CODE and A.BUNHO = C.BUNHO and A.GWA = D.GWA and D.LANGUAGE = :language                               									");
		sql.append("and DATE_FORMAT(A.NAEWON_DATE , '%Y/%m/%d') = :examinationDate and A.BUNHO in (:patientCodes) and A.HOSP_CODE = :hospCode  	AND A.SYS_ID ='MBSO'					");


		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCodes", patientCodes);
		query.setParameter("examinationDate", examinationDate);

		query.setParameter("language", language);

		List<WaitingPatientInfo> list = new JpaResultMapper().list(query, WaitingPatientInfo.class);
		return list;

	}

	@Override
	public List<ComboListItemInfo> getINP1001R04cboHodong(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%'                          CODE                                                               ");
		sql.append("      , FN_ADM_MSG('221',:language)   CODE_NAME                                                         ");
		sql.append("  UNION ALL                                                                                             ");
		sql.append(" SELECT A.GWA                      CODE                                                                 ");
		sql.append("      , A.GWA_NAME            CODE_NAME                                                                 ");
		sql.append("   FROM BAS0260 A                                                                                       ");
		sql.append("  WHERE BUSEO_GUBUN = '2'                                                                               ");
		sql.append("    AND A.HOSP_CODE = :hosp_code                                                                        ");
		sql.append("    AND SWF_TruncDate(CURRENT_TIMESTAMP,'DD') BETWEEN A.START_DATE AND A.END_DATE                       ");
		sql.append("    AND A.GWA <> 'T'                                                                                    ");
		sql.append("  ORDER BY CODE											                                                ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getINP1001D01cboHodongInfo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%' GWA, FN_ADM_MSG('221',FN_LOAD_LANGUAGE_FROM_HOSPITAL(:f_hosp_code))	GWA_NAME	");
		sql.append("  FROM DUAL														                            ");
		sql.append(" UNION ALL														                            ");
		sql.append(" SELECT A.GWA GWA, A.GWA_NAME GWA_NAME							                            ");
		sql.append("  FROM BAS0260 A												                            ");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code								                            ");
		sql.append("  AND A.LANGUAGE   = FN_LOAD_LANGUAGE_FROM_HOSPITAL(:f_hosp_code)							");
		sql.append("  AND A.BUSEO_GUBUN = '2'										                            ");
		sql.append("  AND A.START_DATE  = ( SELECT MAX(Z.START_DATE)				                            ");
		sql.append("                          FROM BAS0260 Z 						                            ");
		sql.append("                         WHERE Z.HOSP_CODE   = :f_hosp_code		                            ");
		sql.append("                           AND Z.LANGUAGE    = A.LANGUAGE		                            ");
		sql.append("                           AND Z.BUSEO_CODE  = A.BUSEO_CODE		                            ");
		sql.append("                           AND Z.START_DATE <= SYSDATE() 		                            ");
		sql.append("                      )											                            ");
		sql.append(" ORDER BY GWA													                            ");
		                                                                                                        
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}
	
	@Override
	public String getNURILIBbuseoInfo(String hospCode, String buseoGubun, String gwa, String naewonDate) {
		StringBuilder sql = new StringBuilder();		
		sql.append("SELECT BUSEO_NAME													");                           
		sql.append("  FROM BAS0260 														");
		sql.append("  WHERE HOSP_CODE   = :f_hosp_code  								");
		sql.append("    AND BUSEO_GUBUN = :f_buseo_gubun 								");
		sql.append("    AND GWA         = :f_gwa 										");
		sql.append("    AND DATE_FORMAT(:f_naewon_date, '%Y/%m/%d') BETWEEN START_DATE  ");
		sql.append("                                                 AND END_DATE 		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_gubun", buseoGubun);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_naewon_date", naewonDate);
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	@Override
	public List<ComboListItemInfo> getINP1003Q00cboHodong(String hospCode, String reserDate){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.GWA,                                              											");                           
		sql.append("	       A.GWA_NAME                                                                                   ");
		sql.append("	FROM BAS0260 A                                                                                      ");
		sql.append("	WHERE A.HOSP_CODE    = :f_hosp_code                                                                 ");
		sql.append("	  AND A.BUSEO_GUBUN  = '2'                                                                          ");
		sql.append("	  AND DATE_FORMAT(:f_reser_date, '%Y/%m/%d')                                                        ");
		sql.append("	      BETWEEN A.START_DATE AND IFNULL(A.END_DATE, DATE_FORMAT('9998/12/31', '%Y/%m/%d'))            ");
		sql.append("	  AND A.GWA          > ''                                                                           ");
		sql.append("	ORDER BY A.GWA                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_reser_date", reserDate);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public String getINP1003U01CheckBool(String hospCode, String gwa, String buseoYmd){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT  'X' 																");
		sql.append("       FROM BAS0260 A															");
		sql.append("      WHERE A.HOSP_CODE   = :f_hosp_code										");
		sql.append("        AND A.BUSEO_GUBUN = '1'													");
		sql.append("        AND DATE_FORMAT(:f_buseo_ymd, '%Y/%m/%d')  								");
		sql.append("                          BETWEEN A.START_DATE AND A.END_DATE					");
		sql.append("        AND A.GWA         = :f_gwa												");
		sql.append("        AND A.IPWON_YN    = 'Y'													");
		sql.append("      ORDER BY A.GWA															");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_buseo_ymd", buseoYmd);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public String getExsitReserDateINP1003U01SaveLayout(String hospCode, String gwa, Date reserDate){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT 'Y'																			");
		sql.append("       FROM DUAL																		");
		sql.append("      WHERE EXISTS (SELECT 'X'															");
		sql.append("                      FROM BAS0260 A													");
		sql.append("                     WHERE A.HOSP_CODE = :f_hosp_code									");
		sql.append("                       AND A.GWA       = :f_gwa											");
		sql.append("                       AND IFNULL(DATE_FORMAT(:f_reser_date, '%Y/%m/%d'), SYSDATE()) 	");
		sql.append("                                       BETWEEN A.START_DATE 							");
		sql.append("                                           AND A.END_DATE )								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_reser_date", reserDate);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<INP1003U00fwkGwaInfo> getINP1003U00fwkGwaInfo(String hospCode, String buseoYmd, String find1) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																								");
		sql.append("	 	A.GWA,																							");
		sql.append("	  	A.GWA_NAME,																						");
		sql.append("	  	A.BUSEO_CODE																					");
		sql.append("	FROM																								");
		sql.append("		BAS0260 A																						");
		sql.append("	WHERE																								");
		sql.append("		A.HOSP_CODE   = :f_hosp_code																	");
		sql.append("	  	AND A.BUSEO_GUBUN = '1'																			");
		sql.append("	  	AND STR_TO_DATE(:f_buseo_ymd,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE					");
		sql.append("	  	AND A.IPWON_YN = 'Y'																			");
		sql.append("	  	AND (A.GWA LIKE :f_find1 OR A.GWA_NAME LIKE :f_find1)											");
		sql.append("	ORDER BY																							");
		sql.append("		A.GWA																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_ymd", buseoYmd);
		query.setParameter("f_find1", "%" + find1 + "%");
		
		List<INP1003U00fwkGwaInfo> list = new JpaResultMapper().list(query, INP1003U00fwkGwaInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getINP1003U00cboHodong(String hospCode, String language, String reserDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '%', FN_ADM_MSG(221, :f_language)																								");
		sql.append("	FROM 																							");
		sql.append("		DUAL 																						");
		sql.append("		UNION ALL 																					");
		sql.append("	SELECT																							");
		sql.append("		A.GWA, A.GWA_NAME																			");
		sql.append("	FROM																							");
		sql.append("		BAS0260 A																					");
		sql.append("	WHERE																							");
		sql.append("		A.HOSP_CODE  				= :f_hosp_code													");
		sql.append("		AND A.LANGUAGE 				= :f_language													");
		sql.append("		AND A.BUSEO_GUBUN 			= '2'															");
		sql.append("		AND STR_TO_DATE(:f_reser_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE				");
		sql.append("		AND A.GWA 					> ' ' 															");
		sql.append("	ORDER BY 1																						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_reser_date", reserDate);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getINP1003U00MakeHodongCombo(String hospCode, String reserDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT																						");
		sql.append("	 	A.GWA        		gwa,																");
		sql.append("	 	A.GWA_NAME   		gwa_name															");
		sql.append("	 FROM																						");
		sql.append("	 	BAS0260 A																				");
		sql.append("	 WHERE																						");
		sql.append("	 	A.HOSP_CODE  				= :f_hosp_code												");
		sql.append("	 	AND A.BUSEO_GUBUN 			= '2'														");
		sql.append("	 	AND STR_TO_DATE(:f_reser_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE			");
		sql.append("	 	AND A.GWA 					> ' ' 														");
		sql.append("	 ORDER BY 1																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_reser_date", reserDate);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<INP1003U00grdInpReserGridColumnChangeddtGwaInfo> getINP1003U00grdInpReserGridColumnChangeddtGwa(
			String hospCode, String gwa, String reserDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 																						");
		sql.append("		A.GWA_NAME 				gwa_name 														");
		sql.append("	FROM 																						");
		sql.append("		BAS0260 A 																				");
		sql.append("	WHERE 																						");
		sql.append("		A.HOSP_CODE 			= :f_hosp_code 													");
		sql.append("		AND A.BUSEO_GUBUN 		= '1' 															");
		sql.append("		AND A.GWA         		= :f_gwa 														");
		sql.append("		AND STR_TO_DATE(:f_reser_date,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE 			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_reser_date", reserDate);
		
		List<INP1003U00grdInpReserGridColumnChangeddtGwaInfo> list = new JpaResultMapper().list(query, INP1003U00grdInpReserGridColumnChangeddtGwaInfo.class);
		return list;
	}
	
	@Override
	public String inp1001U01checkExist(String hospCode, String hoDong, Date silIpwonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT 'Y'															");
		sql.append("       FROM DUAL														");
		sql.append("       WHERE EXISTS ( SELECT 'X'										");
		sql.append("               FROM BAS0260 A											");
		sql.append("              WHERE A.HOSP_CODE        = :f_hosp_code					");
		sql.append("                AND A.GWA              = :f_ho_dong1					");
		sql.append("                AND :f_sil_ipwon_date  BETWEEN A.START_DATE				");
		sql.append("                                           AND A.END_DATE				");

		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong1", hoDong);
		query.setParameter("f_sil_ipwon_date", silIpwonDate);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> findBasGwaByHospCodeIpwonYnBuseoGubun(String hospCode, String language, String ipwonYn,
			String buseoGubun, boolean isAll) {
		
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append("SELECT '%', FN_ADM_MSG('221',:f_language)                                                     			");
			sql.append("UNION                                                                                         			");
		}
		
		sql.append("	(SELECT A.GWA, A.GWA_NAME																				");
		sql.append("	FROM VW_BAS_GWA A																						");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																		");
		sql.append("	  AND A.IPWON_YN = :f_ipwonYn																			");
		sql.append("	  AND A.BUSEO_GUBUN = :f_buseoGubun																		");
		sql.append("	 AND CURRENT_DATE() BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))		");
		sql.append("	ORDER BY A.GWA)																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ipwonYn", ipwonYn);
		query.setParameter("f_buseoGubun", buseoGubun);
		if(isAll){
			query.setParameter("f_language", language);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String callFnDrgConvBuseoCode(String hospCode, String gwa) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_DRG_CONV_BUSEO_CODE(:hospCode, :f_gwa);");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_gwa", gwa);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)&& result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getOCSCHKDISCHARGEgrdStatus1(String hospCode, String fkinp1001, String kijundate, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'KEN', FN_OCSI_LOAD_NOT_ACTING_COUNT(:f_hosp_code, :f_fkinp1001, STR_TO_DATE(:f_kijundate, '%Y/%m/%d')) CNT 	");
		sql.append("	  FROM DUAL																											");
		sql.append("	 UNION ALL																											");
		sql.append("	SELECT 'SYO', FN_OCS_IS_YET_BANNAB_ORDER(:f_hosp_code, :f_bunho, STR_TO_DATE(:f_kijundate, '%Y/%m/%d')) CNT 		");
		sql.append("	  FROM DUAL																											");
		sql.append("	 UNION ALL																											");
		sql.append("	SELECT 'SIJ', IFNULL(FN_OCS_CHECK_NOT_END_DIRECT(:f_hosp_code, :f_bunho, :f_fkinp1001), 'NOROW') CNT 				");
		sql.append("	  FROM DUAL																											");
		sql.append("	 UNION ALL																											");
		sql.append("	SELECT 'SIK', FN_OCSI_GET_SYOKUDOME_CNT(:f_hosp_code, :f_fkinp1001, STR_TO_DATE(:f_kijundate, '%Y/%m/%d') + 1) CNT 	");
		sql.append("	  FROM DUAL																											");
		sql.append("	 UNION ALL																											");
		sql.append("	SELECT 'APP', FN_OCSI_GET_INSORDER_CNT(:f_hosp_code, :f_fkinp1001) CNT 												");
		sql.append("	  FROM DUAL																											");
		                	
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", CommonUtils.parseInteger(fkinp1001));
		query.setParameter("f_kijundate", kijundate);
		query.setParameter("f_bunho", bunho);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public DataStringListItemInfo getOCSCHKDISCHARGEFkinp1001(String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 												");
		sql.append("		CAST(PKINP1001 AS CHAR)                         ");
		sql.append("	FROM 												");
		sql.append("		INP1001 A 										");
		sql.append("	WHERE 												");
		sql.append("		IFNULL(A.CANCEL_YN,'N')   		= 'N'    		");
		sql.append("		AND IFNULL(A.JAEWON_FLAG,'N') 	= 'Y'    		");
		sql.append("		AND A.IPWON_TYPE           		= '0'    		");
		sql.append("	AND A.BUNHO                			= :f_bunho		");
		                	
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunho", bunho);
		
		List<DataStringListItemInfo> listInfo = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		if(!CollectionUtils.isEmpty(listInfo)){
			return listInfo.get(0);
		}
		return null;
	}

	@Override
	public String callFnOcsCheckNotEndDirect(String hospCode, String bunho, String fkinp1001) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT FN_OCS_CHECK_NOT_END_DIRECT(:f_hosp_code, :f_bunho, :f_fkinp1001)	");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && !StringUtils.isEmpty(result.get(0))){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String callFnBasLoadBuseoCode(String hospCode, String bunho, String date) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT FN_BAS_LOAD_BUSEO_CODE(:f_hosp_code, FN_INP_LOAD_HO_DONG_HISTORY(:f_hosp_code, :f_bunho, :f_date), :f_date)	");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_date", DateUtil.toDate(date, DateUtil.PATTERN_YYMMDD));
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && !StringUtils.isEmpty(result.get(0))){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<ComboListItemInfo> getBAS0250Q00grdBAS0260Department(String hospCode, String language, Date buseoYmd, String gumjinHodong){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.GWA,                                              													");                           
		sql.append("	       A.GWA_NAME                                                                                   		");
		sql.append("	FROM BAS0260 A                                                                                      		");
		sql.append("	WHERE A.HOSP_CODE    = :f_hosp_code                                                                    		");
		sql.append("	  AND A.LANGUAGE = :f_language                                                                        		");
		sql.append("	  AND A.BUSEO_GUBUN = '2'                                                                     		        ");
		sql.append("	  AND :f_buseo_ymd BETWEEN A.START_DATE AND A.END_DATE                     		                            ");
		sql.append("	AND (                                 																		");
		sql.append("	         ( :f_gumjin_hodong = 'Y'                                  											");
		sql.append("	           AND                                																");
		sql.append("	           EXISTS ( SELECT 'X'                                  											");
		sql.append("	                      FROM BAS0250 X                                 										");
		sql.append("	                     WHERE X.HOSP_CODE = A.HOSP_CODE                                  						");
		sql.append("	                       AND X.HO_DONG = A.GWA                                 								");
		sql.append("	                       AND X.HO_STATUS IN ('H')                                  							");
		sql.append("	                       AND :f_buseo_ymd BETWEEN X.START_DATE AND X.END_DATE )								");
		sql.append("	         )                                 																	");
		sql.append("	         OR                                 																");
		sql.append("	         ( :f_gumjin_hodong = 'N'                                  											");
		sql.append("	           AND                                 																");
		sql.append("	           EXISTS ( SELECT 'X'                                  											");
		sql.append("	                      FROM BAS0250 X                                 										");
		sql.append("	                     WHERE X.HOSP_CODE = A.HOSP_CODE                                  						");
		sql.append("	                       AND X.HO_DONG = A.GWA                                 								");
		sql.append("	                       AND X.HO_STATUS NOT IN ('H')                                							");
		sql.append("	                       AND :f_buseo_ymd BETWEEN X.START_DATE AND X.END_DATE) 								");
		sql.append("	         )                                 																	");
		sql.append("	       )                                 																	");
		sql.append("	ORDER BY A.GWA                                                                                      		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_ymd", buseoYmd);
		query.setParameter("f_gumjin_hodong", gumjinHodong);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getDRG3010P99cbxBuseo (String hospCode, String language, String buseoGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT '%'     BUSEO_CODE													");
		sql.append("          , CASE(:f_language) WHEN 'JA' THEN '全体'								");
		sql.append("                              WHEN 'VI' THEN 'Tất cả'							");
		sql.append("                              ELSE 'All' END           BUSEO_NAME				");
		sql.append("       FROM DUAL																");
		sql.append("     UNION																		");
		sql.append("     SELECT A.BUSEO_CODE														");
		sql.append("          , A.BUSEO_NAME														");
		sql.append("       FROM VW_GWA_NAME A														");
		sql.append("      WHERE A.HOSP_CODE   = :f_hosp_code										");
		sql.append("        AND CURRENT_DATE() BETWEEN A.START_DATE AND A.END_DATE					");
		sql.append("        AND A.BUSEO_GUBUN = :f_buseo_gubun										");
		sql.append("        AND A.LANGUAGE    = :f_language											");
		sql.append("        ORDER BY BUSEO_CODE														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_gubun", buseoGubun);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getComboHoDong(String hospCode, String language, String buseoGubun, String find1) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.BUSEO_CODE                                                 ");
		sql.append("	      ,A.BUSEO_NAME                                                 ");
		sql.append("	  FROM VW_GWA_NAME A                                                ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                                      ");
		sql.append("	   AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                ");
		sql.append("	   AND A.BUSEO_GUBUN = :buseoGubun                                  ");
		sql.append("	   AND A.LANGUAGE = :language                                       ");
		sql.append("	   AND (A.BUSEO_CODE LIKE :f_find1 OR A.BUSEO_NAME LIKE :f_find1)	");
		sql.append("	   ORDER BY BUSEO_CODE                                  			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("buseoGubun", buseoGubun);
		query.setParameter("f_find1", "%" + find1 + "%");                     
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public String getBuseoNameByCode(String hospCode, String language, String buseoGubun, String code){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(A.BUSEO_NAME, '')						");
		sql.append("   FROM VW_GWA_NAME A									");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code						");
		sql.append("    AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE	");
		sql.append("    AND A.BUSEO_GUBUN  = :f_buseo_gubun					");
		sql.append("    AND A.BUSEO_CODE   = :f_code						");
	    sql.append("    AND A.LANGUAGE     = :f_language					");
	    
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_gubun", buseoGubun);
		query.setParameter("f_code", code);
		query.setParameter("f_language", language);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list)? "" : list.get(0);
	}

	@Override
	public List<ComboListItemInfo> getNUR2004U00fbxToHodong(String hospCode, String date) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																					");
		sql.append("		A.GWA      								hodong,										");
		sql.append("	  	A.GWA_NAME 								hodong_name									");
		sql.append("	FROM																					");
		sql.append("		BAS0260 A																			");
		sql.append("	WHERE																					");
		sql.append("		A.HOSP_CODE 							= :f_hosp_code								");
		sql.append("	   	AND STR_TO_DATE(:f_date, '%Y/%m/%d') 	BETWEEN A.START_DATE AND A.END_DATE			");
		sql.append("	   	AND A.BUSEO_GUBUN 						= '2'										");
		sql.append("	ORDER BY																				");
		sql.append("		A.GWA_SORT1																			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<DataStringListItemInfo> getNUR2004U00layValidCheckGwa(String hospCode, String code, String date) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																						");
		sql.append("		A.GWA_NAME		  																		");
		sql.append("	FROM																						");
		sql.append("		BAS0260 A 																				");
		sql.append("	WHERE																						");
		sql.append("		A.HOSP_CODE   								= :f_hosp_code								");
		sql.append("	   	AND A.BUSEO_GUBUN 							= '1'										");
		sql.append("	   	AND A.GWA  									= :f_code									");
		sql.append("	    AND STR_TO_DATE(:f_date, '%Y/%m/%d') 		BETWEEN A.START_DATE AND A.END_DATE			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		query.setParameter("f_date", date);
		
		List<DataStringListItemInfo> listInfo = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<DataStringListItemInfo> getNUR2004U00layValidCheckHodong(String hospCode, String code, String date) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																						");
		sql.append("		A.GWA_NAME																				");
		sql.append("	FROM																						");
		sql.append("		BAS0260 A 																				");
		sql.append("	WHERE																						");
		sql.append("		A.HOSP_CODE   							= :f_hosp_code									");
		sql.append("		AND A.BUSEO_GUBUN 						= '2' 											");
		sql.append("		AND A.GWA  								= :f_code										");
		sql.append("		AND STR_TO_DATE(:f_date, '%Y/%m/%d') 	BETWEEN A.START_DATE AND A.END_DATE				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		query.setParameter("f_date", date);
		
		List<DataStringListItemInfo> listInfo = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return listInfo;
	}
	
	@Override
	public List<ComboListItemInfo> getBuseoCodeBuseoNameInVwGwaName(String hospCode, String language, String buseoGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																						");
		sql.append("		A.BUSEO_CODE, A.BUSEO_NAME																");
		sql.append("	FROM																						");
		sql.append("		VW_GWA_NAME A 																			");
		sql.append("	WHERE																						");
		sql.append("		A.HOSP_CODE   							= :f_hosp_code									");
		sql.append("		AND A.BUSEO_GUBUN 						= :f_buseo_gubun 								");
		sql.append("		AND A.LANGUAGE  						= :f_language									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_gubun", buseoGubun);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR8003Q00cboBuseo(String hospCode, String language, String buseoGubun) {
		StringBuilder sql = new StringBuilder();		
		sql.append("   SELECT  B.HO_DONG                                                 ");
		sql.append("         , A.GWA_NAME                                                ");
		sql.append("     FROM (SELECT SYS_DATE,                                          ");
		sql.append("             SYS_ID,                                                 ");
		sql.append("             UPD_DATE,                                               ");
		sql.append("             UPD_ID,                                                 ");
		sql.append("             GWA HO_DONG,                                            ");
		sql.append("             BUSEO_NAME HO_DONG_NAME,                                ");
		sql.append("             GWA_NAME GWA_NAME,                                      ");
		sql.append("             TEL,                                                    ");
		sql.append("             START_DATE,                                             ");
		sql.append("             END_DATE,                                               ");
		sql.append("             HOSP_CODE                                               ");
		sql.append("        FROM BAS0260 A                                               ");
		sql.append("       WHERE     A.HOSP_CODE   = :f_hosp_code                        ");
		sql.append("             AND A.LANGUAGE    = :f_language                         ");
		sql.append("             AND A.BUSEO_GUBUN = :f_buseo_gubun                      ");
		sql.append("             AND A.GWA IS NOT NULL) A /*VW_BAS_DONG*/                ");
		sql.append("     JOIN  NUR0801 B                                                 ");
		sql.append("       ON  B.HOSP_CODE = A.HOSP_CODE                                 ");
		sql.append("      AND  B.HO_DONG   = A.HO_DONG                                   ");
		sql.append("    WHERE  A.HOSP_CODE = :f_hosp_code                                ");
		sql.append("    ORDER BY B.HO_DONG                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_gubun", buseoGubun);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR1001U00FwkFind(String hospCode, String language, String buseoName) {
		StringBuilder sql = new StringBuilder();		
		sql.append("   SELECT A.USER_ID, A.USER_NM               ");
		sql.append("     FROM ADM3200 A                          ");
		sql.append("     JOIN BAS0260 B                          ");
		sql.append("       ON B.HOSP_CODE  = A.HOSP_CODE         ");
		sql.append("      AND B.BUSEO_CODE = A.DEPT_CODE         ");
		sql.append("      AND B.BUSEO_NAME = :f_buseo_name       ");
		sql.append("      AND B.LANGUAGE   = :f_language         ");
		sql.append("    WHERE A.HOSP_CODE  = :f_hosp_code        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_name", buseoName);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}
}
