package nta.med.data.dao.medi.inp.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inp.Inp1004RepositoryCustom;
import nta.med.data.model.ihis.inps.INP1001Q00grdINP1001Info;
import nta.med.data.model.ihis.inps.INP1001U01GrdInp1004Info;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdINP1004Info;

/**
 * @author dainguyen.
 */
public class Inp1004RepositoryImpl implements Inp1004RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<INP1001U01GrdInp1004Info> getINP1001U01GrdInp1004Info(String hospCode, String language, String bunho,
			Integer startNum, Integer offset) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.PRIORITY, ''),																								");
		sql.append("	       A.BUNHO,																												");
		sql.append("	       IFNULL(A.NAME, ''),																									");
		sql.append("	       IFNULL(A.ZIP_CODE1, ''),																								");
		sql.append("	       IFNULL(A.ZIP_CODE2, ''),																								");
		sql.append("	       IFNULL(A.ADDRESS1, ''),																								");
		sql.append("	       IFNULL(A.ADDRESS2, ''),																								");
		sql.append("	       IFNULL(A.TEL1, ''),																									");
		sql.append("	       IFNULL(A.TEL2, ''),																									");
		sql.append("	       IFNULL(A.TEL3, ''),																									");
		sql.append("	       IFNULL(A.BIGO, ''),																									");
		sql.append("	       IFNULL(A.BONIN_GUBUN, ''),																							");
		sql.append("	       IFNULL(FN_BAS_LOAD_CODE_NAME('BONIN_GUBUN',A.BONIN_GUBUN, :f_hosp_code, :f_language), '')    BONIN_GUBUN_NAME,		");
		sql.append("	       IFNULL(A.SEQ, '')                                                                            SEQ_1,					");
		sql.append("	       IFNULL(A.TEL_GUBUN, ''),																								");
		sql.append("	       IFNULL(A.TEL_GUBUN2, ''),																							");
		sql.append("	       IFNULL(A.TEL_GUBUN3, ''),																							");
		sql.append("	       'Y'                                                                                          RETRIEVE_YN,			");
		sql.append("	       IFNULL(A.NAME2, '')                                                                          NAME2, 					");
		sql.append("	       IF(A.BIRTH IS NULL, '', STR_TO_DATE(A.BIRTH, '%Y/%m/%d'))                                    BIRTH,					");
		sql.append("	       CAST(FN_BAS_LOAD_AGE(SYSDATE(), A.BIRTH, '') AS CHAR)                                        AGE,					");
		sql.append("	       IFNULL(A.WITH_YN, 'Y')                                                                       WITH_YN,				");
		sql.append("	       IFNULL(A.LIVE_YN, 'Y')                                                                       LIVE_YN,				");
		sql.append("	       IFNULL(A.SEQ, '')                                                                            SEQ_2					");
		sql.append("	  FROM INP1004  A																											");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code																							");
		sql.append("	   AND A.BUNHO     = :f_bunho																								");
		sql.append("	 ORDER BY A.PRIORITY																										");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																									");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1001U01GrdInp1004Info> lstResult = new JpaResultMapper().list(query, INP1001U01GrdInp1004Info.class);
		return lstResult;
	}

	@Override
	public Double getNextSeqInp1004ByBunho(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(MAX(A.SEQ), 0) + 1 	");
		sql.append("	FROM INP1004 A						");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code	");
		sql.append("	 AND  A.BUNHO = :f_bunho			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<Double> lstResult = query.getResultList();
		return CollectionUtils.isEmpty(lstResult) ? null : lstResult.get(0);
	}
	
	@Override
	public List<NUR1001U00GrdINP1004Info> getNUR1001U00GrdINP1004Info(String hospCode, String language, String bunho,
			Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(A.PRIORITY AS CHAR),                                                                             ");
		sql.append("          A.BUNHO,                                                                                              ");
		sql.append("          A.NAME,                                                                                               ");
		sql.append("          A.ZIP_CODE1,                                                                                          ");
		sql.append("          A.ZIP_CODE2,                                                                                          ");
		sql.append("          A.ADDRESS1,                                                                                           ");
		sql.append("          A.ADDRESS2,                                                                                           ");
		sql.append("          A.TEL1,                                                                                               ");
		sql.append("          A.TEL2,                                                                                               ");
		sql.append("          A.TEL3,                                                                                               ");
		sql.append("          A.BIGO,                                                                                               ");
		sql.append("          A.BONIN_GUBUN,                                                                                        ");
		sql.append("          FN_BAS_LOAD_CODE_NAME ( 'BONIN_GUBUN',A.BONIN_GUBUN, A.HOSP_CODE, :f_language)    BONIN_GUBUN_NAME,   ");
		sql.append("          CAST(A.SEQ AS CHAR) SEQ1,                                                                             ");
		sql.append("          A.TEL_GUBUN,                                                                                          ");
		sql.append("          A.TEL_GUBUN2,                                                                                         ");
		sql.append("          A.TEL_GUBUN3,                                                                                         ");
		sql.append("          'Y'                                                      RETRIEVE_YN,                                 ");
		sql.append("          A.NAME2,                                                                                              ");
		sql.append("          DATE_FORMAT(A.BIRTH, '%Y/%m/%d')                          BIRTH,                                      ");
		sql.append("          CAST(FN_BAS_LOAD_AGE(SYSDATE(), A.BIRTH, '') AS CHAR)          AGE,                                   ");
		sql.append("          IFNULL(A.WITH_YN, 'Y')                                         WITH_YN,                               ");
		sql.append("          IFNULL(A.LIVE_YN, 'Y')                                         LIVE_YN,                               ");
		sql.append("          CAST(A.SEQ AS CHAR) SEQ2,                                                                             ");
		sql.append("          '' DATA_ROW_STATE                                                                                     ");
		sql.append("     FROM INP1004  A                                                                                            ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                                            ");
		sql.append("      AND A.BUNHO     = :f_bunho                                                                                ");
		sql.append("    ORDER BY A.PRIORITY                                                                                         ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR1001U00GrdINP1004Info> lstResult = new JpaResultMapper().list(query, NUR1001U00GrdINP1004Info.class);
		return lstResult;
	}
}
