package nta.med.data.dao.medi.bas.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.bas.Bas0250;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.model.ihis.bass.BAS0250Q00grdHOBEDInfo;
import nta.med.data.model.ihis.bass.BAS0250U00GrdHoCodeListInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00SelectHosexInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00layBedListInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00layHosilListInfo;
import nta.med.data.model.ihis.nuri.NUR2004U00layValidCheckHocodeInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;

/**
 * @author dainguyen.
 */

@Repository("bas0250Repository")
public class Bas0250RepositoryImpl extends SimpleJpaRepository<Bas0250, Long> implements Bas0250Repository {

	@PersistenceContext
	private EntityManager entityManager;

	@Autowired
	public Bas0250RepositoryImpl(EntityManager entityManager) {
		super(Bas0250.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Bas0250Repository", allEntries = true)
	public Bas0250 save(Bas0250 entity) {
		return super.save(entity);
	}

	@Override
	@CacheEvict(value = "Bas0250Repository", allEntries = true)
	public List<Bas0250> save(List<Bas0250> entities) {
		return super.save(entities);
	}
	
	@Override
	@CacheEvict(value = "Bas0250Repository", allEntries = true)
	public void delete(Bas0250 entity) {
		super.delete(entity);
	}
	
	@Override
	@Cacheable(value = "Bas0250Repository")
	public List<Bas0250> findByHoCodeHoDongStartDate(String hospCode, String hoCode, String hoDong, String startDate) {
		String sql = "SELECT T FROM Bas0250 T WHERE T.hospCode = :f_hosp_code AND T.hoCode = :f_ho_code AND T.hoDong = :f_ho_dong AND T.startDate = STR_TO_DATE(:f_start_date,'%Y/%m/%d') ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_start_date", startDate);
		
		return query.getResultList();
	}

	@Override
	@CacheEvict(value = "Bas0250Repository", allEntries = true)
	public Integer deleteByHospCodeHoCodeHoDongStartDate(String hospCode, String hoCode, String hoDong, String startDate) {
		String sql = "DELETE FROM Bas0250 WHERE hospCode = :f_hosp_code AND hoCode = :f_ho_code AND hoDong = :f_ho_dong AND startDate = STR_TO_DATE(:f_start_date,'%Y/%m/%d') ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_start_date", startDate);
		
		return query.executeUpdate();
	}

	@Override
	@Cacheable(value = "Bas0250Repository")
	public List<Bas0250> findByHospCodeHoDong(String hospCode, String hoDong) {
		String sql = "SELECT T FROM Bas0250 T WHERE T.hospCode = :f_hosp_code AND T.hoDong = :f_ho_dong";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		return query.getResultList();
	}
	
	@Override
	public List<ComboListItemInfo> getHocodeHodongItemInfo(String hospCode, Date hoCodeYmd, String hoDong, String hoCode){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT 																 ");
		sql.append("	A.HO_CODE HO_CODE                                                                ");
		sql.append("	, A.HO_DONG HO_DONG                                                              ");
		sql.append("	FROM BAS0250 A                                                                   ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                 ");
		sql.append("	AND DATE_FORMAT( :f_ho_code_ymd ,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE ");
		sql.append("	AND A.HO_DONG LIKE CONCAT( :f_ho_dong , '%')                                     ");
		sql.append("	AND A.HO_CODE = :f_ho_code                                                       ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_code_ymd", hoCodeYmd);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public String getBAS0250U00FbxHoGradeValidating(String hospCode, String hoGrade, String hoGradeYmd) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT                                                      									");
		sql.append("		A.HO_GRADE_NAME                                                								");
		sql.append("	FROM                                                      										");
		sql.append("		BAS0251 A                                                									");
		sql.append("	WHERE                                                      										");
		sql.append("		A.HOSP_CODE   			= :f_hosp_code                        								");
		sql.append("		AND A.HO_GRADE 			= :f_ho_grade                          								");
		sql.append("		AND DATE_FORMAT(:f_ho_grade_ymd, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_grade", hoGrade);
		query.setParameter("f_ho_grade_ymd", hoGradeYmd);
		
		@SuppressWarnings("unchecked")
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		
		return null;
	}

