package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0805RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR0803U01grdNUR0805Info;

public class Nur0805RepositoryImpl implements Nur0805RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<NUR0803U01grdNUR0805Info> getNUR0803U01grdNUR0805Info(String hospCode, String needGubun,
			String needAsmtCode, String needResultCode, Date startDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NEED_GUBUN       AS         NEED_GUBUN         ");
		sql.append("	     , A.NEED_ASMT_CODE   AS         NEED_ASMT_CODE     ");
		sql.append("	     , A.NEED_RESULT_CODE AS         NEED_RESULT_CODE   ");
		sql.append("	     , A.NEED_SO_CODE     AS         NEED_SO_CODE       ");
		sql.append("	     , A.NEED_SO_NAME     AS         NEED_SO_NAME       ");
		sql.append("	     , A.NEED_SO_POINT    AS         NEED_SO_POINT      ");
		sql.append("	     , A.SORT_KEY         AS         SORT_KEY           ");
		sql.append("	     , A.START_DATE       AS         START_DATE         ");
		sql.append("	     , A.H_FILE_FLAG      AS         H_FILE_FLAG        ");
		sql.append("	  FROM NUR0805 A                                        ");
		sql.append("	 WHERE A.HOSP_CODE        = :f_hosp_code                ");
		sql.append("	   AND A.NEED_GUBUN       = :f_need_gubun               ");
		sql.append("	   AND A.NEED_ASMT_CODE   = :f_need_asmt_code           ");
		sql.append("	   AND A.NEED_RESULT_CODE = :f_need_result_code         ");
		sql.append("	   AND A.START_DATE       = :f_start_date               ");
		sql.append("	 ORDER BY                                               ");
		sql.append("	       NEED_ASMT_CODE                                   ");
		sql.append("	     , NEED_RESULT_CODE                                 ");
		sql.append("	     , SORT_KEY                                         ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_gubun", needGubun);
		query.setParameter("f_need_asmt_code", needAsmtCode);
		query.setParameter("f_need_result_code", needResultCode);
		query.setParameter("f_start_date", startDate);

		List<NUR0803U01grdNUR0805Info> lstResult = new JpaResultMapper().list(query, NUR0803U01grdNUR0805Info.class);
		return lstResult;
	}

}
