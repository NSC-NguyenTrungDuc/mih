package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur8050RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR8050U00grdNur8050HisInfo;

/**
 * @author dainguyen.
 */
public class Nur8050RepositoryImpl implements Nur8050RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR8050U00grdNur8050HisInfo> getNUR8050U00grdNur8050HisInfo(String hospCode, String bunho,
			Double fkinp1001, String gubun) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BUNHO                                                                               ");
		sql.append("	     , FN_OUT_LOAD_SUNAME(A.BUNHO, :f_hosp_code)                        AS SUNAME            ");
		sql.append("	     , A.FKINP1001                                                                           ");
		sql.append("	     , A.GUBUN                                                                               ");
		sql.append("	     , A.DETAIL                                                                              ");
		sql.append("	     , A.WRITE_DATE                                                                          ");
		sql.append("	     , A.WRITE_USER                                                                          ");
		sql.append("	     , FN_ADM_LOAD_USER_NM(:f_hosp_code, A.WRITE_USER, SYSDATE())       AS WRITE_USER_NAME   ");
		sql.append("	     , A.CONFIRM_USER                                                                        ");
		sql.append("	     , FN_ADM_LOAD_USER_NM(:f_hosp_code, A.CONFIRM_USER, SYSDATE())     AS CONFIRM_USER_NAME ");
		sql.append("	  FROM NUR8050 A                                                                             ");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code                                                           ");
		sql.append("	   AND A.BUNHO      = :f_bunho                                                               ");
		sql.append("	   AND A.FKINP1001  = :f_fkinp1001                                                           ");
		sql.append("	   AND A.GUBUN      LIKE :f_gubun                                                            ");
		sql.append("	 ORDER BY A.WRITE_DATE DESC, A.GUBUN                                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_gubun", gubun);
		
		List<NUR8050U00grdNur8050HisInfo> listInfo = new JpaResultMapper().list(query, NUR8050U00grdNur8050HisInfo.class);
		return listInfo;
	}
}