	@Override
	public List<BAS0250U00GrdHoCodeListInfo> getBAS0250U00GrdHoCodeListInfoList(String hospCode, String language,
			String jukyongDate, String hoDong, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(DATE_FORMAT(A.START_DATE, '%Y/%m/%d'), '')								HO_CODE_YMD,	");
		sql.append("	       A.HO_CODE                                                                        HO_CODE,		");
		sql.append("	       A.HO_DONG                                                                        HO_DONG,		");
		sql.append("	       A.HO_GRADE                                                                       HO_GRADE,		");
		sql.append("	       B.HO_GRADE_NAME                                                                  HO_GRADE_NAME,	");
		sql.append("	       CAST(A.HO_TOTAL_BED AS CHAR)														HO_TOTAL_BED,	");
		sql.append("	       CAST(A.HO_USED_BED AS CHAR)														HO_USED_BED,	");
		sql.append("	       ''																				HO_COM_BED,		");
		sql.append("	       ''																				HO_COM_USED_BED,");
		sql.append("	       A.HO_MAIN_GWA                                                                    HO_MAIN_GWA,	");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.HO_MAIN_GWA, :f_jukyong_date, :f_hosp_code, :f_language)  GWA_MAIN_NAME,	");
		sql.append("	       ''																				HO_GWA,			");
		sql.append("	       ''																				GWA_NAME,		");
		sql.append("	       ''																				HO_LOC,			");
		sql.append("	       A.HO_SEX                                                                          HO_SEX,		");
		sql.append("	       CAST(IFNULL(A.HO_SEX_MAIL, 0) AS CHAR)											 HO_SEX_MAIL,	");
		sql.append("	       CAST(IFNULL(A.HO_SEX_FEMAIL, 0) AS CHAR)											 HO_SEX_FEMAIL,	");
		sql.append("	       A.HO_SPECIAL_YN                                                                   HO_SPECIAL_YN,	");
		sql.append("	       IFNULL(DATE_FORMAT(A.END_DATE, '%Y/%m/%d'), '')									 BULYONG_DATE,	");
		sql.append("	       A.HO_STATUS                                                                       HO_STATUS,		");
		sql.append("	       A.HO_GUBUN                                                                        HO_GUBUN,		");
		sql.append("	       'Y'                                                                               RETRIEVE_YN,	");
		sql.append("	       IFNULL(A.HO_CODE_NAME, '')														 HO_CODE_NAME,	");
		sql.append("	       IFNULL(A.HO_SORT, '')														     HO_SORT,			");
		sql.append("	       IFNULL(A.REPORT_TOTAL_BED, '')														 REPORT_TOTAL_BED,	");
		sql.append("	       IFNULL(A.DOUBLE_HO_YN, 'N')                                                       DOUBLE_HO_YN,		");
		sql.append("	       CASE WHEN A.END_DATE < STR_TO_DATE(:f_jukyong_date, '%Y/%m/%d') THEN									");
		sql.append("	            'Y'																								");
		sql.append("	       ELSE 'N' END                                             END_YN										");
		sql.append("	FROM BAS0250 A																								");
		sql.append("	LEFT JOIN BAS0251 B ON A.HOSP_CODE = B.HOSP_CODE															");
		sql.append("	                   AND A.HO_GRADE  = B.HO_GRADE																");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																			");
		sql.append("	  AND A.HO_DONG   = :f_ho_dong																				");
		sql.append("	  AND A.START_DATE = (SELECT MAX(Z.START_DATE)																");
		sql.append("	                       FROM BAS0250 Z																		");
		sql.append("	                      WHERE Z.HOSP_CODE = A.HOSP_CODE														");
		sql.append("	                        AND Z.HO_DONG   = A.HO_DONG															");
		sql.append("	                        AND Z.HO_CODE   = A.HO_CODE															");
		sql.append("	                        AND Z.START_DATE <=  STR_TO_DATE(:f_jukyong_date, '%Y/%m/%d'))						");
		sql.append("	ORDER BY A.HO_CODE ASC																						");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jukyong_date", jukyongDate);
		query.setParameter("f_ho_dong", hoDong);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<BAS0250U00GrdHoCodeListInfo> lstResult = new JpaResultMapper().list(query, BAS0250U00GrdHoCodeListInfo.class);
		return lstResult;
	}

	@Override
	@CacheEvict(value = "Bas0250Repository", allEntries = true)
	public Integer updateTableBas0250(String hospCode, String updId, String startDate, String hoCode, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE BAS0250 SET upd_id = :f_upd_id												");
		sql.append("	     , upd_date = SYSDATE()															");
		sql.append("	     , end_date = DATE_ADD(STR_TO_DATE(:f_start_date,'%Y/%m/%d'), INTERVAL -1 DAY) 	");
		sql.append("	WHERE hosp_code = :f_hosp_code 														");
		sql.append("	  AND ho_code = :f_ho_code 															");
		sql.append("	  AND ho_dong = :f_ho_dong 															");
		sql.append("	  AND end_date = STR_TO_DATE('9998/12/31','%Y/%m/%d') 								");
		sql.append("	  AND STR_TO_DATE(:f_start_date,'%Y/%m/%d') BETWEEN start_date AND end_date			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_upd_id", updId);
		query.setParameter("f_start_date", startDate);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_ho_dong", hoDong);
		
		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Bas0250Repository", allEntries = true)
	public Integer updateTableBas0250CaseDelete(String hospCode, String updId, String startDate, String hoCode,
			String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE BAS0250 																		");
		sql.append("	SET  upd_Id = :f_upd_id																");
		sql.append("	   , upd_Date = SYSDATE()															");
		sql.append("	   , end_Date = STR_TO_DATE('9998/12/31','%Y/%m/%d') 								");
		sql.append("	WHERE hosp_code = :f_hosp_code 														");
		sql.append("	AND ho_code = :f_ho_code 															");
		sql.append("	AND ho_dong = :f_ho_dong 															");
		sql.append("	AND end_date = DATE_ADD(STR_TO_DATE(:f_start_date,'%Y/%m/%d'), INTERVAL -1 DAY) 	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_upd_id", updId);
		query.setParameter("f_start_date", startDate);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_ho_dong", hoDong);
		
		return query.executeUpdate();
	}

	@Override
	public List<String> getINP2004Q00grdHoCodeListInfo(String hospCode, String hoDong, String jukyongDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  DISTINCT								");
		sql.append("	        A.HO_CODE          						");
		sql.append("	   FROM BAS0250 A								");
		sql.append("	  WHERE A.HOSP_CODE    = :f_hosp_code			");
		sql.append("	    AND A.HO_DONG      = :f_ho_dong				");
		sql.append("	  ORDER BY A.HO_CODE ASC						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<String> listResult= query.getResultList();
		return listResult;
	}

	@Override
	public List<Bas0250> findByHoCodeHoDongFDate(String hospCode, String hoCode, String hoDong, String ipwonDate) {
		String sql = "SELECT T FROM Bas0250 T WHERE T.hospCode = :f_hosp_code AND T.hoCode = :f_ho_code AND T.hoDong = :f_ho_dong AND STR_TO_DATE(:f_ipwon_date,'%Y/%m/%d') BETWEEN T.startDate AND T.endDate ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		return query.getResultList();
	}

	@Override
	public String checkHospitalBedIsPossible(String hospCode, String hoCode, String bedNo, String hoDong,
			String ipwonDate) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT 'Y'																							");
		sql.append("	FROM DUAL																							");
		sql.append("	WHERE EXISTS (SELECT 'X'																			");
		sql.append("	              FROM BAS0250 B																		");
		sql.append("	              JOIN BAS0253 A ON B.HOSP_CODE = A.HOSP_CODE 											");
		sql.append("	                            AND A.HO_CODE   = B.HO_CODE												");
		sql.append("	                            AND A.HO_DONG   = B.HO_DONG												");
		sql.append("	              WHERE A.HOSP_CODE = :f_hosp_code														");
		sql.append("	               AND A.HO_CODE    = :f_ho_code1														");
		sql.append("	               AND A.BED_NO     = :f_bed_no 														");
		sql.append("	               AND B.HO_DONG    = :f_ho_dong1														");
		sql.append("	               AND A.BED_STATUS NOT IN ('00', '01') 												");
		sql.append("	               AND STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d') BETWEEN B.START_DATE AND B.END_DATE)		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_code1", hoCode);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_ho_dong1", hoDong);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		List<String> listResult = query.getResultList();
		return CollectionUtils.isEmpty(listResult) ? "" : listResult.get(0);
	}
	
	@Override
	public List<ComboListItemInfo> getINP1003U00grdInpReserGridColumnChangeddtHoSil(String hospCode, String hoCodeYmd, String hoDong,
			String hoCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																						");
		sql.append("		DISTINCT 																				");
		sql.append("		A.HO_CODE 			HO_CODE,															");
		sql.append("		A.HO_DONG 			HO_DONG																");
		sql.append("	FROM																						");
		sql.append("		BAS0250 A																				");
		sql.append("	WHERE																						");
		sql.append("		A.HOSP_CODE  		= :f_hosp_code														");
		sql.append("		AND STR_TO_DATE(:f_ho_code_ymd,'%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE			");
		sql.append("		AND A.HO_CODE    	= :f_ho_code														");
		sql.append("		AND A.HO_DONG LIKE :f_ho_dong															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_code_ymd", hoCodeYmd);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public String inp1001U00CheckExist(String hospCode, String hoDong, String hoCode, Date silIpwonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT 'Y'																");
		sql.append("       FROM DUAL															");
		sql.append("      WHERE EXISTS (SELECT 'X'												");
		sql.append("                FROM BAS0250 A												");
		sql.append("              WHERE A.HOSP_CODE        = :f_hosp_code						");
		sql.append("                AND A.HO_DONG          = :f_ho_dong1						");
		sql.append("                AND A.HO_CODE          = :f_ho_code1						");
		sql.append("                AND :f_sil_ipwon_date  BETWEEN A.START_DATE					");
		sql.append("                                           AND A.END_DATE)					");
	
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
	public String inp1001U01CheckBedIsPossible(String hospCode, String hoCode, String bedNo, String hoDong, Date silIpwonDate) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT 'Y'																							");
		sql.append("	FROM DUAL																							");
		sql.append("	WHERE EXISTS (SELECT 'X'																			");
		sql.append("	              FROM BAS0250 B																		");
		sql.append("	              JOIN BAS0253 A ON B.HOSP_CODE = A.HOSP_CODE 											");
		sql.append("	                            AND A.HO_CODE   = B.HO_CODE												");
		sql.append("	                            AND A.HO_DONG   = B.HO_DONG												");
		sql.append("	              WHERE A.HOSP_CODE = :f_hosp_code														");
		sql.append("	               AND A.HO_CODE    = :f_ho_code1														");
		sql.append("	               AND A.BED_NO     = :f_bed_no 														");
		sql.append("	               AND B.HO_DONG    = :f_ho_dong1														");
		sql.append("	               AND A.BED_STATUS NOT IN ('00', '01', '02', '03') 									");
		sql.append("	               AND :f_sil_ipwon_date 					BETWEEN B.START_DATE AND B.END_DATE)		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_code1", hoCode);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_ho_dong1", hoDong);
		query.setParameter("f_sil_ipwon_date", silIpwonDate);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<BAS0250Q00grdHOBEDInfo> getBAS0250Q00grdHOBEDInfoList(String hospCode, String hoDong, Date hoCodeYmd, String gumjinHodongYn) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_DONG																				");
		sql.append("	     , A.HO_CODE																				");
		sql.append("	     , CAST(A.HO_TOTAL_BED AS CHAR)																");
		sql.append("	     , A.HO_GRADE																				");
		sql.append("	     , A.HO_STATUS																				");
		sql.append("	  FROM BAS0250 A																				");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code																");
		sql.append("	   AND A.HO_DONG     = :f_ho_dong																");
		sql.append("	   AND :f_ho_code_ymd BETWEEN A.START_DATE AND A.END_DATE										");
		sql.append("	   AND IFNULL(A.DOUBLE_HO_YN, 'N') = 'N'														");
		sql.append("	   AND ( 																						");
		sql.append("	          (  																					");
		sql.append("	             IFNULL(:f_gumjin_hodong_yn, 'N') = 'Y'												");
		sql.append("	             AND																				");
		sql.append("	             A.HO_STATUS IN ('H')																");
		sql.append("	          )																						");
		sql.append("	          OR																					");
		sql.append("	          (																						");
		sql.append("	             IFNULL(:f_gumjin_hodong_yn, 'N') = 'N'												");
		sql.append("	             AND 																				");
		sql.append("	             A.HO_STATUS NOT IN ('H')															");
		sql.append("	          )																						");
		sql.append("	       )																						");
		sql.append("	 ORDER BY A.HO_CODE																				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code_ymd", hoCodeYmd);
		query.setParameter("f_gumjin_hodong_yn", gumjinHodongYn);
		
		List<BAS0250Q00grdHOBEDInfo> list = new JpaResultMapper().list(query, BAS0250Q00grdHOBEDInfo.class);
		return list;
	}
	
	@Override
	public List<DataStringListItemInfo> getBAS0250Q00layMaxBedNoInfoList(String hospCode, String hoDong, Date hoCodeYmd) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT															");
		sql.append("		CAST(MAX(A.HO_TOTAL_BED) as CHAR)							");
		sql.append("    FROM															");
		sql.append("    	BAS0250 A													");
		sql.append("    WHERE															");
		sql.append("    	A.HOSP_CODE         = :f_hosp_code							");
		sql.append("        AND A.HO_DONG   	= :f_ho_dong							");
		sql.append("        AND :f_ho_code_ymd 	BETWEEN A.START_DATE AND A.END_DATE		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code_ymd", hoCodeYmd);
		
		List<DataStringListItemInfo> lstResult = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return lstResult;
	}
	
	@Override
	public void callPrBas2050Refresh(String hospCode, String hoDong){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_BAS_BAS0250_REFRESH");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HO_DONG", String.class, ParameterMode.IN);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_HO_DONG", hoDong);
		query.execute();		
	}

	@Override
	public List<ComboListItemInfo> getNUR2004U00layHoSex(String hospCode, String hoCode, String hoDong, Date date) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																");
		sql.append("		A.HO_CODE,														");
		sql.append("	    A.HO_SEX														");
		sql.append("	FROM																");
		sql.append("		BAS0250 A														");
		sql.append("	WHERE																");
		sql.append("		A.HOSP_CODE 	= :f_hosp_code									");
		sql.append("	   	AND A.HO_DONG   = :f_ho_dong									");
		sql.append("	   	AND A.HO_CODE   = :f_ho_code									");
		sql.append("	   	AND :f_date 	BETWEEN A.START_DATE AND A.END_DATE				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_date", date);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<ComboListItemInfo> getNUR2004U00cboToKaikei(String hospCode, String kaikeiHodong) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT											");
		sql.append("		HO_CODE,									");
		sql.append("		HO_CODE ho_code2							");
		sql.append("	FROM											");
		sql.append("		BAS0250 									");
		sql.append("	WHERE											");
		sql.append("		HOSP_CODE 	= :f_hosp_code					");
		sql.append("	   	AND HO_DONG = :f_kaikei_hodong				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_kaikei_hodong", kaikeiHodong);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<ComboListItemInfo> getComboListItemInfo(String hospCode, String date, String hoDong) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																								");
		sql.append("		A.HO_CODE  						hocode,															");
		sql.append("	  	B.HO_GRADE_NAME																					");
		sql.append("	FROM																								");
		sql.append("		BAS0250 A 	JOIN 	BAS0251 B																	");
		sql.append("					ON 		B.HOSP_CODE = A.HOSP_CODE													");
		sql.append("	   				AND 	B.HO_GRADE  = A.HO_GRADE													");
		sql.append("	WHERE																								");
		sql.append("	 	A.HOSP_CODE 		= :f_hosp_code																");
		sql.append("	   	AND B.START_DATE 	= (	SELECT MAX(X.START_DATE) 												");
		sql.append("	                         	FROM BAS0251 X 															");
		sql.append("	                        	WHERE X.HOSP_CODE 		= B.HOSP_CODE 									");
		sql.append("	                          		AND X.HO_GRADE  	= B.HO_GRADE 									");
		sql.append("	                          		AND X.START_DATE 	<= STR_TO_DATE(:f_date, '%Y/%m/%d'))			");
		sql.append("	   	AND STR_TO_DATE(:f_date, '%Y/%m/%d') 			BETWEEN A.START_DATE AND A.END_DATE				");
		sql.append("	   	AND A.HO_DONG 		= :f_hodong																	");
		sql.append("	ORDER BY 1																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		query.setParameter("f_hodong", hoDong);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR2004U00layValidCheckHocodeInfo> getNUR2004U00layValidCheckHocode(String hospCode, String hoDong, String code, String date) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																					");
		sql.append("		A.HO_CODE,																			");
		sql.append("		CAST(A.HO_TOTAL_BED AS CHAR),														");
		sql.append("		A.HO_GRADE																			");
		sql.append("	FROM																					");
		sql.append("		BAS0250 A 																			");
		sql.append("	WHERE																					");
		sql.append("		A.HOSP_CODE  						= :f_hosp_code									");
		sql.append("		AND A.HO_DONG 						LIKE :f_hodong									");
		sql.append("		AND A.HO_CODE 						LIKE :f_code									");
		sql.append("	AND STR_TO_DATE(:f_date, '%Y/%m/%d') 	BETWEEN A.START_DATE AND A.END_DATE				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hodong", hoDong);
		query.setParameter("f_code", code);
		query.setParameter("f_date", date);
		
		List<NUR2004U00layValidCheckHocodeInfo> listInfo = new JpaResultMapper().list(query, NUR2004U00layValidCheckHocodeInfo.class);
		return listInfo;
	}

	@Override
	public List<ComboListItemInfo> getNUR2004U00fbxToHoCode(String hospCode, String date, String hoDong) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT																								");
		sql.append("		A.HO_CODE  												hocode,									");
		sql.append("	  	B.HO_GRADE_NAME																					");
		sql.append("	FROM																								");
		sql.append("		BAS0250 A 	JOIN 	BAS0251 B																	");
		sql.append("					ON 		B.HOSP_CODE = A.HOSP_CODE													");
		sql.append("	   				AND 	B.HO_GRADE  = A.HO_GRADE													");
		sql.append("	WHERE																								");
		sql.append("	 	A.HOSP_CODE 		= :f_hosp_code																");
		sql.append("	   	AND B.START_DATE 	= (	SELECT MAX(X.START_DATE) 												");
		sql.append("	                         	FROM BAS0251 X 															");
		sql.append("	                        	WHERE X.HOSP_CODE = B.HOSP_CODE 										");
		sql.append("	                          		AND X.HO_GRADE  = B.HO_GRADE 										");
		sql.append("	                          		AND X.START_DATE <= STR_TO_DATE(:f_date, '%Y/%m/%d'))				");
		sql.append("	   AND STR_TO_DATE(:f_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE							");
		sql.append("	   AND A.HO_DONG 		= :f_hodong																	");
		sql.append("	 ORDER BY 1																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		query.setParameter("f_hodong", hoDong);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<DataStringListItemInfo> getNUR2004U00getHograde(String hospCode, String toHoDong1, String toHoCode1, String junpyoDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																		");
		sql.append("		A.HO_GRADE   HO_GRADE																													");
		sql.append("	FROM																																		");
		sql.append("		BAS0250 A																																");
		sql.append("	WHERE																																		");
		sql.append("		A.HOSP_CODE = :f_hosp_code                                            																	");
		sql.append("		AND A.HO_DONG   = :f_to_ho_dong1																										");
		sql.append("		AND A.HO_CODE   = :f_to_ho_code1																										");
		sql.append("		AND IFNULL(STR_TO_DATE(:f_junpyo_date,'%Y/%m/%d'), CURRENT_DATE()) BETWEEN A.START_DATE AND A.END_DATE									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_to_ho_dong1", toHoDong1);
		query.setParameter("f_to_ho_code1", toHoCode1);
		query.setParameter("f_junpyo_date", junpyoDate);
		
		List<DataStringListItemInfo> listInfo = new JpaResultMapper().list(query, DataStringListItemInfo.class);
		return listInfo;
	}
	
	@Override
	public String getHoTotalBedByHospCodeHoCode(String hospCode, String hoCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.HO_TOTAL_BED AS CHAR)						 ");
		sql.append("	FROM BAS0250 A											 ");
		sql.append("    WHERE A.HOSP_CODE    = :f_hosp_code						 ");
		sql.append("      AND A.HO_CODE      = :f_ho_code						 ");
		sql.append("      AND CURRENT_DATE() BETWEEN A.START_DATE AND A.END_DATE ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_code", hoCode);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}
	
	@Override
	public List<NUR1010Q00layHosilListInfo> getNUR1010Q00layHosilListInfo(String hospCode, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.HO_CODE                                                                                           ");
		sql.append("         ,CASE(IFNULL(A.HO_SPECIAL_YN, 'N')) WHEN '' THEN '1' WHEN 'N' THEN '1' ELSE '2' END HO_STATUS        ");
		sql.append("         ,CAST(CASE WHEN IFNULL(HO_TOTAL_BED,0) >= IFNULL(HO_USED_BED,0) THEN IFNULL(HO_TOTAL_BED,0)          ");
		sql.append("               ELSE IFNULL(HO_USED_BED,0)                                                                     ");
		sql.append("               END AS CHAR) AS HO_BED_COUNT                                                                   ");
		sql.append("         ,A.HO_SEX                                                                                            ");
		sql.append("         ,A.HO_CODE_NAME                                                                                      ");
		sql.append("         ,A.DOUBLE_HO_YN                                                                                      ");
		sql.append("         ,IFNULL(CAST(A.HO_SORT AS CHAR), '')																  ");
		sql.append("     FROM BAS0250 A                                                                                           ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                                          ");
		sql.append("      AND A.HO_DONG   = :f_ho_dong                                                                            ");
		sql.append("      AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                                                       ");
		sql.append("    ORDER BY A.HO_SORT                                                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUR1010Q00layHosilListInfo> listInfo = new JpaResultMapper().list(query, NUR1010Q00layHosilListInfo.class);
		return listInfo;
		
	}
	
	@Override
	public List<NUR1010Q00layBedListInfo> getNUR1010Q00layBedListInfo(String hospCode, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.HO_DONG,                                                                                                ");
		sql.append("          A.HO_CODE,                                                                                                ");
		sql.append("          A.BED_NO BED_NO,                                                                                          ");
		sql.append("          B.TEAM                                                                                                    ");
		sql.append("     FROM BAS0250 B                                                                                                 ");
		sql.append("     JOIN BAS0253 A                                                                                                 ");
		sql.append("       ON A.HOSP_CODE = B.HOSP_CODE                                                                                 ");
		sql.append("      AND A.HO_DONG   = B.HO_DONG                                                                                   ");
		sql.append("      AND A.HO_CODE   = B.HO_CODE                                                                                   ");
		sql.append("    WHERE B.HOSP_CODE = :f_hosp_code                                                                                ");
		sql.append("      AND B.HO_DONG   = :f_ho_dong                                                                                  ");
		sql.append("      AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE                                                             ");
		sql.append("      AND SYSDATE() BETWEEN A.FROM_BED_DATE AND IFNULL(A.TO_BED_DATE,STR_TO_DATE('9998/12/31','%Y/%m/%d'))          ");
		sql.append("    ORDER BY B.HO_SORT,B.HO_CODE,LPAD(A.BED_NO,2,'0')                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUR1010Q00layBedListInfo> listInfo = new JpaResultMapper().list(query, NUR1010Q00layBedListInfo.class);
		return listInfo;		
	}
	
	@Override
	public List<ComboListItemInfo> getNUR1010Q00SelectMancnt(String hospCode, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(IFNULL(SUM(A.HO_SEX_MAIL),0) AS CHAR) MAN_CNT              ");
		sql.append("        , CAST(IFNULL(SUM(A.HO_SEX_FEMAIL),0) AS CHAR) WOMAN_CNT          ");
		sql.append("     FROM BAS0250 A                                                       ");
		sql.append("     WHERE A.HOSP_CODE = :f_hosp_code                                     ");
		sql.append("       AND A.HO_DONG   = :f_ho_dong                                       ");
		sql.append("       AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;		
	}
	
	@Override
	public List<NUR1010Q00SelectHosexInfo> getNUR1010Q00SelectHosexInfo(String hospCode, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT IFNULL(A.HO_SEX,'C') HO_SEX                                          ");
		sql.append("         ,IFNULL(A.HO_SPECIAL_YN,'N') HO_SPECIAL_YN                            ");
		sql.append("         ,CAST(IFNULL(SUM(A.HO_TOTAL_BED),0) AS CHAR) TOTAL_BED                ");
		sql.append("         ,CAST(IFNULL(SUM(A.HO_USED_BED),0) AS CHAR) USED_BED                  ");
		sql.append("     FROM BAS0250 A                                                            ");
		sql.append("    WHERE A.HOSP_CODE  = :f_hosp_code                                          ");
		sql.append("      AND A.HO_DONG    = :f_ho_dong                                            ");
		sql.append("      AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                        ");
		sql.append("    GROUP BY IFNULL(A.HO_SEX,'C'), IFNULL(A.HO_SPECIAL_YN,'N')                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUR1010Q00SelectHosexInfo> listInfo = new JpaResultMapper().list(query, NUR1010Q00SelectHosexInfo.class);
		return listInfo;		
	}
	
	@Override
	public List<String> getNUR1010Q00ChangeMoveHosilSelect2(String hospCode, String junpyoDate, String toHoCode, String toHoDong){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.HO_GRADE       HO_GRADE                                ");
		sql.append("   FROM BAS0250 A                                                ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                               ");
		sql.append("    AND A.HO_DONG   = :f_to_ho_dong                              ");
		sql.append("    AND A.HO_CODE   = :f_to_ho_code                              ");
		sql.append("    AND :f_junpyo_date BETWEEN A.START_DATE AND A.END_DATE       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_to_ho_dong", toHoDong);
		query.setParameter("f_to_ho_code", toHoCode);
		query.setParameter("f_junpyo_date", junpyoDate);
		
		List<String> result = query.getResultList();
		
		return result;
	}
	
	@Override
	public String checkNUR1010Q00isExistBas2050(String hospCode, String toHoCode, String toHoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                 ");
		sql.append("     FROM DUAL                                                                ");
		sql.append("    WHERE EXISTS (SELECT 'X'                                                  ");
		sql.append("                    FROM BAS0250 A                                            ");
		sql.append("                   WHERE A.HOSP_CODE          = :f_hosp_code                  ");
		sql.append("                     AND A.HO_DONG            = :f_to_ho_dong                 ");
		sql.append("                     AND A.HO_CODE            = :f_to_ho_code                 ");
		sql.append("                     AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE        ");
		sql.append("                     AND A.DOUBLE_HO_YN       = 'Y')                          ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_to_ho_dong", toHoDong);
		query.setParameter("f_to_ho_code", toHoCode);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}

}
