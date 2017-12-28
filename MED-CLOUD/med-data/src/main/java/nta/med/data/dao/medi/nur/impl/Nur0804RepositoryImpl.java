package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0804RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR0803U01grdNUR0804Info;

public class Nur0804RepositoryImpl implements Nur0804RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<NUR0803U01grdNUR0804Info> getNUR0803U01grdNUR0804Info(String hospCode, String needGubun,
			String needAsmtCode, Date startDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NEED_GUBUN       AS         NEED_GUBUN        ");
		sql.append("	     , A.NEED_ASMT_CODE   AS         NEED_ASMT_CODE    ");
		sql.append("	     , A.NEED_RESULT_CODE AS         NEED_RESULT_CODE  ");
		sql.append("	     , A.NEED_RESULT_NAME AS         NEED_RESULT_NAME  ");
		sql.append("	     , A.SUM_GUBUN        AS         SUM_GUBUN         ");
		sql.append("	     , A.SORT_KEY         AS         SORT_KEY          ");
		sql.append("	     , A.GLOBAL_YN        AS         GLOBAL_YN         ");
		sql.append("	     , A.START_DATE       AS         START_DATE        ");
		sql.append("	  FROM NUR0804 A                                       ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code                 ");
		sql.append("	   AND A.NEED_GUBUN     = :f_need_gubun                ");
		sql.append("	   AND A.NEED_ASMT_CODE = :f_need_asmt_code            ");
		sql.append("	   AND A.START_DATE     = :f_start_date                ");
		sql.append("	 ORDER BY                                              ");
		sql.append("	       NEED_ASMT_CODE                                  ");
		sql.append("	     , NEED_RESULT_CODE                                ");
		sql.append("	     , SORT_KEY                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_need_gubun", needGubun);
		query.setParameter("f_need_asmt_code", needAsmtCode);
		query.setParameter("f_start_date", startDate);
		
		List<NUR0803U01grdNUR0804Info> list = new JpaResultMapper().list(query, NUR0803U01grdNUR0804Info.class);
		return list;
	}

}
