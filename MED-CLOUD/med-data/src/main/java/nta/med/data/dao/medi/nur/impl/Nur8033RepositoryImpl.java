package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur8033RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR8003U03GrdAInfo;

public class Nur8033RepositoryImpl implements Nur8033RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<NUR8003U03GrdAInfo> getNUR8003U03GrdAInfo(String hospCode, String bunho, Date writeDate, String hoDong,
			String needGubun, String migrationDisp) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.NEED_GUBUN      , '')       AS FIRST_GUBUN           ");
		sql.append("	     , IFNULL(A.NEED_ASMT_CODE  , '')       AS GR_CODE               ");
		sql.append("	     , IFNULL(A.NEED_ASMT_NAME  , '')       AS GR_NAME               ");
		sql.append("	     , IFNULL(A.NEED_RESULT_CODE, '')       AS RS_CODE               ");
		sql.append("	     , IFNULL(A.NEED_RESULT_NAME, '')       AS RS_NAME               ");
		sql.append("	     , IFNULL(B.SM_CODE         , '')       AS SM_CODE               ");
		sql.append("	     , IFNULL(B.SM_DETAIL       , '')       AS SM_DETAIL             ");
		sql.append("	     , B.NUR_POINT              			AS NUR_POINT             ");
		sql.append("	     , IFNULL(B.NEW_SM_CODE  , '')          AS NEW_SM_CODE           ");
		sql.append("	     , IFNULL(B.NEW_SM_DETAIL, '')          AS NEW_SM_DETAIL         ");
		sql.append("	     , B.NEW_NUR_POINT          			AS NEW_NUR_POINT         ");
		sql.append("	     , A.SORT_KEY               			AS SORT_KEY              ");
		sql.append("	     , IFNULL(A.SUM_GUBUN, '')              AS SUM_GUBUN             ");
		sql.append("	     , IFNULL(A.GLOBAL_YN, '')              AS GLOBAL_YN             ");
		sql.append("	     , B.WRITE_DATE             			AS WRITE_DATE            ");
		sql.append("	  FROM VW_NUR_NEED_CODE_INFO A                                       ");
		sql.append("	  LEFT JOIN NUR8033 B ON B.HOSP_CODE    = A.HOSP_CODE                ");
		sql.append("	                     AND B.BUNHO        = :f_bunho                   ");
		sql.append("	                     AND B.WRITE_DATE   = :f_write_date              ");
		sql.append("	                     AND B.FIRST_GUBUN  = A.NEED_GUBUN               ");
		sql.append("	                     AND B.GR_CODE      = A.NEED_ASMT_CODE           ");
		sql.append("	                     AND B.RS_CODE      = A.NEED_RESULT_CODE         ");
		sql.append("	                     AND B.WRITE_HODONG = :f_ho_dong                 ");
		sql.append("	,(select @kcck_hosp_code \\:= :f_hosp_code) TMP					     ");
		sql.append("	 WHERE A.HOSP_CODE       = :f_hosp_code                              ");
		sql.append("	   AND A.HO_DONG         = :f_ho_dong                                ");
		sql.append("	   AND A.NEED_GUBUN      = :f_need_gubun                             ");
		sql.append("	   AND :f_write_date BETWEEN A.START_DATE AND A.END_DATE             ");
		sql.append("	   AND (   (:f_migration_disp = '%')                                 ");
		sql.append("	        OR (:f_migration_disp = 'N' AND A.NEED_RESULT_CODE <> '00')  ");
		sql.append("	        OR (:f_migration_disp = 'Y' AND A.NEED_RESULT_CODE  = '00')  ");
		sql.append("	       )                                                             ");
		sql.append("	 ORDER BY SORT_KEY                                                   ");
		sql.append("	        , SORT_KEY2                                                  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_write_date", writeDate);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_need_gubun", needGubun);
		query.setParameter("f_migration_disp", migrationDisp);

		List<NUR8003U03GrdAInfo> lstResult = new JpaResultMapper().list(query, NUR8003U03GrdAInfo.class);
		return lstResult;
	}

}
