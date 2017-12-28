package nta.med.data.dao.medi.nur;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.model.ihis.nuri.NUR1094U00GrdMasterInfo;

public class Nur1093RepositoryImpl implements Nur1093RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<NUR1094U00GrdMasterInfo> getNUR1094U00GrdMasterInfo(String hospCode, Double pkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PKNUR1094                                      AS PKNUR1094,                                         ");
		sql.append("	       A.FKINP1001                                      AS FKINP1001,                                         ");
		sql.append("	       A.CREATE_DATE                                    AS CREATE_DATE,                                       ");
		sql.append("	       A.INPUT_ID                                       AS INPUT_ID,                                          ");
		sql.append("	       FN_ADM_USER_NM(:f_hosp_code, A.INPUT_ID)         AS INPUT_ID_NAME,                                     ");
		sql.append("	       A.SUM_SCORE                                      AS SUM_SCORE,                                         ");
		sql.append("	       A.LEVEL_SCORE                                    AS LEVEL_SCORE,                                       ");
		sql.append("	       (SELECT X.CODE_NAME                                                                                    ");
		sql.append("	          FROM NUR1093 X                                                                                      ");
		sql.append("	         WHERE X.HOSP_CODE   = A.HOSP_CODE                                                                    ");
		sql.append("	           AND X.CODE        = A.LEVEL_SCORE                                                                  ");
		sql.append("	           AND A.CREATE_DATE BETWEEN X.FROM_DATE AND IFNULL(X.TO_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) ");
		sql.append("	        )                                               AS LEVEL_SCORE_NAME,                                  ");
		sql.append("	       A.REMARK                                         AS REMARK                                             ");
		sql.append("	  FROM NUR1094 A                                                                                              ");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code                                                                            ");
		sql.append("	   AND A.FKINP1001  = :f_pkinp1001                                                                            ");
		sql.append("	 ORDER BY                                                                                                     ");
		sql.append("	       A.CREATE_DATE DESC                                                                                     ");
		sql.append("	     , A.PKNUR1094 DESC                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		
		List<NUR1094U00GrdMasterInfo> list = new JpaResultMapper().list(query, NUR1094U00GrdMasterInfo.class);
		return list;
	}
}
