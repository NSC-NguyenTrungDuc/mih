package nta.med.data.dao.medi.inv.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inv.Inv4002RepositoryCustom;
import nta.med.data.model.ihis.invs.INV4001U00Grd4002Info;

public class Inv4002RepositoryImpl implements Inv4002RepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<INV4001U00Grd4002Info> getINV4001U00Grd4002Info(String hospCode, String language, Double fkinv4001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PKINV4002                AS PKINV4002                                                     ");
		sql.append("      , A.FKINV4001                AS FKINV4001                                                     ");
		sql.append("      , A.JAERYO_CODE              AS JAERYO_CODE                                                   ");
		sql.append("      , B.JAERYO_NAME              AS JAERYO_NAME                                                   ");
		sql.append("      , A.IPGO_QTY                 AS IPGO_QTY                                                      ");
		sql.append("       , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', B.SUBUL_DANUI, :hosp_code, :language) IPGO_DANUI_NAME ");
		sql.append("      , A.IPGO_DANGA               AS IPGO_DANGA                                                    ");
		sql.append("      , A.REMARK                   AS REMARK                                                        ");
		sql.append("      , A.IPGO_QTY * A.IPGO_DANGA  AS SUM_DANGA                                                     ");
		sql.append("      , A.START_DATE               AS START_DATE                                                    ");
		sql.append("      , A.LOT                      AS LOT                                                           ");
		sql.append("      , A.EXPIRED_DATE             AS EXPIRED_DATE                                                  ");
		sql.append("   FROM INV0110 B                                                                                   ");
		sql.append("      , INV4002 A                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE                = :hosp_code                                                     ");
		sql.append("    AND A.FKINV4001                = :f_fkinv4001                                                   ");
		sql.append("    AND B.HOSP_CODE                = A.HOSP_CODE                                                    ");
		sql.append("    AND B.JAERYO_CODE              = A.JAERYO_CODE                                                  ");
		sql.append("  ORDER BY B.JAERYO_NAME	LIMIT 100																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_fkinv4001", fkinv4001);
		
		List<INV4001U00Grd4002Info> list = new JpaResultMapper().list(query, INV4001U00Grd4002Info.class);
		return list;
	}

}
