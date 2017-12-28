package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1092RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1091Q00layDownListInfo;
import nta.med.data.model.ihis.nuri.NUR1094U00GrdDetailInfo;

public class Nur1092RepositoryImpl implements Nur1092RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<NUR1094U00GrdDetailInfo> getNUR1094U00GrdDetailInfo(String hospCode, Double fknur1094) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.FKNUR1094         AS FKNUR1094                                                                 ");
		sql.append("	       ,A.CODE_TYPE         AS CODE_TYPE                                                                 ");
		sql.append("	       ,B.CODE_TYPE_NAME    AS CODE_TYPE_NAME                                                            ");
		sql.append("	       ,B.MAX_SCORE         AS MAX_SCORE                                                                 ");
		sql.append("	       ,A.CODE              AS CODE                                                                      ");
		sql.append("	       ,C.CODE_NAME         AS CODE_NAME                                                                 ");
		sql.append("	       ,C.SCORE             AS SCORE                                                                     ");
		sql.append("	 FROM                                                                                                    ");
		sql.append("	        NUR1092 C                                                                                        ");
		sql.append("	       ,NUR1091 B                                                                                        ");
		sql.append("	       ,(SELECT X.CREATE_DATE                                                                            ");
		sql.append("	              , Y.*                                                                                      ");
		sql.append("	           FROM NUR1095 Y                                                                                ");
		sql.append("	              , NUR1094 X                                                                                ");
		sql.append("	          WHERE X.HOSP_CODE = :f_hosp_code                                                               ");
		sql.append("	            AND X.PKNUR1094 = :f_fknur1094                                                               ");
		sql.append("	            AND Y.HOSP_CODE = X.HOSP_CODE                                                                ");
		sql.append("	            AND Y.FKNUR1094 = X.PKNUR1094                                                                ");
		sql.append("	         ) A                                                                                             ");
		sql.append("	 WHERE                                                                                                   ");
		sql.append("	        A.HOSP_CODE     = :f_hosp_code                                                                   ");
		sql.append("	   AND  A.FKNUR1094     = :f_fknur1094                                                                   ");
		sql.append("	   AND  B.HOSP_CODE     = A.HOSP_CODE                                                                    ");
		sql.append("	   AND  B.CODE_TYPE     = A.CODE_TYPE                                                                    ");
		sql.append("	   AND  A.CREATE_DATE   BETWEEN B.FROM_DATE AND IFNULL(B.TO_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) ");
		sql.append("	   AND  C.HOSP_CODE     = A.HOSP_CODE                                                                    ");
		sql.append("	   AND  C.CODE_TYPE     = A.CODE_TYPE                                                                    ");
		sql.append("	   AND  C.CODE          = A.CODE                                                                         ");
		sql.append("	   AND  A.CREATE_DATE   BETWEEN C.FROM_DATE AND IFNULL(C.TO_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) ");
		sql.append("	 ORDER BY                                                                                                ");
		sql.append("	        B.SORT_SEQ                                                                                       ");
		sql.append("	       ,C.SORT_SEQ                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fknur1094", fknur1094);
		
		List<NUR1094U00GrdDetailInfo> list = new JpaResultMapper().list(query, NUR1094U00GrdDetailInfo.class);
		return list;
	}

	@Override
	public List<NUR1091Q00layDownListInfo> getNUR1091Q00layDownListInfo(String hospCode, String codeType,
			Date fDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.CODE_TYPE       AS CODE_TYPE                                                               ");
		sql.append("	     , A.CODE_TYPE_NAME  AS CODE_TYPE_NAME                                                          ");
		sql.append("	     , A.MAX_SCORE       AS MAX_SCORE                                                               ");
		sql.append("	     , B.CODE            AS CODE                                                                    ");
		sql.append("	     , B.CODE_NAME       AS CODE_NAME                                                               ");
		sql.append("	     , B.SCORE           AS SCORE                                                                   ");
		sql.append("	  FROM NUR1092     B                                                                                ");
		sql.append("	     , NUR1091     A                                                                                ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                                   ");
		sql.append("	   AND :f_date     BETWEEN A.FROM_DATE AND IFNULL(A.TO_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                                                                    ");
		sql.append("	   AND B.CODE_TYPE = A.CODE_TYPE                                                                    ");
		sql.append("	   AND B.CODE_TYPE = :f_code_type                                                                   ");
		sql.append("	   AND :f_date     BETWEEN B.FROM_DATE AND IFNULL(B.TO_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) ");
		sql.append("	 ORDER BY                                                                                           ");
		sql.append("	       A.SORT_SEQ                                                                                   ");
		sql.append("	     , B.SORT_SEQ                                                                                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_date", fDate);
		
		List<NUR1091Q00layDownListInfo> list = new JpaResultMapper().list(query, NUR1091Q00layDownListInfo.class);
		return list;
	}

}
