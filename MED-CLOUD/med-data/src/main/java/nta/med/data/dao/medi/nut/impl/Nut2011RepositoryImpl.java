package nta.med.data.dao.medi.nut.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nut.Nut2011RepositoryCustom;
import nta.med.data.model.ihis.nuts.NUT9001U00grdINP5001Info;

/**
 * @author dainguyen.
 */
public class Nut2011RepositoryImpl implements Nut2011RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUT9001U00grdINP5001Info> getNUT9001U00grdINP5001Info(String hospCode, Date magamDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT T.*                                                                                            ");
		sql.append("	  FROM (SELECT DATE_FORMAT(MAGAM_DATE, '%Y/%m/%d') 	MAGAM_DATE,                                       ");
		sql.append("	               IFNULL(CHARGE_YN, 'N')				        CHARGE_YN,                                ");
		sql.append("	               IFNULL(NUT_JO_MAGAM_YN, 'N') 		    NUT_JO_MAGAM_YN,                              ");
		sql.append("	               IFNULL(NUT_JU_MAGAM_YN, 'N') 		    NUT_JU_MAGAM_YN,                              ");
		sql.append("	               IFNULL(NUT_SEOK_MAGAM_YN, 'N') 		  NUT_SEOK_MAGAM_YN,                              ");
		sql.append("	               IFNULL(CAST(FN_NUT_GET_NUT2011_MAGAM_SEQ(A.HOSP_CODE,A.MAGAM_DATE,'1') AS CHAR), '0')  ");
		sql.append("														                          B_SEQ,                  ");
		sql.append("	               IFNULL(CAST(FN_NUT_GET_NUT2011_MAGAM_SEQ(A.HOSP_CODE,A.MAGAM_DATE,'2') AS CHAR), '0')  ");
		sql.append("														                          L_SEQ,                  ");
		sql.append("	               IFNULL(CAST(FN_NUT_GET_NUT2011_MAGAM_SEQ(A.HOSP_CODE,A.MAGAM_DATE,'3') AS CHAR), '0')  ");
		sql.append("														                          D_SEQ,                  ");
		sql.append("	               '0' 									CONT_KEY                                          ");
		sql.append("	          FROM INP5001 A                                                                              ");
		sql.append("	         WHERE A.HOSP_CODE  = :f_hosp_code                                                            ");
		sql.append("			   AND A.MAGAM_DATE = :f_magam_date                                                           ");
		sql.append("	        UNION                                                                                         ");
		sql.append("	        SELECT DATE_FORMAT(:f_magam_date, '%Y/%m/%d') 	MAGAM_DATE,                                   ");
		sql.append("	               'N' 										                  CHARGE_YN,                  ");
		sql.append("	               'N' 										                  NUT_JO_MAGAM_YN,            ");
		sql.append("	               'N' 										                  NUT_JU_MAGAM_YN,            ");
		sql.append("	               'N' 										                  NUT_SEOK_MAGAM_YN,          ");
		sql.append("	               IFNULL(CAST(B.MAGAM_SEQ AS CHAR), '0')   B_SEQ,                                        ");
		sql.append("	               IFNULL(CAST(L.MAGAM_SEQ AS CHAR), '0')   L_SEQ,                                        ");
		sql.append("	               IFNULL(CAST(D.MAGAM_SEQ AS CHAR), '0')   D_SEQ,                                        ");
		sql.append("	               '1' 										CONT_KEY                                      ");
		sql.append("	          FROM (SELECT MAX(MAGAM_SEQ) MAGAM_SEQ                                                       ");
		sql.append("	                  FROM NUT2011 A                                                                      ");
		sql.append("	                 WHERE     A.HOSP_CODE = :f_hosp_code                                                 ");
		sql.append("	                       AND A.NUT_DATE = :f_magam_date                                                 ");
		sql.append("	                       AND A.BLD_GUBUN = '1') B,                                                      ");
		sql.append("	               (SELECT MAX(MAGAM_SEQ) MAGAM_SEQ                                                       ");
		sql.append("	                  FROM NUT2011 A                                                                      ");
		sql.append("	                 WHERE     A.HOSP_CODE = :f_hosp_code                                                 ");
		sql.append("	                       AND A.NUT_DATE = :f_magam_date                                                 ");
		sql.append("	                       AND A.BLD_GUBUN = '2') L,                                                      ");
		sql.append("	               (SELECT MAX(MAGAM_SEQ) MAGAM_SEQ                                                       ");
		sql.append("	                  FROM NUT2011 A                                                                      ");
		sql.append("	                 WHERE     A.HOSP_CODE = :f_hosp_code                                                 ");
		sql.append("	                       AND A.NUT_DATE = :f_magam_date                                                 ");
		sql.append("	                       AND A.BLD_GUBUN = '3') D                                                       ");
		sql.append("		) T                                                                                               ");
		sql.append("	ORDER BY CONT_KEY                                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_magam_date", magamDate);
		
		List<NUT9001U00grdINP5001Info> lstResult = new JpaResultMapper().list(query, NUT9001U00grdINP5001Info.class);
		return lstResult;
	}

	@Override
	public String getMaxMagamSeqByHospCodeNutDateBldGubun(String hospCode, Date nutDate, String bldGubun) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(CAST(MAX(MAGAM_SEQ) AS CHAR), '') MAGAM_SEQ	");
		sql.append("	FROM NUT2011 A												");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code							");
		sql.append("	  AND A.NUT_DATE = :f_nut_date								");
		sql.append("	  AND A.BLD_GUBUN = :f_bld_gubun							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nut_date", nutDate);
		query.setParameter("f_bld_gubun", bldGubun);
		
		List<String> list = query.getResultList();
		return list.get(0);
	}
}

