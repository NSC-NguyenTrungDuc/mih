package nta.med.data.dao.medi.bas.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0253RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0250Q00layBedStatusInfo;
import nta.med.data.model.ihis.bass.BAS0250U00GrdBAS0253Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public class Bas0253RepositoryImpl implements Bas0253RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<BAS0250U00GrdBAS0253Info> getBAS0250U00GrdBAS0253InfoList(String hospCode, String hoDong, String hoCode,
			Integer startNum, Integer offset) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_CODE								");
		sql.append("	     , A.BED_NO									");
		sql.append("	     , IFNULL(DATE_FORMAT(A.FROM_BED_DATE, '%Y/%m/%d'), '')		");
		sql.append("	     , IFNULL(DATE_FORMAT(A.TO_BED_DATE, '%Y/%m/%d'), '')		");
		sql.append("	     , A.BED_STATUS								");
		sql.append("	     , A.BED_NO_TEL								");
		sql.append("	     , A.HO_DONG								");
		sql.append("	  FROM BAS0253 A								");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code				");
		sql.append("	   AND A.HO_DONG   = :f_ho_dong					");
		sql.append("	   AND A.HO_CODE   = :f_ho_code					");
		sql.append("	 ORDER BY CONCAT(A.HO_CODE, A.BED_NO, DATE_FORMAT(A.FROM_BED_DATE, '%Y/%m/%d'))");
		if(startNum != null && offset !=null){
			sql.append("	 LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<BAS0250U00GrdBAS0253Info> lstResult = new JpaResultMapper().list(query, BAS0250U00GrdBAS0253Info.class);
		return lstResult;		
	}

	@Override
	public Integer updateTableBas0253(String hospCode, String updId, String fromBedDate, String hoCode, String hoDong, String bedNo) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE BAS0253 SET upd_id = :f_upd_id														");
		sql.append("	     , upd_date = SYSDATE()																	");
		sql.append("	     , to_bed_date = DATE_ADD(STR_TO_DATE(:f_from_bed_date, '%Y/%m/%d'), INTERVAL -1 DAY)	");
		sql.append("	 WHERE hosp_code = :f_hosp_code 															");
		sql.append("	 AND ho_code = :f_ho_code 																	");
		sql.append("	 AND ho_dong = :f_ho_dong 																	");
		sql.append("	 AND bed_no = :f_bed_no 																	");
		sql.append("	 AND to_bed_date = STR_TO_DATE('9998/12/31','%Y/%m/%d') 									");
		sql.append("	 AND STR_TO_DATE(:f_from_bed_date,'%Y/%m/%d') BETWEEN from_bed_date AND to_bed_date			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_upd_id", updId);
		query.setParameter("f_from_bed_date", fromBedDate);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_bed_no", bedNo);
		
		return query.executeUpdate();
	}

	@Override
	public Integer updateTableBas0253CaseDelete(String hospCode, String updId, String fromBedDate, String hoCode,
			String hoDong, String bedNo) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE BAS0253 																			");
		sql.append("	SET  upd_id = :f_upd_id																	");
		sql.append("	   , upd_date = SYSDATE()																");
		sql.append("	   , to_bed_date = STR_TO_DATE('9998/12/31','%Y/%m/%d') 								");
		sql.append("	 WHERE hosp_code = :f_hosp_code 														");
		sql.append("	 AND ho_code = :f_ho_code 																");
		sql.append("	 AND ho_dong = :f_ho_dong 																");
		sql.append("	 AND bed_no = :f_bed_no 																");
		sql.append("	 AND to_bed_date = DATE_ADD(STR_TO_DATE(:f_from_bed_date,'%Y/%m/%d'), INTERVAL -1 DAY) 	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_upd_id", updId);
		query.setParameter("f_from_bed_date", fromBedDate);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_bed_no", bedNo);
		
		return query.executeUpdate();
	}
	
	@Override
	public String checkExistByHospCodeHoDongHoCodeBedNoIpwonDate(String hospCode, String hoDong, String hoCode, String bedNo, String ipwonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'X'																																	");
		sql.append("	FROM BAS0253 A																																");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																											");
		sql.append("	  AND A.HO_DONG   = :f_ho_dong1																												");
		sql.append("	  AND A.HO_CODE   = :f_ho_code1																												");
		sql.append("	  AND A.BED_NO    = :f_bed_no																												");
		sql.append("	  AND STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d') BETWEEN A.FROM_BED_DATE AND IFNULL(A.TO_BED_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong1", hoDong);
		query.setParameter("f_ho_code1", hoCode);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		List<String> lstResult = query.getResultList();
		return CollectionUtils.isEmpty(lstResult) ? "" : lstResult.get(0);
	}
	
	@Override
	public String inp1001U01CheckIsExist(String hospCode, String hoDong, String hoCode, String bedNo, Date silIpwonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT 'Y'																												");
		sql.append("       FROM DUAL																											");
		sql.append("      WHERE EXISTS ( SELECT 'X'																								");
		sql.append("               FROM BAS0253 A																								");
		sql.append("              WHERE A.HOSP_CODE        = :f_hosp_code																		");
		sql.append("                AND A.HO_DONG          = :f_ho_dong1																		");
		sql.append("                AND A.HO_CODE          = :f_ho_code1																		");
		sql.append("                AND A.BED_NO           = :f_bed_no																			");
		sql.append("                AND :f_sil_ipwon_date  BETWEEN A.FROM_BED_DATE																");
		sql.append("                                           AND IFNULL(A.TO_BED_DATE, DATE_FORMAT('9998/12/31', '%Y/%m/%d')))				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong1", hoDong);
		query.setParameter("f_ho_code1", hoCode);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_sil_ipwon_date", silIpwonDate);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<BAS0250Q00layBedStatusInfo> getBAS0250Q00layBedStatusInfoList(String hospCode, Date hoCodeYmd, String hoDong) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT B.HO_DONG																									");
		sql.append("	     , A.HO_CODE																									");
		sql.append("	     , A.BED_NO																										");
		sql.append("	     , A.BED_STATUS																									");
		sql.append("	     , C.CODE_NAME																									");
		sql.append("	     , IFNULL(DATE_FORMAT(A.FROM_BED_DATE, '%Y/%m/%d'), '')															");
		sql.append("	  FROM   BAS0253 A																									");
		sql.append("   LEFT OUTER JOIN BAS0102 C ON C.HOSP_CODE = A.HOSP_CODE AND A.BED_STATUS = C.CODE AND C.CODE_TYPE = 'BED_STATUS',	    ");
		sql.append("	  	     BAS0250 B																									");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code																					");
		sql.append("	 AND B.HOSP_CODE    = A.HOSP_CODE 																					");
		sql.append("	    AND A.BED_STATUS NOT IN ('00', '01', '02', '03') 																");
		sql.append("	    AND :f_ho_code_ymd BETWEEN A.FROM_BED_DATE AND IFNULL(A.TO_BED_DATE, '9998/12/31') 								");
		sql.append("	    AND A.HO_CODE      = B.HO_CODE 																					");
		sql.append("	    AND :f_ho_code_ymd BETWEEN B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31') 									");
		sql.append("	    AND B.HO_DONG      = :f_ho_dong 																				");
		sql.append("	    AND A.HO_DONG = B.HO_DONG 																						");
		sql.append("	  ORDER BY A.HO_CODE, A.BED_NO 																						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_code_ymd", hoCodeYmd);
		query.setParameter("f_ho_dong", hoDong);
		
		List<BAS0250Q00layBedStatusInfo> lstResult = new JpaResultMapper().list(query, BAS0250Q00layBedStatusInfo.class);
		return lstResult;		
	}

	@Override
	public List<String> getBedNoNUR2004U01(String hospCode, String hoDong, String hoCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BED_NO                                                                              ");
		sql.append("	FROM BAS0253 A                                                                               ");
		sql.append("	,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                              ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                             ");
		sql.append("	  AND A.HO_DONG   = :f_ho_dong                                                               ");
		sql.append("	  AND A.HO_CODE   = :f_ho_code                                                               ");
		sql.append("	  AND CURRENT_DATE() BETWEEN DATE(A.FROM_BED_DATE)                                           ");
		sql.append("	                      AND DATE(IFNULL(A.TO_BED_DATE, STR_TO_DATE('9999/12/31', '%Y/%m/%d'))) ");
		sql.append("	  AND A.BED_STATUS IN ( '00', '01')                                                          ");
		sql.append("	  AND A.BED_NO NOT IN (SELECT B.BED_NO                                                       ");
		sql.append("	                        FROM VW_OCS_INP1001_01 B                                             ");
		sql.append("	                       WHERE B.HOSP_CODE = A.HOSP_CODE                                       ");
		sql.append("	                         AND B.HO_DONG1 = A.HO_DONG                                          ");
		sql.append("	                         AND B.HO_CODE1 = A.HO_CODE                                          ");
		sql.append("	                         AND B.JAEWON_FLAG = 'Y')                                            ");
		sql.append("	ORDER BY A.BED_NO                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		
		List<String> lstResult = query.getResultList();
		return lstResult;
	}
	
	@Override
	public String getNUR2004U01GetSubConfirmData2 (String hospCode, String hoDong, String hoCode, String bedNo){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                                           ");
		sql.append("    FROM DUAL                                                                                           ");
		sql.append("   WHERE EXISTS (SELECT 'X'                                                                             ");
		sql.append("                   FROM BAS0253 B                                                                       ");
		sql.append("                  WHERE B.HOSP_CODE = :f_hosp_code                                                      ");
		sql.append("                    AND B.HO_DONG   = :f_to_ho_dong1                                                    ");
		sql.append("                    AND B.HO_CODE   = :f_to_ho_code1                                                    ");
		sql.append("                    AND B.BED_NO    = :f_to_bed_no                                                      ");
		sql.append("                    AND B.BED_STATUS   IN ('00', '01')                                                  ");
		sql.append("                    AND SYSDATE() BETWEEN B.FROM_BED_DATE                                               ");
		sql.append("                        AND CASE(B.TO_BED_DATE) WHEN '' THEN STR_TO_DATE('99991231', '%Y%m%d') ELSE     ");
		sql.append("                        IFNULL(TO_BED_DATE, STR_TO_DATE('99991231', '%Y%m%d')) END)                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_to_ho_dong1", hoDong);
		query.setParameter("f_to_ho_code1", hoCode);
		query.setParameter("f_to_bed_no", bedNo);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public List<ComboListItemInfo> getNUR2004U00layHocodeBednoRequest(String hospCode, String hoDong, String hoCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.BED_NO, A.BED_STATUS																					");
		sql.append("	FROM BAS0253 A                                                                                               	");
		sql.append("	WHERE A.HOSP_CODE 							= :f_hosp_code														");
		sql.append("	  AND A.HO_DONG   							= :f_ho_dong														");
		sql.append("	  AND A.HO_CODE   							= :f_ho_code														");
		sql.append("	  AND CURRENT_DATE() BETWEEN A.FROM_BED_DATE AND IFNULL(A.TO_BED_DATE, STR_TO_DATE('9999/12/31', '%Y/%m/%d'))	");
		sql.append("	  AND A.BED_STATUS 							!= '05'																");
		sql.append("	ORDER BY A.BED_NO																	                         	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

}

